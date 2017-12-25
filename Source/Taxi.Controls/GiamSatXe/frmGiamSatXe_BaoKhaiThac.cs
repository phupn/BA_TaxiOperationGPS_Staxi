using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.MasterData;

namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_BaoKhaiThac : FormBase
    {
        #region ==== Define ====
        DataTable dulieu;
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        #endregion

        #region ==== Ini =====
        public frmGiamSatXe_BaoKhaiThac()
        {
            InitializeComponent();
        }
        #endregion

        #region ==== Function ====
        private bool ValidateData()
        {
            lblmsg.Text = "";
            if (txtSoHieu.EditValue == null || txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); txtSoHieu.Focus(); return false; }
            if (txtDongHo.Text.Trim() != "")
            {
                if (double.Parse(txtDongHo.Text) >=Double.MaxValue) { lblmsg.Text = "Chỉ số đồng hồ quá lớn"; txtDongHo.Focus(); return false; }
            }
            else { txtDongHo.Text = "0"; }
            if (txtViTri.EditValue==null|| txtViTri.Text.Trim() == "") { lblmsg.Text = "Bạn chưa nhập địa chỉ"; txtViTri.Focus(); return false; }
            if (deGioDi.EditValue == null) { lblmsg.Text = "Bạn chưa nhập Thời điểm"; deGioDi.Focus(); return false; }
            if (deGioDi.DateTime > DateTime.Now) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; deGioDi.Focus(); return false; }
            if (deGioDi.DateTime.Year < 2000) { lblmsg.Text = "Thời điểm không phù hợp"; deGioDi.Focus(); return false; }
          
            return true;
        }
        
        #endregion

        #region ==== Event Form ====

        private void frmGiamSatXe_BaoKhaiThac_Load(object sender, EventArgs e)
        {
            dulieu = lienlac.GSX_BaoRoiXe_GetXe();

            txtSoHieu.Properties.DataSource = dulieu;
            txtSoHieu.Properties.DisplayMember = "SoHieuXe";
            txtSoHieu.Properties.ValueMember = "MaLaiXe";
            txtSoHieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtSoHieu.Properties.Mask.EditMask = @"\d+";
            lVungDieuHanh.Properties.DataSource = new VungDieuHanh().GetTenVungDieuHanh();
            lVungDieuHanh.Properties.DisplayMember = "TenVung";
            lVungDieuHanh.Properties.ValueMember = "Id";
            //lVungDieuHanh.EditValue = null;
            deGioDi.DateTime = Taxi.Business.CommonBL.GetTimeServer();
        }

      
        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (ValidateData())
            {
                if (lVungDieuHanh.EditValue == null || lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng")
                {
                    lienlac.GSX_BaoKhaiThac_XuLy(txtSoHieu.GetColumnValue("SoHieuXe").ToString()
                    , deGioDi.DateTime, txtSoHieu.GetColumnValue("MaLaiXe").ToString(), txtSoHieu.GetColumnValue("TenNhanVien").ToString()
                    , txtViTri.Text, Int64.Parse(txtDongHo.Text), "Xe báo khai thác tại - " + txtViTri.Text, null, "Xe báo khai thác tại - " + txtViTri.Text, Taxi.Business.ThongTinDangNhap.USER_ID, 1, new Guid(), 0);
                }
                else
                {
                    lienlac.GSX_BaoKhaiThac_XuLy(txtSoHieu.GetColumnValue("SoHieuXe").ToString()
                        , deGioDi.DateTime, txtSoHieu.GetColumnValue("MaLaiXe").ToString(), txtSoHieu.GetColumnValue("TenNhanVien").ToString()
                        , txtViTri.Text, Int64.Parse(txtDongHo.Text), "Xe báo khai thác tại - " + txtViTri.Text, lVungDieuHanh.EditValue.ToString(), "Xe báo khai thác tại - " + txtViTri.Text, Taxi.Business.ThongTinDangNhap.USER_ID, 1, new Guid(), 0);
                }
                this.Close();
            }
        }
        #region ------- Event txtSoHieu ----------
        private void txtSoHieu_Leave(object sender, EventArgs e)
        {
            var r = txtSoHieu.GetColumnValue("TenNhanVien");
            if (r!=DBNull.Value&& r != "") lblTenLaiXe.Text = r.ToString();
            else lblTenLaiXe.Text = "";

            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return; }
            else lblmsg.Text = "";
        }

        private void txtSoHieu_EditValueChanged(object sender, EventArgs e)
        {
            var r = txtSoHieu.GetColumnValue("TenNhanVien");
            if (r !=DBNull.Value&& r != "") lblTenLaiXe.Text = r.ToString();
            else lblTenLaiXe.Text = "";
        }
        #endregion
        #endregion
    }
}
