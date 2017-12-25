#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Data;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.BaoCao
{
    public class bc_4_5_BaoCaoTongHopKQDieuHanhNV : DbEntityBase<bc_4_5_BaoCaoTongHopKQDieuHanhNV>
    {
        private const string sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV = "sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV";

        #region === Field ===
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int CuocGoiNhan { get; set; }
        public int CuocGoiTaxi { get; set; }
        public int CuocGoiGPS { get; set; }
        public int CuocChuyenTDCham { get; set; }
        public float PhanTramChuyenCham { get; set; }
        public int CuocGoiDieu { get; set; }
        public int CuocGoiDonDuoc { get; set; }
        public float PhanTramDonDuoc { get; set; }
        public int XeKhongXacDinh { get; set; }
        public int CuocTinhThoiGianDon { get; set; }
        public int SoGiayTrungBinh { get; set; }
        public int CuocGoiTaxiCS { get; set; }
        public int CuocGoiCoCS { get; set; }
        public float PhanTramCoCS { get; set; }
        public int DonDuocCS { get; set; }
        public float PhanTramDonDuocCS { get; set; }
        public int CuocTinhThoiGianDonCS { get; set; }
        public int SoGiayTrungBinhCS { get; set; }
        public int CuocDieuG5 { get; set; }
        public int DonDuocG5 { get; set; }
        public float PhanTramDonDuocG5 { get; set; }

        public int TongCuocSB { get; set; }
        public int DonDuocSB { get; set; }
        public int KhongDonDuocSB { get; set; }
        public float PhanTramDonDuocSB { get; set; }

        #endregion

        public List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> GetReport(DateTime TuNgay, DateTime DenNgay, int SoGiayGioiHanChuyenTongDai, string pMaNhanVien)
        {
            List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lstBC = new List<bc_4_5_BaoCaoTongHopKQDieuHanhNV>();
            DataTable dtNhanVien = GetAllUserInfo(pMaNhanVien);
            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                foreach (DataRow dr in dtNhanVien.Rows)
                {
                    bc_4_5_BaoCaoTongHopKQDieuHanhNV item = new bc_4_5_BaoCaoTongHopKQDieuHanhNV();
                    item.MaNhanVien = dr["USER_ID"].ToString();
                    item.TenNhanVien = dr["USER_ID"] + " - " + dr["FULLNAME"];
                    lstBC.Add(item);
                }
            }
            else
            {
                return null;
            }

            GetDuLieuDienThoai(ref lstBC, TuNgay, DenNgay, SoGiayGioiHanChuyenTongDai, pMaNhanVien);
            GetDuLieuG5(ref lstBC, TuNgay, DenNgay, pMaNhanVien);
            GetDuLieuTongDai(ref lstBC, TuNgay, DenNgay, pMaNhanVien);
            GetDuLieuTongDai_TG(ref lstBC, TuNgay, DenNgay, pMaNhanVien);
            GetDuLieuCS(ref lstBC, TuNgay, DenNgay, pMaNhanVien);
            GetDuLieuTGCS(ref lstBC, TuNgay, DenNgay, pMaNhanVien);
            GetDuLieuSanBay(ref lstBC, TuNgay, DenNgay, pMaNhanVien);
            return lstBC;
        }

        private void GetDuLieuSanBay(ref List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lst, DateTime TuNgay, DateTime DenNgay, string pMaNhanVien)
        {
            DataTable dt = ExeStore("sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV_SanBay", TuNgay, DenNgay, pMaNhanVien);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var item = lst.Find(x=>x.MaNhanVien.ToLower()==row["MaNhanVien"].ToString().ToLower());
                    if (item != null)
                    {
                        item.TongCuocSB = int.Parse(row["TongCuocSB"].ToString());
                        item.DonDuocSB = int.Parse(row["DonDuocSB"].ToString());
                        item.KhongDonDuocSB = int.Parse(row["KhongDonDuocSB"].ToString());
                        item.PhanTramDonDuocSB = int.Parse(row["PhanTramDonDuocSB"].ToString());
                    }
                }
            }
        }
        private DataTable GetAllUserInfo(string pMaNhanVien)
        {
            return ExeStore("SP_SYS_USER_SELECT_ALL_INCLUDE_INFO_REPORT_V2", pMaNhanVien);
        }
        
        private void GetDuLieuDienThoai(ref List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lst, DateTime TuNgay, DateTime DenNgay, int SoGiayGioiHanChuyenTongDai, string MaNhanVien = null)
        {
            DataTable dt = ExeStore("sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV_DT", TuNgay, DenNgay, MaNhanVien, SoGiayGioiHanChuyenTongDai);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = lst.Find(x => x.MaNhanVien.ToUpper() == dr["MaNhanVien"].ToString().ToUpper());
                    if (item != null)
                    {
                        item.CuocGoiNhan = int.Parse(dr["CuocGoiNhan"].ToString());
                        item.CuocGoiTaxi = int.Parse(dr["CuocGoiTaxi"].ToString());
                        item.CuocGoiGPS = int.Parse(dr["CuocGoiGPS"].ToString());
                        item.CuocChuyenTDCham = int.Parse(dr["CuocChuyenTDCham"].ToString());
                        item.PhanTramChuyenCham = float.Parse(dr["PhanTramChuyenCham"].ToString());
                    }
                }
            }
        }

        private void GetDuLieuG5(ref List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lst, DateTime TuNgay, DateTime DenNgay, string MaNhanVien = null)
        {
            DataTable dt = ExeStore("sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV_G5", TuNgay, DenNgay, MaNhanVien);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = lst.Find(x => x.MaNhanVien.ToUpper() == dr["MaNhanVien"].ToString().ToUpper());
                    if (item != null)
                    {
                        item.CuocDieuG5 = int.Parse(dr["CuocDieuG5"].ToString());
                        item.DonDuocG5 = int.Parse(dr["DonDuocG5"].ToString());
                        item.PhanTramDonDuocG5 = float.Parse(dr["PhanTramDonDuocG5"].ToString());
                    }
                }
            }
        }
        private void GetDuLieuTongDai(ref List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lst, DateTime TuNgay, DateTime DenNgay, string MaNhanVien = null)
        {
            DataTable dt = ExeStore("sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV_TD", TuNgay, DenNgay, MaNhanVien);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = lst.Find(x => x.MaNhanVien.ToUpper() == dr["MaNhanVien"].ToString().ToUpper());
                    if (item != null)
                    {
                        item.CuocGoiDieu = int.Parse(dr["CuocGoiDieu"].ToString());
                        item.CuocGoiDonDuoc = int.Parse(dr["CuocGoiDonDuoc"].ToString());
                        item.PhanTramDonDuoc = float.Parse(dr["PhanTramDonDuoc"].ToString());
                        item.XeKhongXacDinh = int.Parse(dr["XeKhongXacDinh"].ToString());
                    }
                }
            }
        }
        private void GetDuLieuTongDai_TG(ref List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lst, DateTime TuNgay, DateTime DenNgay, string MaNhanVien = null)
        {
            DataTable dt = ExeStore("sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV_TDTG", TuNgay, DenNgay, MaNhanVien);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = lst.Find(x => x.MaNhanVien.ToUpper() == dr["MaNhanVien"].ToString().ToUpper());
                    if (item != null)
                    {
                        item.CuocTinhThoiGianDon = int.Parse(dr["CuocTinhThoiGianDon"].ToString());
                        item.SoGiayTrungBinh = int.Parse(dr["SoGiayTrungBinh"].ToString());
                    }
                }
            }
        }
        private void GetDuLieuCS(ref List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lst, DateTime TuNgay, DateTime DenNgay, string MaNhanVien = null)
        {
            DataTable dt = ExeStore("sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV_CS", TuNgay, DenNgay, MaNhanVien);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = lst.Find(x => x.MaNhanVien.ToUpper() == dr["MaNhanVien"].ToString().ToUpper());
                    if (item != null)
                    {
                        item.CuocGoiTaxiCS = int.Parse(dr["CuocGoiTaxiCS"].ToString());
                        item.CuocGoiCoCS = int.Parse(dr["CuocGoiCoCS"].ToString());
                        item.PhanTramCoCS = float.Parse(dr["PhanTramCoCS"].ToString());
                        item.DonDuocCS = int.Parse(dr["DonDuocCS"].ToString());
                        item.PhanTramDonDuocCS = float.Parse(dr["PhanTramDonDuocCS"].ToString());
                    }
                }
            }
        }
        private void GetDuLieuTGCS(ref List<bc_4_5_BaoCaoTongHopKQDieuHanhNV> lst, DateTime TuNgay, DateTime DenNgay, string MaNhanVien = null)
        {
            DataTable dt = ExeStore("sp_bc_4_5_BaoCaoTongHopKQDieuHanhNV_TGCS", TuNgay, DenNgay, MaNhanVien);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = lst.Find(x => x.MaNhanVien.ToUpper() == dr["MaNhanVien"].ToString().ToUpper());
                    if (item != null)
                    {
                        item.CuocTinhThoiGianDonCS = int.Parse(dr["CuocTinhThoiGianDonCS"].ToString());
                        item.SoGiayTrungBinhCS = int.Parse(dr["SoGiayTrungBinhCS"].ToString());
                    }
                }
            }
        }
        private static string GetTenIDNhanVien(DataTable dtNhanVien, string NhanVienID)
        {
            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                foreach (DataRow dr in dtNhanVien.Rows)
                {
                    if (dr["USER_ID"].ToString() == NhanVienID)
                    {
                        return dr["TenHienThi"].ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
