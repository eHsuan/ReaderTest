using Keyence.AutoID.SDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ErrorImageGetter
{
    public partial class Form1 : Form
    {
        enum OperationState { Start, Stop};

        //Constant
        private const string CONST_ERROR_STRING = "ERROR\r";

        //Reader Component
        private List<NicSearchResult> m_nicList = new List<NicSearchResult>();
        private ReaderSearcher m_searcher = new ReaderSearcher();
        private OperationState m_OperationState = OperationState.Stop;
        private List<String> m_ReaderList = new List<string>();
        private String m_MasterIP;
        private ReaderAccessor m_MasterAccessor = new ReaderAccessor();
        private List<ReaderAccessor> m_AccessorList = new List<ReaderAccessor>();
        private int m_RequiredFileNumber = 0;


        public Form1()
        {
            InitializeComponent();
            //Search Network Interface Card
            m_nicList = m_searcher.ListUpNic();
            if(m_nicList != null)
            {
                for( int i = 0; i < m_nicList.Count; i++)
                {
                    nicComboBox.Items.Add(m_nicList[i].NicIpAddr + "/" + m_nicList[i].NicName);
                }
                nicComboBox.SelectedIndex = 0;
            }

        }

        private void DataCheckProcess(byte[] data)
        {
            string readData = Encoding.ASCII.GetString(data);
            //If the data matches ERROR, all images are acquired
            if(readData == CONST_ERROR_STRING)
            {
                if(m_RequiredFileNumber <= 0)
                {
                    return;
                }
                //Get current time and create folder
                string now = System.DateTime.Now.ToString().Replace('/', '_').Replace(':', '_').Replace(' ', '_');
                if (!System.IO.Directory.Exists(now))
                {
                    System.IO.Directory.CreateDirectory(now);
                }
                //If it matches, get the image from the list				
                for (int i = 0; i < m_AccessorList.Count; i++)
                {
                    if (m_AccessorList[i].OpenFtp())
                    {
                        string savePath = now + "\\" + m_AccessorList[i].IpAddress + "_";

                        List<string> strImageFile = m_AccessorList[i].GetFileList("IMAGE");

                        // Remove LIVE.BIN,EXTRALIVE.BIN
                        strImageFile.Remove("LIVE.BIN");
                        strImageFile.Remove("EXTRALIVE.BIN");

                        //select saving files from image files in SR
                        List<string> savingFiles = selectLastNFiles(new List<string>(strImageFile), m_RequiredFileNumber);

                        foreach(string file in savingFiles)
                        {
                            m_AccessorList[i].GetFile("IMAGE\\" + file, savePath + file);
                        }
                    }
                }
            }
            
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

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            if (!m_searcher.IsSearching)
            {
                removeUnusedReaders();
                //Start searching readers
                m_searcher.Start((res) =>
                {
                    BeginInvoke(new delegateSearchResult(appendSearchResult), res);
                });
                searchUIControl(true);


            }
        }

        private void appendSearchResult(ReaderSearchResult res)
        {
            if(res.IpAddress == "")
            {
                searchUIControl(false);
                return;
            }
            string key = getKeyFromSearchResult(res);
            if (SearchedReaders_ChkLstBx.Items.Contains(key)){
                return;
            }
            SearchedReaders_ChkLstBx.Items.Add(key);
            MasterSelect_comboBox.Items.Add(key);
            
        }

        private void removeUnusedReaders()
        {
            for(int i = SearchedReaders_ChkLstBx.Items.Count - 1; i >= 0; i--)
            {
                String key = SearchedReaders_ChkLstBx.Items[i].ToString();
                if (!SearchedReaders_ChkLstBx.GetItemChecked(i))
                {
                    SearchedReaders_ChkLstBx.Items.Remove(key);
                }
                if(SearchedReaders_ChkLstBx.Items.Count == 0)
                {
                    break;
                }
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

        private void searchUIControl(bool enable)
        {
            if (enable)
            {
                Search_Btn.Enabled = false;
            }
            else
            {
                Search_Btn.Enabled = true;
            }
        }

        private void nicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_searcher.SelectedNicSearchResult = m_nicList[nicComboBox.SelectedIndex];
        }

        private void SelectAllReaders_ChkBx_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < SearchedReaders_ChkLstBx.Items.Count; i++)
            {
                SearchedReaders_ChkLstBx.SetItemChecked(i, SelectAllReaders_ChkBx.Checked);
            }
            this.Refresh();
        }

        private void SearchedReaders_ChkLstBx_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string key = SearchedReaders_ChkLstBx.Items[e.Index].ToString();

            if(e.NewValue == CheckState.Checked)
            {
                if (m_ReaderList.Contains(key))
                {
                    /*do nothing*/
                }
                else
                {
                    m_ReaderList.Add(key);
                }
            }
            else
            {
                if (m_ReaderList.Contains(key))
                {
                    m_ReaderList.Remove(key);
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void SearchedReaders_ChkLstBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*do nothing*/
        }

        private void OperationStart_Click(object sender, EventArgs e)
        {
            if(m_OperationState == OperationState.Start)
            {
                m_OperationState = OperationState.Stop;
                OperationStart.Text = "Start";
                //Delete used Accessor
                m_MasterAccessor = new ReaderAccessor();

                int accessorCount = m_AccessorList.Count;
                for(int i = 0; i < accessorCount; i++)
                {
                    m_AccessorList.RemoveAt(0);
                }

            }
            else if(m_OperationState == OperationState.Stop)
            {
                m_OperationState = OperationState.Start;
                OperationStart.Text = "Stop";
                //Connect to Master
                if (m_MasterIP != null)
                {
                    //Pass DataCheckProcess when connecting. Called for each data acquisition
                    m_MasterAccessor.IpAddress = m_MasterIP;
                    m_MasterAccessor.Connect(DataCheckProcess);
                }
                //Create an Accessor list
                int itemCount = SearchedReaders_ChkLstBx.Items.Count;
                if(itemCount > 0)
                {
                    for(int i = 0; i < itemCount; i++)
                    {
                        if (SearchedReaders_ChkLstBx.GetItemChecked(i))
                        {
                            ReaderAccessor Accessor = new ReaderAccessor();
                            Accessor.IpAddress = GetIpAddressFromSelectedItems(SearchedReaders_ChkLstBx.Items[i].ToString());
                            m_AccessorList.Add(Accessor);
                        }
                    }

                }
                //Keep number of files retrieved
                m_RequiredFileNumber = (int)NumberOfErrorFile_NumericUpDown.Value;
                if(m_RequiredFileNumber < 0)
                {
                    m_RequiredFileNumber = 0;
                }

            }

        }

        private void MasterSelect_comboBox_changed(object sender, EventArgs e)
        {
            //Get the IP address of Master
            m_MasterIP = GetIpAddressFromSelectedItems(MasterSelect_comboBox.SelectedItem.ToString());
        }

        private String GetIpAddressFromSelectedItems(String strName)
        {
            int indexOfIp = strName.IndexOf("/");
            String strIpAddress;

            if(indexOfIp > 0)
            {
                strIpAddress = strName.Substring(0, indexOfIp);
            }
            else
            {
                strIpAddress = null;
            }
            return strIpAddress;
        }
    }
}
