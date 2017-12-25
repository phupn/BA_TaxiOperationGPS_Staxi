using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.BanGiaGoc;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmTraCuuBangGiaGoc : Form
    {
        int Flat = 0;
        string TuyenDuongID = "";
        int LoaixeID = 0;
        bool g_IsQuanToan = false;
        bool g_IsLoaded = false;
        public frmTraCuuBangGiaGoc()
        {
            InitializeComponent();
        }
        private void frmNhapBangGiaGoc_Load(object sender, EventArgs e)
        {
            LoadKieuTuyenDuong();
            LoadTuyenDuong();
            g_IsLoaded = true;
            if (cboKieuTuyen.Items.Count > 1)
                cboKieuTuyen.SelectedIndex = 1;
            lstTuyenDuong.Focus();
        }
        public void LoadKieuTuyenDuong()
        {
            Taxi.Business.BanGiaGoc.TuyenDuong TuyendDuongcontrol = new Taxi.Business.BanGiaGoc.TuyenDuong();
            DataTable dt = TuyendDuongcontrol.GetKieuTuyenDuong();

            cboKieuTuyen.DataSource = dt;
            cboKieuTuyen.DisplayMember = "KieuTuyen";
            cboKieuTuyen.ValueMember = "Id";
        }
        public void LoadTuyenDuong()
        {
            int Kieutuyen;
            Kieutuyen = (int)cboKieuTuyen.SelectedValue;
            Taxi.Business.BanGiaGoc.TuyenDuong TuyendDuongcontrol = new Taxi.Business.BanGiaGoc.TuyenDuong();
            DataTable dt = TuyendDuongcontrol.TableTuyenDuong(Kieutuyen);

            lstTuyenDuong.DataSource = dt;
            lstTuyenDuong.DisplayMember = "TenTuyenDuong";
            lstTuyenDuong.ValueMember = "TuyenDuongID";
        }
        private void cboKieuTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (g_IsLoaded)
                LoadTuyenDuong();
        }


        /// <summary>
        /// hien thi ds cac gia cua cac loai xe tren mot tuyen duong
        /// </summary>
        /// <param name="IsQuanToan"></param>
        /// <param name="MaTuyenDuong"></param>
        public void LoadGiaGoc(bool IsQuanToan, string MaTuyenDuong)
        {
            Dulieudauvaotinhtien objDuLieuDauVao = new Dulieudauvaotinhtien();         
            grdLoaiXeTuyenDuong.AutoGenerateColumns = false;
            grdLoaiXeTuyenDuong.DataSource = objDuLieuDauVao.GetDSGiaCuaMotTuyen(IsQuanToan, MaTuyenDuong);
        }
         
        private void lstTuyenDuong_SelectedValueChanged(object sender, EventArgs e)
        {
            if (g_IsLoaded)
            {
                if (lstTuyenDuong.SelectedValue == null)
                {
                    new MessageBox.MessageBoxBA().Show("Vui lòng nhập tuyến đường");
                    return;
                }
                string MaTuyenDuong = lstTuyenDuong.SelectedValue.ToString();
                LoadGiaGoc(g_IsQuanToan, MaTuyenDuong);
            }
        }
    }
}