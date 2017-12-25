using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaxi.Controls.Base.Controls
{
    public class Button : DevExpress.XtraEditors.SimpleButton, IKeyPress,ILanguage
    {
        public System.Windows.Forms.Keys KeyCommand { get; set; }
        public void DoKeyCommand(object sender)
        {
            this.PerformClick();
        }

        public string TagLanguage { get; set; }

        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                Text = Language;
        }
    }
}
