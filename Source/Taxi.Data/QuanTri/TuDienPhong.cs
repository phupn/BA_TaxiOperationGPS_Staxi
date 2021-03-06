using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Taxi.Utils;
namespace Taxi.Data
{
    /// <summary>
    /// Thao tác với cơ sở dữ liệu liên quan đến đối tượng phòng
    /// </summary>
    /// <Modified>
    ///	Name		Date		Comment 
    ///	TuanND		31/01/2008	Thêm mới
    ///	</Modified>
    public class TuDienPhong : DBObject
    {
        //Connection dùng chung
        public string connString = null;// System.Configuration. ConfigurationSettings.AppSettings["Conn"].ToString();
       
        //Hàm khởi tạo mặc định
        public TuDienPhong() 
        {
            this.connString = this.ConnectionString;
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
            return SqlHelper.ExecuteDataset(this.connString, "sp_TuDien_Phong_LayDS", arrPara).Tables[0];
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
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "sp_TuDien_Phong_LayTheoID", arrPara);
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
        public bool ThemMoi(string TenPhong,int QuyenCapPhepHoSo)
        {
            SqlParameter[] arrPara = {new SqlParameter("@TenPhong",SqlDbType.NVarChar),
                                        new SqlParameter("@QuyenCapPhepHoSo",SqlDbType.Int)};
            arrPara[0].Value=TenPhong;
            arrPara[1].Value = QuyenCapPhepHoSo;
            try
            {       
                SqlHelper.ExecuteNonQuery(connString, "sp_TuDien_Phong_ThemMoi", arrPara);
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
        public bool CapNhat(int PhongID,string TenPhong, int QuyenCapPhepHoSo)
        {
            SqlParameter[] arrPara = { new SqlParameter("@PhongID", SqlDbType.Int ),
                                       new SqlParameter("@TenPhong", SqlDbType.NVarChar),
                                       new SqlParameter("@QuyenCapPhepHoSo", SqlDbType.Int )};
            arrPara[0].Value = PhongID;
            arrPara[1].Value = TenPhong;
            arrPara[2].Value = QuyenCapPhepHoSo;
            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_TuDien_Phong_CapNhat", arrPara);
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
                SqlHelper.ExecuteNonQuery(connString, "sp_TuDien_Phong_Xoa", arrPara);
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
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "sp_TuDien_Phong_KiemTraTrungLap", arrPara);
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
            SqlParameter[] arrSqlPara = { new SqlParameter("@PhongID", SqlDbType.Int) };
            arrSqlPara[0].Value = PhongID;

            try 
            {
                DataSet dsTruongPhong = SqlHelper.ExecuteDataset(connString, "sp_PhongBan_LayUserID_TruongPhong", arrSqlPara);
                DataTable dtTruongPhong = dsTruongPhong.Tables[0];
                dsTruongPhong.Dispose();
                if (dtTruongPhong.Rows.Count > 0)
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
                throw ex;
            }
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
            SqlParameter[] arrSqlPara = { };
            try
            {
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "sp_TuDienPhong_LayDS_PhongDuocQuyenCapPhep", arrSqlPara);
                DataTable dtPhong = dsPhong.Tables[0];
                dsPhong.Dispose();
                return dtPhong;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        /// <summary>
        /// Kiểm tra phòng đã có người giữ chức vụ trưởng phòng chưa
        /// </summary>
        /// <returns>True nếu có trưởng phòng rồi, False nếu ngược lại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     Cuongdb    28/02/2008    Tạo mới
        /// </Modified>
        public bool DaCoChucVu(int PhongID, int ChucVuID)
        {
            SqlParameter[] arrPara = { new SqlParameter("@PhongID", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@ChucVuID", SqlDbType.NVarChar, 50)};

            arrPara[0].Value = PhongID;
            arrPara[1].Value = ChucVuID;
            try
            {
                DataSet dsPhong = SqlHelper.ExecuteDataset(connString, "[sp_KiemTraTruongPhong]", arrPara);
                if (dsPhong.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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
            SqlParameter[] arrSqlPara = { new SqlParameter("@PhongID", SqlDbType.Int)};
            arrSqlPara[0].Value = PhongID;
            try
            {
                DataSet dsChuyenVien = SqlHelper.ExecuteDataset(connString, "sp_Phong_LayNhanVienThuocPhong", arrSqlPara);
                return dsChuyenVien.Tables[0];
            }
            catch (Exception ex) 
            {
                throw new Exception("Có lỗi xảy ra, lấy danh sách chuyên viên xử lý của phòng không thực hiện được.");
            }
        }
    }
}
