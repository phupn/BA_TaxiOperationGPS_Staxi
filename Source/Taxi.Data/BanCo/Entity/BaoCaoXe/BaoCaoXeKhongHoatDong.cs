using Taxi.Data.BanCo.DbConnections;
using System;
using System.Linq;
using System.Collections.Generic;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop;
using System.Data;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoXeKhongHoatDong : TaxiOperationDbEntityBase<BaoCaoXeKhongHoatDong>, IDayReport
    {
        /// <summary>
        /// 
        /// </summary>
        public string SoHieuXe { set; get; }

        public int SoHieuXe_int
        {
            get
            {
                return SoHieuXe.To<Int32>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ReportedDate { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Reason { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string TenLoaiXe { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string GroupDate { set; get; }

        /// <summary>
        /// Tổng số ngày
        /// </summary>
        public int TotalDate { set; get; }

        /// <summary>
        /// Tóm tắt 
        /// </summary>
        public string SummaryText { set; get; }
       /// <summary>
       /// Để hiện thị thông tin trên form
       /// </summary>
        public string SummaryText2 { set; get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sohieuxe"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public List<BaoCaoXeKhongHoatDong> GetDataInRangeDate(DateTime? from, DateTime? to, string sohieuxe, string reason)
        {
            return this.ExeStore("EnVang_Report_BanCo_VehicleNotWorking_BaoCaoXeKhongHoatDong", from, to, sohieuxe, reason).ToList<BaoCaoXeKhongHoatDong>();
        }

        /// <summary>
        /// Lấy dữ liệu cho báo cáo
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sohieuxe"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public List<BaoCaoXeKhongHoatDong> GetDataReport(DateTime? from, DateTime? to, string sohieuxe, string reason)
        {
            // Lấy dữ liệu từ db
            var data = GetDataInRangeDate(from, to, sohieuxe, reason);
            if (data.Count == 0) return null;
            data = data.OrderBy(T => T.ReportedDate).ToList();
            int TongCaLuu = data.Count;
            // Tính tổng số xe
            var totalVehicles = 0;
            DataTable dt = GiamSatXe_HoatDong.Inst.GetSoNgayKD(from, to);
            if (dt != null && dt.Rows.Count > 0)
            {
                totalVehicles = dt.Rows[0]["TongSoXe"].To<int>();
            }

            // Tính toán thống kê cho từng nhóm nguyên nhân
            var dic = data.GroupBy(di => di.Reason).ToDictionary(gdi => gdi.Key, gdi =>
            {
                //var tongxe = gdi.Select(gdii => gdii.SoHieuXe).Distinct().Count();
                var tongcaluu_Nhom = gdi.Count();
                return string.Format("{2} - Tổng ca lưu {0} : - Chiếm {1:#,##0.##}%  -  Chiếm {4:#,##0.##}% Tổng xe kd trong tháng [Ca]__{3} ca",
                    TongCaLuu, 
                    (totalVehicles == 0 ? 0 : (decimal)tongcaluu_Nhom / totalVehicles) * 100, 
                    gdi.Key, 
                    tongcaluu_Nhom, 
                    TongCaLuu==0?0:((decimal)tongcaluu_Nhom / TongCaLuu) * 100);
            });

            // Group để ra số liệu của từng loại xe, lý do và số đàm
            var ls = data.GroupBy(di => di.Reason + "_" + di.TenLoaiXe + "_" + di.SoHieuXe).Select(g =>
            {
                var bc = g.First();
                string strGroupDate = "";
                // Group ngày
                bc.GroupDate = string.Join(",", g.GroupBy(gi => "/" + gi.ReportedDate.Month + "/" + gi.ReportedDate.Year + " " )//+ TwoDigitTime(gi.ReportedDate.Hour) + ":" + TwoDigitTime(gi.ReportedDate.Minute))
                    .Select(gi => DoGroupDate(gi.Select(gii => gii.ReportedDate).ToList()) + gi.Key)
                    .ToArray());

                // Tổng số ngày
                bc.TotalDate = g.Count();
                var sp = dic[bc.Reason].Split(new[] {"[Ca]"}, StringSplitOptions.None);
                // Báo cáo tóm tắt
                bc.SummaryText2 = dic[bc.Reason].Replace("[Ca]__"," Tổng số ca:");
                bc.SummaryText = bc.Reason + "--" + sp[0];
                bc.Reason = bc.Reason + sp[1];
                // Group ghi chú
                bc.Description = string.Join(",", g.Select(gi => gi.Description).Distinct().ToArray());

                return bc;
            }).ToList();
            return ls;
        }

        /// <summary>
        /// Thực hiện group date ra string
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        private string DoGroupDate(List<DateTime> dates)
        {
            var dt = dates[0].Date;
            string g = string.Empty, gtt = string.Empty, gtf = dt.Day.ToString();

            for (int i = 1; i < dates.Count; i++)
            {
                var dt2 = dates[i].Date;
                var delta = (dt2 - dt).TotalDays;

                if (delta == 1) gtt = dt2.Day.ToString();

                else if (delta > 0)
                {
                    if (!string.IsNullOrEmpty(gtt) && !gtf.Equals(gtt)) g += gtf + "->" + gtt + "+";
                    else g += gtf + "+";
                    gtf = dt2.Day.ToString();
                    gtt = string.Empty;
                }

                dt = dt2;
            }

            if (!string.IsNullOrEmpty(gtt) && !gtf.Equals(gtt)) g += gtf + "->" + gtt + ",";
            else g += gtf + ",";

            return g.TrimEnd(',');
        }

        public DateTime Date
        {
            get { return ReportedDate; }
        }

        private string TwoDigitTime(int time)
        {
            if (time < 10) return "0" + time;
            return time.ToString();
        }
    }
}
