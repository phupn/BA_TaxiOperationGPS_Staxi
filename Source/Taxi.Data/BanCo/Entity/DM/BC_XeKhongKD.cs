using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;


namespace Taxi.Data.BanCo.Entity.DM
{
    public class BC_XeKhongKD
    {
        public int STT { get; set; }

        public string TenLoaiXe { get; set; }

        public string SoHieuXe { get; set; }

        public DateTime ReportedDate { get; set; }



        
    }
}
