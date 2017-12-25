using Aspose.Cells;
using Taxi.Common.Extender;
using System.Linq;
using System;
namespace Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders
{
    /// <summary>
    /// Thực hiện Binder theo group
    /// </summary>
    public class GridGroupBinder : GridBinder
    {
        /// <summary>
        /// Thực hiện Bind dữ liệu vào excel
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public override int Bind(Workbook workbook, object data)
        {
            // Tìm field mà muốn group
            var rCol = ListReportColumnInfo.FirstOrDefault(rc => rc.CellSpan == CellSpan.Column);

            // Ẩn các cột mà đã được group theo column đi
            AllColumns.Join(ListReportColumnInfo.Where(rc => rc.CellSpan == CellSpan.Column), c => c.FieldName, rc => rc.Column, (c, rc) => c.Visible = false).Count();

            // Tổng số cột
            var totalColumn = AllColumns.Where(c => c.Visible).Count();

            // Nếu không có thì thực hiện bind như grid bình thường
            if (rCol == null) return base.Bind(workbook, data);

            // Thực hiện group các column lại
            var group = data.CastToList().GroupBy(d => Convert.ToString(d.Eval(rCol.Column)));

            // khai báo row bắt đầu thực hiện
            var startRow = RowBegin;

            // 
            var sheet = workbook.Worksheets[0];
            var columnGroups = ListReportColumnInfo.Where(c => c.CellSpan == CellSpan.Column);

            // Thực hiện bind theo từng group
            foreach (var g in group)
            {
                var dataGroup = g.ToList();
                var firstDataGroup = dataGroup.First();

                foreach (var cg in columnGroups)
                {
                    for (var i = CellStart + 1; i <= totalColumn + CellStart; i++)
                        sheet.Cells[startRow, i].SetStyle(ExcelBinderBase.StyleHeader);
                        // sheet.Cells.CreateRange(startRow, CellStart + 1, 1, totalColumn).SetStyle(ExcelBinderBase.StyleHeader);
                    sheet.Cells.Merge(startRow, CellStart + 1, 1, totalColumn);
                    var obj = firstDataGroup.Eval(cg.Column);
                    if (obj is DateTime) obj = string.Format("{0:dd/MM/yyyy}", obj);
                    sheet.Cells[startRow, CellStart + 1].PutValue(obj);
                    startRow++;
                }

                startRow--;

                // Bind header
                startRow = BindHeader(workbook, startRow);

                // Bind nội dung
                startRow = BindContent(workbook, dataGroup, startRow);
            }

            // 
            return 0;
        }
    }
}
