using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmTinhTienTheoKm : Form
    {
        
        public frmTinhTienTheoKm()
        {
            InitializeComponent();
        }

        private void frmTinhTienTheoKm_Load(object sender, EventArgs e)
        {
            if (rad4Cho.Checked)
            {
                TinhTienTheoKm objTinhTien = new TinhTienTheoKm(4, 1);

                GetMessaage(objTinhTien); 
            }
            LoadDiaDanh();
            chkDiaDanh.Checked = false;
            cboDiaDanh.Enabled = false;
        }

        private void GetMessaage(TinhTienTheoKm TinhTien)
        {
            //1,2 Km đầu tiên : 
            lblMessage1.Text = string.Format("{0:0.0}", TinhTien.KmMoCua) + " Km đầu tiên : " + string.Format("{0:0,0}", TinhTien.GiaMoCua) + " VND";
            //1,2 --> 30 Km tiếp theo : 
            lblMessage2.Text = string.Format("{0:0.0}", TinhTien.KmMoCua) + " -->: " + string.Format("{0:0,0}", TinhTien.KmNguong1) + " Km tiếp theo : " + string.Format("{0:0,0}", TinhTien.GiaNguong1 ) + " VND";
            // Từ Km 31 trở  lên : 
            lblMessage3.Text = "Từ Km "  +   string.Format("{0:0,0}", TinhTien.KmNguong1 + 1)  +" : " + string.Format("{0:0,0}", TinhTien.GiaNguong2 ) + " VND";
            // Khách đi 2 chiều mà lớn hơn bằng 30 Km, chiều về bằng 30% chiều đi
            lblMessage4.Text = "Khách đi 2 chiều mà lớn hơn bằng " + string.Format("{0:0,0}", TinhTien.KmNguong2Chieu) + " Km, chiều về bằng " + string.Format("{0:0,0}", 100 - TinhTien.TiLeGiamGia2Chieu) + "% chiều đi";
        }
        private void btnThoai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            Calculator();
        }

        private void editKm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Calculator();
            }
        }

        private void Calculator()
        {
            if (editKm.Text.Length <= 0) return;
            float  SoKm = float.Parse(editKm.Text);
            int LoaiXe=4;
            
            if(rad4Cho.Checked ) LoaiXe = 4;
            if(radioButton2.Checked ) LoaiXe = 7;
            TinhTienTheoKm objTinhTien = new TinhTienTheoKm();
            if (chkTaxiCP.Checked)
                objTinhTien = new TinhTienTheoKm(LoaiXe, SoKm);
           // else objTinhTien = new TinhTienTheoKm(LoaiXe, SoKm, chkTaxiCP.Checked);

            editTienChieuDi.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu);
            editTienChieuVe.Text = string.Format("{0:0,0}", objTinhTien.TongTien2Chieu);
            editTongTien.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu + objTinhTien.TongTien2Chieu);


        }

        private void rad4Cho_CheckedChanged(object sender, EventArgs e)
        {
            if (rad4Cho.Checked)
            {
                TinhTienTheoKm objTinhTien = new TinhTienTheoKm(4, 1);

                GetMessaage(objTinhTien); Calculator();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                TinhTienTheoKm objTinhTien = new TinhTienTheoKm(7, 1);

                GetMessaage(objTinhTien); Calculator();
            }
        }

        private void chkDiaDanh_CheckedChanged(object sender, EventArgs e)
        {          

                cboDiaDanh.Enabled = chkDiaDanh.Checked;
         
        }

        private void LoadDiaDanh()
        {
            cboDiaDanh.DisplayMember = "TenDiaDanh";
            cboDiaDanh.ValueMember = "ID";
            cboDiaDanh.DataSource = TinhTienTheoKm.GetAllDiaDanh();
        }

      

        private void cboDiaDanh_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDiaDanh.SelectedItem != null)
            {
                editKm.Text = ((DataRowView)cboDiaDanh.SelectedItem).Row["Km"].ToString();
                this.Calculator();
            }
        }        
    }
}