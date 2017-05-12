namespace Invengo.Sample
{
    partial class FrAntennaPower
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
            this.lbpower = new System.Windows.Forms.Label();
            this.cbdbm = new System.Windows.Forms.ComboBox();
            this.btsearch = new System.Windows.Forms.Button();
            this.btset = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbpower
            // 
            this.lbpower.Location = new System.Drawing.Point(23, 59);
            this.lbpower.Name = "lbpower";
            this.lbpower.Size = new System.Drawing.Size(80, 20);
            this.lbpower.Text = "Power(dbm)";
            // 
            // cbdbm
            // 
            this.cbdbm.Location = new System.Drawing.Point(109, 59);
            this.cbdbm.Name = "cbdbm";
            this.cbdbm.Size = new System.Drawing.Size(100, 23);
            this.cbdbm.TabIndex = 1;
            // 
            // btsearch
            // 
            this.btsearch.BackColor = System.Drawing.SystemColors.Desktop;
            this.btsearch.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btsearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btsearch.Location = new System.Drawing.Point(23, 151);
            this.btsearch.Name = "btsearch";
            this.btsearch.Size = new System.Drawing.Size(80, 31);
            this.btsearch.TabIndex = 2;
            this.btsearch.Text = "Query";
            this.btsearch.Click += new System.EventHandler(this.btsearch_Click);
            // 
            // btset
            // 
            this.btset.BackColor = System.Drawing.SystemColors.Desktop;
            this.btset.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btset.Location = new System.Drawing.Point(129, 151);
            this.btset.Name = "btset";
            this.btset.Size = new System.Drawing.Size(80, 31);
            this.btset.TabIndex = 3;
            this.btset.Text = "Set";
            this.btset.Click += new System.EventHandler(this.btset_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(23, 104);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(186, 20);
            // 
            // FrAntennaPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btset);
            this.Controls.Add(this.btsearch);
            this.Controls.Add(this.cbdbm);
            this.Controls.Add(this.lbpower);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrAntennaPower";
            this.Text = "AntennaPower";
            this.Load += new System.EventHandler(this.FrFrequency_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbpower;
        private System.Windows.Forms.ComboBox cbdbm;
        private System.Windows.Forms.Button btsearch;
        private System.Windows.Forms.Button btset;
        private System.Windows.Forms.Label lblStatus;
    }
}