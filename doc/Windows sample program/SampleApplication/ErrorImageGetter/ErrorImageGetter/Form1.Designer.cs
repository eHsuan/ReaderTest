namespace ErrorImageGetter
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
            this.nicComboBox = new System.Windows.Forms.ComboBox();
            this.Search_Btn = new System.Windows.Forms.Button();
            this.SelectAllReaders_ChkBx = new System.Windows.Forms.CheckBox();
            this.SearchedReaders_ChkLstBx = new System.Windows.Forms.CheckedListBox();
            this.OperationStart = new System.Windows.Forms.Button();
            this.NumberOfErrorFile_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MasterSelect_comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfErrorFile_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nicComboBox
            // 
            this.nicComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicComboBox.FormattingEnabled = true;
            this.nicComboBox.Location = new System.Drawing.Point(12, 12);
            this.nicComboBox.Name = "nicComboBox";
            this.nicComboBox.Size = new System.Drawing.Size(336, 20);
            this.nicComboBox.TabIndex = 23;
            this.nicComboBox.SelectedIndexChanged += new System.EventHandler(this.nicComboBox_SelectedIndexChanged);
            // 
            // Search_Btn
            // 
            this.Search_Btn.AutoSize = true;
            this.Search_Btn.Location = new System.Drawing.Point(12, 46);
            this.Search_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(129, 39);
            this.Search_Btn.TabIndex = 24;
            this.Search_Btn.Text = "Search";
            this.Search_Btn.UseVisualStyleBackColor = true;
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // SelectAllReaders_ChkBx
            // 
            this.SelectAllReaders_ChkBx.AutoSize = true;
            this.SelectAllReaders_ChkBx.Location = new System.Drawing.Point(12, 99);
            this.SelectAllReaders_ChkBx.Name = "SelectAllReaders_ChkBx";
            this.SelectAllReaders_ChkBx.Size = new System.Drawing.Size(120, 16);
            this.SelectAllReaders_ChkBx.TabIndex = 25;
            this.SelectAllReaders_ChkBx.Text = "Select All Readers";
            this.SelectAllReaders_ChkBx.UseVisualStyleBackColor = true;
            this.SelectAllReaders_ChkBx.CheckedChanged += new System.EventHandler(this.SelectAllReaders_ChkBx_CheckedChanged);
            // 
            // SearchedReaders_ChkLstBx
            // 
            this.SearchedReaders_ChkLstBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchedReaders_ChkLstBx.CheckOnClick = true;
            this.SearchedReaders_ChkLstBx.FormattingEnabled = true;
            this.SearchedReaders_ChkLstBx.Location = new System.Drawing.Point(12, 121);
            this.SearchedReaders_ChkLstBx.Name = "SearchedReaders_ChkLstBx";
            this.SearchedReaders_ChkLstBx.Size = new System.Drawing.Size(263, 74);
            this.SearchedReaders_ChkLstBx.TabIndex = 26;
            this.SearchedReaders_ChkLstBx.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SearchedReaders_ChkLstBx_ItemCheck);
            this.SearchedReaders_ChkLstBx.SelectedIndexChanged += new System.EventHandler(this.SearchedReaders_ChkLstBx_SelectedIndexChanged);
            // 
            // OperationStart
            // 
            this.OperationStart.Location = new System.Drawing.Point(330, 228);
            this.OperationStart.Name = "OperationStart";
            this.OperationStart.Size = new System.Drawing.Size(153, 39);
            this.OperationStart.TabIndex = 29;
            this.OperationStart.Text = "Start";
            this.OperationStart.UseVisualStyleBackColor = true;
            this.OperationStart.Click += new System.EventHandler(this.OperationStart_Click);
            // 
            // NumberOfErrorFile_NumericUpDown
            // 
            this.NumberOfErrorFile_NumericUpDown.Location = new System.Drawing.Point(330, 176);
            this.NumberOfErrorFile_NumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumberOfErrorFile_NumericUpDown.Name = "NumberOfErrorFile_NumericUpDown";
            this.NumberOfErrorFile_NumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.NumberOfErrorFile_NumericUpDown.TabIndex = 30;
            this.NumberOfErrorFile_NumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "Number of Error Files";
            // 
            // MasterSelect_comboBox
            // 
            this.MasterSelect_comboBox.FormattingEnabled = true;
            this.MasterSelect_comboBox.Location = new System.Drawing.Point(330, 80);
            this.MasterSelect_comboBox.Name = "MasterSelect_comboBox";
            this.MasterSelect_comboBox.Size = new System.Drawing.Size(194, 20);
            this.MasterSelect_comboBox.TabIndex = 32;
            this.MasterSelect_comboBox.SelectedIndexChanged += new System.EventHandler(this.MasterSelect_comboBox_changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "Master";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 283);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MasterSelect_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumberOfErrorFile_NumericUpDown);
            this.Controls.Add(this.OperationStart);
            this.Controls.Add(this.SearchedReaders_ChkLstBx);
            this.Controls.Add(this.SelectAllReaders_ChkBx);
            this.Controls.Add(this.Search_Btn);
            this.Controls.Add(this.nicComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfErrorFile_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox nicComboBox;
        private System.Windows.Forms.Button Search_Btn;
        private System.Windows.Forms.CheckBox SelectAllReaders_ChkBx;
        private System.Windows.Forms.CheckedListBox SearchedReaders_ChkLstBx;
        private System.Windows.Forms.Button OperationStart;
        private System.Windows.Forms.NumericUpDown NumberOfErrorFile_NumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MasterSelect_comboBox;
        private System.Windows.Forms.Label label3;
    }
}

