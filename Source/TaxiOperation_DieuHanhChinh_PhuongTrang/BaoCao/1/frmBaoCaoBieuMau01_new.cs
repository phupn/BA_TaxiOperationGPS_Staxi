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
    public partial class frmBaoCaoBieuMau01_new : Form
    {
        DataTable g_dt = new DataTable();
        private const int MAX_DATES = 100;

        public frmBaoCaoBieuMau01_new()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();          
            calNgay.Value = dateCurrent;
            LoadDulieuBaoCao_BieuMau1_New();            
        }
        private void LoadDulieuBaoCao_BieuMau1_New()
        {


            g_dt = new TimKiem_BaoCao().FillData_BieuMau1_New(string.Format("{0:yyyy-MM-dd}", calNgay.Value));

            LoadChart(g_dt);
            LoadChartMoiGioiVangLai(g_dt);

            gridBaoCaoBieuMau1.DataSource = g_dt;
            btnRefresh.Enabled = false;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDulieuBaoCao_BieuMau1_New();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmInBaoCao frmPrint = new frmInBaoCao();
            //frmPrint.InBaoCaoBieuMau1(Configuration.GetReportPath() + "\\Baocao_Bieumau1_NEW.rpt", g_dt,calNgay.Value , Configuration.GetReportPath() + "\\BieuDo1.jpg", Configuration.GetReportPath() + "\\BieuDo2.jpg");
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


        #region bieu do
        private void LoadChart(DataTable dtCuocGoiTheoCa)
        {


            if (dtCuocGoiTheoCa.Rows.Count > 0)
            {
                double[] arrCuocGoiTaxi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiDonDuocKhach = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiTruotHoan = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiKhongxe = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoCa.Rows.Count];
                string[] lableVertical = new string[dtCuocGoiTheoCa.Rows.Count];
                int MaxCuocGoi = 0;
                int i = 0;
                foreach (DataRow dr in dtCuocGoiTheoCa.Rows)
                {
                    //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
                    arrCuocGoiTaxi[i] = (int)dr["CuocGoiTaxiTong"];
                    arrCuocGoiDonDuocKhach[i] = (int)dr["DonDuocKhachTong"];
                    arrCuocGoiTruotHoan[i] = (int)dr["LyDoTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["LyDoKhongXe"];
                    arrCuocGoiMoiGioi[i] = (int)dr["DonDuocKhachMoiGioi"];
                    arrCuocGoiVangLai[i] = (int)dr["DonDuocKhachVangLai"];
                    lableVertical[i] = "Ca " + dr["Ca"].ToString();
                    i++;
                }

                // Create an XYChart object of size 600 x 300 pixels, with a light blue
                // (EEEEFF) background, black border, 1 pxiel 3D border effect and
                // rounded corners 438, 306
                XYChart c = new XYChart(438, 306, 0xeeeeff, 0x000000, 1);
                c.setRoundedFrame();

                // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
                // background. Turn on both horizontal and vertical grid lines with light
                // grey color (0xcccccc)
                c.setPlotArea(50, 40, 380, 225, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
                //  c.setAntiAlias(); 



                // Add a legend box at (50, 30) (top of the chart) with horizontal
                // layout. Use 9 pts Arial Bold font. Set the background and border color
                // to Transparent.
                c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(Chart.Transparent);

                // Add a title box to the chart using 15 pts Times Bold Italic font, on a
                // light blue (CCCCFF) background with glass effect. white (0xffffff) on
                // a dark red (0x800000) background, with a 1 pixel 3D border.
                c.addTitle("Biểu đồ cuộc gọi taxi theo ca",
                    "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());

                // Add a title to the y axis
                c.yAxis().setTitle("Số cuộc gọi");
                //c.yAxis().setLabels(lableVertical);
                // Set the labels on the x axis.
                c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}", calNgay.Value));
                // c.addStepLineLayer(); 
                c.xAxis().setLabels(lableVertical);


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
                layer.addDataSet(arrCuocGoiDonDuocKhach, 0x008800, "Đón được");
                layer.addDataSet(arrCuocGoiTruotHoan, c.dashLineColor(0x3333ff, Chart.DashLine),
                    "Trượt hoãn");
                layer.addDataSet(arrCuocGoiKhongxe, 0xff00ff, "Không xe");
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
                    "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
            }
        }

        private void LoadChartMoiGioiVangLai(DataTable dtCuocGoiTheoCa)
        {

            if (dtCuocGoiTheoCa.Rows.Count > 0)
            {
                double[] arrCuocGoiTaxi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiDonDuocKhach = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiTruotHoan = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiKhongxe = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiMoiGioi = new double[dtCuocGoiTheoCa.Rows.Count];
                double[] arrCuocGoiVangLai = new double[dtCuocGoiTheoCa.Rows.Count];
               // double[] arrCuocGoiMoiGioiTruotHoanKhongXe = new double[dtCuocGoiTheoCa.Rows.Count];
               // double[] arrCuocGoiVangLaiTruotHoanKhongXe = new double[dtCuocGoiTheoCa.Rows.Count];

                string[] lableVertical = new string[dtCuocGoiTheoCa.Rows.Count];
                int MaxCuocGoi = 0;
                int i = 0;
                foreach (DataRow dr in dtCuocGoiTheoCa.Rows)
                {
                    //Ngay, TongCuocGoiTaxi,CuocGoiDonDuoc,CuocGoiTruotHoan ,CuocGoiKhongXe,CuocGoiMoiGioi,CuocGoiVangLai
                    arrCuocGoiTaxi[i] = (int)dr["CuocGoiTaxiTong"];
                    arrCuocGoiDonDuocKhach[i] = (int)dr["DonDuocKhachTong"];
                    arrCuocGoiTruotHoan[i] = (int)dr["LyDoTruotHoan"];
                    arrCuocGoiKhongxe[i] = (int)dr["LyDoKhongXe"];
                    arrCuocGoiMoiGioi[i] = (int)dr["DonDuocKhachMoiGioi"];
                    arrCuocGoiVangLai[i] = (int)dr["DonDuocKhachVangLai"];
                    //arrCuocGoiMoiGioiTruotHoanKhongXe[i] = -(int)dr["KhongDonDuocMoiGioi"];
                   // arrCuocGoiVangLaiTruotHoanKhongXe[i] = -(int)dr["KhongDonDuocVangLai"];
                    lableVertical[i] = "Ca " + dr["Ca"].ToString();
                    i++;
                }

                // Create an XYChart object of size 600 x 300 pixels, with a light blue
                // (EEEEFF) background, black border, 1 pxiel 3D border effect and
                // rounded corners 438, 306
                XYChart c = new XYChart(438, 306, 0xeeeeff, 0x000000, 1);
                c.setRoundedFrame();

                // Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white
                // background. Turn on both horizontal and vertical grid lines with light
                // grey color (0xcccccc)
                c.setPlotArea(50, 40, 380, 225, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
                //  c.setAntiAlias(); 



                // Add a legend box at (50, 30) (top of the chart) with horizontal
                // layout. Use 9 pts Arial Bold font. Set the background and border color
                // to Transparent.
                c.addLegend(50, 30, false, "Arial Bold", 9).setBackground(Chart.Transparent);

                // Add a title box to the chart using 15 pts Times Bold Italic font, on a
                // light blue (CCCCFF) background with glass effect. white (0xffffff) on
                // a dark red (0x800000) background, with a 1 pixel 3D border.
                c.addTitle("Biểu đồ cuộc gọi môi giới/vãng lai theo ca",
                    "Times New Roman Bold Italic", 15).setBackground(0xccccff, 0x000000,
                    Chart.glassEffect());

                // Add a title to the y axis
                c.yAxis().setTitle("Số cuộc gọi");
                //c.yAxis().setLabels(lableVertical);
                // Set the labels on the x axis.
                c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}", calNgay.Value));
                // c.addStepLineLayer(); 
                c.xAxis().setLabels(lableVertical);


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

                layer.addDataSet(arrCuocGoiMoiGioi, 0xffff00, "Môi giới");
                //128, 255, 255
                layer.addDataSet(arrCuocGoiVangLai, 0x00ff7f, "Vãng lai");

                //layer.addDataSet(arrCuocGoiMoiGioiTruotHoanKhongXe, 0x00aa7f, "Trượt,Hoãn,Không xe môi giới");
                //layer.addDataSet(arrCuocGoiVangLaiTruotHoanKhongXe, 0x00dd7f, "Trượt,Hoãn,Không xe vãng lai");
                // Enable bar label for the whole bar
                layer.setAggregateLabelStyle();

                // Enable bar label for each segment of the stacked bar
                layer.setDataLabelStyle();

                // output the chart
                viewer2.Image = c.makeImage();
                viewer2.Image.Save(Configuration.GetReportPath() + "\\BieuDo2.jpg"); 
                //include tool tip for the chart
                viewer2.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
            }

        }

        #endregion bieudo

        private void calNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true  ;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        

       

    }
}