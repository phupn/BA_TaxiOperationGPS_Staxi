using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Common.Attributes;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_BaoRoiXe : FormBase
    {
        #region  ==== Define ====
        DataTable dulieu;
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        DateTime dt;
        private int G_DiemDo_Old;
        #endregion

        #region ==== INI ====
        public frmGiamSatXe_BaoRoiXe()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        #endregion 

        #region ==== Function ====
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  04/09/2015   created
        /// </Modified>
        private void LoadData()
        {
            dulieu = lienlac.GSX_BaoRoiXe_GetXe();//.ToDataTableEnVang("SoHieuXe");

            txtSoHieu.Properties.DataSource = dulieu;
            txtSoHieu.Properties.DisplayMember = "SoHieuXe";
            txtSoHieu.Properties.ValueMember = "MaLaiXe";
            txtSoHieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtSoHieu.Properties.Mask.EditMask = @"\d+";
            txtSoHieu.Focus();
            dt = Taxi.Business.CommonBL.GetTimeServer();
            lblThoiGianBao.Text = dt.ToString("HH:mm:ss dd/MM/yyyy");
            try
            {
                spin_SoPhutNghi.Text = new ConfigurationStatusModel().GetValue(8).ToString();
            }
            catch (Exception ex)
            {
                spin_SoPhutNghi.Text = "15";

            }
        }
        /// <summary>
        /// Refreshes the form.
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  04/09/2015   created
        /// </Modified>
        private void RefreshForm()
        {
            txtSoHieu.Text = "";
            lblViTri.Text = "";
            txtGhiChu.Text = "";
            spin_SoPhutNghi.Text = "";

            LoadData();
            lblTenLaiXe.Text = "";
            lblmsg.Text = "";
        }
        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  04/09/2015   created
        /// </Modified>
        private bool ValidateData()
        {
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); txtSoHieu.Focus(); return false; }
            //if (lblViTri.Text.Trim() == "") { lblmsg.Text = "Bạn chưa nhập vị trí"; lblViTri.Focus(); return; }
            //if (lblViTri.Text.Length > 50) { lblmsg.Text = "Vị trí có quá nhiều ký tự"; lblViTri.Focus(); return; }
            if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; txtGhiChu.Focus(); return false; }
            if (spin_SoPhutNghi.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập số phút nghỉ"); spin_SoPhutNghi.Focus(); return false; }
            //    if (txtGhiChu.Text.Trim() == "") { lblmsg.Text=("Chưa nhập số hiệu"); txtGhiChu.Focus(); return; }
            return true;
        }

        [MethodWithKey(Keys = Keys.Alt | Keys.A)]
        private void Check_AnDiemDo()
        {
            chkAnDiemDo.Checked = !chkAnDiemDo.Checked;
            btnLuu.Focus();
        }
        #endregion

        #region ===== Event Form ====
        private void frmGiamSatXe_BaoRoiXe_Load(object sender, EventArgs e)
        {
            LoadData();
        }        
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                lienlac.GSX_BaoRoiXe_XuLy(chkAnDiemDo.Checked, lblViTri.Text, spin_SoPhutNghi.EditValue
            , txtGhiChu.Text, dt, txtSoHieu.GetColumnValue("SoHieuXe").ToString(), txtSoHieu.GetColumnValue("MaLaiXe").ToString()
            , txtSoHieu.GetColumnValue("TenNhanVien").ToString(), "Rời xe " + spin_SoPhutNghi.Text + " phút", Taxi.Business.ThongTinDangNhap.USER_ID, new Guid(), 0, G_DiemDo_Old);

                RefreshForm();

                lblmsg.Text = "Cập nhật thành công";
                lblmsg.ForeColor = Color.Blue;
                //this.Close();
            }
        }
        private void txtSoHieu_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return; }
            else lblmsg.Text = "";
        }
        
        private void txtSoHieu_Leave(object sender, EventArgs e)
        {
            string r = (string)txtSoHieu.GetColumnValue("TenNhanVien");
            if (r != "") lblTenLaiXe.Text = r;
            else lblTenLaiXe.Text = "";

            //if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return; }
            //else lblmsg.Text = "";
        }

        private void txtSoHieu_EditValueChanged(object sender, EventArgs e)
        {
            var r = txtSoHieu.GetColumnValue("TenNhanVien");
            if (r!=DBNull.Value&& r != "")
            {
                lblTenLaiXe.Text = r.ToString();
                lblViTri.Text = lienlac.GetDiemDo(txtSoHieu.GetColumnValue("SoHieuXe").ToString());
                G_DiemDo_Old = txtSoHieu.GetColumnValue("DiemDo") == null ? 0 :  (int)(txtSoHieu.GetColumnValue("DiemDo"));
            }
            else { 
                lblTenLaiXe.Text = ""; 
            }
        }

        private void txtSoHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !txtSoHieu.IsPopupOpen) {
                txtGhiChu.Focus();
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) {
                spin_SoPhutNghi.Focus();
            }
        }

        private void txtSoPhutNghi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                chkAnDiemDo.Focus();
            }
        }

        private void btnLuu_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //{
            //    btnThoat.Focus();
            //}
        }

        private void btnThoat_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //{
            //    txtSoHieu.Focus();
            //}
        }

        private void txtSoHieu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (txtSoHieu.EditValue == null)
            {
                lblmsg.Text = "Số hiệu xe không tồn tại";
                txtSoHieu.Focus();
            }
            else
            {
                txtGhiChu.Focus();
            }
        }

        private void chkAnDiemDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }
        #endregion
    }
}
