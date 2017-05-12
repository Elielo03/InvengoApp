using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Invengo.NetAPI.Core;
using IRP1 = Invengo.NetAPI.Protocol.IRP1;
using Invengo.NetAPI.Communication;
using Invengo.Audio;
using Invengo.Devices.ModuleControl;

namespace Invengo.Demo.UHF
{
    public partial class FrWriteTags : Form
    {
      
        public MemoryBank selCodeArea = MemoryBank.TIDMemory;
       
        Byte[] tagID=null;
        public static string strcode = "";
        public FrWriteTags()
        {
            InitializeComponent();

            TagOperation.RfidConnecte();
            
        }

        /// <summary>
        /// Write Epc
        /// </summary>
        protected void UiWriteEpc()
        {
  
            AddToStatusAsync("");
            string strdata = tvDataMemo.Text;
            if (strdata == "")
            {
                AddToStatusAsync("EPC can not empty!");
                tvDataMemo.Focus();
                return;
            }
            string strpwd = tvPassword.Text;
            if (strpwd == "")
            {
                AddToStatusAsync("PassWord can not empty!");
                tvPassword.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
         
            try
            {
               
                byte[] bwritedata = FormatConvert.getWriteData(strdata);
                byte[] bpwd = FormatConvert.getPwd(strpwd);
                string errInfo = "";
                string strtmp = "";
                if (TagOperation.WriteEpc(bpwd, bwritedata, tagID, selCodeArea, out errInfo))
                {
                    strtmp = "Write: " + bwritedata.Length.ToString()+" byte!";
                    AddToStatusAsync(string.Format(strtmp));
                    FormatConvert.SoundSucceed();
                }
                else
                {

                    AddToStatusAsync("Write failure," + errInfo);
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Write Userdata_6C
        /// </summary>
        protected void UiWriteUserdata_6C()
        {
            AddToStatusAsync("");
            string strdata = tvDataMemo.Text;
            if (strdata == "")
            {
                AddToStatusAsync("User Data can not empty!");
                tvDataMemo.Focus();
                return;
            }

            string strpwd = tvPassword.Text;
            if (strpwd == "")
            {
                AddToStatusAsync("PassWord can not empty!");
                tvPassword.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
          
            try
            {
              
                uint offset = (ushort)(Convert.ToUInt32("0"));
                ushort BlockLength = 4;
                ushort BlockSize = 6;
                byte[] bwritedata = FormatConvert.getWriteData(strdata);
                byte[] bpwd = FormatConvert.getPwd(strpwd);
                string errInfo = "";
                int hadlen=0;
                bool ret = false;
                int OpWriteMode = this.cbtype.SelectedIndex;

                byte[] selcode = tagID;
               
                switch (OpWriteMode)
                {
                    case 1:
                        ret = TagOperation.BlockWriteData_6C(offset, bpwd, MemoryBank.UserMemory, bwritedata, selcode, selCodeArea, BlockLength, out hadlen, out errInfo);
                        break;
                    case 2:
                        ret = TagOperation.BlockEraseData_6C(offset, bpwd, MemoryBank.UserMemory, BlockLength, BlockSize, selcode, selCodeArea, out errInfo);
                        break;
                    default:
                        ret = TagOperation.WriteUserdata_6C(offset, bpwd, bwritedata, selcode, selCodeArea, out errInfo);
                        break;
                }

                if (ret == true)
                {

                    string strtmp = "Write: " + bwritedata.Length.ToString() + " byte!";
                    AddToStatusAsync(string.Format(strtmp));
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    AddToStatusAsync("Write failure," + errInfo);
                    FormatConvert.SoundError();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
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

      /// <summary>
        /// Write Data 
      /// </summary>
        protected void UiWriteData()
        {

           
            if (this.rbEpc.Checked)
            {
                UiWriteEpc();
            }
            else if (rbUserdata.Checked)
            {
                UiWriteUserdata_6C();
            }
            else
            { 
                return;
            }
            
        }
       
        /// <summary>
        /// Write Data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btWrite_Click_1(object sender, EventArgs e)
        {
            UiWriteData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Read Tag Data
        /// </summary>
        private void UiReadData()
        {
          
            this.lblStatus.Text = "";
            //byte[] selCode = null;
            byte[] data = null;
            string strerr = null;
            int _offset = 0;
            int _length = 28;
            string errinfo;
            if (rbEpc.Checked)
            {
                if (TagOperation.ReadEpc(tagID, selCodeArea, 1, out data, out strerr))
                {
                    this.tvDataMemo.Text = Util.ConvertByteArrayToHexWordString(data);
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    errinfo = string.Format("Read failure,{0}", strerr);
                    AddToStatusAsync(errinfo);
                    FormatConvert.SoundError();
                }
            }
            else if (rbTid.Checked)
            {
                if (TagOperation.ReadTID(tagID, selCodeArea, 1, out data, out strerr))
                {
                    tagID = data;
                    string tid = Util.ConvertByteArrayToHexWordString(data);
                    for (int i = 0; i < cbtid.Items.Count;i++ )
                    {
                        if(tid==cbtid.Items[i].ToString())
                        {
                            this.tvDataMemo.Text = "";
                            FormatConvert.SoundSucceed();
                            return;
                        }

                    }
                    cbtid.Items.Add(tid);
                    this.cbtid.Text = tid;
                    this.tvDataMemo.Text = "";
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    errinfo = string.Format("Read failure,{0}", strerr);
                    AddToStatusAsync(errinfo);
                    FormatConvert.SoundError();
                }
            }
            else
            {
                if (TagOperation.ReadUserdata_6C((ushort)_offset, (ushort)_length, tagID, selCodeArea, out data, out strerr))
                {
                    this.tvDataMemo.Text = Util.ConvertByteArrayToHexWordString(data);
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    errinfo = string.Format("Read failure,{0}", strerr);
                    AddToStatusAsync(errinfo);
                    FormatConvert.SoundError();
                }
            }
        }
      
      
        private void FrWriteTag_KeyDown(object sender, KeyEventArgs e)
        {
            int keyval = e.KeyValue;
            switch (keyval)
            {
                case 0xF1:
                    UiWriteData();
                    break;
                case 0xF2:
                    break;
                case 0xF5:
                    UiReadData();
                    break;
            }
        }

        private void btread_Click(object sender, EventArgs e)
        {
              
            UiReadData();
 
     
        }

        private void FrWriteTag_Load(object sender, EventArgs e)
        {
            
        }

       
       

        private void FrWriteTag_Closed(object sender, EventArgs e)
        {
            TagOperation.Disconnect();
        }

    }
}