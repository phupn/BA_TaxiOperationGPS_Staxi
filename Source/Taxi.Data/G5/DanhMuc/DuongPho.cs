using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = _table)]
    public class DuongPho : DbEntityBase<DuongPho>
    {
        private const string _table = "[T_DuongPho]";
        private const string _spReport = "sp_BC_1_10_BaoCaoThongKeTheoDuongPho";

        [Field(IsIdentity = true, IsKey = true)]
        public int Id { get; set; }
        [Field]
        public string TenDuongPho { get; set; }
        [Field]
        public string TenDuongPhoDayDu { get; set; }
        [Field]
        public bool IsBaoCao { get; set; }
        public static DataTable Report(DateTime start, DateTime end)
        {
            return Inst.ExeStore(_spReport, start, end);
        }
    }
}
