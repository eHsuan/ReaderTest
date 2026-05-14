using Keyence.AutoID.SDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace MultiReaderLogger
{
    public partial class Form1 : Form
    {
        // Reader Conponent
        private List<NicSearchResult> m_nicList = new List<NicSearchResult>();
        private ReaderSearcher m_searcher = new ReaderSearcher();
        private Dictionary<string, LoggerView> m_loggerViews = new Dictionary<string, LoggerView>();

        // Liveview param optimize
        private const int MAX_LAYOUT_ROW_COUNT = 4;
        private const int MID_LOAD_READER_COUNT = 8;
        private const int HEAVY_LOAD_READER_COUNT = 16;
        private const int MID_LOAD_PULL_INTERVAL_MS = 100;
        private const int HEAVY_LOAD_PULL_INTERVAL_MS = 1000;
        private const LiveviewForm.ImageBinningType MID_LOAD_BINNING_TYPE = LiveviewForm.ImageBinningType.OneNinth;
        private const LiveviewForm.ImageBinningType HEAVY_LOAD_BINNING_TYPE = LiveviewForm.ImageBinningType.OneSixteenth;

        // LogView Common Parameters
        private int m_liveviewIntervalMs = 100;
        private LiveviewForm.ImageBinningType m_binningType = LiveviewForm.ImageBinningType.OneQuarter;
        private string m_storedFilePath = System.IO.Directory.GetCurrentDirectory();

        #region FORM_CONTROL
        public Form1()
        {
            InitializeComponent();
            // Search Network Interface Card
            m_nicList = m_searcher.ListUpNic();
            if (m_nicList != null)
            {
                for (int i = 0; i < m_nicList.Count; i++)
                {
                    nicComboBox.Items.Add(m_nicList[i].NicIpAddr + "/" + m_nicList[i].NicName);
                }
            }
            nicComboBox.SelectedIndex = 0;
            layoutComboBox.SelectedIndex = 0;
        }
        // Optimize Liveview Parameters depends on readers count
        private void optimizeLiveviewParams(int readerCount)
        {
            m_liveviewIntervalMs = MID_LOAD_PULL_INTERVAL_MS;
            m_binningType = LiveviewForm.ImageBinningType.OneQuarter;
            if (MID_LOAD_READER_COUNT < readerCount && readerCount < HEAVY_LOAD_READER_COUNT)
            {
                m_binningType = MID_LOAD_BINNING_TYPE;
            }
            else if (HEAVY_LOAD_READER_COUNT <= readerCount)
            {
                m_liveviewIntervalMs = HEAVY_LOAD_PULL_INTERVAL_MS;
                m_binningType = HEAVY_LOAD_BINNING_TYPE;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_searcher.Dispose();
            foreach (LoggerView log in m_loggerViews.Values) log.Deinit();
        }
        private void nicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_searcher.SelectedNicSearchResult = m_nicList[nicComboBox.SelectedIndex];
        }
        #endregion
        #region SEARCH_PROCESS
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!m_searcher.IsSearching)
            {
                removeUnusedReaders();
                //Start searching readers
                m_searcher.Start((res) => {
                    BeginInvoke(new delegateSearchResult(appendSearchResult), res);
                });
                searchUIControl(true);
            }
        }
        private void appendSearchResult(ReaderSearchResult res)
        {
            if (res.IpAddress == "")
            {
                searchUIControl(false);
                return;
            }
            string key = getKeyFromSearchResult(res);
            if (SearchedReaders_ChkLstBx.Items.Contains(key))
            {
                return;
            }
            SearchedReaders_ChkLstBx.Items.Add(key);
            label1.Text = SearchedReaders_ChkLstBx.Items.Count + " Readers Found.";
        }
        private void removeUnusedReaders()
        {
            for (int i = SearchedReaders_ChkLstBx.Items.Count - 1; i >= 0; i--)
            {
                String key = SearchedReaders_ChkLstBx.Items[i].ToString();
                if (!SearchedReaders_ChkLstBx.GetItemChecked(i))
                {
                    SearchedReaders_ChkLstBx.Items.Remove(key);
                }
                if (SearchedReaders_ChkLstBx.Items.Count == 0) break;
            }
        }
        //Delegate method for searching process
        private delegate void delegateSearchResult(ReaderSearchResult res);
        private string getKeyFromSearchResult(ReaderSearchResult res)
        {
            return res.IpAddress + "/" + res.ReaderModel + "/" + res.ReaderName;
        }
        private ReaderSearchResult getSearchResultFromKey(string key)
        {
            String[] readerInfo = key.Split('/');
            if (readerInfo.Length == 3)
            {
                return new ReaderSearchResult(readerInfo[1], readerInfo[2], readerInfo[0]);
            }
            return new ReaderSearchResult();
        }
        #endregion
        #region READER_SELECTION
        private void layoutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = layoutComboBox.SelectedIndex + 1;
            RegisteredLoggerView_Panel.ColumnCount = count;
            RegisteredLoggerView_Panel.RowCount = (count > MAX_LAYOUT_ROW_COUNT) ? MAX_LAYOUT_ROW_COUNT : count;

            optimizeLiveviewParams(RegisteredLoggerView_Panel.RowCount * RegisteredLoggerView_Panel.ColumnCount);
        }
        private void SelectAllReaders_ChkBx_CheckedChanged(object sender, EventArgs e)
        {
            RegisteredLoggerView_Panel.Enabled = false;

            for (int i = 0; i < SearchedReaders_ChkLstBx.Items.Count; i++)
            {
                SearchedReaders_ChkLstBx.SetItemChecked(i, SelectAllReaders_ChkBx.Checked);
            }
            RegisteredLoggerView_Panel.Enabled = true;
            this.Refresh();
            registerLoggerViewUIControl();
        }
        private void SearchedReaders_ChkLstBx_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int maxReaderViewCount = (RegisteredLoggerView_Panel.RowCount) * (RegisteredLoggerView_Panel.ColumnCount);
            string key = SearchedReaders_ChkLstBx.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                if (maxReaderViewCount > SearchedReaders_ChkLstBx.CheckedItems.Count)
                {
                    e.NewValue = appendLoggerView(key) ? CheckState.Checked : CheckState.Unchecked;
                }
                else // not append if reader count reaches maximum.
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
            else
            {
                e.NewValue = removeLoggerView(key) ? CheckState.Unchecked : CheckState.Checked;
            }
        }

        private void SearchedReaders_ChkLstBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            registerLoggerViewUIControl();
        }
        #endregion
        #region LOGGER_VIEW
        private bool appendLoggerView(string key)
        {
            if (m_loggerViews.ContainsKey(key)) return false;
            // create & init loggerview
            ReaderSearchResult result = getSearchResultFromKey(key);
            string filePath = m_storedFilePath + "\\" + System.DateTime.Now.ToShortDateString().Replace('/', '_') + "\\" + result.IpAddress.Replace('.', '_');
            LoggerView loggerView = new LoggerView(result.IpAddress, filePath, m_binningType, m_liveviewIntervalMs);

            // register loggerView
            m_loggerViews.Add(key, loggerView);
            RegisteredLoggerView_Panel.Controls.Add(loggerView);
            return true;
        }
        private bool removeLoggerView(string key)
        {
            if (m_loggerViews.ContainsKey(key))
            {
                // deinit loggerview
                m_loggerViews[key].Deinit();
                RegisteredLoggerView_Panel.Controls.Remove(m_loggerViews[key]);
                // unregister loggerView
                m_loggerViews.Remove(key);
                return true;
            }
            return false;
        }
        private void LogData_ChkBx_CheckedChanged(object sender, EventArgs e)
        {
            foreach (LoggerView log in m_loggerViews.Values)
            {
                log.SetDataLog(LogData_ChkBx.Checked);
            }
            loggingUIControl();
        }
        private void LogImage_ChkBx_CheckedChanged(object sender, EventArgs e)
        {
            string notifyMsg = "Image Data in readers delete before logging image files. Continue? ";
            LogImage_ChkBx.Checked = LogImage_ChkBx.Checked && 
                (MessageBox.Show(notifyMsg, "", MessageBoxButtons.YesNo) == DialogResult.Yes);

            foreach (LoggerView log in m_loggerViews.Values)
            {
                log.RequestChangeImageLogState(LogImage_ChkBx.Checked);
            }
            foreach (LoggerView log in m_loggerViews.Values)
            {
                log.WaitReadyImageLogStateChanged();
            }
            loggingUIControl();
        }
        #endregion
        #region UICONTROL
        private void registerLoggerViewUIControl()
        {
            layoutComboBox.Enabled = (SearchedReaders_ChkLstBx.CheckedItems.Count == 0);
        }
        private void searchUIControl(bool enable)
        {
            if (enable)
            {
                Search_Btn.Enabled = false;
                LogData_ChkBx.Enabled = false;
                LogImage_ChkBx.Enabled = false;
            }
            else
            {
                Search_Btn.Enabled = true;
                LogData_ChkBx.Enabled = true;
                LogImage_ChkBx.Enabled = true;
            }
        }
        private void loggingUIControl()
        {
            if (LogData_ChkBx.Checked || LogImage_ChkBx.Checked)
            {
                nicComboBox.Enabled = false;
                SearchedReaders_ChkLstBx.Enabled = false;
                Search_Btn.Enabled = false;
                SelectAllReaders_ChkBx.Enabled = false;
            }
            else
            {
                nicComboBox.Enabled = true;
                SearchedReaders_ChkLstBx.Enabled = true;
                Search_Btn.Enabled = true;
                SelectAllReaders_ChkBx.Enabled = true;
            }
        }
        #endregion     
    }
}
