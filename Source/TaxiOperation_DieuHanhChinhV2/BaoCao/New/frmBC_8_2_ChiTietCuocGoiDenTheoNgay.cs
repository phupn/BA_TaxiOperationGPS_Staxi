using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.MessageBox;
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
                DateTime tuNgay = calTuNgay.Value;                    
                DateTime denNgay = calDenNgay.Value;              
                string doDienThoai = txtSoDienThoai.Text;
                LoadData(tuNgay, denNgay,doDienThoai);
            }
            else
            {
                MessageBoxBA msgDialog = new MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);                
            }
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay,string SoDienThoai)
        {
            try
            {
                danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_8_2_BaoCaoChiTietCuocGoiDenTheoNgay(TuNgay, DenNgay, SoDienThoai);
                gridBinhQuan.DataMember = "ListBQ";
                gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
                btnRefresh.Enabled = false;
                btnExportExcel.Enabled = !btnRefresh.Enabled;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadData: ", ex);                
            }    
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_8_2_ChiTietKhachHangThuongXuyen", calTuNgay.Value, calDenNgay.Value, false);

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                    {
                        gridBinhQuan.DataMember = "listBinhQuan";
                        gridBinhQuan.SetDataBinding(danhSachBinhQuan, "listBinhQuan");
                        gridEXExporter1.GridEX = gridBinhQuan;
                        gridEXExporter1.Export(objFile);
                        if (new MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBoxButtonsBA.YesNoCancel, MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                        {
                            FileTools.OpenDirectory(new FileInfo(saveFileDialog1.FileName).DirectoryName);
                        }
                        objFile.Close();                        
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnExportExcel_Click: ", ex);                
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