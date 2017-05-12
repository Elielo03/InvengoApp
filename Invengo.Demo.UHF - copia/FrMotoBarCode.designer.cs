namespace Invengo.Sample
{
    partial class FrMotoBarCode
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
            this.btclear = new System.Windows.Forms.Button();
            this.lvCodes = new System.Windows.Forms.ListView();
            this.chCode = new System.Windows.Forms.ColumnHeader();
            this.chCount = new System.Windows.Forms.ColumnHeader();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btscan = new System.Windows.Forms.Button();
            this.trigPull = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btclear
            // 
            this.btclear.BackColor = System.Drawing.SystemColors.Desktop;
            this.btclear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btclear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btclear.Location = new System.Drawing.Point(82, 226);
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(75, 22);
            this.btclear.TabIndex = 62;
            this.btclear.Text = "Clear";
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // lvCodes
            // 
            this.lvCodes.Columns.Add(this.chCode);
            this.lvCodes.Columns.Add(this.chCount);
            this.lvCodes.FullRowSelect = true;
            this.lvCodes.Location = new System.Drawing.Point(-2, 3);
            this.lvCodes.Name = "lvCodes";
            this.lvCodes.Size = new System.Drawing.Size(240, 217);
            this.lvCodes.TabIndex = 61;
            this.lvCodes.View = System.Windows.Forms.View.Details;
            // 
            // chCode
            // 
            this.chCode.Text = "data";
            this.chCode.Width = 160;
            // 
            // chCount
            // 
            this.chCount.Text = "times";
            this.chCount.Width = 50;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(3, 251);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(227, 20);
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(59, 271);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(59, 20);
            this.lblCount.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.Text = "amount";
            // 
            // btscan
            // 
            this.btscan.BackColor = System.Drawing.SystemColors.Desktop;
            this.btscan.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btscan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btscan.Location = new System.Drawing.Point(163, 226);
            this.btscan.Name = "btscan";
            this.btscan.Size = new System.Drawing.Size(75, 22);
            this.btscan.TabIndex = 60;
            this.btscan.Tag = "start";
            this.btscan.Text = "Scan";
            this.btscan.Click += new System.EventHandler(this.btscan_Click);
            // 
            // trigPull
            // 
            this.trigPull.BackColor = System.Drawing.SystemColors.Desktop;
            this.trigPull.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.trigPull.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.trigPull.Location = new System.Drawing.Point(-2, 226);
            this.trigPull.Name = "trigPull";
            this.trigPull.Size = new System.Drawing.Size(75, 22);
            this.trigPull.TabIndex = 59;
            this.trigPull.Text = "Single read";
            this.trigPull.Click += new System.EventHandler(this.trigPull_Click);
            // 
            // FrMotoBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btclear);
            this.Controls.Add(this.lvCodes);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btscan);
            this.Controls.Add(this.trigPull);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrMotoBarCode";
            this.Text = "MotoBarCode";
            this.Closed += new System.EventHandler(this.FrBarCode_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrBarCode_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btclear;
        private System.Windows.Forms.ListView lvCodes;
        private System.Windows.Forms.ColumnHeader chCode;
        private System.Windows.Forms.ColumnHeader chCount;
        protected System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btscan;
        public System.Windows.Forms.Button trigPull;
    }
}