using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Business;
using Taxi.Services.Operations.Inferfaces;
using Taxi.Utils;

namespace Taxi.Services.Operations
{
    public class ServiceOnline : IServiceOnline
    {
        public ServiceOnline() { }
        public ServiceOnline(string connect) { }

        //public string GetAddressByGeo(double lat, double lng)
        //{
        //    return GetAddressByGeo(lat, lng);
        //}

        //public string GetAddressByGeo(float lat, float lng)
        //{
        //    if (lat <= 0 || lng <= 0) return "";
        //    if (Config_Common.GEOService == EnumGEOService.Google)
        //        return Service_Common.WCF_GEO.TryGet(p => p.GetAddressByGeo_Google(Service_Common.WCF_GEO_Authen, lng, lat)).Value;
        //    else
        //        return Service_Common.WCF_GEO.TryGet(p => p.GetAddressByGeo(Service_Common.WCF_GEO_Authen, lng, lat)).Value;
        //}

        //public string GetGeobyAddress(string address, string TenTinh)
        //{
        //    if (Config_Common.GEOService == EnumGEOService.Google)
        //        return Service_Common.WCF_GEO.TryGet(p => p.GetGeoByAddress_Google(Service_Common.WCF_GEO_Authen, address, TenTinh)).Value;
        //    else if (Config_Common.GEOService == EnumGEOService.BinhAnh)
        //    {
        //        if (TenTinh.ToLower().Equals("hà nội") || TenTinh.ToLower().Equals("ha noi"))
        //            return Service_Common.WCF_GEO.TryGet(p => p.GetGeobyAddressBA_HN_First(Service_Common.WCF_GEO_Authen, address, TenTinh)).Value;
        //        else
        //            return Service_Common.WCF_GEO.TryGet(p => p.GetGeobyAddressBA(Service_Common.WCF_GEO_Authen, address, TenTinh)).Value;
        //    }
        //    else
        //    {
        //        string AddressReturn = "";
        //        if (TenTinh.ToLower().Equals("hà nội") || TenTinh.ToLower().Equals("ha noi"))
        //            AddressReturn = Service_Common.WCF_GEO.TryGet(p => p.GetGeobyAddressBA_HN_First(Service_Common.WCF_GEO_Authen, address, TenTinh)).Value;
        //        else
        //            AddressReturn = Service_Common.WCF_GEO.TryGet(p => p.GetGeobyAddressBA(Service_Common.WCF_GEO_Authen, address, TenTinh)).Value;

        //        if (AddressReturn == "" || AddressReturn == "*")
        //        {
        //            AddressReturn = Service_Common.WCF_GEO.TryGet(p => p.GetGeoByAddress_Google(Service_Common.WCF_GEO_Authen, address, TenTinh)).Value;
        //        }
        //        return AddressReturn;
        //    }
        //}




        //public string LayToaDoXeNhan(double lat, double lng, string xeNhan)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
