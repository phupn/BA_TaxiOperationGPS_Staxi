using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace Taxi.Data.DM
{
    /// <summary>
    /// Thao tác với cơ sở dữ liệu liên quan đến đối tượng phòng
    /// </summary>
    /// <Modified>
    ///	Name		Date		Comment 
    ///	TuanND		31/01/2008	Thêm mới
    ///	</Modified>
  public  class TuDienPhong
    {
        //Connection dùng chung
      public string connString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
       
        //Hàm khởi tạo mặc định
        public TuDienPhong() 
        { 
        }       
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
            SqlParameter[] arrPara = { };
            return SqlHelper.ExecuteDataset(this.connString, "sp_T_TuDien_Phong_LayDS", arrPara).Tables[0];
        }
        /// <summary>
        /// Lấy thông tin chi tiết của một phòng ban
        /// </summary>
        /// <param name="PhongID">ID của phòng ban</param>
        /// <returns>DataRow chứa thông tin chi tiết của phòng ban</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public DataRow LayTheoID(int PhongID)
        {
            SqlParameter[] arrPara = { new SqlParameter("@PhongID", SqlDbType.Int) };

            arrPara[0].Value = PhongID;

            try
            {
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "sp_T_TuDien_Phong_LayTheoID", arrPara);
                return dsPhong.Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Thêm mới một phòng vào cơ sở dữ liệu
        /// </summary>
        /// <param name="TenPhong">Tên phòng</param>
        /// <param name="QuyenCapPhepHoSo">Quyền cấp phép hồ sơ</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///	Name		Date			Comment 
        ///	TuanND		31/01/2008		Thêm mới
        /// </Modified>
        public bool ThemMoi(string TenPhong)
        {
            SqlParameter[] arrPara = {new SqlParameter("@TenPhong",SqlDbType.NVarChar,50)};
            arrPara[0].Value=TenPhong;
           
            try
            {       
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TuDien_Phong_ThemMoi", arrPara);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Cập nhật thông tin cho một phòng
        /// </summary>
        /// <param name="PhongID">ID phòng</param>
        /// <param name="TenPhong">Tên phòng</param>
        /// <param name="QuyenCapPhepHoSo">Quyền cấp phép hồ sơ</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public bool CapNhat(int PhongID,string TenPhong)
        {
            SqlParameter[] arrPara = { new SqlParameter("@PhongID", SqlDbType.Int ),
                                       new SqlParameter("@TenPhong", SqlDbType.NVarChar,50)};
            arrPara[0].Value = PhongID;
            arrPara[1].Value = TenPhong;            
            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TuDien_Phong_CapNhat", arrPara);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Xóa một phòng khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="PhongID">ID phòng</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public bool Xoa(int PhongID)
        {
            SqlParameter[] arrPara = { new SqlParameter("@PhongID", SqlDbType.Int) };
            arrPara[0].Value = PhongID;
            
            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TuDien_Phong_Xoa", arrPara);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Kiểm tra trùng lặp phòng giữa các tên phòng
        /// </summary>
        /// <param name="TenPhong">Tên phòng</param>
        /// <returns>True nếu trùng lặp, False nếu ngược lại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public bool KiemTraTrungLap(string TenPhong)
        {
            SqlParameter[] arrPara = { new SqlParameter("@TenPhong", SqlDbType.NVarChar, 255) };

            arrPara[0].Value = TenPhong;

            try
            {
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "sp_T_TuDien_Phong_KiemTraTrungLap", arrPara);
                if (dsPhong.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
