using System;
using System.Collections;
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
    /// Quản lý vài trò của hệ thống. Cấp các quyền truy cập cho từng vai trò.
    /// Cấp quyền cho từng người dùng với từng vai trò
    /// </summary>
    /// <Modified>
    ///     Author      Date        Comments
    ///     Cuongdb    14/2/2008    Tạo mới
    /// </Modified>
    public partial class HeThong_VaiTro_QuanLy : Form
    {
        // Khai báo các biến dùng trong hệ thống
        private Roles objRoles = new Roles();
        private Users objUsers = new Users();
        private Permission objPermission = new Permission();
        private UserRole objUserRole = new UserRole();
        private int CurrentPhongID = 0;
        // Khai báo mã vai trò dùng trong form
        private string strRoleID = "";
        private Form mFormGoi;

        // Khởi tạo form quản lý vai trò
        public HeThong_VaiTro_QuanLy(Form FormGoi)
        {
            mFormGoi = FormGoi;
            InitializeComponent();
            CenterToScreen();
        }
        /// <summary>
        /// Vào chức năng thêm mới vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnThemVaiTro_Click(object sender, EventArgs e)
        {
            // chuyển đến form thêm mới vai trò
            HeThong_Vaitro_TaoMoi frmVaiTroTaoMoi = new HeThong_Vaitro_TaoMoi();
            frmVaiTroTaoMoi.ShowDialog();
            LoadRoleData();
        }
        /// <summary>
        /// Vào chức năng sửa vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>

        private void btnSuaVaiTro_Click(object sender, EventArgs e)
        {
            // chuyển đến form cập nhật vai trò
            HeThong_Vaitro_TaoMoi frmVaiTroCapNhat = new HeThong_Vaitro_TaoMoi(strRoleID);
            frmVaiTroCapNhat.ShowDialog();
            LoadRoleData();
        }
        #region Load du lieu ban dau
        /// <summary>
        ///  Load danh sách vai trò hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>

        private void LoadRoleData()
        {
            strRoleID = "";
            // Add Roles vào list box
            DataTable tabRoles;
            objRoles.RoleID = "";
            tabRoles = objRoles.GetRoles();
            ltbDSVaitro.DataSource = null;
            ltbDSVaitro.DisplayMember = "ROLE_NAME";
            ltbDSVaitro.ValueMember = "ROLE_ID";
            ltbDSVaitro.DataSource = tabRoles;
            ltbDSVaitro.SelectedIndex = 0;
        }
        /// <summary>
        /// Load danh sách người dùng hệ thống có vai trò là đã chọn trong danh sách vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>

        private void LoadUserData(int PhongID)
        {
            try
            {
                // Lấy vai trò được chọn
                objUserRole.RoleID = strRoleID;
                // Add Roles to ltbNguoiDuocCap
                DataTable tabUserByRole;
                tabUserByRole = objUserRole.GetUserByRole(PhongID);
                ltbNguoiDuocCap.DataSource = null;
                ltbNguoiDuocCap.DisplayMember = "FULLNAME";
                ltbNguoiDuocCap.ValueMember = "USER_ID";
                ltbNguoiDuocCap.DataSource = tabUserByRole;
                // Add Users to ltbNguoiKoCap
                DataTable tabUserNotInRole;
                tabUserNotInRole = objUserRole.GetUserNotInRole(PhongID);
                ltbNguoiKoCap.DataSource = null;
                ltbNguoiKoCap.DisplayMember = "FULLNAME";
                ltbNguoiKoCap.ValueMember = "USER_ID";
                ltbNguoiKoCap.DataSource = tabUserNotInRole;
            }
            catch { }
        }
        /// <summary>
        /// Lấy danh sách các quyền được cấp với vai trò đã chọn
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>

        private void LoadPermissionAssignedData()
        {
            try
            {
                // Lấy vai trò đã chọn
                objRoles.RoleID = strRoleID;
                // Add Permission to ltbQuyenDuocCap
                DataTable tabRolePermission;
                tabRolePermission = objRoles.GetRolePermission();
                ltbQuyenDuocCap.DataSource = null;
                ltbQuyenDuocCap.DisplayMember = "PERMISSION_NAME";
                ltbQuyenDuocCap.ValueMember = "PERMISSION_ID";
                ltbQuyenDuocCap.DataSource = tabRolePermission;
                
                //Lấy danh sách quyền không được cấp
                DataTable tabRoleNotPermission;
                tabRoleNotPermission = objRoles.GetPermissionNotInRole();
                //Bổ xung thêm các quyền cha
                DataTable dtPermission = objPermission.GetAll();
                bool bNotExist;
                for (int i = dtPermission.Rows.Count - 1; i >= 0; i--)
                {
                    bNotExist = true;
                    for (int j = 0; j < tabRoleNotPermission.Rows.Count; j++)
                        if (tabRoleNotPermission.Rows[j]["PERMISSION_ID"].ToString().IndexOf(
                            dtPermission.Rows[i]["PERMISSION_ID"].ToString()) == 0)
                        {
                            bNotExist = false;
                            break;
                        }
                    if (bNotExist)
                        dtPermission.Rows.RemoveAt(i);
                }
                ltbQuyenKoCap.DataSource = null;
                ltbQuyenKoCap.DisplayMember = "PERMISSION_NAME";
                ltbQuyenKoCap.ValueMember = "PERMISSION_ID";
                ltbQuyenKoCap.DataSource = dtPermission;
            }
            catch { }
        }
        #endregion
        /// <summary>
        /// Load ra danh sách vai trò, các quyền và người dùng thuộc vai trò sau khi form được khở tạo
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>

        private void HeThong_VaiTro_QuanLy_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
            LoadRoleData();
            //LoadUserData(0);
            //LoadPermissionAssignedData();
        }
        /// <summary>
        /// Load danh sách các phòng ban
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    29/2/2008    Tạo mới
        /// </Modified>

        private void LoadPhongBan()
        {
            TuDienPhong objPhong = new TuDienPhong();
            DataTable tblPhong = objPhong.LayDanhSach();
            DataRow row = tblPhong.NewRow();
            row["TenPhong"] = "Tất cả phòng ban";
            row["PhongID"] = "0";
            tblPhong.Rows.InsertAt(row, 0);
            cbPhongBan.DisplayMember = "TenPhong";
            cbPhongBan.ValueMember = "PhongID";
            cbPhongBan.DataSource = tblPhong;

        }
        /// <summary>
        /// Load ra danh sáchcác quyền và người dùng thuộc vai trò sau khi fthay đổi vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void ltbDSVaitro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbPhongBan.SelectedIndex = 0;
                strRoleID = ltbDSVaitro.SelectedValue.ToString().Trim();
                LoadUserData(CurrentPhongID);
                LoadPermissionAssignedData();
            }
            catch { }
        }
        /// <summary>
        /// Thoát khỏi chức năng quản lý vai trò
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
        /// Thêm mới 1 số quyền vào 1 vai trò
        /// Nếu quyền là quyền cha thì thêm hết các quyền con
        /// Nếu quyền là quyền con thì thêm quyền cha
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        ///     LamDS       10/05/2008  Sửa theo sumary
        /// </Modified>
        private void btnThem1Quyen_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ra danh sách mã các quyền được chọn
                string strPermissionIDs = "";
                string strPermissionID;

                DataTable dtPermission = objPermission.GetAll();
                foreach (DataRowView item in ltbQuyenKoCap.SelectedItems)
                {
                    DataRow drQuyen = item.Row;
                    strPermissionID = drQuyen["PERMISSION_ID"].ToString().Trim();
                    strPermissionIDs = strPermissionIDs + strPermissionID + ",";
                    foreach (DataRow drPermission in dtPermission.Rows)
                    {
                        // Add quyền con
                        if (drPermission["PERMISSION_ID"].ToString().IndexOf(strPermissionID) == 0)
                            strPermissionIDs += drPermission["PERMISSION_ID"].ToString() + ',';
                        // Add quyền cha
                        if (strPermissionID.IndexOf(drPermission["PERMISSION_ID"].ToString()) == 0)
                            strPermissionIDs += drPermission["PERMISSION_ID"].ToString() + ',';
                    }
                }
                objRoles.RoleID = strRoleID;
                // gán danh sách quyền
                objRoles.PermissionIDs = strPermissionIDs;
                // Thêm mới quyền
                objRoles.InsertRolePermission();
            }
            catch (Exception ex)
            { 
            }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Thêm mới tất cả các quyền còn lại vào vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnThemNhieuQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách tất cả cac quyền còn lại
                string strPermissionIDs = "";
                foreach (DataRowView item in ltbQuyenKoCap.Items)
                {
                    DataRow drQuyen = item.Row;
                    strPermissionIDs = strPermissionIDs + drQuyen["PERMISSION_ID"].ToString().Trim() + ",";
                }
                objRoles.RoleID = strRoleID;
                objRoles.PermissionIDs = strPermissionIDs;
                // Thêm các quyền này vào vai trò
                objRoles.InsertRolePermission();
            }
            catch { }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Loại tất cả các quyền ra khỏi vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnLoaiNhieuQuen_Click(object sender, EventArgs e)
        {
            try
            {
                // xóa quyền của vai trò đwocj chọn
                objRoles.RoleID = strRoleID;
                objRoles.DeleteRolePermission();
            }
            catch { }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// TLoại 1 số quyền ra khỏi 1 vai trò đã chọn
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnLoai1Quyen_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách tất cả cac quyền cần loại
                string strPermissionIDs = "";
                string strPermissionID;
                DataTable dtPermission = objPermission.GetAll();
                foreach (DataRowView item in ltbQuyenDuocCap.SelectedItems)
                {
                    DataRow drQuyen = item.Row;
                    strPermissionID = drQuyen["PERMISSION_ID"].ToString().Trim();
                    strPermissionIDs = strPermissionIDs + strPermissionID + ",";

                    // Loại quyền cha thì loại thêm các quyền con
                    foreach (DataRow drPermission in dtPermission.Rows)
                    {
                        // Add quyền con vào xâu loại
                        if (drPermission["PERMISSION_ID"].ToString().IndexOf(strPermissionID) == 0)
                            strPermissionIDs += drPermission["PERMISSION_ID"].ToString() + ',';
                    }
                }
                objRoles.RoleID = strRoleID;
                objRoles.PermissionIDs = strPermissionIDs;
                // Loại các quyền này từ vai trò
                objRoles.DeleteSomePermissionInRole();
            }
            catch { }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Thực hiện chức năng xóa vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnXoaVaiTro_Click(object sender, EventArgs e)
        {
            string result = new Taxi.MessageBox.MessageBoxBA().Show("Bạn có chắc chắn xóa vai trò này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
            if (result == DialogResult.Yes.ToString ())
            {
                try
                {
                    DataTable tabRole = new DataTable();
                    objRoles.RoleID = strRoleID;
                    tabRole = objRoles.GetRoles();
                    objRoles.DeleteRolePermission();
                    objUserRole.RoleID = strRoleID;
                    objUserRole.DeleteUserByRole();
                    if (objRoles.DeleteRoles() == 0)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Đã xóa thành công vai trò được chọn", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        //Ghi log
                        Log objLog = new Log();
                        objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyVaiTro_Xoa,
                            DateTime.Now, "Xóa vai trò " + strRoleID);
                    }
                }
                catch
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Bạn không thể xóa vai trò này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                }
                LoadRoleData();
            }
        }
        /// <summary>
        /// Thêm mới 1 số người vào 1 vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnThem1NguoiDuocCap_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách tất cả người dùng đã chọn
                string strUserIDs = "";
                foreach (DataRowView item in ltbNguoiKoCap.SelectedItems)
                {
                    DataRow drNguoiDung = item.Row;
                    strUserIDs = strUserIDs + drNguoiDung["USER_ID"].ToString().Trim() + ",";
                }
                //strUserIDs = strUserIDs.Remove(strUserIDs.Length - 1);
                // Tiến hành gán thông tin và thêm người dùng vào vai trò
                objUserRole.UserIDs = strUserIDs;
                objUserRole.UserIDsDel = "";
                objUserRole.GrantUserID = "Admin";
                objUserRole.InsertUserByRole();
            }
            catch { }
            LoadUserData(CurrentPhongID);
        }
        /// <summary>
        /// Thêm mới tất cả người dùng vào 1 vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnThemNhieuNguoiDuocCap_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tất cả người dùng trong hệ thống chưa cấp vai trò đã chọn
                string strUserIDs = "";
                foreach (DataRowView item in ltbNguoiKoCap.Items)
                {
                    DataRow drNguoiDung = item.Row;
                    strUserIDs = strUserIDs + drNguoiDung["USER_ID"].ToString().Trim() + ",";
                }
                //Tiến hành gán thông tin và thêm ngwoif vào vai trò
                objUserRole.UserIDs = strUserIDs + "";
                objUserRole.UserIDsDel = "";
                objUserRole.GrantUserID = "Admin";
                objUserRole.InsertUserByRole();
            }
            catch { }
            LoadUserData(CurrentPhongID);
        }
        /// <summary>
        /// Xóa 1 số người trong vai trò đã chọn
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>

        private void btnLoai1Nguoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách ngwoif dùng cần xóa
                string strUserIDs = "";
                foreach (DataRowView item in ltbNguoiDuocCap.SelectedItems)
                {
                    DataRow drNguoiDung = item.Row;
                    strUserIDs = strUserIDs + drNguoiDung["USER_ID"].ToString().Trim() + ",";
                }
                // gán thông tin và xóa người dùng khỏi vai trò
                objUserRole.UserIDs = "";
                objUserRole.UserIDsDel = strUserIDs + "";
                objUserRole.GrantUserID = "Admin";
                objUserRole.InsertUserByRole();
            }
            catch { }
            LoadUserData(CurrentPhongID);
        }
        /// <summary>
        /// Xóa tất cả nguoi dùng trong vai trò này
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnLoaiNhieuNguoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách tất cả người dùng đang có trong vai trò này
                string strUserIDs = "";
                foreach (DataRowView item in ltbNguoiDuocCap.Items)
                {
                    DataRow drNguoiDung = item.Row;
                    strUserIDs = strUserIDs + drNguoiDung["USER_ID"].ToString().Trim() + ",";
                }
                // Xóa người dùng
                objUserRole.UserIDs = "";
                objUserRole.UserIDsDel = strUserIDs + "";
                objUserRole.GrantUserID = "Admin";
                objUserRole.InsertUserByRole();
            }
            catch { }
            LoadUserData(CurrentPhongID);
        }
        /// <summary>
        /// Load ra danh sách người dùng thuộc phòng ban sau khi thay đổi phòng ban
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void cbPhongBan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentPhongID = int.Parse(cbPhongBan.SelectedValue.ToString());
                LoadUserData(CurrentPhongID);
            }
            catch { }
        }

        /// <summary>
        /// Chuyển sang form quản lý người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void lnklblNguoiDung_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Visible = false;
            HeThong_NguoiDung_QuanLy frmQLyNguoiDung = new HeThong_NguoiDung_QuanLy(mFormGoi);
            frmQLyNguoiDung.ShowDialog(mFormGoi);
        }
    }
}