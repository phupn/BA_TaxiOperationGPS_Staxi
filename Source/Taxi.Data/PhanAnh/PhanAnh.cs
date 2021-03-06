using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.PhanAnh
{
    public class PhanAnh : DBObject
    {
        /// <summary>
        /// chen 1 cuoc goi vao bang voi noi dung phan anh ma chua duoc xu li
        /// </summary>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// phupn      7/7/2011   created
        /// </modified>
        
        public bool InsertPhanAnh(string TenKH, string SoDT, string DiaChi, DateTime TGPA, int LoaiPA,
                                DateTime TGPS, string NoiDung, int DacDiem, int DoiTuong, string LTTu
                                , string LTDen, string DHT, DateTime GQ_TGGQ, bool GQ_KHDongY, string GQ_KQGQ, string GQ_YKKH
                                , string GQ_GhiChu, string GQ_SoTai, bool GQ_HL, DateTime GQ_TGT, DateTime NgayTao
                                , string NguoiTao, bool TrangThai, long IdCuocGoi)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@TenKH",SqlDbType.NVarChar,100),
                    new SqlParameter ("@SoDT",SqlDbType.VarChar ,12),
                    new SqlParameter ("@DiaChi",SqlDbType.NVarChar ,500),
                    new SqlParameter ("@TGPA",SqlDbType.DateTime ),
                    new SqlParameter ("@LoaiPA",SqlDbType.SmallInt ),
                    new SqlParameter ("@TGPS",SqlDbType.DateTime),
                    new SqlParameter ("@NoiDung",SqlDbType.NVarChar ,500),
                    new SqlParameter ("@DacDiem",SqlDbType.SmallInt),
                    new SqlParameter ("@DoiTuong",SqlDbType.SmallInt),
                    new SqlParameter ("@LTTu",SqlDbType.NVarChar ,100),
                    new SqlParameter ("@LTDen",SqlDbType.NVarChar ,100),
                    new SqlParameter ("@DHT",SqlDbType.NVarChar ,100 ),
                    new SqlParameter ("@GQ_TGGQ",SqlDbType.DateTime ),
                    new SqlParameter ("@GQ_KHDongY",SqlDbType.Bit),
                    new SqlParameter ("@GQ_KQGQ",SqlDbType.NVarChar ,500),
                    new SqlParameter ("@GQ_YKKH",SqlDbType.NVarChar,500),
                    new SqlParameter ("@GQ_GhiChu",SqlDbType.NVarChar,500),
                    new SqlParameter ("@GQ_SoTai",SqlDbType.VarChar,50 ),
                    new SqlParameter ("@GQ_HL",SqlDbType.Bit),
                    new SqlParameter ("@GQ_TGT",SqlDbType.DateTime ),
                    new SqlParameter ("@NgayTao",SqlDbType.DateTime),
                    new SqlParameter ("@NguoiTao",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@TrangThai",SqlDbType.Bit),
                    new SqlParameter ("@IdCuocGoi",SqlDbType.BigInt )
                };
                parameters[0].Value = TenKH;
                parameters[1].Value = SoDT;
                parameters[2].Value = DiaChi;
                parameters[3].Value = TGPA;
                parameters[4].Value = LoaiPA;
                parameters[5].Value = TGPS;
                parameters[6].Value = NoiDung;
                parameters[7].Value = DacDiem;
                parameters[8].Value = DoiTuong;
                parameters[9].Value = LTTu;
                parameters[10].Value = LTDen;
                parameters[11].Value = DHT;
                if (GQ_TGGQ == DateTime.MinValue)
                {
                    parameters[12].Value = DBNull.Value;
                }
                else
                {
                    parameters[12].Value = GQ_TGGQ;
                }
                parameters[13].Value = GQ_KHDongY;
                parameters[14].Value = GQ_KQGQ;
                parameters[15].Value = GQ_YKKH;
                parameters[16].Value = GQ_GhiChu;
                parameters[17].Value = GQ_SoTai;
                parameters[18].Value = GQ_HL;
                if (GQ_TGT != DateTime.MinValue)
                {
                    parameters[19].Value = GQ_TGT;
                }
                
                parameters[20].Value = NgayTao;
                parameters[21].Value = NguoiTao;
                parameters[22].Value = TrangThai;
                parameters[23].Value = IdCuocGoi;

                rowAffect = this.RunProcedure("SP_T_KHACHHANG_PHANANH_INSERT", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Update phan anh
        /// </summary>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// phupn      7/7/2011   created
        /// </modified>

        public bool UpdatePhanAnh(string TenKH, string SoDT, string DiaChi, DateTime TGPA, int LoaiPA,
                                DateTime TGPS, string NoiDung, int DacDiem, int DoiTuong, string LTTu
                                , string LTDen, string DHT, DateTime GQ_TGGQ, bool GQ_KHDongY, string GQ_KQGQ, string GQ_YKKH
                                , string GQ_GhiChu, string GQ_SoTai, bool GQ_HL, DateTime GQ_TGT, DateTime NgayTao
                                , string NguoiTao, bool TrangThai, long Id, bool IsGQCapCao)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@TenKH",SqlDbType.NVarChar,100),
                    new SqlParameter ("@SoDT",SqlDbType.VarChar ,12),
                    new SqlParameter ("@DiaChi",SqlDbType.NVarChar ,500),
                    new SqlParameter ("@TGPA",SqlDbType.DateTime ),
                    new SqlParameter ("@LoaiPA",SqlDbType.SmallInt ),
                    new SqlParameter ("@TGPS",SqlDbType.DateTime),
                    new SqlParameter ("@NoiDung",SqlDbType.NVarChar ,500),
                    new SqlParameter ("@DacDiem",SqlDbType.SmallInt),
                    new SqlParameter ("@DoiTuong",SqlDbType.SmallInt),
                    new SqlParameter ("@LTTu",SqlDbType.NVarChar ,100),
                    new SqlParameter ("@LTDen",SqlDbType.NVarChar ,100),
                    new SqlParameter ("@DHT",SqlDbType.NVarChar ,100 ),
                    new SqlParameter ("@GQ_TGGQ",SqlDbType.DateTime ),
                    new SqlParameter ("@GQ_KHDongY",SqlDbType.Bit),
                    new SqlParameter ("@GQ_KQGQ",SqlDbType.NVarChar ,500),
                    new SqlParameter ("@GQ_YKKH",SqlDbType.NVarChar,500),
                    new SqlParameter ("@GQ_GhiChu",SqlDbType.NVarChar,500),
                    new SqlParameter ("@GQ_SoTai",SqlDbType.VarChar,50 ),
                    new SqlParameter ("@GQ_HL",SqlDbType.Bit),
                    new SqlParameter ("@GQ_TGT",SqlDbType.DateTime ),
                    new SqlParameter ("@NgaySua",SqlDbType.DateTime),
                    new SqlParameter ("@NguoiSua",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@TrangThai",SqlDbType.Bit),
                    new SqlParameter ("@Id",SqlDbType.BigInt ),
                    new SqlParameter ("@IsGQCapCao",SqlDbType.Bit )
                };
                parameters[0].Value = TenKH;
                parameters[1].Value = SoDT;
                parameters[2].Value = DiaChi;
                parameters[3].Value = TGPA;
                parameters[4].Value = LoaiPA;
                parameters[5].Value = TGPS;
                parameters[6].Value = NoiDung;
                parameters[7].Value = DacDiem;
                parameters[8].Value = DoiTuong;
                parameters[9].Value = LTTu;
                parameters[10].Value = LTDen;
                parameters[11].Value = DHT;
                parameters[12].Value = GQ_TGGQ;
                parameters[13].Value = GQ_KHDongY;
                parameters[14].Value = GQ_KQGQ;
                parameters[15].Value = GQ_YKKH;
                parameters[16].Value = GQ_GhiChu;
                parameters[17].Value = GQ_SoTai;
                parameters[18].Value = GQ_HL;
                parameters[19].Value = GQ_TGT;
                parameters[20].Value = NgayTao;
                parameters[21].Value = NguoiTao;
                parameters[22].Value = TrangThai;
                parameters[23].Value = Id;
                parameters[24].Value = IsGQCapCao;

                rowAffect = this.RunProcedure("SP_T_KHACHHANG_PHANANH_UPDATE_V2", parameters, rowAffect);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Cập nhật phản ánh thành kết thúc
        /// </summary>
        /// <param name="NguoiSua"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdatePhanAnh_Status( string NguoiSua, long Id)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@NguoiSua",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@Id",SqlDbType.BigInt),
                    new SqlParameter("@OUTPUT", SqlDbType.Int)};
                parameters[0].Value = NguoiSua;
                parameters[1].Value = Id;
                parameters[2].Direction = ParameterDirection.Output;

                RunProcedure("SP_T_KHACHHANG_PHANANH_UPDATE_STATUS", parameters);
                return Convert.ToInt16(parameters[2].Value) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// lay ra tat ca thong tin phan anh chua giai quyet xong
        /// </summary>
        /// <returns></returns>
        public DataTable GetThongTinPhanAnh(bool trangThai)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TrangThai", SqlDbType.Bit)
            };
            parameters[0].Value = trangThai;
            ds = RunProcedure("SP_T_KHACHHANG_PHANANH_SELECT_BY_STATUS", parameters, "tblThongTinPA");
            return ds.Tables[0];
        }


        /// <summary>
        /// lay ra tat ca thong tin phan anh
        /// </summary>
        /// <returns></returns>
        public DataTable GetThongTinPhanAnhII(bool trangThai, bool isCapCao)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TrangThai", SqlDbType.Bit),
                new SqlParameter("@IsCapCao", SqlDbType.Bit)
            };
            parameters[0].Value = trangThai;
            parameters[1].Value = isCapCao;
            ds = RunProcedure("SP_T_KHACHHANG_PHANANH_SELECT_BY_STATUS_II", parameters, "tblThongTinPA");
            return ds.Tables[0];
        }

        /// <summary>
        /// Insert tat ca cuoc goi vao line phan anh, update cuoc goi thanh cuoc goi khieu nai cua khach hang(neu co cuoc goi moi)
        /// </summary>
        /// <param name="NguoiTao">User dang dang nhap</param>
        /// <param name="lineCapPhep">Line cua may tinh User dang ngoi</param>
        /// <returns>Danh sach cac cuoc goi khieu nai chua giai quyet</returns>
        public DataTable GetPhanAnh_By_CuocGoi(string NguoiTao, string lineCapPhep)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@LineChoPhep", SqlDbType.VarChar,50),
                new SqlParameter("@NguoiTao", SqlDbType.NVarChar,50),
                new SqlParameter("@Count", SqlDbType.Bit)
            };
            parameters[0].Value = lineCapPhep;
            parameters[1].Value = NguoiTao;
            parameters[2].Direction = ParameterDirection.Output;
            DataSet ds = RunProcedure("SP_T_KHACHHANG_PHANANH_INSERT_BY_T_TAXIOPERATION", parameters, "tblThongTinPA");            
            if (Convert.ToBoolean(parameters[2].Value) == false)
            {
                return null;
            }
            else
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
        }

        /// <summary>
        /// báo cáo tổng hợp thông tin khách hàng phản ánh
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetBaoCaoTongHop(DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TuNgay",SqlDbType.DateTime ),
                new SqlParameter("@DenNgay",SqlDbType.DateTime )
            };

            parameters[0].Value = TuNgay;
            parameters[1].Value = DenNgay;

            ds = this.RunProcedure("SP_BAOCAO_TONGHOP_PHANANH", parameters, "tblTongHop");
            return ds.Tables[0];
        }

        /// <summary>
        /// báo cáo giai quyet thông tin khách hàng phản ánh
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetBaoCaoGiaiQuyet(DateTime TuNgay, DateTime DenNgay,string SoDT, string TenKH,string DiaChi, int TrangThai)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TuNgay",SqlDbType.DateTime ),
                new SqlParameter("@DenNgay",SqlDbType.DateTime ),
                new SqlParameter("@SoDT",SqlDbType.VarChar,14 ),
                new SqlParameter("@TenKH",SqlDbType.NVarChar,100 ),
                new SqlParameter("@DiaChi",SqlDbType.NVarChar,500 ),
                new SqlParameter("@TrangThai",SqlDbType.Bit)
            };

            parameters[0].Value = TuNgay;
            parameters[1].Value = DenNgay;
            if(!string.IsNullOrEmpty(SoDT))
                parameters[2].Value = SoDT;
            if (!string.IsNullOrEmpty(TenKH))
                parameters[3].Value = TenKH;
            if (!string.IsNullOrEmpty(DiaChi))
                parameters[4].Value = DiaChi;
            if (TrangThai == 0)
                parameters[5].Value = false;
            if (TrangThai == 1)
                parameters[5].Value = true;

            ds = this.RunProcedure("SP_T_KHACHHANG_PHANANH_BC_ChiTietPhanAnh", parameters, "tblChiTietPhanAnh");
            return ds.Tables[0];
        }


        public bool Delete(long id)
        {
             if(id <= 0)
                 throw new ArgumentNullException("ID Phản ánh","ID phản ánh có giá trị lớn hơn 0 .");

            string sql  = "DELETE FROM T_KHACHHANG_PHANANH  WHERE ID = " + id.ToString ();

            return (RunSQL(sql)==0);
        }
    }
}
