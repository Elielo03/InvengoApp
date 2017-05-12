using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Invengo.Sample
{
    public partial class FrTestKey : Form
    {
        public FrTestKey()
        {
            InitializeComponent();
        }

        private void FrTestKey_KeyDown(object sender, KeyEventArgs e)
        {
            this.listboxkey.Items.Add(e.KeyValue.ToString());
            if (listboxkey.Items.Count > 0)
            {
                listboxkey.SelectedIndex = listboxkey.Items.Count-1;
            }
         
        }

        private void btback_Click(object sender, EventArgs e)
        {
          
            Close();
        }

      

        private void FrTestKey_Load(object sender, EventArgs e)
        {

        }

        private void btclear_Click(object sender, EventArgs e)
        {
            this.listboxkey.Items.Clear();
        }
    }
}