
using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Common.RepositoryItems;
using Taxi.Common.Extender;

namespace Taxi.Controls.DanhSach.DMXE
{
    public partial class FrmManagerXe : FormManager
    {
        public FrmManagerXe()
        {
            InitializeComponent();
        }
        public override FormUpdate FormUpdate
        {
            get
            {
                return new FormUpdateXe();
            }
        }
        public override void AfterLoad()
        {
            gridView1.Add<RepositoryItem_LoaiXe>("FK_LoaiXeID");
            gridView1.Add<RepositoryItem_Gara>("FK_GaraID");
        }

        public override object GetData()
        {
            return DMXe.GetData(txtSoHieuXe.Text, txtBienSo.Text, lookUpLoaiXe.EditValue.To<int>(), lookUpGara.EditValue.To<int>());
        }
    }
}
