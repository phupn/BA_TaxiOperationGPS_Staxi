using System;
using System.Windows.Forms;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai.XuLyDieuXe
{
    public partial class frmXeDiTinhXoa : FormBase
    {
        public string GhiChu;
        public string LyDo;
        public frmXeDiTinhXoa()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
            LyDo =lupTrangThai.EditValue.ToString();
            GhiChu = inputMemoEdit1.Text;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private void frmXeDiTinhXoa_Load(object sender, EventArgs e)
        {
            lupTrangThai.Properties.DataSource = CommonDuongDai.GetTrangThaiXeDiTinhLyDoXoa();
            lupTrangThai.ItemIndex = 0;
        }
    }
}
