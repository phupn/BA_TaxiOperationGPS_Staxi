using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.Attributes.Validator;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "BanCo_GiamSatXe_DoDau")]
    public class DoDau : TaxiOperationDbEntityBase<DoDau>
    {
        [Field(IsKey = true,IsIdentity = true)]
        public long Id { get; set; }
        [Field(FieldName = "Ngày")]
        [ValidatorRequire]
        public DateTime? NgayDoDau { get; set; }
        [Field(FieldName = "Số xe")]
        [ValidatorRequire]
        public string SoXe { get; set; }
        [Field]
        public DateTime? TGKD { get; set; }
        [Field(FieldName = "Số dầu đồ")]
        [ValidatorRequire]
        public double? SoDauDo { get; set; }
        [Field(FieldName = "Số công tơ mét")]
        [ValidatorRequire]
        public int? SoCongToMet { get; set; }
        [Field]
        public string GhiChu { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string CreatedBy { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
        [Field]
        public string UpdatedBy { get; set; }

        public string TenLaiXe { get; set; }
        public string LoaiXe { get; set; }
        public int SoXe_Int{get { return SoXe.To<int>(); }}
        public List<DoDau> TimKiem(DateTime ?dt,string soXe,string loaiXe)
        {
            return ExeStore("sp_DoDau_Timkiem", dt, soXe, loaiXe).ToList<DoDau>();
        }

        public List<DoDau> GetData()
        {
            return TimKiem(NgayDoDau, SoXe, LoaiXe);
        }
        public bool CheckDoDau()
        {
            var get = TimKiem(NgayDoDau, SoXe, string.Empty);
            return get.Count>0;
        }
    }
}
