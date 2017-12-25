using DevExpress.XtraGrid;
using DevExpress.Utils;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using DevExpress.Data;
using Taxi.Common.Extender;
using System.Linq;
using System;
namespace Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders
{
    /// <summary>
    /// Thông tin config của cột
    /// </summary>
    public class ColumnConfig
    {
        private Collection<ColumnConfig> columns = new Collection<ColumnConfig>();
        /// <summary>
        /// Thông tin các cột con
        /// </summary>
        public Collection<ColumnConfig> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        /// <summary>
        /// Tiêu đề của column
        /// </summary>
        public string Caption { set; get; }

        private bool visible = true;
        /// <summary>
        /// Có hiển thị hay không
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        /// <summary>
        /// Field Name
        /// </summary>
        public string FieldName { set; get; }

        private int width = 80;
        /// <summary>
        /// Độ dài của column
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int groupIndex = -1;
        /// <summary>
        /// Group
        /// </summary>
        public int GroupIndex
        {
            get { return groupIndex; }
            set { groupIndex = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public GridSummaryItem SummaryItem { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public AppearanceObjectEx AppearanceCell { set; get; }

        /// <summary>
        /// FormatInfo
        /// </summary>
        public FormatInfo DisplayFormat { set; get; }

        /// <summary>
        /// GetCell
        /// </summary>
        /// <param name="dataItem"></param>
        /// <returns></returns>
        public object GetValue(object dataItem)
        {
            try
            {
                if (string.IsNullOrEmpty(FieldName))
                    return string.Empty;
                return string.IsNullOrEmpty(DisplayFormat.FormatString) ? dataItem.Eval(FieldName) : string.Format("{0:" + DisplayFormat.FormatString + "}", dataItem.Eval(FieldName));
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            
        }

        /// <summary>
        /// Lấy ra thông tin cột
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<ColumnRange>> GetColumnRanges()
        {
            var rows = new Dictionary<int, List<ColumnRange>>();
            var dicStart = new Dictionary<int, int>();

            // Lấy những cột được hiển thị
            // var columnsVisibles = Columns.Where(c => c.Visible).ToList();
            var columnsVisibles = Columns.Where(c => CheckVisible(c)).ToList();

            for (var i = 0; i < columnsVisibles.Count; i++)
                DoGetColumns(rows, 1, columnsVisibles[i], dicStart);

            var dic = new Dictionary<string, List<ColumnRange>>();

            // Tìm rowspan cho từng cột
            if (rows.Count > 1)
            {
                var listRows = rows.ToList();
                for (var i = 0; i < listRows.Count - 1; i++)
                {
                    var row = listRows[i];
                    for (var j = i + 1; j < listRows.Count; j++)
                    {
                        var rowBelow = listRows[j];
                        for (var k = 0; k < row.Value.Count; k++)
                        {
                            var column = row.Value[k];
                            if (column.ColumnConfig.FieldName == "STT")
                            {
                                column.Row = rows.Count;
                                continue;
                            }

                            //if (!(rowBelow.Value.Count(rb => rb.From == column.From) > 0 && rowBelow.Value.Count(rb => rb.To == column.To) > 0))
                            //    column.Row++;

                            // => xem đoạn comment đánh dấu xxxxx
                            foreach (var columnBelow in rowBelow.Value)
                            {
                                if (column.From == columnBelow.From && column.To == columnBelow.To)
                                {
                                    var key = column.From + "_" + column.To;
                                    List<ColumnRange> list = null;
                                    if (!dic.ContainsKey(key)) dic[key] = list = new List<ColumnRange>();
                                    else list = dic[key];

                                    list.Add(column); list.Add(columnBelow);
                                    column.Right = columnBelow.Right = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            // Anh Sơn fix đoạn này, sau này thằng nào giỏi hơn anh thì vào sửa nhé - xxxxx            
            foreach (var di in dic)
            {
                if (di.Value.Count(c => !string.IsNullOrEmpty(c.ColumnConfig.Caption)) == di.Value.Count)
                {
                    di.Value.ForEach(c => c.Right = true);
                }
                else
                {
                    var c0 = di.Value.First();
                    var c1 = di.Value.First(dt => !string.IsNullOrEmpty(dt.ColumnConfig.Caption));
                    c0.Right = true;
                    c0.ColumnConfig.Caption = c1.ColumnConfig.Caption;
                    c0.Row = rows.Count;
                    c0.ColumnConfig.Width = c1.ColumnConfig.Width;
                    c0.TotalMerge = c0.From;
                }
            }

            return rows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private void DoGetColumns(Dictionary<int, List<ColumnRange>> dic, int row, ColumnConfig column, Dictionary<int, int> start)
        { 
            List<ColumnRange> crs = null;
            if (!dic.ContainsKey(row)) dic[row] = crs = new List<ColumnRange>();
            else crs = dic[row];

            if (!start.ContainsKey(row)) start[row] = 1;

            var cr = new ColumnRange();
            cr.From = start[row];
            var totalColumns = FindColumn(column).Where(c => c.Visible);
            var countColumn = totalColumns.Count();

            if (countColumn > 1) cr.TotalMerge = start[row] + countColumn;
            else cr.TotalMerge = start[row] + countColumn;

            cr.Width = totalColumns.Sum(c => c.Width);
            if (cr.Width == 0) cr.Width = column.Width;
            cr.Row = 1;
            cr.ColumnConfig = column;
            crs.Add(cr);

            var beginRowAfter = start[row];

            // if (countColumn > 1) start[row] = cr.TotalMerge;
            if (countColumn >= 1) start[row] = cr.TotalMerge;
            else start[row] = cr.TotalMerge + 1;

            // Chỉ lấy những cột được hiển thị
            // var columnVisibles = column.Columns.Where(c => c.Visible).ToList();
            var columnVisibles = column.Columns.Where(c => CheckVisible(c)).ToList();

            for (int i = 0; i < columnVisibles.Count; i++)
            {
                if (!start.ContainsKey(row + 1)) start[row + 1] = beginRowAfter;
                DoGetColumns(dic, row + 1, columnVisibles[i], start);
            }
        }

        /// <summary>
        /// Tìm column
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public IEnumerable<ColumnConfig> FindColumn(ColumnConfig column, bool first = true)
        {
            if (!first && column.Columns.Count == 0) yield return column;

            else
            {
                foreach (var c in column.Columns)
                {
                    var min = FindColumn(c, false);
                    foreach (var cm in min)
                        yield return cm;
                }
            }

            //var columns = column.Columns;
            //return columns.Concat(columns.SelectMany(ctrl => FindColumn(ctrl)));
        }

        private bool CheckVisible(ColumnConfig c)
        {
            if (c.Columns.Count > 0)
            {
                var total = 0;
                for (int i = 0; i < c.Columns.Count; i++)
                {
                    if (!CheckVisible(c.Columns[i])) total++;
                }

                if (total == c.columns.Count) return false;
            }

            return c.Visible;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ColumnRange
    {
        public int From { set; get; }
        public int TotalMerge { set; get; }
        public int To
        {
            get
            {
                return TotalMerge == From ? From : TotalMerge - 1;
            }
        }
        public int Row { set; get; }
        public int Width { set; get; }

        /// <summary>
        /// ColumnConfig
        /// </summary>
        public ColumnConfig ColumnConfig { set; get; }

        private bool right = true;
        /// <summary>
        /// 
        /// </summary>
        public bool Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}
