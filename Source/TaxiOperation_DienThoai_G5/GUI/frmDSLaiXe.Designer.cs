namespace TaxiApplication.GUI
{
    partial class frmDSLaiXe
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
            this.panControl = new Taxi.Controls.Base.Controls.ShPanel();
            this.ucDSLaiXe = new Taxi.Controls.ucDSLaiXe();
            ((System.ComponentModel.ISupportInitialize)(this.panControl)).BeginInit();
            this.panControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panControl
            // 
            this.panControl.Controls.Add(this.ucDSLaiXe);
            this.panControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panControl.LabelMessage = null;
            this.panControl.Location = new System.Drawing.Point(0, 0);
            this.panControl.Name = "panControl";
            this.panControl.Size = new System.Drawing.Size(755, 426);
            this.panControl.TabIndex = 1;
            // 
            // ucDSLaiXe
            // 
            this.ucDSLaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDSLaiXe.Location = new System.Drawing.Point(2, 2);
            this.ucDSLaiXe.Name = "ucDSLaiXe";
            this.ucDSLaiXe.Size = new System.Drawing.Size(751, 422);
            this.ucDSLaiXe.TabIndex = 0;
            // 
            // frmDSLaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 426);
            this.Controls.Add(this.panControl);
            this.Name = "frmDSLaiXe";
            this.Text = "Danh sách lái xe";
            this.Load += new System.EventHandler(this.frmDSLaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panControl)).EndInit();
            this.panControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShPanel panControl;
        private Taxi.Controls.ucDSLaiXe ucDSLaiXe;
    }
}