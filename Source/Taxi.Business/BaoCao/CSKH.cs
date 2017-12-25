using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using Taxi.Utils;

namespace Taxi.Business.BaoCao
{
    public class CSKHChiTiet
    {
        private long _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _SoDienThoai;

        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _Line;

        public string Line
        {
            get { return _Line; }
            set { _Line = value; }
        }

        #region Dien Thoai Den
        // Làn 1 gọi đến
        private DateTime _LAN1_Gio;

        public DateTime LAN1_Gio
        {
            get { return _LAN1_Gio; }
            set { _LAN1_Gio = value; }
        }
        private string _LAN1_NVDT; // nhan vien dien thoai

        public string LAN1_NVDT
        {
            get { return _LAN1_NVDT; }
            set { _LAN1_NVDT = value; }
        }
        private string _LAN1_FileGhiAm;

        public string LAN1_FileGhiAm
        {
            get { return _LAN1_FileGhiAm; }
            set { _LAN1_FileGhiAm = value; }
        }
        // LAN 2 
        private DateTime _LAN2_Gio;

        public DateTime LAN2_Gio
        {
            get { return _LAN2_Gio; }
            set { _LAN2_Gio = value; }
        }
        private string _LAN2_NVDT; // nhan vien dien thoai

        public string LAN2_NVDT
        {
            get { return _LAN2_NVDT; }
            set { _LAN2_NVDT = value; }
        }
        private string _LAN2_FileGhiAm;

        public string LAN2_FileGhiAm
        {
            get { return _LAN2_FileGhiAm; }
            set { _LAN2_FileGhiAm = value; }
        }
        // Lan 3
        private DateTime _LAN3_Gio;

        public DateTime LAN3_Gio
        {
            get { return _LAN3_Gio; }
            set { _LAN3_Gio = value; }
        }
        private string _LAN3_NVDT; // nhan vien dien thoai

        public string LAN3_NVDT
        {
            get { return _LAN3_NVDT; }
            set { _LAN3_NVDT = value; }
        }
        private string _LAN3_FileGhiAm;

        public string LAN3_FileGhiAm
        {
            get { return _LAN3_FileGhiAm; }
            set { _LAN3_FileGhiAm = value; }
        }
        // Lan 4
        private DateTime _LAN4_Gio;

        public DateTime LAN4_Gio
        {
            get { return _LAN4_Gio; }
            set { _LAN4_Gio = value; }
        }
        private string _LAN4_NVDT; // nhan vien dien thoai

        public string LAN4_NVDT
        {
            get { return _LAN4_NVDT; }
            set { _LAN4_NVDT = value; }
        }
        private string _LAN4_FileGhiAm;

        public string LAN4_FileGhiAm
        {
            get { return _LAN4_FileGhiAm; }
            set { _LAN4_FileGhiAm = value; }
        }
        #endregion 

        #region Goi CSKH
        // LAN 1
        private DateTime _CSKH_Lan1_Gio;

        public DateTime CSKH_Lan1_Gio
        {
            get { return _CSKH_Lan1_Gio; }
            set { _CSKH_Lan1_Gio = value; }
        }
        private string _CSKH_Lan1_MaNhanVien;

        public string CSKH_Lan1_MaNhanVien
        {
            get { return _CSKH_Lan1_MaNhanVien; }
            set { _CSKH_Lan1_MaNhanVien = value; }
        }
        private string _CSKH_Lan1_FileGhiAm;

        public string CSKH_Lan1_FileGhiAm
        {
            get { return _CSKH_Lan1_FileGhiAm; }
            set { _CSKH_Lan1_FileGhiAm = value; }
        }
        // LAN 2
        private DateTime _CSKH_Lan2_Gio;

        public DateTime CSKH_Lan2_Gio
        {
            get { return _CSKH_Lan2_Gio; }
            set { _CSKH_Lan2_Gio = value; }
        }
        private string _CSKH_Lan2_MaNhanVien;

        public string CSKH_Lan2_MaNhanVien
        {
            get { return _CSKH_Lan2_MaNhanVien; }
            set { _CSKH_Lan2_MaNhanVien = value; }
        }
        private string _CSKH_Lan2_FileGhiAm;

        public string CSKH_Lan2_FileGhiAm
        {
            get { return _CSKH_Lan2_FileGhiAm; }
            set { _CSKH_Lan2_FileGhiAm = value; }
        }
        // LAN 3
        private DateTime _CSKH_Lan3_Gio;

        public DateTime CSKH_Lan3_Gio
        {
            get { return _CSKH_Lan3_Gio; }
            set { _CSKH_Lan3_Gio = value; }
        }
        private string _CSKH_Lan3_MaNhanVien;

        public string CSKH_Lan3_MaNhanVien
        {
            get { return _CSKH_Lan3_MaNhanVien; }
            set { _CSKH_Lan3_MaNhanVien = value; }
        }
        private string _CSKH_Lan3_FileGhiAm;

        public string CSKH_Lan3_FileGhiAm
        {
            get { return _CSKH_Lan3_FileGhiAm; }
            set { _CSKH_Lan3_FileGhiAm = value; }
        }
        // LAN 4
        private DateTime _CSKH_Lan4_Gio;

        public DateTime CSKH_Lan4_Gio
        {
            get { return _CSKH_Lan4_Gio; }
            set { _CSKH_Lan4_Gio = value; }
        }
        private string _CSKH_Lan4_MaNhanVien;

        public string CSKH_Lan4_MaNhanVien
        {
            get { return _CSKH_Lan4_MaNhanVien; }
            set { _CSKH_Lan4_MaNhanVien = value; }
        }
        private string _CSKH_Lan4_FileGhiAm;

        public string CSKH_Lan4_FileGhiAm
        {
            get { return _CSKH_Lan4_FileGhiAm; }
            set { _CSKH_Lan4_FileGhiAm = value; }
        }
        #endregion 

        private bool _DonDuoc;

        public bool DonDuoc
        {
            get { return _DonDuoc; }
            set { _DonDuoc = value; }
        }
        private bool _TruotHoan;

        public bool TruotHoan
        {
            get { return _TruotHoan; }
            set { _TruotHoan = value; }
        }
        private bool _KhongXe;

        public bool KhongXe
        {
            get { return _KhongXe; }
            set { _KhongXe = value; }
        }
        private bool _Khac;  // xe 999

        public bool Khac    // xe 999
        {
            get { return _Khac; }
            set { _Khac = value; }
        }
        private DateTime _GioDonKhach;

        public DateTime GioDonKhach
        {
            get { return _GioDonKhach; }
            set { _GioDonKhach = value; }
        }
        private string _MaNVTongDai;

        public string MaNVTongDai
        {
            get { return _MaNVTongDai; }
            set { _MaNVTongDai = value; }
        }
        private string _MaNhanVienDienThoai;

        public string MaNhanVienDienThoai
        {
            get { return _MaNhanVienDienThoai; }
            set { _MaNhanVienDienThoai = value; }
        }

        private string _phanLoai;

        public string PhanLoai
        {
            get { return _phanLoai; }
            set { _phanLoai = value; }
        }
        private int _vung;

        public int Vung
        {
            get { return _vung; }
            set { _vung = value; }
        }
        /// <summary>
        /// hàm trả về dữ liệu báo cáo chi tiết cskh
        /// khi isGoiTaxi =  true thì
        ///     isDOnDuoc, isDonDuoc888, isTruotHoan,isKhongXe, isKhongXe888 mới được kiểm tra
        /// ngươc lại thì bỏ qua
        /// </summary>
        public static List<CSKHChiTiet> GetBCCSKHChiTiet(DateTime TuNgay, DateTime DenNgay, string Vung, int SoLanGoiLai, bool isDonDuoc, bool isDonDuoc888, bool isTruotHoan, bool isKhongXe, bool isKhongXe999, string idTongDai, string idCS, string idDienThoai, bool isGoiTaxi, bool isGoiLai,string pSoDienThoai ="")
        {
            List<CSKHChiTiet> lstCSKHChiTiet = new List<CSKHChiTiet> ();
            DataTable dt = new DataTable();
            dt = new Data.CSKHChiTiet().GetBCCSKHChiTiet(TuNgay, DenNgay, Vung, SoLanGoiLai, isDonDuoc,isDonDuoc888,   isTruotHoan,   isKhongXe,isKhongXe999,  idTongDai,   idCS,idDienThoai, isGoiTaxi,isGoiLai,pSoDienThoai);
           
            if(dt != null && dt.Rows .Count >0)
            {
                bool bThemMoi = true;
                int iLanGoi = 0;
                string sSoDienThoai = "";
                DateTime thoiDiemGoi = DateTime.MinValue; 
                CSKHChiTiet objCSKHChiTiet =null;

                DateTime LAN2_Gio = DateTime.MinValue;
                string LAN2_NVDT = "";
                string LAN2_FileGhiAm = "";
                DateTime LAN3_Gio = DateTime.MinValue;
                string LAN3_NVDT = "";
                string LAN3_FileGhiAm = "";
                DateTime LAN4_Gio = DateTime.MinValue;
                string LAN4_NVDT = "";
                string LAN4_FileGhiAm = "";

                string[] NhanVienMoiKhach;
                bool quaGio = true;  // kiểm soát giới hạn quá giờ lớn hơn 45 phút.
                for (int i = 0; i < dt.Rows.Count;i++)
                { 
                    DataRow dr =  dt.Rows[i];

                    if (!bThemMoi) 
                    {
                        
                        if (sSoDienThoai == dr["PhoneNumber"].ToString() && (!quaGio) ) // gọi lại
                        {
                            TimeSpan timeSpan = Convert.ToDateTime(dr["ThoiDiemGoi"].ToString()) - thoiDiemGoi;
                            if (timeSpan.TotalMinutes > 45) quaGio = true;
                            if (!quaGio)
                            {
                                if (iLanGoi == 1)  // gọi lại lần 1
                                {
                                    iLanGoi++;
                                    LAN2_Gio = Convert.ToDateTime(dr["ThoiDiemGoi"].ToString());
                                    LAN2_NVDT = dr["MaNhanVienDienThoai"].ToString(); ;
                                    LAN2_FileGhiAm = dr["FileVoicePath"] == null ? "" : dr["FileVoicePath"].ToString();
                                }
                                else if (iLanGoi == 2)
                                {
                                    iLanGoi++;
                                    LAN3_Gio = Convert.ToDateTime(dr["ThoiDiemGoi"].ToString()); ;
                                    LAN3_NVDT = dr["MaNhanVienDienThoai"].ToString(); ;
                                    LAN3_FileGhiAm = dr["FileVoicePath"] == null ? "" : dr["FileVoicePath"].ToString();
                                }
                                else if (iLanGoi == 3)
                                {
                                    iLanGoi++;
                                    LAN4_Gio = Convert.ToDateTime(dr["ThoiDiemGoi"].ToString()); ;
                                    LAN4_NVDT = dr["MaNhanVienDienThoai"].ToString(); ;
                                    LAN4_FileGhiAm = dr["FileVoicePath"] == null ? "" : dr["FileVoicePath"].ToString();
                                }
                            }
                        }
                        else  // cuoc goi khac
                        {
                            bThemMoi = true;
                            iLanGoi = 0;
                            sSoDienThoai = "";
                            
                            objCSKHChiTiet.LAN2_Gio = LAN2_Gio;
                            objCSKHChiTiet.LAN2_NVDT = LAN2_NVDT;
                            objCSKHChiTiet.LAN2_FileGhiAm = LAN2_FileGhiAm;
                            objCSKHChiTiet.LAN3_Gio = LAN3_Gio;
                            objCSKHChiTiet.LAN3_NVDT = LAN3_NVDT;
                            objCSKHChiTiet.LAN3_FileGhiAm = LAN3_FileGhiAm;
                            objCSKHChiTiet.LAN4_Gio = LAN4_Gio;
                            objCSKHChiTiet.LAN4_NVDT = LAN4_NVDT;
                            objCSKHChiTiet.LAN4_FileGhiAm = LAN4_FileGhiAm; 

                            lstCSKHChiTiet.Add(objCSKHChiTiet); // them vao
                             // dat la thong so lan
                            LAN2_Gio = DateTime.MinValue;
                            LAN2_NVDT = "";
                            LAN2_FileGhiAm = "";
                            LAN3_Gio = DateTime.MinValue;
                            LAN3_NVDT = "";
                            LAN3_FileGhiAm = "";
                            LAN4_Gio = DateTime.MinValue;
                            LAN4_NVDT = "";
                            LAN4_FileGhiAm = "";
                        }
                    }
                    if (bThemMoi)
                    {
                        objCSKHChiTiet = new CSKHChiTiet ();
                        // Them moi
                        objCSKHChiTiet = CSKHChiTiet.GetCSKHChiTietByRow(dr); 
                        iLanGoi = 1; // lần gọi đầu
                        sSoDienThoai = objCSKHChiTiet.SoDienThoai; // luu lại số điện thoại để so sánh
                        thoiDiemGoi = objCSKHChiTiet.LAN1_Gio;
                        bThemMoi = false;
                        quaGio = false;
                    }                     
                }
            }

            return lstCSKHChiTiet;
        }
        /// <summary>
        /// hàm trả về một đối tượng CSKHChiTiet
        /// 
        /// ID	Line	PhoneNumber	ThoiDiemGoi	DiaChiDonKhach	KieuKhachHangGoiDen	Vung	MaNhanVienDienThoai	MaNhanVienTongDai
        /// XeNhan	XeDon	DiaChiTraKhach	ThoiGianDieuXe	ThoiGianDonKhach	KieuCuocGoi	TrangThaiCuocGoi	CuocGoiLaiIDs	MaDoiTac	
        /// MOIKHACH_NhungThoiDiemMoi MOIKHACH_NhungNhanVienMoi	FileVoicePath	DonDuoc	TruotHoan	KhongXe	ChiTietGoiLai
        /// 
        ///19438	1	0905111111	2011-02-26 11:20:48.800	khong xe	1	1	dienthoai	tongdai				0	0	1	4			
        /// ;2011-02-26 11:24:05;2011-02-26 11:24:05	;tongdai   NULL	0	0	1	
        /// 19439,2011-02-26 11:21:05,dienthoai,|19440,2011-02-26 11:22:14,dienthoai,|19441,2011-02-26 11:22:24,dienthoai,|
        /// 
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static CSKHChiTiet GetCSKHChiTietByRow(DataRow dataRow)
        {   try{
                CSKHChiTiet objChiTiet = new CSKHChiTiet();

                objChiTiet.ID = Convert.ToInt64( dataRow["ID"].ToString ());
                objChiTiet.Line = dataRow["Line"].ToString();
                objChiTiet.SoDienThoai = dataRow["PhoneNumber"].ToString();
                objChiTiet.DiaChi = dataRow["DiaChiDonKhach"].ToString();
                objChiTiet.Vung = Convert.ToInt32 ( dataRow["Vung"].ToString());
                objChiTiet.PhanLoai = GetPhanLoaiCuocGoi(Convert.ToInt32(dataRow["KieuCuocGoi"].ToString()), Convert.ToInt32(dataRow["Vung"].ToString()));

                objChiTiet.LAN1_Gio = Convert.ToDateTime(dataRow["ThoiDiemGoi"].ToString());
                objChiTiet.LAN1_NVDT = dataRow["MaNhanVienDienThoai"].ToString();
                objChiTiet.LAN1_FileGhiAm = dataRow["FileVoicePath"] == null ? "" : dataRow["FileVoicePath"].ToString();
               

                //DateTime LAN2_Gio = DateTime.MinValue;
                //string LAN2_NVDT  ="";
                //string LAN2_FileGhiAm = "";
                //DateTime LAN3_Gio =  DateTime.MinValue;
                //string LAN3_NVDT = "";
                //string LAN3_FileGhiAm = "";
                //DateTime LAN4_Gio =  DateTime.MinValue;
                //string LAN4_NVDT = "";
                //string LAN4_FileGhiAm = "";

                //string strChiTietGoiLai = "";
                //strChiTietGoiLai = dataRow["ChiTietGoiLai"] == null ? "" : dataRow["ChiTietGoiLai"].ToString();
                //if (strChiTietGoiLai != null && strChiTietGoiLai.Length > 0)
                //{
                //    if (strChiTietGoiLai.EndsWith("|"))
                //        strChiTietGoiLai = strChiTietGoiLai.Substring(0, strChiTietGoiLai.Length - 1);
                //}
                //if (strChiTietGoiLai.Length > 0)
                //{
                //    CSKHChiTiet.GetChiTietGoiLai(strChiTietGoiLai, out LAN2_Gio, out LAN2_NVDT, out LAN2_FileGhiAm,
                //                                              out LAN3_Gio, out LAN3_NVDT, out LAN3_FileGhiAm,
                //                                              out LAN4_Gio, out LAN4_NVDT, out LAN4_FileGhiAm);
                //}
                //objChiTiet.LAN2_Gio = LAN2_Gio;
                //objChiTiet.LAN2_NVDT = LAN2_NVDT;
                //objChiTiet.LAN2_FileGhiAm = LAN2_FileGhiAm;
                //objChiTiet.LAN3_Gio = LAN3_Gio;
                //objChiTiet.LAN3_NVDT = LAN3_NVDT;
                //objChiTiet.LAN3_FileGhiAm = LAN3_FileGhiAm;
                //objChiTiet.LAN4_Gio = LAN4_Gio;
                //objChiTiet.LAN4_NVDT = LAN4_NVDT;
                //objChiTiet.LAN4_FileGhiAm = LAN4_FileGhiAm;

                string strNhungThoiDiemMoi = dataRow["MOIKHACH_NhungThoiDiemMoi"] == null ? "" : dataRow["MOIKHACH_NhungThoiDiemMoi"].ToString ();
                string strNhungNhanVienMoi = dataRow["MOIKHACH_NhungNhanVienMoi"] == null ? null : dataRow["MOIKHACH_NhungNhanVienMoi"].ToString ();


            DateTime CSKH_Lan1_Gio =  DateTime.MinValue; string  CSKH_Lan1_MaNhanVien = "";
            DateTime CSKH_Lan2_Gio = DateTime.MinValue; string CSKH_Lan2_MaNhanVien = "";
            DateTime CSKH_Lan3_Gio = DateTime.MinValue; string CSKH_Lan3_MaNhanVien = "";
            DateTime CSKH_Lan4_Gio = DateTime.MinValue; string CSKH_Lan4_MaNhanVien = "";
            if (strNhungNhanVienMoi.Length > 0 && strNhungThoiDiemMoi.Length > 0)
            {
                CSKHChiTiet.GetChiTietLanCSKH(strNhungThoiDiemMoi, strNhungNhanVienMoi,
                                               out CSKH_Lan1_Gio, out CSKH_Lan1_MaNhanVien
                                               , out CSKH_Lan2_Gio, out CSKH_Lan2_MaNhanVien
                                               , out CSKH_Lan3_Gio, out CSKH_Lan3_MaNhanVien
                                                , out CSKH_Lan4_Gio, out CSKH_Lan4_MaNhanVien);
            }
                objChiTiet.CSKH_Lan1_Gio = CSKH_Lan1_Gio;
                objChiTiet.CSKH_Lan1_MaNhanVien = CSKH_Lan1_MaNhanVien;
                objChiTiet.CSKH_Lan2_Gio = CSKH_Lan2_Gio;
                objChiTiet.CSKH_Lan2_MaNhanVien = CSKH_Lan2_MaNhanVien;
                objChiTiet.CSKH_Lan3_Gio = CSKH_Lan3_Gio;
                objChiTiet.CSKH_Lan3_MaNhanVien = CSKH_Lan3_MaNhanVien;
                objChiTiet.CSKH_Lan4_Gio = CSKH_Lan4_Gio;
                objChiTiet.CSKH_Lan4_MaNhanVien = CSKH_Lan4_MaNhanVien;
                //DonDuoc	TruotHoan	KhongXe
                objChiTiet.DonDuoc = false;
                if(dataRow["DonDuoc"]!= DBNull.Value && dataRow["DonDuoc"].ToString ()=="1")
                     objChiTiet.DonDuoc = true;
                objChiTiet.TruotHoan = false ;
                if (dataRow["TruotHoan"] != DBNull.Value && dataRow["TruotHoan"].ToString() == "1") 
                    objChiTiet.TruotHoan = true;
                objChiTiet.KhongXe = false ;
                if (dataRow["KhongXe"] != DBNull.Value && dataRow["KhongXe"].ToString() == "1") 
                    objChiTiet.KhongXe = true;
                objChiTiet.Khac = false;
                if (dataRow["Khac"] != DBNull.Value && dataRow["Khac"].ToString() == "1")
                    objChiTiet.Khac = true;

                objChiTiet.MaNVTongDai = dataRow["MaNhanVienTongDai"].ToString();
                objChiTiet.MaNhanVienDienThoai = dataRow["MaNhanVienDienThoai"].ToString();
                return objChiTiet;
            }
            catch(Exception ex)
            {
                return null ;
            }
        }
        /// <summary>
        ///  if (kieuCuocGio == (int) KieuCuocGoi.GoiTaxi) return "A";
            //else if (kieuCuocGio == (int)KieuCuocGoi.GoiLai) return "B";
            //else if (kieuCuocGio == (int)KieuCuocGoi.GoiDichVu) return "C";
            //else if (kieuCuocGio == (int)KieuCuocGoi.GoiKhieuNai) return "D";
         ///else if (kieuCuocGio == (int)KieuCuocGoi.GoiKhac) return "E";
        /// </summary>
        /// <param name="kieuCuocGio"></param>
        /// <returns></returns>
        private static string GetPhanLoaiCuocGoi(int kieuCuocGio, int vung)
        {
            if (kieuCuocGio == (int) KieuCuocGoi.GoiTaxi) return "A";
            else if (kieuCuocGio == (int)KieuCuocGoi.GoiLai) return "B";
            else if ( vung == 9 || vung == 10) return "C";
            else if ( vung==11 ) return "D";
            else if (kieuCuocGio == (int)KieuCuocGoi.GoiKhac) return "E";
            else return "";
        }
         /// <summary>
         /// ;2011-02-26 11:24:05;2011-02-26 11:24:05	;tongdai
         /// </summary>
         /// <param name="NhungThoiDiemMoi"></param>
         /// <param name="NNhungNhanVienMoi"></param>
         /// <param name="CSKH_LAN1_Gio"></param>
         /// <param name="CSKH_LAN1_NV"></param>
         /// <param name="CSKH_LAN2_Gio"></param>
         /// <param name="CSKH_LAN2_NV"></param>
         /// <param name="CSKH_LAN3_Gio"></param>
         /// <param name="CSKH_LAN3_NV"></param>
         /// <param name="CSKH_LAN4_Gio"></param>
         /// <param name="CSKH_LAN4_NV"></param>
        public static void GetChiTietLanCSKH(string NhungThoiDiemMoi, string NhungNhanVienMoi, 
                                            out DateTime CSKH_LAN1_Gio, out string CSKH_LAN1_NV,
                                            out DateTime CSKH_LAN2_Gio, out string CSKH_LAN2_NV,
                                            out DateTime CSKH_LAN3_Gio, out string CSKH_LAN3_NV,
                                            out DateTime CSKH_LAN4_Gio, out string CSKH_LAN4_NV)
             
        {
            string strNhungThoiDiemMoi = "";
            string strNhungNhanVienMoi = "";
            if(NhungThoiDiemMoi!=null && NhungThoiDiemMoi.StartsWith(";"))
            {
                strNhungThoiDiemMoi = NhungThoiDiemMoi.Substring(1,NhungThoiDiemMoi.Length-1);
            }
            if(NhungNhanVienMoi != null && NhungNhanVienMoi.StartsWith(";"))
                strNhungNhanVienMoi = NhungNhanVienMoi.Substring(1,NhungNhanVienMoi.Length-1);
          

             CSKH_LAN1_Gio  = DateTime .MinValue ;
             CSKH_LAN1_NV = "";
             CSKH_LAN2_Gio= DateTime .MinValue ;
             CSKH_LAN2_NV = "";
             CSKH_LAN3_Gio= DateTime .MinValue ;
             CSKH_LAN3_NV = "";
             CSKH_LAN4_Gio= DateTime .MinValue ;
             CSKH_LAN4_NV = "";
             
             if (NhungThoiDiemMoi.Length > 0)
             {
                 string[] arrThoiDiem = strNhungThoiDiemMoi.Split(";".ToCharArray());
                 string[] arrNhanVien = strNhungNhanVienMoi.Split(";".ToCharArray());
                 if (arrThoiDiem.Length >= 1)
                 {
                     CSKH_LAN1_Gio = Convert.ToDateTime(arrThoiDiem[0].ToString(), new CultureInfo("en-US", true));
                     CSKH_LAN1_NV = arrNhanVien[0];
                 }
                 if (arrThoiDiem.Length >= 2)
                 {
                     CSKH_LAN2_Gio = Convert.ToDateTime(arrThoiDiem[1].ToString(), new CultureInfo("en-US", true));
                     CSKH_LAN2_NV = arrNhanVien[1];
                 }
                 if (arrThoiDiem.Length >= 3)
                 {
                     CSKH_LAN3_Gio = Convert.ToDateTime(arrThoiDiem[2].ToString(), new CultureInfo("en-US", true));
                     CSKH_LAN3_NV = arrNhanVien[1];
                 }
                 if (arrThoiDiem.Length >= 4)
                 {
                     CSKH_LAN4_Gio = Convert.ToDateTime(arrThoiDiem[3].ToString(), new CultureInfo("en-US", true));
                     CSKH_LAN4_NV = arrNhanVien[3];
                 }
             }
        }
        /// <summary>
        /// Input  :
        ///    19429,2011-02-26 11:10:14,dienthoai,
        /// |19430,2011-02-26 11:10:31,dienthoai,filepathVoice|19431,2011-02-26 11:10:55,dienthoai,|19432,2011-02-26 11:11:12,dienthoai,|
        /// </summary>
        /// <param name="strChiTietGoiLai"></param>
        /// <param name="LAN2_Gio"></param>
        /// <param name="LAN2_NVDT"></param>
        /// <param name="LAN2_FileGhiAm"></param>
        /// <param name="LAN3_Gio"></param>
        /// <param name="LAN3_NVDT"></param>
        /// <param name="LAN3_FileGhiAm"></param>
        /// <param name="LAN4_Gio"></param>
        /// <param name="LAN4_NVDT"></param>
        /// <param name="LAN4_FileGhiAm"></param>
        private static void GetChiTietGoiLai(string ChiTietGoiLai, out DateTime LAN2_Gio, out string LAN2_NVDT, out string LAN2_FileGhiAm,
                                                                      out DateTime LAN3_Gio, out string LAN3_NVDT, out string LAN3_FileGhiAm,
                                                                      out DateTime LAN4_Gio, out string LAN4_NVDT, out string LAN4_FileGhiAm)
        {
            LAN2_Gio = DateTime.MinValue;
            LAN2_NVDT = "";
            LAN2_FileGhiAm = "";
            LAN3_Gio = DateTime.MinValue;
            LAN3_NVDT = "";
            LAN3_FileGhiAm = "";
            LAN4_Gio = DateTime.MinValue;
            LAN4_NVDT = "";
            LAN4_FileGhiAm = "";
            if (ChiTietGoiLai != null && ChiTietGoiLai.Length > 0)
            {
                string[] arrCuocGoiLai = ChiTietGoiLai.Split("|".ToCharArray());

                string[] arrMotCuoc = arrCuocGoiLai[0].Split(",".ToCharArray()); // cuoc 1 //19430,2011-02-26 11:10:31,dienthoai,filepathVoice
                LAN2_Gio = Convert.ToDateTime(arrMotCuoc[1].ToString(), new CultureInfo("en-US", true));
                LAN2_FileGhiAm = arrMotCuoc[3] == null ? "" : arrMotCuoc[3];
                LAN2_NVDT = arrMotCuoc[2] == null ? "" : arrMotCuoc[2];
                if (arrCuocGoiLai.Length >= 2)
                {
                    arrMotCuoc = arrCuocGoiLai[1].Split(",".ToCharArray());
                    LAN3_Gio = Convert.ToDateTime(arrMotCuoc[1].ToString(), new CultureInfo("en-US", true));
                    LAN3_FileGhiAm = arrMotCuoc[3] == null ? "" : arrMotCuoc[3];
                    LAN3_NVDT = arrMotCuoc[2] == null ? "" : arrMotCuoc[2];
                     
                }
                if (arrCuocGoiLai.Length >= 3)
                {
                    arrMotCuoc = arrCuocGoiLai[2].Split(",".ToCharArray());
                    LAN4_Gio = Convert.ToDateTime(arrMotCuoc[1].ToString(), new CultureInfo("en-US", true));
                    LAN4_FileGhiAm = arrMotCuoc[3] == null ? "" : arrMotCuoc[3];
                    LAN4_NVDT = arrMotCuoc[2] == null ? "" : arrMotCuoc[2];

                }
            }
        }
    }
}
