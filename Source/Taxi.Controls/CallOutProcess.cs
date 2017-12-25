using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.Controls
{
    public class CallOutProcess
    {
        public static frmCallOut frmCalling;
        public static bool IsAvailable;
        public static void Call(string PhoneNumber, string Address, string extension)
        {
            try
            {
                IsAvailable = false;
                if (frmCalling == null)
                    frmCalling = new frmCallOut();

                frmCalling.Show();
                frmCalling.Invoke((MethodInvoker)delegate
                {
                    frmCalling.lblSoGoi.Text = String.Format("Đang gọi : {0} - {1}", PhoneNumber, Address);
                });
                frmCalling.Refresh();

                IsAvailable = frmCalling.Call(extension, PhoneNumber);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CallOutProcess Call", ex);
            }
        }
    }
}
