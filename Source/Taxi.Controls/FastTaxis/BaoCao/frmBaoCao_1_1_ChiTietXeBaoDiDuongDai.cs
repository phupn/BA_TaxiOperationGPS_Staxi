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
using Taxi.Data.FastTaxi.BaoCao;
using Taxi.Controls.Base.Extender;
using Taxi.Data.FastTaxi;
using Taxi.Utils;
namespace Taxi.Controls.FastTaxis.BaoCao
{
    /// <summary>
    /// Báo cáo chi tiết xe báo đi đường dài
    /// </summary>
    [ReportInfo(Title = "Báo cáo chi tiết xe báo đi đường dài", BinderType = ExcelBinderType.Grid, TypeReportData = typeof(XeDiDuongDai))]
    public partial class frmBaoCao_1_1_ChiTietXeBaoDiDuongDai : FrmReportBase
    {
        public frmBaoCao_1_1_ChiTietXeBaoDiDuongDai()
        {
            InitializeComponent();
        }
        protected override void AfterLoad()
        {
            //gridView1.Add<RepositoryItemEnum_TrangThaiDuyetXeBaoDiDuongDai>("TrangThaiDuyet");
            //gridView1.Add<RepositoryItemEnum_TrangThaiXeBaoDiDuongDai>("TrangThai");
        }

        private void pnInputs_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
