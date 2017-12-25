using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.QuanLyVe
{
    public class  KhachHang : DBObject
    { 

       //ALTER PROCEDURE [dbo].[VE.sp_T_DMKHACHHANG_Insert]	
           // @TenKhachHang nvarchar(150),
           // @DiaChi nvarchar(50),
           // @NguoiLienHe nvarchar(50),
           // @DienThoai varchar(50),
           // @MaNhanVienQuanLy nvarchar(50),
           // @NgayKyKet datetime,
           // @IDKhachHang int output
        public int  Insert(string _TenKhachHang, string _DiaChi, string _NguoiLienHe, string _DienThoai, string _MaNhanVienQuanLy, DateTime _NgayKyKet)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenKhachHang",SqlDbType.NVarChar ,150),
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50),
                    new SqlParameter("@NguoiLienHe",SqlDbType.NVarChar,50) ,    
                    new SqlParameter("@DienThoai",SqlDbType.VarChar,50) ,    
                    new SqlParameter("@MaNhanVienQuanLy",SqlDbType.NVarChar,50) ,    
                    new SqlParameter("@NgayKyKet",SqlDbType.DateTime) ,    
                    new SqlParameter("@IDKhachHang",SqlDbType.Int ) ,    
                };
                parameters[0].Value = _TenKhachHang;
                parameters[1].Value = _DiaChi;
                parameters[2].Value = _NguoiLienHe;
                parameters[3].Value = _DienThoai;
                parameters[4].Value = _MaNhanVienQuanLy;
                parameters[5].Value = _NgayKyKet;
                parameters[6].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("[VE.sp_T_DMKHACHHANG_Insert]", parameters, rowAffected);
                return int.Parse(parameters[6].Value.ToString());
            }
            catch (Exception e)
            {
                return -1; // loi
            }
        }

        //ALTER PROCEDURE [dbo].[VE.sp_T_DMKHACHHANG_Update]
        //    @IDKhachHang int,
        //    @TenKhachHang nvarchar(150),
        //    @DiaChi nvarchar(50),
        //    @NguoiLienHe nvarchar(50),
        //    @DienThoai varchar(50),
        //    @MaNhanVienQuanLy nvarchar(50),
        //    @NgayKyKet datetime
        public bool Update(int _IDKhachHang, string _TenKhachHang, string _DiaChi, string _NguoiLienHe, string _DienThoai, string _MaNhanVienQuanLy, DateTime _NgayKyKet)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDKhachHang",SqlDbType.Int ) ,
                    new SqlParameter("@TenKhachHang",SqlDbType.NVarChar ,150),
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50),
                    new SqlParameter("@NguoiLienHe",SqlDbType.NVarChar,50) ,    
                    new SqlParameter("@DienThoai",SqlDbType.VarChar,50) ,    
                    new SqlParameter("@MaNhanVienQuanLy",SqlDbType.NVarChar,50) ,    
                    new SqlParameter("@NgayKyKet",SqlDbType.DateTime)   
                };
                parameters[0].Value = _IDKhachHang;
                parameters[1].Value = _TenKhachHang;
                parameters[2].Value = _DiaChi;
                parameters[3].Value = _NguoiLienHe;
                parameters[4].Value = _DienThoai;
                parameters[5].Value = _MaNhanVienQuanLy;
                parameters[6].Value = _NgayKyKet;
               


                rowAffected = this.RunProcedure("[VE.sp_T_DMKHACHHANG_Update]", parameters, rowAffected);
                return (rowAffected >0);
            }
            catch (Exception e)
            {
                return false ; // loi
            }
        }

        //ALTER PROCEDURE [dbo].[VE.sp_T_DMKHACHHANG_Delete]
        //    @IDKhachHang int
        public bool Delete(int _IDKhachHang)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDKhachHang",SqlDbType.Int )  
                    
                };
                parameters[0].Value = _IDKhachHang;
                rowAffected = this.RunProcedure("[VE.sp_T_DMKHACHHANG_Delete]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false ; // loi
            }
        }

              //ALTER PROCEDURE [dbo].[VE.sp_T_DMKHACHHANG_SelectByID]
              //       @IDKhachHang int
        
	      
        public DataTable GetChiTietKhachHang(int IDKhachHang)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDKhachHang",SqlDbType.Int)                    
                };
                parameters[0].Value = IDKhachHang;

                return this.RunProcedure("[VE.sp_T_DMKHACHHANG_SelectByID]", parameters, "tblDMKhachHang").Tables[0];
            }
            catch (Exception ex)
            {
                return null ;
            }
        }

        //[dbo].[VE.sp_T_DMKHACHHANG_SelectByTenKhachHang]
        //    @TenKhachHang  nvarchar(150)
        public DataTable GetDSKhachHang(string TenKhachHang)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenKhachHang",SqlDbType.NVarChar,150)                    
                };
                parameters[0].Value = TenKhachHang;

                return this.RunProcedure("[VE.sp_T_DMKHACHHANG_SelectByTenKhachHang]", parameters, "tblDMKhachHang").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //[VE.sp_T_DMKHACHHANG_SelectAll]
        //  [IDKhachHang]
        //      ,[TenKhachHang]
        //      ,[DiaChi]
        //      ,[NguoiLienHe]
        //      ,[DienThoai]
        //      ,[MaNhanVienQuanLy]
        //      ,[NgayKyKet] 
        public DataTable GetDSKhachHang()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {                                      
                };          

                return this.RunProcedure("[VE.sp_T_DMKHACHHANG_SelectAll]", parameters, "tblDMKhachHang").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
