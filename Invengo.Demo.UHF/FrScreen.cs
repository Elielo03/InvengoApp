using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Platform;

namespace Invengo.Sample
{
    public partial class FrScreen : Form
    {
       
        public FrScreen()
        {
            InitializeComponent();

             Get();
        }

        private void Frversion_Load(object sender, EventArgs e)
        {
  

           
        }

       
     
        private void Frversion_Closed(object sender, EventArgs e)
        {
            
        }
       
        /// <summary>
        /// Set Screen Backlight
        /// </summary>
        /// <param name="offset"></param>
        public void Set(uint offset)
        {
          

            uint val = 170 * offset;
            if (offset == 0)
            {
                val = 20;
            }
            bool ret;
            if (Config.IsXC2903())
            {
                ret = ScreenBrightness.SetScreenBacklight_2903(val);
            }
            else
            {
                ret = ScreenBrightness.SetScreenBacklight(val);
            }

        }

        /// <summary>
        /// Get Screen Backlight
        /// </summary>
        public void Get()
        {
            int val = 0;
            if (Config.IsXC2903())
            {
                val = ScreenBrightness.GetScreenBacklight_2903();
            }
            else
            {
                val = ScreenBrightness.GetScreenBacklight();
            }
            if (val < 170)
            {
                val = 170;
            }
  
            tbarscreen.Value = (int)val*6 / 1000;
            tbarscreen.Update();
        }

        private void tbarscreen_ValueChanged(object sender, EventArgs e)
        {
            uint val = (uint)tbarscreen.Value;
            Set(val);
        }

        private void btback_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}