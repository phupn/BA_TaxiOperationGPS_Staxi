#region ============= Copyright © 2016 BinhAnh =============
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.Common.Extender;
using System.Collections.Generic;
using System.Linq;
using GridView = Taxi.Controls.Base.Controls.Grids.GridView;

#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "6.6 Báo cáo tổng hợp cuốc môi giới theo xe")]
    public partial class frmBC_6_6_BaoCaoTongHopCuocMoiGioiTheoXe : FrmReportBase
    {
        public frmBC_6_6_BaoCaoTongHopCuocMoiGioiTheoXe()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            var data1 = bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe.GetReport(ipFromDate.DateTime, ipToDate.DateTime, txtMaDoiTac.Text.Trim(), txtSoXe.Text.Trim(), lupLoaiDoiTac.EditValue.To<int>(), lupCongTy.EditValue.To<int>());
            var data2 = GetDataSoXeSoCuoc(data1);
            return new DataReportCollection(data1, data2);
        }

        private List<SoXeSoCuoc> GetDataSoXeSoCuoc(List<bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe> data)
        {
            return data == null || data.Count == 0 ? new List<SoXeSoCuoc>() : data.GroupBy(x => x.SoXe)
                                                                              .Select(p => new SoXeSoCuoc() { SoXe = p.Key, SoCuocSanBay = p.Sum(e => e.CuocSanBay), SoCuocThuong = p.Sum(e => e.CuocThuong) }).ToList();
        }

        private class SoXeSoCuoc
        {
            public string SoXe { get; set; }
            public int HoaHong { get { return SoCuocThuong + SoCuocSanBay; } }
            public int SoCuocSanBay { get; set; }
            public int SoCuocThuong { get; set; }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int index = e.FocusedRowHandle;
                var soxe = ((List<SoXeSoCuoc>)shGridControl2.DataSource)[index].SoXe;
                if (soxe != null)
                {
                    var data = ((List<bc_6_6_BaoCaoTongHopCuocMoiGioiTheoXe>)shGridControl1.DataSource).OrderBy(a=>a.SoXe);
                    int i = 0;
                    foreach (var item in data)
                    {
                        if (item.SoXe == soxe)
                        {
                            gridView1.FocusedRowHandle = i;
                            break;
                        }
                        i++;
                    }
                }
            }
            catch
            {
                                
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null && e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(192, 255, 192);
                e.HighPriority = true;
            }
        }
    }
}
