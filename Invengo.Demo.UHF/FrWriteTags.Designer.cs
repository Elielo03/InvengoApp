namespace Invengo.Demo.UHF
{
    partial class FrWriteTags
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
            this.btWrite = new System.Windows.Forms.Button();
            this.tvDataMemo = new System.Windows.Forms.TextBox();
            this.rbUserdata = new System.Windows.Forms.RadioButton();
            this.rbEpc = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.tvPassword = new System.Windows.Forms.TextBox();
            this.lbpwd = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btread = new System.Windows.Forms.Button();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.lbtype = new System.Windows.Forms.Label();
            this.cbtid = new System.Windows.Forms.ComboBox();
            this.rbTid = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btWrite
            // 
            this.btWrite.Location = new System.Drawing.Point(90, 214);
            this.btWrite.Name = "btWrite";
            this.btWrite.Size = new System.Drawing.Size(65, 29);
            this.btWrite.TabIndex = 7;
            this.btWrite.Text = "Write";
            this.btWrite.Click += new System.EventHandler(this.btWrite_Click_1);
            // 
            // tvDataMemo
            // 
            this.tvDataMemo.Location = new System.Drawing.Point(3, 113);
            this.tvDataMemo.MaxLength = 200;
            this.tvDataMemo.Multiline = true;
            this.tvDataMemo.Name = "tvDataMemo";
            this.tvDataMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tvDataMemo.Size = new System.Drawing.Size(232, 59);
            this.tvDataMemo.TabIndex = 6;
            // 
            // rbUserdata
            // 
            this.rbUserdata.Location = new System.Drawing.Point(76, 54);
            this.rbUserdata.Name = "rbUserdata";
            this.rbUserdata.Size = new System.Drawing.Size(79, 20);
            this.rbUserdata.TabIndex = 5;
            this.rbUserdata.TabStop = false;
            this.rbUserdata.Text = "userdata";
            // 
            // rbEpc
            // 
            this.rbEpc.Checked = true;
            this.rbEpc.Location = new System.Drawing.Point(6, 54);
            this.rbEpc.Name = "rbEpc";
            this.rbEpc.Size = new System.Drawing.Size(64, 20);
            this.rbEpc.TabIndex = 4;
            this.rbEpc.Text = "EPC";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Back";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tvPassword
            // 
            this.tvPassword.Location = new System.Drawing.Point(93, 178);
            this.tvPassword.Name = "tvPassword";
            this.tvPassword.Size = new System.Drawing.Size(142, 23);
            this.tvPassword.TabIndex = 9;
            this.tvPassword.Text = "00000000";
            // 
            // lbpwd
            // 
            this.lbpwd.Location = new System.Drawing.Point(17, 178);
            this.lbpwd.Name = "lbpwd";
            this.lbpwd.Size = new System.Drawing.Size(70, 22);
            this.lbpwd.Text = "PassWord:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(17, 246);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(204, 20);
            // 
            // btread
            // 
            this.btread.Location = new System.Drawing.Point(3, 214);
            this.btread.Name = "btread";
            this.btread.Size = new System.Drawing.Size(67, 29);
            this.btread.TabIndex = 10;
            this.btread.Text = "Read";
            this.btread.Click += new System.EventHandler(this.btread_Click);
            // 
            // cbtype
            // 
            this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbtype.Items.Add("Default");
            this.cbtype.Items.Add("BlockWrite");
            this.cbtype.Items.Add("BlockErase");
            this.cbtype.Location = new System.Drawing.Point(93, 80);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(142, 23);
            this.cbtype.TabIndex = 13;
            this.cbtype.Text = "Default";
            // 
            // lbtype
            // 
            this.lbtype.Location = new System.Drawing.Point(3, 83);
            this.lbtype.Name = "lbtype";
            this.lbtype.Size = new System.Drawing.Size(90, 20);
            this.lbtype.Text = "Writing Mode:";
            // 
            // cbtid
            // 
            this.cbtid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbtid.Location = new System.Drawing.Point(5, 25);
            this.cbtid.Name = "cbtid";
            this.cbtid.Size = new System.Drawing.Size(230, 23);
            this.cbtid.TabIndex = 16;
            // 
            // rbTid
            // 
            this.rbTid.Location = new System.Drawing.Point(171, 54);
            this.rbTid.Name = "rbTid";
            this.rbTid.Size = new System.Drawing.Size(64, 20);
            this.rbTid.TabIndex = 17;
            this.rbTid.TabStop = false;
            this.rbTid.Text = "TID";
            // 
            // FrWriteTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.rbTid);
            this.Controls.Add(this.cbtid);
            this.Controls.Add(this.lbtype);
            this.Controls.Add(this.cbtype);
            this.Controls.Add(this.btread);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lbpwd);
            this.Controls.Add(this.tvPassword);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btWrite);
            this.Controls.Add(this.tvDataMemo);
            this.Controls.Add(this.rbUserdata);
            this.Controls.Add(this.rbEpc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrWriteTag";
            this.Text = "Write Tag";
            this.Load += new System.EventHandler(this.FrWriteTag_Load);
            this.Closed += new System.EventHandler(this.FrWriteTag_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrWriteTag_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btWrite;
        private System.Windows.Forms.TextBox tvDataMemo;
        private System.Windows.Forms.RadioButton rbUserdata;
        private System.Windows.Forms.RadioButton rbEpc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tvPassword;
        private System.Windows.Forms.Label lbpwd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btread;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label lbtype;
        private System.Windows.Forms.ComboBox cbtid;
        private System.Windows.Forms.RadioButton rbTid;
    }
}