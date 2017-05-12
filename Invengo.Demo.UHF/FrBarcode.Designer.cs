namespace Invengo.Sample
{
    partial class FrBarcode
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
            this.btScan = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btback = new System.Windows.Forms.Button();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.lbtype = new System.Windows.Forms.Label();
            this.lvCodes = new System.Windows.Forms.ListView();
            this.chNO = new System.Windows.Forms.ColumnHeader();
            this.chCount = new System.Windows.Forms.ColumnHeader();
            this.chCode = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btScan
            // 
            this.btScan.Location = new System.Drawing.Point(13, 231);
            this.btScan.Name = "btScan";
            this.btScan.Size = new System.Drawing.Size(100, 29);
            this.btScan.TabIndex = 0;
            this.btScan.Tag = "start";
            this.btScan.Text = "Read";
            this.btScan.Click += new System.EventHandler(this.btScan_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(13, 208);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 20);
            // 
            // btback
            // 
            this.btback.Location = new System.Drawing.Point(129, 231);
            this.btback.Name = "btback";
            this.btback.Size = new System.Drawing.Size(100, 29);
            this.btback.TabIndex = 2;
            this.btback.Text = "Back";
            this.btback.Click += new System.EventHandler(this.btback_Click);
            // 
            // cbtype
            // 
            this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbtype.Items.Add("Honeywell2d");
            this.cbtype.Items.Add("Honeywell1d");
            this.cbtype.Items.Add("Symbol");
            this.cbtype.Location = new System.Drawing.Point(102, 6);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(127, 23);
            this.cbtype.TabIndex = 4;
            this.cbtype.Text = "Honeywell2d";
            this.cbtype.SelectedIndexChanged += new System.EventHandler(this.cbtype_SelectedIndexChanged);
            // 
            // lbtype
            // 
            this.lbtype.Location = new System.Drawing.Point(3, 6);
            this.lbtype.Name = "lbtype";
            this.lbtype.Size = new System.Drawing.Size(93, 26);
            this.lbtype.Text = "Barcode Type:";
            // 
            // lvCodes
            // 
            this.lvCodes.Columns.Add(this.chNO);
            this.lvCodes.Columns.Add(this.chCount);
            this.lvCodes.Columns.Add(this.chCode);
            this.lvCodes.FullRowSelect = true;
            this.lvCodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCodes.Location = new System.Drawing.Point(3, 35);
            this.lvCodes.Name = "lvCodes";
            this.lvCodes.Size = new System.Drawing.Size(232, 191);
            this.lvCodes.TabIndex = 24;
            this.lvCodes.View = System.Windows.Forms.View.Details;
            // 
            // chNO
            // 
            this.chNO.Text = "NO.";
            this.chNO.Width = 34;
            // 
            // chCount
            // 
            this.chCount.Text = "Count";
            this.chCount.Width = 48;
            // 
            // chCode
            // 
            this.chCode.Text = "Code";
            this.chCode.Width = 170;
            // 
            // FrBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.lvCodes);
            this.Controls.Add(this.lbtype);
            this.Controls.Add(this.cbtype);
            this.Controls.Add(this.btback);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrBarcode";
            this.Text = "Barcode";
            this.Load += new System.EventHandler(this.FrBarcode_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrBarcode_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btScan;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btback;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label lbtype;
        protected System.Windows.Forms.ListView lvCodes;
        private System.Windows.Forms.ColumnHeader chNO;
        private System.Windows.Forms.ColumnHeader chCount;
        private System.Windows.Forms.ColumnHeader chCode;
    }
}