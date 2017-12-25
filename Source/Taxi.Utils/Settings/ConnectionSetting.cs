using System;
using System.Configuration;
using System.IO;

namespace Taxi.Utils.Settings
{
    public class ConnectionSetting
    {
        public static MySettings MySettingObject { set; get; }

        private static string _connectionString = string.Empty;

        public static int ConnectionTimeOut = 180;

        public static string ConnectionString
        {
            get
            {                                
                if (MySettingObject == null)
                {
                    string path = System.Windows.Forms.Application.StartupPath;
                    path = Path.Combine(path, "Settings");
                    // Create folder if it doesn't already exist
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    MySettingObject = new MySettings();
                    MySettingObject.SettingsPath = Path.Combine(path, "Settings.xml");
                    MySettingObject.EncryptionKey = "binhanh.vn";
                    MySettingObject.Load();
                }
                if(ConfigurationManager.AppSettings["ConnectionTimeOut"] != null)
                {
                    int.TryParse(ConfigurationManager.AppSettings["ConnectionTimeOut"],out ConnectionTimeOut);
                }                
                _connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout={4};",
                                        MySettingObject.DataSource,
                                        MySettingObject.InitialCatalog,
                                        MySettingObject.UserID,//"phupn@123");
                                        MySettingObject.Password,
                                        ConnectionTimeOut);
                return _connectionString;
            }
        }

        public static bool UseDynamicConnection { get; set; }

        public static string DynamicConnectionString { get; set; }

        public static void CreateDynamicConnection(string pDataSource, string pCatalog, string pUserName, string pPassword)
        {
            UseDynamicConnection = true;
            DynamicConnectionString= string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout=180;",
                                                    pDataSource,pCatalog,pUserName,pPassword);
        }

        public static string ConnectionStringService
        {
            get
            {                
                if (MySettingObject == null)
                {
                    //Read Setting file
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    path = Path.Combine(path, "Settings");
                    // Create folder if it doesn't already exist
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    //Set Setting Object
                    MySettingObject = new MySettings();
                    MySettingObject.SettingsPath = Path.Combine(path, "Settings.xml");
                    MySettingObject.EncryptionKey = "binhanh.vn";
                    MySettingObject.Load();
                }
                _connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout=60;",
                                        MySettingObject.DataSource,
                                        MySettingObject.InitialCatalog,
                                        MySettingObject.UserID,//"phupn@123");
                                        MySettingObject.Password);
                return _connectionString;
            }
        }
    }
}
