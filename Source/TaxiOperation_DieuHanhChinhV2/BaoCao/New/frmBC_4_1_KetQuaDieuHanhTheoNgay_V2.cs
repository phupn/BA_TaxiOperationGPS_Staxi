using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using Taxi.Business;
using Taxi.Controls.BaoCao;
using Taxi.Data.BaoCaoNew;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    [ReportInfo(Title = "Báo cáo tổng hợp cuốc khách điều hành")]
    public partial class frmBC_4_1_KetQuaDieuHanhTheoNgay_V2 : FrmReportBase
    {
        public frmBC_4_1_KetQuaDieuHanhTheoNgay_V2()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
           
            return LoadReportData();
        }

        private DataTable LoadReportData()
        {
            DateTime dateGioDauCa;
            // lay gio cua ca
            DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
            try
            {
                dateGioDauCa = Convert.ToDateTime(dt.Rows[0]["DauCa1"].ToString());
            }
            catch 
            {
                dateGioDauCa = new DateTime(1900, 1, 1, 6, 0, 0);
            }
            DateTime TuNgay = new DateTime(this.FromDate.Value.Year, this.FromDate.Value.Month, this.FromDate.Value.Day, dateGioDauCa.Hour, dateGioDauCa.Minute, dateGioDauCa.Second);
            DateTime DenNgay = this.ToDate.Value.Date;
            DenNgay = DenNgay.AddDays(1).Add(TuNgay.TimeOfDay.Add(new TimeSpan(0, 0, -1)));                        
            DataTable dtDHTheoNgay = new BC_4_9_TKeSoLieuDieuHanh().BaoCaoKQDieuHanhTheoNgay(TuNgay, DenNgay);
            lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);
            //Tính tỷ trọng!
            object objSum;
            float  tyTrong;
            for (int i = 0; i < dtDHTheoNgay.Rows.Count; i++)
            {
                if (i != 0)
                {
                    string ngayInGroup = dtDHTheoNgay.Rows[i - 1]["NgayHienThi"].ToString();
                    if (dtDHTheoNgay.Rows[i]["NgayHienThi"].ToString() != ngayInGroup || i == (dtDHTheoNgay.Rows.Count - 1))
                    {
                        objSum = dtDHTheoNgay.Compute("Sum(TongGoiTaxi)", "NgayHienThi = " + "'" + ngayInGroup + "'");
                        foreach (DataRow dr in dtDHTheoNgay.Rows)
                        {
                            if (dr["NgayHienThi"].ToString() == ngayInGroup)
                            {
                                tyTrong = (float.Parse(dr["TongGoiTaxi"].ToString()) / float.Parse(objSum.ToString())) * 100;
                                dr["TyTrong"] = tyTrong;
                            }
                        }
                    }
                }
            }
            return dtDHTheoNgay;
        }

        protected override void AfterFind()
        {
            InitGridControl();
        }

        private void InitGridControl()
        {
            bandedGridView1.BeginSort();
            try
            {
                bandedGridView1.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                {
                    new GridColumnSortInfo(bandedGridView1.Columns[0], DevExpress.Data.ColumnSortOrder.Ascending),                        
                    new GridColumnSortInfo(bandedGridView1.Columns[1], DevExpress.Data.ColumnSortOrder.Ascending)//Cột vùng
                }, 1);
            }
            finally
            {
                bandedGridView1.EndSort();
            }
        }
    }
}