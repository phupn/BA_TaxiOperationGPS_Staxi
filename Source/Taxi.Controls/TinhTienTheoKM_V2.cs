using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base.Common;
using Taxi.Utils;

namespace Taxi.Controls
{
    public partial class TinhTienTheoKM_V2 : UserControl
    {
        private bool _isFirstLoad = false;
        public bool SelectItemLoaiXeFirst { get; set; }
        public bool NoneItemAll { get; set; }

        public float G_TongTienChieuDi = 0;
        public float G_TongTienChieuVe = 0;
        public TinhTienTheoKM_V2()
        {
            InitializeComponent();
            cbLoaiXe.NoneItemAll = NoneItemAll;
        }

        #region Events!
        private void TinhTienTheoKM_V2_Load(object sender, EventArgs e)
        {
            try
            {
                _isFirstLoad = true;
                if (!this.DesignMode)
                {
                    chkDiaDanh.Checked = false;
                    cboDiaDanh.Enabled = false;
                    ResetLabel();
                    LoadDiaDanh();
                }
                DisplayInfo();
                if (SelectItemLoaiXeFirst)
                {
                    cbLoaiXe.SelectItemFirst = true;
                }

                _isFirstLoad = false;
                editKm.Text = "0";
                editKm.Focus();
                editKm.SelectAll();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TinhTienTheoKM_V2_Load: ", ex);                
            }
        }
        private void DisplayInfo()
        {
            try
            {
                string strLoaiXe = ctrl_LoaiXe_Combobox.LoaiXeID.ToString();
                if (!string.IsNullOrEmpty(strLoaiXe))
                {
                    TinhTienTheoKm objTien = new TinhTienTheoKm(Convert.ToInt16(strLoaiXe), 1);
                    ResetLabel();
                    GetMessaage(objTien);
                    this.Calculator();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DisplayInfo: ", ex);                
            }
        }
        private void btnThoai_Click(object sender, EventArgs e)
        {
            var topLevel = (Form)this.TopLevelControl;
            if (topLevel != null)
                topLevel.Close();
        }
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            Calculator();
        }
        private void cboDiaDanh_SelectedValueChanged(object sender, EventArgs e)
        {
            if(_isFirstLoad)return;            
            if (cboDiaDanh.SelectedItem != null)
            {
                editKm.Text = ((DataRowView)cboDiaDanh.SelectedItem).Row["Km"].ToString();
                this.Calculator();
            }
        }
        private void cbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayInfo();
        }
        private void cbkTongKM_CheckedChanged(object sender, EventArgs e)
        {
            this.Calculator();
        }
        private void chkDiaDanh_CheckedChanged(object sender, EventArgs e)
        {
            cboDiaDanh.Enabled = chkDiaDanh.Checked;
        }

        #endregion

        #region Methods
        public void FocusLoaiXe()
        {
            cbLoaiXe.Focus();
        }
        public void TinhTienTheoKM_V2_Custom()
        {
            this.editKm.Properties.DisplayFormat.FormatString = "0.0";
            this.editKm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKm.Properties.EditFormat.FormatString = "0.0";
            this.editKm.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKm.Properties.Mask.EditMask = "0.0";
        }
        public void Calculate(double km)
        {
            //cbLoaiXe.SetValue(loaixe);
            editKm.EditValue = km;
            Calculator();
        }

        private void ResetLabel()
        {
            lblMessage1.Text = "";
            lblMessage2.Text = "";
            lblMessage3.Text = "";
            lblMessage4.Text = "";
            cv_lblMsg1.Text = "";
            cv_lblMsg2.Text = "";
        }

        private void GetMessaage(TinhTienTheoKm pTien)
        {
            if(pTien.GiaMoCua>0)
                lblMessage1.Text = string.Format("{0:0.0} Km đầu tiên : {1:0,0} VND", pTien.KmMoCua, pTien.GiaMoCua);
            if (pTien.GiaNguong1>0)
                lblMessage2.Text = string.Format("Từ {0:0.0} --> {1:0,0}Km : {2:0,0} VND", pTien.KmMoCua, pTien.KmNguong1, pTien.GiaNguong1);
            if (pTien.KmNguong2 > 0)
            {
                if (pTien.GiaNguong2 > 0)
                    lblMessage3.Text = string.Format("Từ {0:0.0} --> {1:0,0}Km : {2:0,0} VND", pTien.KmNguong1 + 1, pTien.KmNguong2, pTien.GiaNguong2);
            }
            else
            {
                if (pTien.GiaNguong2 > 0)
                    lblMessage3.Text = string.Format("Từ {0:0.0}Km trở đi : {1:0,0} VND", pTien.KmNguong1 + 1, pTien.GiaNguong2);
            }

            if (pTien.KmNguong3 > 0)
            {
                if (pTien.GiaNguong3 > 0)
                    lblMessage4.Text = string.Format("Từ {0:0,0} --> {1:0,0}Km : {2:0,0} VND", pTien.KmNguong2 + 1, pTien.KmNguong3, pTien.GiaNguong3);
            }
            else
            {
                if (pTien.GiaNguong3 > 0)
                    lblMessage4.Text = string.Format("Từ {0:0,0} trở đi : {1:0,0} VND", pTien.KmNguong2 + 1, pTien.GiaNguong3);
            }
            //lblMessage5.Text = "Khách đi 2 chiều mà lớn hơn bằng " + string.Format("{0:0,0}", TinhTien.KmNguong2Chieu) + " Km, chiều về bằng " + string.Format("{0:0,0}", 100 - TinhTien.TiLeGiamGia2Chieu) + "% chiều đi";
            if (pTien.N1_Giam > 0)
            {
                cv_lblMsg1.Text = string.Format("Chiều đi từ {0:0.0} --> {1:0,0} : {2:0,0} %", pTien.N1_ChieuDiTu, pTien.N1_ChieuDiDen, pTien.N1_Giam);
            }
            else
            {
                cv_lblMsg1.Text = "";
            }
            if (pTien.IsAll)
            {
                if(pTien.N2_Giam>0)
                    cv_lblMsg2.Text = string.Format("Chiều đi > {0:0.0} : giảm {1:0,0} %", pTien.N2_ChieuDiTu, pTien.N2_Giam);
            }
            else
            {
                if(pTien.N2_Giam>0)
                    cv_lblMsg2.Text = string.Format("Chiều đi > {0:0.0} : giảm {1:0,0} % của phần vượt", pTien.N1_ChieuDiTu, pTien.N2_Giam);
            }

            txtThongTinThueBao.Text = pTien.ThongTinThueBao;
        }

        private void Calculator()
        {
            if (license.idxCompany == CompanyCode.SaoHaNoi || license.idxCompany == CompanyCode.SongNhue)
            {
                TinhTienTheoSaoHaNoi();
            }
            else
            {
                TinhTienBinhThuong();
            }
            editKm.Focus();
            editKm.SelectAll();
        }

        private void TinhTienBinhThuong()
        {
            try
            {
                //cbkHaiChieu.Visible = false;
                if (editKm.Text.Length <= 0) return;
                float SoKm = float.Parse(editKm.Text);
                float SoKm2Chieu = SoKm * 2;
                int LoaiXe = 0;
                string strLoaiXe = ctrl_LoaiXe_Combobox.LoaiXeID.ToString();
                if (!string.IsNullOrEmpty(strLoaiXe))
                {
                    LoaiXe = Convert.ToInt16(ctrl_LoaiXe_Combobox.LoaiXeID.ToString());
                }
                TinhTienTheoKm objTinhTien = new TinhTienTheoKm(LoaiXe, SoKm);


                List<TinhTien_SuDungXe> lstTinhTien_TG = new TinhTien_SuDungXe().GetTinhTien_SuDungXe(LoaiXe);
                if (lstTinhTien_TG.Count > 0)
                {
                    TinhTien_SuDungXe objTinhTien_SuDungXe = lstTinhTien_TG.Find(T => T.Km_Tu <= SoKm2Chieu && T.Km_Den > SoKm2Chieu);
                    if (objTinhTien_SuDungXe != null)
                    {
                        editTGSuDungXe.Text = string.Format("{0} giờ", objTinhTien_SuDungXe.TG);
                    }
                    else
                    {
                        editTGSuDungXe.Text = "0 giờ";
                    }
                }
                if (!cbkHaiChieu.Checked)
                {
                    SoKm2Chieu = SoKm;
                    objTinhTien.TongTien2Chieu = 0;
                }
                G_TongTienChieuDi = objTinhTien.TongTien1Chieu;
                G_TongTienChieuVe = objTinhTien.TongTien2Chieu;

                editTienChieuDi.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu);
                editTienChieuVe.Text = string.Format("{0:0,0}", objTinhTien.TongTien2Chieu);
                editTongTien.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu + objTinhTien.TongTien2Chieu);
                lblTongTien.Text = "Tổng tiền (" + SoKm2Chieu + " Km)";

            }
            catch (Exception ex)
            {
                editKm.Focus(); 
                editTienChieuDi.Text = string.Format("{0:0,0}", 0);
                editTienChieuVe.Text = string.Format("{0:0,0}", 0);
                editTongTien.Text = string.Format("{0:0,0}", 0);
                lblTongTien.Text = "Tổng tiền (" + 0 + " Km)";

                G_TongTienChieuDi = 0;
                G_TongTienChieuVe = 0;
            }
        }

        /// <summary>
        /// Yêu cầu riêng của Sao Hà Nội!
        /// </summary>
        private void TinhTienTheoSaoHaNoi()
        {
            try
            {
                if (editKm.Text.Length <= 0) return;
                float SoKm = float.Parse(editKm.Text);
                float SoKm2Chieu = SoKm * 2;
                int LoaiXe = 0;
                string strLoaiXe = ctrl_LoaiXe_Combobox.LoaiXeID.ToString();
                if (!string.IsNullOrEmpty(strLoaiXe))
                {
                    LoaiXe = Convert.ToInt16(ctrl_LoaiXe_Combobox.LoaiXeID.ToString());
                }
                TinhTienTheoKm objTinhTien = new TinhTienTheoKm(LoaiXe, SoKm, cbkHaiChieu.Checked);
                List<TinhTien_SuDungXe> lstTinhTien_TG = new TinhTien_SuDungXe().GetTinhTien_SuDungXe(LoaiXe);
                if (cbkHaiChieu.Checked)
                {
                    SoKm2Chieu = SoKm;
                }
                if (lstTinhTien_TG.Count > 0)
                {
                    TinhTien_SuDungXe objTinhTien_SuDungXe = lstTinhTien_TG.Find(T => T.Km_Tu <= SoKm2Chieu && T.Km_Den > SoKm2Chieu);
                    if (objTinhTien_SuDungXe != null)
                    {
                        editTGSuDungXe.Text = string.Format("{0} giờ", objTinhTien_SuDungXe.TG);
                    }
                    else
                    {
                        editTGSuDungXe.Text = "0 giờ";
                    }
                }
                if (!cbkHaiChieu.Checked)
                    objTinhTien.TongTien2Chieu = 0;

                G_TongTienChieuDi = objTinhTien.TongTien1Chieu;
                G_TongTienChieuVe = objTinhTien.TongTien2Chieu;

                editTienChieuDi.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu);
                editTienChieuVe.Text = string.Format("{0:0,0}", objTinhTien.TongTien2Chieu);
                editTongTien.Text = string.Format("{0:0,0}", objTinhTien.TongTien1Chieu + objTinhTien.TongTien2Chieu);
                lblTongTien.Text = string.Format("Tổng tiền ({0} Km)", SoKm2Chieu);
            }
            catch (Exception ex)
            {
                editKm.Focus();
                editTienChieuDi.Text = string.Format("{0:0,0}", 0);
                editTienChieuVe.Text = string.Format("{0:0,0}", 0);
                editTongTien.Text = string.Format("{0:0,0}", 0);
                lblTongTien.Text = "Tổng tiền (" + 0 + " Km)";

                G_TongTienChieuDi = 0;
                G_TongTienChieuVe = 0;
            }
        }

        private void LoadDiaDanh()
        {
            cboDiaDanh.DisplayMember = "TenDiaDanh";
            cboDiaDanh.ValueMember = "ID";
            cboDiaDanh.DataSource = TinhTienTheoKm.GetAllDiaDanh();
        }

        #endregion

        #region Xử lý hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                var topLevel = (Form)this.TopLevelControl;
                if (topLevel != null) 
                    topLevel.Close();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.N))
            {
                btnTinhTien_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.T))
            {
                var topLevel = (Form)this.TopLevelControl;
                if (topLevel != null) topLevel.Close();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.K))
            {
                editKm.Focus();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.H))
            {
                cbkHaiChieu.Checked = true;
                editKm.Focus();
                return true;
            }
            if (keyData == Keys.Enter || keyData == Keys.Tab)
            {
                Calculator();
            }
            return false;
        }

        #endregion
    }
}
