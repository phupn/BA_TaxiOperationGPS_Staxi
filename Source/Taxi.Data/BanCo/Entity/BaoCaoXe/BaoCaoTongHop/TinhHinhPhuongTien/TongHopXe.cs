namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop.TinhHinhPhuongTien
{
    /// <summary>
    /// Tạo dòng tổng xe nhưng nội dung rỗng
    /// </summary>
    public class TongHopXe : BaoCaoTongHopRowEmptyBase
    {
        public const string TongXe = "Tổng xe";

        /// <summary>
        /// 
        /// </summary>
        protected override string KhoanMuc
        {
            get { return "Tình hình phương tiện"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string NoiDung
        {
            get { return TongXe; }
        }

    }
}
