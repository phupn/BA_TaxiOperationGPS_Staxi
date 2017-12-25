using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using System.Data.SqlClient;

namespace Taxi.Data
{
   public  class TinhTienTheoKm: DBObject 
    {
       // TINH TIEN THEO DIA DANG

       public DataTable GetAllDiaDanh( )
       {
           SqlParameter[] parameters = new SqlParameter[] { };

           return this.RunProcedure("sp_T_TINHTIEN_GIATIEN_DIADANH_Select", parameters, "tblUser").Tables[0];
       }

       
       public DataTable GetThongSoTinhTien(bool LoaiCuoc,int LoaiXe)
       {       
               SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@LoaiXe",SqlDbType.Int),
                new SqlParameter("@LoaiCuoc",SqlDbType.Bit)
            };
               parameters[0].Value = LoaiXe;
               parameters[1].Value = LoaiCuoc;
            return this.RunProcedure("V3_sp_T_TINHTOAN_GIATIEN_SelectByLoaiXe", parameters, "tblUser").Tables[0];
       }

       public DataTable GetThongSoTinhTien(int LoaiXe)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@LoaiXe",SqlDbType.Int)                    
            };
           parameters[0].Value = LoaiXe;

           return RunProcedure("sp_T_TINHTOAN_GIATIEN_NEW_SelectByLoaiXe", parameters, "tblUser").Tables[0];
       }

       public bool Update(float KmMoCua, float GiaMoCua, float KmNguong1, float GiaNguong1, float GiaNguong2, float KmNguong2Chieu, float TiLeGiamGiaHaiChieu, int LoaiXe,string ThongTinThueBao, bool LoaiCuoc)
       {
          
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@KmMoCua",SqlDbType.Float ),
                    new SqlParameter("@GiaMoCua",SqlDbType.Float),
                    new SqlParameter("@KmNguong1",SqlDbType.Float),
                    new SqlParameter("@GiaNguong1",SqlDbType.Float),
                    new SqlParameter("@GiaNguong2",SqlDbType.Float),
                    new SqlParameter("@KmNguong2Chieu",SqlDbType.Float),
                    new SqlParameter("@TiLeGiamGiaHaiChieu",SqlDbType.Float),
                    new SqlParameter("@LoaiXe",SqlDbType.Int),  
                   new SqlParameter("@ThongTinThueBao",SqlDbType.NVarChar,2000),
                   new SqlParameter("@LoaiCuoc",SqlDbType.Bit)

                };
               parameters[0].Value = (float)KmMoCua;
               parameters[1].Value = (float)GiaMoCua;
               parameters[2].Value = (float)KmNguong1;
               parameters[3].Value = (float)GiaNguong1;
               parameters[4].Value = (float)GiaNguong2;
               parameters[5].Value = (float)KmNguong2Chieu;
               parameters[6].Value = (float)TiLeGiamGiaHaiChieu;
               parameters[7].Value = (int)LoaiXe;
               parameters[8].Value = ThongTinThueBao;
               parameters[9].Value = LoaiCuoc;

               rowAffected = this.RunProcedure("V3_sp_T_TINHTOAN_GIATIEN_Update", parameters, rowAffected);
               return (rowAffected > 0);
          
       }

       public bool Update_New(float KmMoCua, float GiaMoCua,
                           float KmNguong1, float GiaNguong1,
                           float KmNguong2, float GiaNguong2,
                           float KmNguong3, float GiaNguong3,
                           float N1_ChieuDiTu, float N1_ChieuDiDen, float N1_Giam,
                           float N2_ChieuDiTu, float N2_Giam, bool IsAll,
                           float KmNguong2Chieu,
                           float TiLeGiamGiaHaiChieu,
                           int LoaiXe,
                           string ThongTinThueBao)
       {
          
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@KmMoCua",SqlDbType.Float ),
                    new SqlParameter("@GiaMoCua",SqlDbType.Float),
                    new SqlParameter("@KmNguong1",SqlDbType.Float),
                    new SqlParameter("@GiaNguong1",SqlDbType.Float),
                   new SqlParameter("@KmNguong2",SqlDbType.Float),
                    new SqlParameter("@GiaNguong2",SqlDbType.Float),
                   new SqlParameter("@KmNguong3",SqlDbType.Float),
                    new SqlParameter("@GiaNguong3",SqlDbType.Float),
                   new SqlParameter("@N1_ChieuDiTu",SqlDbType.Float),
                    new SqlParameter("@N1_ChieuDiDen",SqlDbType.Float),
                    new SqlParameter("@N1_Giam",SqlDbType.Float),
                   new SqlParameter("@N2_ChieuDiTu",SqlDbType.Float),
                    new SqlParameter("@N2_Giam",SqlDbType.Float),
                   new SqlParameter("@IsAll",SqlDbType.Float),
                    new SqlParameter("@KmNguong2Chieu",SqlDbType.Float),
                    new SqlParameter("@TiLeGiamGiaHaiChieu",SqlDbType.Float),
                    new SqlParameter("@LoaiXe",SqlDbType.Int),  
                   new SqlParameter("@ThongTinThueBao",SqlDbType.NVarChar,2000)                

                };
               parameters[0].Value = (float)KmMoCua;
               parameters[1].Value = (float)GiaMoCua;
               parameters[2].Value = (float)KmNguong1;
               parameters[3].Value = (float)GiaNguong1;
               parameters[4].Value = (float)KmNguong2;
               parameters[5].Value = (float)GiaNguong2;
               parameters[6].Value = (float)KmNguong3;
               parameters[7].Value = (float)GiaNguong3;
               parameters[8].Value = (float)N1_ChieuDiTu;
               parameters[9].Value = (float)N1_ChieuDiDen;
               parameters[10].Value = (float)N1_Giam;
               parameters[11].Value = (float)N2_ChieuDiTu;
               parameters[12].Value = (float)N2_Giam;
               parameters[13].Value = IsAll;
               parameters[14].Value = (float)KmNguong2Chieu;
               parameters[15].Value = (float)TiLeGiamGiaHaiChieu;
               parameters[16].Value = (int)LoaiXe;
               parameters[17].Value = ThongTinThueBao;

               rowAffected = RunProcedure("sp_T_TINHTOAN_GIATIEN_NEW_Update", parameters, rowAffected);
               return (rowAffected > 0);
          
       }

       public bool Insert(float KmMoCua, float GiaMoCua,
                           float KmNguong1, float GiaNguong1,
                           float KmNguong2, float GiaNguong2,
                           float KmNguong3, float GiaNguong3,
                           float N1_ChieuDiTu, float N1_ChieuDiDen, float N1_Giam,
                           float N2_ChieuDiTu, float N2_Giam, bool IsAll,
                           float KmNguong2Chieu,
                           float TiLeGiamGiaHaiChieu,
                           int LoaiXe,
                           string ThongTinThueBao)
       {
           
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@KmMoCua",SqlDbType.Float ),
                    new SqlParameter("@GiaMoCua",SqlDbType.Float),
                    new SqlParameter("@KmNguong1",SqlDbType.Float),
                    new SqlParameter("@GiaNguong1",SqlDbType.Float),
                    new SqlParameter("@KmNguong2",SqlDbType.Float),
                    new SqlParameter("@GiaNguong2",SqlDbType.Float),
                    new SqlParameter("@KmNguong3",SqlDbType.Float),
                    new SqlParameter("@GiaNguong3",SqlDbType.Float),
                    new SqlParameter("@N1_ChieuDiTu",SqlDbType.Float),
                    new SqlParameter("@N1_ChieuDiDen",SqlDbType.Float),
                    new SqlParameter("@N1_Giam",SqlDbType.Float),
                    new SqlParameter("@N2_ChieuDiTu",SqlDbType.Float),
                    new SqlParameter("@N2_Giam",SqlDbType.Float),
                    new SqlParameter("@IsAll",SqlDbType.Float),
                    new SqlParameter("@KmNguong2Chieu",SqlDbType.Float),
                    new SqlParameter("@TiLeGiamGiaHaiChieu",SqlDbType.Float),
                    new SqlParameter("@LoaiXe",SqlDbType.Int),  
                    new SqlParameter("@ThongTinThueBao",SqlDbType.NVarChar,2000)                

                };
               parameters[0].Value = (float)KmMoCua;
               parameters[1].Value = (float)GiaMoCua;
               parameters[2].Value = (float)KmNguong1;
               parameters[3].Value = (float)GiaNguong1;
               parameters[4].Value = (float)KmNguong2;
               parameters[5].Value = (float)GiaNguong2;
               parameters[6].Value = (float)KmNguong3;
               parameters[7].Value = (float)GiaNguong3;
               parameters[8].Value = (float)N1_ChieuDiTu;
               parameters[9].Value = (float)N1_ChieuDiDen;
               parameters[10].Value = (float)N1_Giam;
               parameters[11].Value = (float)N2_ChieuDiTu;
               parameters[12].Value = (float)N2_Giam;
               parameters[13].Value = IsAll;
               parameters[14].Value = (float)KmNguong2Chieu;
               parameters[15].Value = (float)TiLeGiamGiaHaiChieu;
               parameters[16].Value = (int)LoaiXe;
               parameters[17].Value = ThongTinThueBao;

               rowAffected = RunProcedure("sp_T_TINHTOAN_GIATIEN_INSERT", parameters, rowAffected);
               return (rowAffected > 0);
          
       }
       public DataTable GetAllLoaiXe()
       {
           SqlParameter[] parameters = new SqlParameter[] { };

           return this.RunProcedure("SP_T_TUDIEN_LOAIXE_SELECT", parameters, "tblLoaiXe").Tables[0];
       }
       public DataTable GetAllLoaiXe_Truck()
       {
           SqlParameter[] parameters = new SqlParameter[] { };

           return this.RunProcedure("SP_T_TUDIEN_LOAIXE_SELECTALL", parameters, "tblLoaiXe").Tables[0];
       }

       #region DIADANH_KM

       /// <summary>
       /// hàm check trùng tên cảu một đia danh trong ds đã nhập
       /// nếu ID > 0thì loại bỏ ID
       /// </summary>
       /// <param name="TenDiaDanh"></param>
       /// <returns></returns>
       public bool CheckTrungTen(int ID, string TenDiaDanh)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ID",SqlDbType.Int),      
               new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar,50)
            };
           parameters[0].Value = ID;
           parameters[1].Value = TenDiaDanh;
           DataTable dt = new DataTable();
           dt =  this.RunProcedure("[sp_T_TINHTIEN_GIATIEN_DIADANH_CheckTrungTen]", parameters, "tblDiaDanh").Tables[0];
           if (dt != null && dt.Rows.Count > 0)
           {
               return true;
           }
           return false;
       }

       /// <summary>
       /// tim kiếm thông tinđạ danh
       /// </summary>
       /// <param name="TenDiaDanh"></param>
       /// <returns></returns>
       public DataTable SearchDiaDanhByTen(string TenDiaDanh)
       {
           SqlParameter[] parameters = new SqlParameter[] {                
               new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar,50)
            };
           
           parameters[0].Value = TenDiaDanh;

           return this.RunProcedure("[sp_T_TINHTIEN_GIATIEN_DIADANH_SearchTen]", parameters, "tblDiaDanh").Tables[0];           
       }

       /// <summary>
       /// Insert địa danh Km
       /// </summary>
       /// <param name="TenDiaDanh"></param>
       /// <param name="Km"></param>
       /// <returns></returns>
       public bool InsertDiaDanhKm(string TenDiaDanh, int Km)
       {
           //[sp_T_TINHTIEN_GIATIEN_DIADANH_Insert] 
           //     @TenDiaDanh nvarchar(50),
           //     @Km int 	 
            try
           {             
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@Km",SqlDbType.Int ) 
                     
                };
               parameters[0].Value = TenDiaDanh;
               parameters[1].Value = Km;


               rowAffected = this.RunProcedure("sp_T_TINHTIEN_GIATIEN_DIADANH_Insert", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception ex)
           {
               return false;
           }        
       }

       public bool UpdateDiaDanhKm(int ID, string TenDiaDanh, int Km)
       {
            	 
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.Int ),
                     new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar,50 ),
                     new SqlParameter("@Km",SqlDbType.Int ) 
                     
                };
               parameters[0].Value = ID;
               parameters[1].Value = TenDiaDanh;
               parameters[2].Value = Km;


               rowAffected = this.RunProcedure("sp_T_TINHTIEN_GIATIEN_DIADANH_Update", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception ex)
           {
               return false;
           }
       }

       /// <summary>
       /// xoa địa danh-Km
       /// </summary>
       /// <param name="ID"></param>
       /// <returns></returns>
       public bool DeleteDiaDanhKm(int ID)
       {
           try
           {             
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int ),
                     
                };
               parameters[0].Value = ID;

               rowAffected = this.RunProcedure("sp_T_TINHTIEN_GIATIEN_DIADANH_Delete", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception ex)
           {
               return false;
           }
       }

       #endregion DIADANH_KM
   }
}
