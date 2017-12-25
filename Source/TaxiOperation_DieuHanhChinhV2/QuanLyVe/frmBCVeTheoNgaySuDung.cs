using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanLyVe;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;

namespace Taxi.GUI
{
    public partial class frmBCVeTheoNgaySuDung : Form
    {
        public frmBCVeTheoNgaySuDung()
        {
            InitializeComponent();
        }
        private void frmVePhatHanh_Load(object sender, EventArgs e)
        {
            btnThemMoi.Enabled = true;
            btnXuatExcel.Enabled = false;
            
            
        }
        
         
       
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
             
               
                LoadDSVeSuDungTheoNgay( calTuNgay.Value, calDenNgay.Value);
                btnThemMoi.Enabled = false;
                btnXuatExcel.Enabled = true;

          
        }
     

        private void LoadDSVeSuDungTheoNgay(  DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt=Ve.GetDSVeDaSuDungTheoNgay( TuNgay, DenNgay);
            grdVeSuDung.DataMember = "ListVeSuDung";
            grdVeSuDung  .SetDataBinding(dt, "ListVeSuDung");
        }

         
         
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "DanhMucVePhatHanh.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                objFile.Close();
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnThemMoi.Enabled = true;
        }

        private void calDenNgay_Validated(object sender, EventArgs e)
        {

        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnThemMoi.Enabled = true;
        }

        

       

      

              
    }
}