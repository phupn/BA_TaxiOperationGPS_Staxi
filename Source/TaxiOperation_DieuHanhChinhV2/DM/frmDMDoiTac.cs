using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.CodeParser;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Utils;
using System.Linq;
using Taxi.Common.Extender;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
namespace Taxi.GUI
{
    public partial class frmDMDoiTac : FormBase
    {
        private List<DoiTac> _listDoiTac = new List<DoiTac>();
        public frmDMDoiTac()
        {
            InitializeComponent();
            this.Load += frmDMDoiTac_Load;
        }

        #region Events!
        private void frmDMDoiTac_Load(object sender, EventArgs e)
        {
            try
            {
                LoadListDoiTac();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDMDoiTac_Load: ", ex);
            }
        }

        private void frmDMDoiTac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        #endregion
        
        private void LoadListDoiTac()
        {
            _listDoiTac = new DoiTac().GetListOfDoiTacs();
            GridControl_DoiTac.DataSource = _listDoiTac;
        }

        #region Add, Delete DoiTac

        private void ThemDoiTac()
        {
            try
            {
                string MaDT = "DT1";
                int rowIndex = 0;                        
                if (_listDoiTac != null && _listDoiTac.Count > 0)
                {
                    try
                    {
                        var l = _listDoiTac.Where(T=>T.MaDoiTac.StartsWith("DT")).Select(p => new {Ma = Regex.Replace(p.MaDoiTac, @"[^\d]", "")}).Last();//@"[^\d]": Bỏ hết các ký tự số!
                        MaDT = string.Format("DT{0:0000}", l.Ma.To<long>() + 1);
                    }
                    catch (Exception ex)
                    {
                        MaDT = string.Format("DT{0:0000}", 1);
                    }

                }
                if (gridView_DoiTac.RowCount > 0)
                {
                    rowIndex = gridView_DoiTac.FocusedRowHandle;
                }
                DoiTac objDoiTac = new DoiTac(MaDT, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, true, "", "", 0, "");
                frmDoiTac frm = new frmDoiTac(objDoiTac, true);// them moi
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objDoiTac = frm.GetDoiTac();

                    if (StringTools.TrimSpace(objDoiTac.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objDoiTac.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objDoiTac.Phones).Length < 7) return;
                    objDoiTac.NguoiTao = ThongTinDangNhap.USER_ID;
                    bool Success = objDoiTac.Insert_V2();
                    if (!Success)
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới đối tác");
                    }
                    else
                    {
                        LoadListDoiTac();
                        gridView_DoiTac.SelectRow(rowIndex);
                    }
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DoiTac.ThemMoi", ex);
            }
        }

        private void SuaDoiTac()
        {
            try
            {
                if (gridView_DoiTac.RowCount > 0)
                {
                    DoiTac objDoiTac = (DoiTac)gridView_DoiTac.GetFocusedRow();
                    int rowIndex = gridView_DoiTac.FocusedRowHandle;
                    string MaDoiTacCu = objDoiTac.MaDoiTac;
                    frmDoiTac frm = new frmDoiTac(objDoiTac, false);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        objDoiTac = frm.GetDoiTac();
                        if (StringTools.TrimSpace(objDoiTac.Name).Length <= 0) return;
                        if (StringTools.TrimSpace(objDoiTac.Address).Length <= 0) return;
                        if (StringTools.TrimSpace(objDoiTac.Phones).Length < 8) return;
                        objDoiTac.NguoiSua = ThongTinDangNhap.USER_ID;
                        bool Success = objDoiTac.Update_V2(MaDoiTacCu);
                        if (!Success)
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi cập nhật đối tác");
                        }
                        else
                        {
                            LoadListDoiTac();
                            gridView_DoiTac.SelectRow(rowIndex);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DoiTac.ThemMoi", ex);
            }
        }

        private void Search()
        {
            frmDoiTacTimKiem frm = new frmDoiTacTimKiem();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _listDoiTac = frm.GetResultListOfDoiTac();
                if (_listDoiTac.Count > 0)
                {
                    GridControl_DoiTac.DataSource = _listDoiTac;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Không tìm thấy kết quả nào");
                }
            }
        }

        private void ActiveDoiTac(bool isActive)
        {
            if (gridView_DoiTac.SelectedRowsCount > 0)
            {
                int[] rows = gridView_DoiTac.GetSelectedRows();
                int rowIndex = gridView_DoiTac.FocusedRowHandle;
                if (rows != null && rows.Length > 0)
                {
                    string Msg_Active ;
                    if (isActive)
                    {
                        Msg_Active = "cập nhật đang hoạt động";
                    }
                    else
                    {
                        Msg_Active = "tạm ngừng hoạt động";
                    }
                    MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
                    if (msg.Show(this, String.Format("Bạn có muốn {0} không ?", Msg_Active), "Xóa môi giới", MessageBox.MessageBoxButtonsBA.OKCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.OK.ToString())
                    {
                        for (int row = 0; row < gridView_DoiTac.SelectedRowsCount; row++)
                        {
                            DoiTac objDoiTac = (DoiTac)gridView_DoiTac.GetRow(rows[row]);
                            objDoiTac.Active(objDoiTac.MaDoiTac, isActive, ThongTinDangNhap.USER_ID);
                        }
                        LoadListDoiTac();
                        gridView_DoiTac.SelectRow(rowIndex);
                    }
                }
            }
        }

        private void DeleteDoiTac()
        {
            if (gridView_DoiTac.SelectedRowsCount > 0)
            {
                int[] rows = gridView_DoiTac.GetSelectedRows();
                int rowIndex = gridView_DoiTac.FocusedRowHandle;
                if (rows != null && rows.Length > 0)
                {
                    MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
                    if (msg.Show(this, "Bạn có xóa danh sách môi giới không ?", "Xóa môi giới", MessageBox.MessageBoxButtonsBA.OKCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.OK.ToString())
                    {
                        for (int row = 0; row < gridView_DoiTac.SelectedRowsCount; row++)
                        {
                            DoiTac objDoiTac = (DoiTac)gridView_DoiTac.GetRow(rows[row]);
                            objDoiTac.Delete(objDoiTac.MaDoiTac);
                        }
                        LoadListDoiTac();
                        if (rowIndex >0)
                        {
                            gridView_DoiTac.SelectRow(rowIndex-1);
                        }
                    }
                }
            }
        }

        private void XuatExcel(string titleName, GridControl grvData)
        {
            try
            {
                var svd = new SaveFileDialog();
                svd.Title  = "Chọn nơi lưu file...";
                svd.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
                svd.FileName = string.Format("{0}_{1}", titleName, DateTime.Now.ToString("ddMMyyyy_HH_mm"));
                svd.OverwritePrompt = true;
                if (svd.ShowDialog() == DialogResult.Cancel) { return; }

                if (svd.FileName.EndsWith("xlsx"))
                {
                    grvData.MainView.As<GridView>().OptionsPrint.AutoWidth = false;
                    grvData.ExportToXlsx(svd.FileName, new XlsxExportOptions { TextExportMode = TextExportMode.Text, ExportMode = XlsxExportMode.SingleFile });
                }
                else
                {
                    grvData.ExportToXls(svd.FileName, new XlsExportOptions { TextExportMode = TextExportMode.Text, ExportMode = XlsExportMode.SingleFile });
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("XuatExcel: ", ex);                
            }
        }

        #endregion Add, Delete DOITAC

        #region Menu Events
        
        private void barButton_CheckDuplicate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKiemTraTrungSoDoiTac frm = new frmKiemTraTrungSoDoiTac();
            frm.Show();
        }

        private void barButton_CapNhatCuocGoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCapNhatThongTinMoiGioi frm = new frmCapNhatThongTinMoiGioi();
            frm.ShowDialog();
        }

        private void barButton_Search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search();
        }

        private void barButton_Excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatExcel("DoiTac", GridControl_DoiTac);
        }

        private void barButton_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteDoiTac();
        }

        private void barButton_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ThemDoiTac();
        }

        private void barButton_Active_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActiveDoiTac(true);
        }

        private void barButton_UnActive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActiveDoiTac(false);
        }

        #endregion

        private void GridControl_DoiTac_DoubleClick(object sender, EventArgs e)
        {
            this.SuaDoiTac();
        }

        private void GridControl_DoiTac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SuaDoiTac();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    barButton_ThemMoi.PerformClick();
                    return true;
                case Keys.F2:
                    barButton_Xoa.PerformClick();
                    return true;
                case Keys.F3:
                    barButton_Excel.PerformClick();
                    return true;
                case Keys.F4:
                    barButton_Search.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}