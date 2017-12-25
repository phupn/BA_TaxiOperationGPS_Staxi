using Taxi.Controls.Base.Controls.Grids.Extends;

namespace Taxi.Controls.Base.Controls.Grids
{
    public class GridControl : DevExpress.XtraGrid.GridControl, IShReportControl
    {
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    
        public GridControl()
            : base()
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
        protected override void RegisterAvailableViewsCore(DevExpress.XtraGrid.Registrator.InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new GridInfoExtendsRegistrator());
            collection.Add(new GridInfoDienThoaiRegistrator());
            collection.Add(new GridInfoTongDaiRegistrator());
        }
        protected override DevExpress.XtraGrid.Views.Base.BaseView CreateDefaultView()
        {
            return CreateView("GridViewExtends");
        }

        public void SetDataSource(object obj)
        {
            this.DataSource = obj;
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
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            // 
            // GridControl
            // 
            this.LookAndFeel.SkinName = "Caramel";
            this.MainView = this.gridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
