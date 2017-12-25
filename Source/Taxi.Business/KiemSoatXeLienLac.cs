using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;

namespace Taxi.Business
{
    public  class KiemSoatXeLienLac
    {
            
        #region Properties

        private string mSoHieuXe;

        public string SoHieuXe
        {
          get { return mSoHieuXe; }
          set { mSoHieuXe = value; }
        }
         
        private DateTime mThoiDiemBao;

        public DateTime ThoiDiemBao
        {
          get { return mThoiDiemBao; }
          set { mThoiDiemBao = value; }
        }

        private string mMaLaiXe;
        public string MaLaiXe
        {
          get { return mMaLaiXe; }
          set { mMaLaiXe = value; }
        }

        private string mViTriDiemBao;

        public string ViTriDiemBao
        {
          get { return mViTriDiemBao; }
          set { mViTriDiemBao = value; }
        }
        private string mViTriDiemDen;

        public string ViTriDiemDen
        {
          get { return mViTriDiemDen; }
          set { mViTriDiemDen = value; }
        }

        private string _ViTri;

        public string ViTri
        {
            get {
                if (mViTriDiemDen != null && mViTriDiemDen.Length > 0)
                    return mViTriDiemBao + "-" + mViTriDiemDen;
                else return mViTriDiemBao;
            }
             
        }

        private LoaiChoKhach mLoaiChoKhach;

        public LoaiChoKhach  LoaiChoKhach
        {
          get { return mLoaiChoKhach; }
          set { mLoaiChoKhach = value; }
        }

        private LoaiChieuChoKhach mChieuChoKhach;
        /// <summary>
        /// chiều chở khách
        /// </summary>
        public LoaiChieuChoKhach  ChieuChoKhach
        {
            get { return mChieuChoKhach; }
            set { mChieuChoKhach = value; }
        }

        private KieuLaiXeBao mTrangThaiLaiXeBao;

        public KieuLaiXeBao TrangThaiLaiXeBao
        {
          get { return mTrangThaiLaiXeBao; }
          set { mTrangThaiLaiXeBao = value; }
        }
        private string mGhiChu;

        public string GhiChu
        {
            get { return mGhiChu; }
            set { mGhiChu = value; }
        }

        private DateTime mThoiDiemVe;

        public DateTime ThoiDiemVe
        {
            get { return mThoiDiemVe; }
            set { mThoiDiemVe = value; }
        }

        public bool mIsHoatDong;
        public bool IsHoatDong
        {
          get { return mIsHoatDong; }
          set { mIsHoatDong = value; }
        }

        public bool mIsMatLienLac;


        public bool IsMatLienLac
        {
            get { return mIsMatLienLac; }
            set { mIsMatLienLac = value; }
        }

        private DateTime mTongDaiCheckCuoi;
        /// <summary>
        /// tong dai check lan gan day
        /// </summary>
        public DateTime TongDaiCheckCuoi
        {
            get { return mTongDaiCheckCuoi; }
            set { mTongDaiCheckCuoi = value; }
        }

        private string _BienSoXe;

        public string BienSoXe
        {
            get { return _BienSoXe; }
            set { _BienSoXe = value; }
        }
        private string _TenGara;

        public string TenGara
        {
            get { return _TenGara; }
            set { _TenGara = value; }
        }

        private string _TenSanh;

        public string TenSanh
        {
            get { return _TenSanh; }
            set { _TenSanh = value; }
        }

        private string _NoiDungSuCo;
        public string NoiDungSuCo
        {
            get { return _NoiDungSuCo; }
            set { _NoiDungSuCo = value; }
        }

        private string _KetQuaXuLy;
        public string KetQuaXuLy
        {
            get { return _KetQuaXuLy; }
            set { _KetQuaXuLy = value; }
        }

        private string _CreatedBy;
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        private Nullable<DateTime> _CreatedDate;
        public Nullable<DateTime> CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private string _UpdatedBy;
        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }

        private Nullable<DateTime> _UpdatedDate;
        public Nullable<DateTime> UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }

        public int TrangThaiTong
        {
            get { 
                //matll : đỏ 1
                //dh : blue 2
                //ve: đen 3
                //nghỉ : vàng  4
                //xe sbdd : green 5

                TimeSpan tsp = new TimeSpan();
                tsp = DateTime.Now - this.ThoiDiemBao;
                if (this.IsHoatDong)
                {
                    return 2;
                }
                else
                {
                    if ((this.ThoiDiemBao != DateTime.MinValue) &&
                            (tsp.TotalMinutes > ThongTinCauHinh.SoPhutGioiHanMatLienLac) &&
                            this.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi_AnCa
                        )
                        return 1; // mất liên l
                    else if ((this.ThoiDiemBao != DateTime.MinValue) &&
                            (tsp.TotalMinutes > ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoNghi) &&
                            this.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi_RoiXe
                        )
                        return 1;
                    else if ((this.ThoiDiemBao != DateTime.MinValue) &&
                        (tsp.TotalMinutes > ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiSanBay) &&
                        this.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi
                    )
                        return 4;
                    else if ((this.ThoiDiemBao != DateTime.MinValue) &&this.TrangThaiLaiXeBao == KieuLaiXeBao.BaoVe)
                        return 3;
                }
                return 0;
            }
            
        }

        private bool mCheckedGPS;
        /// <summary>
        /// đã kiểm tra GPS 
        /// </summary>
        public bool CheckedGPS
        {
            get { return mCheckedGPS; }
            set { mCheckedGPS = value; }
        }

        // Thông tin cơ
        private long coDi;

        public long CoDi
        {
            get { return coDi; }
            set { coDi = value; }
        }

        private long coVe;

        public long CoVe
        {
            get { return coVe; }
            set { coVe = value; }
        }
        private int soPhutNghi;
        public int SoPhutNghi
        {
            get { return soPhutNghi; }
            set { soPhutNghi = value; }
        }
        #endregion Properties

        #region Methods

        public KiemSoatXeLienLac()
        {

        }
        public KiemSoatXeLienLac(string SoHieuXe)
        {
            this.SoHieuXe = SoHieuXe;            
        }
        /// <summary>
        /// Tra ve dang sach so hieu xe dang hoat dong
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllXeDangHoatDong()
        {
            List<string> ListOfSoHieuXe = new List<string>();
            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetAllXeDangHoatDong();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListOfSoHieuXe.Add(dr["SoHieuXe"].ToString());
                    }
                }
            }
            return ListOfSoHieuXe;
        }
        
        public static bool InsertUpdateXeDangHoatDong(string SoHieuXe, DateTime  ThoiDiemBao, bool IsHoatDong)
        {
           return  new Data.KiemSoatXeLienLac().InsertUpdateXeDangHoatDong(SoHieuXe, ThoiDiemBao, IsHoatDong);
        }

        public bool InsertUpdate()
        {
            this.CheckedGPS = false;
            return new Data.KiemSoatXeLienLac().Insert_Update(this.SoHieuXe, this.ThoiDiemBao, this.MaLaiXe, this.ViTriDiemBao, this.ViTriDiemDen, this.LoaiChoKhach, this.TrangThaiLaiXeBao,this.GhiChu, this.IsHoatDong, this.ChieuChoKhach,this.CheckedGPS, this.CoDi, this.SoPhutNghi);

        }

        public bool Insert_Update_V3()
        {
            this.CheckedGPS = false;
            return new Data.KiemSoatXeLienLac().Insert_Update_V3(this.SoHieuXe, this.ThoiDiemBao,this.ViTriDiemBao, this.TrangThaiLaiXeBao, this.GhiChu, this.IsHoatDong, this.NoiDungSuCo, this.KetQuaXuLy, this.CreatedBy, this.UpdatedBy);

        }

        /// <summary>
        /// Lay trang thai cua xe bao tai thoi diem gan day nhat
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        public static KiemSoatXeLienLac GetKSXe_BySoHieuXe(string SoHieuXe)
        {
            KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.KiemSoatXeLienLac().GetKSXe_BySoHieuXe(SoHieuXe);
                if ((dt != null) && (dt.Rows.Count>0))
                {
                    DataRow dr = dt.Rows[0];

                    objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                    objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                    if (dr["MaLaiXe"] != null)
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                    else objKSLL.MaLaiXe = "";
                    if (dr["ViTriDiemBao"] != null)
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                    else objKSLL.ViTriDiemBao = "";
                    if (dr["ViTriDiemDen"] != null)
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                    else objKSLL.ViTriDiemDen = "";
                    objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                    objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                    objKSLL.GhiChu = dr["GhiChu"].ToString();
                    objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;
                }
                return objKSLL;
            }
            catch (Exception ex)
            {
                return objKSLL;
            }
        }
        /// <summary>
        /// thong tin tong dai goi mat lien lac voi xe gan day nhat
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        public static KiemSoatXeLienLac GetTrangThaiGanDayNhatCuaTongDaiGoiXe(string SoHieuXe,  DateTime ThoiDiemBaoTruoc)
        {
            KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.KiemSoatXeLienLac().GetTrangThaiGanDayNhatCuaTongDaiGoiXe(SoHieuXe, ThoiDiemBaoTruoc);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    DataRow dr = dt.Rows[0];

                    objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                    objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                    objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                    objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                    objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                    objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                    objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                    objKSLL.GhiChu = dr["GhiChu"].ToString();
                    objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;
                }
                return objKSLL;
            }
            catch (Exception ex)
            {
                return objKSLL;
            }
        }
        /// <summary>
        /// check so hieu xe nay co dang hoat dong không
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        public static bool CheckXeDangHoatDong(string SoHieuXe)
        {
            return new Data.KiemSoatXeLienLac().CheckXeDangHoatDong(SoHieuXe);
        }
        /// <summary>
        /// tra ve dang sach cac xe hoat dong trong ngay
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public  static List<string> GetDanhSachXeHoatDongTrongNgay(DateTime Ngay)
        {
            List<string> lstTemp = new List<string>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetDanhSachXeHoatDongTrongNgay(Ngay);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(dr["SoHieuXe"].ToString());
                    }
                }
            }
            return lstTemp;
        }

        
        /// <summary>
        /// Lay tat ca cac su kien cua mot xe, trong mot ngay
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        public static List<KiemSoatXeLienLac> GetDanhSachCacSuKienCuaXeTrongNgay(string SoHieuXe, DateTime Ngay)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetDanhSachCacSuKienCuaXeTrongNgay(SoHieuXe, Ngay); 
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {   
                  // [SoHieuXe]
                  //,[ThoiDiemBao]
                  //,[MaLaiXe]
                  //,[ViTriDiemBao]
                  //,[ViTriDiemDen]
                  //,[LoaiChoKhach]
                  //,[TrangThaiLaiXeBao]
                  //,[GhiChu]
                  //,[IsHoatDong] 
                    foreach (DataRow dr in dt.Rows)
                    {
                        KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
                        objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                        objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                        objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                        objKSLL.TrangThaiLaiXeBao =  (KieuLaiXeBao )int.Parse ( dr["TrangThaiLaiXeBao"].ToString());
                        objKSLL.GhiChu = dr["GhiChu"].ToString();
                        objKSLL.IsHoatDong = dr["IsHoatDong"].ToString()=="1" ?  true : false ;
                        objKSLL.ChieuChoKhach = dr["Chieu"] == DBNull.Value ? 0 : ((LoaiChieuChoKhach)(int)(int.Parse(dr["Chieu"].ToString())));
                        objKSLL.CheckedGPS = dr["CheckedGPS"]==DBNull.Value ?  false : bool.Parse( dr["CheckedGPS"].ToString ());
                        objKSLL.CoDi = dr["CoDi"] == DBNull.Value ? 0 : long.Parse(dr["CoDi"].ToString());
                        objKSLL.CoVe = dr["CoVe"] == DBNull.Value ? 0 : long.Parse(dr["CoVe"].ToString());
                        
                        lstTemp.Add(objKSLL);
                    }
                }
            }
            return lstTemp;
        }
        /// <summary>
        /// lay tat ca cac su kien cua xe trong mot khoang thoi gian
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <returns></returns>
        public static List<KiemSoatXeLienLac> GetDanhSachCacSuKienCuaXeTrongKhoangThoiGian(string SoHieuXe, DateTime TuNgayGio, DateTime DenNgayGio)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetDanhSachCacSuKienCuaXeTrongKhoangThoiGian(SoHieuXe, TuNgayGio, DenNgayGio);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    // [SoHieuXe]
                    //,[ThoiDiemBao]
                    //,[MaLaiXe]
                    //,[ViTriDiemBao]
                    //,[ViTriDiemDen]
                    //,[LoaiChoKhach]
                    //,[TrangThaiLaiXeBao]
                    //,[GhiChu]
                    //,[IsHoatDong] 
                    foreach (DataRow dr in dt.Rows)
                    {
                        KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
                        objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                        objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                        objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                        objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                        objKSLL.GhiChu = dr["GhiChu"].ToString();
                        objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;

                        lstTemp.Add(objKSLL);
                    }
                }
            }
            return lstTemp;
        }

        /// <summary>
        /// ham tra ve toan bo du lieu cua xe theo thong tin TuThoiDiem, DenThoiDiem
        /// </summary>
        /// <param name="TuThoiDiem"></param>
        /// <param name="DenThoiDiem"></param>
        /// <returns></returns>
        public static List<KiemSoatXeLienLac> GetBaoCaoMatLienLac(DateTime TuThoiDiem, DateTime DenThoiDiem)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetBaoCaoMatLienLac (  TuThoiDiem,   DenThoiDiem);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    // [SoHieuXe]
                    //,[ThoiDiemBao]
                    //,[MaLaiXe]
                    //,[ViTriDiemBao]
                    //,[ViTriDiemDen]
                    //,[LoaiChoKhach]
                    //,[TrangThaiLaiXeBao]
                    //,[GhiChu]
                    //,[IsHoatDong] 
                    foreach (DataRow dr in dt.Rows)
                    {
                        KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
                        objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                        objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                        objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                        objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                        objKSLL.GhiChu = dr["GhiChu"].ToString();
                        objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;

                        lstTemp.Add(objKSLL);
                    }
                }
            }
            return lstTemp;
        }


        #region XU LY KIEM SOAAT lien LAC
        /// <summary>
        /// với mỗi xe kiểm tra lấy thông tin gần nhất của nó.
        /// </summary>
        /// <returns></returns>
        public  List<KiemSoatXeLienLac> GetKSLLDanhSachXeDangHoatDong()
        {
            List<KiemSoatXeLienLac> ListXesDangHoatDong = new List<KiemSoatXeLienLac>();
            List<string> ListSoHieuXe = new List<string>();
            ListSoHieuXe = KiemSoatXeLienLac.GetAllXeDangHoatDong();
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            if (ListSoHieuXe != null)
            {
                foreach (string SoHieuXe in ListSoHieuXe)
                {
                    ListXesDangHoatDong.Add(KiemSoatXeLienLac.CapNhatTrangThaiXe(KiemSoatXeLienLac.GetKSXe_BySoHieuXe(SoHieuXe),timeServer)); 
                }
            }
            return ListXesDangHoatDong;
        }


        /// <summary>
        /// laays ta ca cac trang thai cua xe dang hoat dong tai thoi diem hien tai
        /// </summary>
        /// <returns></returns>
        public  static List<KiemSoatXeLienLac> GetTrangThaiAllXe_KSLL()
        {
            List<KiemSoatXeLienLac> ListXesDangHoatDong = new List<KiemSoatXeLienLac>();
             
            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetTrangThaiAllXe_KSLL();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
                    try
                    {
                        objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                        objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                        objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                        objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                        objKSLL.GhiChu = dr["GhiChu"].ToString();
                        objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;
                        ListXesDangHoatDong.Add(objKSLL );
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return ListXesDangHoatDong;
        }
        /// <summary>
        /// Kiem tra xem xe do co bi mất liên lạc không
        /// </summary>
        /// <param name="XeHoatDong"></param>
        /// <returns></returns>
        public static  KiemSoatXeLienLac CapNhatTrangThaiXe(KiemSoatXeLienLac XeHoatDong)
        {
          
            int iSoPhutGioiHanMatLienLac = Configuration.GetSoPhutGioiHanMatLienLac ();
            TimeSpan timeGioiHanMatLienLac = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLac / 60), iSoPhutGioiHanMatLienLac - 60 * Convert.ToInt32(iSoPhutGioiHanMatLienLac / 60), 0);
            int iSoPhutGioiHanMatLienLacBaoNghi = Configuration.GetSoPhutGioiHanMatLienLacBaoNghi ();
            TimeSpan timeGioiHanMatLienLacBaoNghi = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoNghi / 60), iSoPhutGioiHanMatLienLacBaoNghi-60 * Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoNghi / 60), 0);
            int iSoPhutGioiHanMatLienLacBaoDiSanBay = Configuration.GetSoPhutGioiHanMatLienLacBaoDiSanBay ();
            TimeSpan timeGioiHanMatLienLacBaoDiSanBay = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiSanBay / 60), iSoPhutGioiHanMatLienLacBaoDiSanBay - 60 * Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiSanBay / 60), 0);
            int iSoPhutGioiHanMatLienLacBaoDiDuongDai = Configuration.GetSoPhutGioiHanMatLienLacBaoDiDuongDai();
            TimeSpan timeGioiHanMatLienLacBaoDiDuongDai = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiDuongDai / 60),iSoPhutGioiHanMatLienLacBaoDiDuongDai- 60 * Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiDuongDai / 60), 0);
            //kiem tra xe dang o trang thai nao
            
            DateTime timeCurrent = DieuHanhTaxi.GetTimeServer ();
            if (XeHoatDong.TrangThaiLaiXeBao != KieuLaiXeBao.BaoNghi) // dang hoat dong khong nghi
            {
                if (XeHoatDong.LoaiChoKhach == LoaiChoKhach.ChoKhachNoiTinh)
                {
                    // kiem tra mat lien lac 
                    if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLac)
                    {
                        XeHoatDong.IsMatLienLac = true;
                        XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao; 
                    }
                }
                else if (XeHoatDong.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay )
                {
                    // kiem tra mat lien lac 
                    if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLacBaoDiSanBay )
                    {
                        XeHoatDong.IsMatLienLac = true;
                        XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao;
                    }
                }
               else if (XeHoatDong.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
                {                            // kiem tra mat lien lac 
                    if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLacBaoDiDuongDai)
                    {
                        XeHoatDong.IsMatLienLac = true;
                        XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao;
                    }
                }
            }
            else // xe nghi
            {
                if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLacBaoNghi)
                {
                    XeHoatDong.IsMatLienLac = true;
                    XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao;
                }
            }

            return XeHoatDong;
        }

        /// <summary>
        /// Kiem tra xem xe do co bi mất liên lạc không
        /// Truyeenf vao thoi gian cua seerver de so sanh
        /// </summary>
        /// <param name="XeHoatDong"></param>
        /// <returns></returns>
        public static KiemSoatXeLienLac CapNhatTrangThaiXe(KiemSoatXeLienLac XeHoatDong,DateTime timeCurrent)
        {

            int iSoPhutGioiHanMatLienLac = Configuration.GetSoPhutGioiHanMatLienLac();
            TimeSpan timeGioiHanMatLienLac = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLac / 60), iSoPhutGioiHanMatLienLac - 60 * Convert.ToInt32(iSoPhutGioiHanMatLienLac / 60), 0);
            int iSoPhutGioiHanMatLienLacBaoNghi = Configuration.GetSoPhutGioiHanMatLienLacBaoNghi();
            TimeSpan timeGioiHanMatLienLacBaoNghi = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoNghi / 60), iSoPhutGioiHanMatLienLacBaoNghi - 60 * Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoNghi / 60), 0);
            int iSoPhutGioiHanMatLienLacBaoDiSanBay = Configuration.GetSoPhutGioiHanMatLienLacBaoDiSanBay();
            TimeSpan timeGioiHanMatLienLacBaoDiSanBay = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiSanBay / 60), iSoPhutGioiHanMatLienLacBaoDiSanBay - 60 * Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiSanBay / 60), 0);
            int iSoPhutGioiHanMatLienLacBaoDiDuongDai = Configuration.GetSoPhutGioiHanMatLienLacBaoDiDuongDai();
            TimeSpan timeGioiHanMatLienLacBaoDiDuongDai = new TimeSpan(Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiDuongDai / 60), iSoPhutGioiHanMatLienLacBaoDiDuongDai - 60 * Convert.ToInt32(iSoPhutGioiHanMatLienLacBaoDiDuongDai / 60), 0);
            //kiem tra xe dang o trang thai nao

            
            if (XeHoatDong.TrangThaiLaiXeBao != KieuLaiXeBao.BaoNghi) // dang hoat dong khong nghi
            {
                if (XeHoatDong.LoaiChoKhach == LoaiChoKhach.ChoKhachNoiTinh)
                {
                    // kiem tra mat lien lac 
                    if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLac)
                    {
                        XeHoatDong.IsMatLienLac = true;
                        XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao;
                    }
                }
                else if (XeHoatDong.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay)
                {
                    // kiem tra mat lien lac 
                    if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLacBaoDiSanBay)
                    {
                        XeHoatDong.IsMatLienLac = true;
                        XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao;
                    }
                }
                else if (XeHoatDong.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
                {                            // kiem tra mat lien lac 
                    if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLacBaoDiDuongDai)
                    {
                        XeHoatDong.IsMatLienLac = true;
                        XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao;
                    }
                }
            }
            else // xe nghi
            {
                if (timeCurrent - XeHoatDong.ThoiDiemBao > timeGioiHanMatLienLacBaoNghi)
                {
                    XeHoatDong.IsMatLienLac = true;
                    XeHoatDong.TongDaiCheckCuoi = KiemSoatXeLienLac.GetTrangThaiGanDayNhatCuaTongDaiGoiXe(XeHoatDong.SoHieuXe, XeHoatDong.ThoiDiemBao).ThoiDiemBao;
                }
            }

            return XeHoatDong;
        }
         

#endregion

        /// <summary>
        /// cap nhat lai ten lai xe co thoi diem lon hon hoac = thoi diem bao
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="ThoiDiemBaoHoatDongGanNhat"></param>
        /// <param name="TenLaiXe"></param>
        /// <returns></returns>
        public static bool  UpdateTenLaiXe(string SoHieuXe, DateTime ThoiDiemBaoHoatDongGanNhat, string TenLaiXe)
        {
            return new Data.KiemSoatXeLienLac().UpdateTenLaiXe(SoHieuXe, ThoiDiemBaoHoatDongGanNhat, TenLaiXe);
        }
        public  static  bool UpdateTenLaiXe(string SoHieuXe, DateTime ThoiDiemBaoHoatDongGanNhat, DateTime ThoiDiemVe, string TenLaiXe)
        {
            return new Data.KiemSoatXeLienLac().UpdateTenLaiXe(SoHieuXe, ThoiDiemBaoHoatDongGanNhat, ThoiDiemVe, TenLaiXe);
        }
        #endregion Methods


        #region  GIAMSATXE
        /// <summary>
        /// hafm tra ve thong tin chi tien xe hoat dong
        /// ket hop thon gtin cua bang xe + thong tin giam sat xe
        /// </summary>
        /// <returns></returns>
        public List<KiemSoatXeLienLac> LayDSXeDangHoatDong()
        { 
             List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSXeDangHoatDong();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayDSXeDangVe()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSXeDangVe();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayDSXeDangNghi()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSXeDangNghi();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayDSXeDangDiSBDD()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSXeDangDiSBDD();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayDSXeDangHong()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSXeDangHong();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayDSSuCoVeThe()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSSuCoVeThe();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayDSXeDangVaCham()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSXeDangVaCham();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayDSXeDangMatLienLac(bool SapXepTheoThoiGian, bool AnMatLLSBDD)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayDSXeDangMatLienLac(  SapXepTheoThoiGian,   AnMatLLSBDD);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayThongTinChiTietCuaXe(string SoHieuXe)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

           
            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayThongTinChiTietCuaXe(SoHieuXe);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    lstTemp.Add(ToKiemSoatXeLienLac(dt.Rows[0]));

                }
                
            }


            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayThongTinChiTietCuaXeTheoDiaChi(string diaChi)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();


            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayThongTinChiTietCuaXeTheoDiaChi(diaChi);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }


            return lstTemp;
        }

        public List<KiemSoatXeLienLac> LayTatcaDSXe()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayTatcaDSXe();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLac(dr));
                    }
                }

            }
            return lstTemp;
        }
        /// <summary>
        ///   SoHieuXe,  BienSoXe , GaraName, TenSanh
		///,KSXLL.[ThoiDiemBao],KSXLL.[MaLaiXe], KSXLL.ViTriDiemBao,KSXLL.ViTriDiemDen
		///	      ,KSXLL.LoaiChoKhach, KSXLL.[TrangThaiLaiXeBao] ,KSXLL.[IsHoatDong]
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public KiemSoatXeLienLac ToKiemSoatXeLienLac(DataRow dr)
        {
            KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
            try
            {                
                objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                objKSLL.BienSoXe = dr["BienSoXe"].ToString();
                if (dr["ThoiDiemBao"] == DBNull.Value) objKSLL.ThoiDiemBao = DateTime.MinValue;
                else if (dr["ThoiDiemBao"].ToString().Length < 10) objKSLL.ThoiDiemBao = DateTime.MinValue;
                else objKSLL.ThoiDiemBao = Convert.ToDateTime(dr["ThoiDiemBao"].ToString());
                objKSLL.MaLaiXe = dr["MaLaiXe"] == DBNull.Value ? "" : dr["MaLaiXe"].ToString();
                objKSLL.ViTriDiemBao = dr["ViTriDiemBao"] == DBNull.Value ? "" : dr["ViTriDiemBao"].ToString();
                objKSLL.ViTriDiemDen = dr["ViTriDiemDen"] == DBNull.Value ? "" : dr["ViTriDiemDen"].ToString();
                objKSLL.LoaiChoKhach = dr["LoaiChoKhach"].ToString().Length <= 0 ? LoaiChoKhach.ChoKhachKhongXacDinh : (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                objKSLL.TrangThaiLaiXeBao = dr["TrangThaiLaiXeBao"].ToString().Length <= 0 ? KieuLaiXeBao.KhongXacDinh : (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                objKSLL.GhiChu = dr["GhiChu"] == DBNull.Value ? "" : dr["GhiChu"].ToString();
                objKSLL.IsHoatDong = dr["IsHoatDong"].ToString().Length <= 0 ? true : dr["IsHoatDong"].ToString() == "1" ? true : false;
                objKSLL.TenGara = dr["GaraName"] == DBNull.Value ? "" : dr["GaraName"].ToString();
                objKSLL.TenSanh = dr["TenSanh"] == DBNull.Value ? "" : dr["TenSanh"].ToString();
                objKSLL.NoiDungSuCo = dr["NoiDungSuCo"] == DBNull.Value ? "" : dr["NoiDungSuCo"].ToString();
                objKSLL.KetQuaXuLy = dr["KetQuaXuLy"] == DBNull.Value ? "" : dr["KetQuaXuLy"].ToString();
                objKSLL.SoPhutNghi = dr["SoPhutNghi"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SoPhutNghi"].ToString());
                objKSLL.CoDi = dr["CoDi"] == DBNull.Value ? 0 : Convert.ToInt64(dr["CoDi"].ToString());
            }
            catch (Exception ex)
            {
            }
            return objKSLL;
        }

        #endregion  GIAMSATXE

        /// <summary>
        /// lấy ds nhung du lieu nho hon 3 tháng gần đây
        /// </summary>
        /// <returns></returns>
        public  static List<KiemSoatXeLienLac> GetNhungTrangThaiXeNhoHon3ThangGanDay()
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetNhungTrangThaiXeNhoHon3ThangGanDay( );
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    // [SoHieuXe]
                    //,[ThoiDiemBao]
                    //,[MaLaiXe]
                    //,[ViTriDiemBao]
                    //,[ViTriDiemDen]
                    //,[LoaiChoKhach]
                    //,[TrangThaiLaiXeBao]
                    //,[GhiChu]
                    //,[IsHoatDong] 
                    foreach (DataRow dr in dt.Rows)
                    {
                        KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
                        objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                        objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                        objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                        objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                        objKSLL.GhiChu = dr["GhiChu"].ToString();
                        objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;

                        lstTemp.Add(objKSLL);
                    }
                }
            }
            return lstTemp;
        }

        public string toStringData()
        {
            string strT = "";
            strT += this.SoHieuXe +   "#%#";
            strT += string.Format("{0:HH:mm:ss dd/MM/yyyy}", this.ThoiDiemBao) + "#%#";
            strT += this.MaLaiXe + "#%#";
            strT += this.ViTriDiemBao + "#%#";
            strT += this.ViTriDiemDen + "#%#";
            strT += this.LoaiChoKhach.ToString () + "#%#";
            strT += this.TrangThaiLaiXeBao.ToString () + "#%#";
            strT += this.GhiChu+ "#%#";
            strT += this.IsHoatDong.ToString () + "#%#";
            strT += "|||";
            return strT;
        }

        public static bool DeleteNhungTrangThaiXeNhoHon3ThangGanDay()
        {
           return  new Data.KiemSoatXeLienLac().DeleteNhungTrangThaiXeNhoHon3ThangGanDay();
        }


        public static bool DeleteXeBiNhapLoi(string SoHieuXe)
        {
            return new Data.KiemSoatXeLienLac().DeleteXeBiNhapLoi(SoHieuXe);
        }

        /// <summary>
        /// hàm trả về ds lái xe không tên trong ngày
        /// Không tên lái xe, hoặc tất cả
        /// </summary>
        /// <param name="bKhongTenLaiXe"></param>
        /// <returns></returns>
        public List<KiemSoatXeLienLac> GetDSXeKhongTenLaiXe(DateTime Ngay, bool bKhongTenLaiXe)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();

            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().GetDSXeKhongTenLaiXe(Ngay,bKhongTenLaiXe);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    // [SoHieuXe]
                    //,[ThoiDiemBao]
                    //,[MaLaiXe]
                    //,[ViTriDiemBao]
                    //,[ViTriDiemDen]
                    //,[LoaiChoKhach]
                    //,[TrangThaiLaiXeBao]
                    //,[GhiChu]
                    //,[IsHoatDong] 
                    foreach (DataRow dr in dt.Rows)
                    {
                        KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
                        objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                        objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                        objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                        objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                        objKSLL.GhiChu = dr["GhiChu"].ToString();
                        objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;

                        lstTemp.Add(objKSLL);
                    }
                }
            }
            return lstTemp;
        }
        /// <summary>
        /// hàm trả về thời điểm về của xe.
        /// Nếu chưa có thời điểm về thì trả về DateTime.MinValue
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <param name="ThoiDiemBatDau"></param>
        /// <returns></returns>
        public static DateTime GetThoiDiemVeCuaXe(string SoHieuXe, DateTime ThoiDiemBatDau)
        {
           return new Data.KiemSoatXeLienLac().GetThoiDiemVeCuaXe(SoHieuXe, ThoiDiemBatDau);
        }

        public static KiemSoatXeLienLac GetKSXeBySoHieuXeThoiDiemBao(string SoHieuXe, DateTime thoiDiemBao)
        {
            KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.KiemSoatXeLienLac().GetKSXeBySoHieuXeThoiDiemBao(SoHieuXe, thoiDiemBao);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    DataRow dr = dt.Rows[0];

                    objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
                    objKSLL.ThoiDiemBao = (DateTime)dr["ThoiDiemBao"];
                    if (dr["MaLaiXe"] != null)
                        objKSLL.MaLaiXe = dr["MaLaiXe"].ToString();
                    else objKSLL.MaLaiXe = "";
                    if (dr["ViTriDiemBao"] != null)
                        objKSLL.ViTriDiemBao = dr["ViTriDiemBao"].ToString();
                    else objKSLL.ViTriDiemBao = "";
                    if (dr["ViTriDiemDen"] != null)
                        objKSLL.ViTriDiemDen = dr["ViTriDiemDen"].ToString();
                    else objKSLL.ViTriDiemDen = "";
                    objKSLL.LoaiChoKhach = (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
                    objKSLL.TrangThaiLaiXeBao = (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
                    objKSLL.ChieuChoKhach = (LoaiChieuChoKhach)int.Parse(dr["Chieu"].ToString());
                    objKSLL.GhiChu = dr["GhiChu"].ToString();
                    objKSLL.IsHoatDong = dr["IsHoatDong"].ToString() == "1" ? true : false;
                    objKSLL.ThoiDiemVe = dr["ThoiDiemVe"] == DBNull.Value ? DateTime.MinValue : (DateTime)dr["ThoiDiemVe"];
                    objKSLL.CoDi = dr["CoDi"] == DBNull.Value ? 0 : long.Parse(dr["CoDi"].ToString());
                    objKSLL.CoVe = dr["CoVe"] == DBNull.Value ? 0 : long.Parse(dr["CoVe"].ToString());
                }
                return objKSLL;
            }
            catch (Exception ex)
            {
                return objKSLL;
            }
        }

        public List<KiemSoatXeLienLac> LayThongTinChiTietCuaXeDuongDai(string noiDung)
        {
            List<KiemSoatXeLienLac> lstTemp = new List<KiemSoatXeLienLac>();


            DataTable dt = new DataTable();
            dt = new Data.KiemSoatXeLienLac().LayThongTinChiTietCuaXeDuongDai(noiDung);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstTemp.Add(ToKiemSoatXeLienLacForDuongDai(dr));
                    }
                }

            }


            return lstTemp;
        }

        public bool InsertUpdateSanBayDuongDai()
        {
            this.CheckedGPS = false;
            return new Data.KiemSoatXeLienLac().Insert_UpdateSanBayDuongDai(this.SoHieuXe, this.ThoiDiemBao, this.MaLaiXe, ViTriDiemBao, ViTriDiemDen, CoDi, this.LoaiChoKhach, this.TrangThaiLaiXeBao, GhiChu, ChieuChoKhach, CoVe);

        }

        public KiemSoatXeLienLac ToKiemSoatXeLienLacForDuongDai(DataRow dr)
        {

            KiemSoatXeLienLac objKSLL = new KiemSoatXeLienLac();
            objKSLL.SoHieuXe = dr["SoHieuXe"].ToString();
            objKSLL.BienSoXe = dr["BienSoXe"].ToString();
            if (dr["ThoiDiemBao"] == null) objKSLL.ThoiDiemBao = DateTime.MinValue;
            else if (dr["ThoiDiemBao"].ToString().Length < 10) objKSLL.ThoiDiemBao = DateTime.MinValue;
            else objKSLL.ThoiDiemBao = Convert.ToDateTime(dr["ThoiDiemBao"].ToString());

            objKSLL.MaLaiXe = dr["MaLaiXe"] == null ? "" : dr["MaLaiXe"].ToString();
            objKSLL.ViTriDiemBao = dr["ViTriDiemBao"] == null ? "" : dr["ViTriDiemBao"].ToString();
            objKSLL.ViTriDiemDen = dr["ViTriDiemDen"] == null ? "" : dr["ViTriDiemDen"].ToString();
            objKSLL.LoaiChoKhach = dr["LoaiChoKhach"].ToString().Length <= 0 ? LoaiChoKhach.ChoKhachKhongXacDinh : (LoaiChoKhach)int.Parse(dr["LoaiChoKhach"].ToString());
            objKSLL.TrangThaiLaiXeBao = dr["TrangThaiLaiXeBao"].ToString().Length <= 0 ? KieuLaiXeBao.KhongXacDinh : (KieuLaiXeBao)int.Parse(dr["TrangThaiLaiXeBao"].ToString());
            //objKSLL.GhiChu = dr["GhiChu"] == null ? "" : dr["GhiChu"].ToString();
            objKSLL.IsHoatDong = dr["IsHoatDong"].ToString().Length <= 0 ? true : dr["IsHoatDong"].ToString() == "1" ? true : false;
            objKSLL.TenGara = dr["GaraName"] == null ? "" : dr["GaraName"].ToString();
            objKSLL.TenSanh = dr["TenSanh"] == null ? "" : dr["TenSanh"].ToString();
            objKSLL.GhiChu = dr["GhiChu"] == DBNull.Value ? string.Empty : dr["GhiChu"].ToString();
            objKSLL.ThoiDiemVe = dr["ThoiDiemVe"] == DBNull.Value ? DateTime.MinValue : (DateTime)dr["ThoiDiemVe"];
            objKSLL.CoDi = dr["CoDi"] == DBNull.Value ? 0 : long.Parse(dr["CoDi"].ToString());
            objKSLL.CoVe = dr["CoVe"] == DBNull.Value ? 0 : long.Parse(dr["CoVe"].ToString());
            return objKSLL;
        }
    }

}
