using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;
using Taxi.Business;

namespace DieuHanhChinh.DM
{
    public partial class frmMemberCard_Search : Form
    {
        public frmMemberCard_Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            string code = txtCode.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Vui lòng nhập mã số";
            }
            else
            {
                MemberCard objMemberCard = MemberCard.GetMemberCardByCode(code);
                if (objMemberCard != null)
                {
                    FillDataToForm(objMemberCard);
                    if (!objMemberCard.Active)
                    {
                        lblMessage.ForeColor = Color.Orange;
                        lblMessage.Text = "Thẻ tạm ngưng hoạt động";
                    }
                    else if (objMemberCard.ExpireDate <= DieuHanhTaxi.GetTimeServer())
                    {
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "Thẻ hết hạn sử dụng ngày: " + objMemberCard.ExpireDate.ToString("hh:mm:ss dd/MM/yyyy");
                    }
                    else
                    {
                        lblMessage.ForeColor = Color.Blue;
                        lblMessage.Text = "Thẻ còn hoạt động đến: " + objMemberCard.ExpireDate.ToString("dd/MM/yyyy");
                    }
                }
                else
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Thẻ không tồn tại";
                }
            }
        }

        private void FillDataToForm(MemberCard objMemberCard)
        {
            lblName.Text = objMemberCard.Name;
            lblNote.Text = objMemberCard.Note;
            lblAddress.Text = objMemberCard.Address;
            lblType.Text = objMemberCard.Type;
            lblDateOfIssue.Text = objMemberCard.DateOfIssue.ToString("hh:mm:ss dd/MM/yyyy");
            lblExpireDate.Text = objMemberCard.ExpireDate.ToString("hh:mm:ss dd/MM/yyyy");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMemberCard_Search_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
            lblName.Text = "";
            lblNote.Text = "";
            lblAddress.Text = "";
            lblType.Text = "";
            lblDateOfIssue.Text = "";
            lblExpireDate.Text = "";
            lblMessage.Text = "";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.SelectAll();
        }

        private void txtCode_Click(object sender, EventArgs e)
        {
            txtCode.SelectAll();
        }
    }
}