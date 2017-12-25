using System;
using System.Data;
using Taxi.Controls.Base.Inputs;
using Taxi.Utils;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
namespace Taxi.Controls.Base.Common
{
    public class AutoCompleteAddressEx : AutoCompleteAddress, IShControl,IShInput, IShKeyPress, ITextChange
    {
        public new object GetValue()
        {
            return this.Text;
        }
    }
    public class AutoCompleteAddress : AutoCompleteTextbox, IShControl,IShInput, IShKeyPress, ITextChange
    {
        public void Bind()
        {
            this.DisplayMember = "AddressVN";
            this.ValueMember = "PK_DistrictID";
       
            AutoCompleteList = Address.GetData();
        }
        public string HuyenVN
        {
            get { return DataRowSelect==null||DataRowSelect["NameVN"]==null||DataRowSelect["NameVN"]==DBNull.Value?"":DataRowSelect["NameVN"].ToString(); }
        }
        public string HuyenEN
        {
            get { return DataRowSelect == null || DataRowSelect["NameEN"] == null || DataRowSelect["NameEN"] == DBNull.Value ? "" : DataRowSelect["NameEN"].ToString(); }
        }
        public string TinhVN
        {
            get { return DataRowSelect == null || DataRowSelect["NameProvinceVN"] == null || DataRowSelect["NameProvinceVN"] == DBNull.Value ? "" : DataRowSelect["NameProvinceVN"].ToString(); }
        }
        public string TinhEN
        {
            get { return DataRowSelect == null || DataRowSelect["NameProvinceEN"] == null || DataRowSelect["NameProvinceEN"] == DBNull.Value ? "" : DataRowSelect["NameProvinceEN"].ToString(); }
        }

        public int TinhId
        {
            get { return DataRowSelect == null || DataRowSelect["TinhId"] == null || DataRowSelect["TinhId"] == DBNull.Value ? 0 : int.Parse(DataRowSelect["TinhId"].ToString()); }
           
        }
        public int HuyenId
        {
            get { return DataRowSelect == null || DataRowSelect["HuyenId"] == null || DataRowSelect["HuyenId"] == DBNull.Value ? 0 : int.Parse(DataRowSelect["HuyenId"].ToString()); }

        }
        public float Lat { get { return DataRowSelect == null || DataRowSelect["Lat"] == null || DataRowSelect["Lat"] == DBNull.Value ? 0 : float.Parse(DataRowSelect["Lat"].ToString()); } }
        public float Lng { get { return DataRowSelect == null || DataRowSelect["Lng"] == null || DataRowSelect["Lng"] == DBNull.Value ? 0 : float.Parse(DataRowSelect["Lng"].ToString()); } }
        public float TempLat;
        public float TempLng;

        /// <summary>
        /// Cho phép bóc tác chỗi ký thự
        /// </summary>
        public void ReSearch()
        {
            if (!string.IsNullOrEmpty(this.Text)&& AutoCompleteList != null && AutoCompleteList.Rows.Count > 0)
            {
                this.HideSuggestionListBox();
                var s = this.Text.RemoveRoutePr().Split(',');
                if (s.Length > 1)
                {
                    string tinh = s[s.Length - 1].Trim();
                    string huyen = s[s.Length - 2].Trim();
                    foreach (DataRow row in AutoCompleteList.Rows)
                    {
                        if (SearchText(row, tinh) && SearchText(row, huyen))
                        {
                            this.DataRowSelect = row;
                            return;
                        }
                    }

                }
            }
        }

        protected override void OnSelectItem(DataRow row)
        {
            TempLat = 0;
            TempLng = 0;
        }
        
    }
    /// <summary>
    /// Bao gồm cả xã huyện tỉnh
    /// </summary>
    public class AutoCompleteAddressFull : AutoCompleteTextbox, IShControl
    {
        #region Field
        public string HuyenVN
        {
            get { return DataRowSelect == null || DataRowSelect["NameVN"] == null || DataRowSelect["NameVN"] == DBNull.Value ? "" : DataRowSelect["NameVN"].ToString(); }
        }
        public string HuyenEN
        {
            get { return DataRowSelect == null || DataRowSelect["NameEN"] == null || DataRowSelect["NameEN"] == DBNull.Value ? "" : DataRowSelect["NameEN"].ToString(); }
        }
        public string TinhVN
        {
            get { return DataRowSelect == null || DataRowSelect["NameProvinceVN"] == null || DataRowSelect["NameProvinceVN"] == DBNull.Value ? "" : DataRowSelect["NameProvinceVN"].ToString(); }
        }
        public string TinhEN
        {
            get { return DataRowSelect == null || DataRowSelect["NameProvinceEN"] == null || DataRowSelect["NameProvinceEN"] == DBNull.Value ? "" : DataRowSelect["NameProvinceEN"].ToString(); }
        }

        public int TinhId
        {
            get { return DataRowSelect == null || DataRowSelect["TinhId"] == null || DataRowSelect["TinhId"] == DBNull.Value ? 0 : int.Parse(DataRowSelect["TinhId"].ToString()); }

        }
        public int HuyenId
        {
            get { return DataRowSelect == null || DataRowSelect["HuyenId"] == null || DataRowSelect["HuyenId"] == DBNull.Value ? 0 : int.Parse(DataRowSelect["HuyenId"].ToString()); }

        }
        public int XaId
        {
            get { return DataRowSelect == null || DataRowSelect["XaId"] == null || DataRowSelect["XaId"] == DBNull.Value ? 0 : int.Parse(DataRowSelect["XaId"].ToString()); }

        }
        public float Lat { get { return DataRowSelect == null || DataRowSelect["Lat"] == null || DataRowSelect["Lat"] == DBNull.Value ? 0 : float.Parse(DataRowSelect["Lat"].ToString()); } }
        public float Lng { get { return DataRowSelect == null || DataRowSelect["Lng"] == null || DataRowSelect["Lng"] == DBNull.Value ? 0 : float.Parse(DataRowSelect["Lng"].ToString()); } }
        public float TempLat;
        public float TempLng;
        #endregion
        public void Bind()
        {
            this.DisplayMember = "AddressVN";
            this.ValueMember = "XaId";
            AutoCompleteList = Address.GetDataFull();
        }
        public void ReSearch()
        {
            if (!string.IsNullOrEmpty(this.Text) && AutoCompleteList != null && AutoCompleteList.Rows.Count > 0)
            {
                this.HideSuggestionListBox();
                var s = this.Text.Split(',');
                if (s.Length > 2)
                {
                    string tinh = s[s.Length - 1].Trim();
                    string huyen = s[s.Length - 2].Trim();
                    string xa = s[s.Length - 3].Trim();

                    foreach (DataRow row in AutoCompleteList.Rows)
                    {
                        if (SearchText(row, tinh) && SearchText(row, huyen) && SearchText(row, xa))
                        {
                            this.DataRowSelect = row;
                            return;
                        }
                    }
                }
                else if (s.Length > 1)
                {
                    string tinh = s[s.Length - 1].Trim();
                    string huyen = s[s.Length - 2].Trim();
                    
                    foreach (DataRow row in AutoCompleteList.Rows)
                    {
                        if (SearchText(row, tinh) && SearchText(row, huyen))
                        {
                            this.DataRowSelect = row;
                            return;
                        }
                    }

                }
            }
        }
    }

    class Address : DBObject
    {
        public DataTable GetDataTable()
        {
            return
                RunSQL(
                    @"SELECT T1.*,T2.NameVN NameProvinceVN ,T2.NameEN NameProvinceEN,(T1.NameVN+', '+T2.NameVN) AddressVN,T2.PK_ProvinceID TinhId,T1.PK_DistrictID  HuyenId  FROM [dbo].[GIS.T_DISTRICT] T1  JOIN dbo.[GIS.T_PROVINCE] T2 ON T1.FK_ProvinceID=T2.PK_ProvinceID",
                    "Address");
        }

        public DataTable GetDataTableFull()
        {
            return
                RunSQL(
                    @"SELECT T1.*,T2.NameVN NameProvinceVN ,T2.NameEN NameProvinceEN,(T3.NameVN+', '+T1.NameVN+', '+T2.NameVN) AddressVN,T2.PK_ProvinceID TinhId,T1.PK_DistrictID  HuyenId,t3.PK_CommuneID XaId  FROM [dbo].[GIS.T_DISTRICT] T1  JOIN dbo.[GIS.T_PROVINCE] T2 ON T1.FK_ProvinceID=T2.PK_ProvinceID JOIN [GIS.T_COMMUNE] T3 ON T1.PK_DistrictID=T3.FK_DistrictID",
                    "Address");
        }

        public static DataTable GetData()
        {
            return new Address().GetDataTable();
        }

        public static DataTable GetDataFull()
        {
           return new Address().GetDataTableFull();
        }
    }
}
