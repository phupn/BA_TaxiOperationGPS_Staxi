using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BACryptor;
using StaxiMan_DAL;
using Taxi.Common.Extender;
using Taxi.Logger;
using Taxi.MessageBox;
using Taxi.Utils;

namespace StaxiMan
{
    public partial class CompanyDatabaseManagement_Form : StaxiMan_FormBase
    {
        #region Init & Constructors
        private const string KeyEngypt = "binhanh.vn";

        public CompanyDatabaseManagement_Form()
        {
            InitializeComponent();
        }

        #endregion

        #region Events!

        private void CompanyDatabaseManagement_Form_Load(object sender, EventArgs e)
        {
            LoadSystemInformation();           
        }

        private void gridView_SystemInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = (SystemInformation)gridView_SystemInfo.GetFocusedRow();
                if (row != null)
                {
                    var connect = CompanyConnection.Inst.GetAll().ToList<CompanyConnection>().Find(a => a.Id == row.FK_Connection_ID);
                    string pass = new Encryption(KeyEngypt).Decrypt(connect.Password);

                    DataTable dtTableRow = row.GetStatisticTableRow(connect.Source, connect.Catalog, connect.UserName,
                        pass);
                    if (dtTableRow.Rows.Count > 0)
                        gridControl_RowCount.DataSource = dtTableRow;

                    DataTable dtDiskSpace = row.GetDiskSpaceInfo(connect.Source, connect.Catalog, connect.UserName, pass);
                    if (dtDiskSpace.Rows.Count > 0)
                        gridControl_Disk.DataSource = dtDiskSpace;

                    DataTable dtDataBaseInfo = row.GetDataBaseInfo(connect.Source, connect.Catalog, connect.UserName,
                        pass);
                    if (dtDataBaseInfo.Rows.Count > 0)
                        gridControl_DB.DataSource = dtDataBaseInfo;
                }
                else
                {
                    new MessageBoxBA().Show("Bạn vui lòng chọn thông tin server trên lưới!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Exclamation);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridView_SystemInfo_DoubleClick: ", ex);
                new MessageBoxBA().Show("Có lỗi khi lấy dữ liệu cơ sở dữ liệu!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Error);
            }
        }

        private void btnTruncate_Click(object sender, EventArgs e)
        {
            try
            {
                var row = (SystemInformation) gridView_SystemInfo.GetFocusedRow();
                if (row != null)
                {
                    var connect = CompanyConnection.Inst.GetAll().ToList<CompanyConnection>().Find(a=>a.Id== row.FK_Connection_ID);
                    string pass = new Encryption(KeyEngypt).Decrypt(connect.Password);
                    string msg = new MessageBoxBA().Show("Bạn có chắc chắn muốn truncate cơ sở dữ liệu ? (Bạn phải cân nhắc thật kĩ khi sử dụng chức năng này!!!)","Thông báo",MessageBoxButtonsBA.YesNo,MessageBoxIconBA.Question);
                    if (msg == "Yes")
                    {
                        if (SystemInformation.Inst.TruncateDataBase(connect.Source, connect.Catalog, connect.UserName,pass))
                        {
                            new MessageBoxBA().Show("Truncate Database thành công!", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Information);
                        }
                    }

                }
                else
                {
                    new MessageBoxBA().Show("Bạn vui lòng chọn thông tin server trên lưới!", "Thông báo", MessageBoxButtonsBA.Yes, MessageBoxIconBA.Exclamation);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnTruncate_Click: ", ex);                
            }
        }

        private void btnShrinkDB_Click(object sender, EventArgs e)
        {
            try
            {
                var row = (SystemInformation)gridView_SystemInfo.GetFocusedRow();
                if (row != null)
                {
                    var connect = CompanyConnection.Inst.GetAll().ToList<CompanyConnection>().Find(a => a.Id == row.FK_Connection_ID);
                    string pass = new Encryption(KeyEngypt).Decrypt(connect.Password);
                    string msg = new MessageBoxBA().Show("Bạn có chắc chắn muốn Shrink cơ sở dữ liệu? (Bạn phải cân nhắc thật kĩ khi sử dụng chức năng này!!!)","Thông báo", MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                    if (msg == "Yes")
                    {
                        if(SystemInformation.Inst.ShinkLogDataBase(connect.Source, connect.Catalog, connect.UserName, pass))
                        {
                            new MessageBoxBA().Show("Shrink Database thành công!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Information);
                        }
                    }
                }
                else
                {
                    new MessageBoxBA().Show("Bạn vui lòng chọn thông tin server trên lưới!","Thông báo",MessageBoxButtonsBA.Yes,MessageBoxIconBA.Exclamation);
                }
                
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnShrinkDB_Click: ",ex);                
            }
        }

        #endregion

        #region Methods
        private void LoadSystemInformation()
        {
            try
            {
                string tempData = string.Empty;
                string[] arrData = null;
                var lstSysInfo = new List<SystemInformation>();
                var lstServer = CompanyConnection.Inst.GetAll().ToList<CompanyConnection>();
                foreach (CompanyConnection item in lstServer)
                {
                    if (!CheckExistServer(item))
                        continue;
                    SystemInformation objInfo = new SystemInformation();
                    objInfo.FK_Connection_ID = item.Id;
                    objInfo.WANIP = item.Source;
                    string pass = new Encryption(KeyEngypt).Decrypt(item.Password);
                    var tempTable = SystemInformation.Inst.GetServerInformation(item.Source, item.Catalog, item.UserName, pass);
                    foreach (DataRow row in tempTable.Rows)
                    {
                        tempData = row[0].ToString();
                        arrData = tempData.Split(new[] { ": " }, StringSplitOptions.None);
                        if (arrData.Count() > 1)
                        {
                            GetSystemInfo(arrData, ref objInfo);
                        }
                    }

                    if (!string.IsNullOrEmpty(objInfo.HostName))
                    {
                        lstSysInfo.Add(objInfo);
                        gridControl_SystemInfo.DataSource = lstSysInfo;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadSystemInformation: ", ex);
            }
        }

        private bool CheckExistServer(CompanyConnection pServer)
        {
            string ipAddress = string.Empty;

            if (pServer.Source.Contains(","))
                ipAddress = NetworkInformation.FormatIP(pServer.Source, ",");

            if (ipAddress.Length > 3)
            {
                if (NetworkInformation.PingHost(ipAddress))
                    return true;
            }

            if (pServer.Source.Contains("\\"))
                ipAddress = NetworkInformation.FormatIP(pServer.Source, "\\");
            if (ipAddress.Length > 3)
            {
                if (NetworkInformation.PingHost(ipAddress))
                    return true;
            }
            if (NetworkInformation.PingHost(pServer.Source))
                return true;

            return false;
        }

        private void GetSystemInfo(string[] arrData, ref SystemInformation objInfo)
        {
            try
            {
                if (arrData[0].Contains("Host Name"))
                    objInfo.HostName = arrData[1].Trim();
                if (arrData[0].Contains("OS Name"))
                    objInfo.OS = arrData[1].Trim();
                if (arrData[0].Contains("Original Install"))
                    objInfo.InstallDate = arrData[1].Trim();
                if (arrData[0].Contains("Boot Time"))
                    objInfo.BootTime = arrData[1].Trim();
                if (arrData[0].Contains("System Type"))
                    objInfo.SystemType = arrData[1].Trim();
                if (arrData[0].Contains("Time Zone"))
                    objInfo.TimeZone = arrData[1].Trim();
                if (arrData[0].Contains("Total Physical"))
                    objInfo.TotalMemory = arrData[1].Trim();
                if (arrData[0].Contains("Available Physical"))
                    objInfo.AvailableMemory = arrData[1].Trim();
                if (arrData[1].Contains("192."))
                    objInfo.LANIP = arrData[1].Trim();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetSystemInfo: ", ex);
            }
        }
       

        #endregion
    }
}
