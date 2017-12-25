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
    public partial class frmBC_1_2_TongHopCuocGoiDenTheoCa : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        DataTable danhSachBinhQuan = new DataTable();
        public frmBC_1_2_TongHopCuocGoiDenTheoCa()
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
                DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
                try
                {
                    dateGioDauCa = Convert.ToDateTime(dt.Rows[0]["DauCa1"].ToString());
                }
                catch
                {
                    dateGioDauCa = new DateTime(1900, 1, 1, 6, 0, 0);
                }
                DateTime TuNgay = new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, dateGioDauCa.Hour, 0, 0);
                DateTime DenNgay = calDenNgay.Value;
                DenNgay = DenNgay.AddDays(1);
                DenNgay = new DateTime(DenNgay.Year, DenNgay.Month, DenNgay.Day, dateGioDauCa.Hour - 1, 59, 59);
                lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);
                LoadData(TuNgay, DenNgay);

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }
            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay)
        {
            string id = string.Empty;
             g_dt = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoCa(TuNgay, DenNgay, ref id);
             griTongCuocGoiDen.DataMember = "ListDienThoai";
             griTongCuocGoiDen.SetDataBinding(g_dt, "ListDienThoai");
             // Su dung ID de lay phan binh quan voi id nay
            //danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGioBinhQuan(id);
            //gridBinhQuan.DataMember = "ListBQ";
            //gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }
        
       
      
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {            
           saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_1_2_TongHopGoiDenCa", calTuNgay.Value, calDenNgay.Value, false);
           if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
               gridEX1.DataMember = "list1";
               gridEX1.SetDataBinding(g_dt, "list1");
               gridEXExporter1.GridEX = gridEX1; 
               gridEXExporter1.Export((Stream)objFile);
               objFile.Close();
               string Directory = new FileInfo(saveFileDialog1.FileName).DirectoryName;
               // Tao binh quan
               //saveFileDialog1.FileName =Directory + "\\" + FileTools.GetFilenameReport("BC_1_2_TongHopGoiCaBinhQuan", calTuNgay.Value, calDenNgay.Value,false);
               //objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
               //gridEX2.DataMember = "listBinhQuan";
               //gridEX2.SetDataBinding(danhSachBinhQuan, "listBinhQuan");
               //gridEXExporter1.GridEX = gridEX2;
               //gridEXExporter1.Export((Stream)objFile);
               //if (new MessageBox.MessageBox().Show(this, "Tạo 2 file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
               // {
               //     FileTools.OpenDirectory(new FileInfo(saveFileDialog1.FileName).DirectoryName);  
               // }               
               // objFile.Close();               
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

        private void griTongCuocGoiDen_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.GroupFooter)
            {
                try
                {
                    double donDuoc = Convert.ToDouble(e.Row.Cells["TongDonDuoc"].Value.ToString());
                    double cuocTaxi = Convert.ToDouble(e.Row.Cells["TongTaxi"].Value.ToString());
                    if (cuocTaxi > 0)
                    {
                        e.Row.Cells["PhanTramDonDuoc"].Text = string.Format("{0:#.#}", Convert.ToDouble(donDuoc / cuocTaxi * 100));
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        

        

       
    }
}