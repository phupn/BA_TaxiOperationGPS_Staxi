using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaxiOperation_DieuHanhChinh.QuanLyChat
{
    public partial class Messenger : Form
    {
        public Messenger()
        {
            InitializeComponent();
        }
        
        private void Messenger_Load(object sender, EventArgs e)
        {
            listMessages1.grcContent.DoubleClick+=grcContent_DoubleClick;
            
        }

        private void grcContent_DoubleClick(object sender, EventArgs e)
        {
            using (SendMessage frmSendMessage = new SendMessage())
            {
                frmSendMessage.sendMessage1.g_idMessage = listMessages1.IDMessage_GV;
                frmSendMessage.ShowDialog();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}