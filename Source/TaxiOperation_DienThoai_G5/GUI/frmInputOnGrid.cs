using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmInputOnGrid : Form
    {
        private CuocGoi g_CuocGoi;
        private KieuNhapTrenGridTongDai g_KieuNhap;
        private List<string> g_listSoHieuXe;
        private string g_Return = string.Empty;
        private int G_XeDonLength = 0;
        private  bool g_CloseForm = false ;
        private bool g_IsKetThuc = false;
        private BackgroundWorker bw = new BackgroundWorker();
        private string StartValue = "";
        public string GetGiaTriNhap()
        {
            return g_Return;
        }

        public bool IsKetThuc()
        {
            return g_IsKetThuc;
        }

        /// <summary>
        /// Check vung nhan năm trong vùng cấu hình.
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
            else bCheck = false;
            return bCheck;
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

        private void frmInputOnGrid_Load(object sender, EventArgs e)
        {
            HienThiControl();
            if (g_CuocGoi.DanhSachXeDeCu != "" && g_CuocGoi.GPS_KinhDo > 0 && g_CuocGoi.GPS_ViDo > 0)
            {
                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            }
        }

        /// <summary>
        /// Hiển thị control
        /// </summary>
        private void HienThiControl()
        {
            string dot = ".";
            if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapChuyenKenh)
            {
                lblLabel.Text = "Chuyển kênh";
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhan)
            {
                lblLabel.Text = "Xe nhận";
                string xeNhanMoi ;
                if (StartValue == "\b")
                {
                    xeNhanMoi = string.IsNullOrEmpty(g_CuocGoi.XeNhan) ? string.Empty : g_CuocGoi.XeNhan.Substring(0,g_CuocGoi.XeNhan.Length-1);
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
                    txtInputGrid.Text = g_CuocGoi.XeDon;
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
                                txtInputGrid.Text = g_CuocGoi.BTBG_NoiDungXuLy;
                                break;
                            case NhapXeDon.XeDenDiem:
                                txtInputGrid.Text = g_CuocGoi.XeDenDiem;
                                break;
                            case NhapXeDon.XeDenDiem_XeMK_XeNhan:
                                {
                                    if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem))
                                    {
                                        txtInputGrid.Text = g_CuocGoi.XeDenDiem;

                                    }
                                    else
                                        if (!string.IsNullOrEmpty(g_CuocGoi.BTBG_NoiDungXuLy))
                                        {
                                            txtInputGrid.Text = g_CuocGoi.BTBG_NoiDungXuLy;
                                        }
                                        else
                                        {

                                            txtInputGrid.Text = g_CuocGoi.XeNhan;
                                        }
                                    break;
                                }

                            case NhapXeDon.XeMK_XeDenDiem_XeNhan:
                                {
                                    if (!string.IsNullOrEmpty(g_CuocGoi.BTBG_NoiDungXuLy))
                                    {
                                        txtInputGrid.Text = g_CuocGoi.BTBG_NoiDungXuLy;
                                    }
                                    else
                                        if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem))
                                        {
                                            txtInputGrid.Text = g_CuocGoi.XeDenDiem;
                                        }
                                        else
                                        {

                                            txtInputGrid.Text = g_CuocGoi.XeNhan;
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
                if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiem)&&g_CuocGoi.XeDenDiem.Substring(g_CuocGoi.XeDenDiem.Length - 1,1) == ".")
                    dot = string.Empty;
                txtInputGrid.Text = string.IsNullOrEmpty(g_CuocGoi.XeDenDiem) ? "" + StartValue : g_CuocGoi.XeDenDiem + dot + StartValue;
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDungDiem)
            {
                lblLabel.Text = "Xe dừng điểm";
                if (!string.IsNullOrEmpty(g_CuocGoi.XeDungDiem) && g_CuocGoi.XeDungDiem.Substring(g_CuocGoi.XeDungDiem.Length - 1,1) == ".")
                    dot = string.Empty;
                txtInputGrid.Text= string.IsNullOrEmpty(g_CuocGoi.XeDungDiem)?""+StartValue:g_CuocGoi.XeDungDiem+dot+StartValue;
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
            //else if (keyData == Keys.Enter)
            //{
            //    this.Close();
            //    this.DialogResult = DialogResult.OK;
            //    return true;
            //}
            return false;
        }
        #endregion XU LY HOTKEY

        private void txtInputGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                g_CloseForm = true;
                MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
                string s = StringTools.TrimSpace( txtInputGrid.Text );
                
                #region KENH
                if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapChuyenKenh)
                {
                    if (s.Length <=0)
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
                    if (CuocGoi.TONGDAI_UpdateChuyenVung(g_CuocGoi.IDCuocGoi,ThongTinDangNhap.USER_ID,g_CuocGoi.Vung,""))
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
                    ValidateXeNhan(xeNhan,g_CuocGoi.XeDon);
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
                                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.TrungXeDon, message))
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
                                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message))
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
                    //string xeNhanDenDiem = StringTools.ConvertToChuoiXeNhanChuan(s);
                    g_Return = s;
                    //ValidateXeNhan(xeNhanDenDiem, g_CuocGoi.XeDon);
                }
                #endregion XENHAN

                #region Xe dừng điểm
                else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDungDiem)
                {
                    g_Return = s;
                }
                #endregion

                #region Số phút báo khách chờ
                else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapPhutKhachCho)
                {
                    g_Return = s;
                }
                #endregion

                g_CloseForm = true;
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //string xeNhan = e.Argument.ToString();
            //if (!KiemTraXeDonThuocXeNhan(xeNhan, g_CuocGoi.DanhSachXeDeCu))
            //{
            //    new Taxi.Data.CuocGoi().TONGDAI_GhiLog_XeNhan(g_CuocGoi.IDCuocGoi, xeNhan, g_CuocGoi.GPS_KinhDo, g_CuocGoi.GPS_ViDo, g_CuocGoi.DanhSachXeDeCu, g_CuocGoi.DanhSachXeDeCu_TD);
            //}
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void ValidateXeNhan(string XeNhan, string XeDon)
        {
            if (string.IsNullOrEmpty(XeNhan)) return;
            if (g_CuocGoi.XeNhan == XeNhan.TrimEnd('.')) return;

            MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
            string xeNhan_Filter = string.Empty;

            //Ktra xe nhận có nhập trùng hay không.
            if (KiemTraTrungLapXeChay(XeNhan))
            {
                msgBox.Show(this, "Nhập trùng xe nhận", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                g_CloseForm = false;
                this.DialogResult = DialogResult.Cancel;
            }
            //Ktra xe nhận đã báo đón hay chưa(nếu đã báo thì ko cho phép nhập).
            else if (!KiemTraXeDonThuocXeNhan2(xeNhan_Filter, XeDon))
            {
                msgBox.Show(this, "Xe [" + xeNhan_Filter + "] đã báo đón khách", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                g_CloseForm = false;
                this.DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Hàm kiểm tra xe nhận có nằm trong dsXe hệ thống đã nhập
        /// INPUT :
        ///      - xeNhan : 2343.6732.9000
        /// OUPPUT : True : xe nhan nằm trong dsXe của hệ thống
        ///          False: xe nhận không nằm trong ds xe của hệ thống.
        /// </summary>
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

        private bool KiemTraXeDonThuocXeNhan2(string xeDon, string xeNhan)
        {
            if (string.IsNullOrEmpty(xeDon) || string.IsNullOrEmpty(xeNhan)) return true;
            string[] arrXeDon = xeDon.Split(".".ToCharArray());
            for (int i = 0; i < arrXeDon.Length; i++)
            {
                if (!xeNhan.Contains(arrXeDon[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Kiem tra trong cac xe da trung nhau khong
        /// </summary>
        private bool KiemTraTrungLapXeChay(string DanhSachXe)
        {
            string[] arrTaxi = DanhSachXe.Split('.');
            var hash = new HashSet<string>();
            foreach (var str in arrTaxi)
                if(hash.Contains(str))
                    return true;
            return false;
        }

        private void frmInputOnGrid_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = !g_CloseForm;
            
        }
    }
}