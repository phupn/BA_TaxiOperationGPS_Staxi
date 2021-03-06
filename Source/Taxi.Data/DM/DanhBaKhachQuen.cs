using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class DanhBaKhachQuen : DBObject
    {

        public DanhBaKhachQuen()
            : base()
        {

        }
        /// <summary>
        /// Insert mot doi tuong vao database
        /// </summary>
        /// <param name="PhoneNumber">so dien thoai</param>
        /// <param name="Name">ten nguoi</param>
        /// <param name="Address">dia chi</param>
        /// <returns></returns>
        public bool Insert(string maKH
                                , string phoneNumber
                                , string name
                                , string address
                                , DateTime birthday
                                , string email
                                , string fax
                                , bool isActive
                                , string notes
                                , int rank
                                , int type)
        {
            
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Phones",SqlDbType.VarChar,255),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255),
                    new SqlParameter("@Birthday",SqlDbType.DateTime),
                    new SqlParameter("@Email",SqlDbType.VarChar,50),
                    new SqlParameter("@Fax",SqlDbType.VarChar,10),
                    new SqlParameter("@IsActive",SqlDbType.Bit),
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255),
                    new SqlParameter("@Rank",SqlDbType.TinyInt),
                    new SqlParameter("@Type",SqlDbType.TinyInt),
                    new SqlParameter("@MaKH",SqlDbType.VarChar,10)
                };
                parameters[0].Value = phoneNumber;
                parameters[1].Value = name;
                parameters[2].Value = address;
                parameters[3].Value = birthday;
                parameters[4].Value = email;
                parameters[5].Value = fax;
                parameters[6].Value = isActive;
                parameters[7].Value = notes;
                parameters[8].Value = rank;
                parameters[9].Value = type;
                parameters[10].Value = maKH;

                rowAffected = this.RunProcedure("V3_SP_T_DMKHACHANG_INSERT", parameters, rowAffected);
                return (rowAffected > 0);
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}
        }


        public bool Update(string maKH
                                , string phoneNumber
                                , string name
                                , string address
                                , DateTime birthday
                                , string email
                                , string fax
                                , bool isActive
                                , string notes
                                , int rank
                                , int type)
        {
            //try
            //{
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Phones",SqlDbType.VarChar,255),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255),
                    new SqlParameter("@Birthday",SqlDbType.DateTime),
                    new SqlParameter("@Email",SqlDbType.VarChar,50),
                    new SqlParameter("@Fax",SqlDbType.VarChar,10),
                    new SqlParameter("@IsActive",SqlDbType.Bit),
                    new SqlParameter("@Notes",SqlDbType.NVarChar,255),
                    new SqlParameter("@Rank",SqlDbType.TinyInt),
                    new SqlParameter("@Type",SqlDbType.TinyInt),
                    new SqlParameter("@MaKH",SqlDbType.VarChar,10),
                };
                parameters[0].Value = phoneNumber;
                parameters[1].Value = name;
                parameters[2].Value = address;
                parameters[3].Value = birthday;
                parameters[4].Value = email;
                parameters[5].Value = fax;
                parameters[6].Value = isActive;
                parameters[7].Value = notes;
                parameters[8].Value = rank;
                parameters[9].Value = type;
                parameters[10].Value = maKH;

                rowAffected = this.RunProcedure("V3_SP_T_DMKHACHANG_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// Get thong tin cua mot so dien thoai
        /// If PhoneNumber= rong thi lay tat ca
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public DataTable GetAddress_Phones(string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Phones",SqlDbType.VarChar ,255)                    
                };
            parameters[0].Value = PhoneNumber;

            return this.RunProcedure("V3_SP_T_DMKHACHANG_GET_ADDRESS_BY_PHONES", parameters, "tblKhachHang").Tables[0];
        
        }
        public DataTable GetAll()
        {
            SqlParameter[] parameters = new SqlParameter[] {};

            return this.RunProcedure("V3_SP_T_DMKHACHANG_GETALL", parameters, "tblKhachHang").Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetDanhBaKhachQuen_ID(string maKH)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaKH",SqlDbType.VarChar,10)                    
                };
            if (!string.IsNullOrEmpty(maKH))
            {
                parameters[0].Value = maKH;
            }

            return this.RunProcedure("V3_SP_T_DMKHACHANG_GET_ID", parameters, "tblKhachHang").Tables[0];
        }

        public DataTable GetDanhBaKhachQuen_Phones(string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Phones",SqlDbType.VarChar,10)                    
                };
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                parameters[0].Value = PhoneNumber;
            }

            return this.RunProcedure("V3_SP_T_DMKHACHANG_GET_PHONES", parameters, "tblKhachHang").Tables[0];
        }

        public DataTable GetDanhBaKhachQuen_Phones_Search(string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Phones",SqlDbType.VarChar,10)                    
                };
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                parameters[0].Value = PhoneNumber;
            }

            return this.RunProcedure("V3_SP_T_DMKHACHANG_SEARCH_PHONES", parameters, "tblKhachHang").Tables[0];
        }

        public DataTable GetDanhBaKhachQuen_Search(string PhoneNumber, string TenKH, string DiaChi)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Phones",SqlDbType.VarChar,20),
                    new SqlParameter("@TenKH",SqlDbType.VarChar,50),
                    new SqlParameter("@DiaChi",SqlDbType.VarChar,200)
                };
            if (!string.IsNullOrEmpty(PhoneNumber))
                parameters[0].Value = PhoneNumber;
            if (!string.IsNullOrEmpty(TenKH))
                parameters[1].Value = TenKH;
            if (!string.IsNullOrEmpty(DiaChi))
                parameters[2].Value = DiaChi;

            return this.RunProcedure("V3_SP_T_DMKHACHANG_SEARCH", parameters, "tblKhachHang").Tables[0];
        }


        public bool Delete(string maKH)
        {
            //try
            //{
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaKhach",SqlDbType.VarChar,10)                                  
                };
                parameters[0].Value = maKH;
                rowAffected = this.RunProcedure("V3_SP_T_DMKHACHANG_DELETE", parameters, rowAffected);
                return (rowAffected > 0);
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

        public DataTable GetKhachQuens(string strSQL)
        {
            return RunSQL(strSQL, "tblKhachao");
        }


        #region Loại khách hàng
        public DataTable GetDanhBaKhachQuen_Type_ID(string ID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.TinyInt)                    
                };
            if (!string.IsNullOrEmpty(ID))
            {
                parameters[0].Value = ID;
            }

            return this.RunProcedure("V3_SP_T_DMKHACHANG_TYPE_GET_ID", parameters, "tblKhachHang").Tables[0];
        }
        #endregion


        #region Xếp hạng khách hàng
        public DataTable GetDanhBaKhachQuen_Rank_ID(string ID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.TinyInt)                    
                };
            if (!string.IsNullOrEmpty(ID))
            {
                parameters[0].Value = ID;
            }

            return this.RunProcedure("V3_SP_T_DMKHACHANG_RANK_GET_ID", parameters, "tblKhachHang").Tables[0];
        }
        #endregion

        public bool CapNhatTrangThaiGoiChoKhach(string maKhachHang, byte trangThaiGoi, string ghiChu)
        {
            try
            {


                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaKH",SqlDbType.VarChar,10),
                    new SqlParameter("@TrangThaiGoi",SqlDbType.TinyInt),
                    new SqlParameter("@GhiChu",SqlDbType.NVarChar,255) 
                     
                };
                parameters[0].Value = maKhachHang;
                parameters[1].Value = trangThaiGoi;
                parameters[2].Value = ghiChu;

                rowAffected = this.RunProcedure("spT_DMKHACHHANG_CALL_Insert", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable GetKhachQuens_LastUpdate(DateTime LastUpdate)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LastUpdate",SqlDbType.DateTime)
                };

            parameters[0].Value = LastUpdate;

            return this.RunProcedure("V3_SP_T_DMKHACHANG_GETBYDATE", parameters, "tblKhachHang").Tables[0];
        }

        public DataTable GetKhachQuens(DateTime tuNgay, DateTime denNgay)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime) ,
                    new SqlParameter("@DenNgay",SqlDbType.DateTime)   
                };

            parameters[0].Value = tuNgay;
            parameters[1].Value = denNgay;

            return this.RunProcedure("spT_DMKHACHHANG_GetDaGoiKhachHangThanThiet", parameters, "tblKhachHang").Tables[0];
        }
        /// <summary>
        /// lấy ra giá trị lớn nhất của mã KH
        /// </summary>
        /// <returns></returns>
        public int GetMaKH()
        {
            int maxMaKH = 0;
            string sql = " SELECT MAX( CONVERT(INT,[MaKH]))MaxMaKH FROM  [T_DMKHACHHANG] WHERE    MaKH IS NOT NULL AND LEN(maKH)>0 ";
            DataTable dt = this.RunSQL(sql, "tab1");

            if (dt == null || dt.Rows.Count <= 0)
                return maxMaKH;
            try
            {
                maxMaKH = int.Parse(dt.Rows[0]["MaxMaKH"].ToString());
            }
            catch (Exception ex)
            {
                maxMaKH = 0;
            }
            return maxMaKH;
        }
    }
}
