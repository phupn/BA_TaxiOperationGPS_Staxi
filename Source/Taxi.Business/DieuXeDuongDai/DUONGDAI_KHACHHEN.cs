using System;
using System.Collections.Generic;
using System.Data;
using Taxi.Common.Extender;
using Taxi.Data.DieuXeDuongDai;
using Taxi.Utils;

namespace Taxi.Business.DieuXeDuongDai
{
    public class DUONGDAI_KHACHHEN
    {
        #region Field
        public long Id { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string TenKhachHang { get; set; }
        public string DienThoai { get; set; }
        public string DiaChiDon { get; set; }
        public DateTime ThoiDiemDon { get; set; }
        public string LoaiXe { get; set; }
        public int SoPhutBaoTruoc { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string GhiChuDieu { get; set; }
        public string XeNhan { get; set; }
        public string MaNVDieu { get; set; }
        public DateTime ThoiDiemDieu { get; set; }
        public string XeDon { get; set; }
        public float TongTien { get; set; }
        public string DiaChiTra { get; set; }
        public float KinhDo { get; set; }
        public float ViDo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public long IDCuocGoi { get; set; }
        #endregion

        #region Hàm
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Insert()
        {
            using (var db=new DUONGDAI_KHACHHEN_DA())
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
            using (var db = new DUONGDAI_KHACHHEN_DA())
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
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                db.Id=this.Id;
                db.UpdatedBy = this.UpdatedBy;
                return db.Delete();
            }
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>DataTable.</returns>
        public DataTable GetAll()
        {
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                return db.GetAll();
            }
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>List</returns>
        public List<DUONGDAI_KHACHHEN> GetList()
        {
            return GetAll().ToList<DUONGDAI_KHACHHEN>();
        }

        public List<DUONGDAI_KHACHHEN> TimKiem(DateTime deStart, DateTime deEnd, string sdt, string diaChi)
        {
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                return db.TimKiem(deStart, deEnd, sdt, diaChi).ToList<DUONGDAI_KHACHHEN>();
            }
        }

        public List<DUONGDAI_KHACHHEN> GetLichSu(long id)
        {
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                return db.GetLichSu(id).ToList<DUONGDAI_KHACHHEN>();
            }
        }
        /// <summary>
        /// Hàm sử dụng ở điều xe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DUONGDAI_KHACHHEN> GetByTime(DateTime?id)
        {
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                return db.GetByTime(id).ToList<DUONGDAI_KHACHHEN>();
            }
        }
        public List<DUONGDAI_KHACHHEN> DieuxeTimKiem(DateTime? dt, string dienthoai, string diachi, string tenkhachhang)
        {
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                return db.DieuxeTimKiem(dt,dienthoai,diachi,tenkhachhang).ToList<DUONGDAI_KHACHHEN>();
            }
        }

        public bool UpdateDieuXe()
        {
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                db.CopyTo(this);
                return db.UpdateDieuXe();
            }
            return false;
        }
        #endregion

        public static DateTime GetTimeServer()
        {
            using (var db = new DUONGDAI_KHACHHEN_DA())
            {
                return db.GetTimeServer();
            }
        }
    }
}
