using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Femiani.Forms.UI.Input;
using Taxi.Business.KhachDat;
using System.Drawing;

namespace Taxi.GUI 
{
    public partial class frmKhachDat : Form
    {
        #region ===========================Initialize==================================
        /// <summary>
        /// trạng thái xử lý trên form. (g_IsUpdate = false : Trạng thái thêm mới).
        /// </summary>
        private bool g_IsUpdate = false;
        private long g_IDCuocGoi = 0;
        private int g_IDKhachDat = 0;
        /// <summary>
        /// Danh sách Địa chỉ (Auto Complete)
        /// </summary>
        private AutoCompleteEntryCollection g_ListDataAutoComplete;
        private DateTime g_DateTimeServer;
        private KhachDatBL objKhachDat = new KhachDatBL();

        /// <summary>
        /// Contructor for Addnew Record
        /// </summary>
        /// <param name="listDataAutoComplete">Dữ liệu danh sách địa chỉ</param>
        //public frmKhachDat(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete)
        //{
        //    InitializeComponent();
        //    refreshForm();
        //    lblTGTiepNhan.Text = string.Format("{0:HH:mm dd/MM/yyyy}", cuocGoi.ThoiDiemGoi);
        //    g_IDCuocGoi = cuocGoi.IDCuocGoi;
        //    txtDiaChi.Text = cuocGoi.DiaChiDonKhach;
        //    txtDienThoai.Text = cuocGoi.PhoneNumber;
        //    txtDienThoai.Enabled = false;//không được sửa số điện thoại gọi đến
        //    //txtKenh.Enabled = false;
        //    //txtSoLuong.Enabled = false;
        //    txtKenh.Text = cuocGoi.Vung.ToString();
        //    if (cuocGoi.SoLuongXe == 0)
        //        txtSoLuong.Text = "1";
        //    else
        //        txtSoLuong.Text = cuocGoi.SoLuongXe.ToString();
        //    if (cuocGoi.LoaiXe == "")
        //        chkXeKI4.Checked = true;
        //    else
        //        SetThongTinLoaiXe(cuocGoi.LoaiXe);
        //    g_ListDataAutoComplete = listDataAutoComplete;

        //}

        /// <summary>
        /// Contructor for Update Record
        /// </summary>
        /// <param name="ID">ID for Update</param>
        /// <param name="listDataAutoComplete">Dữ liệu danh sách địa chỉ</param>
        public frmKhachDat(KhachDatBL KhachDat, AutoCompleteEntryCollection listDataAutoComplete)
        {
            InitializeComponent();
            g_IsUpdate = true;
            objKhachDat = KhachDat;
            setDataInput();
            g_ListDataAutoComplete = listDataAutoComplete;
        }

        public frmKhachDat(KhachDatBL KhachDat, AutoCompleteEntryCollection listDataAutoComplete, bool isUpdate)
        {
            InitializeComponent();
            g_IsUpdate = isUpdate;
            objKhachDat = KhachDat;
            setDataInput();
            g_ListDataAutoComplete = listDataAutoComplete;
        }

        public frmKhachDat()
        {
            InitializeComponent();
            g_ListDataAutoComplete = new AutoCompleteEntryCollection();
        }
        #endregion

        #region ===========================Load Form===================================
        private void frmKhachDat_Load(object sender, EventArgs e)
        {
            fillDefaultDataToForm();
        }

        private void fillDefaultDataToForm()
        {
            txtDiaChi.Items = g_ListDataAutoComplete;
            //txtKenh.Text = "1";
            chk4Cho.Checked = true;
            txtTenKH.Text = "KH";
            txtDiaChi.Focus();
        }

        #endregion

        #region ===========================Validate====================================
        private bool isValid()
        {
            lblMsg.Text = "";
            lblMsg.ForeColor = Color.Red;
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
            if (txtKenh.Text.Trim() == String.Empty || Convert.ToInt16(txtKenh.Value) <= 0)
            {
                lblMsg.Text = "Vui lòng nhập Vùng/Kênh";
                txtKenh.Focus();
                return false;
            }
            //else if (CheckVungNamTrongVungCauHinh(Convert.ToInt16(txtKenh.Value)))
            //{
            //    lblMsg.Text = "Vui lòng nhập Vùng/Kênh thuộc vùng/kênh trong cấu hình";
            //    txtKenh.Focus();
            //    return false;
            //}
            if (txtSoLuong.Text.Trim() == String.Empty || Convert.ToInt16(txtSoLuong.Value) <= 0)
            {
                lblMsg.Text = "Vui lòng nhập Số lượng xe";
                txtSoLuong.Focus();
                return false;}
            if (rbLapLai.Checked&&calNgayBatDau.Value > DateTime.MinValue && calNgayKetThuc.Value > DateTime.MinValue &&
                calNgayBatDau.Value.Date > calNgayKetThuc.Value.Date)
            {
                lblMsg.Text = "Vui lòng nhập ngày bắt đầu nhỏ hơn hoặc bằng ngày kết thúc";
                calNgayBatDau.Focus();
                return false;
                
            }
            double giaTien = 0;
            if (!double.TryParse(txtGiaTien.Text.Trim(), out giaTien))
            {
                lblMsg.Text = "Giá tiền không hợp lệ";
                txtGiaTien.Focus();
                return false;
            }
            //if (chk4Cho.Checked == false &&
            //    chkXeLIMO7.Checked == false &&
            //    chk7Cho.Checked == false &&
            //    chkINO.Checked == false)
            //{
            //    lblMsg.Text = "Vui lòng nhập chọn loại xe";
            //    chk4Cho.Focus();
            //    return false;
            //}

            return true;

        }
        /// <summary>
        /// Kiểm tra vùng có thuộc vùng cấu hình
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
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
        #endregion

        #region ======================Form Status======================================
        /// <summary>
        /// hàm thực hiện set thông tin loại xe
        /// Input : 
        ///     - KIA,VIO,INO,LIMO
        /// Ouput :
        ///      Set lên check box
        /// </summary>
        /// <param name="p"></param>
        //private void SetThongTinLoaiXe(string loaiXe)
        //{
        //    if (loaiXe != null && loaiXe.Length > 0)
        //    {
        //        if (loaiXe.Contains(DSLoaiXe.MORNING))
        //        {
        //            chk4Cho.Checked = true;
        //        }
        //        if (loaiXe.Contains(DSLoaiXe.VIOS))
        //        {
        //            chk7Cho.Checked = true;
        //        }
        //        if (loaiXe.Contains(DSLoaiXe.CARENS))
        //        {
        //            chkCAR.Checked = true;
        //        }
        //        if (loaiXe.Contains(DSLoaiXe.INOVA))
        //        {
        //            chkINO.Checked = true;
        //        }
        //    }
        //    else
        //        chk4Cho.Checked = true;
        //}

        /// <summary>
        /// Get data on the form (Adding / Updating)
        /// </summary>
        /// <returns>false : không lấy được ID cuộc gọi</returns>
        private bool getDataInput()
        {
            if (g_IDCuocGoi <  0)
            {
                lblMsg.Text = "Vui lòng chọn cuộc gọi cần đặt xe";
                lblMsg.ForeColor = Color.Red;
                return false;
            }
            objKhachDat.ThoiDiemTiepNhan = DieuHanhTaxi.GetTimeServer();
            objKhachDat.FK_CuocGoiID = g_IDCuocGoi;
            objKhachDat.TenKhachHang = txtTenKH.Text.Trim();
            objKhachDat.DiaChi = txtDiaChi.Text.Trim();
             
            objKhachDat.SoDienThoai = txtDienThoai.Text.Trim();
            objKhachDat.VungKenh = Convert.ToInt16(txtKenh.Value);
            objKhachDat.LoaiXe = GetThongTinLoaiXeChon();
            objKhachDat.SoLuongXe = Convert.ToInt16(txtSoLuong.Value);
            if (rbLapLai.Checked)
            {
                objKhachDat.IsLapLai = true;
                objKhachDat.ThoiDiemKetThuc = calNgayKetThuc.Value;
                objKhachDat.NgayTrongTuanLapLai = getNgayTrongTuan();
            }
            else
            {
                objKhachDat.IsLapLai = false;
                objKhachDat.ThoiDiemKetThuc = calNgayBatDau.Value;
                objKhachDat.NgayTrongTuanLapLai = "";
            }
            objKhachDat.GioDon = calGioDon.Value;
            objKhachDat.ThoiDiemBatDau = calNgayBatDau.Value;

            objKhachDat.SoPhutBaoTruoc = Convert.ToInt16(cbSoPhut.Value);
            //objKhachDat.FK_CuocGoiID = 0;
            objKhachDat.CreatedBy = ThongTinDangNhap.USER_ID;
            objKhachDat.GhiChu = txtGhiChu.Text.Trim();
            return true;
        }

        private string GetThongTinLoaiXeChon()
        {
            string loaiXe = string.Empty;
            if (chk4Cho.Checked)
            {
                loaiXe = "4c,";
            }
            if (chk7Cho.Checked)
            {
                loaiXe += "7c,";
            }
            loaiXe += txtLoaiXe.Text.Trim();
            return loaiXe;
        }


        private string GetThongTinLoaiXeChon2()
        {
            string loaiXe = string.Empty;
            if (chk4Cho.Checked)
            {
                loaiXe += "4,";
            }
            if (chk7Cho.Checked)
            {
                loaiXe += "7,";
            }
            if (loaiXe.Length > 0)
            {
                loaiXe = loaiXe.Substring(0, loaiXe.Length - 1);
            }
            return loaiXe;
        }


        private void SetThongTinLoaiXe2(string loaiXe)
        {
            if (loaiXe != null && loaiXe.Length > 0)
            {
                string strLoaiXe = "";
                strLoaiXe = loaiXe;
                if (loaiXe.Contains("4c"))
                {
                    chk4Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Replace("4c,", "");
                }
                if (loaiXe.Contains("7c"))
                {
                    chk7Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Replace("7c,", "");
                }
                txtLoaiXe.Text = strLoaiXe;
            }
        }

        /// <summary>
        /// Set data on the form
        /// </summary>
        private void setDataInput()
        {
            g_IDKhachDat = objKhachDat.PK_KhachDatID;
            if (objKhachDat.TenKhachHang == "")
                txtTenKH.Text = objKhachDat.DiaChi;
            else
                txtTenKH.Text = objKhachDat.TenKhachHang;
            txtDiaChi.Text = objKhachDat.DiaChi;
            lblTGTiepNhan.Text = string.Format("{0:HH:mm dd/MM/yyyy}", objKhachDat.ThoiDiemTiepNhan);
            txtDienThoai.Text = objKhachDat.SoDienThoai;
            txtKenh.Value = objKhachDat.VungKenh;
            rbLapLai.Checked = objKhachDat.IsLapLai;
            rbMotLan.Checked = !objKhachDat.IsLapLai;
            calNgayKetThuc.Value = objKhachDat.ThoiDiemKetThuc;
            setNgayTrongTuan(objKhachDat.NgayTrongTuanLapLai);
            calGioDon.Value = objKhachDat.GioDon;
            calNgayBatDau.Value = objKhachDat.ThoiDiemBatDau;
            cbSoPhut.Value = objKhachDat.SoPhutBaoTruoc;
            txtGhiChu.Text = objKhachDat.GhiChu;
            txtSoLuong.Text = objKhachDat.SoLuongXe.ToString();
            txtGiaTien.Text = objKhachDat.SoTien.ToString();
            SetThongTinLoaiXe2(objKhachDat.LoaiXe);
        }

        /// <summary>
        /// Get Ngày trong tuần lặp lại
        /// </summary>
        /// <returns>2;3;4;5;6;7;8</returns>
        private string getNgayTrongTuan()
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
                strNgayTrongTuanLapLai += "8;";

            if (strNgayTrongTuanLapLai == "")
                return "";

            return strNgayTrongTuanLapLai.Substring(0, strNgayTrongTuanLapLai.Length - 1);
        }

        /// <summary>
        /// set Ngày trong tuần lặp lại
        /// </summary>
        private void setNgayTrongTuan(string strNgayTrongTuanLapLai)
        {
            if (strNgayTrongTuanLapLai == null) return;
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
                if (arrValue[i] == "8")
                {
                    chkCN.Checked = true;
                    continue;
                }
            }
        }

        /// <summary>
        /// Khởi tạo lại trạng thái ban đầu của form
        /// </summary>
        private void refreshForm()
        {
            g_IsUpdate = false;
            txtTenKH.Focus();
            g_DateTimeServer = DieuHanhTaxi.GetTimeServer();
            lblTGTiepNhan.Text = string.Format("{0:HH:mm dd/MM/yyyy}", g_DateTimeServer);
            cbSoPhut.Value = 15;
            calGioDon.Value = new DateTime(1900, 1, 1, g_DateTimeServer.Hour, g_DateTimeServer.Minute, 0);
            calNgayBatDau.Value = g_DateTimeServer;
            calNgayKetThuc.Value = g_DateTimeServer;
            txtTenKH.Text = "KH";
            txtKenh.Text = "1";
            txtKenh.Enabled = true;
            txtDienThoai.Text = "";
            txtDienThoai.Enabled = true;
            txtDiaChi.Text = "";
            rbMotLan.Checked = true;
            txtGhiChu.Text = "";
        }

        /// <summary>
        /// Get thông tin khách đặt hẹn
        /// </summary>
        /// <returns></returns>
        public string GetKhachDat()
        {
            return string.Format("{0}-{1}-{2}",calGioDon.Value.ToShortTimeString(), txtTenKH.Text,txtDiaChi.Text);
        }
        #endregion

        #region ===========================Form Event =================================
        private void rbMotLan_CheckedChanged(object sender, EventArgs e)
        {
            boxHangTuan.Enabled = false;
            calNgayKetThuc.Enabled = false;
        }

        private void rbLapLai_CheckedChanged(object sender, EventArgs e)
        {
            boxHangTuan.Enabled = true;
            calNgayKetThuc.Enabled = true;
            chkThu2.Checked = true;
            chkThu3.Checked = true;
            chkThu4.Checked = true;
            chkThu5.Checked = true;
            chkThu6.Checked = true;
            chkThu7.Checked = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;

            if (g_IsUpdate)
            {
                if (g_IDKhachDat <= 0)
                    return;

                if (objKhachDat.UpdateKhachDat())
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    //lblMsg.ForeColor = Color.Blue;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblMsg.Text = "Cập nhật không thành công";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            else
            {
                if (getDataInput())// Lay dữ liệu + ktra xem có IDCuocGoi ko
                {
                    if (objKhachDat.InsertKhachDat())
                    {
                        new MessageBox.MessageBoxBA().Show("Thêm mới thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        //btnLuu.Enabled = false;//Insert thành công, vẫn hiển thị dữ liệu trên form nhưng không cho phép insert or update tiếp                        
                        //g_IsUpdate = true;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới không thành công";
                        lblMsg.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion

        #region ============================Key Event =================================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    btnLuu_Click(null, null);
                    return true;
                case Keys.Escape:
                    Close();
                    return true;
                //case Keys.F5:
                //    if (g_IsUpdate)
                //        Refresh();
                //    return true;
                case Keys.Alt | Keys.H:
                    txtTenKH.Focus();
                    return true;
                case Keys.Alt | Keys.D:
                    txtDienThoai.Focus();
                    return true;
                case Keys.Alt | Keys.C:
                    txtDiaChi.Focus();
                    return true;
                case Keys.Alt | Keys.U:
                    txtKenh.Focus();
                    return true;
                case Keys.Alt | Keys.G:
                    calGioDon.Focus();
                    return true;
                case Keys.Alt | Keys.B:
                    calNgayBatDau.Focus();
                    return true;
                case Keys.Alt | Keys.K:
                    calNgayKetThuc.Focus();
                    return true;
                case Keys.Alt | Keys.T:
                    cbSoPhut.Focus();
                    return true;
                case Keys.Alt | Keys.M:
                    rbMotLan.Checked = true;
                    return true;
                case Keys.Alt | Keys.L:
                    rbLapLai.Checked = true;
                    return true;
                case Keys.Alt | Keys.I:
                    txtGhiChu.Focus();
                    return true;
                case Keys.Alt | Keys.O:
                    if (chkXeLIMO7.Checked)
                        chkXeLIMO7.Checked = false;
                    else
                        chkXeLIMO7.Checked = true;
                    return true;
                case Keys.Alt | Keys.V:
                    if (chk7Cho.Checked)
                        chk7Cho.Checked = false;
                    else
                        chk7Cho.Checked = true;
                    return true;
                //case Keys.Alt | Keys.N:
                //    if (chkINO.Checked)
                //        chkINO.Checked = false;
                //    else
                //        chkINO.Checked = true;
                //    return true;
                case Keys.Alt | Keys.A:
                    if (chk4Cho.Checked)
                        chk4Cho.Checked = false;
                    else
                        chk4Cho.Checked = true;
                    return true;
                case Keys.Alt | Keys.S:
                    txtSoLuong.Focus();
                    return true;
                case Keys.Alt | Keys.D2:
                    if (chkThu2.Checked)
                        chkThu2.Checked = false;
                    else
                        chkThu2.Checked = true;
                    return true;
                case Keys.Alt | Keys.D3:
                    if (chkThu3.Checked)
                        chkThu3.Checked = false;
                    else
                        chkThu3.Checked = true;
                    return true;
                case Keys.Alt | Keys.D4:
                    if (chkThu4.Checked)
                        chkThu4.Checked = false;
                    else
                        chkThu4.Checked = true;
                    return true;
                case Keys.Alt | Keys.D5:
                    if (chkThu5.Checked)
                        chkThu5.Checked = false;
                    else
                        chkThu5.Checked = true;
                    return true;
                case Keys.Alt | Keys.D6:
                    if (chkThu6.Checked)
                        chkThu6.Checked = false;
                    else
                        chkThu5.Checked = true;
                    return true;
                case Keys.Alt | Keys.D7:
                    if (chkThu7.Checked)
                        chkThu7.Checked = false;
                    else
                        chkThu7.Checked = true;
                    return true;
                case Keys.Alt | Keys.D8:
                    if (chkCN.Checked)
                        chkCN.Checked = false;
                    else
                        chkCN.Checked = true;
                    return true;
                case Keys.Shift | Keys.D1:
                    setVung("1");
                    return true;
                case Keys.Shift | Keys.D2:
                    setVung("2");
                    return true;
                case Keys.Shift | Keys.D3:
                    setVung("3");
                    return true;
                case Keys.Shift | Keys.D4:
                    setVung("4");
                    return true;
                case Keys.Shift | Keys.D5:
                    setVung("5");
                    return true;
                case Keys.Shift | Keys.D6:
                    setVung("6");
                    return true;
                case Keys.Shift | Keys.D7:
                    setVung("7");
                    return true;
                case Keys.Shift | Keys.D8:
                    setVung("8");
                    return true;
                case Keys.Shift | Keys.D9:
                    setVung("9");
                    return true;
                case Keys.Shift | Keys.D0:
                    setVung("10");
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        if (txtDiaChi.Focused == false)
        //        {
        //            btnLuu_Click(null, null);
        //            return true;
        //        }
        //    }
        //    return false;     
        //}
        private void setVung(string vung)
        {
            txtKenh.Focus();
            txtKenh.Text = vung;
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDienThoai.Focus();
        }

        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtKenh.Focus();
        }
        #endregion
    }
}