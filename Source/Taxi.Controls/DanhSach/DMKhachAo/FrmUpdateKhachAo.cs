using Taxi.Common.DbBase;
using Taxi.Controls.Base;

namespace Taxi.Controls.DanhSach.DMKhachAo
{
    public partial class FrmUpdateKhachAo : FormUpdate
    {
        public override ModelBase ModelNew
        {
            get
            {
                return new Data.G5.DanhMuc.DMKhachAo();
            }
        }
        public override bool DoValidate()
        {
            if (string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                SetMessage("Bạn chưa nhập số điện thoại");
                txtSoDienThoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                SetMessage("Bạn chưa nhập tên");
                txtTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                SetMessage("Bạn chưa nhập địa chỉ");
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }

        private bool CheckSoDienThoai(string soDienThoai)
        {
            return true;
        }
    }
}
