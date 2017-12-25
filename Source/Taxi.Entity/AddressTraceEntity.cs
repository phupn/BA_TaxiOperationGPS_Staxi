using System;
using System.Data;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Entity
{
    [TableInfo(TableName = "T_TaxiOperation_AddressTrace")]
    public class AddressTraceEntity:DbEntityBase<AddressTraceEntity>
    {
        [Field(IsKey=true,IsIdentity=true )]
        public long TraceID { get; set; }
    
        [Field]
        public long ID { get; set; }
    
        [Field]
        public string PhoneNumber { get; set; }
    
        [Field]
        public DateTime ThoiDiemGoi { get; set; }
    
        [Field]
        public string DiaChiDonKhachMoi { get; set; }
    
        [Field]
        public string DiaChiDonKhachCu { get; set; }
    
        [Field]
        public string KieuKhachHangGoiDen { get; set; }
    
        [Field]
        public string XeDon { get; set; }
    
        [Field]
        public string GhiChuDienThoai { get; set; }
    
        [Field]
        public string GhiChuTongDai { get; set; }
    
        [Field]
        public int KieuCuocGoi { get; set; }
    
        [Field]
        public string MaDoiTac { get; set; }
    
        [Field]
        public string GhiChuLaiXe { get; set; }
    
        [Field]
        public Guid? BookId { get; set; }
    
        [Field]
        public int G5_Type { get; set; }
    
        [Field]
        public DateTime UpdatedTime { get; set; }
    
        [Field]
        public string UpdatedBy { get; set; }

        public DataTable GetDataAddressTrace(DateTime pFrom, DateTime pTo, string pMaDoiTac, string pSDT)
        {
            return this.ExeStore("sp_GetDataAddressTrace", pFrom, pTo, pMaDoiTac, pSDT);
        }
    }
}
