using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using System.Diagnostics;

namespace Taxi.GUI 
{
    /// <summary>
    /// Báo cáo 4.6 mới sử dụng lưới DEV để báo cáo và kết xuất Excel!
    /// </summary>
    public partial class frmBC_4_6_KQDieuHanhNVTheoNgay_V2 : Form
    {
        private DataTable g_dtNVDienThoai;

        public frmBC_4_6_KQDieuHanhNVTheoNgay_V2()
        {
            InitializeComponent();          
        }        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNhanVien();
                btnTimKiem.Enabled = false;
                btnXuatExcel.Enabled = btnTimKiem.Enabled;
                calTuNgay.EditValue = CommonBL.GetTimeServer();
                calDenNgay.EditValue = CommonBL.GetTimeServer().AddHours(12);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmBaoCaoBieuMau3_Load: ", ex);                
            }   

        }

        private void LoadNhanVien()
        {
            try
            {
                cboNhanVien.Properties.ValueMember = "USER_ID";
                cboNhanVien.Properties.DisplayMember = "FULLNAME";
                DataTable dt = new Users().GetAllUserInfo();
                cboNhanVien.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadNhanVien: ", ex);                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.DateTime, calDenNgay.DateTime))
                {

                    string NhanVienID = "";
                    if (cboNhanVien.EditValue!=null && !string.IsNullOrEmpty(cboNhanVien.Text))
                    {
                        NhanVienID = cboNhanVien.EditValue.ToString();
                        if (NhanVienID == "000") NhanVienID = "";
                    }
                    if (NhanVienID.Length > 0)
                    {
                        g_dtNVDienThoai = new TimKiem_BaoCao().GROUP_BC4_6_KetQuaDieuHanhNVTheoNgay(calTuNgay.DateTime, calDenNgay.DateTime, NhanVienID);
                        shGridControl1.DataSource = g_dtNVDienThoai;
                        btnXuatExcel.Enabled = true;
                    }
                    else
                    {
                        MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Bạn phải chọn nhân viên để báo cáo.", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);

                    }
                }
                else
                {
                    MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                    msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                }
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Lỗi khi lấy dữ liệu","Lỗi");
            }
        }

        private void ExportExcelGridDev()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                string FilenameDefault = string.Format("BC_4_6_BaoCaoKQNhanVienDieuHanh_" + cboNhanVien.Text + "_{0}", DateTime.Now.ToString("ddMMyyyy_HH_mm"));
                saveDialog.FileName = FilenameDefault + ".xls";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            shGridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            shGridControl1.ExportToXlsx(exportFilePath);
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                            {
                                Process.Start(exportFilePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("btnExportExcel_Click", ex);
                        }
                    }
                }
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcelGridDev();
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnTimKiem.Enabled = true ;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnXuatExcel.Enabled = !btnTimKiem.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnTimKiem.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnXuatExcel.Enabled = !btnTimKiem.Enabled;
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTimKiem.Enabled = true;
            //   btnPrint.Enabled = !btnRefresh.Enabled;
            btnXuatExcel.Enabled = !btnTimKiem.Enabled;
        }
    }
}