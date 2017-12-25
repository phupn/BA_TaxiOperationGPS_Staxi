using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Data.BanDoXeOnline;
using Taxi.Entity;
using System.Data;

namespace Taxi.Business.BanDoXe
{
    public class clsRoad
    {

        public List<RoadEntity> GetAllRoadbyMAXN_ProvinceID(string MaCungXN, int Province) {
            return new Taxi.Data.BanDoXeOnline.clsRoad().GetAllRoadbyMAXN_ProvinceID(MaCungXN, Province);
        }
        public DataTable GetAllRoadby(string MaCungXN, int Province) {
            return new Taxi.Data.BanDoXeOnline.clsRoad().GetAllRoadby(MaCungXN, Province); 
        }

        public DataTable GetDMDiaDanh(string MaCungXN, string TenDiaDanh) {
            return new Taxi.Data.BanDoXeOnline.clsRoad().GetDMDiaDanh(MaCungXN, TenDiaDanh); 
        }
        /// <summary>
        /// sua lai ten duong viet tat do nguoi dung dinh nghia
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="MaXn"></param>
        /// <param name="TenTat"></param>
        /// <returns></returns>
        public bool Update_TenVietTat(int ID, string TenTat, string NameVN, string NameEN, float KinhDo, float ViDo)
        {
            return new Taxi.Data.BanDoXeOnline.clsRoad().Update_TenVietTat(ID, TenTat, NameVN, NameEN, KinhDo, ViDo);
        }

        public bool Insert_TenVietTat(string NameEN, string NameVN, string VietTat, float KinhDo, float ViDo)
        {
            return new Taxi.Data.BanDoXeOnline.clsRoad().Insert_TenVietTat(NameEN, NameVN, VietTat, KinhDo, ViDo);
        }

        public bool Delete_TenVietTat(int ID)
        {
            return new Taxi.Data.BanDoXeOnline.clsRoad().Delete_TenVietTat(ID);
        }

        #region TEMP
        public bool T_Update_TenVietTat(int ID, string TenTat, string NameVN, float KinhDo, float ViDo)
        {
            return new Taxi.Data.BanDoXeOnline.clsRoad().T_Update_TenVietTat(ID, TenTat, NameVN, KinhDo, ViDo);
        }

        public bool T_Delete_TenVietTat(int ID)
        {
            return new Taxi.Data.BanDoXeOnline.clsRoad().T_Delete_TenVietTat(ID);
        }

        public List<clsPOIEntity> T_GetAllPOI_Type(int Type)
        {
            return new Taxi.Data.BanDoXeOnline.clsRoad().T_GetAllPOI_Type(Type);
        }

        public DataTable T_POI_Type()
        {
            return new Taxi.Data.BanDoXeOnline.clsRoad().T_POI_Type();
        }

        #endregion
    }
}