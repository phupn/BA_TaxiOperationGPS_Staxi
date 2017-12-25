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
using System.Security.AccessControl;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBC_6_4_TongHopMoiGioiGoiQuaTT : Form
    {
        //private List<DieuHanhTaxi> g_lstCuocGoiKetThuc;
        private DataTable g_dtDuLieuTongHop;
        private DataTable g_dtDuLieuDonVi;
        public frmBC_6_4_TongHopMoiGioiGoiQuaTT()
        {
            InitializeComponent();
        }

        private void frm_5_7_BCTongHopMoiGioiGoiQuaTT_Load(object sender, EventArgs e)
        {
            btnExportExcel.Enabled = btnRefresh.Enabled;
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            btnPrint.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            btnPrint.Enabled = !btnRefresh.Enabled;

        }        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                //------------------------------------------------------------------
                // Congnt sua them lay ngay theo ca
                //------------------------------------------------------------------
                DateTime dateGioDauCa;
                // lay gio cua ca
                DataTable dtCa = ThongTinCauHinh.GetThongTinCa(1);
                try
                {
                    dateGioDauCa = Convert.ToDateTime(dtCa.Rows[0]["DauCa1"].ToString());
                }
                catch (Exception ex)
                {
                    dateGioDauCa = new DateTime(1900, 1, 1, 6, 0, 0);
                }
                DateTime TuNgay = new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, dateGioDauCa.Hour, 0, 0);
                DateTime DenNgay = calDenNgay.Value;
                DenNgay = DenNgay.AddDays(1);
                DenNgay = new DateTime(DenNgay.Year, DenNgay.Month, DenNgay.Day, dateGioDauCa.Hour - 1, 59, 59);
                lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);


                DataTable dt = (new BangKe()).BCTHMoiGioi_TT(TuNgay,DenNgay);

                g_dtDuLieuTongHop = new DataTable();
                g_dtDuLieuTongHop = dt.Clone();

                DataRow[] rows = dt.Select("rptGroup = 0");
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        g_dtDuLieuTongHop.ImportRow(row);
                    }
                }
                g_dtDuLieuDonVi = new DataTable();
                g_dtDuLieuDonVi = dt.Clone();
                DataRow[] rows2 = dt.Select("rptGroup = 1");
                if (rows2.Length > 0)
                {
                    foreach (DataRow row in rows2)
                    {
                        g_dtDuLieuDonVi.ImportRow(row);
                    }
                }

                gridDienThoai.DataMember = "tblTongHop";
                gridDienThoai.SetDataBinding(g_dtDuLieuTongHop, "tblTongHop");

                gridEX1.DataMember = "tblDonVi";
                gridEX1.SetDataBinding(g_dtDuLieuDonVi, "tblDonVi");
                SetUnActiveRefreshButton();
            }
            else
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmInBaoCao frmPrint = new frmInBaoCao();
            //frmPrint.InBaoCao_6_4_TongHopMoiGioiGoiQuaTrungTam(Configuration.GetReportPath() + "\\BieuMauBaoCao64.rpt",g_dtDuLieuTongHop,g_dtDuLieuDonVi, calTuNgay.Value, calDenNgay.Value );
            //frmPrint .ShowDialog();
            
        }  

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_THopMGioiQuaTrungTam_TH";
            string FilenameDefault2 = "BaoCao_THopMGioiQuaTrungTam_DV";
            DateTime frmDate = calTuNgay.Value;
            DateTime toDate = calDenNgay.Value;
            string rptDate = String.Format("{0}{1}{2}-{3}{4}{5}", frmDate.Year, frmDate.Month, frmDate.Day, toDate.Year, toDate.Month, toDate.Day);
            saveFileDialog1.FileName = String.Format("{0}_{1}.xls", FilenameDefault ,rptDate);
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                FileStream objFile = new FileStream(fileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);

                string fileName2 = String.Format("{0}{1}_{2}.xls", fileName.Substring(0, fileName.Length - FilenameDefault.Length),FilenameDefault2, rptDate);               
                FileStream objFile2 = new FileStream(fileName2, FileMode.Create);                
                gridEXExporter2.Export((Stream)objFile2);

                if (new MessageBox.MessageBox().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(fileName2);
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

             
        
    }
}