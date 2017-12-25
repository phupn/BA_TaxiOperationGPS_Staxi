using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using Taxi.Controls.BaoCao;
using Taxi.Data.BaoCaoNew;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "Báo cáo kết quả điều hành theo ca/ theo vùng/ theo giờ")]
    public partial class frmBC_4_2_BaoCaoKQDieuHanhTheoCaVung : FrmReportBase
    {
        public int IsCa { get; set; }
        public frmBC_4_2_BaoCaoKQDieuHanhTheoCaVung()
        {
            InitializeComponent();
        }

        protected override object GetData()
        {
            return LayDuLieuBaoCao(IsCa);
        }
        protected override void AfterFind()
        {
            InitGridControl();
        }
        private void InitGridControl()
        {
            bandedGridView.BeginSort();
            try
            {
                subGroupKey.FieldName = "Gio";
                subGroupKey.GroupIndex = -1;
                subGroupKey.Visible = false;
                if (IsCa == 2)
                {
                    subGroupKey.FieldName = "Gio";
                    subGroupKey.GroupIndex = 1;
                    subGroupKey.Visible = false;
                    bandedGridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                    {
                        new GridColumnSortInfo(bandedGridView.Columns[0], DevExpress.Data.ColumnSortOrder.Ascending),
                        new GridColumnSortInfo(bandedGridView.Columns[1], DevExpress.Data.ColumnSortOrder.Ascending),
                        new GridColumnSortInfo(bandedGridView.Columns[2], DevExpress.Data.ColumnSortOrder.Ascending)
                    }, 2);
                }
                else
                {
                    bandedGridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                    {
                        new GridColumnSortInfo(bandedGridView.Columns[0], DevExpress.Data.ColumnSortOrder.Ascending),                        
                        new GridColumnSortInfo(bandedGridView.Columns[2], DevExpress.Data.ColumnSortOrder.Ascending)//Cột ca
                    }, 1);
                }

                if (IsCa == 1)
                {
                    groupKey.FieldName = "Vung";
                    groupKey.Caption = "Vùng";
                }
                else if (IsCa == 2)
                {
                    groupKey.FieldName = "Vung";
                    groupKey.Caption = "Vùng";
                }
                else
                {
                    groupKey.FieldName = "Ca";
                    groupKey.FieldName = "Ca";
                }
            }
            finally
            {
                bandedGridView.EndSort();
            }

        }
        public DataTable LayDuLieuBaoCao(int pIsCa)
        {
            DateTime TuNgay = FromDate.Value;
            DateTime DenNgay = ToDate.Value;
            DataTable dtDHTheoNgay;
            if (pIsCa ==0)
                dtDHTheoNgay = new BC_4_9_TKeSoLieuDieuHanh().BaoCaoKQDieuHanhTheoCa(TuNgay, DenNgay);
            else if (pIsCa==1)
                dtDHTheoNgay = new BC_4_9_TKeSoLieuDieuHanh().BaoCaoKQDieuHanhTheoVung(TuNgay, DenNgay);
            else 
                dtDHTheoNgay = new BC_4_9_TKeSoLieuDieuHanh().BaoCaoKQDieuHanhTheoGio(TuNgay, DenNgay);

            //Tính tỷ trọng của báo cáo!
            object objSum;
            float tyTrong;
            for (int i = 0; i <= dtDHTheoNgay.Rows.Count; i++)
            {
                if (i != 0)
                {
                    try
                    {
                        #region Tính tỷ trọng
                        if (pIsCa < 1)
                        {
                            string ngayInGroup = dtDHTheoNgay.Rows[i-1 ]["NgayHienThi"].ToString();
                            string Ca = dtDHTheoNgay.Rows[i-1]["Ca"].ToString();
                            objSum = dtDHTheoNgay.Compute("Sum(TongGoiTaxi)",  " NgayHienThi= " + "'" + ngayInGroup + "'");
                            foreach (DataRow dr in dtDHTheoNgay.Rows)
                            {
                                if (dr["Ca"].ToString() == Ca && dr["NgayHienThi"].ToString() == ngayInGroup && dr["NgayHienThi"].ToString().Length>8)
                                {
                                    tyTrong = (float.Parse(dr["TongGoiTaxi"].ToString()) / float.Parse(objSum.ToString())) * 100;
                                    dr["TyTrong"] = tyTrong;
                                }
                            }
                            
                        }
                        else if (pIsCa == 1)
                        {
                            string ngayInGroup = dtDHTheoNgay.Rows[i - 1]["NgayHienThi"].ToString();
                            string vung = dtDHTheoNgay.Rows[i - 1]["Vung"].ToString();
                            objSum = dtDHTheoNgay.Compute("Sum(TongGoiTaxi)", " NgayHienThi= " + "'" + ngayInGroup + "'");
                            foreach (DataRow dr in dtDHTheoNgay.Rows)
                            {
                                if (dr["Vung"].ToString() == vung && dr["NgayHienThi"].ToString() == ngayInGroup && dr["NgayHienThi"].ToString().Length > 8)
                                {
                                    if (objSum.ToString().Length > 1)
                                    {
                                        tyTrong = (float.Parse(dr["TongGoiTaxi"].ToString()) / float.Parse(objSum.ToString())) * 100;
                                        dr["TyTrong"] = tyTrong;
                                    }
                                }
                            }
                            
                        }
                        else if (pIsCa == 2)
                        {
                            string ngayInGroup = dtDHTheoNgay.Rows[i - 1]["NgayHienThi"].ToString();
                            string Gio = dtDHTheoNgay.Rows[i - 1]["Gio"].ToString();
                            if (ngayInGroup == "TONG")
                            {
                                objSum = dtDHTheoNgay.Compute("Sum(TongGoiTaxi)", " NgayHienThi= " + "'" + ngayInGroup + "'" + " and Gio is null");
                            }
                            else
                            {
                                objSum = dtDHTheoNgay.Compute("Sum(TongGoiTaxi)", " NgayHienThi= " + "'" + ngayInGroup + "'" + " and Gio= " + "'" + Gio + "'");
                            }

                            foreach (DataRow dr in dtDHTheoNgay.Rows)
                            {
                                if (dr["NgayHienThi"].ToString() == ngayInGroup && dr["Gio"].ToString() == Gio && dr["NgayHienThi"].ToString().Length > 8)
                                {
                                    tyTrong = (float.Parse(dr["TongGoiTaxi"].ToString()) / float.Parse(objSum.ToString())) * 100;
                                    dr["TyTrong"] = tyTrong;
                                }
                            }
                            
                        }
                        #endregion
                    }
                    catch 
                    {
                        
                    }
                }
            }
            return dtDHTheoNgay;
        }

        private void inputIsCa_EditValueChanged(object sender, EventArgs e)
        {           
            groupKey.Caption = inputIsCa.EditValue.Equals(0) ? "Ca" : "Vùng";
        }
    }
}
