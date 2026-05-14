namespace FirstStepApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
         }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.liveviewForm1 = new Keyence.AutoID.SDK.LiveviewForm();
            this.TgrBtn = new System.Windows.Forms.Button();
            this.DataText = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SchBtn = new System.Windows.Forms.Button();
            this.SctBtn = new System.Windows.Forms.CheckBox();
            this.NICcomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // liveviewForm1
            // 
            this.liveviewForm1.BackColor = System.Drawing.Color.Black;
            this.liveviewForm1.BinningType = Keyence.AutoID.SDK.LiveviewForm.ImageBinningType.OneQuarter;
            this.liveviewForm1.ImageFormat = Keyence.AutoID.SDK.LiveviewForm.ImageFormatType.Jpeg;
            this.liveviewForm1.ImageQuality = 5;
            this.liveviewForm1.IpAddress = "192.168.100.100";
            this.liveviewForm1.Location = new System.Drawing.Point(11, 91);
            this.liveviewForm1.Name = "liveviewForm1";
            this.liveviewForm1.PullTimeSpan = 100;
            this.liveviewForm1.Size = new System.Drawing.Size(334, 219);
            this.liveviewForm1.TabIndex = 0;
            this.liveviewForm1.TimeoutMs = 2000;
            // 
            // TgrBtn
            // 
            this.TgrBtn.Enabled = false;
            this.TgrBtn.Location = new System.Drawing.Point(11, 59);
            this.TgrBtn.Name = "TgrBtn";
            this.TgrBtn.Size = new System.Drawing.Size(103, 26);
            this.TgrBtn.TabIndex = 4;
            this.TgrBtn.Text = "Trigger On";
            this.TgrBtn.UseVisualStyleBackColor = true;
            this.TgrBtn.Click += new System.EventHandler(this.TgrBtn_Click);
            // 
            // DataText
            // 
            this.DataText.BackColor = System.Drawing.SystemColors.Control;
            this.DataText.Location = new System.Drawing.Point(11, 318);
            this.DataText.MaxLength = 10;
            this.DataText.Name = "DataText";
            this.DataText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DataText.Size = new System.Drawing.Size(334, 19);
            this.DataText.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 20);
            this.comboBox1.TabIndex = 6;
            // 
            // SchBtn
            // 
            this.SchBtn.Location = new System.Drawing.Point(167, 3);
            this.SchBtn.Name = "SchBtn";
            this.SchBtn.Size = new System.Drawing.Size(83, 23);
            this.SchBtn.TabIndex = 7;
            this.SchBtn.Text = "Search";
            this.SchBtn.UseVisualStyleBackColor = true;
            this.SchBtn.Click += new System.EventHandler(this.SchBtn_Click);
            // 
            // SctBtn
            // 
            this.SctBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.SctBtn.AutoSize = true;
            this.SctBtn.Enabled = false;
            this.SctBtn.Location = new System.Drawing.Point(167, 32);
            this.SctBtn.Name = "SctBtn";
            this.SctBtn.Size = new System.Drawing.Size(83, 22);
            this.SctBtn.TabIndex = 8;
            this.SctBtn.Text = "ReaderSelect";
            this.SctBtn.UseVisualStyleBackColor = true;
            this.SctBtn.CheckedChanged += new System.EventHandler(this.SctBtn_CheckedChanged);
            // 
            // NICcomboBox
            // 
            this.NICcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NICcomboBox.FormattingEnabled = true;
            this.NICcomboBox.Location = new System.Drawing.Point(11, 6);
            this.NICcomboBox.Name = "NICcomboBox";
            this.NICcomboBox.Size = new System.Drawing.Size(150, 20);
            this.NICcomboBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 348);
            this.Controls.Add(this.NICcomboBox);
            this.Controls.Add(this.SctBtn);
            this.Controls.Add(this.SchBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DataText);
            this.Controls.Add(this.TgrBtn);
            this.Controls.Add(this.liveviewForm1);
            this.Name = "Form1";
            this.Text = "FirstStepApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Keyence.AutoID.SDK.LiveviewForm liveviewForm1;
        private System.Windows.Forms.Button TgrBtn;
        private System.Windows.Forms.TextBox DataText;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button SchBtn;
        private System.Windows.Forms.CheckBox SctBtn;
        private System.Windows.Forms.ComboBox NICcomboBox;
    }
}

