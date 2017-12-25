using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Utils;
using System.Configuration;
using Taxi.Services;
using Taxi.Services.WCFServices;
using Taxi.Services.Operations;

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
        private bool g_IsThoatDuoc999 = false;
        private BackgroundWorker bw = new BackgroundWorker();
        string StartValue = "";
        public List<CuocGoi> G_ListCuocGoi { get; set; }
        public string GetGiaTriNhap()
        {
            return g_Return;
        }

        public bool IsKetThuc()
        {
            return g_IsKetThuc;
        }

        /// <summary>
        /// chuỗi Tọa độ xe nhận
        /// </summary>
        /// <returns></returns>
        public string GetGiaTriNhap_TD()
        {
            return g_Return_TD;
        }

        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
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
            g_IsThoatDuoc999 = IsThoat999;
        }

        public frmInputOnGrid(CuocGoi cuocGoi, KieuNhapTrenGridTongDai kieuNhap, List<string> listSoHieuXe, bool IsThoat999, string value)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            g_CuocGoi = cuocGoi;
            g_listSoHieuXe = listSoHieuXe;
            g_IsThoatDuoc999 = IsThoat999;
            StartValue = value;
        }
        public frmInputOnGrid(string DiaChiTra, KieuNhapTrenGridTongDai kieuNhap)
        {
            InitializeComponent();
            g_KieuNhap=kieuNhap;
            StartValue = DiaChiTra;
        }
        private void frmInputOnGrid_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiControl();
            }
            catch (Exception ex)
            {

            }
            
            //if (g_CuocGoi.DanhSachXeDeCu != "" && g_CuocGoi.GPS_KinhDo > 0 && g_CuocGoi.GPS_ViDo > 0)
            //{
            //    bw.DoWork += bw_DoWork;
            //    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            //}
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
                string xeNhanMoi = "";
                if (StartValue == "\b")
                {
                    xeNhanMoi = g_CuocGoi.XeNhan == null || g_CuocGoi.XeNhan == "" ? string.Empty : g_CuocGoi.XeNhan.Substring(0,g_CuocGoi.XeNhan.Length-1);
                }
                else if (StartValue == ".")
                {
                    xeNhanMoi = "";
                }
                else
                {
                    xeNhanMoi = g_CuocGoi.XeNhan == null || g_CuocGoi.XeNhan == "" ? StartValue : g_CuocGoi.XeNhan + "." + StartValue;
                }
                txtInputGrid.Text = xeNhanMoi;
                g_XeNhan_Truoc = txtInputGrid.Text.Trim();//-------Lấy dữ liệu xe nhận đã nhập trước đó
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
                        if (!g_CuocGoi.XeDenDiem.Contains("."))
                            txtInputGrid.Text = g_CuocGoi.XeDenDiem;
                        else
                            txtInputGrid.Text = "";
                    }
                }
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhanDenDiem)
            {
                lblLabel.Text = "Xe đến điểm";
                string xeNhanMoi = "";
                if (StartValue == "\b")
                {
                    xeNhanMoi = g_CuocGoi.XeDenDiem == null || g_CuocGoi.XeDenDiem == "" ? string.Empty : g_CuocGoi.XeDenDiem.Substring(0, g_CuocGoi.XeDenDiem.Length - 1);
                }
                else if (StartValue == ".")
                {
                    xeNhanMoi = "";
                }
                else
                {
                    xeNhanMoi = g_CuocGoi.XeDenDiem == null || g_CuocGoi.XeDenDiem == "" ? StartValue : g_CuocGoi.XeDenDiem + "." + StartValue;
                }
                txtInputGrid.Text = g_CuocGoi.XeDenDiem == null || g_CuocGoi.XeDenDiem == "" ? "" + StartValue : g_CuocGoi.XeDenDiem + "." + StartValue;
            }
            else if (g_KieuNhap == Utils.KieuNhapTrenGridTongDai.TimKiemXe)
            {
                lblLabel.Text = "Tìm kiếm xe";
                txtInputGrid.Focus();
                this.Activate();

            }
            else if (g_KieuNhap == Utils.KieuNhapTrenGridTongDai.NhapDiaChiTra)
            {
                lblLabel.Text = "Nhập địa chỉ trả";
                txtInputGrid.Text = StartValue;
                txtInputGrid.Focus();
                this.Activate();
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
                MessageBox.MessageBoxBA msgBox = new Taxi.MessageBox.MessageBoxBA();
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
                    int kenhVung = 0;
                    try
                    {
                        kenhVung = Convert.ToInt32(s);
                        if (!CheckVungNamTrongVungCauHinh(kenhVung))
                        {
                            kenhVung = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        kenhVung = 0;
                    }
                    if (kenhVung <= 0)
                    {
                        msgBox.Show(this, "Vùng phải lớn hơn 0 và nằm trong vùng được cấp phép.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Question);
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
                    if (!ValidateXeNhan(xeNhan, g_CuocGoi.XeDon))
                    {
                        g_CloseForm = false;
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
                            if (!KiemTraXeNhan(xeDon) && (!StringTools.KiemTraTrungLapXeChay(xeDon)))
                            {
                                msgBox.Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Question);
                                g_CloseForm = false;
                                this.DialogResult = DialogResult.Cancel;
                                return;
                            }
                            string KenhVung_Trung = string.Empty;
                            string xeDangCoKhach = new CuocGoi().TONGDAI_UPDATE_XEDON_CHECKVALID(xeDon, g_CuocGoi.ThoiDiemGoi,out KenhVung_Trung);
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
                                            if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, Taxi.Utils.KieuCanhBaoKhiNhapThongTin.TrungXeDon))
                                            {
                                                new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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
                            if (G_XeDonLength < g_CuocGoi.SoLuong)
                            {
                                const string message = "Chưa đủ xe số lượng xe yêu cầu";
                                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message))
                                {
                                    confirmXeDon.ShowDialog();
                                    if (confirmXeDon.DialogResult == DialogResult.OK)
                                    {
                                        if (confirmXeDon.Result == 2)
                                        {
                                            if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon))
                                            {
                                                new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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
                            else if (G_XeDonLength > g_CuocGoi.SoLuong)//*hot
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
                            if (Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan > 0 && !StringTools.KiemTraXeDonThuocXeNhan(xeDon, XeNhan))
                            {
                                string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", xeDon);
                                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message,xeDon))
                                {
                                    confirmXeDon.ShowDialog();
                                    if (confirmXeDon.DialogResult == DialogResult.OK)
                                    {
                                        xeDon = confirmXeDon.XeDonResult;
                                        if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                                        {
                                            new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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
                    g_Return = xeDon ;
                }
                #endregion

                #region XENHANDENDIEM
                else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhanDenDiem)
                {
                    // Check xe nhận
                    string xeNhanDenDiem = StringTools.ConvertToChuoiXeNhanChuan(s);
                    g_Return = s;
                    if (!ValidateXeNhan(xeNhanDenDiem, g_CuocGoi.XeDon))
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
                if (g_KieuNhap == Utils.KieuNhapTrenGridTongDai.TimKiemXe)
                {
                    g_Return = s;
                    this.DialogResult = DialogResult.OK;
                    g_CloseForm = true;
                }
                #endregion

                #region Nhập xe đến điểm
                if (g_KieuNhap == Utils.KieuNhapTrenGridTongDai.NhapDiaChiTra)
                {
                    g_Return = s;
                    this.DialogResult = DialogResult.OK;
                    g_CloseForm = true;
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
            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                // MessageBox.Show("Processing cancelled.");
                return;
            }
        }

        private bool XuLyCoThongTinXeDon(string XeDon)
        {
            MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

            if (XeDon == "000")
            {
                if (g_CuocGoi.XeNhan.Length <= 0)
                    g_CuocGoi.XeNhan = "000";
                else
                    g_CuocGoi.XeNhan += ".000";  // cong them xe cu                
            }

            if (StringTools.KiemTraTrungLapXeChay(XeDon))
            {
                msg.Show("Bạn phải nhập xe taxi chạy chính xác");
                txtInputGrid.Focus();
                return false;
            }
            return true;
        }
        //private void ValidateXeDon(string XeNhan, string XeDon, string XeDenDiem)
        //{
        //    MessageBox.MessageBox msgBox = new Taxi.MessageBox.MessageBox();
        //    string XeNhanCu = string.Empty;
        //    string XeNhanMoiNhap = XeNhan;
        //    if (!string.IsNullOrEmpty(g_CuocGoi.XeNhan))
        //    {
        //        XeNhanMoiNhap = XeNhan.Replace(g_CuocGoi.XeNhan, "").TrimStart('.').TrimEnd('.');
        //        XeNhanCu = g_CuocGoi.XeNhan + ".";
        //    }
        //    Ktra xe đón có tồn tại hay không.
        //    if (!KiemTraXeNhan(XeDon))
        //    {
        //        msgBox.Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //        g_CloseForm = false;
        //        this.DialogResult = DialogResult.Cancel;
        //        return;
        //    }
        //    Ktra xe đón có nhập trùng hay không.
        //    else if (KiemTraTrungLapXeChay(XeDon))
        //    {
        //        msgBox.Show(this, "Nhập trùng xe đón", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //        g_CloseForm = false;
        //        this.DialogResult = DialogResult.Cancel;
        //        return;
        //    }
        //    Ktra đã đủ số xe đón chưa
        //    if (G_XeDonLength < g_CuocGoi.SoLuong)
        //    {
        //        string confirm = msgBox.Show("Chưa đủ xe số lượng xe yêu cầu. Tiếp tục điều xe đón ?", "Chưa đủ số lượng xe yêu cầu", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question);
        //        if (confirm == DialogResult.Yes.ToString())
        //        {
        //            if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN_DUXEDON(g_CuocGoi.IDCuocGoi, false,false))
        //            {
        //                new MessageBox.MessageBox().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            g_Return = XeDon;
        //            return;
        //        }
        //    }
        //    if (!KiemTraXeDonThuocXeNhan2(XeDon, XeDenDiem) || !KiemTraXeDonThuocXeNhan2(XeDon, XeNhan))
        //    {
        //        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon())
        //        {
        //            confirmXeDon.ShowDialog();
        //            if (confirmXeDon.DialogResult == DialogResult.OK)
        //            {
        //                if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN_XEDON(g_CuocGoi.IDCuocGoi, confirmXeDon.Result, false))
        //                {
        //                    new MessageBox.MessageBox().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                return;
        //            }
        //        }
        //    }
        //    g_Return = XeDon;
        //}

        private bool ValidateXeNhan(string XeNhan, string XeDon)
        {
            if (string.IsNullOrEmpty(XeNhan)) return true;
            if (g_CuocGoi.XeNhan == XeNhan.TrimEnd('.')) return true;

            MessageBox.MessageBoxBA msgBox = new Taxi.MessageBox.MessageBoxBA();
            string xeNhanCu = g_CuocGoi.XeNhan;
            string xeNhan_Filter = string.Empty;

           
            if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan > 0 )
            {
                string strDSXeNhanDaNhanDiem = KiemTraXeNhanDaNhanCuoc(g_CuocGoi.IDCuocGoi, XeNhan);
                if (strDSXeNhanDaNhanDiem.Length > 0)
                {
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                    if (msgDialog.Show(this, "Xe " + strDSXeNhanDaNhanDiem + " đang nhận điểm cần kiểm tra lại. Bạn có cho nhận điểm không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() 
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
            //Ktra xe nhận có tồn tại hay không.
            if (!KiemTraXeNhan(XeNhan))
            {
                msgBox.Show(this, "Vui lòng nhập chính xác xe nhận.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                g_CloseForm = false;
                this.DialogResult = DialogResult.Cancel;
                return false;
            }
            //Ktra xe nhận có nhập trùng hay không.
            
            if (StringTools.KiemTraTrungLapXeChay(XeNhan))
            {
                msgBox.Show(this, "Nhập trùng xe nhận", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                
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
                        XeDon = confirmXeDon.XeDonResult;
                        if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, Taxi.Utils.KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                        {
                            new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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

        /// <summary>
        /// kiem tra xe da co trong ds chua
        /// </summary>
        /// <param name="lstDienThoai"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
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
                            new Taxi.MessageBox.MessageBoxBA().Show(string.Format("Xe {0} đã nhận đón ở địa chỉ {1}", arrXeDaNhan[i], objDH.DiaChiDonKhach));
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
            string SQLCondition = " AND  (len(XeNhan)>0) AND (ID <> " + IDCuocKhach.ToString() + " ) ";

            List<DieuHanhTaxi> lstDienThoai = objDHTaxi.FT_GetAllOf_DienThoai(SQLCondition);
            if (lstDienThoai != null && lstDienThoai.Count > 0)
            {
                for (int i = 0; i < arrTaxi.Length; i++)
                {
                    if (KiemTraXeCoTrongCuocKhachHienTai(lstDienThoai, arrTaxi[i]))
                        strDSXeNhanDaNhanDiem += arrTaxi[i].ToString() + ".";
                }
            }
            return strDSXeNhanDaNhanDiem;
        }

        private bool KiemTraXeCoTrongCuocKhachHienTai(List<DieuHanhTaxi> lstDienThoai, string SoHieuXe)
        {
            foreach (DieuHanhTaxi objDH in lstDienThoai)
            {
                if (!string.IsNullOrEmpty(objDH.XeNhan)&&objDH.XeNhan.Length > 0)
                {
                    string[] arrXeDaNhan = objDH.XeNhan.Split(".".ToCharArray());
                    for (int i = 0; i < arrXeDaNhan.Length; i++)
                        if (arrXeDaNhan[i] == SoHieuXe)
                            return true;
                }
            }
            return false;
        }

        #region -----------------------Xe nhận - GPS--------------------------------
        private string CheckXeNhanQuaXa(string xeNhan, double KD, double VD)
        {
            if (KD <= 0) return xeNhan.TrimEnd('.').TrimStart('.');

            string XeNhan = string.Empty;
            double KhoangCach = 0;
            string[] arrXeNhan = xeNhan.Split('.');
            if (arrXeNhan.Length > 0)
            {
                for (int i = 0; i < arrXeNhan.Length; i++)
                {
                    try
                    {
                        KhoangCach = new SyncServiceOnlineClient().GetKCXeNhan_DiemDonKhach(KD, VD, ThongTinCauHinh.GPS_MaCungXN, arrXeNhan[i]);
                    }
                    catch (Exception ex)
                    {
                        return xeNhan;
                    }

                    if (KhoangCach > ThongTinCauHinh.GPS_BKXeNhan)
                    {
                        string message = string.Format("Xe {0} cách điểm đón khách {1}(km).Đã phát đàm và vẫn cho nhận?", arrXeNhan[i], Math.Round(KhoangCach / 1000, 1));
                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeNhanQuaXa, message))
                        {
                            confirmXeDon.ShowDialog();
                            if (confirmXeDon.DialogResult == DialogResult.OK)
                            {
                                if (confirmXeDon.Result == 1)
                                {
                                    if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeNhanQuaXa))
                                    {
                                        new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                    }
                                }
                                else
                                {
                                    XeNhan += arrXeNhan[i] + ".";
                                }
                            }
                            else
                            {
                                XeNhan = xeNhan;
                            }
                        }
                    }
                    else if (KhoangCach == -1)
                    {
                        new MessageBox.MessageBoxBA().Show(string.Format("Xe {0} đang mất tín hiệu", arrXeNhan[i]), "Xe nhận mất tín hiệu", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        //XeNhan += arrXeNhan[i] + ".";
                    }
                    else if (KhoangCach == -2)
                    {
                        new MessageBox.MessageBoxBA().Show(string.Format("Lỗi, không tìm được xe {0}", arrXeNhan[i]), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        //XeNhan += arrXeNhan[i] + ".";
                    }
                }
            }
            return XeNhan.TrimEnd('.');
        }
        private string g_Return_TD = string.Empty;
        private string g_XeNhan_Truoc = string.Empty;
        private bool updateDSXeNhan_ToaDo()
        {
            try
            {
                double KD = g_CuocGoi.GPS_KinhDo;
                double VD = g_CuocGoi.GPS_ViDo;
                if (KD == 0 || VD == 0)
                    return false;

                string dsXeNhan = txtInputGrid.Text.Trim();//Chuỗi xe nhận hiện tại vừa nhập
                if (dsXeNhan == "")
                    return false;

                string dsToaDo = "";
                string[] arrDSToaDoTruoc = null;
                string[] arrDSXeNhan = dsXeNhan.Split('.');//-----Cắt chuỗi xe nhận vừa nhập
                string[] arrDSXeNhanTruoc = null;
                string dsXeNhanTruoc = "";
                string dsToaDoTruoc = "";
                string dsXeNhanMoi = "";
                string[] arrDSToaDoMoi;

                if (g_XeNhan_Truoc != "")//-----TH đã có xe nhận đã nhập trước đó
                {
                    if (g_CuocGoi.XeNhan_TD == null || g_CuocGoi.XeNhan_TD == "")
                    {
                        //-------Nếu Tọa độ xe nhận cũ không có, lấy lại tọa độ của xe nhận cũ
                        string toaDoTruoc = "";// getToaDoXeNhanMoi(g_CuocGoi.XeNhan, KD, VD);
                        if (toaDoTruoc != "")
                            arrDSToaDoTruoc = toaDoTruoc.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
                    }
                    else
                    {
                        arrDSToaDoTruoc = g_CuocGoi.XeNhan_TD.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
                    }

                    arrDSXeNhanTruoc = g_XeNhan_Truoc.Split('.');//-----Cắt chuỗi xe nhận cũ
                    //----phân tích chuỗi xe nhận vừa nhập để so sánh xem xe nhận nào là cũ và xe nào là mới nhập
                    for (int i = 0; i < arrDSXeNhan.Length; i++)
                    {
                        if (arrDSXeNhan[i] != "")//-----Nếu xe nhận khác rỗng
                        {
                            //---duyệt trong chuỗi xe nhận trước đó
                            for (int j = 0; j < arrDSXeNhanTruoc.Length; j++)
                            {
                                if (arrDSXeNhanTruoc[j] == arrDSXeNhan[i])//----Nếu xe nhận cũ có nằm trong danh sách xe nhận vừa nhập
                                {//---Gán xe nhận và tọa độ trước ra 1 chuỗi khác (1)
                                    dsXeNhanTruoc = string.Format("{0}{1}.", dsXeNhanTruoc, arrDSXeNhan[i]);
                                    dsToaDoTruoc = string.Format("{0}{1},", dsToaDoTruoc, arrDSToaDoTruoc[j]);
                                    break;
                                }
                                else//----Nếu xe nhận cũ không nằm trong danh sách xe nhận vừa nhập 
                                {
                                    //-----Kiểm tra xem xe nhận có tồn tại trong chuỗi đã nhập trước đó ko.
                                    if (Array.IndexOf(arrDSXeNhanTruoc, arrDSXeNhan[j]) == 0)
                                    {
                                        dsXeNhanMoi = string.Format("{0}{1}.", dsXeNhanMoi, arrDSXeNhan[i]);//Gán xe nhận mới vào chuỗi khác (2)
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (dsXeNhanMoi.LastIndexOf('.') > 0)
                        dsXeNhanMoi = dsXeNhanMoi.Substring(0, dsXeNhanMoi.Length - 1);
                }
                else//-----TH chưa có xe nhận trước đó
                {
                    dsXeNhanMoi = dsXeNhan;
                }

                if (dsXeNhanMoi != "")
                {
                    //dsToaDo = string.Format("{0}{1},", dsToaDoTruoc, getToaDoXeNhanMoi(dsXeNhanMoi, KD, VD));//----Tọa độ của danh sách xe nhận đã sắp xếp
                    dsToaDo = dsToaDoTruoc;
                    g_Return = string.Format("{0}{1}.", dsXeNhanTruoc, dsXeNhanMoi);//----Danh sách xe nhận đã sắp xếp
                }
                else
                {
                    dsToaDo = dsToaDoTruoc;//----Tọa độ của danh sách xe nhận đã sắp xếp
                    g_Return = dsXeNhanTruoc;//----Danh sách xe nhận đã sắp xếp
                }
                if (dsToaDo.LastIndexOf(',') > 0)
                    dsToaDo = dsToaDo.Substring(0, dsToaDo.Length - 1);
                if (g_Return.LastIndexOf('.') > 0)
                    g_Return = g_Return.Substring(0, g_Return.Length - 1);

                g_Return_TD = dsToaDo;// chuoi toa do cua xe nhan da sap xep

                return CuocGoi.TONGDAI_UPDATE_XENHAN_TOADO(g_CuocGoi.IDCuocGoi, dsToaDo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string getToaDoXeNhanMoi(string dsXeNhan, double KD, double VD)
        {
            string dsToaDo = "";
            string[] arrDSXeNhan = dsXeNhan.Split('.');
            for (int i = 0; i < arrDSXeNhan.Length; i++)
            {
                //gọi service trả về tọa độ của 1 xe đang có tín hiệu
                //dsToaDo = string.Format("{0}{1},", dsToaDo, ServiceOnlineFactory.Inst.LayToaDoXeNhan(KD, VD, arrDSXeNhan[i]));
            }
            if (dsToaDo.Length > 1)
                dsToaDo = dsToaDo.Substring(0, dsToaDo.Length - 1);
            return dsToaDo;
        }
        #endregion
        
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
    }
}