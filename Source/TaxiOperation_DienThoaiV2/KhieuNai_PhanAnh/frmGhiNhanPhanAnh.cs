using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business.PhanAnh;
using Taxi.Business;
using System.Text.RegularExpressions;

namespace Taxi.GUI
{
    public partial class frmGhiNhanPhanAnh : Form
    {
        #region ===========================Initialize==================================

        private PhanAnh objPhanAnh = new PhanAnh();
        private PhanAnh g_objPhanAnh;
        private long g_IdPA;
        private bool isUpdate = true;
        private bool g_isDaGiaiQuyet;
        private CuocGoi G_CuocGoi;
        public frmGhiNhanPhanAnh(string role)
        {
            InitializeComponent();
            fillDefaultDataToForm();
            EditTab(role);
        }
        public frmGhiNhanPhanAnh(string role, CuocGoi objCuocGoi)
        {
            InitializeComponent();
            G_CuocGoi = objCuocGoi;
            fillDefaultDataToForm();
            EditTab(role);
        }

        public frmGhiNhanPhanAnh(PhanAnh objThongTinPA, string role)
        {
            InitializeComponent();
            g_objPhanAnh = objThongTinPA;
            fillDataToForm(objThongTinPA);
            EditTab(role);
        }

        public frmGhiNhanPhanAnh(PhanAnh objThongTinPA, string role, bool isDaGiaiQuyet)
        {
            InitializeComponent();
            g_objPhanAnh = objThongTinPA;
            fillDataToForm(objThongTinPA);

            btnSave.Enabled = false;
            g_isDaGiaiQuyet = isDaGiaiQuyet;
        }

        #endregion

        #region ===========================Load Form===================================

        private void frmGhiNhanPhanAnh_Load(object sender, EventArgs e)
        {
            txtSoDT.Focus();

            ActiveControl = txtTenKH;

        }

        private void fillDefaultDataToForm()
        {
            isUpdate = false;
            string dateNow = DateTime.Now.ToString();
            string timeNow = getTime(DateTime.Now.Hour, DateTime.Now.Minute);            
            txtSoDT.Focus();
            lblTGPA.Text = String.Format("{0:dd/MM/yyyy} {1}", DateTime.Now, timeNow);

            txtTGPS_Gio.Text = timeNow;
            dateTGPS_Ngay.Text = dateNow;

            //txtGQ_TGGT_Gio.Text = timeNow;
            //dateGQ_TGGT_Ngay.Text = dateNow;

            //txtGQ_TGGQ_Gio.Text = timeNow;
            //dateGQ_TGGQ_Ngay.Text = dateNow;

            rbDDKH_VangLai.Checked = true;
            rbLPA_QuenHanhLy.Checked = true;
            rbDTPA_ConNguoi.Checked = true;
        }

        private void fillDataToForm(PhanAnh objThongTinPA)
        {
            isUpdate = true;
            g_IdPA = objThongTinPA.IdPA;
                       
            txtSoDT.Text = objThongTinPA.SoDT;
            txtSoDT.Enabled = false;
            lblTGPA.Text = objThongTinPA.TGPA.ToString("dd/MM/yyyy HH:mm");
            txtTGPS_Gio.Text = getTime(objThongTinPA.TGPS.Hour, objThongTinPA.TGPS.Minute);
            dateTGPS_Ngay.Value = objThongTinPA.TGPS;
            txtTenKH.Text = objThongTinPA.TenKH;
            txtNoiDung.Text = objThongTinPA.NoiDung;
            
            txtGQ_YKKH.Text = objThongTinPA.GQ_YKKH;
            // giờ giao trả
            txtGQ_TGGT_Gio.Text = objThongTinPA.GQ_TGT.Hour == 0 && objThongTinPA.GQ_TGT.Minute == 0 ? 
                                    getTime(DateTime.Now.Hour, DateTime.Now.Minute) : 
                                    getTime(objThongTinPA.GQ_TGT.Hour, objThongTinPA.GQ_TGT.Minute);
            // Ngày giao trả
            dateGQ_TGGT_Ngay.Value = objThongTinPA.GQ_TGT == DateTime.MinValue ? 
                                    DateTime.Now : objThongTinPA.GQ_TGT;
            // giờ giải quyết
            txtGQ_TGGQ_Gio.Text = objThongTinPA.GQ_TGGQ.Hour == 0 && objThongTinPA.GQ_TGGQ.Minute == 0 ? 
                                getTime(DateTime.Now.Hour, DateTime.Now.Minute) : 
                                getTime(objThongTinPA.GQ_TGGQ.Hour, objThongTinPA.GQ_TGGQ.Minute);
            // ngày giải quyết
            dateGQ_TGGQ_Ngay.Value = objThongTinPA.GQ_TGGQ == DateTime.MinValue ? 
                                        DateTime.Now : objThongTinPA.GQ_TGGQ;
            txtGQ_SoTai.Text = objThongTinPA.GQ_SoTai;
            txtGQ_KQ.Text = objThongTinPA.GQ_KQGQ;
            txtGQ_GhiChu.Text = objThongTinPA.GQ_GhiChu;
            txtDiaChi.Text = objThongTinPA.DiaChi;
            chkDaGiaiQuyet.Checked = objThongTinPA.TrangThai;
            chkGQ_CoHanhLy.Checked = objThongTinPA.GQ_HL;
            chkGQ_KHDongY.Checked = objThongTinPA.GQ_KHDongY;

            setLoaiPA(objThongTinPA.LoaiPA);
            txtLoTrinh_Tu.Text = objThongTinPA.LTTu;
            txtLoTrinh_Den.Text = objThongTinPA.LTDen;
            txtLoTrinh_DHT.Text = objThongTinPA.DHT;

            setDacDiemKH(objThongTinPA.DacDiem);
            setDoiTuongPA(objThongTinPA.DoiTuong);

            
        }

        private string getTime(int hour, int minute)
        {
            string strHour = hour.ToString();
            string strMinute = minute.ToString();
            if (strMinute.Length == 1)
            {
                strMinute = string.Format("0{0}", strMinute);
            }
            if (strHour.Length == 1)
            {
                strHour = string.Format("0{0}", strHour);
            }

            return string.Format("{0}:{1}", strHour, strMinute);
        }
        #endregion

        #region ===========================Validate====================================

        private bool isValid()
        {
            if (!(isValidNumber(txtSoDT, "Số DT") && isValidEmpty(txtNoiDung, "Nội dung phản ánh")))
            {
                tab_PA.SelectedIndex = 0;
                return false;
            }
            if (rbLPA_QuenHanhLy.Checked)
            {
                if (!(isValidEmpty(txtLoTrinh_Tu, "Lộ trình từ") && isValidEmpty(txtLoTrinh_Den, "Lộ trình đến")))
                {
                    tab_PA.SelectedIndex = 0;
                    return false;
                }
            }
            if (chkDaGiaiQuyet.Checked)
            {
                if (!isValidEmpty(txtGQ_KQ, "Kết quả giải quyết"))
                {
                    tab_PA.SelectedIndex = 1;
                    return false;
                }
                if (txtGQ_TGGQ_Gio.Text == "")
                {
                    new MessageBox.MessageBoxBA().Show("Vui lòng nhập Giờ giải quyết", "Thông báo lỗi",
                                                       Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                       Taxi.MessageBox.MessageBoxIconBA.Error);
                    tab_PA.SelectedIndex = 1;
                    txtGQ_TGGQ_Gio.Focus();
                    return false;

                }
                else
                {
                    if (!(isValidTime(txtGQ_TGGQ_Gio, "Giờ giải quyết")))
                    {
                        tab_PA.SelectedIndex = 1;
                        return false;
                    }
                }
            }
            //check giờ nhập hợp lệ


            if (txtTGPS_Gio.Text.Trim() != "")
            {
                if (!(isValidTime(txtTGPS_Gio, "Giờ phát sinh")))
                {
                    tab_PA.SelectedIndex = 0;
                    return false;
                }
            }

            if (!txtGQ_TGGT_Gio.Text.Equals("  :  "))
            {
                if (!(isValidTime(txtGQ_TGGT_Gio, "Giờ giao trả")))
                {
                    tab_PA.SelectedIndex = 1;
                    return false;
                }
            }
            return true;
        }

        private bool isValidTime(Janus.Windows.GridEX.EditControls.MaskedEditBox textbox, string ctrlName)
        {
            try
            {
                Regex checktime =
                 new Regex(@"^(([0-1][0-9])|([2][0-3])|(0)|(00)):(([0-5][0-9])|(0)|(00))$");

                if (checktime.IsMatch(textbox.Text.Trim()))
                {
                    return true;
                }
                else
                {
                    textbox.Focus();
                    new MessageBox.MessageBoxBA().Show(ctrlName + " không hợp lệ", "Thông báo lỗi",
                                                            Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                            Taxi.MessageBox.MessageBoxIconBA.Error);
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        } 

        private bool isValidEmpty(TextBox textbox, string ctrlName)
        {
            if ((textbox.Text == ""))
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập " + ctrlName, "Thông báo lỗi",
                                                        Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                        Taxi.MessageBox.MessageBoxIconBA.Error);
                textbox.Focus();
                return false;
            }
            return true;
        }

        private bool isValidNumber(TextBox textbox, string ctrlName)
        {
            if (textbox.Enabled)
            {
                if (textbox.Text == "")
                {
                    new MessageBox.MessageBoxBA().Show("Vui lòng nhập " + ctrlName, "Thông báo lỗi",
                                                            Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                            Taxi.MessageBox.MessageBoxIconBA.Error);
                    textbox.Focus();
                    return false;
                }
                else
                {
                    if (!IsNumber(textbox.Text.Trim()))
                    {
                        new MessageBox.MessageBoxBA().Show(ctrlName + " không hợp lệ", "Thông báo lỗi",
                                                            Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                            Taxi.MessageBox.MessageBoxIconBA.Error);
                        textbox.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        // Function to test whether the string is valid number or not
        private bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            return !objNotNumberPattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber) &&
            !objTwoMinusPattern.IsMatch(strNumber);
        }

        #endregion

        #region ======================Form Status======================================

        private void getDataInput()
        {
            string GQ_TGGT_Gio = txtGQ_TGGT_Gio.Text.Trim();
            string GQ_TGGQ_Gio = txtGQ_TGGQ_Gio.Text.Trim();
            System.Globalization.CultureInfo CultureInfo = new System.Globalization.CultureInfo("vi-VN");
            objPhanAnh.SoDT = txtSoDT.Text;
            objPhanAnh.TGPA = Convert.ToDateTime(lblTGPA.Text, CultureInfo);
            objPhanAnh.TGPS = Convert.ToDateTime(String.Format("{0} {1}", dateTGPS_Ngay.Text, txtTGPS_Gio.Text), CultureInfo);
            objPhanAnh.TenKH = txtTenKH.Text;
            objPhanAnh.NoiDung = txtNoiDung.Text;
            
            objPhanAnh.GQ_YKKH = txtGQ_YKKH.Text;
            if (!dateGQ_TGGT_Ngay.Equals("") && GQ_TGGT_Gio.Length == 5)
            {
                objPhanAnh.GQ_TGT = Convert.ToDateTime(String.Format("{0} {1}", dateGQ_TGGT_Ngay.Text, txtGQ_TGGT_Gio.Text), CultureInfo);
            }
            if (!dateGQ_TGGQ_Ngay.Equals("") && GQ_TGGQ_Gio.Length == 5)
            {
                objPhanAnh.GQ_TGGQ = Convert.ToDateTime(String.Format("{0} {1}", dateGQ_TGGQ_Ngay.Text, txtGQ_TGGQ_Gio.Text), CultureInfo);
            }
            objPhanAnh.GQ_SoTai = txtGQ_SoTai.Text;
            objPhanAnh.GQ_KQGQ = txtGQ_KQ.Text;
            objPhanAnh.GQ_GhiChu = txtGQ_GhiChu.Text;
            objPhanAnh.DiaChi = txtDiaChi.Text;
            objPhanAnh.TrangThai = chkDaGiaiQuyet.Checked;
            objPhanAnh.GQ_HL = chkGQ_CoHanhLy.Checked;
            objPhanAnh.GQ_KHDongY = chkGQ_KHDongY.Checked;
            objPhanAnh.NguoiTao = ThongTinDangNhap.USER_ID;
            objPhanAnh.NgayTao = DateTime.Now;
            objPhanAnh.NguoiSua = ThongTinDangNhap.USER_ID;
            objPhanAnh.NgaySua = DateTime.Now;

            objPhanAnh.IdPA = g_IdPA;
            objPhanAnh.LoaiPA = getLoaiPA();
            if (objPhanAnh.LoaiPA == 3)
            {
                objPhanAnh.LTTu = txtLoTrinh_Tu.Text;
                objPhanAnh.LTDen = txtLoTrinh_Den.Text;
                objPhanAnh.DHT = txtLoTrinh_DHT.Text;
            }
            else
            {
                objPhanAnh.LTTu = "";
                objPhanAnh.LTDen = "";
                objPhanAnh.DHT = "";
            }
            objPhanAnh.DacDiem = getDacDiemKH();
            objPhanAnh.DoiTuong = getDoiTuongPA();
            
        }

        private void setLoaiPA(int value)
        {
            switch (value)
            {
                case 0:
                    rbLPA_Khen.Checked = true;
                    break;
                case 1:
                    rbLPA_PhanNan.Checked = true;
                    break;
                case 2:
                    rbLPA_KhieuNai.Checked = true;
                    break;
                case 3:
                    rbLPA_QuenHanhLy.Checked = true;
                    break;
            }
        }

        private void setDacDiemKH(int value)
        {
            switch (value)
            {
                case 0:
                    rbDDKH_VangLai.Checked = true;
                    break;
                case 1:
                    rbDDKH_GoiDai.Checked = true;
                    break;
                case 2:
                    rbDDKH_TiepThi.Checked = true;
                    break;
            }
        }

        private void setDoiTuongPA(int value)
        {
            switch (value)
            {
                case 0:
                    rbDTPA_ConNguoi.Checked = true;
                    break;
                case 1:
                    rbDTPA_PhuongTien.Checked = true;
                    break;
            }
        }

        private void setLoaiPA_Focus(int value)
        {
            switch (value)
            {
                case 0:
                    rbLPA_Khen.Focus();
                    break;
                case 1:
                    rbLPA_PhanNan.Focus();
                    break;
                case 2:
                    rbLPA_KhieuNai.Focus();
                    break;
                case 3:
                    rbLPA_QuenHanhLy.Focus();
                    break;
            }
        }

        private void setDacDiemKH_Focus(int value)
        {
            switch (value)
            {
                case 0:
                    rbDDKH_VangLai.Focus();
                    break;
                case 1:
                    rbDDKH_GoiDai.Focus();
                    break;
                case 2:
                    rbDDKH_TiepThi.Focus();
                    break;
            }
        }

        private int getLoaiPA()
        {
            if (rbLPA_Khen.Checked)
            {
                return 0;
            }
            else if (rbLPA_PhanNan.Checked)
            {
                return 1;
            }
            else if (rbLPA_KhieuNai.Checked)
            {
                return 2;
            }
            else if (rbLPA_QuenHanhLy.Checked)
            {
                return 3;
            }
            return 0;
        }

        private int getDacDiemKH()
        {
            if (rbDDKH_VangLai.Checked)
            {
                return 0;
            }
            else if (rbDDKH_GoiDai.Checked)
            {
                return 1;
            }
            else if (rbDDKH_TiepThi.Checked)
            {
                return 2;
            }
            return 0;
        }

        private int getDoiTuongPA()
        {
            if (rbDTPA_ConNguoi.Checked)
            {
                return 0;
            }
            else if (rbDTPA_PhuongTien.Checked)
            {
                return 1;
            }
            return 0;
        }
        //------------------ ĐẶT CHẾ ĐỘ CHO CÁC TAB
        private void EditTab(string roleNhanVien)
        {
            //if(roleNhanVien == string.Empty )
            //{
            //    tbThongTinPA.TabVisible = true;
            //    tbGiaiQuyet.TabVisible = true ;
            //    tbThongTinPA.Enabled = false;
            //    tbGiaiQuyet.Enabled = false;
            //}
            // else 
            //switch (roleNhanVien)
            //{
            //    case DanhSachVaiTro.NVNHANPHANANH:
            //        tab_NDPA.TabVisible = true;
            //        tab_GQ.TabVisible = false;
            //        break;
            //    case DanhSachVaiTro.NVGIAIQUYETPHANANH:
            //        tab_NDPA.TabVisible = true;
            //        tab_GQ.TabVisible = true;
            //        //ko cho sửa thong tin phan anh
            //        tab_NDPA.Enabled = false;
            //        //txtTenKH.Enabled = false;
            //        //txtNoiDung.Enabled = false;
            //        //cbLoaiPhanAnh.Enabled = false;
            //        //cbTenCongTy.Enabled = false;
            //        //chkBinhThuong.Enabled = false;
            //        //chkNghiemTrong.Enabled = false;
            //        // btnSave.Enabled = false;
            //        // btnCancel.Enabled = false;
            //        break;
            //    case "All":
            //        tab_NDPA.TabVisible = true;
            //        tab_GQ.TabVisible = true;
            //        //tab_GQ.Focus();
            //        break;
            //}

        }        

        private void refreshForm()
        {
            fillDefaultDataToForm();
            txtSoDT.Text = "";
            txtTenKH.Text = "";
            txtNoiDung.Text = "";
            txtLoTrinh_Tu.Text = "";
            txtLoTrinh_Den.Text = "";
            txtLoTrinh_DHT.Text = "";
            txtGQ_YKKH.Text = "";
            txtGQ_SoTai.Text = "";
            txtGQ_KQ.Text = "";
            txtGQ_GhiChu.Text = "";
            txtDiaChi.Text = "";
            chkDaGiaiQuyet.Checked = false;
            chkGQ_CoHanhLy.Checked = true;
            chkGQ_KHDongY.Checked = true;
            rbDDKH_VangLai.Checked = true;
            rbDTPA_ConNguoi.Checked = true;
        }        

        private void change_LoaiPhanAnh(bool isVisible)
        {
            //txtLoTrinh_Tu.Text = "";
            //txtLoTrinh_Den.Text = "";
            //txtLoTrinh_DHT.Text = "";
            gb_LoTrinh.Visible = isVisible;
            if (isVisible)
                ActiveControl = txtLoTrinh_Tu;
        }

        private static void SetEnableOnAllChildControls(Control parentControl, bool enable)
        {
            foreach (Control control in parentControl.Controls)
            {
                control.Enabled = enable;
                SetEnableOnAllChildControls(control, enable);
            }
        }

        private static void SetReadOnlyOnAllControls(Control parentControl, bool readOnly)
        {
            if (parentControl is TextBoxBase)
                ((TextBoxBase)parentControl).ReadOnly = readOnly;
            foreach (Control control in parentControl.Controls)
                SetReadOnlyOnAllControls(control, readOnly);
        }
                
        #endregion

        #region ===========================Event ======================================

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (g_isDaGiaiQuyet)
                return;

            if (!isValid())
                return;

            getDataInput();
            if (isUpdate)
            {
                if (objPhanAnh.Update())
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật phản ánh thành công", "Thông báo",
                                                    Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                    Taxi.MessageBox.MessageBoxIconBA.Information);
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi cập nhật phản ánh", "Thông báo",
                                                    Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                    Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            else
            {
                if (objPhanAnh.Insert())
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật phản ánh thành công", "Thông báo",
                                                    Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                    Taxi.MessageBox.MessageBoxIconBA.Information);
                    refreshForm();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi cập nhật phản ánh", "Thông báo",
                                                    Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                                    Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            if (isUpdate)
            {
                fillDataToForm(g_objPhanAnh);
            }
            else
            {
                refreshForm();
            }
        }

        private void rbLPA_QuenHanhLy_CheckedChanged(object sender, EventArgs e)
        {
            change_LoaiPhanAnh(true);
        }

        private void rbLPA_KhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            change_LoaiPhanAnh(false);
        }

        private void rbLPA_PhanNan_CheckedChanged(object sender, EventArgs e)
        {
            change_LoaiPhanAnh(false);
        }

        private void rbLPA_Khen_CheckedChanged(object sender, EventArgs e)
        {
            change_LoaiPhanAnh(false);
        }

        #endregion

        #region ==========================Key Event====================================

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            #region ------------------------------------Tab Nội dung phản ánh------------
            if (tab_PA.SelectedIndex == 0)
            {
                switch (keyData)
                {
                    case Keys.F2:
                    case Keys.Control | Keys.S:
                    case Keys.Alt | Keys.S:
                    case Keys.Alt | Keys.L:
                        btnSave_Click(this, null);
                        return true;
                    //case Keys.Enter:
                    //    if (!(txtNoiDung.Focused || txtGQ_KQ.Focused || txtGQ_YKKH.Focused || txtGQ_GhiChu.Focused))
                    //    {
                    //        btnSave_Click(this, null);
                    //        return true;
                    //    }
                    //    return false;
                    case Keys.Alt | Keys.N:
                        btnRefresh_Click(this, null);
                        return true;
                    case Keys.Escape:
                        btnCancel_Click(this, null);
                        return true;
                    case Keys.Alt | Keys.O:
                        txtNoiDung.Focus();
                        return true;
                    case Keys.Alt | Keys.K:
                        txtTenKH.Focus();
                        return true;
                    case Keys.Alt | Keys.D:
                        txtDiaChi.Focus();
                        return true;
                    case Keys.Alt | Keys.D1:
                        if(rbLPA_Khen.Enabled)
                            rbLPA_Khen.Checked = true;
                        return true;
                    case Keys.Alt | Keys.D2:
                        if (rbLPA_PhanNan.Enabled)
                            rbLPA_PhanNan.Checked = true;
                        return true;
                    case Keys.Alt | Keys.D3:
                        if (rbLPA_KhieuNai.Enabled)
                            rbLPA_KhieuNai.Checked = true;
                        return true;
                    case Keys.Alt | Keys.D4:
                        if (rbLPA_QuenHanhLy.Enabled)
                            rbLPA_QuenHanhLy.Checked = true;
                        return true;
                    case Keys.Alt | Keys.U:
                        if (txtLoTrinh_Tu.Enabled)
                            txtLoTrinh_Tu.Focus();
                        return true;
                    case Keys.Alt | Keys.E:
                        if (txtLoTrinh_Den.Enabled)
                            txtLoTrinh_Den.Focus();
                        return true;
                    case Keys.Alt | Keys.H:
                        if (txtLoTrinh_DHT.Enabled)
                            txtLoTrinh_DHT.Focus();
                        return true;
                    case Keys.Alt | Keys.A:
                        txtTGPS_Gio.Focus();
                        return true;
                    case Keys.Alt | Keys.V:
                        if (rbDDKH_VangLai.Enabled)
                            rbDDKH_VangLai.Checked = true;
                        return true;
                    case Keys.Alt | Keys.G:
                        if (rbDDKH_GoiDai.Enabled)
                            rbDDKH_GoiDai.Checked = true;
                        return true;
                    case Keys.Alt | Keys.T:
                        if (rbDDKH_TiepThi.Enabled)
                            rbDDKH_TiepThi.Checked = true;
                        return true;
                    case Keys.Alt | Keys.C:
                        if (rbDTPA_ConNguoi.Enabled)
                            rbDTPA_ConNguoi.Checked = true;
                        return true;
                    case Keys.Alt | Keys.P:
                        if (rbDTPA_PhuongTien.Enabled)
                            rbDTPA_PhuongTien.Checked = true;
                        return true;
                    //case Keys.Alt | Keys.D1:
                    //    tab_PA.SelectedIndex = 0;
                    //    txtTenKH.Focus();
                    //    return true;
                    //case Keys.Alt | Keys.D2:
                    //    tab_PA.SelectedIndex = 1;
                    //    txtGQ_TGGQ_Gio.Focus();
                    //    return true;
                    default:
                        break;
                }
            }
            #endregion-------------------------------------------------------------------

            #region ------------------------------------Tab Kết quả phản ánh-------------
            else
            {
                switch (keyData)
                {
                    case Keys.Control | Keys.S:
                    case Keys.Alt | Keys.S:
                    case Keys.Alt | Keys.L:
                        btnSave_Click(this, null);
                        return true;
                    case Keys.Alt | Keys.N:
                        btnRefresh_Click(this, null);
                        return true;
                    case Keys.Escape:
                        btnCancel_Click(this, null);
                        return true;
                    case Keys.Alt | Keys.O:
                        txtGQ_TGGQ_Gio.Focus();
                        return true;
                    case Keys.Alt | Keys.E:
                        txtGQ_KQ.Focus();
                        return true;
                    case Keys.Alt | Keys.Y:
                        txtGQ_YKKH.Focus();
                        return true;
                    case Keys.Alt | Keys.U:
                        txtGQ_GhiChu.Focus();
                        return true;
                    case Keys.Alt | Keys.T:
                        txtGQ_SoTai.Focus();
                        return true;
                    case Keys.Alt | Keys.G:
                        txtGQ_TGGT_Gio.Focus();
                        return true;
                    case Keys.Alt | Keys.C:
                        if (chkGQ_CoHanhLy.Checked)
                            chkGQ_CoHanhLy.Checked = false;
                        else
                            chkGQ_CoHanhLy.Checked = true;
                        return true;
                    case Keys.Alt | Keys.D:
                        if (chkGQ_KHDongY.Checked)
                            chkGQ_KHDongY.Checked = false;
                        else
                            chkGQ_KHDongY.Checked = true;
                        return true;
                    case Keys.Alt | Keys.Q:
                        if (chkDaGiaiQuyet.Checked)
                            chkDaGiaiQuyet.Checked = false;
                        else
                            chkDaGiaiQuyet.Checked = true;
                        return true;
                    default:
                        break;
                }
            }
            #endregion-------------------------------------------------------------------

            return base.ProcessCmdKey(ref msg, keyData);
        }        

        private void txtSoDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtTenKH.Focus();
            }
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    txtSoDT.Focus();
                    break;
                case Keys.Down:
                case Keys.Enter:
                    txtDiaChi.Focus();
                    break;
            }
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    txtTenKH.Focus();
                    break;
                case Keys.Down:
                case Keys.Enter:
                    setLoaiPA_Focus(getLoaiPA());
                    break;
            }
        }

        private void rbLPA_Khen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTGPS_Gio.Focus();
            }
        }

        private void rbLPA_PhanNan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTGPS_Gio.Focus();
            }
        }

        private void rbLPA_KhieuNai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTGPS_Gio.Focus();
            }
        }

        private void rbLPA_QuenHanhLy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLoTrinh_Tu.Focus();
            }
        }

        private void txtLoTrinh_Tu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    rbLPA_QuenHanhLy.Focus();
                    break;
                case Keys.Down:
                case Keys.Enter:
                    txtLoTrinh_Den.Focus();
                    break;
            }
        }

        private void txtLoTrinh_Den_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    txtLoTrinh_Tu.Focus();
                    break;
                case Keys.Down:
                case Keys.Enter:
                    txtLoTrinh_DHT.Focus();
                    break;
            }
        }

        private void txtLoTrinh_DHT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTGPS_Gio.Focus();
            }
        }

        private void txtTGPS_Gio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    setLoaiPA_Focus(getLoaiPA());
                    break;
                case Keys.Down:
                case Keys.Enter:
                    dateTGPS_Ngay.Focus();
                    break;
            }
        }

        private void dateTGPS_Ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtTGPS_Gio.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtNoiDung.Focus();
            }
        }

        private void txtNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                dateTGPS_Ngay.Focus();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                setDacDiemKH_Focus(getDacDiemKH());
            }
        }

        private void rbDDKH_VangLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbDTPA_ConNguoi.Focus();
            }
        }

        private void rbDDKH_GoiDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbDTPA_ConNguoi.Focus();
            }
        }

        private void rbDDKH_TiepThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbDTPA_ConNguoi.Focus();
            }
        }

        private void rbDTPA_ConNguoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkDaGiaiQuyet.Focus();
            }
        }

        private void rbDTPA_PhuongTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkDaGiaiQuyet.Focus();
            }
        }

        private void txtGQ_TGGQ_Gio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                dateGQ_TGGQ_Ngay.Focus();
            }
        }

        private void dateGQ_TGGQ_Ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtGQ_TGGQ_Gio.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                chkGQ_KHDongY.Focus();
            }
        }

        private void chkGQ_KHDongY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGQ_KHDongY.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtGQ_KQ.Focus();
            }
        }

        private void txtGQ_KQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                txtGQ_KQ.Focus();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                txtGQ_YKKH.Focus();
            }
        }

        private void txtGQ_YKKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                txtGQ_KQ.Focus();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                txtGQ_GhiChu.Focus();
            }
        }

        private void txtGQ_GhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                txtGQ_YKKH.Focus();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                txtGQ_SoTai.Focus();
            }
        }

        private void txtGQ_SoTai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtGQ_SoTai.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtGQ_TGGT_Gio.Focus();
            }
        }

        private void txtGQ_TGGT_Gio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtGQ_SoTai.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                dateGQ_TGGT_Ngay.Focus();
            }
        }

        private void dateGQ_TGGT_Ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtGQ_TGGT_Gio.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                chkGQ_CoHanhLy.Focus();
            }
        }

        private void chkGQ_CoHanhLy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                dateGQ_TGGT_Ngay.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                chkDaGiaiQuyet.Focus();
            }
        }

        private void chkDaGiaiQuyet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGQ_CoHanhLy.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }

        #endregion       
    }
}