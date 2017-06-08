namespace Invengo.Sample
{
    partial class FrDemolist
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(3, 113);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(192, 35);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(19, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(98, 20);
            this.rb1.TabIndex = 1;
            this.rb1.Text = "F6C(6C)";
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(19, 77);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(98, 20);
            this.rb3.TabIndex = 3;
            this.rb3.TabStop = false;
            this.rb3.Text = "F6G(6B/6C)";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(19, 44);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(98, 20);
            this.rb2.TabIndex = 2;
            this.rb2.TabStop = false;
            this.rb2.Text = "F6B(6B)";
            // 
            // DemolistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(198, 154);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DemolistForm";
            this.Text = "RFID DEMO";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DemolistForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
    }
}