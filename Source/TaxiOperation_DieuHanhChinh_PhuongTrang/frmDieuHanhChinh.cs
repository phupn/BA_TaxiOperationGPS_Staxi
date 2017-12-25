using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;
using ChartDirector;
using Taxi.Business.DM;
using System.Collections;
using Taxi.GUI.BaoCao;
using System.Diagnostics;
using Taxi.Business.QuanTri;
using TaxiOperation_DieuHanhChinh;
using TaxiOperation_DieuHanhChinh.BaoCao.New;
using Taxi.Business.GridLayout;
using GMap.NET.WindowsForms.Markers;
using TaxiOperation_MoiGioi;
using Taxi.Business.CheckCoDuongDai;
using TaxiOperation_DienThoai.CheckCoDuongDai;
using TaxiOperation_DieuHanhChinh.SystemAdmin;
using DieuHanhChinh.DM;
using Taxi.GUI.CheckCoDuongDai;
using Taxi.Services;
using Taxi.Services.WCFServices;
using Taxi.Controls.FastTaxis.TaxiTrip;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Controls.FastTaxis.BaoCao;
using TaxiOperation_BanCo.Config;
using TaxiOperation_BanCo.DM;
using Taxi.Controls.Configs;
using Taxi.Controls.DanhMuc;
using Taxi.Controls.DanhSach.DMDuongPho;

namespace Taxi.GUI
{
    public partial class frmDieuHanhChinh : Form
    {
        #region -------------------Init-------------------------------------------
        private static Taxi.MessageBox.MessageBoxBA MessageBox = new Taxi.MessageBox.MessageBoxBA();

        private List<CuocGoi> g_lstDienThoai = new List<CuocGoi>();
        private bool g_boolChuyenTabCuocGoiKetThuc = false; // thiet lap de load trong timer
        private bool g_boolChuyenTabCuocGoiHienTai = true; // mac dinh la load luon dau tien
        private bool g_boolCoThayDoiDuLieu = false;
        private int g_iStatus = 0;  // Blink stauts
        private DateTime g_TimeServer = DateTime.MinValue;
        private DateTime g_ThoiDiemNhanDulieuTruoc = DateTime.MinValue;
        private DateTime g_ThoiDiemNhanDulieuTruoc_ThayDoiDuLieu = DateTime.MinValue;
        private int g_TimerStep = 0; //
        // private TaxiOperation_DieuHanhChinh.QuanLyChat.Messenger frmMessenger = new TaxiOperation_DieuHanhChinh.QuanLyChat.Messenger();

        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.Timer TimerCaptureDieuHanhChinh;
        private fmProgress m_fmProgress = null;
        private string g_VungChonKiemSoat = "";
        // Khai bao ma nguoi dung he thong
        private string strUser_Id;

        private GridLayout gridLayout;

        private List<Province> G_arrProvince;
        private List<District> G_arrDistrict;
        private List<Commune> G_arrCommune;

        private frmGiamSatXe frmGSXe;
        private List<NhanVien> G_ListLaiXe = new List<NhanVien>();
        #endregion
        
        private void loadLayout(GridEX gridEX)
        {
            gridLayout = new GridLayout(ThongTinDangNhap.USER_ID, "DieuHanhChinh", this.Name, gridEX.Name);
            gridEX.LoadLayout(gridLayout.getLayout(gridEX.GetLayout()));
        }

        public frmDieuHanhChinh()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (DieuHanhTaxi.CheckConnection())
                {
                    TaxiReturn_Process.StartTimeServer();
                    //string license = Service_Common.CheckLicense();
                    //if (license != "")
                    //{
                    //    new MessageBox.MessageBox().Show(this, license, "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //    Application.Exit();
                    //}
                    //System.Net.IPAddress[] a = System.Net.Dns.GetHostAddresses("phuhoangcorp.no-ip.org");
                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();
                    license.CheckThongTinSDTCongTy(ThongTinCauHinh.SoDienThoaiCongTy.Trim());
                    //---------------------------------------------------- 
                    
                    CheckIn_CheckOut frmDangNhap = new CheckIn_CheckOut();
                    DialogResult dlgResult = frmDangNhap.ShowDialog();
                    strUser_Id = ThongTinDangNhap.USER_ID;
                    lnkDSXeChuaCoThongTinLaiXe.Visible =!ThongTinCauHinh.KiemTraXeDaRaHoatDong;  

                    this.Text = Configuration.GetCompanyName() + " - " + this.Text;
                    string IPAddress = QuanTriCauHinh.GetIPPC();
                    if ((IPAddress == "127.0.0.1") || IPAddress == "192.168.1.10" || IPAddress == "192.168.1.12")
                    {
                        mnuThoatCuoc.Visible = true;
                    }
                    else mnuThoatCuoc.Visible = false;
                    if (DateTime.Now.Hour < 8)
                    {
                        //KiemSoatXeLienLac.DeleteNhungTrangThaiXeNhoHon3ThangGanDay();
                        CuocGoiDi.DeleteNhungCuocGoiDiNhoHon3ThangGanDay();
                    }

                    LoadAllCuocGoiHienTai(g_VungChonKiemSoat);
                    HienThiTrenLuoi(true, true);
                    gridDienThoai.Focus();
                    InitTimerCapturePhone(); // Khoi tao bat cuoc goi
                    //--------------------------LAYOUT-------------------------------------
                    //loadLayout(gridDienThoai);
                    //--------------------------LAYOUT-------------------------------------

                    g_TimeServer = DieuHanhTaxi.GetTimeServer();
                    g_ThoiDiemNhanDulieuTruoc = g_TimeServer;
                    g_ThoiDiemNhanDulieuTruoc_ThayDoiDuLieu = g_TimeServer;

                    G_arrProvince = Province.GetAllProvince();
                    G_arrDistrict = District.GetAllDistrict();
                    G_arrCommune = Commune.GetAllCommune();
                    Config_Common.LoadConfig_Common();
                    if (!string.IsNullOrEmpty(Config_Common.TongDai_TenCotGhiChuTongDai))
                    {
                        gridDienThoai.RootTable.Columns["GhiChuTongDai"].Caption = Config_Common.TongDai_TenCotGhiChuTongDai;
                        gridCuocGoi_KetThuc.RootTable.Columns["GhiChuTongDai"].Caption = Config_Common.TongDai_TenCotGhiChuTongDai;
                    }

                    LoadListLaiXe();
                  
                        báoCáoFastTaxiToolStripMenuItem.Visible = ThongTinCauHinh.FT_Active;
                    
                    if (ThongTinCauHinh.FT_ChieuVe_Active)
                    {
                        tabTaxiChieuVe.TabVisible = true;
                        taxiChiềuVềToolStripMenuItem.Visible = true;
                        tabbáoCáoStaxiChiềuVềToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        tabTaxiChieuVe.TabVisible = false;
                        taxiChiềuVềToolStripMenuItem.Visible =false;
                        tabbáoCáoStaxiChiềuVềToolStripMenuItem.Visible = false;
                    }
                  //  PhanQuyenMenu();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    Application.Exit();
                }

                statusBar.Panels["TenDangNhap"].Text  =  ThongTinDangNhap.FULLNAME;

                if (ThongTinDangNhap.USER_ID.ToLower() != "admin")
                {
                    //thực hiện phân quyền trên menu
                    PhanQuyenMenu(EF02_mnuMain, ThongTinDangNhap.PermissionsFull);
                }
                if (ThongTinDangNhap.USER_ID.ToLower() == "admin")
                {
                    if (!Directory.Exists(ThongTinCauHinh.ThuMucDuLieuTanasonic))
                    {
                        mnuBackupDulieu.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show(this, ex.Message , "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                if (TimerCaptureDieuHanhChinh != null) TimerCaptureDieuHanhChinh.Enabled = false;                
            }
        }
        /// <summary>
        /// Load danh sách lái xe của hệ thống
        /// </summary>
        private void LoadListLaiXe()
        {
            G_ListLaiXe = new NhanVien().GetListNhanViens();
        }

        /// <summary>
        /// PHÂN QUYỀN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        /// <summary>
        /// Thêm tên người đăng nhập vào status bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <Modified>
        /// Name        Date        Comment
        /// LongNM      20/03/2008  Tạo mới
        /// LongNM      06/05/2008  Thêm method phân quyền trên menu
        /// </Modified> 
        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Phân quyền trên menu theo danh sách quyền của người dùng
        /// </summary>
        /// <param name="menu">Menu cần phân quyền</param>
        /// <param name="DataTablePermission">Danh sách quyền người dùng</param>
        /// <Modified>
        /// Name        Date        Comment
        /// LongNM      06/05/2008  Tạo mới
        /// HaiNT       26/05/2008  Kiểm tra DanhSachQuyen not null
        /// </Modified> 
        private void PhanQuyenMenu(MenuStrip MenuPhanQuyen, ArrayList DanhSachQuyen)
        //Phân quyền trên menu
        {
            if (MenuPhanQuyen != null && MenuPhanQuyen.Tag != null && MenuPhanQuyen.Tag.ToString().ToString().Length <= 0)
                MenuPhanQuyen.Visible = true;
            foreach (ToolStripMenuItem mnuItem in MenuPhanQuyen.Items)
            {
                if (DanhSachQuyen != null && mnuItem.Tag!=null )
                {                    
                    if (DanhSachQuyen.Contains(mnuItem.Tag.ToString ()) )
                        mnuItem.Visible = true;
                    else
                       mnuItem.Visible = false;
                    if (mnuItem != null && mnuItem.Tag != null  &&  mnuItem.Tag.ToString().Length <=0  )
                         mnuItem.Visible = true;                     
                }
                //Phân quyền các menu con (nếu có)
                if (mnuItem != null && mnuItem.DropDownItems.Count > 0)
                {
                    PhanQuyenMenuItem(mnuItem, DanhSachQuyen);
                }                 
            }
        }

        /// <summary>
        /// Phân quyền trên menu item theo danh sách quyền của người dùng
        /// </summary>
        /// <param name="MenuItemPhanQuyen">Menu item cần phân quyền</param>
        /// <param name="DanhSachQuyen">Danh sách quyền người dùng</param>
        /// <Modified>
        /// Name        Date        Comment
        /// LongNM      06/05/2008  Tạo mới
        /// HaiNT       26/05/2008  Kiểm tra DanhSachQuyen not null
        /// </Modified>
        private void PhanQuyenMenuItem(ToolStripMenuItem MenuItemPhanQuyen, ArrayList DanhSachQuyen)
        {
            if (MenuItemPhanQuyen != null && MenuItemPhanQuyen.Tag != null && MenuItemPhanQuyen.Tag.ToString().Length <= 0)
                MenuItemPhanQuyen.Visible = true;
            //phân quyền cho menu item
            if (DanhSachQuyen != null && MenuItemPhanQuyen != null && MenuItemPhanQuyen.Tag!= null)
             {
                 if (DanhSachQuyen.Contains(MenuItemPhanQuyen.Tag.ToString ()))
                     MenuItemPhanQuyen.Visible = true;
                 else
                      MenuItemPhanQuyen.Visible = false;
                  if (MenuItemPhanQuyen != null &&  MenuItemPhanQuyen.Tag != null  &&  MenuItemPhanQuyen.Tag.ToString().Length <= 0   )   
                      MenuItemPhanQuyen.Visible = true;
            }
            //phân quyền cho các menu item con (nếu có)
            if (MenuItemPhanQuyen!= null && MenuItemPhanQuyen.DropDownItems.Count > 0)
            {
                for (int i = 0; i < MenuItemPhanQuyen.DropDownItems.Count;i++ )
                {
                    object mnuItem = MenuItemPhanQuyen.DropDownItems[i];
                    if (mnuItem != null)
                    {
                        if (!(mnuItem is System.Windows.Forms.ToolStripSeparator))
                            PhanQuyenMenuItem((ToolStripMenuItem)mnuItem, DanhSachQuyen);
                    }
                }
            }
        }

        public void Timer_Tick(object sender, EventArgs eArgs)
        {
          // uiStatus.Panels[1].Text  = "Ngày : " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
        }
       
        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();

            TimerCaptureDieuHanhChinh = new System.Windows.Forms.Timer();
            TimerCaptureDieuHanhChinh.Interval = TimerLength;
            TimerCaptureDieuHanhChinh.Tick += new EventHandler(TimerCapturePhone_Tick);
            TimerCaptureDieuHanhChinh.Start();

        }

        /// <summary>
        /// Doc du lieu tu server ve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        public void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                if (g_boolChuyenTabCuocGoiHienTai)
                {
                    LoadDataDieuHanhChinh_V3();

                    //NhanCacCuocGoiMoiVe();
                    //XoaCacCuocGoi_TongDaiKetThuc();
                    //CapNhatThongTinCuocGoiBiThayDoi();
                    //XuLyCuocGoiNho();
                }
                if (g_boolChuyenTabCuocGoiKetThuc)
                {
                    LoadCacCuocGoiKetThuc();
                    g_boolChuyenTabCuocGoiKetThuc = false;
                }

                // Xu ly dien thi anh trang thai, va trang thai mau cua chatting

                BlinkStatus(g_iStatus);
                if (g_iStatus == 1) g_iStatus = 2;
                else g_iStatus = 1;
                ViewTrangThaiCacCuocGoiO_StatusBar();
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Loi trong timer ", ex);
            }
        }

        #region ------------------Load Data DieuHanhChinh V3

        private void LoadAllCuocGoiHienTai(string Vung)
        {
            g_lstDienThoai = new List<CuocGoi>();
            g_lstDienThoai = CuocGoi.DIEUHANHCHINH_LayAllCuocGoi_V3(Vung);
        }

        private void LoadDataDieuHanhChinh_V3()
        {
            g_TimeServer = g_TimeServer.AddSeconds(1);
            bool hasCuocGoiMoi = false;
            bool hasCuocGoiThayDoi = false;
            GetAllCuocGoiMoi(g_lstDienThoai, g_ThoiDiemNhanDulieuTruoc, ref hasCuocGoiMoi, g_VungChonKiemSoat);
            if (hasCuocGoiMoi)
            {                
                g_ThoiDiemNhanDulieuTruoc = g_TimeServer;
                HienThiTrenLuoi(hasCuocGoiMoi, true);
            }
            g_TimerStep++;
            if (g_TimerStep >= 3)  // 3 giây cập nhật một lần
            {
                hasCuocGoiMoi = false; hasCuocGoiThayDoi = false;
                CapNhapCuocGoiMoiThayDoiDuLieu(ref g_lstDienThoai, g_ThoiDiemNhanDulieuTruoc_ThayDoiDuLieu, ref hasCuocGoiThayDoi, g_VungChonKiemSoat);
                if (hasCuocGoiThayDoi)
                {
                    HienThiTrenLuoi(hasCuocGoiMoi, hasCuocGoiThayDoi);
                    g_ThoiDiemNhanDulieuTruoc_ThayDoiDuLieu = g_TimeServer;
                }
                CapNhatCuocGoiKetThuc(ref g_lstDienThoai, ref hasCuocGoiMoi, g_VungChonKiemSoat);
                if (hasCuocGoiMoi)
                {
                    HienThiTrenLuoi(false, false);
                }
                //HienThiTrenLuoi(hasCuocGoiMoi, hasCuocGoiThayDoi);

                g_TimerStep = 0;
            }

        }

        private void GetAllCuocGoiMoi(List<CuocGoi> listCuocGoiHienTai, DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiMoi,string Vung)
        {
            hasCuocGoiMoi = false;
            List<CuocGoi> listCuocGoiMoi = CuocGoi.DIEUHANHCHINH_LayDSCuocGoiMoi(thoiDiemNhanDulieuTruoc, Vung);
            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoiMoi)
                {
                    if (!KiemTraCuocGoiDaTonTai(listCuocGoiHienTai, objCG))
                    {
                        listCuocGoiHienTai.Insert(0, objCG);
                        hasCuocGoiMoi = true;
                    }
                }
            }
        }

        private void CapNhapCuocGoiMoiThayDoiDuLieu(ref List<CuocGoi> listCuocGoiHienTai, DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiThayDoi,string Vung)
        {
            hasCuocGoiThayDoi = false;
            // Lấy ds cuộc gọi có thay đổi thông tin của tổng đài
            List<CuocGoi> listCuocGoi = CuocGoi.DIEUHANHCHINH_LayDSCuocGoiThayDoi_V3(Vung, thoiDiemNhanDulieuTruoc);
            if (listCuocGoi != null && listCuocGoi.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoi)
                {
                    hasCuocGoiThayDoi = true;
                    TimVaCapNhatCuocGoi(ref listCuocGoiHienTai, objCG, false);
                }
            }
        }

        private void CapNhatCuocGoiKetThuc(ref List<CuocGoi> listCuocGoiHienTai, ref bool hasCapNhat,string Vung)
        {
            hasCapNhat = false;
            // lấy ds các ID cuộc gọi hiện có
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += String.Format("{0},", cuocGoi.IDCuocGoi);
                }
                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }
            if (listIDCuocGoi.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = CuocGoi.DIEUHANHCHINH_LayCacIDCuocGoiKetThuc_V3(listIDCuocGoi, Vung);
                if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                {
                    foreach (long idCuocGoi in listIDDaKetThuc)
                    {
                        int index = listCuocGoiHienTai.FindIndex(delegate(CuocGoi cuocGoiT)
                        {
                            return (cuocGoiT.IDCuocGoi == idCuocGoi);
                        });
                        if (index >= 0)
                        {
                            listCuocGoiHienTai.RemoveAt(index);
                            hasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                }
            }
        }

        private bool KiemTraCuocGoiDaTonTai(List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi)
        {
            bool tonTai = false;
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoiHienTai)
                {
                    if (objCG.IDCuocGoi == cuocGoi.IDCuocGoi)
                    {
                        tonTai = true; break;
                    }
                }
            }
            return tonTai;
        }

        private void TimVaCapNhatCuocGoi(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi, bool IsCapNhat)
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
                    if (!IsCapNhat) // cap nhat theo du lieu tong dai gui sang
                    {
                        listCuocGoiHienTai[index].TrangThaiCuocGoi = cuocGoi.TrangThaiCuocGoi;
                        listCuocGoiHienTai[index].LenhTongDai = cuocGoi.LenhTongDai;
                        listCuocGoiHienTai[index].GhiChuTongDai = cuocGoi.GhiChuTongDai;
                        listCuocGoiHienTai[index].MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai;
                        listCuocGoiHienTai[index].LenhDienThoai = cuocGoi.LenhDienThoai;
                        listCuocGoiHienTai[index].GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                        listCuocGoiHienTai[index].MaNhanVienDienThoai = cuocGoi.MaNhanVienDienThoai;
                        listCuocGoiHienTai[index].XeNhan = cuocGoi.XeNhan;
                        listCuocGoiHienTai[index].XeNhan_TD = cuocGoi.XeNhan_TD;
                        listCuocGoiHienTai[index].ThoiGianDieuXe = cuocGoi.ThoiGianDieuXe;
                        listCuocGoiHienTai[index].FileVoicePath = cuocGoi.FileVoicePath;
                        listCuocGoiHienTai[index].VungGPSID = cuocGoi.VungGPSID;
                        listCuocGoiHienTai[index].GPS_KinhDo = cuocGoi.GPS_KinhDo;
                        listCuocGoiHienTai[index].GPS_ViDo = cuocGoi.GPS_ViDo;
                        listCuocGoiHienTai[index].DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                        listCuocGoiHienTai[index].ThoiDiemCapNhatXeDeCu = cuocGoi.ThoiDiemCapNhatXeDeCu;
                        listCuocGoiHienTai[index].TrangThaiLenh = cuocGoi.TrangThaiLenh;
                        listCuocGoiHienTai[index].MOIKHACH_LenhMoiKhach = cuocGoi.MOIKHACH_LenhMoiKhach;
                        listCuocGoiHienTai[index].MOIKHACH_NhanVien = cuocGoi.MOIKHACH_NhanVien;
                        listCuocGoiHienTai[index].XeDenDiem = cuocGoi.XeDenDiem;
                        listCuocGoiHienTai[index].XeDenDiemDonKhach = cuocGoi.XeDenDiemDonKhach;
                        listCuocGoiHienTai[index].Vung = cuocGoi.Vung;
                        listCuocGoiHienTai[index].DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                        listCuocGoiHienTai[index].XeDenDiemDonKhachDeCu = cuocGoi.XeDenDiemDonKhachDeCu;
                        listCuocGoiHienTai[index].XeDenDiemDonKhachDeCu_TD = cuocGoi.XeDenDiemDonKhachDeCu_TD;
                    }
                    else
                    {
                        if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                        {
                            listCuocGoiHienTai.RemoveAt(index);// remove cuoc goi phia dien thoai ket thuc

                        }
                    }
                }
            }
        }

        private void HienThiTrenLuoi(bool hasCuocGoiMoi, bool hasThayDoiThongTin)
        {
            try
            {
                if (hasThayDoiThongTin)
                {
                    if (hasCuocGoiMoi)
                    {
                        gridDienThoai.DataSource = null;
                        gridDienThoai.DataMember = "ListDienThoai";
                        gridDienThoai.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                    }
                    else
                    {
                        gridDienThoai.Refresh();
                    }
                }
                else
                {
                    gridDienThoai.Refetch();
                    //gridDienThoai.MoveToRowIndex(g_RowIndex);
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
        
        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Name == "uiTabCuocGoiKetThuc")
            {
                g_boolChuyenTabCuocGoiHienTai = false; // thiet lap de load trong timer
                g_boolChuyenTabCuocGoiKetThuc = true;
                //--------------------------LAYOUT-------------------------------------
                loadLayout(gridCuocGoi_KetThuc);
                //--------------------------LAYOUT-------------------------------------
            }
            else if (e.Page.Name == "uiTabCuocGoiChoGiaiQuyet")
            {
                g_boolChuyenTabCuocGoiHienTai = true;
                g_boolChuyenTabCuocGoiKetThuc = false;
                //--------------------------LAYOUT-------------------------------------
                loadLayout(gridDienThoai);
                //--------------------------LAYOUT-------------------------------------
            }
            else if (e.Page.Name == "tabBaoCaoNhanhCuocGoi")
            {
                calNgay.Value = DieuHanhTaxi.GetTimeServer();
                g_boolChuyenTabCuocGoiHienTai = false ;
                g_boolChuyenTabCuocGoiKetThuc = false;
                if (rdoTongHop.Checked)
                {
                    gridBaoCaoBieuMau1.Visible = rdoTongHop.Checked;
                    viewer.Visible = rdoTongHop.Checked;
                    viewer2.Visible = rdoTongHop.Checked;

                    gridBaoCaoVung.Visible = !rdoTongHop.Checked;
                    ChartVungKieu1.Visible = !rdoTongHop.Checked;
                    ChartVungKieu2.Visible = !rdoTongHop.Checked;
                }
                this.LoadDulieuBaoCao_BieuMau1();
            }
            else if (e.Page.Name == "uiTabCuocGoiDi")
            {
                
                g_boolChuyenTabCuocGoiHienTai = false ;
                g_boolChuyenTabCuocGoiKetThuc = false;
               
                //--Get du lieu tu phan cung -------------------------------------------
               // LoadDuLieuCuocGoiDiTuPhanCung();
                //-----------------------------------------------------------------------
                LoadCuocGoiDi(DieuHanhTaxi.GetTimeServer(), DieuHanhTaxi.GetTimeServer());
            }
            else if (e.Page.Name == "uiTabKiemTraXe")
            {                
                g_boolChuyenTabCuocGoiHienTai = false ;
                g_boolChuyenTabCuocGoiKetThuc = false;
                this.LoadTabKiemTraXe(); 
            }
        }
        /// <summary>
        /// Nhung cuoc goi moi ve la nhung cuoc goi co TrangThaiLenh = KhongTruyenDi=0
        ///     - Load trong DB xem co cuoc  goi nao moi ve khong
        ///     - Them vao dau tien cua luoi
        /// </summary>
        //private void NhanCacCuocGoiMoiVe()
        //{
        //    try
        //    {
        //        DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
        //        // TrangThaiLenh=0 Cuoc goi moi nhan chi co dien thoai nhin thay
        //        string SQLCondition = "";
        //        SQLCondition += StringTools.GetSQLStringQueryVung(this.g_VungChonKiemSoat, ",");
        //        SQLCondition += " AND (TrangThaiLenh=0)  ORDER BY ThoiDiemGoi DESC";
        //        List<DieuHanhTaxi> lstDienThoaiCuocGoiMoi = new List<DieuHanhTaxi>();
        //        lstDienThoaiCuocGoiMoi = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
        //        if (lstDienThoaiCuocGoiMoi == null) return;
        //        if (lstDienThoaiCuocGoiMoi.Count > 0) // Co cuoc goi moi
        //        {
        //            if (GhepThemCuocGoiMoiNhanVaoDau(lstDienThoaiCuocGoiMoi))
        //            {
        //                gridDienThoai.DataSource = null;
        //                gridDienThoai.DataMember = "ListDienThoai";
        //                gridDienThoai.SetDataBinding(g_lstDienThoai, "ListDienThoai");
        //            }
        //            //  gridDienThoai.Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // TimerCapturePhone.Stop(); 
        //        //  new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

        //    }
        //}

        /// <summary>
        /// Ghep them cac cuoc goi moi nhan vao dau cua danh sach g_listDienTHoai
        /// </summary>
        /// <param name="ListOfNewCalls"></param>
        //private bool GhepThemCuocGoiMoiNhanVaoDau(List<DieuHanhTaxi> ListOfNewCalls)
        //{
        //    bool boolOK = false;
        //    List<DieuHanhTaxi> lstTemp = new List<DieuHanhTaxi>();
        //    for (int i = ListOfNewCalls.Count - 1; i >= 0; i--)
        //    {
        //        if (!KiemTraXemCuocGoiDaDuocThemVaoChua((DieuHanhTaxi)ListOfNewCalls[i]))
        //        {
        //            boolOK = true;
        //            if (g_lstDienThoai == null) g_lstDienThoai = new List<DieuHanhTaxi>();
        //            g_lstDienThoai.Insert(0, (DieuHanhTaxi)ListOfNewCalls[i]);
        //        }
        //    }
        //    return boolOK;

        //}

        //private bool KiemTraXemCuocGoiDaDuocThemVaoChua(DieuHanhTaxi DHTaxi)
        //{
        //    bool boolOK = false;
        //    if (g_lstDienThoai == null) return boolOK;
        //    foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
        //    {
        //        if (objDHTX.ID_DieuHanh == DHTaxi.ID_DieuHanh)
        //        {
        //            boolOK = true;
        //            break;
        //        }
        //    }
        //    return boolOK;
        //}

        /// <summary>
        /// Lay tat cac cac cuoc goi hien dang co trong TatcaCuocGoiHienHanh
        /// Kiem tra cuoc goi phia DienThoai con ton tai trong TatcaCuocGoiHienHanh
        ///     - Neu khong co thi Remove
        ///     - Neu cô thi de lai
        /// </summary>
        //private void XoaCacCuocGoi_TongDaiKetThuc()
        //{
        //    // Lay danh sach cuoc goi hien hanh (phia server)
        //    try
        //    {
        //        List<DieuHanhTaxi> lstDienThoaiServer = new List<DieuHanhTaxi>(); // cuoc dien thoai hien co o server
        //        List<DieuHanhTaxi> lstDienThoaiNoExist = new List<DieuHanhTaxi>(); // cuoc dien thoai hien tai dang co 

        //        DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
        //        string SQLCondition = " ORDER BY ThoiDiemGoi DESC";
        //        lstDienThoaiServer = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
        //        bool boolCocuocGoiKetThuc_TongDai = false;
        //        if (lstDienThoaiServer != null)
        //        {

        //            if (lstDienThoaiServer.Count > 0) // server con cuoc goi
        //            {
        //                foreach (DieuHanhTaxi objDHTX_DienThoai in g_lstDienThoai)
        //                {
        //                    bool boolHas = false;
        //                    foreach (DieuHanhTaxi objDHTX_Server in lstDienThoaiServer)
        //                    {
        //                        if (objDHTX_DienThoai.ID_DieuHanh == objDHTX_Server.ID_DieuHanh)
        //                        {
        //                            boolHas = true;
        //                            break;
        //                        }
        //                    }
        //                    if (!boolHas)
        //                    {
        //                        boolCocuocGoiKetThuc_TongDai = true;
        //                        lstDienThoaiNoExist.Add(objDHTX_DienThoai);
        //                    }
        //                }
        //                foreach (DieuHanhTaxi objDHTX_Delete in lstDienThoaiNoExist)
        //                {
        //                    g_lstDienThoai.Remove(objDHTX_Delete);
        //                }
        //            }
        //            else // khong con cuoc goi nao
        //            {
        //                if (g_lstDienThoai.Count > 0) // phia dien thoai van con cuoc goi
        //                {
        //                    g_lstDienThoai.Clear();
        //                    boolCocuocGoiKetThuc_TongDai = true;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            if (g_lstDienThoai.Count > 0) // phia dien thoai van con cuoc goi
        //            {
        //                g_lstDienThoai.Clear();
        //                boolCocuocGoiKetThuc_TongDai = true;
        //            }
        //        }

        //        if (boolCocuocGoiKetThuc_TongDai)
        //        {
        //            gridDienThoai.DataSource = null;
        //            gridDienThoai.DataMember = "ListDienThoai";
        //            gridDienThoai.SetDataBinding(g_lstDienThoai, "ListDienThoai");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //  TimerCapturePhone.Stop();
        //        //   new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //    }
        //}

        ///// <summary>
        ///// Cap nhat thong tin cuôc gọi bị thay đổi
        /////     - Cập nhật số lần chuông kêu khi nhắc máy, hoặc cuộc gọi nhỡ
        /////     - Cập nhật thông tin cuộc gọi của Tông dài nhập mới        
        ///// </summary>
        //private void CapNhatThongTinCuocGoiBiThayDoi()
        //{
        //    // Nhan thong tin so lan chuong cua cuoc goi nho, va cuoc goi da nhac may
        //    if (GetSoLanChuongCuaCacCuocGoi())
        //    {
        //        gridDienThoai.Refresh();
        //    }

        //    if (CapNhatTHongTinCuocGoiTongDaiGuiSang())
        //    {
        //        gridDienThoai.Refresh();
        //    }
        //}
        ///// <summary>
        ///// Co noi dung cuoc goi thay doi , tu phai tong dai goi sang
        ///// </summary>
        //private bool CapNhatTHongTinCuocGoiTongDaiGuiSang()
        //{
        //    bool boolOK = false;

        //    try
        //    {
        //        DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
        //        // TrangThaiLenh=2 Cuoc goi TongDai gui sang
        //        string SQLCondition = " AND (TrangThaiLenh=2) ORDER BY ThoiDiemGoi DESC";
        //        List<DieuHanhTaxi> lstCuocGoiTongDaiGuiSang = new List<DieuHanhTaxi>();
        //        lstCuocGoiTongDaiGuiSang = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
        //        if (lstCuocGoiTongDaiGuiSang == null) return false;
        //        if (lstCuocGoiTongDaiGuiSang.Count > 0) //Co cuoc goi TongDai gui sang
        //        {
        //            foreach (DieuHanhTaxi objCuocGoiTongDai in lstCuocGoiTongDaiGuiSang)
        //            {
        //                if (g_lstDienThoai.Count > 0)
        //                {
        //                    for (int i = 0; i < g_lstDienThoai.Count; i++)
        //                    {
        //                        if (objCuocGoiTongDai.ID_DieuHanh == ((DieuHanhTaxi)g_lstDienThoai[i]).ID_DieuHanh)
        //                        {
        //                            g_lstDienThoai[i] = (DieuHanhTaxi)objCuocGoiTongDai;
        //                            boolOK = true;// co cuoc goi thay doi
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return boolOK;//
        //    }
        //    catch (Exception ex)
        //    {
        //        //  TimerCapturePhone.Stop();
        //        //  new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

        //        return false;
        //    }
        //    return false;
        //}
        /// <summary>
        /// Voi Cuoc goi nho : TrangThaiCuocGoi=CuocGoiNho=9 AND TrangThaiLenh=KetThucCuaDienThoai=4
        /// Voi cuoc goi co nhac may: TrangThaiCuocGoi= CuocGoiDaNhacMay=7,trangThaiLenh=KhongTruyenDi = 0,
        /// 
        ///     
        /// </summary>
        /// <returns></returns>
        //private bool GetSoLanChuongCuaCacCuocGoi()
        //{
        //    bool boolOK = false;

        //    try
        //    {
        //        DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
        //        // TrangThaiLenh=0 Cuoc goi moi nhan chi co dien thoai nhin thay
        //        string SQLCondition = " AND ((TrangThaiCuocGoi=9 AND TrangThaiLenh=4) OR (TrangThaiCuocGoi=7 AND TrangThaiLenh=0))  ORDER BY ThoiDiemGoi DESC";
        //        List<DieuHanhTaxi> lstCuocGoiCoSolanChuong = new List<DieuHanhTaxi>();
        //        lstCuocGoiCoSolanChuong = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
        //        if (lstCuocGoiCoSolanChuong == null) return false;
        //        if (lstCuocGoiCoSolanChuong.Count > 0) // Co cuoc goi nho, cac cuoc goi da nhac may
        //        {
        //            foreach (DieuHanhTaxi objCuocGoiCoSolanChuong in lstCuocGoiCoSolanChuong)
        //            {
        //                foreach (DieuHanhTaxi objCuocGoiHienTai in g_lstDienThoai)
        //                {
        //                    if (objCuocGoiCoSolanChuong.ID_DieuHanh == objCuocGoiHienTai.ID_DieuHanh)
        //                    {
        //                        objCuocGoiHienTai.SoLuotDoChuong = objCuocGoiCoSolanChuong.SoLuotDoChuong;
        //                        objCuocGoiHienTai.GhiChuDienThoai = objCuocGoiCoSolanChuong.GhiChuDienThoai;
        //                        boolOK = true;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        return boolOK;
        //    }
        //    catch (Exception ex)
        //    {
        //        //  TimerCapturePhone.Stop(); 
        //        //  new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

        //        return false;
        //    }
        //    return false;
        //}
        /// <summary>
        /// kiem tra thoi gian neu duoc 3 phuc thi cho ket thuc
        /// </summary>
        //private void XuLyCuocGoiNho()
        //{
        //    // lay thoi gian cua may chu
        //    DateTime timeServer = DieuHanhTaxi.GetTimeServer();
        //    List<DieuHanhTaxi> lstRemoveCuocGoiNho = new List<DieuHanhTaxi>();
        //    if (g_lstDienThoai == null) return;
        //    foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
        //    {
        //        if (objDHTX.GhiChuDienThoai.Contains("gọi nhỡ"))
        //        {

        //            if ((timeServer.Hour * 60 + timeServer.Minute) - (objDHTX.ThoiDiemGoi.Hour * 60 + objDHTX.ThoiDiemGoi.Minute) >= 3)
        //            {
        //                lstRemoveCuocGoiNho.Add(objDHTX);
        //            }

        //        }
        //    }
        //    if (lstRemoveCuocGoiNho == null) return;
        //    if (lstRemoveCuocGoiNho.Count > 0)
        //    {
        //        foreach (DieuHanhTaxi objDHTX in lstRemoveCuocGoiNho)
        //        {
        //            objDHTX.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.TrangThaiKhac ;
        //            objDHTX.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThucCuaDienThoai;
        //            if (!objDHTX.Update_DienThoai_CuocGoiNho())
        //            {
        //                new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình xử lý cuộc gọi nhỡ", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                return;
        //            }

        //            if (!objDHTX.Update_ChuyenKetThucCuocGoi())
        //            {
        //                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
        //                msgDialog.Show(this, "Có lỗi trong phần lưu vào cơ sở dữ liệu", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                return;
        //            }
        //            g_lstDienThoai.Remove(objDHTX);
        //        }
        //        gridDienThoai.DataSource = null;
        //        gridDienThoai.DataMember = "ListDienThoai";
        //        gridDienThoai.SetDataBinding(g_lstDienThoai, "ListDienThoai");

        //    }
        //}



        #region XU LY CUOC CHUA KET THUC
        /// <summary>
        /// load all cacs cuoc goi chua ket thuc (tat ca khong phai cua minh nua)
        /// danh sách các vùng chọn hiển thị
        /// </summary>       
        //private void LoadAllCuocGoiHienTai(string Vungs)
        //{

        //    DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();

        //    string SQLCondition = "";
        //    SQLCondition += StringTools.GetSQLStringQueryVung(this.g_VungChonKiemSoat, ",");
        //    SQLCondition += " ORDER BY ThoiDiemGoi DESC";
        //    g_lstDienThoai = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
        //    gridDienThoai.DataMember = "ListDienThoai";
        //    gridDienThoai.SetDataBinding(g_lstDienThoai, "ListDienThoai");

        //}

        #endregion XU LY CUOC CHUA KET THUC

        #region XuLyCacCuocGoi ket thuc
        private void LoadCacCuocGoiKetThuc()
        {
            try
            {
                gridCuocGoi_KetThuc.DataSource = null;
                gridCuocGoi_KetThuc.DataMember = "lstCuocGoiKetThuc";
                gridCuocGoi_KetThuc.SetDataBinding(CuocGoi.DIEUHANHCHINH_LayAllCuocGoi_KETTHUC_V3(ThongTinCauHinh.SoDongCuocGoiDaGiaiQuyet), "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                // new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            } 
        }

        /// <summary>
        /// Sap xep cuoc goi ket thuc theo tieu chi
        /// danh sach dua vao da duoc sap xep theo thoi gian
        /// - Nhung cuoc goi chua nhap dia len truoc - Theo thu thu thoi gian 
        /// - Nhung cuoc goi da nhap dien chi  sau  - Theo thu thu thoi gian 
        /// </summary>
        /// <param name="listCuocGoiKT"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> SapXepCuocGoiKetThuc(List<DieuHanhTaxi> listCuocGoiKT)
        {
            // Danh sach cac cuoc chua co dia chi
            List<DieuHanhTaxi> listCuocGoiChuaCoDCDonKhach = new List<DieuHanhTaxi>();
            //danh sach cac cuoc co co dia chi
            List<DieuHanhTaxi> listCuocGoiDaCoDCDonKhach = new List<DieuHanhTaxi>();
            // danh sach cuoc goi trượt, hoãn, không xe, goi lai
            List<DieuHanhTaxi> listCuocGoiTruotHoanKhongXeGoiLai = new List<DieuHanhTaxi>();
            // 
            // Danh sach cuoi cung ghep tu hai danh sach tren
            List<DieuHanhTaxi> listCuocGoiGhep = new List<DieuHanhTaxi>();
            if (listCuocGoiKT == null) return null;
            foreach (DieuHanhTaxi objDHTX in listCuocGoiKT)
            {
                if (CheckHoanKhongXeTruotGoiLai(objDHTX))
                    listCuocGoiTruotHoanKhongXeGoiLai.Add(objDHTX);
                else if (StringTools.TrimSpace(objDHTX.DiaChiTraKhach).Length > 0)
                    listCuocGoiDaCoDCDonKhach.Add(objDHTX);
                else
                    listCuocGoiChuaCoDCDonKhach.Add(objDHTX);
            }
            // Ghep hai 
            if (listCuocGoiChuaCoDCDonKhach != null)
            {
                foreach (DieuHanhTaxi objDHTX in listCuocGoiChuaCoDCDonKhach)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            if (listCuocGoiDaCoDCDonKhach != null)
            {
                foreach (DieuHanhTaxi objDHTX in listCuocGoiDaCoDCDonKhach)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            if (listCuocGoiTruotHoanKhongXeGoiLai != null)
            {
                foreach (DieuHanhTaxi objDHTX in listCuocGoiTruotHoanKhongXeGoiLai)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            return listCuocGoiGhep;
        }
        /// <summary>
        /// kiem tra xem mot cuoc goi la gi 
        /// true : if la không xe, trượt, gọi lại, hoãn
        /// </summary>
        /// <param name="objDHTX"></param>
        /// <returns></returns>
        private bool CheckHoanKhongXeTruotGoiLai(DieuHanhTaxi objDHTX)
        {
            if (objDHTX.LenhTongDai.Contains("không xe")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("trượt")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("gọi lại")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("hoãn")) return true;
            else if (objDHTX.ThongTinKhac) return true;
            else if (objDHTX.GhiChuDienThoai.Contains("gọi nhỡ")) return true;

            return false;

        }
        #endregion XuLyCacCuocGoi ket thuc

        #region CAC THAO TAC GOI TU MENU
        private void mnuDoiTac_Click(object sender, EventArgs e)
        {
            frmDMDoiTac frm = new frmDMDoiTac();
            frm.Show(this);
        }
        private void mnuDMKhachAo_Click(object sender, EventArgs e)
        {
              new frmDMKhachAo().ShowDialog(this);
        }
        private void mnuDMKhachVIP1_Click(object sender, EventArgs e)
        {
            frmDMKhachQuen frm = new frmDMKhachQuen();
            frm.Show(this);
        }

        private void mnuCalculateByKm_Click(object sender, EventArgs e)
        {
            frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
            frm.Show(this); 
        }
        

        private void ngheLạiCuộcGọiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // new frmHearCallAgain().Show(this);
        }

        #endregion CAC THAO TAC GOI TU MENU

        #region Thanh trang thai

        private void BlinkStatus(int iStatus)
        {
            statusBar.Panels[0].ImageIndex = iStatus;
        }
        private void ViewTrangThaiCacCuocGoiO_StatusBar()
        {
            int iSoCuocGoiChuaChuyenSangTongDai = 0;
            int iSoCuocGoiDaCoXeNhan = 0;
            int iSoCuocGoiChuaCoXeNhan = 0;
            if (g_lstDienThoai != null)
            {
                foreach (CuocGoi objDH in g_lstDienThoai)
                {
                    if (objDH.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.KhongTruyenDi)
                        iSoCuocGoiChuaChuyenSangTongDai += 1;
                    if (objDH.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        if (objDH.XeNhan.Length > 0)
                            iSoCuocGoiDaCoXeNhan += 1;
                        else iSoCuocGoiChuaCoXeNhan += 1;
                    }
                }
                this.statusBar.Panels[1].Width = 150;
                this.statusBar.Panels[1].Text = "Tổng cuộc: " + g_lstDienThoai.Count.ToString();
                this.statusBar.Panels[2].Width = 150;
                this.statusBar.Panels[2].Text = "Chưa chuyển đàm : " + iSoCuocGoiChuaChuyenSangTongDai.ToString();
                this.statusBar.Panels[3].Width = 150;
                this.statusBar.Panels[3].Text = "Đã có xe nhận : " + iSoCuocGoiDaCoXeNhan.ToString();
                this.statusBar.Panels[4].Width = 150;
                this.statusBar.Panels[4].Text = "Chưa có xe nhận : " + iSoCuocGoiChuaCoXeNhan.ToString();
            }
            

        }

        #endregion Thanh trang thai

        #region XU LY TRANG THAI MAU (COLOR)

        private void setStyleXeNhan(GridEXRow row, DateTime ThoiDiemGoi, string xeNhanTD, string xeNhan, string xeDeCu, int ColWidth)
        {
            if (string.IsNullOrEmpty(xeNhan))
            {
                TimeSpan timer = g_TimeServer - ThoiDiemGoi;
                if (timer.TotalMinutes > 1 && timer.TotalMinutes < 5)
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.Transparent, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);

                else if (timer.TotalMinutes >= 5 && timer.TotalMinutes <= 30)
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.Orange, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);

                else
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.Transparent, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            }
            else
            {
                row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage(xeNhanTD, xeNhan, xeDeCu, Color.Transparent, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            }
        }

        private void setStyleXeDenDiem(GridEXRow row, string lenhMoiKhach, string xeDenDiem, string xeDenDiemDonKhach, int ColWidth, DateTime thoiDiemGoi)
        {
            TimeSpan timer = g_TimeServer - thoiDiemGoi;
            if (timer.TotalMinutes > 10)
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.LightSteelBlue, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            else if (timer.TotalMinutes >= 5 && timer.TotalMinutes <= 10)
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.MistyRose, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            else
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.Transparent, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
        }


        /// <summary>
        /// - Hien thi anh trang thai tuong ung voi trang thai lenh
        /// - thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
        /// - Thay mau chu cua dia chi cua khach goi lai
        /// - thay doi may cua cuoc goi khong phai cua minh phu trach
        /// </summary>
        private void HienThiAnhTrangThai_MauChu(GridEXRow row)
        {
            try
            {
                CuocGoi objCuocGoi = (CuocGoi)row.DataRow;
                if (objCuocGoi == null)
                    return;

                setStyleXeNhan(row, objCuocGoi.ThoiDiemGoi, objCuocGoi.XeNhan_TD, objCuocGoi.XeNhan, objCuocGoi.DanhSachXeDeCu, row.Cells["XeNhan_CB"].Column.Width);

                setStyleXeDenDiem(row, objCuocGoi.MOIKHACH_LenhMoiKhach, objCuocGoi.XeDenDiem, objCuocGoi.XeDenDiemDonKhach, row.Cells["XeDenDiem_CB"].Column.Width, objCuocGoi.ThoiDiemGoi);

                if ((objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.BoDam))
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.DienThoai;
                else if (objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.DienThoai)
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.BoDam;
                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                    || objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.ForestGreen;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangKhongHieu)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Red;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                if (objCuocGoi.LenhDienThoai.Contains("gọi lại"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    
                    /// Dua ra cannh bao mau theo muc do goi lai
                    int LanGoiLai = GetSoLanGoiLaiCuaCuocGoi(objCuocGoi);
                    if (LanGoiLai <= 1)
                    {
                        RowStyle.ForeColor = Color.Red;
                        row.Cells["DiaChiDon"].FormatStyle = RowStyle;
                    }
                    else if (LanGoiLai == 2)
                    {
                        RowStyle.BackColor  = Color.Gold;
                        row.RowStyle = RowStyle;
                    }
                    else if (LanGoiLai > 2)
                    {
                        RowStyle.BackColor  = Color.Red ;
                        row.RowStyle = RowStyle;
                    }

              
                }
                if (objCuocGoi.GhiChuTongDai.Contains("trượt"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["GhiChu"].FormatStyle = RowStyle;

                }
                
                if (objCuocGoi.ThoiDiemChuyenTongDai  > Configuration.GetDienThoai_ThoiDiemChuyenTongDai ())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["HienThiThoiDiemChuyenTongDai"].FormatStyle = RowStyle;

                }
                if (objCuocGoi.ThoiGianDieuXe > Configuration.GetGioiHanThoiGianDieuXe())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["HienThiThoiGianDieuXe"].FormatStyle = RowStyle;

                }
                if (objCuocGoi.ThoiGianDonKhach > Configuration.GetGioiHanThoiGianDonKhach())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["HienThiThoiGianDonKhach"].FormatStyle = RowStyle;

                }
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
        /// <summary>
        /// hàm lấy ra cuộc gọi lại hiện tại là cuộc thứ mấy
        /// </summary>
        /// <param name="objDieuHanhTaxi"></param>
        /// <returns></returns>
        private int GetSoLanGoiLaiCuaCuocGoi(CuocGoi CuocGoi)
        {
            int LanGoiLai = 0;
             // Loc cac cuoc gọi lại của cuốc
            if (g_lstDienThoai != null && g_lstDienThoai.Count > 0)
            {
                List<CuocGoi> lstCuocGoiLai = new List<CuocGoi>();
                foreach (CuocGoi objDH in g_lstDienThoai)
                {
                    if (objDH.PhoneNumber == CuocGoi.PhoneNumber && objDH.KieuCuocGoi == KieuCuocGoi.GoiLai)
                    {
                        lstCuocGoiLai.Add(objDH);
                    }
                }
                if (lstCuocGoiLai.Count > 1)
                {
                    lstCuocGoiLai.Sort(delegate(CuocGoi cuoc1, CuocGoi cuoc2) { return cuoc1.ThoiDiemGoi.CompareTo(cuoc2.ThoiDiemGoi); });
                    // tim vi tri
                    for (int i = 0; i < lstCuocGoiLai.Count; i++)
                    {
                        if (CuocGoi.IDCuocGoi == lstCuocGoiLai[i].IDCuocGoi)
                        {
                            LanGoiLai = i+1;  // tra lai so lan cua vi tri goi
                            break;
                        }
                    }
                }
                else LanGoiLai = 1;


            }
            return LanGoiLai;
        }

        private void gridDienThoai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }
        private void gridCuocGoi_KetThuc_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }
        #endregion XU LY TRANG THAI MAU (COLOR)

        #region Phân quyền

        private void PhanQuyen()
        {
            
        }
        #endregion
        private void mnuQuanLyNhanVien_Click(object sender, EventArgs e)
        {
           ;
        }

        private void mnuDanhMucXe_Click(object sender, EventArgs e)
        {
            frmDSXe frm = new frmDSXe();
            frm.ShowDialog();
        }


        #region TabBao cao nhanh cuoc goi
        
        private void LoadDulieuBaoCao_BieuMau1()
        {

            DataTable dt = new DataTable();
            dt =  new TimKiem_BaoCao().FillData_BieuMau1_New (string.Format("{0:yyyy-MM-dd}", calNgay.Value));

              LoadChart(dt);
              LoadChartMoiGioiVangLai(dt);

            gridBaoCaoBieuMau1.DataSource = dt;
            uiButton1.Enabled = false;
            uiButton2.Enabled = !uiButton1.Enabled;
            uiButton3.Enabled = !uiButton1.Enabled;
        }

        private void LoadDulieuBaoCao_BieuMau1_ByVung()
        {

            DataTable dt = new DataTable();
            dt =  new TimKiem_BaoCao().FillData_BieuMau1_Vung(string.Format("{0:yyyy-MM-dd}", calNgay.Value));

            LoadChartVungKieu1(dt);
            LoadChartVungKieu2(dt);
             
            gridBaoCaoVung.DataSource = dt;

            uiButton1.Enabled = false;
            uiButton2.Enabled = !uiButton1.Enabled;
            uiButton3.Enabled = !uiButton1.Enabled;
        }
        

        #endregion TabBao cao nhanh cuoc goi

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (rdoTongHop.Checked)
                LoadDulieuBaoCao_BieuMau1();
           // else LoadDulieuBaoCao_BieuMau1_ByVung();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (rdoTongHop.Checked)
            {
                gridEXPrintDocument1.GridEX = gridBaoCaoBieuMau1;
                pageSetupDialog1.Document = gridEXPrintDocument1;
                printPreviewDialog1.Document = gridEXPrintDocument1;
            }
            else
            {
                gridEXPrintDocument1.GridEX = gridBaoCaoVung; ;
                pageSetupDialog1.Document = gridEXPrintDocument1;
                printPreviewDialog1.Document = gridEXPrintDocument1;
            }
            this.pageSetupDialog1.ShowDialog();
            this.printPreviewDialog1.ShowDialog();           
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau1_" + StringTools.GeDayString(calNgay.Value.Day) + "_" + StringTools.GeMonthString(calNgay.Value.Month) + "_" + calNgay.Value.Year.ToString() + ".xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                if (rdoTongHop.Checked)
                    gridEXExporter1.GridEX = gridBaoCaoBieuMau1;

                else
                    gridEXExporter1.GridEX = gridBaoCaoVung ;

                gridEXExporter1.Export((Stream)objFile);

                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");

                objFile.Close();
            }


        }


        #region bieu do
        #region bieu do
        private void LoadChart(DataTable dtCuocGoiTheoCa)
        {


            if (dtCuocGoiTheoCa.Rows.Count > 0)
            {
                double[] arrCuocGoiTaxi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiDonDuocKhach = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiTruotHoan = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiKhongxe = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoCa.Rows.Count];
                string[] lableVertical = new string[dtCuocGoiTheoCa.Rows.Count];
                int MaxCuocGoi = 0;
                int i = 0;
                foreach (DataRow dr in dtCuocGoiTheoCa.Rows)
                {
                    //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
                    arrCuocGoiTaxi[i] = (int)dr["CuocGoiTaxiTong"];
                    arrCuocGoiDonDuocKhach[i] = (int)dr["DonDuocKhachTong"];
                    arrCuocGoiTruotHoan[i] = (int)dr["LyDoTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["LyDoKhongXe"];
                    arrCuocGoiMoiGioi[i] = (int)dr["DonDuocKhachMoiGioi"];
                    arrCuocGoiVangLai[i] = (int)dr["DonDuocKhachVangLai"];
                    lableVertical[i] = "Ca " + dr["Ca"].ToString();
                    i++;
                }

                // Create an XYChart object of size 600 x 300 pixels, with a light blue
                // (EEEEFF) background, black border, 1 pxiel 3D border effect and
                // rounded corners 438, 306
                XYChart c = new XYChart(438, 306, 0xeeeeff, 0x000000, 1);
                c.setRoundedFrame();

                // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
                // background. Turn on both horizontal and vertical grid lines with light
                // grey color (0xcccccc)
                c.setPlotArea(50, 40, 380, 225, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
                //  c.setAntiAlias(); 



                // Add a legend box at (50, 30) (top of the chart) with horizontal
                // layout. Use 9 pts Arial Bold font. Set the background and border color
                // to Transparent.
                c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(Chart.Transparent);

                // Add a title box to the chart using 15 pts Times Bold Italic font, on a
                // light blue (CCCCFF) background with glass effect. white (0xffffff) on
                // a dark red (0x800000) background, with a 1 pixel 3D border.
                c.addTitle("Biểu đồ cuộc gọi taxi theo ca",
                    "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());

                // Add a title to the y axis
                c.yAxis().setTitle("Số cuộc gọi");
                //c.yAxis().setLabels(lableVertical);
                // Set the labels on the x axis.
                c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}", calNgay.Value));
                // c.addStepLineLayer(); 
                c.xAxis().setLabels(lableVertical);


                // c.xAxis()
                // Display 1 out of 3 labels on the x-axis.
                // c.xAxis().setLabelStep(3);

                // Add a title to the x axis
                // c.xAxis().setTitle("Jun 12, 2006");

                // Add a line layer to the chart
                //LineLayer layer = c.addLineLayer2();
                BarLayer layer = c.addBarLayer2(Chart.Stack, 8);
                // Set the default line width to 2 pixels
                //layer.setLineWidth(2);

                // Add the three data sets to the line layer. For demo purpose, we use a
                // dash line color for the last line
                // layer.addDataSet(arrCuocGoiTaxi , 0xff0000, "Gọi taxi");
                layer.addDataSet(arrCuocGoiDonDuocKhach, 0x008800, "Đón được");
                layer.addDataSet(arrCuocGoiTruotHoan, c.dashLineColor(0x3333ff, Chart.DashLine),
                    "Trượt hoãn");
                layer.addDataSet(arrCuocGoiKhongxe, 0xff00ff, "Không xe");
                //layer.addDataSet(arrCuocGoiMoiGioi, 0xaa00ff, "Môi giới");
                // layer.addDataSet(arrCuocGoiVangLai, 0xcc00ff, "Vãng lai");

                // Enable bar label for the whole bar
                layer.setAggregateLabelStyle();

                // Enable bar label for each segment of the stacked bar
                layer.setDataLabelStyle();

                // output the chart
                viewer.Image = c.makeImage();
                viewer.Image.Save(Configuration.GetReportPath() + "\\BieuDo1.jpg");
                //include tool tip for the chart
                viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
            }
        }

        private void LoadChartMoiGioiVangLai(DataTable dtCuocGoiTheoCa)
        {

            if (dtCuocGoiTheoCa.Rows.Count > 0)
            {
                double[] arrCuocGoiTaxi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiDonDuocKhach = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiTruotHoan = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiKhongxe = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoCa.Rows.Count];
                // double[] arrCuocGoiMoiGioiTruotHoanKhongXe = new double[dtCuocGoiTheoCa.Rows.Count];
                // double[] arrCuocGoiVangLaiTruotHoanKhongXe = new double[dtCuocGoiTheoCa.Rows.Count];

                string[] lableVertical = new string[dtCuocGoiTheoCa.Rows.Count];
                int MaxCuocGoi = 0;
                int i = 0;
                foreach (DataRow dr in dtCuocGoiTheoCa.Rows)
                {
                    //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
                    arrCuocGoiTaxi[i] = (int)dr["CuocGoiTaxiTong"];
                    arrCuocGoiDonDuocKhach[i] = (int)dr["DonDuocKhachTong"];
                    arrCuocGoiTruotHoan[i] = (int)dr["LyDoTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["LyDoKhongXe"];
                    arrCuocGoiMoiGioi[i] = (int)dr["DonDuocKhachMoiGioi"];
                    arrCuocGoiVangLai[i] = (int)dr["DonDuocKhachVangLai"];
                    //arrCuocGoiMoiGioiTruotHoanKhongXe[i] = -(int)dr["KhongDonDuocMoiGioi"];
                    // arrCuocGoiVangLaiTruotHoanKhongXe[i] = -(int)dr["KhongDonDuocVangLai"];
                    lableVertical[i] = "Ca " + dr["Ca"].ToString();
                    i++;
                }

                // Create an XYChart object of size 600 x 300 pixels, with a light blue
                // (EEEEFF) background, black border, 1 pxiel 3D border effect and
                // rounded corners 438, 306
                XYChart c = new XYChart(438, 306, 0xeeeeff, 0x000000, 1);
                c.setRoundedFrame();

                // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
                // background. Turn on both horizontal and vertical grid lines with light
                // grey color (0xcccccc)
                c.setPlotArea(50, 40, 380, 225, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
                //  c.setAntiAlias(); 



                // Add a legend box at (50, 30) (top of the chart) with horizontal
                // layout. Use 9 pts Arial Bold font. Set the background and border color
                // to Transparent.
                c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(Chart.Transparent);

                // Add a title box to the chart using 15 pts Times Bold Italic font, on a
                // light blue (CCCCFF) background with glass effect. white (0xffffff) on
                // a dark red (0x800000) background, with a 1 pixel 3D border.
                c.addTitle("Biểu đồ cuộc gọi môi giới/vãng lai theo ca",
                    "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());

                // Add a title to the y axis
                c.yAxis().setTitle("Số cuộc gọi");
                //c.yAxis().setLabels(lableVertical);
                // Set the labels on the x axis.
                c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}", calNgay.Value));
                // c.addStepLineLayer(); 
                c.xAxis().setLabels(lableVertical);


                // c.xAxis()
                // Display 1 out of 3 labels on the x-axis.
                // c.xAxis().setLabelStep(3);

                // Add a title to the x axis
                // c.xAxis().setTitle("Jun 12, 2006");

                // Add a line layer to the chart
                //LineLayer layer = c.addLineLayer2();
                BarLayer layer = c.addBarLayer2(Chart.Stack, 8);
                // Set the default line width to 2 pixels
                //layer.setLineWidth(2);

                // Add the three data sets to the line layer. For demo purpose, we use a
                // dash line color for the last line
                // layer.addDataSet(arrCuocGoiTaxi , 0xff0000, "Gọi taxi");

                layer.addDataSet(arrCuocGoiMoiGioi, 0xffff00, "Môi giới");
                //128, 255, 255
                layer.addDataSet(arrCuocGoiVangLai, 0x00ff7f, "Vãng lai");

                //layer.addDataSet(arrCuocGoiMoiGioiTruotHoanKhongXe, 0x00aa7f, "Trượt,Hoãn,Không xe môi giới");
                //layer.addDataSet(arrCuocGoiVangLaiTruotHoanKhongXe, 0x00dd7f, "Trượt,Hoãn,Không xe vãng lai");
                // Enable bar label for the whole bar
                layer.setAggregateLabelStyle();

                // Enable bar label for each segment of the stacked bar
                layer.setDataLabelStyle();

                // output the chart
                viewer2.Image = c.makeImage();
                viewer2.Image.Save(Configuration.GetReportPath() + "\\BieuDo2.jpg");
                //include tool tip for the chart
                viewer2.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
            }

        }

        #endregion bieudo

        //private void LoadChart(DataTable dtCuocGoiTheoCa)
        //{


        //    if (dtCuocGoiTheoCa.Rows.Count > 0)
        //    {
        //        double[] arrCuocGoiTaxi = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiDonDuocKhach = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiTruotHoan = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiKhongxe = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoCa.Rows.Count];
        //        string[] lableVertical = new string[dtCuocGoiTheoCa.Rows.Count];
        //        int MaxCuocGoi = 0;
        //        int i = 0;
        //        foreach (DataRow dr in dtCuocGoiTheoCa.Rows)
        //        {
        //            //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
        //            arrCuocGoiTaxi[i] = (int)dr["CuocGoiTaxiTong"];
        //            arrCuocGoiDonDuocKhach[i] = (int)dr["CuocGoiDonDuoc"];
        //            arrCuocGoiTruotHoan[i] = (int)dr["CuocGoiTruotHoan"];
        //            arrCuocGoiKhongxe[i] = (int)dr["CuocGoiKhongXe"];
        //            arrCuocGoiMoiGioi[i] = (int)dr["CuocGoiMoiGioi"];
        //            arrCuocGoiVangLai[i] = (int)dr["CuocGoiVangLai"];
        //            lableVertical[i] = "Ca " + dr["Ca"].ToString();                 
        //            i++;
        //        }

        //        // Create an XYChart object of size 600 x 300 pixels, with a light blue
        //        // (EEEEFF) background, black border, 1 pxiel 3D border effect and
        //        // rounded corners 438, 306
        //        XYChart c = new XYChart(438, 306, 0xeeeeff, 0x000000, 1);
        //        c.setRoundedFrame();

        //        // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
        //        // background. Turn on both horizontal and vertical grid lines with light
        //        // grey color (0xcccccc)
        //        c.setPlotArea(50, 40, 380, 225, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
        //        //  c.setAntiAlias(); 



        //        // Add a legend box at (50, 30) (top of the chart) with horizontal
        //        // layout. Use 9 pts Arial Bold font. Set the background and border color
        //        // to Transparent.
        //        c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(Chart.Transparent);

        //        // Add a title box to the chart using 15 pts Times Bold Italic font, on a
        //        // light blue (CCCCFF) background with glass effect. white (0xffffff) on
        //        // a dark red (0x800000) background, with a 1 pixel 3D border.
        //        c.addTitle("Biểu đồ cuộc gọi taxi theo ca",
        //            "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
        //            Chart.glassEffect());

        //        // Add a title to the y axis
        //        c.yAxis().setTitle("Số cuộc gọi");
        //        //c.yAxis().setLabels(lableVertical);
        //        // Set the labels on the x axis.
        //        c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}",calNgay.Value ));
        //        // c.addStepLineLayer(); 
        //        c.xAxis().setLabels(lableVertical);


        //        // c.xAxis()
        //        // Display 1 out of 3 labels on the x-axis.
        //        // c.xAxis().setLabelStep(3);

        //        // Add a title to the x axis
        //        // c.xAxis().setTitle("Jun 12, 2006");

        //        // Add a line layer to the chart
        //        //LineLayer layer = c.addLineLayer2();
        //        BarLayer layer = c.addBarLayer2(Chart.Stack, 8);
        //        // Set the default line width to 2 pixels
        //        //layer.setLineWidth(2);

        //        // Add the three data sets to the line layer. For demo purpose, we use a
        //        // dash line color for the last line
        //        // layer.addDataSet(arrCuocGoiTaxi , 0xff0000, "Gọi taxi");
        //        layer.addDataSet(arrCuocGoiDonDuocKhach, 0x008800, "Đón được");
        //        layer.addDataSet(arrCuocGoiTruotHoan, c.dashLineColor(0x3333ff, Chart.DashLine),
        //            "Trượt hoãn");
        //        layer.addDataSet(arrCuocGoiKhongxe, 0xff00ff, "Không xe");
        //        //layer.addDataSet(arrCuocGoiMoiGioi, 0xaa00ff, "Môi giới");
        //        // layer.addDataSet(arrCuocGoiVangLai, 0xcc00ff, "Vãng lai");

        //        // Enable bar label for the whole bar
        //        layer.setAggregateLabelStyle();

        //        // Enable bar label for each segment of the stacked bar
        //        layer.setDataLabelStyle();

        //        // output the chart
        //        viewer.Image = c.makeImage();

        //        //include tool tip for the chart
        //        viewer.ImageMap = c.getHTMLImageMap("clickable", "",
        //            "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
        //    }
        //}

        //private void LoadChartMoiGioiVangLai(DataTable dtCuocGoiTheoCa)
        //{

        //    if (dtCuocGoiTheoCa.Rows.Count > 0)
        //    {
        //        double[] arrCuocGoiTaxi = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiDonDuocKhach = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiTruotHoan = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiKhongxe = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoCa.Rows.Count];
        //        double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoCa.Rows.Count];
        //        string[] lableVertical = new string[dtCuocGoiTheoCa.Rows.Count];
        //        int MaxCuocGoi = 0;
        //        int i = 0;
        //        foreach (DataRow dr in dtCuocGoiTheoCa.Rows)
        //        {
        //            //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
        //            arrCuocGoiTaxi[i] = (int)dr["TongCuocGoiTaxi"];
        //            arrCuocGoiDonDuocKhach[i] = (int)dr["CuocGoiDonDuoc"];
        //            arrCuocGoiTruotHoan[i] = (int)dr["CuocGoiTruotHoan"];
        //            arrCuocGoiKhongxe[i] = (int)dr["CuocGoiKhongXe"];
        //            arrCuocGoiMoiGioi[i] = (int)dr["CuocGoiMoiGioi"];
        //            arrCuocGoiVangLai[i] = (int)dr["CuocGoiVangLai"];
        //            lableVertical[i] = "Ca " + dr["Ca"].ToString();
        //            i++;
        //        }

        //        // Create an XYChart object of size 600 x 300 pixels, with a light blue
        //        // (EEEEFF) background, black border, 1 pxiel 3D border effect and
        //        // rounded corners 438, 306
        //        XYChart c = new XYChart(438, 306, 0xeeeeff, 0x000000, 1);
        //        c.setRoundedFrame();

        //        // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
        //        // background. Turn on both horizontal and vertical grid lines with light
        //        // grey color (0xcccccc)
        //        c.setPlotArea(50, 40, 380, 225, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
        //        //  c.setAntiAlias(); 



        //        // Add a legend box at (50, 30) (top of the chart) with horizontal
        //        // layout. Use 9 pts Arial Bold font. Set the background and border color
        //        // to Transparent.
        //        c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(Chart.Transparent);

        //        // Add a title box to the chart using 15 pts Times Bold Italic font, on a
        //        // light blue (CCCCFF) background with glass effect. white (0xffffff) on
        //        // a dark red (0x800000) background, with a 1 pixel 3D border.
        //        c.addTitle("Biểu đồ cuộc gọi môi giới/vãng lai theo ca",
        //            "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
        //            Chart.glassEffect());

        //        // Add a title to the y axis
        //        c.yAxis().setTitle("Số cuộc gọi");
        //        //c.yAxis().setLabels(lableVertical);
        //        // Set the labels on the x axis.
        //        c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}", calNgay.Value));
        //        // c.addStepLineLayer(); 
        //        c.xAxis().setLabels(lableVertical);


        //        // c.xAxis()
        //        // Display 1 out of 3 labels on the x-axis.
        //        // c.xAxis().setLabelStep(3);

        //        // Add a title to the x axis
        //        // c.xAxis().setTitle("Jun 12, 2006");

        //        // Add a line layer to the chart
        //        //LineLayer layer = c.addLineLayer2();
        //        BarLayer layer = c.addBarLayer2(Chart.Stack, 8);
        //        // Set the default line width to 2 pixels
        //        //layer.setLineWidth(2);

        //        // Add the three data sets to the line layer. For demo purpose, we use a
        //        // dash line color for the last line
        //        // layer.addDataSet(arrCuocGoiTaxi , 0xff0000, "Gọi taxi");

        //        layer.addDataSet(arrCuocGoiMoiGioi, 0xffff00, "Môi giới");
        //        //128, 255, 255
        //        layer.addDataSet(arrCuocGoiVangLai, 0x00ff7f, "Vãng lai");
        //        // Enable bar label for the whole bar
        //        layer.setAggregateLabelStyle();

        //        // Enable bar label for each segment of the stacked bar
        //        layer.setDataLabelStyle();

        //        // output the chart
        //        viewer2.Image = c.makeImage();

        //        //include tool tip for the chart
        //        viewer2.ImageMap = c.getHTMLImageMap("clickable", "",
        //            "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
        //    }

        //}


        // Chart VungKieu1 - Kieu cot ĐÓN ĐƯỢC - TRƯỢT HOÃN - KHÔNG XE
        /// <summary>
        ///   - 3 cột thể hiện cho 3 vùng
        ///   - Dung bieu do Overlapping Bar
        /// Ca,ThoiGian,VUNG1_TongCuocGoiTaxi, VUNG1_CuocGoiDonDuoc, VUNG1_CuocGoiTruotHoan,VUNG1_CuocGoiKhongXe,VUNG1_PhanTramDonDuoc,
         // VUNG2_TongCuocGoiTaxi, 
         // VUNG2_CuocGoiDonDuoc,
         // VUNG2_CuocGoiTruotHoan,
         // VUNG2_CuocGoiKhongXe, 
         // VUNG2_PhanTramDonDuoc ,
         //   VUNG3_TongCuocGoiTaxi,
         //   VUNG3_CuocGoiDonDuoc,
         //   VUNG3_CuocGoiTruotHoan,
         //   VUNG3_CuocGoiKhongXe,
         //   VUNG3_PhanTramDonDuoc 
        /// </summary>
        /// <param name="dtCuocGoiTheoVung"></param>
        private void LoadChartVungKieu1(DataTable dtCuocGoiTheoVung)
        {
            if (dtCuocGoiTheoVung.Rows.Count > 0)
            {
                // 9 : so lương lable Ca1-Vùng1, Ca1-Vùng2,..., Ca3-Vung3
                double[] arrCuocGoiDonDuocKhach = new double[9];
                double[] arrCuocGoiTruotHoan = new double[9];
                double[] arrCuocGoiKhongxe = new double[9];              
                
                string[] lableVertical = new string[9];

                int MaxCuocGoi = 0;
                int i = 0;
                foreach (DataRow dr in dtCuocGoiTheoVung.Rows)
                {
                    // ca1-Vùnd1
                    arrCuocGoiDonDuocKhach[i] = (int)dr["VUNG1_CuocGoiDonDuoc"];
                    arrCuocGoiTruotHoan[i] = (int)dr["VUNG1_CuocGoiTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["VUNG1_CuocGoiKhongXe"];
                    lableVertical[i] = "C" + dr["Ca"].ToString() + "V1";
                    i++;
                    //ca1-vung2
                    arrCuocGoiDonDuocKhach[i] = (int)dr["VUNG2_TongCuocGoiTaxi"];
                    arrCuocGoiTruotHoan[i] = (int)dr["VUNG2_CuocGoiTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["VUNG2_CuocGoiKhongXe"];
                    lableVertical[i] = "C" + dr["Ca"].ToString() + "V2";
                    i++;
                    //ca1-vung3
                    arrCuocGoiDonDuocKhach[i] = (int)dr["VUNG3_CuocGoiDonDuoc"];
                    arrCuocGoiTruotHoan[i] = (int)dr["VUNG3_CuocGoiTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["VUNG3_CuocGoiKhongXe"];
                    lableVertical[i] = "C" + dr["Ca"].ToString() + "V3";
                }

                // Create an XYChart object of size 600 x 300 pixels, with a light blue
                // (EEEEFF) background, black border, 1 pxiel 3D border effect and
                // rounded corners 438, 306
                XYChart c = new XYChart(438, 306, 0xeeeeff, 0x000000, 1);
                c.setRoundedFrame();

                // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
                // background. Turn on both horizontal and vertical grid lines with light
                // grey color (0xcccccc)
                c.setPlotArea(50, 40, 380, 225, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
                //  c.setAntiAlias(); 


                // Add a legend box at (50, 30) (top of the chart) with horizontal
                // layout. Use 9 pts Arial Bold font. Set the background and border color
                // to Transparent.
                c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(Chart.Transparent);

                // Add a title box to the chart using 15 pts Times Bold Italic font, on a
                // light blue (CCCCFF) background with glass effect. white (0xffffff) on
                // a dark red (0x800000) background, with a 1 pixel 3D border.
                c.addTitle("Biểu đồ cuộc gọi taxi theo ca-vùng",
                    "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());                 

                // Set the plot area at (50, 50) and of size 500 x 200. Use two
                // alternative background colors (f8f8f8 and ffffff)
                c.setPlotArea(50, 50, 500, 200, 0xf8f8f8, 0xffffff);

                // Add a legend box at (50, 25) using horizontal layout. Use 8pts Arial
                // as font, with transparent background.
                c.addLegend(50, 25, false, "Arial", 8).setBackground(Chart.Transparent);

                // Set the x axis labels
                c.xAxis().setLabels(lableVertical);

                // Draw the ticks between label positions (instead of at label positions)
                c.xAxis().setTickOffset(0.5);

                // Add a multi-bar layer with 3 data sets
                BarLayer layer = c.addBarLayer2(Chart.Side);
                layer.addDataSet(arrCuocGoiKhongxe, 0xff8080, "Không xe");
                layer.addDataSet(arrCuocGoiTruotHoan, 0x80ff80, "Trượt hoãn");
                layer.addDataSet(arrCuocGoiDonDuocKhach, 0x8080ff, "Đón được");

                // Set 50% overlap between bars
                layer.setOverlapRatio(0.5);

                // Add a title to the y-axis
                c.yAxis().setTitle(" Số cuộc gọi taxi");
                 
                // output the chart

                ChartVungKieu1.Image = c.makeImage();

                //include tool tip for the chart
                ChartVungKieu1.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
            }
        }

        private void LoadChartVungKieu2(DataTable dtCuocGoiTheoVung)
        {
            if (dtCuocGoiTheoVung.Rows.Count > 0)
            {
              
                double  arrTongCuocGoiTaxiVung1 = 0;
                double  arrTongCuocGoiTaxiVung2 = 0;
                double  arrTongCuocGoiTaxiVung3 = 0;

                string[] lableVertical = new string[3];

                 
                foreach (DataRow dr in dtCuocGoiTheoVung.Rows)
                {
                    arrTongCuocGoiTaxiVung1 += (int)dr["VUNG1_TongCuocGoiTaxi"];
                    arrTongCuocGoiTaxiVung2 += (int)dr["VUNG2_TongCuocGoiTaxi"];
                    arrTongCuocGoiTaxiVung3 += (int)dr["VUNG3_TongCuocGoiTaxi"];
                
                }

               

                double[] data = new double[3];
                
                data[0] = arrTongCuocGoiTaxiVung1;
                data[1] = arrTongCuocGoiTaxiVung2;
                data[2] = arrTongCuocGoiTaxiVung3;

                lableVertical[0] = "Vùng 1";
                lableVertical[1] = "Vùng 2";
                lableVertical[2] = "Vùng 3";

                // Create a PieChart object of size 360 x 300 pixels
                PieChart c = new PieChart(360, 300, 0xeeeeff, 0x000000, 1);


                // Set the center of the pie at (180, 140) and the radius to 100 pixels
                c.setPieSize(180, 140, 100);

                // Add a title to the pie chart
                
                c.addTitle("Cuộc gọi taxi",
                    "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());    
                
                // Draw the pie in 3D
                c.set3D();

                // Set the pie data and the pie labels
                c.setData(data, lableVertical);

                // Explode the 1st sector (index = 0)
                c.setExplode(0);


                if ((arrTongCuocGoiTaxiVung1 == 0) && (arrTongCuocGoiTaxiVung2 == 0) && (arrTongCuocGoiTaxiVung3 == 0))
                {
                    return;
                }

                ChartVungKieu2.Image = c.makeImage();

                //include tool tip for the chart
                ChartVungKieu2.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
            }
        }

        #endregion bieudo

        private void calNgay_ValueChanged(object sender, EventArgs e)
        {
            uiButton1.Enabled = true;
            uiButton2.Enabled = !uiButton1.Enabled;
            uiButton3.Enabled = !uiButton1.Enabled;
        }

        private void EF02_mniAbout_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        
#region Tab Kiem soat xe
        
        private void LoadTabKiemTraXe()
        {
            this.GetKiemSoatXe();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GetKiemSoatXe();
        }
        private void GetKiemSoatXe()
        {
            List<KiemSoatXeLienLac> listOfXe = new List<KiemSoatXeLienLac>();
            List<KiemSoatXeLienLac> listOfXeCapNhatTrangThai = new List<KiemSoatXeLienLac>();
            listOfXe = KiemSoatXeLienLac.GetTrangThaiAllXe_KSLL();
            DateTime timeCurrentServer = DieuHanhTaxi.GetTimeServer();
            if ((listOfXe != null) && (listOfXe.Count > 0))
            {
                foreach (KiemSoatXeLienLac objKSLLXe in listOfXe)
                {
                    listOfXeCapNhatTrangThai.Add(KiemSoatXeLienLac.CapNhatTrangThaiXe(objKSLLXe, timeCurrentServer));
                }
            }

            if ((listOfXeCapNhatTrangThai != null) && (listOfXeCapNhatTrangThai.Count > 0))
            {
                danhsachXeMatLienLac.ViewListXe(KieuMatLienLac.XeMatLienLac, listOfXeCapNhatTrangThai);
                danhsachXeXinNghi.ViewListXe(KieuMatLienLac.XeXinNghi, listOfXeCapNhatTrangThai);
                danhsachXeDiSanBay.ViewListXe(KieuMatLienLac.XeDiSanBay, listOfXeCapNhatTrangThai);
                danhsachXeDiDuongDai.ViewListXe(KieuMatLienLac.XeDiDuongDai, listOfXeCapNhatTrangThai);
            }
        }
        // Ban cu 
        //  
        // private void GetKiemSoatXe()
        //{
        //    List<KiemSoatXeLienLac> listOfXe = new List<KiemSoatXeLienLac>();
        //    KiemSoatXeLienLac objKSLLXe = new KiemSoatXeLienLac ();
        //    listOfXe = objKSLLXe.GetKSLLDanhSachXeDangHoatDong();

        //    danhsachXeMatLienLac.ViewListXe(KieuMatLienLac.XeMatLienLac, listOfXe);
        //    danhsachXeXinNghi.ViewListXe(KieuMatLienLac.XeXinNghi, listOfXe);
        //    danhsachXeDiSanBay.ViewListXe(KieuMatLienLac.XeDiSanBay, listOfXe);
        //    danhsachXeDiDuongDai.ViewListXe(KieuMatLienLac.XeDiDuongDai, listOfXe); 
        //}
        private void btnBaoCaoXeHoatDong_Click(object sender, EventArgs e)
        {
            frmBaoCaoTrangThaiXe frm = new frmBaoCaoTrangThaiXe();
            frm.ShowDialog();
        }

        private void btnKiemTraTrangThaiXe_Click(object sender, EventArgs e)
        {
            if (editSoHieuXe.Text.Length <= 0)
            {
                lblTrangThaiXe.Text = "";
            }

            if (!Xe.KiemTraTonTaiCuaSoHieuXe(editSoHieuXe.Text))
            {
                lblTrangThaiXe.Text = "Số hiệu xe này không tồn tại";
                return;
            }
            if (StringTools.TrimSpace(editSoHieuXe.Text).Length < 3)
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập đúng số hiệu xe", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            else
            {
                if (!KiemSoatXeLienLac.CheckXeDangHoatDong(editSoHieuXe.Text))
                {
                    lblTrangThaiXe.Text = "Xe không hoạt động.";

                }
                else
                {
                    string strStatus = string.Empty;
                    KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
                    objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(StringTools.TrimSpace(editSoHieuXe.Text));
                    objKSXe = KiemSoatXeLienLac.CapNhatTrangThaiXe(objKSXe);
                    if (!(objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi)) // kong phai nghi 
                    {
                        if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
                        {
                            strStatus = "Xe HĐ: [" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + "][" + objKSXe.ViTri + "]";

                        }
                        else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay)
                        {
                            strStatus = "Xe HĐ:  [" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + "][" + objKSXe.ViTri  + "]";

                        }
                        else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachNoiTinh)
                        {
                            strStatus = "Xe HĐ: [" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + "][" + objKSXe.ViTri  + "]";

                        }
                        if (objKSXe.IsMatLienLac) strStatus += " [Xe mất LL]";
                    }
                    else
                    {
                        strStatus = "Xe nghỉ:[" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + "][" + objKSXe.ViTri + "]";
                    }

                    lblTrangThaiXe.Text = strStatus;
                }
            }
        }

        private void editSoHieuXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (editSoHieuXe.Text.Length <= 0)
                {
                    lblTrangThaiXe.Text = "";
                }

                if (!Xe.KiemTraTonTaiCuaSoHieuXe(editSoHieuXe.Text))
                {
                    lblTrangThaiXe.Text = "Số hiệu xe này không tồn tại";
                    return;
                }
                if (StringTools.TrimSpace(editSoHieuXe.Text).Length < 3)
                {
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                    msgDialog.Show(this, "Bạn phải nhập đúng số hiệu xe", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
                else
                {
                    if (!KiemSoatXeLienLac.CheckXeDangHoatDong(editSoHieuXe.Text))
                    {
                        lblTrangThaiXe.Text = "Xe không hoạt động.";

                    }
                    else
                    {
                        string strStatus = string.Empty;
                        KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
                        objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(StringTools.TrimSpace(editSoHieuXe.Text));
                        objKSXe = KiemSoatXeLienLac.CapNhatTrangThaiXe(objKSXe);
                        if (!(objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi)) // kong phai nghi 
                        {
                            if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
                            {
                                strStatus = "Xe HĐ: [" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + "][" + objKSXe.ViTri + "]"  ;

                            }
                            else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay)
                            {
                                strStatus = "Xe HĐ:  [" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao ) + "][" + objKSXe.ViTri  + "]";

                            }
                            else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachNoiTinh)
                            {
                                strStatus = "Xe HĐ: [" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + "][" + objKSXe.ViTriDiemBao + "]";

                            }
                            if (objKSXe.IsMatLienLac) strStatus += " [Xe mất LL]";
                        }
                        else
                        {
                            strStatus = "Xe nghỉ:[" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + "][" + objKSXe.ViTriDiemBao + "]";
                        }

                        lblTrangThaiXe.Text = strStatus;
                    }
                }
            }
        }
#endregion Tab Kiem soat xe

        #region Cap nhat du lieu cuoc goi di tu phan cung
              
        private void LoadDuLieuCuocGoiDiTuPhanCung()
        {
            // Create a background thread
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            // Create a progress form on the UI thread
            m_fmProgress = new fmProgress();

            // Kick off the Async thread
            bw.RunWorkerAsync();

            // Lock up the UI with this modal progress form.
            try
            {
                m_fmProgress.ShowDialog(this);
                m_fmProgress = null;
            }
            catch (Exception ex)
            {

            }
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {             
            m_fmProgress.lblDescription.Invoke(
               (MethodInvoker)delegate()
               {
                   m_fmProgress.lblDescription.Text = "Loading ... cuộc gọi đi";
                   m_fmProgress.progressBar1.Value = 50;
               }
           );
            //CaptureCuocGoiDi();
            if (m_fmProgress.Cancel)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was canceled.
                e.Cancel = true;
                return;
            }
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. First we should hide the
            // modal Progress Form to unlock the UI. The we need to inspect our
            // response to see if an error occured, a cancel was requested or
            // if we completed succesfully.

            // Hide the Progress Form
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
            }

            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                // MessageBox.Show("Processing cancelled.");
                return;
            }
        }

        /// <summary>
        /// nhan thong tin cac cuoc goi di va cap nhat vao DB
        /// </summary>
        private void CaptureCuocGoiDi()
        {
            try
            {
                // lay du lieu
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                string VOCFileName = ProcessVocFile.GetVOCFileFullPath(timeServer);
                DataTable dt = new DataTable();
                dt = ProcessVocFile.GetEarlyPhoneDialOut(VOCFileName);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CuocGoiDi objGoiDi = new CuocGoiDi(dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString());
                        if (!objGoiDi.Insert())
                        {
                            //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", new Exception("[ Cuoc goi di ]"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", ex);
            }
        }

        #endregion 

       
         
         private void LoadCuocGoiDi(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable g_dt = new DataTable();
            g_dt = CuocGoiDi.GetDSCuocGoiDi(TuNgay, DenNgay);
           // gridCuocGoiDi.DataSource = g_dt;
            
        }


        private void btnLamMoiCuocGoiDi_Click(object sender, EventArgs e)
        {   
            DateTime currentDate = DieuHanhTaxi.GetTimeServer ();
            DateTime DenNgay = new DateTime(currentDate.Year,currentDate.Month,currentDate.Day,23,59,59);
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, DenNgay))
            {
                LoadCuocGoiDi(calTuNgay.Value, DenNgay);
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }



//        private void btnPlay_Click(object sender, EventArgs e)
//        {

//            string filenameVoice = "";
//            gridCuocGoiDi.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

//            if (gridCuocGoiDi.SelectedItems.Count > 0)
//            {  
//                // [Line]
//                //,[PhoneNumber]
//                // ,[ThoiDiemGoi]
//                GridEXRow dr = gridCuocGoiDi.SelectedItems[0].GetRow();
//                string Line = dr.Cells["Line"].Text;
//                DateTime  ThoiDiemGoiDi = Convert.ToDateTime( dr.Cells["ThoiDiemGoi"].Text);
//                string PhoneNumber = dr.Cells["PhoneNumber"].Text;
//                filenameVoice = NgheLaiCuocGoi.GetFileVoiceCuaMotCuocGoi(Line, PhoneNumber, ThoiDiemGoiDi, Taxi.Utils.TypeCall.DialOut,
//ThongTinCauHinh.ThuMucFileAmThanh);
//            } else return; 

//            if (filenameVoice.Length > 0)
//            {
//                player1.FileName = filenameVoice;
//                if (player1.FileName != "")
//                {
//                    player1.Play();
//                    btnPause.Text = "Pause";
//                    this.timer1.Enabled = true;
//                }
//                else
//                {
//                    new MessageBox.MessageBox().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.Thư mục này phải được lưu cùng với thư mục của hệ thống bắt số.Ví dụ : \\maychu\GhiAm");
//                }
//            }
//            else
//            {
//                new MessageBox.MessageBox().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.Thư mục này phải được lưu cùng với thư mục của hệ thống bắt số.Ví dụ : \\maychu\GhiAm");
//            }
//        }

//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            btnPause.Enabled = player1.Status != "stopped";
//            btnStop.Enabled = player1.Status != "stopped";
//            int pos = (player1.PositionInMS * this.tbPosition.Maximum) / player1.DurationInMS;
//            this.tbPosition.Value = pos;
//        }

//        private void btnPause_Click(object sender, EventArgs e)
//        {
//            if (player1.Status == "paused")
//            {
//                player1.Resume();
//                btnPause.Text = "Pause";
//            }
//            else
//            {
//                player1.Pause();
//                btnPause.Text = "Resume";
//            }
//        }

//        private void btnStop_Click(object sender, EventArgs e)
//        {

//            player1.Stop();
//            this.timer1.Enabled = false;
//        }

        private void mnuSuaDoiBangGia_Click(object sender, EventArgs e)
        {
           new frmCapNhatBangGia_New().Show();
        }

        private void mnuDanhBaCongTy_Click(object sender, EventArgs e)
        {
            new frmDMDanhBaCongTy().ShowDialog();
        }

        
        private void mnuQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            HeThong_NguoiDung_QuanLy frm = new HeThong_NguoiDung_QuanLy(this);
            frm.ShowDialog();
        }

        private void mnuPhong1_Click(object sender, EventArgs e)
        {
            DMPhong_QuanLy frm = new DMPhong_QuanLy();
            frm.ShowDialog();
        }

        private void mnuChucVu1_Click(object sender, EventArgs e)
        {
            new DMChucVu_QuanLy().ShowDialog();
        }

        private void EF02_mniExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuQuanLyVaiTro_Click(object sender, EventArgs e)
        {
            new HeThong_VaiTro_QuanLy(this).ShowDialog();
        }

        private void EF02_mniUserManagement_Click(object sender, EventArgs e)
        {
            new CapNhatThongTinCaNhan().ShowDialog();
        }

        private void EF02_mniLogin_Click(object sender, EventArgs e)
        {
            if (strUser_Id.Length > 0)
            {
                Application.Restart();
            }
            else
            {
                // Nếu trong CSDL có rồi thì chỉ xuất ra form Đăng nhập 
                CheckIn_CheckOut frmDangNhap = new CheckIn_CheckOut();
                DialogResult dlgResult = frmDangNhap.ShowDialog();
                strUser_Id = ThongTinDangNhap.USER_ID;
            }

        }

        private void mnuDanhMucLaiXe_Click(object sender, EventArgs e)
        {
             frmDSNhanVien frm = new frmDSNhanVien();
             frm.ShowDialog();
        }

        private void mnuDanhMucNhanVien_Click(object sender, EventArgs e)
        {
            new HeThong_NguoiDung_QuanLy(this).ShowDialog(); 
        }

        private void mnuLoaiDiaDanh_Click(object sender, EventArgs e)
        {
            new DMLoaiDiaDanh().ShowDialog();
        }

        private void mnuDMDiaDanh_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.frmDMDiaDanh().ShowDialog();
        }

        private void btnXeBaoHoatDong_Click(object sender, EventArgs e)
        {
            new frmNhapThongTinKiemSoatXe(1).ShowDialog();
            this.GetKiemSoatXe();
        }

        private void btnXeBaoDiem_Click(object sender, EventArgs e)
        {
            new frmNhapThongTinKiemSoatXe(2).ShowDialog(); this.GetKiemSoatXe();
        }

        private void btnXeBaoVe_Click(object sender, EventArgs e)
        {
            new frmNhapThongTinKiemSoatXe(4).ShowDialog(); this.GetKiemSoatXe();
        }

        private void EF02_mniConfiguaration_Click(object sender, EventArgs e)
        {
            new frmThietLapCauHinhHeThong().ShowDialog();
        }

        private void baoCaoKetQuaNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBaoCaoBieuMau16_GopChung().ShowDialog();
        }

        private void mnuBaoCao17_NhanVienThiTruong_Click(object sender, EventArgs e)
        {
            new frmBaoCaoBieuMau17().ShowDialog();
        }

        private void gridDienThoai_ColumnHeaderClick(object sender, ColumnActionEventArgs e)
        {
             
        }
        /// <summary>
        /// xu ly menu click chuot phai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRigthClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdRefresh")
            {
                //load moi lai du lieu chua grid
                LoadAllCuocGoiHienTai(this.g_VungChonKiemSoat );
                ViewTrangThaiCacCuocGoiO_StatusBar();
                HienThiTrenLuoi(true, true);

            }
            else if (e.Command.Key == "cmdXoaCuocGoi")
            {
                //load moi lai du lieu chua grid
                XoaCuocGoiDangChoGiaiQuyet(); 
            }
            else if (e.Command.Key == "cmdVung")
            {
                // Goi form chon vùng 
                frmChonVung frmChonVung = new frmChonVung(this.g_VungChonKiemSoat);
                if (frmChonVung.ShowDialog() == DialogResult.OK)
                {
                    this.g_VungChonKiemSoat = frmChonVung.GetVungChon();
                    this.LoadAllCuocGoiHienTai(this.g_VungChonKiemSoat);
                    HienThiTrenLuoi(true, true);
                }
            }
        }
        /// <summary>
        /// xóa cuộc gọi đạng chờ giải quyết quá thời gian
        /// </summary>
        private void XoaCuocGoiDangChoGiaiQuyet()
        {
             gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
             if (gridDienThoai.SelectedItems.Count > 0)
             {
                 DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)gridDienThoai.SelectedItems[0].GetRow().DataRow; 
                 /// Neu la cuoc goi nho thi thoat luon
                 if (objDieuHanhTaxi != null)
                 {
                     MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                     if (msgDialog.Show(this, "Bạn có đồng ý xóa cuộc gọi này không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                     {
                         if (objDieuHanhTaxi.DeleteCuocGoiChoGiaiQuyet())
                         {
                             msgDialog.Show(this, "Xóa dữ liệu thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                             LoadAllCuocGoiHienTai(this.g_VungChonKiemSoat);
                         }
                         else msgDialog.Show(this, "Có lỗi khi xóa dữ liệu.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK , Taxi.MessageBox.MessageBoxIconBA.Information);

                     }

                 }
             }
        }


        private void mnuQuanLyVe_Click(object sender, EventArgs e)
        {

        }
        private void mnuNhapVePhatHanh_Click(object sender, EventArgs e)
        {
            new frmVePhatHanh().ShowDialog();
        }
        private void mnuNhapVeSuDung_Click(object sender, EventArgs e)
        {
            new frmVeSuDung().ShowDialog();
        }
        private void mnuDMKhachHang_Click(object sender, EventArgs e)
        {
            new frmDMKhachHang().ShowDialog();
        }

        private void mnuNhapVeHuy_Click(object sender, EventArgs e)
        {
            new frmVeHuy().ShowDialog();
        }

        private void mnuTraCuuVe_Click(object sender, EventArgs e)
        {
            new frmTraCuu().ShowDialog();
        }

        private void mnuBCVeTheoHopDong_Click(object sender, EventArgs e)
        {
            new frmBCVeTheoHopDong().ShowDialog();
        }

        private void mnuBCVeTheoNgay_Click(object sender, EventArgs e)
        {
            new frmBCVeTheoNgaySuDung().ShowDialog();  
        }

        private void rdoTongHop_CheckedChanged(object sender, EventArgs e)
        {
            uiButton1.Enabled = true;
            uiButton2.Enabled = false ;
            uiButton3.Enabled = false ;

            if (rdoTongHop.Checked)
            {
                gridBaoCaoBieuMau1.Visible = rdoTongHop.Checked;
                viewer.Visible = rdoTongHop.Checked;
                viewer2.Visible = rdoTongHop.Checked;

                gridBaoCaoVung.Visible = !rdoTongHop.Checked;
                ChartVungKieu1.Visible = !rdoTongHop.Checked;
                ChartVungKieu2.Visible = !rdoTongHop.Checked;
            }
        }

        private void rdoVung_CheckedChanged(object sender, EventArgs e)
        {
            uiButton1.Enabled = true;
            uiButton2.Enabled = false;
            uiButton3.Enabled = false;
            if (rdoVung.Checked)
            {
                gridBaoCaoBieuMau1.Visible = !rdoVung.Checked;
                viewer.Visible = !rdoVung.Checked;
                viewer2.Visible = !rdoVung.Checked;

                gridBaoCaoVung.Visible =  rdoVung.Checked;
                ChartVungKieu1.Visible =  rdoVung.Checked;
                ChartVungKieu2.Visible = rdoVung.Checked;
            }
        }

        private void EF02_mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuNhanVienDangLamViec_Click(object sender, EventArgs e)
        {
            new frmThongTinNhanVienLamViec().ShowDialog();
        }

        private void mnuDMGara_Click(object sender, EventArgs e)
        {
            new frmDMGara().ShowDialog();
        }

        private void mnuTheHuy_Click(object sender, EventArgs e)
        {
            new frmTheHuy().ShowDialog();
        }
        /// <summary>
        /// báo cáo đi san bay đường dài theo ngày.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuBCDiSanBayDuongDai_Click(object sender, EventArgs e)
        {
            new frmBaoCaoDiSanBayDuongDai(G_arrProvince).ShowDialog();
        }

        private void btnBaoCaoHanhTrinhXeTheoNgay_Click(object sender, EventArgs e)
        {
            new frmBCXeHanhTrinhCuocKhach().ShowDialog();
        }

        private void mnuBackupDulieu_Click(object sender, EventArgs e)
        {
            new frmBackUpDuLieu().ShowDialog();
        }

        private void EF02_mniHelpOffline_Click(object sender, EventArgs e)
        {
            string HDSDPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            HDSDPath = HDSDPath + "\\" + "HDSD.pdf";
            System.Diagnostics.Process.Start(HDSDPath);
        }

        private void mnuDMSanh_Click(object sender, EventArgs e)
        {
            new frmSanhXe().ShowDialog();
        }

        private void mnuDiaDanhKm_Click(object sender, EventArgs e)
        {
            new frmDMDiaDanhKm().ShowDialog();
        }
        /// <summary>
        /// xóa những xe bị lỗi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string SoHieuXe = editSoHieuXe.Text;
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            if (msgDialog.Show(this, "Bạn có đồng ý xóa xe " + SoHieuXe + " không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
            {
                if (KiemSoatXeLienLac.DeleteXeBiNhapLoi(SoHieuXe))
                {
                    msgDialog.Show(this, "Xóa dữ liệu thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    this.GetKiemSoatXe();
                }
                else msgDialog.Show(this, "Có lỗi khi xóa dữ liệu.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);

            }
        }
        /// <summary>
        /// xu ly menu chuot phai cuoc goi da giai quyet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuChuotPhaiCuocGoiDaGiaiQuyet_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdSuaXeDon")
            {
                //load moi lai du lieu chua grid
                SuaCuocGoiDaGiaiQuyet();

            }
        }
        /// <summary>
        /// sua cuoc goi da giai quyen, thong tin xe nhan xe don
        /// </summary>
        private void SuaCuocGoiDaGiaiQuyet()
        {
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)gridCuocGoi_KetThuc.SelectedItems[0].GetRow().DataRow;
            
                /// Neu la cuoc goi nho thi thoat luon
                if (objDieuHanhTaxi != null)
                {
                    frmSuaXeNhanXeDon frm = new  frmSuaXeNhanXeDon (objDieuHanhTaxi.XeNhan, objDieuHanhTaxi.XeDon);
                     if(  frm.ShowDialog()==DialogResult.OK)
                    
                        
                        if (objDieuHanhTaxi.UpdateCuocGoiDaGiaiQuyet(frm.XeNhan,frm.XeDon))
                        {
                            msgDialog.Show(this, "Sửa dữ liệu thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            this.LoadCacCuocGoiKetThuc();
                        }
                        else msgDialog.Show(this, "Có lỗi khi sửa dữ liệu.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);

                     

                }
            }
        }

        private void lnkDSXeChuaCoThongTinLaiXe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmDSXeChuaCoTenLaiXe().ShowDialog();
        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void mnuBaoCaoMoiGioi_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuThoatCuoc_Click(object sender, EventArgs e)
        {
            new fmXoaDuLieu().ShowDialog();
        }

        

        #region Vung chon de kiem soat 
        /// <summary>
        /// thiết lập khi form gọi lần đầu
        /// </summary>
        private void KhoiTaoVungChoKiemSoat()
        {
            this.g_VungChonKiemSoat = "1,2,3,4,5,6,7,8,9,10";
        }
        #endregion 

        // thực hiện lấy ra ds cuộc gọi đã giải quyết.
        private void lnkLoadDuLieu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            try
            {
                LoadCacCuocGoiKetThuc();
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Lỗi load các cuộc gọi kết thúc - Timer", ex);
            } 
        }

        private void ChartVungKieu1_Click(object sender, EventArgs e)
        {

        }

        private void viewer2_Click(object sender, EventArgs e)
        {

        }

        

        private void mnuBCSanBayDuongDai_Click(object sender, EventArgs e)
        {
            new frmBaoCaoDiSanBayDuongDai(G_arrProvince).ShowDialog();
        }

        private void mnuBCCuocGoiDonDuoc_Click(object sender, EventArgs e)
        {
            new frmBaoCaoBieuMau5().ShowDialog();
        }

        private void mnLoaiPhanAnh_Click(object sender, EventArgs e)
        {
            new TaxiOperation_DieuHanhChinh.DM.frmDMLoaiPhanAnh().ShowDialog();
        }

        //-----------------------------phupn------------------------------------------------        
        private void mnuNhapDuLieuBangKe_Click(object sender, EventArgs e)
        {
            frmBangKe frmBangKe = new frmBangKe();
            frmBangKe.ShowDialog();
        }

        private void mnuQLBangKe_Click(object sender, EventArgs e)
        {
           
        }

        private void mnu5_6_BaoCaoMoiGioiTheoBangKe_Click(object sender, EventArgs e)
        {
           // new frm_5_6_BaoCaoMoiGioiTheoBangKe().ShowDialog();
        }

        private void cmdBaoCaoGiaiQuyetPA_Click(object sender, EventArgs e)
        {
            new frmBC_3_2_GiaiQuyetPhanAnh().ShowDialog();
        }
        private void cmdBCDiaChiMoiGioi_Click(object sender, EventArgs e)
        {
            new frmBC_6_1_DSDiaChiMoiGioi().ShowDialog();
        }

        private void cmdBCTongHopThongTinPA_Click(object sender, EventArgs e)
        {
            new frmBC_3_1_TongHopPhanAnh().ShowDialog();
        }
        private void BaoCaoMoiGioiCuocGoiThap_Click(object sender, EventArgs e)
        {
            new frmBC_6_2_DiaChiMoiGioi_CuocGoiThap().ShowDialog();
        }
        private void frmBCTongHopMGGoiQuaTT_Click(object sender, EventArgs e)
        {
           // new frm_5_7_BCTongHopMoiGioiGoiQuaTT().ShowDialog();
        }
             

        private void frm_6_5_BCChiTietCuocKhachMG_DiaChi_Click(object sender, EventArgs e)
        {
           // new BaoCao.New.frmBC_6_
        }
        
        //--------------------------------------hangtm---------------------------------------
        

        private void MenuQLTinNhan_Click(object sender, EventArgs e)
        {
            new TaxiOperation_DieuHanhChinh.QuanLyChat.Messenger().ShowDialog();            
        }

        

        private void MenuGuiTinNhan_Click(object sender, EventArgs e)
        {
            new TaxiOperation_DieuHanhChinh.QuanLyChat.SendMessage().ShowDialog();
        }

        private void MenuQLTinNhanSub_Click(object sender, EventArgs e)
        {
            new TaxiOperation_DieuHanhChinh.QuanLyChat.Messenger().ShowDialog();
        }

        private void MenuTinNhanMau_Click(object sender, EventArgs e)
        {
            new TaxiOperation_DieuHanhChinh.QuanLyChat.MessageTemplate().ShowDialog();
        }

        private void MenuSaveLayoutSetting_Click(object sender, EventArgs e)
        {
            if (gridLayout != null)
            {
                if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiChoGiaiQuyet")
                {
                    gridLayout.setLayout(gridDienThoai.GetLayout().LayoutString);
                    gridDienThoai.LoadLayout(gridLayout.getLayout(gridDienThoai.GetLayout()));
                }
                else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                {
                    gridLayout.setLayout(gridCuocGoi_KetThuc.GetLayout().LayoutString);
                    gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                }
            }
        }

        private void MenuCauHinhMacDinh_Click(object sender, EventArgs e)
        {
            if (gridLayout != null)
            {
                if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiChoGiaiQuyet")
                {
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhChinh));
                    gridLayout.setLayout(resources.GetString("gridEXLayout1.LayoutString"));
                    gridDienThoai.LoadLayout(gridLayout.getLayout(gridDienThoai.GetLayout()));
                }
                else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                {
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhChinh));
                    gridLayout.setLayout(resources.GetString("gridEXLayout2.LayoutString"));
                    gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                }
            }
        }

        private void mnuTiLePhanBo_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.frmTiLePhanBo().ShowDialog();
        }

        private void mnuKHACHDATNhapMoi_Click(object sender, EventArgs e)
        {
            new frmKhachDat() .ShowDialog(); 
        }

        private void mnuKHACHDATDanhsach_Click(object sender, EventArgs e)
        {
            new frmListKhachDat().ShowDialog();
        }        

        private void cmdDMVungGPS_Click(object sender, EventArgs e)
        {
            using (QuanLyVung_GPS myForm = new QuanLyVung_GPS())
            {
                List<GMap.NET.PointLatLng> vertices = new List<GMap.NET.PointLatLng>();
                CustomPolygon polygon = new CustomPolygon(vertices, "MyPolygon");
                myForm.MainPolygon = polygon;
                myForm.ShowDialog();
            }
        }

        private void cmdDinhNghiaTenDuong_Click(object sender, EventArgs e)
        {
            frmDinhNghiVietTatDuong frmVietTat = new frmDinhNghiVietTatDuong();
            frmVietTat.ShowDialog();
        }

        private void mnuCapNhatToaDo_Click(object sender, EventArgs e)
        {
            new frmCapNhatToaDo().Show();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.H:
                    ctrlListBook_ChoXuLy.ShowCtrlH();
                    return true;
                case Keys.Control | Keys.Down:
                    if (uiTabCuocGoiDangThucHien.SelectedTab == tabTaxiChieuVe)
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
                    if (uiTabCuocGoiDangThucHien.SelectedTab == tabTaxiChieuVe)
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
                case Keys.Shift | Keys.D1:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 0)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 0;
                    return true;
                case Keys.Shift | Keys.D2:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 1)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 1;
                    return true;
                case Keys.Shift | Keys.D3:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 2)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 2;
                    return true;
            }
            if (uiTabCuocGoiDangThucHien.SelectedTab == tabTaxiChieuVe)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
                        return true;
                    if (ctrlListBook_ChoXuLy.FindKeyCommand(keyData))
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

        #region -------------------Báo Cáo-------------------------------------------

        #region 1.Báo cáo cuộc gọi
        private void mnuGroupBC_1_1_TongKetGoiDen_Click(object sender, EventArgs e)
        {
            new frmBCGroupTongKetGoiDen_1_1().Show();
        }
        private void mnuGroupBC_1_2_ChiTietGoiDen_Click(object sender, EventArgs e)
        {
            new frmBCGroupChiTietCuocGoiDen_1_2().Show();
        }
        private void mnuGroupBC_1_3_ChiTietGoiDi_Click(object sender, EventArgs e)
        {
            new frm_1_3_BCChiTietGoiDi().Show();
        }
        private void mnuGroupBC_1_4_CuocGoiKhongNhacMay_Click(object sender, EventArgs e)
        {
            new frm_1_4_BCKhongNhacMay().Show();
        }

        #region BC chuyen sang My Dinh
        private void mnu1_1_BCTongHopCuocGoiDenThoeNgay_Click(object sender, EventArgs e)
        {
            new frmBC_1_1_TongHopCuocGoiDenTheoNgay().Show();
        }

        private void mnu1_1_BCTongHopCuocKhachTheoGio_Click(object sender, EventArgs e)
        {
            new fastTaxi_1_1_TongHopCuocGoiDenTheoGio().Show();
        }

        private void mnu1_1_BCTongHopCuocKhachTheoCa_Click(object sender, EventArgs e)
        {
            new frmBC_1_2_TongHopCuocGoiDenTheoCa().Show();
        }

        private void mnu1_3_ChiTietCuocGioDen_Click(object sender, EventArgs e)
        {
            new frmBC_1_3_ChiTietCuocGoiDen().Show();
        }

        private void mnu1_4_ChiTietCuocGoiDi_Click(object sender, EventArgs e)
        {
            new frmBC_1_4_BCChiTietGoiDi().Show();
        }

        private void mnu1_5_ChiTietCuocGioKhongNhayMay_Click(object sender, EventArgs e)
        {
            new frmBC_1_5_KhongNhacMay().Show();
        }

        private void mnuBCTongHopCuoc999_Click(object sender, EventArgs e)
        {
            new frmBC_1_6_BaoCaoTongHopThoatCuoc999().Show();
        }

        private void mnuDBChiTietCuoc999_Click(object sender, EventArgs e)
        {
            new frmBC_1_7_BaoCaoChiTietThoatCuoc999().Show();
        }

        private void mnuChiTietKhachDat_Click(object sender, EventArgs e)
        {
            new frmBC_1_8_BaocaoChitTietKhachDat().Show();
        }

        private void mnuBCTongHopChuyenVung_Click(object sender, EventArgs e)
        {
            frmBC_1_3_ChiTietCuocGoiDen_LogVung frmBC_1_3_ChiTietCuocGoiDen_LogVung = new frmBC_1_3_ChiTietCuocGoiDen_LogVung();
            frmBC_1_3_ChiTietCuocGoiDen_LogVung.Show();
        }
        #endregion
        

        #endregion

        #region 2.Báo cáo CSKH
        private void mnu2_1_BCTongHopCSKH_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHTongHop().Show();
        }
        private void mnu2_2_BCChiTietCSKH_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHChiTiet().Show();
        }
        #endregion

        #region 3.Báo cáo giải quyết khiếu nại
        private void mnu3_1_BCTongHopKhachhangPhanAnh_Click(object sender, EventArgs e)
        {
            new frmBC_3_1_TongHopPhanAnh().Show();
        }
        private void mnu3_1_BCChiTietPhanAnh_Click(object sender, EventArgs e)
        {
            new frmBC_3_2_GiaiQuyetPhanAnh().Show();
        }
        #endregion

        #region 4.Báo cáo kết quả điều hành
        private void BCKetQuaDieuHanhTheoNgay_Click(object sender, EventArgs e)
        {
            new frmBC_4_1_KetQuaDieuHanhTheoNgay().Show();
        }

        private void BCKetQuaDieuHanhTheoCa_Click(object sender, EventArgs e)
        {
            new frmBC_4_2_KetQuaDieuHanhTheoCa().Show();
        }

        private void BCKetQuaDieuHanhTheoGio_Click(object sender, EventArgs e)
        {
            new frmBC_4_3_KetQuaDieuHanhTheoGio().Show();
        }

        private void mnu4_4BCDieuHanhTheoDonVi_Click(object sender, EventArgs e)
        {
            new frmBC_4_4_KetQuaDieuHanhTheoDonVi().Show();
        }

        private void mnuKQNVTheoNgay_Click(object sender, EventArgs e)
        {
            new frmBC_4_6_KQDieuHanhNVTheoNgay().Show();
        }

        private void mnuBC_4_5_TongHopTheoNhanVien_Click(object sender, EventArgs e)
        {
            new frmBC_4_5_TongHopKQDieuHanhNV().Show();
        }
        #endregion

        #region 5.Báo cáo điều hành
        private void mnu5_1_BCThoiGianXeRaVe_Click(object sender, EventArgs e)
        {
            new frmBC_5_1_ThoiGianXeRaVe().Show();
        }
        
        private void mnu5_2_BCThongTinVeHuy_Click(object sender, EventArgs e)
        {
            new frmBC_5_2_ThongTinVeHuy().Show();
        }

        private void mnu5_3_BCHanhTrinhXeBaoTrungTam_Click(object sender, EventArgs e)
        {
            new frmBC_5_3_BaoCaoHanhTrinhXe().Show();
        }

        private void mnu5_4_BCSanBayDuongDai_Click(object sender, EventArgs e)
        {
            new frmBaoCaoDiSanBayDuongDai(G_arrProvince).Show();
        }

        private void mnuBCXeGapSuCo_Click(object sender, EventArgs e)
        {
            new frmBC_5_5_XeGapSuCo().Show();
        }

        private void mnuBaoCaoSuCoVeThe_Click(object sender, EventArgs e)
        {
            new frmBC_5_6_SuCoVeThe().Show();
        }

        #endregion

        #region 6.Báo cáo môi giới
        private void mnu6_1_DanhSachDiaChiMoiGioi_Click(object sender, EventArgs e)
        {
            new frmBC_6_1_DSDiaChiMoiGioi().Show();
        }

        private void mnu6_2_BCDiaChiMoiGioiCuocGoiThap_Click(object sender, EventArgs e)
        {
            new frmBC_6_2_DiaChiMoiGioi_CuocGoiThap().Show();
        }
        private void mnu6_3_DiaChiMoiGioiMoiKhaiThac_Click(object sender, EventArgs e)
        {
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            DateTime ngayBDTu = new DateTime(timeServer.Year, timeServer.Month, 1, 0, 0, 0);
            DateTime ngayDBDen = timeServer;
            new frmBC_6_1_DSDiaChiMoiGioi(ngayBDTu, ngayDBDen).Show();
        }
        private void mnu6_4_TongHopMoiGioiQuaTrungTam_Click(object sender, EventArgs e)
        {
            //new frmBC_6_4_TongHopMoiGioiGoiQuaTT().Show();
        }
        private void mnu6_5_ChiTietCuocKhachMoiGioi_Click(object sender, EventArgs e)
        {
            new frmBC_6_5_BaoCaoMoiGioiTheoDiaChi().Show();
        }
        private void mnu6_5_BCMoiGioiTheoBangKe_Click(object sender, EventArgs e)
        {
            new frmBC_6_6_THCuocGoiMG_TheoXe().Show();
        }
        private void mnu6_7_BCCuocKhachMGTheoDiaChi_Click(object sender, EventArgs e)
        {
            new frmBC_6_7_MoiGioiTheoDiaChi().Show();
        }

        private void mnuBCMoiGioiCu_Click(object sender, EventArgs e)
        {
            new frmBaoCaoGroupMoiGioiCuocKetQuaDieuHanh().Show();
        }
        #endregion

        #region 7.Báo cáo kênh đàm
        private void bcTinhTrangVungDam_Click(object sender, EventArgs e)
        {
            new frmBC_7_4_TinhTrangVungDam().Show();
        }
        #endregion

        #region 8. Báo cáo khách hàng thường xuyên
        private void mnuBC8_1TongHopKHThuongXuyen_Click(object sender, EventArgs e)
        {
            new frmBC_8_2_TongHopKhachHangThuongXuyen().Show();
        }

        private void mnu8_2ChitietKhachHangThuongXuyen_Click(object sender, EventArgs e)
        {
            new frmBC_8_2_ChiTietCuocGoiDenTheoNgay().Show();
        }
        #endregion

        #region 9. Báo cáo điều hành GPS
        private void frmBC_GPS_1_CuocGoiGPSTheoNgay_Click(object sender, EventArgs e)
        {
            frmBC_GPS_1_BCCuocGoiDieuGPSTheoNgay frmBC_GPS_1_BCCuocGoiDieuGPSTheoNgay = new frmBC_GPS_1_BCCuocGoiDieuGPSTheoNgay();
            frmBC_GPS_1_BCCuocGoiDieuGPSTheoNgay.Show();
        }

        private void mnuBCCuocGoiDieuHanh_CanhBao_Click(object sender, EventArgs e)
        {
            frmBC_GPS_2_BCCuocGoiCoCanhBao frmBC_GPS_2_BCCuocGoiCoCanhBao = new frmBC_GPS_2_BCCuocGoiCoCanhBao();
            frmBC_GPS_2_BCCuocGoiCoCanhBao.Show();
        }

        private void mnuBCXeNhanKoThuocXeDeCu_Click(object sender, EventArgs e)
        {
            new frmBC_GPS_2_BCXeNhanKhongThuocDeCu().Show();
        }
        #endregion

        #endregion

        #region -------------------Báo Cáo khac _ Cũ-------------------------------------------
        private void mnuMOIGIOI_BaocaoTongHop_Click(object sender, EventArgs e)
        {
            new frmBaoCaoGroupMoiGioi().ShowDialog();
        }

        private void mnuBCMoiGioiTongHop_Click(object sender, EventArgs e)
        {
            new frmBaoCaoGroupMoiGioi().ShowDialog();
        }

        private void mnuMoiGioi_KetQuaDieuHanh_Click(object sender, EventArgs e)
        {
            new frmBaoCaoGroupMoiGioiCuocKetQuaDieuHanh().ShowDialog();
        }

        private void mnuBCCSKHTongHop_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHTongHop().ShowDialog();
        }

        private void mnuBCChiTietCSKH_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHChiTiet().ShowDialog();
        }

        private void mnuBCCSKH_Click(object sender, EventArgs e)
        {

        }

        private void mnuBaoCaoDieuHanh_Click(object sender, EventArgs e)
        {

        }

        private void mnuGroupBC_3_1_BCKetQuaDieuHanh_Click(object sender, EventArgs e)
        {
            new frm_3_1_BCKetQuaDieuHanh().ShowDialog();
        }

        private void mnuGroupBC_3_1_BCKetQuaDieuHanhTheoDVI_Click(object sender, EventArgs e)
        {
            new frm_3_2_BCKetQuaDieuHanhTheoDVi().ShowDialog();
        }

        private void mnuGroupBC_2_1_BCTongHopCSKH_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHTongHop().ShowDialog();
        }

        private void mnuGroupBC_2_2_BCChiTietCSKH_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHChiTiet().ShowDialog();
        }

        private void mnuBaoCaoNhanVien_Click(object sender, EventArgs e)
        {
            new frm_2_3_BaoCaoNhanVien().ShowDialog();
        }

        private void mnuGroupBC_4_4_BaoCaoHanhTrinhXe_Click(object sender, EventArgs e)
        {
            new frm_4_4_BaoCaoHanhTrinhXe().ShowDialog();
        }

        private void mnuGroupBC_5_2_BCTongHopMoiGioiGoiQuaTrungTam_Click(object sender, EventArgs e)
        {
            new frmBaoCaoGroupMoiGioi().ShowDialog();
        }

        private void mnuGroupBC_5_2_BCChiTietMoiGioiDVi_Click(object sender, EventArgs e)
        {
            new frmBaoCaoGroupMoiGioiCuocKetQuaDieuHanh().ShowDialog();
        }

        private void mnuGroupBC_5_5_BCMoiGioiTheoDiaChi_Click(object sender, EventArgs e)
        {
            new frm_5_5_BaoCaoMoiGioiTheoDiaChi().ShowDialog();
        }

        private void mnuBCXeRaHoatDong_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau14().ShowDialog(this);
        }

        private void mnuBieuMau1_Baocaotheoca_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau01_new().ShowDialog(this);
        }
        private void mnuBaoCaoLuongKhachGoi_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau2().ShowDialog(this);
        }

        private void mnuBaoCaoCuocGoiCuaMoiGioi_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau3().ShowDialog(this);
        }
        private void mnuBaoCaoCuocGoiKhongNhacMay_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau4().ShowDialog(this);
        }
        private void mnuBieuMau5_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau5().ShowDialog(this);
        }
        private void mnuBaoCaoBieuMau6_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau6().ShowDialog(this);
        }
        private void mnuBaoCaoBieuMau7_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau7().ShowDialog(this);
        }
        private void mnuBaoCaoBieuMau8_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMa08().ShowDialog(this);
        }
        private void mnuBaoCao_BieuMau9_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau09().ShowDialog(this);
        }
        private void mnuBieuMauBaoCao10_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frm_5_5_BaoCaoMoiGioiTheoDiaChi().ShowDialog(this);
        }
        private void mnuBieuMauBaoCao11_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau11().ShowDialog(this);
        }
        // san luong theo thoi gian
        private void mnuBaoCao12_SanLuongTheoGio_Click(object sender, EventArgs e)
        {

            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau12().ShowDialog(this);
        }
        // cuoc goi di
        private void mnuBacCao13_CuocGoiDi_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau13().ShowDialog(this);
        }
        // bao cao xe hoat dong
        private void mnuBaoCao14_XeHoatDong_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau14().ShowDialog(this);
        }
        private void mnuBaoCaoCuocgoiNho_Click(object sender, EventArgs e)
        {
            new frmViewCuocGoiKhongThanhCong().ShowDialog(this);
        }

        private void mnuBaoCaoKhachVangLai_Click(object sender, EventArgs e)
        {
            new frmViewBaoCaoKhachVangLai().ShowDialog(this);
        }

        private void mnuBaoCacCacCuocGoiDenTuSoDT_Click(object sender, EventArgs e)
        {
            new frmViewBaoCaoCuocGoiDenTuSoDT().ShowDialog(this);
        }

        private void mnuBC14Xedanghoatdong_Click(object sender, EventArgs e)
        {
            Taxi.GUI.BaoCao.frmBaoCaoBieuMau14 frm = new Taxi.GUI.BaoCao.frmBaoCaoBieuMau14();
            frm.ShowDialog();
        }
        private void mnuBaoCao15_XeMatLienLac_Click(object sender, EventArgs e)
        {
            new frmBaoCaoBieuMau15().ShowDialog();
        }

        private void mnuBaoCao16_HanhTrinhXe_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.BaoCao.frmBaoCaoBieuMau17().ShowDialog();
        }
        #endregion

        #region mnu
        private void mnuTHCGTheoSDT_Click(object sender, EventArgs e)
        {
            //new frmBC_8_2_ChiTietCuocGoiDenTheoNgay().Show();
        }

        private void tinhTienToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuLoaiXe1_Click(object sender, EventArgs e)
        {
            new frmDMLoaiXe().Show();
        }

        private void mnuBaoCaoTheoQuan_Click(object sender, EventArgs e)
        {
            new frmBC_GPS_5_BCCuocGoiDieuGPSTheoQuan().Show();
        }

        private void mnuNhapXeDiDuongDai_Click(object sender, EventArgs e)
        {
            new ThongTinSanBay_DuongDai(G_arrProvince, G_arrDistrict, G_arrCommune, "").ShowDialog();
        }

        private void mnuDSXeDiDuongDai_Click(object sender, EventArgs e)
        {
            new DSCuocDuongDai_SanBay(G_arrProvince, G_arrDistrict, G_arrCommune).Show();
        }

        private void mnuBCNhatKyThueBao_Click(object sender, EventArgs e)
        {
            new frmBCNhatKyThueBao().ShowDialog();
        }

        private void mnuBCNhatKyDieuHanh_Click(object sender, EventArgs e)
        {
            new frmBCNhatKyDieuHanh().ShowDialog();
        }

        private void mnuBCKhachQuenThang_Click(object sender, EventArgs e)
        {
            new frmBaoCaoKhachQuenTheoThang().ShowDialog();
        }

        private void mnuNhapBangGiaThueBao_Click(object sender, EventArgs e)
        {
            new frmNhapBangGiaGoc().ShowDialog();
        }

        private void mnuNhatKyThueBao_Click(object sender, EventArgs e)
        {
            new frmThongTinNhatKyThueBao().ShowDialog();
        }

        private void mnuTraCuuThueBao_Click(object sender, EventArgs e)
        {
            new frmTraCuuBangGiaGoc().ShowDialog();
        }

        private void mnuGiamSatXe_Click(object sender, EventArgs e)
        {
            if (frmGSXe == null || frmGSXe.Visible == false)
            {
                frmGSXe = new frmGiamSatXe(this, G_ListLaiXe);
                frmGSXe.Show(this);
            }
        }

        private void dmMemberCard_Click(object sender, EventArgs e)
        {
            new frmMemberCard().Show();
        }

        private void MemberCard_Search_Click(object sender, EventArgs e)
        {
            new frmMemberCard_Search().Show();
        }

        private void mnu_ChotCoDuongDai_Full_Click(object sender, EventArgs e)
        {

        }

        private void mnu_ChotCoDuongDai_RutGon_Click(object sender, EventArgs e)
        {
            using (frmXeBaoDiSanBay_DuongDai_Mini thongTinSanBay_DuongDai = new frmXeBaoDiSanBay_DuongDai_Mini())
            {
                thongTinSanBay_DuongDai.ShowDialog();
            }
        }

        private void mnu_BC_ChotCoDuongDai_RutGon_Click(object sender, EventArgs e)
        {
            new frmBaoCaoDiSanBayDuongDai_RutGon().Show();
        }

        private void mnu_BC_KhachMGTheoNgay_Click(object sender, EventArgs e)
        {
            new frmBC_KhachMoiGioi_TheoNgay().Show();
        }

        private void mnuDanhBaBuuDien_Click(object sender, EventArgs e)
        {
            new frmDanhBaBuuDien().Show();
        }

        private void mnuCapNhatBanQuyen_Click(object sender, EventArgs e)
        {
            if (Taxi.Services.Service_Common.UpdateLicense())
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại, hoặc liên hệ với quản trị");
        }
        #endregion

        #region Báo cáo FastTaxi
        private void báoCáoTổngCuốcGọiTheoGiờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fastTaxi_1_1_TongHopCuocGoiDenTheoGio().ShowDialog();}

        private void báoCáoChiTiếtCuộcGọiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fastTaxi_1_2_ChiTietCuocGoiDen().ShowDialog();
        }
        #endregion

        private void báoXeĐiĐườngDàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThongTinCauHinh.FT_ChieuVe_Active)
            new frmUpdateTrip().ShowDialog();
        }

        private void báoCáoChiTiếtBáoXeĐiĐườngDàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBaoCao_1_1_ChiTietXeBaoDiDuongDai().Show();
        }

        private void báoCáoChiTiếtKháchCầnXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBaoCao_1_2_ChiTietKhachCanXe().Show();
        }

        private void báoCáoTổngHợpChiềuVềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBaoCao_1_3_TongHopChieuVe().Show();
        }

        private void danhSáchXeViPhạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLoiViPham().Show();
        }

        private void cấuHìnhBànCờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConfigDHBanCo().Show();
        }

        private void cấuHìnhLoạiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDMLoaiXe_Truck().Show();
        }

        private void cmdConfigCommand_Click(object sender, EventArgs e)
        {
            new frmMobileOperationCommands().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void bCChiTiếtCuốcKháchMôiGiớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBC_6_8_ChiTietCuocGoiTheoMaMoiGioi().Show();
        }

        private void danhMụcKháchHàngDùngThẻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDanhMucKhachDungThe().Show();
        }

        private void MenuQLTinNhan_Click_1(object sender, EventArgs e)
        {

        }

        private void danhMụcĐườngPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmManagerDuongPho().Show();
        }

        private void báoCáoTổngHợpTheoĐườngPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmBC_1_10_BaoCaoThongKeTheoTenDuong().Show();
        }
    }
}