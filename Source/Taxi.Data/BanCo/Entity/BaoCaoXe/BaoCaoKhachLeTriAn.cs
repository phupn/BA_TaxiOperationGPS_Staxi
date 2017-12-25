using Taxi.Data.BanCo.DbConnections;
using System.Collections.Generic;
using System;
using System.Linq;
using Taxi.Common.Extender;
using System.Data;
using Taxi.Data.BanCo.Entity.GiamSatXe;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoKhachLeTriAn : TaxiOperationDbEntityBase<BaoCaoKhachLeTriAn>
    {
        /// <summary>
        /// Số điện thoại của khách hàng
        /// </summary>
        public string SoDT { set; get; }

        /// <summary>
        /// Tiền đi
        /// </summary>
        public decimal ThanhTien { set; get; }

        /// <summary>
        /// Loại xe khách hàng đi
        /// </summary>
        public int LoaiXe { set; get; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Lấy dữ liệu cho báo cáo
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetDataReport(DateTime? from, DateTime? to, decimal tongTien = 0,long SoCuoc=0)
        {
            // Dữ liệu cần nhào lặn để ra báo cáo
            // Gồm tên khách hàng và loại xe khách hàng đi + số tiền của lần đi đó
            var table = this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoKhachLeTriAn", from, to);

            // Danh sách các loại xe mà cần tạo cột động
            var listLoaiXe = TuDien_LoaiXe.Inst.GetListAll();

            // Tạo cột các loại xe
            listLoaiXe.ForEach(lx => table.Columns.Add("LoaiXe_" + lx.LoaiXeID));

            // Cột lưu tổng số cuốc
            table.Columns.Add("TongCuoc");
            table.Columns.Add("GhiChu");

            // Return dữ liệu cần hiển thị báo cáo
            // Tên khách hàng, điện thoại => chi tiết các số cuốc của các loại xe, tổng tiền
            var data = table.AsEnumerable().GroupBy(dr => dr["SoDT"].ToString()).Select(gr =>
            {
                var dr = gr.First();

                // Tính tổng tiền của tất cả các cuốc
                dr["ThanhTien"] = gr.Sum(gri => gri["ThanhTien"].To<decimal>());

                // Tính số cuốc của từng loại xe khách đi
                listLoaiXe.ForEach(lx => dr["LoaiXe_" + lx.LoaiXeID] = gr.Count(gri => gri["LoaiXe"].ToString() == lx.LoaiXeID.ToString()));

                // Tính tổng số cuốc
                dr["TongCuoc"] = gr.Count();

                return dr;
            }).Where(p => p["ThanhTien"].To<decimal>() >= tongTien && p["TongCuoc"].To<long>() >= SoCuoc).ToList();

            //danh sách 10 khách hàng có số cuộc gọi nhiều nhất và tổng tiền cao nhất

            //var number =10;
            //if (data.Count < 10) number = data.Count;
            var data10 = data.OrderByDescending(x => x["TongCuoc"].To<int>()).ThenByDescending(y => y["ThanhTien"].To<decimal>()).ToList();//.GetRange(0, number);

            return data10!=null&&data10.Count != 0 ? data10.CopyToDataTable() : null;
        }
    }
}
