using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Taxi.Utils;

namespace Taxi.Data
{
    public class ThongTinTruyCap :   DBObject 
    {
        string ConnString = ConfigurationSettings.AppSettings["Conn"].ToString();
        public ThongTinTruyCap() { }

        public DataTable GetDSThongTinTruyCap(string Username, string IPAddress, DateTime TuNgayGio, DateTime DenNgayGio)
        {
            SqlParameter[] parameters = new SqlParameter[] {                           
              new SqlParameter("@UserName", SqlDbType.NVarChar, 50),
              new SqlParameter("@IPAddress", SqlDbType.VarChar, 20),              
              new SqlParameter("@TuNgayGio", SqlDbType.DateTime),
              new SqlParameter("@DenNgayGio", SqlDbType.DateTime )
            };

            parameters[0].Value = Username;
            parameters[1].Value = IPAddress;
            parameters[2].Value = TuNgayGio;
            parameters[3].Value = DenNgayGio;            

            DataSet ds = new DataSet();
            ds = this.RunProcedure("SP_SYS_T_WebGPS_LOG_TRUYCAP_SELECT", parameters, "tableLogTruycap");
            DataTable dt = ds.Tables[0];

            ds.Dispose();
            ds = null;

            return dt;
        }

        public bool insertNew(string Username, string IPAddress, string typeBrown, DateTime ThoiDiem, string GhiChu)
        {
            SqlParameter[] parameters = new SqlParameter[] {                           
              new SqlParameter("@UserName", SqlDbType.NVarChar, 50),
              new SqlParameter("@ThoiDiemTruyCap", SqlDbType.DateTime),
              new SqlParameter("@IPAddress", SqlDbType.VarChar, 20),              
              new SqlParameter("@LoaiTrinhDuyet", SqlDbType.NVarChar,50),
              new SqlParameter("@GhiChu", SqlDbType.NVarChar, 100 )
            };

            parameters[0].Value = Username;
            parameters[1].Value = ThoiDiem;
            parameters[2].Value = IPAddress;            
            parameters[3].Value = typeBrown;
            parameters[4].Value = GhiChu;   

            try
            {
                SqlHelper.ExecuteNonQuery(ConnString, "SP_T_WebGPS_LOG_TRUYCAP_THEMMOI", parameters);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra,không thêm mới được log ");
                return false;
            }
        }

        public bool deleteData(DateTime TuNgayGio, DateTime DenNgayGio)
        {
            SqlParameter[] parameters = new SqlParameter[] {                                                      
              new SqlParameter("@TuNgayGio", SqlDbType.DateTime),
              new SqlParameter("@DenNgayGio", SqlDbType.DateTime )
            };
          
            parameters[0].Value = TuNgayGio;
            parameters[1].Value = DenNgayGio;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnString, "SP_T_WebGPS_LOG_TRUYCAP_DELETE", parameters);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra,không xoa được log ");
                return false;
            }
        }
    }
}
