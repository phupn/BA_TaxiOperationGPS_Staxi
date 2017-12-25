using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using Taxi.Utils;
using System.Data.SqlClient;


namespace Taxi.Data
{
    /// <summary>
    /// Xu ly cac thong tin tim kiem va bao cao
    /// </summary>
    public class TimKiem_BaoCao : DBObject
    {
        
        /// <summary>
        /// Khai thac du  lieu tu bang TaxiKetThuc
        /// </summary>
        public DataTable GetBaoCao_TaxiKetThuc(string strSQLCondition)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@strSQLCondition",SqlDbType.NVarChar ,4000)                    
                };
            parameters[0].Value = strSQLCondition;

            return this.RunProcedure("sp_GetThongTinBaoCao_T_TAXIOPERATIONKETTHUC", parameters, "tblTaxiKetThuc").Tables[0];
        }
                
        /// <summary>
        /// Lay thong tin du lieu cua khach vang lai
        /// </summary>
        public DataTable GetBaoCao_KhachVangLai(string strSQLCondition)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@strSQLCondition",SqlDbType.NVarChar ,4000)                    
                };
            parameters[0].Value = strSQLCondition;

            return this.RunProcedure("sp_GetThongTinBaoCao_T_KHACHVANGLAI", parameters, "tblTaxiKetThuc").Tables[0];
        }


        /// <summary>
        /// Ham nhan ve mot bao du lieu theo ca
        /// --								CUOC GOI TAXI
        ////--							Tong	Moi gioi  Vang lai
        //--06: 00 18/9- 14:00 18/9			
        //--14: 00 18/9- 22:00 18/9			
        //--22: 00 18/9- 06:00 19/9	
        ///fn_BaoCao_Bieu1_CuocGoiTaxi
        /// </summary>
        /// <param name="strDate">2008-10-23 format</param>
        /// <returns></returns>
       
        public DataTable GetBaoCao_BieuMau1(string strDate)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Date",SqlDbType.VarChar ,10)                    
                };
            parameters[0].Value = strDate;

            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau1", parameters, "tblBaoCaoBieuMau1").Tables[0];
        }

        public DataTable GetBaoCao_BieuMau1_New(string strDate)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Date",SqlDbType.VarChar ,10)                    
                };
            parameters[0].Value = strDate;

            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau1_New", parameters, "tblBaoCaoBieuMau1_New").Tables[0];
        }
        /// <summary>
        /// get bao cao theo vung
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public DataTable GetBaoCao_BieuMau1_Vung(string strDate)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Date",SqlDbType.VarChar ,10)                    
                };
            parameters[0].Value = strDate;

            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau1_ByVung", parameters, "tblBaoCaoBieuMau1byVung").Tables[0];
        }
        /// <summary>
        /// ALTER PROCEDURE [dbo].[sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau2]
	    //  @TuNgay varchar(10),
	    //  @DenNgay varchar(10)
        /// </summary>
        /// <param name="strTuNgay"></param>
        /// <param name="strDenNgay"></param>
        /// <returns></returns>
        public DataTable  GetBaoCao_BieuMau2(string strTuNgay, string strDenNgay)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.VarChar ,10)  ,
                    new SqlParameter("@DenNgay",SqlDbType.VarChar ,10)  
                };
            parameters[0].Value = strTuNgay;
            parameters[1].Value = strDenNgay;
            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau2", parameters, "tblBaoCaoBieuMau2").Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTuNgay"></param>
        /// <param name="strDenNgay"></param>
        /// <returns></returns>
        public DataTable GetBaoCao_BieuMau9(string strTuNgay, string strDenNgay)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.VarChar ,10)  ,
                    new SqlParameter("@DenNgay",SqlDbType.VarChar ,10)  
                };
            parameters[0].Value = strTuNgay;
            parameters[1].Value = strDenNgay;
            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau9", parameters, "tblBaoCaoBieuMau9").Tables[0];
        }
        /// <summary>
        /// Lay so lieu cuoc goi cua moi gioi
        ///     - strTuNgayGio '2008-10-15 12:14:00'
        ///     - strDenNgayGio '2008-10-23 12:14:00'
        ///     - PhoneNumber (80) '37856099'
        /// @TuNgayGio varchar(19), @DenNgayGio varchar(19),@PhoneCall varchar(8)
        /// </summary>
        /// <param name="strTuNgayGio"></param>
        /// <param name="strDenNgayGio"></param>
        /// <param name="PhoneNumber"></param>
        /// <returns>@CuocGoiMoiGioi TABLE
        ///(   TongCuocGoi
          /// CuocGoiDonDuoc int,
           /// CuocGoiTruot int,
           /// CuocGoiHoan int,
           /// CuocGoiKhongXe int,
           /// SoChuyen int
          ///)</returns>
        public DataTable GetBaoCao_CuocGoiMoiGioi(string strTuNgayGio, string strDenNgayGio, string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@DenNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@PhoneCall",SqlDbType.VarChar ,8)  
                };
            parameters[0].Value = strTuNgayGio;
            parameters[1].Value = strDenNgayGio;
            parameters[2].Value = PhoneNumber;
            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetCuocGoiMoiGioi_ByPhoneNumber", parameters, "BaoCao_CuocGoiMoiGioi").Tables[0];
        }

        /// <summary>
        ///  get thong tin ve cuoc goi cua moi gioi lay theo ma
        /// </summary>
        /// <param name="strTuNgayGio"></param>
        /// <param name="strDenNgayGio"></param>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public DataTable GetBaoCao_CuocGoiMoiGioi_ByMaMoiGioi(string strTuNgayGio, string strDenNgayGio, string MaDoiTac)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@DenNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar ,10)  
                };
                parameters[0].Value = strTuNgayGio;
                parameters[1].Value = strDenNgayGio;
                parameters[2].Value = MaDoiTac;
                return this.RunProcedure("[sp_T_TAXIOPERATION_KETTHUC_GetCuocGoiMoiGioi_ByMaDoiTac]", parameters, "BaoCao_CuocGoiMoiGioi").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Loi DL.GetBaoCao_CuocGoiMoiGioi_ByMaMoiGioi");
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTuNgayGio"></param>
        /// <param name="strDenNgayGio"></param>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public DataTable GetBaoCao_CuocGoiMoiGioiOneDay(string strTuNgayGio, string strDenNgayGio, string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@DenNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@PhoneCall",SqlDbType.VarChar ,8)  
                };
            parameters[0].Value = strTuNgayGio;
            parameters[1].Value = strDenNgayGio;
            parameters[2].Value = PhoneNumber;
            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetCuocGoiMoiGioi_ByPhoneNumberOneDay", parameters, "BaoCao_CuocGoiMoiGioi").Tables[0];
        }
        /// <summary>
        /// Tra va bang du lieu TaxiOperation
        /// </summary>
        /// <param name="strTuNgayGio"></param>
        /// <param name="strDenNgayGio"></param>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
       public DataTable GetBaoCao_ChiTietCuocGoiMoiGioi(string strTuNgayGio, string strDenNgayGio, string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@DenNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@PhoneCall",SqlDbType.VarChar ,8)  
                };
            parameters[0].Value = strTuNgayGio;
            parameters[1].Value = strDenNgayGio;
            parameters[2].Value = PhoneNumber;
            return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetChiTietCuocGoiMoiGioi_ByPhoneNumber", parameters, "BaoCao_CuocGoiMoiGioi").Tables[0];
       }

        // bieu mau 14
        /// <summary>
        /// Lay trang thai (ra hoac ve) gan day nhat cua mot xe
        /// </summary>
        /// <returns></returns>
        public DataTable GetTrangThaiBaoRa_Ve_GanNhat(string SoHieuXe)
        {
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@SoHieuXe",SqlDbType.Char ,3)  ,                      
                };
            parameters[0].Value = SoHieuXe;
            return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_GetTrangThaiRaVeGanNhat", parameters, "tblBaoCaoBieuMau14").Tables[0];
        }
        /// <summary>
        /// lay cac su kien cua xe theo thoi diem
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="ThoiDiem"></param>
        /// <returns></returns>
        public DataTable GetTrangThaiBaoRa_Ve_TrongKhoang(DateTime TuThoiDiem, DateTime DenThoiDiem)
        { 

    //        [sp_T_KIEMSOAT_LIENLAC_GetTrangThaiRaVe_TrongKhoang]
   
    //@TuThoiDiem datetime ,
    //@DenThoiDiem datetime 
            SqlParameter[] parameters = new SqlParameter[] {                
                new SqlParameter("@TuThoiDiem",SqlDbType.DateTime )   ,
                new SqlParameter("@DenThoiDiem",SqlDbType.DateTime )
                };
           
            parameters[0].Value = TuThoiDiem;
            parameters[1].Value = DenThoiDiem;
            return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_GetTrangThaiRaVe_TrongKhoang", parameters, "tblBaoCaoBieuMau14").Tables[0];
        }
        /// <summary>
        /// get so chuyen cua mot so dien thoai trong ngay
        /// </summary>
        /// <param name="strNgay">yyyy-MM-dd </param>
        /// <param name="PhoneCall"></param>
        /// <returns></returns>
        public int GetCuocGoiMoiGioiInOneDay(string strNgay, string PhoneCall)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.VarChar ,10)  ,
                    new SqlParameter("@PhoneCall",SqlDbType.VarChar ,8)  ,
                    new SqlParameter("@SoChuyen",SqlDbType.Int )     
                };

                parameters[0].Value = strNgay;
                parameters[1].Value = PhoneCall;
                parameters[2].Direction = ParameterDirection.Output;

                this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetSoChuyenCuocGoiMoiGioi_ByPhoneNumber_InDay", parameters);
                
                return (int)parameters[2].Value;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// @SoHieuXe varchar(3),
	    ///@TuThoiDiem  Datetime,
	    ///@DenThoiDiem  Datetime
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        public DataTable  GetHanhTrinhXe_BaoCao17(string SoHieuXe, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar ,4)  ,
                     new SqlParameter("@TuThoiDiem",SqlDbType.DateTime )  ,
                    new SqlParameter("@DenThoiDiem",SqlDbType.DateTime )     
                };

                parameters[0].Value = SoHieuXe;
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;

                return this.RunProcedure("sp_T_KIEMSOAT_LIENLAC_HanhTrinhCuaXe_BC17", parameters, "tblHanhTrinhXe").Tables[0];

                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// lay thong tin hoat dong của nhan viên 
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetKetQuaHoatDongCuaNhanVien_BaoCao16(bool IsNhanVienDienThoai,string Username ,DateTime TuNgay, DateTime DenNgay)
        {
            try
              {

            //[sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau16]
            //@IsNhanVienDienThoai char(1),
            //@Username nvarchar(50),
            //@TuNgay Datetime,
            //@DenNgay datetime

                SqlParameter[] parameters = new SqlParameter[] {                      
                     new SqlParameter("@IsNhanVienDienThoai",SqlDbType.Char,1),
                     new SqlParameter("@Username",SqlDbType.NVarChar ,50)  ,
                     new SqlParameter("@TuNgay",SqlDbType.DateTime )  ,
                     new SqlParameter("@DenNgay",SqlDbType.DateTime )     
                };

                parameters[0].Value = IsNhanVienDienThoai == true ? '1' : '0';
                parameters[1].Value = Username;
                parameters[2].Value = TuNgay;
                parameters[3].Value = DenNgay;

                return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau16", parameters, "tblHanhTrinhXe").Tables[0];


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// báo cacó kết quản hoạt động của nhân viene gộp chung
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetKetQuaHoatDongCuaNhanVien_BaoCao16_GopChung(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
               //[sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau16_GOPCHUNG_DT_TD]	 
               // @TuNgay Datetime,
               // @DenNgay datetime

                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@TuNgay",SqlDbType.DateTime )  ,
                     new SqlParameter("@DenNgay",SqlDbType.DateTime )     
                };
                               
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;

                return this.RunProcedure("[sp_T_TAXIOPERATION_KETTHUC_BaoCaoBieuMau16_GOPCHUNG_DT_TD]", parameters, "tblHanhTrinhXe").Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public DataTable GetBaoCaoXeDiSanBayDuongDai(DateTime tuNgay, DateTime denNgay, int tinhThanh, int gara)
        {
            try 
            {
                //[sp_T_KIEMSOAT_LIENLAC_BaoCaoXeDiSanBayDuongDai_ByNgay]	
                //    @Ngay  
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@TuNgay",SqlDbType.DateTime ),
                     new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                    new SqlParameter ("@TinhDen",SqlDbType.Int ),
                    new SqlParameter ("@Gara",SqlDbType.Int )
                };
                parameters[0].Value = tuNgay;
                parameters[1].Value = denNgay;
                parameters[2].Value = tinhThanh;
                parameters[3].Value = gara;
                return this.RunProcedure("[SP_T_SANBAY_DUONGDAI_BC_TG]", parameters, "tblHanhTrinhXe").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetBaoCaoXeDiSanBayDuongDai_RutGon(DateTime Ngay)
        {
            try
            {
                //[sp_T_KIEMSOAT_LIENLAC_BaoCaoXeDiSanBayDuongDai_ByNgay]	
                //    @Ngay  
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@Ngay",SqlDbType.DateTime )        
                };
                parameters[0].Value = Ngay;
                return this.RunProcedure("[sp_T_KIEMSOAT_LIENLAC_BaoCaoXeDiSanBayDuongDai_ByNgay]", parameters, "tblHanhTrinhXe").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// hành trnhf xe cuốc khách theo múi giờ
        /// </summary>
        /// <param name="NgayServer"></param>
        /// <returns></returns>
        public DataTable GetXeHanhTrinh_CuocKhach_TrongNgay(DateTime NgayServer)
        {
            try
            {
               
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@Ngay",SqlDbType.DateTime )        
                };
                parameters[0].Value = NgayServer;
                return this.RunProcedure("[sp_T_TAXIOPERATION_KETTHUC_XEHanhTrinhCuocKhach_ByNgay]", parameters, "tblHanhTrinhXe").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// hanh trình xe theo dia chi
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public DataTable GetXeHanhTrinh_DiaChi_TrongNgay(DateTime Ngay)
        {
            try
            {

                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@Ngay",SqlDbType.DateTime )        
                };
                parameters[0].Value = Ngay;
                return this.RunProcedure("[sp_T_TAXIOPERATION_KETTHUC_XEHanhTrinhCuocKhachDiaChi_ByNgay]", parameters, "tblHanhTrinhXe").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetBCChiTietCuocKhachMoiGioi_BC07(string MaNhanVien, DateTime TuNgay, DateTime DenNgay,int SoChuyen)
        {
            //[BAOCAO.GetBCChiTietCuocKhachMoiGioi_BC07]
            //    @MaNhanVien nvarchar(50)='',
            //    @TuNgay datetime,
            //    @DenNgay datetime
            try
            {
               
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50 )  ,
                     new SqlParameter("@TuNgay",SqlDbType.DateTime )  ,
                     new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                    new SqlParameter("@SoChuyen",SqlDbType.Int)
                };
               
                parameters[0].Value = MaNhanVien;
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;
                parameters[3].Value = SoChuyen;

                return this.RunProcedure("[BAOCAO.GetBCChiTietCuocKhachMoiGioi_BC07]", parameters, "tblBCCuocKhachMoiGioi").Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// hàm trả về số chuyển của môi giới trong ngay cua rmột tháng
        /// </summary>
        /// <param name="Thang"></param>
        /// <param name="MaNhanVien"></param>
        /// <param name="SoChuyen"></param>
        /// <returns></returns>
        public DataTable GetBCChiTietCuocKhachMoiGioiTheoNgay_BC08(DateTime Thang, string MaNhanVien, int SoChuyen)
        {
            try
            {
                //BAOCAO.GetBCChiTietCuocKhachMoiGioiTheoNgayTrongThang_BC08]  
                //    @MaNhanVien nvarchar(50)='',
                //    @Thang datetime, 
                //    @SoChuyen int =0

                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50 )  ,
                     new SqlParameter("@Thang",SqlDbType.DateTime )  ,                    
                    new SqlParameter("@SoChuyen",SqlDbType.Int)
                };

                parameters[0].Value = MaNhanVien;
                parameters[1].Value = Thang;                
                parameters[2].Value = SoChuyen;

                return this.RunProcedure("[BAOCAO.GetBCChiTietCuocKhachMoiGioiTheoNgayTrongThang_BC08]", parameters, "tblBCCuocKhachMoiGioi").Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetBCChiTietCuocKhachMoiGioiTheoNgay(DateTime Thang, string MaNhanVien, int SoChuyen, string MaMoiGioi)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50 )  ,
                     new SqlParameter("@Thang",SqlDbType.DateTime )  ,                    
                    new SqlParameter("@SoChuyen",SqlDbType.Int),
                    new SqlParameter("@MaMoiGioi",SqlDbType.VarChar,50)
                };

                parameters[0].Value = MaNhanVien;
                parameters[1].Value = Thang;
                parameters[2].Value = SoChuyen;
                parameters[3].Value = MaMoiGioi;

                return this.RunProcedure("GetBCChiTietCuocKhachMoiGioiTheoNgayTrongThang", parameters, "tblBCCuocKhachMoiGioi").Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetBCChiTietCuocKhachMoiGioiTheoThang_BC09(string MaNhanVien, DateTime TuThang, DateTime DenThang, int SoChuyen)
        {
            //BAOCAO.GetBCChiTietCuocKhachMoiGioiTheoThang_BC09]   
            //    @MaNhanVien nvarchar(50)='',
            //    @TuThang datetime, 
            //    @DenThang Datetime,
            //    @SoChuyen int =0
            SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50 )  ,
                     new SqlParameter("@TuThang",SqlDbType.DateTime )  ,
                     new SqlParameter("@DenThang",SqlDbType.DateTime ),
                    new SqlParameter("@SoChuyen",SqlDbType.Int)
                };

            parameters[0].Value = MaNhanVien;
            parameters[1].Value = TuThang;
            parameters[2].Value = DenThang;
            parameters[3].Value = SoChuyen;

            return this.RunProcedure("[BAOCAO.GetBCChiTietCuocKhachMoiGioiTheoThang_BC09]", parameters, "tblBCCuocKhachMoiGioi").Tables[0];

        }
        /// <summary>
        /// BC 10 : Get chi tiet thong tin cuoc khach moi gioi
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="p_3"></param>
        /// <returns></returns>
        public DataTable GetBaoCao_ChiTietCuocGoiMoiGioiByMaDoiTac(string strTuNgayGio, string strDenNgayGio, string MaDoiTac)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@DenNgayGio",SqlDbType.VarChar ,19)  ,
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar ,10)  
                };
            parameters[0].Value = strTuNgayGio;
            parameters[1].Value = strDenNgayGio;
            parameters[2].Value = MaDoiTac;
            return this.RunProcedure("[BAOCAO.GetBCChiTietCuocKhachMoiGioiByMaDoiTac_BC10]", parameters, "BaoCao_CuocGoiMoiGioi").Tables[0];
        }

        public DataTable GetBaoCaoGroupMoiGioi(DateTime TuNgay, DateTime DenNgay, int CongtyID)
        {
             
               try
               {
                   //[dbo].[MOIGIOI.BaoCaoMoiGioiTongHop]  
                   //    @TuNgay datetime,
                   //    @DenNgay datetime, 
                   //    @CongTyID int =0
                   SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime)  ,
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )  ,
                    new SqlParameter("@CongTyID",SqlDbType.Int)  
                   };
                   parameters[0].Value = TuNgay;
                   parameters[1].Value = DenNgay;
                   parameters[2].Value = CongtyID;
                   return this.RunProcedure("[MOIGIOI.BaoCaoMoiGioiTongHop]", parameters, "BaoCao_CuocGoiMoiGioi").Tables[0];
               }
               catch (Exception ex)
               {
                   return null;
               }
        }
        public DataTable MoiGioi_GetBaoCaoKetQuaDieuHanh(DateTime TuNgay, DateTime DenNgay, int CongtyID)
        {
            try
            {
                //[dbo].[MOIGIOI.BaoCaoMoiGioiTongHop]  
                //    @TuNgay datetime,
                //    @DenNgay datetime, 
                //    @CongTyID int =0
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime)  ,
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )  ,
                    new SqlParameter("@CongTyID",SqlDbType.Int)  
                   };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = CongtyID;
                return this.RunProcedure("[MOIGIOI.BaoCaoMoiGioiKetQuaDieuHanhByCongTy]", parameters, "MoiGioiTheoKetQua").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable   MoiGioi_GetChiTietCuoc999(DateTime  TuNgay, DateTime  DenNgay, int CongtyID)
        {
            string strSQL = "";

            strSQL += " SELECT  DT.Ma_DoiTac MaDoiTac,DT.Name,  DT.FK_CongTyID CongTyID,CT.TenCongTy , T.SoDienThoai,T.DiaChiDonKhach, T.ThoiDiemGoi,T.XeNhan, T.XeDon ";
		     strSQL +="  FROM T_DOITAC DT ";
		     strSQL +=" 	 INNER JOIN ( ";
		     strSQL +=" 		   SELECT KT.[MaDoiTac], KT.DiaChiDonKhach,KT.PhoneNumber SoDienThoai, KT.[ThoiDiemGoi]  , KT.XeNhan, KT.XeDon   ";
		     strSQL +=" 		   FROM  [T_TAXIOPERATION_KETTHUC] KT ";
		     strSQL +=" 		   WHERE KT.ThoiDiemGoi >='" + string .Format ("{0:yyyy-MM-dd HH:mm:ss}",TuNgay) + "' AND KT.ThoiDiemGoi <= '" + string .Format ("{0:yyyy-MM-dd HH:mm:ss}",DenNgay ) + "' AND KieuCuocGoi = 1   AND LEN (MADOITAC)>0  and len(xenhan)>0 and xedon='999' "; 
		     strSQL +=" ) T  ";
		     strSQL +="   ON DT.Ma_DoiTac = T.MaDoiTac ";
             strSQL += "    JOIN T_DMCongTy CT   ON   DT.FK_CongTyID = CT.PK_CongtyID ";
             if (CongtyID > 0)
                 strSQL += " WHERE CT.PK_CongtyID = " + CongtyID.ToString();
            return  this.RunSQL(strSQL, "tbl999");

        }

        public DataTable MoiGioi_GetChiTietCuocTuXoa(DateTime TuNgay, DateTime DenNgay, int CongtyID)
        {
            string strSQL = "";

            strSQL += " SELECT  DT.Ma_DoiTac MaDoiTac,DT.Name,  DT.FK_CongTyID CongTyID,CT.TenCongTy , T.SoDienThoai,T.DiaChiDonKhach, T.ThoiDiemGoi,T.XeNhan  ";
            strSQL += "  FROM T_DOITAC DT ";
            strSQL += " 	 INNER JOIN ( ";
            strSQL += " 		   SELECT KT.[MaDoiTac], KT.DiaChiDonKhach,KT.PhoneNumber SoDienThoai, KT.[ThoiDiemGoi]  , KT.XeNhan   ";
            strSQL += " 		   FROM  [T_TAXIOPERATION_KETTHUC] KT ";
            strSQL += " 		   WHERE KT.ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay) + "' AND KT.ThoiDiemGoi <= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay) + "' AND KieuCuocGoi = 1 AND TrangThaiCuocGoi = 5 AND Len(XeNhan)>0 AND XENHAN <> '999'  AND LEN (MADOITAC)>0 ";
            strSQL += " ) T  ";
            strSQL += "   ON DT.Ma_DoiTac = T.MaDoiTac ";
            strSQL += "    JOIN T_DMCongTy CT   ON   DT.FK_CongTyID = CT.PK_CongtyID ";
            if (CongtyID > 0)
                strSQL += " WHERE CT.PK_CongtyID = " + CongtyID.ToString();
            return this.RunSQL(strSQL, "tbl999");
        }

         public DataTable CSKH_BaoCaoTongHop(DateTime TuNgay, DateTime DenNgay, string sVung, int SoLanKhachGoiLai, string idCSKH, int loaiSoDienThoai)
        { 
            try
            {               
                //[CSKH.BaoCaoCSKHTongHop]  
                //   @TuNgay datetime,
                //   @DenNgay datetime, 
                //   @Vungs varchar(50) = null,
                //   @SoLanKhachGoiLai INT = NULL,
                //   @IDCS	NVARCHAR(50) = NULL,
                //   @LoaiSoDienThoaiGoi TINYINT = NULL -- 1:Moi gioi, 2: vang lai di dong, 3: vang lai co dinh

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime)  ,
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )  ,
                    new SqlParameter("@Vungs",SqlDbType.VarChar ,50) ,
                    new SqlParameter("@SoLanKhachGoiLai",SqlDbType.Int), 
                    new SqlParameter("@IDCS",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@LoaiSoDienThoaiGoi",SqlDbType.TinyInt)
                   };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                if(sVung.Length>0)
                    parameters[2].Value = sVung ;
                if(SoLanKhachGoiLai>0)
                    parameters[3].Value = SoLanKhachGoiLai;
                if(idCSKH.Length>0)
                    parameters[4].Value = idCSKH;
                 parameters[5].Value = loaiSoDienThoai;

                 return this.RunProcedure("[CSKH.BaoCaoCSKHTongHop]", parameters, "CSKHTongHop").Tables[0];
            }
            catch 
            {
                return null;
            }
        }

        public DataTable GROUP_BC_1_1_TongKetCuocGoiDenByCa(DateTime Ngay)
        {
            try
            {
                 //[GROUP.BC_1_1_TongKetCuocGoiDenByCa]
                 //   @Ngay DATETIME 
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.DateTime)   
                   };
                parameters[0].Value = Ngay;

                return this.RunProcedure("[GROUP.BC_1_1_TongKetCuocGoiDenByCa]", parameters, "CSKHTongHop").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// hàm trả về dư xliệu tổng kết cuốc gọi đến theo giờ
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public DataTable GROUP_BC_1_1_TongKetCuocGoiDenByGio(DateTime  Ngay)
        {
            try
            {
                //[GROUP.BC_1_1_TongKetCuocGoiDenByCa]
                //   @Ngay DATETIME 
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.DateTime)   
                   };
                parameters[0].Value = Ngay;

                return this.RunProcedure("[GROUP.BC_1_1_TongKetCuocGoiDenByGio]", parameters, "CSKHTongHop").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoNgay(DateTime TuNgay, DateTime DenNgay, string sVung)
        {
            try
            {
                 //[GROUP.BC_3_1_KetQuaDieuHanhTheoNgay]  
                 //     @TuNgay DATETIME , 
                 //     @DenNgay DATETIME,
                 //     @sVung varchar(20)
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime),  
                    new SqlParameter("@sVung",SqlDbType.VarChar,20)  
                   };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = sVung;

                return this.RunProcedure("[GROUP.BC_3_1_KetQuaDieuHanhTheoNgay]", parameters, "bcDHTheoNgay").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoCa(DateTime Ngay, string sVung)
        {
            try
            {
                //[GROUP.BC_3_1_KetQuaDieuHanhTheoCa]  
                //      @Ngay DATETIME , 	  
                //      @sVung varchar(20)
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.DateTime), 
                    new SqlParameter("@sVung",SqlDbType.VarChar,20)  
                   };
                parameters[0].Value = Ngay;
                parameters[1].Value = sVung ; 
                return this.RunProcedure("[GROUP.BC_3_1_KetQuaDieuHanhTheoCa]", parameters, "bcDHTheoNgay").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoGio(DateTime TuNgay,DateTime DenNgay, string sVung)
        {
            try
            {
                //[GROUP.BC_3_1_KetQuaDieuHanhTheoGio]  
                //      @TuNgay DATETIME , 	
                //      @DenNgay DATETIME , 	  
                //      @sVung varchar(20)

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime),
                    new SqlParameter("@sVung",SqlDbType.VarChar,20)  
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = sVung;
                return this.RunProcedure("[GROUP.BC_3_1_KetQuaDieuHanhTheoGio]", parameters, "bcDHTheoNgay").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_3_1_BaoCaoDieuHanhTheoDonVi(DateTime TuNgay, DateTime DenNgay, string sVung)
        {
            try
            {
                //[GROUP.BC_3_2_KetQuaDieuHanhTheoDonVi]
                //      @TuNgay DATETIME , 	
                //      @DenNgay DATETIME , 	  
                //      @sVung varchar(20)

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime),
                    new SqlParameter("@sVung",SqlDbType.VarChar,20)  
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = sVung;
                return this.RunProcedure("[GROUP.BC_3_2_KetQuaDieuHanhTheoDonVi]", parameters, "bcDHTheoNgay").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_2_3_BaoCaoNhanVien(DateTime TuNgay, DateTime DenNgay, string Vung, string NhanVienID)
        {
            try
            {
                

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime),
                    new SqlParameter("@Vung",SqlDbType.VarChar,50),  
                    new SqlParameter("@NhanVienID",SqlDbType.NVarChar,50)  
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = Vung;
                parameters[3].Value = NhanVienID;

                return this.RunProcedure("[GROUP.BC_2_3_KetQuaDieuHanhTheoNhanVien]", parameters, "bcDHTheoNgay").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #region BAO CAO NEW  (chuyen sang MyDinh)

        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGio(DateTime TuNgay, DateTime DenNgay ,ref string  id )
        {
            id = string.Empty;
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@ID",SqlDbType.VarChar,36)
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Direction = ParameterDirection.Output;

                DataTable dt = this.RunProcedure("[GROUP.BC_1_1_TongHopCuocGoiDenTheoGio]", parameters, "bcDHTheoNgay").Tables[0];
                id = parameters[2].Value.ToString();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// lay cac thong tin theo cuoc khach binh quan cua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGioBinhQuan(string id)
        {
            string strSQL = "";
            strSQL +="SELECT [GioHienThi] ,[ThuTu] ,[TrungBinhTaxi] TongTaxi ,[TrungBinhGoiLai] TongGoiLai ,[TrungBinhKhieuNai] TongKhieuNai";
            strSQL += ",[TrungBinhDichVu] TongDichVu, TrungBinhGoiHoiDam TongHoiDam ,[TrungBinhKhac] TongGoiKhac ,[TrungBinhGoiNho]  GoiNho ";
            strSQL += ", ([TrungBinhTaxi]+[TrungBinhGoiLai]+[TrungBinhKhieuNai]+[TrungBinhDichVu]+TrungBinhGoiHoiDam +[TrungBinhKhac] )TongCuocGoi ";
            strSQL += ",[TrungBinhDonduoc] TongDonDuoc,[TrungBinhTruotHoan] TongTruot ,[TrungBinhKhongXe] KhongXe ";
            strSQL += ",([TrungBinhTruotHoan]+[TrungBinhKhongXe]) TongTruotHoanKhongXe,Cuoc999,Cuoc888, PhanTramDonDuoc ";
            strSQL += " FROM [TEMP.T_BC1_1_TONGHOPGOIDENTHEONGAY] ";
            strSQL += " WHERE ID = '" + id + "'";
             
            return this.RunSQL(strSQL, "tblBinhQuan");
        }

        /// <summary>
        /// lay du lieu tong hop cuoc goi den theo ngay
        /// tra ve id of binh quan ngay
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgay(DateTime TuNgay, DateTime DenNgay, ref string id)
        {
            id = string.Empty;
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@ID",SqlDbType.VarChar,36)
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Direction = ParameterDirection.Output;

                DataTable dt = this.RunProcedure("[GROUP.BC_1_1_TongHopCuocGoiDenTheoNgay]", parameters, "bcDHTheoNgay").Tables[0];
                id = parameters[2].Value.ToString();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// lay du lieu tong hop cuoc goi den theo ngay
        /// tra ve id of binh quan ngay
        /// </summary>
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgayV2(DateTime TuNgay, DateTime DenNgay, ref string id,int KhuVuc)
        {
            id = string.Empty;
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@ID",SqlDbType.VarChar,36),
                    new SqlParameter("@KhuVuc",SqlDbType.Int,36)
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Direction = ParameterDirection.Output;
                parameters[3].Value = KhuVuc;
                DataTable dt = this.RunProcedure("[GROUP.BC_1_1_TongHopCuocGoiDenTheoNgayV2]", parameters, "bcDHTheoNgay").Tables[0];
                id = parameters[2].Value.ToString();
                return dt;
            }
            catch 
            {
                return null;
            }
        }
        public DataTable GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoCa(DateTime TuNgay, DateTime DenNgay, ref string id)
        {
            id = string.Empty;
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@ID",SqlDbType.VarChar,36)
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Direction = ParameterDirection.Output;

                DataTable dt = this.RunProcedure("[GROUP.BC_1_1_TongHopCuocGoiDenTheoCa]", parameters, "bcDHTheoNgay").Tables[0];
                id = parameters[2].Value.ToString();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Bao cao ket qua dieu hanh theo ngay
        /// </summary>
        /// <modified>
        /// author          created date    comment
        /// hangtm                         created
        /// </modified>
        public DataSet GROUP_BaoCaoKetQuaDieuHanh_TheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                new SqlParameter ("@DenNgay",SqlDbType.DateTime)
                
                };
                parameters[0].Value = tuNgay;
                parameters[1].Value = denNgay;
                
                DataSet ds = this.RunProcedure("[SP_BAOCAO_KETQUA_DIEUHANH_THEONGAY]", parameters, "KetQuaDieuHanh");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Bao cao ket qua dieu hanh theo ca
        /// </summary>
        /// <modified>
        /// author          created date    comment
        /// hangtm                          created
        /// </modified>
        public DataSet GROUP_BaoCaoKetQuaDieuHanh_TheoCa(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] 
                { 
                    new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter ("@DenNgay",SqlDbType.DateTime)                
                };
                parameters[0].Value = tuNgay;
                parameters[1].Value = denNgay;
               
                DataSet ds = this.RunProcedure("[SP_BAOCAO_KETQUA_DIEUHANH_THEOCA]", parameters, "KetQuaDieuHanh");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Bao cao ket qua dieu hanh theo gio
        /// </summary>        
        /// <modified>
        /// author          created date    comment
        /// hangtm                           created
        /// </modified>
        public DataSet GROUP_BaoCaoKetQuaDieuHanh_TheoGio(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                new SqlParameter ("@DenNgay",SqlDbType.DateTime)
               
                };
                parameters[0].Value = tuNgay;
                parameters[1].Value = denNgay;
                
                DataSet ds = this.RunProcedure("[SP_BAOCAO_KETQUA_DIEUHANH_THEOGIO]", parameters, "KetQuaDieuHanh");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // BC 4.6 - Ket Qua Nhan Vien - KQNV
        public DataTable GetKQNV_DienThoai(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            #region===old====
            //DataTable dt = new DataTable();
              //string strSQL = ""; 
              //strSQL += "DECLARE @SoGiayGioiHanChuyenTongDai  INT ";
              //strSQL += "SET @SoGiayGioiHanChuyenTongDai = 0 ";
              //// Khoang thoi gian quy dinh chuyen cham
              //strSQL += "SET @SoGiayGioiHanChuyenTongDai = (SELECT TOP 1 SoGiayGioiHanThoiGianChuyenTongDai FROM  [T_TAXIOPERATION_PARAMETER]) ";              
              //strSQL += "SELECT T.NgayHienThi, COUNT(T.GoiTaxi) SoCuocGoi,SUM(T.GoiTaxi) SoCuocTaxi, SUM(T.ChuyenCham) SoChuyenCham ";
              //strSQL += "FROM "; 
              //strSQL += "  (SELECT  CONVERT(VARCHAR,KT.ThoiDiemGoi, 103) NgayHienThi,  KT.MaNhanVienDienThoai NVDT, ";
              //strSQL += "     GoiTaxi = CASE WHEN KT.KieuCuocGoi = 1   AND KT.Vung<9   THEN 1 ELSE 0 END, ";
              //strSQL += "     ChuyenCham = CASE WHEN KT.ThoiDiemChuyenTongDai > @SoGiayGioiHanChuyenTongDai THEN 1 ELSE 0 END ";
              //strSQL += "   FROM T_TAXIOPERATION_KETTHUC KT ";
              //strSQL += "   WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'",TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'",DenNgay) + " AND KT.MaNhanVienDienThoai= '" +NhanVienID+ "') T ";
              //strSQL += "GROUP BY T.NgayHienThi ";
              //strSQL += "ORDER BY T.NgayHienThi";

              //try
              //{
                
              //    dt = RunSQL(strSQL, "tblKQNV_DT");
              //    return dt;
              //}
              //catch (Exception ex)
              //{
              //    return null;
            //}
            #endregion

            #region==New===
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                new SqlParameter ("@DenNgay",SqlDbType.DateTime),
                new SqlParameter ("@NhanVienID",SqlDbType.VarChar)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = NhanVienID;

                DataTable dt = this.RunProcedure("BC4_6_KetQuaDieuHanhNVTheoNgay_GetKQNV_DienThoai", parameters, "tblKQNV_DT").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            #endregion
        }
        /// <summary>
        /// laays thong tin cua NVTongDai
        /// </summary>
        public DataTable GetKQNV_TongDai(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            #region==Old===
            //string strSQL = "";
            //strSQL += "SELECT T.NgayHienThi, COUNT(T.NVTD) SoCuocDieu, SUM(T.CuocDonDuoc) TongDonDuoc,SUM(T.Cuoc999) CuocKhach999 ";
            //strSQL += "FROM ";
            //strSQL += "(";
            //strSQL += "  SELECT  CONVERT(VARCHAR,KT.ThoiDiemGoi, 103) NgayHienThi,  KT.MaNhanVienTongDai NVTD, ";
            //strSQL += "          CuocDonDuoc = CASE WHEN KT.KieuCuocGoi = 1 AND XeDon IS NOT NULL AND LEN(XeDon) > 0 THEN [dbo].[fnGetSoChuyen](XeDon) ELSE 0 END,  ";
            //strSQL += "          Cuoc999 =  CASE WHEN KT.KieuCuocGoi = 1 AND KT.XEDON = '999' THEN 1 ELSE 0 END  ";
            //strSQL += "   FROM T_TAXIOPERATION_KETTHUC KT ";
            //strSQL += "   WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) + " AND   KT.KieuCuocGoi = 1 AND KT.MaNhanVienTongDai= '" + NhanVienID + "' AND KT.Vung<9 ";
            //strSQL += ") T ";
            //strSQL += " GROUP BY T.NgayHienThi ";
            //strSQL += " ORDER BY T.NgayHienThi ";

            //return this.RunSQL(strSQL, "tblKQNV_DT");
            #endregion

            #region==New===
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                new SqlParameter ("@DenNgay",SqlDbType.DateTime),
                new SqlParameter ("@NhanVienID",SqlDbType.VarChar)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = NhanVienID;

                DataTable dt = this.RunProcedure("BC4_6_KetQuaDieuHanhNVTheoNgay_GetKQNV_TongDai", parameters, "tblKQNV_TD").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            #endregion
        }
        /// <summary>
        /// lay du lieu cua NVCS Khach Hang
        /// </summary>
        public DataTable GetKQNV_NVCS(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            #region===Old===
            // string strSQL = "";
            // strSQL += "SELECT T.NgayHienThi, COUNT(T.NVCS) SoCuocGoiTaxi, SUM(T.CuocCoGoiCS) TongCuocCS,SUM(T.CuocDonDuoc) TongDonDuoc,SUM(Cuoc888) TongCuoc888  ";
            // strSQL += "FROM ";
            // strSQL += "  (";
            // strSQL += "     SELECT  CONVERT(VARCHAR,KT.ThoiDiemGoi, 103) NgayHienThi,  KT.MOIKHACH_NhanVien NVCS,";
            // strSQL += "            CuocCoGoiCS = CASE WHEN LEN( MOIKHACH_NhungThoiDiemMoi)>0  THEN 1 ELSE 0 END,";
            // strSQL += "            CuocDonDuoc = CASE WHEN KT.KieuCuocGoi = 1   AND ( KT.TrangThaiCuocGoi = 1 OR XeDon='8888' ) AND KT.XeDon <> '999' THEN [dbo].[fnGetSoChuyen](xeDon) ELSE 0 END,  ";
            // strSQL += "            Cuoc888 = CASE WHEN KT.KieuCuocGoi = 1   AND   XeDon='8888'    THEN 1 ELSE 0 END  ";
            // strSQL += "     FROM T_TAXIOPERATION_KETTHUC KT ";
            // strSQL += "     WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) + " AND   KT.KieuCuocGoi = 1 AND KT.MOIKHACH_NhanVien= '" + NhanVienID + "' AND KT.Vung<9 ";
            // strSQL += "   ) T ";
            // strSQL += "GROUP BY T.NgayHienThi ";
            // strSQL += "ORDER BY T.NgayHienThi ";

            //return this.RunSQL(strSQL, "tblKQNV_DT");
            #endregion

            #region==New===
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                new SqlParameter ("@DenNgay",SqlDbType.DateTime),
                new SqlParameter ("@NhanVienID",SqlDbType.VarChar)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = NhanVienID;

                DataTable dt = this.RunProcedure("BC4_6_KetQuaDieuHanhNVTheoNgay_GetKQNV_NVCS", parameters, "tblKQNV_NVCS").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            #endregion
        }
        /// <summary>
        /// Lay du lieu lam viec cua nhan vien ban tin gia
        /// </summary>
        public DataTable GetKQNV_BanTinGia(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            #region===Old===
            //string strSQL = "";
            //strSQL += " SELECT T.NgayHienThi, COUNT(T.NVBTin) SoCuocGoiGiaiQuyet, SUM(T.CuocDaGiaiQuyetDuoc) SoCuocGoiDaGiaiQuyetDuoc ";
            //strSQL += " FROM ";
            //strSQL += "   (";
            //strSQL += "      SELECT  CONVERT(VARCHAR,KT.ThoiDiemGoi, 103) NgayHienThi,  KT.BANTINBANGIA_NhanVien NVBTin,";
            //strSQL += "             CuocDaGiaiQuyetDuoc = CASE WHEN BANTINBANGIA_IsXuLy = 1   THEN 1 ELSE 0 END ";
            //strSQL += "      FROM T_TAXIOPERATION_KETTHUC KT ";
            //strSQL += "     WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay);
            //strSQL += "           AND KT.BANTINBANGIA_NhanVien= '" + NhanVienID + "' AND KT.Vung>=9 ";
            //strSQL += "    ) T ";
            //strSQL += " GROUP BY T.NgayHienThi ";
            //strSQL += " ORDER BY T.NgayHienThi ";

            //return this.RunSQL(strSQL, "tblKQNV_DT");
            #endregion

            #region==New===
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                new SqlParameter ("@DenNgay",SqlDbType.DateTime),
                new SqlParameter ("@NhanVienID",SqlDbType.VarChar)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = NhanVienID;

                DataTable dt = this.RunProcedure("BC4_6_KetQuaDieuHanhNVTheoNgay_GetKQNV_BanTinGia", parameters, "tblKQNV_BanTinGia").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            #endregion
        }
        public DataTable GetKQNV_DieuG5(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@TuNgay",SqlDbType.DateTime),
                new SqlParameter ("@DenNgay",SqlDbType.DateTime),
                new SqlParameter ("@MaNhanVien",SqlDbType.VarChar)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = NhanVienID;

                DataTable dt = this.RunProcedure("BC4_6_KetQuaDieuHanhNVTheoNgay_GetKQNV_DieuG5", parameters, "tblKQNV_DieuG5").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #region TongHopNVDieuHanh

        /// <summary>
        /// tổng hợp kết quả nhân viên điều hành
        /// if(có nhânvienID) thì tìm duynhất
        /// else tìm tất cả nhân viên
        /// </summary>
        public DataTable GetTongHopKQNV_DienThoai(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            strSQL += "DECLARE @SoGiayGioiHanChuyenTongDai  INT ";
            strSQL += "SET @SoGiayGioiHanChuyenTongDai = 0 ";
            // Khoang thoi gian quy dinh chuyen cham
            strSQL += "SET @SoGiayGioiHanChuyenTongDai = (SELECT TOP 1 SoGiayGioiHanThoiGianChuyenTongDai FROM  [T_TAXIOPERATION_PARAMETER]) ";
            strSQL += "SELECT T.NVDT, COUNT(T.GoiTaxi) SoCuocGoi,SUM(T.GoiTaxi) SoCuocTaxi, SUM(T.ChuyenCham) SoChuyenCham ";
            strSQL += "FROM ";
            strSQL += "  (SELECT KT.MaNhanVienDienThoai NVDT, ";
            strSQL += "     GoiTaxi = CASE WHEN KT.KieuCuocGoi = 1   AND KT.Vung<9   THEN 1 ELSE 0 END, ";
            strSQL += "     ChuyenCham = CASE WHEN KT.ThoiDiemChuyenTongDai > @SoGiayGioiHanChuyenTongDai THEN 1 ELSE 0 END ";
            strSQL += "   FROM T_TAXIOPERATION_KETTHUC KT ";
            strSQL += "   WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) ;
            if (NhanVienID.Length > 0)
                strSQL += "  AND KT.MaNhanVienDienThoai= '" + NhanVienID + "'";
            strSQL += ") T ";
            strSQL += "GROUP BY T.NVDT ";
            strSQL += "ORDER BY T.NVDT";

            try
            {
                dt = RunSQL(strSQL, "tblKQNV_DT");
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetTongHopKQNV_TongDai(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@MaNhanVien",SqlDbType.VarChar,50),
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )

                };
                if (!string.IsNullOrEmpty(NhanVienID))
                {
                    parameters[0].Value = NhanVienID;
                }                
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;

                DataSet ds = this.RunProcedure("V3_BCTHKetQuaDieuHanh_TDV", parameters, "tblKQNHTD");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            //string strSQL = "";
            //strSQL += "SELECT T.NVTD, COUNT(T.NVTD) SoCuocDieu, SUM(T.CuocDonDuoc) TongDonDuoc,SUM(T.Cuoc999) CuocKhach999 ";
            //strSQL += "FROM ";
            //strSQL += "(";
            //strSQL += "  SELECT    KT.MaNhanVienTongDai NVTD, ";
            //strSQL += "          CuocDonDuoc = CASE WHEN KT.KieuCuocGoi = 1   AND (KT.TrangThaiCuocGoi = 1 OR  XeDon ='8888') AND   KT.XeDon <> '999' THEN 1 ELSE 0 END ,";
            //strSQL += "          Cuoc999 =  CASE WHEN KT.KieuCuocGoi = 1 AND KT.XEDON = '999' THEN 1 ELSE 0 END  ";
            //strSQL += "   FROM T_TAXIOPERATION_KETTHUC KT ";
            //strSQL += "   WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) + "  AND KT.KieuCuocGoi = 1  AND KT.Vung<9  ";
            //if(NhanVienID.Length >0)
            //    strSQL += "   AND KT.MaNhanVienTongDai= '" + NhanVienID + "'";
            //strSQL += ") T ";
            //strSQL += " GROUP BY T.NVTD ";
            //strSQL += " ORDER BY T.NVTD ";

            //return this.RunSQL(strSQL, "tblKQNV_DT");
        }

        public DataTable GetTongHopKQNV_TongDai_TBThoiGianDonKhach_V2(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@MaNhanVien",SqlDbType.VarChar,50),
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )

                };
                if (!string.IsNullOrEmpty(NhanVienID))
                {
                    parameters[0].Value = NhanVienID;
                }
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;

                DataSet ds = this.RunProcedure("V3_BCTHKetQuaDieuHanh_TongDai_TBThoiGianDonKhach", parameters, "tblKQNHTD");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// hàm tính số giây đón bình quân của nhân viên tổng đài
        /// </summary>
        public DataTable GetTongHopKQNV_TongDai_TBThoiGianDonKhach(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            string strSQL = "";
            strSQL +=" select UPPER(MaNhanVienTongDai) NVTD, Count(MaNhanVienTongDai) SoCuoc, AVG (ThoiGianDonKhach) TBTGDonTD  from T_TAXIOPERATION_KETTHUC ";
            strSQL += " where ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " and ThoiDiemGoi <= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay)  ;
            strSQL +="   and (xedon is not null) and len(XeDon) > 0  and XeDon <> '999' and XeDon <> '888' and ThoiGianDonKhach>0 ";
            strSQL +="   and ThoiGianDonKhach < 600 and Vung>=0 and Vung <=8 and LEN (MaNhanVienTongDai)>0 ";
            strSQL += "   group by MaNhanVienTongDai ";
             

            return this.RunSQL(strSQL, "tblKQNV_CS_TimeDon");
        }

        public DataTable GetTongHopKQNV_NVCS(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            string strSQL = "";
            strSQL += "SELECT  T.NVCS, COUNT(T.NVCS) SoCuocGoiTaxi, SUM(T.CuocCoGoiCS) CuocGoiCoCS,SUM(T.CuocDonDuoc) CuocGoiCS_DonDuoc, SUM(Cuoc888) TongCuoc888 ";
            strSQL += "FROM ";
            strSQL += "  (";
            strSQL += "     SELECT KT.MOIKHACH_NhanVien NVCS,";
            strSQL += "            CuocCoGoiCS = CASE WHEN LEN( MOIKHACH_NhungThoiDiemMoi)>0  THEN 1 ELSE 0 END,";
            strSQL += "            CuocDonDuoc = CASE WHEN KT.KieuCuocGoi = 1   AND (KT.TrangThaiCuocGoi = 1 OR  XeDon='8888' ) AND KT.XeDon <> '999' THEN [dbo].[fnGetSoChuyen](xeDon) ELSE 0 END, ";
            strSQL += "            Cuoc888 = CASE WHEN KT.KieuCuocGoi = 1   AND KT.TrangThaiCuocGoi = 0  THEN 1 ELSE 0  END ";
            strSQL += "     FROM T_TAXIOPERATION_KETTHUC KT ";
            strSQL += "     WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) + "  AND KT.KieuCuocGoi = 1  AND KT.Vung<9 ";
            if (NhanVienID.Length >0)
                strSQL +=  " AND KT.MOIKHACH_NhanVien= '" + NhanVienID + "'";
            strSQL += "   ) T ";
            strSQL += "GROUP BY T.NVCS ";
            strSQL += "ORDER BY T.NVCS ";

            return this.RunSQL(strSQL, "tblKQNV_CS"); 
        }
        public DataTable GetTongHopKQNV_NVCSMK(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            string strSQL = "";
            strSQL += "SELECT  T.NVCS, COUNT(T.NVCS) SoCuocGoiTaxi, SUM(T.CuocCoGoiCS) CuocGoiCoCS,SUM(T.CuocDonDuoc) CuocGoiCS_DonDuoc, SUM(Cuoc888) TongCuoc888,case when SUM(CuocDonDuoc)>0 then (SUM(ThoiGianDonKhach)/SUM(CuocDonDuoc)) else 0 end  TBTGDonMK ";
            strSQL += "FROM ";
            strSQL += "  (";
            strSQL += "     SELECT NVCS =(Case when KT.MOIKHACH_NhanVien is null OR KT.MOIKHACH_NhanVien='' then KT.MaNhanVienDienThoai else  KT.MOIKHACH_NhanVien end),";
            strSQL += "            CuocCoGoiCS = CASE WHEN LEN( MOIKHACH_NhungThoiDiemMoi)>0  THEN 1 ELSE 0 END,";
            strSQL += "            CuocDonDuoc = CASE WHEN KT.KieuCuocGoi = 1   AND (KT.TrangThaiCuocGoi = 1 OR  XeDon='8888' ) AND KT.XeDon <> '999' THEN 1 ELSE 0 END, ";
            strSQL += "            Cuoc888 = CASE WHEN KT.KieuCuocGoi = 1   AND KT.TrangThaiCuocGoi = 0  THEN 1 ELSE 0  END, ";
            strSQL += "            ThoiGianDonKhach = CASE WHEN KT.KieuCuocGoi = 1   AND (KT.TrangThaiCuocGoi = 1 OR  XeDon='8888' ) AND KT.XeDon <> '999' THEN  ThoiGianDonKhach ELSE 0  END ";
            strSQL += "     FROM T_TAXIOPERATION_KETTHUC KT ";
            strSQL += "     WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) + "  AND KT.KieuCuocGoi = 1  AND KT.Vung<9 ";
            if (NhanVienID.Length > 0)
                strSQL += " AND KT.MOIKHACH_NhanVien= '" + NhanVienID + "'";
            strSQL += "   ) T ";
            strSQL += "GROUP BY T.NVCS ";
            strSQL += "ORDER BY T.NVCS ";

            return this.RunSQL(strSQL, "tblKQNV_CS");
        }

        /// <summary>
        /// Get thông tin tổng hợp KQNV_CS - ThoiGian Don khach trung binh
        /// </summary>
        public DataTable GetTongHopKQNV_NVCS_TBThoiGianDonKhach(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            string strSQL = "";
            if (license.idxCompany == 28)
            {
                strSQL += " select UPPER(MaNhanVienDienThoai) NVCS, Count(MaNhanVienDienThoai) SoCuoc , AVG (ThoiGianDonKhach) TBTGDonMK  from T_TAXIOPERATION_KETTHUC ";
                strSQL += " where ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " and ThoiDiemGoi  <= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay);
                strSQL += "   and (xedon is not null) and len(XeDon) > 0  and XeDon <> '999' and XeDon <> '888' and ThoiGianDonKhach>0 ";
                strSQL += "   and ThoiGianDonKhach < 600 and Vung>=0 and Vung <=8 and LEN (MaNhanVienDienThoai)>0 ";
                strSQL += "   group by MaNhanVienDienThoai ";
            }
            else
            {
                strSQL += " select UPPER(MOIKHACH_NhanVien) NVCS, Count(MOIKHACH_NhanVien) SoCuoc , AVG (ThoiGianDonKhach) TBTGDonMK  from T_TAXIOPERATION_KETTHUC ";
                strSQL += " where ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " and ThoiDiemGoi  <= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay);
                strSQL += "   and (xedon is not null) and len(XeDon) > 0  and XeDon <> '999' and XeDon <> '888' and ThoiGianDonKhach>0 ";
                strSQL += "   and ThoiGianDonKhach < 600 and Vung>=0 and Vung <=8 and LEN (MOIKHACH_NhanVien)>0 ";
                strSQL += "   group by MOIKHACH_NhanVien ";
            }
            return this.RunSQL(strSQL, "tblKQNV_TD_TimeDon");
        }

        public DataTable GetGetTongHopKQNV_BanTinGia(object TuNgay, object DenNgay, string NhanVienID)
        {
            string strSQL = "";
            strSQL += " SELECT  T.NVBTin NVBanTin, COUNT(T.NVBTin) SoCuocGoiGiaiQuyet, SUM(T.CuocDaGiaiQuyetDuoc) SoCuocGoiDaGiaiQuyetDuoc ";
            strSQL += " FROM ";
            strSQL += "   (";
            strSQL += "      SELECT KT.BANTINBANGIA_NhanVien NVBTin,";
            strSQL += "             CuocDaGiaiQuyetDuoc = CASE WHEN BANTINBANGIA_IsXuLy = 1   THEN 1 ELSE 0 END ";
            strSQL += "      FROM T_TAXIOPERATION_KETTHUC KT ";
            strSQL += "     WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay);
            strSQL += "            AND KT.Vung>=9 ";
            if (NhanVienID.Length > 0)
                strSQL += " AND KT.BANTINBANGIA_NhanVien= '" + NhanVienID + "'";
            strSQL += "    ) T ";
            strSQL += " GROUP BY T.NVBTin ";
            strSQL += " ORDER BY T.NVBTin ";

            return this.RunSQL(strSQL, "tblKQNV_banTin");
        }
        /// <summary>
        /// Hàm thực hiện  lấy thông ra nhóm
        /// </summary>
        public DataTable GetTongHopKQNV_TheoNhom(DateTime TuNgay, DateTime DenNgay, string NhanVienID)
        {
            string strSQL = "";

            //-- Lam viẹc o vị trí tổng đài
            strSQL += " SELECT  NV				= CASE WHEN TTD.NVTD IS NULL THEN TCS.NVCS ELSE TTD.NVTD END, "; 
	        strSQL += "         CuocGoiDieuNHOM	= ISNULL(TTD. SoCuocLamViecTD,0) + ISNULL (TCS.SoCuocLamViecCS,0), ";
	        strSQL += "         DonDuocNHOM			= ISNULL(TTD. DonDuocTD,0) + ISNULL (TCS.DonDuocCS,0) ";
            strSQL += " FROM ";
	        strSQL += "     (SELECT T.NVTD,  COUNT(T.NVTD) SoCuocLamViecTD, SUM(T.DonDuoc) DonDuocTD ";
	        strSQL += "     FROM ";
		    strSQL += "         (SELECT MaNhanVienTongDai NVTD, ";
			strSQL += "                DonDuoc = CASE ";
			strSQL += " 							             WHEN KT.KieuCuocGoi = 1 ";
			strSQL += " 								              AND ( KT.TrangThaiCuocGoi = 1 OR XeDon='8888') ";
			strSQL += " 								              AND ( KT.XeDon <> '999' ) THEN 1 ";
			strSQL += " 							             ELSE 0 ";
			strSQL += " 			             END ";
		    strSQL += "         FROM  [T_TAXIOPERATION_KETTHUC] KT ";
            strSQL += "         WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) + "  AND KT.KieuCuocGoi = 1  AND KT.Vung<9 AND (MaNhanVienTongDai IS NOT NULL) ";
            if (NhanVienID.Length > 0)
                strSQL += "     AND   KT.MaNhanVienTongDai ='" + NhanVienID + "'";  
            strSQL += "         )T ";
	        strSQL += "     GROUP BY T.NVTD  )TTD  ";
            strSQL += " FULL OUTER JOIN  ";
           // --- Lam viẹc ở vị trí CS

	       strSQL += "      (SELECT T.NVCS,  COUNT(T.NVCS) SoCuocLamViecCS, SUM(T.DonDuoc) DonDuocCS ";
	       strSQL += "      FROM ";
		    strSQL += "         (SELECT [MOIKHACH_NhanVien] NVCS, ";
			strSQL += "                DonDuoc = CASE ";
			strSQL += " 							             WHEN KT.KieuCuocGoi = 1 ";
			strSQL += " 								              AND ( KT.TrangThaiCuocGoi = 1 OR XeDon='8888' ) ";
			strSQL += " 								              AND ( KT.XeDon <> '999' ) THEN 1 ";
			strSQL += " 							             ELSE 0 ";
			strSQL += " 			             END ";
		    strSQL += "         FROM  [T_TAXIOPERATION_KETTHUC] KT ";
            strSQL += "         WHERE KT.ThoiDiemGoi >= " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", TuNgay) + " AND KT.ThoiDiemGoi <=  " + string.Format("'{0:yyyy-MM-dd HH:mm:ss}'", DenNgay) + "  AND KT.KieuCuocGoi = 1  AND KT.Vung<9 AND (MaNhanVienTongDai IS NOT NULL) ";
            if (NhanVienID.Length > 0)
                strSQL += "     AND   KT.MOIKHACH_NhanVien ='" + NhanVienID + "'";
		    strSQL += "         )T ";
	        strSQL += "     GROUP BY T.NVCS ) TCS ";
            strSQL += " ON TTD.NVTD = TCS.NVCS ";

            return this.RunSQL(strSQL, "tblKQNV_banTin");
        }

        #endregion TongHopNVDieuHanh

        /// <summary>
        /// Bao cao hoat dong cua xe bao ra , ve
        /// </summary>
        public DataTable GROUP_BC_5_1_LaiXeBaoRaVe(DateTime tuNgayGio, DateTime denNgayGio, string soHieuXe, string laiXeID, int congTyID)
        {
         
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@TuNgayGio",SqlDbType.DateTime),
                    new SqlParameter ("@DenNgayGio",SqlDbType.DateTime),
                    new SqlParameter ("@SoHieuXe",SqlDbType.VarChar ,16),
                    new SqlParameter ("@LaiXeID",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@CongTyID",SqlDbType.Int) 
               
                };
                parameters[0].Value = tuNgayGio;
                parameters[1].Value = denNgayGio;
                parameters[2].Value = soHieuXe;
                parameters[3].Value = laiXeID;
                parameters[4].Value = congTyID;

                DataSet ds = this.RunProcedure("[GROUP.BC_5_1_LaiXeBaoRaVe]", parameters, "tblRaVe");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable GROUP_BC_5_1_LaiXeBaoRaVeTheoThoiDiem(DateTime thoiDiem, string soHieuXe, string laiXeID, int congTyID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@ThoiDiem",SqlDbType.DateTime), 
                    new SqlParameter ("@SoHieuXe",SqlDbType.VarChar ,16),
                    new SqlParameter ("@LaiXeID",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@CongTyID",SqlDbType.Int) 
               
                };
                parameters[0].Value = thoiDiem; 
                parameters[1].Value = soHieuXe;
                parameters[2].Value = laiXeID;
                parameters[3].Value = congTyID;

                DataSet ds = this.RunProcedure("[GROUP.BC_5_1_LaiXeBaoRaVeTheoThoiDiem]", parameters, "tblRaVe");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// bao cao tinh trang vung dam 7.4
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// author          created date    comment
        /// hangtm          21/6/2011       created
        /// </modified>
        public DataSet  GROUP_BC_7_4TinhTrangVungDam()
        {
            SqlParameter[] parameters = new SqlParameter[] { 
            };
            DataSet ds = this.RunProcedure("[SP_BAOCAO_TINHTRANG_VUNGDAM]", parameters, "TongHop");
            return ds;
        }

        /// <summary>
        /// ham tra ve thong tin vung dam
        /// Vung, Dam,  CSKH1, CSKH2, TinGia,  CoXeNhan,  ChuaCoXeNhan,   KhachHen
        /// phai lay bo sung du lieu Dam.CSKH1,CSKH2, TinGia
        /// Ghep du lieu cuoc goi voi du lieu nguoi dang nhap
        /// </summary>
        public DataTable GROUP_BC_7_4_TinhTrangVungDam()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {  };

                DataSet ds = this.RunProcedure("[GROUP.BC_7_4_TinhTrangVungDam]", parameters, "tblRaVe");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// la ra thong tin nguoi dang dang nhap
        /// Vung, Ten, IsMayTinh
        /// </summary>
        public DataTable GROUP_BC_7_4_TinhTrangVungDamNguoiDangDangNhap()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };

                DataSet ds = this.RunProcedure("[GROUP.BC_7_4_TinhTrangVungDamNguoiDangDangNhap]", parameters, "tblRaVe");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }

        }
        #endregion BAO CAO NEW  (chuyen sang MyDinh)


        public DataTable GROUP_BC_8_3_BaoCaoTHCuocGoiTheoSoDienThoai(DateTime TuNgay, DateTime DenNgay, string Sodienthoai)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@SoDienThoai",SqlDbType.VarChar,36)
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = Sodienthoai;

                DataTable dt = this.RunProcedure("[GROUP.BC_8_3_TongHopLuongCuocGoiTheoSoDienThoai]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GROUP_BC_GPS_BCCuocKhachGPSTheoQuan(DateTime TuNgay, DateTime DenNgay, bool DonDuoc, bool TruotHoan, bool KhongXe)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime),
                    new SqlParameter("@DonDuoc",SqlDbType.Bit),
                    new SqlParameter("@TruotHoan",SqlDbType.Bit),
                    new SqlParameter("@KhongXe",SqlDbType.Bit)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = DonDuoc;
                parameters[3].Value = TruotHoan;
                parameters[4].Value = KhongXe;
                DataTable dt = this.RunProcedure("BC_GPS_BCCKTheoQuan", parameters, "bcDHGPSTheoQuan").Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
        }

        #region Quynh
        /// <summary>
        /// Báo cáo chi tiết khách gọi thường xuyên
        /// </summary>
        public DataTable GROUP_BC_8_2_BaoCaoChiTietCuocGoiDenTheoNgay(DateTime TuNgay, DateTime DenNgay, string Sodienthoai)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@SoDienThoai",SqlDbType.VarChar,36)
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = Sodienthoai;

                DataTable dt = this.RunProcedure("[GROUP.BC_8_2_ChiTietCuocGoiDenTheoNgay]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("GROUP_BC_8_2_BaoCaoChiTietCuocGoiDenTheoNgay: ", ex);
                return null;
            }
        }


        public DataTable GROUP_BC_8_2_BaoCaoTongHopKhachGoiThuongXuyen(DateTime TuNgay, DateTime DenNgay, string Sodienthoai, string LoaiKhachGoi, string CoDinh, int soCuoc)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@SoDienThoai",SqlDbType.VarChar,36),
                    new SqlParameter("@LoaiKhachGoi",SqlDbType.VarChar,1),
                    new SqlParameter("@LoaiSDT",SqlDbType.VarChar,2),
                    new SqlParameter("@SoCuoc",SqlDbType.Int)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = Sodienthoai;
                parameters[3].Value = LoaiKhachGoi;
                parameters[4].Value = CoDinh;
                parameters[5].Value = soCuoc;
                DataTable dt = this.RunProcedure("[GROUP.BC_8_1_TongHopKhachThuongXuyen]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("GROUP_BC_8_2_BaoCaoTongHopKhachGoiThuongXuyen: ", ex);
                return null;
            }
        }


        public DataTable GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999(DateTime TuNgay, DateTime DenNgay, int Vung)
        {
            try
            {


                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuGio",SqlDbType.DateTime),
                    new SqlParameter("@DenGio",SqlDbType.DateTime) ,
                    new SqlParameter("@Vung",SqlDbType.TinyInt)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = Vung;
                DataTable dt = this.RunProcedure("[GROUP.BC_1_6_BaoCaoTongHopThoatCuoc999]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999: ",ex);
                return null;
            }
        }

        public DataTable GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999_V2(DateTime TuNgay, DateTime DenNgay, byte Vung)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuGio",SqlDbType.DateTime),
                    new SqlParameter("@DenGio",SqlDbType.DateTime) ,
                    new SqlParameter("@Vung",SqlDbType.TinyInt)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = Vung;
                DataTable dt = this.RunProcedure("[GROUP.BC_1_6_BaoCaoTongHopThoatCuoc999_V2]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GROUP_BC_1_7_BaoCaoChiTietKhachThoat999(string TuNgay, string DenNgay, string TruongCa, string NhanVien)
        {
            try
            {


                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.VarChar),
                    new SqlParameter("@DenNgay",SqlDbType.VarChar) ,
                    new SqlParameter("@TruongCa",SqlDbType.VarChar),
                    new SqlParameter("@NVMK",SqlDbType.VarChar)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = TruongCa;
                parameters[3].Value = NhanVien;
                DataTable dt = this.RunProcedure("[GROUP.BC_1_7_ChiTietCuocKhach999]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GROUP_BC_1_7_BaoCaoChiTietKhachThoat999_V2(DateTime TuNgay, DateTime DenNgay, string TruongCa, string NhanVien)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@TruongCa",SqlDbType.VarChar),
                    new SqlParameter("@NVMK",SqlDbType.VarChar)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = TruongCa;
                parameters[3].Value = NhanVien;
                DataTable dt = this.RunProcedure("[GROUP.BC_1_7_ChiTietCuocKhach999_V2]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetDanhSach_NguoiDung(string RoleID)
        {
            try
            {


                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@RoleID",SqlDbType.VarChar)                 
                };
                parameters[0].Value = RoleID;
                DataTable dt = this.RunProcedure("[Group.GetDanhSach_NguoiDung]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataTable GROUP_BC_1_8_BaoCaoChiTietKhachDat(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {


                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )                   
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                DataTable dt = this.RunProcedure("[GROUP.BC_1_8_BaoCaoChiTiet_KhachDat]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        public DataTable GROUP_BC_GPS_1_BCCuocKhachGPSTheoNgay(DateTime TuNgay, DateTime DenNgay, string MaNhanVien)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ) ,
                    new SqlParameter("@MaNhanVien",SqlDbType.VarChar,100 )
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = MaNhanVien;
                DataTable dt = this.RunProcedure("GROUP_BC_GPS_1_BCCuocKhachGPSTheoNgay", parameters, "bcDHGPSTheoNgay").Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GROUP_BC_GPS_2_BCCuocKhachGPS_CoCanhBao(DateTime TuNgay, DateTime DenNgay, string Vung, string MaNhanVien, Taxi.Utils.KieuCanhBaoKhiNhapThongTin? kieuCanhBao)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                    new SqlParameter("@MaNhanVien",SqlDbType.VarChar,20 ),
                    new SqlParameter("@Vung",SqlDbType.VarChar,20 ),
                    new SqlParameter("@KieuCanhBao",SqlDbType.VarChar,100 )                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                if (!string.IsNullOrEmpty(MaNhanVien)) parameters[2].Value = MaNhanVien;
                if (!string.IsNullOrEmpty(Vung)) parameters[3].Value = Vung;
                if (kieuCanhBao != null) parameters[4].Value = (int)kieuCanhBao;
                
                DataTable dt = RunProcedure("GROUP_BC_GPS_2_BCCuocKhachGPS_CoCanhBao", parameters, "bcDHGPS_CoCanhBao").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetTongHopKQNV_DienThoai_V3(DateTime TuNgay, DateTime DenNgay, string NhanVienID, int SoGiayGioiHanChuyenTongDai)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime),
                    new SqlParameter("@NhanVienID",SqlDbType.VarChar,20),
                    new SqlParameter("@SoGiayGioiHanChuyenTongDai",SqlDbType.Int)
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                if (!string.IsNullOrEmpty(NhanVienID))
                {
                    parameters[2].Value = NhanVienID;
                }
                parameters[3].Value = SoGiayGioiHanChuyenTongDai;
                DataTable dt = this.RunProcedure("GROUP_BC_THKQDH_DTV", parameters, "tblKQNV_DT").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public DataTable GetBaoCaoLogChuyenVung(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ) 
                };

                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;

                DataTable dt = this.RunProcedure("[GROUP.BC_1_3_BaoCaoCuocChuyenVung]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// lấy chi tiết thông tin vùng chuyên theo id cuộc gọi
        /// </summary>
        /// <param name="idDieuHanh"></param>
        /// <returns></returns>
        public DataTable GetBaoCaoLogChuyenVungChiTietVung(long idDieuHanh)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDDieuHanh",SqlDbType.BigInt) 
                };
                parameters[0].Value = idDieuHanh;
                DataTable dt = this.RunProcedure("[GROUP.BC_1_3_BaoCaoCuocChuyenVungChiTiet]", parameters, "bcDHTheoNgay").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_DanhSachKHThanThiet(DateTime TuNgay, DateTime DenNgay, int LoaiKH)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                    new SqlParameter("@LoaiKH",SqlDbType.TinyInt )
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = LoaiKH;

                DataTable dt = RunProcedure("GROUP_BC_DanhSachKHThanThiet", parameters, "bcDSKH").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_GPS_2_BCXeNhanKhongThuocXeDeCu(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ) 
                    
                    
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;


                DataTable dt = RunProcedure("GROUP_BC_GPS_2_BCXeNhanKhongThuocXeDeCu", parameters, "bcDSKH").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_XeGapSuCo(string SoHieuXe, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar ,5)  ,
                     new SqlParameter("@TuNgay",SqlDbType.DateTime )  ,
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )     
                };

                parameters[0].Value = SoHieuXe;
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;

                return this.RunProcedure("GROUP_BC_KIEMSOAT_LIENLAC_XEGAPSUCO", parameters, "tblXeGapSuCo").Tables[0];


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GROUP_BC_SuCoVeThe(string SoHieuXe, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar ,5),
                     new SqlParameter("@TuNgay",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime )
                };

                parameters[0].Value = SoHieuXe;
                parameters[1].Value = TuNgay;
                parameters[2].Value = DenNgay;

                return RunProcedure("GROUP_BC_KIEMSOAT_LIENLAC_SUCOVETHE", parameters, "tblXeGapSuCo").Tables[0];


            }
            catch (Exception ex)
            {
                return null;
            }
        }


        // THÔNG TIN KHÁCH QUEN - CSKH - TRUNG KIÊN

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <returns></returns>

        public DataTable GetBCNhatKyDieuHanh(string SoHieuXe, DateTime TuNgayGio, DateTime DenNgayGio)
        {
            //[sp_T_TAXIOPERATION_KETTHUC_GetNhatKyDieuHanhXe]
            //    @TuNgayGio datetime, 
            //    @DenNgayGio datetime,
            //    @SoHieuXe varchar(3)
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {                      
                     new SqlParameter("@TuNgayGio",SqlDbType.DateTime),
                     new SqlParameter("@DenNgayGio",SqlDbType.DateTime)  ,
                     new SqlParameter("@SoHieuXe",SqlDbType.VarChar,3 )                          
                };

                parameters[0].Value = TuNgayGio;
                parameters[1].Value = DenNgayGio;
                parameters[2].Value = SoHieuXe;

                return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetNhatKyDieuHanhXe", parameters, "tblHanhTrinhXe").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable BaoCaoKhachHangThanThiet(DateTime tuNgay, DateTime denNgay, int soCuoc)
        {
            if (soCuoc <= 0) soCuoc = 1;

            string sql = "";
            sql += "SELECT KH.MaKH,KH.Name TenKhachHang,KH.[Address] DiaChi,KH.Notes GhiChu, CG.SoDienThoai, CG.SoCuocGoi ";
            sql += "FROM ";
            sql += " ( ";
            sql += "   SELECT [PhoneNumber] SoDienThoai, Count(PhoneNumber) SoCuocGoi FROM  [T_TAXIOPERATION_KETTHUC]  ";
            sql += "   WHERE ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", tuNgay) + "' AND  ThoiDiemGoi<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", denNgay) + "' AND LEN(PhoneNumber)>=8 AND LEN(XeDon)>0 AND KieuKhachHangGoiDen <> 2     ";
            sql += "      GROUP BY PhoneNumber ";
            sql += "      HAVING   Count(PhoneNumber)>= " + soCuoc.ToString();
            sql += "    ) CG ";
            sql += "    LEFT JOIN ";
            sql += "    ( ";
            sql += "       SELECT MaKH,Name,[Address] ,Notes,Phones ";
            sql += "       FROM T_DMKHACHHANG ";
            sql += "    ) KH ";
            sql += "   ON CG. SoDienThoai = KH. Phones ";

            return RunSQL(sql, "tbl");

        }

        /// <summary>
        /// lấy báo cáo khách hàng thân thiết đã có mã.
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="soCuoc"></param>
        /// <returns></returns>
        public DataTable BaoCaoKhachHangThanThietDaCoMa(DateTime tuNgay, DateTime denNgay, int soCuoc)
        {
            if (soCuoc <= 0) soCuoc = 1;

            string sql = "";
            sql += "SELECT KH.MaKH,KH.Name TenKhachHang,KH.[Address] DiaChi,KH.Notes GhiChu, CG.SoDienThoai, CG.SoCuocGoi ";
            sql += "FROM ";


            sql += "  ( ";
            sql += "       SELECT MaKH,Name,[Address] ,Notes,Phones ";
            sql += "       FROM T_DMKHACHHANG ";
            sql += "   ) KH ";
            sql += "   LEFT JOIN ";
            sql += " ( ";
            sql += "   SELECT [PhoneNumber] SoDienThoai, Count(PhoneNumber) SoCuocGoi FROM  [T_TAXIOPERATION_KETTHUC]  ";
            sql += "   WHERE ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", tuNgay) + "' AND  ThoiDiemGoi<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", denNgay) + "' AND LEN(PhoneNumber)>=8 AND LEN(XeDon)>0 AND KieuKhachHangGoiDen <> 2     ";
            sql += "      GROUP BY PhoneNumber ";
            sql += "      HAVING   Count(PhoneNumber)>= " + soCuoc.ToString();
            sql += "    ) CG ";


            sql += "   ON CG. SoDienThoai = KH. Phones ";



            return RunSQL(sql, "tbl");

        }


        public DataTable TimKhachHangThanThiet(DateTime TuNgay, DateTime DenNgay, int SoCuoc, bool IsCoDinh)
        {
            string strSQL = "";
            if (IsCoDinh)
            {
                strSQL += "SELECT [PhoneNumber] SoDienThoai, Count(PhoneNumber) SoCuocGoi FROM  [T_TAXIOPERATION_KETTHUC] ";
                strSQL += " WHERE ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay) + "' AND  ThoiDiemGoi<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay) + "' AND LEN(XeDon)>0 AND KieuKhachHangGoiDen <> 2 AND (LEN(PhoneNumber)=7 OR SUBSTRING(PhoneNumber,1,3)='056')";
                strSQL += " GROUP BY PhoneNumber";
                strSQL += " HAVING   Count(PhoneNumber)>=" + SoCuoc.ToString();
            }
            else
            {
                strSQL += "SELECT [PhoneNumber] SoDienThoai, Count(PhoneNumber) SoCuocGoi FROM  [T_TAXIOPERATION_KETTHUC] ";
                strSQL += " WHERE ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay) + "' AND  ThoiDiemGoi<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay) + "' AND LEN(XeDon)>0 AND KieuKhachHangGoiDen <> 2 AND (LEN(PhoneNumber)>=9 AND ( SUBSTRING(PhoneNumber,1,1)='9' OR SUBSTRING(PhoneNumber,1,2)='09'  OR SUBSTRING(PhoneNumber,1,1)='1' OR SUBSTRING(PhoneNumber,1,2)='01'))";
                strSQL += " GROUP BY PhoneNumber";
                strSQL += " HAVING   Count(PhoneNumber)>=" + SoCuoc.ToString();
            }
            return RunSQL(strSQL, "tbl");
        }
        public DataTable TimKhachHangThanThietBySoDienThoai(DateTime TuNgay, DateTime DenNgay, string SoDienThoai)
        {
            string strSQL = "";

            strSQL += "SELECT ThoiDiemGoi, DiaChiDonKhach FROM  [T_TAXIOPERATION_KETTHUC] ";
            strSQL += " WHERE ThoiDiemGoi >='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay) + "' AND  ThoiDiemGoi<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay) + "' AND LEN(XeDon)>0 AND KieuKhachHangGoiDen <> 2 AND ( PhoneNumber ='" + SoDienThoai + "')";

            return RunSQL(strSQL, "tbl");
        }

        public DataTable BaoCaoKhachHangThanThietTheoThang(DateTime tuNgay, DateTime denNgay)
        {
            string strSQL = "";

            strSQL += " SELECT KH.MaKH MaKhachHang,KH.Name TenKhachHang,KH.[Address] DiaChi,KH.Notes GhiChu,KH.Phones DienThoais,  ";
            strSQL += "        PV.[1] Thang01 , PV.[2] Thang02,PV.[3] Thang03,PV.[4] Thang04,PV.[5] Thang05,PV.[6] Thang06,PV.[7] Thang07, ";
            strSQL += "        PV.[8] Thang08,PV.[9] Thang09,PV.[10] Thang10,PV.[11] Thang11,PV.[12]  Thang12, ";
            strSQL += "        (PV.[1]  + PV.[2] + PV.[3] + PV.[4] + PV.[5] + PV.[6] + PV.[7] +PV.[8] + PV.[9] + PV.[10] + PV.[11] + PV.[12]  ) TongSoChuyen ";
            strSQL += " FROM ";
            strSQL += "(   ";
            strSQL += "    SELECT MaKH,Name,[Address] ,Notes,Phones   ";
            strSQL += "    FROM T_DMKHACHHANG   ";
            strSQL += ") KH ";
            strSQL += "INNER JOIN ";
            strSQL += "(	 ";
            strSQL += "     SELECT pivotS.* ";
            strSQL += "     FROM  ";
            strSQL += "     ( ";
            strSQL += "         SELECT [PhoneNumber] AS SoDienThoai, MONTH(ThoiDiemGoi)as Thang  ";
            strSQL += "         FROM  [T_TAXIOPERATION_KETTHUC]    ";
            strSQL += "         WHERE ThoiDiemGoi >= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", tuNgay) + "' AND  ThoiDiemGoi<  '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", denNgay) + "'  ";
            strSQL += "    ) AS m ";
            strSQL += "    PIVOT ";
            strSQL += "    ( ";
            strSQL += "        COUNT(Thang) ";
            strSQL += "        FOR Thang IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ";
            strSQL += "    ) AS pivotS  ";
            strSQL += ") PV ";
            strSQL += " ON KH.Phones = PV.SoDienThoai ";
            strSQL += " ORDER BY CONVERT(INT, KH.MaKH) ";
            return RunSQL(strSQL, "tbl");
        }
        public DataTable BaoCaoKhachHangThanThietTheoThang_V2(DateTime tuNgay, DateTime denNgay, string SoDienThoai, string TenKH, string DiaChi,int TypeKH =0 )
        {
            string strSQL = "";
            string strTypeKH = string.Empty;
            if (TypeKH == 1) //Moi gioi
                strTypeKH = "AND KieuKhachHangGoiDen = 2";
            else if (TypeKH == 2) //G5   
                strTypeKH = "And G5_Type=3";
            else strTypeKH = string.Empty;

            strSQL += " SELECT KH.MaKH MaKhachHang,KH.Name TenKhachHang,KH.[Address] DiaChi,KH.Notes GhiChu,KH.Phones DienThoais,  ";
            strSQL += "        PV.[1] Thang01 , PV.[2] Thang02,PV.[3] Thang03,PV.[4] Thang04,PV.[5] Thang05,PV.[6] Thang06,PV.[7] Thang07, ";
            strSQL += "        PV.[8] Thang08,PV.[9] Thang09,PV.[10] Thang10,PV.[11] Thang11,PV.[12]  Thang12, ";
            strSQL += "        (PV.[1]  + PV.[2] + PV.[3] + PV.[4] + PV.[5] + PV.[6] + PV.[7] +PV.[8] + PV.[9] + PV.[10] + PV.[11] + PV.[12]  ) TongSoChuyen ";
            strSQL += " FROM ";
            strSQL += "(   ";
            strSQL += "    SELECT MaKH,Name,[Address] ,Notes,Phones   ";
            strSQL += "    FROM T_DMKHACHHANG   ";
            strSQL += ") KH ";
            strSQL += "INNER JOIN ";
            strSQL += "(	 ";
            strSQL += "     SELECT pivotS.* ";
            strSQL += "     FROM  ";
            strSQL += "     ( ";
            strSQL += "         SELECT [PhoneNumber] AS SoDienThoai, MONTH(ThoiDiemGoi)as Thang  ";
            strSQL += "         FROM  [T_TAXIOPERATION_KETTHUC]    ";
            strSQL += "         WHERE ThoiDiemGoi >= '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", tuNgay) + "' AND  ThoiDiemGoi<  '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", denNgay) + "'  " + strTypeKH;
            strSQL += "    ) AS m ";
            strSQL += "    PIVOT ";
            strSQL += "    ( ";
            strSQL += "        COUNT(Thang) ";
            strSQL += "        FOR Thang IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ";
            strSQL += "    ) AS pivotS  ";
            strSQL += ") PV ";
            strSQL += " ON KH.Phones = PV.SoDienThoai ";
            strSQL += "WHERE (1=1)";
            if (!string.IsNullOrEmpty(SoDienThoai))
            {
                 strSQL += " AND KH.Phones LIKE '%" + SoDienThoai + "%'";
            }
            if (!string.IsNullOrEmpty(TenKH))
            {
                strSQL += " AND KH.Name LIKE '%"+TenKH +"%'";
            }
            if (!string.IsNullOrEmpty(DiaChi))
            {
                strSQL += " AND KH.[Address] LIKE '%" + DiaChi + "%'";
            }
            strSQL += " ORDER BY CONVERT(INT, KH.MaKH) ";
            return RunSQL(strSQL, "tbl");
        }

        public DataTable BaoCaoKhachHangThanThietTheoThang_V3(DateTime tuNgay, DateTime denNgay, string soDienThoai, string tenKH, string diaChi,int typeKH =0 )
        {
            return ExeStoreData("sp_BaoCaoKhachHangThanThietTheoThang_V3", tuNgay,denNgay,soDienThoai,tenKH,diaChi,typeKH);
        }
        #region FastTaxi
        public DataTable FastTaxi_BC_BaoCaoTongHopCuocGoiDenTheoGio(DateTime start,DateTime end)
        {
            return ExeStoreData("FT_BC_1_1_TongHopCuocGoiDenTheoGio", start, end,string.Empty);
        }
        #endregion

        
    }
}
