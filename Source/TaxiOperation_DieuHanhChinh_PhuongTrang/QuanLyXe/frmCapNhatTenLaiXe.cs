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
    public partial class frmCapNhatTenLaiXe : Form
    {
        string g_SoHieuXe = "";
        DateTime g_ThoiDiemBatDau = DateTime.Now;
        DateTime g_ThoiDiemVe = DateTime.Now;
        public frmCapNhatTenLaiXe()
        {
            InitializeComponent();
        }

        public frmCapNhatTenLaiXe( string SoHieuXe, DateTime ThoiDiemBatDau)
        {
            InitializeComponent();
            g_SoHieuXe = SoHieuXe; lblSoHieuXe.Text = g_SoHieuXe;
            g_ThoiDiemBatDau = ThoiDiemBatDau; lblTHoiDiemBatDau.Text = string.Format("{0: HH:mm dd/MM/yyyy}", g_ThoiDiemBatDau);
            g_ThoiDiemVe = KiemSoatXeLienLac.GetThoiDiemVeCuaXe(SoHieuXe, ThoiDiemBatDau);

            if (g_ThoiDiemVe == DateTime.MinValue) g_ThoiDiemVe = DieuHanhTaxi.GetTimeServer();
            lblThoiDiemVe.Text = string.Format("{0: HH:mm dd/MM/yyyy}", g_ThoiDiemVe);

        }
         

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                KiemSoatXeLienLac.UpdateTenLaiXe(g_SoHieuXe, g_ThoiDiemBatDau,g_ThoiDiemVe , StringTools.TrimSpace(txtTenlaiXe.Text));
                this.Close();
            }
            else lblMessage.Text ="Chưa có thông tin tên lái xe.";


        }
        /// <summary>
        /// kiểm tra xe đã có thông tin lái xe chưa
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            string TenLaiXe = StringTools.TrimSpace(txtTenlaiXe.Text);
            if (TenLaiXe.Length <= 0)
                return false;

            return true;
        }

        private void txtMaTheLaiXe_Leave(object sender, EventArgs e)
        {
            string MaLaiXe = StringTools.TrimSpace (txtMaTheLaiXe.Text );
            if (MaLaiXe.Length > 0)
            {

                NhanVien objNV = NhanVien.GetNhanVienByTheLaiXe(MaLaiXe);
                    if (objNV != null)
                    {
                        txtTenlaiXe.Text =   objNV.TenNhanVien ;
                    }
                 
            }
        }
    }
}