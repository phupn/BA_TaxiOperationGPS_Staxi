using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Taxi.GUI
{
    public partial class SendMessage : Form
    {
        string g_TieuDe;
        string g_NoiDung;
        string g_TaiKhoan;
        public SendMessage()
        {
            InitializeComponent();
        }
        public SendMessage(string strTieuDe, string strNoiDung, string strTaIKhoan)
        {
            InitializeComponent();
            g_TieuDe = strTieuDe;
            g_NoiDung = strNoiDung;
            g_TaiKhoan = strTaIKhoan;
        }

        private void SendMessage_Load(object sender, EventArgs e)
        {
            ctrlSendMessage.txtTaiKhoan1.Enabled = false;
            ctrlSendMessage.btnTaiKhoan.Enabled = false;
            ctrlSendMessage.chkIsActiveUser.Enabled = false;
            ctrlSendMessage.rbDHV.Enabled = false;
            ctrlSendMessage.rbDTV.Enabled = false;
            ctrlSendMessage.rbTatCa.Enabled = false;
            ctrlSendMessage.txtTaiKhoan1.Text = g_TaiKhoan;
            ctrlSendMessage.txtTieuDe.Text = g_TieuDe;
            ctrlSendMessage.txtNoiDung1.Text = g_NoiDung;
            ctrlSendMessage.txtNoiDung1.Focus();
            //ctrlSendMessage.txtNoiDung.Select(g_NoiDung.Length, 0);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}