using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Utils;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    /// <summary>
    /// 
    /// </summary>
    public class BaoCaoTongKetLoaiXeTheoThang : TaxiOperationDbEntityBase<BaoCaoTongKetLoaiXeTheoThang>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="loaixe"></param>
        /// <param name="ShowAll"></param>
        /// <returns></returns>
        public DataTable GetDataReport(DateTime? from, DateTime? to, string loaixe,bool ShowAll=false)
        {
            var dataNow = GetDataReportAndGroupByLoaiXeVaCa(from, to, loaixe);
            var dataPrevious = GetDataReportAndGroupByLoaiXeVaCa(from.Value.AddMonths(-1), from.Value.AddSeconds(-1), loaixe);

            var table = new DataTable();
            table.Columns.Add("LoaiXe");
            table.Columns.Add("TenLoaiXe");
            table.Columns.Add("Ca");
            table.Columns.Add("TongCuoc"); table.Columns.Add("TongCuoc_t"); table.Columns.Add("TongCuoc_s");
            table.Columns.Add("ThueBao"); table.Columns.Add("ThueBao_t"); table.Columns.Add("ThueBao_s");
            table.Columns.Add("KhaiThac"); table.Columns.Add("KhaiThac_t"); table.Columns.Add("KhaiThac_s");
            table.Columns.Add("MoCua"); table.Columns.Add("MoCua_t"); table.Columns.Add("MoCua_s");
            table.Columns.Add("Truot"); table.Columns.Add("Truot_t"); table.Columns.Add("Truot_s");

            var listLoaiXe = TuDien_LoaiXe.Inst.GetListAll();

            if (!string.IsNullOrEmpty(loaixe))
                listLoaiXe = listLoaiXe.Join(loaixe.Split(','), lx => lx.LoaiXeID.ToString(), s => s.Trim(), (lx, s) => lx).ToList();

            listLoaiXe.ForEach(lx =>
            {
                for (int i = 1; i <= 3; i++)
                {
                    var dr = table.NewRow();
                    dr["LoaiXe"] = lx.LoaiXeID;
                    dr["TenLoaiXe"] = lx.TenLoaiXe;
                    dr["Ca"] = "Cuốc ca " + i;
                    table.Rows.Add(dr);
                }
            });

            // Dữ liệu tháng hiện tại
            table.AsEnumerable().Join(dataNow, dr => dr["LoaiXe"] + "_" + dr["Ca"], dn => dn["LoaiXe"] + "_" + dn["Ca"], (dr, dn) =>
            {
                dr["TongCuoc"] = dn["TongCuoc"];
                dr["ThueBao"] = dn["ThueBao"];
                dr["KhaiThac"] = dn["KhaiThac"];
                dr["MoCua"] = dn["MoCua"];
                dr["Truot"] = dn["Truot"];
                return false;
            }).Count();

            // Dữ liệu tháng trước
            table.AsEnumerable().Join(dataPrevious, dr => dr["LoaiXe"] + "_" + dr["Ca"], dn => dn["LoaiXe"] + "_" + dn["Ca"], (dr, dn) =>
            {
                dr["TongCuoc_t"] = dn["TongCuoc"];
                dr["ThueBao_t"] = dn["ThueBao"];
                dr["KhaiThac_t"] = dn["KhaiThac"];
                dr["MoCua_t"] = dn["MoCua"];
                dr["Truot_t"] = dn["Truot"];
                return false;
            }).Count();

            table.AsEnumerable().Select(dr =>
            {
                dr["TongCuoc_s"] = dr["TongCuoc"].To<int>() - dr["TongCuoc_t"].To<int>();
                dr["ThueBao_s"] = dr["ThueBao"].To<int>() - dr["ThueBao_t"].To<int>();
                dr["KhaiThac_s"] = dr["KhaiThac"].To<int>() - dr["KhaiThac_t"].To<int>();
                dr["MoCua_s"] = dr["MoCua"].To<int>() - dr["MoCua_t"].To<int>();
                dr["Truot_s"] = dr["Truot"].To<int>() - dr["Truot_t"].To<int>();

                if (dr["TongCuoc"].Equals(DBNull.Value)) dr["TongCuoc"] = 0;
                if (dr["TongCuoc_t"].Equals(DBNull.Value)) dr["TongCuoc_t"] = 0;

                if (dr["ThueBao"].Equals(DBNull.Value)) dr["ThueBao"] = 0;
                if (dr["ThueBao_t"].Equals(DBNull.Value)) dr["ThueBao_t"] = 0;

                if (dr["MoCua"].Equals(DBNull.Value)) dr["MoCua"] = 0;
                if (dr["MoCua_t"].Equals(DBNull.Value)) dr["MoCua_t"] = 0;

                if (dr["Truot"].Equals(DBNull.Value)) dr["Truot"] = 0;
                if (dr["Truot_t"].Equals(DBNull.Value)) dr["Truot_t"] = 0;

                if (dr["KhaiThac"].Equals(DBNull.Value)) dr["KhaiThac"] = 0;
                if (dr["KhaiThac_t"].Equals(DBNull.Value)) dr["KhaiThac_t"] = 0;

                return false;
            }).Count();
            if (ShowAll)
            {
                // Tất cả loại
                table.AsEnumerable().GroupBy(gb => gb["Ca"]).ToList().ForEach(data1 =>
                {
                    var dr1 = table.NewRow();
                    dr1["Ca"] = data1.Key;
                    dr1["LoaiXe"] = "Tổng hợp";
                    dr1["TenLoaiXe"] = "Tổng hợp";
                    dr1["TongCuoc"] = data1.Sum(s => s["TongCuoc"].To<Decimal>());
                    dr1["TongCuoc_t"] = data1.Sum(s => s["TongCuoc_t"].To<Decimal>());
                    dr1["TongCuoc_s"] = data1.Sum(s => s["TongCuoc_s"].To<Decimal>());

                    dr1["ThueBao"] = data1.Sum(s => s["ThueBao"].To<Decimal>());
                    dr1["ThueBao_t"] = data1.Sum(s => s["ThueBao_t"].To<Decimal>());
                    dr1["ThueBao_s"] = data1.Sum(s => s["ThueBao_s"].To<Decimal>());

                    dr1["MoCua"] = data1.Sum(s => s["MoCua"].To<Decimal>());
                    dr1["MoCua_t"] = data1.Sum(s => s["MoCua_t"].To<Decimal>());
                    dr1["MoCua_s"] = data1.Sum(s => s["MoCua_s"].To<Decimal>());

                    dr1["Truot"] = data1.Sum(s => s["Truot"].To<Decimal>());
                    dr1["Truot_s"] = data1.Sum(s => s["Truot_s"].To<Decimal>());
                    dr1["Truot_t"] = data1.Sum(s => s["Truot_t"].To<Decimal>());

                    dr1["KhaiThac"] = data1.Sum(s => s["KhaiThac"].To<Decimal>());
                    dr1["KhaiThac_t"] = data1.Sum(s => s["KhaiThac_t"].To<Decimal>());
                    dr1["KhaiThac_s"] = data1.Sum(s => s["KhaiThac_s"].To<Decimal>());

                    table.Rows.Add(dr1);
                });
           
            }
            
            //
            table.AsEnumerable().GroupBy(dr => dr["LoaiXe"]).ToList().ForEach(gr =>
            {
                var first = gr.First();

                var dr = table.NewRow();
                dr["Ca"] = "Tổng";
                dr["LoaiXe"] = first["LoaiXe"];
                dr["TenLoaiXe"] = first["TenLoaiXe"];

                int TongCuoc = 0;
                int TongCuoc_t = 0;
                int TongCuoc_s = 0;

                int ThueBao = 0;
                int ThueBao_t = 0;
                int ThueBao_s = 0;

                int MoCua = 0;
                int MoCua_t = 0;
                int MoCua_s = 0;

                int Truot = 0;
                int Truot_t = 0;
                int Truot_s = 0;

                int KhaiThac = 0;
                int KhaiThac_t = 0;
                int KhaiThac_s = 0;

                foreach (var gri in gr)
                {
                    TongCuoc += Convert.ToInt32(gri["TongCuoc"]);
                    TongCuoc_t += Convert.ToInt32(gri["TongCuoc_t"]);
                    TongCuoc_s += Convert.ToInt32(gri["TongCuoc_s"]);

                    ThueBao += Convert.ToInt32(gri["ThueBao"]);
                    ThueBao_t += Convert.ToInt32(gri["ThueBao_t"]);
                    ThueBao_s += Convert.ToInt32(gri["ThueBao_s"]);

                    MoCua += Convert.ToInt32(gri["MoCua"]);
                    MoCua_t += Convert.ToInt32(gri["MoCua_t"]);
                    MoCua_s += Convert.ToInt32(gri["MoCua_s"]);

                    Truot += Convert.ToInt32(gri["Truot"]);
                    Truot_t += Convert.ToInt32(gri["Truot_t"]);
                    Truot_s += Convert.ToInt32(gri["Truot_s"]);

                    KhaiThac += Convert.ToInt32(gri["KhaiThac"]);
                    KhaiThac_t += Convert.ToInt32(gri["KhaiThac_t"]);
                    KhaiThac_s += Convert.ToInt32(gri["KhaiThac_s"]);
                }

                dr["TongCuoc"] = TongCuoc;
                dr["TongCuoc_t"] = TongCuoc_t;
                dr["TongCuoc_s"] = TongCuoc_s;

                dr["ThueBao"] = ThueBao;
                dr["ThueBao_t"] = ThueBao_t;
                dr["ThueBao_s"] = ThueBao_s;

                dr["MoCua"] = MoCua;
                dr["MoCua_t"] = MoCua_t;
                dr["MoCua_s"] = MoCua_s;

                dr["Truot"] = Truot;
                dr["Truot_t"] = Truot_t;
                dr["Truot_s"] = Truot_s;

                dr["KhaiThac"] = KhaiThac;
                dr["KhaiThac_t"] = KhaiThac_t;
                dr["KhaiThac_s"] = KhaiThac_s;

                table.Rows.Add(dr);
            });
            return table;
        }

        /// <summary>
        /// Lấy dữ liệu và group theo loại xe vả theo ca
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="loaixe"></param>
        /// <returns></returns>
        public IEnumerable<DataRow> GetDataReportAndGroupByLoaiXeVaCa(DateTime? from, DateTime? to, string loaixe)
        {
            var table = ExeStore("EnVang_Report_BaoCaoTongKetLoaiXeTheoThang", from, to, loaixe);

            table.Columns.Add("TongCuoc");
            table.Columns.Add("ThueBao");
            table.Columns.Add("KhaiThac");
            table.Columns.Add("MoCua");
            table.Columns.Add("Truot");
            return table.AsEnumerable().GroupBy(dr => dr["LoaiXe"].ToString()).SelectMany(gr => gr.GroupBy(gri => gri["Ca"].ToString()).Select(grii =>
            {
                // Đếm số cuốc theo ca
                var dr = grii.First();

                int thuebao = 0, khaithac = 0, mocua = 0, truot = 0,CuocThanhCong = 0;
                    
                // 
                foreach (var dri in grii)
                {
                    var kch = dri["KieuCuocHang"].To<int>();
                    var KieuCuocGoi = dri["KieuCuocGoi"].To<int>();
                    var KetQua = dri["KetQua"].To<int>();
                    var gtb = dri["GiaThueBao"].ToString();
                    var LoaiCuocHang = dri["LoaiCuocHang"].To<int>();
                    var SoDT = dri["SoDT"].ToString();
                    //1,4,5,6,8
                    //;
                    if (KieuCuocGoi == (int)Enum_CallType.GoiXe
                    && LoaiCuocHang != (int)LoaiCuocHangThucHien.CuocBinhThuong
                    && LoaiCuocHang != (int)LoaiCuocHangThucHien.MoCua
                    && LoaiCuocHang != (int)LoaiCuocHangThucHien.ThueBaoMeter) 
                        thuebao++;//!string.IsNullOrEmpty(gtb)
                    if (KieuCuocGoi == (int)Enum_CallType.GoiXe
                       &&
                         SoDT.Equals(CommonData.SDTLXKT)) khaithac++;//kch == 1 ||
                    if (KieuCuocGoi == (int)Enum_CallType.GoiXe
                    && (KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiTruot)) truot++;
                    if (LoaiCuocHang == (int)LoaiCuocHangThucHien.MoCua) mocua++;
                    if (KieuCuocGoi == (int)Enum_CallType.GoiXe && KetQua != (int)TrangThaiCuocGoiTaxi.CuocGoiTruot && KetQua != (int)TrangThaiCuocGoiTaxi.CuocGoiHoan && KetQua != (int)TrangThaiCuocGoiTaxi.CuocGoiKhongXe) CuocThanhCong++;
                }

                dr["TongCuoc"] = grii.Count();// thuebao + khaithac + mocua + truot + CuocThanhCong;
                dr["ThueBao"] = thuebao;
                dr["KhaiThac"] = khaithac;
                dr["MoCua"] = mocua;
                dr["Truot"] = truot;

                return dr;
            }));
        }
    }
}
