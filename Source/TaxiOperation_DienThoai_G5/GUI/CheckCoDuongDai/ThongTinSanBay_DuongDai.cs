using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.CheckCoDuongDai;

namespace Taxi.GUI
{
    public partial class ThongTinSanBay_DuongDai : Form
    {
        #region declare variable

        private CheckCoDuongDai G_objCheckCo;
        private bool isUpdate = false;
        private string DTLaiXe = string.Empty;
        #endregion       
        
        public ThongTinSanBay_DuongDai(string dtLaiXe)
        {
            InitializeComponent();
            DTLaiXe = dtLaiXe;
        }

        public ThongTinSanBay_DuongDai(List<Province> arrProvince, List<District> arrDistrict, List<Commune> arrCommune, string dtLaiXe)
        {
            InitializeComponent();
            checkCoDuongDai1.G_arrCommune = arrCommune;
            checkCoDuongDai1.G_arrDistrict = arrDistrict;
            checkCoDuongDai1.G_arrProvince = arrProvince;
            DTLaiXe = dtLaiXe;
        }

        public ThongTinSanBay_DuongDai(CheckCoDuongDai objCheckCo, List<Province> arrProvince, List<District> arrDistrict, List<Commune> arrCommune)
        {
            InitializeComponent();
            checkCoDuongDai1.G_arrCommune = arrCommune;
            checkCoDuongDai1.G_arrDistrict = arrDistrict;
            checkCoDuongDai1.G_arrProvince = arrProvince;
            G_objCheckCo = objCheckCo;
            isUpdate = true;
            checkCoDuongDai1.isInsert = false;
        }

        private void ThongTinSanBay_DuongDai_Load(object sender, EventArgs e)
        {
            checkCoDuongDai1.LoadForm(DTLaiXe);
            if (isUpdate)
            {
                checkCoDuongDai1.SetValue(G_objCheckCo);
            }
            checkCoDuongDai1.btnLuuThoat.Click += new EventHandler(btnLuuThoat_Click);
            checkCoDuongDai1.btnThoat.Click += new EventHandler(btnThoat_Click);            
            checkCoDuongDai1.btnDelete.Click += new EventHandler(btnDelete_Click);
        }        

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkCoDuongDai1.isSuccess == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
       }
     
        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        void btnLuuThoat_Click(object sender, EventArgs e)
        {
            if (checkCoDuongDai1.isSuccess == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #region Xử lý hot key

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (checkCoDuongDai1.isSuccess == true)
                {
                    this.DialogResult = DialogResult.OK;                 
                }
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.S))
            {
                checkCoDuongDai1.btnLuuThoat_Click(null, null);
                //if (checkCoDuongDai1.isSuccess == true)
                //{
                //    this.Close();
                //}
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.E))
            {
                checkCoDuongDai1.btnLuuTiep_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.T))
            {
                if (checkCoDuongDai1.isSuccess == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                checkCoDuongDai1.btnDelete_Click(null, null);
                //if (checkCoDuongDai1.isSuccess == true)
                //{
                //    this.Close();
                //}
                return true;
            }
            else if (keyData == Keys.Enter && checkCoDuongDai1.txtGhiChu.Focused)
            {
                checkCoDuongDai1.btnLuuThoat_Click(null, null);
                //if (checkCoDuongDai1.isSuccess == true)
                //{
                //    this.Close();
                //}
                return true;
            }
            //else if(keyData == (Keys.Alt|Keys.S))
            //{
            //    checkCoDuongDai1.txtSoHieuXe.Focus();
            //    return true;
            //}
            //else if (keyData == (Keys.Alt | Keys.D))
            //{
            //    checkCoDuongDai1.txtCoDau.Focus();
            //    return true;
            //}
            //else if (keyData == (Keys.Alt | Keys.C))
            //{
            //    checkCoDuongDai1.txtCoCuoi.Focus();
            //    return true;
            //}
            //else if (keyData == (Keys.Alt | Keys.I))
            //{
            //    checkCoDuongDai1.txtTongTien.Focus();
            //    return true;
            //}
            //else if (keyData == (Keys.Alt | Keys.G))
            //{
            //    checkCoDuongDai1.txtGhiChu.Focus();
            //    return true;
            //}
            return base.ProcessDialogKey(keyData);
        }     

        #endregion
 
    }
}