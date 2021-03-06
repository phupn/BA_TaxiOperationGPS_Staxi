 
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
    /// Chức năng Xoa nhat ky he thong
    /// </summary>
    /// <Modified>
    ///     Author      Date        Comments
    ///     Cuongdb    18/2/2008    Tạo mới
    /// </Modified>
	public partial class Hethong_NhatKy_Xoa: Form 
    {
        private static string DenNgay;
        private static string TuNgay;
        private static string[] arrValue = new string[8];
        // Khởi tạo form
		public Hethong_NhatKy_Xoa() 
        {
			InitializeComponent();
		}
        /// <summary>
        /// Thoát khỏi Chức năng xóa nhật ký hệ thống
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
		private void btnThoat_Click(object sender, EventArgs e) {
			Close();
		}

        /// <summary>
        /// Xóa nhật ký hệ thống trong khoảng thời gian đã chọn
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    18/2/2008    Tạo mới
        /// </Modified>
		
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Thiết lập thời gian xóa
            arrValue[0] = dtpTuNgay.Value.ToShortDateString();
            arrValue[1] = dtpTuGio.Value.Hour.ToString();
            arrValue[2] = dtpTuGio.Value.Minute.ToString();
            arrValue[3] = dtpTuGio.Value.Second.ToString();
            arrValue[4] = dtpDenNgay.Value.ToShortDateString();
            arrValue[5] = dtpDenGio.Value.Hour.ToString();
            arrValue[6] = dtpDenGio.Value.Minute.ToString();
            arrValue[7] = dtpDenGio.Value.Second.ToString();

            TuNgay = dtpTuNgay.Value.ToShortDateString() + " " + ((dtpTuGio.Value.Hour.ToString() == "") ? "00" : dtpTuGio.Value.Hour.ToString()) + ":" + ((dtpTuGio.Value.Minute.ToString() == "") ? "00" : dtpTuGio.Value.Minute.ToString()) + ":" + ((dtpTuGio.Value.Second.ToString() == "") ? "01" : dtpTuGio.Value.Second.ToString());
            DenNgay = dtpDenNgay.Value.ToShortDateString() + " " + ((dtpDenGio.Value.Hour.ToString() == "") ? "23" : dtpDenGio.Value.Hour.ToString()) + ":" + ((dtpDenGio.Value.Minute.ToString() == "") ? "59" : dtpDenGio.Value.Minute.ToString()) + ":" + ((dtpDenGio.Value.Second.ToString() == "") ? "59" : dtpDenGio.Value.Second.ToString());
            if (DateTime.Compare(DateTime.Parse(TuNgay), DateTime.Parse(DenNgay)) >= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Thời gian bắt đầu phải trước thời gian kết thúc.","Thông báo",Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }           
            Log objLog = new Log();
            objLog.LogTimeFrom = TuNgay;
            objLog.LogTimeTo = DenNgay;
            try
            {
                string  result = new Taxi.MessageBox.MessageBoxBA().Show("Bạn có chắc chắn muốn xóa nhật ký trong khoảng thời gian đã chọn?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                if (result == DialogResult.Yes.ToString ())
                {
                    int soxoa = objLog.DeleteLog();
                    if (soxoa > 0)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Đã xóa những nhật ký trong thời gian từ : " + TuNgay + "  đến " + DenNgay, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        //Ghi log
                        objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.QuanLyNhatKyHeThong_Xoa, DateTime.Now, 
                            "Xóa từ thời điểm " + TuNgay.ToString() + " đến " + DenNgay.ToString());
                    }
                    else 
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Không có nhật ký hệ thống trong khoảng thời gian từ : " + TuNgay + "  đến " + DenNgay, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    }
                    this.Close();
                }
            }
            catch 
            {
            }
        }
	}
}