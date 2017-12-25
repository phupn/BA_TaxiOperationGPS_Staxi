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

namespace Taxi.GUI
{
    public partial class frmBCVeTheoHopDong : Form
    { 
        public frmBCVeTheoHopDong()
        {
            InitializeComponent();
        }
        private void frmVePhatHanh_Load(object sender, EventArgs e)
        {
            btnThemMoi.Enabled = true;
            btnXuatExcel.Enabled = false;
            lblKhachHang.Text = "";
            lblLienHe.Text = "";
        }
        
         
       
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            int SoHopDong = int.Parse(numSoHopDong.Value.ToString());
            if (SoHopDong >= 0)
            {
                LoadDSHopDongVe(SoHopDong, calTuNgay.Value, calDenNgay.Value);
                LoadDSVeSuDung(SoHopDong, calTuNgay.Value, calDenNgay.Value);
                SetEnabled(false);
            }
        }
        /// <summary>
        /// Load ds ve phat hanh
        /// </summary>
        private void LoadDSHopDongVe(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = Ve.GetDSVeTheoHopDong(SoHopDong, TuNgay, DenNgay);
            grdVePhatHanh.DataMember = "ListVehopDong";
            grdVePhatHanh.SetDataBinding(dt, "ListVehopDong");

            if ((dt != null) && (dt.Rows.Count > 0))
            {
                lblLienHe.Text = dt.Rows[0]["LienHe"].ToString();
                lblKhachHang.Text = dt.Rows[0]["TenKhachHang"].ToString();
            }
        }

        private void LoadDSVeSuDung(int SoHopDong, DateTime TuNgay, DateTime DenNgay)
        {
            grdVeSuDung.DataMember = "ListVeSuDung";
            grdVeSuDung  .SetDataBinding(Ve.GetDSVeTheoHopDongDaSuDung(SoHopDong, TuNgay, DenNgay), "ListVeSuDung");
        }

         
         
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "DanhMucVePhatHanh.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                string path2 = path.Replace(".xls", "") + "_VeSuDung.xls";
                FileStream objFile = new FileStream(path, FileMode.OpenOrCreate);
                FileStream VeSuDung = new FileStream(path2, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                gridEXExporter2.Export((Stream)VeSuDung);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                objFile.Close();
            }
        }

        private void grdVePhatHanh_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void grdVePhatHanh_DoubleClick(object sender, EventArgs e)
        {

        }

        private void numSoHopDong_TextChanged(object sender, EventArgs e)
        {
            SetEnabled(true);
        }

        private void calTuNgay_TextChanged(object sender, EventArgs e)
        {
            SetEnabled(true);
        }

        private bool flgEnabled = false;
        private void SetEnabled(bool flg)
        {
            if (flgEnabled) return;
            flgEnabled = true;
            btnThemMoi.Enabled = flg;
            btnXuatExcel.Enabled = !flg;
            flgEnabled = false;
        }
              
    }
}