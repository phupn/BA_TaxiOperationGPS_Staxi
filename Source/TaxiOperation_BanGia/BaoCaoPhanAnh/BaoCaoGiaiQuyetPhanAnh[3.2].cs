using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.ThongTinPhanAnh;
using System.IO;

namespace TaxiOperation_TongDai.BaoCaoPhanAnh
{
    public partial class BaoCaoGiaiQuyetPhanAnh_3 : Form
    {
        public List<ThongTinPhanAnh> _listThongTinPA = new List<ThongTinPhanAnh>();
        public BaoCaoGiaiQuyetPhanAnh_3()
        {
            InitializeComponent();
        }             

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
            _listThongTinPA = objPhanAnh.JoinByDate(calTuNgay.Value, calDenNgay.Value);
            grdBaoCaoGiaiQuyet.DataMember = "lstThongTinPA";
            grdBaoCaoGiaiQuyet.SetDataBinding(_listThongTinPA, "lstThongTinPA");
            btnExportExcel.Enabled  = true;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_GiaiQuyet_PhanAnh.xls";
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