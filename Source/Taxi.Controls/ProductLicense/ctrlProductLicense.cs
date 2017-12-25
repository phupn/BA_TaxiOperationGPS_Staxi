using System;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.MessageBox;
using Taxi.Services;
using Taxi.Utils;

namespace Taxi.Controls.ProductLicense
{
    public partial class ctrlProductLicense : UserControl
    {
        private LicenseEntity _objLicense = new LicenseEntity();
        public static bool CheckSuccess = true;
        private string CPUID { get; set; }
        private string MacAddress { get; set; }
        public ctrlProductLicense()
        {
            InitializeComponent();
            CheckSuccess = false;
        }

        /// <summary>
        /// Lưu vào hệ thống các key
        /// </summary>
        private void btnConfirmLicense_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                CheckSuccess = true;
                if (MacAddress == null)
                {
                    string strCPUID = "";
                    MacAddress = _objLicense.GetServerInformation(out strCPUID);
                    CPUID = strCPUID;
                }
                int licenseTime = BALicenseManager.CheckValidateLicense(txtCodeLicense.Text, txtKeyLicense.Text, DateTime.Now, MacAddress, CPUID);
                if ( licenseTime >= 0)
                {
                    int result = _objLicense.AuthoriseLicenseKey(txtAPIKey.Text, txtKeyLicense.Text, txtCodeLicense.Text, true, -1);
                    if (result != 1)
                    {
                        CheckSuccess = false;
                    }
                    else
                    {
                        new MessageBoxBA().Show("Xác thực hệ thống thành công!");
                    }
                }
                else
                {
                    lblMsg.Text = "Bản quyền không hợp lệ";
                    CheckSuccess = false;
                }
            }
            catch (Exception ex)
            {
                new MessageBoxBA().Show("Lỗi");
                LogError.WriteLogError("btnConfirmLicense_Click:", ex);
                CheckSuccess = true;
            }
        }

        private void btnGetLicenseCode_Click(object sender, EventArgs e)
        {
            string textError = string.Empty;
            Color color = Color.Red;
            lblMsg.Visible = false;
            try
            {
                ThongTinCauHinh.LayThongTinCauHinh();//Lấy cấu hình trực tiếp luôn
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(userName)|| string.IsNullOrEmpty(password))
                {
                    lblMsg.Text = "Vui lòng nhập thông tin tài khoản!!!";
                    txtUserName.Focus();
                    lblMsg.Visible = true;
                    return;
                }

                string strSDT = ThongTinCauHinh.SoDienThoaiCongTy;
                string strTenCongTy = ThongTinCauHinh.TenCongTy;                
                string strCPUID = "BinhAnh";
                MacAddress = _objLicense.GetServerInformation(out strCPUID);
                CPUID = strCPUID;
                if (MacAddress == "" || strCPUID == "")
                {
                    textError = "Thông tin yêu cầu bản quyền không hợp lệ";
                    return;
                }
                int result = StaxiManServices.RequestLicenseKey(userName, password, MacAddress, strCPUID, strSDT, strTenCongTy);
                switch (result)
                {
                    case 0 :
                        textError = "Xử lý thông tin yêu cầu lỗi (0)";
                        break;
                    case -1:
                        textError = "Tài khoản không tồn tại trong hệ thống. Nhập đúng tài khoản để yêu cầu cấp bản quyền";
                        break;
                    case -2:
                        textError = "Xử lý thông tin yêu cầu lỗi (-2)";
                        break;
                    case 1:
                        color = Color.Blue;
                        textError = "Gửi thông tin yêu cầu Thành Công, Vui lòng liên hệ nhà cung cấp để lấy thông tin bản quyền";
                        break;                    
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnGetLicenseCode_Click: ", ex);
                textError = "Gửi thông tin yêu cầu lỗi";
            }
            lblMsg.ForeColor = color;
            lblMsg.Text = textError;
            lblMsg.Visible = true;
        }

    }
}
