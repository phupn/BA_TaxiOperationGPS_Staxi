using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Taxi.Entity ;
namespace Taxi.Data
{
    /// <summary>
    /// author hangtm  
    /// create date 8/4/2011
    /// </summary>
    public class XeOnlineData
    {
         //ten thu tuc
        private string SP_VITRIXE_SELECT = "[SP_T_VITRI_ONLINE_SELECT]";
        private string SP_DIADANH_SELECT = "[SP_T_DM_DIADANH_SELECT_TEN]";
        private string SP_T_LOAIVUNG = "[SP_T_LOAIVUNG_SELECT]";
        private string SP_VITRIXE_TOADO = "[SP_T_VITRIXE_ONLINE_SELECT_TOADO]";
        private string SP_T_VUNGDIEUHANH = "[SP_GPS_T_VUNGDIEUHANH]";
        private string SP_T_TAXIOPERATION_SELECT = "[SP_T_TAXIOPERATION_SELECT]";

        public string connString;

        public XeOnlineData()
        { 
            //chuoi ket noi
            connString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
        }

        private OnlineCarEntity AddObject( IDataReader dr ) {
            OnlineCarEntity obj = new OnlineCarEntity();
            obj.BienSoXe = dr["FK_BienSoXe"].ToString();
            obj.Huong = (dr["Huong"] == DBNull.Value) ? 0 : int.Parse(dr["Huong"].ToString());
            obj.KinhDo = (dr["KinhDo"] == DBNull.Value) ? 0 :float.Parse(dr["KinhDo"].ToString());
            obj.SoChoNgoi = (dr["Sochongoi"] == DBNull.Value) ? 0 : int.Parse(dr["Sochongoi"].ToString());
            obj.ThoidiemChenDL = (dr["ThoiDiemChenDuLieu"] == DBNull.Value) ? new DateTime() : Convert.ToDateTime(dr["ThoiDiemChenDuLieu"].ToString());
            obj.ThoidiemchenDLServer = (dr["ThoiDiemChenDuLieuServer"] == DBNull.Value) ? new DateTime() : Convert.ToDateTime(dr["ThoiDiemChenDuLieuServer"].ToString());
            obj.ThoidiemGui = (dr["ThoiDiemXeGui"] == DBNull.Value) ? new DateTime() : Convert.ToDateTime(dr["ThoiDiemXeGui"].ToString());
            obj.Trangthai = (dr["TrangThai"] == DBNull.Value) ? 0 : int.Parse(dr["TrangThai"].ToString());
            obj.Vantocco = (dr["VanTocCo"] == DBNull.Value) ? 0 : int.Parse(dr["VanTocCo"].ToString());
            obj.VantocPGS = (dr["VanTocGPS"] == DBNull.Value) ? 0 : int.Parse(dr["VanTocGPS"].ToString());
            obj.ViDo = (dr["ViDo"] == DBNull.Value) ? 0 : float.Parse(dr["ViDo"].ToString());
            obj.disTance = 0;
            obj.SoHieuXe = dr["SoHieuXe"].ToString();
            return obj; 
              
        }

        public List<OnlineCarEntity> Async_ListXeObject_By_XNAndTime(string MaCungXN, DateTime tgBatdau, DateTime tgKetthuc)
        {
            List<OnlineCarEntity> list = new List<OnlineCarEntity>();

            SqlParameter[] parameters = { 
                                            new SqlParameter("@MaCungXN",SqlDbType.VarChar,5),
                                            new SqlParameter("@Batdau",SqlDbType.DateTime ),
                                            new SqlParameter("@Ketthuc",SqlDbType.DateTime ) 
                                        };
            parameters[0].Value = MaCungXN;
            parameters[1].Value = tgBatdau;
            parameters[2].Value = tgKetthuc;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(connString, CommandType.StoredProcedure, SP_VITRIXE_SELECT, parameters))
            {
                while (dr.Read())
                {
                    list.Add(this.AddObject(dr));
                }
            }

            return list;
        }


        public DataTable GetCarPosition(string MaCungXN , DateTime tgBatdau , DateTime tgKetthuc )
        {                         
            DataSet ds = new DataSet();
            DataTable dt= new DataTable();
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaCungXN",SqlDbType.VarChar,5),
                    new SqlParameter("@Batdau",SqlDbType.DateTime ),
                    new SqlParameter("@Ketthuc",SqlDbType.DateTime ) 
                    
                };

                parameters[0].Value = MaCungXN;
                parameters[1].Value = tgBatdau;
                parameters[2].Value = tgKetthuc;

                //ds = SqlHelper.ExecuteDataset(connString ,CommandType.StoredProcedure,SP_VITRIXE_SELECT);
                ds = SqlHelper.ExecuteDataset(connString, SP_VITRIXE_SELECT, parameters);
            if(ds.Tables.Count >0)
            {
                dt= ds.Tables[0];
            }
           return dt;            
        }
        /// <summary>
        /// hangtm
        /// bo sung ngay 19/4/2011
        /// lay ra ten dia danh de lam autocomplete
        /// </summary>
        /// <returns></returns>
        public DataTable TenDiaDanh()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[] { };
            ds = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, SP_DIADANH_SELECT);
            if(ds.Tables.Count >0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        /// <summary>
        /// hangtm 
        /// bo sung ngay 20/4/2011
        /// lay ra ten cac vung
        /// </summary>
        /// <returns></returns>
        public DataSet LoaiVung()
        {
            DataSet ds = new DataSet();           
            SqlParameter[] parameters = new SqlParameter[] { };
            ds = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, SP_T_LOAIVUNG );
            return ds;
        }
        /// <summary>
        /// hangtm
        /// bo sung ngay 23/4/2011
        /// lay ra thong tin kinh do, vi do van toc va trang thai cua xe
        /// </summary>
        /// <returns></returns>
        public DataSet ThongTinXeOnline(string MaXN, string SoHieu, DateTime tgBatDau, DateTime tgKetThuc)
        {
            DataSet dsThongTinXe = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@MaXn",SqlDbType.VarChar,5),
                new SqlParameter("@SoHieuXe",SqlDbType.VarChar,16),
                new SqlParameter("@tgBatDau",SqlDbType.DateTime ),
                new SqlParameter("@tgKetThuc",SqlDbType.DateTime )
            };
            parameters[0].Value = MaXN;
            parameters[1].Value = SoHieu ;
            parameters[2].Value = tgBatDau;
            parameters[3].Value = tgKetThuc;

            dsThongTinXe = SqlHelper.ExecuteDataset(connString, SP_VITRIXE_TOADO, parameters);
            return dsThongTinXe;
        }
        /// <summary>
        /// hangtm
        /// bo sung ngay 25/4/2011
        /// lay ra thong tin vung : toa do cac dinh, toa do tam, ten vung
        /// </summary>
        /// <param name="MaCungXn"></param>
        /// <returns></returns>
        public DataSet ThongTinVung(string MaCungXn, int IDVung)
        {
            DataSet dsVung = new DataSet();
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter("@MaCungXn", SqlDbType.VarChar, 5),
            new SqlParameter("@IDVungDieuHanh",SqlDbType.Int )
            };
            parameters[0].Value = MaCungXn;
            parameters[1].Value = IDVung;
            dsVung = SqlHelper.ExecuteDataset(connString,SP_T_VUNGDIEUHANH ,parameters );

            return dsVung;
        }
        /// <summary>
        /// bo sung 27/4/2011
        /// lay ra thong tin toa do
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable ThongTinToaDo(long ID)
        {
            DataSet dsToaDo = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter ("@ID",SqlDbType.BigInt )
            };
            parameters[0].Value = ID;
            dsToaDo = SqlHelper.ExecuteDataset(connString, SP_T_TAXIOPERATION_SELECT, parameters);
            if(dsToaDo.Tables.Count >0)
            {
               dt = dsToaDo.Tables[0];
            }
            return dt;
        }
    }
}
