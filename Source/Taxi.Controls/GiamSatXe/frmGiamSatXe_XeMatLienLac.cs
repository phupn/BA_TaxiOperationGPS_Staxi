using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.MasterData;
using Taxi.Common.Extender;
namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_XeMatLienLac : FormBase
    {
        #region ==== Define ====
        DataTable dulieu;
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        DateTime TimeServer;
        #endregion

        #region ==== INI ====
        public frmGiamSatXe_XeMatLienLac()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        #endregion

        #region ==== Function ====

        private bool ValidateData()
        {
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); txtSoHieu.Focus(); return false; }
            if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng") { lblmsg.Text = ("Bạn chưa nhập vùng"); lVungDieuHanh.Focus(); return false; }
            if (deThoiDiem.Text.Length <= 0) { lblmsg.Text = "Bạn chưa nhập thời điểm"; deThoiDiem.Focus(); return false; }
            if (deThoiDiem.EditValue == null) { lblmsg.Text = "Bạn chưa nhập Thời điểm"; deThoiDiem.Focus(); return false; }
            if (deThoiDiem.DateTime > DateTime.Now) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; deThoiDiem.Focus(); return false; }
            if (deThoiDiem.DateTime.Year < 2000) { lblmsg.Text = "Thời điểm không phù hợp"; deThoiDiem.Focus(); return false; }
            return true;
        }
        #endregion

        #region ==== Event Form ====
        private void frmGiamSatXe_XeMatLienLac_Load(object sender, EventArgs e)
        {
            TimeServer = Taxi.Business.CommonBL.GetTimeServer();
            dulieu = lienlac.GSX_BaoRoiXe_GetXe();//.ToDataTableEnVang("SoHieuXe");
            // load số hiệu xe
            txtSoHieu.Properties.DataSource = dulieu;
            txtSoHieu.Properties.DisplayMember = "SoHieuXe";
            txtSoHieu.Properties.ValueMember = "MaLaiXe";
            txtSoHieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtSoHieu.Properties.Mask.EditMask = @"\d+";
            //load điểm đỗ
            lVungDieuHanh.Properties.DataSource = new VungDieuHanh().GetTenVungDieuHanh();
            lVungDieuHanh.Properties.DisplayMember = "TenVung";
            lVungDieuHanh.Properties.ValueMember = "Id";

            txtSoHieu.Focus();
            deThoiDiem.DateTime = TimeServer;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                string GhiChu = string.Format(" [Mất LL lúc {0:HH:mm} tại {1}", deThoiDiem.DateTime, lVungDieuHanh.Text);
                lienlac.GSX_BaoMatLienLac_XuLy(deThoiDiem.DateTime, txtSoHieu.GetColumnValue("SoHieuXe").To<string>(), txtSoHieu.GetColumnValue("TenNhanVien").To<string>(), txtSoHieu.GetColumnValue("MaLaiXe").To<string>()
                , txtGhiChu.Text + GhiChu, new Guid(), Taxi.Business.ThongTinDangNhap.USER_ID, 0, lVungDieuHanh.EditValue);
                this.Close();
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
            lblTenLaiXe.Text = txtSoHieu.GetColumnValue("TenNhanVien").To<string>();
            lVungDieuHanh.Text = "";
            lVungDieuHanh.SelectedText = lienlac.GetDiemDo(txtSoHieu.GetColumnValue("SoHieuXe").To<string>());
            lVungDieuHanh.ClosePopup();
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            txtGhiChu.Text = txtGhiChu.Text.TrimStart();
            if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; return; }
            else lblmsg.Text = "";
        }

        private void txtSoHieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                txtSoHieu.Text = txtSoHieu.Text.TrimStart();
            //if (e.KeyChar != '\t')
            //    lblTenLaiXe.Text = "";
        }

        private void deThoiDiem_Leave(object sender, EventArgs e)
        {
            if (deThoiDiem.DateTime > DateTime.Now) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; return; }
            else { lblmsg.Text = ""; }
        }

        private void txtGhiChu_Leave(object sender, EventArgs e)
        {
            if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; return; }
            else lblmsg.Text = "";
        }

        private void deThoiDiem_TextChanged(object sender, EventArgs e)
        {
            if (deThoiDiem.DateTime > DateTime.Now) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; return; }
            else { lblmsg.Text = ""; }
        }
        

        private void txtSoHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !txtSoHieu.IsPopupOpen)
            {
                lVungDieuHanh.Focus();
            }
        }

        private void lVungDieuHanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !lVungDieuHanh.IsPopupOpen)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                deThoiDiem.Focus();
            }
        }

        private void deThoiDiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !deThoiDiem.IsPopupOpen)
            {
                btnLuu.Focus();
            }
        }

        private void txtSoHieu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            txtGhiChu.Focus();
        }
        #endregion
    }
}
