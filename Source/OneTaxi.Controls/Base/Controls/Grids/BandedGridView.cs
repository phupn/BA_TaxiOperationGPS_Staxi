using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace OneTaxi.Controls.Base.Controls.Grids
{
    public class BandedGridView: DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    {
        public BandedGridView()
        {
            this.IndicatorWidth = 35;
            this.OptionsBehavior.Editable = false;
        }
        public BandedGridView(DevExpress.XtraGrid.GridControl ownerGrid)
            : base(ownerGrid)
        {
            this.IndicatorWidth = 35;
            this.OptionsBehavior.Editable = false;
        }
        protected override void RaiseCustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            // Sự kiện lớp base
            base.RaiseCustomDrawRowIndicator(e);
            e.Info.Appearance.Font = new Font(e.Info.Appearance.Font.FontFamily, e.Info.Appearance.Font.Size);
            e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            e.Info.Appearance.TextOptions.VAlignment=VertAlignment.Center;
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
        /// Kế thừa sự kiện OnLoaded
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();

            if (!DesignMode)
            {
                Appearance.HeaderPanel.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                Appearance.HeaderPanel.Options.UseFont = true;
                Appearance.HeaderPanel.Options.UseTextOptions = true;
                Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                Columns.Cast<BandedGridColumn>().ToList().ForEach(FormatColumnHeader);
            }
        }
        public static void FormatColumnHeader(BandedGridColumn gc)
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
        protected static void SetFormat(BandedGridColumn gc, string format)
        {
            gc.DisplayFormat.FormatString = format;
            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        /// <summary>
        /// Tìm tất cả các GridBand
        /// </summary>
        /// <param name="bgc"></param>
        /// <returns></returns>
        private IEnumerable<GridBand> FindAllGridBand(GridBandCollection bgc)
        {
            var bgcc = bgc.Cast<GridBand>();
            foreach (var bg in bgcc)
            {
                yield return bg;
                var bgcChildren = FindAllGridBand(bg.Children as GridBandCollection);
                foreach (var bc in bgcChildren)
                    yield return bc;
            }
        }
        protected override DevExpress.XtraGrid.Views.BandedGrid.GridBandCollection CreateBands()
        {
            return new GridBandCollection(this,null);
        }
        protected override DevExpress.XtraGrid.Columns.GridColumnCollection CreateColumnCollection()
        {
            return new BandedGridColumnCollection(this);
        }
    }
    public class BandedGridInfoExtendsRegistrator : DevExpress.XtraGrid.Registrator.GridInfoRegistrator
    {
        public BandedGridInfoExtendsRegistrator() : base() { }
        public override string ViewName { get { return "BandedGridViewExtends"; } }
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            var view = new BandedGridView(grid);
            return view;
        }
    }
}
