using HiPathProCenterScreenPopAPILibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BA.CallCaptureOpenSpaceSiemens
{
    public delegate void NewCallEventHandler( NewCallEvent e);
    public class NewCallEvent : EventArgs
    {
        private string phoneNumber;
        /// <summary>
        /// Số điện thoại gọi đến
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private int line;

        /// <summary>
        /// gọi tới từ line
        /// </summary>
        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        private string nameCustomer;
        /// <summary>
        /// tên của KH với số điện thoại
        /// </summary>
        public string NameCustomer
        {
            get { return nameCustomer; }
            set { nameCustomer = value; }
        }

        private string addressOfCustomer;
        /// <summary>
        /// địa chỉ của số KH gọi đến
        /// </summary>
        public string AddressOfCustomer
        {
            get { return addressOfCustomer; }
            set { addressOfCustomer = value; }
        }
    }


    /// <summary>
    /// Lớp giao tiếp với tổng đài Siemens của Phương Trang.
    /// 
    /// - ĐTV đăng nhập pm Điện thoại
    /// - Tạo file profile cho Tổng đài với thông số user đăng nhập
    /// - Gọi chương trình OpenSpace Quản trị ( cho điện thoại viên đăng nhập tổng đài)
    /// - Thực hiện bắt số 
    /// </summary>
    ///  Congnt  - 29/10/2015
    public class CallCaptureOpenSpaceSiemens
    {
        #region Properties
        private string serverNameAddress;
        public string ServerNameAddress
        {
            get { return serverNameAddress; }
            set { serverNameAddress = value; }
        }
        /// <summary>
        /// username extension for login PBX
        /// </summary>
        private string userNameExt;
        public string UserNameExt
        {
            get { return userNameExt; }
            set { userNameExt = value; }
        }

        private bool isConnected;
        /// <summary>
        /// trả về trạng thái có đang connect với tổng đài hay không ?
        /// </summary>
        public bool IsConnected
        {
            get { return isConnected; }
        }
        public HiPathProCenterScreenPopAPILibrary.ScreenPopTelephoneListener pbxScreenPopup;

        #endregion Properties

        #region Events

       
        public event NewCallEventHandler NewCall;

        #endregion Events


        public CallCaptureOpenSpaceSiemens()
        { }

        /// <summary>
        /// Hàm khởi tạo lớp vơi
        /// </summary>
        /// <param name="usernameWindowsLogin"></param>
        /// <param name="usernamePBXPMĐH"></param>
        /// <param name="password"></param>
        public CallCaptureOpenSpaceSiemens(string serverName, string userNameExt )
        {
            this.ServerNameAddress = serverName;
            this.UserNameExt = userNameExt;
            pbxScreenPopup = new ScreenPopTelephoneListener();
           
        }

        public void Connect()
        {
            if (string.IsNullOrEmpty(this.ServerNameAddress))
            {
                this.isConnected = false;
                throw new Exception("Chưa có thông tin máy chủ tổng đài.");
            }
            // kết nối server 
            try
            {
                if (!this.isConnected)
                {
                    pbxScreenPopup.Initialize(this.ServerNameAddress);
                    this.isConnected = true;
                }
            }
            catch (Exception ex)
            {
                this.isConnected = false;
            }
        }

        public void StartListening()
        {
           

            if(this.IsConnected)
            {
                LogError_Siemens.WriteLogError("StartListening - IsConnectd : " + UserNameExt, new Exception(""));
                try
                {
                    this.pbxScreenPopup.StartListening(this.UserNameExt);
                    pbxScreenPopup.ScreenPop += new HiPathProCenterScreenPopAPILibrary._IScreenPopTelephoneListenerEvents_ScreenPopEventHandler(pbxScreenPopup_ScreenPop);
                    

                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi không popup với PBX - StartListening " + ex.Message); 
                }

               
            }
        }

        void pbxScreenPopup_ScreenPop(HiPathProCenterScreenPopAPILibrary.IScreenPopTelephoneEvent e)
        {
            LogError_Siemens.WriteLogError(" NewCall pbxScreenPopup_ScreenPop : " + e.Source, new Exception(""));            
            NewCallEvent newCallEvent = new NewCallEvent() { PhoneNumber = e.Source };                  
            OnNewCall(newCallEvent);                
           
        }

        protected virtual void OnNewCall(NewCallEvent newCallEvent )
        {
             NewCallEventHandler  handler = NewCall;
            if (handler != null)
            {
                handler(newCallEvent);
            }
        }
        /// <summary>
        /// hàm thực hiện đóng kết nối.
        /// </summary>
        public void Close()
        {
            if (this.isConnected)
            {
                try
                {
                    if (pbxScreenPopup != null)
                    {
                        pbxScreenPopup.ShutDown();
                        this.isConnected = false;
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        // Event NewCall - cuộc gọi mới tới sẽ có sự kiện
        
        // 
    }
    /// <summary>
    /// lớp thực hiện tạo file profile theo cách mà tổng đài IP Siemens tạo
    /// </summary>
    public class ProfileOpenSpaceSiemens
    {
        /// <summary>
        /// hàm thực hiện thay đổi thông tin tài khoản đăng nhập của file profile của chương trình OpenSpace
        ///   - Tìm đến file profile  xyz.XML
        ///   - Cập nhật lại với tên đăng nhập vào tổng đài usernamePBXPMĐH, thưởng Password là mặt định
        ///   - Lưu thành công thì trả về o   
        /// </summary>
        /// <param name="usernameWindowsLogin">Tài khoản windows </param>
        /// <param name="usernamePBXPMĐH"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int UpdateFileProfileOpenSpaceSiemens(string usernameWindowsLogin, string usernamePBXPMĐHExtensionID, string fullName, string password = ""  )
        {
            string path;
            string filename;// 

            if (usernameWindowsLogin.Length <= 0 || usernamePBXPMĐHExtensionID.Length <= 0) return -5;  // lỗi ko đủ thông tin để tạo tên file

            //
            // mặc định là thông tin theo ổ C: cài đặt windows vd : C:\Users\User\AppData\Roaming\Siemens\OpenScape
            path = string.Format(@"C:\Users\{0}\AppData\Roaming\Siemens\OpenScape", usernameWindowsLogin);
            //vd :  _.NGUYENTRONGCONG.CALLCENTER.xml
            filename = string.Format("_.{0}.CALLCENTER.xml", usernameWindowsLogin);

            path = Path.Combine(path, filename);
            //Message
            // kiểm tra file tồn tại 
            if (!File.Exists(path))
                return -2;
            // mở và ghi file
            XmlDocument docXML = new XmlDocument();
            docXML.Load(path);
            XmlNodeList listNode = docXML.SelectNodes("configuration/siemens.opticlient.sipfunctional.sipfunctionalprovider/primaryline");
            if (listNode != null && listNode.Count > 0)
            {
                try
                {
                    ((XmlElement)listNode[0]).SelectNodes("id")[0].InnerText = usernamePBXPMĐHExtensionID;
                    ((XmlElement)listNode[0]).SelectNodes("userid")[0].InnerText = usernamePBXPMĐHExtensionID;
                    if (((XmlElement)listNode[0]).SelectNodes("text") == null)
                    {
                        //Create a new node.
                        XmlElement elem = docXML.CreateElement("text");
                    }
                    ((XmlElement)listNode[0]).SelectNodes("text")[0].InnerText = fullName;
                    docXML.Save(path);
                    LogError_Siemens.WriteLogErrorForDebug("UpdateFileProfileOpenSpaceSiemens OK");

                    return 1;  // lưu thông tin thành công
                }
                catch (Exception ex)
                {
                    LogError_Siemens.WriteLogError("UpdateFileProfileOpenSpaceSiemens", ex);
                    return 0;
                }
            } 
            return 0; // không cập nhật được           
        }
    }

}
