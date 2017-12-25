using System;
using Taxi.Common.Extender;
namespace Taxi.Controls.BaoCao
{
    /// <summary>
    /// Form báo cáo tìm theo tháng và năm
    /// </summary>
    public partial class FrmReportByMonthBase : FrmReportBase
    {
        /// <summary>
        /// Nếu như tháng và năm thay đổi
        /// </summary>
        protected void ipMonthYear_EditValueChanged(object sender, EventArgs e)
        {
            var month = ipMonth.GetValue().To<int>();
            var year = ipYear.GetValue().To<int>();
            bool greater = false;
            if (ipYear.GetValue().To<int>() > DateTime.Now.Year)
            {
                greater = true;
            }
            else if (ipYear.GetValue().To<int>() == DateTime.Now.Year)
            {
                if (ipMonth.GetValue().To<int>() > DateTime.Now.Month)
                {
                    greater = true;
                }
            }
            if (greater)
            {
                lbMessage.Text = "Bạn đang chọn tháng lớn hơn tháng hiện tại";
            }
            else
            {
                if (lbMessage.Text.Equals("Bạn đang chọn tháng lớn hơn tháng hiện tại")) lbMessage.Text = string.Empty;
            }
            if (month <1) month = 1;
            ipFromDate.SetValue(new DateTime(year, month, 1));
            ipToDate.SetValue(new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1));
        }

        /// <summary>
        /// Sau khi tải Form
        /// </summary>
        protected override void AfterLoad()
        {
            var month = ipMonth.GetValue().To<int>();
            var year = ipYear.GetValue().To<int>();

            if (month == 1)
            {
              
                ipYear.SetValue((year - 1).ToString());
                ipMonth.SetValue("12");
            }
            else
            {
                ipYear.SetValue(year.ToString());
                ipMonth.SetValue((month - 1).ToString());
            }

            ipMonthYear_EditValueChanged(null, null);
        }
    }
}
