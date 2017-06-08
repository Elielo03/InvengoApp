namespace Invengo.Sample
{
    partial class FrRfidModule
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
            this.rbInternal = new System.Windows.Forms.RadioButton();
            this.rbExtern = new System.Windows.Forms.RadioButton();
            this.btok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbInternal
            // 
            this.rbInternal.Checked = true;
            this.rbInternal.Location = new System.Drawing.Point(22, 20);
            this.rbInternal.Name = "rbInternal";
            this.rbInternal.Size = new System.Drawing.Size(100, 20);
            this.rbInternal.TabIndex = 0;
            this.rbInternal.Text = "Internal";
            // 
            // rbExtern
            // 
            this.rbExtern.Location = new System.Drawing.Point(22, 59);
            this.rbExtern.Name = "rbExtern";
            this.rbExtern.Size = new System.Drawing.Size(100, 20);
            this.rbExtern.TabIndex = 1;
            this.rbExtern.TabStop = false;
            this.rbExtern.Text = "Extern";
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(12, 97);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(131, 35);
            this.btok.TabIndex = 2;
            this.btok.Text = "OK";
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // FrRfidModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(159, 163);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.rbExtern);
            this.Controls.Add(this.rbInternal);
            this.Location = new System.Drawing.Point(40, 60);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrRfidModule";
            this.Text = "Rfid Module";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbInternal;
        private System.Windows.Forms.RadioButton rbExtern;
        private System.Windows.Forms.Button btok;
    }
}