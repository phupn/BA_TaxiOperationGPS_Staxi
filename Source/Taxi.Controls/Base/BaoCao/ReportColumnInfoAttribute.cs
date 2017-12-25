using System;
namespace Taxi.Controls.BaoCao
{
    /// <summary>
    /// Thông tin cho cột báo cáo
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ReportColumnInfoAttribute : Attribute
    {
        /// <summary>
        /// Tên cột => gắn với tên field nhé
        /// </summary>
        public string Column { set; get; }

        /// <summary>
        /// Chọn RowSpan hoặc ColumnSpan
        /// </summary>
        public CellSpan CellSpan { set; get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum CellSpan
    { 
        Row = 0,
        Column = 1
    }
}
