using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using StaxiMan_DAL;
using Taxi.Logger;
using Taxi.Utils.Settings;

namespace StaxiMan
{
    public partial class StaxiManagement : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CompanyLicense_Form FormCompanyLicense;
        private BuildLicense_Form FormBuildLicense;
        private Company_Form FormCompany;
        public StaxiManagement()
        {
            InitializeComponent();
            Icon = Properties.Resources.Staxi_96_ic_launcher;
            lblMessage.Text = "";
        }

        private void StaxiManagement_Load(object sender, EventArgs e)
        {
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    barStaticItem_ServerInfo.Caption = string.Format("{0}-{1}", ConnectionSetting.MySettingObject.DataSource, ConnectionSetting.MySettingObject.InitialCatalog);
                    barStaticVersion.Caption = Taxi.Utils.license.VersionInfo.Version_License();
                    ConnectionSetting.UseDynamicConnection = false;
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("ShowFormMain", ex);
                    MessageBox.Show("Lỗi load form", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        private void LoadAllData()
        {
            try
            {
                BuildLicenseUtil.ParentCompanyID = DALCommon.ListCompany.Find(C => C.CompanyId == 0).Id;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadAllData: ", ex); 
            }
        }

        private void ShowFormMain()
        {
            try
            {
                if (FormBuildLicense != null)
                {
                    FormBuildLicense.Visible = true;
                }
                else
                {
                    FormBuildLicense = new BuildLicense_Form();
                    FormBuildLicense.Closed += FormBuildLicense_Closed;
                    AddOwnedForm(FormBuildLicense);
                    FormBuildLicense.MdiParent = this;
                    FormBuildLicense.Show();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShowFormMain", ex);
                MessageBox.Show("Lỗi show form");
            }
        }

        private bool ValidateAuthen()
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Fail !!!";
                return false;
            }

            string pass = new BACryptor.Encryption("binhanh.vn").Encrypt(password);
            if (Company_User.Inst.ValidAuthen_Server(userName, pass))
            {
                ribbon.Enabled = true;
                panelMain.Visible = false;
                barAccountInfo.Caption = string.Format("-{0}",userName);
                ShowFormMain(); 
                LoadAllData();
                return true;
            }
            return false;
        }

        private void FormBuildLicense_Closed(object sender, EventArgs e)
        {
            FormBuildLicense.Dispose();
            FormBuildLicense = null;
        }

        private void barButton_BuildLicense_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowFormMain();
        }

        private void barButton_Account_ItemClick(object sender, ItemClickEventArgs e)
        {
            new UserLogin_Form().ShowDialog();
        }

        private void barButton_Request_ItemClick(object sender, ItemClickEventArgs e)
        {
            new RequestHistory_Form().ShowDialog();
        }

        private void barButtonAPILicense_ItemClick(object sender, ItemClickEventArgs e)
        {
            new LicenseAPI_Form().ShowDialog();
        }

        private void barButton_Company_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FormCompany != null)
                {
                    FormCompany.Visible = true;
                    FormCompany.Activate();
                }
                else
                {
                    FormCompany = new Company_Form();
                    FormCompany.Closed += FormCompany_Closed;
                    AddOwnedForm(FormCompany);
                    FormCompany.MdiParent = this;
                    FormCompany.Show();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShowFormMain", ex);
                MessageBox.Show("Lỗi show form");
            }
        }

        private void FormCompany_Closed(object sender, EventArgs e)
        {
            FormCompany.Dispose();
            FormCompany = null;
        }

        private void barButton_License_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FormCompanyLicense != null)
                {
                    FormCompanyLicense.Visible = true;
                    FormCompanyLicense.Activate();
                }
                else
                {
                    FormCompanyLicense = new CompanyLicense_Form();
                    FormCompanyLicense.Closed += FormCompanyLicense_Closed;
                    AddOwnedForm(FormCompanyLicense);
                    FormCompanyLicense.MdiParent = this;
                    FormCompanyLicense.Show();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShowFormMain", ex);
                MessageBox.Show("Lỗi show form");
            }
        }
        private void FormCompanyLicense_Closed(object sender, EventArgs e)
        {
            FormCompanyLicense.Dispose();
            FormCompanyLicense = null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidateAuthen();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtPassword.Text.Trim() == ""){

                    txtPassword.Focus(); 
                }
                else
                {
                    btnLogin.PerformClick();
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUserName.Text.Trim() == "")
                {

                    txtUserName.Focus();
                }
                else
                {
                    btnLogin.PerformClick();
                }
            }

        }

        private void barButtonServerMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            new CompanyDatabaseManagement_Form().Show();
        }

        private void btnConnectMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            new CompanyConnection_Form().Show();
        }

    }
}