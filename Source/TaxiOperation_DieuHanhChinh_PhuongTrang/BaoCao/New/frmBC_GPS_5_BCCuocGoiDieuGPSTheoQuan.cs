using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using ChartDirector;
using System.IO;
using Taxi.Utils;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.Business.DM;
using DevExpress.XtraCharts;

namespace Taxi.GUI 
{
    public partial class frmBC_GPS_5_BCCuocGoiDieuGPSTheoQuan : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        DataTable danhSachBinhQuan = new DataTable();
        DataTable DSTinhThanh = new DataTable();
        public frmBC_GPS_5_BCCuocGoiDieuGPSTheoQuan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieu();
        }

        private void KhoiTaoDuLieu()
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();           
            
            dateCurrent = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);
            calTuNgay.Value = dateCurrent;
            calDenNgay.Value = dateCurrent;
            DSTinhThanh = new DMTinhThanh().GetQuanHuyenByID(62);
            
            danhSachBinhQuan.Columns.Add("MaQuan",typeof(string));
            danhSachBinhQuan.Columns.Add("TenQuan", typeof(string));
            danhSachBinhQuan.Columns.Add("TongCuocGoi", typeof(int));
        }
 
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                DateTime TuNgay = calTuNgay.Value;
                DateTime DenNgay = calDenNgay.Value;
                
                LoadData(TuNgay, DenNgay);
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }            
        }

        private void LoadData(DateTime TuNgay, DateTime DenNgay)
        {
            bool DonDuoc = false;
            bool TruotHoan = false;
            bool KhongXe = false;
            if (chkDonDuoc.Checked) DonDuoc = true;
            if (chkTruotHoan.Checked) TruotHoan = true;
            if (chkKhongXe.Checked) KhongXe = true;

            DataTable dt = new TimKiem_BaoCao().GROUP_BC_GPS_BCCuocKhachGPSTheoQuan(TuNgay, DenNgay, DonDuoc,TruotHoan,KhongXe);
            if (dt != null && dt.Rows.Count > 0 && DSTinhThanh != null && DSTinhThanh.Rows.Count > 0)
            {
                if (DSTinhThanh.Columns.Contains("TongCuocGoi"))
                {
                    DSTinhThanh.Columns.Remove("TongCuocGoi");
                    DSTinhThanh.Columns.Add("TongCuocGoi", typeof(int));
                }
                else
                    DSTinhThanh.Columns.Add("TongCuocGoi", typeof(int));
                string polygon = "";
                float KinhDo = 0;
                float ViDo = 0;
                foreach (DataRow CuocKhach in dt.Rows)
                {
                    KinhDo = float.Parse(CuocKhach["GPS_KinhDo"].ToString());
                    ViDo = float.Parse(CuocKhach["GPS_ViDo"].ToString());
                    
                    foreach (DataRow quanHuyen in DSTinhThanh.Rows)
                    {                        
                        polygon = quanHuyen["Polygon"].ToString();
                        
                        if (CheckPointInPolygon(ViDo,KinhDo,polygon))
                        {
                            int cuocGoi = 0;
                            int.TryParse(quanHuyen["TongCuocGoi"].ToString(),out cuocGoi);
                            quanHuyen["TongCuocGoi"] = cuocGoi + 1;
                        }
                    }
                }

                gridBinhQuan.SetDataBinding(null, "ListBQ");
                gridBinhQuan.DataMember = "ListBQ";
                gridBinhQuan.SetDataBinding(DSTinhThanh, "ListBQ");

                btnRefresh.Enabled = false;
                btnExportExcel.Enabled = !btnRefresh.Enabled;
                Series series1 = new Series("Cuốc khách điều hành GPS theo quận", ViewType.Pie);                
                foreach (DataRow quanHuyen in DSTinhThanh.Rows)
                {
                    int tongcuoc = 0;
                    int.TryParse(quanHuyen["TongCuocGoi"].ToString(), out tongcuoc);
                    if (tongcuoc > 0)
                    {
                        series1.Points.Add(new SeriesPoint(quanHuyen["NameVN"].ToString(), tongcuoc));
                    }
                }
                if (chartControl.Series.Count > 0) chartControl.Series.Clear();
                chartControl.Series.Add(series1);
                series1.PointOptions.PointView = PointView.ArgumentAndValues;
                series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                series1.PointOptions.ValueNumericOptions.Precision = 0;
                // Detect overlapping of series labels.
                ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

                // Access the view-type-specific options of the series.
                PieSeriesView myView = (PieSeriesView)series1.View;

                // Show a title for the series.
                myView.Titles.Add(new SeriesTitle());
                myView.Titles[0].Text = series1.Name;

                // Specify a data filter to explode points.
                myView.ExplodeMode = PieExplodeMode.None;
                myView.ExplodedDistancePercentage = 30;
                myView.RuntimeExploding = true;
                myView.HeightToWidthRatio = 99;
                                
            }
            else
            {
                gridBinhQuan.SetDataBinding(null, "ListBQ");
            }
            
        }

        /// <summary>
        /// Check point thuoc polygon hay ko
        /// </summary>
        /// <param name="LatDes"></param>
        /// <param name="LngDes"></param>
        /// <param name="Polygon">105.8503 21.0408,105.8274 21.02956</param>
        /// <returns></returns>
        private bool CheckPointInPolygon(float LatDes, float LngDes, string strPolygon)
        {
            string[] arrPolygon;
            string[] Point;
            string[] ToaDoCuoi;
            float[] x = new float[2], y = new float[2];
            arrPolygon = strPolygon.Split(',');
            if (arrPolygon.Length <= 0) return false ;

            int length = arrPolygon.Length - 1;
                int cn = 0;
                for (int i = 0; i < arrPolygon.Length - 1; i++)
                {
                    Point = arrPolygon[i].Split(' ');
                    x[0] = float.Parse(Point[0]);// KD
                    y[0] = float.Parse(Point[1]);//VD

                    ToaDoCuoi = arrPolygon[i + 1].Split(' ');
                    x[1] = float.Parse(ToaDoCuoi[0]);
                    y[1] = float.Parse(ToaDoCuoi[1]);

                    if (((x[0] <= LngDes) && (x[1] > LngDes)) || ((x[0] > LngDes) && (x[1] <= LngDes)))
                    {
                        double vt = (LngDes - x[0]) / (x[1] - x[0]);
                        if (LatDes < y[0] + vt * (y[1] - y[0]))
                            ++cn;
                    }
                }
                if ((cn & 1) > 0) return true;
                else return false;
        }

        private bool IsPointInPolygon(PointF[] polygon, PointF point)
        {
            bool isInside = false;
            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }
        //public static bool IsInPolygon(Point[] poly, Point point)
        //{
        //    var coef = poly.Skip(1).Select((p, i) =>
        //                                    (point.Y - poly[i].Y) * (p.X - poly[i].X)
        //                                  - (point.X - poly[i].X) * (p.Y - poly[i].Y))
        //                            .ToList();

        //    if (coef.Any(p => p == 0))
        //        return true;

        //    for (int i = 1; i < coef.Count(); i++)
        //    {
        //        if (coef[i] * coef[i - 1] < 0)
        //            return false;
        //    }
        //    return true;
        //}

        private void btnExportExcel_Click(object sender, EventArgs e)
        {   
               // Tao binh quan
            saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_CuocGoiDieuHanhGPS_TheoQuan", calTuNgay.Value, calDenNgay.Value, false);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
        }

        
 
        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;           
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;  
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
             
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void btnExpChart_Click(object sender, EventArgs e)
        {
            if (chartControl.IsPrintingAvailable)
            {
                saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_CuocGoiDieuHanhGPS_TheoQuan_BieuDo", calTuNgay.Value, calDenNgay.Value, false);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Exports to an XLS file.
                    chartControl.ExportToXls(saveFileDialog1.FileName + ".xls");

                    // Exports to a stream as XLS.
                    FileStream xlsStream = new FileStream(saveFileDialog1.FileName + ".xls", FileMode.Create);
                    chartControl.ExportToXls(xlsStream);
                    xlsStream.Close();
                }
            }
        }
    }
}