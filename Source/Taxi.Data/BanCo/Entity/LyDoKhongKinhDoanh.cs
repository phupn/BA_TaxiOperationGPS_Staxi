using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.Entity.BaoCaoXe;

namespace Taxi.Data.BanCo.Entity
{
    public class LyDoKhongKinhDoanh
    {
        private int ID_reason {get;set;}

        private string TenLyDo { get; set; }

        //List<XeKhongKinhDoanh> list{ get; set; }

        //public LyDoKhongKinhDoanh() {
        //    list = new List<XeKhongKinhDoanh>();
            
        //}

        public LyDoKhongKinhDoanh(int id) {
            ID_reason = id;
            //TenLyDo = new XeKhongKinhDoanh().GetTenLyDo(id);
            //list = new XeKhongKinhDoanh().GetByReason(id);
        }
    }
}
