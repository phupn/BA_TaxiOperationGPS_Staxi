using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using XlsClient.xls;
using XlsClient.gml;
using System.Collections;
namespace APIServices.GeoBiz
{
    public class RouteService
    {


        public string doTestGeocoderByAddress(string numberBuild, string Street, string Province, string requestID)
        {
            GeocoderTest geocoderTest = new GeocoderTest();
            XLSType xLSTypeRequest = geocoderTest.createXlsRequestTest(numberBuild, Street, null, Province, requestID);
            XLSType xLSTypeResponse = RequestUtil.perform(xLSTypeRequest);

            if (xLSTypeResponse.Response.Exists)
            {
                ResponseType responseType = xLSTypeResponse.Response.First;
                GeocodeResponseType geocodeResponseType = responseType.GeocodeResponse.First;

                if (geocodeResponseType.GeocodeResponseList.Exists)
                {
                    GeocodeResponseListType geocodeResponseListType = geocodeResponseType.GeocodeResponseList.First;
                    if (geocodeResponseListType.GeocodedAddress.Exists)
                    {
                        GeocodedAddressType geocodedAddressType = geocodeResponseListType.GeocodedAddress.First;
                        PointType pointType = geocodedAddressType.Point.First;
                        DirectPositionType directPositionType = pointType.pos.First;
                        AddressType addressType = geocodedAddressType.Address.First;
                        StreetAddressType streetAddressType = addressType.StreetAddress.First;
                        BuildingLocatorType buildingLocatorType = streetAddressType.Building.First;

                        string buildingNumber = buildingLocatorType.number.Value;
                        string strCommuneName = "";
                        string strDistrictName = "";
                        string strProvinceName = "";
                        string strStreetName = "";



                        if (streetAddressType.Street.Exists)
                        {
                            StreetNameType streetNameType = streetAddressType.Street.First;
                            strStreetName = streetNameType.Value;
                        }

                        foreach (NamedPlaceType namedPlaceType in addressType.Place)
                        {
                            if (namedPlaceType.type.Value == "Municipality")
                            {
                                strCommuneName = namedPlaceType.Value;
                            }
                            else if (namedPlaceType.type.Value == "CountrySecondarySubdivision")
                            {
                                strDistrictName = namedPlaceType.Value;
                            }
                            else if (namedPlaceType.type.Value == "CountrySubdivision")
                            {
                                strProvinceName = namedPlaceType.Value;
                            }
                        }
                        // string[] latlong = directPositionType.Value.Split(new string[] { " " } , StringSplitOptions.None);
                        return directPositionType.Value.ToString();
                    }
                    else return "*";
                }
                else return "*";
            }
            else return "*";
        }

        // toa do->dia chi
        public string doTestReverseGeocoderWithAddress(double kinhdo, double vido)
        {
            ReverseGeocoderTest reverseGeocoderTest = new ReverseGeocoderTest();
            XLSType xLSTypeRequest = reverseGeocoderTest.createXlsRequestTest(kinhdo, vido);
            XLSType xLSTypeResponse = RequestUtil.perform(xLSTypeRequest);

            if (xLSTypeResponse.Response.Exists)
            {
                ResponseType responseType = xLSTypeResponse.Response.First;
                ReverseGeocodeResponseType reverseGeocodeResponseType = responseType.ReverseGeocodeResponse.First;

                if (reverseGeocodeResponseType.ReverseGeocodedLocation.Exists)
                {
                    ReverseGeocodedLocationType reverseGeocodedLocationType = reverseGeocodeResponseType.ReverseGeocodedLocation.First;
                    PointType pointType = reverseGeocodedLocationType.Point.First;
                    DirectPositionType directPositionType = pointType.pos.First;
                    AddressType addressType = reverseGeocodedLocationType.Address.First;
                    StreetAddressType streetAddressType = addressType.StreetAddress.First;
                    //BuildingLocatorType buildingLocatorType = streetAddressType.Building.First;
                    string strStreetName = "";
                    string buildingNumber = "";
                    string strCommuneName = "";
                    string strDistrictName = "";
                    string strProvinceName = "";
                    if (streetAddressType.Building.Exists)
                    {
                        BuildingLocatorType buildingLocatorType = streetAddressType.Building.First;
                        buildingNumber = buildingLocatorType.number.Value;
                    }
                    if (streetAddressType.Street.Exists)
                    {
                        StreetNameType streetNameType = streetAddressType.Street.First;
                        strStreetName = streetNameType.Value;
                    }

                    for (int j = 0; j < addressType.Place.Count; j++)
                    {
                        NamedPlaceType namedPlaceType = addressType.Place.At(j);
                        if (namedPlaceType.type.Value == "Municipality")
                        {
                            strCommuneName = namedPlaceType.Value;
                        }
                        else if (namedPlaceType.type.Value == "CountrySecondarySubdivision")
                        {
                            strDistrictName = namedPlaceType.Value;
                        }
                        else if (namedPlaceType.type.Value == "CountrySubdivision")
                        {
                            strProvinceName = namedPlaceType.Value;
                        }
                    }
                    if ((buildingNumber == "") && (strStreetName == "") && (strCommuneName == "") && (strDistrictName == "") && (strProvinceName == "")) return "*";
                    //  string[] latlong = directPositionType.Value.Split(new string[] { " " } , StringSplitOptions.None);
                    string diachi;
                    if (buildingNumber == "0") diachi = strStreetName + "," + strCommuneName + "," + strDistrictName + "," + strProvinceName;
                    else diachi = buildingNumber + "," + strStreetName + "," + strCommuneName + "," + strDistrictName + "," + strProvinceName;
                    diachi = diachi.Replace(",,", ",");
                    return diachi;
                }
                else return "*";

            }
            else return "*";
        }
        // route service
        public List<ServiceGeo> doTestRouteService(double VDStart, double KDStart, double VDEnd, double KDEnd)
        {
            List<ServiceGeo> lstInfo = new List<ServiceGeo>();
            XLSType xLSTypeRequest = createRouteServiceRequest(VDStart, KDStart, VDEnd, KDEnd);
            XLSType xLSTypeResponse = RequestUtil.perform(xLSTypeRequest);
            if (xLSTypeResponse.Response.Exists)
            {
                ResponseType responseType = xLSTypeResponse.Response.First;
                DetermineRouteResponseType determineRouteResponseType = responseType.DetermineRouteResponse.First;
                if (determineRouteResponseType.RouteInstructionsList.Exists)
                {
                    RouteInstructionsListType routeInstructionsListType = determineRouteResponseType.RouteInstructionsList.First;

                    foreach (RouteInstructionType routeInstructionType in routeInstructionsListType.RouteInstruction)
                    {
                        ServiceGeo Geo = new ServiceGeo();
                        string strInstruction = routeInstructionType.Instruction.First.Value;
                        string strDescription = routeInstructionType.description.Value;
                        DistanceType distanceType = routeInstructionType.distance.First;
                        string strUnit = distanceType.uom.Value;
                        string strDistance = distanceType.value2.Value.ToString();

                        RouteGeometryType routeGeometryType = routeInstructionType.RouteInstructionGeometry.First;
                        LineStringType lineStringType = routeGeometryType.LineString.First;
                        string strX = "";
                        string strY = "";
                        DirectPositionType directPositionType = lineStringType.pos.First;
                        string[] xy = directPositionType.Value.Split(new string[] { " " }, StringSplitOptions.None);
                        strX = xy[1];
                        strY = xy[0];
                        // ListViewItem listViewItem = new ListViewItem(new string[] { strInstruction, strDescription, strDistance, strUnit, strX, strY });
                        // this.listViewRouteInstructionsList.Items.Add(listViewItem);
                        Geo.DonVi = strUnit.ToLower();
                        Geo.ChiDan = strInstruction;
                        Geo.MoTa = strDescription;
                        Geo.KhoangCach = (float)Math.Round(double.Parse(strDistance), 1);
                        Geo.KinhDo = strX;
                        Geo.ViDo = strY;
                        lstInfo.Add(Geo);
                    }
                    return lstInfo;
                }
                else return null;
            }
            else return null;
        }

        private XLSType createRouteServiceRequest(double VDStart, double KDStart, double VDEnd, double KDEnd)
        {
            XlsDocument xLSDocument = XlsDocument.CreateDocument();
            XLSType xLSTypeRequest = xLSDocument.XLS.Append();

            // should be added one only
            RequestUtil.addXlsHeader(ref xLSTypeRequest);

            RequestType requestType = xLSTypeRequest.Request.Append();
            requestType.methodName.Value = "DetermineRouteRequest";

            DetermineRouteRequestType determineRouteRequest = requestType.DetermineRouteRequest.Append();

            RoutePlanType routePlanType = determineRouteRequest.RoutePlan.Append();
            RoutePreferenceTypeType routePreferenceTypeType = routePlanType.RoutePreference.Append();
            routePreferenceTypeType.Value = "Shortest";
            WayPointListType wayPointListType = routePlanType.WayPointList.Append();

            // start
            WayPointType wayPointTypeStartPoint = wayPointListType.StartPoint.Append();
            PositionType positionTypeStartPoint = wayPointTypeStartPoint.Position.Append();
            PointType pointTypeStartPoint = positionTypeStartPoint.Point.Append();
            DirectPositionType directPositionTypeStartPoint = pointTypeStartPoint.pos.Append();
            directPositionTypeStartPoint.Value = VDStart.ToString() + " " + KDStart.ToString();

            // end
            WayPointType wayPointTypeEndPoint = wayPointListType.EndPoint.Append();
            PositionType positionTypeEndPoint = wayPointTypeEndPoint.Position.Append();
            PointType pointTypeEndPoint = positionTypeEndPoint.Point.Append();
            DirectPositionType directPositionTypeEndPoint = pointTypeEndPoint.pos.Append();
            directPositionTypeEndPoint.Value = VDEnd.ToString() + " " + KDEnd.ToString();
            determineRouteRequest.RouteGeometryRequest.Append();
            // add this if need the text instructions
            RouteInstructionsRequestType routeInstructionsRequestType = determineRouteRequest.RouteInstructionsRequest.Append();
            routeInstructionsRequestType.format.Value = "text/plain";
            return xLSTypeRequest;
        }
        /// <summary>
        /// lay nhieu ket qua
        /// </summary>
        /// <param name="xLSTypeResponse"></param>
        public ArrayList GetArrDiaChi(List<PointF> Data)
        {
            ReverseGeocoderTest reverseGeocoderTest = new ReverseGeocoderTest();
            XLSType xLSTypeRequest = reverseGeocoderTest.CreateRequest(Data);
            XLSType xLSTypeResponse = RequestUtil.perform(xLSTypeRequest);
            ArrayList result = new ArrayList();
            if (xLSTypeResponse.Response.Exists)
            {
                string Duong = "", Xa = "", Huyen = "", Tinh = "";
                for (int i = 0; i < xLSTypeResponse.Response.Count; i++)
                {

                    ResponseType responseType = xLSTypeResponse.Response[i];
                    ReverseGeocodeResponseType reverseGeocodeResponseType = responseType.ReverseGeocodeResponse.First;

                    if (reverseGeocodeResponseType.ReverseGeocodedLocation.Exists)
                    {
                        ReverseGeocodedLocationType reverseGeocodedLocationType = reverseGeocodeResponseType.ReverseGeocodedLocation.First;
                        PointType pointType = reverseGeocodedLocationType.Point.First;
                        DirectPositionType directPositionType = pointType.pos.First;
                        AddressType addressType = reverseGeocodedLocationType.Address.First;
                        StreetAddressType streetAddressType = addressType.StreetAddress.First;


                        string strStreetName = "";
                        string buildingNumber = "";
                        string strCommuneName = "";
                        string strDistrictName = "";
                        string strProvinceName = "";

                        if (streetAddressType.Building.Exists)
                        {
                            BuildingLocatorType buildingLocatorType = streetAddressType.Building.First;
                            buildingNumber = buildingLocatorType.number.Value.Trim();
                        }

                        if (streetAddressType.Street.Exists)
                        {
                            StreetNameType streetNameType = streetAddressType.Street.First;
                            strStreetName = streetNameType.Value.Trim();
                        }

                        for (int j = 0; j < addressType.Place.Count; j++)
                        {
                            NamedPlaceType namedPlaceType = addressType.Place.At(j);
                            if (namedPlaceType.type.Value == "Municipality")
                            {
                                strCommuneName = namedPlaceType.Value.Trim();
                            }
                            else if (namedPlaceType.type.Value == "CountrySecondarySubdivision")
                            {
                                strDistrictName = namedPlaceType.Value.Trim();
                            }
                            else if (namedPlaceType.type.Value == "CountrySubdivision")
                            {
                                strProvinceName = namedPlaceType.Value.Trim();
                            }
                        }

                        string[] latlong = directPositionType.Value.Split(new string[] { " " }, StringSplitOptions.None);

                        string KetQua = "";
                        strStreetName = strStreetName.Trim();
                        strCommuneName = strCommuneName.Trim();
                        strDistrictName = strDistrictName.Trim();
                        strProvinceName = strProvinceName.Trim();
                        if (strStreetName != "")
                        {
                            if (Duong != strStreetName)
                            {
                                KetQua += "Đường " + strStreetName + ", ";
                                if (Xa != strCommuneName)
                                {
                                    if (strCommuneName != "") KetQua += strCommuneName + ", ";
                                    if (Huyen != strDistrictName)
                                    {
                                        if (strDistrictName != "") KetQua += strDistrictName + ", ";
                                        if (Tinh != strProvinceName)
                                        {
                                            if (strProvinceName != "") KetQua += strProvinceName;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Xa != strCommuneName)
                                {
                                    if (strCommuneName != "") KetQua += strCommuneName + ", ";
                                    if (Huyen != strDistrictName)
                                    {
                                        if (strDistrictName != "") KetQua += strDistrictName + ", ";
                                        if (Tinh != strProvinceName)
                                        {
                                            if (strProvinceName != "") KetQua += strProvinceName;
                                        }
                                    }
                                }
                                else
                                {
                                    if (Huyen != strDistrictName)
                                    {
                                        if (strDistrictName != "") KetQua += strDistrictName + ", ";
                                        if (Tinh != strProvinceName)
                                        {
                                            if (strProvinceName != "") KetQua += strProvinceName;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Xa != strCommuneName)
                            {
                                KetQua += strCommuneName + ", ";
                                if (Huyen != strDistrictName)
                                {
                                    if (strDistrictName != "") KetQua += strDistrictName + ", ";
                                    if (Tinh != strProvinceName)
                                    {
                                        if (strProvinceName != "") KetQua += strProvinceName;
                                    }
                                }
                            }
                            else
                            {
                                if (Huyen != strDistrictName)
                                {
                                    if (strDistrictName != "") KetQua += strDistrictName + ", ";
                                    if (Tinh != strProvinceName)
                                    {
                                        if (strProvinceName != "") KetQua += strProvinceName;
                                    }
                                }
                            }
                        }
                        /*
                        if (i == (xLSTypeResponse.Response.Count - 1))
                        {
                           // if (KetQua == "")
                           // {
                            KetQua = "";
                                if (strStreetName != "") KetQua += "Đường " + strStreetName + ", ";
                                if (strCommuneName != "") KetQua += strCommuneName + ", ";
                                if (strDistrictName != "") KetQua += strDistrictName + ", ";
                                if (strProvinceName != "") KetQua += strProvinceName;
                           // }
                        }
                         */
                        Duong = strStreetName;
                        Xa = strCommuneName;
                        Huyen = strDistrictName;
                        Tinh = strProvinceName;
                        if (KetQua != "")
                        {
                            if (KetQua.Substring(KetQua.Length - 1) == " ") KetQua = KetQua.Remove(KetQua.Length - 2);
                        }
                        result.Add(KetQua);
                    }
                }

            }
            return result;
        }
    }
}
