using TaxiOperation_DieuXeDuongDai.BaoCao;
using TaxiOperation_DieuXeDuongDai.DangKyDonKhach;
using TaxiOperation_DieuXeDuongDai.XeDiTinh;
using TaxiOperation_DieuXeDuongDai.XuLyDieuXe;

namespace TaxiOperation_DieuXeDuongDai
{
    public partial class frmMain : FormBase
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void danhSáchĐónKháchToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new frmDanhSachDatLichDonKhach().Show();
        }

        private void nhậpLịchĐónKháchToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new FrmDatLichDonKhach().Show();
        }

        private void đăngKýĐónKháchToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new frmThemDangKyDonKhach().Show();
        }

        private void danhSáchĐăngKýĐónKháchToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new frmDanhSachDangKyDonKhach().Show();
        }

        private void điềuXeĐườngDàiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void danhSáchXeĐiTỉnhToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
             new frmDanhSachXeDiTinh().Show();
        }

        private void thêmXeĐiTỉnhToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new frmThemXeDiTinh().Show();
        }

        private void xửLýĐiềuXeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new frmDieuXe().Show();
        }

        private void báoCáoNhậtTrìnhXeĐónKháchĐườngDàiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new frmBaoCaoNhatTrinhXeBaoDuongDai().Show();
        }
    }
}
