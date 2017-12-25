using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmLoaiXe : Form
    {
        int g_ID = 0;
        public frmLoaiXe()
        {
            g_ID = -1;
            InitializeComponent();
        }

        public frmLoaiXe(int ID, string TenLoaiXe, int SoCho)
        {
            InitializeComponent();
            g_ID = ID;
            txtTenLoaiXe.Text = TenLoaiXe;
            numSoCho.Value = SoCho;
        }

        private bool ValidateData(string TenLoaiXe, int SoCho)
        {
            if (TenLoaiXe.Length <= 0) return false;            
            if (SoCho < 0) return false;
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string TenLoaiXe = StringTools.TrimSpace (txtTenLoaiXe.Text );
            int SoCho = Convert.ToInt16(numSoCho.Value);

            if (!this.ValidateData(TenLoaiXe,SoCho ))
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập thông tin tên loại xe và  số chỗ.", "Thông báo",
                      Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return;
            }

            if (LoaiXe.CheckTrungTen_LoaiXe(g_ID, TenLoaiXe, SoCho))
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn kiểm tra lại tên loại xe bị trùng.", "Thông báo",
                     Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return;
            }

            if (g_ID > 0) // Update
            {
                if (!(new LoaiXe().UpdateLoaiXe(g_ID, TenLoaiXe, SoCho)))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật thông tin.", "Thông báo",
                     Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                if (!(new LoaiXe().InsertLoaiXe(TenLoaiXe, SoCho)))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi cập nhật thông tin.", "Thông báo",
                     Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    return;
                }
                else
                {
                    this.Close();
                } 
            }             
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Xử lý hot key

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion
    }
}