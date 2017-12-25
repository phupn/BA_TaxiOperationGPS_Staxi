using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Controls.Base;

namespace TaxiOperation_BanCo.DM
{
    public partial class frmDMLoaiXe_Truck : FormBase
    {
        #region khởi tạo form
        public frmDMLoaiXe_Truck()
        {
            InitializeComponent();
            LoadData();
        }
        #endregion

        #region hàm load data
        private void LoadData()
        {
            grcDMLoaiXe.DataSource = new TinhTienTheoKm().GetAllLoaiXe_Truck();
            grcDMLoaiXe.Update();
            grcDMLoaiXe.Focus();
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            grcDMLoaiXe.Focus();
        }

        #region xử lý nút
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (new frmLoaiXe_Truck("Thêm loại xe").ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvDMLoaiXe.FocusedRowHandle >= 0)
            {
                int ID = int.Parse(grvDMLoaiXe.GetFocusedRowCellValue("LoaiXeID").ToString());

                if (new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn có đồng ý xóa loại xe.", "Thông báo",
                                                        Taxi.MessageBox.MessageBoxButtonsBA.YesNo,
                                                        Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    if (new LoaiXe().DeleteLoaiXe_BC_Truck(ID))
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Xóa loại xe thành công", "Thông báo",
                       Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        this.LoadData();
                        Taxi.Business.CommonBL.ListLoaiXe = null;
                        try
                        {
                            grvDMLoaiXe.FocusedRowHandle = 0;
                        }
                        catch
                        { }
                        return;
                    }
                    else
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi xóa loại xe hoặc loại xe đang gán các mục thông tin khác. Bạn kiểm tra lại!", "Thông báo",
                       Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        return;
                    }
                }
            }
        }
        #endregion

        #region grid event
        // stt
        private void grvDMLoaiXe_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvDMLoaiXe_DoubleClick(object sender, EventArgs e)
        {
            var view = (GridView)sender;

            var pt = view.GridControl.PointToClient(Control.MousePosition);

            DoRowDoubleClick(view, pt);
        }

        private void grcDMLoaiXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Sua();
            }
        }

        #endregion

        

        /// <summary>
        /// Handle sự kiện double click trên lưới
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pt"></param>
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                Sua();
            }
        }

        /// <summary>
        /// Sửa
        /// </summary>
        private void Sua()
        {
            if (grvDMLoaiXe.FocusedRowHandle >= 0)
            {
                var id = grvDMLoaiXe.GetFocusedRowCellValue("LoaiXeID") == null ? -1 : int.Parse(grvDMLoaiXe.GetFocusedRowCellValue("LoaiXeID").ToString());
                var tenLoaiXe = grvDMLoaiXe.GetFocusedRowCellValue("TenLoaiXe") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("TenLoaiXe").ToString();
                var hangXe = grvDMLoaiXe.GetFocusedRowCellValue("HangXe") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("HangXe").ToString();
                var kichThuoc = grvDMLoaiXe.GetFocusedRowCellValue("KichThuoc") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("KichThuoc").ToString();
                var taiTrongQuyDinh = grvDMLoaiXe.GetFocusedRowCellValue("TaiTrongQuyDinh") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("TaiTrongQuyDinh").ToString();
                var taiTrongChoPhep = grvDMLoaiXe.GetFocusedRowCellValue("TaiTrongChoPhep") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("TaiTrongChoPhep").ToString();
                var phimTat = grvDMLoaiXe.GetFocusedRowCellValue("PhimTat") == null ? "A" : grvDMLoaiXe.GetFocusedRowCellValue("PhimTat").ToString();
                var vietTat = grvDMLoaiXe.GetFocusedRowCellValue("VietTat") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("VietTat").ToString();
                var font = grvDMLoaiXe.GetFocusedRowCellValue("Font") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("Font").ToString();
                var backColor = grvDMLoaiXe.GetFocusedRowCellValue("BackColor") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("BackColor").ToString();
                var foreColor = grvDMLoaiXe.GetFocusedRowCellValue("ForeColor") == null ? "" : grvDMLoaiXe.GetFocusedRowCellValue("ForeColor").ToString();
                
                if (new frmLoaiXe_Truck(id, tenLoaiXe, hangXe, kichThuoc, taiTrongQuyDinh, taiTrongChoPhep, phimTat, vietTat, font,backColor,foreColor, "Sửa loại xe").ShowDialog() == DialogResult.OK)
                {
                    this.LoadData();
                }
            }
        }

        


    }
}
