using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Invengo.Sample
{
    public partial class FrInfo : Form
    {
        //sitring id = null;
        public FrInfo(string  nombre)
        {
            InitializeComponent();
            PictureBox pictureBox2 = new PictureBox();
            //noDisponible
            if (nombre.Equals("0") || nombre==null)
            {
                
                txtInfo.Text = "Ese registro no se encuentra en la BD";

                this.pictureBox2.Image = new Bitmap(@"/noDisponible.jpg");
            }else {
                try
                {
                    string[] datos = nombre.Split(',');
                    txtInfo.Text = datos[1] + " \n" + datos[2] + " \n" + datos[3];
                    this.pictureBox2.Image = new Bitmap(@"\Storage Card\Img\" + datos[0] + ".jpg");
                }
                catch (Exception ex) {
                   
                    this.pictureBox2.Image = new Bitmap(@"/noDisponible.jpg");
                }
            
        }



        }


        private bool okButton = false;

        public bool OKButtonClicked
        {
            get { return okButton; }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            okButton = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            okButton = false;
            this.Close();
        }

        
    }
}