using System;

namespace Taxi.Controls.Base.Controls.Ribbons
{
    public class RibbonControl : DevExpress.XtraBars.Ribbon.RibbonControl
    {
        protected override DevExpress.XtraBars.Ribbon.RibbonBarManager CreateBarManager()
        {
            return new RibbonBarManager(this);
        }
       
    }
}
