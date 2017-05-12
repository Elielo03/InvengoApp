using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Audio;

namespace Invengo.Sample
{
    public partial class FrSound : Form
    {
        string SoundOK = @"\Windows\startup.wav";

        public FrSound()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set Sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbsound_ValueChanged(object sender, EventArgs e)
        {
            uint oriVolume = (uint)(0xFFFF * 1.0 * (this.tbsound.Value / 6.0));
             SoundVolume.SetSoundVolume(oriVolume);
             GetSound();
             SoundPlayer.PlayWAV(SoundOK);
        }

        /// <summary>
        /// Sound_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSound_Load(object sender, EventArgs e)
        {
            GetSound();
            uint dwVolume = 0;
            SoundVolume.GetSoundVolume(ref dwVolume);
            int sound = (int)(dwVolume * 6 / 0xFFFF * 1.0);
            if (dwVolume > 0xFFFF)
            {
                sound = (int)(dwVolume * 6 / 0xFFFFFFFF);
            }
            
            this.tbsound.Value = sound;
            
            
        }

        /// <summary>
        /// Get Sound
        /// </summary>
        protected void GetSound()
        {
            uint dwVolume = 0;
            SoundVolume.GetSoundVolume(ref dwVolume); 
            this.lbsound.Text = "The Volume is : "+ dwVolume.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
            this.Close();
        }
       
    }
}