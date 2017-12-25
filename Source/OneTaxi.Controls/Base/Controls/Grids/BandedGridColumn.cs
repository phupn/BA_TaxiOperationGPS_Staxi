using DevExpress.Utils.Serializing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaxi.Controls.Base.Controls.Grids
{
    public class BandedGridColumn : DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn, ILanguage
    {
        [XtraSerializableProperty]
        public string TagLanguage { get; set; }
        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Caption = Language;
        }
    }
    public class BandedGridColumnCollection : DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumnCollection
    {
        public BandedGridColumnCollection(DevExpress.XtraGrid.Views.Base.ColumnView view) : base(view) { }
        protected override DevExpress.XtraGrid.Columns.GridColumn CreateColumn()
        {
            return new BandedGridColumn() { Name = string.Format("GridColumn{0}", DateTime.Now.Ticks) };
        }
    }
}
