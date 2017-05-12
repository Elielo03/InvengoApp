namespace Invengo.Sample
{
    partial class FrLoader
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
            this.timerLoad = new System.Windows.Forms.Timer();
            this.progressBarWait = new System.Windows.Forms.ProgressBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerLoad
            // 
            this.timerLoad.Interval = 50;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // progressBarWait
            // 
            this.progressBarWait.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarWait.Location = new System.Drawing.Point(0, 310);
            this.progressBarWait.Name = "progressBarWait";
            this.progressBarWait.Size = new System.Drawing.Size(240, 10);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lblInfo.Location = new System.Drawing.Point(11, 122);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(216, 73);
            this.lblInfo.Visible = false;
            // 
            // FrLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarWait);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrLoader";
            this.Text = "PDA Demo Loader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closed += new System.EventHandler(this.LoaderForm_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.ProgressBar progressBarWait;
        private System.Windows.Forms.Label lblInfo;
    }
}

