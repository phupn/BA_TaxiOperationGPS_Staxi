using System;
using System.Collections.Generic;
using System.Web;
using BAGPS.APIServices;

namespace BAGPS
{
    public static class BAService
    {
        private static Service _service;

        public static Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public static string GetAddressByGeo(float lat,float lng)
        {
            return Service.GetAddressByGeo(lat,lng);
        }

        public static LicenseEntity GetLicense(string requestKey)
        {
            try
            {
                var objAuthentication = new Authentication();
                objAuthentication.Password = "BAGPS_PASS";
                objAuthentication.UserName = "BA_GPS_User";
                APIServices.APIServices objAPI = new APIServices.APIServices();
                
                objAPI.AuthenticationValue = objAuthentication;
                return objAPI.GetLicense(requestKey);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}