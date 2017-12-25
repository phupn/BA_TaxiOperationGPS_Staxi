using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmDanhBaCongTyTimKiem : FormBase
    {
        private List< DanhBaCongTy> mListOfDanhBaCongTy = new List< DanhBaCongTy>();


        public frmDanhBaCongTyTimKiem()
        {
            InitializeComponent();
        }

        public List<DanhBaCongTy> GetResultListOfDanhBaCongTy()
        {
            return mListOfDanhBaCongTy;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";

                if (radDienThoai.Checked)
                {
                    strSQL = "SELECT * FROM  [dbo].[T_DANHBA_CONGTY] WHERE  PhoneNumber LIKE '%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
                }
                else
                    if (radTen.Checked)
                    {
                        strSQL = "SELECT * FROM  [dbo].[T_DANHBA_CONGTY] WHERE Name LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
                    }

                    else if (radDiaChi.Checked)
                    {
                        strSQL = "SELECT * FROM  [dbo].[T_DANHBA_CONGTY] WHERE Address LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
                    }
                mListOfDanhBaCongTy = DanhBaCongTy.GetDanhBaCongTys(strSQL);
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

        private void frmDanhBaCongTyTimKiem_Load(object sender, EventArgs e)
        {
            editThongTinTimKiem.Focus();
        }

    }
}