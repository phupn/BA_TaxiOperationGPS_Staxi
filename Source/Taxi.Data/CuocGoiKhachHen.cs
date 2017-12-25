using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class CuocGoiKhachHen: DBObject 
    {

        /// <summary>
        /// Get thong tin Cuocgoi khach hen
        /// if ID_DieuHanh <=0 then se lay tat câ
        /// else lay cuoc goi theo ID_DieuHanh
        /// </summary>
        /// <param name="ID_DieuHanh"></param>
        /// <returns></returns>
        public DataTable GetCuocGoiKhachHens(long ID_DieuHanh)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID_T_TaxiOperation",SqlDbType.BigInt )                    
                };
            parameters[0].Value = ID_DieuHanh;

            return this.RunProcedure("sp_T_TAXIOPERATION_KHACHHEN_Select", parameters, "tblCuocGoiKhachHen").Tables[0];
        
        }
        /// <summary>
        /// chen thong tin cuoc goi co khach hen
        ///  
        /// </summary>
        /// <param name="ID_DieuHanh"> danh sach cuoc goi </param>
        /// <param name="ThoiDiemBatDau">Thời điểm khách yêu cầu</param>
        /// <param name="BaoTruocSoPhut">Báo trước thời đỉem đó số phút</param>
        /// <param name="IsDaGiaiQuyet">đánh dẫu trạng thái đã xử lý</param>
        /// <param name="GhiChu">Ghi chú thông tin cuộc goi</param>
        /// <returns></returns>
        public bool Insert_Update(long ID_DieuHanh, DateTime ThoiDiemBatDau, int BaoTruocSoPhut, bool IsDaGiaiQuyet, string GhiChu)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@ID_T_TaxiOperation ",SqlDbType.BigInt ),
                   new SqlParameter("@ThoiDiemBatDau",SqlDbType.DateTime ),
                   new SqlParameter("@BaoTruocSoPhut",SqlDbType.Int ),  
                   new SqlParameter("@IsDaGiaiQuyet",SqlDbType.Char,1),
                   new SqlParameter("@GhiChu",SqlDbType.NVarChar,255)                               
                    };

                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = ThoiDiemBatDau;
                parameters[2].Value = BaoTruocSoPhut;
                parameters[3].Value = IsDaGiaiQuyet == true ? "1" : "0";
                parameters[4].Value = GhiChu;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_KHACHHEN_Insert_Update", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Xóa một cuộc hẹn của khách hàng
        /// </summary>
        /// <param name="ID_DieuHanh"></param>
        /// <returns></returns>
        public bool Delete(long ID_DieuHanh)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt  )                    
                };
                parameters[0].Value = ID_DieuHanh;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_KHACHHEN_Delete", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
