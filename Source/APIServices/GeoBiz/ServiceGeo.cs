using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace APIServices.GeoBiz
{
    public class ServiceGeo
    {
        private string mDonVi;
        public string DonVi
        {
            get { return mDonVi; }
            set { mDonVi = value; }
        }
        private string mChiDan;
        public string ChiDan
        {
            get { return mChiDan; }
            set { mChiDan = value; }
        }
        private string mMoTa;
        public string MoTa
        {
            get { return mMoTa; }
            set { mMoTa = value; }
        }
        private float mKhoangCach;
        public float KhoangCach
        {
            get { return mKhoangCach; }
            set { mKhoangCach = value; }
        }

        private string mKinhDo;
        public string KinhDo
        {
            get { return mKinhDo; }
            set { mKinhDo = value; }
        }
        private string mViDo;
        public string ViDo
        {
            get { return mViDo; }
            set { mViDo = value; }
        }
    }
}
