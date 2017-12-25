#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Common;
using DevExpress.XtraBars.Alerter;
using Taxi.Business;
using Taxi.Business.QuanTri;
using Taxi.Controls.BaoCao;
using Taxi.Controls.BaoCao.ThanhCong;
using Taxi.Controls.DanhMuc;
using Taxi.Controls.MessageManagement;
using Taxi.Controls.ThueBaoTuyen;
using Taxi.Utils;
using System.Diagnostics;
using Taxi.Business.DM;
using Femiani.Forms.UI.Input;
using Taxi.Entity;
using Taxi.Business.KhachDat;
using Taxi.Services;
using TaxiApplication.Base;
using System.Linq;
using Taxi.Controls.FastTaxis;
using TaxiApplication.Properties;
using TaxiOperation_TongDai.FormFastTaxi;
using Taxi.Controls.FastTaxis.TaxiTrip;
using System.Collections.Concurrent;
using System.Threading;
using Asterisk.NET.Manager;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Business.ThongTinPhanAnh;
using Taxi.Common.Extender;
using Taxi.Controls;
using TaxiApplication.GUI;
using TaxiApplication.GUI.FrmCanhBaoDieuApp;
using Taxi.Business.AutoUpdate;
using DevExpress.XtraGrid.Views.Base;
using Taxi.Data.G5.DanhMuc;
using DevExpress.XtraBars;
using Taxi.Data.CanhBaoDieuApp;
using Taxi.Controls.DanhSach.DMKhachHang;
using Taxi.Business.CheckCoDuongDai;
using DanhSachQuyen = Taxi.Business.DanhSachQuyen;
using Taxi.Controls.FormCheckCoDuongDai;
using Taxi.MessageBox;
using Taxi.Data.BanCo.Entity.TuyenThueBao;
using Taxi.Utils.Enums;
using Taxi.Data.BanCo.Entity;
using Taxi.Controls.POI;
using Taxi.Controls.frmXeBaoDiSanBay_DuongDai_Mini;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.GUI
{    
    /// <summary>
    /// Lưới điều điện thoại viên
    /// </summary>
    public partial class frmDieuHanhDienThoaiNEWCP_V3 : Form  
    {
        #region ==========================Init================================= 

        #region ------- LENH -------
        //private  string LENH1_DAMOI = "Đã mời";
        //private  string LENH2_GAPXE = "Gặp xe";
        //public   string LENH_3_KHONGXE = "Ko xe xl khách";
        //private  string LENH4_MAYBAN = "Máy bận";
        //private  string LENH5_KHONGLIENLACDUOC = "Từ chối";
        //private  string LENH3_DAXINLOI = "Đã xin lỗi khách";
        //private  string LENH_DAMOI2 = "Đã mời lần 2";
        //private  string LENH_CHOKHACH = "Chờ 5 phút";
        //private  string LENH_DOIXE = "Đổi xe 7C/4C";
        //private  string LENH_DANGGOI = "Đang gọi...";
        //private  string LENH_TRUOTCHUA = "Trượt/Chùa";
        //private  string LENH_KHONGNOIGI = "Ko nói gì";
        //private  string LENH_KHONGXE = "Ko xe xin lỗi khách";
        //private  string LENH_MOIKHACH = "Mời khách";
        //private  string LENH_HOILAIDIACHI = "Hỏi lại địa chỉ";
        //private  string LENH_KHACHDAT = "KHÁCH ĐẶT";        
        //private  string LENH_GIUROI = "Đã giữ khách";
        //private  string LENH_6_KIEMTRAKHACH = "Kiểm tra khách";
        //private  string LENH_7_MOIKHACHLAN2 = "Mời lần 2";
        //private  string LENH_8_RADAUNGO = "Ra đầu ngõ";
        //private  string LENH_9_TIEPTHIXEKHAC = "Tiếp thị 7C/4C";
        //private  string LENH_G_GIUCXE = "Giục xe";
        //private  string LENH_MATKN = "Mất kết nối";
        //private  string LENH_HUYXE_HOAN = "Hủy xe/Hoãn";
        //private  string LENH_KTX_GoiChoKhach = "Gọi cho khách,không thấy xe";
        //private  string LENH_KTX = "ko thấy xe";
        //public   string PMDH_CONST_Msg_NoCarAccept = "Ko xe nhận";
        //public   string PMDH_CONST_AppDieuDam = "App - điều đàm";
        //public   string PMDH_CONST_Msg_NoCar = "App - ko xe";
        #endregion

        #region  ------- Define  -------        
        private bool g_boolChuyenTabCuocGoiKetThuc = false; // thiet lap de load trong timer
        private bool g_boolChuyenTabCuocGoiSearch = false; // thiet lap de load trong timer
        private bool g_boolNhayMauKhiCoCuocGoiMoi = false; // mac dinh la load luon dau tien        
        private bool g_IsDieuSanBay = false;// user có được quyền điều sân bay không
        private int g_iStatus = 0; // Blink stauts
        private System.Windows.Forms.Timer TimerCapturePhone;       //Timer bắt số cuộc gọi đến!
        private System.Windows.Forms.Timer Timer_DateTimeServer;               // Timer Cộng thời gian server
        private bool g_CGLimit = false; //
        private string g_LinesDuocCapPhep = string.Empty;
        private string g_LinesDuocCapPhep_Temp = string.Empty;
        private int g_SoDong = 20; // Số dòng của cuộc gọi đã kết thúc.        
        private List<string> g_ListSoHieuXe; // Luu thong tin ds so hieu xe
        private string g_strUsername = "";
        private string g_strFullName = "";
        private int g_CountKetThuc = 0; //Dem so cuoc goi don duoc        
        public bool g_HasPopUpNewCall = false;
        //private AutoCompleteEntryCollection g_ListDataAutoComplete = new AutoCompleteEntryCollection();
        private frmDienThoaiInputDataNew_V3 g_frmInput;        
        private List<DMVung_GPSEntity> G_DMVung_GPS;
        private List<NhanVien> G_ListLaiXe = new List<NhanVien>();
        private bool hasNewCallPending = false;
        private string G_LineGop = "";
        private frmCanhBaoDieuApp frmCanhBao;

        /// <summary>
        /// Danh sách hàng đợi để gửi lần lượt tiếp tục
        /// </summary>
        private List<QueueCuocKhach> QueueCuocKhachSaoChep = new List<QueueCuocKhach>();
        /// <summary>
        /// BackgroundWorker dùng để check kết nối server PMDH - Server Online
        /// </summary>
        private BackgroundWorker backGroundPingApp;

        public static Dictionary<int, List<KeyValuePair<float, float>>> G_DicVungToaDo;        // Vùng,Kinh độ,Vĩ độ
        public int G_IndexKhachVIP = 0;
        public int G_IndexKhachVang = 0;
        public int G_IndexKhachBac = 0;
        public int G_IndexKHThanThiet = 0;
        public DateTime g_TimeServer = DateTime.MinValue;

        private List<Province> G_arrProvince { get; set; }

        private List<District> G_arrDistrict { get; set; }

        private List<Commune> G_arrCommune { get; set; }

        private string g_COMPort = "";
        

        #region ==================== Thông số kết nối tổng đài =======================
        /// <summary>
        /// Line của Tổng đài PBX IP cho pc này
        /// </summary>
        private string g_lineIPPBX = string.Empty;
        private string g_lineIPPBX1 = string.Empty;
        private string g_lineIPPBX2 = string.Empty;
        public  string g_LinesDuocCapPhepGoiRa = string.Empty;
        public static frmCallOut frmCalling = new frmCallOut();
        #endregion
        #endregion

        #endregion

        #region =======================Constructor=============================
        public frmDieuHanhDienThoaiNEWCP_V3()
        {
            InitializeComponent();
            this.ucPanelCommand.HeThongLayCauHinh = 1;//*sign
            this.ucPanelCommand.DisplayCommandInPanel();
            pnlWelcome.Visible = true;   
        }

        #endregion

        #region ====================Load Form-Set Data=========================

        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
            try
            {                
                if (DieuHanhTaxi.CheckConnection())
                {
                    CheckConnectServiceSyncOnline();
                    //ThongTinCauHinh.LayThongTinCauHinh();
                    //Config_Common.LoadConfigCommon();
                    RealTimeEnvironment.IniRealTime();
                    //btnItemCapNhatDuLieuXe.PerformClick();
                    if (!Debugger.IsAttached)
                        new LicenseBL().CheckLicense();
                    //LoadAllCommonBL();                                                   
                    Text = Configuration.GetCompanyName() + " - Điện thoại viên ";
                    QuanTriCauHinh.IpAddress = QuanTriCauHinh.GetIPPC();
                    LayCauHinhQuanTri();         
                    LayLineVungCuaNguoiDung();
                    if (Debugger.IsAttached)
                    {
                        g_LinesDuocCapPhep = "173;178;1001;1002";
                        g_lineIPPBX = "205";
                        Config_Common.DienThoai_DieuTuDong = true;
                    }

                    if (g_LinesDuocCapPhep.Length > 0)
                    {
                        LayDuLieuTheoLineDienThoai();
                    }
                    else
                    {
                        new MessageBoxBA().Show(this,"Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.","Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        Application.Exit();
                    }
                    Global.LineDuocCapPhep = Global.LineDuocCapPhep_MacDinh = g_LinesDuocCapPhep;

                    if (Debugger.IsAttached)
                    {
                        //QuanTriCauHinh.MoHinh = MoHinh.TD_DT;
                    }

                    if (ThongTinCauHinh.GPS_TrangThai)
                    {
                        InitTimerCheckInternet(); 
                        Global.HasGPS = true;
                        if (Config_Common.MapOnline)
                            Maps_Online.StartTimerLoadMap();
                        Maps_Online.SetPositionConfig();
                    }

                    KhoiTaoFormCanhBao();

                    HienThiTheoCauHinh();


                    grvChoGiaiQuyet.Appearance.FocusedRow.ForeColor = Config_Common.Grid_FocusedRow_Color;
                    grvChoGiaiQuyet.Appearance.FocusedRow.BackColor = Config_Common.Grid_FocusedRow_BackColor;//Color.FromArgb(0x00, 0xCC, 0xFF);
                    if (Config_Common.Grid_Font != "" && Config_Common.LuoiCuocGoi_FontSize_TiepNhan > 0)
                    {
                        grvChoGiaiQuyet.Appearance.Row.Font = new System.Drawing.Font(new FontFamily(Config_Common.Grid_Font), Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
                    }
                    if (Config_Common.Grid_HorzLineColor != null && !Config_Common.Grid_HorzLineColor.IsEmpty)
                    {
                        grvChoGiaiQuyet.Appearance.HorzLine.BackColor = Config_Common.Grid_HorzLineColor;
                    }

                    grdChoGiaiQuyet.Focus();

                    if (Config_Common.DienThoai_DieuTuDong)
                        status5.Visibility = BarItemVisibility.Always;
                    else
                        status5.Visibility = BarItemVisibility.Never;
                }
                else
                {
                    new MessageBoxBA().Show(this,
                        "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.",
                        "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhDienThoaiNEW_Load 2:", ex);
                if (TimerCapturePhone != null) TimerCapturePhone.Enabled = false;
                Application.Exit();
            }
        }

        //private void LoadAllCommonBL()
        //{
        //    try
        //    {
        //        CommonBL.ReLoadCommon();
        //        //CommonBL.LoadVehicles();
        //        //CommonBL.LoadDrivers_Active();
        //        //CommonBL.LoadStaxiLoaiXe();
        //        //CommonBL.ListAllCode = AllCodeEntity.Inst.GetListAll();
        //        //if (Config_Common.NhapTuyenDuongDai || Config_Common.App_DieuXeHopDong)
        //        //    CommonBL.LoadTuyenDuongDai();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("LoadAllCommonBL: ",ex);                
        //    }
        //}

        private void LayCauHinhQuanTri()
        {
            try
            {
                CommonBL.ListQuanTriCauHinh = QuanTriCauHinhEntity.Inst.GetListAll();
                string ip = QuanTriCauHinh.IpAddress;
                var temp = CommonBL.ListQuanTriCauHinh.FirstOrDefault(a => a.IP_Address == ip&&a.IsMayTinh=="DT");
                if (temp != null)
                {
                    g_HasPopUpNewCall = temp.HasPopUpNewCall > 0;
                    alertNewCall.AutoFormDelay = temp.HasPopUpNewCall*1000;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LayCauHinhQuanTri: ", ex);     
            }
        }
        
        private void HienThiTheoCauHinh()
        {
            if (!Config_Common.NhapTuyenDuongDai)
            {
                HideAllLongColumns();
            }
            if (Config_Common.CauHinhThueBaoTuyen)
            {
                btnTraCuuGiaCuoc.Visibility = BarItemVisibility.Always;
                btnNhatKyThueBao.Visibility = BarItemVisibility.Always;
            }
            if (Config_Common.CuocOnline)
            {
                uc_CuocAppKH1.Start();
            }

            if (Config_Common.App_SOS_Alert)
                Taxi.Controls.SOS.ProcessCanhBaoSos.Start(g_LinesDuocCapPhep);

            if (Config_Common.App_SendSMS_Customer && ThongTinDangNhap.HasPermission("01020504"))
            {
                btnItemGuiTinNhanSMS.Visibility = BarItemVisibility.Always;     
            }

            if (Config_Common.NhapChotCoDuongDai == 0)
            {
                barButton_ChotCoDD_Mini.Visibility = BarItemVisibility.Never;
                barButton_ChotCoDD.Visibility = BarItemVisibility.Never;
                barSubItem_SanBayDuongDai.Visibility = BarItemVisibility.Never;
            }
            else if (Config_Common.NhapChotCoDuongDai == 1)
            {
                barButton_ChotCoDD_Mini.Visibility = BarItemVisibility.Always;
                barButton_ChotCoDD.Visibility = BarItemVisibility.Never;
                btnItemDanhSachChotCoDuongDai.Visibility = BarItemVisibility.Always;
            }
            else
            {
                barButton_ChotCoDD_Mini.Visibility = BarItemVisibility.Never;
                barButton_ChotCoDD.Visibility = BarItemVisibility.Always;
                btnItemDanhSachChotCoDuongDai.Visibility = BarItemVisibility.Always;
            }
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

        private void LayDuLieuTheoLineDienThoai()
        {
            if (Config_Common.TongDai_KhungDiaChi == KhungDiaChi.Tren)
                panel_KhungDiaChi.Dock = DockStyle.Top;
            lblXeDon_Help.Visible = QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini;
            lblXeNhan_Help.Visible = QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini;
            lblXeDon_.Visible = QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini;
            lblXeDon_.Visible = true;

            ThietLapKhungTroGiup();
            g_ListSoHieuXe = Xe.GetListSoHieuXe();
            g_TimeServer = DieuHanhTaxi.GetTimeServer();
            _dateMax = _dateMax3 = _dateMaxSB = _dateMax_Khac = g_TimeServer;

            IniFunc();
            LoadAllCuocGoi(g_LinesDuocCapPhep);
            if (Config_Common.DieuSanBay != 0)
            {
                LoadAllCuocGoi_SB();
            }
            //LoadDuLieuForAutoComplete();
            splitContainer.Panel2Collapsed = true;
            btnCollspase.Visible = false;
            if (Config_Common.GridConfig == (int)Grid_Config.Has_Grid_Right)
            {
                btnCollspase.Visible = true;
                LoadAllCuocGoi_Khac(g_LinesDuocCapPhep);
                HienThiLuoi_Khac(true, true);
            }
            #region validate Login            
            if (Config_Common.ValidateLogin)
            {
                InitValidateLogin();
            }
            #endregion
            ThongTinDangNhap.Line_Vung = g_LinesDuocCapPhep;

            LoadListLaiXe();

            G_DMVung_GPS = LoadDanhMucVung_GPS();

            Action ProcessVung = () =>
            {
                G_DicVungToaDo = new Dictionary<int, List<KeyValuePair<float, float>>>();
                if (G_DMVung_GPS != null)
                {
                    LayDanhMucVungGPS();
                }
            };
            ProcessVung();
            pnlWelcome.Visible = false;
            //SetAllCommandFromDB();
            if (!CheckIn()) return;
            tabCuocSanBay.PageVisible = g_IsDieuSanBay;
            if (g_IsDieuSanBay)
            {
                //QuanTriCauHinh.MoHinh = MoHinh.TongDaiMini;
            }

            InitTimerCapturePhone(); // Khoi tao bat cuoc goi
            tabCuocGoiChoGiaiQuyet.Select();
            KhoiTaoFormNhapLieuDienThoai();
            CauHinhAsterisk();
        }

        private void KhoiTaoFormCanhBao()//*sign
        {
            if (Config_Common.CanhBaoLenhLaiXe == 1 || g_IsDieuSanBay)
            {
                this.btnItemCanhBao.Visibility = BarItemVisibility.Always;
                frmCanhBao = new frmCanhBaoDieuApp(g_LinesDuocCapPhep);
                frmCanhBao.EventSelectRow += frmCanhBao_EventSelectRow;
                frmCanhBao.EventActivateForm += frmCanhBao_EventActivateForm;
                frmCanhBao.EventKeysEnter += frmCanhBao_EventKeysEnter;
                frmCanhBao.EventCallOut += frmCanhBao_EventCallOut;
                if (frmCanhBao._lstObjectTruocThayDoi.Count > 0)
                {
                    frmCanhBao.Show();
                }
                else
                {
                    frmCanhBao.Hide();
                }
            }
        }

        private void CauHinhAsterisk()
        {
            if (Config_Common.Asterisk_QuickCall)
            {
                if (g_lineIPPBX == "")
                {
                    if (string.IsNullOrEmpty(g_LinesDuocCapPhepGoiRa))
                        g_lineIPPBX = AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhep);
                    else
                        g_lineIPPBX = AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhepGoiRa);
                    if (Debugger.IsAttached)
                    {
                        g_lineIPPBX = "210";
                    }
                }
                InitPBXIP();
            }
            else if (Config_Common.DTV_QUICKCALL_COM)
            {
                KhoiTaoCOMPort();
                status6.EditValue = "COM: " + g_COMPort;
            }
        }

        private void KhoiTaoFormNhapLieuDienThoai()
        {
            g_frmInput = new frmDienThoaiInputDataNew_V3(RealTimeEnvironment.ListDataAutoComplete, g_CGLimit, G_DMVung_GPS);
            g_frmInput.Owner = this;
            g_frmInput.g_ListSoHieuXe = g_ListSoHieuXe;
            g_frmInput.ListNhanVien = G_ListLaiXe;
            //g_frmInput.g_ListDataAutoComplete = g_ListDataAutoComplete;
            //g_frmInput.g_CGLimit = g_CGLimit;
            g_frmInput.OKCloseFormEvent += SaveData_Click;
            g_frmInput.HienThiCuocMoiEvent += g_frmInput_HienThiCuocMoiEvent;
            g_frmInput.GetTimeServerEvent += g_frmInput_GetTimeServerEvent;
            g_frmInput.EventCallOut += g_frmInput_EventCallOut;
            if(g_HasPopUpNewCall)
                g_frmInput.HienThiPopUpCuocGoiMoiEvent += g_frmInput_HienThiPopupCuocGoiMoi;//*sign //Cấu hình để đăng ký sự kiện
        }

        private void g_frmInput_HienThiPopupCuocGoiMoi()
        {
            try
            {
                HienThiPopUpCuocGoiMoi(g_CuocGoiHienPopUp);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("g_frmInput_HienThiPopupCuocGoiMoi: ",ex);
            }
        }

        private void LayDanhMucVungGPS()
        {
            try
            {
                foreach (var item in G_DMVung_GPS)
                {
                    G_DicVungToaDo.Add(item.KenhVung, item.ToaDoVung.Split('-').Select(p =>
                    {
                        var pi = p.Split(';');
                        float vd;
                        float kd;
                        if (Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator == ",")
                        {
                            //Thay thế '.' => ','
                            pi[0] = pi[0].Replace('.', '#');
                            pi[0] = pi[0].Replace(',', '.');
                            pi[0] = pi[0].Replace('#', ',');

                            pi[1] = pi[1].Replace('.', '#');
                            pi[1] = pi[1].Replace(',', '.');
                            pi[1] = pi[1].Replace('#', ',');
                        }
                        float.TryParse(pi[0], out vd);
                        float.TryParse(pi[1], out kd);
                        return new KeyValuePair<float, float>(kd, vd);
                    }).ToList());
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi load kênh vùng", ex);
            }
        }

        private void LayLineVungCuaNguoiDung()
        {
            try
            {
                using (DataTable dt = QuanTriCauHinh.G5_GetLines_LoaiXeOfPCDienThoai(QuanTriCauHinh.IpAddress))
                {
                    if (dt.Rows != null && dt.Rows.Count > 0)
                    {
                        g_LinesDuocCapPhep = dt.Rows[0]["Line_Vung"].ToString();
                        {
                            g_lineIPPBX = dt.Rows[0]["Extension"] != null ? dt.Rows[0]["Extension"].ToString() : "";
                            if (Global.IsDebug)
                            {
                                new MessageBoxBA().Show("Extension:"+g_lineIPPBX);
                            }
                            if (g_lineIPPBX != "")
                            {
                                string[] arrExt = g_lineIPPBX.Split(';');
                                g_lineIPPBX1 = arrExt[0];
                                AsteriskInfo.Extension_One = g_lineIPPBX1;
                                if (arrExt.Length > 1)
                                {
                                    g_lineIPPBX2 = arrExt[1];
                                    AsteriskInfo.Extension_Two = g_lineIPPBX2;
                                }
                            }
                        }
                        Config_Common.DienThoai_DieuTuDong = dt.Columns.Contains("G5_Type") && dt.Rows[0]["G5_Type"].ToString() == "1";
                        Config_Common.G5_PinMap = dt.Columns.Contains("G5_PinMap") && dt.Rows[0]["G5_PinMap"].ToString() == "1";

                        if (Config_Common.GopLine || ThongTinCauHinh.GopKenh_TrangThai)
                            G_LineGop = dt.Rows[0]["LineGop"] == DBNull.Value
                                ? g_LinesDuocCapPhep
                                : dt.Rows[0]["LineGop"].ToString();
                        QuanTriCauHinh.MoHinh = dt.Columns.Contains("MoHinh") && dt.Rows[0]["MoHinh"] != DBNull.Value && (string)dt.Rows[0]["MoHinh"] != "" && (string)dt.Rows[0]["MoHinh"] != "0" ? (MoHinh)dt.Rows[0]["MoHinh"].To<int>() : MoHinh.TD_DT;
                    }
                    else
                    {
                        g_LinesDuocCapPhep = string.Empty;
                    }
                }

                g_LinesDuocCapPhep_Temp = g_LinesDuocCapPhep;
                if (Config_Common.GopLine)
                    g_LinesDuocCapPhep = G_LineGop;
                using (DataTable dt = QuanTriCauHinh.GetLINEGOIRA_ByIpAddress(QuanTriCauHinh.IpAddress))
                {
                    if (dt.Rows != null && dt.Rows.Count > 0)
                    {
                        g_LinesDuocCapPhepGoiRa = dt.Rows[0]["Line_Vung"].ToString();
                    }
                    else
                    {
                        g_LinesDuocCapPhepGoiRa = string.Empty;
                    }
                }

                //Load thông tin tỉnh thành phố! *sign 
                G_arrProvince = Province.GetAllProvince();
                G_arrDistrict = District.GetAllDistrict();
                G_arrCommune = Commune.GetAllCommune();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LayLineVungCuaNguoiDung  --->   GetLines_LoaiXeOfPCDienThoai", ex);
            }
        }

        //private void SetAllCommandFromDB()
        //{
        //    try
        //    {
        //        //*command
        //        if (CommonBL.Commands.Count > 0)
        //        {
        //            LENH1_DAMOI = CommonBL.GetNameByCode(CommandCode.DaMoi, 1);
        //            LENH2_GAPXE = CommonBL.GetNameByCode(CommandCode.GapXe, 1);
        //            LENH_3_KHONGXE = CommonBL.GetNameByCode(CommandCode.KhongXeXLDT, 1);
        //            LENH4_MAYBAN = CommonBL.GetNameByCode(CommandCode.MayBan, 1);
        //            LENH5_KHONGLIENLACDUOC = CommonBL.GetNameByCode(CommandCode.TuChoi, 1);
        //            LENH3_DAXINLOI = CommonBL.GetNameByCode(CommandCode.DaXinLoi, 1);
        //            LENH_DAMOI2 = CommonBL.GetNameByCode(CommandCode.DaMoiLan2, 1);
        //            LENH_CHOKHACH = CommonBL.GetNameByCode(CommandCode.ChoKhach, 1);//"Chờ 5 phút";
        //            LENH_DOIXE = CommonBL.GetNameByCode(CommandCode.DoiXe, 1);//"Đổi xe 7C/4C";
        //            LENH_DANGGOI = CommonBL.GetNameByCode(CommandCode.DangGoi, 1);//"Đang gọi...";
        //            LENH_TRUOTCHUA = CommonBL.GetNameByCode(CommandCode.TruotChua, 1);
        //            LENH_KHONGNOIGI = CommonBL.GetNameByCode(CommandCode.KoNoiGi, 1);//"Ko nói gì";
        //            LENH_KHONGXE = CommonBL.GetNameByCode(CommandCode.KhongXeXLDT, 1);
        //            LENH_MOIKHACH = CommonBL.GetNameByCode(CommandCode.MoiKhach, 2);
        //            LENH_HOILAIDIACHI = CommonBL.GetNameByCode(CommandCode.HoiLaiDiaChi, 2);
        //            LENH_KHACHDAT = CommonBL.GetNameByCode(CommandCode.KhachDat, 1);
        //            LENH_GIUROI = CommonBL.GetNameByCode(CommandCode.GiuRoi, 1);
        //            LENH_6_KIEMTRAKHACH = CommonBL.GetNameByCode(CommandCode.KiemTraKhach, 2);
        //            LENH_7_MOIKHACHLAN2 = CommonBL.GetNameByCode(CommandCode.MoiLan2, 2);
        //            LENH_8_RADAUNGO = CommonBL.GetNameByCode(CommandCode.RaDauNgo, 2);
        //            LENH_9_TIEPTHIXEKHAC = CommonBL.GetNameByCode(CommandCode.TiepThiXe, 1);//"Tiếp thị 7C/4C";
        //            LENH_G_GIUCXE = CommonBL.GetNameByCode(CommandCode.GiucXe, 1);
        //            LENH_MATKN = CommonBL.GetNameByCode(CommandCode.MatKetNoi, 1);
        //            LENH_HUYXE_HOAN = CommonBL.GetNameByCode(CommandCode.HuyHoan, 1);
        //            LENH_KTX_GoiChoKhach = CommonBL.GetNameByCode(CommandCode.GoiChoKhachKTX, 1);
        //            LENH_KTX = CommonBL.GetNameByCode(CommandCode.KhongThayXe, 1);

        //            PMDH_CONST_Msg_NoCarAccept = CommonBL.GetNameByCode(CommandCode.KoXeNhan, 1);// "Ko xe nhận";
        //            PMDH_CONST_AppDieuDam = CommonBL.GetNameByCode(CommandCode.AppDieuDam, 1);// "App - điều đàm";
        //            PMDH_CONST_Msg_NoCar = CommonBL.GetNameByCode(CommandCode.AppKhongXe, 1); // "App - ko xe";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("SetAllCommandFromDB", ex);
        //    }
        //}

        /// <summary>
        /// Kiem tra ket noi Service Dong Bo Xe
        /// </summary>
        private void CheckConnectServiceSyncOnline()
        {
            backGroundPingApp = new BackgroundWorker();
            backGroundPingApp.DoWork += PingApp_DoWork;
            BackgroundWorker PingWcf = new BackgroundWorker();
            PingWcf.DoWork += (sender1, e1) => Service_Common.PingWcf();
            PingWcf.RunWorkerAsync();
        }

        private void g_frmInput_EventCallOut(string PhoneNumber, string DiaChi)
        {
            HienThiFormGoiDienThoai(PhoneNumber, DiaChi, true, g_lineIPPBX1);
        }

        private DateTime g_frmInput_GetTimeServerEvent()
        {
            return g_TimeServer;
        }

        private void frmCanhBao_EventCallOut(string PhoneNumber, string DiaChi)
        {
            HienThiFormGoiDienThoai(PhoneNumber, DiaChi, true, g_lineIPPBX1);
        }

        /// <summary>
        /// Sự kiện nhấn Enter trên form cảnh báo thì tương ứng enter trên form chính
        /// </summary>
        private void frmCanhBao_EventKeysEnter(int rowPosition)
        {
            NhapDuLieuVaoTruyenDiV2(rowPosition);
        }
        /// <summary>
        /// sự kiện chuyển qua lại giữa form chính và form cảnh báo
        /// </summary>
        private void frmCanhBao_EventActivateForm()
        {
            this.Activate();
        }
        /// <summary>
        /// sự kiện select row trên form cảnh báo thì focus vào row tương ứng trên form chính
        /// </summary>
        private void frmCanhBao_EventSelectRow(Guid bookId, long idCuocGoi, ref CuocGoi cuocGoi, ref int rowPosition)
        {
            for (int i = 0; i < grvChoGiaiQuyet.RowCount; i++)
            {
                var row = (CuocGoi)grvChoGiaiQuyet.GetRow(i);

                if (row != null && (row.BookId == bookId) || row.IDCuocGoi == idCuocGoi)
                {
                    grvChoGiaiQuyet.FocusedRowHandle = i;
                    cuocGoi = row;
                    rowPosition = i;
                    return;
                }
            }
        }

        /// <summary>
        /// hàm thực hiện lấy dữ liệu autocomplete
        /// </summary>
        //private void LoadDuLieuForAutoComplete()
        //{
        //    if (g_ListDataAutoComplete == null)
        //        g_ListDataAutoComplete = new AutoCompleteEntryCollection();

        //    string address;
        //    string streetAbbr;
        //    float kd;
        //    float vd;
        //    using (DataTable dt = new DiaDanh().GetRoadData_Autocomplete())
        //    {
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                address = row["Street"].ToString();
        //                streetAbbr = row["StreetAbbr"].ToString();
        //                kd = float.Parse(row["KinhDo"].ToString());
        //                vd = float.Parse(row["ViDo"].ToString());

        //                g_ListDataAutoComplete.Add(new AutoCompleteEntry(address, kd, vd, streetAbbr));
        //            }
        //        }
        //    }
        //}

        #region Cuoc Gọi Line Khác

        private void TimVaCapNhatCuocGoi_Khac(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi)
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
                    var cuocGoiCurrent = listCuocGoiHienTai[index];
                    cuocGoiCurrent.MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai;
                    cuocGoiCurrent.MaNhanVienDienThoai = cuocGoi.MaNhanVienDienThoai;
                    cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                    cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;
                    cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                    cuocGoiCurrent.LenhTongDai = cuocGoi.LenhTongDai;
                    cuocGoiCurrent.Vung = cuocGoi.Vung;
                    cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                    cuocGoiCurrent.PhoneNumber = cuocGoi.PhoneNumber;
                    cuocGoiCurrent.Line = cuocGoi.Line;
                    cuocGoiCurrent.LoaiXe = cuocGoi.LoaiXe;
                    cuocGoiCurrent.SoLuong = cuocGoi.SoLuong;
                    cuocGoiCurrent.GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                    cuocGoiCurrent.GhiChuTongDai = cuocGoi.GhiChuTongDai;
                    cuocGoiCurrent.GhiChuLaiXe = cuocGoi.GhiChuLaiXe;
                    cuocGoiCurrent.LenhLaiXe = cuocGoi.LenhLaiXe;
                    cuocGoiCurrent.G5_Type = cuocGoi.G5_Type;
                    cuocGoiCurrent.G5_SendDate = cuocGoi.G5_SendDate;
                    cuocGoiCurrent.G5_Step = cuocGoi.G5_Step;
                    cuocGoiCurrent.BookId = cuocGoi.BookId;
                    cuocGoiCurrent.G5_StepLast = cuocGoi.G5_StepLast;
                    cuocGoiCurrent.BTBG_NoiDungXuLy = cuocGoi.BTBG_NoiDungXuLy;
                }
                else
                {
                    listCuocGoiHienTai.Insert(0, cuocGoi);
                }
            }
            else
            {
                listCuocGoiHienTai = new List<CuocGoi>();
                listCuocGoiHienTai.Insert(0, cuocGoi);
            }
        }

        #endregion

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
            // chưa xử lý được tạm thời bỏ qua
            //int n = listCuocHienTai.Count;
            //int vitricuocgoi = viTri;
            //for (int i = viTri + 1; i < n; i++)
            //{
            //    if (listCuocHienTai[i].PhoneNumber == cg.PhoneNumber)
            //    {
            //        cg.GoiLai = true;
            //        var cgCurrent = listCuocHienTai[i];
            //        listCuocHienTai.Insert(vitricuocgoi, cgCurrent);
            //        listCuocHienTai.RemoveAt(i + 1);
            //        vitricuocgoi++;
            //    }
            //}
        }

        /// <summary>
        /// Hàm trả về ds sách cuộc gọi 
        /// </summary>
        /// <param name="linesChoPhep">line của máy này được phép</param>
        /// <param name="soDong">so dòng (row)</param>
        private void LoadCacCuocGoiKetThuc(string linesChoPhep, int soDong)
        {
            try
            {
                if (g_IsDieuSanBay)
                {
                    grcCuocGoiKetThuc.DataSource = CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyetSB(linesChoPhep, soDong);
                }
                else if (ThongTinCauHinh.FT_Active)
                {
                    grcCuocGoiKetThuc.DataSource = CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyet(linesChoPhep, soDong);
                }
                else
                {
                    grcCuocGoiKetThuc.DataSource = CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyetNotFT(linesChoPhep, soDong);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadCacCuocGoiKetThuc:", ex);
                new MessageBoxBA().Show("Load cuộc gọi kết thúc Lỗi ","Thông báo");
            }
        }

        /// <summary>
        /// Load du lieu VungGPS theo Kenh
        /// </summary>
        private List<DMVung_GPSEntity> LoadDanhMucVung_GPS()
        {
            return new DMVung_GPS().GetAllDSVungKenh();
        }

        /// <summary>
        /// Load danh sách lái xe của hệ thống
        /// </summary>
        private void LoadListLaiXe()
        {
            G_ListLaiXe = new NhanVien().GetListNhanViens();
        }

        private void ChenCuocSaoChep(List<CuocGoi> list, CuocGoi cuocGoi)
        {
            try
            {
                if(list == null) list = new List<CuocGoi>();
                int index = 0;

                if(cuocGoi.G5_CopyId > 0 && cuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                {
                    for(int i = 0; i < list.Count; i++)
                    {
                        if (list[i].IDCuocGoi == cuocGoi.G5_CopyId)
                        {
                            index = i + 1;
                            break;
                        }
                    }
                }
                list.Insert(index, cuocGoi);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ChenCuocSaoChep: ", ex);
            }
        }
        private void CauHinhLuoiDieuSanBay()//*sign
        {
            colThoiGianHen.Visible = true;
            colThoiGianHen.VisibleIndex = 3;
        }

        #endregion

        #region ======================Validation Form==========================

        /// <summary>
        /// Thiết lập panel trợ giúp
        /// </summary>
        private void ThietLapKhungTroGiup()
        {
            panelTopHelp.Size = new Size(754, 83);
            panelTopHelp.Location = new Point(Size.Width - (panelTopHelp.Size.Width + 15 + 32), 0);
            btnHelp.Location = new Point(Size.Width - (btnHelp.Size.Width + 15), 0);
            btnCollspase.Location = new Point(Size.Width - (btnCollspase.Size.Width + 15), 40);
            btnReloadGridCuocGoi.Location = new Point(Size.Width - (btnReloadGridCuocGoi.Size.Width + 15), 80);
        }

        /// <summary>
        /// Form đăng nhập vào hệ thống, goi form frmCheckInOut
        /// </summary>        
        private bool CheckIn()
        {
            frmCheckInOut frm = new frmCheckInOut();
            frm.ShowDialog();
            Global.IsDieuSanBay = frm.IsDieuSanBay;
            g_IsDieuSanBay = frm.IsDieuSanBay;
            g_strUsername = ThongTinDangNhap.USER_ID;
            g_strFullName = ThongTinDangNhap.FULLNAME;
            if (g_strUsername.Length > 0)
            {
                if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, QuanTriCauHinh.IpAddress))
                {
                    string alert = new MessageBoxBA().Show(this,
                        "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi",
                        MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Warning);
                    if (alert == "Yes")
                    {
                        ThongTinDangNhap.CheckOutByIpAddress(QuanTriCauHinh.IpAddress);
                    }
                    else
                    {
                        Application.Exit();
                        return false;
                    }
                }
                //Kiểm tra xem user này trước đây đã có ai dăng nhập chưa.                   
                if (!Config_Common.DangNhapNhieuMay &&
                    ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, QuanTriCauHinh.IpAddress))
                {
                    new MessageBoxBA().Show(this,
                        "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.",
                        "Thông báo lỗi", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    ThongTinDangNhap.USER_ID = "";
                    g_strUsername = "";
                    g_strFullName = "";
                    Application.Exit();
                    return false;
                }

                //Nếu Cho đăng nhập ở nhiều máy thì logout ở các máy khác đi
                else if (Config_Common.DangNhapNhieuMay)
                {
                    ThongTinDangNhap.CheckOut_AllIn_OtherIP(g_strUsername, QuanTriCauHinh.IpAddress);
                }
                if (!ThongTinDangNhap.CheckIn_V2(g_strUsername, QuanTriCauHinh.IpAddress, g_IsDieuSanBay))
                {
                    new MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi",
                        MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    ThongTinDangNhap.USER_ID = "";
                    g_strUsername = "";
                    g_strFullName = "";
                    Application.Exit();
                    return false;
                }
                else
                {
                    if (!((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) ||
                            (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
                    {
                        new MessageBoxBA().Show(this, "Bạn không có quyền điều hành điện thoại.",
                            "Thông báo lỗi", MessageBoxButtonsBA.OK,
                            MessageBoxIconBA.Error);
                        ThongTinDangNhap.CheckOutByIpAddress(QuanTriCauHinh.IpAddress);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_strFullName = "";
                        Application.Exit();
                        return false;
                    }
                    if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.App_CARRole))
                    {
                        Global.HasCarRole = true;
                    }
                }

                Text = String.Format("{0} - Điện thoại viên  [{1} - {2}] - {3} - {4}",
                    Configuration.GetCompanyName(), g_LinesDuocCapPhep, QuanTriCauHinh.IpAddress,
                    ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME);
                status4.EditValue = string.Format("NV : {0} - {1}", g_strUsername, g_strFullName);
                if (ThongTinDangNhap.USER_ID != "admin")
                {
                    // Thực hiện phân quyền trên menu
                    // PhanQuyenMenu(uiCommandBar2, ThongTinDangNhap.PermissionsFull);
                    // PhanQuyenMenu(uiCommandBar1, ThongTinDangNhap.PermissionsFull);
                }

                grvChoGiaiQuyet.LoadLayouFromStringXml(G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvChoGiaiQuyet.Name, ThongTinDangNhap.USER_ID));
                grvCuocGoiKetThuc.LoadLayouFromStringXml(G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvCuocGoiKetThuc.Name, ThongTinDangNhap.USER_ID));
                grvTimKiemThongTinCuoc.LoadLayouFromStringXml(G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvTimKiemThongTinCuoc.Name, ThongTinDangNhap.USER_ID));
                if (Config_Common.CotKhachHen)
                {
                    CauHinhLuoiDieuSanBay();
                }
                else
                {
                    colThoiGianHen.Visible = false;
                }
                return true;
            }
            else
            {
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                g_strFullName = "";
                return true;
            }
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
                new MessageBoxBA().Show(this, message,
                    "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }

            status4.EditValue = " NV điện thoại : ";
            ThongTinDangNhap.USER_ID = "";
            try
            {
                grvChoGiaiQuyet.ResetLayout();
                grvChoGiaiQuyet_Khac.ResetLayout();
                grvTimKiemThongTinCuoc.ResetLayout();
            }
            catch (Exception)
            {
            }
            CheckIn();
            tabCuocSanBay.PageVisible = g_IsDieuSanBay;
        }

        #endregion

        #region ========================Form Events============================

        private void DatHen()
        {
            if (grvChoGiaiQuyet.SelectedRowsCount > 0)
            {
                CuocGoi objCuocGoi = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();

                KhachDatBL objKhachDat = new KhachDatBL
                {
                    CreatedBy = ThongTinDangNhap.USER_ID,
                    DiaChi = objCuocGoi.DiaChiDonKhach,
                    SoDienThoai = objCuocGoi.PhoneNumber,
                    SoLuongXe = objCuocGoi.SoLuong,
                    ThoiDiemBatDau = DateTime.Now,
                    ThoiDiemKetThuc = DateTime.Now,
                    LoaiXe = objCuocGoi.G5_CarType,
                    TenLoaiXe = objCuocGoi.LoaiXe,
                    ThoiDiemTiepNhan = DateTime.Now,
                    VungKenh = objCuocGoi.Vung,
                    SoPhutBaoTruoc = 10,
                    GhiChu = "",
                    IsLapLai = false,
                    GioDon = DateTime.Now.AddMinutes(10)
                };
                frmKhachDat formKhachDat = new frmKhachDat(objKhachDat, RealTimeEnvironment.ListDataAutoComplete, false);
                formKhachDat.ShowDialog();
            }
        }
        private void alertNewCall_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {

            if (e.ButtonName == "btnAlertAccept")
            {            
                try
                {
                    string ID = e.Info.Tag.ToString();
                    if (ListCurrent != null)
                    {
                        var cuocGoi = ListCurrent.FirstOrDefault(a => a.IDCuocGoi == ID.To<long>());
                        if (cuocGoi != null)
                        {
                            if (cuocGoi.Vung == 0 && cuocGoi.G5_Type == Enum_G5_Type.DienThoai && !Config_Common.DienThoai_DieuTuDong)
                            {
                                cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                            }
                            e.AlertForm.Close();
                            g_frmInput.LoadCuocGoi(cuocGoi); 
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
        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "tabCuocGoiDaGiaiQuyet")
            {
                g_boolChuyenTabCuocGoiKetThuc = true;
                g_boolChuyenTabCuocGoiSearch = false;
            }
            else if (e.Page.Name == "tabCuocGoiChoGiaiQuyet")
            {
                g_boolChuyenTabCuocGoiKetThuc = false;
                g_boolChuyenTabCuocGoiSearch = false;
            }
            else
            {
                g_boolChuyenTabCuocGoiKetThuc = true;
                g_boolChuyenTabCuocGoiSearch = true;
                txtDiaChi.Focus();
            }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            panelTopHelp.Visible = panelTopHelp.Visible != true;
        }

        /// <summary>
        /// Hiển thị cuộc đầu tiền
        /// </summary>
        private void g_frmInput_HienThiCuocMoiEvent(object sender, EventArgs e)
        {
            hasNewCallPending = false;
            NhapDuLieuVaoTruyenDiV2(0);
        }
        #region XU LY HOTKEY

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1://Lưu POI
                    toolStripMenu_AddPOI.PerformClick();
                    return true;
                case Keys.F2:
                    AddPhoneNumToContact();
                    return true;
                case Keys.F6:
                    frmCanhBao.Activate();
                    return true;
                case Keys.Control | Keys.Down:
                    if (tabMain.SelectedTabPageIndex == 3)
                    {
                        if (tabControl1.SelectedIndex == 0)
                        {
                            ctrlListBook_ChoXuLy.ForcusGrid();
                        }
                        else
                        {
                            ctrlListBook_DaKetThuc.ForcusGrid();
                        }
                    }
                    return true;
                case Keys.Control | Keys.Up:
                    if (tabMain.SelectedTabPageIndex == 3)
                    {
                        if (tabControl1.SelectedIndex == 0)
                        {
                            ctrlDanhSachXeChieuVe_ChoXuLy.ForcusGrid();
                        }
                        else
                        {
                            ctrlDanhSachXeChieuVe_DaKetThuc.ForcusGrid();
                        }
                    }
                    return true;
                case Keys.Alt | Keys.F4:
                    CheckOut();
                    return true;
                case Keys.Alt | Keys.S:
                    if (tabMain.SelectedTabPageIndex == 3)
                        break;
                    if (g_boolChuyenTabCuocGoiSearch == true)
                        txtSoDT.Focus();
                    return true;
                case Keys.Alt | Keys.D:
                    if (g_boolChuyenTabCuocGoiSearch == true)
                        txtDiaChi.Focus();
                    return true;
                case Keys.Alt | Keys.X:
                    if (g_boolChuyenTabCuocGoiSearch == true)
                        txtXeNhan.Focus();
                    return true;
                case (Keys.Alt | Keys.D1):
                case (Keys.Alt | Keys.NumPad1):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung1.Checked) chkVung1.Checked = false;
                        else chkVung1.Checked = true;
                    }
                    return true;
                case (Keys.Alt | Keys.D2):
                case (Keys.Alt | Keys.NumPad2):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung2.Checked) chkVung2.Checked = false;
                        else chkVung2.Checked = true;
                    }
                    return true;
                case (Keys.Alt | Keys.D3):
                case (Keys.Alt | Keys.NumPad3):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung3.Checked) chkVung3.Checked = false;
                        else chkVung3.Checked = true;
                    }
                    return true;
                case (Keys.Alt | Keys.D4):
                case (Keys.Alt | Keys.NumPad4):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung4.Checked) chkVung4.Checked = false;
                        else chkVung4.Checked = true;
                    }
                    return true;
                case Keys.Shift | Keys.D1:
                case Keys.Alt | Keys.F1:
                    tabMain.SelectedTabPageIndex = 0;
                    grvChoGiaiQuyet.Focus();
                    return true;
                case Keys.Shift | Keys.D2:
                case Keys.Alt | Keys.F2:
                    tabMain.SelectedTabPageIndex = 1;
                    grcCuocGoiKetThuc.Focus();
                    return true;
                case Keys.Shift | Keys.D3:
                case Keys.Alt | Keys.F3:
                        tabMain.SelectedTabPageIndex = 2;
                    return true;
                case Keys.Shift | Keys.D4:
                //case Keys.Alt | Keys.B:
                //    tabMain.SelectedTabPageIndex = 3;
                //    return true;
                //case Keys.F9:
                //    barItemTimKiem_ItemClick(null, null);
                //    return true;
                //case Keys.F10:
                //    new frmMemberCard_Search().ShowDialog();
                //    return true;
                case Keys.F11:
                    if (barButton_ChotCoDD_Mini.Visibility == BarItemVisibility.Always)
                    {
                        barButton_ChotCoDD_Mini.PerformClick();
                    }
                    else
                    {
                        barButton_ChotCoDD.PerformClick();
                    }
                    return true;
                //case Keys.Control | Keys.H:
                //    ctrlListBook_ChoXuLy.ShowCtrlH();
                //    return true;
                //case Keys.Alt | Keys.X:
                //    if (tabMain != null && tabMain.SelectedTabPageIndex != 3)
                //    {
                //        tabMain.SelectedTabPageIndex = 3;
                //    }
                //    if (tabControl1.SelectedIndex == 0)
                //    {
                //        ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                //    }
                //    else
                //    {
                //        ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                //    }
                //    return true;
                //case Keys.Alt | Keys.T:
                //    if (tabMain != null && tabMain.SelectedTabPageIndex != 3)
                //    {
                //        tabMain.SelectedTabPageIndex = 3;
                //    }
                //    if (tabControl1.SelectedIndex == 0)
                //    {
                //        ctrlListBook_ChoXuLy.ForcusControl();
                //    }
                //    else
                //    {
                //        ctrlListBook_DaKetThuc.ForcusControl();
                //    }
                //    return true;
                case Keys.Control | Keys.D1:
                case Keys.Control | Keys.NumPad1:
                    if (tabMain != null && tabMain.SelectedTabPageIndex != 0)
                    {
                        tabMain.SelectedTabPageIndex = 0;
                    }
                    //tabControl1.SelectedIndex = 0;
                    //ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                    return true;
                case Keys.Control | Keys.D2:
                case Keys.Control | Keys.NumPad2:
                    if (tabMain != null && tabMain.SelectedTabPageIndex != 1)
                    {
                        tabMain.SelectedTabPageIndex = 1;
                    }
                    //tabControl1.SelectedIndex = 1;
                    //ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                    return true;
                case Keys.Control | Keys.D3:
                case Keys.Control | Keys.NumPad3:
                    if (tabMain != null && tabMain.SelectedTabPageIndex != 2)
                    {
                        tabMain.SelectedTabPageIndex = 2;
                    }
                    return true;
                case Keys.Control | Keys.D4:
                case Keys.Control | Keys.NumPad4:
                    if (tabMain != null && tabMain.SelectedTabPageIndex != 3)
                    {
                        tabMain.SelectedTabPageIndex = 3;
                    }
                    //tabControl1.SelectedIndex = 1;
                    //ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                    return true;

                #region== Menu devexpress==
                case Keys.Control | Keys.F5:
                    btnItemCapNhatDuLieuXe.PerformClick();
                    return true;
                case Keys.Control | Keys.G:
                    barItemChenCuocGoiMoi.PerformClick();
                    return true;

                case Keys.Alt|Keys.F5:
                    btnItemDanhSachLaiXe.PerformClick();
                    return true;
                //case Keys.F3:
                //    barItemDatHen.PerformClick();
                //    return true;
                #endregion
            }
            if (tabMain.SelectedTabPageIndex == 3)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
                        return true;
                    if (ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
                        return true;
                }
                else
                {
                    if (ctrlDanhSachXeChieuVe_DaKetThuc.FindKeyCommand(keyData))
                        return true;
                    if (ctrlListBook_DaKetThuc.FindKeyCommand(keyData))
                        return true;
                }
                if (keyData == (Keys.Control | Keys.Left))
                {
                    tabControl1.SelectedIndex = 0;
                    ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                }
                if (keyData == (Keys.Control | Keys.Right))
                {
                    tabControl1.SelectedIndex = 1;
                    ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkVung1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
                chkVung2.Focus();
            else if (e.KeyData == Keys.Up)
                txtDiaChi.Focus();
        }

        private void chkVung2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
                chkVung3.Focus();
            else if (e.KeyData == Keys.Up)
                chkVung1.Focus();
        }

        private void chkVung3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
                chkVung4.Focus();
            else if (e.KeyData == Keys.Up)
                chkVung2.Focus();
        }

        private void chkVung4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
                txtSoDT.Focus();
            else if (e.KeyData == Keys.Up)
                chkVung3.Focus();
        }

        private void txtSoDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
            else if (e.KeyData == Keys.Down)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
            else if (e.KeyData == Keys.Down)
                txtXeNhan.Focus();
            else if (e.KeyData == Keys.Up)
                txtSoDT.Focus();
        }
        private void txtXeNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
            else if (e.KeyData == Keys.Down)
                chkVung1.Focus();
            else if (e.KeyData == Keys.Up)
                txtDiaChi.Focus();
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
            string xeNhan = txtXeNhan.Text.Trim();
            string kenh = "";

            if (chkVung1.Checked) kenh = "1;";
            if (chkVung2.Checked) kenh = kenh + "2;";
            if (chkVung3.Checked) kenh = kenh + "3;";
            if (chkVung4.Checked) kenh = kenh + "4";

            List<CuocGoi> lstCuocGoi = CuocGoi.DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet_V2(kenh, soDt, diaChi, xeNhan);
            grdTimKiemThongTinCuoc.DataSource = lstCuocGoi;
        }


        private void frmDieuHanhDienThoaiNEWCP_V3_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessFastTaxi.ketThuc = true;
            try
            {
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, QuanTriCauHinh.IpAddress)) // ngôi đúng vị trí checkout
                {
                    ThongTinDangNhap.CheckOut(g_strUsername, QuanTriCauHinh.IpAddress);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhDienThoaiNEWCP_V3_FormClosed:", ex);
            }


            try
            {
                this.Dispose(true);
                if (AutoUpdate.Inst.IsUpdate)
                {
                    Process.Start("AutoUpdate.exe", g_ModuleName);
                }
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhDienThoaiNEWCP_V3_FormClosed:", ex);
            }

        }

        private void btnCollspase_Click(object sender, EventArgs e)
        {
            if (!splitContainer.Panel2Collapsed)
            {
                splitContainer.Panel2Collapsed = true;
                btnCollspase.Image = Resources.previous;
            }
            else
            {
                splitContainer.Panel2Collapsed = false;
                splitContainer.Refresh();
                btnCollspase.Image = Resources.forward;
            }
        }

        #endregion

        #region =========================Grid Event============================

        #region -------------------- Lưới khác --------------------------------

        private void grcCuocGoiKetThuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount > 0)
            {
                CuocGoi cuocGoiRow = grvCuocGoiKetThuc.GetFocusedRow() as CuocGoi;
                if (e.KeyData == (Keys.Control | Keys.C))
                {
                    if (grvCuocGoiKetThuc.FocusedColumn.FieldName == "PhoneNumber")
                    {
                        Clipboard.SetText(cuocGoiRow.PhoneNumber);
                    }
                    else if (grvCuocGoiKetThuc.FocusedColumn.FieldName == "DiaChiDonKhach")
                    {
                        Clipboard.SetText(cuocGoiRow.DiaChiDonKhach);
                    }
                }
                else if (e.KeyData == (Keys.Control | Keys.H))
                {
                    if (cuocGoiRow.G5_SendDate != null)
                    {
                        using (frmCommandHistory frmLichSuCuocDieu = new frmCommandHistory(cuocGoiRow.IDCuocGoi, string.Format("{0}-{1}", cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach)))
                        {
                            frmLichSuCuocDieu.ShowDialog();
                        }
                    }
                }
            }
        }

        #endregion

        #region -------------------- Hàm xử lý --------------------------------

        #region *********************************** Nhập xe đến điểm *******************************
        private bool NhapXeDungDiem(CuocGoi cuocGoiRow, int positionRowSelect, string value) //*new
        {                      
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                using (frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDungDiem,
                        g_ListSoHieuXe, true, value))
                {
                    int yRow = positionRowSelect * grvChoGiaiQuyet.ColumnPanelRowHeight + 170;
                    // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > grdChoGiaiQuyet.Height)
                    {
                        yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(325, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        cuocGoiRow.XeDungDiem = frmInput.GetGiaTriNhap();
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                        //Loại bỏ trùng lặp trước khi thêm vào!
                        string xeDenDiemDaLoc = LocBoTrungLapXe(cuocGoiRow.XeNhan, cuocGoiRow.XeDenDiem);
                        if (!cuocGoiRow.XeNhan.Contains(cuocGoiRow.XeDungDiem) && !string.IsNullOrEmpty(xeDenDiemDaLoc))
                        {
                            if (cuocGoiRow.XeNhan.Length <= 0 )
                                cuocGoiRow.XeNhan = xeDenDiemDaLoc;
                            else
                                cuocGoiRow.XeNhan += "." + xeDenDiemDaLoc;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        private bool NhapXeDenDiem(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    using (
                        frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow,
                            KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDenDiem = frmInput.GetGiaTriChon();
                            if (frmInput.GetGiaTriNhap().Length > 0)
                                cuocGoiRow.XeNhan += "." + frmInput.GetGiaTriNhap();
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    using (
                        frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow,
                            KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        int yRow = positionRowSelect * grvChoGiaiQuyet.ColumnPanelRowHeight + 170;
                        // vị trí của dòng đầu tiên cộng thêm.
                        if (yRow > grdChoGiaiQuyet.Height)
                        {
                            yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                        }
                        frmInput.Location = new Point(325, yRow);
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDenDiem = frmInput.GetGiaTriNhap();
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            //Loại bỏ trùng lặp trước khi thêm vào!
                            string xeDenDiemDaLoc = LocBoTrungLapXe(cuocGoiRow.XeNhan, cuocGoiRow.XeDenDiem);
                            if (!cuocGoiRow.XeNhan.Contains(cuocGoiRow.XeDenDiem) && !string.IsNullOrEmpty(xeDenDiemDaLoc))
                            {
                                if (cuocGoiRow.XeNhan.Length <= 0 )
                                    cuocGoiRow.XeNhan = xeDenDiemDaLoc;
                                else                             
                                    cuocGoiRow.XeNhan += "." + xeDenDiemDaLoc;
                                
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            new MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe đến điểm.",
                "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            return false;
        }

        private string LocBoTrungLapXe(string xeNhan, string xeDenDiem)
        {
            try
            {
                string result = string.Empty;
                string[] arrXeNhan = xeNhan.Split('.');
                string[] arrXeDenDiem = xeDenDiem.Split('.');
                foreach(string item in arrXeDenDiem)
                {
                    if(!arrXeNhan.Contains(item))
                    {
                        if (result.Length == 0)
                            result = item;
                        else result += "." + item;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LocBoTrungLapXe", ex);
                return string.Empty;

                throw;
            }
        }

        #endregion

        #region  *********************************** Nhập xe đón  ***********************************

        private bool NhapXeDon(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice, ref bool changeXeDon, ref bool changeXeNhan)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    changeXeNhan = false;
                    // Hiển thị ô nhập  
                    using (
                        frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow,
                            KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDon = frmInput.GetGiaTriChon();
                            if (frmInput.IsKetThuc())
                            {
                                if (!cuocGoiRow.XeNhan.Contains(cuocGoiRow.XeDon))
                                {
                                    changeXeNhan = false;
                                }
                                if (frmInput.GetGiaTriNhap().Length > 0)
                                {
                                    cuocGoiRow.XeNhan += "." + frmInput.GetGiaTriNhap();
                                    cuocGoiRow.XeDenDiem += "." + frmInput.GetGiaTriNhap();
                                }
                                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                                if (cuocGoiRow.XeDon == "000")
                                {
                                    if (cuocGoiRow.XeNhan.Length <= 0)
                                        cuocGoiRow.XeNhan = "000";
                                    else
                                        cuocGoiRow.XeNhan += ".000";
                                }
                                SapXepLaiIndex(cuocGoiRow);
                                ListCurrent.Remove(cuocGoiRow);
                                HienThiLuoi(false, false);
                            }
                            changeXeDon = true;
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, true, value);
                    int yRow = positionRowSelect * grvChoGiaiQuyet.ColumnPanelRowHeight + 170;
                    // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > grdChoGiaiQuyet.Height)
                    {
                        yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(340, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        cuocGoiRow.XeDon = frmInput.GetGiaTriNhap();
                        if (frmInput.IsKetThuc())
                        {
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
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
                            }
                            SapXepLaiIndex(cuocGoiRow);
                            ListCurrent.Remove(cuocGoiRow);
                            HienThiLuoi(false, false);
                        }
                        changeXeDon = true;
                        return true;
                    }
                }
            }
            else
            {
                new MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe đón.",
                    "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
            return false;
        }

        #endregion

        #region  *********************************** Nhập xe nhận ***********************************
        private bool NhapXeNhan(CuocGoi cuocGoiRow, int positionRowSelect, string value, ref bool changeXeNhan)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                // Hiển thị ô nhập  
                frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhan,
                    g_ListSoHieuXe, true, value);

                int yRow = positionRowSelect * grvChoGiaiQuyet.ColumnPanelRowHeight + 170;
                // vị trí của dòng đầu tiên cộng thêm.
                if (yRow > grdChoGiaiQuyet.Height)
                {
                    yRow = grdChoGiaiQuyet.Height - frmInput.Height;
                }
                frmInput.Location = new Point(625, yRow);
                if (frmInput.ShowDialog() == DialogResult.OK)
                {
                    cuocGoiRow.XeNhan = frmInput.GetGiaTriNhap();
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                    changeXeNhan = true;
                    return true;
                }
            }
            else
            {
                new MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe nhận.",
                    "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
            return false;
        }

        #endregion

        #region  *********************************** Sắp xếp ****************************************

        private void SapXepLaiIndex(CuocGoi cuocGoi)
        {
            if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                G_IndexKhachVIP--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                G_IndexKhachVang--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                G_IndexKhachBac--;
        }

        #endregion

        #region  *********************************** Chuyển cuốc gọi ********************************

        private void RunChuyenCuocGoi()
        {
            try
            {
                if (grvCuocGoiKetThuc.RowCount > 0)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                    {
                        CuocGoi cuocGoiRow = grvCuocGoiKetThuc.GetFocusedRow() as CuocGoi;
                        string result = new MessageBoxBA().Show("Bạn có muốn chuyển cuộc gọi: " + cuocGoiRow.DiaChiDonKhach + " không ?", "Thông báo", MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                        if ( result== "Yes")
                        {
                            CuocGoi.DIENTHOAI_UpdateCGKetThuc2ChuaGiaiQuyet(cuocGoiRow.IDCuocGoi);
                            LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
                            g_boolChuyenTabCuocGoiKetThuc = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("RunChuyenCuocGoi: ", ex);                
            }
        }

        #endregion

        #region  *********************************** Thêm số điện thoại *****************************

        private void AddPOI()
        {
            if (grvChoGiaiQuyet.SelectedRowsCount <= 0)
            {
                new MessageBoxBA().Show("Vui lòng chọn cuộc gọi để lưu");
                return;
            }

            CuocGoi cuocGoi = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();

            new frmPOI(cuocGoi.DiaChiDonKhach, "", "", cuocGoi.GPS_ViDo, cuocGoi.GPS_KinhDo).Show();
        }

        private void AddPhoneNumToContact()
        {
            if (grvChoGiaiQuyet.SelectedRowsCount <= 0)
            {
                new MessageBoxBA().Show("Vui lòng chọn cuộc gọi để lưu");
                return;
            }
            
            CuocGoi cuocGoi = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();
            int type = DMDanhBaCongTy.GetDanhBa_ByPhoneNumber(cuocGoi.PhoneNumber);
            new frmDanhBaCongTy(new DanhBaCongTy(cuocGoi.PhoneNumber, "", cuocGoi.DiaChiDonKhach), type).Show();
        }

        #endregion

        #region  *********************************** Truyền đi **************************************

        private void SaveData_Click(object sender, TaxiEventArgs e)
        {
            try
            {
                if (g_frmInput.g_DialogResult)
                {
                    var cuocGoi = g_frmInput.GetCuocGoi;
                    var checkChange = g_frmInput.GetCheckChange;
                    int soLuong = 0;
                    if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp) // điều đàm thì không cho phép sao chép.
                    {
                        soLuong = cuocGoi.SoLuong - 1;
                        cuocGoi.CamOn_YKien = cuocGoi.SoLuong.ToString();//Dung truong nay de luu tam so luong
                        cuocGoi.SoLuong = 1;
                    }

                    cuocGoi.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                    if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini && Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS && cuocGoi.Vung == 0)
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.DienThoai;
                    }
                    else if ((Config_Common.CoCheDieuApp != EnumCoCheDieuApp.DieuChiDinhGPS && QuanTriCauHinh.MoHinh == MoHinh.TD_DT) && cuocGoi.GPS_KinhDo == 0 && cuocGoi.GPS_ViDo == 0) //địa chỉ không xác định được thì chuyển sang chế độ điều đàm.
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    }
                    bool dieuAppFirst = false;

                    //*sign Tất cả các cuốc giờ quản lý bằng GUID để đồng bộ lên server!
                    //if (cuocGoi.BookId == Guid.Empty)
                    //    cuocGoi.BookId = bookId = Guid.NewGuid();
                    if ((cuocGoi.BookId == Guid.Empty || (cuocGoi.LenhDienThoai == "Chuyển App" && cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe)) && cuocGoi.G5_Type == Enum_G5_Type.DieuApp
                        && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                        && cuocGoi.TrangThaiLenh != TrangThaiLenhTaxi.KetThucCuaDienThoai)
                    {
                        if (cuocGoi.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong)
                        {
                            cuocGoi.XeNhan = string.Empty;
                            checkChange.XeNhan = false;
                        }
                        dieuAppFirst = true;
                    }
                    if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        cuocGoi.XeDungDiem = string.Empty;
                        if (cuocGoi.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong)
                        {
                            cuocGoi.XeNhan = string.Empty;
                            checkChange.XeNhan = false;
                            checkChange.XeDon = false;
                        }
                        else
                        {
                            checkChange.XeNhan = true;
                            checkChange.XeDon = true;
                        }
                        cuocGoi.XeDon = string.Empty;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        //Giữ lại lệnh show phonenumber app lx
                        if (!(cuocGoi.ShowPhoneAppDriver && cuocGoi.LenhDienThoai.Contains(CommandCode.LENH_SHOWPHONENUMBER)))
                        {
                            cuocGoi.LenhDienThoai = string.Empty;                            
                        }
                        dieuAppFirst = true;
                        if (Config_Common.DienThoai_DieuApp_DieuLaiGiuCuocCu)
                        {
                        }
                        else
                        {
                            cuocGoi.BookId = Guid.NewGuid();
                        }
                    }
                    else if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoi.BookId == Guid.Empty)
                    {
                        cuocGoi.BookId = Guid.NewGuid();
                        //if (Config_Common.DTV_FixPrice)
                        //{
                        //    cuocGoi.DiaChiDonKhach = string.Format("[{0}]{1}", cuocGoi.Money_Contract, cuocGoi.DiaChiDonKhach);
                        //    cuocGoi.GhiChuDienThoai = string.Format("[{0}]{1}", cuocGoi.Money_Contract, cuocGoi.GhiChuDienThoai);
                        //}
                    }

                    bool updateSuccess;
                    if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || cuocGoi.SanBay_DuongDai == "1" || cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                        updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini_V2(cuocGoi, dieuAppFirst);
                    else
                        updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi_V2(cuocGoi, checkChange, dieuAppFirst);

                    if (!updateSuccess)
                    {
                        var msgDialog = new MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, vui lòng liên hệ với quản trị", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        return;
                    }
                    else
                    {
                        #region Khởi tạo cuốc ở server rồi update BookId vào db
                        if (dieuAppFirst)
                        {
                            cuocGoi.G5_SendDate = g_TimeServer;//Khắc phục khi điều lại app.
                            if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachDuongDai)
                            {
                            }
                            if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                            {
                                WCFServicesAppXHD.SendInitTrip(cuocGoi);
                            }
                            else
                            {
                                WCFServicesApp.SendInitTrip(cuocGoi);
                                //var toaDoDon = new LatLngOperation(cuocGoi.GPS_ViDo, cuocGoi.GPS_KinhDo);
                                //var toaDoTra = new LatLngOperation(cuocGoi.GPS_ViDo_Tra, cuocGoi.GPS_KinhDo_Tra);
                                //G5ServiceSyn.InitTripSyn(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, toaDoDon, cuocGoi.DiaChiTraKhach, toaDoTra,
                                //    cuocGoi.GhiChuDienThoai, (byte)cuocGoi.SoLuong, cuocGoi.G5_CarType, 0, cuocGoi.PhoneNumber, null, soLuong, false, bookId,
                                //    cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe ? string.Empty : cuocGoi.XeNhan, 0, "", arrVehicleDeny, tripType, cuocGoi.MoneyTrip);
                            }
                            if (soLuong > 0)
                                G5ServiceSyn.CopyCuocGoi(cuocGoi.IDCuocGoi, soLuong, Enum_G5_Type.DieuApp);
                        }
                        #endregion

                        #region GOI KHIEU NAI

                        else if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiKhieuNai)
                        {
                            // sử dụng vùng 11 làm vùng xử lý cuốc khiếu nại. 
                            // nv ĐTV nhập vùng 11 thì chuyển sang cskh
                            if (cuocGoi.Vung == 11)
                            {
                                ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
                                objPhanAnh.DienThoai = cuocGoi.PhoneNumber;
                                objPhanAnh.TenKhachHang = string.Empty;
                                objPhanAnh.NoiDung = cuocGoi.DiaChiDonKhach;
                                objPhanAnh.NhanVienTiepNhan = string.Empty;

                                if (objPhanAnh.InsertCuocGoi(0, 5, 0, cuocGoi.IDCuocGoi) > 0)
                                {
                                    if (Config_Common.KetThucCuocKhieuNai)//Kết thúc cuốc khiếu nại nếu chọn 1
                                    {
                                        DieuHanhTaxi.UpdateCuocGoiKhieuNaiKetThuc(cuocGoi.IDCuocGoi, objPhanAnh.NoiDung, cuocGoi.MaNhanVienDienThoai);
                                        ListCurrent.Remove(cuocGoi);
                                        HienThiLuoi(false, false);
                                    }
                                    return;
                                }
                                else
                                {
                                    MessageBoxBA msgDialog = new MessageBoxBA();
                                    msgDialog.Show(this, "Không chuyển được dữ liệu sang bộ đàm, xin hãy liên hệ với quản trị", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                    return;
                                }
                            }
                        }

                        #endregion

                        ChangeCuocGoiOnListCurrent(cuocGoi);
                        if (soLuong > 0)
                        {
                            HienThiLuoi(true, true);
                        }
                    }
                }

                if (hasNewCallPending)
                {
                    hasNewCallPending = false;
                    NhapDuLieuVaoTruyenDiV2(0);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SaveData_Click: ",ex);
            }
        }

        #endregion

        #endregion

        #endregion

        #region =========================Timer=================================

        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new System.Windows.Forms.Timer();
            TimerCapturePhone.Interval = TimerLength;
            TimerCapturePhone.Tick += TimerCapturePhoneV2_Tick;
            g_TimeServer = DieuHanhTaxi.GetTimeServer();
            TimerCapturePhone.Start();

            Timer_DateTimeServer = new System.Windows.Forms.Timer();
            Timer_DateTimeServer.Interval = TimerLength;
            Timer_DateTimeServer.Tick += Timer_DateTimeServer_Tick;
            Timer_DateTimeServer.Start();
        }

        /// <summary>
        /// hàm tìm kiểm cuocGoi trong listCuocGoiHienTai
        /// nếu  IsCapNhatCuaDienThoai = false thì cập nhật thông tin của tổng đài
        /// ngược lại cập nhật theo thong tin điện thoại nhập
        /// </summary> 
        private void TimVaCapNhatCuocGoi(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi, bool IsCapNhatCuaDienThoai, bool STaxi = false)
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
                    var cuocGoiCurrent = listCuocGoiHienTai[index];
                    if (STaxi)
                    {
                        cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                        cuocGoiCurrent.LoaiXe = cuocGoi.LoaiXe;
                        cuocGoiCurrent.SoLuong = cuocGoi.SoLuong;
                        cuocGoiCurrent.Vung = cuocGoi.Vung;
                        cuocGoiCurrent.FT_KM = cuocGoi.FT_KM;
                        cuocGoiCurrent.DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                        cuocGoiCurrent.DanhSachXeDeCu_TD = cuocGoi.DanhSachXeDeCu_TD;
                        cuocGoiCurrent.KieuKhachHangGoiDen = cuocGoi.KieuKhachHangGoiDen;
                        //Trạng thái timeout
                        cuocGoiCurrent.FT_AllowCall = cuocGoi.FT_AllowCall;
                        cuocGoiCurrent.FT_SendDate = cuocGoi.FT_SendDate;
                    }
                    else
                    {
                        if (!IsCapNhatCuaDienThoai) // cap nhat theo du lieu tong dai gui sang
                        {
                            cuocGoiCurrent.TrangThaiCuocGoi = cuocGoi.TrangThaiCuocGoi;
                            cuocGoiCurrent.LenhTongDai = cuocGoi.LenhTongDai;
                            cuocGoiCurrent.GhiChuTongDai = cuocGoi.GhiChuTongDai;
                            cuocGoiCurrent.MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai;
                            cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                            cuocGoiCurrent.GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                            cuocGoiCurrent.MaNhanVienDienThoai = cuocGoi.MaNhanVienDienThoai;
                            cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                            cuocGoiCurrent.XeNhan_TD = cuocGoi.XeNhan_TD;
                            cuocGoiCurrent.ThoiGianDieuXe = cuocGoi.ThoiGianDieuXe;
                            cuocGoiCurrent.FileVoicePath = cuocGoi.FileVoicePath;
                            cuocGoiCurrent.VungGPSID = cuocGoi.VungGPSID;
                            cuocGoiCurrent.GPS_KinhDo = cuocGoi.GPS_KinhDo;
                            cuocGoiCurrent.GPS_ViDo = cuocGoi.GPS_ViDo;
                            cuocGoiCurrent.DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                            cuocGoiCurrent.ThoiDiemCapNhatXeDeCu = cuocGoi.ThoiDiemCapNhatXeDeCu;
                            cuocGoiCurrent.TrangThaiLenh = cuocGoi.TrangThaiLenh;
                            cuocGoiCurrent.MOIKHACH_LenhMoiKhach = cuocGoi.MOIKHACH_LenhMoiKhach;
                            cuocGoiCurrent.MOIKHACH_NhanVien = cuocGoi.MOIKHACH_NhanVien;
                            cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;
                            cuocGoiCurrent.XeDenDiemDonKhach = cuocGoi.XeDenDiemDonKhach;
                            cuocGoiCurrent.XeDon = cuocGoi.XeDon;
                            cuocGoiCurrent.Vung = cuocGoi.Vung;
                            cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                            cuocGoiCurrent.PhoneNumber = cuocGoi.PhoneNumber;
                            //G5
                            cuocGoiCurrent.BookId = cuocGoi.BookId;
                            if (Config_Common.DTV_ALERT_SOUND_LENHLX && cuocGoiCurrent.LenhLaiXe != cuocGoi.LenhLaiXe && cuocGoi.LenhLaiXe != "Chờ LX nhận cuốc")
                            {
                                SoundUtils.PlaySoundAlert();
                            }
                            cuocGoiCurrent.LenhLaiXe = cuocGoi.LenhLaiXe;
                            cuocGoiCurrent.GhiChuLaiXe = cuocGoi.GhiChuLaiXe;
                            cuocGoiCurrent.G5_Type = cuocGoi.G5_Type;
                            cuocGoiCurrent.G5_CarType = cuocGoi.G5_CarType;
                            cuocGoiCurrent.XeDungDiem = cuocGoi.XeDungDiem;
                            cuocGoiCurrent.SaleOffCode = cuocGoi.SaleOffCode;
                            cuocGoiCurrent.BTBG_NoiDungXuLy = cuocGoi.BTBG_NoiDungXuLy;
                            cuocGoiCurrent.G5_SendDate = cuocGoi.G5_SendDate;
                            cuocGoiCurrent.G5_Step = cuocGoi.G5_Step;
                            cuocGoiCurrent.G5_StepLast = cuocGoi.G5_StepLast;
                            cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                            cuocGoiCurrent.KieuKhachHangGoiDen = cuocGoi.KieuKhachHangGoiDen;
                            //Trạng thái timeout
                            cuocGoiCurrent.FT_AllowCall = cuocGoi.FT_AllowCall;
                            cuocGoiCurrent.FT_SendDate = cuocGoi.FT_SendDate;
                            cuocGoiCurrent.GPS_KinhDo_Tra = cuocGoi.GPS_KinhDo_Tra;
                            cuocGoiCurrent.GPS_ViDo_Tra = cuocGoi.GPS_ViDo_Tra;
                            cuocGoiCurrent.DiaChiTraKhach = cuocGoi.DiaChiTraKhach;
                        }
                        else
                        {
                            if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                            {
                                listCuocGoiHienTai.RemoveAt(index); // remove cuoc goi phia dien thoai ket thuc

                            }
                            else
                            {
                                cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                                cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                                cuocGoiCurrent.GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                                cuocGoiCurrent.TrangThaiLenh = cuocGoi.TrangThaiLenh;
                                cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                                cuocGoiCurrent.LoaiXe = cuocGoi.LoaiXe;
                                cuocGoiCurrent.SoLuong = cuocGoi.SoLuong;
                                cuocGoiCurrent.Vung = cuocGoi.Vung;
                                cuocGoiCurrent.XeDon = cuocGoi.XeDon;
                                cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                                cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;

                                //G5
                                cuocGoiCurrent.BookId = cuocGoi.BookId;

                                if (Config_Common.DTV_ALERT_SOUND_LENHLX && cuocGoiCurrent.LenhLaiXe != cuocGoi.LenhLaiXe && cuocGoi.LenhLaiXe != "Chờ LX nhận cuốc")
                                {
                                    SoundUtils.PlaySoundAlert();
                                }
                                cuocGoiCurrent.LenhLaiXe = cuocGoi.LenhLaiXe;
                                cuocGoiCurrent.GhiChuLaiXe = cuocGoi.GhiChuLaiXe;
                                cuocGoiCurrent.G5_Type = cuocGoi.G5_Type;
                                cuocGoiCurrent.XeDungDiem = cuocGoi.XeDungDiem;
                                cuocGoiCurrent.SaleOffCode = cuocGoi.SaleOffCode;
                                cuocGoiCurrent.BTBG_NoiDungXuLy = cuocGoi.BTBG_NoiDungXuLy;
                                cuocGoiCurrent.G5_SendDate = cuocGoi.G5_SendDate;
                                cuocGoiCurrent.G5_Step = cuocGoi.G5_Step;
                                cuocGoiCurrent.G5_StepLast = cuocGoi.G5_StepLast;
                                cuocGoiCurrent.G5_CarType = cuocGoi.G5_CarType;
                                cuocGoiCurrent.KieuKhachHangGoiDen = cuocGoi.KieuKhachHangGoiDen;
                                //Trạng thái timeout
                                cuocGoiCurrent.FT_AllowCall = cuocGoi.FT_AllowCall;
                                cuocGoiCurrent.FT_SendDate = cuocGoi.FT_SendDate;
                                cuocGoiCurrent.SanBay_DuongDai = cuocGoi.SanBay_DuongDai;
                            }
                        }
                    }
                }
            }
        }

        private void TimVaCapNhatCuocGoiSB(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi, bool IsCapNhatCuaDienThoai, bool STaxi = false)
        {
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count >= 0)
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
                if (index == -1)
                {
                    listCuocGoiHienTai.Insert(0, cuocGoi);
                }
                else if (index >= 0)
                {
                    var cuocGoiCurrent = listCuocGoiHienTai[index];
                    if (STaxi)
                    {
                        cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                        cuocGoiCurrent.LoaiXe = cuocGoi.LoaiXe;
                        cuocGoiCurrent.SoLuong = cuocGoi.SoLuong;
                        cuocGoiCurrent.Vung = cuocGoi.Vung;
                        cuocGoiCurrent.FT_KM = cuocGoi.FT_KM;
                        cuocGoiCurrent.DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                        cuocGoiCurrent.DanhSachXeDeCu_TD = cuocGoi.DanhSachXeDeCu_TD;
                        cuocGoiCurrent.KieuKhachHangGoiDen = cuocGoi.KieuKhachHangGoiDen;
                    }
                    else
                    {
                        if (!IsCapNhatCuaDienThoai) // cap nhat theo du lieu tong dai gui sang
                        {
                            cuocGoiCurrent.TrangThaiCuocGoi = cuocGoi.TrangThaiCuocGoi;
                            cuocGoiCurrent.LenhTongDai = cuocGoi.LenhTongDai;
                            cuocGoiCurrent.GhiChuTongDai = cuocGoi.GhiChuTongDai;
                            cuocGoiCurrent.MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai;
                            cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                            cuocGoiCurrent.GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                            cuocGoiCurrent.MaNhanVienDienThoai = cuocGoi.MaNhanVienDienThoai;
                            cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                            cuocGoiCurrent.XeNhan_TD = cuocGoi.XeNhan_TD;
                            cuocGoiCurrent.ThoiGianDieuXe = cuocGoi.ThoiGianDieuXe;
                            cuocGoiCurrent.FileVoicePath = cuocGoi.FileVoicePath;
                            cuocGoiCurrent.VungGPSID = cuocGoi.VungGPSID;
                            cuocGoiCurrent.GPS_KinhDo = cuocGoi.GPS_KinhDo;
                            cuocGoiCurrent.GPS_ViDo = cuocGoi.GPS_ViDo;
                            cuocGoiCurrent.DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                            cuocGoiCurrent.ThoiDiemCapNhatXeDeCu = cuocGoi.ThoiDiemCapNhatXeDeCu;
                            cuocGoiCurrent.TrangThaiLenh = cuocGoi.TrangThaiLenh;
                            cuocGoiCurrent.MOIKHACH_LenhMoiKhach = cuocGoi.MOIKHACH_LenhMoiKhach;
                            cuocGoiCurrent.MOIKHACH_NhanVien = cuocGoi.MOIKHACH_NhanVien;
                            cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;
                            cuocGoiCurrent.XeDenDiemDonKhach = cuocGoi.XeDenDiemDonKhach;
                            cuocGoiCurrent.XeDon = cuocGoi.XeDon;
                            cuocGoiCurrent.Vung = cuocGoi.Vung;
                            cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                            cuocGoiCurrent.PhoneNumber = cuocGoi.PhoneNumber;
                            //G5
                            cuocGoiCurrent.BookId = cuocGoi.BookId;
                            cuocGoiCurrent.LenhLaiXe = cuocGoi.LenhLaiXe;
                            cuocGoiCurrent.GhiChuLaiXe = cuocGoi.GhiChuLaiXe;
                            cuocGoiCurrent.G5_Type = cuocGoi.G5_Type;
                            cuocGoiCurrent.G5_CarType = cuocGoi.G5_CarType;
                            cuocGoiCurrent.XeDungDiem = cuocGoi.XeDungDiem;
                            cuocGoiCurrent.SaleOffCode = cuocGoi.SaleOffCode;
                            cuocGoiCurrent.BTBG_NoiDungXuLy = cuocGoi.BTBG_NoiDungXuLy;
                            cuocGoiCurrent.G5_SendDate = cuocGoi.G5_SendDate;
                            cuocGoiCurrent.G5_Step = cuocGoi.G5_Step;
                            cuocGoiCurrent.G5_StepLast = cuocGoi.G5_StepLast;
                            cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                            cuocGoiCurrent.KieuKhachHangGoiDen = cuocGoi.KieuKhachHangGoiDen;
                            cuocGoiCurrent.ThoiGianHen = cuocGoi.ThoiGianHen;

                        }
                        else
                        {
                            if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                            {
                                listCuocGoiHienTai.RemoveAt(index); // remove cuoc goi phia dien thoai ket thuc

                            }
                            else
                            {
                                cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                                cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                                cuocGoiCurrent.GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                                cuocGoiCurrent.TrangThaiLenh = cuocGoi.TrangThaiLenh;
                                cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                                cuocGoiCurrent.LoaiXe = cuocGoi.LoaiXe;
                                cuocGoiCurrent.SoLuong = cuocGoi.SoLuong;
                                cuocGoiCurrent.Vung = cuocGoi.Vung;
                                cuocGoiCurrent.XeDon = cuocGoi.XeDon;
                                cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                                cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;

                                //G5
                                cuocGoiCurrent.BookId = cuocGoi.BookId;
                                cuocGoiCurrent.LenhLaiXe = cuocGoi.LenhLaiXe;
                                cuocGoiCurrent.GhiChuLaiXe = cuocGoi.GhiChuLaiXe;
                                cuocGoiCurrent.G5_Type = cuocGoi.G5_Type;
                                cuocGoiCurrent.XeDungDiem = cuocGoi.XeDungDiem;
                                cuocGoiCurrent.SaleOffCode = cuocGoi.SaleOffCode;
                                cuocGoiCurrent.BTBG_NoiDungXuLy = cuocGoi.BTBG_NoiDungXuLy;
                                cuocGoiCurrent.G5_SendDate = cuocGoi.G5_SendDate;
                                cuocGoiCurrent.G5_Step = cuocGoi.G5_Step;
                                cuocGoiCurrent.G5_StepLast = cuocGoi.G5_StepLast;
                                cuocGoiCurrent.G5_CarType = cuocGoi.G5_CarType;
                                cuocGoiCurrent.KieuKhachHangGoiDen = cuocGoi.KieuKhachHangGoiDen;
                                cuocGoiCurrent.ThoiGianHen = cuocGoi.ThoiGianHen;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Hàm thực hiện kiểm tra xem cuộc gọi đã tồn tại hay chưa.
        /// </summary>
        private bool KiemTraCuocGoiDaTonTai(List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi)
        {
            bool tonTai = false;
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoiHienTai)
                {
                    if (objCG.IDCuocGoi == cuocGoi.IDCuocGoi)
                    {
                        tonTai = true;
                        break;
                    }
                }
            }
            return tonTai;
        }

        private void timerNhayBaoCuocGoiMoi_Tick(object sender, EventArgs e)
        {
            if (g_boolNhayMauKhiCoCuocGoiMoi)
            {
                //uiTabCuocGoiChoGiaiQuyet.ImageIndex = 0;
                tabCuocGoiChoGiaiQuyet.ImageIndex = 0;
                g_boolNhayMauKhiCoCuocGoiMoi = false;
            }
            else
            {
                //uiTabCuocGoiChoGiaiQuyet.ImageIndex = 1;
                tabCuocGoiChoGiaiQuyet.ImageIndex = 1;
                g_boolNhayMauKhiCoCuocGoiMoi = true;
            }
            if (tabMain.SelectedTabPageIndex == 0)
            {
                // uiTabCuocGoiChoGiaiQuyet.ImageIndex = -1;
                tabCuocGoiChoGiaiQuyet.ImageIndex = -1;
                timerNhayBaoCuocGoiMoi.Enabled = false;
            }
        }

        //Sử dụng timer check trang thái internet để check cuộc gọi quá giới hạn luôn
        private void InitTimerCheckInternet()
        {
            g_CGLimit = CuocGoi.DIENTHOAI_CheckCuocGoiLimit();
            //checkInternet();
            TimerCapturePhone = new System.Windows.Forms.Timer();
            TimerCapturePhone.Interval = 300000;
            TimerCapturePhone.Tick += TimerCheckInternet_Tick;
            TimerCapturePhone.Start();
        }

        private void TimerCheckInternet_Tick(object sender, EventArgs eArgs)
        {
            //g_TimerCheckLimitCG++;// 5 phút check số cuộc gọi trong bảng taxioperation (có vượt quá giới hạn ?)
            //if (g_TimerCheckLimitCG >= 300)
            //{
            //g_CGLimit = CuocGoi.DIENTHOAI_CheckCuocGoiLimit();
            //g_TimerCheckLimitCG = 0;
            //}
            //checkInternet();
        }

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

            if (G5ServiceSyn.Ping() == Enum_G5_Ping.PingSu)
            {
                status = "Điều App OK";
                imgStatus = Resources.App_Connect_16x;

                if (Config_Common.App_DieuXeHopDong)
                {
                    if (G5ServiceSyn.PingServer_XHD == Enum_G5_Ping.PingSu)
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
                    if (G5ServiceSyn.PingServer_XHD == Enum_G5_Ping.PingSu)
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
                    status5.EditValue = status;
                    status5.Glyph = imgStatus;
                }));
            }
        }

        //-----------------------------Send Message--------------------------------------
        private Messenger g_frmMessenger = new Messenger();
        private string g_Version;
        private string g_ModuleName;
        private bool g_IsNotifyUpdate = false;
        private void timerMessage()
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

        #region===Event control NotifyUpdateVersion
        private void notifyUpdateVer_Click(object sender, EventArgs e)
        {
            if (!g_IsNotifyUpdate)
            {
                g_Version = license.Version();
                string versionUpdate = string.Format("Phiên bản phần mềm Điện thoại mới: {0}", g_Version);
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

        #region ========================= COM PORT ============================
        /// <summary>
        /// Khoi tao mo cong COM thu vo cac cong COM3, COM4, COM5
        /// </summary>
        private void KhoiTaoCOMPort()
        {

            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;

            int iLanMo = 0;
            bool IsOpenCOM = false;
            while (!IsOpenCOM && iLanMo < 3)
            {
                string PortName = string.Format("COM{0}", iLanMo + 3);
                try
                {
                    serialPort1.PortName = PortName;
                    serialPort1.Open();
                    IsOpenCOM = true;
                    g_COMPort = PortName;
                    Thread.Sleep(500);
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("IsOpenCOM:", ex);
                    IsOpenCOM = false;
                    g_COMPort = "";
                }
                iLanMo++;
            }
        }

        /// <summary>
        /// Hàm hiển thị thông tin form gọi điện
        /// </summary>
        private void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi, bool isPBXIP, string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                line = g_lineIPPBX;
            }
            frmCalling.Show();
            frmCalling.Invoke((MethodInvoker)delegate
            {
                frmCalling.lblSoGoi.Text = String.Format("Đang gọi : {0} - {1}", PhoneNumber, DiaChi);
            });
            frmCalling.Refresh();
            if (g_COMPort.Length > 0 && Config_Common.DTV_QUICKCALL_COM)
            {
                if (!isPBXIP) // khong dung tong dai PBXIP
                {
                    if (g_COMPort.Length > 0)
                    {
                        frmCalling.Call(g_COMPort, PhoneNumber, DiaChi);
                    }
                }
                else
                    frmCalling.Call(line, PhoneNumber);
            }
            else if (isPBXIP)
            {
                frmCalling.Call(line, PhoneNumber);
            }
        }

        #endregion COM PORT

        #region Tong dai PBX IP

        private void InitPBXIP()
        {
            try
            {
                if (Config_Common.MPCC_LinkDial != "")
                {
                    status6.EditValue += "MPCC:" + g_lineIPPBX;
                }
                else if (Config_Common.AMI_HostName != "")
                {
                    AsteriskInfo.Manager.Login();
                    if (AsteriskInfo.Manager.IsConnected())
                    {
                        status6.EditValue += "Asterisk:" + g_lineIPPBX;
                        AsteriskInfo.Manager.Logoff();
                    }
                }
                else if (Config_Common.Asterisk_LinkDial != "")
                {
                    status6.EditValue += "Asterisk Cloud:" + g_lineIPPBX;
                }
            }
            catch (Exception ex)
            {
                status6.EditValue += "/CallOut-Err";
                LogError.WriteLogError("InitPBXIP", ex);
            }
        }
        #endregion

        private void uc_CuocAppKH1_EventSoLuongCuoc(int sl)
        {
            tabCuocOnline.Text = string.Format("Cuốc online ({0})", sl);
        } 

        private void frmDieuHanhDienThoaiNEWCP_V3_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ThongTinDangNhap.USER_ID) && !string.IsNullOrEmpty(QuanTriCauHinh.IpAddress) && ThongTinDangNhap.IsUserPostionTrust(ThongTinDangNhap.USER_ID, QuanTriCauHinh.IpAddress)) // ngôi đúng vị trí checkout
                {
                    ThongTinDangNhap.CheckOut(ThongTinDangNhap.USER_ID, QuanTriCauHinh.IpAddress);
                }
            }
            catch (Exception ex1)
            {
                LogError.WriteLogError("frmDieuHanhDienThoaiNEWCP_V3_FormClosed:", ex1);
            }
            if (AutoUpdate.Inst.IsUpdate)
            {
                Process.Start("AutoUpdate.exe", g_ModuleName);
            }
            Process.GetCurrentProcess().Kill();
        }

        #region ==== TimerV2 _ Cải tiến các hàm lấy dữ liệu ====

        #region === Functions ===

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

        #endregion

        #region == Định nghĩa các hàm lấy dữ liệu ==

        /// <summary>
        /// Hàm lấy tất cả các thông tin cuộc gọi thuộc line
        /// </summary>
        private Func<string, List<CuocGoi>> FuncGetAllCuocGoi;
        private Func<string, DateTime, List<CuocGoi>> FuncGetCuocGoiMoi;
        private Func<string, DateTime, List<CuocGoi>> FuncGetCuocGoiThayDoi;
        private Func<string, string, List<long>> FuncGetCuocGoiDaKetThuc;

        private Func<string, List<CuocGoi>> FuncGetAllCuocGoi_Khac;
        private Func<string, DateTime, List<CuocGoi>> FuncGetCuocGoiMoi_Khac;
        private Func<string, DateTime, List<CuocGoi>> FuncGetCuocGoiThayDoi_Khac;
        private Func<string, string, List<long>> FuncGetCuocGoiDaKetThuc_Khac;

        private Func<List<CuocGoi>> FuncGetAllCuocGoiSB;
        private Func<DateTime, List<CuocGoi>> FuncGetCuocGoiThayDoiSB;
        private Func<string, List<long>> FuncGetCuocGoiDaKetThucSB;

        private List<CuocGoi> ListCurrent = new List<CuocGoi>();
        private List<CuocGoi> ListCurrent_Khac = new List<CuocGoi>();
        private List<CuocGoi> ListCurrent_SanBay = new List<CuocGoi>();
        private DateTime _dateMax;  //Thời gian gần đây nhất lấy dữ liệu của lưới sau 1s.
        private DateTime _dateMax3; //Thời gian gần đây nhất lấy dữ liệu của lưới sau 3s.
        private DateTime _dateMaxSB;
        private DateTime _dateMax_Khac;
        private int g_Time3 = 0;
        private int g_Time5 = 0;
        private int g_Time7 = 0;
        private int g_Time10 = 0;
        private int g_Time60 = 0;
        private int g_TimeSb = 0;
        private void IniFunc()
        {
            #region === Ini Func ===
            if (ThongTinCauHinh.FT_Active)
            {
                FuncGetAllCuocGoi = CuocGoi.G5_DIENTHOAI_LayAllCuocGoi;
                FuncGetCuocGoiMoi = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiMoi_FT;
                FuncGetCuocGoiThayDoi = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai;
                FuncGetCuocGoiDaKetThuc = (Line, lsId) => CuocGoi.G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(lsId, Line);

                #region=== Cuốc sân bay===
                FuncGetAllCuocGoiSB = CuocGoi.G5_DIENTHOAI_LayAllCuocGoiSB;
                FuncGetCuocGoiThayDoiSB = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDaiSB;
                FuncGetCuocGoiDaKetThucSB = CuocGoi.G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDaiSB;
                #endregion
            }
            else
            {
                FuncGetAllCuocGoi = CuocGoi.G5_DIENTHOAI_LayAllCuocGoiNotFT;
                FuncGetCuocGoiMoi = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiMoi_FTNotFT;
                FuncGetCuocGoiThayDoi = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai;
                FuncGetCuocGoiDaKetThuc = (Line, lsId) => CuocGoi.G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(lsId, Line);
            }
            FuncGetAllCuocGoi_Khac = CuocGoi.FT_DIENTHOAI_LayAllCuocGoi_Khac;
            FuncGetCuocGoiMoi_Khac = CuocGoi.DIENTHOAI_LayDSCuocGoiMoi_V3_Khac;
            FuncGetCuocGoiThayDoi_Khac = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_Khac;
            FuncGetCuocGoiDaKetThuc_Khac = (Line, lsId) => CuocGoi.DIENTHOAI_LayCacIDCuocGoiKetThuc_Khac(lsId, Line);
            #endregion
        }
        #endregion

        #region === Hien Tai ===

        private CuocGoi g_CuocGoiHienPopUp;        
        private void NhapDuLieuVaoTruyenDiV2(int iRowPosition)
        {
            try
            {
                if (ListCurrent != null && ListCurrent.Count > iRowPosition)
                {
                    var cuocGoi = ListCurrent[iRowPosition];
                    g_CuocGoiHienPopUp = cuocGoi;
                    if (cuocGoi.Vung == 0 && cuocGoi.G5_Type == Enum_G5_Type.DienThoai && !Config_Common.DienThoai_DieuTuDong)
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    }
                    g_frmInput.LoadCuocGoi(cuocGoi);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("NhapDuLieuVaoTruyenDi", ex);
            }

        }
        private void NhapDuLieuVaoTruyenDiSanBay(int iRowPosition)
        {
            try
            {
                if (ListCurrent_SanBay != null && ListCurrent_SanBay.Count > iRowPosition)
                {
                    var cuocGoi = ListCurrent_SanBay[iRowPosition];
                    if (cuocGoi.Vung == 0 && cuocGoi.G5_Type == Enum_G5_Type.DienThoai && !Config_Common.DienThoai_DieuTuDong)
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    }
                    g_frmInput.LoadCuocGoi(cuocGoi);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("NhapDuLieuVaoTruyenDiSanBay", ex);
            }

        }

        private void HienThiAnhTrangThai_MauChuV2(CuocGoi cuocGoi, bool IsRow, int RowIndex, string colName, object valueCell, DevExpress.Utils.AppearanceObject style)
        {
            try
            {
                if (cuocGoi == null) return;
                #region CELL

                if (!IsRow)
                {
                    #region Đổi màu 1 cột
                    //Cột Line : màu vàng = Khách MG. Khách Vip = màu xanh da trời. Khách vàng/Bạc = màu xanh lá cây. Khách ảo = màu cam
                    //Cột xe dừng điểm đổi sang màu đỏ khi có dữ liệu
                    //Cột thời điểm gọi : > 5' và nhỏ hơn 16' thì hiển thị màu cam. Lớn hơn 15 thì hiển thị màu đỏ
                    //Cột thời điểm hẹn :(Thời điểm hẹn - Now) <= 15' thì hiển thị màu đỏ. Nếu <= 90' màu xanh lá cây
                    //Cột loại xe : màu xanh nếu có theo cấu hình số 5.
                    //Cột số lượng : Màu đỏ nếu > 1
                    //Cột số lần : màu vàng = 1. Màu đỏ >= 2
                    //Cột vùng : màu cam = 0
                    //Cột địa chỉ : màu vàng = cuốc điều app
                    //              màu xanh vàng = cuốc xe hợp đồng có thời gian hẹn >= 30'
                    //              màu đỏ = cuốc gọi lại
                    //Cột số điện thoại : có điều app = màu vàng
                    if (!string.IsNullOrEmpty(cuocGoi.XeDungDiem) && colName != null && colName.Equals("XeDungDiem"))
                    {
                        style.BackColor = Config_Common.Grid_XeDungDiem_Color;
                    }
                    //*sign
                    TimeSpan timer = g_TimeServer - cuocGoi.ThoiDiemGoi;
                    if (colName != null && (colName.Equals("ThoiDiemGoi") || colName.Equals("XeNhan") || colName.Equals("XeDenDiem")))
                    {
                        if (timer.TotalMinutes > 5 && timer.TotalMinutes <= 15)
                        {
                            style.ForeColor = Config_Common.Grid_ThoiDiemGoi_Color_5;
                        }
                        else if (timer.TotalMinutes > 15)
                        {
                            style.ForeColor = Config_Common.Grid_ThoiDiemGoi_Color_15;
                        }
                    }

                    if (colName != null && colName.Equals("ThoiGianHenText"))
                    {
                        TimeSpan time = cuocGoi.ThoiGianHen - cuocGoi.ThoiDiemGoi;
                        if (timer.TotalMinutes > 5 && timer.TotalMinutes <= 15)
                            style.ForeColor = Config_Common.Grid_ThoiDiemHen_Color_15;
                        else if (timer.TotalMinutes > 15)
                            style.ForeColor = Config_Common.Grid_ThoiDiemHen_Color_90;
                        else
                            style.ForeColor = Config_Common.Grid_ThoiDiemHen_Color;
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
                    }
                    #endregion

                    #region Lệnh Tổng Đài //*sign
                    //if (cuocGoi.LenhTongDai == LENH_MOIKHACH)
                    //{
                    //    if (cuocGoi.LenhDienThoai == LENH1_DAMOI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH1_DAMOI
                    //        || cuocGoi.LenhDienThoai == LENH2_GAPXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH2_GAPXE
                    //        || cuocGoi.LenhDienThoai == LENH_HOILAIDIACHI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI
                    //        || cuocGoi.LenhDienThoai == LENH_KHONGXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGXE
                    //        || cuocGoi.LenhDienThoai == LENH4_MAYBAN || cuocGoi.MOIKHACH_LenhMoiKhach == LENH4_MAYBAN
                    //        || cuocGoi.LenhDienThoai == LENH5_KHONGLIENLACDUOC || cuocGoi.MOIKHACH_LenhMoiKhach == LENH5_KHONGLIENLACDUOC
                    //        || cuocGoi.LenhDienThoai == LENH_TRUOTCHUA || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_TRUOTCHUA
                    //        || cuocGoi.LenhDienThoai == LENH_KHONGNOIGI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGNOIGI
                    //        || cuocGoi.LenhDienThoai == LENH_GIUROI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GIUROI
                    //        || cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                    //        )
                    //    {
                    //        if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("1") && colName != null && colName.Equals("LenhTongDai"))
                    //        {
                    //            var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.MoiKhach);
                    //            if (temp != null)
                    //                style.BackColor = Color.FromName(temp.CmdColor);
                    //            else
                    //                style.BackColor = Color.Transparent;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("1") && colName != null && colName.Equals("LenhTongDai"))
                    //        {
                    //            style.BackColor = Config_Common.LuoiCuocGoi_MauNen_LenhMoi;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("1") && colName != null && colName.Equals("LenhTongDai"))
                    //    {
                    //        style.BackColor = Color.Transparent;
                    //    }
                    //    else if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("2"))
                    //    {
                    //        style.BackColor = Color.Transparent;
                    //    }
                    //}

                    //if (cuocGoi.LenhTongDai == LENH_6_KIEMTRAKHACH || cuocGoi.LenhTongDai == LENH_8_RADAUNGO)
                    //{
                    //    if (colName != null && colName.Equals("LenhTongDai"))
                    //    {
                    //        if (cuocGoi.LenhDienThoai == LENH1_DAMOI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH1_DAMOI
                    //            || cuocGoi.LenhDienThoai == LENH2_GAPXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH2_GAPXE
                    //            || cuocGoi.LenhDienThoai == LENH_HOILAIDIACHI ||
                    //            cuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI
                    //            || cuocGoi.LenhDienThoai == LENH_KHONGXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGXE
                    //            || cuocGoi.LenhDienThoai == LENH4_MAYBAN || cuocGoi.MOIKHACH_LenhMoiKhach == LENH4_MAYBAN
                    //            || cuocGoi.LenhDienThoai == LENH5_KHONGLIENLACDUOC ||
                    //            cuocGoi.MOIKHACH_LenhMoiKhach == LENH5_KHONGLIENLACDUOC
                    //            || cuocGoi.LenhDienThoai == LENH_TRUOTCHUA || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_TRUOTCHUA
                    //            || cuocGoi.LenhDienThoai == LENH_KHONGNOIGI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGNOIGI
                    //            || cuocGoi.LenhDienThoai == LENH_GIUROI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GIUROI
                    //            || cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                    //            )
                    //        {
                    //            style.BackColor = Color.Transparent;
                    //        }
                    //        else
                    //        {
                    //            //style.BackColor = Color.Orange;
                    //            var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.KiemTraKhach || a.CommandCode == CommandCode.RaDauNgo);
                    //            if (temp != null)
                    //                style.BackColor = Color.FromName(temp.CmdColor);
                    //            else
                    //                style.BackColor = Color.Orange;
                    //        }
                    //    }
                    //}

                    //else if (cuocGoi.LenhTongDai == LENH_7_MOIKHACHLAN2)
                    //{
                    //    if (cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                    //        || cuocGoi.LenhDienThoai == LENH_DAMOI2 || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI2
                    //        )
                    //    {

                    //        if (colName != null && colName.Equals("LenhTongDai"))
                    //        {
                    //            style.BackColor = Color.Transparent;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (colName != null && colName.Equals("LenhTongDai"))
                    //        {
                    //            //style.BackColor = Color.Orange;
                    //            var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.MoiLan2);
                    //            if (temp != null)
                    //                style.BackColor = Color.FromName(temp.CmdColor);
                    //            else
                    //                style.BackColor = Color.Orange;
                    //        }
                    //    }
                    //}
                    //else if (cuocGoi.LenhTongDai == LENH_9_TIEPTHIXEKHAC)
                    //{
                    //    if (colName != null && colName.Equals("LenhTongDai"))
                    //    {
                    //        if (cuocGoi.LenhDienThoai == LENH_DOIXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DOIXE)
                    //        {
                    //            style.BackColor = Color.Transparent;
                    //        }
                    //        else
                    //        {
                    //            //style.BackColor = Color.Orange;
                    //            var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.TiepThiXe);
                    //            if (temp != null)
                    //                style.BackColor = Color.FromName(temp.CmdColor);
                    //            else
                    //                style.BackColor = Color.Orange;
                    //        }
                    //    }
                    //}
                    //else if (cuocGoi.LenhTongDai == LENH_HOILAIDIACHI)
                    //{
                    //    if (colName != null && colName.Equals("LenhTongDai"))
                    //    {
                    //        //style.BackColor = Color.Violet;
                    //        var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.HoiLaiDiaChi);
                    //        if (temp != null)
                    //            style.BackColor = Color.FromName(temp.CmdColor);
                    //        else
                    //            style.BackColor = Color.Violet;
                    //    }
                    //}
                    #endregion

                    #region Lệnh điện thoại
                    //if (cuocGoi.LenhTongDai == LENH_KHONGXE && cuocGoi.ThoiDiemGoi.AddMinutes(3) <= g_TimeServer)
                    //{
                    //    if (colName != null && colName.Equals("LenhTongDai"))
                    //    {
                    //        //style.BackColor = Color.Red;
                    //        var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.KhongXeXL);
                    //        if (temp != null)
                    //            style.BackColor = Color.FromName(temp.CmdColor);
                    //        else
                    //            style.BackColor = Color.Red;
                    //    }
                    //}
                    //else if (cuocGoi.LenhDienThoai == LENH_HUYXE_HOAN ||
                    //         cuocGoi.LenhDienThoai == LENH_G_GIUCXE ||
                    //         cuocGoi.LenhDienThoai.Contains(LENH_MATKN))
                    //{
                    //    if (colName != null && colName.Equals("LenhDienThoai"))
                    //    {
                    //        //style.BackColor = Color.Tomato;
                    //        var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.HuyHoan || a.CommandCode == CommandCode.GiucXe || a.CommandCode == CommandCode.MatKetNoi);
                    //        if (temp != null)
                    //            style.BackColor = Color.FromName(temp.CmdColor);
                    //        else
                    //            style.BackColor = Color.Tomato;
                    //    }
                    //}
                    //else if (cuocGoi.LenhDienThoai == LENH_KTX || cuocGoi.LenhDienThoai == LENH_KTX_GoiChoKhach)
                    //{
                    //    if (colName != null && colName.Equals("LenhDienThoai"))
                    //    {
                    //        //style.BackColor = Color.Yellow;
                    //        var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.KhongThayXe || a.CommandCode == CommandCode.GoiChoKhachKTX);
                    //        if (temp != null)
                    //            style.BackColor = Color.FromName(temp.CmdColor);
                    //        else
                    //            style.BackColor = Color.Yellow;
                    //    }
                    //}

                    //if (cuocGoi.LenhDienThoai == LENH_KHACHDAT)
                    //{
                    //    if (colName != null && colName.Equals("LenhDienThoai"))
                    //    {
                    //        //style.BackColor = Color.Green;
                    //        var temp = CommonBL.ListTaxiCommands.First(a => a.CommandCode == CommandCode.KhachDat);
                    //        if (temp != null)
                    //            style.BackColor = Color.FromName(temp.CmdColor);
                    //        else
                    //            style.BackColor = Color.Green;
                    //    }
                    //}
                    #endregion

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
                    if (colName != null && colName.Equals("Vung"))
                    {
                        // neu vung la 0 thi hien thi mau do, de nhan vien chu y
                        if (cuocGoi.Vung <= 0)
                        {
                            style.BackColor = Config_Common.Grid_Vung_Color;
                        }
                        else // trar lai mau binh thuong
                        {
                            style.BackColor = Color.Transparent;
                        }
                    }
                    #region Line

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
                    #endregion

                    #region DiaChiDonKhach

                    if (colName != null && colName.Equals("DiaChiDonKhach"))
                    {
                        if (cuocGoi.FT_IsFT && cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                        {
                            style.BackColor = Config_Common.Grid_DiaChi_App_Color;
                        }
                        else if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong && (cuocGoi.ThoiGianHen - cuocGoi.ThoiDiemGoi).TotalMinutes >= 30)
                        {
                            style.BackColor = Config_Common.Grid_DiaChi_CAR_Color;
                        }
                        else // goi lai va cuoc goi chua chuyen di va so lan goi lon hon hoac bang 2
                            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai || (cuocGoi.Vung == 0 && cuocGoi.SoLanGoi >= 2))
                            {
                                style.BackColor = Config_Common.Grid_DiaChi_GL_Color;
                            }
                            else
                            {
                                style.BackColor = Color.Transparent;
                            }
                    }

                    #endregion

                    #region LoaiXe

                    if (colName != null && colName.Equals("LoaiXe"))
                    {
                        if (Config_Common.LuoiCuocGoi_MauNen_LoaiXe != null && Config_Common.LuoiCuocGoi_MauNen_LoaiXe.Length > 0)
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
                            else
                            {
                                style.BackColor = Color.Transparent;
                            }
                        }
                        else
                        {
                            style.BackColor = Color.Transparent;
                        }
                    }

                    #endregion

                    if (cuocGoi.SoLuong > 1 && colName != null && colName.Equals("SoLuong"))
                    {
                        style.BackColor = Config_Common.Grid_SoLuong_Color_1;//Color.Red;
                    }
                    if (cuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam) //Chuyển sang điều đàm
                    {
                    }
                    else if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp || cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp || cuocGoi.G5_Type == Enum_G5_Type.CuocAppKH || cuocGoi.G5_Type == Enum_G5_Type.CuocVangLai) //Điều tự động
                    {
                        if (colName != null && colName.Equals("PhoneNumber"))
                        {
                            style.BackColor = Config_Common.Grid_SDT_App_Color;//Color.Yellow;
                        }
                    }
                    #endregion
                }

                #endregion
                #region ROW

                else
                {
                    if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiHoiDam)
                    {
                        style.BackColor = Config_Common.Grid_CuocHoiDam_BackGround;
                    }
                    if (cuocGoi.LenhDienThoai.ToUpper() == "SÂN BAY".ToUpper() || cuocGoi.SanBay_DuongDai == "1")
                    {
                        style.BackColor = Config_Common.Grid_CuocSanBay_BackGround;
                    }
                    if (cuocGoi.FT_AllowCall && cuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam)
                    {
                        style.BackColor = Config_Common.Grid_App_ChuyenDam_Color;//.AntiqueWhite;
                    }
                    if (cuocGoi.LenhLaiXe == CommandCode.PMDH_CONST_Msg_NoCarAccept)
                    {
                        style.BackColor = Config_Common.Grid_App_NoCarAccept_Color;//Color.FromArgb(0x99, 0xFF, 0xCC);
                    }
                    if (cuocGoi.LenhLaiXe == CommandCode.PMDH_CONST_Msg_NoCar)
                    {
                        style.BackColor = Config_Common.Grid_App_NoCar_Color; //Color.FromArgb(0x99, 0xFF, 0xCC);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi hàm HienThiAnhTrangThai_MauChuV2:", ex);
            }
        }

        private void HienThiAnhTrangThai_MauChu_Khac(CuocGoi cuocGoi, bool IsRow, int RowIndex, string colName, object valueCell, DevExpress.Utils.AppearanceObject style)
        {
            try
            {
                if (cuocGoi == null) return;                

                if (!IsRow && cuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                {
                    if (colName != null && colName.Equals("DiaChiDonKhach"))
                    {
                        style.BackColor = Config_Common.Grid_DiaChi_App_Color;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiAnhTrangThai_MauChu_Khac:", ex);
            }

        }
        private void grvChoGiaiQuyet_KeyDown(object sender, KeyEventArgs e)
        {
            #region == NEW ===
            if (grvChoGiaiQuyet.RowCount > 0)
            {
                if (grvChoGiaiQuyet.SelectedRowsCount <= 0)
                {
                    if (e.KeyData == Keys.Up)
                    {
                        grvChoGiaiQuyet.FocusedRowHandle = 0;
                    }
                    else
                    {
                        grvChoGiaiQuyet.FocusedRowHandle = grvChoGiaiQuyet.RowCount - 1;
                    }
                }

                int positionRowSelect = grvChoGiaiQuyet.FocusedRowHandle;

                if (grvChoGiaiQuyet.SelectedRowsCount > 0)
                {
                    CuocGoi cuocGoiRow = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();
                    XuLyTapLenhTrenPanel(cuocGoiRow, e, positionRowSelect, false);
                }
            }
            #endregion
        }
        private void grvCuocGoiSanBay_KeyDown(object sender, KeyEventArgs e)
        {
            #region == NEW ===
            if (grvCuocGoiSanBay.RowCount > 0)
            {
                if (grvCuocGoiSanBay.SelectedRowsCount <= 0)
                {
                    if (e.KeyData == Keys.Up)
                    {
                        grvCuocGoiSanBay.FocusedRowHandle = 0;
                    }
                    else
                    {
                        grvCuocGoiSanBay.FocusedRowHandle = grvChoGiaiQuyet.RowCount - 1;
                    }
                }

                int positionRowSelect = grvCuocGoiSanBay.FocusedRowHandle;                
                if (grvCuocGoiSanBay.SelectedRowsCount > 0)
                {
                    CuocGoi cuocGoiRow = (CuocGoi)grvCuocGoiSanBay.GetFocusedRow();
                    XuLyTapLenhTrenPanel(cuocGoiRow, e, positionRowSelect, true);
                }
            }
            #endregion
        }
        private void grvChoGiaiQuyet_DoubleClick(object sender, EventArgs e)
        {
            if (grvChoGiaiQuyet.SelectedRowsCount > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDiV2(grvChoGiaiQuyet.FocusedRowHandle);
            }
        }
        private void grcCuocGoiSanBay_DoubleClick(object sender, EventArgs e)
        {
            if (grvCuocGoiSanBay.SelectedRowsCount > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDiSanBay(grvCuocGoiSanBay.FocusedRowHandle);
            }
        }
        private void grvChoGiaiQuyet_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var cuocGoi = (CuocGoi)grvChoGiaiQuyet.GetRow(e.RowHandle);
            if (cuocGoi != null)
            {
                HienThiAnhTrangThai_MauChuV2(cuocGoi, false, e.RowHandle, e.Column.FieldName, e.CellValue, e.Appearance);
            }
        }
        private void grvChoGiaiQuyet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var cuocGoi = (CuocGoi)grvChoGiaiQuyet.GetRow(e.RowHandle);
            if (cuocGoi != null)
            {
                HienThiAnhTrangThai_MauChuV2(cuocGoi, true, e.RowHandle, null, null, e.Appearance);
            }
        }
        private void grvChoGiaiQuyet_Khac_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var cuocGoi = (CuocGoi)grvChoGiaiQuyet_Khac.GetRow(e.RowHandle);
            if (cuocGoi != null)
            {
                HienThiAnhTrangThai_MauChu_Khac(cuocGoi, false, e.RowHandle, e.Column.FieldName, e.CellValue, e.Appearance);
            }
        }
        private void grvChoGiaiQuyet_Khac_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var cuocGoi = (CuocGoi)grvChoGiaiQuyet_Khac.GetRow(e.RowHandle);
            if (cuocGoi != null)
            {
                HienThiAnhTrangThai_MauChu_Khac(cuocGoi, true, e.RowHandle, null, null, e.Appearance);
            }
        }
        private void grvCuocGoiSanBay_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var item = (CuocGoi)grvCuocGoiSanBay.GetRow(e.RowHandle);
            if (e.Column.FieldName == "ThoiGianHen")
            {
                TimeSpan time = item.ThoiGianHen - g_TimeServer;
                if (time.TotalMinutes <= 15)
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else if (time.TotalMinutes <= 90 && time.TotalMinutes > 15)
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
        }
        private void grvCuocGoiKetThuc_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount > 0)
            {
                CuocGoi cuocGoi = grvCuocGoiKetThuc.GetRow(e.RowHandle) as CuocGoi;
                if (cuocGoi != null)
                {
                    if (cuocGoi.LenhDienThoai.ToUpper() == "SÂN BAY".ToUpper() || cuocGoi.SanBay_DuongDai == "1")
                    {
                        e.Appearance.BackColor = Config_Common.Grid_CuocSanBay_BackGround;
                    }
                }
            }
        }
        private void grvChoGiaiQuyet_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var cuocGoi = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();
            if (cuocGoi != null)
            {
                lblDiaChi.Text = cuocGoi.DiaChiDonKhach;
                lblSdt.Text = cuocGoi.PhoneNumber;
                lblDHV.Text = cuocGoi.LenhTongDai;
            }
            else
            {
                lblDiaChi.Text = string.Empty;
                lblSdt.Text = string.Empty;
                lblDHV.Text = string.Empty;
            }
        }
        private void grvChoGiaiQuyet_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var cuocGoi = (CuocGoi)grvChoGiaiQuyet.GetFocusedRow();
            if (cuocGoi != null)
            {
                lblDiaChi.Text = cuocGoi.DiaChiDonKhach;
                lblSdt.Text = cuocGoi.PhoneNumber;
                lblDHV.Text = cuocGoi.LenhTongDai;
            }
            else
            {
                lblDiaChi.Text = string.Empty;
                lblSdt.Text = string.Empty;
                lblDHV.Text = string.Empty;
            }
        }

        #endregion

        #region === Lưới chính ===
        private void LoadAllCuocGoi(string Line)
        {
            lock (ListCurrent)
            {
                if (Config_Common.DTV_THOIDIEMHEN_ORDER && Config_Common.DTV_XENHAN_ORDER)
                {
                    ListCurrent = FuncGetAllCuocGoi(Line).OrderBy(T => T.XeNhan).ThenBy(X => X.ThoiGianHen).ToList();
                }
                else if (Config_Common.DTV_THOIDIEMHEN_ORDER)
                {
                    ListCurrent = FuncGetAllCuocGoi(Line).OrderBy(T => T.ThoiGianHen).ToList();
                }
                else if (Config_Common.DTV_XENHAN_ORDER)
                {
                    ListCurrent = FuncGetAllCuocGoi(Line).OrderBy(T => T.XeNhan).ToList();
                }
                else
                {
                    ListCurrent = FuncGetAllCuocGoi(Line);
                }
                if (Config_Common.DienThoai_DieuApp_XuLyCuocGoiSaoChep > 0 && ListCurrent != null && ListCurrent.Count > 0)
                {
                    var cuocGoiLai = ListCurrent.Where(p => (g_TimeServer - p.ThoiDiemGoi).TotalMinutes <= Config_Common.DienThoai_DieuApp_XuLyCuocGoiSaoChep && p.G5_CopyId > 0 && p.G5_Type == Enum_G5_Type.DieuApp && p.BookId == Guid.Empty && p.LenhLaiXe.Contains("Chờ LX nhận cuốc")).OrderBy(p => p.ThoiDiemGoi).ToList();
                    Dictionary<long, QueueCuocKhach> DicQueueCuocGoiSaoChep = new Dictionary<long, QueueCuocKhach>();
                    foreach (var item in cuocGoiLai)
                    {
                        if (item.BookId == Guid.Empty && item.G5_Type == Enum_G5_Type.DieuApp && item.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            if (!DicQueueCuocGoiSaoChep.ContainsKey(item.G5_CopyId))
                            {
                                DicQueueCuocGoiSaoChep[item.G5_CopyId] = new QueueCuocKhach(item.G5_CopyId, item, g_TimeServer);
                            }
                            else
                            {
                                DicQueueCuocGoiSaoChep[item.G5_CopyId].Add(item);
                            }
                        }
                    }
                    lock (QueueCuocKhachSaoChep)
                    {
                        if (DicQueueCuocGoiSaoChep.Count > 0)
                        {
                            QueueCuocKhachSaoChep.AddRange(DicQueueCuocGoiSaoChep.Select(p => p.Value));
                        }
                    }
                }
            }
            HienThiLuoi(true, true);
        }
        private Return GetAllCuocGoiMoi(string Line, DateTime DateMax)
        {
            Return re = new Return();
            try
            {
                var lsCuocGoiMoi = FuncGetCuocGoiMoi(Line, DateMax);
                if (lsCuocGoiMoi != null && lsCuocGoiMoi.Count > 0)
                {
                    Dictionary<long, QueueCuocKhach> DicQueueCuocGoiSaoChep = new Dictionary<long, QueueCuocKhach>();
                    lock (ListCurrent)
                    {
                        foreach (CuocGoi objCG in lsCuocGoiMoi)
                        {
                            if (!KiemTraCuocGoiDaTonTai(ListCurrent, objCG))
                            {
                                re.HasCuocGoiMoi = true;
                                if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                                    DateMax = objCG.ThoiDiemThayDoiDuLieu;

                                ChenCuocSaoChep(ListCurrent, objCG);
                                if (objCG.KieuCuocGoi == KieuCuocGoi.GoiLai && Config_Common.DienThoai_ChuyenCacCuocGoiGanCuocGoiLai)
                                    ChuyenCacCuocGoiGanCuocGoiLai(ListCurrent, objCG, 0);
                                if (objCG.G5_CopyId == 0 || (objCG.G5_CopyId != 0 && objCG.G5_Type == Enum_G5_Type.DienThoai)) //Không phải là cuốc copy của cuốc điều app và cuốc điều lại
                                {
                                    if (!objCG.FT_IsFT)
                                        re.HasCuocGoiPopUp = true;
                                    if ((objCG.G5_Type == Enum_G5_Type.CuocAppKH || objCG.G5_Type == Enum_G5_Type.CuocVangLai) && !string.IsNullOrEmpty(objCG.XeNhan))
                                    {
                                        re.HasCuocGoiPopUp = false;                                        
                                    }
                                }
                                else
                                {
                                    if (objCG.BookId == Guid.Empty && objCG.G5_Type == Enum_G5_Type.DieuApp && objCG.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                                    {
                                        //if (DicQueueCuocGoiSaoChep == null)
                                        //{
                                        //    DicQueueCuocGoiSaoChep = new Dictionary<long, QueueCuocKhach>();
                                        //}
                                        if (!DicQueueCuocGoiSaoChep.ContainsKey(objCG.G5_CopyId))
                                        {
                                            DicQueueCuocGoiSaoChep[objCG.G5_CopyId] = new QueueCuocKhach(objCG.G5_CopyId, objCG, g_TimeServer);
                                        }
                                        else
                                        {
                                            DicQueueCuocGoiSaoChep[objCG.G5_CopyId].Add(objCG);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    lock (QueueCuocKhachSaoChep)
                    {
                        if (DicQueueCuocGoiSaoChep.Count > 0)
                        {
                            QueueCuocKhachSaoChep.AddRange(DicQueueCuocGoiSaoChep.Select(p => p.Value));
                        }
                    }
                }
                re.DateMax = DateMax;


            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetAllCuocGoiMoi:", ex);
            }
            return re;
        }
        private Return CapNhapCuocGoiTuTongDai(string Line, DateTime DateMax)
        {
            Return re = new Return();
            try
            {
                var lsCuocGoi = FuncGetCuocGoiThayDoi(Line, DateMax);
                if (lsCuocGoi != null && lsCuocGoi.Count > 0)
                {
                    lock (ListCurrent)
                    {
                        foreach (CuocGoi objCG in lsCuocGoi)
                        {
                            if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                                DateMax = objCG.ThoiDiemThayDoiDuLieu;
                            re.HasCuocGoiThaydoi = true;
                            TimVaCapNhatCuocGoi(ref ListCurrent, objCG, false);
                        }
                    }
                }
                re.DateMax = DateMax;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CapNhapCuocGoiTuTongDai:", ex);
            }
            return re;
        }
        private Return CapNhatCuocGoiKetThucTuTongDai(string Line)
        {
            Return re = new Return();
            try
            {
                // lấy ds các ID cuộc gọi hiện có
                string lsId = "";
                if (ListCurrent != null && ListCurrent.Count > 0)
                {
                    foreach (CuocGoi cuocGoi in ListCurrent)
                    {
                        lsId += String.Format("{0},", cuocGoi.IDCuocGoi);
                    }
                    if (lsId.EndsWith(","))
                    {
                        lsId = lsId.Substring(0, lsId.Length - 1);
                    }
                }
                if (lsId.Length > 0) // co  cuoc  goi
                {
                    List<long> listIDDaKetThuc = FuncGetCuocGoiDaKetThuc(Line, lsId);
                    if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                    {
                        re.HasCuocGoiMoi = true;
                        re.HasCuocGoiThaydoi = true;
                        if (ListCurrent != null)
                            lock (ListCurrent)
                            {
                                ListCurrent.RemoveAll(p => listIDDaKetThuc.Contains(p.IDCuocGoi));
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CapNhatCuocGoiKetThucTuTongDai:", ex);
            }
            return re;
        }
        private void HienThiLuoi(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                var g_RowIndex = grvChoGiaiQuyet.FocusedRowHandle;
                var FirstRow = grvChoGiaiQuyet.TopRowIndex;

                if(IsThemMoi)
                {
                    grdChoGiaiQuyet.DataSource = ListCurrent;
                    grdChoGiaiQuyet.RefreshDataSource();
                }
                else
                {
                    if (Config_Common.DTV_THOIDIEMHEN_ORDER && Config_Common.DTV_XENHAN_ORDER)
                    {
                        ListCurrent = ListCurrent.OrderBy(T => T.XeNhan).ThenBy(X => X.ThoiGianHen).ToList();
                        grdChoGiaiQuyet.DataSource = ListCurrent;                        
                    }
                    else if (Config_Common.DTV_THOIDIEMHEN_ORDER)
                    {
                        ListCurrent = ListCurrent.OrderBy(T => T.ThoiGianHen).ToList();
                        grdChoGiaiQuyet.DataSource = ListCurrent;                    
                    } 
                    else if (Config_Common.DTV_XENHAN_ORDER)
                    {
                        ListCurrent = ListCurrent.OrderBy(T => T.XeNhan).ToList();
                        grdChoGiaiQuyet.DataSource = ListCurrent;                        
                    }
                    grdChoGiaiQuyet.RefreshDataSource();
                }

                grvChoGiaiQuyet.FocusedRowHandle = g_RowIndex;
                grvChoGiaiQuyet_FocusedRowChanged(null,null);//*sign
                //grvChoGiaiQuyet.TopRowIndex = FirstRow;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiLuoi", ex);
            }
        }

        #endregion

        #region === Lưới line khác ===
        private void LoadAllCuocGoi_Khac(string Line)
        {
            lock (ListCurrent_Khac)
            {
                ListCurrent_Khac = FuncGetAllCuocGoi_Khac(Line);

            }
            HienThiLuoi_Khac(true, true);
        }
        private Return GetAllCuocGoiMoi_Khac(string Line, DateTime DateMax)
        {
            Return re = new Return();
            var lsCuocGoiMoi = FuncGetCuocGoiMoi_Khac(Line, DateMax);
            if (lsCuocGoiMoi != null && lsCuocGoiMoi.Count > 0)
            {
                lock (ListCurrent_Khac)
                {
                    foreach (CuocGoi objCG in lsCuocGoiMoi)
                    {
                        if (!KiemTraCuocGoiDaTonTai(ListCurrent_Khac, objCG))
                        {
                            re.HasCuocGoiMoi = true;
                            if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                                DateMax = objCG.ThoiDiemThayDoiDuLieu;
                            ListCurrent_Khac.Insert(0, objCG);
                        }
                    }
                }
            }
            re.DateMax = DateMax;
            return re;
        }
        private Return CapNhapCuocGoiTuTongDai_Khac(string Line, DateTime DateMax)
        {
            Return re = new Return();
            var lsCuocGoi = FuncGetCuocGoiThayDoi_Khac(Line, DateMax);
            if (lsCuocGoi != null && lsCuocGoi.Count > 0)
            {
                lock (ListCurrent_Khac)
                {
                    foreach (CuocGoi objCG in lsCuocGoi)
                    {
                        if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                            DateMax = objCG.ThoiDiemThayDoiDuLieu;
                        re.HasCuocGoiThaydoi = true;
                        TimVaCapNhatCuocGoi_Khac(ref ListCurrent_Khac, objCG);
                    }
                }
            }
            re.DateMax = DateMax;
            return re;
        }
        private Return CapNhatCuocGoiKetThucTuTongDai_Khac(string Line)
        {
            Return re = new Return();
            // lấy ds các ID cuộc gọi hiện có
            string lsId = "";
            if (ListCurrent_Khac != null && ListCurrent_Khac.Count > 0)
            {
                foreach (CuocGoi cuocGoi in ListCurrent_Khac)
                {
                    lsId += String.Format("{0},", cuocGoi.IDCuocGoi);
                }
                if (lsId.EndsWith(","))
                {
                    lsId = lsId.Substring(0, lsId.Length - 1);
                }
            }
            if (lsId.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = FuncGetCuocGoiDaKetThuc_Khac(Line, lsId);
                if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                {
                    re.HasCuocGoiMoi = true;
                    re.HasCuocGoiThaydoi = true;
                    lock (ListCurrent_Khac)
                    {
                        ListCurrent_Khac.RemoveAll(p => listIDDaKetThuc.Contains(p.IDCuocGoi));
                    }
                }
            }
            return re;
        }
        private void HienThiLuoi_Khac(bool IsCapNhat, bool IsThemMoi)
        {
            var g_RowIndex = grvChoGiaiQuyet_Khac.FocusedRowHandle;
            var FirstRow = grvChoGiaiQuyet_Khac.TopRowIndex;
            if (IsThemMoi)
            {
                grdChoGiaiQuyet_Khac.DataSource = ListCurrent_Khac;
                grdChoGiaiQuyet_Khac.Refresh();
            }
            else
            {
                grdChoGiaiQuyet_Khac.RefreshDataSource();
            }
            grvChoGiaiQuyet_Khac.FocusedRowHandle = g_RowIndex;
            grvChoGiaiQuyet_Khac.TopRowIndex = FirstRow;
        }

        #endregion

        #region === Lưới sân bay ===
        private void LoadAllCuocGoi_SB()
        {
            lock (ListCurrent_SanBay)
            {
                ListCurrent_SanBay = FuncGetAllCuocGoiSB();

                if (Config_Common.DienThoai_DieuApp_XuLyCuocGoiSaoChep > 0 && ListCurrent_SanBay != null && ListCurrent_SanBay.Count > 0)
                {
                    var cuocGoiLai = ListCurrent_SanBay.Where(p => (g_TimeServer - p.ThoiDiemGoi).TotalMinutes <= Config_Common.DienThoai_DieuApp_XuLyCuocGoiSaoChep && p.G5_CopyId > 0 && p.G5_Type == Enum_G5_Type.DieuApp && p.BookId == Guid.Empty && p.LenhLaiXe.Contains("Chờ LX nhận cuốc")).OrderBy(p => p.ThoiDiemGoi).ToList();
                    Dictionary<long, QueueCuocKhach> DicQueueCuocGoiSaoChep = new Dictionary<long, QueueCuocKhach>();
                    foreach (var item in cuocGoiLai)
                    {
                        if (item.BookId == Guid.Empty && item.G5_Type == Enum_G5_Type.DieuApp && item.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            if (!DicQueueCuocGoiSaoChep.ContainsKey(item.G5_CopyId))
                            {
                                DicQueueCuocGoiSaoChep[item.G5_CopyId] = new QueueCuocKhach(item.G5_CopyId, item, g_TimeServer);
                            }
                            else
                            {
                                DicQueueCuocGoiSaoChep[item.G5_CopyId].Add(item);
                            }
                        }
                    }
                    lock (QueueCuocKhachSaoChep)
                    {
                        if (DicQueueCuocGoiSaoChep.Count > 0)
                        {
                            QueueCuocKhachSaoChep.AddRange(DicQueueCuocGoiSaoChep.Select(p => p.Value));
                        }
                    }
                }
            }
            HienThiLuoiSB(true, true);
        }
        private Return CapNhapCuocGoiTuTongDai_SB(DateTime DateMax)
        {
            Return re = new Return();
            var lsCuocGoi = FuncGetCuocGoiThayDoiSB(DateMax);
            if (lsCuocGoi != null && lsCuocGoi.Count > 0)
            {
                lock (ListCurrent_SanBay)
                {
                    foreach (CuocGoi objCG in lsCuocGoi)
                    {
                        if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                            DateMax = objCG.ThoiDiemThayDoiDuLieu;
                        re.HasCuocGoiThaydoi = true;
                        TimVaCapNhatCuocGoiSB(ref ListCurrent_SanBay, objCG, true);
                    }
                }
            }
            re.DateMax = DateMax;
            return re;
        }
        private Return CapNhatCuocGoiKetThucTuTongDai_SB()
        {
            Return re = new Return();
            // lấy ds các ID cuộc gọi hiện có
            string lsId = "";
            if (ListCurrent_SanBay != null && ListCurrent_SanBay.Count > 0)
            {
                foreach (CuocGoi cuocGoi in ListCurrent_SanBay)
                {
                    lsId += String.Format("{0},", cuocGoi.IDCuocGoi);
                }
                if (lsId.EndsWith(","))
                {
                    lsId = lsId.Substring(0, lsId.Length - 1);
                }
            }
            if (lsId.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = FuncGetCuocGoiDaKetThucSB(lsId);
                if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                {
                    re.HasCuocGoiMoi = true;
                    re.HasCuocGoiThaydoi = true;
                    lock (ListCurrent_SanBay)
                    {
                        ListCurrent_SanBay.RemoveAll(p => listIDDaKetThuc.Contains(p.IDCuocGoi));
                    }
                }
            }
            return re;
        }
        private void HienThiLuoiSB(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                var g_RowIndexSb = grvCuocGoiSanBay.FocusedRowHandle;
                CuocGoi cg = grvCuocGoiSanBay.GetFocusedRow() as CuocGoi;
                ListCurrent_SanBay = ListCurrent_SanBay.OrderBy(x => x.ThoiGianHen).ToList();
                if (IsThemMoi)
                {
                    grcCuocGoiSanBay.DataSource = ListCurrent_SanBay;
                    grcCuocGoiSanBay.Refresh();
                }
                else
                {
                    grcCuocGoiSanBay.RefreshDataSource();
                }
                if (IsCapNhat)
                {
                    grcCuocGoiSanBay.DataSource = ListCurrent_SanBay;
                    grcCuocGoiSanBay.Refresh();
                }

                int index = ListCurrent_SanBay.IndexOf(cg);
                if (index < 0)
                {
                    grvCuocGoiSanBay.FocusedRowHandle = g_RowIndexSb - 1;
                }
                else
                {
                    grvCuocGoiSanBay.FocusedRowHandle = index;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiLuoiSB", ex);
            }
        }
        #endregion

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
                //Kiểm tra xem tài khoản này đã có đăng nhập từ máy khác ko
                //Có thì phải checkout ở máy này ra (có nghĩa đã có người khác dùng tài khoản này)
                if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, QuanTriCauHinh.IpAddress))
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        new MessageBoxBA().Show(string.Format("Tài khoản {0} đã đăng nhập ở máy tính khác", g_strUsername));
                        CheckOut();
                    }));
                    
                }
                else if(!ThongTinDangNhap.IsUserPostionTrust(g_strUsername, QuanTriCauHinh.IpAddress))
                {
                    Invoke(new MethodInvoker(() => CheckOut("Bạn vừa bị đăng xuất cưỡng chế từ quản lý")));
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bw_ValidateLogin_DoWork", ex);
            }
        }
        #endregion

        #region === Hàm xử lý ===
        int G_CallOut_Count = 0;
        private void XuLyTapLenhTrenPanel(CuocGoi cuocGoiRow, KeyEventArgs e, int positionRowSelect, bool IsSanBay, bool hasThucHienLenh = false)
        {
            var msgDialog = new MessageBoxBA();
            if (cuocGoiRow == null) return;
            bool changeXeNhan = false;
            bool changeXeDon = false;

            #region Nhập lệnh nhanh
            int keyInput = (int)e.KeyData;
            bool isChuyenApp = false;//Chuyển app thì bật popup luôn
            bool isCommand = false; //biến check xem có phải command đã cấu hình ko
            List<TaxiOperationCommand> lstCommand = CommonBL.Commands.FindAll(a => a.FunctionUsing == (int)Enum_ChucNangNhiemVu.DienThoaiVien && a.CommandCode != Enum_CommandCode.System);
            
            int[] StatusCommand_Num = { 3, 4 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe)
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
                else
                {
                    continue;
                }

                if (isCommand)
                {
                    hasThucHienLenh = true;
                    string commandText = command.Command;
                    bool isApp = ((cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp
                                        || cuocGoiRow.G5_Type == Enum_G5_Type.CuocAppKH
                                        || cuocGoiRow.G5_Type == Enum_G5_Type.CuocVangLai
                                        ||cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                            && cuocGoiRow.BookId != Guid.Empty
                            && cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                            );
                    bool isCuocKhongXe = (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                                && (cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam || cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                                && (    cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe
                                        || cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1
                                        || (cuocGoiRow.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiKhongXe && cuocGoiRow.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1 && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
                                        || cuocGoiRow.LenhLaiXe == CommandCode.PMDH_CONST_Msg_NoCarAccept
                                        || Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc == 1)
                                && (cuocGoiRow.XeNhan == null || cuocGoiRow.XeNhan.Length <= 0));

                    if ((command.CallType != null && (KieuCuocGoi)command.CallType != cuocGoiRow.KieuCuocGoi)
                            && command.CommandCode != Enum_CommandCode.System)//Không check lệnh hệ thống
                    {
                        msgDialog.Show(string.Format("Phải là cuộc gọi xe mới được thực hiện lệnh [{0}]", commandText), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        return;
                    }
                    else if (command.RequireVehicle && string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                    {
                        msgDialog.Show(string.Format("Phải có xe nhận mới được thực hiện lệnh [{0}]", commandText), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        return;
                    }
                    //Hoặc trường hợp không xe xin lỗi khách thì bắt buộc phải ko dc có xe nhận
                    else if ((!command.RequireVehicle
                        && !string.IsNullOrEmpty(cuocGoiRow.XeNhan)
                        && (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi)))
                    {
                        msgDialog.Show(string.Format("Phải chưa có xe nhận mới được thực hiện lệnh [{0}]", command.Command), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        return;
                    }
                    //Validate ParentCommand
                    //else if (!string.IsNullOrEmpty(command.ParentCommand))
                    //{
                    //    if ((cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp
                    //                    || cuocGoiRow.G5_Type == Enum_G5_Type.CuocAppKH
                    //                    || cuocGoiRow.G5_Type == Enum_G5_Type.CuocVangLai)
                    //        && cuocGoiRow.BookId != Guid.Empty
                    //        && cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                    //        && (!command.ParentCommand.Equals(cuocGoiRow.LenhLaiXe) || !cuocGoiRow.LenhLaiXe.Contains(command.ParentCommand)))
                    //    {
                    //        msgDialog.Show(string.Format("[Lệnh Lái Xe] phải là [{1}] thì mới được thực hiện lệnh [{0}]", commandText, command.ParentCommand), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    //        return;
                    //    }
                    //    else if (cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam
                    //        && (!command.ParentCommand.Equals(cuocGoiRow.LenhTongDai) || !cuocGoiRow.LenhTongDai.Contains(command.ParentCommand)))
                    //    {
                    //        msgDialog.Show(string.Format("[Lệnh Tổng Đài] phải là [{1}] thì mới được thực hiện lệnh [{0}]", commandText, command.ParentCommand), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    //        return;
                    //    }
                    //}
                    //Validate các trường hợp kết thúc cuốc
                    if ((command.Status != null && StatusCommand_Num.Contains(command.Status.Value))
                        //Trường hợp đặc biệt, có cấu hình kết thúc không xe ở ĐTV
                        || (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi 
                            && Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc == 1 
                            && (cuocGoiRow.XeNhan == null || cuocGoiRow.XeNhan.Length <= 0)
                        )
                        //Trường hợp Hủy Hoãn
                        || (isApp && (command.CommandCode == Enum_CommandCode.DTV_HuyHoan || command.CommandCode == Enum_CommandCode.DTV_TruotChua))
                        //Trường hợp không xe xin lỗi khách
                        || (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi && isCuocKhongXe)
                        )
                    {
                        string dialog = msgDialog.Show(
                            string.Format("[{0}] Kết thúc địa chỉ {1} ?", commandText.ToUpper(), cuocGoiRow.DiaChiDonKhach), "LỆNH KẾT THÚC CUỐC",
                            MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                        if (dialog.ToUpper() == "yes".ToUpper())
                        {
                            cuocGoiRow.TrangThaiLenh = (TrangThaiLenhTaxi)command.Status;
                            if (command.CommandCode == Enum_CommandCode.DTV_HuyHoan)
                            {
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                            }
                            else if (command.CommandCode == Enum_CommandCode.DTV_TruotChua)
                            {
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                            }
                            else if (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi)
                            {
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                            }
                        }
                        else
                        {
                            hasThucHienLenh = false;
                            return;
                        }
                    }

                    #region cảnh báo mất kết nối server app pdh

                    if ((cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp
                            || ((cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp
                                || cuocGoiRow.G5_Type == Enum_G5_Type.CuocAppKH
                                || cuocGoiRow.G5_Type == Enum_G5_Type.CuocVangLai)
                                && cuocGoiRow.G5_SendDate != null
                                && cuocGoiRow.BookId != Guid.Empty)
                                )
                            && cuocGoiRow.BookId != Guid.Empty
                            && command.SendDriver == 1)
                    {
                        if (Config_Common.DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh)
                        {
                            if ((G5ServiceSyn.PingServer != Enum_G5_Ping.PingSu && cuocGoiRow.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong)
                                    || (G5ServiceSyn.PingServer_XHD != Enum_G5_Ping.PingSu && cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong))
                            {
                                if (cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp)
                                {
                                    msgDialog.Show(this, "Đang mất kết nối tới Server ĐH.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                    return;
                                }
                            }
                        }
                    }
                    #endregion

                    bool IsAppCoXeNhan = (cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp
                                        || cuocGoiRow.G5_Type == Enum_G5_Type.CuocAppKH
                                        || cuocGoiRow.G5_Type == Enum_G5_Type.CuocVangLai)
                            && cuocGoiRow.BookId != Guid.Empty
                            && cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                            && !string.IsNullOrEmpty(cuocGoiRow.XeNhan);

                    if (hasThucHienLenh && command.CommandCode == Enum_CommandCode.DTV_SMSCuocDuongDai && Config_Common.SMS_CuocDuongDai_App_LaiXe_Send == Enum_SendSMSCuocDuongDai_App.NhapLenhKhac
                        )
                    {
                        if (!string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                        {
                            SendSMS_App_DuongDai(cuocGoiRow, cuocGoiRow.XeNhan);
                        }
                        else
                        {
                            msgDialog.Show(this, String.Format("[{0}] Phải có xe nhận mới gửi sms được.", commandText), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }
                    }

                    #region ---------- 1:Đã mời ---------
                    //DaMoiDT:  - Nếu cuốc app có cấu hình 100 (mã lệnh mk) = 43. thì send command cho lx
                    //          - Ngược lại send text
                    if (command.CommandCode == Enum_CommandCode.DTV_DaMoi)
                    {
                        int numMoiKhach;
                        if (IsAppCoXeNhan && command.ParentCommand != "")
                        {
                            numMoiKhach = cuocGoiRow.LenhLaiXe.Replace(command.ParentCommand, "").Replace("[", "").Replace("]", "").Trim().To<int>();
                        }
                        else
                        {
                            numMoiKhach = cuocGoiRow.LenhDienThoai.Replace(command.Command, "").Replace("[", "").Replace("]", "").Trim().To<int>();
                            if (cuocGoiRow.LenhDienThoai == command.Command)
                                numMoiKhach = 1;
                        }
                        int numDaMoi1 = cuocGoiRow.LenhDienThoai.Replace(command.Command, "").Replace("[", "").Replace("]", "").Trim().To<int>();
                        if (numMoiKhach == 0 || !cuocGoiRow.LenhDienThoai.Contains(command.Command))
                        {
                            //cuocGoiRow.LenhDienThoai = command.Command;
                        }
                        else
                        {
                            if (numDaMoi1 == 0)
                                numDaMoi1 = 1;
                            numMoiKhach = numDaMoi1 + 1;
                            commandText = string.Format("{0} [{1}]", command.Command, numMoiKhach);
                        }
                        if (IsAppCoXeNhan)
                        {
                            if (Config_Common.DienThoai_DieuApp_DaMoiCmdId >= 0)
                            {
                                int cmdID = Config_Common.DienThoai_DieuApp_DaMoiCmdId;
                                if ((int)cuocGoiRow.G5_StepLast >= 60)
                                {
                                    cmdID = (int)cuocGoiRow.G5_StepLast;
                                }
                                G5ServiceSyn.SendText(cuocGoiRow.XeNhan, commandText, cuocGoiRow.BookId, cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, cmdID);
                            }
                            else
                            {
                                G5ServiceSyn.SendACKInvite(cuocGoiRow.BookId, cuocGoiRow.XeNhan, true, commandText, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                            }
                            if (hasThucHienLenh && Config_Common.SMS_CuocDuongDai_App_LaiXe_Send == Enum_SendSMSCuocDuongDai_App.NhapLenhDaMoi)
                            {
                                if (!string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                                {
                                    SendSMS_App_DuongDai(cuocGoiRow, cuocGoiRow.XeNhan);
                                }
                                else
                                {
                                    msgDialog.Show(this, String.Format("[{0}] Phải có xe nhận mới gửi sms được.", commandText), "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                    hasThucHienLenh = false;
                                    return;
                                }
                            }
                        }
                    }

                    #endregion

                    #region ---------- 2:Gặp xe  ----------

                    //================ 2 : Gặp xe rồi
                    else if (command.CommandCode == Enum_CommandCode.DTV_GapXe)
                    {
                        if (IsAppCoXeNhan)
                        {
                            if (license.IsTaxiGroup)
                                G5ServiceSyn.SendText(cuocGoiRow.XeNhan, commandText, cuocGoiRow.BookId, cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                            else
                                G5ServiceSyn.SendCatchUserSyn(cuocGoiRow.BookId, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                        }
                    }
                    #endregion

                    #region ---------- 3:Không xe xin lỗi khách  ----------

                    else if (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi)
                    {
                        string LineDuocCapPhep = Global.LineDuocCapPhep + ";";
                        if (tabMain.SelectedTabPage.Name == "tabCuocSanBay" && LineDuocCapPhep.IndexOf(cuocGoiRow.Line + ";") < 0)
                        {
                            if (cuocGoiRow.XeNhan.Trim().Length > 0)
                            {
                                msgDialog.Show(this, String.Format("[{0}] Phải có xe nhận đón.", commandText),
                                    "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                hasThucHienLenh = false;
                                return;
                            }
                            else
                            {
                                cuocGoiRow.LenhTongDai = commandText;
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                                CuocGoi.G5_DIENTHOAI_UpdateLenhCuocSB(cuocGoiRow);
                            }
                        }
                        else
                        {
                            if (isCuocKhongXe)
                            {
                                //string dialog = msgDialog.Show(string.Format("[{0}] {1}...?", commandText, cuocGoiRow.DiaChiDonKhach),
                                //    "Thông báo", MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                                //if (dialog == "Yes")
                                {
                                    if (cuocGoiRow.G5_StepLast == Enum_G5_Step.SourceCancel_Customer)
                                    {
                                        G5ServiceSyn.SendOperatorDispatched(cuocGoiRow.BookId, "", cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                                    }
                                    if (Config_Common.App_SendSMS_Customer && Config_Common.DTV_SMS_DAXINLOI_KHACH == 1)
                                    {
                                        WCFServicesApp.SendSMS_ReceiveNoCar(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, cuocGoiRow.LoaiCuocKhach);
                                    }
                                    else if (Config_Common.SMS_TaxiVina && Config_Common.SMS_TaxiVina_NoCar)
                                    {
                                        WCF_SMSVina.Vina_SendSms_VinaTaxi_NoCar(cuocGoiRow.PhoneNumber);
                                    }
                                    hasThucHienLenh = true;
                                }
                            }
                            else
                            {
                                msgDialog.Show(this,
                                    string.Format("[{0}] Phải là cuộc gọi taxi - chưa có xe nhận.", commandText),
                                    "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                hasThucHienLenh = false;
                                return;
                            }
                        }
                    }
                    #endregion

                    #region ---------- 3:Gửi SMS đã xin lỗi khách  ----------

                    else if (command.CommandCode == Enum_CommandCode.DTV_SMSDaXinLoi)
                    {                       
                        if (isCuocKhongXe)
                        {
                            if (Config_Common.App_SendSMS_Customer && Config_Common.DTV_SMS_DAXINLOI_KHACH == 2)
                            {
                                WCFServicesApp.SendSMS_ReceiveNoCar(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, cuocGoiRow.LoaiCuocKhach);
                            }
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                string.Format("[{0}] Phải là cuộc gọi taxi - chưa có xe nhận.", commandText),
                                "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }
                    }
                    #endregion

                    #region ---------- 8:Hủy xe/Hoãn ----------
                    //Cuốc app Hợp đồng và đã có lệnh gặp khách của lx thì không dc hủy/hoãn
                    //Cuốc app KH hủy hoặc (app KH đặt ko xe và có lái xe hủy) thì gửi SendOperatorDispatched
                    //Cuốc app từ PDH gửi SendOperatorCancel
                    //Có cấu hình 139 thì gửi sms
                    //-> có xe nhận hoặc xe đến điểm : gửi SendSMS_ReceiveDriverCancel
                    //-> ngược lại : gửi SendSMS_ReceiveNoCar
                    else if (command.CommandCode == Enum_CommandCode.DTV_HuyHoan)
                    {
                        if (IsAppCoXeNhan || cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp || cuocGoiRow.LenhLaiXe == "Chờ LX nhận cuốc")
                        {
                            if (cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong && cuocGoiRow.G5_StepLast == Enum_G5_Step.CatchedUser)
                            {
                                msgDialog.Show(this, "Xe đã gặp khách, vui lòng ko " + commandText, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                                hasThucHienLenh = false;
                                return;
                            }
                            //string dialog = msgDialog.Show(
                            //string.Format("[{0}] {1}...?", commandText, cuocGoiRow.DiaChiDonKhach), "Thông báo",
                            //MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                            //if (dialog == "Yes")
                            {
                                if (cuocGoiRow.G5_StepLast == Enum_G5_Step.SourceCancel_Customer
                                    || (cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp
                                    && cuocGoiRow.G5_StepLast == Enum_G5_Step.DriverCancel))
                                {
                                    G5ServiceSyn.SendOperatorDispatched(cuocGoiRow.BookId, "", cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                                }
                                else
                                {
                                    G5ServiceSyn.SendOperatorCancel(cuocGoiRow.BookId, cuocGoiRow.LoaiCuocKhach, "Tâm thông báo " + commandText);
                                }

                                #region SMS
                                if (Config_Common.App_SendSMS_Customer)
                                {
                                    if (cuocGoiRow.XeNhan.Length > 0 || cuocGoiRow.XeDungDiem.Length > 0)
                                    {
                                        WCFServicesApp.SendSMS_ReceiveDriverCancel(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, cuocGoiRow.XeNhan, cuocGoiRow.LoaiCuocKhach);
                                        cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveDriverCancel;
                                    }
                                    else
                                    {
                                        if (Config_Common.DTV_SMS_DAXINLOI_KHACH == 1)
                                        {
                                            WCFServicesApp.SendSMS_ReceiveNoCar(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, cuocGoiRow.LoaiCuocKhach);
                                            cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveNoCar;
                                        }
                                    }
                                }

                                #endregion
                            }
                            //else
                            //{
                            //    hasThucHienLenh = false;
                            //    return;
                            //}
                        }
                    }
                    #endregion

                    #region  ---------- A : Chuyển App  ----------
                    //Chuyển app: chuyển cuốc đã chuyển đàm sang điều app. có cấu hình 148 thì mới dùng dc tính năng
                    else if (command.CommandCode == Enum_CommandCode.DTV_ChuyenApp)
                    {
                        if (Config_Common.ChoPhepChuyenDieuApp)
                        {
                            if (cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam && string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                            {
                                //cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe;
                                cuocGoiRow.G5_Type = Enum_G5_Type.DieuApp;
                                isChuyenApp = true;
                            }
                            else
                            {
                                msgDialog.Show(this,
                                    String.Format("[{0}] Phải là cuộc gọi taxi và không có xe nhận", commandText), "Thông báo",
                                    MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                hasThucHienLenh = false;
                                return;
                            }
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[{0}] Phải cấu hình cho phép chuyển điều đàm sang điều app", commandText), "Thông báo",
                                MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;

                        }
                    }
                    #endregion

                    #region ---------- R: Chuyển điều đàm ----------
                    //Cuốc app chuyển đàm : App PĐH hoặc từ App KH
                    //có liên quan đến cấu hình 95 : thời gian cho phép chuyển đàm
                    else if (command.CommandCode == Enum_CommandCode.DTV_ChuyenDam)
                    {
                        if ((cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp || cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                        && cuocGoiRow.Vung > 0
                        && (!String.IsNullOrEmpty(cuocGoiRow.XeDungDiem) || !String.IsNullOrEmpty(cuocGoiRow.XeDon)
                            || (Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam > 0 &&
                                ((g_TimeServer - (cuocGoiRow.G5_SendDate ?? cuocGoiRow.ThoiDiemGoi)).TotalMinutes >
                                Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam))
                            || (string.IsNullOrEmpty(cuocGoiRow.XeNhan) && cuocGoiRow.LenhLaiXe != "Chờ LX nhận cuốc")))
                        {
                            cuocGoiRow.G5_Type = Enum_G5_Type.ChuyenSangDam;
                            cuocGoiRow.XeNhan = "";
                        }
                        else
                        {
                            msgDialog.Show(this, String.Format("[{0}] Phải là cuộc gọi taxi, điều app và chưa có xe nhận.", commandText)
                                , "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }
                    }
                    #endregion

                    #region ---------- D: Hoãn điều app chuyển sang điều đàm ----------
                    //Cuốc app, nhân viên can thiệp hoãn và chuyển điều đàm
                    else if (command.CommandCode == Enum_CommandCode.DTV_HoanChuyenDam)
                    {
                        if ((cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp)
                        && cuocGoiRow.Vung > 0
                        && (!string.IsNullOrEmpty(cuocGoiRow.XeNhan) && cuocGoiRow.LenhLaiXe != "Chờ LX nhận cuốc"))
                        {
                            G5ServiceSyn.SendOperatorCancel(cuocGoiRow.BookId, cuocGoiRow.LoaiCuocKhach, "Tâm thông báo " + commandText);
                            cuocGoiRow.G5_Type = Enum_G5_Type.ChuyenSangDam;
                            cuocGoiRow.XeNhan = "";
                        }
                        else
                        {
                            msgDialog.Show(this, String.Format("[{0}] Phải là cuộc gọi taxi, điều app và có xe nhận.", commandText)
                                , "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }
                    }
                    #endregion

                    #region  ---------- L:Không liên lạc được ----------
                    //Lệnh không liên lạc dc :
                    //Cuốc app => kết thúc cuốc luôn (nhưng phải sau 5 phút)
                    //Cấu hình 85 để gửi message cho lx
                    //Cuốc đàm ko kết thúc
                    else if (command.CommandCode == Enum_CommandCode.DTV_KoLienLacDuoc)
                    {
                        if (cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp || cuocGoiRow.G5_Type == Enum_G5_Type.CuocAppKH)
                        {
                            //Nếu là cuốc điều app và có xe dừng điểm hoặc thời gian vượt quá 5 phút thì cho trượt
                            if (!string.IsNullOrEmpty(cuocGoiRow.XeDungDiem) || (g_TimeServer - (cuocGoiRow.G5_SendDate ?? cuocGoiRow.ThoiDiemGoi)).TotalMinutes > 5)
                            {
                                //string dialog = msgDialog.Show(
                                //    string.Format("[{1}] {0}...?", cuocGoiRow.DiaChiDonKhach, commandText),
                                //    "Thông báo", MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                                //if (dialog == "Yes")
                                {
                                    if (cuocGoiRow.G5_StepLast == Enum_G5_Step.SourceCancel_Customer
                                    || (cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp && cuocGoiRow.G5_StepLast == Enum_G5_Step.DriverCancel))
                                    {
                                        G5ServiceSyn.SendOperatorDispatched(cuocGoiRow.BookId, "", cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                                    }

                                    if (Config_Common.CmdIdLenhKoLienLac > 0) //Khi dùng gửi lệnh thì gửi lệnh.
                                    {
                                        G5ServiceSyn.SendText(cuocGoiRow.XeNhan, commandText, cuocGoiRow.BookId, cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, Config_Common.CmdIdLenhKoLienLac);
                                    }
                                    else
                                    {
                                        G5ServiceSyn.SendOperatorCancel(cuocGoiRow.BookId, cuocGoiRow.LoaiCuocKhach, commandText);
                                    }
                                }
                                //else
                                //{
                                //    hasThucHienLenh = false;
                                //    return;
                                //}
                            }
                            else
                            {
                                hasThucHienLenh = false;
                                msgDialog.Show(this,
                               String.Format("[{0}] Phải là cuốc gọi điều App và có lái xe hủy.", commandText),
                               "Thông báo",
                               MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                return;
                            }
                        }
                    }
                    #endregion

                    #region  ---------- H:Hoàn thành ----------
                    //Cấu hình 132 : số phút dc phép kích hoàn thành. (0 thì kích thoải mái)
                    else if (command.CommandCode == Enum_CommandCode.DTV_HoanThanh)
                    {
                        if (IsAppCoXeNhan
                            && ((!string.IsNullOrEmpty(cuocGoiRow.XeDon) && (Config_Common.App_Minute_Done_ByKeyH < 0 || cuocGoiRow.G5_SendDate.Value.AddMinutes(Config_Common.App_Minute_Done_ByKeyH) <= g_TimeServer))
                            || (Config_Common.App_Minute_Done_ByKeyH == 0))
                            )
                        {
                            cuocGoiRow.XeDon = cuocGoiRow.XeNhan;
                            hasThucHienLenh = true;
                            G5ServiceSyn.SendConfirmDoneBook(cuocGoiRow, Services.Operations.EnumConfirmDoneBook.Done);
                           
                        }
                        else
                        {
                            string msg = String.Format("[{0}] Phải là cuốc điều App đã có xe đón.", commandText);
                            if (Config_Common.App_Minute_Done_ByKeyH > 0)
                            {
                                msg = String.Format("[{1}] Phải là cuốc điều App cách đây {0} phút và đã có xe đón.", Config_Common.App_Minute_Done_ByKeyH, command.Command);
                            }
                            msgDialog.Show(this, msg, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }

                    }
                    #endregion

                    #region  ---------- T:Trượt/Chùa  ----------
                    //Cuốc app :
                    //Phải có xe dừng điểm
                    //hoặc Thời gian hợp lệ với cấu hình 120
                    //hoặc Cấu hình 103 : cho phép trượt khi có xe nhận
                    // - khách xe HĐ :  đã gặp khách thì ko cho trượt/hoãn

                    else if (command.CommandCode == Enum_CommandCode.DTV_TruotChua)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                            && (!string.IsNullOrEmpty(cuocGoiRow.XeNhan)
                            || !string.IsNullOrEmpty(cuocGoiRow.XeDenDiem)))
                        {
                            if (isApp)
                            {
                                if (//Cuốc hợp đồng mà đã gặp khách rồi thì ko cho trượt
                                   (cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong && cuocGoiRow.G5_StepLast == Enum_G5_Step.CatchedUser))
                                {
                                    hasThucHienLenh = false;
                                    msgDialog.Show(this, "Xe đã gặp khách, vui lòng ko " + command.Command, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                                    return;
                                }
                                //Nếu là cuốc điều app và có xe dừng điểm hoặc thời gian vượt quá 5 phút thì cho trượt
                                if (!string.IsNullOrEmpty(cuocGoiRow.XeDungDiem)
                                    || (Config_Common.DienThoai_DieuApp_Truot == 0 || (g_TimeServer - (cuocGoiRow.G5_SendDate ?? cuocGoiRow.ThoiDiemGoi)).TotalMinutes > Config_Common.DienThoai_DieuApp_Truot)
                                    || (!string.IsNullOrEmpty(cuocGoiRow.XeNhan) && Config_Common.DienThoai_DieuApp_TruotKhiCoXeNhan)
                                    )
                                {
                                    {
                                        //string dialog = msgDialog.Show(string.Format("{1} {0}...?", cuocGoiRow.DiaChiDonKhach, command.Command), "Thông báo",
                                        //    MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                                        //if (dialog == "Yes")
                                        {
                                            if (cuocGoiRow.G5_StepLast == Enum_G5_Step.SourceCancel_Customer
                                                || (cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp && cuocGoiRow.G5_StepLast == Enum_G5_Step.DriverCancel))
                                            {
                                                G5ServiceSyn.SendOperatorDispatched(cuocGoiRow.BookId, "", cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                                            }
                                            else
                                                //Gửi hủy cho lái xe
                                                G5ServiceSyn.SendOperatorCancel(cuocGoiRow.BookId, cuocGoiRow.LoaiCuocKhach, "Tâm thông báo " + command.Command);

                                            #region SMS
                                            if (Config_Common.App_SendSMS_Customer)
                                            {
                                                if (cuocGoiRow.XeNhan.Length > 0 || cuocGoiRow.XeDungDiem.Length > 0)
                                                {
                                                    WCFServicesApp.SendSMS_ReceiveDriverCancel(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, cuocGoiRow.XeNhan, cuocGoiRow.LoaiCuocKhach);
                                                    cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveDriverCancel;
                                                }
                                                else
                                                {
                                                    if (Config_Common.DTV_SMS_DAXINLOI_KHACH == 1)
                                                    {
                                                        WCFServicesApp.SendSMS_ReceiveNoCar(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, cuocGoiRow.LoaiCuocKhach);
                                                        cuocGoiRow.SendSMS_Status = Enum_G5_PMDH_SMS_Status.ReceiveNoCar;
                                                    }
                                                }
                                            }

                                            #endregion
                                        }
                                    }
                                }
                                else
                                {
                                    msgDialog.Show(this,
                                   String.Format("[{0}] Phải là cuốc gọi điều App và lái xe đã báo trượt.", command.Command),
                                   "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                    hasThucHienLenh = false;
                                    return;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(cuocGoiRow.XeDon))
                                {
                                    msgDialog.Show(this,
                                        String.Format("[{0}] Phải là cuộc gọi taxi, có xe nhận và chưa có xe đón.", command.Command),
                                        "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                    hasThucHienLenh = false;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[{0}] Phải là cuộc gọi taxi và đã có xe nhận.", command.Command),
                                "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }
                    }
                    #endregion

                    #region=== Y/N:Gửi số điện thoại cho lái xe ===
                    if (command.CommandCode == Enum_CommandCode.DTV_ChoSoDT || command.CommandCode == Enum_CommandCode.DTV_KoChoSoDT)
                    {
                        if (IsAppCoXeNhan
                            && (cuocGoiRow.LenhLaiXe == command.ParentCommand || cuocGoiRow.G5_Step.Contains("50"))
                            )
                        {
                            G5ServiceSyn.SendText(cuocGoiRow.XeNhan, cuocGoiRow.PhoneNumber, cuocGoiRow.BookId, cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, 50, command.CommandCode == Enum_CommandCode.DTV_ChoSoDT);
                        }
                        else
                        {
                            msgDialog.Show(this,
                                     String.Format("[{0}] Phải là cuộc gọi taxi và cuốc điều app và có xe nhận.", commandText),
                                     "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }
                    }
                    if (command.CommandCode == Enum_CommandCode.DTV_ShowPhoneNumber)
                    {
                        if (Config_Common.AppLX_CMDID_ShowPhoneNumber > 0)
                        {
                            if (IsAppCoXeNhan)
                            {
                                G5ServiceSyn.SendText(cuocGoiRow.XeNhan, cuocGoiRow.PhoneNumber, cuocGoiRow.BookId, cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, Config_Common.AppLX_CMDID_ShowPhoneNumber, command.CommandCode == Enum_CommandCode.DTV_ShowPhoneNumber);
                            }
                            else
                            {
                                msgDialog.Show(this,
                                         String.Format("[{0}] Phải là cuộc gọi taxi và cuốc điều app và có xe nhận.", commandText),
                                         "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                                hasThucHienLenh = false;
                                return;
                            }
                        }
                        else
                        {
                            msgDialog.Show(this,
                                     String.Format("[{0}] Phải có cấu hình cho phép hiển thị số đt trên app lx", commandText),
                                     "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            hasThucHienLenh = false;
                            return;
                        }
                    }
                    #endregion

                    #region  ---------- Gửi lệnh cho lái xe  ----------
                    if (command.SendDriver == (int)Enum_SendDriver.SendText)
                    {
                        if ((cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp
                            || cuocGoiRow.G5_Type == Enum_G5_Type.CuocAppKH
                            || cuocGoiRow.G5_Type == Enum_G5_Type.CuocVangLai)
                            && cuocGoiRow.BookId != Guid.Empty
                            && !string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                        {
                            G5ServiceSyn.SendText(cuocGoiRow.XeNhan, commandText, cuocGoiRow.BookId, cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID, cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                        }
                    }
                    #endregion

                    hasThucHienLenh = true;
                    cuocGoiRow.LenhDienThoai = commandText;
                    int[] CallStatusNum = { 1, 2, 3, 4, 6 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe, Không xe lần 1)
                    if (command.CallStatus != null && CallStatusNum.Contains(command.CallStatus.Value))
                    {
                        //Cuộc gọi không xe thì ĐTV có thể kết thúc cuộc gọi.
                        if (cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                        {
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        }
                        //Lấy theo cấu hình lệnh
                        else
                        {
                            if (cuocGoiRow.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiHoan 
                                || cuocGoiRow.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiTruot
                                || cuocGoiRow.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                            {
                                cuocGoiRow.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)command.CallStatus;
                            }
                        }
                    }
                    
                    if (command.IsSend_CallCust != null) cuocGoiRow.ChuyenMK = (bool)command.IsSend_CallCust;
                    //Thực hiện xong thì thoát vòng lặp
                    break;
                }
            }


            #endregion

            #region *********** Sửa thông tin tuyến đường dài *********

            if (e.KeyData == Keys.F4)
            {
                if (Config_Common.NhapTuyenDuongDai && (int)cuocGoiRow.LoaiCuocKhach == 2)
                {
                    frmNhapTuyenDuongDai frmDuongDai = new frmNhapTuyenDuongDai();
                    frmDuongDai.CuocGoi = cuocGoiRow;
                    frmDuongDai.ShowDialog();
                    if (frmDuongDai.IsSuccess)
                    {
                        bool updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi_V2(cuocGoiRow);
                        if (!updateSuccess)
                        {
                            msgDialog.Show(this, "Không lưu được dữ liệu, vui lòng liên hệ với quản trị", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                            return;
                        }
                    }
                }
            }
            #endregion

            #region **************** Xem lịch sử cuốc điều ****************

            if (e.KeyData == (Keys.Control | Keys.H))
            {
                if (cuocGoiRow.FT_IsFT)
                {
                    using (frmLichSuCuocDieu frmLichSuCuocDieu = new frmLichSuCuocDieu(cuocGoiRow))
                    {
                        frmLichSuCuocDieu.ShowDialog();
                    }
                }
                else if (cuocGoiRow.G5_SendDate != null)
                {
                    using (frmCommandHistory frmLichSuCuocDieu = new frmCommandHistory(cuocGoiRow.IDCuocGoi, string.Format("{0}-{1}", cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach)))
                    {
                        frmLichSuCuocDieu.ShowDialog();
                    }
                }
                return;
            }

            #endregion

            #region **************** Key Enter ****************************

            if (e.KeyData == Keys.Enter)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                {
                    if (IsSanBay)
                    {
                        NhapDuLieuVaoTruyenDiSanBay(positionRowSelect);
                    }
                    else if (g_HasPopUpNewCall && alertNewCall.AlertFormList.Count > 0)
                    {
                        ShowFormInPut();                        
                    }
                    else
                    {
                        NhapDuLieuVaoTruyenDiV2(positionRowSelect);
                    }
                }
            }
            #endregion

            #region Escape
            else if (e.KeyData == Keys.Escape)
            {
                if (g_HasPopUpNewCall && alertNewCall.AlertFormList.Count > 0)
                {
                    alertNewCall.AlertFormList[0].Close();
                }
            }

            #endregion

            #region ****************  Space || Ctrl + C **************************

            else if ((e.KeyData == Keys.Space) && (g_COMPort.Length > 0 || !string.IsNullOrEmpty(g_lineIPPBX2)))
            {
                cuocGoiRow.LenhDienThoai = CommandCode.LENH_DANGGOI;
                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                hasThucHienLenh = true;
                try
                {
                    CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("Update_ThoiDiemMoiKhach", ex);
                }
                if (!string.IsNullOrEmpty(g_lineIPPBX2))
                {
                    HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, true, g_lineIPPBX2);
                }
                else if (g_COMPort.Length > 0)
                {
                    HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, false, g_lineIPPBX1);
                }
            }
            else if (e.KeyData == (Keys.Control | Keys.Space))
            {
                if (G_CallOut_Count >= 5)
                {
                    G_CallOut_Count = 0;
                    HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, true, g_lineIPPBX1);

                    cuocGoiRow.LenhDienThoai = CommandCode.LENH_DANGGOI;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    hasThucHienLenh = true;
                    CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
                }
            }

            #endregion

            #region **************** Tập lệnh xử lý ***********************

            #region  ---------- Delete:Thoát cuốc  ----------
            //================ delete : Thoát cuộc gọi khác
            else if (e.KeyData == Keys.Delete)
            {
                //Cuốc điều app ko cho phép xóa cuốc
                if (cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp
                    || cuocGoiRow.G5_Type == Enum_G5_Type.CuocAppKH
                    || cuocGoiRow.G5_Type == Enum_G5_Type.CuocKhongXeApp
                    || cuocGoiRow.G5_Type == Enum_G5_Type.CuocVangLai
                    || (cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam && cuocGoiRow.G5_SendDate != null))
                    return;
                e.Handled = true;
                string dialog = msgDialog.Show(
                    string.Format("Cuộc gọi khác {0}...?", cuocGoiRow.DiaChiDonKhach), "Thông báo",
                    MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                if (dialog == "Yes")
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.DiaChiDonKhach = cuocGoiRow.DiaChiDonKhach.Length > 0
                        ? cuocGoiRow.DiaChiDonKhach
                        : "delete";
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                    cuocGoiRow.KieuCuocGoi = KieuCuocGoi.GoiKhac;
                }
                else
                {
                    return;
                }
            }
            #endregion

            #region --------- Alt+C: Gọi cho lái xe -------
            else if (e.KeyData == (Keys.Alt | Keys.C))
            {
                if (!string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                {
                    if (CommonBL.DictDriver.ContainsKey(cuocGoiRow.XeNhan))
                    {
                        T_NHANVIEN objDriver = CommonBL.DictDriver[cuocGoiRow.XeNhan];
                        string soDT = objDriver.DiDong;
                        if (!string.IsNullOrEmpty(soDT))
                        {
                            string text = string.Format("Xe {0} - {1}", cuocGoiRow.XeNhan, objDriver.TenNhanVien);
                            HienThiFormGoiDienThoai(soDT, text, true, g_lineIPPBX1);
                        }
                        else
                        {
                            new MessageBoxBA().Show(string.Format("Lái xe {0}-{1} chưa có thông tin số điện thoại", cuocGoiRow.XeNhan, objDriver.TenNhanVien), "Thông báo", MessageBoxButtonsBA.OK);
                        }
                    }
                    else
                    {
                        new MessageBoxBA().Show(string.Format("Hiện tại không có lái xe nào chạy xe {0}", cuocGoiRow.XeNhan), "Thông báo", MessageBoxButtonsBA.OK);
                    }
                }
                else
                {
                    new MessageBoxBA().Show(string.Format("Không gọi được. Chưa có xe nhận"), "Thông báo", MessageBoxButtonsBA.OK);
                }
            }
            #endregion   

            #region  ---------- Backspace:Xóa lệnh  ----------
            //============== Backspace : xóa lệnh
            else if (e.KeyData == Keys.Back)
            {
                // thực hiện khi có xe nhận
                if (cuocGoiRow.LenhDienThoai != "")
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhDienThoai = "";
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                }
            }
            #endregion
            
            #endregion            
            
            #region **************** Nhập xe ******************************
            //================= / : chon nhap xe nhan
            else if (e.KeyData == Keys.Divide && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
            {
                if (Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS)
                {
                    return;
                }
                hasThucHienLenh = NhapXeNhan(cuocGoiRow, positionRowSelect, "", ref changeXeNhan);
            }
            //================= * : chon nhap Xe Den diem
            else if (e.KeyData == Keys.Multiply && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
            {
                if (Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS)
                {
                    return;
                }
                hasThucHienLenh = NhapXeDenDiem(cuocGoiRow, positionRowSelect, "", false);
                

            } //================= - : chon nhap Xe Don
            else if (e.KeyData == Keys.Subtract && (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || (!string.IsNullOrEmpty(cuocGoiRow.XeNhan) && cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp && (Config_Common.DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan == 0 || (g_TimeServer - cuocGoiRow.ThoiDiemGoi).TotalMinutes > Config_Common.DienThoai_DieuApp_SoPhutChoPhepNhapXeDonKhiCoXeNhan)))) //Nhập xe đón và hoàn thành
            {
                if (Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS)
                {
                    return;
                }
                hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "", false, ref changeXeDon, ref changeXeNhan);
                if (hasThucHienLenh && cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp)
                {
                    if (!string.IsNullOrEmpty(cuocGoiRow.XeDon) && changeXeNhan)
                        G5ServiceSyn.SendConfirmDoneBook(cuocGoiRow, Services.Operations.EnumConfirmDoneBook.MissTrip);
                    else
                    {
                        G5ServiceSyn.SendConfirmDoneBook(cuocGoiRow, Services.Operations.EnumConfirmDoneBook.Done);
                    }

                    #region Send SMS
                    if (!string.IsNullOrEmpty(cuocGoiRow.XeDon) && Config_Common.SMS_CuocDuongDai_App_LaiXe_Send == Enum_SendSMSCuocDuongDai_App.NhapXeDon && cuocGoiRow.XeDon != "000")
                        SendSMS_App_DuongDai(cuocGoiRow, cuocGoiRow.XeDon);
                    #endregion
                }
            }
            else if (e.KeyData == Keys.Add && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
            {
                hasThucHienLenh = NhapXeDungDiem(cuocGoiRow,positionRowSelect,"");
            }
            #endregion

            #region **************** Lưu danh bạ ************************
            // Lưu địa chỉ vào danh bạ
            else if (e.KeyData == Keys.F2)
            {
                AddPhoneNumToContact();
            }
            #endregion

            #region **************** Gửi tin nhắn ****************
            //============Gửi tin nhắn
            else if (e.KeyData == Keys.S)
            {
                if (ThongTinDangNhap.PermissionsFull.Contains(DanhSachQuyen.TagGuiTinNhan))
                {
                    int KenhVung = cuocGoiRow.Line;
                    if (KenhVung > 0)
                    {
                        string TieuDe = "Tin nhắn gửi từ máy ĐHV số " + g_LinesDuocCapPhep;

                        string NoiDung =
                            string.Format("Thời điểm gọi : {0}{1} Số điện thoại : {2}{3} Địa chỉ : {4}{5}"
                                , cuocGoiRow.ThoiDiemGoi.ToShortTimeString(), Environment.NewLine
                                , cuocGoiRow.PhoneNumber, Environment.NewLine
                                , cuocGoiRow.DiaChiDonKhach, Environment.NewLine);
                        string TaiKhoan = Users.GetIPByVungKenh(KenhVung.ToString());

                        SendMessage frmMessage = new SendMessage(TieuDe, NoiDung, TaiKhoan);
                        frmMessage.Show();
                    }
                }
                else
                {
                    msgDialog.Show(this, "Bạn không có quyền gửi tin nhắn.", 
                                    "Thông báo",MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                }
            }
            #endregion

            #region **************** B : Bản đồ ****************

            else if (e.KeyData == Keys.B)
            {
                new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
            }
            #endregion

            #region **************** C : Copy **********************

            else if (e.KeyData == (Keys.Control | Keys.C))
            {
                try
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
                catch (Exception ex)
                {
                    LogError.WriteLogError("Bản đồ", ex);
                    return;
                }
            }

            #endregion

            #region **************** Cập nhật dữ liệu ****************            

            if (hasThucHienLenh)//*command
            {
                var checkChange = new CuocGoi.CheckChange();
                checkChange.DiaChiDon = true;
                checkChange.DiaChiTra = true;
                checkChange.XeNhan = !changeXeNhan && !changeXeDon;
                checkChange.XeDon = !changeXeDon;
                cuocGoiRow.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                bool updateSuccess = false;
                try
                {
                    if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
                        updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoiRow);
                    else
                        updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi(cuocGoiRow, checkChange);
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("hasThucHienLenh" , ex);
                }

                if (!updateSuccess)
                {
                    msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo",MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);                    
                }
                else
                {
                    ChangeCuocGoiOnListCurrent(cuocGoiRow);
                    if (isChuyenApp)
                    {
                        NhapDuLieuVaoTruyenDiV2(grvChoGiaiQuyet.FocusedRowHandle);                        
                    }
                }
            }

            #endregion
            
        }

        private void SendSMS_App_DuongDai(CuocGoi cuocGoiRow, string xeGuiSMS)
        {
            if (Config_Common.App_SendSMS_Customer)
            {
                if (cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                {
                    int GiaPhuTroi = 0;
                    int LoaiXeID = 0;
                    string GiaPhuTroi_Gio = "";
                    Services.ServiceApp_XHD.TcpOPDirection chieu = Services.ServiceApp_XHD.TcpOPDirection.MotChieu;
                    if (cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachDuongDai)
                    {
                        int.TryParse(cuocGoiRow.Long_LoaiXeID, out LoaiXeID);
                        VuotGioQuyDinh temp = CommonBL.ListDanhMucVuotGio.Find(a => a.FK_LoaiXeID == LoaiXeID);
                        if (temp != null)
                        {
                            if (cuocGoiRow.Long_ChieuID == (int)Services.ServiceApp_XHD.TcpOPDirection.HaiChieu)
                            {
                                int.TryParse(temp.GiaDinhMucVuot1KmHaiChieu.ToString(), out GiaPhuTroi);
                                chieu = Services.ServiceApp_XHD.TcpOPDirection.HaiChieu;
                                GiaPhuTroi_Gio = temp.GiaDinhMucVuot1GioHaiChieu.ToString();
                            }
                            else
                            {
                                int.TryParse(temp.GiaDinhMucVuot1KmMotChieu.ToString(), out GiaPhuTroi);
                            }
                        }
                    }
                    WCFServicesAppXHD.SendSMS_ReceiveCatchedUser(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, xeGuiSMS, cuocGoiRow.Long_GiaTien, cuocGoiRow.LoaiCuocKhach, GiaPhuTroi, cuocGoiRow.Long_Km, chieu, GiaPhuTroi_Gio);
                }
                else
                {
                    int GiaPhuTroi = 0;
                    int LoaiXeID = 0;
                    string GiaPhuTroi_Gio = "";
                    Services.ServiceApp.TcpOPDirection chieu = Services.ServiceApp.TcpOPDirection.MotChieu;
                    if (cuocGoiRow.LoaiCuocKhach == LoaiCuocKhach.ChoKhachDuongDai)
                    {
                        int.TryParse(cuocGoiRow.Long_LoaiXeID, out LoaiXeID);
                        #region Nếu điều loại xe khác thì lấy lại thông tin giá để gửi sms
                        if (CommonBL.DicObjecXe.ContainsKey(xeGuiSMS))
                        {
                            var objXe = CommonBL.DicObjecXe[xeGuiSMS];
                            if (LoaiXeID != objXe.FK_LoaiXeID)
                            {
                                LoaiXeID = objXe.FK_LoaiXeID;
                                DataTable data = new BangGiaCuoc().LayGiaTheoTuyen(cuocGoiRow.Long_TuyenID, cuocGoiRow.Long_ChieuID, LoaiXeID, 1);
                                if (data.Rows.Count > 0)
                                {
                                    cuocGoiRow.Long_GiaTien = int.Parse(data.Rows[0]["GiaTien"].ToString());
                                    cuocGoiRow.Long_Km = int.Parse(data.Rows[0]["Km"].ToString());
                                    cuocGoiRow.Long_ThoiGian = int.Parse(data.Rows[0]["ThoiGian"].ToString());
                                }
                            }
                        }

                        #endregion

                        VuotGioQuyDinh temp = CommonBL.ListDanhMucVuotGio.Find(a => a.FK_LoaiXeID == LoaiXeID);
                        if (temp != null)
                        {
                            if (cuocGoiRow.Long_ChieuID == (int)Services.ServiceApp.TcpOPDirection.HaiChieu)
                            {
                                int.TryParse(temp.GiaDinhMucVuot1KmHaiChieu.ToString(), out GiaPhuTroi);
                                chieu = Services.ServiceApp.TcpOPDirection.HaiChieu;
                                GiaPhuTroi_Gio = temp.GiaDinhMucVuot1GioHaiChieu.ToString();
                            }
                            else
                            {
                                int.TryParse(temp.GiaDinhMucVuot1KmMotChieu.ToString(), out GiaPhuTroi);
                            }
                        }
                    }
                    WCFServicesApp.SendSMS_ReceiveCatchedUser(cuocGoiRow.BookId, cuocGoiRow.PhoneNumber, xeGuiSMS, cuocGoiRow.Long_GiaTien, cuocGoiRow.LoaiCuocKhach, GiaPhuTroi, cuocGoiRow.Long_Km, chieu, GiaPhuTroi_Gio);

                }
            }
        }

        private void ShowFormInPut()
        {
            try
            {
                int lastIndex = alertNewCall.AlertFormList.Count-1;
                string ID = alertNewCall.AlertFormList[lastIndex].AlertInfo.Tag.ToString();//Show Form đầu tiên!
                if (ListCurrent != null)
                {
                    var cuocGoi = ListCurrent.FirstOrDefault(a => a.IDCuocGoi == ID.To<long>());
                    if (cuocGoi != null)
                    {
                        if (cuocGoi.Vung == 0 && cuocGoi.G5_Type == Enum_G5_Type.DienThoai && !Config_Common.DienThoai_DieuTuDong)
                        {
                            cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                        }
                        alertNewCall.AlertFormList[lastIndex].Close();
                        g_frmInput.LoadCuocGoi(cuocGoi);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShowFormInPut: ", ex);
            }
        }

        private void ChangeCuocGoiOnListCurrent(CuocGoi cg)
        {
            try
            {
                if (cg.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc 
                  ||cg.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                {
                    SapXepLaiIndex(cg);                    
                    ListCurrent.Remove(cg);
                    HienThiLuoi(false, false);
                    //Kết thúc tát cả cảnh bảo của cuốc này trên form cảnh báo nếu có
                    CanhBaoDieuApp.Inst.KetThucCanhBao(cg.IDCuocGoi, "Cuốc đã kết thúc");
                }
                else
                {
                    TimVaCapNhatCuocGoi(ref ListCurrent, cg, true);
                    HienThiLuoi(true, false);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ChangeCuocGoiOnListCurrent", ex);
            }
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
        #endregion

        private void Timer_DateTimeServer_Tick(object sender, EventArgs e)
        {
            g_TimeServer = g_TimeServer.AddSeconds(1);
            G_CallOut_Count++;
        }

        /// <summary>
        /// Hàm quét dữ liệu cuộc gọi hiển thị lên lưới điều!
        /// </summary>
        private void TimerCapturePhoneV2_Tick(object sender, EventArgs e)
        {
            #region == 1 Giây ==
            if (!string.IsNullOrEmpty(G_LineGop))
            {
                if (DieuKienGopLai(g_TimeServer.TimeOfDay, ThongTinCauHinh.GopKenh_GioBD, ThongTinCauHinh.GopKenh_GioKT))
                {
                    g_LinesDuocCapPhep = G_LineGop;
                }
                else
                {
                    g_LinesDuocCapPhep = g_LinesDuocCapPhep_Temp;
                }
                if (CommonBL.HavingSOS)
                {
                    btnHelp.Image = Resources.ic_help_04_01_Red;
                }
                else
                {
                    btnHelp.Image = Resources.ic_help_04_01;
                }
            }
            g_Time3++;
            g_Time5++;
            g_Time7++;
            g_Time10++;
            g_Time60++;
            g_TimeSb++;
            if (Config_Common.DienThoai_DieuTuDong && !backGroundPingApp.IsBusy)
                backGroundPingApp.RunWorkerAsync();
            #endregion

            #region == Lấy cuộc gọi mới và bật Popup lên ==
            BackgroundFunction(() => GetAllCuocGoiMoi(g_LinesDuocCapPhep, _dateMax), T =>
            {
                if (T.HasCuocGoiThaydoi || T.HasCuocGoiMoi)
                {
                    HienThiLuoi(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi);
                    _dateMax = T.DateMax;
                    if (Config_Common.HienThiPopup && T.HasCuocGoiPopUp)
                    {
                        CuocGoi cg = ListCurrent[0];
                        g_CuocGoiHienPopUp = cg;
                        if (!cg.FT_IsFT)// && cg.G5_Type != Enum_G5_Type.DieuApp && cg.G5_Type != Enum_G5_Type.CuocAppKH)
                        {                          
                            if (g_frmInput != null && g_frmInput.Visible)
                            {
                                hasNewCallPending = true;
                                g_frmInput.HienThiThongBaoCoCuocGoiMoi();                                
                            }
                            else //  nguoc lai thi hien thi cuoc dau tien
                            {
                                //Nếu là line mặc định thì hiển thị popup
                                if (Global.LineDuocCapPhep_MacDinh.Contains(cg.Line.ToString()))
                                {
                                    hasNewCallPending = false;
                                    g_frmInput.g_IsNew = true;
                                    NhapDuLieuVaoTruyenDiV2(0);
                                }
                            }                            
                        }
                    }
                }
            }, "GetAllCuocGoiMoi");

            #endregion

            #region === Lưới sân bay ===
            //if (IsDieuSanBay)
            //{
            //    BackgroundFunction(() => GetAllCuocGoiMoi_SB(_DateMax), (T) =>
            //    {
            //        HienThiLuoiSB(T.HasCuocGoiThaydoi, T.hasCuocGoiMoi);
            //        _DateMax = T.DateMax;
            //        if (Config_Common.HienThiPopup && T.hasCuocGoiPopUp)
            //        {
            //            CuocGoi cg = ListCurrent_SanBay[0];
            //            if (!cg.FT_IsFT && cg.G5_Type != Enum_G5_Type.DieuApp)
            //            {
            //                if (g_frmInput != null && g_frmInput.Visible)
            //                {
            //                    hasNewCallPending = true;
            //                    g_frmInput.HienThiThongBaoCoCuocGoiMoi();
            //                }
            //                else //  nguoc lai thi hien thi cuoc dau tien
            //                {
            //                    hasNewCallPending = false;
            //                    NhapDuLieuVaoTruyenDiV2(0); // vi tri dau tin cua loi
            //                }
            //            }
            //        }
            //    }, "GetAllCuocGoiMoi_SB");
            //}

            #endregion

            #region == Lưới khác ==
            if (Config_Common.GridConfig == (int)Grid_Config.Has_Grid_Right)
            {
                BackgroundFunction(() => GetAllCuocGoiMoi_Khac(g_LinesDuocCapPhep, _dateMax_Khac), T =>
                {
                    HienThiLuoi_Khac(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi);
                    _dateMax_Khac = T.DateMax;
                }, "GetAllCuocGoiMoi_Khac");
            }
            #endregion

            #region === Load lưới kết thúc ===
            if (g_boolChuyenTabCuocGoiKetThuc)
            {
                g_boolChuyenTabCuocGoiKetThuc = false;
                BackgroundFunction(() => true, T => LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong));
            }
            #endregion

            #region === Trạng thái ===
            BackgroundFunction(() =>
            {
                var rs = new Return();
                int iSoCuocGoiChuaChuyenSangTongDai = 0;
                int iSoCuocGoiChuaDonDuocXe = 0;
                if (ListCurrent != null)
                {
                    foreach (CuocGoi objDH in ListCurrent)
                    {
                        if (objDH.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                            iSoCuocGoiChuaChuyenSangTongDai += 1;
                        if (objDH.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                            objDH.TrangThaiLenh != TrangThaiLenhTaxi.KhongTruyenDi)
                            iSoCuocGoiChuaDonDuocXe += 1;
                    }
                }
                if (g_iStatus == 1) g_iStatus = 2;
                else g_iStatus = 1;
                rs.Status = g_iStatus;
                rs.SoCuocGoiChuaChuyenSangTongDai = iSoCuocGoiChuaChuyenSangTongDai;
                rs.SoCuocGoiChuaDonDuocXe = iSoCuocGoiChuaDonDuocXe;
                return rs;
            },
               T =>
               {
                   statusImage.ImageIndex = T.Status;
                   status1.Width = 200;
                   status1.EditValue = String.Format("Chưa chuyển tổng đài : {0}", T.SoCuocGoiChuaChuyenSangTongDai);
                   status2.Width = 200;
                   status2.EditValue = String.Format("Chưa đón được khách : {0}", T.SoCuocGoiChuaDonDuocXe);
                   status3.Width = 200;
                   status3.EditValue = String.Format("Đón được khách : {0}", g_CountKetThuc);
               }, "");
            #endregion

            #region == 3 Giây ==
            if (g_Time3 > 3)
            {
                #region == Cập nhật cuốc ==
                BackgroundFunction(() => CapNhapCuocGoiTuTongDai(g_LinesDuocCapPhep, _dateMax3), T =>
                {
                    if (T.HasCuocGoiThaydoi || T.HasCuocGoiMoi)
                    {
                        HienThiLuoi(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi);
                    }
                    _dateMax3 = T.DateMax;
                }, "CapNhapCuocGoiTuTongDai");

                if (Config_Common.GridConfig == (int)Grid_Config.Has_Grid_Right)
                {
                    BackgroundFunction(() => CapNhapCuocGoiTuTongDai_Khac(g_LinesDuocCapPhep, _dateMax_Khac), T =>
                    {
                        HienThiLuoi_Khac(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi);
                        _dateMax_Khac = T.DateMax;
                    }, "CapNhapCuocGoiTuTongDai_Khac");
                }
                #endregion

                #region == Cập nhật cuốc SB==
                if (g_IsDieuSanBay)
                {
                    BackgroundFunction(() => CapNhapCuocGoiTuTongDai_SB(_dateMaxSB), T =>
                    {
                        HienThiLuoiSB(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi);
                        _dateMaxSB = T.DateMax;
                    }, "CapNhapCuocGoiTuTongDai_SB");
                }

                #endregion                

                g_Time3 = 0;
            }
            #endregion

            #region == 5 Giây ==
            if (g_Time5 > 5)
            {
                #region == Load cuốc kết thúc Lưới hiện tại ==
                BackgroundFunction(() => CapNhatCuocGoiKetThucTuTongDai(g_LinesDuocCapPhep), T => 
                    {
                        if (T.HasCuocGoiThaydoi || T.HasCuocGoiMoi)
                            HienThiLuoi(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi);
                    }
                    , "CapNhatCuocGoiKetThucTuTongDai");
                #endregion

                #region == Load cuốc kết thúc Lưới sân bay ==
                if (g_IsDieuSanBay)
                {
                    BackgroundFunction(CapNhatCuocGoiKetThucTuTongDai_SB, T => HienThiLuoiSB(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi), "CapNhatCuocGoiKetThucTuTongDai_SB");
                }
                #endregion

                #region == Load cuốc kết thúc Lưới khác ==
                if (Config_Common.GridConfig == (int)Grid_Config.Has_Grid_Right)
                {
                    BackgroundFunction(() => CapNhatCuocGoiKetThucTuTongDai_Khac(g_LinesDuocCapPhep), T => HienThiLuoi_Khac(T.HasCuocGoiThaydoi, T.HasCuocGoiMoi), "CapNhatCuocGoiKetThucTuTongDai_Khac");
                }
                #endregion

                #region == Cập nhật cuốc sao chép ==
                BackgroundFunction(() =>
                {
                    if (QueueCuocKhachSaoChep != null && QueueCuocKhachSaoChep.Count > 0)
                    {
                        bool flgQueueCuocKhach = false;
                        //Thực hiện kiểm tra những cuốc trong
                        foreach (var item in QueueCuocKhachSaoChep)
                        {
                            if ((g_TimeServer - item.SendDate).TotalSeconds >= Config_Common.DienThoai_DieuApp_SleepCuocSaoChep
                                || ListCurrent.Count(p => p.IDCuocGoi == item.IdCuocGoiTruoc
                                    && !p.LenhLaiXe.Contains("Chờ LX nhận cuốc") && p.LenhLaiXe != "") > 0)
                            {
                                flgQueueCuocKhach = true;
                                var objCG = item.CurrentCuocGoi;
                                LogError.WriteLogInfo(string.Format("QueueCuocKhachSaoChep:{0}-{1}-{2}", objCG.IDCuocGoi, objCG.CuocGoiLaiIDs, objCG.BookId));
                                if (objCG.BookId == Guid.Empty
                                    && objCG.G5_Type == Enum_G5_Type.DieuApp
                                    && objCG.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                                {
                                    if (objCG.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                                    {
                                        LogError.WriteLogInfo(string.Format("QueueCuocKhachSaoChep:{0}-{1}-{2} CAR", objCG.IDCuocGoi, objCG.CuocGoiLaiIDs, objCG.BookId));
                                        WCFServicesAppXHD.SendInitTrip(objCG);
                                    }
                                    else
                                    {
                                        LogError.WriteLogInfo(string.Format("QueueCuocKhachSaoChep:{0}-{1}-{2} TAXI", objCG.IDCuocGoi, objCG.CuocGoiLaiIDs, objCG.BookId));
                                        WCFServicesApp.SendInitTrip(objCG);
                                    }
                                    //objCG.LenhLaiXe = "Chờ LX nhận cuốc";
                                }
                                //Chuyển sang cuốc tiếp theo.
                                item.Next();
                                item.SendDate = g_TimeServer;
                            }
                        }
                        if (flgQueueCuocKhach)
                            QueueCuocKhachSaoChep.RemoveAll(p => p.IsEnd);
                    }
                    return true;
                }, T => { }, "Xử lý cuốc sao chép");
                #endregion

                #region Validate Login
                if (bw_ValidateLogin != null && !bw_ValidateLogin.IsBusy && Config_Common.ValidateLogin && ThongTinDangNhap.USER_ID != "")
                {
                    bw_ValidateLogin.RunWorkerAsync();
                }
                #endregion
                g_Time5 = 0;

            }
            #endregion

            #region == 7 Giây ==
            if (g_Time7 > 7)
            {
                g_Time7 = 0;
            }
            #endregion

            #region == 10 Giây ==
            if (g_Time10 > 10)
            {
                g_Time10 = 0;
                BackgroundFunction(() =>
                {
                    Config_Common.LoadConfigCommonByLastUpdate();
                    if (Config_Common.DienThoai_DieuApp_ChuyenDam == 0 || Config_Common.DienThoai_DieuApp_ChuyenDam == 3)
                    {
                        // nếu  Cuốc điều app  và 1'30 ko có xe nhận thì thì tự đông chuyển sang cuốc điều đàm.
                        foreach (var item in ListCurrent)
                        {
                            if (item.G5_Type == Enum_G5_Type.DieuApp &&
                                item.G5_SendDate != null &&
                                string.IsNullOrEmpty(item.XeNhan) &&
                                (g_TimeServer - item.G5_SendDate.Value).TotalSeconds > Config_Common.DienThoai_DieuApp_ThoiGianChuyenDam)
                            {
                                CuocGoi.G5_DIENTHOAI_UpdateBookTimeout(item.BookId);
                            }
                        }
                    }
                    CommonBL.LoadDrivers_Active_LastUpdate();
                    CommonBL.LoadVehicles_Active_LastUpdate();

                    return true;
                }, T => timerMessage(), "g_Time10");
            }
            #endregion

            #region == 60 Giây ==
            if (g_Time60 > 60)
            {
                BackgroundFunction(() =>
                {
                    string version = string.Empty;
                    var autoupdate = AutoUpdate.Inst.GetUpdateByDateTime(Module.DienThoaiVien, license.Version());
                    if (autoupdate != null)
                    {
                        version = autoupdate.Version;
                        g_ModuleName = autoupdate.ModuleName;
                    }
                    return version;
                }, version =>
                {
                    if (!string.IsNullOrEmpty(version))
                    {
                        notifyUpdateVer.Visible = true;
                        notifyUpdateVer.ShowBalloonTip(60, "Có phiên bản Update " + version, "Khởi động lại phần mềm để cập nhật thay đổi", ToolTipIcon.Warning);
                        notifyUpdateVer.Text = string.Format("Update {0}, Khởi động lại để cập nhật thay đổi", version);
                    }
                }, "Check Version");
                g_Time60 = 0;
            }
            #endregion

            #region== 31 giây, cuốc sân bay sắp điều
            if (g_TimeSb >= 31)//*sign
            {
                if (tabCuocSanBay.PageVisible && Config_Common.CanhBaoCuocSanBay)
                {
                    BackgroundFunction(() =>
                    {
                        ListCurrent_SanBay = FuncGetAllCuocGoiSB();
                        // Cuốc sân bay chuẩn bị đến thời gian hẹn đón: còn <15 phút
                        IEnumerable<CuocGoi> cgsb15 = ListCurrent_SanBay.Where(x => (x.ThoiGianHen - g_TimeServer).TotalMinutes <= 15
                             //&& string.IsNullOrEmpty(x.XeNhan)
                             && !x.Is15);
                        string[] line = g_LinesDuocCapPhep.Split(';');
                        string bao15Phut = "SB[Kiểm tra xe 15 phút]";
                        if (cgsb15.Any())
                        {
                            g_TimeSb = 0;
                            DateTime timeServer = DieuHanhTaxi.GetTimeServer();                            
                            foreach (var item in cgsb15)
                            {                                
                                CanhBaoDieuApp canhBao = new CanhBaoDieuApp();
                                if (canhBao.CheckTrungCanhBao(item.IDCuocGoi, bao15Phut))
                                {
                                    canhBao.IdCuocGoi = item.IDCuocGoi;
                                    canhBao.BookId = item.BookId;
                                    canhBao.Line = int.Parse(line[0]);
                                    canhBao.ThoiGianNhan = item.ThoiGianHen;
                                    canhBao.ThoiGianXuLy = timeServer;
                                    canhBao.NoiDung = bao15Phut;
                                    canhBao.SoDienThoai = item.PhoneNumber;
                                    canhBao.DiaChiDon = item.DiaChiDonKhach;
                                    canhBao.Save();//*sign 
                                    item.Is15 = true;      
                                }                                                                                          
                            }                            
                        }
                        // Cuốc sân bay chuẩn bị đến thời gian hẹn đón: còn <1h30 phút
                        IEnumerable<CuocGoi> cgsb60 = ListCurrent_SanBay.Where(x => (x.ThoiGianHen - g_TimeServer).TotalMinutes <= 60 && (x.ThoiGianHen - g_TimeServer).TotalMinutes >= 15
                            && string.IsNullOrEmpty(x.XeNhan)
                            && !x.Is90);
                        string bao60Phut = "SB[Điều xe 60 phút]";
                        if (cgsb60.Any())
                        {
                            g_TimeSb = 0;
                            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                            foreach (var item in cgsb60)
                            {
                                CanhBaoDieuApp canhBao = new CanhBaoDieuApp();
                                if (canhBao.CheckTrungCanhBao(item.IDCuocGoi, bao60Phut))
                                {
                                    canhBao.IdCuocGoi = item.IDCuocGoi;
                                    canhBao.BookId = item.BookId;
                                    canhBao.Line = int.Parse(line[0]);
                                    canhBao.ThoiGianNhan = item.ThoiGianHen;
                                    canhBao.ThoiGianXuLy = timeServer;
                                    canhBao.NoiDung = bao60Phut;
                                    canhBao.SoDienThoai = item.PhoneNumber;
                                    canhBao.DiaChiDon = item.DiaChiDonKhach;
                                    canhBao.Save();//*sign
                                    item.Is90 = true;        
                                }                                                          
                            }
                        }                        
                        return cgsb15;
                    }, cgsb15 =>{ }, "");
                }
                g_TimeSb = 0;
            }
            #endregion
        }

        private void HienThiPopUpCuocGoiMoi(CuocGoi pCuocGoi)
        {
            try
            {
                string strDiaChiDon = string.Empty;
                if (pCuocGoi.DiaChiDonKhach.Length > 30)
                    strDiaChiDon = pCuocGoi.DiaChiDonKhach.Substring(0, 30)+" ...";
                else
                    strDiaChiDon = pCuocGoi.DiaChiDonKhach;
                AlertInfo alertInfo = new AlertInfo(pCuocGoi.PhoneNumber + " - " + pCuocGoi.ThoiDiemGoi.ToShortDateString() , strDiaChiDon, Resources.ic_Phone__insert_the_call_01);
                alertInfo.Tag = pCuocGoi.IDCuocGoi;
                alertNewCall.FormLocation = AlertFormLocation.BottomRight;
                alertNewCall.AppearanceCaption.ForeColor = GetColorByType(pCuocGoi.KieuKhachHangGoiDen);
                alertNewCall.Show(this,alertInfo);
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

        private struct Return
        {
            public bool HasCuocGoiMoi { get; set; }
            public bool HasCuocGoiThaydoi { get; set; }
            public bool HasCuocGoiPopUp { get; set; }
            public DateTime DateMax { get; set; }
            public int Status { get; set; }
            public int SoCuocGoiChuaChuyenSangTongDai { get; set; }
            public int SoCuocGoiChuaDonDuocXe { get; set; }
        }
        #endregion

        #region===Right click lưới cuôc kết thúc===
        private void strmnu20_Click(object sender, EventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount > 0)
            {
                g_SoDong = 20;
                LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
            }
        }

        private void strmnu50_Click(object sender, EventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount > 0)
            {
                g_SoDong = 50;
                LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
            }

        }

        private void strmnu100_Click(object sender, EventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount > 0)
            {
                g_SoDong = 100;
                LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
            }
        }

        private void strmnuChuyenCuocGoi_Click(object sender, EventArgs e)
        {
            if (grvCuocGoiKetThuc.RowCount > 0)
            {
                RunChuyenCuocGoi();
            }
        }
        #endregion

        #region=== Event Menu Devexpress====

        #region=== Menu Quản trị===
        private void btnItemDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (CapNhatThongTinCaNhan capNhatThongTinCaNhan = new CapNhatThongTinCaNhan())
            {
                capNhatThongTinCaNhan.ShowDialog();
            }
        }

        private void btnItemCheckIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            CheckIn();
        }

        private void btnItemCheckOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            CheckOut();
        }

        private void btnItemThoat_ItemClick(object sender,ItemClickEventArgs e)
        {
            Application.Exit();
        }
        #endregion
        
        #region==Menu Công cụ===
        private void btnItemChenCuocGoiMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmChenMoiMotCuocDienThoai frm = new frmChenMoiMotCuocDienThoai(Global.LineDuocCapPhep_MacDinh, RealTimeEnvironment.ListDataAutoComplete))
            {
                frm.ShowDialog();
            }
        }

        private void btnItemLuuCauHinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabMain.SelectedTabPage.Name == "tabCuocGoiChoGiaiQuyet")
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvChoGiaiQuyet.Name, ThongTinDangNhap.USER_ID, grvChoGiaiQuyet.GetLayoutFromStringXml());
            }
            else if (tabMain.SelectedTabPage.Name == "tabCuocGoiDaGiaiQuyet")
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvCuocGoiKetThuc.Name, ThongTinDangNhap.USER_ID, grvCuocGoiKetThuc.GetLayoutFromStringXml());
            }
            else if (tabMain.SelectedTabPage.Name == "tabTimCuocGoi")
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvTimKiemThongTinCuoc.Name, ThongTinDangNhap.USER_ID, grvTimKiemThongTinCuoc.GetLayoutFromStringXml());
            }
        }

        private void btnItemCauHinhMacDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabMain.SelectedTabPage.Name == "tabCuocGoiChoGiaiQuyet")
            {
                grvChoGiaiQuyet.ResetLayout();
            }
            else if (tabMain.SelectedTabPage.Name == "tabCuocGoiDaGiaiQuyet")
            {
                grvCuocGoiKetThuc.ResetLayout();
            }
            else if (tabMain.SelectedTabPage.Name == "tabTimCuocGoi")
            {
                grvTimKiemThongTinCuoc.ResetLayout();
            }

            if(!Config_Common.NhapTuyenDuongDai)
                HideAllLongColumns();
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
                grvChoGiaiQuyet.Appearance.Row.Font = new System.Drawing.Font(new FontFamily(Config_Common.Grid_Font), Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            }
            if (Config_Common.Grid_HorzLineColor != null && !Config_Common.Grid_HorzLineColor.IsEmpty)
            {
                grvChoGiaiQuyet.Appearance.HorzLine.BackColor = Config_Common.Grid_HorzLineColor;
            }

            //CommonBL._listStaxiLoaiXe = null;
            //LoadDuLieuForAutoComplete();
            // Lấy cấu hình.
            //Config_Common.LoadConfigCommon();
        }

        private void btnItemQuanLyTinNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Messenger().ShowDialog();
        }

        private void btnItemGhiChu_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Controls.frmGhiChu().Show();
        }

        private void btnItemThemDanhBa_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddPhoneNumToContact();
        }

        private void btnItemDanhSachLaiXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmDSLaiXe().ShowDialog();
        }

        private void btnItemTraCuuTheMCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            //using (TraCuuTheMCC traCuuTheMCC = new TraCuuTheMCC())
            //{
            //    traCuuTheMCC.ShowDialog();
            //}
        }

        private void btnItemChotCoSBDD_ItemClick(object sender, ItemClickEventArgs e) 
        {
            using (ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince, G_arrDistrict, G_arrCommune, ""))
            {
                thongTinSanBay_DuongDai.ShowDialog();
            }
        }
         
        private void btnItemDanhSachKhachDat_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmListKhachDat().Show();
        }

        private void btnItemDanhMucKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FrmManagerKhachHang().Show();
        }

        private void btnItemDanhSachChotCoDuongDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (DSCuocDuongDai_SanBay_V2 dSCuocDuongDai_SanBay = new DSCuocDuongDai_SanBay_V2(G_arrProvince, G_arrDistrict, G_arrCommune))
            {
                dSCuocDuongDai_SanBay.ShowDialog();
            }
        }

        #region===Thiết lập kích cỡ lưới===
        private void btnItemLonNhat_ItemClick(object sender, ItemClickEventArgs e)
        {
            grvChoGiaiQuyet.ZoomOut();
        }
        private void btnItemLonVua_ItemClick(object sender, ItemClickEventArgs e)
        {
            grvChoGiaiQuyet.ZoomIn();
        }

        private void btnItemBinhThuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            grvChoGiaiQuyet.ResetZoom();
        }
        #endregion

        private void btnItemCanhBao_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmCanhBao._lstObjectTruocThayDoi.Count > 0)
            {
                frmCanhBao.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Hiện tại không có cảnh báo nào.", "Thông báo");
            }
        }
        #endregion

        #region== Menu ===
        private void btnItemBaoXeDiDuongDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (ThongTinCauHinh.FT_ChieuVe_Active)
                new frmUpdateTrip().ShowDialog();
        }

        private void barItemChenCuocGoiMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmChenMoiMotCuocDienThoai frm = new frmChenMoiMotCuocDienThoai(Global.LineDuocCapPhep_MacDinh, RealTimeEnvironment.ListDataAutoComplete))
            {
                frm.ShowDialog();
            }
        }

        private void barItemDatHen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvChoGiaiQuyet.SelectedRowsCount > 0)
            {
                DatHen();
            }
            else
            {
                new MessageBoxBA().Show(this, "Vui lòng chọn cuộc gọi cần đặt hẹn", "Thông báo",
                    MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
        }

        private void barItemTinhTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
            frm.ShowDialog();
        }

        private void barItemChotCoSBDD_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince, G_arrDistrict, G_arrCommune, ""))
            {
                thongTinSanBay_DuongDai.ShowDialog();
            }
            //using (
            //        ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince,
            //            G_arrDistrict, G_arrCommune, ""))
            //{
            //    thongTinSanBay_DuongDai.ShowDialog();
            //}
        }

        private void barItemTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            int TrangThaiCuocGoi;
            if (tabMain.SelectedTabPageIndex == 0)
            {
                TrangThaiCuocGoi = 1;
            }
            else
            {
                TrangThaiCuocGoi = 2;
            }
            new TimKiemCuocGoi(g_TimeServer, g_LinesDuocCapPhep, TrangThaiCuocGoi, "4").Show();
        }

        private void barItemTongDai1080_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmDMDiaDanh frmDMDiaDanh = new frmDMDiaDanh())
            {
                frmDMDiaDanh.ShowDialog();
            }
        }

        private void barItemTraCuuThe_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmMemberCard_Search().ShowDialog();
        }
        #endregion

        private void themVaoDanhBaCongTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvChoGiaiQuyet.SelectedRowsCount > 0)
            {
                #region Them so dien thoai vao db cong ty
                AddPhoneNumToContact();
                #endregion Them so dien thoai vao db cong ty
            }
        }

        #endregion

        private void btnBC_1_3_ChiTietCuocGoiDen_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmBC_1_3_BaoCaoChiTietCuocGoiDen().Show();
        }

        private void btnBC_4_6_KQDieuHanhTheoNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            //new frmBC_4_6_KQDieuHanhNVTheoNgay().Show();
            new frmBC_4_6_KQDieuHanhNVTheoNgay_V2().Show();
        }

        private void btnTraCuuGiaCuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmTraCuuBangGiaGoc().Show();
        }

        private void btnNhatKyThueBao_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmThongTinNhatKyThueBao().Show();
        }

        private void btnBC_1_1_TongHopCuocGoiTheoNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmBC_1_1_BaoCaoTongHopCuocKhachDieuHanh_V2().Show();
        }

        private void btnItemGuiTinNhanSMS_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmSendListMessage().ShowDialog();
        }

        private void barButton_BanDoXeOnline_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Controls.Maps.FrmBanDo_Online().Show();
        }

        private void status6_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButton_DanhBaCongTy_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmDMDanhBaCongTy().Show();
        }

        private void barButton_ChotCoDD_Mini_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmXeBaoDiSanBay_DuongDai_Mini thongTinSanBay_DuongDai = new frmXeBaoDiSanBay_DuongDai_Mini())
            {
                thongTinSanBay_DuongDai.ShowDialog();
            }
        }

        private void toolStripMenu_AddPOI_Click(object sender, EventArgs e)
        {
            AddPOI();
        }

        private void barButton_GopLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (ConfigLine frmConfigLine = new ConfigLine())
            {
                //if(
                    frmConfigLine.ShowDialog() ;
                    //== System.Windows.Forms.DialogResult.OK)
                {
                    if (Global.LineDuocCapPhep != g_LinesDuocCapPhep)
                    {
                        TimerCapturePhone.Stop();
                        g_LinesDuocCapPhep = Global.LineDuocCapPhep;
                        LoadAllCuocGoi(g_LinesDuocCapPhep);
                        TimerCapturePhone.Start();
                        Text = String.Format("{0} - Điện thoại viên  [{1} - {2}] - {3} - {4}",
                    Configuration.GetCompanyName(), g_LinesDuocCapPhep, QuanTriCauHinh.IpAddress,
                    ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME);
                    }
                }
            }
        }

        private void btnReloadGridCuocGoi_Click(object sender, EventArgs e)
        {
            HienThiLuoi(false, false);
        }

        
    }

    #region === Class QueueCuocKhach ===
    public class QueueCuocKhach
    {
        public QueueCuocKhach(long idCuocGoiTruoc,CuocGoi currentCuocGoi,DateTime sendDate)
        {
            IsEnd = false;
            this.IdCuocGoiTruoc = idCuocGoiTruoc;
            this.CurrentCuocGoi = currentCuocGoi;
            this.SendDate = sendDate;
        }
        /// <summary>
        /// ID cuốc cần kiểm tra điều kiện xem đã có xe nhận và ko xe hoặc là cuốc đó kết thúc
        /// </summary>
        public long IdCuocGoiTruoc { get; set; }
        /// <summary>
        /// Thời gian gửi đi.
        /// </summary>
        public DateTime SendDate { get; set; }
        /// <summary>
        /// Cuốc hiện tại cần xử lý gửi đi điêu tiếp.
        /// </summary>
        public CuocGoi CurrentCuocGoi { get; set; }
        /// <summary>
        /// Hàng đợi của các thông tin Cuốc khách trước đó
        /// </summary>
        public ConcurrentQueue<CuocGoi> ListQueueCuocGoi = new ConcurrentQueue<CuocGoi>();
        /// <summary>
        /// Số lượng cuốc còn lại trong queue
        /// </summary>
        public int CountQueue { get { return ListQueueCuocGoi.Count; } }
        public bool IsEnd { get;  set; }
        /// <summary>
        /// Thêm vào hàng đợi.
        /// </summary>
        public void Add(CuocGoi cuocKhach)
        {
            ListQueueCuocGoi.Enqueue(cuocKhach);
        }

        /// <summary>
        /// Còn tiếp để next không?
        /// </summary>
        public void Next()
        {
            CuocGoi cuocKhach;
            if (CountQueue > 0 && ListQueueCuocGoi.TryDequeue(out cuocKhach))
            {
                IdCuocGoiTruoc = CurrentCuocGoi.IDCuocGoi;
                CurrentCuocGoi = cuocKhach;
                SendDate = DateTime.Now;
                return;
            }
            IsEnd = true;
        }
    }
    #endregion
}