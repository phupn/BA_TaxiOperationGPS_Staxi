using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.DM
{
    public class MemberCard
    {
        #region Properties
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

        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        /// <summary>
        /// 0 : Tra sau
        /// 1 : Tra Truoc
        /// </summary>
        private string mType;
        public string Type
        {
            get { return mType; }
            set { mType = value; }
        }

        /// <summary>
        /// Ma The
        /// </summary>
        private string mCode;
        public string Code
        {
            get { return mCode; }
            set { mCode = value; }
        }

        /// <summary>
        /// Ghi chu
        /// </summary>
        private string mNote;
        public string Note
        {
            get { return mNote; }
            set { mNote = value; }
        }

        /// <summary>
        /// Ngay cap
        /// </summary>
        private DateTime mDateOfIssue;
        public DateTime DateOfIssue
        {
            get { return mDateOfIssue; }
            set { mDateOfIssue = value; }
        }

        /// <summary>
        /// Ngay het han
        /// </summary>
        private DateTime mExpireDate;
        public DateTime ExpireDate
        {
            get { return mExpireDate; }
            set { mExpireDate = value; }
        }

        /// <summary>
        /// co hoat dong hay ko
        /// </summary>
        private bool mActive;
        public bool Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        #endregion
        public MemberCard()
        {
        }

        public MemberCard(int _ID, string _Name, string _Address, string _Type, string _Code, string _Note, DateTime _DateOfIssue, DateTime _ExpDate, bool _Active)
        {
            this.mID = _ID;
            this.mName = _Name;
            this.mAddress = _Address;
            this.mType = _Type;
            this.mCode = _Code;
            this.mNote = _Note;
            this.mDateOfIssue = _DateOfIssue;
            this.mExpireDate = _ExpDate;
            this.mActive = _Active;
        }

        public static MemberCard Parse(DataRow row)
        {
            return new MemberCard(
                int.Parse(row["ID"].ToString()),
                row["Name"].ToString(),
                row["Address"].ToString(),
                row["Type"].ToString(),
                row["Code"].ToString(),
                row["Note"].ToString(),
                DateTime.Parse(row["DateOfIssue"].ToString()),
                DateTime.Parse(row["ExpireDate"].ToString()),
                Convert.ToBoolean(row["Active"]));
        }

        /// <summary>
        /// insert 1 gara tra ve một id của gara
        /// </summary>
        public int Insert()
        {
            return new Data.DM.MemberCard().Insert(Name, Address, Type, Code, Note, DateOfIssue, ExpireDate, Active);
        }

        public bool Update()
        {
            return new Data.DM.MemberCard().Update(ID, Name, Address, Type, Code, Note, DateOfIssue, ExpireDate, Active);
        }
        /// <summary>
        /// lay thong tin cua gara by id
        /// </summary>
        public static MemberCard GetGaraByID(int ID)
        {
            DataTable dt = new Data.DM.MemberCard().GetMemberCardByID(ID);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                return Parse(dt.Rows[0]);
            }
            return null;
        }

        public static List<MemberCard> GetAllMemberCard()
        {
            List<MemberCard> lstMemberCard = new List<MemberCard>();
            DataTable dt = new Data.DM.MemberCard().GetAllMemberCard();
            foreach (DataRow row in dt.Rows)
            {
                lstMemberCard.Add(Parse(row));
            }
            return lstMemberCard;
        }

        public static List<MemberCard> GetAllMemberCard_BySearch(string _Code, string _Name, string _Address)
        {
            List<MemberCard> lstMemberCard = new List<MemberCard>();
            DataTable dt = new Data.DM.MemberCard().GetMemberCard_BySearch(_Code, _Name, _Address);
            foreach (DataRow row in dt.Rows)
            {
                lstMemberCard.Add(Parse(row));
            }
            return lstMemberCard;
        }

        public bool Delete()
        {
            return new Data.DM.MemberCard().Delete(this.ID);
        }

        public static bool CheckTonTaiTenGara(string _Code)
        {
            return new Data.DM.MemberCard().CheckTonTaiMaThe(_Code);
        }

        public static MemberCard GetMemberCardByCode(string _Code)
        {
            DataTable dt = new Data.DM.MemberCard().GetMemberCard_ByCode(_Code);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                return Parse(dt.Rows[0]);
            }
            return null;
        }
    }
}
