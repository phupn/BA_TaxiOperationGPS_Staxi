using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business;

namespace TaxiOperation_CallCapture2
{
    public partial class frmTestMain : Form
    {
        public frmTestMain()
        {
            InitializeComponent();
        }

        private void frmTestMain_Load(object sender, EventArgs e)
        {
            // Lay thong tin he thong
            ThongTinCauHinh.LayThongTinCauHinh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //textBox2.Text = StringTools.GetSoDienThoaiChuan(textBox1.Text,"011111111");
        }

       
    }
}
