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
using Taxi.Utils;

namespace Taxi.GUI 
{
    public partial class frmBC_GPS_2_BCCuocGoiCoCanhBao : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        DataTable danhSachBinhQuan = new DataTable();
        public frmBC_GPS_2_BCCuocGoiCoCanhBao()
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
                KieuCanhBaoKhiNhapThongTin? kieuCanhBao = null;

                if (chk_Loai1.Checked)
                    kieuCanhBao = KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan;
                else if (chk_Loai2.Checked)
                    kieuCanhBao = KieuCanhBaoKhiNhapThongTin.XeNhanQuaXa;
                else if (chk_Loai3.Checked)
                    kieuCanhBao = KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon;
                else if (chk_Loai4.Checked)
                    kieuCanhBao = KieuCanhBaoKhiNhapThongTin.TrungXeDon;

                DateTime TuNgay = calTuNgay.Value;
                DateTime DenNgay = calDenNgay.Value;

                LoadData(TuNgay, DenNgay, kieuCanhBao);
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }            
        }

        private void LoadData(DateTime TuNgay, DateTime DenNgay, KieuCanhBaoKhiNhapThongTin? kieuCanhBao)
        {
            string Vung = txtVung.Text.Trim() ;
            string MaNhanVien = txtMaNV.Text.Trim();
            danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_GPS_2_BCCuocKhachGPS_CoCanhBao(TuNgay, DenNgay, Vung, MaNhanVien, kieuCanhBao);
            gridBinhQuan.DataMember = "ListBQ";
            gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {   
               // Tao binh quan
            saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_GPS_2_CuocKhachDieuHanhGPS_CoBaoCao", calTuNgay.Value, calDenNgay.Value, false);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    gridEXExporter1.Export((Stream)objFile);
                }
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
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

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
             
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chk_Loai1_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chk_Loai3_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chk_Loai2_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chk_Loai4_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        

        

       
    }
}