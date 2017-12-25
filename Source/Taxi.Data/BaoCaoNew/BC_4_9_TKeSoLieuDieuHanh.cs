using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop;
using Taxi.Utils;

namespace Taxi.Data.BaoCaoNew
{
    public class BC_4_9_TKeSoLieuDieuHanh : DbEntityBase<BC_4_9_TKeSoLieuDieuHanh>
    {
        private string sp = "sp_BC_4_9_TKeSoLieuDieuHanh";
        public DataTable GetDataReport(DateTime? from, DateTime? to)
        {
            //1. Tạo table theo khung báo cáo
            var table = new DataTable();
            table.Columns.Add("KhoanMuc");
            table.Columns.Add("NoiDung");
            var dic = new Dictionary<DateTime, int>();
            // Tạo cột cho báo cáo theo từng ngày
            for (var d = from.Value; d <= to.Value; d = d.AddDays(1))
            {
                table.Columns.Add("Day_" + d.Day, typeof(int));//Tạo header cho datatable!                
                if (d.DayOfWeek == DayOfWeek.Sunday)
                    table.Columns.Add("W_" + d.GetWeekNumberOfYear(), typeof(int));
                dic[d] = d.GetWeekNumberOfYear();
            }
            table.Columns.Add("Total", typeof(int));
            table.Columns.Add("ChiTieu", typeof (int));
            table.Columns.Add("ChiPhiHH", typeof (double));
            table.Columns.Add("%",typeof(double));
            table.Columns.Add("GhiChu", typeof (string));


            //2. Tạo các binders để tổ chức dữ liệu từ trong DB!
            var baseBinders = new List<BaoCaoTongHopBase>();
            baseBinders.Add(new BaoCaoThongKeDieuHanh());

            var dicRow = new Dictionary<string, DataRow>();
            var context = new Dictionary<string, object>(); 
            baseBinders.ForEach(baseBinder =>
            {
                baseBinder.DayWithWeek = dic;
                baseBinder.Table = table;//Gán liên kết bảng ở đây!
                baseBinder.From = from;
                baseBinder.To = to;
                baseBinder.DicRow = dicRow;
                baseBinder.Context = context;
                baseBinder.Bind();//Thực hiện liên kết dữ liệu
            });
            table =FillZeroToDataTable(table);
            return table;
        }

       
        private DataTable FillZeroToDataTable(DataTable table)
        {
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        if (row[col.ColumnName].ToString().Length == 0 &&col.ColumnName!="GhiChu")
                            row[col.ColumnName] = 0;
                    }
                }
                return table;
            }
            catch 
            {
                return new DataTable();
            }
        }

        public DataTable LayDuLieuCuocGPS(DateTime? pFrom, DateTime? pTo)
        {            
            DateTime from = (DateTime)pFrom;
            DateTime to = (DateTime)pTo;
            DataTable dtAll = new DataTable();
            int count = to.Day - from.Day;
            for (int i = 1; i <= count + 1; i++)
            {
                dtAll.Merge(this.ExeStore("sp_BC_4_9_LayDuLieuCuocGPS", from, from.AddDays(1)));
                from = from.AddDays(1);
                Thread.Sleep(300);
            }
            return dtAll;
        }
        public DataTable LayDuLieuThongKeDieuHanh(DateTime? pFrom, DateTime? pTo)
        {
            DateTime from = (DateTime)pFrom;
            DateTime to = (DateTime)pTo;
            DataTable dtAll = new DataTable();
            int count = to.Day - from.Day;
            for (int i = 1; i <= count + 1; i++)
            {
                dtAll.Merge(this.ExeStore(sp, from, from.AddDays(1)));
                from = from.AddDays(1);
                Thread.Sleep(300);
            }
            return dtAll;
        }

        public DataTable LayDuLieuCacSanh()
        {
            return this.ExeStore("sp_BC_4_9_LayDuLieuSanh");
        }

        public DataTable BaoCaoKQDieuHanhTheoCa(params object[] pInput)
        {
            return this.ExeStore("SP_BAOCAO_KETQUA_DIEUHANH_THEOCA", pInput);
        }
        public DataTable BaoCaoKQDieuHanhTheoVung(params object[] pInput)
        {
            return this.ExeStore("SP_BAOCAO_KETQUA_DIEUHANH_THEOVUNG",pInput);
        }

        public DataTable BaoCaoKQDieuHanhTheoGio(params object[] pInput)
        {
            return this.ExeStore("SP_BAOCAO_KETQUA_DIEUHANH_THEOGIO", pInput);
        }

        public DataTable BaoCaoKQDieuHanhTheoNgay(params object[] pInput)
        {
            return this.ExeStore("SP_BAOCAO_KETQUA_DIEUHANH_THEONGAY", pInput);
        }        
    }
}
