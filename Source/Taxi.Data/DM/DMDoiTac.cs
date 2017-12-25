using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
    /// <summary>
    ///  Cac ham thao cac voi bang T_DOITAC
    /// </summary>
    public class DoiTac : DBObject
    {
        public bool Insert(string MaDoiTac, string Name, string Address, string Phones, string Fax, string Email
            , float TiLeHoaHongNoiTinh, float TiLeHoaHongDuongDai, string Notes, 
            bool IsActive, string MaNhanVien, string TenNhanVien, int Vung, DateTime NgayKyKet,
            int CongTyID, string NguoiTao, string SoNha, string TenDuong, float KinhDo, float ViDo)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@Phones",SqlDbType.VarChar,255) ,
                    new SqlParameter("@Fax",SqlDbType.Char,20) ,
                    new SqlParameter("@Email",SqlDbType.VarChar ,50) ,
                    new SqlParameter("@TiLeHoaHongNoiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@TiLeHoaHongNgoaiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@IsActive",SqlDbType.Char ,1) ,
                    new SqlParameter("@FK_MaNhanVien",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@TenNhanVien",SqlDbType.NVarChar  ,50)  , 
                    new SqlParameter("@Vung",SqlDbType.Int),
                    new SqlParameter("@NgayKyKet",SqlDbType.DateTime  ),
                    new SqlParameter("@CongTyID",SqlDbType.Int   ),
                    new SqlParameter("@CreatedBy",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@SoNha",SqlDbType.NVarChar ,20) ,
                    new SqlParameter("@TenDuong",SqlDbType.NVarChar ,50),
                    new SqlParameter("@KinhDo",SqlDbType.Float),
                    new SqlParameter("@ViDo",SqlDbType.Float)
                };
                parameters[0].Value = MaDoiTac;
                parameters[1].Value = Name;
                parameters[2].Value = Address;
                parameters[3].Value = Phones;
                parameters[4].Value = Fax;
                parameters[5].Value = Email;
                parameters[6].Value = TiLeHoaHongNoiTinh;
                parameters[7].Value = TiLeHoaHongDuongDai;
                parameters[8].Value = Notes;
                parameters[9].Value = IsActive == true ? "1" : "0";
                parameters[10].Value = MaNhanVien;
                parameters[11].Value = TenNhanVien;
                parameters[12].Value = Vung;
                parameters[13].Value = NgayKyKet;
                parameters[14].Value = CongTyID;
                parameters[15].Value = NguoiTao;
                parameters[16].Value = SoNha;
                parameters[17].Value = TenDuong;
                parameters[18].Value = KinhDo;
                parameters[19].Value = ViDo;

                rowAffected = this.RunProcedure("spInsert_T_DOITAC", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Insert_V2(string MaDoiTac, string Name, string Address, string Phones, string Fax, string Email
           , float TiLeHoaHongNoiTinh, float TiLeHoaHongDuongDai, string Notes,
           bool IsActive, string MaNhanVien, string TenNhanVien, int Vung, DateTime NgayKyKet,
           int CongTyID, string NguoiTao, string SoNha, string TenDuong, float KinhDo, float ViDo, int LoaiDoiTacID,string VietTat, int fk_Step)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@Phones",SqlDbType.VarChar,255) ,
                    new SqlParameter("@Fax",SqlDbType.Char,20) ,
                    new SqlParameter("@Email",SqlDbType.VarChar ,50) ,
                    new SqlParameter("@TiLeHoaHongNoiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@TiLeHoaHongNgoaiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@IsActive",SqlDbType.Char ,1) ,
                    new SqlParameter("@FK_MaNhanVien",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@TenNhanVien",SqlDbType.NVarChar  ,50)  , 
                    new SqlParameter("@Vung",SqlDbType.Int),
                    new SqlParameter("@NgayKyKet",SqlDbType.DateTime  ),
                    new SqlParameter("@CongTyID",SqlDbType.Int   ),
                    new SqlParameter("@CreatedBy",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@SoNha",SqlDbType.NVarChar ,20) ,
                    new SqlParameter("@TenDuong",SqlDbType.NVarChar ,50),
                    new SqlParameter("@KinhDo",SqlDbType.Float),
                    new SqlParameter("@ViDo",SqlDbType.Float),
                    new SqlParameter("@LoaiDoiTacID",SqlDbType.Int),
                    new SqlParameter("@VietTat",SqlDbType.VarChar ,10) ,
                    new SqlParameter("@FK_Step",SqlDbType.Int)
                };
                parameters[0].Value = MaDoiTac;
                parameters[1].Value = Name;
                parameters[2].Value = Address;
                parameters[3].Value = Phones;
                parameters[4].Value = Fax;
                parameters[5].Value = Email;
                parameters[6].Value = TiLeHoaHongNoiTinh;
                parameters[7].Value = TiLeHoaHongDuongDai;
                parameters[8].Value = Notes;
                parameters[9].Value = IsActive == true ? "1" : "0";
                parameters[10].Value = MaNhanVien;
                parameters[11].Value = TenNhanVien;
                parameters[12].Value = Vung;
                parameters[13].Value = NgayKyKet;
                parameters[14].Value = CongTyID;
                parameters[15].Value = NguoiTao;
                parameters[16].Value = SoNha;
                parameters[17].Value = TenDuong;
                parameters[18].Value = KinhDo;
                parameters[19].Value = ViDo;
                parameters[20].Value = LoaiDoiTacID;
                parameters[21].Value = VietTat;
                parameters[22].Value = fk_Step;
                rowAffected = this.RunProcedure("spInsert_T_DOITAC_V4", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Update du lieu don, can thiet cho cac trung ho  
        /// </summary>
        public bool Update(string MaDoiTac, string Name, string Address, string Phones, string Fax,
            string Email, float TiLeHoaHongNoiTinh, float TiLeHoaHongDuongDai, string Notes,
            bool IsActive, string MaNhanVien, string TenNhanVien, int Vung, DateTime NgayKyKet,
            DateTime NgayKetThuc, string NguoiSua, string SoNha, string TenDuong, string MaDoiTac_Old, float KinhDo, float ViDo, string VietTat)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@Phones",SqlDbType.VarChar,255) ,
                    new SqlParameter("@Fax",SqlDbType.Char,20) ,
                    new SqlParameter("@Email",SqlDbType.VarChar ,50) ,
                    new SqlParameter("@TiLeHoaHongNoiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@TiLeHoaHongNgoaiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@IsActive",SqlDbType.Char ,1) ,
                    new SqlParameter("@FK_MaNhanVien",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@TenNhanVien",SqlDbType.NVarChar  ,50)  ,
                    new SqlParameter("@Vung",SqlDbType.Int),
                    new SqlParameter("@NgayKyKet",SqlDbType.DateTime  ) ,
                    new SqlParameter("@NgayKetThuc",SqlDbType.DateTime  ) ,
                    new SqlParameter("@UpdatedBy",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@SoNha",SqlDbType.NVarChar ,20) ,
                    new SqlParameter("@TenDuong",SqlDbType.NVarChar ,50),
                    new SqlParameter("@Ma_DoiTac_Old",SqlDbType.VarChar,10),
                    new SqlParameter("@KinhDo",SqlDbType.Float),
                    new SqlParameter("@ViDo",SqlDbType.Float),
                    new SqlParameter("@VietTat",SqlDbType.VarChar,10)                
                };
                parameters[0].Value = MaDoiTac;
                parameters[1].Value = Name;
                parameters[2].Value = Address;
                parameters[3].Value = Phones;
                parameters[4].Value = Fax;
                parameters[5].Value = Email;
                parameters[6].Value = TiLeHoaHongNoiTinh;
                parameters[7].Value = TiLeHoaHongDuongDai;
                parameters[8].Value = Notes;
                parameters[9].Value = IsActive == true ? "1" : "0";
                parameters[10].Value = MaNhanVien;
                parameters[11].Value = TenNhanVien;
                parameters[12].Value = Vung;
                parameters[13].Value = NgayKyKet;
                parameters[14].Value = NgayKetThuc;
                parameters[15].Value = NguoiSua;
                parameters[16].Value = SoNha;
                parameters[17].Value = TenDuong;
                parameters[18].Value = MaDoiTac_Old;
                parameters[19].Value = KinhDo;
                parameters[20].Value = ViDo;
                parameters[21].Value = VietTat;
                rowAffected = this.RunProcedure("spUpdate_T_DOITAC", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Update: ", ex);
                return false;
            }
        }
        public bool Update_V2(string MaDoiTac, string Name, string Address, string Phones, string Fax,
            string Email, float TiLeHoaHongNoiTinh, float TiLeHoaHongDuongDai, string Notes,
            bool IsActive, string MaNhanVien, string TenNhanVien, int Vung, DateTime NgayKyKet,
            DateTime NgayKetThuc, string NguoiSua, string SoNha, string TenDuong, string MaDoiTac_Old, float KinhDo, float ViDo, int LoaiDoiTacID, string VietTat, int fk_Step)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@Phones",SqlDbType.VarChar,255) ,
                    new SqlParameter("@Fax",SqlDbType.Char,20) ,
                    new SqlParameter("@Email",SqlDbType.VarChar ,50) ,
                    new SqlParameter("@TiLeHoaHongNoiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@TiLeHoaHongNgoaiTinh",SqlDbType.Float ) ,
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255) ,
                    new SqlParameter("@IsActive",SqlDbType.Char ,1) ,
                    new SqlParameter("@FK_MaNhanVien",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@TenNhanVien",SqlDbType.NVarChar  ,50)  ,
                    new SqlParameter("@Vung",SqlDbType.Int),
                    new SqlParameter("@NgayKyKet",SqlDbType.DateTime  ) ,
                    new SqlParameter("@NgayKetThuc",SqlDbType.DateTime  ) ,
                    new SqlParameter("@UpdatedBy",SqlDbType.NVarChar ,50) ,
                    new SqlParameter("@SoNha",SqlDbType.NVarChar ,20) ,
                    new SqlParameter("@TenDuong",SqlDbType.NVarChar ,50),
                    new SqlParameter("@Ma_DoiTac_Old",SqlDbType.VarChar,10),
                    new SqlParameter("@KinhDo",SqlDbType.Float),
                    new SqlParameter("@ViDo",SqlDbType.Float),
                    new SqlParameter("@LoaiDoiTacID",SqlDbType.Int),
                    new SqlParameter("@VietTat",SqlDbType.VarChar,10),
                    new SqlParameter("@FK_Step",SqlDbType.Int)                   
                };
                parameters[0].Value = MaDoiTac;
                parameters[1].Value = Name;
                parameters[2].Value = Address;
                parameters[3].Value = Phones;
                parameters[4].Value = Fax;
                parameters[5].Value = Email;
                parameters[6].Value = TiLeHoaHongNoiTinh;
                parameters[7].Value = TiLeHoaHongDuongDai;
                parameters[8].Value = Notes;
                parameters[9].Value = IsActive == true ? "1" : "0";
                parameters[10].Value = MaNhanVien;
                parameters[11].Value = TenNhanVien;
                parameters[12].Value = Vung;
                parameters[13].Value = NgayKyKet;
                parameters[14].Value = NgayKetThuc;
                parameters[15].Value = NguoiSua;
                parameters[16].Value = SoNha;
                parameters[17].Value = TenDuong;
                parameters[18].Value = MaDoiTac_Old;
                parameters[19].Value = KinhDo;
                parameters[20].Value = ViDo;
                parameters[21].Value = LoaiDoiTacID;
                parameters[22].Value = VietTat;
                parameters[23].Value = fk_Step;
                rowAffected = this.RunProcedure("spUpdate_T_DOITAC_V4", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("Update_V2: ",ex);
                return false;
            }
        }

        public DataTable GetCacDoiTacs(string MaDoiTac)
        {
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar ,10)                    
            };
            parameters[0].Value = MaDoiTac;
            return this.RunProcedure("spSelect_T_DOITAC_V2", parameters, "tblUser").Tables[0];
        }


        public DataTable GetCacDoiTacs_LastUpdate(DateTime LastUpdate)
        {
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@LastUpdate",SqlDbType.DateTime)                    
            };
            parameters[0].Value = LastUpdate;

            return this.RunProcedure("SP_T_DOITAC_GetLastUpdate", parameters, "tblDOITAC").Tables[0];
        }

        public DataTable GetDSDoiTacs(bool isActive)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@isActive",SqlDbType.Bit)                    
                };
            parameters[0].Value = isActive;

            return this.RunProcedure("SP_T_DOITAC_ISACTIVE", parameters, "tblDOITAC").Tables[0];
        }

        public DataTable GetCacDoiTacs_NAME()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            return this.RunProcedure("SP_DOITAC_SELECT_ALL_NAME", parameters, "tblDoiTac").Tables[0];
        }

        public bool Delete(string MaDoiTac)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar ,10)
                };
                parameters[0].Value = MaDoiTac;
                rowAffected = this.RunProcedure("spDelete_T_DOITAC", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Active(string MaDoiTac, bool isActive, string NguoiSua)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar ,10),
                    new SqlParameter("@IsActive",SqlDbType.Bit),
                    new SqlParameter("@UpdateBy",SqlDbType.NVarChar,50)
                };
                parameters[0].Value = MaDoiTac;
                parameters[1].Value = isActive;
                parameters[2].Value = NguoiSua;
                rowAffected = this.RunProcedure("spActive_T_DOITAC", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetNextMaDoiTac(int CongTyID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar ,10),
                    new SqlParameter("@CongTyID",SqlDbType.Int) 
                };
                parameters[0].Value = string.Empty;
                parameters[0].Direction = ParameterDirection.Output;
                parameters[1].Value = CongTyID;

                rowAffected = this.RunProcedure("spGetMaxKey_T_DOITAC", parameters, rowAffected);

                return parameters[0].Value.ToString();
            }
            catch (Exception e)
            {
                return string.Empty;// Loi chung tring phai a Phong
            }
        }

        public DataTable GetDoiTacByOPhoneNumber(string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11)                    
                };
            parameters[0].Value = PhoneNumber;

            return this.RunProcedure("sp_T_DOITAC_SelectByPhoneNumber", parameters, "tblUser").Tables[0];
        }
        /// <summary>
        /// get mot so dien thoai khong cung mã với số hiện tại đâng sửa chữa
        /// </summary>
        public DataTable GetDoiTacByOPhoneNumber_KhongCungMa(string MaDoiTac, string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar,10)  ,    
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11)                    
                };
            parameters[0].Value = MaDoiTac;
            parameters[1].Value = PhoneNumber;

            return this.RunProcedure("sp_T_DOITAC_SelectByPhoneNumber_KhongCungMa", parameters, "tblUser").Tables[0];
        }

        public DataTable GetDoiTacs(string strSQL)
        {
            return RunSQL(strSQL, "tblDoiTac");
        }
        public DataTable GetDoiTacs_V2(int KieuTimKiem, string ThongTinTimKiem)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                  new SqlParameter("@KieuTimKiem",SqlDbType.Int)  ,    
                    new SqlParameter("@ThongTinTimKiem",SqlDbType.NVarChar,255)                    
                };
            parameters[0].Value = KieuTimKiem;
            parameters[1].Value = ThongTinTimKiem;

            return this.RunProcedure("sp_T_DOITAC_Search", parameters, "tblDoiTac").Tables[0];
        }

        public DataTable GetListOfDoiTacs_ByNhanVien(string MaNhanVien)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaNhanVien",SqlDbType.NVarChar,50)                    
                };
            parameters[0].Value = MaNhanVien;

            return this.RunProcedure("sp_T_DOITAC_SelectByMaNhanVien", parameters, "tblUser").Tables[0];
        }


        /// <summary>
        /// hàm tra về dữ liệu của so chuyến của đối tác theo thang trong nam
        /// D0001  10  245  (Độ dài của xe đón - đổi ra số chuyến = 245+1/4
        /// D0001  11  245
        /// D0001  12  245
        /// SELECT :  MaDoiTac,  Thang,  TongDoDaiXeDon
        /// </summary>
        public DataTable GetSoChuyenCuaDoiTacTrongThangCuaNam(int Year)
        {

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Year",SqlDbType.Int)                    
                };
            parameters[0].Value = Year;

            return this.RunProcedure("sp_T_DOITAC_SelectSoChuyenCuaThang_ByYear", parameters, "tblUser").Tables[0];
        }

        public void CapNhatDuLieu()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {                                    
                };
                rowAffected = this.RunProcedure("[MOIGIOI.CapNhatCacCuocGoiMoiGioi]", parameters, rowAffected);

            }
            catch (Exception e)
            {

            }
        }

        public string GetNextMaDoiTac_v3(string MaMG_Group)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Ma_DoiTac_Group",SqlDbType.VarChar ,10),
                    new SqlParameter("@Ma_DoiTac",SqlDbType.VarChar ,10) 
                };
                parameters[0].Value = MaMG_Group;
                parameters[1].Direction = ParameterDirection.Output;

                rowAffected = this.RunProcedure("spSelect_T_DOITAC_MaMG_Group", parameters, rowAffected);

                return parameters[1].Value.ToString();
            }
            catch (Exception e)
            {
                return string.Empty;// Loi chung tring phai a Phong
            }
        }
    }
}
