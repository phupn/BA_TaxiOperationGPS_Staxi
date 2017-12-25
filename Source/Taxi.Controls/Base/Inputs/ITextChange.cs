using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Controls.Base.Inputs
{
    public interface ITextChange
    {
        bool IsChangeText { get; set; }
        bool IsForceChangeText { get;}
    }
}
