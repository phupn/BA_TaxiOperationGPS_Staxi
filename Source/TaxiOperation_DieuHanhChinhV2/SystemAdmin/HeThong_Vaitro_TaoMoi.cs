using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
 

namespace Taxi.GUI 
{
    /// <summary>
    /// Quản lý nhóm vai trò : Thêm mới và sửa tên vai trò
    /// </summary>
    /// <Modified>
    ///     Author      Date        Comments
    ///     Cuongdb    14/2/2008    Tạo mới
    /// </Modified>
        
	public partial class HeThong_Vaitro_TaoMoi: Form {

        private string strRoleID = "";
        /// <summary>
        /// Khởi tạo form
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
    
		public HeThong_Vaitro_TaoMoi() 
        {
			InitializeComponent();
		}
        /// <summary>
        /// Khởi tạo form vai trò với vai trò cần cập nhật thay đổi
        /// </summary>
        /// <param name="MaVaiTro"> Mã vai trò cần cập nhật thay đổi </param>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
    
		public HeThong_Vaitro_TaoMoi(string MaVaiTro)
        {
			InitializeComponent();
            strRoleID = MaVaiTro;
			this.btnTaoMoi.Text = "Cập nhật";
			this.Text = "Sửa thông tin vai trò";
		}
        /// <summary>
        /// Thoát khỏi chức năng tạo mới vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
    
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Tạo mới 1 vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
    
        private void TaoMoi() 
        {
            // Khởi tạo đối tượng vại trò
            Roles objRole = new Roles();
            // Gán các thông tin cho vai trò
            objRole.Description = txtMoTa.Text.Trim();
            objRole.RoleName = txtTenNhomQuyenDayDu.Text.Trim();
            objRole.RoleID = txtTenNhomQuyen.Text.Trim();
            // Thêm mới vai trò
            int intResult = objRole.InsertRoles();
            // Nếu tạo mới thành công xuất ra thông báo và ghi log hệ thống
            if (intResult == 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Tạo mới thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                this.Close();
                //Tiến hành ghi log
                Log objLog = new Log();
                objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyVaiTro_ThemMoi, DateTime.Now,
                    "Thêm mới vai trò " + txtTenNhomQuyen.Text.Trim());
            }
            else 
            {
                // Tạo mới thất bại, xuất thông báo
                new Taxi.MessageBox.MessageBoxBA().Show("Tạo mới thất bại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }
        /// <summary>
        /// Cập nhật thông tin thay đổi vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
    
        private void CapNhat(string MaVaiTro) 
        {
            Roles objRole = new Roles();
            objRole.RoleID = MaVaiTro;
            objRole.Description = txtMoTa.Text.Trim();
            objRole.RoleName = txtTenNhomQuyenDayDu.Text.Trim();
            // Cập nhật vai trò
            int intResult = objRole.UpdateRoles();
            // Nếu cập nhật thành công xuất ra thông báo và ghi log hệ thống
            if (intResult == 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                Log objLog = new Log();
                objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyVaiTro_Sua, DateTime.Now,
                    "Sửa vai trò " + strRoleID);
                this.Close();
                // tiến hành ghi log
            }
            else
            {
                // Cập nhật thất bại, xuất thông báo
                new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật thất bại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }
        /// <summary>
        /// Sự kiện thêm mới, cập nhật vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập tên nhóm quyền chưa
            if (txtTenNhomQuyen.Text.Trim() == "") 
            {
                // Nếu chưa nhập tên thì ngừng việc cập nhật
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn chưa nhập tên nhóm quyền","Thông Báo",Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Warning);
                // Trả về focus cho tên nhóm quyền
                txtTenNhomQuyen.Focus();
                return;
            }
            // Kiểm tra xem đã nhập tên đầy đủ của nhóm quyền chưa
            if (txtTenNhomQuyenDayDu.Text.Trim() == "")
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn chưa nhập tên đầy đủ của nhóm quyền", "Thông Báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                txtTenNhomQuyenDayDu.Focus();
                return;
            }
            // Kiểm tra xem mã vai trò truyên vào bao đầu
            if (strRoleID != "")
            {
                // Nếu truyền vào mã vai trò thì tiến hành cập nhật
                CapNhat(strRoleID);
            }
            else 
            {
                // atọ mới vai trò
                TaoMoi();
            }
        }

        /// <summary>
        /// Load thông tin vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void LoadThongTin() 
        {
            if (strRoleID != "") 
            {
                Roles objRole = new Roles();
                objRole.RoleID = strRoleID;
                DataTable tblRole = objRole.GetRoles();
                DataRow drRole = tblRole.Rows[0];
                txtTenNhomQuyen.Text = strRoleID;
                txtTenNhomQuyen.ReadOnly = true;
                txtTenNhomQuyenDayDu.Text = drRole["ROLE_NAME"].ToString().Trim();
                txtMoTa.Text = drRole["DESCRIPTION"].ToString().Trim();
            }
        }
        private void HeThong_Vaitro_TaoMoi_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }
	}
}