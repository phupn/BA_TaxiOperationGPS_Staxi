using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.KhachDat;
using Taxi.Business;
using Janus.Windows.GridEX;

namespace Taxi.GUI
{
    public partial class frmListKhachDat : Form
    {
        #region ====================Encapsulation field(Search)========================
        private DateTime _ThoiDiemTiepNhanTu;
        public DateTime ThoiDiemTiepNhanTu
        {
            get { return _ThoiDiemTiepNhanTu; }
            set { _ThoiDiemTiepNhanTu = value; }
        }

        private DateTime _ThoiDiemTiepNhanDen;
        public DateTime ThoiDiemTiepNhanDen
        {
            get { return _ThoiDiemTiepNhanDen; }
            set { _ThoiDiemTiepNhanDen = value; }
        }

        private string _TenKhachHang;
        public string TenKhachHang
        {
            get { return _TenKhachHang; }
            set { _TenKhachHang = value; }
        }

        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        private string _SoDienThoai;
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }

        private int _VungKenh;
        public int VungKenh
        {
            get { return _VungKenh; }
            set { _VungKenh = value; }
        }

        private int _IsLapLai;
        public int IsLapLai
        {
            get { return _IsLapLai; }
            set { _IsLapLai = value; }
        }

        private DateTime _GioDonTu;
        public DateTime GioDonTu
        {
            get { return _GioDonTu; }
            set { _GioDonTu = value; }
        }

        private DateTime _GioDonDen;
        public DateTime GioDonDen
        {
            get { return _GioDonDen; }
            set { _GioDonDen = value; }
        }

        private DateTime _ThoiDiemBatDau;
        public DateTime ThoiDiemBatDau
        {
            get { return _ThoiDiemBatDau; }
            set { _ThoiDiemBatDau = value; }
        }

        private DateTime _ThoiDiemKetThuc;
        public DateTime ThoiDiemKetThuc
        {
            get { return _ThoiDiemKetThuc; }
            set { _ThoiDiemKetThuc = value; }
        }

        private int _SoPhutBaoTruoc;
        public int SoPhutBaoTruoc
        {
            get { return _SoPhutBaoTruoc; }
            set { _SoPhutBaoTruoc = value; }
        }

        private string _LoaiXe;
        public string LoaiXe
        {
            get { return _LoaiXe; }
            set { _LoaiXe = value; }
        }

        private int _SoLuongXe;
        public int SoLuongXe
        {
            get { return _SoLuongXe; }
            set { _SoLuongXe = value; }
        }
        #endregion

        #region ===========================Initialize==================================
        /// <summary>
        /// g_FormStatus = 0 : Tìm kiếm.
        /// g_FormStatus = 1 : Thêm mới.
        /// g_FormStatus = 2 : Cập nhật.
        /// </summary>
        private int g_FormStatus = 0;
        /// <summary>
        /// g_IsNow : Trạng thái dữ liệu của gridview (NgayTiepNhan = now)
        /// </summary>
        private bool g_IsNow = true;
        private long g_IDCuocGoi = 0;
        private int g_IDKhachDat = 0;
        
        private DateTime g_DateTimeServer;
        private KhachDatBL objKhachDat = new KhachDatBL();


        /// <summary>
        /// Contructor for Addnew Record
        /// </summary>
        public frmListKhachDat()
        {
            InitializeComponent();
            refreshForm(1);
        }

        /// <summary>
        /// Contructor for Addnew Record (có thông tin cuộc gọi tự động)
        /// </summary>
        /// <param name="cuocGoi">Thông tin cuộc gọi</param>
        //public frmListKhachDat(CuocGoi cuocGoi)
        //{
        //    InitializeComponent();
        //    refreshForm(1);
        //    calThoiDiemTiepNhan.Value = cuocGoi.ThoiDiemGoi;
        //    g_IDCuocGoi = cuocGoi.IDCuocGoi;
        //    txtDiaChi.Text = cuocGoi.DiaChiDonKhach;
        //    txtDienThoai.Text = cuocGoi.PhoneNumber;
        //    txtDienThoai.Enabled = false;//không được sửa số điện thoại gọi đến
        //    txtKenh.Enabled = false;
        //    txtKenh.Text = cuocGoi.Vung.ToString();            
        //}

        /// <summary>
        /// Contructor for Update Record
        /// </summary>
        /// <param name="KhachDat">Thông tin khách đặt</param>
        public frmListKhachDat(KhachDatBL KhachDat)
        {
            InitializeComponent();
            //g_IsUpdate = true;
            objKhachDat = KhachDat;
            //setDataInput();          
        }

        #endregion

        #region ===========================Load Form===================================
        private void frmListKhachDat_Load(object sender, EventArgs e)
        {
            fillDefaultDataToForm(1);
        }

        private void fillDefaultDataToForm(int formStatus)
        {
            g_DateTimeServer = DieuHanhTaxi.GetTimeServer();
            if (formStatus == 1)
            {//for Addnew item                
                calThoiDiemTiepNhan.Value = g_DateTimeServer;
                cbSoPhut.Value = 15;
                calGioDon.Value = new DateTime(1900, 1, 1, g_DateTimeServer.Hour, g_DateTimeServer.Minute, 0);
                calNgayBatDau.Value = g_DateTimeServer;
                calNgayKetThuc.Value = g_DateTimeServer;
                getKhachDat_NgayTiepNhan();
            }
            else if (formStatus == 0)
            {
                //for Search item
                txtKenh.Value = null;
                cbSoPhut.TextBox.Text = "";
                calNgayBatDau.IsNullDate = true;
                calNgayKetThuc.IsNullDate = true;
                calGioDonTu.Value = new DateTime(1900, 1, 1, 0, 0, 0);
                calGioDonDen.Value = new DateTime(1900, 1, 1, 23, 59, 0);
                calTGTiepNhanTu.Value = new DateTime(g_DateTimeServer.Year, g_DateTimeServer.Month, g_DateTimeServer.Day, 0, 0, 0);
                calTGTiepNhanDen.Value = new DateTime(g_DateTimeServer.Year, g_DateTimeServer.Month, g_DateTimeServer.Day, 23, 59, 0);
            }            
        }

        /// <summary>
        /// Get thông tin Khách đặt theo ngày Tiếp nhận (ngày hiện tại)
        /// </summary>
        private void getKhachDat_NgayTiepNhan()
        {
            List<KhachDatBL> lstKhachDat = new KhachDatBL().GetKhachDat_TGTiepNhan(calThoiDiemTiepNhan.Value);
            gridDSDatHen.DataMember = "lstKhachDat_Ngay";
            gridDSDatHen.SetDataBinding(lstKhachDat, "lstKhachDat_Ngay");

        }
        #endregion

        #region ===========================Validate====================================
        private bool isValid()
        {            
            lblMsg.Text = "";
            lblMsg.ForeColor = Color.Red;
            if (g_FormStatus == 0)
            {
                if (calTGTiepNhanTu.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Thời điểm nhận"; 
                    calTGTiepNhanTu.Focus();
                    return false;
                }
                if (calTGTiepNhanDen.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Thời điểm nhận"; 
                    calTGTiepNhanDen.Focus();
                    return false;
                }
                if (calGioDonTu.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Giờ đón"; 
                    calGioDonTu.Focus();
                    return false;
                }
                if (calGioDonDen.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Giờ đón";
                    calGioDonDen.Focus();
                    return false;
                }
            }
            else
            {
                if (txtTenKH.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Tên khách hàng"; 
                    txtTenKH.Focus();
                    return false;
                }
                if (txtDiaChi.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Địa chỉ";                    
                    txtDiaChi.Focus();
                    return false;
                }
                if (txtDienThoai.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Số điện thoại";
                    txtDienThoai.Focus();
                    return false;
                }
                //if (txtKenh.Text.Trim() == String.Empty || Convert.ToInt16(txtKenh.Value) <= 0)
                //{
                //    lblMsg.Text = "Vui lòng nhập Vùng/Kênh";
                //    txtKenh.Focus();
                //    return false;
                //}
                if (calThoiDiemTiepNhan.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Thời điểm nhận";
                    calThoiDiemTiepNhan.Focus();
                    return false;
                }
                if (calGioDon.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Giờ đón";
                    calGioDon.Focus();
                    return false;
                }
                if (calNgayBatDau.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Ngày bắt đầu";
                    calNgayBatDau.Focus();
                    return false;
                }
                if (calNgayKetThuc.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Ngày kết thúc";
                    calNgayKetThuc.Focus();
                    return false;
                }
                if (cbSoPhut.Value <= 0)
                {
                    lblMsg.Text = "Vui lòng nhập Số phút báo trước";
                   
                    cbSoPhut.Focus();
                    return false;
                }
                if (rbLapLai.Checked == true)
                {
                    if (getNgayTrongTuan() == "")
                    {
                        lblMsg.Text = "Vui lòng nhập các Ngày trong tuần(lặp lại)";
                        chkThu2.Focus();
                        return false;
                    }
                }
                if (txtSoLuong.Text.Trim() == String.Empty || Convert.ToInt16(txtSoLuong.Value) <= 0)
                {                    
                    lblMsg.Text = "Vui lòng nhập Số lượng xe"; 
                    txtSoLuong.Focus();
                    return false;
                }
                //if (chkXeKI4.Checked == false &&
                //    chkXeLIMO7.Checked == false &&
                //    chkXeVIOS4.Checked == false &&
                //    chkXeINOVA7.Checked == false)
                //{
                //    lblMsg.Text = "Vui lòng nhập chọn loại xe"; 
                //    chkXeKI4.Focus();
                //    return false;
                //}
            }
            return true;

        }
        
        #endregion

        #region ======================Form Status======================================
        
        /// <summary>
        /// Get data on the form (Adding / Updating)
        /// </summary>
        ///// <returns>false : không lấy được ID cuộc gọi</returns>
        private void getDataInput()
        {
            //if (g_IDCuocGoi <= 0)
            //{
            //    new MessageBox.MessageBox().Show("Vui lòng chọn cuộc gọi cần đặt xe.", "Thông báo lỗi",
            //                                                   Taxi.MessageBox.MessageBoxButtons.OK,
            //                                                   Taxi.MessageBox.MessageBoxIcon.Error);
            //    return false;
            //}
            objKhachDat.PK_KhachDatID = g_IDKhachDat;
            objKhachDat.FK_CuocGoiID = g_IDCuocGoi;
            objKhachDat.TenKhachHang = txtTenKH.Text.Trim();
            objKhachDat.DiaChi = txtDiaChi.Text.Trim();
            objKhachDat.ThoiDiemTiepNhan = calThoiDiemTiepNhan.Value;
            objKhachDat.SoDienThoai = txtDienThoai.Text.Trim();
            objKhachDat.VungKenh = Convert.ToInt16(txtKenh.Value);
            objKhachDat.LoaiXe = GetThongTinLoaiXeChon2();
            objKhachDat.SoLuongXe = Convert.ToInt16(txtSoLuong.Value);
            if (rbLapLai.Checked)
            {
                objKhachDat.IsLapLai = true;
                objKhachDat.ThoiDiemKetThuc = calNgayKetThuc.Value.Date;
                objKhachDat.NgayTrongTuanLapLai = getNgayTrongTuan();
            }
            else
            {                
                objKhachDat.IsLapLai = false;
                objKhachDat.ThoiDiemKetThuc = calNgayBatDau.Value.Date;
                objKhachDat.NgayTrongTuanLapLai = "";
            }
            objKhachDat.GioDon = new DateTime(calNgayBatDau.Value.Date.Year, calNgayBatDau.Value.Date.Month, calNgayBatDau.Value.Date.Day, calGioDon.Value.Hour, calGioDon.Value.Minute, 0);
            objKhachDat.ThoiDiemBatDau = calNgayBatDau.Value.Date;           
            
            objKhachDat.SoPhutBaoTruoc = Convert.ToInt16(cbSoPhut.Value);
            //objKhachDat.FK_CuocGoiID = 0;
            objKhachDat.CreatedBy = ThongTinDangNhap.USER_ID;
            objKhachDat.UpdatedBy = ThongTinDangNhap.USER_ID;
            objKhachDat.GhiChu = txtGhiChu.Text.Trim();
            objKhachDat.SoTien = double.Parse(txtSoTien.Text.Trim());
            //return true;
        }

        /// <summary>
        /// Set data on the form
        /// </summary>
        private void setDataInput(GridEXRow row)
        {
            g_FormStatus = 2;
            refreshForm(g_FormStatus);
            string IDKhachDat = row.Cells["PK_KhachDatID"].Value.ToString();
            g_IDKhachDat = Int32.TryParse(IDKhachDat, out g_IDKhachDat) ? g_IDKhachDat : 0;
            txtTenKH.Text = row.Cells["TenKhachHang"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            calThoiDiemTiepNhan.Value = Convert.ToDateTime(row.Cells["ThoiDiemTiepNhan"].Value);
            txtDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtKenh.Value = row.Cells["VungKenh"].Value;
            bool isLapLai = Convert.ToBoolean(row.Cells["IsLapLai"].Value);

            calNgayBatDau.IsNullDate = false;
            calNgayBatDau.Text = row.Cells["ThoiDiemBatDau"].Value.ToString();
            calNgayBatDau.Value = Convert.ToDateTime(row.Cells["ThoiDiemBatDau"].Value);
            
            if (isLapLai)
            {
                rbLapLai.Checked = true;
                calNgayKetThuc.IsNullDate = false;
                calNgayKetThuc.Value = Convert.ToDateTime(row.Cells["ThoiDiemKetThuc"].Value);
            }
            else
            {
                rbMotLan.Checked = true;
                calNgayKetThuc.IsNullDate = false;
                calNgayKetThuc.Value = calNgayBatDau.Value.Date;

            }
            setNgayTrongTuan(row.Cells["NgayTrongTuanLapLai"].Value.ToString());
            calGioDon.Value = Convert.ToDateTime(row.Cells["GioDon"].Value);
            
            int SoPhutBaoTruoc = Int32.TryParse(row.Cells["SoPhutBaoTruoc"].Value.ToString(), out SoPhutBaoTruoc) ? SoPhutBaoTruoc : 0;
            cbSoPhut.Value = SoPhutBaoTruoc;
            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            SetThongTinLoaiXe2(row.Cells["LoaiXe"].Value.ToString());
            txtSoLuong.Text = row.Cells["SoLuongXe"].Value.ToString();
            txtSoTien.Text = row.Cells["SoTien"].Value.ToString();
        }

        /// <summary>
        /// Get Ngày trong tuần lặp lại
        /// </summary>
        /// <returns>2;3;4;5;6;7;8</returns>
        private string getNgayTrongTuan()
        {
            string strNgayTrongTuanLapLai = "";
            
            if (chkThu2.Checked)
                strNgayTrongTuanLapLai = "2;";
            if (chkThu3.Checked)
                strNgayTrongTuanLapLai += "3;";
            if (chkThu4.Checked)
                strNgayTrongTuanLapLai += "4;";
            if (chkThu5.Checked)
                strNgayTrongTuanLapLai += "5;";
            if (chkThu6.Checked)
                strNgayTrongTuanLapLai += "6;";
            if (chkThu7.Checked)
                strNgayTrongTuanLapLai += "7;";
            if (chkCN.Checked)
                strNgayTrongTuanLapLai += "8;";

            if (strNgayTrongTuanLapLai == "")
                return "";

            return strNgayTrongTuanLapLai.Substring(0, strNgayTrongTuanLapLai.Length-1);
        }

        /// <summary>
        /// set Ngày trong tuần lặp lại
        /// </summary>
        private void setNgayTrongTuan(string strNgayTrongTuanLapLai)
        {
            string[] arrValue = strNgayTrongTuanLapLai.Split(';');
            for (int i = 0; i < arrValue.Length; i++)
            {
                if (arrValue[i] == "2")
                {
                    chkThu2.Checked = true;
                    continue;
                }
                if (arrValue[i] == "3")
                {
                    chkThu3.Checked = true;
                    continue;
                }
                if (arrValue[i] == "4")
                {
                    chkThu4.Checked = true;
                    continue;
                }
                if (arrValue[i] == "5")
                {
                    chkThu5.Checked = true;
                    continue;
                }
                if (arrValue[i] == "6")
                {
                    chkThu6.Checked = true;
                    continue;
                }
                if (arrValue[i] == "7")
                {
                    chkThu7.Checked = true;
                    continue;
                }
                if (arrValue[i] == "8")
                {
                    chkCN.Checked = true;
                    continue;
                }
            }
        }

        /// <summary>
        /// Set lại trạng thái của form
        /// </summary>
        private void refreshForm(int formStatus)
        {
            txtTenKH.Focus();
            txtTenKH.Text = "";
            txtKenh.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            txtSoLuong.Text = "1";
            txtSoTien.Text = "";
            rbMotLan.Checked = true;            
            switch (formStatus)
            {
                case 0://Tìm kiếm
                    lblMsg.Text = "";
                    g_FormStatus = formStatus;
                    g_IsNow = false;                    
                    pnlGioDonSearch.Visible = true;
                    pnlTGTiepNhanSearch.Visible = true;
                    pnlLoaiDatHen.Visible = true;
                    rbMotLan.Visible = false;
                    rbLapLai.Visible = false;
                    calGioDon.Visible = false;
                    calThoiDiemTiepNhan.Visible = false;
                    calNgayKetThuc.Enabled = true;
                    fillDefaultDataToForm(0);
                    txtDiaChi.BackColor = Color.Yellow;
                    txtDienThoai.BackColor = Color.Yellow;
                    txtTenKH.BackColor = Color.Yellow;
                    txtKenh.BackColor = Color.Yellow;
                    calNgayBatDau.BackColor = Color.Yellow;
                    calNgayKetThuc.BackColor = Color.Yellow;
                    cbSoPhut.BackColor = Color.Yellow;
                    txtSoLuong.BackColor = Color.Yellow;
                    //chkXeINOVA7.BackColor = Color.Yellow;
                    //chkXeKI4.BackColor = Color.Yellow;
                    //chkXeLIMO7.BackColor = Color.Yellow;
                    //chkXeVIOS4.BackColor = Color.Yellow;
                    btnUpdate.ImageIndex = 0;
                    btnUpdate.Text = "Tìm (Ctrl+S)";
                    break;
                case 1://Thêm mới
                case 2://Cap Nhât
                    g_FormStatus = formStatus;                    
                    txtTenKH.Focus();
                    pnlGioDonSearch.Visible = false;
                    pnlTGTiepNhanSearch.Visible = false;
                    pnlLoaiDatHen.Visible = false;
                    rbMotLan.Visible = true;
                    rbLapLai.Visible = true;
                    calGioDon.Visible = true;
                    calThoiDiemTiepNhan.Visible = true;
                    txtDiaChi.BackColor = SystemColors.Window;
                    txtDienThoai.BackColor = SystemColors.Window;
                    txtTenKH.BackColor = SystemColors.Window;
                    txtKenh.BackColor = SystemColors.Window;
                    calNgayBatDau.BackColor = SystemColors.Window;
                    calNgayKetThuc.BackColor = SystemColors.Window;
                    cbSoPhut.BackColor = SystemColors.Window;
                    txtSoLuong.BackColor = SystemColors.Window;
                    //chkXeINOVA7.BackColor = Color.Transparent;
                    //chkXeKI4.BackColor = Color.Transparent;
                    //chkXeLIMO7.BackColor = Color.Transparent;
                    //chkXeVIOS4.BackColor = Color.Transparent;
                    btnUpdate.ImageIndex = 3;
                    btnUpdate.Text = "Lưu (Ctrl+S)";                    
                    break;
                default:
                    break;
            }
            
        }

        private void getKhachDat_Search()
        {
            lblMsg.Text = "";
            TenKhachHang = txtTenKH.Text.Trim();
            DiaChi = txtDiaChi.Text.Trim();
            ThoiDiemTiepNhanTu = calTGTiepNhanTu.Value;
            ThoiDiemTiepNhanDen = calTGTiepNhanDen.Value;
            SoDienThoai = txtDienThoai.Text.Trim();
            LoaiXe = "";
            SoLuongXe = Convert.ToInt16(txtSoLuong.Value);
            if (txtKenh.Value != null)
            {
                VungKenh = Convert.ToInt16(txtKenh.Value);
            }

            if (chkMotLan.Checked == true && chkLapLai.Checked == true
                || chkMotLan.Checked == false && chkLapLai.Checked == false)
            {
                IsLapLai = -1;
            }
            else if (chkMotLan.Checked == true)
            {
                IsLapLai = 0;
            }
            else
            {
                IsLapLai = 1;
            }
            GioDonTu = calGioDonTu.Value;
            GioDonDen = calGioDonDen.Value;
            if (calNgayBatDau.Text != "")
                ThoiDiemBatDau = calNgayBatDau.Value.Date;
            else
                ThoiDiemBatDau = DateTime.MinValue;
            if (calNgayKetThuc.Text != "")
                ThoiDiemKetThuc = calNgayKetThuc.Value.Date;
            else
                ThoiDiemKetThuc = DateTime.MinValue;
            if (cbSoPhut.TextBox.Text != "")
            {
                SoPhutBaoTruoc = Convert.ToInt16(cbSoPhut.Value);
            }
            
        }

        /// <summary>
        /// Search dữ liệu và fill vào grid
        /// </summary>
        private void setData_BySearch()
        {
            List<KhachDatBL> lstKhachDat = new KhachDatBL().GetKhachDat_Search(ThoiDiemTiepNhanTu, ThoiDiemTiepNhanDen, TenKhachHang, DiaChi, SoDienThoai, VungKenh
                                , IsLapLai, GioDonTu, GioDonDen, ThoiDiemBatDau, ThoiDiemKetThuc, SoPhutBaoTruoc, LoaiXe, SoLuongXe);
            if (lstKhachDat == null)
            {
                lblMsg.Text = "Không tìm thấy dữ liệu";
            }
            gridDSDatHen.DataMember = "lstKhachDat_Search";
            gridDSDatHen.SetDataBinding(lstKhachDat, "lstKhachDat_Search");
        }

        //private string GetThongTinLoaiXeChon()
        //{
        //    string loaiXe = string.Empty;
        //    if (chkXeKI4.Checked)
        //    {
        //        loaiXe += "KIA,";
        //    }
        //    if (chkXeVIOS4.Checked)
        //    {
        //        loaiXe += " 4 cho,";
        //    }
        //    if (chkXeINOVA7.Checked)
        //    {
        //        loaiXe += "7 cho,";
        //    }
        //    if (chkXeLIMO7.Checked)
        //    {
        //        loaiXe += "LIMO,";
        //    }
        //    if (loaiXe.Length > 0)
        //    {
        //        loaiXe = loaiXe.Substring(0, loaiXe.Length - 1);
        //    }
        //    return loaiXe;
        //}


        private string GetThongTinLoaiXeChon2()
        {
            string loaiXe = string.Empty;
            if (chk4Cho.Checked)
            {
                loaiXe += "4,";
            }
            if (chk7Cho.Checked)
            {
                loaiXe += "7,";
            }
            if (loaiXe.Length > 0)
            {
                loaiXe = loaiXe.Substring(0, loaiXe.Length - 1);
            }
            return loaiXe;
        }


        private void SetThongTinLoaiXe2(string loaiXe)
        {
            if (loaiXe != null && loaiXe.Length > 0)
            {
                string strLoaiXe = "";
                strLoaiXe = loaiXe;
                if (loaiXe.Contains("4c"))
                {
                    chk4Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Replace("4c,", "");
                }
                if (loaiXe.Contains("7c"))
                {
                    chk7Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Replace("7c,", "");
                }
                txtLoaiXe.Text = strLoaiXe;
            }
        }
        /// <summary>
        /// hàm thực hiện set thông tin loại xe
        /// Input : 
        ///     - KIA,VIO,INO,LIMO
        /// Ouput :
        ///      Set lên check box
        /// </summary>
        /// <param name="p"></param>
        //private void SetThongTinLoaiXe(string loaiXe)
        //{
        //    if (loaiXe != null && loaiXe.Length > 0)
        //    {
        //        chkXeKI4.Checked = false;
        //        chkXeVIOS4.Checked = false;
        //        chkXeINOVA7.Checked = false;
        //        chkXeLIMO7.Checked = false;
        //        if (loaiXe.Contains("KIA"))
        //        {
        //            chkXeKI4.Checked = true;
        //        }
        //        if (loaiXe.Contains("4"))
        //        {
        //            chkXeVIOS4.Checked = true;
        //        }
        //        if (loaiXe.Contains("7"))
        //        {
        //            chkXeINOVA7.Checked = true;
        //        }
        //        if (loaiXe.Contains("LIMO"))
        //        {
        //            chkXeLIMO7.Checked = true;
        //        }
        //    }

        //}
        #endregion 

        #region ===========================Form Event =================================
        private void rbMotLan_CheckedChanged(object sender, EventArgs e)
        {
            boxHangTuan.Enabled = false;
            calNgayKetThuc.Enabled = false;
        }

        private void rbLapLai_CheckedChanged(object sender, EventArgs e)
        {
            boxHangTuan.Enabled = true;
            calNgayKetThuc.Enabled = true;
            chkThu2.Checked = false;
            chkThu3.Checked = false;
            chkThu4.Checked = false;
            chkThu5.Checked = false;
            chkThu6.Checked = false;
            chkThu7.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;

            if (g_FormStatus==2)
            {
                if (g_IDKhachDat <= 0)
                    return;

                getDataInput();//Lay du Lieu                
                if (objKhachDat.UpdateKhachDat())
                {
                    lblMsg.ForeColor = Color.Blue;
                    lblMsg.Text = "Cập nhật thành công";

                    if (g_IsNow)
                        getKhachDat_NgayTiepNhan();
                    else
                    {
                        setData_BySearch();
                    }
                }
                else
                {
                    lblMsg.Text = "Cập nhật không thành công";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            else if (g_FormStatus==1)
            {
                getDataInput();// Lay dữ liệu
                
                if (objKhachDat.InsertKhachDat())
                {
                    lblMsg.Text = "Thêm mới thành công";
                    lblMsg.ForeColor = Color.Blue; 

                    refreshForm(1);
                    fillDefaultDataToForm(1);
                    getKhachDat_NgayTiepNhan();
                }
                else
                {
                    lblMsg.Text = "Thêm mới không thành công";
                    lblMsg.ForeColor = Color.Red;
                }                
            }
            else if (g_FormStatus == 0)
            {
                getKhachDat_Search();
                setData_BySearch();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshForm(1);
            fillDefaultDataToForm(1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (g_IDKhachDat > 0)
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == "Yes")
                {
                    if (objKhachDat.DeleteKhachDat(g_IDKhachDat))
                    {
                        lblMsg.Text = "Xóa thành công";
                        lblMsg.ForeColor = Color.Blue;
                        if (g_IsNow)
                            getKhachDat_NgayTiepNhan();
                        else
                        {
                            setData_BySearch();
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Xóa không thành công";
                        lblMsg.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                lblMsg.Text = "Vui lòng chọn một cuộc đặt lịch hẹn xe muốn xóa";
                lblMsg.ForeColor = Color.Red;                
            }
        }

        #endregion

        #region ============================Key Event =================================
        private void gridDSDatHen_KeyUp(object sender, KeyEventArgs e)
        {
            gridDSDatHen.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (gridDSDatHen.SelectedItems.Count > 0)
                {
                    setDataInput(gridDSDatHen.CurrentRow);
                }
            }
        }

        private void gridDSDatHen_Click(object sender, EventArgs e)
        {
            gridDSDatHen.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDSDatHen.SelectedItems != null && gridDSDatHen.SelectedItems.Count > 0)
            {
                setDataInput(gridDSDatHen.CurrentRow);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.Delete:
                    btnDelete_Click(null, null);
                    break;
                case Keys.Control | Keys.S:                    
                    btnUpdate_Click(null, null);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F5:
                    refreshForm(1);
                    fillDefaultDataToForm(1);
                    break;
                case Keys.Alt | Keys.H:
                    txtTenKH.Focus();
                    break;
                case Keys.Alt | Keys.D:
                    txtDienThoai.Focus();
                    break;
                case Keys.Alt | Keys.C:
                    txtDiaChi.Focus();
                    break;
                case Keys.Alt | Keys.G:
                    if (g_FormStatus == 0)
                        calGioDonTu.Focus();
                    else
                        calGioDon.Focus();
                    break;
                case Keys.Alt | Keys.B:
                    calNgayBatDau.Focus();
                    break;
                case Keys.Alt | Keys.K:
                    calNgayKetThuc.Focus();
                    break;
                case Keys.Alt | Keys.T:
                    cbSoPhut.Focus();
                    break;
                case Keys.Alt | Keys.U:
                    txtKenh.Focus();
                    break;
                //case Keys.Alt | Keys.O:
                //    if (chkXeLIMO7.Checked)
                //        chkXeLIMO7.Checked = false;
                //    else
                //        chkXeLIMO7.Checked = true;
                //    return true;
                //case Keys.Alt | Keys.V:
                //    if (chkXeVIOS4.Checked)
                //        chkXeVIOS4.Checked = false;
                //    else
                //        chkXeVIOS4.Checked = true;
                //    return true;
                //case Keys.Alt | Keys.N:
                //    if (chkXeINOVA7.Checked)
                //        chkXeINOVA7.Checked = false;
                //    else
                //        chkXeINOVA7.Checked = true;
                //    return true;
                //case Keys.Alt | Keys.A:
                //    if (chkXeKI4.Checked)
                //        chkXeKI4.Checked = false;
                //    else
                //        chkXeKI4.Checked = true;
                //    return true;
                case Keys.Alt | Keys.S:
                    txtSoLuong.Focus();
                    return true;
                case Keys.Alt | Keys.M:                    
                    if (g_FormStatus == 0)
                    {
                        if (chkMotLan.Checked == true)
                            chkMotLan.Checked = false;
                        else
                            chkMotLan.Checked = true;
                    }
                    else
                        rbMotLan.Checked = true;
                    break;
                case Keys.Alt | Keys.L:                    
                    if (g_FormStatus == 0)
                    {
                        if (rbLapLai.Checked == true)
                            rbLapLai.Checked = false;
                        else
                            rbLapLai.Checked = true;
                    }
                    else
                        rbLapLai.Checked = true;
                    break;
                case Keys.Alt | Keys.I:
                    txtGhiChu.Focus();
                    break;
                case Keys.Alt | Keys.E:                    
                    if (g_FormStatus == 0)
                        calTGTiepNhanTu.Focus();
                    else
                        calThoiDiemTiepNhan.Focus();
                    break;
                case Keys.Alt | Keys.D2:
                    if (chkThu2.Checked)
                        chkThu2.Checked = false;
                    else
                        chkThu2.Checked = true;
                    break;
                case Keys.Alt | Keys.D3:
                    if (chkThu3.Checked)
                        chkThu3.Checked = false;
                    else
                        chkThu3.Checked = true;
                    break;
                case Keys.Alt | Keys.D4:
                    if (chkThu4.Checked)
                        chkThu4.Checked = false;
                    else
                        chkThu4.Checked = true;
                    break;
                case Keys.Alt | Keys.D5:
                    if (chkThu5.Checked)
                        chkThu5.Checked = false;
                    else
                        chkThu5.Checked = true;
                    break;
                case Keys.Alt | Keys.D6:
                    if (chkThu6.Checked)
                        chkThu6.Checked = false;
                    else
                        chkThu6.Checked = true;
                    break;
                case Keys.Alt | Keys.D7:
                    if (chkThu7.Checked)
                        chkThu7.Checked = false;
                    else
                        chkThu7.Checked = true;
                    break;
                case Keys.Alt | Keys.D8:
                    if (chkCN.Checked)
                        chkCN.Checked = false;
                    else
                        chkCN.Checked = true;
                    break;
                case Keys.Control | Keys.F:
                    refreshForm(0);
                    break;
                case Keys.Up:
                    if (rbMotLan.Focused == true)
                        cbSoPhut.Focus();
                    break;
                case Keys.Left:
                    if (rbMotLan.Focused == true)
                        calGioDon.Focus();
                    break;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtDiaChi.Focus();
                    break;
                case Keys.Right:
                    calGioDon.Focus();
                    break;
                case Keys.Down:
                    txtDiaChi.Focus();
                    break;
                default:
                    break;
            }
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtDienThoai.Focus();
                    break;
                case Keys.Right:
                    calNgayBatDau.Focus();
                    break;
                case Keys.Down:
                    txtDienThoai.Focus();
                    break;
                case Keys.Up:
                    txtTenKH.Focus();
                    break;
                default:
                    break;
            }
        }

        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (g_FormStatus == 0)
                        calTGTiepNhanTu.Focus();
                    else
                        calThoiDiemTiepNhan.Focus();
                    break;
                case Keys.Right:
                    if (calNgayKetThuc.Enabled == true)
                        calNgayKetThuc.Focus();
                    else
                        cbSoPhut.Focus();
                    break;
                case Keys.Down:
                    if (g_FormStatus == 0)
                        calTGTiepNhanTu.Focus();
                    else
                        calThoiDiemTiepNhan.Focus();
                    break;
                case Keys.Up:
                    txtDiaChi.Focus();
                    break;
                default:
                    break;
            }
        }

        private void calThoiDiemTiepNhan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtKenh.Focus();
                    break;
                case Keys.Right:
                    cbSoPhut.Focus();
                    break;
                case Keys.Down:
                    txtKenh.Focus();
                    break;
                case Keys.Up:
                    txtDienThoai.Focus();
                    break;
                default:
                    break;
            }
        } 

        private void txtKenh_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (g_FormStatus == 0)
                        calGioDonTu.Focus();
                    else
                        calGioDon.Focus();
                    break;
                case Keys.Right:
                    cbSoPhut.Focus();
                    break;
                case Keys.Down:
                    if (g_FormStatus == 0)
                        calGioDonTu.Focus();
                    else
                        calGioDon.Focus();
                    break;
                case Keys.Up:
                    if(g_FormStatus == 0)
                        calTGTiepNhanDen.Focus();
                    else
                        calThoiDiemTiepNhan.Focus();
                    break;
                default:
                    break;
            }
        }       

        private void calGioDon_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    calNgayBatDau.Focus();
                    break;
                case Keys.Left:
                    txtTenKH.Focus();
                    break;
                case Keys.Right:
                    rbMotLan.Focus();
                    break;
                case Keys.Down:
                    calNgayBatDau.Focus();
                    break;
                case Keys.Up:
                    txtKenh.Focus();
                    break;
                default:
                    break;
            }
        }

        private void calNgayBatDau_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    calNgayKetThuc.Focus();
                    break;
                case Keys.Left:
                    txtDiaChi.Focus();
                    break;
                case Keys.Right:
                    rbMotLan.Focus();
                    break;
                case Keys.Down:
                    if (calNgayKetThuc.Enabled == true)
                        calNgayKetThuc.Focus();
                    else
                        cbSoPhut.Focus();
                    break;
                case Keys.Up:
                    if (g_FormStatus == 0)
                        calGioDonDen.Focus();
                    else
                        calGioDon.Focus();                    
                    break;
                default:
                    break;
            }
        }

        private void calNgayKetThuc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    cbSoPhut.Focus();
                    break;
                case Keys.Left:
                    txtDienThoai.Focus();
                    break;
                case Keys.Right:
                    rbMotLan.Focus();
                    break;
                case Keys.Down:
                    cbSoPhut.Focus();
                    break;
                case Keys.Up:
                    calNgayBatDau.Focus();
                    break;
                default:
                    break;
            }
        }

        private void cbSoPhut_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (g_FormStatus == 0)
                        chkMotLan.Focus();
                    else
                        rbMotLan.Focus();                    
                    break;
                case Keys.Left:
                    txtKenh.Focus();
                    break;
                case Keys.Right:
                    if (g_FormStatus == 0)
                        chkMotLan.Focus();
                    else
                        rbMotLan.Focus();
                    break;
                case Keys.Down:
                    if (g_FormStatus == 0)
                        chkMotLan.Focus();
                    else
                        rbMotLan.Focus();
                    break;
                case Keys.Up:
                    if (calNgayKetThuc.Enabled == true)
                        calNgayKetThuc.Focus();
                    else
                        cbSoPhut.Focus();
                    break;
                default:
                    break;
            }
        }

        private void rbMotLan_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void rbLapLai_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkThu2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void chkThu3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkThu4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkThu5_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkThu6_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkThu7_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkCN_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
        }
        #endregion        
    }
}