using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.ThongTinPhanAnh;
using Janus.Windows.GridEX;
using System.IO;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmTimKiem : Form
    {
        #region

        ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
        List<ThongTinPhanAnh> lstPhanAnh = new List<ThongTinPhanAnh>();
        public bool TrangThai;
        public bool ChuyenDV;

        private bool g_ChonDongNhapVaoLuot = false;
        private string g_soDienThoai = string.Empty;

        private string g_TenKhachHang = string.Empty ;
        private string g_NoiDung = string.Empty;

        public string GetTenKhachHang
        {
            get { return g_TenKhachHang; }
        }

        public string GetNoiDung
        {
            get { return g_NoiDung; }
        }


        #endregion

        // tao delegate cho tim kiem thanh cong

        public delegate void TimKiemThanhCongEvent();
        public event TimKiemThanhCongEvent TimKiemThanhCongClick;

        public frmTimKiem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// khoi tao du lieu voi thong tin dien thoai
        /// tim kiem theo so dien thoai, thiet lap thoi gian tim kiem trong 10 ngay gan day
        /// 
        /// </summary>
        /// <param name="soDienThoai"></param>
        public frmTimKiem(string soDienThoai)
        {
            InitializeComponent();
            g_soDienThoai = soDienThoai;
            g_ChonDongNhapVaoLuot = true;
        }


        public frmTimKiem(bool trangThai, bool chuyen)
        {
            InitializeComponent();
            TrangThai = trangThai;
            ChuyenDV = chuyen;
        }


        public virtual void OnTimKiemThanhCongClick()
        {
            if (TimKiemThanhCongClick != null)
                TimKiemThanhCongClick();
        }


        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            if (!g_ChonDongNhapVaoLuot)
            {
                btnXuatExcel.Enabled = false;
                btnSearch.Enabled = true;
                lblMessage.Visible = false;
            }
            else
            {
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                cbDenNgay.Value = timeServer;
                cbTuNgay.Value = timeServer.AddDays(-10);
                cbDenNgay.Enabled = false;
                cbTuNgay.Enabled = false;
                txtSoDienThoai.Text = g_soDienThoai;
                lstPhanAnh = objPhanAnh.SearchPhanAnh(g_soDienThoai, "", cbTuNgay.Value, cbDenNgay.Value, TrangThai, ChuyenDV);

                grdGiaiQuyetPA.DataMember = "lstThongTinPA";
                grdGiaiQuyetPA.SetDataBinding(lstPhanAnh, "lstThongTinPA"); 
                btnSearch.Enabled = false;
                btnXuatExcel.Enabled = false;
                lblMessage.Visible = true;
            }
        }
        public List<ThongTinPhanAnh> GetPhanAnh
        {
            get { return lstPhanAnh; }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (cbDenNgay.Value < cbTuNgay.Value)
            {
                new Taxi.MessageBox.MessageBox().Show("Từ ngày phải nhỏ hơn đến ngày");
            }
            else
            {
                lstPhanAnh = objPhanAnh.SearchPhanAnh(StringTools.TrimSpace(txtSoDienThoai.Text), StringTools.TrimSpace(txtNoiDung.Text),
                    cbTuNgay.Value, cbDenNgay.Value, TrangThai, ChuyenDV);
                if (lstPhanAnh != null && lstPhanAnh.Count > 0)
                {
                    btnXuatExcel.Enabled = true;
                } 

                grdGiaiQuyetPA.DataMember = "lstThongTinPA";
                grdGiaiQuyetPA.SetDataBinding(lstPhanAnh, "lstThongTinPA");
                btnSearch.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

   

        private void frmTimKiem_FormClosing(object sender, FormClosingEventArgs e)
        {
           //   e.Cancel = true;
        }
        #region Xử lý hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == (Keys.Alt|Keys.K))
            {
                btnSearch_Click(null, null);
                return true;
            }
            else if(keyData == (Keys.Alt|Keys.T))
            {
                btnThoat_Click(null, null);
                return true;
            }
            return false;
        }
        #endregion               

        #region Xử lý mũi tên
        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right )
            {
                txtNoiDung.Focus();
            }
            else if(e.KeyCode == Keys.Left)
            {
                
            }
        }

        private void txtNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                cbTuNgay.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtSoDienThoai.Focus();
            }
        }

        private void cbTuNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                cbDenNgay.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtNoiDung.Focus();
            }
        }

        private void cbDenNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnSearch.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                cbTuNgay.Focus();
            }
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnThoat.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                cbDenNgay.Focus(); 
            }
        }

        private void btnThoat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtSoDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnSearch.Focus();
            }
        }
        #endregion

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // lấy ra ds nhung cuộc chọn và xuất excel.
            List<ThongTinPhanAnh> lstPhanAnhs = new List<ThongTinPhanAnh>();
            // gán vào lưới --> xuất excel
            GridEXRow[] rows = grdGiaiQuyetPA.GetCheckedRows();
            if (rows != null && rows.Length > 0)
            {
                foreach (GridEXRow row in rows)
                {
                    lstPhanAnhs.Add((ThongTinPhanAnh)row.DataRow);
                }

                gridEX1.DataMember = "lstThongTinPA";
                gridEX1.SetDataBinding(lstPhanAnhs, "lstThongTinPA");

               
                string FilenameDefault = "PhanAnh.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.Create); 
                        gridEXExporter1.Export((Stream)objFile);
                        new MessageBox.MessageBox().Show("Tạo file Excel thành công.", "Thông báo");
                        objFile.Close();
                    }
                    catch (Exception ex)
                    {
                        new MessageBox.MessageBox().Show(ex.Message);
                    }
                }

            }
            else
            {
                new Taxi.MessageBox.MessageBox().Show("Bạn phải chọn dòng để xuất Excel.");
            }
            btnXuatExcel.Enabled = false;
        }

        private void gridEX1_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void grdGiaiQuyetPA_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if ((DateTime)e.Row.Cells["NgayGiaiQuyet"].Value == DateTime.MinValue)
            {                 
                e.Row.Cells["NgayGiaiQuyet"].Value = new DateTime(1900, 01, 01, 0, 0, 0);
                //e.Row.Cells["NgayGiaiQuyet"].Text = "";
            }
        }

        private void grdGiaiQuyetPA_DoubleClick(object sender, EventArgs e)
        {
            if (g_ChonDongNhapVaoLuot)
            {
                grdGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdGiaiQuyetPA.SelectedItems.Count > 0)
                {
                    ThongTinPhanAnh objThongTinPA = (ThongTinPhanAnh)((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                    g_NoiDung = objThongTinPA.NoiDung;
                    g_TenKhachHang = objThongTinPA.TenKhachHang;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cbDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetControl();
        }

        private void cbTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetControl();
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {
            SetControl();
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            SetControl();
        }

        private void SetControl()
        {
            btnSearch.Enabled = true;
            btnXuatExcel.Enabled = false;
        }
    }
}