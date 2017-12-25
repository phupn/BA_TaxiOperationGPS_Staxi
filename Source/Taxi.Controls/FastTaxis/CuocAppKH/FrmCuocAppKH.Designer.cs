namespace Taxi.Controls.FastTaxis.CuocAppKH
{
    partial class FrmCuocAppKH
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
            this.uc_CuocAppKH1 = new Taxi.Controls.FastTaxis.CuocAppKH.uc_CuocAppKH();
            this.SuspendLayout();
            // 
            // uc_CuocAppKH1
            // 
            this.uc_CuocAppKH1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_CuocAppKH1.Location = new System.Drawing.Point(0, 0);
            this.uc_CuocAppKH1.Name = "uc_CuocAppKH1";
            this.uc_CuocAppKH1.Size = new System.Drawing.Size(1027, 653);
            this.uc_CuocAppKH1.TabIndex = 0;            
            // 
            // FrmCuocAppKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 653);
            this.Controls.Add(this.uc_CuocAppKH1);
            this.Name = "FrmCuocAppKH";
            this.Text = "Cuốc đặt từ App KH";
            this.Load += new System.EventHandler(this.FrmCuocAppKH_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_CuocAppKH uc_CuocAppKH1;
    }
}