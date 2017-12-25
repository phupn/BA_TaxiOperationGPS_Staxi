using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmBanGiaInputData: Form
    {

        private DieuHanhTaxi mDieuHanhTaxi = new DieuHanhTaxi();
         

        public DieuHanhTaxi GetDieuHanhTaxi
        {
            get {
                  
                return mDieuHanhTaxi; }
            //  set { mDieuHanhTaxi = value; }
        }
        private int gLen = 0;
        public frmBanGiaInputData()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Truyen vao mot doi tuong DieuHanh, tuong duoc mot cuoc goi 
        /// </summary>
        /// <param name="DieuHanhTaxi"></param>
        public frmBanGiaInputData(DieuHanhTaxi DieuHanhTaxi)
        {
            InitializeComponent();
            mDieuHanhTaxi = DieuHanhTaxi;
            

        }
         

        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            
            this.SetData2Form();
            txtVung.Enabled = false;
             
        }
        /// <summary>
        /// Thiet lap gia tri của dư lieu len form
        /// </summary>
        private void SetData2Form()
        {
            if (mDieuHanhTaxi != null)
            {
                // line + phone + time

                lblLinePhoneTime.Text = "[" + mDieuHanhTaxi.Line + "]  " + mDieuHanhTaxi.PhoneNumber + "  " + mDieuHanhTaxi.ThoiDiemGoiGio;
               
                txtDiaChi.Text = mDieuHanhTaxi.DiaChiDonKhach;

                txtNoiDungXuLy.Text = mDieuHanhTaxi.BTBG_NoiDungXuLy;

                int iSoLuong = 0;

                if (mDieuHanhTaxi.SoLuong == "") iSoLuong = 0;
                else iSoLuong = int.Parse(mDieuHanhTaxi.SoLuong);
                string strXeCho;
                if ((iSoLuong == 2) && (mDieuHanhTaxi.LoaiXe.Contains("0")))
                {
                    strXeCho = "1 xe 4 chỗ, 1 xe 7 chỗ";
                }
                else
                {
                    strXeCho = mDieuHanhTaxi.SoLuong;
                    if (mDieuHanhTaxi.LoaiXe.Contains("4")) strXeCho+= " xe, 4 chỗ" ;
                    else if (mDieuHanhTaxi.LoaiXe.Contains("7")) strXeCho += " xe, 7 chỗ";
                    else if (mDieuHanhTaxi.LoaiXe.Contains("0")) strXeCho += " xe, 4 hoặc 7 chỗ";
                } 
            }
        }
        /// <summary>
        /// lay du lieu tra form gan vao cho doi tuong mDieuHanhTaxi
        /// </summary>
        
        private void GetData2Form()
        {
            
        }

        #region Validate du lieu
        /// <summary>
        /// Kiem tra trong cac xe da trung nhau khong
        /// </summary>
        /// <param name="DanhSachTaxi"></param>
        /// <returns></returns>
        private bool CheckTrungLapXeChay(string DanhSachTaxi)
        {
           
                string[] arrTaxi = DanhSachTaxi.Split(".".ToCharArray());
                ////for (int i = 0; i < arrTaxi.Length; i++)
                //// {
                ////     if (arrTaxi[i].Length != 3) { return true; }
                ////}
                for (int i = 0; i < arrTaxi.Length - 1; i++)
                {
                    for (int j = i + 1; j < arrTaxi.Length; j++)
                    {
                 
                        if(arrTaxi[j] == arrTaxi[i]) return true ;
                    }
                }
                return false;
           
        }

        /// <summary>
        /// Check xe cua Taxi Chay co trong Nhung ChieuTaxichay hay khong
        /// </summary>
        /// <param name="NhungXeCoTheChay"></param>
        /// <param name="TaxiChay"></param>
        /// <returns></returns>
        private bool CheckDulieu_XeChay(string NhungXeCoTheChay, string TaxiChay)
        {
            bool boolRet = true;    
            if (TaxiChay.Contains("."))
            {

                string[] arrTaxiChay = TaxiChay.Split(".".ToCharArray());

                for (int i = 0; i < arrTaxiChay.Length; i++)
                {
                    boolRet = boolRet & NhungXeCoTheChay.Contains((string)arrTaxiChay[i]);
                }

                return boolRet;
            }
            else
            {
                return (boolRet & NhungXeCoTheChay.Contains(TaxiChay));
            }
            return false;
        }

        #endregion Validate du lieu 

        /// <summary>
        /// Nhap thong tin va thiet lap trang thai cuoc goi
        /// trang thai lenh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            mDieuHanhTaxi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChi.Text);
            mDieuHanhTaxi.BTBG_NoiDungXuLy = StringTools.TrimSpace(txtNoiDungXuLy.Text);
            mDieuHanhTaxi.BTBG_IsDaXuLy = chkDaXuLy.Checked;
            try
            {
                string Vung = StringTools.TrimSpace(txtVung.Text);
                mDieuHanhTaxi.MaVung = Vung;

            }
            catch (Exception ex)
            {

            }
            this.DialogResult = DialogResult.OK;
            this.Close();     
        }
          
        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel; 
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N))
            {
                
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                 
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L))
            {
                
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.G))
            {
               
                return true;
            }
            else if (keyData == Keys.F5)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if(objT!=null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 1).ShowDialog();
            }
            else if (keyData == Keys.F6)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 2).ShowDialog();
            }
            else if (keyData == Keys.F7)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT,3).ShowDialog();
            }
            else if (keyData == Keys.F8)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 4).ShowDialog();
            }
            else if (keyData == Keys.Enter) // Mo nhap du lieu dong 1
            {
                this.btnOK_Click(null, null);
                if(this.DialogResult!= DialogResult.No)
                    this.DialogResult = DialogResult.OK;
                this.Close(); return true;
            }
            return false;
        }
        #endregion XU LY HOTKEY

         
        private void maskXeNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
 

        private void frmBodamInputData_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void chkDaXuLy_CheckedChanged(object sender, EventArgs e)
        {
            txtVung.Enabled = chkDaXuLy.Checked;
        }

        private void uiTabPage1_Click(object sender, EventArgs e)
        {

        }
         
        
    }
}