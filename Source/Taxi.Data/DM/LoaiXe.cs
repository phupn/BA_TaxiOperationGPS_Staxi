using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.DM
{
    public class LoaiXe : DBObject
    {
        public DataTable GetAllLoaiXe()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            return this.RunProcedure("SP_T_TUDIEN_LOAIXE_SELECT", parameters, "tblLoaiXe").Tables[0];
        }

        /// <summary>
        /// hàm check trùng tên của Loại xe - cùng số chỗ
        /// nếu ID > 0 thì loại bỏ ID
        /// </summary>
        /// <returns></returns>
        public bool CheckTrungTen_LoaiXe(int ID, string TenLoaiXe, int soCho)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@LoaiXeID",SqlDbType.Int), 
                new SqlParameter("@TenLoaiXe",SqlDbType.NVarChar,50),
                new SqlParameter("@SoCho",SqlDbType.Int)
            };
            parameters[0].Value = ID;
            parameters[1].Value = TenLoaiXe;
            parameters[2].Value = soCho;
            DataTable dt = new DataTable();
            dt = this.RunProcedure("SP_T_TUDIEN_LOAIXE_CHECK_EXIST", parameters, "tblLoaiXe").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool InsertLoaiXe(string TenLoaiXe, int SoCho)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@TenLoaiXe",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@SoCho",SqlDbType.Int ) 
                     
                };
                parameters[0].Value = TenLoaiXe;
                parameters[1].Value = SoCho;


                rowAffected = this.RunProcedure("SP_T_TUDIEN_LOAIXE_CHECK_INSERT", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateLoaiXe(int ID, string TenLoaiXe, int SoCho)
        {

            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@LoaiXeID",SqlDbType.Int ),
                     new SqlParameter("@TenLoaiXe",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@SoCho",SqlDbType.Int ) 
                     
                };
                parameters[0].Value = ID;
                parameters[1].Value = TenLoaiXe;
                parameters[2].Value = SoCho;


                rowAffected = this.RunProcedure("SP_T_TUDIEN_LOAIXE_CHECK_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteLoaiXe(int ID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LoaiXeID",SqlDbType.Int ),
                     
                };
                parameters[0].Value = ID;

                rowAffected = this.RunProcedure("SP_T_TUDIEN_LOAIXE_CHECK_DELETE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckTrungTen_LoaiXe_Truck(string TenLoaiXe)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TenLoaiXe",SqlDbType.NVarChar,50)
            };
            parameters[0].Value = TenLoaiXe;
            DataTable dt = new DataTable();
            dt = this.RunProcedure("sp_T_TUDIEN_LOAIXE_CheckTonTaiTen_Truck", parameters, "tblLoaiXe").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public DataTable GetAll()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                                  
                };

                return this.RunProcedure("sp_T_TUDIEN_LOAIXE_MauQuanCo_GetAll", parameters, "tbloaiXe").Tables[0];

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool DeleteLoaiXe_BC_Truck(int ID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LoaiXeID",SqlDbType.Int ),
                     
                };
                parameters[0].Value = ID;

                rowAffected = this.RunProcedure("SP_T_TUDIEN_LOAIXE_CHECK_DELETE_BC_Truck", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertLoaiXe_BC_Truck(string TenLoaiXe, string HangXe, string KichThuoc, string TaiTrongQuyDinh, string TaiTrongChoPhep, string PhimTat, string VietTat, string backColor, string foreColor)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@TenLoaiXe",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@HangXe",SqlDbType.NVarChar,20 ) ,
                     new SqlParameter("@KichThuoc",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@TaiTrongQuyDinh",SqlDbType.NVarChar,20 ),
                     new SqlParameter("@TaiTrongChoPhep",SqlDbType.NVarChar,20 ),
                     new SqlParameter("@PhimTat",SqlDbType.Char,1 ),
                     new SqlParameter("@VietTat",SqlDbType.VarChar,6 ),
                      new SqlParameter("@backColor",SqlDbType.VarChar,50 ),
                     new SqlParameter("@foreColor",SqlDbType.VarChar,50 )
                     
                };
                parameters[0].Value = TenLoaiXe;
                parameters[1].Value = HangXe;
                parameters[2].Value = KichThuoc;
                parameters[3].Value = TaiTrongQuyDinh;
                parameters[4].Value = TaiTrongChoPhep;
                parameters[5].Value = PhimTat;
                parameters[6].Value = VietTat;
                parameters[7].Value = backColor;
                parameters[8].Value = foreColor;
                rowAffected = this.RunProcedure("SP_T_TUDIEN_LOAIXE_CHECK_INSERT_BC_Truck", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLoaiXe_BC_Truck(int ID, string TenLoaiXe, string HangXe, string KichThuoc, string TaiTrongQuyDinh, string TaiTrongChoPhep, string PhimTat, string font, string VietTat, string backColor, string foreColor)
        {

            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@LoaiXeID",SqlDbType.Int ),
                     new SqlParameter("@TenLoaiXe",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@HangXe",SqlDbType.NVarChar,20 ) ,
                     new SqlParameter("@KichThuoc",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@TaiTrongQuyDinh",SqlDbType.NVarChar,20 ),
                     new SqlParameter("@TaiTrongChoPhep",SqlDbType.NVarChar,20 ),
                     new SqlParameter("@PhimTat",SqlDbType.Char,1 ),
                     new SqlParameter("@Font", SqlDbType.NVarChar, 50),
                     new SqlParameter("@VietTat",SqlDbType.VarChar,6 ),
                     new SqlParameter("@backColor",SqlDbType.VarChar,50 ),
                     new SqlParameter("@foreColor",SqlDbType.VarChar,50)

                };
                parameters[0].Value = ID;
                parameters[1].Value = TenLoaiXe;
                parameters[2].Value = HangXe;
                parameters[3].Value = KichThuoc;
                parameters[4].Value = TaiTrongQuyDinh;
                parameters[5].Value = TaiTrongChoPhep;
                parameters[6].Value = PhimTat;
                parameters[7].Value = font;
                parameters[8].Value = VietTat;
                parameters[9].Value = backColor;
                parameters[10].Value = foreColor;


                rowAffected = this.RunProcedure("SP_T_TUDIEN_LOAIXE_CHECK_UPDATE_BC_Truck", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}