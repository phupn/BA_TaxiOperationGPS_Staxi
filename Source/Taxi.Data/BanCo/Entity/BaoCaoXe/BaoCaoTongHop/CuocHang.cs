using Taxi.Common.Extender;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Data;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop
{
    public class CuocHang : BaoCaoTongHopBase
    {
        protected override void DoBind()
        {
            var data = BaoCaoKetQuaHoatDongCuaCacXeTheoThang.Inst.BaoCaoTongKetLoaiXeTheoThang_V2(From, To, string.Empty).ToList<TruckInfo>();

            #region delegate tạo cột và fill dữ liệu
            Action<string, List<string>> createColumn = (km, lst) =>
            {
                foreach (var di in lst)
                {
                    var dr = Table.NewRow();
                    dr["KhoanMuc"] = km;
                    dr["NoiDung"] = di;
                    Table.Rows.Add(dr);
                    DicRow[di] = dr;
                }
            };

            createColumn("Kết quả Kinh Doanh", 
                new List<string> 
                { "Cuốc ca 1"
                    , "Cuốc ca 2"
                    , "Cuốc ca 3"
                    , "Tổng cuốc"
                    , "Tổng thuê bao"
                    , "Khai thác"
                    , "TB đường dài"
                    , "Trượt" 
                });
            createColumn("Thông tin tiếp nhận điện thoại", 
                new List<string> 
                {   "Tổng cuộc đến"
                    , "ĐT có khách"
                    , "Gọi lại"   // 3
                    , "Hết xe"    // 13
                    , "Giục xe"   // 14
                    , "Hoãn xe"   // 12
                    , "Phản ánh"  // 6
                    , "Xin lỗi"   // 7
                    , "Bốc xếp"   // 5
                    , "Khách hẹn" // 11
                    , "Hỏi giá"   // 4
                    , "Nháy máy"  // 9
                    , "Nội bộ"    // 8
                    , "Gọi khác"  // 10
                    , "Không cập nhật"
                });

            Action<string, TruckSummary> fillCell = (cell, ts) =>
            {
                if (!Table.Columns.Contains(cell)) return;

                DicRow["Tổng cuốc"][cell] = ts.TongCuocHang;// ts.GetAllCuocGoi();
                DicRow["Tổng thuê bao"][cell] = ts.ThueBao;
                DicRow["Khai thác"][cell] = ts.KhaiThac;
                //DicRow["Mở cửa"][cell] = ts.MoCua;
                DicRow["TB đường dài"][cell] = ts.TBDuongDai;
                DicRow["Trượt"][cell] = ts.Truot;

                DicRow["Tổng cuộc đến"][cell] = ts.TongCuocDen;
                DicRow["ĐT có khách"][cell] = ts.DienThoaiCoKhach;
                DicRow["Gọi lại"][cell] = ts.GoiLai;
                DicRow["Hết xe"][cell] = ts.HetXe;
                DicRow["Giục xe"][cell] = ts.GiucXe;
                DicRow["Hoãn xe"][cell] = ts.HoanXe;
                DicRow["Phản ánh"][cell] = ts.KhieuNai;
                DicRow["Xin lỗi"][cell] = ts.XinLoi;
                DicRow["Bốc xếp"][cell] = ts.BocXep;
                DicRow["Khách hẹn"][cell] = ts.KhachHen;
                DicRow["Hỏi giá"][cell] = ts.HoiGia;
                DicRow["Nháy máy"][cell] = ts.NhayMay;
                DicRow["Nội bộ"][cell] = ts.NoiBo;
                DicRow["Gọi khác"][cell] = ts.GoiKhac;
                DicRow["Không cập nhật"][cell] = ts.KhongCapNhat;

            };

            #endregion
            
            // Nhóm dữ liệu theo ngày và phân theo từng ca làm việc
            var dataByDayInCa = data.GroupBy(d => d.TGTiepNhan.Day).SelectMany(g =>
            {
                return g.Select(gi => gi.ToTruckSummary()).GroupBy(gc => gc.Ca).Select(gci =>
                {
                    var ts = gci.DoSum();
                    DicRow[gci.Key]["Day_" + g.Key] = ts.TongCuocHang;                    
                    return new DataByCa { Day = g.Key, TruckSummary = ts, Ca = gci.Key };
                });
            })

            // Tính cột tổng cho các ca làm việc
            .GroupBy(di => di.Ca).SelectMany(g =>
            {
                DicRow[g.Key]["Total"] = g.Select(gdiii => gdiii.TruckSummary).DoSum().TongCuocHang;
                return g;
            });

            // Tính toán tổng theo từng tuần của từng ca
            var tsAll = DayWithWeek.Join(dataByDayInCa, dwi => dwi.Key.Day, d => d.Day, (dwi, d) => new { w = dwi.Value, d }).GroupBy(wd => wd.w).SelectMany(gwd =>
            {
                return gwd.GroupBy(gwdi => gwdi.d.Ca).SelectMany(gwdi =>
                {
                    if (Table.Columns.Contains("W_" + gwd.Key)) DicRow[gwdi.Key]["W_" + gwd.Key] = gwdi.Select(d => d.d.TruckSummary).DoSum().TongCuocHang;
                    return gwdi.Select(d => d.d);
                });
            })

            // Tính toán dữ liệu của một ngày
            .GroupBy(b => b.Day).Select(g =>
            {
                var ts = g.Select(t => t.TruckSummary).DoSum();
                fillCell("Day_" + g.Key, ts);
                return new DataByCa { Day = g.Key, TruckSummary = ts };
            })

            // Tính toán dữ liệu cho cả tuần
            .Join(DayWithWeek, d => d.Day, dwi => dwi.Key.Day, (d, dwi) => new { TruckSummary = d.TruckSummary, Week = dwi.Value }).GroupBy(w => w.Week).Select(g =>
            {
                var ts = g.Select(gi => gi.TruckSummary).DoSum();
                fillCell("W_" + g.Key, ts);
                return ts;
            }).DoSum();

            // Tính toán cho cột tổng
            fillCell("Total", tsAll);
        }

        public class DataByCa
        {
            public int Day { set; get; }
            public TruckSummary TruckSummary { set; get; }
            public string Ca { set; get; }
        }
    }
}
