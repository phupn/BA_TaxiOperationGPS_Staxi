using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmDangGoi : Form
    {
        public string strMessage = "";
        private string g_PhoneNumber = "";
        private Timer G_Timer = new Timer();
        private int tick = 0;
        private ManagerConnection G_manager;

        public frmCallOut()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - this.Height - 30);
            G_Timer.Tick += G_Timer_Tick;
            G_Timer.Interval = 1000;
        }

        public frmCallOut(string COMPort, string PhoneNumber , string Message)
        {
            InitializeComponent();
            this.strMessage = Message;
            this.g_PhoneNumber = PhoneNumber ;
        }

        private void frmDangGoi_Load(object sender, EventArgs e)
        {
          
            
        }
        void G_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                tick++;
                if (tick >= 5)
                {
                    HideForm();
                }
            }
            catch (Exception ex)
            {
                HideForm();
                LogError.WriteLogError("TimerDangGoi:", ex);
            }
        }
        private void HideForm()
        {
            G_Timer.Stop();
            tick = 0;
            this.Hide();
        }
        public void Call(string COMPort, string PhoneNumber, string Message)
        {
            
           // this.lblSoGoi.Text += PhoneNumber + " -- " + strMessage;    
           
            // Mo COM          
            serialPort1.PortName = COMPort; // thu tu cua cong com
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Open();
            //new MessageBox.MessageBox().Show(serialPort1.PortName);
            if (serialPort1.IsOpen)
            {
                QuaySoGoiDien(PhoneNumber);
            }
            System.Threading.Thread.Sleep(2000);
            serialPort1.Close();
            this.Hide();            
        }


        public void Call(Asterisk.NET.Manager.ManagerConnection manager, string lineIPPBX, string phoneNumber)
        {
            G_Timer.Start();
            //System.Threading.Thread.Sleep(200);
            QuaySoGoiDien(manager, lineIPPBX, phoneNumber);
            //System.Threading.Thread.Sleep(2000);
            //this.Hide();
        }

        private void QuaySoGoiDien(string SoDienThoai)
        {
            string Call = String.Format("ATDT{0}{1}{2}", Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13), Convert.ToChar(11));
            //new MessageBox.MessageBox().Show(Call);
            serialPort1.Write(Call);                    
 
        }
        private bool QuaySoGoiDien(ManagerConnection manager, string line, string phoneNumber)
        {
            bool bRet = false;
            const string ORIGINATE_CONTEXT = "from-internal";
            if (manager == null) return false;
            try
            {
                G_manager = manager;
                string channel = string.Format("{0}/{1}", Config_Common.ChannelDial, line);
                if (!G_manager.IsConnected())
                {
                    G_manager = new ManagerConnection(AsteriskInfo.AST_HOSTNAME, AsteriskInfo.AST_PORT_NUMBER, AsteriskInfo.AST_USERNAME, AsteriskInfo.AST_PASSWORD);

                }
                G_manager.Login();
                if (G_manager.IsConnected())
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        Text = "Gọi đi : Kết nối tổng đài IP thành công - " + channel;
                    }));
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        Text = "Gọi đi : Kết nối tổng đài IP thất bại !!! - " + channel;
                    }));
                }
                OriginateAction oc = new OriginateAction() 
                { 
                    Context = ORIGINATE_CONTEXT, 
                    Priority = 1, 
                    Channel = channel, 
                    CallerId = line, 
                    Exten = phoneNumber, 
                    Timeout = 15000 
                };

                ManagerResponse originateResponse = G_manager.SendAction(oc, 30000);
                if (originateResponse.IsSuccess())
                    bRet = true;
                else
                    bRet = false;
                G_manager.Logoff();
            }
            catch (Exception ex)
            {
                bRet = false;
                G_manager.Logoff();
                LogError.WriteLogError("QuaySoGoiDien2", ex);
            }
            return bRet;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                HideForm();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}