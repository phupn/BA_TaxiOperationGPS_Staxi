using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Taxi.Controls
{
    public partial class ctrlGoiSo : UserControl
    {
        public static  string COMPortName = "";         

        public ctrlGoiSo()
        {
            InitializeComponent();
        }
        private void ctrlGoiSo_Load(object sender, EventArgs e)
        {
            
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PortName"></param>
        public void SetPortName(string PortName)
        {
            COMPortName = PortName;
            if (COMPortName.Length <= 0)
            {
                txtSoDienThoai.Text = " Không gọi được.";
                txtSoDienThoai.Enabled = false;
                btnGoi.Enabled = false;
                button11.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        private void btnGoi_Click(object sender, EventArgs e)
        {
            if( COMPortName.Length >0)
                 Call( COMPortName, this.txtSoDienThoai.Text); 
        }
        protected override bool ProcessDialogKey (Keys keyData)
        {
            int code = (int)keyData;
            if ((code >= 48 && code <= 57) || (code >= 96 && code <= 105))
            {
                KeysConverter keyconvert = new KeysConverter();
                txtSoDienThoai.Text += keyconvert.ConvertToString(keyData);
                txtSoDienThoai.SelectionStart = txtSoDienThoai.Text.Length;

                return true;
            }
            else if (keyData == Keys.Back)
            {
                 
                int len = txtSoDienThoai.Text .Length ;
                if (len > 0)
                {
                    int oldPos = txtSoDienThoai.SelectionStart;
                    txtSoDienThoai.Text = txtSoDienThoai.Text.Remove(oldPos - 1, 1);
                    txtSoDienThoai.SelectionStart = oldPos - 1;
                }
                return true;
            }
            else if (keyData == Keys.Delete )
            {

                int len = txtSoDienThoai.Text.Length;
                if (len > 0)
                {
                    int oldPos = txtSoDienThoai.SelectionStart;
                    if (oldPos != len)
                    {
                        txtSoDienThoai.Text = txtSoDienThoai.Text.Remove(oldPos , 1);
                        txtSoDienThoai.SelectionStart = oldPos;
                    }
                }
                return true;
            }
            else if (keyData == Keys.Enter)
            {
                if ( COMPortName.Length > 0)
                    Call( COMPortName, this.txtSoDienThoai.Text);
                return true;
            }
            return false ;
        }

        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys .Escape)
            {
                txtSoDienThoai.Text = "";
            }
        }

        private  void Call(string COMPort, string PhoneNumber )
        { 
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
        }

        private void QuaySoGoiDien(string SoDienThoai)
        {
            string Call = String.Format("ATDT{0}{1}{2}", Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13), Convert.ToChar(11));
            serialPort1.Write(Call);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if ( COMPortName.Length > 0)
                 Call( COMPortName, this.txtSoDienThoai.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text = "";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "8";
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text += "0";
        }

       
    }
}
