using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Invengo.GPS;
using GVars;
using Keyboard;
using Invengo.Devices.ModuleControl;

namespace InspectHandler
{
    public partial class FrTopbar : Form
    {
        //
        public event WirelessStatusHandler WirelessStatusEvent;
        //
        private KeyHook hook;
        //
        private delegate void RunBackgroundHandler();
        //
        private Size defSize;        
        //
        protected GPSControl gpscontrol;
        //
        private bool isAdjust = false;
        //
        private int chargingIndex = 0;
        //
        public Form ActivedForm = null;
        public Form ParentForm = null;
        //
        private Thread tDate;
        private Thread tShowMsg;
        //
        public bool IsGpsForm = false;
        //
        public Thread tGpsMonitor;
        //
        protected bool isWirelessQuerying = false;

        public FrTopbar()
        {
            InitializeComponent();
                        
            defSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, 20);

            gpscontrol = new GPSControl();
            gpscontrol.GPSDataEvent += new GPSControl.GPSDataHandler(gpscontrol_GPSDataEvent);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Size = defSize;

            base.OnLoad(e);

            InitializeVars();

            RefreshTime();

            GetPowerLifePercent();

            timerBattery.Enabled = true;
            timerWireless.Enabled = true;

            DateStart();

            //gps  
            GpsStart();
            GpsMonitorStart();
        }

        protected override void OnClosed(EventArgs e)
        {
            timerBattery.Enabled = false;
            timerCharging.Enabled = false;
            timerWireless.Enabled = false;
            DateStop();
            ShowMsgStop();
            GpsStop();
            GpsMonitorStop();

            try
            {
                hook.Stop();
            }
            catch { }

            base.OnClosed(e);
        }

        private void gpscontrol_GPSDataEvent(object sender, GpsDataEventArgs e)
        {
            if (isAdjust)
                return;
            if (e.Gsa.FormatFixType() != GSA.FixType.Fix_not)
            {
                string strdate = e.Rmc.FormatDate();
                string strtime = e.Gga.FormatTime();
                //strdate = "2012-07-25";
                if (Utility.UpdateTime(strdate, strtime))
                {
                    isAdjust = true;
                    AddToMemo("重新校准了系统时间");
                    RefreshTime();
                    GValue.SoundAlarmA();
                }
            }
        }

        private void InitializeVars()
        {
            if (imlExt.Images.Count > 0)
            {
                picWireless.Image = imlExt.Images[0];
            }

            if (imlBattery.Images.Count > 0)
            {
                picBattery.Image = imlBattery.Images[0];
            }

            try
            {
                hook = new KeyHook();
                hook.KeyHookEvent += new KeyHook.KeyHookEventHandler(hook_KeyHookEvent);
                hook.Start();
            }
            catch { }
        }

        private void hook_KeyHookEvent(object sender, KeyHook.KeyHookEventArgs e)
        {
            switch (e.KBParam.scanCode)
            {
                case 0:    //key 0
                    if (e.Flag == KeyHook.WM_KEYDOWN)
                    {
                        SendKeys.Sends(SendKeys.VK_ESCAPE, SendKeys.KEYEVENTF_KEYDOWN);
                    }
                    else if (e.Flag == KeyHook.WM_KEYUP)
                    {
                        SendKeys.Sends(SendKeys.VK_ESCAPE, SendKeys.KEYEVENTF_KEYUP);
                    }
                    break;
                case 1:
                    if (e.Flag == KeyHook.WM_KEYDOWN)
                    {
                        SendKeys.Sends(SendKeys.VK_UP, SendKeys.KEYEVENTF_KEYDOWN);
                    }
                    else if (e.Flag == KeyHook.WM_KEYUP)
                    {
                        SendKeys.Sends(SendKeys.VK_UP, SendKeys.KEYEVENTF_KEYUP);
                    }
                    break;
                case 2:
                    if (e.Flag == KeyHook.WM_KEYDOWN)
                    {
                        SendKeys.Sends(SendKeys.VK_RETURN, SendKeys.KEYEVENTF_KEYDOWN);
                    }
                    else if (e.Flag == KeyHook.WM_KEYUP)
                    {
                        SendKeys.Sends(SendKeys.VK_RETURN, SendKeys.KEYEVENTF_KEYUP);
                    }
                    break;
                case 3:
                    if (e.Flag == KeyHook.WM_KEYDOWN)
                    {
                        SendKeys.Sends(SendKeys.VKSCAN, SendKeys.KEYEVENTF_KEYDOWN);

                        if (!(ActivedForm is FrRead))
                        {
                            if (GVars.Utility.FindShutdownForm() != IntPtr.Zero)
                            {
                                return;
                            }
                            if (ActivedForm != null && !(ActivedForm is FrMain))
                            {
                                ActivedForm.Close();
                            }

                            if ( ParentForm is FrMain)
                            {
                                FrMain pa = (FrMain)ParentForm;
                                pa.ShowXunjian();
                            }
                        }
                    }
                    else if (e.Flag == KeyHook.WM_KEYUP)
                    {
                        SendKeys.Sends(SendKeys.VKSCAN, SendKeys.KEYEVENTF_KEYUP);
                    }
                    break;
                case 4:
                    if (e.Flag == KeyHook.WM_KEYDOWN)
                    {
                        SendKeys.Sends(SendKeys.VK_DOWN, SendKeys.KEYEVENTF_KEYDOWN);
                    }
                    else if (e.Flag == KeyHook.WM_KEYUP)
                    {
                        SendKeys.Sends(SendKeys.VK_DOWN, SendKeys.KEYEVENTF_KEYUP);
                    }
                    break;
            }

            if (e.Flag == KeyHook.WM_KEYDOWN)
            {
                SetWindowFocus();
            }
        }

        protected void SetWindowFocus()
        {
            if (GVars.Utility.FindShutdownForm() != IntPtr.Zero)
            {
                return;
            }
            if (ActivedForm != null)
            {
                ActivedForm.Activate();
            }
        }

        private void picBattery_Click(object sender, EventArgs e)
        {
            if (ActivedForm != null)
            {
                if ((string)picBattery.Tag == "show")
                {
                    ActivedForm.Hide();
                    if (ActivedForm.Owner != null)
                    {
                        ActivedForm.Owner.Hide();
                    }

                    picBattery.Tag = "hide";
                }
                else
                {
                    ActivedForm.Show();
                    if (ActivedForm.Owner != null)
                    {
                        ActivedForm.Owner.Show();
                    }

                    picBattery.Tag = "show";
                }
            }
        }

        private void picBattery_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshTime()
        {
            BeginInvoke(new EventHandler(delegate(object sender, EventArgs e)
            {
                ////DateTime dt = DateTime.Now;
                ////string strdt = dt.ToString("MM-dd hh:mm");
                ////lblDatetime.Text = strdt;
                string strdt = "";
                if (Utility.GetLocalTime(out strdt))
                {
                    if (strdt != "")
                    {
                        lblDatetime.Text = strdt;
                    }
                }
            }));
        }

        public void GpsStart()
        {
            if (gpscontrol != null
                && !gpscontrol.IsRunning)
            {
                isAdjust = false;

                gpscontrol.Start();
            }
        }

        public void GpsStop()
        {
            if (gpscontrol != null)
                gpscontrol.Stop();
        }

        private void GpsMonitorStart()
        {
            tGpsMonitor = new Thread(new ThreadStart(GpsMonitorProc));
            tGpsMonitor.IsBackground = true;
            tGpsMonitor.Start();
        }

        private void GpsMonitorProc()
        {
            Thread.Sleep(150 * 1000);

            if (!IsGpsForm && gpscontrol.IsRunning)
            {
                GpsStop();

                //AddToMemo("停止了GPS校时");
                //GValue.SoundAlarmA();
            }
        }

        private void GpsMonitorStop()
        {
            try
            {
                if (tGpsMonitor != null)
                    tGpsMonitor.Abort();
            }
            catch { }
        }
        
        private void GetPowerLifePercent()
        {
            try
            {
                BatteryQuery.PowerInfo obj = BatteryQuery.GetPowerInfo();
                if (obj == null)
                    return;
                if (obj.PowerType == SystemPower.AC_LINE_ONLINE)
                {
                    if(obj.BaterryStatus == SystemPower.BATTERY_FLAG_CHARGING)
                    {
                        if (!timerCharging.Enabled)
                            timerCharging.Enabled = true;
                    }
                    else
                    {
                        timerCharging.Enabled = false;

                        ChangeBatteryPic(obj.LifePercent);
                    }
                }
                else
                {
                    if (timerCharging.Enabled)
                    {
                        timerCharging.Enabled = false;
                    }

                    ChangeBatteryPic(obj.LifePercent);
                }
            }
            catch { }
        }

        private void ChangeBatteryPic(int lifePercent)
        {
            BeginInvoke(new EventHandler(delegate(object sender, EventArgs e)
            {
                if (lifePercent > 70)
                {
                    picBattery.Image = imlBattery.Images[4];
                }
                else if (lifePercent > 50)
                {
                    picBattery.Image = imlBattery.Images[3];
                }
                else if (lifePercent > 30)
                {
                    picBattery.Image = imlBattery.Images[2];
                }
                else if (lifePercent > 10)
                {
                    picBattery.Image = imlBattery.Images[1];
                }
                else
                {
                    picBattery.Image = imlBattery.Images[0];
                }
                picBattery.Update();
            }));
        }

        public void GetWirelessState()
        {
            if (isWirelessQuerying)
                return;
            isWirelessQuerying = true;
            BeginInvoke(new EventHandler(delegate(object sender, EventArgs e)
                {
                    string adapter, ssid;
                    bool isconnected = false;
                    try
                    {
                        WirelessStatusEventArgs status = new WirelessStatusEventArgs();

                        bool ret = WifiUtility.GetNetworkInfo(out adapter, out ssid, out isconnected);
                        
                        status.SSID = ssid;

                        if (WifiControl.IsActived())
                        {
                            status.IsEnable = true;
                            picWireless.Image = imlExt.Images[1];
                        }
                        else
                        {
                            picWireless.Image = imlExt.Images[0];
                        }

                        if (ret && isconnected)
                        {
                            StringBuilder szAdapterName = new StringBuilder("SDIO86861");
                            StringBuilder szIPAddress = new StringBuilder(50);
                            StringBuilder szSubnetMask = new StringBuilder(50);
                            StringBuilder szGateway = new StringBuilder(50);
                            StringBuilder szDnsServer = new StringBuilder(50);
                            StringBuilder szWinsServer = new StringBuilder(50);
                            StringBuilder szAdapterMac = new StringBuilder(50);
                            uint DHCPEnable = 0;
                            int ir = WifiUtility.GetIPAddress(szAdapterName, szIPAddress, szSubnetMask, szGateway, szDnsServer, szWinsServer, szAdapterMac, ref DHCPEnable);
                            if (ir == 0)
                            {
                                if (szIPAddress.ToString() != ""
                                    && szIPAddress.ToString() != "0.0.0.0")
                                {
                                    status.IsConnected = true;
                                    picWireless.Image = imlExt.Images[2];
                                }

                                if (szIPAddress.ToString() != "")
                                    status.IPAddress = szIPAddress.ToString();

                                if (szSubnetMask.ToString() != "")
                                    status.Submask = szSubnetMask.ToString();

                                if (szGateway.ToString() != "")
                                    status.Gateway = szGateway.ToString();
                            }
                        }

                        picWireless.Update();

                        if (WirelessStatusEvent != null)
                        {
                            WirelessStatusEvent(this, status);
                        }
                    }
                    catch { }
                }));

            isWirelessQuerying = false;
        }

        private void RunBackground(RunBackgroundHandler handler)
        {
            Thread t = new Thread(new ThreadStart(handler));
            t.IsBackground = true;
            t.Start();
        }

        public void AddToMemo(string msg)
        {
            RunBackground(new RunBackgroundHandler(delegate()
            {
                BeginInvoke(new EventHandler(delegate(object sender, EventArgs e)
                {
                    lblMsg.Text = msg;
                    lblMsg.Dock = DockStyle.Fill;
                    lblMsg.Visible = true;

                    ShowMsgStart();
                }));
            }));
        }

        //
        private void DateStart()
        {
            tDate = new Thread(new ThreadStart(DateProc));
            tDate.IsBackground = true;
            tDate.Priority = ThreadPriority.Lowest;
            tDate.Start();
        }

        private void DateProc()
        {
            while (true)
            {                
                RefreshTime();

                Thread.Sleep(10000);
            }
        }

        private void DateStop()
        {
            try
            {
                if (tDate != null)
                    tDate.Abort();
            }
            catch { }
        }

        //
        private void ShowMsgStart()
        {
            tShowMsg = new Thread(new ThreadStart(ShowMsgProc));
            tShowMsg.IsBackground = true;
            tShowMsg.Start();
        }

        private void ShowMsgProc()
        {
            Thread.Sleep(5000);

            BeginInvoke(new EventHandler(delegate(object sender, EventArgs e)
            {
                lblMsg.Text = "";
                lblMsg.Dock = DockStyle.None;
                lblMsg.Size = new Size(1, 1);
                lblMsg.Visible = false;
            }));            
        }

        private void ShowMsgStop()
        {
            try
            {
                if (tShowMsg != null)
                    tShowMsg.Abort();
            }
            catch { }
        }

        private void timerBattery_Tick(object sender, EventArgs e)
        {
            timerBattery.Enabled = false;

            GetPowerLifePercent();           

            Utility.CloseBatteryPromptForm();

            timerBattery.Enabled = true;
        }

        private void timerCharging_Tick(object sender, EventArgs e)
        {
            if (chargingIndex > 4)
            {
                chargingIndex = 0;
            }
            picBattery.Image = imlBattery.Images[chargingIndex];
            picBattery.Update();
            chargingIndex++;
        }

        private void timerWireless_Tick(object sender, EventArgs e)
        {
            timerWireless.Enabled = false;
            
            Utility.CloseWifiWindow();

            GetWirelessState();

            timerWireless.Enabled = true;
        }
    }
}