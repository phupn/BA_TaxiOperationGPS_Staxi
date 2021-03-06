using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Taxi.Business.ThongTinPhanAnh;

namespace TaxiOperation_TongDai.BaoCaoPhanAnh
{
    public partial class BaoCaoTongHopPhanAnh : Form
    {
        public BaoCaoTongHopPhanAnh()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
            grdTongHop.DataMember = "tblTongHop";
            grdTongHop.DataSource = objPhanAnh.GetReport(calTuNgay.Value, calDenNgay.Value);
            btnExportExcel.Enabled = true;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_TongHop_PhanAnh.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                MessageBox.Show("Tạo file Excel thành công.", "Thông báo");
            }
        }
    }
}