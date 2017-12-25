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
using Taxi.Data.BaoCaoNew;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace Taxi.GUI 
{
    public partial class frmBC_1_6_BaoCaoTongHopThoatCuoc999 : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        DataTable danhSachBinhQuan = new DataTable();
        public frmBC_1_6_BaoCaoTongHopThoatCuoc999()
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
        }
 
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                DateTime TuNgay = calTuNgay.Value;                    
                DateTime DenNgay = calDenNgay.Value;               
                byte Vung;
                byte.TryParse(txtVung.Text,out Vung);
                LoadData(TuNgay, DenNgay,Vung);
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay,byte Vung)
        {
            danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999_V2(TuNgay, DenNgay, Vung);
            //danhSachBinhQuan = new BC_PhanMemDieuHanh().BC_1_6_BaoCaoTongCuocKhachThoat999(TuNgay, DenNgay, Vung);
            gridBinhQuan.DataMember = "ListBQ";
            gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {   
            // Tao binh quan
            saveFileDialog1.FileName = FileTools.GetFilenameReport("BaoCaoTongCuocKhachThoat999", calTuNgay.Value, calDenNgay.Value, false);
            FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);            
 
            gridEXExporter1.GridEX = gridBinhQuan;
            gridEXExporter1.Export((Stream)objFile);
            if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
            {
                FileTools.OpenDirectory(new FileInfo(saveFileDialog1.FileName).DirectoryName);  
            }               
            objFile.Close();               
            
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

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtVung_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
        }
    }
}