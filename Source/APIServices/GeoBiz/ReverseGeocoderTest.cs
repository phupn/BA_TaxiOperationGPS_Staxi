using System;
using System.Collections.Generic;
using System.Text;
using XlsClient.xls;
using XlsClient.gml;
using System.Drawing;
using System.Collections;
namespace APIServices.GeoBiz
{
    public class ReverseGeocoderTest
    {
        private void addReverseGeocodeRequest(ref XLSType xLSType, string strPoint, string requestID)
        {
            RequestType requestType = xLSType.Request.Append();
            requestType.methodName.Value = "ReverseGeocodeRequest";

            ReverseGeocodeRequestType reverseGeocodeRequestType = requestType.ReverseGeocodeRequest.Append();

            ReverseGeocodePreferenceTypeType reverseGeocodePreferenceType = reverseGeocodeRequestType.ReverseGeocodePreference.Append();
            reverseGeocodePreferenceType.Value = "StreetAddress";

            PositionType positionType = reverseGeocodeRequestType.Position.Append();
            PointType pointType = positionType.Point.Append();

            DirectPositionType directPositionType = pointType.pos.Append();
            directPositionType.Value = strPoint;
        }

        public XLSType createXlsRequestTest(double x, double y)
        {
            XlsDocument xLSDocument = XlsDocument.CreateDocument();
            XLSType xLSType = xLSDocument.XLS.Append();
            xLSType.lang.Value = ServiceConfigProperties.Language;
            // should be added one only
            RequestUtil.addXlsHeader(ref xLSType);

            // can be added more than one
            //double x = 105.81783721316403;
            //double y = 21.028330217040492;
            //Random random = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    double x1 = x + random.NextDouble() / 100;
            //    double y1 = y + random.NextDouble() / 100;
            //string strPoint = y1 + " " + x1;
            //string requestId = "request_" + i;
            addReverseGeocodeRequest(ref xLSType, y + " " + x, "request_0");
            //}

            return xLSType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DuLieu"></param>
        /// <returns></returns>
        public XLSType CreateRequest(List<PointF> DuLieu)
        {
            XlsDocument xLSDocument = XlsDocument.CreateDocument();
            XLSType xLSType = xLSDocument.XLS.Append();
            xLSType.lang.Value = ServiceConfigProperties.Language;

            if (DuLieu.Count == 0) return xLSType;
            RequestUtil.addXlsHeader(ref xLSType);

            for (int i = 0; i < DuLieu.Count; i++)
            {
                string strPoint = DuLieu[i].X + " " + DuLieu[i].Y;
                string requestId = "request_" + i.ToString();
                addReverseGeocodeRequest(ref xLSType, strPoint, requestId);
            }

            return xLSType;
        }
    }
}
