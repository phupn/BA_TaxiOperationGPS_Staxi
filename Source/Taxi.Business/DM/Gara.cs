using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.DM
{
    public class Gara
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

        public Gara(int _ID, string _Name)
        {
            this.mID = _ID;
            this.mName = _Name;
        }
        /// <summary>
        /// insert 1 gara tra ve một id của gara
        /// </summary>
        /// <param name="_Name"></param>
        /// <returns></returns>
        public int Insert()
        {
            return new Data.DM.Gara().Insert(this.mName);
        }

        public bool Update()
        {
           return new Data.DM.Gara().Update(ID, Name);
        }
        /// <summary>
        /// lay thong tin cua gara by id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Gara GetGaraByID(int ID)
        {
            DataTable dt = new Data.DM.Gara().GetGaraByID(ID);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                int _id = 0;
                string _name = "";

                _id = int.Parse(dt.Rows[0]["ID"].ToString());
                _name = dt.Rows[0]["Name"].ToString(); 

                Gara objGara = new Gara(_id,_name );

                return objGara;
            }
            return null;


        }

        public static DataTable GetAllGara()
        {
            return new Data.DM.Gara().GetAllGara();
        }

        public bool Delete()
        {
            return new Data.DM.Gara().Delete(this.ID);
        }

        public static bool CheckTonTaiTenGara(string _Name)
        {
            return new Data.DM.Gara().CheckTonTaiTenGara(_Name);
        }
    }
}
