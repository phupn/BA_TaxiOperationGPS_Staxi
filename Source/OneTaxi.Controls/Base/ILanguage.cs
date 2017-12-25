using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaxi.Controls.Base
{
    /// <summary>
    /// Giúp mở rộng ngôn ngữ khác.
    /// </summary>
    public interface ILanguage
    {
        string TagLanguage { get; set; }
        void SetLanguage(string Language);
    }
}
