using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Taxi.Business.PhanAnh;
using Taxi.Business;

namespace Taxi.Controls.KhieuNai_PhanAnh
{
    public partial class ctrlDSKhieuNai : UserControl
    {
        public ctrlDSKhieuNai()
        {
            InitializeComponent();
        }

        #region LoadForm
        
        public void LoadPhanAnh_ChuaGiaiQuyet(int Position)
        {
            grdGiaiQuyetPA.DataMember = "lstThongTinPA";
            grdGiaiQuyetPA.SetDataBinding(new PhanAnh().GetPhanAnh_II(false, ThongTinDangNhap.RoleNhanVienPA.Equals(DanhSachVaiTro.NVGIAIQUYETPHANANH_II)), "lstThongTinPA");

            if (grdGiaiQuyetPA.RowCount > 0)
            {
                if (Position <= 0)
                {
                    grdGiaiQuyetPA.Row = 0;
                }
                else if (Position > 0)
                {
                    grdGiaiQuyetPA.Row = Position;
                }
            }            
        }

        public void LoadPhanAnh_DaGiaiQuyet(int Position)
        {
            grdDaGiaiQuyetPA.DataMember = "lstThongTinPA";
            List<PhanAnh> lstData = new PhanAnh().GetPhanAnh_II(true, ThongTinDangNhap.RoleNhanVienPA.Equals(DanhSachVaiTro.NVGIAIQUYETPHANANH_II));
            grdDaGiaiQuyetPA.SetDataBinding(lstData, "lstThongTinPA");
            // Congnt sua ----
            if (Position > 0) { grdDaGiaiQuyetPA.Row = Position; }
            // ---------------
        }
        #endregion

        #region =========================Grid Event====================================

        private void grdGiaiQuyetPA_DoubleClick(object sender, EventArgs e)
        {
            if (grdGiaiQuyetPA.SelectedItems.Count <= 0)
                return;

            NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).Position);

        }

        private void grdGiaiQuyetPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && grdGiaiQuyetPA.SelectedItems.Count > 0)
            {
                NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).Position);
            }
        }

        private void grdDaGiaiQuyetPA_DoubleClick(object sender, EventArgs e)
        {
            if (grdDaGiaiQuyetPA.SelectedItems.Count <= 0)
                return;
            XemLaiDuLieuPA(((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).Position);
        }

        private void grdDaGiaiQuyetPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (grdDaGiaiQuyetPA.SelectedItems.Count <= 0)
                return;

            XemLaiDuLieuPA(((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).Position);
        }

        private void grdGiaiQuyetPA_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }

        #endregion

        #region ======================Form Status======================================

        private void HienThiTrangThaiChu(GridEXRow row)
        {
            if (((PhanAnh)row.DataRow).TGPA != DateTime.MinValue)
                return;

            row.Cells["TGPA"].Text = string.Empty;
        }

        public void NhapDuLieuVaoTruyenDi(int iRowPosition)
        {
            grdGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdGiaiQuyetPA.SelectedItems.Count > 0)
            {
                PhanAnh objThongTinPA = (PhanAnh)((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                //End - Thu doi mau                 
                using (frmGhiNhanPhanAnh frmPAInPut = new frmGhiNhanPhanAnh(objThongTinPA, ThongTinDangNhap.RoleNhanVienPA))
                {
                    DialogResult _dialogResult = frmPAInPut.ShowDialog(this);
                    if (_dialogResult == DialogResult.Yes)
                    {
                        LoadPhanAnh_ChuaGiaiQuyet(rowSelect.Position);
                    }
                    else
                        if (_dialogResult == DialogResult.OK)
                            LoadPhanAnh_ChuaGiaiQuyet(frmPAInPut.chkDaGiaiQuyet.Checked ? 0 : rowSelect.Position);
                        else
                            LoadPhanAnh_ChuaGiaiQuyet(rowSelect.Position);
                }

                //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                rowSelect.RowStyle = RowStyle;
            }
        }

        public void XemLaiDuLieuPA(int iRowPosition)
        {
            grdDaGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDaGiaiQuyetPA.SelectedItems.Count > 0)
            {
                PhanAnh objThongTinPA = (PhanAnh)((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                //End - Thu doi mau
                //true : da giai quyet
                using (frmGhiNhanPhanAnh frmPAInPut = new frmGhiNhanPhanAnh(objThongTinPA, ThongTinDangNhap.RoleNhanVienPA, true))
                {
                    DialogResult _dialogResult = frmPAInPut.ShowDialog(this);
                    if (_dialogResult == DialogResult.Yes)
                    {
                        LoadPhanAnh_DaGiaiQuyet(rowSelect.Position);
                    }
                }
                //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                rowSelect.RowStyle = RowStyle;
            }
        }

        #endregion

        private void tabControl_DSKhieuNai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_DSKhieuNai.SelectedIndex == 0)
            {
                LoadPhanAnh_ChuaGiaiQuyet(0);
            }
            else
            {
                LoadPhanAnh_DaGiaiQuyet(0);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.N):
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
