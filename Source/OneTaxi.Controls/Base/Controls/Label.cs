using System;

namespace OneTaxi.Controls.Base.Controls
{
    public class Label : DevExpress.XtraEditors.LabelControl,ILanguage
    {
        public string TagLanguage { get; set; }
        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Text = Language;
        }
    }
}
