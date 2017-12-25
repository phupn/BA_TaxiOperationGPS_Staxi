namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class frmBC_4_7_BaoCaoKetQuaDieuHanhTheoVung
    {
        public frmBC_4_7_BaoCaoKetQuaDieuHanhTheoVung()
        {
            InitializeComponent();
        }
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
            this.shGridControl1 = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.ShBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Ngay = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.vung = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Taxi_Tong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Taxi_MG = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Taxi_VL = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.DonDuoc_Tong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.DonDuoc_MG = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.DonDuoc_VL = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.KhongDonDuoc_Tong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.KhongDonDuoc_TruotHoan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.KhongDonDuoc_TruotHoan5Phut = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.KhongDonDuoc_Khongxe = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.KhongDonDuoc_Khac = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.PhanTramdonDuoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.CuocGoiLai_Cuoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CuocGoiLai_PhanTramGoiLai = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TyTrongVungNgay = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.inputLookup_VungGPS1 = new Taxi.Controls.Base.Common.InputLookUp_VungDieuHanh();
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
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputLookup_VungGPS1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Controls.Add(this.inputLookup_VungGPS1);
            this.pnInputs.Controls.Add(this.shLabel1);
            this.pnInputs.Size = new System.Drawing.Size(1257, 64);
            this.pnInputs.Controls.SetChildIndex(this.ipFromDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl1, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipToDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl2, 0);
            this.pnInputs.Controls.SetChildIndex(this.shLabel1, 0);
            this.pnInputs.Controls.SetChildIndex(this.inputLookup_VungGPS1, 0);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(530, 6);
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = new System.DateTime(2015, 12, 29, 9, 19, 57, 0);
            this.ipToDate.Location = new System.Drawing.Point(581, 3);
            this.ipToDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipToDate.Size = new System.Drawing.Size(132, 20);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(344, 7);
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = new System.DateTime(2015, 12, 29, 0, 0, 0, 0);
            this.ipFromDate.Location = new System.Drawing.Point(393, 4);
            this.ipFromDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipFromDate.Size = new System.Drawing.Size(132, 20);
            // 
            // pnButtons
            // 
            this.pnButtons.Location = new System.Drawing.Point(0, 98);
            this.pnButtons.Size = new System.Drawing.Size(1257, 52);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.Location = new System.Drawing.Point(463, 2);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(588, 2);
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnTim.Appearance.Options.UseFont = true;
            this.btnTim.Location = new System.Drawing.Point(347, 2);
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.shGridControl1);
            this.pnOutput.Location = new System.Drawing.Point(0, 150);
            this.pnOutput.Size = new System.Drawing.Size(1257, 511);
            // 
            // pnTitle
            // 
            this.pnTitle.Size = new System.Drawing.Size(1257, 34);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(325, 7);
            this.lblTitle.Size = new System.Drawing.Size(375, 22);
            this.lblTitle.Text = "4.7. Báo cáo kết quả điều hành theo vùng";
            // 
            // shGridControl1
            // 
            this.shGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl1.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl1.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl1.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl1.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl1.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl1.Location = new System.Drawing.Point(0, 0);
            this.shGridControl1.MainView = this.gridView1;
            this.shGridControl1.Name = "shGridControl1";
            this.shGridControl1.Size = new System.Drawing.Size(1257, 511);
            this.shGridControl1.TabIndex = 0;
            this.shGridControl1.UseEmbeddedNavigator = true;
            this.shGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.BandPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.BandPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand7,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.gridView1.ColumnPanelRowHeight = 35;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.vung,
            this.Ngay,
            this.Taxi_Tong,
            this.Taxi_MG,
            this.Taxi_VL,
            this.DonDuoc_Tong,
            this.DonDuoc_MG,
            this.DonDuoc_VL,
            this.KhongDonDuoc_Tong,
            this.KhongDonDuoc_TruotHoan,
            this.KhongDonDuoc_TruotHoan5Phut,
            this.KhongDonDuoc_Khongxe,
            this.KhongDonDuoc_Khac,
            this.PhanTramdonDuoc,
            this.CuocGoiLai_Cuoc,
            this.CuocGoiLai_PhanTramGoiLai,
            this.TyTrongVungNgay});
            this.gridView1.GridControl = this.shGridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Taxi_Tong", this.Taxi_Tong, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Taxi_MG", this.Taxi_MG, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Taxi_VL", this.Taxi_VL, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DonDuoc_Tong", this.DonDuoc_Tong, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DonDuoc_MG", this.DonDuoc_MG, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DonDuoc_VL", this.DonDuoc_VL, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_Tong", this.KhongDonDuoc_Tong, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_TruotHoan", this.KhongDonDuoc_TruotHoan, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_TruotHoan5Phut", this.KhongDonDuoc_TruotHoan5Phut, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_Khongxe", this.KhongDonDuoc_Khongxe, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_Khac", this.KhongDonDuoc_Khac, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CuocGoiLai_Cuoc", this.CuocGoiLai_Cuoc, "")});
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Ngay, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.Ngay);
            this.gridBand1.Columns.Add(this.vung);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 68;
            // 
            // Ngay
            // 
            this.Ngay.Caption = "Ngày";
            this.Ngay.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.Ngay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Ngay.FieldName = "Ngay";
            this.Ngay.GroupFormat.FormatString = "dd/MM/yyyy";
            this.Ngay.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Ngay.Name = "Ngay";
            // 
            // vung
            // 
            this.vung.Caption = "Vùng";
            this.vung.FieldName = "Vung";
            this.vung.Name = "vung";
            this.vung.Visible = true;
            this.vung.Width = 68;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Cuộc gọi taxi";
            this.gridBand2.Columns.Add(this.Taxi_Tong);
            this.gridBand2.Columns.Add(this.Taxi_MG);
            this.gridBand2.Columns.Add(this.Taxi_VL);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 225;
            // 
            // Taxi_Tong
            // 
            this.Taxi_Tong.Caption = "Tổng";
            this.Taxi_Tong.DisplayFormat.FormatString = "#,##0";
            this.Taxi_Tong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Taxi_Tong.FieldName = "Taxi_Tong";
            this.Taxi_Tong.Name = "Taxi_Tong";
            this.Taxi_Tong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Taxi_Tong", "{0:#,##0}")});
            this.Taxi_Tong.Visible = true;
            // 
            // Taxi_MG
            // 
            this.Taxi_MG.Caption = "MG";
            this.Taxi_MG.DisplayFormat.FormatString = "#,##0";
            this.Taxi_MG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Taxi_MG.FieldName = "Taxi_MG";
            this.Taxi_MG.Name = "Taxi_MG";
            this.Taxi_MG.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Taxi_MG", "{0:#,##0}")});
            this.Taxi_MG.Visible = true;
            // 
            // Taxi_VL
            // 
            this.Taxi_VL.Caption = "VL";
            this.Taxi_VL.DisplayFormat.FormatString = "#,##0";
            this.Taxi_VL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Taxi_VL.FieldName = "Taxi_VL";
            this.Taxi_VL.Name = "Taxi_VL";
            this.Taxi_VL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Taxi_VL", "{0:#,##0}")});
            this.Taxi_VL.Visible = true;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "Đón được";
            this.gridBand7.Columns.Add(this.DonDuoc_Tong);
            this.gridBand7.Columns.Add(this.DonDuoc_MG);
            this.gridBand7.Columns.Add(this.DonDuoc_VL);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 225;
            // 
            // DonDuoc_Tong
            // 
            this.DonDuoc_Tong.Caption = "Tổng";
            this.DonDuoc_Tong.DisplayFormat.FormatString = "#,##0";
            this.DonDuoc_Tong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DonDuoc_Tong.FieldName = "DonDuoc_Tong";
            this.DonDuoc_Tong.Name = "DonDuoc_Tong";
            this.DonDuoc_Tong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DonDuoc_Tong", "{0:#,##0}")});
            this.DonDuoc_Tong.Visible = true;
            // 
            // DonDuoc_MG
            // 
            this.DonDuoc_MG.Caption = "MG";
            this.DonDuoc_MG.DisplayFormat.FormatString = "#,##0";
            this.DonDuoc_MG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DonDuoc_MG.FieldName = "DonDuoc_MG";
            this.DonDuoc_MG.Name = "DonDuoc_MG";
            this.DonDuoc_MG.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DonDuoc_MG", "{0:#,##0}")});
            this.DonDuoc_MG.Visible = true;
            // 
            // DonDuoc_VL
            // 
            this.DonDuoc_VL.Caption = "VL";
            this.DonDuoc_VL.DisplayFormat.FormatString = "#,##0";
            this.DonDuoc_VL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DonDuoc_VL.FieldName = "DonDuoc_VL";
            this.DonDuoc_VL.Name = "DonDuoc_VL";
            this.DonDuoc_VL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DonDuoc_VL", "{0:#,##0}")});
            this.DonDuoc_VL.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Không đón được";
            this.gridBand3.Columns.Add(this.KhongDonDuoc_Tong);
            this.gridBand3.Columns.Add(this.KhongDonDuoc_TruotHoan);
            this.gridBand3.Columns.Add(this.KhongDonDuoc_TruotHoan5Phut);
            this.gridBand3.Columns.Add(this.KhongDonDuoc_Khongxe);
            this.gridBand3.Columns.Add(this.KhongDonDuoc_Khac);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 375;
            // 
            // KhongDonDuoc_Tong
            // 
            this.KhongDonDuoc_Tong.Caption = "Tổng";
            this.KhongDonDuoc_Tong.DisplayFormat.FormatString = "#,##0";
            this.KhongDonDuoc_Tong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.KhongDonDuoc_Tong.FieldName = "KhongDonDuoc_Tong";
            this.KhongDonDuoc_Tong.Name = "KhongDonDuoc_Tong";
            this.KhongDonDuoc_Tong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_Tong", "{0:#,##0}")});
            this.KhongDonDuoc_Tong.Visible = true;
            // 
            // KhongDonDuoc_TruotHoan
            // 
            this.KhongDonDuoc_TruotHoan.Caption = "Trượt/Hoãn";
            this.KhongDonDuoc_TruotHoan.DisplayFormat.FormatString = "#,##0";
            this.KhongDonDuoc_TruotHoan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.KhongDonDuoc_TruotHoan.FieldName = "KhongDonDuoc_TruotHoan";
            this.KhongDonDuoc_TruotHoan.Name = "KhongDonDuoc_TruotHoan";
            this.KhongDonDuoc_TruotHoan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_TruotHoan", "{0:#,##0}")});
            this.KhongDonDuoc_TruotHoan.Visible = true;
            // 
            // KhongDonDuoc_TruotHoan5Phut
            // 
            this.KhongDonDuoc_TruotHoan5Phut.Caption = "Trượt/Hoãn dưới 5 phút";
            this.KhongDonDuoc_TruotHoan5Phut.DisplayFormat.FormatString = "#,##0";
            this.KhongDonDuoc_TruotHoan5Phut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.KhongDonDuoc_TruotHoan5Phut.FieldName = "KhongDonDuoc_TruotHoan5Phut";
            this.KhongDonDuoc_TruotHoan5Phut.Name = "KhongDonDuoc_TruotHoan5Phut";
            this.KhongDonDuoc_TruotHoan5Phut.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_TruotHoan5Phut", "{0:#,##0}")});
            this.KhongDonDuoc_TruotHoan5Phut.Visible = true;
            // 
            // KhongDonDuoc_Khongxe
            // 
            this.KhongDonDuoc_Khongxe.Caption = "Không xe";
            this.KhongDonDuoc_Khongxe.DisplayFormat.FormatString = "#,##0";
            this.KhongDonDuoc_Khongxe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.KhongDonDuoc_Khongxe.FieldName = "KhongDonDuoc_Khongxe";
            this.KhongDonDuoc_Khongxe.Name = "KhongDonDuoc_Khongxe";
            this.KhongDonDuoc_Khongxe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_Khongxe", "{0:#,##0}")});
            this.KhongDonDuoc_Khongxe.Visible = true;
            // 
            // KhongDonDuoc_Khac
            // 
            this.KhongDonDuoc_Khac.Caption = "Khác";
            this.KhongDonDuoc_Khac.DisplayFormat.FormatString = "#,##0";
            this.KhongDonDuoc_Khac.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.KhongDonDuoc_Khac.FieldName = "KhongDonDuoc_Khac";
            this.KhongDonDuoc_Khac.Name = "KhongDonDuoc_Khac";
            this.KhongDonDuoc_Khac.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KhongDonDuoc_Khac", "{0:#,##0}")});
            this.KhongDonDuoc_Khac.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "% đón được";
            this.gridBand4.Columns.Add(this.PhanTramdonDuoc);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 75;
            // 
            // PhanTramdonDuoc
            // 
            this.PhanTramdonDuoc.Caption = "% Đón được";
            this.PhanTramdonDuoc.DisplayFormat.FormatString = "#,##0.##";
            this.PhanTramdonDuoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhanTramdonDuoc.FieldName = "PhanTramdonDuoc";
            this.PhanTramdonDuoc.Name = "PhanTramdonDuoc";
            this.PhanTramdonDuoc.Visible = true;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "Gọi lại";
            this.gridBand5.Columns.Add(this.CuocGoiLai_Cuoc);
            this.gridBand5.Columns.Add(this.CuocGoiLai_PhanTramGoiLai);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 150;
            // 
            // CuocGoiLai_Cuoc
            // 
            this.CuocGoiLai_Cuoc.Caption = "Cuốc";
            this.CuocGoiLai_Cuoc.DisplayFormat.FormatString = "#,##0";
            this.CuocGoiLai_Cuoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.CuocGoiLai_Cuoc.FieldName = "CuocGoiLai_Cuoc";
            this.CuocGoiLai_Cuoc.Name = "CuocGoiLai_Cuoc";
            this.CuocGoiLai_Cuoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CuocGoiLai_Cuoc", "{0:#,##0}")});
            this.CuocGoiLai_Cuoc.Visible = true;
            // 
            // CuocGoiLai_PhanTramGoiLai
            // 
            this.CuocGoiLai_PhanTramGoiLai.Caption = "%";
            this.CuocGoiLai_PhanTramGoiLai.DisplayFormat.FormatString = "#,##0.##";
            this.CuocGoiLai_PhanTramGoiLai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.CuocGoiLai_PhanTramGoiLai.FieldName = "CuocGoiLai_PhanTramGoiLai";
            this.CuocGoiLai_PhanTramGoiLai.Name = "CuocGoiLai_PhanTramGoiLai";
            this.CuocGoiLai_PhanTramGoiLai.Visible = true;
            // 
            // gridBand6
            // 
            this.gridBand6.Columns.Add(this.TyTrongVungNgay);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 101;
            // 
            // TyTrongVungNgay
            // 
            this.TyTrongVungNgay.Caption = "Tỷ trọng (Vùng/Ngày)";
            this.TyTrongVungNgay.DisplayFormat.FormatString = "#,##0.##";
            this.TyTrongVungNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TyTrongVungNgay.FieldName = "TyTrongVungNgay";
            this.TyTrongVungNgay.Name = "TyTrongVungNgay";
            this.TyTrongVungNgay.Visible = true;
            this.TyTrongVungNgay.Width = 101;
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(332, 35);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(52, 13);
            this.shLabel1.TabIndex = 5;
            this.shLabel1.Text = "Chọn Vùng";
            // 
            // inputLookup_VungGPS1
            // 
            this.inputLookup_VungGPS1.DefaultSelectFirstRow = false;
            this.inputLookup_VungGPS1.IsChangeText = false;
            this.inputLookup_VungGPS1.IsFocus = false;
            this.inputLookup_VungGPS1.IsShowTextNull = true;
            this.inputLookup_VungGPS1.Location = new System.Drawing.Point(393, 32);
            this.inputLookup_VungGPS1.Name = "inputLookup_VungGPS1";
            this.inputLookup_VungGPS1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inputLookup_VungGPS1.Properties.NullText = "Chọn tất cả";
            this.inputLookup_VungGPS1.Size = new System.Drawing.Size(132, 20);
            this.inputLookup_VungGPS1.TabIndex = 7;
            this.inputLookup_VungGPS1.Tag = "Vung";
            // 
            // frmBC_4_7_BaoCaoKetQuaDieuHanhTheoVung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 661);
            this.Name = "frmBC_4_7_BaoCaoKetQuaDieuHanhTheoVung";
            this.Text = "4.7. Báo cáo kết quả điều hành theo vùng";
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
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputLookup_VungGPS1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl shGridControl1;
        private Taxi.Controls.Base.Controls.ShBandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn vung;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Taxi_Tong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Taxi_MG;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Taxi_VL;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DonDuoc_Tong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DonDuoc_MG;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DonDuoc_VL;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn KhongDonDuoc_Tong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn KhongDonDuoc_TruotHoan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn KhongDonDuoc_TruotHoan5Phut;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn KhongDonDuoc_Khongxe;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn KhongDonDuoc_Khac;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn PhanTramdonDuoc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CuocGoiLai_Cuoc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CuocGoiLai_PhanTramGoiLai;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TyTrongVungNgay;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Ngay;
        private Taxi.Controls.Base.Controls.ShLabel shLabel1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private Taxi.Controls.Base.Common.InputLookUp_VungDieuHanh inputLookup_VungGPS1;
    }
}