using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmDMDiaDanhKm : Form
    {
        public frmDMDiaDanhKm()
        {
            InitializeComponent();
            LoadDiaDanh();
        }

        private void LoadDiaDanh()
        {
            gridDiaDanhKm.DataMember = "listDiaDanh";
            gridDiaDanhKm.SetDataBinding(TinhTienTheoKm.GetAllDiaDanh() , "listDiaDanh");
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TenDiaDanh = StringTools.TrimSpace(txtTimKiem.Text);
            if (TenDiaDanh.Length <= 0)
                this.LoadDiaDanh();
            else
            {
                gridDiaDanhKm.DataMember = "listDiaDanh";
                gridDiaDanhKm.SetDataBinding(TinhTienTheoKm.SearchDiaDanhByTen(TenDiaDanh), "listDiaDanh");
            }
        }
    }
}