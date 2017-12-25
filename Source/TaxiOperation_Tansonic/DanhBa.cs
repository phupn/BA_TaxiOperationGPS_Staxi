using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Business;
using System.Data;
using Taxi.Business.DM;
using Taxi.Utils;

namespace TaxiCapture
{
    public enum KieuDanhBa :int{

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
        private Guid _BookId;
        public Guid BookId
        {
            get { return _BookId; }
            set { _BookId = value; }
        }
        private string _XeNhan;
        public string XeNhan
        {
            get { return _XeNhan; }
            set { _XeNhan = value; }
        }
        private KieuKhachHangGoiDen _KieuKhachHang;
        public KieuKhachHangGoiDen KieuKhachHang
        {
            get { return _KieuKhachHang; }
            set { _KieuKhachHang = value; }
        }
        private string _SDTLaiXe;
        public string SDTLaiXe
        {
            get { return _SDTLaiXe; }
            set { _SDTLaiXe = value; }
        }
        private string _TenLaiXe;
        public string TenLaiXe
        {
            get { return _TenLaiXe; }
            set { _TenLaiXe = value; }
        }
        private long _IdCuocGoi;
        public long IdCuocGoi
        {
            get { return _IdCuocGoi; }
            set { _IdCuocGoi = value; }
        }
        private int _SoLanGoi;
        public int SoLanGoi
        {
            get { return _SoLanGoi; }
            set { _SoLanGoi = value; }
        }

        public float GPS_KinhDo { get; set; }
        public float GPS_ViDo { get; set; }
        public int G5_CarType { get; set; }
        public DateTime ThoiDiemGoi { get; set; }

        public DanhBaEx()
        {
            this.PhoneNumber = string.Empty;
            this.Address = string.Empty;
            this.KieuDanhBa = KieuDanhBa.Online;
            this.MaDoiTac = string.Empty;
            this.Vung = 0;
            this.LoaiXe = string.Empty;
            this.IsActive = false;
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
        ///        
        /// </summary>
        /// <returns></returns>
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
        ///        
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaEx> GetDanhBaMoiGioi()
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
                    DanhBaEx dtx = new DanhBaEx(arrDienThoai[i], doiTac.Name +" - " + doiTac.Address, KieuDanhBa.MoiGioi, doiTac.MaDoiTac,doiTac.Vung,"", doiTac.IsActive,"","");
                    listRet.Add(dtx);
                }
            }

            return listRet;
        }

        /// <summary>
        /// Get danh bạ đối tác có sự thay đổi
        /// </summary>
        /// <param name="LastUpdate"></param>
        /// <returns></returns>
        public static List<DanhBaEx> GetDanhBaMoiGioi_LastUpdate(DateTime LastUpdate)
        {
            List<DanhBaEx> listRet = new List<DanhBaEx>();
            try
            {
            DoiTac dt = new DoiTac();
            List<DoiTac> listDT = dt.GetCacDoiTacs_LastUpdate(LastUpdate);

            foreach (DoiTac doiTac in listDT)
            {
                // tác số điện thoại
                string[] arrDienThoai = doiTac.Phones.Split(";".ToCharArray());
                for (int i = 0; i < arrDienThoai.Length; i++)
                {
                    DanhBaEx dtx = new DanhBaEx(arrDienThoai[i], doiTac.Name + " - " + doiTac.Address, KieuDanhBa.MoiGioi, doiTac.MaDoiTac, doiTac.Vung, "", doiTac.IsActive,"","");
                    listRet.Add(dtx);
                }
            }


            }
            catch (Exception)
            {

                throw;
            }
            return listRet;
        }

        /// <summary>
        /// hàm thực hiện lấy danh bạ công ty.
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaEx> GetDanhBaCongTy()
        {
            // ds danh bạ mở rộng trả về
            List<DanhBaEx> listRet = new List<DanhBaEx>();
            try
            {
                // lấy ds danh bạ công ty
                List<DanhBaCongTy> listDanhBa = DanhBaCongTy.GetDanhSachDanhBaCongTy();
                foreach (DanhBaCongTy dbcty in listDanhBa)
                {
                    string Name = dbcty.Name.Length > 0 ? "[" + dbcty.Name + "] " : "";
                    DanhBaEx dtx = new DanhBaEx(dbcty.PhoneNumber, Name + dbcty.Address, KieuDanhBa.CongTy, string.Empty, 0, "", true, "", "");
                    listRet.Add(dtx);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaCongTy:", ex);
            }
            return listRet;
        }
        
        /// <summary>
        /// hàm thực hiện lấy danh bạ công ty.
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaEx> GetDanhBaCONGTY_GetLast(DateTime LastUpdate)
        {
            // ds danh bạ mở rộng trả về
            List<DanhBaEx> listRet = new List<DanhBaEx>();
            try
            {
            // lấy ds danh bạ công ty
            List<DanhBaCongTy> listDanhBa = DanhBaCongTy.GetDanhBaCONGTY_GetLast(LastUpdate);
            foreach (DanhBaCongTy dbcty in listDanhBa)
            {
                string Name = dbcty.Name.Length > 0 ? "[" + dbcty.Name + "] " : "";
                DanhBaEx dtx = new DanhBaEx(dbcty.PhoneNumber, Name + dbcty.Address, KieuDanhBa.CongTy, string.Empty, 0, "", true, "", "");
                listRet.Add(dtx);
            }


            }
            catch (Exception)
            {

                throw;
            }
            return listRet;
        }

    }
}
