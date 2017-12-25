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

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoBieuMau4 : Form
    {
        private List<DieuHanhTaxi> g_lstCuocGoiKetThuc;
        public frmBaoCaoBieuMau4()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = btnRefresh.Enabled;
            btnExportExcel.Enabled = btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {


            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                g_lstCuocGoiKetThuc = new List<DieuHanhTaxi>();

                  string SQLCondition = string.Empty;
                  string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calTuNgay.Value);
                string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calDenNgay.Value);

                SQLCondition = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
                // Cuoi goi nho
                SQLCondition += " AND (GhiChuDienThoai LIKE N'%nhỡ%') ";
                string NRecords = "";
                
                g_lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);
             
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(g_lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
                btnRefresh.Enabled = false;
                btnPrint.Enabled = !btnRefresh.Enabled;
                btnExportExcel.Enabled = !btnRefresh.Enabled;
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (g_lstCuocGoiKetThuc != null)
            {
                if (g_lstCuocGoiKetThuc.Count > 0)
                {
                    //frmInBaoCao frmPrint= new frmInBaoCao();
                    //frmPrint.InBaoCaoBieuMau4(Configuration.GetReportPath() + "\\Baocao_Bieumau4.rpt", g_lstCuocGoiKetThuc, calTuNgay.Value, calDenNgay.Value);
                    //frmPrint.ShowDialog(this);
                }
                else
                {
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                    msgDialog.Show(this, "Không có dữ liệu để tạo báo cáo", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau4.xls";
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