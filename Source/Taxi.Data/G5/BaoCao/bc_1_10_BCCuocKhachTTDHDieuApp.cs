using System;
using System.Collections.Generic;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Data.G5
{
    public class G5_1_10_BCCuocKhachTTDHDieuApp : DbEntityBase<G5_1_10_BCCuocKhachTTDHDieuApp>
    {
        #region Const 

        public const string sp_BC_TongHopDieuAppNew = "sp_BC_1_10_TongHopDieuAppNew";

        #endregion

        #region==Properties==
        public DateTime Ngay { get; set; }
        public int CuocGoiTaxiTTDH { get; set; }
        public int CuocTTDHDieuApp { get; set; }
        public int SoCuocLXNhan { get; set; }
        public int SoCuocTraLai { get; set; }
        public int DonDuocDieuApp { get; set; }
        public int TruotHoanDieuApp { get; set; }
        public int XeDungDiem { get; set; }
        public int AppKhongPhanHoiGapKhach { get; set; }
        public string PhanTramDonDuoc
        {
            get
            {
                if (SoCuocLXNhan == 0)
                {
                    return "0%";
                }
                else
                {
                    return String.Format("{0:0,0}", ((float)DonDuocDieuApp / SoCuocLXNhan * 100)) + "%";
                }                
            }
            set { }
        }
        //public string DieuApp_PhanTram
        //{

        //    get
        //    {
        //        if (CuocTTDHDieuApp == 0)
        //        {
        //            return "0%";
        //        }
        //        else
        //        {
        //            return String.Format("{0:0,0}", ((float)CuocGoiTaxiTTDH / CuocTTDHDieuApp * 100)) + "%";
        //        }
        //        ;
        //    }
        //    set { ;}
        //}
        #region === New ==
        public int CuocGoiTaxi { get; set; }
        public int DieuApp_Tong{ get; set; }
        public int DieuApp_DonDuoc{ get; set; }
        public int DieuApp_TruotHoan{ get; set; }
        public float DieuApp_PhanTram { get { return CuocGoiTaxi <= 0 ? 0 : (100 * ((float)DieuApp_Tong / (float)CuocGoiTaxi)); } }
        public float DieuApp_PhanTramDonDuoc { get { return DieuApp_Tong <= 0 ? 0 : (100 * ((float)DieuApp_DonDuoc / (float)DieuApp_Tong)); } }
        public int DieuDam_Tong{ get; set; }
        public int DieuDam_DonDuoc{ get; set; }
        public int DieuDam_TruotHoan{ get; set; }
        public int DieuDam_KhongXe{ get; set; }
        public float DieuDam_PhanTramDonDuoc { get { return DieuDam_Tong <= 0 ? 0 : (100 * ((float)DieuDam_DonDuoc / (float)DieuDam_Tong)); } }
        public int ChuyenDam_Tong { get; set; }
        public int ChuyenDam_DonDuoc { get; set; }
        public int ChuyenDam_TruotHoan { get; set; }
        public int ChuyenDam_KhongXe { get; set; }
        public float ChuyenDam_PhanTramDonDuoc { get { return ChuyenDam_Tong <= 0 ? 0 : (100 * ((float)ChuyenDam_DonDuoc / (float)ChuyenDam_Tong)); } }
        public int SoCuoChuyenDam{ get; set; }
        
        #endregion
        #endregion

        #region==Method==
        public List<G5_1_10_BCCuocKhachTTDHDieuApp> GetData(DateTime tuNgay, DateTime denNgay)
        {
            return ExeStore("G5_BaoCao_SP_dh_BaoCaoCuocKhachTTDHDieuApp", tuNgay, denNgay).ToList<G5_1_10_BCCuocKhachTTDHDieuApp>();
        }
        #endregion

        #region ===Báo cáo điều app ====
        public static List<G5_1_10_BCCuocKhachTTDHDieuApp> GetBaoCaoTongHopDieuAppNew(DateTime tuNgay, DateTime denNgay)
        {
            return Inst.ExeStore(sp_BC_TongHopDieuAppNew, tuNgay, denNgay).ToList<G5_1_10_BCCuocKhachTTDHDieuApp>();
        }
        #endregion
    }
}
