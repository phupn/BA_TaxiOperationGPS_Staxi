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
using Taxi.Business.DM;
using Taxi.Utils;
using System.Data;
using System.Linq;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    public partial class frmBC_6_6_THCuocGoiMG_TheoXe : Form
    {
        DataTable dtXe = new DataTable();
        public frmBC_6_6_THCuocGoiMG_TheoXe()
        {
            InitializeComponent();
        }
       
        private void frmBC_6_2_DiaChiMoiGioi_CuocGoiThap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtMaMoiGioi;
            txtMaMoiGioi.Focus();
            calBatDauDen.Value = DateTime.Now.Date.AddSeconds(86399);
            calBatDauTu.Value = DateTime.Now.Date;
            dtXe = new Xe().LayDanhSach_SHXe();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayBatDau = calBatDauTu.Value;
                DateTime ngayKetThuc = calBatDauDen.Value;

                DoiTac objMoiGioi = new DoiTac();
                if ((ngayKetThuc < ngayBatDau))
                {
                    MessageBox.Show(@"Ngày kết thúc phải lớn hơn ngày bắt đầu", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    calBatDauDen.Focus();
                }
                else
                {
                    // bind du lieu vao grid
                    int Type = 0;
                    if (chkCiputra.Checked && !chkHoaHong.Checked)
                    {
                        Type = 1;
                    }
                    else if (!chkCiputra.Checked && chkHoaHong.Checked)
                    {
                        Type = 2;
                    }
                    DataSet ds = objMoiGioi.GetBaoCaoMoiGioi_PhatSinhTheoXe(txtMaMoiGioi.Text.Trim(), txtSoXe.Text.Trim(), ngayBatDau, ngayKetThuc, Type);
                    if (ds != null && ds.Tables.Count > 1)
                    {
                        DataTable dt1 = ds.Tables[0];//Table cuộc gọi có 1 xe đón
                        DataTable dt2 = ds.Tables[1];//Table cuộc gọi có nhiều xe đón
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            foreach (DataRow item in dt2.Rows)
                            {
                                string[] arrXeDon = item["XeDonCK"].ToString().Split('.');
                                foreach (string xedon in arrXeDon)
                                {
                                    //DataRow[] dr = dtXe.Select("PK_SoHieuXe = '" + xedon + "'");
                                    //if (dr.Length > 0)
                                    {
                                        item["XeDon"] = xedon;
                                        dt1.ImportRow(item);
                                        //dt1.Rows[dt1.Rows.Count-1]["XeDon"] = xedon;
                                    }
                                }
                            }
                        }
                        if (dt1 != null)
                        {
                            var groupedData = from tab in dt1.AsEnumerable()
                                              group tab by tab["XeDon"]
                                                  into groupDt let list = groupDt.ToList()
                                                  select new
                                                  {
                                                      XeDon = groupDt.Key,
                                                      MoiGioiCount = list.Count(),
                                                      SanBay_DuongDai = list.Sum(x => x.Field<int>("SanBay_DuongDai")),
                                                      BinhThuong = list.Sum(x => x.Field<int>("BinhThuong"))
                                                  };


                            //DataTable dtReport = Global.GroupBy_Multi_Custom("XeDon", "MoiGioi","Ciputra", "ID", dt1);
                            gridEX_TH.DataMember = "tblMoiGioiTH";
                            gridEX_TH.SetDataBinding(groupedData.ToList(), "tblMoiGioiTH");

                            grdMoiGioiCuocGoiThap.DataMember = "tblMoiGioiSoLuong";
                            grdMoiGioiCuocGoiThap.SetDataBinding(dt1, "tblMoiGioiSoLuong");
                            btnExportExcel.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu");
                            gridEX_TH.DataMember = "tblMoiGioiTH";
                            gridEX_TH.SetDataBinding(null, "tblMoiGioiTH");

                            grdMoiGioiCuocGoiThap.DataMember = "tblMoiGioiSoLuong";
                            grdMoiGioiCuocGoiThap.SetDataBinding(dt1, "tblMoiGioiSoLuong");
                            lbMess.Text = "Không tìm thấy dữ liệu";
                            btnExportExcel.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Taxi.Business.LogError.WriteLogError("frmBC_6_6", ex);
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
                string FilenameDefaultTH = "BaoCaoTHCGMoiGioiPhatSinhTheoXE_TH.xls";
                string FilenameDefault = "BaoCaoTHCGMoiGioiPhatSinhTheoXE.xls";
                saveFileDialog1.FileName = FilenameDefaultTH;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFileTH = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter2.GridEX = gridEX_TH;
                    gridEXExporter2.Export((Stream)objFileTH);
                    objFileTH.Close();
                    saveFileDialog1.FileName = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.Length - 4) + "_ChiTiet.xls";
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
                txtSoXe.Focus();
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
                txtSoXe.Focus();
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
                txtSoXe.Focus();
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

            //if (row.Cells["NgayKyKet"].Text == DateTime.MinValue.ToString() || row.Cells["NgayKyKet"].Text == "01/01/1900")
            //{
            //    row.Cells["NgayKyKet"].Text = string.Empty;
            //}
            //if (row.Cells["NgayKetThuc"].Text  == DateTime.MinValue.ToString() || row.Cells["NgayKetThuc"].Text  == "01/01/1900")
            //{
            //    row.Cells["NgayKetThuc"].Text = string.Empty;
            //}
        }

        private void grdMoiGioiCuocGoiThap_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkCiputra_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}