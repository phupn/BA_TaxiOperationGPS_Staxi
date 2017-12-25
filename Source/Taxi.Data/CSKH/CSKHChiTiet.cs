using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class CSKHChiTiet : DBObject 
    {
        public DataTable GetBCCSKHChiTiet(DateTime TuNgay, DateTime DenNgay, string Vung, int SoLanGoiLai)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TuNgay",SqlDbType.DateTime),     
                     new SqlParameter("@DenNgay",SqlDbType.DateTime),
                     new SqlParameter("@Vungs",SqlDbType.VarChar,50),
                     new SqlParameter("@SoLanKhachGoiLai",SqlDbType.Int)
                };
            parameters[0].Value = TuNgay;
            parameters[1].Value = DenNgay;
            parameters[2].Value = Vung;
            parameters[3].Value = SoLanGoiLai;
            return this.RunProcedure("[CSKH.BaoCaoCSKHChiTiet]", parameters, "tblCSKH").Tables[0];
        }
        /// <summary>
        /// Hàm trả về dữ liệu chi tiết cuốc gọi đến và gọi đi.
        /// lọc cuộc gọi đi -> cuộc gọi lại
        /// </summary>
        public DataTable GetBCCSKHChiTiet(DateTime TuNgay, DateTime DenNgay, string Vung, int soLanGoiLai, bool isDonDuoc, bool isDonDuoc888, bool isTruotHoan, bool isKhongXe, bool isKhongXe999, string idTongDai, string idCS, string idDienThoai, bool isGoiTaxi, bool isGoiLai,string pSoDienThoai)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TuNgay",SqlDbType.DateTime),     
                new SqlParameter("@DenNgay",SqlDbType.DateTime),
                new SqlParameter("@Vungs",SqlDbType.VarChar,50) ,
                new SqlParameter("@IsDonDuoc",SqlDbType.Bit) ,
                new SqlParameter("@IsDonDuocXe888",SqlDbType.Bit),
                new SqlParameter("@IsTruotHoan",SqlDbType.Bit) ,
                new SqlParameter("@IsKhongXe",SqlDbType.Bit) ,
                new SqlParameter("@IsKhongXe999",SqlDbType.Bit) ,
                new SqlParameter("@IDTD",SqlDbType.NVarChar,50) ,
                new SqlParameter("@IDCS",SqlDbType.NVarChar ,50) ,
                new SqlParameter("@IDDienThoai",SqlDbType.NVarChar ,50),
                new SqlParameter("@isGoiTaxi",SqlDbType.Bit) ,
                new SqlParameter("@isGoiLai",SqlDbType.Bit) ,
                new SqlParameter("@soLanGoiLai",SqlDbType.Int),
                new SqlParameter("@pSoDienThoai",SqlDbType.VarChar,20)
            };
            parameters[0].Value = TuNgay;
            parameters[1].Value = DenNgay;
            parameters[2].Value = Vung;
            parameters[3].Value = isDonDuoc ;
            parameters[4].Value = isDonDuoc888;
            parameters[5].Value = isTruotHoan;
            parameters[6].Value = isKhongXe;
            parameters[7].Value = isKhongXe999;
            parameters[8].Value = idTongDai;
            parameters[9].Value =idCS  ;
            parameters[10].Value = idDienThoai;
            parameters[11].Value = isGoiTaxi;
            parameters[12].Value = isGoiLai;
            parameters[13].Value = soLanGoiLai;
            parameters[14].Value = pSoDienThoai;
            return this.RunProcedure("[CSKH.BaoCaoCSKHChiTietByVung]", parameters, "tblCSKH").Tables[0];
        }
    }
}
