namespace Invengo.Sample
{
    partial class FrLengthParas
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
            this.label1 = new System.Windows.Forms.Label();
            this.tvTidLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tvUserdataOffset = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tvUserdataLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tvPassWord = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.Text = "ID length(bytes)";
            // 
            // tvTidLength
            // 
            this.tvTidLength.Location = new System.Drawing.Point(138, 29);
            this.tvTidLength.MaxLength = 3;
            this.tvTidLength.Name = "tvTidLength";
            this.tvTidLength.Size = new System.Drawing.Size(100, 23);
            this.tvTidLength.TabIndex = 1;
            this.tvTidLength.Text = "8";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.Text = "Userdata offset";
            // 
            // tvUserdataOffset
            // 
            this.tvUserdataOffset.Location = new System.Drawing.Point(138, 68);
            this.tvUserdataOffset.MaxLength = 3;
            this.tvUserdataOffset.Name = "tvUserdataOffset";
            this.tvUserdataOffset.Size = new System.Drawing.Size(100, 23);
            this.tvUserdataOffset.TabIndex = 3;
            this.tvUserdataOffset.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.Text = "Userdata length(bytes)";
            // 
            // tvUserdataLength
            // 
            this.tvUserdataLength.Location = new System.Drawing.Point(138, 105);
            this.tvUserdataLength.MaxLength = 3;
            this.tvUserdataLength.Name = "tvUserdataLength";
            this.tvUserdataLength.Size = new System.Drawing.Size(100, 23);
            this.tvUserdataLength.TabIndex = 5;
            this.tvUserdataLength.Text = "28";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Access password";
            // 
            // tvPassWord
            // 
            this.tvPassWord.Location = new System.Drawing.Point(138, 138);
            this.tvPassWord.MaxLength = 8;
            this.tvPassWord.Name = "tvPassWord";
            this.tvPassWord.Size = new System.Drawing.Size(100, 23);
            this.tvPassWord.TabIndex = 7;
            this.tvPassWord.Text = "00000000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrLengthParas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvPassWord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tvUserdataLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tvUserdataOffset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvTidLength);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrLengthParas";
            this.Text = "FrLengthParas";
            this.Load += new System.EventHandler(this.FrLengthParas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvTidLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tvUserdataOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tvUserdataLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tvPassWord;
        private System.Windows.Forms.Button button1;
    }
}