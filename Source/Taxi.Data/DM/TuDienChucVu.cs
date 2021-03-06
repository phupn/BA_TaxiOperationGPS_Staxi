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
    /// Tầng Data của đối tượng từ điển chúc vụ
    /// <Modified>
    ///     Author      Date        Comments
    ///     TuanND    18/2/2008    Tạo mới
    ///     LamDS       31/03/2008  Thêm phương thức lấy danh sách người ký
    /// </Modified>
    /// </summary>
  public   class TuDienChucVu
    {
        //Connection dùng chung
      public string connString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
       
        //Hàm khởi tạo mặc định
        public TuDienChucVu() { }

        /// <summary>
        /// Lấy danh sách chức vụ có trong cơ sở dữ liệu
        /// </summary>
        /// <returns>Danh sách các chức vụ</returns>
        /// <Modified>
        ///	Name		Date			Comment 
        ///	TuanND		18/02/2008		Thêm mới
        ///	</Modified>
        public DataTable LayDanhSach()
        {
            SqlParameter[] arrPara = { };
            return SqlHelper.ExecuteDataset(this.connString, "sp_T_TUDIEN_CHUCVU_LayDS", arrPara).Tables[0];
        }
        /// <summary>
        /// Thêm mới một chức vụ vào cơ sở dữ liệu
        /// </summary>
        /// <param></param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    18/02/2008    Tạo mới
        /// </Modified>
        public bool ThemMoi(string strTenChucVu)
        {
            SqlParameter[] arrPara = {new SqlParameter("@TenChucVu",SqlDbType.NVarChar)};
            arrPara[0].Value=strTenChucVu;
            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TUDIEN_CHUCVU_ThemMoi", arrPara);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Cập nhật thông tin cho một chức vụ
        /// </summary>
        /// <param name="TenChucVu">Tên chức vụ</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    18/02/2008    Tạo mới
        /// </Modified>
        public bool CapNhat(string strTenChucVuCu, string strTenChucVu)
        {
            SqlParameter[] arrPara = { new SqlParameter("@TenChucVuCu", SqlDbType.NVarChar),
                                       new SqlParameter("@TenChucVu", SqlDbType.NVarChar)};
            arrPara[0].Value = strTenChucVuCu;
            arrPara[1].Value = strTenChucVu;
            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TUDIEN_CHUCVU_CapNhat", arrPara);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Xóa một chức vụ khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="TenChucVu">Tên chức vụ</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    18/02/2008    Tạo mới
        /// </Modified>
        public bool Xoa(string strTenChucVu)
        {
            SqlParameter[] arrPara = { new SqlParameter("@TenChucVu", SqlDbType.NVarChar)};
            arrPara[0].Value = strTenChucVu;
            
            try
            {
                SqlHelper.ExecuteNonQuery(connString, "sp_T_TUDIEN_CHUCVU_Xoa", arrPara);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Kiểm tra trùng lặp chức vụ giữa
        /// hai lần thêm mới hoặc cập nhật
        /// </summary>
        /// <param name="TenChucVu">Tên chức vụ</param>
        /// <returns>True nếu trùng lặp, False nếu ngược lại</returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    18/02/2008    Tạo mới
        /// </Modified>
        public bool KiemTraTrungLap(string TenChucVu)
        {
            SqlParameter[] arrPara = { new SqlParameter("@TenChucVu", SqlDbType.NVarChar, 255) };

            arrPara[0].Value = TenChucVu;

            try
            {
                DataSet dsChucVu = SqlHelper.ExecuteDataset(connString, "sp_T_TUDIEN_CHUCVU_KiemTraTrungLap", arrPara);
                if (dsChucVu.Tables[0].Rows.Count > 0)
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
        /// Lấy danh sách chức vụ có trong cơ sở dữ liệu
        /// </summary>
        /// <returns>Danh sách các chức vụ</returns>
        /// <Modified>
        ///	Name		Date			Comment 
        ///	Cuongdb		28/02/2008		Thêm mới
        ///	</Modified>
        public DataTable LayDanhSachKhongCoTruongPhong()
        {
            SqlParameter[] arrPara = { };
            return SqlHelper.ExecuteDataset(this.connString, "sp_T_TUDIEN_CHUCVU_LayDS_KoTruongPhong", arrPara).Tables[0];
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
            return SqlHelper.ExecuteDataset(connString, "sp_T_TUDIEN_CHUCVU_LayDsNguoiKy").Tables[0];
        }
    }
}
