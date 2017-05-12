using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Devices.ModuleControl;

namespace Invengo.Sample
{
    public partial class FrRfidModule : Form
    {
        public FrRfidModule()
        {
            InitializeComponent();
        }
        /// <summary>
        /// RFID Module
        /// </summary>
        private void RFIDModule()
        {
            if (rbInternal.Checked)
            {
                RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Internal);
                RfidConfig.RfidModule = 1;

            }
            else
            {
                RfidControl.SwitchRfid(RfidControl.RFIDModuleFlag.Extern);
                RfidConfig.RfidModule = 2;
            }
        }
        private void btok_Click(object sender, EventArgs e)
        {
            RFIDModule();
            FrTagMain frtag = new FrTagMain();
            frtag.ShowDialog();
            Close();
        }
    }
}