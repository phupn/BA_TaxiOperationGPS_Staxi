namespace Taxi.Controls
{
    partial class XeLienLacControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSoHieuXe = new System.Windows.Forms.Label();
            this.lblThoiGianLienLacCuoi = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.lblTongDaiDaLienLacLanCuoi = new System.Windows.Forms.Label();
            this.lblViTri = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSoHieuXe
            // 
            this.lblSoHieuXe.AutoSize = true;
            this.lblSoHieuXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHieuXe.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblSoHieuXe.Location = new System.Drawing.Point(10, -1);
            this.lblSoHieuXe.Name = "lblSoHieuXe";
            this.lblSoHieuXe.Size = new System.Drawing.Size(35, 17);
            this.lblSoHieuXe.TabIndex = 0;
            this.lblSoHieuXe.Text = "123";
            this.lblSoHieuXe.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // lblThoiGianLienLacCuoi
            // 
            this.lblThoiGianLienLacCuoi.AutoSize = true;
            this.lblThoiGianLienLacCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianLienLacCuoi.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblThoiGianLienLacCuoi.Location = new System.Drawing.Point(-2, 18);
            this.lblThoiGianLienLacCuoi.Name = "lblThoiGianLienLacCuoi";
            this.lblThoiGianLienLacCuoi.Size = new System.Drawing.Size(28, 12);
            this.lblThoiGianLienLacCuoi.TabIndex = 1;
            this.lblThoiGianLienLacCuoi.Text = "14:05";
            this.lblThoiGianLienLacCuoi.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.lblSoHieuXe);
            this.panel.Controls.Add(this.lblThoiGianLienLacCuoi);
            this.panel.Controls.Add(this.lblTongDaiDaLienLacLanCuoi);
            this.panel.Controls.Add(this.lblViTri);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(52, 46);
            this.panel.TabIndex = 2;
            this.panel.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // lblTongDaiDaLienLacLanCuoi
            // 
            this.lblTongDaiDaLienLacLanCuoi.AutoSize = true;
            this.lblTongDaiDaLienLacLanCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDaiDaLienLacLanCuoi.Location = new System.Drawing.Point(26, 18);
            this.lblTongDaiDaLienLacLanCuoi.Name = "lblTongDaiDaLienLacLanCuoi";
            this.lblTongDaiDaLienLacLanCuoi.Size = new System.Drawing.Size(28, 12);
            this.lblTongDaiDaLienLacLanCuoi.TabIndex = 3;
            this.lblTongDaiDaLienLacLanCuoi.Text = "15:05";
            this.lblTongDaiDaLienLacLanCuoi.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // lblViTri
            // 
            this.lblViTri.AutoSize = true;
            this.lblViTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViTri.Location = new System.Drawing.Point(-2, 29);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(55, 13);
            this.lblViTri.TabIndex = 4;
            this.lblViTri.Text = "vi tri baogl";
            this.lblViTri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblViTri.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // XeLienLacControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "XeLienLacControl";
            this.Size = new System.Drawing.Size(52, 46);
            this.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSoHieuXe;
        private System.Windows.Forms.Label lblThoiGianLienLacCuoi;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblTongDaiDaLienLacLanCuoi;
        private System.Windows.Forms.Label lblViTri;
    }
}
