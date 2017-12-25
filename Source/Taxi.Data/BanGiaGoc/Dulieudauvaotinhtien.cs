using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.BanGiaGoc 
{
    public class Dulieudauvaotinhtien : DBObject
    {

        /// <summary>
        /// chèn dữ liệu cho vị trí Hải Phòng or Quán Toan
        /// </summary>
        /// <param name="IsQuanToan"></param>
        /// <param name="TuyenDuongID"></param>
        /// <param name="LoaiXeID"></param>
        /// <param name="KmQuyDinh1Chieu"></param>
        /// <param name="ThoiGianQuyDinh1Chieu"></param>
        /// <param name="GiaTien1Chieu"></param>
        /// <param name="KmQuyDinh2Chieu"></param>
        /// <param name="ThoiGianQuyDinh2Chieu"></param>
        /// <param name="GiaTien2Chieu"></param>
        /// <returns></returns>
        public int Insert(bool IsQuanToan, string TuyenDuongID, int LoaiXeID, double KmQuyDinh1Chieu, double ThoiGianQuyDinh1Chieu, double GiaTien1Chieu, double KmQuyDinh2Chieu, double ThoiGianQuyDinh2Chieu, double GiaTien2Chieu,string VeTram)
        {

//     

            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IsQuanToan",SqlDbType.Bit), 
                    new SqlParameter("@TuyenDuongID",SqlDbType.NChar,5) , 
                    new SqlParameter("@LoaiXeID",SqlDbType.Int)  ,
                     new SqlParameter("@KmQuyDinh1Chieu",SqlDbType.Float) , 
                    new SqlParameter("@ThoiGianQuyDinh1Chieu",SqlDbType.Float),
                   new SqlParameter("@GiaTien1Chieu",SqlDbType.Float) , 
                    new SqlParameter("@KmQuyDinh2Chieu",SqlDbType.Float),
                   new SqlParameter("@ThoiGianQuyDinh2Chieu",SqlDbType.Float) , 
                    new SqlParameter("@GiaTien2Chieu",SqlDbType.Float)
                    , new SqlParameter("@VeTram",SqlDbType.Char,50)
                };

                parameters[0].Value = IsQuanToan;
                parameters[1].Value = TuyenDuongID;
                parameters[2].Value = LoaiXeID;
                parameters[3].Value = KmQuyDinh1Chieu;
                parameters[4].Value = ThoiGianQuyDinh1Chieu;
                parameters[5].Value = GiaTien1Chieu;
                parameters[6].Value = KmQuyDinh2Chieu;
                parameters[7].Value = ThoiGianQuyDinh2Chieu;
                parameters[8].Value = GiaTien2Chieu;
                parameters[9].Value = VeTram;

                return  this.RunProcedure("SP_T_DULIEUDAUVAOTINHTIEN_INSERT", parameters, rowAffected);
               
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public int Update(bool IsQuanToan, string TuyenDuongID, int LoaiXeID, double KmQuyDinh1Chieu, double ThoiGianQuyDinh1Chieu, double GiaTien1Chieu, double KmQuyDinh2Chieu, double  ThoiGianQuyDinh2Chieu, double GiaTien2Chieu,string VeTram)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IsQuanToan",SqlDbType.Bit),
                    new SqlParameter("@TuyenDuongID",SqlDbType.NChar,5) , 
                    new SqlParameter("@LoaiXeID",SqlDbType.Int)  ,
                     new SqlParameter("@KmQuyDinh1Chieu",SqlDbType.Float) , 
                    new SqlParameter("@ThoiGianQuyDinh1Chieu",SqlDbType.Float),
                   new SqlParameter("@GiaTien1Chieu",SqlDbType.Float) , 
                    new SqlParameter("@KmQuyDinh2Chieu",SqlDbType.Float),
                   new SqlParameter("@ThoiGianQuyDinh2Chieu",SqlDbType.Float) , 
                    new SqlParameter("@GiaTien2Chieu",SqlDbType.Float),
                     new SqlParameter("@VeTram",SqlDbType.Char,50)
                };
                parameters[0].Value = IsQuanToan;
                parameters[1].Value = TuyenDuongID;
                parameters[2].Value = LoaiXeID;
                parameters[3].Value = KmQuyDinh1Chieu;
                parameters[4].Value = ThoiGianQuyDinh1Chieu;
                parameters[5].Value = GiaTien1Chieu;
                parameters[6].Value = KmQuyDinh2Chieu;
                parameters[7].Value = ThoiGianQuyDinh2Chieu;
                parameters[8].Value = GiaTien2Chieu;
                parameters[9].Value = VeTram;


                return this.RunProcedure("SP_T_DULIEUDAUVAOTINHTIEN_UPDATE", parameters, rowAffected);

            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public int Delete(bool IsQuanToan, string TuyenDuongID, int LoaiXeID)
        {
            //[sp_T_TUDIEN_LOAIXE_Xoa]                 
            //        @LoaiXeID int

           
             
             try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    
                    new SqlParameter("@IsQuanToan",SqlDbType.Bit),
                    new SqlParameter("@TuyenDuongID",SqlDbType.NChar,5) , 
                    new SqlParameter("@LoaiXeID",SqlDbType.Int)  
                    
                };
                parameters[0].Value = IsQuanToan;
                parameters[1].Value = TuyenDuongID;
                parameters[2].Value = LoaiXeID;
              


                return this.RunProcedure("SP_T_DULIEUDAUVAOTINHTIEN_DELETE", parameters, rowAffected);

            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public System.Data.DataTable GetByLoaixeID(bool IsQuanToan, int LoaiXeID)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IsQuanToan",SqlDbType.Bit),
                    new SqlParameter("@LoaiXeID",SqlDbType.Int  )                    
                };
           parameters[0].Value =  IsQuanToan;
           parameters[1].Value =  LoaiXeID;

           return this.RunProcedure("[SP_T_DULIEUDAUVAOTINHTIEN_SELECTBYLOAIXE]", parameters, "tblGara").Tables[0];
       }

        public System.Data.DataTable GetOne(bool IsQuanToan, string TuyenDuongID, int LoaiXeID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IsQuanToan",SqlDbType.Bit),
                  new SqlParameter("@TuyenDuongID",SqlDbType.NChar,5  ) ,
                    new SqlParameter("@LoaiXeID",SqlDbType.Int  )                    
                };
            parameters[0].Value = IsQuanToan;
            parameters[1].Value = TuyenDuongID;
            parameters[2].Value = LoaiXeID;
            return this.RunProcedure("SP_T_DULIEUDAUVAOTINHTIEN_SELECTONE", parameters, "tblGara").Tables[0];
        }
        
        /// <summary>
        /// lấy dữ liệu là của HP or Quán toan
        /// </summary>
        /// <param name="IsQuanToan"></param>
        /// <returns></returns>
       public System.Data.DataTable GetAll(bool IsQuanToan)
       {
           
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@IsQuanToan",SqlDbType.Bit)                    
                };

            parameters[0].Value = IsQuanToan;
            return this.RunProcedure("SP_T_DULIEUDAUVAOTINHTIEN_SELECT", parameters, "tblGara").Tables[0];
       }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsQuanToan"></param>
        /// <param name="MaTuyenDuong"></param>
        /// <returns></returns>
       public DataTable GetDulieuCuaMotTuyen(bool IsQuanToan, string MaTuyenDuong)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IsQuanToan",SqlDbType.Bit),
                    new SqlParameter("@MaTuyenDuong",SqlDbType.VarChar,5  )                    
                };
           parameters[0].Value = IsQuanToan;
           parameters[1].Value = MaTuyenDuong;

           return this.RunProcedure("[SP_T_DULIEUDAUVAOTINHTIEN_SELECTBYMaTuyenDuong]", parameters, "tblGara").Tables[0];
       }

        
   }
}
