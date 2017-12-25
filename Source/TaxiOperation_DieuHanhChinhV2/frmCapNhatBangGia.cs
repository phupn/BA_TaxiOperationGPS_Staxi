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
    public partial class frmCapNhatBangGia : Form
    {
        private bool G_LoaiCuoc = false;
        public frmCapNhatBangGia()
        {
            InitializeComponent();
        }

        private void frmTinhTienTheoKm_Load(object sender, EventArgs e)
        {
            cbLoaiCuoc.SelectedIndex = 0;
            LoadDuLieu();
        }
        private void LoadDuLieu()
        {            
            TinhTienTheoKm obj4 = new TinhTienTheoKm(G_LoaiCuoc, 4, 1);
            numGiaMoCua.Value = (float)obj4.GiaMoCua;
            numKmMoCua4.Value = (float)obj4.KmMoCua;
            numKmNguong1.Value = (float   )obj4.KmNguong1;
            numGiaNguong1.Value = (float)obj4.GiaNguong1;
            numGiaNguong2.Value = (float)obj4.GiaNguong2;
            numKmNguong2Chieu.Value = (float)obj4.KmNguong2Chieu;
            numTiLeGiamGia2Chieu.Value = (float)obj4.TiLeGiamGia2Chieu;
            txtThongTinThueBao.Text = obj4.ThongTinThueBao;

            TinhTienTheoKm obj7 = new TinhTienTheoKm(G_LoaiCuoc, 7, 1);
            numGiaMoCua7.Value = (float)obj7.GiaMoCua;
            numKmMoCua7.Value = (float)obj7.KmMoCua;
            numKmNguong17.Value = (float)obj7.KmNguong1;
            numGiaNguong17.Value = (float)obj7.GiaNguong1;
            numGiaNguong27.Value = (float)obj7.GiaNguong2;
            numKmNguong2Chieu7.Value = (float)obj7.KmNguong2Chieu;
            numTiLeGiamGia2Chieu7.Value = (float)obj7.TiLeGiamGia2Chieu;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            TinhTienTheoKm objTinhTien = new TinhTienTheoKm(
                (float)numKmMoCua4.Value
                ,(float)numGiaMoCua.Value
                ,(float)numKmNguong1.Value
                ,(float) numGiaNguong1.Value
                ,(float)numGiaNguong2.Value
                ,(float)numKmNguong2Chieu.Value
                ,(float)numTiLeGiamGia2Chieu.Value
                ,4
                , txtThongTinThueBao.Text
                , G_LoaiCuoc);
            if (!objTinhTien.Update())
            {
                new MessageBox.MessageBoxBA().Show("Lỗi cập nhật thông tin giá cước mới cho loại xe 4 chỗ.");
                return;
            }
            objTinhTien = null;

            TinhTienTheoKm objTinhTien7 = new TinhTienTheoKm((float)numKmMoCua7.Value, (float)numGiaMoCua7.Value, (float)numKmNguong17.Value, (float)numGiaNguong17.Value, (float)numGiaNguong27.Value, (float)numKmNguong2Chieu7.Value, (float)numTiLeGiamGia2Chieu7.Value, 7, txtThongTinThueBao.Text, G_LoaiCuoc);
            if (!objTinhTien7.Update())
            {
                new MessageBox.MessageBoxBA().Show("Lỗi cập nhật thông tin giá cước mới cho loại xe 7 chỗ.");
                return;
            }
            new MessageBox.MessageBoxBA().Show("Cập nhật thông tin giá cước mới thành công.");
            this.Close();
        }

        private void btnThoai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiCuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiCuoc.SelectedIndex == 1)
            {
                G_LoaiCuoc = true;
            }
            else
            {
                G_LoaiCuoc = false;
            }
            LoadDuLieu();
        }
    }
}