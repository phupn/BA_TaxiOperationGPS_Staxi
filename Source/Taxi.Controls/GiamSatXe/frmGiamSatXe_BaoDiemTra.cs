using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.MasterData;

namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_BaoDiemTra : FormBase
    {
        #region ==== Define ====
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        DateTime TimeServer;
        #endregion

        #region ==== INI ====
        public frmGiamSatXe_BaoDiemTra()
        {
            InitializeComponent();

            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width)/2, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        #endregion

        #region ==== Function ====
        private bool IsValid()
        {
            lblmsg.Text = "";
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe")
            {
                lblmsg.Text = ("Bạn chưa nhập số xe");
                txtSoHieu.Focus();
                return false;
            }
            if (lblViTri.Text.Length > 50)
            {
                lblmsg.Text = "Vị trí vượt quá ký tự cho phép";
                lblViTri.Focus();
                return false;
            }
            if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng")
            {
                lblmsg.Text = ("Bạn chưa nhập vùng");
                txtSoHieu.Focus();
                return false;
            }
            if (deThoiDiem.EditValue == null)
            {
                lblmsg.Text = "Bạn chưa nhập thời điểm";
                deThoiDiem.Focus();
                return false;

            }
            if (deThoiDiem.DateTime > TimeServer)
            {
                lblmsg.Text = "Thời điểm không quá ngày hiện tại";
                deThoiDiem.Focus();
                return false;
            }
            if (deThoiDiem.DateTime.Year < 2000)
            {
                lblmsg.Text = "Thời điểm không phù hợp";
                deThoiDiem.Focus();
                return false;
            }
            return true;
        }
        private void ThemXeXinDiemDo()
        {
            if (IsValid())
            {
                lienlac.GSX_BaoDiemTra(txtSoHieu.GetColumnValue("SoHieuXe").ToString(),
                                                txtSoHieu.GetColumnValue("MaLaiXe").ToString(),
                                                txtSoHieu.GetColumnValue("TenLaiXe").ToString(),
                                                deThoiDiem.DateTime,
                                               lVungDieuHanh.GetColumnValue("NameVungDH").ToString(),
                                                int.Parse(lVungDieuHanh.GetColumnValue("Id").ToString()),
                                                Taxi.Business.ThongTinDangNhap.USER_ID,
                                                0,
                                                Guid.NewGuid().ToString());

                this.Close();
            }
        }
        #endregion

        #region ==== Event Form ====
        private void frmGiamSatXe_ChuyenVung_XinDiemDo_Load(object sender, EventArgs e)
        {
            TimeServer = Taxi.Business.CommonBL.GetTimeServer();
            txtSoHieu.Properties.DataSource = lienlac.GetListAllXe_ForBaoDiemTra();
            txtSoHieu.Properties.DisplayMember = "SoHieuXe";
            txtSoHieu.Properties.ValueMember = "MaLaiXe";
            txtSoHieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtSoHieu.Properties.Mask.EditMask = @"\d+";
            lVungDieuHanh.Properties.DataSource = new VungDieuHanh().GetTenVungDieuHanh();
            lVungDieuHanh.Properties.DisplayMember = "TenVung";
            lVungDieuHanh.Properties.ValueMember = "Id";

            deThoiDiem.DateTime = TimeServer;
            txtSoHieu.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThemXeXinDiemDo();
        }
        private void txtSoHieu_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return; }
            else lblmsg.Text = "";
        }
        private void txtSoHieu_Leave(object sender, EventArgs e)
        {
            if (txtSoHieu.EditValue != null && txtSoHieu.GetColumnValue("TenLaiXe") != null)
            {
                string r = txtSoHieu.GetColumnValue("TenLaiXe").ToString();
                if (r != "") lblTenLaiXe.Text = r;
                else lblTenLaiXe.Text = "";
            }
        }

        private void txtSoHieu_EditValueChanged(object sender, EventArgs e)
        {            
            string r = txtSoHieu.GetColumnValue("TenLaiXe").ToString();
            if (r != "") lblTenLaiXe.Text = r;
            else lblTenLaiXe.Text = "";

            if (!txtSoHieu.Text.Equals("") && !txtSoHieu.Text.Equals(" "))
            {
                if (!((System.Data.SqlTypes.SqlInt32)(txtSoHieu.GetColumnValue("DiemDo"))).IsNull && txtSoHieu.GetColumnValue("DiemDo").ToString() != "")
                {
                    lblViTri.Text = lienlac.GetDiemDo(txtSoHieu.GetColumnValue("SoHieuXeInt").ToString());
                    string TrangThaiLaiXeBao = lienlac.GetDiemDo(txtSoHieu.GetColumnValue("TrangThaiLaiXeBao").ToString());
                }
                else 
                { 
                    lblViTri.Text = "";
                }
            }
        }

        private void lblViTri_TextChanged(object sender, EventArgs e)
        {
            lblViTri.Text = lblViTri.Text.TrimStart();
            if (lblViTri.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập vị trí"); return; }
            if (lblViTri.Text.Length > 50) { lblmsg.Text = "Vị trí vượt quá ký tự cho phép"; return; }
            else lblmsg.Text = "";
        }

        private void txtSoHieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                txtSoHieu.Text = txtSoHieu.Text.TrimStart();
        }

        private void lVungDieuHanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                lVungDieuHanh.Text = lVungDieuHanh.Text.TrimStart();
        }

        private void lVungDieuHanh_Leave(object sender, EventArgs e)
        {
            if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng") { lblmsg.Text = ("Bạn chưa nhập vùng"); return; }
            else lblmsg.Text = "";
        }

        private void deThoiDiem_Leave(object sender, EventArgs e)
        {
            if (deThoiDiem.DateTime > TimeServer) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; return; }
            else lblmsg.Text = "";
        }

        private void lVungDieuHanh_TextChanged(object sender, EventArgs e)
        {
            if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng") { lblmsg.Text = ("Bạn chưa nhập vùng"); return; }
            else lblmsg.Text = "";
        }

        private void deThoiDiem_TextChanged(object sender, EventArgs e)
        {
            if (deThoiDiem.DateTime > TimeServer) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; return; }
            else lblmsg.Text = "";
        }
        

        private void txtSoHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !txtSoHieu.IsPopupOpen)
                lVungDieuHanh.Focus();
        }

        private void lVungDieuHanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !lVungDieuHanh.IsPopupOpen)
                deThoiDiem.Focus();
        }

        private void deThoiDiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnLuu.Focus();
        }

        private void btnLuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnThoat.Focus();
            }
            else {
                ThemXeXinDiemDo();
            }
        }

        private void btnThoat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                txtSoHieu.Focus();
        }
      

        private void txtSoHieu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            lVungDieuHanh.Focus();
        }

        private void TxtNode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                deThoiDiem.Focus();
        }  
        #endregion
    }
}
