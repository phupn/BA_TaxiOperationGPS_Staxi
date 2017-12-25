using StaxiMan_DAL;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Taxi.Controls.Base.Common.License;
using Taxi.Controls.Base.Extender;

namespace StaxiMan
{
    public partial class CompanyLicense_Form : StaxiMan_FormBase
    {
        private RequestLicenseKey ResponsedItem { get; set; }
        private CompanyLicense CompanyLicenseItem { get; set; }
        public CompanyLicense_Form()
        {
            InitializeComponent();
        }

        private void CompanyLicense_Form_Load(object sender, EventArgs e)
        {
            if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime) && !DesignMode)
            {
                gridView.Add<RepositoryItem_Company>("FK_CompanyID");
            }
            groupBuildLicense.BindShControl();
            LoadData();
        }
        
        private void LoadData()
        {
            gridControl.DataSource = CompanyLicense.Inst.GetList();
        }

        private void RefreshForm()
        {
            btnBuildLicense.Enabled = false;
            btnCopy.Enabled = false;
            btnSave.Enabled = false;
            btnActive.Enabled = false;
            ResponsedItem = null;
            lblCompanyName.Text = "";
            lblCpuId.Text = "";
            lblMacAddress.Text = "";
            lblPhone.Text = "";
            date_ExpDate.DateTime = DateTime.Now;
            inputLookUp_Company.EditValue = null;
        }

        private void BuildLicense()
        {
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
            string licenseCode = "";
            txtLicenseKey.Text = CompanyLicense.Inst.BuildLicenseKey(ResponsedItem, date_ExpDate.DateTime, out licenseCode);
            txtLicenseCode.Text = licenseCode;
            if (txtAPICode.Text.Trim() != "")
            {
                txtAPIKey.Text = BuildLicenseUtil.BuildEncrypt(txtAPICode.Text.Trim());
            }
            //Build lại license thì mặc định là active lại cho license đó
            CompanyLicenseItem.IsActive = true;
            btnActive.Text = "Deactive";
            btnActive.Enabled = false;
        }

        private void SaveLicense()
        {
            if (string.IsNullOrEmpty(txtLicenseCode.Text.Trim()) || string.IsNullOrEmpty(txtLicenseKey.Text.Trim()))
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
            CompanyLicenseItem.LicenseCode = txtLicenseCode.Text.Trim();
            CompanyLicenseItem.LicenseKey = txtLicenseKey.Text.Trim();
            CompanyLicenseItem.ExpDate = date_ExpDate.DateTime;
            CompanyLicenseItem.CreateDate = DateTime.Now;
            CompanyLicenseItem.FK_CompanyID = (int)inputLookUp_Company.EditValue;
            CompanyLicenseItem.IsActive = true;
            CompanyLicenseItem.LicenseTaxiAPI = txtAPIKey.Text.Trim();
            CompanyLicenseItem.LicenseTaxiAPI_Code = txtAPICode.Text.Trim();
            CompanyLicenseItem.Notes = txtNote.Text.Trim();
            CompanyLicenseItem.Update();
            if (APILicense.Inst.UpdateAPI(CompanyLicenseItem.FK_CompanyID, CompanyLicenseItem.LicenseTaxiAPI_Code, CompanyLicenseItem.LicenseTaxiAPI))
            {
                MessageBox.Show("Lưu thành công, License này đã có thể sử dụng cho KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi chưa lưu được license, Vui lòng thử lại !", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyLicenseToClipBoard()
        {
            string license = "";
            license = string.Format("API Key : {2}\r\nLicense Code : {0}\r\nLicense Key : {1}", txtLicenseCode.Text, txtLicenseKey.Text, txtAPIKey.Text);
            Clipboard.SetText(license);
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                
            }
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                RefreshForm();
                bool valid = false;
                lblMsg.Text = "";
                CompanyLicenseItem = (CompanyLicense)gridView.GetRow(e.RowHandle);
                if (CompanyLicenseItem != null)
                {
                    txtLicenseCode.Text = CompanyLicenseItem.LicenseCode;
                    txtLicenseKey.Text = CompanyLicenseItem.LicenseKey;
                    txtAPIKey.Text = CompanyLicenseItem.LicenseTaxiAPI;
                    txtAPICode.Text = CompanyLicenseItem.LicenseTaxiAPI_Code;
                    txtNote.Text = CompanyLicenseItem.Notes;
                    date_ExpDate.DateTime = CompanyLicenseItem.ExpDate;
                    inputLookUp_Company.EditValue = CompanyLicenseItem.FK_CompanyID;
                    int requestID = CompanyLicense.Inst.GetRequestIDByCompanyLicenseId(CompanyLicenseItem.Id);
                    if (requestID > 0)
                    {
                        ResponsedItem = RequestLicenseResponsed.Inst.GetResponsedByID(requestID);
                        if (ResponsedItem != null)
                        {
                            lblCompanyName.Text = ResponsedItem.CompName;
                            lblCpuId.Text = ResponsedItem.CPUID;
                            lblMacAddress.Text = ResponsedItem.MacAddress;
                            lblPhone.Text = ResponsedItem.PhoneNumber;

                            valid = true;
                        }
                    }

                    if (CompanyLicenseItem.IsActive)
                    {
                        btnActive.Text = "Deactive";
                    }
                    else
                    {
                        btnActive.Text = "Active"; 
                    }
                    btnActive.Enabled = valid;
                    btnBuildLicense.Enabled = valid;
                    btnCopy.Enabled = valid;
                    btnSave.Enabled = valid;
                    if (!valid)
                    {
                        lblMsg.Text = "Request license not found";                        
                    }
                }
            }
        }

        private void btnBuildLicense_Click(object sender, EventArgs e)
        {
            BuildLicense();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLicense();
            RefreshForm();
            LoadData();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (CompanyLicense.Inst.ActiveLicense(!CompanyLicenseItem.IsActive, CompanyLicenseItem.Id))
            {
                MessageBox.Show("{0} successfull", btnActive.Text);
                RefreshForm();
                LoadData();
            }
            else
            {
                MessageBox.Show("{0} fail", btnActive.Text);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyLicenseToClipBoard();
        }
    }
}
