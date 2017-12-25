namespace TaxiApplication.GUI.FrmCanhBaoDieuApp
{
    partial class frmCanhBaoDieuApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCanhBaoDieuApp));
            this.grcCanhBaoDieuApp = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvCanhBaoDieuApp = new Taxi.Controls.Base.Controls.ShGridView();
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon();
            ((System.ComponentModel.ISupportInitialize)(this.grcCanhBaoDieuApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCanhBaoDieuApp)).BeginInit();
            this.SuspendLayout();
            // 
            // grcCanhBaoDieuApp
            // 
            this.grcCanhBaoDieuApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcCanhBaoDieuApp.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcCanhBaoDieuApp.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcCanhBaoDieuApp.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcCanhBaoDieuApp.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcCanhBaoDieuApp.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcCanhBaoDieuApp.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcCanhBaoDieuApp.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcCanhBaoDieuApp.Location = new System.Drawing.Point(0, 0);
            this.grcCanhBaoDieuApp.MainView = this.grvCanhBaoDieuApp;
            this.grcCanhBaoDieuApp.Name = "grcCanhBaoDieuApp";
            this.grcCanhBaoDieuApp.Size = new System.Drawing.Size(585, 176);
            this.grcCanhBaoDieuApp.TabIndex = 5;
            this.grcCanhBaoDieuApp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCanhBaoDieuApp});
            this.grcCanhBaoDieuApp.Click += new System.EventHandler(this.grcCanhBaoDieuApp_Click);
            // 
            // grvCanhBaoDieuApp
            // 
            this.grvCanhBaoDieuApp.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvCanhBaoDieuApp.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCanhBaoDieuApp.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCanhBaoDieuApp.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCanhBaoDieuApp.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCanhBaoDieuApp.Appearance.Row.Options.UseTextOptions = true;
            this.grvCanhBaoDieuApp.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCanhBaoDieuApp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.grvCanhBaoDieuApp.GridControl = this.grcCanhBaoDieuApp;
            this.grvCanhBaoDieuApp.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.grvCanhBaoDieuApp.IndicatorWidth = 35;
            this.grvCanhBaoDieuApp.Name = "grvCanhBaoDieuApp";
            this.grvCanhBaoDieuApp.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCanhBaoDieuApp.OptionsBehavior.Editable = false;
            this.grvCanhBaoDieuApp.OptionsMenu.EnableFooterMenu = false;
            this.grvCanhBaoDieuApp.OptionsView.ShowGroupPanel = false;
            this.grvCanhBaoDieuApp.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvCanhBaoDieuApp_RowCellStyle);
            this.grvCanhBaoDieuApp.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvCanhBaoDieuApp_FocusedRowChanged);
            this.grvCanhBaoDieuApp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvCanhBaoDieuApp_KeyDown);
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
            this.colNoiDung.Width = 142;
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
            this.colThoiGianNhan.Width = 82;
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
            this.colSDT.Width = 113;
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
            this.colDiaChiDon.Width = 211;
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
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.BalloonTipText = "Có cảnh báo mới";
            this.notifyIcon1.BalloonTipTitle = "Cảnh báo";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Cảnh báo";
            // 
            // frmCanhBaoDieuApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 176);
            this.Controls.Add(this.grcCanhBaoDieuApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCanhBaoDieuApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cảnh báo (Ẩn c.báo sau 15P ko x.lý;Space-Gọi KH,Alt+C-Gọi LX)";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmCanhBaoDieuApp_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCanhBaoDieuApp_FormClosing);
            this.Load += new System.EventHandler(this.frmCanhBaoDieuApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcCanhBaoDieuApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCanhBaoDieuApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl grcCanhBaoDieuApp;
        private Taxi.Controls.Base.Controls.ShGridView grvCanhBaoDieuApp;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colBookId;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChiDon;
        private DevExpress.XtraGrid.Columns.GridColumn colSoXe;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianXuLy;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiXuLy;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}