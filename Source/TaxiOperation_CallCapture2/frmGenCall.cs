using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaxiCapture
{
    public partial class frmGenCall : Form
    {

        private string g_ConnecString = "";
        private List<int> lstLine = new List<int>();
        private List<string> lstPhone = new List<string>();
        private System.Timers.Timer timerCapture = null;

        int g_Count = 0;
        int g_SoGiay = 0;
        bool g_bRun = false;

        int g_Len = 0;
        public frmGenCall()
        {
            InitializeComponent();
        }
      
        private void frmGenCall_Load(object sender, EventArgs e)
        {
            g_ConnecString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            lstLine.Add(1);
            lstLine.Add(2);
            lstLine.Add(3);
            lstLine.Add(4);
            lstLine.Add(5);
            lstLine.Add(6);

            if(richPhone.Lines != null)
            {
                for (int i =0;i<richPhone.Lines.Length ;i++)
                {
                    lstPhone.Add(richPhone.Lines[i]);
                }
                g_Len = richPhone.Lines.Length;
            }
            
            /// end check connection
            timerCapture = new System.Timers.Timer(1000); // nửa giây quét một lần.
            timerCapture.Elapsed += new System.Timers.ElapsedEventHandler(timerCapture_Elapsed);
            timerCapture.Enabled = true;

            try
            {
                g_SoGiay = int.Parse(txtSoGiay.Text);
            }
            catch (Exception ex)
            {
                g_SoGiay = 30;
                txtSoGiay.Text = g_SoGiay.ToString();
            }
        }

        void timerCapture_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            g_Count++;

            if(g_Count >= g_SoGiay && g_bRun)
            {
                Random ran = new Random();
                int iLine = ran.Next(0, 5);
                int iPhone = ran.Next(0, g_Len - 1);

                long id = TaxiCapture.InsertCuocGoiLanDauByDiaChiFromMEM(this.g_ConnecString, lstLine[iLine].ToString(),
                                                                                            lstPhone[iPhone],
                                                                                            DateTime.Now,
                                                                                            "",
                                                                                            0,
                                                                                            Taxi.Utils.KieuKhachHangGoiDen.KhachHangBinhThuong,
                                                                                            "",
                                                                                            0,
                                                                                            0,
                                                                                            "",
                                                                                            "");
                if (id > 0)
                {
                    // statusLblSoCuocChoXuLy.Text = "Đang thoại : " + g_ListCuocGoiChoXuLy.Count.ToString();
                    lblGoiDen.Invoke((MethodInvoker)delegate()
                    {
                        lblGoiDen.Text = "Gọi đến : " + lstLine[iLine].ToString() + " - " + lstPhone[iPhone];
                    });
                }

                g_Count = 0;
            }

        }
        private void chkSinhCuocGoi_CheckedChanged(object sender, EventArgs e)
        {
            txtLine.Enabled = !chkSinhCuocGoi.Checked;
            txtSoDienThoai.Enabled = !chkSinhCuocGoi.Checked;
            btnGenCall.Enabled =   !chkSinhCuocGoi.Checked;

            btnStart.Enabled = chkSinhCuocGoi.Checked;
            btnStop.Enabled = chkSinhCuocGoi.Checked;
            txtSoGiay.Enabled = chkSinhCuocGoi.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            g_bRun = true;
            
            btnStop.Enabled = true;
            btnStart.Enabled = !btnStop.Enabled;

            timerCapture_Elapsed(null, null);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            g_bRun = false;
            btnStart.Enabled = true;
            btnStop.Enabled = !btnStop.Enabled;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkLine1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLine1.Checked)
            {
                lstLine[0] = 1;
            }
            else
                lstLine[0] = 0;

        }

        private void chkLine2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLine2.Checked)
            {
                lstLine[1] =2;
            }
            else
                lstLine[1] = 0;
        }

        private void chkLine3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLine3.Checked)
            {
                lstLine[2] = 3;
            }
            else
                lstLine[2] = 0;
        }

        private void chkLine4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLine4.Checked)
            {
                lstLine[3] = 4;
            }
            else
                lstLine[3] = 0;
        }

        private void chkLine5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLine5.Checked)
            {
                lstLine[4] = 5;
            }
            else
                lstLine[4] = 0;
        }

        private void chkLine6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLine6.Checked)
            {
                lstLine[5] = 6;
            }
            else
                lstLine[5] = 0;
        }

        private void btnGenCall_Click(object sender, EventArgs e)
        {
            try
            {
                long id = TaxiCapture.InsertCuocGoiLanDauByDiaChiFromMEM(this.g_ConnecString,
                                                                                               txtLine.Text,
                                                                                               txtSoDienThoai.Text,
                                                                                               DateTime.Now,
                                                                                               "",
                                                                                               0,
                                                                                               Taxi.Utils.KieuKhachHangGoiDen.KhachHangBinhThuong,
                                                                                               "",
                                                                                               0,
                                                                                               0,
                                                                                               "",
                                                                                               "");
                if (id > 0)
                {
                    // statusLblSoCuocChoXuLy.Text = "Đang thoại : " + g_ListCuocGoiChoXuLy.Count.ToString();
                    lblGoiDen.Invoke((MethodInvoker)delegate()
                    {
                        lblGoiDen.Text = "Gọi đến : " + txtLine.Text + " - " + txtSoDienThoai.Text;
                    });
                }
                else
                    MessageBox.Show("LOI : Không chèn được.");

            }
            catch(Exception ex)
            {
                MessageBox.Show("LOI :" + ex.Message);
            }
        }

        
    }
}
