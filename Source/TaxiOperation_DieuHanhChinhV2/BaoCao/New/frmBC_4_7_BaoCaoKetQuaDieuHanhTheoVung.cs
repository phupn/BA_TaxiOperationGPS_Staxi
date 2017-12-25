using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.BaoCao;
using Taxi.Data.BanCo;
using Taxi.Data.BanCo.Entity.MasterData;
using Taxi.Data.BaoCaoNew;
using Taxi.Common.Extender;
namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    [ReportInfo(Title = "4.7. Báo cáo kết quả điều hành theo vùng")]
    public partial class frmBC_4_7_BaoCaoKetQuaDieuHanhTheoVung : FrmReportBase
    {
        public int Vung { get; set; }
        protected override object GetData()
        {
            var db = BC_4_7_BaoCaoKetQuaDieuHanhTheoVung.Inst.GetData(FromDate.Value, ToDate.Value, Vung);
            var dsVung = CommonData.DSVungDieuHanh;
            db.ForEach(p =>
            {
                long Id = 0;
                string Name = getKenhByDiaChi(dsVung, p.GPS_ViDo, p.GPS_KinhDo, ref Id);
                p.Vung = Name;
                p.VungId = Id;
            });
            db = db.GroupBy(p => new { p.VungId, p.Vung, p.Ngay }).Select(p =>
            {
                return new BC_4_7_BaoCaoKetQuaDieuHanhTheoVung()
                {
                    VungId = p.Key.VungId,
                    Vung = p.Key.Vung,
                    Ngay = p.Key.Ngay,
                    Taxi_Tong = p.Sum(pi => pi.Taxi_Tong),
                    Taxi_MG = p.Sum(pi => pi.Taxi_MG),
                    Taxi_VL = p.Sum(pi => pi.Taxi_VL),
                    DonDuoc_Tong = p.Sum(pi => pi.DonDuoc_Tong),
                    DonDuoc_MG = p.Sum(pi => pi.DonDuoc_MG),
                    DonDuoc_VL = p.Sum(pi => pi.DonDuoc_VL),
                    KhongDonDuoc_Tong = p.Sum(pi => pi.KhongDonDuoc_Tong),
                    KhongDonDuoc_TruotHoan = p.Sum(pi => pi.KhongDonDuoc_TruotHoan),
                    KhongDonDuoc_TruotHoan5Phut = p.Sum(pi => pi.KhongDonDuoc_TruotHoan5Phut),
                    KhongDonDuoc_Khongxe = p.Sum(pi => pi.KhongDonDuoc_Khongxe),
                    KhongDonDuoc_Khac = p.Sum(pi => pi.KhongDonDuoc_Khac),
                    PhanTramdonDuoc = p.Sum(pi => pi.PhanTramdonDuoc),
                    CuocGoiLai_Cuoc = p.Sum(pi => pi.CuocGoiLai_Cuoc),
                    CuocGoiLai_PhanTramGoiLai = p.Sum(pi => pi.CuocGoiLai_PhanTramGoiLai),
                    TyTrongVungNgay = p.Sum(pi => pi.TyTrongVungNgay)
                };
            }).Where(p => Vung == 0 || Vung == null || p.VungId == Vung).ToList();
            db.GroupBy(p => p.Ngay).All(p =>
            {
                float TongCuoc = p.Sum(pi => pi.Taxi_Tong);
                p.All(pi =>
                {
                    pi.TyTrongVungNgay = 100 * (float)pi.Taxi_Tong / (float)TongCuoc;
                    pi.PhanTramdonDuoc = 100 * (float)pi.DonDuoc_Tong / (float)pi.Taxi_Tong;
                    pi.Taxi_VL = pi.Taxi_Tong - pi.Taxi_MG;
                    pi.DonDuoc_VL = pi.DonDuoc_Tong - pi.DonDuoc_MG;
                    pi.CuocGoiLai_PhanTramGoiLai = 100 * (float)pi.CuocGoiLai_Cuoc / (float)pi.Taxi_Tong;
                    return true;
                });
                return true;
            });
            return db;
        }

        private string getKenhByDiaChi(List<VungDieuHanh> G_VungToaDo, float LatDes, float LngDes, ref long VungId)
        {
            try
            {
                foreach (var item in G_VungToaDo)
                {
                    if (item.LsPolygon.Count > 0)
                    {
                        int cn = 0;
                        for (int i = 0; i < item.LsPolygon.Count - 1; i++)
                        {
                            float x1 = item.LsPolygon[i].Key;
                            float y1 = item.LsPolygon[i].Value;
                            float x2 = item.LsPolygon[i + 1].Key;
                            float y2 = item.LsPolygon[i + 1].Value;

                            if (((x1 <= LngDes) && (x2 > LngDes)) || ((x1 > LngDes) && (x2 <= LngDes)))
                            {
                                double vt = (LngDes - x1) / (x2 - x1);
                                if (LatDes < y1 + vt * (y2 - y1))
                                    ++cn;
                            }
                        }
                        if ((cn & 1) > 0)
                        {
                            if (item.FK_CodeVungGPS != null)
                                VungId = item.FK_CodeVungGPS.Value;
                            return item.NameVungDH;
                        } // 0 if even (out), and 1 if odd (in)
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("getKenhByDiaChi", ex);
            }

            return "Khác";
        }
    }
}
