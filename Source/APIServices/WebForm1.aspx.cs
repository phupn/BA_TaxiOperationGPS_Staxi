using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APIServices.BL;
using APIServices.DAL;

namespace APIServices
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string cuocCanKiemTraXeToiDiems = "1;105.825348;21.0169373;1210.2739#2;105.867432;20.998045;2054";
            //string ret = new APIServicesBL().GetDSToiDiemDaDonKhach(cuocCanKiemTraXeToiDiems, 120, "329,6025,787");

            System.Data.DataTable dt = new APIServicesDAL().GetViTriOnline_TGCapNhat(DateTime.Now);
        }
    }
}
