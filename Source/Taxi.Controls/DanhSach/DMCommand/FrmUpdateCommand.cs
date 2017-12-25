using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Utils;

namespace Taxi.Controls.DanhSach.DMCommand
{
    public partial class FrmUpdateCommand : FormUpdate
    {
        public override Taxi.Common.DbBase.ModelBase ModelNew
        {
            get
            {
                return new Taxi.Data.G5.DanhMuc.G5Command();
            }
        }
        public FrmUpdateCommand()
        {
            InitializeComponent();
        }

        private void lookupEdit_EnumCommand_ServerFunction1_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsLoad)
            {
                inputLookUp_G5CommandCmd1.EditValue = 0;
                txtThongBao.Text = "";
            }
            if (lookupEdit_EnumCommand_ServerFunction1.GetValue().Equals((int)IServerFunction.SendText))
            {
                inputLookUp_G5CommandCmd1.Enabled = true;
                txtThongBao.Enabled = true;
            }
            else
            {
                inputLookUp_G5CommandCmd1.Enabled = false;
                txtThongBao.Enabled = false;
            }
        }

        private void lookupEdit_EnumCommand_G5CommandType1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEdit_EnumCommand_G5CommandType1.EditValue.Equals((int)G5CommandType.NhapMoRong))
            {
                lblCanhBao.Text = "(Chú ý:Cột trong db)";
                lblCotNhap.Visible = true;
            }
            else
            {
                lblCanhBao.Text = "(Điều app-Lệnh lái xe,Lệnh tổng đài)";
                lblCotNhap.Visible = false;
            }
        }
    }
}
