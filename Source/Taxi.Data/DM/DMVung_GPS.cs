using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;
using Taxi.Entity;
using Microsoft.ApplicationBlocks.Data;

namespace Taxi.Data.DM
{
    public class DMVung_GPS
    {
        private string g_ConnectionString = string.Empty;
        private SqlConnection g_sqlCon;

        public DMVung_GPS()
        {
            g_ConnectionString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
            g_sqlCon = new SqlConnection(g_ConnectionString);
        }

        /// <summary>
        /// Lay tat ca vung kenh gps
        /// </summary>
        /// <returns></returns>
        public List<DMVung_GPSEntity> GetAllDSVungKenh()
        {
            List<DMVung_GPSEntity> DSVungKenh = new List<DMVung_GPSEntity>();

            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            using (SqlDataReader sqldrDSVungKenh = SqlHelper.ExecuteReader(g_sqlCon, CommandType.StoredProcedure, "V3_DM_VUNG_GPS_GETALL"))
            {
                while (sqldrDSVungKenh.Read())
                {
                    DSVungKenh.Add(new DMVung_GPSEntity(
                                        Convert.ToInt32(sqldrDSVungKenh["ID"]),
                                        sqldrDSVungKenh["TenVungGPS"].ToString(),
                                        Convert.ToInt32(sqldrDSVungKenh["KenhVung"]),
                                        Convert.ToInt32(sqldrDSVungKenh["KenhGop"]),
                                        sqldrDSVungKenh["ToaDoVung"].ToString(),
                                        Convert.ToInt32(sqldrDSVungKenh["BanKinhTimXe"])
                                        )
                                    );
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return DSVungKenh;
        }

        /// <summary>
        /// Lay Vung kenh theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DMVung_GPSEntity GetVungKenh(int ID)
        {
            DMVung_GPSEntity vungKenh = new DMVung_GPSEntity();
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int)};
                        parameters[0].Value = ID;

                        using (SqlDataReader sqldrVungKenh = SqlHelper.ExecuteReader(g_sqlCon, CommandType.StoredProcedure, "V3_DM_VUNG_GPS_GET_BY_ID", parameters))
            {
                if (sqldrVungKenh != null)
                {
                    vungKenh.KenhVung = Convert.ToInt32(sqldrVungKenh["ID"]);
                    vungKenh.TenVungGPS = sqldrVungKenh["TenVungGPS"].ToString();
                    vungKenh.KenhVung = Convert.ToInt32(sqldrVungKenh["KenhVung"]);
                    vungKenh.KenhGop = Convert.ToInt32(sqldrVungKenh["KenhGop"]);
                    vungKenh.ToaDoVung = sqldrVungKenh["ToaDoVung"].ToString();
                    vungKenh.BanKinhTimXe = Convert.ToInt32(sqldrVungKenh["BanKinhTimXe"]);
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return vungKenh;
        }

        /// <summary>
        /// Lay kenh gop kenh vung
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetKenhGop_ByVung(string Vung)
        {
            string kenhGop = "";
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Vung",SqlDbType.VarChar, 10)};
            parameters[0].Value = Vung;

            using (SqlDataReader sqldrVungKenh = SqlHelper.ExecuteReader(g_sqlCon, CommandType.StoredProcedure, "V3_DM_VUNG_GPS_GET_BY_VUNG", parameters))
            {
                while (sqldrVungKenh.Read())
                {
                    kenhGop += sqldrVungKenh["KenhGop"].ToString() + ";";
                }
            }
            // đóng kêt nối db
            g_sqlCon.Close();
            return kenhGop.TrimEnd(';');
        }
        /// <summary>
        /// Xoa Kenh VungGPS
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int),
                    new SqlParameter("@Output",SqlDbType.Bit)};
            parameters[0].Value = ID;
            parameters[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_DM_VUNG_GPS_DELETE", parameters);            
            g_sqlCon.Close();
            return Convert.ToBoolean(parameters[1].Value);
        }

        /// <summary>
        /// Cap nhat kenh vung
        /// </summary>
        /// <param name="DMVung_GPS"></param>
        /// <returns></returns>
        public bool Update(DMVung_GPSEntity DMVung_GPS)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int),
                    new SqlParameter("@TenVungGPS",SqlDbType.NVarChar,50),
                    new SqlParameter("@KenhVung",SqlDbType.Int),
                    new SqlParameter("@KenhGop",SqlDbType.Int),
                    new SqlParameter("@ToaDoVung",SqlDbType.VarChar,5000),
                    new SqlParameter("@BanKinhTimXe",SqlDbType.Int),
                    new SqlParameter("@Output",SqlDbType.Bit)
            
            };
                parameters[0].Value = DMVung_GPS.ID;
                parameters[1].Value = DMVung_GPS.TenVungGPS;
                parameters[2].Value = DMVung_GPS.KenhVung;
                parameters[3].Value = DMVung_GPS.KenhGop;
                parameters[4].Value = DMVung_GPS.ToaDoVung;
                parameters[5].Value = DMVung_GPS.BanKinhTimXe;
                parameters[6].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_DM_VUNG_GPS_UPDATE", parameters);
            g_sqlCon.Close();
            return Convert.ToBoolean(parameters[6].Value);
        }

        /// <summary>
        /// Cap nhat kenh vung
        /// </summary>
        /// <param name="DMVung_GPS"></param>
        /// <returns></returns>
        public bool Insert(DMVung_GPSEntity DMVung_GPS)
        {
            if (g_sqlCon.State == ConnectionState.Closed)
            {
                g_sqlCon.Open();
            }
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenVungGPS",SqlDbType.NVarChar,50),
                    new SqlParameter("@KenhVung",SqlDbType.Int),
                    new SqlParameter("@KenhGop",SqlDbType.Int),
                    new SqlParameter("@ToaDoVung",SqlDbType.VarChar,5000),
                    new SqlParameter("@BanKinhTimXe",SqlDbType.Int),
                    new SqlParameter("@Output",SqlDbType.Bit)
            
            };
            parameters[0].Value = DMVung_GPS.TenVungGPS;
            parameters[1].Value = DMVung_GPS.KenhVung;
            parameters[2].Value = DMVung_GPS.KenhGop;
            parameters[3].Value = DMVung_GPS.ToaDoVung;
            parameters[4].Value = DMVung_GPS.BanKinhTimXe;
            parameters[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "V3_DM_VUNG_GPS_INSERT", parameters);
            g_sqlCon.Close();
            return Convert.ToBoolean(parameters[5].Value);
        }

    }
}
