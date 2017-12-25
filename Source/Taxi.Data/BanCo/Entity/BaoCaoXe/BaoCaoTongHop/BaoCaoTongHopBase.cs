using System.Collections.Generic;
using System;
using System.Linq;
using System.Data;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop
{
    public abstract class BaoCaoTongHopBase
    {
        public Dictionary<DateTime, int> DayWithWeek { set; get; }
        public DataTable Table { set; get; }
        public DateTime? From { set; get; }
        public DateTime? To { set; get; }

        /// <summary>
        /// Lưu trữ để map giữa nội dung => row
        /// </summary>
        public Dictionary<string, DataRow> DicRow { set; get; }

        public void Bind()
        {
            DoBind();
        }

        protected abstract void DoBind();

        /// <summary>
        /// Context
        /// </summary>
        public Dictionary<string, object> Context { set; get; }

        /// <summary>
        /// Lấy dữ liệu từ context
        /// </summary>
        protected T GetFromContext<T>(string key, Func<T> func)
        {
            T t;

            if (Context.ContainsKey(key))
            {
                var value = Context[key];
                if (value == null) Context[key] = t = func();
                else t = value.As<T>();
            }
            else Context[key] = t = func();

            return t;
        }
    }

    public class DataInWeek<T>
    {
        public int Week { set; get; }
        public T Data { set; get; }
    }

    public abstract class BaoCaoTongHopRowEmptyBase : BaoCaoTongHopBase
    {
        protected abstract string KhoanMuc { get; }
        protected abstract string NoiDung { get; }

        /// <summary>
        /// Tạo dòng rỗng
        /// </summary>
        sealed protected override void DoBind()
        {
            var dr = Table.NewRow();
            dr["KhoanMuc"] = KhoanMuc;
            dr["NoiDung"] = NoiDung;
            Table.Rows.Add(dr);
            DicRow[NoiDung] = dr;
            OnNewRow(dr);
        }

        protected virtual void OnNewRow(DataRow dr) { }
    }

    public abstract class BaoCaoTongHopBase<T> : BaoCaoTongHopRowEmptyBase where T : IDayReport
    {
        protected override void OnNewRow(DataRow dr)
        {
            var data = GetData();

            // Group theo tuần để tính toán
            var dataSum = DayWithWeek.Join(data, diw => diw.Key.Day, d => d.Date.Day, (diw, d) => new DataInWeek<T> { Data = d, Week = diw.Value }).GroupBy(wd => wd.Week).SelectMany(gwd =>
            {
                var stringKey = "W_" + gwd.Key;
                if (Table.Columns.Contains(stringKey)) OnBindWeek(stringKey, dr[stringKey] = CalByWeek(gwd.Select(gwdi => gwdi.Data)));
                return gwd.Select(gwdi => gwdi.Data);
            })

            // Group theo ngày để tính toán
            .GroupBy(d => d.Date.Day).SelectMany(dg =>
            {
                var stringKey = "Day_" + dg.Key;
                OnBindDay(stringKey, dr[stringKey] = CalByDay(dg));
                return dg.Select(dgi => dgi);
            });

            // Tổng toàn bộ dữ liệu
            OnBindSumary("Total", dr["Total"] = CalSumary(dataSum));
        }

        /// <summary>
        /// Sự kiện bind dữ liệu vào cột tuần
        /// </summary>
        /// <param name="column"></param>
        /// <param name="data"></param>
        protected virtual void OnBindWeek(string column, object data) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataInWeek"></param>
        /// <returns></returns>
        protected virtual object CalByWeek(IEnumerable<T> dataInWeek)
        {
            return dataInWeek.Count();
        }

        /// <summary>
        /// Sự kiện khi bind dữ liệu vào cột ngày
        /// </summary>
        /// <param name="column"></param>
        /// <param name="data"></param>
        protected virtual void OnBindDay(string column, object data) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataInDay"></param>
        /// <returns></returns>
        protected virtual object CalByDay(IEnumerable<T> dataInDay)
        {
            return dataInDay.Count();
        }

        /// <summary>
        /// Sự kiện bind dữ liệu vào cột tổng
        /// </summary>
        /// <param name="column"></param>
        /// <param name="data"></param>
        protected virtual void OnBindSumary(string column, object data) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAll"></param>
        /// <returns></returns>
        protected virtual object CalSumary(IEnumerable<T> dataAll)
        {
            return dataAll.Count();
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        protected abstract List<T> GetData();
    }

    public interface IDayReport
    {
        DateTime Date { get; }
    }
}