using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business.PhanAnh;
using System.IO;
using Janus.Windows.GridEX;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmBC_3_2_GiaiQuyetPhanAnh : Form
    {
        public List<PhanAnh> _listThongTinPA = new List<PhanAnh>();

        public frmBC_3_2_GiaiQuyetPhanAnh()
        {
            InitializeComponent();           
        }

        private void frmBC_3_2_GiaiQuyetPhanAnh_Load(object sender, EventArgs e)
        {
            ActiveControl = calTuNgay;
            calTuNgay.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (calDenNgay.Value < calTuNgay.Value)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập ngày kết thúc lớn hơn hoặc bằng ngày bắt đầu", "Thông báo",
                                                        Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                        Taxi.MessageBox.MessageBoxIconBA.Information);
            }
            else
            {
                string soDT = txtSoDT.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string tenKH = txtTenKH.Text.Trim();

                int trangThai = -1;
                if (chkChuaGiaiQuyet.Checked)
                    trangThai = 0;
                if (chkDaGiaiQuyet.Checked)
                    trangThai = 1;

                PhanAnh objPhanAnh = new PhanAnh();
                grdBaoCaoGiaiQuyet.DataMember = "tblChiTietPhanAnh";
                grdBaoCaoGiaiQuyet.DataSource = objPhanAnh.GetBaoCaoGiaiQuyet(calTuNgay.Value, calDenNgay.Value.AddMinutes(1439),soDT,tenKH,diaChi,trangThai);
                btnExportExcel.Enabled = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_GiaiQuyet_PhanAnh.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    gridEXExporter1.Export((Stream)objFile);
                }
                if (new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    //FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
            btnExportExcel.Enabled = false;
        }

        private void HienThiTrangThaiChu(GridEXRow row)
        {
            //PhanAnh objPhanAnh = (PhanAnh)row.DataRow;
            //if (objPhanAnh.TGPA == DateTime.MinValue)
            //{
            //    row.Cells["TGPA"].Text = string.Empty;
            //}
            //else if (objPhanAnh.GQ_TGGQ == DateTime.MinValue)
            //{
            //    row.Cells["GQ_TGGQ"].Text = string.Empty;
            //}
        }

        private void grdBaoCaoGiaiQuyet_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        #region Xu li hotkey
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            else if (keyData == Keys.T)
            {
                calTuNgay.Focus();
                return true;
            }
            else if (keyData == Keys.D)
            {
                calDenNgay.Focus();
                return true;
            }
            else if (keyData == Keys.L)
            {
                btnRefresh.Focus();
                return true;
            }
            else if (keyData == Keys.X)
            {
                btnExportExcel.Focus();
                return true;
            }
            return false;
        }
        #endregion

        #region xu li mui ten
        private void calTuNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                calDenNgay.Focus();
            }
        }

        private void calDenNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnRefresh.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                calTuNgay.Focus();
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
                calDenNgay.Focus();
            }
        }

        private void btnExportExcel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                calTuNgay.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnRefresh.Focus();
            }
        }
        #endregion       

    }
}