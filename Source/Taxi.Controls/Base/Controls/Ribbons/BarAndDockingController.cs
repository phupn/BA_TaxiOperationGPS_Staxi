using DevExpress.XtraBars.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Controls.Ribbons.Items;

namespace Taxi.Controls.Base.Controls.Ribbons
{
    public class BarAndDockingController : DevExpress.XtraBars.BarAndDockingController
    {
        public BarAndDockingController() : base() { PaintStyleName = "DevExtends"; }
        public BarAndDockingController(System.ComponentModel.IContainer container) : base(container) { PaintStyleName = "DevExtends"; }
        static BarAndDockingController _default;
        public new static BarAndDockingController Default
        {
            get
            {
                if (_default == null) _default = new BarAndDockingController();
                return _default;
            }
        }
        protected override void RegisterPaintStyles()
        {
            this.PaintStyles.Add(new SkinBarManagerPaintStyle(this.PaintStyles));
            base.RegisterPaintStyles();
        }
    }
    public class SkinBarManagerPaintStyle : DevExpress.XtraBars.Styles.SkinBarManagerPaintStyle
    {
        public override string Name
        {
            get
            {
                return "DevExtends";
            }
        }
        public SkinBarManagerPaintStyle(DevExpress.XtraBars.Styles.BarManagerPaintStyleCollection collection) : base(collection) { }

        protected override void RegisterItemInfo()
        {
            ItemInfoCollection.Add(new BarItemInfo("BarButtonItemLanguage", "ButtonLanguage", 0, typeof(BarButtonItem), typeof(BarButtonItemLink), typeof(BarButtonLinkViewInfo), new BarCustomContainerLinkPainter(this), true, true));
            ItemInfoCollection.Add(new BarItemInfo("BarSubItemLanguage", "MenuLanguage", 1, typeof(BarSubItem), typeof(BarSubItemLink), typeof(BarSubItemLinkViewInfo), new BarCustomContainerLinkPainter(this), true, true));
            base.RegisterItemInfo();
        }
    }
}
