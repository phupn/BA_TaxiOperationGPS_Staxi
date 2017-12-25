using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Taxi.Common.Extender;
using Taxi.Data.DieuXeDuongDai;
using Taxi.Utils;

namespace Taxi.Business.DieuXeDuongDai
{
    public class DUONGDAI_DONKHACH_XEDITINH
    {
        #region Field
        public long Id { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string DienThoai { get; set; }
        public string SoXe { get; set; }
        public string DiaChiDon { get; set; }
        public DateTime ThoiDiemDon { get; set; }
        public int TrangThai { get; set; }
        public bool IsDelete { get; set; }
        public string GhiChu { get; set; }
        public float TongTien { get; set; }
        public long FK_DUONGDAI_KHACHHEN { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public long IDCuocGoi { get; set; }
        public string NguoiNhap{get { return string.IsNullOrEmpty(UpdatedBy) ? CreatedBy : UpdatedBy; }}
        #endregion
        #region Hàm
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Insert()
        {
            using (var db = new DUONGDAI_DONKHACH_XEDITINH_DA())
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
            using (var db = new DUONGDAI_DONKHACH_XEDITINH_DA())
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
            using (var db = new DUONGDAI_DONKHACH_XEDITINH_DA())
            {
                db.Id = this.Id;
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
            using (var db = new DUONGDAI_DONKHACH_XEDITINH_DA())
            {
                return db.GetAll();
            }
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>List</returns>
        public List<DUONGDAI_DONKHACH_XEDITINH> GetList()
        {
            return GetAll().ToList<DUONGDAI_DONKHACH_XEDITINH>();
        }

        public List<DUONGDAI_DONKHACH_XEDITINH> TimKiem(DateTime deStart, DateTime deEnd, string soxe, string sdt, string diaChi, int trangthai)
        {
            using (var db = new DUONGDAI_DONKHACH_XEDITINH_DA())
            {
                return db.TimKiem(deStart, deEnd,soxe, sdt, diaChi,trangthai).ToList<DUONGDAI_DONKHACH_XEDITINH>();
            }
        }

        public List<DUONGDAI_DONKHACH_XEDITINH> GetLichSu(long id)
        {
            using (var db = new DUONGDAI_DONKHACH_XEDITINH_DA())
            {
                return db.GetLichSu(id).ToList<DUONGDAI_DONKHACH_XEDITINH>();
            }
        }
        #endregion

        public static DateTime GetTimeServer()
        {
            using (var db = new DUONGDAI_DONKHACH_XEDITINH_DA())
            {
                return db.GetTimeServer();
            }
        }
    }
}
