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

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoBieuMau2 : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        public frmBaoCaoBieuMau2()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();
            calTuNgay.Value = dateCurrent;
            calDenNgay.Value = dateCurrent;
            LoadData(calTuNgay.Value, calDenNgay.Value);
        }
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                LoadData(calTuNgay.Value, calDenNgay.Value);
                
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

            g_dt = new TimKiem_BaoCao().FillData_BieuMau2(string.Format("{0:yyyy-MM-dd}", TuNgay), string.Format("{0:yyyy-MM-dd}", DenNgay));
            gridBaoCaoBieuMau1.DataSource = g_dt;

            LoadChart(g_dt);
            LoadChartMoiGioiVangLai(g_dt);

            btnRefresh.Enabled = false;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel .Enabled = !btnRefresh.Enabled;
           
        }
        
        private void LoadChart(DataTable dtCuocGoiTheoNgay)
        {
            

            if (dtCuocGoiTheoNgay.Rows.Count > 0)
            {
                double[] arrCuocGoiTaxi = new double[dtCuocGoiTheoNgay.Rows.Count];
                double[] arrCuocGoiDonDuocKhach = new double[dtCuocGoiTheoNgay.Rows.Count];
                double[] arrCuocGoiTruotHoan = new double[dtCuocGoiTheoNgay.Rows.Count];
                double[] arrCuocGoiKhongxe = new double[dtCuocGoiTheoNgay.Rows.Count];
                double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoNgay.Rows.Count];
                double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoNgay.Rows.Count];
                DateTime[] lableVertical = new DateTime[dtCuocGoiTheoNgay.Rows.Count];
                int MaxCuocGoi = 0;
                int i=0;
                foreach (DataRow dr in dtCuocGoiTheoNgay.Rows)
                {
                    //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
                    arrCuocGoiTaxi[i] = (int)dr["TongCuocGoiTaxi"];
                    arrCuocGoiDonDuocKhach[i] = (int)dr["CuocGoiDonDuoc"];
                    arrCuocGoiTruotHoan[i] = (int)dr["CuocGoiTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["CuocGoiKhongXe"];
                    arrCuocGoiMoiGioi[i] = (int)dr["CuocGoiMoiGioi"];
                    arrCuocGoiVangLai[i] = (int)dr["CuocGoiVangLai"];
                    lableVertical[i] = DateTime .Parse (dr["Ngay"].ToString().Substring (0,10));
                    if (MaxCuocGoi < (int)dr["TongCuocGoiTaxi"])
                        MaxCuocGoi = (int)dr["TongCuocGoiTaxi"];
                        
                    i++;
                }

                // Create an XYChart object of size 600 x 300 pixels, with a light blue
                // (EEEEFF) background, black border, 1 pxiel 3D border effect and
                // rounded corners 490, 363
                XYChart c = new XYChart(490, 363, 0xeeeeff, 0x000000, 1);
                c.setRoundedFrame();

                // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
                // background. Turn on both horizontal and vertical grid lines with light
                // grey color (0xcccccc)
                c.setPlotArea(50, 40, 430, 280, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
              //  c.setAntiAlias(); 



                // Add a legend box at (50, 30) (top of the chart) with horizontal
                // layout. Use 9 pts Arial Bold font. Set the background and border color
                // to Transparent.
                c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(
                    Chart.Transparent);

                // Add a title box to the chart using 15 pts Times Bold Italic font, on a
                // light blue (CCCCFF) background with glass effect. white (0xffffff) on
                // a dark red (0x800000) background, with a 1 pixel 3D border.
                c.addTitle("Biểu đồ cuộc gọi taxi ",
                    "Times New Roman Bold Italic",15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());

                // Add a title to the y axis
                c.yAxis().setTitle("Số cuộc gọi");
                //c.yAxis().setLabels(lableVertical);
                // Set the labels on the x axis.
                c.xAxis().setTitle("Ngày");
               // c.addStepLineLayer(); 
                c.xAxis().setLabels(lableVertical, "{value|dd/mm}");


               // c.xAxis()
               // Display 1 out of 3 labels on the x-axis.
               // c.xAxis().setLabelStep(3);

                // Add a title to the x axis
               // c.xAxis().setTitle("Jun 12, 2006");

                // Add a line layer to the chart
                //LineLayer layer = c.addLineLayer2();
                BarLayer layer = c.addBarLayer2(Chart.Stack, 8);
                // Set the default line width to 2 pixels
                //layer.setLineWidth(2);

                // Add the three data sets to the line layer. For demo purpose, we use a
                // dash line color for the last line
               // layer.addDataSet(arrCuocGoiTaxi , 0xff0000, "Gọi taxi");
                layer.addDataSet(arrCuocGoiDonDuocKhach , 0x00eea0, "Đón được");
                layer.addDataSet(arrCuocGoiTruotHoan , 0x333303,"Trượt hoãn");
                layer.addDataSet(arrCuocGoiKhongxe, 0x88ff0f, "Không xe");
                //layer.addDataSet(arrCuocGoiMoiGioi, 0xaa00ff, "Môi giới");
               // layer.addDataSet(arrCuocGoiVangLai, 0xcc00ff, "Vãng lai");

                // Enable bar label for the whole bar
                layer.setAggregateLabelStyle();

                // Enable bar label for each segment of the stacked bar
                layer.setDataLabelStyle();

                // output the chart
                viewer.Image = c.makeImage();
                viewer.Image.Save(Configuration.GetReportPath() + "\\BieuDo1.jpg"); 
                //include tool tip for the chart
                viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] Ngày {xLabel}: {value} Cuộc gọi'");
            }
        }

        private void LoadChartMoiGioiVangLai(DataTable dtCuocGoiTheoNgay)
        {


            if (dtCuocGoiTheoNgay.Rows.Count > 0)
            {
              
                double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoNgay.Rows.Count];
                double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoNgay.Rows.Count];
                DateTime[] lableVertical = new DateTime[dtCuocGoiTheoNgay.Rows.Count];
              
                int i = 0;
                foreach (DataRow dr in dtCuocGoiTheoNgay.Rows)
                {
                    //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
                  
                    arrCuocGoiMoiGioi[i] = (int)dr["CuocGoiMoiGioi"];
                    arrCuocGoiVangLai[i] = (int)dr["CuocGoiVangLai"];
                    lableVertical[i] = DateTime.Parse(dr["Ngay"].ToString().Substring(0, 10));
                           i++;
                }

                // Create an XYChart object of size 600 x 300 pixels, with a light blue
                // (EEEEFF) background, black border, 1 pxiel 3D border effect and
                // rounded corners 490, 363
                XYChart c = new XYChart(490, 363, 0xeeeeff, 0x000000, 1);
                c.setRoundedFrame();

                // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
                // background. Turn on both horizontal and vertical grid lines with light
                // grey color (0xcccccc)
                c.setPlotArea(50, 40, 430, 280, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
                //  c.setAntiAlias(); 



                // Add a legend box at (50, 30) (top of the chart) with horizontal
                // layout. Use 9 pts Arial Bold font. Set the background and border color
                // to Transparent.
                c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(
                    Chart.Transparent);

                // Add a title box to the chart using 15 pts Times Bold Italic font, on a
                // light blue (CCCCFF) background with glass effect. white (0xffffff) on
                // a dark red (0x800000) background, with a 1 pixel 3D border.
                c.addTitle("Biểu đồ khách môi giới/vãng lai",
                    "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());

                // Add a title to the y axis
                c.yAxis().setTitle("Số cuộc gọi");
                //c.yAxis().setLabels(lableVertical);
                // Set the labels on the x axis.
                c.xAxis().setTitle("Ngày");
                // c.addStepLineLayer(); 
                c.xAxis().setLabels(lableVertical, "{value|dd/mm}");


                // c.xAxis()
                // Display 1 out of 3 labels on the x-axis.
                // c.xAxis().setLabelStep(3);

                // Add a title to the x axis
                // c.xAxis().setTitle("Jun 12, 2006");

                // Add a line layer to the chart
                //LineLayer layer = c.addLineLayer2();
                BarLayer layer = c.addBarLayer2(Chart.Stack, 8);
                // Set the default line width to 2 pixels
                //layer.setLineWidth(2);

               
                layer.addDataSet(arrCuocGoiMoiGioi, 0xffff00, "Môi giới");
                //128, 255, 255
                layer.addDataSet(arrCuocGoiVangLai, 0x00ff7f, "Vãng lai");

                // Enable bar label for the whole bar
                layer.setAggregateLabelStyle();

                // Enable bar label for each segment of the stacked bar
                layer.setDataLabelStyle();

                // output the chart
                view2 .Image = c.makeImage();
                view2.Image.Save(Configuration.GetReportPath() + "\\BieuDo2.jpg"); 

                //include tool tip for the chart
                view2.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] Ngày {xLabel}: {value} Cuộc gọi'");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmInBaoCao frmPrint = new frmInBaoCao();
            //frmPrint.InBaoCaoBieuMau2(Configuration.GetReportPath() + "\\Baocao_Bieumau2.rpt", g_dt, calTuNgay.Value, calDenNgay.Value, Configuration.GetReportPath() + "\\BieuDo1.jpg", Configuration.GetReportPath() + "\\BieuDo2.jpg");
            //frmPrint.ShowDialog(this);
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau2.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
    }
}