using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.CheckCoDuongDai 
{    
    public class CheckCoDuongDai : DBObject
    {
        // Ten thủ tục
        private string SP_GETDM_TINHTHANH = "spTaxiOperationGPS_MaiLinh_GetDMTinhThanh";
        private string SP_CHECK_SOHIEUXE_TONTAI = "spTaxiOperationGPS_MaiLinh_CheckSoHieuXeTonTai";
        private string SP_INSERT_CHECKCO = "V2_spTaxiOperationGPS_MaiLinh_InsertCheckCo";
        private string SP_GETCUOC_DUONGDAI_SANBAY = "V2_spTaxiOperationGPS_MaiLinh_GetCuocDuongDai_SanBay";
        private string SP_GETCUOC_DUONGDAI_SANBAY_GARA = "V2_spTaxiOperationGPS_MaiLinh_GetCuocDuongDai_SanBay_Gara";
        private string SP_UPDATE_CHECKCO = "V2_spTaxiOperationGPS_MaiLinh_UpdateCheckCo";
        private string SP_DELETE_CHECKCO = "spTaxiOperationGPS_MaiLinh_DeleteCheckCo";

        public string ConnectString = string.Empty;

        public CheckCoDuongDai()
        { 
            // chuỗi kết nối cơ sở dữ liệu
            ConnectString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString.ToString();
        }
       
        /// <summary>
        /// lấy ra danh mục các tỉnh thành
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// Name        Date        Comment
        /// hangtm      4/7/2011    created
        /// </modified>
        public DataSet GetDMTinhThanh()
        { 
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { };
                ds = this.RunProcedure(SP_GETDM_TINHTHANH, parameters, "DMTinhThanh");
                return ds;
            }
        }

        public DataSet GetProvince()
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { };
                ds = RunProcedure("SP_GIS_T_PROVINCE_GETALL", parameters, "DMTinhThanh");
                return ds;
            }
        }

        public DataSet GetDistrict()
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { };
                ds = this.RunProcedure("SP_GIS_T_DISTRICT_GETALL", parameters, "DMQuanHuyen");
                return ds;
            }
        }

        public DataSet GetCommune()
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { };
                ds = this.RunProcedure("SP_GIS_T_COMMUNE_GETALL", parameters, "DMPhuongxa");
                return ds;
            }
        }


        /// <summary>
        /// Kiem tra so hieu xe co ton tai khong
        /// </summary>
        /// <modified>
        /// name        date        comment
        /// hangtm      4/7/2011   created
        /// </modified>
        public bool CheckSoHieuXe(string SoHieuXe)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                     new SqlParameter ("@SoHieuXe",SqlDbType.VarChar ,10),
                     new SqlParameter ("@TonTai",SqlDbType.Bit )
                 };
                parameters[0].Value = SoHieuXe;
                parameters[1].Direction = ParameterDirection.Output;

                this.RunProcedure(SP_CHECK_SOHIEUXE_TONTAI, parameters, rowsAffected);
                return Convert.ToBoolean(parameters[1].Value);
            }
        }
        /// <summary>
        /// Insert du lieu vao bang T_SANBAY_DUONGDAI
        /// </summary>
        /// <modified>
        /// name            date        comment
        /// hangtm          4/7/2011    created
        ///</modified>
        public int InsertCheckCo(string soHieuXe, string diaDiemDi, string diaDiemDen, int tinhThanhID, int coDau, int coCuoi,
                                DateTime thoiDiemDi, DateTime thoiDiemVe, bool chieuDi, float tongTien, string ghiChu, string userName
            , int TinhThanhDiID, int QuanHuyenDiID, int QuanHuyenDenID, int PhuongXaDiID, int PhuongXaDenID, string TenLaiXe, string soDienThoai, bool isChiaSe)
        {
            int rowAffects = 0;
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar ,16),
                    new SqlParameter("@DiaDiemDi",SqlDbType.NVarChar,50),
                    new SqlParameter("@DiaDiemDen",SqlDbType.NVarChar,50),
                    new SqlParameter("@TinhThanhDenID",SqlDbType.Int),
                    new SqlParameter("@CoDau",SqlDbType.Int ),
                    new SqlParameter("@CoCuoi",SqlDbType.Int),
                    new SqlParameter("@ThoiDiemDi",SqlDbType.DateTime ),
                    new SqlParameter("@ThoiDiemVe",SqlDbType.DateTime ),
                    new SqlParameter("@ChieuDi",SqlDbType.Bit),
                    new SqlParameter("@TongTien",SqlDbType.Float),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,150),
                    new SqlParameter("@CreatedByUser",SqlDbType.NVarChar,50),
                    new SqlParameter("@OUTPUT",SqlDbType.BigInt),
                    new SqlParameter("@TinhThanhDiID",SqlDbType.Int ),
                    new SqlParameter("@QuanHuyenDiID",SqlDbType.Int ),
                    new SqlParameter("@QuanHuyenDenID",SqlDbType.Int ),
                    new SqlParameter("@PhuongXaDiID",SqlDbType.Int ),
                    new SqlParameter("@PhuongXaDenID",SqlDbType.Int ),
                    new SqlParameter("@TenLaiXe",SqlDbType.NVarChar ,100),
                    new SqlParameter("@SoDienThoai",SqlDbType.VarChar ,50),
                    new SqlParameter("@isChiaSeChuyenDi",SqlDbType.Bit)
                    };
                    parameters[0].Value = soHieuXe;
                    parameters[1].Value = diaDiemDi;
                    parameters[2].Value = diaDiemDen;
                    if (tinhThanhID > 0)
                    {
                        parameters[3].Value = tinhThanhID;
                    }
                    parameters[4].Value = coDau;
                    parameters[5].Value = coCuoi;
                    parameters[6].Value = thoiDiemDi;
                    if (thoiDiemVe != DateTime.MinValue)
                        parameters[7].Value = thoiDiemVe;                    
                    parameters[8].Value = chieuDi;
                    parameters[9].Value = tongTien;
                    parameters[10].Value = ghiChu;
                    parameters[11].Value = userName;
                    parameters[12].Direction = ParameterDirection.Output;
                    parameters[13].Value = TinhThanhDiID;
                    parameters[14].Value = QuanHuyenDiID;
                    parameters[15].Value = QuanHuyenDenID;
                    parameters[16].Value = PhuongXaDiID;
                    parameters[17].Value = PhuongXaDenID;
                    parameters[18].Value = TenLaiXe;
                    parameters[19].Value = soDienThoai;
                    parameters[20].Value = isChiaSe;
                    RunProcedure(SP_INSERT_CHECKCO, parameters);

                    return Convert.ToInt16(parameters[12].Value);
                }
                catch(Exception ex)
                {
                    return 0;
                }
            }
           
        }

        public DataSet GetDSCuocDuongDaiSanBay_TG()
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] {  };

                ds = this.RunProcedure("spTaxiOperationGPS_MaiLinh_GetCuocDuongDai_SanBay_TG", parameters, "SanBayDuongDai");
                return ds;

            }
        }

        public DataSet GetDSCuocDuongDaiSanBayMoi(DateTime thoiDiemLayDuLieuTruoc)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UpdatedDate", SqlDbType.DateTime) };
                parameters[0].Value = thoiDiemLayDuLieuTruoc;
                ds = this.RunProcedure("V2_T_SANBAY_DUONGDAI_GETALLNEW", parameters, "SanBayDuongDai");
                return ds;

            }
        }

        public DataSet GetDSCuocDuongDaiSanBayMoiThayDoi(DateTime thoiDiemLayDuLieuTruoc)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UpdatedDate", SqlDbType.DateTime) };
                parameters[0].Value = thoiDiemLayDuLieuTruoc;
                ds = this.RunProcedure("V2_T_SANBAY_DUONGDAI_GETALLNEW_UPDATE", parameters, "SanBayDuongDai");
                return ds;

            }
        }

        public DataTable GetDSIDCuocDuongDaiSanBayDelete(string ListIDCuocGoiHienTai)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ListIDCuocGoiHienTai", SqlDbType.VarChar,4000) };
                parameters[0].Value = ListIDCuocGoiHienTai;
                ds = this.RunProcedure("V2_T_SANBAY_DUONGDAI_GETALL_ID_DELETE", parameters, "SanBayDuongDai");
                return ds.Tables[0];

            }
        }

        /// <summary>
        /// lấy ra danh sách cuốc khách đường dài sắp xếp theo thời gian và lọc cuốc chưa trả khách lên trước
        /// </summary>
        /// <param name="soHieuXe"></param>
        /// <returns></returns>
        /// <modified>
        /// name        date        comment
        /// hangtm      6/7/2011    created
        ///</modified>
        public DataSet GetDSCuocDuongDaiSanBay(string soHieuXe, int thoiGian)
        {
            List<CheckCoDuongDai> lstCheckCoDuongDai = new List<CheckCoDuongDai>();
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@SoHieuXe",SqlDbType.VarChar ,16),
                    new SqlParameter ("@ThoiGian",SqlDbType.Int )
                };
                if (soHieuXe != string.Empty) { parameters[0].Value = soHieuXe; }
                if (thoiGian > 0) { parameters[1].Value = thoiGian; } 
               
                ds = this.RunProcedure(SP_GETCUOC_DUONGDAI_SANBAY, parameters, "SanBayDuongDai");
                return ds;
                
            }
        }

        /// <summary>
        /// lấy ra danh sách cuốc khách đường dài sắp xếp theo thời gian và lọc cuốc chưa trả khách lên trước
        /// </summary>
        /// <param name="soHieuXe"></param>
        /// <returns></returns>
        /// <modified>
        /// name        date        comment
        /// hangtm      6/7/2011    created
        ///</modified>
        public DataSet GetDSCuocDuongDaiSanBay_Gara(string soHieuXe, int thoiGian, int gara)
        {
            List<CheckCoDuongDai> lstCheckCoDuongDai = new List<CheckCoDuongDai>();
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@SoHieuXe",SqlDbType.VarChar ,16),
                    new SqlParameter ("@ThoiGian",SqlDbType.Int ),
                    new SqlParameter ("@Gara",SqlDbType.Int )
                };
                if (soHieuXe != string.Empty) { parameters[0].Value = soHieuXe; }
                if (thoiGian > 0) { parameters[1].Value = thoiGian; }
                if (gara > 0) { parameters[2].Value = gara; }

                ds = this.RunProcedure(SP_GETCUOC_DUONGDAI_SANBAY_GARA, parameters, "SanBayDuongDai");
                return ds;

            }
        }

        public int UpdateCheckCo(int id, string soHieuXe,string diaDiemDi, string diaDiemDen,int tinhThanhID,int coDau, int coCuoi, DateTime thoiDiemDi,
                                           DateTime thoiDiemVe,bool chieuDi,float tongTien, string ghiChu, string nguoiSua
                                , int TinhThanhDiID, int QuanHuyenDiID, int QuanHuyenDenID, int PhuongXaDiID, int PhuongXaDenID, string TenLaiXe, string soDienThoai, bool isChiaSe, bool TrangThaiDuyet)
        {
            CheckCoDuongDai objCheckCo = new CheckCoDuongDai();
            int rowAffects = 0;
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID", SqlDbType.Int ),
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar ,16),
                    new SqlParameter("@DiaDiemDi",SqlDbType.NVarChar,50),
                    new SqlParameter("@DiaDiemDen",SqlDbType.NVarChar,50),
                    new SqlParameter("@TinhThanhDenID",SqlDbType.Int ),
                    new SqlParameter("@CoDau", SqlDbType.Int),
                    new SqlParameter("@CoCuoi", SqlDbType.Int ),
                    new SqlParameter("@ThoiDiemDi", SqlDbType.DateTime ),
                    new SqlParameter("@ThoiDiemVe",SqlDbType.DateTime),
                    new SqlParameter("@ChieuDi",SqlDbType.Bit ),
                    new SqlParameter("@TongTien",SqlDbType.Float),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,150),
                    new SqlParameter("@NguoiSua",SqlDbType.NVarChar ,50),
                    new SqlParameter("@TinhThanhDiID",SqlDbType.Int ),
                    new SqlParameter("@QuanHuyenDiID",SqlDbType.Int ),
                    new SqlParameter("@QuanHuyenDenID",SqlDbType.Int ),
                    new SqlParameter("@PhuongXaDiID",SqlDbType.Int ),
                    new SqlParameter("@PhuongXaDenID",SqlDbType.Int ),
                    new SqlParameter("@TenLaiXe",SqlDbType.NVarChar ,100),
                    new SqlParameter("@SoDienThoai",SqlDbType.VarChar ,50),
                    new SqlParameter("@isChiaSeChuyenDi",SqlDbType.Bit),
                    new SqlParameter("@TrangThaiDuyet",SqlDbType.Bit)
                };
                    parameters[0].Value = id;
                    parameters[1].Value = soHieuXe;
                    parameters[2].Value = diaDiemDi ;
                    parameters[3].Value = diaDiemDen ;
                    parameters[4].Value = tinhThanhID ;
                    parameters[5].Value = coDau ;
                    parameters[6].Value = coCuoi ;
                    parameters[7].Value = thoiDiemDi; 
                    if (thoiDiemVe != DateTime.MinValue)
                        parameters[8].Value = thoiDiemVe;
                    parameters[9].Value = chieuDi;
                    parameters[10].Value = tongTien;
                    parameters[11].Value = ghiChu;
                    parameters[12].Value = nguoiSua;
                    parameters[13].Value = TinhThanhDiID;
                    parameters[14].Value = QuanHuyenDiID;
                    parameters[15].Value = QuanHuyenDenID;
                    parameters[16].Value = PhuongXaDiID;
                    parameters[17].Value = PhuongXaDenID;
                    parameters[18].Value = TenLaiXe;
                    parameters[19].Value = soDienThoai;
                    parameters[20].Value = isChiaSe;
                    parameters[21].Value = TrangThaiDuyet;
                    rowAffects = this.RunProcedure(SP_UPDATE_CHECKCO, parameters, rowsAffected);
                    return rowAffects;
                }
                catch(Exception ex)
                {
                    return 0;
                }
            }
   
        }
        public int DeleteChecCo(int id, string deleteByUser)
        { 
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                int rowAffects = 0;
                try {
                    SqlParameter[] parameters = new SqlParameter[] { 
                        new SqlParameter("@ID", SqlDbType.Int),
                        new SqlParameter("@DeleteByUser", SqlDbType.NVarChar,50)
                    };
                    parameters[0].Value = id;
                    parameters[1].Value = deleteByUser;
                    rowAffects = this.RunProcedure(SP_DELETE_CHECKCO, parameters, rowsAffected);
                    return rowAffects;
                }
                catch(Exception ex)
                {
                    return 0;
                }
            }
        }

        public int DuyetChecCo(int id, string nguoiDuyet, bool trangThaiDuyet)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                int rowAffects = 0;
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] { 
                        new SqlParameter("@ID", SqlDbType.Int),
                        new SqlParameter("@NguoiDuyet", SqlDbType.NVarChar,50),
                        new SqlParameter("@TrangThaiDuyet", SqlDbType.Bit)
                    };
                    parameters[0].Value = id;
                    parameters[1].Value = nguoiDuyet;
                    parameters[2].Value = trangThaiDuyet;
                    rowAffects = this.RunProcedure("spTaxiOperationGPS_MaiLinh_DuyetCheckCo", parameters, rowsAffected);
                    return rowAffects;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
    }
}
