using DevExpress.Utils;
using DevExpress.Utils.Serializing;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Taxi.Controls.Base.Controls.Grids
{
    public class GridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        protected bool IsInDesignMode
        {
            get
            {
                return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            }
        }
        public string LayoutDefault;
        private float SizeDefault;
        private float SizeHeaderDefault;
        public GridView()
            : base()
        {
            this.IndicatorWidth = 50;
            this.OptionsPrint.AutoWidth = false;
        }
        public GridView(DevExpress.XtraGrid.GridControl ownerGrid)
            : base(ownerGrid)
        {

        }
        protected override DevExpress.XtraGrid.Columns.GridColumnCollection CreateColumnCollection()
        {
            return new GridColumnCollection(this);
        }
        public void SetGrid(DevExpress.XtraGrid.GridControl newControl)
        {
            base.SetGridControl(newControl);
        }
        protected override void RaiseCustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            // Sự kiện lớp base
            base.RaiseCustomDrawRowIndicator(e);
            e.Info.Appearance.Font = new Font(e.Info.Appearance.Font.FontFamily, e.Info.Appearance.Font.Size);
            e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            // Hiển thị số thứ tự
           
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
            else if (!e.Info.IsRowIndicator && e.RowHandle < 0 && e.Info.IsTopMost)
            {
                e.Info.DisplayText = "STT";
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
                Columns.Cast<DevExpress.XtraGrid.Columns.GridColumn>().ToList().ForEach(FormatColumnHeader);
                if (LayoutDefault == null&&!string.IsNullOrEmpty(this.Name))
                {
                    LayoutDefault = GetLayoutFromStringXml();
                    SizeDefault = this.Appearance.Row.Font.Size;
                    SizeHeaderDefault = this.Appearance.HeaderPanel.Font.Size;
                }

            }
        }

        /// <summary>
        /// Thiết lập thông số cho Header
        /// </summary>
        /// <param name="gc"></param>
        protected virtual void FormatColumnHeader(DevExpress.XtraGrid.Columns.GridColumn gc)
        {
            switch (gc.UnboundType)
            {
                case DevExpress.Data.UnboundColumnType.Decimal: SetFormat(gc, "#,###.##"); break;
                case DevExpress.Data.UnboundColumnType.DateTime: SetFormat(gc, "dd/MM/yyyy"); break;
            }
        }

        /// <summary>
        /// Thiết lập Format
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="format"></param>
        protected void SetFormat(DevExpress.XtraGrid.Columns.GridColumn gc, string format)
        {
            gc.DisplayFormat.FormatString = format;
            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        public virtual string GetLayoutFromStringXml()
        {
            using (Stream stream = new MemoryStream())
            {
                var optionlayout = new OptionsLayoutGrid();
                optionlayout.StoreAppearance = true;
                this.SaveLayoutToStream(stream, optionlayout);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }
        public virtual void LoadLayouFromStringXml(string layoutXml)
        {
            if (string.IsNullOrEmpty(layoutXml))
            {
                this.ResetLayout();
                return;
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(layoutXml);
            MemoryStream stream = new MemoryStream(byteArray);
            var optionlayout = new OptionsLayoutGrid();
            optionlayout.StoreAppearance = true;
            this.RestoreLayoutFromStream(stream, optionlayout);
            this.ColumnPanelRowHeight = this.ColumnPanelRowHeight + 6;
        }
        public virtual void ResetLayout()
        {
            if (!string.IsNullOrEmpty(this.LayoutDefault))
            {
                this.LoadLayouFromStringXml(this.LayoutDefault);
                ResetZoom();
            }
        }
        public void ResetZoom()
        {
            this.Appearance.HeaderPanel.Font = new Font(this.Appearance.HeaderPanel.Font.Name, this.SizeHeaderDefault, this.Appearance.HeaderPanel.Font.Style);
            this.Appearance.Row.Font = new Font(this.Appearance.Row.Font.Name, SizeDefault, this.Appearance.Row.Font.Style);
            this.ColumnPanelRowHeight = 35;
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
            if (this.Appearance.Row.Font.Size + fontSize > 7 && this.Appearance.Row.Font.Size + fontSize<25)
            {
                this.Appearance.HeaderPanel.Font = new Font(this.Appearance.HeaderPanel.Font.Name, this.Appearance.HeaderPanel.Font.Size + fontSize, this.Appearance.HeaderPanel.Font.Style);
                this.Appearance.Row.Font = new Font(this.Appearance.Row.Font.Name, this.Appearance.Row.Font.Size + fontSize, this.Appearance.Row.Font.Style);
                Columns.Cast<DevExpress.XtraGrid.Columns.GridColumn>().ToList().ForEach(p =>
                {
                    p.Width = p.Width + (int)fontSize * 5;

                });
                this.ColumnPanelRowHeight = this.ColumnPanelRowHeight + (int)fontSize*7;
            }
        }
    }

    public class GridInfoExtendsRegistrator : DevExpress.XtraGrid.Registrator.GridInfoRegistrator
    {
        public GridInfoExtendsRegistrator() : base() { }
        public override string ViewName { get { return "GridViewExtends"; } }
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            var view = new GridView();
            view.SetGrid(grid);
            return view;
        }
    }
}
