namespace TaxiApplication
{
    partial class FormMainRibbon
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainRibbon));
            this.ribbonMainForm = new Taxi.Controls.Base.Controls.Ribbons.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.bbtnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnChenCuocGoiGoi = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnKhachDat = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnTinhTien = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.btnCheckApp = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.barButtonItem2 = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnQuanLyTapLenh = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.btnLuuHienThiLuoi = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.btnHienThiMacDinh = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnTangKichThuocLuoi = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnGiamKichThuocLuoi = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnDanhMucKhachDat = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnDanhSachCongTy = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.bbtnQuanLyTamLenhModule = new Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem();
            this.pageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pgDienThoai = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgKhachHang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgHienThiLuoi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageCongCu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.re = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.statusBar1 = new Taxi.Controls.Base.Controls.Ribbons.StatusBar();
            this.tabControl1 = new Taxi.Controls.Base.Controls.TabControl();
            this.tabPageChoGiaiQuyet = new Taxi.Controls.Base.Controls.TabPage();
            this.slChoGiaiQuyet = new System.Windows.Forms.SplitContainer();
            this.grdChoGiaiQuyet = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.grvChoGiaiQuyet = new Taxi.Controls.Base.Controls.Grids.Extends.DienThoaiGridView();
            this.colICon = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.cbICon = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageListICon = new System.Windows.Forms.ImageList(this.components);
            this.colLine = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colThoiDiemGoi = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDienThoai = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colLoaiXe = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDiaChi = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colVung = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colSLXe = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colXeNhan = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colXeMK = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colXeDungDiem = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colXeDenDiem = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colXeDon = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colLenhDTV = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colLenhLaiXe = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colLenhDHV = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colLenhMK = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDiaChiTraKhach = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colGhiChuTDV = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colGhiChuDTV = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDTV = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDHV = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colDanhSachXeDeCu = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.colGhiChuMK = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.grdCuocKhachLineKhac = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.grvCuocKhachLineKhac = new Taxi.Controls.Base.Controls.Grids.Extends.DienThoaiGridView();
            this.gridColumn49 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn50 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn51 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn52 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn53 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn54 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn55 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn56 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn57 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn58 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn59 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn60 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn61 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn62 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn63 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn64 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn65 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn66 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn67 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn68 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn69 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn70 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn71 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn72 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.PanelThongTinDiaChi = new System.Windows.Forms.Panel();
            this.btnAnHien = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblDienThoai = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblLenhDHV = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblDiaChiDon = new Taxi.Controls.Base.Controls.ShLabel();
            this.tabPageDaGiaiQuyet = new Taxi.Controls.Base.Controls.TabPage();
            this.grdDaGiaiQuyet = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.mnuSoDong = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItem100 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItem150 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItem200 = new System.Windows.Forms.ToolStripMenuItem();
            this.lấyLạiCuốcKháchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvDaGiaiQuyet = new Taxi.Controls.Base.Controls.Grids.GridView();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn4 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn5 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn6 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn7 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn8 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn9 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn10 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn11 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn12 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn13 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn14 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn15 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn16 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn17 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn18 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn19 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn20 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn21 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn22 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn23 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn24 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.tabPageTimKiemCuocGoi = new Taxi.Controls.Base.Controls.TabPage();
            this.grdTimKiemCuocGoi = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.grvTimKiemCuocGoi = new Taxi.Controls.Base.Controls.Grids.GridView();
            this.gridColumn26 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn27 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn28 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn29 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn30 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn31 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn32 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn33 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn34 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn35 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn36 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn37 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn38 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn39 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn40 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn41 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn42 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn43 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn44 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn45 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn46 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn47 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn48 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CbkSearchKenh4 = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.CbkSearchKenh3 = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.CbkSearchKenh2 = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.CbkSearchKenh1 = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchAddress = new Taxi.Controls.Base.Inputs.InputText();
            this.txtXeNhan = new Taxi.Controls.Base.Inputs.InputText();
            this.txtSearchPhone = new Taxi.Controls.Base.Inputs.InputText();
            this.tabPageCuocOnline = new Taxi.Controls.Base.Controls.TabPage();
            this.uc_CuocAppKH1 = new Taxi.Controls.FastTaxis.CuocAppKH.uc_CuocAppKH();
            this.panelTopHelp = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMainForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageChoGiaiQuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slChoGiaiQuyet)).BeginInit();
            this.slChoGiaiQuyet.Panel1.SuspendLayout();
            this.slChoGiaiQuyet.Panel2.SuspendLayout();
            this.slChoGiaiQuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChoGiaiQuyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChoGiaiQuyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbICon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuocKhachLineKhac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCuocKhachLineKhac)).BeginInit();
            this.PanelThongTinDiaChi.SuspendLayout();
            this.tabPageDaGiaiQuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaGiaiQuyet)).BeginInit();
            this.mnuSoDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDaGiaiQuyet)).BeginInit();
            this.tabPageTimKiemCuocGoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimKiemCuocGoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTimKiemCuocGoi)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXeNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchPhone.Properties)).BeginInit();
            this.tabPageCuocOnline.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Location = new System.Drawing.Point(0, 143);
            this.ribbon.Size = new System.Drawing.Size(1411, 0);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // ribbonMainForm
            // 
            this.ribbonMainForm.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbonMainForm.ApplicationButtonText = null;
            this.ribbonMainForm.ApplicationIcon = global::TaxiApplication.Properties.Resources.Staxi_96_ic_launcher1;
            this.ribbonMainForm.ExpandCollapseItem.Id = 0;
            this.ribbonMainForm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMainForm.ExpandCollapseItem,
            this.bbtnChenCuocGoiGoi,
            this.bbtnKhachDat,
            this.bbtnTinhTien,
            this.btnCheckApp,
            this.barButtonItem2,
            this.bbtnQuanLyTapLenh,
            this.btnLuuHienThiLuoi,
            this.btnHienThiMacDinh,
            this.bbtnTangKichThuocLuoi,
            this.bbtnGiamKichThuocLuoi,
            this.bbtnDangXuat,
            this.barButtonItem3,
            this.bbtnDanhMucKhachDat,
            this.bbtnDanhSachCongTy,
            this.bbtnQuanLyTamLenhModule});
            this.ribbonMainForm.Location = new System.Drawing.Point(0, 0);
            this.ribbonMainForm.MaxItemId = 21;
            this.ribbonMainForm.Name = "ribbonMainForm";
            this.ribbonMainForm.PageHeaderItemLinks.Add(this.barButtonItem2);
            this.ribbonMainForm.PageHeaderItemLinks.Add(this.ribbonMainForm.ExpandCollapseItem);
            this.ribbonMainForm.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageHome,
            this.PageCongCu});
            this.ribbonMainForm.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemPictureEdit1});
            this.ribbonMainForm.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonMainForm.Size = new System.Drawing.Size(1411, 143);
            this.ribbonMainForm.StatusBar = this.statusBar1;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.bbtnDangXuat);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItem3);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbonMainForm;
            // 
            // bbtnDangXuat
            // 
            this.bbtnDangXuat.Caption = "Đăng xuất";
            this.bbtnDangXuat.Id = 16;
            this.bbtnDangXuat.ImageOptions.Image = global::TaxiApplication.Properties.Resources.Apps_preferences_desktop_user_password_icon__1_;
            this.bbtnDangXuat.Name = "bbtnDangXuat";
            this.bbtnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnDangXuat_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Thoát";
            this.barButtonItem3.Id = 17;
            this.barButtonItem3.ImageOptions.Image = global::TaxiApplication.Properties.Resources.Close;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // bbtnChenCuocGoiGoi
            // 
            this.bbtnChenCuocGoiGoi.Caption = "Chèn cuốc gọi\r\n(Ctrl+G)";
            this.bbtnChenCuocGoiGoi.Id = 1;
            this.bbtnChenCuocGoiGoi.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.phone_add;
            this.bbtnChenCuocGoiGoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G));
            this.bbtnChenCuocGoiGoi.Name = "bbtnChenCuocGoiGoi";
            this.bbtnChenCuocGoiGoi.TagLanguage = null;
            this.bbtnChenCuocGoiGoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnChenCuocGoiGoi_ItemClick);
            // 
            // bbtnKhachDat
            // 
            this.bbtnKhachDat.Caption = "Khách đặt\r\n(F3)";
            this.bbtnKhachDat.Id = 6;
            this.bbtnKhachDat.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.Apps_date_icon;
            this.bbtnKhachDat.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bbtnKhachDat.Name = "bbtnKhachDat";
            this.bbtnKhachDat.TagLanguage = null;
            this.bbtnKhachDat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnKhachDat_ItemClick);
            // 
            // bbtnTinhTien
            // 
            this.bbtnTinhTien.Caption = "Tính tiền\r\n(F12)";
            this.bbtnTinhTien.Id = 7;
            this.bbtnTinhTien.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.dollar_icon;
            this.bbtnTinhTien.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            this.bbtnTinhTien.Name = "bbtnTinhTien";
            this.bbtnTinhTien.TagLanguage = null;
            this.bbtnTinhTien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnTinhTien_ItemClick);
            // 
            // btnCheckApp
            // 
            this.btnCheckApp.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnCheckApp.Caption = "Điều App OK";
            this.btnCheckApp.Id = 9;
            this.btnCheckApp.Name = "btnCheckApp";
            this.btnCheckApp.TagLanguage = null;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Help";
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.ImageOptions.Image = global::TaxiApplication.Properties.Resources.help2;
            this.barButtonItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ShortcutKeyDisplayString = "F1";
            this.barButtonItem2.TagLanguage = null;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bbtnQuanLyTapLenh
            // 
            this.bbtnQuanLyTapLenh.Caption = "Quản lý tập lệnh";
            this.bbtnQuanLyTapLenh.Id = 11;
            this.bbtnQuanLyTapLenh.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.SystemSetting;
            this.bbtnQuanLyTapLenh.Name = "bbtnQuanLyTapLenh";
            this.bbtnQuanLyTapLenh.TagLanguage = null;
            this.bbtnQuanLyTapLenh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnQuanLyTapLenh_ItemClick);
            // 
            // btnLuuHienThiLuoi
            // 
            this.btnLuuHienThiLuoi.Caption = "Lưu hiển thị lưới";
            this.btnLuuHienThiLuoi.Id = 12;
            this.btnLuuHienThiLuoi.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources._768px_Approve_icon_svg__1_;
            this.btnLuuHienThiLuoi.Name = "btnLuuHienThiLuoi";
            this.btnLuuHienThiLuoi.TagLanguage = null;
            this.btnLuuHienThiLuoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuuHienThiLuoi_ItemClick);
            // 
            // btnHienThiMacDinh
            // 
            this.btnHienThiMacDinh.Caption = "Hiển thị mặc định";
            this.btnHienThiMacDinh.Id = 13;
            this.btnHienThiMacDinh.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.Undo;
            this.btnHienThiMacDinh.Name = "btnHienThiMacDinh";
            this.btnHienThiMacDinh.TagLanguage = null;
            this.btnHienThiMacDinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHienThiMacDinh_ItemClick);
            // 
            // bbtnTangKichThuocLuoi
            // 
            this.bbtnTangKichThuocLuoi.Caption = "Tăng kích thước";
            this.bbtnTangKichThuocLuoi.Id = 14;
            this.bbtnTangKichThuocLuoi.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.Actions_arrow_up_icon;
            this.bbtnTangKichThuocLuoi.Name = "bbtnTangKichThuocLuoi";
            this.bbtnTangKichThuocLuoi.TagLanguage = null;
            this.bbtnTangKichThuocLuoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnTangKichThuocLuoi_ItemClick);
            // 
            // bbtnGiamKichThuocLuoi
            // 
            this.bbtnGiamKichThuocLuoi.Caption = "Giảm kích thước";
            this.bbtnGiamKichThuocLuoi.Id = 15;
            this.bbtnGiamKichThuocLuoi.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.Actions_arrow_down_icon;
            this.bbtnGiamKichThuocLuoi.Name = "bbtnGiamKichThuocLuoi";
            this.bbtnGiamKichThuocLuoi.TagLanguage = null;
            this.bbtnGiamKichThuocLuoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnGiamKichThuocLuoi_ItemClick);
            // 
            // bbtnDanhMucKhachDat
            // 
            this.bbtnDanhMucKhachDat.Caption = "Danh Sách khách đặt";
            this.bbtnDanhMucKhachDat.Id = 18;
            this.bbtnDanhMucKhachDat.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.Apps_date_icon;
            this.bbtnDanhMucKhachDat.Name = "bbtnDanhMucKhachDat";
            this.bbtnDanhMucKhachDat.TagLanguage = null;
            this.bbtnDanhMucKhachDat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnDanhMucKhachDat_ItemClick);
            // 
            // bbtnDanhSachCongTy
            // 
            this.bbtnDanhSachCongTy.Caption = "Danh sách công ty";
            this.bbtnDanhSachCongTy.Id = 19;
            this.bbtnDanhSachCongTy.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.MyDocXP;
            this.bbtnDanhSachCongTy.Name = "bbtnDanhSachCongTy";
            this.bbtnDanhSachCongTy.TagLanguage = null;
            this.bbtnDanhSachCongTy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnDanhSachCongTy_ItemClick);
            // 
            // bbtnQuanLyTamLenhModule
            // 
            this.bbtnQuanLyTamLenhModule.Caption = "Quản lý tập lệnh từng vai trò";
            this.bbtnQuanLyTamLenhModule.Id = 20;
            this.bbtnQuanLyTamLenhModule.ImageOptions.LargeImage = global::TaxiApplication.Properties.Resources.SystemAdmin;
            this.bbtnQuanLyTamLenhModule.Name = "bbtnQuanLyTamLenhModule";
            this.bbtnQuanLyTamLenhModule.TagLanguage = null;
            this.bbtnQuanLyTamLenhModule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnQuanLyTamLenhModule_ItemClick);
            // 
            // pageHome
            // 
            this.pageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pgDienThoai,
            this.pgKhachHang,
            this.pgHienThiLuoi});
            this.pageHome.Name = "pageHome";
            this.pageHome.Text = "Home";
            // 
            // pgDienThoai
            // 
            this.pgDienThoai.ItemLinks.Add(this.bbtnChenCuocGoiGoi);
            this.pgDienThoai.Name = "pgDienThoai";
            this.pgDienThoai.ShowCaptionButton = false;
            this.pgDienThoai.Text = "Điện thoại";
            // 
            // pgKhachHang
            // 
            this.pgKhachHang.AllowTextClipping = false;
            this.pgKhachHang.ItemLinks.Add(this.bbtnKhachDat);
            this.pgKhachHang.ItemLinks.Add(this.bbtnTinhTien);
            this.pgKhachHang.Name = "pgKhachHang";
            this.pgKhachHang.ShowCaptionButton = false;
            this.pgKhachHang.Text = "Khách hàng";
            // 
            // pgHienThiLuoi
            // 
            this.pgHienThiLuoi.AllowTextClipping = false;
            this.pgHienThiLuoi.ItemLinks.Add(this.btnLuuHienThiLuoi);
            this.pgHienThiLuoi.ItemLinks.Add(this.btnHienThiMacDinh);
            this.pgHienThiLuoi.ItemLinks.Add(this.bbtnTangKichThuocLuoi);
            this.pgHienThiLuoi.ItemLinks.Add(this.bbtnGiamKichThuocLuoi);
            this.pgHienThiLuoi.Name = "pgHienThiLuoi";
            this.pgHienThiLuoi.ShowCaptionButton = false;
            this.pgHienThiLuoi.Text = "Hiển thị lưới";
            // 
            // PageCongCu
            // 
            this.PageCongCu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.re,
            this.pgDanhMuc});
            this.PageCongCu.Name = "PageCongCu";
            this.PageCongCu.Text = "Công cụ";
            // 
            // re
            // 
            this.re.AllowTextClipping = false;
            this.re.ItemLinks.Add(this.bbtnQuanLyTapLenh);
            this.re.ItemLinks.Add(this.bbtnQuanLyTamLenhModule);
            this.re.Name = "re";
            this.re.ShowCaptionButton = false;
            this.re.Text = "Quản lý";
            // 
            // pgDanhMuc
            // 
            this.pgDanhMuc.AllowTextClipping = false;
            this.pgDanhMuc.ItemLinks.Add(this.bbtnDanhMucKhachDat);
            this.pgDanhMuc.ItemLinks.Add(this.bbtnDanhSachCongTy);
            this.pgDanhMuc.Name = "pgDanhMuc";
            this.pgDanhMuc.ShowCaptionButton = false;
            this.pgDanhMuc.Text = "Danh Mục";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Vietnam",
            "English"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.NullText = "Chọn ngôn ngữ";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
            // 
            // statusBar1
            // 
            this.statusBar1.ItemLinks.Add(this.btnCheckApp);
            this.statusBar1.Location = new System.Drawing.Point(0, 880);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Ribbon = this.ribbonMainForm;
            this.statusBar1.Size = new System.Drawing.Size(1411, 31);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.IsClosePageCurrent = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 143);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tabPageChoGiaiQuyet;
            this.tabControl1.Size = new System.Drawing.Size(1411, 737);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageChoGiaiQuyet,
            this.tabPageDaGiaiQuyet,
            this.tabPageTimKiemCuocGoi,
            this.tabPageCuocOnline});
            this.tabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl1_SelectedPageChanged);
            // 
            // tabPageChoGiaiQuyet
            // 
            this.tabPageChoGiaiQuyet.Controls.Add(this.slChoGiaiQuyet);
            this.tabPageChoGiaiQuyet.Controls.Add(this.PanelThongTinDiaChi);
            this.tabPageChoGiaiQuyet.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.tabPageChoGiaiQuyet.Name = "tabPageChoGiaiQuyet";
            this.tabPageChoGiaiQuyet.Size = new System.Drawing.Size(1405, 709);
            this.tabPageChoGiaiQuyet.TagLanguage = null;
            this.tabPageChoGiaiQuyet.Text = "Chờ giải quyết (Alt+1)";
            // 
            // slChoGiaiQuyet
            // 
            this.slChoGiaiQuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slChoGiaiQuyet.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.slChoGiaiQuyet.Location = new System.Drawing.Point(0, 34);
            this.slChoGiaiQuyet.Name = "slChoGiaiQuyet";
            // 
            // slChoGiaiQuyet.Panel1
            // 
            this.slChoGiaiQuyet.Panel1.Controls.Add(this.grdChoGiaiQuyet);
            // 
            // slChoGiaiQuyet.Panel2
            // 
            this.slChoGiaiQuyet.Panel2.Controls.Add(this.grdCuocKhachLineKhac);
            this.slChoGiaiQuyet.Size = new System.Drawing.Size(1405, 675);
            this.slChoGiaiQuyet.SplitterDistance = 1118;
            this.slChoGiaiQuyet.TabIndex = 1;
            // 
            // grdChoGiaiQuyet
            // 
            this.grdChoGiaiQuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdChoGiaiQuyet.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdChoGiaiQuyet.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdChoGiaiQuyet.Location = new System.Drawing.Point(0, 0);
            this.grdChoGiaiQuyet.MainView = this.grvChoGiaiQuyet;
            this.grdChoGiaiQuyet.MenuManager = this.ribbonMainForm;
            this.grdChoGiaiQuyet.Name = "grdChoGiaiQuyet";
            this.grdChoGiaiQuyet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbICon});
            this.grdChoGiaiQuyet.Size = new System.Drawing.Size(1118, 675);
            this.grdChoGiaiQuyet.TabIndex = 0;
            this.grdChoGiaiQuyet.UseEmbeddedNavigator = true;
            this.grdChoGiaiQuyet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChoGiaiQuyet});
            // 
            // grvChoGiaiQuyet
            // 
            this.grvChoGiaiQuyet.ActiveFilterEnabled = false;
            this.grvChoGiaiQuyet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvChoGiaiQuyet.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvChoGiaiQuyet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvChoGiaiQuyet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvChoGiaiQuyet.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grvChoGiaiQuyet.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvChoGiaiQuyet.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvChoGiaiQuyet.ColumnPanelRowHeight = 35;
            this.grvChoGiaiQuyet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICon,
            this.colLine,
            this.colThoiDiemGoi,
            this.colDienThoai,
            this.colLoaiXe,
            this.colDiaChi,
            this.colVung,
            this.colSLXe,
            this.colXeNhan,
            this.colXeMK,
            this.colXeDungDiem,
            this.colXeDenDiem,
            this.colXeDon,
            this.colLenhDTV,
            this.colLenhLaiXe,
            this.colLenhDHV,
            this.colLenhMK,
            this.colDiaChiTraKhach,
            this.colGhiChuTDV,
            this.colGhiChuDTV,
            this.colDTV,
            this.colDHV,
            this.colDanhSachXeDeCu,
            this.colGhiChuMK});
            this.grvChoGiaiQuyet.GridControl = this.grdChoGiaiQuyet;
            this.grvChoGiaiQuyet.Images = this.imageListICon;
            this.grvChoGiaiQuyet.IndicatorWidth = 35;
            this.grvChoGiaiQuyet.IsCommand = true;
            this.grvChoGiaiQuyet.IsKeyEnterAndDoubleClickOnPopUp = true;
            this.grvChoGiaiQuyet.IsPopUp = true;
            this.grvChoGiaiQuyet.Name = "grvChoGiaiQuyet";
            this.grvChoGiaiQuyet.OptionsBehavior.Editable = false;
            this.grvChoGiaiQuyet.OptionsCustomization.AllowFilter = false;
            this.grvChoGiaiQuyet.OptionsCustomization.AllowSort = false;
            this.grvChoGiaiQuyet.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grvChoGiaiQuyet.OptionsFilter.AllowFilterEditor = false;
            this.grvChoGiaiQuyet.OptionsFind.AllowFindPanel = false;
            this.grvChoGiaiQuyet.OptionsView.ColumnAutoWidth = false;
            this.grvChoGiaiQuyet.OptionsView.ShowGroupPanel = false;
            this.grvChoGiaiQuyet.RowIndex = 0;
            this.grvChoGiaiQuyet.Timer_Step_1 = 0;
            this.grvChoGiaiQuyet.Timer_Step_2 = 3;
            this.grvChoGiaiQuyet.Timer_Step_3 = 5;
            this.grvChoGiaiQuyet.Timer_Step_4 = 10;
            this.grvChoGiaiQuyet.Timer_Step_5 = 60;
            this.grvChoGiaiQuyet.TimerInterval = 1000;
            this.grvChoGiaiQuyet.GridStyles += new Taxi.Controls.Base.Controls.Grids.Extends.GridStyle(this.grvChoGiaiQuyet_GridStyles);
            this.grvChoGiaiQuyet.DoCommand += new System.Action<Taxi.Business.CuocGoi, Taxi.Data.G5.DanhMuc.G5Command>(this.grvChoGiaiQuyet_DoCommand);
            this.grvChoGiaiQuyet.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvChoGiaiQuyet_FocusedRowChanged);
            // 
            // colICon
            // 
            this.colICon.AppearanceCell.Options.UseTextOptions = true;
            this.colICon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colICon.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colICon.Caption = " ";
            this.colICon.ColumnEdit = this.cbICon;
            this.colICon.FieldName = "ICon";
            this.colICon.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colICon.Name = "colICon";
            this.colICon.TagLanguage = null;
            this.colICon.Visible = true;
            this.colICon.VisibleIndex = 0;
            this.colICon.Width = 24;
            // 
            // cbICon
            // 
            this.cbICon.AutoHeight = false;
            this.cbICon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cbICon.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbICon.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 0)});
            this.cbICon.LargeImages = this.imageListICon;
            this.cbICon.Name = "cbICon";
            // 
            // imageListICon
            // 
            this.imageListICon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListICon.ImageStream")));
            this.imageListICon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListICon.Images.SetKeyName(0, "App_Cancel16x16.png");
            this.imageListICon.Images.SetKeyName(1, "App16x16.png");
            this.imageListICon.Images.SetKeyName(2, "phone16x16.png");
            // 
            // colLine
            // 
            this.colLine.AppearanceCell.Options.UseTextOptions = true;
            this.colLine.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLine.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLine.Caption = "Máy";
            this.colLine.FieldName = "Line";
            this.colLine.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colLine.Name = "colLine";
            this.colLine.OptionsColumn.AllowEdit = false;
            this.colLine.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLine.OptionsFilter.AllowAutoFilter = false;
            this.colLine.OptionsFilter.AllowFilter = false;
            this.colLine.TagLanguage = null;
            this.colLine.Visible = true;
            this.colLine.VisibleIndex = 1;
            this.colLine.Width = 33;
            // 
            // colThoiDiemGoi
            // 
            this.colThoiDiemGoi.AppearanceCell.Options.UseTextOptions = true;
            this.colThoiDiemGoi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThoiDiemGoi.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colThoiDiemGoi.Caption = "Thời điểm gọi";
            this.colThoiDiemGoi.DisplayFormat.FormatString = "HH:ss:mm dd/MM/yyyy";
            this.colThoiDiemGoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colThoiDiemGoi.FieldName = "ThoiDiemGoi";
            this.colThoiDiemGoi.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colThoiDiemGoi.Name = "colThoiDiemGoi";
            this.colThoiDiemGoi.OptionsColumn.AllowEdit = false;
            this.colThoiDiemGoi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colThoiDiemGoi.OptionsFilter.AllowAutoFilter = false;
            this.colThoiDiemGoi.OptionsFilter.AllowFilter = false;
            this.colThoiDiemGoi.TagLanguage = null;
            this.colThoiDiemGoi.Visible = true;
            this.colThoiDiemGoi.VisibleIndex = 2;
            this.colThoiDiemGoi.Width = 90;
            // 
            // colDienThoai
            // 
            this.colDienThoai.AppearanceCell.Options.UseTextOptions = true;
            this.colDienThoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDienThoai.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDienThoai.Caption = "Điện thoại";
            this.colDienThoai.FieldName = "PhoneNumber";
            this.colDienThoai.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.OptionsColumn.AllowEdit = false;
            this.colDienThoai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDienThoai.OptionsFilter.AllowAutoFilter = false;
            this.colDienThoai.OptionsFilter.AllowFilter = false;
            this.colDienThoai.TagLanguage = null;
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 3;
            this.colDienThoai.Width = 87;
            // 
            // colLoaiXe
            // 
            this.colLoaiXe.Caption = "Loại xe";
            this.colLoaiXe.FieldName = "LoaiXe";
            this.colLoaiXe.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colLoaiXe.Name = "colLoaiXe";
            this.colLoaiXe.OptionsColumn.AllowEdit = false;
            this.colLoaiXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLoaiXe.OptionsFilter.AllowAutoFilter = false;
            this.colLoaiXe.OptionsFilter.AllowFilter = false;
            this.colLoaiXe.TagLanguage = null;
            this.colLoaiXe.Visible = true;
            this.colLoaiXe.VisibleIndex = 4;
            this.colLoaiXe.Width = 66;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DiaChiDonKhach";
            this.colDiaChi.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.AllowEdit = false;
            this.colDiaChi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDiaChi.OptionsFilter.AllowAutoFilter = false;
            this.colDiaChi.OptionsFilter.AllowFilter = false;
            this.colDiaChi.TagLanguage = null;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 5;
            this.colDiaChi.Width = 235;
            // 
            // colVung
            // 
            this.colVung.AppearanceCell.Options.UseTextOptions = true;
            this.colVung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVung.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVung.Caption = "Vùng";
            this.colVung.FieldName = "Vung";
            this.colVung.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colVung.Name = "colVung";
            this.colVung.OptionsColumn.AllowEdit = false;
            this.colVung.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colVung.OptionsFilter.AllowAutoFilter = false;
            this.colVung.OptionsFilter.AllowFilter = false;
            this.colVung.TagLanguage = null;
            this.colVung.Visible = true;
            this.colVung.VisibleIndex = 6;
            this.colVung.Width = 37;
            // 
            // colSLXe
            // 
            this.colSLXe.AppearanceCell.Options.UseTextOptions = true;
            this.colSLXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSLXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSLXe.Caption = "SL xe";
            this.colSLXe.FieldName = "SoLuong";
            this.colSLXe.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colSLXe.Name = "colSLXe";
            this.colSLXe.OptionsColumn.AllowEdit = false;
            this.colSLXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSLXe.OptionsFilter.AllowAutoFilter = false;
            this.colSLXe.OptionsFilter.AllowFilter = false;
            this.colSLXe.TagLanguage = null;
            this.colSLXe.Visible = true;
            this.colSLXe.VisibleIndex = 7;
            this.colSLXe.Width = 38;
            // 
            // colXeNhan
            // 
            this.colXeNhan.AppearanceCell.Options.UseTextOptions = true;
            this.colXeNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXeNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colXeNhan.Caption = "Xe nhận";
            this.colXeNhan.FieldName = "XeNhan";
            this.colXeNhan.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colXeNhan.Name = "colXeNhan";
            this.colXeNhan.OptionsColumn.AllowEdit = false;
            this.colXeNhan.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colXeNhan.OptionsFilter.AllowAutoFilter = false;
            this.colXeNhan.OptionsFilter.AllowFilter = false;
            this.colXeNhan.TagLanguage = null;
            this.colXeNhan.Visible = true;
            this.colXeNhan.VisibleIndex = 8;
            this.colXeNhan.Width = 68;
            // 
            // colXeMK
            // 
            this.colXeMK.AppearanceCell.Options.UseTextOptions = true;
            this.colXeMK.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXeMK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colXeMK.Caption = "Xe MK";
            this.colXeMK.FieldName = "BTBG_NoiDungXuLy";
            this.colXeMK.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colXeMK.Name = "colXeMK";
            this.colXeMK.OptionsColumn.AllowEdit = false;
            this.colXeMK.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colXeMK.OptionsFilter.AllowAutoFilter = false;
            this.colXeMK.OptionsFilter.AllowFilter = false;
            this.colXeMK.TagLanguage = null;
            this.colXeMK.Visible = true;
            this.colXeMK.VisibleIndex = 9;
            this.colXeMK.Width = 77;
            // 
            // colXeDungDiem
            // 
            this.colXeDungDiem.AppearanceCell.Options.UseTextOptions = true;
            this.colXeDungDiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXeDungDiem.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colXeDungDiem.Caption = "Xe dừng điểm";
            this.colXeDungDiem.FieldName = "XeDungDiem";
            this.colXeDungDiem.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colXeDungDiem.Name = "colXeDungDiem";
            this.colXeDungDiem.OptionsColumn.AllowEdit = false;
            this.colXeDungDiem.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colXeDungDiem.OptionsFilter.AllowAutoFilter = false;
            this.colXeDungDiem.OptionsFilter.AllowFilter = false;
            this.colXeDungDiem.TagLanguage = null;
            this.colXeDungDiem.Visible = true;
            this.colXeDungDiem.VisibleIndex = 10;
            this.colXeDungDiem.Width = 77;
            // 
            // colXeDenDiem
            // 
            this.colXeDenDiem.AppearanceCell.Options.UseTextOptions = true;
            this.colXeDenDiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXeDenDiem.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colXeDenDiem.Caption = "Xe đến điểm";
            this.colXeDenDiem.FieldName = "XeDenDiem";
            this.colXeDenDiem.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colXeDenDiem.Name = "colXeDenDiem";
            this.colXeDenDiem.OptionsColumn.AllowEdit = false;
            this.colXeDenDiem.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colXeDenDiem.OptionsFilter.AllowAutoFilter = false;
            this.colXeDenDiem.OptionsFilter.AllowFilter = false;
            this.colXeDenDiem.TagLanguage = null;
            this.colXeDenDiem.Visible = true;
            this.colXeDenDiem.VisibleIndex = 11;
            this.colXeDenDiem.Width = 64;
            // 
            // colXeDon
            // 
            this.colXeDon.AppearanceCell.Options.UseTextOptions = true;
            this.colXeDon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXeDon.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colXeDon.Caption = "Xe đón";
            this.colXeDon.FieldName = "XeDon";
            this.colXeDon.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colXeDon.Name = "colXeDon";
            this.colXeDon.OptionsColumn.AllowEdit = false;
            this.colXeDon.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colXeDon.OptionsFilter.AllowAutoFilter = false;
            this.colXeDon.OptionsFilter.AllowFilter = false;
            this.colXeDon.TagLanguage = null;
            this.colXeDon.Visible = true;
            this.colXeDon.VisibleIndex = 12;
            this.colXeDon.Width = 65;
            // 
            // colLenhDTV
            // 
            this.colLenhDTV.AppearanceCell.Options.UseTextOptions = true;
            this.colLenhDTV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLenhDTV.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLenhDTV.Caption = "Lệnh ĐTV";
            this.colLenhDTV.FieldName = "LenhDienThoai";
            this.colLenhDTV.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colLenhDTV.Name = "colLenhDTV";
            this.colLenhDTV.OptionsColumn.AllowEdit = false;
            this.colLenhDTV.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLenhDTV.OptionsFilter.AllowAutoFilter = false;
            this.colLenhDTV.OptionsFilter.AllowFilter = false;
            this.colLenhDTV.TagLanguage = null;
            this.colLenhDTV.Visible = true;
            this.colLenhDTV.VisibleIndex = 13;
            this.colLenhDTV.Width = 115;
            // 
            // colLenhLaiXe
            // 
            this.colLenhLaiXe.AppearanceCell.Options.UseTextOptions = true;
            this.colLenhLaiXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLenhLaiXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLenhLaiXe.Caption = "Lệnh lái xe";
            this.colLenhLaiXe.FieldName = "LenhLaiXe";
            this.colLenhLaiXe.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colLenhLaiXe.Name = "colLenhLaiXe";
            this.colLenhLaiXe.OptionsColumn.AllowEdit = false;
            this.colLenhLaiXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLenhLaiXe.OptionsFilter.AllowAutoFilter = false;
            this.colLenhLaiXe.OptionsFilter.AllowFilter = false;
            this.colLenhLaiXe.TagLanguage = null;
            this.colLenhLaiXe.Visible = true;
            this.colLenhLaiXe.VisibleIndex = 14;
            this.colLenhLaiXe.Width = 112;
            // 
            // colLenhDHV
            // 
            this.colLenhDHV.AppearanceCell.Options.UseTextOptions = true;
            this.colLenhDHV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLenhDHV.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLenhDHV.Caption = "Lệnh ĐHV";
            this.colLenhDHV.FieldName = "LenhTongDai";
            this.colLenhDHV.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colLenhDHV.Name = "colLenhDHV";
            this.colLenhDHV.OptionsColumn.AllowEdit = false;
            this.colLenhDHV.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLenhDHV.OptionsFilter.AllowAutoFilter = false;
            this.colLenhDHV.OptionsFilter.AllowFilter = false;
            this.colLenhDHV.TagLanguage = null;
            this.colLenhDHV.Visible = true;
            this.colLenhDHV.VisibleIndex = 15;
            this.colLenhDHV.Width = 115;
            // 
            // colLenhMK
            // 
            this.colLenhMK.AppearanceCell.Options.UseTextOptions = true;
            this.colLenhMK.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLenhMK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLenhMK.Caption = "Lệnh MK";
            this.colLenhMK.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colLenhMK.Name = "colLenhMK";
            this.colLenhMK.OptionsColumn.AllowEdit = false;
            this.colLenhMK.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLenhMK.OptionsFilter.AllowAutoFilter = false;
            this.colLenhMK.OptionsFilter.AllowFilter = false;
            this.colLenhMK.TagLanguage = null;
            this.colLenhMK.Visible = true;
            this.colLenhMK.VisibleIndex = 16;
            this.colLenhMK.Width = 121;
            // 
            // colDiaChiTraKhach
            // 
            this.colDiaChiTraKhach.Caption = "Địa chỉ trả khách";
            this.colDiaChiTraKhach.FieldName = "DiaChiTraKhach";
            this.colDiaChiTraKhach.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDiaChiTraKhach.Name = "colDiaChiTraKhach";
            this.colDiaChiTraKhach.OptionsColumn.AllowEdit = false;
            this.colDiaChiTraKhach.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDiaChiTraKhach.OptionsFilter.AllowAutoFilter = false;
            this.colDiaChiTraKhach.OptionsFilter.AllowFilter = false;
            this.colDiaChiTraKhach.TagLanguage = null;
            this.colDiaChiTraKhach.Visible = true;
            this.colDiaChiTraKhach.VisibleIndex = 17;
            this.colDiaChiTraKhach.Width = 149;
            // 
            // colGhiChuTDV
            // 
            this.colGhiChuTDV.Caption = "Ghi chú TĐV";
            this.colGhiChuTDV.FieldName = "GhiChuTongDai";
            this.colGhiChuTDV.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colGhiChuTDV.Name = "colGhiChuTDV";
            this.colGhiChuTDV.OptionsColumn.AllowEdit = false;
            this.colGhiChuTDV.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGhiChuTDV.OptionsFilter.AllowAutoFilter = false;
            this.colGhiChuTDV.OptionsFilter.AllowFilter = false;
            this.colGhiChuTDV.TagLanguage = null;
            this.colGhiChuTDV.Visible = true;
            this.colGhiChuTDV.VisibleIndex = 18;
            this.colGhiChuTDV.Width = 108;
            // 
            // colGhiChuDTV
            // 
            this.colGhiChuDTV.Caption = "Ghi chú ĐTV";
            this.colGhiChuDTV.FieldName = "GhiChuDienThoai";
            this.colGhiChuDTV.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colGhiChuDTV.Name = "colGhiChuDTV";
            this.colGhiChuDTV.OptionsColumn.AllowEdit = false;
            this.colGhiChuDTV.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGhiChuDTV.OptionsFilter.AllowAutoFilter = false;
            this.colGhiChuDTV.OptionsFilter.AllowFilter = false;
            this.colGhiChuDTV.TagLanguage = null;
            this.colGhiChuDTV.Visible = true;
            this.colGhiChuDTV.VisibleIndex = 19;
            this.colGhiChuDTV.Width = 113;
            // 
            // colDTV
            // 
            this.colDTV.AppearanceCell.Options.UseTextOptions = true;
            this.colDTV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDTV.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDTV.Caption = "ĐTV";
            this.colDTV.FieldName = "MaNhanVienDienThoai";
            this.colDTV.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDTV.Name = "colDTV";
            this.colDTV.OptionsColumn.AllowEdit = false;
            this.colDTV.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDTV.OptionsFilter.AllowAutoFilter = false;
            this.colDTV.OptionsFilter.AllowFilter = false;
            this.colDTV.TagLanguage = null;
            this.colDTV.Visible = true;
            this.colDTV.VisibleIndex = 20;
            this.colDTV.Width = 112;
            // 
            // colDHV
            // 
            this.colDHV.AppearanceCell.Options.UseTextOptions = true;
            this.colDHV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDHV.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDHV.Caption = "ĐHV";
            this.colDHV.FieldName = "MaNhanVienTongDai";
            this.colDHV.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDHV.Name = "colDHV";
            this.colDHV.OptionsColumn.AllowEdit = false;
            this.colDHV.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDHV.OptionsFilter.AllowAutoFilter = false;
            this.colDHV.OptionsFilter.AllowFilter = false;
            this.colDHV.TagLanguage = null;
            this.colDHV.Visible = true;
            this.colDHV.VisibleIndex = 21;
            this.colDHV.Width = 102;
            // 
            // colDanhSachXeDeCu
            // 
            this.colDanhSachXeDeCu.AppearanceCell.Options.UseTextOptions = true;
            this.colDanhSachXeDeCu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDanhSachXeDeCu.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDanhSachXeDeCu.Caption = "Danh sách xe đề cử";
            this.colDanhSachXeDeCu.FieldName = "DanhSachXeDeCu";
            this.colDanhSachXeDeCu.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colDanhSachXeDeCu.Name = "colDanhSachXeDeCu";
            this.colDanhSachXeDeCu.OptionsColumn.AllowEdit = false;
            this.colDanhSachXeDeCu.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDanhSachXeDeCu.OptionsFilter.AllowAutoFilter = false;
            this.colDanhSachXeDeCu.OptionsFilter.AllowFilter = false;
            this.colDanhSachXeDeCu.TagLanguage = null;
            this.colDanhSachXeDeCu.Visible = true;
            this.colDanhSachXeDeCu.VisibleIndex = 22;
            this.colDanhSachXeDeCu.Width = 129;
            // 
            // colGhiChuMK
            // 
            this.colGhiChuMK.Caption = "Ghi chú MK";
            this.colGhiChuMK.FieldName = "MOIKHACH_KhieuNai_ThongTinThem";
            this.colGhiChuMK.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.colGhiChuMK.Name = "colGhiChuMK";
            this.colGhiChuMK.OptionsColumn.AllowEdit = false;
            this.colGhiChuMK.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGhiChuMK.OptionsFilter.AllowAutoFilter = false;
            this.colGhiChuMK.OptionsFilter.AllowFilter = false;
            this.colGhiChuMK.TagLanguage = null;
            this.colGhiChuMK.Visible = true;
            this.colGhiChuMK.VisibleIndex = 23;
            this.colGhiChuMK.Width = 139;
            // 
            // grdCuocKhachLineKhac
            // 
            this.grdCuocKhachLineKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.First.Visible = false;
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdCuocKhachLineKhac.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdCuocKhachLineKhac.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdCuocKhachLineKhac.Location = new System.Drawing.Point(0, 0);
            this.grdCuocKhachLineKhac.MainView = this.grvCuocKhachLineKhac;
            this.grdCuocKhachLineKhac.MenuManager = this.ribbonMainForm;
            this.grdCuocKhachLineKhac.Name = "grdCuocKhachLineKhac";
            this.grdCuocKhachLineKhac.Size = new System.Drawing.Size(283, 675);
            this.grdCuocKhachLineKhac.TabIndex = 1;
            this.grdCuocKhachLineKhac.UseEmbeddedNavigator = true;
            this.grdCuocKhachLineKhac.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCuocKhachLineKhac});
            // 
            // grvCuocKhachLineKhac
            // 
            this.grvCuocKhachLineKhac.ActiveFilterEnabled = false;
            this.grvCuocKhachLineKhac.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCuocKhachLineKhac.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCuocKhachLineKhac.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCuocKhachLineKhac.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCuocKhachLineKhac.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grvCuocKhachLineKhac.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCuocKhachLineKhac.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvCuocKhachLineKhac.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8F);
            this.grvCuocKhachLineKhac.ColumnPanelRowHeight = 35;
            this.grvCuocKhachLineKhac.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn49,
            this.gridColumn50,
            this.gridColumn51,
            this.gridColumn52,
            this.gridColumn53,
            this.gridColumn54,
            this.gridColumn55,
            this.gridColumn56,
            this.gridColumn57,
            this.gridColumn58,
            this.gridColumn59,
            this.gridColumn60,
            this.gridColumn61,
            this.gridColumn62,
            this.gridColumn63,
            this.gridColumn64,
            this.gridColumn65,
            this.gridColumn66,
            this.gridColumn67,
            this.gridColumn68,
            this.gridColumn69,
            this.gridColumn70,
            this.gridColumn71,
            this.gridColumn72});
            this.grvCuocKhachLineKhac.GridControl = this.grdCuocKhachLineKhac;
            this.grvCuocKhachLineKhac.IndicatorWidth = 35;
            this.grvCuocKhachLineKhac.IsCommand = false;
            this.grvCuocKhachLineKhac.IsKeyEnterAndDoubleClickOnPopUp = true;
            this.grvCuocKhachLineKhac.IsPopUp = true;
            this.grvCuocKhachLineKhac.Name = "grvCuocKhachLineKhac";
            this.grvCuocKhachLineKhac.OptionsBehavior.Editable = false;
            this.grvCuocKhachLineKhac.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grvCuocKhachLineKhac.OptionsFilter.AllowFilterEditor = false;
            this.grvCuocKhachLineKhac.OptionsFind.AllowFindPanel = false;
            this.grvCuocKhachLineKhac.OptionsView.ColumnAutoWidth = false;
            this.grvCuocKhachLineKhac.OptionsView.ShowGroupPanel = false;
            this.grvCuocKhachLineKhac.RowIndex = 0;
            this.grvCuocKhachLineKhac.Timer_Step_1 = 0;
            this.grvCuocKhachLineKhac.Timer_Step_2 = 3;
            this.grvCuocKhachLineKhac.Timer_Step_3 = 5;
            this.grvCuocKhachLineKhac.Timer_Step_4 = 10;
            this.grvCuocKhachLineKhac.Timer_Step_5 = 60;
            this.grvCuocKhachLineKhac.TimerInterval = 1000;
            // 
            // gridColumn49
            // 
            this.gridColumn49.FieldName = "ICon";
            this.gridColumn49.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.TagLanguage = null;
            this.gridColumn49.Width = 37;
            // 
            // gridColumn50
            // 
            this.gridColumn50.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn50.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn50.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn50.Caption = "Máy";
            this.gridColumn50.FieldName = "Line";
            this.gridColumn50.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn50.Name = "gridColumn50";
            this.gridColumn50.OptionsColumn.AllowEdit = false;
            this.gridColumn50.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn50.OptionsFilter.AllowFilter = false;
            this.gridColumn50.TagLanguage = null;
            this.gridColumn50.Visible = true;
            this.gridColumn50.VisibleIndex = 0;
            this.gridColumn50.Width = 32;
            // 
            // gridColumn51
            // 
            this.gridColumn51.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn51.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn51.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn51.Caption = "Thời điểm gọi";
            this.gridColumn51.DisplayFormat.FormatString = "HH:mm dd/MM";
            this.gridColumn51.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn51.FieldName = "ThoiDiemGoi";
            this.gridColumn51.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn51.Name = "gridColumn51";
            this.gridColumn51.OptionsColumn.AllowEdit = false;
            this.gridColumn51.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn51.OptionsFilter.AllowFilter = false;
            this.gridColumn51.TagLanguage = null;
            this.gridColumn51.Visible = true;
            this.gridColumn51.VisibleIndex = 1;
            this.gridColumn51.Width = 95;
            // 
            // gridColumn52
            // 
            this.gridColumn52.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn52.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn52.Caption = "Điện thoại";
            this.gridColumn52.FieldName = "PhoneNumber";
            this.gridColumn52.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn52.Name = "gridColumn52";
            this.gridColumn52.OptionsColumn.AllowEdit = false;
            this.gridColumn52.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn52.OptionsFilter.AllowFilter = false;
            this.gridColumn52.TagLanguage = null;
            this.gridColumn52.Visible = true;
            this.gridColumn52.VisibleIndex = 2;
            this.gridColumn52.Width = 90;
            // 
            // gridColumn53
            // 
            this.gridColumn53.Caption = "Loại xe";
            this.gridColumn53.FieldName = "LoaiXe";
            this.gridColumn53.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.OptionsColumn.AllowEdit = false;
            this.gridColumn53.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn53.OptionsFilter.AllowFilter = false;
            this.gridColumn53.TagLanguage = null;
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 3;
            this.gridColumn53.Width = 57;
            // 
            // gridColumn54
            // 
            this.gridColumn54.Caption = "Địa chỉ";
            this.gridColumn54.FieldName = "DiaChiDonKhach";
            this.gridColumn54.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn54.Name = "gridColumn54";
            this.gridColumn54.OptionsColumn.AllowEdit = false;
            this.gridColumn54.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn54.OptionsFilter.AllowFilter = false;
            this.gridColumn54.TagLanguage = null;
            this.gridColumn54.Visible = true;
            this.gridColumn54.VisibleIndex = 4;
            this.gridColumn54.Width = 210;
            // 
            // gridColumn55
            // 
            this.gridColumn55.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn55.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn55.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn55.Caption = "Vùng";
            this.gridColumn55.FieldName = "Vung";
            this.gridColumn55.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn55.Name = "gridColumn55";
            this.gridColumn55.OptionsColumn.AllowEdit = false;
            this.gridColumn55.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn55.OptionsFilter.AllowFilter = false;
            this.gridColumn55.TagLanguage = null;
            this.gridColumn55.Visible = true;
            this.gridColumn55.VisibleIndex = 5;
            this.gridColumn55.Width = 37;
            // 
            // gridColumn56
            // 
            this.gridColumn56.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn56.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn56.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn56.Caption = "SL xe";
            this.gridColumn56.FieldName = "SoLuong";
            this.gridColumn56.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.OptionsColumn.AllowEdit = false;
            this.gridColumn56.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn56.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn56.OptionsFilter.AllowFilter = false;
            this.gridColumn56.TagLanguage = null;
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 6;
            this.gridColumn56.Width = 38;
            // 
            // gridColumn57
            // 
            this.gridColumn57.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn57.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn57.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn57.Caption = "Xe nhận";
            this.gridColumn57.FieldName = "XeNhan";
            this.gridColumn57.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn57.Name = "gridColumn57";
            this.gridColumn57.OptionsColumn.AllowEdit = false;
            this.gridColumn57.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn57.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn57.OptionsFilter.AllowFilter = false;
            this.gridColumn57.TagLanguage = null;
            this.gridColumn57.Visible = true;
            this.gridColumn57.VisibleIndex = 7;
            this.gridColumn57.Width = 61;
            // 
            // gridColumn58
            // 
            this.gridColumn58.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn58.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn58.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn58.Caption = "Xe MK";
            this.gridColumn58.FieldName = "BTBG_NoiDungXuLy";
            this.gridColumn58.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.OptionsColumn.AllowEdit = false;
            this.gridColumn58.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn58.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn58.OptionsFilter.AllowFilter = false;
            this.gridColumn58.TagLanguage = null;
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 8;
            this.gridColumn58.Width = 67;
            // 
            // gridColumn59
            // 
            this.gridColumn59.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn59.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn59.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn59.Caption = "Xe dừng điểm";
            this.gridColumn59.FieldName = "XeDungDiem";
            this.gridColumn59.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn59.Name = "gridColumn59";
            this.gridColumn59.OptionsColumn.AllowEdit = false;
            this.gridColumn59.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn59.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn59.OptionsFilter.AllowFilter = false;
            this.gridColumn59.TagLanguage = null;
            this.gridColumn59.Visible = true;
            this.gridColumn59.VisibleIndex = 9;
            this.gridColumn59.Width = 78;
            // 
            // gridColumn60
            // 
            this.gridColumn60.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn60.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn60.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn60.Caption = "Xe đến điểm";
            this.gridColumn60.FieldName = "XeDenDiem";
            this.gridColumn60.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn60.Name = "gridColumn60";
            this.gridColumn60.OptionsColumn.AllowEdit = false;
            this.gridColumn60.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn60.OptionsFilter.AllowFilter = false;
            this.gridColumn60.TagLanguage = null;
            this.gridColumn60.Visible = true;
            this.gridColumn60.VisibleIndex = 10;
            this.gridColumn60.Width = 65;
            // 
            // gridColumn61
            // 
            this.gridColumn61.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn61.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn61.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn61.Caption = "Xe đón";
            this.gridColumn61.FieldName = "XeDon";
            this.gridColumn61.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn61.Name = "gridColumn61";
            this.gridColumn61.OptionsColumn.AllowEdit = false;
            this.gridColumn61.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn61.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn61.OptionsFilter.AllowFilter = false;
            this.gridColumn61.TagLanguage = null;
            this.gridColumn61.Visible = true;
            this.gridColumn61.VisibleIndex = 11;
            this.gridColumn61.Width = 66;
            // 
            // gridColumn62
            // 
            this.gridColumn62.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn62.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn62.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn62.Caption = "Lệnh ĐTV";
            this.gridColumn62.FieldName = "LenhDienThoai";
            this.gridColumn62.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.OptionsColumn.AllowEdit = false;
            this.gridColumn62.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn62.OptionsFilter.AllowFilter = false;
            this.gridColumn62.TagLanguage = null;
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 12;
            this.gridColumn62.Width = 102;
            // 
            // gridColumn63
            // 
            this.gridColumn63.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn63.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn63.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn63.Caption = "Lệnh lái xe";
            this.gridColumn63.FieldName = "LenhLaiXe";
            this.gridColumn63.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn63.Name = "gridColumn63";
            this.gridColumn63.OptionsColumn.AllowEdit = false;
            this.gridColumn63.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn63.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn63.OptionsFilter.AllowFilter = false;
            this.gridColumn63.TagLanguage = null;
            this.gridColumn63.Visible = true;
            this.gridColumn63.VisibleIndex = 13;
            this.gridColumn63.Width = 101;
            // 
            // gridColumn64
            // 
            this.gridColumn64.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn64.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn64.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn64.Caption = "Lệnh ĐHV";
            this.gridColumn64.FieldName = "LenhTongDai";
            this.gridColumn64.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn64.OptionsColumn.AllowEdit = false;
            this.gridColumn64.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn64.OptionsFilter.AllowFilter = false;
            this.gridColumn64.TagLanguage = null;
            this.gridColumn64.Visible = true;
            this.gridColumn64.VisibleIndex = 14;
            this.gridColumn64.Width = 101;
            // 
            // gridColumn65
            // 
            this.gridColumn65.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn65.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn65.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn65.Caption = "Lệnh MK";
            this.gridColumn65.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn65.OptionsColumn.AllowEdit = false;
            this.gridColumn65.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn65.OptionsFilter.AllowFilter = false;
            this.gridColumn65.TagLanguage = null;
            this.gridColumn65.Visible = true;
            this.gridColumn65.VisibleIndex = 15;
            this.gridColumn65.Width = 94;
            // 
            // gridColumn66
            // 
            this.gridColumn66.Caption = "Địa chỉ trả khách";
            this.gridColumn66.FieldName = "DiaChiTraKhach";
            this.gridColumn66.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn66.OptionsColumn.AllowEdit = false;
            this.gridColumn66.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn66.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn66.OptionsFilter.AllowFilter = false;
            this.gridColumn66.TagLanguage = null;
            this.gridColumn66.Visible = true;
            this.gridColumn66.VisibleIndex = 16;
            this.gridColumn66.Width = 130;
            // 
            // gridColumn67
            // 
            this.gridColumn67.Caption = "Ghi chú TĐV";
            this.gridColumn67.FieldName = "GhiChuTongDai";
            this.gridColumn67.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn67.OptionsColumn.AllowEdit = false;
            this.gridColumn67.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn67.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn67.OptionsFilter.AllowFilter = false;
            this.gridColumn67.TagLanguage = null;
            this.gridColumn67.Visible = true;
            this.gridColumn67.VisibleIndex = 17;
            this.gridColumn67.Width = 102;
            // 
            // gridColumn68
            // 
            this.gridColumn68.Caption = "Ghi chú ĐTV";
            this.gridColumn68.FieldName = "GhiChuDienThoai";
            this.gridColumn68.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn68.Name = "gridColumn68";
            this.gridColumn68.OptionsColumn.AllowEdit = false;
            this.gridColumn68.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn68.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn68.OptionsFilter.AllowFilter = false;
            this.gridColumn68.TagLanguage = null;
            this.gridColumn68.Visible = true;
            this.gridColumn68.VisibleIndex = 18;
            this.gridColumn68.Width = 106;
            // 
            // gridColumn69
            // 
            this.gridColumn69.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn69.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn69.Caption = "ĐTV";
            this.gridColumn69.FieldName = "MaNhanVienDienThoai";
            this.gridColumn69.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn69.Name = "gridColumn69";
            this.gridColumn69.OptionsColumn.AllowEdit = false;
            this.gridColumn69.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn69.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn69.OptionsFilter.AllowFilter = false;
            this.gridColumn69.TagLanguage = null;
            this.gridColumn69.Visible = true;
            this.gridColumn69.VisibleIndex = 19;
            this.gridColumn69.Width = 102;
            // 
            // gridColumn70
            // 
            this.gridColumn70.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn70.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn70.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn70.Caption = "ĐHV";
            this.gridColumn70.FieldName = "MaNhanVienTongDai";
            this.gridColumn70.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn70.Name = "gridColumn70";
            this.gridColumn70.OptionsColumn.AllowEdit = false;
            this.gridColumn70.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn70.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn70.OptionsFilter.AllowFilter = false;
            this.gridColumn70.TagLanguage = null;
            this.gridColumn70.Visible = true;
            this.gridColumn70.VisibleIndex = 20;
            this.gridColumn70.Width = 86;
            // 
            // gridColumn71
            // 
            this.gridColumn71.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn71.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn71.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn71.Caption = "Danh sách xe đề cử";
            this.gridColumn71.FieldName = "DanhSachXeDeCu";
            this.gridColumn71.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn71.Name = "gridColumn71";
            this.gridColumn71.OptionsColumn.AllowEdit = false;
            this.gridColumn71.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn71.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn71.OptionsFilter.AllowFilter = false;
            this.gridColumn71.TagLanguage = null;
            this.gridColumn71.Visible = true;
            this.gridColumn71.VisibleIndex = 21;
            this.gridColumn71.Width = 129;
            // 
            // gridColumn72
            // 
            this.gridColumn72.Caption = "Ghi chú MK";
            this.gridColumn72.FieldName = "MOIKHACH_KhieuNai_ThongTinThem";
            this.gridColumn72.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn72.Name = "gridColumn72";
            this.gridColumn72.OptionsColumn.AllowEdit = false;
            this.gridColumn72.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn72.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn72.OptionsFilter.AllowFilter = false;
            this.gridColumn72.TagLanguage = null;
            this.gridColumn72.Visible = true;
            this.gridColumn72.VisibleIndex = 22;
            this.gridColumn72.Width = 139;
            // 
            // PanelThongTinDiaChi
            // 
            this.PanelThongTinDiaChi.Controls.Add(this.btnAnHien);
            this.PanelThongTinDiaChi.Controls.Add(this.shLabel3);
            this.PanelThongTinDiaChi.Controls.Add(this.lblDienThoai);
            this.PanelThongTinDiaChi.Controls.Add(this.shLabel5);
            this.PanelThongTinDiaChi.Controls.Add(this.shLabel2);
            this.PanelThongTinDiaChi.Controls.Add(this.lblLenhDHV);
            this.PanelThongTinDiaChi.Controls.Add(this.lblDiaChiDon);
            this.PanelThongTinDiaChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelThongTinDiaChi.Location = new System.Drawing.Point(0, 0);
            this.PanelThongTinDiaChi.Name = "PanelThongTinDiaChi";
            this.PanelThongTinDiaChi.Size = new System.Drawing.Size(1405, 34);
            this.PanelThongTinDiaChi.TabIndex = 1;
            // 
            // btnAnHien
            // 
            this.btnAnHien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnHien.Image = global::TaxiApplication.Properties.Resources.forward;
            this.btnAnHien.Location = new System.Drawing.Point(1365, 4);
            this.btnAnHien.Name = "btnAnHien";
            this.btnAnHien.Size = new System.Drawing.Size(33, 23);
            this.btnAnHien.TabIndex = 2;
            this.btnAnHien.Click += new System.EventHandler(this.btnAnHien_Click);
            // 
            // shLabel3
            // 
            this.shLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.shLabel3.Appearance.Options.UseFont = true;
            this.shLabel3.Appearance.Options.UseForeColor = true;
            this.shLabel3.Location = new System.Drawing.Point(3, 3);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(103, 25);
            this.shLabel3.TabIndex = 1;
            this.shLabel3.Text = "Điện thoại:";
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDienThoai.Appearance.Options.UseFont = true;
            this.lblDienThoai.Location = new System.Drawing.Point(109, 4);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(0, 23);
            this.lblDienThoai.TabIndex = 0;
            // 
            // shLabel5
            // 
            this.shLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.shLabel5.Appearance.Options.UseFont = true;
            this.shLabel5.Appearance.Options.UseForeColor = true;
            this.shLabel5.Location = new System.Drawing.Point(942, 2);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(101, 25);
            this.shLabel5.TabIndex = 1;
            this.shLabel5.Text = "Lệnh ĐHV:";
            // 
            // shLabel2
            // 
            this.shLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.shLabel2.Appearance.Options.UseFont = true;
            this.shLabel2.Appearance.Options.UseForeColor = true;
            this.shLabel2.Location = new System.Drawing.Point(257, 3);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(114, 25);
            this.shLabel2.TabIndex = 1;
            this.shLabel2.Text = "Địa chỉ đón:";
            // 
            // lblLenhDHV
            // 
            this.lblLenhDHV.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLenhDHV.Appearance.Options.UseFont = true;
            this.lblLenhDHV.Location = new System.Drawing.Point(1048, 3);
            this.lblLenhDHV.Name = "lblLenhDHV";
            this.lblLenhDHV.Size = new System.Drawing.Size(0, 23);
            this.lblLenhDHV.TabIndex = 0;
            // 
            // lblDiaChiDon
            // 
            this.lblDiaChiDon.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChiDon.Appearance.Options.UseFont = true;
            this.lblDiaChiDon.Location = new System.Drawing.Point(376, 4);
            this.lblDiaChiDon.Name = "lblDiaChiDon";
            this.lblDiaChiDon.Size = new System.Drawing.Size(0, 23);
            this.lblDiaChiDon.TabIndex = 0;
            // 
            // tabPageDaGiaiQuyet
            // 
            this.tabPageDaGiaiQuyet.Controls.Add(this.grdDaGiaiQuyet);
            this.tabPageDaGiaiQuyet.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.tabPageDaGiaiQuyet.Name = "tabPageDaGiaiQuyet";
            this.tabPageDaGiaiQuyet.Size = new System.Drawing.Size(1405, 709);
            this.tabPageDaGiaiQuyet.TagLanguage = null;
            this.tabPageDaGiaiQuyet.Text = "Đã giải quyết (Alt+2)";
            // 
            // grdDaGiaiQuyet
            // 
            this.grdDaGiaiQuyet.ContextMenuStrip = this.mnuSoDong;
            this.grdDaGiaiQuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDaGiaiQuyet.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdDaGiaiQuyet.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdDaGiaiQuyet.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdDaGiaiQuyet.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdDaGiaiQuyet.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdDaGiaiQuyet.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdDaGiaiQuyet.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdDaGiaiQuyet.Location = new System.Drawing.Point(0, 0);
            this.grdDaGiaiQuyet.MainView = this.grvDaGiaiQuyet;
            this.grdDaGiaiQuyet.MenuManager = this.ribbonMainForm;
            this.grdDaGiaiQuyet.Name = "grdDaGiaiQuyet";
            this.grdDaGiaiQuyet.Size = new System.Drawing.Size(1405, 709);
            this.grdDaGiaiQuyet.TabIndex = 0;
            this.grdDaGiaiQuyet.UseEmbeddedNavigator = true;
            this.grdDaGiaiQuyet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDaGiaiQuyet});
            // 
            // mnuSoDong
            // 
            this.mnuSoDong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItem50,
            this.mnuItem100,
            this.mnuItem150,
            this.mnuItem200,
            this.lấyLạiCuốcKháchToolStripMenuItem});
            this.mnuSoDong.Name = "mnuSoDong";
            this.mnuSoDong.Size = new System.Drawing.Size(172, 114);
            // 
            // mnuItem50
            // 
            this.mnuItem50.Name = "mnuItem50";
            this.mnuItem50.Size = new System.Drawing.Size(171, 22);
            this.mnuItem50.Text = "50";
            this.mnuItem50.Click += new System.EventHandler(this.mnuItem50_Click);
            // 
            // mnuItem100
            // 
            this.mnuItem100.Name = "mnuItem100";
            this.mnuItem100.Size = new System.Drawing.Size(171, 22);
            this.mnuItem100.Text = "100";
            this.mnuItem100.Click += new System.EventHandler(this.mnuItem100_Click);
            // 
            // mnuItem150
            // 
            this.mnuItem150.Name = "mnuItem150";
            this.mnuItem150.Size = new System.Drawing.Size(171, 22);
            this.mnuItem150.Text = "150";
            this.mnuItem150.Click += new System.EventHandler(this.mnuItem150_Click);
            // 
            // mnuItem200
            // 
            this.mnuItem200.Name = "mnuItem200";
            this.mnuItem200.Size = new System.Drawing.Size(171, 22);
            this.mnuItem200.Text = "200";
            this.mnuItem200.Click += new System.EventHandler(this.mnuItem200_Click);
            // 
            // lấyLạiCuốcKháchToolStripMenuItem
            // 
            this.lấyLạiCuốcKháchToolStripMenuItem.Name = "lấyLạiCuốcKháchToolStripMenuItem";
            this.lấyLạiCuốcKháchToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.lấyLạiCuốcKháchToolStripMenuItem.Text = "Lấy lại cuốc khách";
            this.lấyLạiCuốcKháchToolStripMenuItem.Click += new System.EventHandler(this.mnuItemChuyenCuocGoi_Click);
            // 
            // grvDaGiaiQuyet
            // 
            this.grvDaGiaiQuyet.ActiveFilterEnabled = false;
            this.grvDaGiaiQuyet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvDaGiaiQuyet.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDaGiaiQuyet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDaGiaiQuyet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDaGiaiQuyet.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grvDaGiaiQuyet.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvDaGiaiQuyet.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvDaGiaiQuyet.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8F);
            this.grvDaGiaiQuyet.ColumnPanelRowHeight = 35;
            this.grvDaGiaiQuyet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24});
            this.grvDaGiaiQuyet.GridControl = this.grdDaGiaiQuyet;
            this.grvDaGiaiQuyet.IndicatorWidth = 35;
            this.grvDaGiaiQuyet.Name = "grvDaGiaiQuyet";
            this.grvDaGiaiQuyet.OptionsBehavior.Editable = false;
            this.grvDaGiaiQuyet.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grvDaGiaiQuyet.OptionsFilter.AllowFilterEditor = false;
            this.grvDaGiaiQuyet.OptionsFind.AllowFindPanel = false;
            this.grvDaGiaiQuyet.OptionsView.ColumnAutoWidth = false;
            this.grvDaGiaiQuyet.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Máy";
            this.gridColumn2.FieldName = "Line";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 43;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Thời điểm gọi";
            this.gridColumn3.DisplayFormat.FormatString = "HH:ss:mm dd/MM/yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "ThoiDiemGoi";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 133;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Điện thoại";
            this.gridColumn4.FieldName = "PhoneNumber";
            this.gridColumn4.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.TagLanguage = null;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 107;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Loại xe";
            this.gridColumn5.FieldName = "LoaiXe";
            this.gridColumn5.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.TagLanguage = null;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 66;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Địa chỉ";
            this.gridColumn6.FieldName = "DiaChiDonKhach";
            this.gridColumn6.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.TagLanguage = null;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 250;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "Vùng";
            this.gridColumn7.FieldName = "Vung";
            this.gridColumn7.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.TagLanguage = null;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 37;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "SL xe";
            this.gridColumn8.FieldName = "SoLuong";
            this.gridColumn8.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn8.OptionsFilter.AllowFilter = false;
            this.gridColumn8.TagLanguage = null;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 38;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "Xe nhận";
            this.gridColumn9.FieldName = "XeNhan";
            this.gridColumn9.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn9.OptionsFilter.AllowFilter = false;
            this.gridColumn9.TagLanguage = null;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 113;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.Caption = "Xe MK";
            this.gridColumn10.FieldName = "BTBG_NoiDungXuLy";
            this.gridColumn10.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn10.OptionsFilter.AllowFilter = false;
            this.gridColumn10.TagLanguage = null;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 127;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.Caption = "Xe dừng điểm";
            this.gridColumn11.FieldName = "XeDungDiem";
            this.gridColumn11.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn11.OptionsFilter.AllowFilter = false;
            this.gridColumn11.TagLanguage = null;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 131;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.Caption = "Xe đến điểm";
            this.gridColumn12.FieldName = "XeDenDiem";
            this.gridColumn12.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn12.OptionsFilter.AllowFilter = false;
            this.gridColumn12.TagLanguage = null;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 128;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.Caption = "Xe đón";
            this.gridColumn13.FieldName = "XeDon";
            this.gridColumn13.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn13.OptionsFilter.AllowFilter = false;
            this.gridColumn13.TagLanguage = null;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 132;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn14.Caption = "Lệnh ĐTV";
            this.gridColumn14.FieldName = "LenhDienThoai";
            this.gridColumn14.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn14.OptionsFilter.AllowFilter = false;
            this.gridColumn14.TagLanguage = null;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            this.gridColumn14.Width = 122;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn15.Caption = "Lệnh lái xe";
            this.gridColumn15.FieldName = "LenhLaiXe";
            this.gridColumn15.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn15.OptionsFilter.AllowFilter = false;
            this.gridColumn15.TagLanguage = null;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            this.gridColumn15.Width = 118;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn16.Caption = "Lệnh ĐHV";
            this.gridColumn16.FieldName = "LenhTongDai";
            this.gridColumn16.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn16.OptionsFilter.AllowFilter = false;
            this.gridColumn16.TagLanguage = null;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            this.gridColumn16.Width = 123;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn17.Caption = "Lệnh MK";
            this.gridColumn17.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn17.OptionsFilter.AllowFilter = false;
            this.gridColumn17.TagLanguage = null;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            this.gridColumn17.Width = 121;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Địa chỉ trả khách";
            this.gridColumn18.FieldName = "DiaChiTraKhach";
            this.gridColumn18.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn18.OptionsFilter.AllowFilter = false;
            this.gridColumn18.TagLanguage = null;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 16;
            this.gridColumn18.Width = 149;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Ghi chú TĐV";
            this.gridColumn19.FieldName = "GhiChuTongDai";
            this.gridColumn19.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn19.OptionsFilter.AllowFilter = false;
            this.gridColumn19.TagLanguage = null;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 17;
            this.gridColumn19.Width = 108;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Ghi chú ĐTV";
            this.gridColumn20.FieldName = "GhiChuDienThoai";
            this.gridColumn20.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn20.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn20.OptionsFilter.AllowFilter = false;
            this.gridColumn20.TagLanguage = null;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 18;
            this.gridColumn20.Width = 113;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn21.Caption = "ĐTV";
            this.gridColumn21.FieldName = "MaNhanVienDienThoai";
            this.gridColumn21.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn21.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn21.OptionsFilter.AllowFilter = false;
            this.gridColumn21.TagLanguage = null;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 19;
            this.gridColumn21.Width = 112;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn22.Caption = "ĐHV";
            this.gridColumn22.FieldName = "MaNhanVienTongDai";
            this.gridColumn22.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn22.OptionsFilter.AllowFilter = false;
            this.gridColumn22.TagLanguage = null;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 20;
            this.gridColumn22.Width = 102;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn23.Caption = "Danh sách xe đề cử";
            this.gridColumn23.FieldName = "DanhSachXeDeCu";
            this.gridColumn23.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn23.OptionsFilter.AllowFilter = false;
            this.gridColumn23.TagLanguage = null;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 21;
            this.gridColumn23.Width = 129;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Ghi chú MK";
            this.gridColumn24.FieldName = "MOIKHACH_KhieuNai_ThongTinThem";
            this.gridColumn24.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn24.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn24.OptionsFilter.AllowFilter = false;
            this.gridColumn24.TagLanguage = null;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 22;
            this.gridColumn24.Width = 139;
            // 
            // tabPageTimKiemCuocGoi
            // 
            this.tabPageTimKiemCuocGoi.Controls.Add(this.grdTimKiemCuocGoi);
            this.tabPageTimKiemCuocGoi.Controls.Add(this.panel1);
            this.tabPageTimKiemCuocGoi.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.tabPageTimKiemCuocGoi.Name = "tabPageTimKiemCuocGoi";
            this.tabPageTimKiemCuocGoi.Size = new System.Drawing.Size(1405, 709);
            this.tabPageTimKiemCuocGoi.TagLanguage = null;
            this.tabPageTimKiemCuocGoi.Text = "Tìm kiếm cuốc gọi (Alt+3)";
            // 
            // grdTimKiemCuocGoi
            // 
            this.grdTimKiemCuocGoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTimKiemCuocGoi.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdTimKiemCuocGoi.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdTimKiemCuocGoi.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdTimKiemCuocGoi.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdTimKiemCuocGoi.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdTimKiemCuocGoi.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdTimKiemCuocGoi.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdTimKiemCuocGoi.Location = new System.Drawing.Point(0, 43);
            this.grdTimKiemCuocGoi.MainView = this.grvTimKiemCuocGoi;
            this.grdTimKiemCuocGoi.MenuManager = this.ribbonMainForm;
            this.grdTimKiemCuocGoi.Name = "grdTimKiemCuocGoi";
            this.grdTimKiemCuocGoi.Size = new System.Drawing.Size(1405, 666);
            this.grdTimKiemCuocGoi.TabIndex = 1;
            this.grdTimKiemCuocGoi.UseEmbeddedNavigator = true;
            this.grdTimKiemCuocGoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTimKiemCuocGoi});
            // 
            // grvTimKiemCuocGoi
            // 
            this.grvTimKiemCuocGoi.ActiveFilterEnabled = false;
            this.grvTimKiemCuocGoi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvTimKiemCuocGoi.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTimKiemCuocGoi.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvTimKiemCuocGoi.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvTimKiemCuocGoi.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grvTimKiemCuocGoi.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvTimKiemCuocGoi.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvTimKiemCuocGoi.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8F);
            this.grvTimKiemCuocGoi.ColumnPanelRowHeight = 35;
            this.grvTimKiemCuocGoi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42,
            this.gridColumn43,
            this.gridColumn44,
            this.gridColumn45,
            this.gridColumn46,
            this.gridColumn47,
            this.gridColumn48});
            this.grvTimKiemCuocGoi.GridControl = this.grdTimKiemCuocGoi;
            this.grvTimKiemCuocGoi.IndicatorWidth = 35;
            this.grvTimKiemCuocGoi.Name = "grvTimKiemCuocGoi";
            this.grvTimKiemCuocGoi.OptionsBehavior.Editable = false;
            this.grvTimKiemCuocGoi.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grvTimKiemCuocGoi.OptionsFilter.AllowFilterEditor = false;
            this.grvTimKiemCuocGoi.OptionsFind.AllowFindPanel = false;
            this.grvTimKiemCuocGoi.OptionsView.ColumnAutoWidth = false;
            this.grvTimKiemCuocGoi.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn26.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn26.Caption = "Máy";
            this.gridColumn26.FieldName = "Line";
            this.gridColumn26.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn26.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn26.OptionsFilter.AllowFilter = false;
            this.gridColumn26.TagLanguage = null;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 0;
            this.gridColumn26.Width = 43;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn27.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn27.Caption = "Thời điểm gọi";
            this.gridColumn27.DisplayFormat.FormatString = "HH:ss:mm dd/MM/yyyy";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn27.FieldName = "ThoiDiemGoi";
            this.gridColumn27.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn27.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn27.OptionsFilter.AllowFilter = false;
            this.gridColumn27.TagLanguage = null;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 1;
            this.gridColumn27.Width = 133;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn28.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn28.Caption = "Điện thoại";
            this.gridColumn28.FieldName = "PhoneNumber";
            this.gridColumn28.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn28.OptionsFilter.AllowFilter = false;
            this.gridColumn28.TagLanguage = null;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 2;
            this.gridColumn28.Width = 107;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Loại xe";
            this.gridColumn29.FieldName = "LoaiXe";
            this.gridColumn29.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn29.OptionsFilter.AllowFilter = false;
            this.gridColumn29.TagLanguage = null;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 3;
            this.gridColumn29.Width = 66;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Địa chỉ";
            this.gridColumn30.FieldName = "DiaChiDonKhach";
            this.gridColumn30.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn30.OptionsFilter.AllowFilter = false;
            this.gridColumn30.TagLanguage = null;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 4;
            this.gridColumn30.Width = 250;
            // 
            // gridColumn31
            // 
            this.gridColumn31.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn31.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn31.Caption = "Vùng";
            this.gridColumn31.FieldName = "Vung";
            this.gridColumn31.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn31.OptionsFilter.AllowFilter = false;
            this.gridColumn31.TagLanguage = null;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 5;
            this.gridColumn31.Width = 37;
            // 
            // gridColumn32
            // 
            this.gridColumn32.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn32.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn32.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn32.Caption = "SL xe";
            this.gridColumn32.FieldName = "SoLuong";
            this.gridColumn32.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn32.OptionsFilter.AllowFilter = false;
            this.gridColumn32.TagLanguage = null;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 6;
            this.gridColumn32.Width = 38;
            // 
            // gridColumn33
            // 
            this.gridColumn33.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn33.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn33.Caption = "Xe nhận";
            this.gridColumn33.FieldName = "XeNhan";
            this.gridColumn33.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn33.OptionsFilter.AllowFilter = false;
            this.gridColumn33.TagLanguage = null;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 7;
            this.gridColumn33.Width = 113;
            // 
            // gridColumn34
            // 
            this.gridColumn34.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn34.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn34.Caption = "Xe MK";
            this.gridColumn34.FieldName = "BTBG_NoiDungXuLy";
            this.gridColumn34.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn34.OptionsFilter.AllowFilter = false;
            this.gridColumn34.TagLanguage = null;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 8;
            this.gridColumn34.Width = 127;
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn35.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn35.Caption = "Xe dừng điểm";
            this.gridColumn35.FieldName = "XeDungDiem";
            this.gridColumn35.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn35.OptionsFilter.AllowFilter = false;
            this.gridColumn35.TagLanguage = null;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 9;
            this.gridColumn35.Width = 131;
            // 
            // gridColumn36
            // 
            this.gridColumn36.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn36.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn36.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn36.Caption = "Xe đến điểm";
            this.gridColumn36.FieldName = "XeDenDiem";
            this.gridColumn36.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn36.OptionsFilter.AllowFilter = false;
            this.gridColumn36.TagLanguage = null;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 10;
            this.gridColumn36.Width = 128;
            // 
            // gridColumn37
            // 
            this.gridColumn37.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn37.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn37.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn37.Caption = "Xe đón";
            this.gridColumn37.FieldName = "XeDon";
            this.gridColumn37.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn37.OptionsFilter.AllowFilter = false;
            this.gridColumn37.TagLanguage = null;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 11;
            this.gridColumn37.Width = 132;
            // 
            // gridColumn38
            // 
            this.gridColumn38.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn38.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn38.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn38.Caption = "Lệnh ĐTV";
            this.gridColumn38.FieldName = "LenhDienThoai";
            this.gridColumn38.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn38.OptionsFilter.AllowFilter = false;
            this.gridColumn38.TagLanguage = null;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 12;
            this.gridColumn38.Width = 122;
            // 
            // gridColumn39
            // 
            this.gridColumn39.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn39.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn39.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn39.Caption = "Lệnh lái xe";
            this.gridColumn39.FieldName = "LenhLaiXe";
            this.gridColumn39.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn39.OptionsFilter.AllowFilter = false;
            this.gridColumn39.TagLanguage = null;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 13;
            this.gridColumn39.Width = 118;
            // 
            // gridColumn40
            // 
            this.gridColumn40.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn40.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn40.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn40.Caption = "Lệnh ĐHV";
            this.gridColumn40.FieldName = "LenhTongDai";
            this.gridColumn40.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn40.OptionsFilter.AllowFilter = false;
            this.gridColumn40.TagLanguage = null;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 14;
            this.gridColumn40.Width = 123;
            // 
            // gridColumn41
            // 
            this.gridColumn41.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn41.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn41.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn41.Caption = "Lệnh MK";
            this.gridColumn41.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.AllowEdit = false;
            this.gridColumn41.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn41.OptionsFilter.AllowFilter = false;
            this.gridColumn41.TagLanguage = null;
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 15;
            this.gridColumn41.Width = 121;
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "Địa chỉ trả khách";
            this.gridColumn42.FieldName = "DiaChiTraKhach";
            this.gridColumn42.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.AllowEdit = false;
            this.gridColumn42.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn42.OptionsFilter.AllowFilter = false;
            this.gridColumn42.TagLanguage = null;
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 16;
            this.gridColumn42.Width = 149;
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "Ghi chú TĐV";
            this.gridColumn43.FieldName = "GhiChuTongDai";
            this.gridColumn43.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.OptionsColumn.AllowEdit = false;
            this.gridColumn43.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn43.OptionsFilter.AllowFilter = false;
            this.gridColumn43.TagLanguage = null;
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 17;
            this.gridColumn43.Width = 108;
            // 
            // gridColumn44
            // 
            this.gridColumn44.Caption = "Ghi chú ĐTV";
            this.gridColumn44.FieldName = "GhiChuDienThoai";
            this.gridColumn44.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.OptionsColumn.AllowEdit = false;
            this.gridColumn44.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn44.OptionsFilter.AllowFilter = false;
            this.gridColumn44.TagLanguage = null;
            this.gridColumn44.Visible = true;
            this.gridColumn44.VisibleIndex = 18;
            this.gridColumn44.Width = 113;
            // 
            // gridColumn45
            // 
            this.gridColumn45.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn45.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn45.Caption = "ĐTV";
            this.gridColumn45.FieldName = "MaNhanVienDienThoai";
            this.gridColumn45.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn45.OptionsColumn.AllowEdit = false;
            this.gridColumn45.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn45.OptionsFilter.AllowFilter = false;
            this.gridColumn45.TagLanguage = null;
            this.gridColumn45.Visible = true;
            this.gridColumn45.VisibleIndex = 19;
            this.gridColumn45.Width = 112;
            // 
            // gridColumn46
            // 
            this.gridColumn46.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn46.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn46.Caption = "ĐHV";
            this.gridColumn46.FieldName = "MaNhanVienTongDai";
            this.gridColumn46.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.OptionsColumn.AllowEdit = false;
            this.gridColumn46.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn46.OptionsFilter.AllowFilter = false;
            this.gridColumn46.TagLanguage = null;
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 20;
            this.gridColumn46.Width = 102;
            // 
            // gridColumn47
            // 
            this.gridColumn47.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn47.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn47.Caption = "Danh sách xe đề cử";
            this.gridColumn47.FieldName = "DanhSachXeDeCu";
            this.gridColumn47.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.OptionsColumn.AllowEdit = false;
            this.gridColumn47.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn47.OptionsFilter.AllowFilter = false;
            this.gridColumn47.TagLanguage = null;
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 21;
            this.gridColumn47.Width = 129;
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "Ghi chú MK";
            this.gridColumn48.FieldName = "MOIKHACH_KhieuNai_ThongTinThem";
            this.gridColumn48.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn48.Name = "gridColumn48";
            this.gridColumn48.OptionsColumn.AllowEdit = false;
            this.gridColumn48.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn48.OptionsFilter.AllowFilter = false;
            this.gridColumn48.TagLanguage = null;
            this.gridColumn48.Visible = true;
            this.gridColumn48.VisibleIndex = 22;
            this.gridColumn48.Width = 139;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CbkSearchKenh4);
            this.panel1.Controls.Add(this.CbkSearchKenh3);
            this.panel1.Controls.Add(this.CbkSearchKenh2);
            this.panel1.Controls.Add(this.CbkSearchKenh1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearchAddress);
            this.panel1.Controls.Add(this.txtXeNhan);
            this.panel1.Controls.Add(this.txtSearchPhone);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1405, 43);
            this.panel1.TabIndex = 0;
            // 
            // CbkSearchKenh4
            // 
            this.CbkSearchKenh4.IsChangeText = false;
            this.CbkSearchKenh4.IsFocus = false;
            this.CbkSearchKenh4.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.CbkSearchKenh4.Location = new System.Drawing.Point(825, 11);
            this.CbkSearchKenh4.Name = "CbkSearchKenh4";
            this.CbkSearchKenh4.Properties.Caption = "Kênh [4]";
            this.CbkSearchKenh4.Size = new System.Drawing.Size(62, 19);
            this.CbkSearchKenh4.TabIndex = 5;
            this.CbkSearchKenh4.CheckedChanged += new System.EventHandler(this.CbkSearchKenh1_CheckedChanged);
            // 
            // CbkSearchKenh3
            // 
            this.CbkSearchKenh3.IsChangeText = false;
            this.CbkSearchKenh3.IsFocus = false;
            this.CbkSearchKenh3.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.CbkSearchKenh3.Location = new System.Drawing.Point(756, 11);
            this.CbkSearchKenh3.Name = "CbkSearchKenh3";
            this.CbkSearchKenh3.Properties.Caption = "Kênh [3]";
            this.CbkSearchKenh3.Size = new System.Drawing.Size(63, 19);
            this.CbkSearchKenh3.TabIndex = 4;
            this.CbkSearchKenh3.CheckedChanged += new System.EventHandler(this.CbkSearchKenh1_CheckedChanged);
            // 
            // CbkSearchKenh2
            // 
            this.CbkSearchKenh2.IsChangeText = false;
            this.CbkSearchKenh2.IsFocus = false;
            this.CbkSearchKenh2.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.CbkSearchKenh2.Location = new System.Drawing.Point(687, 11);
            this.CbkSearchKenh2.Name = "CbkSearchKenh2";
            this.CbkSearchKenh2.Properties.Caption = "Kênh [2]";
            this.CbkSearchKenh2.Size = new System.Drawing.Size(63, 19);
            this.CbkSearchKenh2.TabIndex = 3;
            this.CbkSearchKenh2.CheckedChanged += new System.EventHandler(this.CbkSearchKenh1_CheckedChanged);
            // 
            // CbkSearchKenh1
            // 
            this.CbkSearchKenh1.IsChangeText = false;
            this.CbkSearchKenh1.IsFocus = false;
            this.CbkSearchKenh1.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.CbkSearchKenh1.Location = new System.Drawing.Point(615, 11);
            this.CbkSearchKenh1.MenuManager = this.ribbonMainForm;
            this.CbkSearchKenh1.Name = "CbkSearchKenh1";
            this.CbkSearchKenh1.Properties.Caption = "Kênh [1]";
            this.CbkSearchKenh1.Size = new System.Drawing.Size(66, 19);
            this.CbkSearchKenh1.TabIndex = 2;
            this.CbkSearchKenh1.CheckedChanged += new System.EventHandler(this.CbkSearchKenh1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "[Đ]ịa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Xe nhận";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Đ[T]";
            // 
            // txtSearchAddress
            // 
            this.txtSearchAddress.IsChangeText = false;
            this.txtSearchAddress.IsFocus = false;
            this.txtSearchAddress.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.txtSearchAddress.Location = new System.Drawing.Point(246, 10);
            this.txtSearchAddress.Name = "txtSearchAddress";
            this.txtSearchAddress.Properties.MaxLength = 255;
            this.txtSearchAddress.Size = new System.Drawing.Size(196, 20);
            this.txtSearchAddress.TabIndex = 1;
            this.txtSearchAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchAddress_KeyDown);
            // 
            // txtXeNhan
            // 
            this.txtXeNhan.IsChangeText = false;
            this.txtXeNhan.IsFocus = false;
            this.txtXeNhan.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.txtXeNhan.Location = new System.Drawing.Point(500, 10);
            this.txtXeNhan.Name = "txtXeNhan";
            this.txtXeNhan.Properties.Mask.EditMask = "\\d+";
            this.txtXeNhan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtXeNhan.Properties.MaxLength = 15;
            this.txtXeNhan.Size = new System.Drawing.Size(96, 20);
            this.txtXeNhan.TabIndex = 0;
            this.txtXeNhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchPhone_KeyDown);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.IsChangeText = false;
            this.txtSearchPhone.IsFocus = false;
            this.txtSearchPhone.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.txtSearchPhone.Location = new System.Drawing.Point(55, 10);
            this.txtSearchPhone.MenuManager = this.ribbonMainForm;
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Properties.Mask.EditMask = "\\d+";
            this.txtSearchPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSearchPhone.Properties.MaxLength = 15;
            this.txtSearchPhone.Size = new System.Drawing.Size(131, 20);
            this.txtSearchPhone.TabIndex = 0;
            this.txtSearchPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchPhone_KeyDown);
            // 
            // tabPageCuocOnline
            // 
            this.tabPageCuocOnline.Controls.Add(this.uc_CuocAppKH1);
            this.tabPageCuocOnline.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.tabPageCuocOnline.Name = "tabPageCuocOnline";
            this.tabPageCuocOnline.Size = new System.Drawing.Size(1405, 709);
            this.tabPageCuocOnline.TagLanguage = null;
            this.tabPageCuocOnline.Text = "Cuốc Online (Alt+4)";
            // 
            // uc_CuocAppKH1
            // 
            this.uc_CuocAppKH1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_CuocAppKH1.Location = new System.Drawing.Point(0, 0);
            this.uc_CuocAppKH1.Name = "uc_CuocAppKH1";
            this.uc_CuocAppKH1.Size = new System.Drawing.Size(1405, 709);
            this.uc_CuocAppKH1.TabIndex = 1;
            this.uc_CuocAppKH1.Load += new System.EventHandler(this.uc_CuocAppKH1_Load);
            // 
            // panelTopHelp
            // 
            this.panelTopHelp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panelTopHelp.BackColor = System.Drawing.Color.LightYellow;
            this.panelTopHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopHelp.ForeColor = System.Drawing.Color.DarkRed;
            this.panelTopHelp.Location = new System.Drawing.Point(1065, 52);
            this.panelTopHelp.Name = "panelTopHelp";
            this.panelTopHelp.Size = new System.Drawing.Size(343, 89);
            this.panelTopHelp.TabIndex = 8;
            this.panelTopHelp.Visible = false;
            // 
            // FormMainRibbon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 911);
            this.Controls.Add(this.panelTopHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.ribbonMainForm);
            this.Name = "FormMainRibbon";
            this.Ribbon = this.ribbonMainForm;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.statusBar1;
            this.Text = "FormMainRibbon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMainRibbon_Load);
            this.Resize += new System.EventHandler(this.FormMainRibbon_Resize);
            this.Controls.SetChildIndex(this.ribbonMainForm, 0);
            this.Controls.SetChildIndex(this.statusBar1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.panelTopHelp, 0);
            this.Controls.SetChildIndex(this.ribbon, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMainForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageChoGiaiQuyet.ResumeLayout(false);
            this.slChoGiaiQuyet.Panel1.ResumeLayout(false);
            this.slChoGiaiQuyet.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slChoGiaiQuyet)).EndInit();
            this.slChoGiaiQuyet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChoGiaiQuyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChoGiaiQuyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbICon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuocKhachLineKhac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCuocKhachLineKhac)).EndInit();
            this.PanelThongTinDiaChi.ResumeLayout(false);
            this.PanelThongTinDiaChi.PerformLayout();
            this.tabPageDaGiaiQuyet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDaGiaiQuyet)).EndInit();
            this.mnuSoDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDaGiaiQuyet)).EndInit();
            this.tabPageTimKiemCuocGoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTimKiemCuocGoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTimKiemCuocGoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbkSearchKenh1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXeNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchPhone.Properties)).EndInit();
            this.tabPageCuocOnline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Controls.Ribbons.RibbonControl ribbonMainForm;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgDienThoai;
        private Taxi.Controls.Base.Controls.TabControl tabControl1;
        private Taxi.Controls.Base.Controls.TabPage tabPageChoGiaiQuyet;
        private Taxi.Controls.Base.Controls.TabPage tabPageDaGiaiQuyet;
        private Taxi.Controls.Base.Controls.Grids.GridControl grdChoGiaiQuyet;
        private Taxi.Controls.Base.Controls.Grids.Extends.DienThoaiGridView grvChoGiaiQuyet;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colICon;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colLine;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colThoiDiemGoi;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDienThoai;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colLoaiXe;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDiaChi;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colVung;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colSLXe;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colXeNhan;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colXeMK;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colXeDungDiem;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colXeDenDiem;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colXeDon;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colLenhDTV;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colLenhLaiXe;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colLenhDHV;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colLenhMK;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDiaChiTraKhach;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colGhiChuTDV;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colGhiChuDTV;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDTV;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDHV;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colDanhSachXeDeCu;
        private Taxi.Controls.Base.Controls.Grids.GridColumn colGhiChuMK;
        private Taxi.Controls.Base.Controls.Grids.GridControl grdDaGiaiQuyet;
        private Taxi.Controls.Base.Controls.Grids.GridView grvDaGiaiQuyet;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn2;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn3;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn4;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn5;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn6;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn7;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn8;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn9;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn10;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn11;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn12;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn13;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn14;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn15;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn16;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn17;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn18;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn19;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn20;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn21;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn22;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn23;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn24;
        private Taxi.Controls.Base.Controls.TabPage tabPageTimKiemCuocGoi;
        private Taxi.Controls.Base.Controls.Grids.GridControl grdTimKiemCuocGoi;
        private Taxi.Controls.Base.Controls.Grids.GridView grvTimKiemCuocGoi;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn26;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn27;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn28;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn29;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn30;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn31;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn32;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn33;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn34;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn35;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn36;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn37;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn38;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn39;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn40;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn41;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn42;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn43;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn44;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn45;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn46;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn47;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn48;
        private System.Windows.Forms.Panel panel1;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnChenCuocGoiGoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.Windows.Forms.SplitContainer slChoGiaiQuyet;
        private Taxi.Controls.Base.Controls.Grids.GridControl grdCuocKhachLineKhac;
        private Taxi.Controls.Base.Controls.Grids.Extends.DienThoaiGridView grvCuocKhachLineKhac;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn49;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn50;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn51;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn52;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn53;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn54;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn55;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn56;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn57;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn58;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn59;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn60;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn61;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn62;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn63;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn64;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn65;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn66;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn67;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn68;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn69;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn70;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn71;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn72;
        private Taxi.Controls.Base.Controls.Ribbons.StatusBar statusBar1;
        private System.Windows.Forms.ImageList imageListICon;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbICon;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnKhachDat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgKhachHang;
        private Taxi.Controls.Base.Controls.TabPage tabPageCuocOnline;
        private Taxi.Controls.FastTaxis.CuocAppKH.uc_CuocAppKH uc_CuocAppKH1;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageCongCu;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnTinhTien;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem btnCheckApp;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private System.Windows.Forms.Panel PanelThongTinDiaChi;
        private Taxi.Controls.Base.Controls.ShLabel lblDiaChiDon;
        private Taxi.Controls.Base.Controls.ShLabel shLabel2;
        private Taxi.Controls.Base.Controls.ShButton btnAnHien;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem barButtonItem2;
        private Taxi.Controls.Base.Controls.ShLabel shLabel3;
        private Taxi.Controls.Base.Controls.ShLabel lblDienThoai;
        private Taxi.Controls.Base.Controls.ShLabel shLabel5;
        private Taxi.Controls.Base.Controls.ShLabel lblLenhDHV;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnQuanLyTapLenh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup re;
        private System.Windows.Forms.Panel panelTopHelp;
        private System.Windows.Forms.ContextMenuStrip mnuSoDong;
        private System.Windows.Forms.ToolStripMenuItem mnuItem50;
        private System.Windows.Forms.ToolStripMenuItem mnuItem150;
        private System.Windows.Forms.ToolStripMenuItem mnuItem200;
        private System.Windows.Forms.ToolStripMenuItem mnuItem100;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgHienThiLuoi;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem btnLuuHienThiLuoi;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem btnHienThiMacDinh;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnTangKichThuocLuoi;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnGiamKichThuocLuoi;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem bbtnDangXuat;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Inputs.InputText txtSearchPhone;
        private System.Windows.Forms.Label label2;
        private Taxi.Controls.Base.Inputs.InputText txtSearchAddress;
        private Taxi.Controls.Base.Inputs.InputCheckbox CbkSearchKenh1;
        private Taxi.Controls.Base.Inputs.InputCheckbox CbkSearchKenh4;
        private Taxi.Controls.Base.Inputs.InputCheckbox CbkSearchKenh3;
        private Taxi.Controls.Base.Inputs.InputCheckbox CbkSearchKenh2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgDanhMuc;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnDanhMucKhachDat;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnDanhSachCongTy;
        private System.Windows.Forms.ToolStripMenuItem lấyLạiCuốcKháchToolStripMenuItem;
        private Taxi.Controls.Base.Controls.Ribbons.Items.BarButtonItem bbtnQuanLyTamLenhModule;
        private System.Windows.Forms.Label label3;
        private Taxi.Controls.Base.Inputs.InputText txtXeNhan;


    }
}