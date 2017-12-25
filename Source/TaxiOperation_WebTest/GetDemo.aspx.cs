using System;
using TaxiOperation_WebTest.Demo;

namespace TaxiOperation_WebTest
{
    public partial class GetDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = new TaxiOperation_ServicesSoapClient().GetDomain(new Authentication());
        }
    }
}