using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Controls.Ribbons.Items
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
