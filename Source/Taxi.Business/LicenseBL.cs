using System;
using Taxi.Data;
using System.Data;
using Taxi.Utils;
using System.Windows.Forms;
using Taxi.MessageBox;


namespace Taxi.Business
{
    public class LicenseBL
    {
        public string LicenseKey { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Cập nhật license vào db
        /// </summary>
        public bool UpdateLicense(string pLicenseKey, DateTime pFromDate, DateTime pToDate)
        {
            return new LicenseDA().UpdateLicense(pLicenseKey, pFromDate, pToDate);
        }

        /// <summary>
        /// Lấy thông tin license từ DB
        /// </summary>
        public LicenseBL GetLicense()
        {
            try
            {
                DataTable dt = new LicenseDA().GetLicense();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return new LicenseBL
                    {
                        LicenseKey = dr["LicenseKey"].ToString(),
                        FromDate = Convert.ToDateTime(dr["FromDate"].ToString()),
                        ToDate = Convert.ToDateTime(dr["ToDate"].ToString())
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Check license
        /// </summary>        
        public void CheckLicense()
        {
            //if (Debugger.IsAttached) return;//*sign
            if (ExceptionCompany())
                return;           
            try
            {
                string message = "";
                LicenseEntity objLicense = new LicenseEntity();
                string pCode = string.Empty;
                string pKey = string.Empty;
                DateTime pDate = CommonBL.GetTimeServer();
                DataTable dtTemp = objLicense.GetAll();
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    pCode = dtTemp.Rows[0]["LicenseCode"].ToString();
                    pKey = dtTemp.Rows[0]["LicenseKey"].ToString();
                    //pDate = dtTemp.Rows[0]["CreatedDate"].To<DateTime>(); 
                    string strCPUID = "";
                    string strMacAddress = objLicense.GetServerInformation(out strCPUID);
                    var hasValid = BALicenseManager.CheckValidateLicense(pCode, pKey, pDate, strMacAddress, strCPUID);
                    if (hasValid < 0)
                    {
                        message = string.Format("{0}:Mã xác thực License Key không hợp lệ. Vui lòng liên hệ nhà cung cấp", hasValid);
                        new MessageBoxBA().Show(message, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        Application.Exit();
                    }
                    else if (hasValid > 1)
                    {
                        message = string.Format("Bản quyền còn {0} ngày nữa sẽ hết hạn. Vui lòng liên hệ nhà cung cấp", hasValid);
                        new MessageBoxBA().Show(message, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                    }
                    else if (hasValid == 0)
                    {
                        message = string.Format("Phần mềm đã hết hạn sử dụng. Bạn không được sử dụng phần mềm này nữa");
                        new MessageBoxBA().Show(message, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    message = "Phần mềm đang chưa có bản quyền.";
                    new MessageBoxBA().Show(message, "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LicenseBL CheckLicense", ex);
                new MessageBoxBA().Show("Lỗi.Phần mềm đang chưa có bản quyền.", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
                Application.Exit();
            }
        }

        private bool ExceptionCompany()
        {
            if (license.IsTaxiBaSao)
                return true;            
            if(license.idxCompany==CompanyCode.SaoHaNoi)
                return true;
            return false;
        }
    }
}
