using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Taxi.Business;
using Taxi.Common.Attributes;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Common;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Controls.FastTaxis.TaxiDieuXe;
using Taxi.Services.FastTaxi_OperationService;
using Taxi.Utils.Enums;
using Taxi.Utils.Enums.DieuXeChieuVe;
using Booking = Taxi.Data.FastTaxi.Booking;
using MessageBoxButtons = Taxi.MessageBox.MessageBoxButtonsBA;
using Taxi.Business.Staxi;
using Taxi.Common.DbBase;
using Taxi.Data.FastTaxi;
using Taxi.Services;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Taxi.Controls.Base.Inputs;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.Controls.FastTaxis.TaxiBook
{
    public delegate void GridSelect(string SoXe);

    public partial class ctrlListBook : UserControlBase
    {
        public event GridSelect EventGridSelect;
        public ctrlListBook(){
            InitializeComponent();
        }

        #region biến dữ liệu
        private string m_HuyDieu = "KH hủy";
        private string m_DaGapXe = "Đã gặp xe";
        private float g_KmDuKien = 30; 
        public bool IsDieuXe { get; set; }
        public List<Booking> DuLieu;
        public frmInfo FrmThongTin;
        private readonly Timer _layDuLieuThayDoi = new Timer();
        private DateTime _thoiDiemTruocLayDuLieu;
      //  public static DateTime TaxiReturn_Process.timerServer;
        //public static Timer G_TaxiReturn_Process.timerServer;
        public bool VisitSearch
        {
            get;// { return panel2.Visible; }
            set ;//{ panel2.Visible = value; }
        }

        #endregion

        #region Sự kiên

        #region btn

        private int _iSearch = -1;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            ReSearch();
        }

        #endregion

        private void ctrlDieuXe_Load(object sender, EventArgs e)
        {
          
            if (DesignMode) return;
            if (ThongTinCauHinh.CacLineCuaTaxiOperation == "")
                ThongTinCauHinh.LayThongTinCauHinh();
            if (!ThongTinCauHinh.FT_ChieuVe_Active)
            {
                this.Visible = false;
                return;
            }
            TaxiReturn_Process.StartTimeServer();
            try
            {
                MenuItem_ChuyenSangChuaGiaiQuyet.Visible = !IsDieuXe;
                menuKetThuc.Visible = IsDieuXe;
                gridView_Bookings.Add<RepositoryItemEnum_TrangThaiDieuXe>("OpStatus");
                panel2.BindShControl();
                if (IsDieuXe)
                {
                   // panel2.Visible = true;
                    DieuXe();
                    lblNgayDon.Visible = false;
                    lblNgayDen.Visible = false;
                    deDenNgay.Visible = false;
                    deTuNgay.Visible = false;
                    btnSearch.Visible = false;
                }
                else
                {
                    deDenNgay.Bind();
                    deTuNgay.Bind();
                }
                

            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show(ex.Message);
            }
        }

        private void txtDiaChiDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ReSearch();
            }
        }
        
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == (Keys.Control| Keys.R))
            //{
            //    _iSearch = 0;
            //}
            //if (!IsDieuXe)
            //{
            //    if (e.KeyData == Keys.Enter)
            //    {
            //        GridEnter();
            //    }
            //    //else if (e.KeyData == Keys.D1 || e.KeyData == Keys.NumPad1)
            //    //{
            //    //    _iSearch = 0;
            //    //    GridDaDonDuocKhach();
            //    //}
            //    return;
            //}
            if (e.KeyData == Keys.Enter)
            {
                GridEnter();
            }
            if (e.KeyData == Keys.Apps)
            {
                GridViewInfo info = (GridViewInfo)gridView_Bookings.GetViewInfo();
                GridCellInfo cell = info.GetGridCellInfo(gridView_Bookings.FocusedRowHandle, gridView_Bookings.FocusedColumn);
                if (cell != null && cell.Bounds!=null)
                cMenu.Show(shGridControl_Bookings, cell.Bounds.X+cell.Column.Width/2, cell.Bounds.Y+cell.RowInfo.RowLineHeight/2);
            }
            //else if (e.KeyData == Keys.Delete)
            //{
            //    //_iSearch = 0;
            //    //GridDelete();
            //}
            //else if (e.KeyData == Keys.D1 || e.KeyData == Keys.NumPad1)
            //{
            //    _iSearch = 0;
            //    GridDaDonDuocKhach();
            //}
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            // if (!IsDieuXe) return;
            GridEnter();
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            /* o	Màu sắc :
                	Đã ghép xe : hiển thị nền cả dòng màu xanh da trời
                	Khách đã lên xe : hiển thị màu cam nhạt
                */
            var row = gridView_Bookings.GetRow(e.RowHandle).As<Booking>();
            if (row != null)
            {
                switch (row.OpStatus)
                {
                    case (int)Enum_DieuXe_trangThai.DaGhepKhach:
                        {
                            e.Appearance.BackColor = Color.CadetBlue;
                            e.Appearance.ForeColor = Color.White;
                        }

                        break;
                    case (int)Enum_DieuXe_trangThai.DaDonDuocKhach:
                        e.Appearance.BackColor = Color.Bisque;
                        break;
                }
                
            }
        }

        private void gridView_Bookings_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (IsDieuXe)
            {
                if (e.Column.FieldName == "Mobile_ThoiGian")
                {
                    var row = gridView_Bookings.GetRow(e.RowHandle).As<Booking>();
                    if (row != null)
                    {
                        if (row.Mobile == row.Mobile_ThoiGian)
                        {

                        }
                        else
                        {
                            if (row.OpReceivedTime == null)
                            {
                                e.Appearance.BackColor = Color.Yellow;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.LimeGreen;
                            }
                        }
                    }
                }
            }
            if (e.Column.FieldName == "OpCommand")
            {
                var row = gridView_Bookings.GetRow(e.RowHandle).As<Booking>();
                if (row != null)
                {
                    if (row.OpCommand ==m_HuyDieu)
                    {
                        e.Appearance.BackColor = Color.Goldenrod;
                    }
                    else
                    {

                     
                    }
                }
            }
         
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMenu.Show(shGridControl_Bookings, e.X, e.Y);
            }
            if (EventGridSelect != null)
            {
               var vehicle= gridView_Bookings.GetRowCellValue(e.RowHandle, "OpVehicle");
                if (vehicle != null && vehicle.ToString() != string.Empty)
                {
                    EventGridSelect(vehicle.ToString());
                }
            }
        }

        private void menuChuyenSangChuaGiaiQuyet_Click(object sender, EventArgs e)
        {
            if (gridView_Bookings.GetFocusedRow() != null)
            {

                if (String.Equals(new MessageBox.MessageBoxBA().Show("Bạn có muốn chuyển cuốc này sang cuốc chưa giải quyết", "Thông báo", MessageBoxButtons.YesNo), "yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    var m = gridView_Bookings.GetFocusedRow().As<Booking>();
                    m.OpVehicle = string.Empty;
                    m.FK_TaxiReturn = 0;
                    m.OpAcceptedTime = TaxiReturn_Process.timerServer;
                    m.DateCreated = TaxiReturn_Process.timerServer;
                    m.OpStatus = (int)Enum_Bookings_OpStatus.ChoXuLy;
                    m.Update();
                    btnSearch.PerformClick();
                }

            }
        }
        private int _timeXoaDuLieu = 0;
        private void layDuLieuThayDoi_Tick(object sender, EventArgs e)
        {
            _timeXoaDuLieu++;
            try
            {
                if (DuLieu == null) DuLieu = new List<Booking>();
                if (_iSearch > 0)
                {
                    //  _iSearch--;
                }
                else if (_iSearch == 0)
                {
                    shGridControl_Bookings.DataSource = DuLieu;
                    shGridControl_Bookings.RefreshDataSource();
                    _iSearch = -1;
                }
                var data = Booking.Inst.GetByDateTime(ThongTinCauHinh.CacLineCuaTaxiOperation, _thoiDiemTruocLayDuLieu);

                if (data != null && data.Count > 0)
                {
                    TaxiReturn_Process.timerServer = DieuHanhTaxi.GetTimeServer();
                    _thoiDiemTruocLayDuLieu = TaxiReturn_Process.timerServer;
                    //Kiểm tra là trạng thái chấp nhận,đã đón khách,chờ xử lý thì thêm và cập nhận lại.
                    data.Where(p => !DieuKienXoa(p)).ToList().ForEach(p =>
                    {
                        var dl = DuLieu.FirstOrDefault(pi => pi.PK_BooID == p.PK_BooID);
                        if (dl != null)
                        {
                            dl.CopyPropertyValue(p, p.GetPropertiesName());
                        }
                        else
                        {
                            if (p.FK_TaxiReturn == 0 && p.OpStatus==(int)Enum_Bookings_OpStatus.ChoXuLy)
                            {
                                var control = this.ActiveControl;
                                if (this.ParentForm != null)
                                {
                                    control = this.ParentForm.ActiveControl;
                                }
                                if (!string.IsNullOrEmpty(ThongTinDangNhap.USER_ID)&&ThongTinDangNhap.HasPermission(StaxiPermission.GhepXeChieuVe))
                                {
                                    FrmThongTin = new frmInfo();
                                    FrmThongTin.SetModel(p);
                                    FrmThongTin.Show();
                                }
                                bool check = false;
                                foreach (Form item in Application.OpenForms)
                                {
                                    if (item.Visible && item is frmKhachCanXe)
                                    {
                                        item.Focus();
                                        item.Activate();
                                        check = true;
                                    }
                                }
                                if (!check&&control != null)
                                    control.Focus();
                            }
                            else
                            {
                                if (p.OpReceivedTime == null)
                                {
                                    p.OpReceived(p.PK_BooID, ThongTinDangNhap.USER_ID);
                                    TaxiReturn_Process.OperationHasReceive(p.PK_BooID, ThongTinCauHinh.GPS_MaCungXN.To<int>());     
                                }
                                                        
                            }
                            DuLieu.Insert(0,p);
                        }
                    });
                    //kiểm tra xem đã kết thúc và xóa khỏi lưới.
                    data.Where(DieuKienXoa).ToList().ForEach(p =>
                    {
                        var dl = DuLieu.FirstOrDefault(pi => pi.PK_BooID == p.PK_BooID);
                        if (dl != null)
                        {
                            DuLieu.Remove(dl);
                        }
                    });
                    if (_iSearch == -1)
                    {
                        shGridControl_Bookings.DataSource = DuLieu;
                        shGridControl_Bookings.RefreshDataSource();
                    }
                  //  DuLieu = DuLieu.OrderBy(p => p.CreatedDate).ToList();  
                }
                //Duyệt các cuốc xe thời gian đã hết chưa và thực hiện dấu số điện thoại.
                DuLieu.ForEach(p =>
                {

                    if (p.OpStatus == (int)Enum_Bookings_OpStatus.ChapNhan ||p.OpStatus == (int)Enum_Bookings_OpStatus.DaDonKhach)
                    {
                        p.Mobile_ThoiGian = p.Mobile;
                    }
                    else if (p.OpStatus == (int)Enum_Bookings_OpStatus.ChoXuLy)
                    {
                        if (IsDieuXe)
                        {
                            if (string.IsNullOrEmpty(p.OpCommand))
                            {
                                var dt = p.OpReceivedTime ?? p.CreatedDate;
                                //Trạng thái số phút còn lại thực hiện
                                int val = ((p.OpReceivedTime == null ? 1 : 5) * 60) - (int)(TaxiReturn_Process.timerServer - dt.Value).TotalSeconds;
                                // nếu hết thời gian sẽ cập nhật là không xử lý.
                                if (val <= 0)
                                {
                                    //p.OpStatus = (int)Enum_Bookings_OpStatus.KhongXuLy;
                                    //p.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                                    //p.OpAcceptedTime = TaxiReturn_Process.timerServer;
                                    p.UpdateStatus(p.PK_BooID, Enum_Bookings_OpStatus.KhongXuLy, ThongTinDangNhap.USER_ID);
                                    DuLieu.Remove(p);
                                }
                                else
                                {

                                    int sophut = (val / 60);
                                    int soGiay = val - sophut * 60;
                                    p.Mobile_ThoiGian = string.Format("Còn lại {0}:{1}", sophut, soGiay);
                                }

                            }
                            else
                            {
                                p.Mobile_ThoiGian = string.Empty;
                            }                        
                        }
                        else
                        {
                            p.Mobile_ThoiGian = string.Empty;
                        }      
                    }

                    else
                    {
                        p.Mobile_ThoiGian = string.Empty;
                    }    
                });
              
                if (_timeXoaDuLieu >= 3)
                {
                    _timeXoaDuLieu = 0;
                    if (DuLieu.Count > 0)
                    {
                        string lsId = string.Empty;
                        DuLieu.ForEach(p => lsId += string.Format("{0},", p.PK_BooID));
                        var lsDelete = Booking.Inst.GetDataDelete(lsId);
                        DuLieu.Where(p => lsDelete.Any(pi => pi == p.PK_BooID)).ToList().ForEach(p => {
                            p.OpReceivedTime=DateTime.Now;
                            DuLieu.Remove(p);
                        });                        
                    }
                    //DuLieu = DuLieu.OrderBy(p => p.CreatedDate).ToList();                    
                }
                shGridControl_Bookings.RefreshDataSource();
                //int index = gridView_Bookings.FocusedRowHandle;
                //shGridControl_Bookings.DataSource = DuLieu.Where(DieuKienTimKiem).ToList();
                //if (index < gridView_Bookings.RowCount) gridView_Bookings.FocusedRowHandle = index;
               
            }
            catch (Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "ctrlListBook\\layDuLieuThayDoi_Tick", DateTime.Now,ex.Message);
            }
        }
        public bool DieuKienTimKiem(Booking p)
        {
            return (txtSoDT.Text==string.Empty|| p.Mobile_ThoiGian.Contains(txtSoDT.Text)) &&( txtDiaChiDon.Text==string.Empty|| p.TenGhepDiaChiDon.Contains(txtDiaChiDon.Text));
        }
        public bool DieuKienXoa(Booking p)
        {
            //HỦy |Xóa| (Khác chờ xử lý&khác chấp nhận)
            return p.OpIsDelete || p.IsCancel || (p.OpStatus != (int)Enum_Bookings_OpStatus.ChoXuLy && p.OpStatus != (int)Enum_Bookings_OpStatus.ChapNhan);
        }
        #endregion

        #region Hàm xử lý dữ liệu
        public bool FindKeyCommand(Keys keyData)
        {
            var cmd=panel2.FindAllChildrenByType<IShKeyPress>().FirstOrDefault(p => p.KeyCommand == keyData);
            if (cmd != null)
                cmd.DoKeyCommand(cmd);
            return cmd.IsNotNull();
        }
        public void ForcusControl()
        {

            txtSoDT.Focus();
        }
        public void ForcusGrid()
        {
            if (gridView_Bookings.RowCount == 0)
            {
                ForcusControl();
            }
            else
            {
                gridView_Bookings.Focus();
                shGridControl_Bookings.Select();
            }
           
        }
        public void ReSearch()
        {
            if (deTuNgay.EditValue == null || deDenNgay.EditValue == null)
            {
                shGridControl_Bookings.DataSource = null;
                return;
            }
            var start = deTuNgay.DateTime;
            var end = deDenNgay.DateTime;
            if (IsDieuXe) //
            {
                shGridControl_Bookings.DataSource = DuLieu.Where(DieuKienTimKiem).ToList();
                shGridControl_Bookings.RefreshDataSource();
                //_iSearch = 4;
                //shGridControl_Bookings.DataSource = Booking.Inst.Search(ThongTinCauHinh.CacLineCuaTaxiOperation,
                //    txtSoDT.Text, txtDiaChiDon.Text, start, end);
                //shGridControl_Bookings.RefreshDataSource();
            }
            else
            {
                var ketThuc=Booking.Inst.SearchKetThuc(ThongTinCauHinh.CacLineCuaTaxiOperation,
                   txtSoDT.Text, txtDiaChiDon.Text, start, end);
                ketThuc.ForEach(p=>{
                    if(p.FK_TaxiReturn>0)
                    p.Mobile_ThoiGian     =p.Mobile;
                });
                shGridControl_Bookings.DataSource = ketThuc;
                shGridControl_Bookings.RefreshDataSource();
            }
        }
        public void DieuXe()
        {
            #region Lấy dữ liệu đầy đủ cho lưới.
            TaxiReturn_Process.timerServer = DieuHanhTaxi.GetTimeServer();
            if (deTuNgay.EditValue == null || deDenNgay.EditValue == null) return;
            _thoiDiemTruocLayDuLieu = TaxiReturn_Process.timerServer;
            var start = _thoiDiemTruocLayDuLieu.Date.AddMonths(-3);
            var end = _thoiDiemTruocLayDuLieu.Date.AddMonths(3);
            DuLieu = Booking.Inst.Search(ThongTinCauHinh.CacLineCuaTaxiOperation, string.Empty, string.Empty, start, end).OrderByDescending(p => p.CreatedDate).ToList();
            shGridControl_Bookings.DataSource = DuLieu;
            shGridControl_Bookings.Refresh();
            #endregion

            #region thiết lập thời gian
            
            _layDuLieuThayDoi.Interval = 1000;
            _layDuLieuThayDoi.Tick += layDuLieuThayDoi_Tick;
       
            _layDuLieuThayDoi.Start();
            
            #endregion
        }
        [MethodWithKey(Keys = (Keys.Control | Keys.R))]
        public void ReKeySearch()
        {
            _iSearch = 0;
        }
        [MethodWithKey(Keys = (Keys.Control | Keys.H))]
        public void ShowCtrlH()
        {
            if (FrmThongTin != null)
            {
                if (Application.OpenForms[FrmThongTin.Name] == null)
                {
                    GridEnter();
                }
                else
                {

                    //if (FrmThongTin.Model.OpReceivedTime == null)
                    //{
                    //    FrmThongTin.Model.OpReceived(FrmThongTin.Model.PK_BooID, ThongTinDangNhap.USER_ID);
                    //}
                    FrmThongTin.ShowCtrlH();
                }

            }
            else
            {
                GridEnter();
            }

        }
        #endregion

        #region Menu
        private void kháchĐãLênXe1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridDaDonDuocKhach();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var m = gridView_Bookings.GetFocusedRow().As<Booking>();
                if (m!=null)
                m.UpdateStatus(m.PK_BooID, Enum_Bookings_OpStatus.HuyDieu, ThongTinDangNhap.USER_ID);
            }
            catch (Exception ex) { }
           
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridEnter();
        }

        private void GridEnter()
        {
            if (IsDieuXe)
            {
                if (ThongTinDangNhap.HasPermission(StaxiPermission.GhepXeChieuVe))
                {
                    if (gridView_Bookings.GetFocusedRow() != null)
                    {
                        var frm = new frmKhachCanXe(gridView_Bookings.GetFocusedRow().As<Booking>());
                        frm.ShowDialog();
                        if (!IsDieuXe)
                        {
                            btnSearch.PerformClick();
                        }
                        else
                        {
                            _iSearch = 0;
                        }
                    }
                    else
                    {
                        // new MessageBox.MessageBox().Show("Chưa chọn cuốc khách");
                    }

                }
                
                
            }
            
        }
        private void GridDelete()
        {
            if (ThongTinDangNhap.HasPermission(StaxiPermission.GhepXeChieuVe))
            {
                if (gridView_Bookings.GetFocusedRow() != null)
                {
                    var m = gridView_Bookings.GetFocusedRow().As<Booking>();
                    if (m.OpStatus == (int)Enum_Bookings_OpStatus.DaDonKhach)
                    {
                        new MessageBox.MessageBoxBA().Show("[Không xóa được] - Cuốc khách này đã đón được khách.", "Thông báo");
                        return;
                    }
                    else if (m.OpStatus == (int)Enum_Bookings_OpStatus.ChapNhan)
                    {
                        new MessageBox.MessageBoxBA().Show("[Không xóa được] - Cuốc khách này đã ghép xe.", "Thông báo");
                        return;
                    }
                    var rs = new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa cuốc này không?", "Thông báo",
                        MessageBoxButtons.YesNo);
                    if (rs.ToLower() == ("YES").ToLower())
                    {

                        //m.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                        m.DoDelete();
                        if (m.FK_TaxiReturn > 0)
                        {
                            TaxiReturn_Process.TripUpdateStatus(m.FK_TaxiReturn, ThongTinCauHinh.CompanyID,
                      Trip.Status.KetThuc);
                        }
                        if (!IsDieuXe)
                            btnSearch.PerformClick();
                    }

                }
                else
                {
                    //  new MessageBox.MessageBox().Show("Chưa chọn cuốc khách");
                }
            }
        }

        private void GridDaGhepCuoc()
        {
            if (gridView_Bookings.GetFocusedRow() != null)
            {
                var m = gridView_Bookings.GetFocusedRow().As<Booking>();
                if (string.IsNullOrEmpty(m.OpVehicle) || m.FK_TaxiReturn>0)
                {
                    new MessageBox.MessageBoxBA().Show("Cuốc ghép khách phải là cuốc đã được gán xe");
                    return;
                }
                m.OpAcceptedTime = TaxiReturn_Process.timerServer;
                m.OpStatus = (int)Enum_Bookings_OpStatus.ChapNhan;
                m.Update();
            }
        }

        private void GridDaDonDuocKhach()
        {
            if (ThongTinDangNhap.HasPermission(StaxiPermission.GhepXeChieuVe))
            {
                if (gridView_Bookings.GetFocusedRow() != null)
                {

                    var m = gridView_Bookings.GetFocusedRow().As<Booking>();
                    if (string.IsNullOrEmpty(m.OpVehicle) || m.FK_TaxiReturn == 0)//
                    {
                        new MessageBox.MessageBoxBA().Show("Cuốc đón khách phải là cuốc đã được gán xe");
                        return;
                    }
                    //m.OpAcceptedUser = ThongTinDangNhap.USER_ID;
                    m.OpStatus = (int)Enum_Bookings_OpStatus.DaDonKhach;
                    m.DaDonDuocKhach();
                    TaxiReturn_Process.TripUpdateStatus(m.FK_TaxiReturn, ThongTinCauHinh.CompanyID, Trip.Status.KhachDaLenXe);
                    if (!IsDieuXe)
                        btnSearch.PerformClick();
                    else _iSearch = 0;
                }
            }
            
        }
        #endregion

        private void txtSoDT_EditValueChanged(object sender, EventArgs e)
        {
            ReSearch();
        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var _model = gridView_Bookings.GetFocusedRow<Booking>();
            if (_model == null) return;
            int G_XNCode = ThongTinCauHinh.CompanyID;

            #region Trường hợp 1:Khách hàng hủy
            if (_model.OpCommand == m_HuyDieu)
            {
                //Bạn có muốn xóa cuốc khách chiều về này không ?
                //    if (new MessageBox.MessageBox().Show("Khách hàng hủy cuốc chiều về ?", "Thông báo", MessageBoxButtons.YesNo).ToLower() == "yes".ToLower())
                {
                    try
                    {
                          //cập nhật trạng thái của xe đường dài.    
                            var xddd = new XeDiDuongDai();
                           xddd.UpdateStatus(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach, ThongTinDangNhap.USER_ID);
                            _model.UpdateStatus(_model.PK_BooID, Enum_Bookings_OpStatus.KhachHangHuy, m_HuyDieu, ThongTinDangNhap.USER_ID);

                        if (_model.FK_TaxiReturn > 0)
                            TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.DangDi);
                        //  this.Close();
                    }
                    catch (Exception ex)
                    {
                        new Log().WriteLog(ThongTinDangNhap.USER_ID, "ctrlListBook\\kếtThúcToolStripMenuItem_Click", DateTime.Now, ex.Message);
                        //  ShowMessageFail("[KH hủy] Quá trình lưu xảy ra bị lỗi");
                    }
                }
                return;
            }
            #endregion

            #region Từ chối
            if (_model.FK_TaxiReturn == 0)
            {
                new MessageBox.MessageBoxBA().Show("Cuốc khách chưa gián xe.\nvui lòng chọn trạng thái từ chối");
                return;
            }   
            #endregion

            #region Trường hợp 2:Đã ghép.
            else
            {
                #region Mobile đã gặp xe
                if (_model.OpCommand == m_DaGapXe)
                {
                    try
                    {
                        string rs = string.Empty;
                        var themTrip = new XeDiDuongDai();
                        var address = new AutoCompleteAddress();
                        address.Bind();

                        #region Khởi tạo trip mới và chưa lưu
                        themTrip.ID = _model.FK_TaxiReturn;
                        try
                        {
                            //Thiếu : Thêm ID cha vào để quan hệ
                            if (themTrip.GetByKey())
                            {
                                themTrip.ParentID = _model.FK_TaxiReturn;
                                themTrip.ID = 0;
                                themTrip.LoTrinh = string.Empty;
                                themTrip.LoTrinh_Diem = string.Empty;
                                themTrip.KmDuKien = 0;
                                themTrip.TrangThai = (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach;
                                themTrip.CreatedDate = TaxiReturn_Process.timerServer;
                                themTrip.CreatedByUser = ThongTinDangNhap.USER_ID;
                                themTrip.UpdatedDate = null;
                                themTrip.UpdatedByUser = string.Empty;
                                // thời điểm bắt đầu của lái xe.
                                themTrip.ThoiDiemDi = themTrip.TGDuKien;
                                //_modelDetail.B
                                themTrip.DiaDiemDen = _model.ToAdress;
                                //address.Text = themTrip.DiaDiemDen;
                                //address.ReSearch();
                                themTrip.FK_QuanHuyenDenID = address.HuyenId;
                                themTrip.FK_TinhThanhDenID = address.TinhId;
                                themTrip.Den_ViDo = _model.ToLat;
                                themTrip.Den_KinhDo = _model.ToLng;


                                //lấy tọa độ của xe.
                                var _xeOnline = WCFService_Common.GetXeOnlineBySHX(themTrip.FK_SoHieuXe);
                                themTrip.Xe_KinhDo = _xeOnline.KinhDo;
                                themTrip.Xe_ViDo = _xeOnline.ViDo;

                                // Lộ trình này là lộ trình của điểm DC
                                var lotrinh = TaxiReturn_Process.LayLoTrinh(themTrip.Di_ViDo, themTrip.Di_KinhDo, themTrip.Den_ViDo, themTrip.Den_KinhDo);
                                themTrip.LoTrinh = lotrinh.LoTrinh_DiaChi;
                                themTrip.LoTrinh_Diem = lotrinh.LoTrinh_ToaDo;
                                themTrip.KmDuKien = (int)lotrinh.Distance;

                                //Tính thời gian đi của book.
                                int SoPhutDiQuangDuongBC = TaxiReturn_Process.TinhThoiGianDiHetQuangDuong(_model.BC_Route_Distance);
                                themTrip.TGDuKien = themTrip.TGDuKien.AddMinutes(SoPhutDiQuangDuongBC); // là thời điểm đến điểm C.
                                themTrip.ThoiDiemVe = themTrip.TGDuKien;
                                Xe objXe1 = new Xe().GetChiTietXe(themTrip.FK_SoHieuXe);
                                if (objXe1 != null)
                                {
                                    themTrip.BienSoXe = objXe1.BienKiemSoat;
                                    TinhTienTheoKm objTinhTien = new TinhTienTheoKm(objXe1.LoaiXeID, themTrip.KmDuKien);
                                    themTrip.TienDuKien = objTinhTien.TongTien1Chieu;
                                }
                            }

                        }
                        catch (Exception)
                        {

                        }
                        #endregion

                        if (themTrip.KmDuKien >= g_KmDuKien)
                            rs = new MessageBox.MessageBoxBA().Show("Xe này có muốn đón cuốc chiều về khác không ?", "Thông báo", MessageBoxButtons.YesNo);

                        if (rs == "Yes")
                        {
                            themTrip.Insert();
                        }
                        themTrip.UpdateStatusV2(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.None, ThongTinDangNhap.USER_ID, true, Enum_Bookings_OpStatus.MobileKetThuc, _model.PK_BooID);

                        #region Send server
                        try
                        {
                            TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.KetThuc);
                            if (rs == "Yes" && themTrip.ID > 0)
                            {
                                var rsBoot = TaxiReturn_Process.ReplaceTrip(themTrip.ParentID, themTrip);
                                themTrip.UpdateIsAddedStaxi(themTrip.ID, ThongTinDangNhap.USER_ID, rsBoot);
                            }
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);

                        }

                        //chỉ cần Kết thúc cái Book chưa có hàm gửi lên server
                        try
                        {
                            //  if (!G_DoNotSendToServer)
                            TaxiReturn_Process.FinishVehicleReturn(_model.ClientKey);
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                        }

                        #endregion


                    }
                    catch (Exception ex)
                    {
                        new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Cập nhật dữ liệu lỗi:" + ex.Message);

                    }
                }
                #endregion

                #region Mobile chưa gặp xe
                else
                {
                    try
                    {
                        #region Điều hành kết thúc
                        string rs = string.Empty;
                        var themTrip = new XeDiDuongDai();
                        var address = new AutoCompleteAddress();
                        address.Bind();

                        #region Khởi tạo trip mới và chưa lưu
                        themTrip.ID = _model.FK_TaxiReturn;
                        try
                        {
                            //Thiếu : Thêm ID cha vào để quan hệ
                            if (themTrip.GetByKey())
                            {
                                themTrip.ParentID = _model.FK_TaxiReturn;
                                themTrip.ID = 0;
                                themTrip.LoTrinh = string.Empty;
                                themTrip.LoTrinh_Diem = string.Empty;
                                themTrip.KmDuKien = 0;
                                themTrip.TrangThai = (int)Enum_XeBaoDiDuongDai_TrangThai.ChoGhepKhach;
                                themTrip.CreatedDate = TaxiReturn_Process.timerServer;
                                themTrip.CreatedByUser = ThongTinDangNhap.USER_ID;
                                themTrip.UpdatedDate = null;
                                themTrip.UpdatedByUser = string.Empty;    
                                // thời điểm bắt đầu của lái xe.
                                themTrip.ThoiDiemDi = themTrip.TGDuKien;
                                //_modelDetail.B
                                themTrip.DiaDiemDen = _model.ToAdress;
                                //address.Text = themTrip.DiaDiemDen;
                                //address.ReSearch();
                                themTrip.FK_QuanHuyenDenID = address.HuyenId;
                                themTrip.FK_TinhThanhDenID = address.TinhId;
                                themTrip.Den_ViDo = _model.ToLat;
                                themTrip.Den_KinhDo = _model.ToLng;
                               

                                //lấy tọa độ của xe.
                                var _xeOnline = WCFService_Common.GetXeOnlineBySHX(themTrip.FK_SoHieuXe);
                                themTrip.Xe_KinhDo = _xeOnline.KinhDo;
                                themTrip.Xe_ViDo = _xeOnline.ViDo;

                                // Lộ trình này là lộ trình của điểm DC
                                var lotrinh = TaxiReturn_Process.LayLoTrinh(themTrip.Di_ViDo, themTrip.Di_KinhDo, themTrip.Den_ViDo, themTrip.Den_KinhDo);
                                themTrip.LoTrinh = lotrinh.LoTrinh_DiaChi;
                                themTrip.LoTrinh_Diem = lotrinh.LoTrinh_ToaDo;
                                themTrip.KmDuKien = (int)lotrinh.Distance;

                                //Tính thời gian đi của book.
                                int SoPhutDiQuangDuongBC = TaxiReturn_Process.TinhThoiGianDiHetQuangDuong(_model.BC_Route_Distance);
                                themTrip.TGDuKien = themTrip.TGDuKien.AddMinutes(SoPhutDiQuangDuongBC); // là thời điểm đến điểm C.
                                themTrip.ThoiDiemVe = themTrip.TGDuKien;
                                Xe objXe1 = new Xe().GetChiTietXe(themTrip.FK_SoHieuXe);
                                if (objXe1 != null)
                                {
                                    themTrip.BienSoXe = objXe1.BienKiemSoat;
                                    TinhTienTheoKm objTinhTien = new TinhTienTheoKm(objXe1.LoaiXeID, themTrip.KmDuKien);
                                    themTrip.TienDuKien = objTinhTien.TongTien1Chieu;
                                }
                              
                            }

                        }
                        catch (Exception)
                        {

                        }
                        #endregion

                        if (themTrip.KmDuKien >= g_KmDuKien)
                            rs = new MessageBox.MessageBoxBA().Show("Xe này có muốn đón cuốc chiều về khác không ?", "Thông báo", MessageBoxButtons.YesNo);
                        

                            #region nếu chọn đón cuốc chiều về khác thì Thêm mới Trip
                            if (rs == "Yes")
                            {
                                themTrip.Insert();
                            }
                            themTrip.UpdateStatusV2(_model.FK_TaxiReturn, Enum_XeBaoDiDuongDai_TrangThai.None, ThongTinDangNhap.USER_ID, true, Enum_Bookings_OpStatus.KetThuc, _model.PK_BooID);
                            #endregion
                     
                        #region Send server
                        try
                        {
                            TaxiReturn_Process.TripUpdateStatus(_model.FK_TaxiReturn, G_XNCode, Services.FastTaxi_OperationService.Trip.Status.KetThuc);
                            if (rs == "Yes" && themTrip.ID > 0)
                            {
                                var rsBoot = TaxiReturn_Process.ReplaceTrip(themTrip.ParentID, themTrip);
                                themTrip.UpdateIsAddedStaxi(themTrip.ID, ThongTinDangNhap.USER_ID, rsBoot);
                            }
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);

                        }

                        //chỉ cần Kết thúc cái Book chưa có hàm gửi lên server
                        try
                        {
                            //if (!G_DoNotSendToServer)
                            TaxiReturn_Process.FinishVehicleReturn(_model.ClientKey);
                        }
                        catch (Exception ex)
                        {
                            new Log().WriteLog(ThongTinDangNhap.USER_ID, "Lưu trên form khách cần xe", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                        }

                        #endregion
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        new Log().WriteLog(ThongTinDangNhap.USER_ID, "Kết thúc trên lưới Book", DateTime.Now, "Gửi lên server sảy ra lỗi:" + ex.Message);
                        new MessageBox.MessageBoxBA().Show("Quá trình xử lý sảy ra lỗi vui lòng liên hệ với quản trị");
                    }


                }
                #endregion

            }
            #endregion

        }

        private void txtDiaChiDon_TextChanged(object sender, EventArgs e)
        {
            ReSearch();
        }

        private void gridView_Bookings_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void gridView_Bookings_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (EventGridSelect != null)
            {
                var vehicle = gridView_Bookings.GetRowCellValue(e.FocusedRowHandle, "OpVehicle");
                if (vehicle != null && vehicle.ToString() != string.Empty)
                {
                    EventGridSelect(vehicle.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n=frmInfo.PostionInfo.Count(p => p == 0);
            for (int i = 0; i < n+1; i++)
            {
                new frmInfo().Show();
            }
        }

       
    }

}
