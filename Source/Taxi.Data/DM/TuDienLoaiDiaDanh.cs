using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Taxi.Utils;

namespace Taxi.Data.DM
{
    // <summary>
    /// Thực hiện ra vào dữ liệu liên quan tới danh mục hệ tiêu chuẩn
    /// </summary>
    /// <Modified>
    ///     Author          Date            Comments
    ///     Tuanpv       02/07/2008         Tạo mới
    /// </Modified>
   public  class TuDienLoaiDiaDanh : DBObject
    {
       private string strConnString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
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
            SqlParameter[] arrSqlPara = { new SqlParameter("@TenLoaiDiaDanh", SqlDbType.NVarChar,50)};
            arrSqlPara[0].Value = TenLoaiDiaDanh;
            try 
            {
                int rowAffected = SqlHelper.ExecuteNonQuery(strConnString, "sp_TuDien_LoaiDiaDanh_ThemMoi", arrSqlPara);
                if (rowAffected > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) 
            {
                throw new Exception("Có lỗi xảy ra, thêm mới hệ tiêu chuẩn không thực hiện được.");
            }
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
        public int CapNhat( int LoaiDiaDanhID,string TenLoaiDiaDanh )
        {
            SqlParameter[] arrSqlPara = { new SqlParameter("@PK_LoaiDiaDanh", SqlDbType.Int),
                 new SqlParameter("@TenLoaiDiaDanh", SqlDbType.NVarChar, 50)};

            arrSqlPara[0].Value = LoaiDiaDanhID;
            arrSqlPara[1].Value = TenLoaiDiaDanh;
            try 
            {
                int rowAffected = SqlHelper.ExecuteNonQuery(strConnString, "sp_TuDien_LoaiDiaDanh_CapNhat", arrSqlPara);
                if (rowAffected > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) 
            {
                throw new Exception("Có lỗi xảy ra, cập nhật hệ tiêu chuẩn không thực hiện được.");
            }
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
            SqlParameter[] arrSqlPara = { new SqlParameter("@PK_LoaiDiaDanh", SqlDbType.Int) };
            arrSqlPara[0].Value = LoaiDiaDanhID;
            try
            {
                int rowAffected = SqlHelper.ExecuteNonQuery(strConnString, "sp_TuDien_LoaiDiaDanh_Xoa", arrSqlPara);
                if (rowAffected > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra, xóa hệ tiêu chuẩn không thực hiện được.");
            }
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
            SqlParameter[] arrSqlPara = { };
            try
            {
                DataSet dsPhuongThucPhat = SqlHelper.ExecuteDataset(strConnString, "sp_TuDien_LoaiDiaDanh_LayDanhSach", arrSqlPara);
                return dsPhuongThucPhat.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra, lấy danh sách hệ tiêu chuẩn không thực hiện được.");
            }
           
        }

        /// <summary>
        /// Kiểm tra một hệ tiêu chuẩn đã được sử dụng trong hệ thống dữ liệu chương trình
        /// </summary>
        /// <param name="TenLoaiDiaDanh">Tên của hệ tiêu chuẩn</param>
        /// <returns>1 nếu đã được sử dụng, 0 nếu chưa được sử dụng</returns>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        //public int KiemTraDaDuocSuDung(string TenLoaiDiaDanh)
        //{
        //    SqlParameter[] arrSqlPara = { new SqlParameter("@TenLoaiDiaDanh", SqlDbType.NVarChar, 50) };
        //    arrSqlPara[0].Value = TenLoaiDiaDanh;
        //    try
        //    {
        //        int rowAffected = SqlHelper.ExecuteNonQuery(strConnString, "sp_TuDien_LoaiDiaDanh_KiemTraDaDuocSuDung", arrSqlPara);
        //        if (rowAffected > 0)
        //            return 1;
        //        else
        //            return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Có lỗi xảy ra, kiểm tra hệ tiêu chuẩn đã được sử dụng không thực hiện được.");
        //    }
        //}

        /// <summary>
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
            SqlParameter[] arrSqlPara = { new SqlParameter("@TenLoaiDiaDanh", SqlDbType.NVarChar, 50) };
            arrSqlPara[0].Value = TenLoaiDiaDanh;
            try
            {
                DataSet dsPhuongThucPhat = SqlHelper.ExecuteDataset(strConnString, "sp_TuDien_LoaiDiaDanh_KiemTraTrungLap", arrSqlPara);
                if (dsPhuongThucPhat.Tables[0].Rows.Count > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra, kiểm tra trùng lặp hệ tiêu chuẩn không thực hiện được.");
            }
        }
    }
}
