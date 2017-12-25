using System;
using System.Collections.Generic;
using Taxi.Utils;

namespace Taxi.Business
{
    public class DanhBaEx : DanhBa
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

        public string LenhTiepNhan { get; set; }
        public string GhiChuTiepNhan { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public int SoLanGoi { get; set; }
        public long IdCuocGoi { get; set; }
        public float GPS_KinhDo { get; set; }
        public float GPS_ViDo { get; set; }
        public KieuKhachHangGoiDen KieuKHGoiDen { get; set; }
        public DanhBaEx()
        {
            this.PhoneNumber = string.Empty;
            this.Address = string.Empty;
            this.KieuDanhBa = KieuDanhBa.Online;
            this.MaDoiTac = string.Empty;
            this.SoLanGoi = 0;
            this.IdCuocGoi = 0;
            this.Vung = 0;
            this.LoaiXe = string.Empty;
            this.ThoiDiemGoi = DateTime.MinValue;
            this.IsActive = false;
            this.LenhTiepNhan = string.Empty;
            this.GhiChuTiepNhan = string.Empty;
            this.GPS_KinhDo = 0;
            this.GPS_ViDo = 0;
            this.KieuKHGoiDen = KieuKhachHangGoiDen.KhachHangBinhThuong;
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

        /// <summary>
        /// hàm thực hiện trả về ds anh ba môi giới      
        /// </summary>
        public static List<DanhBaEx> GetDanhBaMoiGioi()
        {
            List<DanhBaEx> listRet = new List<DanhBaEx>();
            try
            {
                DoiTac dt = new DoiTac();
                List<DoiTac> listDT = dt.GetListOfDoiTacs(true);

                foreach (DoiTac doiTac in listDT)
                {
                    // tác số điện thoại
                    string[] arrDienThoai = doiTac.Phones.Split(";".ToCharArray());
                    for (int i = 0; i < arrDienThoai.Length; i++)
                    {
                        DanhBaEx dtx = new DanhBaEx()
                        {
                            PhoneNumber = arrDienThoai[i],
                            Address = doiTac.Name + " - " + doiTac.Address,
                            kieuDanhBa = KieuDanhBa.MoiGioi,
                            MaDoiTac = doiTac.MaDoiTac,
                            Vung = doiTac.Vung,
                            IsActive = doiTac.IsActive,
                            GhiChuTiepNhan = doiTac.Notes,
                            GPS_KinhDo = doiTac.KinhDo,
                            GPS_ViDo = doiTac.ViDo,
                            KieuKHGoiDen = KieuKhachHangGoiDen.KhachHangMoiGioi
                        };
                        listRet.Add(dtx);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaMoiGioi ", ex);
            }
            return listRet;
        }

        /// <summary>
        /// Get danh bạ đối tác có sự thay đổi
        /// </summary>
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
                        DanhBaEx dtx = new DanhBaEx(arrDienThoai[i], doiTac.Name + " - " + doiTac.Address, KieuDanhBa.MoiGioi, doiTac.MaDoiTac, doiTac.Vung, "", doiTac.IsActive, "", doiTac.KinhDo, doiTac.ViDo, "");
                        listRet.Add(dtx);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaMoiGioi_LastUpdate ",ex);                
            }

            return listRet;
        }

        /// <summary>
        /// hàm thực hiện lấy danh bạ công ty.
        /// </summary>
        public static List<DanhBaEx> GetDanhBaCongTy()
        {
            //Ds danh bạ mở rộng trả về
            List<DanhBaEx> listRet = new List<DanhBaEx>();
            try
            {
                List<DanhBaCongTy> listDanhBa = DanhBaCongTy.GetDanhSachDanhBaCongTy();
                foreach (DanhBaCongTy dbcty in listDanhBa)
                {
                    string Name = dbcty.Name.Length > 0 ? "[" + dbcty.Name + "] " : "";
                    DanhBaEx dtx = new DanhBaEx()
                    {
                        PhoneNumber = dbcty.PhoneNumber,
                        Address = Name + dbcty.Address,
                        KieuDanhBa = KieuDanhBa.CongTy,
                        KieuKHGoiDen = KieuKhachHangGoiDen.KhachHangBinhThuong,
                        IsActive = true
                    };
                    listRet.Add(dtx);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaCongTy: ",ex);                
            }

            return listRet;
        }

        /// <summary>
        /// hàm thực hiện lấy danh bạ công ty.
        /// </summary>
        /// <returns></returns>
        public static List<DanhBaEx> GetDanhBaCONGTY_GetLast(DateTime LastUpdate)
        {
            List<DanhBaEx> listRet = new List<DanhBaEx>();

            try
            {
                List<DanhBaCongTy> listDanhBa = DanhBaCongTy.GetDanhBaCONGTY_GetLast(LastUpdate);
                foreach (DanhBaCongTy dbcty in listDanhBa)
                {
                    string Name = dbcty.Name.Length > 0 ? "[" + dbcty.Name + "] " : "";
                    DanhBaEx dtx = new DanhBaEx(dbcty.PhoneNumber, Name + dbcty.Address, KieuDanhBa.CongTy, string.Empty, 0, "", true);
                    listRet.Add(dtx);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaCONGTY_GetLast : ", ex);                
            }

            return listRet;
        }

    }
}
