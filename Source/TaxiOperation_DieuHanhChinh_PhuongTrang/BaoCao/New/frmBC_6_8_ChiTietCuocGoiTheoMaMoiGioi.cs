using System;
using Taxi.Controls.BaoCao;
using Taxi.Controls.Base.Common;
using Taxi.Data.FastTaxi.BaoCao;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Common.RepositoryItems;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    [ReportInfo(Title="Báo cáo chi tiết cuốc gọi theo mã môi giới",BinderType=ExcelBinderType.Grid)]
    public partial class frmBC_6_8_ChiTietCuocGoiTheoMaMoiGioi : FrmReportBase
    {
        public int CongTyId { get; set; }
        public string DoiTacId { get; set; }
        public bool IsShow { get; set; }
        private BaoCaoChiTietCuocGoiTheoMaMoiGioi entiy = new BaoCaoChiTietCuocGoiTheoMaMoiGioi();
        public frmBC_6_8_ChiTietCuocGoiTheoMaMoiGioi()
        {
            InitializeComponent();
        }
        public frmBC_6_8_ChiTietCuocGoiTheoMaMoiGioi(DateTime start,DateTime end,int congTyid,string doiTacId)
        {
            InitializeComponent();
            FromDate = start;
            ToDate = end; 
            CongTyId = congTyid;
            DoiTacId = doiTacId;
            IsShow = true;
        }
        protected override void AfterLoad()
        {
            inputLookUp_CongTy.Properties.DataSource = entiy.GetThongTinCongTy();
            inputLookUp_DoiTac.Properties.DataSource = entiy.GetThongTinDoiTac();
            gridView1.Add<RepostionryItemEnum_KieuCuocGoi>("KieuCuocGoi");
            gridView1.Add<RepostionryItemEnum_TrangThaiCuocGoi>("TrangThaiCuocGoi");
            
            if (IsShow)
            {
                ipFromDate.SetValue(FromDate);
                ipToDate.SetValue(ToDate);
                inputLookUp_CongTy.SetValue(CongTyId);
                inputLookUp_DoiTac.SetValue(DoiTacId);
                btnTim.PerformClick();
            }
            else
            {
                ipFromDate.SetValue(DateTime.Now.Date);
                ipToDate.SetValue(DateTime.Now);
                inputLookUp_CongTy.SetValue(0);
                inputLookUp_DoiTac.SetValue("0");
            }
        }
        protected override object GetData()
        {
            return entiy.GetData(FromDate.Value, ToDate.Value, CongTyId, DoiTacId);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
