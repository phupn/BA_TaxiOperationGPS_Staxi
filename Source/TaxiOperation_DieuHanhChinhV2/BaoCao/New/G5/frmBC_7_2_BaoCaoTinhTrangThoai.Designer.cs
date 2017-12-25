namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    partial class frmBC_7_2_BaoCaoTinhTrangThoai
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
            this.grcBaoCaoCuocKhachTTDHDieuApp = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvBaoCaoCuocKhachTTDHDieuApp = new Taxi.Controls.Base.Controls.ShGridView();
            this.colViTri = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colTenNV = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colThoiDiemDangNhap = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colThoiGianDangNhap = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDaCoXeNhan = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colChuaCoXeNhan = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colChuaChuyenDam = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.Tổng = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDieuG5 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).BeginInit();
            this.pnInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).BeginInit();
            this.pnButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).BeginInit();
            this.pnOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoCuocKhachTTDHDieuApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoCuocKhachTTDHDieuApp)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Size = new System.Drawing.Size(722, 97);
            this.pnInputs.Visible = false;
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = null;
            this.ipToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = null;
            this.ipFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // pnButtons
            // 
            this.pnButtons.Size = new System.Drawing.Size(722, 52);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnThoat.Appearance.Options.UseFont = true;
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnTim.Appearance.Options.UseFont = true;
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.grcBaoCaoCuocKhachTTDHDieuApp);
            this.pnOutput.Size = new System.Drawing.Size(722, 259);
            // 
            // pnTitle
            // 
            this.pnTitle.Size = new System.Drawing.Size(722, 34);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            // 
            // grcBaoCaoCuocKhachTTDHDieuApp
            // 
            this.grcBaoCaoCuocKhachTTDHDieuApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcBaoCaoCuocKhachTTDHDieuApp.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcBaoCaoCuocKhachTTDHDieuApp.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcBaoCaoCuocKhachTTDHDieuApp.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcBaoCaoCuocKhachTTDHDieuApp.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcBaoCaoCuocKhachTTDHDieuApp.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcBaoCaoCuocKhachTTDHDieuApp.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcBaoCaoCuocKhachTTDHDieuApp.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcBaoCaoCuocKhachTTDHDieuApp.Location = new System.Drawing.Point(0, 0);
            this.grcBaoCaoCuocKhachTTDHDieuApp.MainView = this.grvBaoCaoCuocKhachTTDHDieuApp;
            this.grcBaoCaoCuocKhachTTDHDieuApp.Name = "grcBaoCaoCuocKhachTTDHDieuApp";
            this.grcBaoCaoCuocKhachTTDHDieuApp.Size = new System.Drawing.Size(722, 259);
            this.grcBaoCaoCuocKhachTTDHDieuApp.TabIndex = 7;
            this.grcBaoCaoCuocKhachTTDHDieuApp.UseEmbeddedNavigator = true;
            this.grcBaoCaoCuocKhachTTDHDieuApp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaoCaoCuocKhachTTDHDieuApp});
            // 
            // grvBaoCaoCuocKhachTTDHDieuApp
            // 
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.Row.Options.UseTextOptions = true;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvBaoCaoCuocKhachTTDHDieuApp.ColumnPanelRowHeight = 39;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colViTri,
            this.colTenNV,
            this.colThoiDiemDangNhap,
            this.colThoiGianDangNhap,
            this.colDaCoXeNhan,
            this.colChuaCoXeNhan,
            this.colChuaChuyenDam,
            this.Tổng,
            this.colDieuG5});
            this.grvBaoCaoCuocKhachTTDHDieuApp.GridControl = this.grcBaoCaoCuocKhachTTDHDieuApp;
            this.grvBaoCaoCuocKhachTTDHDieuApp.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.grvBaoCaoCuocKhachTTDHDieuApp.IndicatorWidth = 35;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Name = "grvBaoCaoCuocKhachTTDHDieuApp";
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsBehavior.Editable = false;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsFilter.AllowFilterEditor = false;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsFilter.AllowMRUFilterList = false;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsFind.AllowFindPanel = false;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsView.ShowGroupPanel = false;
            // 
            // colViTri
            // 
            this.colViTri.Caption = "Vị trí";
            this.colViTri.FieldName = "ViTri";
            this.colViTri.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colViTri.Name = "colViTri";
            this.colViTri.TagLanguage = null;
            this.colViTri.Visible = true;
            this.colViTri.VisibleIndex = 0;
            this.colViTri.Width = 41;
            // 
            // colTenNV
            // 
            this.colTenNV.Caption = "Tên NV";
            this.colTenNV.FieldName = "TenNV";
            this.colTenNV.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.TagLanguage = null;
            this.colTenNV.Visible = true;
            this.colTenNV.VisibleIndex = 1;
            this.colTenNV.Width = 104;
            // 
            // colThoiDiemDangNhap
            // 
            this.colThoiDiemDangNhap.Caption = "Thời điểm đăng nhập";
            this.colThoiDiemDangNhap.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.colThoiDiemDangNhap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colThoiDiemDangNhap.FieldName = "ThoiDiemDangNhap";
            this.colThoiDiemDangNhap.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colThoiDiemDangNhap.Name = "colThoiDiemDangNhap";
            this.colThoiDiemDangNhap.TagLanguage = null;
            this.colThoiDiemDangNhap.Visible = true;
            this.colThoiDiemDangNhap.VisibleIndex = 2;
            this.colThoiDiemDangNhap.Width = 121;
            // 
            // colThoiGianDangNhap
            // 
            this.colThoiGianDangNhap.Caption = "Thời gian đăng nhập";
            this.colThoiGianDangNhap.FieldName = "ThoiGianDangNhap";
            this.colThoiGianDangNhap.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colThoiGianDangNhap.Name = "colThoiGianDangNhap";
            this.colThoiGianDangNhap.TagLanguage = null;
            this.colThoiGianDangNhap.Visible = true;
            this.colThoiGianDangNhap.VisibleIndex = 3;
            this.colThoiGianDangNhap.Width = 92;
            // 
            // colDaCoXeNhan
            // 
            this.colDaCoXeNhan.Caption = "Đã có xe nhận";
            this.colDaCoXeNhan.FieldName = "DaCoXeNhan";
            this.colDaCoXeNhan.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDaCoXeNhan.Name = "colDaCoXeNhan";
            this.colDaCoXeNhan.TagLanguage = null;
            this.colDaCoXeNhan.Visible = true;
            this.colDaCoXeNhan.VisibleIndex = 4;
            this.colDaCoXeNhan.Width = 59;
            // 
            // colChuaCoXeNhan
            // 
            this.colChuaCoXeNhan.Caption = "Chưa có xe nhận";
            this.colChuaCoXeNhan.FieldName = "ChuaCoXeNhan";
            this.colChuaCoXeNhan.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colChuaCoXeNhan.Name = "colChuaCoXeNhan";
            this.colChuaCoXeNhan.TagLanguage = null;
            this.colChuaCoXeNhan.Visible = true;
            this.colChuaCoXeNhan.VisibleIndex = 5;
            this.colChuaCoXeNhan.Width = 56;
            // 
            // colChuaChuyenDam
            // 
            this.colChuaChuyenDam.Caption = "Chưa chuyển đàm";
            this.colChuaChuyenDam.FieldName = "ChuaChuyenDam";
            this.colChuaChuyenDam.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colChuaChuyenDam.Name = "colChuaChuyenDam";
            this.colChuaChuyenDam.TagLanguage = null;
            this.colChuaChuyenDam.Visible = true;
            this.colChuaChuyenDam.VisibleIndex = 6;
            this.colChuaChuyenDam.Width = 79;
            // 
            // Tổng
            // 
            this.Tổng.Caption = "Tổng";
            this.Tổng.FieldName = "Tong";
            this.Tổng.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.Tổng.Name = "Tổng";
            this.Tổng.TagLanguage = null;
            this.Tổng.Visible = true;
            this.Tổng.VisibleIndex = 7;
            this.Tổng.Width = 52;
            // 
            // colDieuG5
            // 
            this.colDieuG5.AppearanceCell.Options.UseTextOptions = true;
            this.colDieuG5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDieuG5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDieuG5.Caption = "Điều G5";
            this.colDieuG5.FieldName = "DieuG5";
            this.colDieuG5.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDieuG5.Name = "colDieuG5";
            this.colDieuG5.TagLanguage = null;
            this.colDieuG5.Visible = true;
            this.colDieuG5.VisibleIndex = 8;
            this.colDieuG5.Width = 81;
            // 
            // frmBC_7_2_BaoCaoTinhTrangThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 442);
            this.Name = "frmBC_7_2_BaoCaoTinhTrangThoai";
            this.Text = "frmBC_7_2_BaoCaoTinhTrangThoai";
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).EndInit();
            this.pnInputs.ResumeLayout(false);
            this.pnInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).EndInit();
            this.pnButtons.ResumeLayout(false);
            this.pnButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).EndInit();
            this.pnOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoCuocKhachTTDHDieuApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoCuocKhachTTDHDieuApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl grcBaoCaoCuocKhachTTDHDieuApp;
        private Taxi.Controls.Base.Controls.ShGridView grvBaoCaoCuocKhachTTDHDieuApp;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colViTri;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colTenNV;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colThoiDiemDangNhap;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colThoiGianDangNhap;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDaCoXeNhan;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colChuaCoXeNhan;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colChuaChuyenDam;
        private Taxi.Controls.Base.Controls.Grids.GridColumn Tổng;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDieuG5;
    }
}