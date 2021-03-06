using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.BaoCao;
using System.IO;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    public partial class frmBC_6_2_DiaChiMoiGioi_CuocGoiThap : Form
    {
        public frmBC_6_2_DiaChiMoiGioi_CuocGoiThap()
        {
            InitializeComponent();
        }
       
        private void frmBC_6_2_DiaChiMoiGioi_CuocGoiThap_Load(object sender, EventArgs e)
        {
            LoadDMCongTy();
            cbCongTy.SelectedIndex = 0;
            this.ActiveControl = txtMaMoiGioi;
            txtMaMoiGioi.Focus();
            calBatDauTu.Value = DateTime.Today;
            calBatDauDen.Value = DateTime.Now;
            grdMoiGioiCuocGoiThap.KeyDown += grdMoiGioiCuocGoiThap_KeyDown;
            grdMoiGioiCuocGoiThap.RowDoubleClick += grdMoiGioiCuocGoiThap_RowDoubleClick;
        }

        void grdMoiGioiCuocGoiThap_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            LoadRowDetail();
        }

        void grdMoiGioiCuocGoiThap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadRowDetail();
            }
        }
        public void LoadDMCongTy()
        {
            DoiTac objThongTinDT = new DoiTac();
            cbCongTy.DataSource = objThongTinDT.GetTenCongTy();
            cbCongTy.DisplayMember = "TenCongTy";
            cbCongTy.ValueMember = "CongtyID";
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int congTy = 0;
            DateTime ngayBatDau = DateTime.MinValue;
            DateTime ngayKetThuc = DateTime.MinValue;
            int SoLuongDonDuoc =0;

            DoiTac objMoiGioi = new DoiTac();
            if ((calBatDauDen.Value < calBatDauTu.Value))
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                calBatDauDen.Focus();
            }
            else
            {
                if (cbCongTy.SelectedIndex == 0)
                {
                    congTy = 0;
                }
                else
                {
                    congTy =int.Parse(cbCongTy.SelectedValue.ToString());
                }
                
                 ngayBatDau = calBatDauTu.Value;
                 ngayKetThuc = calBatDauDen.Value;
              
                if(txtDonDuoc.Text == string.Empty )
                {
                    SoLuongDonDuoc = -1;
                }
                else 
                {
                    SoLuongDonDuoc = int.Parse(txtDonDuoc.Text);
                }
                // bind du lieu vao grid
                DataTable dt = objMoiGioi.GetBaoCaoMoiGioi_CuocGoiThap(txtMaMoiGioi.Text, congTy,
                    SoLuongDonDuoc, ngayBatDau, ngayKetThuc);

                
                if (dt != null)
                {
                    grdMoiGioiCuocGoiThap.DataMember = "tblMoiGioiSoLuong";
                    grdMoiGioiCuocGoiThap.SetDataBinding(dt, "tblMoiGioiSoLuong");

                    gridExport.DataMember = "gridExport";
                    gridExport.SetDataBinding(dt, "gridExport");
                    btnExportExcel.Enabled = true;
                }
                else
                {
                    grdMoiGioiCuocGoiThap.DataMember = "tblMoiGioiSoLuong";
                    grdMoiGioiCuocGoiThap.SetDataBinding(dt, "tblMoiGioiSoLuong");

                    gridExport.DataMember = "gridExport";
                    gridExport.SetDataBinding(dt, "gridExport");
                    lbMess.Text = "Không tìm thấy dữ liệu";
                    btnExportExcel.Enabled = false ;
                }
            }
        }

        private void txtDonDuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCaoDiaChiMoiGioi_CuocGoiThap.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    if (MessageBox.Show("Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
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

        private void txtMaMoiGioi_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void cbCongTy_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void txtDonDuoc_TextChanged(object sender, EventArgs e)
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

       
        #region Xu li mui ten
        private void txtMaMoiGioi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                cbCongTy.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {

            }
        }

        private void cbCongTy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtDonDuoc.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtMaMoiGioi.Focus();
            }
        }

        private void txtDonDuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                //chkBDTatCa.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbCongTy.Focus();
            }
        }
              
        private void calBatDauTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                calBatDauDen.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                //chkBDTatCa.Focus();
            }
        }

        private void calBatDauDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                //chkBDTatCa.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                calBatDauTu.Focus();
            }
        }
        #endregion
        #region xu li hot key
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
                return true;
            }

            else if (keyData == Keys.C)
            {
                cbCongTy.Focus();
                return true;
            }
            else if (keyData == Keys.S)
            {
                txtDonDuoc.Focus();
                return true;
            }
            else if (keyData == Keys.G)
            {
                //chkBDTatCa.Focus();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion
        private void HienThiTrangThaiChu(GridEXRow row)
        {

            if (row.Cells["NgayKyKet"].Text == DateTime.MinValue.ToString() || row.Cells["NgayKyKet"].Text == "01/01/1900")
            {
                row.Cells["NgayKyKet"].Text = string.Empty;
            }
            if (row.Cells["NgayKetThuc"].Text  == DateTime.MinValue.ToString() || row.Cells["NgayKetThuc"].Text  == "01/01/1900")
            {
                row.Cells["NgayKetThuc"].Text = string.Empty;
            }
        }
        private void grdMoiGioiCuocGoiThap_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }

        private void grdMoiGioiCuocGoiThap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
           
           
        }

        private void gridExport_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            LoadRowDetail();
        }
        private void LoadRowDetail()
        {
            try
            {
                var dr = grdMoiGioiCuocGoiThap.GetRow(grdMoiGioiCuocGoiThap.Row);
                if (dr != null)
                {
                    string maDoiTac = dr.Cells["Ma_DoiTac"].Text;
                    int congTy = 0;
                    if (cbCongTy.SelectedIndex > 0)
                    {
                        int.TryParse(cbCongTy.SelectedValue.ToString(), out congTy);
                    }
                    DateTime ngayBatDau = calBatDauTu.Value;
                    DateTime ngayKetThuc = calBatDauDen.Value;
                    new frmBC_6_8_ChiTietCuocGoiTheoMaMoiGioi(ngayBatDau, ngayKetThuc, congTy, maDoiTac).Show();
                }
            }
            catch (Exception ex)
            {
                Taxi.Business.LogError.WriteLogError("LoadRowDetail", ex);
                MessageBox.Show("Lỗi");
            }
        }

        private void gridExport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadRowDetail();
            }
        }
        
    }
}