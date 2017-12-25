using Taxi.Utils;
using DevExpress.XtraGrid;
using Taxi.Common.Extender;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
namespace Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders
{
    /// <summary>
    /// ReportGridChain dùng để lấy được config các cột trong grid cho báo cáo
    /// </summary>
    public abstract class ReportGridChain : Chain<ReportGridChain>
    {
        private static ReportGridChain inst = null;
        public static ReportGridChain Inst
        {
            get
            {
                // Nếu chưa khởi tạo thì thực hiện khởi tạo
                if (inst.IsNull())
                {
                    // Mặc định sẽ check GridView trước
                    inst = new ReportGridViewChain();

                    // Tiếp đến là ShGridView
                    inst.SetHandler<ReportShGridViewChain>();

                    // Sau đó sẽ check BandedGridView
                    inst.SetHandler<ReportBandedGridViewChain>();

                }
                return inst;
            }
        }

        /// <summary>
        /// Lấy config
        /// </summary>
        /// <param name="reportControl"></param>
        /// <returns></returns>
        public abstract ColumnConfig GetConfig(GridControl reportControl);

        /// <summary>
        /// CreateColumnConfig
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected ColumnConfig CreateColumnConfig(GridColumn c)
        {
            var cc = new ColumnConfig(); cc.CopyValueFrom(c);
            cc.DisplayFormat = c.DisplayFormat;
            cc.SummaryItem = c.SummaryItem;
            cc.AppearanceCell = c.AppearanceCell;
            if (cc.GroupIndex >= 0) cc.Visible = true;
            return cc;
        }

        /// <summary>
        /// CreateColumnConfig
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected ColumnConfig CreateColumnConfig(GridBand c)
        {
            var tc = new ColumnConfig(); tc.CopyValueFrom(c);
            tc.Visible = true;
            return tc;
        }


    }

    /// <summary>
    /// ReportGridChain T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReportGridChain<T> : ReportGridChain
    {
        /// <summary>
        /// Thực thi khi là kiểu dữ liệu gì
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public override ColumnConfig GetConfig(GridControl reportControl)
        {
            // Nếu là GridControl
            return reportControl.MainView.IsTypeOf<T>() ?
            //return reportControl.MainView is T ?
                DoProcess(reportControl.MainView.As<T>()) : (this.Handler.IsNotNull() ? this.Handler.GetConfig(reportControl) : null);
        }

        /// <summary>
        /// Xử lý lấy dữ liệu theo T
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected abstract ColumnConfig DoProcess(T t);
    }
}
