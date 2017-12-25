using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Taxi.Business;
using Taxi.Common.DbBase;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Data.FastTaxi;
using Taxi.Utils;
using Taxi.Utils.Enums;                                                                                 
using Taxi.Utils.Enums.DieuXeChieuVe;
using MessageBoxButtons = Taxi.MessageBox.MessageBoxButtonsBA;
using Taxi.Business.DM;
using Taxi.Controls.Base.Common;
using Taxi.Common.Attributes;
using Taxi.Services;
using System.Data;
using Taxi.Controls.FastTaxis.TaxiDieuXe;
using Taxi.Business.Staxi;

namespace Taxi.Controls.FastTaxis.TaxiBook
{
    public partial class frmKhachCanXe : FormBase
    {
        #region Properties
        int G_LoaiXe = 0;
        /// <summary>
        /// Tổng tiền của Trip đề cử
        /// </summary>
        float G_TongTien = 0;
        int G_XNCode = 0;
        /// <summary>
        /// Ngưỡng km dự kiến để khởi tạo thêm trip mới.
        /// </summary>
        private float g_KmDuKien = 30;                                                
        /// <summary>
        /// trạng thái đang có 1 form khách cần xe đang mở.
        /// </summary>
        public bool IsOpen = false;
        public static bool IsOpenStatic = false;
        private Booking _model;
        /// <summary> 
        /// đối tượng detail book được chấp nhận
        /// </summary>
        private BookingsDetail _modelDetail;
        /// <summary>
        /// Danh sach các xe phù hợp.
        /// </summary>
        private List<BookingsDetail> _lsModelDetail;
        /// <summary>
        /// Index của xe trong Danh sách đề cử mặc định là vị trí đầu tiên.
        /// </summary>
        private int _index;

        /// <summary>
        /// Là số phút tính từ lúc mobi bắt đầu đặt tới thời gian thực.
        /// </summary>
        private int SoPhutCho = 0;
        /// <summary>
        /// Nếu = true thì không gửi lên Staxi nữa
        /// </summary>
        private bool G_DoNotSendToServer = false;
        #endregion

        public frmKhachCanXe(Booking model)
        {
            IsOpenStatic = true;
            IsOpen = true;
            InitializeComponent();
            _model = model;
            ConfigMap();
        }

        public frmKhachCanXe(bool IsReceive, Booking model)
        {
            IsOpenStatic = true;
            IsOpen = true;
            InitializeComponent();
            _model = model;
            ConfigMap();
            //if (IsReceive) 
            //    TaxiReturn_Process.OperationHasReceive(_model.PK_BooID, ThongTinCauHinh.GPS_MaCungXN.To<int>());
        }

        #region ==========================MAPS=================================

        private MapModeEnum _mapMode;
        private GMapMarker _currentMarker;
        private GMapMarker _MarkerA;
        private GMapMarker _MarkerB;
        private GMapOverlay _top;
        private GMapOverlay _overlayXeDeCu;
        private GMapOverlay _overlayXeNhan;

        private bool _isMouseDown;

        private void ConfigMap()
        {
            //// config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            //MainMap.CacheLocation = System.Configuration.ConfigurationManager.AppSettings["MapPath"]; //Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 23;
            MainMap.MinZoom = 1;
            MainMap.Zoom =4;
            MainMap.Dock = DockStyle.Fill;

            //MainMap.PolygonsEnabled = false;            
            // map events

            // add custom layers  
            {
                _top = new GMapOverlay("top");
                MainMap.Overlays.Add(_top);

                _overlayXeDeCu = new GMapOverlay("OverlayXeDeCu");
                MainMap.Overlays.Add(_overlayXeDeCu);

                _overlayXeNhan = new GMapOverlay("OverlayXeNhan");
                MainMap.Overlays.Add(_overlayXeNhan);
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
            trackBarMap.Properties.Minimum = MainMap.MinZoom;
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
                _isMouseDown = false;
                //if (currentMarker != null)

                _currentMarker = null;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _isMouseDown = true;
                if (_currentMarker != null && _currentMarker.IsVisible)
                    _currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
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
            _currentMarker = item;
        }

        private void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!_isMouseDown)
                _currentMarker = null;
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _isMouseDown)
            {
                if (_currentMarker != null && _currentMarker.IsVisible)
                {
                    _currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
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
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;
                            //---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeDeCu(trangThai, Convert.ToDouble(Values[2], Global.CultureSystem),
                            Convert.ToDouble(Values[3], Global.CultureSystem),
                            string.Format("{0}-{1}", arrDSXeDeCu[i], Values[1]));
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
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;
                            //---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeNhan(trangThai, Convert.ToDouble(Values[2], Global.CultureSystem),
                            Convert.ToDouble(Values[3], Global.CultureSystem),
                            string.Format("{0}-{1}", arrDSXeNhan[i], Values[1]));
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void trackBarMap_EditValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }

        #endregion

        #region --------- Hàm xử lý -----------------------
        frmInfo _info;
        public void CoCuocGoiMoi(frmInfo info)
        {
            this.Activate();
            _info = info;
            lblCuocMoi.Visible = true;
            info.Remove += info_Remove;
        }

        void info_Remove()
        {
            lblCuocMoi.Visible = false;
            _info = null;
        }
        
        [MethodWithKey(Keys = (Keys.Control | Keys.H))]
        private void MoCuocMoi()
        {
            if (_info != null)
            {
                this.Hide();
                this.Close();
                _info.ShowCtrlH();
            }
        }
        /// <summary>
        /// Đổ dữ liệu từ model vào các control form.
        /// </summary>
        private void DoFill()
        {
            txtDiaChiDon.EditValue = _model.TenGhepDiaChiDon;
            txtDiaChiTra.EditValue = _model.TenGhepDiaChiTra;
            txtGhiChu.EditValue = _model.Description;
            txtGhiChuDieu.EditValue = _model.OpDescription;

            if (_model.FK_TaxiReturn == 0 && _model.OpReceivedTime == null && _model.OpCommand == string.Empty) // Chưa nhận
            {
                btnLuu.Visible = false;
                btnKhachHangHuy.Visible = false;
                btnThoat.Visible = false;
               // btnXoa.Visible = false;
                btnQuayLai.Visible = false;
                btnTiepTuc.Visible = false;
                raTuChoi.Enabled = false;
                raNhanDon.Enabled = false;
                raKhongLienLacDuocLaiXe.Enabled = false;
                txtLyDo.Enabled = false;
                txtGhiChuDieu.Enabled = false;
                lupTrangThaiDieuXe.Visible = false;
                lblTrangThai.Visible = false;
                btnNhanCuoc.Visible = true;
                var dt = _model.DateCreated ?? _model.CreatedDate;
                shProgressBar_TimeOut.Properties.Maximum = 1 * 60;
                shProgressBar_TimeOut.Properties.Minimum = 0;
                SoPhutCho = (int)(TaxiReturn_Process.timerServer - dt.Value).TotalSeconds;
                shProgressBar_TimeOut.EditValue = 1 * 60 - SoPhutCho;
                lblGoiKhach.Visible = false;
                shPicture_CallToCustomer.Visible = false;
                shPicture_CallToCustomer.Enabled = false;
                lblCallDriver.Visible = false;
                shPicture_CallToDriver.Visible = false;
                return;
            }
            else
            {
                btnLuu.Visible = true;
                btnKhachHangHuy.Visible = true;
                btnThoat.Visible = true;
                //btnXoa.Visible = true;
                btnQuayLai.Visible = true;
                btnTiepTuc.Visible = true;
                raTuChoi.Enabled = true;
                raNhanDon.Enabled = true;
                raKhongLienLacDuocLaiXe.Enabled = true;
                txtLyDo.Enabled = true;
                txtGhiChuDieu.Enabled = true;
                lupTrangThaiDieuXe.Visible = true;
                lblTrangThai.Visible = true;
                btnNhanCuoc.Visible = false;
                lblCallDriver.Visible = true;
                shPicture_CallToDriver.Visible = true;
            }

            _lsModelDetail = BookingsDetail.Inst.GetListByBookID(_model.PK_BooID);       
            Xe objXe = new Xe().GetChiTietXe(_model.OpVehicle);
            if (objXe == null)
            {
                txtSoXe.EditValue = _model.OpVehicle;
            }
            else
            {
                txtSoXe.EditValue = string.Format("{0} - {1}", _model.OpVehicle, objXe.BienKiemSoat);
            }
           // if (_model.OpAcceptedTime!=null)
                txtSoDT.EditValue = _model.Mobile;
           // else txtSoDT.EditValue = string.Empty;

            if (_model.FromTime == _model.ToTime)
            {
                txtThoiMonMuon.Text = "Khách hàng muốn đi ngay";
            }
            else
            {
                txtThoiMonMuon.Text = string.Format("{0:HH:mm}-{1:HH:mm dd/MM}", _model.FromTime, _model.ToTime);
            }
            lupTrangThaiDieuXe.EditValue = _model.OpStatus == 0 ? (int)Enum_Bookings_OpStatus.ChapNhan : _model.OpStatus;
            // chưa được ghép xe thì sẽ thực hiện ẩn điện thoại khách và không cho gọi.
            if (_model.FK_TaxiReturn == 0)
            {
                txtSoDT.Properties.Appearance.BackColor = Color.LimeGreen;
                txtSoDT.Properties.AppearanceDisabled.BackColor = Color.LimeGreen;
                _index = 0;
                shProgressBar_TimeOut.Properties.Maximum = 5 * 60;
                var dt = _model.OpReceivedTime;
                if (dt.HasValue)
                {
                    SoPhutCho = (int)(TaxiReturn_Process.timerServer - dt.Value).TotalSeconds;
                }
                else
                {
                    SoPhutCho = 2 * 60;
                }
                shProgressBar_TimeOut.EditValue = 5 * 60 - SoPhutCho;
                lblKhoangCach.Text = _model.BC_Route_Distance.ToString("#,##0");
                //lblGoiKhach.Visible = false;
                //shPicture_CallToCustomer.Visible = false;
                //shPicture_CallToCustomer.Enabled = false;
                 
            }
            else//Nếu đã ghép rồi thì sẽ thục hiện khóa lại và chọn các trạng thái của các cuốc.
            {
                timer_Timeout.Stop();
                shProgressBar_TimeOut.Visible = false;
                if (_lsModelDetail != null && _lsModelDetail.Count > 0)
                {
                    var r = _lsModelDetail.FirstOrDefault(p => p.TripID == _model.FK_TaxiReturn);
                    if (r == null) _index = 0;
                    else
                    {
                        r.Status = (int)Enum_BookingsDetail_Status.DuocChapNhan;
                        _index = _lsModelDetail.IndexOf(r);
                    }
                }
                else
                {
                    lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.KhongXe;
                    txtLyDo.Enabled = false;
                }
                raTuChoi.Enabled = false;
                raNhanDon.Enabled = false;
                raKhongLienLacDuocLaiXe.Enabled = false;
                txtLyDo.Properties.ReadOnly = true;
                btnQuayLai.Enabled = false;
                btnTiepTuc.Enabled = false;
            }
          
        }
        /// <summary>
        /// Kiểm trả dữ liệu.
        /// </summary>
        /// <returns></returns>
        private bool DoVaildate()
        {
            try
            {
                if (lupTrangThaiDieuXe.EditValue.To<int>() == ((int)Enum_Bookings_OpStatus.ChapNhan) || lupTrangThaiDieuXe.EditValue.To<int>() == ((int)Enum_Bookings_OpStatus.DaDonKhach))
                {
                    //Kiểm tra trong những cuốc đường dài đã được báo lên chưa
                    var ls = XeDiDuongDai.Inst.GetListBy(_modelDetail.FK_SoHieuXe);
                    if (ls != null && ls.Count > 0)
                    {
                        //Kiểm tra xem xe đã đón được khách hoặc khách đã lên xe chưa.
                        if (ls.Any(p =>  p.ID!=_model.FK_TaxiReturn&&p.FK_SoHieuXe == _modelDetail.FK_SoHieuXe && (p.TrangThai == (int)Enum_XeBaoDiDuongDai_TrangThai.DaGhepKhach || p.TrangThai == (int)Enum_XeBaoDiDuongDai_TrangThai.KhachDaLenXe)))
                        {
                            txtSoXe.Focus();
                            ShowMessageFail(string.Format("Xe {0} đang ghép cuốc khác", _modelDetail.FK_SoHieuXe));
                            return false;
                        }
                    }
                    else
                    {
                        txtSoXe.Focus();
                        ShowMessageFail("Xe này đã kết thúc");
                        return false;
                    }
                }
                // Nếu trạng thái chấp nhận thì phải có 1 xe được chấp nhận trong danh sách xe đề cử.
                if (lupTrangThaiDieuXe.EditValue.To<int>() == ((int)Enum_Bookings_OpStatus.ChapNhan))
                {
                    if (_lsModelDetail == null || _lsModelDetail.Count == 0)
                    {
                        ShowMessageFail("Không có xe đề cử.");
                    }
                    if (_lsModelDetail.Count(p => p.Status == ((int)Enum_BookingsDetail_Status.DuocChapNhan)) == 0)
                    {
                        txtLyDo.Focus();
                        ShowMessageFail("Chưa có xe nào được chấp nhận");
                       // new MessageBox.MessageBox().Show("Chưa có xe nào được chấp nhận");
                        return false;
                    }
                    if (_model.OpCommand == "KH hủy")
                    {
                        lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.KhachHangHuy;
                        G_DoNotSendToServer = true;
                        ShowMessageFail("Khách hàng đã hủy.");
                       // new MessageBox.MessageBox().Show("Khách hàng đã hủy.");
                        return false;
                    }

                }
                else if (lupTrangThaiDieuXe.EditValue.To<int>() == ((int)Enum_Bookings_OpStatus.TuChoi))
                {
                    if (string.IsNullOrEmpty(txtGhiChuDieu.Text))
                    {
                        txtGhiChuDieu.Focus();
                        ShowMessageFail("Chưa nhập lý do từ chối");
                       // new MessageBox.MessageBox().Show();
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "KhachHangCanXe\\DoVaildate", DateTime.Now, ex.Message);
                 ShowMessageFail("Xảy ra lỗi ngoại lệ:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Đưa dữ liệu từ control vào model
        /// </summary>
        private void DoPasre()
        {
            if (_model == null) _model = new Booking();     
            _model.OpDescription = txtGhiChuDieu.Text;
            int trangThaiDieuXe = lupTrangThaiDieuXe.EditValue.To<int>();
            if (_model.FK_TaxiReturn==0&&(trangThaiDieuXe == (int)Enum_Bookings_OpStatus.DaDonKhach || trangThaiDieuXe == (int)Enum_Bookings_OpStatus.ChapNhan))
            {
                _model.FK_TaxiReturn = _modelDetail.TripID;
                _model.OpVehicle = _modelDetail.FK_SoHieuXe;
            }
            //else
            //{
            //    if (lupTrangThaiDieuXe.EditValue.To<int>() != (int)Enum_Bookings_OpStatus.KetThuc)
            //    {
            //        _model.FK_TaxiReturn = _modelDetail.TripID;
            //        _model.OpVehicle = _modelDetail.FK_SoHieuXe;
            //    }

            //}

        }

        #endregion

        #region --------- Sự kiện của form ----------------

        private void frmKhachCanXe_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindShControl();
                G_XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>();
            }
            catch (Exception ex)
            {
                 ShowMessageFail(ex.Message);
            }
            if (_model != null && _model.PK_BooID > 0)
            {
                DoFill();

                #region -- KH hủy --
                if (_model.OpCommand == "KH hủy")
                {
                    lblGoiKhach.Visible = false;
                   
                    lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.KhachHangHuy;
                    G_DoNotSendToServer = true;
                    lupTrangThaiDieuXe.Enabled = false;
                    timer_CheckKHHuy.Stop();
                    timer_Timeout.Stop();
                    shProgressBar_TimeOut.Visible = false;
                    //if (_model.FK_TaxiReturn == 0)
                    //{
                    //    shPicture_CallToCustomer.Visible = false;
                    //    shPicture_CallToCustomer.Enabled = false;
                    //    txtSoDT.Text = string.Empty;
                    //}
                    //else
                    {
                        shPicture_CallToCustomer.Visible = true;
                        shPicture_CallToCustomer.Enabled = true;
                        lblGoiKhach.Visible = true;
                        txtSoDT.Text = _model.Mobile;
                    }
                }
                #endregion

                #region -- Đã gặp xe --
                else if (_model.OpCommand == "Đã gặp xe")
                {
                    lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.MobileKetThuc;
                    G_DoNotSendToServer = true;
                    lupTrangThaiDieuXe.Enabled = false;
                    timer_CheckKHHuy.Stop();
                    timer_Timeout.Stop();
                    shProgressBar_TimeOut.Visible = false;
                    btnKhachHangHuy.Enabled = false;
                    //  txtSoDT.Text = string.Empty;
                }
                #endregion
                lblOpCommand.Text = _model.OpCommand;
            }
            Showindex(_index);  
         
            this.ActiveControl = txtGhiChuDieu;
            //this.Activate();
            //txtGhiChuDieu.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Focus();
            if (DoVaildate())
            {
                int companyID = ThongTinCauHinh.CompanyID;
                long FK_TaxiReturn_Old = _model.FK_TaxiReturn;
                switch (lupTrangThaiDieuXe.EditValue.To<int>())
                {
                    #region ---------- Chấp nhận-------------

                    // Đối với trường hợp chấp nhận này thì phải tồn tại 1 xe được chấp nhận đón khách.
                    // và cập nhận lại cho 2 bảng chi tiết cuốc khách và xe báo đi đường dài.
                    // đồng thời cập nhận trạng thái chấp nhận cho cuốc đặt và gửi lại server.
                    case (int)Enum_Bookings_OpStatus.ChapNhan:
                        bool checkMess = _model.OpStatus == (int)Enum_Bookings_OpStatus.ChapNhan;
                        if (checkMess || new MessageBox.MessageBoxBA().Show(string.Format("Bạn có chắc chắn điều xe số {0} đón khách chiều về hay không ?", _modelDetail.FK_SoHieuXe), "Thông báo", MessageBoxButtons.YesNo).ToLower() == "yes".ToLower())
                        {
                            DoPasre();
                            try
                            {

                                #region ====== Cập nhật DB ======
                                    _lsModelDetail.ForEach(pi =>
                                    {
                                        pi.DateUpdated = DateTime.Now;//------------Cho lên trên, ra ngoài case để dùng lại
                                        pi.Update();//----------Thay bằng procedure
                                    });
                                    //cập nhật trạng thái của xe đường dài.                                  
                                    var xi = new XeDiDuongDai();
                                    xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.DaGhepKhach, ThongTinDangNhap.USER_ID);
                                    // cập nhật lại trạng thái chấp nhận của Cuốc đặt.
                                    _model.OpStatus = (int)Enum_Bookings_OpStatus.ChapNhan;//----------các cái phần gán cho đối tượng thì cho ra ngoài transaction
                                    if (_model.OpAcceptedUser == null || _model.OpAcceptedUser == "")
                                    {
                                        _model.OpAcceptedTime = TaxiReturn_Process.timerServer;//------------Cho lên trên, ra ngoài case để dùng lại
                                        _model.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                                        G_DoNotSendToServer = false;
                                    }
                                    else
                                    {
                                        G_DoNotSendToServer = true;
                                    }
                                    _model.OpLastModifyTime = _model.OpAcceptedTime;
                                    _model.Update();
                             
                                #endregion

                                #region ====== Gửi lên server ======
                                try
                                {
                                    //Nếu đã ghép thì ko gửi lên server nữa
                                    if (!G_DoNotSendToServer)
                                    {
                                        // Gửi lên server điều hành để cập nhật lại trạng thái chấp nhận
                                        Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer item = new Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer()
                                        {
                                            Answer = Services.FastTaxi_OperationService.BookingDetailStatus.Accept,
                                            TripId = _model.FK_TaxiReturn,
                                            XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>(),
                                            Money = G_TongTien
                                        };
                                        TaxiReturn_Process.OperationAnswer(_model.PK_BooID, item);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                                }
                                #endregion
                                if (checkMess)
                                {
                                    ShowMessageSuccess("Lưu thành công.");
                                }
                                else
                                    ShowMessageSuccess("Điều xe chiều về thành công. Vui lòng giữ liên lạc với khách hàng và lái xe.");
                                Close();
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu chấp nhận lỗi:" + ex.Message);
                                ShowMessageFail("[Chấp nhận] Quá trình lưu xảy ra bị lỗi");
                            }
                        }


                        break;

                    #endregion

                    #region ---------- Đã đón khách ---------

                    case (int)Enum_Bookings_OpStatus.DaDonKhach:

                        try
                        {
                            DoPasre();
                            #region ====== Cập nhật DB ======
                           
                                _lsModelDetail.ForEach(pi =>
                                {
                                    pi.DateUpdated = DateTime.Now;
                                    pi.Update();
                                });
                                //cập nhật trạng thái của xe đường dài.                                  
                                var xi = new XeDiDuongDai();
                                xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.DaGhepKhach, ThongTinDangNhap.USER_ID);
                                _model.OpStatus = (int)Enum_Bookings_OpStatus.DaDonKhach;
                                if (_model.OpAcceptedUser == null || _model.OpAcceptedUser == "")
                                {
                                    _model.OpAcceptedTime =DateTime.Now;
                                    _model.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                                }
                                _model.Update();

                            #endregion

                            #region ====== Gửi lên server ======
                            try
                            {
                                //cập nhật khách lên xe của trip
                                if (!G_DoNotSendToServer)
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, companyID, Services.FastTaxi_OperationService.Trip.Status.KhachDaLenXe);
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                            }
                            #endregion

                            ShowMessageSuccess("Lưu thành công.");
                            Close();
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu chấp nhận lỗi:" + ex.Message);
                            ShowMessageFail("[Đã đón khách] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;

                    #endregion

                    #region ---------- Từ chối --------------

                    case (int)Enum_Bookings_OpStatus.TuChoi:
                        try
                        {
                            DoPasre();
                            #region ====== Cập nhật DB ======
                           
                                //cập nhật trạng thái của xe đường dài.                                  
                                var xi = new XeDiDuongDai();
                               xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);
                                // cập nhật lại trạng thái từ chối của Cuốc đặt.
                                _model.UpdateStatusDescription(_model.PK_BooID, Enum_Bookings_OpStatus.TuChoi, ThongTinDangNhap.USER_ID, _model.OpDescription); ;
                        
                            #endregion

                            #region ====== Gửi lên server ======
                            try
                            {
                                if (_model.FK_TaxiReturn == 0)
                                {
                                    Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer item = new Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer()
                                    {
                                        Answer = Services.FastTaxi_OperationService.BookingDetailStatus.Deny,
                                        TripId = _model.FK_TaxiReturn,
                                        XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>(),
                                        Money = 0
                                    };
                                    TaxiReturn_Process.OperationAnswer(_model.PK_BooID, item);
                                }
                                else
                                {
                                    TaxiReturn_Process.DenyTripInBookingProcess(_model.PK_BooID, _model.FK_TaxiReturn, G_XNCode);
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                                }
                               
                               
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe",
                                    DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                            }
                            #endregion

                            ShowMessageSuccess("Lưu thành công.");
                            Close();
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);
                            ShowMessageFail("[Từ chối] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;

                    #endregion

                    #region ---------- Hoãn -----------------

                    case (int)Enum_Bookings_OpStatus.Hoan:
                        try
                        {
                            DoPasre();
                            #region ====== Cập nhật DB ======
                               //cập nhật trạng thái của xe đường dài.                                  
                                var xi = new XeDiDuongDai();
                               xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);
                                // cập nhật lại trạng thái từ chối của Cuốc đặt.
                                _model.UpdateStatusDescription(_model.PK_BooID, Enum_Bookings_OpStatus.Hoan, ThongTinDangNhap.USER_ID, _model.OpDescription); ;
                            
                            #endregion

                            #region ====== Gửi lên server ======
                            try
                            {
                                if (_model.FK_TaxiReturn == 0)
                                {
                                    Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer item = new Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer()
                                    {
                                        Answer = Services.FastTaxi_OperationService.BookingDetailStatus.Deny,
                                        TripId = _model.FK_TaxiReturn,
                                        XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>(),
                                        Money = 0
                                    };
                                    TaxiReturn_Process.OperationAnswer(_model.PK_BooID, item);
                                }
                                else
                                {
                                    TaxiReturn_Process.DenyTripInBookingProcess(_model.PK_BooID, _model.FK_TaxiReturn, G_XNCode);
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                                }
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "TripUpdateStatus: Hoãn", DateTime.Now, "Gửi lên server xảy ra lỗi:" + ex.Message);
                            }
                            #endregion

                            ShowMessageSuccess("Lưu thành công.");
                            Close();
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);
                            ShowMessageFail("[Hoãn] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;

                    #endregion

                    #region ---------- Trượt ----------------

                    case (int)Enum_Bookings_OpStatus.Truot:
                        try
                        {
                            DoPasre();
                            #region ====== Cập nhật DB ======
                            
                                //cập nhật trạng thái của xe đường dài.                                  
                                var xi = new XeDiDuongDai();
                               xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);
                                // cập nhật lại trạng thái từ chối của Cuốc đặt.
                                _model.UpdateStatusDescription(_model.PK_BooID, Enum_Bookings_OpStatus.Truot, ThongTinDangNhap.USER_ID, _model.OpDescription); ;
                          
                            #endregion

                            #region ====== Gửi lên server ======

                            try
                            {
                                if (_model.FK_TaxiReturn == 0)
                                {
                                    Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer item = new Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer()
                                    {
                                        Answer = Services.FastTaxi_OperationService.BookingDetailStatus.Deny,
                                        TripId = _model.FK_TaxiReturn,
                                        XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>(),
                                        Money = 0
                                    };
                                    TaxiReturn_Process.OperationAnswer(_model.PK_BooID, item);
                                }
                                else
                                {
                                    TaxiReturn_Process.DenyTripInBookingProcess(_model.PK_BooID, _model.FK_TaxiReturn, G_XNCode);
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                                }
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "TripUpdateStatus: Trượt", DateTime.Now, "Gửi lên server xảy ra lỗi:" + ex.Message);
                            }
                            #endregion
                            ShowMessageSuccess("Lưu thành công.");
                            Close();
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);
                            ShowMessageFail("[Trượt] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;

                    #endregion

                    #region ---------- Không xe -------------

                    case (int)Enum_Bookings_OpStatus.KhongXe:
                        try
                        {
                            DoPasre();

                            #region ====== Cập nhật DB ======
                           
                                //cập nhật trạng thái của xe đường dài.                                  
                                var xi = new XeDiDuongDai();
                                xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);
                                // cập nhật lại trạng thái từ chối của Cuốc đặt.
                                _model.UpdateStatusDescription(_model.PK_BooID, Enum_Bookings_OpStatus.KhongXe, ThongTinDangNhap.USER_ID, _model.OpDescription); ;
                          
                            #endregion

                            #region ====== Gửi lên server ======
                            try
                            {
                                if (_model.FK_TaxiReturn == 0)
                                {
                                    Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer item = new Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer()
                                    {
                                        Answer = Services.FastTaxi_OperationService.BookingDetailStatus.Deny,
                                        TripId = _model.FK_TaxiReturn,
                                        XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>(),
                                        Money = 0
                                    };
                                    TaxiReturn_Process.OperationAnswer(_model.PK_BooID, item);
                                }
                                else
                                {
                                    TaxiReturn_Process.DenyTripInBookingProcess(_model.PK_BooID, _model.FK_TaxiReturn, G_XNCode);
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                                }
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "TripUpdateStatus: Không xe", DateTime.Now, "Gửi lên server xảy ra lỗi:" + ex.Message);
                            }
                            #endregion

                            ShowMessageSuccess("Lưu thành công.");
                            Close();
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);
                            ShowMessageFail("[Không xe] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;

                    #endregion

                    #region ---------- Hủy điều -------------

                    case (int)Enum_Bookings_OpStatus.HuyDieu:
                        try
                        {
                            DoPasre();

                            #region ====== Cập nhật DB ======
                               //cập nhật trạng thái của xe đường dài.                                  
                                var xi = new XeDiDuongDai();
                               xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);
                                // cập nhật lại trạng thái từ chối của Cuốc đặt.
                               _model.UpdateStatusDescription(_model.PK_BooID, Enum_Bookings_OpStatus.HuyDieu, ThongTinDangNhap.USER_ID, _model.OpDescription); ;
                           
                            #endregion

                            #region ====== Gửi lên server ======
                            try
                            {
                                if (_model.FK_TaxiReturn == 0)
                                {
                                    Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer item = new Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer()
                                    {
                                        Answer = Services.FastTaxi_OperationService.BookingDetailStatus.Deny,
                                        TripId = _model.FK_TaxiReturn,
                                        XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>(),
                                        Money = 0
                                    };
                                    TaxiReturn_Process.OperationAnswer(_model.PK_BooID, item);
                                }
                                else
                                {
                                    TaxiReturn_Process.DenyTripInBookingProcess(_model.PK_BooID, _model.FK_TaxiReturn, G_XNCode);
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                                }
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "TripUpdateStatus: Hủy điều", DateTime.Now, "Gửi lên server xảy ra lỗi:" + ex.Message);
                            }
                            #endregion

                            ShowMessageSuccess("Lưu thành công.");
                            Close();
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);
                            ShowMessageFail("[Hủy điều] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;

                    #endregion

                    #region ---------- Kết thúc--------------

                    case (int)Enum_Bookings_OpStatus.KetThuc:
                        /*
                         Mô tả: Trường hợp kết thúc sẽ có có 2 trường hợp:
                         * 1.Chưa ghép:sẽ xử lý cập nhận trạng thái kết thúc như bình thường.
                         * 2.Đã ghép :Thông báo "Xe này có muốn đón cuốc chiều về khác không ?"
                         * +nếu chọn không thì thì cập nhận lại trạng thái và kết thúc.
                         * +nếu chọn có thì sẽ tạo 1 trip mới và gửi lên server và kết thúc trip cũ đi.
                         */

                        try
                        {
                            DoPasre();

                            #region Trường hợp 1:chưa ghép thì sẽ bắt buộc từ chối.

                            if (string.IsNullOrEmpty(_model.OpVehicle))
                            {
                                /// trường hợp chưa ghép thì bắt buộc chọn từ chối.
                                ShowMessageFail("Cuốc này chưa được ghép.Vui lòng chọn từ chối");
                                lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.TuChoi;
                            }
                            #endregion

                            #region Trường hợp 2:Đã ghép.
                            else
                            {
                                string rs = string.Empty;
                                var themTrip = new XeDiDuongDai();
                                var address = new AutoCompleteAddress();
                                address.Bind();

                                #region Khởi tạo trip mới và chưa lưu
                                themTrip.ID = _model.FK_TaxiReturn;
                                try
                                {
                                    //Thiếu : Thêm ID cha vào để quan hệ
                                    if (themTrip.GetByKey())
                                    {
                                        themTrip.ParentID = _model.FK_TaxiReturn;
                                        themTrip.ID = 0;
                                        themTrip.LoTrinh = string.Empty;
                                        themTrip.LoTrinh_Diem = string.Empty;
                                        themTrip.KmDuKien = 0;
                                        themTrip.TrangThai = (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach;
                                        themTrip.CreatedDate = TaxiReturn_Process.timerServer;
                                        themTrip.CreatedByUser = ThongTinDangNhap.USER_ID;
                                        themTrip.UpdatedDate = null;
                                        themTrip.UpdatedByUser = string.Empty;
                                        // thời điểm bắt đầu của lái xe.
                                        themTrip.ThoiDiemDi = themTrip.TGDuKien;
                                        //_modelDetail.B
                                        themTrip.DiaDiemDen = _model.ToAdress;
                                        //address.Text = themTrip.DiaDiemDen;
                                        //address.ReSearch();
                                        themTrip.FK_QuanHuyenDenID = address.HuyenId;
                                        themTrip.FK_TinhThanhDenID = address.TinhId;
                                        themTrip.Den_ViDo = _model.ToLat;
                                        themTrip.Den_KinhDo = _model.ToLng;


                                        //lấy tọa độ của xe.
                                        var _xeOnline = WCFService_Common.GetXeOnlineBySHX(themTrip.FK_SoHieuXe);
                                        themTrip.Xe_KinhDo = _xeOnline.KinhDo;
                                        themTrip.Xe_ViDo = _xeOnline.ViDo;

                                        // Lộ trình này là lộ trình của điểm DC
                                        var lotrinh = TaxiReturn_Process.LayLoTrinh(themTrip.Di_ViDo, themTrip.Di_KinhDo, themTrip.Den_ViDo, themTrip.Den_KinhDo);
                                        themTrip.LoTrinh = lotrinh.LoTrinh_DiaChi;
                                        themTrip.LoTrinh_Diem = lotrinh.LoTrinh_ToaDo;
                                        themTrip.KmDuKien = (int)lotrinh.Distance;

                                        //Tính thời gian đi của book.
                                        int SoPhutDiQuangDuongBC = TaxiReturn_Process.TinhThoiGianDiHetQuangDuong(_model.BC_Route_Distance);
                                        themTrip.TGDuKien = themTrip.TGDuKien.AddMinutes(SoPhutDiQuangDuongBC); // là thời điểm đến điểm C.
                                        themTrip.ThoiDiemVe = themTrip.TGDuKien;
                                        Xe objXe1 = new Xe().GetChiTietXe(themTrip.FK_SoHieuXe);
                                        if (objXe1 != null)
                                        {
                                            themTrip.BienSoXe = objXe1.BienKiemSoat;
                                            TinhTienTheoKm objTinhTien = new TinhTienTheoKm(objXe1.LoaiXeID, themTrip.KmDuKien);
                                            themTrip.TienDuKien = objTinhTien.TongTien1Chieu;
                                        }
                                    }

                                }
                                catch (Exception)
                                {
                                    
                                }
                                #endregion

                                if (themTrip.KmDuKien >= g_KmDuKien)
                                    rs = new MessageBox.MessageBoxBA().Show("Xe này có muốn đón cuốc chiều về khác không ?", "Thông báo", MessageBoxButtons.YesNo);
                             

                                    #region nếu chọn đón cuốc chiều về khác thì Thêm mới Trip
                                    if (rs == "Yes")
                                    {
                                        themTrip.Insert();
                                    }                                                                                                                               
                                    themTrip.UpdateStatusV2(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.None, ThongTinDangNhap.USER_ID, true, Enum_Bookings_OpStatus.KetThuc, _model.PK_BooID);
                                    #endregion
                                #region Send server
                                try
                                {
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.KetThuc);
                                    if (rs == "Yes" && themTrip.ID > 0)
                                    {
                                        var rsBoot = TaxiReturn_Process.ReplaceTrip(themTrip.ParentID, themTrip);
                                        themTrip.UpdateIsAddedStaxi(themTrip.ID, ThongTinDangNhap.USER_ID, rsBoot);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);

                                }

                                //chỉ cần Kết thúc cái Book chưa có hàm gửi lên server
                                try
                                {
                                    if (!G_DoNotSendToServer)
                                        TaxiReturn_Process.FinishVehicleReturn(_model.ClientKey);
                                }
                                catch (Exception ex)
                                {
                                    new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                                }

                                #endregion
                                ShowMessageSuccess("Lưu thành công.");
                                Close();
                            }
                            #endregion

                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);
                            ShowMessageFail("[Kết thúc] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;
                    #endregion

                    #region ---------- Khách hàng hủy -------
                    case (int)Enum_Bookings_OpStatus.KhachHangHuy:
                        if (_model.OpCommand=="KH hủy"|| new MessageBox.MessageBoxBA().Show("Khách hàng hủy cuốc chiều về ?", "Thông báo", MessageBoxButtons.YesNo).ToLower() == "yes".ToLower())
                        {
                            try
                            {
                              //cập nhật trạng thái của xe đường dài.    
                                    var xddd = new XeDiDuongDai();
                                   xddd.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);

                                   _model.UpdateStatus(_model.PK_BooID, Enum_Bookings_OpStatus.KhachHangHuy, "KH hủy", ThongTinDangNhap.USER_ID);

                                //});
                                if (!G_DoNotSendToServer)
                                    TaxiReturn_Process.RemoveScheduleVehicleReturnProcess(_model.ClientKey);
                                if (_model.FK_TaxiReturn > 0)
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                new Log().WriteLog(ThongTinDangNhap.USER_ID, "KhachCanXe\\KhachHangHuy_Click", DateTime.Now, ex.Message);
                                ShowMessageFail("[KH hủy] Quá trình lưu xảy ra bị lỗi");
                            }
                        }
                        break;
                    #endregion

                    #region ---------- Khách hàng kết thúc --

                    case (int)Enum_Bookings_OpStatus.MobileKetThuc:
                        try
                        {
                            #region Trường hợp 1:chưa ghép thì sẽ bắt buộc từ chối.

                            if (string.IsNullOrEmpty(_model.OpVehicle))
                            {
                                /// trường hợp chưa ghép thì bắt buộc chọn từ chối.
                                ShowMessageFail("Cuốc này chưa được ghép.Vui lòng chọn từ chối");
                                lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.TuChoi;
                            }
                            #endregion
                            else
                            {
                                DoPasre();
                                string rs = string.Empty;
                                var themTrip = new XeDiDuongDai();
                                var address = new AutoCompleteAddress();
                                address.Bind();

                                #region Khởi tạo trip mới và chưa lưu
                                themTrip.ID = _model.FK_TaxiReturn;
                                try
                                {
                                    //Thiếu : Thêm ID cha vào để quan hệ
                                    if (themTrip.GetByKey())
                                    {
                                        themTrip.ParentID = _model.FK_TaxiReturn;
                                        themTrip.ID = 0;
                                        themTrip.LoTrinh = string.Empty;
                                        themTrip.LoTrinh_Diem = string.Empty;
                                        themTrip.KmDuKien = 0;
                                        themTrip.TrangThai = (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach;
                                        themTrip.CreatedDate = TaxiReturn_Process.timerServer;
                                        themTrip.CreatedByUser = ThongTinDangNhap.USER_ID;
                                        themTrip.UpdatedDate = null;
                                        themTrip.UpdatedByUser = string.Empty;
                                        // thời điểm bắt đầu của lái xe.
                                        themTrip.ThoiDiemDi = themTrip.TGDuKien;
                                        //_modelDetail.B
                                        themTrip.DiaDiemDen = _model.ToAdress;
                                        //address.Text = themTrip.DiaDiemDen;
                                        //address.ReSearch();
                                        themTrip.FK_QuanHuyenDenID = address.HuyenId;
                                        themTrip.FK_TinhThanhDenID = address.TinhId;
                                        themTrip.Den_ViDo = _model.ToLat;
                                        themTrip.Den_KinhDo = _model.ToLng;


                                        //lấy tọa độ của xe.
                                        var _xeOnline = WCFService_Common.GetXeOnlineBySHX(themTrip.FK_SoHieuXe);
                                        themTrip.Xe_KinhDo = _xeOnline.KinhDo;
                                        themTrip.Xe_ViDo = _xeOnline.ViDo;

                                        // Lộ trình này là lộ trình của điểm DC
                                        var lotrinh = TaxiReturn_Process.LayLoTrinh(themTrip.Di_ViDo, themTrip.Di_KinhDo, themTrip.Den_ViDo, themTrip.Den_KinhDo);
                                        themTrip.LoTrinh = lotrinh.LoTrinh_DiaChi;
                                        themTrip.LoTrinh_Diem = lotrinh.LoTrinh_ToaDo;
                                        themTrip.KmDuKien = (int)lotrinh.Distance;

                                        //Tính thời gian đi của book.
                                        int SoPhutDiQuangDuongBC = TaxiReturn_Process.TinhThoiGianDiHetQuangDuong(_model.BC_Route_Distance);
                                        themTrip.TGDuKien = themTrip.TGDuKien.AddMinutes(SoPhutDiQuangDuongBC); // là thời điểm đến điểm C.
                                        themTrip.ThoiDiemVe = themTrip.TGDuKien;
                                        Xe objXe1 = new Xe().GetChiTietXe(themTrip.FK_SoHieuXe);
                                        if (objXe1 != null)
                                        {
                                            themTrip.BienSoXe = objXe1.BienKiemSoat;
                                            TinhTienTheoKm objTinhTien = new TinhTienTheoKm(objXe1.LoaiXeID, themTrip.KmDuKien);
                                            themTrip.TienDuKien = objTinhTien.TongTien1Chieu;
                                        }
                                    }

                                }
                                catch (Exception)
                                {

                                }
                                #endregion

                                if (themTrip.KmDuKien >= g_KmDuKien)
                                    rs = new MessageBox.MessageBoxBA().Show("Xe này có muốn đón cuốc chiều về khác không ?", "Thông báo", MessageBoxButtons.YesNo);
                                   #region nếu chọn đón cuốc chiều về khác thì Thêm mới Trip
                                    if (rs == "Yes")
                                    {
                                        themTrip.Insert();
                                    }
                                    themTrip.UpdateStatusV2(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.None, ThongTinDangNhap.USER_ID, true,Enum_Bookings_OpStatus.MobileKetThuc,_model.PK_BooID);
                                    #endregion
                               

                                #region Send server
                                try
                                {
                                    TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.KetThuc);
                                    if (rs == "Yes" && themTrip.ID > 0)
                                    {
                                        var rsBoot = TaxiReturn_Process.ReplaceTrip(themTrip.ParentID, themTrip);
                                        themTrip.UpdateIsAddedStaxi(themTrip.ID, ThongTinDangNhap.USER_ID, rsBoot);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);

                                }

                                //chỉ cần Kết thúc cái Book chưa có hàm gửi lên server
                                try
                                {
                                    if (!G_DoNotSendToServer)
                                        TaxiReturn_Process.FinishVehicleReturn(_model.ClientKey);
                                }
                                catch (Exception ex)
                                {
                                    new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                                }

                                #endregion
                                ShowMessageSuccess("Lưu thành công.");
                                Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);
                            ShowMessageFail("[Khách hàng kết thúc] Quá trình lưu xảy ra bị lỗi");
                        }
                        break;

                    #endregion

                }
            }
        }
        private void ShowMessageSuccess(string message)
        {
            lbl_Msg.ForeColor = Color.Blue;
            lbl_Msg.Text = message;
        }

        private void ShowMessageFail(string message)
        {
            lbl_Msg.ForeColor = Color.Red;
            lbl_Msg.Text = message;
        }

        private void btnKhachHangHuy_Click(object sender, EventArgs e)
        {
            //Bạn có muốn xóa cuốc khách chiều về này không ?
            if (new MessageBox.MessageBoxBA().Show("Khách hàng hủy cuốc chiều về ?", "Thông báo", MessageBoxButtons.YesNo).ToLower() == "yes".ToLower())
            {
                try
                {
                        //cập nhật trạng thái của xe đường dài.    
                        var xddd = new XeDiDuongDai();
                        xddd.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);

                        _model.UpdateStatus(_model.PK_BooID, Enum_Bookings_OpStatus.KhachHangHuy, "KH hủy", ThongTinDangNhap.USER_ID);

                   
                    if (!G_DoNotSendToServer)
                        TaxiReturn_Process.RemoveScheduleVehicleReturnProcess(_model.ClientKey);
                    if (_model.FK_TaxiReturn > 0)
                        TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                    this.Close();
                }
                catch (Exception ex)
                {
                    new Log().WriteLog(ThongTinDangNhap.USER_ID, "KhachCanXe\\KhachHangHuy_Click", DateTime.Now, ex.Message);
                    ShowMessageFail("[KH hủy] Quá trình lưu xảy ra bị lỗi");
                }
            }
        }
        private void btnHuyDieu_Click(object sender, EventArgs e)
        {
            try
            {
                //if (_model.OpStatus == (int)Enum_Bookings_OpStatus.DaDonKhach)
                //{
                //    ShowMessageFail("[Không xóa được] - Cuốc khách này đã đón được khách");
                //    return;
                //}
                //else if (_model.OpStatus == (int)Enum_Bookings_OpStatus.ChapNhan)
                //{
                //    ShowMessageFail("[Không xóa được] - Cuốc khách này đã ghép xe");
                //    return;
                //}
                var rs = new MessageBox.MessageBoxBA().Show("Bạn có muốn hủy cuốc này không cuốc này không?", "Thông báo",MessageBoxButtons.YesNo);
                if (rs.ToLower() == ("YES").ToLower())
                {


                    #region ====== Cập nhật DB ======
                   
                        //cập nhật trạng thái của xe đường dài.                                  
                        var xi = new XeDiDuongDai();
                       xi.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);
                        // cập nhật lại trạng thái từ chối của Cuốc đặt.
                       _model.UpdateStatus(_model.PK_BooID, Enum_Bookings_OpStatus.HuyDieu, ThongTinDangNhap.USER_ID);
                   
                    #endregion

                    #region ====== Gửi lên server ======
                    try
                    {
                        if (_model.FK_TaxiReturn == 0)
                        {
                            Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer item = new Taxi.Services.FastTaxi_OperationService.TimerSendBookingTimerSendBookingAnswer()
                            {
                                Answer = Services.FastTaxi_OperationService.BookingDetailStatus.Deny,
                                TripId = _model.FK_TaxiReturn,
                                XNCode = ThongTinCauHinh.GPS_MaCungXN.To<int>(),
                                Money = 0
                            };
                            TaxiReturn_Process.OperationAnswer(_model.PK_BooID, item);
                        }
                        else
                        {
                            TaxiReturn_Process.DenyTripInBookingProcess(_model.PK_BooID, _model.FK_TaxiReturn, G_XNCode);
                            TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                        }
                    }
                    catch (Exception ex)
                    {
                        new Log().WriteLog(ThongTinDangNhap.USER_ID, "TripUpdateStatus: Hủy điều", DateTime.Now, "Gửi lên server xảy ra lỗi:" + ex.Message);
                    }
                    #endregion

                    ShowMessageSuccess("Lưu thành công.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "KhachCanXe\\Xoa_Click", DateTime.Now, ex.Message);
                ShowMessageFail("[hủy điều] - Lỗi trong quá trình xử lý");
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNhanCuoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (_model.OpAcceptedTime == null)
                {
                    _model.OpReceivedTime = TaxiReturn_Process.timerServer;
                    _model.OpReceivedUser = ThongTinDangNhap.USER_ID;
                    //_model.OpAcceptedTime = DieuHanhTaxi.GetTimeServer();
                    //_model.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                    _model.Update();
                    TaxiReturn_Process.OperationHasReceive(_model.PK_BooID, ThongTinCauHinh.GPS_MaCungXN.To<int>());
                }
                
                DoFill();
                Showindex(_index);
            }
            catch (Exception ex)
            {
                ShowMessageFail("[Nhận cuốc] - Lỗi trong quá trình xử lý");
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (shProgressBar_TimeOut.EditValue != null)
            {
                shProgressBar_TimeOut.EditValue = shProgressBar_TimeOut.EditValue.To<int>() - 1;
                if (shProgressBar_TimeOut.EditValue.To<int>() <= 0)
                {
                    timer_Timeout.Stop();
                    if (IsOpen)
                        new MessageBox.MessageBoxBA().Show("Hết thời gian xử lý.");
                    this.Close();
                }

            }
           
        }

        private void txtDChiTra_TextChanged(object sender, EventArgs e)
        {
            txtDChiTra.ToolTip = txtDChiTra.Text;
        }

        private void shProgressBar_TimeOut_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            int sophut = (e.Value.To<int>() / 60);
            int soGiay = e.Value.To<int>() - sophut * 60;
            e.DisplayText = string.Format("Còn lại {0}:{1}", sophut, soGiay);

            //if (sophut > 0)
            //{
            //    e.DisplayText = string.Format("Còn lại {0} phút {1} giây", sophut, soGiay);
            //}
            //else
            //{
            //    e.DisplayText = string.Format("Còn lại {1} giây", sophut, soGiay);
            //}
            //txtSoDT.Text = e.DisplayText;
        }

        private void frmKhachCanXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsOpen = false;
            IsOpenStatic = false;
        }

        private void lupTrangThaiDieuXe_EditValueChanged(object sender, EventArgs e)
        {
            if (lupTrangThaiDieuXe.EditValue != null)
            {
                switch (lupTrangThaiDieuXe.EditValue.To<int>())
                {
                    case (int)Enum_Bookings_OpStatus.ChapNhan:
                    case (int)Enum_Bookings_OpStatus.DaDonKhach:
                    case (int)Enum_Bookings_OpStatus.ChoXuLy:
                        groupBox_ThongTinKhachCanXe.Enabled = true;
                        break;
                    default:
                        groupBox_ThongTinKhachCanXe.Enabled = false;
                        break;
                }
                lblGhiChuDieu.Text = lupTrangThaiDieuXe.EditValue.To<int>() == (int)Enum_Bookings_OpStatus.TuChoi ? "Lý &do từ chối" : "Ghi chú &điều";
                if (lupTrangThaiDieuXe.EditValue.To<int>() == (int)Enum_Bookings_OpStatus.TuChoi)
                {
                    txtGhiChuDieu.Focus();
                }
            }
        }

        private void shPicture_CallToCustomer_Click(object sender, EventArgs e)
        {
            new MessageBox.MessageBoxBA().Show("Chưa hoàn thiện chức năng gọi cho khách hàng");
        }

        private void shPicture_CallToDriver_Click(object sender, EventArgs e)
        {
            new MessageBox.MessageBoxBA().Show("Chưa hoàn thiện chức năng gọi cho lái xe");
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {

            if (_model.OpStatus == (int)Enum_Bookings_OpStatus.ChapNhan || _model.OpStatus == (int)Enum_Bookings_OpStatus.DaDonKhach)
            {
                if (_model.OpSendSMS >= 2)
                {
                    lbl_Msg.ForeColor = Color.Red;
                    lbl_Msg.Text = "Bạn đã gửi tin nhắn cho lái xe 2 lần!";
                }
                else
                {
                    string thoigian = string.Format("từ {0:HH:mm} đến {1:HH:mm dd/MM/yyyy}", _model.FromTime, _model.ToTime);
                    if (_model.FromTime == _model.ToTime)
                    {
                        thoigian = string.Format("{0:HH:mm dd/MM/yyyy}", _model.ToTime);
                    }
                    string strSMS = string.Format("Staxi-Don: {0}.DT: {1}.DC: {2}-{3}",
                                                                                        thoigian,
                                                                                        _model.Mobile,
                                                                                        StringTools.convertToUnSign3(_model.FromName),
                                                                                        StringTools.convertToUnSign3(_model.FromAddress));
                    if (Service_Common.FastTaxi.Try(client => client.SendSMS(txtSoDTLX.Text.Trim(), strSMS)))
                    {
                        ShowMessageSuccess("Gửi tin nhắn thành công");
                        _model.OpSendSMS += 1;
                        Booking.Inst.UpdateStatus_OpSendSMS(_model.PK_BooID, _model.OpSendSMS);
                    }
                    else
                    {
                        lbl_Msg.ForeColor = Color.Red;
                        lbl_Msg.Text = "Gửi tin nhắn thất bại, Vui lòng thử lại";
                    }
                }
            }
            else
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "Cuốc này chưa được chấp nhận.";//"Chưa có thông tin số điện thoại của khách hàng";
            }
        }

        private void btnSMS_EditValueChanged(object sender, EventArgs e)
        {
        }

        #endregion

        #region --------- Xử lý thông tin xe đề cử --------
        [MethodWithKey(Keys = Keys.Control | Keys.Right)]
        private void TiepTuc()
        {
            if (lupTrangThaiDieuXe.EditValue.To<int>() != (int)Enum_Bookings_OpStatus.ChapNhan) return;
            if (raNhanDon.Checked) return;
            if (string.IsNullOrEmpty(txtLyDo.Text) || string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                ShowMessageFail("Vui lòng nhập lý do từ chối");
                txtLyDo.Focus();
                return;
            }
            _index++;
            Showindex(_index);
        }
        /// <summary>
        /// 
        /// </summary>
        [MethodWithKey(Keys = Keys.Control | Keys.Left)]
        private void QuayLai()
        {
            if (lupTrangThaiDieuXe.EditValue.To<int>() != (int)Enum_Bookings_OpStatus.ChapNhan) return;
            if (raNhanDon.Checked) return;
            //if (string.IsNullOrEmpty(txtLyDo.Text) || string.IsNullOrWhiteSpace(txtLyDo.Text))
            //{
            //    ShowMessageFail("Vui lòng nhập lý do từ chối");
            //    txtLyDo.Focus();
            //    return;
            //}
            _index--;
            Showindex(_index);
        }
        /// <summary>
        /// Hiển thị thông tin xe trong danh sách xe đề cử.
        /// </summary>
        /// <param name="id">Thứ tự</param>
        private void Showindex(int id)
        {
            if (_lsModelDetail == null || _lsModelDetail.Count == 0)
            {
                txtSoXe.Text = string.Empty;
                txtTGTra.EditValue = null;
                txtDChiTra.Text = string.Empty;
                txtSoDTLX.Text = string.Empty;
                txtLyDo.Text = string.Empty;
                txtIndexTong.Text = "Không có xe đề cử nào";
            }
            else
            {
                if (id >= _lsModelDetail.Count)
                    id = _lsModelDetail.Count - 1;
                if (id <= 0) id = 0;
                _index = id;
                _modelDetail = _lsModelDetail[id];
                txtSoXe.Text = string.Format("{0}", _modelDetail.FK_SoHieuXe);
                txtTGTra.EditValue = _modelDetail.TGDuKien;
                txtDChiTra.Text = _modelDetail.DiaDiemDen;
                txtSoDTLX.Text = _modelDetail.SoDienThoai;
                txtLyDo.Text = _modelDetail.LyDo;

                Xe objXe = new Xe().GetChiTietXe(_modelDetail.FK_SoHieuXe);
                if (objXe != null)
                {
                    G_LoaiXe = objXe.LoaiXeID;
                    TinhTienTheoKm item = new TinhTienTheoKm(G_LoaiXe, _model.BC_Route_Distance);
                    if (item != null)
                    {
                        G_TongTien = item.TongTien1Chieu;
                        lblTongTien.Text = item.TongTien1Chieu.ToString("C0", new CultureInfo("vi-VN"));
                        lblKhoangCach.Text = _model.BC_Route_Distance.ToString("#,##0");
                    }
                    else
                    {
                        lblTongTien.Text = "";
                        lblKhoangCach.Text = "";
                    }
                    txtSoXe.Text = string.Format("{0} - {1} ", _modelDetail.FK_SoHieuXe, objXe.BienKiemSoat);
                }
               
                switch (_modelDetail.Status)
                {
                    case (int)Enum_BookingsDetail_Status.DuocChapNhan:
                        raNhanDon.Checked = true;
                        break;
                    case (int)Enum_BookingsDetail_Status.TuChoi:
                        raTuChoi.Checked = true;
                        break;
                    case (int)Enum_BookingsDetail_Status.KhongTraLoi:
                        raKhongLienLacDuocLaiXe.Checked = true;
                        break;
                    default:
                        raTuChoi.Checked = true;
                        break;
                }
                txtIndexTong.Text = string.Format("Xe {0}/{1} xe đề cử", id + (_lsModelDetail.Count > 0 ? 1 : 0), _lsModelDetail.Count);
                if (_lsModelDetail.Count <= 1)
                {
                    btnTiepTuc.Enabled = false;
                    btnQuayLai.Enabled = false;
                }

                #region Vẽ lộ trình của các điểm

                MainMap.ClearRoute();
                MainMap.ClearAllMarkers();
                /*
                 * A-Điểm bắt đầu xuất phát chiều về.
                 * B-Điểm đón khách.
                 * C-Điểm trả khách.
                 * D-Điểm về gara
                 */
                //Lộ trình BC
                MainMap.AddRoute(TaxiReturn_Process.ConvertToPointLatLng(_model.BC_Route), Color.FromArgb(95, Color.Red));
                //Lộ trình AB
                MainMap.AddRoute(TaxiReturn_Process.ConvertToPointLatLng(_modelDetail.ABRoute), Color.FromArgb(95, Color.Blue));
                //Lộ trình CD
                MainMap.AddRoute(TaxiReturn_Process.ConvertToPointLatLng(_modelDetail.CDRoute), Color.FromArgb(95, Color.Blue));
                //Tọa độ của A
                MainMap.AddMarkerEnum(new PointLatLng(_modelDetail.Den_ViDo, _modelDetail.Den_KinhDo), GMapResources.EnumMarkerCustom.MarkerA);
                //Tọa độ của B
                MainMap.AddMarkerEnum(new PointLatLng(_model.FromLat, _model.FromLng), GMapResources.EnumMarkerCustom.MarkerB);
                //Tọa độ của C
                MainMap.AddMarkerEnum(new PointLatLng(_model.ToLat, _model.ToLng), GMapResources.EnumMarkerCustom.MarkerC);
                //Tọa độ của D
                MainMap.AddMarkerEnum(new PointLatLng(_modelDetail.Di_ViDo, _modelDetail.Di_KinhDo), GMapResources.EnumMarkerCustom.MarkerD);
                MainMap.ZoomAndCenterRoutes("1");
                MainMap.Zoom = 8;
                // MainMap.AddRoute()
                #endregion
            }

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            QuayLai();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            TiepTuc();
        }

        private void raTuChoi_CheckedChanged(object sender, EventArgs e)
        {
            if (_modelDetail == null) return;
            if (raTuChoi.Checked)
            {
                _modelDetail.Status = (int)Enum_BookingsDetail_Status.TuChoi;
            }
        }

        private void raNhanDon_CheckedChanged(object sender, EventArgs e)
        {
            if (_modelDetail == null) return;
            txtLyDo.Text = string.Empty;
            if (raNhanDon.Checked)
            {
                _modelDetail.Status = (int)Enum_BookingsDetail_Status.DuocChapNhan;
                btnTiepTuc.Enabled = false;
                btnQuayLai.Enabled = false;
            }
            else
            {
                btnTiepTuc.Enabled = _lsModelDetail != null && _lsModelDetail.Count > 1;
                btnQuayLai.Enabled = _lsModelDetail != null && _lsModelDetail.Count > 1;
                //  _model.FK_TaxiReturn = 0;
            }

        }

        private void raKhongLienLacDuocLaiXe_CheckedChanged(object sender, EventArgs e)
        {
            if (raKhongLienLacDuocLaiXe.Checked)
            {
                _modelDetail.Status = (int)Enum_BookingsDetail_Status.KhongTraLoi;
                txtLyDo.Text = "Không liên lạc đươc lái xe";
            }
            else if (raNhanDon.Checked)
            {
                txtLyDo.Text = "";
            }

        }

        private void txtLyDo_TextChanged(object sender, EventArgs e)
        {
            if (_modelDetail != null)
                _modelDetail.LyDo = txtLyDo.Text;
        }

        #endregion

        private void timer_CheckKHHuy_Tick(object sender, EventArgs e)
        {
        
            if (_model.OpCommand != string.Empty)
            {
                lblOpCommand.Text = _model.OpCommand;
            }
            if (_model.OpCommand == "KH hủy")
            {
                DoFill();
                Showindex(_index);
                lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.KhachHangHuy;
                G_DoNotSendToServer = true;
                lupTrangThaiDieuXe.Enabled = false;
                timer_CheckKHHuy.Stop();
                timer_Timeout.Stop();
                shProgressBar_TimeOut.Visible = false;
                shPicture_CallToCustomer.Visible = true;
                shPicture_CallToCustomer.Enabled = true;
                lblGoiKhach.Visible = true;
                txtSoDT.Text = _model.Mobile;
                //if (_model.FK_TaxiReturn == 0)
                //{
                //    shPicture_CallToCustomer.Visible = false;
                //    shPicture_CallToCustomer.Enabled = false;
                //    txtSoDT.Text = string.Empty; 
                //    lblGoiKhach.Visible = false;
                //}
              
            }
            if (_model.OpCommand == "Đã gặp xe")
            {
                lupTrangThaiDieuXe.EditValue = (int)Enum_Bookings_OpStatus.MobileKetThuc;
                G_DoNotSendToServer = true;
                lupTrangThaiDieuXe.Enabled = false;
                timer_CheckKHHuy.Stop();
                timer_Timeout.Stop();
                shProgressBar_TimeOut.Visible = false;
                btnKhachHangHuy.Enabled = false;
                //  txtSoDT.Text = string.Empty;
            }
        }
        int time_msg_int =10;
        private void timer_Msg_Tick(object sender, EventArgs e)
        {
            time_msg_int--;
            if (time_msg_int <= 0)
            {
                timer_Msg.Stop();
                time_msg_int = 10;
                lbl_Msg.Text = string.Empty;
            }
        }

        private void lbl_Msg_TextChanged(object sender, EventArgs e)
        {
            if (lbl_Msg.Text!=string.Empty)
            timer_Msg.Start();
        }

        private void shPicture_CallToCustomer_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}