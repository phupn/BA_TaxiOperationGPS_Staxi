using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.Business.QuanTri;
using Taxi.Utils;
using System.IO;
using System.Diagnostics;
using Taxi.Business.ThongTinPhanAnh;
using Taxi.Business.GridLayout;

namespace Taxi.GUI
{
    public partial class frmDieuHanhDienThoaiNEWCP_V2 : Form
    {
        private List<DieuHanhTaxi> g_lstDienThoai = new List<DieuHanhTaxi>();
        private List<DieuHanhTaxi> g_lstCuocGoiDangTheoDoi = new List<DieuHanhTaxi>();
        private bool g_boolChuyenTabCuocGoiKetThuc = false; // thiet lap de load trong timer
        private bool g_boolNhayMauKhiCoCuocGoiMoi = false; // mac dinh la load luon dau tien
        private Color g_ColorOldTabCuocGoiDangThucHien;        
        private bool g_boolIsTrungSoDienThoaiDangGiaiQuyen;
        private int g_iStatus = 0;  // Blink stauts
        private Timer TimerCapturePhone;

        private string g_LinesDuocCapPhep = string.Empty;
        private int g_SoDong = 20;  // 20 dong cuoc goi da ket thuc
        
        // luu lai thong so dong duoc chon
        private int g_rowIndexSelected_CuocGoiCuaNhom = -1;

        private string g_strUsername = "";
        private string g_IPAddress = "";

        private DateTime g_TimeServer = DateTime.MinValue;
        private int g_Count = 0;  // Dem so lan trong timer
        
        private bool g_bKetThucTimer = false;
        private Messenger frmMessenger = new Messenger();

        //--------------------------------LAYOUT----------------------------------------------------
        private GridLayout gridLayout;
        private void loadLayout(GridEX gridEX)
        {
            gridLayout = new GridLayout(ThongTinDangNhap.USER_ID, "DienThoai", Name, gridEX.Name);
            gridEX.LoadLayout(gridLayout.getLayout(gridEX.GetLayout()));
        }
        //--------------------------------LAYOUT----------------------------------------------------


        public frmDieuHanhDienThoaiNEWCP_V2()
        {
            InitializeComponent();
        }
        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
            try
            {
                //-----------Set location for panel message
                pnlMessage.Location = new Point(Width - pnlMessage.Width - 14, 0);
                if (DieuHanhTaxi.CheckConnection())
                {// Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();
                    g_TimeServer =  DieuHanhTaxi.GetTimeServer();
                    //---------------------------------------------------- 
                    g_ColorOldTabCuocGoiDangThucHien = uiTabCuocGoiDangThucHien.BackColor;// luu lai mau hien tai 
                    Text = String.Format("{0} - {1}", Configuration.GetCompanyName(), Text);
                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    g_LinesDuocCapPhep = QuanTriCauHinh.GetLinesOfPCDienThoai(g_IPAddress);
                   
                    if (g_LinesDuocCapPhep.Length > 0)
                    {                       
                        LoadAllCuocGoiHienTai();
                        gridDienThoai.Focus();
                        CheckIn();
                        g_bKetThucTimer = true;

                        //get tin nhan moi - hien thi noi dung tin nhan tren goc phai man hinh
                        getNewMessage();

                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi

                        //--------------------------LAYOUT-------------------------------------
                        loadLayout(gridDienThoai);
                        //--------------------------LAYOUT-------------------------------------
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show(this, "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                        Application.Exit();
                    } 
                }
                else
                {
                    new MessageBox.MessageBox().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBox().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                if (TimerCapturePhone!=null ) TimerCapturePhone.Enabled = false;
           
                Application.Exit();
            }

        }

        #region ChẹckIn/CheckOut
        /// <summary>
        /// check in, goi form frmCheckInOut
        /// </summary>
        private void CheckIn()
        {
            using (frmCheckInOut frm = new frmCheckInOut())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    g_strUsername = ThongTinDangNhap.USER_ID;
                    if (g_strUsername.Length > 0)
                    {
                        if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress))
                        {
                            // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
                            cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        }
                        else
                        {
                            // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
                            if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
                            {
                                new MessageBox.MessageBox().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống.Cần checkout hoặc đăng xuất cưỡng chế.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                                Application.Exit();
                                return;
                            }
                            // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
                            if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
                            {
                                new MessageBox.MessageBox().Show(this, "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                                ThongTinDangNhap.USER_ID = "";
                                g_strUsername = "";
                                Application.Exit();
                                return;
                            }
                            if (!((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) || (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
                            {
                                new MessageBox.MessageBox().Show(this, "Bạn không có quyền điều hành điện thoại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                                ThongTinDangNhap.USER_ID = "";
                                g_strUsername = "";
                                Application.Exit();
                                return;
                            }
                            else
                            {
                                // cap nhat trang thai
                                if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
                                {
                                    new MessageBox.MessageBox().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                                    ThongTinDangNhap.USER_ID = "";
                                    g_strUsername = "";
                                    Application.Exit();
                                    return;
                                }
                            }
                            // thiet lap menu disable 
                            cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            statusBar.Panels["TenDangNhap"].Text = " NV điện thoại : " + g_strUsername;
                        }
                    }
                    else
                    {
                        cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                    }
                }
            }
        }

        #endregion 


        #region Nhan cuoc goi moi co

        #region Cac ham lien quan toi Timer Capture Phone
        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = TimerLength;
            TimerCapturePhone.Tick += TimerCapturePhone_Tick;
            TimerCapturePhone.Start();

        }
        /// <summary>
        /// Nhan cac cuoc goi moi 
        /// Nhan thong tin moi chuyen ve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        public void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                // 1 giây cập nhật một lần 
                g_TimeServer = g_TimeServer.AddSeconds(1);
                g_Count++;
                if (g_bKetThucTimer)
                {
                    g_bKetThucTimer = false;
                    if (g_lstCuocGoiDangTheoDoi != null)
                    {
                        if (g_lstCuocGoiDangTheoDoi.Count > 0) g_lstCuocGoiDangTheoDoi.Clear();
                    }                 
                    g_lstCuocGoiDangTheoDoi = GetAllCuocGoiDangTheoDoi(g_LinesDuocCapPhep); 
                    NhanCacCuocGoiMoiVe();
                    XoaCacCuocGoi_TongDaiKetThuc();
                    CapNhatThongTinCuocGoiBiThayDoi();
                    XuLyCuocGoiNho(); 

                    // load cuoc goi ket thuc
                    if ((g_boolChuyenTabCuocGoiKetThuc))
                    {
                        try
                        { 
                            LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);                                
                        }
                        catch (Exception ex)
                        {

                        }
                        g_boolChuyenTabCuocGoiKetThuc = false;
                    }

                    if (g_Count >= 10)
                    {
                        // Kiem tra tin nhan
                        if (frmMessenger.IsDisposed == false)
                        {

                            if (frmMessenger.Visible == false)
                            {
                                if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
                                {
                                    frmMessenger.Show();
                                }
                            }
                            else
                            {
                                frmMessenger.BringToFront();
                            }
                        }
                        else
                        {
                            frmMessenger = new Messenger();
                            if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
                            {
                                frmMessenger.Show();
                            }
                        }
                        //get tin nhan moi - hien thi noi dung tin nhan tren goc phai man hinh
                        getNewMessage();
                        g_Count = 0;
                    }
                    // Xu ly dien thi anh trang thai, va trang thai mau cua chatting

                    BlinkStatus(g_iStatus);
                    if (g_iStatus == 1) g_iStatus = 2;
                    else g_iStatus = 1;
                    ViewTrangThaiCacCuocGoiO_StatusBar();
                    g_bKetThucTimer = true;
                }
            }
            catch (Exception ex)
            {
                g_bKetThucTimer = true;
            }
        }

        /// <summary>
        /// Lấy nội dung tin nhắn gần nhất có trạng thái = 1 (là luôn luôn hiển thị)
        /// </summary>
        private void getNewMessage()
        {
            try
            {
                DataTable dtMsg = new Chatting().GetNewMessage(ThongTinDangNhap.USER_ID);
                if (dtMsg == null)
                {
                    pnlMessage.Visible = false;
                    txtNDTinNhan.Text = "";
                    return;
                }
                if (dtMsg.Rows.Count <= 0)
                {
                    pnlMessage.Visible = false;
                    txtNDTinNhan.Text = "";
                    return;
                }

                pnlMessage.Visible = true;
                txtNDTinNhan.Text = dtMsg.Rows[0]["Contents"].ToString();
                dtMsg.Dispose();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        #region Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

        /// <summary>
        /// nhung cuoc goi dang co o T_TAXIOPERATION
        /// </summary>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiDangTheoDoi()
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                // chi lay cac cuoc goi taxi hoac cuoc goi co lenh la khong truyen di hoac goi nho
                string SQLCondition = " AND ( KieuCuocGoi=1 OR KieuCuocGoi=7 OR TrangThaiLenh='0'  )  ORDER BY ThoiDiemGoi DESC";
                return objDHTaxi.GetAllOf_DienThoai(SQLCondition);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// nhung cuoc goi dang co o T_TAXIOPERATION với Lines == line của người nhận
        /// </summary>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiDangTheoDoi(string Lines)
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                // chi lay cac cuoc goi taxi hoac cuoc goi co lenh la khong truyen di hoac goi nho
                string SQLCondition = " AND (" + this.GetSQLStringQueryLines(Lines) + ") AND ( KieuCuocGoi=1 OR KieuCuocGoi=2  OR KieuCuocGoi=7 OR TrangThaiLenh='0'  )  ORDER BY ThoiDiemGoi DESC";
                return objDHTaxi.GetAllOf_DienThoai(SQLCondition);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Lines kiểu : 1;3;5;6;7
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private string GetSQLStringQueryLines(string Lines)
        {
            string strReturn = " (1<>1) ";
            string[] arrLine = Lines.Split(";".ToCharArray());

            foreach (string strLine in arrLine)
            {
                if (strLine.Length > 0) strReturn += String.Format(" OR (Line = '{0}') ", strLine);
            }
            return strReturn;
        }
        /// <summary>
        /// input la danh sach cac cuoc goi dang theo doi (chua ket thuc)
        /// output : cuoc goi moi nhat ((TrangThaiLenh=0)
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiMoi(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiMoiNhan = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.KhongTruyenDi)
                        ListCuocGoiMoiNhan.Add(objDHTaxi);
                }
                // kiem tra xem co phai goi lai khong
                if (ListCuocGoiMoiNhan.Count > 0)
                {
                    int lenCuocGoiMoi = ListCuocGoiMoiNhan.Count;
                    int lenCuocGoi = ListAllCuocGoiDangHoatDong.Count;
                    for (int i = 0; i < lenCuocGoiMoi; i++)
                    {
                        for (int j = 0; j < lenCuocGoi; j++)
                        {
                            if ((ListCuocGoiMoiNhan[i].CuocGoiLaiIDs.Length<=0) && (ListAllCuocGoiDangHoatDong[j].TrangThaiLenh != TrangThaiLenhTaxi.KhongTruyenDi) && (ListCuocGoiMoiNhan[i].PhoneNumber != ThongTinCauHinh.SoDienThoaiCongTy) && (ListCuocGoiMoiNhan[i].PhoneNumber == ListAllCuocGoiDangHoatDong[j].PhoneNumber))
                            {
                                ListCuocGoiMoiNhan[i].CuocGoiLaiIDs = ListAllCuocGoiDangHoatDong[j].ID_DieuHanh.ToString (); break;
                            }
                        }
                    }
                }
            } 
            return ListCuocGoiMoiNhan;
        }
        /// <summary>
        /// Get tat ca cac cuoc goi tong dai moi truyen sang (TrangThaiLenh=2)
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiTongDaiMoiTruyenSang(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiTongDaiTruyenSang = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if ((objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.BoDam) || (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoai)
                        || (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoaiGuiSangMoiKhach)
                        || (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach)
                        || (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.MoiKhachGui))
                        ListCuocGoiTongDaiTruyenSang.Add(objDHTaxi);
                }
            }
            return ListCuocGoiTongDaiTruyenSang;

        }
        /// <summary>
        /// get tat ca cuoc goi chua co so chuong ((TrangThaiCuocGoi=9 AND TrangThaiLenh=4, khong ) OR (TrangThaiCuocGoi=7 AND TrangThaiLenh=0)
        /// Cuoc goi da nhac may (TrangThaiCuocGoi=7), Cuoc goi nho (TrangThaiCuocGoi=9)
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiChuaCoSoChuong(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiChuaChuong = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if (((objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai) && (objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.TrangThaiKhac)) || ((objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi) && (objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.TrangThaiKhac )))
                        ListCuocGoiChuaChuong.Add(objDHTaxi);
                }
            }
            return ListCuocGoiChuaChuong;
        }
        #endregion Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

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

                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)row.DataRow;
                if ((objDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.KhongTruyenDi) ||
                    (objDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.BoDam) ||
                    (objDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoai))
                    row.Cells["ImageCol"].ImageIndex = (int)objDieuHanhTaxi.TrangThaiLenh;
                else row.Cells["ImageCol"].ImageIndex = 1;

                if (objDieuHanhTaxi.CuocGoiLaiIDs!=null &&  objDieuHanhTaxi.CuocGoiLaiIDs.Length >= 2 )
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Cyan;                    
                    row.Cells["PhoneNumber"].FormatStyle = RowStyle;
                   
                    GridEXFormatStyle RowStyleDC = new GridEXFormatStyle();
                    RowStyleDC.FontItalic = TriState.True;
                    RowStyleDC.FontBold = TriState.True;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyleDC;
                    
                }
                // Set mau lines cho nhung so dien 
              
                if(! DieuHanhTaxi.CheckLineDuocPhepsuDungMayNay(g_LinesDuocCapPhep , objDieuHanhTaxi.Line ))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightGray;
                    row.RowStyle = RowStyle;
                     
                }
                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (objDieuHanhTaxi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangKhongHieu)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Red;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangHen)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Violet;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }

                if (objDieuHanhTaxi.LenhDienThoai.Contains("gọi lại"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyle;
                }
                if (objDieuHanhTaxi.ThoiDiemChuyenTongDai > Configuration.GetDienThoai_ThoiDiemChuyenTongDai())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    row.Cells["ThoiDiemChuyenTongDai"].FormatStyle = RowStyle;
                }
                if (objDieuHanhTaxi.GhiChuTongDai.Contains("trượt"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["GhiChu"].FormatStyle = RowStyle;
                }

                if (objDieuHanhTaxi.LoaiXe.Contains("7"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Cyan;                  
                    row.Cells["LoaiXe"].FormatStyle = RowStyle;
                }
               
                // Hiển thị màu theo thời gian để cảnh báo
                TimeSpan timeSpan = g_TimeServer - objDieuHanhTaxi.ThoiDiemGoi; 
                if (timeSpan.TotalMinutes >= 5 && timeSpan.TotalMinutes < 10)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightCyan; // xanh nhat
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
                }
                else if (timeSpan.TotalMinutes >= 10 && timeSpan.TotalMinutes < 15)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Turquoise;    // xanhdam hon
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
                }
                else if (timeSpan.TotalMinutes >= 15)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightPink;
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
                }

                if (timeSpan.TotalMinutes > 1 && objDieuHanhTaxi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Red ;
                    row.RowStyle = RowStyle;
                }
            }
            catch (Exception ex)
            {
              
            }
        }



        /// <summary>
        /// Nhung cuoc goi moi ve la nhung cuoc goi co TrangThaiLenh = KhongTruyenDi=0
        ///     - Load trong DB xem co cuoc  goi nao moi ve khong
        ///     - Them vao dau tien cua luoi
        /// </summary>
        private void NhanCacCuocGoiMoiVe()
        {
            try
            {
                List<DieuHanhTaxi> lstDienThoaiCuocGoiMoi = new List<DieuHanhTaxi>();
                lstDienThoaiCuocGoiMoi = GetAllCuocGoiMoi(g_lstCuocGoiDangTheoDoi);
                if (lstDienThoaiCuocGoiMoi == null) return;
                if (lstDienThoaiCuocGoiMoi.Count > 0) // Co cuoc goi moi
                {
                    if (GhepThemCuocGoiMoiNhanVaoDau(lstDienThoaiCuocGoiMoi))
                    {

                        DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep); 
                        // Khoi phat su kien nhap nhay
                        timerNhayBaoCuocGoiMoi.Enabled = true;

                    }
                    //  gridDienThoai.Refresh();
                }
            }
            catch (Exception ex)
            {
                // TimerCapturePhone.Stop(); 
                //  new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                
            }
        }
        /// <summary>
        /// kiem tra thoi gian neu duoc 15 phuc thi cho ket thuc
        /// </summary>
        private void XuLyCuocGoiNho()
        {
            // lay thoi gian cua may chu
            DateTime timeServer = g_TimeServer;
            List<DieuHanhTaxi> lstRemoveCuocGoiNho = new List<DieuHanhTaxi>();
            if (g_lstDienThoai == null) return;
            foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
            {
                if (objDHTX.GhiChuDienThoai.Contains("gọi nhỡ"))
                {

                    if ((timeServer.Hour * 60 + timeServer.Minute) - (objDHTX.ThoiDiemGoi.Hour * 60 + objDHTX.ThoiDiemGoi.Minute) >= 15)// 15 phút thì remove sang cuoc goi da xu ly
                    {
                        lstRemoveCuocGoiNho.Add(objDHTX);
                    }
                }
            }
            if (lstRemoveCuocGoiNho == null) return;
            if (lstRemoveCuocGoiNho.Count > 0)
            {
                foreach (DieuHanhTaxi objDHTX in lstRemoveCuocGoiNho)
                {
                    objDHTX.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.TrangThaiKhac ;
                    objDHTX.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThucCuaDienThoai;
                    objDHTX.MaNhanVienDienThoai = g_strUsername;
                    objDHTX.Update_MaNhanVienDienThoai();
                    if (!objDHTX.Update_DienThoai_CuocGoiNho())
                    {
                        new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình xử lý cuộc gọi nhỡ", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                        return;
                    }
                    if (!objDHTX.Update_ChuyenKetThucCuocGoi())
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Có lỗi trong phần lưu vào cơ sở dữ liệu [ChuyenKetThucCuocGoi]", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                        return;
                    }
                    g_lstDienThoai.Remove(objDHTX);
                }
             
                DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep); 

            }
        }
        /// <summary>
        /// Cap nhat thong tin cuôc gọi bị thay đổi
        ///     - Cập nhật số lần chuông kêu khi nhắc máy, hoặc cuộc gọi nhỡ
        ///     - Cập nhật thông tin cuộc gọi của Tông dài nhập mới        
        /// </summary>
        private void CapNhatThongTinCuocGoiBiThayDoi()
        {
            // Nhan thong tin so lan chuong cua cuoc goi nho, va cuoc goi da nhac may
            if (!ThongTinCauHinh.KichHoachTaxiGroupDon)
            {
                if (GetSoLanChuongCuaCacCuocGoi())
                {
                    // gridDienThoai.Refresh();
                    DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep);
                }
            }
            if (CapNhatTHongTinCuocGoiTongDaiGuiSang())
            {
                //gridDienThoai.Refresh();
                DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep); 
            }
             

        }
        /// <summary>
        /// Co noi dung cuoc goi thay doi , tu phai tong dai goi sang
        /// </summary>
        private bool CapNhatTHongTinCuocGoiTongDaiGuiSang()
        {
            bool boolOK = false;

            try
            {
                List<DieuHanhTaxi> lstCuocGoiTongDaiGuiSang = new List<DieuHanhTaxi>();
                lstCuocGoiTongDaiGuiSang = GetAllCuocGoiTongDaiMoiTruyenSang(g_lstCuocGoiDangTheoDoi);
                if (lstCuocGoiTongDaiGuiSang == null) return false;
                if (lstCuocGoiTongDaiGuiSang.Count > 0) //Co cuoc goi TongDai gui sang
                {
                    foreach (DieuHanhTaxi objCuocGoiTongDai in lstCuocGoiTongDaiGuiSang)
                    {
                        if (g_lstDienThoai.Count > 0)
                        {
                            for (int i = 0; i < g_lstDienThoai.Count; i++)
                            {
                                if (objCuocGoiTongDai.ID_DieuHanh == ((DieuHanhTaxi)g_lstDienThoai[i]).ID_DieuHanh)
                                {
                                    g_lstDienThoai[i] = (DieuHanhTaxi)objCuocGoiTongDai;
                                    boolOK = true;// co cuoc goi thay doi
                                    break;
                                }
                            }
                        }
                    }
                }
                return boolOK;//
            }
            catch (Exception ex)
            {
                //  TimerCapturePhone.Stop();
                //  new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);

                return false;
            }
            return false;
        }
        /// <summary>
        /// Voi Cuoc goi nho : TrangThaiCuocGoi=CuocGoiNho=9 AND TrangThaiLenh=KetThucCuaDienThoai=4
        /// Voi cuoc goi co nhac may: TrangThaiCuocGoi= CuocGoiDaNhacMay=7,trangThaiLenh=KhongTruyenDi = 0,
        /// 
        ///     
        /// </summary>
        /// <returns></returns>
        private bool GetSoLanChuongCuaCacCuocGoi()
        {
            bool boolOK = false;

            try
            {
                List<DieuHanhTaxi> lstCuocGoiCoSolanChuong = new List<DieuHanhTaxi>();
                lstCuocGoiCoSolanChuong = GetAllCuocGoiChuaCoSoChuong(g_lstCuocGoiDangTheoDoi);
                if (lstCuocGoiCoSolanChuong == null) return false;
                if (lstCuocGoiCoSolanChuong.Count > 0) // Co cuoc goi nho, cac cuoc goi da nhac may
                {
                    foreach (DieuHanhTaxi objCuocGoiCoSolanChuong in lstCuocGoiCoSolanChuong)
                    {
                        foreach (DieuHanhTaxi objCuocGoiHienTai in g_lstDienThoai)
                        {
                            if (objCuocGoiCoSolanChuong.ID_DieuHanh == objCuocGoiHienTai.ID_DieuHanh)
                            {
                                objCuocGoiHienTai.SoLuotDoChuong = objCuocGoiCoSolanChuong.SoLuotDoChuong;
                                objCuocGoiHienTai.GhiChuDienThoai = objCuocGoiCoSolanChuong.GhiChuDienThoai;
                                boolOK = true;
                                break;
                            }
                        }
                    }
                }
                return boolOK;
            }
            catch (Exception ex)
            {
                //  TimerCapturePhone.Stop(); 
                //  new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);

                return false;
            }
            return false;
        }
        /// <summary>
        /// Lay tat cac cac cuoc goi hien dang co trong TatcaCuocGoiHienHanh
        /// Kiem tra cuoc goi phia DienThoai con ton tai trong TatcaCuocGoiHienHanh
        ///     - Neu khong co thi Remove
        ///     - Neu cô thi de lai
        /// </summary>
        private void XoaCacCuocGoi_TongDaiKetThuc()
        {
            // Lay danh sach cuoc goi hien hanh (phia server)
            try
            {
                List<DieuHanhTaxi> lstDienThoaiServer = new List<DieuHanhTaxi>(); // cuoc dien thoai hien co o server
                List<DieuHanhTaxi> lstDienThoaiNoExist = new List<DieuHanhTaxi>(); // cuoc dien thoai hien tai dang co 

                if (g_lstCuocGoiDangTheoDoi == null)
                {
                    if ((g_lstDienThoai != null) && (g_lstDienThoai.Count > 0))
                    {
                        g_lstDienThoai.Clear();

                        DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep);  
                    }
                    return;
                }
                lstDienThoaiServer = g_lstCuocGoiDangTheoDoi;
                bool boolCocuocGoiKetThuc_TongDai = false;
                if (lstDienThoaiServer != null)
                {

                    if (lstDienThoaiServer.Count > 0) // server con cuoc goi
                    {
                        foreach (DieuHanhTaxi objDHTX_DienThoai in g_lstDienThoai)
                        {
                            bool boolHas = false;
                            foreach (DieuHanhTaxi objDHTX_Server in lstDienThoaiServer)
                            {
                                if (objDHTX_DienThoai.ID_DieuHanh == objDHTX_Server.ID_DieuHanh)
                                {
                                    boolHas = true;
                                    break;
                                }
                            }
                            if (!boolHas)
                            {
                                boolCocuocGoiKetThuc_TongDai = true;
                                lstDienThoaiNoExist.Add(objDHTX_DienThoai);
                            }
                        }
                        foreach (DieuHanhTaxi objDHTX_Delete in lstDienThoaiNoExist)
                        {
                            g_lstDienThoai.Remove(objDHTX_Delete);
                        }
                    }
                    else // khong con cuoc goi nao
                    {
                        if (g_lstDienThoai.Count > 0) // phia dien thoai van con cuoc goi
                        {
                            g_lstDienThoai.Clear();
                            boolCocuocGoiKetThuc_TongDai = true;
                        }
                    }
                }
                else
                {
                    if (g_lstDienThoai.Count > 0) // phia dien thoai van con cuoc goi
                    {
                        g_lstDienThoai.Clear();
                        boolCocuocGoiKetThuc_TongDai = true;
                    }
                }
                if (boolCocuocGoiKetThuc_TongDai)
                {
                    DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep);  
                }
            }
            catch (Exception ex)
            {
                  
            }
        }

        /// <summary>
        /// Ghep them cac cuoc goi moi nhan vao dau cua danh sach g_listDienTHoai
        /// </summary>
        /// <param name="ListOfNewCalls"></param>
        private bool GhepThemCuocGoiMoiNhanVaoDau(List<DieuHanhTaxi> ListOfNewCalls)
        {
            bool boolOK = false;
            List<DieuHanhTaxi> lstTemp = new List<DieuHanhTaxi>();
            for (int i = ListOfNewCalls.Count - 1; i >= 0; i--)
            {
                if (!KiemTraXemCuocGoiDaDuocThemVaoChua((DieuHanhTaxi)ListOfNewCalls[i]))
                {
                    boolOK = true;
                    if (g_lstDienThoai == null) g_lstDienThoai = new List<DieuHanhTaxi>();
                    g_lstDienThoai.Insert(0, (DieuHanhTaxi)ListOfNewCalls[i]);
                }
            }
            return boolOK;

        }

        private bool KiemTraXemCuocGoiDaDuocThemVaoChua(DieuHanhTaxi DHTaxi)
        {
            bool boolOK = false;
            if (g_lstDienThoai == null) return boolOK;
            foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
            {
                if (objDHTX.ID_DieuHanh == DHTaxi.ID_DieuHanh)
                {
                    boolOK = true;
                    break;
                }
            }
            return boolOK;
        }

        #endregion Cac ham lien quan toi Timer Capture Phone


        #endregion Nhan cuoc goi moi co


        #region Validate du lieu



        #endregion Validate du lieu

        #region XU LY CUOC CHUA KET THUC
        /// <summary>
        /// load all cacs cuoc goi chua ket thuc (tat ca khong phai cua minh nua)
        /// </summary>       
        private void LoadAllCuocGoiHienTai()
        {
            DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
            string SQLCondition = "  AND ( KieuCuocGoi=1 OR KieuCuocGoi=7 OR TrangThaiLenh='0'  ) ORDER BY ThoiDiemGoi DESC";
            g_lstDienThoai = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
            DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep); 
        }

        

        #endregion XU LY CUOC CHUA KET THUC


        #region Input du lieu - nhap du lieu va chuyen sang ben tong dai

        private void gridDienThoai_DoubleClick(object sender, EventArgs e)
        {
            gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDienThoai.SelectedItems.Count > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)gridDienThoai.SelectedItems[0]).Position);
                // lua cho dong lua chon dau tien
                
            }
        }
        private void gridDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridDienThoai.SelectedItems.Count > 0)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                        NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)gridDienThoai.SelectedItems[0]).Position);
                }
            }
        }

        /// <summary>
        /// Nhan thong tin cua Dient hoai vien nhap va truyen sang cho tong dai
        /// </summary>
        private void NhapDuLieuVaoTruyenDi(int iRowPosition)
        {
            try
            {                
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)gridDienThoai.GetRow(iRowPosition).DataRow;
                /// Neu la cuoc goi nho thi thoat luon
                if (objDieuHanhTaxi.GhiChuDienThoai.Contains("gọi nhỡ"))
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn không được thay đổi thông tin cuộc gọi nhỡ.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                    return;
                }

                // Khong phai line minh phu trach
                if (!DieuHanhTaxi.CheckLineDuocPhepsuDungMayNay(g_LinesDuocCapPhep, objDieuHanhTaxi.Line ))
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Cuộc gọi này không phải bạn nghe máy.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                    return;
                }

                // check cuocgoi khach hen
                if (objDieuHanhTaxi.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangHen)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    if (!(msgDialog.Show(this, "Bạn có muốn thay đổi thông tin cuộc gọi hẹn không ? ", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString()))
                    { return; }
                }
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)gridDienThoai.SelectedItems[0]).GetRow();

                // Lay lai file anh hien tai

                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                //End - Thu doi mau

                g_boolIsTrungSoDienThoaiDangGiaiQuyen = IsSoDienThoaiDangCoTrangChoGiaiQuyet(objDieuHanhTaxi.PhoneNumber);

                frmDienThoaiInputDataNew frm = new frmDienThoaiInputDataNew(objDieuHanhTaxi, g_boolIsTrungSoDienThoaiDangGiaiQuyen);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objDieuHanhTaxi = frm.GetDieuHanhTaxi;
 
                    objDieuHanhTaxi.MaNhanVienDienThoai = g_strUsername;
                    if (objDieuHanhTaxi.KieuCuocGoi == KieuCuocGoi.GoiKhac  )
                        objDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThucCuaDienThoai;
                    else// thiet lap trang thai lenh                    
                        objDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.DienThoai;// Dien thoai chuyen
                     

                    #region CUOC GOI KHAC 
                    if (objDieuHanhTaxi.KieuCuocGoi == KieuCuocGoi.GoiKhac)
                    {
                        
                        if (!objDieuHanhTaxi.Update_DienThoai_CuocGoiKhac_KetThuc())
                        {
                            MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                            msgDialog.Show(this, "Có lỗi trong phần lưu vào cơ sở dữ liệu [CuocGoiKhac-KetThuc]", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                            return;
                        }                         
                        g_lstDienThoai.Remove(objDieuHanhTaxi); 
                        DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep); 
                        return;
                    }
                    #endregion CUOC GOI KHAC 

                    #region GOI KHIEU NAI

                    else if(objDieuHanhTaxi.KieuCuocGoi == KieuCuocGoi.GoiKhieuNai  )
                    {
                        if (objDieuHanhTaxi.MaVung == "11")
                        {
                            
                            ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
                            objPhanAnh.DienThoai = objDieuHanhTaxi.PhoneNumber;
                            objPhanAnh.TenKhachHang = string.Empty;
                            objPhanAnh.NoiDung = objDieuHanhTaxi.DiaChiDonKhach;
                            objPhanAnh.NhanVienTiepNhan = string.Empty;

                            if (objPhanAnh.InsertCuocGoi(0, 5, 0, objDieuHanhTaxi.ID_DieuHanh)>0)
                            {
                                DieuHanhTaxi.UpdateCuocGoiKhieuNaiKetThuc(objDieuHanhTaxi.ID_DieuHanh, objPhanAnh.NoiDung, objDieuHanhTaxi.MaNhanVienDienThoai); 
                                g_lstDienThoai.Remove(objDieuHanhTaxi);
                                DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep); 
                                gridDienThoai.Refresh();
                                return;
                            }
                            else
                            {
                                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                                msgDialog.Show(this, "Không chuyển được dữ liệu sang Bộ đàm, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                                //tra ve mau cu
                                RowStyle = new GridEXFormatStyle();
                                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                                rowSelect.RowStyle = RowStyle;
                                return;
                            }
                        }
                    }                    
                    #endregion
                    
                    #region CUOC GOI TAXI
                    else  // if (objDieuHanhTaxi.KieuCuocGoi == KieuCuocGoi.GoiTaxi) // La cuoc goi taxi
                    {
                        // cap nhat du lieu va chuyen di

                        if (objDieuHanhTaxi.Update_DienThoai())
                        {
                            for (int i = 0; i < g_lstDienThoai.Count; i++)
                            {
                                if (((DieuHanhTaxi)g_lstDienThoai[i]).ID_DieuHanh == objDieuHanhTaxi.ID_DieuHanh)
                                {
                                    //(DieuHanhTaxi)g_lstDienThoai[i] = objDieuHanhTaxi;
                                    break;
                                }
                            }
                            // Chuyen cuoc goi ket thuc
                            if (objDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.KetThuc)
                            {
                                g_lstDienThoai.Remove(objDieuHanhTaxi);
                                DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep);
                            }
                            gridDienThoai.Refresh();

                        }
                        else
                        {
                            MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                            msgDialog.Show(this, "Không chuyển được dữ liệu sang Bộ đàm, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                            //tra ve mau cu
                            RowStyle = new GridEXFormatStyle();
                            RowStyle.BackColor = System.Drawing.SystemColors.Window;
                            rowSelect.RowStyle = RowStyle;
                            return;
                        }
                    }
                    #endregion CUOC GOI TAXI

                }
                else
                {  //tra ve mau cu
                    RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = System.Drawing.SystemColors.Window;
                    rowSelect.RowStyle = RowStyle;

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Không chuyển được dữ liệu sang Bộ đàm, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                
            }
        }

        private bool IsSoDienThoaiDangCoTrangChoGiaiQuyet(string PhoneNumber)
        {
            if (g_lstDienThoai.Count > 0)
            {
                foreach (DieuHanhTaxi objDH in g_lstDienThoai)
                {
                    if (StringTools.TrimSpace(objDH.PhoneNumber) == StringTools.TrimSpace(PhoneNumber))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
         

        #endregion Input du lieu - nhap du lieu va chuyen sang ben kien

        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Name == "uiTabCuocGoiKetThuc")
            {
                g_boolChuyenTabCuocGoiKetThuc = true;
                //--------------------------LAYOUT-------------------------------------
                loadLayout(gridCuocGoi_KetThuc);
                //--------------------------LAYOUT-------------------------------------
            }
            else
            {
                g_boolChuyenTabCuocGoiKetThuc = false;
                //--------------------------LAYOUT-------------------------------------
                loadLayout(gridDienThoai);
                //--------------------------LAYOUT-------------------------------------
            }
        }


        #region XuLyCacCuocGoi ket thuc

       

        /// <summary>
        /// hàm trả về ds sách cuộc gọi 
        /// </summary>
        /// <param name="linesChoPhep">line của máy này được phép</param>
        /// <param name="soDong">so dòng (row)</param>
        private void LoadCacCuocGoiKetThuc(string linesChoPhep, int soDong)
        {
            try
            {
                gridCuocGoi_KetThuc.DataMember = "lstCuocGoiKetThuc";
                gridCuocGoi_KetThuc.SetDataBinding(DieuHanhTaxi.DIENTHOAI_LayCuocGoiDaGiaiQuyet(linesChoPhep, soDong), "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {

            }
        }


 

        //private void LoadCacCuocGoiKetThuc()
        //{
        //    try
        //    {
        //        DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
        //        List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>(); 
        //        gridCuocGoi_KetThuc.DataMember = "lstCuocGoiKetThuc";
        //        gridCuocGoi_KetThuc.SetDataBinding(objDHTaxi.Get_CuocGoi_KetThucBySoDong(ThongTinCauHinh.SoDongCuocGoiDaGiaiQuyet), "lstCuocGoiKetThuc");
        //    }
        //    catch (Exception ex)
        //    {
        //        //TimerCapturePhone.Stop();
        //        // new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //    }
        //}
        
        #endregion XuLyCacCuocGoi ket thuc

        private void uiCommandBar2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdThayDoiMatKhau")
            {
                new CapNhatThongTinCaNhan().ShowDialog();
            }
            else if (e.Command.Key == "cmdTinhCuoc")
            {
                frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                frm.ShowDialog();
            }
            else if (e.Command.Key == "cmdChenThemCuocGoi")
            {
                frmChenMoiMotCuocDienThoai frm = new frmChenMoiMotCuocDienThoai( this.g_LinesDuocCapPhep,g_TimeServer);
                frm.ShowDialog();
            }
            else if (e.Command.Key == "cmdLogin")
            {
                CheckIn();
            }
            else if (e.Command.Key == "cmdCheckOut")
            {
                // check co dung may cua user dang ngồi không.
                if (ThongTinDangNhap.IsUserPostionTrust (g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
                {
                    if (ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBox().Show(this, "CheckOut thành công, bạn cần bảo người đổi ca checkin luôn.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        statusBar.Panels["TenDangNhap"].Text = " NV điện thoại : ";
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        CheckIn();
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show(this, "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                    }
                  }
                   
                else
                    new MessageBox.MessageBox().Show(this, "Bạn ngồi không đúng vị trí cần ngồi đúng máy bạn đã khai báo vào hệ thống (checkin).", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                // nếu đúng thì cập nhật thời gian checkout.

            }
            else if (e.Command.Key == "cmdChenThemMotCuocGoi")
            {
                new frmChenMoiMotCuocDienThoai(this.g_LinesDuocCapPhep,this.g_TimeServer).ShowDialog();

            } //cmdTraCuuDiaDanh
            else if (e.Command.Key == "cmdTraCuuDiaDanh")
            {
                new frmDMDiaDanh().ShowDialog();

            }
                 
           else if (e.Command.Key == "cmdExit")
                {
                    Application.Exit();
             }

             else if (e.Command.Key == "cmdXeRaHoatDong") //ctrl + 4
             {
                 frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(1);
                 if (frm.ShowDialog() == DialogResult.OK)
                 {

                 }
             }
             else if (e.Command.Key == "cmdXeBaoDiem")//ctrl + 1
             {
                 frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(2);
                 if (frm.ShowDialog() == DialogResult.OK)
                 {

                 }


             }
             else if (e.Command.Key == "cmdXeBaoVe")//ctrl + 2
             {
                 frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(4);
                 if (frm.ShowDialog() == DialogResult.OK)
                 {

                 }
             }
             else if (e.Command.Key == "cmdKiemSoatXe_KiemTraMatLienLac")//ctrl + 3
             {
                 frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(3);
                 if (frm.ShowDialog() == DialogResult.OK)
                 {

                 }
             }
             else if (e.Command.Key == "cmdNoiDungTroGiup")
             {
                 try
                 {
                     string HDSDPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                     HDSDPath = HDSDPath + "\\" + "HDSD.pdf";
                     System.Diagnostics.Process.Start(HDSDPath);
                 }
                 catch (Exception ex)
                 {
                     new MessageBox.MessageBox().Show(this, "File hướng dẫn không tồn tại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                 }
             }
             else if (e.Command.Key == "cmdAbout")
             {
                 new frmAbout().ShowDialog();
             }

             //--------------------------------------Quan Ly Tin Nhan - Phupn
             else if (e.Command.Key == "cmdQuanLyTinNhan_Sub")
             {
                 new Messenger().ShowDialog();
             }
             //else if (e.Command.Key == "cmdGuiTinNhan")
             //{
             //    new SendMessage().ShowDialog();
             //}
             //else if (e.Command.Key == "cmdTinNhanMau")
             //{
             //    new MessageTemplate().ShowDialog();
             //}

             //--------------------------------------LAYOUT - Phupn
             else if (e.Command.Key == "cmdLuuCauHinhHienThi")
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
             else if (e.Command.Key == "cmdMacDinh")
             {
                 if (gridLayout != null)
                 {
                     if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiChoGiaiQuyet")
                     {
                         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhDienThoaiNEWCP_V2));
                         gridLayout.setLayout(resources.GetString("gridEXLayout1.LayoutString"));
                         gridDienThoai.LoadLayout(gridLayout.getLayout(gridDienThoai.GetLayout()));
                     }
                     else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                     {
                         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhDienThoaiNEWCP_V2));
                         gridLayout.setLayout(resources.GetString("gridEXLayout2.LayoutString"));
                         gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                     }
                 }
             }
        }

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int iRowSelect = -1;
            if (keyData == (Keys.Alt | Keys.D1)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 0;

            }
            else if (keyData == (Keys.Alt | Keys.D2)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 1;
            }
            else if (keyData == (Keys.Alt | Keys.D3)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 2;
            }
            else if (keyData == (Keys.Alt | Keys.D4)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 3;
            }
            else if (keyData == (Keys.Alt | Keys.D5)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 4;
            }
            else if (keyData == (Keys.Alt | Keys.D6)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 5;
            }
            else if (keyData == (Keys.Alt | Keys.D7)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 6;
            }
            else if (keyData == (Keys.Alt | Keys.D8)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 7;
            }
            else if (keyData == (Keys.Alt | Keys.D9)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 8;
            }

            else if (keyData == (Keys.Alt | Keys.D0)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 9;
            }

            if (iRowSelect >= 0)
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
                {

                    if (gridDienThoai.RowCount > iRowSelect)
                    {
                        gridDienThoai.Row = iRowSelect;
                        if (g_strUsername.Length <= 0)
                            CheckIn();
                        else
                            NhapDuLieuVaoTruyenDi(iRowSelect);
                       
                    }
                }
                return true;
            }

            if (keyData == (Keys.Shift | Keys.D1))
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex != 0)
                    uiTabCuocGoiDangThucHien.SelectedIndex = 0;
            }
            if (keyData == (Keys.Shift | Keys.D2))
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex != 1)
                    uiTabCuocGoiDangThucHien.SelectedIndex = 1;
            }
            return false;
        }
        #endregion XU LY HOTKEY

        private void gridDienThoai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridCuocGoi_KetThuc_FormattingRow_1(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }


        #region Thanh trang thai

        private void BlinkStatus(int iStatus)
        {
            statusBar.Panels[0].ImageIndex = iStatus;
        }

        private void ViewTrangThaiCacCuocGoiO_StatusBar()
        {
            int iSoCuocGoiChuaChuyenSangTongDai = 0;
            int iSoCuocGoiChuaDonDuocXe = 0;
            if (g_lstDienThoai != null)
            {
                foreach (DieuHanhTaxi objDH in g_lstDienThoai)
                {
                    if (objDH.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.KhongTruyenDi)
                        iSoCuocGoiChuaChuyenSangTongDai += 1;
                    if (objDH.XeNhan.Length > 0)
                        iSoCuocGoiChuaDonDuocXe += 1;

                }
            }
            this.statusBar.Panels[1].Width = 290;
            this.statusBar.Panels[1].Text = "Cuộc gọi chưa chuyển tổng đài : " + iSoCuocGoiChuaChuyenSangTongDai.ToString();
            this.statusBar.Panels[2].Width = 270;
            this.statusBar.Panels[2].Text = "Cuộc gọi chưa đón được khách : " + iSoCuocGoiChuaDonDuocXe.ToString();

        }
        #endregion Thanh trang thai

        private void timerNhayBaoCuocGoiMoi_Tick(object sender, EventArgs e)
        {
            if (g_boolNhayMauKhiCoCuocGoiMoi)
            {

                uiTabCuocGoiChoGiaiQuyet.ImageIndex = 0;
                g_boolNhayMauKhiCoCuocGoiMoi = false;
            }
            else
            {
                uiTabCuocGoiChoGiaiQuyet.ImageIndex = 1;
                g_boolNhayMauKhiCoCuocGoiMoi = true;
            }
            if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
            {
                uiTabCuocGoiChoGiaiQuyet.ImageIndex = -1;
                timerNhayBaoCuocGoiMoi.Enabled = false;

            }
        }

        private void gridDienThoai_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuRigthClick.ShowCustomizeDialog();
            }
        }

        private void mnuRigthClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();

            if (gridDienThoai.SelectedItems.Count <= 0) return;
            #region Them so dien thoai vao db cong ty
            if (e.Command.Key == "cmdThemSoDienThoai")
            {
                // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridDienThoai.SelectedItems[0]).GetRow().DataRow;
               

                if (DanhBaCongTy.GetDanhBa(objDieuHanhTaxi.PhoneNumber).Length > 0)
                {

                    msgDialog.Show(this, "Số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] này đã tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                    return;
                }
                if (msgDialog.Show(this, "Bạn có đồng ý đưa số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] vào danh bạ số điện thoại công ty không?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question) == DialogResult.Yes.ToString())
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy(objDieuHanhTaxi.PhoneNumber, "", objDieuHanhTaxi.DiaChiDonKhach);
                    if (objDanhBaCongTy.Insert())
                    {

                        msgDialog.Show(this, "Thêm mới vào danh bạ công ty thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        msgDialog.Show(this, "Lỗi thêm mới vào danh bạ công ty", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        return;
                    }

                }
            }
            #endregion Them so dien thoai vao db cong ty

            else if (e.Command.Key == "cmdLaiXeBaoDonDuocKhach")
            {
                //// GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();           
                //DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridDienThoaiNhomKhac.SelectedItems[0]).GetRow().DataRow;
                //if (objDieuHanhTaxi != null)
                //{
                //    frmBodamInputData frm = new frmBodamInputData(objDieuHanhTaxi);
                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {
                //        objDieuHanhTaxi = frm.GetDieuHanhTaxi;
                //        if (objDieuHanhTaxi.Update_BoDam())
                //        {

                //            msgDialog.Show(this, "Cập nhật thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                //            objDieuHanhTaxi.Update_ChuyenKetThucCuocGoi(); 
                //            return;
                //        }
                //        else
                //        {
                //            msgDialog.Show(this, "Lỗi cập nhật xe đón", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                //            return;
                //        }
                //    }
                //}
            }
            else if (e.Command.Key == "cmdKhachGoiLaiBaoHoan")
            {
                //// GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();           
                //DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridDienThoaiNhomKhac.SelectedItems[0]).GetRow().DataRow;
                //if (objDieuHanhTaxi != null)
                //{
                //    objDieuHanhTaxi.DiaChiDonKhach = "[KHÁCH HOÃN] - " + objDieuHanhTaxi.DiaChiDonKhach;
                //    objDieuHanhTaxi.LenhDienThoai = "khách hoãn";
                    
                //    if (objDieuHanhTaxi.Update_DienThoai())
                //        {

                //            msgDialog.Show(this, "Cập nhật thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                //            objDieuHanhTaxi.Update_ChuyenKetThucCuocGoi(); 
                //            return;
                //        }
                //        else
                //        {
                //            msgDialog.Show(this, "Lỗi cập nhật  ", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                //            return;
                //        }
                //}

            }
            // View dong cuoc goi ket thuc
            else if (e.Command.Key == "cmdChon20Dong")
            {
                g_SoDong = 20;
                LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
            }
            else if (e.Command.Key == "cmdChon50Dong")
            {
                g_SoDong = 50;
                LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
            }
            else if (e.Command.Key == "cmdChon100Dong")
            {
                g_SoDong = 100;
                LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
            }

        }

        private void gridDienThoai_SizingColumn(object sender, SizingColumnEventArgs e)
        {
           // SaveLayoutGrid(gridDienThoai, "gridDienThoai");
        }

        #region Loc nhung cuoc goi cua chinh nhom minh
        /// <summary>
        /// ham thuc hien chuc nang loc cac cuoc goi cua chinh nhom minh
        /// </summary>
        /// <param name="listCacCuocGois"></param>
        /// <param name="LinesDuocCapPhep"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetNhungCuocGoiCuaNhom(List<DieuHanhTaxi> listCacCuocGois, string LinesDuocCapPhep, out  List<DieuHanhTaxi> listCuocGoiKhongPhaiCuaNhom )
        {
            List<DieuHanhTaxi> listNhungCuocGoiCuaNhom = new List<DieuHanhTaxi>();
            List<DieuHanhTaxi> _listCuocGoiKhongPhaiCuaNhom = new List<DieuHanhTaxi>();
            if ((listCacCuocGois != null) && (listCacCuocGois.Count > 0))
            {
                foreach (DieuHanhTaxi objDHTX in listCacCuocGois)
                {
                    if(DieuHanhTaxi.CheckLineDuocPhepsuDungMayNay(LinesDuocCapPhep ,objDHTX .Line ))
                    {
                        listNhungCuocGoiCuaNhom.Add (objDHTX );
                    }
                    else 
                    {
                        _listCuocGoiKhongPhaiCuaNhom.Add(objDHTX);
                    }
                }
            }
            listCuocGoiKhongPhaiCuaNhom = _listCuocGoiKhongPhaiCuaNhom;
            return listNhungCuocGoiCuaNhom ;
        }
        /// <summary>
        /// hien thi thong tin len luoi
        /// hien thi luoi cuoc goi cua nhom, nhung cuoc goi khong phai cua nhom. 
        /// </summary>
        /// <param name="listDienThoai"></param>
        /// <param name="LinesDuocCapPhep"></param>
        private void DisplayLenGrid(List<DieuHanhTaxi> listDienThoai, string LinesDuocCapPhep)
        {
            // lay lua chon dong hien tai
            if (gridDienThoai.Row >= 0)
                g_rowIndexSelected_CuocGoiCuaNhom = gridDienThoai.Row; 
           List<DieuHanhTaxi> listNhungCuocGoiCuaNhom = new List<DieuHanhTaxi>();
           List<DieuHanhTaxi> listCuocGoiKhongPhaiCuaNhom = new List<DieuHanhTaxi>();

           listNhungCuocGoiCuaNhom = this.GetNhungCuocGoiCuaNhom(listDienThoai,  LinesDuocCapPhep, out listCuocGoiKhongPhaiCuaNhom);
           
           gridDienThoai.DataSource = null;
           gridDienThoai.DataMember = "ListDienThoai";
           gridDienThoai.SetDataBinding(listNhungCuocGoiCuaNhom, "ListDienThoai");
            
            

            // thiet lap lua chon
           if ((g_rowIndexSelected_CuocGoiCuaNhom >= 0) && (gridDienThoai.RowCount > 0))
           {
               while (g_rowIndexSelected_CuocGoiCuaNhom > gridDienThoai.RowCount) g_rowIndexSelected_CuocGoiCuaNhom--;
               gridDienThoai.Row = g_rowIndexSelected_CuocGoiCuaNhom;
           }
           
        }
        #endregion 

        private void gridDienThoaiNhomKhac_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        /// <summary>
        /// xu ly toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiCommandBar1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdTinhTienCuoc")
            {
                 
                    frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                    frm.ShowDialog();
                 
            }
            else if (e.Command.Key == "cmdTraCuuVeHuy")
            {
               new frmTraCuu().ShowDialog();
            }
            else if (e.Command.Key == "cmdTongDai1080")
            {
                new frmDMDiaDanh().ShowDialog();
            }
            else if (e.Command.Key == "cmdChenMotCuocGoi")
            {
                new frmChenMoiMotCuocDienThoai(this.g_LinesDuocCapPhep, g_TimeServer).ShowDialog();
            }
            
             
        }
 

    }
}