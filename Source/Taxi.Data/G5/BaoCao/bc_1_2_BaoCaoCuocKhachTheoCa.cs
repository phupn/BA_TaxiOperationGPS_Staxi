using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Taxi.Utils;

namespace Taxi.Data.G5.BaoCao
{
    public class bc_1_2_BaoCaoCuocKhachTheoCa : DbEntityBase<bc_1_2_BaoCaoCuocKhachTheoCa>
    {
        private const string spReport = "sp_bc_1_2_BaoCaoCuocKhachTheoCa";
        private const string spReportSum = "sp_BC_1_2_BaoCaoCuocKhachTheoCaTong";
        private const string spReportTime = "sp_BC_1_2_BaoCaoCuocKhachTheoGio";
        /// <summary>
        /// Báo cáo Tổng hợp cuốc khách điều hành
        /// </summary>
        public static object GetReport(DateTime start, DateTime end, int IsCa)
        {
            DataTable result= new DataTable();
            if (IsCa != 2)
            {
                result = Inst.ExeStore(spReport, start, end, IsCa);
                DataTable dtSum = Inst.ExeStore(spReportSum, start, end, IsCa);
                result.Merge(dtSum);
            }
            else
            {
                result = Inst.ExeStore(spReportTime, start, end);
                DataTable dtSum = Inst.ExeStore(spReportSum, start, end, IsCa);
                result .Merge(dtSum);
            }
            return result;
        }
        public DateTime Ngay { get; set; }
        public string Ca { get; set; }
        public int GoiTaxi { get; set; }
        public int GoiVL { get; set; }
        public int GoiMG { get; set; }
        public int GoiLai { get; set; }
        public float PhanTramGoiLai { get; set; }
        public int ChuyenKH { get; set; }
        public int DichVu { get; set; }
        public int HoiDam { get; set; }
        public int GoiKhac { get; set; }
        public int Tong { get; set; }
        public int CuocGoiNho { get; set; }
        public int DonDuoc { get; set; }
        public int KhongDonDuoc { get; set; }
        public int Truot { get; set; }
        public int Hoan { get; set; }
        public int KhongXe { get; set; }
        public int Khac { get; set; }
        public float PhanTramDonDuoc { get; set; }
        public int XeKhongXacDinh { get; set; }
        public int CuocG5 { get; set; }
        public int DonDuocG5 { get; set; }
        public float PhanTramG5 { get; set; }
        public float TiTrongVung { get; set; }
    }
}
