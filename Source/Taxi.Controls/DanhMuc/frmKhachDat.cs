using System;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Femiani.Forms.UI.Input;
using Taxi.Business.KhachDat;
using System.Drawing;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Data.FastTaxi;

namespace Taxi.Controls.DanhMuc
{
    public partial class frmKhachDat : FormRibbon
    {
        #region ===========================Initialize==================================
        private bool g_IsUpdate = false;                                    // Trạng thái xử lý trên form. (g_IsUpdate = false : Trạng thái thêm mới).
        private long g_IDCuocGoi = 0;
        private int  g_IDKhachDat = 0;
        private AutoCompleteEntryCollection g_ListDataAutoComplete;         
        private KhachDatEntity g_objKhachDat = new KhachDatEntity();


        public frmKhachDat(KhachDatBL KhachDat, AutoCompleteEntryCollection listDataAutoComplete, bool isUpdate)
        {
            InitializeComponent();
            g_IsUpdate = isUpdate;
            g_objKhachDat = KhachDat.ParseToEntity();
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
            FillDefaultDataToForm();
            SetDataInput();
        }

        private void FillDefaultDataToForm()
        {
            txtDiaChi.Items = g_ListDataAutoComplete;            
            chk4Cho.Checked = true;
            txtTenKH.Text = "KH";
            txtDiaChi.Text = string.Empty;
            txtDiaChi.Focus();
        }

        #endregion

        #region ===========================Validate====================================
        private bool IsValid()
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
            if (txtSoLuong.Text.Trim() == String.Empty || Convert.ToInt16(txtSoLuong.EditValue) <= 0)
            {
                lblMsg.Text = "Vui lòng nhập Số lượng xe";
                txtSoLuong.Focus();
                return false;
            }
            if (rbLapLai.Checked&&calNgayBatDau.DateTime > DateTime.MinValue && calNgayKetThuc.DateTime > DateTime.MinValue &&
                calNgayBatDau.DateTime.Date > calNgayKetThuc.DateTime.Date)
            {
                lblMsg.Text = "Vui lòng nhập ngày bắt đầu nhỏ hơn hoặc bằng ngày kết thúc";
                calNgayBatDau.Focus();
                return false;                
            }

            if (calNgayBatDau.DateTime.Date < CommonBL.GetTimeServer().Date &&!rbLapLai.Checked)
            {
                lblMsg.Text = "Ngày bắt đầu không được nhỏ hơn thời điểm tiếp nhận!";
                calNgayBatDau.Focus();
                return false;
            }

            if (calGioDon.DateTime.TimeOfDay < CommonBL.GetTimeServer().TimeOfDay && calNgayBatDau.DateTime.Date == CommonBL.GetTimeServer().Date && !rbLapLai.Checked)
            {
                lblMsg.Text = "Giờ đón không được nhỏ hơn thời điểm tiếp nhận";
                calGioDon.Focus();
                return false;
            }

            double giaTien ;
            if (!double.TryParse(txtGiaTien.Text.Trim(), out giaTien))
            {
                lblMsg.Text = "Giá tiền không hợp lệ";
                txtGiaTien.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region ======================Form Status======================================

        /// <summary>
        /// Get data on the form (Adding / Updating)
        /// </summary>
        /// <returns>false : không lấy được ID cuộc gọi</returns>
        private bool GetDataInsert()
        {
            try
            {
                if (g_IDCuocGoi < 0)
                {
                    lblMsg.Text = "Vui lòng chọn cuộc gọi cần đặt xe";
                    lblMsg.ForeColor = Color.Red;
                    return false;
                }
                g_objKhachDat.ThoiDiemTiepNhan = DieuHanhTaxi.GetTimeServer();
                g_objKhachDat.FK_CuocGoiID = g_IDCuocGoi;
                g_objKhachDat.TenKhachHang = txtTenKH.Text.Trim();
                g_objKhachDat.DiaChiDon = txtDiaChi.Text.Trim();

                g_objKhachDat.SoDienThoai = txtDienThoai.Text.Trim();
                g_objKhachDat.VungKenh = Convert.ToInt16(txtKenh.Value);
                g_objKhachDat.TenLoaiXe = GetThongTinLoaiXeChon();
                g_objKhachDat.LoaiXe = ipLoaiXe.EditValue.ToString();
                g_objKhachDat.SoLuongXe = Convert.ToInt16(txtSoLuong.EditValue);
                if (rbLapLai.Checked)
                {
                    g_objKhachDat.IsLapLai = true;
                    g_objKhachDat.ThoiDiemKetThuc = calNgayKetThuc.DateTime;
                    g_objKhachDat.NgayTrongTuanLapLai = getNgayTrongTuan();
                }
                else
                {
                    g_objKhachDat.IsLapLai = false;
                    g_objKhachDat.ThoiDiemKetThuc = calNgayBatDau.DateTime.Date.AddDays(1).AddSeconds(-1);
                    g_objKhachDat.NgayTrongTuanLapLai = "";
                }
                double giatien = 0.0;
                double.TryParse(txtGiaTien.Text, out giatien);
                g_objKhachDat.SoTien = giatien;
                g_objKhachDat.GioDon = calGioDon.DateTime;
                g_objKhachDat.ThoiDiemBatDau = calNgayBatDau.DateTime;
                g_objKhachDat.SoPhutBaoTruoc = Convert.ToInt16(cbSoPhut.Value);
                g_objKhachDat.CreatedBy = ThongTinDangNhap.USER_ID;
                g_objKhachDat.CreatedDate = CommonBL.GetTimeServer();
                g_objKhachDat.UpdatedDate = CommonBL.GetTimeServer();
                g_objKhachDat.GhiChu = txtGhiChu.Text.Trim();
                return true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDataInsert: ", ex);
                return false;
            }
        }

        private string GetThongTinLoaiXeChon()
        {
            string carType = ipLoaiXe.EditValue.ToString();
            string loaiXe = CommonBL.ListStaxiLoaiXe.FirstOrDefault(a => a.StaxiType.ToString() == carType).Name + " - " +txtLoaiXe.Text;
            return loaiXe;
        }

        private void SetThongTinLoaiXe2(string loaiXe)
        {
            if (!string.IsNullOrEmpty(loaiXe) && loaiXe != "0")
            {
                StaxiCarType temp = CommonBL.ListStaxiLoaiXe.FirstOrDefault(a => a.StaxiType.ToString() == loaiXe);
                if (temp.Seat == 4)
                    chk4Cho.Checked = true;
                else if (temp.Seat == 7)
                    chk7Cho.Checked = true;
            }
            else
            {
                chk4Cho.Checked = false;
                chk7Cho.Checked = false;
            }
        }

        /// <summary>
        /// Set data on the form!
        /// </summary>
        private void SetDataInput()
        {
            g_IDKhachDat = g_objKhachDat.PK_KhachDatID;
            if (g_objKhachDat.TenKhachHang == "")
                txtTenKH.Text = g_objKhachDat.DiaChiDon;
            else
                txtTenKH.Text = g_objKhachDat.TenKhachHang;
            txtDiaChi.Text = g_objKhachDat.DiaChiDon;            
            txtDienThoai.Text = g_objKhachDat.SoDienThoai;
            txtKenh.Value = g_objKhachDat.VungKenh;
            rbLapLai.Checked = g_objKhachDat.IsLapLai;
            rbMotLan.Checked = !g_objKhachDat.IsLapLai;        
            setNgayTrongTuan(g_objKhachDat.NgayTrongTuanLapLai);
            if (g_objKhachDat.GioDon.Year > 2000)
                calGioDon.EditValue = g_objKhachDat.GioDon;
            else calGioDon.EditValue = CommonBL.GetTimeServer().Date.AddMinutes(10);

            if (g_objKhachDat.ThoiDiemTiepNhan.Year > 2000)
                lblTGTiepNhan.Text = string.Format("{0:HH:mm dd/MM/yyyy}", g_objKhachDat.ThoiDiemTiepNhan);
            else
                lblTGTiepNhan.Text = string.Format("{0:HH:mm dd/MM/yyyy}", CommonBL.GetTimeServer());

            if (g_objKhachDat.ThoiDiemKetThuc.Year > 2000)
                calNgayKetThuc.EditValue = g_objKhachDat.ThoiDiemKetThuc;
            else calNgayKetThuc.EditValue = CommonBL.GetTimeServer();

            if (g_objKhachDat.ThoiDiemBatDau.Year > 2000)
                calNgayBatDau.EditValue = g_objKhachDat.ThoiDiemBatDau;
            else calNgayBatDau.EditValue = CommonBL.GetTimeServer();

            cbSoPhut.Value = g_objKhachDat.SoPhutBaoTruoc;
            txtGhiChu.Text = g_objKhachDat.GhiChu;
            txtSoLuong.Text = g_objKhachDat.SoLuongXe.ToString();
            txtGiaTien.Text = g_objKhachDat.SoTien.ToString();
            SetThongTinLoaiXe2(g_objKhachDat.LoaiXe);
        }

        /// <summary>
        /// Get Ngày trong tuần lặp lại
        /// </summary>
        /// <returns>2;3;4;5;6;7;1</returns>
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
                strNgayTrongTuanLapLai += "1;";

            if (strNgayTrongTuanLapLai == "")
                return "";

            return strNgayTrongTuanLapLai.Substring(0, strNgayTrongTuanLapLai.Length - 1);
        }

        /// <summary>
        /// set Ngày trong tuần lặp lại
        /// </summary>
        private void setNgayTrongTuan(string strNgayTrongTuanLapLai)
        {
            ResetCheckBox();
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

        #endregion

        #region ===========================Form Event =================================
        private void rbMotLan_CheckedChanged(object sender, EventArgs e)
        {
            boxHangTuan.Enabled = false;
            calNgayKetThuc.Enabled = !rbMotLan.Checked;
            if (rbMotLan.Checked)
            {
                calNgayKetThuc.SetValue(calNgayBatDau.GetValue());
            }
        }

        private void rbLapLai_CheckedChanged(object sender, EventArgs e)
        {
            boxHangTuan.Enabled = true;
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
            if (!IsValid())
                return;

            if (g_IsUpdate)
            {
                if (g_IDKhachDat <= 0)
                    return;

                try
                {
                    g_objKhachDat.Update();
                    new MessageBox.MessageBoxBA().Show("Cập nhật thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch
                {
                    lblMsg.Text = "Cập nhật không thành công";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            else
            {
                if (GetDataInsert())// Lay dữ liệu + ktra xem có IDCuocGoi ko
                {
                    try
                    {
                        g_objKhachDat.Insert();
                        new MessageBox.MessageBoxBA().Show("Thêm mới thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch
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
                case Keys.Alt | Keys.V:
                    if (chk7Cho.Checked)
                        chk7Cho.Checked = false;
                    else
                        chk7Cho.Checked = true;
                    return true;
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
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

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

        private void RefreshLoaiXe()
        {
            var listXe = CommonBL.ListStaxiLoaiXe;
            //if (cbkSanBay.Checked)
            //    listXe = listXe.Where(p => p.Type == Utils.StaxiCarType_Type.AriPort).ToList();
            if (chk4Cho.Checked)
                listXe = listXe.Where(p => p.Seat == 4).ToList();
            else if (chk7Cho.Checked)
                listXe = listXe.Where(p => p.Seat == 7).ToList();
            //else if (chkXeHD.Checked)
            //    listXe = listXe.Where(p => p.Type == Utils.StaxiCarType_Type.Taxi && p.Seat == 7).ToList();
            ipLoaiXe.Properties.DataSource = listXe;
            ipLoaiXe.EditValue = null;
            ipLoaiXe.RefreshEditValue();
            ipLoaiXe.Refresh();
            if (ipLoaiXe.Properties.Items.Count > 0)
            {
                ipLoaiXe.Properties.Items[0].CheckState = CheckState.Checked;
                if (listXe.First().Type == Utils.StaxiCarType_Type.AriPort)
                    txtDiaChi.Text = "[SB]" + txtDiaChi.Text;
                else if (listXe.First().Type == Utils.StaxiCarType_Type.Car)
                    txtDiaChi.Text = "[Car]" + txtDiaChi.Text;
            }
            ipLoaiXe.Properties.DropDownRows = ipLoaiXe.Properties.Items.Count > ipLoaiXe.RowCount ? ipLoaiXe.RowCount : ipLoaiXe.Properties.Items.Count;
        }
        private void calNgayBatDau_EditValueChanged(object sender, EventArgs e)
        {
            if (rbMotLan.Checked)
            {
                calNgayKetThuc.SetValue(calNgayBatDau.GetValue());
            }
        }
        
        private bool ipLoaiXeChange = false;
        private void ipLoaiXe_EditValueChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange || ipLoaiXe.IsPopupOpen)
                return;
            ipLoaiXeChange = true;
            chk4Cho.Checked = false;
            chk7Cho.Checked = false;
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

                ipLoaiXe.EditValue = lx.StaxiType;
                ipLoaiXe.RefreshEditValue();
                ipLoaiXe.Refresh();
                ipLoaiXe.Properties.DropDownRows = ipLoaiXe.Properties.Items.Count > ipLoaiXe.RowCount ? ipLoaiXe.RowCount : ipLoaiXe.Properties.Items.Count;
            }
            else
            {
                RefreshLoaiXe();
            }
            ipLoaiXeChange = false;
        }

        private void chk4Cho_EditValueChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange) return;
            ipLoaiXeChange = true;
            if (chk4Cho.Checked) chk7Cho.Checked = false;
            RefreshLoaiXe();
            ipLoaiXeChange = false;
        }

        private void chk7Cho_CheckedChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange) return;
            ipLoaiXeChange = true;
            if (chk7Cho.Checked) chk4Cho.Checked = false;
            RefreshLoaiXe();
            ipLoaiXeChange = false;
        }

        public string GetKhachDat()
        {
            return string.Format("{0}-{1}-{2}", calGioDon.DateTime.ToShortTimeString(), txtTenKH.Text, txtDiaChi.Text);
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}