using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Configuration;

namespace Taxi.Data.DM
{
   public class TuDienLoaiXe
    {

     
        //Connection dùng chung
       public string connString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;

        //Hàm khởi tạo mặc định
       public TuDienLoaiXe()
        {
        }
        /// <summary>
        /// Lấy danh sách loại xe có trong cơ sở dữ liệu
        /// </summary>
        /// <returns>Danh sách các loại xe</returns>
        /// <Modified>
        ///	Name		Date			Comment 
        ///	Congnt		03/08/2008		Thêm mới
        ///	</Modified>
        public DataTable LayDanhSach()
        {
            SqlParameter[] arrPara = { };
            return SqlHelper.ExecuteDataset(this.connString, "sp_T_TUDIEN_LOAIXE_LayDS", arrPara).Tables[0];
        }
        /// <summary>
        /// Lấy thông tin chi tiết của một loại xe
        /// </summary>
        /// <param name="PhongID">ID của loại xe</param>
        /// <returns>DataRow chứa thông tin chi tiết của loại xe</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Congnt    03/08/2008    Tạo mới
        /// </Modified>
        public DataRow LayTheoID(int LoaiXeID)
        {
            SqlParameter[] arrPara = { new SqlParameter("@LoaiXeID", SqlDbType.Int) };

            arrPara[0].Value = LoaiXeID;

            try
            {
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "sp_T_TUDIEN_LOAIXE_LayTheoID", arrPara);
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
        ///	Congnt		03/08/2008		Thêm mới
        /// </Modified>
        public bool ThemMoi(string TenLoaiXe)
        {
            SqlParameter[] arrPara = { new SqlParameter("@TenLoaiXe", SqlDbType.NVarChar, 50) };
            arrPara[0].Value = TenLoaiXe;

            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TUDIEN_LOAIXE_ThemMoi", arrPara);
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
        ///     Congnt    03/08/2008    Tạo mới
        /// </Modified>
        public bool CapNhat(int LoaiXeID, string TenLoaiXe)
        {
            SqlParameter[] arrPara = { new SqlParameter("@LoaiXeID", SqlDbType.Int ),
                                       new SqlParameter("@TenLoaiXe", SqlDbType.NVarChar,50)};
            arrPara[0].Value = LoaiXeID;
            arrPara[1].Value = TenLoaiXe;
            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TUDIEN_LOAIXE_CapNhat", arrPara);
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
        ///     Congnt    03/08/2008    Tạo mới
        /// </Modified>
        public bool Xoa(int LoaiXeID)
        {
            SqlParameter[] arrPara = { new SqlParameter("@LoaiXeID", SqlDbType.Int) };
            arrPara[0].Value = LoaiXeID;

            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TUDIEN_LOAIXE_Xoa", arrPara);
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
        ///     Congnt    03/08/2008    Tạo mới
        /// </Modified>
        public bool KiemTraTrungLap(string TenLoaiXe)
        {
            SqlParameter[] arrPara = { new SqlParameter("@TenLoaiXe", SqlDbType.NVarChar, 255) };

            arrPara[0].Value = TenLoaiXe;

            try
            {
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "sp_T_TUDIEN_LOAIXE_KiemTraTrungLap", arrPara);
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
