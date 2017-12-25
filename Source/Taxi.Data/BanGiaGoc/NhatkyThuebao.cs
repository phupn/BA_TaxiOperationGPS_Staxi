using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Taxi.Data.BanGiaGoc
{
    public class NhatkyThuebao : DBObject
    {

        public int Insert(DateTime ThoiDiem, string SoHieuXe, string TenLaiXe, string TuyenDuongID, string TenTuyenDuong, int Chieu, DateTime ThoiGianDon, 
                          int KmDon, DateTime ThoiGianTra, int KmTra, float KmThucDi, int DongHoTien, string PhuTroi, double TienThucThu,
                          string MaNhanVienNhap, string GhiChu, int LoaiXeID, string GiaThueBao, bool IsQuanToan, string soDienThoai)
        {
            try
            {
    //@ThoiDiem DateTime,
    //@SoHieuXe varchar(4),
    //@TenLaiXe nvarchar(50),
    //@TuyenDuongID char(5),
    //@TenTuyenDuong nvarchar(50),
    //@Chieu int,
    //@ThoiGianDon DateTime,
    //@KmDon int,
    //@ThoiGianTra DateTime,
    //@KmTra int,
    //@KmThucDi float, 
    //@DongHoTien int,
    //@PhuTroi  nvarchar(50),
    //@TienThucThu float,
    //@MaNhanVienNhap nvarchar(50),
    //@GhiChu nvarchar(50),
    //@LoaiXeID int 

                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    
                    new SqlParameter("@ThoiDiem",SqlDbType.DateTime) , 
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4)  ,
                    new SqlParameter("@TenLaiXe",SqlDbType.NVarChar,50) , 
                    new SqlParameter("@TuyenDuongID",SqlDbType.VarChar,5),
                    new SqlParameter("@TenTuyenDuong",SqlDbType.NVarChar,50) , 

                    new SqlParameter("@Chieu",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDon",SqlDbType.DateTime),
                    new SqlParameter("@KmDon",SqlDbType.Int) , 
                    new SqlParameter("@ThoiGianTra",SqlDbType.DateTime),                     
                    new SqlParameter("@KmTra",SqlDbType.Int) , 

                    new SqlParameter("@KmThucDi",SqlDbType.Float) , 
                    new SqlParameter("@DongHoTien",SqlDbType.Int)  ,
                    new SqlParameter("@PhuTroi",SqlDbType.NVarChar,50) , 
                    new SqlParameter("@TienThucThu",SqlDbType.Float),
                    new SqlParameter("@MaNhanVienNhap",SqlDbType.NVarChar,50) , 
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,250),
                    new SqlParameter("@LoaiXeID",SqlDbType.Int) , 
                    new SqlParameter("@GiaThueBao",SqlDbType.VarChar,50),
                    new SqlParameter("@IsQuanToan",SqlDbType.Bit),
                    new SqlParameter("@SoDienThoai",SqlDbType.VarChar,11),
                };


                parameters[0].Value = ThoiDiem;
                parameters[1].Value = SoHieuXe;
                parameters[2].Value = TenLaiXe;
                parameters[3].Value = TuyenDuongID;
                parameters[4].Value = TenTuyenDuong;

                parameters[5].Value = Chieu ;
                parameters[6].Value = ThoiGianDon;
                parameters[7].Value = KmDon;
                parameters[8].Value = ThoiGianTra ;
                parameters[9].Value = KmTra;

                parameters[10].Value = KmThucDi ;
                parameters[11].Value = DongHoTien ;
                parameters[12].Value = PhuTroi ;
                parameters[13].Value = TienThucThu ;

                parameters[14].Value = MaNhanVienNhap;
                parameters[15].Value = GhiChu ;
                parameters[16].Value = LoaiXeID;
                parameters[17].Value = GiaThueBao;
                parameters[18].Value = IsQuanToan;

                parameters[19].Value = soDienThoai;

                return this.RunProcedure("SP_T_NHATKYTHUEBAO_insert", parameters, rowAffected);

            }
            catch (Exception e)
            {
                return -1;
            }
        }
       
        public int Update( string TuyenDuongID, string TenTuyenDuong, int Chieu, DateTime ThoiGianDon, int KmDon, DateTime ThoiGianTra, int KmTra,
                           int KmThucDi, int DongHoTien, string PhuTroi, double TienThucThu,string GhiChu, int ID,int LoaiXeID, string GiaThueBao,
                           string MaNhanVienNhap, string soDienThoai)
        {
            try
            {
                //@ID int,	 
                //@TuyenDuongID char(5),
                //@TenTuyenDuong nvarchar(50),
                //@Chieu int,
                //@ThoiGianDon DateTime,
                //@KmDon int,
                //@ThoiGianTra DateTime,
                //@KmTra int,

                //@KmThucDi float, 
                //@DongHoTien int,
                //@PhuTroi  nvarchar(50),
                //@TienThucThu float	,
                //@GhiChu nvarchar(50),
                //@LoaiXeID int ,
                //@GiaThueBao varchar(50) 
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int),                     
                    new SqlParameter("@TuyenDuongID",SqlDbType.VarChar,5),
                    new SqlParameter("@TenTuyenDuong",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@Chieu",SqlDbType.Int),
                    new SqlParameter("@ThoiGianDon",SqlDbType.DateTime),
                    new SqlParameter("@KmDon",SqlDbType.Int) , 
                    new SqlParameter("@ThoiGianTra",SqlDbType.DateTime),
                    new SqlParameter("@KmTra",SqlDbType.Int) , // 7
                    new SqlParameter("@KmThucDi",SqlDbType.Float) ,                    
                    new SqlParameter("@DongHoTien",SqlDbType.Int)  ,
                    new SqlParameter("@PhuTroi",SqlDbType.NVarChar,50) , 
                    new SqlParameter("@TienThucThu",SqlDbType.Float), 
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,250),     //12           
                     new SqlParameter("@LoaiXeID",SqlDbType.Int ),
                    new SqlParameter("@GiaThueBao",SqlDbType.NVarChar,50 )   ,
                     new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50 ) ,
                    new SqlParameter("@SoDienThoai",SqlDbType.VarChar,11),
                };


                parameters[0].Value = ID ;
                parameters[1].Value = TuyenDuongID;
                parameters[2].Value = TenTuyenDuong ;
                parameters[3].Value = Chieu;
                parameters[4].Value = ThoiGianDon;
                parameters[5].Value = KmDon ;
                parameters[6].Value = ThoiGianTra;

                parameters[7].Value = KmTra;
                parameters[8].Value = KmThucDi;
                parameters[9].Value = DongHoTien;
                parameters[10].Value = PhuTroi;
                parameters[11].Value = TienThucThu;
                parameters[12].Value = GhiChu ;
                parameters[13].Value = LoaiXeID;
                parameters[14].Value = GiaThueBao;
                parameters[15].Value = MaNhanVienNhap;

                parameters[16].Value = soDienThoai;

                return this.RunProcedure("SP_T_NHATKYTHUEBAO_Update", parameters, rowAffected);

            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public int Delete(int ID)
        {
            //[sp_T_TUDIEN_LOAIXE_Xoa]                 
            //        @LoaiXeID int



            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    
                    new SqlParameter("@ID",SqlDbType.Int) , 
                  
                    
                };
                parameters[0].Value = ID;
                return this.RunProcedure("SP_T_NHATKYTHUEBAO_Delete", parameters, rowAffected);

            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public DataTable SelectAll()
        {
            SqlParameter[] parameters = new SqlParameter[] {
                                 
                };

            return this.RunProcedure("[SP_T_NHATKYTHUEBAO_select]", parameters, "tblGara").Tables[0];
        }

        public DataTable GetOne(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                
                    new SqlParameter("@ID",SqlDbType.Int  )                    
                };

            parameters[0].Value = ID;

            return this.RunProcedure("SP_T_NHATKYTHUEBAO_selectone", parameters, "SP_T_NHATKYTHUEBAO_selectone").Tables[0];
        }

        public System.Data.DataTable GetAll()
        {

            SqlParameter[] parameters = new SqlParameter[] {  }; 
            return this.RunProcedure("SP_T_NHATKYTHUEBAO_select", parameters, "tblGara").Tables[0];
        }



        public DataTable GetBCNhatKyThueBao(string strSQL)
        {  
            return this.RunSQL(strSQL, "tbl");
        }
        /// <summary>
        /// nhap thong tin nhat ky thue bao
        /// </summary>
        /// <returns></returns>
        public DataTable GetDSNhungCuocChuaNhapDuThongTin()
        {
            string strSQL = "SELECT  * FROM  [TRUNGKIEN.T_NHATKYTHUEBAO] WHERE KmThucDi =-1";
            return this.RunSQL(strSQL, "tbl");
        }

        public DataTable GetDSCuocThuebao(DateTime TuNgay, DateTime DenNgay, string SoHieuXe, string noiDungTimKhac)
        {
            string strSQL = "";

            if (SoHieuXe.Length > 0)
                strSQL = "SELECT  *  FROM  [TRUNGKIEN.T_NHATKYTHUEBAO] WHERE ThoiDiem >= '" + string.Format("{0: yyyy-MM-dd HH:mm:ss}", TuNgay) + "' AND ThoiDiem <= '" + string.Format("{0: yyyy-MM-dd HH:mm:ss}", DenNgay) + "' AND SoHieuXe ='" + SoHieuXe + "'";

            else
                strSQL = "SELECT  *  FROM  [TRUNGKIEN.T_NHATKYTHUEBAO] WHERE ThoiDiem >= '" + string.Format("{0: yyyy-MM-dd HH:mm:ss}", TuNgay) + "' AND ThoiDiem <= '" + string.Format("{0: yyyy-MM-dd HH:mm:ss}", DenNgay) + "'";

            if (noiDungTimKhac.Length > 0)
                strSQL += " AND ((TenTuyenDuong LIKE N'%" + noiDungTimKhac + "%') OR (GhiChu LIKE N'%" + noiDungTimKhac + "%') OR  (SoDienThoai LIKE '%" + noiDungTimKhac + "%'))";  

            return this.RunSQL(strSQL, "tbl");
        }
        /// <summary>
        /// hàm thực hiện cập nhận thực hiện gọi
        /// Sửa dụng spaceBar ghi nhận
        /// </summary>
        public bool GhiNhanThucHienGoi(long idThueBaoTuyen, string nhanVien, string ghiChu, byte trangThaiCuocGoi, bool ketThuc)
        {
            if (idThueBaoTuyen > 0 && nhanVien.Length > 0)
            {
                try
                {
                    string sql = " UPDATE [TRUNGKIEN.T_NHATKYTHUEBAO] ";
                    sql += " SET CSKH_NhanVienGoi ='" + nhanVien + "',";
                    sql += "     CSKH_ThoiDiemGoi =  CASE WHEN CSKH_ThoiDiemGoi IS NULL  THEN  GETDATE() ELSE CSKH_ThoiDiemGoi  END,";
                    sql += "     CSKH_IsDaGoi = 1, ";
                    sql += "     CSKH_GhiChu  = N'" + ghiChu.Replace("DELETE", " ").Replace("DROP", " ") + "' ,";
                    sql += "     CSKH_TrangThaiGoi = " + trangThaiCuocGoi.ToString() + ",";

                    if (ketThuc)
                        sql += "  CSKH_KetThuc = 1 , ";
                    sql += "     CSKH_ThoiDiemCapNhanCuoi =  CASE WHEN CSKH_ThoiDiemGoi IS NULL THEN  CSKH_ThoiDiemCapNhanCuoi ELSE GETDATE()  END  ";

                    sql += " WHERE ID = " + idThueBaoTuyen.ToString();

                    return (RunSQL(sql) == 0);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return false;
        }
    }
}
