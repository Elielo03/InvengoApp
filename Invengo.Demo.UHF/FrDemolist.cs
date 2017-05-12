using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Invengo.Sample
{
    public partial class FrDemolist : Form
    {
        public FrDemolist()
        {
            InitializeComponent();
        }

        private void DemolistForm_Load(object sender, EventArgs e)
        {
            LayoutCenter();
        }

        private void LayoutCenter()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            this.Location = new Point((screen.Width - this.Width) / 2,
              (screen.Height - this.Height) / 2);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Startup();
        }

        private void Startup()
        {
            try
            {
                FrTagMain form = new FrTagMain();
                if (rb1.Checked)
                {
                    RfidConfig._rfidModel = RFIDModule.F6C;
                }
                else if (rb2.Checked)
                {
                    RfidConfig._rfidModel = RFIDModule.F6B;
                }
                else if (rb3.Checked)
                {
                    RfidConfig._rfidModel = RFIDModule.F6C_F6B;
                }
                
                if (form != null)
                {
                    Hide();
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}   //