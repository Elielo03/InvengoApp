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
    public partial class FrKillTag : Form
    {

        public MemoryBank selCodeArea = MemoryBank.TIDMemory;

        public FrKillTag()
        {
            InitializeComponent();
            TagOperation.RfidConnecte();

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
        /// Kill Tag
        /// </summary>
        private void KillTag()
        {
            string TitleText="";
            if (cbTargetTag.SelectedIndex < 0)
            {
                AddToStatusAsync("Plese select one tag epc!");
                return;
            }
            string strepc = cbTargetTag.SelectedItem.ToString();
            string strpwd = tvKillPwd.Text;
            if (strpwd == "")
            {
                AddToStatusAsync("The KillPassWord can not empty!");
                return;
            }
            if (DialogResult.No == MessageBox.Show("Are you sure to kill the tag?", TitleText , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                return;
            }
            
            byte[] bepc = Util.ConvertHexStringToByteArray(strepc);
            byte[] killPwd = Util.ConvertHexStringToByteArray(strpwd);
            string errInfo = "";
            if (TagOperation.KillTag_6C(killPwd, bepc, out errInfo))
            {
                AddToStatusAsync("Kill Tag Successfully.");
               FormatConvert .SoundSucceed();
            }
            else
            {
                AddToStatusAsync("Kill Tag Failed," + errInfo);
                FormatConvert.SoundError();
            }
        }

        /// <summary>
        /// Read Epc
        /// </summary>
        private void ReadEpc()
        {
            byte[] tagEpc = null;
            byte[] data;
            string strerr;
            TagOperation.RfidConnecte();
            if (TagOperation.ReadEpc(tagEpc, selCodeArea, 1, out data, out strerr))
            {
                tagEpc = data;
                string epc = Util.ConvertByteArrayToHexWordString(data);
                for (int i = 0; i < cbTargetTag.Items.Count; i++)
                {
                    if (epc == cbTargetTag.Items[i].ToString())
                    {
                        FormatConvert.SoundSucceed();
                        return;
                    }

                }
                cbTargetTag.Items.Add(epc);
                this.cbTargetTag.Text = epc;
                AddToStatusAsync("");
                FormatConvert.SoundSucceed();
            }
            else
            {
                AddToStatusAsync("Read failure," + strerr);
                FormatConvert.SoundError();
            }
        }

        private void btkill_Click(object sender, EventArgs e)
        {
            KillTag();
        }

        private void btread_Click(object sender, EventArgs e)
        {
            ReadEpc();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyValue)
            {
                case 0xF1:
                case 0xF2:
                case 0xF5:
                    ReadEpc();
                    break;
            }
        }

        private void FrKillTag_Closed(object sender, EventArgs e)
        {
            TagOperation.Disconnect();

        }

        private void FrKillTag_Load(object sender, EventArgs e)
        {

        }
    }
}