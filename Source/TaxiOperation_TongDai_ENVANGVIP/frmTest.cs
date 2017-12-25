using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Geocoding;
using Geocoding.Google;
using GMap.NET;
using GMap.NET.MapProviders;
using Taxi.Utils;

namespace TaxiOperation_TongDai
{
  
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
       }

        private void GetGeo()
        {
            var en = new testData();
            var data = en.GetData();
            //    IGeocoder geocoder = new GoogleGeocoder();
            foreach (DataRow row in data.Rows)
            {
                //if (row["Lat"] == DBNull.Value)
                {
                    try
                    {
                    var geo = new GoogleGeocoder()
                    {
                        Language = "VN"
                    }.Geocode(row["AddressVN"].ToString() + ",Việt Nam");
                    if (geo != null && geo.Any())
                    {
                        row["Lat"] = geo.First().Coordinates.Latitude;
                        row["Lng"] = geo.First().Coordinates.Longitude;
                        row.AcceptChanges();
                        en.Update(geo.First().Coordinates.Latitude, geo.First().Coordinates.Longitude,
                            long.Parse(row["PK_DistrictID"].ToString()));
                    }
                    else
                    {

                        en.Update(0, 0, long.Parse(row["PK_DistrictID"].ToString()));
                    }


                    }
                    catch (Exception)
                    {
                        en.Update(0, 0, long.Parse(row["PK_DistrictID"].ToString()));
                    }
                    //string toaDo = Service_Common.ServiceSoapClient.GetGeobyAddressBA3(row["AddressVN"].ToString());
                    //double lat = 0;
                    //double lng = 0;
                    //if (toaDo != "*" && toaDo != string.Empty)
                    //{
                    //    string[] arrString = toaDo.Split(' ');

                    //    double.TryParse(arrString[0], out lat);
                    //    double.TryParse(arrString[1], out lng);
                    //    en.Update(lat, lng, long.Parse(row["PK_DistrictID"].ToString()));
                    //}
                    //else
                    //{

                    //    en.Update(lat, lng, long.Parse(row["PK_DistrictID"].ToString()));
                    //    //MessageBox.Show("Không tìm thấy tọa độ:" + row["AddressVN"].ToString());
                    //}
                    Thread.Sleep(1000);
                }
            }
        }

        private void frmTest_Load(object sender, EventArgs e){
            extendedGMapControl1.CacheLocation = Application.StartupPath + "\\Map";
            //MainMap.CacheLocation = System.Configuration.ConfigurationManager.AppSettings["MapPath"]; 
            extendedGMapControl1.Manager.Mode = AccessMode.ServerAndCache;
            
            extendedGMapControl1.MapProvider = GMapProviders.GoogleMap;
            extendedGMapControl1.MaxZoom = 19;
            extendedGMapControl1.MinZoom = 7;
            extendedGMapControl1.Zoom = 15;
            extendedGMapControl1.Dock = DockStyle.Fill;
            extendedGMapControl1.Zoom = 10;autoCompleteAddress1.Bind();
            //GetGeo();
            DateTime a = DateTime.Now;
            DateTime b = new DateTime(2015, 05, 15);
            TimeSpan c = b.Subtract(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void autoCompleteAddress1_EventSelectAutoComplete(DataRow row)
        {
            extendedGMapControl1.Position = new PointLatLng(autoCompleteAddress1.Lat, autoCompleteAddress1.Lng);
           //extendedGMapControl1.FromLatLngToLocal(new PointLatLng(autoCompleteAddress1.Lat, autoCompleteAddress1.Lng));
         
        }
    }
    class testData : DBObject
    {
        public DataTable GetData()
        {
            return
                RunSQL(
                    @"SELECT T1.*,T2.NameVN NameProvinceVN ,T2.NameEN NameProvinceEN,(T1.NameVN+','+T2.NameVN) AddressVN  FROM [dbo].[GIS.T_DISTRICT] T1  JOIN dbo.[GIS.T_PROVINCE] T2 ON T1.FK_ProvinceID=T2.PK_ProvinceID", "Test");
        }

        public void Update(double lat, double lng, long id)
        {
            RunSQL(string.Format("UPDATE [dbo].[GIS.T_DISTRICT] SET [Lat] = {0},[Lng] = {1} where [PK_DistrictID] ={2}",lat,lng,id));
        }
     //   public void run
    }
   }
