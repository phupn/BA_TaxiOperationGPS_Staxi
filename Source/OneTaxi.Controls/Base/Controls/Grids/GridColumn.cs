using DevExpress.Utils.Serializing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTaxi.Controls.Base.Controls.Grids
{
    public class GridColumn : DevExpress.XtraGrid.Columns.GridColumn, ILanguage
    {
        public GridColumn() : base() { }
        [XtraSerializableProperty]
        public string TagLanguage { get; set; }
        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Caption = Language;
        }
    }
    public class GridColumnCollection : DevExpress.XtraGrid.Columns.GridColumnCollection
    {
        public GridColumnCollection(DevExpress.XtraGrid.Views.Base.ColumnView view) : base(view) { }
        protected override DevExpress.XtraGrid.Columns.GridColumn CreateColumn()
        {
            return new GridColumn() { Name = string.Format("GridColumn{0}", DateTime.Now.Ticks) };
        }
    }
}
