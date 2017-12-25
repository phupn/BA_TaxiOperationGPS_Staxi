using System;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Common
{
    public class LookupEdit_Year : InputLookUp, IShControl
    {
        public void Bind()
        {
            Properties.ValueMember = Properties.DisplayMember = "Year";
            Properties.Columns.Add(new LookUpColumnInfo("Year", "Chọn năm"));
            Properties.DataSource = Enumerable.Range(2014, DateTime.Today.Year - 2014 + 1).Select(y => new { Year = y.ToString() }).ToList();
            this.SetValue(DateTime.Today.Year.ToString());
        }
    }
}
