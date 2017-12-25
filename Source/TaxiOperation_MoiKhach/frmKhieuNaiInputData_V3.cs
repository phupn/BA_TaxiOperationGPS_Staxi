using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using TaxiOperation_MoiKhach;

namespace Taxi.GUI
{
    public partial class frmKhieuNaiInputData_V3: Form
    {
        private CuocGoi mCuocGoi = new CuocGoi(); 
      
       
        public CuocGoi GetCuocGoi
        {
            get {
                  
                return mCuocGoi; }
            //  set { mCuocGoi = value; }
        }
        private int gLen = 0; 
        /// <summary>
        /// Truyen vao mot doi tuong DieuHanh, tuong duoc mot cuoc goi 
        /// 
        /// </summary>
        /// <param name="CuocGoi"></param>
        public frmKhieuNaiInputData_V3(CuocGoi CuocGoi)
        {
            InitializeComponent();
            mCuocGoi = CuocGoi;
          
        } 
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
             
            this.SetData2Form();
                         
        }

       


        /// <summary>
        /// Thiet lap gia tri của dư lieu len form
        /// </summary>
        private void SetData2Form()
        {
            if (mCuocGoi != null)
            { 
                // line + phone + time 
                lblLinePhoneTime.Text = "[" + mCuocGoi.Line + "]  " + mCuocGoi.PhoneNumber + "  " + mCuocGoi.ThoiDiemGoiGio;
                txtKhieuNai.Text = mCuocGoi.DiaChiDonKhach;            
                chkDaXuLy.Checked = mCuocGoi.MOIKHACH_KhieuNai_DaXyLy;
                txtKetQuaXuLy.Text = mCuocGoi.MOIKHACH_KhieuNai_ThongTinThem;                
            }
        }   
        #region Validate du lieu
        
        #endregion Validate du lieu

          
        


        /// <summary>
        /// Nhap thong tin va thiet lap trang thai cuoc goi
        /// trang thai lenh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!FormValidate())
            {
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                msg.Show(this, "Bạn phải nhập thông tin khiếu nại và kết quả xử lý.","Thông báo",Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Information);
                return;
            }
 
                
            mCuocGoi.MOIKHACH_LenhMoiKhach = "đã xử lý";
            mCuocGoi.MOIKHACH_KhieuNai_DaXyLy = chkDaXuLy.Checked;
            if(chkDaXuLy.Checked)
                 mCuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
            mCuocGoi.MOIKHACH_KhieuNai_ThongTinThem = StringTools.TrimSpace ( txtKetQuaXuLy.Text);
            mCuocGoi.DiaChiDonKhach = StringTools.TrimSpace (  txtKhieuNai .Text);
              
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool FormValidate()
        {
            string strDiaChi = StringTools.TrimSpace(txtKhieuNai.Text);
            string strKetQua = StringTools.TrimSpace(txtKetQuaXuLy.Text);
            if (strDiaChi.Length > 0 && strKetQua.Length > 0) return true;
            return false;

        }
        
      

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            } 
            return false;
        }
        #endregion XU LY HOTKEY
         

        
    

       

         

       
    }
}