namespace Taxi.GUI
{
    partial class frmDMKieuKhachHangPhanAnh
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMKieuKhachHangPhanAnh));
            this.grdDSKieuKhachHangPhanAnh = new Janus.Windows.GridEX.GridEX();
            this.lnkThemMoi = new System.Windows.Forms.LinkLabel();
            this.lnkSua = new System.Windows.Forms.LinkLabel();
            this.lnkXoa = new System.Windows.Forms.LinkLabel();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSKieuKhachHangPhanAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDSKieuKhachHangPhanAnh
            // 
            this.grdDSKieuKhachHangPhanAnh.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID=\"\" /></RootTable></GridEXLayoutDa" +
                "ta>";
            this.grdDSKieuKhachHangPhanAnh.DesignTimeLayout = gridEXLayout1;
            this.grdDSKieuKhachHangPhanAnh.GroupByBoxVisible = false;
            this.grdDSKieuKhachHangPhanAnh.Location = new System.Drawing.Point(12, 12);
            this.grdDSKieuKhachHangPhanAnh.Name = "grdDSKieuKhachHangPhanAnh";
            this.grdDSKieuKhachHangPhanAnh.SaveSettings = false;
            this.grdDSKieuKhachHangPhanAnh.Size = new System.Drawing.Size(374, 393);
            this.grdDSKieuKhachHangPhanAnh.TabIndex = 0;
            // 
            // lnkThemMoi
            // 
            this.lnkThemMoi.AutoSize = true;
            this.lnkThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkThemMoi.Location = new System.Drawing.Point(258, 418);
            this.lnkThemMoi.Name = "lnkThemMoi";
            this.lnkThemMoi.Size = new System.Drawing.Size(61, 13);
            this.lnkThemMoi.TabIndex = 1;
            this.lnkThemMoi.TabStop = true;
            this.lnkThemMoi.Text = "Thêm mới";
            // 
            // lnkSua
            // 
            this.lnkSua.AutoSize = true;
            this.lnkSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSua.Location = new System.Drawing.Point(325, 418);
            this.lnkSua.Name = "lnkSua";
            this.lnkSua.Size = new System.Drawing.Size(29, 13);
            this.lnkSua.TabIndex = 2;
            this.lnkSua.TabStop = true;
            this.lnkSua.Text = "Sửa";
            // 
            // lnkXoa
            // 
            this.lnkXoa.AutoSize = true;
            this.lnkXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkXoa.Location = new System.Drawing.Point(360, 418);
            this.lnkXoa.Name = "lnkXoa";
            this.lnkXoa.Size = new System.Drawing.Size(29, 13);
            this.lnkXoa.TabIndex = 3;
            this.lnkXoa.TabStop = true;
            this.lnkXoa.Text = "Xóa";
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(390, 162);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(69, 23);
            this.uiButton1.TabIndex = 4;
            this.uiButton1.Text = "Lên";
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(390, 191);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(69, 23);
            this.uiButton2.TabIndex = 5;
            this.uiButton2.Text = "Xuống";
            // 
            // frmDMKieuKhachHangPhanAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 440);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.lnkXoa);
            this.Controls.Add(this.lnkSua);
            this.Controls.Add(this.lnkThemMoi);
            this.Controls.Add(this.grdDSKieuKhachHangPhanAnh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMKieuKhachHangPhanAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục kiểu khách hàng phản anh";
            this.Load += new System.EventHandler(this.frmDMKieuKhachHangPhanAnh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDSKieuKhachHangPhanAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdDSKieuKhachHangPhanAnh;
        private System.Windows.Forms.LinkLabel lnkThemMoi;
        private System.Windows.Forms.LinkLabel lnkSua;
        private System.Windows.Forms.LinkLabel lnkXoa;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
    }
}