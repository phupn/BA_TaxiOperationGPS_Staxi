
using System;
using System.Data;
using Taxi.Logger;
using Taxi.Utils.Settings;

namespace StaxiMan_DAL
{
    public class SystemInformation : DBServices<SystemInformation>
    {
        public string Company { get; set; }
        public string HostName { get; set; }
        public string OS { get; set; }
        public string InstallDate { get; set; }
        public string BootTime { get; set; }
        public string SystemType { get; set; }
        public string TimeZone { get; set; }
        public string TotalMemory { get; set; }
        public string AvailableMemory { get; set; }
        public string WANIP { get; set; }
        public string LANIP { get; set; }

        public int FK_Connection_ID { get; set; }

        public DataTable GetServerInformation(string pDataSource, string pCatalog, string pUserName, string pPassWord)
        {
            try
            {
                ConnectionSetting.CreateDynamicConnection(pDataSource, pCatalog, pUserName, pPassWord);
                DataTable result = this.ExeStore("[sp_GetServerInformation]");
                ConnectionSetting.UseDynamicConnection = false;
                return result;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetServerInformation: ", ex);
                ConnectionSetting.UseDynamicConnection = false;
                return new DataTable();
            }
        }

        public DataTable GetStatisticTableRow(string pSource, string pCatalog, string pUserName, string pPassWord)
        {
            try
            {
                ConnectionSetting.CreateDynamicConnection(pSource, pCatalog, pUserName, pPassWord);
                DataTable result = this.ExeStore("[sp_StatisticTableRow]");
                ConnectionSetting.UseDynamicConnection = false;
                return result;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetStatisticTableRow: ", ex);
                ConnectionSetting.UseDynamicConnection = false;
                return new DataTable();
            }
        }

        public DataTable GetDiskSpaceInfo(string pSource, string pCatalog, string pUserName, string pPassWord)
        {
            try
            {
                ConnectionSetting.CreateDynamicConnection(pSource, pCatalog, pUserName, pPassWord);
                DataTable result = this.ExeStore("sp_GetDiskSpaceInfo");
                ConnectionSetting.UseDynamicConnection = false;
                return result;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDiskSpaceInfo: ", ex);
                ConnectionSetting.UseDynamicConnection = false;
                return new DataTable();
            }
        }

        public DataTable GetDataBaseInfo(string pSource, string pCatalog, string pUserName, string pPassWord)
        {
            try
            {
                ConnectionSetting.CreateDynamicConnection(pSource, pCatalog, pUserName, pPassWord);
                DataTable result = this.ExeStore("sp_GetDataBaseInfo");
                ConnectionSetting.UseDynamicConnection = false;
                return result;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDataBaseInfo: ", ex);
                ConnectionSetting.UseDynamicConnection = false;
                return new DataTable();
            }
        }

        public bool ShinkLogDataBase(string pSource, string pCatalog, string pUserName, string pPassWord)
        {
            try
            {
                ConnectionSetting.CreateDynamicConnection(pSource, pCatalog, pUserName, pPassWord);
                this.ExeStore("sp_ShrinkDataBase", pCatalog);
                ConnectionSetting.UseDynamicConnection = false;
                return true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShinkLogDataBase: ", ex);
                ConnectionSetting.UseDynamicConnection = false;
                return false;
            }
        }

        public bool TruncateDataBase(string pSource, string pCatalog, string pUserName, string pPassWord)
        {
            try
            {
                ConnectionSetting.CreateDynamicConnection(pSource, pCatalog, pUserName, pPassWord);
                this.ExeStore("sp_TruncateDataBase");
                ConnectionSetting.UseDynamicConnection = false;
                return true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TruncateDataBase: ", ex);
                ConnectionSetting.UseDynamicConnection = false;
                return false;
            }
        }
    }
}
