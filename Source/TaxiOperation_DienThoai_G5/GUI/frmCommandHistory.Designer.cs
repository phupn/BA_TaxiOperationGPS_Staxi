namespace TaxiApplication.GUI
{
    partial class frmCommandHistory
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
            this.ctrlListCommandHistory = new Taxi.Controls.Commands.ctrlListCommandHistory();
            this.SuspendLayout();
            // 
            // ctrlListCommandHistory
            // 
            this.ctrlListCommandHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListCommandHistory.Location = new System.Drawing.Point(0, 0);
            this.ctrlListCommandHistory.Name = "ctrlListCommandHistory";
            this.ctrlListCommandHistory.Size = new System.Drawing.Size(409, 212);
            this.ctrlListCommandHistory.TabIndex = 0;
            // 
            // frmCommandHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 212);
            this.ControlBox = false;
            this.Controls.Add(this.ctrlListCommandHistory);
            this.Name = "frmCommandHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Lệnh đã gửi cho lái xe";
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Commands.ctrlListCommandHistory ctrlListCommandHistory;
    }
}