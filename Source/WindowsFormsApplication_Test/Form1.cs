using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string _domain = "Futabus";
        private const string _userName = "BookTaxi_Futa";
        private const string _password = "Q954KDmoHHBvg6NwKjj5CQ==";
        private void Form1_Load(object sender, EventArgs e)
        {
            //TaxiOperation_ServicesSoapClient APIService = new TaxiOperation_ServicesSoapClient();
            //if(APIService.AuthenticationServices(_domain, _userName,_password))
            //{
            //    string tenKhachHang="Phú BA";
            //    string soDienThoai="0972284850";
            //    string diaChiDon = "test diaChiDon";
            //    string diaChiTra = "test diaChiTra"; 
            //    float soKm= 10; 
            //    int soTien=100000;
            //    string loaiXe = "4c"; 
            //    int soLuongXe = 1; 
            //    DateTime gioDon = DateTime.Now; 
            //    int soPhutBaoTruoc = 10;
            //    string ghiChu = "test ghiChu"; 
            //    int systemBookID = 1;
            //    string a = APIService.BookingTaxi(tenKhachHang, soDienThoai, diaChiDon, diaChiTra, soKm, soTien, loaiXe, soLuongXe, gioDon, soPhutBaoTruoc, ghiChu, systemBookID);
            //}
            frm.LoadCuoc();
        }
        
        private FormTest frm = new FormTest();

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    frm.LoadCuoc();
                }catch(Exception ex)
                {
                    textBox1.Text = string.Format("{0}{1}{2}", textBox1.Text, Environment.NewLine, ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100000; i++)
            {
                var bck =new BackgroundWorker();
                bck.DoWork += bck_DoWork;
                
                bck.RunWorkerCompleted += bck_RunWorkerCompleted;
                bck.RunWorkerAsync();
            }
            for (int i = 0; i < 100000; i++)
            {
                var bck = new BackgroundWorker();
                bck.DoWork += bck_DoWork;

                bck.RunWorkerCompleted += bck_RunWorkerCompleted;
                bck.RunWorkerAsync();
            }
        }

        void bck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            try
            {
                frm.LoadCuoc();
            }
            catch (Exception ex)
            {
                textBox1.Text = string.Format("{0}{1}{2}", textBox1.Text, Environment.NewLine, ex.Message);
            }
        }

        void bck_DoWork(object sender, DoWorkEventArgs e)
        {
        }
    }
}
