using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Taxi.Business.BanGiaGoc; 
using Taxi.Business;
using Taxi.Controls.Base;


namespace Taxi.Controls.FormCheckCoDuongDai
{
    /// <summary>
    /// Bản nhật ký thuê bao tuyến chung cho cả DT, TD và DHC
    /// </summary>
    public partial class frmThongTinNhatKyThueBao : FormBase
    {
        #region Khởi tạo và khai báo!
        public frmThongTinNhatKyThueBao()
        {
            InitializeComponent();
        }
        private void frmThongTinNhatKyThueBao_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDSThueBao();
                if (ThongTinDangNhap.USER_ID.Length <= 0)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải đăng nhập để thực hiện nhập thông tin thuê bao.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmThongTinNhatKyThueBao_Load: ", ex);                
            }
        }
        #endregion

        #region Methods
        private void LoadDSThueBao()
        {
            NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
            DataTable dt = NhatkyThuebaoControl.GetAll();
            try
            {
                gridNhanVien.DataSource = dt;
               
            }
            catch(Exception ex)
            {
                LogError.WriteLogError("LoadDSThueBao: ", ex);
            }
        }

        #endregion

        #region Events
       
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao();
                frmNhapNhatKyThueBaocontrol.ShowDialog();
                LoadDSThueBao();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnAdd_ItemClick: ", ex); 
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {                
                if (gridViewNhanVien.SelectedRowsCount > 0)
                {
                    if (ThongTinDangNhap.USER_ID == "admin" || ThongTinDangNhap.HasPermission(DanhSachQuyen.UpdateThueBaoTuyen))
                    {
                        MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
                        if (msgBox.Show(this, "Bạn có đồng ý xóa không ?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                        {
                            int ID = -1;
                            int index = gridViewNhanVien.FocusedRowHandle;
                            int.TryParse(gridViewNhanVien.GetRowCellValue(index, "ID").ToString(), out ID);
                            NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
                            int So = NhatkyThuebaoControl.Delete(ID);
                            if (So > 0)
                            {
                                new MessageBox.MessageBoxBA().Show(" xóa thành công");
                                DataTable dt = NhatkyThuebaoControl.GetAll();
                                gridNhanVien.DataSource = dt;                                
                            }
                            else
                            {
                                new MessageBox.MessageBoxBA().Show("xóa không thành công");
                            }
                        }
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Chỉ có quản trị hệ thống mới được xóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnDelete_ItemClick: ", ex);                
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXeChuaNhapDuThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
                DataTable dt = NhatkyThuebaoControl.GetDSNhungCuocChuaNhapDuThongTin();
                gridNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnXeChuaNhapDuThongTin: ", ex);                
            }
        }

        private void btnTatCaXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LoadDSThueBao();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnTatCaXe_ItemClick: ", ex);                
            }
        }

        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmTimKiemXeThueBao frm = new frmTimKiemXeThueBao();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
                    DataTable dt = NhatkyThuebaoControl.GetDSCuocThuebao(frm.TuNgay(), frm.DenNgay(), frm.SoHieuXe(), frm.NoiDungTimKhac());
                    gridNhanVien.DataSource = dt;
                }                 
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnTimKiem_Click: ", ex);                            
            }
        }

        private void gridViewNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (gridViewNhanVien.SelectedRowsCount > 0)
                    {
                        int index = gridViewNhanVien.FocusedRowHandle;
                        int KmTra = 0;
                        int ID = 0;
                        int.TryParse(gridViewNhanVien.GetRowCellValue(index, "KmTra").ToString(), out KmTra);
                        int.TryParse(gridViewNhanVien.GetRowCellValue(index, "ID").ToString(), out ID);

                        if (KmTra > 0)
                        {
                            frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID, true);
                            frmNhapNhatKyThueBaocontrol.Show();
                        }
                        else
                        {
                            frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID);
                            frmNhapNhatKyThueBaocontrol.Show();
                        }
                        this.LoadDSThueBao();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewNhanVien_KeyDown: ", ex);
            }
        }

        private void gridViewNhanVien_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewNhanVien.SelectedRowsCount > 0)
                {
                    int index = gridViewNhanVien.FocusedRowHandle;
                    int KmTra = 0, ID = 0;
                    int.TryParse(gridViewNhanVien.GetRowCellValue(index, "KmTra").ToString(), out KmTra);
                    int.TryParse(gridViewNhanVien.GetRowCellValue(index, "ID").ToString(), out ID);
                    if (KmTra > 0)
                    {
                        if (ThongTinDangNhap.HasPermission(DanhSachQuyen.UpdateThueBaoTuyen))
                        {
                            frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID, true);
                            frmNhapNhatKyThueBaocontrol.ShowDialog();
                        }
                        else
                        {
                            new MessageBox.MessageBoxBA().Show("Bạn chỉ sửa thông tin trong vòng 4 giờ khi đã nhập.");
                        }
                    }
                    else
                    {
                        frmNhapNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapNhatKyThueBao(ID);
                        frmNhapNhatKyThueBaocontrol.ShowDialog();
                    }
                    this.LoadDSThueBao();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewNhanVien_DoubleClick: ", ex);
            }
        }

        private void gridViewNhanVien_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                int KmTra = 0;
                int.TryParse(gridViewNhanVien.GetRowCellValue(e.RowHandle, "KmTra").ToString(), out KmTra);
                if (KmTra == -1)
                {                    
                    if (e.Column.FieldName == "SoHieuXe")
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewNhanVien_RowCellStyle: ", ex);
            }
        }

        private void gridViewNhanVien_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.DisplayText == "-1" || e.DisplayText.Contains("00:00 01/01"))
                {
                    e.DisplayText = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewNhanVien_CustomColumnDisplayText: ", ex);
                throw;
            }
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case  Keys.F1:
                    btnAdd.PerformClick();
                    return true;
                case Keys.F2:
                    btnDelete.PerformClick();
                    return true;
                case Keys.F3:
                    btnTimKiem.PerformClick();
                    return true;                    
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}