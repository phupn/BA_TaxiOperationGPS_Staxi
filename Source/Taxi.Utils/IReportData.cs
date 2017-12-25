using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.BaoCao
{
    public interface IReportData
    {
        DateTime? FromDate { set; get; }
        DateTime? ToDate { set; get; }

        object GetData();
    }
}
