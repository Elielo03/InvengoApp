namespace Invengo.Sample
{
    partial class FrSysInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrSysInfo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lvInfo = new System.Windows.Forms.ListView();
            this.chname = new System.Windows.Forms.ColumnHeader();
            this.chdescribe = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 57);
            // 
            // lblCopyright
            // 
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCopyright.Location = new System.Drawing.Point(30, 222);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(204, 40);
            this.lblCopyright.Text = "Copyright (C) 2012 Invengo Information Technology Co,Ltd.";
            // 
            // lvInfo
            // 
            this.lvInfo.Columns.Add(this.chname);
            this.lvInfo.Columns.Add(this.chdescribe);
            this.lvInfo.FullRowSelect = true;
            this.lvInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvInfo.Location = new System.Drawing.Point(0, 54);
            this.lvInfo.Name = "lvInfo";
            this.lvInfo.Size = new System.Drawing.Size(238, 150);
            this.lvInfo.TabIndex = 24;
            this.lvInfo.View = System.Windows.Forms.View.Details;
            // 
            // chname
            // 
            this.chname.Text = "Name";
            this.chname.Width = 100;
            // 
            // chdescribe
            // 
            this.chdescribe.Text = "Describe";
            this.chdescribe.Width = 130;
            // 
            // FrSysInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.lvInfo);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrSysInfo";
            this.Text = "SysInfo";
            this.Load += new System.EventHandler(this.FrSysInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCopyright;
        protected System.Windows.Forms.ListView lvInfo;
        private System.Windows.Forms.ColumnHeader chname;
        private System.Windows.Forms.ColumnHeader chdescribe;
    }
}