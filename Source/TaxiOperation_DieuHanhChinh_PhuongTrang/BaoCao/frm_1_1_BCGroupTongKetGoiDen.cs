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

namespace Taxi.GUI 
{
    public partial class frmBCGroupTongKetGoiDen_1_1 : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        public frmBCGroupTongKetGoiDen_1_1()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();

            dateCurrent = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);

            calTuNgay.Value = dateCurrent;
            radTheoCa.Checked = true;
            //LoadData(calTuNgay.Value, radTheoCa.Checked);
        }
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            LoadData(calTuNgay.Value,radTheoCa.Checked );
        }

        private void LoadData(DateTime TuNgay, bool IsCa)
        {
            if (IsCa)
            {
                g_dt = new TimKiem_BaoCao().GROUP_BC_1_1_TongKetCuocGoiDenByCa(TuNgay);
                gridEX1.DataMember = "ListDienThoai";
                gridEX1.SetDataBinding(g_dt, "ListDienThoai");
                if (g_dt != null && g_dt.Rows.Count > 0)
                {
                    LoadChart(g_dt);
                    LoadChartMoiGioiVangLai(g_dt);
                }
            }
            else
            {
                g_dt = new TimKiem_BaoCao().GROUP_BC_1_1_TongKetCuocGoiDenByGio(TuNgay);
                gridTheoGio .DataMember = "ListDienThoai";
                gridTheoGio .SetDataBinding(g_dt, "ListDienThoai"); 
            }
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }

        #region bieu do

        private void LoadChart(DataTable dtCuocGoiTheoCa)
        {
            try
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
                        // Ca , Tu, Den,TongTaxi,TongGoiLai,TOngKhieuNai,TongGoiKhac,Tong,TongGoiNho,TongDonDuoc,PhanTramDonDuoc, TongTruotHoan,,
                        // TongKhongXe,PhanTramKhongXe, TongKhongXacDinh , PhanTramKhongXacDinh, TongCuocTaxiMoiGioi
                        if (dr["TongTaxi"] != null && dr["TongTaxi"].ToString().Length > 0)
                        {
                            arrCuocGoiTaxi[i] = Convert.ToInt32(dr["TongTaxi"].ToString());
                        }
                        else arrCuocGoiTaxi[i] = 0;
                        if (dr["TongDonDuoc"] != null && dr["TongDonDuoc"].ToString().Length > 0)
                            arrCuocGoiDonDuocKhach[i] = (int)dr["TongDonDuoc"];
                        else arrCuocGoiDonDuocKhach[i] = 0;
                        if (dr["TongTruotHoan"] != null && dr["TongTruotHoan"].ToString().Length > 0)
                            arrCuocGoiTruotHoan[i] = (int)dr["TongTruotHoan"];
                        else arrCuocGoiTruotHoan[i] = 0;
                        if (dr["TongKhongXe"] != null && dr["TongKhongXe"].ToString().Length > 0)
                            arrCuocGoiKhongxe[i] = (int)dr["TongKhongXe"];
                        else arrCuocGoiKhongxe[i] = 0;
                        if (dr["TongCuocTaxiMoiGioi"] != null && dr["TongCuocTaxiMoiGioi"].ToString().Length > 0)
                            arrCuocGoiMoiGioi[i] = (int)dr["TongCuocTaxiMoiGioi"];
                        else arrCuocGoiMoiGioi[i] = 0;                        
                        arrCuocGoiVangLai[i] = arrCuocGoiTaxi[i] - arrCuocGoiMoiGioi[i];
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
                    c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}", calTuNgay.Value));
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
                    ChartVungKieu1.Image = c.makeImage();
                    // ChartVungKieu1.Image.Save(Configuration.GetReportPath() + "\\BieuDo1.jpg");
                    //include tool tip for the chart
                    ChartVungKieu1.ImageMap = c.getHTMLImageMap("clickable", "",
                        "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadChartMoiGioiVangLai(DataTable dtCuocGoiTheoCa)
        {
            try{
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
                    // Ca , Tu, Den,TongTaxi,TongGoiLai,TOngKhieuNai,TongGoiKhac,Tong,TongGoiNho,TongDonDuoc,PhanTramDonDuoc, TongTruotHoan,,
                    // TongKhongXe,PhanTramKhongXe, TongKhongXacDinh , PhanTramKhongXacDinh, TongCuocTaxiMoiGioi
                    if (dr["TongTaxi"] != null && dr["TongTaxi"].ToString().Length > 0)
                        arrCuocGoiTaxi[i] = (int)dr["TongTaxi"];
                    else arrCuocGoiTaxi[i] = 0;
                    if (dr["TongDonDuoc"] != null && dr["TongDonDuoc"].ToString().Length > 0)
                        arrCuocGoiDonDuocKhach[i] = (int)dr["TongDonDuoc"];
                    else arrCuocGoiDonDuocKhach[i] = 0;
                    if (dr["TongTruotHoan"] != null && dr["TongTruotHoan"].ToString().Length > 0)
                        arrCuocGoiTruotHoan[i] = (int)dr["TongTruotHoan"];
                    else arrCuocGoiTruotHoan[i] = 0;
                    if (dr["TongKhongXe"] != null && dr["TongKhongXe"].ToString().Length > 0)
                        arrCuocGoiKhongxe[i] = (int)dr["TongKhongXe"];
                    else arrCuocGoiKhongxe[i] = 0;
                    if (dr["TongCuocTaxiMoiGioi"] != null && dr["TongCuocTaxiMoiGioi"].ToString().Length > 0)
                        arrCuocGoiMoiGioi[i] = (int)dr["TongCuocTaxiMoiGioi"];
                    else arrCuocGoiMoiGioi[i] = 0;
                    arrCuocGoiVangLai[i] = arrCuocGoiTaxi[i] - arrCuocGoiMoiGioi[i];                    

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
                c.xAxis().setTitle("Ngày " + string.Format("{0:dd/MM/yyyy}", calTuNgay.Value));
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
                //viewer2.Image.Save(Configuration.GetReportPath() + "\\BieuDo2.jpg");
                //include tool tip for the chart
                viewer2.ImageMap = c.getHTMLImageMap("clickable", "",
                    "title='[{dataSetName}] {xLabel}: {value} Cuộc gọi'");
            }
             }
            catch (Exception ex)
            {

            }
        }

        #endregion bieudo
        
 

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_1_1.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                if (radTheoCa.Checked) gridEXExporter1.GridEX = gridEX1;
                else gridEXExporter1.GridEX = gridTheoGio;
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
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.TotalRow)
            {
                //TongTaxi,  TongDonDuoc, TongTruotHoan, TongKhongXe,TongKhongXacDinh, PhanTramDonDuoc,PhanTramTruotHoan,PhanTramKhongXe, ,PhanTramKhongXacDinh 
                double TongTaxi = (double)e.Row.Cells["TongTaxi"].Value;
                double TongDonDuoc = (double)e.Row.Cells["TongDonDuoc"].Value;
                double TongTruotHoan = (double)e.Row.Cells["TongTruotHoan"].Value;
                double TongKhongXe = (double)e.Row.Cells["TongKhongXe"].Value;
                double TongKhongXacDinh = (double)e.Row.Cells["TongKhongXacDinh"].Value;

                if (TongTaxi != 0)
                {
                    double PhanTramDonDuoc = TongDonDuoc / TongTaxi * 100;
                    double PhanTramTruotHoan = TongTruotHoan / TongTaxi * 100;
                    double PhanTramKhongXe = TongKhongXe / TongTaxi * 100;
                    double PhanTramKhongXacDinh = TongKhongXacDinh / TongTaxi * 100;

                    //e.Row.Cells["PhanTramDonDuoc"].Value = PhanTramDonDuoc;
                    e.Row.Cells["PhanTramDonDuoc"].Text = string.Format("{0:#.##}", PhanTramDonDuoc);

                    // e.Row.Cells["PhanTramTruotHoan"].Value = PhanTramTruotHoan;
                    e.Row.Cells["PhanTramTruotHoan"].Text = string.Format("{0:#.##}", PhanTramTruotHoan);

                    //e.Row.Cells["PhanTramKhongXe"].Value = PhanTramKhongXe;
                    e.Row.Cells["PhanTramKhongXe"].Text = string.Format("{0:#.##}", PhanTramKhongXe);

                    // e.Row.Cells["PhanTramKhongXacDinh"].Value = PhanTramKhongXacDinh;
                    e.Row.Cells["PhanTramKhongXacDinh"].Text = string.Format("{0:#.##}", PhanTramKhongXacDinh);
                }
            } 
        }

        private void radTheoGio_CheckedChanged(object sender, EventArgs e)
        {
            gridEX1.Visible = !radTheoGio.Checked;
            ChartVungKieu1.Visible = !radTheoGio.Checked;
            viewer2.Visible = !radTheoGio.Checked;
            gridTheoGio .Visible =  radTheoGio.Checked;
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void radTheoCa_CheckedChanged(object sender, EventArgs e)
        {
            gridEX1.Visible =  radTheoCa.Checked;
            ChartVungKieu1.Visible = radTheoCa.Checked;
            viewer2.Visible = radTheoCa.Checked;
            gridTheoGio.Visible = !radTheoCa.Checked;
            
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;            
        }

        private void gridTheoGio_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.TotalRow)
            {
                //TongTaxi,  TongDonDuoc, TongTruotHoan, TongKhongXe,TongKhongXacDinh, PhanTramDonDuoc,PhanTramTruotHoan,PhanTramKhongXe, ,PhanTramKhongXacDinh 
                double TongTaxi          = (double)e.Row.Cells["TongTaxi"].Value;
                double TongDonDuoc       = (double)e.Row.Cells["TongDonDuoc"].Value;
                double TongTruotHoan     =( double)e.Row.Cells["TongTruotHoan"].Value;
                double TongKhongXe       = (double)e.Row.Cells["TongKhongXe"].Value;
                double TongKhongXacDinh  = (double)e.Row.Cells["TongKhongXacDinh"].Value;

                if (TongTaxi!= 0)
                {
                    double PhanTramDonDuoc      =  TongDonDuoc/TongTaxi * 100;
                    double PhanTramTruotHoan    = TongTruotHoan / TongTaxi * 100;
                    double PhanTramKhongXe      = TongKhongXe / TongTaxi * 100;
                    double PhanTramKhongXacDinh = TongKhongXacDinh/ TongTaxi * 100;

                    //e.Row.Cells["PhanTramDonDuoc"].Value = PhanTramDonDuoc;
                    e.Row.Cells["PhanTramDonDuoc"].Text  = string.Format ("{0:#.##}",PhanTramDonDuoc); 

                   // e.Row.Cells["PhanTramTruotHoan"].Value = PhanTramTruotHoan;
                    e.Row.Cells["PhanTramTruotHoan"].Text  = string.Format ("{0:#.##}",PhanTramTruotHoan); 

                     //e.Row.Cells["PhanTramKhongXe"].Value = PhanTramKhongXe;
                    e.Row.Cells["PhanTramKhongXe"].Text  = string.Format ("{0:#.##}",PhanTramKhongXe); 

                    // e.Row.Cells["PhanTramKhongXacDinh"].Value = PhanTramKhongXacDinh;
                    e.Row.Cells["PhanTramKhongXacDinh"].Text  = string.Format ("{0:#.##}",PhanTramKhongXacDinh); 
                }
            }
        }
    }
}