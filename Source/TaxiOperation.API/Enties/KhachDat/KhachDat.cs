using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace TaxiOperation.API.Enties.KhachDat
{
    [TableInfo(TableName = "T_KHACHDAT")]
    public class KhachDat : EntityBase<KhachDat>
    {
        #region== Properties==

        [Field(IsKey = true, IsIdentity = true)]
        public int PK_KhachDatID { get; set; }
        [Field]
        public DateTime ThoiDiemTiepNhan { get; set; }
        [Field]
        public string TenKhachHang { get; set; }
        [Field]
        public string DiaChiDon { get; set; }
        [Field]
        public string DiaChiTra { get; set; }
        [Field]
        public string SoDienThoai { get; set; }
        [Field]
        public int VungKenh { get; set; }
        [Field]
        public bool IsLapLai { get; set; }
        [Field]
        public DateTime GioDon { get; set; }
        [Field]
        public DateTime ThoiDiemBatDau { get; set; }
        [Field]
        public DateTime ThoiDiemKetThuc { get; set; }
        [Field]
        public string NgayTrongTuanLapLai { get; set; }
        [Field]
        public int SoPhutBaoTruoc { get; set; }
        [Field]
        public long FK_CuocGoiID { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string CreatedBy { get; set; }
        [Field]
        public DateTime UpdatedDate { get; set; }
        [Field]
        public string UpdatedBy { get; set; }
        [Field]
        public string GhiChu { get; set; }
        [Field]
        public string IDCuocGoi_LapLai { get; set; }
        [Field]
        public bool IsDaChenCuocGoi { get; set; }
        [Field]
        public string LoaiXe { get; set; }
        [Field]
        public int SoLuongXe { get; set; }
        [Field]
        public DateTime UpdatedDateKD { get; set; }
        [Field]
        public float KinhDo { get; set; }
        [Field]
        public float ViDo { get; set; }
        [Field]
        public int SoTien { get; set; }
        [Field]
        public float SoKm { get; set; }
        [Field]
        public int FK_SystemBookID { get; set; }
     
        #endregion

        #region== Method===
        public DateTime GetTimerServer()
        {
            return GetTimeServer().To<DateTime>();
            
        }
        /// <summary>
        /// Cập nhật thông tin khách đặt, chưa viết stored
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void UpdateById()
        {
            ExeStoreNoneQuery("SP_T_KHACHDAT_UPDATE_NEW");
        }

        public int Insert()
        {
            return ExeStore("SP_T_KHACHDAT_INSERT_NEW").Rows[0][0].To<int>();
        }
        #endregion
    }
}