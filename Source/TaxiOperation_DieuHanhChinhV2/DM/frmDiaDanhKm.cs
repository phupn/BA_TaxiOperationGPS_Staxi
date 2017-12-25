using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmDiaDanhKm : Form
    {
        int g_ID = 0;
        public frmDiaDanhKm()
        {
            g_ID = -1;
            InitializeComponent();
        }

        public frmDiaDanhKm(int ID, string TenDiaDanh, int Km)
        {
            InitializeComponent();
            g_ID = ID;
            txtTenDiaDanh.Text = TenDiaDanh;
            numKm.Value = Km;
        }

        private bool ValidateData(string TenDiaDanh, int Km)
        {

            if (TenDiaDanh.Length <= 0) return false;

            
            if (Km <= 0) return false;

            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string TenDiaDanh = StringTools.TrimSpace (txtTenDiaDanh.Text );
            int Km = Convert.ToInt16(numKm.Value);

            if (!this.ValidateData(TenDiaDanh,Km ))
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập thông tin tên địa danh và  Km > 0.", "Thông báo",
                      Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;
            }

            if (TinhTienTheoKm.CheckTrungTen(g_ID, TenDiaDanh))
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn kiểm tra lại tên địa danh bị trùng.", "Thông báo",
                     Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                return;
            }

            if (g_ID > 0) // Update
            {
                if (!TinhTienTheoKm.UpdateDiaDanhKm(g_ID, TenDiaDanh, Km))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật thông tin.", "Thông báo",
                     Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    return;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Cập nhật thông tin thành công.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    this.Close();
                }

            }
            else
            {
                if (!TinhTienTheoKm.InsertDiaDanhKm( TenDiaDanh, Km))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật thông tin.", "Thông báo",
                     Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    return;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Nhập mới thành thông tin thành công.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    this.Close();
                } 

            }
             
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}