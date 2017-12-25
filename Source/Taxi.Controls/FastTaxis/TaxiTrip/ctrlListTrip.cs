using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.Staxi;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Common;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Inputs;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Data.FastTaxi;
using Taxi.Utils.Enums;

namespace Taxi.Controls.FastTaxis.TaxiTrip
{
    /// <summary>
    /// Danh sách các cuốc lái xe đi đường dài.
    /// </summary>
    public partial class ctrlListTrip : UserControlBase
    {
        public ctrlListTrip()
        {
            if (DesignMode | LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            InitializeComponent();
        }

        public void SelectGridByVehicle(string Vehicle)
        {
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if ((string) gridView1.GetRowCellValue(i, "FK_SoHieuXe") == Vehicle)
                    {
                       
                        gridView1.TopRowIndex = i;
                        gridView1.FocusedRowHandle=i;
                        break;
                    }
                }
            }
        }
        #region Field
        private readonly Timer _timerLayDuLieu = new Timer();
        /// <summary>
        /// 
        /// </summary>
        private List<XeDiDuongDai> _dulieu;
        private DateTime _thoiGianTruocLayDuLieu;
        private bool _first = true;
        /// <summary>
        /// Trạng thái để quy định control.
        /// true:cho phép lấy các trạng thái đang xử lý và dùng timer sử lý.
        /// false: tìm kiếm các trạng thái kết thúc.
        /// </summary>
        public bool IsDieuXe { get; set; }
        public bool VisitSearch
        {
            get;// { return panel1.Visible; }
            set;// { panel1.Visible = value; }
        }
        #endregion

        #region Hàm xử lý
        public void ForcusControl()
        {

            txtSoXe.Focus();
        }
        public void ForcusGrid()
        {
            if (gridView1.RowCount == 0)
            {
                ForcusControl();
            }
            else
            {
                gridView1.Focus();
                shGridControl1.Select();

            }
           
        }
        public bool FindKeyCommand(Keys keyData)
        {
            var cmd = panel1.FindAllChildrenByType<IShKeyPress>().FirstOrDefault(p => p.KeyCommand == keyData);
            if (cmd != null)
                cmd.DoKeyCommand(cmd);
            return cmd.IsNotNull();
        }
        /// <summary>
        /// Khởi tạo tạo timer và lấy dữ liệu đầy đủ cho danh sách.
        /// và cho phép thay đổi dữ liệu.
        /// </summary>
        public void Start()
        {
            IsDieuXe = true;
            gridView1.DoubleClick += gridView1_DoubleClick;
            gridView1.KeyDown += gridView1_KeyDown;
            _thoiGianTruocLayDuLieu = TaxiChieuVe.TaxiReturn_Process.timerServer;
            _timerLayDuLieu.Interval = 1000;
            _timerLayDuLieu.Start();
            _timerLayDuLieu.Tick += _timerLayDuLieu_Tick;
            LoadFull();
        }
        public void LoadFull()
        {
            if (_first) return;
            _dulieu = XeDiDuongDai.Inst.LayXeChuaKetThucTheoLine(ThongTinCauHinh.CacLineCuaTaxiOperation);
            shGridControl1.DataSource = _dulieu;
        }
        /// <summary>
        /// Tìm kiếm theo trạng thái của control
        /// </summary>
        public void ReSearch()
        {
            if (_first) return;
            if (IsDieuXe) TimKiem();
            else SearchDieuKetThuc();
        }
        public void SearchDieuKetThuc()
        {
            if (deTuNgay.EditValue != null && deDenNgay.EditValue != null)
                _dulieu = XeDiDuongDai.Inst.SearchKetThuc(deTuNgay.EditValue.To<DateTime>(), deDenNgay.EditValue.To<DateTime>(), inputLookUp_Province1.EditValue.To<int>(), txtSoXe.Text);
          
            shGridControl1.DataSource = _dulieu;
        }
        private void TimKiem()
        {
            shGridControl1.DataSource =_dulieu.Where(DieuKienTimKiem).ToList();
        }
        private bool DieuKienTimKiem(XeDiDuongDai xddd)
        {
            bool rs = false;
            if (inputLookUp_Province1.EditValue != null && inputLookUp_Province1.EditValue.To<int>() > 0)
                rs = (xddd.FK_TinhThanhDenID == inputLookUp_Province1.EditValue.To<int>());
            else rs = true;
            if (txtSoXe.EditValue != null && txtSoXe.EditValue.To<string>().Trim() != "")
                rs = rs && (xddd.FK_SoHieuXe == txtSoXe.EditValue.To<string>());
            else rs = rs && true;
            return rs;
        }
        #endregion

        #region sự kiện
        int _timeXoaDuLieu=0;
        void _timerLayDuLieu_Tick(object sender, EventArgs e)
        {
            _timeXoaDuLieu++;
            
            var data = XeDiDuongDai.Inst.GetDataByDateTime(ThongTinCauHinh.CacLineCuaTaxiOperation, _thoiGianTruocLayDuLieu);

            if (data != null && data.Count > 0)
            {
                _thoiGianTruocLayDuLieu = TaxiChieuVe.TaxiReturn_Process.timerServer;
                //thực hiện cập nhật dữ liệu vào danh sách.
                data.Where(p=>!DieuKienXoa(p)).ToList().ForEach(p =>
                {
                    
                    var val = _dulieu.FirstOrDefault(p1 => p1.ID == p.ID);
                    if (val != null) // thay thế dữ liệu
                    {
                        val.CopyPropertyValue(p, p.GetPropertiesName());                       
                    }
                    else // thêm dữ liệu
                        _dulieu.Insert(0,p);
                });
                //xóa những cuốc kết thúc trong danh sách.
                data.Where(DieuKienXoa).ToList().ForEach(p =>
                {
                    var v = _dulieu.FirstOrDefault(p1 => p1.ID == p.ID);
                    if (v != null)
                        _dulieu.Remove(v);
                });
                ReSearch();
                //shGridControl1.DataSource = _dulieu;
                //shGridControl1.RefreshDataSource();
            }
            //Chờ 3s thì mới kiểm tra xem có bị xóa dữ liệu.
            if (_timeXoaDuLieu >= 3)
            {
                _timeXoaDuLieu = 0;
                if (_dulieu.Count > 0)
                {
                    string lsId = string.Empty;
                    _dulieu.ForEach(p => lsId += string.Format("{0},", p.ID));
                    var lsDelete = XeDiDuongDai.Inst.GetDataDelete(lsId);
                    if (lsDelete.Count > 0)
                    {
                        _dulieu.Where(p => lsDelete.Any(pi => pi == p.ID)).ToList().ForEach(p => _dulieu.Remove(p));
                        ReSearch();
                    }
                }
            }

        }
        private bool DieuKienXoa(XeDiDuongDai p)
        {
            return (p.IsKetThuc|| p.isDelete);
        }
        private void inputLookUp_Province1_EditValueChanged(object sender, EventArgs e)
        {
            ReSearch();
        }

        private void inputText1_EditValueChanged(object sender, EventArgs e)
        {
            ReSearch();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var m = gridView1.GetFocusedRow<XeDiDuongDai>();
            if (m != null)
            {
                var frm = new frmUpdateTrip(m);             
                frm.ShowDialog();
            }

        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (!ThongTinDangNhap.HasPermission(StaxiPermission.BaoXeDiDuongDai))
                {
                    new MessageBox.MessageBoxBA().Show("Bạn không có quyền thao tác tác vụ này.");
                    return;
                }
                var m = gridView1.GetFocusedRow<XeDiDuongDai>();
                if (m != null)
                {
                    var frm = new frmUpdateTrip(m);
                   
                    frm.ShowDialog();
                }
            }
            else if (e.KeyData == Keys.H)
            {
                if (!ThongTinDangNhap.HasPermission(StaxiPermission.BaoXeDiDuongDai))
                {
                    new MessageBox.MessageBoxBA().Show("Bạn không có quyền thao tác tác vụ này.");
                    return;
                }
                var m = gridView1.GetFocusedRow<XeDiDuongDai>();
                if (m != null && new MessageBox.MessageBoxBA().Show("Bạn có muốn hủy cuốc này không?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo) == "Yes")
                {
                    _dulieu.Remove(m);
                    shGridControl1.RefreshDataSource();
                    m.UpdateStatus(m.ID, Enum_XeBaoDiDuongDai_TrangThai.HuyDieu, ThongTinDangNhap.USER_ID, true);
                    TaxiReturn_Process.TripUpdateStatus(m.ID, ThongTinCauHinh.CompanyID, Services.FastTaxi_OperationService.Trip.Status.HuyDieu);
                }
            }
        }

        private void ctrlDanhSachXeChieuVe_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (ThongTinCauHinh.CacLineCuaTaxiOperation == "")
                ThongTinCauHinh.LayThongTinCauHinh();
            if (!ThongTinCauHinh.FT_ChieuVe_Active)
            {
                this.Visible = false;
                return;
            }
            TaxiReturn_Process.StartTimeServer();
            _dulieu = new List<XeDiDuongDai>();
            gridView1.Add<RepositoryItemEnum_TrangThaiXeBaoDiDuongDai>("TrangThai");
            gridView1.Add<RepositoryItemEnum_TrangThaiDuyetXeBaoDiDuongDai>("TrangThaiDuyet");
            try
            {
                panel1.BindShControl();
               
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show(ex.Message);
            }
            if (IsDieuXe)
            {
                lblDenNgay.Visible = false;
                lblTuNgay.Visible = false;
                deDenNgay.Visible = false;
                deTuNgay.Visible = false;
                //btnSearch.Visible = true;
                btnSearch.Visible = false;
                //panel1.Visible = false;
                Start();
            }
            else
            {
                btnSearch.Visible = true;
            }
            _first = false;
            LoadFull();
            ReSearch();
        }

        private void deTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (IsDieuXe)
                LoadFull();
            ReSearch();
        }

        private void deDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (IsDieuXe)
                LoadFull();
            ReSearch();
        }

        private void inputLookUp_Province1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                inputLookUp_Province1.SetValue(0);
                inputLookUp_Province1.Refresh();
                inputLookUp_Province1.SelectionStart = inputLookUp_Province1.Text.Length;
                e.Handled = true;
            }
            else if (e.KeyData == Keys.Back)
            {
                //inputLookUp_Province1.SetValue(0);
                //inputLookUp_Province1.Refresh();
                //inputLookUp_Province1.SelectionStart =0;
                //inputLookUp_Province1.SelectionLength = 0;
                //e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReSearch();
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            /*
             * nếu trạng thái là đang đi thì ô Số xe màu trắng. 
             * Đã trả khách màu cam. 
             * Đã ghép khách màu xanh giống màu bên lưới khách đặt. 
             * Khách đã lên xe hiển thị màu xanh dương giống màu xanh của xe có khách.
             */
            if (e.Column.FieldName == "FK_SoHieuXe")
            {
                var row = gridView1.GetRow(e.RowHandle).As<XeDiDuongDai>();
                if (row != null)
                {
                    switch (row.TrangThai)
                    {
                        case (int)Enum_XeBaoDiDuongDai_TrangThai.DaGhepKhach:
                            e.Appearance.BackColor = Color.CadetBlue;
                            break;
                        case (int)Enum_XeBaoDiDuongDai_TrangThai.KhachDaLenXe:
                            e.Appearance.BackColor = Color.Bisque;
                            break;
                        case (int)Enum_XeBaoDiDuongDai_TrangThai.KhongXacDinh:
                            e.Appearance.BackColor = Color.Yellow;
                            break;

                    }
                }
            }
            else if (e.Column.FieldName == "TrangThai")
            {             
                var row = gridView1.GetRow(e.RowHandle).As<XeDiDuongDai>();
                if (row != null)
                {
                    switch (row.TrangThai)
                    {
                        case (int)Enum_XeBaoDiDuongDai_TrangThai.None:
                        
                            break;
                    }
                }

            }
            else if (e.Column.FieldName == "Is1ChieuStr")
            {
                    var row = gridView1.GetRow(e.RowHandle).As<XeDiDuongDai>();
                    if (row != null)
                    {
                        if (row.Is1Chieu)
                        {
                            e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold);
                            if (!row.IsAddedStaxi)
                                e.Appearance.ForeColor = Color.Red;

                        }
                    }
            }
        }
        #endregion
       

    }
}
