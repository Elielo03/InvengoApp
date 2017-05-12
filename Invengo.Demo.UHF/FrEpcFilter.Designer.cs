namespace Invengo.Demo.UHF
{
    partial class FrEpcFilter
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
            this.lbepc = new System.Windows.Forms.Label();
            this.tvEpcData = new System.Windows.Forms.ComboBox();
            this.btallrigth = new System.Windows.Forms.Button();
            this.btallleft = new System.Windows.Forms.Button();
            this.btright = new System.Windows.Forms.Button();
            this.btleft = new System.Windows.Forms.Button();
            this.listBoxAddr = new System.Windows.Forms.ListBox();
            this.listBoxChooseAddr = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btcancel = new System.Windows.Forms.Button();
            this.btfilter = new System.Windows.Forms.Button();
            this.btread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbepc
            // 
            this.lbepc.Location = new System.Drawing.Point(3, 9);
            this.lbepc.Name = "lbepc";
            this.lbepc.Size = new System.Drawing.Size(35, 20);
            this.lbepc.Text = "EPC:";
            // 
            // tvEpcData
            // 
            this.tvEpcData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.tvEpcData.Location = new System.Drawing.Point(34, 6);
            this.tvEpcData.Name = "tvEpcData";
            this.tvEpcData.Size = new System.Drawing.Size(201, 23);
            this.tvEpcData.TabIndex = 1;
            this.tvEpcData.Text = "000000000000000000000000";
            // 
            // btallrigth
            // 
            this.btallrigth.Location = new System.Drawing.Point(91, 184);
            this.btallrigth.Name = "btallrigth";
            this.btallrigth.Size = new System.Drawing.Size(53, 29);
            this.btallrigth.TabIndex = 8;
            this.btallrigth.Text = "<<";
            this.btallrigth.Click += new System.EventHandler(this.btallrigth_Click_1);
            // 
            // btallleft
            // 
            this.btallleft.Location = new System.Drawing.Point(91, 133);
            this.btallleft.Name = "btallleft";
            this.btallleft.Size = new System.Drawing.Size(53, 29);
            this.btallleft.TabIndex = 7;
            this.btallleft.Text = ">>";
            this.btallleft.Click += new System.EventHandler(this.btallleft_Click_1);
            // 
            // btright
            // 
            this.btright.Location = new System.Drawing.Point(91, 84);
            this.btright.Name = "btright";
            this.btright.Size = new System.Drawing.Size(53, 29);
            this.btright.TabIndex = 6;
            this.btright.Text = "<";
            this.btright.Click += new System.EventHandler(this.btright_Click_1);
            // 
            // btleft
            // 
            this.btleft.Location = new System.Drawing.Point(91, 37);
            this.btleft.Name = "btleft";
            this.btleft.Size = new System.Drawing.Size(53, 29);
            this.btleft.TabIndex = 5;
            this.btleft.Text = ">";
            this.btleft.Click += new System.EventHandler(this.btleft_Click_1);
            // 
            // listBoxAddr
            // 
            this.listBoxAddr.Location = new System.Drawing.Point(3, 35);
            this.listBoxAddr.Name = "listBoxAddr";
            this.listBoxAddr.Size = new System.Drawing.Size(82, 178);
            this.listBoxAddr.TabIndex = 2;
            // 
            // listBoxChooseAddr
            // 
            this.listBoxChooseAddr.Location = new System.Drawing.Point(153, 35);
            this.listBoxChooseAddr.Name = "listBoxChooseAddr";
            this.listBoxChooseAddr.Size = new System.Drawing.Size(82, 178);
            this.listBoxChooseAddr.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(13, 216);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(212, 20);
            // 
            // btcancel
            // 
            this.btcancel.Location = new System.Drawing.Point(3, 239);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(82, 28);
            this.btcancel.TabIndex = 11;
            this.btcancel.Text = "Cancel Filter";
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // btfilter
            // 
            this.btfilter.Location = new System.Drawing.Point(165, 239);
            this.btfilter.Name = "btfilter";
            this.btfilter.Size = new System.Drawing.Size(70, 28);
            this.btfilter.TabIndex = 12;
            this.btfilter.Text = "Filter";
            this.btfilter.Click += new System.EventHandler(this.btfilter_Click);
            // 
            // btread
            // 
            this.btread.Location = new System.Drawing.Point(91, 239);
            this.btread.Name = "btread";
            this.btread.Size = new System.Drawing.Size(68, 28);
            this.btread.TabIndex = 15;
            this.btread.Text = "Read ";
            this.btread.Click += new System.EventHandler(this.btread_Click);
            // 
            // FrEpcFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btread);
            this.Controls.Add(this.btfilter);
            this.Controls.Add(this.btcancel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBoxChooseAddr);
            this.Controls.Add(this.btallrigth);
            this.Controls.Add(this.btallleft);
            this.Controls.Add(this.btright);
            this.Controls.Add(this.btleft);
            this.Controls.Add(this.listBoxAddr);
            this.Controls.Add(this.tvEpcData);
            this.Controls.Add(this.lbepc);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrEpcFilter";
            this.Text = "Epc Filter";
            this.Load += new System.EventHandler(this.FrEpcFilter_Load);
            this.Closed += new System.EventHandler(this.FrEpcFilter_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbepc;
        private System.Windows.Forms.ComboBox tvEpcData;
        private System.Windows.Forms.Button btallrigth;
        private System.Windows.Forms.Button btallleft;
        private System.Windows.Forms.Button btright;
        private System.Windows.Forms.Button btleft;
        private System.Windows.Forms.ListBox listBoxAddr;
        private System.Windows.Forms.ListBox listBoxChooseAddr;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.Button btfilter;
        private System.Windows.Forms.Button btread;
    }
}