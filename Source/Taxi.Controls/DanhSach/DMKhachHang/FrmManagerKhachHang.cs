using Taxi.Controls.Base;

namespace Taxi.Controls.DanhSach.DMKhachHang
{
    public partial class FrmManagerKhachHang : FormManager
    {
        public FrmManagerKhachHang()
        {
            InitializeComponent();
        }

        public override FormUpdate FormUpdate
        {
            get
            {
                return new FrmUpdateKhachHang();
            }
        }
        public override object GetData()
        {
            return Data.G5.DanhMuc.DMDanhBaCongTy.GetData(txtSoDienThoai.Text, txtTen.Text, txtDiaChi.Text);
        }

    }
}
