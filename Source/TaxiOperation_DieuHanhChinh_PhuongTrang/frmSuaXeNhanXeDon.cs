using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmSuaXeNhanXeDon : Form
    {
        public string XeNhan = "";
        public string XeDon = "";
        public frmSuaXeNhanXeDon()
        {
            InitializeComponent();
        }

        public frmSuaXeNhanXeDon(  string XeNhan,string XeDon)
        {
            InitializeComponent();
            
            txtXeDon.Text = XeDon;
            txtXeNhan.Text = XeNhan;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            XeNhan = StringTools.TrimSpace(txtXeNhan.Text);
            XeDon = StringTools.TrimSpace(txtXeDon.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}