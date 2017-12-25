using System.Collections.Generic;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop.TinhHinhPhuongTien
{
    /// <summary>
    /// 
    /// </summary>
    public class XeKhongDiKinhDoanh : BaoCaoTinhHinhPhuongTien<BaoCaoXeKhongHoatDong>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override string NoiDung
        {
            get { return "Xe không đi KD"; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override List<BaoCaoXeKhongHoatDong> GetData()
        {
            return BaoCaoXeKhongHoatDong.Inst.GetDataInRangeDate(From, To, string.Empty, string.Empty);
        }
    }
}
