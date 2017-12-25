using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Controls
{
    public class XeLienLacEventArgs : EventArgs 
    {

        public XeLienLacEventArgs(string sSoHieuXe)
        {
            SoHieuXe = sSoHieuXe;

        }
        public readonly string SoHieuXe;
    }
}
