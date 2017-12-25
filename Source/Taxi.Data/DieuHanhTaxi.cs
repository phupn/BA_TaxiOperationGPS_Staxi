using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data
{
    public class DieuHanhTaxi : DBObject
    {

        #region Methods        
        /// <summary>
        /// Lay tat cac cac cuoc goi trong bang T_TAXIOPERATION 
        /// voi dieu kien SQLCondition dua vao
        /// </summary>
        /// <param name="SQLCondition"></param>
        /// <returns></returns>
        public DataTable GetAll_DienThoai(string SQLCondition)
        {
            try{
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SQLCondition",SqlDbType.NVarChar ,2000)
                };
            parameters[0].Value = SQLCondition ;            

            return this.RunProcedure("sp_T_TAXIOPERATION_GetAll", parameters, "tblDienThoaiAll").Tables[0];
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("GetAll_DienThoai: ", ex);
                return null;
            }            
        }
        public DataTable FT_GetAll_DienThoai(string SQLCondition)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SQLCondition",SqlDbType.NVarChar ,2000)
                };
                parameters[0].Value = SQLCondition;

                return this.RunProcedure("sp_dh_FT_T_TAXIOPERATION_GetAll", parameters, "tblDienThoaiAll").Tables[0];
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("FT_GetAll_DienThoai: ", ex);
                return null;
            }
        } 
       
        public DataTable Get_CuocGoi_KetThuc(string NRecords, string SQLCondition)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NRecords",SqlDbType.VarChar ,10),
                    new SqlParameter("@SQLCondition",SqlDbType.NVarChar ,2000)
                };
                parameters[0].Value = NRecords;
                parameters[1].Value = SQLCondition;

                return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetAll", parameters, "tblDienThoaiKetThucAll").Tables[0];
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Get_CuocGoi_KetThuc: ",ex);
                return null;
            }         
        }
        public DataTable FT_Get_CuocGoi_KetThuc(string NRecords, string SQLCondition)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NRecords",SqlDbType.VarChar ,10),
                    new SqlParameter("@SQLCondition",SqlDbType.NVarChar ,2000)
                };
                parameters[0].Value = NRecords;
                parameters[1].Value = SQLCondition;

                return this.RunProcedure("FastTaxi_T_TAXIOPERATION_KETTHUC_GetAll", parameters, "tblDienThoaiKetThucAll").Tables[0];
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("FT_Get_CuocGoi_KetThuc: ", ex);
                return null;
            }
        }
        /// <summary>
        /// lấy số dòng lầy ra của cuộc gọi đã kết thúc
        /// </summary>
        /// <param name="SoDongLayRa"></param>
        /// <returns></returns>
         public DataTable Get_CuocGoi_KetThucBySoDong(int SoDongLayRa)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoCuocGoi",SqlDbType.Int) 
                };
                parameters[0].Value = SoDongLayRa;
                return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetAll_BySoCuocGoi", parameters, "tblDienThoaiKetThucAll").Tables[0];
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Get_CuocGoi_KetThucBySoDong: ",ex);
                return null;
            }         
        }
 

        /// <summary>
        /// Chen cuoc goi lan dau tien bat duoc
        /// - Line
        /// - PhoneNumber
        /// - DateTime (2008-09-27 15:50:22)
        /// - TrangThaiCuocGoi.CuocGoiDen
        /// - TrangThaiLenh.KhongTruyenDi
        /// @Line varchar(2),
	    ///@PhoneNumber varchar(11),
	    ///@ThoiDiemGoi datetime,
	    ///@DiaChiDonKhach nvarchar(255),
	    ///@KieuKhachHangGoiDen char(1),
	    ///@TrangThaiCuocGoi char(1),
	    ///@TrangThaiLenh char(1),
	    ///@ID_DieuHanh bigint output
        /// </summary>
        /// <returns></returns>        
        public long Insert_DienThoai_LanDau(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi  TrangThaiCuocGoi, TrangThaiLenhTaxi  TrangThaiLenh)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,2 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt) 
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                //parameters[2].Value = null;
                parameters[3].Value = DiaChiDonKhach;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)KieuKhachHangGoiDen).ToString();
                parameters[5].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                parameters[7].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Insert_CuocGoiLanDau", parameters, rowAffected);
                return (long) parameters[7].Value;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Insert_DienThoai_LanDau: ", ex);
                return 0;
            }
        }

        public long Insert_DienThoai_LanDau_ToaDo(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh, float KinhDo, float ViDo,string MaDoiTac)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,5 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt), 
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float),
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float),
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10)
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                //parameters[2].Value = null;
                parameters[3].Value = DiaChiDonKhach;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)KieuKhachHangGoiDen).ToString();
                parameters[5].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                parameters[7].Direction = ParameterDirection.Output;
                parameters[8].Value = KinhDo;
                parameters[9].Value = ViDo;
                parameters[10].Value = MaDoiTac;

                rowAffected = this.RunProcedure("V3_sp_T_TAXIOPERATION_Insert_CuocGoiLanDau_ToaDo_MaDoiTac", parameters, rowAffected);
                return (long)parameters[7].Value;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Insert_DienThoai_LanDau_ToaDo: ",ex);
                return 0;
            }
        }

        public long Insert_DienThoai_LanDau_ToaDo_FastTaxi(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh, float KinhDo, float ViDo, string MaDoiTac)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,2 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt), 
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float),
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float),
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10)
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                //parameters[2].Value = null;
                parameters[3].Value = DiaChiDonKhach;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)KieuKhachHangGoiDen).ToString();
                parameters[5].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                parameters[7].Direction = ParameterDirection.Output;
                parameters[8].Value = KinhDo;
                parameters[9].Value = ViDo;
                parameters[10].Value = MaDoiTac;

                rowAffected = this.RunProcedure("FT_V3_sp_T_TAXIOPERATION_Insert_CuocGoiLanDau_ToaDo_MaDoiTac_FastTaxiTest", parameters, rowAffected);
                return (long)parameters[7].Value;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Insert_DienThoai_LanDau_ToaDo_FastTaxi: ",ex);
                return 0;
            }
        }
        public long Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh, float KinhDo, float ViDo, string MaDoiTac)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,5 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt), 
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float),
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float),
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10)
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                //parameters[2].Value = null;
                parameters[3].Value = DiaChiDonKhach;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)KieuKhachHangGoiDen).ToString();
                parameters[5].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                parameters[7].Direction = ParameterDirection.Output;
                parameters[8].Value = KinhDo;
                parameters[9].Value = ViDo;
                parameters[10].Value = MaDoiTac;

                rowAffected = this.RunProcedure("G5_DienThoai_spT_TAXIOPERATION_Insert_CuocGoiLanDau_ToaDo_MaDoiTac_TestCuocGoiLai", parameters, rowAffected);
                return (long)parameters[7].Value;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai: ",ex);
                return 0;
            }
        }
        //@ID bigint,	
        //@DiaChiDonKhach nvarchar(255),
        //@GoiTaxi char(1),
        //@GoiLai char(1),
        //@GoiKhieuNai char(1),
        //@ThongTinKhac char(1),
        //@LoaiXe nvarchar(7),
        //@SoLuong int,
        //@ChonTaxi4Cho char(1),
        //@ChonTaxi7Cho char(1),
        //@SanBay_DuongDai char(1),
        //@Vung int,
        //@LenhDienThoai nvarchar(255),
        //@MaNhanVienDienThoai char(20),
        //@GhiChu nvarchar(255),
        //@TrangThaiCuocGoi char(1),
        //@TrangThaiLenh char(1)
        /// <summary>
        /// Du lieu dien thoai goi lan dau
        /// </summary>
        public bool Update_DienThoai(long IDDieuHanh, string DiaChiDonKhach, int ThoiDiemChuyenTongDai, bool GoiTaxi, bool GoiLai,
                        bool GoiKhieuNai, bool ThongTinKhac, string LoaiXe, int SoLuong, string  SanBay_DuongDai, int Vung,
                        string LenhDienThoai, string GhiChu, string MaNhanVienDienThoai, TrangThaiLenhTaxi TrangThaiLenh, string CuocGoiLaiIDs,KieuCuocGoi kieuCuocGoi)
        {
            try
            {
                
                if ( IDDieuHanh <= 0) return false;

                TrangThaiLenhTaxi t = TrangThaiLenh ;
                if (TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                    t = TrangThaiLenhTaxi.DienThoai;
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),                    
                    new SqlParameter("@GoiTaxi",SqlDbType.Char,1  ),
                    new SqlParameter("@GoiLai",SqlDbType.Char ,1 ),                   
                    new SqlParameter("@ThongTinKhac",SqlDbType.Char ,1 ),  //5                                     
                    new SqlParameter("@LoaiXe",SqlDbType.NVarChar,7  ),
                    new SqlParameter("@SoLuong",SqlDbType.Int  ),
                    new SqlParameter("@SanBay_DuongDai",SqlDbType.Char,1 ),
                    new SqlParameter("@Vung",SqlDbType.Int  ),  
                    new SqlParameter("@LenhDienThoai",SqlDbType.NVarChar ,255 ),//10
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar  ,50 ),
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar ,255 ),   
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char ,1),
                    new SqlParameter("@CuocGoiLaiIDs",SqlDbType.VarChar ,255) ,
                    new SqlParameter("@ThoiDiemChuyenTongDai",SqlDbType.Int ),
                    new SqlParameter("@GoiKhieuNai",SqlDbType.Char,1 )   ,
                    new SqlParameter("@KieuCuocGoi",SqlDbType.TinyInt )
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = DiaChiDonKhach;
                parameters[2].Value = GoiTaxi == true ? "1" : "0";
                parameters[3].Value = GoiLai == true ? "1" : "0";
                
                parameters[4].Value = ThongTinKhac == true ? "1" : "0";
                parameters[5].Value = LoaiXe;
                parameters[6].Value = SoLuong;
                parameters[7].Value = SanBay_DuongDai;
                parameters[8].Value = Vung;
                parameters[9].Value = LenhDienThoai;
                parameters[10].Value = MaNhanVienDienThoai;
                parameters[11].Value = GhiChu;
                parameters[12].Value = ((int)(TrangThaiLenhTaxi)t).ToString();
                parameters[13].Value = CuocGoiLaiIDs;
                parameters[14].Value = ThoiDiemChuyenTongDai;
                parameters[15].Value = GoiKhieuNai == true ? "1" : "0";
                parameters[16].Value = ((byte)(KieuCuocGoi)kieuCuocGoi);
                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_DienThoai_Update", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Update_DienThoai: ",ex);
                return false;
            }

        }



        //@LenhTongDai nvarchar(255),
        //@MaNhanVienTongDai char(20),
        //@XeNhan char(25),
        //@XeDon char(25),
        //@DiaChiTraKhach nvarchar(255),
        //@GhiChu nvarchar(255),
        //@TrangThaiLenh char(1)
        public bool Update_BoDam(long IDDieuHanh, string LenhTongDai, string MaNhanVienTongDai, string XeNhan,
           string XeDon, string GhiChu, TrangThaiLenhTaxi TrangThaiLenh,int ThoiGianDieuXe, int ThoiGianDonKhach, TrangThaiCuocGoiTaxi TrangThaiCGoiTaxi)
        {
            try
            {
                TrangThaiLenhTaxi t = TrangThaiLenh;
                if (TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                    t = TrangThaiLenhTaxi.BoDam;

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@LenhTongDai",SqlDbType.NVarChar, 255 ),                    
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar ,50 ),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar  ,100 ),
                    new SqlParameter("@XeDon",SqlDbType.VarChar  ,100 ),
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar  ,255 ),
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar,255  ),                    
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char ,1 ),
                    new SqlParameter("@ThoiGianDieuXe",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDonKhach",SqlDbType.Int),
                    new SqlParameter("@TrangThaiCuocGoiTaxi",SqlDbType.TinyInt)  //TrangThaiCuocGoiTaxi (trangthaicuocgoi)
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = LenhTongDai;
                parameters[2].Value = MaNhanVienTongDai;
                parameters[3].Value = XeNhan;
                parameters[4].Value = XeDon;
                parameters[5].Value = "";
                parameters[6].Value = GhiChu;
                parameters[7].Value = ((int)(TrangThaiLenhTaxi)t).ToString();
                parameters[8].Value = ThoiGianDieuXe ;
                parameters[9].Value = ThoiGianDonKhach;
                parameters[10].Value = ((byte)(TrangThaiCuocGoiTaxi)TrangThaiCGoiTaxi);

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_BoDam_Update", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Update_BoDam: ",ex);
                return false;
            }
        }


        /// <summary>
        /// Cap nhat so luong chuong do, tinh tu thoi gian may goi toi thoi gian den thoi gian bat may
        /// </summary>
        public bool Update_SoLuongChuongDo(long IDDieuHanh, int SoLuotChuongDo)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@SoLuotDoChuong",SqlDbType.Int  ),                                                        
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = SoLuotChuongDo;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_SoLuongChuongDo", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Update_SoLuongChuongDo: ",ex);
                return false;
            }
        }

        /// <summary>
        /// Cap nhat Thoi gian dieu xe
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <param name="ThoiGianDieuXe"></param>
        /// <returns></returns>
        public bool Update_ThoiGianDieuXe(long IDDieuHanh, int ThoiGianDieuXe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@ThoiGianDieuXe",SqlDbType.Int  ),                                                        
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = ThoiGianDieuXe;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_ThoiGianDieuXe", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Cap nhat thoi gian don khach
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <param name="ThoiGianDonKhach"></param>
        /// <returns></returns>
        public bool Update_ThoiGianDonKhach(long IDDieuHanh, int ThoiGianDonKhach)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@ThoiGianDonKhach",SqlDbType.Int  ),                                                        
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = ThoiGianDonKhach;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_ThoiGianDonKhach", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Cap nhat tong thoi dam thoai
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <param name="ThoiGianDonKhach"></param>
        /// <returns></returns>
        public bool Update_TongThoiGianDamThoai(long IDDieuHanh, int TongThoiGianDamThoai)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@TongThoiGianDamThoai",SqlDbType.Int  ),                                                        
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = TongThoiGianDamThoai;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_TongThoiGianDamThoai", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion Methods

        #region OlderMethods

        public DataTable GetDieuHanhID_DieuHanhKetThuc(string Line, string PhoneNumber, DateTime ThoiDiemGoi)
        {

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.Char,7) ,                   
                    new SqlParameter("@PhoneNumber",SqlDbType.Char,11),
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime)                    
                };
            parameters[0].Value = Line;
            parameters[1].Value = PhoneNumber;
            parameters[2].Value = ThoiDiemGoi;

            return this.RunProcedure("sp_Get_ID_DIEUHANH_T_TAXIOPERATION_KETHUC", parameters, "tblUser").Tables[0];

        }

        public DataTable GetDieuHanhID(string Line, string PhoneNumber, DateTime ThoiDiemGoi)
        {

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.Char,7) ,                   
                    new SqlParameter("@PhoneNumber",SqlDbType.Char,11),
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime)                    
                };
            parameters[0].Value = Line;
            parameters[1].Value = PhoneNumber;
            parameters[2].Value = ThoiDiemGoi;

            return this.RunProcedure("sp_Get_ID_DIEUHANH_T_TAXIOPERATION", parameters, "tblUser").Tables[0];

        }
        // lay du lieu moi nhat gui ve bo dao
        public DataTable GetBoDam()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };
                return this.RunProcedure("sp_Get_BODAM_T_TAXIOPERATION", parameters, "tblUser").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// Khi nhan dien thoi lan dau, thong tin se duoc cap nhat xuoong, truong TrangThaiLenh de la 1
        /// Khi ma dienthoai vien chon Taxi thi moi chuyen trang thani san la2 (chia se sang ca tong dai)
        /// </summary>
        /// <param name="Line"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="ThoiDiemGoi"></param>
        /// <param name="ThoiDiemKetThucGoi"></param>
        /// <param name="DiaChiGoi"></param>
        /// <param name="DiaChiDi"></param>
        /// <param name="GoiTaxi"></param>
        /// <param name="GoiDichVu"></param>
        /// <param name="ThongTinKhac"></param>
        /// <param name="GoiLai"></param>
        /// <param name="MaVung"></param>
        /// <param name="ChonTaxi4Cho"></param>
        /// <param name="ChonTaxi7Cho"></param>
        /// <param name="SanBay_DuongDai"></param>
        /// <param name="LenhTrucDienThoaiID"></param>
        /// <param name="GhiChuChoDienThoai"></param>
        /// <param name="MaNhanVienDienThoai"></param>
        /// <param name="TrangThaiLenh"></param>
        /// <returns></returns>
        public bool Insert_TrucDienThoai_LanDau(string Line, string PhoneNumber, DateTime ThoiDiemGoi,
                    DateTime ThoiDiemKetThucGoi, string DiaChiGoi, string DiaChiDi, int GoiTaxi, bool GoiKhieuNai, bool ThongTinKhac, bool GoiLai,
                    int MaVung, int ChonTaxi4Cho, int ChonTaxi7Cho, bool SanBay_DuongDai, string LenhTrucDienThoaiID, string GhiChuChoDienThoai,
                    string MaNhanVienDienThoai, TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.Char,7), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.Char,11),
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),           
                    new SqlParameter("@ThoiDiemKetThucGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiGoi",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@DiaChiDi",SqlDbType.NVarChar, 255 ),//5
                    new SqlParameter("@GoiTaxi",SqlDbType.Int  ),
                    new SqlParameter("@GoiDichVu",SqlDbType.Char ,1 ),
                    new SqlParameter("@ThongTinKhac",SqlDbType.Char ,1 ),
                    new SqlParameter("@GoiLai",SqlDbType.Char ,1 ),
                    new SqlParameter("@Vung",SqlDbType.Int  ),  //10
                    new SqlParameter("@ChonTaxi4Cho",SqlDbType.Int  ),
                    new SqlParameter("@ChonTaxi7Cho",SqlDbType.Int  ),
                    new SqlParameter("@SanBay_DuongDai",SqlDbType.Char,1 ),
                    new SqlParameter("@LenhTrucDienThoaiID",SqlDbType.Char,2 ),
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.Char ,5 ),//15
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar ,255 ),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char ,1 )                    
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                if (ThoiDiemGoi == DateTime.MinValue)
                {
                    parameters[2].IsNullable = true;
                    parameters[2].Value = DBNull.Value;
                }
                else
                {
                    parameters[2].Value = ThoiDiemGoi;
                }
                if (ThoiDiemKetThucGoi == DateTime.MinValue)
                {
                    parameters[3].IsNullable = true;
                    parameters[3].Value = DBNull.Value;
                }
                else
                {
                    parameters[3].Value = ThoiDiemKetThucGoi;
                }


                parameters[4].Value = DiaChiGoi;
                parameters[5].Value = DiaChiDi;
                parameters[6].Value = GoiTaxi;
                parameters[7].Value = GoiKhieuNai == true ? "1" : "0";
                parameters[8].Value = ThongTinKhac == true ? "1" : "0";
                parameters[9].Value = GoiLai == true ? "1" : "0";
                parameters[10].Value = MaVung;
                parameters[11].Value = ChonTaxi4Cho;
                parameters[12].Value = ChonTaxi7Cho;
                parameters[13].Value = SanBay_DuongDai == true ? "1" : "0";
                parameters[14].Value = LenhTrucDienThoaiID;
                parameters[15].Value = MaNhanVienDienThoai;
                parameters[16].Value = GhiChuChoDienThoai;
                parameters[17].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();

                rowAffected = this.RunProcedure("sp_Insert_T_TAXIOPERATION", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Update trangthailenh thay dhoi trang thai lenh dieu hanh
        /// </summary>
        /// <param name="ID_DieuHanh"></param>
        /// <param name="TrangThaiLenh"></param>
        /// <returns></returns>
        public bool Update_TrangThaiLenh(long ID_DieuHanh, string TrangThaiLenh)
        {
            try
            {

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ),                   
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char ,1 )                    
                };
                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = TrangThaiLenh;

                rowAffected = this.RunProcedure("sp_UPDATE_T_TAXIOPERATION_TrangThaiLenh", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }

        }


        /// <summary>
        /// Cap nhat them thong tin cho nhan vien tong dai
        /// </summary>
        /// <param name="ID_DieuHanh"></param>
        /// <param name="LenhTrucTongDaiID"></param>
        /// <param name="CuocGoiKhongThanhCong"></param>
        /// <param name="MaNhanVienTongDai"></param>
        /// <param name="NhungTaxiCoTheChay"></param>
        /// <param name="TaxiChay"></param>
        /// <param name="DiaChiTraKhach"></param>
        /// <param name="GhiChuChoTongDai"></param>
        /// <returns></returns>
        public bool Update_ThongTinTongDai(long ID_DieuHanh, int LenhTrucTongDaiID, string CuocGoiKhongThanhCong, string MaNhanVienTongDai,
                    string NhungTaxiCoTheChay, string TaxiChay, string DiaChiTraKhach, string GhiChuChoTongDai)
        {

            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ),                   
                    new SqlParameter("@LenhTrucTongDaiID",SqlDbType.Int  )  ,    
                    new SqlParameter("@CuocGoiKhongThanhCong",SqlDbType.Char , 2)  ,
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.Char ,5 )  ,
                    new SqlParameter("@NhungTaxiCoTheChay",SqlDbType.Char , 25)  ,
                    new SqlParameter("@TaxiChay",SqlDbType.Char , 25)  ,
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar , 255)  ,
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar ,255)  
                   
                };

                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = LenhTrucTongDaiID;
                parameters[2].Value = CuocGoiKhongThanhCong;
                parameters[3].Value = MaNhanVienTongDai;
                parameters[4].Value = NhungTaxiCoTheChay;
                parameters[5].Value = TaxiChay;
                parameters[6].Value = DiaChiTraKhach;
                parameters[7].Value = GhiChuChoTongDai;

                rowAffected = this.RunProcedure("sp_UPDATE_T_TAXIOPERATION_TONGDAI", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        //@ID BIGINT,
        //@DiaChiDi nvarchar(255),
        //@GoiTaxi int,
        //@GoiLai char(1),
        //@GoiKhieuNai char(1),
        //@ThongTinKhac char(1),
        //@ChonTaxi4Cho int,
        //@ChonTaxi7Cho int,
        //@SanBay_DuongDai char(1),
        //@Vung int,
        //@LenhTrucDienThoaiID char(2),
        //@LichSuLenhDienThoai char(255),
        //@GhiChuChoDienThoai nvarchar(255),
        //@TrangThaiLenh char(1)
        /// <summary>
        /// Update to DB trang thai Chat cua dien thoai
        /// </summary>

        public bool UpdateChatDienThoai(long ID_DIEUHANH, string DiaChiGoi, string DiaChiDi, int GoiTaxi, bool GoiLai, bool GoiKhieuNai, bool ThongTinKhac,
                     int ChonTaxi4Cho, int ChonTaxi7Cho, bool SanBay_DuongDai, int MaVung, string LenhTrucDienThoaiID, string LichSuLenhDienThoai, string GhiChuChoDienThoai,
                    TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@DiaChiGoi",SqlDbType.NVarChar, 255 ),//5
                    new SqlParameter("@DiaChiDi",SqlDbType.NVarChar, 255 ),//5
                    new SqlParameter("@GoiTaxi",SqlDbType.Int  ),
                     new SqlParameter("@GoiLai",SqlDbType.Char ,1 ),
                    new SqlParameter("@GoiKhieuNai",SqlDbType.Char ,1 ),
                    new SqlParameter("@ThongTinKhac",SqlDbType.Char ,1 ),                                       
                    new SqlParameter("@ChonTaxi4Cho",SqlDbType.Int  ),
                    new SqlParameter("@ChonTaxi7Cho",SqlDbType.Int  ),
                    new SqlParameter("@SanBay_DuongDai",SqlDbType.Char,1 ),
                    new SqlParameter("@Vung",SqlDbType.Int  ),  //10
                    new SqlParameter("@LenhTrucDienThoaiID",SqlDbType.Char,2 ),
                    new SqlParameter("@LichSuLenhDienThoai",SqlDbType.Char ,255 ),//15
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar ,255 ),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char ,1 )                    
                };
                parameters[0].Value = ID_DIEUHANH;
                parameters[1].Value = DiaChiGoi;
                parameters[2].Value = DiaChiDi;
                parameters[3].Value = GoiTaxi;
                parameters[4].Value = GoiLai == true ? "1" : "0";
                parameters[5].Value = GoiKhieuNai == true ? "1" : "0";
                parameters[6].Value = ThongTinKhac == true ? "1" : "0";
                parameters[7].Value = ChonTaxi4Cho;
                parameters[8].Value = ChonTaxi7Cho;
                parameters[9].Value = SanBay_DuongDai == true ? "1" : "0";
                parameters[10].Value = MaVung;
                parameters[11].Value = LenhTrucDienThoaiID;
                parameters[12].Value = LichSuLenhDienThoai == null ? string.Empty : LichSuLenhDienThoai.ToString();
                parameters[13].Value = GhiChuChoDienThoai;
                parameters[14].Value = ((int)TrangThaiLenh).ToString();

                rowAffected = this.RunProcedure("sp_UpdateChatDienThoai_T_TAXIOPERATION", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }


        }
        /// <summary>
        /// Cap nhat lai thong tin cua cuoc goi ket thuc can sua chua
        /// </summary>
        /// <param name="ID_DIEUHANH"></param>
        /// <param name="DiaChiGoi"></param>
        /// <param name="DiaChiDi"></param>
        /// <param name="GoiTaxi"></param>
        /// <param name="GoiLai"></param>
        /// <param name="GoiKhieuNai"></param>
        /// <param name="ThongTinKhac"></param>
        /// <param name="ChonTaxi4Cho"></param>
        /// <param name="ChonTaxi7Cho"></param>
        /// <param name="SanBay_DuongDai"></param>
        /// <param name="MaVung"></param>
        /// <param name="LenhTrucDienThoaiID"></param>
        /// <param name="LichSuLenhDienThoai"></param>
        /// <param name="GhiChuChoDienThoai"></param>
        /// <param name="TrangThaiLenh"></param>
        /// <returns></returns>
        public bool UpdateChatDienThoai_DieuHanhKetThuc(long ID_DIEUHANH, string DiaChiGoi, string DiaChiDi, int GoiTaxi, bool GoiLai, bool GoiKhieuNai, bool ThongTinKhac,
                    int ChonTaxi4Cho, int ChonTaxi7Cho, bool SanBay_DuongDai, int MaVung, string LenhTrucDienThoaiID, string LichSuLenhDienThoai, string GhiChuChoDienThoai,
                   TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@DiaChiGoi",SqlDbType.NVarChar, 255 ),//5
                    new SqlParameter("@DiaChiDi",SqlDbType.NVarChar, 255 ),//5
                    new SqlParameter("@GoiTaxi",SqlDbType.Int  ),
                     new SqlParameter("@GoiLai",SqlDbType.Char ,1 ),
                    new SqlParameter("@GoiKhieuNai",SqlDbType.Char ,1 ),
                    new SqlParameter("@ThongTinKhac",SqlDbType.Char ,1 ),                                       
                    new SqlParameter("@ChonTaxi4Cho",SqlDbType.Int  ),
                    new SqlParameter("@ChonTaxi7Cho",SqlDbType.Int  ),
                    new SqlParameter("@SanBay_DuongDai",SqlDbType.Char,1 ),
                    new SqlParameter("@Vung",SqlDbType.Int  ),  //10
                    new SqlParameter("@LenhTrucDienThoaiID",SqlDbType.Char,2 ),
                    new SqlParameter("@LichSuLenhDienThoai",SqlDbType.Char ,255 ),//15
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar ,255 ),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char ,1 )                    
                };
                parameters[0].Value = ID_DIEUHANH;
                parameters[1].Value = DiaChiGoi;
                parameters[2].Value = DiaChiDi;
                parameters[3].Value = GoiTaxi;
                parameters[4].Value = GoiLai == true ? "1" : "0";
                parameters[5].Value = GoiKhieuNai == true ? "1" : "0";
                parameters[6].Value = ThongTinKhac == true ? "1" : "0";
                parameters[7].Value = ChonTaxi4Cho;
                parameters[8].Value = ChonTaxi7Cho;
                parameters[9].Value = SanBay_DuongDai == true ? "1" : "0";
                parameters[10].Value = MaVung;
                parameters[11].Value = LenhTrucDienThoaiID;
                parameters[12].Value = LichSuLenhDienThoai == null ? string.Empty : LichSuLenhDienThoai.ToString();
                parameters[13].Value = GhiChuChoDienThoai;
                parameters[14].Value = ((int)TrangThaiLenh).ToString();

                rowAffected = this.RunProcedure("sp_UpdateChatDienThoai_T_TAXIOPERATION_KETTHUC", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Lay tat cac cac lenh duoc thay doi moi nhat moi tong dai bo dam
        /// gia tri @TrangThaiLanh = BoDam
        /// Ngay lay ngay hien tai
        /// @Ngay Datetime,
        /// @TrangThaiLenh char(1)
        /// </summary>
        /// <param name="Ngay">Ngay Hien Tai datenow 00:00:01</param>
        /// <returns>Dánh sách cac dong dieu hanh thay doi</returns>
        public DataTable GetNewCallsAndChatForDienThoai(DateTime Ngay)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.DateTime )            
                };
            parameters[0].Value = Ngay;



            return this.RunProcedure("[sp_GetNewCallsAndChatForDienThoai]", parameters, "tblNewCallsAndChatForDienThoai").Tables[0];

        }

        public DataTable GetAllCallsFinishOnDay_DienThoai(DateTime Ngay)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.DateTime )
                };

            parameters[0].Value = Ngay;

            return this.RunProcedure("[sp_GetAllCallsFinish_DienThoai_ByDay]", parameters, "tblCallsFinish").Tables[0];
        }
        public DataTable GetAllCallsFinishOnDay(DateTime Ngay)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.DateTime )
                };

            parameters[0].Value = Ngay;

            return this.RunProcedure("[sp_GetAllCallsFinish_ByDay]", parameters, "tblCallsFinish").Tables[0];
        }

        #endregion OlderMethods

        #region  KHAI THAC THONG TIN CUA CAC CUOC GOI DA KET THUC

        /// <summary>
        /// -- Description:	@Ngay ; Ngcay can truy van thong tin
        /// --				@MaNhanVienTongDai : Chon ma vien la truc tongdai, neu de rong thi lay theo ca ngay
        ///  --			   @CuocGoiKhongThanhCong : Trang thai cua khong thanh cong
        ///   --					1 : Khong xe phuc vu
        ///   --					2 : Truot khach
        ///   --					3 : Khach ao
        ///   --					4 : Khach hoan
        ///               @CuocGoiKhongThanhCong = empty  ; Lay tat ca 4 trang thai
        ///   -- =============================================
        /// </summary>
        /// <param name="Ngay"></param>
        /// <param name="MaNhaVienTongDai"></param>
        /// <param name="CuocGoiKhongThanhCong"></param>
        /// <returns></returns>
        public DataTable GetAllCallsStatus_CuocGoiKhongThanhCong(DateTime Ngay, string MaNhaVienTongDai, string CuocGoiKhongThanhCong)
        {
            //@Ngay datetime,
            //@MaNhanVienTongDai	char(5),
            //@CuocGoiKhongThanhCong char(2)

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ngay",SqlDbType.DateTime ),
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.Char ,5 ),
                    new SqlParameter("@CuocGoiKhongThanhCong",SqlDbType.Char,2 )
                };

            parameters[0].Value = Ngay;
            parameters[1].Value = MaNhaVienTongDai;
            parameters[2].Value = CuocGoiKhongThanhCong;


            return this.RunProcedure("[sp_GetAllCuocGoiKhongThanhCong_ByDate]", parameters, "tblCallsFinish").Tables[0];
        }

         
        /// <summary>
        /// lấy tất cả các cuộc gọi của môi giới
        /// </summary>
        /// <param name="Thang"></param>
        /// <param name="Nam"></param>
        /// <returns></returns>
        public DataTable GetAllCuocGoiCuaDoiTac_GoiTaxi(int Thang, int Nam)
        {
            //@Ngay datetime,
            //@MaNhanVienTongDai	char(5),
            //@CuocGoiKhongThanhCong char(2)

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Thang",SqlDbType.Int ),
                    new SqlParameter("@Nam",SqlDbType.Int  ) 
                };

            parameters[0].Value =  Thang;
            parameters[1].Value = Nam; 

            return this.RunProcedure("[sp_GetAllCuocGoiCuaDoiTac_GoiTaxi]", parameters, "tblCuocGoiCuaDoiTac_GoiTaxi").Tables[0];
        }

        #endregion  KHAI THAC THONG TIN CUA CAC CUOC GOI DA KET THUC

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCuocGoiCua_DienThoai()
        {
            throw new Exception("The method or operation is not implemented.");
        }


        /// <summary>
        /// Tra ve thoi gian cua may chu
        /// </summary>
        /// <returns></returns>
        public  DateTime GetTimeServer()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DateTimeServer",SqlDbType.DateTime)
                };
                parameters[0].Direction = ParameterDirection.Output;
                RunProcedure("sp_GetDateTimeServer", parameters);
                return (DateTime)parameters[0].Value;

            }
            catch (Exception ex)
            {
                return DateTime.MinValue ;
            }
        }

        /// <summary>
        /// Update so chuong va trang thai lenh cho cuong goi nho
        /// CallTaxi.SoLuotDoChuong  = (int)((SoGiayCuoi - SoGiayDau) / 5) + 1;
        ///        CallTaxi.TrangThaiCuocGoi = TrangThaiCuocGoi.CuocGoiNho;
        ///        CallTaxi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
        /// </summary>
        /// <returns></returns>
        public bool Update_DienThoai_CuocGoiNho(long IDDieuHanh, int SoLuotDoChuong, string GhiChuDienThoai, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh   )
        {
            try
            {
                //@ID bigint,	
                //@SoLuotDoChuong int,
                //@TrangThaiCuocGoi char(1),MaNhanVienDienThoai
                //@TrangThaiLenh char(1)
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@SoLuotDoChuong",SqlDbType.Int),                   
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar,255),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char,1),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1) 
                      
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = SoLuotDoChuong;
                parameters[2].Value = GhiChuDienThoai ;
                parameters[3].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[4].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();

                rowAffected = RunProcedure("sp_T_TAXIOPERATION_Update_CuocGoiNho", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public  bool Update_DienThoai_CuocGoiDenCoBatMay(long IDDieuHanh, int SoLuotDoChuong, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {
                //@ID bigint,	
                //@SoLuotDoChuong int,
                //@TrangThaiCuocGoi char(1),
                //@TrangThaiLenh char(1)
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@SoLuotDoChuong",SqlDbType.Int),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char,1),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1)
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = SoLuotDoChuong;
                parameters[2].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[3].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_CuocGoiDenCoBatMay", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Cap nhat cuoc goi da ket thuc
        ///     - lay cac cuoc goi o T_TAXIOPERATION co trang thai lenh =3,4 (ket thuc dien thoai, kethuc) insert to T_TAXIOPEREATION_KETTHUC
        /// </summary>
        /// <returns></returns>
        public bool Update_ChuyenKetThucCuocGoi()
        {
            try
            {

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                                    
                };
                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Update trang thai lenh khi ket thuc
        ///  Ket thuc, ket thuc dien thoai
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <param name="TrangThaiLenh"></param>
        /// <returns></returns>
       public  bool Update_KetThucCuocGoi(long IDDieuHanh, TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {               
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0                   
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1)
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Update_KetThucCuocGoi", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }




        /// <summary>
        /// Update cuoc goi khach ket thuc
        /// cap nhat nhan vien dien thoai va ket thuc luon
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <param name="DiaChiDonKhach"></param>
        /// <param name="TrangThaiLenh"></param>
        public bool  Update_DienThoai_CuocGoiKhac_KetThuc(long IDDieuHanh, string DiaChiDonKhach,string NhanVienDienThoai)
        {
            //[sp_T_TAXIOPERATION_Update_DienThoai_CuocGoiKhac_KetThuc]
            //    @ID bigint,		
            //    @DiaChiDonKhach nvarchar(255) ,
            //    @MaNhanVienDienThoai nvarchar(50)
            try
            {
                if (IDDieuHanh <= 0) return false;
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0  
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 ), 
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar,50)
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = DiaChiDonKhach ;
                parameters[2].Value = NhanVienDienThoai;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Update_DienThoai_CuocGoiKhac_KetThuc", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Cap nhat thong tin dia chi don khach vao bang T_TAXIOPERATION_KETTHUC
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        public bool Update_BoDam_CapNhatDiaChiTraKhack(long IDDieuHanh, string DiaChiTraKhach)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0  
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar,255 )
                    
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = DiaChiTraKhach;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_Update_DiaChiTraKhach", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }





        public bool Update_BoDam_CapNhatSanBay_DuongDai(long IDDieuHanh)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt )
                    
                };
                parameters[0].Value = IDDieuHanh;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_Update_SanBay_DuongDai", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// input : line, phonenumber, thoidiemgoi
        ///   - tim kiem trong danh sach cac cuoc dang hoat dong, danh sach cuoc goi ket thuc
        ///   - if thay trong cai nao truoc thi update vao trong bao ghi do
        /// </summary>
        /// <param name="Line"></param>
        /// <param name="PhoneNumber">[max 11 chars]</param>
        /// <param name="ThoiDiemGoi"></param>
        /// <param name="DoDaiCuocGoi"></param>
        /// <param name="VoiceFilePath"></param>
        /// <returns></returns>
        public bool UpdateCuocGoiDenFileVoice(string Line, string PhoneNumber, DateTime ThoiDiemGoi, DateTime DoDaiCuocGoi, string VoiceFilePath)
        {
            try
            { 
           //@Line  varchar(2), 
           //@PhoneNumber  varchar(11), 
           //@ThoiDiemGoi  datetime, 
           //@DoDaiCuocGoi  datetime, 
           //@VoiceFilePath  va

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar,2),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ) ,
                    new SqlParameter("@DoDaiCuocGoi",SqlDbType.DateTime ) ,
                    new SqlParameter("@VoiceFilePath",SqlDbType.VarChar ,255)                   
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                parameters[2].Value = ThoiDiemGoi;
                parameters[3].Value = DoDaiCuocGoi;
                parameters[4].Value = VoiceFilePath;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_T_KETTHUC_UpdateFileVoiceAndDuration", parameters,rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public bool Update_DienThoai_KieuKhachGoi(long ID_DieuHanh, KieuKhachHangGoiDen kieuKhachHangGoiDen)
        {
            try
            {
                //@ID bigint,	
                //@SoLuotDoChuong int,
                //@TrangThaiCuocGoi char(1),
                //@TrangThaiLenh char(1)
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 )
                };
                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = ((int)(KieuKhachHangGoiDen)kieuKhachHangGoiDen).ToString();
               
                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Update_KieuKhachGoi", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            } 
        }
        /// <summary>
        /// cap nhat vao bang du lieu T_TAXIOPERATION_KETTHUC
        /// </summary>
        /// <param name="ID_DieuHanh"></param>
        /// <param name="KieuKHGoiDen"></param>
        /// <returns></returns>
        public bool UpdateLaiCuocGoiMoiGioi(long ID_DieuHanh, KieuKhachHangGoiDen KieuKHGoiDen)
        {
            try
            { 
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 )
                };
                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = ((int)(KieuKhachHangGoiDen)KieuKHGoiDen).ToString();

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_Update_KieuKhachGoi", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            } 
        }

        public bool Update_MaNhanVienDienThoai(long ID_DieuHanh, string MaNhanVienDienThoai)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar ,50 ) 
                     
                };
                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = MaNhanVienDienThoai;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Update_MaNhanVienDienThoai", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            } 
        }

        public bool Update_MaNhanVienTongDai(long ID_DieuHanh, string MaNhanVienTongDai)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50) 
                     
                };
                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = MaNhanVienTongDai;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Update_MaNhanVienTongDai", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// xoa cuoc goi cho giai quuyet
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public bool DeleteCuocGoiChoGiaiQuyet(long IDCuocGoi)
        {
            try
            {
                //[dbo].[sp_T_TAXIOPERATION_Delete_ByID] 
                //    @ID  bigint  
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt )       
                };
                parameters[0].Value = IDCuocGoi;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Delete_ByID", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable GetNhungCuocGoiNhoHon3ThangGanDay()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    
                }; 
                return this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_GetNhungCuocGoiNhoHon3ThangGanDay", parameters, "tblNhungCuocGoiNhoHon3ThangGanDay").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }         
        }

        public bool DeleteNhungCuocGoiNhoHon3ThangGanDay()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                                    
                }; 
                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_KETTHUC_DeletetNhungCuocGoiNhoHon3ThangGanDay", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            } 
        }

        public bool KiemTraXeNhanDaDangNhanCuocKhach(long ID, string SoHieuXe)
        {
            try
            {
                 //[sp_T_TAXIOPERATION_CheckXeNhanDaCo]
                 //  @ID bigint,
                 //  @XeNhan varchar(3),
                 //  @iCount int OUTPUT
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ) ,
                     new SqlParameter("XeNhan",SqlDbType.VarChar ,3 ) ,
                     new SqlParameter("@iCount",SqlDbType.Int ) 
                };

                parameters[0].Value = ID;
                parameters[1].Value = SoHieuXe;
                parameters[2].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_CheckXeNhanDaCo", parameters, rowAffected);
                return ((int)parameters[2].Value > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateCuocGoiDaGiaiQuyet(long ID_DieuHanh, string XeNhan, string XeDon)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,100) ,
                    new SqlParameter("@XeDon",SqlDbType.VarChar,100) 
                     
                };
                parameters[0].Value = ID_DieuHanh;
                parameters[1].Value = XeNhan;
                parameters[2].Value = XeDon;

                rowAffected = this.RunProcedure("[sp_T_TAXIOPERATION_KETTHUC_Update_XeNhanXeDon]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateLaiCuocGoiMoiGioi(DateTime TuNgay, DateTime DenNgay, string MaMoiGioi)
        {
             //
             //   @ datetime,
             //   @ datetime,
             //   @ varchar(6)
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@TuNgay",SqlDbType.DateTime ), //0
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ) ,
                    new SqlParameter("@MaMoiGioi",SqlDbType.VarChar,10) 
                     
                };
                parameters[0].Value = TuNgay;
                parameters[1].Value = DenNgay;
                parameters[2].Value = MaMoiGioi;

                rowAffected = this.RunProcedure("[MOIGIOI.CapNhatCacCuocGoiMoiGioiByMaDoiTac]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #region XU LY CUOC GOI CAM ON 
        
        public bool UpdateCuocGoiCamOn(long ID, bool DaCamOn,KieuKhachDanhGiaCAMON KieuDanhGia,string YKienKhach,string NhanVienNhapDau,string NhanVienSua)
        { 
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ), //0
                    new SqlParameter("@DaCamOn",SqlDbType.Bit ) ,
                    new SqlParameter("@DanhGia",SqlDbType.TinyInt) ,
                    new SqlParameter("@YKien",SqlDbType.NVarChar,250) ,
                   new SqlParameter("@NhanVien",SqlDbType.NVarChar, 50) ,
                    new SqlParameter("@NhanVienSua",SqlDbType.NVarChar, 50)                       
                };
                parameters[0].Value = ID;
                parameters[1].Value = DaCamOn == true? 1:0;
                parameters[2].Value = (int)KieuDanhGia;
                parameters[3].Value = YKienKhach;
                parameters[4].Value = NhanVienNhapDau;
                parameters[5].Value = NhanVienSua;

                rowAffected = this.RunProcedure("[sp_T_TAXIOPERATION_KETTHUC_UpdateThongTinCamOn]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion XU LY CUOC GOI CAM ON

        #region XU LY MOI KHACH 

        public bool Update_MOIKHACH(long ID, string DiaChiDonKhach, string LenhMoiKhach, bool DaXinLoi, bool DaXyLyKhieuNai, string ThongTinThemKhieuNai, string NhanVien)
        {
            try
            {
                if (ID <= 0) return false;
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ), //0
                     new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 ) ,
                     new SqlParameter("@LenhMoiKhach",SqlDbType.NVarChar,50 ) ,
                     new SqlParameter("@DaXinLoi",SqlDbType.Bit ) ,
                     new SqlParameter("@KhieuNaiDaXyLy",SqlDbType.Bit) ,
                     new SqlParameter("@KhieuNaiThongTinThem",SqlDbType.NVarChar, 150) ,
                     new SqlParameter("@NhanVien",SqlDbType.NVarChar, 50)     ,
                     new SqlParameter("@IsErrorInsertKhongXe",SqlDbType.Int)   
                };// @IsErrorInsertKhongXe int  OUTPUT
                parameters[0].Value = ID;
                parameters[1].Value = DiaChiDonKhach;
                parameters[2].Value = LenhMoiKhach;
                parameters[3].Value = DaXinLoi == true ? 1 : 0;
                parameters[4].Value = DaXyLyKhieuNai == true ? 1 : 0;
                parameters[5].Value = ThongTinThemKhieuNai;
                parameters[6].Value = NhanVien;
                parameters[7].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("[sp_UPDATE_T_TAXIOPERATION_MoiKhach]", parameters, rowAffected);
                if (LenhMoiKhach.Contains("đã xin lỗi"))
                {
                    int IsErrorInsertKhongXe = Convert.ToInt32(parameters[7].Value.ToString());
                    if (IsErrorInsertKhongXe > 0) return false; // lỗi không chèn được không xe.
                }
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion XU LY MOI KHACH

        public bool TongDai_ChuyenVung(long IDCuocGoi, int iVung)
        {
            try
            { 		 
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@IDCuocGoi",SqlDbType.BigInt  ), //0
                    new SqlParameter("@Vung",SqlDbType.Int  )  
                };
             parameters[0].Value = IDCuocGoi;
             parameters[1].Value = iVung; 
             rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_UpdateTongDaiChuyenVung", parameters, rowAffected);
             return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// hàm cap nhat cuoc goi ket thuc
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public bool UpdateCuocKhachKetThucKhongXacDinhXeDon(long IDCuocGoi)
        {
            string strSQL = "";
            strSQL = " UPDATE [T_TAXIOPERATION]  ";
            strSQL += " SET  [TrangThaiCuocGoi] = 0 , [TrangThaiLenh] = 4, [ThoiDiemThayDoiDuLieu] = GETDATE(), XeNhan='8888', XeDon='8888'  WHERE ID = " + IDCuocGoi.ToString() + " ";
            strSQL += " exec sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi ";
            try
            {
                RunSQL(strSQL);
                return true  ;
            }
            catch (Exception ex)
            {
                return false;
            }                
        }
        /// <summary>
        /// hàm cap nhat cuoc goi ket thuc
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public bool UpdateCuocKhachKetThucKhongXacDinhXeDon(long IDCuocGoi, string NhanVienCSKH, string xeNhan)
        { 
            string strSQL = "";
            strSQL = " UPDATE [T_TAXIOPERATION]  ";
            if (xeNhan != null && xeNhan.Length > 0)
                strSQL += " SET  [TrangThaiCuocGoi] = 0 , [TrangThaiLenh] = 4, [ThoiDiemThayDoiDuLieu] = GETDATE(), XeNhan='" + xeNhan + ".8888', XeDon='8888' , MOIKHACH_NhanVien = '" + NhanVienCSKH + "' ,ThoiGianDonKhach = DATEDIFF(ss, thoidiemgoi, GETDATE())   WHERE ID = " + IDCuocGoi.ToString() + " ";
            else
                strSQL += " SET  [TrangThaiCuocGoi] = 0 , [TrangThaiLenh] = 4, [ThoiDiemThayDoiDuLieu] = GETDATE(), XeNhan='8888', XeDon='8888' , MOIKHACH_NhanVien = '" + NhanVienCSKH + "' , ThoiGianDonKhach = DATEDIFF(ss, thoidiemgoi, GETDATE())  WHERE ID = " + IDCuocGoi.ToString() + " ";

            strSQL += " exec sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi ";
            try
            {
                RunSQL(strSQL);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// hàm thực hiện kết thúc khi kiếu nại --> phản ánh 
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public bool UpdateCuocGoiKhieuNaiKetThuc(long IDCuocGoi, string noiDungPA, string maNhanVienDienThoai)
        {
            //sp_T_TAXIOPERATION_Update_CuocGoiGuiBanKhachHang]	
            //    @ID bigint,	
            //    @NoiDung NVARCHAR(250)

            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt  ), //0
                     new SqlParameter("@NoiDung",SqlDbType.NVarChar,250  ) ,
                     new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar,50)
                };
                parameters[0].Value = IDCuocGoi;
                parameters[1].Value = noiDungPA;
                parameters[2].Value = maNhanVienDienThoai;
                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Update_CuocGoiGuiBanKhachHang", parameters, rowAffected);
                return (rowAffected > 0);
               
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm thực hiện cập nhật lại lệnh mời khách và giữ khách khi v
        /// 
        /// IF LenhTongDai = "" AND LenhMoiKhach =""  -> Dat lai dienthoai truyen sang
        /// IF LenhTongDai >0 AND LenhMoiKhach ="" -->  Dat lai TrangThaiLenh = 'TongDai'
        /// 
        /// </summary>
        /// <param name="p"></param>
        public bool UpdateTuDongMoiGiuKhach(long IDCuocGoi, string LenhTongDai, string LenhMoiKhach)
        {
            if (IDCuocGoi < 0) return false;

            string strSQL = "";
            if (LenhTongDai.Length <= 0 && LenhMoiKhach.Length <= 0)
            {
                strSQL = " UPDATE [T_TAXIOPERATION]  SET LenhTongDai =N'" + LenhTongDai + "' ,MOIKHACH_LenhMoiKhach =N'" + LenhMoiKhach + "',TrangThaiLenh='1'   WHERE ID = " + IDCuocGoi.ToString();
            }
            else
            {
                strSQL = " UPDATE [T_TAXIOPERATION]  SET LenhTongDai =N'" + LenhTongDai + "' ,MOIKHACH_LenhMoiKhach =N'" + LenhMoiKhach + "' ,TrangThaiLenh='6'  WHERE ID = " + IDCuocGoi.ToString();
            }
            try
            {
                RunSQL(strSQL);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <param name="NoiDung"></param>
        /// <param name="IsDaXuLy"></param>
        /// <returns></returns>
        public bool Update_BanGiaBanTin(long IDCuocGoi,string DiaChiSuaDoi,  string NoiDung, string NhanVien,  bool IsDaXuLy,string  Vung)
        {
            if (IDCuocGoi <= 0) return false;
            int iVung = 0;

            if (Vung != null && Vung.Length > 0)
            {
                try
                {
                    iVung = Convert.ToInt32(Vung);
                }
                catch (Exception ex)
                {
                    iVung = 0;
                }
            }
             try{
                //sp_T_TAXIOPERATION_Update_BanTinGia]	
                //    @ID bigint,	
                //    @Vung INT ,		-- Chuyen vung tu ban tin ban gia
                //    @DiaChiSuaDoi NVARCHAR(255),
                //    @NoiDungXuLy NVARCHAR(255),
                //    @DaXuLy BIT ,
                //    @NhanVien NVARCHAR(50)

                   int rowAffected = 0;
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ID",SqlDbType.BigInt  ), //0
                        new SqlParameter("@Vung",SqlDbType.Int  )  ,
                        new SqlParameter("@DiaChiSuaDoi",SqlDbType.NVarChar,255  )  ,
                        new SqlParameter("@NoiDungXuLy",SqlDbType.NVarChar,255),
                        new SqlParameter("@DaXuLy",SqlDbType.Bit ),
                        new SqlParameter("@NhanVien",SqlDbType.NVarChar,50 )
                    };
                 
                 parameters[0].Value = IDCuocGoi;
                 parameters[1].Value = iVung ;
                 parameters[2].Value = DiaChiSuaDoi;
                 parameters[3].Value = NoiDung;
                 parameters[4].Value = IsDaXuLy==true?1:0;
                 parameters[5].Value = NhanVien;
                 rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_Update_BanTinGia", parameters, rowAffected);
                 return (rowAffected > 0);
                
            }
            catch (Exception ex)
            {
                return false;
            }      
        }
        /// <summary>
        /// tuwj cập nhật tổng đài 
        /// sau 3 phút mà đã có vùng mà vẫn là là chưa chuyền đi thì đặt là cuyển tổng đài
        /// </summary>
        public void  TuDongChuyenSangTongDai()
        {
            string strSQL = "";

            strSQL += " DECLARE  @Time Datetime " + Environment.NewLine;
            strSQL += " SET @Time = DATEADD(mi,-3, GetDate()) " + Environment.NewLine;
            strSQL += " UPDATE  T_TAXIOPERATION " + Environment.NewLine;
            strSQL += " SET TrangThaiLenh = '1' " + Environment.NewLine;
            strSQL += " WHERE ThoiDiemGoi <= @Time AND KieuCuocGoi = 1 AND  TrangThaiLenh = '0'   AND Vung>0  " + Environment.NewLine;

            try
            {
                RunSQL(strSQL);
                 
            }
            catch (Exception ex)
            {
                
            }     
        }

        public bool Update_BoDam(string Vung, string MaNhanVienTongdai)
        {
            string strSQL = "";

            
            strSQL += " UPDATE  T_TAXIOPERATION " + Environment.NewLine;
            strSQL += " SET MaNhanVienTongDai = N'" + MaNhanVienTongdai + "'" + Environment.NewLine;
            strSQL += " WHERE Vung = " + Vung + " AND (Len(MaNhanvienTongDai) <=0 OR (MaNhanVienTongDai IS NULL) ) " + Environment.NewLine;
           
            try
            {
                RunSQL(strSQL);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }

        /// <summary>
        /// xoa du lieu hien tai chi giu lai so dong gan day
        /// </summary>
        /// <param name="SoCuocGiuLai"></param>
        public void XoaTuDongCacCuocKhachQuaLau(int SoCuocGiuLai)
        {             
               string strSQL = "";
               //strSQL += " DECLARE @IdMin BIGINT" + Environment.NewLine; 
               //strSQL += " SET @IdMin = ( SELECT MIN(T.ID) FROM ( " + Environment.NewLine;
               //strSQL += " SELECT  TOP "+ SoCuocGiuLai.ToString () +" [ID] " + Environment.NewLine;
               //strSQL += " FROM  [T_TAXIOPERATION] WHERE LenhDienThoai <> N'khách hẹn' and LenhDienThoai <> N'KHÁCH ĐẶT' " + Environment.NewLine;
               //strSQL += " ORDER BY ID DESC ) T)" + Environment.NewLine;
               //strSQL += " UPDATE  T_TAXIOPERATION " + Environment.NewLine;
               //strSQL += " SET TrangThaiLenh = '4', TrangThaiCuocGoi = 5 " + Environment.NewLine;  // cuoc goi chua xac dinh
               //strSQL += " WHERE ID < @IdMin  AND LenhDienThoai <> N'khách hẹn'  and LenhDienThoai <> N'KHÁCH ĐẶT'  " + Environment.NewLine;  // tat ca cac cuoc dang theo doi
            strSQL = "EXEC sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi_v3";

               try
               {
                   RunSQL(strSQL);

               }
               catch (Exception ex)
               {

               }     
        } 
        /// <summary>
        /// xoa cuoc khach tu dong sau so phut
        /// chuyen thanh cac cuoc goi taxi cua xac dinh
        /// Thuoc nhung vung nao
        /// </summary>
        /// <param name="SoPhut"></param>
        public void XoaTuDongCacCuocKhachQuaLau(int SoPhut,string Vungs )
        {
            string strSQL = "";

            strSQL += " DECLARE  @Time Datetime " + Environment.NewLine;
            strSQL += " SET @Time = DATEADD(mi,-" + SoPhut.ToString () + ", GetDate()) " + Environment.NewLine;
            strSQL += " UPDATE  T_TAXIOPERATION " + Environment.NewLine;
            strSQL += " SET TrangThaiLenh = '4', TrangThaiCuocGoi = 5 " + Environment.NewLine;  // cuoc goi chua xac dinh
            strSQL += " WHERE  (" + GetSQLStringQueryVung(Vungs) + ") AND ThoiDiemGoi <= @Time AND LenhDienThoai <> N'khách hẹn'  AND LenhDienThoai <> N'KHÁCH ĐẶT' " + Environment.NewLine;  // tat ca cac cuoc dang theo doi
            strSQL += " EXEC sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi ";

            try
            {
                RunSQL(strSQL);

            }
            catch (Exception ex)
            { }     
        }


        private string GetSQLStringQueryVung(string Vung)
        {
            string strReturn = " (1<>1) ";
            string[] arrVung = Vung.Split(";".ToCharArray());

            foreach (string strV in arrVung)
            {
                if (strV.Length > 0) strReturn += " OR (Vung = " + strV + ") ";
            }
            return strReturn;
        }
        /// <summary>
        /// thuc hien update thong tin moi khach
        /// update thoi diem tiep theo := 'HH:mm:ss dd/MM/yyyy'
        /// cong them cac thoi diem vao
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <param name="NhanVienMoiID"></param>
        /// <returns></returns>
        public bool Update_ThoiDiemMoiKhach(long IDDieuHanh, string NhanVienMoiID)
        {
             //[sp_T_TAXIOPERATION_MoiKhach_UpdateThoiDiemGoi]	
             //   @ID bigint,
             //   @NhanVienID nvarchar(50)

            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt  ), //0
                    new SqlParameter("@NhanVienID",SqlDbType.NVarChar ,50  )  
                };
                parameters[0].Value = IDDieuHanh ;
                parameters[1].Value = NhanVienMoiID ;
                rowAffected = this.RunProcedure("sp_T_TAXIOPERATION_MoiKhach_UpdateThoiDiemGoi", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int UpdateCSPhanBoCuocGoi(string strSQL)
        {
            try
            {
                return this.RunSQL_ReturnRowsAffected(strSQL);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void UpdateCSPhanBoCuocGoi(long ID, string xeNhan,  string XeDon, string NhanVienCS)
        {
            string strSQL = "";
            if (ID > 0)
            {
                strSQL += " UPDATE  [T_TAXIOPERATION] ";
                strSQL += " SET [TrangThaiCuocGoi] = 1 ";
                strSQL += "   ,[TrangThaiLenh] = '3'  , XeNhan ='" +xeNhan+ "',XeDon = '" + XeDon +"'";
                strSQL += "  ,[MOIKHACH_NhanVien] = N'" + NhanVienCS + "'";
                strSQL += "  ,[ThoiDiemThayDoiDuLieu] = GETDATE() ";

                if (XeDon.Length > 0) //  cập nhật thông tin thời gian đón
                    strSQL += " ,ThoiGianDonKhach =CASE WHEN (ThoiGianDonKhach IS NULL OR ThoiGianDonKhach =0)   THEN   datediff(ss,ThoiDiemGoi,getdate()) ELSE ThoiGianDonKhach END ";

                strSQL += " WHERE ID = " + ID.ToString();
                strSQL += "    EXEC sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi ";

                this.RunSQL(strSQL);
            }
        }
        /// <summary>
        /// hàm trả về thời điểm thực hiện gọi lại của cuộc gọi nhỡ
        /// </summary>
        /// <param name="thoiDiemGoi"></param>
        /// <param name="soDienThoai"></param>
        /// <returns></returns>
        public DataTable  GetThoiDiemGoiLaiCuocGioNho(DateTime thoiDiemGoi, string soDienThoai)
        {
 
            DataTable dt;
            string sql = "";
            sql += " SELECT [Line] ,[PhoneNumber] ,[ThoiDiemGoi] ,[DoDaiCuocGoi] ,[VoiceFilePath] FROM [T_TAXIOPERATION_CUOCGOIDI] ";
            sql += " WHERE ThoiDiemGoi BETWEEN '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", thoiDiemGoi) + "' AND '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", thoiDiemGoi.AddMinutes(10)) + "'";
            sql += " AND PhoneNumber = '" + soDienThoai + "'";
            try
            {
                dt = this.RunSQL(sql, "tbl");
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        /// <summary>
        /// tra ve ds cuoc goi da ket thuc
        /// </summary>
        /// <param name="linesChoPhep"></param>
        /// <param name="soDong"></param>
        /// <returns></returns>
        public DataTable DIENTHOAI_LayCuocGoiDaGiaiQuyet(string linesChoPhep, int soDong)
        {
             
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int)
           };

            parameters[0].Value = linesChoPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;

            return this.RunProcedure("[DIENTHOAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc]", parameters, "cuogoiKetThuc").Tables[0];

        }
        /// <summary>
        /// ham tra ve ds cuoc goi cua tong dai
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="soDong"></param>
        /// <returns></returns>
        public DataTable TONGDAI_LayCuocGoiDaGiaiQuyet(string  vungsDuocCapPhep, int soDong)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int)
           };

            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;

            return this.RunProcedure("[TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc]", parameters, "cuogoiKetThuc").Tables[0];
        }

        #region ========================New v3========================
        /// <summary>
        /// Search chi tiết cuộc gọi đến
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="kieuGoi"></param>
        /// <param name="loaiXe"></param>
        /// <param name="diaChi"></param>
        /// <param name="Vung"></param>
        /// <param name="soDienThoai"></param>
        /// <param name="line"></param>
        /// <param name="idNhanVienTD"></param>
        /// <param name="idNhanVienDT"></param>
        /// <param name="ketQuaDH"></param>
        /// <returns></returns>
        /// <modified>
        /// name            date        comments
        /// phupn         1/10/2011     created
        ///</modified>
        public DataTable ML_GetCuocGoi_Search(DateTime tuNgay, DateTime denNgay, string kieuGoi, string loaiXe, string diaChi, string Vung,
                        string soDienThoai, string line, int TrangThaiCuocGoi)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] parameters = new SqlParameter[]{
                        new SqlParameter ("@TuNgay", SqlDbType.DateTime),
                        new SqlParameter ("@DenNgay", SqlDbType.DateTime),
                        new SqlParameter ("@Line", SqlDbType.VarChar,10),
                        new SqlParameter ("@KieuCuocGoi", SqlDbType.VarChar ,10),
                        new SqlParameter ("@LoaiXe", SqlDbType.VarChar ,50),
                        new SqlParameter ("@Vung", SqlDbType.VarChar ,50),
                        new SqlParameter ("@DiaChi", SqlDbType.NVarChar , 255),
                        new SqlParameter ("@SoDienThoai", SqlDbType.VarChar ,100),
                        new SqlParameter ("@TrangThaiCuocGoi", SqlDbType.Int)
                    };
                    parameters[0].Value = tuNgay;
                    parameters[1].Value = denNgay;
                    if (line != string.Empty) parameters[2].Value = line;
                    if (kieuGoi != string.Empty) parameters[3].Value = kieuGoi;
                    if (loaiXe != string.Empty) parameters[4].Value = loaiXe;
                    if (Vung != string.Empty) parameters[5].Value = Vung;
                    //if (xeNhan != string.Empty) parameters[6].Value = xeNhan;
                    //if (xeDon != string.Empty) parameters[7].Value = xeDon;
                    // if (ketQuaDH != string.Empty) parameters[6].Value = ketQuaDH;
                    if (diaChi != string.Empty) parameters[6].Value = diaChi;
                    if (soDienThoai != string.Empty) parameters[7].Value = soDienThoai;
                    parameters[8].Value = TrangThaiCuocGoi;

                    ds = RunProcedure("V3_SP_T_TAXIOPERATION_SEARCH", parameters, "tblCuocGoiDen");
                    DataTable dt = ds.Tables[0];
                    return dt;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public DataTable ML_GetCuocGoi_Search_V4(DateTime tuNgay, DateTime denNgay, string kieuGoi, string loaiXe, string diaChi, string Vung,
                        string soDienThoai, string line, int TrangThaiCuocGoi, string xeNhan, string xeDon)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] parameters = new SqlParameter[]{
                        new SqlParameter ("@TuNgay", SqlDbType.DateTime),
                        new SqlParameter ("@DenNgay", SqlDbType.DateTime),
                        new SqlParameter ("@Line", SqlDbType.VarChar,10),
                        new SqlParameter ("@KieuCuocGoi", SqlDbType.VarChar ,10),
                        new SqlParameter ("@LoaiXe", SqlDbType.VarChar ,50),
                        new SqlParameter ("@Vung", SqlDbType.VarChar ,50),
                        new SqlParameter ("@DiaChi", SqlDbType.NVarChar , 255),
                        new SqlParameter ("@SoDienThoai", SqlDbType.VarChar ,100),
                        new SqlParameter ("@TrangThaiCuocGoi", SqlDbType.Int),
                        new SqlParameter ("@XeNhan", SqlDbType.VarChar ,50),
                        new SqlParameter ("@XeDon", SqlDbType.VarChar ,50)
                    };
                    parameters[0].Value = tuNgay;
                    parameters[1].Value = denNgay;
                    if (line != string.Empty) parameters[2].Value = line;
                    if (kieuGoi != string.Empty) parameters[3].Value = kieuGoi;
                    if (loaiXe != string.Empty) parameters[4].Value = loaiXe;
                    if (Vung != string.Empty) parameters[5].Value = Vung;
                    //if (xeNhan != string.Empty) parameters[6].Value = xeNhan;
                    //if (xeDon != string.Empty) parameters[7].Value = xeDon;
                    // if (ketQuaDH != string.Empty) parameters[6].Value = ketQuaDH;
                    if (diaChi != string.Empty) parameters[6].Value = diaChi;
                    if (soDienThoai != string.Empty) parameters[7].Value = soDienThoai;
                    parameters[8].Value = TrangThaiCuocGoi;
                    parameters[9].Value = xeNhan;
                    parameters[10].Value = xeDon;

                    ds = RunProcedure("V3_SP_T_TAXIOPERATION_SEARCH_V4", parameters, "tblCuocGoiDen");
                    DataTable dt = ds.Tables[0];
                    return dt;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }


        public DataTable BanTinGia_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, string linesDuocCapPhep, int soDong)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int),
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50)
           };

            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;
            parameters[3].Value = linesDuocCapPhep;

            return this.RunProcedure("BanTinGia_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc", parameters, "cuogoiKetThuc").Tables[0];
        }
        #endregion
        public int DeleteMuliCuocGoi(string idCuocGoi)
        {
            var parameters = new[]
            {
                new SqlParameter("@idCuocGoi", SqlDbType.NVarChar,4000)
            };
            parameters[0].Value = idCuocGoi;
            return this.RunProcedure("sp_DeleteMuliCuocGoi", parameters, 0);
        }
        public string G5_GetAddressOfDienThoai(string phonenumber)
        {
           var dt= this.ExeStoreData("G5_sp_DienThoai_GetAddressOfDienThoai", phonenumber);
           if (dt == null || dt.Rows.Count == 0)
               return string.Empty;
           return dt.Rows[0]["DiaChiDonKhach"].ToString();
        }



        #region  ToolTest
        public long Insert_DienThoai_LanDau_ToaDo_TestCuocGoiLai(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh, float KinhDo, float ViDo, string MaDoiTac, string parConnectDB)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,5 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt), 
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float),
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float),
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10)
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                //parameters[2].Value = null;
                parameters[3].Value = DiaChiDonKhach;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)KieuKhachHangGoiDen).ToString();
                parameters[5].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                parameters[7].Direction = ParameterDirection.Output;
                parameters[8].Value = KinhDo;
                parameters[9].Value = ViDo;
                parameters[10].Value = MaDoiTac;

                this.myConnection = new SqlConnection(parConnectDB);
                rowAffected = this.RunProcedure("G5_DienThoai_spT_TAXIOPERATION_Insert_CuocGoiLanDau_ToaDo_MaDoiTac_TestCuocGoiLai", parameters, rowAffected);
                return (long)parameters[7].Value;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public long Insert_DienThoai_LanDau_ToaDo(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh, float KinhDo, float ViDo, string MaDoiTac, string parConnectDB)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,5 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt), 
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float),
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float),
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10)
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                //parameters[2].Value = null;
                parameters[3].Value = DiaChiDonKhach;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)KieuKhachHangGoiDen).ToString();
                parameters[5].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                parameters[7].Direction = ParameterDirection.Output;
                parameters[8].Value = KinhDo;
                parameters[9].Value = ViDo;
                parameters[10].Value = MaDoiTac;
                this.myConnection = new SqlConnection(parConnectDB);
                rowAffected = this.RunProcedure("V3_sp_T_TAXIOPERATION_Insert_CuocGoiLanDau_ToaDo_MaDoiTac", parameters, rowAffected);
                return (long)parameters[7].Value;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        public long InsertCuocGoiLanDau_TongDai(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh, float KinhDo, float ViDo, string MaDoiTac)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,5 ), //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ), 
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt), 
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float),
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float),
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10)
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                //parameters[2].Value = null;
                parameters[3].Value = DiaChiDonKhach;
                parameters[4].Value = ((int)(KieuKhachHangGoiDen)KieuKhachHangGoiDen).ToString();
                parameters[5].Value = ((int)(TrangThaiCuocGoiTaxi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = ((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();
                parameters[7].Direction = ParameterDirection.Output;
                parameters[8].Value = KinhDo;
                parameters[9].Value = ViDo;
                parameters[10].Value = MaDoiTac;

                rowAffected = this.RunProcedure("V3_sp_T_TAXIOPERATION_Insert_CuocGoiLanDau_ToaDo_TongDai", parameters, rowAffected);
                return (long)parameters[7].Value;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }




}