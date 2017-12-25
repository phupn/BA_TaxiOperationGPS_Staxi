using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{
    public class DanhBaKhachAo
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
        public DanhBaKhachAo()
        {
            mPhoneNumber = string.Empty;
            mName = string.Empty;
            mAddress = string.Empty;
        }
        public DanhBaKhachAo(string PhoneNumber, string Name, string Address)
        {
            mPhoneNumber = PhoneNumber;
            mName = Name;
            mAddress = Address;
        }
        #endregion Contructor

        #region Methods
        public bool Insert()
        {
            return new Data.DanhBaKhachAo().Insert(this.PhoneNumber, this.Name, this.Address);
        }

        public bool Update()
        {
            return new Data.DanhBaKhachAo().Update(this.PhoneNumber, this.Name, this.Address);
        }

     
        /// <summary>
        /// tra ve dia chi cua so dien thoai 
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public static string  GetDanhBa(string PhoneNumber)
        {
            DataTable dt = new DataTable();
            dt = new Data.DanhBaKhachAo().GetDanhBaKhachAo(PhoneNumber);
            if (dt.Rows.Count > 0)
            {
               return  dt.Rows[0]["Address"].ToString();
            
            }
            dt.Dispose();
            dt = null;
            return string.Empty;
        }

        public static List<DanhBaKhachAo >  GetDanhSachKhachAo()
        {
            List<DanhBaKhachAo> listKhachAo = new List<DanhBaKhachAo>();
            DataTable dt = new DataTable();
            dt = new Data.DanhBaKhachAo().GetDanhBaKhachAo(string.Empty );
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DanhBaKhachAo objKhachao = new DanhBaKhachAo();
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
            return new Data.DanhBaKhachAo().Delete(PhoneNumber);
        }

        #endregion Methods

        public static List<DanhBaKhachAo> GetKhachAos(string strSQL)
        {
            List<DanhBaKhachAo> lstKhachAo = new List<DanhBaKhachAo>();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachAo().GetKhachAos(strSQL);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DanhBaKhachAo objKhachAo = new DanhBaKhachAo();
                    objKhachAo.PhoneNumber = StringTools.TrimSpace(dr["PhoneNumber"].ToString());
                    objKhachAo.Name = StringTools.TrimSpace(dr["Name"].ToString());
                    objKhachAo.Address = StringTools.TrimSpace(dr["Address"].ToString());


                    lstKhachAo.Add(objKhachAo);
                }
            }
            dt.Dispose();
            dt = null;

            return lstKhachAo;
        }
    }
}
