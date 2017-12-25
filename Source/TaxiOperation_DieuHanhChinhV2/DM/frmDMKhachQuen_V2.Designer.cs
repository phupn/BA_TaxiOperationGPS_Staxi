namespace Taxi.GUI
{
    partial class frmDMKhachQuen_V2
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
            DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMKhachQuen_V2));
            this.barMenuTop = new DevExpress.XtraBars.Bar();
            this.shBarManager = new Taxi.Controls.Base.Controls.ShBarManager();
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barButton_ThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_Xoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_Excel = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_Search = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButton_CapNhatCuocGoi = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_CheckDuplicate = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButton_Active = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_UnActive = new DevExpress.XtraBars.BarButtonItem();
            this.gridKhachQuen = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridViewKhachQuen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.shBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKhachQuen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKhachQuen)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn1
            // 
            gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gridColumn1.AppearanceHeader.Options.UseFont = true;
            gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridColumn1.Caption = "Mã";
            gridColumn1.FieldName = "MaKH";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // barMenuTop
            // 
            this.barMenuTop.BarName = "Tools";
            this.barMenuTop.DockCol = 0;
            this.barMenuTop.DockRow = 0;
            this.barMenuTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenuTop.OptionsBar.AllowQuickCustomization = false;
            this.barMenuTop.OptionsBar.DisableClose = true;
            this.barMenuTop.OptionsBar.DisableCustomization = true;
            this.barMenuTop.OptionsBar.DrawDragBorder = false;
            this.barMenuTop.OptionsBar.UseWholeRow = true;
            this.barMenuTop.Text = "Tools";
            // 
            // shBarManager
            // 
            this.shBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop});
            this.shBarManager.DockControls.Add(this.barDockControlTop);
            this.shBarManager.DockControls.Add(this.barDockControlBottom);
            this.shBarManager.DockControls.Add(this.barDockControlLeft);
            this.shBarManager.DockControls.Add(this.barDockControlRight);
            this.shBarManager.Form = this;
            this.shBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButton_ThemMoi,
            this.barButton_Xoa,
            this.barButton_Excel,
            this.barButton_Search,
            this.barButton_CapNhatCuocGoi,
            this.barButton_CheckDuplicate,
            this.barSubItem1,
            this.barButton_Active,
            this.barButton_UnActive,
            this.btnExit});
            this.shBarManager.MaxItemId = 10;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButton_ThemMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButton_Xoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButton_Excel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButton_Search, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
            this.barTop.OptionsBar.AllowQuickCustomization = false;
            this.barTop.OptionsBar.DisableClose = true;
            this.barTop.OptionsBar.DisableCustomization = true;
            this.barTop.OptionsBar.DrawDragBorder = false;
            this.barTop.OptionsBar.UseWholeRow = true;
            this.barTop.Text = "Tools";
            // 
            // barButton_ThemMoi
            // 
            this.barButton_ThemMoi.Caption = "Thêm mới (F1)";
            this.barButton_ThemMoi.Id = 0;
            this.barButton_ThemMoi.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_add_01;
            this.barButton_ThemMoi.Name = "barButton_ThemMoi";
            this.barButton_ThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_ThemMoi_ItemClick);
            // 
            // barButton_Xoa
            // 
            this.barButton_Xoa.Caption = "Xóa (F2)";
            this.barButton_Xoa.Id = 1;
            this.barButton_Xoa.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_delete_03_01;
            this.barButton_Xoa.Name = "barButton_Xoa";
            this.barButton_Xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_Xoa_ItemClick);
            // 
            // barButton_Excel
            // 
            this.barButton_Excel.Caption = "Excel (F3)";
            this.barButton_Excel.Id = 2;
            this.barButton_Excel.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel_icon_24x24;
            this.barButton_Excel.Name = "barButton_Excel";
            this.barButton_Excel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_Excel_ItemClick);
            // 
            // barButton_Search
            // 
            this.barButton_Search.Caption = "Tìm kiếm (F4)";
            this.barButton_Search.Id = 3;
            this.barButton_Search.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_search_02_01;
            this.barButton_Search.Name = "barButton_Search";
            this.barButton_Search.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_Search_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Thoát (Esc)";
            this.btnExit.Id = 9;
            this.btnExit.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_lock_03_01;
            this.btnExit.Name = "btnExit";
            this.btnExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.shBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(811, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 522);
            this.barDockControlBottom.Manager = this.shBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(811, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Manager = this.shBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 483);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(811, 39);
            this.barDockControlRight.Manager = this.shBarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 483);
            // 
            // barButton_CapNhatCuocGoi
            // 
            this.barButton_CapNhatCuocGoi.Caption = "Cập nhật cuộc gọi";
            this.barButton_CapNhatCuocGoi.Id = 4;
            this.barButton_CapNhatCuocGoi.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic__find_people_01;
            this.barButton_CapNhatCuocGoi.Name = "barButton_CapNhatCuocGoi";
            // 
            // barButton_CheckDuplicate
            // 
            this.barButton_CheckDuplicate.Caption = "Kiểm tra trùng số đt";
            this.barButton_CheckDuplicate.Id = 5;
            this.barButton_CheckDuplicate.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_check_02_01;
            this.barButton_CheckDuplicate.Name = "barButton_CheckDuplicate";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Trạng thái";
            this.barSubItem1.Id = 6;
            this.barSubItem1.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_help_07_01;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButton_Active),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButton_UnActive)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButton_Active
            // 
            this.barButton_Active.Caption = "Hoạt động";
            this.barButton_Active.Id = 7;
            this.barButton_Active.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_check_03_01;
            this.barButton_Active.Name = "barButton_Active";
            // 
            // barButton_UnActive
            // 
            this.barButton_UnActive.Caption = "Ngưng hoạt động";
            this.barButton_UnActive.Id = 8;
            this.barButton_UnActive.ImageOptions.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.ic_lock_01;
            this.barButton_UnActive.Name = "barButton_UnActive";
            // 
            // gridKhachQuen
            // 
            this.gridKhachQuen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKhachQuen.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridKhachQuen.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridKhachQuen.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridKhachQuen.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridKhachQuen.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridKhachQuen.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridKhachQuen.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridKhachQuen.Location = new System.Drawing.Point(0, 39);
            this.gridKhachQuen.MainView = this.gridViewKhachQuen;
            this.gridKhachQuen.MenuManager = this.shBarManager;
            this.gridKhachQuen.Name = "gridKhachQuen";
            this.gridKhachQuen.Size = new System.Drawing.Size(811, 483);
            this.gridKhachQuen.TabIndex = 7;
            this.gridKhachQuen.UseEmbeddedNavigator = true;
            this.gridKhachQuen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewKhachQuen});
            // 
            // gridViewKhachQuen
            // 
            this.gridViewKhachQuen.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewKhachQuen.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewKhachQuen.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridViewKhachQuen.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewKhachQuen.ColumnPanelRowHeight = 35;
            this.gridViewKhachQuen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridViewKhachQuen.GridControl = this.gridKhachQuen;
            this.gridViewKhachQuen.Name = "gridViewKhachQuen";
            this.gridViewKhachQuen.OptionsBehavior.Editable = false;
            this.gridViewKhachQuen.OptionsPrint.AutoWidth = false;
            this.gridViewKhachQuen.OptionsPrint.PrintPreview = true;
            this.gridViewKhachQuen.OptionsSelection.MultiSelect = true;
            this.gridViewKhachQuen.OptionsView.ColumnAutoWidth = false;
            this.gridViewKhachQuen.OptionsView.ShowGroupPanel = false;
            this.gridViewKhachQuen.DoubleClick += new System.EventHandler(this.gridViewKhachQuen_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Loại";
            this.gridColumn2.FieldName = "TypeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Xếp hạng";
            this.gridColumn3.FieldName = "RankName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Số điện thoại";
            this.gridColumn4.FieldName = "Phones";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 96;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "Tên";
            this.gridColumn5.FieldName = "Name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "Địa chỉ";
            this.gridColumn6.FieldName = "Address";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "Ngày sinh";
            this.gridColumn7.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "BirthDay";
            this.gridColumn7.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "Email";
            this.gridColumn8.FieldName = "Email";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "Fax";
            this.gridColumn9.FieldName = "Fax";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.Caption = "Ghi chú";
            this.gridColumn10.FieldName = "Notes";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Xếp hạng";
            this.gridColumn11.FieldName = "Rank";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Phân loại";
            this.gridColumn12.FieldName = "Type";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // frmDMKhachQuen_V2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 522);
            this.Controls.Add(this.gridKhachQuen);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDMKhachQuen_V2";
            this.Text = "Danh mục khách hàng thân thiết";
            ((System.ComponentModel.ISupportInitialize)(this.shBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKhachQuen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKhachQuen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //  private Janus.Windows.GridEX.GridEX grdDoiTac;
        private DevExpress.XtraBars.Bar barMenuTop;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private Controls.Base.Controls.ShBarManager shBarManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem barButton_ThemMoi;
        private DevExpress.XtraBars.BarButtonItem barButton_Xoa;
        private DevExpress.XtraBars.BarButtonItem barButton_Excel;
        private DevExpress.XtraBars.BarButtonItem barButton_Search;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButton_Active;
        private DevExpress.XtraBars.BarButtonItem barButton_UnActive;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButton_CapNhatCuocGoi;
        private DevExpress.XtraBars.BarButtonItem barButton_CheckDuplicate;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private Controls.Base.Controls.ShGridControl gridKhachQuen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewKhachQuen;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}