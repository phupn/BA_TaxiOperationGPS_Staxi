#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.Common.Extender;
using System.Collections.Generic;
using System.Linq;
using Taxi.MessageBox;
using Taxi.Business;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using Taxi.Services.BAGIS;
using Femiani.Forms.UI.Input;
using System.Data;
using Taxi.Data.G5.DanhMuc;
using Taxi.Services;
using System.Globalization;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{

     [ReportInfo(Title = "1.12.1 BC cuốc không điều app TH theo NV")]
    public partial class frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien : FrmReportBase
    {
        public frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien()
        {
            InitializeComponent();
        }
        public frmBC_1_11_1_BaoCaoCuocKhongDieuAppTongHopTheoNhanVien(object dataSource)
        {
            InitializeComponent();
            shGridControl2.DataSource = dataSource;
            SetEnableButtonFind(true);
        }

        protected override void SetEnableButtonFind(bool enable)
        {
            if (gridView2.RowCount > 0)
            {
                btnExportExcel.Enabled = true;
            }
            else
                btnExportExcel.Enabled = false;
        }
    }
}
