namespace Taxi.Controls.FastTaxis.TaxiBook
{
    partial class ctrlListBook
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.shGridControl_Bookings = new Taxi.Controls.Base.Controls.ShGridControl();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Xoa = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ChiTiet = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ChuyenSangChuaGiaiQuyet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKetThuc = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_Bookings = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new Taxi.Controls.Base.Controls.ShButton();
            this.txtSoDT = new Taxi.Controls.Base.Inputs.InputText();
            this.deDenNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.txtDiaChiDon = new Taxi.Controls.Base.Inputs.InputText();
            this.deTuNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.lblSoDT = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblNgayDen = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblDiaChiDon = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblNgayDon = new Taxi.Controls.Base.Controls.ShLabel();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl_Bookings)).BeginInit();
            this.cMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Bookings)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiDon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(928, 645);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Cuốc khách đặt";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.shGridControl_Bookings);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(928, 610);
            this.panel3.TabIndex = 2;
            // 
            // shGridControl_Bookings
            // 
            this.shGridControl_Bookings.ContextMenuStrip = this.cMenu;
            this.shGridControl_Bookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl_Bookings.EmbeddedNavigator.ContextMenuStrip = this.cMenu;
            this.shGridControl_Bookings.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl_Bookings.Location = new System.Drawing.Point(0, 0);
            this.shGridControl_Bookings.MainView = this.gridView_Bookings;
            this.shGridControl_Bookings.Name = "shGridControl_Bookings";
            this.shGridControl_Bookings.Size = new System.Drawing.Size(928, 610);
            this.shGridControl_Bookings.TabIndex = 0;
            this.shGridControl_Bookings.UseEmbeddedNavigator = true;
            this.shGridControl_Bookings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Bookings});
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Xoa,
            this.MenuItem_ChiTiet,
            this.MenuItem_ChuyenSangChuaGiaiQuyet,
            this.menuKetThuc});
            this.cMenu.Name = "contextMenuStrip1";
            this.cMenu.Size = new System.Drawing.Size(228, 92);
            // 
            // MenuItem_Xoa
            // 
            this.MenuItem_Xoa.Name = "MenuItem_Xoa";
            this.MenuItem_Xoa.Size = new System.Drawing.Size(227, 22);
            this.MenuItem_Xoa.Text = "Hủy điều";
            this.MenuItem_Xoa.Visible = false;
            this.MenuItem_Xoa.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // MenuItem_ChiTiet
            // 
            this.MenuItem_ChiTiet.Name = "MenuItem_ChiTiet";
            this.MenuItem_ChiTiet.ShortcutKeyDisplayString = "Enter";
            this.MenuItem_ChiTiet.Size = new System.Drawing.Size(227, 22);
            this.MenuItem_ChiTiet.Text = "Chi tiết";
            this.MenuItem_ChiTiet.Click += new System.EventHandler(this.chiTiếtToolStripMenuItem_Click);
            // 
            // MenuItem_ChuyenSangChuaGiaiQuyet
            // 
            this.MenuItem_ChuyenSangChuaGiaiQuyet.Name = "MenuItem_ChuyenSangChuaGiaiQuyet";
            this.MenuItem_ChuyenSangChuaGiaiQuyet.Size = new System.Drawing.Size(227, 22);
            this.MenuItem_ChuyenSangChuaGiaiQuyet.Text = "Chuyển sang chưa giải quyết";
            this.MenuItem_ChuyenSangChuaGiaiQuyet.Visible = false;
            this.MenuItem_ChuyenSangChuaGiaiQuyet.Click += new System.EventHandler(this.menuChuyenSangChuaGiaiQuyet_Click);
            // 
            // menuKetThuc
            // 
            this.menuKetThuc.Name = "menuKetThuc";
            this.menuKetThuc.Size = new System.Drawing.Size(227, 22);
            this.menuKetThuc.Text = "Kết thúc";
            this.menuKetThuc.Click += new System.EventHandler(this.kếtThúcToolStripMenuItem_Click);
            // 
            // gridView_Bookings
            // 
            this.gridView_Bookings.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Bookings.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Bookings.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_Bookings.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_Bookings.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView_Bookings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn11,
            this.gridColumn10});
            this.gridView_Bookings.GridControl = this.shGridControl_Bookings;
            this.gridView_Bookings.IndicatorWidth = 35;
            this.gridView_Bookings.Name = "gridView_Bookings";
            this.gridView_Bookings.OptionsBehavior.Editable = false;
            this.gridView_Bookings.OptionsCustomization.AllowFilter = false;
            this.gridView_Bookings.OptionsView.ColumnAutoWidth = false;
            this.gridView_Bookings.OptionsView.ShowGroupPanel = false;
            this.gridView_Bookings.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView_Bookings.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView_Bookings.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_Bookings_RowCellStyle);
            this.gridView_Bookings.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView_Bookings.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_Bookings_SelectionChanged);
            this.gridView_Bookings.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_Bookings_FocusedRowChanged);
            this.gridView_Bookings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView_Bookings.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Số xe";
            this.gridColumn1.FieldName = "OpVehicle";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 42;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "KH đi khoảng";
            this.gridColumn2.FieldName = "DiKhoang";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 103;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "TG đón đến";
            this.gridColumn12.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn12.FieldName = "ToTime";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 101;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Số ĐT";
            this.gridColumn3.FieldName = "Mobile_ThoiGian";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 109;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Điểm đón";
            this.gridColumn7.FieldName = "FromName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 151;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Địa chỉ đón";
            this.gridColumn5.FieldName = "TenGhepDiaChiDon";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 312;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Điểm trả";
            this.gridColumn9.FieldName = "ToName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 190;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Địa chỉ trả";
            this.gridColumn6.FieldName = "TenGhepDiaChiTra";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 292;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "Lệnh";
            this.gridColumn8.FieldName = "OpCommand";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 97;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Trạng thái";
            this.gridColumn4.FieldName = "OpStatus";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 147;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Ghi chú";
            this.gridColumn11.FieldName = "OpDescription";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            this.gridColumn11.Width = 287;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "gridColumn10";
            this.gridColumn10.FieldName = "CreateDate";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSoDT);
            this.panel2.Controls.Add(this.deDenNgay);
            this.panel2.Controls.Add(this.txtDiaChiDon);
            this.panel2.Controls.Add(this.deTuNgay);
            this.panel2.Controls.Add(this.lblSoDT);
            this.panel2.Controls.Add(this.lblNgayDen);
            this.panel2.Controls.Add(this.lblDiaChiDon);
            this.panel2.Controls.Add(this.lblNgayDon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 22);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Taxi.Controls.Properties.Resources.search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSearch.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.btnSearch.Location = new System.Drawing.Point(597, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSoDT
            // 
            this.txtSoDT.EnterMoveNextControl = true;
            this.txtSoDT.IsChangeText = false;
            this.txtSoDT.IsFocus = false;
            this.txtSoDT.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.txtSoDT.Location = new System.Drawing.Point(43, 1);
            this.txtSoDT.Name = "txtSoDT";
            this.txtSoDT.Properties.Mask.EditMask = "\\d+";
            this.txtSoDT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoDT.Properties.MaxLength = 49;
            this.txtSoDT.Size = new System.Drawing.Size(75, 20);
            this.txtSoDT.TabIndex = 1;
            this.txtSoDT.EditValueChanged += new System.EventHandler(this.txtSoDT_EditValueChanged);
            this.txtSoDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaChiDon_KeyDown);
            // 
            // deDenNgay
            // 
            this.deDenNgay.DateNowWhenLoad = true;
            this.deDenNgay.EditValue = new System.DateTime(2015, 6, 5, 9, 59, 54, 195);
            this.deDenNgay.EnterMoveNextControl = true;
            this.deDenNgay.IsChangeText = false;
            this.deDenNgay.IsFocus = false;
            this.deDenNgay.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.deDenNgay.Location = new System.Drawing.Point(506, 1);
            this.deDenNgay.Name = "deDenNgay";
            this.deDenNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deDenNgay.Properties.ShowToday = false;
            this.deDenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDenNgay.Size = new System.Drawing.Size(86, 20);
            this.deDenNgay.TabIndex = 6;
            this.deDenNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaChiDon_KeyDown);
            // 
            // txtDiaChiDon
            // 
            this.txtDiaChiDon.EnterMoveNextControl = true;
            this.txtDiaChiDon.IsChangeText = false;
            this.txtDiaChiDon.IsFocus = false;
            this.txtDiaChiDon.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.txtDiaChiDon.Location = new System.Drawing.Point(178, 1);
            this.txtDiaChiDon.Name = "txtDiaChiDon";
            this.txtDiaChiDon.Properties.MaxLength = 49;
            this.txtDiaChiDon.Size = new System.Drawing.Size(162, 20);
            this.txtDiaChiDon.TabIndex = 3;
            this.txtDiaChiDon.TextChanged += new System.EventHandler(this.txtDiaChiDon_TextChanged);
            this.txtDiaChiDon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaChiDon_KeyDown);
            // 
            // deTuNgay
            // 
            this.deTuNgay.DateNowWhenLoad = true;
            this.deTuNgay.EditValue = new System.DateTime(2015, 6, 5, 9, 59, 36, 595);
            this.deTuNgay.EnterMoveNextControl = true;
            this.deTuNgay.IsChangeText = false;
            this.deTuNgay.IsFocus = false;
            this.deTuNgay.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.deTuNgay.Location = new System.Drawing.Point(398, 1);
            this.deTuNgay.Name = "deTuNgay";
            this.deTuNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deTuNgay.Properties.ShowToday = false;
            this.deTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTuNgay.Size = new System.Drawing.Size(79, 20);
            this.deTuNgay.TabIndex = 5;
            this.deTuNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaChiDon_KeyDown);
            // 
            // lblSoDT
            // 
            this.lblSoDT.Location = new System.Drawing.Point(8, 5);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(29, 13);
            this.lblSoDT.TabIndex = 0;
            this.lblSoDT.Text = "&Số ĐT";
            // 
            // lblNgayDen
            // 
            this.lblNgayDen.Location = new System.Drawing.Point(481, 5);
            this.lblNgayDen.Name = "lblNgayDen";
            this.lblNgayDen.Size = new System.Drawing.Size(20, 13);
            this.lblNgayDen.TabIndex = 8;
            this.lblNgayDen.Text = "Đ&ến";
            // 
            // lblDiaChiDon
            // 
            this.lblDiaChiDon.Location = new System.Drawing.Point(120, 5);
            this.lblDiaChiDon.Name = "lblDiaChiDon";
            this.lblDiaChiDon.Size = new System.Drawing.Size(53, 13);
            this.lblDiaChiDon.TabIndex = 2;
            this.lblDiaChiDon.Text = "Địa chỉ đ&ón";
            // 
            // lblNgayDon
            // 
            this.lblNgayDon.Location = new System.Drawing.Point(346, 5);
            this.lblNgayDon.Name = "lblNgayDon";
            this.lblNgayDon.Size = new System.Drawing.Size(46, 13);
            this.lblNgayDon.TabIndex = 4;
            this.lblNgayDon.Text = "Ngày &đón";
            // 
            // ctrlListBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlListBook";
            this.Size = new System.Drawing.Size(928, 645);
            this.Load += new System.EventHandler(this.ctrlDieuXe_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl_Bookings)).EndInit();
            this.cMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Bookings)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiDon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Base.Controls.ShGridControl shGridControl_Bookings;
        private Taxi.Controls.Base.Controls.ShGridView gridView_Bookings;
        private Base.Controls.ShButton btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private Base.Inputs.InputDate deDenNgay;
        private Base.Inputs.InputDate deTuNgay;
        private Base.Controls.ShLabel lblNgayDen;
        private Base.Controls.ShLabel lblNgayDon;
        private Base.Controls.ShLabel lblDiaChiDon;
        private Base.Inputs.InputText txtSoDT;
        private Base.Inputs.InputText txtDiaChiDon;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Xoa;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ChiTiet;
        private Base.Controls.ShLabel lblSoDT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ChuyenSangChuaGiaiQuyet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.ToolStripMenuItem menuKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.Button button1;
    }
}
