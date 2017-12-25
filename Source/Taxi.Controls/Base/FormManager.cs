using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Common.DbBase;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Controls;
using Taxi.Controls.Base.Extender;
using Taxi.Utils;
namespace Taxi.Controls.Base
{
    /// <summary>
    ///  Form Base Manger
    /// </summary>
    public partial class FormManager : FormBase
    {
        #region ===== Tập quyền ====

        [Category("[Quản lý tập quyền]")]
        public string PermissionAdd { get; set; }

        [Category("[Quản lý tập quyền]")]
        public string PermissionEdit { get; set; }

        [Category("[Quản lý tập quyền]")]
        public string PermissionDelete { get; set; }

        [Category("[Quản lý tập quyền]")]
        public string PermissionFind { get; set; }

        [Category("[Quản lý tập quyền]")]
        public string PermissionRefresh { get; set; }

        [Category("[Quản lý tập quyền]")]
        public string PermissionExportExcel { get; set; }

        #endregion

        #region ===== Ẩn/hiện nút ==

        private bool _isExcel = true;

        [Category("[Quản lý ẩn/hiện nút]")]
        public bool IsExcel
        {
            get { return _isExcel; }
            set
            {
                _isExcel = value;
                VisitButtonAction();
            }
        }

        private bool _isRefresh = true;

        /// <summary>
        /// 
        /// </summary>
        [Category("[Quản lý ẩn/hiện nút]")]
        public bool IsRefresh
        {
            get { return _isRefresh; }
            set
            {
                _isRefresh = value;
                VisitButtonAction();
            }
        }

        private bool _isFind = true;

        [Category("[Quản lý ẩn/hiện nút]")]
        public bool IsFind
        {
            get { return _isFind; }
            set
            {
                _isFind = value;
                VisitButtonAction();
            }
        }

        private bool _isDelete = true;

        [Category("[Quản lý ẩn/hiện nút]")]
        public bool IsDelete
        {
            get { return _isDelete; }
            set
            {
                _isDelete = value;
                VisitButtonAction();
            }
        }

        private bool _isEdit = true;

        [Category("[Quản lý ẩn/hiện nút]")]
        public bool IsEdit
        {
            get { return _isEdit; }
            set
            {
                _isEdit = value;
                VisitButtonAction();
            }
        }

        private bool _isAdd = true;

        [Category("[Quản lý ẩn/hiện nút]")]
        public bool IsAdd
        {
            get { return _isAdd; }
            set
            {
                _isAdd = value;
                VisitButtonAction();
            }
        }

        protected virtual void VisitButtonAction()
        {
            int soButtonAn = 0;
            int soButtonHien = 0;
            const int withButton = 75;
            const int panelButtonwith = 489;
            if (!IsAdd)
            {
                soButtonAn++;
            }
            else
            {
                soButtonHien++;
            }
            btnThem.Visible = IsAdd;
            btnSua.Location = new Point(3 + soButtonHien * (withButton + 5), btnSua.Location.Y);
            if (!IsEdit)
            {
                soButtonAn++;
            }
            else
            {
                soButtonHien++;
            }
            btnSua.Visible = IsEdit;
            btnXoa.Location = new Point(3 + soButtonHien * (withButton + 5), btnXoa.Location.Y);
            if (!IsDelete)
            {
                soButtonAn++;
            }
            else
            {
                soButtonHien++;
            }
            btnXoa.Visible = IsDelete;
            btnTimKiem.Location = new Point(3 + soButtonHien * (withButton + 5),
                btnTimKiem.Location.Y);
            if (!IsFind)
            {
                soButtonAn++;
            }
            else
            {
                soButtonHien++;
            }
            btnTimKiem.Visible = IsFind;
            grBTimKiem.Visible = IsFind;
            btnLamMoi.Location = new Point(3 + soButtonHien * (withButton + 5), btnLamMoi.Location.Y);
            if (!IsRefresh)
            {
                soButtonAn++;
            }
            else
            {
                soButtonHien++;
            }
            btnLamMoi.Visible = IsRefresh;
            btnXuatExcel.Location = new Point(3 + soButtonHien * (withButton + 5),
                btnXuatExcel.Location.Y);
            if (!IsExcel)
            {
                soButtonAn++;
            }
            //else
            //{
            //    soButtonHien++;
            //}
            btnXuatExcel.Visible = IsExcel;
            panelButton.Width = panelButtonwith - (soButtonAn) * (withButton + 5);

            FormManger_SizeChanged(null, null);
        }

        #endregion

        #region ==== Field =========

        [Category("[Quản lý]")]
        public GridControl Grid { get; set; }

        private bool _isLoadFisrt = true;

        [Category("[Quản lý]")]
        public bool IsLoadFisrt
        {
            get { return _isLoadFisrt; }
            set { _isLoadFisrt = value; }
        }

        private bool _isOpenExportExcel = true;

        [Category("[Quản lý]")]
        public bool IsOpenExportExcel
        {
            get { return _isOpenExportExcel; }
            set { _isOpenExportExcel = value; }
        }
        private int RowIndex;
        private string _fileExcel;

        [Category("[Quản lý]")]
        public string FileExcel
        {
            get
            {
                return string.IsNullOrEmpty(_fileExcel) ? this.Name : _fileExcel;
            }
            set
            {
                _fileExcel = value.Trim();
            }
        }

        #endregion

        #region ==== virtual =======

        /// <summary>
        /// Get File Name Excel
        /// </summary>
        /// <returns></returns>
        public virtual string GetFileExcel()
        {
            return string.Format("{0}-{1:ddMMyyyyHHmmssmmm}", string.IsNullOrEmpty(FileExcel) ? this.Text.UnicodeFormat() : FileExcel, DateTime.Now);
        }

        /// <summary>
        /// Form Update
        /// </summary>
        public virtual FormUpdate FormUpdate
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Get Data
        /// </summary>
        public virtual object GetData()
        {
            return null;
        }

        /// <summary>
        /// Model Current
        /// </summary>
        public virtual ModelBase ModelCurrent
        {
            get
            {
                if (Grid != null)
                {
                    RowIndex = Grid.MainView.As<GridView>().FocusedRowHandle;
                    return Grid.MainView.As<GridView>().GetFocusedRow() as ModelBase;
                }
                return null;
            }
        }

        /// <summary>
        /// After Find
        /// </summary>
        public virtual void AfterFind()
        {
        }

        /// <summary>
        /// After Load
        /// </summary>
        public virtual void AfterLoad()
        {
        }

        public virtual void InputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        protected virtual void Delete()
        {
            if (System.Windows.Forms.MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                try
                {
                    if (ModelCurrent != null)
                    {
                        ModelCurrent.Delete();
                        btnLamMoi.PerformClick();
                    }
                    else
                    {
                        SetMessage("Bạn chưa chọn bản ghi nào để xóa");
                    }

                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message);
                }

            }
        }

        protected virtual void Edit()
        {
            try
            {
                if (ModelCurrent != null)
                {
                    var frm = FormUpdate;
                    frm.SetModel(ModelCurrent, this);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnLamMoi.PerformClick();
                    }
                }
                else
                {
                    SetMessage("Bạn chưa chọn bản ghi nào để sửa");
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        protected virtual void Add()
        {
            try
            {
                var frm = FormUpdate;
                frm.SetModel(null, this);
                if (Grid.MainView.As<GridView>().RowCount>0)
                {
                    RowIndex = Grid.MainView.As<GridView>().FocusedRowHandle;
                }
                else
                {
                    RowIndex = 0;
                }
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    btnLamMoi.PerformClick();
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        protected virtual void ExportToExcel()
        {
            try
            {
                if (Grid != null)
                {
                    var dialog = new SaveFileDialog
                    {
                        DefaultExt = "xlsx",
                        Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls",
                        FileName = GetFileExcel()
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (dialog.FileName.EndsWith("xlsx"))
                        {
                            Grid.ExportToXlsx(dialog.FileName);
                        }
                        else
                        {
                            Grid.ExportToXls(dialog.FileName);
                        }
                    }
                    else
                    {
                        IsOpenExportExcel = false;
                    }
                    if (IsOpenExportExcel)
                    {
                        Process.Start(dialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
                LogError.WriteLogError(string.Format("{0}_XuatExcel", this.Name), ex);
            }

        }
        protected virtual void Search()
        {
            try
            {
                SetMessage(string.Empty);
                btnXuatExcel.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                panelInputFind.ParseTo(this, false);
                var data = GetData();
                if (data == null || (data is IList && ((IList)data).Count == 0) ||
                    (data is DataTable && ((DataTable)data).Rows.Count == 0))
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
                if (Grid != null)
                {
                    ((IShReportControl)Grid).SetDataSource(data);
                }
                else
                {
                    throw new Exception("Không tìm thấy lưới hiển thị");
                }
                btnXuatExcel.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                if (Grid != null)
                {
                    ((IShReportControl)Grid).SetDataSource(null);
                }
                SetMessage(ex.Message);

            }
            finally
            {
                // panelInputFind.FocusInput();
                AfterFind();

            }
        }
        protected virtual void RefreshForm()
        {
            try
            {
                SetMessage(string.Empty);
                btnXuatExcel.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                panelInputFind.ClearForm();
                panelInputFind.ParseTo(this, false);
                var data = GetData();
                if (data == null || (data is IList && ((IList)data).Count == 0) ||
                    (data is DataTable && ((DataTable)data).Rows.Count == 0))
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
                if (Grid != null)
                {
                    ((IShReportControl)Grid).SetDataSource(data);
                    Grid.MainView.As<GridView>().FocusedRowHandle = RowIndex;
                }
                else
                {
                    throw new Exception("Không tìm thấy lưới hiển thị");
                }
                btnXuatExcel.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                if (Grid != null)
                {
                    ((IShReportControl)Grid).SetDataSource(null);
                }
                SetMessage(ex.Message);

            }
            finally
            {
                panelInputFind.FocusInput();
                AfterFind();

            }
        }
        #endregion

        #region ==== Function ======

        /// <summary>
        /// Set Message Error
        /// </summary>
        /// <param name="msg"></param>
        public virtual void SetMessage(string msg)
        {
            lblMessage.Text = msg;
            lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2, lblMessage.Location.Y);
        }

        protected virtual void CheckPermission()
        {
            if (IsAdd && !string.IsNullOrEmpty(PermissionAdd) && !ThongTinDangNhap.HasPermission(PermissionAdd))
            {
                IsAdd = false;
            }
            if (IsEdit && !string.IsNullOrEmpty(PermissionEdit) && !ThongTinDangNhap.HasPermission(PermissionEdit))
            {
                IsEdit = false;
            }
            if (IsDelete && !string.IsNullOrEmpty(PermissionDelete) && !ThongTinDangNhap.HasPermission(PermissionDelete))
            {
                IsDelete = false;
            }
            if (IsFind && !string.IsNullOrEmpty(PermissionFind) && !ThongTinDangNhap.HasPermission(PermissionFind))
            {
                IsFind = false;
            }
            if (IsRefresh && !string.IsNullOrEmpty(PermissionRefresh) &&
                !ThongTinDangNhap.HasPermission(PermissionRefresh))
            {
                IsRefresh = false;
            }
            if (IsExcel && !string.IsNullOrEmpty(PermissionExportExcel) &&
                !ThongTinDangNhap.HasPermission(PermissionExportExcel))
            {
                IsExcel = false;

            }

        }

        #endregion

        #region ==== Event =========

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Add();
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            Edit();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }


        private void FormManger_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignTimeHelper.IsInDesignMode) return;
                if (Grid != null)
                {
                    Grid.MainView.As<GridView>().KeyDown+= Grid_KeyDown;
                    Grid.MainView.As<GridView>().DoubleClick += Grid_DoubleClick;
                }
                panelInputFind.BindShControl();
                if (IsLoadFisrt)
                {
                    btnLamMoi.PerformClick();
                }
                panelInputFind.ListInputs.ForEach(p =>
                {
                    ((Control)p).KeyDown += InputKeyDown;
                });
                SetMessage(string.Empty);
                panelInputFind.FocusInput();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                CheckPermission();
                AfterLoad();
            }
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if(Grid.MainView.IsFocusedView)
                btnSua.PerformClick();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSua.PerformClick();
            }
        }

        private void FormManger_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                panelButton.Location = new Point((this.Width - panelButton.Width) / 2, 2);
                lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2, lblMessage.Location.Y);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}
 