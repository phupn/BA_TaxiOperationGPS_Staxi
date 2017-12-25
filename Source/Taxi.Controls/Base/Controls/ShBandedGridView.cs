using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using System.Collections.Generic;
using DevExpress.Utils;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
namespace Taxi.Controls.Base.Controls
{
    public class ShBandedGridView : BandedGridView
    {
        public ShBandedGridView()
        {
            this.IndicatorWidth = 35;
            this.OptionsBehavior.Editable = false;
        }

        //private int index1 = 0;
        //private int index2 = 0;
        //private Dictionary<int, int> dic= new Dictionary<int, int>();
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
                  // index2 = e.RowHandle;
                }
                else if (!e.Info.IsRowIndicator && e.RowHandle < 0 && e.Info.IsTopMost)
                {
                    e.Info.DisplayText = "STT";
                    //index1 = 0;
                    //index2 = 0;
                }
              //else if (IsGroupRow(e.RowHandle)&&e.RowHandle>-100)
              //{
              //    e.Info.DisplayText = "g" + (0 - e.RowHandle).ToString();
              //    index1 = 0 - e.RowHandle;
              //    dic[index1] = index2+1;
              //}
            //}
                
        }

        //protected override void DoChangeFocusedRow(int currentRowHandle, int newRowHandle, bool raiseUpdateCurrentRow)
        //{
        //    base.DoChangeFocusedRow(currentRowHandle, newRowHandle, raiseUpdateCurrentRow);
        //    RefreshRow(currentRowHandle);
        //}

        /// <summary>
        /// Kế thừa sự kiện OnLoaded
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();

            if (!DesignMode)
            {
                //FindAllGridBand(Bands).ToList().ForEach(b =>
                //{
                //    b.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                //    b.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                //    b.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap; 
                    
                //});
                Appearance.HeaderPanel.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                Appearance.HeaderPanel.Options.UseFont = true;
                Appearance.HeaderPanel.Options.UseTextOptions = true;
                Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                Columns.Cast<BandedGridColumn>().ToList().ForEach(FormatColumnHeader);
            }
        }
        public static void FormatColumnHeader(GridColumn gc)
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
        protected static void SetFormat(GridColumn gc, string format)
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
                var bgcChildren = FindAllGridBand(bg.Children);
                foreach (var bc in bgcChildren)
                    yield return bc;
            }
        }
    }
}
