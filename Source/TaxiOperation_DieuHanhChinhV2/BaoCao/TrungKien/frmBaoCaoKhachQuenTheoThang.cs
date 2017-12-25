using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Taxi.Business;
using System.IO;
using Taxi.Common.Extender;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoKhachQuenTheoThang : Form
    {
        #region Properties & Constructor

        private fmProgress m_fmProgress = null;
        private bool g_bChuaCoDuLieu = true;
        private bool g_bThayDoiChonNam = false;
        private int g_Nam = 0;
        private int gIsMoiGioi = 0;
        private BackgroundWorker g_BackGroundWorker = new BackgroundWorker();
        public frmBaoCaoKhachQuenTheoThang()
        {
            InitializeComponent();
        }

        #endregion

        #region Method
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;

            btnExportExcel.Enabled = false;
            gIsMoiGioi = inputRadioGroup.EditValue.To<int>();
            KhoiTaoDuLieu();
        }
        private void KhoiTaoDuLieu()
        {
            try
            {
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                intUDDenThang.Value = timeServer.Month;
                int startYear = 2008;
                for (int i = startYear; i <= timeServer.Year; i++)
                {
                    ddlNam.Items.Add(i);
                }
                int index = ddlNam.Items.IndexOf(timeServer.Year);
                ddlNam.SelectedIndex = index;
                g_BackGroundWorker.DoWork += bw_DoWork;
                g_BackGroundWorker.RunWorkerCompleted += bw_RunWorkerCompleted;
            }
            catch (Exception ex )
            {
                LogError.WriteLogError("KhoiTaoDuLieu: ", ex);
            }
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
        private bool ValidateInput()
        {
            if (intUDTuThang.Value <= 0 || intUDTuThang.Value > 12 || (intUDDenThang.Value <= 0) || (intUDDenThang.Value > 12))
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập tháng trong khoảng [1..12].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                return false;
            }

            if (intUDTuThang.Value > intUDDenThang.Value)
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ tháng] nhỏ hơn hoặc bằng [Đến tháng].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                return false;
            }
            if (ddlNam.Text.Length < 4)
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập phải nhập dữ liệu năm.", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                return false;
            }
            g_Nam = int.Parse(ddlNam.Text);
            return true;
        }
        private void HideCotCuaGrid(int TuThang, int DenThang, ref GridEX pGridCuocGoiMGThang)
        {
            for (int i = 1; i <= 12; i++)
            {
                pGridCuocGoiMGThang.RootTable.Columns[i + 4].Visible = false;
            }
            for (int i = TuThang; i <= DenThang; i++)
            {
                pGridCuocGoiMGThang.RootTable.Columns[i + 4].Visible = true;
            }
        }

        #endregion

        #region Events!
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                DateTime tuNgay = new DateTime(g_Nam, intUDTuThang.Value, 1, 0, 0, 0);
                DateTime denNgay = new DateTime(g_Nam, intUDDenThang.Value, DateTime.DaysInMonth(g_Nam, intUDDenThang.Value),23,59,59);
                if (intUDDenThang.Value >= 12)
                    denNgay = new DateTime(g_Nam + 1, 1, 1, 0, 0, 0);

                DataTable data = TimKiem_BaoCao.BaoCaoKhachHangThanThietTheoThang_V2(tuNgay, denNgay, txtSoDienThoai.Text.Trim(), txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), gIsMoiGioi);
                gridCuocGoiMGThang.DataMember = "ListDienThoai";
                gridCuocGoiMGThang.SetDataBinding(data, "ListDienThoai");
                HideCotCuaGrid(intUDTuThang.Value, intUDDenThang.Value, ref gridCuocGoiMGThang);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DoWork: ", ex);
            }
            SetUnActiveRefreshButton();           
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (g_bChuaCoDuLieu && (!g_bThayDoiChonNam))  // chưa có dữ liệu ghép và chưa có lựa chọn thay đổi dữ liệu theo năm
            {
                try
                {
                    m_fmProgress.lblDescription.Invoke(
                       (MethodInvoker)delegate { m_fmProgress.lblDescription.Text = "Đang xử lý ... "; }
                    );
                    if (m_fmProgress.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("bw_DoWork: ", ex);
                }
            }

            try
            {
                DateTime tuNgay = new DateTime(g_Nam, intUDTuThang.Value, 1, 0, 0, 0);
                DateTime denNgay = new DateTime(g_Nam, intUDDenThang.Value, DateTime.DaysInMonth(g_Nam, intUDDenThang.Value), 0, 0, 0);
                if (intUDDenThang.Value >= 12)
                    denNgay = new DateTime(g_Nam + 1, 1, 1, 0, 0, 0);

                DataTable data = TimKiem_BaoCao.BaoCaoKhachHangThanThietTheoThang_V2(tuNgay, denNgay, txtSoDienThoai.Text.Trim(), txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), gIsMoiGioi);
                gridCuocGoiMGThang.DataMember = "ListDienThoai";
                gridCuocGoiMGThang.SetDataBinding(data, "ListDienThoai");
                HideCotCuaGrid(intUDTuThang.Value, intUDDenThang.Value, ref gridCuocGoiMGThang);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DoWork: ", ex);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = string.Format("12_BaoCaoKhachQuenTheoThang-{0:yyyy-MM-dd-HH-mm}.xls", CommonBL.GetTimeServer().Date);
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export(objFile);
                    new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnExportExcel_Click: ", ex);
            }
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
            }

            if (e.Error != null)
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
            }
        }

        private void intSoChuyen_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }
        private void ddlNam_SelectedValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
            if (g_bThayDoiChonNam) g_bThayDoiChonNam = false;
        }
        private void intUDTuThang_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }
        private void intUDDenThang_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        #region Validate dữ liệu nhập
        private void intUDTuThang_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int iValue = int.Parse(intUDTuThang.TextBox.Text);
                if (iValue <= 0 || iValue > 12)
                {
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void intUDDenThang_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int iValue = int.Parse(intUDDenThang.TextBox.Text);
                if (iValue <= 0 || iValue > 12)
                {
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void intSoChuyen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int iValue = int.Parse(intSoChuyen.TextBox.Text);
                if (iValue < 0)
                {
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }

        #endregion 

        private void txtSoDienThoai_Click_1(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
        }

        private void txtTenKH_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
        }

        private void txtDiaChi_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
        }

        private void inputRadioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inputRadioGroup.SelectedIndex == 0)
                gIsMoiGioi = 0;
            else if (inputRadioGroup.SelectedIndex == 1)
                gIsMoiGioi = 1;
            else gIsMoiGioi = 2;
            SetActiveRefreshButton();
        }
        #endregion
    }
}