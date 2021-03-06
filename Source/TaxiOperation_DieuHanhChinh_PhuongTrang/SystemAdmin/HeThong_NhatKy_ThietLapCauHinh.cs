 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Taxi.Business;
namespace Taxi.GUI
{
    /// <summary>
    /// Chức năng thiết lập các chế độ ghi log
    /// </summary>
    /// <Modified>
    ///     Author      Date        Comments
    ///     Cuongdb    18/2/2008    Tạo mới
    /// </Modified>
	public partial class HeThong_NhatKy_ThietLapCauHinh: Form
    {

        private static EventGroup mEventGroup;
        private static int curEventGroupID;

		public HeThong_NhatKy_ThietLapCauHinh() 
        {
			InitializeComponent();
		}
        /// <summary>
        /// Lay ra danh sach cac su kien trong nhom su kien nay
        /// </summary>
        /// <param name="mmEventGroup">mã nhóm sự kiện được chọn </param>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
        public void BindData(int mmEventGroup)
        {
            DataTable dt;
            //DataRow arow;
            mEventGroup = new EventGroup(mmEventGroup);
            dt = mEventGroup.GetEvents();
            grdSuKien.DataSource = dt;
        }
        /// <summary>
        /// Load danh sách các nhóm sự kiện
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
        private void LoadGroupEvent() 
        {
            DataTable dt;
            //DataRow arow;
            mEventGroup = new EventGroup();
            dt = mEventGroup.GetEventGroups();
            cbChucNang.DisplayMember = "event_group_name";
            cbChucNang.ValueMember = "event_group_id";
            cbChucNang.DataSource = dt;
        }
        /// <summary>
        /// Thoát khỏi chức năng thiết lập cấu hình ghi log
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
		private void btnThoat_Click(object sender, EventArgs e) {
			Close();
		}
        /// <summary>
        /// Cập nhật chế độ ghi log
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ArrayList arrCheck = new ArrayList();
            for (int i = 0; i < grdSuKien.RowCount; i++) 
            {
                if ((bool)grdSuKien.GetRow(i).Cells[0].Value == true) 
                {
                    arrCheck.Add(grdSuKien.GetRow(i).Cells[1].Value);
                }
            }
            try
            {
                mEventGroup.SetLogMode(arrCheck);
                new Taxi.MessageBox.MessageBoxBA().Show("Đã cập nhật chế độ ghi nhật ký","Thông báo",Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Information);
                // Ghi log
                Log objLog = new Log();
                objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyNhatKyHeThong_ThietLapCoCheGhiNhatKy,
                    DateTime.Now, "Cập nhật chế độ ghi log");
            }
            catch 
            { }
            BindData(curEventGroupID);
        }
        /// <summary>
        /// Load danh sách các sự kiện khi thay đổi nhóm sự kiện được chọn
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
        private void cbChucNang_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                curEventGroupID = int.Parse(cbChucNang.SelectedValue.ToString());
                BindData(curEventGroupID);
            }
            catch { }
        }
        /// <summary>
        /// Load các nhóm sự kiện và các sự kiện tương ứng ban đầu khi form được load
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
        private void HeThong_NhatKy_ThietLapCauHinh_Load(object sender, EventArgs e)
        {
            LoadGroupEvent();
        }

      
	}
}