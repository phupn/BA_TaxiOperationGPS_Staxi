using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business.KhachDat;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.FastTaxi;
using System.IO;
using System.Diagnostics;

namespace Taxi.Controls.DanhMuc
{
    public partial class frmListKhachDat : FormRibbon
    {
        #region ====================Properties========================

        public DateTime ThoiDiemTiepNhanTu { get; set; }

        private DateTime ThoiDiemTiepNhanDen { get; set; }

        public string TenKhachHang { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public int VungKenh { get; set; }

        public int IsLapLai { get; set; }

        public DateTime GioDonTu { get; set; }

        public DateTime GioDonDen { get; set; }

        public DateTime ThoiDiemBatDau { get; set; }

        public DateTime ThoiDiemKetThuc { get; set; }

        public int SoPhutBaoTruoc { get; set; }

        public string LoaiXe { get; set; }

        public int SoLuongXe { get; set; }

        #endregion

        #region ===========================Initialize==================================

        private bool g_IsDelete = false;
        private bool g_LoaiXeChange = false;
        private bool g_IsSearched = false;
        private bool g_IsInserting = false;
        /// <summary>
        /// g_FormStatus = 0 : Tìm kiếm.
        /// g_FormStatus = 1 : Thêm mới.
        /// g_FormStatus = 2 : Cập nhật.
        /// </summary>
        private int g_FormStatus = 0;
        /// <summary>
        /// g_IsNow : Trạng thái dữ liệu của gridview (NgayTiepNhan = now)
        /// </summary>
        private bool g_IsNow = true;
        /// <summary>
        /// True: Đang ở trong hàm FormLoad. False: Không ở trong hàm đó.
        /// </summary>
        private bool g_IsFirstLoad = false;
        private long g_IDCuocGoi = 0;
        private int g_IDKhachDat = 0;

        private DateTime g_DateTimeServer;
        private KhachDatEntity g_KhachDat = new KhachDatEntity();
        List<KhachDatBL> G_ListKhachDat;

        public frmListKhachDat()
        {
            InitializeComponent();
            RefreshForm(1);
        }

        #endregion

        #region ===========================Load Form===================================
        private void frmListKhachDat_Load(object sender, EventArgs e)
        {
            g_IsFirstLoad = true;
            FillDefaultDataToForm(1);
            txtTenKH.Focus();
            chk4Cho.Checked = true;
            RefreshForm(1);            
            g_IsFirstLoad = false;
            SetAllCheckBox();
            panButton.Left = grbThongTinKhachHang.Left;
        }

        private void FillDefaultDataToForm(int formStatus)
        {
            g_DateTimeServer = DieuHanhTaxi.GetTimeServer();
            g_FormStatus = formStatus;
            g_IDKhachDat = 0;
            if (formStatus == 1)
            {              
                calThoiDiemTiepNhan.EditValue = g_DateTimeServer;
                calThoiDiemTiepNhan.Visible = true;
                cbSoPhut.Value = 15;
                calGioDon.EditValue = new DateTime(1900, 1, 1, g_DateTimeServer.Hour, g_DateTimeServer.Minute, 0);
                calNgayBatDau.EditValue = g_DateTimeServer;
                calNgayKetThuc.EditValue = g_DateTimeServer;
                GetKhachDat_NgayTiepNhan();
                chk4Cho.Checked = false;
                chk7Cho.Checked = false;
                txtSoLuong.Text = "1";
                txtKenh.Value = 0;
                txtGhiChu.Text = "";
                txtLoaiXe.Text = "";                
            }
            else if (formStatus == 0)
            {
                txtKenh.Text = null;
                cbSoPhut.Text = "";
                calGioDonTu.EditValue = new DateTime(1900, 1, 1, 0, 0, 0);
                calGioDonDen.EditValue = new DateTime(1900, 1, 1, 23, 59, 0);
                calTGTiepNhanTu.EditValue = new DateTime(g_DateTimeServer.Year, g_DateTimeServer.Month, g_DateTimeServer.Day, 0, 0, 0);
                calTGTiepNhanDen.EditValue = new DateTime(g_DateTimeServer.Year, g_DateTimeServer.Month, g_DateTimeServer.Day, 23, 59, 59);
            }
        }

        /// <summary>
        /// Get thông tin Khách đặt theo ngày Tiếp nhận (7 ngày gần nhất!)
        /// </summary>
        private void GetKhachDat_NgayTiepNhan()
        {
            if (!g_IsDelete&&!g_IsInserting)
            {
                G_ListKhachDat = new KhachDatBL().GetKhachDat_TGTiepNhan(DateTime.Now.Date);
                gridControlDSDatHen.DataSource = G_ListKhachDat;
            }
        }
        #endregion

        #region ===========================Validate====================================
        private bool IsValid()
        {
            lblMsg.Text = "";
            lblMsg.ForeColor = Color.Red;
            if (g_FormStatus == 0)//Check khi đang ở form tìm kiếm
            {
                if (calTGTiepNhanTu.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Thời điểm nhận";
                    calTGTiepNhanTu.Focus();
                    return false;
                }
                if (calTGTiepNhanDen.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Thời điểm nhận";
                    calTGTiepNhanDen.Focus();
                    return false;
                }
                if (calGioDonTu.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Giờ đón";
                    calGioDonTu.Focus();
                    return false;
                }
                if (calGioDonDen.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Giờ đón";
                    calGioDonDen.Focus();
                    return false;
                }
            }
            else //Check khi thực thi thêm sửa xóa!
            {
                if (txtTenKH.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Tên khách hàng";
                    txtTenKH.Focus();
                    return false;
                }
                if (txtDiaChi.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Địa chỉ";
                    txtDiaChi.Focus();
                    return false;
                }
                if (txtDienThoai.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Số điện thoại";
                    txtDienThoai.Focus();
                    return false;
                }
                if (calThoiDiemTiepNhan.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Thời điểm nhận";
                    calThoiDiemTiepNhan.Focus();
                    return false;
                }
                if (calGioDon.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Giờ đón";
                    calGioDon.Focus();
                    return false;
                }
                if (calNgayBatDau.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Ngày bắt đầu";
                    calNgayBatDau.Focus();
                    return false;
                }
                if (calNgayKetThuc.Text.Trim() == String.Empty)
                {
                    lblMsg.Text = "Vui lòng nhập Ngày kết thúc";
                    calNgayKetThuc.Focus();
                    return false;
                }
                if (cbSoPhut.Value <= 0)
                {
                    lblMsg.Text = "Vui lòng nhập Số phút báo trước";
                    cbSoPhut.Focus();
                    return false;
                }

                if (rbLapLai.Checked == true)
                {
                    if (GetNgayTrongTuan() == "")
                    {
                        lblMsg.Text = "Vui lòng nhập các Ngày trong tuần(lặp lại)";
                        chkThu2.Focus();
                        return false;
                    }
                }

                if (txtSoLuong.Text.Trim() == String.Empty || Convert.ToInt16(txtSoLuong.Text) <= 0)
                {
                    lblMsg.Text = "Vui lòng nhập Số lượng xe";
                    txtSoLuong.Focus();
                    return false;
                }

                if (calNgayBatDau.DateTime > calNgayKetThuc.DateTime)
                {
                    lblMsg.Text = "Ngày kết thúc không được nhỏ hơn ngày bắt đầu!";
                    calNgayBatDau.Focus();
                    return false;
                }

                //if (calThoiDiemTiepNhan.DateTime.Date < CommonBL.GetTimeServer().Date && !rbLapLai.Checked)
                //{
                //    lblMsg.Text = "Thời điểm tiếp nhận không được nhập nhỏ hơn ngày hiện tại!";
                //    calThoiDiemTiepNhan.Focus();
                //    return false;
                //}

                //if (calNgayBatDau.DateTime.Date < CommonBL.GetTimeServer().Date && !rbLapLai.Checked)
                //{
                //    lblMsg.Text = "Ngày bắt đầu không được nhỏ hơn thời ngày hiện tại";
                //    calNgayBatDau.Focus();
                //    return false;
                //}

                int kenh = 0;
                int.TryParse(txtKenh.Text, out kenh);
                if (kenh <= 0)
                {
                    lblMsg.Text ="Bạn vui lòng nhập số kênh!";
                    txtKenh.Focus();
                    return false;
                }

                int sophut = 0;
                int.TryParse(cbSoPhut.Text, out sophut);
                if (sophut <= 0)
                {
                    lblMsg.Text = "Bạn vui lòng nhập số phút!";
                    cbSoPhut.Focus();
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region ======================Form Status======================================

        /// <summary>
        /// Get data on the form (Adding / Updating)
        /// </summary>
        private void GetDataInput()
        {
            g_KhachDat.StatusRow = 0;
            g_KhachDat.PK_KhachDatID = g_IDKhachDat;
            g_KhachDat.FK_CuocGoiID = g_IDCuocGoi;
            g_KhachDat.TenKhachHang = txtTenKH.Text.Trim();
            g_KhachDat.DiaChiDon = txtDiaChi.Text.Trim();
            g_KhachDat.ThoiDiemTiepNhan = calThoiDiemTiepNhan.DateTime;
            g_KhachDat.SoDienThoai = txtDienThoai.Text.Trim();
            g_KhachDat.VungKenh = Convert.ToInt16(txtKenh.Value);            
            g_KhachDat.TenLoaiXe = GetThongTinLoaiXeChon2() +" - "+ txtLoaiXe.Text;
            g_KhachDat.LoaiXe =ipLoaiXe.EditValue.ToString();
            g_KhachDat.SoLuongXe = Convert.ToInt16(txtSoLuong.Text);
            if (rbLapLai.Checked)
            {
                g_KhachDat.IsLapLai = true;
                g_KhachDat.ThoiDiemKetThuc = calNgayKetThuc.DateTime.Date.AddDays(1).AddSeconds(-1); 
                g_KhachDat.NgayTrongTuanLapLai = GetNgayTrongTuan();
            }
            else
            {
                g_KhachDat.IsLapLai = false;
                g_KhachDat.ThoiDiemKetThuc = calNgayKetThuc.DateTime.Date.AddDays(1).AddSeconds(-1);//*sign
                g_KhachDat.NgayTrongTuanLapLai = "";
            }
            g_KhachDat.GioDon = new DateTime(calNgayBatDau.DateTime.Date.Year, calNgayBatDau.DateTime.Date.Month, calNgayBatDau.DateTime.Date.Day, calGioDon.DateTime.Hour, calGioDon.DateTime.Minute, 0);
            g_KhachDat.ThoiDiemBatDau = calNgayBatDau.DateTime.Date;
            g_KhachDat.SoPhutBaoTruoc = Convert.ToInt16(cbSoPhut.Value);
            g_KhachDat.CreatedBy = ThongTinDangNhap.USER_ID;
            g_KhachDat.UpdatedBy = ThongTinDangNhap.USER_ID;
            g_KhachDat.GhiChu = txtGhiChu.Text.Trim();
            double soTien;
            double.TryParse(txtSoTien.Text.Trim(), out soTien);
            g_KhachDat.SoTien = soTien;
            g_KhachDat.UpdatedDate = CommonBL.GetTimeServer();
            g_KhachDat.CreatedDate = CommonBL.GetTimeServer();
        }

        private void SetDataToForm(KhachDatBL kd)
        {
            if (kd == null) return;
            RefreshForm(2);
            g_IDKhachDat = kd.PK_KhachDatID;
            txtTenKH.Text = kd.TenKhachHang;
            txtDiaChi.Text = kd.DiaChi;
            txtDienThoai.Text = kd.SoDienThoai;
            calThoiDiemTiepNhan.SetValue(kd.ThoiDiemTiepNhan);
            txtKenh.Value = kd.VungKenh;
            txtSoLuong.Text = kd.SoLuongXe.ToString();
            //txtLoaiXe.Text = kd.TenLoaiXe;
            SetThongTinLoaiXe2(kd.LoaiXe);
            ipLoaiXe.EditValue = kd.LoaiXe;
            txtGhiChu.Text = kd.GhiChu;
            calGioDon.SetValue(kd.GioDon);
            calNgayBatDau.SetValue(kd.ThoiDiemBatDau);
            calNgayKetThuc.SetValue(kd.ThoiDiemKetThuc);
            cbSoPhut.Value = kd.SoPhutBaoTruoc;
            txtSoTien.Text = kd.SoTien.ToString();
            
            if (kd.IsLapLai)
            {
                rbLapLai.Checked = true;
            }
            else
            {
                rbMotLan.Checked = true;
            }
            SetNgayTrongTuan(kd.NgayTrongTuanLapLai);
        }
        /// <summary>
        /// Get Ngày trong tuần lặp lại
        /// </summary>
        /// <returns>1;2;3;4;5;6;7;</returns>
        private string GetNgayTrongTuan()
        {
            string strNgayTrongTuanLapLai = "";

            if (chkThu2.Checked)
                strNgayTrongTuanLapLai = "2;";
            if (chkThu3.Checked)
                strNgayTrongTuanLapLai += "3;";
            if (chkThu4.Checked)
                strNgayTrongTuanLapLai += "4;";
            if (chkThu5.Checked)
                strNgayTrongTuanLapLai += "5;";
            if (chkThu6.Checked)
                strNgayTrongTuanLapLai += "6;";
            if (chkThu7.Checked)
                strNgayTrongTuanLapLai += "7;";
            if (chkCN.Checked)
                strNgayTrongTuanLapLai += "1;";

            if (strNgayTrongTuanLapLai == "")
                return "";

            return strNgayTrongTuanLapLai.Substring(0, strNgayTrongTuanLapLai.Length - 1);
        }

        /// <summary>
        /// set Ngày trong tuần lặp lại
        /// </summary>
        private void SetNgayTrongTuan(string strNgayTrongTuanLapLai)
        {
            ResetCheckBox();
            string[] arrValue = strNgayTrongTuanLapLai.Split(';');
            for (int i = 0; i < arrValue.Length; i++)
            {
                if (arrValue[i] == "2")
                {
                    chkThu2.Checked = true;
                    continue;
                }
                if (arrValue[i] == "3")
                {
                    chkThu3.Checked = true;
                    continue;
                }
                if (arrValue[i] == "4")
                {
                    chkThu4.Checked = true;
                    continue;
                }
                if (arrValue[i] == "5")
                {
                    chkThu5.Checked = true;
                    continue;
                }
                if (arrValue[i] == "6")
                {
                    chkThu6.Checked = true;
                    continue;
                }
                if (arrValue[i] == "7")
                {
                    chkThu7.Checked = true;
                    continue;
                }
                if (arrValue[i] == "1")
                {
                    chkCN.Checked = true;
                }
            }
        }

        private void ResetCheckBox()
        {
            chkThu2.Checked = false;
            chkThu3.Checked = false;
            chkThu4.Checked = false;
            chkThu5.Checked = false;
            chkThu6.Checked = false;
            chkThu7.Checked = false;
            chkCN.Checked = false;
        }

        /// <summary>
        /// Set lại trạng thái của form
        /// </summary>
        private void RefreshForm(int formStatus)
        {
            txtTenKH.Text = "";
            txtKenh.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            txtSoLuong.Text = "1";
            txtSoTien.Text = "";
            rbMotLan.Checked = true;
            g_FormStatus = formStatus;
            cbkSanBay.Checked = false;
            switch (formStatus)
            {
                case 0://Tìm kiếm
                    lblMsg.Text = "";
                    g_IsNow = false;
                    g_IsSearched = true;
                    ControlForSearch(true);
                    pnlTGTiepNhanSearch.Visible = true;
                    calThoiDiemTiepNhan.Visible = false;
                    FillDefaultDataToForm(0);
                    btnUpdate.ImageIndex = 0;
                    btnUpdate.Text = "Tìm (Ctrl+S)";
                    break;
                case 1://Làm mới
                    ControlForSearch(false);
                    btnUpdate.Text = "Lưu (Ctrl+S)";
                    pnlTGTiepNhanSearch.Visible = false;
                    calThoiDiemTiepNhan.Visible = true;
                    break;
                case 2://Cập Nhât
                    pnlGioDonSearch.Visible = false;
                    pnlTGTiepNhanSearch.Visible = false;
                    rbMotLan.Visible = true;
                    rbLapLai.Visible = true;
                    calGioDon.Visible = true;
                    calThoiDiemTiepNhan.Visible = true;
                    txtDiaChi.BackColor = SystemColors.Window;
                    txtDienThoai.BackColor = SystemColors.Window;
                    txtTenKH.BackColor = SystemColors.Window;
                    txtKenh.BackColor = SystemColors.Window;
                    calNgayBatDau.BackColor = SystemColors.Window;
                    calNgayKetThuc.BackColor = SystemColors.Window;
                    cbSoPhut.BackColor = SystemColors.Window;
                    txtSoLuong.BackColor = SystemColors.Window;
                    btnUpdate.ImageIndex = 3;
                    btnUpdate.Text = "Lưu (Ctrl+S)";
                    break;
            }
            txtTenKH.Focus();
        }
        private void ControlForSearch(bool IsSearch)
        {
            panNotSearch.Visible = !IsSearch;
            grbLoaiDatHen.Visible = !IsSearch;
            grbThongTinDatHen.Visible = !IsSearch;
            txtGhiChu.Visible = !IsSearch;
            lblGhiChu.Visible = !IsSearch;
            if (IsSearch)
            {
                
                lblHoTen.Text = @"&Họ tên";
                lblDiaChiDon.Text = @"Địa &chỉ đón";
                lblDienThoai.Text = @"&Điện thoại";
                lblThoidiemnhan.Text = @"Thời gian đón";
            }
            else
            {
                //panButton.Location = new Point(369, 196);
                lblHoTen.Text = @"&Họ tên*";
                lblDiaChiDon.Text = @"Địa &chỉ đón*";
                lblDienThoai.Text = @"&Điện thoại*";
                lblThoidiemnhan.Text = @"Thời điểm nhận";
            }
        }
        private void GetKhachDat_Search()
        {
            lblMsg.Text = "";
            TenKhachHang = txtTenKH.Text.Trim();
            DiaChi = txtDiaChi.Text.Trim();
            ThoiDiemTiepNhanTu = calTGTiepNhanTu.DateTime;
            ThoiDiemTiepNhanDen = calTGTiepNhanDen.DateTime;
            SoDienThoai = txtDienThoai.Text.Trim();
            LoaiXe = "";
            SoLuongXe = Convert.ToInt16(txtSoLuong.Text);
            if (txtKenh.EditValue != null)
            {
                VungKenh = Convert.ToInt16(txtKenh.Value);
            }

            if (rbMotLan.Checked == true && rbLapLai.Checked == true
                || rbMotLan.Checked == false && rbLapLai.Checked == false)
            {
                IsLapLai = -1;
            }
            else if (rbMotLan.Checked == true)
            {
                IsLapLai = 0;
            }
            else
            {
                IsLapLai = 1;
            }
            GioDonTu = calGioDonTu.DateTime;
            GioDonDen = calGioDonDen.DateTime;
            if (calNgayBatDau.Text != "")
                ThoiDiemBatDau = calNgayBatDau.DateTime.Date;
            else
                ThoiDiemBatDau = DateTime.MinValue;
            if (calNgayKetThuc.Text != "")
                ThoiDiemKetThuc = calNgayKetThuc.DateTime.Date;
            else
                ThoiDiemKetThuc = DateTime.MinValue;
            if (cbSoPhut.Text != "")
            {
                SoPhutBaoTruoc = Convert.ToInt16(cbSoPhut.Value);
            }

        }

        /// <summary>
        /// Search dữ liệu và fill vào grid
        /// </summary>
        private void BindDataSearch()
        {
            if (g_FormStatus == 0 || g_IsSearched)
            {
                G_ListKhachDat = new KhachDatBL().GetKhachDat_Search_V2((DateTime)calTGTiepNhanTu.GetValue(), (DateTime)calTGTiepNhanDen.GetValue(), TenKhachHang, DiaChi, SoDienThoai);
            }
            else
            {
                G_ListKhachDat = new KhachDatBL().GetKhachDat_TGTiepNhan(calThoiDiemTiepNhan.DateTime);//Lấy 7 ngày gần nhất!
            }

            if (G_ListKhachDat == null)
            {
                lblMsg.Text = "Không tìm thấy dữ liệu";
            }
            gridControlDSDatHen.DataSource = G_ListKhachDat;
        }

        private string GetThongTinLoaiXeChon2()
        {
            string carType = ipLoaiXe.EditValue.ToString();
            string loaiXe = CommonBL.ListStaxiLoaiXe.FirstOrDefault(a => a.StaxiType.ToString() == carType).Name;
            return loaiXe;
        }
        private void SetThongTinLoaiXe2(string loaiXe)//Lấy theo seat
        {
            if (!string.IsNullOrEmpty(loaiXe) && loaiXe!="0")
            {
                StaxiCarType temp = CommonBL.ListStaxiLoaiXe.FirstOrDefault(a => a.StaxiType.ToString()==loaiXe);
                if(temp!=null )
                {
                    if (temp.Seat == 4)
                        chk4Cho.Checked = true;
                    else if (temp.Seat == 7)
                        chk7Cho.Checked = true;
                }
            }
            else
            {
                chk4Cho.Checked = false;
                chk7Cho.Checked = false;
            }
        }
        #endregion

        #region ===========================Form Event =================================

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            if (g_FormStatus == 2)
            {
                if (g_IDKhachDat <= 0)
                    return;

                GetDataInput();               
                try
                {
                    g_KhachDat.Update();
                    lblMsg.ForeColor = Color.Blue;
                    lblMsg.Text = "Cập nhật thành công";

                    if (g_IsNow)
                        GetKhachDat_NgayTiepNhan();
                    else
                        BindDataSearch();
                }
                catch
                {
                    lblMsg.Text = "Cập nhật không thành công";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            else if (g_FormStatus == 1)
            {
                GetDataInput();// Lay dữ liệu

                try
                {
                    g_KhachDat.Insert();
                    lblMsg.Text = "Thêm mới thành công";
                    lblMsg.ForeColor = Color.Blue;
                    g_IsInserting = true;
                    if (g_IsNow)
                        GetKhachDat_NgayTiepNhan();
                    else
                    {
                        BindDataSearch();
                    }
                    RefreshForm(1);
                    g_IsInserting = false;
                    FillDefaultDataToForm(1);                    
                }
                catch( Exception ex)
                {
                    lblMsg.Text = "Thêm mới không thành công";
                    lblMsg.ForeColor = Color.Red;
                    LogError.WriteLogError("UpdateKhachDat", ex);
                }
            }
            else if (g_FormStatus == 0)
            {
                GetKhachDat_Search();
                BindDataSearch();
            }
            RefreshForm(1);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            UpdateStatus(-2, "Xóa");
        }

        private void btnHoan_Click(object sender, EventArgs e)
        {
            UpdateStatus(-1, "Hoãn");
        }
        private void UpdateStatus(int StatusRow, string strStatus)
        {
            if (System.Windows.Forms.MessageBox.Show("Bạn có muốn " + strStatus + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (gridDSDatHen.RowCount > 0 && g_IDKhachDat > 0 && g_KhachDat != null)
                {
                    g_KhachDat.PK_KhachDatID = g_IDKhachDat;
                    g_KhachDat.StatusRow = StatusRow;
                    g_KhachDat.UpdatedBy = ThongTinDangNhap.USER_ID;
                    if (g_KhachDat.UpdateStatus())
                    {
                        lblMsg.Text = strStatus + " Thành Công";
                        lblMsg.ForeColor = Color.Blue;
                        gridControlDSDatHen.RefreshDataSource();
                    }
                }
                else
                {
                    lblMsg.Text = "Vui lòng chọn khách đặt cần thao tác";
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcelGridDev();
        }

        private void ExportExcelGridDev()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                string FilenameDefault = string.Format("KhachDat_DanhSach_{0}", DateTime.Now.ToString("ddMMyyyy_HH_mm"));
                saveDialog.FileName = FilenameDefault + ".xls";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridDSDatHen.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridDSDatHen.ExportToXlsx(exportFilePath);
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                            {
                                Process.Start(exportFilePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("btnExportExcel_Click", ex);
                        }
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            g_IsFirstLoad = true;
            RefreshForm(1);
            FillDefaultDataToForm(1);
            SetAllCheckBox();
            lblMsg.Text = string.Empty;
            g_IsSearched = false;
            g_IsFirstLoad = false;
        }

        private void SetAllCheckBox()
        {
            try
            {
                foreach (var item in grbHangTuan.Controls)
                {
                    ((InputCheckbox) item).Checked = true;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SetAllCheckBox: ", ex);
            }
        }
        #endregion

        #region ============================Key Event =================================
        private void gridDSDatHen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridDSDatHen.RowCount>0 && !g_IsFirstLoad)
            {
                KhachDatBL khachDat = gridDSDatHen.GetFocusedRow() as KhachDatBL;                
                SetDataToForm(khachDat);
            }
        }
        private void gridDSDatHen_DoubleClick(object sender, EventArgs e)
        {
            if (gridDSDatHen.RowCount > 0 && !g_IsFirstLoad && g_FormStatus!=0)
            {
                KhachDatBL kd = gridDSDatHen.GetFocusedRow() as KhachDatBL;
                SetDataToForm(kd);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.Delete:
                    btnDelete.PerformClick();
                    break;
                case Keys.Control | Keys.S:
                    btnUpdate.PerformClick();
                    break;
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F5:
                    g_IsFirstLoad = true;
                    RefreshForm(1);
                    FillDefaultDataToForm(1);
                    lblMsg.Text = string.Empty;
                    g_IsSearched = false;
                    g_IsFirstLoad = false;
                    break;
                case Keys.Alt | Keys.H:
                    txtTenKH.Focus();
                    break;
                case Keys.Alt | Keys.D:
                    txtDienThoai.Focus();
                    break;
                case Keys.Alt | Keys.C:
                    txtDiaChi.Focus();
                    break;
                case Keys.Alt | Keys.G:
                    if (g_FormStatus == 0)
                        calGioDonTu.Focus();
                    else
                        calGioDon.Focus();
                    break;
                case Keys.Alt | Keys.B:
                    calNgayBatDau.Focus();
                    break;
                case Keys.Alt | Keys.K:
                    calNgayKetThuc.Focus();
                    break;
                case Keys.Alt | Keys.T:
                    cbSoPhut.Focus();
                    break;
                case Keys.Alt | Keys.U:
                    txtKenh.Focus();
                    break;
                //case Keys.Alt | Keys.O:
                //    if (chkXeLIMO7.Checked)
                //        chkXeLIMO7.Checked = false;
                //    else
                //        chkXeLIMO7.Checked = true;
                //    return true;
                //case Keys.Alt | Keys.V:
                //    if (chkXeVIOS4.Checked)
                //        chkXeVIOS4.Checked = false;
                //    else
                //        chkXeVIOS4.Checked = true;
                //    return true;
                //case Keys.Alt | Keys.N:
                //    if (chkXeINOVA7.Checked)
                //        chkXeINOVA7.Checked = false;
                //    else
                //        chkXeINOVA7.Checked = true;
                //    return true;
                //case Keys.Alt | Keys.A:
                //    if (chkXeKI4.Checked)
                //        chkXeKI4.Checked = false;
                //    else
                //        chkXeKI4.Checked = true;
                //    return true;
                case Keys.Alt | Keys.S:
                    txtSoLuong.Focus();
                    return true;
                case Keys.Alt | Keys.M:
                    if (g_FormStatus == 0)
                    {
                        if (rbMotLan.Checked == true)
                            rbMotLan.Checked = false;
                        else
                            rbMotLan.Checked = true;
                    }
                    else
                        rbMotLan.Checked = true;
                    break;
                case Keys.Alt | Keys.L:
                    if (g_FormStatus == 0)
                    {
                        if (rbLapLai.Checked == true)
                            rbLapLai.Checked = false;
                        else
                            rbLapLai.Checked = true;
                    }
                    else
                        rbLapLai.Checked = true;
                    break;
                case Keys.Alt | Keys.I:
                    txtGhiChu.Focus();
                    break;
                case Keys.Alt | Keys.E:
                    if (g_FormStatus == 0)
                        calTGTiepNhanTu.Focus();
                    else
                        calThoiDiemTiepNhan.Focus();
                    break;
                case Keys.Alt | Keys.D2:
                    if (chkThu2.Checked)
                        chkThu2.Checked = false;
                    else
                        chkThu2.Checked = true;
                    break;
                case Keys.Alt | Keys.D3:
                    if (chkThu3.Checked)
                        chkThu3.Checked = false;
                    else
                        chkThu3.Checked = true;
                    break;
                case Keys.Alt | Keys.D4:
                    if (chkThu4.Checked)
                        chkThu4.Checked = false;
                    else
                        chkThu4.Checked = true;
                    break;
                case Keys.Alt | Keys.D5:
                    if (chkThu5.Checked)
                        chkThu5.Checked = false;
                    else
                        chkThu5.Checked = true;
                    break;
                case Keys.Alt | Keys.D6:
                    if (chkThu6.Checked)
                        chkThu6.Checked = false;
                    else
                        chkThu6.Checked = true;
                    break;
                case Keys.Alt | Keys.D7:
                    if (chkThu7.Checked)
                        chkThu7.Checked = false;
                    else
                        chkThu7.Checked = true;
                    break;
                case Keys.Alt | Keys.D8:
                    if (chkCN.Checked)
                        chkCN.Checked = false;
                    else
                        chkCN.Checked = true;
                    break;
                case Keys.Control | Keys.F:
                    RefreshForm(0);
                    break;
                case Keys.Up:
                    if (rbMotLan.Focused == true)
                        cbSoPhut.Focus();
                    break;
                case Keys.Left:
                    if (rbMotLan.Focused == true)
                        calGioDon.Focus();
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
        private void calNgayBatDau_EditValueChanged(object sender, EventArgs e)
        {
            if (rbMotLan.Checked)
            {
                calNgayKetThuc.SetValue(calNgayBatDau.GetValue());
            }
        }

        private void rbMotLan_CheckedChanged_1(object sender, EventArgs e)
        {
            grbHangTuan.Visible = !rbMotLan.Checked;
            calNgayKetThuc.Enabled = !rbMotLan.Checked;
            if (rbMotLan.Checked)
            {
                calNgayKetThuc.SetValue(calNgayBatDau.GetValue());
            }
        }

        private void txtTenKH_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiaChi.Focus();
            }
        }

        private void txtDiaChi_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDienThoai.Focus();
            }
        }

        private void txtDienThoai_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calThoiDiemTiepNhan.Focus();
            }
        }

        private void calThoiDiemTiepNhan_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKenh.Focus();
            }
        }

        private void txtKenh_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoLuong.Focus();
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLoaiXe.Focus();
            }
        }

        private void txtLoaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void calGioDonTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calGioDonDen.Focus();
            }
        }

        private void calGioDonDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calNgayBatDau.Focus();
            }
        }

        private void calNgayBatDau_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calNgayKetThuc.Focus();
            }
        }

        private void calNgayKetThuc_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbSoPhut.Focus();
            }
        }

        private void cbSoPhut_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoTien.Focus();
            }
        }
        private void txtSoTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGhiChu.Focus();
            }
        }
        private void ipLoaiXe_EditValueChanged(object sender, EventArgs e)
        {
            if (g_LoaiXeChange || ipLoaiXe.IsPopupOpen)
                return;
            g_LoaiXeChange = true;
            chk4Cho.Checked = false;
            chk7Cho.Checked = false;
            cbkSanBay.Checked = false;
            var loaixe = ipLoaiXe.EditValue.To<string>().Split(',').Select(p => p.Trim().To<int>()).ToList();
            var lx = (CommonBL.ListStaxiLoaiXe.FirstOrDefault(p => loaixe.Any(pi => p.StaxiType == pi)));
            if (lx != null && ipLoaiXe.EditValue != null && (string)ipLoaiXe.EditValue != "")
            {
                if (lx.Seat != 4 && lx.Seat != 7)
                {
                    ipLoaiXe.Properties.DataSource = CommonBL.ListStaxiLoaiXe;
                }
                else
                {
                    ipLoaiXe.Properties.DataSource = CommonBL.ListStaxiLoaiXe.Where(p => p.Seat == lx.Seat).ToList();
                    if (lx.Seat == 4)
                    {
                        chk4Cho.Checked = true;
                    }
                    else
                    {
                        chk7Cho.Checked = true;
                    }
                }
                if (lx.Type == Utils.StaxiCarType_Type.AriPort)
                    cbkSanBay.Checked = true;

                ipLoaiXe.EditValue = lx.StaxiType;
                ipLoaiXe.RefreshEditValue();
                ipLoaiXe.Refresh();
                ipLoaiXe.Properties.DropDownRows = ipLoaiXe.Properties.Items.Count > ipLoaiXe.RowCount ? ipLoaiXe.RowCount : ipLoaiXe.Properties.Items.Count;
            }
            else
            {
                RefreshLoaiXe();
            }
            g_LoaiXeChange = false;
        }
        private void RefreshLoaiXe()
        {
            var listXe = CommonBL.ListStaxiLoaiXe;
            if (cbkSanBay.Checked)
                listXe = listXe.Where(p => p.Type == Utils.StaxiCarType_Type.AriPort).ToList();
            if (chk4Cho.Checked)
                listXe = listXe.Where(p => p.Type == Utils.StaxiCarType_Type.Taxi && p.Seat == 4).ToList();
            else if (chk7Cho.Checked)
                listXe = listXe.Where(p => p.Type == Utils.StaxiCarType_Type.Taxi && p.Seat == 7).ToList();
            ipLoaiXe.Properties.DataSource = listXe;
            ipLoaiXe.EditValue = null;
            ipLoaiXe.RefreshEditValue();
            ipLoaiXe.Refresh();
            if (ipLoaiXe.Properties.Items.Count > 0)
            {
                ipLoaiXe.Properties.Items[0].CheckState = CheckState.Checked;
                if (listXe.First().Type == Utils.StaxiCarType_Type.AriPort)
                    cbkSanBay.Checked = true;
            }
            ipLoaiXe.Properties.DropDownRows = ipLoaiXe.Properties.Items.Count > ipLoaiXe.RowCount ? ipLoaiXe.RowCount : ipLoaiXe.Properties.Items.Count;
        }
        private void cbkSanBay_CheckedChanged(object sender, EventArgs e)
        {
            g_LoaiXeChange = true;
            RefreshLoaiXe();
            g_LoaiXeChange = false;
        }
        private void chk4Cho_EditValueChanged(object sender, EventArgs e)
        {
            if (g_LoaiXeChange) return;
            g_LoaiXeChange = true;
            if (chk4Cho.Checked) chk7Cho.Checked = false;
            RefreshLoaiXe();
            g_LoaiXeChange = false;
        }
        private void chk7Cho_CheckedChanged(object sender, EventArgs e)
        {
            if (g_LoaiXeChange) return;
            g_LoaiXeChange = true;
            if (chk7Cho.Checked) chk4Cho.Checked = false;
            RefreshLoaiXe();
            g_LoaiXeChange = false;
        }
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void gridDSDatHen_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var khachdat = (KhachDatBL)gridDSDatHen.GetRow(e.RowHandle);
            if (khachdat != null)
            {
                if (khachdat.UpdatedDateKD != null)
                {
                    if ((g_IsSearched && khachdat.UpdatedDateKD > calTGTiepNhanTu.DateTime) || (!g_IsSearched && khachdat.UpdatedDateKD > DateTime.Now.Date))
                    {
                        e.Appearance.BackColor = Color.MistyRose;                        
                    }
                }
            }
        }

        private void gridDSDatHen_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (!e.Column.FieldName.Equals("DiaChi")) return;

            var khachdat = (KhachDatBL)gridDSDatHen.GetRow(e.RowHandle);
            if (khachdat != null)
            {
                if (khachdat.StatusRow != null)
                {
                    if (khachdat.StatusRow == -1)
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                    else if (khachdat.StatusRow == -2)
                    {
                        e.Appearance.BackColor = Color.OrangeRed;
                    }
                }
            }
        }

    }
}