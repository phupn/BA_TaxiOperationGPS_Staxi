using System;
using System.Windows.Forms;
using Taxi.Controls.Base.Extender;
using Taxi.Utils;
using System.Data;
using System.ComponentModel;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Business;

namespace TaxiOperation_BanCo.Controls.GiamSatXe
{
    public partial class GiamSatXe_GiamSatXe : UserControl
    {
        #region ======= Ini_Form  =======
        public GiamSatXe_GiamSatXe()
        {
            InitializeComponent();
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            lienlac = new GiamSatXe_LienLac();
            timer_GSX.Enabled = true;
            grvGiamSatXe.IndicatorWidth = 30;
            grcGiamSatXe.DataSource = lienlac.GetGiamSatXeByTrangThai("1").ToDataTableEnVang("SoHieuXe");
            grcGiamSatXe.Update();
        }
        #endregion

        #region ======= Biến toàn cục =======
        private GiamSatXe_LienLac lienlac = null;
        string TrangThai = "";
        public delegate void GiamSatXeEventHandler(object sender, long id, string shx, int sophutnghi, string ghichu, string vitridiembao, int diemdo, string tenlaixe, string malaixe, DateTime thoidiembao);
        public event GiamSatXeEventHandler UpdateData;
        #endregion

        #region ======= Event =======
        private void txtSoHieu_KeyDown(object sender, KeyEventArgs e)
        {
            txtSoHieu.Text = txtSoHieu.Text.TrimStart();

            if (e.KeyData == Keys.Enter)
            {
                btnTimKiem_Click(null, null);
            } else
                lblMsg.Text = ""; 
        }

        private void SetTrangThai() {
            if (rbTatCa.Checked)
            {
                TrangThai = "-1";
            }
            else if (rbHoatDong.Checked)
            {
                TrangThai = "1";
            }
            else if (rbKhaiThac.Checked)
            {
                TrangThai = "10";
            }
            else if (rbChuyenVung.Checked)
            {
                TrangThai = "3";
            }
            else if (rbAnCa.Checked)
            {
                TrangThai = "6";
            }
            else if (rbRoiXe.Checked)
            {
                TrangThai = "7";
            }
            else if (rbMatLienLac.Checked)
            {
                TrangThai = "11";
            }
            else if (rbVe.Checked)
            {
                TrangThai = "0";
            }
        }

        private void rdTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

                int cindex = grvGiamSatXe.FocusedRowHandle;
                int tindex = grvGiamSatXe.TopRowIndex;

                SetTrangThai();
                if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Số xe")
                    grcGiamSatXe.DataSource = lienlac.GetGiamSatXeByTrangThai(TrangThai).ToDataTableEnVang("SoHieuXe");
                else
                    grcGiamSatXe.DataSource = lienlac.GetGiamSatXe(txtSoHieu.Text, TrangThai).ToDataTableEnVang("SoHieuXe");
                grvGiamSatXe.FocusedRowHandle = cindex;
                grvGiamSatXe.TopRowIndex = tindex;
                grcGiamSatXe.Update();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("rdTrangThai_SelectedIndexChanged", ex);
            }
            
           
        }

        public void LoadData()
        {
            rdTrangThai_SelectedIndexChanged(null, null);
        }

        private void grvGiamSatXe_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSoHieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSoHieu.Text = txtSoHieu.Text.Trim();
        }

        private void txtSoHieu_KeyUp(object sender, KeyEventArgs e)
        {
            txtSoHieu.Text = txtSoHieu.Text.TrimStart();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            SetTrangThai();
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text == "Số hiệu")
                grcGiamSatXe.DataSource = lienlac.GetGiamSatXeByTrangThai(TrangThai);
            else
                grcGiamSatXe.DataSource = lienlac.GetGiamSatXe(txtSoHieu.Text, TrangThai);

        }

       

        private void grvGiamSatXe_DoubleClick(object sender, EventArgs e)
        {
            FillData(sender);
        }

        private void grvGiamSatXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                FillData(sender);
            }
            else if(e.KeyData == Keys.Delete)
            {
                RemoveData();
            }
        }

        /// <summary>
        /// Update thong tin xe bao an ca
        /// </summary>
        /// <param name="sender"></param>
        private void FillData(object sender)
        {
            try
            {
                if (grvGiamSatXe.SelectedRowsCount > 0 && UpdateData != null && TrangThai == "6")
                {
                    DataTable objGiamSatXe = grvGiamSatXe.GetFocusedDataRow().Table;
                    if (objGiamSatXe != null)
                    {
                        long id = long.Parse(objGiamSatXe.Rows[0]["Id"].ToString());
                        int sophutnghi = objGiamSatXe.Rows[0]["SoPhutNghi_KB"] == DBNull.Value ? 0 : int.Parse(objGiamSatXe.Rows[0]["SoPhutNghi_KB"].ToString());
                        string ghichu = objGiamSatXe.Rows[0]["GhiChu"].ToString();
                        string vitri = objGiamSatXe.Rows[0]["ViTriDiemBao"].ToString();
                        string shx = objGiamSatXe.Rows[0]["SoHieuXe"].ToString();
                        int diemdo = objGiamSatXe.Rows[0]["DiemDo"] == DBNull.Value ? 0 : int.Parse(objGiamSatXe.Rows[0]["DiemDo"].ToString());
                        string tenlaixe = objGiamSatXe.Rows[0]["TenLaiXe"].ToString();
                        string malaixe = objGiamSatXe.Rows[0]["MaLaiXe"].ToString();
                        DateTime thoidiembao = DateTime.Parse(objGiamSatXe.Rows[0]["ThoiDiemBao"].ToString());
                        UpdateData(sender, id, shx, sophutnghi, ghichu, vitri, diemdo, tenlaixe, malaixe, thoidiembao);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Xoa thong tin xe bao an ca
        /// </summary>
        /// <param name="sender"></param>
        private void RemoveData()
        {
            try
            {
                if (grvGiamSatXe.SelectedRowsCount > 0 && TrangThai == "6")
                {
                    DialogResult question = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (question == DialogResult.Yes)
                    {
                        DataTable objGiamSatXe = grvGiamSatXe.GetFocusedDataRow().Table;
                        if (objGiamSatXe != null)
                        {
                            long id = long.Parse(objGiamSatXe.Rows[0]["Id"].ToString());
                            string shx = objGiamSatXe.Rows[0]["SoHieuXe"].ToString();
                            string malaixe = objGiamSatXe.Rows[0]["MaLaiXe"].ToString();
                            DateTime thoidiembao = DateTime.Parse(objGiamSatXe.Rows[0]["ThoiDiemBao"].ToString());

                            lienlac.GSX_BaoAnCa_XuLy_Delete(thoidiembao, shx, malaixe, Taxi.Business.ThongTinDangNhap.USER_ID, id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa dữ liệu thất bại, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region  =======  Bắt sự kiện bàn phím  =======

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{

        //    switch (keyData)
        //    {
        //        case(Keys.Alt|Keys.A):
        //            rdTrangThai.EditValue =- 1;
        //            break;
        //        case (Keys.Alt | Keys.H):
        //            rdTrangThai.EditValue =(int)Enum_TrangThaiLaiXeBao.BaoRaKinhDoanh;
        //            break;
        //        case (Keys.Alt | Keys.K):
        //            rdTrangThai.EditValue = (int)Enum_TrangThaiLaiXeBao.KhaiThac;
        //            break;
        //        case (Keys.Alt | Keys.C):
        //            rdTrangThai.EditValue = (int)Enum_TrangThaiLaiXeBao.BaoDiemDo;
        //            break;
        //        case (Keys.Alt | Keys.N):
        //            rdTrangThai.EditValue = (int)Enum_TrangThaiLaiXeBao.BaoNghi_AnCa;
        //            break;
        //        case (Keys.Alt | Keys.R):
        //            rdTrangThai.EditValue = (int)Enum_TrangThaiLaiXeBao.BaoNghi_RoiXe;
        //            break;
        //        case (Keys.Alt | Keys.M):
        //            rdTrangThai.EditValue = (int)Enum_TrangThaiLaiXeBao.MatLienLac;
        //            break;
        //        case (Keys.Alt | Keys.V):
        //            rdTrangThai.EditValue = (int)Enum_TrangThaiLaiXeBao.BaoVe;
        //            break;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);

        //}
        #endregion

    }
}
