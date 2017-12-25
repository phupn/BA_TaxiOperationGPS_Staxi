using System;
using StaxiMan_DAL;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Extender;
using Taxi.Logger;
using Taxi.MessageBox;
using System.Collections.Generic;

namespace StaxiMan
{
    public partial class UserLogin_Form : StaxiMan_FormBase 
    {
        private int _id=-1;
        private const string DefaultPassWord = "123456";
        private const string KeyEngypt = "binhanh.vn";
        private List<Company_User> lstCompany_User;
        public UserLogin_Form()
        {
            InitializeComponent();
        }

        private void UserLogin_Form_Load(object sender, EventArgs e)
        {
            LoadDataInput();
        }

        private void LoadDataInput()
        {
            try
            {
                panelTop.BindShControl();
                lstCompany_User = Company_User.Inst.GetAll().ToList<Company_User>();
                gridControl.DataSource = lstCompany_User;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadDataInput: ", ex);                
            }
        }

        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Company_User row = (Company_User)gridView.GetFocusedRow();
                if (row != null)
                {
                    _id = row.Id;
                    txtUserName.Enabled = false;
                    txtUserName.Text = row.UserName;
                    txtPassword.Text = new BACryptor.Encryption(KeyEngypt).Decrypt(row.Password);
                    cboCompany.EditValue = row.FK_CompanyID;
                    chkIsActive.Checked = row.IsActive;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridControl_DoubleClick: ", ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    new MessageBoxBA().Show("Bạn vui lòng chọn dữ liệu trên lưới!","Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    return;
                }
                var result = new MessageBoxBA().Show("Bạn có muốn xóa user này không?","Thông báo", MessageBoxButtonsBA.YesNo,MessageBoxIconBA.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Company_User objUser = new Company_User();
                    objUser.Id = _id;
                    objUser.Delete();
                    new MessageBoxBA().Show("Xóa thông tin user thành công!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Information);
                    ResetForm();
                    RefreshGridControl();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnDelete_Click", ex);               
            }
        }

        private void ResetForm()
        {
            _id = -1;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cboCompany.EditValue = 0;
            txtUserName.Enabled = true;           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGridControl();
            ResetForm();
        }

        private void RefreshGridControl()
        {
            lstCompany_User = Company_User.Inst.GetAll().ToList<Company_User>();
            gridControl.DataSource = lstCompany_User;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValid())
                    return;

                Company_User objUser = new Company_User();
                objUser.Id = _id;
                objUser.UserName = txtUserName.Text;
                objUser.Password = new BACryptor.Encryption(KeyEngypt).Encrypt(txtPassword.Text);
                objUser.FK_CompanyID = cboCompany.EditValue.To<int>();
                objUser.IsActive = chkIsActive.Checked;

                if (_id == -1)//Thêm mới
                {
                    objUser.Insert();
                    new MessageBoxBA().Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                }
                else
                {
                    objUser.Update();
                    new MessageBoxBA().Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                }
                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                new MessageBoxBA().Show("Cập nhật dữ liệu thất bại!","Thông báo", MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                LogError.WriteLogError("btnSave_Click: ", ex);                
            }
        }

        private bool CheckValid()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                new MessageBoxBA().Show("Tên đăng nhập không được để trống!","Thông báo",MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                txtUserName.Focus();
                return false;
            }

            if (ExistUserName(txtUserName.Text))
            {
                new MessageBoxBA().Show("Tên đăng nhập không được trùng với các user trước đó!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                new MessageBoxBA().Show("Mật khẩu không được để trống!","Thông báo", MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                txtPassword.Focus();
                return false;
            }

            if (cboCompany.EditValue == null || cboCompany.EditValue == "0")
            {
                new MessageBoxBA().Show("Bạn vui lòng chọn công ty của user!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                cboCompany.Focus();
                return false;
            }
            else
            {
                int companyid = cboCompany.EditValue.To<int>();
                if (companyid > 0 && lstCompany_User.FindIndex(T=>T.FK_CompanyID == companyid && T.IsActive == true) > 0)
                {
                    new MessageBoxBA().Show("Công ty này đã có tài khoản rồi!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    cboCompany.Focus();
                    return false;                    
                }
            }
            return true;
        }

        private bool ExistUserName(string pUserName)
        {
            if (Company_User.Inst.GetListAllUser().Exists(a => a.UserName == pUserName && _id <= 0))
            {
                return true;
            }
            return false;
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    new MessageBoxBA().Show("Bạn vui lòng chọn dữ liệu trên lưới!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    return;
                }

                Company_User objUser = (Company_User)gridView.GetFocusedRow();
                objUser.Password = new BACryptor.Encryption(KeyEngypt).Encrypt(DefaultPassWord);
                objUser.Update();
                new MessageBoxBA().Show("Reset mật khẩu thành công!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Information);
            }
            catch (Exception ex)
            {
                new MessageBoxBA().Show("Reset mật khẩu thất bại!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                LogError.WriteLogError("btnResetPass_Click: ",ex);                
            }
        }
    }
}
