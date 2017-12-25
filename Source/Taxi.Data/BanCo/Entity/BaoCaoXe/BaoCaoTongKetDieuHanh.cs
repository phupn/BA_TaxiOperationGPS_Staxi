using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
using System.Linq;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Utils;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoTongKetDieuHanh : TaxiOperationDbEntityBase<BaoCaoTongKetDieuHanh>
    {
        public DataTable GetDataReport(DateTime? from, DateTime? to, string nhanvien)
        {
            var table = this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoTongKetDieuHanh", from, to, nhanvien);

            table.Columns.Add("TongCuoc");
            table.Columns.Add("GoiXe");
            table.Columns.Add("GoiNho");
            table.Columns.Add("GoiLai");
            table.Columns.Add("HoiGia");
            table.Columns.Add("BocXepKhachGoi");
            table.Columns.Add("SDTBocXep");            
            table.Columns.Add("KhieuNai");
            table.Columns.Add("XinLoi");
            table.Columns.Add("NoiBo");
            table.Columns.Add("NhayMay");
            table.Columns.Add("GoiKhac");
            table.Columns.Add("KhachHen");
            table.Columns.Add("KhachHoan");
            table.Columns.Add("HetXe");
            table.Columns.Add("GiucXe");
            table.Columns.Add("GhiChu");
            table.Columns.Add("CuocDieu");
            table.Columns.Add("ThanhCong");
            table.Columns.Add("Truot");
            table.Columns.Add("Hoan");
            table.Columns.Add("KhongXe");
            table.Columns.Add("DangDieu");
            var intGoiXe = (int)Enum_CallType.GoiXe;
            var data = table.AsEnumerable().GroupBy(dr => dr["MaNhanVien"].ToString()).Select(gr =>
            {
                var dr = gr.First();

                var tongcuoc = 0;
                var thanhcong = 0;
                var truot = 0;
                var hoan = 0;
                var khongxe = 0;
                var goilai = 0;
                var hoigia = 0;
                var bocxepkhachgoi = 0;
                var sdtbocxep = 0;
                var xinloi = 0;
                var khieunai = 0;
                var cuocdieu = 0;
                var GoiNho = 0;
                var NoiBo = 0;
                var NhayMay = 0;
                var GoiKhac = 0;
                var KhachHen = 0;
                var KhachHoan = 0;
                var HetXe = 0;
                var GiucXe = 0;
                var CuocDieu = 0;
                var DangDieu = 0;
                foreach (var gri in gr)
                {
                    var KieuCuocGoi = gri["KieuCuocGoi"].To<int>();
                    var KetQua = gri["KetQua"].To<int>();
                    var IsTiepNhan = gri["IsTiepNhan"].To<bool>();
                    if (IsTiepNhan)
                    {
                        tongcuoc++;

                        if (KieuCuocGoi == (int)Enum_CallType.GoiXe) cuocdieu++;
                        if (KieuCuocGoi == (int)Enum_CallType.NoiBo) NoiBo++;
                        if (KieuCuocGoi == (int)Enum_CallType.NhayMay) NhayMay++;
                        if (KieuCuocGoi == (int)Enum_CallType.GoiKhac) GoiKhac++;
                        if (KieuCuocGoi == (int)Enum_CallType.KhachHen) KhachHen++;
                        if (KieuCuocGoi == (int)Enum_CallType.KhachHoan) KhachHoan++;
                        if (KieuCuocGoi == (int)Enum_CallType.HetXe) HetXe++;
                        if (KieuCuocGoi == (int)Enum_CallType.GiucXe) GiucXe++;
                        if (KieuCuocGoi == (int)Enum_CallType.GoiNho) GoiNho++;
                        if (KieuCuocGoi == (int)Enum_CallType.GoiLai) goilai++;
                        if (KieuCuocGoi == (int)Enum_CallType.HoiGia) hoigia++;
                        if (KieuCuocGoi == (int)Enum_CallType.BocXep) bocxepkhachgoi++;
                        if (KieuCuocGoi == (int)Enum_CallType.XinLoiKhach) xinloi++;
                        if (KieuCuocGoi == (int)Enum_CallType.KhieuNai) khieunai++; ;
                        if (CommonData.SDTBocXep == gri["SoDT"].ToString()) sdtbocxep++;
                    }
                    else
                    {
                        if ((KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach ||
                            KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiThanhCong) &&
                            KieuCuocGoi == intGoiXe) thanhcong++;
                        else if (KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiTruot && KieuCuocGoi == intGoiXe) truot++;
                        else if (KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiHoan && KieuCuocGoi == intGoiXe) hoan++;
                        else if (KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiKhongXe && KieuCuocGoi == intGoiXe) khongxe++;
                        else DangDieu++;
                    }

                }

                CuocDieu = thanhcong + truot + hoan + khongxe + DangDieu;

                dr["TongCuoc"] = tongcuoc;
                dr["GoiXe"] = cuocdieu;
                dr["GoiNho"] = GoiNho;
                dr["GoiLai"] = goilai;
                dr["HoiGia"] = hoigia;
                dr["BocXepKhachGoi"] = bocxepkhachgoi;
                dr["SDTBocXep"] = sdtbocxep;
                dr["KhieuNai"] = khieunai;
                dr["XinLoi"] = xinloi;
                dr["NoiBo"] = NoiBo;
                dr["NhayMay"] = NhayMay;
                dr["GoiKhac"] = GoiKhac;
                dr["KhachHen"] = KhachHen;
                dr["KhachHoan"] = KhachHoan;
                dr["HetXe"] = HetXe;
                dr["GiucXe"] = GiucXe;
                dr["CuocDieu"] = CuocDieu;
                dr["ThanhCong"] = thanhcong;
                dr["Truot"] = truot;
                dr["Hoan"] = hoan;
                dr["KhongXe"] = khongxe;
                dr["DangDieu"] = DangDieu;

                return dr;
            }).ToList();

            return data.Count != 0 ? data.CopyToDataTable() : null;
        }
    }
}
