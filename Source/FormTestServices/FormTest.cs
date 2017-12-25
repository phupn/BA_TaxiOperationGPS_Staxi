using FormTestServices.ServerSMS_Viettel;
using FormTestServices.ServicesGEO;
using System;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace FormTestServices
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            //ServiceReference.ServiceClient serviceClient = new ServiceReference.ServiceClient();
            //serviceClient.ClientCredentials.UserName.UserName = "admina";//admina
            //serviceClient.ClientCredentials.UserName.Password = "staximanadmina";//staximanadmina
            //MessageBox.Show(serviceClient.GetData("phupn","123456",12));
            //bookingTaxiThanhCong();
            //bookingTaxiThanhCong_V2();


            result res;
            ServerSMS_Viettel.CcApiClient client = new ServerSMS_Viettel.CcApiClient();
            res = client.wsCpMt("thvn", "123456a@A", "THVN", "5", "‎‎‎84972284850", "‎‎84972284850", "VINATAXI", "bulksms", "noi dung sms 2", "0)");
        }

        private void bookingTaxiThanhCong()
        {
            Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoapClient service = new Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoapClient();
            service.ClientCredentials.UserName.UserName = "thanhcongtaxi";
            service.ClientCredentials.UserName.Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96";
            FormTestServices.Server_BookingTaxi_ThanhCong.Authentication authen = new Server_BookingTaxi_ThanhCong.Authentication();
            authen.UserName = "thanhcongtaxi";
            authen.Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96";

            string returnvalue = service.BookingTaxi(
                new Server_BookingTaxi_ThanhCong.Authentication() { UserName = "thanhcongtaxi", Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96" }, 
                "phupn test chatbot", 
                "0999000999", 
                "Phú Bình Anh", 
                "4", 
                1, 
                DateTime.Now, 
                "ghi chú", 
                4, 
                1, 
                "thanhcongtaxi.vn"
                );

        }

        private void bookingTaxiThanhCong_V2()
        {
            //using (ServicesOnlineClient geo = new ServicesOnlineClient())
            //{
            //    var auth = new AuthenticationHeader();
            //    auth.UserName = "BAGIS_BinhAnh";
            //    auth.PassWord = "BAGIS_BinhAnh_BAGIS_20160126";
            //    auth.Key = "BAGIS_20160126";
            //    string addressLocation = geo.GetAddressByGeo(auth, 105.86897277832F, 21.0328483581543F);

            //}

            Services_DatXe_ThanhCong_V2.TaxiOperation_ServicesSoapClient service = new Services_DatXe_ThanhCong_V2.TaxiOperation_ServicesSoapClient();
            service.ClientCredentials.UserName.UserName = "thanhcongtaxi";
            service.ClientCredentials.UserName.Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96";
            FormTestServices.Server_BookingTaxi_ThanhCong.Authentication authen = new Server_BookingTaxi_ThanhCong.Authentication();
            authen.UserName = "thanhcongtaxi";
            authen.Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96";

            string returnvalue = service.BookingTaxi_V2(
                new Services_DatXe_ThanhCong_V2.Authentication() { UserName = "thanhcongtaxi", Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96" },
                "[Tue Phan]",
                "0972284850",
                "Phú Bình Anh 21.0328483581543, 105.86897277832",
                "3",
                1,
                DateTime.Now,
                "ghi chú",
                5,
                1,
                "thanhcongtaxi.vn", "21.0328483581543", "105.86897277832", "1234", "", ""
                );
            long id = 0;
            if (long.TryParse(returnvalue, out id))
            {
                string cancelvalule = service.CancelBooking_V2(
                    new Services_DatXe_ThanhCong_V2.Authentication() { UserName = "thanhcongtaxi", Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96" },
                    "thanhcongtaxi.vn",
                    1,
                    returnvalue);
            }
            string a;
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            //ServiceReference.ServiceClient serviceClient = new ServiceReference.ServiceClient();
            //serviceClient.ClientCredentials.UserName.UserName = "admina";//admina
            //serviceClient.ClientCredentials.UserName.Password = "staximanadmina";//staximanadmina
            //MessageBox.Show(serviceClient.GetData("phupn", "123456", 123456789));

        }
    }
}
