using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Controls;
namespace Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportGridViewChain : ReportGridViewChain<GridView>
    {
        
    }

    public class ReportShGridViewChain : ReportGridViewChain<ShGridView>
    {

    }

    public class ReportGridViewChain<T> : ReportGridChain<T> where T : GridView
    {
        protected override ColumnConfig DoProcess(T t)
        {
            // Khởi tạo Config
            var config = new ColumnConfig();

            // Duyệt qua từng columns của GridView để lấy config
            // từ GridColumn tạo và đưa vào danh sách columns
            t.Columns.Cast<GridColumn>().ToList().ForEach(c =>
            {
                if (c.Visible)
                    config.Columns.Add(CreateColumnConfig(c));
            });

            // return
            return config;
        }
    }
}
