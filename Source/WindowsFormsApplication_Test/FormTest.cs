using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_Test
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }
        private bool IsShow = false;

        int PORT_NUMBER = 2500;
        private UdpClient udp;
        Thread t = null;
        IAsyncResult ar_ = null;

        private void FormTest_Load(object sender, EventArgs e)
        {

        }
        public void LoadCuoc()
        {
            //lock (this)
            {
                if (!Visible)
                {
                    //IsShow = true;
                    //Visible = true;
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => ShowDialog()));
                        return;
                    }
                    else
                    {
                        ShowDialog();
                    }
                    //Visible = true;
                }
            }          
        }
        
        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            IsShow = false;
            Stop();
            Application.Exit();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            ProcessGoiDi(txtLinkCall.Text.Trim());
        }
        string ProcessGoiDi(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Credentials = CredentialCache.DefaultCredentials;
                var response = Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);
                response.Wait();
                response.Result.Close();
                request.Abort();
                lblResult.Text = "SUCCESS";
                return "SUCCESS";
            }
            catch (WebException ex)
            {
                lblResult.Text = "";
                return "";
            }
        }
        public void Start()
        {
            if (t != null)
            {
                throw new Exception("Already started, stop first");
            }
            Console.WriteLine("Started listening");
            StartListening();
        }
        public void Stop()
        {
            try
            {
                udp.Close();
                Console.WriteLine("Stopped listening");
            }
            catch { /* don't care */ }
        }
        private void StartListening()
        {
            ar_ = udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, PORT_NUMBER);
            if (udp.Client != null)
            {
                byte[] bytes = udp.EndReceive(ar, ref ip);
                string message = Encoding.UTF8.GetString(bytes);
                //Console.WriteLine("From {0} received: {1} ", ip.Address.ToString(), message);
                txtUDPData.Invoke((MethodInvoker)delegate()
                {
                    txtUDPData.AppendText(message);
                    txtUDPData.AppendText(Environment.NewLine);
                });
                StartListening();
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            int.TryParse(txtLinkUDP.Text.Trim(), out PORT_NUMBER);
            udp = new UdpClient(PORT_NUMBER);
            
            Start();
            MessageBox.Show("Connect Thành Công");
        }

        private void btnSendUDP_Click(object sender, EventArgs e)
        {
            Send(txtUDPRawData.Text.Trim());
        }
        public void Send(string message)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, PORT_NUMBER);
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
            //Console.WriteLine("Sent: {0} ", message);
        }
    }
}
