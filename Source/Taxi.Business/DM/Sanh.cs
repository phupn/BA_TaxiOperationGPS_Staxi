using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.DM
{
    public class Sanh
    {
        private int mID;

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        private string mName;

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public Sanh(int _ID, string _Name)
        {
            this.mID = _ID;
            this.mName = _Name;
        }
        /// <summary>
        /// insert 1 Sanh tra ve một id của Sanh
        /// </summary>
        /// <param name="_Name"></param>
        /// <returns></returns>
        public int Insert()
        {
            return new Data.DM.Sanh().Insert(this.mName);
        }

        public bool Update()
        {
            return new Data.DM.Sanh().Update(ID, Name);
        }
        /// <summary>
        /// lay thong tin cua Sanh by id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Sanh GetSanhByID(int ID)
        {
            DataTable dt = new Data.DM.Sanh().GetSanhByID(ID);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                int _id = 0;
                string _name = "";

                _id = int.Parse(dt.Rows[0]["ID"].ToString());
                _name = dt.Rows[0]["Name"].ToString();

                Sanh objSanh = new Sanh(_id, _name);

                return objSanh;
            }
            return null;


        }

        public static DataTable GetAllSanh()
        {
            return new Data.DM.Sanh().GetAllSanh();
        }

        public static bool Delete(int ID)
        {
            return new Data.DM.Sanh().Delete(ID);
        }

        public static bool CheckTonTaiTenSanh(string _Name)
        {
            return new Data.DM.Sanh().CheckTonTaiTenSanh(_Name);
        }
/// <summary>
/// hamf tra ve ds xe trong sanh
/// </summary>
/// <param name="SanhID"></param>
/// <returns></returns>
        public static DataTable  GetDSXeThuocSanh(int SanhID)
        {
            return new Data.DM.Sanh().GetDSXeThuocSanh(SanhID);
        }
        /// <summary>
        /// ham tra ve sanh thuoc xe
        /// </summary>
        /// <param name="BienSoXe"></param>
        /// <returns></returns>
        public static Sanh GetSanhCuaXe(string BienSoXe)
        {
            DataTable dt = new Data.DM.Sanh().GetSanhCuaXe(BienSoXe);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                Sanh objSanh = new Sanh(Convert.ToInt32(dt.Rows[0]["ID"].ToString()), dt.Rows[0]["Name"].ToString());
                return objSanh;


            }
            return null;
        }
        /// <summary>
        /// hafm tra ve ds xe khong thuoc sanh nao
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDSXeKhongThuocSanhNao()
        {
            return new Data.DM.Sanh().GetDSXeKhongThuocSanhNao( );
        }

        public static bool AddXeVaoSanh(string SoHieuXe, int SanhID)
        {
            return new Data.DM.Sanh().AddXeVaoSanh(SoHieuXe, SanhID);
        }
        public static bool XoaXeTrongSanh(string SoHieuXe )
        {
            return new Data.DM.Sanh().XoaXeTrongSanh(SoHieuXe );
        }
        
    }
}
