using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.BanGiaGoc;
using Taxi.Business;
using Taxi.GUI;
using Taxi.Utils;
using Taxi.Business.DM;
using System.Globalization;
namespace Taxi.GUI
{
    public partial class frmNhapCSKHNhatKyThueBao : Form
    {
        private int g_LoaixeID = 0;
        private int g_Chieu = 1;
        private bool g_TuyenKhac = false;
        private bool g_IsQuanToan = false;
        private string g_TuyenDuongID = "";
        private int g_IDThueBao = 0;
        private bool g_IsAddNew = true;
        private bool g_IsSaved = false; // ddax 
        private bool g_CoThongTinTraKhach = false;
        private bool g_DaCoKmTra = false;
         // 
        private DateTime g_dateThoiGianNhap;
        private Dulieudauvaotinhtien Dulieudauvaotinhtienobj ;
        
        public frmNhapCSKHNhatKyThueBao()
        {
            InitializeComponent();
            g_IsAddNew = true;
            // thiet lap thoi din
           
        }
        /// <summary>
        /// load thông tin nhật ký thuê bao có ID = IDThueBao
        /// </summary>
        /// <param name="IDThueBao"></param>
        public frmNhapCSKHNhatKyThueBao(int IDThueBao)
        {
            InitializeComponent();
            g_IsAddNew = false;
            g_IDThueBao = IDThueBao;
           
        }
        public frmNhapCSKHNhatKyThueBao(int IDThueBao, bool DaCoKmTra)
        {
            InitializeComponent();
            g_IsAddNew = false;
            g_IDThueBao = IDThueBao;
            g_DaCoKmTra = DaCoKmTra;
        } 
        private void frmNhapNhatKyThueBao_Load(object sender, EventArgs e)
        {
            if (ThongTinDangNhap.USER_ID.Length <= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn phải đăng nhập để thực hiện nhập thông tin thuê bao.");
                this.Close();
            }

           KhoiTaoNhapMoi(); btnTinhToan.Visible = false;
            if (g_IsAddNew)
            {
                
                HienThiControls_CoThongTinTra(!g_IsAddNew);
                calDon.Value = new DateTime(g_dateThoiGianNhap.Year, g_dateThoiGianNhap.Month, g_dateThoiGianNhap.Day, g_dateThoiGianNhap.Hour, g_dateThoiGianNhap.Minute, 0);
                calTra.Value = new DateTime(g_dateThoiGianNhap.Year, g_dateThoiGianNhap.Month, g_dateThoiGianNhap.Day, 0, 0, 0);
                txtNhanVien.Text = ThongTinDangNhap.USER_ID;
            }
            else
            {
                NhatkyThuebao objThueBao = new NhatkyThuebao();
                objThueBao = NhatkyThuebao.Selectone(g_IDThueBao);
                // lay thongtin
                if (!g_DaCoKmTra)
                {

                   
                    if (objThueBao != null)
                    {

                        txtNgayThangNhap.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", objThueBao.ThoiDiem);

                        txtSoHieuXe.Text = objThueBao.SoHieuXe; txtSoHieuXe.Enabled = false;
                        if (objThueBao.LoaiXeID > 0)
                            cboLoaiXe.SelectedValue = objThueBao.LoaiXeID;
                        else objThueBao.LoaiXeID = 01;

                        if (StringTools.TrimSpace(objThueBao.TuyenDuongID) == "")
                        {
                            txtTuyenduong.Text = objThueBao.TenTuyenDuong;
                            cboTuyenDuong.Visible = false;
                            radKhac.Checked = true;

                        }
                        else
                        {
                            cboTuyenDuong.Visible = true;
                            cboTuyenDuong.SelectedValue = objThueBao.TuyenDuongID;
                        }
                        txtGiaThueBao.Text = objThueBao.GiaThueBao;
                        calDon.Value = objThueBao.ThoiGianDon;
                        txtKmDon.Text = objThueBao.KmDon.ToString();
                        txtNhanVien.Text = objThueBao.MaNhanVienNhap;
                        txtGhiChu.Text = objThueBao.GhiChu;
                        txtDienThoai.Text = objThueBao.SoDienThoai;
                        // set mac dinh thoi gian cho
                        calTra.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                        if (objThueBao.Chieu == 2) radioHaiChieu.Checked = true;
                        else radioHaiChieu.Checked = false;

                    }
                    HienThiControls_CoThongTinTra(g_IsAddNew);
                    // dat focus vao chkConThongTinTra
                    chkCoDonTraKhach.Focus();
                }
                else  /// da co du lieu km tra
                {
                    if (objThueBao != null)
                    {
                        cboTuyenDuong.DataSource = null;
                        LoadTuyenDuong(0);

                        txtNgayThangNhap.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", objThueBao.ThoiDiem);

                        txtSoHieuXe.Text = objThueBao.SoHieuXe; txtSoHieuXe.Enabled = true;
                        if (objThueBao.LoaiXeID > 0)
                            cboLoaiXe.SelectedValue = objThueBao.LoaiXeID;
                        else objThueBao.LoaiXeID = 01;

                        if (StringTools.TrimSpace(objThueBao.TuyenDuongID) == "")
                        {
                            txtTuyenduong.Text = objThueBao.TenTuyenDuong;
                            cboTuyenDuong.Visible = false;
                            radKhac.Checked = true;

                        }
                        else
                        {
                            cboTuyenDuong.Visible = true;
                            cboTuyenDuong.SelectedValue = objThueBao.TuyenDuongID;
                        }
                        txtNhanVien.Text = objThueBao.MaNhanVienNhap;
                        txtGiaThueBao.Text = objThueBao.GiaThueBao;
                        calDon.Value = objThueBao.ThoiGianDon;
                        txtKmDon.Text = objThueBao.KmDon.ToString();

                        chkCoDonTraKhach.Checked = true;
                        // set mac dinh thoi gian cho
                        calTra.Value = objThueBao.ThoiGianTra;
                        txtKmTra.Text = objThueBao.KmTra.ToString();
                        txtDongHoTien.Text = objThueBao.DongHoTien.ToString();

                        txtKmThucDi.Text = objThueBao.KmThucDi.ToString();
                        txtPhuTroiLuu.Text = objThueBao.PhuTroi;
                        txtThanhTienLuu.Text = objThueBao.TienThucThu.ToString();
                        txtGhiChu.Text = objThueBao.GhiChu;
                        txtDienThoai.Text = objThueBao.SoDienThoai;
                        if (objThueBao.Chieu == 2) radioHaiChieu.Checked = true;
                        else radioHaiChieu.Checked = false;

                        calTra.Enabled = false;
                        cboTrangThai.Focus();

                        // thiết lập thông tin cskh
                        if (objThueBao.CSKH_TrangThaiGoi ==   1)
                        {
                            cboTrangThai.SelectedIndex = 0;
                        }
                        else if (objThueBao.CSKH_TrangThaiGoi == 2)
                        {
                            cboTrangThai.SelectedIndex = 1;
                        }
                        else if (objThueBao.CSKH_TrangThaiGoi == 3)
                        {
                            cboTrangThai.SelectedIndex = 2;
                        }
                        else if (objThueBao.CSKH_TrangThaiGoi == 9)
                        {
                            cboTrangThai.SelectedIndex = 3;
                        }

                        txtGhiChuCS.Text = objThueBao.CSKH_GhiChu;

                        // thực hiện gọi điện
                    }
                    

                }
            }
        }

        private void KhoiTaoNhapMoi()
        {

            g_dateThoiGianNhap = DateTime.Now;
            txtNgayThangNhap.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", g_dateThoiGianNhap);

            //if (!g_IsAddNew) LoadTuyenDuong(0);
            //else LoadTuyenDuong(1);

            if (radNgoaiTinh.Checked)
            {
                LoadTuyenDuong(2);
            }
            else if (radNgoaiThanh.Checked)
            {
                LoadTuyenDuong(1);
            }

            LoadLoaiXe();
            
            btnTinhToan.Enabled = false;
            if (cboTuyenDuong.SelectedValue != null)
            {
                g_TuyenDuongID = cboTuyenDuong.SelectedValue.ToString();
            }
            lblChonKhac.Visible = false;
            btnTinhToan.Visible = false;
            txtTuyenduong.Text = "";
            txtGiaThueBao.Text = "";
            txtKmDon.Text = "";
            txtKmTra.Text = "";
            txtPhuTroi.Text = "";
            txtPhuTroiLuu.Text = "";
            txtThanhTien.Text = "";
            txtThanhTienLuu.Text = "";
            txtSoHieuXe.Text = "";
            txtDongHoTien.Text = "";
            txtKmThucDi.Text = "";
            lblGioTinh.Text = "";
            lblKmDi.Text = "";
            txtSoHieuXe.Focus();
            txtNhanVien.Text = ThongTinDangNhap.USER_ID;
            txtGhiChu.Text = "";
            txtDienThoai.Text = ""; 
            // thông tin trạng thái gọi
            
        }
         
        /// <summary>
        /// 1: Bạn phải nhập số hiệu xe.
        //2: Bạn chưa chọn loại xe.
        //3: Bạn chưa chọn tuyến đường.
        //4: Bạn chưa nhập giá thuê bao.
        //5: Km trả khách phải lớn hơn Km đón khách
        //6: Thời gian trả khách phải lớn hơn thời gian đón khách.
        //7: Bạn nhập đồng hồ tiền.
        //8: Bạn phải nhập Km thực đi.
        // 9: Bạn phải nhập Km đón khách.
        // 10 : Bạn phải nhập Km trả khách
        // 11 : Bạn phải nhập số Km, giờ phụ trội. Không có nhập 0.
        // 12 : Bạn phải nhập tiền thực thu.
        // Hàm validate form và trả về mã lỗi
        /// </summary>
        /// <returns></returns>
        ///  
        ///  Is TinhToan = true thi valite cho nut tinh toan.
        ///  Is false thi validte cho nut luu
        /// 
        private int ValidateForm(bool NoKmTra,bool IsTinhToan)
        {
            string SoHieuXe = StringTools.TrimSpace(txtSoHieuXe.Text );
            if (SoHieuXe.Length < 3) return 1;
            if (cboLoaiXe.SelectedIndex <  0) return 2;
            if (radKhac.Checked)
            {
                if (StringTools.TrimSpace(txtTuyenduong.Text).Length <= 0) return 3;
            }
            else if (cboTuyenDuong.SelectedIndex < 0) return 3;
            // Gia thue bao
            if (StringTools.TrimSpace(txtGiaThueBao.Text).Length <= 0) return 4;
            // Km trả khách
            if (StringTools.TrimSpace(txtKmDon.Text).Length <= 0) return 9;
            long KmDon = Convert.ToUInt32(txtKmDon.Text);      
            if (KmDon <= 0) return 9;

            if (StringTools.TrimSpace(txtNhanVien.Text).Length <= 0) return 13; // yêu càu nhạp nhân viên 

            if (NoKmTra)
            {
                if (StringTools.TrimSpace(txtKmTra.Text).Length <= 0) return 10;
                long KmTra = Convert.ToUInt32(txtKmTra.Text);
                if (chkCoDonTraKhach.Checked)
                {
                    if (KmTra <= 0) return 10;
                    if (KmTra <= KmDon) return 5;

                    if (calTra.Value.CompareTo(calDon.Value) <= 0) return 6;
                }

                if (StringTools.TrimSpace(txtDongHoTien.Text).Length <= 0) return 7;
                if (StringTools.TrimSpace(txtKmThucDi.Text).Length <= 0) return 8;            
               
            }
            if (  IsTinhToan)
            {
               //  if (StringTools.TrimSpace(txtPhuTroiLuu.Text).Length <= 0) return 11;
                 if (StringTools.TrimSpace(txtThanhTienLuu.Text).Length <= 0) return 12;
            }
            return 0;
        }
        /// <summary>
        /// 1: Bạn phải nhập số hiệu xe.
        //2: Bạn chưa chọn loại xe.
        //3: Bạn chưa chọn tuyến đường.
        //4: Bạn chưa nhập giá thuê bao.
        //5: Km trả khách phải lớn hơn Km đón khách
        //6: Giờ trả khách phải lớn hơn giờ đón khách.
        //7: Bạn nhập đồng hồ tiền.
        //8: Bạn phải nhập Km thực đi.
        // 9: Bạn phải nhập Km đón khách.
        // 10 : Bạn phải nhập Km trả khách
        // 11 : Bạn phải nhập số Km, giờ phụ trội. Không có nhập 0.
        // 12 : Bạn phải nhập tiền thực thu.
        // Hàm hiển thỉ lỗi
        /// </summary>
        /// <returns></returns>
        private void DisplayMessage(int ErrorCode)
        {
            string strMessage = "";
            switch (ErrorCode)
            {
                case 1: { strMessage = "Bạn phải nhập số hiệu xe."; txtSoHieuXe.Focus(); break; }
                case 2: { strMessage = "Bạn chưa chọn loại xe."; cboLoaiXe.Focus(); break; }
                case 3: { strMessage = "Bạn chưa chọn tuyến đường."; txtTuyenduong.Focus();   break; }
                case 4: { strMessage = "Bạn chưa nhập giá thuê bao."; txtGiaThueBao.Focus(); break; }
                case 5: { strMessage = "Km trả khách phải lớn hơn Km đón khách."; txtKmDon.Focus(); break; }
                case 6: { strMessage = "Giờ trả khách phải lớn hơn giờ đón khách."; txtKmTra.Focus(); break; }
                case 7: { strMessage = "Bạn nhập đồng hồ tiền."; txtDongHoTien.Focus(); break; }
                case 8: { strMessage = "Bạn phải nhập Km thực đi."; txtKmThucDi.Focus(); break; }
                case 9: { strMessage = "Bạn phải nhập Km đón khách."; txtKmDon.Focus(); break; }
                case 10: { strMessage = "Bạn phải nhập Km trả khách."; txtKmTra.Focus(); break; }
                case 11: { strMessage = "Bạn phải nhập số Km, giờ phụ trội."; txtPhuTroiLuu.Focus(); break; }
                case 12: { strMessage = "Bạn phải nhập tiền thực thu."; txtThanhTienLuu.Focus(); break; }
                case 13: { strMessage = "Bạn phải nhập thông tin người nhập"; txtNhanVien.Focus(); break; }

            }
            lblThongBao.Visible = true;
            if (ErrorCode == 0)
                lblThongBao.Visible = false;
            else
            {
                lblThongBao.Text = strMessage;
            }
        }
        /// <summary>
        /// ẩn hiện thông tin controls khi có đủ thông tin trả khách
        /// </summary>
        /// <param name="Visible"></param>
        private void HienThiControls_CoThongTinTra(bool Enable)
        {

            calTra.Enabled = Enable;
            txtKmTra.Enabled = Enable;
            txtDongHoTien.Enabled = Enable;
            txtKmThucDi.Enabled = Enable;
            btnTinhToan.Enabled = Enable;
            txtPhuTroiLuu.Enabled = Enable;
            txtThanhTienLuu.Enabled = Enable;
            //txtGhiChu.Enabled = Enable;

        }

        private void chkCoDonTraKhach_CheckedChanged(object sender, EventArgs e)
        {
            btnTinhToan.Visible = chkCoDonTraKhach.Checked;
            btnTinhToan.Enabled = true;  
            g_CoThongTinTraKhach = chkCoDonTraKhach.Checked;
            HienThiControls_CoThongTinTra(chkCoDonTraKhach.Checked);
            if (calTra.Value.Hour == 0 && calTra.Value.Minute == 0)
            {
                calTra.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            }

        }
        public void LoadTuyenDuong(int MaTuyenDuong)
        {
            int Kieutuyen;
           
            Taxi.Business.BanGiaGoc.TuyenDuong TuyendDuongcontrol = new Taxi.Business.BanGiaGoc.TuyenDuong();
            DataTable dt = TuyendDuongcontrol.TableTuyenDuong(MaTuyenDuong);

            
            cboTuyenDuong.DisplayMember = "TenTuyenDuong";
            cboTuyenDuong.ValueMember = "TuyenDuongID";
            cboTuyenDuong.DataSource = dt;
        }
        /// <summary>
        /// ham tra ve ds loai xe
        /// </summary>
        public void LoadLoaiXe()
        {
            Taxi.Business.DM.LoaiXe LoaiXecontrol = new Taxi.Business.DM.LoaiXe();
            DataTable dt = LoaiXecontrol.GetAll();
            cboLoaiXe.DataSource = dt;
            cboLoaiXe.DisplayMember = "TenLoaiXe";
            cboLoaiXe.ValueMember = "LoaiXeID";

        }
       
         
        public void LoadGiacuoc(bool IsQuanToan, int LoaixeID, string TuyenDuongID)
        {
           
                   Dulieudauvaotinhtien Dulieudauvaotinhtiencontrol = new Dulieudauvaotinhtien();
                   Dulieudauvaotinhtienobj = Dulieudauvaotinhtiencontrol.Selectone(IsQuanToan,TuyenDuongID, LoaixeID);
                     if (Dulieudauvaotinhtienobj != null)
                     {
                          
                         if (radMotChieu.Checked == true)
                         {
                             txtGiaThueBao.Text = Dulieudauvaotinhtienobj.GiaThueBao1Chieu();
                         }
                         else if (radioHaiChieu.Checked == true)
                         {
                             txtGiaThueBao.Text = Dulieudauvaotinhtienobj.GiaThueBao2Chieu();
                         }
                     }
                     else
                     {
                         txtGiaThueBao.Text = "";
                     }            
        }
         
         
        public bool Checkvalue()
        {
            try
            {
                int KMtroi;
                DateTime Don = Convert.ToDateTime(calDon.Text);
                DateTime tra = Convert.ToDateTime(calTra.Text);
                if (txtKmTra.Text == "" || txtKmTra.Text == null)
                {  }
                else
                {
                    KMtroi = Convert.ToInt32(txtKmTra.Text);
                    double TIen = Convert.ToDouble(txtThanhTienLuu.Text);
                }
                KMtroi=  Convert.ToInt32(txtKmDon.Text);
              //  Ngay=  Convert.ToDateTime(calTra.Text);
                
                return true;
            }
            catch 
            {
                return false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int ErrorCode = 0;

            
            ErrorCode = ValidateForm(chkCoDonTraKhach.Checked ,btnTinhToan.Visible);
            if (ErrorCode > 0) { DisplayMessage(ErrorCode); return; }
            

            int DongHoTien = 0;
               try
                {

            #region THEM MỚI
                    if (g_IsAddNew)
                    {
                        //@ThoiDiem DateTime,
                        //@SoHieuXe varchar(4),
                        //@TenLaiXe nvarchar(50),

                        //@TuyenDuongID char(5),
                        //@TenTuyenDuong nvarchar(50),
                        //@Chieu int,
                        //@ThoiGianDon DateTime,
                        //@KmDon int,
                        //@ThoiGianTra DateTime,
                        //@KmTra int,
                        //@KmThucDi float, 
                        //@DongHoTien int,
                        //@PhuTroi  nvarchar(50),
                        //@TienThucThu float,
                        //@MaNhanVienNhap nvarchar(50),
                        //@GhiChu nvarchar(50)

                        // Nhập tối thiểu


                        // Nhập 

                        NhatkyThuebao objThueBao = new NhatkyThuebao();
                        objThueBao.ThoiDiem = g_dateThoiGianNhap;
                        objThueBao.SoHieuXe = txtSoHieuXe.Text;
                        objThueBao.TenLaiXe = "";
                        if (radKhac.Checked == true)
                        {
                            objThueBao.TenTuyenDuong = txtTuyenduong.Text;
                            objThueBao.TuyenDuongID = "";
                        }
                        else
                        {
                            objThueBao.TenTuyenDuong = cboTuyenDuong.Text;
                            objThueBao.TuyenDuongID = cboTuyenDuong.SelectedValue.ToString();
                        }
                        if (radioHaiChieu.Checked)
                            objThueBao.Chieu = 2;
                        else objThueBao.Chieu = 1;

                        objThueBao.ThoiGianDon = calDon.Value;
                        objThueBao.KmDon = Convert.ToInt32(txtKmDon.Text);
                        objThueBao.MaNhanVienNhap = StringTools.TrimSpace(txtNhanVien.Text);
                        objThueBao.LoaiXeID = int.Parse(cboLoaiXe.SelectedValue.ToString());
                        objThueBao.GiaThueBao = StringTools.TrimSpace(txtGiaThueBao.Text);
                        objThueBao.GhiChu = txtGhiChu.Text;
                        if (!g_CoThongTinTraKhach)
                        {
                            objThueBao.ThoiGianTra = new DateTime(1900, 01, 01);
                            objThueBao.KmTra = -1;
                            objThueBao.TienThucThu = -1;
                            objThueBao.KmThucDi = -1;
                            objThueBao.DongHoTien = -1;
                            
                            objThueBao.PhuTroi = "";
                        }
                        else
                        {
                            objThueBao.ThoiGianTra = calTra.Value;
                            objThueBao.KmTra = Convert.ToInt32(txtKmTra.Text);
                            objThueBao.TienThucThu = Convert.ToDouble(txtThanhTienLuu.Text);
                            objThueBao.KmThucDi = Convert.ToInt32(txtKmThucDi.Text);
                            DongHoTien = Convert.ToInt32(txtDongHoTien.Text);
                            objThueBao.DongHoTien = DongHoTien;
                           
                            objThueBao.PhuTroi = txtPhuTroiLuu.Text;
                        }
                        objThueBao.SoDienThoai = StringTools.TrimSpace(txtDienThoai.Text);
                        int so = objThueBao.Insert(objThueBao);
                        if (so <= 0)
                        {                           
                     
                            new Taxi.MessageBox.MessageBoxBA().Show("Nhập mới bị lỗi.");
                            return;
                        }
                      
                    }
#endregion THEM MỚI
                    else
                    {           
            #region UPDATE
                        NhatkyThuebao objThueBao = new NhatkyThuebao();
                        objThueBao.ID = g_IDThueBao;
                        objThueBao.ThoiDiem = g_dateThoiGianNhap;
                        objThueBao.SoHieuXe = txtSoHieuXe.Text;
                        objThueBao.TenLaiXe = "";
                        if (radKhac.Checked == true)
                        {
                            objThueBao.TenTuyenDuong = txtTuyenduong.Text;
                            objThueBao.TuyenDuongID = "";
                        }
                        else
                        {
                            objThueBao.TenTuyenDuong = cboTuyenDuong.Text;
                            objThueBao.TuyenDuongID = cboTuyenDuong.SelectedValue.ToString();
                        }
                        if (radioHaiChieu.Checked)
                            objThueBao.Chieu = 2;
                        else objThueBao.Chieu = 1;

                        objThueBao.ThoiGianDon = calDon.Value;
                        objThueBao.KmDon = Convert.ToInt32(txtKmDon.Text);
                        objThueBao.MaNhanVienNhap = StringTools.TrimSpace(txtNhanVien.Text);
                        objThueBao.LoaiXeID = int.Parse(cboLoaiXe.SelectedValue.ToString());
                        objThueBao.GiaThueBao = StringTools.TrimSpace(txtGiaThueBao.Text);
                        objThueBao.GhiChu = txtGhiChu.Text;
                        if (!g_CoThongTinTraKhach)
                        {
                            objThueBao.ThoiGianTra = new DateTime(1900, 01, 01);
                            objThueBao.KmTra = -1;
                            objThueBao.TienThucThu = -1;
                            objThueBao.KmThucDi = -1;
                            objThueBao.DongHoTien = -1;
                             
                            objThueBao.PhuTroi = "";
                        }
                        else
                        {
                            objThueBao.ThoiGianTra = calTra.Value;
                            objThueBao.KmTra = Convert.ToInt32(txtKmTra.Text);
                            objThueBao.TienThucThu = Convert.ToDouble(txtThanhTienLuu.Text);
                            objThueBao.KmThucDi = Convert.ToInt32(txtKmThucDi.Text);
                            DongHoTien = Convert.ToInt32(txtDongHoTien.Text);
                            objThueBao.DongHoTien = DongHoTien;
                            
                            objThueBao.PhuTroi = txtPhuTroiLuu.Text;
                            if (objThueBao.KmThucDi <= 0 || objThueBao.KmTra <= 0)
                            {
                                new Taxi.MessageBox.MessageBoxBA().Show("Có lỗi nhập dữ liệu. Bạn cần kiểm tra lại");
                                return;
                            }
                        }

                        objThueBao.SoDienThoai = StringTools.TrimSpace(txtDienThoai.Text);
                        int so = objThueBao.Update(objThueBao);
                        if (so <= 0)
                        {
                         
                            new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật không thành công.Bạn cần kiểm tra lại dữ liệu nhập.");
                            return;
                        }

                    #endregion UPDATE
                   }
                   g_IsSaved = true;
                   this.Close();
                }
                catch
                {
                    lblThongBao.Text ="Có lỗi nhập dữ liệu vào";
                }
             
             
        }

        private void btnLuuVaTiep_Click(object sender, EventArgs e)
        { 
            try
            {
                 // validate thong tin
                 byte trangThaiCuocGoi  = 0;
                 try
                 { 

                     string textSelect = cboTrangThai.Text;
                     if(textSelect == "Gọi thành công")
                     {
                         trangThaiCuocGoi = 1;
                     }
                     else if(textSelect == "Gọi không nghe máy")
                     {
                         trangThaiCuocGoi = 2;
                     }
                     else if(textSelect == "Không liên lạc được")
                     {
                         trangThaiCuocGoi = 3;
                     }
                     else if(textSelect == "Khác")
                     {
                         trangThaiCuocGoi = 9;
                     } 
                 }
                 catch (Exception ex)
                 {
                     trangThaiCuocGoi = 0;
                 }

                 if (trangThaiCuocGoi == 0)
                 {
                     new Taxi.MessageBox.MessageBoxBA().Show("Bạn phải chọn thông tin xử lý cuộc gọi.");
                     return;
                 }
                 // lấy thông tin để lưu.
                // 0: Chưa gọi, 1 : Gọi thành công, 2: Khong nghe máy, 3: Gọi không liên lạc được  9:Khác

                 try
                 {
                     if (NhatkyThuebao.GhiNhanThucHienGoi(g_IDThueBao, ThongTinDangNhap.USER_ID, StringTools.TrimSpace(txtGhiChuCS.Text), trangThaiCuocGoi, chkKetThucCSKH.Checked))
                     {
                         new Taxi.MessageBox.MessageBoxBA().Show("Nhập thông tin CSKH thành công.");
                     }
                     else
                     {
                         new Taxi.MessageBox.MessageBoxBA().Show(this, "Nhập thông tin CSKH bị LỖI.", "Thông bao lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                     }
                 }
                 catch (Exception ex)
                 {
                     new Taxi.MessageBox.MessageBoxBA().Show(ex.Message);
                 }
                 this.Close();
            }
            catch
            {
                lblThongBao.Text = "Có lỗi nhập dữ liệu vào";
            } 
        }

        private void btnDong_Click(object sender, EventArgs e)
        {             
            this.Close();
          
        }

        private void calDon_ValueChanged(object sender, EventArgs e)
        {

        }  

       

    }
}