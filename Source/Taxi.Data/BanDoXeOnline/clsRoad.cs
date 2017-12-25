using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Taxi.Entity;
using Taxi.Utils;

namespace Taxi.Data.BanDoXeOnline
{
    public class clsRoad : DBObject
    {
        private string SP_T_ROAD_VIET_TAT_UPDATE = "[SP_T_ROAD_UPDATE_VIET_TAT]";
        private string SP_T_ROAD_VIET_TAT_INSERT = "[SP_T_ROAD_INSERT_VIET_TAT]";
        private string SP_T_ROAD_VIET_TAT_DELETE = "[SP_T_ROAD_DELETE_VIET_TAT]";

        string connString; 
        public clsRoad()
        { 
            //chuoi ket noi
            connString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
        }

        private RoadEntity Select(IDataReader dr, bool firstLoad)
        {
            RoadEntity obj = new RoadEntity(); 
            obj.ID =  (dr["ID"]== DBNull.Value)?0: int.Parse (dr["ID"].ToString());
            obj.NameEN = dr["NameEN"].ToString();
            obj.NameVN = dr["NameVN"].ToString();
            obj.VietTat = dr["VietTat"].ToString();
            obj.Polygon = dr["Polygon"].ToString();
            obj.Type = ( dr["Type"] == DBNull.Value) ?0:int.Parse ( dr["Type"].ToString());
            obj.FK_CommuneID = (dr["FK_CommuneID"] == DBNull.Value) ? 0 : int.Parse(dr["FK_CommuneID"].ToString());
            obj.FK_DistrictID = (dr["FK_DistrictID"] == DBNull.Value) ? 0 : int.Parse(dr["FK_DistrictID"].ToString());
            obj.FK_ProvinceID = (dr["FK_ProvinceID"] == DBNull.Value) ? 0 : int.Parse(dr["FK_ProvinceID"].ToString());
            obj.MaXN =(dr["MaXN"] == DBNull.Value)?"": dr["MaXN"].ToString();
            obj.KinhDo = float.Parse(dr["KinhDo"].ToString());
            obj.ViDo = float.Parse(dr["ViDo"].ToString());
            return obj; 
                        
        }

        public List<RoadEntity> GetAllRoadbyMAXN_ProvinceID( string MaCungXN , int Province  ) {
            List<RoadEntity> list = new List<RoadEntity>();

            SqlParameter[] parameters = { 
                                            new SqlParameter("@MaCungXN", SqlDbType.VarChar),
                                            new SqlParameter("@Province", SqlDbType.Int) 
                                        };
            parameters[0].Value = MaCungXN;
            parameters[1].Value = Province;
            //using (SqlDataReader dr = SqlHelper.ExecuteReader(MaCungXN, CommandType.StoredProcedure, "[GIS.T_ROAD_SelectAll]", parameters))
            using (SqlDataReader dr = SqlHelper.ExecuteReader(connString, CommandType.StoredProcedure, "[V3_GIS.T_ROAD_SelectAll]", parameters))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr, false));
                }
            }
            return list;

        }


        public DataTable GetAllRoadby(string MaCungXN, int Province)
        {
            try
            {
                SqlParameter[] parameters = { 
                                            new SqlParameter("@MaCungXN", SqlDbType.VarChar),
                                            new SqlParameter("@Province", SqlDbType.Int) 
                                        };
                parameters[0].Value = MaCungXN;
                parameters[1].Value = Province;
                return SqlHelper.ExecuteDataset(connString, "[V3_GIS.T_ROAD_SelectAll]", parameters).Tables[0];
                //return SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "[GIS.T_ROAD_SelectAll]").Tables[0];
                //return this.RunProcedure("[GIS.T_ROAD_SelectAll]", parameters, "tblRoad").Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetDMDiaDanh(string MaCungXN , string TenDiaDanh ) { 
            DataSet ds = new DataSet();
            DataTable dt= new DataTable();
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@MaCungXN",SqlDbType.VarChar,5),
                    new SqlParameter("@TenDiaDanh",SqlDbType.NVarChar,100 )                    
                };

                parameters[0].Value = MaCungXN;
                parameters[1].Value = TenDiaDanh;              

                //ds = SqlHelper.ExecuteDataset(connString ,CommandType.StoredProcedure,SP_VITRIXE_SELECT);
                ds = SqlHelper.ExecuteDataset(connString, "[T_DM_DIADANH_SelectAllByMaXN_DiaDanh]", parameters);
            if(ds.Tables.Count >0)
            {
                dt= ds.Tables[0];
            }
           return dt; 
        }

        public bool Update_TenVietTat(int ID, string VietTat, string NameVN, string NameEN, float KinhDo, float ViDo)
        {
            try
            {
                int RowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@id",SqlDbType.Int),
                    new SqlParameter ("@VietTat",SqlDbType.VarChar,200),
                    new SqlParameter ("@NameEN",SqlDbType.VarChar,200),
                    new SqlParameter ("@NameVN",SqlDbType.NVarChar,200),
                    new SqlParameter ("@KinhDo",SqlDbType.Float),
                    new SqlParameter ("@ViDo",SqlDbType.Float)
                };
                parameters[0].Value = ID;
                parameters[1].Value = VietTat;
                parameters[2].Value = NameEN;
                parameters[3].Value = NameVN;
                parameters[4].Value = KinhDo;
                parameters[5].Value = ViDo;

                RowAffect = this.RunProcedure(SP_T_ROAD_VIET_TAT_UPDATE, parameters, RowAffect);
                return (RowAffect > 0);
            }
            catch(Exception ex)
            {
                return false;            
            }
        }

        public bool Insert_TenVietTat(string NameEN, string NameVN, string VietTat, float KinhDo, float ViDo)
        {
            try
            {
                int RowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@NameEN",SqlDbType.VarChar,200),
                    new SqlParameter ("@NameVN",SqlDbType.NVarChar,200),
                    new SqlParameter ("@VietTat",SqlDbType.VarChar,200),
                    new SqlParameter ("@KinhDo",SqlDbType.Float),
                    new SqlParameter ("@ViDo",SqlDbType.Float)
                };
                parameters[0].Value = NameEN;
                parameters[1].Value = NameVN;
                parameters[2].Value = VietTat;
                parameters[3].Value = KinhDo;
                parameters[4].Value = ViDo;

                RowAffect = this.RunProcedure(SP_T_ROAD_VIET_TAT_INSERT, parameters, RowAffect);
                return (RowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete_TenVietTat(int ID)
        {
            try
            {
                int RowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@Id",SqlDbType.Int)
                };
                parameters[0].Value = ID;

                RowAffect = this.RunProcedure(SP_T_ROAD_VIET_TAT_DELETE, parameters, RowAffect);
                return (RowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        #region TEMP

        public DataTable T_POI_Type()
        {
            using (DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GPS_POI_TYPE_SELECT"))
            {
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;

        }

        private clsPOIEntity SelectPOI(IDataReader dr, bool firstLoad)
        {
            clsPOIEntity obj = new clsPOIEntity();
            obj.ID = (dr["ID"] == DBNull.Value) ? 0 : int.Parse(dr["ID"].ToString());
            obj.NameVN = dr["NameVN"].ToString();
            obj.VietTat = dr["VietTat"].ToString();
            obj.Type = (dr["Type"] == DBNull.Value) ? 0 : int.Parse(dr["Type"].ToString());
            obj.KinhDo = float.Parse(dr["KinhDo"].ToString());
            obj.ViDo = float.Parse(dr["ViDo"].ToString());
            return obj;

        }

        public List<clsPOIEntity> T_GetAllPOI_Type(int Type)
        {
            List<clsPOIEntity> list = new List<clsPOIEntity>();

            SqlParameter[] parameters = {new SqlParameter ("@TypeId",SqlDbType.Int)
                                        };
            parameters[0].Value = Type;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(connString, CommandType.StoredProcedure, "[V3_GIS.T_ROAD_SelectAll_TEMP]", parameters))
            {
                while (dr.Read())
                {
                    list.Add(this.SelectPOI(dr, false));
                }
            }
            return list;

        }

        public bool T_Update_TenVietTat(int ID, string VietTat, string NameVN, float KinhDo, float ViDo)
        {
            try
            {
                int RowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@id",SqlDbType.Int),
                    new SqlParameter ("@VietTat",SqlDbType.VarChar,200),
                    new SqlParameter ("@NameVN",SqlDbType.NVarChar,200),
                    new SqlParameter ("@KinhDo",SqlDbType.Float),
                    new SqlParameter ("@ViDo",SqlDbType.Float)
                };
                parameters[0].Value = ID;
                parameters[1].Value = VietTat;
                parameters[2].Value = NameVN;
                parameters[3].Value = KinhDo;
                parameters[4].Value = ViDo;

                RowAffect = this.RunProcedure("SP_T_ROAD_UPDATE_VIET_TAT_TEMP", parameters, RowAffect);
                return (RowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool T_Delete_TenVietTat(int ID)
        {
            try
            {
                int RowAffect = 0;
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@Id",SqlDbType.Int)
                };
                parameters[0].Value = ID;

                RowAffect = this.RunProcedure("SP_T_ROAD_DELETE_VIET_TAT_TEMP", parameters, RowAffect);
                return (RowAffect > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
