using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using TaxiOperation;

namespace TaxiOperation_Services
{
    [Serializable]
    public class RouterItem
    {
        public float Distance { get; set; }
        public float Monney { get; set; }
        public string Result { get; set; }
    }
    public class TinhToanGiaTien
    {
        /// <summary>
        /// Tính toán giá tiền theo loại xe và khoảng cách
        /// </summary>
        /// <param name="SoKm"></param>
        /// <param name="LoaiXe"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        public float TinhTienBinhThuong(float SoKm, int LoaiXe, Brand brand)
        {
            if (LoaiXe <= 0 || LoaiXe > 7) return 0;

            TinhTienTheoKm objTinhTien = new TinhTienTheoKm(SoKm, LoaiXe, brand);
            if (objTinhTien != null)
            {
                return objTinhTien.TongTien1Chieu;
            }
            else return 0;
        }

        /// <summary>
        /// Lấy khoảng cách điểm đi và điểm đến theo google
        /// </summary>
        /// <param name="fromLat"></param>
        /// <param name="fromLng"></param>
        /// <param name="toLat"></param>
        /// <param name="toLng"></param>
        /// <returns></returns>
        public float CalDistance(float fromLat, float fromLng, float toLat, float toLng)
        {
            try
            {
                double distance = 0;
                OnlineService.CarOnlineSystemServiceClient serviceOnline = new OnlineService.CarOnlineSystemServiceClient();
                OnlineService.CarOnlineSystemServiceLatLngBase from = new OnlineService.CarOnlineSystemServiceLatLngBase();
                from.Lat = fromLat;
                from.Lng = fromLng;
                OnlineService.CarOnlineSystemServiceLatLngBase to = new OnlineService.CarOnlineSystemServiceLatLngBase();
                to.Lat = toLat;
                to.Lng = toLng;
                distance = serviceOnline.CalDistanceRouter(from, to) / 1000;

                return (float)distance;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CalDistance : ", ex);
                return 0;
            }
        }
    }

    public class TinhTienTheoKm
    {
        #region Members
        private float mKmMoCua;

        public float KmMoCua
        {
            get { return mKmMoCua; }
            set { mKmMoCua = value; }
        }
        private float mGiaMoCua;

        public float GiaMoCua
        {
            get { return mGiaMoCua; }
            set { mGiaMoCua = value; }
        }
        private float mKmNguong1;

        public float KmNguong1
        {
            get { return mKmNguong1; }
            set { mKmNguong1 = value; }
        }
        private float mGiaNguong1;

        public float GiaNguong1
        {
            get { return mGiaNguong1; }
            set { mGiaNguong1 = value; }
        }

        private float mGiaNguong2;

        public float GiaNguong2
        {
            get { return mGiaNguong2; }
            set { mGiaNguong2 = value; }
        }

        private float mKmNguong2;
        public float KmNguong2
        {
            get { return mKmNguong2; }
            set { mKmNguong2 = value; }
        }

        private float mKmNguong3;
        public float KmNguong3
        {
            get { return mKmNguong3; }
            set { mKmNguong3 = value; }
        }

        private float mGiaNguong3;
        public float GiaNguong3
        {
            get { return mGiaNguong3; }
            set { mGiaNguong3 = value; }
        }

        private float mN1_ChieuDiTu;
        public float N1_ChieuDiTu
        {
            get { return mN1_ChieuDiTu; }
            set { mN1_ChieuDiTu = value; }
        }

        private float mN1_ChieuDiDen;
        public float N1_ChieuDiDen
        {
            get { return mN1_ChieuDiDen; }
            set { mN1_ChieuDiDen = value; }
        }

        private float mN1_Giam;
        public float N1_Giam
        {
            get { return mN1_Giam; }
            set { mN1_Giam = value; }
        }

        private float mN2_ChieuDiTu;
        public float N2_ChieuDiTu
        {
            get { return mN2_ChieuDiTu; }
            set { mN2_ChieuDiTu = value; }
        }

        private float mN2_Giam;
        public float N2_Giam
        {
            get { return mN2_Giam; }
            set { mN2_Giam = value; }
        }

        private bool mIsAll;
        public bool IsAll
        {
            get { return mIsAll; }
            set { mIsAll = value; }
        }

        private float mKmNguong2Chieu;
        public float KmNguong2Chieu
        {
            get { return mKmNguong2Chieu; }
            set { mKmNguong2Chieu = value; }
        }
        private float mTiLeGiamGia2Chieu;

        public float TiLeGiamGia2Chieu
        {
            get { return mTiLeGiamGia2Chieu; }
            set { mTiLeGiamGia2Chieu = value; }
        }
        private int mLoaiXe;

        public int LoaiXe
        {
            get { return mLoaiXe; }
            set { mLoaiXe = value; }
        }

        private float mTongTien1Chieu;

        public float TongTien1Chieu
        {
            get { return mTongTien1Chieu; }

        }
        private float mTongTien2Chieu;

        public float TongTien2Chieu
        {
            get { return mTongTien2Chieu; }
            set { mTongTien2Chieu = value; }
        }
        private string mThongTinThueBao;

        public string ThongTinThueBao
        {
            get { return mThongTinThueBao; }
            set { mThongTinThueBao = value; }
        }

        /// <summary>
        /// 0 : Cước Ngày
        /// 1 : Cước Đêm
        /// </summary>
        private bool mLoaiCuoc;
        public bool LoaiCuoc
        {
            get { return mLoaiCuoc; }
            set { mLoaiCuoc = value; }
        }

        #endregion

        public TinhTienTheoKm()
        {
        }

        public TinhTienTheoKm(float SoKm, int LoaiXe, Brand brand)
        {
            try
            {
                TinhTienTheoKm objTinhTien = GetThongSoTinhTen(LoaiXe, brand);
                GiaMoCua = objTinhTien.GiaMoCua;
                KmMoCua = objTinhTien.KmMoCua;
                KmNguong1 = objTinhTien.KmNguong1;
                GiaNguong1 = objTinhTien.GiaNguong1;
                KmNguong2 = objTinhTien.KmNguong2;
                GiaNguong2 = objTinhTien.GiaNguong2;
                KmNguong3 = objTinhTien.KmNguong3;
                GiaNguong3 = objTinhTien.GiaNguong3;
                N1_ChieuDiTu = objTinhTien.N1_ChieuDiTu;
                N1_ChieuDiDen = objTinhTien.N1_ChieuDiDen;
                N1_Giam = objTinhTien.N1_Giam;
                N2_ChieuDiTu = objTinhTien.N2_ChieuDiTu;
                N2_Giam = objTinhTien.N2_Giam;
                IsAll = objTinhTien.IsAll;

                KmNguong2Chieu = objTinhTien.KmNguong2Chieu;
                TiLeGiamGia2Chieu = objTinhTien.TiLeGiamGia2Chieu;
                ThongTinThueBao = objTinhTien.ThongTinThueBao;

                mTongTien1Chieu = TinhTien1Chieu_New(SoKm);
                if (SoKm >= N1_ChieuDiTu && SoKm <= N1_ChieuDiDen && N1_Giam > 0)
                {
                    mTongTien2Chieu = mTongTien1Chieu * ((100 - N1_Giam) / 100);
                }
                else if (SoKm > N2_ChieuDiTu && N2_Giam > 0)
                {
                    if (IsAll)
                    {
                        mTongTien2Chieu = mTongTien1Chieu * ((100 - N2_Giam) / 100);
                    }
                    else
                    {
                        float TienGiamNgon = TinhTien1Chieu_New(SoKm - N2_ChieuDiTu);
                        mTongTien2Chieu = (mTongTien1Chieu - TienGiamNgon) * ((100 - N2_Giam) / 100);
                    }
                }
                else
                {
                    mTongTien2Chieu = mTongTien1Chieu;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CalDistance : ", ex);
            }
        }

        /// <summary>
        /// Lấy thông số tính tiền theo loại xe của chi nhánh tương ứng
        /// </summary>
        /// <param name="LoaiXe"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static TinhTienTheoKm GetThongSoTinhTen(int LoaiXe, Brand brand)
        {
            try
            {
                TinhTienTheoKm objTinhTien = new TinhTienTheoKm();

                objTinhTien.LoaiXe = 0;
                DataTable dt = new DataTable();
                dt = new DAO().GetThongSoTinhTien(LoaiXe, brand);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    objTinhTien.KmMoCua = float.Parse(dt.Rows[0]["KmMoCua"].ToString());
                    objTinhTien.GiaMoCua = float.Parse(dt.Rows[0]["GiaMoCua"].ToString());
                    objTinhTien.KmNguong1 = float.Parse(dt.Rows[0]["KmNguong1"].ToString());
                    objTinhTien.GiaNguong1 = float.Parse(dt.Rows[0]["GiaNguong1"].ToString());
                    objTinhTien.KmNguong2 = dt.Rows[0]["KmNguong2"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["KmNguong2"].ToString());
                    objTinhTien.GiaNguong2 = dt.Rows[0]["GiaNguong2"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["GiaNguong2"].ToString());
                    objTinhTien.KmNguong3 = dt.Rows[0]["KmNguong3"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["KmNguong3"].ToString());
                    objTinhTien.GiaNguong3 = dt.Rows[0]["GiaNguong3"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["GiaNguong3"].ToString());
                    objTinhTien.N1_ChieuDiTu = dt.Rows[0]["N1_ChieuDiTu"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["N1_ChieuDiTu"].ToString());
                    objTinhTien.N1_ChieuDiDen = dt.Rows[0]["N1_ChieuDiDen"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["N1_ChieuDiDen"].ToString());
                    objTinhTien.N1_Giam = dt.Rows[0]["N1_Giam"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["N1_Giam"].ToString());
                    objTinhTien.N2_ChieuDiTu = dt.Rows[0]["N2_ChieuDiTu"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["N2_ChieuDiTu"].ToString());
                    objTinhTien.N2_Giam = dt.Rows[0]["N2_Giam"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["N2_Giam"].ToString());
                    objTinhTien.IsAll = dt.Rows[0]["IsAll"] != DBNull.Value && bool.Parse(dt.Rows[0]["IsAll"].ToString());

                    objTinhTien.KmNguong2Chieu = dt.Rows[0]["KmNguong2Chieu"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["KmNguong2Chieu"].ToString());
                    objTinhTien.TiLeGiamGia2Chieu = dt.Rows[0]["TiLeGiamGiaHaiChieu"] == DBNull.Value ? 0 : float.Parse(dt.Rows[0]["TiLeGiamGiaHaiChieu"].ToString());
                    objTinhTien.LoaiXe = (int)dt.Rows[0]["LoaiXe"];
                    if (dt.Rows[0]["ThongTinThueBao"] != null)
                        objTinhTien.ThongTinThueBao = dt.Rows[0]["ThongTinThueBao"].ToString();
                }
                return objTinhTien;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetThongSoTinhTen : ", ex);
                return null;
            }
        }

        private float TinhTien1Chieu_New(float SoKm)
        {
            float CuocNguong1 = 0;
            float CuocNguong2 = 0;
            float CuocNguong3 = 0;

            if (SoKm <= KmMoCua)
            {
                CuocNguong1 = GiaMoCua;
                CuocNguong2 = 0;
            }
            else if ((SoKm > KmMoCua) && (SoKm <= KmNguong1) && GiaNguong1 > 0)
            {
                CuocNguong1 = GiaMoCua + (SoKm - KmMoCua) * GiaNguong1;
                CuocNguong2 = 0;
            }

            else if ((SoKm > KmMoCua) && (SoKm > KmNguong1) && (SoKm <= KmNguong2) && GiaNguong2 > 0)
            {
                CuocNguong1 = GiaMoCua + (KmNguong1 - KmMoCua) * GiaNguong1;
                CuocNguong2 = (SoKm - KmNguong1) * GiaNguong2;
            }
            else if ((SoKm > KmMoCua) && (SoKm > KmNguong2) && (SoKm <= KmNguong3) && GiaNguong3 > 0)
            {
                CuocNguong1 = GiaMoCua + (KmNguong1 - KmMoCua) * GiaNguong1;
                CuocNguong2 = (KmNguong2 - KmNguong1) * GiaNguong2;
                CuocNguong3 = (SoKm - KmNguong2) * GiaNguong3;
            }
            float Cuoc1Chieu = CuocNguong1 + CuocNguong2 + CuocNguong3;

            return Cuoc1Chieu;
        }
    }
}