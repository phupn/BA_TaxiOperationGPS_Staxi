using Taxi.Data.BanCo.Entity.GiamSatXe;
using System.Collections.Generic;
using System.Linq;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop.TinhHinhPhuongTien
{
    public class XeDiKinhDoanh : BaoCaoTinhHinhPhuongTien<BanCo_GiamSatXe>
    {
        /// <summary>
        /// Tiêu đề
        /// </summary>
        protected override string NoiDung
        {
            get { return "Xe đi KD"; }
        }

        /// <summary>
        /// Dữ liệu báo cáo
        /// </summary>
        /// <returns></returns>
        protected override List<BanCo_GiamSatXe> GetData()
        {
            return BaoCaoSoNgayXeDiKinhDoanh.Inst.GetDataInRangeDate_V2(From, To, string.Empty).ToList<BanCo_GiamSatXe>();
        }
    }
}
