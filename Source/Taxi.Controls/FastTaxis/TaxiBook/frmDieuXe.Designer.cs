using Taxi.Controls.FastTaxis.TaxiBook;

namespace Taxi.Controls.FastTaxis.TaxiDieuXe
{
    partial class frmDieuXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuXe));
            this.ctrl_DieuXe = new Taxi.Controls.FastTaxis.TaxiBook.ctrlListBook();
            this.SuspendLayout();
            // 
            // ctrl_DieuXe
            // 
            this.ctrl_DieuXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrl_DieuXe.IsDieuXe = true;
            this.ctrl_DieuXe.Location = new System.Drawing.Point(0, 0);
            this.ctrl_DieuXe.Name = "ctrl_DieuXe";
            this.ctrl_DieuXe.Size = new System.Drawing.Size(929, 553);
            this.ctrl_DieuXe.TabIndex = 0;
            this.ctrl_DieuXe.VisitSearch = true;
            this.ctrl_DieuXe.DoubleClick += new System.EventHandler(this.ctrlDieuXe1_DoubleClick);
            // 
            // frmDieuXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 553);
            this.Controls.Add(this.ctrl_DieuXe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDieuXe";
            this.Text = "frmDieuXe";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlListBook ctrl_DieuXe;

    }
}