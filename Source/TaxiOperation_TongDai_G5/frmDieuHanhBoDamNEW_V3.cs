using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Common;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using Taxi.Common.Extender;
using Taxi.Controls.BaoCao;
using Taxi.Controls.BaoCao.ThanhCong;
using Taxi.Controls.CommonForm;
using Taxi.Controls.FormCheckCoDuongDai;
using Taxi.Controls.ThueBaoTuyen;
using Taxi.Data.FastTaxi;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business.QuanTri;
using System.Diagnostics;
using Taxi.Business;
using Taxi.Controls;
using System.ComponentModel;
using Taxi.Services;
using System.Linq;
using System.Threading;
using Taxi.Controls.FastTaxis;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Controls.FastTaxis.TaxiTrip;
using Taxi.Utils.Enums;
using TaxiOperation_TongDai.FormFastTaxi;
using TaxiOperation_TongDai.Properties;
using Timer = System.Windows.Forms.Timer;
using Taxi.Controls.VersionInfo;
using Taxi.Business.AutoUpdate;
using Taxi.Data.G5.DanhMuc;
using Taxi.Controls.Base;
using TaxiOperation_TongDai.CanhBaoSanBay;
using Taxi.Data.CanhBaoDieuApp;
using Asterisk.NET.Manager;
using Commune = Taxi.Business.CheckCoDuongDai.Commune;
using District = Taxi.Business.CheckCoDuongDai.District;
using Province = Taxi.Business.CheckCoDuongDai.Province;
using Taxi.Data.BanCo.Entity.TuyenThueBao;
using Taxi.MessageBox;
using Taxi.Data.BanCo.Entity;
using Taxi.Controls.frmXeBaoDiSanBay_DuongDai_Mini;
using TaxiOperation_TongDai.App;

namespace Taxi.GUI
{
    public partial class frmDieuHanhBoDamNEW_V3 : FormBase  
    {
        #region ==========================Init====================================
        //------------------LENH TONG DAI ----------------------------------------
        //private string LENH_1_MOIKHACH = "Mời khách";        
        //private string LENH_3_KHONGXE = "Ko xe xl khách";
        ////private string LENH_9_TIEPTHIXEKHAC = "Tiếp thị 7C/4C";
        ////-----------------------Lenh dtv---------------------------------------
        //private  string LENH_KHACHDAT = "KHÁCH ĐẶT";
        //private  string LENH_SANBAY = "SÂN BAY";
        private string LENH_G_GIUCXE = "Giục xe";
        private string LENH_HUYXE_HOAN = "Hủy xe/Hoãn";
        private string LENH_KTX = "Không thấy xe";
        //private string LENH_BOOKTIMEOUT = "Hết TG xử lý";
        private List<string> g_ListCommandTop;
        //private  string LENH_SPACE_DANGGOI = "Đang gọi";
        //------------------------------------------------------------------------
        private List<CuocGoi> g_lstDienThoai_New = new List<CuocGoi>();  // Cuộc gọi vừa chuyển sang
        private List<CuocGoi> g_lstDienThoai = new List<CuocGoi>();      // Cuộc gọi tổng đài đã tiếp nhận điều
        private List<CuocGoi> g_lstCuocGoiKhongXe = new List<CuocGoi>(); // Lưu nhung cuoc khong xe lan 1, sau X phut thì sẽ hiển thị lên.
        private int g_SoGiayGioiHanKhongXe = 5;
        private DateTime g_TimeServer;
        private List<string> g_ListSoHieuXe;
        private List<CuocGoi> g_lstCuocGoiKetThuc;
        private int g_TimeStep = 0;
        private int g_TimeStepSau1Phut = 0;
        private int g_TimerMsg = 0;
        private int g_Timer5second = 0;
        private int timerCheckVer = 0;
        private int g_TimeSanbay = 0;           //Dùng để cảnh báo cuốc sân bay trong timer.
        private Timer g_TimerCapturePhone;
        private bool g_IsNotifyUpdate = false;  // Có đang hiện form thông báo cập nhật version không
        private string g_Version;
        private string g_VungDuocCapPhep = string.Empty;
        private string g_VungsDuocCapPhep_Temp = string.Empty;// Lưu trữ các lại.sau khi gộp line và trả lại line cũ hiện hành.
        private bool g_TabKetThucDuocChon = false; // lua chon cuoc goi ket thuc
        private bool g_TabCuocDieuAppDuocChon = false;
        private bool g_ChuyenTabCuocGoiSearch = false; // thiet lap de load trong timer
        private int g_SoDong = 20;  // Số dòng hien thi tren luoi cuoc goi ket thuc
        private int g_Status = 0;  // Blink stauts  
        private bool g_NhayMauKhiCoCuocGoiMoi = false;
        private string g_strUsername = "";
        private string g_FullName = "";
        private string g_IPAddress = "";                
        private int g_RowIndex = 0;                 
        private int g_SoLuongDangNhapCS = 0;    // Luu so luong nguoi dang nhap bo phan CS. 10 giay quet mot lan        
        private int g_Thoat999SoPhutGioiHan;            //So phut gioi han cho phep thoat cuoc
        private int g_Thoat999SoCuocGioiHan;            //So cuoc goi gioi han duoc phep su dụng 999
        private bool g_IsThoatDuoc999 = false;
        private DateTime g_ThoiDiemLayDuLieuTruoc;
        private DateTime g_ThoiDiemLayDuLieuTruoc_ChuaNhan;
        private string G_KenhGop = "";
        private frmHienThiBanDo_Mini g_frmBanDo;        
        private frmHienThiBanDo_XeNhan g_frmHienThiBanDo;
        private frmCanhBaoSanBay g_frmCanhBaoSanBay;
        private Messenger g_frmMessenger = new Messenger();
        private List<Province> G_arrProvince { get; set; }
        private List<District> G_arrDistrict { get; set; }
        private List<Commune> G_arrCommune { get; set; }
        public int G_IndexPriority = 0;         //Index các cuốc ưu tiên 
        public int G_IndexKhachVIP = 0;         //KieuKhachHangGoiDen = 3 (Bình thường = 1)
        public int G_IndexKhachVang = 0;        //KieuKhachHangGoiDen = 5
        public int G_IndexKhachBac = 0;         //KieuKhachHangGoiDen = 6
        public int G_IndexCurrentInsert = 0;
        public bool g_HasPopUpNewCall = false;
        #endregion

        #region =======================Constructor=============================
        public frmDieuHanhBoDamNEW_V3()
        {
            try
            {
                InitializeComponent();
                //ShowWelcome();
                if (Global.GridConfig_CuocGoi == Grid_Config.Default)
                {
                    splitContainer1.Panel2Collapsed = true;
                }
                this.ucPanelCommand1.HeThongLayCauHinh = 2;//*sign
                this.ucPanelCommand1.DisplayCommandInPanel();
                //SetCommandFromDB(); 
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhBoDamNEW_V3: ", ex);
            }
        }
        //ctrlWelcome G_ControlWelcome;
        //private void ShowWelcome()
        //{
        //    G_ControlWelcome = new ctrlWelcome();
        //    G_ControlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
        //    G_ControlWelcome.Location = new System.Drawing.Point(0, 61);
        //    G_ControlWelcome.Name = "pnlWelcome";
        //    G_ControlWelcome.Size = new System.Drawing.Size(1123, 512);
        //    G_ControlWelcome.Visible = true;
        //    this.Controls.Add(G_ControlWelcome);
        //    G_ControlWelcome.BringToFront();

        //}
        //private void SetCommandFromDB()
        //{
        //    try
        //    {
        //        if (CommonBL.Commands.Count > 0)
        //        {
        //            LENH_1_MOIKHACH = CommonBL.GetNameByCode(CommandCode.MoiKhach, 2);
        //            LENH_3_KHONGXE = CommonBL.GetNameByCode(CommandCode.KhongXeXL, 2);
        //            //Các lệnh bên điện thoại sang!
        //            //LENH_9_TIEPTHIXEKHAC = CommonBL.GetNameByCode(CommandCode.TiepThiXe, 1); 
        //            LENH_KHACHDAT = CommonBL.GetNameByCode(CommandCode.KhachDat, 1);
        //            //LENH_SANBAY = "SÂN BAY";
        //            LENH_G_GIUCXE = CommonBL.GetNameByCode(CommandCode.GiucXe, 1);
        //            LENH_HUYXE_HOAN = CommonBL.GetNameByCode(CommandCode.HuyHoan, 1);
        //            LENH_KTX = CommonBL.GetNameByCode(CommandCode.KhongThayXe, 1);
        //            //LENH_KTX2 = "Ko thấy xe";
        //            //LENH_BOOKTIMEOUT = "Hết TG xử lý";
        //            LENH_SPACE_DANGGOI = CommonBL.GetNameByCode(CommandCode.DangGoiTD,2);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("SetCommandFromDB: ", ex);
        //    }
        //}
        #endregion

        #region ====================Load Form-Set Data=========================

        #region ---------- Form Load ---------------
        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
            try
            {
                TaxiReturn_Process.IsDebug = false;
                ProcessFastTaxi.Debug = false;
                if (DieuHanhTaxi.CheckConnection())
                {
                    //Lấy thông tin hệ thống
                    //ThongTinCauHinh.LayThongTinCauHinh();
                    //Config_Common.LuoiCuocGoi_FontSize_TongDai = 11;
                    //Config_Common.LuoiCuocGoi_RowHeight_TongDai = 19;
                    RealTimeEnvironment.IniRealTime();
                    if (!Debugger.IsAttached)
                        new LicenseBL().CheckLicense();
                    //Load thông tin tỉnh thành phố! *sign 
                    G_arrProvince = Province.GetAllProvince();
                    G_arrDistrict = District.GetAllDistrict();
                    G_arrCommune = Commune.GetAllCommune();
                    //license.CheckThongTinSDTCongTy(ThongTinCauHinh.SoDienThoaiCongTy.Trim());                 
                    Text = Configuration.GetCompanyName() + " - Điều hành viên ";
                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    LayLineVungCuaNguoiDung();
                    LayCauHinhQuanTri();
                    if (Debugger.IsAttached)
                    {
                        g_VungDuocCapPhep = "1;2;3;4";
                        G_KenhGop = "1;2;3;4";
                    }
                    if (ThongTinCauHinh.GPS_TrangThai)
                    {
                        Global.HasGPS = true;
                        if (Config_Common.MapOnline)
                            Maps_Online.StartTimerLoadMap();
                        Maps_Online.SetPositionConfig();
                    }
                    if (Config_Common.GopLine)
                        g_VungDuocCapPhep = G_KenhGop;
                    if (!ThongTinCauHinh.FT_ChieuVe_Active)
                        btnItemXeDiDuongDai.Visibility=BarItemVisibility.Never;
                    #region validate Login
                    if (Config_Common.ValidateLogin)
                    {
                        InitValidateLogin();
                    }
                    #endregion

                    g_VungsDuocCapPhep_Temp = g_VungDuocCapPhep;

                    if (g_VungDuocCapPhep.Length > 0)
                    {
                        LayDuLieuTheoLineVung();                        
                    }
                    else
                    {
                        new MessageBoxBA().Show(this, "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.", "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);                        
                        Application.Exit();
                    }
                    HienThiTheoCauHinh();

                    grvChoGiaiQuyet.Appearance.FocusedRow.ForeColor = Config_Common.Grid_FocusedRow_Color;
                    grvChoGiaiQuyet.Appearance.FocusedRow.BackColor = Config_Common.Grid_FocusedRow_BackColor;
                    if (Config_Common.Grid_Font != "" && Config_Common.LuoiCuocGoi_FontSize_TiepNhan > 0)
                    {
                        grvChoGiaiQuyet.Appearance.Row.Font = new System.Drawing.Font(new FontFamily(Config_Common.Grid_Font), Config_Common.LuoiCuocGoi_FontSize_TongDai);
                    }
                    if (Config_Common.Grid_HorzLineColor != null && !Config_Common.Grid_HorzLineColor.IsEmpty)
                    {
                        grvChoGiaiQuyet.Appearance.HorzLine.BackColor = Config_Common.Grid_HorzLineColor;
                    }
                }
                else
                {
                    new MessageBoxBA().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhDienThoaiNEW_Load: ", ex);
                new MessageBoxBA().Show(this, "Có lỗi khởi tạo dữ liệu, cần liên lạc với quản trị." + ex.Message, "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
        }

        private void LayCauHinhQuanTri()
        {
            try
            {
                CommonBL.ListQuanTriCauHinh = QuanTriCauHinhEntity.Inst.GetListAll();
                string ip = QuanTriCauHinh.IpAddress;
                var temp = CommonBL.ListQuanTriCauHinh.FirstOrDefault(a => a.IP_Address == ip && a.IsMayTinh == "TD");
                if (temp != null)
                {
                    g_HasPopUpNewCall = temp.HasPopUpNewCall > 0;
                    alertNewCall.AutoFormDelay = temp.HasPopUpNewCall * 1000;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LayCauHinhQuanTri: ", ex);
            }
        }

        /// <summary>
        /// Hiển thị giao diện theo cấu hình Config_Common!
        /// </summary>
        private void HienThiTheoCauHinh()
        {
            if (!Config_Common.NhapTuyenDuongDai)
            {
                HideAllLongColumns();
            }
            if (Config_Common.CauHinhThueBaoTuyen)
            {
                btnTraCuuGiaCuocThueBao.Visibility = BarItemVisibility.Always;
                btnNhatKyThueBao.Visibility = BarItemVisibility.Always;
            }
            if (Config_Common.TongDai_KhungDiaChi == KhungDiaChi.Tren)
                panel_KhungDiaChi.Dock = DockStyle.Top;
            if (Config_Common.NhapChotCoDuongDai == 0)
            {
                barButton_ChotCoDD_Mini.Visibility = BarItemVisibility.Never;
                barButton_ChotCoDD.Visibility = BarItemVisibility.Never;
                barSubItem_ChotCoDD.Visibility = BarItemVisibility.Never;
            }
            else if (Config_Common.NhapChotCoDuongDai == 1)
            {
                barButton_ChotCoDD_Mini.Visibility = BarItemVisibility.Always;
                barButton_ChotCoDD.Visibility = BarItemVisibility.Never;
            }
            else
            {
                barButton_ChotCoDD_Mini.Visibility = BarItemVisibility.Never;
                barButton_ChotCoDD.Visibility = BarItemVisibility.Always;
            }
        }

        private void ExitApplication()
        {
            new MessageBoxBA().Show("Phần mềm của bạn chưa được đăng ký! Vui lòng liên hệ với nhà sản xuất để lấy mã đăng ký!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
            Application.Exit();
        }
        private void HideAllLongColumns()
        {
            colTuyenDuong.Visible = false;
            colChieu.Visible = false;
            colHangXe.Visible = false;
            colGia.Visible = false;
            colKm.Visible = false;
            colThoiGian.Visible = false;
        }

        private void LayDuLieuTheoLineVung()
        {
            try
            {
                ThietLapKhungTroGiup();
                grdChoGiaiQuyet.Focus();
                g_TimeServer = DieuHanhTaxi.GetTimeServer();
                g_ThoiDiemLayDuLieuTruoc = g_TimeServer;
                g_ThoiDiemLayDuLieuTruoc_ChuaNhan = g_TimeServer;
                g_ListSoHieuXe = Xe.GetListSoHieuXe();
                g_SoLuongDangNhapCS = ThongTinDangNhap.GetSoLuongCSDangNhapThuocVung(this.g_VungDuocCapPhep);

                LayCauHinhThoatCuoc999();
                #region Command sắp xếp lên đầu
                LENH_G_GIUCXE = CommonBL.GetNameByCodeEnum(Enum_CommandCode.DTV_GiucXe, 1);
                LENH_KTX = CommonBL.GetNameByCodeEnum(Enum_CommandCode.DTV_KhongThayXe, 1);
                LENH_HUYXE_HOAN = CommonBL.GetNameByCodeEnum(Enum_CommandCode.DTV_HuyHoan, 1);
                g_ListCommandTop = new List<string>();
                if (!string.IsNullOrEmpty(LENH_G_GIUCXE))
                    g_ListCommandTop.Add(LENH_G_GIUCXE);
                if (!string.IsNullOrEmpty(LENH_KTX))
                    g_ListCommandTop.Add(LENH_KTX);
                if (!string.IsNullOrEmpty(LENH_HUYXE_HOAN))
                    g_ListCommandTop.Add(LENH_HUYXE_HOAN);
                #endregion

                LoadAllCuocGoiHienTai(g_VungDuocCapPhep);
                Thread.Sleep(5000);
                CheckIn();

                CommonBL.LoadVehicles();
                //HienThiTrenLuoi(true, true);
                HienThiTrenLuoi_ChuaNhan(true, true);
                InitTimerCapturePhone(); //Khởi tạo timer quét cuộc gọi mới!

                bwSync_AddCuocGoi.DoWork += bwSync_AddCuocGoi_DoWork;
                bwSync_RemoveCuocGoi.DoWork += bwSync_RemoveCuocGoi_DoWork;

                HienThiTrenLuoi(true, true);
                DoFastTaxi();
                if (Config_Common.App_SOS_Alert)
                    Taxi.Controls.SOS.ProcessCanhBaoSos.Start();
                if(Config_Common.CoDieuApp)
                    SearchCuocDieuApp();

                g_frmHienThiBanDo = new frmHienThiBanDo_XeNhan();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LayDuLieuTheoLineVung: ", ex);
            }
        }

        private void LayLineVungCuaNguoiDung()
        {
            try
            {
                using (DataTable dt = QuanTriCauHinh.GetLines_LoaiXeOfPCTongDai(g_IPAddress))
                {
                    if (dt.Rows != null && dt.Rows.Count > 0)
                    {
                        g_VungDuocCapPhep = dt.Rows[0]["Line_Vung"].ToString();
                        if (Config_Common.GopLine || ThongTinCauHinh.GopKenh_TrangThai)
                            G_KenhGop = dt.Rows[0]["LineGop"] == DBNull.Value || (string)dt.Rows[0]["LineGop"] == "" ? g_VungDuocCapPhep : dt.Rows[0]["LineGop"].ToString();
                        //if (Config_Common.MPCC_TrunkDial != "" &&
                        //    Config_Common.MPCC_Queue != "" &&
                        //    Config_Common.MPCC_LinkDial != "")
                        {
                            g_LineIPPBX = dt.Rows[0]["Extension"] != null ? dt.Rows[0]["Extension"].ToString() : "";
                        }
                    }
                    else
                    {
                        g_VungDuocCapPhep = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LayLineVungCuaUser  ->  GetLines_LoaiXeOfPCTongDai", ex);
            }
        }

        #endregion //End Form Load

        #region  ---------- Hàm thực hiện ----------

        private void LayCauHinhThoatCuoc999()
        {            
            g_Thoat999SoPhutGioiHan = 15;
            g_Thoat999SoCuocGioiHan = 30;
            int vung;
            string[] arrVungs = g_VungDuocCapPhep.Split(";".ToCharArray());
            if (int.TryParse(arrVungs[0], out vung))
            {
                DataTable dt = ThoatCuoc999.GetCauHinhBATTATByVung(vung);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                  
                    if (!int.TryParse(dr["SoPhutDuocThoatCuoc"].ToString(), out g_Thoat999SoPhutGioiHan))
                    {
                        g_Thoat999SoPhutGioiHan = 15;
                    }
                    if (!int.TryParse(dr["GioiHanSoCuocDuocBat"].ToString(), out g_Thoat999SoCuocGioiHan))
                    {
                        g_Thoat999SoCuocGioiHan = 40;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region ======================Validation Form==========================

        /// <summary>
        /// Confirm có tiếp tục check in hay không. nếu có sẽ check out toàn bộ các account đã check in trên máy.
        /// 1 : có người đăng nhập trên máy này rồi
        /// 2 : account này đã đăng nhập ở 1 máy tính khác
        /// </summary>
        private void CheckIn()//*sign
        {
            //G_ControlWelcome.Visible = false;
            frmCheckInOut frmCheckIn = new frmCheckInOut();
            frmCheckIn.ShowDialog();
            //frmCheckIn.ShowCheckin();
            g_strUsername = ThongTinDangNhap.USER_ID;
            g_FullName = ThongTinDangNhap.FULLNAME;
            if (g_strUsername.Length > 0)
            {
                //if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) 
                //{

                //}
                //else
                {
                    // Kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
                    if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
                    {
                        string alert = new MessageBoxBA().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi", MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Warning);
                        if (alert == "Yes")
                        {
                            ThongTinDangNhap.CheckOutByIpAddress(g_IPAddress);
                        }
                        else
                        {
                            Application.Exit();
                            return;
                        }
                    }
                    //Kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
                    if (!Config_Common.DangNhapNhieuMay && ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
                    {
                        new MessageBoxBA().Show(this, "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_FullName = "";
                        Application.Exit();
                        return;
                    }
                    //Nếu Cho đăng nhập ở nhiều máy thì logout ở các máy khác đi
                    else if (Config_Common.DangNhapNhieuMay)
                    {
                        ThongTinDangNhap.CheckOut_AllIn_OtherIP(g_strUsername, g_IPAddress);
                    }               
                    if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
                    {
                        new MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_FullName = "";
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        if (!((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) || (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
                        {
                            new MessageBoxBA().Show(this, "Bạn không có quyền điều hành điện thoại.", "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            ThongTinDangNhap.CheckOutByIpAddress(g_IPAddress);
                            ThongTinDangNhap.USER_ID = "";
                            g_strUsername = "";
                            g_FullName = "";
                            Application.Exit();
                            return;
                        }
                    }
                }

                Text = String.Format("{0} - Tổng đài viên  [{1} - {2}] - {3} - {4}", Configuration.GetCompanyName(), g_VungDuocCapPhep, g_IPAddress, ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME);                
                status5.EditValue = string.Format("NV : {0} - {1}", g_strUsername, g_FullName);                
                grvCuocGoiKetThuc.LoadLayouFromStringXml(G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvCuocGoiKetThuc.Name, ThongTinDangNhap.USER_ID));
                grvChoGiaiQuyet.LoadLayouFromStringXml(G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvChoGiaiQuyet.Name, ThongTinDangNhap.USER_ID));
                CauHinhLuoiDieuSanBay();
                InitBackGroundApp();
            }
            else
            {
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                g_FullName = "";
            }
        }

        private void CauHinhLuoiDieuSanBay()//*sign
        {
            string kenhVung = Config_Common.DieuSanBay + ";";
            if ((g_VungDuocCapPhep + ";").IndexOf(kenhVung) > -1)
            {
                Global.IsDieuSanBayTongDai = true;
                colThoiGianHen.Visible = true;
                colThoiGianHen.VisibleIndex = 2;

                colThoiGianHenKetThuc.Visible = true;
                colThoiGianHenKetThuc.VisibleIndex = 3;
                g_frmCanhBaoSanBay = new frmCanhBaoSanBay();
                g_frmCanhBaoSanBay.OnClickCuocSanBay += FocusRowOnGridView;
                g_frmCanhBaoSanBay.Hide();
            }
            else
            {
                colThoiGianHen.Visible = false;
                colThoiGianHenKetThuc.Visible = false;
            }
        }

        /// <summary>
        /// thiết lập panel trợ giúp
        /// </summary>
        private void ThietLapKhungTroGiup()
        {
            panelTopHelp.Size= new Size(756,85);
            panelTopHelp.Location = new Point(this.Width - (panelTopHelp.Width + 15 + 32), 0);
            panelTopHelp.Visible = true;
            btnHelp.Location = new Point(this.Size.Width - (btnHelp.Size.Width + 15), 0);
        }

        private bool g_IsBinding=false;
        /// <summary>
        /// Hiển thị thông tin lên lưới
        /// Nếu IsRefesh = true thì chỉ thực hiện refesh
        /// ngược lại : thì load mới
        /// </summary>
        private void HienThiTrenLuoi(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                if (grdChoGiaiQuyet.InvokeRequired)
                {
                    grdChoGiaiQuyet.Invoke(new Action(() => HienThiTrenLuoi(IsCapNhat, IsThemMoi)));
                    return;
                }
                var g_RowIndex_Temp = (g_RowIndex);
                var FirstRow = grvChoGiaiQuyet.FocusedRowHandle - grvChoGiaiQuyet.TopRowIndex;
                if (Global.IsDieuSanBayTongDai)//*sign
                {
                    g_lstDienThoai = g_lstDienThoai.OrderBy(x => x.ThoiGianHen).ToList(); 
                }
                //Binding lưới chờ giải quyết với list!
                g_IsBinding = true;
                grdChoGiaiQuyet.DataSource = g_lstDienThoai;
                grdChoGiaiQuyet.RefreshDataSource();
                g_IsBinding = false;
                grvChoGiaiQuyet_FocusedRowChanged(null, null);
                if (grvChoGiaiQuyet.RowCount == 0)
                    return;
                if (g_RowIndex_Temp < grvChoGiaiQuyet.RowCount)
                {
                    grvChoGiaiQuyet.FocusedRowHandle = (g_RowIndex_Temp);
                }
                else
                {
                    grvChoGiaiQuyet.FocusedRowHandle = grvChoGiaiQuyet.RowCount - 1;
                }

                //if (FirstRow < 0 || g_RowIndex_Temp < FirstRow || g_RowIndex_Temp < 22)
                //{
                //    grvChoGiaiQuyet.TopRowIndex = 0;
                //}
                //else
                //{
                //    grvChoGiaiQuyet.TopRowIndex = g_RowIndex_Temp - FirstRow;
                //}
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiTrenLuoi", ex);
            }
        }

        private void HienThiTrenLuoi_ChuaNhan(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                if (grdCuocKhachMoi.InvokeRequired)
                {
                    grdCuocKhachMoi.Invoke(new Action(() => HienThiTrenLuoi_ChuaNhan(IsCapNhat, IsThemMoi)));
                    return;
                }
                var g_RowIndex_Temp = (g_RowIndex);
                var FirstRow = grvCuocKhachMoi.FocusedRowHandle - grvCuocKhachMoi.TopRowIndex;
                if (IsThemMoi)
                {
                    grdCuocKhachMoi.DataSource = g_lstDienThoai;
                    grdCuocKhachMoi.Refresh();
                }
                else
                {
                    grdCuocKhachMoi.RefreshDataSource();
                }
                if (grvCuocKhachMoi.RowCount == 0)
                    return;
                if (g_RowIndex_Temp < grvCuocKhachMoi.RowCount)
                {
                    grvCuocKhachMoi.FocusedRowHandle = (g_RowIndex_Temp);
                }
                else
                {
                    grvCuocKhachMoi.FocusedRowHandle = grvCuocKhachMoi.RowCount - 1;
                }

                if (FirstRow < 0 || g_RowIndex_Temp < FirstRow || g_RowIndex_Temp < 22)
                {
                    grvCuocKhachMoi.TopRowIndex = 0;
                }
                else
                {
                    grvCuocKhachMoi.TopRowIndex = g_RowIndex_Temp - FirstRow;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiTrenLuoi", ex);
            }

        }

        /// <summary>
        /// Hiển thị thông tin lên lưới
        /// Nếu IsRefesh = true thì chỉ thực hiện refesh
        /// ngược lại : thì load mới
        /// </summary>
        private void HienThiTrenLuoi_KETTHUC(bool IsCapNhat, bool IsThemMoi)
        {
            grcCuocGoiKetThuc.DataSource = g_lstCuocGoiKetThuc;
            grcCuocGoiKetThuc.Refresh();
        }

        private void BlinkStatus(int iStatus)
        {
            statusImage.ImageIndex = iStatus;
        }

        private void CheckOut(string message = "")
        {            
            if (message == "" && ThongTinDangNhap.IsUserPostionTrust(g_strUsername, QuanTriCauHinh.IpAddress))
            {
                if (ThongTinDangNhap.CheckOut(g_strUsername, QuanTriCauHinh.IpAddress))
                {
                    new MessageBoxBA().Show(this, "CheckOut thành công, bạn cần bảo người đổi ca checkin luôn.",
                        "Thông báo", MessageBoxButtonsBA.OK,
                        MessageBoxIconBA.Information);
                }
                else
                {
                    new MessageBoxBA().Show(this,
                        "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo",
                        MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                }
            }
            else
            {
                if (message =="")
                {
                    message="Bạn ngồi không đúng vị trí cần ngồi đúng máy bạn đã khai báo vào hệ thống (checkin).";
                }
                new MessageBoxBA().Show(this, message,"Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }

            status5.EditValue = "NV: ";
            ThongTinDangNhap.USER_ID = "";
            CheckIn();
        }

        #endregion

        #region =======================Get Data Form===========================
        /// <summary>
        /// Hàm xử lý lấy ds các cuộc gọi vùng đang xử lý của vùng được cấp phép
        /// </summary>        
        private void LoadAllCuocGoiHienTai(string vungsDuocCapPhep)
        {
            g_lstDienThoai = new List<CuocGoi>();
            if (ThongTinCauHinh.FT_Active)
                g_lstDienThoai = CuocGoi.G5_TONGDAI_LayAllCuocGoi(vungsDuocCapPhep, ref g_lstDienThoai_New);
            else
                g_lstDienThoai = CuocGoi.G5_TONGDAI_LayAllCuocGoiNotFT(vungsDuocCapPhep, ref g_lstDienThoai_New);
            SapXepCuocGoiThanThiet();
        }
        /// <summary>
        /// Thực hiện sắp xếp các cuộc gọi thân thiết khi lần đầu load form
        /// </summary>
        private void SapXepCuocGoiThanThiet()
        {
            List<CuocGoi> lstDienThoai = new List<CuocGoi>();
            int index = 0;
            string indexRemove = "";
            foreach (CuocGoi objCuocGoi in g_lstDienThoai)
            {
                if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP
                    || objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                    || objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac
                    || (g_ListCommandTop.Contains(objCuocGoi.LenhDienThoai) && Config_Common.TDV_ORDERBYCOMMAND)
                )
                {
                    lstDienThoai.Add(objCuocGoi);
                    indexRemove = indexRemove + index+ ";";
                }
                index++;
            }
            if (indexRemove.Length > 0)
            {
                string[] array = indexRemove.Split(';');

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length > 0)
                    {
                        try
                        {
                            g_lstDienThoai.RemoveAt(Convert.ToInt16(array[i]) - i);
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("SapXepCuocGoiThanThiet:", ex);
                        }
                    }
                }

                foreach (CuocGoi item in lstDienThoai)
                {
                    if (item.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                    {
                        g_lstDienThoai.Insert(0, item);
                        G_IndexKhachVIP++;
                    }
                    else if (item.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                    {
                        g_lstDienThoai.Insert(G_IndexKhachVIP, item);
                        G_IndexKhachVang++;
                    }
                    else if (item.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                    {
                        g_lstDienThoai.Insert(G_IndexKhachVang, item);
                        G_IndexKhachBac++;
                    }
                    else
                    {
                        if (g_ListCommandTop.Contains(item.LenhDienThoai) && Config_Common.TDV_ORDERBYCOMMAND)
                        {
                            G_IndexPriority = G_IndexPriority + G_IndexKhachBac;
                            g_lstDienThoai.Insert(G_IndexPriority, item);
                            G_IndexPriority++;
                        }
                    }
                }

            }
        }

        /// <summary>
        /// hàm trả về ds sách cuộc gọi 
        /// </summary>
        private void LoadCacCuocGoiKetThuc(string vungsDuocCapPhep, int soDong)
        {
            try
            {
                if (ThongTinCauHinh.FT_Active)
                    g_lstCuocGoiKetThuc = CuocGoi.G5_TONGDAI_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong);
                else
                    g_lstCuocGoiKetThuc = CuocGoi.G5_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(vungsDuocCapPhep, soDong);
                grcCuocGoiKetThuc.DataSource = g_lstCuocGoiKetThuc;
                grcCuocGoiKetThuc.Refresh();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadCacCuocGoiKetThuc:", ex);
            }
        }

        /// <summary>
        /// Hàm thực hiện lấy các cuộc gọi các cuộc gọi thay đổi phía điện thoai mà nhân viên tổng đài đã nhận xử lý!
        /// </summary>
        private void LoadCuocGoiMoiTongDai_DaNhan(ref List<CuocGoi> listCuocGoiHienTai, string vungDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi, ref DateTime DateMax)
        {
            hasThemMoi = false;
            hasCapNhat = false;
            // nếu chưa có ds cuộc gọi hiện tại
            if (listCuocGoiHienTai == null)
                listCuocGoiHienTai = new List<CuocGoi>();

            // cuộc gọi chưa có trong cuộc gọi thì chèn mới
            // nếu có rồi thì cập nhật
            List<CuocGoi> listCuocGoiMoi;
            if (ThongTinCauHinh.FT_Active)
                listCuocGoiMoi = CuocGoi.G5_TONGDAI_LayCuocGoiDaNhanXuLy(vungDuocCapPhep, thoiDiemLayDuLieuTruoc);
            else
                listCuocGoiMoi = CuocGoi.G5_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(vungDuocCapPhep, thoiDiemLayDuLieuTruoc);
            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                hasCapNhat = true;
                for (int i = 0; i < listCuocGoiMoi.Count; i++)
                {
                    CuocGoi objCG = listCuocGoiMoi[i];
                    if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                        DateMax = objCG.ThoiDiemThayDoiDuLieu;
                    int index = -1;
                    for (int j = 0; j < listCuocGoiHienTai.Count; j++)
                    {
                        if (objCG.IDCuocGoi == listCuocGoiHienTai[j].IDCuocGoi) // Da co 1 cuoc ton tai thi cap nhat
                        {
                            index = j; break;
                        }
                    }
                    if (index == -1)
                    {
                        hasThemMoi = true;
                        if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                        {
                            listCuocGoiHienTai.Insert(0, objCG);
                            G_IndexKhachVIP++;
                        }
                        else if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                        {
                            listCuocGoiHienTai.Insert(G_IndexKhachVIP, objCG);
                            G_IndexKhachVang++;
                        }
                        else if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                        {
                            listCuocGoiHienTai.Insert(G_IndexKhachVang, objCG);
                            G_IndexKhachBac++;
                        }
                        else// Khách hàng thường!
                        {
                            G_IndexCurrentInsert = G_IndexKhachVIP + G_IndexKhachVang + G_IndexKhachBac;
                            listCuocGoiHienTai.Insert(G_IndexCurrentInsert, objCG);
                        }
                        // Neu la cuoc goi lai, tim cuoc goi taxi cua cuoc goi do va day len tren gan cuoc goi taxi
                        if (objCG.KieuCuocGoi == KieuCuocGoi.GoiLai)
                        {
                            // tìm đến cuộc gọi taxi của số này, chèn cuộc đó lên đầu.
                            int viTri = -1;
                            for (int k = 0; k < listCuocGoiHienTai.Count; k++)
                            {
                                if (listCuocGoiHienTai[k].PhoneNumber == objCG.PhoneNumber && listCuocGoiHienTai[k].KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                                {
                                    viTri = k;
                                    break;
                                }
                            }
                            if (viTri > 1) // loaij bo vi tri nay vi se chen ngay vao vi tri so 1
                            {
                                listCuocGoiHienTai.Insert(G_IndexCurrentInsert + 1, listCuocGoiHienTai[viTri]);
                                listCuocGoiHienTai.RemoveAt(viTri + 1);
                            }
                        }
                    }
                    else // cap nhat thong tin cua dien thoai gui sang cho
                    {
                        var cuocGoiCurrent = listCuocGoiHienTai[index];
                        cuocGoiCurrent.DiaChiTraKhach = objCG.DiaChiTraKhach;
                        cuocGoiCurrent.DiaChiDonKhach = objCG.DiaChiDonKhach;
                        cuocGoiCurrent.SoLanGoi = objCG.SoLanGoi;
                        cuocGoiCurrent.Vung = objCG.Vung;
                        cuocGoiCurrent.LoaiXe = objCG.LoaiXe;
                        cuocGoiCurrent.SoLuong = objCG.SoLuong;
                        cuocGoiCurrent.KieuKhachHangGoiDen = objCG.KieuKhachHangGoiDen;
                        cuocGoiCurrent.IsCuocGiaLap = objCG.IsCuocGiaLap;
                        cuocGoiCurrent.KieuCuocGoi = objCG.KieuCuocGoi;
                        cuocGoiCurrent.LenhDienThoai = objCG.LenhDienThoai;
                        cuocGoiCurrent.GhiChuDienThoai = objCG.GhiChuDienThoai;
                        cuocGoiCurrent.LenhTongDai = objCG.LenhTongDai;
                        cuocGoiCurrent.GhiChuTongDai = objCG.GhiChuTongDai;
                        cuocGoiCurrent.MaNhanVienTongDai = objCG.MaNhanVienTongDai;
                        cuocGoiCurrent.MaNhanVienDienThoai = objCG.MaNhanVienDienThoai;
                        cuocGoiCurrent.ThoiDiemChuyenTongDai = objCG.ThoiDiemChuyenTongDai;
                        cuocGoiCurrent.DanhSachXeDeCu = objCG.DanhSachXeDeCu;
                        cuocGoiCurrent.DanhSachXeDeCu_TD = objCG.DanhSachXeDeCu_TD;
                        cuocGoiCurrent.ThoiDiemCapNhatXeDeCu = objCG.ThoiDiemCapNhatXeDeCu;
                        cuocGoiCurrent.XeNhan = objCG.XeNhan;
                        cuocGoiCurrent.XeNhan_TD = objCG.XeNhan_TD;
                        cuocGoiCurrent.MOIKHACH_NhanVien = objCG.MOIKHACH_NhanVien;
                        cuocGoiCurrent.MOIKHACH_LenhMoiKhach = objCG.MOIKHACH_LenhMoiKhach;
                        cuocGoiCurrent.XeDenDiem = objCG.XeDenDiem;
                        cuocGoiCurrent.XeDenDiemDonKhach = objCG.XeDenDiemDonKhach;
                        cuocGoiCurrent.XeDenDiemDonKhach_TD = objCG.XeDenDiemDonKhach_TD;
                        //listCuocGoiHienTai[index].x = objCG.MOIKHACH_LenhMoiKhach;
                        ////TinNhan
                        cuocGoiCurrent.GPS_KinhDo = objCG.GPS_KinhDo;
                        cuocGoiCurrent.GPS_ViDo = objCG.GPS_ViDo;
                        cuocGoiCurrent.PhoneNumber = objCG.PhoneNumber;
                        //FastTaxi
                        cuocGoiCurrent.FT_Date = objCG.FT_Date;
                        cuocGoiCurrent.FT_IsFT = objCG.FT_IsFT;
                        cuocGoiCurrent.FT_SendDate = objCG.FT_SendDate;
                        cuocGoiCurrent.FT_Status = objCG.FT_Status;
                        cuocGoiCurrent.BTBG_NoiDungXuLy = objCG.BTBG_NoiDungXuLy;
                        cuocGoiCurrent.G5_Type = objCG.G5_Type;
                        cuocGoiCurrent.LenhLaiXe = objCG.LenhLaiXe;
                        cuocGoiCurrent.XeDungDiem = objCG.XeDungDiem;
                        cuocGoiCurrent.ThoiGianHen = objCG.ThoiGianHen;//*sign
                    }
                }
            }
        }

        /// <summary>
        /// Hàm thực hiện lấy các cuộc gọi các cuộc gọi thay đổi, thêm mới phía điện thoai
        /// </summary>
        private void LoadCuocGoiMoiTongDai_ChuaNhan(ref List<CuocGoi> listCuocGoi_ChuaNhanXuLy, string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi, ref DateTime DateMax)
        {
            hasThemMoi = false;
            hasCapNhat = false;
            // nếu chưa có ds cuộc gọi hiện tại
            if (listCuocGoi_ChuaNhanXuLy == null)
            {
                listCuocGoi_ChuaNhanXuLy = new List<CuocGoi>();
            }
            // cuộc gọi chưa có trong cuộc gọi chưa nhận thì chèn mới
            List<CuocGoi> listCuocGoiMoi;
            //Nếu trạng thái Sử dụng staxi kích hoạt thì lấy những cuốc có cả các cuốc gọi trên staxi;
            if (ThongTinCauHinh.FT_Active)
                listCuocGoiMoi = CuocGoi.G5_TONGDAI_LayCuocGoiMoiTuDienThoai(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc);
            else
                listCuocGoiMoi = CuocGoi.G5_TONGDAI_LayCuocGoiMoiTuDienThoaiNotFT(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc);
            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                hasCapNhat = true;
                for (int i = 0; i < listCuocGoiMoi.Count; i++)
                {
                    CuocGoi objCG = listCuocGoiMoi[i];
                    int index = -1;

                    if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                        DateMax = objCG.ThoiDiemThayDoiDuLieu;//.AddMilliseconds(100);//*sign
                    for (int j = 0; j < listCuocGoi_ChuaNhanXuLy.Count; j++)
                    {
                        if (objCG.IDCuocGoi == listCuocGoi_ChuaNhanXuLy[j].IDCuocGoi) // da co 1 cuoc ton tai
                        {
                            index = j; break;
                        }
                    }

                    //*sign Thêm cuộc gọi mới vào trong lưới điều điện thoại theo thứ tự ưu tiên! Có config trong bản ghi 70
                    if (index == -1) 
                    {
                        hasThemMoi = true;
                        switch (Config_Common.TongDai_SapXepCuocGoi)
                        {
                            case SapXepCuocGoi.SapXepThoiGian://Theo thời gian
                                ChenTheoThoiGianCuocMoi(listCuocGoi_ChuaNhanXuLy, objCG);
                                break;
                            case SapXepCuocGoi.SapXepKieuKhachHang://Loại cổ điển
                                ChenCuocMoiSapXepKieuKhachHang(listCuocGoi_ChuaNhanXuLy, objCG);
                                break;
                            case SapXepCuocGoi.SapXepKieuKhachHangApp://Loại có tham gia của APP khách hàng
                                ChenCuocMoiSapXepKieuKhachHang(listCuocGoi_ChuaNhanXuLy, objCG);
                                break;
                            default:
                                ChenCuocMoiSapXep(listCuocGoi_ChuaNhanXuLy, objCG);
                                break;
                        }
                        if (g_ListCommandTop.Contains(objCG.LenhDienThoai) && Config_Common.TDV_ORDERBYCOMMAND)
                        {
                            G_IndexPriority++;
                        }
                        if(g_HasPopUpNewCall)
                            HienThiPopUpCuocGoiMoi(objCG);//*sign
                    }
                    else //Cập nhật thông tin điện thoại gửi sang cho
                    { 
                        var cuocGoiCurrent = listCuocGoi_ChuaNhanXuLy[index];
                        cuocGoiCurrent.DiaChiTraKhach = objCG.DiaChiTraKhach;
                        cuocGoiCurrent.DiaChiDonKhach = objCG.DiaChiDonKhach;
                        cuocGoiCurrent.SoLanGoi = objCG.SoLanGoi;
                        cuocGoiCurrent.Vung = objCG.Vung;
                        cuocGoiCurrent.LoaiXe = objCG.LoaiXe;
                        cuocGoiCurrent.SoLuong = objCG.SoLuong;
                        cuocGoiCurrent.KieuKhachHangGoiDen = objCG.KieuKhachHangGoiDen;
                        cuocGoiCurrent.IsCuocGiaLap = objCG.IsCuocGiaLap;
                        cuocGoiCurrent.KieuCuocGoi = objCG.KieuCuocGoi;
                        cuocGoiCurrent.LenhDienThoai = objCG.LenhDienThoai;
                        cuocGoiCurrent.GhiChuDienThoai = objCG.GhiChuDienThoai;
                        cuocGoiCurrent.LenhTongDai = objCG.LenhTongDai;
                        cuocGoiCurrent.GhiChuTongDai = objCG.GhiChuTongDai;
                        cuocGoiCurrent.MaNhanVienTongDai = objCG.MaNhanVienTongDai;
                        cuocGoiCurrent.MaNhanVienDienThoai = objCG.MaNhanVienDienThoai;
                        cuocGoiCurrent.ThoiDiemChuyenTongDai = objCG.ThoiDiemChuyenTongDai;
                        cuocGoiCurrent.DanhSachXeDeCu = objCG.DanhSachXeDeCu;
                        cuocGoiCurrent.DanhSachXeDeCu_TD = objCG.DanhSachXeDeCu_TD;
                        cuocGoiCurrent.ThoiDiemCapNhatXeDeCu = objCG.ThoiDiemCapNhatXeDeCu;
                        cuocGoiCurrent.XeNhan = objCG.XeNhan;
                        cuocGoiCurrent.XeNhan_TD = objCG.XeNhan_TD;
                        cuocGoiCurrent.MOIKHACH_NhanVien = objCG.MOIKHACH_NhanVien;
                        cuocGoiCurrent.MOIKHACH_LenhMoiKhach = objCG.MOIKHACH_LenhMoiKhach;
                        cuocGoiCurrent.XeDenDiem = objCG.XeDenDiem;
                        cuocGoiCurrent.XeDenDiemDonKhach = objCG.XeDenDiemDonKhach;
                        cuocGoiCurrent.XeDenDiemDonKhach_TD = objCG.XeDenDiemDonKhach_TD;
                        cuocGoiCurrent.GPS_KinhDo = objCG.GPS_KinhDo;
                        cuocGoiCurrent.GPS_ViDo = objCG.GPS_ViDo;
                        cuocGoiCurrent.PhoneNumber = objCG.PhoneNumber;
                        cuocGoiCurrent.FT_Date = objCG.FT_Date;
                        cuocGoiCurrent.FT_IsFT = objCG.FT_IsFT;
                        cuocGoiCurrent.FT_SendDate = objCG.FT_SendDate;
                        cuocGoiCurrent.FT_Status = objCG.FT_Status;
                        cuocGoiCurrent.BTBG_NoiDungXuLy = objCG.BTBG_NoiDungXuLy;
                        cuocGoiCurrent.LenhLaiXe = objCG.LenhLaiXe;
                        cuocGoiCurrent.XeDungDiem = objCG.XeDungDiem;
                        cuocGoiCurrent.G5_Type = objCG.G5_Type;
                        //*sign
                        cuocGoiCurrent.ThoiGianHen = objCG.ThoiGianHen;
                        cuocGoiCurrent.Long_ChieuID = objCG.Long_ChieuID;
                        cuocGoiCurrent.Long_TuyenID = objCG.Long_TuyenID;
                        cuocGoiCurrent.Long_LoaiXeID = objCG.Long_LoaiXeID;
                        cuocGoiCurrent.Long_GiaTien = objCG.Long_GiaTien;
                        cuocGoiCurrent.Long_Km = objCG.Long_Km;
                        cuocGoiCurrent.Long_ThoiGian = objCG.Long_ThoiGian;

                        if (g_ListCommandTop.Contains(objCG.LenhDienThoai) && Config_Common.TDV_ORDERBYCOMMAND)
                        {
                            if (index >= G_IndexPriority)
                            {
                                listCuocGoi_ChuaNhanXuLy.Insert(0, cuocGoiCurrent);
                                listCuocGoi_ChuaNhanXuLy.RemoveAt(index + 1);
                                G_IndexPriority++;
                                if (index > G_IndexPriority)
                                {
                                    g_RowIndex++;
                                }
                                else if (index < G_IndexPriority)
                                {
                                    g_RowIndex--;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Chèn theo thời gian
        /// </summary>
        private void ChenTheoThoiGianCuocMoi(List<CuocGoi> lscuocgoi, CuocGoi cuocgoi)
        {
            if (lscuocgoi == null) lscuocgoi = new List<CuocGoi>();
            int viTriChen = 0;

            for (int index = 0; index < lscuocgoi.Count; index++)
            {
                if (cuocgoi.ThoiDiemGoi > lscuocgoi[index].ThoiDiemGoi)
                {
                    viTriChen = index - 1;
                    break;
                }
            }

            if (viTriChen < 0) viTriChen = 0;
            if (viTriChen < g_RowIndex) g_RowIndex++;
            lscuocgoi.Insert(viTriChen, cuocgoi);
            if(Config_Common.TongDai_ChuyenCacCuocGoiGanCuocGoiLai)
                ChuyenCacCuocGoiGanCuocGoiLai(lscuocgoi, cuocgoi, viTriChen);
        }

        /// <summary>
        /// Phương pháp cũ
        /// </summary>
        private void ChenCuocMoiSapXepKieuKhachHang(List<CuocGoi> lscuocGoi, CuocGoi cuocgoi)
        {
            int viTriChenCuocMoi = 0;
            //Sắp xếp cuốc mới trên lưới
            if (cuocgoi.FT_IsFT && Config_Common.TongDai_SapXepCuocGoi == SapXepCuocGoi.SapXepKieuKhachHangApp)
            {
                lscuocGoi.Insert(0, cuocgoi);
            }
            else
            {
                if (cuocgoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                {
                    lscuocGoi.Insert(G_IndexKhachVIP, cuocgoi);
                    viTriChenCuocMoi = G_IndexKhachVIP;
                    G_IndexKhachVIP++;
                }
                else if (cuocgoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                {
                    lscuocGoi.Insert(G_IndexKhachVIP + G_IndexKhachVang, cuocgoi);
                    viTriChenCuocMoi = G_IndexKhachVIP + G_IndexKhachVang;
                    G_IndexKhachVang++;
                }
                else if (cuocgoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                {
                    lscuocGoi.Insert(G_IndexKhachVang + G_IndexKhachBac, cuocgoi);
                    viTriChenCuocMoi = G_IndexKhachVang + G_IndexKhachBac;
                    G_IndexKhachBac++;
                }
                else
                {
                    G_IndexCurrentInsert = G_IndexKhachVIP + G_IndexKhachVang + G_IndexKhachBac;
                    lscuocGoi.Insert(G_IndexCurrentInsert, cuocgoi);
                    viTriChenCuocMoi = G_IndexCurrentInsert;
                }
                if (viTriChenCuocMoi < g_RowIndex) 
                    g_RowIndex++;
                // Neu la cuoc goi lai, tim cuoc goi taxi cua cuoc goi do va day len tren gan cuoc goi taxi
                if (cuocgoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                {
                    // tìm đến cuộc gọi taxi của số này, chèn cuộc đó lên đầu.
                    int viTri = -1;
                    for (int k = 0; k < lscuocGoi.Count; k++)
                    {
                        if (lscuocGoi[k].PhoneNumber == cuocgoi.PhoneNumber && lscuocGoi[k].KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            viTri = k;
                            break;
                        }
                    }
                    if (viTri > 1) // loai bo vi tri nay vi se chen ngay vao vi tri so 1
                    {
                        lscuocGoi.Insert(G_IndexCurrentInsert + 1, lscuocGoi[viTri]);
                        lscuocGoi.RemoveAt(viTri + 1);
                    }
                    if (G_IndexCurrentInsert + 1 < g_RowIndex && viTri + 1 > g_RowIndex) 
                        g_RowIndex++;
                }
            }
            //Thực hiện khi là cuốc gọi lại thì kéo cuốc điều của nó lên sát nhau!
            if (Config_Common.TongDai_ChuyenCacCuocGoiGanCuocGoiLai)
                ChuyenCacCuocGoiGanCuocGoiLai(lscuocGoi, cuocgoi, viTriChenCuocMoi);
        }
        private void ChenCuocMoiSapXep(List<CuocGoi> lscuocGoi, CuocGoi cuocgoi)
        {
            lscuocGoi.Insert(0, cuocgoi);
            g_RowIndex++;
            if (Config_Common.TongDai_ChuyenCacCuocGoiGanCuocGoiLai)
                ChuyenCacCuocGoiGanCuocGoiLai(lscuocGoi, cuocgoi, 0);
        }

        /// <summary>
        /// Chuyens the cac cuoc goi gan cuoc goi lai.
        /// </summary>
        /// <param name="listCuocHienTai">The list cuoc hien tai.</param>
        /// <param name="cg">The cg.</param>
        /// <param name="viTri">The vi tri.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  10/09/2015   created
        /// </Modified>
        private void ChuyenCacCuocGoiGanCuocGoiLai(List<CuocGoi> listCuocHienTai, CuocGoi cg, int viTri)
        {
            if (cg.KieuCuocGoi != KieuCuocGoi.GoiLai) return;
            int n = listCuocHienTai.Count;
            int vitricuocgoi = viTri;
            for (int i = viTri + 1; i < n; i++)
            {
                if (listCuocHienTai[i].PhoneNumber == cg.PhoneNumber)
                {
                    var cgCurrent = listCuocHienTai[i];
                    vitricuocgoi++;
                    listCuocHienTai.Insert(vitricuocgoi, cgCurrent);
                    listCuocHienTai.RemoveAt(i + 1);
                    if (g_RowIndex > vitricuocgoi && g_RowIndex < i) g_RowIndex++;
                    if (g_RowIndex == i) g_RowIndex = vitricuocgoi;
                }
            }
        }

        #endregion

        #region ========================Form Events============================

        /// <summary>
        /// Sử dụng background
        /// </summary>
        /// <typeparam name="T">Kiểu trả về</typeparam>
        /// <param name="func">Hàm xử lý trong background</param>
        /// <param name="actionReturn">Hàm chạy khi background xử lý xong</param>
        /// <param name="LogName">Tên để ghi log lỗi</param>
        private void BackgroundFunction<T>(Func<T> func, Action<T> actionReturn, string LogName = "Ghi log Lỗi")
        {
            //return;
            try
            {
                using (var background = new BackgroundWorker())
                {
                    background.DoWork += (s, e) =>
                    {
                        e.Result = func();
                    };
                    background.RunWorkerCompleted += (s, e) =>
                    {
                        if (e.Error != null)
                        {
                            LogError.WriteLogError(LogName, e.Error);
                        }
                        else
                        {
                            try
                            {
                                actionReturn((T)e.Result);

                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError(string.Format("Action.{0}", LogName), ex);
                            }
                        }
                    };
                    background.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(string.Format("BackgroundFunction.{0}", LogName), ex);
            }

        }
        
        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (panelTopHelp.Visible == true)
                panelTopHelp.Visible = false;
            else
                panelTopHelp.Visible = true;
        }

        /// <summary>
        /// Cho grid dev
        /// </summary>
        private void RunChuyenCuocGoi()
        {
            try
            {
                if (grvCuocGoiKetThuc.RowCount > 0)
                {
                    if (g_strUsername.Length <= 0)
                    {
                        CheckIn();
                    }
                    else
                    {
                        var item = grvCuocGoiKetThuc.GetFocusedRow() as CuocGoi;
                        if (item == null) return;
                        string result= new MessageBoxBA().Show("Bạn có muốn chuyển cuộc gọi: " + item.DiaChiDonKhach + " không ?", "Thông báo",MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                        if ( result == "Yes")
                        {
                            CuocGoi.TONGDAI_UpdateCGKetThuc2ChuaGiaiQuyet(item.IDCuocGoi);
                            LoadCacCuocGoiKetThuc(g_VungDuocCapPhep, g_SoDong);
                            g_TabKetThucDuocChon = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("RunChuyenCuocGoi: ", ex);
            }
        }

        #region Tab Search Cuoc Goi
        private void chkVung1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung2.Focus();
            else if (e.KeyCode == Keys.Up)
                txtDiaChi.Focus();
        }

        private void chkVung2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung3.Focus();
            else if (e.KeyCode == Keys.Up)
                chkVung1.Focus();
        }

        private void chkVung3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung4.Focus();
            else if (e.KeyCode == Keys.Up)
                chkVung2.Focus();
        }

        private void chkVung4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSoDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
            else if (e.KeyCode == Keys.Down)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
            else if (e.KeyCode == Keys.Down)
                chkVung1.Focus();
            else if (e.KeyCode == Keys.Up)
                txtSoDT.Focus();
        }

        private void chkVung1_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung2_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung3_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung4_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string soDt = txtSoDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string kenh = "";

            if (chkVung1.Checked) kenh = "1;";
            if (chkVung2.Checked) kenh = kenh + "2;";
            if (chkVung3.Checked) kenh = kenh + "3;";
            if (chkVung4.Checked) kenh = kenh + "4";

            List<CuocGoi> lstCuocGoi = CuocGoi.DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet(kenh, soDt, diaChi);
            grcTimKiemThongTin.DataSource = null;
            grcTimKiemThongTin.DataSource = lstCuocGoi;
        }

        #endregion

        #endregion

        #region ========= Xử lý phím tắt ===========
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F4:
                    CheckOut();
                    return true;
                case Keys.Control | Keys.Down:
                    if (grdCuocKhachMoi.Focused)
                        grdChoGiaiQuyet.Select();
                    else if (grdChoGiaiQuyet.Focused)
                        grdCuocKhachMoi.Select();
                    return true;
                case Keys.Control | Keys.Up:
                    if (grdCuocKhachMoi.Focused)
                        grdChoGiaiQuyet.Select();
                    else if (grdChoGiaiQuyet.Focused)
                        grdCuocKhachMoi.Select();
                    return true;
                case Keys.Alt | Keys.S:
                    if (g_ChuyenTabCuocGoiSearch == true)
                        txtSoDT.Focus();
                    return true;
                case Keys.Alt | Keys.D:
                    if (g_ChuyenTabCuocGoiSearch == true)
                    {
                        txtDiaChi.Focus();
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case (Keys.Alt | Keys.D1):
                case (Keys.Alt | Keys.NumPad1):
                    if (g_ChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung1.Checked) chkVung1.Checked = false;
                        else chkVung1.Checked = true;
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case (Keys.Alt | Keys.D2):
                case (Keys.Alt | Keys.NumPad2):
                    if (g_ChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung2.Checked) chkVung2.Checked = false;
                        else chkVung2.Checked = true;
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case (Keys.Alt | Keys.D3):
                case (Keys.Alt | Keys.NumPad3):
                    if (g_ChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung3.Checked) chkVung3.Checked = false;
                        else chkVung3.Checked = true;
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case (Keys.Alt | Keys.D4):
                case (Keys.Alt | Keys.NumPad4):
                    if (g_ChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung4.Checked) chkVung4.Checked = false;
                        else chkVung4.Checked = true;
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case Keys.Shift | Keys.D1:
                case Keys.Alt | Keys.F1:
                    tabControl_BoDam.SelectedTabPageIndex = 0;
                    grvChoGiaiQuyet.Focus();
                    return true;
                case Keys.Shift | Keys.D2:
                case Keys.Alt | Keys.F2:
                    tabControl_BoDam.SelectedTabPageIndex = 1;
                    grcCuocGoiKetThuc.Focus();
                    return true;
                case Keys.Shift | Keys.D3:
                case Keys.Alt | Keys.F3:
                    tabControl_BoDam.SelectedTabPageIndex = 2;
                    return true;
                case Keys.Shift | Keys.D4:
                case Keys.Alt | Keys.B:
                    tabControl_BoDam.SelectedTabPageIndex = 3;
                    return true;
                case Keys.F1:
                    UpdateCuocGoi_NhanXuLy(true);
                    return true;
                case Keys.F11:
                    if (barButton_ChotCoDD_Mini.Visibility == BarItemVisibility.Always)
                    {
                        barButton_ChotCoDD_Mini.PerformClick();
                    }
                    else {
                        barButton_ChotCoDD.PerformClick();
                    }
                    return true;
                //case Keys.F3://Nhập xe đến điểm
                //    HienThiNhapXeDenDiem();
                //    return true;
                //case Keys.F4://Nhập xe đón
                //    HienThiNhapXeDon();
                //    return true;
                case Keys.F5:
                    UpdateCuocGoi_Nhan5(5);
                    return true;
                case Keys.F10:
                    new frmMemberCard_Search().ShowDialog();
                    return true;
                case Keys.Alt|Keys.F5:
                    btnItemDanhSachLaiXe.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region =========================Grid Event============================

        /// <summary>
        /// Cập nhật địa chỉ thói quen khách hàng
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void UpdateCustomerHabit(CuocGoi cuocGoi)
        {
            try
            {
                if ((Config_Common.DienThoai_UpdateCustomerHabit == 1
                    || (Config_Common.DienThoai_UpdateCustomerHabit == 0
                        && CommonBL.IsPhoneNumber_Cellphone(cuocGoi.PhoneNumber)) //Check là số di động
                    && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                    && cuocGoi.XeNhan != null && cuocGoi.XeNhan != "") // chỉ lưu những cuốc gọi taxi và có xe nhận
                    && cuocGoi.KieuKhachHangGoiDen != KieuKhachHangGoiDen.KhachHangMoiGioi)//Không thêm cuộc gọi môi giới
                {
                    BackgroundFunction(() =>
                    {
                        int days = 1 + (int)cuocGoi.ThoiDiemGoi.DayOfWeek;
                        CustomerHabits.Update(cuocGoi.PhoneNumber, days, cuocGoi.ThoiDiemGoi.TimeOfDay, cuocGoi.DiaChiDonKhach);
                        return true;
                    }, T => { }, "CustomerHabitUpdate");
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhBoDamNEW_V3 CustomerHabitUpdate", ex);
            }
        }

        #region ----------------- Nhập xe nhận -xe đến điểm - xe đón ---------------

        private bool NhapXeNhan(CuocGoi cuocGoiRow, int positionRowSelect, string value)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                // Hiển thị ô nhập  
                frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhan, g_ListSoHieuXe, true, value)
                {
                    G_ListCuocGoi = g_lstDienThoai
                };
                int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 170; // vị trí của dòng đầu tiên cộng thêm.
                if (yRow > grdChoGiaiQuyet.Height)
                {
                    yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                }
                frmInput.Location = new Point(525, yRow);
                if (frmInput.ShowDialog() == DialogResult.OK)
                {
                    if (Config_Common.TongDai_CheckXeViPham)
                    {
                        string xenhan = frmInput.GetGiaTriNhap();
                        string xeViPham = LoiViPham.Inst.GetXeViPham(xenhan, g_TimeServer);
                        if (!string.IsNullOrEmpty(xeViPham))
                        {
                            new MessageBoxBA().Show(this, string.Format("Xe {0} đang vi phạm lỗi", xeViPham), "Thông báo");
                            return false;
                        }
                    }

                    cuocGoiRow.XeNhan = frmInput.GetGiaTriNhap();
                    //cuocGoiRow.XeNhan_TD = frmInput.GetGiaTriNhap_TD();
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                    return true;
                }
            }
            else
            {
                new MessageBoxBA().Show(this, "Cuội gọi lại, không được nhập xe nhận.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
            return false;
        }

        private bool NhapXeDon(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    // Hiển thị ô nhập  
                    using (frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            if (frmInput.GetGiaTriChon() != string.Empty && frmInput.GetGiaTriChon().Split('.').Length > cuocGoiRow.SoLuong)
                            {
                                new MessageBoxBA().Show("Nhập xe đón lớn hơn số lượng xe yêu cầu.", "Cảnh báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                                return false;
                            }
                            cuocGoiRow.XeDon = frmInput.GetGiaTriChon();
                            if (Config_Common.TongDai_CheckXeViPham)
                            {
                                string xenhan = cuocGoiRow.XeDon;
                                string xeViPham = LoiViPham.Inst.GetXeViPham(xenhan, DateTime.Now);
                                if (!string.IsNullOrEmpty(xeViPham))
                                {
                                    new MessageBoxBA().Show(this, string.Format("Xe {0} đang vi phạm lỗi", xeViPham), "Thông báo");
                                    return false;
                                }
                            }
                            if (frmInput.IsKetThuc())
                            {
                                if (frmInput.GetGiaTriNhap().Length > 0)
                                {
                                    cuocGoiRow.XeNhan += "." + frmInput.GetGiaTriNhap();
                                    cuocGoiRow.XeDenDiem += "." + frmInput.GetGiaTriNhap();
                                    cuocGoiRow.XeNhan = string.Join(".", cuocGoiRow.XeNhan.Split('.').Distinct()).TrimEnd('.');
                                    cuocGoiRow.XeDenDiem = string.Join(".", cuocGoiRow.XeDenDiem.Split('.').Distinct()).TrimEnd('.');
                                }
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                                if (cuocGoiRow.XeDon == "000")
                                {
                                    if (cuocGoiRow.XeNhan.Length <= 0)
                                        cuocGoiRow.XeNhan = "000";
                                    else
                                        cuocGoiRow.XeNhan += ".000";
                                }
                                SapXepLaiIndex(cuocGoiRow);
                                g_lstDienThoai.Remove(cuocGoiRow);
                                cuocGoiRow.XeNhan = StringTools.LocBoTrungXe(cuocGoiRow.XeNhan);
                                HienThiTrenLuoi(false, false);
                            }
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, true, value);
                    int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 170; // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > grdChoGiaiQuyet.Height)
                    {
                        yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(525, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        if (frmInput.GetGiaTriNhap() != string.Empty && frmInput.GetGiaTriNhap().Split('.').Length > cuocGoiRow.SoLuong)
                        {
                            new MessageBoxBA().Show("Nhập xe đón lớn hơn số lượng xe yêu cầu.", "Cảnh báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                            return false;
                        }
                        cuocGoiRow.XeDon = frmInput.GetGiaTriNhap();
                        if (Config_Common.TongDai_CheckXeViPham)
                        {
                            string xenhan = cuocGoiRow.XeDon;
                            string xeViPham = LoiViPham.Inst.GetXeViPham(xenhan, DateTime.Now);
                            if (!string.IsNullOrEmpty(xeViPham))
                            {
                                new MessageBoxBA().Show(this, string.Format("Xe {0} đang vi phạm lỗi", xeViPham), "Thông báo");
                                return false;
                            }
                        }
                        if (frmInput.IsKetThuc())
                        {
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                            if (cuocGoiRow.XeDon == "000")
                            {
                                if (cuocGoiRow.XeNhan.Length <= 0)
                                    cuocGoiRow.XeNhan = "000";
                                else
                                    cuocGoiRow.XeNhan += ".000";
                            }
                            else
                            {
                                //Nếu xe đón không thuộc xe nhận thì tự động nhập xe đón vào xe nhận
                                if (!cuocGoiRow.XeNhan.Contains(cuocGoiRow.XeDon))
                                {
                                    if (cuocGoiRow.XeNhan.Length <= 0)
                                        cuocGoiRow.XeNhan = cuocGoiRow.XeDon;
                                    else
                                        cuocGoiRow.XeNhan += "." + cuocGoiRow.XeDon;
                                }
                                cuocGoiRow.XeNhan = StringTools.LocBoTrungXe(cuocGoiRow.XeNhan);
                            }
                            SapXepLaiIndex(cuocGoiRow);
                            g_lstDienThoai.Remove(cuocGoiRow);
                            HienThiTrenLuoi(false, false);
                        }
                        return true;
                    }
                }
            }
            else
            {
                new MessageBoxBA().Show(this, "Cuội gọi lại, không được nhập xe đón.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
            return false;
        }
        private bool NhapXeMK(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    using (frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeMK, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.BTBG_NoiDungXuLy = frmInput.GetGiaTriChon();
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    using (frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeMK, g_ListSoHieuXe, true, value))
                    {
                        frmInput.G_ListCuocGoi = g_lstDienThoai;
                        int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 170;
                        // vị trí của dòng đầu tiên cộng thêm.
                        if (yRow > grdChoGiaiQuyet.Height)
                        {
                            yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                        }
                        frmInput.Location = new Point(525, yRow);
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            string strXeMK = frmInput.GetGiaTriNhap().TrimEnd('.');
                            if (!strXeMK.Equals(cuocGoiRow.BTBG_NoiDungXuLy))
                            {
                                if (Config_Common.ChenXeDenDiemVaoXeNhan == 1)
                                {
                                    if (cuocGoiRow.XeNhan != "")
                                        cuocGoiRow.XeNhan += "." + strXeMK;
                                    else
                                        cuocGoiRow.XeNhan = strXeMK;
                                }
                                cuocGoiRow.BTBG_NoiDungXuLy = StringTools.LocBoTrungXe(strXeMK);

                                cuocGoiRow.XeNhan = StringTools.LocBoTrungXe(cuocGoiRow.XeNhan);
                            }

                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                new MessageBoxBA().Show(this, "Cuội gọi lại, không được nhập xe mời khách.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
            return false;
        }
        private bool NhapXeDenDiem(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    using (frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDenDiem = frmInput.GetGiaTriChon();

                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    using (frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        frmInput.G_ListCuocGoi = g_lstDienThoai;
                        int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 170;
                        // vị trí của dòng đầu tiên cộng thêm.
                        if (yRow > grdChoGiaiQuyet.Height)
                        {
                            yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                        }
                        frmInput.Location = new Point(525, yRow);
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            string strXeMK = frmInput.GetGiaTriNhap().TrimEnd('.');
                            if (!strXeMK.Equals(cuocGoiRow.XeDenDiem))
                            {
                                if (Config_Common.ChenXeDenDiemVaoXeNhan == 1)
                                {
                                    if (cuocGoiRow.XeNhan != "")
                                        cuocGoiRow.XeNhan += "." + strXeMK;
                                    else
                                        cuocGoiRow.XeNhan = strXeMK;
                                }
                                if (Config_Common.ChenXeDenDiemVaoXeMK)
                                {
                                    if (cuocGoiRow.BTBG_NoiDungXuLy != "")
                                        cuocGoiRow.BTBG_NoiDungXuLy += "." + strXeMK;
                                    else
                                        cuocGoiRow.BTBG_NoiDungXuLy = strXeMK;
                                    cuocGoiRow.BTBG_NoiDungXuLy = StringTools.LocBoTrungXe(cuocGoiRow.BTBG_NoiDungXuLy);
                                }
                                cuocGoiRow.XeDenDiem = StringTools.LocBoTrungXe(strXeMK);

                                cuocGoiRow.XeNhan = StringTools.LocBoTrungXe(cuocGoiRow.XeNhan);
                            }

                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                new MessageBoxBA().Show(this, "Cuội gọi lại, không được nhập xe đến điểm.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
            return false;
        }

        #endregion

        #region ----------------- Hàm xử lý trên lưới ------------------------------
        /// <summary>
        /// Tìm kiếm xe trên lưới điều.
        /// </summary>
        /// <param name="Xe">The xe.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  08/09/2015   created
        /// </Modified>
        private void TimKiemXeTrenLuoi(string Xe)
        {
            if (!string.IsNullOrEmpty(Xe) && Xe.Trim() != "" && g_lstDienThoai != null && g_lstDienThoai.Count > 0)
            {
                var index = g_lstDienThoai.FindIndex(p => p.XeNhan == Xe || p.XeNhan.Split('.').Any(pi => pi.Trim() == Xe));
                if (index >= 0)
                {
                    grvChoGiaiQuyet.FocusedRowHandle = index;
                }
                else
                {
                    new MessageBoxBA().Show("Không tìm thấy");
                }
            }
        }

        private void HienThiBanDo(CuocGoi cuocGoiRow, bool IsReActive)
        {
            if (g_frmBanDo == null)
            {
                g_frmBanDo = new frmHienThiBanDo_Mini(cuocGoiRow);
                g_frmBanDo.Show();
            }
            else
            {
                if (g_frmBanDo.Visible == true)
                {
                    if (cuocGoiRow == null)
                    {
                        g_frmBanDo.Close();
                    }
                    else
                    {
                        g_frmBanDo.RefreshForm(cuocGoiRow);
                    }
                }
                else
                {
                    if (IsReActive)
                    {
                        g_frmBanDo.Visible = true;
                        g_frmBanDo.Show();
                    }
                }
            }
        }

        private void SendSMS_CuocDuongDai(CuocGoi cuocGoi, string xeGuiSMS)
        {
            if (Config_Common.App_SendSMS_Customer)
            {
                int GiaPhuTroi_Km = 0;
                string GiaPhuTroi_Gio = "";
                int LoaiXeID = 0;
                Services.ServiceApp.TcpOPDirection chieu = Services.ServiceApp.TcpOPDirection.MotChieu;
                if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachDuongDai)
                {
                    int.TryParse(cuocGoi.Long_LoaiXeID, out LoaiXeID);
                    #region Nếu điều loại xe khác thì lấy lại thông tin giá để gửi sms
                    if (CommonBL.DicObjecXe.ContainsKey(xeGuiSMS))
                    {
                        var objXe = CommonBL.DicObjecXe[xeGuiSMS];
                        if (LoaiXeID != objXe.FK_LoaiXeID)
                        {
                            LoaiXeID = objXe.FK_LoaiXeID;
                            DataTable data = new BangGiaCuoc().LayGiaTheoTuyen(cuocGoi.Long_TuyenID, cuocGoi.Long_ChieuID, LoaiXeID, 1);
                            if (data.Rows.Count > 0)
                            {
                                cuocGoi.Long_GiaTien = int.Parse(data.Rows[0]["GiaTien"].ToString());
                                cuocGoi.Long_Km = int.Parse(data.Rows[0]["Km"].ToString());
                                cuocGoi.Long_ThoiGian = int.Parse(data.Rows[0]["ThoiGian"].ToString());
                            }
                        }
                    }

                    #endregion

                    VuotGioQuyDinh temp = CommonBL.ListDanhMucVuotGio.Find(a => a.FK_LoaiXeID == LoaiXeID);
                    if (temp != null)
                    {
                        if (cuocGoi.Long_ChieuID == (int)Services.ServiceApp.TcpOPDirection.HaiChieu)
                        {
                            int.TryParse(temp.GiaDinhMucVuot1KmHaiChieu.ToString(), out GiaPhuTroi_Km);
                            chieu = Services.ServiceApp.TcpOPDirection.HaiChieu;
                            GiaPhuTroi_Gio = temp.GiaDinhMucVuot1GioHaiChieu.ToString();
                        }
                        else
                        {
                            int.TryParse(temp.GiaDinhMucVuot1KmMotChieu.ToString(), out GiaPhuTroi_Km);
                        }
                    }
                }

                WCFServicesApp.SendSMS_ReceiveCatchedUser(cuocGoi.BookId, cuocGoi.PhoneNumber, xeGuiSMS, cuocGoi.Long_GiaTien, cuocGoi.LoaiCuocKhach, GiaPhuTroi_Km, cuocGoi.Long_Km, chieu, GiaPhuTroi_Gio);
                    
            }
        }

        /// <summary>
        /// - Nhan vao vi tri cua mot dong trong list cac cuoc goi dang hien hanh
        /// - lay gia tri len form 
        /// - nhap vao truyen di
        /// </summary>
        private void NhapDuLieuVaoTruyenDi(CuocGoi cuocGoi)
        {
            if (tabControl_BoDam.SelectedTabPage == tabChoGiaiQuyet)
            {
                string xeNhan_Old = cuocGoi.XeNhan;
                string xeDon_Old = cuocGoi.XeDon;
                string xeDenDiem_Old = cuocGoi.XeDenDiem;
                string lenhTongDai_old = cuocGoi.LenhTongDai;
                var trangThaiCuocGoi_old = cuocGoi.TrangThaiCuocGoi;
                frmBodamInputData_V4 frm = new frmBodamInputData_V4(g_TimeServer, cuocGoi, g_ListSoHieuXe, false, g_SoLuongDangNhapCS, g_IsThoatDuoc999)
                {
                    G_ListCuocGoi = g_lstDienThoai
                };
                DialogResult ketQua = frm.ShowDialog(this);
                if (ketQua == DialogResult.OK)
                {
                    cuocGoi = frm.GetCuocGoi; 
                    cuocGoi.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;

                    #region XU LY CUOC GOI KHONG XE LẦN 1
                    //Xử lý cuộc gọi không xe, sau 3 phút, hoặc số phút theo cấu hình thì sẽ hiển thị lại cuộc gọi không xe!
                    if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1)
                    {
                        cuocGoi.CamOn_ThoiDiemChen = g_TimeServer;
                        if (!g_lstCuocGoiKhongXe.Contains(cuocGoi))
                            g_lstCuocGoiKhongXe.Add(cuocGoi);
                        SapXepLaiIndex(cuocGoi);
                        g_lstDienThoai.Remove(cuocGoi);
                        HienThiTrenLuoi(false, false);
                    }
                    #endregion

                    //*command
                    bool chuyenMK = CommonBL.Commands.Any(a=> a.FunctionUsing==2&&!string.IsNullOrEmpty(cuocGoi.LenhTongDai)
                                            && a.Command == cuocGoi.LenhTongDai && a.IsSend_CallCust == true);
                    if (chuyenMK)
                    {
                        cuocGoi.ChuyenMK = true;
                    }

                    var change = new CuocGoi.CheckChange();
                    change.DiaChiDon = !frm.IsChangeDiaChiDon;
                    change.DiaChiTra = !frm.IsChangeDiaChiTra;

                    #region Xử lý gửi lên App KH và Lái xe
                    
                    if (cuocGoi.BookId != Guid.Empty && cuocGoi.G5_StepLast == Enum_G5_Step.SourceCancel_Customer)
                    {
                        if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                        {
                            if (xeNhan_Old != cuocGoi.XeNhan)
                                WCFServicesAppXHD.SendOperatorDispatched(cuocGoi.BookId, cuocGoi.XeNhan);
                            else if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan
                                    || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiTruot)
                            {
                                WCFServicesAppXHD.SendOperatorDispatched(cuocGoi.BookId, "");
                            }
                        }
                        else
                        {
                            if (xeNhan_Old != cuocGoi.XeNhan)
                                WCFServicesApp.SendOperatorDispatched(cuocGoi.BookId, cuocGoi.XeNhan);
                            else if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan
                                    || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiTruot)
                            {
                                WCFServicesApp.SendOperatorDispatched(cuocGoi.BookId, "");
                            }
                        }
                    }

                    #region Send SMS App
                    if (Config_Common.App_SendSMS_Customer && cuocGoi.XeDon != "000")
                    {
                        if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                            && cuocGoi.XeNhan.Length > 0 && cuocGoi.SendSMS_Status == null)
                        {
                            WCFServicesApp.SendSMS_ReceiveCarInfo(cuocGoi.BookId, cuocGoi.PhoneNumber, cuocGoi.XeNhan, cuocGoi.LoaiCuocKhach, "");
                            cuocGoi.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveCarInfo;
                        }
                        if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                            && (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan
                                || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiTruot))
                        {
                            if (cuocGoi.XeNhan.Length > 0)
                            {
                                WCFServicesApp.SendSMS_ReceiveDriverCancel(cuocGoi.BookId, cuocGoi.PhoneNumber, cuocGoi.XeNhan, cuocGoi.LoaiCuocKhach);
                                cuocGoi.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveDriverCancel;
                            }
                            else
                            {
                                if (Config_Common.DTV_SMS_DAXINLOI_KHACH == 1)
                                {
                                    WCFServicesApp.SendSMS_ReceiveNoCar(cuocGoi.BookId, cuocGoi.PhoneNumber, cuocGoi.LoaiCuocKhach);
                                    cuocGoi.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveNoCar;
                                }
                            }
                        }
                    }

                    if (Config_Common.SMS_CuocDuongDai_Dam_LaiXe_Send == Enum_SendSMSCuocDuongDai_Dam.NhapXeDon && cuocGoi.XeDon != "000"
                        && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                        && cuocGoi.XeNhan.Length > 0 && cuocGoi.XeDon.Length > 0
                        && cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach
                        && (cuocGoi.SendSMS_Status == null || cuocGoi.SendSMS_Status == Enum_G5_PMDH_SMS_Status.ReceiveCarInfo))
                    {
                        SendSMS_CuocDuongDai(cuocGoi, cuocGoi.XeDon);
                        cuocGoi.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveCatchedUser;
                    }
                    else if (!string.IsNullOrEmpty(cuocGoi.XeDenDiem) && Config_Common.SMS_CuocDuongDai_Dam_LaiXe_Send == Enum_SendSMSCuocDuongDai_Dam.NhapXeDenDiem && cuocGoi.XeDenDiem != "000" && xeDenDiem_Old != cuocGoi.XeDenDiem)
                        SendSMS_CuocDuongDai(cuocGoi, cuocGoi.XeDenDiem);
                    #endregion

                    #region SMS VINA
                    if (Config_Common.SMS_TaxiVina)
                    {
                        if (Config_Common.SMS_TaxiVina_ReceiveCarInfo && cuocGoi.XeDon != "000")
                        {
                            //if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                            //&& cuocGoi.XeDenDiem.Length > 0 && cuocGoi.SendSMS_Status == null)
                            //{
                            //    string xenhanViewcar = cuocGoi.XeDenDiem;
                            //    if (cuocGoi.XeDenDiem.Contains("."))
                            //    {
                            //        string[] arXeNhan = cuocGoi.XeDenDiem.Split('.');
                            //        xenhanViewcar = arXeNhan[0];
                            //    }
                            //    WCF_SMSVina.Vina_SendSms_VinaTaxi_ViewCar(cuocGoi.PhoneNumber, xenhanViewcar);
                            //    cuocGoi.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveCarInfo;
                            //}
                            //else 
                            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoi.XeDon.Length > 0
                            && cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach && cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                            {
                                WCF_SMSVina.Vina_SendSms_VinaTaxi_ThankCustomer(cuocGoi.PhoneNumber, cuocGoi.XeDon);
                            }
                        }
                    }
                    #endregion

                    #endregion

                    if (!CuocGoi.G5_TONGDAI_UpdateThongTinCuocGoi(cuocGoi, change))
                    {
                        MessageBoxBA msgDialog = new MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    }
                    else
                    {
                        #region FastTaxi
                        // là cuốc fastTaxi
                        if (cuocGoi.FT_IsFT)
                        {
                            //#region SendToMasterSignedCar - Nhập xe nhận
                            ////Xe nhận thay đổi thì xử lý gửi
                            //if (xeNhan_Old != null && cuocGoi.XeNhan != xeNhan_Old)
                            //{
                            //    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.NhapXeNhan);
                            //}
                            //#endregion

                            //#region SendToMasterSignedCar - Nhập xe đón
                            ////Xe đón thay đổi thì xử lý gửi
                            //if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach &&
                            //    cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                            //{
                            //    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.NhapXeDon);
                            //}
                            //#endregion

                            //#region Thay đổi có xe đón
                            //if (xeDon_Old != null && cuocGoi.XeDon != xeDon_Old)
                            //{
                            //    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.NhapXeDon);
                            //}
                            //#endregion

                            //#region SendToMasterCatchingCar - Mời khách
                            ////Mời khách
                            //if (lenhTongDai_old.ToLower() != LENH_1_MOIKHACH.ToLower() 
                            //    && cuocGoi.LenhTongDai.ToLower() == LENH_1_MOIKHACH.ToLower() 
                            //    &&cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.BoDam)
                            //{
                            //    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.MoiKhach);
                            //}

                            //#endregion

                            //#region SendToMasterBookingFail - Không xe
                            //if ((lenhTongDai_old.ToLower() != LENH_3_KHONGXE.ToLower() || trangThaiCuocGoi_old != TrangThaiCuocGoiTaxi.CuocGoiKhongXe) 
                            //     && (cuocGoi.LenhTongDai.ToLower() == LENH_3_KHONGXE.ToLower() || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe))
                            //{
                            //    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.KhongXe);
                            //}
                            //#endregion

                            //#region SendToMasterBookingFail -Trượt
                            //// Trượt
                            //if ((lenhTongDai_old != "trượt" || trangThaiCuocGoi_old != TrangThaiCuocGoiTaxi.CuocGoiTruot) &&
                            //    (cuocGoi.LenhTongDai == "trượt" || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiTruot))
                            //{
                            //    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.Truot);
                            //}
                            //#endregion

                            //#region SendToMasterBookingFail -Hoãn
                            //// Hoãn 
                            //if ((lenhTongDai_old.ToLower() != "hoãn".ToLower() || trangThaiCuocGoi_old != TrangThaiCuocGoiTaxi.CuocGoiHoan) &&
                            //    (cuocGoi.LenhTongDai.ToLower() == "hoãn".ToLower() || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan))
                            //{
                            //    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.Hoan);
                            //}
                            //#endregion
                        }
                        #endregion

                        #region Bắn cuốc App xuống cho LX
                        if (Config_Common.App_SendRadioTrip && xeDenDiem_Old != cuocGoi.XeDenDiem && cuocGoi.XeDenDiem != "")
                        {
                            cuocGoi.ShowPhoneAppDriver = true;
                            //if (cuocGoi.GPS_KinhDo == 0)
                            //{
                            //    cuocGoi.GPS_KinhDo = ThongTinCauHinh.GPS_KinhDo;
                            //    cuocGoi.GPS_ViDo = ThongTinCauHinh.GPS_ViDo;
                            //}
                            if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                                WCFServicesAppXHD.SendInitTrip(cuocGoi);
                            else
                                WCFServicesApp.SendInitTrip(cuocGoi);
                        }
                        #endregion
                        if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            
                            UpdateCustomerHabit(cuocGoi);
                            RemoveCuocGoi(cuocGoi);
                            HienThiTrenLuoi(false, false); // Refresh                            
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoi, true);
                            HienThiTrenLuoi(true, false); // Refresh
                            //Nếu cuộc gọi có thay đổi xe nhận thì cập nhật thông tin cuộc gọi vào MEM
                            //if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && xeNhan_Old != cuocGoi.XeNhan)
                            //{
                            //    if (!bwSync_AddCuocGoi.IsBusy)
                            //    {
                            //        bwSync_AddCuocGoi.RunWorkerAsync(cuocGoi);
                            //    }
                            //}
                        }
                    }

                }
                else if (ketQua == DialogResult.Ignore) // chuyeern vung
                {
                    RemoveCuocGoi(cuocGoi);
                    HienThiTrenLuoi(false, false); // Refresh
                }
            }
            else
            {
                frmBodamInputData_V4 frm = new frmBodamInputData_V4(g_TimeServer, cuocGoi, g_ListSoHieuXe, true, g_SoLuongDangNhapCS, g_IsThoatDuoc999)
                {
                    G_ListCuocGoi = g_lstDienThoai
                };
                DialogResult ketQua = frm.ShowDialog(this);
                if (ketQua == DialogResult.OK)
                {
                    cuocGoi = frm.GetCuocGoi;
                    cuocGoi.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                    //*command
                    bool chuyenMK = CommonBL.Commands.Any(a =>a.FunctionUsing == 2 && !string.IsNullOrEmpty(cuocGoi.LenhTongDai) 
                                            && a.Command == cuocGoi.LenhTongDai && a.IsSend_CallCust==true);
                    if (chuyenMK)
                    {
                        cuocGoi.ChuyenMK = true;
                    }
                    
                    if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi_KETTHUC(cuocGoi))
                    {
                        MessageBoxBA msgDialog = new MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi(ref g_lstCuocGoiKetThuc, cuocGoi, true);
                        HienThiTrenLuoi_KETTHUC(true, false); // Refresh
                    }
                }
            }
        }

        private void RemoveCuocGoi(CuocGoi cuocGoi)
        {
            SapXepLaiIndex(cuocGoi);
            g_lstDienThoai.Remove(cuocGoi);
        }

        private void RemoveCuocGoi_ChuaNhan(CuocGoi cuocGoi)
        {
            g_lstDienThoai_New.Remove(cuocGoi);
        }

        private void SapXepLaiIndex(CuocGoi cuocGoi)
        {
            if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                G_IndexKhachVIP--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                G_IndexKhachVang--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                G_IndexKhachBac--;
            else if (g_ListCommandTop.Contains(cuocGoi.LenhDienThoai) && Config_Common.TDV_ORDERBYCOMMAND)
            {
                G_IndexPriority--;
            }
        }


        /// <summary>
        /// hàm cập nhật dữ liệu cuộc gọi thay đổi vào dữ liệu của dsCuocGoi
        /// Nếu isDuLieuCuaTongDai = True (dữ liệu phía tổng dài thay đổi, nhap trên form và cập nhật luôn)
        /// Ngược lại :
        ///     cập nhật dữ liệu phía điện thoại thay đổi
        /// </summary>
        private void TimVaCapNhatCuocGoi(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi, bool isDuLieuCuaTongDai)
        {
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                int index = -1;
                for (int i = 0; i < listCuocGoiHienTai.Count; i++)
                {
                    if (listCuocGoiHienTai[i].IDCuocGoi == cuocGoi.IDCuocGoi)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                {
                    if (isDuLieuCuaTongDai)
                    {
                        var cuocGoiCurrent = listCuocGoiHienTai[index];
                        cuocGoiCurrent.TrangThaiCuocGoi = cuocGoi.TrangThaiCuocGoi;
                        cuocGoiCurrent.LenhTongDai = cuocGoi.LenhTongDai;
                        cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                        cuocGoiCurrent.GhiChuTongDai = cuocGoi.GhiChuTongDai;
                        cuocGoiCurrent.MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai == listCuocGoiHienTai[index].MaNhanVienTongDai ? listCuocGoiHienTai[index].MaNhanVienTongDai : cuocGoi.MaNhanVienTongDai;
                        cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                        cuocGoiCurrent.XeNhan_TD = cuocGoi.XeNhan_TD;
                        cuocGoiCurrent.XeDon = cuocGoi.XeDon;
                        cuocGoiCurrent.DiaChiTraKhach = cuocGoi.DiaChiTraKhach;
                        cuocGoiCurrent.ThoiGianDieuXe = cuocGoi.ThoiGianDieuXe;
                        cuocGoiCurrent.ThoiGianDonKhach = cuocGoi.ThoiGianDonKhach;
                        cuocGoiCurrent.MOIKHACH_LenhMoiKhach = cuocGoi.MOIKHACH_LenhMoiKhach;
                        cuocGoiCurrent.MOIKHACH_NhanVien = cuocGoi.MOIKHACH_NhanVien;
                        cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;
                        cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                        cuocGoiCurrent.FT_Date = cuocGoi.FT_Date;
                        cuocGoiCurrent.FT_SendDate = cuocGoi.FT_SendDate;
                        cuocGoiCurrent.FT_IsFT = cuocGoi.FT_IsFT;
                        cuocGoiCurrent.FT_Status = cuocGoi.FT_Status;
                        //G5
                        cuocGoiCurrent.BookId = cuocGoi.BookId;
                        cuocGoiCurrent.LenhLaiXe = cuocGoi.LenhLaiXe;
                        cuocGoiCurrent.GhiChuLaiXe = cuocGoi.GhiChuLaiXe;
                        cuocGoiCurrent.G5_Type = cuocGoi.G5_Type;
                        cuocGoiCurrent.XeDungDiem = cuocGoi.XeDungDiem;
                        cuocGoiCurrent.BTBG_NoiDungXuLy = cuocGoi.BTBG_NoiDungXuLy;
                        //Trạng thái timeout
                        cuocGoiCurrent.FT_AllowCall = cuocGoi.FT_AllowCall;
                        cuocGoiCurrent.FT_SendDate = cuocGoi.FT_SendDate;
                    }
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin vào db.
        /// </summary>
        private bool UpdateThongTinCuocGoi(CuocGoi cuocGoi, CuocGoi.CheckChange checkChange)
        {
            if (Config_Common.TongDai_BanCo)
            {
                return CuocGoi.TONGDAI_UpdateThongTinCuocGoi_BanCo(cuocGoi);
            }
            else
            {
                return CuocGoi.G5_TONGDAI_UpdateThongTinCuocGoi(cuocGoi, checkChange);
            }

        }
        #endregion

        private void FocusRowOnGridView(DateTime pTime)
        {
            try
            {
                int i = 0;
                foreach (var item in grvChoGiaiQuyet.DataSource.CastToList())
                {
                    if (((CuocGoi)item).ThoiGianHen == pTime)
                    {
                        grvChoGiaiQuyet.FocusedRowHandle = i;
                    }
                    i++;
                }
            }
            catch
            {

            }
        }
        #endregion

        #region =========================Timer=================================

        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();
            g_TimerCapturePhone = new Timer();
            g_TimerCapturePhone.Interval = TimerLength;
            g_TimerCapturePhone.Tick += TimerCapturePhone_Tick;
            g_TimeServer = DieuHanhTaxi.GetTimeServer();
            g_TimerCapturePhone.Start();
        }
        /// <summary>
        /// Điều kiện gôp line
        /// </summary>
        private bool DieuKienGopLai(TimeSpan now, TimeSpan start, TimeSpan end)
        {
            if (Config_Common.GopLine) return true;
            if (start <= end) //Nếu thời điểm bắt đầu lớn hơn kết thúc ví dụ: BD-05:00:00 và KT-23:00:00
                return ThongTinCauHinh.GopKenh_TrangThai && start <= now && now <= end;
            return ThongTinCauHinh.GopKenh_TrangThai && !(start > now && now > end); // Ngược lại ví dụ: BD-23:00:00 và KT-05:00:00 thì không lấy thời điểm từ KT-BD tức là Khoảng (05:00:00-23:00:00) là không lấy
        }
        /// <summary>
        /// Nhan cac cuoc goi moi 
        /// Nhan thong tin moi chuyen ve
        ///   - 1 giay lay cuoc goi moi chuyen sang
        ///   - 3 giay xu ly cuoc goi ket thuc
        /// </summary>
        private void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                g_TimeServer = CommonBL.GetTimeServer();
                if (Config_Common.DienThoai_DieuTuDong && !backGroundPingApp.IsBusy)
                    backGroundPingApp.RunWorkerAsync();

                if (!string.IsNullOrEmpty(G_KenhGop))
                {
                    if (DieuKienGopLai(g_TimeServer.TimeOfDay, ThongTinCauHinh.GopKenh_GioBD, ThongTinCauHinh.GopKenh_GioKT))
                    {
                        g_VungDuocCapPhep = G_KenhGop;
                    }
                    else
                    {
                        g_VungDuocCapPhep = g_VungsDuocCapPhep_Temp;
                    }
                }

                DateTime DateMax = DateTime.MinValue;
                bool hasThemMoi = false;
                bool hasCapNhat = false;
                if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)//*sign
                {
                    LoadCuocGoiMoiTongDai_ChuaNhan(ref g_lstDienThoai_New, g_VungDuocCapPhep, g_ThoiDiemLayDuLieuTruoc_ChuaNhan, ref hasCapNhat, ref hasThemMoi, ref DateMax);

                    if (hasCapNhat)
                    {
                        HienThiTrenLuoi_ChuaNhan(true, hasThemMoi);
                        g_ThoiDiemLayDuLieuTruoc_ChuaNhan = DateMax;
                    }
                }
                else
                {
                    LoadCuocGoiMoiTongDai_ChuaNhan(ref g_lstDienThoai, g_VungDuocCapPhep, g_ThoiDiemLayDuLieuTruoc_ChuaNhan, ref hasCapNhat, ref hasThemMoi, ref DateMax);

                    if (hasCapNhat)//*sign
                    {
                        HienThiTrenLuoi(true, hasThemMoi);
                        g_ThoiDiemLayDuLieuTruoc_ChuaNhan = DateMax;
                    }
                }
                hasThemMoi = false;
                hasCapNhat = false;
                if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                {
                    LoadCuocGoiMoiTongDai_DaNhan(ref g_lstDienThoai, g_VungDuocCapPhep, g_ThoiDiemLayDuLieuTruoc, ref hasCapNhat, ref hasThemMoi, ref DateMax);
                    if (hasCapNhat) // co thay doilieu du  moi cap nhat cuoc goi
                    {
                        HienThiTrenLuoi(true, hasThemMoi);
                        g_ThoiDiemLayDuLieuTruoc = DateMax;
                    }
                }

                g_TimeStep++;
                g_TimerMsg++;
                g_TimeStepSau1Phut++;
                if (g_TimeStep >= 3)  // 3 giay thuc hien mot lan
                {
                    if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                    {
                        CapNhatCuocGoiDaKetThucByDienThoai_ChuaNhan(ref g_lstDienThoai_New, g_VungDuocCapPhep, ref hasCapNhat);
                        if (hasCapNhat)
                        {
                            HienThiTrenLuoi_ChuaNhan(false, false);
                            hasCapNhat = false;
                        }
                    }

                    CapNhatCuocGoiDaKetThucByDienThoai(ref g_lstDienThoai, g_VungDuocCapPhep, ref hasCapNhat,hasThemMoi);
                    if (hasCapNhat)
                    {
                        HienThiTrenLuoi(false, false);
                    }
                    g_TimeStep = 0;
                }
                g_Timer5second++;
                if (g_Timer5second >= 5)
                {
                    #region Validate Login
                    if (bw_ValidateLogin != null && !bw_ValidateLogin.IsBusy && Config_Common.ValidateLogin && ThongTinDangNhap.USER_ID != "")
                    {
                        bw_ValidateLogin.RunWorkerAsync();
                    }
                    #endregion

                    g_Timer5second = 0;
                }
                if (g_TimerMsg >= 10)  // 10 giay thuc hien mot lan
                {
                    ServiceVersion.CheckVersion();
                    TimerMessage();
                    Config_Common.LoadConfigCommonByLastUpdate();
                    g_TimerMsg = 0;
                    XuLyCuocGoiXinLoiKhach();
                    
                }
                timerCheckVer++;

                //1 phút check version 1 lần
                if (timerCheckVer >= 60)
                {
                    LoadNewUpdateVer();
                }
                if (g_TimeStepSau1Phut > 60)
                {
                    //  CapNhatCuocGoiChuaXuLySau1Phut(ref g_lstDienThoai);
                    g_TimeStepSau1Phut = 0;
                }
                if (g_TabKetThucDuocChon)
                {
                    LoadCacCuocGoiKetThuc(g_VungDuocCapPhep, g_SoDong);
                    g_TabKetThucDuocChon = false;
                }

                #region== Cảnh báo cuốc sân bay trước 60 phút ===
                g_TimeSanbay++;
                if (g_TimeSanbay >= 15)
                {
                    CanhBaoCuocSanBayTrenLuoi();                    
                }
                #endregion

                #region Hiển thị cuốc điều app theo cấu hình
                if (Config_Common.CoDieuApp && g_TabCuocDieuAppDuocChon)
                {
                    SearchCuocDieuApp();
                    g_TabCuocDieuAppDuocChon = false;
                }
                #endregion

                ViewTrangThaiCacCuocGoiO_StatusBar();
                BlinkStatus(g_Status);
                if (g_Status == 1) g_Status = 2;
                else g_Status = 1;
            }
            catch (Exception ex)
            {
                LoadAllCuocGoiHienTai(g_VungDuocCapPhep);
                HienThiTrenLuoi(true, true);
                LogError.WriteLogError("TimerCapturePhone_Tick", ex);
            }
        }

        #region Validate Login
        private BackgroundWorker bw_ValidateLogin;
        private void InitValidateLogin()
        {
            bw_ValidateLogin = new BackgroundWorker();
            bw_ValidateLogin.DoWork += bw_ValidateLogin_DoWork;
        }

        private void bw_ValidateLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, QuanTriCauHinh.IpAddress))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        new MessageBoxBA().Show(string.Format("Tài khoản {0} đã đăng nhập ở máy tính khác", g_strUsername));
                        CheckOut();
                    }));
                }
                else if (!ThongTinDangNhap.IsUserPostionTrust(g_strUsername, QuanTriCauHinh.IpAddress))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        CheckOut("Bạn vừa bị đăng xuất cưỡng chế từ quản lý");
                    }));
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bw_ValidateLogin_DoWork", ex);
            }
        }
        #endregion

        private void XuLyCuocGoiXinLoiKhach()
        {            
            //Nếu so cuộc gọi xin lỗi khách lần 1 thì sau x phút sẽ đẩy lại.
            if (g_lstCuocGoiKhongXe != null && g_lstCuocGoiKhongXe.Count > 0)
            {
                int i = -1; bool hasXoa = false;
                foreach (CuocGoi cuocGoi in g_lstCuocGoiKhongXe)
                {
                    i++;
                    if ((cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1) && (g_TimeServer - cuocGoi.ThoiDiemThayDoiDuLieu).Seconds >= g_SoGiayGioiHanKhongXe) // thông số cấu hình
                    {
                        // Kiểm tra cuộc gọi đã tồn tại chưa, nếu rồi thì không thêm vào
                        bool bFind = false;
                        foreach (CuocGoi item in g_lstDienThoai)
                        {
                            if (cuocGoi.IDCuocGoi == item.IDCuocGoi)
                            {
                                bFind = true;
                                break;
                            }
                        }
                        if (!bFind)
                        {
                            g_lstDienThoai.Insert(0, cuocGoi);
                            HienThiTrenLuoi(true, true);
                            hasXoa = true;
                            break;
                        }
                    }
                }
                if (hasXoa)
                    g_lstCuocGoiKhongXe.RemoveAt(i);
            }            
        }

        private void CanhBaoCuocSanBayTrenLuoi() //*sign
        {

            try
            {
                if (g_frmCanhBaoSanBay == null) return;
                List<CanhBaoCuocSanBay> lstCanhBaoSanBay = new List<CanhBaoCuocSanBay>();
                IEnumerable<CuocGoi> lstSanBay = g_lstDienThoai.Where(x => x.Vung == 4);
                IEnumerable<CuocGoi> lstCanhBao15 = lstSanBay.Where(x => (x.ThoiGianHen - g_TimeServer).TotalMinutes <= 15 && x.SanBay_DuongDai == "1" && !x.Is15 && (g_TimeServer - x.ThoiGianHen).TotalMinutes <= 15);//&& string.IsNullOrEmpty(x.XeNhan)
                bool has15 = lstCanhBao15.ToList().Count > 0;
                if (has15)
                {
                        g_TimeSanbay = 0;
                    foreach (var item in lstCanhBao15)
                    {
                        CanhBaoCuocSanBay canhBao = new CanhBaoCuocSanBay();
                        canhBao.ThoiGianNhan = item.ThoiGianHen;
                        canhBao.NoiDung = "SB[Kiểm tra xe 15 phút]";
                        canhBao.SoDienThoai = item.PhoneNumber;
                        canhBao.DiaChiDon = item.DiaChiDonKhach;
                        canhBao.IsDisplay = true;
                        lstCanhBaoSanBay.Add(canhBao);
                    }
                    g_frmCanhBaoSanBay.SetCanhBao(lstCanhBaoSanBay);
                }

                IEnumerable<CuocGoi> lstCanhBao60 = g_lstDienThoai.Where(x => (x.ThoiGianHen - g_TimeServer).TotalMinutes <= 60 && (x.ThoiGianHen - g_TimeServer).TotalMinutes >= 15
                                                && string.IsNullOrEmpty(x.XeNhan)
                                                && !x.Is60);
                bool has60 = lstCanhBao60.ToList().Count > 0;
                if (has60)
                {
                    g_TimeSanbay = 0;
                    foreach (var item in lstCanhBao60)
                    {
                        CanhBaoCuocSanBay canhBao = new CanhBaoCuocSanBay();
                        canhBao.ThoiGianNhan = item.ThoiGianHen;
                        canhBao.NoiDung = "SB[Điều xe 60 phút]";
                        canhBao.SoDienThoai = item.PhoneNumber;
                        canhBao.DiaChiDon = item.DiaChiDonKhach;
                        canhBao.IsDisplay = true;
                        lstCanhBaoSanBay.Add(canhBao);
                    }
                    g_frmCanhBaoSanBay.SetCanhBao(lstCanhBaoSanBay);
                }
                if (!has15 && !has60)//Nếu không có cuốc nào thì cho về null
                {
                    g_frmCanhBaoSanBay.SetCanhBao(lstCanhBaoSanBay);
                }
                g_TimeSanbay = 0;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CanhBaoCuocSanBayTrenLuoi: ",ex);               
            }
        }
        #region=== Update New Version===
        private void LoadNewUpdateVer()
        {
            // Create a background thread
            BackgroundWorker bwUpdateVer = new BackgroundWorker();
            bwUpdateVer.DoWork +=  bwUpdateVer_DoWork;
            bwUpdateVer.RunWorkerCompleted +=  bwUpdateVer_RunWorkerCompleted;
            bwUpdateVer.RunWorkerAsync();
        }

        private void bwUpdateVer_DoWork(object sender, DoWorkEventArgs args)
        {
            var autoupdate = AutoUpdate.Inst.GetUpdateByDateTime(Module.DieuHanhChinh, license.Version());
            if (autoupdate != null)
            {
                args.Result = autoupdate.Version;
            }
        }
        private void bwUpdateVer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Error != null)
            {
                new MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
            }
            else
            {
                if (e.Result != null)
                {
                    g_Version = e.Result.ToString();
                    notifyUpdateVer.Visible = true;
                    notifyUpdateVer.ShowBalloonTip(60, "Có phiên bản Update " + g_Version, "Khởi động lại phần mềm để cập nhật thay đổi", ToolTipIcon.Warning);
                    notifyUpdateVer.Text = "Update " + g_Version + ", Khởi động lại để cập nhật thay đổi";
                    timerCheckVer = 0;
                }
            }
        }

        #region===Event control NotifyUpdateVersion
        private void notifyUpdateVer_Click(object sender, EventArgs e)
        {
            if (!g_IsNotifyUpdate)
            {
                string versionUpdate = string.Format("Phiên bản phần mềm Tổng đài mới: {0}", g_Version);
                frmNotifyAutoUpdate frm = new frmNotifyAutoUpdate();
                frm.SetMessage(versionUpdate);
                g_IsNotifyUpdate = true;
                if (frm.ShowDialog() == DialogResult.No)
                {
                    g_IsNotifyUpdate = false;
                }
            }
        }
        private void notifyUpdateVer_BalloonTipClicked(object sender, EventArgs e)
        {
            notifyUpdateVer_Click(sender, e);
        }
        #endregion
        #endregion
        private void ViewTrangThaiCacCuocGoiO_StatusBar()
        {
            try
            {
                int iSoCuocGoiChuaDieuXe = 0;
                int iSoCuocGoiChuaDonDuocKhach = 0;
                if (g_lstDienThoai != null)
                {
                    foreach (CuocGoi objDH in g_lstDienThoai)
                    {
                        if (objDH == null || objDH.XeNhan == null) continue;
                        if (objDH.XeNhan.Length <= 0)
                            iSoCuocGoiChuaDieuXe += 1;
                        if (objDH.XeNhan.Length > 0)
                            iSoCuocGoiChuaDonDuocKhach += 1;
                    }
                }
                status1.Width = 170;
                status1.EditValue = "Chưa điều xe : " + iSoCuocGoiChuaDieuXe;
                status2.Width = 180;
                status2.EditValue = "Chưa đón được khách : " + iSoCuocGoiChuaDonDuocKhach;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ViewTrangThaiCacCuocGoiO_StatusBar", ex);
            }
        }

        //-----------------------------Send Message--------------------------------------
        private void TimerMessage()
        {
            try
            {
                if (ThongTinDangNhap.USER_ID == "")
                    return;
                // Kiem tra tin nhan
                if (g_frmMessenger.IsDisposed == false)
                {

                    if (g_frmMessenger.Visible == false)
                    {
                        if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
                        {
                            g_frmMessenger.Show();
                        }
                    }
                    else
                    {
                        g_frmMessenger.BringToFront();
                    }
                }
                else
                {
                    g_frmMessenger = new Messenger();
                    if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
                    {
                        g_frmMessenger.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TimerMessage: ", ex);                
            }
        }

        private void timerNhayBaoCuocGoiMoi_Tick(object sender, EventArgs e)
        {
            if (g_NhayMauKhiCoCuocGoiMoi)
            {
                g_NhayMauKhiCoCuocGoiMoi = false;
            }
            else
            {
                g_NhayMauKhiCoCuocGoiMoi = true;
            }
            Thread.Sleep(100);
        }

        /// <summary>
        /// Hàm thực hiện cập nhật thông tin cuộc gọi đã kết thúc 
        /// </summary>
        private void CapNhatCuocGoiDaKetThucByDienThoai(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, ref bool pHasCapNhat,bool pHasThemMoi)
        {
            pHasCapNhat = false;            
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += cuocGoi.IDCuocGoi + ",";
                }
                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }
            if (listIDCuocGoi.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = CuocGoi.TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(listIDCuocGoi, vungsDuocCapPhep);
                if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                {
                    foreach (long idCuocGoi in listIDDaKetThuc)
                    {
                        int index = listCuocGoiHienTai.FindIndex(cuocGoiT => (cuocGoiT.IDCuocGoi == idCuocGoi));
                        if (index >= 0)
                        {                            

                            SapXepLaiIndex(listCuocGoiHienTai.Find(T => T.IDCuocGoi == idCuocGoi));

                            listCuocGoiHienTai.RemoveAt(index);

                            if (index <= g_RowIndex)
                            {
                                g_RowIndex = g_RowIndex - 1;
                            }
                            pHasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                    if (pHasThemMoi)
                        g_RowIndex++;
                }

            }
            else
                pHasCapNhat = false;
        }

        private void CapNhatCuocGoiDaKetThucByDienThoai_ChuaNhan(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, ref bool hasCapNhat)
        {
            hasCapNhat = false;
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += cuocGoi.IDCuocGoi + ",";
                }

                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }

            if (listIDCuocGoi.Length > 0)
            {
                List<long> listIDDaKetThuc = CuocGoi.TONGDAI_LayCacIDCuocGoiKetThucByDienThoai_ChuaNhan(listIDCuocGoi, vungsDuocCapPhep);
                if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                {
                    foreach (long idCuocGoi in listIDDaKetThuc)
                    {
                        int index = listCuocGoiHienTai.FindIndex(cuocGoiT => (cuocGoiT.IDCuocGoi == idCuocGoi));
                        if (index >= 0)
                        {

                            SapXepLaiIndex(listCuocGoiHienTai.Find(T => T.IDCuocGoi == idCuocGoi));

                            listCuocGoiHienTai.RemoveAt(index);

                            if (index <= g_RowIndex)
                            {
                                g_RowIndex = g_RowIndex - 1;
                            }
                            hasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                }
            }
            else
                hasCapNhat = false;
        }

        #endregion

        #region ====================== Memory==================================

        /// <summary>
        /// Background worker dong bo du lieu cuoc goi vao mem
        /// </summary>
        private BackgroundWorker bwSync_AddCuocGoi = new BackgroundWorker();
        private BackgroundWorker bwSync_RemoveCuocGoi = new BackgroundWorker();

        /// <summary>
        /// Khởi tạo Mem
        /// </summary>
        private void InitMemService()
        {
            try
            {
                bwSync_AddCuocGoi.DoWork += bwSync_AddCuocGoi_DoWork;
                bwSync_RemoveCuocGoi.DoWork += bwSync_RemoveCuocGoi_DoWork;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("InitMemService", ex);
                new MessageBoxBA().Show("Không kết nối được với Service đồng bộ xe", "Thông Báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                ThongTinCauHinh.GPS_TrangThai = false;
            }
        }

        private void bwSync_AddCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateCuocGoi_Memory(e.Argument as CuocGoi);
        }

        private void bwSync_RemoveCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoveCuocGoi_Memory(e.Argument as CuocGoi);
        }

        /// <summary>
        /// Cập nhật thông tin cuộc gọi vào memory
        /// </summary>
        private void UpdateCuocGoi_Memory(CuocGoi cuocGoi)
        {
            try
            {
                if (cuocGoi.GPS_KinhDo > 0 && cuocGoi.GPS_ViDo > 0 && ThongTinCauHinh.GPS_TrangThai)
                {
                    WCFService_Common.WCFServiceClient.Try(p => p.SaveTaxiOperation(cuocGoi.GPS_KinhDo
                    , cuocGoi.GPS_ViDo,
                    cuocGoi.LoaiXe,
                    cuocGoi.SoLuong,
                    cuocGoi.ThoiDiemGoi,
                    cuocGoi.IDCuocGoi, "", "", cuocGoi.XeNhan));
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("UpdateCuocGoi_Memory", ex);
            }
        }

        /// <summary>
        /// Xóa cuộc gọi ở mem, chuyển sang cuộc gọi kết thúc
        /// </summary>
        private void RemoveCuocGoi_Memory(CuocGoi cuocGoi)
        {
            try
            {
                if (cuocGoi.CoGPS && cuocGoi.GPS_KinhDo > 0 && ThongTinCauHinh.GPS_TrangThai)
                {
                    //xóa cuộc gọi ở memory
                    WCFService_Common.WCFServiceClient.Try(p => p.RemoveTaxiOperation(cuocGoi.IDCuocGoi, cuocGoi.Vung, cuocGoi.XeNhan, cuocGoi.XeDon));
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("RemoveCuocGoi_Memory", ex);
            }
        }

        #endregion

        #region Grid Cuoc goi chua nhan

        private void UpdateCuocGoi_NhanXuLy(bool isAll)
        {
            if (isAll)
            {
                if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_TatCa(g_VungDuocCapPhep, ThongTinDangNhap.USER_ID))
                {
                    new MessageBoxBA().Show(this, "Chưa nhận được cuộc gọi(F1), xin hãy liên hệ với quản trị.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                }
            }
            else
            {
                foreach (var item in grvCuocKhachMoi.GetSelectedRows())
                {
                    CuocGoi cuocGoiRow = (CuocGoi)grvCuocKhachMoi.GetRow(item);
                    cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
                    cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi_NhanXuLy(cuocGoiRow))
                    {
                        new MessageBoxBA().Show(this, "Chưa nhận được cuộc gọi:" + cuocGoiRow.DiaChiDonKhach, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        continue;
                    }
                    RemoveCuocGoi_ChuaNhan(cuocGoiRow);
                }
            }
            HienThiTrenLuoi_ChuaNhan(true, false); // Refresh
            //Chuyển lên lưới cuộc gọi đã nhận
            if (grvChoGiaiQuyet.RowCount > 0)
                grvChoGiaiQuyet.FocusedRowHandle = 0;

        }

        private void UpdateCuocGoi_Nhan5(int numAccept)
        {
            if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_ID(ThongTinDangNhap.USER_ID, numAccept, g_lstDienThoai_New, g_VungDuocCapPhep))
            {
                new MessageBoxBA().Show(this, "Chưa nhận được cuộc gọi, xin hãy liên hệ với quản trị.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
            //Chuyển lên lưới cuộc gọi đã nhận
            if (grvChoGiaiQuyet.RowCount > 0)
                grvChoGiaiQuyet.FocusedRowHandle = 0;
        }

        private void UpdateCuocGoi_HoanCuocGoi()
        {
            foreach (var item in grvCuocKhachMoi.GetSelectedRows())
            {
                CuocGoi cuocGoiRow = (CuocGoi)grvCuocKhachMoi.GetRow(item);

                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                #region SendSMS

                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan.Length > 0 && Config_Common.App_SendSMS_Customer)
                    WCFServicesApp.SendSMS_ReceiveDriverCancel(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, cuocGoiRow.XeNhan, cuocGoiRow.LoaiCuocKhach);
                #endregion
                if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi(cuocGoiRow))
                {
                    new MessageBoxBA().Show(this, "Chưa nhận được cuộc gọi, xin hãy liên hệ với quản trị.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    continue;
                }

                RemoveCuocGoi_ChuaNhan(cuocGoiRow);
            }
            HienThiTrenLuoi_ChuaNhan(true, true); // Refresh

        }

        private void UpdateCuocGoi_CuocGoiLai(CuocGoi cuocGoiRow)
        {
            cuocGoiRow.LenhTongDai = "gọi lại";
            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
            cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
            if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi(cuocGoiRow))
            {
                new MessageBoxBA().Show(this, "Cập nhật lỗi, xin hãy liên hệ với quản trị.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                return;
            }

            RemoveCuocGoi_ChuaNhan(cuocGoiRow);
            HienThiTrenLuoi_ChuaNhan(true, true); // Refresh            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvCuocKhachMoi.RowCount > 0 && grvCuocKhachMoi.SelectedRowsCount > 0)
            {
                UpdateCuocGoi_HoanCuocGoi();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grvCuocKhachMoi.RowCount > 0 && grvCuocKhachMoi.SelectedRowsCount > 0)
            {
                UpdateCuocGoi_NhanXuLy(false);
            }
        }

        private void btnNhanTatCa_Click(object sender, EventArgs e)
        {
            UpdateCuocGoi_NhanXuLy(true);
        }

        private void btnShift5_Click(object sender, EventArgs e)
        {
            UpdateCuocGoi_Nhan5(5);
        }
        #endregion

        #region Các thành phần FastTaxi

        private void DoFastTaxi()
        {
            if (ThongTinCauHinh.FT_Active)
            {
                ProcessFastTaxi.TitleLog = "Log gửi lên server-Tổng đài";
                ProcessFastTaxi.DoFastTaxi();
            }
        }

        private void SendFastTaxi(CuocGoi cuocGoiRow, Enum_FastTaxi_Status status)
        {

            ProcessFastTaxi.SendFastTaxi(cuocGoiRow, status);
        }

        #endregion

        #region App
        private void InitBackGroundApp()
        {

            if (Config_Common.DienThoai_DieuTuDong)
                status4.Visibility = BarItemVisibility.Always;
            else
                status4.Visibility = BarItemVisibility.Never;

            backGroundPingApp = new BackgroundWorker();
            backGroundPingApp.DoWork += PingApp_DoWork;
        }
        /// <summary>
        /// BackgroundWorker dùng để check kết nối server PMDH - Server Online
        /// </summary>
        private BackgroundWorker backGroundPingApp;
        private void PingApp_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CheckConnectServerApp();
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("PingApp_DoWork:", ex);
            }
        }
        /// <summary>
        /// Hiển thị trạng thái kết nối điều app
        /// </summary>
        private void CheckConnectServerApp()
        {
            string status;
            Image imgStatus;

            if (ServerApp.Ping() == Enum_G5_Ping.PingSu)
            {
                status = "Điều App OK";
                imgStatus = Resources.App_Connect_16x;

                if (Config_Common.App_DieuXeHopDong)
                {
                    if (ServerApp.PingServer_XHD == Enum_G5_Ping.PingSu)
                    {
                        status = status + "-Car OK";
                    }
                    else
                    {
                        status = status + "-Car Err";
                    }
                }
            }
            else
            {
                status = "Lỗi điều App";
                imgStatus = Resources.App_Error_16x;
                if (Config_Common.App_DieuXeHopDong)
                {
                    if (ServerApp.PingServer_XHD == Enum_G5_Ping.PingSu)
                    {
                        status = status + "-Car OK";
                        imgStatus = Resources.App_Connect_16x;
                    }
                    else
                    {
                        status = status + "-Car Err";
                    }
                }
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    status4.EditValue = status;
                    status4.Glyph = imgStatus;
                }));
            }
        }

        #endregion
        private void frmDieuHanhBoDamNEW_V3_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessFastTaxi.ketThuc = true;
            try
            {
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) //đúng vị trí checkout
                {
                    ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhBoDamNEW_V3_FormClosing:", ex);
            }

            try
            {

                if (bwSync_AddCuocGoi != null) bwSync_AddCuocGoi.Dispose();
                if (bwSync_RemoveCuocGoi != null) bwSync_RemoveCuocGoi.Dispose();
                this.Dispose(true);
                if (!AutoUpdate.Inst.IsUpdate)
                {
                    Process.GetCurrentProcess().Kill();//nếu kill hết sẽ không restart lại đc
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhBoDamNEW_V3_FormClosing:", ex);
            }
        }

        #region=== Menu control Devexpress==

        #region==Menu Quản trị===
        private void btnItemDoiMatKhau_ItemClick(object sender,ItemClickEventArgs e)
        {
            new CapNhatThongTinCaNhan().ShowDialog();
        }

        private void btnItemCheckIn_ItemClick(object sender,ItemClickEventArgs e)
        {
            CheckIn();
        }

        private void btnItemCheckOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            CheckOut();
        }

        private void btnItemThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region=== Menu Công cụ===

        private void btnItemTongTai_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmDMDiaDanh().ShowDialog();
        }
        private void btnItemLuuCauHinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl_BoDam.SelectedTabPage == tabChoGiaiQuyet)
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvChoGiaiQuyet.Name, ThongTinDangNhap.USER_ID, grvChoGiaiQuyet.GetLayoutFromStringXml());
            }
            else if (tabControl_BoDam.SelectedTabPage == tabDaGiaiQuyet)
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvCuocGoiKetThuc.Name, ThongTinDangNhap.USER_ID, grvCuocGoiKetThuc.GetLayoutFromStringXml());
            }
        }

        private void btnItemCauHinhMacDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl_BoDam.SelectedTabPage == tabChoGiaiQuyet)
            {
                grvChoGiaiQuyet.ResetLayout();
                HideAllLongColumns();
            }
            else if (tabControl_BoDam.SelectedTabPage == tabDaGiaiQuyet)
            {
                grvCuocGoiKetThuc.ResetLayout();
            }
        }

        private void btnItemCapNhatDuLieuXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            g_ListSoHieuXe = Xe.GetListSoHieuXe();
            CommonBL.ReLoadCommon();
            RealTimeEnvironment.ResetData();

            grvChoGiaiQuyet.Appearance.FocusedRow.ForeColor = Config_Common.Grid_FocusedRow_Color;
            grvChoGiaiQuyet.Appearance.FocusedRow.BackColor = Config_Common.Grid_FocusedRow_BackColor;
            if (Config_Common.Grid_Font != "" && Config_Common.LuoiCuocGoi_FontSize_TiepNhan > 0)
            {
                grvChoGiaiQuyet.Appearance.Row.Font = new System.Drawing.Font(new FontFamily(Config_Common.Grid_Font), Config_Common.LuoiCuocGoi_FontSize_TongDai);
            }
            if (Config_Common.Grid_HorzLineColor != null && !Config_Common.Grid_HorzLineColor.IsEmpty)
            {
                grvChoGiaiQuyet.Appearance.HorzLine.BackColor = Config_Common.Grid_HorzLineColor;
            }
        }
        private void btnItemXeDiDuongDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ThongTinCauHinh.FT_ChieuVe_Active)
                new frmUpdateTrip().ShowDialog();
        }
        private void btnItemDanhSachLaiXe_ItemClick(object sender,ItemClickEventArgs e)
        {
            new frmDSNhanVien().Show();
        }

        private void btnItemTraCuuTheMCC_ItemClick(object sender,ItemClickEventArgs e)
        {
            //new TraCuuTheMCC().ShowDialog();
        }

        private void btnItemGhiChu_ItemClick(object sender,ItemClickEventArgs e)
        {
            new Controls.frmGhiChu().Show();
        }
        #region===Style grid===
        private void btnItemTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl_BoDam.SelectedTabPage == tabChoGiaiQuyet)
            {
                grvChoGiaiQuyet.ZoomOut();
            }
            else if (tabControl_BoDam.SelectedTabPage == tabDaGiaiQuyet)
            {
                grvCuocGoiKetThuc.ZoomOut();
            }
        }
        private void btnItemGiam_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl_BoDam.SelectedTabPage == tabChoGiaiQuyet)
            {
                grvChoGiaiQuyet.ZoomIn();
            }
            else if (tabControl_BoDam.SelectedTabPage == tabDaGiaiQuyet)
            {
                grvCuocGoiKetThuc.ZoomIn();
            }
        }
        private void btnItemMacDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl_BoDam.SelectedTabPage == tabChoGiaiQuyet)
            {
                grvChoGiaiQuyet.ResetZoom();
            }
            else if (tabControl_BoDam.SelectedTabPage == tabDaGiaiQuyet)
            {
                grvCuocGoiKetThuc.ResetZoom();
            }
        }
        #endregion

        #endregion

        #region=== Menu Taxi chiều về===

        private void btnItemBaoXeDiDuongDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Controls.FastTaxis.TaxiDieuXe.frmTestThemMoi().Show();
        }
        #endregion

        #region=== Các phím chức năng nhanh===

        private void barItemTongDai1080_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmDMDiaDanh frmDMDiaDanh = new frmDMDiaDanh())
            {
                frmDMDiaDanh.ShowDialog();
            }
        }

        private void barItemTinhTien_ItemClick(object sender,ItemClickEventArgs e)
        {
            new frmTinhTienTheoKm().Show();
        }

        private void barItemTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            int TrangThaiCuocGoi;
            if (tabControl_BoDam.SelectedTabPage == tabTimKiemCuocGoi)
                TrangThaiCuocGoi = 1;
            else
                TrangThaiCuocGoi = 2;

            new TimKiemCuocGoi(g_TimeServer, g_VungDuocCapPhep, TrangThaiCuocGoi, "4").Show();
        }

        private void barItemTraCuuThe_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmMemberCard_Search().ShowDialog();
        }
        private void barItemBaoXeDiDuongDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ThongTinCauHinh.FT_ChieuVe_Active)
                new frmUpdateTrip().ShowDialog();
        }

        #endregion

        #region=== Menu right click CuocGoiDaGiaiQuyet===
        private void mnItem20Dong_Click(object sender, EventArgs e)
        {
            g_SoDong = 20;
            LoadCacCuocGoiKetThuc(g_VungDuocCapPhep, g_SoDong);
        }

        private void mnItem50Dong_Click(object sender, EventArgs e)
        {
            g_SoDong = 50;
            LoadCacCuocGoiKetThuc(g_VungDuocCapPhep, g_SoDong);
        }

        private void mnItem100Dong_Click(object sender, EventArgs e)
        {
            g_SoDong = 100;
            LoadCacCuocGoiKetThuc(g_VungDuocCapPhep, g_SoDong);
        }

        private void mnItemChuyenChuaGiaiQuyet_Click(object sender, EventArgs e)
        {
            RunChuyenCuocGoi();
        }
        #endregion

        #region ----------------- Lưới  grvCuocGoiKetThuc ------------------------
        private void grvCuocGoiKetThuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount >= 0)
            {
                CuocGoi cuocGoiRow = (CuocGoi)grvCuocGoiKetThuc.GetFocusedRow();
                if (cuocGoiRow == null) return;
                if (e.KeyData == (Keys.Control | Keys.C))
                {
                    var col = grvCuocGoiKetThuc.FocusedColumn;
                    switch (col.FieldName)
                    {
                        case "PhoneNumber":
                            Clipboard.SetText(cuocGoiRow.PhoneNumber);
                            break;
                        case "DiaChiDonKhach":
                            Clipboard.SetText(cuocGoiRow.DiaChiDonKhach);
                            break;
                    }
                }
                if (e.KeyData == Keys.Enter)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                    {
                        TimeSpan timeSpan = g_TimeServer - cuocGoiRow.ThoiDiemGoi;
                        if (!string.IsNullOrEmpty(cuocGoiRow.XeDon))
                        {
                            timeSpan.Add(new TimeSpan(0, 0, cuocGoiRow.ThoiGianDonKhach));
                        }
                        if (timeSpan.TotalSeconds > 30 * 60)  // lớn hơn 10 phút từ thời điểm nhập xe đón
                        {
                            MessageBoxBA msgDialog = new MessageBoxBA();
                            msgDialog.Show(this, "Quá giờ giới hạn cho phép bạn nhập thông tin.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                            return;
                        }
                        NhapDuLieuVaoTruyenDi(cuocGoiRow);
                    }
                }
                else if (e.KeyData == Keys.B)
                {
                    if (g_frmHienThiBanDo != null)
                    {
                        g_frmHienThiBanDo.g_CuocGoi = cuocGoiRow;
                        g_frmHienThiBanDo.LoadInfo();
                        g_frmHienThiBanDo.Visible = true;
                    }
                    else
                    {
                        new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                    }
                }

                // Ban Do Xe Nhan
                //else if (e.KeyData == Keys.X)
                //{
                //    if (g_frmHienThiBanDo != null)
                //    {
                //        g_frmHienThiBanDo.g_CuocGoi = cuocGoiRow;
                //        g_frmHienThiBanDo.LoadInfo();
                //        g_frmHienThiBanDo.Visible = true;
                //    }
                //    else
                //    {
                //        new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                //    }
                //}
            }
        }
        private void grvCuocGoiKetThuc_DoubleClick(object sender, EventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount >= 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                {
                    CuocGoi cuocGoiRow = (CuocGoi)grvCuocGoiKetThuc.GetFocusedRow();
                    if (cuocGoiRow == null) return;
                    TimeSpan timeSpan = g_TimeServer - cuocGoiRow.ThoiDiemGoi;
                    if (!string.IsNullOrEmpty(cuocGoiRow.XeDon))
                    {
                        timeSpan.Add(new TimeSpan(0, 0, cuocGoiRow.ThoiGianDonKhach));
                    }
                    if (timeSpan.TotalSeconds > 10 * 60)  // lớn hơn 10 phút từ thời điểm nhập xe đón
                    {
                        MessageBoxBA msgDialog = new MessageBoxBA();
                        msgDialog.Show(this, "Quá giờ giới hạn cho phép bạn nhập thông tin.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                        return;
                    }
                    NhapDuLieuVaoTruyenDi(cuocGoiRow);
                }
            }
        }
        #endregion

        private void tabControl_BoDam_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabControl_BoDam.SelectedTabPageIndex == 1)
            {
                g_TabKetThucDuocChon = true;
            }
            if (tabControl_BoDam.SelectedTabPage.Name == "tabDieuApp")
            {
                g_TabCuocDieuAppDuocChon = true;
            }
        }
        private void btnBC_1_3_ChiTietCuocGoiDen_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmBC_1_3_BaoCaoChiTietCuocGoiDen().Show();
        }

        private void btnBC_4_6_KQDieuHanhTheoNgay_ItemClick(object sender,ItemClickEventArgs e)
        {
            new frmBC_4_6_KQDieuHanhNVTheoNgay_V2().Show();
        }
        #endregion

        private void grvChoGiaiQuyet_DoubleClick(object sender, EventArgs e)
        {
            var cg = grvChoGiaiQuyet.GetFocusedRow() as CuocGoi;
            if (cg != null)
                NhapDuLieuVaoTruyenDi(cg);
        }
        private string G_XeNhan_Old = string.Empty;
        private string G_LenhMK_Old = string.Empty;
        private string G_XeDenDiem_Old = string.Empty;
        private void grvChoGiaiQuyet_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
            if (grvChoGiaiQuyet.RowCount > 0)
            {
                if (grvChoGiaiQuyet.SelectedRowsCount < 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        grvChoGiaiQuyet.FocusedRowHandle = 0;
                    }
                    else
                    {
                        grvChoGiaiQuyet.FocusedRowHandle = grvChoGiaiQuyet.RowCount - 1;
                    }
                }
                if (e.KeyData == Keys.NumPad0 || e.KeyData == (Keys.ControlKey | Keys.F))
                {
                    frmInputOnGrid frm = new frmInputOnGrid(KieuNhapTrenGridTongDai.TimKiemXe, g_ListSoHieuXe);
                    int yRow = grvChoGiaiQuyet.FocusedRowHandle * grvChoGiaiQuyet.RowHeight + 170;
                    if (yRow > grdChoGiaiQuyet.Height)
                    {
                        yRow = grdChoGiaiQuyet.Height - frm.Height;
                    }
                    frm.Location = new Point(525, yRow);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        TimKiemXeTrenLuoi(frm.GetGiaTriNhap());
                    }
                    return;
                }

                CuocGoi cuocGoiRow = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();
                int positionRowSelect = grvChoGiaiQuyet.FocusedRowHandle;
                bool hasThucHienLenh = false;  // dung de xac dinh có thay đổi dữ liệu và gọi update
                
                string XeDon_Old = cuocGoiRow.XeDon;
                string DiaChiDon_Old = cuocGoiRow.DiaChiDonKhach;
                string DiaChiTra_Old = cuocGoiRow.DiaChiTraKhach;

                G_XeNhan_Old = cuocGoiRow.XeNhan ?? string.Empty;
                G_LenhMK_Old = cuocGoiRow.LenhTongDai;
                G_XeDenDiem_Old = cuocGoiRow.XeDenDiem ?? string.Empty;

                #region Nhập lệnh nhanh
                int keyInput = (int)e.KeyData;
                bool isCommand = false; //biến check xem có phải command đã cấu hình ko
                MessageBoxBA MessageBox = new MessageBoxBA();
                int[] StatusCommand_Num = { 3, 4 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe)
                List<TaxiOperationCommand> lstCommand = CommonBL.Commands.FindAll(a => a.FunctionUsing == (int)Enum_ChucNangNhiemVu.TongDaiVien && a.CommandCode != Enum_CommandCode.System);
                foreach (var command in lstCommand)
                {
                    if (keyInput == command.Shortcuts)
                    {
                        isCommand = true;
                    }
                    else if (keyInput >= 96 && keyInput <= 105)
                    {
                        //Command là phím 0-9 (tính cả bên dãy phím số)
                        if (keyInput - command.Shortcuts == 48)
                            isCommand = true; // ưu tiên phím số vì có 2 chỗ nhập phím số
                        else continue;
                    }


                    if (isCommand)
                    {
                        hasThucHienLenh = true;
                        string CommandText = command.Command;
                        if ((command.CallType != null && (KieuCuocGoi)command.CallType != cuocGoiRow.KieuCuocGoi) 
                            && command.CommandCode != Enum_CommandCode.System)//Không check lệnh hệ thống
                        {
                            MessageBox.Show(string.Format("Phải là cuộc gọi xe mới được thực hiện lệnh [{0}]", command.Command), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            return;
                        }
                        else if (command.RequireVehicle && string.IsNullOrEmpty(cuocGoiRow.XeNhan))                            
                        {
                            MessageBox.Show(string.Format("Phải có xe nhận mới được thực hiện lệnh [{0}]", command.Command), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            return;
                        }
                        //Hoặc trường hợp không xe xin lỗi khách thì bắt buộc phải ko dc có xe nhận
                        else if ((!command.RequireVehicle
                            && !string.IsNullOrEmpty(cuocGoiRow.XeNhan)
                            && (command.CommandCode == Enum_CommandCode.TDV_KoXeLan1 || command.CommandCode == Enum_CommandCode.TDV_KhongXeXL)))
                        {
                            MessageBox.Show(string.Format("Phải chưa có xe nhận mới được thực hiện lệnh [{0}]", command.Command), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            return;
                        }
                        //else if (!string.IsNullOrEmpty(command.ParentCommand))
                        //{
                        //    if (!command.ParentCommand.Equals(cuocGoiRow.LenhDienThoai) || !cuocGoiRow.LenhDienThoai.Contains(command.ParentCommand))
                        //    {
                        //        msgDialog.Show(string.Format("[Lệnh Tổng Đài] phải là [{1}] thì mới được thực hiện lệnh [{0}]", CommandText, command.ParentCommand), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        //        return;
                        //    }
                        //}
                        if ((command.Status != null && StatusCommand_Num.Contains(command.Status.Value)))
                        {
                            string dialog = msgDialog.Show(
                                string.Format("[{0}] Kết thúc địa chỉ {1} ?", CommandText.ToUpper(), cuocGoiRow.DiaChiDonKhach), "LỆNH KẾT THÚC CUỐC",
                                MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                            if (dialog.ToUpper() == "no".ToUpper() || dialog == "")
                            {
                                hasThucHienLenh = false;
                                return;
                            }
                            else
                            {
                                cuocGoiRow.TrangThaiLenh = (TrangThaiLenhTaxi)command.Status;
                            }
                        }
                        //else
                        //{
                        //    break;
                        //}                       

                        cuocGoiRow.LenhTongDai = CommandText;
                        int[] CallStatusNum = { 1, 2, 3, 4, 6 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe, Không xe lần 1)
                        if (command.CallStatus != null && CallStatusNum.Contains(command.CallStatus.Value))
                        {
                            cuocGoiRow.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)command.CallStatus;
                        }
                        if (command.IsSend_CallCust != null) cuocGoiRow.ChuyenMK = (bool)command.IsSend_CallCust;
                        
                        //Lấy theo xe đến điểm để gửi sms cuốc đường dài khi nhập lệnh khác
                        if (hasThucHienLenh && command.CommandCode == Enum_CommandCode.TDV_SMSCuocDuongDai && Config_Common.SMS_CuocDuongDai_Dam_LaiXe_Send == Enum_SendSMSCuocDuongDai_Dam.NhapLenhKhac)
                        {
                            if (!string.IsNullOrEmpty(cuocGoiRow.XeDenDiem))
                            {
                                SendSMS_CuocDuongDai(cuocGoiRow, cuocGoiRow.XeDenDiem);
                            }
                            else
                            {
                                msgDialog.Show(this, String.Format("[{0}] Phải có xe đến điểm mới gửi sms được.", CommandText), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                hasThucHienLenh = false;
                                return;
                            }
                        }
                        if (hasThucHienLenh && command.CommandCode == Enum_CommandCode.TDV_SMSCustomerInfo)
                        {
                            if (!string.IsNullOrEmpty(cuocGoiRow.XeDenDiem))
                            {
                                if (Config_Common.App_SendSMS_Customer &&
                                        cuocGoiRow.SendSMS_Status != Enum_G5_PMDH_SMS_Status.ReceiveCarInfo)
                                {
                                    string info = string.Format("{0}", cuocGoiRow.DiaChiDonKhach);
                                    if (CommonBL.DictDriver[cuocGoiRow.XeDenDiem].SystemType == Enum_SystemType.Car )
                                    {
                                        if (WCFServicesAppXHD.SendSMS_DuongThao_CustomerPhone(cuocGoiRow.PhoneNumber, cuocGoiRow.XeDenDiem, info))
                                        {
                                            cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveCarInfo;
                                        }
                                    }
                                    else
                                    {
                                        if (WCFServicesApp.SendSMS_DuongThao_CustomerPhone(cuocGoiRow.PhoneNumber, cuocGoiRow.XeDenDiem, info))
                                        {
                                            cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveCarInfo;
                                        }
                                    }
                                    //if (cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                                    //{
                                    //    WCFServicesAppXHD.SendSMS_CustomerInfo(cuocGoiRow.BookId, cuocGoiRow.XeDenDiem, cuocGoiRow.PhoneNumber, info);
                                    //}
                                    //else
                                    //{
                                    //    WCFServicesApp.SendSMS_CustomerInfo(cuocGoiRow.BookId, cuocGoiRow.XeDenDiem, cuocGoiRow.PhoneNumber, info);
                                    //}
                                }
                                if (Config_Common.SMS_TaxiVina && Config_Common.SMS_TaxiVina_ReceiveCarInfo && cuocGoiRow.SendSMS_Status == null)
                                {
                                    if(WCF_SMSVina.Vina_SendSms_VinaTaxi_ReceiveCarInfo(cuocGoiRow.PhoneNumber,"", cuocGoiRow.XeDenDiem, (float)cuocGoiRow.GPS_ViDo, (float)cuocGoiRow.GPS_KinhDo, cuocGoiRow.BookId))
                                    {
                                        cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveCarInfo;
                                    }
                                    WCF_SMSVina.Vina_SendSms_VinaTaxi_ViewCar(cuocGoiRow.PhoneNumber, cuocGoiRow.XeDenDiem, (float)cuocGoiRow.GPS_ViDo, (float)cuocGoiRow.GPS_KinhDo, cuocGoiRow.BookId, 0);
                                }
                            }
                            else
                            {
                                msgDialog.Show(this, String.Format("[{0}] Phải có xe đến điểm mới gửi sms được.", CommandText), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                hasThucHienLenh = false;
                                return;
                            }
                        }
                        else if (hasThucHienLenh && command.CommandCode == Enum_CommandCode.TDV_SMSVinaTDVCatchedUser && Config_Common.SMS_TaxiVina && Config_Common.SMS_TaxiVina_ViewCar)
                        {
                            float soPhut = 5;
                            if (Config_Common.SMS_PHUTKHACHCHO != null && Config_Common.SMS_PHUTKHACHCHO != "")
                            {
                                frmInputOnGrid frmInput = new frmInputOnGrid("", KieuNhapTrenGridTongDai.NhapPhutKhachCho);
                                int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                                if (yRow > grdChoGiaiQuyet.Height)
                                {
                                    yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                                }
                                frmInput.Location = new Point(625, yRow);
                                if (frmInput.ShowDialog() == DialogResult.OK)
                                {
                                    hasThucHienLenh = true;
                                    float.TryParse(frmInput.GetGiaTriNhap(), out soPhut);
                                    cuocGoiRow.LenhTongDai = string.Format("SMS chờ khách {0}'", soPhut);
                                    HienThiTrenLuoi(true, false);
                                }
                            }
                            if (!string.IsNullOrEmpty(cuocGoiRow.XeDenDiem))
                            {
                                WCF_SMSVina.Vina_SendSms_VinaTaxi_ViewCar(cuocGoiRow.PhoneNumber, cuocGoiRow.XeDenDiem, (float)cuocGoiRow.GPS_ViDo, (float)cuocGoiRow.GPS_KinhDo, cuocGoiRow.BookId, soPhut);
                            }
                            else
                            {
                                msgDialog.Show(this, String.Format("[{0}] Phải có xe đến điểm mới gửi sms được.", CommandText), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                hasThucHienLenh = false;
                                return;
                            }
                        }
                        //Thực hiện xong thì thoát vòng lặp
                        break;
                    }
                }

                #endregion

                #region Xem lịch sử cuốc điều
                if (e.KeyData == (Keys.Control | Keys.H) && cuocGoiRow.FT_IsFT)
                {
                    new frmLichSuCuocDieu(cuocGoiRow).ShowDialog();
                    return;
                }
                #endregion

                if (e.KeyCode == Keys.Enter)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else if (g_HasPopUpNewCall && alertNewCall.AlertFormList.Count > 0)
                    {
                        ShowFormInPut();
                    }
                    else
                        NhapDuLieuVaoTruyenDi(cuocGoiRow);                    
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    if (g_HasPopUpNewCall && alertNewCall.AlertFormList.Count > 0)
                    {
                        alertNewCall.AlertFormList[0].Close();
                    }
                }
                
                #region ============== Backspace : xóa lệnh
                else if (e.KeyCode == Keys.Back)
                {
                    //string xoaLenh = CommonBL.GetCommandNameByKey((int) Keys.Back, 2);
                    if (cuocGoiRow.LenhTongDai != "")
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = "";
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                }
                #endregion

                #region ============== K : chuyển kênh
                else if (e.KeyCode == Keys.K)
                {

                    // Hiển thị ô nhập  
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapChuyenKenh, g_ListSoHieuXe, true)
                    {
                        G_ListCuocGoi = g_lstDienThoai
                    };
                    int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > grdChoGiaiQuyet.Height)
                    {
                        yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(625, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        SapXepLaiIndex(cuocGoiRow);
                        g_lstDienThoai.Remove(cuocGoiRow);
                        //TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                        HienThiTrenLuoi(false, false); // Refresh
                    }
                }
                #endregion

                #region ============== + : Nhập xe dừng điểm
                else if (e.KeyCode == Keys.Add)
                {
                    // Hiển thị ô nhập  
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDungDiem, g_ListSoHieuXe, true)
                    {
                        G_ListCuocGoi = g_lstDienThoai
                    };
                    int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > grdChoGiaiQuyet.Height)
                    {
                        yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(625, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        hasThucHienLenh = true;
                        var xeDungDiem = frmInput.GetGiaTriNhap();
                        List<string> lsXeDungDiem = new List<string>();
                        var dsxeDungDiem = xeDungDiem.Split('.').ToList();
                        if (!string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                        {
                            var dsxeNhan = cuocGoiRow.XeNhan.Split('.').ToList();
                            List<string> XoaXeNhan = new List<string>();
                            foreach (var item in dsxeNhan)
                            {
                                if (dsxeDungDiem.Any(p => p == item))
                                {
                                    XoaXeNhan.Add(item);
                                    if (lsXeDungDiem.All(p => p != item))
                                    {
                                        dsxeDungDiem.Remove(item);
                                        lsXeDungDiem.Add(item);
                                    }
                                }
                            }
                            XoaXeNhan.ForEach(p => dsxeNhan.Remove(p));
                            cuocGoiRow.XeNhan = string.Join(".", dsxeNhan.ToArray());

                        }
                        if (!string.IsNullOrEmpty(cuocGoiRow.XeDenDiem))
                        {
                            var dsxeXeDenDiem = cuocGoiRow.XeDenDiem.Split('.').ToList();
                            List<string> xoaDenDiem = new List<string>();
                            foreach (var item in dsxeXeDenDiem)
                            {
                                if (dsxeDungDiem.Any(p => p == item))
                                {
                                    xoaDenDiem.Add(item);
                                    if (lsXeDungDiem.All(p => p != item))
                                    {
                                        dsxeDungDiem.Remove(item);
                                        lsXeDungDiem.Add(item);
                                    }
                                }
                            }
                            xoaDenDiem.ForEach(p => dsxeXeDenDiem.Remove(p));
                            cuocGoiRow.XeDenDiem = string.Join(".", dsxeXeDenDiem.ToArray());
                        }
                        //lsXeDungDiem.AddRange(dsxeDungDiem);
                        cuocGoiRow.XeDungDiem = xeDungDiem;//string.Join(".", lsXeDungDiem.ToArray());
                        HienThiTrenLuoi(true, false);
                    }
                }
                #endregion

                #region ============== . : Địa chỉ trả
                else if (e.KeyCode == Keys.Decimal)
                {
                    // Hiển thị ô nhập  
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow.DiaChiTraKhach, KieuNhapTrenGridTongDai.NhapDiaChiTra);
                    int yRow = positionRowSelect * grvChoGiaiQuyet.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > grdChoGiaiQuyet.Height)
                    {
                        yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(625, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.DiaChiTraKhach = frmInput.GetGiaTriNhap();
                        HienThiTrenLuoi(true, false);
                    }
                }
                #endregion

                #region ================= / / F2 : chon nhap xe nhan
                else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.F2)
                {
                    hasThucHienLenh = NhapXeNhan(cuocGoiRow, positionRowSelect, "");

                    #region Gửi xe nhận tới Cho fastTaxi nếu là cuốc của fastTaxi
                    if (hasThucHienLenh && cuocGoiRow.FT_IsFT && G_XeNhan_Old.Trim() != cuocGoiRow.XeNhan.Trim())
                    {
                        SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.NhapXeNhan);
                    }
                    #endregion
                }
                #endregion

                #region ================= */F3 :Xe MK// chon nhap xe den diem
                else if (e.KeyCode == Keys.Multiply || e.KeyCode == Keys.F3)
                {
                    string xeDenDiemHienTai = cuocGoiRow.XeDenDiem;
                    if (Config_Common.TDV_NhapXeMK)
                    {
                        xeDenDiemHienTai = cuocGoiRow.BTBG_NoiDungXuLy;
                        hasThucHienLenh = NhapXeMK(cuocGoiRow, positionRowSelect, "", false);
                    }
                    else
                    {
                        hasThucHienLenh = NhapXeDenDiem(cuocGoiRow, positionRowSelect, "", false);
                    }
                    if (Config_Common.LenhMoiKhachKhiNhapXeDenDiem == 1)
                    {
                        if (hasThucHienLenh && !string.IsNullOrEmpty(cuocGoiRow.XeDenDiem) 
                            && cuocGoiRow.XeDenDiem != xeDenDiemHienTai)
                        {
                            cuocGoiRow.LenhTongDai = CommonBL.GetNameByCodeEnum(Enum_CommandCode.TDV_MoiKhach, 2);
                        }
                    }
                    if (hasThucHienLenh && !string.IsNullOrEmpty(cuocGoiRow.XeDenDiem) && cuocGoiRow.XeDenDiem != xeDenDiemHienTai && cuocGoiRow.XeDenDiem != "000" && Config_Common.SMS_CuocDuongDai_Dam_LaiXe_Send == Enum_SendSMSCuocDuongDai_Dam.NhapXeDenDiem)
                    {
                        SendSMS_CuocDuongDai(cuocGoiRow, cuocGoiRow.XeDenDiem);
                    }
                }
                #endregion

                #region ================= - / F4 : chon nhap Xe Don
                else if ((e.KeyCode == Keys.Subtract || e.KeyCode == Keys.F4))
                {
                    var xeDonCurrent = cuocGoiRow.XeDon;
                    hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "", false);

                    #region SendToMasterSignedCar - Nhập xe đón
                    //Xe đón thay đổi thì xử lý gửi
                    if (cuocGoiRow.FT_IsFT && hasThucHienLenh && xeDonCurrent != cuocGoiRow.XeDon && cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach &&
                        cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                    {
                        SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.NhapXeDon);
                    }
                    #endregion
                }
                #endregion
                
                #region ================= C : Chuyển thành Gọi Taxi
                else if (e.KeyCode == Keys.C)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiLai)
                    {
                        CuocGoi.TONGDAI_UpdateCuocGoiTaxi(cuocGoiRow.IDCuocGoi);
                    }
                    else
                    {
                        msgDialog.Show(this, "[Lệnh Gọi Taxi] Cuội gọi phải là cuộc gọi lại.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ================= Space : Đang gọi =================
                else if (e.KeyData == (Keys.Control | Keys.Space))
                {
                    string lenh6KiemTraKhach = CommonBL.GetNameByKey((int) Keys.D6, 2);
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                        HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, true);

                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", lenh6KiemTraKhach), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region Control|C : Copy
                else if (e.KeyData == (Keys.Control | Keys.C))
                {
                    var col = grvChoGiaiQuyet.FocusedColumn;
                    switch (col.FieldName)
                    {
                        case "PhoneNumber":
                            Clipboard.SetText(cuocGoiRow.PhoneNumber);
                            break;
                        case "DiaChiDonKhach":
                            Clipboard.SetText(cuocGoiRow.DiaChiDonKhach);
                            break;
                    }

                }
                #endregion

                #region B : Bản đồ
                else if (e.KeyData == Keys.B)
                {
                    if (g_frmHienThiBanDo != null)
                    {
                        g_frmHienThiBanDo.g_CuocGoi = cuocGoiRow;
                        g_frmHienThiBanDo.LoadInfo();
                        g_frmHienThiBanDo.Visible = true;
                    }
                    else
                    {
                        new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                    }
                }
                else if (e.KeyData == (Keys.Control | Keys.B))
                {
                    if (g_frmBanDo != null && g_frmBanDo.Visible)
                    {
                        HienThiBanDo(null, false);
                    }
                    else
                    {
                        HienThiBanDo(cuocGoiRow, true);
                        grvChoGiaiQuyet.Focus();
                    }
                }
                #endregion

                #region  X : Thoat cuoc don khach khong xac dinh
                else if (e.KeyData == Keys.X)
                {
                    hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "000", false);
                }

                #endregion

                #region có thực hiện lệnh, gọi cập nhật
                if (hasThucHienLenh)
                {                    
                    //*command
                    bool chuyenMK = CommonBL.Commands.Any(a => a.ParentCommand.Contains(cuocGoiRow.LenhTongDai) && !string.IsNullOrEmpty(a.ParentCommand) && a.FunctionUsing == 2 && !string.IsNullOrEmpty(cuocGoiRow.LenhTongDai));
                    if (chuyenMK)
                    {
                        cuocGoiRow.ChuyenMK = true;
                    }

                    cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                    var checkChange = new CuocGoi.CheckChange();
                    checkChange.DiaChiDon = cuocGoiRow.DiaChiDonKhach.Equals(DiaChiDon_Old);
                    checkChange.DiaChiTra = cuocGoiRow.DiaChiTraKhach.Equals(DiaChiTra_Old);
                    checkChange.XeNhan = cuocGoiRow.XeNhan.Equals(G_XeNhan_Old);
                    checkChange.XeDon = cuocGoiRow.XeDon.Equals(XeDon_Old);
                    #region Dieu app - gui thong bao xuong cho app KH
                    if (cuocGoiRow.BookId != Guid.Empty && cuocGoiRow.G5_StepLast == Enum_G5_Step.SourceCancel_Customer)
                    {
                        if (cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan
                                || cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiTruot)
                        {
                            WCFServicesApp.SendOperatorDispatched(cuocGoiRow.BookId, "");
                        }
                        else if (G_XeNhan_Old != cuocGoiRow.XeNhan)
                            WCFServicesApp.SendOperatorDispatched(cuocGoiRow.BookId, cuocGoiRow.XeNhan);
                    }
                    #endregion

                    #region Send SMS
                    if (Config_Common.SMS_CuocDuongDai_Dam_LaiXe_Send == Enum_SendSMSCuocDuongDai_Dam.NhapXeDon && cuocGoiRow.XeDon != "000"
                        && cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                        && cuocGoiRow.XeNhan.Length > 0 && cuocGoiRow.XeDon.Length > 0
                        && cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach
                        && (cuocGoiRow.SendSMS_Status == null || cuocGoiRow.SendSMS_Status == Enum_G5_PMDH_SMS_Status.ReceiveCarInfo))
                        SendSMS_CuocDuongDai(cuocGoiRow, cuocGoiRow.XeDon);

                    //else if (!string.IsNullOrEmpty(cuocGoiRow.XeDenDiem) && Config_Common.SMS_CuocDuongDai_Dam_LaiXe_Send == Enum_SendSMSCuocDuongDai_Dam.NhapXeDenDiem && cuocGoiRow.XeDenDiem != "000" && G_XeDenDiem_Old != cuocGoiRow.XeDenDiem)
                    //    SendSMS_CuocDuongDai(cuocGoiRow, cuocGoiRow.XeDenDiem);

                    #endregion

                    if (!UpdateThongTinCuocGoi(cuocGoiRow, checkChange))
                    {
                        new MessageBoxBA().Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);                        
                    }
                    else
                    {
                        #region SMS Taxi Vina
                        //if (Config_Common.SMS_TaxiVina && Config_Common.SMS_TaxiVina_ReceiveCarInfo && cuocGoiRow.XeNhan != "" && G_XeNhan_Old != cuocGoiRow.XeNhan
                        //    && cuocGoiRow.SendSMS_Status == null)
                        //{
                        //    string xenhanViewcar = cuocGoiRow.XeNhan;
                        //    if (cuocGoiRow.XeNhan.Contains("."))
                        //    {
                        //        string[] arXeNhan = cuocGoiRow.XeNhan.Split('.');
                        //        xenhanViewcar = arXeNhan[0];
                        //    }
                        //    WCF_SMSVina.Vina_SendSms_VinaTaxi_ViewCar(cuocGoiRow.PhoneNumber, xenhanViewcar);
                        //    cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveCarInfo;
                        //}
                        //else 
                        if (Config_Common.SMS_TaxiVina && Config_Common.SMS_TaxiVina_ThankCustomer && cuocGoiRow.XeDon != "" 
                            && cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach && cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            WCF_SMSVina.Vina_SendSms_VinaTaxi_ThankCustomer(cuocGoiRow.PhoneNumber, cuocGoiRow.XeDon);
                        }
                        #endregion
                        #region Bắn cuốc App xuống cho LX
                        if (Config_Common.App_SendRadioTrip && G_XeDenDiem_Old != cuocGoiRow.XeDenDiem && cuocGoiRow.XeDenDiem != "")
                        {
                            cuocGoiRow.ShowPhoneAppDriver = true;

                            if (cuocGoiRow.GPS_KinhDo > 0)
                            {
                                cuocGoiRow.GPS_KinhDo = 0;
                                cuocGoiRow.GPS_ViDo = 0;
                            }
                            if (cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                                WCFServicesAppXHD.SendInitTrip(cuocGoiRow);
                            else
                                WCFServicesApp.SendInitTrip(cuocGoiRow);
                        }
                        #endregion 
                        if (cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            
                            SapXepLaiIndex(cuocGoiRow);
                            g_lstDienThoai.Remove(cuocGoiRow);
                            HienThiTrenLuoi(false, false);
                            //if (!bwSync_RemoveCuocGoi.IsBusy)
                            //{
                            //    //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                            //    bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                            //}
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                            HienThiTrenLuoi(true, false);
                        }
                    }
                }
                #endregion
            }
        }

        #region TongDai IP

        #region ==================== Thông số kết nối tổng đài =======================
        private ManagerConnection g_Manager = null;
        private string g_LineIPPBX = string.Empty;          //Line của Tổng đài PBX IP cho pc này 
        public static frmDangGoi g_frmCalling = new frmDangGoi();
        
        #endregion

        /// <summary>
        /// Hàm hiển thị thông tin form gọi điện
        /// </summary>
        private void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi, bool isPBXIP)
        {
            if (g_frmCalling.IsDisposed)
            {
                g_frmCalling = new frmDangGoi();
            }
            g_frmCalling.Show();
            g_frmCalling.Invoke(
                (MethodInvoker)delegate
                {
                    g_frmCalling.lblSoGoi.Text = String.Format("Đang gọi : {0} - {1}", PhoneNumber, DiaChi);
                }
                );
            g_frmCalling.Refresh();
            if (isPBXIP)
            {
                g_frmCalling.Call(g_Manager, g_LineIPPBX, PhoneNumber);
                System.Threading.Thread.Sleep(1000);
                g_frmCalling.Hide();
            }
        }

        #endregion
        private void grvChoGiaiQuyet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (g_IsBinding) return;
            g_RowIndex = grvChoGiaiQuyet.FocusedRowHandle;
            var cg = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();
            if (cg != null)
            {
                lblSdt.Text = cg.PhoneNumber;
                lblDiaChi.Text = cg.DiaChiDonKhach;
                lblDTV.Text = cg.LenhDienThoai;
            }
            else
            {
                lblSdt.Text = string.Empty;
                lblDiaChi.Text = string.Empty;
                lblDTV.Text = string.Empty;
            }
        }

        private void HienThiAnhTrangThai_MauChuV2(CuocGoi cuocGoi, bool IsRow, int RowIndex, string colName, object valueCell, DevExpress.Utils.AppearanceObject style)
        {
            try
            {
                if (cuocGoi == null) return;

                if (IsRow)
                {
                    if (string.IsNullOrEmpty(cuocGoi.MaNhanVienTongDai))
                    {
                        style.BackColor = Config_Common.Grid_CuocChuaXuLy_BackGround;
                    }
                    else
                    {
                        style.BackColor = Config_Common.Grid_CuocChuaXuLy_BackGround_DaNhan;
                    }
                    if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiHoiDam)
                    {
                        style.BackColor = Config_Common.Grid_CuocHoiDam_BackGround;
                    }
                    //Nếu là trạng thái server trả về đã sang đàm thì đổi màu của dòng.
                    if (Enum_G5_Step.ConfirmTripLast <= cuocGoi.G5_StepLast && cuocGoi.G5_StepLast <= Enum_G5_Step.DriverDoneLast)
                    {
                        style.BackColor = Config_Common.MauLaiXeNhanAppTongDai;
                    }
                    if ((cuocGoi.LenhDienThoai.ToUpper() == "SÂN BAY".ToUpper() || cuocGoi.SanBay_DuongDai == "1"))
                    {
                        style.BackColor = Config_Common.Grid_CuocSanBay_BackGround;
                    }

                    //if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("2"))
                    //{
                    //    //*command
                    //    var lenhDT = CommonBL.Commands.FirstOrDefault( a=> a.Command.Contains(cuocGoi.LenhDienThoai)&& !string.IsNullOrEmpty(cuocGoi.LenhDienThoai));
                    //    var lenhMK = CommonBL.Commands.FirstOrDefault(a=>a.Command.Contains(cuocGoi.MOIKHACH_LenhMoiKhach)&&!string.IsNullOrEmpty(cuocGoi.MOIKHACH_LenhMoiKhach));
                    //    if (lenhDT!=null && lenhDT.Command.Length > 0)
                    //        style.BackColor = Color.FromName(lenhDT.CmdColor);
                    //    else if (lenhMK!=null && lenhMK.Command.Length > 0)
                    //        style.BackColor = Color.FromName(lenhMK.CmdColor);
                    //    else
                    //        style.BackColor = Config_Common.LuoiCuocGoi_MauNen_LenhMoi;                     
                    //}
                }
                else//Màu sắc cho một cell của cuốc
                {
                    if (!string.IsNullOrEmpty(cuocGoi.XeDungDiem) && colName != null && colName.Equals("XeDungDiem"))
                    {
                        style.BackColor = Config_Common.Grid_XeDungDiem_Color;
                    }
                    if (colName != null && colName.Equals("ThoiDiemGoi"))
                    {
                        TimeSpan timer = g_TimeServer - cuocGoi.ThoiDiemGoi;
                        if (timer.TotalMinutes > 5 && timer.TotalMinutes <= 15)
                        {
                            style.ForeColor = Config_Common.Grid_ThoiDiemGoi_Color_5;
                        }
                        else if (timer.TotalMinutes > 15)
                        {
                            style.ForeColor = Config_Common.Grid_ThoiDiemGoi_Color_15;
                        }
                    }
                    #region Cột Lệnh
                    if (colName != null && (colName.Equals("LenhDienThoai") || colName.Equals("LenhTongDai") || colName.Equals("LenhLaiXe")))
                    {
                        if (valueCell != null && CommonBL.Commands.Count(t => t.Command == valueCell.ToString()) > 0)
                        {
                            int functionUsing = 0;
                            if (colName.Equals("LenhDienThoai"))
                            {
                                functionUsing = 1;
                            }
                            else if (colName.Equals("LenhTongDai"))
                            {
                                functionUsing = 2;
                            }
                            else if (colName.Equals("LenhLaiXe"))
                            {
                                functionUsing = 4;
                            }
                            var listLenh = new List<string>();
                            listLenh.Add(cuocGoi.LenhDienThoai);
                            listLenh.Add(cuocGoi.LenhTongDai);
                            listLenh.Add(cuocGoi.LenhLaiXe);
                            listLenh.Remove(valueCell.ToString());
                            var lenhDT = CommonBL.Commands.FirstOrDefault(t => t.Command == valueCell.ToString() && t.FunctionUsing == functionUsing);
                            if (lenhDT != null)
                            {
                                bool mauTheoLenhCha = false;
                                if (!string.IsNullOrEmpty(lenhDT.ParentCommand))
                                {
                                    var lenhCha = lenhDT.ParentCommand.Split(',').ToList();
                                    foreach (var lenh in listLenh)
                                    {
                                        if (lenhCha.Contains(lenh))
                                        {
                                            mauTheoLenhCha = true;
                                            style.BackColor = Color.FromName(lenhDT.ParentColor);
                                            //bc = true;
                                        }
                                    }
                                }
                                if (!mauTheoLenhCha)
                                {
                                    style.BackColor = Color.FromName(lenhDT.CmdColor);
                                    //bc = true;
                                }
                            }
                        }
                        else
                        {
                            if (colName.Equals("LenhDienThoai") && cuocGoi.LenhDienThoai != "")
                                style.BackColor = Config_Common.TDV_Grid_LenhDTV;
                        }
                    }
                    #endregion

                    if (colName != null && colName.Equals("Line"))
                    { 
                        if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                        {
                            style.BackColor = Config_Common.Grid_Line_Color_KhachMG;
                        }
                        else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                        {
                            style.BackColor = Config_Common.Grid_Line_Color_KhachVip;
                            //style.ForeColor = Color.White;
                        }
                        else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                            || cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                        {
                            style.BackColor = Config_Common.Grid_Line_Color_KhachVangBac;
                        }
                        else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangKhongHieu)
                        {
                            style.BackColor = Config_Common.Grid_Line_Color_KhachAo;
                        }
                    }

                    if (colName != null && colName.Equals("LoaiXe") && Config_Common.LuoiCuocGoi_MauNen_LoaiXe != null && Config_Common.LuoiCuocGoi_MauNen_LoaiXe.Length > 0)
                    {
                        bool HasColor_LoaiXe = false;
                        foreach (var item in Config_Common.LuoiCuocGoi_MauNen_LoaiXe)
                        {
                            if (cuocGoi.LoaiXe.Contains(item))
                            {
                                HasColor_LoaiXe = true;
                                break;
                            }
                        }
                        if (HasColor_LoaiXe)
                        {
                            style.BackColor = Config_Common.Grid_LoaiXe_Color_Config5;
                        }
                    }

                    if (colName != null && colName.Equals("SoLanGoi"))
                    {
                        if (cuocGoi.SoLanGoi == 1)
                        {
                            style.BackColor = Config_Common.Grid_SoLan_Color_1;
                        }
                        else if (cuocGoi.SoLanGoi >= 2)
                        {
                            style.BackColor = Config_Common.Grid_SoLan_Color_2;
                        }
                    }

                    if (colName != null && colName.Equals("SoLuong") && cuocGoi.SoLuong > 1)
                    {
                        style.BackColor = Config_Common.Grid_SoLuong_Color_1;
                    }

                    if (colName != null && colName.Equals("DiaChiDonKhach"))
                    {
                        if (cuocGoi.FT_IsFT)
                        {
                            style.BackColor = Config_Common.Grid_DiaChi_App_Color;
                        }
                        else if (!cuocGoi.FT_IsFT && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                        {
                            style.BackColor = Config_Common.Grid_DiaChi_GL_Color;
                        }
                    }

                    if (colName != null && colName.Equals("GhiChuDienThoai"))
                    {
                        if (cuocGoi.FT_IsFT)
                        {
                            style.ForeColor = Config_Common.TDV_Grid_GhiChuDTV;
                        }
                        else if (!cuocGoi.FT_IsFT)
                        {
                            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                            {
                                style.BackColor = Config_Common.Grid_DiaChi_GL_Color;                                
                            }
                            else
                            {
                                style.ForeColor = Config_Common.TDV_Grid_GhiChuDTV;
                            }
                        }
                    }
                    if (colName != null && colName.Equals("ThoiGianHen"))
                    {
                        if (cuocGoi.SanBay_DuongDai == "1")
                        {
                            TimeSpan time = cuocGoi.ThoiGianHen - g_TimeServer;
                            if (time.TotalMinutes <= 15)
                            {
                                style.BackColor = Config_Common.Grid_ThoiDiemHen_Color_15;
                            }
                            else if (time.TotalMinutes <= 90 && time.TotalMinutes > 15)
                            {
                                style.BackColor = Config_Common.Grid_ThoiDiemHen_Color_90;
                            }
                        }
                        else
                        {
                            if (cuocGoi.ThoiGianHen > cuocGoi.ThoiDiemGoi)
                            {
                                style.BackColor = Config_Common.TDV_Grid_ThoiGianHen;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiAnhTrangThai_MauChuV2:", ex);
            }
        }

        private void grvChoGiaiQuyet_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var cg = (CuocGoi)grvChoGiaiQuyet.GetRow(e.RowHandle);
                HienThiAnhTrangThai_MauChuV2(cg, false, e.RowHandle, e.Column.FieldName, e.CellValue, e.Appearance);
            }
        }

        private void grvChoGiaiQuyet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var cg = (CuocGoi)grvChoGiaiQuyet.GetRow(e.RowHandle);
                HienThiAnhTrangThai_MauChuV2(cg, true, e.RowHandle, string.Empty, null, e.Appearance);
            }
        }

        private void grvCuocKhachMoi_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBoxBA msgDialog = new MessageBoxBA();
            if (grvCuocKhachMoi.RowCount > 0)
            {
                if (grvCuocKhachMoi.SelectedRowsCount <= 0)
                {
                    if (e.KeyCode == Keys.Up)
                        grvCuocKhachMoi.FocusedRowHandle = 0;
                    else if (e.KeyCode == Keys.Down)
                        grvCuocKhachMoi.FocusedRowHandle = grvCuocKhachMoi.RowCount - 1;
                }
                else
                {
                    int positionRowSelect = grvChoGiaiQuyet.FocusedRowHandle;
                    CuocGoi cuocGoiRow = (CuocGoi)grvCuocKhachMoi.GetFocusedRow();
                    if (e.KeyCode == Keys.Enter)
                    {
                        UpdateCuocGoi_NhanXuLy(false);
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        UpdateCuocGoi_HoanCuocGoi();
                    }
                    // ============== 4 : chuyển kênh
                    else if (e.KeyCode == Keys.K)
                    {
                        // Hiển thị ô nhập
                        frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapChuyenKenh, g_ListSoHieuXe, true)
                        {
                            G_ListCuocGoi = g_lstDienThoai
                        };
                        int yRow = positionRowSelect * grvCuocKhachMoi.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                        if (yRow > grdCuocKhachMoi.Height)
                        {
                            yRow = grdCuocKhachMoi.Height - frmInput.Height;
                        }
                        frmInput.Location = new Point(625, yRow);
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            g_lstDienThoai_New.Remove(cuocGoiRow);
                            //TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                            HienThiTrenLuoi_ChuaNhan(false, false); // Refresh
                        }
                    }
                    //================= L : Ket thuc cuộc gọi lại
                    else if (e.KeyCode == Keys.L)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiLai)
                        {
                            UpdateCuocGoi_CuocGoiLai(cuocGoiRow);
                        }
                        else
                        {
                            msgDialog.Show(this, "[Lệnh gọi lại] " + "Cuội gọi phải là cuộc gọi lại.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        }
                    }
                }
            }
        }

        private void HienThiAnhTrangThai_MauChu_ChuaNhanV2(CuocGoi cuocGoi, bool IsRow, int RowIndex, string colName, object valueCell, DevExpress.Utils.AppearanceObject style)
        {
            try
            {
                if (cuocGoi == null)
                    return;
                if (!IsRow && !string.IsNullOrEmpty(colName))
                {
                    switch (colName)
                    {
                        //case "LenhDienThoai":
                        //    if (cuocGoi.LenhDienThoai == LENH_KHACHDAT || cuocGoi.LenhDienThoai == LENH_SANBAY)
                        //    {
                        //        style.BackColor = Color.Green;
                        //    }
                        //    break;
                        case "Line":
                            if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                            {
                                style.BackColor = Color.Yellow;
                            }
                            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                            {
                                style.BackColor = Color.Blue;
                            }
                            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                                || cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                            {
                                style.BackColor = Color.Blue;
                            }
                            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangKhongHieu)
                            {
                                style.BackColor = Color.Tomato;
                            }
                            break;
                        case "DiaChiDonKhach":
                            if (cuocGoi.FT_IsFT)
                            {
                                style.BackColor = Color.Yellow;
                            }
                            else if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                            {
                                style.BackColor = Color.Red;
                            }
                            break;
                        case "LoaiXe":
                            if (cuocGoi.LoaiXe != null && (cuocGoi.LoaiXe.Contains("INO") || cuocGoi.LoaiXe.Contains("LIM")))
                            {
                                style.BackColor = Color.Cyan;
                            }
                            break;
                        case "SoLanGoi":
                            if (cuocGoi.SoLanGoi == 1)
                            {
                                style.BackColor = Color.Yellow;
                            }
                            else if (cuocGoi.SoLanGoi >= 2)
                            {
                                style.BackColor = Color.Red;
                            }
                            break;
                        case "SoLuong":
                            if (cuocGoi.SoLuong > 1)
                            {
                                style.BackColor = Color.Red;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiAnhTrangThai_MauChu_ChuaNhan:", ex);
            }
        }

        private void grvCuocKhachMoi_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var cg = (CuocGoi)grvChoGiaiQuyet.GetRow(e.RowHandle);
                HienThiAnhTrangThai_MauChu_ChuaNhanV2(cg, false, e.RowHandle, e.Column.FieldName, e.CellValue, e.Appearance);
            }
        }

        private void grvCuocKhachMoi_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var cg = (CuocGoi)grvChoGiaiQuyet.GetRow(e.RowHandle);
                HienThiAnhTrangThai_MauChu_ChuaNhanV2(cg, true, e.RowHandle, string.Empty, null, e.Appearance);
            }
        }

        private void grvCuocGoiKetThuc_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var cuocGoi = (CuocGoi)grvCuocGoiKetThuc.GetRow(e.RowHandle);
                if (Global.IsDieuSanBayTongDai && (cuocGoi.LenhDienThoai.ToUpper() == "SÂN BAY".ToUpper() || cuocGoi.SanBay_DuongDai == "1"))
                {
                    e.Appearance.BackColor = Config_Common.Grid_CuocSanBay_BackGround;
                }
            }
        }

        private void btnDanhSachDuongDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (DSCuocDuongDai_SanBay_V2 dSCuocDuongDai_SanBay = new DSCuocDuongDai_SanBay_V2(G_arrProvince, G_arrDistrict, G_arrCommune))
            {
                dSCuocDuongDai_SanBay.ShowDialog();
            }
        }

        private void btnChotCoSanBay_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince, G_arrDistrict, G_arrCommune, ""))
            {
                thongTinSanBay_DuongDai.ShowDialog();
            }
        }
        
        private void barButton_ChotCoDD_Mini_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmXeBaoDiSanBay_DuongDai_Mini thongTinSanBay_DuongDai = new frmXeBaoDiSanBay_DuongDai_Mini())
            {
                thongTinSanBay_DuongDai.ShowDialog();
            }
        }

        private void btnTraCuuGiaCuocThueBao_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmTraCuuBangGiaGoc().Show();
        }

        private void btnNhatKyThueBao_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmThongTinNhatKyThueBao().Show();
        }

        private void btnBC_1_1_TongHopCuocTheoNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmBC_1_1_BaoCaoTongHopCuocKhachDieuHanh_V2().Show();
        }

        #region Xử lý pop up cuộc gọi
        private void HienThiPopUpCuocGoiMoi(CuocGoi pCuocGoi)
        {
            try
            {
                string strDiaChiDon = string.Empty;
                if (pCuocGoi.DiaChiDonKhach.Length > 30)
                    strDiaChiDon = pCuocGoi.DiaChiDonKhach.Substring(0, 30) + " ...";
                else
                    strDiaChiDon = pCuocGoi.DiaChiDonKhach;
                AlertInfo alertInfo = new AlertInfo(pCuocGoi.PhoneNumber + " - " + pCuocGoi.ThoiDiemGoi.ToShortDateString(), strDiaChiDon, Resources.ic_Phone__insert_the_call_01);
                alertInfo.Tag = pCuocGoi.IDCuocGoi;
                alertNewCall.FormLocation = AlertFormLocation.BottomRight;
                alertNewCall.AppearanceCaption.ForeColor = GetColorByType(pCuocGoi.KieuKhachHangGoiDen);
                alertNewCall.Show(this, alertInfo);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiPopUpCuocGoiMoi: ", ex);
            }
        }

        private Color GetColorByType(KieuKhachHangGoiDen kieuKhachHangGoiDen)
        {
            switch (kieuKhachHangGoiDen)
            {
                case KieuKhachHangGoiDen.KhachHangBinhThuong:
                    return Color.Black;
                case KieuKhachHangGoiDen.KhachHangVIP:
                    return Color.Violet;
                case KieuKhachHangGoiDen.KhachHangMoiGioi:
                    return Color.Blue;
                case KieuKhachHangGoiDen.KhachHangHen:
                    return Color.Brown;
                default:
                    return Color.Black;
            }
        }

        private void ShowFormInPut()
        {
            try
            {
                int lastIndex = alertNewCall.AlertFormList.Count - 1;
                string ID = alertNewCall.AlertFormList[lastIndex].AlertInfo.Tag.ToString();//Show Form đầu tiên!
                if (g_lstDienThoai != null)
                {
                    var cuocGoi = g_lstDienThoai.FirstOrDefault(a => a.IDCuocGoi == ID.To<long>());
                    if (cuocGoi != null)
                    {
                        if (cuocGoi.Vung == 0 && cuocGoi.G5_Type == Enum_G5_Type.DienThoai && !Config_Common.DienThoai_DieuTuDong)
                        {
                            cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                        }
                        alertNewCall.AlertFormList[lastIndex].Close();
                        if (!frmBodamInputData_V4.IsOnShowDiaLog)
                            NhapDuLieuVaoTruyenDi(cuocGoi);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShowFormInPut: ", ex);
            }
        }

        private void alertNewCall_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "btnAlertAccept")
            {
                try
                {
                    string ID = e.Info.Tag.ToString();
                    if (g_lstDienThoai != null)
                    {
                        var cuocGoi = g_lstDienThoai.FirstOrDefault(a => a.IDCuocGoi == ID.To<long>());
                        if (cuocGoi != null)
                        {
                            if (cuocGoi.Vung == 0 && cuocGoi.G5_Type == Enum_G5_Type.DienThoai && !Config_Common.DienThoai_DieuTuDong)
                            {
                                cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                            }
                            e.AlertForm.Close();

                            if(!frmBodamInputData_V4.IsOnShowDiaLog)
                                NhapDuLieuVaoTruyenDi(cuocGoi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("alertNewCall_ButtonClick: ", ex);
                }

            }

            if (e.ButtonName == "btnAlertExit")
            {
                e.AlertForm.Close();
            }
        }
        #endregion

        private void barButton_BanDoXeOnline_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Controls.Maps.FrmBanDo_Online().Show();
        }

        private void barButton_QuanLyTinNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Messenger().ShowDialog();
        }

        private void txtDiaChiApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchCuocDieuApp();
        }

        private List<CuocGoi> G_ListCuocDieuApp = new List<CuocGoi>();
        private void SearchCuocDieuApp()
        {
            try
            {
                string soXe = txtSoXe.Text.Trim();
                string soDT = txtSoDienThoaiApp.Text.Trim();
                string diachi = txtDiaChiApp.Text.Trim();
                G_ListCuocDieuApp = CuocGoi.TongDai_LayDanhSachCacCuocDieuApp(soDT, diachi, soXe);
                gridDieuApp.DataSource = G_ListCuocDieuApp;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SearchCuocDieuApp: ", ex);                
            }


        }

        private void txtSoDienThoaiApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchCuocDieuApp();
        }

        private void txtSoXe_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                SearchCuocDieuApp();
        }

        private void barButton_About_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

    }
}
