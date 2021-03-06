using System;
using System.Data;
using System.Data.SqlClient;
using APIServices.Entities;
using System.Collections.Generic;


namespace APIServices.DAL
{
    public class APIServicesDAL : DBObject
    {
        private string SP_T_VITRI_ONLINE_BY_TOADO = "OP_SP_T_VITRI_ONLINE_BY_TOADO";
        private string SP_T_VITRI_ONLINE_BY_TOADO_CALGEO = "OP_SP_T_VITRI_ONLINE_BY_TOADO_CALGEO";
        private string SP_T_VITRI_ONLINE_TOADO_BY_SOHIEUXE = "OP_SP_T_VITRI_ONLINE_TOADO_BY_SOHIEUXE";
        private const string SP_T_VITRI_ONLINE_GETDSXEHOATDONG = "OP_SP_T_VITRI_ONLINE_GETDSXEHOATDONG";

        // MASK BIT cho trang thai
        private const int MASK_BIT_COKHACH = 3; // bit trang thai co khach  TrangThai & MASK_BIT_COKHACH = 0 --> co khach


        #region=========================SERVICE - DS XE DE CU=================
        /// <summary>
        /// hàm thực hiện lấy ra ds xe đề cử.
        /// </summary>
        /// 
        /// <param name="diaChi">địa chỉ phía ĐiênThoại nhập - địa chỉ khách gọi</param>
        /// <param name="maXN"> thông mã xí nghiệp trên hệ thống GPS </param>
        /// <param name="loaiXe">loại xe, chuyển đổi về loại xe tương ứng của GPS, (KIA, VIO, INO, LIMO). KHong chọn là tất cả </param>
        /// <param name="kenhVung">số kênh phía điện thoại đã chọn, Không chọn là tất cả</param>
        /// <param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="trangThaiCoKhach">trạng thái. 1: có khách, 2: không khách, 3: là cả hai. MẶC ĐỊNH là không khách</param>
        /// <param name="soXeTraVe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns> table danh sach xe de cu  </returns>
        public DataTable LayDanhSachXeDeCu(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, int soLuongXe)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@KD", SqlDbType.Float),
                            new SqlParameter("@VD", SqlDbType.Float),
                            new SqlParameter("@MaXN", SqlDbType.VarChar,50),
                            new SqlParameter("@LoaiXe", SqlDbType.VarChar,50),
                            new SqlParameter("@BKGioiHan", SqlDbType.Int),
                            new SqlParameter("@SoXeTraVe", SqlDbType.Int)
                        };
                parameters[0].Value = KD;
                parameters[1].Value = VD;
                parameters[2].Value = maXN;
                parameters[3].Value = loaiXe;
                parameters[4].Value = banKinhGioiHan;
                parameters[5].Value = soLuongXe;

                DataSet ds = RunProcedure(SP_T_VITRI_ONLINE_BY_TOADO, parameters, "tblDSXeDeCu");
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// hàm thực hiện lấy ra ds xe đề cử.
        /// </summary>
        /// 
        /// <param name="diaChi">địa chỉ phía ĐiênThoại nhập - địa chỉ khách gọi</param>
        /// <param name="maXN"> thông mã xí nghiệp trên hệ thống GPS </param>
        /// <param name="loaiXe">loại xe, chuyển đổi về loại xe tương ứng của GPS, (KIA, VIO, INO, LIMO). KHong chọn là tất cả </param>
        /// <param name="kenhVung">số kênh phía điện thoại đã chọn, Không chọn là tất cả</param>
        /// <param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="trangThaiCoKhach">trạng thái. 1: có khách, 2: không khách, 3: là cả hai. MẶC ĐỊNH là không khách</param>
        /// <param name="soXeTraVe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns> table danh sach xe de cu  </returns>
        public DataTable LayDanhSachXeDeCu_CalGEO(double KDMin, double VDMin, double KDMax, double VDMax, string maXN, string loaiXe, int soLuongXe)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@KDMin", SqlDbType.Float),
                            new SqlParameter("@VDMin", SqlDbType.Float),
                            new SqlParameter("@KDMax", SqlDbType.Float),
                            new SqlParameter("@VDMax", SqlDbType.Float),
                            new SqlParameter("@MaXN", SqlDbType.VarChar,50),
                            new SqlParameter("@LoaiXe", SqlDbType.VarChar,50),
                            new SqlParameter("@SoXeTraVe", SqlDbType.Int)
                        };
                parameters[0].Value = KDMin;
                parameters[1].Value = VDMin;
                parameters[2].Value = KDMax;
                parameters[3].Value = VDMax;
                parameters[4].Value = maXN;
                parameters[5].Value = loaiXe;
                parameters[6].Value = soLuongXe;

                DataSet ds = RunProcedure(SP_T_VITRI_ONLINE_BY_TOADO_CALGEO, parameters, "tblDSXeDeCu");
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy tọa độ của xe nhận
        /// </summary>
        /// <param name="KD"></param>
        /// <param name="VD"></param>
        /// <param name="maXN"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns>SHXe-KhoangCach-KD-VD-TrangThai</returns>
        public string LayToaDoXeNhan(double KD, double VD, string maXN, string SoHieuXe)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@KD", SqlDbType.Float),
                            new SqlParameter("@VD", SqlDbType.Float),
                            new SqlParameter("@MaXN", SqlDbType.VarChar,50),
                            new SqlParameter("@SoHieuXe", SqlDbType.VarChar,50),
                            new SqlParameter("@Return", SqlDbType.VarChar,50)
                        };
                parameters[0].Value = KD;
                parameters[1].Value = VD;
                parameters[2].Value = maXN;
                parameters[3].Value = SoHieuXe;
                parameters[4].Direction = ParameterDirection.Output;

                RunProcedure(SP_T_VITRI_ONLINE_TOADO_BY_SOHIEUXE, parameters, "tblToaDo");
                return parameters[4].Value.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion====================================================================

        #region Sync Xe online
        public DataTable GetViTriOnline_TGCapNhat(DateTime TGLayGuLieuTruoc)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                        new SqlParameter("@ThoiDiemChenDuLieu", SqlDbType.DateTime)
                };
                parameters[0].Value = TGLayGuLieuTruoc;
                return RunProcedure("OP_T_VITRI_ONLINE_GETNEW", parameters, "T_VITRI_ONLINE").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetViTriOnline_MaXN_TGCapNhat(DateTime TGLayGuLieuTruoc, string MaXN)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                        new SqlParameter("@ThoiDiemChenDuLieu", SqlDbType.DateTime),
                        new SqlParameter("@MaCungXN", SqlDbType.VarChar, 100)
                };
                parameters[0].Value = TGLayGuLieuTruoc;
                parameters[1].Value = MaXN;
                return RunProcedure("OP_T_VITRI_ONLINE_GETNEW_MAXN", parameters, "T_VITRI_ONLINE").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetViTriOnline_TGCapNhat_Paging(DateTime TGLayGuLieuTruoc, int pageIndex)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ThoiDiemChenDuLieu", SqlDbType.DateTime),
                        new SqlParameter("@PageIndex", SqlDbType.Int),
                };
                parameters[0].Value = TGLayGuLieuTruoc;
                parameters[1].Value = pageIndex;
                return RunProcedure("OP_T_VITRI_ONLINE_GETNEW_PAGING", parameters, "T_VITRI_ONLINE").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetViTriOnline_TGCapNhat_MaXN_Paging(DateTime TGLayGuLieuTruoc, int pageIndex, string MaXN)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ThoiDiemChenDuLieu", SqlDbType.DateTime),
                        new SqlParameter("@PageIndex", SqlDbType.Int),
                        new SqlParameter("@MaCungXN", SqlDbType.VarChar, 100)
                };
                parameters[0].Value = TGLayGuLieuTruoc;
                parameters[1].Value = pageIndex;
                parameters[2].Value = MaXN;
                return RunProcedure("OP_T_VITRI_ONLINE_GETNEW_PAGING_MAXN", parameters, "T_VITRI_ONLINE").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetAllVehicles()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { };
                return RunProcedure("OP_T_XE_VITRI_ONLINE_GETALL", parameters, "T_VITRI_ONLINE").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetAllVehicles_MaXN(string MaXN)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@MaCungXN", SqlDbType.VarChar, 50)
                };
                parameters[0].Value = MaXN;
                return RunProcedure("OP_T_XE_VITRI_ONLINE_GETALL_MAXN", parameters, "T_VITRI_ONLINE").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
        public DataTable GetVehicles_BienSoXe(string MaXN, string BienSoXe)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@MaCungXN", SqlDbType.VarChar, 50),
                    new SqlParameter("@BienSoXe", SqlDbType.VarChar, 50)
                };
                parameters[0].Value = MaXN;
                parameters[1].Value = BienSoXe;
                return RunProcedure("SP_T_XE_BIENSOXE", parameters, "T_Xe").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        /// <summary>
        /// Côngnt
        /// hàm trả về ds xe có tín hiệu gần đây
        /// </summary>
        /// <param name="soGiayCoTinHieuGanDay"></param>
        /// <param name="maCungXNs"></param>
        /// <returns></returns>
        public List<XeOnlineEntity> GetDSXeOnlineHoatDong(int soGiayCoTinHieuGanDay, string maCungXNs)
        {

            try
            {
                List<XeOnlineEntity> listXe = new List<XeOnlineEntity>();
                SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@SoGiayCoTinHieu", SqlDbType.Float),
                            new SqlParameter("@DSMaCungXN", SqlDbType.VarChar,200) 
                        };
                parameters[0].Value = soGiayCoTinHieuGanDay;
                parameters[1].Value = maCungXNs;

                DataSet ds = RunProcedure(SP_T_VITRI_ONLINE_GETDSXEHOATDONG, parameters, "tblDSXeDeCu");
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listXe.Add(GetXeOnlineEntity(dr));
                    }
                }

                return listXe;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// lay ra doi tuong XeOnlineEntity
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private XeOnlineEntity GetXeOnlineEntity(DataRow dr)
        {
            if (dr != null)
            {
                //BienSoXe, OL.KinhDo, OL.ViDo, OL.TrangThai  
                XeOnlineEntity xe = new XeOnlineEntity();
                xe.BienSoXe = dr["BienSoXe"] == DBNull.Value ? string.Empty : dr["BienSoXe"].ToString();
                xe.SoHieuXe = dr["SoHieuXe"] == DBNull.Value ? string.Empty : dr["SoHieuXe"].ToString();
                xe.KinhDo = dr["KinhDo"] == DBNull.Value ? 0 : float.Parse(dr["KinhDo"].ToString());
                xe.ViDo = dr["ViDo"] == DBNull.Value ? 0 : float.Parse(dr["ViDo"].ToString());
                xe.TrangThai = dr["TrangThai"] == DBNull.Value ? 0 : int.Parse(dr["TrangThai"].ToString());

                return xe;
            }
            return null;
        }

        #region License
        /// <summary>
        /// Get license
        /// </summary>
        /// <param name="RequestKey"></param>
        /// <returns></returns>
        public LicenseEntity GetLicense(string RequestKey)
        {
            try
            {
                LicenseEntity objLicense = new LicenseEntity();
                SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@RequestKey", SqlDbType.VarChar,200) 
                        };
                parameters[0].Value = RequestKey;

                DataSet ds = RunProcedure("OP_REQUEST_LICENSEKEY", parameters, "tblDSXeDeCu");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    objLicense.LicenseKey = dr["LicenseKey"].ToString();
                    objLicense.FromDate = Convert.ToDateTime(dr["FromDate"].ToString());
                    objLicense.ToDate = Convert.ToDateTime(dr["ToDate"].ToString());                    
                }

                return objLicense;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
