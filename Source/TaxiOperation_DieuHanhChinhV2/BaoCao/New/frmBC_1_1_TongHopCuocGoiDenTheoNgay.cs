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

namespace Taxi.GUI 
{
    public partial class frmBC_1_1_TongHopCuocGoiDenTheoNgay : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        DataTable danhSachBinhQuan = new DataTable();
        public frmBC_1_1_TongHopCuocGoiDenTheoNgay()
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
                //DateTime dateGioDauCa;
                //// lay gio cua ca
                //DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
                //try
                //{
                //    dateGioDauCa = Convert.ToDateTime(dt.Rows[0]["DauCa1"].ToString());
                //}
                //catch (Exception ex)
                //{
                //    dateGioDauCa = new DateTime(1900, 1, 1, 6, 0, 0);
                //}
                //DateTime TuNgay = new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, dateGioDauCa.Hour, 0, 0);
                //DateTime DenNgay = calDenNgay.Value;
                //DenNgay = DenNgay.AddDays(1);
                //DenNgay = new DateTime(DenNgay.Year, DenNgay.Month, DenNgay.Day, dateGioDauCa.Hour - 1, 59, 59);
                //lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);
                LoadData(calTuNgay.Value, calDenNgay.Value);

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay)
        {
            string id = string.Empty;
             g_dt = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgay(TuNgay, DenNgay, ref id);
             if (g_dt != null)
             {
                 griTongCuocGoiDen.DataMember = "ListDienThoai";
                 griTongCuocGoiDen.SetDataBinding(g_dt, "ListDienThoai");


                 gridEX1.DataMember = "ListDienThoai";
                 gridEX1.SetDataBinding(g_dt, "ListDienThoai");

                 // Su dung ID de lay phan binh quan voi id nay
                //danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGioBinhQuan(id);
                //gridBinhQuan.DataMember = "ListBQ";
                //gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
                btnRefresh.Enabled = false;            
                btnExportExcel .Enabled = !btnRefresh.Enabled;
             }           
        }      
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "Excel Workbook (*.xls)|*.xls|All files (*.*)|*.*";
           saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_1_1_TongHopGoiDenNgay", calTuNgay.Value, calDenNgay.Value, false);
           if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);

                gridEXExporter1.Export((Stream)objFile);
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
        

        

       
    }
}