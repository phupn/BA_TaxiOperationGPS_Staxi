using DevExpress.Utils.Serializing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaxi.Controls.Base.Controls.Grids
{
    public class GridBand : DevExpress.XtraGrid.Views.BandedGrid.GridBand, ILanguage
    {
        [XtraSerializableProperty]
        public string TagLanguage { get; set; }
        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Caption = Language;
        }
        protected override DevExpress.XtraGrid.Views.BandedGrid.GridBandCollection CreateBandCollection()
        {
            return new GridBandCollection(null,this);
        }
    }
    public class GridBandCollection : DevExpress.XtraGrid.Views.BandedGrid.GridBandCollection
    {
        public GridBandCollection(BandedGridView view, GridBand ownerBand) : base(view, ownerBand) { }

        public override DevExpress.XtraGrid.Views.BandedGrid.GridBand CreateBand()
        {
            return new GridBand();
        }
    }
}
