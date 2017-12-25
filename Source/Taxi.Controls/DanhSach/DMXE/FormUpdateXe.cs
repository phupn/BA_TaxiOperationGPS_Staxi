using Taxi.Common.DbBase;
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;
using Taxi.Common.Extender;

namespace Taxi.Controls.DanhSach.DMXE
{
    public partial class FormUpdateXe : FormUpdate
    {
        public FormUpdateXe()
        {
            InitializeComponent();
        }
        public override ModelBase ModelNew
        {
            get
            {
                return new DMXe();
            }
        }
        public override bool DoValidate()
        {
            if (string.IsNullOrEmpty(txtSoHieuXe.Text))
            {
                  SetMessage("Số hiệu xe không được để trống");
                  txtSoHieuXe.Focus();
                  return false;
            }
            if (IsNew)
            {
                if (CheckSoHieuXe(txtSoHieuXe.Text))
                {
                    SetMessage("Số hiệu xe đã tồn tại");
                    txtSoHieuXe.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtBienSo.Text))
            {
                SetMessage("Biển số không được để trống");
                txtBienSo.Focus();
                return false;
            }
            return true;
        }

        private bool CheckSoHieuXe(string soHieuXe)
        {
            return DMXe.CheckSoHieuXe(soHieuXe);
        }
    }
    
}

