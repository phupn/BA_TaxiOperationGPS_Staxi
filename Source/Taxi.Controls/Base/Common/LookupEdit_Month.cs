using System;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Common
{
    public class LookupEdit_Month : InputLookUp, IShControl
    {
        public void Bind()
        {
            Properties.ValueMember = Properties.DisplayMember = "Month";
            Properties.Columns.Add(new LookUpColumnInfo("Month", "Chọn tháng"));
            Properties.DataSource = Enumerable.Range(1, 12).Select(m => new { Month = m.ToString() }).ToList();
            this.SetValue(DateTime.Today.Month.ToString());
        }
    }
}
