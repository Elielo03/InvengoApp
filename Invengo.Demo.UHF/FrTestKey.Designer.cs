namespace Invengo.Sample
{
    partial class FrTestKey
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
            this.listboxkey = new System.Windows.Forms.ListBox();
            this.btback = new System.Windows.Forms.Button();
            this.btclear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listboxkey
            // 
            this.listboxkey.Location = new System.Drawing.Point(15, 3);
            this.listboxkey.Name = "listboxkey";
            this.listboxkey.Size = new System.Drawing.Size(202, 178);
            this.listboxkey.TabIndex = 0;
            // 
            // btback
            // 
            this.btback.Location = new System.Drawing.Point(132, 189);
            this.btback.Name = "btback";
            this.btback.Size = new System.Drawing.Size(85, 36);
            this.btback.TabIndex = 1;
            this.btback.Text = "Back";
            this.btback.Click += new System.EventHandler(this.btback_Click);
            // 
            // btclear
            // 
            this.btclear.Location = new System.Drawing.Point(15, 189);
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(85, 36);
            this.btclear.TabIndex = 2;
            this.btclear.Text = "Clear";
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 20);
            this.label1.Text = "Please press the keys !";
            // 
            // FrTestKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btclear);
            this.Controls.Add(this.btback);
            this.Controls.Add(this.listboxkey);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrTestKey";
            this.Text = "Test Key";
            this.Load += new System.EventHandler(this.FrTestKey_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrTestKey_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxkey;
        private System.Windows.Forms.Button btback;
        private System.Windows.Forms.Button btclear;
        private System.Windows.Forms.Label label1;
    }
}