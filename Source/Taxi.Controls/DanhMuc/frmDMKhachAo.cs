using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmDMKhachAo : FormBase
    {
        public frmDMKhachAo()
        {
            InitializeComponent();
            this.Load += frmDMKhachAo_Load;
        }

        void frmDMKhachAo_Load(object sender, EventArgs e)
        {
            LoadListKhachAo();
            
        }

        private void LoadListKhachAo()
        {
            List<DanhBaKhachAo> lstKhachAo = new List<DanhBaKhachAo>();
            lstKhachAo = DanhBaKhachAo.GetDanhSachKhachAo();
            gridDanhMucKhachAo.DataSource = lstKhachAo;
        }

        #region Add, Delete KhachAo

        private void ThemKhachAo()
        {

            try
            {
                DanhBaKhachAo objKhachAo = new DanhBaKhachAo(string.Empty, string.Empty, string.Empty);
                frmKhachAo frm = new frmKhachAo(objKhachAo, true);// them moi
                frm.ShowDialog(this);
                if ( frm.IsSuccess)
                {
                    objKhachAo = frm.GetKhachAo();
                    if (StringTools.TrimSpace(objKhachAo.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachAo.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachAo.PhoneNumber).Length < 8) return;
                    if (!objKhachAo.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách ảo");
                    }
                    else
                    {
                        LoadListKhachAo();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ThemKhachAo: ", ex);                
            }
                  
        }
        private void SuaKhachAo()
        {
            try
            {
                if (gridViewDanhMucKhachAo.SelectedRowsCount > 0)
                {
                    DanhBaKhachAo objKhachAo = (DanhBaKhachAo)gridViewDanhMucKhachAo.GetFocusedRow();
                    frmKhachAo frm = new frmKhachAo(objKhachAo, false);
                    frm.ShowDialog(this);
                    if (frm.IsSuccess)
                    {
                        objKhachAo = frm.GetKhachAo();
                        if (StringTools.TrimSpace(objKhachAo.Name).Length <= 0) return;
                        if (StringTools.TrimSpace(objKhachAo.Address).Length <= 0) return;
                        if (StringTools.TrimSpace(objKhachAo.PhoneNumber).Length < 8) return;
                        if (!objKhachAo.Update())
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi khi sửa khách ảo");
                        }
                        else
                        {
                            LoadListKhachAo();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SuaKhachAo: ", ex);       
            }
        }
        private void XoaKhachAo()
        {
            try
            {
                if (gridViewDanhMucKhachAo.SelectedRowsCount > 0)
                {
                    DanhBaKhachAo objKhachAo = (DanhBaKhachAo)gridViewDanhMucKhachAo.GetFocusedRow();
                    MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
                    if (msg.Show(this, "Bạn có xóa khách ảo " + objKhachAo.Name + " không ?", "Xóa khách ảo", MessageBox.MessageBoxButtonsBA.OKCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.OK.ToString())
                    {
                        if (!objKhachAo.Delete(objKhachAo.PhoneNumber))
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi khi xóa khách ảo!");
                        }
                        else
                        {
                            LoadListKhachAo();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("XoaKhachAo: ", ex);                
            }
        }
        #endregion Add, Delete KhachAo

        #region Events!
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ThemKhachAo();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnAdd: ", ex);                
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.SuaKhachAo();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnEdit: ", ex);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.XoaKhachAo();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnXoa: ", ex);                
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmKhachAoTimKiem frm = new frmKhachAoTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (frm.GetResultListOfKhachAo().Count > 0)
                    {
                        gridDanhMucKhachAo.DataSource = frm.GetResultListOfKhachAo();
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

        private void gridViewDanhMucKhachAo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDanhMucKhachAo.SelectedRowsCount > 0)
                {
                    DanhBaKhachAo objKhachAo = (DanhBaKhachAo)gridViewDanhMucKhachAo.GetFocusedRow();
                    frmKhachAo frm = new frmKhachAo(objKhachAo, false);
                    frm.ShowDialog(this);
                    if (frm.IsSuccess)
                    {
                        objKhachAo = frm.GetKhachAo();
                        frm.Dispose();
                        if (!objKhachAo.Update())
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi khi sửa khách ảo!");
                        }
                        else LoadListKhachAo();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewDanhMucKhachAo_DoubleClick: ", ex);
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    btnAdd.PerformClick();
                    return true;
                case Keys.F2:
                    btnEdit.PerformClick();
                    return true;
                case Keys.F3:
                    btnXoa.PerformClick();
                    return true;
                case Keys.F4:
                    btnTimKiem.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}