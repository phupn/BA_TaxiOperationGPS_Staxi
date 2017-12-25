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
    public partial class frmKhachQuenTimKiem : Form
    {
        private List<DanhBaKhachQuen> mListOfKhachQuen = new List<DanhBaKhachQuen>();


        public frmKhachQuenTimKiem()
        {
            InitializeComponent();
        }

        public List<DanhBaKhachQuen> GetResultListOfKhachQuen()
        {
            return mListOfKhachQuen;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            if (radDienThoai .Checked)
            {
                strSQL = "SELECT  K.* , T.[Type] TypeName , R.[Rank] RankName FROM    [dbo].[T_DMKHACHHANG] K INNER JOIN dbo.T_DMKHACHHANG_RANK R ON K.[Rank] = R.ID INNER JOIN dbo.T_DMKHACHHANG_TYPE T ON K.[Type] = T.ID WHERE  Phones LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
            }
            else
            if (radTen.Checked)
            {
                strSQL = "SELECT  K.* , T.[Type] TypeName , R.[Rank] RankName FROM    [dbo].[T_DMKHACHHANG] K INNER JOIN dbo.T_DMKHACHHANG_RANK R ON K.[Rank] = R.ID INNER JOIN dbo.T_DMKHACHHANG_TYPE T ON K.[Type] = T.ID WHERE Name LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
            }
             
             else if (radDiaChi.Checked)
             {
                 strSQL = "SELECT  K.* , T.[Type] TypeName , R.[Rank] RankName FROM    [dbo].[T_DMKHACHHANG] K INNER JOIN dbo.T_DMKHACHHANG_RANK R ON K.[Rank] = R.ID INNER JOIN dbo.T_DMKHACHHANG_TYPE T ON K.[Type] = T.ID WHERE Address LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
             }
             mListOfKhachQuen = DanhBaKhachQuen.GetKhachQuens(strSQL);

             this.DialogResult = DialogResult.OK;
             this.Close();
        }
    }
}