using System;
using TaxiOperation_WebTest.Demo;

namespace TaxiOperation_WebTest
{
    public partial class DatXe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnDatXe_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            try
            {
                var db = new Demo.TaxiOperation_ServicesSoapClient();
                var au = new Authentication();
                au.Password = "pass";
                au.UserName = "admin";
                var sl = 0;
                int.TryParse(txtSoLuong.Text, out sl);
                DateTime dt;
                DateTime.TryParse(txtGioDon.Text, out dt);
                var rs = db.BookingTaxi(au,txtTenKhachHang.Text, txtSoDienThoai.Text, txtDiaChiDon.Text, txtLoaiXe.Text, sl,
                txtDiaChiTraKhach.Text, txtGhiChu.Text, dt, txtEmail.Text);
                lblMsg.Text = string.IsNullOrEmpty(rs) || rs=="1" ? "Lưu thành công" : string.Format("Lỗi:{0}", rs);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            
        }
    }
}