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
    public partial class frmBaoCaoDiSanBayDuongDai_RutGon : Form
    {
        private DataTable g_dt = new DataTable();
        private const int MAX_DATES = 100;
        private fmProgress m_fmProgress = null;
        public frmBaoCaoDiSanBayDuongDai_RutGon()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();
            calTuNgay.Value = dateCurrent;
           // calDenNgay.Value = dateCurrent;
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
            
                LoadData(calTuNgay.Value);
             
        }
        /// <summary>
        /// lấy thông tin xe đi san bay đường dài theo ngày
        /// </summary>
        /// <param name="Ngay"></param>
        private void LoadData(DateTime  Ngay )
        {

            g_dt = TimKiem_BaoCao.GetBaoCaoXeDiSanBayDuongDai_RutGon(Ngay);
            
            gridBaoCaoBieuMau1.DataMember = "ListDienThoai";
            gridBaoCaoBieuMau1.SetDataBinding(g_dt, "ListDienThoai");

            SetUnActiveRefreshButton();
        }
        
       

        

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCaoXeDiSanBayDuongDai.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");

           //     Log objLog = new Log();
           //     objLog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.BaoCao_XuatBaoCao, DateTime.Now,
           //"Xuất báo cáo Đi SB-ĐD");
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
            if (e.Row.Cells["SanBay"].Value.ToString() == "0")
            {
                e.Row.Cells["SanBay"].Text = "";
            }
            if (e.Row.Cells["DuongDai"].Value.ToString() == "0")
            {
                e.Row.Cells["DuongDai"].Text = "";
            }
        }

     
    }
}