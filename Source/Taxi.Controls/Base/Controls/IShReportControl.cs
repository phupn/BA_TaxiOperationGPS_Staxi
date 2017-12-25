using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Controls
{
    /// <summary>
    /// Mở ra phương thức thiết lập DataSource cho control
    /// </summary>
    public interface IShReportControl
    {
        /// <summary>
        /// Thiết lập DataSource cho control
        /// </summary>
        /// <param name="obj"></param>
        void SetDataSource(object obj);

        int TabIndex { set; get; }
    }
}
