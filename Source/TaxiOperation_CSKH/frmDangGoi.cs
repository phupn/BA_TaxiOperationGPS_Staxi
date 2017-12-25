using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taxi.GUI
{
    public partial class frmDangGoi : Form
    {
        public string strMessage = "";
        private string g_PhoneNumber = "";

        public frmDangGoi()
        {
            InitializeComponent();
        }

        public frmDangGoi(string COMPort, string PhoneNumber , string Message)
        {
            InitializeComponent();
            this.strMessage = Message;
            this.g_PhoneNumber = PhoneNumber ;
        }

        private void frmDangGoi_Load(object sender, EventArgs e)
        {
          
            
        }

        public void Call(string COMPort, string PhoneNumber, string Message)
        {
            
           // this.lblSoGoi.Text += PhoneNumber + " -- " + strMessage;    
           
            // Mo COM          
            serialPort1.PortName = COMPort; // thu tu cua cong com
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Open();
            if (serialPort1.IsOpen)
            {
                QuaySoGoiDien(PhoneNumber);
            }
            System.Threading.Thread.Sleep(2000);
            serialPort1.Close();
            this.Hide();            
        }

        private void QuaySoGoiDien(string SoDienThoai)
        {
            string Call = String.Format("ATDT{0}{1}{2}", Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13), Convert.ToChar(11));
            serialPort1.Write(Call);                    
 
        }
    }
}