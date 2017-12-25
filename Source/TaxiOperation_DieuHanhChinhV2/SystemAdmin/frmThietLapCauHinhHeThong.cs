using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Taxi.Business.QuanTri;
using Taxi.Business;
using Taxi.Utils;
using System.IO;
using System.Diagnostics;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Linq;
using System.Collections;
using Taxi.Common.Extender;
namespace Taxi.GUI
{
    public partial class frmThietLapCauHinhHeThong : Form
    {

        /// <summary>
        /// thông tin lưu ở trong bàng phải được thiết lập từ đầu
        /// </summary>
        private string g_LogoCongTy = "";
        private bool g_bCoThayLogo = false;

        private Timer TimerCapturePhone;

        public frmThietLapCauHinhHeThong()
        {
            InitializeComponent();
           
        }

        private void frmThietLapCauHinhHeThong_Load(object sender, EventArgs e)
        {
            inputEnumLookUp_ServiceMap1.Bind();
            LoadThongTinCauHinh();
            this.GetDSMayTinhDienThoai();
            this.GetDSMayTinhTongDai();
            this.GetDSMayTinhMoiKhach();
            this.GetDSMayGoiRa();
            if (ThongTinDangNhap.USER_ID.ToLower() != "admin")
            {
                PhanQuyen(TabCauHinh, ThongTinDangNhap.PermissionsFull);
            }
            chkGopKenh_TrangThai_Config.Checked = Config_Common.GopLine;
            //ConfigMap();

            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = 5000;
            TimerCapturePhone.Tick += TimerCapturePhone_Tick;
            TimerCapturePhone.Start();
            TimerCapturePhone.Enabled = false;
        }

        private void PhanQuyen(TabControl tabCauHinh, ArrayList DanhSachQuyen)
        {
            if (tabCauHinh != null && tabCauHinh.Tag != null && tabCauHinh.Tag.ToString().Length <= 0)
                tabCauHinh.Visible = true;
            foreach (TabPage tabPage in tabCauHinh.TabPages)
            {
                if (DanhSachQuyen != null && tabPage.Tag != null)
                {
                    if (!DanhSachQuyen.Contains(tabPage.Tag.ToString()))
                        tabCauHinh.TabPages.Remove(tabPage);
                }
            }
        }

        public void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            //GetThongTinCauHinhBatCuoc();
        }       

        #region Chon Tab

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabCauHinh.SelectedTab.Name == "tabCauHinhHeThong")
                {
                    btnHuyBo.Visible = true;
                    btnLuu.Visible = true;
                    TimerCapturePhone.Enabled = false;
                }
                else if (TabCauHinh.SelectedTab.Name == "tabIPSetting")
                {
                    btnHuyBo.Visible = false ;
                    btnLuu.Visible = false;
                    TimerCapturePhone.Enabled = false;
                }
                else if (TabCauHinh.SelectedTab.Name == "tabThongTinCa")
                {
                    DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        calDauCa1.Value = Convert.ToDateTime(dr["DauCa1"].ToString());
                        calKetThucCa1.Value = Convert.ToDateTime(dr["KetThucCa1"].ToString());
                        calKetThucCa2.Value = Convert.ToDateTime(dr["KetThucCa2"].ToString());
                    }
                    btnHuyBo.Visible = false;
                    btnLuu.Visible = false;
                    TimerCapturePhone.Enabled = false;
                }
                else if (TabCauHinh.SelectedTab.Name == "tabThoatCuoc999")
                {
                    HienThiDSCauHinhThoatCuoc();
                    btnHuyBo.Visible = false;
                    btnLuu.Visible = false;
                    TimerCapturePhone.Enabled = true;
                }
                else
                {
                    btnHuyBo.Visible = true;
                    btnLuu.Visible = true;
                }
            }
            catch (Exception Ex)
            {
            }
        }

        #endregion Chon Tab         

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string TenCongTy = StringTools.TrimSpace(txtTenCongTy.Text);

            string LogoPath = g_LogoCongTy;
            if (g_bCoThayLogo)
            {
                // lấy file name

                FileInfo info = new FileInfo(g_LogoCongTy);

                LogoPath = info.Name;
                string DesFile = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\Reports\\" + LogoPath;
                FileTools.CopyFileTo(g_LogoCongTy, DesFile);


            }

            string SoDauCuaTongDai = "";
            if (chkCoSuDungTongDai.Checked) SoDauCuaTongDai = StringTools.TrimSpace(txtSoDauTongDai.Text);
            bool bTinhTienCuoc2ChieuNgatCuoc = chkTinhTienCuocHaiChieuKhongNgatCuoc.Checked;
            int SoGiayGioiHanThoiGianChuyenTongDai = int.Parse(StringTools.TrimSpace(txtThoiGianChuyenTongDai.Text));
            int SoGiayGioiHanThoiGianDieuXe = int.Parse(StringTools.TrimSpace(txtThoiGianDieuXe.Text));
            int SoGiayGioiHanThoiGianDonKhach = int.Parse(StringTools.TrimSpace(txtThoiGianDonKhach.Text));
            int SoPhutGioiHanMatLienLac = int.Parse(StringTools.TrimSpace(txtGioiHanMLL.Text));
            int SoPhutGioiHanMatLienLacBaoNghi = int.Parse(StringTools.TrimSpace(txtGioiHanMLLBaoNghi.Text));
            int SoPhutGioiHanMatLienLacBaoDiSanBay = int.Parse(StringTools.TrimSpace(txtGioiHanMLLDiSanBay.Text));
            int SoPhutGioiHanMatLienLacBaoDiDuongDai = int.Parse(StringTools.TrimSpace(txtGioiHanMLLDiSanBay.Text));
            string ThuMucDuLieuTanasonic = txtThuMucDuLieuTanasonic.Text;
            string ThuMucFileAmThanh = txtThuMucFileAmThanh.Text;
            string TatCaLinesHeThong = StringTools.TrimSpace(txtLineHeThong.Text);
            string CacLineTaxi = StringTools.TrimSpace(txtLineTaxi.Text);
            string CacVungTongDai = StringTools.TrimSpace(txtCacVungTongDai.Text);
            if (CacVungTongDai.Length <= 0) CacVungTongDai = "1";
            string PhoneTaxi = StringTools.TrimSpace(txtPhoneTaxi.Text);
            bool HasTongDai = chkHasCOMPort.Checked;
            int SoDongCuocGoiDaGiaiQuyet = Convert.ToInt16(txtDongCuocGoiDaGiaiQuyet.Text);
            bool bKiemTraXeDaRaHoatDong = chkKiemTraXeDaRaHoatDong.Checked;

            bool KichHoachTaxiGroupDon = chkKichHoatTaxiGroupDon.Checked;
            byte SoPhutGiuKhachChuaCoXeNhan = 0;
            byte SoPhutGiuKhachCoXeNhan = 0;
            byte SoPhutGiuKhachLai = 0;
            try
            {
                SoPhutGiuKhachChuaCoXeNhan = Convert.ToByte(txtSoPhutChuaCoXeNhan.Text);
            }
            catch (Exception ex) { SoPhutGiuKhachChuaCoXeNhan = 5; }
            try
            {
                SoPhutGiuKhachCoXeNhan = Convert.ToByte(txtSoPhutCoXeNhan.Text);
            }
            catch (Exception ex) { SoPhutGiuKhachCoXeNhan = 10; }
            try
            {
                SoPhutGiuKhachLai = Convert.ToByte(txtSoPhutGiuKhachLai.Text);
            }
            catch (Exception ex) { SoPhutGiuKhachLai = 15; }


            if (PhoneTaxi.Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập số điện thoại công ty.");
                txtPhoneTaxi.Focus();
                return;
            }
            if (CacVungTongDai.Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập các vùng tổng đài.");
                txtCacVungTongDai.Focus();
                return;
            }
            if (!ValidateLinesHeThong(TatCaLinesHeThong, CacLineTaxi))
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn cần phải đặt lại thông tin lines hệ thống,(0<Lines <=32) và lines taxi phải thuộc trong lines hệ thống.");
                txtLineTaxi.Focus();
                return;
            }

            #region Tab Config GPS
            string MaCungXn = "";
            string BanDo = "";
            int Zoom = 0;
            float KinhDo = 0;
            float ViDo = 0;
            bool TrangThai = false;
            string TenTinh = string.Empty;

            if (!validConfigGPS())
                return;

            MaCungXn = txtGPS_MaCungXN.Text;
            BanDo = lblGPS_LoaiBanDo.Text.Trim();
            Zoom = Convert.ToInt32(lblGPS_mucZoom.Text);
            KinhDo = float.Parse(lblGPS_KinhDo.Text);
            ViDo = float.Parse(lblGPS_ViDo.Text);
            TenTinh = txtGPS_TenTinh.Text;

            TrangThai = ckGPS_KetNoi.Checked ? true : false;

            int BKGioiHan = 500;
            int BKXeNhan = 500;
            int.TryParse(txtGPS_BanKinhTimXe.Text.Trim(), out BKGioiHan);
            int.TryParse(txtBKXeNhan.Text.Trim(), out BKXeNhan);

            #endregion

            TimeSpan GioDB = time_GopKenh_GioBatDau.Value.TimeOfDay;
            TimeSpan GioKT = time_GopKenh_GioKetThuc.Value.TimeOfDay;
            bool status = chkGopKenh_TrangThai.Checked;
            bool ft_ChieuVe_CoDuyet = chkFT_ChieuVe_CoDuyet.Checked;
            bool ft_ChieuVe_CoChotCo = chkFT_ChieuVe_CoChotCo.Checked;
            bool fT_Active = ckSuDungStaxi.Checked;
            bool fT_ChieuVe_Active = ckbSuDungStaxiChieuVe.Checked;
            int fT_ServiceMap = inputEnumLookUp_ServiceMap1.EditValue.To<int>();
            int fT_SoKM = txtGioiHanKm.EditValue.To<int>();

            if (ThongTinCauHinh.UpdateInsetThongTinCauHinh(TenCongTy, LogoPath, SoDauCuaTongDai,
                 SoGiayGioiHanThoiGianChuyenTongDai, SoGiayGioiHanThoiGianDieuXe, SoGiayGioiHanThoiGianDonKhach,
                 SoPhutGioiHanMatLienLac, SoPhutGioiHanMatLienLacBaoNghi, SoPhutGioiHanMatLienLacBaoDiSanBay,
                 SoPhutGioiHanMatLienLacBaoDiDuongDai, ThuMucDuLieuTanasonic, ThuMucFileAmThanh, TatCaLinesHeThong,
                 CacLineTaxi, PhoneTaxi, HasTongDai, SoDongCuocGoiDaGiaiQuyet, bKiemTraXeDaRaHoatDong, CacVungTongDai,
                 bTinhTienCuoc2ChieuNgatCuoc, KichHoachTaxiGroupDon, SoPhutGiuKhachChuaCoXeNhan, SoPhutGiuKhachCoXeNhan, SoPhutGiuKhachLai,
                 MaCungXn, BanDo, Zoom, KinhDo, ViDo, TenTinh, TrangThai, BKGioiHan, BKXeNhan, status, GioDB, GioKT, ft_ChieuVe_CoDuyet, ft_ChieuVe_CoChotCo, fT_Active, fT_ChieuVe_Active, fT_ServiceMap, fT_SoKM))
            {
                new MessageBox.MessageBoxBA().Show(this, "Lưu thông tin cấu hình thành công.");
                new MessageBox.MessageBoxBA().Show(this, "Cần phải khởi động lại chương trình các máy con để để thiết lập thông tin.");
                Application.Restart();

            }
            else new MessageBox.MessageBoxBA().Show(this, "Lỗi lưu thông tin cấu hình thành công");
        }

        /// <summary>
        /// kiem tra du lieu nhap các line.
        ///   1. các line phai lơn hơn 0 và nhỏ hơn bằng 32
        ///   2. Line của Taxi phải nằm trong line hệ thống.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private bool ValidateLinesHeThong(string LinesHeThong, string LinesTaxi)
        {
            bool bError = true;
            if (LinesHeThong.Length <= 0) return false;
            if (LinesTaxi.Length <= 0) return false;

            try
            {
                // phan ra cac line
                string[] arrLinesHeThong = LinesHeThong.Split(";".ToCharArray());
                string[] arrLinesTaxi = LinesTaxi.Split(";".ToCharArray());
                // kiem tra co >=32
                for (int i = 0; i < arrLinesHeThong.Length; i++)
                {
                    if (arrLinesHeThong[i].ToString().Length > 0)
                    {
                        int iLine = Convert.ToInt16(arrLinesHeThong[i].ToString());
                        if (iLine <= 0) return false;
                    }
                    else return false;
                }
                for (int i = 0; i < arrLinesTaxi.Length; i++)
                {
                    if (arrLinesTaxi[i].ToString().Length > 0)
                    {
                        int iLine = Convert.ToInt16(arrLinesTaxi[i].ToString());
                        if (iLine <= 0) return false;
                    }
                    else return false;
                }
                // kiem tra LineTaxi co nawmf traong line he thong khong
                for (int i = 0; i < arrLinesTaxi.Length; i++)
                {
                    bool bFind = false;
                    for (int j = 0; j < arrLinesHeThong.Length; j++)
                    {
                        if (arrLinesTaxi[i].ToString() == arrLinesHeThong[j].ToString())
                        {
                            bFind = true;
                        }
                    }
                    if (bFind == false) return false; // khong co trung
                }

                return bError;
            }
            catch
            {
                bError = false;
                return bError;
            } 
        } 

        #region Tab_CauHinh
        private void LoadThongTinCauHinh()
        {
            txtTenCongTy.Text = ThongTinCauHinh.TenCongTy;
            g_LogoCongTy = ThongTinCauHinh.LogoPath;
            imgLogo.ImageLocation = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\Reports\\" + ThongTinCauHinh.LogoPath;

            if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0)
            {
                chkCoSuDungTongDai.Checked = true;
                txtSoDauTongDai.Text = ThongTinCauHinh.SoDauCuaTongDai;
                lblSoDauTongDai.Enabled = true;
            }
            else
            {
                chkCoSuDungTongDai.Checked = false;
                txtSoDauTongDai.Text = "";
                lblSoDauTongDai.Enabled = false;
            }

            txtThoiGianChuyenTongDai.Text = ThongTinCauHinh.SoGiayGioiHanThoiGianChuyenTongDai.ToString();
            txtThoiGianDieuXe.Text = ThongTinCauHinh.SoGiayGioiHanThoiGianDieuXe.ToString();
            txtThoiGianDonKhach.Text = ThongTinCauHinh.SoGiayGioiHanThoiGianDonKhach.ToString();

            txtGioiHanMLL.Text = ThongTinCauHinh.SoPhutGioiHanMatLienLac.ToString();
            txtGioiHanMLLBaoNghi.Text = ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoNghi.ToString();
            txtGioiHanMLLDiDuongDai.Text = ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiDuongDai.ToString();
            txtGioiHanMLLDiSanBay.Text = ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiSanBay.ToString();

            txtThuMucDuLieuTanasonic.Text = ThongTinCauHinh.ThuMucDuLieuTanasonic;
            txtThuMucFileAmThanh.Text = ThongTinCauHinh.ThuMucFileAmThanh;

            txtLineHeThong.Text = ThongTinCauHinh.TatCaLineCuaHeThong;
            txtLineTaxi.Text = ThongTinCauHinh.CacLineCuaTaxiOperation;

            txtPhoneTaxi.Text = ThongTinCauHinh.SoDienThoaiCongTy;
            chkHasCOMPort.Checked = ThongTinCauHinh.HasTongDai;

            txtDongCuocGoiDaGiaiQuyet.Text = ThongTinCauHinh.SoDongCuocGoiDaGiaiQuyet.ToString();
            chkKiemTraXeDaRaHoatDong.Checked = ThongTinCauHinh.KiemTraXeDaRaHoatDong;

            txtCacVungTongDai.Text = ThongTinCauHinh.CacVungTongDai;

            chkTinhTienCuocHaiChieuKhongNgatCuoc.Checked = ThongTinCauHinh.TinhTienCuocHaiChieuKhongNgatCuoc;

            chkKichHoatTaxiGroupDon.Checked = ThongTinCauHinh.KichHoachTaxiGroupDon;
            txtSoPhutChuaCoXeNhan.Text = ThongTinCauHinh.SoPhutGiuKhachChuaCoXeNhan.ToString();
            txtSoPhutCoXeNhan.Text = ThongTinCauHinh.SoPhutGiuKhachCoXeNhan.ToString();
            txtSoPhutGiuKhachLai.Text = ThongTinCauHinh.SoPhutGiuKhachLai.ToString();

            loadGPSConfig();

            chkGopKenh_TrangThai.Checked = ThongTinCauHinh.GopKenh_TrangThai;
            time_GopKenh_GioBatDau.Value = DateTime.Today.AddTicks(ThongTinCauHinh.GopKenh_GioBD.Ticks);
            time_GopKenh_GioKetThuc.Value = DateTime.Today.AddTicks(ThongTinCauHinh.GopKenh_GioKT.Ticks);

            #region FT
            chkFT_ChieuVe_CoDuyet.Checked = ThongTinCauHinh.FT_ChieuVe_CoChotCo;
            chkFT_ChieuVe_CoChotCo.Checked = ThongTinCauHinh.FT_ChieuVe_CoDuyet;
            ckbSuDungStaxiChieuVe.Checked = ThongTinCauHinh.FT_ChieuVe_Active;
            ckSuDungStaxi.Checked = ThongTinCauHinh.FT_Active;
            txtGioiHanKm.EditValue = ThongTinCauHinh.FT_SoKM;
            inputEnumLookUp_ServiceMap1.EditValue = (int)ThongTinCauHinh.FT_ServiceMap;
            #endregion

        }
        #endregion

        #region Tab_IPSetting

        private void GetDSMayTinhDienThoai()
        {
            gridMayDienThoai.DataMember = "ListPCDienThoai";
            gridMayDienThoai.SetDataBinding(Taxi.Business.QuanTri.QuanTriCauHinh.GetDSMayDienThoai(), "ListPCDienThoai");
        }

        private void GetDSMayTinhTongDai()
        {
            gridMayTinhTongDai.DataMember = "ListPCTongDai";
            gridMayTinhTongDai.SetDataBinding(Taxi.Business.QuanTri.QuanTriCauHinh.GetDSMayTongDai(), "ListPCTongDai");
        }

        private void GetDSMayTinhMoiKhach()
        {
            gridMayMoiKhach.DataMember = "ListPCMoiKhach";
            gridMayMoiKhach.SetDataBinding(Taxi.Business.QuanTri.QuanTriCauHinh.GetDSMayMoiKhach(), "ListPCMoiKhach");  
        }

        private void GetDSMayGoiRa()
        {
            gridMayGoiRa.DataMember = "ListGoiRa";
            gridMayGoiRa.SetDataBinding(LineGoiRa.GetDSLineGoiRa(), "ListGoiRa");
        }        

        private void lnkThemMayDienThoai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmThemMayTinh("", "", true,Taxi.Business.KieuMayTinh.MAYDIENTHOAI  , true,0, "").ShowDialog();
            this.GetDSMayTinhDienThoai();
        }

        private void lnkThemMayTongDai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmThemMayTinh("", "", true, Taxi.Business.KieuMayTinh.MAYTONGDAI, true,0,"").ShowDialog();
            this.GetDSMayTinhTongDai();
        }

        private void lnkThemMayMoiKhach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmThemMayTinh("", "", true, Taxi.Business.KieuMayTinh.MAYMOIKHACH, true,0,"").ShowDialog();
            this.GetDSMayTinhMoiKhach();
        }
         
        private void lnkThemMayCamOnKhach_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmThemMayTinhGoiRa("", "", true, "0", true).ShowDialog();
            this.GetDSMayGoiRa();

            //new frmThemMayTinh("", "", true, Taxi.Business.KieuMayTinh.MAYKHACHMOI, true).ShowDialog();
            //this.GetDSMayTinhKhachMoi();
        }

        private void gridMayDienThoai_DoubleClick(object sender, EventArgs e)
        {
            gridMayDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridMayDienThoai.SelectedItems.Count > 0)
            {
                GridEXRow row = gridMayDienThoai.SelectedItems[0].GetRow();
                string IP = row.Cells["IP_Address"].Value.ToString();
                string Line_Vung = row.Cells["Line_Vung"].Value.ToString();
                string Line_Vung_Gop = row.Cells["LineGop"].Value.ToString();
                bool IsActive = row.Cells["IsHoatDong"].Value.ToString() == "1";
                bool IsG5_Type = row.Cells["G5_Type"].Value.ToString() == "1";
                string Extension = row.Cells["Extension"].Value.To<string>();
                new frmThemMayTinh(IP, Line_Vung, IsActive, KieuMayTinh.MAYDIENTHOAI, false, 0, Line_Vung_Gop, IsG5_Type, Extension).ShowDialog();
                this.GetDSMayTinhDienThoai();
            }
        }

        private void gridMayTinhTongDai_DoubleClick(object sender, EventArgs e)
        {
            gridMayTinhTongDai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridMayTinhTongDai.SelectedItems.Count > 0)
            {
                GridEXRow row = gridMayTinhTongDai.SelectedItems[0].GetRow();
                string IP = row.Cells["IP_Address"].Value.ToString();
                string Line_Vung = row.Cells["Line_Vung"].Value.ToString();
                string Line_Vung_Gop = row.Cells["LineGop"].Value.ToString();
                bool IsActive = row.Cells["IsHoatDong"].Value.ToString() == "1" ? true : false;
                string Extension = row.Cells["Extension"].Value.To<string>();
                new frmThemMayTinh(IP, Line_Vung, IsActive, Taxi.Business.KieuMayTinh.MAYTONGDAI, false, 0, Line_Vung_Gop,false, Extension).ShowDialog();
                this.GetDSMayTinhTongDai();
            }
        }
        private void gridMayTinhMoiKhach_DoubleClick(object sender, EventArgs e)
        {
            gridMayMoiKhach.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridMayMoiKhach.SelectedItems.Count > 0)
            {
                GridEXRow row = gridMayMoiKhach.SelectedItems[0].GetRow();
                string IP = row.Cells["IP_Address"].Value.ToString();
                string Line_Vung = row.Cells["Line_Vung"].Value.ToString();
                string Line_Vung_Gop = row.Cells["LineGop"].Value.ToString();
                bool IsActive = row.Cells["IsHoatDong"].Value.ToString() == "1" ? true : false;
                int No = Convert.ToInt16(row.Cells["MK"].Value);
                string Extension = row.Cells["Extension"].Value.To<string>();
                new frmThemMayTinh(IP, Line_Vung, IsActive, Taxi.Business.KieuMayTinh.MAYMOIKHACH, false, No, Line_Vung_Gop,false, Extension).ShowDialog();
                this.GetDSMayTinhMoiKhach();
            }
        }

        private void gridMayTinhCamOnKhach_DoubleClick(object sender, EventArgs e)
        {
            //gridMayGoiRa.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            //if (gridMayGoiRa.SelectedItems.Count > 0)
            //{
            //    GridEXRow row = gridMayGoiRa.SelectedItems[0].GetRow();
            //    string IP = row.Cells["IP_Address"].Value.ToString();
            //    string Line_Vung = row.Cells["Line_Vung"].Value.ToString();
            //    bool IsActive = row.Cells["IsHoatDong"].Value.ToString() == "1" ? true : false;

            //    new frmThemMayTinh(IP, Line_Vung, IsActive, Taxi.Business.KieuMayTinh.MAYKHACHMOI, false).ShowDialog();
            //    this.GetDSMayTinhKhachMoi();
            //}
        }

        private void lnkXoaMayDienThoai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridMayDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridMayDienThoai.SelectedItems.Count > 0)
            {
                GridEXRow row = gridMayDienThoai.SelectedItems[0].GetRow();
                string IP = row.Cells["IP_Address"].Value.ToString();

                MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
                string Result = msgBox.Show(this, "Bạn có đồng ý xóa máy tính này?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question);

                if (Result == DialogResult.Yes.ToString())
                {
                    if (QuanTriCauHinh.Delete(IP))
                    {
                        this.GetDSMayTinhDienThoai();
                        new MessageBox.MessageBoxBA().Show("Xóa thông tin máy tính thành công");
                    }
                    else new MessageBox.MessageBoxBA().Show("Lỗi xóa thông tin máy tính thành công");
                }

            }
        }

        private void lnkXoaMayTongDai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridMayTinhTongDai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridMayTinhTongDai.SelectedItems.Count > 0)
            {
                GridEXRow row = gridMayTinhTongDai.SelectedItems[0].GetRow();
                string IP = row.Cells["IP_Address"].Value.ToString();

                MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
                string Result = msgBox.Show(this, "Bạn có đồng ý xóa máy tính này?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question);

                if (Result == DialogResult.Yes.ToString())
                {
                    if (QuanTriCauHinh.Delete(IP))
                    {
                        this.GetDSMayTinhTongDai();
                        new MessageBox.MessageBoxBA().Show("Xóa thông tin máy tính thành công");
                    }
                    else new MessageBox.MessageBoxBA().Show("Lỗi xóa thông tin máy tính thành công");
                }

            }
        }

        private void lnkXoaMayMoiKhach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridMayMoiKhach.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridMayMoiKhach.SelectedItems.Count > 0)
            {
                GridEXRow row = gridMayMoiKhach.SelectedItems[0].GetRow();
                string IP = row.Cells["IP_Address"].Value.ToString();

                MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
                string Result = msgBox.Show(this, "Bạn có đồng ý xóa máy tính này?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question);

                if (Result == DialogResult.Yes.ToString())
                {
                    if (QuanTriCauHinh.Delete(IP))
                    {
                        this.GetDSMayTinhMoiKhach();
                        new MessageBox.MessageBoxBA().Show("Xóa thông tin máy tính thành công");
                    }
                    else new MessageBox.MessageBoxBA().Show("Lỗi xóa thông tin máy tính thành công");
                }

            }
        }
        private void lnkXoaMayCamOnKhach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             gridMayGoiRa.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
             if (gridMayGoiRa.SelectedItems.Count > 0)
             {
                 GridEXRow row = gridMayGoiRa.SelectedItems[0].GetRow();
                 int ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());


                 MessageBox.MessageBoxBA msgBox = new MessageBox.MessageBoxBA();
                 string Result = msgBox.Show(this, "Bạn có đồng ý xóa line này?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question);

                 if (Result == DialogResult.Yes.ToString())
                 {
                     if (LineGoiRa.Delete(ID))
                     {
                         this.GetDSMayGoiRa();
                         new MessageBox.MessageBoxBA().Show("Xóa thông tin line thành công");
                     }
                     else new MessageBox.MessageBoxBA().Show("Lỗi xóa thông tin line thành công");
                 }
             }
        }


        #endregion Tab_IPSetting

        #region Tab_CauHinhStaxi

        private void llCapNhatCauHinhChieuVe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var coDuyet = chkFT_ChieuVe_CoDuyet.Checked;
            var coChot = chkFT_ChieuVe_CoChotCo.Checked;
            var km =txtGioiHanKm.EditValue.To<int>();
            var sermap = inputEnumLookUp_ServiceMap1.EditValue.To<int>();
            if (ThongTinCauHinh.Update_CauHinhStaxiChieuVe(coDuyet, coChot, sermap, km))
            {
                ThongTinCauHinh.FT_SoKM = km;
                ThongTinCauHinh.FT_ChieuVe_CoChotCo = coChot;
                ThongTinCauHinh.FT_ChieuVe_CoDuyet = coDuyet;
                ThongTinCauHinh.FT_ServiceMap = (Taxi.Utils.Enums.Enum_FT_ServiceMap)Enum.Parse(typeof(Taxi.Utils.Enums.Enum_FT_ServiceMap), sermap.ToString());
            }
        }
        private void llCapNhatCauHinhStaxi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ThongTinCauHinh.Update_CauHinhStaxi(ckSuDungStaxi.Checked, ckbSuDungStaxiChieuVe.Checked))
            {
                ThongTinCauHinh.FT_Active = ckSuDungStaxi.Checked;
                ThongTinCauHinh.FT_ChieuVe_Active = ckbSuDungStaxiChieuVe.Checked;
            }
        }
        #endregion
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkThietLapMacDinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            txtThoiGianChuyenTongDai.Text = "60";
            txtThoiGianDieuXe.Text = "120";
            txtThoiGianDonKhach.Text = "300";

            txtGioiHanMLL.Text = "120";
            txtGioiHanMLLBaoNghi.Text = "180";
            txtGioiHanMLLDiDuongDai.Text = "180";
            txtGioiHanMLLDiSanBay.Text = "240";

            txtLineHeThong.Text = "1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16";
            txtLineTaxi.Text = "1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16";
            txtDongCuocGoiDaGiaiQuyet.Text = "50";

            txtCacVungTongDai.Text = "1";
            chkTinhTienCuocHaiChieuKhongNgatCuoc.Checked = true;

            chkKichHoatTaxiGroupDon.Checked = false;
            txtSoPhutChuaCoXeNhan.Text = "5";
            txtSoPhutCoXeNhan.Text = "10";
            txtSoPhutGiuKhachLai.Text = "15";
        }

        private void chkCoSuDungTongDai_CheckedChanged(object sender, EventArgs e)
        {
            txtSoDauTongDai.Enabled = chkCoSuDungTongDai.Checked;
            lblSoDauTongDai.Enabled = chkCoSuDungTongDai.Checked;
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            // g_LogoCongTy = "";
            // Browse anh moi
            g_bCoThayLogo = false;
            openFileDialog1.Filter = "JPG Images|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                if (FileTools.IsExsitFile(filePath))
                {
                    g_LogoCongTy = filePath;
                    imgLogo.ImageLocation = g_LogoCongTy;
                    g_bCoThayLogo = true;

                }
            }
            // Load anh

        }
        /// <summary>
        /// lay duong dan thu muc luu Tanasonic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogInComingBrowse_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtThuMucDuLieuTanasonic.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnThuMucDuongDanAmThanh_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtThuMucFileAmThanh.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void lnkCapNhat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime DauCa1 = new DateTime (1900,1,1,calDauCa1.Value.Hour,calDauCa1.Value.Minute,0);
            DateTime KetThucCa1 = new DateTime (1900,1,1,calKetThucCa1.Value.Hour,calKetThucCa1.Value.Minute,0);
            DateTime KetThucCa2 = new DateTime (1900,1,1,calKetThucCa2.Value.Hour , calKetThucCa2.Value.Minute,0);

            if (ThongTinCauHinh.CapNhatThongTinCa(1, DauCa1, KetThucCa1, KetThucCa2))
            {
                new MessageBox.MessageBoxBA().Show(this, "Cập nhật thông tin ca thành công.");
            }
            else
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi cập nhật thông tin ca.");
            }
        } 

        #region Tab Cau hinh Thoat 999

        private void HienThiDSCauHinhThoatCuoc()
        {
            DataTable dt = ThoatCuoc999.GetAllDSCauHinh();
        }

        private void lnkThemMoiThoat999_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmThemThoatCuoc999 frm = new frmThemThoatCuoc999(0, 0, 0, true);
            frm.ShowDialog();
            HienThiDSCauHinhThoatCuoc();

        }

        /// <summary>
        /// hàm trả về trạng thái cho phép nút bật có được Enable
        /// </summary>
        /// <param name="soCuocGioiHan"></param>
        /// <param name="soCuocHienTai"></param>
        /// <param name="ThoiDiemBat"></param>
        /// <param name="ThoiDiemTat"></param>
        /// <returns></returns>
        private Janus.Windows.UI.InheritableBoolean GetEnableMenuBATThoatCuoc999(int soCuocGioiHan, int soCuocHienTai, DateTime ThoiDiemBat, DateTime ThoiDiemTat)
        {
            if (soCuocGioiHan <= 0) return Janus.Windows.UI.InheritableBoolean.False;   // Enable = false
            if (ThoiDiemTat != DateTime.MinValue)        // da tat
            {
                if (soCuocHienTai > soCuocGioiHan)
                    return Janus.Windows.UI.InheritableBoolean.True;                    // Enable = true
                else
                    return Janus.Windows.UI.InheritableBoolean.False;                   // Enable  = false;
            }
            else                                        // da bat
            {
                if (ThoiDiemBat == DateTime.MinValue)    // chua tung bat
                {
                     if (soCuocHienTai > soCuocGioiHan)
                        return Janus.Windows.UI.InheritableBoolean.True;                    // Enable = true
                    else
                        return Janus.Windows.UI.InheritableBoolean.False;                   // Enable  = false;
                }
                else                                    // Tung bat gan day
                 
                {                    
                        return Janus.Windows.UI.InheritableBoolean.False;                   // Enable  = false;
                }                    
            }             
        }

        private Janus.Windows.UI.InheritableBoolean GetEnableMenuTATThoatCuoc999(int soCuocGioiHan, int soCuocHienTai, DateTime ThoiDiemBat, DateTime ThoiDiemTat)
        { 
            if (ThoiDiemTat != DateTime.MinValue)        // da tat
            {                
                return Janus.Windows.UI.InheritableBoolean.False;                   // Enable  = false;
            }
            else                                        // da bat
            {
                if (ThoiDiemBat != DateTime.MinValue)     // da bat
                {
                    return Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                    return Janus.Windows.UI.InheritableBoolean.False; // khong can bat
            }
        }
        
        private void gridCauHinhBatThoatCuoc_FormattingRow(object sender, RowLoadEventArgs e)
        {
            GridEXRow row = e.Row;
            if (row.Cells["ThoiDiemKetThuc999"].Value != null && row.Cells["ThoiDiemKetThuc999"].Value.ToString().Length <= 0 
                && row.Cells["ThoiDiemBatDau999"].Value != null && row.Cells["ThoiDiemBatDau999"].Value.ToString().Length > 0  ) // chua co gio ket thuc
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Lime ;
                row.Cells["Vung"].FormatStyle = RowStyle;
            }
        }
        #endregion Tab Cau hinh Thoat 999

        ///0 : Điện thoại
        //1 : Tổng đài
        //2 : Mời khách
        //3 : Tin Giá
        //4 : Khách hàng
        //5 : Trưởng ca
        //9 : Khác
        private void gridMayGoiRa_FormattingRow(object sender, RowLoadEventArgs e)
        {
            //if (e.Row.Cells["IsMayTinh"].Value.ToString() == "0")
            //{
            //    e.Row.Cells["LoaiMay"].Text = "Điện thoại";
            //}
            //else if (e.Row.Cells["IsMayTinh"].Value.ToString()== "1")
            //{
            //    e.Row.Cells["LoaiMay"].Text = "Tổng đài";
            //}
            //else if (e.Row.Cells["IsMayTinh"].Value.ToString() =="2")
            //{
            //    e.Row.Cells["LoaiMay"].Text = "Mời khách";
            //}
            //else if (e.Row.Cells["IsMayTinh"].Value.ToString() == "3")
            //{
            //    e.Row.Cells["LoaiMay"].Text = "Tin giá";
            //}
            //else if (e.Row.Cells["IsMayTinh"].Value.ToString() == "4")
            //{
            //    e.Row.Cells["LoaiMay"].Text = "Khách hàng";
            //}
            //else if (e.Row.Cells["IsMayTinh"].Value.ToString() == "5")
            //{
            //    e.Row.Cells["LoaiMay"].Text = "Trưởng ca";
            //}
            //else if (e.Row.Cells["IsMayTinh"].Value.ToString() == "9")
            //{
            //    e.Row.Cells["LoaiMay"].Text = "Khác";
            //}
        }

        #region Tab Cau Hinh GPS
        // Toyota MyDinh Building
        private PointLatLng currentPoint = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
        private GMapProvider _mapType;
        private Taxi.Utils.MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;
        #region Internal variables

        // markers
        GMapMarkerCustom centerMarker;
        GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        // layers
        GMapOverlay top;

        bool isMouseDown;
        #endregion

        #region Public properties
        /// <summary>
        /// Get set the main marker
        /// </summary>
        //public GMapMarker MainMarker
        //{
        //    get
        //    {
        //        return currentMarker;
        //    }
        //    set
        //    {
        //        currentMarker = value;
        //    }
        //}

        //public List<GMapMarker> OtherMarkers
        //{
        //    get
        //    {
        //        List<GMapMarker> rv = top.Markers.ToList();
        //        rv.Remove(currentMarker);
        //        return rv;
        //    }
        //    set
        //    {
        //        _otherMarkers = value;
        //    }
        //}

        //public GMapProvider MapType
        //{
        //    get { return _mapType; }
        //    set { _mapType = value; }
        //}

        //public int MapZoom
        //{
        //    get { return _mapZoom; }
        //    set { _mapZoom = value; }
        //}

        //public Taxi.Utils.MapModeEnum MapMode
        //{
        //    get { return _mapMode; }
        //    set { _mapMode = value; }
        //}

        #endregion

        private void ConfigMap()
        {
            // config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 15;

            MainMap.PolygonsEnabled = false;
            MainMap.AllowDrawPolygon = false;

            // map events
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

            if (_mapMode == Taxi.Utils.MapModeEnum.EditPoint)
            {
                MainMap.MouseMove += MainMap_MouseMove;
                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseUp += MainMap_MouseUp;
            }
            else
            {
                MainMap.MouseMove -= MainMap_MouseMove;
                MainMap.MouseDown -= MainMap_MouseDown;
                MainMap.MouseUp -= MainMap_MouseUp;
            }
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;
            
            // get zoom  
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

            // add custom layers  
            {
                top = new GMapOverlay("top");
                MainMap.Overlays.Add(top);
            }

            CbMapType.ValueMember = "Name";
            CbMapType.DataSource = GMapProviders.List;
            CbMapType.SelectedItem = GMapProviders.GoogleMap;

            // kiểm tra và thiết lặp vị trí mặc định của bản đồ
            if (ThongTinCauHinh.GPS_KinhDo > 0 && ThongTinCauHinh.GPS_ViDo > 0)
                MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            CustomInitMap();
        }

        private void CustomInitMap()
        {
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            //initConfigGPS();

        }

        private void initConfigGPS()
        {
            if (currentMarker != null && currentMarker.Position.Lat > 0)
            {
                lblGPS_KinhDo.Text = currentMarker.Position.Lng.ToString();
                lblGPS_ViDo.Text = currentMarker.Position.Lat.ToString();
            }
            
            lblGPS_mucZoom.Text = MainMap.Zoom.ToString();
            lblGPS_LoaiBanDo.Text = MainMap.MapProvider.Name;
        }
        
        #region===================Map Events==================================
        
        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            initConfigGPS();
        }

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
            initConfigGPS();
        }       

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainMap.Zoom < MainMap.MaxZoom)
            {
                int zoom = (int)(MainMap.Zoom + 1);
                if (zoom > MainMap.MaxZoom)
                {
                    zoom = MainMap.MaxZoom;
                }
                trackBarMap.Value = zoom;
                MainMap.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = false;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = true;
                if (currentMarker.IsVisible)
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                initConfigGPS();
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }

            }
            MainMap.Refresh(); // force instant invalidation
        }

        #endregion=============================================================        

        private void CbMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MainMap.MapProvider = CbMapType.SelectedItem as GMapProvider;
        }

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }

        private bool validConfigGPS()
        {
            if (!ckGPS_KetNoi.Checked)
		        return true;
            if (txtGPS_BanKinhTimXe.Value <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập bán kính tìm xe","Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return false;
            }
            if (txtGPS_MaCungXN.Text == "")
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập mã xí nghiệp", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return false;
            }
            return true;
        }

        private void loadGPSConfig()
        {
            ckGPS_KetNoi.Checked = ThongTinCauHinh.GPS_TrangThai;
            lblGPS_KinhDo.Text = ThongTinCauHinh.GPS_KinhDo.ToString();
            lblGPS_ViDo.Text = ThongTinCauHinh.GPS_ViDo.ToString();
            lblGPS_LoaiBanDo.Text = ThongTinCauHinh.GPS_LoaiBanDo;
            txtGPS_MaCungXN.Text = ThongTinCauHinh.GPS_MaCungXN;
            txtGPS_BanKinhTimXe.Value = ThongTinCauHinh.GPS_BKGioiHan;
            txtBKXeNhan.Value = ThongTinCauHinh.GPS_BKXeNhan;
            lblGPS_mucZoom.Text = ThongTinCauHinh.GPS_MucZoom.ToString();
            txtGPS_TenTinh.Text = ThongTinCauHinh.GPS_TenTinh;
            float gps_vd = ThongTinCauHinh.GPS_ViDo;
            float gps_kd = ThongTinCauHinh.GPS_KinhDo;
            if (gps_vd > 0 && gps_vd > 0)
                currentMarker = MainMap.AddMarkerRed(new PointLatLng((double)(gps_vd), (double)(gps_kd)));
            else
                currentMarker = MainMap.AddMarkerRed(currentPoint);

            //chkFT_ChieuVe_CoChotCo.Checked = ThongTinCauHinh.FT_ChieuVe_CoChotCo;
            //chkFT_ChieuVe_CoDuyet.Checked = ThongTinCauHinh.FT_ChieuVe_CoDuyet;
        }
        #endregion

        private void lnkGopKenh_CapNhat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                TimeSpan GioDB = time_GopKenh_GioBatDau.Value.TimeOfDay;
                TimeSpan GioKT = time_GopKenh_GioKetThuc.Value.TimeOfDay;
                bool status = chkGopKenh_TrangThai.Checked;
                if (Config_Common.Update(Enum_Config_Common.GopLine, chkGopKenh_TrangThai_Config.Checked ? "1" : ""))
                {
                    Config_Common.GopLine = chkGopKenh_TrangThai_Config.Checked;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Có lỗi cập nhật cấu hình gộp kênh.");
                    return;
                }
                if (ThongTinCauHinh.Update_GopKenh(status, GioKT, GioDB))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Cập nhật cấu hình gộp kênh thành công.");
                    ThongTinCauHinh.GopKenh_GioBD = GioDB;
                    ThongTinCauHinh.GopKenh_GioKT = GioKT;
                    ThongTinCauHinh.GopKenh_TrangThai = status;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Có lỗi cập nhật cấu hình gộp kênh.");
                }
            }
            catch (Exception)
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi cấu hình gộp kênh.");
            }
        }

        private void ckbSuDungStaxiChieuVe_CheckedChanged(object sender, EventArgs e)
        {
          
                groupStaxiChieuVe.Enabled = ckbSuDungStaxiChieuVe.Checked;
            
        }
    }
}