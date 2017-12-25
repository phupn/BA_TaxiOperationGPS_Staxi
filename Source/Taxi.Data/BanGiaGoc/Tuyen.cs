using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data.SqlClient;
using System.Data;

namespace Taxi.Data.BanGiaGoc
{
    public class Tuyen : DBObject
    {
        /// <summary>
        /// Get data Tuyen Duong
        /// </summary>
        /// <returns></returns>
        public DataTable GetKieuTuyenDuong()
        {
            SqlParameter[] parameters = new SqlParameter[] {
                };

            return this.RunProcedure("SP_T_ThueBaoTuyen_KieuTuyen_GetAll", parameters, "tblKieuTuyenduong").Tables[0];
        }
        public DataTable TableTuyenDuong(int KieuTuyenDuong)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@KieuTuyenDuong",SqlDbType.Int) 

                };
            parameters[0].Value = KieuTuyenDuong;

            return this.RunProcedure("SP_T_TUYENDUONG_SELECT", parameters, "tblTuyenduong").Tables[0];
            // return this.RunProcedure("sp_T_TUDIEN_LOAIXE_MauQuanCo_GetAll", parameters, "tbloaiXe").Tables[0];                
        }
        public DataTable TableTuyenDuongbyTen(String TenTuyenDuong)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenTuyenDuong",SqlDbType.NVarChar,50) 

                };
            parameters[0].Value = TenTuyenDuong;
            return this.RunProcedure("T_TUYENDUONG_SELECTBYTEN", parameters, "tblTuyenduong").Tables[0];
            // return this.RunProcedure("sp_T_TUDIEN_LOAIXE_MauQuanCo_GetAll", parameters, "tbloaiXe").Tables[0];                

        }

        /// <summary>
        /// chèn tuyến đường
        /// Mã tuyến dường sẽ tự sinh
        /// </summary>
        /// <param name="TenTuyenDuong"></param>
        /// <param name="KieuTuyenTuong"></param>
        /// <returns></returns>
        public bool Insert(string TenTuyenDuong, int KieuTuyenTuong)
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenTuyenDuong",SqlDbType.NVarChar,50),
                     new SqlParameter("@KieuTuyenTuong",SqlDbType.Int)
                };
            parameters[0].Value = TenTuyenDuong;
            parameters[1].Value = KieuTuyenTuong;
            rowAffected = this.RunProcedure("sp_T_TUYENDUONG_Insert", parameters, rowAffected);
            return (rowAffected > 0);


        }
        public bool Update(string MaTuyenDuong, string TenTuyenDuong, int KieuTuyenTuong)
        {
            int rowAffected = 0;

            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@TuyenDuongID",SqlDbType.VarChar,5 ),
                    new SqlParameter("@TenTuyenDuong",SqlDbType.NVarChar,50),
                     new SqlParameter("@KieuTuyenTuong",SqlDbType.Int)
                };
            parameters[0].Value = MaTuyenDuong;
            parameters[1].Value = TenTuyenDuong;
            parameters[2].Value = KieuTuyenTuong;
            rowAffected = this.RunProcedure("sp_T_TUYENDUONG_Update", parameters, rowAffected);
            return (rowAffected > 0);
        }

        public bool Delete(string MaTuyenDuong)
        {
            int rowAffected = 0;

            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@TuyenDuongID",SqlDbType.VarChar,5 )               
                };
            parameters[0].Value = MaTuyenDuong;

            rowAffected = this.RunProcedure("sp_T_TUYENDUONG_Delete", parameters, rowAffected);
            return (rowAffected > 0);
        }
    }
}
