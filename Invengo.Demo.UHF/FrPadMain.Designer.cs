namespace Invengo.Sample
{
    partial class FrPadMain
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
            this.btversion = new System.Windows.Forms.Button();
            this.btsound = new System.Windows.Forms.Button();
            this.btkey = new System.Windows.Forms.Button();
            this.btGPRS = new System.Windows.Forms.Button();
            this.btwifi = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btbattery = new System.Windows.Forms.Button();
            this.btver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btversion
            // 
            this.btversion.BackColor = System.Drawing.SystemColors.Desktop;
            this.btversion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btversion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btversion.Location = new System.Drawing.Point(126, 143);
            this.btversion.Name = "btversion";
            this.btversion.Size = new System.Drawing.Size(100, 31);
            this.btversion.TabIndex = 43;
            this.btversion.Text = "Set Backlight";
            this.btversion.Click += new System.EventHandler(this.btversion_Click);
            // 
            // btsound
            // 
            this.btsound.BackColor = System.Drawing.SystemColors.Desktop;
            this.btsound.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btsound.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btsound.Location = new System.Drawing.Point(9, 143);
            this.btsound.Name = "btsound";
            this.btsound.Size = new System.Drawing.Size(99, 31);
            this.btsound.TabIndex = 42;
            this.btsound.Text = "Set Volume";
            this.btsound.Click += new System.EventHandler(this.btsound_Click);
            // 
            // btkey
            // 
            this.btkey.BackColor = System.Drawing.SystemColors.Desktop;
            this.btkey.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btkey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btkey.Location = new System.Drawing.Point(10, 29);
            this.btkey.Name = "btkey";
            this.btkey.Size = new System.Drawing.Size(216, 31);
            this.btkey.TabIndex = 41;
            this.btkey.Text = "Test Keys";
            this.btkey.Click += new System.EventHandler(this.btkey_Click);
            // 
            // btGPRS
            // 
            this.btGPRS.BackColor = System.Drawing.SystemColors.Desktop;
            this.btGPRS.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btGPRS.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btGPRS.Location = new System.Drawing.Point(126, 87);
            this.btGPRS.Name = "btGPRS";
            this.btGPRS.Size = new System.Drawing.Size(100, 31);
            this.btGPRS.TabIndex = 40;
            this.btGPRS.Tag = "Open";
            this.btGPRS.Text = "Open GPRS";
            this.btGPRS.Click += new System.EventHandler(this.btGPRS_Click);
            // 
            // btwifi
            // 
            this.btwifi.BackColor = System.Drawing.SystemColors.Desktop;
            this.btwifi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btwifi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btwifi.Location = new System.Drawing.Point(10, 87);
            this.btwifi.Name = "btwifi";
            this.btwifi.Size = new System.Drawing.Size(99, 31);
            this.btwifi.TabIndex = 39;
            this.btwifi.Tag = "Open";
            this.btwifi.Text = "Wi-Fi";
            this.btwifi.Click += new System.EventHandler(this.btwifi_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(10, 242);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(216, 20);
            this.lblStatus.ParentChanged += new System.EventHandler(this.lblStatus_ParentChanged);
            // 
            // btbattery
            // 
            this.btbattery.BackColor = System.Drawing.SystemColors.Desktop;
            this.btbattery.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btbattery.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btbattery.Location = new System.Drawing.Point(9, 199);
            this.btbattery.Name = "btbattery";
            this.btbattery.Size = new System.Drawing.Size(99, 31);
            this.btbattery.TabIndex = 44;
            this.btbattery.Text = "Battery";
            this.btbattery.Click += new System.EventHandler(this.btbattery_Click);
            // 
            // btver
            // 
            this.btver.BackColor = System.Drawing.SystemColors.Desktop;
            this.btver.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btver.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btver.Location = new System.Drawing.Point(126, 199);
            this.btver.Name = "btver";
            this.btver.Size = new System.Drawing.Size(99, 31);
            this.btver.TabIndex = 46;
            this.btver.Text = "Version";
            this.btver.Click += new System.EventHandler(this.btver_Click);
            // 
            // FrPadMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btver);
            this.Controls.Add(this.btbattery);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btversion);
            this.Controls.Add(this.btsound);
            this.Controls.Add(this.btkey);
            this.Controls.Add(this.btGPRS);
            this.Controls.Add(this.btwifi);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrPadMain";
            this.Text = "Pad Main";
            this.Load += new System.EventHandler(this.FrPadMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btversion;
        private System.Windows.Forms.Button btsound;
        private System.Windows.Forms.Button btkey;
        private System.Windows.Forms.Button btGPRS;
        private System.Windows.Forms.Button btwifi;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btbattery;
        private System.Windows.Forms.Button btver;
    }
}