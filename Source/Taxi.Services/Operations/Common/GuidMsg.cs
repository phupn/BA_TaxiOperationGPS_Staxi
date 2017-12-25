using System;
using Taxi.Services.ServiceG5;

namespace Taxi.Services.Operations
{
    public class GuidMsg
    {
        public Guid BookId { get; set; }
        public string Msg { get; set; }
        public bool Flag { get; set; }
        public SourceCancelType TypeMsg { get; set; }
    }
    //public enum SourceCancelType : byte
    //{
    //    Unknown = 0,
    //    UserCancel = 1,
    //    Timeout = 2,
    //    Mistake = 3,
    //}
}
