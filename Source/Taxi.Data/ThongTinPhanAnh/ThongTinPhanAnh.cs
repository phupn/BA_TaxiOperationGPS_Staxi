using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.ThongTinPhanAnh
{
    public class ThongTinPhanAnh :DBObject
    {
        public string ConnectString;

        #region TEN THU TUC
        private string SP_DMCONGTY_GET_ALLNAME = "[SP_CONGTY_SELECT_ALL_NAME]";
        private string SP_KHACHHANGPHANANH_LOAIPHANANH = "SP_KHACHHANG_PHANANH_SELECTALL";
        private string SP_KHACHHANG_PHANANH_JOIN = "sp_KHACHHANG_PHANANH_JOIN";
        private string SP_KHACHHANG_PHANANH_KETTHUC_GOILAIGOIKHAC = "sp_KHACHHANG_PHANANH_GioLaiGoiKhac";
        private string SP_KHACHHANG_PHANANH_GETALL = "SP_T_KHACHHANGPHANANH_GETALL";
        private string SP_KHACHHANG_PHANANH_INSERT_CUOCGOI = "SP_T_KHACHHANGPHANANH_INSERT_CUOCGOI";
        private string SP_KHACHHANG_PHANANH_UPDATE_CUOCGOI = "SP_T_KHACHHANGPHANANH_UPDATE_CUOCGOI";
        private string SP_KHACHHANG_PHANANH_UPDATE_GIAIQUYET = "SP_T_KHACHHANGPHANANH_UPDATE_GIAIQUYET";
        private string SP_KHACHHANG_PHANANH_GETBYID = "SP_T_KHACHHANGPHANANH_GETBYID";
        private string SP_KHACHHANG_PHANANH_UPDATEALL = "[SP_KHACHHANGPHANANH_UPDATEALL]";
        private string SP_KHACHHANG_PHANANH_JOIN_BYDATE = "[SP_KHACHHANG_PHANANH_JOIN_BYDATE]";
        private const string SP_KHACHHANG_PHANANH_BAOCAO_THEONGAY = "SP_KHACHHANG_PHANANH_BAOCAO_THEONGAY";
        private string SP_KHACHHANG_PHANANH_TONGHOP = "[SP_BAOCAO_TONGHOP_PHANANH]";
        private string SP_KHACHHANG_PHANANH_GET_CHUYENDONVI = "[SP_T_KHACHHANG_PHANANH_GET_CHUYENDONVI]";
        private string SP_KHACHHANG_PHANANH_SEARCH = "[SP_PHANANH_SEARCH_PHANANH]";
        private string SP_DMCONGTY_GETALL = "[SP_T_DMCongTy_GETALL]";
        private string SP_PHANANH_CONGTY_INSERT = "SP_T_PHANANH_CONGTY_INSERT";
        private string SP_PHANANH_CONGTY_GETCT_BYPAID  = "[SP_T_PHANANH_CONGTY_GETCONGTY_BYPHANANHID]";
        private string SP_T_TAXIOPERATION_CHUYENDAM = "[SP_T_TAXIOPERATION_INSERT_CHUYENDAM]";
        private const string SP_KHACHHANG_PHANANH_UPDATE_GHICHU = "SP_T_KHACHHANGPHANANH_UPDATE_KETTHUC_GHICHU";
        private const string SP_KHACHHANG_PHANANH_UPDATE_KQGIAIQUYET = "SP_T_KHACHHANGPHANANH_UPDATE_KETQUAGIAIQUYET";
        

     

        #endregion

        public ThongTinPhanAnh()
        {
            ConnectString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString.ToString();
        }

        #region GET METHOD
        /// <summary>
        /// Lay ra thong tin cong ty có dòng chọn công ty
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        /// 
        public DataTable GetDMCongTy()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { };
            ds = this.RunProcedure(SP_DMCONGTY_GET_ALLNAME, parameters, "tblDMCongTy");
            return ds.Tables[0];
        }

        /// <summary>
        /// Lay ra thong tin cong ty ko có chọn công ty
        /// </summary>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      19/7/2011   created
        /// </modified>
        ///
        public DataTable GetAllCongTy()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { };
            ds = this.RunProcedure(SP_DMCONGTY_GETALL, parameters, "tblDMCongTy");
            return ds.Tables[0];
        }

        /// <summary>
        /// lay ra thong tin cac loai phan anh
        /// </summary>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>        
        public DataTable GetLoaiPhanAnh()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { };
            ds = this.RunProcedure(SP_KHACHHANGPHANANH_LOAIPHANANH , parameters, "tblLoaiPhanAnh");
            return ds.Tables[0];
        }

        /// <summary>
        /// lay ra tat ca thong tin phan anh chua giai quyet xong
        /// cac thong tin nay join tu nhieu bang
        /// </summary>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public DataTable GetThongTinPhanAnh(bool trangThai)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TrangThai", SqlDbType.Bit)
            };
            parameters[0].Value = trangThai;
            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_JOIN , parameters, "tblThongTinPA");
            return ds.Tables[0];
        }

        public DataTable GetThongTinPhanAnhGoiLaiGoiKhac(DateTime TuNgay, DateTime DenNgay)
        {
             DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TuNgay", SqlDbType.DateTime),
                new SqlParameter("@DenNgay", SqlDbType.DateTime) 
            };
            parameters[0].Value = TuNgay;
            parameters[1].Value = DenNgay ;
            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_KETTHUC_GOILAIGOIKHAC, parameters, "tblThongTinPA");
            return ds.Tables[0];
            
        }
        /// <summary>
        /// lay ra thong tin phan anh da giai quyet xong trong bang [T_KHACHHANGPHANANH]
        /// </summary>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public DataTable GetAllKhachHangPA()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { };
            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_GETALL , parameters, "tblKhachHangPA");
            return ds.Tables[0];
        }
        
        /// <summary>
        /// lay ra bang [T_KHACHHANGPHANANH] theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public DataTable GetAllByID(long id)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@ID",SqlDbType.BigInt)
            };
            parameters[0].Value = id;
            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_GETBYID, parameters, "tblKhachHangPA");
            return ds.Tables[0];
        }

        public DataTable GetCongTyByPhanAnhID(int idPhanAnh)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@PhanAnhID",SqlDbType.Int)
            };
            parameters[0].Value = idPhanAnh;

            ds = this.RunProcedure(SP_PHANANH_CONGTY_GETCT_BYPAID, parameters, "tbPhanAnhCongTy");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        #endregion

        #region Thao tac du lieu

        /// <summary>
        /// chen 1 cuoc goi vao bang voi noi dung phan anh ma chua duoc xu li
        /// </summary>
        /// <param name="dienThoai"></param>
        /// <param name="tenKhachHang"></param>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public int InsertCuocGoi(string dienThoai, string tenKhachHang,string noiDung, int loaiPhanAnh, int mucDo,
            int congTyID,string idNhanVien, long FK_TaxiOperationID)
        {
            try
            {                 
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@DienThoai",SqlDbType.NVarChar,25),
                    new SqlParameter("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@NoiDung",SqlDbType.NVarChar ,1500),
                    new SqlParameter ("@LoaiPhanAnh",SqlDbType.Int ),
                    new SqlParameter ("@MucDo",SqlDbType.TinyInt ),
                    new SqlParameter ("@CongtyID",SqlDbType.Int),
                    new SqlParameter ("@IDNhanVien",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@FK_TaxiOperationID",SqlDbType.Int ),
                    new SqlParameter ("@PhanAnhID", SqlDbType.Int)
                };
                parameters[0].Value = dienThoai;
                parameters[1].Value = tenKhachHang;
                parameters[2].Value = noiDung ;
                parameters[3].Value = loaiPhanAnh ;
                parameters[4].Value = mucDo ;
                parameters[5].Value = congTyID ;
                parameters[6].Value = idNhanVien ;
                parameters[7].Value = FK_TaxiOperationID;
                parameters[8].Direction = ParameterDirection.Output;

                this.RunProcedure(SP_KHACHHANG_PHANANH_INSERT_CUOCGOI, parameters, rowsAffected);
                return Convert.ToInt32(parameters[8].Value)  ;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Update Cuoc goi voi chi tiet noi dung phan anh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenKhachHang"></param>
        /// <param name="noiDung"></param>
        /// <param name="loaiPhanAnh"></param>
        /// <param name="mucDo"></param>
        /// <param name="congTyID"></param>
        /// <param name="idNhanVien"></param>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public int UpdateCuocGoi(long id,string tenKhachHang,string noiDung,int loaiPhanAnh, int mucDo, int congTyID,string idNhanVien, bool isChuyen, bool isGoiLaiGoiKhac, string maThongTin)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@ID",SqlDbType.BigInt ),                   
                    new SqlParameter("@TenKhachHang",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@NoiDung",SqlDbType.NVarChar ,1500),
                    new SqlParameter("@LoaiPhanAnh",SqlDbType.Int ),
                    new SqlParameter("@MucDo",SqlDbType.TinyInt ),
                    new SqlParameter ("@CongtyID",SqlDbType.Int ),
                    new SqlParameter("@IDNhanVien",SqlDbType.NVarChar,50),
                    new SqlParameter ("@isChuyen", SqlDbType.Bit),
                    new SqlParameter ("@IsGoiLaiGoiKhac",SqlDbType.Bit),
                    new  SqlParameter("@MaThongTin",SqlDbType.NVarChar ,50) 
                };
                parameters[0].Value = id ;
                parameters[1].Value = tenKhachHang;
                parameters[2].Value = noiDung ;
                parameters[3].Value = loaiPhanAnh ;
                parameters[4].Value = mucDo ;
                parameters[5].Value = congTyID ;
                parameters[6].Value = idNhanVien ;
                parameters[7].Value = isChuyen;
                parameters[8].Value = isGoiLaiGoiKhac;
                parameters[9].Value = maThongTin;
                rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_UPDATE_CUOCGOI , parameters, rowsAffected);
                return rowAffect;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// update thong tin giai quyet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ketQua"></param>
        /// <param name="ngayGiaiQuyet"></param>
        /// <param name="mucHaiLong"></param>
        /// <param name="yKienKH"></param>
        /// <param name="idNhanVien"></param>
        /// <param name="trangThaiXuly"></param>
        /// <returns></returns>
        ///  /// <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public int UpdateGiaiQuyet(long id, string ketQua, DateTime ngayGiaiQuyet, int mucHaiLong,string yKienKH, string idNhanVien,bool trangThaiXuly, bool isChuyen)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@ID",SqlDbType.BigInt ),                   
                    new SqlParameter("@KetQua",SqlDbType.NVarChar ,250),
                    new SqlParameter ("@NgayGiaiQuyet",SqlDbType.DateTime),
                    new SqlParameter("@MucHaiLong",SqlDbType.TinyInt  ),
                    new SqlParameter("@YKien",SqlDbType.NVarChar,250 ),
                    new SqlParameter ("@IDNhanVien",SqlDbType.NVarChar,50),
                    new SqlParameter("@TrangThaiXuLy",SqlDbType.Bit),
                    new SqlParameter ("isChuyen", SqlDbType.Bit)
                };
                parameters[0].Value = id;
                parameters[1].Value = ketQua ;
                parameters[2].Value = ngayGiaiQuyet ;
                parameters[3].Value = mucHaiLong ;
                parameters[4].Value = yKienKH;
                parameters[5].Value = idNhanVien ;
                parameters[6].Value = trangThaiXuly ;
                parameters[7].Value = isChuyen;

                rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_UPDATE_GIAIQUYET , parameters, rowsAffected);
                return rowAffect;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// update ca bang thong tin khach phan anh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenKH"></param>
        /// <param name="noiDung"></param>
        /// <param name="loaiPhanAnh"></param>
        /// <param name="mucDoPA"></param>
        /// <param name="congTyID"></param>
        /// <param name="nhanVienNhanPA"></param>
        /// <param name="ketQua"></param>
        /// <param name="ngayGiaiQuyet"></param>
        /// <param name="mucHaiLong"></param>
        /// <param name="yKien"></param>
        /// <param name="idNhanVien"></param>
        /// <param name="trangThai"></param>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      19/5/2011   created
        /// </modified>
        public int UpdateAll(long id,string tenKH,string noiDung,int loaiPhanAnh,int mucDoPA,int congTyID,string nhanVienNhanPA,
                string ketQua,DateTime ngayGiaiQuyet,int mucHaiLong,string yKien,string idNhanVien,bool trangThai)
        {
            try 
            {
                int rowAffect = 0;
                SqlParameter[] parameter = new SqlParameter[] { 
                    new SqlParameter ("@ID",SqlDbType.Int ),
                    new SqlParameter ("@TenKhachHang",SqlDbType.NVarChar,50),
                    new SqlParameter ("@NoiDung",SqlDbType.NVarChar ,1500),
                    new SqlParameter ("@LoaiPhanAnh",SqlDbType.Int ),
                    new SqlParameter ("@MucDo",SqlDbType.TinyInt ),
                    new SqlParameter ("@CongtyID",SqlDbType.Int ),
                    new SqlParameter ("@NhanVienTiepNhan",SqlDbType.NVarChar ,50),
                    new SqlParameter ("@KetQua",SqlDbType.NVarChar,250),
                    new SqlParameter ("@NgayGiaiQuyet",SqlDbType.DateTime ),
                    new SqlParameter ("@MucHaiLong",SqlDbType.TinyInt ),
                    new SqlParameter ("@YKien",SqlDbType.NVarChar,250),
                    new SqlParameter ("@IDNhanVien",SqlDbType.NVarChar,50),
                    new SqlParameter ("@TrangThaiXuLy",SqlDbType.Bit ),
                  
                };
                    parameter [0].Value = id;
                    parameter [1].Value = tenKH;
                    parameter [2].Value  = noiDung;
                    parameter [3].Value =loaiPhanAnh;
                    parameter [4].Value = mucDoPA;
                    parameter [5].Value = congTyID;
                    parameter [6].Value = nhanVienNhanPA;
                    parameter [7].Value= ketQua;
                    parameter [8].Value = ngayGiaiQuyet;
                    parameter [9].Value = mucHaiLong ;
                    parameter [10].Value = yKien;
                    parameter [11].Value = idNhanVien;
                    parameter[12].Value = trangThai;

                    rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_UPDATEALL, parameter, rowsAffected);
                    return rowAffect ;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// lấy ra danh sách cuộc gọi phản ánh chuyển đơn vị
        /// </summary>
        /// <returns></returns>
        /// ///  <modified>
        /// name        date        comments
        /// hangtm      17/7/2011   created
        /// </modified>
        public DataTable GetPhanAnhChuyenDonVi()
        {
            DataSet ds= new DataSet();            
            SqlParameter []parameters = new SqlParameter[]{};
            ds= this.RunProcedure(SP_KHACHHANG_PHANANH_GET_CHUYENDONVI,parameters,"tbXuLyBanDau");
            return ds.Tables[0];
        }

        /// <summary>
        /// insert vào bảng phản ánh công ty
        /// </summary>
        /// <param name="phanAnhID"></param>
        /// <param name="congTyID"></param>
        /// <returns></returns>
        /// <modified>
        /// name        date        comments
        /// hangtm      20/7/2011   created
        /// </modified>
        public bool InsertPhanAnh_CongTy(int phanAnhID,List<int> congTyID)
        {
            if (congTyID == null || congTyID.Count <= 0) return false;

            SqlConnection connect = new SqlConnection(ConnectString);
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            SqlTransaction trans = connect.BeginTransaction();

            try
            {
                 
                
                for (int i = 0; i < congTyID.Count; i++)
                {
                    SqlParameter[] parameters = new SqlParameter[] { 
                        new SqlParameter("@PhanAnhID", SqlDbType.Int),
                        new SqlParameter("@CongTyID", SqlDbType.Int),
                        new SqlParameter ("@IsXoaPhanAnh",SqlDbType.Bit)
                    };
                    parameters[0].Value = phanAnhID;
                    parameters[1].Value = congTyID[i];

                    if (i == 0)
                        parameters[2].Value = 1; // xoa thong tin cuoc cu
                    else
                        parameters[2].Value = 0; 

                    // Tao command
                    SqlCommand command = new SqlCommand(SP_PHANANH_CONGTY_INSERT, connect);
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    command.Transaction = trans;

                    rowsAffected = command.ExecuteNonQuery(); 

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
            finally
            {
                connect.Close();
            }

            
        }

        #endregion

        #region Bao Cao
        /// <summary>
        /// báo cáo giải quyết thông tin khách hàng phản ánh
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      21/5/2011   created
        /// </modified>
        public DataTable JoinByDate(DateTime startDate, DateTime endDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@StartDate",SqlDbType.DateTime ),
                new SqlParameter("@EndDate",SqlDbType.DateTime )
            };

            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_JOIN_BYDATE , parameters, "tblThongTinPA");
            return ds.Tables[0];
        }
        /// <summary>
        /// báo cáo tổng hợp thông tin khách hàng phản ánh
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      23/5/2011   created
        /// </modified>
        public DataTable GetReport(DateTime startDate, DateTime endDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@StartDate",SqlDbType.DateTime ),
                new SqlParameter("@EndDate",SqlDbType.DateTime )
            };

            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_TONGHOP, parameters, "tblTongHop");
            return ds.Tables[0];
        }
       
        #endregion

        #region Search thông tin phản ánh
        /// <summary>
        /// tìm kiếm thông tin phản ánh
        /// </summary>
        /// <param name="soDienThoai"></param> tìm theo số điện thoại (bắt buộc)
        /// <param name="noiDung"></param> tìm theo nội dung phản ánh (tùy chọn)
        /// <param name="tuNgay"></param> tìm theo ngày (bắt buộc)
        /// <param name="denNgay"></param>-----------------------
        /// <param name="trangThai"></param> tìm theo trạng thái đã giải quyết xong chưa (phụ thuộc vào người dùng đang đứng ở tab nào)
        /// <param name="chuyenDV"></param> tìm theo trạng thái có chuyển đơn vị ko (phụ thuộc vào người dùng đang đứng ở tab nào)
        /// <returns></returns>
        /// <modified>
        /// name            date        comments
        /// hangtm         19/7/2011    created
        ///</modified>
        public DataTable SearchPhanAnh(string soDienThoai, string noiDung, DateTime tuNgay, DateTime denNgay, bool trangThai, bool chuyenDV)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@SoDienThoai", SqlDbType.VarChar,25),
                new SqlParameter ("@NoiDung",SqlDbType.NVarChar, 250),
                new SqlParameter ("@TuNgay", SqlDbType.DateTime),
                new SqlParameter("@DenNgay", SqlDbType.DateTime),
                new SqlParameter ("@TrangThai", SqlDbType.Bit),
                new SqlParameter ("@Chuyen", SqlDbType.Bit)
            };
            parameters[0].Value = soDienThoai;
            parameters[1].Value = noiDung;
            parameters[2].Value = tuNgay;
            parameters[3].Value = denNgay;
            parameters[4].Value = trangThai;
            parameters[5].Value = chuyenDV;

            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_SEARCH, parameters, "tbPhanAnh");
            DataTable dt = ds.Tables[0];
            return dt;
        }
        #endregion

    #region Chuyển đàm
        public int InsertPhanAnhChuyenDam(string soDienThoai, string diaChi, int vung)
        {            
            try {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@SoDienThoai", SqlDbType.VarChar,11),
                    new SqlParameter ("@DiaChiDonKhach", SqlDbType.NVarChar,255),
                    new SqlParameter ("@Vung", SqlDbType.Int)
                };
                parameters[0].Value = soDienThoai;
                parameters[1].Value = diaChi;
                parameters[2].Value = vung;

                return this.RunProcedure(SP_T_TAXIOPERATION_CHUYENDAM, parameters, rowsAffected);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    #endregion
        
        public bool UpdateGhiChu(long  id, string ghiChu)
        {
             
            try 
            {
                int rowAffect = 0;
                SqlParameter[] parameter = new SqlParameter[] { 
                    new SqlParameter ("@ID",SqlDbType.BigInt ),
                    new SqlParameter ("@GhiChu",SqlDbType.NVarChar,250) 
                    
                  
                };
                    parameter [0].Value = id;
                    parameter [1].Value = ghiChu ;
                    
                    rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_UPDATE_GHICHU, parameter, rowsAffected);
                    return (rowAffect>0) ;
            }
            catch(Exception ex)
            {
                return false ;
            }
        }
        /// <summary>
        /// hàm trả về thông tin phản ánh
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="dienThoai"></param>
        /// <param name="tenKhachHang"></param>
        /// <param name="maThongTin"></param>
        /// <param name="loaiPhanAnhID"></param>
        /// <param name="congTyID"></param>
        /// <returns></returns>
        public DataTable GetThongTinKhachHangPhanAnh(DateTime tuNgay, DateTime denNgay, string dienThoai, string tenKhachHang, string maThongTin, int loaiPhanAnhID, int congTyID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@StartDate", SqlDbType.DateTime),
                new SqlParameter ("@EndDate",SqlDbType.DateTime),
                new SqlParameter ("@DienThoai", SqlDbType.VarChar,25),
                new SqlParameter ("@TenKhachHang", SqlDbType.NVarChar,50),
                new SqlParameter ("@MaThongTin", SqlDbType.NVarChar,50),
                new SqlParameter ("@LoaiPhanAnhID", SqlDbType.Int),
                new SqlParameter ("@CongTyID", SqlDbType.Int) 
            };
            parameters[0].Value = tuNgay;
            parameters[1].Value = denNgay;
            parameters[2].Value = dienThoai;
            parameters[3].Value = tenKhachHang;
            parameters[4].Value = maThongTin;
            parameters[5].Value = loaiPhanAnhID;
            parameters[6].Value = congTyID;

            ds = this.RunProcedure(SP_KHACHHANG_PHANANH_BAOCAO_THEONGAY, parameters, "tbPhanAnh");
            DataTable dt = ds.Tables[0];
            return dt; 
        }
        /// <summary>
        /// cap nhat thong tin giai quyet, boi maThongTin
        /// </summary>
        /// <param name="maThongTin"></param>
        /// <param name="ketQuaGiaiQuyet"></param>
        /// <returns></returns>
        public bool UpdateKetQuaGiaiQuyet(string maThongTin, string ketQuaGiaiQuyet)
        {
            try
            {
                int rowAffect = 0;
                SqlParameter[] parameter = new SqlParameter[] { 
                    new SqlParameter ("@MaThongTin",SqlDbType.NVarChar,50 ),
                    new SqlParameter ("@KetQuaGiaiQuyet",SqlDbType.NVarChar,250) 
                    
                  
                };
                parameter[0].Value = maThongTin;
                parameter[1].Value = ketQuaGiaiQuyet;

                rowAffect = this.RunProcedure(SP_KHACHHANG_PHANANH_UPDATE_KQGIAIQUYET, parameter, rowsAffected);
                return (rowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    } 
}
