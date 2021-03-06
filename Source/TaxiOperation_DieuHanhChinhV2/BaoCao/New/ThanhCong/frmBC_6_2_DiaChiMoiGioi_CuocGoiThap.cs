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

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.ThanhCong
{
    public partial class frmBC_6_2_DiaChiMoiGioi_CuocGoiThap : Form
    {
        public frmBC_6_2_DiaChiMoiGioi_CuocGoiThap()
        {
            InitializeComponent();
        }
       
        private void frmBC_6_2_DiaChiMoiGioi_CuocGoiThap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtMaMoiGioi;
            txtMaMoiGioi.Focus();
            calBatDauDen.Value = DateTime.Now.Date.AddSeconds(86399);
            calBatDauTu.Value = DateTime.Now.Date;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
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
                //SP_DOITAC_BAOCAO_MOIGIOI_CUOCGOITHAP
                DataTable dt = objMoiGioi.GetBaoCaoMoiGioi_CuocGoiThap(txtMaMoiGioi.Text, 0,
                    SoLuongDonDuoc, ngayBatDau, ngayKetThuc);



                if (dt != null && dt.Rows.Count > 0)
                {
                    if(!dt.Columns.Contains("PhiHH"))
                        dt.Columns.Add("PhiHH");
                   //  item["PhiHH"]
                    float TienHH1 = 0;
                    float TienHH2 = 0;
                    float TienHH3 = 0;
                    int TuCuoc1 = 0;
                    int TuCuoc2 = 0;
                    int TrenCuoc1 = 0;
                    int TrenCuoc2 = 0;
                    int.TryParse(txtTuCuoc.Text.Trim(), out TuCuoc1);
                    int.TryParse(txtDenCuoc.Text.Trim(), out TuCuoc2);
                    int.TryParse(txtTrenCuoc1.Text.Trim(), out TrenCuoc1);
                    int.TryParse(txtTrenCuoc2.Text.Trim(), out TrenCuoc2);
                    float.TryParse(txtTienHH1.Text.Trim(), out TienHH1);
                    float.TryParse(txtTienHH2.Text.Trim(), out TienHH2);
                    float.TryParse(txtTienHH3.Text.Trim(), out TienHH3);
                    DateTime tgSuDungCongThuc = calNgayKyKet.Value;

                    foreach (DataRow item in dt.Rows)
                    {
                        int TongCuoc = int.Parse(item["TongCuoc"].ToString());
                         int CuocSB=0;
                        if(dt.Columns.Contains("CuocSB"))
                         CuocSB = int.Parse(item["CuocSB"].ToString());
                        int CuocDD = int.Parse(item["TongDonDuoc"].ToString());
                         float HHNT=0;
                         if (dt.Columns.Contains("TiLeHoaHongNoiTinh"))
                         HHNT = float.Parse(item["TiLeHoaHongNoiTinh"].ToString());
                        float HHSB = 0;
                        if(dt.Columns.Contains("TiLeHoaHongNgoaiTinh"))
                         HHSB =  float.Parse(item["TiLeHoaHongNgoaiTinh"].ToString());
                        DateTime tgKyHopDong = item["NgayKyKet"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(item["NgayKyKet"].ToString());
                        float TienHoaHong = 0;
                        if (tgKyHopDong >= tgSuDungCongThuc)
                        {
                            if (CuocDD <= TrenCuoc1)
                            {
                                TienHoaHong = CuocDD * TienHH1;
                            }
                            else if (CuocDD > TrenCuoc1 && CuocDD <= TrenCuoc2)
                            {
                                TienHoaHong = CuocDD * TienHH2;
                            }
                            else if (CuocDD > TrenCuoc2)
                            {
                                TienHoaHong = CuocDD * TienHH3;
                            }
                            item["PhiHH"] = TienHoaHong;

                        }
                        else
                        {
                            item["PhiHH"] = (CuocSB * HHSB) + (CuocDD * HHNT);
                        }
                    }

                    grdMoiGioiCuocGoiThap.DataMember = "tblMoiGioiSoLuong";
                    grdMoiGioiCuocGoiThap.SetDataBinding(dt, "tblMoiGioiSoLuong");
                    btnExportExcel.Enabled = true;
                }
                else
                {
                    grdMoiGioiCuocGoiThap.DataMember = "tblMoiGioiSoLuong";
                    grdMoiGioiCuocGoiThap.SetDataBinding(dt, "tblMoiGioiSoLuong");
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
                string FilenameDefault = "BaoCaoDiaChiMoiGioi_GoiQuaTrungTam.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.GridEX = grdMoiGioiCuocGoiThap;
                    gridEXExporter1.Export((Stream)objFile);
                    objFile.Close();
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
                txtDonDuoc.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                calBatDauDen.Focus();
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
                btnRefresh.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtMaMoiGioi.Focus();
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
                btnRefresh.Focus();
            }
        }

        private void calBatDauDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMaMoiGioi.Focus();
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
            return false;
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

        
    }
}