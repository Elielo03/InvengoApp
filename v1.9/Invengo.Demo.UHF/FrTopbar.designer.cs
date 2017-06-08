namespace InspectHandler
{
    partial class FrTopbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrTopbar));
            this.picWireless = new System.Windows.Forms.PictureBox();
            this.picBattery = new System.Windows.Forms.PictureBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.imlBattery = new System.Windows.Forms.ImageList();
            this.lblDatetime = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.imlExt = new System.Windows.Forms.ImageList();
            this.timerBattery = new System.Windows.Forms.Timer();
            this.timerCharging = new System.Windows.Forms.Timer();
            this.timerWireless = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // picWireless
            // 
            this.picWireless.Dock = System.Windows.Forms.DockStyle.Left;
            this.picWireless.Location = new System.Drawing.Point(0, 0);
            this.picWireless.Name = "picWireless";
            this.picWireless.Size = new System.Drawing.Size(24, 20);
            this.picWireless.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // picBattery
            // 
            this.picBattery.Dock = System.Windows.Forms.DockStyle.Right;
            this.picBattery.Location = new System.Drawing.Point(215, 0);
            this.picBattery.Name = "picBattery";
            this.picBattery.Size = new System.Drawing.Size(25, 20);
            this.picBattery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBattery.Tag = "show";
            this.picBattery.DoubleClick += new System.EventHandler(this.picBattery_DoubleClick);
            this.picBattery.Click += new System.EventHandler(this.picBattery_Click);
            // 
            // picBackground
            // 
            this.picBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(240, 20);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // imlBattery
            // 
            this.imlBattery.ImageSize = new System.Drawing.Size(24, 24);
            this.imlBattery.Images.Clear();
            this.imlBattery.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imlBattery.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imlBattery.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imlBattery.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.imlBattery.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            // 
            // lblDatetime
            // 
            this.lblDatetime.BackColor = System.Drawing.Color.Transparent;
            this.lblDatetime.Location = new System.Drawing.Point(132, 1);
            this.lblDatetime.Name = "lblDatetime";
            this.lblDatetime.Size = new System.Drawing.Size(80, 17);
            this.lblDatetime.Text = "08-08 15:08";
            this.lblDatetime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Location = new System.Drawing.Point(30, 2);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(15, 15);
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMsg.Visible = false;
            // 
            // imlExt
            // 
            this.imlExt.ImageSize = new System.Drawing.Size(24, 24);
            this.imlExt.Images.Clear();
            this.imlExt.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
            this.imlExt.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
            this.imlExt.Images.Add(((System.Drawing.Image)(resources.GetObject("resource7"))));
            // 
            // timerBattery
            // 
            this.timerBattery.Interval = 3000;
            this.timerBattery.Tick += new System.EventHandler(this.timerBattery_Tick);
            // 
            // timerCharging
            // 
            this.timerCharging.Interval = 2000;
            this.timerCharging.Tick += new System.EventHandler(this.timerCharging_Tick);
            // 
            // timerWireless
            // 
            this.timerWireless.Interval = 6000;
            this.timerWireless.Tick += new System.EventHandler(this.timerWireless_Tick);
            // 
            // FrTopbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 20);
            this.ControlBox = false;
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblDatetime);
            this.Controls.Add(this.picBattery);
            this.Controls.Add(this.picWireless);
            this.Controls.Add(this.picBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrTopbar";
            this.Text = "FrTopbar";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWireless;
        private System.Windows.Forms.PictureBox picBattery;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.ImageList imlBattery;
        private System.Windows.Forms.Label lblDatetime;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ImageList imlExt;
        private System.Windows.Forms.Timer timerBattery;
        private System.Windows.Forms.Timer timerCharging;
        private System.Windows.Forms.Timer timerWireless;
    }
}