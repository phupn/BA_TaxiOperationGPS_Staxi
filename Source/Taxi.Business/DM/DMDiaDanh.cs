using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business
{
    public class  DiaDanh
    {
        private int mDiaDanhID;

        public int DiaDanhID
        {
            get { return mDiaDanhID; }
            set { mDiaDanhID = value; }
        }
        private string mTenDiaDanh;

        public string TenDiaDanh
        {
            get { return mTenDiaDanh; }
            set { mTenDiaDanh = value; }
        }

        private string mDiaChi;

        public string DiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }
        private string mDienThoai;

        public string DienThoai
        {
            get { return mDienThoai; }
            set { mDienThoai = value; }
        }

        private string mGhiChu;

        public string GhiChu
        {
            get { return mGhiChu; }
            set { mGhiChu = value; }
        }

        private int mLoaiDiaDanhID;

        public int LoaiDiaDanhID
        {
            get { return mLoaiDiaDanhID; }
            set { mLoaiDiaDanhID = value; }
        }


        private string mLoaiDiaDanh;

        public string LoaiDiaDanh
        {
            get { return mLoaiDiaDanh; }
            set { mLoaiDiaDanh = value; }
        }
        /// <summary>
        /// lay tat ca dia danh
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDSDiaDanh()
        {
            return new Data.DiaDanh().GetDSDiaDanh(-1, "", "", -1);
        }
        /// <summary>
        /// lay theo diadanhID
        /// </summary>
        /// <param name="DiaDanhID"></param>
        /// <returns></returns>
        public static DataTable GetDSDiaDanh_ByDiaDanhID(int DiaDanhID)
        {
            return new Data.DiaDanh().GetDSDiaDanh(DiaDanhID, "", "", -1);
        }
        /// <summary>
        /// lay theo like TenDiaDanh
        /// </summary>
        /// <param name="TenDiaDanh"></param>
        /// <returns></returns>
        public static DataTable GetDSDiaDanh_ByTenDiaDanh(string TenDiaDanh)
        {
            return new Data.DiaDanh().GetDSDiaDanh(-1, TenDiaDanh, "", -1);
        }
        /// <summary>
        /// lay theo like DiaChi
        /// </summary>
        /// <param name="DiaChi"></param>
        /// <returns></returns>
        public static DataTable GetDSDiaDanh_ByDiaChi(string DiaChi)
        {
            return new Data.DiaDanh().GetDSDiaDanh(-1, "", DiaChi, -1);
        }
        /// <summary>
        /// lay theo loaidiadanhID
        /// </summary>
        /// <param name="LoaiDiaDanhID"></param>
        /// <returns></returns>
        public static DataTable GetDSDiaDanh_ByLoaiDiaDanh(int LoaiDiaDanhID)
        {
            return new Data.DiaDanh().GetDSDiaDanh(-1, "", "", LoaiDiaDanhID);
        }


        public bool Insert() 
        {
            return new Data.DiaDanh().Insert(this.TenDiaDanh, this.DiaChi, this.DienThoai, this.GhiChu, this.LoaiDiaDanhID);
        }

        public bool Update()
        {
            return new Data.DiaDanh().Update(this.DiaDanhID, this.TenDiaDanh, this.DiaChi, this.DienThoai, this.GhiChu, this.LoaiDiaDanhID);
        }

        public bool Delete()
        {
            return new Data.DiaDanh().Delete(this.DiaDanhID);
        }

        #region -----New v3-----
        #region========================Autocomplete Address==========================
        public DataTable GetRoadData_Autocomplete()
        {
            return new Data.DiaDanh().GetRoadData_Autocomplete();
        }

        public DataTable GetData_NoneAutocomplete()
        {
            return new Data.DiaDanh().GetData_NoneAutocomplete();
        }
        #endregion===================================================================
        #endregion
    }
}
