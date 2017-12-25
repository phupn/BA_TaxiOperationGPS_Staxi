using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.BaoCao;
using Taxi.Controls.BaoCao.ExcelBinders;
using Taxi.Data.FastTaxi;
using Taxi.Common.Extender;
using Taxi.Utils;
namespace Taxi.Controls.FastTaxis.BaoCao
{    /// <summary>
    /// Báo cáo tổng hợp chiều về
    /// </summary>
    [ReportInfo(Title = "Báo cáo tổng hợp chiều về", BinderType = ExcelBinderType.Grid)]
    public partial class frmBaoCao_1_3_TongHopChieuVe : FrmReportBase
    {
        public frmBaoCao_1_3_TongHopChieuVe()
        {
            InitializeComponent();
        }
        protected override void AfterLoad()
        {
            
        }
        protected override object GetData()
        {
            var data = Booking.Inst.GetBaoCaoTongHop(ipFromDate.DateTime, ipToDate.DateTime, txtTenLaiXe.Text, txtSoXe.Text);
            return data.GroupBy(p => new { p.SoHieuXe, p.LoaiXeID }).Select(p => new Booking()
            {
                SoHieuXe = p.Key.SoHieuXe,
                LoaiXeID = p.Key.LoaiXeID,
                SoDienThoai = p.First().SoDienThoai,
                TenLaiXe = p.First().TenLaiXe,
                TongCuocKhongThanhCong = p.Sum(pi => pi.TongCuocKhongThanhCong),
                TongCuocDuongDai = p.Sum(pi => pi.TongCuocDuongDai),
                TongCuocThanhCong = p.Sum(pi => pi.TongCuocThanhCong),
                KmCoKhach = p.Sum(pi => pi.KmCoKhach),
                KmRong = p.Sum(pi => { if (pi.KmRong < 0) return 0 - pi.KmRong; else return pi.KmRong; }),
                TongTien = p.Sum(pi =>
                {
                    if (pi.KmCoKhach <= 0)
                        return 0;
                    TinhTienTheoKm item = new TinhTienTheoKm(pi.LoaiXeID, pi.KmCoKhach);
                    if (item != null)
                    {
                        return (decimal)item.TongTien1Chieu;
                    }
                    else return (decimal)0;
                })
            }).OrderBy(p => p.SoHieuXe.To<int>()).ToList();
           // Booking.Inst.Get
            //return base.GetData();
        }
    }
}
