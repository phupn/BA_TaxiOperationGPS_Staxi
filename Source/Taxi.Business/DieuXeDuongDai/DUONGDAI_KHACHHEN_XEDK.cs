using System;
using System.Collections.Generic;
using System.Data;
using Taxi.Common.Extender;
using Taxi.Data.DieuXeDuongDai;
using Taxi.Utils;

namespace Taxi.Business.DieuXeDuongDai
{
    public class DUONGDAI_KHACHHEN_XEDK
    {
        #region Field
        public long Id { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string DienThoai { get; set; }
        public string SoXe { get; set; }
        public string DiemDo { get; set; }
        public DateTime ThoiDiemDon { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
        public long FK_DUONGDAI_KHACHHEN { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ?UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public long IDCuocGoi { get; set; }
        public string NguoiNhap {get{return (string.IsNullOrEmpty(UpdatedBy) ? CreatedBy : UpdatedBy);}}
        public string TenLaiXe { get; set; }
        public string GioCho
        {
            get
            {
            if (ThoiDiemGoi > DateTime.MinValue)
            {
                var time = (GetTimeServer() - ThoiDiemGoi).TotalHours;
                var hour = (long) time;
                var mitu = (long) ((time - hour)*60);
                return string.Format("{0}:{1}",hour,mitu);
            }
            return string.Empty;
        }}
        public int IsXeDangKy { get; set; }
        public bool IsDelete { get; set; }
        #endregion

        #region Hàm
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Insert()
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                db.CopyTo(this);
                return db.Insert();
            }
        }
        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Update()
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                db.CopyTo(this);
                return db.Update();
            }
        }

      
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Delete()
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                db.Id = this.Id;
                db.UpdatedBy = this.UpdatedBy;
                return db.Delete();
            }
        }
        public bool DeleteDieuXe()
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                db.Id = this.Id;
                db.UpdatedBy = this.UpdatedBy;
                db.TrangThai = this.TrangThai;
                db.GhiChu = this.GhiChu;
                db.IsXeDangKy = this.IsXeDangKy;
                return db.DeleteDieuXe();
            }
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>DataTable.</returns>
        public DataTable GetAll()
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                return db.GetAll();
            }
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>List</returns>
        public List<DUONGDAI_KHACHHEN_XEDK> GetList()
        {
            return GetAll().ToList<DUONGDAI_KHACHHEN_XEDK>();
        }

        public List<DUONGDAI_KHACHHEN_XEDK> TimKiem(DateTime deStart, DateTime deEnd, string sdt, string soxe, int trangthai)
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                return db.TimKiem(deStart, deEnd, sdt,soxe, trangthai).ToList<DUONGDAI_KHACHHEN_XEDK>();
            }
        }

        public List<DUONGDAI_KHACHHEN_XEDK> GetLichSu(long id)
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                return db.GetLichSu(id).ToList<DUONGDAI_KHACHHEN_XEDK>();
            }
        }

        public List<DUONGDAI_KHACHHEN_XEDK> GetByTime(DateTime ?dt)
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                var d= db.GetByTime(dt).ToList<DUONGDAI_KHACHHEN_XEDK>();
                return d;
            }
        }
        public bool UpdateDieuXe()
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                db.CopyTo(this);
                return db.UpdateDieuXe();
            }
        }

        public List<DUONGDAI_KHACHHEN_XEDK> DieuxeTimKiem(DateTime? dt,string soXe,string diemDo)
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                db.CopyTo(this);
                return db.DieuxeTimKiem(dt,soXe,diemDo).ToList<DUONGDAI_KHACHHEN_XEDK>();
            }
        }
        #endregion

        public static DateTime GetTimeServer()
        {
            using (var db = new DUONGDAI_KHACHHEN_XEDK_DA())
            {
                return db.GetTimeServer();
            }
        }
    }
}
