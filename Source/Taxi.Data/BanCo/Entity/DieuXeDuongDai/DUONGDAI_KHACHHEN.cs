using System;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;

namespace Taxi.Data.BanCo.Entity.DieuXeDuongDai
{
    [TableInfo(TableName = "DUONGDAI_KHACHHEN")]
    public class DUONGDAI_KHACHHEN : TaxiOperationDbEntityBase<DUONGDAI_KHACHHEN>
    {
        [Field]
        public long Id { get; set; }
        [Field]
        public DateTime ThoiDiemGoi { get; set; }
        [Field]
        public string TenKhachHang { get; set; }
        [Field]
        public string DienThoai { get; set; }
        [Field]
        public string DiaChiDon { get; set; }
        [Field]
        public DateTime ThoiDiemDon { get; set; }
        [Field]
        public string LoaiXe { get; set; }
        [Field]
        public int SoPhutBaoTruoc { get; set; }
        [Field]
        public int TrangThai { get; set; }
        [Field]
        public string GhiChu { get; set; }
        [Field]
        public string XeNhan { get; set; }
        [Field]
        public string MaNVDieu { get; set; }
        [Field]
        public DateTime ThoiDiemDieu { get; set; }
        [Field]
        public string XeDon { get; set; }
        [Field]
        public float TongTien { get; set; }
        [Field]
        public string DiaChiTra { get; set; }
        [Field]
        public float KinhDo { get; set; }
        [Field]
        public float ViDo { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string CreatedBy { get; set; }
        [Field]
        public DateTime UpdatedDate { get; set; }
        [Field]
        public string UpdatedBy { get; set; }
    }
}
