using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxiOperation_WebTest.ServiceTest;

namespace TaxiOperation_WebTest
{
    public partial class GetDomain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = ":" + new TaxiOperationClient().GetDomain();
        }
    }
}