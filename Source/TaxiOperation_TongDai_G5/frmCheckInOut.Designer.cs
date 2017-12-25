namespace Taxi.GUI
{
    partial class frmCheckInOut
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
            this.ctrlCheckInCheckOut = new Taxi.Controls.CheckInCheckOut();
            this.SuspendLayout();
            // 
            // ctrlCheckInCheckOut
            // 
            this.ctrlCheckInCheckOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCheckInCheckOut.g_Success = false;
            this.ctrlCheckInCheckOut.Location = new System.Drawing.Point(0, 0);
            this.ctrlCheckInCheckOut.Name = "ctrlCheckInCheckOut";
            this.ctrlCheckInCheckOut.Size = new System.Drawing.Size(404, 285);
            this.ctrlCheckInCheckOut.TabIndex = 0;
            // 
            // frmCheckInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 285);
            this.Controls.Add(this.ctrlCheckInCheckOut);
            this.Icon = global::TaxiOperation_TongDai.Properties.Resources.Taxi;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckInOut_FormClosing);
            this.Load += new System.EventHandler(this.frmCheckInOut_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CheckInCheckOut ctrlCheckInCheckOut;


    }
}