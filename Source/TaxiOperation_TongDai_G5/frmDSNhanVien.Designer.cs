namespace Taxi.GUI
{
    partial class frmDSNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSNhanVien));
            this.ucDSLaiXe1 = new Taxi.Controls.ucDSLaiXe();
            this.SuspendLayout();
            // 
            // ucDSLaiXe1
            // 
            this.ucDSLaiXe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDSLaiXe1.Location = new System.Drawing.Point(0, 0);
            this.ucDSLaiXe1.Name = "ucDSLaiXe1";
            this.ucDSLaiXe1.Size = new System.Drawing.Size(652, 397);
            this.ucDSLaiXe1.TabIndex = 1;
            // 
            // frmDSNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 397);
            this.Controls.Add(this.ucDSLaiXe1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDSNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách  lái xe";
            this.Load += new System.EventHandler(this.frmDSNhanVien_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private Controls.ucDSLaiXe ucDSLaiXe1;
    }
}