namespace Invengo.Sample
{
    partial class FrReadSet
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
            this.lbreadcount = new System.Windows.Forms.Label();
            this.tvQValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvScanInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tvDefaultTidLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCharMode = new System.Windows.Forms.ComboBox();
            this.chkRssi = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbreadcount
            // 
            this.lbreadcount.Location = new System.Drawing.Point(15, 19);
            this.lbreadcount.Name = "lbreadcount";
            this.lbreadcount.Size = new System.Drawing.Size(86, 20);
            this.lbreadcount.Text = "Read Count";
            // 
            // tvQValue
            // 
            this.tvQValue.Location = new System.Drawing.Point(102, 19);
            this.tvQValue.Name = "tvQValue";
            this.tvQValue.Size = new System.Drawing.Size(68, 23);
            this.tvQValue.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.Text = "Read Interval";
            // 
            // tvScanInterval
            // 
            this.tvScanInterval.Location = new System.Drawing.Point(101, 55);
            this.tvScanInterval.Name = "tvScanInterval";
            this.tvScanInterval.Size = new System.Drawing.Size(69, 23);
            this.tvScanInterval.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.Text = "TID Length";
            // 
            // tvDefaultTidLength
            // 
            this.tvDefaultTidLength.Location = new System.Drawing.Point(101, 91);
            this.tvDefaultTidLength.Name = "tvDefaultTidLength";
            this.tvDefaultTidLength.Size = new System.Drawing.Size(69, 23);
            this.tvDefaultTidLength.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.Text = "RFID Module";
            // 
            // chkCharMode
            // 
            this.chkCharMode.Items.Add("Internal");
            this.chkCharMode.Items.Add("Extern");
            this.chkCharMode.Location = new System.Drawing.Point(101, 139);
            this.chkCharMode.Name = "chkCharMode";
            this.chkCharMode.Size = new System.Drawing.Size(100, 23);
            this.chkCharMode.TabIndex = 10;
            this.chkCharMode.SelectedIndexChanged += new System.EventHandler(this.chkCharMode_SelectedIndexChanged);
            // 
            // chkRssi
            // 
            this.chkRssi.Location = new System.Drawing.Point(15, 180);
            this.chkRssi.Name = "chkRssi";
            this.chkRssi.Size = new System.Drawing.Size(100, 20);
            this.chkRssi.TabIndex = 11;
            this.chkRssi.Text = "Rssi";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(15, 203);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(202, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(176, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.Text = "*10(ms)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(176, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.Text = "(Byte)";
            // 
            // FrReadSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkRssi);
            this.Controls.Add(this.chkCharMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tvDefaultTidLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvScanInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvQValue);
            this.Controls.Add(this.lbreadcount);
            this.Name = "FrReadSet";
            this.Text = "Read Set";
            this.Load += new System.EventHandler(this.FrReadSet_Load);
            this.Closed += new System.EventHandler(this.FrReadSet_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbreadcount;
        private System.Windows.Forms.TextBox tvQValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvScanInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tvDefaultTidLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox chkCharMode;
        private System.Windows.Forms.CheckBox chkRssi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}