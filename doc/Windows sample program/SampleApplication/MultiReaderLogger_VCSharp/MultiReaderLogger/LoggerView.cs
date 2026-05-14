using System;
using System.Text;
using System.Windows.Forms;
using Keyence.AutoID.SDK;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Linq;



namespace MultiReaderLogger
{
    public partial class LoggerView : UserControl
    {
        private const int STORED_IMAGE_FILE_COUNT = 2;
        private const int STORED_IMAGE_INTERVAL_MS = 1000;

        private DataLogger m_dataLogger = null;
        private ImageLogger m_imageLogger = null;

        #region PRIVATE_CLASS
        private class Logger
        {
            protected ReaderAccessor m_reader = new ReaderAccessor();
            protected string m_storedFilePath = "";

            public Logger(string ip, string storedPath) {
                m_reader.IpAddress = ip;
                m_storedFilePath = storedPath;
                Directory.CreateDirectory(storedPath);
            }
            public void Dispose()
            {
                Stop();
                
                m_reader.Disconnect();
                m_reader.Dispose();
            }
            virtual public void Start() { }
            virtual public void Stop() { }
            virtual public void WaitStopIfPossible() { }
        }
        private class DataLogger : Logger
        {
            public DataLogger(string ip, string storedPath) : base(ip, storedPath) { }

            public Action<string> DataReceivedCallback { set; get; } = null;

            private void process(byte[] data)
            {
                try
                {
                    string storedText = "[" + DateTime.Now + "]" + Encoding.ASCII.GetString(data);
                    using (var fs = new FileStream(m_storedFilePath + "\\readdata.csv", FileMode.Append, FileAccess.Write, FileShare.Read))
                    {
                        using (System.IO.StreamWriter textFile = new System.IO.StreamWriter(fs))
                        {
                            textFile.WriteLine(storedText);
                            textFile.Close();
                        }
                    }
                    DataReceivedCallback(storedText);
                }
                catch
                {
                    MessageBox.Show(m_reader.IpAddress + ":Can not access readdata.csv because it is being used by another process.");
                }
            }

            public override void Start()
            {
                m_reader.Connect(process);
            }

            public override void Stop()
            {
                m_reader.Disconnect();
            }
        }
        private class ImageLogger : Logger
        {
            private Thread m_thread = null;
            private bool m_invokeStop = false; 

            public ImageLogger(string ip, string storedPath) : base(ip, storedPath) { }
            public override void Start()
            {
                if (m_thread == null)
                {
                    m_thread = new Thread(process);
                    m_thread.IsBackground = true;
                    m_invokeStop = false;
                    m_thread.Start();
                }
            }
            public override void Stop()
            {
                if (m_thread != null)
                {
                    m_invokeStop = true;
                }               
            }
            public override void WaitStopIfPossible()
            {
                if (m_invokeStop && m_thread != null)
                {
                    m_thread.Join();
                    m_thread = null;
                } 
            }

            private void process()
            {
                clearDeviceFiles();

                int imageLogInterval = 0;
                int timerInterval = STORED_IMAGE_INTERVAL_MS;
                var sw = new System.Diagnostics.Stopwatch();

                while (!m_invokeStop)
                {
                    sw.Restart();
                    if (m_reader.OpenFtp())
                    {
                        string nowTime = System.DateTime.Now.ToString().Replace('/', '_').Replace(':', '_').Replace(' ', '_');
                        string savePath = m_storedFilePath + "\\[" + nowTime + "]";

                        List<string> srImageFiles = m_reader.GetFileList("IMAGE");

                        // Remove LIVE.BIN,EXTRALIVE.BIN
                        srImageFiles.Remove("LIVE.BIN");
                        srImageFiles.Remove("EXTRALIVE.BIN");

                        // select saving files from image files in SR.
                        List<string> savingFiles = selectLastNFiles(new List<string>(srImageFiles), STORED_IMAGE_FILE_COUNT);

                        foreach (string file in savingFiles)
                        {
                            m_reader.GetFile("IMAGE\\" + file, savePath + file);
                        }
                        foreach (string file in srImageFiles)
                        {
                            m_reader.DeleteFile("IMAGE\\" + file);
                        }                   
                        m_reader.CloseFtp();

                        imageLogInterval = timerInterval - (int)sw.ElapsedMilliseconds;
                        //If the processing time is less than timerInterval, the thread is stopped for timerInterval.
                        if (imageLogInterval > 0) Thread.Sleep(imageLogInterval);
                    }
                }
            }
            private void clearDeviceFiles()
            {
                    m_reader.OpenFtp();
                    List<string> initialFileList = m_reader.GetFileList("IMAGE");
                    if (initialFileList != null)
                    {
                        foreach (string fileName in initialFileList)
                        {
                            m_reader.DeleteFile("IMAGE\\" + fileName);
                        }
                    }
                    m_reader.CloseFtp();
                    return;
            }
            private List<string> selectLastNFiles(List<string> files, int maxFileCount)
            {              
                files.Sort();
                if (files.Count < maxFileCount) return files;

                files = sortFilesByTimeOrder(files);
                //return last (maxFileCount) files
                return files.Skip(files.Count - maxFileCount).ToList();
            }
            private List<string> sortFilesByTimeOrder(List<string> files)
            {
                //  sort files{("000_S_01.jpg","001_S_01.jpg","998_S_01.jpg","999_S_01.jpg") =>("998_S_01.jpg","999_S_01.jpg""000_S_01.jpg","001_S_01.jpg")}
                if (files[0].StartsWith("000") && files[files.Count - 1].StartsWith("999"))
                {
                    int lastFileIndex = 0;
                    for (int i = 0; i < files.Count - 1; i++)
                    {
                        int currentIndex;
                        int nextIndex;
                        int.TryParse(files[i].Substring(0, 3), out currentIndex);
                        int.TryParse(files[i + 1].Substring(0, 3), out nextIndex);
                        if (nextIndex - currentIndex > 1)
                        {
                            lastFileIndex = i;
                            break;
                        }
                    }
                    for (int i = 0; i <= lastFileIndex; i++)
                    {
                        files.Add(files[0]);
                        files.RemoveAt(0);
                    }
                }
                return files;
            }
        }
        #endregion

        #region PUBLIC_METHOD   
        public LoggerView(string ipAddr, string storedPath, LiveviewForm.ImageBinningType binningType, int pulltime)
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left;
            liveviewForm1.BinningType = binningType;
            liveviewForm1.PullTimeSpan = pulltime;
            liveviewForm1.IpAddress = ipAddr;
            liveviewForm1.BeginReceive();
            readerInfo.Text = ipAddr;

            m_dataLogger = new DataLogger(ipAddr, storedPath);
            m_imageLogger = new ImageLogger(ipAddr, storedPath);
        }
        
        public void Deinit()
        {
            m_dataLogger.Dispose();
            m_imageLogger.Dispose();

            liveviewForm1.EndReceive();
            liveviewForm1.Dispose();
        }
        public void SetDataLog(bool enable)
        {
            if (enable)
            {
                m_dataLogger.DataReceivedCallback = notifyData;
                m_dataLogger.Start();
            }
            else m_dataLogger.Stop();
        }
        public void RequestChangeImageLogState(bool enable)
        {
            if (enable) m_imageLogger.Start();
            else m_imageLogger.Stop();
        }
        public void WaitReadyImageLogStateChanged()
        {
             m_imageLogger.WaitStopIfPossible();
        }
        #endregion

        #region PRIVATE_METHOD 
        //Delegate method for UserControls
        private delegate void handleData(string str);
        private void notifyData(string data)
        {
            BeginInvoke(new handleData(updateDataView), data);
        }
        private void updateDataView(string data)
        {
            readerData.Text = data;
        }
        #endregion
    }
}
