using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Data.G5.DanhMuc;
using Taxi.GUI;
using Taxi.Business;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh.SystemAdmin
{
    public partial class CheckIn_CheckOut : Form
    {
        private bool g_Checkin = false;

        public CheckIn_CheckOut()
        {
            InitializeComponent();
            this.FormClosing += this.HeThong_DangNhap_FormClosing;
        }
        /// <summary>
        /// Thoát khỏi hệ thống
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {                   
            Application.Exit();
        }
        /// <summary>
        /// Su kien click dang nhap he thong
        /// Chuyen vao form chinh neu dang nhap thanh cong
        /// Xuất thong báo nếu đăng nhập thất bại
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin về username và password người dùng nhập vào
                string strUserName = txtTenDangNhap.Text.Trim();
                string strPassword = txtMatKhau.Text.Trim();
                // Kiểm tra xem có nhập username hay không
                if (strUserName.Length <= 0)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                    return;
                }
                // Kiểm tra xem có đăng nhập được không
                if (ThongTinDangNhap.ValidateLogin(strUserName, strPassword))
                {
                    LuuThongTinDangNhap();
                    this.g_Checkin = true;
                    this.Close();
                }
                else
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(ex.Message, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Stop);
            }
        }
        /// <summary>
        /// Luu lai thong tin dang nhap lan truoc neu nguoi dung check vao muc luu thong tin dang nhap
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void LuuThongTinDangNhap()
        {
            if (chkLuuMatKhau.Checked)
            {
                HeThong.MaHoa(txtMatKhau.Text.Trim());
                HeThong.MaHoa(txtTenDangNhap.Text.Trim());
            }
            // Bo qua khong luu vao registry
            #region Luu vao registry
            //string strRegistryKey = @"Software\CucTanSo";
            //if (chkLuuMatKhau.Checked)
            //{
            //    // chỉ lưu khi đã nhập tên đăng nhập
            //    if (txtTenDangNhap.Text.Length == 0) return;

            //    // Mã hóa mật khẩu 
            //    byte[] arrBytePassword = System.Text.Encoding.Unicode.GetBytes(txtMatKhau.Text);
            //    // Provide additional protection via entropy with another byte array:
            //    byte[] arrEntropy = { 4, 5, 7, 9, 4, 5, 7, 9 }; //Save this for unprotecting later                    
            //    byte[] arrByteProtected = ProtectedData.Protect(arrBytePassword, arrEntropy, DataProtectionScope.CurrentUser);
            //    string strPasswordProtected = System.Text.Encoding.Unicode.GetString(arrByteProtected);

            //    RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegistryKey, true);

            //    if (key == null)
            //    {
            //        key = Registry.CurrentUser.CreateSubKey(strRegistryKey);
            //    }

            //    try
            //    {
            //        byte[] arrUsername = System.Text.Encoding.Unicode.GetBytes(txtTenDangNhap.Text);

            //        // Lưu tên đăng nhập
            //        key.SetValue("TenDangNhap", arrUsername, RegistryValueKind.Binary);
            //        // Lưu mật khẩu
            //        key.SetValue("MatKhau", arrByteProtected, RegistryValueKind.Binary);
            //    }
            //    catch
            //    {
            //        // bỏ qua
            //    }
            //    finally
            //    {
            //        if (key != null)
            //            key.Close();
            //    }

            //}
            //else
            //{
            //    RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegistryKey, true);

            //    if (key == null)
            //    {
            //        key = Registry.CurrentUser.CreateSubKey(strRegistryKey);
            //    }

            //    try
            //    {
            //        // Lưu tên đăng nhập
            //        key.SetValue("TenDangNhap", new byte[0]);
            //        // Lưu mật khẩu
            //        key.SetValue("MatKhau", new byte[0]);

            //    }
            //    catch
            //    {
            //        // Bỏ qua
            //    }
            //    finally
            //    {
            //        if (key != null)
            //            key.Close();
            //    }
            //}
            #endregion
        }
        /// <summary>
        /// Load thông tin đăng nhập lần trước
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        /// </summary>
        private void HeThong_DangNhap_Load(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() != "")
            {
                chkLuuMatKhau.Checked = true;
            }
            txtTenDangNhap.Focus();
            
            #region Load mat khau tu registry
            //string strRegistryKey = @"Software\CucTanSo";
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegistryKey, true))
            //{
            //    if (key != null)
            //    {

            //        // lấy tên đăng nhập
            //        byte[] arrUsername = (byte[])key.GetValue("TenDangNhap", new byte[0]);
            //        if (arrUsername.Length == 0)
            //            txtTenDangNhap.Text = "";
            //        else
            //            txtTenDangNhap.Text = System.Text.Encoding.Unicode.GetString(arrUsername);

            //        // giải mã mật khẩu lưu trong registry
            //        byte[] arrPasswordProtected = (byte[])key.GetValue("MatKhau", new byte[0]);
            //        if (arrPasswordProtected.Length == 0)
            //        {
            //            txtMatKhau.Text = "";
            //            return;
            //        }
            //        byte[] arrEntropy = { 4, 5, 7, 9, 4, 5, 7, 9 };
            //        byte[] arrPassword = ProtectedData.Unprotect(arrPasswordProtected, arrEntropy, DataProtectionScope.CurrentUser);
            //        // hiển thị mật khẩu trên txtMatKhau
            //        txtMatKhau.Text = System.Text.Encoding.Unicode.GetString(arrPassword);
            //        // check chkLuuMatKhau
            //        chkLuuMatKhau.Checked = true;
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Vào form cấu hình hệ thống
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        /// </summary>
        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            HeThong_CauHinh_QuanLy frmCauHinh = new HeThong_CauHinh_QuanLy();
            frmCauHinh.ShowDialog();
        }
        private void HeThong_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (g_Checkin == false) e.Cancel = true;
            }
        }        
    }
}
