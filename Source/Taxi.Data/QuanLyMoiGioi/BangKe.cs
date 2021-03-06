using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Collections;

namespace Taxi.Data
{
    public class  BangKe : DBObject
    {
        public string ConnectString;
        public BangKe()
        {
            ConnectString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
        }
        /// <summary>
        /// Lấy danh sách bảng kê
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="TenDoiTac"></param>
        /// <param name="TenCongTy"></param>
        /// <param name="XeDon"></param>
        /// <param name="NgayDonTu"></param>
        /// <param name="NgayDonDen"></param>
        /// <returns></returns>
        public DataTable GetDSBangKe(string MaDoiTac , string TenDoiTac, string MaCongTy, string XeDon, DateTime NgayDonTu, DateTime NgayDonDen)
        { 
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaDoiTac",SqlDbType.VarChar, 10),
                    new SqlParameter("@TenDoiTac",SqlDbType.NVarChar, 50),
                    new SqlParameter("@MaCongTy",SqlDbType.NVarChar, 50),
                    new SqlParameter("@XeDon",SqlDbType.VarChar, 200),
                    new SqlParameter("@NgayDonTu",SqlDbType.DateTime),
                    new SqlParameter("@NgayDonDen",SqlDbType.DateTime) 
                };
            if (MaDoiTac != "0")
                parameters[0].Value = MaDoiTac;
            if (TenDoiTac != "")
                parameters[1].Value = TenDoiTac;
            if (MaCongTy != "0")
                parameters[2].Value = MaCongTy;
            if (XeDon != "")
                parameters[3].Value = XeDon;
                parameters[4].Value = NgayDonTu;
                parameters[5].Value = NgayDonDen;

            return this.RunProcedure("SP_MOIGIOI_T_BANGKECUOC_SEARCH", parameters, "tblDSBangKe").Tables[0];
        }

        public DataTable GetDoiTac()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            return this.RunProcedure("T_DOITAC_GETALL", parameters, "tblDoiTac").Tables[0];
        }

        public DataTable GetBangKe(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt)                    
                };
            parameters[0].Value = ID;

            return this.RunProcedure("SP_MOIGIOI_T_BANGKECUOC_GET_BY_ID", parameters, "tblDoiTac").Tables[0];
        }

        public bool Insert(int FK_CongTyID, string FK_MaDoiTac, string DSXeDon, string CreatedBy, DateTime NgayDon)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@FK_CongTyID",SqlDbType.Int),
                    new SqlParameter("@FK_MaDoiTac",SqlDbType.VarChar,6),
                    new SqlParameter("@DSXeDon",SqlDbType.VarChar,200) ,
                    new SqlParameter("@CreatedBy",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@NgayDon",SqlDbType.DateTime) };

                parameters[0].Value = FK_CongTyID;
                parameters[1].Value = FK_MaDoiTac;
                parameters[2].Value = DSXeDon;
                parameters[3].Value = CreatedBy;
                parameters[4].Value = NgayDon;

                rowAffected = this.RunProcedure("SP_MOIGIOI_T_BANGKECUOC_INSERT", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(int ID,int FK_CongTyID, string FK_MaDoiTac, string DSXeDon, string UpdateBy, DateTime NgayDon)
        {
            try
            {


                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt),
                    new SqlParameter("@FK_CongTyID",SqlDbType.Int),
                    new SqlParameter("@FK_MaDoiTac",SqlDbType.VarChar,10),
                    new SqlParameter("@DSXeDon",SqlDbType.VarChar,200) ,
                    new SqlParameter("@UpdateBy",SqlDbType.NVarChar,50) ,
                    new SqlParameter("@NgayDon",SqlDbType.DateTime) };

                parameters[0].Value = ID;
                parameters[1].Value = FK_CongTyID;
                parameters[2].Value = FK_MaDoiTac;
                parameters[3].Value = DSXeDon;
                parameters[4].Value = UpdateBy;
                parameters[5].Value = NgayDon;

                rowAffected = this.RunProcedure("SP_MOIGIOI_T_BANGKECUOC_UPDATE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.BigInt),
                    };
                parameters[0].Value = ID;
                rowAffected = this.RunProcedure("SP_MOIGIOI_T_BANGKECUOC_DELETE", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách cuốc khách mô giới theo bảng kê
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="MaCongTy"></param>
        /// <param name="NgayDonTu"></param>
        /// <param name="NgayDonDen"></param>
        /// <returns></returns>
        public DataTable BaoCaoCuocKhachMoGioi_BangKe(string MaDoiTac,string MaCongTy,DateTime NgayDonTu, DateTime NgayDonDen)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaKH",SqlDbType.VarChar, 10),
                    new SqlParameter("@MaCongTy",SqlDbType.VarChar, 6),
                    new SqlParameter("@NgayDonTu",SqlDbType.DateTime),
                    new SqlParameter("@NgayDonDen",SqlDbType.DateTime) 
                };
            if (MaDoiTac != "0")
                parameters[0].Value = MaDoiTac;
            if (MaCongTy != "0")
                parameters[1].Value = MaCongTy;
            parameters[2].Value = NgayDonTu;
            parameters[3].Value = NgayDonDen;

            return this.RunProcedure("SP_BAOCAO_CUOCKHACH_MOIGIOI_BANGKE", parameters, "tblDSBangKe").Tables[0];
        }

        /// <summary>
        /// Bao cao tong hop moi gioi goi qua trung tam
        /// </summary>
        /// <param name="NgayDonTu"></param>
        /// <param name="NgayDonDen"></param>
        /// <returns></returns>
        public DataTable BCTHMoiGioi_TT(DateTime NgayDonTu, DateTime NgayDonDen)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayDonTu",SqlDbType.DateTime),
                    new SqlParameter("@NgayDonDen",SqlDbType.DateTime) 
                };
            parameters[0].Value = NgayDonTu;
            parameters[1].Value = NgayDonDen;

            return this.RunProcedure("V3_SP_BAOCAO_TONGHOP_MOIGIOI_GOIQUA_TT", parameters, "tblDSBaoCao").Tables[0];
        }

        /// <summary>
        /// Bao cao chi tiet cuoc khach moi gioi theo dia chi
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="MaCongTy"></param>
        /// <param name="NgayDonTu"></param>
        /// <param name="NgayDonDen"></param>
        /// <returns></returns>
        public DataTable BaoCaoChiTietCuocKhachMoGioi_DiaChi(string MaDoiTac, string MaCongTy, DateTime NgayDonTu, DateTime NgayDonDen)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaKH",SqlDbType.VarChar, 10),
                    new SqlParameter("@CongTyID",SqlDbType.VarChar, 6),
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),
                    new SqlParameter("@DenNgay",SqlDbType.DateTime) 
                };
            if (MaDoiTac != "0")
                parameters[0].Value = MaDoiTac;
            if (MaCongTy != "0")
                parameters[1].Value = MaCongTy;
            parameters[2].Value = NgayDonTu;
            parameters[3].Value = NgayDonDen;

            return this.RunProcedure("[MOIGIOI.BC_CHITIET_CUOCKHACH_MG_DIACHI]", parameters, "tblBaoCao").Tables[0];
        }

        /// <summary>
        /// Báo cáo kết quả điều hành theo đơn vị
        /// </summary>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <returns></returns>
        public DataTable GetBaoCao_KQDieuHanh_DV(DateTime TuNgayGio, DateTime DenNgayGio,bool filter)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@NgayDonTu",SqlDbType.DateTime),
                    new SqlParameter("@NgayDonDen",SqlDbType.DateTime),
                    new SqlParameter("@GroupBy",SqlDbType.Bit)
                };
            parameters[0].Value = TuNgayGio;
            parameters[1].Value = DenNgayGio;
            parameters[2].Value = filter;
            return this.RunProcedure("SP_BAOCAO_KETQUA_DIEUHANH_DONVI", parameters, "BaoCao_KQDH_DonVi").Tables[0];
        }

        //=========================================Tỷ lệ phân bổ =======================================
       //hangtm sửa 17/7/2011
        public bool Insert_TyLePhanBo(DataTable dtTiLePhanBo)
        {
            //SqlTransaction trans = myConnection.BeginTransaction();
            try
            {
                DataSet dsReturn;
                ArrayList arrlstPara = new ArrayList(); //Init an ArrayList contain Paramaters
                if (dtTiLePhanBo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTiLePhanBo.Rows.Count; i++)
                    {
                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@FK_CongTyID",SqlDbType.Int),
                            new SqlParameter("@TiLePhanBo",SqlDbType.Float)};

                        parameters[0].Value = dtTiLePhanBo.Rows[i]["FK_CongTyID"];
                        parameters[1].Value = dtTiLePhanBo.Rows[i]["TiLePhanBo"];

                        arrlstPara.Add(parameters);
                        //this.RunProcedure("SP_T_CONGTY_TILEPHANBO_INSERT", parameters, "dtTiLePhanBo");
                    }
                   
                }
                //trans.Commit();
                this.RunListProcedure("SP_T_CONGTY_TILEPHANBO_INSERT", arrlstPara, "dtTiLePhanBo");
                return true;
            }
            catch (Exception e)
            {
                //trans.Rollback();
                return false;
            }
        }
        //hangtm sửa 17/7/2011
        public bool Update_TyLePhanBo(DataTable dtTiLePhanBo)
        {
            //SqlTransaction trans = myConnection.BeginTransaction();
            try
            {
                DataSet dsReturn;
                ArrayList arrlstPara = new ArrayList(); //Init an ArrayList contain Paramaters
                if (dtTiLePhanBo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTiLePhanBo.Rows.Count; i++)
                    {
                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@FK_CongTyID",SqlDbType.Int),
                            new SqlParameter("@TiLePhanBo",SqlDbType.Float)};

                        parameters[0].Value = dtTiLePhanBo.Rows[i]["FK_CongTyID"];
                        parameters[1].Value = dtTiLePhanBo.Rows[i]["TiLePhanBo"];

                        arrlstPara.Add(parameters);
                        //this.RunProcedure("SP_T_CONGTY_TILEPHANBO_UPDATE", parameters , "dtTiLePhanBo");
                    }
                }
                //trans.Commit();
                this.RunListProcedure("SP_T_CONGTY_TILEPHANBO_UPDATE", arrlstPara, "dtTiLePhanBo");
                return true;
            }
            catch (Exception e)
            {
                //trans.Rollback();
                return false;
            }
        }

        public DataTable GetTiLePhanBo()
        {
            SqlParameter[] parameters = new SqlParameter[] {                   
                };

            return this.RunProcedure("SP_T_CONGTY_TILEPHANBO_GETALL", parameters, "dtTiLePhanBo").Tables[0];
        }
    }
}
