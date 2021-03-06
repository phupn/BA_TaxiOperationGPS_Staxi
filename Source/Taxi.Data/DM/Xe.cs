using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
    public class Xe : DBObject
    {

        public DataTable GetTatCaCacXe()
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_SoHieuXe",SqlDbType.VarChar ,4)                    
                };
            parameters[0].Value = string.Empty; ;

            return this.RunProcedure("sp_T_DMXE_Select", parameters, "tbXe").Tables[0];
        }

        public DataTable GetChiTietMotXe(string SoHieuXe)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_SoHieuXe",SqlDbType.VarChar ,4)                    
                };
            parameters[0].Value = SoHieuXe;

            return this.RunProcedure("sp_T_DMXE_Select", parameters, "tblXe").Tables[0];
        }
        public bool Delete(string SoHieuXe)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_SoHieuXe",SqlDbType.VarChar ,4)                    
                };
                parameters[0].Value = SoHieuXe;

                rowAffected = this.RunProcedure("sp_T_DMXE_Delete", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //   [PK_SoHieuXe]
        //  ,[BienKiemSoat]
        //  ,[SoMay]
        //  ,[SoKhung]
        //  ,LoaiXe
        /// <summary>
        /// chen vao mot thong tin cua xe
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="BienKiemSoat"></param>
        /// <param name="SoMay"></param>
        /// <param name="LoaiXe">4,7 (4 cho, 7 cho)</param>
        /// <returns></returns>
        //   [PK_SoHieuXe]
        //  ,[BienKiemSoat]
        //  ,[SoMay]
        //  ,[SoKhung]
        //  ,LoaiXe
        /// <summary>
        /// chen vao mot thong tin cua xe
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="BienKiemSoat"></param>
        /// <param name="SoMay"></param>
        /// <param name="LoaiXe">4,7 (4 cho, 7 cho)</param>
        /// <returns></returns>
        public bool Insert(string SoHieuXe, string BienKiemSoat, string SoMay, string SoKhung, int LoaiXeID, int GaraID, int SoCho)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_SoHieuXe",SqlDbType.VarChar,4),
                    new SqlParameter("@BienKiemSoat",SqlDbType.VarChar ,10),
                    new SqlParameter("@SoMay",SqlDbType.VarChar ,20) ,
                    new SqlParameter("@SoKhung",SqlDbType.VarChar,20) ,
                    new SqlParameter("@FK_LoaiXeID",SqlDbType.Int),
                    new SqlParameter("@GaraID",SqlDbType.Int),
                    new SqlParameter("@SoCho",SqlDbType.Int) };

                parameters[0].Value = SoHieuXe;
                parameters[1].Value = BienKiemSoat;
                parameters[2].Value = SoMay;
                parameters[3].Value = SoKhung;
                parameters[4].Value = LoaiXeID;
                parameters[5].Value = GaraID;
                parameters[6].Value = SoCho;

                rowAffected = this.RunProcedure("sp_T_DMXE_Insert", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string SoHieuXe, string BienKiemSoat, string SoMay, string SoKhung, int LoaiXeID, int GaraID, int SoCho)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PK_SoHieuXe",SqlDbType.VarChar,4),
                    new SqlParameter("@BienKiemSoat",SqlDbType.VarChar ,10),
                    new SqlParameter("@SoMay",SqlDbType.VarChar ,20) ,
                    new SqlParameter("@SoKhung",SqlDbType.VarChar,20) ,
                    new SqlParameter("@FK_LoaiXeID",SqlDbType.Int)  ,
                    new SqlParameter("@GaraID",SqlDbType.Int),
                    new SqlParameter("@SoCho",SqlDbType.Int)
                };
                parameters[0].Value = SoHieuXe;
                parameters[1].Value = BienKiemSoat;
                parameters[2].Value = SoMay;
                parameters[3].Value = SoKhung;
                parameters[4].Value = LoaiXeID;
                parameters[5].Value = GaraID;
                parameters[6].Value = SoCho;

                rowAffected = this.RunProcedure("sp_T_DMXE_Update", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                throw e;
                //return false;
            }
        }




        #region -------New v3-----------
        /// <summary>
        /// Danh sách Mã loại xe GPS ứng với Nhóm xe
        /// </summary>
        /// <param name="NhomXe"></param>
        /// <returns></returns>
        public DataTable LayDanhSachLoaiXe_GPS(string NhomXe)
        {
            SqlParameter[] arrPara = { new SqlParameter("@NhomXe", SqlDbType.NVarChar, 50) };
            arrPara[0].Value = NhomXe;

            return RunProcedure("SP_T_TUDIEN_LOAIXE_SELECT_IDGPS", arrPara, "tbLoaiXe").Tables[0];
        }

        /// <summary>
        /// Danh sách Mã loại xe GPS mặc định ứng với kênh
        /// </summary>
        /// <param name="kenh"></param>
        /// <returns>12,23,34,45</returns>
        public string LayDanhSachLoaiXe_GPS_Kenh(string kenh)
        {
            SqlParameter[] arrPara = { new SqlParameter("@Kenh", SqlDbType.VarChar, 2),
                                        new SqlParameter("@DSXe", SqlDbType.VarChar, 50)};
            arrPara[0].Value = kenh;
            arrPara[1].Direction = ParameterDirection.Output;

            this.RunProcedure("SP_T_KENH_LOAIXE_SELECT_IDGPS", arrPara);
            if (arrPara[1].Value != null)
                return arrPara[1].Value.ToString();
            else
                return "";
        }

        public DataTable GetDS_SHXe()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            return this.RunProcedure("sp_T_DMXE_Select_SHXe", parameters, "tbXe").Tables[0];
        }
        #endregion

    }
}
