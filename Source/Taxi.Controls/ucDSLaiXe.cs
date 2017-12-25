using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.DM;
using DevExpress.Data.Filtering;

namespace Taxi.Controls
{
    public partial class ucDSLaiXe : UserControlBase
    {
        #region  === delegate,event===
        public delegate void CallOut(string PhoneNumber, string DiaChi);
        public event CallOut EventCallOut;
        #endregion

        #region===Properties===
        private List<T_NHANVIEN> _lstNhanVien;
        #endregion

        #region=== Form===
        public ucDSLaiXe()
        {
            InitializeComponent();
        }
        private void ucDSLaiXe_Load(object sender, EventArgs e)
        {
            txtSoHieuXe.Focus();
            lblMsg.Text = string.Empty;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //gọi cho lái xe
            if (grcDanhSachLaiXe.IsFocused && keyData == Keys.Space)
            {
                if (grvDanhSachLaiXe.RowCount > 0)
                {
                    T_NHANVIEN nv = grvDanhSachLaiXe.GetFocusedRow() as T_NHANVIEN;
                    if (!string.IsNullOrEmpty(nv.DiDong))
                    {
                        HienThiFormGoiDienThoai(nv.DiDong, nv.TenNhanVien);
                    }
                    else
                    {
                        lblMsg.Text = "Số di động của lái xe đang bị trống.";
                    }
                    return true;
                }
            }

            if (keyData == Keys.Enter)
            {
                btnTimKiem.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string thongTinTimKiem = "(1=1)";
            if (!string.IsNullOrEmpty(txtSoHieuXe.Text.Trim()))
            {
                thongTinTimKiem += string.Format(" and [FK_SoHieuXeLai] like '%{0}%'", txtSoHieuXe.Text.Replace("'", "''"));
            }
            if (!string.IsNullOrEmpty(txtTheLaiXe.Text.Trim()))
            {
                thongTinTimKiem += string.Format(" and [SoTheLaiXe] like '%{0}%'", txtTheLaiXe.Text.Replace("'", "''"));
            }
            if (!string.IsNullOrEmpty(txtDiDong.Text.Trim()))
            {
                thongTinTimKiem += string.Format(" and [DiDong] like '%{0}%'", txtDiDong.Text.Replace("'", "''"));
            }
            grvDanhSachLaiXe.ActiveFilterCriteria = CriteriaOperator.Parse(thongTinTimKiem);
        }

        #endregion

        #region===Method===

        /// <summary>
        /// hàm hiển thị thông tin form gọi điện
        /// </summary>
        public void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi)
        {
            try
            {
                if (EventCallOut != null)
                {
                    EventCallOut(PhoneNumber, DiaChi);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ucDSLaiXe.HienThiFormGoiDienThoai", ex);
            }
        }
        public void SetListNhanVien(IEnumerable<T_NHANVIEN> lstNhanVien)
        {
            txtSoHieuXe.Text = string.Empty;
            txtTheLaiXe.Text = string.Empty;
            txtDiDong.Text = string.Empty;
            this._lstNhanVien = lstNhanVien.OrderBy(a=>a.SoHieuXe).ToList();
            grcDanhSachLaiXe.DataSource = _lstNhanVien;
            grvDanhSachLaiXe.ActiveFilterCriteria = null;
            grcDanhSachLaiXe.Refresh();
        }

        #endregion
    }
}
