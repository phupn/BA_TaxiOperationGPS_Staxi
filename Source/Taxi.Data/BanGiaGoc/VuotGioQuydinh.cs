using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.BanGiaGoc
{
    public class VuotGioQuydinhDA : DBObject

    {
      public DataTable selectone(int LoaiXeID)
     {
         int rowAffected = 0;
         try
         {
             SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LoaiXeID",SqlDbType.Int) 

                };
             parameters[0].Value = LoaiXeID;

             return this.RunProcedure("SP_T_VUOTGIOQUYDINH_SELECTONE", parameters, "tblVuot").Tables[0];
           // return this.RunProcedure("sp_T_TUDIEN_LOAIXE_MauQuanCo_GetAll", parameters, "tbloaiXe").Tables[0];                

         }
         catch (Exception e)
         {
             return null;
         }
     }
    }
}
