using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Business
{
    public class CuocGoiDoiTac
    {
#region Properties
        private string mMaDoiTac;
        public string MaDoiTac
        {
            get { return mMaDoiTac; }
            set { mMaDoiTac = value; }
        }
        private DateTime mThoiDiemGoi;

        public DateTime ThoiDiemGoi
        {
            get { return mThoiDiemGoi; }
            set { mThoiDiemGoi = value; }
        }

        private string  mSoDienThoai;

        public string SoDienThoai
        {
            get { return mSoDienThoai; }
            set { mSoDienThoai = value; }
        }

        private int mChonTaxi4Cho;

        public int ChonTaxi4Cho
        {
            get { return mChonTaxi4Cho; }
            set { mChonTaxi4Cho = value; }
        }
        private int mChonTaxi7Cho;

        public int ChonTaxi7Cho
        {
            get { return mChonTaxi7Cho; }
            set { mChonTaxi7Cho = value; }
        }
        private bool mSanBay_DuongDai;

        public bool SanBay_DuongDai
        {
            get { return mSanBay_DuongDai; }
            set { mSanBay_DuongDai = value; }
        }

        private bool mIsSuccess;

        public bool IsSuccess
        {
            get { return mIsSuccess; }
            set { mIsSuccess = value; }
        }
    
    #endregion Properties

    #region Methods
        public bool Insert()
        {
            return new Data.CuocGoiDoiTac().Insert(this.MaDoiTac, this.ThoiDiemGoi,this.SoDienThoai,this.ChonTaxi4Cho, this.ChonTaxi7Cho, this.SanBay_DuongDai, this.IsSuccess);
        }
    #endregion Methods
}}
