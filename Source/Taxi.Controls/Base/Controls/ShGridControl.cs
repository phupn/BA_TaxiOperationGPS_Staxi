using DevExpress.XtraGrid;
using System.Collections.Generic;
namespace Taxi.Controls.Base.Controls
{
    /// <summary>
    /// ShGridControl
    /// </summary>
    public class ShGridControl : GridControl, IShReportControl
    {
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        /// <summary>
        /// Thiết lập DataSource
        /// </summary>
        public void SetDataSource(object obj) { this.DataSource = obj; }

        //Thanh bar hiển thị số trang
        public ShGridControl()
        {
            this.UseEmbeddedNavigator = true;
            this.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
        }

        public object GetDataView()
        {
            List<object> objData = new List<object>();
            for (int i = 0; i < this.MainView.RowCount; i++)
            {
                objData.Add(this.MainView.GetRow(i));
            }
            return objData;
        }

        private void InitializeComponent()
        {
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            // 
            // ShGridControl
            // 
            this.MainView = this.gridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
