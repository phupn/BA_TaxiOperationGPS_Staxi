using DevExpress.Utils;
using OneTaxi.Controls.Base.Controls.Grids;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OneTaxi.Controls.Base.Controls.Grids
{
    public class GridControl : DevExpress.XtraGrid.GridControl
    {
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
            collection.Add(new BandedGridInfoExtendsRegistrator());
            //collection.Add(new GridInfoTongDaiRegistrator());
        }
        protected override DevExpress.XtraGrid.Views.Base.BaseView CreateDefaultView()
        {
            return CreateView("GridViewExtends");
        }

        #region === Layout ===
        public DevExpress.XtraGrid.Views.Grid.GridView LayoutGrid { get { return (DevExpress.XtraGrid.Views.Grid.GridView)MainView; } }
        public string LayoutDefault;
        private float SizeDefault;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private float SizeHeaderDefault;
        public virtual string GetLayoutFromStringXml()
        {
            using (Stream stream = new MemoryStream())
            {
                var optionlayout = new OptionsLayoutGrid();
                optionlayout.StoreAppearance = true;
                MainView.SaveLayoutToStream(stream, optionlayout);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }
        public virtual void LoadLayouFromStringXml(string layoutXml)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(layoutXml);
            MemoryStream stream = new MemoryStream(byteArray);
            var optionlayout = new OptionsLayoutGrid();
            optionlayout.StoreAppearance = true;
            MainView.RestoreLayoutFromStream(stream, optionlayout);
            if (LayoutGrid!=null)
                LayoutGrid.ColumnPanelRowHeight = LayoutGrid.ColumnPanelRowHeight + 6;
        }
        public virtual void ResetLayout()
        {
            this.LoadLayouFromStringXml(this.LayoutDefault);
            LayoutGrid.Appearance.HeaderPanel.Font = new Font(LayoutGrid.Appearance.HeaderPanel.Font.Name, this.SizeHeaderDefault, LayoutGrid.Appearance.HeaderPanel.Font.Style);
            LayoutGrid.Appearance.Row.Font = new Font(LayoutGrid.Appearance.Row.Font.Name, SizeDefault, LayoutGrid.Appearance.Row.Font.Style);
            LayoutGrid.ColumnPanelRowHeight = 35;
        }

        public void ZoomIn()
        {
            this.SetFontSize(-1);
        }
        public void ZoomOut()
        {
            this.SetFontSize(1);
        }
        private void SetFontSize(float fontSize)
        {
            if (LayoutGrid.Appearance.Row.Font.Size + fontSize > 7 && LayoutGrid.Appearance.Row.Font.Size + fontSize < 25)
            {
                LayoutGrid.Appearance.HeaderPanel.Font = new Font(LayoutGrid.Appearance.HeaderPanel.Font.Name, LayoutGrid.Appearance.HeaderPanel.Font.Size + fontSize, LayoutGrid.Appearance.HeaderPanel.Font.Style);
                LayoutGrid.Appearance.Row.Font = new Font(LayoutGrid.Appearance.Row.Font.Name, LayoutGrid.Appearance.Row.Font.Size + fontSize, LayoutGrid.Appearance.Row.Font.Style);
                LayoutGrid.Columns.Cast<DevExpress.XtraGrid.Columns.GridColumn>().ToList().ForEach(p =>
                {
                    p.Width = p.Width + (int)fontSize * 5;

                });
                LayoutGrid.ColumnPanelRowHeight = LayoutGrid.ColumnPanelRowHeight + (int)fontSize * 7;
            }
        }
        /// <summary>
        /// Override sự kiện OnLoaded
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();

            if (!DesignMode)
            {
                if (LayoutDefault == null && !string.IsNullOrEmpty(this.Name))
                {
                    LayoutDefault = GetLayoutFromStringXml();
                    SizeDefault = LayoutGrid.Appearance.Row.Font.Size;
                    SizeHeaderDefault = LayoutGrid.Appearance.HeaderPanel.Font.Size;
                }
            }
        }
        #endregion

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
            // GridControl
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
