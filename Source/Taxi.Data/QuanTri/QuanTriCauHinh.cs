using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data.SqlClient;
using System.Data;

namespace Taxi.Data.QuanTri
{
    public class QuanTriCauHinh : DBObject
    {
        /// <summary>
        /// Tra ve duong line cap cho may voi IPAddress
        /// </summary>
        public string GetLinesOfPCDienThoai(string IPAddress)
        {
            try
            {
                //@IP_Address varchar(15),
                //@@Line varchar(50)  output 	
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar ,15)   , 
                    new SqlParameter("@Line",SqlDbType.VarChar ,50)  
                };
                parameters[0].Value = IPAddress;
                parameters[1].Direction = System.Data.ParameterDirection.Output;

                RunProcedure("sp_T_QUANTRICAUHINH_HETHONGMAYTINH_SelectLinesPCDienThoai", parameters);

                return (string)parameters[1].Value;
            }
            catch
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// get so vung cua PC tong dai
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public string GetVungsOfPCTongDai(string IPAddress)
        {
            try
            {
                //@IP_Address varchar(15),
                //@@Line varchar(50)  output 	
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar ,15)   , 
                    new SqlParameter("@Vung",SqlDbType.VarChar ,50)  
                };
                parameters[0].Value = IPAddress;
                parameters[1].Direction = System.Data.ParameterDirection.Output;

                RunProcedure("sp_T_QUANTRICAUHINH_HETHONGMAYTINH_SelectVungsPCTongDai", parameters);

                return (string)parameters[1].Value;
            }
            catch 
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// hamf tra ve vung cua mot may tinh 
        /// voi thong tin truyen vao
        ///  IP : dia chi IP cua may
        ///  KieuMayTinh : 'TD', 'CO', 'MK', DT,''
        /// IF NULL thì trả về tất cả máy 
        /// Tra ve : cac vung cua may tinh co the nhan thong tin
        /// </summary>
        public string GetLineVungOfPC(string IPAddress, string KieuMayTinh)
        { 
            string strSQL = "";
            if (KieuMayTinh.Length > 0)
            {
                strSQL += "SELECT TOP 1 [Line_Vung] FROM  [dbo].[T_QUANTRICAUHINH_HETHONGMAYTINH] ";
                strSQL += "WHERE ( IP_Address='" + IPAddress + "') AND (IsMayTinh='" + KieuMayTinh + "') AND (IsHoatDong='1') ";
            }
            else
            {
                strSQL += "SELECT TOP 1 [Line_Vung] FROM  [dbo].[T_QUANTRICAUHINH_HETHONGMAYTINH] ";
                strSQL += "WHERE ( IP_Address='" + IPAddress + "')";
            }
            DataTable dt = RunSQL(strSQL, "tblVungOfPC");
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Line_Vung"].ToString();
            }
            return "";
        }

        /// <summary>
        /// lay nhung IsMayTinh = 'DT' la dienthoai
        ///           IsMayTinh = 'TD' la tongdai 
        /// </summary>
        /// <param name="IsMayTinh"></param>
        /// <returns></returns>
        public DataTable GetDSMay(string IsMayTinh)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IsMayTinh",SqlDbType.Char ,2)                    
                };
            parameters[0].Value = IsMayTinh;

            return this.RunProcedure("SP_T_QUANTRICAUHINH_HETHONGMAYTINH_GetDSMayTinh", parameters, "tblListIP").Tables[0];
        }

        public bool InsertIP(string IP, string Line_Vung, string IsMayTinh, bool IsActive,int No)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar,15),
                    new SqlParameter("@Line_Vung",SqlDbType.VarChar ,50),
                    new SqlParameter("@IsMayTinh",SqlDbType.VarChar ,2) ,
                    new SqlParameter("@IsHoatDong",SqlDbType.VarChar,1),
                    new SqlParameter("@No",SqlDbType.TinyInt)
                };
                parameters[0].Value = IP;
                parameters[1].Value = Line_Vung;
                parameters[2].Value = IsMayTinh;
                parameters[3].Value = IsActive == true ? "1" : "0";
                parameters[4].Value = No;
                rowAffected = this.RunProcedure("SP_T_QUANTRICAUHINH_HETHONGMAYTINH_Insert", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool InsertIP_V2(string IP, string Line_Vung, string IsMayTinh, bool IsActive, int No, string Line_Vung_Gop, bool G5Type)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar,15),
                    new SqlParameter("@Line_Vung",SqlDbType.VarChar ,50),
                    new SqlParameter("@IsMayTinh",SqlDbType.VarChar ,2) ,
                    new SqlParameter("@IsHoatDong",SqlDbType.VarChar,1),
                    new SqlParameter("@No",SqlDbType.TinyInt),
                    new SqlParameter("@Line_Vung_Gop",SqlDbType.NVarChar,50),
                    new SqlParameter("@G5Type",SqlDbType.VarChar,1)
                };
                parameters[0].Value = IP;
                parameters[1].Value = Line_Vung;
                parameters[2].Value = IsMayTinh;
                parameters[3].Value = IsActive == true ? "1" : "0";
                parameters[4].Value = No;
                parameters[5].Value = Line_Vung_Gop;
                parameters[6].Value = G5Type == true ? "1" : "0"; 
                rowAffected = this.RunProcedure("SP_T_QUANTRICAUHINH_HETHONGMAYTINH_Insert_V3", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogErrorUtils.WriteLogError("InsertIP_V2: ",e);
                return false;
            }
        }
        public bool InsertIP_V3(string IP, string Line_Vung, string IsMayTinh, bool IsActive, int No, string Line_Vung_Gop, bool G5Type, string Extension)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar,15),
                    new SqlParameter("@Line_Vung",SqlDbType.VarChar ,50),
                    new SqlParameter("@IsMayTinh",SqlDbType.VarChar ,2) ,
                    new SqlParameter("@IsHoatDong",SqlDbType.VarChar,1),
                    new SqlParameter("@No",SqlDbType.TinyInt),
                    new SqlParameter("@Line_Vung_Gop",SqlDbType.NVarChar,50),
                    new SqlParameter("@G5Type",SqlDbType.VarChar,1),
                    new SqlParameter("@Extension",SqlDbType.VarChar,10)                    
                };
                parameters[0].Value = IP;
                parameters[1].Value = Line_Vung;
                parameters[2].Value = IsMayTinh;
                parameters[3].Value = IsActive == true ? "1" : "0";
                parameters[4].Value = No;
                parameters[5].Value = Line_Vung_Gop;
                parameters[6].Value = G5Type == true ? "1" : "0";
                parameters[7].Value = Extension;
                rowAffected = this.RunProcedure("SP_T_QUANTRICAUHINH_HETHONGMAYTINH_Insert_V4", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogErrorUtils.WriteLogError("InsertIP_V3: ", e);
                return false;
            }
        }

        public bool Delete(string IP)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar,15)  
                };
                parameters[0].Value = IP;
                rowAffected = this.RunProcedure("SP_T_QUANTRICAUHINH_HETHONGMAYTINH_Delete", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Lay thông tin cấu hình của hệ thống trong bảng T_TAXIOPERATION_PARAMETER
        /// </summary>
        public DataTable GetThongTinCauHinh()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            return this.RunProcedure("SP_T_TAXIOPERATION_PARAMETER_GetThongTinCauHinh", parameters, "tblListIP").Tables[0];
        }

        public bool UpdateInsetThongTinCauHinh(string TenCongTy, string LogoPath, string SoDauCuaTongDai,
                    int SoGiayGioiHanThoiGianChuyenTongDai, int SoGiayGioiHanThoiGianDieuXe, int SoGiayGioiHanThoiGianDonKhach,
                    int SoPhutGioiHanMatLienLac, int SoPhutGioiHanMatLienLacBaoNghi, int SoPhutGioiHanMatLienLacBaoDiSanBay,
                    int SoPhutGioiHanMatLienLacBaoDiDuongDai, string ThuMucDuLieuTanasonic, string ThuMucFileAmThanh, string TatCaLineCuaHeThong,
                    string CacLineCuaTaxiOperation, string SoDienThoaiCongTy, bool HasTongDai, int SoDongCuocGoiDaGiaiQuyet, bool KiemTraXeDaRaHoatDong,
                    string CacVungTongDai, bool TinhTienCuocHaiChieuKhongNgatCuoc
                    , bool KichHoachTaxiGroupDon, byte SoPhutGiuKhachChuaCoXeNhan, byte SoPhutGiuKhachCoXeNhan, byte SoPhutGiuKhachLai,
                    string MaCungXn, string BanDo, int Zoom, float KinhDo, float ViDo, string TenTinh, bool TrangThai, int BKGioiHan, int BKXeNhan,
            bool status, TimeSpan GioKT, TimeSpan GioBD, bool ft_ChieuVe_CoDuyet, bool ft_ChieuVe_CoChotCo, bool fT_Active, bool fT_ChieuVe_Active, int fT_ServiceMap, float fT_SoKM)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenCongTy",SqlDbType.NVarChar,50),
                    new SqlParameter("@LogoCongTy",SqlDbType.VarChar ,255),
                    new SqlParameter("@SoGiayGioiHanThoiGianChuyenTongDai",SqlDbType.Int) ,
                    new SqlParameter("@SoGiayGioiHanThoiGianDieuXe",SqlDbType.Int) ,                     
                    new SqlParameter("@SoGiayGioiHanThoiGianDonKhach",SqlDbType.Int) , 

                    new SqlParameter("@SoPhutGioiHanMatLienLac",SqlDbType.Int) , 
                    new SqlParameter("@SoPhutGioiHanMatLienLacBaoNghi",SqlDbType.Int) , 
                    new SqlParameter("@SoPhutGioiHanMatLienLacBaoDiSanBay",SqlDbType.Int) , 
                    new SqlParameter("@SoPhutGioiHanMatLienLacBaoDiDuongDai",SqlDbType.Int) , 

                    new SqlParameter("@SoDauCuaTongDai",SqlDbType.VarChar ,2) , 
                    new SqlParameter("@ThuMucDuLieuTanasonic",SqlDbType.VarChar ,250) , 
                    new SqlParameter("@ThuMucFileAmThanh",SqlDbType.VarChar ,250),
                    new SqlParameter("@TatCaLineCuaHeThong",SqlDbType.VarChar ,250) ,  
                    new SqlParameter("@CacLineCuaTaxiOperation",SqlDbType.VarChar ,250) ,
                    new SqlParameter("@SoDienThoaiCongTy",SqlDbType.VarChar ,11  ),
                    new SqlParameter("@HasTongDai",SqlDbType.Bit   ),
                    new SqlParameter("@SoDongCuocGoiDaGiaiQuyet",SqlDbType.Int   ),
                    new SqlParameter("@KiemTraXeDaRaHoatDong",SqlDbType.Bit   ),
                    new SqlParameter("@CacVungTongDai",SqlDbType.VarChar,250   )  ,
                    new SqlParameter("@TinhTienCuocHaiChieuKhongNgatCuoc",SqlDbType.Bit),
                   
                    new SqlParameter("@KichHoachTaxiGroupDon",SqlDbType.Bit),
                    new SqlParameter("@SoPhutGiuKhachChuaCoXeNhan",SqlDbType.TinyInt),
                    new SqlParameter("@SoPhutGiuKhachCoXeNhan",SqlDbType.TinyInt),
                     new SqlParameter("@SoPhutGiuKhachLai",SqlDbType.TinyInt),

                    new SqlParameter ("@GPS_MaXN",SqlDbType.VarChar,50),
                    new SqlParameter ("@GPS_MAP_LoaiBanDo",SqlDbType.NVarChar,50),
                    new SqlParameter ("@GPS_MAP_Zoom",SqlDbType.Int),
                    new SqlParameter ("@GPS_MAP_KinhDo",SqlDbType.Float),
                    new SqlParameter ("@GPS_MAP_ViDo",SqlDbType.Float),
                    new SqlParameter ("@GPS_TenTinh",SqlDbType.NVarChar,50),
                    new SqlParameter ("@GPS_Trangthai",SqlDbType.Bit),
                    new SqlParameter ("@GPS_BKGioiHan",SqlDbType.Int),
                    new SqlParameter ("@GPS_BKXeNhan",SqlDbType.Int),
                    new SqlParameter("@GopKenh_TrangThai",SqlDbType.Bit),
                    new SqlParameter("@GopKenh_GioKT",SqlDbType.Time,7),
                    new SqlParameter("@GopKenh_GioBD",SqlDbType.Time,7),
                    new SqlParameter("@FT_ChieuVe_CoDuyet",SqlDbType.Bit),
                    new SqlParameter("@FT_ChieuVe_CoChotCo",SqlDbType.Bit),
                    new SqlParameter("@FT_Active",SqlDbType.Bit),
                    new SqlParameter("@FT_ChieuVe_Active",SqlDbType.Bit),
                     new SqlParameter("@FT_ServiceMap",SqlDbType.Int),
                    new SqlParameter("@FT_SoKM",SqlDbType.Int)
                };
                parameters[0].Value = TenCongTy;
                parameters[1].Value = LogoPath;
                parameters[2].Value = SoGiayGioiHanThoiGianChuyenTongDai;
                parameters[3].Value = SoGiayGioiHanThoiGianDieuXe;
                parameters[4].Value = SoGiayGioiHanThoiGianDonKhach;

                parameters[5].Value = SoPhutGioiHanMatLienLac;
                parameters[6].Value = SoPhutGioiHanMatLienLacBaoNghi;
                parameters[7].Value = SoPhutGioiHanMatLienLacBaoDiSanBay;
                parameters[8].Value = SoPhutGioiHanMatLienLacBaoDiDuongDai;

                parameters[9].Value = SoDauCuaTongDai;
                parameters[10].Value = ThuMucDuLieuTanasonic;
                parameters[11].Value = ThuMucFileAmThanh;
                parameters[12].Value = TatCaLineCuaHeThong;
                parameters[13].Value = CacLineCuaTaxiOperation;
                parameters[14].Value = SoDienThoaiCongTy;
                parameters[15].Value = HasTongDai == true ? 1 : 0;
                parameters[16].Value = SoDongCuocGoiDaGiaiQuyet <= 0 ? 50 : SoDongCuocGoiDaGiaiQuyet;
                parameters[17].Value = KiemTraXeDaRaHoatDong == true ? 1 : 0;
                parameters[18].Value = CacVungTongDai;
                parameters[19].Value = TinhTienCuocHaiChieuKhongNgatCuoc;

                parameters[20].Value = KichHoachTaxiGroupDon;
                parameters[21].Value = SoPhutGiuKhachChuaCoXeNhan;
                parameters[22].Value = SoPhutGiuKhachCoXeNhan;
                parameters[23].Value = SoPhutGiuKhachLai;

                parameters[24].Value = MaCungXn;
                parameters[25].Value = BanDo;
                parameters[26].Value = Zoom;
                parameters[27].Value = KinhDo;
                parameters[28].Value = ViDo;
                parameters[29].Value = TenTinh;
                parameters[30].Value = TrangThai == true ? 1 : 0;
                parameters[31].Value = BKGioiHan;
                parameters[32].Value = BKXeNhan;
                parameters[33].Value = status;
                parameters[34].Value = GioKT;
                parameters[35].Value = GioBD;
                parameters[36].Value = ft_ChieuVe_CoDuyet;
                parameters[37].Value = ft_ChieuVe_CoChotCo;
                parameters[38].Value = fT_Active;
                parameters[39].Value = fT_ChieuVe_Active;
                parameters[40].Value = fT_ServiceMap;
                parameters[41].Value = fT_SoKM;
                rowAffected = this.RunProcedure("SP_T_TAXIOPERATION_PARAMETER_InsertV2", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// lấy thông tin ca 
        /// </summary>
        public DataTable GetThongTinCa(int ID)
        {
            string strSQL = "";
            strSQL += "SELECT [ID] ,[DauCa1] ,[KetThucCa1] ,[KetThucCa2]  FROM [CA.T_NHANVIENDIEUHANH] WHERE ID = " + ID.ToString();
            return RunSQL(strSQL, "tbl");
        }
        /// <summary>
        /// lưu thông tin cấu hình thông tin ca
        /// </summary>
        public bool CapNhatThongTinCa(int ID, DateTime DauCa1, DateTime KetThucCa1, DateTime KetThucCa2)
        {
            try
            {
                string strSQL = "";
                strSQL += " UPDATE [CA.T_NHANVIENDIEUHANH] ";
                strSQL += " SET DauCa1 ='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DauCa1) + "', ";
                strSQL += " KetThucCa1 ='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", KetThucCa1) + "', ";
                strSQL += " KetThucCa2 ='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", KetThucCa2) + "' ";
                strSQL += " WHERE ID = " + ID.ToString();                
                int iError = this.RunSQL(strSQL);
                if (iError == 0) return true;
                else return false;

            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// hamr tra ve ds cac IP co cung vung moi khach
        /// </summary>
        public List<string> GetDSMayTinhMoiKhachByVung(string Vung)
        {
            List<string> lstPC = new List<string>();
            DataTable dt;
            string strSQL = " SELECT [IP_Address] ,[Line_Vung] ,[IsMayTinh] ,[IsHoatDong] ";
            strSQL += "       FROM  [T_QUANTRICAUHINH_HETHONGMAYTINH]  ";
            strSQL += "       WHERE IsMayTinh ='MK' AND Line_Vung = '" + Vung + "'";

            dt = RunSQL(strSQL, "dtPC");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstPC.Add(dr["IP_Address"].ToString());
                }
            }
            return lstPC;
        }

        #region -----New v3-----
        /// <summary>
        /// Lấy số line và Loại xe của Máy tính
        /// </summary>
        public DataTable GetLines_LoaiXeOfPCDienThoai(string IPAddress)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar ,15)                    
                };
            parameters[0].Value = IPAddress;

            return this.RunProcedure("V3_sp_T_QUANTRICAUHINH_HETHONGMAYTINH_SelectLines_LoaiXePCDienThoai", parameters, "tblListLine_LXe").Tables[0];
        }

        /// <summary>
        /// Lấy số line và Loại xe của Máy tính
        /// </summary>
        public DataTable GetLines_LoaiXeOfPCTongDai(string IPAddress)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar ,15)                    
                };
            parameters[0].Value = IPAddress;

            return this.RunProcedure("sp_T_QUANTRICAUHINH_HETHONGMAYTINH_SelectVungsPCTongDai_V2", parameters, "tblListLine_LXe").Tables[0];
        }

        public bool Update_GopKenh(bool status, TimeSpan GioKT, TimeSpan GioBD)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@GopKenh_TrangThai",SqlDbType.Bit),
                    new SqlParameter("@GopKenh_GioKT",SqlDbType.Time,7),
                    new SqlParameter("@GopKenh_GioBD",SqlDbType.Time,7),
                    new SqlParameter("@Output",SqlDbType.Bit)
                };
                parameters[0].Value = status;
                parameters[1].Value = GioKT;
                parameters[2].Value = GioBD;
                parameters[3].Direction = ParameterDirection.Output;

                this.RunProcedure("V3_T_TAXIOPERATION_PARAMETER_UPDATE_GOPKENH", parameters, rowAffected);
                return Convert.ToBoolean(parameters[3].Value);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update_CauHinhStaxi(bool ckbStaxi, bool ckbStaxiChieuVe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ckbStaxi",SqlDbType.Bit),
                    new SqlParameter("@ckbStaxiChieuVe",SqlDbType.Bit),
                    new SqlParameter("@Output",SqlDbType.Bit)
                };
                parameters[0].Value = ckbStaxi;
                parameters[1].Value = ckbStaxiChieuVe;
                parameters[2].Direction = ParameterDirection.Output;

                this.RunProcedure("sp_T_TAXIOPERATION_PARAMETER_Update_CauHinhStaxi", parameters, rowAffected);
                return Convert.ToBoolean(parameters[2].Value);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public  bool Update_CauHinhStaxiChieuVe(bool CoDuyet, bool CoChotCo, int ServerMapType, float KM)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CoDuyet",SqlDbType.Bit),
                    new SqlParameter("@CoChotCo",SqlDbType.Bit),
                    new SqlParameter("@ServerMapType",SqlDbType.Int),
                    new SqlParameter("@KM",SqlDbType.Float),
                    new SqlParameter("@Output",SqlDbType.Bit)
                };
                parameters[0].Value = CoDuyet;
                parameters[1].Value = CoChotCo;
                parameters[2].Value = ServerMapType;
                parameters[3].Value = KM;
                parameters[4].Direction = ParameterDirection.Output;

                this.RunProcedure("sp_T_TAXIOPERATION_PARAMETER_Update_CauHinhStaxiChieuVe", parameters, rowAffected);
                return Convert.ToBoolean(parameters[4].Value);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable G5_GetLines_LoaiXeOfPCDienThoai(string ipAddress)
        {
            return this.ExeStoreData("G5_HeThongMayTinh_DienThoai_GetByIP", ipAddress);
        }
        public void G5_Update_PinMap(string ipAddress,string value)
        {
                this.ExeStore("G5_HeThongMayTinh_DienThoai_Update_PinMap", ipAddress, value);
        }
        #endregion
        public DataTable GetLINEGOIRA_ByIpAddress(string IPAddress)
        {
            var parameters = new SqlParameter[] {
                    new SqlParameter("@IpAddress",SqlDbType.VarChar ,15)                   
                };
            parameters[0].Value = IPAddress;

            return this.RunProcedure("sp_T_QUANTRICAUHINH_LINEGOIRA_ByIpAddress", parameters, "tblListLine_LXe").Tables[0];
        }
    }
}
