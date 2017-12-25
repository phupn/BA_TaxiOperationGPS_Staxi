using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaxiOperation_TongDai
{
    public partial class frmLogDebug : Form
    {
        public frmLogDebug()
        {
            InitializeComponent();
        }

        public void WriteLog(long idCuoc, string msg, string content, string status)
        {
            SetText(string.Format("[{0:HH:mm:ss dd/MM}]-[{1}]-[{2}]-[{3}]-[{4}]", DateTime.Now, msg, status, idCuoc, content));
        }
        delegate void SetTextCallback(string text);

        private delegate void ShowCallback();

        public void ShowForm()
        {

            try
            {
                if (this.InvokeRequired)
                {
                    var d = new ShowCallback(ShowForm);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    this.Show();
                }
            }
            catch (Exception ex) { }
            
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = string.Format("{0}{2}{1}", text, this.textBox1.Text, Environment.NewLine);
            }
        }

        private void frmLogDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmLogDebug_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - (Height+340 + 50));
        }
        
    }
}
