namespace Invengo.Sample
{
    partial class FrTagMain
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
            this.btscanrfid = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btpower = new System.Windows.Forms.Button();
            this.btreadset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btscanrfid
            // 
            this.btscanrfid.BackColor = System.Drawing.SystemColors.Desktop;
            this.btscanrfid.Enabled = false;
            this.btscanrfid.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btscanrfid.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btscanrfid.Location = new System.Drawing.Point(39, 167);
            this.btscanrfid.Name = "btscanrfid";
            this.btscanrfid.Size = new System.Drawing.Size(148, 40);
            this.btscanrfid.TabIndex = 53;
            this.btscanrfid.Text = "Scan Tag";
            this.btscanrfid.Click += new System.EventHandler(this.btscanrfid_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Desktop;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(39, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 50);
            this.button2.TabIndex = 56;
            this.button2.Text = "Connect";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btpower
            // 
            this.btpower.BackColor = System.Drawing.SystemColors.Desktop;
            this.btpower.Enabled = false;
            this.btpower.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btpower.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btpower.Location = new System.Drawing.Point(39, 39);
            this.btpower.Name = "btpower";
            this.btpower.Size = new System.Drawing.Size(148, 40);
            this.btpower.TabIndex = 55;
            this.btpower.Text = "Antenna Power";
            this.btpower.Visible = false;
            this.btpower.Click += new System.EventHandler(this.btpower_Click_1);
            // 
            // btreadset
            // 
            this.btreadset.BackColor = System.Drawing.SystemColors.Desktop;
            this.btreadset.Enabled = false;
            this.btreadset.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btreadset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btreadset.Location = new System.Drawing.Point(39, 3);
            this.btreadset.Name = "btreadset";
            this.btreadset.Size = new System.Drawing.Size(148, 40);
            this.btreadset.TabIndex = 57;
            this.btreadset.Text = "Read Settings";
            this.btreadset.Visible = false;
            this.btreadset.Click += new System.EventHandler(this.btreadset_Click);
            // 
            // FrTagMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btreadset);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btpower);
            this.Controls.Add(this.btscanrfid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrTagMain";
            this.Text = "Rfid Main";
            this.Load += new System.EventHandler(this.FrTagMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btscanrfid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btpower;
        private System.Windows.Forms.Button btreadset;
    }
}