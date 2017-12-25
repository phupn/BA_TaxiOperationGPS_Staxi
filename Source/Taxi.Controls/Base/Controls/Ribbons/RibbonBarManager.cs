using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Controls.Ribbons
{
    public class RibbonBarManager: DevExpress.XtraBars.Ribbon.RibbonBarManager
    {
        public new RibbonControl Ribbon { get { return (RibbonControl)base.Ribbon; } }
        public RibbonBarManager(DevExpress.XtraBars.Ribbon.RibbonControl ribbon)
            : base(ribbon)
        {
        }
        public override DevExpress.XtraBars.BarAndDockingController GetController()
        {
            return Controller == null ? BarAndDockingController.Default : Controller;
        }
        public DevExpress.XtraBars.ViewInfo.BarSelectionInfo SelectionInfoBase
        {
            get
            {
                return base.SelectionInfo;
            }
        }
    }
}
