using System.Data;
using System.Windows.Forms;
using Taxi.Business.DieuXeDuongDai;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai.DangKyDonKhach
{
    public partial class frmDanhSachDangKyDonKhach : FormBase
    {
        #region Hàm
        public frmDanhSachDangKyDonKhach()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            //var db = new DUONGDAI_KHACHHEN_XEDK().GetList();
            //shGridControl1.SetDataSource(db);
            btnTimKiem.PerformClick();
        }
        #endregion

        #region Sự kiện
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
            if (lupTrangThai.EditValue != null)
                int.TryParse(lupTrangThai.EditValue.ToString(), out trangthai);
            var db = new DUONGDAI_KHACHHEN_XEDK().TimKiem(deStart.DateTime, deEnd.DateTime, txtSDT.Text,txtSoXe.Text, trangthai);
            shGridControl1.SetDataSource(db);
        }

        private void btnThemMoi_Click(object sender, System.EventArgs e)
        {
            new frmThemDangKyDonKhach().ShowDialog();
            LoadData();
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            var frm = new frmThemDangKyDonKhach();
            frm.SetModel(gridView1.GetFocusedRow() as DUONGDAI_KHACHHEN_XEDK);
            frm.ShowDialog();
            LoadData();
        }

        private void frmDanhSachDangKyDonKhach_Load(object sender, System.EventArgs e)
        {
            lupTrangThai.Properties.DataSource = CommonDuongDai.GetTrangThaiXeDangKy();
            lupTrangThai.ItemIndex = 0;
            deStart.EditValue = CommonDuongDai.GetTimeServer().Date;
            deEnd.EditValue = CommonDuongDai.GetTimeServer();
            LoadData();
            txtSDT.Focus();
        }

        private void reLichSu_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmLichSuDangKyDonKhach();
                frm.SetId((gridView1.GetFocusedRow() as DUONGDAI_KHACHHEN_XEDK).Id);
                frm.ShowDialog();
            }catch{}

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gridView1_DoubleClick(null, null);
            }
        }

        private void btnLichSu_Click(object sender, System.EventArgs e)
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
