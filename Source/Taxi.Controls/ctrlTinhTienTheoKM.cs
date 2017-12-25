using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.Controls
{
    public partial class ctrlTinhTienTheoKM : UserControl
    {
        public ctrlTinhTienTheoKM()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            //if (rad4Cho.Checked)
            //{
            //    Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
            //}
            LoadDiaDanh();
            chkDiaDanh.Checked = false;
            cboDiaDanh.Enabled = false;
        }

        private void GetMessaage(TinhTienTheoKm TinhTien)
        {
            //1,2 Km đầu tiên : 
            lblMessage1.Text = string.Format("{0:0.00}", TinhTien.KmMoCua) + " Km đầu tiên : " + string.Format("{0:0,0}", TinhTien.GiaMoCua) + " VND";
            //1,2 --> 30 Km tiếp theo : 
            lblMessage2.Text = string.Format("Km tiếp theo đến Km {0:0.0}", TinhTien.KmNguong1) + " " + string.Format("{0:0,0}", TinhTien.GiaNguong1) + " VND";
            // Từ Km 31 trở  lên : 
            lblMessage3.Text = "Từ Km " + string.Format("{0:0.0}", TinhTien.KmNguong1 + 1) + " : " + string.Format("{0:0,0}", TinhTien.GiaNguong2) + " VND";
            // Khách đi 2 chiều mà lớn hơn bằng 30 Km, chiều về bằng 30% chiều đi
            //khách  đi 2 chiều trong ngày , cự ly 30 km (cả đi và về > 60 km), chiều về được giảm 60%
            // lblMessage4.Text = "Khách đi 2 chiều mà lớn hơn bằng " + string.Format("{0:0,0}", TinhTien.KmNguong2Chieu) + " Km, chiều về bằng " + string.Format("{0:0,0}", 100 - TinhTien.TiLeGiamGia2Chieu) + "% chiều đi";
            txtThongTinThueBao.Text = TinhTien.ThongTinThueBao;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
        }

        private void editKm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
            }
        }

        private void Calculator(bool IsCP)
        {
            if (editKm.Text.Length <= 0) return;
            float SoKm = float.Parse(editKm.Text);
            float SoKm2Chieu = SoKm * 2;
            int LoaiXe = 4;

            if (rad4Cho.Checked) LoaiXe = 4;
            if (rad7Cho.Checked) LoaiXe = 7;

            TinhTienTheoKm objTinhTien = new TinhTienTheoKm(chkCuocDem.Checked, LoaiXe, SoKm);

            editTienChieuDi.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu);
            editTienChieuVe.Text = string.Format("{0:0,0}", objTinhTien.TongTien2Chieu);
            editTong.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu + objTinhTien.TongTien2Chieu);
            lblKm2Chieu.Text = "(" + SoKm2Chieu.ToString() + " Km)";
            if (SoKm > objTinhTien.KmNguong2Chieu) lblPhanTramGiam.Text = string.Format("{0:0}%", objTinhTien.TiLeGiamGia2Chieu);
            else lblPhanTramGiam.Text = "";

            GetMessaage(objTinhTien);
        }

        private void rad4Cho_CheckedChanged(object sender, EventArgs e)
        {
            if (rad4Cho.Checked)
            {
                Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
            }
        }

        private void rad7Cho_CheckedChanged(object sender, EventArgs e)
        {
            if (rad7Cho.Checked)
            {
                Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
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
                this.Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
            }
        }

        private void lblMessage3_Click(object sender, EventArgs e)
        {

        }

        private void chkCuocDem_CheckedChanged(object sender, EventArgs e)
        {
            Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
        }

        private void ctrlTinhTienTheoKM_Load(object sender, EventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.D4:
                    rad4Cho.Checked = true;
                    return true;
                case Keys.Alt | Keys.D7:
                    rad7Cho.Checked = true;
                    return true;
                case Keys.Alt | Keys.D:
                    chkCuocDem.Checked = true;
                    return true;
                case Keys.Alt | Keys.A:
                    chkDiaDanh.Checked = true;
                    return true;
                case Keys.Alt | Keys.K:
                    editKm.Focus();
                    return true;
                case Keys.Alt | Keys.N: 
                case Keys.Enter:
                    Calculator(ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
