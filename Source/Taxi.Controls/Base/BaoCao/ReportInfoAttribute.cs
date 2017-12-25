using System;
using Taxi.Controls.BaoCao.ExcelBinders;
using Taxi.Utils;
namespace Taxi.Controls.BaoCao
{
    /// <summary>
    /// Thông tin về báo cáo
    /// </summary>
    public class ReportInfoAttribute : Attribute
    {
        /// <summary>
        /// Tiêu đề báo cáo
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// Kiểu bind dữ liệu vào Excel
        /// </summary>
        public ExcelBinderType BinderType { set; get; }

        private bool autoAscending = true;
        /// <summary>
        /// Có tự động tăng dần hay không
        /// </summary>
        public bool AutoAscending
        {
            get { return autoAscending; }
            set { autoAscending = value; }
        }

        /// <summary>
        /// Type của đối tượng IReportData
        /// </summary>
        public Type TypeReportData { set; get; }
    }
}
