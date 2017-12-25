using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base.Common.License;
using Taxi.Controls.Base.Extender;

namespace Taxi.Controls.ProductLicense
{
    public partial class ctrlLicenseResponsed : UserControl
    {
        public ctrlLicenseResponsed()
        {
            InitializeComponent();
            if (!System.Diagnostics.Debugger.IsAttached && (LicenseManager.UsageMode != LicenseUsageMode.Designtime) && !DesignMode)
            {
                gridView.Add<RepositoryItem_Company>("FK_CompanyID");
            }
        }

        /// <summary>
        /// Load data (dùng cho cả form search)
        /// </summary>
        public void LoadData(int companyID = -1, string companyName = "", DateTime? fromDate = null, DateTime? toDate = null)
        {

        }
    }
}
