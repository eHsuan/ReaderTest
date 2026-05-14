namespace ReadResultAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.picBxJpegImageView = new System.Windows.Forms.PictureBox();
            this.lbReadDate = new System.Windows.Forms.Label();
            this.lbReadData = new System.Windows.Forms.Label();
            this.tbxServerPath = new System.Windows.Forms.TextBox();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.lbNewFileName = new System.Windows.Forms.Label();
            this.lbNewJpgFileName = new System.Windows.Forms.Label();
            this.btnShowImage = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbData = new System.Windows.Forms.Label();
            this.lbHistoricalDataFileName = new System.Windows.Forms.Label();
            this.lbImageFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBxJpegImageView)).BeginInit();
            this.SuspendLayout();
            // 
            // picBxJpegImageView
            // 
            this.picBxJpegImageView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picBxJpegImageView.Location = new System.Drawing.Point(12, 12);
            this.picBxJpegImageView.Name = "picBxJpegImageView";
            this.picBxJpegImageView.Size = new System.Drawing.Size(510, 378);
            this.picBxJpegImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxJpegImageView.TabIndex = 11;
            this.picBxJpegImageView.TabStop = false;
            // 
            // lbReadDate
            // 
            this.lbReadDate.AutoSize = true;
            this.lbReadDate.Location = new System.Drawing.Point(553, 33);
            this.lbReadDate.Name = "lbReadDate";
            this.lbReadDate.Size = new System.Drawing.Size(29, 12);
            this.lbReadDate.TabIndex = 13;
            this.lbReadDate.Text = "none";
            // 
            // lbReadData
            // 
            this.lbReadData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReadData.Location = new System.Drawing.Point(553, 72);
            this.lbReadData.Name = "lbReadData";
            this.lbReadData.Size = new System.Drawing.Size(289, 122);
            this.lbReadData.TabIndex = 14;
            this.lbReadData.Text = "none";
            // 
            // tbxServerPath
            // 
            this.tbxServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxServerPath.Location = new System.Drawing.Point(555, 229);
            this.tbxServerPath.Name = "tbxServerPath";
            this.tbxServerPath.Size = new System.Drawing.Size(206, 19);
            this.tbxServerPath.TabIndex = 15;
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderSelect.Location = new System.Drawing.Point(767, 227);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFolderSelect.TabIndex = 16;
            this.btnFolderSelect.Text = "FTP Path";
            this.btnFolderSelect.UseVisualStyleBackColor = true;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click_1);
            // 
            // lbNewFileName
            // 
            this.lbNewFileName.AutoSize = true;
            this.lbNewFileName.Location = new System.Drawing.Point(553, 268);
            this.lbNewFileName.Name = "lbNewFileName";
            this.lbNewFileName.Size = new System.Drawing.Size(29, 12);
            this.lbNewFileName.TabIndex = 17;
            this.lbNewFileName.Text = "none";
            // 
            // lbNewJpgFileName
            // 
            this.lbNewJpgFileName.AutoSize = true;
            this.lbNewJpgFileName.Location = new System.Drawing.Point(553, 301);
            this.lbNewJpgFileName.Name = "lbNewJpgFileName";
            this.lbNewJpgFileName.Size = new System.Drawing.Size(29, 12);
            this.lbNewJpgFileName.TabIndex = 18;
            this.lbNewJpgFileName.Text = "none";
            // 
            // btnShowImage
            // 
            this.btnShowImage.Location = new System.Drawing.Point(555, 367);
            this.btnShowImage.Name = "btnShowImage";
            this.btnShowImage.Size = new System.Drawing.Size(164, 23);
            this.btnShowImage.TabIndex = 19;
            this.btnShowImage.Text = "Show Image";
            this.btnShowImage.UseVisualStyleBackColor = true;
            this.btnShowImage.Click += new System.EventHandler(this.btnShowImage_Click_1);
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(798, 378);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(44, 12);
            this.lbVersion.TabIndex = 20;
            this.lbVersion.Text = "Version";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(528, 21);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(38, 12);
            this.lbTime.TabIndex = 21;
            this.lbTime.Text = "[Time]";
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(528, 60);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(37, 12);
            this.lbData.TabIndex = 22;
            this.lbData.Text = "[Data]";
            // 
            // lbHistoricalDataFileName
            // 
            this.lbHistoricalDataFileName.AutoSize = true;
            this.lbHistoricalDataFileName.Location = new System.Drawing.Point(528, 256);
            this.lbHistoricalDataFileName.Name = "lbHistoricalDataFileName";
            this.lbHistoricalDataFileName.Size = new System.Drawing.Size(139, 12);
            this.lbHistoricalDataFileName.TabIndex = 23;
            this.lbHistoricalDataFileName.Text = "[Historical data file name]";
            // 
            // lbImageFileName
            // 
            this.lbImageFileName.AutoSize = true;
            this.lbImageFileName.Location = new System.Drawing.Point(528, 289);
            this.lbImageFileName.Name = "lbImageFileName";
            this.lbImageFileName.Size = new System.Drawing.Size(94, 12);
            this.lbImageFileName.TabIndex = 24;
            this.lbImageFileName.Text = "[Image file name]";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 410);
            this.Controls.Add(this.lbImageFileName);
            this.Controls.Add(this.lbHistoricalDataFileName);
            this.Controls.Add(this.lbData);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.btnShowImage);
            this.Controls.Add(this.lbNewJpgFileName);
            this.Controls.Add(this.lbNewFileName);
            this.Controls.Add(this.btnFolderSelect);
            this.Controls.Add(this.tbxServerPath);
            this.Controls.Add(this.lbReadData);
            this.Controls.Add(this.lbReadDate);
            this.Controls.Add(this.picBxJpegImageView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.picBxJpegImageView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBxJpegImageView;
        private System.Windows.Forms.Label lbReadDate;
        private System.Windows.Forms.Label lbReadData;
        private System.Windows.Forms.TextBox tbxServerPath;
        private System.Windows.Forms.Button btnFolderSelect;
        private System.Windows.Forms.Label lbNewFileName;
        private System.Windows.Forms.Label lbNewJpgFileName;
        private System.Windows.Forms.Button btnShowImage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.Label lbHistoricalDataFileName;
        private System.Windows.Forms.Label lbImageFileName;
    }
}

