using System;

namespace OneTaxi.Controls.Base.Controls.Ribbons
{
    public class RibbonControl : DevExpress.XtraBars.Ribbon.RibbonControl
    {
        protected override DevExpress.XtraBars.Ribbon.RibbonBarManager CreateBarManager()
        {
            return new RibbonBarManager(this);
        }
       
    }
}
