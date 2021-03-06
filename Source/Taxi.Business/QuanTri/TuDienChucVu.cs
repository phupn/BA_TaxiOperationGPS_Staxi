using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Data;
using Microsoft.ApplicationBlocks.Data;
namespace Taxi.Business
{
    /// <summary>
    /// Tầng Business của đối tượng từ điển chúc vụ
    /// <Modified>
    ///     Author      Date        Comments
    ///     TuanND    18/2/2008    Tạo mới
    ///     LamDS       31/03/2008  Thêm phương thức lấy danh sách người ký
    /// </Modified>
    /// </summary>
    public class TuDienChucVu
    {
        #region Thuộc tính

        private string mTenChucVu;

        public string TenChucVu
        {
            get { return mTenChucVu; }
            set { mTenChucVu = value; }
        }
        #endregion
        #region Constructor

        public TuDienChucVu() { }
        public TuDienChucVu(string strTenChucVu) 
        {
            this.TenChucVu = strTenChucVu;
                       
        }
        
        #endregion
        
        
        public DataTable LayDanhSach()
        {
            Taxi.Data.TuDienChucVu objTuDienChucVu = new Taxi.Data.TuDienChucVu();
            return objTuDienChucVu.LayDanhSach();
        }
        public DataTable LayDanhSachKhongCoTruongPhong()
        {
            Taxi.Data.TuDienChucVu objTuDienChucVu = new Taxi.Data.TuDienChucVu();
            return objTuDienChucVu.LayDanhSachKhongCoTruongPhong();
        }
        public bool ThemMoi()
        {
            Taxi.Data.TuDienChucVu objTuDienChucVu = new Taxi.Data.TuDienChucVu();
            return objTuDienChucVu.ThemMoi(TenChucVu);
        }
        public bool CapNhat(string TenChucVuCu)
        {
            Taxi.Data.TuDienChucVu objTuDienChucVu = new Taxi.Data.TuDienChucVu();
            return objTuDienChucVu.CapNhat(TenChucVuCu, TenChucVu);
        }
        public bool Xoa()
        {
            Taxi.Data.TuDienChucVu objTuDienChucVu = new Taxi.Data.TuDienChucVu();
            return objTuDienChucVu.Xoa(TenChucVu);
        }
        public bool KiemTraTrungLap()
        {
            Taxi.Data.TuDienChucVu objTuDienChucVu = new Taxi.Data.TuDienChucVu();
            return objTuDienChucVu.KiemTraTrungLap(this.TenChucVu);
        }

        /// <summary>
        /// Lấy danh sách người ký
        /// </summary>
        /// <returns>Danh sách người ký</returns>
        /// <Modified>
        /// Name        Date        Comment
        /// LamDS       31/03/2008  Thêm mới
        /// </Modified>
        public DataTable LayDanhSachnguoiKy()
        {
            Taxi.Data.TuDienChucVu objChucVu = new Taxi.Data.TuDienChucVu();
            return objChucVu.LayDanhSachnguoiKy();
        }
    }
}
