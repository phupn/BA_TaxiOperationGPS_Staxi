using System;
using Taxi.Common.DbBase;
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.DanhSach
{
    public partial class FrmUpdateDanhBaCongTy : FormUpdate
    {
        public FrmUpdateDanhBaCongTy()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtSoDienThoai.Focus();
        }

        public override ModelBase ModelNew
        {
            get { return new DMDanhBaCongTy(); }
        }

        public override bool DoValidate()
        {
            if (string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                SetMessage("Bạn chưa nhập số điện thoại!");
                txtSoDienThoai.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTen.Text))
            {
                SetMessage("Bạn chưa nhập tên công ty!");
                txtTen.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                SetMessage("Bạn chưa nhập địa chỉ!");
                txtDiaChi.Focus();
                return false;

            }
            return true;
        }
    }
}
