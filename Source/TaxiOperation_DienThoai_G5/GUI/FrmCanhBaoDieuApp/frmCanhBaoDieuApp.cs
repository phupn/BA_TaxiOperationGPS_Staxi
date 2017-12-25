#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Common.Attributes;
using Taxi.Controls.Base;
using Taxi.Data.CanhBaoDieuApp;
using Taxi.Utils;
using TaxiApplication.Base;

#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiApplication.GUI.FrmCanhBaoDieuApp
{
    #region  === delegate ===
    public delegate void ActivateForm();
    public delegate void SelectRow(Guid bookId, long idCuocGoi, ref CuocGoi _cuocGoi, ref int rowPosition);
    public delegate void KeysEnter(int rowPosition);
    public delegate void CallOut(string PhoneNumber, string DiaChi);
    #endregion
    public partial class frmCanhBaoDieuApp : FormBase
    {
        #region === Properties ===
        public List<CanhBaoDieuApp> _lstObjectTruocThayDoi;
        public CanhBaoDieuApp rowSelectedObject;
        private CuocGoi _cuocGoi;
        private int timerMsg = 0;
        private int timerCanhBaoMoi = 0;
        public Guid BookId { get; set; }
        private DateTime _thoiDiemTruocThayDoiDuLieu;
        private string _line;
        private bool g_isThayDoiDuLieu = false;
        private bool isFormHide = false;
        private bool isDelete = false;
        private int rowPosition;

        #region ------- LENH -------

        private const string LENH_DAMOI = "Đã mời";
        private const string LENH_DAMOI2 = "Đã mời lần 2";
        private const string LENH_CHOKHACH = "Chờ 5 phút";
        private const string LENH_DANGRA = "Đang ra";
        private const string LENH_DOIXE = "Đổi xe 7C/4C";
        private const string LENH_DANGGOI = "Đang gọi...";
        private const string LENH_GAPXE = "Gặp xe";
        private const string LENH_MAYBAN = "Máy bận";
        //private const string LENH_KHONGLIENLACDUOC = "Ko LL được";
        private const string LENH_KHONGLIENLACDUOC = "Từ chối";
        private const string LENH_HUYXE = "Hủy xe/Hoãn";
        private const string LENH_KOTRUCTIEP = "Ko trực tiếp";
        private const string LENH_KOTHAYXE = "Ko thấy xe";
        private const string LENH_TRUOTCHUA = "Trượt/Chùa";
        private const string LENH_KHONGNGHEMAY = "Ko nghe máy";
        private const string LENH_KHONGNOIGI = "Gọi nhiều ko nghe máy";
        private const string LENH_KHONGXE = "Ko xe xin lỗi khách";
        private const string LENH_MOIKHACH = "Mời khách";
        private const string LENH_HOILAIDIACHI = "Hỏi lại địa chỉ";
        private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        private const string LENH_DAXINLOI = "Đã xin lỗi khách";
        private const string LENH_GIUROI = "Giữ Rồi";
        private const string LENH_6_KIENTRAKHACH = "Kiểm tra khách";
        private const string LENH_7_MOIKHACHLAN2 = "Mời lần 2";
        private const string LENH_8_RADAUNGO = "Ra đầu ngõ";
        private const string LENH_9_TIEPTHIXEKHAC = "Tiếp thị 7C/4C";
        private const string LENH_G_GIUCXE = "Giục xe";
        private const string LENH_MATKN = "Mất kết nối";
        private const string LENH_HUYXE_HOAN = "Hủy xe/Hoãn";
        private const string LENH_KTX_GoiChoKhach = "Gọi cho khách,không thấy xe";
        private const string LENH_KTX = "ko thấy xe";
        private const string LENH_KOLIENLACDUOC = "Ko L.lạc đc";
        private const string LENH_THUEBAO = "Thuê bao";
        private const string LENH_THAYXE = "Thấy xe";
        private const string LENH_SPACE_DANGGOI = "Đang gọi";


        #endregion

        #region=== Lệnh lái xe ===
        private const string XEHONG = "Xe hỏng";
        private const string TRUOTKHACH = "Trượt khách";
        private const string GIUCXE = "Giục xe";
        private const string GHICHU = "Ghi chú";
        private const string KHONGLIENLACDUOCVOIKHACH = "Không liên lạc được với khách";
        private const string KHACHHUY = "Khách hủy";
        private const string KHONGLIENLACDUOC = "Không liên lạc được";
        private const string GIUKHACH = "Giữ khách";
        private const string DAGOIKHACHHANG = "Đã gọi khách hàng";
        private const string NHAMKHACH = "Nhầm khách";
        private const string DIEUHANHMOIKHACH = "Điều hành mời khách";
        private const string VACHAMGIAOTHONG = "Va chạm giao thông";
        private const string XINSODIENTHOAI = "Xin số điện thoại";
        private const string CHOSODIENTHOAI = "Đã cho số điện thoại";
        private const string TRUOTSODIENTHOAI = "Trượt SĐT";
        #endregion

        #endregion

        #region === Event ===
        public event SelectRow EventSelectRow;
        public event KeysEnter EventKeysEnter;
        public event CallOut EventCallOut;
        protected virtual void OnEventSelectRow(Guid bookId, long idCuocGoi, ref CuocGoi _cuocGoi, ref int rowPosition)
        {
            if (EventSelectRow != null) EventSelectRow(bookId, idCuocGoi, ref _cuocGoi, ref rowPosition);
        }
        protected virtual void OnEventKeysEnter(int rowPosition)
        {
            if (EventKeysEnter != null)
            {
                EventKeysEnter(rowPosition);
            }
        }
        #endregion

        #region === Form events ===
        public frmCanhBaoDieuApp()
        {
            InitializeComponent();
        }
        public frmCanhBaoDieuApp(string line)
        {
            InitializeComponent();
            grcCanhBaoDieuApp.UseEmbeddedNavigator = false;
            this._line = line;
            _thoiDiemTruocThayDoiDuLieu = DieuHanhTaxi.GetTimeServer();
            //lấy tất cả dữ liệu khi load
            _lstObjectTruocThayDoi = CanhBaoDieuApp.Inst.GetAllData(_line);
            grcCanhBaoDieuApp.DataSource = _lstObjectTruocThayDoi;
            Timer timerCanhbao = new Timer();
            timerCanhbao.Enabled = true;
            timerCanhbao.Interval = 2000;
            timerCanhbao.Tick += this.timerCanhbao_Tick;
            timerCanhbao.Start();
        }

        private void frmCanhBaoDieuApp_Load(object sender, EventArgs e)
        {
            var wa = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(wa.Right - this.Width, wa.Bottom - this.Height);
        }
        private void frmCanhBaoDieuApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            isFormHide = true;
        }
        private void frmCanhBaoDieuApp_Activated(object sender, EventArgs e)
        {
            var row = grvCanhBaoDieuApp.GetFocusedRow() as CanhBaoDieuApp;
            _cuocGoi = new CuocGoi();
            if (row != null)
            {
                OnEventSelectRow(row.BookId, row.IdCuocGoi, ref  _cuocGoi, ref rowPosition);
            }
        }
        #endregion

        #region === Control events ===
        private void grcCanhBaoDieuApp_Click(object sender, EventArgs e)
        {

        }
        private void grvCanhBaoDieuApp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = grvCanhBaoDieuApp.GetFocusedRow() as CanhBaoDieuApp;
            _cuocGoi = new CuocGoi();
            if (row != null)
            {
                OnEventSelectRow(row.BookId, row.IdCuocGoi, ref  _cuocGoi, ref rowPosition);
            }
        }


        private void grvCanhBaoDieuApp_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grvCanhBaoDieuApp.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                if (e.Column.FieldName != "NoiDung")
                {
                    e.Appearance.ForeColor = Color.White;
                }
                e.Appearance.Font = new Font(Font.FontFamily, 8, FontStyle.Bold);
            }
            if (e.RowHandle >= 0)
            {
                //hiển thị màu cho cả row
                int type = (int)grvCanhBaoDieuApp.GetRowCellValue(e.RowHandle, "Type");
                if (type == (int)Enum_G5_PMDH_CanhBaoApp_Type.Row_Red)
                {
                    e.Appearance.BackColor = Color.Tomato;
                }
                //hiển thị màu cột Nội dung theo lệnh tổng đài
                if (e.Column.FieldName == "NoiDung")
                {
                    string noiDung = grvCanhBaoDieuApp.GetRowCellValue(e.RowHandle, "NoiDung").ToString();
                    if (noiDung == LENH_MOIKHACH)
                    {
                        e.Appearance.BackColor = Config_Common.LuoiCuocGoi_MauNen_LenhMoi;
                    }
                    else if (noiDung == LENH_6_KIENTRAKHACH
                       || noiDung == LENH_8_RADAUNGO || noiDung == LENH_7_MOIKHACHLAN2 || noiDung == LENH_9_TIEPTHIXEKHAC)
                    {
                        e.Appearance.BackColor = Color.Orange;
                    }
                    else if (noiDung == LENH_HOILAIDIACHI)
                    {
                        e.Appearance.BackColor = Color.Violet;
                    }
                    else if (noiDung == LENH_KHONGXE)
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void grvCanhBaoDieuApp_KeyDown(object sender, KeyEventArgs e)
        {
            #region===Lệnh===
            CanhBaoDieuApp canhBaoDieuApp = grvCanhBaoDieuApp.GetFocusedRow() as CanhBaoDieuApp;
            bool hasThucHienLenh = false; // dung de xac dinh có thay đổi dữ liệu và gọi update
            var msgDialog = new Taxi.MessageBox.MessageBoxBA();

            #region===1. Mời khách===
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                //kết thúc trong bảng cảnh báo chuyển sang cất vào bảng cảnh báo điếu app kết thúc
                if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                    && !string.IsNullOrEmpty(_cuocGoi.XeNhan)
                    && (_cuocGoi.LenhLaiXe.Contains(LENH_MOIKHACH)
                    || _cuocGoi.LenhLaiXe.Contains(DIEUHANHMOIKHACH)
                    || _cuocGoi.LenhLaiXe.Contains(KHONGLIENLACDUOC)
                    || _cuocGoi.LenhLaiXe.Contains(DAGOIKHACHHANG)))
                {
                    _cuocGoi.LenhDienThoai = LENH_DAMOI;
                    if (_cuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                    {
                        if (Config_Common.DienThoai_DieuApp_DaMoiCmdId >= 0)
                            G5ServiceSyn.SendText(_cuocGoi.XeNhan, _cuocGoi.LenhDienThoai, _cuocGoi.BookId, _cuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID,_cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, Config_Common.DienThoai_DieuApp_DaMoiCmdId);
                        else
                        {
                            G5ServiceSyn.SendACKInvite(_cuocGoi.BookId, _cuocGoi.XeNhan, true, _cuocGoi.LenhDienThoai, _cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                        }
                    }
                    _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    hasThucHienLenh = true;
                }
                else
                {
                    msgDialog.Show(this,
                        String.Format(
                            "[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi, điều app và đã có xe nhận.",
                            LENH_DAMOI),
                        "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region === Not use ===

            #region===2. Gặp xe ===
            //else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            //{
            //    // thực hiện khi có xe nhận
            //    if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(_cuocGoi.XeNhan) &&
            //        _cuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam)
            //    {
            //        _cuocGoi.LenhDienThoai = LENH_GAPXE;
            //        _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
            //        hasThucHienLenh = true;
            //        G5ServiceSyn.SendCatchUserSyn(_cuocGoi.BookId);
            //    }
            //    else
            //    {
            //        msgDialog.Show(this,
            //            String.Format(
            //                "[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm. và đã có xe nhận.",
            //                LENH_GAPXE),
            //            "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //    }
            //}
            #endregion

            #region===3. Đã xin lỗi ===
            //else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            //{
            //    if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam &&
            //        (_cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe ||
            //            _cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1) &&
            //        (_cuocGoi.XeNhan == null || _cuocGoi.XeNhan.Length <= 0))
            //    {
            //        _cuocGoi.LenhDienThoai = LENH_DAXINLOI;
            //        _cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
            //        _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
            //        hasThucHienLenh = true;
            //    }
            //    else
            //    {
            //        msgDialog.Show(this,
            //            string.Format(
            //                "[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm. và chưa có xe nhận.",
            //                LENH_DAXINLOI),
            //            "Thông báo",
            //            Taxi.MessageBox.MessageBoxButtons.OK,
            //            Taxi.MessageBox.MessageBoxIcon.Error);
            //    }
            //}
            #endregion

            #region===4. Máy bận ===
            //else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            //{
            //    if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.LenhLaiXe == LENH_MOIKHACH)
            //    {
            //        _cuocGoi.LenhDienThoai = LENH_MAYBAN;
            //        _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
            //        hasThucHienLenh = true;
            //        G5ServiceSyn.SendText(bienSo, LENH_MAYBAN, _cuocGoi.BookId);
            //    }
            //    else
            //    {
            //        msgDialog.Show(this,
            //            String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và lái xe yêu cầu mời khách và đã có xe nhận.", LENH_MAYBAN),
            //            "Thông báo",
            //            Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //    }
            //}
            #endregion

            #region===5. Không liên lạc được ===
            //else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            //{
            //    if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.LenhLaiXe == LENH_MOIKHACH)
            //    {
            //        _cuocGoi.LenhDienThoai = LENH_KHONGLIENLACDUOC;
            //        _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
            //        hasThucHienLenh = true;
            //        G5ServiceSyn.SendText(bienSo, LENH_KHONGLIENLACDUOC, _cuocGoi.BookId);
            //    }
            //    else
            //    {
            //        msgDialog.Show(this,
            //            String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và lái xe yêu cầu mời khách và đã có xe nhận.",
            //                LENH_KHONGLIENLACDUOC),
            //            "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //    }
            //}
            #endregion

            #region===6. Không nghe máy ===
            //else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            //{
            //    if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.LenhLaiXe == LENH_MOIKHACH)
            //    {
            //        _cuocGoi.LenhDienThoai = LENH_KHONGNGHEMAY;
            //        _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
            //        hasThucHienLenh = true;
            //        G5ServiceSyn.SendText(bienSo, LENH_KHONGNGHEMAY, _cuocGoi.BookId);
            //    }
            //    else
            //    {
            //        msgDialog.Show(this,
            //            String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và lái xe yêu cầu mời khách và đã có xe nhận.",
            //                LENH_KHONGNGHEMAY),
            //            "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //    }
            //}
            #endregion

            #region===7. Không nói gì ===
            //else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            //{
            //    if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.LenhLaiXe == LENH_MOIKHACH)
            //    {
            //        if (Config_Common.CauHinhTextLenh7 == 1)
            //        {
            //            _cuocGoi.LenhDienThoai = "Gọi nhiều ko nghe";
            //        }
            //        else
            //        {
            //            _cuocGoi.LenhDienThoai = LENH_KHONGNOIGI;
            //        }

            //        if (Config_Common.CauHinhKetThucCuocLenh7 == 1)//cho phép kết thúc cuốc luôn
            //        {
            //            _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
            //        }
            //        _cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
            //        hasThucHienLenh = true;
            //        G5ServiceSyn.SendText(bienSo, _cuocGoi.LenhDienThoai, _cuocGoi.BookId);
            //    }
            //    else
            //    {
            //        msgDialog.Show(this,
            //            String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và lái xe yêu cầu mời khách và đã có xe nhận.",
            //                LENH_KHONGNOIGI),
            //            "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //    }
            //}
            #endregion

            #region===8. Hủy xe/Hoãn ===
            //else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            //{
            //    if (_cuocGoi.LenhLaiXe ==LENH_MOIKHACH && _cuocGoi.BookId != Guid.Empty)
            //    {
            //        string dialog = msgDialog.Show(
            //        string.Format("Hủy xe / Hoãn {0}...?", _cuocGoi.DiaChiDonKhach), "Thông báo",
            //        Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question);
            //        if (dialog == "Yes")
            //        {
            //            _cuocGoi.LenhDienThoai = LENH_HUYXE;
            //            _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
            //            hasThucHienLenh = true;

            //            #region Gửi đã Hoãn tới Cho fastTaxi nếu là cuốc của fastTaxi

            //            G5ServiceSyn.SendOperatorCancel(_cuocGoi.BookId);

            //            if (_cuocGoi.FT_IsFT)
            //                ProcessFastTaxi.SendFastTaxi(_cuocGoi, Enum_FastTaxi_Status.Hoan_DaHoan);

            //            #endregion

            //            // Gửi hủy cho lái xe
            //            G5ServiceSyn.SendOperatorCancel(_cuocGoi.BookId);
            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        _cuocGoi.LenhDienThoai = LENH_HUYXE;
            //        hasThucHienLenh = true;
            //    }

            //}
            #endregion
            #endregion

            #region===9. Giữ rồi ===
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.G5_Type == Enum_G5_Type.DieuApp && _cuocGoi.LenhLaiXe == GIUKHACH)
                {
                    _cuocGoi.LenhDienThoai = LENH_GIUROI;
                    G5ServiceSyn.SendText(_cuocGoi.XeNhan, "Đã giữ khách", _cuocGoi.BookId, _cuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID, _cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                    _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    hasThucHienLenh = true;
                }
                else
                {
                    msgDialog.Show(this,
                        String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.", LENH_GIUROI),
                        "Thông báo",
                        Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region=== Gửi số điện thoại cho lái xe ===
            // có cho số
            if (e.KeyCode == Keys.Y)
            {
                if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.G5_Type == Enum_G5_Type.DieuApp && canhBaoDieuApp.CmdId == 50)
                {
                    _cuocGoi.LenhDienThoai = "Đã gửi SĐT";
                    G5ServiceSyn.SendText(_cuocGoi.XeNhan, _cuocGoi.PhoneNumber, _cuocGoi.BookId, _cuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID, _cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, canhBaoDieuApp.CmdId);
                    _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    hasThucHienLenh = true;
                    KetThucCanhBao(canhBaoDieuApp.Id, "Đã gửi SĐT");
                }
            }
            //Không cho số
            if (e.KeyCode == Keys.N)
            {
                 if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && _cuocGoi.G5_Type == Enum_G5_Type.DieuApp && canhBaoDieuApp.CmdId == 50)
                {
                    _cuocGoi.LenhDienThoai = "Không cho số";
                    G5ServiceSyn.SendText(_cuocGoi.XeNhan, _cuocGoi.PhoneNumber, _cuocGoi.BookId, _cuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID, _cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, canhBaoDieuApp.CmdId, false);
                    _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    hasThucHienLenh = true;  
                    KetThucCanhBao(canhBaoDieuApp.Id, "Không cho số");
                }
            }
            #endregion

            #region=== Trượt: không gửi số điện thoại cho lái xe ===
            if (e.KeyCode == Keys.T)
            {
                if (_cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                            && _cuocGoi.XeNhan != null && _cuocGoi.XeNhan != "")
                {
                    if (_cuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                    {
                        if (Config_Common.DienThoai_DieuApp_CanhBaoMatKetNoiVoiServerDieuHanh)
                        {
                            if ((G5ServiceSyn.PingServer != Enum_G5_Ping.PingSu && _cuocGoi.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong)
                                || (G5ServiceSyn.PingServer_XHD != Enum_G5_Ping.PingSu && _cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong))
                            {
                                if (_cuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                                {
                                    msgDialog.Show(this, "Đang mất kết nối tới Server ĐH.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                    return;
                                }
                            }
                        }
                        //Nếu là cuốc điều app và có xe dừng điểm hoặc thời gian vượt quá 5 phút thì cho trượt
                        if ((_cuocGoi.XeDungDiem != null && _cuocGoi.XeDungDiem != "")
                            || (Config_Common.DienThoai_DieuApp_Truot == 0 || (DieuHanhTaxi.GetTimeServer() - (_cuocGoi.G5_SendDate ?? _cuocGoi.ThoiDiemGoi)).TotalMinutes > Config_Common.DienThoai_DieuApp_Truot)
                            || (!string.IsNullOrEmpty(_cuocGoi.XeNhan) && Config_Common.DienThoai_DieuApp_TruotKhiCoXeNhan)
                            )
                        {
                            string dialog = msgDialog.Show(string.Format("{1} {0}...?", _cuocGoi.DiaChiDonKhach, LENH_TRUOTCHUA), "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                            if (dialog == "Yes")
                            {
                                _cuocGoi.LenhDienThoai = LENH_TRUOTCHUA;
                                _cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                                _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                hasThucHienLenh = true;

                                // Gửi hủy cho lái xe
                                G5ServiceSyn.SendOperatorCancel(_cuocGoi.BookId, _cuocGoi.LoaiCuocKhach, "Trượt khách");
                                KetThucCanhBao(canhBaoDieuApp.Id, "Trượt");
                            }
                        }
                        else
                        {
                            msgDialog.Show(this,
                           String.Format("[Lệnh Trượt] Cuội gọi phải là cuốc gọi điều App và lái xe đã báo trượt.", LENH_MAYBAN),
                           "Thông báo",
                          Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    else
                    {
                        _cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                        _cuocGoi.LenhDienThoai = LENH_TRUOTCHUA;
                        _cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        hasThucHienLenh = true;
                    }
                }
                else
                {
                    msgDialog.Show(this,
                        String.Format("[Lệnh Trượt] Cuốc trượt phải là cuộc gọi taxi và đã có xe nhận.", LENH_MAYBAN),
                        "Thông báo",
                        Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region **************** F4|| Space || Ctrl + C **************************

            else if ((e.KeyData == Keys.F4 || e.KeyData == Keys.Space))
            {
                HienThiFormGoiDienThoai(Taxi.Business.Configuration.GetDauSoGoiDi + canhBaoDieuApp.SoDienThoai, canhBaoDieuApp.DiaChiDon);
            }
            #endregion

            #region --------- Alt+C: Gọi cho lái xe -------
            else if (e.KeyData == (Keys.Alt | Keys.C))
            {
                try
                {
                    if (!string.IsNullOrEmpty(canhBaoDieuApp.SoXe))
                    {
                        if (CommonBL.DictDriver.ContainsKey(canhBaoDieuApp.SoXe))
                        {
                            var objDriver = CommonBL.DictDriver[canhBaoDieuApp.SoXe];
                            string soDT = objDriver.DiDong;
                            if (!string.IsNullOrEmpty(soDT))
                            {
                                string text = string.Format("Xe {0} - {1}", canhBaoDieuApp.SoXe, objDriver.TenNhanVien);
                                HienThiFormGoiDienThoai(soDT, text);
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Lái xe {0}-{1} chưa có thông tin số điện thoại", canhBaoDieuApp.SoXe, objDriver.TenNhanVien), "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Hiện tại không có lái xe nào chạy xe {0}", canhBaoDieuApp.SoXe), "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Không gọi được. Chưa có xe nhận"), "Thông báo", MessageBoxButtons.OK);
                    }

                }
                catch (Exception ex)
                {

                }

            }
            #endregion

            #region===Cập nhật dữ liệu===
            if (hasThucHienLenh)
            {
                _cuocGoi.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                bool updateSuccess = false;

                var checkChange = new CuocGoi.CheckChange();
                checkChange.DiaChiDon = true;
                checkChange.DiaChiTra = true;
                checkChange.XeNhan = true;
                checkChange.XeDon = true;

                if (Global.MoHinh == MoHinh.TongDaiMini)
                    updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini(_cuocGoi);
                else
                    updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi(_cuocGoi, checkChange);

                if (!updateSuccess)
                {
                    MessageBox.Show("Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo");
                    return;
                }
                else
                {
                    // KetThucCanhBao(canhBaoDieuApp, canhBaoDieuAppKT, _cuocGoi.LenhDienThoai);
                    KetThucCanhBao(canhBaoDieuApp.Id, _cuocGoi.LenhDienThoai);
                }
            }
            #endregion

            #endregion

            #region===Kết thúc cảnh báo, không xử lý===
            if (e.KeyCode == Keys.Delete)
            {
                //Kết thúc cảnh báo với nội dung "XÓA"
                if (MessageBox.Show("Bạn muốn kết thúc cảnh báo của SĐT " + canhBaoDieuApp.SoDienThoai + " mà không xử lý ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KetThucCanhBao(canhBaoDieuApp.Id, "Xóa");
                }
            }
            #endregion

            #region===Cuốc đã xử lý===
            if (e.KeyCode == Keys.D)
            {
                if (MessageBox.Show("Bạn đã xử lý cảnh báo của SĐT " + canhBaoDieuApp.SoDienThoai + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KetThucCanhBao(canhBaoDieuApp.Id, "Đã xử lý");
                }
            }
            #endregion

            #region===Keys Enter===
            if (e.KeyCode == Keys.Enter)
            {
                OnEventKeysEnter(rowPosition);
            }
            #endregion
        }
        #endregion

        #region === Timer ===
        private void timerCanhbao_Tick(object sender, EventArgs e)
        {
            try
            {
                bool isThayDoiDuLieu = false;
                bool isNew = false;
                string content = "";
                isThayDoiDuLieu = GetUpdateData(ref isNew, ref _thoiDiemTruocThayDoiDuLieu, ref content);
                timerMsg++;
                timerCanhBaoMoi++;
                if (timerMsg >= 2)
                {
                    timerMsg = 0;
                    isThayDoiDuLieu = KiemTraCacBanGhiXoa();
                }
                //xử lý các cảnh báo quá giờ không xử lý,sẽ tự động cho kết thúc
                if (timerCanhBaoMoi >= 7)//7s kiểm tra 1 lần
                {
                    timerCanhBaoMoi = 0;
                    KetThucCanhBaoQuaGio_V2();
                }
                if (isThayDoiDuLieu)
                { // Dữ liệu thay đổi
                    grcCanhBaoDieuApp.RefreshDataSource();
                    if (grvCanhBaoDieuApp.RowCount <= 0)
                    {
                        this.Hide();
                    }
                    else this.Show();
                }
                if (isNew)
                {
                    // Hiện form khi có cảnh báo mới
                    //Nếu form đang Minimized
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    //nếu form đang ẩn
                    if (isFormHide)
                    {
                        this.Show();
                        isFormHide = false;
                    }
                    notifyIcon1.Visible = true;
                    if (content != "")
                    {
                        notifyIcon1.ShowBalloonTip(10, "Cảnh báo mới", content, ToolTipIcon.Warning);
                    }
                    else
                    {
                        notifyIcon1.ShowBalloonTip(10, "Cảnh báo mới", "Có cảnh báo mới", ToolTipIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CanhBaoDieuApp.Timer", ex);
            }
        }
        #endregion

        #region === Method ===
        /// <summary>
        /// Sao chép dữ liệu giữa 2 đối tượng
        /// </summary>
        /// <param name="o1">Object cần thay đổi</param>
        /// <param name="o2">Object để lấy dữ liệu cần sao chép</param>
        private void Copy(CanhBaoDieuApp o1, CanhBaoDieuApp o2)
        {
            o1.BookId = o2.BookId;
            o1.NoiDung = o2.NoiDung;
            o1.SoDienThoai = o2.SoDienThoai;
            o1.DiaChiDon = o2.DiaChiDon;
            o1.SoXe = o2.SoXe;
            o1.ThoiGianNhan = o2.ThoiGianNhan;
            o1.Line = o2.Line;
            o1.NguoiNhan = o2.NguoiNhan;
            o1.ThoiGianXuLy = o2.ThoiGianXuLy;
            o1.NguoiXuLy = o2.NguoiXuLy;
            o1.TrangThai = o2.TrangThai;
            o1.Type = o2.Type;
            o1.NoiDungXuLy = o2.NoiDungXuLy;
        }
        private void G5_DIENTHOAI_UpdateLenhMoiKhach(long id, string lenh)
        {
            // cập nhật lại lệnh trên form chính
            bool updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateLenhMoiKhach(id, lenh);
            if (!updateSuccess)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return;
            }
        }
        /// <summary>
        /// Kết thúc cảnh báo, dạng không xử lý cảnh báo
        /// </summary>
        private void KetThucCanhBao(CanhBaoDieuApp canhBao, CanhBaoDieuAppKetThuc canhBaoKetThuc, string noiDungXuLy)
        {
            canhBaoKetThuc.Id = canhBao.Id;
            canhBaoKetThuc.BookId = canhBao.BookId;
            canhBaoKetThuc.IdCuocGoi = canhBao.IdCuocGoi;
            canhBaoKetThuc.NoiDung = canhBao.NoiDung;
            canhBaoKetThuc.SoDienThoai = canhBao.SoDienThoai;
            canhBaoKetThuc.DiaChiDon = canhBao.DiaChiDon;
            canhBaoKetThuc.SoXe = canhBao.SoXe;
            canhBaoKetThuc.ThoiGianNhan = canhBao.ThoiGianNhan;
            canhBaoKetThuc.Line = canhBao.Line;
            canhBaoKetThuc.NguoiNhan = canhBao.NguoiNhan;
            canhBaoKetThuc.ThoiGianXuLy = DieuHanhTaxi.GetTimeServer();
            canhBaoKetThuc.NguoiXuLy = canhBao.NguoiXuLy;
            canhBaoKetThuc.TrangThai = (int)Enum_G5_PMDH_CanhBaoApp_Status.DaGiaiQuyet;
            canhBaoKetThuc.Type = canhBao.Type;
            canhBaoKetThuc.NoiDungXuLy = noiDungXuLy;
            try
            {
                _lstObjectTruocThayDoi.Remove(canhBao);
                grcCanhBaoDieuApp.RefreshDataSource();
                canhBao.Delete();// delete
                canhBaoKetThuc.Save();//if() update else inser
            }
            catch (Exception)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi, không kết thúc được cuốc này.", "Thông báo",
                       Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }

        }

        private void KetThucCanhBao(long id, string noiDungXuLy)
        {
            try
            {
                CanhBaoDieuApp.Inst.KetThucCanhBao(id, noiDungXuLy);
            }
            catch (Exception)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi, không kết thúc được cuốc này.", "Thông báo",
                         Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }
        /// <summary>
        /// Xử lý kết thúc các cảnh báo quá thời gian quy định( 1 phút) nếu cảnh báo đó không được xử lý
        /// </summary>
        private bool KetThucCanhBaoQuaGio()
        {
            bool isThayDoiDuLieu = false;
            if (_lstObjectTruocThayDoi.Count > 0)
            {
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                CanhBaoDieuAppKetThuc canhBaoDieuAppKT = new CanhBaoDieuAppKetThuc();
                for (int i = 0; i < _lstObjectTruocThayDoi.Count; i++)
                {
                    if (_lstObjectTruocThayDoi[i].ThoiGianNhan.AddMinutes(1) <= timeServer) //5-tb hết hạn
                    {
                        // sau 15 phút không xử lý thì kết thúc cảnh báo
                        //KetThucCanhBao(_lstObjectTruocThayDoi[i], canhBaoDieuAppKT, "Quá thời gian xử lý cảnh báo");
                        KetThucCanhBao(_lstObjectTruocThayDoi[i].Id, "Quá thời gian xử lý cảnh báo");
                        i--;// xóa đi thì Count-- nên i--
                        isThayDoiDuLieu = true;
                    }
                }
            }
            return isThayDoiDuLieu;
        }

        private void KetThucCanhBaoQuaGio_V2()
        {
            BackgroundWorker bw_KetThucCanhBao = new BackgroundWorker();
            bw_KetThucCanhBao.DoWork += bw_KetThucCanhBao_DoWork;
            bw_KetThucCanhBao.RunWorkerCompleted += bw_KetThucCanhBao_RunWorkerCompleted;
            bw_KetThucCanhBao.RunWorkerAsync();
        }

        void bw_KetThucCanhBao_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_lstObjectTruocThayDoi.Count > 0)
            {
                CanhBaoDieuApp.Inst.CheckCanhBaoQuaGio();
            }
        }
        void bw_KetThucCanhBao_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //
        }

        /// <summary>
        /// Kiểm tra các bản ghi thay đổi và các bản ghi bị xóa
        /// </summary>
        /// <returns>True: nếu có dữ liệu thay đổi, ngược lại: False</returns>
        public bool GetUpdateData(ref bool pIsNew, ref DateTime pMaxDate, ref string pContent)
        {
            DateTime maxDate = DateTime.MinValue;
            bool isNew = false;
            string content = "";
            //kiểm tra các bản ghi thay đổi 
            List<CanhBaoDieuApp> lstRecordNew = CanhBaoDieuApp.Inst.KiemTraBanGhiThayDoiVaThemMoi(_line, _thoiDiemTruocThayDoiDuLieu);
            if (lstRecordNew.Count > 0)
            {
                g_isThayDoiDuLieu = true;

                for (int i = 0; i < lstRecordNew.Count; i++)
                {
                    CanhBaoDieuApp item = lstRecordNew[i];
                    bool isUpdate = false;
                    for (int j = 0; j < _lstObjectTruocThayDoi.Count; j++)
                    {
                        if (item.Id == _lstObjectTruocThayDoi[j].Id)
                        {
                            isUpdate = true;
                            Copy(_lstObjectTruocThayDoi[j], item);
                            break;
                        }
                    }
                    if (!isUpdate)
                    {
                        _lstObjectTruocThayDoi.Insert(0, item);
                        isNew = true;
                        content = "SĐT: " + item.SoDienThoai + ": " + item.NoiDung;
                        if (item.Type == (int)Enum_G5_PMDH_CanhBaoApp_Type.Row_Red_Sound)
                        {
                            SoundUtils.PlaySoundAlert();
                        }
                    }
                    if (item.ThoiGianXuLy > maxDate)//*sign
                    {
                        maxDate = item.ThoiGianXuLy;
                    }
                }
            }
            else
            {
                g_isThayDoiDuLieu = false;
            }

            if (maxDate > pMaxDate)
                pMaxDate = maxDate;
            pIsNew = isNew;
            pContent = content;
            return g_isThayDoiDuLieu;
        }
        /// <summary>
        /// Kiểm tra các bản ghi bị xóa
        /// </summary>
        /// <returns>True: nếu có bản ghi bị xóa, ngược lại: False</returns>
        public bool KiemTraCacBanGhiXoa()
        {
            string chuoiId = "";
            for (int i = 0; i < _lstObjectTruocThayDoi.Count; i++)
            {
                chuoiId += _lstObjectTruocThayDoi[i].Id + ";";
            }
            DataTable lstId = CanhBaoDieuApp.Inst.KiemTraCacBanGhiXoa(_line, chuoiId);
            if (lstId.Rows.Count > 0)
            {
                foreach (DataRow dr in lstId.Rows)
                {
                    string id = dr[0].ToString();
                    _lstObjectTruocThayDoi.Remove(_lstObjectTruocThayDoi.Find(x => x.Id.ToString() == dr[0].ToString()));
                }
                return true;
            }
            return false;
        }

        void bw_KiemTraBanGhiXoa_DoWork(object sender, DoWorkEventArgs e)
        {
            string chuoiId = "";
            for (int i = 0; i < _lstObjectTruocThayDoi.Count; i++)
            {
                chuoiId += _lstObjectTruocThayDoi[i].Id + ";";
            }
            DataTable lstId = CanhBaoDieuApp.Inst.KiemTraCacBanGhiXoa(_line, chuoiId);
            if (lstId.Rows.Count > 0)
            {
                foreach (DataRow dr in lstId.Rows)
                {
                    string id = dr[0].ToString();
                    _lstObjectTruocThayDoi.Remove(_lstObjectTruocThayDoi.Find(x => x.Id.ToString() == dr[0].ToString()));
                }
                e.Result = true;
                //isDelete= true;
            }
            e.Result = false;
            //  isDelete = false;
        }

        void bw_KiemTraBanGhiXoa_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isDelete = (bool)e.Result;
        }

        #endregion

        #region === ProcessCmdKey ===
        public event ActivateForm EventActivateForm;
        [MethodWithKey(Keys = Keys.F6)]
        protected virtual void OnEventActivateForm()
        {
            if (EventActivateForm != null) EventActivateForm();
        }
        #endregion

        /// <summary>
        /// hàm hiển thị thông tin form gọi điện
        /// </summary>
        public void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi)
        {
            try
            {
                if (EventCallOut != null)
                {
                    EventCallOut(PhoneNumber, DiaChi);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CanhBaoDieuApp.HienThiFormGoiDienThoai", ex);
            }

        }
    }
}
