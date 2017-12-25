using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Taxi.Utils;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using Taxi.Entity;
using Taxi.Utils.Enums;
using System.Configuration;
namespace Taxi.Data
{
    /// <summary>
    ///  dữ liệu cuốc khách
    /// </summary>
    /// <Modified>        
    ///	Name		Date		    Comment 
    /// Côngnt      16/07           Create
    /// </Modified>
    public class CuocGoi
    {
        #region ================================== sp Name ==================================
        // định nghĩa các stoce procedure
        // Điện thoại
        private const string SP_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGIOMOI = "V3_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoi";
        private const string SP_DIENTHOAI_T_TAXIOPERATION_CAPNHATCUOCGOI = "V3_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi";                
        private const string SP_DIENTHOAI_T_TAXIOPERATION_CAPNHATCUOCGOI_Envang = "V1_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Envang";


        private const string SP_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGOICAPNHATBYTONGDAI = "V3_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai";
        private const string SP_DIENTHOAI_T_TAXIOPERATION_LAYCACIDCUOCGOIKETTHUCBYTONGDAI = "V3_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDai";
        private const string SP_DIENTHOAI_T_TAXIOPERAtiON_CHENCUOCGOIGIALAP = "V3_DIENTHOAI_spT_TAXIOPERATION_ChenCuocGoiGiaLap";
        private const string SP_DIENTHOAI_T_TAXIOPERAtiON_CHENCUOCGOIGIALAP2 = "V3_DIENTHOAI_spT_TAXIOPERATION_ChenCuocGoiGiaLap2";
        private const string SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC = "V3_DIENTHOAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc";
        private const string SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUCSB = "V3_DIENTHOAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThucSB";
        private const string SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUCNotFT = "V3_DIENTHOAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThucNotFT";
        private const string SP_DIENTHOAI_SP_T_TAXIOPERATION_COUNT_LIMIT = "V3_SP_T_TAXIOPERATION_COUNT_LIMIT";
        private const string SP_T_TAXIOPERATION_KETTHUC_UPDATE_STATUS = "V3_SP_T_TAXIOPERATION_KETTHUC_UPDATE_STATUS";
        private const string SP_T_TAXIOPERATION_KETTHUC_UPDATE_STATUS_TONGDAI = "V3_SP_T_TAXIOPERATION_KETTHUC_UPDATE_STATUS_TONGDAI";

        // Tổng đài                                                             
        private string SP_TONGDAI_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP = "V3_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep_V3";
        private const string SP_TONGDAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC = "V3_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc";
        private const string SP_TONGDAI_T_TAXIOPERATION_UPDATECUOCGOI = "V3_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi";
        private const string SP_TONGDAI_T_TAXIOPERATION_UPDATECUOCGOI_BanCo = "V3_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_BanCo";
        private const string SP_TONGDAI_T_TAXIOPERATION_UPDATECUOCGOI_KETTHUC = "V3_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_KETTHUC";
        private string SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "V3_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai";
        private const string SP_TONGDAI_T_TAXIOPERATION_LAYCACIDCUOCGOIKETTHUCBYDIENTHOAI = "V3_TONGDAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByDienThoai";
        private const string SP_DIENTHOAI_SP_T_TAXIOPERATION_UPDATE_DSXEDECU = "V3_DIENTHOAI_SP_T_TAXIOPERATION_UPDATE_DSXEDECU";
        private const string SP_TONGDAI_SP_T_TAXIOPERATION_UPDATE_DSXENHAN_TOADO = "V3_TONGDAI_SP_T_TAXIOPERATION_UPDATE_DSXENHAN_TOADO";

        // DieuHanhChinh
        private const string SP_DIEUHANHCHINH_T_TAXIOPRATION_LAYDSCUOCGOIMOI = "V3_DIEUHANHCHINH_spT_TAXIOPERATION_LayDSCuocGoiMoi";
        private const string SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC_DHC = "V3_DIENTHOAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc_DHC";

        private const string SP_DIEUHANHCHINH_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP_FILTER = "V3_DIEUHANHCHINH_spT_TAXIOPERATION_LayAllOfVungChoPhep_Filter";

        private const string SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY = "V3_SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY";
        private const string SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY_DHV = "V3_SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY_DHV";
        private const string SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY_DTV = "V3_SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY_DTV";


        // Moi Khach        
        private const string V3_MOIKHACH_T_TAXIOPERATION_LAYCUOCGOITUDTV_TDV = "V3_MOIKHACH_spT_TAXIOPERATION_LayCuocGoiMoiTuDTV_TDV";
        private const string V3_MOIKHACH_T_TAXIOPERATION_LAYCACIDCUOCGOIKETTHUCBYDTV_TDV = "V3_MOIKHACH_T_TAXIOPERATION_LAYCACIDCUOCGOIKETTHUCBYDTV_TDV";
        private const string V3_MOIKHACH_T_TAXIOPERATION_CAPNHATCUOCGOI_XEDON = "V3_MOIKHACH_T_TAXIOPERATION_CAPNHATCUOCGOI_XEDON";
        private const string V3_MOIKHACH_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC = "V3_MOIKHACH_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc";
        private const string V3_MOIKHACH_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP = "V3_MOIKHACH_spT_TAXIOPERATION_LayAllOfVungChoPhep";

        // Man hinh dieu hanh
        private const string SP_MANHINH_T_TAXIOPERATION_UPDATEGUITOIXE = "V3_MANHINH_TAXIOPERATION_GUITOIXE";
        private SqlConnection g_sqlCon;

        #region FastTaxi
        private const string sp_FT_V3_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep = "FT_V3_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep";
        private const string sp_FT_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGIOMOI = "FT_V3_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoi";
        private const string sp_FT_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGIOMOINotFT = "FT_V3_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiNotFT";        
        #endregion

        #region EnVang
        private const string sp_EnVangVip_DIENTHOAI_LAYDSCUOCGIOMOI = "EnVangVip_DIENTHOAI_LayDSCuocGoiMoi";
        private const string sp_EnVangVip_DIENTHOAI_LayAllOfLineChoPhep = "EnVangVip_DIENTHOAI_LayAllOfLineChoPhep";
        #endregion
        #endregion
        /// <summary>
        /// hàm khởi tạo
        /// thực hiện lấy thông tin connection
        /// </summary>
        public CuocGoi()
        {
            //g_ConnectionString = @"192.168.1.240\sqlexpress;Initial Catalog=Taxi_TienSa;User ID=sa;Password=123@123abc";
            string gConnectionString = Utils.Settings.ConnectionSetting.ConnectionString;
            if (string.IsNullOrEmpty(gConnectionString) || gConnectionString.Contains("Data Source=;"))
            {
                gConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            }
            g_sqlCon = new SqlConnection(gConnectionString);
        }

        #region ================================== DienThoai Module ==================================
        public long InsertCuocGoiLanDauByDiaChiFromMEM_V2(string Line, string PhoneNumber, DateTime ThoiDiemGoi, string diaChi,
                                                                int vung, KieuKhachHangGoiDen kieuKhachHang, string maDoiTac, byte soLanGoiLai, long IDCuocGoiLai,
                                                                string LoaiXe, string thoiGianGoiLai, string GhiChuTiepNhan, float KinhDo, float ViDo, string diaChiTra)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            long IDCuocGoi = -1; // Loi

            try
            {
                int iLine;
                try
                {
                    iLine = Convert.ToInt32(Line);
                    if (iLine <= 0) Line = "1";
                }
                catch 
                {
                    Line = "1";
                }
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,5 ),               //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),     
                    new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     // 5
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ),  
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10  ), 
                    new SqlParameter("@Vung",SqlDbType.Int  ),  // 8
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt),
                    new SqlParameter("@CuocGoiLaiIDs",SqlDbType.VarChar ,255) ,   // 10  
                    new SqlParameter ("@SoLanGoiLai",SqlDbType.SmallInt),
                    new SqlParameter("@LoaiXe",SqlDbType.VarChar ,255),
                    new SqlParameter("@ThoiGianGoiLai",SqlDbType.VarChar ,255),
                    new SqlParameter("@GhiChuTiepNhan",SqlDbType.NVarChar ,255),
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float)  ,
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float)   ,
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar, 255 )  
                };

                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                parameters[2].Value = ThoiDiemGoi;
                parameters[3].Value = diaChi;
                parameters[4].Value = ((int)kieuKhachHang).ToString();
                parameters[5].Value = "0"; //((int)(TrangThaiCuocGoi)TrangThaiCuocGoi).ToString();
                parameters[6].Value = "0"; //((int)(TrangThaiLenhTaxi)TrangThaiLenh).ToString();  
                parameters[7].Value = maDoiTac;
                parameters[8].Value = vung;
                parameters[9].Direction = ParameterDirection.Output;
                parameters[10].Value = IDCuocGoiLai.ToString(); // null is không nghi nhận id gọi lại 
                parameters[11].Value = soLanGoiLai;
                parameters[12].Value = LoaiXe;
                parameters[13].Value = thoiGianGoiLai;
                parameters[14].Value = GhiChuTiepNhan;
                parameters[15].Value = KinhDo;
                parameters[16].Value = ViDo;
                parameters[17].Value = diaChiTra;
                int iRet = SqlHelper.ExecuteNonQuery(g_sqlCon, "sp_T_TAXIOPERATION_Insert_CuocGoiLanDauCoDiaChi_V5", parameters);

                if (iRet > 0)
                {
                    IDCuocGoi = long.Parse(parameters[9].Value.ToString());
                }

                g_sqlCon.Close();
                return IDCuocGoi;
            }
            catch 
            {
                g_sqlCon.Close();
                return IDCuocGoi;
            }
        }

        public void DeleteCallAuto()
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlHelper.ExecuteScalar(g_sqlCon, CommandType.StoredProcedure, "sp_T_TAXIOPERATION_RemoveCallAuto");
            g_sqlCon.Close();
        }

        /// <summary>
        /// hàm thực hiện lấy ra các cuộc gọi gần đây nhất mà chương trình chưa cập nhật
        /// </summary>
        /// <param name="lineChoPhep"></param>
        /// <param name="thoiDiemLayTruoc"></param>
        /// <returns></returns>
        public List<CuocGoiDienThoaiLanDauType> DIENTHOAI_LayDSCuocGoiMoi(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            List<CuocGoiDienThoaiLanDauType> retListCuocGoiLanDau = new List<CuocGoiDienThoaiLanDauType>();

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
                };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = thoiDiemLayTruoc;

            using (SqlDataReader sqldrCuocGoiMoi = SqlHelper.ExecuteReader(g_sqlCon, SP_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGIOMOI, parameters))
            {
                while (sqldrCuocGoiMoi.Read())
                {
                    //[ID] ,[Line] ,[PhoneNumber] ,[ThoiDiemGoi]  ,[DiaChiLuu] ,[DiaChiDonKhach]  ,[Vung]  ,[LoaiKhachHang]                  
                    retListCuocGoiLanDau.Add(new CuocGoiDienThoaiLanDauType(Convert.ToInt64(sqldrCuocGoiMoi["ID"].ToString()),
                                                 Convert.ToDateTime(sqldrCuocGoiMoi["ThoiDiemGoi"].ToString()),
                                                 Convert.ToByte(sqldrCuocGoiMoi["SoLanGoi"].ToString()),
                                                 Convert.ToByte(sqldrCuocGoiMoi["Line"].ToString()),
                                                 sqldrCuocGoiMoi["PhoneNumber"].ToString(),
                                                 sqldrCuocGoiMoi["DiaChiGoi"].ToString(),
                                                 sqldrCuocGoiMoi["DiaChiDonKhach"].ToString(),
                                                 Convert.ToByte(sqldrCuocGoiMoi["Vung"].ToString()),
                                                 (KieuKhachHangGoiDen)Convert.ToInt32(sqldrCuocGoiMoi["KieuKhachHangGoiDen"].ToString()),
                                                 sqldrCuocGoiMoi["LoaiXe"].ToString(),
                                                 sqldrCuocGoiMoi["LenhDienThoai"].ToString(),
                                                 sqldrCuocGoiMoi["GhiChuDienThoai"].ToString(),
                                                 sqldrCuocGoiMoi["XeNhan"].ToString(),
                                                 sqldrCuocGoiMoi["MaDoiTac"].ToString(),
                                                 sqldrCuocGoiMoi["GPS_KinhDo"].ToString(),
                                                 sqldrCuocGoiMoi["GPS_ViDo"].ToString()
                                                 ));
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return retListCuocGoiLanDau;
        }
        /// <summary>
        /// hàm thực hiện lấy ra các cuộc gọi gần đây nhất mà chương trình chưa cập nhật
        /// </summary>
        /// <param name="lineChoPhep"></param>
        /// <param name="thoiDiemLayTruoc"></param>
        /// <returns></returns>
        public DataTable DIENTHOAI_LayDSCuocGoiMoi_FT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,150), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
                };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = thoiDiemLayTruoc;
            DataTable dt = SqlHelper.ExecuteDataset(g_sqlCon, sp_FT_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGIOMOI, parameters).Tables[0];
            // đóng kêt nối db
            g_sqlCon.Close();
            return dt;
        }
        public DataTable DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,150), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
                };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = thoiDiemLayTruoc;
            DataTable dt = SqlHelper.ExecuteDataset(g_sqlCon, sp_FT_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGIOMOINotFT, parameters).Tables[0];
            // đóng kêt nối db
            g_sqlCon.Close();
            return dt;
        }
        /// <summary>
        /// hàm lấy tất cả các cuộc gọi của line cho phép
        /// </summary>
        /// <param name="lineChoPhep"></param>
        /// <returns></returns>
        public DataTable DIENTHOAI_LayAllCuocGoi(string lineChoPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50)
           };
            parameters[0].Value = lineChoPhep;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, sp_FT_V3_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        #region Cuoc Goi Line Khac

        /// <summary>
        /// hàm lấy tất cả các cuộc gọi khác line cho phép
        /// </summary>
        /// <param name="lineChoPhep"></param>
        /// <returns></returns>
        public DataTable DIENTHOAI_LayAllCuocGoi_Khac(string lineChoPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50)
           };
            parameters[0].Value = lineChoPhep;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep_Khac", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable DIENTHOAI_LayDSCuocGoiMoi_V3_Khac(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
                };
            if (!string.IsNullOrEmpty(lineChoPhep))
            {
                parameters[0].Value = lineChoPhep;
            }

            parameters[1].Value = thoiDiemLayTruoc;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoi_Khac", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }

        public DataTable DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3_Khac(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
            };
            parameters[0].Value = linesDuocCapPhep;
            parameters[1].Value = thoiDiemNhanDulieuTruoc;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai_Khac", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable DIENTHOAI_LayCacIDCuocGoiKetThuc_Khac(string listIDCuocGoiHienTai, string linesDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LinesDuocCapPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@ListIDCuocGoiHienTai",SqlDbType.VarChar ,8000) 
           };
            parameters[0].Value = linesDuocCapPhep;
            parameters[1].Value = listIDCuocGoiHienTai;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThuc_Khac", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// Hàm thực hiện lấy ds cuộc gọi đã giải quyết
        /// </summary>
        /// <param name="lineChoPhep"> line cho phép , '1;4;5;7'</param>
        /// <param name="soDong"> số dòng của MACDINH = 20</param>
        public DataTable DIENTHOAI_LayCuocGoiDaGiaiQuyet(object lineChoPhep, int soDong)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int)
           };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        public DataTable DIENTHOAI_LayCuocGoiDaGiaiQuyetSB(object lineChoPhep, int soDong)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int)
           };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUCSB, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        public DataTable DIENTHOAI_LayCuocGoiDaGiaiQuyetNotFT(object lineChoPhep, int soDong)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int)
           };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUCNotFT, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        /// <summary>
        /// Hàm thực hiện lấy ds cuộc gọi đã giải quyết cho Dieu hanh chinh (lay ca cuoc khach dat)
        /// </summary>
        /// <param name="lineChoPhep"> line cho phép , '1;4;5;7'</param>
        /// <param name="soDong"> số dòng của MACDINH = 20</param>
        public DataTable DIENTHOAI_LayCuocGoiDaGiaiQuyet_DHC(object lineChoPhep, int soDong)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int)
           };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC_DHC, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        /// <summary>
        /// hàm trả về ds các id cuộc gọi đã bị tổng đài kết thúc
        /// </summary>
        /// <param name="listIDCuocGoiHienTai">ds các id hiện tại</param>
        /// <param name="linesDuocCapPhep">line cho phép của máy điện thoại</param>
        /// <returns></returns>
        public DataTable DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(string listIDCuocGoiHienTai, string linesDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LinesDuocCapPhep",SqlDbType.VarChar ,150),
                    new SqlParameter("@ListIDCuocGoiHienTai",SqlDbType.VarChar ,8000) 
           };
            parameters[0].Value = linesDuocCapPhep;
            parameters[1].Value = listIDCuocGoiHienTai;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_LAYCACIDCUOCGOIKETTHUCBYTONGDAI, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        /// <summary>
        /// Hàm thực hiện update thông tin cuộc gọi phía điện thoại
        /// </summary>
        public bool DIENTHOAI_UpdateThongTinCuocGoi(long IDCuocGoi, string diaChiDonKhach, string phoneNumber, int vung, string loaiXe, int soLuongXe,
                                                    TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
                                                    TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
                                                    int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD, string xeDon, KieuKhachHangGoiDen kieuKHGoiDen, LoaiCuocKhach loaiCuocKhach)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 )  ,                    
                    new SqlParameter("@Vung",SqlDbType.Int )  , 
                    new SqlParameter("@SoLuongXe",SqlDbType.Int )  , 
                    new SqlParameter("@LoaiXe",SqlDbType.NVarChar,50 )  ,         
                    new SqlParameter("@IsCuocGiaLap",SqlDbType.Bit )  ,        //5
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int )  ,  
                    new SqlParameter("@KieuCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LoaiCuocKhach",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char  )  ,      // 10
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar ,50 )  , 
                    new SqlParameter("@ThoiGianChuyenTongDai",SqlDbType.Int  ) ,
                    new SqlParameter("@KinhDo", SqlDbType.Float ),
                    new SqlParameter("@ViDo", SqlDbType.Float),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11), // phuc vu cho goi lai cap nhat solangoi
                    new SqlParameter("@DanhSachXe_DeCu",SqlDbType.VarChar,250),
                    new SqlParameter("@DanhSachXe_DeCu_TD",SqlDbType.VarChar,250),
                    new SqlParameter("@XeDon",SqlDbType.VarChar,100),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Int)
           };
            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = diaChiDonKhach;
            parameters[2].Value = vung;
            parameters[3].Value = soLuongXe;
            parameters[4].Value = loaiXe;
            parameters[5].Value = 0;
            parameters[6].Value = (byte)trangThaiCuocGoi;
            parameters[7].Value = (int)kieuCuocGoi;
            parameters[8].Value = (int)loaiCuocKhach;
            parameters[9].Value = lenhDienThoai;
            parameters[10].Value = ((int)trangThaiLenh).ToString();
            parameters[11].Value = ghiChuDienThoai;
            parameters[12].Value = maNhanVienDienThoai;
            parameters[13].Value = thoiGianChuyenTongDai;
            parameters[14].Value = kinhDo;
            parameters[15].Value = viDo;
            parameters[16].Value = phoneNumber;
            parameters[17].Value = DanhSachXeDeCu;
            parameters[18].Value = DanhSachXeDeCu_TD;
            parameters[19].Value = xeDon;
            parameters[20].Value = (int)kieuKHGoiDen;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_CAPNHATCUOCGOI,
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool DIENTHOAI_UpdateThongTinCuocGoi_Mini(long IDCuocGoi, string diaChiDonKhach, string phoneNumber, int vung, string loaiXe, int soLuongXe,
                                                    TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
                                                    TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
                                                    int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD, string xeDon, KieuKhachHangGoiDen kieuKHGoiDen
            , string xeNhan, string xeDenDiem, LoaiCuocKhach loaiCuocKhach)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 )  ,                    
                    new SqlParameter("@Vung",SqlDbType.Int )  , 
                    new SqlParameter("@SoLuongXe",SqlDbType.Int )  , 
                    new SqlParameter("@LoaiXe",SqlDbType.NVarChar,50 )  ,         
                    new SqlParameter("@IsCuocGiaLap",SqlDbType.Bit )  ,        //5
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int )  ,  
                    new SqlParameter("@KieuCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LoaiCuocKhach",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char  )  ,      // 10
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar ,50 )  , 
                    new SqlParameter("@ThoiGianChuyenTongDai",SqlDbType.Int  ) ,
                    new SqlParameter("@KinhDo", SqlDbType.Float ),
                    new SqlParameter("@ViDo", SqlDbType.Float),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11), // phuc vu cho goi lai cap nhat solangoi
                    new SqlParameter("@DanhSachXe_DeCu",SqlDbType.VarChar,250),
                    new SqlParameter("@DanhSachXe_DeCu_TD",SqlDbType.VarChar,250),
                    new SqlParameter("@XeDon",SqlDbType.VarChar,100),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Int),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,100),
                    new SqlParameter("@XeDenDiem",SqlDbType.VarChar,100)
           };
            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = diaChiDonKhach;
            parameters[2].Value = vung;
            parameters[3].Value = soLuongXe;
            parameters[4].Value = loaiXe;
            parameters[5].Value = 0;
            parameters[6].Value = (byte)trangThaiCuocGoi;
            parameters[7].Value = (int)kieuCuocGoi;
            parameters[8].Value = (int)loaiCuocKhach;
            parameters[9].Value = lenhDienThoai;
            parameters[10].Value = ((int)trangThaiLenh).ToString();
            parameters[11].Value = ghiChuDienThoai;
            parameters[12].Value = maNhanVienDienThoai;
            parameters[13].Value = thoiGianChuyenTongDai;
            parameters[14].Value = kinhDo;
            parameters[15].Value = viDo;
            parameters[16].Value = phoneNumber;
            parameters[17].Value = DanhSachXeDeCu;
            parameters[18].Value = DanhSachXeDeCu_TD;
            parameters[19].Value = xeDon;
            parameters[20].Value = (int)kieuKHGoiDen;
            parameters[21].Value = xeNhan;
            parameters[22].Value = xeDenDiem;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool DIENTHOAI_UpdateThongTinCuocGoi_EnVang(long IDCuocGoi, string diaChiDonKhach, string phoneNumber, int vung, string loaiXe, int soLuongXe,
                                                    TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
                                                    TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
                                                    int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD,
            string xeDon, KieuKhachHangGoiDen kieuKHGoiDen, LoaiCuocKhach loaiCuocKhach, float GPS_ViDo_Tra, float GPS_KinhDo_Tra)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 )  ,                    
                    new SqlParameter("@Vung",SqlDbType.Int )  , 
                    new SqlParameter("@SoLuongXe",SqlDbType.Int )  , 
                    new SqlParameter("@LoaiXe",SqlDbType.NVarChar,50 )  ,         
                    new SqlParameter("@IsCuocGiaLap",SqlDbType.Bit )  ,        //5
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int )  ,  
                    new SqlParameter("@KieuCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LoaiCuocKhach",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char  )  ,      // 10
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar ,50 )  , 
                    new SqlParameter("@ThoiGianChuyenTongDai",SqlDbType.Int  ) ,
                    new SqlParameter("@KinhDo", SqlDbType.Float ),
                    new SqlParameter("@ViDo", SqlDbType.Float),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11), // phuc vu cho goi lai cap nhat solangoi
                    new SqlParameter("@DanhSachXe_DeCu",SqlDbType.VarChar,250),
                    new SqlParameter("@DanhSachXe_DeCu_TD",SqlDbType.VarChar,250),
                    new SqlParameter("@XeDon",SqlDbType.VarChar,100),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Int),
                    new SqlParameter("@GPS_ViDo_Tra",SqlDbType.Float),
                    new SqlParameter("@GPS_KinhDo_Tra",SqlDbType.Float)
           };
            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = diaChiDonKhach;
            parameters[2].Value = vung;
            parameters[3].Value = soLuongXe;
            parameters[4].Value = loaiXe;
            parameters[5].Value = 0;
            parameters[6].Value = (byte)trangThaiCuocGoi;
            parameters[7].Value = (int)kieuCuocGoi;
            parameters[8].Value = (int)loaiCuocKhach;
            parameters[9].Value = lenhDienThoai;
            parameters[10].Value = ((int)trangThaiLenh).ToString();
            parameters[11].Value = ghiChuDienThoai;
            parameters[12].Value = maNhanVienDienThoai;
            parameters[13].Value = thoiGianChuyenTongDai;
            parameters[14].Value = kinhDo;
            parameters[15].Value = viDo;
            parameters[16].Value = phoneNumber;
            parameters[17].Value = DanhSachXeDeCu;
            parameters[18].Value = DanhSachXeDeCu_TD;
            parameters[19].Value = xeDon;
            parameters[20].Value = (int)kieuKHGoiDen;
            parameters[21].Value = GPS_ViDo_Tra;
            parameters[22].Value = GPS_KinhDo_Tra;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_CAPNHATCUOCGOI_Envang,
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        /// <summary>
        /// hamf thuực hiện nhận dữ liệu tổng đài mới thay đổi
        /// </summary>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="thoiDiemNhanDulieuTruoc"></param>
        /// <returns></returns>
        public List<CuocGoiTongDaiCapNhatType> DIENTHOAI_LayDSCuocGoiThayDoiByTongDai(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            List<CuocGoiTongDaiCapNhatType> retListCuocGoiTD = new List<CuocGoiTongDaiCapNhatType>();

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
            };
            parameters[0].Value = linesDuocCapPhep;
            parameters[1].Value = thoiDiemNhanDulieuTruoc;

            using (SqlDataReader sdrCuocGoi = SqlHelper.ExecuteReader(g_sqlCon, SP_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGOICAPNHATBYTONGDAI, parameters))
            {
                while (sdrCuocGoi.Read())
                {
                    //[ID] [TrangThaiCuocGoi] ,  ,[LenhTongDai] ,[TrangThaiLenh]  ,[GhiChuTongDai] ,[MaNhanVienTongDai]
                    //,[XeNha n] ,[XeDon] ,[DiaChiTraKhach] ,[ThoiGianChuyenTongDai] ,[ThoiGianDieuXe] 
                    //,[FileVoicePath]  ,[FK_VungID] ,[CoGPS] ,[GPS_KinhDo] ,[GPS_ViDo]  ,[DanhSachXe_DeCu] ,[ThoiDiemCapNhatXeDeCu] , ,[ThoiDiemCapNhat]
                    long idCuocGoi = sdrCuocGoi["ID"] == DBNull.Value ? 0 : Convert.ToInt64(sdrCuocGoi["ID"].ToString());
                    TrangThaiCuocGoiTaxi trangThaiCG = sdrCuocGoi["TrangThaiCuocGoi"] == null ? TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh : (TrangThaiCuocGoiTaxi)int.Parse(sdrCuocGoi["TrangThaiCuocGoi"].ToString());
                    string lenhTongDai = sdrCuocGoi["LenhTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["LenhTongDai"].ToString();
                    TrangThaiLenhTaxi trangThaiLenh = sdrCuocGoi["TrangThaiLenh"] == DBNull.Value ? TrangThaiLenhTaxi.KhongTruyenDi : (TrangThaiLenhTaxi)int.Parse(sdrCuocGoi["TrangThaiLenh"].ToString());
                    string ghiChuTD = sdrCuocGoi["GhiChuTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["GhiChuTongDai"].ToString();
                    string nvTD = sdrCuocGoi["MaNhanVienTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["MaNhanVienTongDai"].ToString();

                    string lenhDT = sdrCuocGoi["LenhDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["LenhDienThoai"].ToString();
                    string ghiChuDT = sdrCuocGoi["GhiChuDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["GhiChuDienThoai"].ToString();
                    string nvDT = sdrCuocGoi["MaNhanVienDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["MaNhanVienDienThoai"].ToString();

                    string xeNhan = sdrCuocGoi["XeNhan"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeNhan"].ToString();
                    int thoigianDieuXe = sdrCuocGoi["ThoiGianDieuXe"] == DBNull.Value ? 0 : int.Parse(sdrCuocGoi["ThoiGianDieuXe"].ToString());
                    string filePath = sdrCuocGoi["FileVoicePath"] == DBNull.Value ? string.Empty : sdrCuocGoi["FileVoicePath"].ToString();
                    int vungGPSID = sdrCuocGoi["FK_VungID"] == DBNull.Value ? 0 : int.Parse(sdrCuocGoi["FK_VungID"].ToString());
                    double gpsKinhDo = sdrCuocGoi["GPS_KinhDo"] == DBNull.Value ? 0 : double.Parse(sdrCuocGoi["GPS_KinhDo"].ToString());
                    double gpsViDo = sdrCuocGoi["GPS_ViDo"] == DBNull.Value ? 0 : double.Parse(sdrCuocGoi["GPS_ViDo"].ToString());
                    string dsXeDeCu = sdrCuocGoi["DanhSachXe_DeCu"] == DBNull.Value ? string.Empty : sdrCuocGoi["DanhSachXe_DeCu"].ToString();
                    DateTime thoiDiemDeCu = sdrCuocGoi["ThoiDiemCapNhatXeDeCu"] == DBNull.Value ? new DateTime(1900, 01, 01, 0, 0, 0) : DateTime.Parse(sdrCuocGoi["ThoiDiemCapNhatXeDeCu"].ToString());
                    string lenhMoiKhach = sdrCuocGoi["MOIKHACH_LenhMoiKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["MOIKHACH_LenhMoiKhach"].ToString();
                    string XeDenDiem = sdrCuocGoi["XeDenDiem"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiem"].ToString();
                    string XeDenDiemDonKhach = sdrCuocGoi["XeDenDiemDonKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiemDonKhach"].ToString();

                    retListCuocGoiTD.Add(new CuocGoiTongDaiCapNhatType(idCuocGoi, trangThaiCG, lenhTongDai, ghiChuTD, lenhDT, ghiChuDT, nvTD, nvDT, xeNhan, thoigianDieuXe, filePath, vungGPSID, gpsKinhDo, gpsViDo, dsXeDeCu, thoiDiemDeCu, trangThaiLenh, lenhMoiKhach, XeDenDiem, XeDenDiemDonKhach));
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return retListCuocGoiTD;
        }

        public DataTable DIENTHOAI_LayDSCuocGoiMoi_V3(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
                };
            if (!string.IsNullOrEmpty(lineChoPhep))
            {
                parameters[0].Value = lineChoPhep;
            }

            parameters[1].Value = thoiDiemLayTruoc;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGIOMOI, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }

        public DataTable DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,150), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
            };
            parameters[0].Value = linesDuocCapPhep;
            parameters[1].Value = thoiDiemNhanDulieuTruoc;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERATION_LAYDSCUOCGOICAPNHATBYTONGDAI, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy danh sách cuộc gọi thay đổi theo tổng đài
        /// </summary>
        /// <param name="linesDuocCapPhep">The lines duoc cap phep.</param>
        /// <param name="thoiDiemNhanDulieuTruoc">The thoi diem nhan dulieu truoc.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/28/2015   created
        /// </Modified>
        public DataTable DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V4(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
            };
            parameters[0].Value = linesDuocCapPhep;
            parameters[1].Value = thoiDiemNhanDulieuTruoc;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V4_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// hàm thực hiện chèn cuộc giả lập
        /// trả về ÌD của cuộc gọi
        /// </summary>
        /// <param name="line"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="diaChi"></param>
        /// <param name="kieuKhachGoi"></param>
        /// <param name="trangThaiLenh"></param>
        /// <param name="NVDienThoai"></param>
        /// <returns></returns>
        public long DIENTHOAI_ChenMotCuocGiaLap(int line, string phoneNumber, string diaChi, KieuKhachHangGoiDen kieuKhachGoi,
                                                TrangThaiLenhTaxi trangThaiLenh, string NVDienThoai)
        {
            long idCuocGoi = -1;
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }


            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.Int ),            //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,15 )  , 
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@LoaiKhachHang",SqlDbType.Int )  , 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int )  ,         
                    new SqlParameter("@NVDienThoai",SqlDbType.NVarChar,50 )  ,        //5
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt )   
           };

            parameters[0].Value = line;
            parameters[1].Value = phoneNumber;
            parameters[2].Value = diaChi;
            parameters[3].Value = kieuKhachGoi;
            parameters[4].Value = trangThaiLenh;

            parameters[5].Value = NVDienThoai;
            parameters[6].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERAtiON_CHENCUOCGOIGIALAP,
                                                       parameters);
            if (parameters[6].Value != null)
            {
                idCuocGoi = Convert.ToInt64(parameters[6].Value.ToString());
            }

            g_sqlCon.Close();
            return idCuocGoi;
        }

        /// <summary>
        /// hàm thực hiện chèn cuộc giả lập - co them ghi chu (khach VIP)
        /// trả về ÌD của cuộc gọi
        /// </summary>
        public long DIENTHOAI_ChenMotCuocGiaLap2(int line, string phoneNumber, string diaChi, KieuKhachHangGoiDen kieuKhachGoi,
                                                TrangThaiLenhTaxi trangThaiLenh, string NVDienThoai, string GhiChu)
        {
            long idCuocGoi = -1;
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }


            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.Int ),            //0
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,15 )  , 
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@LoaiKhachHang",SqlDbType.Int )  , 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int )  ,         
                    new SqlParameter("@NVDienThoai",SqlDbType.NVarChar,50 )  ,        //5
                    new SqlParameter("@ID_DieuHanh",SqlDbType.BigInt ) ,  
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar,250 ) 
           };

            parameters[0].Value = line;
            parameters[1].Value = phoneNumber;
            parameters[2].Value = diaChi;
            parameters[3].Value = kieuKhachGoi;
            parameters[4].Value = trangThaiLenh;

            parameters[5].Value = NVDienThoai;
            parameters[6].Direction = ParameterDirection.Output;
            parameters[7].Value = GhiChu;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_T_TAXIOPERAtiON_CHENCUOCGOIGIALAP2,
                                                       parameters);
            if (parameters[6].Value != null)
            {
                idCuocGoi = Convert.ToInt64(parameters[6].Value.ToString());
            }

            g_sqlCon.Close();
            return idCuocGoi;
        }

        /// <summary>
        /// hàm thực hiện update thông tin cuộc gọi phía điện thoại
        /// </summary>
        public bool DIENTHOAI_UpdateDSXeDeCu(long IDCuocGoi, string DSXeDeCu, string DSXeDeCu_TD)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
                g_sqlCon.Open();

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@DanhSachXe_DeCu",SqlDbType.VarChar,50 ),
                    new SqlParameter("@DanhSachXe_DeCu_TD",SqlDbType.VarChar,250 )};
            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = DSXeDeCu;
            parameters[2].Value = DSXeDeCu_TD;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_SP_T_TAXIOPERATION_UPDATE_DSXEDECU,
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        /// <summary>
        /// Hàm kiểm tra xem bảng T_Taxioperation có vượt quá giới hạn cuộc gọi không.
        /// </summary>
        /// <returns>true : có</returns>
        public bool DIENTHOAI_CheckCuocGoiLimit()
        {
            if (g_sqlCon.State == ConnectionState.Closed)
                g_sqlCon.Open();

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@return",SqlDbType.Bit)};
            parameters[0].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_DIENTHOAI_SP_T_TAXIOPERATION_COUNT_LIMIT,
                                                       parameters);
            g_sqlCon.Close();
            return Convert.ToBoolean(parameters[0].Value);
        }

        /// <summary>
        /// Cập nhật cuộc gọi đã giải quyết thành cuộc gọi chưa giải quyết
        /// </summary>
        /// <param name="IDCuocGoi"></param>
        /// <returns></returns>
        public bool DIENTHOAI_UpdateCGKetThuc2ChuaGiaiQuyet(long IDCuocGoi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
                g_sqlCon.Open();

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),
                    new SqlParameter("@OUTPUT",SqlDbType.VarChar,50 )};
            parameters[0].Value = IDCuocGoi;
            parameters[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_T_TAXIOPERATION_KETTHUC_UPDATE_STATUS,
                                                       parameters);
            g_sqlCon.Close();
            return Convert.ToInt32(parameters[1].Value) > 0;
        }

        public int DIENTHOAI_DemCuocGoiDonDuoc(DateTime tuNgay, DateTime denNgay, string maNhanVien)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@TuNgay",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                    new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50 ),
                    new SqlParameter("@RowCount",SqlDbType.Int )
                };

            parameters[0].Value = tuNgay;
            parameters[1].Value = denNgay;
            parameters[2].Value = maNhanVien;
            parameters[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY_DTV, parameters);
            g_sqlCon.Close();
            return Convert.ToInt32(parameters[3].Value);
        }

        public DataTable DIENTHOAI_LayDSCuocGoiDangGiaiQuyet(string Vung, string SoDT, string DiaChi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Kenh",SqlDbType.VarChar,10), 
                    new SqlParameter("@SoDT",SqlDbType.NVarChar,15 ),
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50 )
                };
            parameters[0].Value = Vung;
            parameters[1].Value = SoDT;
            parameters[2].Value = DiaChi;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "OP_SP_TAXIOPERATION_GETBYSEARCH", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }
        public DataTable DIENTHOAI_LayDSCuocGoiDangGiaiQuyet_V2(string Vung, string SoDT, string DiaChi, string XeNhan)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Kenh",SqlDbType.VarChar,10), 
                    new SqlParameter("@SoDT",SqlDbType.NVarChar,15 ),
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50 ),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,50 )
                };
            parameters[0].Value = Vung;
            parameters[1].Value = SoDT;
            parameters[2].Value = DiaChi;
            parameters[3].Value = XeNhan;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "OP_SP_TAXIOPERATION_GETBYSEARCH_V2", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }
        public DataTable DIENTHOAI_LayDSCuocGoiDangGiaiQuyet_TC(string Vung, string SoDT, string DiaChi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Kenh",SqlDbType.VarChar,10), 
                    new SqlParameter("@SoDT",SqlDbType.NVarChar,15 ),
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50 )
                };
            parameters[0].Value = Vung;
            parameters[1].Value = SoDT;
            parameters[2].Value = DiaChi;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "OP_SP_TAXIOPERATION_GETBYSEARCH_THANHCONG", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }
        public bool BANTINGIA_Insert_CuocGoi_Chen(string Line, string PhoneNumber, string DiaChiDonKhach, KieuKhachHangGoiDen KieuKhachHangGoiDen, TrangThaiCuocGoiTaxi TrangThaiCuocGoi, TrangThaiLenhTaxi TrangThaiLenh, float KinhDo, float ViDo, string MaDoiTac
                                                    , int vung, string loaiXe, int soLuongXe,
                                                    KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
                                                    string maNhanVienDienThoai,
                                                    string DanhSachXeDeCu, string DanhSachXeDeCu_TD)
        {
            try
            {
                if (g_sqlCon.State == ConnectionState.Closed)
                {
                    g_sqlCon.Open();
                }

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Line",SqlDbType.VarChar ,2 ),
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11 ),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar, 255 ),
                    new SqlParameter("@KieuKhachHangGoiDen",SqlDbType.Char ,1 ),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Char ,1 ),     
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1  ),
                    new SqlParameter("@GPS_KinhDo",SqlDbType.Float),
                    new SqlParameter("@GPS_ViDo",SqlDbType.Float),
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@Vung",SqlDbType.Int )  , 
                    new SqlParameter("@SoLuongXe",SqlDbType.Int )  , 
                    new SqlParameter("@LoaiXe",SqlDbType.NVarChar,50 )  ,         
                    new SqlParameter("@IsCuocGiaLap",SqlDbType.Bit )  ,        //5
                    new SqlParameter("@KieuCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LoaiCuocKhach",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar ,50 )  , 
                    new SqlParameter("@DanhSachXe_DeCu",SqlDbType.VarChar,250),
                    new SqlParameter("@DanhSachXe_DeCu_TD",SqlDbType.VarChar,250),
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt)
                };
                parameters[0].Value = Line;
                parameters[1].Value = PhoneNumber;
                parameters[2].Value = DiaChiDonKhach;
                parameters[3].Value = ((int)KieuKhachHangGoiDen).ToString();
                parameters[4].Value = ((int)TrangThaiCuocGoi).ToString();
                parameters[5].Value = ((int)TrangThaiLenh).ToString();
                parameters[6].Value = KinhDo;
                parameters[7].Value = ViDo;
                parameters[8].Value = MaDoiTac;
                parameters[9].Value = vung;
                parameters[10].Value = soLuongXe;
                parameters[11].Value = loaiXe;
                parameters[12].Value = 1;
                parameters[13].Value = (int)kieuCuocGoi;
                parameters[14].Value = (int)LoaiCuocKhach.ChoKhachNoiTinh;
                parameters[15].Value = lenhDienThoai;
                parameters[16].Value = maNhanVienDienThoai;
                parameters[17].Value = DanhSachXeDeCu;
                parameters[18].Value = DanhSachXeDeCu_TD;

                int roweff = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_sp_T_TAXIOPERATION_Insert_BanTinGia", parameters);
                g_sqlCon.Close();
                return roweff > 0;
            }
            catch 
            {
                return false;
            }
        }

        public bool BANTINGIA_UpdateThongTinCuocGoi(long IDCuocGoi, string diaChiDonKhach, int vung, string loaiXe, int soLuongXe,
                                                   TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
                                                   TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
                                                   int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD, string NoiDungXuLy, bool isDaXuLy, string BTBG_NhanVien)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            //       @NoiDungXuLy NVARCHAR(255),
            //@IsDaXuLy BIT,
            //@BTBG_NhanVien nvarchar(50)
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 )  ,                    
                    new SqlParameter("@Vung",SqlDbType.Int )  , 
                    new SqlParameter("@SoLuongXe",SqlDbType.Int )  , 
                    new SqlParameter("@LoaiXe",SqlDbType.NVarChar,50 )  ,         
                    new SqlParameter("@IsCuocGiaLap",SqlDbType.Bit )  ,        //5
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int )  ,  
                    new SqlParameter("@KieuCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LoaiCuocKhach",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char  )  ,      // 10
                    new SqlParameter("@GhiChuDienThoai",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar ,50 )  , 
                    new SqlParameter("@ThoiGianChuyenTongDai",SqlDbType.Int  ) ,
                    new SqlParameter("@KinhDo", SqlDbType.Float ),
                    new SqlParameter("@ViDo", SqlDbType.Float),
                    new SqlParameter("@DanhSachXe_DeCu",SqlDbType.VarChar,250),
                    new SqlParameter("@DanhSachXe_DeCu_TD",SqlDbType.VarChar,250),
                    new SqlParameter("@NoiDungXuLy",SqlDbType.NText),
                    new SqlParameter("@IsDaXuLy",SqlDbType.Bit),
                    new SqlParameter("@BTBG_NhanVien",SqlDbType.VarChar,50)
           };
            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = diaChiDonKhach;
            parameters[2].Value = vung;
            parameters[3].Value = soLuongXe;
            parameters[4].Value = loaiXe;

            parameters[5].Value = 0;
            parameters[6].Value = (byte)trangThaiCuocGoi;
            parameters[7].Value = (int)kieuCuocGoi;
            parameters[8].Value = (int)LoaiCuocKhach.ChoKhachNoiTinh;
            parameters[9].Value = lenhDienThoai;
            parameters[10].Value = ((int)trangThaiLenh).ToString();

            parameters[11].Value = ghiChuDienThoai;
            parameters[12].Value = maNhanVienDienThoai;
            parameters[13].Value = thoiGianChuyenTongDai;
            parameters[14].Value = kinhDo;
            parameters[15].Value = viDo;

            parameters[16].Value = DanhSachXeDeCu;
            parameters[17].Value = DanhSachXeDeCu_TD;
            parameters[18].Value = NoiDungXuLy;
            parameters[19].Value = isDaXuLy;
            parameters[20].Value = BTBG_NhanVien;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_BANTINGIA_spT_TAXIOPERATION_CapNhatCuocGoi", parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }


        public DataTable BANTINGIA_LayAllCuocGoi(string vungsDuocCapPhep, string linesDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar ,50)
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = linesDuocCapPhep;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_BANTINGIA_spT_TAXIOPERATION_LayAllOfVungChoPhep", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public bool UpdateCuocGoiKhieuNaiKetThuc(long IDCuocGoi, string noiDungPA, string maNhanVienDienThoai)
        {
            try
            {
                if (g_sqlCon.State == ConnectionState.Closed)
                {
                    g_sqlCon.Open();
                }
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt  ), //0
                     new SqlParameter("@NoiDung",SqlDbType.NVarChar,250  ) ,
                     new SqlParameter("@MaNhanVienDienThoai",SqlDbType.NVarChar,50)
                };
                parameters[0].Value = IDCuocGoi;
                parameters[1].Value = noiDungPA;
                parameters[2].Value = maNhanVienDienThoai;
                int rowAffected = SqlHelper.ExecuteNonQuery(g_sqlCon, "sp_T_TAXIOPERATION_Update_CuocGoiGuiBanKhachHang", parameters);
                g_sqlCon.Open();
                return (rowAffected > 0);

            }
            catch 
            {
                return false;
            }
        }

        #endregion DienThoai Module

        #region ================================== Hàm xử lý cho phần tổng đài ==================================

        /// <summary>
        /// hàm trả về thông tin tất cả cuộc gọi theo vùng
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <returns></returns>
        public DataSet TONGDAI_LayAllCuocGoi(string vungsDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50)
           };
            parameters[0].Value = vungsDuocCapPhep;
            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                SP_TONGDAI_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP = "V3_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep_V3";
            else
                SP_TONGDAI_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP = "V3_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep_V4";

            DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP, parameters);
            //using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP, parameters))
            //{
            g_sqlCon.Close();
            //    if (ds.Tables != null && ds.Tables.Count > 0)
            //    {
            //        return ds.Tables[0];
            //    }
            //}
            return ds;
        }

        public DataTable TONGDAI_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int)
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        /// <summary>
        /// hàm lấy cuộc gọi mới thay đổi phía điện thoại truyền sang tổng đài
        /// </summary>
        public List<CuocGoiEntity> TONGDAI_LayCuocGoiMoiTuDienThoai(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            List<CuocGoiEntity> retListCuocGoiDT = new List<CuocGoiEntity>();

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayDuLieuLanTruoc",SqlDbType.DateTime )                   
            };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = thoiDiemLayDuLieuTruoc;
            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "V3_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_ChuaNhan";
            else
                SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "V3_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_V2";

            using (SqlDataReader sdrCuocGoi = SqlHelper.ExecuteReader(g_sqlCon, SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI, parameters))
            {
                while (sdrCuocGoi.Read())
                {
                    //  [ID] ,Line , ThoiDiemGoi,PhoneNumber ,SoLanGoi,[DiaChiDonKhach] ,[Vung] ,[LoaiXe] ,[SoLuongXe] ,[LoaiKhachHang]  ,[IsCuocGiaLap] 
                    // ,[KieuCuocGoi] ,[LenhDienThoai]  ,[TrangThaiLenh] ,[GhiChuDienThoai] ,[MaNhanVienDienThoai] 
                    //    ,[ThoiGianChuyenTongDai]    ,[DanhSachXe_DeCu] ,[ThoiDiemCapNhatXeDeCu] 
                    long idCuocGoi = sdrCuocGoi["ID"] == DBNull.Value ? 0 : Convert.ToInt64(sdrCuocGoi["ID"].ToString());
                    DateTime thoiDiemGoi = sdrCuocGoi["ThoiDiemGoi"] == DBNull.Value ? DateTime.Now : DateTime.Parse(sdrCuocGoi["ThoiDiemGoi"].ToString());
                    int line = sdrCuocGoi["Line"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["Line"].ToString());
                    string phoneNumber = sdrCuocGoi["PhoneNumber"] == DBNull.Value ? "00000000" : sdrCuocGoi["PhoneNumber"].ToString();
                    int soLan = sdrCuocGoi["SoLanGoi"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["SoLanGoi"].ToString());
                    string diachi = sdrCuocGoi["DiaChiDonKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["DiaChiDonKhach"].ToString();
                    int vung = sdrCuocGoi["Vung"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["Vung"].ToString());
                    string loaiXe = sdrCuocGoi["LoaiXe"] == DBNull.Value ? string.Empty : sdrCuocGoi["LoaiXe"].ToString();
                    int soLuongXe = sdrCuocGoi["SoLuong"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["SoLuong"].ToString());
                    KieuKhachHangGoiDen loaiKhachHang = sdrCuocGoi["KieuKhachHangGoiDen"] == DBNull.Value ? KieuKhachHangGoiDen.KhachHangBinhThuong : (KieuKhachHangGoiDen)(int.Parse(sdrCuocGoi["KieuKhachHangGoiDen"].ToString()));
                    bool isCuocGiaLap = sdrCuocGoi["IsCuocGiaLap"] != DBNull.Value && bool.Parse(sdrCuocGoi["IsCuocGiaLap"].ToString());
                    KieuCuocGoi kieuCG = sdrCuocGoi["KieuCuocGoi"] == DBNull.Value ? KieuCuocGoi.TrangThaiKhac : (KieuCuocGoi)(int.Parse(sdrCuocGoi["KieuCuocGoi"].ToString()));
                    string lenhDienThoai = sdrCuocGoi["LenhDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["LenhDienThoai"].ToString();
                    string ghiChuDT = sdrCuocGoi["GhiChuDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["GhiChuDienThoai"].ToString();
                    TrangThaiLenhTaxi trangThaiLenh = sdrCuocGoi["TrangThaiLenh"] == DBNull.Value ? TrangThaiLenhTaxi.KhongTruyenDi : (TrangThaiLenhTaxi)int.Parse(sdrCuocGoi["TrangThaiLenh"].ToString());
                    string nvDT = sdrCuocGoi["MaNhanVienDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["MaNhanVienDienThoai"].ToString();

                    string lenhTD = sdrCuocGoi["LenhTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["LenhTongDai"].ToString();
                    string ghiChuTD = sdrCuocGoi["GhiChuTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["GhiChuTongDai"].ToString();
                    string nvTD = sdrCuocGoi["MaNhanVienTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["MaNhanVienTongDai"].ToString();

                    int thoiGianChuyenTongDai = sdrCuocGoi["ThoiDiemChuyenTongDai"] == DBNull.Value ? 0 : int.Parse(sdrCuocGoi["ThoiDiemChuyenTongDai"].ToString());
                    string dsXeDeCu = sdrCuocGoi["DanhSachXe_DeCu"] == DBNull.Value ? string.Empty : sdrCuocGoi["DanhSachXe_DeCu"].ToString();
                    string dsXeDeCu_TD = sdrCuocGoi["DanhSachXe_DeCu_TD"] == DBNull.Value ? string.Empty : sdrCuocGoi["DanhSachXe_DeCu_TD"].ToString();
                    double KD = sdrCuocGoi["GPS_KinhDo"] == DBNull.Value ? 1 : double.Parse(sdrCuocGoi["GPS_KinhDo"].ToString());
                    double VD = sdrCuocGoi["GPS_ViDo"] == DBNull.Value ? 1 : double.Parse(sdrCuocGoi["GPS_ViDo"].ToString());
                    DateTime thoiDiemDeCu = sdrCuocGoi["ThoiDiemCapNhatXeDeCu"] == DBNull.Value ? new DateTime(1900, 01, 01, 0, 0, 0) : DateTime.Parse(sdrCuocGoi["ThoiDiemCapNhatXeDeCu"].ToString());
                    string xeNhan = sdrCuocGoi["XeNhan"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeNhan"].ToString();
                    string xeNhanTD = sdrCuocGoi["XeNhan_TD"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeNhan_TD"].ToString();

                    string lenhMoiKhach = sdrCuocGoi["MOIKHACH_LenhMoiKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["MOIKHACH_LenhMoiKhach"].ToString();
                    string nvMoiKhach = sdrCuocGoi["MOIKHACH_NhanVien"] == DBNull.Value ? string.Empty : sdrCuocGoi["MOIKHACH_NhanVien"].ToString();
                    string xeDenDiem = sdrCuocGoi["XeDenDiem"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiem"].ToString();
                    string xeDenDiemDonKhach = sdrCuocGoi["XeDenDiemDonKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiemDonKhach"].ToString();
                    string xeDenDiemDonKhach_TD = sdrCuocGoi["XeDenDiemDonKhach_TD"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiemDonKhach_TD"].ToString();
                    //string cuocGoiLaiIDs = sdrCuocGoi["CuocGoiLaiIDs"] == DBNull.Value ? string.Empty : sdrCuocGoi["CuocGoiLaiIDs"].ToString();

                    retListCuocGoiDT.Add(new CuocGoiEntity(idCuocGoi, thoiDiemGoi, line, phoneNumber, soLan, diachi, vung, loaiXe, soLuongXe, loaiKhachHang, isCuocGiaLap, kieuCG, lenhDienThoai, ghiChuDT, lenhTD, ghiChuTD, trangThaiLenh, nvDT, nvTD, thoiGianChuyenTongDai, dsXeDeCu, thoiDiemDeCu, dsXeDeCu_TD, KD, VD, xeNhan, xeNhanTD, lenhMoiKhach, nvMoiKhach, xeDenDiem, xeDenDiemDonKhach, xeDenDiemDonKhach_TD));
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return retListCuocGoiDT;
        }

        /// <summary>
        /// Lấy các cuộc điện thoại mà tổng đài viên đã nhận xử lý.
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public DataTable TONGDAI_LayCuocGoiDaNhanXuLy(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@ThoiDiemLayDuLieuLanTruoc",SqlDbType.DateTime)
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = thoiDiemLayDuLieuTruoc;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhan", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        /// <summary>
        /// ham thu hien cap nhat thong tin tong dai cap nhan vao cuoc goi
        /// </summary>
        /// <returns>True : thanh cong, False : khong thanh cong</returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Congt       22/07/11        Created
        /// </Modified>
        public bool TONGDAI_UpdateThongTinCuocGoi(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                                  string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                                  string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                                  int thoigianDonKhach, bool chuyenMK, string xeDenDiem)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhTongDai",SqlDbType.NVarChar,255),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int),
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar,255),  //4
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,100),
                    new SqlParameter("@XeDon",SqlDbType.VarChar ,100 ),
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar,255),
                    new SqlParameter("@ThoiGianDieuXe",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDonKhach",SqlDbType.Int) ,           //10
                    new SqlParameter("@ChuyenMK",SqlDbType.Bit) ,           //10
                    new SqlParameter("@XeDenDiem",SqlDbType.VarChar, 255)
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = (int)trangThaiCuocGoiTaxi;
            parameters[2].Value = lenhTongDai;
            parameters[3].Value = (int)trangThaiLenhTaxi;
            parameters[4].Value = ghiChuTongDai;
            parameters[5].Value = idNVTD;
            parameters[6].Value = xeNhan;
            parameters[7].Value = xeDon;
            parameters[8].Value = diaChiTraKhach;
            parameters[9].Value = thoiGianDieuXe;
            parameters[10].Value = thoigianDonKhach;
            parameters[11].Value = chuyenMK;
            parameters[12].Value = xeDenDiem;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_T_TAXIOPERATION_UPDATECUOCGOI,
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }
        public bool TONGDAI_UpdateThongTinCuocGoi_BanCo(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                                string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                                string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                                int thoigianDonKhach, bool chuyenMK, string xeDenDiem)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhTongDai",SqlDbType.NVarChar,255),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int),
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar,255),  //4
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,100),
                    new SqlParameter("@XeDon",SqlDbType.VarChar ,100 ),
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar,255),
                    new SqlParameter("@ThoiGianDieuXe",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDonKhach",SqlDbType.Int) ,           //10
                    new SqlParameter("@ChuyenMK",SqlDbType.Bit) ,           //10
                    new SqlParameter("@XeDenDiem",SqlDbType.VarChar, 255)
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = (int)trangThaiCuocGoiTaxi;
            parameters[2].Value = lenhTongDai;
            parameters[3].Value = (int)trangThaiLenhTaxi;
            parameters[4].Value = ghiChuTongDai;
            parameters[5].Value = idNVTD;
            parameters[6].Value = xeNhan;
            parameters[7].Value = xeDon;
            parameters[8].Value = diaChiTraKhach;
            parameters[9].Value = thoiGianDieuXe;
            parameters[10].Value = thoigianDonKhach;
            parameters[11].Value = chuyenMK;
            parameters[12].Value = xeDenDiem;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_T_TAXIOPERATION_UPDATECUOCGOI_BanCo,
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        /// <summary>
        /// ham thu hien cap nhat thong tin tong dai cap nhan vao cuoc goi
        /// </summary>
        /// <returns>True : thanh cong, False : khong thanh cong</returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Congt       22/07/11        Created
        /// </Modified>
        public bool TONGDAI_UpdateThongTinCuocGoi_EV(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                                  string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                                  string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                                  int thoigianDonKhach, bool chuyenMK, string xeDenDiem, bool KhongDungMobileService)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhTongDai",SqlDbType.NVarChar,255),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int),
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar,255),  //4
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,100),
                    new SqlParameter("@XeDon",SqlDbType.VarChar ,100 ),
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar,255),
                    new SqlParameter("@ThoiGianDieuXe",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDonKhach",SqlDbType.Int) ,           //10
                    new SqlParameter("@ChuyenMK",SqlDbType.Bit) ,           //10
                    new SqlParameter("@XeDenDiem",SqlDbType.VarChar, 255),           //10
                    new SqlParameter("@KhongDungMobileService",SqlDbType.Bit)
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = (int)trangThaiCuocGoiTaxi;
            parameters[2].Value = lenhTongDai;
            parameters[3].Value = (int)trangThaiLenhTaxi;
            parameters[4].Value = ghiChuTongDai;
            parameters[5].Value = idNVTD;
            parameters[6].Value = xeNhan;
            parameters[7].Value = xeDon;
            parameters[8].Value = diaChiTraKhach;
            parameters[9].Value = thoiGianDieuXe;
            parameters[10].Value = thoigianDonKhach;
            parameters[11].Value = chuyenMK;
            parameters[12].Value = xeDenDiem;
            parameters[13].Value = KhongDungMobileService;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_EV",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool TONGDAI_UpdateThongTinCuocGoi_V4(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                                  string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                                  string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                                  int thoigianDonKhach, bool chuyenMK, string xeDenDiem, string DiaChiDonKhach)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhTongDai",SqlDbType.NVarChar,255),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int),
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar,255),  //4
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,100),
                    new SqlParameter("@XeDon",SqlDbType.VarChar ,100 ),
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar,255),
                    new SqlParameter("@ThoiGianDieuXe",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDonKhach",SqlDbType.Int) ,           //10
                    new SqlParameter("@ChuyenMK",SqlDbType.Bit) ,           //10
                    new SqlParameter("@XeDenDiem",SqlDbType.VarChar, 255),
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255)
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = (int)trangThaiCuocGoiTaxi;
            parameters[2].Value = lenhTongDai;
            parameters[3].Value = (int)trangThaiLenhTaxi;
            parameters[4].Value = ghiChuTongDai;
            parameters[5].Value = idNVTD;
            parameters[6].Value = xeNhan;
            parameters[7].Value = xeDon;
            parameters[8].Value = diaChiTraKhach;
            parameters[9].Value = thoiGianDieuXe;
            parameters[10].Value = thoigianDonKhach;
            parameters[11].Value = chuyenMK;
            parameters[12].Value = xeDenDiem;
            parameters[13].Value = DiaChiDonKhach;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V4_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        /// <summary>
        /// Nhan vien tong dai tiep nhan xu ly
        /// </summary>
        public bool TONGDAI_UpdateThongTinCuocGoi_NhanXuLy(long idCuocGoi, string idNVTD, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi, TrangThaiLenhTaxi trangThaiLenhTaxi)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int)
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = idNVTD;
            parameters[2].Value = (int)trangThaiCuocGoiTaxi;
            parameters[3].Value = (int)trangThaiLenhTaxi;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_NhanXuLy",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_TatCa(string VungChoPhep, string idNVTD)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),            
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50)};

            parameters[0].Value = VungChoPhep;
            parameters[1].Value = idNVTD;
            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_NhanXuLy_TatCa", parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool TONGDAI_UpdateThongTinCuocGoi_NhanXuLy_TheoID(string IDNhanXyLy, string idNVTD)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDNhanXuLy",SqlDbType.VarChar ,50),
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50)
            };

            parameters[0].Value = IDNhanXyLy;
            parameters[1].Value = idNVTD;
            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_NhanXuLy_ID",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        /// <summary>
        /// ham thu hien cap nhat thong tin tong dai cap nhan vao cuoc goi
        /// </summary>
        /// <returns>True : thanh cong, False : khong thanh cong</returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Congt       22/07/11        Created
        /// </Modified>
        public bool TONGDAI_UpdateChuyenVung(long idCuocGoi, string MaNhanVienTD, int Vung, string LenhTongDai)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt), 
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50),
                    new SqlParameter("@Vung",SqlDbType.Int),
                    new SqlParameter("@LenhTongDai",SqlDbType.NVarChar,255)
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = MaNhanVienTD;
            parameters[2].Value = Vung;
            parameters[3].Value = LenhTongDai;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "SP_T_TAXIOPERATION_CHUYENVUNG",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool TONGDAI_UpdateCuocGoiTaxi(long idCuocGoi)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt)
           };
            parameters[0].Value = idCuocGoi;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "SP_T_TAXIOPERATION_UPDATECHUYENTAXI",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        /// <summary>
        /// ham thu hien cap nhat thong tin tong dai cap nhan vao cuoc goi kết thúc
        /// </summary>
        /// <returns>True : thanh cong, False : khong thanh cong</returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Congt       22/07/11        Created
        /// </Modified>
        public bool TONGDAI_UpdateThongTinCuocGoi_KETTHUC(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                                  string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                                  string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                                  int thoigianDonKhach)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int  )  , 
                    new SqlParameter("@LenhTongDai",SqlDbType.NVarChar,255),
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int),
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar,255),  //4
                    new SqlParameter("@MaNhanVienTongDai",SqlDbType.NVarChar,50),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,100),
                    new SqlParameter("@XeDon",SqlDbType.VarChar ,100 ),
                    new SqlParameter("@DiaChiTraKhach",SqlDbType.NVarChar,255),
                    new SqlParameter("@ThoiGianDieuXe",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDonKhach",SqlDbType.Int)            //10
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = (int)trangThaiCuocGoiTaxi;
            parameters[2].Value = lenhTongDai;
            parameters[3].Value = (int)trangThaiLenhTaxi;
            parameters[4].Value = ghiChuTongDai;
            parameters[5].Value = idNVTD;
            parameters[6].Value = xeNhan;
            parameters[7].Value = xeDon;
            parameters[8].Value = diaChiTraKhach;
            parameters[9].Value = thoiGianDieuXe;
            parameters[10].Value = thoigianDonKhach;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_T_TAXIOPERATION_UPDATECUOCGOI_KETTHUC,
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        /// <summary>
        /// ham xu ly lay id cuoc goi da ket thuc boi dien thoai                            
        /// </summary>
        /// <param name="listIDCuocGoiHienTai"></param>
        /// <param name="vungsDuocCapPhep"></param>
        /// <returns></returns>
        public DataTable TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@ListIDCuocGoi",SqlDbType.VarChar ,8000) 
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = listIDCuocGoiHienTai;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_T_TAXIOPERATION_LAYCACIDCUOCGOIKETTHUCBYDIENTHOAI, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable TONGDAI_LayCacIDCuocGoiKetThucByDienThoai_ChuaNhan(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@ListIDCuocGoi",SqlDbType.VarChar ,8000) 
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = listIDCuocGoiHienTai;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_TONGDAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByDienThoai_ChuaNhan", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Cập nhật tọa độ của danh sách xe nhận
        /// </summary>
        /// <param name="idCuocGoi"></param>
        /// <param name="dsToaDoXeNhan"></param>
        /// <returns></returns>
        public bool TONGDAI_UPDATE_XENHAN_TOADO(long idCuocGoi, string dsToaDoXeNhan)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),
                new SqlParameter("@XeNhan_TD",SqlDbType.VarChar,150)
            };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = dsToaDoXeNhan;
            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_TONGDAI_SP_T_TAXIOPERATION_UPDATE_DSXENHAN_TOADO,
                                                                   parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public int TONGDAI_DemCuocGoiDonDuoc(DateTime tuNgay, DateTime denNgay, string maNhanVien)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@TuNgay",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                    new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50 ),
                    new SqlParameter("@RowCount",SqlDbType.Int )
                };

            parameters[0].Value = tuNgay;
            parameters[1].Value = denNgay;
            parameters[2].Value = maNhanVien;
            parameters[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY_DHV, parameters);
            g_sqlCon.Close();
            return Convert.ToInt32(parameters[3].Value);
        }

        /// <summary>
        /// Cập nhật xác nhận xe đón của nhân viên tổng đài
        /// </summary>
        public bool TONGDAI_UPDATE_XACNHAN(long idCuocGoi, string Message, int Confirm, string MaNhanVien, KieuCanhBaoKhiNhapThongTin KieuCanhBao)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@IdCuocGoi",SqlDbType.BigInt),
                new SqlParameter("@Message",SqlDbType.NVarChar, 100),
                new SqlParameter("@UserConfirm",SqlDbType.Int),
                new SqlParameter("@MaNhanVien",SqlDbType.VarChar,20),
                new SqlParameter("@KieuCanhBao",SqlDbType.Int)
            };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = Message;
            parameters[2].Value = Confirm;
            parameters[3].Value = MaNhanVien;
            parameters[4].Value = KieuCanhBao;
            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_SP_T_TAXIOPERATION_CANHBAO_INSERT", parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool TONGDAI_UpdateGhiChuTongDai(long idCuocGoi, string GhiChuTongDai)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),
                    new SqlParameter("@GhiChuTongDai",SqlDbType.NVarChar,255)
           };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = GhiChuTongDai;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "SP_T_TAXIOPERATION_UPDATE_GHICHUTONGDAI",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public DataTable TONGDAI_LayThongTinXeDon_ID(long IDCuocGoi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt)
           };
            parameters[0].Value = IDCuocGoi;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "OP_SP_TAXIOPERATION_LAYTHONGTINDONKHACH_ID", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable TONGDAI_LayThongTinXeDon_ID_KetThuc(long IDCuocGoi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt)
           };
            parameters[0].Value = IDCuocGoi;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "OP_SP_TAXIOPERATION_KETTHUC_LAYTHONGTINDONKHACH_ID", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Kiểm tra xe nhận có nhận ở các cuốc khách khách không
        /// </summary>
        /// <returns>Vùng đã nhận</returns>
        public int TONGDAI_CHECKEXIST_XENHAN_ALL(long IDCuocGoi, string XeNhan)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@ID",SqlDbType.BigInt ),
                    new SqlParameter("@XeNhan",SqlDbType.VarChar,2000),
                    new SqlParameter("@VungNhan",SqlDbType.Int)
                };

            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = XeNhan;
            parameters[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "OP_T_TAXIOPERATION_CHECK_EXIST_XENHAN", parameters);
            g_sqlCon.Close();
            if (parameters[2].Value != DBNull.Value)
                return Convert.ToInt32(parameters[2].Value);
            else
                return 0;

        }

        /// <summary>
        /// CHuyển tất cả các cuộc gọi thuộc 1 vùng sang 1 máy cs
        /// </summary>
        public void TONGDAI_ChuyenCG_SangMayCS(int MayCS, string Vung)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@MayCS",SqlDbType.Int),
                    new SqlParameter("@Vung",SqlDbType.VarChar,10)
                };

            parameters[0].Value = MayCS;
            parameters[1].Value = Vung;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "OP_SP_TAXIOPERATION_UPDATE_CGMAYCS", parameters);
            g_sqlCon.Close();
        }

        /// <summary>
        /// Kiểm tra xem xe đã đón khách trong khoảng 5' gần đây ko.
        /// </summary>
        public string TONGDAI_UPDATE_XEDON_CHECKVALID(string XeDon, DateTime ThoiDiemGoi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@XeDon",SqlDbType.VarChar,50),
                new SqlParameter("@ThoiDiemGoi",SqlDbType.DateTime),
                new SqlParameter("@Index",SqlDbType.Int)
            };
            parameters[0].Value = XeDon;
            parameters[1].Value = ThoiDiemGoi;
            parameters[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_SP_T_TAXIOPERATION_KETTHUC_CHECK_XEDON", parameters);
            g_sqlCon.Close();
            return parameters[2].Value.ToString();
        }


        /// <summary>
        /// Cập nhật cuộc gọi đã giải quyết thành cuộc gọi chưa giải quyết
        /// </summary>
        public bool TONGDAI_UpdateCGKetThuc2ChuaGiaiQuyet(long IDCuocGoi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
                g_sqlCon.Open();

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),
                    new SqlParameter("@OUTPUT",SqlDbType.VarChar,50 )};
            parameters[0].Value = IDCuocGoi;
            parameters[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_T_TAXIOPERATION_KETTHUC_UPDATE_STATUS_TONGDAI,
                                                       parameters);
            g_sqlCon.Close();
            return Convert.ToInt32(parameters[1].Value) > 0;
        }
        #endregion Hàm xử lý cho phần tổng đài

        #region ================================== DieuHanhChinh ==================================

        public int DIEUHANHCHINH_DemCuocGoiDonDuoc(DateTime tuNgay, DateTime denNgay)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@TuNgay",SqlDbType.DateTime ),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                    new SqlParameter("@RowCount",SqlDbType.Int )
                };

            parameters[0].Value = tuNgay;
            parameters[1].Value = denNgay;
            parameters[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_T_TAXIOPERATION_KETTHUC_COUNT_DONDUOC_NGAY, parameters);
            g_sqlCon.Close();
            return Convert.ToInt32(parameters[2].Value);
        }

        /// <summary>
        /// ham thuc hien lay ra cuoc goi moi ben dieu hanh chinh
        /// </summary>
        public List<CuocGoiDienThoaiLanDauType> DIEUHANHCHINH_LayDSCuocGoiMoi(DateTime thoiDiemLayTruoc, string Vung)
        {
            List<CuocGoiDienThoaiLanDauType> retListCuocGoiLanDau = new List<CuocGoiDienThoaiLanDauType>();

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime),                 
                    new SqlParameter("@Vung",SqlDbType.VarChar,50)                  
                };

            parameters[0].Value = thoiDiemLayTruoc;
            parameters[1].Value = Vung;

            using (SqlDataReader sqldrCuocGoiMoi = SqlHelper.ExecuteReader(g_sqlCon, SP_DIEUHANHCHINH_T_TAXIOPRATION_LAYDSCUOCGOIMOI, parameters))
            {
                while (sqldrCuocGoiMoi.Read())
                {
                    //[ID] ,[Line] ,[PhoneNumber] ,[ThoiDiemGoi]  ,[DiaChiLuu] ,[DiaChiDonKhach]  ,[Vung]  ,[LoaiKhachHang]                  
                    retListCuocGoiLanDau.Add(ParseCuocGoiDienThoaiLanDauType(sqldrCuocGoiMoi));
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return retListCuocGoiLanDau;
        }

        private CuocGoiDienThoaiLanDauType ParseCuocGoiDienThoaiLanDauType(SqlDataReader sqldrCuocGoiMoi)
        {
            return new CuocGoiDienThoaiLanDauType(
                Convert.ToInt64(sqldrCuocGoiMoi["ID"].ToString()),
                Convert.ToDateTime(sqldrCuocGoiMoi["ThoiDiemGoi"].ToString()),
                Convert.ToByte(sqldrCuocGoiMoi["SoLanGoi"] == DBNull.Value ? 1 : int.Parse(sqldrCuocGoiMoi["SoLanGoi"].ToString())),
                Convert.ToInt32(sqldrCuocGoiMoi["Line"].ToString()),
                sqldrCuocGoiMoi["PhoneNumber"].ToString(),
                sqldrCuocGoiMoi["DiaChiGoi"].ToString(),
                sqldrCuocGoiMoi["DiaChiDonKhach"] == DBNull.Value ? string.Empty : sqldrCuocGoiMoi["DiaChiDonKhach"].ToString(),
                sqldrCuocGoiMoi["Vung"] == DBNull.Value ? (byte)0 : Convert.ToByte(sqldrCuocGoiMoi["Vung"].ToString()),
                sqldrCuocGoiMoi["KieuKhachHangGoiDen"] == DBNull.Value ? KieuKhachHangGoiDen.KhachHangBinhThuong : (KieuKhachHangGoiDen)(int.Parse(sqldrCuocGoiMoi["KieuKhachHangGoiDen"].ToString())),
                sqldrCuocGoiMoi["LoaiXe"] == DBNull.Value ? string.Empty : sqldrCuocGoiMoi["LoaiXe"].ToString(),
                sqldrCuocGoiMoi["LenhDienThoai"] == DBNull.Value ? string.Empty : sqldrCuocGoiMoi["LenhDienThoai"].ToString(),
                sqldrCuocGoiMoi["GhiChuDienThoai"] == DBNull.Value ? string.Empty : sqldrCuocGoiMoi["LenhDienThoai"].ToString(),
                sqldrCuocGoiMoi["XeNhan"] == DBNull.Value ? string.Empty : sqldrCuocGoiMoi["XeNhan"].ToString()
                );
        }
        
        public DataTable DIEUHANHCHINH_LayAllCuocGoi(string vungsDuocCapPhep, bool isFilterXeNhan)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@FilterXeNhan",SqlDbType.Bit)
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = isFilterXeNhan;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, SP_DIEUHANHCHINH_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP_FILTER, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable ML_BC_ChiTietCuocGoiDen(DateTime tuNgay, DateTime denNgay, string kieuGoi, string loaiXe, string diaChi, string Vung,
                        string soDienThoai, string line, string xeNhan, string xeDon, string idNhanVienTD, string idNhanVienDT, string ketQuaDH, string soLanGoi)
        {
            try
            {
                if (g_sqlCon.State == ConnectionState.Closed)
                {
                    g_sqlCon.Open();
                }
                SqlParameter[] parameters = new SqlParameter[]{
                        new SqlParameter ("@TuNgay", SqlDbType.DateTime),
                        new SqlParameter ("@DenNgay", SqlDbType.DateTime),
                        new SqlParameter ("@Line", SqlDbType.VarChar,10),
                        new SqlParameter ("@KieuCuocGoi", SqlDbType.VarChar ,10),
                        new SqlParameter ("@LoaiXe", SqlDbType.VarChar ,50),
                        new SqlParameter ("@Vung", SqlDbType.VarChar ,50),
                        new SqlParameter ("@XeNhan", SqlDbType.VarChar ,100),
                        new SqlParameter ("@XeDon", SqlDbType.VarChar ,100),
                        new SqlParameter ("@KetQuaDH", SqlDbType.VarChar ,10),
                        new SqlParameter ("@DiaChi", SqlDbType.NVarChar , 255),
                        new SqlParameter ("@IDNhanVienTD", SqlDbType.VarChar,20),
                        new SqlParameter ("@IDNhanVienDT", SqlDbType.VarChar ,20),
                        new SqlParameter ("@SoDienThoai", SqlDbType.VarChar ,100),
                        new SqlParameter ("@SoLanGoi", SqlDbType.Int)
                    };
                parameters[0].Value = tuNgay;
                parameters[1].Value = denNgay;
                if (line != string.Empty) parameters[2].Value = line;
                if (kieuGoi != string.Empty) parameters[3].Value = kieuGoi;
                if (loaiXe != string.Empty) parameters[4].Value = loaiXe;
                if (Vung != string.Empty) parameters[5].Value = Vung;
                if (xeNhan != string.Empty) parameters[6].Value = xeNhan;
                if (xeDon != string.Empty) parameters[7].Value = xeDon;
                if (ketQuaDH != string.Empty) parameters[8].Value = ketQuaDH;
                if (diaChi != string.Empty) parameters[9].Value = diaChi;
                if (idNhanVienTD != string.Empty) parameters[10].Value = idNhanVienTD;
                if (idNhanVienDT != string.Empty) parameters[11].Value = idNhanVienDT;
                if (soDienThoai != string.Empty) parameters[12].Value = soDienThoai;
                if (soLanGoi != string.Empty) parameters[13].Value = Convert.ToInt32(soLanGoi);

                DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "[MAILINH.BC_ChiTietCuocGoiDen]", parameters);
                g_sqlCon.Close();
                if (ds.Tables != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }

        }

        public DataTable DIEUHANHCHINH_LayAllCuocGoi_V3(string lineChoPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Vung",SqlDbType.VarChar ,50)
           };
            if (!string.IsNullOrEmpty(lineChoPhep))
            {
                parameters[0].Value = lineChoPhep;
            }
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_DIEUHANHCHINH_spT_TAXIOPERATION_LayAllOfLine", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable DIEUHANHCHINH_LayDSCuocGoiThayDoi_V3(string Vung, DateTime thoiDiemNhanDulieuTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Vung",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
            };
            if (!string.IsNullOrEmpty(Vung))
            {
                parameters[0].Value = Vung;
            }
            parameters[1].Value = thoiDiemNhanDulieuTruoc;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_DIEUHANHCHINH_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhat", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable DIEUHANHCHINH_LayCacIDCuocGoiKetThuc_V3(string listIDCuocGoiHienTai, string Vung)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Vung",SqlDbType.VarChar ,50),
                    new SqlParameter("@ListIDCuocGoiHienTai",SqlDbType.VarChar ,8000) 
           };
            if (!string.IsNullOrEmpty(Vung))
            {
                parameters[0].Value = Vung;
            }

            parameters[1].Value = listIDCuocGoiHienTai;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V3_DIEUHANHCHINH_spT_TAXIOPERATION_LayCacIDCuocGoiKetThuc", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        #endregion

        #region ================================== Moi Khach ==================================

        public bool UpdateCSPhanBoCuocGoi(string strSQL)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.Text, strSQL) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update_MOIKHACH(long ID, string DiaChiDonKhach, string LenhMoiKhach, bool DaXinLoi, bool DaXyLyKhieuNai, string ThongTinThemKhieuNai, string NhanVien)
        {
            try
            {
                if (ID <= 0) return false;
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ), //0
                     new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 ) ,
                     new SqlParameter("@LenhMoiKhach",SqlDbType.NVarChar,50 ) ,
                     new SqlParameter("@DaXinLoi",SqlDbType.Bit ) ,
                     new SqlParameter("@KhieuNaiDaXyLy",SqlDbType.Bit) ,
                     new SqlParameter("@KhieuNaiThongTinThem",SqlDbType.NVarChar, 150) ,
                     new SqlParameter("@NhanVien",SqlDbType.NVarChar, 50)     ,
                     new SqlParameter("@IsErrorInsertKhongXe",SqlDbType.Int)   
                };
                parameters[0].Value = ID;
                parameters[1].Value = DiaChiDonKhach;
                parameters[2].Value = LenhMoiKhach;
                parameters[3].Value = DaXinLoi == true ? 1 : 0;
                parameters[4].Value = DaXyLyKhieuNai == true ? 1 : 0;
                parameters[5].Value = ThongTinThemKhieuNai;
                parameters[6].Value = NhanVien;
                parameters[7].Direction = ParameterDirection.Output;

                int rowAffected = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "[sp_UPDATE_T_TAXIOPERATION_MoiKhach]", parameters);
                if (LenhMoiKhach.Contains("đã xin lỗi"))
                {
                    int IsErrorInsertKhongXe = Convert.ToInt32(parameters[7].Value.ToString());
                    if (IsErrorInsertKhongXe > 0) return false; // lỗi không chèn được không xe.
                }
                return (rowAffected > 0);
            }
            catch 
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
        public bool Update_KetThucCuocGoi(long IDDieuHanh, TrangThaiLenhTaxi TrangThaiLenh)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt ), //0                   
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Char,1)
                };
                parameters[0].Value = IDDieuHanh;
                parameters[1].Value = ((int)TrangThaiLenh).ToString();

                int rowAffected = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "sp_T_TAXIOPERATION_Update_KetThucCuocGoi", parameters);
                return (rowAffected > 0);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// hàm cap nhat cuoc goi ket thuc
        /// </summary>
        public bool UpdateCuocKhachKetThucKhongXacDinhXeDon(long IDCuocGoi)
        {
            string strSQL = " UPDATE [T_TAXIOPERATION]  ";
            strSQL += " SET  [TrangThaiCuocGoi] = 0 , [TrangThaiLenh] = 4, [ThoiDiemThayDoiDuLieu] = GETDATE(), XeNhan='8888', XeDon='8888'  WHERE ID = " + IDCuocGoi.ToString() + " ";
            strSQL += " exec sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi ";
            try
            {
                SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.Text, strSQL);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// hàm cap nhat cuoc goi ket thuc
        /// </summary>
        public bool UpdateCuocKhachKetThucKhongXacDinhXeDon(long IDCuocGoi, string NhanVienCSKH, string xeNhan)
        {
            string strSQL = " UPDATE [T_TAXIOPERATION]  ";
            if (!string.IsNullOrEmpty(xeNhan))
                strSQL += " SET  [TrangThaiCuocGoi] = 0 , [TrangThaiLenh] = 4, [ThoiDiemThayDoiDuLieu] = GETDATE(), XeNhan='" + xeNhan + ".8888', XeDon='8888' , MOIKHACH_NhanVien = '" + NhanVienCSKH + "' ,ThoiGianDonKhach = DATEDIFF(ss, thoidiemgoi, GETDATE())   WHERE ID = " + IDCuocGoi.ToString() + " ";
            else
                strSQL += " SET  [TrangThaiCuocGoi] = 0 , [TrangThaiLenh] = 4, [ThoiDiemThayDoiDuLieu] = GETDATE(), XeNhan='8888', XeDon='8888' , MOIKHACH_NhanVien = '" + NhanVienCSKH + "' , ThoiGianDonKhach = DATEDIFF(ss, thoidiemgoi, GETDATE())  WHERE ID = " + IDCuocGoi.ToString() + " ";

            strSQL += " exec sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi ";
            try
            {
                SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.Text, strSQL);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateCSPhanBoCuocGoi(long ID, string xeNhan, string XeDon, string NhanVienCS)
        {
            string strSQL = "";
            if (ID > 0)
            {
                strSQL += " UPDATE  [T_TAXIOPERATION] ";
                strSQL += " SET [TrangThaiCuocGoi] = 1 ";
                strSQL += "   ,[TrangThaiLenh] = '3'  , XeNhan ='" + xeNhan + "',XeDon = '" + XeDon + "'";
                strSQL += "  ,[MOIKHACH_NhanVien] = N'" + NhanVienCS + "'";
                strSQL += "  ,[ThoiDiemThayDoiDuLieu] = GETDATE() ";

                if (XeDon.Length > 0) //  cập nhật thông tin thời gian đón
                    strSQL += " ,ThoiGianDonKhach =CASE WHEN (ThoiGianDonKhach IS NULL OR ThoiGianDonKhach =0)   THEN   datediff(ss,ThoiDiemGoi,getdate()) ELSE ThoiGianDonKhach END ";

                strSQL += " WHERE ID = " + ID.ToString();
                strSQL += "    EXEC sp_T_TAXIOPERATION_ChuyenKetThucCuocGoi ";

                SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.Text, strSQL);

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
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@ID",SqlDbType.BigInt ) ,
                     new SqlParameter("XeNhan",SqlDbType.VarChar ,3 ) ,
                     new SqlParameter("@iCount",SqlDbType.Int ) 
                };

                parameters[0].Value = ID;
                parameters[1].Value = SoHieuXe;
                parameters[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "sp_T_TAXIOPERATION_CheckXeNhanDaCo", parameters);
                return ((int)parameters[2].Value > 0);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm cập nhật thông tin sửa chữa thông tin cuốc khách đã kết thúc
        /// </summary>

        public bool MOIKHACH_UpdateThongTinCuocGoiKetThuc(long idCuocGoi, string xeDon, bool truot, string ghiChu, string nhanVien)
        {
            try
            {
                string strSQL = string.Empty;
                strSQL += " UPDATE [T_TAXIOPERATION_KETTHUC] ";
                if (truot)
                {
                    strSQL += "SET XeDon = '', ";
                    strSQL += " TrangThaiCuocGoi = 2 ";
                }
                else
                {
                    strSQL += "SET XeDon = '" + xeDon + "'";
                }
                strSQL += ",CAMON_ThoiDiemSuaCuoi ='2000-01-01 00:00:00' , MOIKHACH_NhanVien = '" + nhanVien + "' ";  // set CAMON_ThoiDiemSuaCuoi ='2000-01-01 00:00:00'   de ghi nhan la da co sua
                strSQL += ", MOIKHACH_KhieuNai_ThongTinThem = MOIKHACH_KhieuNai_ThongTinThem + N'[" + ghiChu + "(" + nhanVien + ")]'";
                strSQL += ", DiaChiTraKhach =  + N'[" + ghiChu + "(" + nhanVien + ")]'";
                strSQL += " WHERE ID = " + idCuocGoi.ToString();

                return SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.Text, strSQL) > 0;
            }
            catch
            {
                return false;
            }
        }

        #region ---V3---
        /// <summary>
        /// hàm lấy cuộc gọi mới thay đổi phía điện thoại, tổng đài truyền sang mời khách
        /// </summary>
        public List<CuocGoiEntity> MK_LayCuocGoiMoiTuDTV_TDV(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, int MayCS)
        {
            List<CuocGoiEntity> retListCuocGoiDT = new List<CuocGoiEntity>();

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayDuLieuLanTruoc",SqlDbType.DateTime ),
                    new SqlParameter("@MayCS",SqlDbType.Int )
            };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = thoiDiemLayDuLieuTruoc;
            parameters[2].Value = MayCS;

            using (SqlDataReader sdrCuocGoi = SqlHelper.ExecuteReader(g_sqlCon, V3_MOIKHACH_T_TAXIOPERATION_LAYCUOCGOITUDTV_TDV, parameters))
            {
                while (sdrCuocGoi.Read())
                {
                    //  [ID] ,Line , ThoiDiemGoi,PhoneNumber ,SoLanGoi,[DiaChiDonKhach] ,[Vung] ,[LoaiXe] ,[SoLuongXe] ,[LoaiKhachHang]  ,[IsCuocGiaLap] 
                    // ,[KieuCuocGoi] ,[LenhDienThoai]  ,[TrangThaiLenh] ,[GhiChuDienThoai] ,[MaNhanVienDienThoai] 
                    //    ,[ThoiGianChuyenTongDai]    ,[DanhSachXe_DeCu] ,[ThoiDiemCapNhatXeDeCu] 
                    long idCuocGoi = sdrCuocGoi["ID"] == DBNull.Value ? 0 : Convert.ToInt64(sdrCuocGoi["ID"].ToString());
                    DateTime thoiDiemGoi = sdrCuocGoi["ThoiDiemGoi"] == DBNull.Value ? DateTime.Now : DateTime.Parse(sdrCuocGoi["ThoiDiemGoi"].ToString());
                    int line = sdrCuocGoi["Line"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["Line"].ToString());
                    string phoneNumber = sdrCuocGoi["PhoneNumber"] == DBNull.Value ? "00000000" : sdrCuocGoi["PhoneNumber"].ToString();
                    int soLan = sdrCuocGoi["SoLanGoi"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["SoLanGoi"].ToString());
                    string diachi = sdrCuocGoi["DiaChiDonKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["DiaChiDonKhach"].ToString();
                    int vung = sdrCuocGoi["Vung"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["Vung"].ToString());
                    string loaiXe = sdrCuocGoi["LoaiXe"] == DBNull.Value ? string.Empty : sdrCuocGoi["LoaiXe"].ToString();
                    int soLuongXe = sdrCuocGoi["SoLuong"] == DBNull.Value ? 1 : int.Parse(sdrCuocGoi["SoLuong"].ToString());
                    KieuKhachHangGoiDen loaiKhachHang = sdrCuocGoi["KieuKhachHangGoiDen"] == DBNull.Value ? KieuKhachHangGoiDen.KhachHangBinhThuong : (KieuKhachHangGoiDen)(int.Parse(sdrCuocGoi["KieuKhachHangGoiDen"].ToString()));
                    bool isCuocGiaLap = sdrCuocGoi["IsCuocGiaLap"] != DBNull.Value && bool.Parse(sdrCuocGoi["IsCuocGiaLap"].ToString());
                    KieuCuocGoi kieuCG = sdrCuocGoi["KieuCuocGoi"] == DBNull.Value ? KieuCuocGoi.TrangThaiKhac : (KieuCuocGoi)(int.Parse(sdrCuocGoi["KieuCuocGoi"].ToString()));
                    string lenhDienThoai = sdrCuocGoi["LenhDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["LenhDienThoai"].ToString();
                    string ghiChuDT = sdrCuocGoi["GhiChuDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["GhiChuDienThoai"].ToString();
                    string lenhTongDai = sdrCuocGoi["LenhTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["LenhTongDai"].ToString();
                    string ghiChuTD = sdrCuocGoi["GhiChuTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["GhiChuTongDai"].ToString();
                    TrangThaiLenhTaxi trangThaiLenh = sdrCuocGoi["TrangThaiLenh"] == DBNull.Value ? TrangThaiLenhTaxi.KhongTruyenDi : (TrangThaiLenhTaxi)int.Parse(sdrCuocGoi["TrangThaiLenh"].ToString());
                    string nvDT = sdrCuocGoi["MaNhanVienDienThoai"] == DBNull.Value ? string.Empty : sdrCuocGoi["MaNhanVienDienThoai"].ToString();
                    string nvTD = sdrCuocGoi["MaNhanVienTongDai"] == DBNull.Value ? string.Empty : sdrCuocGoi["MaNhanVienTongDai"].ToString();
                    int thoiGianChuyenTongDai = sdrCuocGoi["ThoiDiemChuyenTongDai"] == DBNull.Value ? 0 : int.Parse(sdrCuocGoi["ThoiDiemChuyenTongDai"].ToString());
                    string dsXeDeCu = sdrCuocGoi["DanhSachXe_DeCu"] == DBNull.Value ? string.Empty : sdrCuocGoi["DanhSachXe_DeCu"].ToString();
                    string dsXeDeCu_TD = sdrCuocGoi["DanhSachXe_DeCu_TD"] == DBNull.Value ? string.Empty : sdrCuocGoi["DanhSachXe_DeCu_TD"].ToString();
                    double KD = sdrCuocGoi["GPS_KinhDo"] == DBNull.Value ? 1 : double.Parse(sdrCuocGoi["GPS_KinhDo"].ToString());
                    double VD = sdrCuocGoi["GPS_ViDo"] == DBNull.Value ? 1 : double.Parse(sdrCuocGoi["GPS_ViDo"].ToString());
                    DateTime thoiDiemDeCu = sdrCuocGoi["ThoiDiemCapNhatXeDeCu"] == DBNull.Value ? new DateTime(1900, 01, 01, 0, 0, 0) : DateTime.Parse(sdrCuocGoi["ThoiDiemCapNhatXeDeCu"].ToString());
                    string xeNhan = sdrCuocGoi["XeNhan"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeNhan"].ToString();
                    string xeNhan_TD = sdrCuocGoi["XeNhan_TD"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeNhan_TD"].ToString();

                    string MK_Lenh = sdrCuocGoi["MOIKHACH_LenhMoiKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["MOIKHACH_LenhMoiKhach"].ToString();
                    string MK_NhanVien = sdrCuocGoi["MOIKHACH_NhanVien"] == DBNull.Value ? string.Empty : sdrCuocGoi["MOIKHACH_NhanVien"].ToString();

                    string xeDenDiem = sdrCuocGoi["XeDenDiem"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiem"].ToString();
                    string xeDenDiemDonKhach = sdrCuocGoi["XeDenDiemDonKhach"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiemDonKhach"].ToString();
                    string xeDenDiemDonKhach_TD = sdrCuocGoi["XeDenDiemDonKhach_TD"] == DBNull.Value ? string.Empty : sdrCuocGoi["XeDenDiemDonKhach_TD"].ToString();
                    TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi = sdrCuocGoi["TrangThaiCuocGoi"] == DBNull.Value ? TrangThaiCuocGoiTaxi.TrangThaiKhac : (TrangThaiCuocGoiTaxi)int.Parse(sdrCuocGoi["TrangThaiCuocGoi"].ToString());
                    retListCuocGoiDT.Add(new CuocGoiEntity(idCuocGoi, thoiDiemGoi, line, phoneNumber, soLan, diachi, vung, loaiXe, soLuongXe, loaiKhachHang, isCuocGiaLap, kieuCG, lenhDienThoai, ghiChuDT, lenhTongDai, ghiChuTD, trangThaiLenh, nvDT, nvTD, thoiGianChuyenTongDai, dsXeDeCu, thoiDiemDeCu, dsXeDeCu_TD, KD, VD, xeNhan, xeNhan_TD, MK_Lenh, MK_NhanVien, xeDenDiem, xeDenDiemDonKhach, xeDenDiemDonKhach_TD, trangThaiCuocGoiTaxi));
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return retListCuocGoiDT;
        }

        public DataTable MK_LayCacIDCuocGoiKetThucByDTV_TDV(string listIDCuocGoiHienTai, string vungsDuocCapPhep, int MayCS)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@ListIDCuocGoi",SqlDbType.VarChar ,8000), 
                    new SqlParameter("@MayCS",SqlDbType.Int)
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = listIDCuocGoiHienTai;
            parameters[2].Value = MayCS;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, V3_MOIKHACH_T_TAXIOPERATION_LAYCACIDCUOCGOIKETTHUCBYDTV_TDV, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public bool MK_UpdateThongTinCuocGoi(long IDCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoi, string lenhMoiKhach,
                                                    TrangThaiLenhTaxi trangThaiLenh, string maNhanVienMoiKhach, string xeDon)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int ), 
                    new SqlParameter("@MOIKHACH_LenhMoiKhach",SqlDbType.NVarChar,255 ), 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int  ),
                    new SqlParameter("@MOIKHACH_NhanVien",SqlDbType.NVarChar ,50 ),
                    new SqlParameter("@XeDon",SqlDbType.VarChar,100)
           };
            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = trangThaiCuocGoi;
            parameters[2].Value = lenhMoiKhach;
            parameters[3].Value = trangThaiLenh;
            parameters[4].Value = maNhanVienMoiKhach;
            parameters[5].Value = xeDon;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, V3_MOIKHACH_T_TAXIOPERATION_CAPNHATCUOCGOI_XEDON,
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public bool MK_UpdateThongTinCuocGoi_V4(long IDCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoi, string lenhMoiKhach,
                                                    TrangThaiLenhTaxi trangThaiLenh, string maNhanVienMoiKhach, string xeDon, string DiaChiDonKhach)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),
                    new SqlParameter("@TrangThaiCuocGoi",SqlDbType.Int ), 
                    new SqlParameter("@MOIKHACH_LenhMoiKhach",SqlDbType.NVarChar,255 ), 
                    new SqlParameter("@TrangThaiLenh",SqlDbType.Int  ),
                    new SqlParameter("@MOIKHACH_NhanVien",SqlDbType.NVarChar ,50 ),
                    new SqlParameter("@XeDon",SqlDbType.VarChar,100), 
                    new SqlParameter("@DiaChiDonKhach",SqlDbType.NVarChar,255 )
           };
            parameters[0].Value = IDCuocGoi;
            parameters[1].Value = trangThaiCuocGoi;
            parameters[2].Value = lenhMoiKhach;
            parameters[3].Value = trangThaiLenh;
            parameters[4].Value = maNhanVienMoiKhach;
            parameters[5].Value = xeDon;
            parameters[6].Value = DiaChiDonKhach;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V4_MOIKHACH_T_TAXIOPERATION_CAPNHATCUOCGOI_XEDON",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }

        public DataTable MK_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong, int MayCS)
        {

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@StartRow",SqlDbType.Int),
                    new SqlParameter("@EndRow",SqlDbType.Int),
                    new SqlParameter("@MayCS",SqlDbType.Int)
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = 1;
            parameters[2].Value = soDong;
            parameters[3].Value = MayCS;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, V3_MOIKHACH_T_TAXIOPERATION_LAYCACCUOCGOIDAKETTHUC, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public DataTable MK_LayAllCuocGoi(string vungsDuocCapPhep, int MayCS)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@MayCS",SqlDbType.Int)
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = MayCS;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, V3_MOIKHACH_T_TAXIOPERATION_LAYALLOFVUNGCHOPHEP, parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        #endregion
        #endregion

        #region ================================== Man hinh dieu xe ==================================
        /// <summary>
        /// hàm thực hiện thông in cập nhật màn hình điều hành
        /// </summary>
        /// <param name="idCuocGoi"></param>
        /// <returns></returns>
        public bool TONGDAI_UpdateThongTinGuiToiXe(long idCuocGoi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt ) 
                };

            parameters[0].Value = idCuocGoi;

            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, SP_MANHINH_T_TAXIOPERATION_UPDATEGUITOIXE, parameters);
            return (rowAffeced > 0);
        }

        #endregion

        #region ================================== FastTaxi ==================================
        #region dùng chung
        public int RunStore(string name, params object[] pa)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            int rowAffected = SqlHelper.ExecuteNonQuery(g_sqlCon, name, pa);
            g_sqlCon.Close();
            return rowAffected;
        }

        public DataSet RunStoreData(string name, params object[] pa)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, name, pa);
            g_sqlCon.Close();
            return ds;
        }

        /// <summary>
        /// Get thông tin cuốc online
        /// </summary>
        /// <returns></returns>
        public DataTable GetCuocOnlines_v2()
        {
            try
            {
                return this.RunStoreData("T_TaxiOperation_GetCuocGoi_ForMem").Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Điện thoại
        /// <summary>
        ///  </summary>
        /// <param name="lineChoPhep"></param>
        /// <returns></returns>
        public DataTable FT_DIENTHOAI_LayAllCuocGoi_Khac(string lineChoPhep)
        {
            return this.RunStoreData("FT_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep_Khac", lineChoPhep).Tables[0];
        }
        public DataTable FT_DIENTHOAI_LayAllCuocGoi(string lineChoPhep)
        {
            return this.RunStoreData("FT_V3_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep", lineChoPhep).Tables[0];
        }
        public DataTable FT_DIENTHOAI_LayAllCuocGoiNotFT(string lineChoPhep)
        {
            return this.RunStoreData("FT_V3_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepNotFT", lineChoPhep).Tables[0];
        }
        #region Cập nhật cuốc của FastTaxi

        public bool FT_DIENTHOAI_UpdateThongTinCuocGoi(long IDCuocGoi, string diaChiDonKhach, string DiaChiTraKhach,
            string phoneNumber, int vung, string loaiXe, int soLuongXe,
            TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
            TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
            int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD,
            string xeDon, KieuKhachHangGoiDen kieuKHGoiDen, LoaiCuocKhach loaiCuocKhach, bool FT_IsFT, DateTime? FT_Date,
            DateTime? FT_SendDate, Enum_FastTaxi_Status FT_Status)
        {
            return this.RunStore("FT_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi", IDCuocGoi, diaChiDonKhach, (long)vung,
                    soLuongXe, loaiXe, 0, (int)trangThaiCuocGoi, (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, (int)trangThaiLenh,
                    ghiChuDienThoai, maNhanVienDienThoai, thoiGianChuyenTongDai, kinhDo, viDo,
                    phoneNumber, DanhSachXeDeCu, DanhSachXeDeCu_TD, xeDon, (int)kieuKHGoiDen,
                    FT_IsFT, FT_Date, FT_SendDate, DiaChiTraKhach, (int)FT_Status) > 0;
        }
        public bool FT_DIENTHOAI_UpdateThongTinCuocGoiV2(long IDCuocGoi, string diaChiDonKhach, string DiaChiTraKhach,
            string phoneNumber, int vung, string loaiXe, int soLuongXe,
            TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
            TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
            int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD,
            string xeDon, KieuKhachHangGoiDen kieuKHGoiDen, LoaiCuocKhach loaiCuocKhach, bool FT_IsFT, DateTime? FT_Date,
            DateTime? FT_SendDate, Enum_FastTaxi_Status FT_Status, int isHeThong)
        {
            return  this.RunStore("FT_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoiV2", IDCuocGoi, diaChiDonKhach, (long)vung,
                    soLuongXe, loaiXe, 0, (int)trangThaiCuocGoi, (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, (int)trangThaiLenh,
                    ghiChuDienThoai, maNhanVienDienThoai, thoiGianChuyenTongDai, kinhDo, viDo,
                    phoneNumber, DanhSachXeDeCu, DanhSachXeDeCu_TD, xeDon, (int)kieuKHGoiDen,
                    FT_IsFT, FT_Date, FT_SendDate, DiaChiTraKhach, (int)FT_Status, isHeThong) > 0;
        }

        public bool FT_DIENTHOAI_UpdateThongTinCuocGoi_Mini(long IDCuocGoi, string diaChiDonKhach,
            string DiaChiTraKhachHang, string phoneNumber, int vung, string loaiXe, int soLuongXe,
            TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
            TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
            int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD,
            string xeDon, KieuKhachHangGoiDen kieuKHGoiDen
            , string xeNhan, string xeDenDiem, LoaiCuocKhach loaiCuocKhach, bool FT_IsFT, DateTime? FT_Date,
            DateTime? FT_SendDate, Enum_FastTaxi_Status FT_Status)
        {
            return this.RunStore("FT_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini", IDCuocGoi, diaChiDonKhach, vung,
                soLuongXe, loaiXe,
                0, (int)trangThaiCuocGoi, (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, (int)trangThaiLenh, ghiChuDienThoai, maNhanVienDienThoai,
                thoiGianChuyenTongDai, kinhDo, viDo, phoneNumber, DanhSachXeDeCu,
                DanhSachXeDeCu_TD, xeDon, (int)kieuKHGoiDen, xeNhan, xeDenDiem,
                FT_IsFT, FT_Date, FT_SendDate, DiaChiTraKhachHang, (int)FT_Status) > 0;
        }

        #endregion

        /// <summary>
        /// Cập nhật trạng thái lịch sử của fastTaxi
        /// </summary>
        public bool FT_ReturnSendByID(long id, bool flg)
        {

            return this.RunStore("FT_ReturnSendByID", id, flg) > 0;
        }

        public string GetLenhDienThoaiCurrent(long id)
        {
            try
            {
                var dt = RunStoreData("sp_FT_CuocGoi_GetLenhDienThoaiCurrent", id);
                if (dt != null && dt.Tables[0] != null && dt.Tables[0].Rows.Count > 0)
                {
                    return dt.Tables[0].Rows[0][0].ToString();
                }
            }
            catch
            {

            }
            return string.Empty;
        }
        /// <summary>
        /// Hàm cập nhật vào db
        /// </summary>
        /// <param name="Id">Key</param>
        /// <param name="Vung">Vùng</param>
        /// <param name="DanhSachXeDeCu">Danh sách xe đề cử</param>
        /// <param name="DanhSachXeDeCu_TD">Danh sách xe đề cử</param>
        /// <param name="KieuCuocGoi">Kiểu cuốc gọi</param>
        /// <param name="SoLuong">Số lượng</param>
        /// <param name="FT_KM">là khoảng các giữa điểm đón với vị trị của khách hàng.</param>
        /// <returns></returns>
        public bool DIENTHOAI_UpdateThongTinCuocSTaxi(long Id, int Vung, string DanhSachXeDeCu, string DanhSachXeDeCu_TD, int KieuCuocGoi, int SoLuong, float FT_KM)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.BigInt),            //0                  
                    new SqlParameter("@Vung",SqlDbType.Int )  , 
                    new SqlParameter("@DanhSachXeDeCu",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@DanhSachXeDeCu_TD",SqlDbType.NVarChar,255 )  , 
                    new SqlParameter("@KieuCuocGoi",SqlDbType.Int),
                    new SqlParameter("@SoLuong",SqlDbType.Int),
                    new SqlParameter("@FT_KM",SqlDbType.Float)
           };
            parameters[0].Value = Id;
            parameters[1].Value = Vung;
            parameters[2].Value = DanhSachXeDeCu;
            parameters[3].Value = DanhSachXeDeCu_TD;
            parameters[4].Value = KieuCuocGoi;
            parameters[5].Value = SoLuong;
            parameters[6].Value = FT_KM;
            int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "sp_DIENTHOAI_UpdateThongTinCuocSTaxi",
                                                       parameters);
            g_sqlCon.Close();
            return (rowAffeced > 0);
        }
        public DataTable DienThoai_LayLichSuTheoSoDienThoai(string SoDienThoai, DateTime ThoiDiemGoi, int SoDong)
        {
            return this.RunStoreData("sp_DIENTHOAI_LayLichSuTheoSoDienThoai", SoDienThoai, ThoiDiemGoi, SoDong).Tables[0];
        }
        #endregion

        #region Lịch sử
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCuocGoi"></param>
        /// <param name="Content"></param>
        /// <param name="Status">Enum_FastTaxi_Status</param>
        /// <param name="T_Result"></param>
        /// <param name="FT_Result"></param>
        /// <returns></returns>
        public bool FT_History_Create(int IdCuocGoi, string Content, int Status, bool T_Result = true, bool FT_Result = true)
        {
            return this.RunStore("FT_BanCo_FastTaxi_History_Create", IdCuocGoi, Content, Status, T_Result, FT_Result) > 0;
        }

        public DataTable FT_GetHistoryByIdCuoc(long id)
        {
            return this.RunStoreData("FT_GetHistoryByIdCuoc", id).Tables[0];
        }
        #endregion

        #region  Tổng đài
        /// <summary>
        /// hàm trả về thông tin tất cả cuộc gọi theo vùng
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <returns></returns>
        public DataSet FT_TONGDAI_LayAllCuocGoi(string vungsDuocCapPhep)
        {

            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                return this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT", vungsDuocCapPhep);
            else
                return this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep", vungsDuocCapPhep);

        }
        public DataSet FT_TONGDAI_LayAllCuocGoiNotFT(string vungsDuocCapPhep)
        {

            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                return this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT", vungsDuocCapPhep);
            else
                return this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT", vungsDuocCapPhep);

        }
        public DataTable FT_TONGDAI_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong)
        {
            var ds = this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc", vungsDuocCapPhep, 1, soDong);
            return ds.Tables[0];
        }
        public DataTable FT_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(string vungsDuocCapPhep, int soDong)
        {
            var ds = this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThucNotFT", vungsDuocCapPhep, 1, soDong);
            return ds.Tables[0];
        }
        /// <summary>
        /// Lấy các cuộc điện thoại mà tổng đài viên đã nhận xử lý.
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public DataTable FT_TONGDAI_LayCuocGoiDaNhanXuLy(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            return this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhan", vungsDuocCapPhep, thoiDiemLayDuLieuTruoc).Tables[0];
        }
        /// <summary>
        ///       Lấy các cuộc điện thoại mà tổng đài viên đã nhận xử lý không phải là FT.
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public DataTable FT_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            return this.RunStoreData("FT_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhanNotFT", vungsDuocCapPhep, thoiDiemLayDuLieuTruoc).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCuocGoi"></param>
        /// <param name="trangThaiCuocGoiTaxi"></param>
        /// <param name="lenhTongDai"></param>
        /// <param name="ghiChuTongDai"></param>
        /// <param name="trangThaiLenhTaxi"></param>
        /// <param name="idNVTD"></param>
        /// <param name="xeNhan"></param>
        /// <param name="xeDon"></param>
        /// <param name="diaChiTraKhach"></param>
        /// <param name="thoiGianDieuXe"></param>
        /// <param name="thoigianDonKhach"></param>
        /// <param name="chuyenMK"></param>
        /// <param name="xeDenDiem"></param> <param name="DiaChiDonKhach"></param>
        /// <returns></returns>
        public bool FT_TONGDAI_UpdateThongTinCuocGoi_V4(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                               string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                               string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                               int thoigianDonKhach, bool chuyenMK, string xeDenDiem, string DiaChiDonKhach)
        {
            return this.RunStore("FT_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi", idCuocGoi, trangThaiCuocGoiTaxi,
                    lenhTongDai, trangThaiLenhTaxi, ghiChuTongDai, idNVTD, xeNhan, xeDon, diaChiTraKhach, thoiGianDieuXe,
                    thoigianDonKhach, chuyenMK, xeDenDiem, DiaChiDonKhach) > 0;
        }

        public bool FT_TONGDAI_UpdateThongTinCuocGoi_EV(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                               string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                               string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                               int thoigianDonKhach, bool chuyenMK, string xeDenDiem, string DiaChiDonKhach, bool KhongDungMobileService)
        {
            return this.RunStore("FT_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_EV", idCuocGoi, trangThaiCuocGoiTaxi,
                    lenhTongDai, trangThaiLenhTaxi, ghiChuTongDai, idNVTD, xeNhan, xeDon, diaChiTraKhach, thoiGianDieuXe,
                    thoigianDonKhach, chuyenMK, xeDenDiem, DiaChiDonKhach, KhongDungMobileService) > 0;
        }

        public DataTable FT_TONGDAI_LayCuocGoiMoiTuDienThoai(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "FT_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_ChuaNhan";
            else
                SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "FT_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai";

            return this.RunStoreData(SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI, vungsDuocCapPhep,
                    thoiDiemLayDuLieuTruoc).Tables[0];
        }
        public DataTable FT_TONGDAI_LayCuocGoiMoiTuDienThoaiNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "FT_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT_ChuaNhan";
            else
                SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "FT_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT";

            return this.RunStoreData(SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI, vungsDuocCapPhep,
                    thoiDiemLayDuLieuTruoc).Tables[0];
        }



        #endregion

        #endregion

        #region ================================== EnVang ==================================
        /// <summary>
        /// hàm thực hiện lấy ra các cuộc gọi gần đây nhất mà chương trình chưa cập nhật
        /// </summary>
        /// <param name="lineChoPhep"></param>
        /// <param name="thoiDiemLayTruoc"></param>
        /// <returns></returns>
        public DataTable DIENTHOAI_LayDSCuocGoiMoi_EnVangVip(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            return this.RunStoreData(sp_EnVangVip_DIENTHOAI_LAYDSCUOCGIOMOI, lineChoPhep, thoiDiemLayTruoc).Tables[0];

        }

        /// <summary>
        /// Hàm thực hiện lấy ra các cuộc gọi gần đây nhất mà chương trình chưa cập nhật
        /// </summary>
        public DataTable DIENTHOAI_LayAllOfLineChoPhep_EnVangVip(string lineChoPhep)
        {


            return this.RunStoreData(sp_EnVangVip_DIENTHOAI_LayAllOfLineChoPhep, lineChoPhep).Tables[0];


        }

        /// <summary>
        /// Update thông tin cuộc gọi của én vàng vip
        /// </summary>
        /// <param name="IDCuocGoi">The identifier cuoc goi.</param>
        /// <param name="diaChiDonKhach">The dia chi don khach.</param>
        /// <param name="DiaChiTraKhach">The dia chi tra khach.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="vung">The vung.</param>
        /// <param name="loaiXe">The loai xe.</param>
        /// <param name="soLuongXe">The so luong xe.</param>
        /// <param name="trangThaiCuocGoi">The trang thai cuoc goi.</param>
        /// <param name="kieuCuocGoi">The kieu cuoc goi.</param>
        /// <param name="lenhDienThoai">The lenh dien thoai.</param>
        /// <param name="trangThaiLenh">The trang thai lenh.</param>
        /// <param name="ghiChuDienThoai">The ghi chu dien thoai.</param>
        /// <param name="maNhanVienDienThoai">The ma nhan vien dien thoai.</param>
        /// <param name="thoiGianChuyenTongDai">The thoi gian chuyen tong dai.</param>
        /// <param name="kinhDo">The kinh do.</param>
        /// <param name="viDo">The vi do.</param>
        /// <param name="DanhSachXeDeCu">The danh sach xe de cu.</param>
        /// <param name="DanhSachXeDeCu_TD">The danh sach xe de cu_ td.</param>
        /// <param name="xeDon">The xe don.</param>
        /// <param name="kieuKHGoiDen">The kieu kh goi den.</param>
        /// <param name="loaiCuocKhach">The loai cuoc khach.</param>
        /// <param name="FT_IsFT">if set to <c>true</c> [f t_ is ft].</param>
        /// <param name="FT_Date">The f t_ date.</param>
        /// <param name="FT_SendDate">The f t_ send date.</param>
        /// <param name="FT_Status">The f t_ status.</param>
        /// <param name="XeNhan">The xe nhan.</param>
        /// <param name="GPS_ViDo_Tra">Vi do</param>
        /// <param name="GPS_KinhDo_Tra">Kinh do</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/28/2015   created
        /// </Modified>
        public bool DIENTHOAI_UpdateThongTinCuocGoi_EnVangVip(long IDCuocGoi, string diaChiDonKhach, string DiaChiTraKhach,
            string phoneNumber, int vung, string loaiXe, int soLuongXe,
            TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
            TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
            int thoiGianChuyenTongDai, double kinhDo, double viDo, string DanhSachXeDeCu, string DanhSachXeDeCu_TD,
            string xeDon, KieuKhachHangGoiDen kieuKHGoiDen, LoaiCuocKhach loaiCuocKhach, bool FT_IsFT, DateTime? FT_Date,
            DateTime? FT_SendDate, Enum_FastTaxi_Status FT_Status, string XeNhan, double GPS_ViDo_Tra, double GPS_KinhDo_Tra)
        {
            return
                this.RunStore("V1_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_EnVangVip", IDCuocGoi, diaChiDonKhach, (long)vung,
                    soLuongXe, loaiXe, 0, (int)trangThaiCuocGoi, (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, (int)trangThaiLenh,
                    ghiChuDienThoai, maNhanVienDienThoai, thoiGianChuyenTongDai, kinhDo, viDo,
                    phoneNumber, DanhSachXeDeCu, DanhSachXeDeCu_TD, xeDon, (int)kieuKHGoiDen,
                    FT_IsFT, FT_Date, FT_SendDate, DiaChiTraKhach, (int)FT_Status, XeNhan, GPS_ViDo_Tra, GPS_KinhDo_Tra) > 0;
        }

        /// <summary>
        /// Cập nhật trường đánh dấu đã gửi danh sách xe nhận
        /// </summary>
        /// <param name="IDCuocGoi">The identifier cuoc goi.</param>
        /// <param name="DaGuiDSXeNhan">The da GUI ds xe nhan.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/28/2015   created
        /// </Modified>
        public bool DIENTHOAI_CapNhatDaGuiDSXeNhan_EnVangVip(long IDCuocGoi, byte? DaGuiDSXeNhan)
        {
            return this.RunStore("DIENTHOAI_spT_TAXIOPERATION_CapNhatDaGuiDSXeNhan_EnVangVip", IDCuocGoi, DaGuiDSXeNhan) > 0;
        }

        public DataTable DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V4_Khac(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,50), 
                    new SqlParameter("@ThoiDiemLayTruoc",SqlDbType.DateTime )                   
            };
            parameters[0].Value = linesDuocCapPhep;
            parameters[1].Value = thoiDiemNhanDulieuTruoc;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "V4_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai_Khac", parameters))
            {
                g_sqlCon.Close();
                if ( ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy về xe ưa thích của khách hàng
        /// </summary>
        /// <param name="idCuocGoi">The identifier cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/29/2015   created
        /// </Modified>
        public DataTable DIENTHOAI_LayXeUaThich_EnVangVIP(long idCuocGoi)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.VarChar,50)                   
            };
            parameters[0].Value = idCuocGoi;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "DienThoai_LayVeXeYeuThich_EnVangVIP", parameters))
            {
                g_sqlCon.Close();
                if ( ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy danh sách các message từ server/mobile chuyển về
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/20/2015   created
        /// </Modified>
        public DataTable DIENTHOAI_LayMessageConfirm_EnVangVIP(string lineChoPhep, bool isDienThoai, string arrayOpenedMessage)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,255),
                    new SqlParameter("@IsDienThoai",SqlDbType.Bit),
                    new SqlParameter("@ArrayOpenedMessage", SqlDbType.VarChar, 4000)
            };
            parameters[0].Value = lineChoPhep;
            parameters[1].Value = isDienThoai;
            parameters[2].Value = arrayOpenedMessage;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "DIENTHOAI_sp_GetMessageConfirm_EnVangVip_V2", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Sửa lệnh lái xe
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/30/2015   created
        /// </Modified>
        public int DIENTHOAI_SuaMessageConfirm_EnVangVip(long idCuocGoi, string lenhLaiXe, short maMessage, bool coMoLai, string soHieuXe)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IDCuocGoi",SqlDbType.VarChar,50),
                    new SqlParameter("@LenhLaiXe",SqlDbType.NVarChar,255),
                    new SqlParameter("@MaMessage",SqlDbType.SmallInt),
                    new SqlParameter("@CoMoLai",SqlDbType.Bit),
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,16)
            };
            parameters[0].Value = idCuocGoi;
            parameters[1].Value = lenhLaiXe;
            parameters[2].Value = maMessage;
            parameters[3].Value = coMoLai;
            parameters[4].Value = soHieuXe;
            return SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "DIENTHOAI_spT_TAXIOPERATION_SuaMessageConfirm_EnVangVip", parameters);
        }

        /// <summary>
        /// Lưu thông tin giờ phút, số lần gửi xe của cuộc gọi.
        /// </summary>
        /// <param name="idCuocGoi">The identifier cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/10/2015   created
        /// </Modified>
        public bool EnVangVIP_GuiTinChoLaiXe(long idCuocGoi)
        {
            return this.RunStore("DienThoai_GuiTinChoLaiXe_EnVangVIP", idCuocGoi) > 0;
        }

        /// <summary>
        /// Lấy về các cuốc cho phần tổng đài
        /// </summary>
        /// <param name="vungsDuocCapPhep">The vungs duoc cap phep.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/18/2015   created
        /// </Modified>
        public DataSet EnVangVIP_TONGDAI_LayAllCuocGoi(string vungsDuocCapPhep)
        {

            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                return this.RunStoreData("EnVangVip_TONGDAI_sp_T_TAXIOPERATION_LayAllOfVungChoPhep", vungsDuocCapPhep);
            else
                return this.RunStoreData("EnVangVip_TONGDAI_sp_T_TAXIOPERATION_LayAllOfVungChoPhep", vungsDuocCapPhep);

        }

        /// <summary>
        /// Lay cac cuoc goi da don duoc khach
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <returns></returns>
        public DataSet EnVangVIP_TONGDAI_LayAllCuocGoi_DaDonKhach(string vungsDuocCapPhep)
        {
            return this.RunStoreData("EnVangVip_TONGDAI_sp_T_TAXIOPERATION_LayAllOfVungChoPhep_DaDonKhach", vungsDuocCapPhep);
        }
        public DataTable EnVangVip_TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@ListIDCuocGoi",SqlDbType.VarChar ,8000) 
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = listIDCuocGoiHienTai;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "EnVangVip_TONGDAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByDienThoai", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// ham xu ly lay id cuoc goi da ket thuc boi dien thoai                            
        /// </summary>
        /// <param name="listIDCuocGoiHienTai"></param>
        /// <param name="vungsDuocCapPhep"></param>
        /// <returns></returns>
        public DataTable EnVangVIP_TONGDAI_LayCacIDCuocGoiKetThucByDienThoai_DaDonKhach(string listIDCuocGoiHienTai, string vungsDuocCapPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VungChoPhep",SqlDbType.VarChar ,50),
                    new SqlParameter("@ListIDCuocGoi",SqlDbType.VarChar ,8000) 
           };
            parameters[0].Value = vungsDuocCapPhep;
            parameters[1].Value = listIDCuocGoiHienTai;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "EnVangVip_TONGDAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByDienThoai_DaDonKhach", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Tạo nhiều cuộc gọi cho én vàng vip dựa trên số lượng xe
        /// </summary>
        /// <param name="idCuocGoi">The identifier cuoc goi.</param>
        /// <param name="soLuong">The so luong.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/19/2015   created
        /// </Modified>
        public bool EnVangVIP_TaoNhieuCuocGoi(long idCuocGoi, int soLuong)
        {
            return this.RunStore("EnVangVip_sp_TaoNhieuCuocGoi", idCuocGoi, soLuong) > 0;
        }

        /// <summary>
        /// Tạo message confirm
        /// </summary>
        /// <param name="idCuocGoi">Id cuộc gọi.</param>
        /// <param name="maMessage">Mã số message.</param>
        /// <param name="canConfirm">Cần confirm</param>
        /// <param name="daGiaiQuyet">Giải quyết hay chưa</param>
        /// <param name="messageContent">Nội dung message</param>
        /// <param name="soHieuXe">Số hiệu xe.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/20/2015   created
        /// </Modified>
        public bool EnVangVIP_TaoMessageConfirm(long idCuocGoi, short maMessage, bool canConfirm, bool daGiaiQuyet, string messageContent, string soHieuXe)
        {
            return this.RunStore("EnVangVip_sp_CreateMessageConfirm", idCuocGoi, maMessage, canConfirm, daGiaiQuyet, messageContent, soHieuXe, null) > 0;
        }

        /// <summary>
        /// Én Vàng - Nhập dữ liệu giám sát xe
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/27/2015   created
        /// </Modified>
        public DataTable EnVangVIP_NhapDuLieuGiamSatXe(string bienSo, string maLaiXe, string viTriDiemBao
            , string trangThaiXeBao, int? diemDo, string isHoatDong, int? soPhutNghi, DateTime? thoiDiemVe, int node)
        {
            var result = this.RunStoreData("BANCO_NhapDuLieuGiamSatXe_Main"
                , bienSo, maLaiXe, viTriDiemBao, trangThaiXeBao
                , diemDo, isHoatDong, soPhutNghi
                , thoiDiemVe, false, 0, 0, node);

            if (result != null && result.Tables.Count > 0 && result.Tables[0] != null && result.Tables[0].Rows.Count > 0)
            {
                return result.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy về các xe đang chat
        /// </summary>
        /// <param name="lineChoPhep">The line cho phep.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/20/2015   created
        /// </Modified>
        public DataTable EnVangVip_DienThoai_LayCacXeDangChat(string lineChoPhep)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LineChoPhep",SqlDbType.VarChar,255)
                    
            };
            parameters[0].Value = lineChoPhep;


            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "EnVangVip_sp_CheckVehicleHasChat", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy nội dung chat của xe đang chọn
        /// </summary>
        public DataTable EnVangVip_DienThoai_LayNoiDungChatCuaXe(string soHieuXe, DateTime? thoiDiemLineChatCuoi = null)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,16),
                    new SqlParameter("@LastChatTime",SqlDbType.DateTime)
            };
            parameters[0].Value = soHieuXe;
            parameters[1].Value = thoiDiemLineChatCuoi;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "EnVangVip_sp_GetNewMessageChats", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy nội dung chat của xe đang chọn
        /// </summary>
        public DataTable EnVangVip_sp_GetMessageWithNoId(string openedMessageKeys)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ArrayOpenedMessage", SqlDbType.VarChar, 4000)
            };
            parameters[0].Value = openedMessageKeys;

            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "EnVangVip_sp_GetMessageWithNoId_V2", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy về xe đang nghỉ
        /// </summary>
        /// <param name="privateCodes">The private codes.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/28/2015   created
        /// </Modified>
        public DataTable EnVangVip_sp_GetRestingVehicle(string privateCodes)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@PrivateCodes",SqlDbType.VarChar,255)
            };
            parameters[0].Value = privateCodes;
            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "EnVangVip_sp_GetRestingVehicle", parameters))
            {
                g_sqlCon.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Tạo cuộc gọi khai thác cho én vàng
        /// </summary>
        /// <param name="soHieuXe">The so hieu xe.</param>
        /// <param name="thoiDiemBao">The thoi diem bao.</param>
        /// <param name="maLaiXe">The ma lai xe.</param>
        /// <param name="tenLaiXe">The ten lai xe.</param>
        /// <param name="viTriDiemBao">The vi tri diem bao.</param>
        /// <param name="diemDo">The diem do.</param>
        /// <param name="ghiChu">The ghi chu.</param>
        /// <param name="gioKhachLen">Length of the gio khach.</param>
        /// <param name="maNVTongDai">The ma nv tong dai.</param>
        /// <param name="maNVDienThoai">The ma nv dien thoai.</param>
        /// <param name="line">The line.</param>
        /// <param name="kinhDo">The kinh do.</param>
        /// <param name="viDo">The vi do.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/1/2015   created
        /// </Modified>
        public bool EnVangVip_sp_TaoCuocGoiKhaiThac(string soHieuXe, DateTime thoiDiemBao, string maLaiXe, string tenLaiXe, string viTriDiemBao,
            int diemDo, string ghiChu, DateTime gioKhachLen, string maNVTongDai, string maNVDienThoai, string line, double kinhDo, double viDo)
        {
            var result = this.RunStore("EnVangVip_sp_TaoCuocGoiKhaiThac"
                , soHieuXe, thoiDiemBao, maLaiXe, tenLaiXe, viTriDiemBao, diemDo, ghiChu, gioKhachLen, maNVTongDai, maNVDienThoai, line, kinhDo, viDo);
            return result > 0;
        }

        /// <summary>
        /// Đổi config có kết nối điện thoại hay không
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/3/2015   created
        /// </Modified>
        public bool EnVangVip_sp_ChangeDisconnectMobile(bool value)
        {
            return this.RunStore("EnVangVip_sp_ChangeDisconnectMobile", value) > 0;
        }
        public DataTable EnVangVip_TONGDAI_LayCuocGoiMoiTuDienThoai(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "EnVangVip_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai";
            return this.RunStoreData(SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI, vungsDuocCapPhep,thoiDiemLayDuLieuTruoc).Tables[0];
        }

        public DataTable EnVangVip_TONGDAI_LayCuocGoiMoiTuDienThoai_DaDonKhach(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI = "EnVangVip_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_DaDonKhach";
            return this.RunStoreData(SP_TONGDAI_T_TAXIOPERATION_LAYCUOCGOIMOITUDIENTHOAI, vungsDuocCapPhep,thoiDiemLayDuLieuTruoc).Tables[0];
        }

        #endregion

        #region ================================== G5  ==================================

        #region ---------------------------- Điện thoại ----------------------------

        #region === Const-Tối ưu hơn và nhanh hơn:Lưu ý thay đổi store thì cũng thay đổi commnet ===
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiNotFT
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiNotFT = "G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiNotFT";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoi
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoi = "G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoi";
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiSB = "G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiSB";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep = "G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep";
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepSB = "G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepSB";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepNotFT
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepNotFT = "G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepNotFT";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai = "G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai";
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDaiSB = "G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDaiSB";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDai
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDai = "G5_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDai";
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDaiSB = "G5_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDaiSB";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_GetVehiclePlateByBookId
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_GetVehiclePlateByBookId = "G5_DIENTHOAI_spT_TAXIOPERATION_GetVehiclePlateByBookId";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai_Khac
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai_Khac = "G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai_Khac";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLai
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLai = "G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLai";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLaiByBookID
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLaiByBookID = "G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLaiByBookID";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini = "G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini";
        //private const string G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini_V2 = "G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini_V2";
        /// <summary>
        /// Cập nhật cuộc gọi.
        /// V3 : Thêm số tiền
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini_V3 = "G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini_V6";
        /// <summary>
        /// G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V2
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi = "G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V2";
        //private const string G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V3 = "G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V3";
        /// <summary>
        /// V6 thêm MoneyTrip và IsDieuApp
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V6 = "G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V6";
        /// <summary>
        /// V5 thêm phần đường dài Long!
        /// </summary>
        private const string G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V5 = "G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V6_DuongDai";

        private const string G5_DIENTHOAI_spT_TAXIOPERATION_UpdateLenhCuocSB = "G5_DIENTHOAI_spT_TAXIOPERATION_UpdateLenhCuocSB";
        /// <summary>
        /// G5_sp_TAXIOPERATION_DienThoai_CopyNew
        /// </summary>
        private const string G5_sp_TAXIOPERATION_DienThoai_CopyNew = "G5_sp_TAXIOPERATION_DienThoai_CopyNew";
        /// <summary>
        /// G5_DIENTHOAI_UpdateBookIdByIdCuocGoi
        /// </summary>
        private const string G5_sp_DIENTHOAI_UpdateBookIdByIdCuocGoi = "G5_DIENTHOAI_UpdateBookIdByIdCuocGoi_V2";
        /// <summary>
        /// Cập nhật ghi chú tiếp nhận
        /// </summary>
        private const string G5_DIENTHOAI_UpdateGhiChuDienThoai_ByBookId = "G5_DIENTHOAI_UpdateGhiChuDienThoai_ByBookId";
        /// <summary>
        /// G5_DIENTHOAI_UpdateLenhMoiKhach
        /// </summary>
        private const string G5_sp_DIENTHOAI_UpdateLenhMoiKhach = "G5_DIENTHOAI_UpdateLenhMoiKhach";
        /// <summary>
        /// G5_DIENTHOAI_UpdateBookTimeout
        /// </summary>
        private const string G5_sp_DIENTHOAI_UpdateBookTimeout = "G5_DIENTHOAI_UpdateBookTimeout";
        /// <summary>
        /// G5_sp_DIENTHOAI_CheckTrungDiaChiDon
        /// </summary>
        private const string G5_sp_DIENTHOAI_CheckTrungDiaChiDon = "G5_sp_DIENTHOAI_CheckTrungDiaChiDon";

        #endregion

        #region == Const_New ==
        private const string G5_DIENTHOAI_TAXIOPERATION_GetNew = "G5_DIENTHOAI_TAXIOPERATION_GetNew";
        private const string G5_DIENTHOAI_TAXIOPERATION_GetUpdate = "G5_DIENTHOAI_TAXIOPERATION_GetUpdate";
        private const string G5_DIENTHOAI_TAXIOPERATION_GetDelete = "G5_DIENTHOAI_TAXIOPERATION_GetDelete";
        #endregion
        #region ********************************* Lấy dữ liệu **********************************
        #region == New ==
        public DataTable G5_DIENTHOAI_GetNew(string Line, DateTime LastUpdate)
        {
            return RunStoreData(G5_DIENTHOAI_TAXIOPERATION_GetNew, Line, LastUpdate).Tables[0];
        }
        public DataTable G5_DIENTHOAI_GetUpdate(string Line, DateTime LastUpdate)
        {
            return RunStoreData(G5_DIENTHOAI_TAXIOPERATION_GetUpdate, Line, LastUpdate).Tables[0];
        }
        public DataTable G5_DIENTHOAI_GetDelete(string Line, string LsID)
        {
            return RunStoreData(G5_DIENTHOAI_TAXIOPERATION_GetDelete, Line, LsID).Tables[0];
        }
        #endregion

        #region === Cuốc sân bay ===
        public DataTable G5_DIENTHOAI_LayAllCuocGoiSB()
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepSB).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayDSCuocGoiMoi_FTSB( DateTime thoiDiemLayTruoc)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiSB, thoiDiemLayTruoc).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDaiSB( DateTime thoiDiemNhanDulieuTruoc)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDaiSB, thoiDiemNhanDulieuTruoc).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDaiSB(string listIDCuocGoiHienTai)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDaiSB, listIDCuocGoiHienTai).Tables[0];
        }
        #endregion

        public DataTable G5_DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiNotFT, lineChoPhep, thoiDiemLayTruoc).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayDSCuocGoiMoi_FT(string lineChoPhep, DateTime thoiDiemLayTruoc)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoi, lineChoPhep, thoiDiemLayTruoc).Tables[0];
        }

        public DataTable G5_DIENTHOAI_LayAllCuocGoi(string lineChoPhep)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhep, lineChoPhep).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayAllCuocGoiNotFT(string lineChoPhep)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayAllOfLineChoPhepNotFT, lineChoPhep).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai, linesDuocCapPhep, thoiDiemNhanDulieuTruoc).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(string listIDCuocGoiHienTai, string linesDuocCapPhep)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayCacIDCuocGoiKetThucByTongDai, linesDuocCapPhep, listIDCuocGoiHienTai).Tables[0];
        }
        public DataTable G5_DIENTHOAI_TAXIOPERATION_GetVehiclePlateByBookId(Guid BookId)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_GetVehiclePlateByBookId, BookId).Tables[0];
        }
        public DataTable G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_Khac(string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_LayDSCuocGoiMoiCapNhatByTongDai_Khac, linesDuocCapPhep, thoiDiemNhanDulieuTruoc).Tables[0];
        }
        public DataTable ThongTinGoiLai(string Id)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLai, Id).Tables[0];
        }
        public DataTable GetThongTinGoiLaiByBookId(Guid bookId)
        {
            return RunStoreData(G5_DIENTHOAI_spT_TAXIOPERATION_ThongTinGoiLaiByBookID, bookId).Tables[0];
        }
        #endregion

        #region ********************** Cập nhật dữ liệu **********************

        public bool G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini(long idCuocGoi, string diaChiDonKhach,
            string diaChiTraKhachHang, string phoneNumber, int vung, string loaiXe, int soLuongXe,
            TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
            TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
            int thoiGianChuyenTongDai, double kinhDo, double viDo, string danhSachXeDeCu, string danhSachXeDeCuTd,
            string xeDon, KieuKhachHangGoiDen kieuKHGoiDen
            , string xeNhan, string xeDenDiem, LoaiCuocKhach loaiCuocKhach, bool ftIsFt, DateTime? ftDate,
            DateTime? ftSendDate, Enum_FastTaxi_Status ftStatus, Guid bookId, int g5Type,
            string SanBay_DuongDai, string g5CarType,string xeDungDiem)
        {
            return RunStore(G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini,
                idCuocGoi, diaChiDonKhach, vung, soLuongXe, loaiXe, 0, (int)trangThaiCuocGoi,
                (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, (int)trangThaiLenh,
                ghiChuDienThoai, maNhanVienDienThoai, thoiGianChuyenTongDai, kinhDo, viDo,
                phoneNumber, danhSachXeDeCu, danhSachXeDeCuTd, xeDon, (int)kieuKHGoiDen, xeNhan,
                xeDenDiem, ftIsFt, ftDate, ftSendDate, diaChiTraKhachHang, (int)ftStatus, bookId, g5Type, SanBay_DuongDai, g5CarType,xeDungDiem) > 0;
        }
        public bool G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini_V2(long idCuocGoi, string diaChiDonKhach,
           string diaChiTraKhachHang, string phoneNumber, int vung, string loaiXe, int soLuongXe,
           TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi, string lenhDienThoai,
           TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
           int thoiGianChuyenTongDai, double kinhDo, double viDo, string danhSachXeDeCu, string danhSachXeDeCuTd,
           string xeDon, KieuKhachHangGoiDen kieuKHGoiDen
           , string xeNhan, string xeDenDiem, LoaiCuocKhach loaiCuocKhach, bool ftIsFt, DateTime? ftDate,
           DateTime? ftSendDate, Enum_FastTaxi_Status ftStatus, Guid bookId, int g5Type,
           string SanBay_DuongDai, string g5CarType, DateTime ThoiGianHen, int moneyTrip, bool isDieuApp = false, string diachiGoi = "")
        {
            return RunStore(G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_Mini_V3,
                idCuocGoi, diaChiDonKhach, vung, soLuongXe, loaiXe, 0, (int)trangThaiCuocGoi,
                (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, (int)trangThaiLenh,
                ghiChuDienThoai, maNhanVienDienThoai, thoiGianChuyenTongDai, kinhDo, viDo,
                phoneNumber, danhSachXeDeCu, danhSachXeDeCuTd, xeDon, (int)kieuKHGoiDen, xeNhan,
                xeDenDiem, ftIsFt, ftDate, ftSendDate, diaChiTraKhachHang, (int)ftStatus
                , bookId, g5Type, SanBay_DuongDai, g5CarType, ThoiGianHen, moneyTrip, isDieuApp,diachiGoi) > 0;
        }

        /// <summary>
        /// Cập nhật thông tin cuốc khách
        /// </summary>
        public bool G5_DIENTHOAI_UpdateThongTinCuocGoi(
            long idCuocGoi, string diaChiDonKhach, string diaChiTraKhach, string phoneNumber,
            int vung, string loaiXe, int soLuongXe, TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi,
            string lenhDienThoai, TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
           int thoiGianChuyenTongDai, double kinhDo, double viDo, string danhSachXeDeCu, string danhSachXeDeCuTd,
           string xeDon, KieuKhachHangGoiDen kieuKHGoiDen, LoaiCuocKhach loaiCuocKhach, bool ftIsFt, DateTime? ftDate,
           DateTime? ftSendDate, Enum_FastTaxi_Status ftStatus, Guid bookId, int g5Type,
            string SanBay_DuongDai, string g5CarType, string XeNhan)
        {

            return RunStore(G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi,
                    idCuocGoi, diaChiDonKhach, (long)vung, soLuongXe, loaiXe, 0, (int)trangThaiCuocGoi,
                    (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, (int)trangThaiLenh, ghiChuDienThoai,
                    maNhanVienDienThoai, thoiGianChuyenTongDai, kinhDo, viDo, phoneNumber, danhSachXeDeCu,
                    danhSachXeDeCuTd, xeDon, (int)kieuKHGoiDen, ftIsFt, ftDate, ftSendDate, diaChiTraKhach,
                    (int)ftStatus, bookId, g5Type, SanBay_DuongDai, g5CarType, XeNhan) > 0;
        }

        /// <summary>
        /// update lệnh khi sử dụng điều sân bay
        /// Người điều sân bay(Tổng đài mini) gửi lệnh đến DTV của cuốc không thuộc line của mình
        /// </summary>
        public bool G5_DIENTHOAI_UpdateLenhCuocSB(long IdCuocGoi, string LenhTongDai, TrangThaiLenhTaxi trangThaiLenh, TrangThaiCuocGoiTaxi trangThaiCuocGoi)
        {

            return RunStore(G5_DIENTHOAI_spT_TAXIOPERATION_UpdateLenhCuocSB, IdCuocGoi,LenhTongDai, trangThaiLenh, trangThaiCuocGoi) > 0;
        }

        public bool G5_DIENTHOAI_UpdateThongTinCuocGoi_V2(
           long idCuocGoi, string diaChiDonKhach, string diaChiTraKhach, string phoneNumber,
           int vung, string loaiXe, int soLuongXe, TrangThaiCuocGoiTaxi trangThaiCuocGoi, KieuCuocGoi kieuCuocGoi,
           string lenhDienThoai, TrangThaiLenhTaxi trangThaiLenh, string ghiChuDienThoai, string maNhanVienDienThoai,
          int thoiGianChuyenTongDai, double kinhDo, double viDo, string danhSachXeDeCu, string danhSachXeDeCuTd,
          string xeDon, KieuKhachHangGoiDen kieuKHGoiDen, LoaiCuocKhach loaiCuocKhach, bool ftIsFt, DateTime? ftDate,
          DateTime? ftSendDate, Enum_FastTaxi_Status ftStatus, Guid bookId, int g5Type,
           string SanBay_DuongDai, string g5CarType, string XeNhan, DateTime ThoiGianHen, 
            int moneyTrip, double kinhDo_Tra, double viDo_Tra, bool isDieuApp)
        {

            return RunStore(G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V6,
                    idCuocGoi, diaChiDonKhach, (long)vung, soLuongXe, loaiXe, 
                    0, (int)trangThaiCuocGoi, (int)kieuCuocGoi, (int)loaiCuocKhach, lenhDienThoai, 
                    (int)trangThaiLenh, ghiChuDienThoai, maNhanVienDienThoai, thoiGianChuyenTongDai, kinhDo, 
                    viDo, phoneNumber, danhSachXeDeCu, danhSachXeDeCuTd, xeDon, 
                    (int)kieuKHGoiDen, ftIsFt, ftDate, ftSendDate, diaChiTraKhach,
                    (int)ftStatus, bookId, g5Type, SanBay_DuongDai, g5CarType,
                    XeNhan, ThoiGianHen, moneyTrip, kinhDo_Tra, viDo_Tra, isDieuApp) > 0;
        }

        /// <summary>
        /// Cập nhật cuộc gọi lần đầu khi nhập liệu trên form popup *sign
        /// </summary>
        public bool G5_DienThoai_UpdateThongTinCuocGoi_V3(
                        long pID, string pDiaChiDon, string pDiaChiTra, string pPhoneNumber, 
                        int pVung, string pLoaiXe, int pSoLuongXe, TrangThaiCuocGoiTaxi pTrangThai, KieuCuocGoi pKieuCuocGoi, 
                        string pLenhDienThoai, TrangThaiLenhTaxi pTrangThaiLenhTaxi, string pGhiChuDienThoai, string pMaNVDT, 
                        int pThoiGianChuyenTD, double pKinhDo, double pViDo, string pDSXeDeCu, string pDSXeDeCuTD, 
                        string pXeDon, KieuKhachHangGoiDen pKieuKHGoiDen, LoaiCuocKhach pLoaiCuocKhach, bool pIsFT, DateTime? pFTDate,
                        DateTime? pFTSendDate, Enum_FastTaxi_Status pFTStatus, Guid pBookID, int pG5Type, 
                        string pSanBay_DuongDai, string pG5CarType, string pXeNhan, DateTime pThoiGianHen, int pMoneyTrip,
                        string pLong_TuyenID, int pLong_ChieuID, string pLong_LoaiXeID, int pLong_GiaTien, int pLong_Km
                    , int pLong_ThoiGian, double pKinhDo_Tra, double pViDo_Tra, bool isDieuApp, string diachiGoi)
        {
            return RunStore(G5_DIENTHOAI_spT_TAXIOPERATION_CapNhatCuocGoi_V5, 
                    pID,pDiaChiDon,pDiaChiTra,pPhoneNumber,pVung,pLoaiXe,pSoLuongXe,0,(int)pTrangThai,(int)pKieuCuocGoi,
                    pLenhDienThoai,(int)pTrangThaiLenhTaxi,pGhiChuDienThoai,pMaNVDT,pThoiGianChuyenTD,pKinhDo,pViDo,pDSXeDeCu,pDSXeDeCuTD,
                    pXeDon,(int)pKieuKHGoiDen,(int)pLoaiCuocKhach,pIsFT,pFTDate,pFTSendDate,(int)pFTStatus,pBookID,pG5Type,pSanBay_DuongDai,pG5CarType,pXeNhan,
                    pThoiGianHen, pMoneyTrip, pLong_TuyenID, pLong_ChieuID, pLong_LoaiXeID, pLong_GiaTien, pLong_Km, pLong_ThoiGian, pKinhDo_Tra, pViDo_Tra, isDieuApp, diachiGoi) > 0;
        }
        public bool G5_DIENTHOAI_CopyCuocGoi(long idCuocGoi, int G5Type)
        {
            return RunStore(G5_sp_TAXIOPERATION_DienThoai_CopyNew, idCuocGoi, G5Type) > 0;
        }
        public bool G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(Guid bookId, long idCuocGoi, int type, string LenhDTV)
        {
            return RunStore(G5_sp_DIENTHOAI_UpdateBookIdByIdCuocGoi, bookId, idCuocGoi, type, LenhDTV) > 0;
        }
        public bool G5_DIENTHOAI_UpdateGhiChuDTV_ByBookId(Guid bookId, long idCuocGoi, string GhiChuDTV)
        {
            return RunStore(G5_DIENTHOAI_UpdateGhiChuDienThoai_ByBookId, bookId, idCuocGoi, GhiChuDTV) > 0;
        }
        /// <summary>
        /// Cập nhật lệnh điện thoại viên khi thực hiện lệnh đã mời khách trên form cảnh báo
        /// </summary>
        public bool G5_DIENTHOAI_UpdateLenhMoiKhach(long idCuocGoi, string lenhDTV)
        {
            return RunStore(G5_sp_DIENTHOAI_UpdateLenhMoiKhach, idCuocGoi, lenhDTV) > 0;
        }
        public bool G5_DIENTHOAI_UpdateBookTimeout(Guid bookId)
        {
            return RunStore(G5_sp_DIENTHOAI_UpdateBookTimeout, bookId) > 0;
        }
       /// <summary>
        ///  Kiểm tra địa chỉ đón khách trùng nhau mà do các số điện thoại khác nhau gọi đến xem có phải cùng 1 khách không
       /// </summary>
       /// <param name="idCuocGoi"></param>
       /// <param name="diaChiDon"></param>
       /// <returns> 1 Số điện thoại của cuốc đã gọi trước đó có cùng địa chỉ đón</returns>
        public string G5_DIENTHOAI_CheckTrungDiaChiDon(long idCuocGoi, string diaChiDon)
        {
            DataTable dt = RunStoreData(G5_sp_DIENTHOAI_CheckTrungDiaChiDon, idCuocGoi, diaChiDon).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion
        #endregion

        #region ---------------------------- Tổng đài ------------------------------

        #region === Const-Tối ưu hơn và nhanh hơn:Lưu ý thay đổi store thì cũng thay đổi commnet ===
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep = "G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT = "G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc = "G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThucNotFT
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThucNotFT = "G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThucNotFT";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhan
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhan = "G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhan";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhanNotFT
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhanNotFT = "G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhanNotFT";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_ChuaNhan
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_ChuaNhan = "G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_ChuaNhan";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai = "G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT_ChuaNhan
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT_ChuaNhan = "G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT_ChuaNhan";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT = "G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT";
        /// <summary>
        /// G5_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_V2
        /// </summary>
        private const string G5_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi = "G5_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi_V2";
        #endregion

        #region ********************************* Lấy dữ liệu **********************************
        /// <summary>
        /// hàm trả về thông tin tất cả cuộc gọi theo vùng
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <returns></returns>
        public DataSet G5_TONGDAI_LayAllCuocGoi(string vungsDuocCapPhep)
        {

            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep, vungsDuocCapPhep);
            else
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhep, vungsDuocCapPhep);

        }
        public DataSet G5_TONGDAI_LayAllCuocGoiNotFT(string vungsDuocCapPhep)
        {

            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT, vungsDuocCapPhep);
            else
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayAllOfVungChoPhepNotFT, vungsDuocCapPhep);

        }
        public DataTable G5_TONGDAI_LayCuocGoiDaGiaiQuyet(string vungsDuocCapPhep, int soDong)
        {
            return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThuc, vungsDuocCapPhep, 1, soDong).Tables[0];
        }
        public DataTable G5_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(string vungsDuocCapPhep, int soDong)
        {
            return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_KETTHUC_LayDSCuocKetThucNotFT, vungsDuocCapPhep, 1, soDong).Tables[0];
        }
        /// <summary>
        /// Lấy các cuộc điện thoại mà tổng đài viên đã nhận xử lý.
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <returns></returns>
        public DataTable G5_TONGDAI_LayCuocGoiDaNhanXuLy(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhan, vungsDuocCapPhep, thoiDiemLayDuLieuTruoc).Tables[0];
        }
        /// <summary>
        ///       Lấy các cuộc điện thoại mà tổng đài viên đã nhận xử lý không phải là FT.
        /// </summary>
        public DataTable G5_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            return this.RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_TD_DaNhanNotFT, vungsDuocCapPhep, thoiDiemLayDuLieuTruoc).Tables[0];
        }
        public DataTable G5_TONGDAI_LayCuocGoiMoiTuDienThoai(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai_ChuaNhan, vungsDuocCapPhep,
                     thoiDiemLayDuLieuTruoc).Tables[0];
            else
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoai, vungsDuocCapPhep,
                        thoiDiemLayDuLieuTruoc).Tables[0];
        }
        public DataTable G5_TONGDAI_LayCuocGoiMoiTuDienThoaiNotFT(string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc)
        {
            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT_ChuaNhan, vungsDuocCapPhep,
                    thoiDiemLayDuLieuTruoc).Tables[0];
            else
                return RunStoreData(G5_TONGDAI_spT_TAXIOPERATION_LayCuocGoiMoiTuDienThoaiNotFT, vungsDuocCapPhep,
                        thoiDiemLayDuLieuTruoc).Tables[0];
        }

        public DataTable TongDai_LayDanhSachCacCuocDieuApp(string soDT, string diachi,string soXe)
        {
            return RunStoreData("sp_TongDai_LayDanhSachCacCuocDieuApp", soDT, diachi,soXe).Tables[0];
        }
        #endregion

        #region ********************************** Cập nhật dữ liệu ****************************
        /// <summary>
        /// Cập nhật thông tin vào cơ sở dữ liệu từ tổng đài viên
        /// </summary>
        public bool G5_TONGDAI_UpdateThongTinCuocGoi(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCuocGoiTaxi,
                                               string lenhTongDai, string ghiChuTongDai, TrangThaiLenhTaxi trangThaiLenhTaxi,
                                               string idNVTD, string xeNhan, string xeDon, string diaChiTraKhach, int thoiGianDieuXe,
                                               int thoigianDonKhach, bool chuyenMK, string xeDenDiem, string DiaChiDonKhach, string xeDungDiem, string XeMK)
        {
            return this.RunStore(G5_TONGDAI_spT_TAXIOPERATION_CapNhatCuocGoi, idCuocGoi, trangThaiCuocGoiTaxi,
                    lenhTongDai, trangThaiLenhTaxi, ghiChuTongDai, idNVTD, xeNhan, xeDon, diaChiTraKhach, thoiGianDieuXe,
                    thoigianDonKhach, chuyenMK, xeDenDiem, DiaChiDonKhach, xeDungDiem, XeMK) > 0;
        }

        #endregion

        #endregion
        #endregion


    }

    #region Remove

    public class CuocGoiDienThoaiLanDauType
    {
        #region Properties
        private long id;
        /// <summary>
        /// Ma cuoc goi
        /// </summary>
        public long IDCuocGoi
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime thoiDiemGoi;
        /// <summary>
        /// thoi diem goi
        /// </summary>
        public DateTime ThoiDiemGoi
        {
            get { return thoiDiemGoi; }
            set { thoiDiemGoi = value; }
        }
        private byte soLanGoi;
        /// <summary>
        /// số lần khách đã gọi
        /// </summary>
        public byte SoLanGoi
        {
            get { return soLanGoi; }
            set { soLanGoi = value; }
        }
        private int line;
        /// <summary>
        /// line dien thoai
        /// </summary>
        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        private string phoneNumber;
        /// <summary>
        /// so dien thoai goi den
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }


        private string diaChiLuu;
        /// <summary>
        /// dia chi luu, dia chi luu tu he thong co the lay lai su dung
        /// </summary>
        public string DiaChiGoi
        {
            get { return diaChiLuu; }
            set { diaChiLuu = value; }
        }
        private string diaChiDonKhach;
        /// <summary>
        /// dia chi thuc hien don khach
        /// </summary>
        public string DiaChiDonKhach
        {
            get { return diaChiDonKhach; }
            set { diaChiDonKhach = value; }
        }
        private byte vung;
        /// <summary>
        /// vung (kenh) cua diem dia chi don khach
        /// </summary>
        public byte Vung
        {
            get { return vung; }
            set { vung = value; }
        }

        private KieuKhachHangGoiDen loaiKhachHang;
        /// <summary>
        /// kieu khach hang goi den 
        /// KhachHangKhongHieu = 0, // khach vui ve, khach ao
        /// KhachHangBinhThuong=1,
        /// KhachHangMoiGioi=2,
        /// KhachHangVIP=3,
        /// KhachHangHen=9,
        /// </summary>
        public KieuKhachHangGoiDen KieuKhachHangGoiDen
        {
            get { return loaiKhachHang; }
            set { loaiKhachHang = value; }
        }

        private string loaiXe;
        /// <summary>
        /// Loại Xe
        /// </summary>
        public string LoaiXe
        {
            get { return loaiXe; }
            set { loaiXe = value; }
        }

        private string lenhDienThoai;
        /// <summary>
        /// LenhDienThoai
        /// </summary>
        public string LenhDienThoai
        {
            get { return lenhDienThoai; }
            set { lenhDienThoai = value; }
        }

        private string ghiChuDienThoai;
        public string GhiChuDienThoai
        {
            get { return ghiChuDienThoai; }
            set { ghiChuDienThoai = value; }
        }

        private string xeNhan;
        public string XeNhan
        {
            get { return xeNhan; }
            set { xeNhan = value; }
        }
        private string maDoiTac;
        public string MaDoiTac
        {
            get { return maDoiTac; }
            set { maDoiTac = value; }
        }

        private float gps_KinhDo;
        public float GPS_KinhDo
        {
            get { return gps_KinhDo; }
            set { gps_KinhDo = value; }
        }

        private float gps_ViDo;
        public float GPS_ViDo
        {
            get { return gps_ViDo; }
            set { gps_ViDo = value; }
        }
        public DateTime? FT_SendDate { get; set; }
        public DateTime? FT_Date { get; set; }
        public bool FT_IsFT { get; set; }
        public int FT_Status { get; set; }
        public long FT_ID { get; set; }
        public float FT_Cust_Lat { get; set; }
        public float FT_Cust_Lng { get; set; }
        public bool FT_AllowCall { get; set; }
        public string DiaChiTraKhach { get; set; }

        public KieuCuocGoi KieuCuocGoi { get; set; }
        public bool? KhongDungMobileService { get; set; }
        #region EnVang
        public string MH_LenhLaiXe { get; set; }
        public DateTime? MH_ThoiDiemGuiXe { get; set; }
        public int MH_SoLanGuiToiXe { get; set; }
        public bool MH_DaGuiXe { get; set; }
        public string GhiChuLaiXe { get; set; }
        public string XeDon { get; set; }
        public byte? DaGuiDSXeNhan { get; set; }
        public byte? CenterConfirm { get; set; }
        public string DanhSachXeDeCu { get; set; }
        public string LenhTongDai { get; set; }
        public string GhiChuTongDai { get; set; }
        #endregion
        #endregion Properties
        /// <summary>
        /// Khởi tạo thông tin cuộc gọi lấy lần đầu cho điện thoại
        /// </summary>

        public CuocGoiDienThoaiLanDauType(long id, DateTime thoiDiemGoi, byte soLanGoi, int line, string phoneNumber, string diaChiLuu,
                                          string diaChiDonKhach, byte vungDieuDam, KieuKhachHangGoiDen loaiKhachHang, string loaiXe, string lenhDienThoai, string ghiChuDienThoai, string xeNhan)
        {

            IDCuocGoi = id;
            ThoiDiemGoi = thoiDiemGoi;
            SoLanGoi = soLanGoi;
            Line = line;
            PhoneNumber = phoneNumber;
            DiaChiGoi = diaChiLuu;
            DiaChiDonKhach = diaChiDonKhach;
            Vung = vungDieuDam;
            KieuKhachHangGoiDen = loaiKhachHang;
            LoaiXe = loaiXe;
            LenhDienThoai = lenhDienThoai;
            GhiChuDienThoai = ghiChuDienThoai;
            XeNhan = xeNhan;
        }

        public CuocGoiDienThoaiLanDauType(long id, DateTime thoiDiemGoi, byte soLanGoi, byte line, string phoneNumber, string diaChiLuu,
                                          string diaChiDonKhach, byte vungDieuDam, KieuKhachHangGoiDen loaiKhachHang
            , string loaiXe, string lenhDienThoai, string ghiChuDienThoai, string xeNhan, string maDoiTac, string kinhDo, string viDo)
        {

            IDCuocGoi = id;
            ThoiDiemGoi = thoiDiemGoi;
            SoLanGoi = soLanGoi;
            Line = line;
            PhoneNumber = phoneNumber;
            DiaChiGoi = diaChiLuu;
            DiaChiDonKhach = diaChiDonKhach;
            Vung = vungDieuDam;
            KieuKhachHangGoiDen = loaiKhachHang;
            LoaiXe = loaiXe;
            LenhDienThoai = lenhDienThoai;
            GhiChuDienThoai = ghiChuDienThoai;
            XeNhan = xeNhan;
            MaDoiTac = maDoiTac;
            if (!string.IsNullOrEmpty(kinhDo) && !string.IsNullOrEmpty(viDo))
            {
                GPS_KinhDo = float.Parse(kinhDo);
                GPS_ViDo = float.Parse(viDo);
            }
        }

    }

    public class CuocGoiTongDaiCapNhatType
    {
        #region Properties

        private long id;
        /// <summary>
        /// Ma cuoc goi
        /// </summary>
        public long IDCuocGoi
        {
            get { return id; }
            set { id = value; }
        }

        private TrangThaiCuocGoiTaxi trangThaiCuocGoi;
        /// <summary>
        /// trang thai cuoc goi taxi
        ///  KhongXacDinh, DonDuoc, Truot, Hoan, KhongXe
        /// </summary>
        public TrangThaiCuocGoiTaxi TrangThaiCuocGoi
        {
            get { return trangThaiCuocGoi; }
            set { trangThaiCuocGoi = value; }
        }
        private KieuCuocGoi kieuCuocGoi;

        public KieuCuocGoi KieuCuocGoi
        {
            get { return kieuCuocGoi; }
            set { kieuCuocGoi = value; }
        }

        private string diaChiDonKhach;
        /// <summary>
        /// lenh tong dai chuyen sang ben dien thoai
        /// </summary>
        public string DiaChiDonKhach
        {
            get { return diaChiDonKhach; }
            set { diaChiDonKhach = value; }
        }

        private string lenhTongDai;
        /// <summary>
        /// lenh tong dai chuyen sang ben dien thoai
        /// </summary>
        public string LenhTongDai
        {
            get { return lenhTongDai; }
            set { lenhTongDai = value; }
        }

        private string lenhDienThoai;
        /// <summary>
        /// lenh dien thoai
        /// </summary>
        public string LenhDienThoai
        {
            get { return lenhDienThoai; }
            set { lenhDienThoai = value; }
        }
        private TrangThaiLenhTaxi trangThaiLenh;
        /// <summary>
        /// trang thai lenh  gan den thay thong tin ben nao thay doi tran trai cuoi cung
        /// 
        /// </summary>
        public TrangThaiLenhTaxi TrangThaiLenh
        {
            get { return trangThaiLenh; }
            set { trangThaiLenh = value; }
        }

        private string ghiChuTongDai;
        /// <summary>
        /// thong tin ghi chu cua nhan vien Tong dai
        /// </summary>
        public string GhiChuTongDai
        {
            get { return ghiChuTongDai; }
            set { ghiChuTongDai = value; }
        }

        private string ghiChuDienThoai;
        /// <summary>
        /// thong tin ghi chu cua nhan vien Tong dai
        /// </summary>
        public string GhiChuDienThoai
        {
            get { return ghiChuDienThoai; }
            set { ghiChuDienThoai = value; }
        }

        private string nhanVienTongDai;

        public string NhanVienTongDai
        {
            get { return nhanVienTongDai; }
            set { nhanVienTongDai = value; }
        }

        private string nhanVienDienThoai;

        public string NhanVienDienThoai
        {
            get { return nhanVienDienThoai; }
            set { nhanVienDienThoai = value; }
        }

        private string xeNhan;
        /// <summary>
        /// Xe nhan
        /// </summary>
        public string XeNhan
        {
            get { return xeNhan; }
            set { xeNhan = value; }
        }
        private string xeDon;
        /// <summary>
        /// xe don 
        /// </summary>
        public string XeDon
        {
            get { return xeDon; }
            set { xeDon = value; }
        }

        private int thoiGianDieuXe;
        /// <summary>
        /// thoi gian dieu duoc xe nhan (theo giay)
        /// </summary>
        public int ThoiGianDieuXe
        {
            get { return thoiGianDieuXe; }
            set { thoiGianDieuXe = value; }
        }

        private string fileVoicePath;
        /// <summary>
        /// duoc dan file am thanh luu
        /// </summary>
        public string FileVoicePath
        {
            get { return fileVoicePath; }
            set { fileVoicePath = value; }
        }

        private int vungGPSID;
        /// <summary>
        /// dung cua diem khach goi, tai mot 
        /// </summary>
        public int VungGPSID
        {
            get { return vungGPSID; }
            set { vungGPSID = value; }
        }

        private double gps_KinhDo;
        /// <summary>
        /// kinh do cua diem khach goi
        /// </summary>
        public double GPS_KinhDo
        {
            get { return gps_KinhDo; }
            set { gps_KinhDo = value; }
        }
        private double gps_ViDo;
        /// <summary>
        /// vi do cua diem khach goi
        /// </summary>
        public double GPS_ViDo
        {
            get { return gps_ViDo; }
            set { gps_ViDo = value; }
        }
        private string danhSachXeDeCu;
        /// <summary>
        /// danh sach xe de cu
        /// </summary>
        public string DanhSachXeDeCu
        {
            get { return danhSachXeDeCu; }
            set { danhSachXeDeCu = value; }
        }
        private DateTime thoiDiemCapNhatXeDeCu;
        /// <summary>
        /// thoi diem cap nhat xe de cu
        /// </summary>
        public DateTime ThoiDiemCapNhatXeDeCu
        {
            get { return thoiDiemCapNhatXeDeCu; }
            set { thoiDiemCapNhatXeDeCu = value; }
        }

        private string _MOIKHACH_LenhMoiKhach;

        public string MOIKHACH_LenhMoiKhach
        {
            get { return _MOIKHACH_LenhMoiKhach; }
            set { _MOIKHACH_LenhMoiKhach = value; }
        }

        private string _MOIKHACH_NhanVien;

        public string MOIKHACH_NhanVien
        {
            get { return _MOIKHACH_NhanVien; }
            set { _MOIKHACH_NhanVien = value; }
        }

        private string _XeDenDiem;

        public string XeDenDiem
        {
            get { return _XeDenDiem; }
            set { _XeDenDiem = value; }
        }

        private string _XeDenDiemDonKhach;

        public string XeDenDiemDonKhach
        {
            get { return _XeDenDiemDonKhach; }
            set { _XeDenDiemDonKhach = value; }
        }

        #endregion Properties

        public CuocGoiTongDaiCapNhatType(long idCuocGoi, TrangThaiCuocGoiTaxi trangThaiCG, string lenhTongDai, string ghiChuTongDai, string lenhDT, string ghiChuDT,
                                         string nhanVienTD, string nhanVienDT, string xeNhan, int thoiGianDieuXe, string fileVoicePath, int vungGPS,
                                         double gpsKinhDo, double gpsViDo, string DSXeDeCu, DateTime thoiDiemCapNhatXeDeCu,
                                         TrangThaiLenhTaxi trangThaiLenh, string lenhMoiKhach, string xeDenDiem, string xeDenDiemDonKhach)
        {
            IDCuocGoi = idCuocGoi;
            TrangThaiCuocGoi = trangThaiCG;
            LenhTongDai = lenhTongDai;
            GhiChuTongDai = ghiChuTongDai;
            NhanVienTongDai = nhanVienTD;
            LenhDienThoai = lenhDT;
            GhiChuDienThoai = ghiChuDT;
            NhanVienDienThoai = nhanVienDT;
            XeNhan = xeNhan;
            ThoiGianDieuXe = thoiGianDieuXe;
            FileVoicePath = fileVoicePath;
            VungGPSID = vungGPS;
            GPS_KinhDo = gpsKinhDo;
            GPS_ViDo = gpsViDo;
            DanhSachXeDeCu = DSXeDeCu;
            ThoiDiemCapNhatXeDeCu = thoiDiemCapNhatXeDeCu;
            TrangThaiLenh = trangThaiLenh;
            MOIKHACH_LenhMoiKhach = lenhMoiKhach;
            XeDenDiem = xeDenDiem;
            XeDenDiemDonKhach = xeDenDiemDonKhach;
        }
    }
    #endregion
}