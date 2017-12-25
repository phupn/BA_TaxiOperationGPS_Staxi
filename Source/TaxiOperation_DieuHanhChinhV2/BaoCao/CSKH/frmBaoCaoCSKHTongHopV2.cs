using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;


namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoCSKHTongHopV2 : Form
    {
        private DataTable g_DuLieu;
        public frmBaoCaoCSKHTongHopV2()
        {
            InitializeComponent();
        }

        private void frmBaoCaoCSKHTongHopV2_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnExportExcel.Enabled = false;

            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();
            calTuNgay.Value = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);
            calDenNgay.Value = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0); 
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                string sVung = "";
                int SoLanKhachGoiLai = 0;
                sVung = StringTools.TrimSpace(txtVung.Text);
                string idCSKH = StringTools.TrimSpace(txtIDCS.Text);
                int.TryParse(txtSoLanGoi.Text, out SoLanKhachGoiLai);

                int loaiSoDienThoai = 9;
                if (radMoiGioi.Checked)
                    loaiSoDienThoai = 1;
                else if (radVangLaiDiDong.Checked)
                    loaiSoDienThoai = 2;
                else if (radVLCD.Checked)
                    loaiSoDienThoai = 3;
                else loaiSoDienThoai = 0;

                g_DuLieu = TimKiem_BaoCao.CSKH_BaoCaoTongHop(calTuNgay.Value, calDenNgay.Value, sVung, SoLanKhachGoiLai, idCSKH, loaiSoDienThoai);
                shGridControl.DataSource = g_DuLieu;
                SetUnActiveRefreshButton();
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }
        }


        private void ExportExcelGridDev()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                string FilenameDefault = string.Format("BaoCaoCSKHTongHop");
                saveDialog.FileName = FilenameDefault + ".xls";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            shGridControl.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            shGridControl.ExportToXlsx(exportFilePath);
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
            try
            {
                ExportExcelGridDev();
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi tạo file Excel.", "Thông báo");
            }
        }
        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtSoLanGoi_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radMoiGioi_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radVangLaiDiDong_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radVLCD_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtVung_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        //private void shGridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    try
        //    {
        //        e.Info.Appearance.Font = new Font(e.Info.Appearance.Font.FontFamily, e.Info.Appearance.Font.Size);
        //        e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
        //        e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
        //        // Hiển thị số thứ tự

        //        if (e.Info.IsRowIndicator && e.RowHandle >= 0)
        //        {
        //            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        //        }
        //        else if (!e.Info.IsRowIndicator && e.RowHandle < 0 && e.Info.IsTopMost)
        //        {
        //            e.Info.DisplayText = "STT";
        //        }
        //    }
        //    catch 
        //    {
                
        //    }
        //}
    }
}
