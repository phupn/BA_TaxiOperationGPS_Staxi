using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.DirectoryServices.AccountManagement;

namespace TaxiOperation
{
    public class Authentication : SoapHeader
    {
        public string UserName;
        public string Password;
    }
}