using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
 
namespace Taxi.GUI
{
    /// <summary>
    /// Cập nhât thông tin cá nhân người dùng
    /// </summary>
    /// <Modified>
    ///     Author      Date        Comments
    ///     TuanND      29/4/2008    Tạo mới
    /// </Modified>
    public partial class CapNhatThongTinCaNhan : Form
    {
        // Khai báo các biến
        private string strUser_ID = ThongTinDangNhap.USER_ID;
       /// <summary>
       /// Hàm khởi tạo
       /// Hiển thị thông tin phòng ban
       /// Hiển thị thông tin chức vụ
       /// Load thông tin người dùng
       /// </summary>
        public CapNhatThongTinCaNhan()
        {
            InitializeComponent();
            HienThiPhongBan();
            HienThiChucVu();
            cbGioiTinh.SelectedIndex = 0;
            LoadThongTinNguoiDung(strUser_ID);
        }

        /// <summary>
        /// Load danh sách các phòng ban
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    29/4/2008    Tạo mới
        /// </Modified>
        private void HienThiPhongBan()
        {
            TuDienPhong objPhong = new TuDienPhong();
            DataTable tblPhong = objPhong.LayDanhSach();
            cbPhong.DataSource = tblPhong;
            cbPhong.DisplayMember = "TenPhong";
            cbPhong.ValueMember = "PhongID";
            
        }
        /// <summary>
        /// Load danh sách các chức vụ
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    29/4/2008    Tạo mới
        /// </Modified>
        private void HienThiChucVu()
        {
            TuDienChucVu objChucVu = new TuDienChucVu();
            DataTable tblChucVu = objChucVu.LayDanhSach();
            cbChucVu.DataSource = tblChucVu;
            cbChucVu.DisplayMember = "TenChucVu";
            cbChucVu.ValueMember = "ChucVuID";
        }
        /// <summary>
        /// Load thông tin người dùng lên các control
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    29/4/2008    Tạo mới
        /// </Modified>
        private void LoadThongTinNguoiDung(string strMaNguoiDung)
        {
            try
            {
                // kiem tra ma nguoi dung truyen vao
                if (strMaNguoiDung != "")
                {
                    Users objUser = new Users(strMaNguoiDung);
                    txtTenTruyCap.Text = objUser.UserName;
                    txtHoTen.Text = objUser.FullName;
                    dtNgaySinh.Value = objUser.NgaySinh;
                    if (objUser.GioiTinh) cbGioiTinh.Text = "Nam";
                    else cbGioiTinh.Text = "Nữ";
                    txtDienThoai.Text = objUser.DienThoai;
                    txtEmail.Text = objUser.Email;
                    txtDiaChi.Text = objUser.DiaChi;
                    txtQueQuan.Text = objUser.QueQuan;
                    //Hiển thị chức vụ
                    try
                    {
                        cbChucVu.SelectedValue = objUser.ChucVUID;
                    }
                    catch
                    {
                        cbChucVu.SelectedIndex = 0;
                    }
                    //Hiển thị phòng 
                    try
                    {
                        cbPhong.SelectedValue = objUser.PhongID;
                    }
                    catch
                    {
                        cbPhong.SelectedIndex = 0;
                    }
                }
            }
            catch { }
        }
        //Thoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Kiểm tra xem người dùng có muốn thay đổi password không
        /// </summary>
        private void chkDoiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            gbMatKhau.Enabled = chkDoiMatKhau.Checked;
        }
        /// <summary>
        /// Kiểm tra thông tin mật khẩu người dùng nhập
        /// </summary>
        /// <param name="objUser">đối tượng người dùng</param>
        /// <returns>true: thông tin đúng, false: thông tin sai</returns>
        public bool KiemTraMatKhau(Users objUser)
        {
            bool blnKetQua = true;
            // kiểm tra mật khẩu cũ 
            if (StringTools.EncryptPassword(txtMatKhauCu.Text.Trim()) != objUser.PassWordOld)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Mật khẩu cũ không đúng!", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                txtMatKhau.Select();
                blnKetQua= false;
            }
            // Kiểm tra password strengh
            blnKetQua = Users.CheckPasswordStrength(txtMatKhau.Text);
            if (blnKetQua == false)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(Users.NOT_VALID_PASSWORD_STRENGTH, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                txtMatKhau.Select();
            }
            return blnKetQua;
        }
        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (validator.Validate())
            {
                Users objUser = new Users(strUser_ID);

                objUser.FullName = txtHoTen.Text.Trim();
                objUser.NgaySinh = dtNgaySinh.Value;
                //Lấy thông tin giới tính
                string strGioiTinh = cbGioiTinh.Text;
                if (strGioiTinh.ToUpper() == "NAM") objUser.GioiTinh = true;
                else objUser.GioiTinh = false;
                objUser.QueQuan = txtQueQuan.Text.Trim();
                objUser.DiaChi = txtDiaChi.Text.Trim();
                objUser.DienThoai = txtDienThoai.Text.Trim();
                objUser.Email = txtEmail.Text.Trim();

                //Kiểm tra xem người dùng có muốn thay đổi mật khẩu hay không
                if (chkDoiMatKhau.Checked)
                {
                    bool blnKiemTra = KiemTraMatKhau(objUser);
                    if (blnKiemTra)
                    {
                        objUser.PassWord = txtMatKhau.Text.Trim();
                    }
                    else
                    {
                        return;
                    }
                }
                //Bắt đầu cập nhật thông tin
                try
                {
                    int intResult;
                    intResult = objUser.UpdateUsers();
                    if (intResult == 0)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật thành công!", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        Log objLog = new Log();
                        objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.HeThong_ThayDoiThongTinCaNhan,
                            DateTime.Now, "Thay đổi thông tin cá nhân");
                        //this.Close();
                    }
                    else
                    {
                        // Thong bao loi
                        new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật thất bại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                catch (Exception ex)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Có lỗi phát sinh trong quá trình cập nhật thông tin", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
        }//end CapNhat_Click


    }// Exit class
}