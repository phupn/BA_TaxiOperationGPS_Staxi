﻿using System;
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
                DateTime dateGioDauCa;
                // lay gio cua ca

                DateTime TuNgay = calTuNgay.Value;
                    //new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, calTuNgay.Value.Hour, calTuNgay.Value.Minute, calTuNgay.Value.Millisecond);
                DateTime DenNgay = calDenNgay.Value;
              //  DenNgay = DenNgay.AddDays(1);
                //DenNgay = new DateTime(DenNgay.Year, DenNgay.Month, DenNgay.Day, DenNgay.Hour, DenNgay.Minute, DenNgay.Millisecond);
               // lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);
                byte Vung = 0;
                byte.TryParse(txtVung.Text,out Vung);
             
                LoadData(TuNgay, DenNgay,Vung);

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay,byte Vung)
        {
            string id = string.Empty;
            danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_1_6_BaoCaoTongCuocKhachThoat999(TuNgay, DenNgay, Vung);
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

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
             
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