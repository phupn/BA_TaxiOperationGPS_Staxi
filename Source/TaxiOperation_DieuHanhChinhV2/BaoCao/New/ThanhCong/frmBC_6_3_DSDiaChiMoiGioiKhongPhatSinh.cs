using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.BaoCao ;
using Taxi.Utils;
using System.IO;
using Janus.Windows.GridEX;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    public partial class frmBC_6_3_DSDiaChiMoiGioiKhongPhatSinh : Form
    {
        public frmBC_6_3_DSDiaChiMoiGioiKhongPhatSinh()
        {
            InitializeComponent();
           
        }
        private void frmBC_6_1_DSDiaChiMoiGioi_Load(object sender, EventArgs e)
        {
            calBatDauTu.Value = DateTime.Now.Date;
            calBatDauDen.Value = DateTime.Now.Date.AddSeconds(86399);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            DateTime ngayBDTu = DateTime.MinValue;
            DateTime ngayBDDen = DateTime.MinValue;
            DateTime ngayKTTu = DateTime.MinValue;
            DateTime ngayKTDen = DateTime.MinValue;

            DoiTac objMoiGioi = new DoiTac();
            
            //bind vao gridEx
            DataTable dt = objMoiGioi.GetBaoCaoMoiGioi_KoPhatSinh(calBatDauTu.Value,calBatDauDen.Value);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdDSDiaChiMoiGioi.DataMember = "tblDoiTac";
                grdDSDiaChiMoiGioi.SetDataBinding(dt, "tblDoiTac");                
                btnExportExcel.Enabled = true;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu");
                grdDSDiaChiMoiGioi.DataMember = "tblDoiTac";
                grdDSDiaChiMoiGioi.SetDataBinding(dt, "tblDoiTac");
                btnExportExcel.Enabled = false ;
            }
                      
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_DSDiaChi_MoiGioi_KhongPhatSinh.xls";
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
                MessageBox.Show("Có lỗi tạo file excel","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information );
            }
            btnExportExcel.Enabled = false;
        }
        private void HienThiTrangThaiChu(GridEXRow row)
        {
            //DataRow objDoiTac = (DataRow)row.DataRow;
            //if (objDoiTac["NgayKyKet"] == DateTime.MinValue || objDoiTac["NgayKyKet"] == DateTime.Parse("01/01/1900"))
            //{
            //    row.Cells["NgayKyKet"].Text = string.Empty;
            //}
            //if (objDoiTac.["NgayKetThuc"]  == DateTime.MinValue || objDoiTac["NgayKetThuc"] == DateTime.Parse("01/01/1900"))
            //{
            //    row.Cells["NgayKetThuc"].Text = string.Empty;
            //}
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
            if (calBatDauTu.Enabled == false )
            {
                calBatDauTu.Enabled = true;
                calBatDauDen.Enabled = true;
            }
            else
            {
                calBatDauTu.Enabled = false ;
                calBatDauDen.Enabled = false ;
            }
        }
    }
}