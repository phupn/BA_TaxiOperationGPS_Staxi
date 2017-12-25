using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.Controls
{
    public partial class frmCallOut : Form
    {
        private string G_PhoneNumber = "";
        /// <summary>
        /// Line Tổng đài IP
        /// </summary>
        private string G_lineIPPBX;
        private Timer G_Timer = new Timer();    // Timer hide dialog dialout
        private int tick = 0;

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
            this.G_PhoneNumber = PhoneNumber ;
        }

        private void frmDangGoi_Load(object sender, EventArgs e)
        {
            //bw_Call = new BackgroundWorker();
            //bw_Call.DoWork += new DoWorkEventHandler(bw_Call_DoWork);
            //bw_Call.WorkerSupportsCancellation = true;
        }

        void bw_Call_DoWork(object sender, DoWorkEventArgs e)
        {
            QuaySoGoiDien();
        }

        void G_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                tick++;
                if (tick >= 5)
                {
                    //tick = 0;
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
        /// <summary>
        /// Gọi ra bằng hộp số tự động
        /// </summary>
        /// <param name="COMPort"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Message"></param>
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

        /// <summary>
        /// Gọi ra bằng tổng đài IP
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="lineIPPBX"></param>
        /// <param name="phoneNumber"></param>
        public bool Call(string lineIPPBX, string phoneNumber)
        {
            if (Config_Common.Asterisk_QuickCall)
            {
                G_lineIPPBX = lineIPPBX;
                G_PhoneNumber = phoneNumber;
                if (Config_Common.MPCC_LinkDial != "")
                {
                    QuaySoGoiDen_MPCC(lineIPPBX, phoneNumber);
                }
                else if (Config_Common.Asterisk_LinkDial != "")
                {
                    CallOut_AsteriskCloud(lineIPPBX, phoneNumber);
                }
                else
                {
                    QuaySoGoiDien();
                }
                System.Threading.Thread.Sleep(1000);
                this.Hide();
            }
            return true;
        }

        /// <summary>
        /// Quay số gọi ra  - hộp gọi tự động
        /// </summary>
        /// <param name="SoDienThoai"></param>
        private void QuaySoGoiDien(string SoDienThoai)
        {
            string Call = String.Format("ATDT{0}{1}{2}", Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13), Convert.ToChar(11));
            serialPort1.Write(Call);
        }

        #region CallOut with MPCC

        /// <summary>
        /// Quay số gọi đến của MPCC
        /// </summary>
        /// <param name="line"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private bool QuaySoGoiDen_MPCC(string line, string phoneNumber)
        {
            try
            {
                //http://192.168.100.188:8080/MPCCNotifier/mptelecom/DoAction.jsp?event=GetRealTimeList

                //http://192.168.254.10:8080/MPCCNotifier/mptelecom/DoAction.jsp?event=DialByTrunk&trunk=trFXO&queue=Goira&agentCode=linhtn&phoneNum=0973428169&extension=1990

                string url = string.Format("{0}&trunk={1}&queue={2}&agentCode={3}&phoneNum={4}&extension={5}",
                        Config_Common.MPCC_LinkDial,
                        Config_Common.MPCC_TrunkDial,
                        Config_Common.MPCC_Queue,
                        ThongTinDangNhap.USER_ID,
                        phoneNumber,
                        line
                        );
                if (Global.IsDebug)
                    new MessageBox.MessageBoxBA().Show(url);
                string result = Global.ExecuteURL(url);
                this.Invoke(new MethodInvoker(delegate
                {
                    Text = string.Format("Đang gọi đi MP: {0}", result);
                }));

                if (Global.IsDebug)
                    new MessageBox.MessageBoxBA().Show(result);
                return result.Contains("SUCCESS");

            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    Text = "Gọi đi thất bại rồi Tâm à !!!";
                }));
                LogError.WriteLogError("QuaySoGoiDen_MPCC", ex);
                return false;
            }
        }       
        
        #endregion

        /// <summary>
        /// Gọi đi với hệ thống asterisk Cloud
        /// </summary>
        /// <param name="line"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private bool CallOut_AsteriskCloud(string line, string phoneNumber)
        {
            try
            {
                //http://connect.cloudpbx.zlink.vn/taxihonghai/dial.php?customernumber=0904706808&agentnumber=1163&crmid=103248912

                string url = string.Format("{0}{1}&agentnumber={2}&crmid={3}",
                        Config_Common.Asterisk_LinkDial,
                        phoneNumber,
                        line,
                        Config_Common.Asterisk_LinkDial_CRMID
                        );
                if (Global.IsDebug)
                    new MessageBox.MessageBoxBA().Show(url);
                string result = Global.ExecuteURL(url);
                this.Invoke(new MethodInvoker(delegate
                {
                    Text = string.Format("Đang gọi đi Tổng đài IP: {0}", result);
                }));

                if (Global.IsDebug)
                    new MessageBox.MessageBoxBA().Show(result);
                return result.Contains("SUCCESS");

            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    Text = "Gọi đi thất bại rồi Tâm à !!!";
                }));
                LogError.WriteLogError("QuaySoGoiDen_MPCC", ex);
                return false;
            }
        }       

        /// <summary>
        /// Quay số gọi ra  - tổng đài ip
        /// </summary>
        private bool QuaySoGoiDien()
        {
            bool bRet = false;
            const string ORIGINATE_CONTEXT = "from-internal";
            try
            {
                string channel = string.Format("{0}/{1}", Config_Common.ChannelDial, G_lineIPPBX);
                
                AsteriskInfo.Manager.Login();
                if (AsteriskInfo.Manager.IsConnected())
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
                var oc = new OriginateAction() { 
                    Context = ORIGINATE_CONTEXT,
                    Priority = 1,
                    Channel = channel,//"SIP/" + G_lineIPPBX,
                    CallerId = G_lineIPPBX,
                    Exten = G_PhoneNumber + Config_Common.Asterisk_SetNumberSign,
                    Timeout = Config_Common.Asterisk_CallOut_TimeOut,
                    //Async = true
                };
                //oc.SetVariable("exten", G_PhoneNumber);
                if (AsteriskInfo.Manager.SendAction(oc, oc.Timeout).IsSuccess())
                    bRet = true;
                else
                    bRet = false; 

                AsteriskInfo.Manager.Logoff();
            }
            catch (Exception ex)
            {
                bRet = false;
                AsteriskInfo.Manager.Logoff();
                LogError.WriteLogError("QuaySoGoiDien2", ex);
            }
            return bRet;
        }
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {
        //        HideForm();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
    }
}