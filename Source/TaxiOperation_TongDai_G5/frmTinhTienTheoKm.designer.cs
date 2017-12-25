namespace Taxi.GUI
{
    partial class frmTinhTienTheoKm
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
            this.tinhTienTheoKM_V21 = new Taxi.Controls.TinhTienTheoKM_V2();
            this.SuspendLayout();
            // 
            // tinhTienTheoKM_V21
            // 
            this.tinhTienTheoKM_V21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tinhTienTheoKM_V21.Location = new System.Drawing.Point(0, 0);
            this.tinhTienTheoKM_V21.Name = "tinhTienTheoKM_V21";
            this.tinhTienTheoKM_V21.Size = new System.Drawing.Size(532, 442);
            this.tinhTienTheoKM_V21.TabIndex = 0;
            // 
            // frmTinhTienTheoKm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 442);
            this.Controls.Add(this.tinhTienTheoKM_V21);
            this.Icon = global::TaxiOperation_TongDai.Properties.Resources.Taxi;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmTinhTienTheoKm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính tiền theo Km";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TinhTienTheoKM_V2 tinhTienTheoKM_V21;

    }
}