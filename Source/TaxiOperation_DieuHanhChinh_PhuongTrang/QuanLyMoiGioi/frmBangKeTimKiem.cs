using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DM;

namespace TaxiOperation_DieuHanhChinh.QuanLyMoiGioi
{
    public partial class frmBangKeTimKiem : Form
    {
        private DataTable DTDoiTac;
        private List<BangKe> mListOfBangKe = new List<BangKe>();
        public frmBangKeTimKiem(DataTable dtDoiTac)
        {
            InitializeComponent();
            DTDoiTac = dtDoiTac;
        }

        private void frmBangKeTimKiem_Load(object sender, EventArgs e)
        {
            LoadDSCongTy();
            LoadDSDoiTac();
        }

        public List<BangKe> GetResultListOfBangKe()
        {
            return mListOfBangKe;
        }

        public void LoadDSCongTy()
        {
            cbCongTy.ValueMember = "CongTyID";
            cbCongTy.DisplayMember = "TenCongTy";
            cbCongTy.DataSource = null;
            DataTable a = CongTy.GetListOfCongTys_NAME();
            cbCongTy.DataSource = CongTy.GetListOfCongTys_NAME();           
            cbCongTy.SelectedIndex = 0;            
        }

        private void LoadDSDoiTac()
        {
            DoiTac objDoiTac = new DoiTac();
            cbMoiGioi.DisplayMember = "Name";
            cbMoiGioi.ValueMember = "Ma_DoiTac";
            cbMoiGioi.DataSource = DTDoiTac;
            cbMoiGioi.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string moiGioi = cbMoiGioi.SelectedValue.ToString();
            string congTy = cbCongTy.SelectedValue.ToString();
            mListOfBangKe = new BangKe().GetListOfBangKes_BySearch(moiGioi, "", congTy, "", calTuNgay.Value, calDenNgay.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}