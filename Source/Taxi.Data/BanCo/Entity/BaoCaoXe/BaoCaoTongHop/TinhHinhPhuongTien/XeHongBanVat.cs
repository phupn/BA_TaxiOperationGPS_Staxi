using System.Collections.Generic;
using Taxi.Data.BanCo.Entity.GiamSatXe;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop.TinhHinhPhuongTien
{
    /// <summary>
    /// Tính toán xe hỏng ban vặt
    /// </summary>
    public class XeHongBanVat : BaoCaoTinhHinhPhuongTien<BanCo_VehicleCorrupt>
    {
        /// <summary>
        /// Nội dung báo cáo
        /// </summary>
        protected override string NoiDung
        {
            get { return "Xe hỏng ban vặt"; }
        }

        /// <summary>
        /// Dữ liệu báo cáo
        /// </summary>
        /// <returns></returns>
        protected override List<BanCo_VehicleCorrupt> GetData()
        {
            return BanCo_VehicleCorrupt.Inst.GetReport(From, To, string.Empty, 0);
        }
    }
}
