using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Janus.Windows;   
namespace Taxi.GUI
{
    public partial class frmDienThoaiHenKhach : Form
    {
        private DieuHanhTaxi mDieuHanhTaxi = new DieuHanhTaxi();
        private CuocGoiKhachHen mCuocGoiKhachHen = new CuocGoiKhachHen();
        public CuocGoiKhachHen GetCuocGoiKhachHen
        {
            get { return mCuocGoiKhachHen; }             
        }
        /// <summary>
        /// chi co du lieu cuoc goi
        /// </summary>
        /// <param name="DieuHanhTaxi"></param>
        public frmDienThoaiHenKhach(DieuHanhTaxi DieuHanhTaxi)
        {
            InitializeComponent();
            mDieuHanhTaxi = DieuHanhTaxi;
            mCuocGoiKhachHen = CuocGoiKhachHen.GetKhachHen(mDieuHanhTaxi.ID_DieuHanh);
        }
        /// <summary>
        /// da co day du du lieu cuoc goi + du lieu cuoc hen.
        /// </summary>
        /// <param name="DieuHanhTaxi"></param>
        /// <param name="CuocGoiKhachHen"></param>
        public frmDienThoaiHenKhach(DieuHanhTaxi  DieuHanhTaxi, CuocGoiKhachHen CuocGoiKhachHen)
        {
            InitializeComponent();

            mDieuHanhTaxi = DieuHanhTaxi;
            mCuocGoiKhachHen = CuocGoiKhachHen;
        }
        /// <summary>
        /// Truyen vao mot doi tuong DieuHanh, tuong duoc mot cuoc goi 
        /// </summary>
        /// <param name="DieuHanhTaxi"></param>       
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {           
            this.SetData2Form();
        }
        /// <summary>
        /// Thiet lap gia tri của dư lieu len form
        /// </summary>
        private void SetData2Form()
        {

            if (mDieuHanhTaxi != null)
            {
                // line + phone + time

                lblInfo.Text = "[ " + mDieuHanhTaxi.Line + " ]  " + mDieuHanhTaxi.PhoneNumber + "  " + mDieuHanhTaxi.ThoiDiemGoiGio;

                // set default 
                // if (!(chkGoiLai.Checked || chkGoiLai.Checked || chkGoiKhac.Checked)) chkGoiTaxi.Checked = true;
                txtDiaChiDonKhach.Text = mDieuHanhTaxi.DiaChiDonKhach;
                if (mDieuHanhTaxi.LoaiXe.Contains("4")) chkXe4.Checked = true;
                if (mDieuHanhTaxi.LoaiXe.Contains("7")) chkXe7.Checked = true;
                editSoLuongXe.TextBox.Text = mDieuHanhTaxi.SoLuong;
                editVung.TextBox.Text = mDieuHanhTaxi.MaVung;     
            }
            if (mCuocGoiKhachHen.ID_DieuHanh  != 0)
            {
                timeHen.Text = string.Format("{0:HH:mm}", mCuocGoiKhachHen.ThoiDiemBatDau);
                dateNgayHen.Text = string.Format("{0:dd/MM/yyyy}", mCuocGoiKhachHen.ThoiDiemBatDau);
                intPhut.TextBox.Text = mCuocGoiKhachHen.BaoTruocSoPhut.ToString();
                editGhiChu.Text = mCuocGoiKhachHen.GhiChu;
                
            }
        }
        /// <summary>
        /// lay du lieu tra form gan vao cho doi tuong mDieuHanhTaxi
        /// </summary>
        private void GetData2Form()
        {
            if (mCuocGoiKhachHen == null) mCuocGoiKhachHen = new CuocGoiKhachHen();
            mCuocGoiKhachHen.ThoiDiemBatDau = DateTime.Parse(timeHen.Text + ":00 " + dateNgayHen.Text);
            mCuocGoiKhachHen.ID_DieuHanh = mDieuHanhTaxi.ID_DieuHanh;
            mCuocGoiKhachHen.BaoTruocSoPhut = intPhut.Value;
            mCuocGoiKhachHen.GhiChu = editGhiChu.Text;
           
        }
      

        private void btnOK_Click(object sender, EventArgs e)
        {

            DateTime ThoiDiemBatDau = DateTime.Parse(timeHen.Text + ":00 " + dateNgayHen.Text);
            if (!(mDieuHanhTaxi.ThoiDiemGoi < ThoiDiemBatDau))
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Bạn phải nhập đúng thời gian khách hẹn.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                return;
            }
 
            this.GetData2Form();

             
            this.DialogResult = DialogResult.OK;

            this.Close();
            }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
     

    }
}