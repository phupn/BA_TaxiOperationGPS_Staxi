using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Data.BanCo.DbConnections;
using System.Data;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.TuyenThueBao
{
    [TableInfo(TableName = "T_KHACHDAT")]
    public class DSKhachDat : TaxiOperationDbEntityBase<DSKhachDat>
    {
        [Field(IsKey = true,IsIdentity=true)]
        public int PK_KhachDatID { get; set; }

        [Field]
        public string TenKhachHang { get; set; }

        [Field]
        public bool IsLapLai { get; set; }

        [Field]
        public string NgayTrongTuanLapLai { get; set; }

        [Field]
        public DateTime GioDon { get; set; }

        [Field]
        public string SoDienThoai { get; set; }

        [Field]
        public DateTime ThoiDiemTiepNhan { get; set; }

        [Field]
        public DateTime ThoiDiemBatDau { get; set; }

        [Field]
        public DateTime ThoiDiemKetThuc { get; set; }


        [Field]
        public string DiaChiDon { get; set; }
        
        [Field]
        public string SoPhutBaoTruoc { get; set; }
        
        [Field]
        public string LoaiXe { get; set; }
        
        [Field]
        public string SoLuongXe { get; set; }
        
        [Field]
        public string GhiChu { get; set; }

        [Field]
        public string TenLoaiXe { get; set; }

        [Field]
        public string XeNhanDon { get; set; }

        [Field]
        public int VungKenh { get; set; }


        [Field]
        public string CreatedBy { get; set; }

        [Field]
        public string UpdatedBy { get; set; }

        [Field]
        public DateTime UpdatedDate { get; set; }

        [Field]
        public string YeuCau { get; set; }

        [Field]
        public int TrangThai { get; set; }

        [Field]
        public string DuongPho { get; set; }


        public List<DSKhachDat> getDSKhachDat(params object[] para) {
            return getListKhachDat(para).ToList<DSKhachDat>();
        }

        public DataTable getListKhachDat(params object[] para) {
            var val= ExeStore("sp_T_KHACHDAT_DS_KHACHDAT",para);
            return val;

        }
    }
}
