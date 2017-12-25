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
    public partial class frmNhapNhatKyThueBao : Form
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
        
        public frmNhapNhatKyThueBao()
        {
            InitializeComponent();
            g_IsAddNew = true;
            // thiet lap thoi din
           
        }
        /// <summary>
        /// load thông tin nhật ký thuê bao có ID = IDThueBao
        /// </summary>
        /// <param name="IDThueBao"></param>
        public frmNhapNhatKyThueBao(int IDThueBao)
        {
            InitializeComponent();
            g_IsAddNew = false;
            g_IDThueBao = IDThueBao;
           
        }
        public frmNhapNhatKyThueBao(int IDThueBao,bool DaCoKmTra)
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
                        if (objThueBao.Chieu == 2) radioHaiChieu.Checked = true;
                        else radioHaiChieu.Checked = false;
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
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
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
       

        private void radKhac_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radKhac.Checked)
            {
                txtGiaThueBao.Text = null;
                cboTuyenDuong.Visible = false;
                txtTuyenduong.Visible = true;
                btnTinhToan.Enabled = false;
                g_TuyenKhac = radKhac.Checked;
                lblChonKhac.Visible = true;
            }
            else cboTuyenDuong.Visible = true;
        //    cboTuyenDuong.Items.Clear();
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            btnTinhToan.Visible = !radKhac.Checked;
        }

        private void radNgoaiThanh_CheckedChanged(object sender, EventArgs e)
        {
            if (radNgoaiThanh.Checked)
            {
                txtTuyenduong.Visible = false;
                lblChonKhac.Visible = false;
                LoadTuyenDuong(1);
                  btnLuu.Enabled = true;
            }
            
        }
        private void radNgoaiTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (radNgoaiTinh.Checked)
            {
                txtTuyenduong.Visible = false;
                lblChonKhac.Visible = false;
                LoadTuyenDuong(2);
                  btnLuu.Enabled = true;
            }

        }
        private void txtSoHieuXe_TextChanged(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(txtSoHieuXe.Text);
            if (SoHieuXe.Length == 3)
            {
                if (!Xe.KiemTraTonTaiCuaSoHieuXe(SoHieuXe))
                {
                   new Taxi.MessageBox.MessageBoxBA().Show("Xe không tồn tại (không có trong danh sách xe). Bạn yêu cầu quản trị nhập số hiệu xe.");
                    txtSoHieuXe.Focus();
                    return;
                }
                Xe objXe = new Xe();
                objXe = objXe.GetChiTietXe(SoHieuXe);
                if (objXe.LoaiXeID > 0)
                    cboLoaiXe.SelectedValue = objXe.LoaiXeID;
                btnLuu.Enabled = true;
            }
        }
        private void txtSoHieuXe_Leave(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(txtSoHieuXe.Text);
            if (SoHieuXe.Length < 3)
            {
                txtSoHieuXe.Focus();
            }
            else
            {
                if (!Xe.KiemTraTonTaiCuaSoHieuXe(SoHieuXe))
                { txtSoHieuXe.Focus(); }
            }
        } 

        private void radMotChieu_CheckedChanged(object sender, EventArgs e)
        {
             btnLuu.Enabled = true;
        }
        private void radioHaiChieu_CheckedChanged(object sender, EventArgs e)
        {
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            if (radMotChieu.Checked)
                g_Chieu = 1;
            else g_Chieu = 2;
            if (!radKhac.Checked)
            { 
                if ((g_LoaixeID > 0) & g_TuyenDuongID.Length > 0)
                {
                    this.LoadGiacuoc(g_IsQuanToan, g_LoaixeID, g_TuyenDuongID);
                }
            }
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
         

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
             
            int ErrorCode = 0;
            ErrorCode = ValidateForm(false,false );
            if (ErrorCode > 0) {DisplayMessage(ErrorCode); return;}

            
            try
            {
                double Tientroi = 0;
                double TienTra = 0;

                //IFormatProvider culture = new CultureInfo("vi-VN", true);
                //DateTime GioDon = DateTime.Parse(calTra.Value.ToString (), culture, DateTimeStyles.NoCurrentDateDefault);

                //Khoảng thời gian khách đi
                TimeSpan timeThoiGianChuyenDi = calTra.Value - calDon.Value;

                 
                string TextTroi = "";

                 
                VuotGioQuyDinhBL VuotGioQuyDinhControl = new VuotGioQuyDinhBL();
                VuotGioQuyDinhControl = VuotGioQuyDinhControl.Selectone(g_LoaixeID);

                if (VuotGioQuyDinhControl == null)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Không xác định được giờ thông tin giá vượt quy định. Liên hệ với quản trị nhập vượt giờ quy định.");
                    return;
                }
                long KMKhachDi = Convert.ToUInt32(txtKmThucDi.Text);
                // Xử lý đi tuyến một chiều
                if (radMotChieu.Checked == true)
                {
                    int PhanGio = 0;
                    int PhanPhut = 0;
                    string strSoThucThoiGian = Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu.ToString ();
                    if (strSoThucThoiGian.Contains("."))
                    {
                        PhanGio = Convert.ToInt32(Math.Truncate(Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu));
                        PhanPhut = 30;
                    }
                    else
                    {
                        PhanGio = Convert.ToInt32( Dulieudauvaotinhtienobj.ThoiGianQuyDinh1Chieu );
                        PhanPhut = 0;
                    }
                    //Thời gian quy định đi 1 chiều 
                    TimeSpan Quydinh = new TimeSpan(PhanGio, PhanPhut, 0);
                    // Thời gian trội 
                    TimeSpan timeTroi = timeThoiGianChuyenDi - Quydinh;
                    // Km troi
                    double KmtroiT = KMKhachDi - Dulieudauvaotinhtienobj.KmQuyDinh1Chieu;
                    /// KHUYEN MAI
                    if ((timeTroi.TotalMinutes <= 10) && (KmtroiT == 1))
                    {
                        TextTroi = string.Format("Khuyến mại: {0}h {1}'", timeTroi.Hours, timeTroi.Minutes);
                        TextTroi += ", " + KmtroiT.ToString() + "(km)";
                        txtGhiChu.Text = "Khuyến mại";
                        TienTra = Dulieudauvaotinhtienobj.GiaTien1Chieu;
                    }
                    else
                    {
                        if (timeTroi.Hours > 0 || timeTroi.Minutes > 0) // Kiểm tra có trội
                        {
                            TextTroi = string.Format("{0}h {1}'", timeTroi.Hours, timeTroi.Minutes);
                            int Gio = timeTroi.Hours;    // số giờ trội

                            Tientroi += Gio * VuotGioQuyDinhControl.GiaTienVuot1Gio; // TÍnh tiền trội theo giờ

                            int phut = timeTroi.Minutes; // số phút trội

                            if (phut > 0)
                            {
                                if (phut > 0 && phut <= 15)
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio * 25 / 100;
                                }
                                else if (phut > 15 && phut <= 30)
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio * 50 / 100;
                                }
                                else if (phut > 30 && phut <= 45)
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio * 75 / 100;
                                }
                                else
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio;
                                }
                            }
                        }
                        // TInh tiền km trội  
                        if (KmtroiT >= 1)
                        {
                            TextTroi += ", " + KmtroiT.ToString() + "(km)";
                            Tientroi += KmtroiT * VuotGioQuyDinhControl.GiaTienVuot1Km;
                        }
                        TienTra = Dulieudauvaotinhtienobj.GiaTien1Chieu + Tientroi;
                    }               
                }
                else  // HAI CHIEU
                {
                    int PhanGio = 0;
                    int PhanPhut = 0;
                    string strSoThucThoiGian = Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu.ToString();
                    if (strSoThucThoiGian.Contains("."))
                    {
                        PhanGio = Convert.ToInt32(Math.Truncate(Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu));
                        PhanPhut = 30;
                    }
                    else
                    {
                        PhanGio = Convert.ToInt32(Dulieudauvaotinhtienobj.ThoiGianQuyDinh2Chieu);
                        PhanPhut = 0;
                    }
                    
                    TimeSpan Quydinh = new TimeSpan(PhanGio, PhanPhut, 0);
                      // Thời gian trội 
                    TimeSpan timeTroi = timeThoiGianChuyenDi - Quydinh;

                    // Km trội
                    double KmtroiT = KMKhachDi - Dulieudauvaotinhtienobj.KmQuyDinh2Chieu;
                   /// KHUYEN MAI
                    if ((timeTroi.TotalMinutes <= 10) && (KmtroiT == 1))
                    {
                        TextTroi = string.Format("Khuyến mại: {0}h {1}'", timeTroi.Hours, timeTroi.Minutes);
                        TextTroi += ", " + KmtroiT.ToString() + "(km)";
                        TienTra = Dulieudauvaotinhtienobj.GiaTien2Chieu;
                        txtGhiChu.Text = "Khuyến mại";
                    }
                    else
                    {


                        if (timeTroi.Hours > 0 || timeTroi.Minutes > 0) // Kiểm tra có trội
                        {
                            TextTroi = string.Format("{0}h {1}'", timeTroi.Hours, timeTroi.Minutes);

                            int Gio = timeTroi.Hours;    // số giờ trội

                            Tientroi += Gio * VuotGioQuyDinhControl.GiaTienVuot1Gio; // TÍnh tiền trội theo giờ

                            int phut = timeTroi.Minutes; // số phút trội
                            if (phut > 0)
                            {
                                if (phut > 0 && phut <= 15)
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio * 25 / 100;
                                }
                                else if (phut > 15 && phut <= 30)
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio * 50 / 100;
                                }
                                else if (phut > 30 && phut <= 45)
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio * 75 / 100;
                                }
                                else
                                {
                                    Tientroi += 1 * VuotGioQuyDinhControl.GiaTienVuot1Gio;
                                }
                            }
                        }
                        // TInh tiền km trội 
                        if (KmtroiT >= 1)
                        {
                            TextTroi += ", " + KmtroiT.ToString() + "(km)";
                            Tientroi += KmtroiT * VuotGioQuyDinhControl.GiaTienVuot1Km;
                        }
                        TienTra = Dulieudauvaotinhtienobj.GiaTien2Chieu + Tientroi;
                    }
                }
                txtPhuTroi.Text = TextTroi;
                txtPhuTroiLuu.Text = TextTroi;
                txtThanhTien.Text = TienTra.ToString();
                txtThanhTienLuu.Text = TienTra.ToString();
                btnTinhToan.Enabled = false;
                lblThongBao.Text = "";

            }
            catch {
                lblThongBao.Text = "Có lỗi nhập dữ liệu đầu vào. Bạn kiểm tra lại.";
                btnTinhToan.Enabled = true; btnLuu.Enabled = true;
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
            int ErrorCode = 0;

            ErrorCode = ValidateForm(chkCoDonTraKhach.Checked, btnTinhToan.Visible);
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
                    objThueBao.MaNhanVienNhap = StringTools.TrimSpace(txtNhanVien.Text); //ThongTinDangNhap.USER_ID;
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
                    objThueBao.MaNhanVienNhap = StringTools.TrimSpace(txtNhanVien.Text); ;
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

                    int so = objThueBao.Update(objThueBao);
                    if (so <= 0)
                    {

                        new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật không thành công.Bạn cần kiểm tra lại dữ liệu nhập.");
                        return;
                    }

                    #endregion UPDATE
                }
                g_IsSaved = true;
                
                //Reset lai form
                KhoiTaoNhapMoi();
                HienThiControls_CoThongTinTra(!false);
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

        private void txtKmDon_TextChanged(object sender, EventArgs e)
        {
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            if (g_CoThongTinTraKhach)
            {
                txtKmTra.Enabled = true;
                calTra.Enabled = true;
                string KmDon = StringTools.TrimSpace(txtKmDon.Text);
                string KmTra = StringTools.TrimSpace(txtKmTra.Text);

                if ((KmDon.Length > 0) && (KmTra.Length > 0))
                {
                    try
                    {
                        int iKmThucDi = Convert.ToInt32(KmTra) - Convert.ToInt32(KmDon);

                        txtKmThucDi.Text = iKmThucDi.ToString();
                        
                           
                    }
                    catch (Exception ex)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Nhập sai dữ liệu. Bạn kiểm tra lại.");
                        txtKmDon.Focus();
                    }
                }
            }
        }

        private void txtKmTra_TextChanged(object sender, EventArgs e)
        {
            //btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            //string KmDon = StringTools.TrimSpace(txtKmDon.Text);
            //string KmTra = StringTools.TrimSpace(txtKmTra.Text);

            //if (KmTra.Length > 0)
            //{
            //    btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            //}
            //else btnTinhToan.Enabled = false;

            //if ((KmDon.Length > 0) && (KmTra.Length > 0))
            //{
            //    try
            //    {
            //        int iKmThucDi = Convert.ToInt32(KmTra) - Convert.ToInt32(KmDon);

            //        txtKmThucDi.Text = iKmThucDi.ToString();

            //        if (iKmThucDi < 0) lblMessage.Visible = true;
            //        else lblMessage.Visible = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        //new Taxi.MessageBox.MessageBox().Show("Nhập sai dữ liệu. Bạn kiểm tra lại.");
            //        txtKmTra.Focus();
            //    }
            //}        
        }

        private void cboTuyenDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            if (cboTuyenDuong.SelectedValue != null)
            {
                g_TuyenDuongID =  cboTuyenDuong.SelectedValue.ToString() ;
                if ((g_LoaixeID > 0) & g_TuyenDuongID.Length > 0)
                {
                    this.LoadGiacuoc(g_IsQuanToan, g_LoaixeID, g_TuyenDuongID);
                }
            }
        }

        private void cboViTri_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void cboLoaiXe_SelectedValueChanged(object sender, EventArgs e)
        {
          
            if (cboLoaiXe.SelectedValue != null)
            {
                g_LoaixeID = int.Parse(cboLoaiXe.SelectedValue.ToString());
                if ((g_LoaixeID > 0) & g_TuyenDuongID.Length > 0)
                {
                    this.LoadGiacuoc(g_IsQuanToan, g_LoaixeID, g_TuyenDuongID);
                }
            }
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
        }

        private void txtKmTra_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(txtKmTra.Text).Length <= 0)
            {
                btnTinhToan.Enabled = false; txtKmTra.Focus();
                // tính toán giá trị của Km

            }
            else
            {
                string strKmDon = StringTools.TrimSpace(txtKmDon.Text);
                string strKmTra = StringTools.TrimSpace(txtKmTra.Text);
                if (strKmDon.Length > 0 && strKmTra.Length > 0)
                {
                    int KmDon = Convert.ToInt32(strKmDon);
                    int KmTra = Convert.ToInt32(strKmTra);
                    lblKmDi.Text =   Convert.ToString(KmTra - KmDon) + " Km.";
                    lblKmDi.Visible = true;
                }
            }
        }

        private void txtKmThucDi_TextChanged(object sender, EventArgs e)
        {
             btnTinhToan.Enabled = true; btnLuu.Enabled = true; 
            //string KmThucDi = StringTools.TrimSpace (txtKmThucDi.Text);
            //if(KmThucDi.Length >0)
            //{
            //    try{
            //         int iKmThucDi = Convert.ToInt16 (KmThucDi);
            //         if (iKmThucDi > 0) { btnTinhToan.Enabled = true; btnLuu.Enabled = true; }
            //         else btnTinhToan.Enabled = false;
            //    }
            //        catch(Exception ex)
            //    {
            //        new Taxi.MessageBox.MessageBox().Show("Lỗi nhập Km thực đi.");
            //    }
            //}
        }

        private void cboViTri_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void calDon_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void calTra_TextChanged(object sender, EventArgs e)
        {
            
        }

        #region Xu ly ban phim

        private void cboTuyenDuong_Leave(object sender, EventArgs e)
        {
            radMotChieu.Focus();
        }
        private void radMotChieu_Leave(object sender, EventArgs e)
        {

        }
        #endregion Xu ly ban phim

        private void txtTuyenduong_TextChanged(object sender, EventArgs e)
        {
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
        }

        private void txtGiaThueBao_TextChanged(object sender, EventArgs e)
        {
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
        }

        private void calDon_ValueChanged(object sender, EventArgs e)
        {

            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            TimeSpan tp = calTra.Value - calDon.Value;
            if (tp.Hours > 0 || tp.Minutes > 0)
            {
                lblGioTinh.Text = string.Format("{0} h:{1} phút ", tp.Hours, tp.Minutes);
            }
        }

        private void calTra_ValueChanged(object sender, EventArgs e)
        {
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
            TimeSpan tp = calTra.Value - calDon.Value;
            if (tp.Hours > 0 || tp.Minutes > 0)
            {
                lblGioTinh.Text = string.Format("{0} h:{1} phút ", tp.Hours, tp.Minutes);
            }
        }

        private void txtDongHoTien_TextChanged(object sender, EventArgs e)
        {
            btnTinhToan.Enabled = true; btnLuu.Enabled = true;
        }

        private void txtPhuTroiLuu_TextChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }

        private void txtThanhTienLuu_TextChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }

        private void txtKmDon_Leave(object sender, EventArgs e)
        {
            // tính toán giá trị của Km
            string strKmDon = StringTools.TrimSpace ( txtKmDon.Text);
            string strKmTra = StringTools.TrimSpace (txtKmTra.Text);
            if (strKmDon.Length > 0 && strKmTra.Length > 0)
            { 
                int KmDon = Convert.ToInt32(strKmDon);
                int KmTra = Convert.ToInt32(strKmTra);
                lblKmDi.Text = Convert.ToString(KmTra - KmDon);
                lblKmDi.Visible = true;
            }
        }

        #region XU LY HOTKEY
       //x sohieuxe
       // o laoixe
       // n ngoai thanh
       // t ngoaitinh
       // h khac
       // d tuyenduong
       // 1 1 chieu
       // 2 2 chieu
       // b  thue bao
       // g  gio don
       // r gio tra
       // K Km don
       // m Km tra
       // 3  Doong ho tien
       // v  Km thuc
       // z  tinh toan
       // p phu troi luu
       // t thanh tien
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData ==Keys.Escape  )
            {
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))  
            {
                txtSoHieuXe.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.O))  
            {
                cboLoaiXe.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))  
            {
                if (radKhac.Checked) txtTuyenduong.Focus();
                else cboTuyenDuong.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.B))
            {
                txtGiaThueBao.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.G))
            {
                calDon.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.R))
            {
                calTra.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.K))
            {
                txtKmDon.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.M))
            {
                txtKmTra.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.D3))
            {
                txtDongHoTien.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.D3))
            {
                txtDongHoTien.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.V))
            {
                txtKmThucDi.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.P))
            {
                txtPhuTroiLuu.Focus(); return true;
            }
            else if (keyData == (Keys.Alt | Keys.T))
            {
                txtThanhTienLuu.Focus(); return true;
            }
            else   if (keyData == Keys.Tab)
            {
                this.ProcessTabKey(true); return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion XU LY HOTKEY


        private void txtSoHieuXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnLuu.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                cboLoaiXe.Focus();
            }
        }
        private void radNgoaiThanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                radNgoaiTinh.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                cboLoaiXe.Focus();
            }
        }

        private void radNgoaiTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                radKhac.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                radNgoaiThanh.Focus();
            }
        }

        private void radKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                radNgoaiTinh.Focus();
            }
             
        }
        private void lnkMayTinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");

        }

       

        private void radMotChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                radioHaiChieu.Focus();
            }
             
        }

        private void radioHaiChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left )
            {
                radMotChieu.Focus();
            }
        }

       

    }
}