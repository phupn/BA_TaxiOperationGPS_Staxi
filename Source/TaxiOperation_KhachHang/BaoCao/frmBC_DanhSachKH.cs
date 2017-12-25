using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace Taxi.GUI 
{
    public partial class frmBC_DanhSachKH : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        DataTable danhSachBinhQuan = new DataTable();
        private List<DanhBaKhachQuen_Type> G_lstKhachQuen_Type;
        public frmBC_DanhSachKH()
        {
            InitializeComponent();
        }

        public frmBC_DanhSachKH(List<DanhBaKhachQuen_Type> lstKhachQuen_Type)
        {
            InitializeComponent();
            G_lstKhachQuen_Type = lstKhachQuen_Type;
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
            LoadCB_Type();
        }

        private void LoadCB_Type()
        {
            cbLoaiKH.DisplayMember = "Type";
            cbLoaiKH.ValueMember = "ID";
            cbLoaiKH.DataSource = G_lstKhachQuen_Type;
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
              
                LoadData(TuNgay, DenNgay);
            }
            else
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                return;
            }            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay)
        {
            int loaiKH = (int)cbLoaiKH.SelectedValue;
            danhSachBinhQuan = new TimKiem_BaoCao().GetData_BCDSKHThanThiet(TuNgay, DenNgay, loaiKH);
            gridBinhQuan.DataMember = "ListBQ";
            gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {   
               // Tao binh quan
            saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_DanhSach_KHThanThiet", calTuNgay.Value, calDenNgay.Value, false);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    gridEXExporter1.Export((Stream)objFile);
                }
                if (new MessageBox.MessageBox().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
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

        private void cbLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}