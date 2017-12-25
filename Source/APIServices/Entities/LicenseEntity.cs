using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace APIServices.Entities
{
    public class LicenseEntity
    {
        public string LicenseKey { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class Authentication : SoapHeader
    {
        public string UserName;
        public string Password;
    }
}