using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data.SqlClient;
using System.Data;

namespace Taxi.Data.QuanLyVe
{
    public class Ve : DBObject
    {

        #region #Ve Phat hanh
        //dbo].[VE.sp_T_VEPHATHANH_Insert]
        //    @NgayPhatHanh datetime,
        //    @SoHopDong int,
        //    @SeriDau int,
        //    @SeriCuoi int, 	 
        //    @FK_IDKhachHang int,
        //    @GhiChu nvarchar(50)
        public bool InsertVePhatHanh(DateTime _NgayPhatHanh, int _SoHopDong, int _SeriDau, int _SeriCuoi, int _FK_IDKhachHang, string _GhiChu)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayPhatHanh",SqlDbType.DateTime),
                    new SqlParameter("@SoHopDong",SqlDbType.Int ),
                    new SqlParameter("@SeriDau",SqlDbType.Int) ,    
                    new SqlParameter("@SeriCuoi",SqlDbType.Int) , 
                    new SqlParameter("@FK_IDKhachHang",SqlDbType.Int) ,    
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50)   
                };
                parameters[0].Value = _NgayPhatHanh;
                parameters[1].Value = _SoHopDong;
                parameters[2].Value = _SeriDau;
                parameters[3].Value = _SeriCuoi;
                parameters[4].Value = _FK_IDKhachHang;
                parameters[5].Value = _GhiChu;


                rowAffected = this.RunProcedure("[VE.sp_T_VEPHATHANH_Insert]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }

        public bool UpdateVePhatHanh(DateTime _NgayPhatHanh, int _SoHopDong, int _SeriDau, int _SeriCuoi, int _FK_IDKhachHang, string _GhiChu)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayPhatHanh",SqlDbType.DateTime),
                    new SqlParameter("@SoHopDong",SqlDbType.Int ),
                    new SqlParameter("@SeriDau",SqlDbType.Int) ,    
                    new SqlParameter("@SeriCuoi",SqlDbType.Int) , 
                    new SqlParameter("@FK_IDKhachHang",SqlDbType.Int) ,    
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50)   
                };
                parameters[0].Value = _NgayPhatHanh;
                parameters[1].Value = _SoHopDong;
                parameters[2].Value = _SeriDau;
                parameters[3].Value = _SeriCuoi;
                parameters[4].Value = _FK_IDKhachHang;
                parameters[5].Value = _GhiChu;


                rowAffected = this.RunProcedure("[VE.sp_T_VEPHATHANH_Update]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }
        //[dbo].[VE.sp_T_VEPHATHANH_Delete]
        //    @NgayPhatHanh datetime,
        //    @SoHopDong int,	 
        //    @FK_IDKhachHang int 
        public bool DeleteVePhatHanh(DateTime _NgayPhatHanh, int _SoHopDong,  int _FK_IDKhachHang )
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayPhatHanh",SqlDbType.DateTime),
                    new SqlParameter("@SoHopDong",SqlDbType.Int ),                 
                    new SqlParameter("@FK_IDKhachHang",SqlDbType.Int)     
                    
                };
                parameters[0].Value = _NgayPhatHanh;
                parameters[1].Value = _SoHopDong;    
                parameters[2].Value = _FK_IDKhachHang;
                 
                rowAffected = this.RunProcedure("[VE.sp_T_VEPHATHANH_Delete]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }

        //[dbo].[VE.sp_T_VEPHATHANH_SelectByID]
        //    @NgayPhatHanh datetime,
        //    @SoHopDong int,	 
        //    @FK_IDKhachHang int 	 
                 
         //NgayPhatHanh] [SoHopDong] [SeriDau] [SeriCuoi],   SoLuong [FK_IDKhachHang], TenKhachHang,   LienHe ,[GhiChu] 
        public DataTable GetVePhatHanh( DateTime _NgayPhatHanh, int _SoHopDong,  int _FK_IDKhachHang )
        {
          

            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayPhatHanh",SqlDbType.DateTime),
                    new SqlParameter("@SoHopDong",SqlDbType.Int ),                 
                    new SqlParameter("@FK_IDKhachHang",SqlDbType.Int)     
                    
                };
                parameters[0].Value = _NgayPhatHanh;
                parameters[1].Value = _SoHopDong;
                parameters[2].Value = _FK_IDKhachHang;


                return this.RunProcedure("[VE.sp_T_VEPHATHANH_SelectByID]", parameters, "tblVePhatHanh").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_NgayPhatHanh"></param>
        /// <param name="_SoHopDong"></param>
        /// <param name="_FK_IDKhachHang"></param>
        /// <returns></returns>
        public DataTable GetDSVePhatHanh( )
        { 
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {    };
                return this.RunProcedure("[VE.sp_T_VEPHATHANH_SelectAll]", parameters, "tblDSVePhatHanh").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetVePhatHanhBySeri(int Seri)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@Seri",SqlDbType.Int)  
                      
                };
                parameters[0].Value = Seri;

                return this.RunProcedure("[VE.sp_T_VEPHATHANH_SelectBySeri]", parameters, "tblVePhatHanh").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        #endregion #Ve Phat hanh

        #region Ve Huy
        //[VE.sp_T_VEHUY_Insert]
        //    @NgayHuy datetime,
        //    @SoHopDong int,
        //    @SeriDau int,
        //    @SeriCuoi int,
        //    @TenKhachHang  nvarchar(50),
        //    @MaDonViVe varchar(2), -- ma don vị quản l
        //    @LyDoHuy nvarchar(50),
        //    @GhiChu nvarchar(50)
        public bool InsertVeHuy(DateTime _NgayHuy, int _SoHopDong, int _SeriDau, int _SeriCuoi, string _TenKhachHang, int _MaDonViVe, string _LyDoHuy, string _GhiChu,bool _TamNhap,string _NguoiNhap)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayHuy",SqlDbType.DateTime),
                    new SqlParameter("@SoHopDong",SqlDbType.Int ),
                    new SqlParameter("@SeriDau",SqlDbType.Int) ,    
                    new SqlParameter("@SeriCuoi",SqlDbType.Int) , 
                    new SqlParameter("@TenKhachHang",SqlDbType.NVarChar,50) ,
                     new SqlParameter("@MaDonViVe",SqlDbType.Int) ,
                    new SqlParameter("@LyDoHuy",SqlDbType.NVarChar,50),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@TamNhap",SqlDbType.Bit),
                    new SqlParameter("@NguoiNhap",SqlDbType.NVarChar,50) ,
                };
                parameters[0].Value = _NgayHuy;
                parameters[1].Value = _SoHopDong;
                parameters[2].Value = _SeriDau;
                parameters[3].Value = _SeriCuoi;
                parameters[4].Value = _TenKhachHang;
                parameters[5].Value = _MaDonViVe;
                parameters[6].Value = _LyDoHuy;
                parameters[7].Value = _GhiChu;
                parameters[8].Value = _TamNhap==true ? 1 : 0;
                parameters[9].Value = _NguoiNhap;

                rowAffected = this.RunProcedure("[VE.sp_T_VEHUY_Insert]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }

        public bool UpdateVeHuy(DateTime _NgayHuy, int _SoHopDong, int _SeriDau, int _SeriCuoi, int _FK_IDKhachHang, string _LyDoHuy, string _GhiChu)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayHuy",SqlDbType.DateTime),
                    new SqlParameter("@SoHopDong",SqlDbType.Int ),
                    new SqlParameter("@SeriDau",SqlDbType.Int) ,    
                    new SqlParameter("@SeriCuoi",SqlDbType.Int) , 
                    new SqlParameter("@FK_IDKhachHang",SqlDbType.Int) ,
                    new SqlParameter("@LyDoHuy",SqlDbType.NVarChar,50),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50)   
                };
                parameters[0].Value = _NgayHuy;
                parameters[1].Value = _SoHopDong;
                parameters[2].Value = _SeriDau;
                parameters[3].Value = _SeriCuoi;
                parameters[4].Value = _FK_IDKhachHang;
                parameters[5].Value = _LyDoHuy;
                parameters[6].Value = _GhiChu;


                rowAffected = this.RunProcedure("[VE.sp_T_VEHUY_Update]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }

        
        //[VE.sp_T_VEHUY_Delete]
        //    @NgayHuy datetime,	 
        //    @SoHopDong int,
        //    @SeriDau int,	 
        //    @SeriCuoi int,
        //    @MaDonViVe varchar(2)
        public bool DeleteVeHuy(DateTime _NgayHuy,int _SoHopDong,int _SeriDau, int _SeriCuoi, int _MaDonViVe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayHuy",SqlDbType.DateTime),
                     new SqlParameter("@SoHopDong",SqlDbType.Int ),
                    new SqlParameter("@SeriDau",SqlDbType.Int ),
                    new SqlParameter("@SeriCuoi",SqlDbType.Int) ,                     
                    new SqlParameter("@MaDonViVe",SqlDbType.Int) 
                      
                };
                parameters[0].Value = _NgayHuy;
                parameters[1].Value = _SoHopDong;
                parameters[2].Value = _SeriDau;
                parameters[3].Value = _SeriCuoi;
                parameters[4].Value = _MaDonViVe;



                rowAffected = this.RunProcedure("[VE.sp_T_VEHUY_Delete]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }

        //[VE.sp_T_VEHUY_SelectByID] 
        //    @NgayHuy datetime,
        //    @SoHopDong int,
        //    @SeriDau int,	 
        //    @FK_IDKhachHang int
	 
        public DataTable  SelectVeHuyByID(DateTime _NgayHuy, int _SoHopDong, int _SeriDau, int _FK_IDKhachHang)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayHuy",SqlDbType.DateTime),
                    new SqlParameter("@SoHopDong",SqlDbType.Int ),
                    new SqlParameter("@SeriDau",SqlDbType.Int) ,                     
                    new SqlParameter("@FK_IDKhachHang",SqlDbType.Int) 
                      
                };
                parameters[0].Value = _NgayHuy;
                parameters[1].Value = _SoHopDong;
                parameters[2].Value = _SeriDau;
                parameters[3].Value = _FK_IDKhachHang;



                return this.RunProcedure("[VE.sp_T_VEPHATHANH_SelectByID]", parameters, "tblVePhatHanh").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        public DataTable SelectVeHuyAll()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { };



                return this.RunProcedure("[VE.sp_T_VEHUY_SelectAll]", parameters, "tblVePhatHanh").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }
        //[dbo].[VE.sp_T_VEHUY_SelectBySeri]	
        public DataTable GetVeHuyBySeri(int Seri)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@Seri",SqlDbType.Int)  
                      
                };
                parameters[0].Value = Seri;

                return this.RunProcedure("[VE.sp_T_VEHUY_SelectBySeri]", parameters, "tblHuy").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }
        #endregion Ve Huy



        #region VE DA SU DUNG

        public DataTable GetDSVeSuDung()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { };



                return this.RunProcedure("[VE.sp_T_VESUDUNG_SelectAll]", parameters, "tblVeSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }


        public   DataTable GetDaSuDungBySeri(int Seri)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@Seri",SqlDbType.Int)  
                      
                };
                parameters[0].Value = Seri;

                return this.RunProcedure("[VE.sp_T_VESUDUNG_SelectBySeri]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

           //[VE.sp_T_VESUDUNG_Insert]
           // @NgaySuDung datetime,
           // @SeriDau int,
           // @SoHieuXe varchar(5) ,	 
           // @GhiChu nvarchar(50)
        public bool InsertVeSuDung(DateTime _NgaySuDung, int _SeriDau, string _SoHieuXe,int _SoTien, string _GhiChu)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgaySuDung",SqlDbType.DateTime), 
                    new SqlParameter("@SeriDau",SqlDbType.Int),  
                    new SqlParameter("@SoTien",SqlDbType.Int), 
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,5),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50)   
                };
                parameters[0].Value = _NgaySuDung;
                parameters[1].Value = _SeriDau;
                parameters[2].Value = _SoTien;
                parameters[3].Value = _SoHieuXe;
                parameters[4].Value = _GhiChu; 
                rowAffected = this.RunProcedure("[VE.sp_T_VESUDUNG_Insert]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }
        public bool UpdateVeSuDung(DateTime _NgaySuDung, int _SeriDau, string _SoHieuXe, int _SoTien,string _GhiChu)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgaySuDung",SqlDbType.DateTime), 
                    new SqlParameter("@SeriDau",SqlDbType.Int),  
                    new SqlParameter("@SoTien",SqlDbType.Int), 
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,5),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,50)   
                };
                parameters[0].Value = _NgaySuDung;
                parameters[1].Value = _SeriDau;
                parameters[2].Value = _SoTien;
                parameters[3].Value = _SoHieuXe;
                parameters[4].Value = _GhiChu; 
                rowAffected = this.RunProcedure("[VE.sp_T_VESUDUNG_Update]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }

        //[dbo].[VE.sp_T_VESUDUNG_Delete]
        //@NgaySuDung datetime,
        //@SeriDau int 
    	 
        public bool DeleteVeSuDung(DateTime _NgaySuDung, int _SeriDau )
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgaySuDung",SqlDbType.DateTime), 
                    new SqlParameter("@SeriDau",SqlDbType.Int)   
                };
                parameters[0].Value = _NgaySuDung;
                parameters[1].Value = _SeriDau;

                rowAffected = this.RunProcedure("[VE.sp_T_VESUDUNG_Delete]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false; // loi
            }
        }
        #endregion VE DA SU DUNG


            #region VE CUA CONG TY KHAC

            #endregion VE CUA CONG TY KHAC

        /// <summary>
        ///  [dbo].[VE.sp_T_VEPHATHANH_SelectBySoHopDong]	 
        /// @SoHopDong int ,
        /// @TuNgay Datetime,
        /// @DenNgay Datetime
        /// </summary>
        /// <param name="SoHopDong"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetDSVeTheoHopDong(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@SoHopDong",SqlDbType.Int) , 
                     new SqlParameter("@TuNgay",SqlDbType.DateTime) ,  
                     new SqlParameter("@DenNgay",SqlDbType.DateTime) 
                };
                parameters[0].Value = SoHopDong;
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;

                return this.RunProcedure("[VE.sp_T_VEPHATHANH_SelectBySoHopDong]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        //[VE.sp_T_VESUDUNG_SelectBySoHopDong]	 
        //    @SoHopDong int ,
        //    @TuNgay Datetime,
        //    @DenNgay Datetime 
        public DataTable GetDSVeTheoHopDongDaSuDung(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@SoHopDong",SqlDbType.Int) , 
                     new SqlParameter("@TuNgay",SqlDbType.DateTime) ,  
                     new SqlParameter("@DenNgay",SqlDbType.DateTime) 
                };
                parameters[0].Value = SoHopDong;
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;

                return this.RunProcedure("[VE.sp_T_VESUDUNG_SelectBySoHopDong]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        //[dbo].[VE.sp_T_VESUDUNG_SelectByNgay]	 
	 
        //    @TuNgay Datetime,
        //    @DenNgay Datetime 
        public DataTable GetDSVeDaSuDungTheoNgay( DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                     
                     new SqlParameter("@TuNgay",SqlDbType.DateTime)  , 
                     new SqlParameter("@DenNgay",SqlDbType.DateTime) 
                };
                
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;

                return this.RunProcedure("[VE.sp_T_VESUDUNG_SelectByNgay]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        public DataTable TimKiemThongTinVe(int MaDonViVe, int Seri,int Nam)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                     
                     new SqlParameter("@MaDonViVe",SqlDbType.Int)  , 
                     new SqlParameter("@Seri",SqlDbType.Int),
                     new SqlParameter("@Nam",SqlDbType.Int) 
                };

                parameters[0].Value = MaDonViVe;
                parameters[1].Value = Seri;
                parameters[2].Value = Nam;

                return this.RunProcedure("[VE.sp_T_VESUDUNG_SelectByMaDonViSeri]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        public DataTable TimKiemThongTinSoHopDong(int MaDonViVe, int SoHopDong,int Nam)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                     
                     new SqlParameter("@MaDonViVe",SqlDbType.Int)  , 
                     new SqlParameter("@SoHopDong",SqlDbType.Int),
                    new SqlParameter("@Nam",SqlDbType.Int) 
                };

                parameters[0].Value = MaDonViVe;
                parameters[1].Value = SoHopDong;
                parameters[2].Value = Nam;

                return this.RunProcedure("[VE.sp_T_VESUDUNG_SelectByMaDonViSoHopDong]", parameters, "tblSuDung").Tables[0];
            }
            catch (Exception e)
            {
                return null; // loi
            }
        }

        public DataTable GetBCVe(DateTime NgayHuyTuNgay, DateTime NgayHuyDenNgay, int HopDong, int CongTyID, int SeriVe, string tenKhachHang,bool quyDinhHanMuc, bool isHopDongHuy)
        {
            string sql = "";
            sql += "  SELECT  [NgayHuy] ,[SoHopDong] ,[SeriDau] ,[SeriCuoi],(SeriCuoi-SeriDau) SoLuong,[LyDoHuy] ,[GhiChu] ,[TenKhachHang] ";
            sql += "        ,[MaDonViVe] ,[Nam] ,[IsTamNhap]  ,[NguoiNhap] ,[NgayNhap] ,[NguoiSua] ,[NgaySua] ,CT.TenCongTy ";
            sql+= "  FROM  [VE.T_VEHUY] VE ";
            sql += " INNER JOIN T_DMCongTy CT ON VE.MaDonViVe = CT.PK_CongtyID ";
            sql += " WHERE VE.NgayHuy >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", NgayHuyTuNgay) + "' AND VE.NgayHuy  <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", NgayHuyDenNgay) + "'   ";
            if (HopDong  > 0)
                sql += " AND (SoHopDong = " + HopDong.ToString ()  + ") ";
            if (CongTyID > 0)
                sql += " AND (MaDonViVe =" + CongTyID.ToString() + ")";
            if (SeriVe > 0)
                sql += " AND (SeriDau <= " + SeriVe.ToString() + " AND SeriCuoi <= " + SeriVe.ToString() + ")";
            if (tenKhachHang.Length > 0)
                sql += " AND (TenKhachHang LIKE '%" + tenKhachHang + "%')";
            if (quyDinhHanMuc)
                sql += " AND ( CHARINDEX('[GIOI HAN]',GhiChu)>0)";
            if (isHopDongHuy)
                sql += " AND (SeriDau=0 AND SeriCuoi=0)";
            sql += " ORDER BY NgayHuy ASC ";
            return RunSQL(sql, "tbl");

        }
    }
}
