namespace Taxi.GUI
{
    partial class frmDangGoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSoGoi = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // lblSoGoi
            // 
            this.lblSoGoi.AutoSize = true;
            this.lblSoGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoGoi.ForeColor = System.Drawing.Color.Blue;
            this.lblSoGoi.Location = new System.Drawing.Point(12, 9);
            this.lblSoGoi.Name = "lblSoGoi";
            this.lblSoGoi.Size = new System.Drawing.Size(81, 20);
            this.lblSoGoi.TabIndex = 0;
            this.lblSoGoi.Text = "Đang gọi :";
            // 
            // frmDangGoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(638, 50);
            this.ControlBox = false;
            this.Controls.Add(this.lblSoGoi);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangGoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đang gọi ...";
            this.Load += new System.EventHandler(this.frmDangGoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  System.Windows.Forms.Label lblSoGoi;
        private System.IO.Ports.SerialPort serialPort1;
    }
}