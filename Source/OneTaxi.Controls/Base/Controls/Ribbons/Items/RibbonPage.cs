using System;
namespace OneTaxi.Controls.Base.Controls.Ribbons
{
    public class RibbonPage : DevExpress.XtraBars.Ribbon.RibbonPage, ILanguage
    {
        public string TagLanguage { get; set; }

        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Text = Language;
        }
    }
}
