using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{
    /// <summary>
    /// DM muc doi tac cua cong ty taxi
    /// </summary>
    /// <Modified>
    ///	Name		Date		 Comment 
    ///	Congnt		31/03/2008   Created
    ///	</Modified> 
    public class KhachVIP
    {
        #region Members

        private string mMaKhachVIP;
        public string MaKhachVIP
        {
            get { return mMaKhachVIP; }
            set { mMaKhachVIP = value; }
        }
        private string mName;
        private string mAddress;
        private string mPhones; // Khach hang su dung nhieu so dien thoai, luu lai tat ca cac so
        private string mFax;
        private string mEmail;
        private string mNotes;
        private bool mIsActive;

        public bool IsActive
        {
            get { return mIsActive; }
            set { mIsActive = value; }
        }
        #endregion Members

        #region Properties


        public string Name
        {
            set { mName = value; }
            get { return mName; }
        }

        public string Address
        {
            set { mAddress = value; }
            get { return mAddress; }
        }

        public string Phones
        {
            set { mPhones = value; }
            get { return mPhones; }
        }

        public string Fax
        {
            set { mFax = value; }
            get { return mFax; }
        }
        public string Email
        {
            set { mEmail = value; }
            get { return mEmail; }
        }

        public string Notes
        {
            set { mNotes = value; }
            get { return mNotes; }
        }
        #endregion Properties

        #region Constructors
        public KhachVIP()
        {
            this.MaKhachVIP = string.Empty;
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Phones = string.Empty;
            this.Fax = string.Empty;
            this.Email = string.Empty;

            this.Notes = string.Empty;
        }
        public KhachVIP(string MaKhachVIP, string Name, string Address, string Phones, string Fax, string Email, string Notes, bool IsActive)
        {
            this.MaKhachVIP = MaKhachVIP;
            this.Name = Name;
            this.Address = Address;
            this.Phones = Phones;
            this.Fax = string.Empty;
            this.Email = Fax;
            this.Notes = Notes;
            this.IsActive = IsActive;
        }


        #endregion Constructors

        #region Methods
        public List<KhachVIP> GetListOfKhachVIPs()
        {
            List<KhachVIP> lstKhachVIP = new List<KhachVIP>();
            DataTable dt = new DataTable();

            dt = new Data.DM.KhachVIP().GetDanhSachKhachVIPs(string.Empty);// lay ta ca
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    KhachVIP objKhachVIP = new KhachVIP();
                    objKhachVIP.MaKhachVIP = StringTools.TrimSpace(dr["Ma_KhachVIP"].ToString());
                    objKhachVIP.Name = StringTools.TrimSpace(dr["Name"].ToString());
                    objKhachVIP.Address = StringTools.TrimSpace(dr["Address"].ToString());
                    objKhachVIP.Phones = StringTools.TrimSpace(dr["Phones"].ToString());
                    objKhachVIP.Fax = StringTools.TrimSpace(dr["Fax"].ToString());
                    objKhachVIP.Email = StringTools.TrimSpace(dr["Email"].ToString());


                    objKhachVIP.Notes = dr["Notes"].ToString();
                    objKhachVIP.IsActive = dr["IsActive"].ToString() == "1" ? true : false;

                    lstKhachVIP.Add(objKhachVIP);
                }
            }

            return lstKhachVIP;
        }
        public KhachVIP GetKhachVIPByMaKhachVIP(string MaKhachVIP)
        {
            KhachVIP objKhachVIP = new KhachVIP();
            DataTable dt = new DataTable();

            dt = new Data.DM.KhachVIP().GetDanhSachKhachVIPs(MaKhachVIP);
            if (dt.Rows.Count == 1)
            {
                objKhachVIP.MaKhachVIP = StringTools.TrimSpace(dt.Rows[0]["Ma_KhachVIP"].ToString());
                objKhachVIP.Name = StringTools.TrimSpace(dt.Rows[0]["Name"].ToString());
                objKhachVIP.Address = StringTools.TrimSpace(dt.Rows[0]["Address"].ToString());
                objKhachVIP.Phones = StringTools.TrimSpace(dt.Rows[0]["Phones"].ToString());
                objKhachVIP.Fax = StringTools.TrimSpace(dt.Rows[0]["Fax"].ToString());
                objKhachVIP.Email = StringTools.TrimSpace(dt.Rows[0]["Email"].ToString());


                objKhachVIP.Notes = dt.Rows[0]["Notes"].ToString();
                objKhachVIP.IsActive = dt.Rows[0]["IsActive"].ToString() == "1" ? true : false;
            }

            return objKhachVIP;
        }

        public bool Insert()
        {
            return new Data.DM.KhachVIP().Insert(this.MaKhachVIP, this.Name, this.Address, this.Phones,
                this.Fax, this.Email, this.Notes, this.IsActive);
        }
        public bool Update()
        {
            return new Data.DM.KhachVIP().Update(this.MaKhachVIP, this.Name, this.Address, this.Phones,
    this.Fax, this.Email, this.Notes, this.IsActive);

        }
        public bool Delete(string MaKhachVIP)
        {
            return new Data.DM.KhachVIP().Delete(MaKhachVIP);
        }

        /// <summary>
        /// Ma doi tac bang rong thi se xoa toan bo T_KhachVIP
        /// </summary>
        /// <returns></returns>
        public bool DeleteAllKhachVIP()
        {
            return new Data.DM.KhachVIP().Delete(string.Empty);
        }
        /// <summary>
        /// Sinh ma doi tac, neuchua co thi gan la ID0001
        /// Neu co roi thi lay max + 1
        /// </summary>
        /// <returns>Ma tiep theo</returns>
        public static string GetNextMaKhachVIP()
        {
            try
            {
                string strMaxKey = new Data.DM.KhachVIP().GetNextMaKhachVIP();
                string strNextKey = string.Empty;

                if (strMaxKey.Length >= 6)
                {
                    string sID = strMaxKey.Substring(2, 4);
                    long ID = long.Parse(sID);
                    ID += 1;
                    sID = ID.ToString();
                    while (sID.ToString().Length < 4)
                    {
                        sID = "0" + sID;
                    }
                    return "VI" + sID;
                }
                else
                {
                    return "VI0001"; // ma dau tien
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #endregion Methods
        /// <summary>
        /// Lay thong tin cua khach VIP boi SoDienThoai
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public static KhachVIP GetKhachVIPByPhoneNumber(string PhoneNumber)
        {
            KhachVIP objKhachVIP = new KhachVIP();
            DataTable dt = new DataTable();
            dt = new Data.DM.KhachVIP().GetKhachVIPByPhoneNumber(PhoneNumber);
            if (dt.Rows.Count == 1)
            {
                objKhachVIP.MaKhachVIP = StringTools.TrimSpace(dt.Rows[0]["Ma_KhachVIP"].ToString());
                objKhachVIP.Name = StringTools.TrimSpace(dt.Rows[0]["Name"].ToString());
                objKhachVIP.Address = StringTools.TrimSpace(dt.Rows[0]["Address"].ToString());
                objKhachVIP.Phones = StringTools.TrimSpace(dt.Rows[0]["Phones"].ToString());
                objKhachVIP.Fax = StringTools.TrimSpace(dt.Rows[0]["Fax"].ToString());
                objKhachVIP.Email = StringTools.TrimSpace(dt.Rows[0]["Email"].ToString());
                objKhachVIP.Notes = dt.Rows[0]["Notes"].ToString();
                objKhachVIP.IsActive = dt.Rows[0]["IsActive"].ToString() == "1" ? true : false;
            }
            dt.Dispose();
            dt = null;
            return objKhachVIP;
        }
    }
}
