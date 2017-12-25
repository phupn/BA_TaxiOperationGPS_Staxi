using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace OneTaxi.Controls.Base.Extender
{
    /// <summary>
    /// Phương thức mở rộng cho RepositoryItem
    /// </summary>
    public static class RepositoryItemExtender
    {
        /// <summary>
        /// Đưa vào Grid
        /// </summary>
        /// <param name="ri"></param>
        /// <param name="grd"></param>
        /// <param name="column"></param>
        public static void AddRepositoryItemToGrid(this RepositoryItem ri, GridControl grd, params GridColumn[] column)
        {
            // Đưa vào Repository
            if (grd != null) grd.RepositoryItems.Add(ri);

            // Đưa vào column
            for (int i = 0; i < column.Length; i++) column[i].ColumnEdit = ri;
        }

        /// <summary>
        /// Thực hiện Add RepositoryItem To Grid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ri"></param>
        public static void AddToGrid<T>(this T ri, GridView gv, params string[] columnName) where T : RepositoryItem, IBindControl
        {
            // Thực hiện Bind dữ liệu
            ri.Bind();

            // Đưa lên GridView
            ri.AddRepositoryItemToGrid(gv.GridControl, gv.GetColumns(columnName));
        }
    }
}
