using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
 public class DanhBa : DBObject
    {

     public DanhBa()
         :base()
     {

     }
     /// <summary>
     /// Insert mot doi tuong vao database
     /// </summary>
     /// <param name="PhoneNumber">so dien thoai</param>
     /// <param name="Name">ten nguoi</param>
     /// <param name="Address">dia chi</param>
     /// <returns></returns>
     public bool Insert(string PhoneNumber, string Name, string Address)
     {
         try
         {
             int rowAffected = 0;
             SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,8),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255)                    
                };
             parameters[0].Value = PhoneNumber;
             parameters[1].Value = Name;
             parameters[2].Value = Address;


             rowAffected = this.RunProcedure("sp_Insert_T_DANHBA", parameters, rowAffected);
             return (rowAffected > 0);
         }
         catch (Exception e)
         {
             return false;
         }
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// </summary>
     /// <param name="PhoneNumber"></param>
     /// <returns></returns>
     public DataTable GetDanhBa(string PhoneNumber)
     {
         SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,8)                    
                };
         parameters[0].Value = PhoneNumber;

         return this.RunProcedure("sp_T_DANHBA_BUUDIEN_GetBy_PhoneNumber", parameters, "tblUser").Tables[0];
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// </summary>
     public DataTable GetDanhBa_BuuDien()
     {
         SqlParameter[] parameters = new SqlParameter[] {};

         return this.RunProcedure("SP_T_DANHBA_BUUDIEN_GETALL", parameters, "tblUser").Tables[0];
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// </summary>
     public DataTable GetDanhBa_BuuDien_1()
     {
         SqlParameter[] parameters = new SqlParameter[] { };

         return this.RunProcedure("SP_T_DANHBA_BUUDIEN_GETALL_1", parameters, "tblUser").Tables[0];
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// </summary>
     public DataTable GetDanhBa_BuuDien_2()
     {
         SqlParameter[] parameters = new SqlParameter[] { };

         return this.RunProcedure("SP_T_DANHBA_BUUDIEN_GETALL_2", parameters, "tblUser").Tables[0];
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// </summary>
     public DataTable GetDanhBa_BuuDien_3()
     {
         SqlParameter[] parameters = new SqlParameter[] { };

         return this.RunProcedure("SP_T_DANHBA_BUUDIEN_GETALL_3", parameters, "tblUser").Tables[0];
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// </summary>
     /// <param name="PhoneNumber"></param>
     /// <returns></returns>
     public DataTable GetDanhBa_BuuDien_4()
     {
         SqlParameter[] parameters = new SqlParameter[] { };

         return this.RunProcedure("SP_T_DANHBA_BUUDIEN_GETALL_4", parameters, "tblUser").Tables[0];
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// </summary>
     /// <param name="PhoneNumber"></param>
     /// <returns></returns>
     public DataTable GetDanhBa_BuuDien_5()
     {
         SqlParameter[] parameters = new SqlParameter[] { };

         return this.RunProcedure("SP_T_DANHBA_BUUDIEN_GETALL_5", parameters, "tblUser").Tables[0];
     }

    // @PhoneNumber varchar(11),	 
    //@DiaChiKhach nvarchar(255) output,
    //@KieuKhachHangGoiDen char(1)output ,
    //@GiaiMa char(1) Output

     /// <summary>
     /// hamf lay ra dia chi tu mot so dien thoai theo thu tu
     /// -- khach ao
     /// -- khach vip
     /// -- khach moi gioi
     /// -- khach dang hoat dong
     /// -- danh ba riwng cua cong ty
     /// -- danh ba buu dien
     /// neu GiaiMa= true --> giai ma du lieu dia chi
     /// </summary>
     /// <param name="PhoneNumber"></param>
     /// <param name="KieuKhachHangGoi"></param>
     /// <param name="GiaiMa"></param>
     /// <returns></returns>
     public string GetAddressFromPhoneNumber(string PhoneNumber, out Taxi.Utils.KieuKhachHangGoiDen KieuKhachHangGoi, out bool GiaiMa, out string MaDoiTac,out int Vung)
     {
         try
         {
             GiaiMa = false;
             SqlParameter[] parameters = new SqlParameter[] {
                  new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11) ,    
                  new SqlParameter("@DiaChiKhach",SqlDbType.NVarChar ,255) ,
                  new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.VarChar , 1) ,
                  new SqlParameter("@GiaiMa",SqlDbType.VarChar , 1) ,
                   new SqlParameter("@MaDoiTac",SqlDbType.VarChar , 10) ,
                  new SqlParameter("@Vung",SqlDbType.Int)
                };
             parameters[0].Value = PhoneNumber;
             parameters[1].Direction = ParameterDirection.Output;
             parameters[2].Direction = ParameterDirection.Output;
             parameters[3].Direction = ParameterDirection.Output;
             parameters[4].Direction = ParameterDirection.Output;
             parameters[5].Direction = ParameterDirection.Output;




             this.RunProcedure("[DANHBA.sp_GetAddressFromPhoneNumber]", parameters);

             if (parameters[3].Value.ToString() == "1") GiaiMa = true;
             KieuKhachHangGoi = ((Taxi.Utils.KieuKhachHangGoiDen) int.Parse(parameters[2].Value.ToString()));
             MaDoiTac = parameters[4].Value.ToString();
             try{
                 Vung = Convert.ToInt32(parameters[5].Value.ToString());
             }
             catch(Exception ex)
             {
                 Vung = 0;
             }
             
             return parameters[1].Value.ToString();
         }
         catch (Exception ex)
         {
             KieuKhachHangGoi = Taxi.Utils.KieuKhachHangGoiDen.KhachHangBinhThuong;
             GiaiMa = false;
             MaDoiTac = "";
             Vung = 0;
             return null;
         }
     }
 }
}
