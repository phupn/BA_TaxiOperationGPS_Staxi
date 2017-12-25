using System;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity;
using Taxi.MessageBox;

namespace Taxi.Controls.DanhMuc
{
    public partial class frmLuuDiaChiDoiTac : FormBase
    {
        public string DiaChiMoi;
        public string MaDoiTac;
        public long TraceID;
        public bool IsSuccess = false;
        public frmLuuDiaChiDoiTac()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(!CheckValidate())
                    return;
                T_DOITAC.Inst.UpdateNewAddress(MaDoiTac, txtDiaChiMoi.Text, TraceID, ThongTinDangNhap.USER_ID, CommonBL.GetTimeServer());
                new MessageBox.MessageBoxBA().Show("Duyệt địa chỉ mới thành công!", "Thông báo");
                IsSuccess = true;
                this.Close();
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi khi lưu dữ liệu!", "Thông báo");
            }
        }

        private void frmLuuDiaChiDoiTac_Load(object sender, EventArgs e)
        {
            txtDiaChiMoi.Text = DiaChiMoi;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtDiaChiMoi.Text))
            {
                new MessageBox.MessageBoxBA().Show("Địa chỉ mới không được để trống!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                txtDiaChiMoi.Focus();
                return false;
            }
            return true;
        }
    }
}
