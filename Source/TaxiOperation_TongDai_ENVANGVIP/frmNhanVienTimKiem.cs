using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
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
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            
            if (radTenDoiTac.Checked)
            {
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [TenNhanVien] LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
            }
            else if (radSoHieuXe.Checked)
            {
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [FK_SoHieuXeLai] LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
            }
            else if (radTheLaiXe.Checked)
            {
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [SoTheLaiXe] LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
            }
            else if(radSoDienThoai.Checked)
                strSQL = "SELECT * FROM  [dbo].[T_NHANVIEN] WHERE [DiDong] LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
       
             mListOfNhanVien = NhanVien.GetNhanViens (strSQL);

             this.DialogResult = DialogResult.OK;
             this.Close();
        }

        private void frmNhanVienTimKiem_Load(object sender, EventArgs e)
        {
            editThongTinTimKiem.Focus();
        }
    }
}