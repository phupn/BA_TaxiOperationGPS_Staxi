using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmNhapThongTinGoiKhachThanThiet : Form
    {
        private string g_MaKhachHang ;
        public frmNhapThongTinGoiKhachThanThiet(string maKhachHang,string tenKhachHang, string soDienThoai)
        {
            InitializeComponent();

            g_MaKhachHang = maKhachHang;
            lblSoDienThoai.Text = soDienThoai;
            lblTenKhachHang.Text = tenKhachHang;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate thong tin
            byte trangThaiCuocGoi = 0;
            try
            {

                string textSelect = cboTrangThai.Text;
                if (textSelect == "Gọi thành công")
                {
                    trangThaiCuocGoi = 1;
                }
                else if (textSelect == "Gọi không nghe máy")
                {
                    trangThaiCuocGoi = 2;
                }
                else if (textSelect == "Không liên lạc được")
                {
                    trangThaiCuocGoi = 3;
                }
                else if (textSelect == "Khác")
                {
                    trangThaiCuocGoi = 9;
                }
            }
            catch (Exception ex)
            {
                trangThaiCuocGoi = 0;
            }

            if (trangThaiCuocGoi == 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn phải chọn thông tin xử lý cuộc gọi.");
                return;
            }

            DanhBaKhachQuen.CapNhatTrangThaiGoiChoKhach(g_MaKhachHang, trangThaiCuocGoi, StringTools.TrimSpace(txtGhiChuCS.Text));
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
         
    }
}