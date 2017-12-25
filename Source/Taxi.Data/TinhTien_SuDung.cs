using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data.SqlClient;
using System.Data;

namespace Taxi.Data
{
    public class TinhTien_SuDung : DBObject
    {
        public bool Insert(int loaiXe,int Km_Tu,int Km_Den,int Vtb,float  TG)
        {
            
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LoaiXe",SqlDbType.Int ),
                    new SqlParameter("@Km_Tu",SqlDbType.Int),
                    new SqlParameter("@Km_Den",SqlDbType.Int),
                    new SqlParameter("@Vtb",SqlDbType.Int),
                    new SqlParameter("@TG",SqlDbType.Float)
                };
                parameters[0].Value = loaiXe;
                parameters[1].Value = Km_Tu;
                parameters[2].Value = Km_Den;
                parameters[3].Value = Vtb;
                parameters[4].Value = TG;

                rowAffected = RunProcedure("SP_T_TINHTOAN_GIATIEN_TG_INSERT", parameters, rowAffected);
                return (rowAffected > 0);
           
        }

        public bool Update(int ID, int loaiXe, int Km_Tu, int Km_Den, int Vtb, float TG)
        {
            
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LoaiXe",SqlDbType.Int ),
                    new SqlParameter("@Km_Tu",SqlDbType.Int),
                    new SqlParameter("@Km_Den",SqlDbType.Int),
                    new SqlParameter("@Vtb",SqlDbType.Int),
                    new SqlParameter("@TG",SqlDbType.Float),
                    new SqlParameter("@ID",SqlDbType.Int)
                };
                parameters[0].Value = loaiXe; 
                parameters[1].Value = Km_Tu;
                parameters[2].Value = Km_Den;
                parameters[3].Value = Vtb;
                parameters[4].Value = TG;
                parameters[5].Value = ID;

                rowAffected = RunProcedure("SP_T_TINHTOAN_GIATIEN_TG_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
          
        }

        public DataTable GetTinhTien_SuDung(int LoaiXe)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@LoaiXe",SqlDbType.Int)                    
            };
            parameters[0].Value = LoaiXe;

            return RunProcedure("SP_T_TINHTOAN_GIATIEN_TG_SelectByLoaiXe", parameters, "tblUser").Tables[0];
        }
    }
}
