using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Devices.ModuleControl;

namespace Invengo.Sample
{
    public partial class FrReadSet : Form
    {
        public FrReadSet()
        {
            InitializeComponent();
            RfidConfig.RfidConnecte();
            SetControlValue();
        }

        /// <summary>
        /// Set Control Value
        /// </summary>
        protected void SetControlValue()
        {
            try
            {
                
                tvQValue.Text = RfidConfig.QValue.ToString();
                chkRssi.Checked = RfidConfig.IsRssi;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (RfidConfig.IsXC2903())
            {
                chkCharMode.SelectedIndex = RfidConfig.RfidModule-1;

            }
            else
            {
                chkCharMode.Enabled = false;
            }

                string err = "";
                try
                {
                    ushort ival = 30;
                    if (RfidConfig.GetScanInterval(out ival, out err))
                    {
                       
                            if (ival < 30)
                                ival = 30;
                      
                        tvScanInterval.Text = ival.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    ushort tidlen = 0;
                    if (RfidConfig.GetDefaultTidLength(out tidlen, out err))
                    {
                        tvDefaultTidLength.Text = tidlen.ToString();
                        RfidConfig.TidLength = tidlen;
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }           
          
        }

        

        private void SetRssiStatus(bool enable)
        {
           
                string err = "";
                try
                {
                    if (RfidConfig.SetRssiStatus(enable, out err))
                    {
                        RfidConfig.IsRssi = enable;

                    }
                }
                catch
                {
                }
           
        }

        /// <summary>
        /// Set Read Value
        /// </summary>
        private void SetOK()
        {
            string strq = tvQValue.Text;
            if (strq == "")
            {
                strq = "8";
            }
            else if (strq == "0")
            {
                strq = "1";
            }
            RfidConfig.QValue = Convert.ToUInt16(strq);
            if (chkCharMode.Enabled)
            {
                RfidConfig.RfidModule = chkCharMode.SelectedIndex + 1; //1:Internal,2:Extern
                if (RfidConfig.RfidModule == 1)
                {
                    RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Internal);
                }
                else
                {
                    RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Extern);

                }

            }

            SetRssiStatus(chkRssi.Checked);

            string err = "";
            try
            {
                ushort ival = 30;
                ival = Convert.ToUInt16(tvScanInterval.Text);

                if (ival < 30)
                {
                    ival = 30;
                }
                else if (ival > 255)
                {
                    ival = 255;
                }

                RfidConfig.SetScanInterval(ival, out err) ;
            }
            catch {  }

            try
            {
                ushort tidlen = Convert.ToUInt16(tvDefaultTidLength.Text);
                if (RfidConfig.SetDefualtTidLength(tidlen, out err))
                {
                    RfidConfig.TidLength = tidlen;
                }
            }
            catch { }
            FormatConvert.SoundSucceed();
            DialogResult = DialogResult.Yes;
            Close();
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

        protected void AddToStatus(object sender, EventArgs e)
        {
            string msg = (string)sender;
            lblStatus.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetOK();
        }

        private void FrReadSet_Closed(object sender, EventArgs e)
        {
            RfidConfig.Disconnect();
        }

        private void chkCharMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrReadSet_Load(object sender, EventArgs e)
        {

        }

        private void lblStatus_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}