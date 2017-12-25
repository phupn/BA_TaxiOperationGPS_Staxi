using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business
{
    /// <summary>
    /// input : Loai xe, so km
    /// tra ve gia tri 1 chieu, 2 chieu
    /// gia tri cac 
    /// [KmMoCua] [float] NULL,
	/// [GiaMoCua] [float] NULL,
	/// [KmNguong1] [float] NULL,
	/// [GiaNguong1] [float] NULL,
	/// [GiaNguong2] [float] NULL,
	/// [KmNguong2Chieu] [float] NULL,
	/// [TiLeGiamGiaHaiChieu] [float] NULL,
    /// [LoaiXe] [int] NULL
    /// </summary>
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

       public TinhTienTheoKm(float KmMoCua, float GiaMoCua, float KmNguong1, float GiaNguong1, float GiaNguong2, float KmNguong2Chieu, float TiLeGiamGiaHaiChieu, int LoaiXe, string _ThongTinThueBao,bool _LoaiCuoc)
       {
           this.KmMoCua = KmMoCua;
           this.GiaMoCua = GiaMoCua;
           this.KmNguong1 = KmNguong1;
           this.GiaNguong1 = GiaNguong1;
           this.GiaNguong2 = GiaNguong2;
           this.KmNguong2Chieu = KmNguong2Chieu;
           this.TiLeGiamGia2Chieu = TiLeGiamGiaHaiChieu;
           this.LoaiXe = LoaiXe;
           this.ThongTinThueBao = _ThongTinThueBao;
           this.LoaiCuoc = _LoaiCuoc;
       }

       public TinhTienTheoKm(float KmMoCua, float GiaMoCua,
                           float KmNguong1, float GiaNguong1,
                           float KmNguong2, float GiaNguong2,
                           float KmNguong3, float GiaNguong3,
                           float N1_ChieuDiTu, float N1_ChieuDiDen, float N1_Giam,
                           float N2_ChieuDiTu, float N2_Giam, bool IsAll,
                           float KmNguong2Chieu,
                           float TiLeGiamGiaHaiChieu,
                           int LoaiXe,
                           string _ThongTinThueBao)
       {
           this.KmMoCua = KmMoCua;
           this.GiaMoCua = GiaMoCua;
           this.KmNguong1 = KmNguong1;
           this.GiaNguong1 = GiaNguong1;
           this.KmNguong2 = KmNguong2;
           this.GiaNguong2 = GiaNguong2;
           this.KmNguong3 = KmNguong3;
           this.GiaNguong3 = GiaNguong3;
           this.N1_ChieuDiTu = N1_ChieuDiTu;
           this.N1_ChieuDiDen = N1_ChieuDiDen;
           this.N1_Giam = N1_Giam;
           this.N2_ChieuDiTu = N2_ChieuDiTu;
           this.N2_Giam = N2_Giam;
           this.IsAll = IsAll;
           this.KmNguong2Chieu = KmNguong2Chieu;
           this.TiLeGiamGia2Chieu = TiLeGiamGiaHaiChieu;
           this.LoaiXe = LoaiXe;
           this.ThongTinThueBao = _ThongTinThueBao;

       }
       //public TinhTienTheoKm(int LoaiXe, float SoKm)
       //{
       //    TinhTienTheoKm objTinhTien = TinhTienTheoKm.GetThongSoTinhTen(LoaiXe);
       //    this.GiaMoCua = objTinhTien.GiaMoCua;
       //    this.KmMoCua = objTinhTien.KmMoCua;
       //    this.GiaNguong1 = objTinhTien.GiaNguong1;
       //    this.GiaNguong2 = objTinhTien.GiaNguong2;
       //    this.KmNguong1 = objTinhTien.KmNguong1;
       //    this.KmNguong2Chieu = objTinhTien.KmNguong2Chieu;
       //    this.LoaiXe = objTinhTien.LoaiXe;
       //    this.TiLeGiamGia2Chieu = objTinhTien.TiLeGiamGia2Chieu;
       //    this.ThongTinThueBao = objTinhTien.ThongTinThueBao;
       //    this.mTongTien1Chieu = TinhTien1Chieu(SoKm);
          
       //    if (SoKm <= KmNguong2Chieu) mTongTien2Chieu = mTongTien1Chieu;
       //    else this.mTongTien2Chieu =   ((100 - TiLeGiamGia2Chieu) / 100) * mTongTien1Chieu;
            
       //}

       public TinhTienTheoKm(int LoaiXe, float SoKm,bool flgTong=false)
       {
           TinhTienTheoKm objTinhTien = GetThongSoTinhTen(LoaiXe);
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
           if (flgTong)
           {
               SoKm = SoKm / 2;
           }

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
       public TinhTienTheoKm(bool LoaiCuoc,int LoaiXe, float SoKm)
       {
           TinhTienTheoKm objTinhTien = GetThongSoTinhTen(LoaiCuoc,LoaiXe);
           this.GiaMoCua = objTinhTien.GiaMoCua;
           this.KmMoCua = objTinhTien.KmMoCua;
           this.GiaNguong1 = objTinhTien.GiaNguong1;
           this.GiaNguong2 = objTinhTien.GiaNguong2;
           this.KmNguong1 = objTinhTien.KmNguong1;
           this.KmNguong2Chieu = objTinhTien.KmNguong2Chieu;
           this.LoaiXe = objTinhTien.LoaiXe;
           this.TiLeGiamGia2Chieu = objTinhTien.TiLeGiamGia2Chieu;
           this.ThongTinThueBao = objTinhTien.ThongTinThueBao;
           this.mTongTien1Chieu = TinhTien1Chieu(SoKm);

           if (SoKm <= KmNguong2Chieu) mTongTien2Chieu = mTongTien1Chieu;
           else this.mTongTien2Chieu = ((100 - TiLeGiamGia2Chieu) / 100) * mTongTien1Chieu;

       }

       /// <summary>
       //ham tinh toan gia cuoc cho TaxiCP
       //   - lay thong so khai bao cua giá cước
       //   - neu IsTaxi = true thi tinh cho taxicp
       //       //Công thức tính : 
       //2 chieu : 4 cho
       //  - [12 k + 29km x 10k +  ((tongkm- 30) x 6.5 ) ]     -->  1 chieu
       //  - 12 k + 29km x 10k +  ((tongkm- 30) x 6.5 )  x 07   --> 2chieu
       //2 chieu : 7 chỗ
       //   - [12 k + 29km x 10k + (tongkm- 30) x 7.5 )  ]  1 chieu
       //     12 k + 29km x 10k + (tongkm- 30) x 7.5 )  x 0.7   -->  2 chieu
       /// </summary>
       public TinhTienTheoKm(bool LoaiCuoc, int LoaiXe, float SoKm, bool IsTaxiCP)
       {
           TinhTienTheoKm objTinhTien = TinhTienTheoKm.GetThongSoTinhTen(LoaiCuoc, LoaiXe);
          
           this.GiaMoCua = objTinhTien.GiaMoCua;
           this.KmMoCua = objTinhTien.KmMoCua;
           this.GiaNguong1 = objTinhTien.GiaNguong1;
           this.GiaNguong2 = objTinhTien.GiaNguong2;
           this.KmNguong1 = objTinhTien.KmNguong1;
           this.KmNguong2Chieu = objTinhTien.KmNguong2Chieu;
           this.LoaiXe = objTinhTien.LoaiXe;
           this.TiLeGiamGia2Chieu = objTinhTien.TiLeGiamGia2Chieu;

           this.mTongTien1Chieu = TinhTien1Chieu_CP(SoKm);
           this.mTongTien2Chieu = TinhTien2Chieu_CP(SoKm*2);
       }

       public  float TinhTien2Chieu_CP(float SoKm)
       {
           if (SoKm < 2 * this.KmNguong2Chieu) return this.TinhTien1Chieu_CP(SoKm);

           // ngươc lại
           // tính ra tổng số tình của đi một chiều với KM trên (1)
           // Tổng tiền  = (1) /2 chia đôi + ( (1)/2 chia đôi* % giảm giá)

           float TongTienDi1Chieu = this.TinhTien1Chieu_CP(SoKm);
           return (TongTienDi1Chieu / 2 )+ ((TongTienDi1Chieu/2)*(100-this.TiLeGiamGia2Chieu)/100); 
       }

       /// <summary>
       /// tinh tien theo Km cho TaxiCP
       //2 chieu : 4 cho
       //  - [12 k + 29km x 10k +  ((tongkm- 30) x 6.5 ) ]     -->  1 chieu
       //  - 12 k + 29km x 10k +  ((tongkm- 30) x 6.5 )  x 07   --> 2chieu
       //2 chieu : 7 chỗ
       //   - [12 k + 29km x 10k + (tongkm- 30) x 7.5 )  ]  1 chieu
       //     12 k + 29km x 10k + (tongkm- 30) x 7.5 )  x 0.7   -->  2 chieu
       /// </summary>
       public  float TinhTien1Chieu_CP(float SoKm)
       {
           float Cuoc1Chieu = 0;
           float CuocNguong1 = 0;
           float CuocNguong2 = 0;

           if (SoKm <= KmMoCua)
           {
               CuocNguong1 = GiaMoCua;
               CuocNguong2 = 0;
           }
           else if ((SoKm > KmMoCua) && (SoKm <= KmNguong1))
           {
               CuocNguong1 = GiaMoCua + (SoKm - KmMoCua) * GiaNguong1;
               CuocNguong2 = 0;
           }
           else if (SoKm > KmNguong1)
           {
               CuocNguong1 = GiaMoCua + (KmNguong1 - KmMoCua) * GiaNguong1;
               CuocNguong2 = (SoKm - KmNguong1) * GiaNguong2;
           }
           Cuoc1Chieu = CuocNguong1 + CuocNguong2;

           return Cuoc1Chieu;
       }

       private   static TinhTienTheoKm GetThongSoTinhTen(bool LoaiCuoc, int LoaiXe)
       {
           TinhTienTheoKm objTinhTien = new TinhTienTheoKm();
          
           objTinhTien.LoaiXe = 0;
           DataTable dt = new DataTable();
           dt = new Data.TinhTienTheoKm().GetThongSoTinhTien(LoaiCuoc, LoaiXe);
           if ((dt != null) && (dt.Rows.Count > 0))
           {
               objTinhTien.KmMoCua =   float.Parse (dt.Rows[0]["KmMoCua"].ToString ());
               objTinhTien.GiaMoCua = float.Parse (dt.Rows[0]["GiaMoCua"].ToString ());
               objTinhTien.KmNguong1 = float.Parse (dt.Rows[0]["KmNguong1"].ToString ());
               objTinhTien.GiaNguong1 = float.Parse (dt.Rows[0]["GiaNguong1"].ToString ());
               objTinhTien.GiaNguong2 = float.Parse (dt.Rows[0]["GiaNguong2"].ToString ());
               objTinhTien.KmNguong2Chieu = float.Parse (dt.Rows[0]["KmNguong2Chieu"].ToString ());
               objTinhTien.TiLeGiamGia2Chieu  = float.Parse (dt.Rows[0]["TiLeGiamGiaHaiChieu"].ToString ());
               objTinhTien.LoaiXe = (int)dt.Rows[0]["LoaiXe"];
               objTinhTien.LoaiCuoc = Convert.ToBoolean( dt.Rows[0]["LoaiCuoc"]);
               if (dt.Rows[0]["ThongTinThueBao"] != null)
                   objTinhTien.ThongTinThueBao = dt.Rows[0]["ThongTinThueBao"].ToString();

               
           }
            return objTinhTien;
       }

       public static TinhTienTheoKm GetThongSoTinhTen(int LoaiXe)
       {
           TinhTienTheoKm objTinhTien = new TinhTienTheoKm();

           objTinhTien.LoaiXe = 0;
           DataTable dt = new DataTable();
           dt = new Data.TinhTienTheoKm().GetThongSoTinhTien(LoaiXe);
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

       private float TinhTien1Chieu(float SoKm)
       {
           float Cuoc1Chieu = 0;
           float CuocNguong1 = 0;
           float CuocNguong2 =0;

           if (SoKm <= KmMoCua)
           {
               CuocNguong1 = GiaMoCua;
               CuocNguong2 = 0;
           }
           else if((SoKm >KmMoCua) && (SoKm <= KmNguong1 ))
           {
               CuocNguong1 = GiaMoCua + (SoKm - KmMoCua) * GiaNguong1;
               CuocNguong2 = 0;
           }
           else if  (SoKm > KmNguong1) 
           {
               CuocNguong1 = GiaMoCua + (KmNguong1  - KmMoCua) * GiaNguong1;
               CuocNguong2 = (SoKm - KmNguong1) * GiaNguong2;
           }
           Cuoc1Chieu = CuocNguong1 + CuocNguong2;

           return Cuoc1Chieu;
       }

       public bool Update()
       {
           try
           {
               return new Data.TinhTienTheoKm().Update(this.KmMoCua, this.GiaMoCua, this.KmNguong1, this.GiaNguong1, this.GiaNguong2, this.KmNguong2Chieu, this.TiLeGiamGia2Chieu, this.LoaiXe, this.ThongTinThueBao, this.LoaiCuoc);
           }
           catch (Exception ex)
           {
               LogError.WriteLogError("TinhTienTheoKm.Update", ex);
               return false;
           }
       }

       public bool Update_New()
       {
           try
           {
               return new Data.TinhTienTheoKm().Update_New(this.KmMoCua, this.GiaMoCua, this.KmNguong1, this.GiaNguong1, this.KmNguong2, this.GiaNguong2, this.KmNguong3, this.GiaNguong3, this.N1_ChieuDiTu, this.N1_ChieuDiDen, this.N1_Giam, this.N2_ChieuDiTu, this.N2_Giam, this.IsAll, this.KmNguong2Chieu, this.TiLeGiamGia2Chieu, this.LoaiXe, this.ThongTinThueBao);
           }
           catch (Exception ex)
           {
               LogError.WriteLogError("TinhTienTheoKm.Update_New", ex);
               return false;
           }
       }
       public bool Insert()
       {
           try
           {
               return new Data.TinhTienTheoKm().Insert(this.KmMoCua, this.GiaMoCua, this.KmNguong1, this.GiaNguong1, this.KmNguong2, this.GiaNguong2, this.KmNguong3, this.GiaNguong3, this.N1_ChieuDiTu, this.N1_ChieuDiDen, this.N1_Giam, this.N2_ChieuDiTu, this.N2_Giam, this.IsAll, this.KmNguong2Chieu, this.TiLeGiamGia2Chieu, this.LoaiXe, this.ThongTinThueBao);
           }
           catch (Exception ex)
           {
               LogError.WriteLogError("TinhTienTheoKm.Insert", ex);
               return false;
           }
       }

       public DataTable GetAllLoaiXe()
       {
           try
           {
               return new Data.TinhTienTheoKm().GetAllLoaiXe();
           }
           catch (Exception ex)
           {
               LogError.WriteLogError("TinhTienTheoKm.GetAllLoaiXe", ex);
               return null;
           }
       }
       public DataTable GetAllLoaiXe_Truck()
       {
           try
           {
               return new Data.TinhTienTheoKm().GetAllLoaiXe_Truck();
           }
           catch (Exception ex)
           {
               LogError.WriteLogError("TinhTienTheoKm.GetAllLoaiXe", ex);
               return null;
           }

       }

       #region DIADANH_KM
       /// <summary>
       /// kiem tra trung tên dia danh. loại bỏ tên với ID đang xét
       /// </summary>
       /// <param name="ID"></param>
       /// <param name="TenDiaDanh"></param>
       /// <returns></returns>
       public static bool CheckTrungTen(int ID, string TenDiaDanh)
       {
          return   new Data.TinhTienTheoKm().CheckTrungTen(ID, TenDiaDanh);
       }

         /// <summary>
       /// tim kiếm thông tinđạ danh
       /// </summary>
       /// <param name="TenDiaDanh"></param>
       /// <returns></returns>
       public static DataTable SearchDiaDanhByTen(string TenDiaDanh)
       {
           return new Data.TinhTienTheoKm().SearchDiaDanhByTen(TenDiaDanh);
       }
        /// <summary>
       /// Insert địa danh Km
       /// </summary>
       /// <param name="TenDiaDanh"></param>
       /// <param name="Km"></param>
       /// <returns></returns>
       public static  bool InsertDiaDanhKm(string TenDiaDanh, int Km)
       {
           return new Data.TinhTienTheoKm().InsertDiaDanhKm(TenDiaDanh, Km);
       }
       /// <summary>
       /// update dia danh Km
       /// </summary>
       /// <param name="ID"></param>
       /// <param name="TenDiaDanh"></param>
       /// <param name="Km"></param>
       /// <returns></returns>
       public static  bool UpdateDiaDanhKm(int ID, string TenDiaDanh, int Km)
       {
           return new Data.TinhTienTheoKm().UpdateDiaDanhKm(ID, TenDiaDanh, Km);
       }

       public static DataTable GetAllDiaDanh()
       {
           return new Data.TinhTienTheoKm().GetAllDiaDanh();
       }      

       public static bool DeleteDiaDanhKm(int ID)
       {
           return new Data.TinhTienTheoKm().DeleteDiaDanhKm(ID);
       }

       #endregion DIADANH_KM
   }


}
