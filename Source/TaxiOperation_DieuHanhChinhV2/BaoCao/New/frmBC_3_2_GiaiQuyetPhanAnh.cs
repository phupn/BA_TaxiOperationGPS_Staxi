using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.ThongTinPhanAnh;
using System.IO;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.Business.DM;

namespace TaxiOperation_DieuHanhChinh
{
    public partial class frmBC_3_2_GiaiQuyetPhanAnh : Form
    {
        public List<ThongTinPhanAnh> _listThongTinPA = new List<ThongTinPhanAnh>();
        public frmBC_3_2_GiaiQuyetPhanAnh()
        {
            InitializeComponent();
           
        }
        private void frmBC_3_2_GiaiQuyetPhanAnh_Load(object sender, EventArgs e)
        {

            this.ActiveControl = calTuNgay;
            calTuNgay.Focus();
            LoadLoaiPhanAnh();
            LoadDSCongTy();
        }

        public void LoadLoaiPhanAnh()
        {
            ThongTinPhanAnh objLoaiPhanAnh = new ThongTinPhanAnh();
            DataTable dtLoaiPA = objLoaiPhanAnh.GetLoaiPhanAnh();
            cbLoaiPhanAnh.DisplayMember = "TenLoaiPhanAnh";
            cbLoaiPhanAnh.ValueMember = "ID";
            cbLoaiPhanAnh.DataSource = dtLoaiPA;

        }
        private void LoadDSCongTy( )
        {
            cboCongTy.ValueMember = "CongTyID";
            cboCongTy.DisplayMember = "TenCongTy";
            cboCongTy.DataSource = null;
            cboCongTy.DataSource = CongTy.GetAllDSCongTy();
 
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (calDenNgay.Value < calTuNgay.Value)
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc lớn hơn hoặc bằng ngày bắt đầu","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                string dienThoai    = StringTools.TrimSpace (txtDienThoai.Text );
                string tenKhachHang = StringTools.TrimSpace (txtTenKhachHang.Text );
                string maThongTin   = StringTools .TrimSpace (txtMaThongTin.Text );
                int loaiPhanAnhID   = 0;
                try{
                    loaiPhanAnhID = int.Parse(cbLoaiPhanAnh.SelectedValue.ToString());
                }
                catch(Exception ex)
                {
                    loaiPhanAnhID = 0;
                }
                int congTyID        = 0;
                try{
                    congTyID =  int.Parse(cboCongTy.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    congTyID = 0;
                }
                 ThongTinPhanAnh phanAnh = new ThongTinPhanAnh ();
                _listThongTinPA = phanAnh.GetThongTinKhachHangPhanAnh(calTuNgay.Value, calDenNgay.Value,dienThoai, tenKhachHang, maThongTin, loaiPhanAnhID, congTyID );
                
                grdBaoCaoGiaiQuyet.DataMember = "lstThongTinPA";
                grdBaoCaoGiaiQuyet.SetDataBinding(_listThongTinPA, "lstThongTinPA");
                btnExportExcel.Enabled = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_GiaiQuyet_PhanAnh.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                if (MessageBox.Show("Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
            btnExportExcel.Enabled = false;
        }
        private void HienThiTrangThaiChu(GridEXRow row)
        {
            ThongTinPhanAnh objPhanAnh = (ThongTinPhanAnh)row.DataRow;
            if (objPhanAnh.ThoiGianPhanAnh == DateTime.MinValue)
            {
                row.Cells["ThoiGianPhanAnh"].Text = string.Empty;
            }
            else if (objPhanAnh.NgayGiaiQuyet == DateTime.MinValue)
            {
                row.Cells["NgayGiaiQuyet"].Text = string.Empty;
            }
        }

        private void grdBaoCaoGiaiQuyet_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
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
                this.Close();
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

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

        private void txtMaThongTin_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = false;
        }

       
    }
}