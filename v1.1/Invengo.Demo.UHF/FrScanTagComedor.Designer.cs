namespace Invengo.Sample
{
    partial class FrScanTagComedor
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
            this.ibScan = new System.Windows.Forms.Button();
            this.lvCodes = new System.Windows.Forms.ListView();
            this.chCount = new System.Windows.Forms.ColumnHeader();
            this.chtid = new System.Windows.Forms.ColumnHeader();
            this.chepc = new System.Windows.Forms.ColumnHeader();
            this.chuserdata = new System.Windows.Forms.ColumnHeader();
            this.chrssi = new System.Windows.Forms.ColumnHeader();
            this.btClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbRfidType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtqvalue = new System.Windows.Forms.TextBox();
            this.cbDataArea = new System.Windows.Forms.ComboBox();
            this.cbsingle = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.button1 = new System.Windows.Forms.Button();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // ibScan
            // 
            this.ibScan.BackColor = System.Drawing.SystemColors.Desktop;
            this.ibScan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ibScan.Location = new System.Drawing.Point(83, 269);
            this.ibScan.Name = "ibScan";
            this.ibScan.Size = new System.Drawing.Size(70, 25);
            this.ibScan.TabIndex = 13;
            this.ibScan.Tag = "Start";
            this.ibScan.Text = "Scan";
            this.ibScan.Click += new System.EventHandler(this.btRead_Click);
            // 
            // lvCodes
            // 
            this.lvCodes.Columns.Add(this.chCount);
            this.lvCodes.Columns.Add(this.chtid);
            this.lvCodes.Columns.Add(this.columnHeader1);
            this.lvCodes.Columns.Add(this.chepc);
            this.lvCodes.Columns.Add(this.chuserdata);
            this.lvCodes.Columns.Add(this.chrssi);
            this.lvCodes.FullRowSelect = true;
            this.lvCodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCodes.Location = new System.Drawing.Point(0, 32);
            this.lvCodes.Name = "lvCodes";
            this.lvCodes.Size = new System.Drawing.Size(238, 191);
            this.lvCodes.TabIndex = 23;
            this.lvCodes.View = System.Windows.Forms.View.Details;
            this.lvCodes.SelectedIndexChanged += new System.EventHandler(this.lvCodes_SelectedIndexChanged);
            // 
            // chCount
            // 
            this.chCount.Text = "Count";
            this.chCount.Width = 50;
            // 
            // chtid
            // 
            this.chtid.Text = "TID/ID";
            this.chtid.Width = 200;
            // 
            // chepc
            // 
            this.chepc.Text = "EPC";
            this.chepc.Width = 200;
            // 
            // chuserdata
            // 
            this.chuserdata.Text = "USERDATA";
            this.chuserdata.Width = 200;
            // 
            // chrssi
            // 
            this.chrssi.Text = "RSSI";
            this.chrssi.Width = 60;
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.SystemColors.Desktop;
            this.btClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btClear.Location = new System.Drawing.Point(0, 269);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(70, 26);
            this.btClear.TabIndex = 14;
            this.btClear.Tag = "";
            this.btClear.Text = "Limpiar";
            this.btClear.Click += new System.EventHandler(this.btClear_Click_1);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(-3, 226);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(238, 20);
            // 
            // cbRfidType
            // 
            this.cbRfidType.Enabled = false;
            this.cbRfidType.Items.Add("6C");
            this.cbRfidType.Items.Add("6B");
            this.cbRfidType.Items.Add("6C/6B");
            this.cbRfidType.Location = new System.Drawing.Point(69, 3);
            this.cbRfidType.Name = "cbRfidType";
            this.cbRfidType.Size = new System.Drawing.Size(166, 23);
            this.cbRfidType.TabIndex = 24;
            this.cbRfidType.Visible = false;
            this.cbRfidType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.Text = "Tipo Tag ";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.Text = "Area";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.Text = "Q Value";
            this.label3.Visible = false;
            // 
            // txtqvalue
            // 
            this.txtqvalue.Location = new System.Drawing.Point(69, 55);
            this.txtqvalue.MaxLength = 2;
            this.txtqvalue.Name = "txtqvalue";
            this.txtqvalue.ReadOnly = true;
            this.txtqvalue.Size = new System.Drawing.Size(50, 23);
            this.txtqvalue.TabIndex = 30;
            this.txtqvalue.Text = "3";
            this.txtqvalue.Visible = false;
            // 
            // cbDataArea
            // 
            this.cbDataArea.Enabled = false;
            this.cbDataArea.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.cbDataArea.Location = new System.Drawing.Point(69, 28);
            this.cbDataArea.Name = "cbDataArea";
            this.cbDataArea.Size = new System.Drawing.Size(166, 24);
            this.cbDataArea.TabIndex = 36;
            this.cbDataArea.Visible = false;
            this.cbDataArea.SelectedIndexChanged += new System.EventHandler(this.cbDataArea_SelectedIndexChanged);
            // 
            // cbsingle
            // 
            this.cbsingle.Location = new System.Drawing.Point(207, 58);
            this.cbsingle.Name = "cbsingle";
            this.cbsingle.Size = new System.Drawing.Size(28, 20);
            this.cbsingle.TabIndex = 41;
            this.cbsingle.Visible = false;
            this.cbsingle.CheckStateChanged += new System.EventHandler(this.cbsingle_CheckStateChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(132, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.Text = "Single Scan";
            this.label4.Visible = false;
            // 
            // lblStat
            // 
            this.lblStat.Location = new System.Drawing.Point(0, 246);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(238, 20);
            this.lblStat.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Desktop;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(159, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 25);
            this.button1.TabIndex = 61;
            this.button1.Tag = "Start";
            this.button1.Text = "Cod. Barra";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 60;
            // 
            // FrScanTagComedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.cbsingle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDataArea);
            this.Controls.Add(this.txtqvalue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRfidType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lvCodes);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.ibScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrScanTagComedor";
            this.Text = "Scan Tag";
            this.Load += new System.EventHandler(this.FrScanTag_Load);
            this.Closed += new System.EventHandler(this.FrScanTag_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ibScan;
        protected System.Windows.Forms.ListView lvCodes;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ColumnHeader chtid;
        private System.Windows.Forms.ComboBox cbRfidType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtqvalue;
        private System.Windows.Forms.ColumnHeader chepc;
        private System.Windows.Forms.ColumnHeader chuserdata;
        private System.Windows.Forms.ColumnHeader chrssi;
        private System.Windows.Forms.ComboBox cbDataArea;
        private System.Windows.Forms.CheckBox cbsingle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader chCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}