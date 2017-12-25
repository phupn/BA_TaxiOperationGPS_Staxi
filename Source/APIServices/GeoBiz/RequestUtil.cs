using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using XlsClient.xls;

namespace APIServices.GeoBiz
{
    public class RequestUtil
    {
        public static void addXlsHeader(ref XLSType xLSType)
        {
            RequestHeaderType requestHeaderType = xLSType.RequestHeader.Append();
            requestHeaderType.clientName.Value = ServiceConfigProperties.clientUserName;
            requestHeaderType.clientPassword.Value = ServiceConfigProperties.clientPassword;
        }

        public static XLSType perform(XLSType xLSTypeRequest)
        {
            XLSType xLSTypeResponse = null;

            WebClient webClient = new WebClient();
            //webClient.Headers.Add("Content-Type", "text/xml");
            //webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add("SOAPAction", "http://www.opengis.net/xls");
            webClient.Encoding = System.Text.Encoding.UTF8;
            XlsDocument xLSDocument = XlsDocument.CreateDocument();
            //xLSDocument.XLS.
            //xLSDocument.setXLS(xLSTypeRequest);

            string strRequest = getStringSoapMessage(xLSTypeRequest.Node.OuterXml);
            string strResponse = webClient.UploadString(ServiceConfigProperties.EndPointURL, "POST", strRequest);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strResponse);



            XmlNodeList xlsNodeList = xmlDoc.GetElementsByTagName("XLS", "http://www.opengis.net/xls");
            if (xlsNodeList.Count > 0)
            {
                XmlNode xlsNode = xlsNodeList.Item(0);
                xLSDocument = XlsDocument.LoadFromString(xlsNode.OuterXml);
                //xLSTypeResponse = XLSType.Factory.parse(xlsNode.OuterXml);

                xLSTypeResponse = xLSDocument.XLS.First;
            }

            return xLSTypeResponse;
        }

        public static string getStringSoapMessage(string content)
        {
            string strRequest = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xls=\"http://www.opengis.net/xls\">";
            strRequest += "<SOAP-ENV:Header/>";
            strRequest += "    <SOAP-ENV:Body>";
            strRequest += content;
            strRequest += "   </SOAP-ENV:Body>";
            strRequest += "</SOAP-ENV:Envelope>";

            return strRequest;
        }

    }
}
