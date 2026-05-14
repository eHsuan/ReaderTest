using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace ReadResultAnalyzer
{
    public partial class MainForm : Form
    {
        private const string MESSAGE_FILE_NO_EXIST = "< Historical data file doesn't exist. >";
        private const string MESSAGE_FILE_CORRECT = "< Find historical data file(s). >";
        private const string MESSAGE_FIND_NEW_FILE = "< Find new historical data file(s). >";
        private const string MESSAGE_JPEG_NO_EXIST = "< CANNOT find any image file in the historical data. >";

        private string m_ftpPath = String.Empty;
        FileSystemWatcher watcher = null;
        public MainForm()
        {
            InitializeComponent();
            tbxServerPath.ReadOnly = true;
            lbVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private void btnFolderSelect_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select FTP path";
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                tbxServerPath.Text = folderBrowserDialog1.SelectedPath;
                m_ftpPath = folderBrowserDialog1.SelectedPath;

                watcher = new System.IO.FileSystemWatcher();

                watcher.Path = m_ftpPath;

                watcher.NotifyFilter =
                    (System.IO.NotifyFilters.LastAccess
                    | System.IO.NotifyFilters.LastWrite
                    | System.IO.NotifyFilters.FileName
                    | System.IO.NotifyFilters.DirectoryName);

                watcher.Filter = "*.json";

                watcher.SynchronizingObject = this;

                watcher.Created += new FileSystemEventHandler(watcher_Changed);
                watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);

                watcher.EnableRaisingEvents = true;

                // Newest historicalDataFile Search
                lbNewFileName.Text = getLatestHistoricalFileName(m_ftpPath);

                // Check file
                if (lbNewFileName.Text == string.Empty)
                {
                    lbNewJpgFileName.Text = MESSAGE_FILE_NO_EXIST;
                }
                else
                {
                    lbNewJpgFileName.Text = MESSAGE_FILE_CORRECT;
                }
            }
        }

        private void watcher_Changed(System.Object source, System.IO.FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    string fileName = Path.GetFileName(e.FullPath);
                    lbNewFileName.Text = fileName;
                    lbNewJpgFileName.Text = MESSAGE_FIND_NEW_FILE;
                    break;
                default:
                    break;
            }
        }

        private void watcher_Deleted(System.Object source, System.IO.FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Deleted:
                    lbNewFileName.Text = string.Empty;
                    lbNewJpgFileName.Text = MESSAGE_FILE_NO_EXIST;
                    break;

                default:
                    break;
            }
        }

        private void btnShowImage_Click_1(object sender, EventArgs e)
        {
            //initialization
            picBxJpegImageView.ImageLocation = null;
            lbNewFileName.Text = string.Empty;
            lbNewJpgFileName.Text = string.Empty;
            lbReadDate.Text = string.Empty;
            lbReadData.Text = string.Empty;
            lbReadData.Update();
            string latestFileName = string.Empty;

            // Check FTP path input
            if (m_ftpPath == string.Empty)
            {
                MessageBox.Show("FTP server path is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get the latest historical data file
            latestFileName = getLatestHistoricalFileName(m_ftpPath);
            lbNewFileName.Text = latestFileName;

            // check historical data file
            if (lbNewFileName.Text == string.Empty)
            {
                lbNewJpgFileName.Text = MESSAGE_FILE_NO_EXIST;
                MessageBox.Show("Historical data file doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string historicalDataFile = m_ftpPath + "\\" + latestFileName;

            // Check file name
            if (latestFileName.Contains(".json") != true)
            {
                MessageBox.Show("File name error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HistoricalData historical_data = new HistoricalData(historicalDataFile);
            if (historical_data.isDataOK != true)
            {
                MessageBox.Show("Historical data content is not correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get Jpeg file name from historical data file
            string jpegFileName = historical_data.GetJpegFileName();

            // No Jpeg file
            if (jpegFileName == string.Empty)
            {
                lbNewJpgFileName.Text = MESSAGE_JPEG_NO_EXIST;
                MessageBox.Show("Jpeg file does not exist in the historical data file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get corner point from historical data file
            List<Point> posList = historical_data.GetCornerPointList();

            // Check list of center point
            if (posList.Count() == 0)
            {
                MessageBox.Show("\"code corner\" does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Draw rectangle 
            JpegOperate jpeg_operate = new JpegOperate();
            jpegFileName = m_ftpPath + "\\" + jpegFileName;
            int ret_mark = jpeg_operate.DrawAndSave(jpegFileName, posList);

            if (ret_mark != 0)
            {
                switch (ret_mark)
                {
                    case JpegOperate.NOT_JPG_FILE:
                        MessageBox.Show("Saved file was not a jpeg file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case JpegOperate.JPG_NOT_EXIST:
                        MessageBox.Show("Jpeg file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case JpegOperate.NOT_MAKE_BMP:
                        MessageBox.Show("Failed to read image data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case JpegOperate.NOT_SAVE_FILE:
                        MessageBox.Show("CANNOT Save new JPEG file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        break;
                }
                return;
            }

            // Show ReadData & DateTime
            lbReadDate.Text = historical_data._date + historical_data._time;
            lbReadData.Text = historical_data.GetReaddataString(historical_data._out_data);
            // Show Jpeg view
            this.picBxJpegImageView.ImageLocation = jpegFileName + JpegOperate.EXTENDED_STRING;
            // Show jpgFileName
            lbNewJpgFileName.Text = Path.GetFileName(jpegFileName + JpegOperate.EXTENDED_STRING);
        }

        private string getLatestHistoricalFileName(string folderName)
        {
            string[] historicalDataFiles;

            try
            {
                historicalDataFiles = System.IO.Directory.GetFiles(folderName, "*.json", System.IO.SearchOption.TopDirectoryOnly);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            string newesthistoricalDataFileName = string.Empty;
            System.DateTime updateTime = System.DateTime.MinValue;

            // Newest historicalDataFile Searching.
            foreach (string file in historicalDataFiles)
            {
                // Get historicalDataFile Infomation
                System.IO.FileInfo fi = new System.IO.FileInfo(file);

                // Judge DateTime
                if (fi.LastWriteTime > updateTime)
                {
                    updateTime = fi.LastWriteTime;
                    newesthistoricalDataFileName = file;
                }
            }

            return System.IO.Path.GetFileName(newesthistoricalDataFileName);
        }



    }
}
