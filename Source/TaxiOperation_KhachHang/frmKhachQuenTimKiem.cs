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
    public partial class frmKhachQuenTimKiem : Form
    {
        private List<DanhBaKhachQuen> mListOfKhachQuen = new List<DanhBaKhachQuen>();


        public frmKhachQuenTimKiem()
        {
            InitializeComponent();
        }

        public List<DanhBaKhachQuen> GetResultListOfKhachQuen()
        {
            return mListOfKhachQuen;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string SoDT = string.Empty;
            string DiaChi = string.Empty;
            string TenKH = string.Empty;
            if (radDienThoai.Checked)
                SoDT = StringTools.TrimSpace(editThongTinTimKiem.Text);
            else if (radTen.Checked)
                TenKH = StringTools.TrimSpace(editThongTinTimKiem.Text);
            else if (radDiaChi.Checked)
                DiaChi = StringTools.TrimSpace(editThongTinTimKiem.Text);

            mListOfKhachQuen = DanhBaKhachQuen.GetDanhBaKhachQuen_Search(SoDT, TenKH, DiaChi);

             DialogResult = DialogResult.OK;
             Close();
        }
    }
}