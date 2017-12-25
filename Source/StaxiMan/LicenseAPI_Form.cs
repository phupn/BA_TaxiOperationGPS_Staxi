using StaxiMan_DAL;
using System;
using System.ComponentModel;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Common.License;
using Taxi.Logger;
using Taxi.MessageBox;
using Taxi.Controls.Base.Extender;
using System.Collections.Generic;

namespace StaxiMan
{
    public partial class LicenseAPI_Form : StaxiMan_FormBase
    {
        #region Init & Constructor!

        private int _id;
        private List<APILicense> lstAPILicense;
        public LicenseAPI_Form()
        {
            InitializeComponent();
        }

        #endregion

        #region Events!
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValid())
                    return;

                APILicense objApiCode = new APILicense();
                objApiCode.Id = _id;
                objApiCode.APICode = txtAPICode.Text.Trim();
                objApiCode.APIKey = BuildLicenseUtil.BuildEncrypt(txtAPICode.Text.Trim());
                objApiCode.FK_CompanyID = cboCompany.EditValue.To<int>();
                if(_id==-1)//Add Api Code cho công ty!
                    objApiCode.Insert();
                else 
                    objApiCode.Update(); 

                new MessageBoxBA().Show("Cập nhật thông tin API License thành công!", "Thông báo", MessageBoxButtonsBA.OK,MessageBoxIconBA.Information);
                ResetForm();
                RefreshGridControl();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSave_Click: ", ex);                
            }
        }

        private void LicenseAPI_Form_Load(object sender, EventArgs e)
        {
            if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime) && !DesignMode)
            {
                gridViewCompany.Add<RepositoryItem_Company>("FK_CompanyID");
            }
            LoadInputData();
        }

        private void gridViewCompany_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = (APILicense)gridViewCompany.GetFocusedRow();
                if (row != null)
                {
                    _id = row.Id;
                    //txtAPICode.Text = BuildLicenseUtil.BuildDecrypt(row.APICode);
                    txtAPICode.Text = row.APICode;
                    cboCompany.EditValue = row.FK_CompanyID;

                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewCompany_DoubleClick: ", ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGridControl();
            ResetForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    new MessageBoxBA().Show("Bạn vui lòng chọn dữ liệu trên lưới!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    return;
                }

                var result = new MessageBoxBA().Show("Bạn có muốn xóa API Company này không?", "Thông báo", MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Error);
                if (result == MessageBoxResult.Yes)
                {
                    APILicense objApiLicense = new APILicense();
                    objApiLicense.Id = _id;
                    objApiLicense.Delete();
                    new MessageBoxBA().Show("Xóa thông tin API Company thành công!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
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

        private void ResetForm()
        {
            _id = -1;
            txtAPICode.Text = string.Empty;
            cboCompany.EditValue = 0;
            txtAPICode.Focus();
        }

        private void LoadInputData()
        {
            try
            {
                cboCompany.Properties.DisplayMember = "Name";
                cboCompany.Properties.ValueMember = "CompanyId";
                cboCompany.Bind();
                lstAPILicense = new APILicense().GetAll().ToList<APILicense>();
                gridData.DataSource = lstAPILicense;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadInputData: ", ex);                
            }
        }

        private bool CheckValid()
        {
            if (string.IsNullOrEmpty(txtAPICode.Text))
            {
                new MessageBoxBA().Show("Bạn vui lòng nhập mã APICode để xác thực!", "Thông báo", MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                txtAPICode.Focus();
                return false;
            }
            if (cboCompany.EditValue == null || cboCompany.EditValue == BuildLicenseUtil.ParentCompanyID.ToString())
            {
                new MessageBoxBA().Show("Bạn vui lòng chọn tên công ty!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Error);
                cboCompany.Focus();
                return false;
            }
            else
            {
                int companyid = cboCompany.EditValue.To<int>();

                if (lstAPILicense.Exists(T => T.FK_CompanyID == companyid))
                {
                    new MessageBoxBA().Show("Công ty này đã có license API!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    cboCompany.Focus();
                    return false;
                }
            }
            return true;
        }

        private void RefreshGridControl()
        {
            lstAPILicense = new APILicense().GetAll().ToList<APILicense>();
            gridData.DataSource = lstAPILicense;
        }

        #endregion
    }
}
