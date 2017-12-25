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

namespace Taxi.GUI.BaoCao
{
    public partial class frmBC_1_3_ChiTietCuocGoiDen_LogVung : Form
    {
        public const string KYTU_GOIDEN = "A";
        public const string KYTU_GOIDI = "B";

        List<BaoCaoBieuMau3> g_lstBaoCaoBieuMau3;
        private fmProgress m_fmProgress = null;
        public frmBC_1_3_ChiTietCuocGoiDen_LogVung()
        {
            InitializeComponent();
          
        }

        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;           
            btnExportExcel.Enabled = btnRefresh.Enabled;
           
        }

        
        

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                List<BaoCaoLogVung> lstLogVung = TimKiem_BaoCao.GetBaoCaoLogChuyenVung(calTuNgay.Value, calDenNgay.Value);

                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(lstLogVung, "lstCuocGoiKetThuc"); 
                btnRefresh.Enabled = false; 
                btnExportExcel.Enabled = !btnRefresh.Enabled;;

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }

          
     

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau3.xls";
            saveFileDialog1.FileName = FilenameDefault;
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
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;;
        }

        private void gridDienThoai_DoubleClick(object sender, EventArgs e)
        {
            // lay ID của cuốc và chuyền sang dialog đề xem chi tiết các lần chuyển vùng.
            gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDienThoai.SelectedItems.Count > 0)
            {
                BaoCaoLogVung objLogVung = (BaoCaoLogVung)((GridEXSelectedItem)gridDienThoai.SelectedItems[0]).GetRow().DataRow; 
                new frmBC_1_3_ChiTietCuocGoiDen_LogVungChiTietCuoc(objLogVung.ID_DieuHanh).ShowDialog();
            }
        }
    }
}