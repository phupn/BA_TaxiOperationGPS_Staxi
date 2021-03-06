 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.MessageBox;

namespace Taxi.GUI
{
    /// <summary>
    /// Quản lý người dùng hệ thống : Thêm mới, cập nhật thông tin thay đổi của người dùng
    /// </summary>
    /// <Modified>
    ///     Author      Date        Comments
    ///     Cuongdb    15/2/2008    Tạo mới
    /// </Modified>
    public partial class HeThong_NguoiDung_TaoMoi : Form
    {
        // Khai báo các biến
        private string strUser_ID = "";
        private int intMaChucVu = 0;
        private int intMaPhong;
        private Users objUser = new Users();
        private static string strPasswordOld;

        /// <summary>
        /// Khoi tao form tạo mới nguoi dung
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        /// </Modified>

        public HeThong_NguoiDung_TaoMoi()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Khoi tao form cap nhat nguoi dung
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        /// </Modified>

        public HeThong_NguoiDung_TaoMoi(string MaNguoiDung)
        {
            InitializeComponent();
            strUser_ID = MaNguoiDung;
        }
        /// <summary>
        /// Load danh mục chức vụ trong hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        ///     Cuongdb    28/2/2008    Chỉnh sửa
        /// </Modified>
        private void LoadChucVu(int MaPhong)
        {
            int ChucVuTruongPhong = 1;
            TuDienChucVu objChucVu = new TuDienChucVu();
            DataTable tblChucVu;
            TuDienPhong objPhong = new TuDienPhong();
            objPhong.PhongID = MaPhong;
            if (MaPhong == intMaPhong)
            {
                if ((intMaChucVu == ChucVuTruongPhong) || (!objPhong.DaCoChucVu(ChucVuTruongPhong)))
                {
                    tblChucVu = objChucVu.LayDanhSach();
                }
                else
                {
                    tblChucVu = objChucVu.LayDanhSachKhongCoTruongPhong();
                }
            }
            else
            {
                if (objPhong.DaCoChucVu(ChucVuTruongPhong))
                {
                    tblChucVu = objChucVu.LayDanhSachKhongCoTruongPhong();
                }
                else
                    tblChucVu = objChucVu.LayDanhSach();
            }
            cbChucVu.DisplayMember = "TenChucVu";
            cbChucVu.ValueMember = "ChucVuID";
            cbChucVu.DataSource = tblChucVu;
            if (MaPhong == intMaPhong) cbChucVu.SelectedValue = intMaChucVu;
            else cbChucVu.SelectedIndex = 0;
        }
        /// <summary>
        /// Load danh sách các phòng ban
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        /// </Modified>

        private void LoadPhongBan()
        {
            TuDienPhong objPhong = new TuDienPhong();
            DataTable tblPhong = objPhong.LayDanhSach();
            cbPhong.DisplayMember = "TenPhong";
            cbPhong.ValueMember = "PhongID";
            cbPhong.DataSource = tblPhong;
        }
        /// <summary>
        /// Hiển thị danh sách các trung tâm thu phí
        /// </summary>
        /// <Modified>
        ///     Author      Date            Comments
        ///     Namnh       26/06/2008      Tạo mới
        /// </Modified>
        private void LoadTrungTam()
        {
            //DMTrungTam objTrungTam = new DMTrungTam();
            //DataTable tblTrungTam = objTrungTam.LayDanhSachKhongKemTheoTinhThanh();
            //DataRow row = tblTrungTam.NewRow();
            //row["TrungTamID"] = 0; row["TenTrungTam"] = "Chọn trung tâm";
            //tblTrungTam.Rows.InsertAt(row, 0);
            //cbTrungTam.ValueMember = "TrungTamID";
            //cbTrungTam.DisplayMember = "TenTrungTam";
            //cbTrungTam.DataSource = tblTrungTam;            
        }

        /// <summary>
        /// Load thông tin người dùng trong hệ thống 
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        /// </Modified>

        private void LoadThongTinNguoiDung(string strMaNguoiDung)
        {
            try
            {
                txtTenTruyCap.ReadOnly = strMaNguoiDung != "" ? true : false;
                Users objUser = new Users(strMaNguoiDung);
                txtDiaChi.Text = objUser.DiaChi;
                txtHoTen.Text = objUser.FullName;
                txtQueQuan.Text = objUser.QueQuan;
                intMaChucVu = objUser.ChucVUID;
                intMaPhong = objUser.PhongID;
                txtTenTruyCap.Text = objUser.UserName;
                dtNgaySinh.Value = objUser.NgaySinh;
                strPasswordOld = objUser.PassWordOld;
                txtEmail.Text = objUser.Email;
                txtDienThoai.Text = objUser.DienThoai;
                txtMatKhau.Text = objUser.PassWordOld;
                if (objUser.GioiTinh) cbGioiTinh.Text = "Nam";
                else cbGioiTinh.Text = "Nữ";
                txtTenTruyCap.Text = strMaNguoiDung;
                if (objUser.Status == "1") chkNgungSuDung.Checked = false;
                else chkNgungSuDung.Checked = true;
                DataTable tblChucVu;
                TuDienChucVu objChucVu = new TuDienChucVu();
                tblChucVu = objChucVu.LayDanhSach();
                cbChucVu.DisplayMember = "TenChucVu";
                cbChucVu.ValueMember = "ChucVuID";
                cbChucVu.DataSource = tblChucVu;
                try
                {
                    cbChucVu.SelectedValue = intMaChucVu;
                }
                catch
                {
                    cbChucVu.SelectedIndex = 0;
                }
                cbTrungTam.SelectedValue = objUser.TrungTamID;
                txtEXT.Text = objUser.LDAPAdsPath;
            }
            catch { }
        }
        /// <summary>
        /// Thoát khỏi chức năng thêm mới người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        /// </Modified>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Load thông tin người dùng trong hệ thống 
        /// Load danh sách phòng ban, chức vụ
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        ///     Namnh       26/06/08    Thêm trung tâm vào thông tin của người dùng
        /// </Modified>
        private void HeThong_NguoiDung_TaoMoi_Load(object sender, EventArgs e)
        {
            cbGioiTinh.SelectedIndex = 0;
            LoadPhongBan();
            LoadTrungTam();
            LoadThongTinNguoiDung(strUser_ID);
            if (intMaPhong != 0)
            {
                cbPhong.SelectedValue = intMaPhong;
            }
            CheckNguoiDung();
        }
        /// <summary>
        /// Kiem tra nguoi dung truyen vao su dung de hien thi dieu khien
        /// Sau nay bo sung them phan quyen va nguoi dung dang nhap vao de hien thi dieu khien
        /// </summary>
        private void CheckNguoiDung()
        {
            // Neu la tao moi nguoi dung thi an check ngung su dung
            if (strUser_ID == "")
            {
                chkNgungSuDung.Enabled = false;
            }
        }
        private void Clear()
        {
            txtTenTruyCap.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtQueQuan.Text = "";
            cbChucVu.SelectedIndex = 0;
            cbPhong.SelectedIndex = 0;
            txtEmail.Text = "";
        }
        /// <summary>
        /// Tien hanh cap nhat, tao moi nguoi dung
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    16/2/2008    Tạo mới
        ///     LamDS       21/05/2008  Thêm điều kiện kiểm tra người dùng đã tồn tại chưa
        /// </Modified>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenTruyCap.Text.Trim() == "")
                {
                    new MessageBoxBA().Show("Bạn chưa nhập tên truy cập", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                    txtTenTruyCap.Focus();
                    return;
                }
                if (txtHoTen.Text.Trim() == "")
                {
                    new MessageBoxBA().Show("Bạn chưa nhập họ tên người dùng", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                    txtHoTen.Focus();
                    return;
                }
                if (cbGioiTinh.Text == "")
                {
                    new MessageBoxBA().Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                    cbGioiTinh.Focus();
                    return;
                }
                Log objLog = new Log();
                //Kiem tra ma nguoi dung 
                // neu co ma nguoi dung truyen vao thi tien hanh cap nhat thong tin nguoi dung
                if (strUser_ID != "")
                {
                    objUser.UserName = txtTenTruyCap.Text.Trim();
                    // if (ChucVuKhongHopLe()) return;
                    objUser.PassWordOld = strPasswordOld;
                    objUser.PassWord = txtMatKhau.Text.Trim();
                    objUser.FullName = txtHoTen.Text.Trim();
                    if (chkNgungSuDung.Checked) objUser.Status = "0";
                    else objUser.Status = "1";
                    objUser.LDAPAdsPath = txtEXT.Text.Trim();
                    objUser.SecurityLevel = 0;
                    objUser.DiaChi = txtDiaChi.Text.Trim();
                    objUser.DienThoai = txtDienThoai.Text.Trim();
                    objUser.NgaySinh = dtNgaySinh.Value;
                    objUser.QueQuan = txtQueQuan.Text.Trim();
                    string strGoiTinh = cbGioiTinh.Text;
                    if (strGoiTinh.ToUpper() == "NAM") objUser.GioiTinh = true;
                    else objUser.GioiTinh = false;
                    int chucVuID = 0;
                    if (cbChucVu.SelectedValue != null)
                        int.TryParse(cbChucVu.SelectedValue.ToString(), out chucVuID);                    
                    objUser.ChucVUID = chucVuID;

                    int phongID = 0;
                    if (cbPhong.SelectedValue != null)
                        int.TryParse(cbPhong.SelectedValue.ToString(), out phongID);
                    objUser.PhongID = phongID;

                    objUser.Email = txtEmail.Text.Trim();
                    objUser.TrungTamID = 0;// int.Parse(cbTrungTam.SelectedValue.ToString());
                    if (txtMatKhau.Text != strPasswordOld)
                    {
                        //Kiểm tra password strength
                        if (Users.CheckPasswordStrength(txtMatKhau.Text) == false)
                        {
                            new MessageBoxBA().Show(Users.NOT_VALID_PASSWORD_STRENGTH, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                            txtMatKhau.Select();
                            return;
                        }
                        //Kiểm tra xác nhận mật khẩu
                        if (txtMatKhau.Text.Trim() != txtXacNhanMatKhau.Text.Trim())
                        {
                            new MessageBoxBA().Show("Đề nghị bạn xác nhận chính xác mật khẩu", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                            txtXacNhanMatKhau.Select();
                            return;
                        }
                    }
                    var intResult = objUser.UpdateUsers();
                    if (intResult == 0)
                    {
                        LoadThongTinNguoiDung(strUser_ID);
                        objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyNguoiDung_Sua,
                            DateTime.Now,
                            "Sửa thông tin người dùng " + objUser.UserName);
                        new MessageBoxBA().Show("Cập nhật thành công thông tin thay đổi của người dùng", "Thông báo", MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        Close();
                        HeThong_NguoiDung_QuanLy frmQuanLy = (HeThong_NguoiDung_QuanLy)Owner;
                        frmQuanLy.LoadUserData(frmQuanLy.CurentPhongBanID);
                    }
                    else
                    {
                        // Thong bao loi
                        new MessageBoxBA().Show("Cập nhật thất bại", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    }
                }
                else
                {
                    // tao moi nguoi dung he thong
                    objUser.UserName = txtTenTruyCap.Text.Trim();
                    // Nếu tên truy cập đã tồn tại thì không cho phép tạo mới
                    DataTable dtUser = objUser.GetUserInfo(objUser.UserName);
                    if (dtUser.Rows.Count > 0)
                    {
                        new MessageBoxBA().Show("Không thể tạo mới người dùng do tên truy cập đã tồn tại", "Thông báo",
                            MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        return;
                    }
                    //if (ChucVuKhongHopLe()) return;
                    objUser.PassWord = txtMatKhau.Text.Trim();
                    objUser.FullName = txtHoTen.Text.Trim();
                    objUser.Status = "1";
                    objUser.LDAPAdsPath = txtEXT.Text.Trim();
                    objUser.SecurityLevel = 0;
                    objUser.DiaChi = txtDiaChi.Text.Trim();
                    objUser.DienThoai = txtDienThoai.Text.Trim();
                    objUser.NgaySinh = dtNgaySinh.Value;
                    objUser.QueQuan = txtQueQuan.Text.Trim();
                    string strGoiTinh = cbGioiTinh.Text;
                    if (strGoiTinh.ToUpper() == "NAM") objUser.GioiTinh = true;
                    else objUser.GioiTinh = false;
                    int chucVuID = 0;
                    if (cbChucVu.SelectedValue != null)
                        int.TryParse(cbChucVu.SelectedValue.ToString(), out chucVuID);
                    objUser.ChucVUID = chucVuID;

                    int phongID = 0;
                    if(cbPhong.SelectedValue!=null)
                        int.TryParse(cbPhong.SelectedValue.ToString(), out phongID);
                    objUser.PhongID = phongID;
                    objUser.Email = txtEmail.Text.Trim();
                    objUser.TrungTamID = 1;// int.Parse(cbTrungTam.SelectedValue.ToString());
                    if (txtMatKhau.Text.Trim() != txtXacNhanMatKhau.Text.Trim())
                    {
                        new MessageBoxBA().Show("Đề nghị bạn xác nhận lại chính xác mật khẩu", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                        txtXacNhanMatKhau.Focus();
                        return;
                    }
                    var intResult = objUser.InsertUsers();
                    if (intResult == 0)
                    {
                        new MessageBoxBA().Show("Tạo mới thành công người dùng", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                        objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyNguoiDung_ThemMoi, DateTime.Now, "Thêm mới người dùng " + objUser.UserName);
                        Close();
                        HeThong_NguoiDung_QuanLy frmQuanLy = (HeThong_NguoiDung_QuanLy)Owner;
                        frmQuanLy.LoadUserData(frmQuanLy.CurentPhongBanID);
                    }
                    else
                    {
                        // Thong bao tao moi that bai
                        new MessageBoxBA().Show("Tạo mới thất bại", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnTaoMoi_Click", ex);                
            }
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của chức vụ người dùng được bổ nhiệm
        /// </summary>
        /// <returns>true nếu không hợp lệ, false nếu hợp lệ</returns>
        /// 
        private bool ChucVuKhongHopLe()
        {
            DataTable dtUser = objUser.GetAllUserInfo();
            // Nếu người dùng muốn bổ nhiệm là cục trưởng, cục phó, kiểm tra đã có ai là cục trưởng, phó chưa
            if (cbChucVu.SelectedValue.ToString() == "4" ||
                cbChucVu.SelectedValue.ToString() == "2")
            {
                foreach (DataRow drUser in dtUser.Rows)
                    if (drUser["User_ID"].ToString() != txtTenTruyCap.Text.Trim() &&
                        drUser["ChucVuID"].ToString() == cbChucVu.SelectedValue.ToString())
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Không thể tạo mới người dùng do chức vụ " + drUser["TenChucVu"]
                            + " đã cấp cho người dùng " + drUser["FULLNAME"], "Thông báo",
                            Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Error);
                        return true;
                    }
            }
            // Nếu chức vụ muốn bổ nhiệm là trưởng phòng, phó phòng kiểm tra trong phòng đã có chức vụ đó chưa
            if (cbChucVu.SelectedValue.ToString() == "1" ||
                cbChucVu.SelectedValue.ToString() == "3")
            {
                foreach (DataRow drUser in dtUser.Rows)
                    if (drUser["User_ID"].ToString() != txtTenTruyCap.Text.Trim() &&
                        drUser["ChucVuID"].ToString() == cbChucVu.SelectedValue.ToString()&&
                        drUser["PhongID"].ToString() == cbPhong.SelectedValue.ToString())
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Không thể tạo mới người dùng do chức vụ " + drUser["TenChucVu"]
                            + " đã cấp cho người dùng " + drUser["FULLName"], "Thông báo",
                            Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Error);
                        return true;
                    }
            }
            return false;
        }
        /// <summary>
        /// Lấy danh sách chức vụ thuộc phòng ban
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    28/2/2008    Tạo mới
        /// </Modified>
        private void cbPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int MaPhong = int.Parse(cbPhong.SelectedValue.ToString());
                LoadChucVu(MaPhong);
            }
            catch { }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}