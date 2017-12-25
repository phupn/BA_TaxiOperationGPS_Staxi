using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTaxi.Controls.Base.Controls.Ribbons
{
    public class BarSubItem : DevExpress.XtraBars.BarSubItem, ILanguage
    {
        public BarSubItem() : base() { }
        public BarSubItem(DevExpress.XtraBars.BarManager manager, string caption) : base(manager, caption) { }
        public BarSubItem(DevExpress.XtraBars.BarManager manager, string caption, DevExpress.XtraBars.BarItem[] items) : base(manager, caption, items) { }
        public BarSubItem(DevExpress.XtraBars.BarManager manager, string caption, int imageIndex) : base(manager, caption, imageIndex) { }
        public BarSubItem(DevExpress.XtraBars.BarManager manager, string caption, int imageIndex, DevExpress.XtraBars.BarItem[] items) : base(manager, caption, imageIndex, items) { }
        public string TagLanguage { get; set; }
        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Caption = Language;
        }
    }
    public class BarSubItemLink : DevExpress.XtraBars.BarSubItemLink
    {
        protected BarSubItemLink(DevExpress.XtraBars.BarItemLinkReadOnlyCollection ALinks, DevExpress.XtraBars.BarItem AItem, object ALinkedObject) : base(ALinks, AItem, ALinkedObject) { }

    }
    public class BarSubItemLinkViewInfo : DevExpress.XtraBars.ViewInfo.BarSubItemLinkViewInfo
    {
        public BarSubItemLinkViewInfo(DevExpress.XtraBars.ViewInfo.BarDrawParameters parameters, DevExpress.XtraBars.BarItemLink link) : base(parameters, link) { }
    }
    public class BarCustomContainerLinkPainter : DevExpress.XtraBars.Painters.BarCustomContainerLinkPainter
    {
        public BarCustomContainerLinkPainter(DevExpress.XtraBars.Styles.BarManagerPaintStyle paintStyle) : base(paintStyle) { }
    }
}
