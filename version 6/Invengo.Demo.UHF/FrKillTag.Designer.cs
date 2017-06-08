namespace Invengo.Demo.UHF
{
    partial class FrKillTag
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
            this.lbepc = new System.Windows.Forms.Label();
            this.cbTargetTag = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tvKillPwd = new System.Windows.Forms.TextBox();
            this.btkill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbepc
            // 
            this.lbepc.Location = new System.Drawing.Point(3, 9);
            this.lbepc.Name = "lbepc";
            this.lbepc.Size = new System.Drawing.Size(97, 20);
            this.lbepc.Text = "The Tag EPC:";
            // 
            // cbTargetTag
            // 
            this.cbTargetTag.Location = new System.Drawing.Point(3, 32);
            this.cbTargetTag.Name = "cbTargetTag";
            this.cbTargetTag.Size = new System.Drawing.Size(232, 23);
            this.cbTargetTag.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(3, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(219, 20);
            // 
            // tvKillPwd
            // 
            this.tvKillPwd.Location = new System.Drawing.Point(3, 98);
            this.tvKillPwd.Name = "tvKillPwd";
            this.tvKillPwd.Size = new System.Drawing.Size(118, 23);
            this.tvKillPwd.TabIndex = 3;
            this.tvKillPwd.Text = "00000000";
            // 
            // btkill
            // 
            this.btkill.Location = new System.Drawing.Point(163, 191);
            this.btkill.Name = "btkill";
            this.btkill.Size = new System.Drawing.Size(72, 30);
            this.btkill.TabIndex = 4;
            this.btkill.Text = "Kill ";
            this.btkill.Click += new System.EventHandler(this.btkill_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.Text = "The Kill PassWord:";
            // 
            // btread
            // 
            this.btread.Location = new System.Drawing.Point(3, 191);
            this.btread.Name = "btread";
            this.btread.Size = new System.Drawing.Size(72, 30);
            this.btread.TabIndex = 6;
            this.btread.Text = "Read";
            this.btread.Click += new System.EventHandler(this.btread_Click);
            // 
            // FrKillTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btread);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btkill);
            this.Controls.Add(this.tvKillPwd);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbTargetTag);
            this.Controls.Add(this.lbepc);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrKillTag";
            this.Text = "Kill Tag";
            this.Load += new System.EventHandler(this.FrKillTag_Load);
            this.Closed += new System.EventHandler(this.FrKillTag_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbepc;
        private System.Windows.Forms.ComboBox cbTargetTag;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox tvKillPwd;
        private System.Windows.Forms.Button btkill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btread;

    }
}