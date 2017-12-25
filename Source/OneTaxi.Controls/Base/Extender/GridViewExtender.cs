using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Staxi.Utils.DbBase;
using Staxi.Utils.Extender;
namespace OneTaxi.Controls.Base.Extender
{
    /// <summary>
    /// Phương thức mở rộng cho GridView
    /// </summary>
    public static class GridViewExtender
    {
        /// <summary>
        /// Lấy ra thông tin của một Cell
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        public static GridCellInfo GetFocusedCell(this GridView gv, GridColumn column)
        {               
            return ((GridViewInfo)gv.GetViewInfo()).GetGridCellInfo(gv.FocusedRowHandle, column);
        }

        /// <summary>
        /// Lấy ra Row đang Focused
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gv"></param>
        /// <returns></returns>
        public static T GetFocusedRow<T>(this GridView gv)
        {
            // Lấy ra Row Focus
            int rowIndex = gv.FocusedRowHandle;

            // Nếu không row nào được chọn thì thoát
            if (rowIndex < 0) return default(T);

            // Lấy ra row đang Focused
            return gv.GetRow(rowIndex).As<T>();
        }

        /// <summary>
        /// Tạo một cột mới
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        public static GridColumn CreateNewGridColumn(this GridView gv, string caption, bool isAddToGridView = true)
        {
            // Tạo một cột mới
            var gc = new GridColumn();

            // Khởi tạo thông số cho Column
            gc.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gc.AppearanceHeader.Options.UseFont = true;
            gc.AppearanceHeader.Options.UseTextOptions = true;
            gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gc.Caption = caption;
            gc.Visible = true;
            gc.VisibleIndex = gv.Columns.Count;

            // Đưa cột vào GridView
            if (isAddToGridView) gv.Columns.Add(gc);

            // return cột
            return gc;
        }

        /// <summary>
        /// Lấy ra mảng cột
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static GridColumn[] GetColumns(this GridView gv, params string[] columnName)
        {
            GridColumn[] columns = new GridColumn[columnName.Length];

            for (int i = 0; i < columnName.Length; i++)
                columns[i] = gv.Columns[columnName[i]];

            return columns;
        }

        /// <summary>
        /// Đưa IRepository lên Column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gv"></param>
        /// <param name="columnName"></param>
        public static T Add<T>(this GridView gv, params string[] columnName) where T : RepositoryItem, IBindControl, new()
        {
            // Khởi tạo IRepository
            T t = new T();

            t.NullText = "";

            // Đưa vào Grid
            t.AddToGrid(gv, columnName);

            // return t
            return t;
        }

        /// <summary>
        /// Đưa IRepository lên Column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gv"></param>
        /// <param name="columnName"></param>
        public static T Add<T>(this GridView gv, Action<T> action, params string[] columnName) where T : RepositoryItem, IBindControl, new()
        {
            // Khởi tạo IRepository
            T t = new T();

            // Khởi tạo
            action(t);

            // Đưa vào Grid
            t.AddToGrid(gv, columnName);

            // return t
            return t;
        }

        /// <summary>
        /// Đưa IRepository lên Column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="gv"></param>
        /// <param name="func"></param>
        /// <param name="columnName"></param>
        public static T Add<T, TModel>(this GridView gv, Func<List<TModel>> func, params string[] columnName)
            where T : RepositoryItem, IBindControl, IRepository<TModel>, new()
            where TModel : ModelBase, new()
        {
            // Khởi tạo IRepository
            T t = new T();

            // Function lấy dữ liệu
            t.Func = func;

            // Đưa vào Grid
            t.AddToGrid(gv, columnName);

            // return
            return t;
        }

        /// <summary>
        /// Gắn Reposity với một data có sẵn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="gv"></param>
        /// <param name="data"></param>
        /// <param name="columnName"></param>
        public static T Add<T, TModel>(this GridView gv, List<TModel> data, params string[] columnName)
            where T : RepositoryItem, IBindControl, IRepository<TModel>, new()
            where TModel : ModelBase, new()
        {
            // Khởi tạo
            T t = new T();

            // Gắn dữ liệu
            t.Func = () => data;

            // Đưa vào Grid
            t.AddToGrid(gv, columnName);

            // return
            return t;
        }

        /// <summary>
        /// Tạo cột xóa
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        public static GridColumn CreateColumnDelete(this GridView gv, RepositoryItemPictureEdit ripDelete, bool isAddToGridView = true)
        {
            // Khởi tạo một cột
            var gc = gv.CreateNewGridColumn("Xóa", isAddToGridView);

            // Độ rộng
            gc.Width = 40;

            // Field Name
            gc.FieldName = "Delete";

            // Unbound
            gc.UnboundType = UnboundColumnType.String;

            gc.Fixed = FixedStyle.Right;

            // RepositoryItemPictureEdit
            gc.ColumnEdit = ripDelete;

            // 
            return gc;
        }

        /// <summary>
        /// Tạo cột cho GridBand
        /// </summary>
        /// <param name="gcc"></param>
        /// <param name="field"></param>
        /// <param name="caption"></param>
        /// <param name="header"></param>
        /// <param name="cell"></param>
        public static void CreateColumn(this GridBandColumnCollection gcc, string field, string caption, Color header, Color cell, int width = 40)
        {
            var gc = new BandedGridColumn { Caption = caption, FieldName = field, Visible = true, Width = width };
            gc.AppearanceCell.Options.UseTextOptions = gc.OptionsColumn.FixedWidth = true;
            gcc.Add(gc);
            gc.AppearanceHeader.TextOptions.HAlignment = gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gc.OptionsFilter.AllowFilter = false;
            gc.OptionsColumn.AllowSort = DefaultBoolean.False;
            gc.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            

            if (header != Color.Empty) gc.AppearanceHeader.BackColor = header;
            if (cell != Color.Empty) gc.AppearanceCell.BackColor = cell;
        }
    }
}
