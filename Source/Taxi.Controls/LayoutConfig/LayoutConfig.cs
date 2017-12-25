using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base.Controls;
using Taxi.Data.G5.DanhMuc;

namespace Taxi.Controls.LayoutConfig
{
    public class LayoutConfig
    {
        #region===G5 ConfigLayout===
        /// <summary>
        /// Lấy layout lần lưu gần đây nhất
        /// </summary>
        /// <param name="grid"></param>
        public static void GetLayOutGrid(ShGridControl grid)
        {
            List<ConfigLayout> lstConfigLayout = ConfigLayout.Inst.GetLayoutGrid(grid.Name, ThongTinDangNhap.USER_ID);
            if (lstConfigLayout != null && lstConfigLayout.Count > 0)
            {
                foreach (GridColumn col in ((ColumnView)grid.Views[0]).Columns)
                {
                    ConfigLayout item = lstConfigLayout.Where(x => x.ColumnName == col.Name).First();
                    col.Width = item.Width;
                    col.Visible = item.Visible;
                    col.VisibleIndex = item.VisibleIndex;
                }
            }
        }

        /// <summary>
        /// Lưu lại layout tại thời điểm hiện tại
        /// </summary>
        /// <param name="grid"></param>
        public static void SaveLayoutGrid(ShGridControl grid)
        {
            foreach (GridColumn col in ((ColumnView)grid.Views[0]).Columns)
            {
                ConfigLayout conf = new ConfigLayout();
                conf.GridName = grid.Name;
                conf.ColumnName = col.Name;
                conf.Width = col.Width;
                conf.VisibleIndex = col.VisibleIndex;
                conf.Visible = col.Visible;
                conf.UserID = ThongTinDangNhap.USER_ID;
                conf.SaveLayout();
            }
        }

        public static void SaveLayoutDefault(ShGridControl grid)
        {
            string fileName = Application.StartupPath;
            fileName += "\\LayoutGrid";
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
            fileName += "\\" + grid.Name + "_Layout.xml";
            if (!File.Exists(fileName))
            {
                grid.MainView.SaveLayoutToXml(fileName);
            }
            GetLayOutGrid(grid);
        }

        /// <summary>
        /// Lấy lại cầu hình mặc định ban đầu
        /// </summary>
        /// <param name="grid"></param>
        public static void GetLayOutDefault(ShGridControl grid)
        {
            string fileName = Application.StartupPath + "\\LayoutGrid\\" + grid.Name + "_Layout.xml";
            if (File.Exists(fileName))
            {
                grid.MainView.RestoreLayoutFromXml(fileName);
                SaveLayoutGrid(grid);
            }
        }
        #endregion
    }
}
