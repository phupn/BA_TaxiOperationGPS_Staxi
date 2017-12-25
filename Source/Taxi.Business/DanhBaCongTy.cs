using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{
   public  class DanhBaCongTy
    {
      #region Members
        private string mPhoneNumber;

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }

        private string mName;

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        private string mAddress;

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        #endregion

        #region Contructor
        public DanhBaCongTy()
        {
            mPhoneNumber = string.Empty;
            mName = string.Empty;
            mAddress = string.Empty;
        }
       public DanhBaCongTy(string PhoneNumber, string Name, string Address)
        {
            mPhoneNumber = PhoneNumber;
            mName = Name;
            mAddress = Address;
        }
        #endregion Contructor

        #region Methods
        public bool Insert()
        {
            return new Data.DanhBaCongTy().Insert(this.PhoneNumber, this.Name, this.Address);
        }

       public bool Update()
       {
           return new Data.DanhBaCongTy().Update(this.PhoneNumber, this.Name, this.Address);
       }
        /// <summary>
        /// tra ve dia chi cua so dien thoai 
        /// </summary>
        public static string  GetDanhBa(string PhoneNumber)
        {
            DataTable dt = new DataTable();
            dt = new Data.DanhBaCongTy().GetDanhBaCONGTY(PhoneNumber);
            if (dt.Rows.Count > 0)
            {
               return  dt.Rows[0]["Address"].ToString();
            
            }
            dt.Dispose();
            dt = null;
            return string.Empty;
        }
        public static string GetName(string PhoneNumber)
        {
            try
            {
                using (DataTable dt = new Data.DanhBaCongTy().GetDanhBaCONGTY(PhoneNumber))
                {
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0]["Name"].ToString();
                    }
                }

            }
            catch (Exception ex) { }
            
            return string.Empty;
        }
       public static List<DanhBaCongTy> GetDanhSachDanhBaCongTy()
        {
            List<DanhBaCongTy> listKhachAo = new List<DanhBaCongTy>();
            DataTable dt = new DataTable();
            dt = new Data.DanhBaCongTy().GetDanhBaCONGTY(string.Empty );
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DanhBaCongTy objKhachao = new DanhBaCongTy();
                    objKhachao.PhoneNumber = dr["PhoneNumber"].ToString();
                    objKhachao.Name = dr["Name"].ToString();
                    objKhachao.Address = dr["Address"].ToString();

                    listKhachAo.Add(objKhachao);
                }
            }
            dt.Dispose();
            dt = null;

            return listKhachAo;
        }

       /// <summary>
       /// Get danh ba cong ty co thay doi
       /// </summary>
       /// <param name="LastUpdate"></param>
       /// <returns></returns>
       public static List<DanhBaCongTy> GetDanhBaCONGTY_GetLast(DateTime LastUpdate)
       {
           List<DanhBaCongTy> listKhachAo = new List<DanhBaCongTy>();
           DataTable dt = new DataTable();
           dt = new Data.DanhBaCongTy().GetDanhBaCONGTY_GetLast(LastUpdate);
           if (dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   DanhBaCongTy objKhachao = new DanhBaCongTy();
                   objKhachao.PhoneNumber = dr["PhoneNumber"].ToString();
                   objKhachao.Name = dr["Name"].ToString();
                   objKhachao.Address = dr["Address"].ToString();

                   listKhachAo.Add(objKhachao);
               }
           }
           dt.Dispose();
           dt = null;

           return listKhachAo;
       }

        public bool Delete(string PhoneNumber)
        {
            return new Data.DanhBaCongTy().Delete(PhoneNumber);
        }

        #endregion Methods

        public static List<DanhBaCongTy> GetDanhBaCongTys(string strSQL)
        {
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaCongTy().GetDanhBaCongTys(strSQL);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy();
                    objDanhBaCongTy.PhoneNumber = StringTools.TrimSpace(dr["PhoneNumber"].ToString());
                    objDanhBaCongTy.Name = StringTools.TrimSpace(dr["Name"].ToString());
                    objDanhBaCongTy.Address = StringTools.TrimSpace(dr["Address"].ToString());


                    lstDanhBaCongTy.Add(objDanhBaCongTy);
                }
            }
            dt.Dispose();
            dt = null;

            return lstDanhBaCongTy;
        }
    }
}

