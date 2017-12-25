using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "T_TAXIOPERATION")]
    public class TaxiOperation : TaxiOperationDbEntityBase<TaxiOperation>
    {
        [Field(IsKey = true, IsIdentity = false)]
        public long ID { get; set; }

        [Field]
        public byte? KieuCuocGoi { get; set; }

        [Field]
        public string XeNhan { get; set; }

        /// <summary>
        /// Sơn PC thêm để sửa chữa lỗi lầm của Phú PN
        /// </summary>
        public string SoXe { set; get; }

        
    }
}
