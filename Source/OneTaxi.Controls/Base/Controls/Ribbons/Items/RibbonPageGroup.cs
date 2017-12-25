using System;

namespace OneTaxi.Controls.Base.Controls.Ribbons
{
    public class RibbonPageGroup : DevExpress.XtraBars.Ribbon.RibbonPageGroup, ILanguage
    {
        protected override DevExpress.XtraBars.Ribbon.RibbonPageGroup CreateGroup()
        {
            return new RibbonPageGroup();
        }
        public string TagLanguage { get; set; }

        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Text = Language;
        }
    }
}
