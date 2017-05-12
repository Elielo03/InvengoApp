namespace Invengo.Sample
{
    partial class FrScreen
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
            this.tbarscreen = new System.Windows.Forms.TrackBar();
            this.btback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbarscreen
            // 
            this.tbarscreen.Location = new System.Drawing.Point(16, 67);
            this.tbarscreen.Maximum = 6;
            this.tbarscreen.Name = "tbarscreen";
            this.tbarscreen.Size = new System.Drawing.Size(205, 45);
            this.tbarscreen.TabIndex = 1;
            this.tbarscreen.ValueChanged += new System.EventHandler(this.tbarscreen_ValueChanged);
            // 
            // btback
            // 
            this.btback.Location = new System.Drawing.Point(60, 148);
            this.btback.Name = "btback";
            this.btback.Size = new System.Drawing.Size(115, 33);
            this.btback.TabIndex = 4;
            this.btback.Text = "Back";
            this.btback.Click += new System.EventHandler(this.btback_Click);
            // 
            // FrScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btback);
            this.Controls.Add(this.tbarscreen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrScreen";
            this.Text = "Screen Backlight";
            this.Load += new System.EventHandler(this.Frversion_Load);
            this.Closed += new System.EventHandler(this.Frversion_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar tbarscreen;
        private System.Windows.Forms.Button btback;
    }
}