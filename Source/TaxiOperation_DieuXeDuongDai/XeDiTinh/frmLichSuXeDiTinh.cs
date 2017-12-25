using Taxi.Business.DieuXeDuongDai;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai.XeDiTinh
{
    public partial class frmLichSuXeDiTinh : FormBase
    {
        public frmLichSuXeDiTinh()
        {
            InitializeComponent();
        }

        public void SetId(long id)
        {
            reTrangThai.DataSource = CommonDuongDai.GetTrangThaiXeDiTinh();
            reTrangThaiXoa.DataSource = CommonDuongDai.GetTrangThaiXoa();
            var db=new DUONGDAI_DONKHACH_XEDITINH().GetLichSu(id);
            shGridControl1.SetDataSource(db);
        }
    }
}
