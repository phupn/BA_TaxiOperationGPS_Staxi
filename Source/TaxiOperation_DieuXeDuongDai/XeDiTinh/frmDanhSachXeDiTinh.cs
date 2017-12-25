using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using Taxi.Business.DieuXeDuongDai;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai.XeDiTinh
{
    public partial class frmDanhSachXeDiTinh : FormBase
    {
        #region Hàm
        public frmDanhSachXeDiTinh()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            //var db = new DUONGDAI_DONKHACH_XEDITINH().GetList();
            //shGridControl1.SetDataSource(db);
            btnTimKiem.PerformClick();
        }
        #endregion

        #region sự kiện
        private void frmDanhSachXeDiTinh_Load(object sender, System.EventArgs e)
        {
            var db = CommonDuongDai.GetTrangThaiXeDiTinh();
            var row =db.NewRow();
            row[0] = "Tất cả";
            row[1] = "0";
            db.Rows.InsertAt(row, 0);
            lupTrangThai.Properties.DataSource = db;
            lupTrangThai.ItemIndex = 0; 
            reTrangThai.DataSource = CommonDuongDai.GetTrangThaiXeDiTinh();
            reTrangThaiXoa.DataSource = CommonDuongDai.GetTrangThaiXoa();
            //
            deStart.EditValue = CommonDuongDai.GetTimeServer().Date;
            deEnd.EditValue = CommonDuongDai.GetTimeServer(); 
            LoadData();
            SendKeys.Send("%");
            txtSDT.Focus();
        }

        private void btnThemMoi_Click(object sender, System.EventArgs e)
        {
            new frmThemXeDiTinh().ShowDialog();
            LoadData();
        }
        
        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            if (deStart.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn từ ngày");
                deStart.Focus();
                return;
            }
            if (deEnd.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn đến ngày");
                deEnd.Focus();
                return;
            }
            if (deStart.DateTime > deEnd.DateTime)
            {
                MessageBox.Show("Từ ngày nhỏ hơn đến ngày");
                deEnd.Focus();
                return;
            }
            var trangthai = 0;
            if(lupTrangThai.EditValue!=null)int.TryParse(lupTrangThai.EditValue.ToString(), out trangthai);
            var db = new DUONGDAI_DONKHACH_XEDITINH().TimKiem(deStart.DateTime, deEnd.DateTime, txtXe.Text, txtSDT.Text, TxtDiaChi.Text, trangthai);
            shGridControl1.SetDataSource(db);
        }
        
        private void reLichSu_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmLichSuXeDiTinh();
                frm.SetId((gridView1.GetFocusedRow() as DUONGDAI_DONKHACH_XEDITINH).Id);
                frm.ShowDialog();
            }
            catch { }
        }
        
        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            var frm = new frmThemXeDiTinh();
            frm.SetModel((gridView1.GetFocusedRow() as DUONGDAI_DONKHACH_XEDITINH));
            frm.ShowDialog();
            LoadData();
        }
        
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gridView1_DoubleClick(null, null);
            }
        }
        
        private void btnLichSu_Click(object sender, EventArgs e)
        {
            reLichSu_Click(null, null);
        }
        #endregion

        #region ProcessCmdKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (btnLichSu.Focused && keyData == Keys.Tab)
            {
                deStart.Focus();
                //keyData = Keys.None;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
