namespace TaxiOperation_DieuHanhChinh.DM
{
    partial class frmLoaiPhanAnh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiPhanAnh));
            this.lbPhanAnh = new System.Windows.Forms.Label();
            this.txtTenPhanAnh = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPhanAnh
            // 
            this.lbPhanAnh.AutoSize = true;
            this.lbPhanAnh.Location = new System.Drawing.Point(3, 21);
            this.lbPhanAnh.Name = "lbPhanAnh";
            this.lbPhanAnh.Size = new System.Drawing.Size(99, 13);
            this.lbPhanAnh.TabIndex = 0;
            this.lbPhanAnh.Text = "Tên loại phản ánh :";
            // 
            // txtTenPhanAnh
            // 
            this.txtTenPhanAnh.Location = new System.Drawing.Point(108, 18);
            this.txtTenPhanAnh.Name = "txtTenPhanAnh";
            this.txtTenPhanAnh.Size = new System.Drawing.Size(357, 20);
            this.txtTenPhanAnh.TabIndex = 1;
            this.txtTenPhanAnh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenPhanAnh_KeyDown);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(235, 44);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(86, 30);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "&Cập nhật";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnLuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLuu_KeyDown);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Close;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(348, 44);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmLoaiPhanAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 86);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTenPhanAnh);
            this.Controls.Add(this.lbPhanAnh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoaiPhanAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loại phản ánh";
            this.Load += new System.EventHandler(this.frmLoaiPhanAnh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPhanAnh;
        private System.Windows.Forms.TextBox txtTenPhanAnh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}