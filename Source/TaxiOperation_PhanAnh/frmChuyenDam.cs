using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.ThongTinPhanAnh;
using Taxi.Utils;
using Taxi.Business;

namespace TaxiOperation_TongDai
{
    public partial class frmChuyenDam : Form
    {
        ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
        public frmChuyenDam()
        {
            InitializeComponent();
        }
        public frmChuyenDam(ThongTinPhanAnh paChuyenDam)
        {
            InitializeComponent();
            objPhanAnh = paChuyenDam;
            txtSoDienThoai.Text = objPhanAnh.DienThoai;
            txtDiaChi.Text = objPhanAnh.NoiDung;
           
        }

        private void btnChuyenDam_Click(object sender, EventArgs e)
        {
            int Vung = 0;
            if(StringTools.TrimSpace(txtSoDienThoai.Text)== string.Empty )
            {
                new Taxi.MessageBox.MessageBox().Show(this, "Số điện thoại không thể để trống", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            }
            else if(StringTools.TrimSpace(txtDiaChi.Text) == string.Empty )
            {
                new Taxi.MessageBox.MessageBox().Show(this, "Hãy nhập nội dung phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            }
            else if(StringTools.TrimSpace(txtVung.Text) == string.Empty )
            {
                 new Taxi.MessageBox.MessageBox().Show(this, "Hãy nhập vùng cần chuyển đàm", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            }
            else if (StringTools.TrimSpace(txtVung.Text).Length > 0 && txtVung.Text != "_")
            {
                try
                {
                    Vung = int.Parse(txtVung.Text.Replace("_", ""));
                }
                catch (Exception ex)
                {
                    Vung = 0;
                }
            }
            if (Vung <= 0)
            {
                 new Taxi.MessageBox.MessageBox().Show(this, "Bạn phải nhập vùng chuyển đàm", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                txtVung.Focus();
                //this.g_FormValidate = false;
                return;
            }
            else // check ton tai vung trong vung cai hinh
            {
                if (!CheckVungNamTrongVungCauHinh(Vung))
                {
                    new Taxi.MessageBox.MessageBox().Show(this, "Bạn phải nhập vùng chuyển đàm thuộc vùng cấu hình.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    txtVung.Focus();
                    //this.g_FormValidate = false;
                    return;
                }
                else
                {                     
                    if(objPhanAnh.InsertPhanAnhChuyenDam(StringTools.TrimSpace(txtSoDienThoai.Text),StringTools.TrimSpace(txtDiaChi.Text),Vung)>0)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }

        }
        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
            {
                string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
                for (int i = 0; i < arrVung.Length; i++)
                {
                    if (Convert.ToInt32(arrVung[i]) == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            else bCheck = false;
            return bCheck;
        } 
    }
}