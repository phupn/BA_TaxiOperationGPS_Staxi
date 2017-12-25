using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Data.DM;

namespace Taxi.Business.DM
{
    /// <summary>
    /// Lớp thể hiện đối tượng hệ tiêu chuẩn
    /// </summary>
    /// <Modified>
    ///     Author          Date            Comments
    ///     Tuanpv       02/07/2008         Tạo mới
    /// </Modified>
    public class TuDienLoaiDiaDanh
    {
        //Properties
        private string mTenLoaiDiaDanh = "";
        public string TenLoaiDiaDanh 
        {
            get { return mTenLoaiDiaDanh; }
            set { mTenLoaiDiaDanh = value; }
        }


        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        public TuDienLoaiDiaDanh() { }

        /// <summary>
        /// Thực hiện thêm mới một hệ tiêu chuẩn vào cơ sở dữ liệu
        /// </summary>
        /// <param name="TenLoaiDiaDanh">Tên hệ tiêu chuẩn muốn thêm mới</param>
        /// <returns>1 nếu thành công, 0 nếu thất bại</returns>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        public int ThemMoi(string TenLoaiDiaDanh) 
        {
            Taxi.Data.DM.TuDienLoaiDiaDanh objLoaiDiaDanh = new Taxi.Data.DM.TuDienLoaiDiaDanh();
            return objLoaiDiaDanh.ThemMoi(TenLoaiDiaDanh);
        }

        /// <summary>
        /// Sửa đổi thông tin của một hệ tiêu chuẩn
        /// </summary>
        /// <param name="TenLoaiDiaDanh">Tên mới</param>
        /// <param name="TenCu">Tên cũ muốn sửa</param>
        /// <returns>1 nếu thành công, 0 nếu thất bại</returns>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        public int CapNhat(int LoaiDiaDanhID,string TenLoaiDiaDanh ) 
        {
            Taxi.Data.DM.TuDienLoaiDiaDanh objLoaiDiaDanh = new Taxi.Data.DM.TuDienLoaiDiaDanh();
            return objLoaiDiaDanh.CapNhat(LoaiDiaDanhID,TenLoaiDiaDanh);
        }

        /// <summary>
        /// Xóa một hệ tiêu chuẩn khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="TenLoaiDiaDanh">Tên hệ tiêu chuẩn muốn xóa</param>
        /// <returns>1 nếu thành công, 0 nếu thất bại</returns>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        public int Xoa(int LoaiDiaDanhID) 
        {
            Taxi.Data.DM.TuDienLoaiDiaDanh objLoaiDiaDanh = new Taxi.Data.DM.TuDienLoaiDiaDanh();
            return objLoaiDiaDanh.Xoa(LoaiDiaDanhID);
        }

        /// <summary>
        /// Lấy danh sách các hệ tiêu chuẩn hiện có trong cơ sở dữ liệu
        /// </summary>
        /// <returns>Bảng danh sách các hệ tiêu chuẩn</returns>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        public DataTable LayDanhSach() 
        {
            Taxi.Data.DM.TuDienLoaiDiaDanh objLoaiDiaDanh = new Taxi.Data.DM.TuDienLoaiDiaDanh();
            return objLoaiDiaDanh.LayDanhSach();
        }

        ///// <summary>
        ///// Kiểm tra một hệ tiêu chuẩn đã được sử dụng trong hệ thống dữ liệu chương trình
        ///// </summary>
        ///// <param name="TenLoaiDiaDanh">Tên của hệ tiêu chuẩn</param>
        ///// <returns>1 nếu đã được sử dụng, 0 nếu chưa được sử dụng</returns>
        ///// <Modified>
        /////     Author          Date            Comments
        /////     Tuanpv       02/07/2008         Tạo mới
        ///// </Modified>
        //public int KiemTraDaDuocSuDung(string TenLoaiDiaDanh) 
        //{
        //    Taxi.Da
        ///// <summaryta.DM.TuDienLoaiDiaDanh objLoaiDiaDanh = new Taxi.Data.DM.TuDienLoaiDiaDanh();
        //    return objLoaiDiaDanh.KiemTraDaDuocSuDung(TenLoaiDiaDanh);
        //}
 
        /// Kiểm tra khả năng trùng lặp với một hệ tiêu chuẩn đã tồn tại trong csdl khi thực hiện thêm mới hoặc cập nhật 1 hệ tiêu chuẩn
        /// </summary>
        /// <param name="TenLoaiDiaDanh">Tên hệ tiêu chuẩn muốn thêm mới</param>
        /// <returns>1 nếu trùng tên, 0 nếu không bị trùng</returns>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        public int KiemTraTrungTen(string TenLoaiDiaDanh) 
        {
            Taxi.Data.DM.TuDienLoaiDiaDanh objLoaiDiaDanh = new Taxi.Data.DM.TuDienLoaiDiaDanh();
            return objLoaiDiaDanh.KiemTraTrungTen(TenLoaiDiaDanh);
        }
    }
}
