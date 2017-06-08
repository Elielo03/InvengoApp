namespace Invengo.Demo.UHF
{
    partial class FrConfig
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
            this.cbTargetTag = new System.Windows.Forms.ComboBox();
            this.lboldpwd = new System.Windows.Forms.Label();
            this.tvOriAccessPwd = new System.Windows.Forms.TextBox();
            this.rbNewAccessPassword = new System.Windows.Forms.RadioButton();
            this.tvNewAccessPwd = new System.Windows.Forms.TextBox();
            this.rbKillPwd = new System.Windows.Forms.RadioButton();
            this.tvKillPwd = new System.Windows.Forms.TextBox();
            this.rbTagLock = new System.Windows.Forms.RadioButton();
            this.btread = new System.Windows.Forms.Button();
            this.btset = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbLockOperate = new System.Windows.Forms.ComboBox();
            this.cbLockArea = new System.Windows.Forms.ComboBox();
            this.panelLock = new System.Windows.Forms.Panel();
            this.panelLock.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTargetTag
            // 
            this.cbTargetTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbTargetTag.Location = new System.Drawing.Point(5, 13);
            this.cbTargetTag.Name = "cbTargetTag";
            this.cbTargetTag.Size = new System.Drawing.Size(230, 23);
            this.cbTargetTag.TabIndex = 17;
            // 
            // lboldpwd
            // 
            this.lboldpwd.Location = new System.Drawing.Point(5, 49);
            this.lboldpwd.Name = "lboldpwd";
            this.lboldpwd.Size = new System.Drawing.Size(116, 20);
            this.lboldpwd.Text = "Access PassWord";
            // 
            // tvOriAccessPwd
            // 
            this.tvOriAccessPwd.Location = new System.Drawing.Point(138, 46);
            this.tvOriAccessPwd.Name = "tvOriAccessPwd";
            this.tvOriAccessPwd.Size = new System.Drawing.Size(97, 23);
            this.tvOriAccessPwd.TabIndex = 19;
            this.tvOriAccessPwd.Text = "00000000";
            // 
            // rbNewAccessPassword
            // 
            this.rbNewAccessPassword.Checked = true;
            this.rbNewAccessPassword.Location = new System.Drawing.Point(5, 85);
            this.rbNewAccessPassword.Name = "rbNewAccessPassword";
            this.rbNewAccessPassword.Size = new System.Drawing.Size(116, 20);
            this.rbNewAccessPassword.TabIndex = 22;
            this.rbNewAccessPassword.Text = "New PassWord";
            this.rbNewAccessPassword.CheckedChanged += new System.EventHandler(this.rbNewAccessPassword_CheckedChanged);
            // 
            // tvNewAccessPwd
            // 
            this.tvNewAccessPwd.Location = new System.Drawing.Point(138, 85);
            this.tvNewAccessPwd.Name = "tvNewAccessPwd";
            this.tvNewAccessPwd.Size = new System.Drawing.Size(97, 23);
            this.tvNewAccessPwd.TabIndex = 23;
            this.tvNewAccessPwd.Text = "00000000";
            // 
            // rbKillPwd
            // 
            this.rbKillPwd.Location = new System.Drawing.Point(5, 114);
            this.rbKillPwd.Name = "rbKillPwd";
            this.rbKillPwd.Size = new System.Drawing.Size(116, 20);
            this.rbKillPwd.TabIndex = 24;
            this.rbKillPwd.Text = "Kill PassWord";
            this.rbKillPwd.CheckedChanged += new System.EventHandler(this.rbKillPwd_CheckedChanged);
            // 
            // tvKillPwd
            // 
            this.tvKillPwd.Enabled = false;
            this.tvKillPwd.Location = new System.Drawing.Point(138, 114);
            this.tvKillPwd.Name = "tvKillPwd";
            this.tvKillPwd.Size = new System.Drawing.Size(97, 23);
            this.tvKillPwd.TabIndex = 25;
            // 
            // rbTagLock
            // 
            this.rbTagLock.Location = new System.Drawing.Point(5, 140);
            this.rbTagLock.Name = "rbTagLock";
            this.rbTagLock.Size = new System.Drawing.Size(116, 20);
            this.rbTagLock.TabIndex = 26;
            this.rbTagLock.Text = "Lock/UnLock";
            this.rbTagLock.CheckedChanged += new System.EventHandler(this.rbTagLock_CheckedChanged);
            // 
            // btread
            // 
            this.btread.Location = new System.Drawing.Point(5, 235);
            this.btread.Name = "btread";
            this.btread.Size = new System.Drawing.Size(81, 28);
            this.btread.TabIndex = 29;
            this.btread.Text = "Read";
            this.btread.Click += new System.EventHandler(this.btread_Click);
            // 
            // btset
            // 
            this.btset.Location = new System.Drawing.Point(154, 235);
            this.btset.Name = "btset";
            this.btset.Size = new System.Drawing.Size(81, 28);
            this.btset.TabIndex = 30;
            this.btset.Text = "Set";
            this.btset.Click += new System.EventHandler(this.btset_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(5, 201);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(218, 20);
            // 
            // cbLockOperate
            // 
            this.cbLockOperate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbLockOperate.Items.Add("Lock Tag");
            this.cbLockOperate.Items.Add("UnLock Tag");
            this.cbLockOperate.Location = new System.Drawing.Point(3, 8);
            this.cbLockOperate.Name = "cbLockOperate";
            this.cbLockOperate.Size = new System.Drawing.Size(100, 23);
            this.cbLockOperate.TabIndex = 27;
            this.cbLockOperate.Text = "Lock Tag";
            // 
            // cbLockArea
            // 
            this.cbLockArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbLockArea.Items.Add("All Area");
            this.cbLockArea.Items.Add("TID");
            this.cbLockArea.Items.Add("EPC");
            this.cbLockArea.Items.Add("UserData");
            this.cbLockArea.Items.Add("Access PassWord");
            this.cbLockArea.Items.Add("Kill PassWord");
            this.cbLockArea.Location = new System.Drawing.Point(111, 8);
            this.cbLockArea.Name = "cbLockArea";
            this.cbLockArea.Size = new System.Drawing.Size(124, 23);
            this.cbLockArea.TabIndex = 28;
            this.cbLockArea.Text = "All Area";
            // 
            // panelLock
            // 
            this.panelLock.Controls.Add(this.cbLockArea);
            this.panelLock.Controls.Add(this.cbLockOperate);
            this.panelLock.Enabled = false;
            this.panelLock.Location = new System.Drawing.Point(0, 158);
            this.panelLock.Name = "panelLock";
            this.panelLock.Size = new System.Drawing.Size(235, 40);
            // 
            // FrConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btset);
            this.Controls.Add(this.btread);
            this.Controls.Add(this.rbTagLock);
            this.Controls.Add(this.tvKillPwd);
            this.Controls.Add(this.rbKillPwd);
            this.Controls.Add(this.tvNewAccessPwd);
            this.Controls.Add(this.rbNewAccessPassword);
            this.Controls.Add(this.tvOriAccessPwd);
            this.Controls.Add(this.lboldpwd);
            this.Controls.Add(this.cbTargetTag);
            this.Controls.Add(this.panelLock);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrConfig";
            this.Text = "Tag Set";
            this.Load += new System.EventHandler(this.FrConfig_Load);
            this.Closed += new System.EventHandler(this.FrConfig_Closed);
            this.panelLock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTargetTag;
        private System.Windows.Forms.Label lboldpwd;
        private System.Windows.Forms.TextBox tvOriAccessPwd;
        private System.Windows.Forms.RadioButton rbNewAccessPassword;
        private System.Windows.Forms.TextBox tvNewAccessPwd;
        private System.Windows.Forms.RadioButton rbKillPwd;
        private System.Windows.Forms.TextBox tvKillPwd;
        private System.Windows.Forms.RadioButton rbTagLock;
        private System.Windows.Forms.Button btread;
        private System.Windows.Forms.Button btset;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbLockOperate;
        private System.Windows.Forms.ComboBox cbLockArea;
        private System.Windows.Forms.Panel panelLock;
    }
}