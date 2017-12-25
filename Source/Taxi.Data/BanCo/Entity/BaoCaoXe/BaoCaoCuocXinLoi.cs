

using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public  class BaoCaoCuocXinLoi : TaxiOperationDbEntityBase<BaoCaoCuocXinLoi>
    {
        public DateTime Time { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string TypeName { get; set; }
        public string Note { get; set; }
        public string GhiChu { get; set; }
        public List<BaoCaoCuocXinLoi> GetReport(DateTime? FromDate, DateTime? ToDate, string LoaiXe,string LyDo)
        {
            return ExeStore("EnVang_Report_BaoCaoCuocXinLoi", FromDate, ToDate, LoaiXe).ToList<BaoCaoCuocXinLoi>();
        }
    }
}
