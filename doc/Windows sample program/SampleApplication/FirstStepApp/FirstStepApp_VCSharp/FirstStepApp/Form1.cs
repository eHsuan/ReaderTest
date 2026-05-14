using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keyence.AutoID.SDK;

namespace FirstStepApp
{
    public partial class Form1 : Form
    { 
        private ReaderAccessor m_reader = new ReaderAccessor();
        private ReaderSearcher m_searcher = new ReaderSearcher();
        List<NicSearchResult> m_nicList = new List<NicSearchResult>();

        public Form1()
        {
            InitializeComponent();
            m_nicList = m_searcher.ListUpNic();
            if (m_nicList != null)
            {
                for (int i = 0; i < m_nicList.Count; i++)
                {
                    NICcomboBox.Items.Add(m_nicList[i].NicIpAddr);
                }
            }
            NICcomboBox.SelectedIndex = 0;
        }

        private void SchBtn_Click(object sender, EventArgs e)
        {           
            //m_searcher.IsSearching is true while searching readers.
            if (!m_searcher.IsSearching)
            {
                m_searcher.SelectedNicSearchResult = m_nicList[NICcomboBox.SelectedIndex];
                NICcomboBox.Enabled = false;
                SchBtn.Enabled = false;
                SctBtn.Enabled = false;
                comboBox1.Items.Clear();
                //Start searching readers.
                m_searcher.Start((res) =>
                {
                    //Define searched actions here.Defined actions work asynchronously.
                    //"SearchListUp" works when a reader was searched.
                    BeginInvoke(new delegateUserControl(SearchListUp), res.IpAddress);
                });
            }
        }
        private void SctBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (SctBtn.Checked)
            {
                if (comboBox1.SelectedItem != null)
                {
                    //Stop liveview.
                    liveviewForm1.EndReceive();
                    //Set ip address of liveview.
                    liveviewForm1.IpAddress = comboBox1.SelectedItem.ToString();
                    //Start liveview.
                    liveviewForm1.BeginReceive();
                    //Set ip address of ReaderAccessor.
                    m_reader.IpAddress = comboBox1.SelectedItem.ToString();
                    //Connect TCP/IP.
                    m_reader.Connect((data) =>
                    {
                        //Define received data actions here.Defined actions work asynchronously.
                        //"ReceivedDataWrite" works when reading data was received.
                        BeginInvoke(new delegateUserControl(ReceivedDataWrite), Encoding.ASCII.GetString(data));
                    });
                    NICcomboBox.Enabled = false;
                    SchBtn.Enabled = false;
                    comboBox1.Enabled = false;
                    TgrBtn.Enabled = true;
                }
            }
            else
            {
                NICcomboBox.Enabled = true;
                SchBtn.Enabled = true;
                comboBox1.Enabled = true;
                TgrBtn.Enabled = false;
            }
        }
        private void TgrBtn_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                //ExecCommand("command")is for sending a command and getting a command response.
                ReceivedDataWrite(m_reader.ExecCommand("LON"));
            }
        }
        //delegateUserControl is for controlling UserControl from other threads.
        private delegate void delegateUserControl(string str);
        private void ReceivedDataWrite(string receivedData)
        {
            DataText.Text=("[" + m_reader.IpAddress + "][" + DateTime.Now + "]" + receivedData);
        }
        private void SearchListUp(string ip)
        {
            if (ip != "")
            {
                comboBox1.Items.Add(ip);
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                return;
            }
            else
            {
                NICcomboBox.Enabled = true;
                SctBtn.Enabled = true;
                SchBtn.Enabled = true;
            }
        }
        //Dispose before closing Form for avoiding error.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_reader.Dispose();
            m_searcher.Dispose();
            liveviewForm1.Dispose();
        }
    }
}
