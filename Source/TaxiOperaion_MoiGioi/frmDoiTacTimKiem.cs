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
    public partial class frmDoiTacTimKiem : Form
    {
        private   List<DoiTac> mListOfDoiTac = new List<DoiTac>();
       

        public frmDoiTacTimKiem()
        {
            InitializeComponent();
        }

        public List<DoiTac> GetResultListOfDoiTac()
        {
            return mListOfDoiTac;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            strSQL +=" SELECT [Ma_DoiTac]  ,[Name] ,[Address] ,[Phones] ,[Fax] ,[Email] ,[TiLeHoaHongNoiTinh] ,[TiLeHoaHongNgoaiTinh]  ,[Notes] ";
            strSQL += "   ,[IsActive],FK_MaNhanVien,TenNhanVien,Vung,NgayKyKet,NgayKetThuc,'' TenCongTy, DT.FK_CongTyID CongTyID ";
            strSQL += "    ,[SoNha] ,[TenDuong]  ,[CreatedBy] ,[CreatedDate] ,[UpdatedBy] ,[UpdatedDate],isnull(KinhDo,0) KinhDo, isnull(ViDo,0) ViDo ";
            strSQL += "  FROM [dbo].[T_DOITAC] DT "; 


            if (radMaDoiTac.Checked)
            {
                strSQL += "  WHERE Ma_DoiTac = '" + StringTools.TrimSpace ( editThongTinTimKiem.Text ) + "'";
            }
            else
            if (radTenDoiTac.Checked)
            {
                strSQL += "  WHERE Name LIKE N'%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
            }
            else if (radDienThoại.Checked)
            {
                strSQL += "  WHERE Phones LIKE '%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
             }
             else if (radDiaChi.Checked)
             {
                 strSQL += "  WHERE Address LIKE '%" + StringTools.TrimSpace(editThongTinTimKiem.Text) + "%'";
             }
             mListOfDoiTac = DoiTac.GetDoiTacs(strSQL);

             this.DialogResult = DialogResult.OK;
             this.Close();
        }
    }
}