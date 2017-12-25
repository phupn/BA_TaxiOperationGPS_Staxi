#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

using Taxi.Business;
using Taxi.Business.QuanTri;
using Taxi.Business.ThongTinPhanAnh;
using Taxi.Common.EnumUtility;
using Taxi.Controls;
using Taxi.Controls.Base;
using Taxi.Controls.DanhMuc;
using Taxi.Controls.DanhSach.DMCommand;
using Taxi.Data.G5.DanhMuc;
using Taxi.GUI;
using Taxi.Services;
using Taxi.Utils;
using TaxiApplication.Base;
using Taxi.Common.Extender;
using Taxi.Utils.Enums;
using Taxi.Business.KhachDat;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiApplication
{
    /// <summary>
    /// Đang dùng để test cho nâng cấp!
    /// </summary>
    public partial class FormMainRibbon : FormRibbon
    {
        #region === Define ===
        private bool hasNewCallPending = false;
        private int SoDong = 50;
        private frmDienThoaiInputDataNew_V3 formInput;
        private BackgroundWorker PingApp;
        private bool IsDaGiaiQuyet = false;
        private bool IsShowCommandHelp = false;
        #endregion

        #region === Form_Load ====
        public FormMainRibbon()
        {
            InitializeComponent();
        }

        private void FormMainRibbon_Load(object sender, EventArgs e)
        {
            if (DieuHanhTaxi.CheckConnection())
            {

                // Lưu ý:Làm hàm Load tối giản lại càng tốt
                RealTimeEnvironment.IniRealTime();

                PingApp = new BackgroundWorker();
                PingApp.DoWork += PingApp_DoWork;
                using (var PingWcf = new BackgroundWorker())
                {
                    PingWcf.DoWork += (sender1, e1) => Service_Common.PingWcf();
                    PingWcf.RunWorkerAsync();

                }
                if (Config_Common.DienThoai_KhungDiaChi == KhungDiaChi.Duoi)
                {
                    PanelThongTinDiaChi.Dock = DockStyle.Bottom;
                }
                else
                {
                    PanelThongTinDiaChi.Dock = DockStyle.Top;
                }
                if (Config_Common.GridConfig != 1)
                {
                    btnAnHien.PerformClick();
                    btnAnHien.Visible = false;
                }

                #region ==== GridControl ====

                //  RealTimeEnvironment.LineVung = "124;179";
                // Lấy cấu hình.
                #region === Ini Data ===
                grvChoGiaiQuyet.FuncGetTimerServer = () => RealTimeEnvironment.TimeServer;
                grvChoGiaiQuyet.FuncGetAll = CuocGoi.G5_DIENTHOAI_LayAllCuocGoi;
                grvChoGiaiQuyet.FuncGetNew = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiMoi_FT;
                grvChoGiaiQuyet.FuncGetUpdate = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai;
                grvChoGiaiQuyet.FuncGetDelete = (Line, LsKeys) => CuocGoi.G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(LsKeys, Line);
                grvChoGiaiQuyet.ActionPopUp += grvChoGiaiQuyet_ActionPopUp;
                grvChoGiaiQuyet.EventActionStep += grvChoGiaiQuyet_EventActionStep;

                grvCuocKhachLineKhac.FuncGetTimerServer = () => RealTimeEnvironment.TimeServer;
                grvCuocKhachLineKhac.FuncGetAll = CuocGoi.DIENTHOAI_LayAllCuocGoi_Khac;
                grvCuocKhachLineKhac.FuncGetNew = CuocGoi.DIENTHOAI_LayDSCuocGoiMoi_V3_Khac;
                grvCuocKhachLineKhac.FuncGetUpdate = CuocGoi.DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3_Khac;
                grvCuocKhachLineKhac.FuncGetDelete = (Line, LsKeys) => CuocGoi.DIENTHOAI_LayCacIDCuocGoiKetThuc_Khac(LsKeys, Line);
                #endregion

                grvCuocKhachLineKhac.LoadAll();
                grvChoGiaiQuyet.LoadAll();
                grvChoGiaiQuyet.StartRealTime();
                #endregion

                #region === Form Input ===
                formInput = new frmDienThoaiInputDataNew_V3(RealTimeEnvironment.ListDataAutoComplete, false, RealTimeEnvironment.DMVung_GPS);

                formInput.OKCloseFormEvent += SaveData_Click;
                formInput.HienThiCuocMoiEvent += g_frmInput_HienThiCuocMoiEvent;
                formInput.GetTimeServerEvent += g_frmInput_GetTimeServerEvent;
                formInput.EventCallOut += g_frmInput_EventCallOut;
                #endregion

                IsShowCommandHelp = GetHelpCommand();
                panelTopHelp.Visible = IsShowCommandHelp;

                if (!CheckIn())
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.",
                    "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        #endregion

        #region === Form Input ===
        private void g_frmInput_EventCallOut(string PhoneNumber, string DiaChi)
        {
            
        }

        private DateTime g_frmInput_GetTimeServerEvent()
        {
            return RealTimeEnvironment.TimeServer;
        }

        private void g_frmInput_HienThiCuocMoiEvent(object sender, EventArgs e)
        {
            if (hasNewCallPending)
                grvChoGiaiQuyet.ShowPopUp(); 
            hasNewCallPending = false;
        }

        private void SaveData_Click(object sender, TaxiEventArgs e)
        {
            if (formInput.g_DialogResult)
            {
                var cuocGoi = formInput.GetCuocGoi;
                var checkChange = formInput.GetCheckChange;
                int soLuong = 0;
                if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp) // điều đàm thì không cho phép sao chép.
                {
                    soLuong = cuocGoi.SoLuong - 1;
                    cuocGoi.SoLuong = 1;
                }

                cuocGoi.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini && Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS && cuocGoi.Vung == 0)
                {
                    cuocGoi.G5_Type = Enum_G5_Type.DienThoai;
                }
                else
                    if ((Config_Common.CoCheDieuApp != EnumCoCheDieuApp.DieuChiDinhGPS && QuanTriCauHinh.MoHinh == MoHinh.TD_DT) && cuocGoi.GPS_KinhDo == 0 && cuocGoi.GPS_ViDo == 0) //địa chỉ không xác định được thì chuyển sang chế độ điều đàm.
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    }

                bool DieuAppFirst = false;
                Guid BookId = Guid.Empty;
                if (cuocGoi.BookId == Guid.Empty && 
                    cuocGoi.G5_Type == Enum_G5_Type.DieuApp &&
                    cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                    cuocGoi.TrangThaiLenh != TrangThaiLenhTaxi.KetThucCuaDienThoai)//|| cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe
                {
                    cuocGoi.BookId = BookId = Guid.NewGuid();
                    cuocGoi.XeNhan = string.Empty;
                    checkChange.XeNhan = false;
                    DieuAppFirst = true;
                }
                if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe)
                {
                    //cuocGoi.BookId = BookId = Guid.Empty;
                    cuocGoi.XeNhan = string.Empty;
                    cuocGoi.XeDon = string.Empty;
                    cuocGoi.GhiChuDienThoai = string.Empty;
                    checkChange.XeNhan = false;
                    checkChange.XeDon = false;
                    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.TrangThaiKhac;
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    cuocGoi.LenhDienThoai = string.Empty;
                    cuocGoi.GhiChuDienThoai = string.Empty;
                    DieuAppFirst = true;
                    if (Config_Common.DienThoai_DieuApp_DieuLaiGiuCuocCu)
                    {
                        BookId = cuocGoi.BookId;
                    }
                    else
                    {
                        cuocGoi.BookId = BookId = Guid.NewGuid();
                    }
                }
                bool updateSuccess ;
                if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
                    updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoi);
                else
                    updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi(cuocGoi, checkChange);

                if (!updateSuccess)
                {
                    MessageBox.Show(this, "Không lưu được dữ liệu, vui lòng liên hệ với quản trị", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //if (formInput.UpdateCustomerHabit) //Có được phép cập nhật thói quen khách hàng không?
                    //{
                    //    try
                    //    {
                    //        Task.Factory.StartNew(() => { G5ServiceSyn.CustomerHabitUpdate(cuocGoi.PhoneNumber, cuocGoi.DiaChiDonKhach, cuocGoi.ThoiDiemGoi); });
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        LogError.WriteLogError("UpdateCustomerHabit", ex);
                    //    }
                    //}
                    //khởi tạo cuốc ở server rồi update BookId vào db
                    if (DieuAppFirst)
                    {
                        var toaDoDon = new LatLngOperation(cuocGoi.GPS_ViDo, cuocGoi.GPS_KinhDo);
                        var toaDoTra = new LatLngOperation(cuocGoi.GPS_ViDo_Tra, cuocGoi.GPS_KinhDo_Tra);
                        //if (Config_Common.DienThoai_DieuLai_BookIdOld && DieuLai && BookIdOld != Guid.Empty)
                        //{
                        //    BookId = cuocGoi.BookId = BookIdOld;
                        //    CuocGoi.G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(cuocGoi.BookId, cuocGoi.IDCuocGoi, Enum_G5_Type.DieuApp, cuocGoi.LenhDienThoai);
                        //}
                        //G5ServiceSyn.InitTripSyn(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach, toaDoDon, cuocGoi.DiaChiTraKhach, toaDoTra, cuocGoi.GhiChuDienThoai, (byte)cuocGoi.SoLuong, cuocGoi.G5_CarType, 0, cuocGoi.PhoneNumber, null, soLuong, false, BookId, cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe ? string.Empty : cuocGoi.XeNhan);
                    }

                    #region GOI KHIEU NAI

                    else if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiKhieuNai)
                    {
                        // sử dụng vùng 11 làm vùng xử lý cuốc khiếu nại. 
                        // nv ĐTV nhập vùng 11 thì chuyển sang cskh

                        if (cuocGoi.Vung == 11)
                        {
                            ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
                            objPhanAnh.DienThoai = cuocGoi.PhoneNumber;
                            objPhanAnh.TenKhachHang = string.Empty;
                            objPhanAnh.NoiDung = cuocGoi.DiaChiDonKhach;
                            objPhanAnh.NhanVienTiepNhan = string.Empty;

                            if (objPhanAnh.InsertCuocGoi(0, 5, 0, cuocGoi.IDCuocGoi) > 0)
                            {
                                if (Config_Common.KetThucCuocKhieuNai)//Kết thúc cuốc khiếu nại nếu chọn 1
                                {
                                    DieuHanhTaxi.UpdateCuocGoiKhieuNaiKetThuc(cuocGoi.IDCuocGoi, objPhanAnh.NoiDung, cuocGoi.MaNhanVienDienThoai);
                                    grvChoGiaiQuyet.FindAndRemove(cuocGoi);
                                }
                                //DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(this, "Không chuyển được dữ liệu sang bộ đàm, xin hãy liên hệ với quản trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                        }
                    }

                    #endregion
                    grvChoGiaiQuyet.FindAndUpdate(cuocGoi);
                }
            }
        }
        #endregion

        #region === Ping Kết nối App ===
        void PingApp_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CheckConnectServerApp();
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("PingApp_DoWork:", ex);
            }
        }

        /// <summary>
        /// Hiển thị trạng thái kết nối điều app
        /// </summary>
        private void CheckConnectServerApp()
        {
            if (G5ServiceSyn.Ping() == Enum_G5_Ping.PingSu)
            {
                btnCheckApp.Caption = "Điều App OK";
                btnCheckApp.LargeGlyph = Properties.Resources.App_Connect_16x;
            }
            else
            {
                btnCheckApp.Caption = "Lỗi điều App";
                btnCheckApp.LargeGlyph = Properties.Resources.App_Error_16x;
                LogError.WriteLogErrorForDebug("CheckConnectServerApp: Lỗi điều App");
            }
        }
        #endregion

        #region === grvChoGiaiQuyet ===
        private void grvChoGiaiQuyet_EventActionStep(Taxi.Controls.Base.Controls.Grids.Extends.RealTimeStep obj)
        {
            grvCuocKhachLineKhac.ActionStep(obj);
            if (obj == Taxi.Controls.Base.Controls.Grids.Extends.RealTimeStep.Step_1)
            {
                if (!PingApp.IsBusy)
                    PingApp.RunWorkerAsync();
                if (IsDaGiaiQuyet)
                {
                    grdDaGiaiQuyet.DataSource = CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyet(RealTimeEnvironment.LineVung, SoDong);
                    IsDaGiaiQuyet = false;
                }
            }
            else if (obj == Taxi.Controls.Base.Controls.Grids.Extends.RealTimeStep.Step_3)
            {
                if (Config_Common.DienThoai_DieuApp_ChuyenDam == 0 || Config_Common.DienThoai_DieuApp_ChuyenDam == 3)
                {
                    // nếu  Cuốc điều app  và 1'30 ko có xe nhận thì thì tự đông chuyển sang cuốc điều đàm.
                    foreach (var item in grvChoGiaiQuyet.ListData.Where(p => p.G5_Type == Enum_G5_Type.DieuApp && string.IsNullOrEmpty(p.XeNhan) && p.G5_SendDate != null).ToList())
                    {
                        if ((RealTimeEnvironment.TimeServer - item.G5_SendDate.Value).TotalSeconds > Config_Common.DienThoai_DieuApp_ThoiGianChuyenDam)
                        {
                            CuocGoi.G5_DIENTHOAI_UpdateBookTimeout(item.BookId);
                        }
                    }
                }

            }
        }
        private void grvChoGiaiQuyet_ActionPopUp(CuocGoi obj)
        {
            if (formInput != null && RealTimeEnvironment.IsLogin)
            {
                if (formInput.Visible)
                {
                    hasNewCallPending = true;
                    formInput.HienThiThongBaoCoCuocGoiMoi();
                }
                else
                {
                    formInput.LoadCuocGoi(obj);
                }
            }
        }
        private void grvChoGiaiQuyet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var Row = grvChoGiaiQuyet.FocusedRow;
            if (Row != null)
            {
                lblDienThoai.Text = Row.PhoneNumber;
                lblDiaChiDon.Text = Row.DiaChiDonKhach;
                lblLenhDHV.Text = Row.G5_Type == Enum_G5_Type.DieuApp ? Row.LenhLaiXe : Row.LenhTongDai;
            }
        }
        private void grvChoGiaiQuyet_DoCommand(CuocGoi arg1, G5Command arg2)
        {
            if (arg2.CmdServer != IServerFunction.None && arg1.G5_Type == Enum_G5_Type.DieuApp)
            {
                if (Config_Common.DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh)
                {
                    if ((G5ServiceSyn.PingServer != Enum_G5_Ping.PingSu && arg1.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong)
                        || (G5ServiceSyn.PingServer_XHD != Enum_G5_Ping.PingSu && arg1.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong))
                    {
                        MessageBox.Show(this, "Đang mất kết nối tới Server ĐH.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (arg2.CommandType == G5CommandType.None)
            {
                string tienTo = string.Empty;
                if (arg1.G5_Type == Enum_G5_Type.DieuApp && !string.IsNullOrEmpty(arg1.LenhLaiXe) && arg1.LenhLaiXe.IndexOf('[') > 0 && arg1.LenhLaiXe.IndexOf(']') > 0)
                {
                    var start = arg1.LenhLaiXe.IndexOf('[') + 1;
                    var end = arg1.LenhLaiXe.IndexOf(']');
                    if (start < end)
                    {
                        tienTo = arg1.LenhLaiXe.Substring(start, end - start);
                    }

                }
                else if (!string.IsNullOrEmpty(arg1.LenhTongDai) && arg1.LenhTongDai.IndexOf('[') > 0 && arg1.LenhTongDai.IndexOf(']') > 0)
                {
                    var start = arg1.LenhTongDai.IndexOf('[') + 1;
                    var end = arg1.LenhTongDai.IndexOf(']');
                    if (start < end)
                    {
                        tienTo = arg1.LenhTongDai.Substring(start, end - start);
                    }
                }
                if (string.IsNullOrEmpty(tienTo))
                    arg1.LenhDienThoai = arg2.Command;
                else
                    arg1.LenhDienThoai = string.Format("{0}[{1}]", arg2.Command, tienTo);
            }
            else
            {
                if (new FrmInputGridView(arg1, arg2).ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            if (arg2.CallStatus != TrangThaiCuocGoiTaxi.None)
            {
                arg1.TrangThaiCuocGoi = arg2.CallStatus;
            }
            if (arg2.Status != TrangThaiLenhTaxi.None)
            {
                arg1.TrangThaiLenh = arg2.Status;
            }
            if (arg2.CallType != KieuCuocGoi.None)
            {
                arg1.KieuCuocGoi = arg2.CallType;
            }

            if (arg2.CmdServer != IServerFunction.None && arg1.G5_Type == Enum_G5_Type.DieuApp)
            {
                //G5ServiceSyn.SendServer(arg2.CmdServer, arg2.CmdId, string.IsNullOrEmpty(arg2.CmdMsg) ? arg1.GhiChuDienThoai : arg2.CmdMsg, arg1.BookId, arg1.XeNhan);
            }
            CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi(arg1);
            if (arg1.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc || arg1.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
            {
                grvChoGiaiQuyet.FindAndRemove(arg1);
            }
            else
            {
                grvChoGiaiQuyet.FindAndUpdate(arg1);
            }
        }
        private void grvChoGiaiQuyet_GridStyles(DevExpress.Utils.AppearanceObject pAppearance, string FieldName, int RowIndex, bool IsRow)
        {
            var row = grvChoGiaiQuyet.GetRow(RowIndex);
            if (row == null) return;
            if (IsRow)//Cho phép thiết lập mầu sắc cho cả dòng.
            {
                if (row.LenhDienThoai.ToUpper() == "SÂN BAY".ToUpper() || row.SanBay_DuongDai == "1")
                {
                    pAppearance.BackColor = Config_Common.Grid_CuocSanBay_BackGround;
                }
            }
            else//Cho phép thiết mầu sắc cho từ ô dữ liệu
            {
                if (FieldName.Contains("DiaChiDonKhach") && row.FT_IsFT && row.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                {
                    pAppearance.BackColor = Color.Yellow;
                }
            }
        }
        #endregion

        #region === Đã giải quyết ===
        private void tabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabPageDaGiaiQuyet)
            {
                IsDaGiaiQuyet = true;
            }
            else if (e.Page == tabPageTimKiemCuocGoi)
            {
                txtSearchPhone.Focus();
            }
        }

        private void mnuItem50_Click(object sender, EventArgs e)
        {
            SoDong = 50;
            IsDaGiaiQuyet = true;
        }

        private void mnuItem150_Click(object sender, EventArgs e)
        {

            SoDong = 150;
            IsDaGiaiQuyet = true;
        }

        private void mnuItem200_Click(object sender, EventArgs e)
        {

            SoDong = 200;
            IsDaGiaiQuyet = true;
        }

        private void mnuItem100_Click(object sender, EventArgs e)
        {

            SoDong = 100;
            IsDaGiaiQuyet = true;
        }
        private void mnuItemChuyenCuocGoi_Click(object sender, EventArgs e)
        {
            if (RealTimeEnvironment.IsLogin)
            {
                var row = grvDaGiaiQuyet.GetFocusedRow() as CuocGoi;
                if (row != null)
                {
                    if (MessageBox.Show(string.Format("Bạn có muốn chuyển cuộc gọi: {0} không ?", row.DiaChiDonKhach), "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CuocGoi.DIENTHOAI_UpdateCGKetThuc2ChuaGiaiQuyet(row.IDCuocGoi);
                        grdDaGiaiQuyet.DataSource = CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyet(RealTimeEnvironment.LineVung, SoDong);
                        IsDaGiaiQuyet = false;
                    }
                }
            }
        }
        #endregion

        #region=== label command===
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (IsShowCommandHelp)
            {
                panelTopHelp.Visible = !panelTopHelp.Visible;
            }
        }
        private bool GetHelpCommand()
        {
            try
            {
                var obj = RealTimeEnvironment.DicCommand.Join(RealTimeEnvironment.DicCommandModule, x => x.Id, y => y.CommandId, (x, y) => x);
                if (!obj.Any())
                {
                    panelTopHelp.Visible = false;
                    return false;
                }
                var lst = obj.Where(p => p.Shortcuts != PhimTat.None).OrderBy(x => x.OrderBy).ToList();
                {
                    if (lst.Count > 0)
                    {
                        panelTopHelp.Visible = true;
                        panelTopHelp.Controls.Clear();
                        int row = 0;
                        int col = 0;
                        int height = 3;
                        int with = 10;
                        int withMax = 0;
                        int RowCount = 4;
                        int lblHeight = 0;
                        for (int i1 = 0; i1 < lst.Count; i1++)
                        {
                            if (row >= RowCount)
                            {
                                row = 0;
                                col = col + 1;
                                with = with + withMax + 5;
                                withMax = 0;
                            }
                            var cmd = lst[i1];
                            var lbl = new Label();
                            lbl.AutoSize = true;
                            lbl.MaximumSize = new Size(500, lbl.MaximumSize.Height);
                            panelTopHelp.Controls.Add(lbl);
                            lbl.ForeColor = Color.Chocolate;
                            string lblPhim = typeof(PhimTat).GetField(cmd.Shortcuts.ToString()).GetAttribute<EnumItemAttribute>().Name;
                            lbl.Text = string.Format("Phím {0}\t : {1}", lblPhim, cmd.Command.WhenEmpty(() => "Xóa lệnh"));
                            lbl.Location = new Point(with, (lbl.Height + 5) * row + height);
                            if (lbl.Width > withMax) withMax = lbl.Width;
                            lblHeight = lbl.Height;
                            row++;
                        }
                        panelTopHelp.Width = with + withMax + 10;
                        panelTopHelp.Height = (lblHeight + 5) * RowCount + 2 * height - 1;
                        panelTopHelp.Left = this.Width - panelTopHelp.Width - 20;
                        panelTopHelp.Top = 60;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetHelpCommand", ex);
            }
            return false;

        }

        private void FormMainRibbon_Resize(object sender, EventArgs e)
        {
            //panelTopHelp.Left = this.Width - panelTopHelp.Width - 20;
            if (this.WindowState == FormWindowState.Maximized)
            {
                panelTopHelp.Top = 60;
            }
            else
            {
                panelTopHelp.Top = 53;
            }
        }
        #endregion

        #region === Tìm kiếm nhanh thông tin cuốc ==
        private void SearchCuocGoi()
        {
            string soDt = txtSearchPhone.Text.Trim();
            string diaChi = txtSearchAddress.Text.Trim();
            string xeNhan = txtXeNhan.Text.Trim();
            string kenh = "";

            if (CbkSearchKenh1.Checked) kenh = "1;";
            if (CbkSearchKenh2.Checked) kenh = kenh + "2;";
            if (CbkSearchKenh3.Checked) kenh = kenh + "3;";
            if (CbkSearchKenh4.Checked) kenh = kenh + "4";
            grdTimKiemCuocGoi.DataSource = CuocGoi.DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet_V2(kenh, soDt, diaChi, xeNhan);
        }

        private void txtSearchPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchCuocGoi();
            }
        }

        private void txtSearchAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchCuocGoi();
            }
        }

        private void CbkSearchKenh1_CheckedChanged(object sender, EventArgs e)
        {
            SearchCuocGoi();
        }
        #endregion

        #region === Menu Ribbon ===

        private void btnAnHien_Click(object sender, EventArgs e)
        {
            if (!slChoGiaiQuyet.Panel2Collapsed)
            {
                btnAnHien.Image = Properties.Resources.previous;
                slChoGiaiQuyet.Panel2Collapsed = true;
                slChoGiaiQuyet.Panel2.Hide();
            }
            else
            {
                btnAnHien.Image = Properties.Resources.forward;
                slChoGiaiQuyet.Panel2Collapsed = false;
                slChoGiaiQuyet.Panel2.Show();
            }
        }
        private void bbtnChenCuocGoiGoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmChenMoiMotCuocDienThoai(RealTimeEnvironment.LineVung, RealTimeEnvironment.ListDataAutoComplete))
            {
                frm.ShowDialog();
            }
        }
        private void bbtnQuanLyTapLenh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (new FrmManagerCommand().ShowDialog() == DialogResult.Yes)
            {
                //RealTimeEnvironment.ResetCommand();
                //panelTopHelp.Controls.Clear();
                //GetHelpCommand();
            }
        }
        private void btnLuuHienThiLuoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl1.SelectedTabPage == tabPageChoGiaiQuyet)
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvChoGiaiQuyet.Name, ThongTinDangNhap.USER_ID, grvChoGiaiQuyet.GetLayoutFromStringXml());
            }
            else if (tabControl1.SelectedTabPage == tabPageDaGiaiQuyet)
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvDaGiaiQuyet.Name, ThongTinDangNhap.USER_ID, grvDaGiaiQuyet.GetLayoutFromStringXml());
            }
            else if (tabControl1.SelectedTabPage == tabPageTimKiemCuocGoi)
            {
                G5Layout.SaveLayout(Global.Module.ToString(), this.Name, grvTimKiemCuocGoi.Name, ThongTinDangNhap.USER_ID, grvTimKiemCuocGoi.GetLayoutFromStringXml());
            }
        }
        private void btnHienThiMacDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl1.SelectedTabPage == tabPageChoGiaiQuyet)
            {
                grvChoGiaiQuyet.ResetLayout();
            }
            else if (tabControl1.SelectedTabPage == tabPageDaGiaiQuyet)
            {
                grvDaGiaiQuyet.ResetLayout();
            }
            else if (tabControl1.SelectedTabPage == tabPageTimKiemCuocGoi)
            {
                grvTimKiemCuocGoi.ResetLayout();
            }
        }
        private void bbtnTangKichThuocLuoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl1.SelectedTabPage == tabPageChoGiaiQuyet)
            {
                grvChoGiaiQuyet.ZoomOut();
            }
            else if (tabControl1.SelectedTabPage == tabPageDaGiaiQuyet)
            {
                grvDaGiaiQuyet.ZoomOut();
            }
            else if (tabControl1.SelectedTabPage == tabPageTimKiemCuocGoi)
            {
                grvTimKiemCuocGoi.ZoomOut();
            }
        }
        private void bbtnGiamKichThuocLuoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabControl1.SelectedTabPage == tabPageChoGiaiQuyet)
            {
                grvChoGiaiQuyet.ZoomIn();
            }
            else if (tabControl1.SelectedTabPage == tabPageDaGiaiQuyet)
            {
                grvDaGiaiQuyet.ZoomIn();
            }
            else if (tabControl1.SelectedTabPage == tabPageTimKiemCuocGoi)
            {
                grvTimKiemCuocGoi.ZoomIn();
            }
        }
        private void bbtnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            CheckIn();
        }
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void bbtnKhachDat_ItemClick(object sender, ItemClickEventArgs e)
        {
            var objCuocGoi = grvChoGiaiQuyet.FocusedRow;
            if (objCuocGoi != null)
            {
                KhachDatBL objKhachDat = new KhachDatBL
                {
                    CreatedBy = ThongTinDangNhap.USER_ID,
                    DiaChi = objCuocGoi.DiaChiDonKhach,
                    SoDienThoai = objCuocGoi.PhoneNumber,
                    SoLuongXe = objCuocGoi.SoLuong,
                    ThoiDiemBatDau = DateTime.Now,
                    ThoiDiemKetThuc = DateTime.Now,
                    LoaiXe = objCuocGoi.LoaiXe,
                    ThoiDiemTiepNhan = DateTime.Now,
                    VungKenh = objCuocGoi.Vung,
                    SoPhutBaoTruoc = 10,
                    GhiChu = "",
                    IsLapLai = false,
                    GioDon = DateTime.Now.AddMinutes(10)
                };

                using (var formKhachDat = new frmKhachDat(objKhachDat, RealTimeEnvironment.ListDataAutoComplete, false))
                {
                    formKhachDat.ShowDialog();
                }
            }
        }
        private void bbtnTinhTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmTinhTienTheoKm())
            {
                frm.ShowDialog();
            }
        }
        private void bbtnDanhMucKhachDat_ItemClick(object sender,ItemClickEventArgs e)
        {
            new frmListKhachDat().Show();
        }
        private void bbtnDanhSachCongTy_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmDMDanhBaCongTy().Show();
        }
        private void bbtnQuanLyTamLenhModule_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var item = new FrmCommandModule())
            {
                item.ShowDialog();
                if (item.IsChangeCommand)
                {
                    RealTimeEnvironment.ResetCommand();
                    panelTopHelp.Controls.Clear();
                    GetHelpCommand();
                }
            }
        }
        #endregion

        #region === Đăng xuất ===
        /// <summary>
        /// check in, goi form frmCheckInOut
        /// </summary>        
        private bool CheckIn()
        {
            Text = String.Format("{0} - Điện thoại viên  [{1} - {2}]",Configuration.GetCompanyName(), RealTimeEnvironment.LineVung, RealTimeEnvironment.IpAddress);
            RealTimeEnvironment.IsLogin = false;
            frmCheckInOut frm = new frmCheckInOut();
            frm.ShowDialog();
            if (ThongTinDangNhap.USER_ID.Length > 0)
            {
                if (ThongTinDangNhap.IsUserPostionTrust(ThongTinDangNhap.USER_ID, RealTimeEnvironment.IpAddress))
                // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
                {
                }
                else
                {
                    // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
                    if (ThongTinDangNhap.IsPCCheckInWithOutUser(ThongTinDangNhap.USER_ID, RealTimeEnvironment.IpAddress))
                    {
                        var alert = MessageBox.Show("Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (alert == DialogResult.Yes)
                        {
                            ThongTinDangNhap.CheckOutByIpAddress(RealTimeEnvironment.IpAddress);
                        }
                        else
                        {
                            Application.Exit();
                            return false;
                        }
                    }
                    // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.                   
                    if (Config_Common.DangNhapNhieuMay &&
                        ThongTinDangNhap.IsUserCheckInAtOtherPC(ThongTinDangNhap.USER_ID, RealTimeEnvironment.IpAddress))
                    {
                        MessageBox.Show(
                           "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.",
                           "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ThongTinDangNhap.USER_ID = "";
                        Application.Exit();
                        return false;
                    }

                    // cap nhat trang thai
                    if (!ThongTinDangNhap.CheckIn(ThongTinDangNhap.USER_ID, RealTimeEnvironment.IpAddress))
                    {
                        MessageBox.Show("Có lỗi checkin hệ thống.", "Thông báo lỗi",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ThongTinDangNhap.USER_ID = "";

                        Application.Exit();
                        return false;
                    }
                    else
                    {
                        if (
                            !((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) ||
                               (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
                        {
                            MessageBox.Show("Bạn không có quyền điều hành điện thoại.",
                               "Thông báo lỗi", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                            ThongTinDangNhap.CheckOutByIpAddress(RealTimeEnvironment.IpAddress);
                            ThongTinDangNhap.USER_ID = "";
                            Application.Exit();
                            return false;
                        }
                    }

                    // thiet lap menu disable 

                }
                Text = String.Format("{0} - Điện thoại viên  [{1} - {2}] - {3} - {4}",
                    Configuration.GetCompanyName(), RealTimeEnvironment.LineVung, RealTimeEnvironment.IpAddress,
                    ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME);
                RealTimeEnvironment.IsLogin = true;
                LoadLayout();
                PhanQuyen();
                return true;
            }
            else
            {

                RealTimeEnvironment.IsLogin = true;
                ThongTinDangNhap.USER_ID = "";
                PhanQuyen();
                return true;
            }
        }
        private void LoadLayout()
        {
            try
            {
                var layoutChoGiaiQuyet = G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvChoGiaiQuyet.Name, ThongTinDangNhap.USER_ID);
                if (!string.IsNullOrEmpty(layoutChoGiaiQuyet))
                    grvChoGiaiQuyet.LoadLayouFromStringXml(layoutChoGiaiQuyet);
                else grvChoGiaiQuyet.ResetLayout();

                var layoutDaGiaiQuyet = G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvDaGiaiQuyet.Name, ThongTinDangNhap.USER_ID);
                if (!string.IsNullOrEmpty(layoutDaGiaiQuyet))
                    grvChoGiaiQuyet.LoadLayouFromStringXml(layoutDaGiaiQuyet);
                else grvChoGiaiQuyet.ResetLayout();

                var layoutTimKiemCuocGoi = G5Layout.GetLayout(Global.Module.ToString(), this.Name, grvTimKiemCuocGoi.Name, ThongTinDangNhap.USER_ID);
                if (!string.IsNullOrEmpty(layoutTimKiemCuocGoi))
                    grvChoGiaiQuyet.LoadLayouFromStringXml(layoutTimKiemCuocGoi);
                else grvChoGiaiQuyet.ResetLayout();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadLayout", ex);
            }
        }

        // SonPC-PhanQuyen_CacAnhEmVaoHocHoi
        private void PhanQuyen()
        {
            // Thiết lập quyền cho từng baritem
            ribbonMainForm.Items.Cast<BarItem>().ToList().ForEach(bi => bi.Visibility = (bi.Tag == null ? BarItemVisibility.Always : BarItemVisibility.Never)); //Ẩn hết các button đi
            // ribbonMainForm.Items.Cast<BarItem>().Where(bi => bi.Tag == null).ToList().ForEach(bi => bi.Visibility = BarItemVisibility.Always);//Hiển thị những tag = null

            //Hiển thị những Button có tag khớp với trong Database của user đó.
            ThongTinDangNhap.PermissionsFull.Cast<object>().
                Select(p => p.ToString()).
                Join(ribbonMainForm.Items.Cast<BarItem>(), p => p, bi => bi.Tag == null ? string.Empty : bi.Tag.ToString(), (p, bi) => bi.Visibility = BarItemVisibility.Always).Count();

            // Ẩn group nếu như không có item được hiển thị
            ribbonMainForm.Pages.Cast<RibbonPage>().
                SelectMany(p => p.Groups.Cast<RibbonPageGroup>().
                    Select(pg => pg.Visible = pg.ItemLinks.Cast<BarItemLink>().Count(bi => bi.Item.Visibility == BarItemVisibility.Always) != 0)).Count();

            // Ẩn page nếu như không có group được hiển thị
            ribbonMainForm.Pages.Cast<RibbonPage>().Select(p => p.Visible = p.Groups.Cast<RibbonPageGroup>().Count(pg => pg.Visible) != 0).Count();
        }
        #endregion

        private void uc_CuocAppKH1_Load(object sender, EventArgs e)
        {

        }
    }
}
