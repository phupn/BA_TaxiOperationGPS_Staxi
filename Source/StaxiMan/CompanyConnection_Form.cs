using System;
using System.ComponentModel;
using BACryptor;
using StaxiMan_DAL;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Common.License;
using Taxi.Controls.Base.Extender;
using Taxi.Logger;
using Taxi.MessageBox;

namespace StaxiMan
{
    public partial class CompanyConnection_Form : StaxiMan_FormBase
    {
        #region Init & Constructor
        private const string KeyEngypt = "binhanh.vn";
        private string _nullText = "Chọn công ty";        
        private int _id = -1;
        public CompanyConnection_Form()
        {
            InitializeComponent();
        }
        #endregion

        #region Events!

        private void CompanyConnection_Form_Load(object sender, EventArgs e)
        {
            LoadAllDataInput();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
            RefreshGridControl();
            txtSource.Focus();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CompanyConnection row = (CompanyConnection)gridView.GetFocusedRow();
                if (row != null)
                {
                    _id = row.Id;
                    txtSource.Text = row.Source;
                    txtCatalog.Text = row.Catalog;
                    txtUserName.Text = row.UserName;
                    txtPassword.Text = new Encryption(KeyEngypt).Decrypt(row.Password);
                    cboCompany.EditValue = row.FK_CompanyID;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridView_DoubleClick: ", ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyConnection objConnection = new CompanyConnection();
                objConnection.Id = _id;
                objConnection.FK_CompanyID = cboCompany.EditValue.To<int>();
                objConnection.Source = txtSource.Text;
                objConnection.Catalog = txtCatalog.Text;
                objConnection.UserName = txtUserName.Text;
                objConnection.Password = new Encryption(KeyEngypt).Encrypt(txtPassword.Text);

                if (!CheckValid())
                    return;

                if (_id == -1)
                {
                    objConnection.Insert();
                    new MessageBoxBA().Show("Thêm mới thông tin máy chủ thành công!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                }
                else
                {
                    objConnection.Update();
                    new MessageBoxBA().Show("Cập nhật thông tin máy chủ thành công!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                }
                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSave_Click: ", ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    new MessageBoxBA().Show("Bạn chưa chọn dữ liệu trên lưới!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    return;
                }
                var result = new MessageBoxBA().Show("Bạn có muốn xóa thông tin máy chủ này không?", "Thông báo", MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                if (result == "Yes")
                {
                    CompanyConnection objDel = new CompanyConnection();
                    objDel.Id = _id;
                    objDel.Delete();
                    new MessageBoxBA().Show("Xóa thông tin máy chủ thành công!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                    ResetForm();
                    RefreshGridControl();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnDelete_Click: ", ex);
            }
        }
        #endregion

        #region Methods
        private void LoadAllDataInput()
        {
            try
            {
                if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime) && !DesignMode)
                {
                    gridView.Add<RepositoryItem_Company>("FK_CompanyID");
                }
                panelTop.BindShControl();
                RefreshGridControl();                
                cboCompany.Properties.NullText = _nullText;                
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadAllDataInput: ",ex);
            }
        }

        private bool CheckValid()
        {
            if (string.IsNullOrEmpty(txtSource.Text))
            {
                new MessageBoxBA().Show("Địa chỉ nguồn server không được để trống!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                txtSource.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCatalog.Text))
            {
                new MessageBoxBA().Show("Tên cơ sở dữ liệu không được để trống!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                txtCatalog.Focus();
                return false;
            }

            if (cboCompany.Text == _nullText)
            {
                new MessageBoxBA().Show("Tên công ty không được để trống!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                cboCompany.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                new MessageBoxBA().Show("Username không được để trống!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                new MessageBoxBA().Show("Mật khẩu không được để trống!", "Thông báo");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            try
            {
                _id = -1;
                txtSource.Text = string.Empty;
                txtCatalog.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cboCompany.EditValue = null;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ResetForm: ", ex);
            }
        }

        private void RefreshGridControl()
        {
            try
            {
                var lstConnectCompany = CompanyConnection.Inst.GetAll().ToList<CompanyConnection>();
                gridControl.DataSource = lstConnectCompany;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("RefreshGridControl: ", ex);
            }
        }

        #endregion
    }
}
