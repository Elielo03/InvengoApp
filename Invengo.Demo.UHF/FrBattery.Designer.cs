namespace Invengo.Sample
{
    partial class FrBattery
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
            this.lblPowerType = new System.Windows.Forms.Label();
            this.lblLifePercent = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.lblBatteryStatus = new System.Windows.Forms.Label();
            this.timerGetPower = new System.Windows.Forms.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbbackup = new System.Windows.Forms.Label();
            this.lblBakVoltage = new System.Windows.Forms.Label();
            this.lblBakPercent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPowerType
            // 
            this.lblPowerType.ForeColor = System.Drawing.Color.Navy;
            this.lblPowerType.Location = new System.Drawing.Point(110, 11);
            this.lblPowerType.Name = "lblPowerType";
            this.lblPowerType.Size = new System.Drawing.Size(100, 20);
            // 
            // lblLifePercent
            // 
            this.lblLifePercent.ForeColor = System.Drawing.Color.Navy;
            this.lblLifePercent.Location = new System.Drawing.Point(110, 53);
            this.lblLifePercent.Name = "lblLifePercent";
            this.lblLifePercent.Size = new System.Drawing.Size(100, 20);
            // 
            // lblVoltage
            // 
            this.lblVoltage.ForeColor = System.Drawing.Color.Navy;
            this.lblVoltage.Location = new System.Drawing.Point(110, 95);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(100, 20);
            // 
            // lblBatteryStatus
            // 
            this.lblBatteryStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblBatteryStatus.Location = new System.Drawing.Point(110, 130);
            this.lblBatteryStatus.Name = "lblBatteryStatus";
            this.lblBatteryStatus.Size = new System.Drawing.Size(100, 20);
            // 
            // timerGetPower
            // 
            this.timerGetPower.Interval = 3000;
            this.timerGetPower.Tick += new System.EventHandler(this.timerGetPower_Tick_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "PowerType";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Life Percent";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Voltage";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Battery Status";
            // 
            // lbbackup
            // 
            this.lbbackup.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbbackup.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbbackup.Location = new System.Drawing.Point(3, 12);
            this.lbbackup.Name = "lbbackup";
            this.lbbackup.Size = new System.Drawing.Size(213, 23);
            this.lbbackup.Text = "Backup Battery";
            // 
            // lblBakVoltage
            // 
            this.lblBakVoltage.ForeColor = System.Drawing.Color.Navy;
            this.lblBakVoltage.Location = new System.Drawing.Point(110, 199);
            this.lblBakVoltage.Name = "lblBakVoltage";
            this.lblBakVoltage.Size = new System.Drawing.Size(100, 20);
            // 
            // lblBakPercent
            // 
            this.lblBakPercent.ForeColor = System.Drawing.Color.Navy;
            this.lblBakPercent.Location = new System.Drawing.Point(109, 78);
            this.lblBakPercent.Name = "lblBakPercent";
            this.lblBakPercent.Size = new System.Drawing.Size(100, 20);
            this.lblBakPercent.ParentChanged += new System.EventHandler(this.lblBakPercent_ParentChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "Bak Voltage";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "Bak Percent";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblBakPercent);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbbackup);
            this.panel2.Location = new System.Drawing.Point(4, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 128);
            this.panel2.Visible = false;
            // 
            // FrBattery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.lblBakVoltage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBatteryStatus);
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.lblLifePercent);
            this.Controls.Add(this.lblPowerType);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrBattery";
            this.Text = "Battery";
            this.Load += new System.EventHandler(this.FrBattery_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPowerType;
        private System.Windows.Forms.Label lblLifePercent;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label lblBatteryStatus;
        private System.Windows.Forms.Timer timerGetPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbbackup;
        private System.Windows.Forms.Label lblBakVoltage;
        private System.Windows.Forms.Label lblBakPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
    }
}