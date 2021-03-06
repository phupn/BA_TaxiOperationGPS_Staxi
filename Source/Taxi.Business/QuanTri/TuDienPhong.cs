using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace Taxi.Business
{
    /// <summary>
    /// Thao tác với cơ sở dữ liệu liên quan đến đối tượng phòng
    /// </summary>
    /// <Modified>
    ///	Name		Date		Comment 
    ///	TuanND	  31/01/2008	Thêm mới
    /// Tuanpv    28/02/2008    Thêm mới phương thức kiểm tra một phòng đã có trưởng phòng hay chưa?
    /// Tuanpv    30/05/2008    Thêm mới phương thức lấy danh sách các chuyên viên xử lý thuộc phòng
    ///	</Modified>
    public class TuDienPhong
    {
        
        #region Thuộc tính

        private string mTenPhong;

        public string TenPhong
        {
            get { return mTenPhong; }
            set { mTenPhong = value; }
        }
        private int mPhongID;
        public int PhongID
        {
            get { return mPhongID; }
            set { mPhongID = value; }
        }
        private int mQuyenCapPhepHoSo;

        public int QuyenCapPhepHoSo
        {
            get { return mQuyenCapPhepHoSo; }
            set { mQuyenCapPhepHoSo = value; }
        }
        #endregion

        #region Các hàm khởi tạo

        public TuDienPhong() { }
        
        public TuDienPhong(int PhongID)
            : this()
        {
            this.mPhongID = PhongID;
            Taxi.Data.TuDienPhong objPhong = new Taxi.Data.TuDienPhong();
            DataRow dr = objPhong.LayTheoID(PhongID);
            this.mTenPhong = dr["TenPhong"].ToString();
            this.mQuyenCapPhepHoSo = int.Parse(dr["QuyenCapPhepHoSo"].ToString()); 
            
        }
        #endregion

        /// <summary>
        /// Lấy danh sách phòng ban có trong cơ sở dữ liệu
        /// </summary>
        /// <returns>Danh sách các phòng ban</returns>
        /// <Modified>
        ///	Name		Date			Comment 
        ///	TuanND		31/01/2008		Thêm mới
        ///	</Modified>
        public DataTable LayDanhSach()
        {
            Taxi.Data.TuDienPhong objTuDienPhong = new Taxi.Data.TuDienPhong();
            return objTuDienPhong.LayDanhSach();
        }
        /// <summary>
        /// Thêm mới một phòng vào cơ sở dữ liệu
        /// </summary>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///	Name		Date			Comment 
        ///	TuanND		31/01/2008		Thêm mới
        /// </Modified>
        public bool ThemMoi()
        {
            Taxi.Data.TuDienPhong objTuDienPhong = new Taxi.Data.TuDienPhong();
            return objTuDienPhong.ThemMoi(this.TenPhong,this.QuyenCapPhepHoSo);
        }
        /// <summary>
        /// Cập nhật thông tin cho một phòng
        /// </summary>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public bool CapNhat()
        {
            Taxi.Data.TuDienPhong objTuDienPhong = new Taxi.Data.TuDienPhong();
            return objTuDienPhong.CapNhat(this.PhongID,this.TenPhong,this.QuyenCapPhepHoSo);
        }
        /// <summary>
        /// Xóa một phòng khỏi cơ sở dữ liệu
        /// </summary>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public bool Xoa()
        {
            Taxi.Data.TuDienPhong objTuDienPhong = new Taxi.Data.TuDienPhong();
            return objTuDienPhong.Xoa(this.PhongID );
        }
        /// <summary>
        /// Kiểm tra trùng lặp phòng giữa
        /// hai lần thêm mới hoặc cập nhật
        /// </summary>
        /// <returns>True nếu trùng lặp, False nếu ngược lại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public bool KiemTraTrungLap(string TenPhong)
        {
            Taxi.Data.TuDienPhong objTuDienPhong = new Taxi.Data.TuDienPhong();
            return objTuDienPhong.KiemTraTrungLap(TenPhong);
        }

        /// <summary>
        /// Kiểm tra xem một phòng đã có trưởng phòng hay chưa?
        /// </summary>
        /// <param name="TenPhong">Mã của phòng</param>
        /// <returns>True nếu phòng đã có trưởng phòng, False nếu phòng chưa có trưởng phòng</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Tuanpv    28/2/2008     Tạo mới
        /// </Modified>
        public bool DaCoTruongPhong(int PhongID) 
        {
            Taxi.Data.TuDienPhong objPhong = new Taxi.Data.TuDienPhong();
            return objPhong.DaCoTruongPhong(PhongID);
        }

        /// <summary>
        /// Lấy ra danh sách các phòng có được quyền cấp phép hồ sơ
        /// </summary>
        /// <returns>Bảng các phòng</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Tuanpv    28/2/2008     Tạo mới
        /// </Modified>
        public DataTable LayDSPhongCoQuyenCapPhepHoSo() 
        {
            Taxi.Data.TuDienPhong objPhong = new Taxi.Data.TuDienPhong();
            return objPhong.LayDSPhongCoQuyenCapPhepHoSo();
        }
        /// <summary>
        /// Kiểm tra phòng đã có người giữ chức vụ trưởng phòng chưa
        /// </summary>
        /// <returns>True nếu có trưởng phòng rồi, False nếu ngược lại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    28/02/2008    Tạo mới
        /// </Modified>
        public bool DaCoChucVu(int ChucVuID)
        {
            Taxi.Data.TuDienPhong objTuDienPhong = new Taxi.Data.TuDienPhong();
            return objTuDienPhong.DaCoChucVu(mPhongID,ChucVuID);
        }

        /// <summary>
        /// Lấy ra danh sách các chuyên viên xử lý thuộc phòng
        /// </summary>
        /// <param name="PhongID">Mã phòng</param>
        /// <returns>Bảng danh sách chuyên viên</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Tuanpv    30/05/2008    Tạo mới
        /// </Modified>
        public DataTable LayDanhSachChuyenVienThuocPhong(int PhongID) 
        {
            Taxi.Data.TuDienPhong objPhong = new Taxi.Data.TuDienPhong();
            return objPhong.LayDanhSachChuyenVienThuocPhong(PhongID);
        }
    }
}
