using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Business 
{
    public class EventTimFileArgs : EventArgs
    {
        public EventTimFileArgs(string filename)
        {
            this.Filename = filename;
        }
        public string Filename; 
    }
}
