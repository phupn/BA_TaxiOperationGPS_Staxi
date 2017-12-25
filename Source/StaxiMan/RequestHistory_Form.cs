using System;
using StaxiMan_DAL;
using Taxi.Logger;

namespace StaxiMan
{
    public partial class RequestHistory_Form : StaxiMan_FormBase
    {
        public RequestHistory_Form()
        {
            InitializeComponent();
            ResetForm();
        }
        public RequestHistory_Form(DateTime fromDateTime, DateTime toDateTime, string phoneNumber, string companyName)
        {
            InitializeComponent();
            fromDate.DateTime = fromDateTime;
            toDate.DateTime = toDateTime;
            txtPhoneNumber.Text = phoneNumber;
            txtCompanyName.Text = companyName;
        }

        private void btnSearch_Click(object sender, EventArgs e) 
        {
            try
            {
                SearchHistoryData(fromDate.DateTime, toDate.DateTime, txtPhoneNumber.Text, txtCompanyName.Text);                
            }
            catch(Exception ex)
            {
                LogError.WriteLogError("btnSave_Click: ", ex);
            }
        }

        private void SearchHistoryData(DateTime fromDateTime, DateTime toDateTime, string phoneNumber, string companyName)
        {
            try
            {
                var listData = RequestLicenseResponsed.Inst.SearchLicenseResponsed(fromDateTime.Date, toDateTime.Date.AddHours(24),phoneNumber, companyName);
                gridData.DataSource = listData;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SearchHistoryData: ",ex);
            }
        }

        private void RequestHistory_Form_Load(object sender, EventArgs e)
        {
            try
            {
                SearchHistoryData(fromDate.DateTime, toDate.DateTime, txtPhoneNumber.Text, txtCompanyName.Text);
            }
            catch(Exception ex)
            {
                LogError.WriteLogError("RequestHistory_Form_Load: ", ex);
            }
        }

        private void ResetForm()
        {
            fromDate.EditValue = DALCommon.Inst.GetTimeServer().Date.AddDays(-7);
            toDate.EditValue   = DALCommon.Inst.GetTimeServer().Date.AddDays(1);
            txtPhoneNumber.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
