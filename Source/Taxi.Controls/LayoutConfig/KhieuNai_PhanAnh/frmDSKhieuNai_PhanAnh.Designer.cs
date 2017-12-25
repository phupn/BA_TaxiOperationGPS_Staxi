namespace Taxi.Controls.KhieuNai_PhanAnh
{
    partial class frmDSKhieuNai_PhanAnh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSKhieuNai_PhanAnh));
            this.ctrlDSKhieuNai1 = new Taxi.Controls.KhieuNai_PhanAnh.ctrlDSKhieuNai();
            this.SuspendLayout();
            // 
            // ctrlDSKhieuNai1
            // 
            this.ctrlDSKhieuNai1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDSKhieuNai1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDSKhieuNai1.Name = "ctrlDSKhieuNai1";
            this.ctrlDSKhieuNai1.Size = new System.Drawing.Size(934, 561);
            this.ctrlDSKhieuNai1.TabIndex = 0;
            // 
            // frmDSKhieuNai_PhanAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.ctrlDSKhieuNai1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDSKhieuNai_PhanAnh";
            this.Text = "Danh sách khiếu nại - phản ánh của KH";
            this.Load += new System.EventHandler(this.frmDSKhieuNai_PhanAnh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDSKhieuNai ctrlDSKhieuNai1;
    }
}