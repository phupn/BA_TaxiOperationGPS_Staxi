using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Extender
{
    public static class DataTableEx
    {
        public static DataTable ToDataTableEnVang(this DataTable dt, string sohieuxe = "SoXe")
        {
            return dt.ToDataTableFieldType(sohieuxe, typeof(Int32), true);
        }

        public static DataTable ToDataTableFieldType(this DataTable dt, string name, Type type, bool checkNull = false, bool sort = true)
        {
            var dtCloned = dt.Clone();
            dt.Columns[name].AllowDBNull = checkNull;
            dtCloned.Columns[name].DataType = type;
            dtCloned.Columns[name].AllowDBNull = checkNull;
            foreach (DataRow row in dt.Rows)
            {
                if (string.IsNullOrEmpty(row[name].ToString().Trim()))
                {
                    row[name] = DBNull.Value;
                    row.AcceptChanges();
                }
                try
                {
                    dtCloned.ImportRow(row);
                }
                catch
                {
                }
            }
            if (!sort) return dtCloned;
            var dataview = dtCloned.DefaultView;
            dataview.Sort = name;
            return dataview.ToTable();
        }
    }
}
