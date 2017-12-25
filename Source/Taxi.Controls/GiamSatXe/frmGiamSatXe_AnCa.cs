using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Extender;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_AnCa : FormBase
    {
        #region ==== Define =====
        DataTable dulieu;
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        DateTime dt;
        private long ID { set; get; }
        private string SoHieuXe { set; get; }
        private string MaLaiXe { set; get; }
        private string TenLaiXe { set; get; }
        private int DiemDo { set; get; }
        private int SoPhutNghi { set; get; }
        private string GhiChu { set; get; }
        private string ViTriDiemBao { set; get; }
        private DateTime ThoiDiemBao { set; get; }
        #endregion

        #region ==== INI =====
        public frmGiamSatXe_AnCa()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }

        /// <summary>
        /// Cap nhat lai du lieu xe bao an ca
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shx"></param>
        /// <param name="sophutnghi"></param>
        /// <param name="ghichu"></param>
        /// <param name="vitridiembao"></param>
        /// <param name="diemdo"></param>
        /// <param name="tenlaixe"></param>
        /// <param name="malaixe"></param>
        /// <param name="thoidiembao"></param>
        public frmGiamSatXe_AnCa(long id, string shx, int sophutnghi, string ghichu, string vitridiembao, int diemdo, string tenlaixe, string malaixe, DateTime thoidiembao)
        {
            InitializeComponent();
            ID = id;
            SoHieuXe = shx;
            SoPhutNghi = sophutnghi;
            GhiChu = ghichu;
            ViTriDiemBao = vitridiembao;
            TenLaiXe = tenlaixe;
            MaLaiXe = malaixe;
            DiemDo = diemdo;
            ThoiDiemBao = thoidiembao;
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        #endregion

        #region ==== Function ====
        private bool ValidateData()
        {
            lblmsg.Text = "";

            if (txtSoHieu.EditValue==null || txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); txtSoHieu.Focus(); return false; }
            if (lblViTri.Text.Trim() == "") { lblmsg.Text = "Bạn chưa nhập vị trí"; lblViTri.Focus(); return false; }
            if (lblViTri.Text.Length > 50) { lblmsg.Text = "Vị trí có quá nhiều ký tự"; lblViTri.Focus(); return false; }
            if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; txtGhiChu.Focus(); return false; }
            if (spin_SoPhutNghi.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập số phút nghỉ"); spin_SoPhutNghi.Focus(); return false; }
            
            return true;
        }
        #endregion

        #region ==== Event From ====

        private void frmGiamSatXe_AnCa_Load(object sender, EventArgs e)
        {
            dulieu = lienlac.GSX_BaoRoiXe_GetXe();//.ToDataTableEnVang("SoHieuXe");
            if (ID > 0)
            {
                DataRow row = dulieu.NewRow();
                row["SoHieuXe"] = SoHieuXe;
                row["MaLaiXe"] = MaLaiXe;
                row["DiemDo"] = DiemDo;
                row["TenNhanVien"] = TenLaiXe;
                dulieu.Rows.InsertAt(row, 0);
            }
            txtSoHieu.Properties.DataSource = dulieu;
            txtSoHieu.Properties.DisplayMember = "SoHieuXe";
            txtSoHieu.Properties.ValueMember = "MaLaiXe";

            txtSoHieu.Focus();

            if (ID == 0)
            {
                dt = Taxi.Business.CommonBL.GetTimeServer();
                lblThoiGianBao.Text = dt.ToString("HH:mm:ss dd/MM/yyyy");
                try
                {
                    spin_SoPhutNghi.Text = new ConfigurationStatusModel().GetValue(7).ToString();
                }
                catch (Exception ex)
                {
                    spin_SoPhutNghi.Text = "15";
                }
            }
            else
            {
                txtSoHieu.Text = SoHieuXe;
                txtGhiChu.Text = GhiChu;
                lblViTri.Text = ViTriDiemBao;
                spin_SoPhutNghi.Value = SoPhutNghi;
                lblThoiGianBao.Text = ThoiDiemBao.ToString("HH:mm:ss dd/MM/yyyy");
            }
            txtSoHieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtSoHieu.Properties.Mask.EditMask = @"\d+";
        }

      

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (ID == null || ID == 0)
            {
                lienlac.GSX_BaoAnCa_XuLy(dt, txtSoHieu.GetColumnValue("SoHieuXe").ToString(), txtSoHieu.GetColumnValue("MaLaiXe").ToString()
                    , txtSoHieu.GetColumnValue("TenNhanVien").ToString(), lblViTri.Text, spin_SoPhutNghi.EditValue, txtGhiChu.Text, "Ăn ca " + spin_SoPhutNghi.Text + " phút"
                    , Taxi.Business.ThongTinDangNhap.USER_ID, 0, new Guid());
            }
            else
            {
                lienlac.GSX_BaoAnCa_XuLyUpdate(ThoiDiemBao, txtSoHieu.GetColumnValue("SoHieuXe").ToString(), txtSoHieu.GetColumnValue("MaLaiXe").ToString()
                       , txtSoHieu.GetColumnValue("TenNhanVien").ToString(), lblViTri.Text, spin_SoPhutNghi.EditValue, txtGhiChu.Text, "Ăn ca " + spin_SoPhutNghi.Text + " phút"
                       , Taxi.Business.ThongTinDangNhap.USER_ID,ID);                
            }
            this.Close();
        }

        private void txtSoHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !txtSoHieu.IsPopupOpen)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                spin_SoPhutNghi.Focus();
            }
        }

        private void txtSoPhutNghi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLuu.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                e.Handled = true;
                txtGhiChu.Focus();
            }
            else if (e.KeyData == Keys.Down)
            {
                e.Handled = true;
                btnLuu.Focus();
            }
        }

        private void txtSoHieu_EditValueChanged(object sender, EventArgs e)
        {
            string r = (string)txtSoHieu.GetColumnValue("TenNhanVien");
            if (r != "")
            {
                lblTenLaiXe.Text = r;
                lblViTri.Text = lienlac.GetDiemDo(txtSoHieu.GetColumnValue("SoHieuXe").ToString());
            }
            else
            {
                lblTenLaiXe.Text = "";
            }
        }
        #endregion


    }
}
