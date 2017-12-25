using System;
using Taxi.Common.Attributes.Validator;
using Taxi.Common.DbBase.Attributes;

namespace Taxi.Controls.BaoCao
{
    /// <summary>
    /// FormBase cho báo cáo tìm theo nhiều tháng
    /// </summary>
    public partial class FrmReportInRangeMonth : FrmReportByMonthBase
    {
        #region Thông tin tìm kiếm báo cáo
        /// <summary>
        /// Tìm kiếm từ tháng nào
        /// </summary>
        [Field(Name = "Từ tháng")]
        [ValidatorRequire]
        public int? FromMonth { set; get; }

        /// <summary>
        /// Tìm kiếm đến tháng nào
        /// </summary>
        [Field(Name = "Đến tháng")]
        [ValidatorRequire]
        [ValidatorGreater("FromMonth")]
        public int? ToMonth { set; get; }

        /// <summary>
        /// Tìm kiếm năm nào
        /// </summary>
        [Field(Name = "Năm")]
        [ValidatorRequire]
        public int? Year { set; get; }
        #endregion

        /// <summary>
        /// Tiêu đề báo cáo
        /// </summary>
        /// <returns></returns>
        protected override string GetReportDateTitle()
        {
            return FromMonth == ToMonth ? ("Tháng " + FromMonth + " năm " + Year) : ("Từ tháng " + FromMonth + " đến tháng " + ToMonth + " năm " + Year);
        }

        /// <summary>
        /// Sau khi tải Form
        /// </summary>
        protected override void AfterLoad()
        {
            ipMonth.SetValue("1");
            ipYear.SetValue(DateTime.Today.Year.ToString());
            ipToMonth.SetValue(DateTime.Today.Month.ToString());
            //base.AfterLoad();

            ipMonthYear_EditValueChanged(null, null);
        }
    }
}
