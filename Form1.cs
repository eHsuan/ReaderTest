using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace ReaderTestApp
{
    public partial class Form1 : Form
    {
        private bool _isRunning = false;
        private CancellationTokenSource? _cts;
        private readonly List<ReaderInstance> _activeReaders = new();
        private static readonly object _csvLock = new object();
        private string _calibCommand = "TUNE,01\r";

        public Form1()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                _calibCommand = config["CalibrationCommand"] ?? "TUNE,01\r";
                int activeCount = int.Parse(config["ActiveReaderCount"] ?? "0");
                activeCount = Math.Clamp(activeCount, 0, 4);

                _activeReaders.Clear();
                var readersConfig = config.GetSection("Readers").GetChildren();
                int index = 0;

                TextBox[] logBoxes = { txtLog1, txtLog2, txtLog3, txtLog4 };
                Label[] nameLabels = { lblName1, lblName2, lblName3, lblName4 };
                Button[] calibBtns = { btnCalib1, btnCalib2, btnCalib3, btnCalib4 };

                // 隱藏所有
                foreach (var tb in logBoxes) tb.Visible = false;
                foreach (var lb in nameLabels) lb.Visible = false;
                foreach (var bt in calibBtns) bt.Visible = false;

                foreach (var rCfg in readersConfig)
                {
                    if (index >= activeCount) break;

                    var instance = new ReaderInstance
                    {
                        Name = rCfg["ReaderName"] ?? $"Reader_{index + 1}",
                        IP = rCfg["IP"] ?? "127.0.0.1",
                        Port = int.Parse(rCfg["Port"] ?? "9000"),
                        PollingInterval = int.Parse(rCfg["PollingIntervalMs"] ?? "500"),
                        TriggerCommand = rCfg["TriggerCommand"] ?? "LON\r",
                        TimeoutMs = int.Parse(rCfg["TimeoutMs"] ?? "2000"),
                        LogControl = logBoxes[index],
                        NameLabel = nameLabels[index],
                        CalibButton = calibBtns[index]
                    };

                    instance.LogControl.Visible = true;
                    instance.NameLabel.Visible = true;
                    instance.CalibButton.Visible = true;
                    instance.NameLabel.Text = instance.Name;
                    instance.CalibButton.Text = instance.Name;

                    _activeReaders.Add(instance);
                    index++;
                }

                AppendSystemLog($"[系統] 載入設定成功，啟動讀取器數量: {activeCount}");
            }
            catch (Exception ex)
            {
                AppendSystemLog($"[錯誤] 載入設定失敗: {ex.Message}");
            }
        }

        private async void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!_isRunning)
            {
                StartTesting();
            }
            else
            {
                await StopTesting();
            }
        }

        private void StartTesting()
        {
            _isRunning = true;
            btnStartStop.Text = "停止測試";
            _cts = new CancellationTokenSource();

            foreach (var reader in _activeReaders)
            {
                reader.ResetState();
                Task.Run(() => PollingLoop(reader, _cts.Token));
            }

            Task.Run(() => BreathingEffect(_cts.Token));
            AppendSystemLog("[系統] 測試已啟動");
        }

        private async Task StopTesting()
        {
            _isRunning = false;
            btnStartStop.Text = "啟動測試";
            _cts?.Cancel();
            lblIndicator.BackColor = Color.Gray;
            AppendSystemLog("[系統] 測試已停止");
            await Task.Delay(100);
        }

        private async void btnCalibrate_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show("請先停止測試再進行校正。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Button btn = (Button)sender;
            int readerIdx = (int)btn.Tag;
            if (readerIdx >= _activeReaders.Count) return;

            var reader = _activeReaders[readerIdx];
            btn.Enabled = false;
            AppendLog(reader, $"[系統] 開始校正指令: {_calibCommand.Trim()}");

            try
            {
                string result = await SendCalibCommandAsync(reader);
                AppendLog(reader, $"[校正結果] {result}");
            }
            catch (Exception ex)
            {
                AppendLog(reader, $"[校正失敗] {ex.Message}");
            }
            finally
            {
                btn.Enabled = true;
            }
        }

        private async Task<string> SendCalibCommandAsync(ReaderInstance reader)
        {
            using var client = new TcpClient();
            try
            {
                // 使用 WaitAsync 處理連線超時
                await client.ConnectAsync(reader.IP, reader.Port).WaitAsync(TimeSpan.FromMilliseconds(reader.TimeoutMs));
            }
            catch (TimeoutException)
            {
                throw new TimeoutException("連線逾時");
            }

            using var stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(_calibCommand);
            await stream.WriteAsync(data);

            byte[] buffer = new byte[1024];
            // 校正可能需要較長時間，給予 5 秒等待
            DateTime start = DateTime.Now;
            StringBuilder sb = new StringBuilder();

            while ((DateTime.Now - start).TotalSeconds < 5)
            {
                if (client.Available > 0)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string part = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    sb.Append(part);
                    if (part.Contains("\r")) break;
                }
                await Task.Delay(100);
            }

            return sb.ToString().Trim('\r', '\n', ' ');
        }

        private async Task PollingLoop(ReaderInstance reader, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    string result = await ReadFromReaderAsync(reader, token);
                    ProcessResult(reader, result);
                }
                catch (Exception ex)
                {
                    AppendLog(reader, $"[連線異常] {ex.Message}");
                    reader.IsLastReadValid = false;
                }

                await Task.Delay(reader.PollingInterval, token);
            }
        }

        private async Task<string> ReadFromReaderAsync(ReaderInstance reader, CancellationToken token)
        {
            using var client = new TcpClient();
            var connectTask = client.ConnectAsync(reader.IP, reader.Port, token);
            
            if (await Task.WhenAny(connectTask.AsTask(), Task.Delay(reader.TimeoutMs, token)) != connectTask.AsTask())
            {
                throw new TimeoutException("連線逾時");
            }

            using var stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(reader.TriggerCommand);
            await stream.WriteAsync(data, token);

            byte[] buffer = new byte[1024];
            StringBuilder sb = new StringBuilder();
            DateTime startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalMilliseconds < reader.TimeoutMs && !token.IsCancellationRequested)
            {
                if (client.Available > 0)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (bytesRead > 0)
                    {
                        string part = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        sb.Append(part);
                        if (part.Contains("\r"))
                        {
                            string fullReceived = sb.ToString();
                            string[] lines = fullReceived.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var line in lines)
                            {
                                string cleanLine = line.Trim();
                                if (string.IsNullOrEmpty(cleanLine) || cleanLine == "OK" || cleanLine == "LON" || cleanLine == "ERROR") continue;
                                return cleanLine;
                            }
                            sb.Clear();
                        }
                    }
                }
                await Task.Delay(30, token);
            }
            return "";
        }

        private void ProcessResult(ReaderInstance reader, string currentId)
        {
            if (!string.IsNullOrEmpty(currentId))
            {
                if (currentId != reader.LastSavedPanelId)
                {
                    SaveToCsv(reader.Name, currentId);
                    reader.LastSavedPanelId = currentId;
                    AppendLog(reader, $"[讀取成功] ID: {currentId}");
                }
                reader.IsLastReadValid = true;
            }
        }

        private void SaveToCsv(string readerName, string panelId)
        {
            lock (_csvLock)
            {
                try
                {
                    string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Record");
                    if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                    string filePath = Path.Combine(directory, $"{DateTime.Now:yyyyMMdd}.csv");
                    bool fileExists = File.Exists(filePath);

                    using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
                    {
                        if (!fileExists)
                        {
                            writer.WriteLine("Timestamp,ReaderName,ID");
                        }
                        writer.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff},{readerName},{panelId}");
                    }
                }
                catch { }
            }
        }

        private async Task BreathingEffect(CancellationToken token)
        {
            int alpha = 0;
            int step = 15;
            while (!token.IsCancellationRequested)
            {
                alpha += step;
                if (alpha >= 255 || alpha <= 0) step = -step;
                alpha = Math.Clamp(alpha, 0, 255);
                this.Invoke(new Action(() => lblIndicator.BackColor = Color.FromArgb(alpha, 0, 255, 0)));
                await Task.Delay(50, token);
            }
        }

        private void AppendLog(ReaderInstance reader, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => AppendLog(reader, message)));
                return;
            }

            string logEntry = $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}";
            reader.LogControl.AppendText(logEntry);
            reader.LogControl.SelectionStart = reader.LogControl.Text.Length;
            reader.LogControl.ScrollToCaret();
        }

        private void AppendSystemLog(string message)
        {
            if (_activeReaders.Count > 0)
            {
                AppendLog(_activeReaders[0], message);
            }
        }

        private class ReaderInstance
        {
            public string Name { get; set; } = "";
            public string IP { get; set; } = "";
            public int Port { get; set; }
            public int PollingInterval { get; set; }
            public string TriggerCommand { get; set; } = "";
            public int TimeoutMs { get; set; }
            public string LastSavedPanelId { get; set; } = "";
            public bool IsLastReadValid { get; set; } = false;
            public TextBox LogControl { get; set; } = null!;
            public Label NameLabel { get; set; } = null!;
            public Button CalibButton { get; set; } = null!;

            public void ResetState()
            {
                LastSavedPanelId = "";
                IsLastReadValid = false;
            }
        }
    }
}

