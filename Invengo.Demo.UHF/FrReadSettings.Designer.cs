namespace Invengo.Sample
{
    partial class FrReadSettings
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
            this.chkRssi = new System.Windows.Forms.CheckBox();
            this.tvDefaultTidLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btset = new System.Windows.Forms.Button();
            this.lbmsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tvScanInterval = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkRssi
            // 
            this.chkRssi.Location = new System.Drawing.Point(8, 96);
            this.chkRssi.Name = "chkRssi";
            this.chkRssi.Size = new System.Drawing.Size(100, 20);
            this.chkRssi.TabIndex = 15;
            this.chkRssi.Text = "Rssi";
            this.chkRssi.CheckStateChanged += new System.EventHandler(this.chkRssi_CheckStateChanged);
            // 
            // tvDefaultTidLength
            // 
            this.tvDefaultTidLength.Location = new System.Drawing.Point(117, 20);
            this.tvDefaultTidLength.MaxLength = 2;
            this.tvDefaultTidLength.Name = "tvDefaultTidLength";
            this.tvDefaultTidLength.Size = new System.Drawing.Size(52, 23);
            this.tvDefaultTidLength.TabIndex = 14;
            this.tvDefaultTidLength.Text = "12";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.Text = "TID Length (Byte)";
            // 
            // btset
            // 
            this.btset.BackColor = System.Drawing.SystemColors.Desktop;
            this.btset.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btset.Location = new System.Drawing.Point(117, 188);
            this.btset.Name = "btset";
            this.btset.Size = new System.Drawing.Size(80, 38);
            this.btset.TabIndex = 23;
            this.btset.Text = "OK";
            this.btset.Click += new System.EventHandler(this.btset_Click);
            // 
            // lbmsg
            // 
            this.lbmsg.Location = new System.Drawing.Point(3, 165);
            this.lbmsg.Name = "lbmsg";
            this.lbmsg.Size = new System.Drawing.Size(232, 20);
            this.lbmsg.Text = " ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.Text = "Read interval";
            // 
            // tvScanInterval
            // 
            this.tvScanInterval.Location = new System.Drawing.Point(117, 60);
            this.tvScanInterval.MaxLength = 3;
            this.tvScanInterval.Name = "tvScanInterval";
            this.tvScanInterval.Size = new System.Drawing.Size(52, 23);
            this.tvScanInterval.TabIndex = 27;
            this.tvScanInterval.Text = "30";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(175, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.Text = "* 10(ms)";
            // 
            // FrReadSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tvScanInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbmsg);
            this.Controls.Add(this.btset);
            this.Controls.Add(this.chkRssi);
            this.Controls.Add(this.tvDefaultTidLength);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrReadSettings";
            this.Text = "FrReadSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRssi;
        private System.Windows.Forms.TextBox tvDefaultTidLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btset;
        private System.Windows.Forms.Label lbmsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvScanInterval;
        private System.Windows.Forms.Label label7;
    }
}