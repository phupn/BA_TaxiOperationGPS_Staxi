using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Taxi.GUI.QuanLyChat
{
    public partial class Messenger : Form
    {
        public Messenger()
        {
            InitializeComponent();
        }
        
        private void Messenger_Load(object sender, EventArgs e)
        {
            listMessages1.dgvListMessage.CellDoubleClick += new DataGridViewCellEventHandler(dgvListMessage_CellDoubleClick);
        }

        private void dgvListMessage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
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
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}