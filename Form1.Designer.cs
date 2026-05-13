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
            this.txtLogLeft = new System.Windows.Forms.TextBox();
            this.txtLogRight = new System.Windows.Forms.TextBox();
            this.lblNameLeft = new System.Windows.Forms.Label();
            this.lblNameRight = new System.Windows.Forms.Label();
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
            // lblNameLeft
            // 
            this.lblNameLeft.AutoSize = true;
            this.lblNameLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNameLeft.Location = new System.Drawing.Point(12, 65);
            this.lblNameLeft.Name = "lblNameLeft";
            this.lblNameLeft.Size = new System.Drawing.Size(81, 21);
            this.lblNameLeft.TabIndex = 3;
            this.lblNameLeft.Text = "Reader 1";
            // 
            // lblNameRight
            // 
            this.lblNameRight.AutoSize = true;
            this.lblNameRight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNameRight.Location = new System.Drawing.Point(408, 65);
            this.lblNameRight.Name = "lblNameRight";
            this.lblNameRight.Size = new System.Drawing.Size(81, 21);
            this.lblNameRight.TabIndex = 4;
            this.lblNameRight.Text = "Reader 2";
            // 
            // txtLogLeft
            // 
            this.txtLogLeft.BackColor = System.Drawing.Color.Black;
            this.txtLogLeft.ForeColor = System.Drawing.Color.Lime;
            this.txtLogLeft.Location = new System.Drawing.Point(12, 89);
            this.txtLogLeft.Multiline = true;
            this.txtLogLeft.Name = "txtLogLeft";
            this.txtLogLeft.ReadOnly = true;
            this.txtLogLeft.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogLeft.Size = new System.Drawing.Size(380, 460);
            this.txtLogLeft.TabIndex = 2;
            // 
            // txtLogRight
            // 
            this.txtLogRight.BackColor = System.Drawing.Color.Black;
            this.txtLogRight.ForeColor = System.Drawing.Color.Lime;
            this.txtLogRight.Location = new System.Drawing.Point(408, 89);
            this.txtLogRight.Multiline = true;
            this.txtLogRight.Name = "txtLogRight";
            this.txtLogRight.ReadOnly = true;
            this.txtLogRight.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogRight.Size = new System.Drawing.Size(380, 460);
            this.txtLogRight.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.lblNameRight);
            this.Controls.Add(this.txtLogRight);
            this.Controls.Add(this.lblNameLeft);
            this.Controls.Add(this.txtLogLeft);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.btnStartStop);
            this.Name = "Form1";
            this.Text = "Keyence Reader TCP 測試工具 (多機版)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.TextBox txtLogLeft;
        private System.Windows.Forms.TextBox txtLogRight;
        private System.Windows.Forms.Label lblNameLeft;
        private System.Windows.Forms.Label lblNameRight;
    }
}
