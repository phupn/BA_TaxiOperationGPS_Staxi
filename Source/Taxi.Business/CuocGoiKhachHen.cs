using System;
using System.Collections.Generic;
using System.Data;

namespace Taxi.Business
{
    public class CuocGoiKhachHen
    {
        #region Members
        //@ID bigint,
        private long mID_DieuHanh;
        public long ID_DieuHanh
        {
            get { return mID_DieuHanh; }
            set { mID_DieuHanh = value; }
        }

        private DateTime mThoiDiemBatDau;

        public DateTime ThoiDiemBatDau
        {
            get { return mThoiDiemBatDau; }
            set { mThoiDiemBatDau = value; }
        }
        private int mBaoTruocSoPhut;

        public int BaoTruocSoPhut
        {
            get { return mBaoTruocSoPhut; }
            set { mBaoTruocSoPhut = value; }
        }
        private bool mIsDaGiaiQuyet;

        public bool IsDaGiaiQuyet
        {
            get { return mIsDaGiaiQuyet; }
            set { mIsDaGiaiQuyet = value; }
        }

        private string mGhiChu;

        public string GhiChu
        {
            get { return mGhiChu; }
            set { mGhiChu = value; }
        }
        #endregion 

        public CuocGoiKhachHen() { }
        public CuocGoiKhachHen(long ID_DieuHanh, DateTime ThoiDiemBatDau, int BaoTruocSoPhut, bool IsDaGiaiQuyet,string GhiChu) 
        {
            this.ID_DieuHanh = ID_DieuHanh;
            this.ThoiDiemBatDau = ThoiDiemBatDau ;
            this.BaoTruocSoPhut= BaoTruocSoPhut;
            this.IsDaGiaiQuyet = IsDaGiaiQuyet;
            this.GhiChu = GhiChu;
        }

        #region Methods

        public static CuocGoiKhachHen GetKhachHen(long ID_DieuHanh)
        {
            CuocGoiKhachHen objKhachHen = new CuocGoiKhachHen ();
            DataTable dt = new DataTable();
            dt = new Data.CuocGoiKhachHen().GetCuocGoiKhachHens(ID_DieuHanh);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                DataRow dr = dt.Rows[0];
                objKhachHen.ID_DieuHanh = (long)dr["ID_T_TaxiOperation"];
                objKhachHen.ThoiDiemBatDau =  (DateTime)dr["ThoiDiemBatDau"];
                objKhachHen.BaoTruocSoPhut = (int)dr["BaoTruocSoPhut"];
                objKhachHen.IsDaGiaiQuyet = dr["IsDaGiaiQuyet"].ToString() == "1";
                objKhachHen.GhiChu = dr ["GhiChu"].ToString();
                 
            } 
            return objKhachHen;
        }

        public List<CuocGoiKhachHen>  GetAllKhachHenChuaXuLy()
        {
            List<CuocGoiKhachHen> listCuocGoiKhachHen = new List<CuocGoiKhachHen>();
            DataTable dt = new DataTable();
            dt = new Data.CuocGoiKhachHen().GetCuocGoiKhachHens(0);
            if ((dt != null) && (dt.Rows.Count >0))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listCuocGoiKhachHen.Add(new CuocGoiKhachHen((long)dr["ID_T_TaxiOperation"], (DateTime)dr["ThoiDiemBatDau"], (int)dr["BaoTruocSoPhut"], dr["IsDaGiaiQuyet"].ToString() == "1" ? true : false, dr["GhiChu"].ToString()));
                }
            }
            return listCuocGoiKhachHen;
        }

        public static bool CanhBaoDenGioKhachHen(CuocGoiKhachHen CuocGoiKhachHen)
        {
            // lay thoi gian cua may chu
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            // so sanh co thoi gian bao truoc chu
            int SoPhut = ( (TimeSpan)(CuocGoiKhachHen.ThoiDiemBatDau - timeServer)).Minutes ;
            if(SoPhut<= CuocGoiKhachHen.BaoTruocSoPhut )
            {
                return true;
            }
            return false;
        }


        public bool Insert_Update()
        {
            return new Data.CuocGoiKhachHen().Insert_Update(this.ID_DieuHanh, this.ThoiDiemBatDau, this.BaoTruocSoPhut, this.IsDaGiaiQuyet, this.GhiChu);
        }

        public bool Delete()
        {
            return new Data.CuocGoiKhachHen().Delete(this.ID_DieuHanh);
        }
        #endregion
    }
}
