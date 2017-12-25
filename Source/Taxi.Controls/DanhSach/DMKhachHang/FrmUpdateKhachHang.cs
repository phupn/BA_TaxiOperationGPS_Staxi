using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Common.DbBase;
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.DanhSach.DMKhachHang
{
    public partial class FrmUpdateKhachHang : FormUpdate
    {
        public FrmUpdateKhachHang()
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
            get
            {
                return new DMDanhBaCongTy();
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
