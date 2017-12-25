using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TaxiOperation_MoiGioi
{
    public class TDoiTac
    {
        #region Members

        private string mMa_DoiTac;
        public string Ma_DoiTac
        {
            get { return mMa_DoiTac; }
            set { mMa_DoiTac = value; }
        }

        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        private string mName;
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        private string mTenDuong;
        public string TenDuong
        {
            get { return mTenDuong; }
            set { mTenDuong = value; }
        }

        private double mKinhDo;
        public double KinhDo
        {
            get { return mKinhDo; }
            set { mKinhDo = value; }
        }

        private double mViDo;
        public double ViDo
        {
            get { return mViDo; }
            set { mViDo = value; }
        }
        #endregion

        public static TDoiTac getDoiTac(DataRow dr)
        {
            try
            {
                TDoiTac TDoiTac = new TDoiTac();
                TDoiTac.Name = dr["Tên môi giới"] != null ? dr["Tên môi giới"].ToString() : "";
                TDoiTac.Address = dr["Địa chỉ"] != null ? dr["Địa chỉ"].ToString() : "";
                TDoiTac.TenDuong = dr["Tên đường"] != null ? dr["Tên đường"].ToString() : "";
                TDoiTac.Ma_DoiTac = dr["Mã MG"] != null ? dr["Mã MG"].ToString() : "";
                if (dr["Kinh độ"] != null && dr["Kinh độ"].ToString() != "")
                {
                    TDoiTac.KinhDo = float.Parse(dr["Kinh độ"].ToString());
                }
                if (dr["Vĩ độ"] != null && dr["Vĩ độ"].ToString() != "")
                {
                    TDoiTac.ViDo = float.Parse(dr["Vĩ độ"].ToString());
                }
                return TDoiTac;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
