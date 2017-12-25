using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Data.BanCo.Entity.DieuXe
{
    /// <summary>
    /// 
    /// </summary>
    public class ThongTinTimKiem
    {
        public string SoXe { set; get; }
        public string DienThoai { set; get; }
        public string DiaChi { set; get; }
        public string DiaChiTra { set; get; }

        /// <summary>
        /// Nếu là True thì load dữ liệu cuộc gọi của tất cả các line (vùng ứng với tổng đài)
        /// </summary>
        public bool IsAllLine_Vung { set; get; }
    }
}
