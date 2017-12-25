using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmSanhXe : Form
    {
        public frmSanhXe()
        {
            InitializeComponent();
        }

        private void frmSanhXe_Load(object sender, EventArgs e)
        {
            LoadDSSach();
            LoadDSXeKhongThuocSanhNao();
        }

        /// <summary>
        /// ham load ds xe cuar mot sanh
        /// </summary>
        /// <param name="SanhID"></param>
        private void LoadDSCacXeThuocSanh(int SanhID)
        {
            lstXeThuocSanh.DisplayMember = "SoHieuXe";
            lstXeThuocSanh.ValueMember = "SoHieuXe";
            lstXeThuocSanh.DataSource = Sanh.GetDSXeThuocSanh(SanhID);
        }
        private void LoadDSXeKhongThuocSanhNao()
        {
            lstXeKhongThuocSanhNao.DisplayMember = "SoHieuXe";
            lstXeKhongThuocSanhNao.ValueMember = "SoHieuXe";
            lstXeKhongThuocSanhNao.DataSource = Sanh.GetDSXeKhongThuocSanhNao();
        }
        private void LoadDSSach()
        {
            lstSanh.DisplayMember = "Name";
            lstSanh.ValueMember = "ID";
            lstSanh.DataSource = Sanh.GetAllSanh();
        }

        private void lnkThemSanh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmSanh().ShowDialog();
            LoadDSSach();
        }

        private void lnkSuaSanh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(lstSanh.SelectedValue.ToString());
            string Name = lstSanh.Text ;
            if (ID > 0)
            {
                new frmSanh(ID, Name).ShowDialog(); LoadDSSach();
            }
        }

        private void lnkXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(lstSanh.SelectedValue.ToString());
            string Name = lstSanh.Text;
            if (ID > 0)
            {
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA ();
                if (msg.Show(this, "Bạn có đồng ý xóa sảnh này không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question)==DialogResult.Yes.ToString ())
                {
                    Sanh.Delete(ID); LoadDSSach(); LoadDSXeKhongThuocSanhNao();
                }
            }
        }

        private void lstSanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SanhID = Convert.ToInt32 (  lstSanh.SelectedValue.ToString ());
            LoadDSCacXeThuocSanh(SanhID);
        }
        /// <summary>
        /// xoas mootj xe khoi sanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            if (lstXeThuocSanh.SelectedValue == null) return;
            string SoHieuXe = lstXeThuocSanh.SelectedValue.ToString();
            int SanhID = Convert.ToInt32(lstSanh.SelectedValue.ToString());
            if ((SoHieuXe.Length > 0) && (SanhID > 0))
            {
                if (Sanh.XoaXeTrongSanh(SoHieuXe ))
                {
                    LoadDSCacXeThuocSanh(SanhID);
                    LoadDSXeKhongThuocSanhNao();
                }
                else
                {
                    MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                    msg.Show(this, "Có lỗi xử lý xóa xe khỏi sảnh.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }

            }
        }
        /// <summary>
        /// them xe vao sanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOne_Click(object sender, EventArgs e)
        {
            
            string SoHieuXe = lstXeKhongThuocSanhNao.SelectedValue.ToString();
            int SanhID = Convert.ToInt32(lstSanh.SelectedValue.ToString());
            if ((SoHieuXe.Length > 0) && (SanhID > 0))
            {
                if (Sanh.AddXeVaoSanh(SoHieuXe, SanhID))
                {
                    LoadDSCacXeThuocSanh(SanhID);
                    LoadDSXeKhongThuocSanhNao();
                }
                else
                {
                    MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                    msg.Show(this, "Có lỗi xử lý thêm xe khỏi sảnh.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }

            }
        }
    }
}