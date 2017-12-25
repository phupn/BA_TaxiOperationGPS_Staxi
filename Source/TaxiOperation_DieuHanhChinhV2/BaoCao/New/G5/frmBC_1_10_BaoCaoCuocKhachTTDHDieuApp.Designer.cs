namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    partial class frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp));
            this.panTop = new Taxi.Controls.Base.Controls.ShPanel();
            this.panHeader = new Taxi.Controls.Base.Controls.ShPanel();
            this.dtpDenNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuatExcel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLamMoi = new Taxi.Controls.Base.Controls.ShButton();
            this.lblDenNgay = new Taxi.Controls.Base.Controls.ShLabel();
            this.dtpTuNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.lblTuNgay = new Taxi.Controls.Base.Controls.ShLabel();
            this.panelInput2 = new Taxi.Controls.Base.Controls.ShPanel();
            this.grcBaoCaoCuocKhachTTDHDieuApp = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvBaoCaoCuocKhachTTDHDieuApp = new Taxi.Controls.Base.Controls.ShGridView();
            this.colSoCuocGoiTaxiTTDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCuocTTDHDieuApp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCuocLXNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCuocTraLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonDuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTruotHoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXeDungDiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppKhongPhanHoiDaGapKhach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhanTramDonDuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panTop)).BeginInit();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panHeader)).BeginInit();
            this.panHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput2)).BeginInit();
            this.panelInput2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoCuocKhachTTDHDieuApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoCuocKhachTTDHDieuApp)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.panHeader);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.LabelMessage = null;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(889, 113);
            this.panTop.TabIndex = 0;
            // 
            // panHeader
            // 
            this.panHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panHeader.Controls.Add(this.dtpDenNgay);
            this.panHeader.Controls.Add(this.label1);
            this.panHeader.Controls.Add(this.btnXuatExcel);
            this.panHeader.Controls.Add(this.btnLamMoi);
            this.panHeader.Controls.Add(this.lblDenNgay);
            this.panHeader.Controls.Add(this.dtpTuNgay);
            this.panHeader.Controls.Add(this.lblTuNgay);
            this.panHeader.LabelMessage = null;
            this.panHeader.Location = new System.Drawing.Point(236, 2);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(416, 109);
            this.panHeader.TabIndex = 5;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.DateNowWhenLoad = true;
            this.dtpDenNgay.EditValue = new System.DateTime(2016, 1, 20, 8, 15, 14, 312);
            this.dtpDenNgay.IsChangeText = false;
            this.dtpDenNgay.IsFocus = false;
            this.dtpDenNgay.Location = new System.Drawing.Point(261, 36);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDenNgay.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dtpDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDenNgay.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dtpDenNgay.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.dtpDenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDenNgay.Size = new System.Drawing.Size(126, 20);
            this.dtpDenNgay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "BÁO CÁO CUỐC KHÁCH TTĐH ĐIỀU APP";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Enabled = false;
            this.btnXuatExcel.KeyCommand = System.Windows.Forms.Keys.F4;
            this.btnXuatExcel.Location = new System.Drawing.Point(211, 71);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(92, 23);
            this.btnXuatExcel.TabIndex = 4;
            this.btnXuatExcel.Text = "Xuất Excel(F4)";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.KeyCommand = System.Windows.Forms.Keys.F5;
            this.btnLamMoi.Location = new System.Drawing.Point(113, 71);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(92, 23);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới(F5)";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Location = new System.Drawing.Point(208, 40);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(47, 13);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.DateNowWhenLoad = true;
            this.dtpTuNgay.EditValue = new System.DateTime(2016, 1, 20, 8, 15, 14, 312);
            this.dtpTuNgay.IsChangeText = false;
            this.dtpTuNgay.IsFocus = true;
            this.dtpTuNgay.Location = new System.Drawing.Point(76, 36);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTuNgay.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dtpTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpTuNgay.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dtpTuNgay.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.dtpTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpTuNgay.Size = new System.Drawing.Size(126, 20);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Location = new System.Drawing.Point(30, 40);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(40, 13);
            this.lblTuNgay.TabIndex = 3;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // panelInput2
            // 
            this.panelInput2.Controls.Add(this.grcBaoCaoCuocKhachTTDHDieuApp);
            this.panelInput2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput2.LabelMessage = null;
            this.panelInput2.Location = new System.Drawing.Point(0, 113);
            this.panelInput2.Name = "panelInput2";
            this.panelInput2.Size = new System.Drawing.Size(889, 387);
            this.panelInput2.TabIndex = 1;
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
            this.grcBaoCaoCuocKhachTTDHDieuApp.Location = new System.Drawing.Point(2, 2);
            this.grcBaoCaoCuocKhachTTDHDieuApp.MainView = this.grvBaoCaoCuocKhachTTDHDieuApp;
            this.grcBaoCaoCuocKhachTTDHDieuApp.Name = "grcBaoCaoCuocKhachTTDHDieuApp";
            this.grcBaoCaoCuocKhachTTDHDieuApp.Size = new System.Drawing.Size(885, 383);
            this.grcBaoCaoCuocKhachTTDHDieuApp.TabIndex = 5;
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
            this.grvBaoCaoCuocKhachTTDHDieuApp.ColumnPanelRowHeight = 50;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colSoCuocGoiTaxiTTDH,
            this.colSoCuocTTDHDieuApp,
            this.colSoCuocLXNhan,
            this.colSoCuocTraLai,
            this.colDonDuoc,
            this.colTruotHoan,
            this.colXeDungDiem,
            this.colAppKhongPhanHoiDaGapKhach,
            this.colPhanTramDonDuoc});
            this.grvBaoCaoCuocKhachTTDHDieuApp.GridControl = this.grcBaoCaoCuocKhachTTDHDieuApp;
            this.grvBaoCaoCuocKhachTTDHDieuApp.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.grvBaoCaoCuocKhachTTDHDieuApp.IndicatorWidth = 35;
            this.grvBaoCaoCuocKhachTTDHDieuApp.Name = "grvBaoCaoCuocKhachTTDHDieuApp";
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsBehavior.Editable = false;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsView.ShowFooter = true;
            this.grvBaoCaoCuocKhachTTDHDieuApp.OptionsView.ShowGroupPanel = false;
            // 
            // colSoCuocGoiTaxiTTDH
            // 
            this.colSoCuocGoiTaxiTTDH.Caption = "Số cuốc gọi Taxi TTĐH ";
            this.colSoCuocGoiTaxiTTDH.FieldName = "CuocGoiTaxiTTDH";
            this.colSoCuocGoiTaxiTTDH.Name = "colSoCuocGoiTaxiTTDH";
            this.colSoCuocGoiTaxiTTDH.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colSoCuocGoiTaxiTTDH.Visible = true;
            this.colSoCuocGoiTaxiTTDH.VisibleIndex = 1;
            this.colSoCuocGoiTaxiTTDH.Width = 74;
            // 
            // colSoCuocTTDHDieuApp
            // 
            this.colSoCuocTTDHDieuApp.Caption = "Số cuốc TTĐH điều app";
            this.colSoCuocTTDHDieuApp.FieldName = "CuocTTDHDieuApp";
            this.colSoCuocTTDHDieuApp.Name = "colSoCuocTTDHDieuApp";
            this.colSoCuocTTDHDieuApp.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colSoCuocTTDHDieuApp.Visible = true;
            this.colSoCuocTTDHDieuApp.VisibleIndex = 2;
            this.colSoCuocTTDHDieuApp.Width = 73;
            // 
            // colSoCuocLXNhan
            // 
            this.colSoCuocLXNhan.Caption = "Số cuốc LX nhận";
            this.colSoCuocLXNhan.FieldName = "SoCuocLXNhan";
            this.colSoCuocLXNhan.Name = "colSoCuocLXNhan";
            this.colSoCuocLXNhan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colSoCuocLXNhan.Visible = true;
            this.colSoCuocLXNhan.VisibleIndex = 3;
            // 
            // colSoCuocTraLai
            // 
            this.colSoCuocTraLai.Caption = "Số cuốc trả lại";
            this.colSoCuocTraLai.FieldName = "SoCuocTraLai";
            this.colSoCuocTraLai.Name = "colSoCuocTraLai";
            this.colSoCuocTraLai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colSoCuocTraLai.Visible = true;
            this.colSoCuocTraLai.VisibleIndex = 4;
            this.colSoCuocTraLai.Width = 80;
            // 
            // colDonDuoc
            // 
            this.colDonDuoc.Caption = "Đón được";
            this.colDonDuoc.FieldName = "DonDuocDieuApp";
            this.colDonDuoc.Name = "colDonDuoc";
            this.colDonDuoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colDonDuoc.Visible = true;
            this.colDonDuoc.VisibleIndex = 5;
            // 
            // colTruotHoan
            // 
            this.colTruotHoan.Caption = "Trượt/Hoãn";
            this.colTruotHoan.FieldName = "TruotHoanDieuApp";
            this.colTruotHoan.Name = "colTruotHoan";
            this.colTruotHoan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colTruotHoan.Visible = true;
            this.colTruotHoan.VisibleIndex = 6;
            this.colTruotHoan.Width = 78;
            // 
            // colXeDungDiem
            // 
            this.colXeDungDiem.Caption = "Xe dừng điểm";
            this.colXeDungDiem.FieldName = "XeDungDiem";
            this.colXeDungDiem.Name = "colXeDungDiem";
            this.colXeDungDiem.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colXeDungDiem.Visible = true;
            this.colXeDungDiem.VisibleIndex = 7;
            this.colXeDungDiem.Width = 77;
            // 
            // colAppKhongPhanHoiDaGapKhach
            // 
            this.colAppKhongPhanHoiDaGapKhach.Caption = "App không phản hồi đã gặp khách";
            this.colAppKhongPhanHoiDaGapKhach.FieldName = "AppKhongPhanHoiGapKhach";
            this.colAppKhongPhanHoiDaGapKhach.Name = "colAppKhongPhanHoiDaGapKhach";
            this.colAppKhongPhanHoiDaGapKhach.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colAppKhongPhanHoiDaGapKhach.Visible = true;
            this.colAppKhongPhanHoiDaGapKhach.VisibleIndex = 8;
            this.colAppKhongPhanHoiDaGapKhach.Width = 77;
            // 
            // colPhanTramDonDuoc
            // 
            this.colPhanTramDonDuoc.Caption = "% đón được";
            this.colPhanTramDonDuoc.FieldName = "PhanTramDonDuoc";
            this.colPhanTramDonDuoc.Name = "colPhanTramDonDuoc";
            this.colPhanTramDonDuoc.Visible = true;
            this.colPhanTramDonDuoc.VisibleIndex = 9;
            this.colPhanTramDonDuoc.Width = 88;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ngày";
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "Ngay";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp
            // 
            this.AcceptButton = this.btnLamMoi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 500);
            this.Controls.Add(this.panelInput2);
            this.Controls.Add(this.panTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp";
            this.Text = "1.10 Báo cáo cuốc khách TTĐH điều app";
            this.Load += new System.EventHandler(this.frmBC_1_10_BaoCaoCuocKhachTTDHDieuApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panTop)).EndInit();
            this.panTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panHeader)).EndInit();
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput2)).EndInit();
            this.panelInput2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoCuocKhachTTDHDieuApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoCuocKhachTTDHDieuApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShPanel panTop;
        private Taxi.Controls.Base.Controls.ShPanel panelInput2;
        private Taxi.Controls.Base.Controls.ShLabel lblTuNgay;
        private Taxi.Controls.Base.Inputs.InputDate dtpTuNgay;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Controls.ShLabel lblDenNgay;
        private Taxi.Controls.Base.Controls.ShGridControl grcBaoCaoCuocKhachTTDHDieuApp;
        private Taxi.Controls.Base.Controls.ShGridView grvBaoCaoCuocKhachTTDHDieuApp;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCuocGoiTaxiTTDH;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCuocTTDHDieuApp;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCuocLXNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCuocTraLai;
        private DevExpress.XtraGrid.Columns.GridColumn colDonDuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colTruotHoan;
        private DevExpress.XtraGrid.Columns.GridColumn colXeDungDiem;
        private DevExpress.XtraGrid.Columns.GridColumn colAppKhongPhanHoiDaGapKhach;
        private DevExpress.XtraGrid.Columns.GridColumn colPhanTramDonDuoc;
        private Taxi.Controls.Base.Controls.ShButton btnXuatExcel;
        private Taxi.Controls.Base.Controls.ShButton btnLamMoi;
        private Taxi.Controls.Base.Inputs.InputDate dtpDenNgay;
        private Taxi.Controls.Base.Controls.ShPanel panHeader;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}