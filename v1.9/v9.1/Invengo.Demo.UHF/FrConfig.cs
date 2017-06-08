using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;

namespace Invengo.Demo.UHF
{



    public partial class FrConfig : Form
    {
        public MemoryBank selCodeArea = MemoryBank.TIDMemory;


        public FrConfig()
        {
            InitializeComponent();
            TagOperation.RfidConnecte();

        }

        /// <summary>
        /// Add To Status
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

        /// <summary>
        /// Set Access PassWord
        /// </summary>
        private void SetAccessPwd()
        {
            string oldpwd = tvOriAccessPwd.Text;
            string newpwd = tvNewAccessPwd.Text;
            string strcode = "";
            if (cbTargetTag.Items.Count > 0)
            {
                strcode = cbTargetTag.SelectedItem.ToString();
            }
            if (strcode == "")
            {
                AddToStatusAsync("Please select one tag!");
                cbTargetTag.Focus();
                return;
            }
            if (oldpwd == "")
            {
                AddToStatusAsync("Old password can not empty!");
                tvOriAccessPwd.Focus();
                return;
            }
            if (newpwd == "")
            {
                AddToStatusAsync("New password can not empty!");
                tvNewAccessPwd.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                byte[] bcode = Util.ConvertHexStringToByteArray(strcode);
                byte[] boldPwd = Util.ConvertHexStringToByteArray(oldpwd);
                byte[] bnewPwd = Util.ConvertHexStringToByteArray(newpwd);
                string errInfo = "";
                if (TagOperation.SetAccessPassword(boldPwd, bnewPwd, bcode, selCodeArea, out errInfo))
                {
                    AddToStatusAsync("Set Access Password Successfully!");
                    FormatConvert.SoundSucceed();
                }
                else
                {

                    AddToStatusAsync("Set Access Password Failed," + errInfo);
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
        /// Set Kill PassWord
        /// </summary>
        private void SetKillPwd()
        {
            string oldpwd = tvOriAccessPwd.Text;
            string newpwd = tvKillPwd.Text;
            string strcode = "";
            if (cbTargetTag.Items.Count > 0)
            {
                strcode = cbTargetTag.SelectedItem.ToString();
            }
            if (strcode == "")
            {
                AddToStatusAsync("Please select one tag!");
                cbTargetTag.Focus();
                return;
            }
            if (oldpwd == "")
            {
                AddToStatusAsync("Access password can not empty!");
                tvOriAccessPwd.Focus();
                return;
            }
            if (newpwd == "")
            {
                AddToStatusAsync("Kill password can not empty!");
                tvKillPwd.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                byte[] bcode = Util.ConvertHexStringToByteArray(strcode);
                byte[] bAccessPwd = Util.ConvertHexStringToByteArray(oldpwd);
                byte[] bnewPwd = Util.ConvertHexStringToByteArray(newpwd);
                string errInfo = "";
                if (TagOperation.SetKillPassword(bAccessPwd, bnewPwd, bcode, selCodeArea, out errInfo))
                {
                    AddToStatusAsync("Set Kill Password Successfully!");
                    FormatConvert.SoundSucceed();
                }
                else
                {

                    AddToStatusAsync("Set Kill Password Failed," + errInfo);
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
        /// Set Tag Lock
        /// </summary>
        private void SetTagLock()
        {
            int seloperate = cbLockOperate.SelectedIndex;
            int selbank = cbLockArea.SelectedIndex;
            string accessPwd = tvOriAccessPwd.Text;
            string strcode = "";
            if (cbTargetTag.Items.Count > 0)
            {
               strcode= cbTargetTag.SelectedItem.ToString();
            }
            if (strcode == "")
            {
                AddToStatusAsync("Please select one tag!");
                cbTargetTag.Focus();
                return;
            }
            if (accessPwd == "")
            {
                AddToStatusAsync("Access password can not empty!");
                tvOriAccessPwd.Focus();
                return;
            }
            if (seloperate < 0)
            {
                AddToStatusAsync("Select operation type!");
                cbLockOperate.Focus();
                return;
            }
            if (selbank < 0)
            {
                AddToStatusAsync("Select operating memory!");
                cbLockArea.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                byte[] bcode = Util.ConvertHexStringToByteArray(strcode);
                byte[] baccessPwd = Util.ConvertHexStringToByteArray(accessPwd);
                string errInfo = "";
                if (TagOperation.LockTag_6C(baccessPwd, (byte)seloperate, (byte)selbank, bcode, selCodeArea, out errInfo))
                {
                    if (seloperate == 1)
                    {
                        AddToStatusAsync("Unlock tag successfully.");
                    }
                    else
                    {
                        AddToStatusAsync("Lock tag successfully.");
                        FormatConvert.SoundError();
                    }
                    FormatConvert.SoundSucceed();
                }
                else
                {
                    if (seloperate == 1)
                    {
                        AddToStatusAsync("Unlock failed," + errInfo);
                    }
                    else
                    {
                        AddToStatusAsync("Lock failed," + errInfo);
                    }
                    FormatConvert.SoundError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        protected void InitializeCombox()
        {
          
        }

        private void btset_Click(object sender, EventArgs e)
        {
            if (rbNewAccessPassword.Checked)
            {
                SetAccessPwd();
            }
            else if (rbKillPwd.Checked)
            {
                SetKillPwd();
            }
            else if (rbTagLock.Checked)
            {
                SetTagLock();
            }
        }

        /// <summary>
        /// Read TID 
        /// </summary>
        private void ReadTID()
        {
            byte[] tagID=null;
            byte[] data;
            string strerr;
            if (TagOperation.ReadTID(tagID, selCodeArea, 1, out data, out strerr))
            {
                tagID = data;
                string tid = Util.ConvertByteArrayToHexWordString(data);
                for (int i = 0; i < cbTargetTag.Items.Count; i++)
                {
                    if (tid == cbTargetTag.Items[i].ToString())
                    {
                        FormatConvert.SoundSucceed();
                        return;
                    }

                }
                cbTargetTag.Items.Add(tid);
                this.cbTargetTag.Text = tid;
                AddToStatusAsync("");
                FormatConvert.SoundSucceed();
            }
            else
            {
                AddToStatusAsync("Read failure,"+strerr);
                FormatConvert.SoundError();
            }
        }

        private void btread_Click(object sender, EventArgs e)
        {
            ReadTID();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyValue)
            {
                case 0xF1:
                case 0xF2:
                case 0xF5:
                    ReadTID();
                    break;
            }
        }
        private void rbNewAccessPassword_CheckedChanged(object sender, EventArgs e)
        {
            tvNewAccessPwd.Enabled = rbNewAccessPassword.Checked;

        }

        private void rbKillPwd_CheckedChanged(object sender, EventArgs e)
        {
            tvKillPwd.Enabled = rbKillPwd.Checked;

        }

        private void rbTagLock_CheckedChanged(object sender, EventArgs e)
        {
            panelLock.Enabled = rbTagLock.Checked;

        }

        private void FrConfig_Load(object sender, EventArgs e)
        {

        }

        private void FrConfig_Closed(object sender, EventArgs e)
        {
            TagOperation.Disconnect();
        }
    }
}