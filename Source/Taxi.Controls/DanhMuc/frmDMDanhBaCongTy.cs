using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls;
using Taxi.Controls.Base;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmDMDanhBaCongTy : FormBase
    {
        #region Init & Contructor!

        public frmCallOut frmCalling;
        public frmDMDanhBaCongTy()
        {
            InitializeComponent();
            this.Load += frmDMDanhBaCongTy_Load;
        }
        private void frmDMDanhBaCongTy_Load(object sender, EventArgs e)
        {
            LoadListDanhBaCongTy();
            frmCalling = new frmCallOut();
        }

        #endregion

        #region Methods
        private void ThemDanhBaCongTy()
        {
            try
            {
                DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy(string.Empty, string.Empty, string.Empty);
                frmDanhBaCongTy frm = new frmDanhBaCongTy(objDanhBaCongTy, true);// them moi
                frm.ShowDialog(this);
                if (frm.IsSuccess)
                {
                    objDanhBaCongTy = frm.GetDanhBaCongTy();

                    if (StringTools.TrimSpace(objDanhBaCongTy.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objDanhBaCongTy.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objDanhBaCongTy.PhoneNumber).Length < 8) return;

                    if (!objDanhBaCongTy.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới vào danh bạ công ty");
                    }
                    else
                    {
                        LoadListDanhBaCongTy();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ThemDanhBaCongTy: ", ex);                
            }
        }
        private void SuaDanhBaCongTy()
        {
            try
            {
                if (gridViewDanhBaCongTy.SelectedRowsCount > 0)
                {
                    DanhBaCongTy objDanhBaCongTy = (DanhBaCongTy)gridViewDanhBaCongTy.GetFocusedRow();
                    frmDanhBaCongTy frm = new frmDanhBaCongTy(objDanhBaCongTy, false);
                    frm.ShowDialog(this);
                    if (frm.IsSuccess)
                    {
                        objDanhBaCongTy = frm.GetDanhBaCongTy();
                        if (StringTools.TrimSpace(objDanhBaCongTy.Name).Length <= 0) return;

                        if (StringTools.TrimSpace(objDanhBaCongTy.Address).Length <= 0) return;

                        if (StringTools.TrimSpace(objDanhBaCongTy.PhoneNumber).Length < 8) return;

                        if (!objDanhBaCongTy.Update())
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi sửa danh bạ công ty!");
                        }
                        else
                        {
                            LoadListDanhBaCongTy();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SuaDanhBaCongTy: ", ex);                
            }
        }
        private void XoaDanhBaCongTy()
        {            
            if (gridViewDanhBaCongTy.SelectedRowsCount > 0)
            {                             
                DanhBaCongTy objDanhBaCongTy = (DanhBaCongTy) gridViewDanhBaCongTy.GetFocusedRow();
                MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
                if (msg.Show(this, "Bạn có xóa " + objDanhBaCongTy.Name + " không ?", "Xóa công ty", MessageBox.MessageBoxButtonsBA.OKCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.OK.ToString())
                {
                    if (!objDanhBaCongTy.Delete(objDanhBaCongTy.PhoneNumber))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi khi xóa công ty!");
                    }
                    else
                    {                        
                        LoadListDanhBaCongTy();
                    }
                }
            }
        }
        private void LoadListDanhBaCongTy()
        {
            try
            {
                List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();
                lstDanhBaCongTy = DanhBaCongTy.GetDanhSachDanhBaCongTy();
                gridDanhBaCongTy.DataSource = lstDanhBaCongTy;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadListDanhBaCongTy: ", ex);
            }
        }
        #endregion

        #region Events!

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ThemDanhBaCongTy();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SuaDanhBaCongTy();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.XoaDanhBaCongTy();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmDanhBaCongTyTimKiem frm = new frmDanhBaCongTyTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (frm.GetResultListOfDanhBaCongTy().Count > 0)
                    {
                        gridDanhBaCongTy.DataSource = frm.GetResultListOfDanhBaCongTy();
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy kết quả nào");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnTimKiem_ItemClick: ", ex); 
            }
        }
        private void gridViewDanhBaCongTy_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDanhBaCongTy.SelectedRowsCount > 0)
                {
                    DanhBaCongTy objCongTy = (DanhBaCongTy) gridViewDanhBaCongTy.GetFocusedRow();
                    frmDanhBaCongTy frm = new frmDanhBaCongTy(objCongTy, false);
                    frm.ShowDialog(this);
                    if (frm.IsSuccess)
                    {
                        objCongTy = frm.GetDanhBaCongTy();
                        frm.Dispose();
                        if (!objCongTy.Update())
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi thêm mới danh bạ công ty");
                        }
                        else LoadListDanhBaCongTy();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewDanhBaCongTy_DoubleClick: ", ex);  
            }
        }

        #endregion
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    this.ThemDanhBaCongTy();
                    return true;
                case Keys.F2:
                    this.SuaDanhBaCongTy();
                    return true;
                case Keys.F3:
                    this.XoaDanhBaCongTy();
                    return true;
                case Keys.F4:
                    btnTimKiem.PerformClick();
                    return true;
                case Keys.Control | Keys.Space:
                    {
                        if (AsteriskInfo.Extension_One != "" && CallOutProcess.IsAvailable)
                        {
                            try
                            {
                                var item = (DanhBaCongTy)gridViewDanhBaCongTy.GetFocusedRow();
                                if (item != null)
                                {
                                    CallOutProcess.Call(item.PhoneNumber, item.Address, AsteriskInfo.Extension_One);
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError("frmDMDanhBaCongTy CallOut 1", ex);
                            }
                        }
                    }
                    return true;
                case Keys.Space:
                    {
                        if (AsteriskInfo.Extension_Two != "" && CallOutProcess.IsAvailable)
                        {
                            try
                            {
                                var item = (DanhBaCongTy)gridViewDanhBaCongTy.GetFocusedRow();
                                if (item != null)
                                {
                                    CallOutProcess.Call(item.PhoneNumber, item.Address, AsteriskInfo.Extension_Two);
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError("frmDMDanhBaCongTy CallOut 2", ex);
                            }
                        }
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}