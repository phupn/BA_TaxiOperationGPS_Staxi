using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;
namespace Taxi.Data.BaoCao
{
     public class DoiTac :DBObject 
    {
        //bang doi tac
         private string SP_DOITAC_BAOCAO_DIACHI_MOIGIOI = "SP_T_DOITAC_REPORT";
        private string SP_DOITAC_SELECT_ALLNAME = "[SP_DOITAC_SELECT_ALL_NAME]";
        private string SP_CONGTY_SELECT_ALL_NAME = "SP_CONGTY_SELECT_ALL_NAME";
         private string SP_BAOCAO_MOIGIOI_CUOCGOITHAP = "SP_DOITAC_BAOCAO_MOIGIOI_CUOCGOITHAP";

        /// <summary>
        /// lay ra ma doi tac
        /// </summary>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      26/5/2011   created
        /// </modified>
        public DataTable GetAllDoiTacID()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameter = new SqlParameter[] { };
            
            ds = this.RunProcedure(SP_DOITAC_SELECT_ALLNAME, parameter, "tblDoiTac");
            return ds.Tables[0];
        }
        /// <summary>
        /// lay ra ten cong ty
        /// </summary>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      26/5/2011   created
        /// </modified>
        public DataTable GetCongTyName()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameter = new SqlParameter[] { };

            ds = this.RunProcedure(SP_CONGTY_SELECT_ALL_NAME, parameter, "tblCongTy");
            return ds.Tables[0];
        }
        /// <summary>
        /// baó cáo danh sách địac chỉ môi giới
        /// </summary>
        /// <param name="maMoiGioi"></param>
        /// <param name="dienThoai"></param>
        /// <param name="congTy"></param>
        /// <param name="ngayBDTu"></param>
        /// <param name="ngayBDDen"></param>
        /// <param name="ngayKTTu"></param>
        /// <param name="ngayKTDen"></param>
        /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      26/5/2011   created
        /// </modified>
        public DataTable GetBaoCaoDiaChiMoiGioi(string maMoiGioi, string dienThoai, int congTy, DateTime ngayBDTu,
                DateTime ngayBDDen, DateTime ngayKTTu, DateTime ngayKTDen,string tenDuong, string diaChi)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@MaMoiGioi",SqlDbType.VarChar ,6),
                new SqlParameter("@DienThoai",SqlDbType.VarChar,255),
                new SqlParameter("@CongTy",SqlDbType.Int),
                new SqlParameter("@NgayBDTu",SqlDbType.DateTime ),
                new SqlParameter("@NgayBDDen",SqlDbType.DateTime ),
                new SqlParameter("@NgayKTTu",SqlDbType.DateTime ),
                new SqlParameter("@NgayKTDen",SqlDbType.DateTime ),
                new SqlParameter ("@TenDuong",SqlDbType.NVarChar ,50),
                new SqlParameter ("@DiaChi",SqlDbType.NVarChar ,255)
            };

            if (maMoiGioi != string.Empty) parameters[0].Value = maMoiGioi;

            if (dienThoai != string.Empty) parameters[1].Value = dienThoai;

            if (congTy != 0) parameters[2].Value = congTy;

            if (ngayBDTu != DateTime.MinValue) parameters[3].Value = ngayBDTu;

            if (ngayBDDen != DateTime.MinValue) parameters[4].Value = ngayBDDen;

            if (ngayKTTu != DateTime.MinValue) parameters[5].Value = ngayKTTu;

            if (ngayKTDen != DateTime.MinValue) parameters[6].Value = ngayKTDen;

            if (tenDuong != string.Empty) parameters[7].Value = tenDuong;

            if (diaChi != string.Empty) parameters[8].Value = diaChi;

            ds = this.RunProcedure(SP_DOITAC_BAOCAO_DIACHI_MOIGIOI, parameters, "tblDoiTac");
            return ds.Tables[0];
        }
         /// <summary>
         /// báo cáo địa chỉ môi giới cuộc gọi thấp
         /// </summary>
         /// <param name="maMoiGioi"></param>
         /// <param name="congTy"></param>
         /// <param name="soCuocDonDuoc"></param>
         /// <param name="ngayBatDau"></param>
         /// <param name="ngayKetThuc"></param>
         /// <returns></returns>
        ///  <modified>
        /// name        date        comments
        /// hangtm      28/5/2011   created
        /// </modified>
         public DataTable GetBaoCaoMoiGioi_CuocGoiThap(string maMoiGioi,int congTy, int soCuocDonDuoc,DateTime ngayBatDau, DateTime ngayKetThuc)
         {
             DataSet ds = new DataSet();
             SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@ThoiGianBD", SqlDbType.DateTime ),
                 new SqlParameter ("@ThoiGianKT", SqlDbType.DateTime),
                 new SqlParameter ("@MaMoiGioi", SqlDbType.VarChar,10),
                 new SqlParameter ("@CongTy", SqlDbType.Int),
                 new SqlParameter ("@SoCuocDonDuoc", SqlDbType.Int)
             };
             if (ngayBatDau != DateTime.MinValue) parameters[0].Value = ngayBatDau;
             if (ngayKetThuc != DateTime.MinValue) parameters[1].Value = ngayKetThuc;
             if(maMoiGioi != string.Empty ) parameters[2].Value = maMoiGioi ;
             if (congTy != 0) parameters[3].Value = congTy;
             if ((soCuocDonDuoc >= 0)|| (soCuocDonDuoc.ToString() == string.Empty )) parameters[4].Value = soCuocDonDuoc;
            

             ds = this.RunProcedure(SP_BAOCAO_MOIGIOI_CUOCGOITHAP, parameters, "tblMoiGioiSoLuong");
             return ds.Tables[0];
         }

         public DataTable GetBaoCaoMoiGioi_KoPhatSinh(DateTime ngayBatDau, DateTime ngayKetThuc)
         {
             DataSet ds = new DataSet();
             SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@ThoiGianBD", SqlDbType.DateTime ),
                 new SqlParameter ("@ThoiGianKT", SqlDbType.DateTime)
             };
             parameters[0].Value = ngayBatDau;
             parameters[1].Value = ngayKetThuc;

             ds = this.RunProcedure("SP_DOITAC_BAOCAO_MOIGIOI_KOPHATSINH", parameters, "tblMoiGioiSoLuong");
             return ds.Tables[0];
         }

         public DataSet GetBaoCaoMoiGioi_PhatSinhTheoXe(string maMoiGioi, string soxe, DateTime ngayBatDau, DateTime ngayKetThuc, int Type)
         {
             SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter ("@ThoiGianBD", SqlDbType.DateTime ),
                 new SqlParameter ("@ThoiGianKT", SqlDbType.DateTime),
                 new SqlParameter ("@MaMoiGioi", SqlDbType.VarChar,10),
                 new SqlParameter ("@SoXe", SqlDbType.VarChar,10),
                 new SqlParameter ("@Type", SqlDbType.TinyInt)
             };
             parameters[0].Value = ngayBatDau;
             parameters[1].Value = ngayKetThuc;
             parameters[2].Value = maMoiGioi;
             parameters[3].Value = soxe;
             parameters[4].Value = Type;

             return this.RunProcedure("SP_DOITAC_BAOCAO_MOIGIOI_CUOCGOIPHATSINH_THEOXE", parameters, "tblMoiGioiSoLuong");
         }

    }

}
