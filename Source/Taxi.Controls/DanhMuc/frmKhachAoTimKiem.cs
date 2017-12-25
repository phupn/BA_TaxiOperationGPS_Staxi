using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmKhachAoTimKiem : FormBase
    {
        private List<DanhBaKhachAo> mListOfKhachAo = new List<DanhBaKhachAo>();

        public frmKhachAoTimKiem()
        {
            InitializeComponent();
        }

        public List<DanhBaKhachAo> GetResultListOfKhachAo()
        {
            return mListOfKhachAo;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";

                if (radDienThoai.Checked)
                {
                    strSQL = "SELECT * FROM  [dbo].[T_DANHBA_KhachAo] WHERE  PhoneNumber LIKE '%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
                }
                else if (radTen.Checked)
                {
                    strSQL = "SELECT * FROM  [dbo].[T_DANHBA_KhachAo] WHERE Name LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
                }
                else if (radDiaChi.Checked)
                {
                    strSQL = "SELECT * FROM  [dbo].[T_DANHBA_KhachAo] WHERE Address LIKE '%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
                }
                mListOfKhachAo = DanhBaKhachAo.GetKhachAos(strSQL);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSave_Click: ", ex);                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    btnSave.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmKhachAoTimKiem_Load(object sender, EventArgs e)
        {
            editThongTinTimKiem.Focus();
        }
    }
}