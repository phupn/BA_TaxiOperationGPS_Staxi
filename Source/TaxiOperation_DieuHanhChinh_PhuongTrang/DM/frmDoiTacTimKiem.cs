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
            strSQL += "   ,[IsActive],FK_MaNhanVien,TenNhanVien,Vung,NgayKyKet,NgayKetThuc, CT.TenCongTy, DT.FK_CongTyID CongTyID ";
			strSQL +="    ,[SoNha] ,[TenDuong]  ,[CreatedBy] ,[CreatedDate] ,[UpdatedBy] ,[UpdatedDate],KinhDo,ViDo ";
            strSQL += "  FROM [dbo].[T_DOITAC] DT LEFT JOIN T_DMCONGTY CT ON DT.FK_CongTyID = CT.PK_CongTyID "; 


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