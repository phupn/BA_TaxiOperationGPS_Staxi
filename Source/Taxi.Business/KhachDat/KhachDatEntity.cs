

using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Business.KhachDat
{
    [TableInfo (TableName="T_KHACHDAT")]
    public class KhachDatEntity:DbEntityBase<KhachDatEntity>
    {
        #region ====================Encapsulation field==================

        [Field(IsKey=true, IsIdentity = true)]
        public int PK_KhachDatID { get; set; }

        [Field]
        public DateTime ThoiDiemTiepNhan { get; set; }
        [Field]
        public string TenKhachHang { get; set; }
        [Field]
        public string DiaChiDon { get; set; }
        [Field]
        public string SoDienThoai { get; set; }
        [Field]
        public int VungKenh { get; set; }

        public int Line { get; set; }
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

        public string FULLNAME { get; set; }
        [Field]
        public DateTime UpdatedDate { get; set; }
        [Field]
        public string UpdatedBy { get; set; }
        [Field]
        public string GhiChu { get; set; }
        [Field]
        public string LoaiXe { get; set; }      //Dùng lưu mã loại xe trong SCarTaxi
        [Field]
        public string TenLoaiXe { get; set; }   //Dùng để hiển thị text loại xe!
        [Field]
        public int SoLuongXe { get; set; }
        [Field]
        public double KinhDo { get; set; }
        [Field]
        public double ViDo { get; set; }

        [Field]
        public double SoTien { get; set; }
        /// <summary>
        /// Trạng thái khách đặt.
        /// = -2 là Đã Xóa
        /// = -1 là Khách hoãn
        /// = 0 hoặc null là Chưa chèn
        /// = 1 là đã chèn 1 lần
        /// = 2 là đã chèn 2 lần
        /// </summary>
        [Field]
        public int StatusRow { get; set; }

        public string DiaChiTra { get; set; }
        public int FK_SystemBookID { get; set; }
        public float SoKm { get; set; }

        #endregion

        /// <summary>
        /// Update Status row
        /// </summary>
        /// <param name="PK_KhachDatID"></param>
        /// <param name="StatusRow"></param>
        /// <param name="UpdateDate"></param>
        /// <param name="UpdateBy"></param>
        /// <returns></returns>
        public bool UpdateStatus()
        {
            return ExeStoreNoneQuery("SP_T_KHACHDAT_UPDATE_STATUS", this.PK_KhachDatID, this.StatusRow, this.UpdatedBy) > 0;
        }

    }
}
