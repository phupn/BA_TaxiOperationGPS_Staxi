using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Common.Extender;

namespace Staxi_ReplacePhoneNumber
{
    public class DBServices : DbEntityBase<DBServices>
    {
        /// <summary>
        /// Lấy tất cả các bảng dữ liệu của database
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTableName()
        {
            return ExeStore("SP_SYSTABLE_LIST");
        }
        /// <summary>
        /// Lấy tất cả column của 1 bảng
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetAllColumnByTableName(string tableName)
        {
            return ExeStore("SP_SYSTABLE_COLUMN_LIST", tableName);
        }

        /// <summary>
        /// Lấy tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetData_Table(string tableName)
        {
            return ExeStore("SP_SYSTABLE_DATA", tableName);
        }
        /// <summary>
        /// Lấy tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetData_Table(string tableName, string columnName, string value, string replace)
        {
            return ExeStore("SP_SYSTABLE_DATA_REVIEW", tableName, columnName, value, replace);
        }
        /// <summary>
        /// Lấy tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetData_Table_Column(string tableName, string columnName, string value, string replace)
        {
            return ExeStore("SP_SYSTABLE_DATA_COLUMN", tableName, columnName, value, replace);
        }

        /// <summary>
        /// Replace Value cho toan bo table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <param name="replaceValue"></param>
        /// <returns></returns>
        public bool ReplaceData(string tableName,string columnName, string value, string replaceValue)
        {
            return ExeStoreNoneQuery("SP_SYSTABLE_DATA_UPDATE", tableName, columnName, value, replaceValue) > 0;
        }
    }
}
