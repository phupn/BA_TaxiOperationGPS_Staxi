using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Controls;
using Taxi.MessageBox;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmDMKhachQuen_V2 : FormBase
    {

        #region ==========================Init and Constructors==============

        private List<DanhBaKhachQuen_Type> G_lstKhachQuen_Type;
        private List<DanhBaKhachQuen_Rank> G_lstKhachQuen_Rank;

        public frmDMKhachQuen_V2()
        {
            InitializeComponent();
            this.Load += frmDMKhachAo_Load;
        }

        #endregion

        #region ========================Load Form==============================
        private void frmDMKhachAo_Load(object sender, EventArgs e)
        {
            LoadListKhachQuen();
            LoadListKhachQuen_Type();
            LoadListKhachQuen_Rank();
        }

        private void LoadListKhachQuen()
        {
            try
            {
                List<DanhBaKhachQuen> lstKhachQuen = new List<DanhBaKhachQuen>();
                lstKhachQuen = DanhBaKhachQuen.GetDanhSachKhachQuen();
                gridKhachQuen.DataSource = lstKhachQuen;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadListKhachQuen",ex);                
            }
        }

        private void LoadListKhachQuen_Type()
        {
            G_lstKhachQuen_Type = new List<DanhBaKhachQuen_Type>();
            G_lstKhachQuen_Type = DanhBaKhachQuen_Type.GetDanhSachKhachQuen_Type();
        }

        private void LoadListKhachQuen_Rank()
        {
            G_lstKhachQuen_Rank = new List<DanhBaKhachQuen_Rank>();   
            G_lstKhachQuen_Rank = DanhBaKhachQuen_Rank.GetDanhSachKhachQuen_Rank();
        }

        #endregion

        #region =======================Method Process==========================

        private void ThemKhachQuen()
        {
            try
            {
                DanhBaKhachQuen objKhachQuen = new DanhBaKhachQuen();
                frmKhachQuen frm = new frmKhachQuen(objKhachQuen, true, G_lstKhachQuen_Type, G_lstKhachQuen_Rank);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachQuen = frm.GetKhachQuen();                    
                    if (!objKhachQuen.Insert())
                    {
                        new MessageBoxBA().Show("Lỗi thêm mới khách quen");
                    }
                    else
                    {                        
                        LoadListKhachQuen();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ThemKhachQuen: ",ex);                
            }
        }

        private void SuaKhachQuen()
        {
            try
            {
                if (gridViewKhachQuen.SelectedRowsCount > 0)
                {                    
                    DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen) gridViewKhachQuen.GetFocusedRow();
                    frmKhachQuen frm = new frmKhachQuen(objKhachQuen, false, G_lstKhachQuen_Type, G_lstKhachQuen_Rank);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        objKhachQuen = frm.GetKhachQuen();
                        if (StringTools.TrimSpace(objKhachQuen.Name).Length <= 0) return;
                        if (StringTools.TrimSpace(objKhachQuen.Address).Length <= 0) return;
                        if (StringTools.TrimSpace(objKhachQuen.Phones).Length < 8) return;

                        if (!objKhachQuen.Update())
                        {
                            new MessageBoxBA().Show("Lỗi khi sửa khách quen");
                        }
                        else
                        {
                            LoadListKhachQuen();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SuaKhachQuen: ",ex);                
            }
        }

        private void XoaKhachQuen()
        {
            
            if (gridViewKhachQuen.RowCount > 0)
            {                
                DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen) gridViewKhachQuen.GetFocusedRow();
                MessageBoxBA msg = new MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa khách quen " + objKhachQuen.Name + " không ?", "Xóa khách quen", MessageBoxButtonsBA.OKCancel, MessageBoxIconBA.Question) == DialogResult.OK.ToString())
                {
                    if (!objKhachQuen.Delete(objKhachQuen.MaKH ))
                    {
                        new MessageBoxBA().Show("Lỗi xóa khách quen");
                    }
                    else
                    {                        
                        LoadListKhachQuen();
                    }
                }
            }
        }

        private void XuatExcel(string titleName, ShGridControl grvData)
        {
            try
            {
                var svd = new SaveFileDialog();
                svd.Title = "Chọn nơi lưu file...";
                svd.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
                svd.FileName = string.Format("{0}_{1}", titleName, DateTime.Now.ToString("ddMMyyyy_HH_mm"));
                svd.OverwritePrompt = true;
                if (svd.ShowDialog() == DialogResult.Cancel) { return; }

                if (svd.FileName.EndsWith("xlsx"))
                {
                    grvData.MainView.As<GridView>().OptionsPrint.AutoWidth = false;
                    grvData.ExportToXlsx(svd.FileName, new XlsxExportOptions { TextExportMode = TextExportMode.Text, ExportMode = XlsxExportMode.SingleFile });
                    new MessageBoxBA().Show("Kết xuất file excel thành công!","Thông báo",MessageBoxButtonsBA.OK,MessageBoxIconBA.Information);
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

        #endregion

        #region =========================Form Events!=========================
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButton_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ThemKhachQuen();
        }

        private void barButton_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.XoaKhachQuen();
        }

        private void barButton_Search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmKhachQuenTimKiem frm = new frmKhachQuenTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    var lstKhachQuen = frm.GetResultListOfKhachQuen();
                    if (lstKhachQuen.Count > 0)
                    {
                        gridKhachQuen.DataSource = lstKhachQuen;
                    }
                    else
                    {
                        new MessageBoxBA().Show("Không tìm thấy kết quả nào");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("barButton_Search_ItemClick: ",ex);                
            }
        }

        private void gridViewKhachQuen_DoubleClick(object sender, EventArgs e)
        {
            this.SuaKhachQuen();
        }

        private void barButton_Excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatExcel("KhachQuen", gridKhachQuen);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData==Keys.F1)
            { 
                barButton_ThemMoi.PerformClick();
                return true;
            }
            if (keyData == Keys.F2)
            {
                barButton_Xoa.PerformClick();
                return true;
            }
            if (keyData == Keys.F3)
            {
                barButton_Excel.PerformClick();
                return true;
            }
            if (keyData == Keys.F4)
            {
                barButton_Search.PerformClick();
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

    }
}