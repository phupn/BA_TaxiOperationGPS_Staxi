using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices.GeoBiz
{
    public class ServiceConfigProperties
    {
       // public static string EndPointURL = "http://map2.vngeobiz.com:7080/xls/services";
        public static string EndPointURL = System.Configuration.ConfigurationManager.AppSettings["GeoConfig"];
        public static string Language = System.Configuration.ConfigurationManager.AppSettings["Language"];
        public static string clientUserName = "binhanh";
        public static string clientPassword = "binhanh";
    }
}
