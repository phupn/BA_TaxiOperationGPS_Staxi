using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Utils;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoKetQuaHoatDongCuaCacXeTheoThang : TaxiOperationDbEntityBase<BaoCaoKetQuaHoatDongCuaCacXeTheoThang>
    {
        public DataTable GetDataReport(DateTime? from, DateTime? to, string loaixe)
        {
            var table = new DataTable();
            table.Columns.Add("LoaiXe");
            table.Columns.Add("TenLoaiXe");
            table.Columns.Add("NoiDung");
            table.Columns.Add("Value", typeof(decimal));
            table.Columns.Add("Value_tl", typeof(decimal));
            table.Columns.Add("Value_t", typeof(decimal));
            table.Columns.Add("Value_t_tl", typeof(decimal));
            table.Columns.Add("Value_s", typeof(decimal));

            var listLoaiXe = TuDien_LoaiXe.Inst.GetListAll();

            if (!string.IsNullOrEmpty(loaixe))
                listLoaiXe = listLoaiXe.Join(loaixe.Split(','), lx => lx.LoaiXeID.ToString(), s => s.Trim(), (lx, s) => lx).ToList();

            var tableCurrent  = GetDataInRangeDate(from, to, loaixe);
            var tablePrevious = GetDataInRangeDate(from.Value.AddMonths(-1), from.Value.AddSeconds(-1), loaixe);

            Func<DataTable, string, string, decimal> func = (dt,lx, nd)=>
            {
                if (lx.Trim() == "")
                {
                    decimal tong = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        if (dt.Rows[i]["NoiDung"].ToString() == nd)
                            tong+= dt.Rows[i]["Value"].To<decimal>();
                    return tong;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i]["LoaiXe"].ToString() == lx && dt.Rows[i]["NoiDung"].ToString() == nd)
                        return dt.Rows[i]["Value"].To<decimal>();

                return 0;
            };


            Action<int, string, string, decimal, decimal, decimal, decimal, bool> addRow = (lx, tlx, nd, tn,tcn, tt,tct, tinhtyle) =>
            {
                var dr = table.NewRow();
                dr["LoaiXe"] = lx;
                dr["TenLoaiXe"] = tlx;
                dr["NoiDung"] = nd;
                dr["Value"] = tn;
                dr["Value_t"] = tt;
                dr["Value_s"] = tn - tt == 0 ? (object)DBNull.Value : tn - tt;

                if (tinhtyle)
                {
                    dr["Value_tl"] = tcn == 0 ? (object)DBNull.Value : (tn / tcn) * 100;
                    dr["Value_t_tl"] = tct == 0 ? (object)DBNull.Value : (tt / tct) * 100;
                }
                table.Rows.Add(dr);
            };

            listLoaiXe.ForEach(lx =>
            {
                var tongCuocNay = func(tableCurrent, lx.LoaiXeID.ToString(), "Tổng cuốc");
                var tongCuocTruoc = func(tablePrevious, lx.LoaiXeID.ToString(), "Tổng cuốc");
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Tổng cuốc", tongCuocNay,0, tongCuocTruoc,0, false);

                var kmkd_tn = func(tableCurrent, lx.LoaiXeID.ToString(), "Tổng KMKD");
                var kmkd_tt = func(tablePrevious, lx.LoaiXeID.ToString(), "Tổng KMKD");
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Tổng KMKD", kmkd_tn, 0, kmkd_tt, 0, false);

                var kmcohang_tn = func(tableCurrent, lx.LoaiXeID.ToString(), "KM có hàng");
                var kmcohang_tt = func(tablePrevious, lx.LoaiXeID.ToString(), "KM có hàng");
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "KM có hàng", kmcohang_tn, 0, kmcohang_tt, 0, false);

                addRow(lx.LoaiXeID, lx.TenLoaiXe, "KM không hàng", kmkd_tn - kmcohang_tn, 0, kmkd_tt - kmcohang_tt, 0, false);

                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Khai thác", func(tableCurrent, lx.LoaiXeID.ToString(), "Khai thác"), tongCuocNay, func(tablePrevious, lx.LoaiXeID.ToString(), "Khai thác"), tongCuocTruoc, true);
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Thuê bao", func(tableCurrent, lx.LoaiXeID.ToString(), "Thuê bao"), tongCuocNay, func(tablePrevious, lx.LoaiXeID.ToString(), "Thuê bao"), tongCuocTruoc, true);
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Mở cửa", func(tableCurrent, lx.LoaiXeID.ToString(), "Mở cửa"), tongCuocNay, func(tablePrevious, lx.LoaiXeID.ToString(), "Mở cửa"), tongCuocTruoc, true);
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Trượt", func(tableCurrent, lx.LoaiXeID.ToString(), "Trượt"), tongCuocNay, func(tablePrevious, lx.LoaiXeID.ToString(), "Trượt"), tongCuocTruoc, true);

                var soxekd_tn = func(tableCurrent, lx.LoaiXeID.ToString(), "Số xe đi KD");
                var soxekd_tt = func(tablePrevious, lx.LoaiXeID.ToString(), "Số xe đi KD");

                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Số xe đi KD", soxekd_tn, 0, soxekd_tt, 0, false);

                decimal kmxengay = 0;
                try
                {
                    kmxengay = (soxekd_tn == 0 ? 0 : (decimal)kmkd_tn / soxekd_tn) / ((decimal)(to.Value - from.Value).TotalDays);
                }
                catch { }

                decimal kmxengay_tt = 0;
                try
                {
                    kmxengay_tt = ((decimal)kmkd_tt / soxekd_tt) / (decimal)(from.Value.AddSeconds(-1) - from.Value.AddMonths(-1)).TotalDays;
                }
                catch { }

                addRow(lx.LoaiXeID, lx.TenLoaiXe, "KM/Xe/ngày", kmxengay, 0, kmxengay_tt, 0, false);
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Cuốc/ngày", func(tableCurrent, lx.LoaiXeID.ToString(), "Cuốc/ngày"), 0, func(tablePrevious, lx.LoaiXeID.ToString(), "Cuốc/ngày"), 0, false);
                addRow(lx.LoaiXeID, lx.TenLoaiXe, "Cuốc/ngày/xe", func(tableCurrent, lx.LoaiXeID.ToString(), "Cuốc/ngày/xe"), 0, func(tablePrevious, lx.LoaiXeID.ToString(), "Cuốc/ngày/xe"), 0, false);
            });
            #region Tổng hợp

            if (loaixe == "")
            {
                var tongCuocNay = func(tableCurrent, string.Empty, "Tổng cuốc");
                var tongCuocTruoc = func(tablePrevious, string.Empty, "Tổng cuốc");
                addRow(-1, "Tất cả các xe", "Tổng cuốc", tongCuocNay, 0, tongCuocTruoc, 0, false);

                var kmkd_tn1 = func(tableCurrent, string.Empty, "Tổng KMKD");
                var kmkd_tt1 = func(tablePrevious, string.Empty, "Tổng KMKD");
                addRow(-1, "Tất cả các xe", "Tổng KMKD", kmkd_tn1, 0, kmkd_tt1, 0, false);

                var kmcohang_tn1 = func(tableCurrent, string.Empty, "KM có hàng");
                var kmcohang_tt1 = func(tablePrevious, string.Empty, "KM có hàng");
                addRow(-1, "Tất cả các xe", "KM có hàng", kmcohang_tn1, 0, kmcohang_tt1, 0, false);

                addRow(-1, "Tất cả các xe", "KM không hàng", kmkd_tn1 - kmcohang_tn1, 0, kmkd_tt1 - kmcohang_tt1, 0, false);

                addRow(-1, "Tất cả các xe", "Khai thác", func(tableCurrent, string.Empty, "Khai thác"), tongCuocNay, func(tablePrevious, string.Empty, "Khai thác"), tongCuocTruoc, true);
                addRow(-1, "Tất cả các xe", "Thuê bao", func(tableCurrent, string.Empty, "Thuê bao"), tongCuocNay, func(tablePrevious, string.Empty, "Thuê bao"), tongCuocTruoc, true);
                addRow(-1, "Tất cả các xe", "Mở cửa", func(tableCurrent, string.Empty, "Mở cửa"), tongCuocNay, func(tablePrevious, string.Empty, "Mở cửa"), tongCuocTruoc, true);
                addRow(-1, "Tất cả các xe", "Trượt", func(tableCurrent, string.Empty, "Trượt"), tongCuocNay, func(tablePrevious, string.Empty, "Trượt"), tongCuocTruoc, true);

                var soxekd_tn1 = func(tableCurrent, string.Empty, "Số xe đi KD");
                var soxekd_tt1 = func(tablePrevious, string.Empty, "Số xe đi KD");

                addRow(-1, "Tất cả các xe", "Số xe đi KD", soxekd_tn1, 0, soxekd_tt1, 0, false);

                decimal kmxengay1 = 0;
                try
                {
                    kmxengay1 = (soxekd_tn1 == 0 ? 0 : (decimal)kmkd_tn1 / soxekd_tn1) / ((decimal)(to.Value - from.Value).TotalDays);
                }
                catch { }

                decimal kmxengay_tt1 = 0;
                try
                {
                    kmxengay_tt1 = ((decimal)kmkd_tt1 / soxekd_tt1) / (decimal)(from.Value.AddSeconds(-1) - from.Value.AddMonths(-1)).TotalDays;
                }
                catch { }

                addRow(-1, "Tất cả các xe", "KM/Xe/ngày", kmxengay1, 0, kmxengay_tt1, 0, false);
                addRow(-1, "Tất cả các xe", "Cuốc/ngày", func(tableCurrent, string.Empty, "Cuốc/ngày"), 0, func(tablePrevious, string.Empty, "Cuốc/ngày"), 0, false);
                addRow(-1, "Tất cả các xe", "Cuốc/ngày/xe", func(tableCurrent, string.Empty, "Cuốc/ngày/xe"), 0,
                    func(tablePrevious, string.Empty, "Cuốc/ngày/xe"), 0, false);
            }
          
            #endregion

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                var content = row["NoiDung"].ToString();
                if (content == "Khai thác" || content == "Thuê bao" || content == "Mở cửa" || content == "Trượt")
                {
                    if (row["Value"].Equals(DBNull.Value)) row["Value"] = 0;
                    if (row["Value_t"].Equals(DBNull.Value)) row["Value_t"] = 0;
                    if (row["Value_s"].Equals(DBNull.Value)) row["Value_s"] = 0;
                    if (row["Value_tl"].Equals(DBNull.Value)) row["Value_tl"] = 0;
                    if (row["Value_t_tl"].Equals(DBNull.Value)) row["Value_t_tl"] = 0;
                }
            }

            return table;
        }

        public DataTable BaoCaoTongKetLoaiXeTheoThang(DateTime? from, DateTime? to, string loaixe)
        {
            return ExeStore("EnVang_Report_BaoCaoTongKetLoaiXeTheoThang", from, to, loaixe);
        }
        
        /// <summary>
        /// Lấy cả thông tin những cuốc không cập nhật thông tin trong bảng Truck (chưa điều)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="loaixe"></param>
        /// <returns></returns>
        public DataTable BaoCaoTongKetLoaiXeTheoThang_V2(DateTime? from, DateTime? to, string loaixe)
        {
            return ExeStore("EnVang_Report_BaoCaoTongKetLoaiXeTheoThang_V2", from, to, loaixe);
        }

        private DataTable GetDataInRangeDate(DateTime? from, DateTime? to, string loaixe)
        {
            var data = new DataTable();
            data.Columns.Add("LoaiXe");
            data.Columns.Add("NoiDung");
            data.Columns.Add("Value", typeof(decimal));

            var table = BaoCaoTongKetLoaiXeTheoThang(from, to, loaixe);
            var table2 = ExeStore("EnVang_Report_BanCo_GiamSatXe_BaoCaoKetQuaHoatDongCuaCacXeTheoThang", from, to, loaixe);
            var table3 = GiamSatXe_HoatDong.Inst.GetSoNgayKD_LoaiXe(from, to);

            Action<string, string, object> addRow = (key, nd, value) =>
            {
                var dr = data.NewRow();
                dr["LoaiXe"] = key;
                dr["NoiDung"] = nd;
                dr["Value"] = value;
                data.Rows.Add(dr);
            };

            table.AsEnumerable().GroupBy(dr => dr["LoaiXe"].ToString()).Select(gr =>
            {
                int thuebao = 0, khaithac = 0, mocua = 0, truot = 0;
                decimal kmThucDi = 0;
                int soXeDiKinhDoanh = 0;
                //var xeList= new List<string>();

                foreach (var dri in gr)
                {
                    var kieucuochang = dri["KieuCuocHang"].To<int>();
                    var kieucuocgoi = dri["KieuCuocGoi"].To<int>();
                    var ketqua = dri["KetQua"].To<int>();
                    var giathubao = dri["GiaThueBao"].ToString();
                    var sodt = dri["SoDT"].ToString();
                    var loaicuochang = dri["LoaiCuocHang"].To<int>();

                    // if (!string.IsNullOrEmpty(gtb)) thuebao++;
                    if (kieucuocgoi == (int)Enum_CallType.GoiXe
                    && loaicuochang != (int)LoaiCuocHangThucHien.CuocBinhThuong
                    && loaicuochang != (int)LoaiCuocHangThucHien.MoCua
                    && loaicuochang != (int)LoaiCuocHangThucHien.ThueBaoMeter) thuebao++;

                    if (sodt.Equals(CommonData.SDTLXKT)) khaithac++;
                    if (kieucuocgoi == (int)Enum_CallType.GoiXe && ketqua == (int)TrangThaiCuocGoiTaxi.CuocGoiTruot) truot++;
                    if (loaicuochang == (int)LoaiCuocHangThucHien.MoCua) mocua++;

                    kmThucDi += dri["KmThucDi"].To<decimal>();
                    //if (!dri["SoXe"].Equals(DBNull.Value) && 
                    //    !xeList.Any(p => p.Equals(dri["SoXe"]))
                    //    ) 
                    //    xeList.Add(dri["SoXe"].ToString());
                }

             //   addRow(gr.Key, "Tổng cuốc", thuebao + khaithac + mocua + truot);
                DataRow[] item = table3.Select("LoaiXe = " + gr.Key);
                if (item != null && item.Count() > 0)
                {
                    soXeDiKinhDoanh = item[0]["SoHieuXe"].To<int>();
                }
                var tongcuoc = gr.Count();
                //soXeDiKinhDoanh = xeList.Count;
                addRow(gr.Key, "Tổng cuốc", tongcuoc);// thực hiện đếm số cuốc theo loại xe
                addRow(gr.Key, "KM có hàng", kmThucDi);
                addRow(gr.Key, "Khai thác", khaithac);
                addRow(gr.Key, "Thuê bao", thuebao);
                addRow(gr.Key, "Mở cửa", mocua);
                addRow(gr.Key, "Trượt", truot);
                addRow(gr.Key, "Số xe đi KD", soXeDiKinhDoanh);

                decimal cn = 0;
                try
                {
                    cn = ((decimal)(tongcuoc)) / (decimal)(to.Value - from.Value).TotalDays;
                }
                catch { }

                decimal cnx = 0;
                try
                {
                    cnx = ((tongcuoc) / (decimal)(to.Value - from.Value).TotalDays) / soXeDiKinhDoanh;
                }
                catch { }

                addRow(gr.Key, "Cuốc/ngày", cn);
                addRow(gr.Key, "Cuốc/ngày/xe", cnx);

                return false;
            }).Count();

            table2.AsEnumerable().GroupBy(dr => dr["FK_LoaiXeID"].ToString()).Select(gr => 
            {
                var tong = gr.Where(dri => dri["TrangThaiLaiXeBao"].ToString() == "0" && !dri["CoVe"].Equals(DBNull.Value)).Aggregate<DataRow, decimal>(0, (current, dri) => current + (dri["CoVe"].To<decimal>() - dri["CoDi"].To<decimal>()));

                addRow(gr.Key, "Tổng KMKD", tong);

                return false;
            }).Count();

            return data;
        }
    }
}
