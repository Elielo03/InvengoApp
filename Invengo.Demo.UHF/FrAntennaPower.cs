using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Invengo.Sample
{
    public partial class FrAntennaPower : Form
    {

        public static int _startpower = 0;

        /// <summary>
        /// 
        /// </summary>
        public FrAntennaPower()
        {
            InitializeComponent();
            InitializePowerList();
            GetAntennaPower();
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            GetAntennaPower();
        }

        /// <summary>
        /// Initialize Power List
        /// </summary>
        /// <returns></returns>
        private bool InitializePowerList()
        {
 
            List<ComboBindData> antennaPowerList = new List<ComboBindData>();

            string err = "";
            byte[] curfreqs = null;
            bool iret = TagOperation.GetPowerList(out curfreqs, out err);
            if (iret && curfreqs != null)
            {
                for (int i = 0; i < curfreqs.Length; i++)
                {
                    if (curfreqs[i] != 0x00)
                    {
                     
                        {
                            antennaPowerList.Add(new ComboBindData(_startpower + i, i));
                        }
                    }
                }
            }

            if (antennaPowerList.Count < 1)
            {
              
                return false;
            }

            cbdbm.DataSource = antennaPowerList;
            cbdbm.DisplayMember = "DisplayMember";
            cbdbm.ValueMember = "ValueMember";
            if (cbdbm.Items.Count > 0)
                cbdbm.SelectedIndex = 0;

            return true;
        }
        /// <summary>
        /// Get Power List
        /// </summary>
        private void GetAntennaPower()
        {
            byte[] powerlist = null;
            string errInfo = "";

            if (TagOperation.GetAntennaPower(out powerlist, out errInfo))
            {
                if (powerlist != null && powerlist.Length > 0)
                {
                    int val = powerlist[0];
                    int count = 0;
                    foreach (ComboBindData o in cbdbm.Items)
                    {
                        if (val == (int)o.ValueMember)
                        {
                            cbdbm.SelectedIndex = count;
                            break;
                        }
                        count++;
                    }
                    string strtmp = "The Power is :{0} dBm.";
                    string strpower = string.Format(strtmp, _startpower + val);
                    AddToStatusAsync(strpower);
                    FormatConvert.SoundSucceed();
                }
            }
            else
            {
                AddToStatusAsync("Query failed," + errInfo);
            }
        }

        /// <summary>
        /// Set Antenna Power
        /// </summary>
        private void SetAntennaPower()
        {
            if (cbdbm.SelectedIndex < 0)
                return;
            string errInfo = "";
            byte val = Convert.ToByte(cbdbm.SelectedValue);
            if (TagOperation.SetAntennaPower(val, out errInfo))
            {
                AddToStatusAsync("Set successfully.");
                FormatConvert.SoundSucceed();
                Close();
                return;
            }
            else
            {
                AddToStatusAsync("Failed," + errInfo);
                FormatConvert.SoundError();
            }
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

        /// <summary>
        /// Key Down
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyValue)
            {
                case 0xF1:
                case 0xF2:
                case 0xF5:
                    GetAntennaPower();
                    break;
            }
        }
       
        private void FrFrequency_Load(object sender, EventArgs e)
        {
            
        }

        private void btset_Click(object sender, EventArgs e)
        {
            SetAntennaPower();
        }

       
    }

   
}