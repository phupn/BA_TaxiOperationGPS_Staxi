using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
   public class CuocGoiDoiTac : DBObject
    {
 
         //   @MaDoiTac char(6),
         //   @ThoiDiemGoi datetime,
         //   @SoDienThoaiGoi varchar(15),
         //   @SoXe4Cho int,
         //   @SoXe7Cho int,
         //   @SanBay_DuongDai char(1),
         //   @IsSuccess char(1)	

       /// <summary>
       /// Insert thông tin cuộc gọi của một đối tác
       /// </summary>
       /// <param name="MaDoiTac"></param>
       /// <param name="ThoiDiemGoi">ngaythangnam;gio-phut-giay</param>
       /// <param name="SoDienThoaiGoi"></param>
       /// <param name="SoXe4Cho"></param>
       /// <param name="SoXe7Cho"></param>
       /// <param name="SanBay_DuongDai"></param>
       /// <param name="IsSuccess"></param>
       /// <returns></returns>
       public bool Insert(string MaDoiTac, DateTime ThoiDiemGoi, string SoDienThoaiGoi, int SoXe4Cho, int SoXe7Cho, bool  SanBay_DuongDai, bool  IsSuccess)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@SoDienThoaiGoi",SqlDbType.VarChar ,15) ,
                    new SqlParameter("@SoXe4Cho",SqlDbType.Int) ,
                    new SqlParameter("@SoXe7Cho",SqlDbType.Int) ,
                    new SqlParameter("@SanBay_DuongDai",SqlDbType.Char,1) ,
                    new SqlParameter("@IsSuccess",SqlDbType.Char ,1) 
                };
               parameters[0].Value = MaDoiTac;
               parameters[1].Value = ThoiDiemGoi;
               parameters[2].Value = SoDienThoaiGoi;
               parameters[3].Value = SoXe4Cho;
               parameters[4].Value = SoXe7Cho;
               parameters[5].Value = SanBay_DuongDai == true ? "1" : "0"; ;
               parameters[6].Value = IsSuccess == true ? "1" : "0"; ;
               
               rowAffected = this.RunProcedure("spInsert_T_CUOCGOIDOITAC", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }
       public bool Update(string MaDoiTac, DateTime ThoiDiemGoi, string SoDienThoaiGoi, int SoXe4Cho, int SoXe7Cho, bool SanBay_DuongDai, bool IsSuccess)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@SoDienThoaiGoi",SqlDbType.VarChar ,15) ,
                    new SqlParameter("@SoXe4Cho",SqlDbType.Int) ,
                    new SqlParameter("@SoXe7Cho",SqlDbType.Int) ,
                    new SqlParameter("@SanBay_DuongDai",SqlDbType.Char,1) ,
                    new SqlParameter("@IsSuccess",SqlDbType.Char ,1) 
                };
               parameters[0].Value = MaDoiTac;
               parameters[1].Value = ThoiDiemGoi;
               parameters[2].Value = SoDienThoaiGoi;
               parameters[3].Value = SoXe4Cho;
               parameters[4].Value = SoXe7Cho;
               parameters[5].Value = SanBay_DuongDai == true ? "1" : "0"; ;
               parameters[6].Value = IsSuccess == true ? "1" : "0"; ;

               rowAffected = this.RunProcedure("spUpdate_T_CUOCGOIDOITAC", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }
       
    //   ALTER PROCEDURE [dbo].[spSelect_T_CUOCGOIDOITAC]
    //@MaDoiTac char(6),
    //@ThangNam char(7)
       public DataTable GetDanhSachCuocGoiDoiTac(string MaDoiTac, string FromDate,string ToDate)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar ,10),
                    new SqlParameter("@FromDate",SqlDbType.DateTime),
                    new SqlParameter("@ToDate",SqlDbType.DateTime)
                };
           parameters[0].Value = MaDoiTac;
           parameters[1].Value = FromDate;
           parameters[2].Value = ToDate;

           return this.RunProcedure("spSelect_T_CUOCGOIDOITAC", parameters, "tblUser").Tables[0];
       }
    }
}
