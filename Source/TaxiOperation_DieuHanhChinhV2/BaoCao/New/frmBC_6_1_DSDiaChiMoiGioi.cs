using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.BaoCao;
using Taxi.Utils;
using System.IO;
using Janus.Windows.GridEX;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    public partial class frmBC_6_1_DSDiaChiMoiGioi : Form
    {
        public frmBC_6_1_DSDiaChiMoiGioi()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 
        /// hàm khởi tạo từ ngày đến ngày của ngày bắt đầu
        /// Sử dụng cho báo cáo 3 mặc định tìm kiếm môi giới gần đây.
        /// </summary>
        /// <param name="ngayBDTuNgay"></param>
        /// <param name="ngayBDDenNgay"></param>
        /// <modified>
        ///  Congnt
        /// </modified>
        public frmBC_6_1_DSDiaChiMoiGioi(DateTime ngayBDTuNgay, DateTime ngayBDDenNgay)
        {
            InitializeComponent();
            chkBDTatCa.Checked = true;
            calBatDauTu.Value = ngayBDTuNgay;
            calBatDauDen.Value = ngayBDDenNgay;
        }
        private void frmBC_6_1_DSDiaChiMoiGioi_Load(object sender, EventArgs e)
        {
            LoadDMCongTy();
            cbCongTy.SelectedIndex = 0;
            this.ActiveControl = txtMaMoiGioi;
            txtMaMoiGioi.Focus();
        }
        #region Load du lieu

        public void LoadDMCongTy()
        {
            DoiTac objThongTinDT = new DoiTac();
            cbCongTy.DataSource = objThongTinDT.GetTenCongTy();
            cbCongTy.DisplayMember = "TenCongTy";
            cbCongTy.ValueMember = "CongtyID";
        }
        #endregion

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int congTy = 0;
            DateTime ngayBDTu = DateTime.MinValue;
            DateTime ngayBDDen = DateTime.MinValue;
            DateTime ngayKTTu = DateTime.MinValue;
            DateTime ngayKTDen = DateTime.MinValue;

            DoiTac objMoiGioi = new DoiTac();
            if (txtDienThoai.Text != string.Empty && txtDienThoai.Text.Length < 8)
            {
                MessageBox.Show("Bạn hãy kiểm tra lại định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            else if (chkBDTatCa.Checked && (calBatDauDen.Value < calBatDauTu.Value))
            {
                MessageBox.Show("Ngày bắt đầu sau phải lớn hơn hoặc bằng ngày bắt đầu trước ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                calBatDauDen.Focus();
            }
            else if (chkKTTatCa.Checked && (calKetThucDen.Value < calKetThucTu.Value))
            {
                MessageBox.Show("Ngày kết thúc sau phải lớn hơn hoặc bằng ngày kết thúc trước ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                calKetThucDen.Focus();
            }
            else
            {
                if (cbCongTy.SelectedIndex == 0)
                {
                    congTy = 0;
                }
                else
                {
                    congTy = int.Parse(cbCongTy.SelectedValue.ToString());
                }
                if (!chkBDTatCa.Checked)
                {
                    ngayBDTu = DateTime.MinValue;
                    ngayBDDen = DateTime.MinValue;
                }
                else
                {
                    ngayBDTu = calBatDauTu.Value;
                    ngayBDDen = calBatDauDen.Value;
                }
                if (!chkKTTatCa.Checked)
                {
                    ngayKTTu = DateTime.MinValue;
                    ngayKTDen = DateTime.MinValue;
                }
                else
                {
                    ngayKTTu = calKetThucTu.Value;
                    ngayKTDen = calKetThucDen.Value;
                }
                //bind vao gridEx
                List<DoiTac> lstDoiTac = new List<DoiTac>();
                lstDoiTac = objMoiGioi.GetBaoCaoDiaChiMoiGioi(txtMaMoiGioi.Text, txtDienThoai.Text,
                    congTy, ngayBDTu, ngayBDDen, ngayKTTu, ngayKTDen, txtTenDuong.Text, txtDiaChi.Text);
                if (lstDoiTac != null)
                {
                    grdDSDiaChiMoiGioi.DataMember = "tblDoiTac";
                    grdDSDiaChiMoiGioi.SetDataBinding(lstDoiTac, "tblDoiTac");

                    btnExportExcel.Enabled = true;
                }
                else
                {
                    grdDSDiaChiMoiGioi.DataMember = "tblDoiTac";
                    grdDSDiaChiMoiGioi.SetDataBinding(lstDoiTac, "tblDoiTac");
                    btnExportExcel.Enabled = false;
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_DSDiaChi_MoiGioi.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                   // gridEXExporter1.GridEX = grdDSDiaChiMoiGioi;
                    gridEXExporter1.Export((Stream)objFile);
                   // objFile.Close();
                    if (MessageBox.Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FileTools.OpenFileExcel(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi tạo file excel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnExportExcel.Enabled = false;
        }
        private void HienThiTrangThaiChu(GridEXRow row)
        {
            DoiTac objDoiTac = (DoiTac)row.DataRow;
            if (objDoiTac.NgayKyKet == DateTime.MinValue || objDoiTac.NgayKyKet == DateTime.Parse("01/01/1900"))
            {
                row.Cells["NgayKyKet"].Text = string.Empty;
            }
            if (objDoiTac.NgayKetThuc == DateTime.MinValue || objDoiTac.NgayKetThuc == DateTime.Parse("01/01/1900"))
            {
                row.Cells["NgayKetThuc"].Text = string.Empty;
            }
        }

        private void grdDSDiaChiMoiGioi_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }

        private void txtMaMoiGioi_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void cbCongTy_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void calBatDauTu_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void calBatDauDen_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void calKetThucTu_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void calKetThucDen_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void chkBDTatCa_Click(object sender, EventArgs e)
        {
            if (calBatDauTu.Enabled == false)
            {
                calBatDauTu.Enabled = true;
                calBatDauDen.Enabled = true;
            }
            else
            {
                calBatDauTu.Enabled = false;
                calBatDauDen.Enabled = false;
            }
        }

        private void chkKTTatCa_Click(object sender, EventArgs e)
        {
            if (calKetThucTu.Enabled == false)
            {
                calKetThucTu.Enabled = true;
                calKetThucDen.Enabled = true;
            }
            else
            {
                calKetThucTu.Enabled = false;
                calKetThucDen.Enabled = false;
            }
        }


        #region Xu li mui ten
        private void txtMaMoiGioi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {

            }
        }
        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                cbCongTy.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtMaMoiGioi.Focus();
            }
        }

        private void cbCongTy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chkBDTatCa.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtDienThoai.Focus();
            }
        }

        private void chkBDTatCa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                calBatDauTu.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                cbCongTy.Focus();
            }
        }

        private void calBatDauTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                calBatDauDen.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkBDTatCa.Focus();
            }
        }

        private void calBatDauDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chkKTTatCa.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                calBatDauTu.Focus();
            }
        }

        private void chkKTTatCa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                calKetThucTu.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                calBatDauDen.Focus();
            }
        }

        private void calKetThucTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                calKetThucDen.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkKTTatCa.Focus();
            }
        }

        private void calKetThucDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnRefresh.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                calKetThucTu.Focus();
            }
        }

        private void btnRefresh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnExportExcel.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                calKetThucDen.Focus();
            }
        }

        private void btnExportExcel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtMaMoiGioi.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnRefresh.Focus();
            }
        }
        #endregion
        #region Xu ly hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnRefresh_Click(null, null);
                return true;
            }
            else if (keyData == Keys.L)
            {
                btnRefresh_Click(null, null);
                return true;
            }
            else if (keyData == Keys.X)
            {
                btnExportExcel_Click(null, null);
                return true;
            }
            else if (keyData == Keys.M)
            {
                txtMaMoiGioi.Focus();
            }
            else if (keyData == Keys.D)
            {
                txtDienThoai.Focus();
            }
            else if (keyData == Keys.C)
            {
                cbCongTy.Focus();
            }
            //else if (keyData == Keys.B)
            //{
            //    chkBDTatCa.Focus();
            //    calBatDauTu.Enabled = true;
            //    calBatDauDen.Enabled = true;
            //}
            //else if (keyData == Keys.K)
            //{
            //    chkKTTatCa.Focus();
            //    calKetThucTu.Enabled = true;
            //    calKetThucDen .Enabled = true;
            //}
            else if (keyData == Keys.T)
            {
                calBatDauTu.Focus();
            }
            else if (keyData == Keys.D)
            {
                calBatDauDen.Focus();
            }
            else if (keyData == Keys.N)
            {
                calBatDauTu.Focus();
            }
            else if (keyData == Keys.G)
            {
                calKetThucDen.Focus();
            }
            return false;
        }
        #endregion

        private void chkBDTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBDTatCa.Checked)
            {
                calBatDauTu.Enabled = true;
                calBatDauDen.Enabled = true;
            }
            else
            {
                calBatDauTu.Enabled = false;
                calBatDauDen.Enabled = false;
            }
        }

        private void chkKTTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKTTatCa.Checked)
            {
                calKetThucTu.Enabled = true;
                calKetThucDen.Enabled = true;
            }
            else
            {
                calKetThucTu.Enabled = false;
                calKetThucDen.Enabled = false;
            }
        }


    }
}