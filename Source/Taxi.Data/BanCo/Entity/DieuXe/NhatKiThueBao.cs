using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System;
using System.Data.SqlTypes;
using System.Data;
using Taxi.Data.BanCo.Entity.DieuXe;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "[TRUNGKIEN.T_NHATKYTHUEBAO]")]
    public class NhatKiThueBao : TaxiOperationDbEntityBase<NhatKiThueBao>
    {
        /*
         * [ID]
      ,[ThoiDiem]
      ,[SoHieuXe]
      ,[TenLaiXe]
      ,[TuyenDuongID]
      ,[TenTuyenDuong]
      ,[ThoiGianDon]
      ,[KmDon]
      ,[ThoiGianTra]
      ,[KmTra]
      ,[KmThucDi]
      ,[DongHoTien]
      ,[PhuTroi]
      ,[TienThucThu]
      ,[MaNhanVienNhap]
      ,[GhiChu]
      ,[Chieu]
      ,[SoLanSua]
      ,[LoaiXeID]
      ,[GiaThueBao]
      ,[IsQuanToan]
      ,[SoDienThoai]
      ,[ThoiDiemSua]*/
        [Field(IsKey = true, IsIdentity = false)]
        public SqlInt64 ID { get; set; }
        [Field]
        public SqlDateTime ThoiDiem { get; set; }
        [Field]
        public SqlString SoHieuXe { get; set; }
        [Field]
        public SqlString TenLaiXe { get; set; }
        [Field]
        public SqlString TuyenDuongID { get; set; }
        [Field]
        public SqlString TenTuyenDuong { get; set; }
        [Field]
        public SqlDateTime ThoiGianDon { get; set; }
        [Field]
        public SqlInt32 KmDon { get; set; }
        
        [Field]
        public SqlDateTime ThoiGianTra { get; set; }
        [Field]
        public SqlInt32 KmTra { get; set; }
        [Field]
        public SqlDouble KmThucDi { get; set; }
        [Field]
        public SqlInt32 DongHoTien { get; set; }
        [Field]
        public SqlString PhuTroi { get; set; }
        [Field]
        public SqlDouble TienThucThu { get; set; }
        [Field]
        public SqlString MaNhanVienNhap { get; set; }
        [Field]
        public SqlString GhiChu { get; set; }
        [Field]
        public SqlInt32 Chieu { get; set; }
        [Field]
        public SqlInt32 SoLanSua { get; set; }
        [Field]
        public SqlInt32 LoaiXeID { get; set; }
        [Field]
        public SqlString GiaThueBao { get; set; }
        [Field]
        public SqlBinary IsQuanToan { get; set; }
        [Field]
        public SqlString SoDienThoai { get; set; }
        [Field]
        public SqlDouble ThoiDiemSua { get; set; }
        public List<NhatKiThueBao> GetListAll()
        {
            var dt=GetAll();
            if (dt.Rows.Count > 0)
            {
                return dt.ToList<NhatKiThueBao>();
            }
            return new List<NhatKiThueBao>();
        }
        public DataTable GetListAllStore()
        {
            return  ExeStore("sp_NhatKiThueBao_GetAll");//.ToList<NhatKiThueBao>();
        }

        public DataTable GetListAllStore(ThongTinTimKiem tttk)
        {
            return this.ExeStore("sp_NhatKiThueBao_GetAll_v2", tttk.SoXe); // DieuCuocHangEntity
        }

        public List<NhatKiThueBao> TimKiem(DateTime NgayDi,DateTime NgayDen,string SoHieuXe,string TimKiem)
        {
            return ExeStore("SP_T_NhatKyCuocGoi_TimKiem", NgayDi, NgayDen, SoHieuXe, TimKiem).ToList<NhatKiThueBao>();
        }
        public List<NhatKiThueBao> GetListXeDiTuyen()
        {
            return ExeStore("SP_T_NhatKyCuocGoi_XeDiTuyen").ToList<NhatKiThueBao>();
        }
    }
}
