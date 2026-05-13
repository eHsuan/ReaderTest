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

                int activeCount = int.Parse(config["ActiveReaderCount"] ?? "0");
                activeCount = Math.Clamp(activeCount, 0, 2);

                _activeReaders.Clear();
                var readersConfig = config.GetSection("Readers").GetChildren();
                int index = 0;

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
                        LogControl = index == 0 ? txtLogLeft : txtLogRight,
                        NameLabel = index == 0 ? lblNameLeft : lblNameRight
                    };
                    _activeReaders.Add(instance);
                    index++;
                }

                // UI 更新
                lblNameLeft.Visible = txtLogLeft.Visible = activeCount >= 1;
                lblNameRight.Visible = txtLogRight.Visible = activeCount >= 2;
                
                if (activeCount >= 1) lblNameLeft.Text = _activeReaders[0].Name;
                if (activeCount >= 2) lblNameRight.Text = _activeReaders[1].Name;

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
            int bytesRead = await stream.ReadAsync(buffer, token);
            if (bytesRead == 0) return "";

            return Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim('\r', '\n', ' ');
        }

        private void ProcessResult(ReaderInstance reader, string currentId)
        {
            bool isCurrentValid = !string.IsNullOrEmpty(currentId) && currentId != "ERROR";

            if (isCurrentValid)
            {
                if (!reader.IsLastReadValid || currentId != reader.LastSavedPanelId)
                {
                    SaveToCsv(reader.Name, currentId);
                    reader.LastSavedPanelId = currentId;
                    AppendLog(reader, $"[讀取成功] ID: {currentId}");
                }
                reader.IsLastReadValid = true;
            }
            else
            {
                if (reader.IsLastReadValid)
                {
                    AppendLog(reader, "[狀態重置] 視野內無條碼");
                }
                reader.IsLastReadValid = false;
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
                            writer.WriteLine("Timestamp,ReaderName,Panel_ID");
                        }
                        writer.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff},{readerName},{panelId}");
                    }
                }
                catch (Exception ex)
                {
                    // 若寫入失敗，僅能顯示在系統日誌中，避免主迴圈崩潰
                }
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
            // 將系統日誌顯示在第一個啟用的 Reader TextBox，若無啟動則不顯示
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

            public void ResetState()
            {
                LastSavedPanelId = "";
                IsLastReadValid = false;
            }
        }
    }
}
