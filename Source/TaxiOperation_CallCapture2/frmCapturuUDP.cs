using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace TaxiOperation_CallCapture2
{
    public partial class frmCapturuUDP : Form
    {
        public frmCapturuUDP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
                bool done = false;
                int listenPort =  1792;
                UdpClient listener = new UdpClient(listenPort);
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse("192.168.1.102"), listenPort);
                string received_data;
                byte[] receive_byte_array;
                try
                {
                    while (!done)
                    {
                     
                        receive_byte_array = listener.Receive(ref groupEP);
                        Console.WriteLine("Received a broadcast from {0}", groupEP.ToString() );
                        received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                        lblTest.Text = received_data;
                    }
                }
                catch (Exception ex)
                {
                  lblTest.Text = ex.Message.ToString ();
                }
                listener.Close();
                
         
      }
       
    }
}