using System;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
    public class NhanVien : DBObject
    {
        public bool Insert(string MaNhanVien, string TenNhanVien, DateTime NgaySinh, bool GioiTinh, string SoCMT, string DiaChi, string DienThoai, string DiDong, string Email, string VanBang, int PhongID, int ChucVuID, string SoHieuXeLai, string SoTheLaiXe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("PK_MaNhanVien",SqlDbType.VarChar,6),
                    new SqlParameter("@TenNhanVien",SqlDbType.NVarChar,50),
                    new SqlParameter("@NgaySinh",SqlDbType.DateTime) ,
                    new SqlParameter("@GioiTinh",SqlDbType.Char,1) ,
                    new SqlParameter("@SoCMT",SqlDbType.VarChar,15) ,
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@DienThoai",SqlDbType.Char ,15) ,            
                    new SqlParameter("@DiDong",SqlDbType.VarChar,50) ,
                    new SqlParameter("@Email",SqlDbType.NVarChar ,50),
                    new SqlParameter("@VanBang",SqlDbType.NVarChar ,50),
                    new SqlParameter("@FK_PhongID",SqlDbType.Int ),
                    new SqlParameter("@FK_ChucVu",SqlDbType.Int),
                    new SqlParameter("@FK_SoHieuXeLai",SqlDbType.VarChar,4),  
                    new SqlParameter("@SoTheLaiXe",SqlDbType.VarChar ,10)
                };
                parameters[0].Value = MaNhanVien;
                parameters[1].Value = TenNhanVien;
                parameters[2].Value = NgaySinh;
                parameters[3].Value = GioiTinh == true ? "1" : "0";
                parameters[4].Value = SoCMT;
                parameters[5].Value = DiaChi;
                parameters[6].Value = DienThoai;
                parameters[7].Value = DiDong;
                parameters[8].Value = Email;
                parameters[9].Value = VanBang;
                parameters[10].Value = PhongID;
                parameters[11].Value = ChucVuID;
                parameters[12].Value = SoHieuXeLai;
                parameters[13].Value = SoTheLaiXe;
                rowAffected = this.RunProcedure("sp_T_NHANVIEN_Insert", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch
            {
                return false;
            }
        }

        public bool Update(string MaNhanVien, string TenNhanVien, DateTime NgaySinh, bool GioiTinh, string SoCMT, string DiaChi, string DienThoai, string DiDong, string Email, string VanBang, int PhongID, int ChucVuID, string SoHieuXeLai, string SoTheLaiXe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("PK_MaNhanVien",SqlDbType.VarChar,6),
                    new SqlParameter("@TenNhanVien",SqlDbType.NVarChar,50),
                    new SqlParameter("@NgaySinh",SqlDbType.DateTime) ,
                    new SqlParameter("@GioiTinh",SqlDbType.Char,1) ,
                    new SqlParameter("@SoCMT",SqlDbType.VarChar,15) ,
                    new SqlParameter("@DiaChi",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@DienThoai",SqlDbType.Char ,15) ,            
                    new SqlParameter("@DiDong",SqlDbType.VarChar,50) ,
                    new SqlParameter("@Email",SqlDbType.NVarChar ,50),
                    new SqlParameter("@VanBang",SqlDbType.NVarChar ,50),
                    new SqlParameter("@FK_PhongID",SqlDbType.Int ),
                    new SqlParameter("@FK_ChucVu",SqlDbType.Int),
                    new SqlParameter("@FK_SoHieuXeLai",SqlDbType.VarChar,4),  
                    new SqlParameter("@SoTheLaiXe",SqlDbType.VarChar ,10)
                };
                parameters[0].Value = MaNhanVien;
                parameters[1].Value = TenNhanVien;
                parameters[2].Value = NgaySinh;
                parameters[3].Value = GioiTinh == true ? "1" : "0";
                parameters[4].Value = SoCMT;
                parameters[5].Value = DiaChi;
                parameters[6].Value = DienThoai;
                parameters[7].Value = DiDong;
                parameters[8].Value = Email;
                parameters[9].Value = VanBang;
                parameters[10].Value = PhongID;
                parameters[11].Value = ChucVuID;
                parameters[12].Value = SoHieuXeLai;
                parameters[13].Value = SoTheLaiXe;


                rowAffected = this.RunProcedure("sp_T_NHANVIEN_Update", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lay danh saach NhanVien, neu co MaNhanVien thi  tra ve thong tin chi tien mot nhan vien
        /// nguoi lai thi tra ve mot danh sach
        /// </summary>
        public DataTable GetDanhSachNhanViens(string MaNhanVien)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_MaNhanVien",SqlDbType.VarChar ,6)                    
                };
            parameters[0].Value = MaNhanVien;

            return this.RunProcedure("sp_T_NHANVIEN_Select", parameters, "tblUser").Tables[0];
        }

        public bool Delete(string MaNhanVien)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_MaNhanVien",SqlDbType.VarChar ,6)                    
                };
                parameters[0].Value = MaNhanVien;

                rowAffected = this.RunProcedure("sp_T_NHANVIEN_Delete", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// lay ma lon nhat cua MaNhanVien
        /// </summary>
        /// <returns></returns>
        public string GetMaxKeyNhanVien()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_MaNhanVien",SqlDbType.VarChar ,6)                    
                };
                parameters[0].Value = string.Empty;
                parameters[0].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("sp_T_NHANVIEN_GetMaxKey", parameters, rowAffected);

                return parameters[0].Value.ToString();
            }
            catch
            {
                return string.Empty;// Loi chung tring phai a Phong
            }
        }
        /// <summary>
        /// lấy mã lớn nhất của MaNhanVien
        /// </summary>
        /// <returns></returns>
        public string GetMaxKeyNhanVienV2()
        {
            try
            {
                DataTable dt = this.ExeStoreData("sp_dh_T_NHANVIEN_GetMaxKey");
                if (dt.Rows.Count > 0)
                {
                    int id = int.Parse(dt.Rows[0][0].ToString());
                    return string.Format("NV{0}", (long)id + 1);
                }
            }
            catch
            {
            }
            return string.Empty;
        }
        /// <summary>
        /// thuc hien mot cau lenh get thong tin cua cac nhan vien    
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataTable GetNhanViens(string strSQL)
        {
            return RunSQL(strSQL, "tblNhanVien");
        }

        /// <summary>
        /// tra ve thonog tin lai xe by MaTheLaiXe
        /// </summary>
        public DataTable GetNhanVienByTheLaiXe(string SoTheLaiXe)
        {
            //[sp_T_NHANVIEN_SelectBySoTheLaiXe]
            //    @SoTheLaiXe char(10)

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoTheLaiXe",SqlDbType.VarChar ,6)                    
                };
            parameters[0].Value = SoTheLaiXe;

            return this.RunProcedure("sp_T_NHANVIEN_SelectBySoTheLaiXe", parameters, "tblUser").Tables[0];
        }

        /// <summary>
        /// tra ve thonog tin lai xe by SoHieuXe
        /// </summary>
        public DataTable GetNhanVienSearch(string thongTinTimKiem)
        {
            //[sp_T_NHANVIEN_SelectBySoTheLaiXe]
            //    @SoTheLaiXe char(10)

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@thongTinTimKiem",SqlDbType.VarChar ,6)                    
                };
            parameters[0].Value = thongTinTimKiem;

            return this.RunProcedure("sp_T_NHANVIEN_Search", parameters, "tblUser").Tables[0];
        }
    }
}
