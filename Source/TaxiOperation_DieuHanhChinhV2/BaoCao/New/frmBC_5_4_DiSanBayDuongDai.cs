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
using Janus.Windows.GridEX;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBC_5_4_DiSanBayDuongDai : Form
    {
        private DataTable g_dt = new DataTable();
        private const int MAX_DATES = 100;
        private fmProgress m_fmProgress = null;
        public frmBC_5_4_DiSanBayDuongDai()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();
            calTuNgay.Value = dateCurrent.Date;
            date_DenNgay.Value = dateCurrent;
          //  LoadData(calTuNgay.Value, calDenNgay.Value);

            btnRefresh.Enabled = false ;
          //  btnPrint.Enabled = false ;
            btnExportExcel.Enabled = false ;
           // LoadDuLieuCuocGoiDiTuPhanCung();
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {           
             LoadData(calTuNgay.Value, date_DenNgay.Value);             
        }
        /// <summary>
        /// lấy thông tin xe đi san bay đường dài theo ngày
        /// </summary>
        /// <param name="Ngay"></param>
        private void LoadData(DateTime  TuNgay, DateTime DenNgay )
        {
            g_dt = TimKiem_BaoCao.GetBaoCaoXeDiSanBayDuongDai(TuNgay, DenNgay);
            if (chkAirPort.Checked)
            {
                DataTable dt = g_dt.Clone();
                DataRow[] rows = g_dt.Select("SUBSTRING(SoHieuXe,1,1) = '8'");
                foreach (DataRow item in rows)
                {
                    dt.ImportRow(item);
                }
                gridBaoCaoBieuMau1.DataMember = "ListDienThoai";
                gridBaoCaoBieuMau1.SetDataBinding(dt, "ListDienThoai");

                // input vao luoi cho xuat excel
                gridEX1.DataMember = "ListDienThoai1";
                gridEX1.SetDataBinding(dt, "ListDienThoai1");
            }
            else
            {
                gridBaoCaoBieuMau1.DataMember = "ListDienThoai";
                gridBaoCaoBieuMau1.SetDataBinding(g_dt, "ListDienThoai");

                // input vao luoi cho xuat excel
                gridEX1.DataMember = "ListDienThoai1";
                gridEX1.SetDataBinding(g_dt, "ListDienThoai1");
            }            

            SetUnActiveRefreshButton();
            btnRefresh.Enabled = true;
        }
         
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = string.Format("BaoCaoXeDiSanBayDuongDai_{0:dd_MM_yyyy}.xls",calTuNgay.Value);
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);   
                gridEXExporter1.Export ((Stream)objFile);
                new MessageBox.MessageBox().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void gridBaoCaoBieuMau1_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if(e.Row.RowType == RowType.Record)
            {
                //SanBayMotChieu
                if (e.Row.Cells["SanBayMotChieu"].Value.ToString() == "0")
                    e.Row.Cells["SanBayMotChieu"].Text = "";                
                else
                    e.Row.Cells["SanBayMotChieu"].Text = "x";

                if (e.Row.Cells["SanBayMotChieuVeCoKhach"].Value.ToString() == "0")
                    e.Row.Cells["SanBayMotChieuVeCoKhach"].Text = "";
                else
                    e.Row.Cells["SanBayMotChieuVeCoKhach"].Text = "x";

                if (e.Row.Cells["SanBayHaiChieu"].Value.ToString() == "0") 
                    e.Row.Cells["SanBayHaiChieu"].Text = ""; 
                else
                    e.Row.Cells["SanBayHaiChieu"].Text = "x";

                if (e.Row.Cells["DuongDaiMotChieu"].Value.ToString() == "0")
                    e.Row.Cells["DuongDaiMotChieu"].Text = "";
                else
                    e.Row.Cells["DuongDaiMotChieu"].Text = "x";

                if (e.Row.Cells["DuongDaiHaiChieu"].Value.ToString() == "0")
                    e.Row.Cells["DuongDaiHaiChieu"].Text = "";
                else
                    e.Row.Cells["DuongDaiHaiChieu"].Text = "x";

                if (e.Row.Cells["ThueBao"].Value.ToString() == "0")
                    e.Row.Cells["ThueBao"].Text = "";
                else
                    e.Row.Cells["ThueBao"].Text = "x";

            }
        }

     
    }
}