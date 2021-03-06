using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Data.DM;

namespace Taxi.Business.DM
{
    public class DMTinhThanh
    {
        private int mID;

        public int TinhThanhID
        {
            get { return mID; }
            set { mID = value; }
        }
        private string mMaTinhThanh;

        public string MaTinhThanh
        {
            get { return mMaTinhThanh; }
            set { mMaTinhThanh = value; }
        }
        private string mTenTinhThanh;

        public string TenTinhThanh
        {
            get { return mTenTinhThanh; }
            set { mTenTinhThanh = value; }
        }
        public DMTinhThanh()
        {
        }
        public DMTinhThanh(string MaTinhThanh, string TenTinhThanh)
        {
            this.mMaTinhThanh = MaTinhThanh;
            this.mTenTinhThanh = TenTinhThanh;
        }

        /// <summary>
        /// insert 1 gara tra ve một id của gara
        /// </summary>
        /// <param name="_Name"></param>
        /// <returns></returns>
        //public int Insert()
        //{
        //    return new Data.DM.Gara().Insert(this.mName);
        //}

        //public bool Update()
        //{
        //   return new Data.DM.Gara().Update(ID, Name);
        //}
        /// <summary>
        /// lay thong tin cua gara by id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public DataTable GetAllTinhThanh()
        {
            return new Taxi.Data.DM.DMTinhThanh().GetAllTinhThanh();
        }


        public DataTable GetQuanHuyenByID(int ID)
        {
            return new Taxi.Data.DM.DMTinhThanh().GetQuanHuyenByID(ID);
        }
        //public bool Delete()
        //{
        //    return new Data.DM.Gara().Delete(this.ID);
        //}

        //public static bool CheckTonTaiTenGara(string _Name)
        //{
        //    return new Data.DM.Gara().CheckTonTaiTenGara(_Name);
        //}
    }
}
