 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using TaxiOperation_DieuHanhChinh.SystemAdmin;
namespace Taxi.GUI
{
    /// <summary>
    /// Quản lý người dùng trong hệ thống : Cấp quyền cho người dùng, thêm sửa xóa thông tin người dùng
    /// </summary>
    /// <Modified>
    ///     Author      Date        Comments
    ///     Cuongdb    14/2/2008    Tạo mới
    /// </Modified>
    public partial class HeThong_NguoiDung_QuanLy : Form
    {
        // Khai báo các biến dùng trong form
        private Users objUsers = new Users();
        private UserRole objUserRole = new UserRole();
        private UserPermission objUserPermission = new UserPermission();
        public int CurentPhongBanID = 0;
        private string strUserName = "";
        private Form mFormGoi;

        public HeThong_NguoiDung_QuanLy(Form FormGoi)
        {
            mFormGoi = FormGoi;
            InitializeComponent();
            CenterToScreen();
        }
        /// <summary>
        /// Click chuyển đến form thêm mới người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnThem_Click(object sender, EventArgs e)
        {
            // khởi tạo form thêm người dùng
            HeThong_NguoiDung_TaoMoi nguoiDung = new HeThong_NguoiDung_TaoMoi();
            nguoiDung.ShowDialog(this);
            //if (nguoiDung.ShowDialog()!= DialogResult.Cancel)
            //    LoadUserData(CurentPhongBanID);
        }
        /// <summary>
        /// Click chuyển đến form sửa đổi thông tin người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void btnSua_Click(object sender, EventArgs e)
        {
            HeThong_NguoiDung_TaoMoi nguoiDung = new HeThong_NguoiDung_TaoMoi(strUserName);
            nguoiDung.Text = "Sửa thông tin người dùng";
            nguoiDung.Controls["btnTaoMoi"].Text = "Cập nhật";
            nguoiDung.ShowDialog(this);
            //DialogResult mResult = nguoiDung.ShowDialog();
            //if(mResult != DialogResult.Cancel) LoadUserData(CurentPhongBanID);
        }
        /// <summary>
        /// Thoát khỏi chức năng quản lý người dùng
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
        /// Load danh sách người dùng trong hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>

        public void LoadUserData(int PhongID)
        {
            // Add Users to List
            DataTable tabUsers;
            //objUsers.UserName = "";
            tabUsers = objUsers.LayDanhSachNguoiDungCua1Phong(PhongID);
            lstNguoiDung.DisplayMember = "FULLNAME";
            lstNguoiDung.ValueMember = "USER_ID";
            lstNguoiDung.DataSource = tabUsers;
        }
        /// <summary>
        /// Load danh sách vai trò của người dùng và vai trò mà người dùng không có quyền
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    14/2/2008    Tạo mới
        /// </Modified>
        private void AdminLoadRoleData()
        {
            // Add Roles to lstRoleAssigned
            DataView tabUserRole;
            objUserRole.UserName = strUserName;
            tabUserRole = new DataView(objUserRole.GetUserRole());
            lstVaiTroDuocCap.DataSource = null;
            lstVaiTroDuocCap.DisplayMember = "ROLE_NAME";
            lstVaiTroDuocCap.ValueMember = "ROLE_ID";
            lstVaiTroDuocCap.DataSource = tabUserRole;
            // load cac vai tro ma nguoi dung chua duoc cap trong he thong
            DataView tabRoleNotInUser;
            tabRoleNotInUser = new DataView(objUserRole.GetRoleNotInUser());
            lstVaiTroKhongDuocCap.DataSource = null;
            lstVaiTroKhongDuocCap.DisplayMember = "ROLE_NAME";
            lstVaiTroKhongDuocCap.ValueMember = "ROLE_ID";
            lstVaiTroKhongDuocCap.DataSource = tabRoleNotInUser;
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Load danh sach cac quyen khac ngoai vai tro ma nguoi dung duoc cap
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void LoadPermissionAssignedData()
        {
            // Add Permission to lstQuyenDuocCap
            UserPermission objUserPermission = new UserPermission();
            DataView tabUserPermission;
            objUserPermission.UserName = strUserName;
            tabUserPermission = new DataView(objUserPermission.GetUserPermissionFull());
            //tabUserPermission.RowFilter = "GRANT_USER_ID = '" + strUserName + "'";
            lstQuyenDuocCap.DataSource = null;
            lstQuyenDuocCap.DisplayMember = "PERMISSION_NAME";
            lstQuyenDuocCap.ValueMember = "PERMISSION_ID";
            lstQuyenDuocCap.DataSource = tabUserPermission;

            // Load cac quyen khong duoc cap con lai trong he thong
            DataTable tabPermissionNotInUser;
            objUserPermission.UserName = strUserName;
            tabPermissionNotInUser = objUserPermission.GetPermissionNotInUser();

            //Bổ xung thêm các quyền cha
            DataTable dtPermission = (new Permission()).GetAll();
            bool bNotExist;
            for (int i = dtPermission.Rows.Count - 1; i >= 0; i--)
            {
                bNotExist = true;
                for (int j = 0; j < tabPermissionNotInUser.Rows.Count; j++)
                    if (tabPermissionNotInUser.Rows[j]["PERMISSION_ID"].ToString().IndexOf(
                        dtPermission.Rows[i]["PERMISSION_ID"].ToString()) == 0)
                    {
                        bNotExist = false;
                        break;
                    }
                if (bNotExist)
                    dtPermission.Rows.RemoveAt(i);
            }

            lstQuyenKhongDuocCap.DataSource = null;
            lstQuyenKhongDuocCap.DisplayMember = "PERMISSION_NAME";
            lstQuyenKhongDuocCap.ValueMember = "PERMISSION_ID";
            lstQuyenKhongDuocCap.DataSource = dtPermission;
            objUserPermission = null;

        }
        /// <summary>
        /// Load thông tin quản lý người dùng khi form được khởi tạo
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void HeThong_NguoiDung_QuanLy_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
            LoadUserData(0);
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
            tblPhong.Rows.InsertAt(row,0);
            cbPhongBan.DisplayMember = "TenPhong";
            cbPhongBan.ValueMember = "PhongID";
            cbPhongBan.DataSource = tblPhong;
        }

        /// <summary>
        /// Su kiem thay doi nguoi dung duoc chon. Load lai vai tro va quyen voi nguoi dung tuong ung duoc chon
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void lstNguoiDung_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                strUserName = lstNguoiDung.SelectedValue.ToString().Trim();
                AdminLoadRoleData();
                //LoadPermissionAssignedData();
            }
            catch { }
        }
        /// <summary>
        /// Them moi mot so vai tro cho nguoi dung
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnVaiTroThem_Click(object sender, EventArgs e)
        {
            try
            {
                objUserRole.UserName = strUserName;
                string strRoleIDs = "";
                string strGrantOptions = "";
                foreach (DataRowView item in lstVaiTroKhongDuocCap.SelectedItems)
                {
                    DataRow drVaiTro = item.Row;
                    strRoleIDs = strRoleIDs + drVaiTro["ROLE_ID"].ToString().Trim() + ",";
                    strGrantOptions = strGrantOptions + "0,";
                }
                objUserRole.RoleIDs = strRoleIDs + "";
                objUserRole.GrantOptions = strGrantOptions + "";
                objUserRole.InsertUserRole();
                //Ghi log
                //Log oLog = new Log();
                //oLog.WriteLog(mUserName, "0101", DateTime.Now, "Thay đổi quyền người dùng " + HttpUtility.HtmlDecode(lstUsers.SelectedValue) + " trên máy có địa chỉ IP: " + Context.Request.ServerVariables["REMOTE_ADDR"].ToString());
            }
            catch { }
            AdminLoadRoleData();
        }
        /// <summary>
        /// Thêm tất cả các vai trò cho người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnVaiTroThemHet_Click(object sender, EventArgs e)
        {
            try
            {
                objUserRole.UserName = strUserName;
                string strRoleIDs = "";
                string strGrantOptions = "";
                foreach (DataRowView item in lstVaiTroKhongDuocCap.Items)
                {
                    DataRow drVaiTro = item.Row;
                    strRoleIDs = strRoleIDs + drVaiTro["ROLE_ID"].ToString().Trim() + ",";
                    strGrantOptions = strGrantOptions + "0,";
                }
                objUserRole.RoleIDs = strRoleIDs + "";
                objUserRole.GrantOptions = strGrantOptions + "";
                objUserRole.InsertUserRole();
                //Ghi log
                //Log oLog = new Log();
                //oLog.WriteLog(mUserName, "0101", DateTime.Now, "Thay đổi quyền người dùng " + HttpUtility.HtmlDecode(lstUsers.SelectedValue) + " trên máy có địa chỉ IP: " + Context.Request.ServerVariables["REMOTE_ADDR"].ToString());
            }
            catch { }
            AdminLoadRoleData();
        }
        /// <summary>
        /// Xóa những vai trò đã chọn của người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnVaiTroXoa_Click(object sender, EventArgs e)
        {
            try
            {
                objUserRole.UserName = strUserName;
                string strRoleIDs = "";
                foreach (DataRowView item in lstVaiTroDuocCap.SelectedItems)
                {
                    DataRow drVaiTro = item.Row;
                    strRoleIDs = strRoleIDs + drVaiTro["ROLE_ID"].ToString().Trim() + ",";
                }
                objUserRole.RoleIDs = strRoleIDs + "";
                objUserRole.DeleteUserSomeRole();
                //Ghi log
                //Log oLog = new Log();
                //oLog.WriteLog(mUserName, "0101", DateTime.Now, "Thay đổi quyền người dùng " + HttpUtility.HtmlDecode(lstUsers.SelectedValue) + " trên máy có địa chỉ IP: " + Context.Request.ServerVariables["REMOTE_ADDR"].ToString());
            }
            catch { }
            AdminLoadRoleData();
        }
        /// <summary>
        /// Xóa tất cả vai trò mà người dùng được cấp
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnVaiTroXoaHet_Click(object sender, EventArgs e)
        {
            try
            {
                objUserRole.UserName = strUserName;
                objUserRole.DeleteUserRole();
            }
            catch { }
            AdminLoadRoleData();
        }
        /// <summary>
        /// Thêm mới một số quyền ngoài vai trò của người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnQuyenThem_Click(object sender, EventArgs e)
        {
            try
            {
                objUserPermission.UserName = strUserName;
                string strPermissionIDs = "";
                string strPermissionID;
                string strGrantOptions = "";
                DataTable dtPermission = (new Permission()).GetAll();
                UserPermission user = new UserPermission();
                user.UserName = strUserName;
                DataTable dtUserPermission = user.GetUserPermissionFull();
                string strPermissionList = "";
                string strPermissionIDChon = string.Empty;
                foreach (DataRow r in dtUserPermission.Rows)
                    strPermissionList += ',' + r["permission_id"].ToString();


                foreach (DataRowView item in lstQuyenKhongDuocCap.SelectedItems)
                {
                    DataRow drQuyen = item.Row;
                    strPermissionIDChon = drQuyen["PERMISSION_ID"].ToString().Trim();
                    strPermissionIDs = strPermissionIDs + strPermissionIDChon + ",";
                    strGrantOptions = strGrantOptions + "0,";
                    foreach (DataRow drPermission in dtPermission.Rows)
                    {
                        // Add quyền con
                        // debug: sửa đối tượng thông tin đăng nhập = người dùng đang chọn
                        if ((drPermission["PERMISSION_ID"].ToString().IndexOf(strPermissionIDChon) == 0) && (strPermissionIDChon.Length < 6)
                            && (!strPermissionList.Contains(',' + drPermission["PERMISSION_ID"].ToString())))
                        {
                            strPermissionID = drPermission["PERMISSION_ID"].ToString();
                            strPermissionIDs += strPermissionID + ',';
                            strGrantOptions = strGrantOptions + "0,";
                            strPermissionList += ',' + strPermissionID;
                        }
                        //Add quyền cha
                        if (strPermissionIDChon.IndexOf(drPermission["PERMISSION_ID"].ToString()) == 0)
                        {
                            strPermissionIDs += drPermission["PERMISSION_ID"].ToString() + ',';
                            strGrantOptions = strGrantOptions + "0,";
                        }
                    }
                }
                objUserPermission.PermissionIDs = strPermissionIDs;
                objUserPermission.GrantOptions = strGrantOptions;
                objUserPermission.InsertUserPermission();
            }
            catch { }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Thêm tất cả các quyền ngoài vai trò cho người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnQuyenThemHet_Click(object sender, EventArgs e)
        {
            try
            {
                objUserPermission.UserName = strUserName;
                string strPermissionIDs = "";
                string strGrantOptions = "";
                foreach (DataRowView item in lstQuyenKhongDuocCap.Items)
                {
                    DataRow drQuyen = item.Row;
                    strPermissionIDs = strPermissionIDs + drQuyen["PERMISSION_ID"].ToString().Trim() + ",";
                    strGrantOptions = strGrantOptions + "0,";
                }
                objUserPermission.PermissionIDs = strPermissionIDs;
                objUserPermission.GrantOptions = strGrantOptions;
                objUserPermission.InsertUserPermission();
            }
            catch { }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Xóa một số quyền ngoài vai trò của người dùng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnQuyenXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách tất cả cac quyền cần loại
                string strPermissionIDs = "";
                string strPermissionID;
                DataTable dtPermission = (new Permission()).GetAll();
                foreach (DataRowView item in lstQuyenDuocCap.SelectedItems)
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
                objUserPermission.UserName = strUserName;
                objUserPermission.PermissionIDs = strPermissionIDs;
                objUserPermission.DeleteUserSomePermission();
            }
            catch { }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Xóa tất cả quyền ngoài vai trò mà người dùng được cấp
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnQuyenXoaHet_Click(object sender, EventArgs e)
        {
            try
            {
                objUserPermission.UserName = strUserName;
                objUserPermission.DeleteUserPermission();
            }
            catch { }
            LoadPermissionAssignedData();
        }
        /// <summary>
        /// Xóa người dùng trong hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string result = new Taxi.MessageBox.MessageBoxBA().Show("Bạn có chắc chắn muốn xóa người dùng này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
            if (result == DialogResult.Yes.ToString ())
            {
                // xOA NGUOI DUNG DUOC CHON            
                if (lstNguoiDung.SelectedIndex >= 0)
                {
                    objUserPermission.UserName = strUserName;
                    objUserPermission.DeleteUserPermission();
                    objUserRole.UserName = strUserName;
                    objUserRole.GrantUserID = "ADMIN";
                    objUserRole.DeleteUserRole();
                    objUsers.UserName = strUserName;
                    if (objUsers.DeleteUsers() == 0)
                    {
                        //Ghi log
                        Log oLog = new Log();
                        new Taxi.MessageBox.MessageBoxBA().Show("Đã xóa người dùng được chọn", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        oLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyNguoiDung_Xoa,
                            DateTime.Now,
                            "Xóa người dùng " + objUsers.UserName);
                        LoadUserData(CurentPhongBanID);
                    }
                    else
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Bạn không thể xóa người dùng này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    }
                }
            }
        }
        /// <summary>
        /// Load ra danh sách người dùng thuộc phòng ban sau khi thay đổi phòng ban
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    15/2/2008    Tạo mới
        /// </Modified>
        private void cbPhongBan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                CurentPhongBanID = int.Parse(cbPhongBan.SelectedValue.ToString());
                LoadUserData(CurentPhongBanID);
                txtTen.Text = string.Empty;
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Chuyển sang form quản lý vai trò
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    5/3/2008    Tạo mới
        /// </Modified>
        private void lnklblVaiTro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            HeThong_VaiTro_QuanLy frmQLVaiTro = new HeThong_VaiTro_QuanLy(mFormGoi);
            frmQLVaiTro.ShowDialog(mFormGoi);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == string.Empty)
            {
                new MessageBox.MessageBoxBA().Show("Hãy nhập tài khoản hoặc tên người dùng cần tìm", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
            }
            else
            {
                DataTable dtNhanVien = objUsers.LayDanhSachNguoiDungCua1Phong(CurentPhongBanID);
                DataTable result = new DataTable();
                //
                string stringFilterID = " [USER_ID] like '%" + txtTen.Text + "%'";
                string stringFilterTen = " [FULLNAME] like '%" + txtTen.Text + "%'";
                DataRow[] rowsID = dtNhanVien.Select(stringFilterID);
                if (rowsID.Length <= 0)
                {
                    DataRow[] rowsTen = dtNhanVien.Select(stringFilterTen);
                    if (rowsTen.Length <= 0)
                    {                       
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy người dùng này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        lstNguoiDung.DisplayMember = "FULLNAME";
                        lstNguoiDung.ValueMember = "USER_ID";
                        lstNguoiDung.DataSource = dtNhanVien;
                    }
                    else
                    {
                        result = dtNhanVien.Clone();
                        for (int i = 0; i < rowsTen.Length; i++)
                        {
                            DataRow row = result.NewRow();
                            row[0] = rowsTen[i].ItemArray[0].ToString();
                            row[1] = rowsTen[i].ItemArray[1].ToString();
                            row[2] = rowsTen[i].ItemArray[2].ToString();
                            row[3] = rowsTen[i].ItemArray[3].ToString();
                            row[4] = rowsTen[i].ItemArray[4].ToString();
                            row[5] = rowsTen[i].ItemArray[5].ToString();
                            row[6] = rowsTen[i].ItemArray[6].ToString();
                            result.Rows.Add(row);
                        }
                        // Add Users to List

                        lstNguoiDung.DisplayMember = "FULLNAME";
                        lstNguoiDung.ValueMember = "USER_ID";
                        lstNguoiDung.DataSource = result;
                    }
                }
                else
                {
                    result = dtNhanVien.Clone();
                    for (int i = 0; i < rowsID.Length; i++)
                    {
                        DataRow row = result.NewRow();
                        row[0] = rowsID[i].ItemArray[0].ToString();
                        row[1] = rowsID[i].ItemArray[1].ToString();
                        row[2] = rowsID[i].ItemArray[2].ToString();
                        row[3] = rowsID[i].ItemArray[3].ToString();
                        row[4] = rowsID[i].ItemArray[4].ToString();
                        row[5] = rowsID[i].ItemArray[5].ToString();
                        row[6] = rowsID[i].ItemArray[6].ToString();
                        result.Rows.Add(row);
                    }
                    // Add Users to List

                    lstNguoiDung.DisplayMember = "FULLNAME";
                    lstNguoiDung.ValueMember = "USER_ID";
                    lstNguoiDung.DataSource = result;
                }

               
            }
        }

        private void lnklbPhanQuyen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new HeThong_PhanQuyenKhaiThacMoiGioi().ShowDialog();
        }

    }
}