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
    public partial class frmBCNhatKyThueBao : Form
    {
      
        public frmBCNhatKyThueBao()
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



                string strSQL = string.Empty;
                  string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calTuNgay.Value);
                string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calDenNgay.Value);

                strSQL  = " SELECT  *  FROM [TRUNGKIEN.T_NHATKYTHUEBAO]  WHERE  ((ThoiDiem >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiem <= cast('" + strDenNgay + "' as datetime)))  order by  [ThoiDiem] ASC ";



                DataTable dt = Taxi.Business.BanGiaGoc.NhatkyThuebao.GetBCNhatKyThueBao(strSQL);
             
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(dt, "lstCuocGoiKetThuc");
                btnRefresh.Enabled = false;
               
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
             
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCaoNhatKyThueBao.xls";
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
           
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
            
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        
    }
}