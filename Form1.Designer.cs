namespace ReaderTestApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnStartStop = new Button();
            lblIndicator = new Label();
            lblCalibTitle = new Label();
            btnCalib1 = new Button();
            btnCalib2 = new Button();
            btnCalib3 = new Button();
            btnCalib4 = new Button();
            txtLog1 = new TextBox();
            txtLog2 = new TextBox();
            txtLog3 = new TextBox();
            txtLog4 = new TextBox();
            lblName1 = new Label();
            lblName2 = new Label();
            lblName3 = new Label();
            lblName4 = new Label();
            SuspendLayout();
            // 
            // btnStartStop
            // 
            btnStartStop.Location = new Point(19, 18);
            btnStartStop.Margin = new Padding(5, 5, 5, 5);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(189, 61);
            btnStartStop.TabIndex = 0;
            btnStartStop.Text = "啟動測試";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // lblIndicator
            // 
            lblIndicator.BackColor = Color.Gray;
            lblIndicator.Location = new Point(228, 31);
            lblIndicator.Margin = new Padding(5, 0, 5, 0);
            lblIndicator.Name = "lblIndicator";
            lblIndicator.Size = new Size(39, 38);
            lblIndicator.TabIndex = 1;
            // 
            // lblCalibTitle
            // 
            lblCalibTitle.AutoSize = true;
            lblCalibTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCalibTitle.Location = new Point(346, 34);
            lblCalibTitle.Margin = new Padding(5, 0, 5, 0);
            lblCalibTitle.Name = "lblCalibTitle";
            lblCalibTitle.Size = new Size(92, 32);
            lblCalibTitle.TabIndex = 2;
            lblCalibTitle.Text = "校正：";
            // 
            // btnCalib1
            // 
            btnCalib1.Location = new Point(440, 23);
            btnCalib1.Margin = new Padding(5, 5, 5, 5);
            btnCalib1.Name = "btnCalib1";
            btnCalib1.Size = new Size(157, 54);
            btnCalib1.TabIndex = 3;
            btnCalib1.Tag = 0;
            btnCalib1.Text = "Reader 1";
            btnCalib1.Click += btnCalibrate_Click;
            // 
            // btnCalib2
            // 
            btnCalib2.Location = new Point(605, 23);
            btnCalib2.Margin = new Padding(5, 5, 5, 5);
            btnCalib2.Name = "btnCalib2";
            btnCalib2.Size = new Size(157, 54);
            btnCalib2.TabIndex = 4;
            btnCalib2.Tag = 1;
            btnCalib2.Text = "Reader 2";
            btnCalib2.Click += btnCalibrate_Click;
            // 
            // btnCalib3
            // 
            btnCalib3.Location = new Point(770, 23);
            btnCalib3.Margin = new Padding(5, 5, 5, 5);
            btnCalib3.Name = "btnCalib3";
            btnCalib3.Size = new Size(157, 54);
            btnCalib3.TabIndex = 5;
            btnCalib3.Tag = 2;
            btnCalib3.Text = "Reader 3";
            btnCalib3.Click += btnCalibrate_Click;
            // 
            // btnCalib4
            // 
            btnCalib4.Location = new Point(935, 23);
            btnCalib4.Margin = new Padding(5, 5, 5, 5);
            btnCalib4.Name = "btnCalib4";
            btnCalib4.Size = new Size(157, 54);
            btnCalib4.TabIndex = 6;
            btnCalib4.Tag = 3;
            btnCalib4.Text = "Reader 4";
            btnCalib4.Click += btnCalibrate_Click;
            // 
            // txtLog1
            // 
            txtLog1.BackColor = Color.Black;
            txtLog1.ForeColor = Color.Lime;
            txtLog1.Location = new Point(19, 136);
            txtLog1.Margin = new Padding(5, 5, 5, 5);
            txtLog1.Multiline = true;
            txtLog1.Name = "txtLog1";
            txtLog1.ReadOnly = true;
            txtLog1.ScrollBars = ScrollBars.Vertical;
            txtLog1.Size = new Size(909, 461);
            txtLog1.TabIndex = 8;
            // 
            // txtLog2
            // 
            txtLog2.BackColor = Color.Black;
            txtLog2.ForeColor = Color.Lime;
            txtLog2.Location = new Point(951, 136);
            txtLog2.Margin = new Padding(5, 5, 5, 5);
            txtLog2.Multiline = true;
            txtLog2.Name = "txtLog2";
            txtLog2.ReadOnly = true;
            txtLog2.ScrollBars = ScrollBars.Vertical;
            txtLog2.Size = new Size(909, 461);
            txtLog2.TabIndex = 10;
            // 
            // txtLog3
            // 
            txtLog3.BackColor = Color.Black;
            txtLog3.ForeColor = Color.Lime;
            txtLog3.Location = new Point(19, 637);
            txtLog3.Margin = new Padding(5, 5, 5, 5);
            txtLog3.Multiline = true;
            txtLog3.Name = "txtLog3";
            txtLog3.ReadOnly = true;
            txtLog3.ScrollBars = ScrollBars.Vertical;
            txtLog3.Size = new Size(909, 461);
            txtLog3.TabIndex = 12;
            // 
            // txtLog4
            // 
            txtLog4.BackColor = Color.Black;
            txtLog4.ForeColor = Color.Lime;
            txtLog4.Location = new Point(951, 637);
            txtLog4.Margin = new Padding(5, 5, 5, 5);
            txtLog4.Multiline = true;
            txtLog4.Name = "txtLog4";
            txtLog4.ReadOnly = true;
            txtLog4.ScrollBars = ScrollBars.Vertical;
            txtLog4.Size = new Size(909, 461);
            txtLog4.TabIndex = 14;
            // 
            // lblName1
            // 
            lblName1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName1.Location = new Point(19, 100);
            lblName1.Margin = new Padding(5, 0, 5, 0);
            lblName1.Name = "lblName1";
            lblName1.Size = new Size(236, 32);
            lblName1.TabIndex = 7;
            lblName1.Text = "Reader 1";
            // 
            // lblName2
            // 
            lblName2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName2.Location = new Point(951, 100);
            lblName2.Margin = new Padding(5, 0, 5, 0);
            lblName2.Name = "lblName2";
            lblName2.Size = new Size(236, 32);
            lblName2.TabIndex = 9;
            lblName2.Text = "Reader 2";
            // 
            // lblName3
            // 
            lblName3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName3.Location = new Point(19, 600);
            lblName3.Margin = new Padding(5, 0, 5, 0);
            lblName3.Name = "lblName3";
            lblName3.Size = new Size(236, 32);
            lblName3.TabIndex = 11;
            lblName3.Text = "Reader 3";
            // 
            // lblName4
            // 
            lblName4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName4.Location = new Point(951, 600);
            lblName4.Margin = new Padding(5, 0, 5, 0);
            lblName4.Name = "lblName4";
            lblName4.Size = new Size(236, 32);
            lblName4.TabIndex = 13;
            lblName4.Text = "Reader 4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 1124);
            Controls.Add(btnStartStop);
            Controls.Add(lblIndicator);
            Controls.Add(lblCalibTitle);
            Controls.Add(btnCalib1);
            Controls.Add(btnCalib2);
            Controls.Add(btnCalib3);
            Controls.Add(btnCalib4);
            Controls.Add(lblName1);
            Controls.Add(txtLog1);
            Controls.Add(lblName2);
            Controls.Add(txtLog2);
            Controls.Add(lblName3);
            Controls.Add(txtLog3);
            Controls.Add(lblName4);
            Controls.Add(txtLog4);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form1";
            Text = "Keyence Reader TCP 測試工具 (四機校正版)";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Label lblCalibTitle;
        private System.Windows.Forms.Button btnCalib1;
        private System.Windows.Forms.Button btnCalib2;
        private System.Windows.Forms.Button btnCalib3;
        private System.Windows.Forms.Button btnCalib4;
        private System.Windows.Forms.TextBox txtLog1;
        private System.Windows.Forms.TextBox txtLog2;
        private System.Windows.Forms.TextBox txtLog3;
        private System.Windows.Forms.TextBox txtLog4;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblName4;
    }
}
