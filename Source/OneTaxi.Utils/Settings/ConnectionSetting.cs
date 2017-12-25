using System;
using System.IO;

namespace OneTaxi.Utils.Settings
{
    public class ConnectionSetting
    {
        public static OneTaxiSettings MySettingObject { set; get; }

        private static string _ConnectionString;

        public static string ConnectionString
        {
            get
            {
                if (MySettingObject == null)
                {
                    //Read Setting file
                    string path = System.Windows.Forms.Application.StartupPath;
                    path = Path.Combine(path, "Settings");
                    // Create folder if it doesn't already exist
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    //Set Setting Object
                    MySettingObject = new OneTaxiSettings();
                    MySettingObject.SettingsPath = Path.Combine(path, "Settings.xml");
                    MySettingObject.EncryptionKey = "binhanh.vn";
                    MySettingObject.Load();
                }

                if (string.IsNullOrEmpty(_ConnectionString))
                    _ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout=60;",
                                            MySettingObject.DataSource,
                                            MySettingObject.InitialCatalog,
                                            MySettingObject.UserID,
                                            MySettingObject.Password);
                return _ConnectionString;
            }
        }
        public static void SetConnectionString(string strConnect)
        {
            _ConnectionString = strConnect;
        }
    }
}
