namespace Invengo.Sample
{
    partial class FrWriteTag
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
            this.cbDataArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvLength = new System.Windows.Forms.TextBox();
            this.tvOffsetAddr = new System.Windows.Forms.TextBox();
            this.tvPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tvDataMemo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbTargetTag = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDataArea
            // 
            this.cbDataArea.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.cbDataArea.Location = new System.Drawing.Point(55, 138);
            this.cbDataArea.Name = "cbDataArea";
            this.cbDataArea.Size = new System.Drawing.Size(180, 24);
            this.cbDataArea.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "TID/ID";
            // 
            // tvLength
            // 
            this.tvLength.Location = new System.Drawing.Point(109, 87);
            this.tvLength.MaxLength = 5;
            this.tvLength.Name = "tvLength";
            this.tvLength.Size = new System.Drawing.Size(126, 23);
            this.tvLength.TabIndex = 39;
            this.tvLength.Text = "28";
            // 
            // tvOffsetAddr
            // 
            this.tvOffsetAddr.Location = new System.Drawing.Point(109, 58);
            this.tvOffsetAddr.MaxLength = 5;
            this.tvOffsetAddr.Name = "tvOffsetAddr";
            this.tvOffsetAddr.Size = new System.Drawing.Size(126, 23);
            this.tvOffsetAddr.TabIndex = 40;
            this.tvOffsetAddr.Text = "0";
            // 
            // tvPassword
            // 
            this.tvPassword.Location = new System.Drawing.Point(109, 116);
            this.tvPassword.MaxLength = 8;
            this.tvPassword.Name = "tvPassword";
            this.tvPassword.Size = new System.Drawing.Size(126, 23);
            this.tvPassword.TabIndex = 41;
            this.tvPassword.Text = "00000000";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Offset(byte)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Lenght(bytes)";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Access password";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.Text = "Arase";
            // 
            // tvDataMemo
            // 
            this.tvDataMemo.Location = new System.Drawing.Point(6, 190);
            this.tvDataMemo.MaxLength = 4096;
            this.tvDataMemo.Multiline = true;
            this.tvDataMemo.Name = "tvDataMemo";
            this.tvDataMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tvDataMemo.Size = new System.Drawing.Size(229, 51);
            this.tvDataMemo.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "Data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 26);
            this.button1.TabIndex = 53;
            this.button1.Text = "Write";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbTargetTag
            // 
            this.cbTargetTag.Location = new System.Drawing.Point(0, 21);
            this.cbTargetTag.Name = "cbTargetTag";
            this.cbTargetTag.Size = new System.Drawing.Size(235, 23);
            this.cbTargetTag.TabIndex = 54;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(6, 245);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(232, 20);
            // 
            // btread
            // 
            this.btread.Location = new System.Drawing.Point(6, 265);
            this.btread.Name = "btread";
            this.btread.Size = new System.Drawing.Size(72, 28);
            this.btread.TabIndex = 56;
            this.btread.Text = "Read";
            this.btread.Click += new System.EventHandler(this.btread_Click);
            // 
            // FrWriteTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btread);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbTargetTag);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tvDataMemo);
            this.Controls.Add(this.cbDataArea);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvPassword);
            this.Controls.Add(this.tvOffsetAddr);
            this.Controls.Add(this.tvLength);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrWriteTag";
            this.Text = "FrWriteTag";
            this.Load += new System.EventHandler(this.FrWriteTag_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDataArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvLength;
        private System.Windows.Forms.TextBox tvOffsetAddr;
        private System.Windows.Forms.TextBox tvPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tvDataMemo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbTargetTag;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btread;
    }
}