using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Invengo.Sample
{
    public partial class FrMenu : Form
    {
        public FrMenu()
        {
            InitializeComponent();
           
        }


        private void bttag_Click_1(object sender, EventArgs e)
        {
           
            FrTagMain frtag = new FrTagMain(0);
            frtag.ShowDialog();
        }

      
      
        private void FrMenu_Load(object sender, EventArgs e)
        {

        }

        private void btpda_Click(object sender, EventArgs e)
        {
            FrPadMain frpad = new FrPadMain();
            frpad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrBarcode barcode = new FrBarcode();
            barcode.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FrMotoBarCode frm = new FrMotoBarCode();
            //frm.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            try
            {
                Application.Exit();
                System.Threading.Thread.CurrentThread.Abort();

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrConexion frConexion = new FrConexion();
            frConexion.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
             FrTagMain frtag = new FrTagMain(1);
            frtag.ShowDialog();
        }
    }
}