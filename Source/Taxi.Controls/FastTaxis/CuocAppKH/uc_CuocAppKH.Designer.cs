namespace Taxi.Controls.FastTaxis.CuocAppKH
{
    partial class uc_CuocAppKH
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
            this.tabCuocApp = new Taxi.Controls.Base.Controls.ShTabControl();
            this.tabDangXuLy = new DevExpress.XtraTab.XtraTabPage();
            this.grcDangXuLy = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvDangXuLy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCatchedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFromAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcToAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCarTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXeNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXeDungDiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXeDenDiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXeDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDriverCommand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcServerCommand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabHoanThanh = new DevExpress.XtraTab.XtraTabPage();
            this.grcHoanThanh = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvHoanThanh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabCuocApp)).BeginInit();
            this.tabCuocApp.SuspendLayout();
            this.tabDangXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDangXuLy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDangXuLy)).BeginInit();
            this.tabHoanThanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcHoanThanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHoanThanh)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCuocApp
            // 
            this.tabCuocApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCuocApp.Location = new System.Drawing.Point(0, 0);
            this.tabCuocApp.Name = "tabCuocApp";
            this.tabCuocApp.SelectedTabPage = this.tabDangXuLy;
            this.tabCuocApp.Size = new System.Drawing.Size(1103, 506);
            this.tabCuocApp.TabIndex = 0;
            this.tabCuocApp.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDangXuLy,
            this.tabHoanThanh});
            this.tabCuocApp.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabCuocApp_SelectedPageChanged);
            // 
            // tabDangXuLy
            // 
            this.tabDangXuLy.Controls.Add(this.grcDangXuLy);
            this.tabDangXuLy.Name = "tabDangXuLy";
            this.tabDangXuLy.Size = new System.Drawing.Size(1097, 480);
            this.tabDangXuLy.Text = "Đang xử lý";
            // 
            // grcDangXuLy
            // 
            this.grcDangXuLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcDangXuLy.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcDangXuLy.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcDangXuLy.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcDangXuLy.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcDangXuLy.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcDangXuLy.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcDangXuLy.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcDangXuLy.Location = new System.Drawing.Point(0, 0);
            this.grcDangXuLy.MainView = this.grvDangXuLy;
            this.grcDangXuLy.Name = "grcDangXuLy";
            this.grcDangXuLy.Size = new System.Drawing.Size(1097, 480);
            this.grcDangXuLy.TabIndex = 0;
            this.grcDangXuLy.UseEmbeddedNavigator = true;
            this.grcDangXuLy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDangXuLy});
            // 
            // grvDangXuLy
            // 
            this.grvDangXuLy.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDangXuLy.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDangXuLy.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grvDangXuLy.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvDangXuLy.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvDangXuLy.ColumnPanelRowHeight = 35;
            this.grvDangXuLy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLine,
            this.gcVung,
            this.gcPhoneNumber,
            this.gcCatchedTime,
            this.gcFromAddress,
            this.gcToAddress,
            this.gridColumn7,
            this.gcCarTypeName,
            this.gcXeNhan,
            this.gcXeDungDiem,
            this.gcXeDenDiem,
            this.gcXeDon,
            this.gcDriverCommand,
            this.gcStatus,
            this.gcServerCommand,
            this.gcCustomNote,
            this.gcUpdateTime});
            this.grvDangXuLy.GridControl = this.grcDangXuLy;
            this.grvDangXuLy.Name = "grvDangXuLy";
            this.grvDangXuLy.OptionsBehavior.Editable = false;
            this.grvDangXuLy.OptionsCustomization.AllowFilter = false;
            this.grvDangXuLy.OptionsCustomization.AllowSort = false;
            this.grvDangXuLy.OptionsView.ColumnAutoWidth = false;
            this.grvDangXuLy.OptionsView.ShowFooter = true;
            this.grvDangXuLy.OptionsView.ShowGroupPanel = false;
            this.grvDangXuLy.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvDangXuLy_SelectionChanged);
            // 
            // gcLine
            // 
            this.gcLine.Caption = "Line";
            this.gcLine.FieldName = "Line";
            this.gcLine.Name = "gcLine";
            this.gcLine.Width = 36;
            // 
            // gcVung
            // 
            this.gcVung.Caption = "Vùng";
            this.gcVung.FieldName = "Vung";
            this.gcVung.Name = "gcVung";
            this.gcVung.Width = 32;
            // 
            // gcPhoneNumber
            // 
            this.gcPhoneNumber.AppearanceCell.Options.UseTextOptions = true;
            this.gcPhoneNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPhoneNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.gcPhoneNumber.Caption = "Điện thoại";
            this.gcPhoneNumber.FieldName = "PhoneNumber";
            this.gcPhoneNumber.Name = "gcPhoneNumber";
            this.gcPhoneNumber.Visible = true;
            this.gcPhoneNumber.VisibleIndex = 0;
            this.gcPhoneNumber.Width = 101;
            // 
            // gcCatchedTime
            // 
            this.gcCatchedTime.AppearanceCell.Options.UseTextOptions = true;
            this.gcCatchedTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCatchedTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcCatchedTime.Caption = "Thời gian đặt";
            this.gcCatchedTime.DisplayFormat.FormatString = "HH:mm dd/MM";
            this.gcCatchedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCatchedTime.FieldName = "CatchedTime";
            this.gcCatchedTime.Name = "gcCatchedTime";
            this.gcCatchedTime.Visible = true;
            this.gcCatchedTime.VisibleIndex = 1;
            this.gcCatchedTime.Width = 111;
            // 
            // gcFromAddress
            // 
            this.gcFromAddress.Caption = "Địa chỉ đón";
            this.gcFromAddress.FieldName = "FromAddress";
            this.gcFromAddress.Name = "gcFromAddress";
            this.gcFromAddress.Visible = true;
            this.gcFromAddress.VisibleIndex = 2;
            this.gcFromAddress.Width = 309;
            // 
            // gcToAddress
            // 
            this.gcToAddress.Caption = "Địa chỉ trả";
            this.gcToAddress.FieldName = "ToAddress";
            this.gcToAddress.Name = "gcToAddress";
            this.gcToAddress.Visible = true;
            this.gcToAddress.VisibleIndex = 3;
            this.gcToAddress.Width = 325;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "Số lượng";
            this.gridColumn7.FieldName = "CountCar";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 41;
            // 
            // gcCarTypeName
            // 
            this.gcCarTypeName.AppearanceCell.Options.UseTextOptions = true;
            this.gcCarTypeName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCarTypeName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcCarTypeName.Caption = "Loại xe";
            this.gcCarTypeName.FieldName = "CarTypeName";
            this.gcCarTypeName.Name = "gcCarTypeName";
            this.gcCarTypeName.Visible = true;
            this.gcCarTypeName.VisibleIndex = 5;
            this.gcCarTypeName.Width = 71;
            // 
            // gcXeNhan
            // 
            this.gcXeNhan.AppearanceCell.Options.UseTextOptions = true;
            this.gcXeNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcXeNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcXeNhan.Caption = "Xe nhận";
            this.gcXeNhan.FieldName = "XeNhan";
            this.gcXeNhan.Name = "gcXeNhan";
            this.gcXeNhan.Visible = true;
            this.gcXeNhan.VisibleIndex = 6;
            this.gcXeNhan.Width = 49;
            // 
            // gcXeDungDiem
            // 
            this.gcXeDungDiem.AppearanceCell.Options.UseTextOptions = true;
            this.gcXeDungDiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcXeDungDiem.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcXeDungDiem.Caption = "Xe dừng điểm";
            this.gcXeDungDiem.FieldName = "XeDungDiem";
            this.gcXeDungDiem.Name = "gcXeDungDiem";
            this.gcXeDungDiem.Visible = true;
            this.gcXeDungDiem.VisibleIndex = 7;
            this.gcXeDungDiem.Width = 49;
            // 
            // gcXeDenDiem
            // 
            this.gcXeDenDiem.Caption = "Xe đến điểm";
            this.gcXeDenDiem.FieldName = "XeDenDiem";
            this.gcXeDenDiem.Name = "gcXeDenDiem";
            this.gcXeDenDiem.Visible = true;
            this.gcXeDenDiem.VisibleIndex = 8;
            this.gcXeDenDiem.Width = 42;
            // 
            // gcXeDon
            // 
            this.gcXeDon.AppearanceCell.Options.UseTextOptions = true;
            this.gcXeDon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcXeDon.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcXeDon.Caption = "Xe đón";
            this.gcXeDon.FieldName = "XeDon";
            this.gcXeDon.Name = "gcXeDon";
            this.gcXeDon.Visible = true;
            this.gcXeDon.VisibleIndex = 9;
            this.gcXeDon.Width = 51;
            // 
            // gcDriverCommand
            // 
            this.gcDriverCommand.AppearanceCell.Options.UseTextOptions = true;
            this.gcDriverCommand.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDriverCommand.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcDriverCommand.Caption = "Lệnh LX";
            this.gcDriverCommand.FieldName = "DriverCommand";
            this.gcDriverCommand.Name = "gcDriverCommand";
            this.gcDriverCommand.Visible = true;
            this.gcDriverCommand.VisibleIndex = 10;
            this.gcDriverCommand.Width = 100;
            // 
            // gcStatus
            // 
            this.gcStatus.AppearanceCell.Options.UseTextOptions = true;
            this.gcStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcStatus.Caption = "Trạng thái";
            this.gcStatus.FieldName = "Status";
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.Visible = true;
            this.gcStatus.VisibleIndex = 11;
            this.gcStatus.Width = 154;
            // 
            // gcServerCommand
            // 
            this.gcServerCommand.Caption = "Lệnh server";
            this.gcServerCommand.FieldName = "ServerCommand";
            this.gcServerCommand.Name = "gcServerCommand";
            this.gcServerCommand.Width = 93;
            // 
            // gcCustomNote
            // 
            this.gcCustomNote.Caption = "Ghi chú KH";
            this.gcCustomNote.FieldName = "CustomNote";
            this.gcCustomNote.Name = "gcCustomNote";
            this.gcCustomNote.Visible = true;
            this.gcCustomNote.VisibleIndex = 12;
            this.gcCustomNote.Width = 123;
            // 
            // gcUpdateTime
            // 
            this.gcUpdateTime.AppearanceCell.Options.UseTextOptions = true;
            this.gcUpdateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUpdateTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcUpdateTime.Caption = "TG Cập nhật";
            this.gcUpdateTime.DisplayFormat.FormatString = "HH:mm:ss dd/MM";
            this.gcUpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcUpdateTime.FieldName = "UpdateTime";
            this.gcUpdateTime.Name = "gcUpdateTime";
            this.gcUpdateTime.Visible = true;
            this.gcUpdateTime.VisibleIndex = 13;
            this.gcUpdateTime.Width = 168;
            // 
            // tabHoanThanh
            // 
            this.tabHoanThanh.Controls.Add(this.grcHoanThanh);
            this.tabHoanThanh.Name = "tabHoanThanh";
            this.tabHoanThanh.Size = new System.Drawing.Size(1097, 480);
            this.tabHoanThanh.Text = "Hoàn thành";
            // 
            // grcHoanThanh
            // 
            this.grcHoanThanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcHoanThanh.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcHoanThanh.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcHoanThanh.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcHoanThanh.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcHoanThanh.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcHoanThanh.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcHoanThanh.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcHoanThanh.Location = new System.Drawing.Point(0, 0);
            this.grcHoanThanh.MainView = this.grvHoanThanh;
            this.grcHoanThanh.Name = "grcHoanThanh";
            this.grcHoanThanh.Size = new System.Drawing.Size(1097, 480);
            this.grcHoanThanh.TabIndex = 1;
            this.grcHoanThanh.UseEmbeddedNavigator = true;
            this.grcHoanThanh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHoanThanh});
            // 
            // grvHoanThanh
            // 
            this.grvHoanThanh.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvHoanThanh.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvHoanThanh.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grvHoanThanh.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvHoanThanh.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvHoanThanh.ColumnPanelRowHeight = 35;
            this.grvHoanThanh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.grvHoanThanh.GridControl = this.grcHoanThanh;
            this.grvHoanThanh.Name = "grvHoanThanh";
            this.grvHoanThanh.OptionsBehavior.Editable = false;
            this.grvHoanThanh.OptionsCustomization.AllowFilter = false;
            this.grvHoanThanh.OptionsCustomization.AllowSort = false;
            this.grvHoanThanh.OptionsView.ColumnAutoWidth = false;
            this.grvHoanThanh.OptionsView.ShowFooter = true;
            this.grvHoanThanh.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Line";
            this.gridColumn1.FieldName = "Line";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 36;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Vùng";
            this.gridColumn2.FieldName = "Vung";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 32;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.gridColumn3.Caption = "Điện thoại";
            this.gridColumn3.FieldName = "PhoneNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 101;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Thời gian đặt";
            this.gridColumn4.DisplayFormat.FormatString = "HH:mm dd/MM";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "CatchedTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 111;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Địa chỉ đón";
            this.gridColumn5.FieldName = "FromAddress";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 411;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Địa chỉ trả";
            this.gridColumn6.FieldName = "ToAddress";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 402;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "Số lượng";
            this.gridColumn8.FieldName = "CountCar";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 41;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "Loại xe";
            this.gridColumn9.FieldName = "CarTypeName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 71;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.Caption = "Xe nhận";
            this.gridColumn10.FieldName = "XeNhan";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 49;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.Caption = "Xe dừng điểm";
            this.gridColumn11.FieldName = "XeDungDiem";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            this.gridColumn11.Width = 49;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Xe đến điểm";
            this.gridColumn12.FieldName = "XeDenDiem";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 42;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.Caption = "Xe đón";
            this.gridColumn13.FieldName = "XeDon";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 9;
            this.gridColumn13.Width = 51;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn14.Caption = "Lệnh LX";
            this.gridColumn14.FieldName = "DriverCommand";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 10;
            this.gridColumn14.Width = 100;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn15.Caption = "Trạng thái";
            this.gridColumn15.FieldName = "Status";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 11;
            this.gridColumn15.Width = 154;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Lệnh server";
            this.gridColumn16.FieldName = "ServerCommand";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 93;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Ghi chú KH";
            this.gridColumn17.FieldName = "CustomNote";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 12;
            this.gridColumn17.Width = 123;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn18.Caption = "TG Cập nhật";
            this.gridColumn18.DisplayFormat.FormatString = "HH:mm:ss dd/MM";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn18.FieldName = "UpdateTime";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 13;
            this.gridColumn18.Width = 168;
            // 
            // uc_CuocAppKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCuocApp);
            this.Name = "uc_CuocAppKH";
            this.Size = new System.Drawing.Size(1103, 506);
            ((System.ComponentModel.ISupportInitialize)(this.tabCuocApp)).EndInit();
            this.tabCuocApp.ResumeLayout(false);
            this.tabDangXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDangXuLy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDangXuLy)).EndInit();
            this.tabHoanThanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcHoanThanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHoanThanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShTabControl tabCuocApp;
        private DevExpress.XtraTab.XtraTabPage tabDangXuLy;
        private DevExpress.XtraTab.XtraTabPage tabHoanThanh;
        private Base.Controls.ShGridControl grcDangXuLy;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDangXuLy;
        private DevExpress.XtraGrid.Columns.GridColumn gcLine;
        private DevExpress.XtraGrid.Columns.GridColumn gcVung;
        private DevExpress.XtraGrid.Columns.GridColumn gcPhoneNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcCatchedTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcFromAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcToAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gcCarTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn gcXeNhan;
        private DevExpress.XtraGrid.Columns.GridColumn gcXeDungDiem;
        private DevExpress.XtraGrid.Columns.GridColumn gcXeDenDiem;
        private DevExpress.XtraGrid.Columns.GridColumn gcXeDon;
        private DevExpress.XtraGrid.Columns.GridColumn gcDriverCommand;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomNote;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpdateTime;
        private Base.Controls.ShGridControl grcHoanThanh;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHoanThanh;
        private DevExpress.XtraGrid.Columns.GridColumn gcServerCommand;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
    }
}
