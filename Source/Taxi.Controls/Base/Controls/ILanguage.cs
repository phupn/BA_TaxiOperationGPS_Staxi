using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Controls
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
