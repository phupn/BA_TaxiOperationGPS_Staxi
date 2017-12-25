using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmDanhBaCongTyTimKiem : Form
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
            string strSQL = "";

            if (radDienThoai .Checked)
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
                 strSQL = "SELECT * FROM  [dbo].[T_DANHBA_CONGTY] WHERE Address LIKE '%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
             }
             mListOfDanhBaCongTy = DanhBaCongTy.GetDanhBaCongTys(strSQL);

             this.DialogResult = DialogResult.OK;
             this.Close();
        }
    }
}