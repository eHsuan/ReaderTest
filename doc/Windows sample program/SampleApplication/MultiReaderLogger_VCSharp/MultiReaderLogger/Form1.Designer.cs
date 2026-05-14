namespace MultiReaderLogger
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
            this.Search_Btn = new System.Windows.Forms.Button();
            this.SearchedReaders_ChkLstBx = new System.Windows.Forms.CheckedListBox();
            this.RegisteredLoggerView_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectAllReaders_ChkBx = new System.Windows.Forms.CheckBox();
            this.LogData_ChkBx = new System.Windows.Forms.CheckBox();
            this.LogImage_ChkBx = new System.Windows.Forms.CheckBox();
            this.nicComboBox = new System.Windows.Forms.ComboBox();
            this.layoutComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Search_Btn
            // 
            this.Search_Btn.AutoSize = true;
            this.Search_Btn.Location = new System.Drawing.Point(7, 34);
            this.Search_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(129, 39);
            this.Search_Btn.TabIndex = 8;
            this.Search_Btn.Text = "Search";
            this.Search_Btn.UseVisualStyleBackColor = true;
            this.Search_Btn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchedReaders_ChkLstBx
            // 
            this.SearchedReaders_ChkLstBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchedReaders_ChkLstBx.CheckOnClick = true;
            this.SearchedReaders_ChkLstBx.FormattingEnabled = true;
            this.SearchedReaders_ChkLstBx.Location = new System.Drawing.Point(4, 103);
            this.SearchedReaders_ChkLstBx.Name = "SearchedReaders_ChkLstBx";
            this.SearchedReaders_ChkLstBx.Size = new System.Drawing.Size(316, 76);
            this.SearchedReaders_ChkLstBx.TabIndex = 12;
            this.SearchedReaders_ChkLstBx.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SearchedReaders_ChkLstBx_ItemCheck);
            this.SearchedReaders_ChkLstBx.SelectedIndexChanged += new System.EventHandler(this.SearchedReaders_ChkLstBx_SelectedIndexChanged);
            // 
            // RegisteredLoggerView_Panel
            // 
            this.RegisteredLoggerView_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisteredLoggerView_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RegisteredLoggerView_Panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.RegisteredLoggerView_Panel.ColumnCount = 8;
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RegisteredLoggerView_Panel.Location = new System.Drawing.Point(4, 185);
            this.RegisteredLoggerView_Panel.Name = "RegisteredLoggerView_Panel";
            this.RegisteredLoggerView_Panel.RowCount = 4;
            this.RegisteredLoggerView_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RegisteredLoggerView_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RegisteredLoggerView_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RegisteredLoggerView_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RegisteredLoggerView_Panel.Size = new System.Drawing.Size(440, 342);
            this.RegisteredLoggerView_Panel.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 15;
            // 
            // SelectAllReaders_ChkBx
            // 
            this.SelectAllReaders_ChkBx.AutoSize = true;
            this.SelectAllReaders_ChkBx.Location = new System.Drawing.Point(7, 81);
            this.SelectAllReaders_ChkBx.Name = "SelectAllReaders_ChkBx";
            this.SelectAllReaders_ChkBx.Size = new System.Drawing.Size(131, 19);
            this.SelectAllReaders_ChkBx.TabIndex = 19;
            this.SelectAllReaders_ChkBx.Text = "Select All Readers";
            this.SelectAllReaders_ChkBx.UseVisualStyleBackColor = true;
            this.SelectAllReaders_ChkBx.CheckedChanged += new System.EventHandler(this.SelectAllReaders_ChkBx_CheckedChanged);
            // 
            // LogData_ChkBx
            // 
            this.LogData_ChkBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogData_ChkBx.AutoSize = true;
            this.LogData_ChkBx.Location = new System.Drawing.Point(326, 103);
            this.LogData_ChkBx.Name = "LogData_ChkBx";
            this.LogData_ChkBx.Size = new System.Drawing.Size(83, 19);
            this.LogData_ChkBx.TabIndex = 20;
            this.LogData_ChkBx.Text = "Log Data ";
            this.LogData_ChkBx.UseVisualStyleBackColor = true;
            this.LogData_ChkBx.CheckedChanged += new System.EventHandler(this.LogData_ChkBx_CheckedChanged);
            // 
            // LogImage_ChkBx
            // 
            this.LogImage_ChkBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogImage_ChkBx.AutoSize = true;
            this.LogImage_ChkBx.Location = new System.Drawing.Point(326, 132);
            this.LogImage_ChkBx.Name = "LogImage_ChkBx";
            this.LogImage_ChkBx.Size = new System.Drawing.Size(93, 19);
            this.LogImage_ChkBx.TabIndex = 21;
            this.LogImage_ChkBx.Text = "Log Image ";
            this.LogImage_ChkBx.UseVisualStyleBackColor = true;
            this.LogImage_ChkBx.CheckedChanged += new System.EventHandler(this.LogImage_ChkBx_CheckedChanged);
            // 
            // nicComboBox
            // 
            this.nicComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicComboBox.FormattingEnabled = true;
            this.nicComboBox.Location = new System.Drawing.Point(7, 6);
            this.nicComboBox.Name = "nicComboBox";
            this.nicComboBox.Size = new System.Drawing.Size(313, 23);
            this.nicComboBox.TabIndex = 22;
            this.nicComboBox.SelectedIndexChanged += new System.EventHandler(this.nicComboBox_SelectedIndexChanged);
            // 
            // layoutComboBox
            // 
            this.layoutComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutComboBox.FormattingEnabled = true;
            this.layoutComboBox.Items.AddRange(new object[] {
            "1 x 1",
            "2 x 2",
            "3 x 3",
            "4 x 4",
            "5 x 4",
            "6 x 4",
            "7 x 4",
            "8 x 4"});
            this.layoutComboBox.Location = new System.Drawing.Point(326, 6);
            this.layoutComboBox.Name = "layoutComboBox";
            this.layoutComboBox.Size = new System.Drawing.Size(102, 23);
            this.layoutComboBox.TabIndex = 23;
            this.layoutComboBox.SelectedIndexChanged += new System.EventHandler(this.layoutComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 539);
            this.Controls.Add(this.layoutComboBox);
            this.Controls.Add(this.nicComboBox);
            this.Controls.Add(this.SelectAllReaders_ChkBx);
            this.Controls.Add(this.LogImage_ChkBx);
            this.Controls.Add(this.LogData_ChkBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegisteredLoggerView_Panel);
            this.Controls.Add(this.Search_Btn);
            this.Controls.Add(this.SearchedReaders_ChkLstBx);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "MultiReaderLogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Search_Btn;
        private System.Windows.Forms.CheckedListBox SearchedReaders_ChkLstBx;
        private System.Windows.Forms.TableLayoutPanel RegisteredLoggerView_Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SelectAllReaders_ChkBx;
        private System.Windows.Forms.CheckBox LogData_ChkBx;
        private System.Windows.Forms.CheckBox LogImage_ChkBx;
        private System.Windows.Forms.ComboBox nicComboBox;
        private System.Windows.Forms.ComboBox layoutComboBox;
    }
}

