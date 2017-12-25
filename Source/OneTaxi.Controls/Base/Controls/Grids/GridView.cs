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

namespace OneTaxi.Controls.Base.Controls.Grids
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
            this.IndicatorWidth = 35;
            this.OptionsPrint.AutoWidth = false;
        }
        public GridView(DevExpress.XtraGrid.GridControl ownerGrid)
            : base(ownerGrid)
        {
            this.IndicatorWidth = 35;
            this.OptionsPrint.AutoWidth = false;
        }
        protected override DevExpress.XtraGrid.Columns.GridColumnCollection CreateColumnCollection()
        {
            return new GridColumnCollection(this);
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
       
    }

    public class GridInfoExtendsRegistrator : DevExpress.XtraGrid.Registrator.GridInfoRegistrator
    {
        public GridInfoExtendsRegistrator() : base() { }
        public override string ViewName { get { return "GridViewExtends"; } }
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            var view = new GridView(grid);
        
            return view;
        }
    }
}
