using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Taxi.Business;
using Taxi.Controls.Base.Inputs;
using Taxi.Controls.GMapResources;
using Taxi.Utils;

namespace Taxi.Controls.FastTaxis.TaxiTrip
{
    partial class frmUpdateTrip_Map
    {
        public frmUpdateTrip_Map()
        {
            InitializeComponent();
            ConfigMap();
        }
        #region ==========================MAPS=================================
        private Taxi.Utils.MapModeEnum _mapMode;
        GMapMarker currentMarker;
        GMapOverlay top;
        GMapOverlay OverlayXeDeCu;
        GMapOverlay OverlayXeNhan;

        bool isMouseDown;

        private void ConfigMap()
        {
            //// config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            //MainMap.CacheLocation = System.Configuration.ConfigurationManager.AppSettings["MapPath"]; //Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 23;
            MainMap.MinZoom = 1;
            MainMap.Zoom = 15;
            MainMap.Dock = DockStyle.Fill;

            //MainMap.PolygonsEnabled = false;            
            // map events

            // add custom layers  
            {
                top = new GMapOverlay("top");
                MainMap.Overlays.Add(top);

                OverlayXeDeCu = new GMapOverlay("OverlayXeDeCu");
                MainMap.Overlays.Add(OverlayXeDeCu);

                OverlayXeNhan = new GMapOverlay("OverlayXeNhan");
                MainMap.Overlays.Add(OverlayXeNhan);
            }

            //  pnlBanDo.Controls.Add(MainMap);
            MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            MainMap.MouseMove += MainMap_MouseMove;
            MainMap.MouseDown += MainMap_MouseDown;
            MainMap.MouseUp += MainMap_MouseUp;
           //if (_mapMode == Taxi.Utils.MapModeEnum.EditPoint)
            //{
            //    MainMap.MouseMove += MainMap_MouseMove;
            //    MainMap.MouseDown += MainMap_MouseDown;
            //    MainMap.MouseUp += MainMap_MouseUp;
            //}
            //else
            //{
            //    MainMap.MouseMove -= MainMap_MouseMove;
            //    MainMap.MouseDown -= MainMap_MouseDown;
            //    MainMap.MouseUp -= MainMap_MouseUp;
            //}
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

            // get zoom  
            trackBarMap.Properties.Minimum = MainMap.MinZoom+2;
            trackBarMap.Properties.Maximum = MainMap.MaxZoom;
            trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);
        }
        #region===================Map Events==================================

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
        }

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainMap.Zoom < MainMap.MaxZoom)
            {
                int zoom = (int)(MainMap.Zoom + 1);
                if (zoom > MainMap.MaxZoom)
                {
                    zoom = MainMap.MaxZoom;
                }
                trackBarMap.Value = zoom;
                MainMap.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = false;
                if (currentMarker!=null)
                    Route();
                currentMarker = null;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = true;
                if (currentMarker!=null&&currentMarker.IsVisible&&(currentMarker is GMapMarkerCustomEnum))
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                //else
                //{
                //    //PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                //    //string strDiaChi = new TaxiOperation_TongDai.BAGPS.Service().GetAddressByGeo((float)point.Lat, (float)point.Lng);

                //    //MainMap.addMarkerCustomer(point, strDiaChi);
                //}

            }
        }
        private void MainMap_OnMarkerEnter(GMapMarker item)
        {
            currentMarker = item;
        }

        private void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if(!isMouseDown)
                currentMarker = null;
        }
        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                //if (currentMarker is GMapMarkerA)
                //{
                //    AddressA=Service_Common.ServiceSoapClient.GetAddressByGeo((float) currentMarker.Position.Lat,(float)currentMarker.Position.Lng);
                //}
                //     if (currentMarker is GMapMarkerB)
                //{
                //    AddressB = Service_Common.ServiceSoapClient.GetAddressByGeo((float)currentMarker.Position.Lat, (float)currentMarker.Position.Lng);
                //}
                if (currentMarker != null && currentMarker.IsVisible && (currentMarker is GMapMarkerCustomEnum))
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
               
            }
            MainMap.Refresh(); // force instant invalidation
        }
        #endregion=============================================================

        private void setMarkerDSXeDeCu(string DSXeDeCu, string DSXeDeCu_TD)
        {
            try
            {
                int trangThai = 0;
                string[] arrDSXeDeCu = DSXeDeCu.Split('.');
                string[] arrDSXeDeCu_TD = DSXeDeCu_TD.Split(',');
                string[] Values;
                for (int i = 0; i < arrDSXeDeCu.Length; i++)
                {
                    //"SHXe-KhoangCach-KD-VD-TrangThai"
                    Values = arrDSXeDeCu_TD[i].Split('_');
                    if (Values.Length > 0)
                    {
                        if (Values[4] != "")
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeDeCu(trangThai, Convert.ToDouble(Values[2], Global.CultureSystem), Convert.ToDouble(Values[3], Global.CultureSystem), string.Format("{0}-{1}", arrDSXeDeCu[i], Values[1]));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void setMarkerDSXeNhan(string DSXeNhan, string DSXeNhan_TD)
        {
            try
            {
                int trangThai = 0;
                string[] arrDSXeNhan = DSXeNhan.Split('.');
                string[] arrDSXeNhan_TD = DSXeNhan_TD.Split(',');
                string[] Values;
                for (int i = 0; i < arrDSXeNhan.Length; i++)
                {
                    //"SHXe-KhoangCach-KD-VD-TrangThai"
                    Values = arrDSXeNhan_TD[i].Split('_');
                    if (Values.Length > 0)
                    {
                        if (!String.IsNullOrEmpty(Values[4]))
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeNhan(trangThai, Convert.ToDouble(Values[2], Global.CultureSystem), Convert.ToDouble(Values[3], Global.CultureSystem), string.Format("{0}-{1}", arrDSXeNhan[i], Values[1]));
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion        

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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateTrip_Map));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.shPicture_LayLoTrinhTheoGoogle = new Taxi.Controls.Base.Controls.ShPicture();
            this.btnOk = new Taxi.Controls.Base.Controls.ShButton();
            this.txtSearch = new Taxi.Controls.Base.Inputs.InputButtonEdit();
            this.trackBarMap = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.MainMap = new Taxi.Controls.ExtendedGMapControl(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtLoTrinh = new Taxi.Controls.Base.Inputs.InputRichEdit();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtDiemCuoi = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtDiemDau = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel7 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtTienDuKien = new Taxi.Controls.Base.Inputs.InputText();
            this.txtKhoangCach = new Taxi.Controls.Base.Inputs.InputText();
            this.txtThoiGian = new Taxi.Controls.Base.Inputs.InputText();
            this.panel2 = new System.Windows.Forms.Panel();
            this.shLabel8 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel6 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.picDiemTra = new System.Windows.Forms.PictureBox();
            this.picDiemDon = new System.Windows.Forms.PictureBox();
            this.picViTriXe = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shPicture_LayLoTrinhTheoGoogle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiemCuoi.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiemDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienDuKien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhoangCach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDiemTra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiemDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViTriXe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.trackBarMap);
            this.panel1.Controls.Add(this.MainMap);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 573);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.shPicture_LayLoTrinhTheoGoogle);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(316, 35);
            this.panel4.TabIndex = 0;
            // 
            // shPicture_LayLoTrinhTheoGoogle
            // 
            this.shPicture_LayLoTrinhTheoGoogle.CausesValidation = false;
            this.shPicture_LayLoTrinhTheoGoogle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shPicture_LayLoTrinhTheoGoogle.EditValue = global::Taxi.Controls.Properties.Resources._4b43c975_2502_4f1a_b877_fd57c13169e8;
            this.shPicture_LayLoTrinhTheoGoogle.Location = new System.Drawing.Point(283, 3);
            this.shPicture_LayLoTrinhTheoGoogle.Name = "shPicture_LayLoTrinhTheoGoogle";
            this.shPicture_LayLoTrinhTheoGoogle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.shPicture_LayLoTrinhTheoGoogle.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.shPicture_LayLoTrinhTheoGoogle.Size = new System.Drawing.Size(29, 28);
            toolTipItem2.Text = "Lấy lộ trình theo google.";
            superToolTip2.Items.Add(toolTipItem2);
            this.shPicture_LayLoTrinhTheoGoogle.SuperTip = superToolTip2;
            this.shPicture_LayLoTrinhTheoGoogle.TabIndex = 2;
            this.shPicture_LayLoTrinhTheoGoogle.Click += new System.EventHandler(this.shPicture_LayLoTrinhTheoGoogle_Click);
            // 
            // btnOk
            // 
            this.btnOk.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnOk.Location = new System.Drawing.Point(199, 6);
            this.btnOk.LookAndFeel.SkinName = "Blue";
            this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK (F2)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.IsChangeText = false;
            this.txtSearch.IsFocus = false;
            this.txtSearch.KeyCommand = System.Windows.Forms.Keys.F3;
            this.txtSearch.Location = new System.Drawing.Point(4, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtSearch.Properties.LookAndFeel.SkinName = "Blue";
            this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSearch.Properties.MaxLength = 255;
            this.txtSearch.Properties.NullText = "Tên tỉnh,tên đường (F3)";
            this.txtSearch.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_Properties_ButtonClick);
            this.txtSearch.Size = new System.Drawing.Size(189, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // trackBarMap
            // 
            this.trackBarMap.EditValue = null;
            this.trackBarMap.Location = new System.Drawing.Point(2, 36);
            this.trackBarMap.Name = "trackBarMap";
            this.trackBarMap.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trackBarMap.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMap.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.trackBarMap.Size = new System.Drawing.Size(23, 246);
            this.trackBarMap.TabIndex = 1;
            this.trackBarMap.EditValueChanged += new System.EventHandler(this.trackBarMap_EditValueChanged);
            // 
            // MainMap
            // 
            this.MainMap.AllowDrawPolygon = false;
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 0);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(703, 573);
            this.MainMap.TabIndex = 3;
            this.MainMap.Zoom = 0D;
            this.MainMap.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.MainMap_OnMarkerEnter);
            this.MainMap.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.MainMap_OnMarkerLeave);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(703, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(283, 573);
            this.panel3.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtLoTrinh);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 123);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(281, 408);
            this.panel7.TabIndex = 9;
            // 
            // txtLoTrinh
            // 
            this.txtLoTrinh.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtLoTrinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoTrinh.Enabled = false;
            this.txtLoTrinh.IsChangeText = false;
            this.txtLoTrinh.IsFocus = false;
            this.txtLoTrinh.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtLoTrinh.Location = new System.Drawing.Point(0, 0);
            this.txtLoTrinh.Name = "txtLoTrinh";
            this.txtLoTrinh.Padding = new System.Windows.Forms.Padding(10);
            this.txtLoTrinh.ReadOnly = true;
            this.txtLoTrinh.ShowCaretInReadOnly = false;
            this.txtLoTrinh.Size = new System.Drawing.Size(281, 408);
            this.txtLoTrinh.TabIndex = 0;
            this.txtLoTrinh.Views.PrintLayoutView.AllowDisplayLineNumbers = false;
            this.txtLoTrinh.Views.SimpleView.Padding = new System.Windows.Forms.Padding(0);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtDiemCuoi);
            this.panel8.Controls.Add(this.shLabel4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 531);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(281, 40);
            this.panel8.TabIndex = 1;
            // 
            // txtDiemCuoi
            // 
            this.txtDiemCuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDiemCuoi.EditValue = "Hải phòng";
            this.txtDiemCuoi.Enabled = false;
            this.txtDiemCuoi.IsChangeText = false;
            this.txtDiemCuoi.IsFocus = false;
            this.txtDiemCuoi.Location = new System.Drawing.Point(108, 3);
            this.txtDiemCuoi.Name = "txtDiemCuoi";
            this.txtDiemCuoi.Properties.AcceptsReturn = false;
            this.txtDiemCuoi.Properties.AllowFocused = false;
            this.txtDiemCuoi.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtDiemCuoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiemCuoi.Properties.Appearance.Options.UseBackColor = true;
            this.txtDiemCuoi.Properties.Appearance.Options.UseFont = true;
            this.txtDiemCuoi.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtDiemCuoi.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDiemCuoi.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtDiemCuoi.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtDiemCuoi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtDiemCuoi.Size = new System.Drawing.Size(172, 34);
            this.txtDiemCuoi.TabIndex = 0;
            // 
            // shLabel4
            // 
            this.shLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shLabel4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.shLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.shLabel4.Location = new System.Drawing.Point(3, 12);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(99, 16);
            this.shLabel4.TabIndex = 1;
            this.shLabel4.Text = "Điểm kết thúc :";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.shLabel1);
            this.panel5.Controls.Add(this.shLabel2);
            this.panel5.Controls.Add(this.txtDiemDau);
            this.panel5.Controls.Add(this.shLabel3);
            this.panel5.Controls.Add(this.shLabel7);
            this.panel5.Controls.Add(this.txtTienDuKien);
            this.panel5.Controls.Add(this.txtKhoangCach);
            this.panel5.Controls.Add(this.txtThoiGian);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(281, 123);
            this.panel5.TabIndex = 0;
            // 
            // shLabel1
            // 
            this.shLabel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.shLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.shLabel1.Location = new System.Drawing.Point(3, 11);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(95, 16);
            this.shLabel1.TabIndex = 7;
            this.shLabel1.Text = "Khoảng cách  :";
            // 
            // shLabel2
            // 
            this.shLabel2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.shLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.shLabel2.Location = new System.Drawing.Point(4, 38);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(94, 16);
            this.shLabel2.TabIndex = 5;
            this.shLabel2.Text = "Thời gian        :";
            // 
            // txtDiemDau
            // 
            this.txtDiemDau.EditValue = "Hà nội";
            this.txtDiemDau.Enabled = false;
            this.txtDiemDau.IsChangeText = false;
            this.txtDiemDau.IsFocus = false;
            this.txtDiemDau.Location = new System.Drawing.Point(99, 83);
            this.txtDiemDau.Name = "txtDiemDau";
            this.txtDiemDau.Properties.AcceptsReturn = false;
            this.txtDiemDau.Properties.AllowFocused = false;
            this.txtDiemDau.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtDiemDau.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiemDau.Properties.Appearance.Options.UseBackColor = true;
            this.txtDiemDau.Properties.Appearance.Options.UseFont = true;
            this.txtDiemDau.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtDiemDau.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDiemDau.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtDiemDau.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtDiemDau.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtDiemDau.Size = new System.Drawing.Size(178, 34);
            this.txtDiemDau.TabIndex = 3;
            // 
            // shLabel3
            // 
            this.shLabel3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.shLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.shLabel3.Location = new System.Drawing.Point(3, 90);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(95, 16);
            this.shLabel3.TabIndex = 4;
            this.shLabel3.Text = "Điểm bắt đầu :";
            // 
            // shLabel7
            // 
            this.shLabel7.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.shLabel7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.shLabel7.Location = new System.Drawing.Point(4, 62);
            this.shLabel7.Name = "shLabel7";
            this.shLabel7.Size = new System.Drawing.Size(94, 16);
            this.shLabel7.TabIndex = 6;
            this.shLabel7.Text = "Tiền dự kiến   :";
            // 
            // txtTienDuKien
            // 
            this.txtTienDuKien.EditValue = "";
            this.txtTienDuKien.Enabled = false;
            this.txtTienDuKien.IsChangeText = false;
            this.txtTienDuKien.IsFocus = false;
            this.txtTienDuKien.Location = new System.Drawing.Point(99, 62);
            this.txtTienDuKien.Name = "txtTienDuKien";
            this.txtTienDuKien.Properties.AllowFocused = false;
            this.txtTienDuKien.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtTienDuKien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTienDuKien.Properties.Appearance.Options.UseBackColor = true;
            this.txtTienDuKien.Properties.Appearance.Options.UseFont = true;
            this.txtTienDuKien.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtTienDuKien.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTienDuKien.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtTienDuKien.Properties.ReadOnly = true;
            this.txtTienDuKien.Size = new System.Drawing.Size(178, 18);
            this.txtTienDuKien.TabIndex = 2;
            // 
            // txtKhoangCach
            // 
            this.txtKhoangCach.EditValue = "-1";
            this.txtKhoangCach.Enabled = false;
            this.txtKhoangCach.IsChangeText = false;
            this.txtKhoangCach.IsFocus = false;
            this.txtKhoangCach.Location = new System.Drawing.Point(99, 11);
            this.txtKhoangCach.Name = "txtKhoangCach";
            this.txtKhoangCach.Properties.AllowFocused = false;
            this.txtKhoangCach.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtKhoangCach.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtKhoangCach.Properties.Appearance.Options.UseBackColor = true;
            this.txtKhoangCach.Properties.Appearance.Options.UseFont = true;
            this.txtKhoangCach.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtKhoangCach.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtKhoangCach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtKhoangCach.Properties.ReadOnly = true;
            this.txtKhoangCach.Size = new System.Drawing.Size(178, 18);
            this.txtKhoangCach.TabIndex = 0;
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.EditValue = "không thấy đường";
            this.txtThoiGian.Enabled = false;
            this.txtThoiGian.IsChangeText = false;
            this.txtThoiGian.IsFocus = false;
            this.txtThoiGian.Location = new System.Drawing.Point(99, 38);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Properties.AllowFocused = false;
            this.txtThoiGian.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtThoiGian.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtThoiGian.Properties.Appearance.Options.UseBackColor = true;
            this.txtThoiGian.Properties.Appearance.Options.UseFont = true;
            this.txtThoiGian.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtThoiGian.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtThoiGian.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtThoiGian.Properties.ReadOnly = true;
            this.txtThoiGian.Size = new System.Drawing.Size(178, 18);
            this.txtThoiGian.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.shLabel8);
            this.panel2.Controls.Add(this.shLabel6);
            this.panel2.Controls.Add(this.shLabel5);
            this.panel2.Controls.Add(this.picDiemTra);
            this.panel2.Controls.Add(this.picDiemDon);
            this.panel2.Controls.Add(this.picViTriXe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 573);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(986, 32);
            this.panel2.TabIndex = 1;
            // 
            // shLabel8
            // 
            this.shLabel8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.shLabel8.Location = new System.Drawing.Point(236, 9);
            this.shLabel8.Name = "shLabel8";
            this.shLabel8.Size = new System.Drawing.Size(59, 17);
            this.shLabel8.TabIndex = 3;
            this.shLabel8.Text = "Điểm trả";
            // 
            // shLabel6
            // 
            this.shLabel6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.shLabel6.Location = new System.Drawing.Point(127, 8);
            this.shLabel6.Name = "shLabel6";
            this.shLabel6.Size = new System.Drawing.Size(66, 17);
            this.shLabel6.TabIndex = 3;
            this.shLabel6.Text = "Điểm đón";
            // 
            // shLabel5
            // 
            this.shLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.shLabel5.Location = new System.Drawing.Point(32, 9);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(52, 17);
            this.shLabel5.TabIndex = 3;
            this.shLabel5.Text = "Vị trí xe";
            // 
            // picDiemTra
            // 
            this.picDiemTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDiemTra.Image = global::Taxi.Controls.Properties.Resources.STaxi_MarkerA;
            this.picDiemTra.Location = new System.Drawing.Point(210, 6);
            this.picDiemTra.Name = "picDiemTra";
            this.picDiemTra.Size = new System.Drawing.Size(20, 20);
            this.picDiemTra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDiemTra.TabIndex = 2;
            this.picDiemTra.TabStop = false;
            this.picDiemTra.Click += new System.EventHandler(this.picDiemTra_Click);
            // 
            // picDiemDon
            // 
            this.picDiemDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDiemDon.Image = global::Taxi.Controls.Properties.Resources.STaxi_MarkerD;
            this.picDiemDon.Location = new System.Drawing.Point(101, 6);
            this.picDiemDon.Name = "picDiemDon";
            this.picDiemDon.Size = new System.Drawing.Size(20, 20);
            this.picDiemDon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDiemDon.TabIndex = 1;
            this.picDiemDon.TabStop = false;
            this.picDiemDon.Click += new System.EventHandler(this.picDiemDon_Click);
            // 
            // picViTriXe
            // 
            this.picViTriXe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picViTriXe.Image = global::Taxi.Controls.Properties.Resources.XeCK_2;
            this.picViTriXe.Location = new System.Drawing.Point(6, 6);
            this.picViTriXe.Name = "picViTriXe";
            this.picViTriXe.Size = new System.Drawing.Size(20, 20);
            this.picViTriXe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picViTriXe.TabIndex = 0;
            this.picViTriXe.TabStop = false;
            this.picViTriXe.Click += new System.EventHandler(this.picViTriXe_Click);
            // 
            // frmUpdateTrip_Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 605);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmUpdateTrip_Map";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bản đồ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXeBaoDiDuongDai_BanDo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shPicture_LayLoTrinhTheoGoogle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMap)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiemCuoi.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiemDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienDuKien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhoangCach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDiemTra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiemDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViTriXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ExtendedGMapControl MainMap;
        private DevExpress.XtraEditors.ZoomTrackBarControl trackBarMap;
        private Base.Inputs.InputText txtThoiGian;
        private Base.Inputs.InputText txtKhoangCach;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel1;
        private Base.Controls.ShLabel shLabel4;
        private Base.Controls.ShLabel shLabel3;
        private Panel panel4;
        private Base.Controls.ShButton btnOk;
        private Base.Inputs.InputRichEdit txtLoTrinh;
        private PictureBox picDiemTra;
        private PictureBox picDiemDon;
        private PictureBox picViTriXe;
        private Base.Controls.ShLabel shLabel8;
        private Base.Controls.ShLabel shLabel6;
        private Base.Controls.ShLabel shLabel5;
        private InputButtonEdit txtSearch;
        private InputMemoEdit txtDiemDau;
        private InputMemoEdit txtDiemCuoi;
        private InputText txtTienDuKien;
        private Base.Controls.ShLabel shLabel7;
        private Panel panel7;
        private Panel panel8;
        private Panel panel5;
        private Base.Controls.ShPicture shPicture_LayLoTrinhTheoGoogle;
    }
}