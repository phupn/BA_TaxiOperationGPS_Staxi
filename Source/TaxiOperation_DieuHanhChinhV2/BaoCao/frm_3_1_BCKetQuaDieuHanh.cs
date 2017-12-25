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
    public partial class frm_3_1_BCKetQuaDieuHanh : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        public frm_3_1_BCKetQuaDieuHanh()
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
            radTheoNgay.Checked = true;

            gridTheoGio.Visible = false;
            gridTheoCa.Visible = false;
            gridTheoNgay.Visible = true;

        }

        

        /// <summary>
        /// nếu chon kiểu báo cáo là ngày : return 1
        ///     chọn kiểu báo cáo là ca : return 2
        ///     chọn kiểu báo cáo là giờ : return 3
        /// </summary>
        /// <returns></returns>
        private int GetKieuBaoCao()
        {
            if (radTheoNgay.Checked) return 1;
            else if (radTheoCa.Checked) return 2;
            else if (radTheoGio.Checked) return 3;

            return 1;
        }

        /// <summary>
        /// Load phan len bieu mau
        /// </summary>        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string sVung = StringTools.TrimSpace(txtVung.Text);
            LoadData(calTuNgay.Value,calDenNgay.Value, this.GetKieuBaoCao(),sVung);
        }
        /// <summary>
        /// load kieu bao cao
        ///  1 : Báo cáo theo ngày
        ///  2 : Báo cáo theo ca
        ///  3 : Báo cáo theo giờ
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="KieuBaoCao"></param>
        private void LoadData(DateTime TuNgay, DateTime DenNgay, int KieuBaoCao, string sVung)
        {
            if (KieuBaoCao == 1)
            {
                 g_dt = new TimKiem_BaoCao().GROUP_BC_3_1_BaoCaoDieuHanhTheoNgay(TuNgay, DenNgay, sVung);
                 gridTheoNgay.DataMember = "ListDienThoai";
                 gridTheoNgay.SetDataBinding(g_dt, "ListDienThoai");
            }
            else if (KieuBaoCao == 2)
            {
                g_dt = new TimKiem_BaoCao().GROUP_BC_3_1_BaoCaoDieuHanhTheoCa(TuNgay, sVung);
                gridTheoCa.DataMember = "ListDienThoai";
                gridTheoCa.SetDataBinding(g_dt, "ListDienThoai");
            }
            else if (KieuBaoCao == 3)
            {    
                DateTime _TuNgay = new DateTime (TuNgay.Year,TuNgay.Month ,TuNgay.Day ,0,0,0);
                DateTime _DenNgay = new DateTime (TuNgay.Year,TuNgay.Month ,TuNgay.Day ,23,59,59);
                g_dt = new TimKiem_BaoCao().GROUP_BC_3_1_BaoCaoDieuHanhTheoGio(_TuNgay,_DenNgay , sVung);
                gridTheoGio.DataMember = "ListDienThoai";
                gridTheoGio.SetDataBinding(g_dt, "ListDienThoai");
            } 
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }
        
       
      
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = this.GetFileNameExport(calTuNgay.Value ,calDenNgay.Value );
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.GridEX = this.GetGridExport();
                gridEXExporter1.Export((Stream)objFile);
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
        }

        private Janus.Windows.GridEX.GridEX GetGridExport()
        {
            if (radTheoNgay.Checked)
            {
                return this.gridTheoNgay;
            }
            else if (radTheoCa.Checked)
            {
                return this.gridTheoCa;
            }
            else if (radTheoGio.Checked)
            {
                return this.gridTheoGio;
            }
            return null;
        }

        private string GetFileNameExport(DateTime TuNgay, DateTime DenNgay)
        {
            string strFilename = "";
            if (radTheoNgay.Checked)
            {
                strFilename = "BC_3_1_KetQuaDieuHanhTheoNgay_" + string.Format("{0:dd_MM}_{1:dd_MM_yyyy}", TuNgay, DenNgay) + ".xls"; 
            }
            else if (radTheoCa.Checked)
            {
                strFilename = "BC_3_1_KetQuaDieuHanhTheoCa_" + string.Format("{0:dd_MM_yyyy}", TuNgay ) + ".xls";
            }
            else if (radTheoGio.Checked)
            {
                strFilename = "BC_3_1_KetQuaDieuHanhTheoGio_" + string.Format("{0:dd_MM_yyyy}", TuNgay) + ".xls";
            }

            return strFilename;
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
        private void radTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            lblDenNgay .Visible =  radTheoNgay.Checked;
            calDenNgay.Visible =  radTheoNgay.Checked;
            gridTheoNgay.Visible =  radTheoNgay.Checked;
            gridTheoGio.Visible = !radTheoNgay.Checked;
            gridTheoCa.Visible = !radTheoNgay.Checked;

            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void radTheoGio_CheckedChanged(object sender, EventArgs e)
        {
            lblDenNgay.Visible = !radTheoGio.Checked;
            calDenNgay.Visible = !radTheoGio.Checked;
            gridTheoNgay.Visible = !radTheoGio.Checked;
            gridTheoGio.Visible =  radTheoGio.Checked;
            gridTheoCa.Visible = !radTheoGio.Checked;

            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            
        }

        private void radTheoCa_CheckedChanged(object sender, EventArgs e)
        {
            lblDenNgay.Visible = !radTheoCa.Checked;
            calDenNgay.Visible = !radTheoCa.Checked;
            gridTheoNgay.Visible = !radTheoCa.Checked;
            gridTheoGio.Visible = !radTheoCa.Checked;
            gridTheoCa.Visible = radTheoCa.Checked;
 
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        

       
    }
}