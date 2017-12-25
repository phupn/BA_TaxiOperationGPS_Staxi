using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;

namespace TaxiOperation_DieuHanhChinh
{
    public partial class frmDanhBaBuuDien : Form
    {
        public frmDanhBaBuuDien()
        {
            InitializeComponent();
        }

        private void frmDanhBaBuuDien_Load(object sender, EventArgs e)
        {
            try
            {
                List<DanhBaCongTy> listDBBuuDien = DanhBa.GetDanhBa_BuuDien_1();
                gridDanhBaBuuDien.DataSource = listDBBuuDien;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDanhBaBuuDien_Load: ",ex);                
            }            
        }
    }
}
