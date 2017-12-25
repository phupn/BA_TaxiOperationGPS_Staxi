using Aspose.Cells;

namespace Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders
{
    /// <summary>
    /// Thực hiện bind theo thông tin của Grid
    /// </summary>
    public partial class GridBinder : ExcelBinderBase
    {
        /// <summary>
        /// Thực hiện binding
        /// </summary>
        public override int Bind(Workbook workbook, object data)
        {
            #region Khắc phục lỗi numbers stored as text option
            var opts = workbook.Worksheets[0].ErrorCheckOptions;
            var index = opts.Add();
            var opt = opts[index];
            //Disable the numbers stored as text option
            opt.SetErrorCheck(ErrorCheckType.TextNumber, false);
            //Set the range
            opt.AddRange(CellArea.CreateCellArea(0, 0, 65535, 256));
            #endregion

            // Tạo Header
            var rowStart = BindHeader(workbook, RowBegin);

            // Bind nội dung
            return BindContent(workbook, data, rowStart);
        }

        /// <summary>
        /// 
        /// </summary>
        private class CellValue
        {
            private object value = null;
            /// <summary>
            /// 
            /// </summary>
            public object Value
            {
                get { return this.value; }
                set { this.value = value ?? string.Empty; }
            }

            /// <summary>
            /// 
            /// </summary>
            public int RowStart { set; get; }
        }
    }

    
}
