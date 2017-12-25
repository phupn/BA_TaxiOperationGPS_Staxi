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
    public partial class frmBC_1_7_BaoCaoChiTietThoatCuoc999 : Form
    {
        private const int MAX_DATES = 100;
        DataTable g_dt = new DataTable();
        DataTable danhSachBinhQuan = new DataTable();
        public frmBC_1_7_BaoCaoChiTietThoatCuoc999()
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
            LoadComBobox();
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
                string TuNgays = TuNgay.ToString();
                string DenNgays = DenNgay.ToString();
                string TruongCa = String.Empty;
                string NhanVien = String.Empty;
                TruongCa = cboTruongCa.SelectedValue.ToString();
                NhanVien = cboNhanVien.SelectedValue.ToString();

                LoadData(TuNgays, DenNgays,TruongCa,NhanVien);

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            
        }
        
        private void LoadData(string TuNgay, string DenNgay,string TruongCa,string NVMK)
        {
            string id = string.Empty;
            danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_1_7_BaoCaoChiTietKhachThoat999(TuNgay, DenNgay, TruongCa, NVMK);
            if ((danhSachBinhQuan != null) && (danhSachBinhQuan.Rows.Count > 0))
            {
                danhSachBinhQuan.BeginInit();
                danhSachBinhQuan.Columns.Add(new DataColumn("ChenhLechThoiGian",typeof(string)));
                danhSachBinhQuan.EndInit();
                foreach (DataRow dr in danhSachBinhQuan.Rows)
                {
                    int SoGiay = dr["ThoiGianDonKhaCh"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ThoiGianDonKhach"]);
                    dr["ChenhLechThoiGian"] = StringTools.ConvertSoGiay_PhutGiay(SoGiay);
                }
                gridBinhQuan.DataMember = "ListBQ";
                gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
                btnRefresh.Enabled = false;
                btnExportExcel.Enabled = !btnRefresh.Enabled;
            }
            else
            {
                btnRefresh.Enabled = true;
                gridBinhQuan.DataSource = null;
                gridBinhQuan.SetDataBinding(null, "KhongDuLieu");
                btnExportExcel.Enabled = !btnRefresh.Enabled;
            }
        }
        
       
      
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {   
               // Tao binh quan
            saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_8_2_ChiTietKhachHangThuongXuyen", calTuNgay.Value, calDenNgay.Value, false);
            FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);            
            objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
            gridEX2.DataMember = "listBinhQuan";
            gridEX2.SetDataBinding(danhSachBinhQuan, "listBinhQuan");
            gridEXExporter1.GridEX = gridEX2;
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

        public void LoadComBobox()
        { 
            // Lây danh sách trưởng ca
            DataTable tbTruongCa = new TimKiem_BaoCao().GetDanhSach_NguoiDung("TC");
            DataRow drInit = tbTruongCa.NewRow();
            drInit["FULLNAME"] = "Chọn";
            drInit["UserID"] = DBNull.Value;

            tbTruongCa.Rows.InsertAt(drInit, 0);
            cboTruongCa.DisplayMember = "FULLNAME";
            cboTruongCa.ValueMember = "UserID";
            cboTruongCa.DataSource = tbTruongCa;
            // Lây danh sách nhân viên mơi khách
            DataTable tbNVMK = new TimKiem_BaoCao().GetDanhSach_NguoiDung("NVCAMON");
            DataRow drInitNV = tbNVMK.NewRow();
            drInitNV["FULLNAME"] = "Chọn";
            drInitNV["UserID"] = DBNull.Value;

            tbNVMK.Rows.InsertAt(drInitNV, 0);
            cboNhanVien.DisplayMember = "FULLNAME";
            cboNhanVien.ValueMember = "UserID";
            cboNhanVien.DataSource = tbNVMK;

           
           
        }

        private void cboTruongCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        

        

       
    }
}