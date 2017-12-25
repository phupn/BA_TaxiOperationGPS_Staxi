using System;
using System.Collections.Generic;
using Taxi.Business;
using Taxi.Business.DM;

namespace TaxiCapture
{
    public enum KieuDanhBa {

        MoiGioi = 1,
        CongTy = 2,
        KhachAo = 3,
        Online = 4,
        BuuDien = 5

    }
    public class DanhBaEx:DanhBa
    { 

        private KieuDanhBa kieuDanhBa;

        public KieuDanhBa KieuDanhBa
        {
            get { return kieuDanhBa; }
            set { kieuDanhBa = value; }
        }

        private string maDoiTac;

        public string MaDoiTac
        {
            get { return maDoiTac; }
            set { maDoiTac = value; }
        }

        private int vung;

        public int Vung
        {
            get { return vung; }
            set { vung = value; }
        }
        private string loaiXe;

        public string LoaiXe
        {
            get { return loaiXe; }
            set { loaiXe = value; }
        }
        public bool IsActive { get; set; }
        private string _GhiChuDienThoai;
        public string GhiChuDienThoai
        {
            get { return _GhiChuDienThoai; }
            set { _GhiChuDienThoai = value; }
        }
        private string _GhiChuTongDai;
        public string GhiChuTongDai
        {
            get { return _GhiChuTongDai; }
            set { _GhiChuTongDai = value; }
        }
        public string GhiChuTiepNhan { get; set; }
        public float GPS_KinhDo { get; set; }
        public float GPS_ViDo { get; set; }

        public DanhBaEx()
        {
            this.PhoneNumber = string.Empty;
            this.Address = string.Empty;
            this.KieuDanhBa = KieuDanhBa.Online;
            this.MaDoiTac = string.Empty;
            this.Vung = 0;
            this.LoaiXe = string.Empty;
            this.IsActive = false;
            this.GhiChuTiepNhan = string.Empty;
            this.GPS_KinhDo = 0;
            this.GPS_ViDo = 0;
        }

        public DanhBaEx(string soDienThoai, string diaChi, KieuDanhBa kieuDanhBa, string maDoiTac, int vung, string loaiXe, bool isActive)
        {
            this.PhoneNumber = soDienThoai;
            this.Address = diaChi;
            this.KieuDanhBa = kieuDanhBa;
            this.MaDoiTac = maDoiTac;
            this.Vung = vung;
            this.LoaiXe = loaiXe;
            this.IsActive = isActive;
        }
        public DanhBaEx(string soDienThoai, string diaChi, KieuDanhBa kieuDanhBa, string maDoiTac, int vung, string loaiXe, bool isActive,
            string GhiChuTiepNhan, float KinhDo, float ViDo, string diachiTra)
        {
            this.PhoneNumber = soDienThoai;
            this.Address = diaChi;
            this.KieuDanhBa = kieuDanhBa;
            this.MaDoiTac = maDoiTac;
            this.Vung = vung;
            this.LoaiXe = loaiXe;
            this.IsActive = isActive;
            this.GhiChuTiepNhan = GhiChuTiepNhan;
            this.GPS_KinhDo = KinhDo;
            this.GPS_ViDo = ViDo;
            this.Address_Destination = diachiTra;
        }
        public DanhBaEx(string soDienThoai, string diaChi, KieuDanhBa kieuDanhBa, string maDoiTac, int vung, string loaiXe, bool isActive, string GhiChuDienThoai, string GhiChuTongDai)
        {
            this.PhoneNumber = soDienThoai;
            this.Address = diaChi;
            this.KieuDanhBa = kieuDanhBa;
            this.MaDoiTac = maDoiTac;
            this.Vung = vung;
            this.LoaiXe = loaiXe;
            this.IsActive = isActive;
            this.GhiChuDienThoai = GhiChuDienThoai;
            this.GhiChuTongDai = GhiChuTongDai;
        }
        /// <summary>
        /// hàm thực hiện trả về ds anh ba lai xe     
        /// </summary>
        public static List<DanhBaEx> GetDanhBaLaiXe()
        {
            List<DanhBaEx> listRet = new List<DanhBaEx>();
            try
            {
                List<NhanVien> listNV = new NhanVien().GetListNhanViens();

                foreach (NhanVien item in listNV)
                {
                    // tác số điện thoại
                    string[] arrDienThoai = item.DiDong.Split(";".ToCharArray());
                    for (int i = 0; i < arrDienThoai.Length; i++)
                    {
                        DanhBaEx dtx = new DanhBaEx(arrDienThoai[i], item.TenNhanVien, KieuDanhBa.CongTy, "", 0, "", true, "", "");
                        listRet.Add(dtx);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaLaiXe:", ex);
            }
            return listRet;
        }
        /// <summary>
        /// hàm thực hiện trả về ds anh ba môi giới
        /// </summary>        
        public static List<DanhBaEx> GetDanhBaMoiGioi()
        {
            try
            {
                List<DanhBaEx> listRet = new List<DanhBaEx>();
                DoiTac dt = new DoiTac();
                List<DoiTac> listDT = dt.GetListOfDoiTacs(true);

                foreach (DoiTac doiTac in listDT)
                {
                    // tác số điện thoại
                    string[] arrDienThoai = doiTac.Phones.Split(";".ToCharArray());
                    for (int i = 0; i < arrDienThoai.Length; i++)
                    {
                        DanhBaEx dtx = new DanhBaEx(arrDienThoai[i], doiTac.Name + " - " + doiTac.Address, KieuDanhBa.MoiGioi, doiTac.MaDoiTac, doiTac.Vung, "", doiTac.IsActive, "", doiTac.KinhDo, doiTac.ViDo, "");
                        listRet.Add(dtx);
                    }
                }

                return listRet;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaMoiGioi: " ,ex);
                return new List<DanhBaEx>();
            }
        }

        /// <summary>
        /// Get danh bạ đối tác có sự thay đổi
        /// </summary>
        public static List<DanhBaEx> GetDanhBaMoiGioi_LastUpdate(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaEx> listRet = new List<DanhBaEx>();
                DoiTac dt = new DoiTac();
                List<DoiTac> listDT = dt.GetCacDoiTacs_LastUpdate(LastUpdate);

                foreach (DoiTac doiTac in listDT)
                {
                    // tác số điện thoại
                    string[] arrDienThoai = doiTac.Phones.Split(";".ToCharArray());
                    for (int i = 0; i < arrDienThoai.Length; i++)
                    {
                        DanhBaEx dtx = new DanhBaEx(arrDienThoai[i], doiTac.Name + " - " + doiTac.Address, KieuDanhBa.MoiGioi, doiTac.MaDoiTac, doiTac.Vung, "", doiTac.IsActive, "", doiTac.KinhDo, doiTac.ViDo, "");
                        listRet.Add(dtx);
                    }
                }

                return listRet;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DanhBa.cs-> GetDanhBaMoiGioi_LastUpdate: ",ex);          
                return new List<DanhBaEx>();
            }
        }

        /// <summary>
        /// hàm thực hiện lấy danh bạ công ty.
        /// </summary>        
        public static List<DanhBaEx> GetDanhBaCongTy()
        {
            try
            {
                // ds danh bạ mở rộng trả về
                List<DanhBaEx> listRet = new List<DanhBaEx>();
                // lấy ds danh bạ công ty
                List<DanhBaCongTy> listDanhBa = DanhBaCongTy.GetDanhSachDanhBaCongTy();
                foreach (DanhBaCongTy dbcty in listDanhBa)
                {
                    string Name = dbcty.Name.Length > 0 ? "[" + dbcty.Name + "] " : "";
                    DanhBaEx dtx = new DanhBaEx(dbcty.PhoneNumber, Name + dbcty.Address, KieuDanhBa.CongTy, string.Empty, 0, "", true);
                    listRet.Add(dtx);
                }
                return listRet;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaCongTy: " ,ex);
                return new List<DanhBaEx>();
            }
        }
        
        /// <summary>
        /// hàm thực hiện lấy danh bạ công ty.
        /// </summary>        
        public static List<DanhBaEx> GetDanhBaCONGTY_GetLast(DateTime LastUpdate)
        {
            try
            {
                // ds danh bạ mở rộng trả về
                List<DanhBaEx> listRet = new List<DanhBaEx>();
                // lấy ds danh bạ công ty
                List<DanhBaCongTy> listDanhBa = DanhBaCongTy.GetDanhBaCONGTY_GetLast(LastUpdate);
                foreach (DanhBaCongTy dbcty in listDanhBa)
                {
                    string Name = dbcty.Name.Length > 0 ? "[" + dbcty.Name + "] " : "";
                    DanhBaEx dtx = new DanhBaEx(dbcty.PhoneNumber, Name + dbcty.Address, KieuDanhBa.CongTy, string.Empty, 0, "", true);
                    listRet.Add(dtx);
                }

                return listRet;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaCONGTY_GetLast: ", ex);                
                return new List<DanhBaEx>();
            }
        }
    }
}
