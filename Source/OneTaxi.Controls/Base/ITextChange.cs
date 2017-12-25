using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaxi.Controls.Base
{
    public interface ITextChange
    {
        bool IsChangeText { get; set; }
        bool IsForceChangeText { get; }
    }
}
