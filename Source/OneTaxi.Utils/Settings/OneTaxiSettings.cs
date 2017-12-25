using OneTaxi.Utils.Enums;
using System;

using Staxi.Utils.Extender;
using System.Data.SqlClient;

namespace  OneTaxi.Utils.Settings
{
    public class OneTaxiSettings : SettingsBase
    {
        // Declare application settings
        public string IPAddress { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public int ModuleId { get; set; }
        public EnumModule Module { get { return (EnumModule)ModuleId; } }

        public bool CheckConnect()
        {
            ConnectionSetting.MySettingObject = this;
            ConnectionSetting.SetConnectionString(string.Empty);
            try
            {
                using (var Check = new SqlConnection(ConnectionSetting.ConnectionString))
                {
                    Check.Open();
                    if (Check.State == System.Data.ConnectionState.Open)
                    {
                        Check.Close();
                        return true;
                    }
                }

            }
            catch (Exception ex) { }
           
            return false;
        }
        public override void WriteSettings(UserSettingsWriter writer)
        {
            writer.Write("IPAddress", IPAddress);
            writer.WriteEncrypted("Module",string.Format("{0}", ModuleId));
            writer.WriteEncrypted("Source", DataSource);
            writer.WriteEncrypted("Catalog", InitialCatalog);
            writer.WriteEncrypted("User", UserID);
            writer.WriteEncrypted("Password", Password);
        }

        // Must override ReadSettings() to read values
        public override void ReadSettings(UserSettingsReader reader)
        {
            IPAddress = reader.Read("IPAddress", "");
            ModuleId = reader.ReadEncrypted("Module", "").To<int>();
            DataSource = reader.ReadEncrypted("Source", "");
            InitialCatalog = reader.ReadEncrypted("Catalog", "");
            UserID = reader.ReadEncrypted("User", "");
            Password = reader.ReadEncrypted("Password", "");
        }
    }
}
