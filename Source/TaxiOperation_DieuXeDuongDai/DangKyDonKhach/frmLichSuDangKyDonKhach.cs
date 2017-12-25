using Taxi.Business.DieuXeDuongDai;

namespace TaxiOperation_DieuXeDuongDai.DangKyDonKhach
{
    public partial class frmLichSuDangKyDonKhach : FormBase
    {
        public frmLichSuDangKyDonKhach()
        {
            InitializeComponent();
        }

        public void SetId(long id)
        {
            var db=new DUONGDAI_KHACHHEN_XEDK().GetLichSu(id);
            shGridControl1.SetDataSource(db);
        }
    }
}
