using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmNhanVienTimKiem : Form
    {
        private List<NhanVien> mListOfNhanVien = new List<NhanVien>();


        public frmNhanVienTimKiem()
        {
            InitializeComponent();
        }

        public List<NhanVien> GetResultListOfNhanVien()
        {
            return mListOfNhanVien;
        }

        private void frmNhanVienTimKiem_Load(object sender, EventArgs e)
        {
            txtThongTinTimKiem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string strSQL = "";


            if (radTenDoiTac.Checked)
            {
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [TenNhanVien] LIKE N'%" + StringTools.TrimSpace(txtThongTinTimKiem.Text) + "%'";
            }
            else if (radSoHieuXe.Checked)
            {
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [FK_SoHieuXeLai] LIKE N'%" + StringTools.TrimSpace(txtThongTinTimKiem.Text) + "%'";
            }
            else if (radTheLaiXe.Checked)
            {
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [SoTheLaiXe] LIKE N'%" + StringTools.TrimSpace(txtThongTinTimKiem.Text) + "%'";
            }
            else if (radSoDienThoai.Checked)
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [DiDong] LIKE N'%" + StringTools.TrimSpace(txtThongTinTimKiem.Text) + "%'";

            mListOfNhanVien = NhanVien.GetNhanViens(strSQL);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}