using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Invengo.Devices.ModuleControl;
using System.IO;
using System.Diagnostics;
using Invengo.Platform;

namespace Invengo.Sample
{
    public partial class FrPadMain : Form
    {
        Thread td_wifi;
        private bool _isLoop = false;
        public bool IsLoop
        {
            get { return _isLoop; }
            set { _isLoop = value; }
        }


        public FrPadMain()
        {
            InitializeComponent();
            SelBarCode();
        }

        public void SelBarCode()
        {

            PDAInfo.DevModel _pdamodel = PDAInfo.GetDevModel();
            if (_pdamodel == PDAInfo.DevModel.XC2903)
            {
                CameraBarcodeSwitch.SelBarCode();
            };
        }

        private void btScan_Click_1(object sender, EventArgs e)
        {
            FrBarcode barcode = new FrBarcode();
            barcode.ShowDialog();
        }

        private void btkey_Click(object sender, EventArgs e)
        {
            FrTestKey fkey = new FrTestKey();
            fkey.ShowDialog();
        }
        private void AddToStatus(string msg)
        {
            Invoke(new EventHandler(delegate(object sender, EventArgs e)
            {
                lblStatus.Text = msg;
            }));
        }

        /// <summary>
        /// Open Wifi
        /// </summary>
        private void OpenWifi()
        {
            bool ret = WifiControl.IsActived();

            if (!ret)
            {
                AddToStatus("Wifi is being opened!");

                WifiControl.Active();

            }
            else
            {
                MessageBox.Show("Wifi is already open!");

            }
            Thread.Sleep(12000);

            AddToStatus("");

        }


        private void StartWifi()
        {
            td_wifi = new Thread(new ThreadStart(OpenWifi));
            td_wifi.IsBackground = true;
            td_wifi.Start();
        }
        private void SwitchWifi()
        {
            string msg = "";
            if (WifiControl.IsActived())
            {
                if (DialogResult.No == MessageBox.Show("Do you need to close Wi-Fi?", "Wi-Fi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                if (WifiControl.Deactive())
                {
                    btwifi.Text = "Open Wi-Fi";
                }
            }
            else
            {
                if (WifiControl.Active())
                {
                    Thread.Sleep(5 * 1000);

                    if (WifiControl.IsActived())
                    {
                        btwifi.Text = "Close Wi-Fi";
                        //btWifi.Image = 
                    }
                }
                else
                {
                    msg = "Fail to Open Wi-Fi!";
                    MessageBox.Show(msg);
                }
            }
        }
      
        private void btwifi_Click(object sender, EventArgs e)
        {
            SwitchWifi();
          
        }

        private void FrPadMain_Load(object sender, EventArgs e)
        {
            if (WifiControl.IsActived())
            {
                btwifi.Text = "Close Wi-Fi";
            }
            if (GprsControl.IsActived())
            {
                btGPRS.Tag = "Close";
                btGPRS.Text = "Close GPRS";
            }
        }
        /// <summary>
        /// Switch Gprs
        /// </summary>
        private void SwitchGprs()
        {
            bool isInvoke = false;
            if (GprsControl.IsActived())
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to close the gprs?", "GPRS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (GprsControl.Deactive())
                        btGPRS.Text = "Open GPRS";
                }
                else
                {
                    isInvoke = true;
                }
               
            }
            else
            {
                int ret = GprsControl.Active();
                {
                    isInvoke = true;
                }
               
            }

            if (isInvoke)
            {
                btGPRS.Text = "Close GPRS";
                string procname = @"\Windows\rnaapp.exe";
                if (!File.Exists(procname))
                    return;
                Process.Start(procname, "-e\"GPRSDial\"");      //"-p-e\"GPRSDial\""
            }
        }

        private void btversion_Click(object sender, EventArgs e)
        {
            FrScreen frver = new FrScreen();
            frver.ShowDialog();
        }

        private void btGPRS_Click(object sender, EventArgs e)
        {
            //GprsThread();
            SwitchGprs();

        }

        private void btsound_Click(object sender, EventArgs e)
        {
            FrSound setsound = new FrSound();
            setsound.ShowDialog();
        }

        private void btbattery_Click(object sender, EventArgs e)
        {
            FrBattery frbattery = new FrBattery();
            frbattery.ShowDialog();
        }

        private void btver_Click(object sender, EventArgs e)
        {
            FrSysInfo frsys = new FrSysInfo();
            frsys.ShowDialog();
        }

        private void lblStatus_ParentChanged(object sender, EventArgs e)
        {

        }

      
    }
}