using System;
using System.Collections.Generic;
using System.Text;
using XlsClient.xls;

namespace APIServices.GeoBiz
{
    public class GeocoderTest
    {
        public XLSType createXlsRequestTest(string number, string street1, string street2, string city, string requestID)
        {

            XlsDocument xLSDocument = XlsDocument.CreateDocument();
            XLSType xLSType = xLSDocument.XLS.Append();
            xLSType.lang.Value = ServiceConfigProperties.Language;
            // should be added one only
            RequestUtil.addXlsHeader(ref xLSType);
            addGeocodeRequest(ref xLSType, number, street1, street2, city, requestID);
            return xLSType;
        }

        private void addGeocodeRequest(ref XLSType xLSType, string number, string street1, string street2, string city, string requestID)
        {
            RequestType requestType = xLSType.Request.Append();
            requestType.methodName.Value = "GeocodeRequest";

            GeocodeRequestType geocodeRequestType = requestType.GeocodeRequest.Append();
            AddressType addressType = geocodeRequestType.Address.Append();
            StreetAddressType streetAddressType = addressType.StreetAddress.Append();

            if (number != null)
            {
                BuildingLocatorType buildingLocatorType = streetAddressType.Building.Append();
                buildingLocatorType.number.Value = number;
            }

            StreetNameType streetNameType = streetAddressType.Street.Append();
            streetNameType.Value = street1;

            if (street2 != null)
            {
                StreetNameType streetNameType2 = streetAddressType.Street.Append();
                streetNameType2.Value = street2;
            }

            NamedPlaceType placeProvince = addressType.Place.Append();
            placeProvince.type.Value = "CountrySubdivision";
            placeProvince.Value = city;
        }


    }
}
