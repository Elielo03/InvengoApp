namespace Invengo.Demo.UHF
{
    partial class FrFrequency
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
            this.lbfrequency = new System.Windows.Forms.ListBox();
            this.btleft = new System.Windows.Forms.Button();
            this.btright = new System.Windows.Forms.Button();
            this.btallleft = new System.Windows.Forms.Button();
            this.btallrigth = new System.Windows.Forms.Button();
            this.lbdisplay = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btsearch = new System.Windows.Forms.Button();
            this.btset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbfrequency
            // 
            this.lbfrequency.Location = new System.Drawing.Point(6, 0);
            this.lbfrequency.Name = "lbfrequency";
            this.lbfrequency.Size = new System.Drawing.Size(80, 194);
            this.lbfrequency.TabIndex = 0;
            // 
            // btleft
            // 
            this.btleft.Location = new System.Drawing.Point(92, 11);
            this.btleft.Name = "btleft";
            this.btleft.Size = new System.Drawing.Size(53, 29);
            this.btleft.TabIndex = 1;
            this.btleft.Text = ">";
            this.btleft.Click += new System.EventHandler(this.btleft_Click);
            // 
            // btright
            // 
            this.btright.Location = new System.Drawing.Point(92, 58);
            this.btright.Name = "btright";
            this.btright.Size = new System.Drawing.Size(53, 29);
            this.btright.TabIndex = 2;
            this.btright.Text = "<";
            this.btright.Click += new System.EventHandler(this.btright_Click);
            // 
            // btallleft
            // 
            this.btallleft.Location = new System.Drawing.Point(92, 107);
            this.btallleft.Name = "btallleft";
            this.btallleft.Size = new System.Drawing.Size(53, 29);
            this.btallleft.TabIndex = 3;
            this.btallleft.Text = ">>";
            this.btallleft.Click += new System.EventHandler(this.btallleft_Click);
            // 
            // btallrigth
            // 
            this.btallrigth.Location = new System.Drawing.Point(92, 158);
            this.btallrigth.Name = "btallrigth";
            this.btallrigth.Size = new System.Drawing.Size(53, 29);
            this.btallrigth.TabIndex = 4;
            this.btallrigth.Text = "<<";
            this.btallrigth.Click += new System.EventHandler(this.btallrigth_Click);
            // 
            // lbdisplay
            // 
            this.lbdisplay.Location = new System.Drawing.Point(155, 0);
            this.lbdisplay.Name = "lbdisplay";
            this.lbdisplay.Size = new System.Drawing.Size(80, 194);
            this.lbdisplay.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(16, 206);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(210, 20);
            // 
            // btsearch
            // 
            this.btsearch.Location = new System.Drawing.Point(16, 238);
            this.btsearch.Name = "btsearch";
            this.btsearch.Size = new System.Drawing.Size(79, 28);
            this.btsearch.TabIndex = 7;
            this.btsearch.Text = "Query";
            this.btsearch.Click += new System.EventHandler(this.btsearch_Click);
            // 
            // btset
            // 
            this.btset.Location = new System.Drawing.Point(122, 238);
            this.btset.Name = "btset";
            this.btset.Size = new System.Drawing.Size(79, 28);
            this.btset.TabIndex = 9;
            this.btset.Text = "Set";
            this.btset.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrFrequency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btset);
            this.Controls.Add(this.btsearch);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lbdisplay);
            this.Controls.Add(this.btallrigth);
            this.Controls.Add(this.btallleft);
            this.Controls.Add(this.btright);
            this.Controls.Add(this.btleft);
            this.Controls.Add(this.lbfrequency);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrFrequency";
            this.Text = "Frequency";
            this.Load += new System.EventHandler(this.FrFrequency_Load);
            this.Closed += new System.EventHandler(this.FrFrequency_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbfrequency;
        private System.Windows.Forms.Button btleft;
        private System.Windows.Forms.Button btright;
        private System.Windows.Forms.Button btallleft;
        private System.Windows.Forms.Button btallrigth;
        private System.Windows.Forms.ListBox lbdisplay;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btsearch;
        private System.Windows.Forms.Button btset;
    }
}