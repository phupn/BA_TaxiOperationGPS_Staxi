using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using System.Data.SqlClient;
using System.Configuration;
 

namespace Taxi.GUI 
{
    /// <summary>
    /// Chức năng quản lý cấu hình hệ thống
    /// Cuongdb    20/2/2008
    /// </summary>
	public partial class HeThong_CauHinh_QuanLy: Form 
    {
        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        private HeThong objHeThong = new HeThong();
		public HeThong_CauHinh_QuanLy() 
        {
			InitializeComponent();
		}

		private void btnThoat_Click(object sender, EventArgs e) {
			Close();
		}
        /// <summary>
        /// Load cấu hình ban đầu của hệ thống
        /// Cuongdb     22/2/2008
        /// </summary>
        private void LoadThongTinHeThong() 
        {
            txtDiaChiCSDL.Text = HeThong.GiaiMa(config.AppSettings.Settings["DiaChiCSDL"].Value.Trim());
            txtTenCSDL.Text = HeThong.GiaiMa(config.AppSettings.Settings["TenCSDL"].Value.Trim());
            txtTenNguoiDung.Text = HeThong.GiaiMa(config.AppSettings.Settings["User_ID"].Value.Trim());
            txtMatKhau.Text = HeThong.GiaiMa(config.AppSettings.Settings["MatKhau"].Value.Trim());
        }

        private void HeThong_CauHinh_QuanLy_Load(object sender, EventArgs e)
        {
			//GiaoDienChinh frmMain = this.ParentForm as GiaoDienChinh;
			//if (frmMain.ActiveMdiChild != null)
			//    frmMain.ActiveMdiChild.Close();

            LoadThongTinHeThong();
        }
        /// <summary>
        /// Lưu lại cấu hình hệ thống
        /// Cuongdb     22/2/2008
        /// </summary>
        private void LuuCauHinh() 
        {
            try
            {
                string StrConn = "Data Source=" + txtDiaChiCSDL.Text.Trim() + ";Initial Catalog=" + txtTenCSDL.Text.Trim() + ";User ID=" + txtTenNguoiDung.Text.Trim() + ";Password=" + txtMatKhau.Text.Trim();
                //string MatKhau = Strings.EncryptPassword(txtMatKhau.Text.Trim());
                config.AppSettings.Settings["DiaChiCSDL"].Value = HeThong.MaHoa(txtDiaChiCSDL.Text.Trim());
                config.AppSettings.Settings["TenCSDL"].Value = HeThong.MaHoa(txtTenCSDL.Text.Trim());
                config.AppSettings.Settings["User_ID"].Value = HeThong.MaHoa(txtTenNguoiDung.Text.Trim());
                config.AppSettings.Settings["MatKhau"].Value = HeThong.MaHoa(txtMatKhau.Text.Trim());
                config.AppSettings.Settings["Conn"].Value = StrConn;
                config.Save(ConfigurationSaveMode.Modified);
                new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật thay đổi tham số hệ thống thành công. Chương trình sẽ khởi động lại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                Application.Restart();
            }
            catch 
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Không cập nhật được thay đổi tham số hệ thống", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }
        /// <summary>
        /// Kiểm tra cấu hình cơ sở dữ liệu có hợp lệ hay không
        /// </summary>
        /// <param name="strCon"></param>
        /// <returns>
        /// Ket noi thanh cong tra ve true
        /// That bai tra ve false
        /// </returns>
        private bool KiemTraCauHinh(string strCon) 
        {
            SqlConnection Conn;
            Conn = new SqlConnection(strCon);
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Lưu lại cấp hình hệ thống
        /// Cuongdb    
        /// </summary>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string StrConn = "Data Source=" + txtDiaChiCSDL.Text.Trim() + ";Initial Catalog=" + txtTenCSDL.Text.Trim() + ";User ID=" + txtTenNguoiDung.Text.Trim() + ";Password=" + txtMatKhau.Text.Trim();
            if (KiemTraCauHinh(StrConn))
            {
                LuuCauHinh();
                Log objLog = new Log();
                objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.HeThong_ThietLapCauHinhCSDL,
                    DateTime.Now, "Thay đổi cấu hình CSDL");
                this.Close();
            }
            else 
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Cấu hình không hợp lệ. Bạn không thể lưu cấu hình này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }
        /// <summary>
        /// Sự kiện kiểm tra tính hợp lệ của cấu hình
        /// Cuongdb
        /// </summary>
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string StrConn = "Data Source=" + txtDiaChiCSDL.Text.Trim() + ";Initial Catalog=" + txtTenCSDL.Text.Trim() + ";User ID=" + txtTenNguoiDung.Text.Trim() + ";Password=" + txtMatKhau.Text.Trim();
            if (KiemTraCauHinh(StrConn))
            {
                string  result = new Taxi.MessageBox.MessageBoxBA().Show("Kết nối thành công. Bạn có muốn lưu lại cấu hình cơ sở dữ liệu này không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                if (result.ToString().ToUpper() == "YES")
                {
                    LuuCauHinh();
                    Log objLog = new Log();
                    objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.HeThong_ThietLapCauHinhCSDL,
                        DateTime.Now, "Thay đổi cấu hình CSDL");
                }
            }
            else 
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Kết nối thất bại. Bạn không thể truy cập vào cơ sở dữ liệu này?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Error);
            }

        }
	}
}