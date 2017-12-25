using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Utils.Settings
{
    // Create customized Settings class
    public class MySettings : SettingsBase
    {
        // Declare application settings
        public string IPAddress { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

        // Must override WriteSettings() to write values
        public override void WriteSettings(UserSettingsWriter writer)
        {
            writer.Write("IPAddress", IPAddress);
            writer.WriteEncrypted("Source", DataSource);
            writer.WriteEncrypted("Catalog", InitialCatalog);
            writer.WriteEncrypted("User", UserID);
            writer.WriteEncrypted("Password", Password);
        }

        // Must override ReadSettings() to read values
        public override void ReadSettings(UserSettingsReader reader)
        {
            IPAddress = reader.Read("IPAddress", "");
            DataSource = reader.ReadEncrypted("Source", "");
            InitialCatalog = reader.ReadEncrypted("Catalog", "");
            UserID = reader.ReadEncrypted("User", "");
            Password = reader.ReadEncrypted("Password", "");
        }
    }
}
