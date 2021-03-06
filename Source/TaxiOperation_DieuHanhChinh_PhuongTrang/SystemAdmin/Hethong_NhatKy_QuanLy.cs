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

	public partial class Hethong_NhatKy_QuanLy: Form 
    {
        /// <summary>
        /// Chức năng quản lý nhật ký hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
		public Hethong_NhatKy_QuanLy() 
        {
			InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
		}
        /// <summary>
        /// Thoát khỏi Chức năng quản lý nhật ký hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
		private void btnThoat_Click(object sender, EventArgs e) {
			Close();
		}
        /// <summary>
        /// Vào Chức năng xóa nhật ký hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
		private void btnXoaNhatKy_Click(object sender, EventArgs e) {
			Hethong_NhatKy_Xoa frmNhatKy = new Hethong_NhatKy_Xoa();
			frmNhatKy.ShowDialog();
            BindGrid();
		}
        /// <summary>
        /// Vào form Chức năng thiết lập cấu hình ghi nhật ký hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void btnThietLap_Click(object sender, EventArgs e)
        {
            HeThong_NhatKy_ThietLapCauHinh frmThietLapNhatKy = new HeThong_NhatKy_ThietLapCauHinh();
            frmThietLapNhatKy.ShowDialog();
        }
        /// <summary>
        /// Load danh sách tất cả người dùng hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void LoadNguoiDung() 
        {
            // Add Users to List
            DataTable tabUsers;
            Users objUsers = new Users();
            //objUsers.UserName = "";
            tabUsers = objUsers.GetAllUser();
            DataRow row = tabUsers.NewRow();
            row["FULLNAME"] = "Chọn tất cả người dùng";
            row["USER_ID"] = "0";
            tabUsers.Rows.InsertAt(row, 0);
            chklstNguoiDung.DataSource = tabUsers;
            chklstNguoiDung.DisplayMember = "FULLNAME";
            chklstNguoiDung.ValueMember = "USER_ID";
            for (int count = 0; count < chklstNguoiDung.Items.Count; count++)
            {
                chklstNguoiDung.SetItemChecked(count, false);
            }  
        }
        /// <summary>
        /// Tìm kiếm danh sách nhật ký hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void btnLoc_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        /// <summary>
        /// Load danh sách nhật ký tìm thấy vào grid
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        
        private void BindGrid() 
        {
            Log objLog = new Log();
            string FromTime, ToTime;
            string lstUserID = " ";
            string lstEventGroupID = "";

            FromTime = (dtpTuNgay.Value.ToShortDateString() == "" ? "01/01/1900" : dtpTuNgay.Value.ToShortDateString()) + " " + (dtpTuGio.Value.Hour.ToString() == "" ? "00" : dtpTuGio.Value.Hour.ToString()) + ":" + (dtpTuGio.Value.Minute.ToString() == "" ? "00" : dtpTuGio.Value.Minute.ToString()) + ":" + (dtpTuGio.Value.Second.ToString() == "" ? "01" : dtpTuGio.Value.Second.ToString());
            ToTime = (dtpDenNgay.Value.ToShortDateString() == "" ? DateTime.Now.ToShortDateString() : dtpDenNgay.Value.ToShortDateString()) + " " + (dtpDenGio.Value.Hour.ToString() == "" ? "23" : dtpDenGio.Value.Hour.ToString()) + ":" + (dtpDenGio.Value.Minute.ToString() == "" ? "59" : dtpDenGio.Value.Minute.ToString()) + ":" + (dtpDenGio.Value.Second.ToString() == "" ? "59" : dtpDenGio.Value.Second.ToString());
            if (DateTime.Compare(DateTime.Parse(FromTime), DateTime.Parse(ToTime)) >= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            int batdau = 0;
            if (chklstNguoiDung.GetItemChecked(0))
            {
                batdau = 1;
            }
            for (int i = batdau; i < chklstNguoiDung.CheckedItems.Count; i++)
            {
                lstUserID = lstUserID + "'" + ((DataRowView)chklstNguoiDung.CheckedItems[i]).Row["USER_ID"].ToString() + "'" + ",";
            }

            if (lstUserID.Length > 0) lstUserID = lstUserID.Substring(0, lstUserID.Length - 1);
            objLog.LogTimeFrom = FromTime;
            objLog.LogTimeTo = ToTime;
            objLog.UserID = lstUserID;
            objLog.EventGroupID = lstEventGroupID;
            DataTable tblKetQua = objLog.Log_Search();
            grdKetQuaTimKiem.DataSource = tblKetQua;
            if (tblKetQua.Rows.Count == 0) new Taxi.MessageBox.MessageBoxBA().Show("Không tìm thấy bản ghi nào trong khoảng thời gian từ " + dtpTuNgay.Value.ToShortDateString() + " " + dtpTuGio.Value.ToShortTimeString() 
                                                            + " đến " + dtpDenNgay.Value.ToShortDateString() + " " + dtpDenGio.Value.ToShortTimeString(),
                                                           "Kết quả", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
        }
        /// <summary>
        /// Load thông tin ban đầu khi form được khởi tạo
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void Hethong_NhatKy_QuanLy_Load(object sender, EventArgs e)
        {
            //GiaoDienChinh frmMain = this.ParentForm as GiaoDienChinh;
            //if (frmMain.ActiveMdiChild != null)
            //    frmMain.ActiveMdiChild.Close();
            dtpTuGio.Value = DateTime.Today.Date;
            LoadNguoiDung();
        }
        /// <summary>
        /// Điều chỉnh dữ liệu khi được load vào grid
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void grdKetQuaTimKiem_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            int Position = e.Row.Position + 1;
            Janus.Windows.GridEX.GridEXCell cell = (Janus.Windows.GridEX.GridEXCell)e.Row.Cells[0];
            cell.Text = Position.ToString();
        }

        /// <summary>
        /// Su kien xay ra khi nguoi dung check vao check box
        /// Se tien hanh loc danh sach nguoi dung can tin kiem
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    19/2/2008    Tạo mới
        /// </Modified>
        private void chklstNguoiDung_Click(object sender, EventArgs e)
        {
            int vitri = chklstNguoiDung.SelectedIndex;
            if (vitri == 0)
            {
                if (chklstNguoiDung.GetItemChecked(vitri))
                {
                    // vi tri 0 dang check thi trang thai moi la uncheck => uncheck all
                    for (int count = 1; count < chklstNguoiDung.Items.Count; count++)
                    {
                        chklstNguoiDung.SetItemChecked(count, false);
                    }
                }
                else
                {
                    // vi tri 0 dang un check thi trang thai moi la check => check all
                    for (int count = 1; count < chklstNguoiDung.Items.Count; count++)
                    {
                        chklstNguoiDung.SetItemChecked(count, true);
                    }
                }
            }
            else 
            {
                if (chklstNguoiDung.GetItemChecked(vitri))
                {
                    chklstNguoiDung.SetItemChecked(0, false);
                }
            }
        }
	}
}