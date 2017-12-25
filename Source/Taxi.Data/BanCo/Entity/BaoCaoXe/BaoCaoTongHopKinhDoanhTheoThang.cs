using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
using System.Linq;
using Taxi.Common.Extender;
using System.Collections.Generic;
using Taxi.Common.DbBase;
using Taxi.Utils;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop;
using Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop.TinhHinhPhuongTien;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoTongHopKinhDoanhTheoThang : TaxiOperationDbEntityBase<BaoCaoTongHopKinhDoanhTheoThang>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetDataReport(DateTime? from, DateTime? to)
        {
            // Tạo table theo khung báo cáo
            var table = new DataTable();
            table.Columns.Add("KhoanMuc");
            table.Columns.Add("NoiDung");

            var dic = new Dictionary<DateTime, int>();

            // Tạo cột cho báo cáo theo từng ngày
            for (var d = from.Value; d <= to.Value; d = d.AddDays(1))
            {
                table.Columns.Add("Day_" + d.Day, typeof(int));
                if (d.DayOfWeek == DayOfWeek.Sunday)
                    table.Columns.Add("W_" + d.GetWeekNumberOfYear(), typeof(int));

                dic[d] = d.GetWeekNumberOfYear();
            }

            table.Columns.Add("Total", typeof(int));

            var binders = new List<BaoCaoTongHopBase>();
            binders.Add(new TongHopXe());
            binders.Add(new XeDiKinhDoanh());
            binders.Add(new XeKhongDiKinhDoanh());
            binders.Add(new XeHongBanVat());
            binders.Add(new CuocHang());
            binders.AddRange(BaoCaoLoi.CreateBinders());

            var dicRow = new Dictionary<string, DataRow>();
            var context = new Dictionary<string, object>();

            binders.ForEach(binder =>
            {
                binder.DayWithWeek = dic;
                binder.Table = table;
                binder.From = from;
                binder.To = to;
                binder.DicRow = dicRow;
                binder.Context = context;
                binder.Bind();
            });

            // 
            return table;
        }
    }
}
