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
    public partial class frm_3_2_BCKetQuaDieuHanhTheoDVi : Form
    {
      
        public frm_3_2_BCKetQuaDieuHanhTheoDVi()
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
                string sVung = StringTools.TrimSpace(editVung.Text);
                gridEX1.DataMember = "ListDienThoai";
                gridEX1.SetDataBinding(TimKiem_BaoCao.GROUP_BC_3_1_BaoCaoDieuHanhTheoDonVi(calTuNgay.Value, calDenNgay.Value, sVung), "ListDienThoai");
                btnExportExcel.Enabled = true;
                btnRefresh.Enabled = false;
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
            string FilenameDefault = "BC3_2_KetQuaDieuHanhTheoDonVi.xls";
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
            btnExportExcel.Enabled = false ;
            btnRefresh.Enabled = true ;
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;            
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;           
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
 
       
        private void editVung_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
    }
}