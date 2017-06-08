using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Sample;

namespace Invengo.Sample
{
    public partial class FrReadSettings : Form
    {
        public FrReadSettings()
        {
            InitializeComponent();
            SetControlValue();
        }

        protected void SetControlValue()
        {
            
                string err = "";
                try
                {
                    ushort tidlen = 0;
                    if (TagOperation.GetDefaultTidLength(out tidlen, out err))
                    {
                        tvDefaultTidLength.Text = tidlen.ToString();
                    }
                    else
                    {
                        tvDefaultTidLength.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                try
                {

                    ushort ival = 30;
                    if (TagOperation.GetScanInterval(out ival, out err))
                    {

                        tvScanInterval.Text = ival.ToString();
                    }
                    else
                    {
                        tvScanInterval.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                GetRssiStatus();
           
        }

        private void GetRssiStatus()
        {
            ushort val = 0;
            string err = "";
            try
            {
                if (TagOperation.GetRssiStatus(out val, out err))
                {
                    if (val == 1)
                    {
                        chkRssi.Checked = true;
                    }
                    else
                    {
                        chkRssi.Checked = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void SetOK()
        {
            string err = "";
            try
            {
                ushort tidlen = Convert.ToUInt16(tvDefaultTidLength.Text);
                
                if (!TagOperation.SetDefualtTidLength(tidlen, out err))
                {
                    this.lbmsg.Text = string.Format("Set Defualt Tid Length Failure,{0}!", err);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            try
            {
                ushort ival = 30;
                ival = Convert.ToUInt16(tvScanInterval.Text);
                
                    if (ival < 0)
                    {
                        ival = 0;
                    }
                    else if (ival > 255)
                    {
                        ival = 255;
                    }

                    if (TagOperation.SetScanInterval(ival, out err))
                    {
                        if (ival == 0)
                        {
                            TagOperation.SetLoopRead(out err);
                        }
                    }
                    else
                    {
                        this.lbmsg.Text = this.lbmsg.Text+string.Format("Set Defualt Tid Length Failure,{0}!", err);
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            if (err != "") { FormatConvert.SoundError(); return; }
            FormatConvert.SoundSucceed();
            Close();
        }

        private void SetRssiStatus(bool enable)
        {

            string err = "";
            this.lbmsg.Text = "";
            try
            {
                if (!TagOperation.SetRssiStatus(enable, out err))
                {
                    this.lbmsg.Text=string.Format("Set Rssi Failure,{0}!",err);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void btset_Click(object sender, EventArgs e)
        {
            SetOK();
        }

        private void chkRssi_CheckStateChanged(object sender, EventArgs e)
        {
            SetRssiStatus(chkRssi.Checked);
        }
    }
}