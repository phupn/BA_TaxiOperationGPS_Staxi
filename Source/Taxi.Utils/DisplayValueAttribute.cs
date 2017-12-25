using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Utils
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class DisplayValueAttribute:Attribute
    {
        public string DisplayName { get; set; }
        public object Value { get; set; }
        public bool IsDefault { get; set; }
        public long OrderBy { get; set; }
        public DisplayValueAttribute()
        {
            OrderBy = DateTime.Now.Ticks;
        }
        public DisplayValueAttribute(string displayName, object value)
        {
            DisplayName = displayName;
            Value = value;
        }
        public DisplayValueAttribute(string displayName, object value,bool isDefault)
        {
            DisplayName = displayName;
            Value = value;
            IsDefault = isDefault;
        }
        public new long GetHashCode()
        {
            return OrderBy;
        }
    }
}
