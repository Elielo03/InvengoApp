namespace Invengo.Sample
{
    partial class FrMenu
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
            this.btpda = new System.Windows.Forms.Button();
            this.bttag = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btpda
            // 
            this.btpda.BackColor = System.Drawing.SystemColors.Desktop;
            this.btpda.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btpda.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btpda.Location = new System.Drawing.Point(43, 58);
            this.btpda.Name = "btpda";
            this.btpda.Size = new System.Drawing.Size(144, 49);
            this.btpda.TabIndex = 3;
            this.btpda.Text = "PDA";
            this.btpda.Click += new System.EventHandler(this.btpda_Click);
            // 
            // bttag
            // 
            this.bttag.BackColor = System.Drawing.SystemColors.Desktop;
            this.bttag.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bttag.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttag.Location = new System.Drawing.Point(42, 3);
            this.bttag.Name = "bttag";
            this.bttag.Size = new System.Drawing.Size(144, 49);
            this.bttag.TabIndex = 2;
            this.bttag.Text = "Autobus";
            this.bttag.Click += new System.EventHandler(this.bttag_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Desktop;
            this.button3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(43, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 49);
            this.button3.TabIndex = 6;
            this.button3.Text = "Sync Data";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Desktop;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(42, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "Comedor";
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // FrMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btpda);
            this.Controls.Add(this.bttag);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btpda;
        private System.Windows.Forms.Button bttag;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}