using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Controls.Ribbons.Items
{
    public class RibbonPageGroup : DevExpress.XtraBars.Ribbon.RibbonPageGroup, ILanguage
    {
        public string TagLanguage { get; set; }

        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Text = Language;
        }
    }
}
