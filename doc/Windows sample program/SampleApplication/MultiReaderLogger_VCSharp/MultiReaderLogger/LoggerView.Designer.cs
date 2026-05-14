namespace MultiReaderLogger
{
    partial class LoggerView
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.readerData = new System.Windows.Forms.TextBox();
            this.readerInfo = new System.Windows.Forms.Label();
            this.liveviewForm1 = new Keyence.AutoID.SDK.LiveviewForm();
            this.ImageInitializeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readerData
            // 
            this.readerData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readerData.Location = new System.Drawing.Point(14, 212);
            this.readerData.Name = "readerData";
            this.readerData.ReadOnly = true;
            this.readerData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.readerData.Size = new System.Drawing.Size(232, 19);
            this.readerData.TabIndex = 1;
            // 
            // readerInfo
            // 
            this.readerInfo.AutoSize = true;
            this.readerInfo.Location = new System.Drawing.Point(12, 4);
            this.readerInfo.Name = "readerInfo";
            this.readerInfo.Size = new System.Drawing.Size(74, 12);
            this.readerInfo.TabIndex = 4;
            this.readerInfo.Text = "Reader Name";
            // 
            // liveviewForm1
            // 
            this.liveviewForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveviewForm1.BackColor = System.Drawing.Color.Black;
            this.liveviewForm1.BinningType = Keyence.AutoID.SDK.LiveviewForm.ImageBinningType.OneQuarter;
            this.liveviewForm1.ImageFormat = Keyence.AutoID.SDK.LiveviewForm.ImageFormatType.Jpeg;
            this.liveviewForm1.ImageQuality = 5;
            this.liveviewForm1.IpAddress = "192.168.100.100";
            this.liveviewForm1.Location = new System.Drawing.Point(14, 19);
            this.liveviewForm1.Name = "liveviewForm1";
            this.liveviewForm1.PullTimeSpan = 100;
            this.liveviewForm1.Size = new System.Drawing.Size(232, 187);
            this.liveviewForm1.TabIndex = 0;
            this.liveviewForm1.TimeoutMs = 2000;
            // 
            // ImageInitializeLabel
            // 
            this.ImageInitializeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageInitializeLabel.AutoSize = true;
            this.ImageInitializeLabel.Location = new System.Drawing.Point(215, 4);
            this.ImageInitializeLabel.Name = "ImageInitializeLabel";
            this.ImageInitializeLabel.Size = new System.Drawing.Size(0, 12);
            this.ImageInitializeLabel.TabIndex = 5;
            // 
            // LoggerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImageInitializeLabel);
            this.Controls.Add(this.readerInfo);
            this.Controls.Add(this.readerData);
            this.Controls.Add(this.liveviewForm1);
            this.Name = "LoggerView";
            this.Size = new System.Drawing.Size(258, 243);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Keyence.AutoID.SDK.LiveviewForm liveviewForm1;
        private System.Windows.Forms.TextBox readerData;
        private System.Windows.Forms.Label readerInfo;
        private System.Windows.Forms.Label ImageInitializeLabel;
    }
}
