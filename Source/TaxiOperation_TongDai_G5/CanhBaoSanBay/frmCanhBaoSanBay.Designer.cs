namespace TaxiOperation_TongDai.CanhBaoSanBay
{
    partial class frmCanhBaoSanBay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCanhBaoSanBay));
            this.grcCanhBaoSanBay = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvCanhBaoSanBay = new Taxi.Controls.Base.Controls.ShGridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChiDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianXuLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiXuLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timerCanhBao = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.grcCanhBaoSanBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCanhBaoSanBay)).BeginInit();
            this.SuspendLayout();
            // 
            // grcCanhBaoSanBay
            // 
            this.grcCanhBaoSanBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcCanhBaoSanBay.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcCanhBaoSanBay.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcCanhBaoSanBay.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcCanhBaoSanBay.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcCanhBaoSanBay.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcCanhBaoSanBay.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcCanhBaoSanBay.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcCanhBaoSanBay.Location = new System.Drawing.Point(0, 0);
            this.grcCanhBaoSanBay.MainView = this.grvCanhBaoSanBay;
            this.grcCanhBaoSanBay.Name = "grcCanhBaoSanBay";
            this.grcCanhBaoSanBay.Size = new System.Drawing.Size(595, 153);
            this.grcCanhBaoSanBay.TabIndex = 6;
            this.grcCanhBaoSanBay.UseEmbeddedNavigator = true;
            this.grcCanhBaoSanBay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCanhBaoSanBay});
            this.grcCanhBaoSanBay.DoubleClick += new System.EventHandler(this.grcCanhBaoSanBay_DoubleClick);
            // 
            // grvCanhBaoSanBay
            // 
            this.grvCanhBaoSanBay.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvCanhBaoSanBay.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCanhBaoSanBay.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCanhBaoSanBay.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCanhBaoSanBay.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCanhBaoSanBay.Appearance.Row.Options.UseTextOptions = true;
            this.grvCanhBaoSanBay.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCanhBaoSanBay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colBookId,
            this.colNoiDung,
            this.colThoiGianNhan,
            this.colSDT,
            this.colDiaChiDon,
            this.colSoXe,
            this.colLine,
            this.colNguoiNhan,
            this.colThoiGianXuLy,
            this.colNguoiXuLy,
            this.colTrangThai,
            this.colType});
            this.grvCanhBaoSanBay.GridControl = this.grcCanhBaoSanBay;
            this.grvCanhBaoSanBay.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.grvCanhBaoSanBay.IndicatorWidth = 35;
            this.grvCanhBaoSanBay.Name = "grvCanhBaoSanBay";
            this.grvCanhBaoSanBay.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCanhBaoSanBay.OptionsBehavior.Editable = false;
            this.grvCanhBaoSanBay.OptionsMenu.EnableFooterMenu = false;
            this.grvCanhBaoSanBay.OptionsView.ShowGroupPanel = false;
            this.grvCanhBaoSanBay.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvCanhBaoSanBay_RowCellStyle);
            this.grvCanhBaoSanBay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvCanhBaoSanBay_KeyDown);
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.AllowFilter = false;
            this.colId.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colId.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colBookId
            // 
            this.colBookId.Caption = "BookID";
            this.colBookId.FieldName = "BookId";
            this.colBookId.Name = "colBookId";
            this.colBookId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colNoiDung
            // 
            this.colNoiDung.AppearanceCell.Options.UseTextOptions = true;
            this.colNoiDung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNoiDung.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNoiDung.Caption = "Nội dung";
            this.colNoiDung.FieldName = "NoiDung";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNoiDung.OptionsFilter.AllowAutoFilter = false;
            this.colNoiDung.OptionsFilter.AllowFilter = false;
            this.colNoiDung.Visible = true;
            this.colNoiDung.VisibleIndex = 0;
            this.colNoiDung.Width = 150;
            // 
            // colThoiGianNhan
            // 
            this.colThoiGianNhan.Caption = "TG hẹn";
            this.colThoiGianNhan.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.colThoiGianNhan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colThoiGianNhan.FieldName = "ThoiGianNhan";
            this.colThoiGianNhan.Name = "colThoiGianNhan";
            this.colThoiGianNhan.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colThoiGianNhan.Visible = true;
            this.colThoiGianNhan.VisibleIndex = 1;
            this.colThoiGianNhan.Width = 101;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "SĐT";
            this.colSDT.FieldName = "SoDienThoai";
            this.colSDT.Name = "colSDT";
            this.colSDT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSDT.OptionsFilter.AllowAutoFilter = false;
            this.colSDT.OptionsFilter.AllowFilter = false;
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 2;
            this.colSDT.Width = 102;
            // 
            // colDiaChiDon
            // 
            this.colDiaChiDon.AppearanceCell.Options.UseTextOptions = true;
            this.colDiaChiDon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDiaChiDon.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDiaChiDon.Caption = "Địa chỉ đón";
            this.colDiaChiDon.FieldName = "DiaChiDon";
            this.colDiaChiDon.Name = "colDiaChiDon";
            this.colDiaChiDon.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDiaChiDon.OptionsFilter.AllowAutoFilter = false;
            this.colDiaChiDon.OptionsFilter.AllowFilter = false;
            this.colDiaChiDon.Visible = true;
            this.colDiaChiDon.VisibleIndex = 3;
            this.colDiaChiDon.Width = 205;
            // 
            // colSoXe
            // 
            this.colSoXe.Caption = "Số xe";
            this.colSoXe.FieldName = "SoXe";
            this.colSoXe.Name = "colSoXe";
            this.colSoXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colLine
            // 
            this.colLine.Caption = "Line";
            this.colLine.FieldName = "Line";
            this.colLine.Name = "colLine";
            this.colLine.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colNguoiNhan
            // 
            this.colNguoiNhan.Caption = "Người nhận";
            this.colNguoiNhan.FieldName = "NguoiNhan";
            this.colNguoiNhan.Name = "colNguoiNhan";
            this.colNguoiNhan.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colThoiGianXuLy
            // 
            this.colThoiGianXuLy.Caption = "TG Xử lý";
            this.colThoiGianXuLy.FieldName = "ThoiGianXuLy";
            this.colThoiGianXuLy.Name = "colThoiGianXuLy";
            this.colThoiGianXuLy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colNguoiXuLy
            // 
            this.colNguoiXuLy.Caption = "Người xử lý";
            this.colNguoiXuLy.FieldName = "NguoiXuLy";
            this.colNguoiXuLy.Name = "colNguoiXuLy";
            this.colNguoiXuLy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Caption = "Trạng thái";
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // timerCanhBao
            // 
            this.timerCanhBao.Enabled = true;
            this.timerCanhBao.Interval = 1000;
            // 
            // frmCanhBaoSanBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 153);
            this.Controls.Add(this.grcCanhBaoSanBay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCanhBaoSanBay";
            this.Text = "C.báo cuốc sb( Ẩn c.báo sau 15 phút ko xử lý)";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCanhBaoSanBay_FormClosing);
            this.Load += new System.EventHandler(this.frmCanhBaoSanBay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcCanhBaoSanBay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCanhBaoSanBay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl grcCanhBaoSanBay;
        private Taxi.Controls.Base.Controls.ShGridView grvCanhBaoSanBay;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colBookId;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChiDon;
        private DevExpress.XtraGrid.Columns.GridColumn colSoXe;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianXuLy;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiXuLy;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private System.Windows.Forms.Timer timerCanhBao;
    }
}