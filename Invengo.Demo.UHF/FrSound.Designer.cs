namespace Invengo.Sample
{
    partial class FrSound
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbsound = new System.Windows.Forms.Label();
            this.tbsound = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbsound
            // 
            this.lbsound.Location = new System.Drawing.Point(27, 43);
            this.lbsound.Name = "lbsound";
            this.lbsound.Size = new System.Drawing.Size(184, 20);
            // 
            // tbsound
            // 
            this.tbsound.Location = new System.Drawing.Point(13, 79);
            this.tbsound.Maximum = 6;
            this.tbsound.Name = "tbsound";
            this.tbsound.Size = new System.Drawing.Size(207, 45);
            this.tbsound.TabIndex = 1;
            this.tbsound.ValueChanged += new System.EventHandler(this.tbsound_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbsound);
            this.Controls.Add(this.lbsound);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrSound";
            this.Text = "Sound";
            this.Load += new System.EventHandler(this.SetSound_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbsound;
        private System.Windows.Forms.TrackBar tbsound;
        private System.Windows.Forms.Button button1;
    }
}