using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
   public class KiemSoatXeLienLac : DBObject
    {
        /// <summary>
        /// Get ta ca nhung xe dang hoat dong
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllXeDangHoatDong()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_DSXEHOATDONG_SelectAllXeHoatDong", parameters, "tblTaxiDangHoatDong").Tables[0];
        }
   
   //@SoHieuXe char(3),
   //@ThoiDiemBao datetime,
   //@MaLaiXe char(6),
   //@ViTriDiemBao nvarchar(50),
   //@ViTriDiemDen nvarchar(50),
   //@LoaiChoKhach char(1),
   //@TrangThaiLaiXeBao char(1),
   //@IsHoatDong char(1)

       /// <summary>
       /// 
       /// </summary>
       /// <param name="SoHieuXe"></param>
       /// <param name="ThoiDiemBao"></param>
       /// <param name="MaLaiXe"></param>
       /// <param name="ViTriDiemBao"></param>
       /// <param name="ViTriDiemDen"></param>
       /// <param name="LoaiChoKhach"></param>
       /// <param name="TrangThaiLaiXeBao"></param>
       /// <param name="GhiChu"></param>
       /// <param name="IsHoatDong"></param>
       /// <param name="chieu"></param>
       /// <param name="checkedGPS"></param>
       /// <returns></returns>
       public bool Insert_Update(string SoHieuXe, DateTime ThoiDiemBao, string MaLaiXe, string ViTriDiemBao, string ViTriDiemDen, LoaiChoKhach LoaiChoKhach,
           KieuLaiXeBao TrangThaiLaiXeBao,string GhiChu, bool IsHoatDong, LoaiChieuChoKhach chieu, bool checkedGPS, long coDi, int SoPhutNghi)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@ThoiDiemBao",SqlDbType.DateTime ),
                   new SqlParameter("@MaLaiXe",SqlDbType.NVarChar,50),  
                   new SqlParameter("@ViTriDiemBao",SqlDbType.NVarChar,50),
                   new SqlParameter("@ViTriDiemDen",SqlDbType.NVarChar,50),
                   new SqlParameter("@LoaiChoKhach",SqlDbType.Char,1),
                   new SqlParameter("@TrangThaiLaiXeBao",SqlDbType.VarChar,2),
                   new SqlParameter("@GhiChu",SqlDbType.NVarChar,550),
                   new SqlParameter("@IsHoatDong",SqlDbType.Char,1),
                   new SqlParameter("@Chieu",SqlDbType.TinyInt),
                   new SqlParameter("@CheckedGPS",SqlDbType.Bit ),
                   new SqlParameter("@CoDi",SqlDbType.BigInt),
                   new SqlParameter("@SoPhutNghi",SqlDbType.Int)
                    };

               parameters[0].Value = SoHieuXe ;
               parameters[1].Value = ThoiDiemBao;
               parameters[2].Value = MaLaiXe ;
               parameters[3].Value =ViTriDiemBao  ;
               parameters[4].Value = ViTriDiemDen ;
               parameters[5].Value = ((int)(LoaiChoKhach)LoaiChoKhach).ToString();
               parameters[6].Value = ((int)(KieuLaiXeBao )TrangThaiLaiXeBao ).ToString();;
               parameters[7].Value = GhiChu ;
               parameters[8].Value = (IsHoatDong ==true ? "1" : "0") ;
               parameters[9].Value =  ((int) (LoaiChieuChoKhach) chieu);
               parameters[10].Value = checkedGPS;
               parameters[11].Value = coDi;
               parameters[12].Value = SoPhutNghi;

               rowAffected = this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_Insert_Update2", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }

       public bool Insert_Update_V3(string SoHieuXe, DateTime ThoiDiemBao, string ViTriDiemBao,
           KieuLaiXeBao TrangThaiLaiXeBao, string GhiChu, bool IsHoatDong, string noiDungSuCo, string ketQuaXuLy,string createdBy, string updatedBy)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.Char,4),
                   new SqlParameter("@ThoiDiemBao",SqlDbType.DateTime ), 
                   new SqlParameter("@ViTriDiemBao",SqlDbType.NVarChar,50),
                   new SqlParameter("@TrangThaiLaiXeBao",SqlDbType.VarChar,2),
                   new SqlParameter("@GhiChu",SqlDbType.NVarChar,500),
                   new SqlParameter("@IsHoatDong",SqlDbType.Char,1),
                   new SqlParameter("@NoiDungSuCo",SqlDbType.NVarChar, 500),
                   new SqlParameter("@KetQuaXuLy",SqlDbType.NVarChar, 500 ),
                   new SqlParameter("@CreatedBy",SqlDbType.NVarChar, 50 ),
                   new SqlParameter("@UpdatedBy",SqlDbType.NVarChar, 50 )
                    };

               parameters[0].Value = SoHieuXe;
               parameters[1].Value = ThoiDiemBao;
               parameters[2].Value = ViTriDiemBao;
               parameters[3].Value = ((int)(KieuLaiXeBao)TrangThaiLaiXeBao).ToString(); ;
               parameters[4].Value = GhiChu;
               parameters[5].Value = (IsHoatDong == true ? "1" : "0");
               parameters[6].Value = noiDungSuCo;
               parameters[7].Value = ketQuaXuLy;
               parameters[8].Value = createdBy;
               parameters[9].Value = updatedBy;

               rowAffected = this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_Insert_Update_V3", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }

       /// <summary>
       /// lay ta cac cac xe dang 
       /// </summary>
       /// <returns></returns>
       public DataTable GetAllCacXe()
       {
           SqlParameter[] parameters = new SqlParameter[] {};

           return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectAll", parameters, "tblCallsFinish").Tables[0];
       }

       /// <summary>
       /// Check mot xe co phai dang hoat dong khong
       /// </summary>
       /// <param name="SoHieuXe"></param>
       /// <returns></returns>
       public  bool CheckXeDangHoatDong(string SoHieuXe)
       {
          
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@IsExist",SqlDbType.Char,1 )                                
               };

               parameters[0].Value = SoHieuXe ;
               parameters[1].Direction = ParameterDirection.Output;
               rowAffected = this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_DSXEHOATDONG_CheckSoHieuXeDangHoatDong", parameters, rowAffected);

               string strReturn = parameters[1].Value.ToString();
               if (strReturn == "1") return true;
               else return false;
               
           }
           catch (Exception e)
           {
               return false;
           }
       }


       public  DataTable GetDanhSachXeHoatDongTrongNgay(DateTime Ngay)
       {
         //  sp_T_KIEMSOAT_LIENLAC_SelectAll_SoHieuXe_TrongNgay

           SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@Ngay",SqlDbType.DateTime )
                                                 
                    };

           parameters[0].Value = Ngay;
           return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectAll_SoHieuXe_TrongNgay", parameters, "tblDSSoHieuXe").Tables[0];
       }

       public DataTable GetDanhSachCacSuKienCuaXeTrongNgay(string SoHieuXe, DateTime Ngay)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@Ngay",SqlDbType.DateTime )                                                
            };

           parameters[0].Value = SoHieuXe;
           parameters[1].Value = Ngay;
           return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectAllEvents_SoHieuXe_TrongNgay", parameters, "tblDSEvents_BySoHieuXe").Tables[0];
       }
    /// <summary>
    /// lay thong tin cua mot xe dang hoat dong
    /// </summary>
    /// <param name="SoHieuXe"></param>
    /// <returns></returns>
       public DataTable GetKSXe_BySoHieuXe(string SoHieuXe)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4)                                                                 
            };

           parameters[0].Value = SoHieuXe;
           return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectBy_SoHieuXe", parameters, "tblKSXE").Tables[0];
       }
       /// <summary>
       /// laays ta ca cac trang thai cua xe dang hoat dong tai thoi diem hien tai
       /// KSLL
       /// </summary>
       /// <returns></returns>
       public DataTable GetTrangThaiAllXe_KSLL( )
       {
           SqlParameter[] parameters = new SqlParameter[] {                                                                                
            };
           return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectTrangThaiCuaCacXeGanDayNhat", parameters, "tblKSXE").Tables[0];
       }


       /// <summary>
       /// Cap nhat thong tin xe hoat dong vao bang danhsachxedanghoatdong
       /// if chua co so hieu xe thi se insert, neu co toi thi update
       /// </summary>
       /// <param name="SoHieuXe"></param>
       /// <param name="ThoiDiemBao"></param>
       /// <param name="IsHoatDong"></param>
       public  bool  InsertUpdateXeDangHoatDong(string SoHieuXe, DateTime  ThoiDiemBao, bool IsHoatDong)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@ThoiDiemBao",SqlDbType.DateTime ),                  
                   new SqlParameter("@IsHoatDong",SqlDbType.Char,1)                   
                    };

               parameters[0].Value = SoHieuXe;
               parameters[1].Value = ThoiDiemBao;        
               parameters[2].Value = (IsHoatDong == true ? "1" : "0");

               rowAffected = this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_DSXEHOATDONG_InsertUpdate", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }
            
   
   
       /// <summary>
       /// lay thong tin gan  nhat cua xe dang hoat dong ma mat lien lac tong dai da check
       /// </summary>
       /// <param name="SoHieuXe"></param>
       /// <returns></returns>
    public DataTable GetTrangThaiGanDayNhatCuaTongDaiGoiXe(string SoHieuXe,DateTime ThoiDiemBaoTruoc)
    {
        SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4)  ,
                   new SqlParameter("@ThoiDiemBaoTruoc",SqlDbType.DateTime  )                                                
            };

        parameters[0].Value = SoHieuXe;
        parameters[1].Value = ThoiDiemBaoTruoc;
        return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectBy_SoHieuXe_TongDaiMoiGoi", parameters, "tblKSXE").Tables[0];
    }

    public DataTable GetDanhSachCacSuKienCuaXeTrongKhoangThoiGian(string SoHieuXe, DateTime TuNgayGio, DateTime DenNgayGio)
    {
        SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@TuNgayGio",SqlDbType.DateTime ) ,
                   new SqlParameter("@DenNgayGio",SqlDbType.DateTime ) ,                            
            };
        parameters[0].Value = SoHieuXe;
        parameters[1].Value = TuNgayGio;
        parameters[2].Value = DenNgayGio;
        return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectAllEvents_SoHieuXe_TrongKhoangThoiGian", parameters, "tblDSEvents_BySoHieuXe").Tables[0];
    }
       /// <summary>
       /// cap nhat lai ten lai xe co thoi diem lon hon hoac = thoi diem bao
       /// </summary>
       /// <param name="SoHieuXe"></param>
       /// <param name="ThoiDiemBaoHoatDongGanNhat"></param>
       /// <param name="TenLaiXe"></param>
       /// <returns></returns>
    public bool UpdateTenLaiXe(string SoHieuXe, DateTime ThoiDiemBaoHoatDongGanNhat, string TenLaiXe)
    { 
        try
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@MaLaiXe",SqlDbType.NVarChar,50 ),                  
                   new SqlParameter("@ThoiDiemBao",SqlDbType.DateTime )                   
                    };

            parameters[0].Value = SoHieuXe;
            parameters[1].Value = TenLaiXe;
            parameters[2].Value =  ThoiDiemBaoHoatDongGanNhat;

            rowAffected = this.RunProcedure("spT_KIEMSOAT_LIENLAC_UpdateTenLaiXe", parameters, rowAffected);
            return (rowAffected > 0);
        }
        catch (Exception e)
        {
            return false;
        }
    }
        public bool UpdateTenLaiXe(string SoHieuXe, DateTime ThoiDiemBaoHoatDongGanNhat,DateTime ThoiDiemVe, string TenLaiXe)
    { 
        try
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@MaLaiXe",SqlDbType.NVarChar,50 ),                  
                   new SqlParameter("@ThoiDiemBao",SqlDbType.DateTime )  ,
                 new SqlParameter("@ThoiDiemVe",SqlDbType.DateTime )   
                    };

            parameters[0].Value = SoHieuXe;
            parameters[1].Value = TenLaiXe;
            parameters[2].Value =  ThoiDiemBaoHoatDongGanNhat;
            parameters[3].Value = ThoiDiemVe;

            rowAffected = this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_UpdateTenLaiXeTuBaoRa_BaoVe", parameters, rowAffected);
            return (rowAffected > 0);
        }
        catch (Exception e)
        {
            return false;
        }
    }
       
       /// <summary>
       /// ham tra ve ds cac trong thai cua xe trong thoi diem  tu thoi diem --> den thoi diem
       /// </summary>
       /// <param name="TuThoiDiem"></param>
       /// <param name="DenThoiDiem"></param>
       /// <returns></returns>
    public DataTable GetBaoCaoMatLienLac(DateTime TuThoiDiem, DateTime DenThoiDiem)
    {
        //sp_T_KIEMSOAT_LIENLAC_GetBaoCaoMatLienLac]
        //    @TuNgay  Datetime,
        //    @DenNgay Datetime 

        SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@TuNgay",SqlDbType.DateTime ) ,
                   new SqlParameter("@DenNgay",SqlDbType.DateTime )                             
            };
        parameters[0].Value = TuThoiDiem;
        parameters[1].Value = DenThoiDiem;

        return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_GetBaoCaoMatLienLac", parameters, "tblDSEvents").Tables[0];
    }

    public DataTable GetNhungTrangThaiXeNhoHon3ThangGanDay()
    {
        SqlParameter[] parameters = new SqlParameter[] { 
                                          
            }; 
        return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_GetNhungTrangThaiXeNhoHon3ThangGanDay", parameters, "tblDSEvents").Tables[0];
    }

    public bool DeleteNhungTrangThaiXeNhoHon3ThangGanDay()
    {
        try
        {
            int rowAffected = 0;
            SqlParameter[] parameters = new SqlParameter[] {
                                    
                };
            rowAffected = this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_DeleteNhungTrangThaiXeNhoHon3ThangGanDay", parameters, rowAffected);
            return (rowAffected > 0);
        }
        catch (Exception e)
        {
            return false;
        } 
    }

    public DataTable LayDSXeDangHoatDong()
    {
        try
        {
            SqlParameter[] parameters = new SqlParameter[] { 
                                          
            };
            return this.RunProcedure("[GIAMSATXE.GetDSXeDangHoatDong]", parameters, "tblDSXeHD").Tables[0];
        }
        catch (Exception ex)
        {
            return null;
        }

    }
    public DataTable LayDSXeDangVe()
    {
        try
        {
            SqlParameter[] parameters = new SqlParameter[] { 
                                          
            };
            return this.RunProcedure("[GIAMSATXE.GetDSXeDangVe]", parameters, "tblDSXeHD").Tables[0];
        }
        catch (Exception ex)
        {
            return null;
        }
    }
   public DataTable LayDSXeDangNghi()
   {
       try
       {
           SqlParameter[] parameters = new SqlParameter[] { 
                                      
        };
           return this.RunProcedure("[GIAMSATXE.GetDSXeDangNghi]", parameters, "tblDSXeHD").Tables[0];
       }
       catch (Exception ex)
       {
           return null;
       }
   }
   public DataTable LayDSXeDangHong()
   {
       try
       {
           SqlParameter[] parameters = new SqlParameter[] { 
                                      
        };
           return this.RunProcedure("[GIAMSATXE.GetDSXeDangHong]", parameters, "tblDSXeHD").Tables[0];
       }
       catch (Exception ex)
       {
           return null;
       }
   }

   public DataTable LayDSSuCoVeThe()
   {
       try
       {
           SqlParameter[] parameters = new SqlParameter[] { 
                                      
        };
           return this.RunProcedure("[GIAMSATXE.GetDSSuCoVeThe]", parameters, "tblDSXeHD").Tables[0];
       }
       catch (Exception ex)
       {
           return null;
       }
   }

   public DataTable LayDSXeDangVaCham()
   {
       try
       {
           SqlParameter[] parameters = new SqlParameter[] { 
                                      
        };
           return this.RunProcedure("[GIAMSATXE.GetDSXeVaCham]", parameters, "tblDSXeHD").Tables[0];
       }
       catch (Exception ex)
       {
           return null;
       }
   }

       public DataTable LayDSXeDangDiSBDD()
       {
           try
           {
               SqlParameter[] parameters = new SqlParameter[] { 
                                      
        };
               return this.RunProcedure("[GIAMSATXE.GetDSXeDangDiSBDD]", parameters, "tblDSXeHD").Tables[0];
           }
           catch (Exception ex)
           {
               return null;
           }
       }
       public DataTable LayDSXeDangMatLienLac(bool SapXepTheoThoiGian, bool AnMatLLSBDD)
       {
           try
           { 
               SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SapXepTheoThoiGian",SqlDbType.Bit ) ,
                new SqlParameter("@AnMatLLSBDD",SqlDbType.Bit )     
                                      
            };
               parameters[0].Value = SapXepTheoThoiGian;
               parameters[1].Value = AnMatLLSBDD;
               return this.RunProcedure("[GIAMSATXE.GetDSXeDangMatLienLac]", parameters, "tblDSXeHD").Tables[0];
           }
           catch (Exception ex)
           {
               return null;
           }
       }
       public DataTable LayThongTinChiTietCuaXe(string SoHieuXe)
       {
           try
           {
               SqlParameter[] parameters = new SqlParameter[] {new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4 ) 
                                      
        };
               parameters[0].Value = SoHieuXe;
               return this.RunProcedure("[GIAMSATXE.GetChiTietThongTinXe]", parameters, "tblDSXeHD").Tables[0];
           }
           catch (Exception ex)
           {
               return null;
           }
       }

       public DataTable LayThongTinChiTietCuaXeTheoDiaChi(string diaChi)
       {
           try
           {
               SqlParameter[] parameters = new SqlParameter[] 
                {
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50 ) 
                                      
                };
               parameters[0].Value = diaChi;
               return this.RunProcedure("[GIAMSATXE.GetChiTietThongTinXeByDiaChi]", parameters, "tblDSXeHD").Tables[0];
           }
           catch (Exception ex)
           {
               return null;
           }
       }

       public DataTable GetKSXeBySoHieuXeThoiDiemBao(string soHieuXe, DateTime thoiDiemBao)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4)   ,
                new SqlParameter("@ThoiDiemBao ",SqlDbType.DateTime)                                          
            };

           parameters[0].Value = soHieuXe;
           parameters[1].Value = thoiDiemBao;
           return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_SelectBy_SoHieuXeByThoiDiemBao", parameters, "tblKSXE").Tables[0];
       }

       public DataTable LayTatcaDSXe()
       {
           try
           {
               SqlParameter[] parameters = new SqlParameter[] { 
                                      
            };
               return this.RunProcedure("[GIAMSATXE.GetTatCaDSXe]", parameters, "tblDSXeHD").Tables[0];
           }
           catch (Exception ex)
           {
               return null;
           }
       }

       public bool DeleteXeBiNhapLoi(string SoHieuXe)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4 ) 
                                      
        };
               parameters[0].Value = SoHieuXe;
               rowAffected = this.RunProcedure("sp_T_T_KIEMSOAT_LIENLAC_DeleteXeNhapLoi", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception ex)
           {
               return false ;
           }
       }

      
       /// <summary>
       /// hàm trả về ds lái xe không tên trong ngày
       /// Không tên lái xe, hoặc tất cả
       /// </summary>
       /// <param name="bKhongTenLaiXe"></param>
       /// <returns></returns>
       public DataTable GetDSXeKhongTenLaiXe( DateTime Ngay,  bool bKhongTenLaiXe)
       {
           try
           {
               SqlParameter[] parameters = new SqlParameter[] { 
                   new SqlParameter("@Ngay",SqlDbType. DateTime ) ,
                   new SqlParameter("@KhongTenLaiXe",SqlDbType.Bit) 
                                      
            };
               parameters[0].Value = Ngay;
               parameters[1].Value = bKhongTenLaiXe == true ? 1 : 0;
               return this.RunProcedure("[GIAMSATXE.GetDSXeKhongTenLaiXe]", parameters, "tblDSXeHD").Tables[0];
           }
           catch (Exception ex)
           {
               return null;
           }
       }

       /// <summary>
       /// hàm trả về thời điểm về của xe.
       /// Nếu chưa có thời điểm về thì trả về DateTime.MinValue
       /// </summary>
       /// <param name="SoHieuXe"></param>
       /// <param name="ThoiDiemBatDau"></param>
       /// <returns></returns>
       public DateTime  GetThoiDiemVeCuaXe(string SoHieuXe, DateTime ThoiDiemBatDau)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4 ) ,
                   new SqlParameter("@ThoiDiemBaoRaHoatDong",SqlDbType.DateTime ) ,
                   new SqlParameter("@ThoiDiemBaoVe",SqlDbType.DateTime )
                                      
        };
               parameters[0].Value = SoHieuXe;
               parameters[1].Value = ThoiDiemBatDau;
               parameters[2].Direction = ParameterDirection.Output;

               this.RunProcedure("[GIAMSATXE.GetThoiDiemVeCuaXe]", parameters, rowAffected);

               DateTime retDate = DateTime.MinValue;
               retDate = Convert.ToDateTime(parameters[2].Value.ToString());
               return retDate;               
           }
           catch (Exception ex)
           {
               return DateTime .MinValue;
           }
       }

       public DataTable LayThongTinChiTietCuaXeDuongDai(string noiDung)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] 
                {
                    new SqlParameter("@NoiDung",SqlDbType.NVarChar,50 ) 
                                      
                };
               parameters[0].Value = noiDung;
               return this.RunProcedure("[GIAMSATXE.GetChiTietThongTinXeDuongDai]", parameters, "tblDSXeHD").Tables[0];
           }
           catch (Exception ex)
           {
               return null;
           }
       }

       public bool Insert_UpdateSanBayDuongDai(string soHieuXe, DateTime ThoiDiemDi, string maLaiXe, string ViTriDiemBao, string ViTriDiemDen, long CoDi, LoaiChoKhach loaiChoKhach, KieuLaiXeBao kieuLaiXeBao, string GhiChu, LoaiChieuChoKhach ChieuChoKhach, long CoVe)
       {
           try
           {

               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4),
                   new SqlParameter("@ThoiDiemBao",SqlDbType.DateTime ),
                   new SqlParameter("@MaLaiXe",SqlDbType.NVarChar,50),  
                   new SqlParameter("@ViTriDiemBao",SqlDbType.NVarChar,50),
                   new SqlParameter("@ViTriDiemDen",SqlDbType.NVarChar,50),
                   new SqlParameter("@LoaiChoKhach",SqlDbType.Char,1),
                   new SqlParameter("@TrangThaiLaiXeBao",SqlDbType.VarChar,2),
                   new SqlParameter("@GhiChu",SqlDbType.NVarChar,250), 
                   new SqlParameter("@Chieu",SqlDbType.TinyInt),
                   new SqlParameter("@CoDi",SqlDbType.BigInt),                  
                   new SqlParameter("@CoVe",SqlDbType.BigInt)
                 };

               parameters[0].Value = soHieuXe;
               parameters[1].Value = ThoiDiemDi;
               parameters[2].Value = maLaiXe;
               parameters[3].Value = ViTriDiemBao;
               parameters[4].Value = ViTriDiemDen;
               parameters[5].Value = ((int)(LoaiChoKhach)loaiChoKhach).ToString();
               parameters[6].Value = ((int)(KieuLaiXeBao)kieuLaiXeBao).ToString(); ;
               parameters[7].Value = GhiChu;
               parameters[8].Value = ((int)(LoaiChieuChoKhach)ChieuChoKhach);
               parameters[9].Value = CoDi;
               parameters[10].Value = CoVe;

               rowAffected = this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_Insert_UpdateSanBayDuongDai", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }
   }
}
