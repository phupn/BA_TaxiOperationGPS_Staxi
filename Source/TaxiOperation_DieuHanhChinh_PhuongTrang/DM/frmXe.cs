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
    public partial class frmXe : Form
    {

        DataTable G_LoaiXe = new DataTable();
        DataTable G_Gara = new DataTable();
        private Xe mXe;
        private bool mIsAdd = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }
        }

        public frmXe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        /// <param name="DoiTac"></param>
        /// <param name="boolAdd"></param>
        public frmXe(Xe Xe, bool boolAdd, DataTable LoaiXe, DataTable Gara)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới xe";
            }
            else
            {
                this.Text = "Sửa đổi thông tin xe";
                editSoHieuXe.Enabled = false;
            }
            mXe = Xe;
            G_LoaiXe = LoaiXe;
            G_Gara = Gara;
        }

        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            LoadDSGara();
            LoadLoaiXe();
            cboGara.SelectedIndex = 0;

            SetXe(mXe);
            if (mIsAdd)
            {
                cboGara.SelectedIndex = 0;
            }
        }

        private void LoadLoaiXe()
        {
            cbLoaiXe.DisplayMember = "TenLoaiXe_SoCho";
            cbLoaiXe.ValueMember = "LoaiXeID";
            cbLoaiXe.DataSource = G_LoaiXe;
        }

        private void LoadDSGara()
        {
            cboGara.DisplayMember = "Name";
            cboGara.ValueMember = "ID";
            cboGara.DataSource = G_Gara;
        }

        private void SetXe(Xe Xe)
        {
            editSoHieuXe.Text = Xe.SoHieuXe;
            editBienKiemSoat.Text = Xe.BienKiemSoat;
            editSoMay.Text = Xe.SoMay;
            editSoKhung.Text = Xe.SoKhung;
            cbLoaiXe.SelectedValue = Xe.LoaiXeID;
            cboGara.SelectedValue = Xe.GaraID;
        }

        public Xe GetXe()
        {
            mXe.SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);
            mXe.BienKiemSoat = StringTools.TrimSpace(editBienKiemSoat.Text);
            mXe.SoMay = StringTools.TrimSpace(editSoMay.Text);
            mXe.SoKhung = StringTools.TrimSpace(editSoKhung.Text);
            mXe.LoaiXe = cbLoaiXe.SelectedItem.Text;
            mXe.GaraID = int.Parse(cboGara.SelectedValue.ToString());
            mXe.LoaiXeID = int.Parse(cbLoaiXe.SelectedValue.ToString());
            return mXe;
        }

        #region Validate du lieu

        private void editSoHieuXe_TextChanged(object sender, EventArgs e)
        {

        }
        private void editSoHieuXe_Validating(object sender, CancelEventArgs e)
        {
            if (StringTools.TrimSpace(editSoHieuXe.Text).Length < 2)
            {
                e.Cancel = true;
                errorProvider.SetError(editSoHieuXe, "Số hiệu xe có độ dài > 1");
            }
            else
            {
                if (Xe.KiemTraTonTaiCuaSoHieuXe(editSoHieuXe.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(editSoHieuXe, "Số hiệu xe này đã tồn tại");
                    return;
                }


                e.Cancel = false;
                errorProvider.SetError(editSoHieuXe, "");
            }

        }
        //private void editName_TextChanged(object sender, EventArgs e)
        //{
        //    if (StringTools.TrimSpace(editBienKiemSoat.Text).Length <= 0)
        //        errorProvider.SetError(editBienKiemSoat, "Trường tin Tên nhân viên bắt buộc phải nhập");
        //    else
        //        errorProvider.SetError(editBienKiemSoat, "");
        //}
        //private void editName_Leave(object sender, EventArgs e)
        //{
        //    if (StringTools.TrimSpace(editBienKiemSoat.Text).Length <= 0)
        //        errorProvider.SetError(editBienKiemSoat, "Trường tin Tên nhân viên bắt buộc phải nhập");
        //    else
        //        errorProvider.SetError(editBienKiemSoat, "");
        //}      
        #endregion Validate du lieu

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StringTools.TrimSpace(editSoHieuXe.Text).Length == 3)
            {
                errorProvider.SetError(editSoHieuXe, "Trường tin số hiệu xe bắt buộc phải nhập");
                editSoHieuXe.Focus();
                e.Cancel = true;

            }
        }

        private void editSoHieuXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void uiTab1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadDSLaiXe()
        {
            NhanVien objNhanVien = new NhanVien();
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            lstNhanVien = objNhanVien.GetListNhanViens();
            listDanhSachLaiXe.DataSource = lstNhanVien;
        }

        private void uiTab1_ChangingSelectedTab(object sender, Janus.Windows.UI.Tab.TabCancelEventArgs e)
        {
            if (e.Page.Name == "tabThongTinLaiXe")
            {
                LoadDSLaiXe();
            }
        }
    }
}