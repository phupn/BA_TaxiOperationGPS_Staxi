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
    public partial class frmKhachAoTimKiem : Form
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
            string strSQL = "";

            if (radDienThoai .Checked)
            {
                strSQL = "SELECT * FROM  [dbo].[T_DANHBA_KhachAo] WHERE  PhoneNumber LIKE '%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
            }
            else
            if (radTen.Checked)
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
    }
}