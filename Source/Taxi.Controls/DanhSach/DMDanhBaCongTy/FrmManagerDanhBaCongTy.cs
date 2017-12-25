
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;


namespace Taxi.Controls.DanhSach
{
    public partial class FrmManagerDanhBaCongTy : FormManager
    {
        public FrmManagerDanhBaCongTy()
        {
            InitializeComponent();
        }

        public override object GetData()
        {
           return  DMDanhBaCongTy.GetData(txtSoDienThoai.Text, txtTen.Text, txtDiaChi.Text);
        }

    }
}
