using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Invengo.Audio;
using Invengo.Devices.ModuleControl;
using Invengo.NetAPI.Core;
using Invengo.Platform;
using Invengo.NetAPI.Protocol.IRP1;

namespace Invengo.Sample
{
    public partial class FrTagMain : Form
    {
        Reader reader = null;
        int portno = 4;
        int baudrate = 115200;
        private static PDAInfo.DevModel _pdamodel;
        int indicador;

        public FrTagMain( int indicador)
        {
            this.indicador = indicador;
            InitializeComponent();
           
        }

        /// <summary>
        /// RFID Active
        /// </summary>
        /// <returns></returns>
        private bool SwitchRfid()
        {
            bool isRight = true;
            try
            {
                _pdamodel = PDAInfo.GetDevModel();
                if (_pdamodel == PDAInfo.DevModel.XC2903)
                {
                    bool isext = RfidControl.IsExtRfid();
                    if (isext)
                    {
                        RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Extern);
                    }
                    else
                    {
                        RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Internal);
                    }

                }
                else
                {
                    RfidControl.Active();
                }

            }
            catch
            {
                isRight = false;
            }

            return isRight;
        }

        /// <summary>
        /// Connect
        /// </summary>
        /// <returns></returns>
        public bool RfOn()
        {
            bool ret = SwitchRfid();
            if (ret)
            {
                System.Threading.Thread.Sleep(400);
                ret = Connect();
            }
            return ret;
        }
        /// <summary>
        ///RFID Deactive
        /// </summary>
        public void RfOff()
        {
            try
            {
                if (reader != null)
                {
                    reader.Send(new PowerOff());
                    Disconnect();
                }
                RfidControl.Deactive();
            }
            catch { }

        }

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            try
            {
                reader.Disconnect();
            }
            catch
            {
            }

            return reader.IsConnected;
        }

        /// <summary>
        /// Read Connect
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {

            string comName = string.Format("COM{0}:,{1}", portno, baudrate);

            if (reader == null)
            {
                reader = new Reader("Reader1", "RS232", comName);
                TagOperation.RfReader = reader;
            }
            if (!reader.IsConnected)
                reader.Connect();
            return reader.IsConnected;
        }

        private void btscanrfid_Click_1(object sender, EventArgs e)
        {
            if (this.indicador == 0)
            {
                FrScanTag scantag = new FrScanTag(reader);
                scantag.ShowDialog();

            }
            else
            {
                FrScanTagComedor scantag = new FrScanTagComedor(reader);
                scantag.ShowDialog();

            }


        }

        private void btpower_Click_1(object sender, EventArgs e)
        {
            FrAntennaPower fp = new FrAntennaPower();
            fp.ShowDialog();
        }

     

        private void FrTagMain_Load(object sender, EventArgs e)
        {

        }

        private void btreadset_Click(object sender, EventArgs e)
        {
            FrReadSettings frread = new FrReadSettings();
            frread.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.button2.Enabled = false;
            if (!RfOn())
            {
                FormatConvert.SoundError();
                Cursor.Current = Cursors.Default;
                this.button2.Enabled = true; MessageBox.Show("Connect Failure ！");
            }

            else
            {
                btreadset.Enabled = true;
                this.btpower.Enabled = true;
                this.btscanrfid.Enabled = true;
                FormatConvert.SoundSucceed();
              
            }
            Cursor.Current = Cursors.Default;
        }

        protected override void OnClosed(EventArgs e)
        {

            base.OnClosed(e);

            RfOff();


        }



    }
}