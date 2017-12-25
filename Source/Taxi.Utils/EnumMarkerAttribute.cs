using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Utils
{
    public class EnumMarkerAttribute : Attribute
    {
        public Type TypeIcon { get; set; }
    }
}
