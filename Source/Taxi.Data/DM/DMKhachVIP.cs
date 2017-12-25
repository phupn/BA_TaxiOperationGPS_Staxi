using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
    /// <summary>
    ///  Cac ham thao cac voi bang T_KHACHVIP
    /// </summary>
    public class KhachVIP : DBObject
    {
        //.[spInsert_T_DOITAC]
        //@Ma_DoiTac char(6),
        //@Name nvarchar(50),
        //@Address nvarchar(255),
        //@Phones varchar(255),
        //@Fax char(10),
        //@Email varchar(50),    
        //@Notes nvarchar(255),
        //@IsActive char(1)

        public bool Insert(string MaKhachVIP, string Name, string Address, string Phones, string Fax, string Email, string Notes, bool IsActive)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_KhachVIP",SqlDbType.Char,6),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@Phones",SqlDbType.VarChar,255) ,
                    new SqlParameter("@Fax",SqlDbType.Char,20) ,
                    new SqlParameter("@Email",SqlDbType.VarChar ,50) ,            
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@IsActive",SqlDbType.Char ,1) ,
                };
                parameters[0].Value = MaKhachVIP;
                parameters[1].Value = Name;
                parameters[2].Value = Address;
                parameters[3].Value = Phones;
                parameters[4].Value = Fax;
                parameters[5].Value = Email;
                parameters[6].Value = Notes;
                parameters[7].Value = IsActive == true ? "1" : "0";


                rowAffected = this.RunProcedure("spInsert_T_DMKHACHVIP", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Update du lieu don, can thiet cho cac trung ho  
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        /// <param name="Phones"></param>
        /// <param name="Fax"></param>
        /// <param name="Email"></param>
        /// <param name="TiLeHoaHongNoiTinh"></param>
        /// <param name="TiLeHoaHongDuongDai"></param>
        /// <param name="Notes"></param>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public bool Update(string MaKhachVIP, string Name, string Address, string Phones, string Fax, string Email, string Notes, bool IsActive)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_KhachVIP",SqlDbType.Char,6),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@Phones",SqlDbType.VarChar,255) ,
                    new SqlParameter("@Fax",SqlDbType.Char,20) ,
                    new SqlParameter("@Email",SqlDbType.VarChar ,50) ,                
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@IsActive",SqlDbType.Char ,1) ,
                };
                parameters[0].Value = MaKhachVIP;
                parameters[1].Value = Name;
                parameters[2].Value = Address;
                parameters[3].Value = Phones;
                parameters[4].Value = Fax;
                parameters[5].Value = Email;
                parameters[6].Value = Notes;
                parameters[7].Value = IsActive == true ? "1" : "0";



                rowAffected = this.RunProcedure("spUpdate_T_DMKHACHVIP", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public DataTable GetDanhSachKhachVIPs(string MaKhachVIP)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_KhachVIP",SqlDbType.Char ,6)                    
                };
            parameters[0].Value = MaKhachVIP;

            return this.RunProcedure("spSelect_T_DMKHACHVIP", parameters, "tblUser").Tables[0];
        }
        /// <summary>
        /// Lay thong tin KhachVIP theo so dien thoai
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public DataTable GetKhachVIPByPhoneNumber(string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.NVarChar ,11)                    
                };
            parameters[0].Value = PhoneNumber;

            return this.RunProcedure("sp_T_DMKHACHVIP_SelectByPhoneNumber", parameters, "tblUser").Tables[0];
        }
        public bool Delete(string MaKhachVIP)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_KhachVIP",SqlDbType.Char ,6)                    
                };
                parameters[0].Value = MaKhachVIP;

                rowAffected = this.RunProcedure("spDelete_T_DMKHACHVIP", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetNextMaKhachVIP()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_KhachVIP",SqlDbType.Char ,6)                    
                };
                parameters[0].Value = string.Empty;
                parameters[0].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("spGetMaxKey_T_DMKHACHVIP", parameters, rowAffected);

                return parameters[0].Value.ToString();
            }
            catch (Exception e)
            {
                return string.Empty;// Loi chung tring phai a Phong
            }
        }


    }
}
