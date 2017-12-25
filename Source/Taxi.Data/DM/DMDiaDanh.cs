using System;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class  DiaDanh : DBObject
    {

        /// <summary>
        /// lay ds dia danh
        /// if DiaDanhID =-1 AND TenDiaDanh = null AND DiaChi = null --> Get tat ca
        /// if DiaDanhID >0 lay theo ID
        /// if TenDiaDanh.len >0 theo Ten
        /// if DiaChi.Len >0 theo DiaChi
        /// </summary>
        public DataTable GetDSDiaDanh(int DiaDanhID, string TenDiaDanh, string DiaChi,int LoaiDiaDanhID)
        { 
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_DiaDanh",SqlDbType.Int )  ,
                    new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar,100 )  ,
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar ,100 ) ,
                   new SqlParameter("@FK_LoaiDiaDanh",SqlDbType.Int  ) 
                };
            parameters[0].Value = DiaDanhID;
            parameters[1].Value = TenDiaDanh;
            parameters[2].Value = DiaChi;
            parameters[3].Value = LoaiDiaDanhID;


            return this.RunProcedure("SP_T_DM_DIADANH_Select", parameters, "tblUser").Tables[0];

        }

        public bool Insert(string TenDiaDanh, string DiaChi, string DienThoai, string GhiChu,  int LoaiDiaDanhID)
        {
            try
            {
                 

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar , 100),
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,100),
                    new SqlParameter("@DienThoai",SqlDbType.VarChar,15) ,
                    new SqlParameter("@MoTa",SqlDbType.NVarChar,100) ,
                    new SqlParameter("@FK_LoaiDiaDanh",SqlDbType.Int) };
                
                parameters[0].Value = TenDiaDanh ;
                parameters[1].Value = DiaChi ;
                parameters[2].Value = DienThoai ;
                parameters[3].Value = GhiChu ;
                parameters[4].Value = LoaiDiaDanhID; 

                rowAffected = this.RunProcedure("SP_T_DM_DIADANH_Insert", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(int DiaDanhID, string TenDiaDanh, string DiaChi, string DienThoai, string GhiChu, int LoaiDiaDanhID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_DiaDanh",SqlDbType.Int),
                    new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar , 100),
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,100),
                    new SqlParameter("@DienThoai",SqlDbType.VarChar,15) ,
                    new SqlParameter("@MoTa",SqlDbType.NVarChar,100) ,
                    new SqlParameter("@FK_LoaiDiaDanh",SqlDbType.Int) };


                parameters[0].Value = DiaDanhID;
                parameters[1].Value = TenDiaDanh;
                parameters[2].Value = DiaChi;
                parameters[3].Value = DienThoai;
                parameters[4].Value = GhiChu;
                parameters[5].Value = LoaiDiaDanhID;

                rowAffected = this.RunProcedure("SP_T_DM_DIADANH_Update", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int DiaDanhID)
        {
            try
            { 
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_DiaDanh",SqlDbType.Int)
                }; 
                parameters[0].Value = DiaDanhID;  
                rowAffected = this.RunProcedure("SP_T_DM_DIADANH_Delete", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch
            {
                return false;
            }
        }

        #region -----New v3-----
        #region========================Autocomplete Address==========================
        public DataTable GetRoadData_Autocomplete()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("V3_SP_T_ROAD_SELECT_AUTOCOMPLETE", parameters, "tblRoadData").Tables[0];
        }

        public DataTable GetData_NoneAutocomplete()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("V3_SP_ONAC_SELECT_AUTOCOMPLETE", parameters, "tblONAC").Tables[0];
        }
        #endregion===================================================================
        #endregion
    }
}
