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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.lblCalibTitle = new System.Windows.Forms.Label();
            this.btnCalib1 = new System.Windows.Forms.Button();
            this.btnCalib2 = new System.Windows.Forms.Button();
            this.btnCalib3 = new System.Windows.Forms.Button();
            this.btnCalib4 = new System.Windows.Forms.Button();
            
            this.txtLog1 = new System.Windows.Forms.TextBox();
            this.txtLog2 = new System.Windows.Forms.TextBox();
            this.txtLog3 = new System.Windows.Forms.TextBox();
            this.txtLog4 = new System.Windows.Forms.TextBox();
            
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.lblName4 = new System.Windows.Forms.Label();
            
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 12);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(120, 40);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "啟動測試";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblIndicator
            // 
            this.lblIndicator.BackColor = System.Drawing.Color.Gray;
            this.lblIndicator.Location = new System.Drawing.Point(145, 20);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(25, 25);
            this.lblIndicator.TabIndex = 1;
            // 
            // lblCalibTitle
            // 
            this.lblCalibTitle.AutoSize = true;
            this.lblCalibTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCalibTitle.Location = new System.Drawing.Point(220, 22);
            this.lblCalibTitle.Name = "lblCalibTitle";
            this.lblCalibTitle.Size = new System.Drawing.Size(58, 21);
            this.lblCalibTitle.Text = "校正：";
            // 
            // btnCalib1
            // 
            this.btnCalib1.Location = new System.Drawing.Point(280, 15);
            this.btnCalib1.Name = "btnCalib1";
            this.btnCalib1.Size = new System.Drawing.Size(100, 35);
            this.btnCalib1.Text = "Reader 1";
            this.btnCalib1.Tag = 0;
            this.btnCalib1.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnCalib2
            // 
            this.btnCalib2.Location = new System.Drawing.Point(385, 15);
            this.btnCalib2.Name = "btnCalib2";
            this.btnCalib2.Size = new System.Drawing.Size(100, 35);
            this.btnCalib2.Text = "Reader 2";
            this.btnCalib2.Tag = 1;
            this.btnCalib2.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnCalib3
            // 
            this.btnCalib3.Location = new System.Drawing.Point(490, 15);
            this.btnCalib3.Name = "btnCalib3";
            this.btnCalib3.Size = new System.Drawing.Size(100, 35);
            this.btnCalib3.Text = "Reader 3";
            this.btnCalib3.Tag = 2;
            this.btnCalib3.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnCalib4
            // 
            this.btnCalib4.Location = new System.Drawing.Point(595, 15);
            this.btnCalib4.Name = "btnCalib4";
            this.btnCalib4.Size = new System.Drawing.Size(100, 35);
            this.btnCalib4.Text = "Reader 4";
            this.btnCalib4.Tag = 3;
            this.btnCalib4.Click += new System.EventHandler(this.btnCalibrate_Click);

            // Row 1
            this.lblName1.Location = new System.Drawing.Point(12, 65);
            this.lblName1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName1.Size = new System.Drawing.Size(150, 21);
            this.lblName1.Text = "Reader 1";
            
            this.txtLog1.Location = new System.Drawing.Point(12, 89);
            this.txtLog1.Size = new System.Drawing.Size(580, 350);
            this.txtLog1.Multiline = true;
            this.txtLog1.ReadOnly = true;
            this.txtLog1.BackColor = System.Drawing.Color.Black;
            this.txtLog1.ForeColor = System.Drawing.Color.Lime;
            this.txtLog1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.lblName2.Location = new System.Drawing.Point(605, 65);
            this.lblName2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName2.Size = new System.Drawing.Size(150, 21);
            this.lblName2.Text = "Reader 2";
            
            this.txtLog2.Location = new System.Drawing.Point(605, 89);
            this.txtLog2.Size = new System.Drawing.Size(580, 350);
            this.txtLog2.Multiline = true;
            this.txtLog2.ReadOnly = true;
            this.txtLog2.BackColor = System.Drawing.Color.Black;
            this.txtLog2.ForeColor = System.Drawing.Color.Lime;
            this.txtLog2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // Row 2
            this.lblName3.Location = new System.Drawing.Point(12, 455);
            this.lblName3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName3.Size = new System.Drawing.Size(150, 21);
            this.lblName3.Text = "Reader 3";
            
            this.txtLog3.Location = new System.Drawing.Point(12, 479);
            this.txtLog3.Size = new System.Drawing.Size(580, 350);
            this.txtLog3.Multiline = true;
            this.txtLog3.ReadOnly = true;
            this.txtLog3.BackColor = System.Drawing.Color.Black;
            this.txtLog3.ForeColor = System.Drawing.Color.Lime;
            this.txtLog3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.lblName4.Location = new System.Drawing.Point(605, 455);
            this.lblName4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName4.Size = new System.Drawing.Size(150, 21);
            this.lblName4.Text = "Reader 4";
            
            this.txtLog4.Location = new System.Drawing.Point(605, 479);
            this.txtLog4.Size = new System.Drawing.Size(580, 350);
            this.txtLog4.Multiline = true;
            this.txtLog4.ReadOnly = true;
            this.txtLog4.BackColor = System.Drawing.Color.Black;
            this.txtLog4.ForeColor = System.Drawing.Color.Lime;
            this.txtLog4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 850);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.lblCalibTitle);
            this.Controls.Add(this.btnCalib1);
            this.Controls.Add(this.btnCalib2);
            this.Controls.Add(this.btnCalib3);
            this.Controls.Add(this.btnCalib4);
            this.Controls.Add(this.lblName1);
            this.Controls.Add(this.txtLog1);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.txtLog2);
            this.Controls.Add(this.lblName3);
            this.Controls.Add(this.txtLog3);
            this.Controls.Add(this.lblName4);
            this.Controls.Add(this.txtLog4);
            this.Name = "Form1";
            this.Text = "Keyence Reader TCP 測試工具 (四機校正版)";
            this.ResumeLayout(false);
            this.PerformLayout();
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
