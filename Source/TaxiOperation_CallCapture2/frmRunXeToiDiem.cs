using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace TaxiOperation_CallCapture2
{
    public partial class frmRunXeToiDiem : Form
    {
        //const
        private const int   SO_GIAY_TOI_HAN_CO_TIN_HIEU = 120;    // 120 giay gan day xe van co tin hieu
        private const string DS_MA_CUNG_XN = "329,787,6025,752,760"; // cac cong ty can kiem tra
        private const int BAN_KINH_GIOI_HAN = 300;                  // 100 met gan diem cua khach

        private bool g_Thoat = false;
        private System.Timers.Timer timerCapture = null;
        private string g_ConnecString = "";
        private bool g_KetThucTimer = true;
        private int iSoLan = 0;

        private int g_SoCuocGoiKiemTraToiDiemGuiService = 50;

        public frmRunXeToiDiem()
        {
            InitializeComponent();
        }

        private void frmRunXeToiDiem_Load(object sender, EventArgs e)
        {
            Init();
        }
        /// <summary>
        /// Khoi tao du lieu luc dau
        /// </summary>
        private void Init()
        {
            // Lay thong tin he thong
            ThongTinCauHinh.LayThongTinCauHinh(); 
            g_ConnecString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            

            // check connection 
            if (!DieuHanhTaxi.CheckConnection())
            {
                MessageBox.Show("Không kết nối được với cơ sở dữ liệu.Cần liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }
            /// end check connection
            timerCapture = new System.Timers.Timer(5000); // nửa giây quét một lần. 15 giay
            timerCapture.Elapsed += new System.Timers.ElapsedEventHandler(timerCapture_Elapsed);
            timerCapture.Enabled = true;

            // Thong tin status bar
            statusLblKhoiDongLuc.Text = " Khởi động : " + string.Format("{0:HH:mm dd/MM}", DateTime.Now);
            statusLblSoCuocChoXuLy.Text = " Cuộc chờ xử lý : 0";
            statusLblServer.Text = " Server: " + GetServerName(g_ConnecString);
            statusLblDatabase.Text = " DB: " + GetDatabaseName(g_ConnecString);

            this.Text = Configuration.GetCompanyName() + " - " + this.Text;
        }

        /// <summary>
        /// ham lay thong tin db tu connectionstring
        /// Data Source=pccongnt\SQLEXPRESS;Initial Catalog=DBName;User ID=sa ;Password=scongnt
        /// 
        /// </summary>
        /// <param name="ConnecString"></param>
        /// <returns>DBName</returns>
        private string GetDatabaseName(string ConnectString)
        {
            string[] arrString = ConnectString.Split(";".ToCharArray());
            if (arrString != null && arrString.Length > 2)
            {
                return arrString[1].Replace("Initial Catalog=","");
            }
            return "";
        }

        private string GetServerName(string ConnectString)
        {
            string[] arrString = ConnectString.Split(";".ToCharArray());
            if (arrString != null && arrString.Length > 2)
            {
                return arrString[0].Replace("Data Source=", "");
            }
            return "";
        }
        
        /// <summary>
        /// hàm xử lý trong timer
        /// 
        /// Tổ chức.
        ///    - Yêu tiên bắt số 1/2 giấy bắt số gọi đến một lần
        ///    - Số bắt được lưu vào ds cuộc gọi đến
        ///    - Dùng backgroudworker để xác định các cuộc gọi
        ///         - Phân chuông của cuộc gọiđã nghe máy, tính vào lúc đã có được ghi âm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timerCapture_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        { 
            if (g_KetThucTimer)
            {
                g_KetThucTimer = false;

                // string dsCuocGoiCanKiemTraXeToiDiem = TaxiCapture.TaxiCapture.GetDSCuocGoiCanKiemTraXeToiDiem(0, 30, g_ConnecString);


                lblThoiDiemQuet.Invoke(
                                           (MethodInvoker)delegate()
                                           {
                                               lblThoiDiemQuet.Text = string.Format("{0:HH:mm:ss dd/MM}", DateTime.Now);
                                           }
                                       );

                List<TaxiCapture.TaxiCapture.KieuXeToiDiem> listXeToiDiem = new List<TaxiCapture.TaxiCapture.KieuXeToiDiem>();
                listXeToiDiem = TaxiCapture.TaxiCapture.GetDSCuocGoiCanKiemTraXeToiDiemReturnList(0, 30, g_ConnecString);
                if(listXeToiDiem!= null && listXeToiDiem.Count >0)
                {
                    string KetQuaXeToiDiem = string.Empty;
                    CapNhatXeToiDiem(listXeToiDiem, out KetQuaXeToiDiem);
                    if (KetQuaXeToiDiem.Length > 0)
                    {
                        lblThoiDiemXeToiDiem.Invoke(
                                               (MethodInvoker)delegate()
                                               {
                                                   lblThoiDiemXeToiDiem.Text = KetQuaXeToiDiem;
                                               }
                                        );
                    }

                    string KetQuaXeDonKhach = string.Empty;

                    CapNhatXeToiDiemDonKhach(listXeToiDiem, out KetQuaXeDonKhach);
                    if (KetQuaXeDonKhach != null && KetQuaXeDonKhach.Length > 0)
                    {
                        lblThoiDiemXeDon.Invoke(
                                              (MethodInvoker)delegate()
                                              {
                                                  lblThoiDiemXeDon.Text = KetQuaXeDonKhach;
                                              }
                                       );
                    }                   
                }
                g_KetThucTimer = true;
            }
        }


        private void CapNhatXeToiDiem(List<TaxiCapture.TaxiCapture.KieuXeToiDiem> listXeToiDiem,out string ketQuaXeToiDiem)
        {
            ketQuaXeToiDiem = string.Empty;

            BAGPS.Service service = new TaxiOperation_CallCapture2.BAGPS.Service();
            int iPos = 0;       // Vi tri con tro tren danh sach
            int startIndex = 0; // vị trí bắt đầu lấy dữ liệu
            int len = 0;        // độ dài của khoảng lấy
            while (iPos < listXeToiDiem.Count)
            {
                startIndex = iPos;
                if (listXeToiDiem.Count - iPos - g_SoCuocGoiKiemTraToiDiemGuiService > 0) // số cuốc lớn hơn số dòng quy định
                {
                    len = g_SoCuocGoiKiemTraToiDiemGuiService;
                }
                else
                {
                    len = listXeToiDiem.Count - iPos;
                }
                iPos += len;
                string dsCuocGoiCanKiemTraXeToiDiem = string.Empty;
                for (int i = startIndex; i < len; i++)
                {
                    dsCuocGoiCanKiemTraXeToiDiem += listXeToiDiem[i].ToString() + "#";
                }
                if (dsCuocGoiCanKiemTraXeToiDiem != null & dsCuocGoiCanKiemTraXeToiDiem.Length > 0)
                {
                    dsCuocGoiCanKiemTraXeToiDiem = dsCuocGoiCanKiemTraXeToiDiem.Substring(0, dsCuocGoiCanKiemTraXeToiDiem.Length - 1);
                }
                // Gui service
                string xeToiDiems = service.LayDanhSachXeToiDiem(dsCuocGoiCanKiemTraXeToiDiem, SO_GIAY_TOI_HAN_CO_TIN_HIEU, DS_MA_CUNG_XN, BAN_KINH_GIOI_HAN);
                if (xeToiDiems != null && xeToiDiems.Length > 0)
                {
                    TaxiCapture.TaxiCapture.UpdateThongTinXeToiDiem(xeToiDiems, this.g_ConnecString);
                    ketQuaXeToiDiem = string.Format("{0:HH:mm:ss dd/MM},{1}", DateTime.Now, xeToiDiems);
                }
            }
        } 


        private void   CapNhatXeToiDiemDonKhach(List < TaxiCapture.TaxiCapture.KieuXeToiDiem >  listXeToiDiem,out string ketQuaXeDonKhach) 
        {
            ketQuaXeDonKhach = string.Empty;

            BAGPS.Service service = new TaxiOperation_CallCapture2.BAGPS.Service();
            int iPos = 0;       // Vi tri con tro tren danh sach
            int startIndex = 0; // vị trí bắt đầu lấy dữ liệu
            int len = 0;        // độ dài của khoảng lấy
            while (iPos < listXeToiDiem.Count)
            {
                startIndex = iPos;
                if (listXeToiDiem.Count - iPos - g_SoCuocGoiKiemTraToiDiemGuiService > 0) // số cuốc lớn hơn số dòng quy định
                { 
                    len = g_SoCuocGoiKiemTraToiDiemGuiService; 
                }
                else
                { 
                    len = listXeToiDiem.Count - iPos ; 
                }
                iPos += len;
                string dsCuocGoiCanKiemTraXeToiDiem = string.Empty;
                for (int i = startIndex; i < len; i++)
                {
                    dsCuocGoiCanKiemTraXeToiDiem += listXeToiDiem[i].ToString() + "#";
                }
                if (dsCuocGoiCanKiemTraXeToiDiem != null & dsCuocGoiCanKiemTraXeToiDiem.Length > 0)
                {
                    dsCuocGoiCanKiemTraXeToiDiem = dsCuocGoiCanKiemTraXeToiDiem.Substring(0, dsCuocGoiCanKiemTraXeToiDiem.Length - 1);
                }
                // Gui service
                string xeToiDiems = service.LayDanhSachXeToiDiemDonDuocKhach(dsCuocGoiCanKiemTraXeToiDiem, SO_GIAY_TOI_HAN_CO_TIN_HIEU, DS_MA_CUNG_XN);
                if (xeToiDiems != null && xeToiDiems.Length > 0)
                {

                    TaxiCapture.TaxiCapture.UpdateThongTinXeToiDiemDonKhach (xeToiDiems, this.g_ConnecString);
                    ketQuaXeDonKhach = string.Format("{0:HH:mm:ss dd/MM},{1}", DateTime.Now, xeToiDiems);
                }
            } 
        }



        private void btnLayXeToiDiem_Click(object sender, EventArgs e)
        {
            // lấy ds các cuốc gọi có xe nhận.
            // ID,KinhDo,ViDo,XeNhan
            //string dsCuocGoiCanKiemTraXeToiDiem = TaxiCapture.TaxiCapture.GetDSCuocGoiCanKiemTraXeToiDiem(0, 10000, g_ConnecString);

            // string dsCuocGoiCanKiemTraXeToiDiem = TaxiCapture.TaxiCapture.GetDSCuocGoiCanKiemTraXeToiDiem(0, 30, g_ConnecString);

            List<TaxiCapture.TaxiCapture.KieuXeToiDiem> listXeToiDiem = new List<TaxiCapture.TaxiCapture.KieuXeToiDiem>();
            listXeToiDiem = TaxiCapture.TaxiCapture.GetDSCuocGoiCanKiemTraXeToiDiemReturnList(0, 30, g_ConnecString);
            if (listXeToiDiem != null && listXeToiDiem.Count > 0)
            {

                BAGPS.Service service = new TaxiOperation_CallCapture2.BAGPS.Service();
                int iPos = 0;       // Vi tri con tro tren danh sach
                int startIndex = 0; // vị trí bắt đầu lấy dữ liệu
                int len = 0;        // độ dài của khoảng lấy
                while (iPos < listXeToiDiem.Count)
                {
                    startIndex = iPos;
                    if (listXeToiDiem.Count - iPos - g_SoCuocGoiKiemTraToiDiemGuiService > 0) // số cuốc lớn hơn số dòng quy định
                    {
                        len = g_SoCuocGoiKiemTraToiDiemGuiService;
                    }
                    else
                    {
                        len = listXeToiDiem.Count - iPos;
                    }
                    iPos += len;
                    string dsCuocGoiCanKiemTraXeToiDiem = string.Empty;
                    for (int i = startIndex; i < len; i++)
                    {
                        dsCuocGoiCanKiemTraXeToiDiem += listXeToiDiem[i].ToString() + "#";
                    }
                    if (dsCuocGoiCanKiemTraXeToiDiem != null & dsCuocGoiCanKiemTraXeToiDiem.Length > 0)
                    {
                        // bỏ dấu # ở cuối
                        dsCuocGoiCanKiemTraXeToiDiem = dsCuocGoiCanKiemTraXeToiDiem.Substring(0, dsCuocGoiCanKiemTraXeToiDiem.Length - 1);
                    }
                    // Gui service
                    string xeToiDiems = service.LayDanhSachXeToiDiem(dsCuocGoiCanKiemTraXeToiDiem, SO_GIAY_TOI_HAN_CO_TIN_HIEU, DS_MA_CUNG_XN, BAN_KINH_GIOI_HAN);
                    if (xeToiDiems != null && xeToiDiems.Length > 0)
                        TaxiCapture.TaxiCapture.UpdateThongTinXeToiDiem(xeToiDiems, this.g_ConnecString);
                }
              }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string soDienThoai = StringTools.TrimSpace(txtSoDienThoai.Text);
            if (soDienThoai != null && soDienThoai.Length >= 10)
            { 
               long ID =  TaxiCapture.TaxiCapture.InsertCuocGoiLanDau(this.g_ConnecString, "1", soDienThoai, DateTime.Now);
               if (ID > 0)
               {
                   MessageBox.Show("Chèn thành công");
               }
               else
               {
                   MessageBox.Show("Lỗi chèn cuốc");
               }

            }
            else
                MessageBox.Show("Bạn phải chèn đúng số điện thoại");
        }

        private void btnXeToiDiemDonKhach_Click(object sender, EventArgs e)
        {
            // lấy những cuộc gọi có xe nhận
            // kiểm tra những xe nhận này có đón được khách không.
            List<TaxiCapture.TaxiCapture.KieuXeToiDiem> listXeToiDiem = new List<TaxiCapture.TaxiCapture.KieuXeToiDiem>();
            listXeToiDiem = TaxiCapture.TaxiCapture.GetDSCuocGoiCanKiemTraXeToiDiemReturnList(0, 30, g_ConnecString);
            if (listXeToiDiem != null && listXeToiDiem.Count > 0)
            {

                BAGPS.Service service = new TaxiOperation_CallCapture2.BAGPS.Service();
                int iPos = 0;       // Vi tri con tro tren danh sach
                int startIndex = 0; // vị trí bắt đầu lấy dữ liệu
                int len = 0;        // độ dài của khoảng lấy
                while (iPos < listXeToiDiem.Count)
                {
                    startIndex = iPos;
                    if (listXeToiDiem.Count - iPos - g_SoCuocGoiKiemTraToiDiemGuiService > 0) // số cuốc lớn hơn số dòng quy định
                    {
                        len = g_SoCuocGoiKiemTraToiDiemGuiService;
                    }
                    else
                    {
                        len = listXeToiDiem.Count - iPos;
                    }
                    iPos += len;
                    string dsCuocGoiCanKiemTraXeToiDiemDonKhach = string.Empty;
                    for (int i = startIndex; i < len; i++)
                    {
                        dsCuocGoiCanKiemTraXeToiDiemDonKhach += listXeToiDiem[i].ToString() + "#";
                    }
                    if (dsCuocGoiCanKiemTraXeToiDiemDonKhach != null & dsCuocGoiCanKiemTraXeToiDiemDonKhach.Length > 0)
                    {
                        // bỏ dấu # ở cuối
                        dsCuocGoiCanKiemTraXeToiDiemDonKhach = dsCuocGoiCanKiemTraXeToiDiemDonKhach.Substring(0, dsCuocGoiCanKiemTraXeToiDiemDonKhach.Length - 1);
                    }
                    // Gui service
                    string xeToiDiems = service.LayDanhSachXeToiDiemDonDuocKhach (dsCuocGoiCanKiemTraXeToiDiemDonKhach, SO_GIAY_TOI_HAN_CO_TIN_HIEU, DS_MA_CUNG_XN );
                  
                    if (xeToiDiems != null && xeToiDiems.Length > 0)
                        TaxiCapture.TaxiCapture.UpdateThongTinXeToiDiemDonKhach(xeToiDiems, this.g_ConnecString);
                }
            }
        }

         
    }
}
