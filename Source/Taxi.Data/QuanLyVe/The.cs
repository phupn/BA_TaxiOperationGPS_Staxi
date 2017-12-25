using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;
namespace Taxi.Data.QuanLyVe
{
    /// <summary>
    /// Quan ly the
    /// </summary>
    public class The: DBObject
    {

        /// <summary>
        /// lấy ds thẻ hủy
        /// </summary>
        /// <returns></returns>
        public DataTable GetDSThe()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {   
                };
              


                return this.RunProcedure("[VE.sp_T_THE_SelectAll]", parameters, "tblTheHuy").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }
        /// <summary>
        /// hamf tra ve ds ve cua mot don vi
        /// </summary>
        /// <param name="MaDonViVe"></param>
        /// <returns></returns>
        public DataTable GetDSThe(int MaDonViVe)
        {   // @MaSoThe varchar(10),@MaDonViVe varchar(2)	 
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@MaSoThe",SqlDbType.VarChar,10) , 
                     new SqlParameter("@MaDonViVe",SqlDbType.Int)  
                };
                parameters[0].Value = "";
                parameters[1].Value = MaDonViVe;


                return this.RunProcedure("[VE.sp_T_THE_Select]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        } 
        /// <summary>
        /// ham tra ve chi tiet thong tin cua ve
        /// </summary>
        /// <param name="MaThe"></param>
        /// <param name="MaDonViVe"></param>
        /// <returns></returns>
        public DataTable GetChiTietThe(string MaThe, int MaDonViVe,int Nam)
        {
            // @MaSoThe varchar(10),@MaDonViVe varchar(2)	 
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@MaSoThe",SqlDbType.VarChar,10) , 
                     new SqlParameter("@MaDonViVe",SqlDbType.Int) ,
                     new SqlParameter("@Nam",SqlDbType.Int)  
                };
                parameters[0].Value = MaThe;
                parameters[1].Value = MaDonViVe;
                parameters[2].Value = Nam ;


                return this.RunProcedure("[VE.sp_T_THE_Select]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        /// <summary>
        /// [VE.sp_T_THE_Insert]	
        //@MaSoThe varchar(10),
        //@NgayHuy datetime, 
        //@TenCongTy nvarchar(50),
        //@GhiChu nvarchar(50),@MaDonViVe varchar(2)
        /// </summary>
        public bool Insert(string MaThe, DateTime NgayHuy, string TenCongTyHopDong, string GhiChu, int MaDonViVe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@MaSoThe",SqlDbType.VarChar,12) ,
                    new SqlParameter("@NgayHuy",SqlDbType.DateTime),                  
                    new SqlParameter("@TenCongTy",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50),
                    new SqlParameter("@MaDonViVe",SqlDbType.Int) 
                };
                parameters[0].Value = MaThe;
                parameters[1].Value = NgayHuy;
                parameters[2].Value = TenCongTyHopDong;
                parameters[3].Value = GhiChu;
                parameters[4].Value = MaDonViVe;



                rowAffected = this.RunProcedure("[VE.sp_T_THE_Insert]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }

        }
      public bool Update(string MaThe, DateTime NgayHuy,string TenCongTyHopDong,string GhiChu, int MaDonViVe)
    {
        try
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@MaSoThe",SqlDbType.VarChar,12) ,
                    new SqlParameter("@NgayHuy",SqlDbType.DateTime),                  
                    new SqlParameter("@TenCongTy",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50),
                    new SqlParameter("@MaDonViVe",SqlDbType.Int) 
                };
            parameters[0].Value = MaThe;
            parameters[1].Value = NgayHuy;
            parameters[2].Value = TenCongTyHopDong;
            parameters[3].Value = GhiChu;
            parameters[4].Value = MaDonViVe;



            rowAffected = this.RunProcedure("[VE.sp_T_THE_Update]", parameters, rowAffected);
            return (rowAffected > 0);
        }
        catch (Exception e)
        {
            return false; // loi
        }
      
    }

        public bool Delete(string MaThe ,int MaDonViVe)
        {//[VE.sp_T_THE_Delete]	
	     // @MaSoThe varchar(10), @MaDonViVe varchar(2)	
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@MaSoThe",SqlDbType.VarChar,12)  ,
                 new SqlParameter("@MaDonViVe",SqlDbType.Int) 
                };
                parameters[0].Value = MaThe;
                parameters[1].Value = MaDonViVe;
                rowAffected = this.RunProcedure("[VE.sp_T_THE_Delete]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }

        }


        
    }
}
