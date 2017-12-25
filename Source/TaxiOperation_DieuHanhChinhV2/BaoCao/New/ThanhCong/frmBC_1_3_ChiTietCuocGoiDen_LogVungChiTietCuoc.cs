using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI.BaoCao.ThanhCong
{
    public partial class frmBC_1_3_ChiTietCuocGoiDen_LogVungChiTietCuoc : Form
    {
        private long g_IDDieuHanh = 0;
        public frmBC_1_3_ChiTietCuocGoiDen_LogVungChiTietCuoc()
        {
            InitializeComponent();
        }
        public frmBC_1_3_ChiTietCuocGoiDen_LogVungChiTietCuoc(long idDieuHanh)
        {
            InitializeComponent();
            g_IDDieuHanh = idDieuHanh;
        }
        

        private void frmBC_1_3_ChiTietCuocGoiDen_LogVungChiTietCuoc_Load(object sender, EventArgs e)
        {
            gridDienThoai.DataMember = "lstCuocGoiKetThuc";
            gridDienThoai.SetDataBinding( TimKiem_BaoCao.GetBaoCaoLogChuyenVungChiTietVung(g_IDDieuHanh)  , "lstCuocGoiKetThuc"); 
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}