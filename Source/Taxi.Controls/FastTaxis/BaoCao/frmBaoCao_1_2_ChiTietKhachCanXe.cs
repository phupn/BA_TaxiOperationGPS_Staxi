using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Controls.BaoCao;
using Taxi.Controls.BaoCao.ExcelBinders;
using Taxi.Controls.Base.Common;
using Taxi.Data.FastTaxi;
using Taxi.Controls.Base.Extender;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Utils;
namespace Taxi.Controls.FastTaxis.BaoCao
{
    /// <summary>
    /// Báo cáo chi tiết khách cần xe
    /// </summary>
    [ReportInfo(Title = "Báo cáo chi tiết khách cần xe", BinderType = ExcelBinderType.Grid, TypeReportData = typeof(Booking))]
    public partial class frmBaoCao_1_2_ChiTietKhachCanXe : FrmReportBase
    {
        public frmBaoCao_1_2_ChiTietKhachCanXe()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            var data= (base.GetData() as List<Booking>);
            if(data!=null){
               // data = data.OrderByDescending(pi => pi.FromTime).OrderBy(p=>p.SoHieuXe.To<int>()).ToList();
                 data.ForEach(pi =>
                    {
                        if (pi.KmCoKhach <= 0)
                            pi.TongTien= 0;
                        TinhTienTheoKm item = new TinhTienTheoKm(pi.LoaiXeID, pi.BC_Route_Distance);
                        if (item != null)
                        {
                             pi.TongTien=(decimal)item.TongTien1Chieu;
                        }
                        else  pi.TongTien= (decimal)0;
                    });
            }
            return data.ToList();
           
        }
        protected override void AfterFind()
        {
            shGridControl1.Refresh();
        }
        protected override void AfterLoad()
        {
            DataTable dataCmd = new DataTable();
            dataCmd.Columns.Add("Display");
            dataCmd.Columns.Add("Value");
            dataCmd.Rows.Add("Tất cả", "");
            dataCmd.Rows.Add("KH Hủy", "KH Hủy");
            dataCmd.Rows.Add("Đã gặp xe", "Đã gặp xe");

            lueLenh.Properties.DataSource = dataCmd;
            lueLenh.ItemIndex = 0;
             //gridView1.Add<RepositoryItemEnum_TrangThaiDieuXe>("OpStatus");
        }
    }
}
