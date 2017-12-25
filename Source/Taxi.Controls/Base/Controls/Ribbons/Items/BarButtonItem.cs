using DevExpress.XtraBars;
using DevExpress.XtraBars.ViewInfo;
using System;

namespace Taxi.Controls.Base.Controls.Ribbons.Items
{
    public class BarButtonItem : DevExpress.XtraBars.BarButtonItem, ILanguage
    {
        public BarButtonItem() : base() { }
        public BarButtonItem(DevExpress.XtraBars.BarManager manager, string caption) : base(manager, caption) { }
        public BarButtonItem(DevExpress.XtraBars.BarManager manager, string caption, int imageIndex) : base(manager, caption, imageIndex) { }
        public BarButtonItem(DevExpress.XtraBars.BarManager manager, string caption, int imageIndex, DevExpress.XtraBars.BarShortcut shortcut) : base(manager, caption, imageIndex, shortcut) { }
        public string TagLanguage { get; set; }

        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Caption = Language;
        }
    }

    public class BarButtonItemLink : DevExpress.XtraBars.BarButtonItemLink
    {
        public BarButtonItemLink(BarItemLinkReadOnlyCollection ALinks, BarItem AItem, object ALinkedObject) : base(ALinks, AItem, ALinkedObject) { }
        public new BarButtonItem Item { get { return (BarButtonItem)base.Item; } }

    }

    public class BarButtonLinkViewInfo : DevExpress.XtraBars.ViewInfo.BarButtonLinkViewInfo
    {
        public BarButtonLinkViewInfo(BarDrawParameters parameters, BarItemLink link) : base(parameters, link) { }
        public new BarButtonItemLink Link
        {
            get
            {
                return base.Link as BarButtonItemLink;
            }
        }
    }
}
