using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;

namespace Taxi.GUI 
{
    public partial class frmBC_8_2_ChiTietCuocGoiDenTheoNgay : Form
    {
        private DataTable danhSachBinhQuan = new DataTable();
        public frmBC_8_2_ChiTietCuocGoiDenTheoNgay()
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
                string SoDienThoai = txtSoDienThoai.Text;
                LoadData(TuNgay, DenNgay,SoDienThoai);
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }
            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay,string SoDienThoai)
        {            
            danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_8_2_BaoCaoChiTietCuocGoiDenTheoNgay(TuNgay,DenNgay,SoDienThoai);
            gridBinhQuan.DataMember = "ListBQ";
            gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_8_2_ChiTietKhachHangThuongXuyen", calTuNgay.Value, calDenNgay.Value, false);
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEX2.DataMember = "listBinhQuan";
                gridEX2.SetDataBinding(danhSachBinhQuan, "listBinhQuan");
                gridEXExporter1.GridEX = gridEX2;
                gridEXExporter1.Export(objFile);
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    FileTools.OpenDirectory(new FileInfo(saveFileDialog1.FileName).DirectoryName);
                }
                objFile.Close();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(" btnExportExcel_Click: ", ex);
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

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
    }
}