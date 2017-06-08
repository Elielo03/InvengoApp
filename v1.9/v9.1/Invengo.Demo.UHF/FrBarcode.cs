using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Invengo;
using Invengo.Barcode;
using System.Threading;
using Invengo.Devices.ModuleControl;
using Invengo.Platform;
using Invengo.Audio;
namespace Invengo.Sample
{
    public partial class FrBarcode : Form
    {
        public int ScannerIndex;
        protected int TaskbarStatus = 1;
        BarcodeScannerHoneywell1D honeywell1d;
        BarcodeScannerHoneywell2D honeywell2d;
        BarcodeScannerSymbol symbol;

        int n = 0;


        /// <summary>
        /// Initialize
        /// </summary>
        public FrBarcode()
        {
            InitializeComponent();

            symbol = BarcodeScannerSymbol.CreateInstance();
            symbol.BarcodeRecvEvent += new BarcodeScanner.BarcodeRecvEventHandler(symbol_BarcodeRecvEvent);
            honeywell1d = BarcodeScannerHoneywell1D.CreateInstance();
            honeywell1d.BarcodeRecvEvent += new BarcodeScanner.BarcodeRecvEventHandler(honeywell1d_BarcodeRecvEvent);
            honeywell2d = BarcodeScannerHoneywell2D.CreateInstance();
            honeywell2d.BarcodeRecvEvent += new BarcodeScanner.BarcodeRecvEventHandler(honeywell2d_BarcodeRecvEvent);

            ScannerIndex = 0;
            InitHonywell2D();

        }


        /// <summary>
        /// Add To Status Async
        /// </summary>
        /// <param name="msg"></param>
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

        protected void AddToStatus(object sender, EventArgs e)
        {
            string msg = (string)sender;
            lblStatus.Text = msg;
        }

        private void honeywell2d_BarcodeRecvEvent(object sender, BarcodeScanner.BarcodeRecvEventArgs e)
        {
            string msg = Encoding.Default.GetString(e.Code.Data, 0, e.Code.Data.Length);
            AddToListAsync(msg);

        }

        private void honeywell1d_BarcodeRecvEvent(object sender, BarcodeScanner.BarcodeRecvEventArgs e)
        {
            string msg = Encoding.Default.GetString(e.Code.Data, 0, e.Code.Data.Length);
            AddToListAsync(msg);

        }

        private void symbol_BarcodeRecvEvent(object sender, BarcodeScanner.BarcodeRecvEventArgs e)
        {

            string msg = Encoding.Default.GetString(e.Code.Data, 0, e.Code.Data.Length);
            AddToListAsync(msg);

        }

        private void AddToListAsync(string msg)
        {
            Invoke(new EventHandler(AddToList), msg);
        }

        /// <summary>
        /// Add To List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToList(object sender, EventArgs e)
        {
            if (lvCodes.Items.Count > 1000)
            {
                lvCodes.Items.Clear();
            }
            string msg = (string)sender;
            bool exists = false;
            foreach (ListViewItem lvi in lvCodes.Items)
            {
                if (lvi == null)
                    continue;
                if (msg == lvi.SubItems[2].Text)
                {
                    exists = true;
                    int ic = Convert.ToInt32(lvi.SubItems[1].Text);
                    ic += 1;
                    lvi.SubItems[1].Text = ic.ToString();
                    break;
                }
            }

            if (!exists)
            {
                n++;
                ListViewItem lvi = new ListViewItem(new string[] { n.ToString(), "1", msg });
                lvCodes.Items.Add(lvi);
                lvCodes.EnsureVisible(lvCodes.Items.Count - 1);
            }
            FormatConvert.SoundRecord();
        }

        private void btScan_Click(object sender, EventArgs e)
        {

            AddToStatusAsync("");
            ReadBarcode();

        }
        private void InitHonywell2D()
        {
            honeywell2d.Initialize(BarcodeScannerHoneywell2D.InitType._256Bit);
        }

        /// <summary>
        /// Barcode Initialize
        /// </summary>
        private void Barcodeinitialize()
        {
            honeywell1d.Close();
            symbol.Close();
            if (ScannerIndex == 0)
            {
                InitHonywell2D();
            }
            else if (ScannerIndex == 1)
            {
                honeywell1d.Initialize();
            }
            else if (ScannerIndex == 2)
            {
                symbol.Initialize();
            }
        }

        /// <summary>
        /// Read Barcode
        /// </summary>
        public void ReadBarcode()
        {
            try
            {

                switch (ScannerIndex)
                {
                    case 0:

                        honeywell2d.BarcodeRead();
                        break;
                    case 1:

                        honeywell1d.BarcodeRead();
                        break;
                    case 2:
                        symbol.BarcodeRead();

                        break;
                }
            }
            catch (Exception ex)
            {
                string exs = ex.Message;
            }
        }





        private void btback_Click(object sender, EventArgs e)
        {
            symbol.Dispose();
            honeywell2d.Dispose();
            honeywell1d.Dispose();
            Close();

        }

        private void FrBarcode_Closing(object sender, CancelEventArgs e)
        {

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyValue)
            {
                case 0xF1:
                case 0xF2:
                case 0xF5:
                    ReadBarcode();
                    break;
            }
        }

        private void FrBarcode_Load(object sender, EventArgs e)
        {

        }

        private void cbtype_SelectedIndexChanged(object sender, EventArgs e)
        {

            ScannerIndex = cbtype.SelectedIndex;
            Barcodeinitialize();
        }
    }
}