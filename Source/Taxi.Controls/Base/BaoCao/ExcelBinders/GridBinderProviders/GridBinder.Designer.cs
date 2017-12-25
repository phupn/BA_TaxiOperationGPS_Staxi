using DevExpress.XtraGrid;
using System.Collections.Generic;
using Taxi.Common.Extender;
using Aspose.Cells;
using System.Linq;
using DevExpress.Utils;
namespace Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GridBinder
    {
        /// <summary>
        /// Thông tin của Grid
        /// </summary>
        public GridControl Grid { set; get; }

        private List<ReportColumnInfoAttribute> listReportColumnInfo = null;
        /// <summary>
        /// Danh sách các thông tin về cột của báo cáo
        /// </summary>
        public List<ReportColumnInfoAttribute> ListReportColumnInfo
        {
            get 
            {
                if (listReportColumnInfo == null)
                    listReportColumnInfo = Target.GetType().GetListAttribute<ReportColumnInfoAttribute>();
                return listReportColumnInfo; 
            }
        }

        private ColumnConfig columnConfig = null;
        /// <summary>
        /// Thực hiện lấy thông tin về các cột trong grid
        /// </summary>
        public ColumnConfig ColumnConfig
        {
            get 
            {
                if (columnConfig == null)
                {
                    columnConfig = ReportGridChain.Inst.GetConfig(Grid);
                    if (Target.ReportInfo==null||Target.ReportInfo.AutoAscending)
                    {
                        var cc = new AppearanceObjectEx { };
                        cc.TextOptions.HAlignment = HorzAlignment.Center;
                        columnConfig.Columns.Insert(0, new ColumnConfig { Caption = "STT", FieldName = "STT", Width = 40, AppearanceCell = cc });
                    }
                }
                return columnConfig; 
            }
        }

        private Dictionary<int, List<ColumnRange>> _columnRange;

        public Dictionary<int, List<ColumnRange>> ColumnRange
        {
            get
            {
                if (_columnRange == null) _columnRange = ColumnConfig.GetColumnRanges();
                return _columnRange;
            }
        }

        private List<ColumnConfig> allColumns = null;
        /// <summary>
        /// Tất cả các cột cần bind
        /// </summary>
        public List<ColumnConfig> AllColumns
        {
            get 
            {
                if (allColumns == null)
                    allColumns = ColumnConfig.FindColumn(columnConfig).ToList();
                return allColumns; 
            }
        }

        /// <summary>
        /// BindHeader
        /// </summary>
        /// <param name="workbook"></param>
        protected int BindHeader(Workbook workbook, int start)
        {
            // Thông số config cho header
            var configHeader = ColumnRange;

            //
            var sheet = workbook.Worksheets[0];

            // Row bắt đầu fill dữ liệu
            var rowStart = start; 

            // Lưu trữ row và column hiện thời đang fill dữ liệu
            int row = 0, column = 0;

            // Khởi tạo Header
            foreach (var rowConfig in configHeader)
            {
                var cells = rowConfig.Value.Where(c=> c.Right).ToList();

                for (int i = 0; i < cells.Count; i++)
                {
                    var cellConfig = cells[i];

                    row = rowStart + rowConfig.Key;
                    column = cellConfig.From + CellStart;

                    // Thiết lập tiêu đề cho cột
                    sheet.Cells[row, column].PutValue(cellConfig.ColumnConfig.Caption);
                    sheet.Cells[row, column].SetStyle(ExcelBinderBase.StyleHeader);

                    // Thực hiện merge cột
                    // if (cellConfig.Row != 1 || cellConfig.To - cellConfig.From != 0)
                    if (cellConfig.Row != 0 && cellConfig.TotalMerge - cellConfig.From != 0)
                    {
                        for (var z = 0; z < cellConfig.TotalMerge - cellConfig.From; z++)
                            sheet.Cells[row, column + z].SetStyle(ExcelBinderBase.StyleHeader);
                        try
                        {
                            sheet.Cells.Merge(row, column, cellConfig.Row, cellConfig.TotalMerge - cellConfig.From);
                        }
                        catch { }
                    }

                    // Merge row
                    if (cellConfig.Row > 1)
                    {
                        for (var z = 0; z < cellConfig.Row; z++)
                            sheet.Cells[row + z, column].SetStyle(ExcelBinderBase.StyleHeader);
                        try
                        {
                            sheet.Cells.Merge(row, column, cellConfig.Row, 1);
                            sheet.Cells.CreateRange(row, column, cellConfig.Row, 1).Value = cellConfig.ColumnConfig.Caption;
                        }
                        catch { }
                    }

                    // Thiết lập độ rộng cho cột
                    if (cellConfig.From == cellConfig.TotalMerge) sheet.Cells.SetColumnWidthPixel(column, cellConfig.Width);
                }
            }

            rowStart += configHeader.Max(d => d.Key) + 1;

            // 
            return rowStart;
        }

        /// <summary>
        /// Bind nội dung
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="data"></param>
        /// <param name="rowStart"></param>
        /// <returns></returns>
        protected int BindContent(Workbook workbook, object data, int rowStart)
        {
            var list = data.CastToList();

            // Khởi tạo dic lưu các cell cần thực hiện RowSpan
            var cellRowSpans = ListReportColumnInfo.Where(rc => rc.CellSpan == CellSpan.Row).ToDictionary(rc => rc.Column, rc => new CellValue { Value = null });

            // Lưu trữ row và column hiện thời đang fill dữ liệu
            int row = 0, column = 0;

            var sheet = workbook.Worksheets[0];

            // Lấy các cột được hiển thị thôi
            var columnVisibles = AllColumns.Where(c => c.Visible).ToList();

            for (var i =0; i < list.Count;i++)
            {
                var dataItem = list[i];
                row = rowStart;
                column = CellStart + 1;

                foreach (var cellConfig in columnVisibles)
                {
                   
                   // else value = value.ToString();
                    // Điền dữ liệu lên cell
                     //Khắc phục lỗi khi có số 0 ở đầu mà k muốn bỏ
                    //if (value.ToString().Length > 1 && value.ToString().StartsWith("0"))
                    //{
                    //    sheet.Cells[row, column].PutValue(value.ToString(), false);
                    //}
                    // else sheet.Cells[row, column].PutValue(value.ToString(), true);
                    Style styleCell = ExcelBinderBase.StyleCell;
                    // Căn cột
                    if (cellConfig.AppearanceCell != null)
                        switch (cellConfig.AppearanceCell.TextOptions.HAlignment)
                        { 
                            case HorzAlignment.Center:
                                styleCell=ExcelBinderBase.StyleCellCenter;
                                break;
                            case HorzAlignment.Far:
                                 styleCell=ExcelBinderBase.StyleCellRight;
                                break;
                            case HorzAlignment.Near:
                                 styleCell=ExcelBinderBase.StyleCellLeft;
                                break;
                            default:
                                styleCell = ExcelBinderBase.StyleCellLeft;
                                break;
                        }
                    else
                         styleCell=ExcelBinderBase.StyleCellLeft;
                    
                    var value = cellConfig.FieldName.Equals("STT") ? (i + 1) : cellConfig.GetValue(dataItem);

                    if (value == null) value = string.Empty;
                    if (value is bool)
                    {
                        value = (bool)value ? "X" : "";
                        styleCell = ExcelBinderBase.StyleCell;
                    }
                    double r = 0;
                    if (value.ToString() != string.Empty && double.TryParse(value.ToString(), out r) && cellConfig.DisplayFormat!=null&&!cellConfig.DisplayFormat.IsEmpty)
                    {
                        if (r - (double)((long)r) != 0)
                        {
                            styleCell.Custom = string.Format(@"#,##0.##");
                        }
                        else
                        {
                            styleCell.Custom = string.Format(@"#,##0");
                        }
                        value = r;
                    }
                       
                    sheet.Cells[row, column].PutValue(value);
                    sheet.Cells[row, column].SetStyle(styleCell);
                    // Tìm cell rowspan
                    if (cellRowSpans.ContainsKey(cellConfig.FieldName))
                    {
                        var cellValue = cellRowSpans[cellConfig.FieldName];
                        if (cellValue.RowStart == 0)
                        {
                            cellValue.Value = value;
                            cellValue.RowStart = row;
                        }
                        else
                        {
                            // Nếu thay đổi giá trị thì bắt đầu thiết lập rowspan
                            if (!cellValue.Value.Equals(value))
                            {
                                cellValue.RowStart = row;
                                cellValue.Value = value;
                            }
                            else sheet.Cells.Merge(cellValue.RowStart, column, row - cellValue.RowStart + 1, 1);
                        }
                    }

                    column++;
                }

                rowStart++;
            }

            // Trả về Row cuối cùng
            return rowStart;
        }
    }
}
