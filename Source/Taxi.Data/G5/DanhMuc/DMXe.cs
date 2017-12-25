#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Data;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = "T_DMXE")]
    public class DMXe : DbEntityBase<DMXe>
    {
        private const string sp_DMXe_GetData = "sp_DMXe_GetData";
        private const string sp_DMXe_Save = "sp_DMXe_Save";
        private const string sp_DMXe_CheckSoHieuXe = "sp_DMXe_CheckSoHieuXe";
        #region===Field===
        [Field(IsKey = true)]
        public string PK_SoHieuXe { get; set; }
        [Field]
        public string BienKiemSoat { get; set; }
        [Field]
        public string SoMay { get; set; }
        [Field]
        public string SoKhung { get; set; }
        [Field]
        public int FK_LoaiXeID { get; set; }
        [Field]
        public int FK_GaraID { get; set; }
        [Field]
        public int SoCho { get; set; }
        [Field]
        public int FK_LoaiNhienLieu { get; set; }
        [Field]
        public DateTime LastUpdate { get; set; }
        [Field]
        public string SoDienThoai { get; set; }
        [Field]
        public string TenLaiXe { get; set; }

        #endregion

        #region===Methods===
        public static List<DMXe> GetData(string SoHieuXe, string BienKiemSoat, int LoaiXe, int Gara)
        {
            return Inst.ExeStore(sp_DMXe_GetData, SoHieuXe, BienKiemSoat, LoaiXe, Gara).ToList<DMXe>();
        }

        public static bool CheckSoHieuXe(string soHieuXe)
        {
            var dt = Inst.ExeStore(sp_DMXe_CheckSoHieuXe, soHieuXe);
            return dt!=null && dt.Rows.Count > 0;
        }

        public override void Save()
        {
            this.ExeStoreNoneQuery(sp_DMXe_Save);
        }
        #endregion
    }
}
