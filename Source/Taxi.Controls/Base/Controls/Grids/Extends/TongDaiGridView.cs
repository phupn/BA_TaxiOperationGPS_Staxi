using System;
using Taxi.Business;

namespace Taxi.Controls.Base.Controls.Grids.Extends
{
    public class TongDaiGridView : RealTimeGridView<CuocGoi, long>
    {
        public override void IniGridView()
        {
            this.GetKey = (cg) => cg.IDCuocGoi;
            this.GetLastUpdate = (cg) => cg.ThoiDiemThayDoiDuLieu;
        }

        public override string GetLineVung()
        {
            return RealTimeEnvironment.LineVung;
        }
    }
    public class GridInfoTongDaiRegistrator : DevExpress.XtraGrid.Registrator.GridInfoRegistrator
    {
        public GridInfoTongDaiRegistrator() : base() { }
        public override string ViewName { get { return "TongDaiGridView"; } }
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            var view = new TongDaiGridView();
            view.SetGrid(grid);
            return view;
        }
    }
}
