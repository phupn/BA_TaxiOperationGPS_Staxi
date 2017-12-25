using System.Data;
using System.Windows.Forms;
using Taxi.Business.DieuXeDuongDai;
using Taxi.Data.DM;
using Taxi.Utils;
using Taxi.Utils.Enums;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai
{
    public partial class frmDanhSachDatLichDonKhach : FormBase
    {
        #region Hàm
        public frmDanhSachDatLichDonKhach()
        {
            InitializeComponent();
           
        }

        private void LoadData()
        {
            //shGridControl1.SetDataSource(new DUONGDAI_KHACHHEN().GetList());
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
            var db = new DUONGDAI_KHACHHEN().TimKiem(deStart.DateTime.Date, deEnd.DateTime.Date.AddDays(1).AddSeconds(-1), txtSDT.Text, txtDiaChi.Text);
            shGridControl1.SetDataSource(db);
        }

        private void reXemLichSu_Click(object sender, System.EventArgs e)
        {
            var db = gridView1.GetFocusedRow() as DUONGDAI_KHACHHEN;
            if (db != null)
            {
                var frm = new frmLichSuDatLichDonKhach();
                frm.SetID(db.Id);
                frm.ShowDialog();
            }
            
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            var db = gridView1.GetFocusedRow() as DUONGDAI_KHACHHEN;
            if (db != null)
            {
                var frm = new FrmDatLichDonKhach();
                frm.SetModel(db);
                frm.ShowDialog(); 
                LoadData();
            }
        }

        private void btnThemMoi_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmDatLichDonKhach();
            frm.ShowDialog();
            LoadData();
        }

        private void frmDanhSachDatLichDonKhach_Load(object sender, System.EventArgs e)
        {
           //
            reTrangThai.DataSource = CommonDuongDai.GetTrangThaiDatLichDonKhach();
            reLoaiXe.DataSource = CommonDuongDai.GetLoaiXe();
            reLoaiXe.DisplayMember = "TenLoaiXe";
            reLoaiXe.ValueMember = "LoaiXeID"; 
            deStart.EditValue = CommonDuongDai.GetTimeServer().Date;
            deEnd.EditValue = CommonDuongDai.GetTimeServer();
             LoadData();
            txtSDT.Focus();

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
            reXemLichSu_Click(null, null);
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
