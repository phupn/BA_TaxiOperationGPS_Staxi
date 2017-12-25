using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop.TinhHinhPhuongTien
{
    /// <summary>
    /// Tình hình phương tiện
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaoCaoTinhHinhPhuongTien<T> : BaoCaoTongHopBase<T> where T : IDayReport
    {
        sealed protected override string KhoanMuc
        {
            get { return "Tình hình phương tiện"; }
        }

        /// <summary>
        /// Khi bind dữ liệu vào cột ngày
        /// </summary>
        /// <param name="column"></param>
        /// <param name="data"></param>
        protected override void OnBindDay(string column, object data)
        {
            if (this.NoiDung != "Xe hỏng ban vặt")            
                DicRow[TongHopXe.TongXe][column] = DicRow[TongHopXe.TongXe][column].To<int>() + data.To<int>();
        }

        /// <summary>
        /// Khi bind dữ liệu cho cột tuần
        /// </summary>
        /// <param name="column"></param>
        /// <param name="data"></param>
        protected override void OnBindWeek(string column, object data)
        {
            if (this.NoiDung != "Xe hỏng ban vặt")
                DicRow[TongHopXe.TongXe][column] = DicRow[TongHopXe.TongXe][column].To<int>() + data.To<int>();
        }

        /// <summary>
        /// Khi bind dữ liệu cho cột tổng
        /// </summary>
        /// <param name="column"></param>
        /// <param name="data"></param>
        protected override void OnBindSumary(string column, object data)
        {
            if (this.NoiDung != "Xe hỏng ban vặt")
                DicRow[TongHopXe.TongXe][column] = DicRow[TongHopXe.TongXe][column].To<int>() + data.To<int>();
        }
    }
}
