using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.IO;
using System.Reflection;
using Invengo;
using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;
using Invengo.Devices.ModuleControl;
using Invengo.Platform;

namespace Invengo.Sample
{
    public partial class FrLoader : Form
    {
        protected XmlHelper condoc;
        protected string portName = "COM4";
        protected string irpName = "IRP1";

        protected Bitmap bmpBuffer;
        public string BackgroundFileName;
        //
        protected int TaskbarStatus = 1;
        //
        protected string demoname = "";
        //
        private PDAInfo.DevModel _pdamodel;

        public FrLoader()
        {
            InitializeComponent();

            BackgroundFileName = AppPath + @"\images\rfidsplash.png";
        }

        public static string AppPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          
            //LayoutCenter();
            if (File.Exists(BackgroundFileName))
            {
                bmpBuffer = new Bitmap(BackgroundFileName);
            }
            else
            {
                bmpBuffer = new Bitmap(this.Width, this.Height);
            }

            //StartupAsync();
            this.timerLoad.Enabled = true;
        }

        private void LoaderForm_Closed(object sender, EventArgs e)
        {
            this.timerLoad.Enabled = false;
 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (bmpBuffer != null)
            {
                //e.Graphics.DrawImage(bmpBuffer, this.Location.X, this.Location.Y, this.ClientRectangle, GraphicsUnit.Pixel);
                e.Graphics.DrawImage(bmpBuffer, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            }
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }       

        private void LayoutCenter()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            this.Location = new Point((screen.Width - this.Width) / 2,
              (screen.Height - this.Height) / 2);
        }

        private void StartupAsync()
        {
            //if (InvokeRequired)
            //{
                BeginInvoke(new EventHandler(Startup));
            //}
            //else
            //{
            //    Startup(null, null);
            //}
        }

        private void Startup(object sender, EventArgs e)
        {
            condoc = new XmlHelper();
            condoc.LoadXmlDocument("sys.config");
            string strauto = condoc.GetSingleAttributeValue("startup", "mode");
            _pdamodel = PDAInfo.GetDevModel();
            //if (strauto == "auto")
            //{
            //    //this.timerLoad.Enabled = true;
                LoaderAsync();
            //}
            //else if (strauto == "manual")
            //{
            //    FrDemolist demolist = new FrDemolist();
            //    progressBarWait.Value = progressBarWait.Maximum;
            //    demolist.Load += new EventHandler(showform_Load);
            //    demolist.ShowDialog();
            //    this.Close();
            //}
            //else
            //{
            //    demoname = condoc.GetSingleAttributeValue("startup", "default");
            //    FrTagMain form = new FrTagMain();
            //    switch (demoname)
            //    {
            //        case "F6C":
            //            RfidConfig._rfidModel = RFIDModule.F6C;
            //            break;
            //        case "F6B":
            //            RfidConfig._rfidModel = RFIDModule.F6B;
            //            break;
            //        case "F6G":
            //            RfidConfig._rfidModel = RFIDModule.F6G;
            //            break;
            //        default:
            //            MessageBox.Show("No matched demo!", "RFID DEMO", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            //            break;
            //    }
            //    if (form != null)
            //    {
            //        progressBarWait.Value = progressBarWait.Maximum;
            //        form.Load += new EventHandler(showform_Load);
            //        form.ShowDialog();
            //    }
            //    this.Close();
            //}
        }

        private void showform_Load(object sender, EventArgs e)
        {
            //Hide();
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            this.timerLoad.Enabled = false;
            //LoaderAsync();
            StartupAsync();
        }

        private void LoaderAsync()
        {
            //if (InvokeRequired)
            //{
                Invoke(new EventHandler(Loader));
            //}
            //else
            //{
            //    Loader(null, null);
            //}
        }

        /// <summary>
        /// �ж��豸���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loader(object sender, EventArgs e)
        {
            bool isfound = false;
            try
            {
                progressBarWait.Value = 20;
                FrTagMain form = null;
                if (!isfound)
                {
                    isfound = ReaderF6C();
                    if (isfound)
                    {

                        form = new FrTagMain();
                    }
                    else
                    {
                        progressBarWait.Value = 50;
                    }
                }

                //if (!isfound)
                //{
                //    int iFlag = 0;
                //    isfound = ReaderF6B(out iFlag);
                //    if (isfound)
                //    {
                //        if (iFlag == 2)
                //        {
                //            RfidConfig._rfidModel = RFIDModule.F6G;
                //        }
                //        else
                //        {
                //            RfidConfig._rfidModel = RFIDModule.F6B;
                //        }
                //    }
                //    else
                //    {
                //        progressBarWait.Value = 100;
                //    }
                //}

                if (isfound && form != null)
                {
                    progressBarWait.Value = progressBarWait.Maximum;
                    form.Load += new EventHandler(showform_Load);
                    form.ShowDialog();
                }
                else
                {
                    progressBarWait.Value = progressBarWait.Maximum;

                    MessageBox.Show("模块不能工作!");
                }
            }
            catch (Exception ex)
            {
                ShowInfoAsync(ex.Message);
                Thread.Sleep(3000);
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// ��жF6C����
        /// </summary>
        /// <returns></returns>
        private bool ReaderF6C()
        {
            bool isRight = false;
            Reader reader = null;
            int sleepspan = 400;
            try
            {
                reader = RfidAdapter.CreateReader(RFIDModule.F6C, irpName);
                string prdno = "";
                string err = "";
                bool ret = false;

                if (_pdamodel == PDAInfo.DevModel.XC2903)
                {
                    RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Internal);
                }
                else
                {
                    RfidControl.Active();
                }

                ////if (devicetype == "2903")
                ////{
                ////    RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Internal);
                ////}
                ////else
                ////{
                ////    RfidControl.Active();
                ////}
                Thread.Sleep(sleepspan);
                if (!reader.IsConnected)
                {
                    reader.Connect();
                    Thread.Sleep(sleepspan);
                }
                for (int i = 0; i < 2; i++)
                {
                    if (reader.IsConnected)
                        ret = RfidConfigration_6C.GetProductNo(out prdno, out err);
                    //if (!ret && devicetype == "2903")
                    if (!ret && _pdamodel == PDAInfo.DevModel.XC2903)
                    {
                        bool isext = RfidControl.IsExtRfid();
                        if (!isext)
                            break;
                        RfidControl.Deactive();
                        Thread.Sleep(sleepspan);
                        RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Extern);
                        Thread.Sleep(sleepspan);
                    }
                    else
                    {
                        break;
                    }
                }

                if (ret && !string.IsNullOrEmpty(prdno))
                {
                    if (prdno.Length >= 4
                        && (prdno.IndexOf("802", 0) > -1))
                    {
                        isRight = true;
                    }
                }
                else
                {
                    if (!reader.IsConnected)
                    {
                        Log.Debug("Fail to open port");
                    }
                    else if (!ret)
                    {
                        Log.Debug("Fail to get rfid data");
                    }
                }
            }
            catch (Exception ex)
            {
                string strex = ex.Message;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Disconnect();
                    reader.Dispose();
                    reader = null;
                }
                RfidControl.Deactive();
            }
            return isRight;
        }

        /// <summary>
        /// ��жF6B����
        /// </summary>
        /// <returns></returns>
        private bool ReaderF6B(out int flag)
        {
            bool isRight = false;
            flag = 0;
            Reader reader = null;
            try
            {
                reader = RfidAdapter.CreateReader(RFIDModule.F6B, irpName);
                string prdno = "";
                string err = "";
                bool ret = false;

                RfidControl.Active();
                Thread.Sleep(400);
                for (int i = 0; i < 1; i++)
                {
                    if (!reader.IsConnected)
                    {
                        reader.Connect();
                        Thread.Sleep(100);
                        if (!reader.IsConnected)
                            continue;
                    }
                    ret = RfidConfigration_6C.GetProductNo(out prdno, out err);
                    if (ret)
                        break;
                }

                if (ret)
                {
                        if (prdno.Length >= 4
                            && prdno.IndexOf("F6BE", 0) > -1)
                        {
                            flag = 2;
                            isRight = true;
                        }
                        else if (prdno.Length >= 3
                            && prdno.IndexOf("F6B", 0) > -1)
                        {
                            flag = 1;
                            isRight = true;
                        }
                }
            }
            catch { }
            finally
            {
                if (reader != null)
                {
                    reader.Disconnect();
                    reader.Dispose();
                    reader = null;
                }
                RfidControl.Deactive();
            }

            return isRight;
        }

        private void ShowInfoAsync(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(ShowInfo), msg);
            }
            else
            {
                ShowInfo(msg, null);
            }
        }

        private void ShowInfo(object sender, EventArgs e)
        {
            string msg = (string)sender;
            this.lblInfo.Visible = true;
            this.lblInfo.Text = msg;
        }
    }
}