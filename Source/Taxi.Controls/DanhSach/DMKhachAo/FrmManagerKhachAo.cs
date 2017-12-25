
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Common.InputLookUps;
using Taxi.Controls.Base.Common.RepositoryItems;
using Taxi.Common.Extender;

namespace Taxi.Controls.DanhSach.DMKhachAo
{
    public partial class FrmManagerKhachAo : FormManager
    {
        public FrmManagerKhachAo()
        {
            InitializeComponent();
        }

        public override FormUpdate FormUpdate
        {
            get
            {
                return new FrmUpdateKhachAo();
            }
        }
        public override object GetData()
        {
            return Data.G5.DanhMuc.DMKhachAo.GetData(txtSoDienThoai.Text, txtTen.Text, txtDiaChi.Text);
        }
    }
}
