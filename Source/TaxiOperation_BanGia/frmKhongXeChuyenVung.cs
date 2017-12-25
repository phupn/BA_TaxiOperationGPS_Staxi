using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanLyVe;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmKhongXeChuyenVung : Form
    {
        private DieuHanhTaxi mDieuHanhTaxi;


        public frmKhongXeChuyenVung(DieuHanhTaxi DieuHanhTaxi)
        {
            InitializeComponent();
            mDieuHanhTaxi = DieuHanhTaxi;
            
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MessageBox.MessageBox msg = new Taxi.MessageBox.MessageBox();
            try
            {
                int iVung = Convert.ToInt32(txtNam.Text);
                if (iVung > 0)
                {
                    if (DieuHanhTaxi.TongDai_ChuyenVung(mDieuHanhTaxi.ID_DieuHanh, iVung))
                    {
                        msg.Show("Chuyển vùng thành công."); this.Close();
                    }
                    else
                        msg.Show("Có lỗi chuyển vùng.");
                }
            }
            catch (Exception ex)
            {
                
                msg.Show("Bạn phảinhập vùng là kiểu số.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}