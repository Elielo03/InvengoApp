using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.NetAPI.Core;

namespace Invengo.Demo.UHF
{
    public partial class FrEpcFilter : Form
    {
        byte[] TargetCode;
        public MemoryBank selCodeArea = MemoryBank.TIDMemory;

        public FrEpcFilter()
        {
            InitializeComponent();
            RfidConfig.RfidConnecte();
            InitializeFilterAddressList();
        }

        /// <summary>
        /// Initialize Filter Address List
        /// </summary>
        private void InitializeFilterAddressList()
        {
            try
            {
                if (this.tvEpcData.Text != "")
                {
                    TargetCode = Util.ConvertHexStringToByteArray(this.tvEpcData.Text);
                }
                List<ComboBindData> list = new List<ComboBindData>();
                listBoxAddr.BeginUpdate();

                if (TargetCode != null)
                {
                    for (int i = 0; i < Math.Min(TargetCode.Length, 12); i++)
                    {
                        string sb = TargetCode[i].ToString("X2");
                        list.Add(new ComboBindData(sb, i));
                    }
                }
                this.listBoxAddr.DataSource = list;
                this.listBoxAddr.DisplayMember = "DisplayMember";
                this.listBoxAddr.ValueMember = "ValueMember";

                //
                this.listBoxChooseAddr.DisplayMember = "DisplayMember";
                this.listBoxChooseAddr.ValueMember = "ValueMember";
                listBoxAddr.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Set Epc Filter
        /// </summary>
        private void SetEpcFilter()
        {
            string errInfo = "";
            string strhex =FormatConvert.HaxToStr(tvEpcData.Text.Trim());
            if (strhex == "" ||
                strhex.Length != 24)
            {
                AddToStatusAsync("Input tag EPC(12-byte)!");
                tvEpcData.Focus();
                return;
            }
            if (listBoxChooseAddr.Items.Count < 1)
            {
                AddToStatusAsync("Select matched data!");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                byte[] match = new byte[this.listBoxAddr.Items.Count];
                for (int i = 0; i < match.Length; i++)
                {
                    match[i] = 0x00;
                }
                foreach (object o in this.listBoxChooseAddr.Items)
                {
                    ComboBindData item = (ComboBindData)o;
                    int iadd = Convert.ToInt32(item.ValueMember);
                    match[iadd] = 0xFF;
                }
                byte[] bcode = Util.ConvertHexStringToByteArray(strhex);

                if (RfidConfig.SetEpcFilter(0x00, bcode, match, out errInfo))
                {
                    AddToStatusAsync("Configure EPC match completed.");
                    FormatConvert.SoundSucceed();
                    Close();
                }
                else
                {
                    FormatConvert.SoundError();
                    AddToStatusAsync("Configure EPC match failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Cancel Epc Filter
        /// </summary>
        private void CancelEpcFilter()
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                string errInfo = "";
                byte[] bcode = new byte[listBoxAddr.Items.Count];
                byte[] match = new byte[this.listBoxAddr.Items.Count];
                for (int i = 0; i < match.Length; i++)
                {
                    match[i] = 0x00;
                }

                if (RfidConfig.SetEpcFilter(0x01, bcode, match, out errInfo))
                {
                    AddToStatusAsync("Cancel match EPC.");
                    FormatConvert.SoundSucceed();
                    Close();
                }
                else
                {
                    FormatConvert.SoundError();
                    AddToStatusAsync("Cancel Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Add To Status Async
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


        private void FrEpcFilter_Load(object sender, EventArgs e)
        {

        }

      

        private void btallrigth_Click_1(object sender, EventArgs e)
        {
            this.listBoxChooseAddr.Items.Clear();

        }

        /// <summary>
        /// all left_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btallleft_Click_1(object sender, EventArgs e)
        {
            foreach (ComboBindData o in listBoxAddr.Items)
            {
                bool isExists = false;
                foreach (ComboBindData oo in listBoxChooseAddr.Items)
                {
                    if (oo.ValueMember == o.ValueMember)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists)
                    this.listBoxChooseAddr.Items.Add(o);
            }
        }

        private void btright_Click_1(object sender, EventArgs e)
        {
            if (this.listBoxChooseAddr.SelectedItem == null)
                return;
            this.listBoxChooseAddr.Items.Remove(this.listBoxChooseAddr.SelectedItem);
        }

        /// <summary>
        /// left_Click_
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btleft_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listBoxAddr.SelectedIndex < 0)
                    return;
                ComboBindData item = (ComboBindData)(this.listBoxAddr.SelectedItem);
                bool isExists = false;
                foreach (ComboBindData o in listBoxChooseAddr.Items)
                {
                    if (o.ValueMember == item.ValueMember)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists)
                    this.listBoxChooseAddr.Items.Add(new ComboBindData(item.DisplayMember, item.ValueMember));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// ReadEpc
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
                for (int i = 0; i < tvEpcData.Items.Count; i++)
                {
                    if (epc == tvEpcData.Items[i].ToString())
                    {
                        FormatConvert.SoundSucceed();
                        return;
                    }

                }
                tvEpcData.Items.Add(epc);
                this.tvEpcData.Text = epc;
                AddToStatusAsync("");
                FormatConvert.SoundSucceed();
            }
            else
            {
                AddToStatusAsync("Read failure,"+strerr);
                FormatConvert.SoundError();
            }
        }

        private void btfilter_Click(object sender, EventArgs e)
        {
            SetEpcFilter();
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            CancelEpcFilter();
        }

        private void FrEpcFilter_Closed(object sender, EventArgs e)
        {
            RfidConfig.Disconnect();
        }

        private void btread_Click(object sender, EventArgs e)
        {
            ReadEpc();
            InitializeFilterAddressList();
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
                    InitializeFilterAddressList();
                    break;
            }
        }
    }
}