using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Reflection;
using HANDLE = System.IntPtr;
using System.Threading;
using Invengo.Audio;
using System.Diagnostics;
using Invengo.Barcode;

namespace Invengo.Sample
{
    public partial class FrMotoBarCode : Form
    {

        private delegate void InvokeDelegate();
        public String res;
        public Boolean comedor;
        BarcodeScannerMoto scanner = null;

        public FrMotoBarCode(Boolean comedor)
        {
            InitializeComponent();

            InitializeSDLScanner();
            this.comedor=comedor;
        }


        private void InitializeSDLScanner()
        {
            scanner = BarcodeScannerMoto.CreateInstance();
            if (scanner == null)
            {
                MessageBox.Show("No scan engine found to claim", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                trigPull.Enabled = btscan.Enabled = false;

            }
            else
            {
                scanner.Decoded += new EventHandler(SDLScanner_onDecoded);
            }

        }


        //--------------------------------------------------------------------------------------      
        private void SDLScanner_onDecoded(object Sender, EventArgs e)
        {

            try
            {
                if (lvCodes.InvokeRequired)
                    lvCodes.Invoke(new InvokeDelegate(UpdateDecodeText));
                else
                    UpdateDecodeText();
            }
            catch { }
        }

        //--------------------------------------------------------------------------------------
        private void UpdateDecodeText()
        {

            if (DecodeData.text == null || DecodeData.text[0] == '\0')
            {
                AddToListAsync("(no decode)");
            }
            else
            {

                SoundSucceed();
                AddToListAsync(DecodeData.text);
                UiCount();

            }
            //scanner.Trigger = false;   //release trigger

        }



        private void btclear_Click(object sender, EventArgs e)
        {
            this.lvCodes.Items.Clear();
            AddToStatusAsync("");
            this.lblCount.Text = "0";
        }

        private void btscan_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void trigPull_Click(object sender, EventArgs e)
        {
            scanner.SingleRead();
        }
        private void AddToListAsync(string msg)
        {
           
            Invoke(new EventHandler(AddToList), msg);
        }
        /// <summary>
        /// play success voice;
        /// </summary>
        public virtual void SoundSucceed()
        {
            SoundPlayer.PlayWAV(@"\Windows\infend_short.wav");
        }

        private void AddToList(object sender, EventArgs e)
        {
           
            Dao.Dao dao = new Dao.Dao();
            if (lvCodes.Items.Count > 1000)
            {
                //MessageBox.Show("2");
                lvCodes.Items.Clear();
            }
            string msg = (string)sender;
            bool exists = false;
            //foreach (ListViewItem lvi in lvCodes.Items)
            //{
            //    if (lvi == null)
            //        continue;
            //    if (msg == lvi.SubItems[0].Text)
            //    {
            //        exists = true;
            //        int ic = Convert.ToInt32(lvi.SubItems[1].Text);
            //        ic += 1;
            //        lvi.SubItems[1].Text = ic.ToString();

            //        break;
            //    }
            //}

            if (!exists)
            {


                this.res = "";
                
                 this.res = dao.getPersonaByCredencial(msg,this.comedor);
                 ListViewItem lvi = new ListViewItem(new string[] { msg,this.res, "1" });
                 lvCodes.Items.Add(lvi);
                 lvCodes.EnsureVisible(lvCodes.Items.Count - 1);
                 scanner.StopScan();
                Thread ATM2 = new Thread(new ThreadStart(ThreadProc));
                ATM2.Start();
                
               
                btscan.Text = "Scan";
                btscan.Tag = "start";
                
            }

        }

        public void ThreadProc()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => CreateAndShowForm()));
                return;
            }
            CreateAndShowForm();


            
        }
        private void CreateAndShowForm()
        {
            FrInfo frInfo = new FrInfo(this.res);
            frInfo.ShowDialog();
           
        }
        protected void AddToStatusAsync(string msg)
        {
            if (InvokeRequired)
            {
               
                Invoke(new EventHandler(AddToStatus), msg);
            }
            else
            {
                
                AddToStatus(msg, null);
            }
        }


        private void Start()
        {
            if ((string)btscan.Tag == "start")
            {
                AddToStatusAsync("");
                scanner.StartScan();
                btscan.Text = "Stop";
                btscan.Tag = "stop";
            }
            else
            {
                scanner.StopScan();
                btscan.Text = "Scan";
                btscan.Tag = "start";
            }
        }

        protected void AddToStatus(object sender, EventArgs e)
        {
            string msg = (string)sender;
            lblStatus.Text = msg;
        }

        private void UiCount()
        {
            BeginInvoke(new EventHandler(delegate(object sender, EventArgs e)
            {
                lblCount.Text = lvCodes.Items.Count.ToString();
            }));
        }


        private void FrBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            int val = e.KeyValue;
            switch (val)
            {
                case 0xF1:
                case 0xF2:
                case 0xF5:
                    Start();
                    break;
            }
        }

        private void FrBarCode_Closed(object sender, EventArgs e)
        {
            try
            {
                if (scanner != null)
                {
                 
                    scanner.Decoded -= new EventHandler(SDLScanner_onDecoded);

                    scanner.Dispose();
                    scanner.Release();
                    scanner = null;
                 
                }

            }
            catch { }

        }

        private void lvCodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

    }
}