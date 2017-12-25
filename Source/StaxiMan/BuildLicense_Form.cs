using StaxiMan_DAL;
using System;
using System.Windows.Forms;
using Taxi.Common.Extender;
using Taxi.Logger;
using Taxi.Controls.Base.Extender;

namespace StaxiMan
{
    public partial class BuildLicense_Form : StaxiMan_FormBase 
    { 
        private int IDRequestLicenseKey { get; set; }
        
        private RequestLicenseKey _objRequestLicenseKey { get; set; }
        private CompanyLicense _objCompanyLicense { get; set; }
        public BuildLicense_Form()
        {
            
            InitializeComponent();
        }

        private void BuildLicense_Form_Load(object sender, EventArgs e)
        {
            LoadData();
            RefreshForm();
            //gridView_Origin.Add<RepositoryItemLookUpEdit_PhimTat>("Company");
            groupBuildLicense.BindShControl();
        }

        private void RefreshForm()
        {            
            _objRequestLicenseKey = new RequestLicenseKey();
            _objCompanyLicense = new CompanyLicense();
            FillData();
            groupBuildLicense.Enabled = false;
        }

        private void FillData()
        {            
            lblCompanyName.Text = _objRequestLicenseKey.CompName;
            lblPhoneNumber.Text = _objRequestLicenseKey.PhoneNumber;
            lblID_RequestLicenseKey.Text = _objRequestLicenseKey.Id.ToString();            
            IDRequestLicenseKey = _objRequestLicenseKey.Id;
            txtLicenseCode.Text = "";
            txtLicenseKey.Text = "";
            date_ExpDate.EditValue = null;
            txtNote.Text = "";
            if (inputLookUp_Company.EditValue.To<int>() != _objRequestLicenseKey.FK_CompanyID)
            {
                txtAPIKey.Text = "";
                txtAPICode.Text = "";
            }
            inputLookUp_Company.EditValue = _objRequestLicenseKey.FK_CompanyID;
            if (_objRequestLicenseKey.FK_CompanyID != BuildLicenseUtil.ParentCompanyID)
            {
                inputLookUp_Company.Enabled = false;
            }
            else
            {
                inputLookUp_Company.Enabled = true;
            }
            lblMsg.Text = "";
        }

        private void LoadData()
        {
            gridControl_Origin.DataSource = RequestLicenseKey.Inst.GetAllData();            
        }

        private void btnBuildLicense_Click(object sender, EventArgs e)
        {
            BuildLicense();
        }

        private void BuildLicense()
        {
            try
            {
                if (date_ExpDate.EditValue == null || date_ExpDate.DateTime <= DateTime.Now.Date)
                {
                    lblMsg.Text = "Exp.Date Invalid!!!";
                    date_ExpDate.Focus();
                    return;
                }

                if (inputLookUp_Company.EditValue.ToString() ==  BuildLicenseUtil.ParentCompanyID.ToString())
                {
                    lblMsg.Text = "Please choose company";
                    inputLookUp_Company.Focus();
                    return;
                }                
                string licenseCode = "";
                txtLicenseKey.Text = CompanyLicense.Inst.BuildLicenseKey(_objRequestLicenseKey, date_ExpDate.DateTime, out licenseCode);
                txtLicenseCode.Text = licenseCode;
                if (txtAPICode.Text.Trim() != "")
                {
                    txtAPIKey.Text = BuildLicenseUtil.BuildEncrypt(txtAPICode.Text.Trim());
                }

                DisableControl();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("StaxiMan BuildLicense", ex); 
            }
        }

        private void DisableControl()
        {
            inputLookUp_Company.Enabled = false;
            date_ExpDate.Enabled = false;
            txtAPICode.Enabled = false;            
        }

        private void EnableControls()
        {
            inputLookUp_Company.Enabled = true;
            date_ExpDate.Enabled = true;
            txtAPICode.Enabled = true;       
        }

        private void CopyLicenseToClipBoard()
        {
            string license = "";
            license = string.Format("API Key : {2}\r\nLicense Code : {0}\r\nLicense Key : {1}", txtLicenseCode.Text, txtLicenseKey.Text, txtAPIKey.Text);
            Clipboard.SetText(license);
        }

        private void LoadCurrentLicense()
        {
            try
            {
                if (inputLookUp_Company.EditValue != null)
                {
                    int companyID = 0;
                    int.TryParse(inputLookUp_Company.EditValue.ToString(), out companyID);
                    CompanyLicense objCompanyLicense = CompanyLicense.Inst.GetDataById(companyID);
                    if (objCompanyLicense != null)
                    {
                        txtCurrentLicense.Text = string.Format("License Code : {0}\r\nLicense Key : {1}\r\nAPI Key : {2}\r\nExp.Date : {3:dd/MM/yyyy}", objCompanyLicense.LicenseCode, objCompanyLicense.LicenseKey, objCompanyLicense.LicenseTaxiAPI_Code, objCompanyLicense.ExpDate);
                    }
                    else txtCurrentLicense.Text=string.Empty;
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("BuildLicense_Form.LoadCurrentLicense", ex);
            }
        }

        private void LoadCurrentAPIKey()
        {
            try
            {
                if (inputLookUp_Company.EditValue != null)
                {
                    int companyID = 0;
                    int.TryParse(inputLookUp_Company.EditValue.ToString(), out companyID);
                    APILicense objAPILicense = APILicense.Inst.GetItemFromCompanyId(companyID);
                    if (objAPILicense != null)
                    {
                        txtAPICode.Text = objAPILicense.APICode;                        
                    }
                    else
                    {
                        txtAPICode.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("BuildLicense_Form.LoadCurrentAPIKey", ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLicenseCode.Text.Trim()) || string.IsNullOrEmpty(txtLicenseKey.Text.Trim()) || IDRequestLicenseKey <= 0)
                {
                    lblMsg.Text = "Invalid Input!!!";
                    return;
                }
                if (date_ExpDate.EditValue == null || date_ExpDate.DateTime <= DateTime.Now.Date)
                {
                    lblMsg.Text = "Exp.Date Invalid!!!";
                    date_ExpDate.Focus();
                    return;
                }
                if (inputLookUp_Company.EditValue.ToString() == BuildLicenseUtil.ParentCompanyID.ToString())
                {
                    lblMsg.Text = "Please choose company";
                    inputLookUp_Company.Focus();
                    return;
                }
                _objCompanyLicense.LicenseCode = txtLicenseCode.Text.Trim();
                _objCompanyLicense.LicenseKey = txtLicenseKey.Text.Trim();
                _objCompanyLicense.ExpDate = date_ExpDate.DateTime;
                _objCompanyLicense.CreateDate = DateTime.Now;
                _objCompanyLicense.FK_CompanyID = (int)inputLookUp_Company.EditValue;
                _objCompanyLicense.IsActive = true;
                _objCompanyLicense.LicenseTaxiAPI = txtAPIKey.Text.Trim();
                _objCompanyLicense.LicenseTaxiAPI_Code = txtAPICode.Text.Trim();
                _objCompanyLicense.Notes = txtNote.Text.Trim();
                if(_objCompanyLicense.InsertData(_objRequestLicenseKey.Id))
                {
                    MessageBox.Show("Lưu thành công, License này đã có thể sử dụng cho KH","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    RefreshForm();
                    EnableControls();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Lỗi chưa lưu được license, Vui lòng thử lại !", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("BuildLicenseForm Save", ex);
            }
        }

   

        private void gridView_Origin_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    _objRequestLicenseKey = (RequestLicenseKey)gridView_Origin.GetRow(e.RowHandle);
                    FillData();
                    LoadCurrentLicense();
                    date_ExpDate.EditValue = DALCommon.Inst.GetTimeServer().AddDays(30);
                    groupBuildLicense.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridView_Origin_RowClick: ", ex);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new RequestHistory_Form(DateTime.Now.Date, DateTime.Now, _objRequestLicenseKey.PhoneNumber, _objRequestLicenseKey.CompName).ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillData();
            EnableControls();
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyLicenseToClipBoard();
        }

        private void btnReloadRequest_Click(object sender, EventArgs e)
        {
            LoadData();
            RefreshForm();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (_objRequestLicenseKey != null && _objRequestLicenseKey.Id > 0)
                {
                    if (MessageBox.Show("Do you want to cancel this request ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _objRequestLicenseKey.Responsed = true;
                        _objRequestLicenseKey.ResponsedDate = DateTime.Now;
                        _objRequestLicenseKey.Update();

                        btnReloadRequest_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Choose Request !!!");
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnReject_Click: ", ex);                
            }
            
        }

        private void inputLookUp_Company_EditValueChanged(object sender, EventArgs e)
        {
            if (inputLookUp_Company.EditValue != null)
            {
                LoadCurrentLicense();
                LoadCurrentAPIKey();
            }
        }
    }
}
