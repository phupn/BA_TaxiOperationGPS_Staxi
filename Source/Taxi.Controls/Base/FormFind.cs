using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base.Controls;

namespace Taxi.Controls.Base
{
    public partial class FormFind : FormBase
    {
        #region ==== Field =================

        [Category("FormBase")]
        public ShGridControl Grid { get; set; }
        private string _fileExcel;
        [Category("FormBase")]
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

        #region ===== PERMISSION Action ====
        // [Category("Action PERMISSION")]
       // public string PermissionAdd { get; set; }
       //[Category("Action PERMISSION")]
       // public string PermissionEdit { get; set; }
       //[Category("Action PERMISSION")]
       // public string PermissionDelete { get; set; }
       [Category("Action PERMISSION")]
        public string PermissionFind { get; set; }
       [Category("Action PERMISSION")]
        public string PermissionRefresh { get; set; }
       [Category("Action PERMISSION")]
        public string PermissionExportExcel { get; set; }
        #endregion

        #region ==== Button Action =========
       private bool _isExcel = true;
        private bool _isRefresh = true;
        private bool _isFind = true;
        [Category("FormBase")]
        public bool IsExcel
        {
            get { return _isExcel; }
            set
            {
                _isExcel = value;
                VisitButtonAction();
            }
        }

        [Category("FormBase")]
        public bool IsRefresh
        {
            get { return _isRefresh; }
            set
            {
                _isRefresh = value;
                VisitButtonAction();
            }
        }

        public bool IsFind
        {
            get { return _isFind; }
            set{
                _isFind = value;
                VisitButtonAction();
            }
        }

        protected virtual void VisitButtonAction()
        {
            int soButtonAn = 0;
            int soButtonHien = 0;
            const int withButton = 75;
            const int panelButtonwith = 253;
            //if (!IsAdd)
            //{
            //    soButtonAn++;
            //}
            //else
            //{
            //    soButtonHien++;
            //}
            //btnThem.Visible = IsAdd;
            //btnSua.Location = new Point(3 + soButtonHien * (withButton + 5), btnSua.Location.Y);
            //if (!IsEdit)
            //{
            //    soButtonAn++;
            //}
            //else
            //{
            //    soButtonHien++;
            //}
            //btnSua.Visible = IsEdit;
            //btnXoa.Location = new Point(3 + soButtonHien * (withButton + 5), btnXoa.Location.Y);
            //if (!IsDelete)
            //{
            //    soButtonAn++;
            //}
            //else
            //{
            //    soButtonHien++;
            //}
            //btnXoa.Visible = IsDelete;
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

            FormFind_SizeChanged(null, null);
        }
        #endregion

        #region ==== Virtual ===============
        public virtual string GetFileExcel()
        {
            return string.Format("{0}-{1:ddMMyyyyHHmmssmi}", FileExcel, DateTime.Now);
        }
        public virtual void AfterFind() { }
        public virtual void AfterLoad() { }
        public virtual object GetData()
        {
            return null;
        }
        #endregion

        #region ==== Function ==============
        public void SetMessage(string msg)
        {
            lblMessage.Text = msg;
            lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2, lblMessage.Location.Y);
        }
        protected virtual void CheckPermission()
        {
            //if (IsAdd && !string.IsNullOrEmpty(PermissionAdd) && !ThongTinDangNhap.HasPermission(PermissionAdd))
            //{
            //    IsAdd = false;
            //}
            //if (IsEdit && !string.IsNullOrEmpty(PermissionEdit) && !ThongTinDangNhap.HasPermission(PermissionEdit))
            //{
            //    IsEdit = false;
            //}
            //if (IsDelete && !string.IsNullOrEmpty(PermissionDelete) && !ThongTinDangNhap.HasPermission(PermissionDelete))
            //{
            //    IsDelete = false;
            //}
            if (IsFind && !string.IsNullOrEmpty(PermissionFind) && !ThongTinDangNhap.HasPermission(PermissionFind))
            {
                IsFind = false;
            }
            if (IsRefresh && !string.IsNullOrEmpty(PermissionRefresh) && !ThongTinDangNhap.HasPermission(PermissionRefresh))
            {
                IsRefresh = false;
            }
            if (IsExcel && !string.IsNullOrEmpty(PermissionExportExcel) && !ThongTinDangNhap.HasPermission(PermissionExportExcel))
            {
                IsExcel = false;
            }
        }
        #endregion

        #region ==== Event Form ============
        private void FormFind_SizeChanged(object sender, System.EventArgs e)
        {
            try
            {
                panelButton.Location = new Point((this.Width - panelButton.Width) / 2, 2);
                lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2, lblMessage.Location.Y);
            }
            catch (Exception ex) { }
           
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            try
            {
                SetMessage(string.Empty);
                btnXuatExcel.Enabled = false;
                panelInputFind.ParseTo(this, false);
                var data = GetData();
                if (data == null || (data is IList && ((IList) data).Count == 0) ||
                    (data is DataTable && ((DataTable) data).Rows.Count == 0))
                {
                    throw  new Exception("Không tìm thấy dữ liệu");
                }
                if (Grid != null)
                {
                    Grid.SetDataSource(data);
                }
                else
                {
                    throw new Exception("Không tìm thấy lưới hiển thị");
                }
                btnXuatExcel.Enabled = true;
            }
            catch (Exception ex)
            {
                if (Grid != null)
                {
                    Grid.SetDataSource(null);
                }
                SetMessage(ex.Message);
                
            }
            finally
            {
                //panelInputFind.FocusInput();
                AfterFind();
                
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                btnXuatExcel.Enabled = false;
                SetMessage(string.Empty);
                panelInputFind.ClearForm();
                panelInputFind.FocusInput();
                if (Grid != null)
                {
                    Grid.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grid != null)
                {
                    var dialog = new SaveFileDialog { DefaultExt = "xlsx",
                        Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls",
                        FileName = GetFileExcel() };
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
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void FormFind_Load(object sender, EventArgs e)
        {
            try
            {
                SetMessage(string.Empty);
            }
            catch
            {

            }
            finally
            {
                AfterLoad();
            }
        }
        #endregion
    }
}
