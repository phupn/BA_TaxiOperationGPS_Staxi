using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using System.Linq;
using Taxi.Data.G5;

namespace Taxi.GUI
{
    public partial class frmInputOnGrid : Form
    {
        private CuocGoi g_CuocGoi;
        private KieuNhapTrenGridTongDai g_KieuNhap;
        private List<string> g_listSoHieuXe;
        private string g_Return = string.Empty;
        private int G_XeDonLength = 0;
        private bool g_CloseForm = false;
        private bool g_IsKetThuc = false;
        string StartValue = "";
        public List<CuocGoi> G_ListCuocGoi { get; set; }
        public string GetGiaTriNhap()
        {
            return StringTools.LocBoTrungXe(g_Return);
        }

        public bool IsKetThuc()
        {
            return g_IsKetThuc;
        }

        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (!string.IsNullOrEmpty(ThongTinCauHinh.CacVungTongDai))
            {
                string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
                for (int i = 0; i < arrVung.Length; i++)
                {
                    if (Convert.ToInt32(arrVung[i]) == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            return bCheck;
        }
        public frmInputOnGrid(KieuNhapTrenGridTongDai kieuNhap, List<string> listSoHieuXe)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            g_listSoHieuXe = listSoHieuXe;
        }
        public frmInputOnGrid(CuocGoi cuocGoi, KieuNhapTrenGridTongDai kieuNhap, List<string> listSoHieuXe, bool IsThoat999)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            g_CuocGoi = cuocGoi;
            g_listSoHieuXe = listSoHieuXe;
        }

        public frmInputOnGrid(CuocGoi cuocGoi, KieuNhapTrenGridTongDai kieuNhap, List<string> listSoHieuXe, bool IsThoat999, string value)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            g_CuocGoi = cuocGoi;
            g_listSoHieuXe = listSoHieuXe;
            StartValue = value;
        }
        public frmInputOnGrid(string DiaChiTra, KieuNhapTrenGridTongDai kieuNhap)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            StartValue = DiaChiTra;
        }
        private void frmInputOnGrid_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiControl();
            }
            catch 
            {

            }
        }

        /// <summary>
        /// hiển thị control
        /// </summary>
        private void HienThiControl()
        {
            if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapChuyenKenh)
            {
                lblLabel.Text = "Chuyển kênh";
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapGhiChuTongDai)
            {
                lblLabel.Text = "Ghi chú";
                txtInputGrid.Text = g_CuocGoi.GhiChuTongDai;
                if (g_CuocGoi.GhiChuTongDai.Length > 0)
                    txtInputGrid.SelectAll();
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhan)
            {
                lblLabel.Text = "Xe nhận";
                string xeNhanMoi;
                if (StartValue == "\b")
                {
                    xeNhanMoi = string.IsNullOrEmpty(g_CuocGoi.XeNhan) ? string.Empty : g_CuocGoi.XeNhan.Substring(0, g_CuocGoi.XeNhan.Length - 1);
                }
                else if (StartValue == ".")
                {
                    xeNhanMoi = "";
                }
                else
                {
                    xeNhanMoi = string.IsNullOrEmpty(g_CuocGoi.XeNhan) ? StartValue : g_CuocGoi.XeNhan + "." + StartValue;
                }
                txtInputGrid.Text = xeNhanMoi;
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon)
            {
                lblLabel.Text = "Xe đón";
                if (!string.IsNullOrEmpty(g_CuocGoi.XeDon))
                {
                    txtInputGrid.Text = g_CuocGoi.XeDon + ".";
                }
                else
                {
                    if (StartValue != "")
                    {
                        txtInputGrid.Text = StartValue;
                    }
                    else
                    {
                        switch (Config_Common.DungXe)
                        {
                            case NhapXeDon.None:
                            case NhapXeDon.XeMK:
                                if (!string.IsNullOrEmpty(g_CuocGoi.BTBG_NoiDungXuLy) && g_CuocGoi.BTBG_NoiDungXuLy.Split('.').Length==1)
                                    txtInputGrid.Text = g_CuocGoi.BTBG_NoiDungXuLy + ".";
                                break;
                            case NhapXeDon.XeDenDiem:
                                if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem) && g_CuocGoi.XeDenDiem.Split('.').Length == 1)
                                    txtInputGrid.Text = g_CuocGoi.XeDenDiem + ".";
                                break;
                            case NhapXeDon.XeDenDiem_XeMK_XeNhan:
                                {
                                    if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem))
                                    {
                                        if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem) && g_CuocGoi.XeDenDiem.Split('.').Length == 1)
                                            txtInputGrid.Text = g_CuocGoi.XeDenDiem + ".";

                                    }
                                    else
                                        if (!string.IsNullOrEmpty(g_CuocGoi.BTBG_NoiDungXuLy))
                                        {
                                            if (!string.IsNullOrEmpty(g_CuocGoi.BTBG_NoiDungXuLy) && g_CuocGoi.BTBG_NoiDungXuLy.Split('.').Length == 1)
                                                txtInputGrid.Text = g_CuocGoi.BTBG_NoiDungXuLy + ".";
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && g_CuocGoi.XeNhan.Split('.').Length == 1)
                                                txtInputGrid.Text = g_CuocGoi.XeNhan + ".";
                                        }
                                    break;
                                }

                            case NhapXeDon.XeMK_XeDenDiem_XeNhan:
                                {
                                    if (!string.IsNullOrEmpty(g_CuocGoi.BTBG_NoiDungXuLy))
                                    {
                                        if (!string.IsNullOrEmpty(g_CuocGoi.BTBG_NoiDungXuLy) && g_CuocGoi.BTBG_NoiDungXuLy.Split('.').Length == 1)
                                            txtInputGrid.Text = g_CuocGoi.BTBG_NoiDungXuLy + ".";
                                    }
                                    else
                                        if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem))
                                        {
                                            if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem) && g_CuocGoi.XeDenDiem.Split('.').Length == 1)
                                            txtInputGrid.Text = g_CuocGoi.XeDenDiem+".";
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && g_CuocGoi.XeNhan.Split('.').Length == 1)
                                                txtInputGrid.Text = g_CuocGoi.XeNhan + ".";
                                        }
                                    break;
                                }
                               
                        }
                    }
                }
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhanDenDiem)
            {
                lblLabel.Text = "Xe đến điểm";
                if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem))
                {
                    txtInputGrid.Text = g_CuocGoi.XeDenDiem + "." + StartValue;
                }
                else
                {
                    if (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && !g_CuocGoi.XeNhan.Contains("."))
                    {
                        txtInputGrid.Text =g_CuocGoi.XeNhan + "." + StartValue;
                    }
                }
                //txtInputGrid.Text = string.IsNullOrEmpty(g_CuocGoi.XeDenDiem) ? "" + StartValue : g_CuocGoi.XeDenDiem + "." + StartValue;
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.TimKiemXe)
            {
                lblLabel.Text = "Tìm kiếm xe";
                txtInputGrid.Focus();
                this.Activate();
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapDiaChiTra)
            {
                lblLabel.Text = "Nhập địa chỉ trả";
                txtInputGrid.Text = StartValue;
                txtInputGrid.Focus();
                this.Activate();
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDungDiem)
            {
                lblLabel.Text = "Xe dừng điểm";
                string xeNhanMoi;
                if (StartValue == "\b")
                {
                    xeNhanMoi = string.IsNullOrEmpty(g_CuocGoi.XeDungDiem) ? string.Empty : g_CuocGoi.XeDungDiem.Substring(0, g_CuocGoi.XeDungDiem.Length - 1);
                }
                else if (StartValue == ".")
                {
                    xeNhanMoi = "";
                }
                else
                {
                    xeNhanMoi = string.IsNullOrEmpty(g_CuocGoi.XeDungDiem) ? StartValue : g_CuocGoi.XeDungDiem + "." + StartValue;
                }
                txtInputGrid.Text = xeNhanMoi + (string.IsNullOrEmpty(xeNhanMoi)?"":".");
                txtInputGrid.Focus();
                this.Activate();
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeMK)
            {
                lblLabel.Text = "Nhập xe MK";
                txtInputGrid.Text = g_CuocGoi.BTBG_NoiDungXuLy;
                if (g_CuocGoi.BTBG_NoiDungXuLy.Length > 0)
                {
                    txtInputGrid.Text = txtInputGrid.Text + '.';
                    txtInputGrid.SelectAll();
                }
                else
                {   
                    if (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && g_CuocGoi.XeNhan.Split('.').Length == 1)
                        txtInputGrid.Text = g_CuocGoi.XeNhan + '.';
                    txtInputGrid.SelectAll();
                }
            }

            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapPhutKhachCho)
            {
                lblLabel.Text = "Số phút khách chờ";
                txtInputGrid.Text = "5";
                if (Config_Common.SMS_PHUTKHACHCHO != null && Config_Common.SMS_PHUTKHACHCHO != "")
                {
                    txtInputGrid.Text = Config_Common.SMS_PHUTKHACHCHO;
                }
            }
            int length = txtInputGrid.Text.Length;
            if (length > 0)
            {
                txtInputGrid.Select(length, 0);
            }
        }

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                this.DialogResult = DialogResult.Cancel;
                g_Return = string.Empty;
                g_CloseForm = true;
                return true;
            }
            return false;
        }
        #endregion XU LY HOTKEY

        private void txtInputGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                g_CloseForm = true;
                MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
                string s = StringTools.TrimSpace(txtInputGrid.Text);
                
                
                    #region KENH
                    if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapChuyenKenh)
                    {
                        if (s.Length <= 0)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            return;
                        }
                        g_Return = s;
                        int kenhVung ;
                        try
                        {
                            kenhVung = Convert.ToInt32(s);
                            if (!CheckVungNamTrongVungCauHinh(kenhVung))
                            {
                                kenhVung = -1;
                            }
                        }
                        catch 
                        {
                            kenhVung = 0;
                        }
                        if (kenhVung <= 0)
                        {
                            msgBox.Show(this, "Vùng phải lớn hơn 0 và nằm trong vùng được cấp phép.", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Question);
                            this.DialogResult = DialogResult.Cancel;
                            g_CloseForm = false;
                            return;
                        }
                        g_CuocGoi.Vung = kenhVung;
                        g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.TongGuiSangMoiKhach;
                    if (CuocGoi.TONGDAI_UpdateChuyenVung(g_CuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID, g_CuocGoi.Vung, ""))
                        {
                            this.DialogResult = DialogResult.OK;
                            g_CloseForm = true;
                        }
                    }
                #endregion KENH

                    #region XENHAN
                    else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhan)
                    {
                        // Check xe nhận
                        string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(s);
                        g_Return = xeNhan;
                        if (Config_Common.CanhBaoKhiNhapXe == 0 && !ValidateXeNhan(xeNhan, g_CuocGoi.XeDon))
                        {
                            g_CloseForm = false;
                            this.DialogResult = DialogResult.Cancel;
                            return;
                        }
                        if (Config_Common.TDV_VALIDATE_XENHAN_APP)
                        {
                            string xeNhanMoi = StringTools.GetXeNhanMoi(g_CuocGoi.XeNhan, xeNhan);
                            List<T_TaxiOperation> lstItem = T_TaxiOperation.Inst.GetList_XeDangNhanApp(g_CuocGoi.IDCuocGoi, xeNhanMoi);
                            if (lstItem != null && lstItem.Count > 0)
                            {
                                T_TaxiOperation item = lstItem[0];
                                frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.TrungXeNhanApp, item.MessageAlert, item.Id);
                                {
                                    confirmXeDon.ShowDialog();
                                    if (confirmXeDon.DialogResult == DialogResult.OK && confirmXeDon.Result == 1)
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        g_CloseForm = false;
                                        this.DialogResult = DialogResult.Cancel;
                                        return;
                                    }
                                }
                            }
                        }
                        else if (Config_Common.TDV_XENHAN_RADIO_TO_APP)
                        {
                            string xeNhanMoi = StringTools.GetXeNhanMoi(g_CuocGoi.XeNhan, xeNhan);
                            if (CommonBL.DictApp_Current != null && CommonBL.DictApp_Current.Count > 0)
                            {
                                if (CommonBL.DictApp_Current.ContainsKey(xeNhanMoi))
                                {
                                    string info = string.Format("Cuốc khách gối : {0} - {1}", g_CuocGoi.PhoneNumber, g_CuocGoi.DiaChiDonKhach);
                                    Taxi.Services.WCFServicesApp.SendText(CommonBL.ConvertSangBienSo(xeNhanMoi), info, CommonBL.DictApp_Current[xeNhanMoi]);
                                    g_CuocGoi.LenhTongDai = "Đã gửi cuốc gối cho lx";
                                }
                            }
                        }
                    }
                    #endregion XENHAN

                    #region Xe MK
                    else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeMK)
                    {
                        // Check xe nhận
                        string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(s);
                        g_Return = xeNhan;
                        if (Config_Common.CanhBaoKhiNhapXe == 0 && !ValidateXeMK(xeNhan, g_CuocGoi.XeNhan))
                        {
                            g_CloseForm = false;
                            this.DialogResult = DialogResult.Cancel;
                            return;
                        }

                    }
                    #endregion XENHAN

                    #region XEDON
                    else if (s.Length > 0 && g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon)
                    {
                        
                        // Kiểm tra xe đó có nằm trong xe nhận
                        string xeDon = StringTools.ConvertToChuoiXeNhanChuan(s);
                        g_Return = xeDon;
                        
                        if (!string.IsNullOrEmpty(xeDon))
                        {
                            if (xeDon == "000")
                            {
                                xeDon = "000";
                                g_IsKetThuc = true;
                            }
                            else
                            {
                                G_XeDonLength = xeDon.Split('.').Length;
                                if (Config_Common.CanhBaoKhiNhapXe == 0 && !KiemTraXeNhan(xeDon) && (!StringTools.KiemTraTrungLapXeChay(xeDon)))
                                {
                                    msgBox.Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Question);
                                    g_CloseForm = false;
                                    this.DialogResult = DialogResult.Cancel;
                                    return;
                                }
                                string KenhVung_Trung;
                                string xeDangCoKhach = new CuocGoi().TONGDAI_UPDATE_XEDON_CHECKVALID(xeDon, g_CuocGoi.ThoiDiemGoi, out KenhVung_Trung);
                                if (xeDangCoKhach != "")
                                {
                                    string message = String.Format("Xe {0} đã đón khách ở vùng {1} khoảng 5 phút gần đây", xeDangCoKhach, KenhVung_Trung);
                                    using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.TrungXeDon, message, g_CuocGoi.IDCuocGoi))
                                    {
                                        confirmXeDon.ShowDialog();
                                        if (confirmXeDon.DialogResult == DialogResult.OK)
                                        {
                                            if (confirmXeDon.Result == 1)
                                            {
                                                if (!new Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.TrungXeDon))
                                                {
                                                    new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                                                    return;
                                                }
                                                g_IsKetThuc = true;
                                            }
                                            else
                                            {
                                                g_IsKetThuc = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            g_IsKetThuc = false;
                                            return;
                                        }
                                    }
                                }
                                if (Config_Common.CanhBaoKhiNhapXe == 0 && G_XeDonLength < g_CuocGoi.SoLuong)
                                {
                                    const string message = "Chưa đủ xe số lượng xe yêu cầu";
                                    using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message, g_CuocGoi.IDCuocGoi))
                                    {
                                        confirmXeDon.ShowDialog();
                                        if (confirmXeDon.DialogResult == DialogResult.OK)
                                        {
                                            if (confirmXeDon.Result == 2)
                                            {
                                                if (!new Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon))
                                                {
                                                    new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                                                    return;
                                                }
                                                g_IsKetThuc = true;
                                            }
                                            else
                                            {
                                                g_IsKetThuc = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            g_IsKetThuc = false;
                                            return;
                                        }
                                    }
                                }
                                else if (Config_Common.CanhBaoKhiNhapXe == 0 && G_XeDonLength > g_CuocGoi.SoLuong)
                                {
                                    new MessageBox.MessageBoxBA().Show("Xe đón vượt số lượng yêu cầu. Vui lòng kiểm tra lại");
                                    g_IsKetThuc = false;
                                    return;
                                }
                                else
                                {
                                    g_IsKetThuc = true;
                                }
                                string XeNhan = g_CuocGoi.XeNhan;
                                if (Config_Common.CanhBaoKhiNhapXe == 0 && Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan > 0 && !StringTools.KiemTraXeDonThuocXeNhan(xeDon, XeNhan))
                                {
                                    string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", xeDon);
                                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message, xeDon))
                                    {
                                        confirmXeDon.ShowDialog();
                                        if (confirmXeDon.DialogResult == DialogResult.OK)
                                        {
                                            xeDon = confirmXeDon.XeDonResult;
                                            if (!new Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                                            {
                                                new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            g_IsKetThuc = false;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    g_Return = xeDon;
                    }
                    #endregion

                    #region XENHANDENDIEM
                    else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhanDenDiem)
                    {
                        // Check xe nhận
                        string xeNhanDenDiem = StringTools.ConvertToChuoiXeNhanChuan(s);
                        g_Return = s;
                        if (Config_Common.CanhBaoKhiNhapXe == 0 && !ValidateXeNhan(xeNhanDenDiem, g_CuocGoi.XeDon))
                            return;
                    }
                    #endregion XENHAN

                    #region GHI CHU
                    if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapGhiChuTongDai)
                    {
                        if (s.Length <= 0 && s.Equals(g_CuocGoi.GhiChuTongDai))
                        {
                            this.DialogResult = DialogResult.Cancel;
                            return;
                        }
                        g_Return = s;
                        g_CuocGoi.GhiChuTongDai = g_Return;
                        g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.TongGuiSangMoiKhach;
                        if (CuocGoi.TONGDAI_UpdateGhiChuTongDai(g_CuocGoi.IDCuocGoi, g_CuocGoi.GhiChuTongDai))
                        {
                            this.DialogResult = DialogResult.OK;
                            g_CloseForm = true;
                        }
                    }
                    #endregion GHI CHU

                    #region Tìm kiếm Xe
                    if (g_KieuNhap == KieuNhapTrenGridTongDai.TimKiemXe)
                    {
                        g_Return = s;
                        this.DialogResult = DialogResult.OK;
                        g_CloseForm = true;
                    }
                    #endregion

                    #region Nhập địa chỉ trả
                    if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapDiaChiTra)
                    {
                        g_Return = s;
                        this.DialogResult = DialogResult.OK;
                        g_CloseForm = true;
                    }
                    #endregion

                    #region Số phút báo khách chờ
                    else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapPhutKhachCho)
                    {
                        g_Return = s;
                        this.DialogResult = DialogResult.OK;
                        g_CloseForm = true;
                    }
                    #endregion

                    else if (s.Length > 0 && g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDungDiem)
                    {
                        string xeDungDiem = StringTools.ConvertToChuoiXeNhanChuan(s);
                        g_Return = xeDungDiem;
                    }
                    g_CloseForm = true;
                    this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private bool ValidateXeNhan(string XeNhan, string XeDon)
        {
            if (string.IsNullOrEmpty(XeNhan)) return true;
            if (g_CuocGoi.XeNhan == XeNhan.TrimEnd('.')) return true;

            MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
            string xeNhan_Filter = string.Empty;

           
            if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan > 0)
            {
                string strDSXeNhanDaNhanDiem = KiemTraXeNhanDaNhanCuoc(g_CuocGoi.IDCuocGoi, XeNhan);
                if (strDSXeNhanDaNhanDiem.Length > 0)
                {
                    MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                    if (msgDialog.Show(this, "Xe " + strDSXeNhanDaNhanDiem + " đang nhận điểm cần kiểm tra lại. Bạn có cho nhận điểm không?", "Thông báo", MessageBox.MessageBoxButtonsBA.OKCancel, MessageBox.MessageBoxIconBA.Question)
                        == DialogResult.Cancel.ToString())
                    {
                        g_CloseForm = false;
                        DialogResult = DialogResult.Cancel;
                        return false;
                    }
                    else
                    {
                        return Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan == 2;
                    }
                }              
            }
            #region==cmt===
            //if (!string.IsNullOrEmpty(xeNhanCu) && g_CuocGoi.GPS_KinhDo > 0 && g_CuocGoi.GPS_ViDo > 0)
            //{
            //    xeNhan_Filter = StringTools.GetXeNhanMoi(xeNhanCu, XeNhan);
            //    if (!string.IsNullOrEmpty(xeNhan_Filter))
            //    {
            //        if (g_CuocGoi.DanhSachXeDeCu != "")
            //        {
            //            try
            //            {
            //                //--------Luu log xe nhan khong thuoc xe de cu
            //                bw.RunWorkerAsync(xeNhan_Filter);
            //            }
            //            catch (Exception)
            //            {
            //            }
            //        }
            //        string xeNhan_QuaXa = string.Empty;
            //        xeNhan_QuaXa = CheckXeNhanQuaXa(xeNhan_Filter, g_CuocGoi.GPS_KinhDo, g_CuocGoi.GPS_ViDo);
            //        if (!string.IsNullOrEmpty(xeNhan_QuaXa))
            //        {
            //            g_Return = StringTools.ConvertToChuoiXeNhanChuan(XeNhan.Replace(xeNhan_QuaXa, ""));
            //        }
            //    }
            //}
            #endregion
            //Ktra xe nhận có tồn tại hay không.
            if (!KiemTraXeNhan(XeNhan))
            {
                msgBox.Show(this, "Vui lòng nhập chính xác xe nhận.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                g_CloseForm = false;
                this.DialogResult = DialogResult.Cancel;
                return false;
            }
            //Ktra xe nhận có nhập trùng hay không.
            
            if (StringTools.KiemTraTrungLapXeChay(XeNhan))
            {
                msgBox.Show(this, "Nhập trùng xe nhận", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                
                return false;
            }
            //Ktra xe nhận đã báo đón hay chưa(nếu đã báo thì ko cho phép nhập).
            else if (Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan > 0 && !StringTools.KiemTraXeDonThuocXeNhan(xeNhan_Filter, XeDon))
            {
                string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", XeDon);
                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message, XeDon))
                {
                    confirmXeDon.ShowDialog();
                    if (confirmXeDon.DialogResult == DialogResult.OK)
                    {
                        if (!new Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                        {
                            new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                            return false;
                        }
                    }
                    else
                    {
                        g_IsKetThuc = false;
                        return false;
                    }
                }
                return false;
            }
            else if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan > 0 && KiemTraXeCoTrongCuocKhachHienTai(XeNhan))
            {
                return Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan == 2;
            }
            return true;
        }
        private bool ValidateXeMK(string xeMK, string xeNhan)
        {
          
            if (string.IsNullOrEmpty(xeMK))
            {
                return true;
            }         
            if (string.IsNullOrEmpty(xeNhan) || !xeMK.Split('.').All(p => xeNhan.Split('.').Any(pi => pi == p)))
            {
                new MessageBox.MessageBoxBA().Show("Xe MK không thuộc xe nhận");
                return false;
            }
            return true;
        }
        /// <summary>
        /// kiem tra xe da co trong ds chua
        /// </summary>
        private bool KiemTraXeCoTrongCuocKhachHienTai(string SoHieuXe)
        {
            string[] arrTaxi = SoHieuXe.Split('.');
            foreach (CuocGoi objDH in G_ListCuocGoi)
            {
                if (objDH.IDCuocGoi == g_CuocGoi.IDCuocGoi) continue;
                if (objDH.XeNhan.Length > 0)
                {
                    string[] arrXeDaNhan = objDH.XeNhan.Split(".".ToCharArray());
                    for (int i = 0; i < arrXeDaNhan.Length; i++)
                        if (Array.IndexOf(arrTaxi, arrXeDaNhan[i]) > -1)
                        {
                            new MessageBox.MessageBoxBA().Show(string.Format("Xe {0} đã nhận đón ở địa chỉ {1}", arrXeDaNhan[i], objDH.DiaChiDonKhach));
                            return true;
                        }
                }
            }
            return false;
        }

        private string KiemTraXeNhanDaNhanCuoc(long IDCuocKhach, string strXeNhan)
        {
            if (strXeNhan.Length <= 0) return strXeNhan;
            DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
            string strDSXeNhanDaNhanDiem = "";
            string[] arrTaxi = strXeNhan.Split(".".ToCharArray());
            string SQLCondition = " AND  (len(XeNhan)>0) AND (ID <> " + IDCuocKhach.ToString() + " )";

            DataTable dsXeDaNhan = objDHTaxi.FT_GetAllOf_DienThoaiNew(SQLCondition);
            if (dsXeDaNhan!=null && dsXeDaNhan.Rows.Count>0)
            {
                foreach (string soHieuXeCanKiemTra in arrTaxi)
                {
                     if (KiemTraXeCoTrongCuocKhachHienTai(dsXeDaNhan,soHieuXeCanKiemTra))
                        strDSXeNhanDaNhanDiem += soHieuXeCanKiemTra + ".";
                }
            }
            return strDSXeNhanDaNhanDiem;
        }

        /// <summary>
        /// Kiểm tra xe có trong cuốc khách hiện tại đang nhận cuốc khác chưa
        /// </summary>
        /// <param name="dsXeDaNhan"></param>
        /// <param name="soHieuXeCanKiemTra"></param>
        /// <returns>false: xe đó đã nhận cuốc khác, true: ngược lại</returns>
        private bool KiemTraXeCoTrongCuocKhachHienTai(DataTable dsXeDaNhan, string soHieuXeCanKiemTra)
        {
            if (dsXeDaNhan.Rows.Count == 0)
            {
                return true;//xe này chưa nhận cuốc nào
            }
            else if (dsXeDaNhan.Rows.Count >0)
            {
                foreach (DataRow dr in dsXeDaNhan.Rows)
                {
                    string[] arrXeDaNhan = (dr[0].ToString()).Split(".".ToArray());
                    foreach (string xeDaNhan in arrXeDaNhan)
                    {
                        if (xeDaNhan==soHieuXeCanKiemTra)
                        {
                            return false;// xe cần kiểm tra đã nhận cuốc khác
                        }
                    }
                }
                return true;
            }
            return true;
        }


        
        /// <summary>
        /// Hàm kiểm tra xe nhận có nằm trong dsXe hệ thống đã nhập
        /// INPUT :
        ///      - xeNhan : 2343.6732.9000
        /// OUPPUT : True : xe nhan nằm trong dsXe của hệ thống
        ///          False: xe nhận không nằm trong ds xe của hệ thống.
        /// </summary>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        private bool KiemTraXeNhan(string xeNhan)
        {
            if (g_listSoHieuXe == null || g_listSoHieuXe.Count <= 0) return false;
            if (string.IsNullOrEmpty(xeNhan)) return true;

            string[] arrXeNhan = xeNhan.Split('.');
            G_XeDonLength = arrXeNhan.Length;
            
            for (int i = 0; i < G_XeDonLength; i++)
            {
                if (!g_listSoHieuXe.Contains(arrXeNhan[i]))
                    return false;                
            }
            return true;
        }

        private void frmInputOnGrid_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = !g_CloseForm;
            
        }

        private void txtInputGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon||g_KieuNhap ==KieuNhapTrenGridTongDai.NhapXeMK||g_KieuNhap==KieuNhapTrenGridTongDai.NhapXeNhan)
            {
                if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == 46)) && (!Char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = false;
                }
                else
                    e.Handled = true;
            }
        }
    }
}