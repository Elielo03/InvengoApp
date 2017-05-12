using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Sample;
using Invengo.NetAPI.Core;

namespace Invengo.Sample
{
    public partial class FrWriteTag : Form
    {
        private RFIDModule RfidMode = RFIDModule.F6C;
        private MemoryBank selCodeArea = MemoryBank.TIDMemory;
        private ushort QValue = 3;
        private string Tid = string.Empty;

        public FrWriteTag(RFIDModule rfidmode, string tid)
        {
            RfidMode = rfidmode;
            Tid = tid;
            InitializeComponent();
            InitializeCombox();
        }
        protected void InitializeCombox()
        {
            cbTargetTag.Items.Add("");  //keep empty item;
            if (!string.IsNullOrEmpty(Tid)) cbTargetTag.Items.Add(Tid);

            cbTargetTag.SelectedIndex = 0;

            cbDataArea.DisplayMember = "DisplayMember";
            cbDataArea.ValueMember = "ValueMember";
            if (RfidMode == RFIDModule.F6C)
            {
                cbDataArea.Items.Add(new ComboBindData("EPC_6C", 0));
                cbDataArea.Items.Add(new ComboBindData("Userdata_6C", 1));
            }
            if (RfidMode == RFIDModule.F6B)
            {
                cbDataArea.Items.Add(new ComboBindData("Userdata_6B", 2));
            }
            if (cbDataArea.Items.Count > 0)
            {
                cbDataArea.SelectedIndex = 0;
            }
        }

        private int GetDataAreaIndex()
        {
            if (cbDataArea.SelectedItem == null)
                return -1;
            int idx = 0;
            ComboBindData obj = (ComboBindData)cbDataArea.SelectedItem;
            idx = Convert.ToInt32(obj.ValueMember);
            return idx;
        }

        protected void AddToStatusAsync(string msg)

        {
            MessageBox.Show("addtostatusasync: " + msg);
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
        protected void AddToMemoAsync(string msg)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(AddToMemo), msg);
            }
            else
            {
                AddToMemo(msg, null);
            }
        }

        protected void AddToMemo(object sender, EventArgs e)
        {
            string msg = (string)sender;
            tvDataMemo.Text = msg;
        }
        protected void UiWriteData()
        {
            int selArea = GetDataAreaIndex();
            switch (selArea)
            {
                case 0:
                    UiWriteEpc();
                    break;
                case 1:
                    UiWriteUserdata_6C();
                    break;
                case 2:
                    UiWriteUserdata_6B();
                    break;
            }
        }

        protected void UiReadData()
        {
            int selArea = GetDataAreaIndex();
            switch (selArea)
            {
                case 0:
                    UiReadEpc();
                    break;
                case 1:
                    UiReadUserdata_6C();
                    break;
                case 2:
                    UiReadUserdata_6B();
                    break;
            }
        }


        protected void UiReadEpc()
        {
            AddToMemoAsync("");
            string strcode = cbTargetTag.SelectedItem.ToString();
            //MessageBox.Show("strCode es: " + strcode);
            byte[] selcode = null;
            if (strcode != "")
            {
                    
                selcode = Util.ConvertHexStringToByteArray(strcode);
                //foreach (byte element in selcode) {
                //    MessageBox.Show("selcode es: " + element.ToString());
                //}
                
            }

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                string errInfo = "";
                string strtmp = "";
                byte[] readdata = null;
                bool ret = TagOperation.ReadEpc(selcode, selCodeArea, QValue, out readdata, out errInfo);
                if (ret && readdata != null)
                {
                    //foreach(byte elemet in readdata){
                    //    MessageBox.Show("readdata es: " + elemet.ToString());
                    //}
                    //MessageBox.Show("decode readData: " + BitConverter.ToString(readdata));
                    
                    byte[] tepc = null;
                    int rssi = 0;
                    string sepc = string.Empty;
                        sepc = Util.ConvertByteArrayToHexString(readdata);
                    AddToMemoAsync(sepc);
                    strtmp = "Acquired data {0} bytes.";
                    AddToStatusAsync(string.Format(strtmp, readdata.Length));
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    //strtmp = CurLanguage.GetMsg("MSG_1");
                    //AddToStatusAsync(string.Format(strtmp, errInfo));
                    AddToStatusAsync(errInfo);
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        protected void UiWriteEpc()
        {
            AddToStatusAsync("");
            string strdata = tvDataMemo.Text;
            if (strdata == "")
            {
                AddToStatusAsync("Input the write data.");
                tvDataMemo.Focus();
                return;
            }
            string strpwd = tvPassword.Text;
            if (strpwd == "")
            {
                AddToStatusAsync("Input the tag password.");
                tvPassword.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            string strcode = cbTargetTag.SelectedItem.ToString();
            byte[] selcode = null;
            try
            {
                if (strcode != "")
                {
                    selcode = Util.ConvertHexStringToByteArray(strcode);
                }
                byte[] bwritedata = Util.ConvertHexStringToByteArray(strdata);
                byte[] bpwd = Util.ConvertHexStringToByteArray(strpwd);
                string errInfo = "";
                string strtmp = "";
                if (TagOperation.WriteEpc(bpwd, bwritedata, selcode, selCodeArea, out errInfo))
                {
                    strtmp = "Write {0} bytes.";
                    AddToStatusAsync(string.Format(strtmp, bwritedata.Length));
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    //strtmp = CurLanguage.GetMsg("MSG_13");
                    //AddToStatusAsync(string.Format(strtmp, errInfo));
                    AddToStatusAsync(errInfo);
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        protected void UiReadUserdata_6C()
        {
            MessageBox.Show("UiReadUserdata_6C");
            AddToMemoAsync("");
            string strcode = cbTargetTag.SelectedItem.ToString();
            byte[] selcode = null;
            if (strcode != "")
            {
                MessageBox.Show("strCode: " + selcode);
                selcode = Util.ConvertHexStringToByteArray(strcode);
            }

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                uint offset = (uint)(Convert.ToUInt32(tvOffsetAddr.Text));
                uint length = (uint)(Convert.ToUInt32(tvLength.Text));
                byte[] readdata = null;
                string errInfo = "";
                string strtmp = "";
                bool ret = TagOperation.ReadUserdata_6C(offset, length, selcode, selCodeArea, out readdata, out errInfo);
                if (ret && readdata != null)
                {
                    if (readdata != null)
                    {
                        foreach(byte element in readdata){
                            MessageBox.Show("readdata: " + element.ToString());
                        }
                        string str = Util.ConvertByteArrayToHexString(readdata);
                        AddToMemoAsync(str);
                        strtmp = "Acquired data {0} bytes.";
                        AddToStatusAsync(string.Format(strtmp, readdata.Length));
                        FormatConvert.SoundSucceed();
                    }
                }
                else
                {
                    //strtmp = CurLanguage.GetMsg("MSG_1");
                    //AddToStatusAsync(string.Format(strtmp, errInfo));
                    AddToStatusAsync(errInfo);
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        protected void UiWriteUserdata_6C()
        {
            AddToStatusAsync("");
            string strdata = tvDataMemo.Text;

            if (strdata == "")
            {
                AddToStatusAsync("Input the write data.");
                tvDataMemo.Focus();
                return;
            }

            string strpwd = tvPassword.Text;
            if (strpwd == "")
            {
                AddToStatusAsync("Input the tag password.");
                tvPassword.Focus();
                return;
            }


            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            string strcode = cbTargetTag.SelectedItem.ToString();
            byte[] selcode = null;
            try
            {
                if (strcode != "")
                {
                    selcode = Util.ConvertHexStringToByteArray(strcode);
                }
                uint offset = (ushort)(Convert.ToUInt32(tvOffsetAddr.Text));
                //uint length = (ushort)(Convert.ToUInt32(tvLength.Text) / 2);
                byte[] bwritedata = Util.ConvertHexStringToByteArray(strdata);
                byte[] bpwd = Util.ConvertHexStringToByteArray(strpwd);
                int hadlen = 0;
                string errInfo = "";
                bool ret = TagOperation.WriteUserdata_6C(offset, bpwd, bwritedata, selcode, selCodeArea, out errInfo);

                string strmsg = "";
                string strtmp = "";
                if (ret == true)
                {

                    strtmp = "Write {0} bytes.";
                    strmsg = string.Format(strtmp, bwritedata.Length);

                    AddToStatusAsync(strmsg);
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    //strtmp = CurLanguage.GetMsg("MSG_13");
                    //AddToStatusAsync(string.Format(strtmp, errInfo));
                    AddToStatusAsync(errInfo);
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
      
        protected void UiWriteUserdata_6B()
        {
            AddToStatusAsync("");
            string strdata = tvDataMemo.Text;

            if (strdata == "")
            {
                AddToStatusAsync("Input the write data.");
                tvDataMemo.Focus();
                return;
            }

            string strpwd = tvPassword.Text;
            if (strpwd == "")
            {
                AddToStatusAsync("Input the tag password.");
                tvPassword.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            string strcode = cbTargetTag.SelectedItem.ToString();
            byte[] selcode = null;
            try
            {
                if (strcode != "")
                {
                    selcode = Util.ConvertHexStringToByteArray(strcode);
                }
                uint offset = (ushort)(Convert.ToUInt32(tvOffsetAddr.Text));
                uint length = (ushort)(Convert.ToUInt32(tvLength.Text));
                byte[] bwritedata = Util.ConvertHexStringToByteArray(strdata);
                byte[] bpwd = Util.ConvertHexStringToByteArray(strpwd);
                string errInfo = "";
                bool ret = false;
                ret = TagOperation.WriteUserdata_6B(selcode, offset, bwritedata, out errInfo);
                string strmsg = "";
                string strtmp = "";
                if (ret == true)
                {
                    strtmp = "Write {0} bytes.";
                    strmsg = string.Format(strtmp, bwritedata.Length);
                    AddToStatusAsync(strmsg);
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    strtmp = "Write failed, {0}";
                    AddToStatusAsync(string.Format(strtmp, errInfo));
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        protected void UiReadUserdata_6B()
        {
            AddToMemoAsync("");
            string strcode = cbTargetTag.SelectedItem.ToString();
            byte[] selcode = null;
            if (strcode != "")
            {
                selcode = Util.ConvertHexStringToByteArray(strcode);
            }

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                uint offset = (uint)(Convert.ToUInt32(tvOffsetAddr.Text));
                uint length = (uint)(Convert.ToUInt32(tvLength.Text));
                byte[] readdata = null;
                string errInfo = "";
                string strtmp = "";
                bool ret = TagOperation.ReadUserdata_6B(selcode, offset, length, out readdata, out errInfo);
                if (ret && readdata != null)
                {
                    if (readdata != null)
                    {
                        string str = Util.ConvertByteArrayToHexString(readdata);
                        AddToMemoAsync(str);
                        strtmp = "Acquired data {0} bytes.";
                        AddToStatusAsync(string.Format(strtmp, readdata.Length));
                        FormatConvert.SoundSucceed();
                    }
                }
                else
                {
                    strtmp = "ead failed, {0}!";
                    AddToStatusAsync(string.Format(strtmp, errInfo));
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void FrWriteTag_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UiWriteData();
        }

        private void btread_Click(object sender, EventArgs e)
        {
            UiReadData();
        }


    }
}