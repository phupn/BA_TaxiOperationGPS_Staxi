using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmInputXeNhan_Don : Form
    {
        private CuocGoi g_CuocGoi = new CuocGoi();
        private KieuNhapTrenGridTongDai g_KieuNhap;
        private List<string> g_listSoHieuXe;
        private string g_Return = string.Empty;
        private string g_Return_Chon = string.Empty;
        private bool g_IsThoatDuoc999;
        string StartValue = "";
        private List<string> G_ListXeNhan = new List<string>();
        private List<string> G_ListXeDenDiem = new List<string>();
        private bool g_CloseForm;
        private bool g_IsKetThuc;
        private string g_Return_TD = string.Empty;
        private int G_XeDonLength = 0;

        /// <summary>
        /// Get Value in Textbox
        /// </summary>
        /// <returns></returns>
        public string GetGiaTriNhap()
        {
            return g_Return;
        }

        /// <summary>
        /// Get Value Choiced
        /// </summary>
        public string GetGiaTriChon()
        {
            return g_Return_Chon;
        }
        
        public bool IsKetThuc()
        {
            return g_IsKetThuc;
        }

        /// <summary>
        /// chuỗi Tọa độ xe nhận
        /// </summary>
        public string GetGiaTriNhap_TD()
        {
            return g_Return_TD;
        }

        public frmInputXeNhan_Don()
        {
            InitializeComponent();
        }

        public frmInputXeNhan_Don(CuocGoi cuocGoi, KieuNhapTrenGridTongDai kieuNhap, List<string> listSoHieuXe, bool IsThoat999)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            g_CuocGoi = cuocGoi;
            g_listSoHieuXe = listSoHieuXe;
            g_IsThoatDuoc999 = IsThoat999;
        }

        public frmInputXeNhan_Don(CuocGoi cuocGoi, KieuNhapTrenGridTongDai kieuNhap, List<string> listSoHieuXe, bool IsThoat999, string value)
        {
            InitializeComponent();
            g_KieuNhap = kieuNhap;
            g_CuocGoi = cuocGoi;
            g_listSoHieuXe = listSoHieuXe;
            g_IsThoatDuoc999 = IsThoat999;
            StartValue = value;
        }

        private void frmInputXeNhan_Don_Load(object sender, EventArgs e)
        {
            SplitVehicle();
            HienThiControl();
        }

        /// <summary>
        /// Phân tích chuỗi xe nhận - đến điểm
        /// </summary>
        private void SplitVehicle()
        {
            //g_KieuNhap = KieuNhapTrenGridTongDai.NhapXeNhanDenDiem;
            //g_CuocGoi.XeDenDiem = "5689";
            //g_CuocGoi.XeNhan = "1234.5689.1414.5485.542.98";
            if (g_CuocGoi.XeNhan.Length <= 0) return;

            string[] arrXeNhan = g_CuocGoi.XeNhan.Split('.');
            string[] arrXeDenDiem = g_CuocGoi.XeDenDiem.Split('.');
            string[] arrXeDon = g_CuocGoi.XeDon.Split('.');
            if (arrXeNhan.Length > 0)
            {
                for (int i = 0; i < arrXeNhan.Length; i++ )
                {
                    G_ListXeNhan.Add(arrXeNhan[i]);
                    if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhanDenDiem)
                    {
                        Control[] arrControl_Label = Controls.Find("lbl_Xe" + (i+1), true);
                        if (arrControl_Label.Length > 0)
                        {
                            Label lbl = (Label)arrControl_Label[0];
                            lbl.Text = (i + 1) + ".";
                            lbl.Visible = true;
                        }
                        Control[] arrControl_CheckBox = Controls.Find("chk_Xe" + (i + 1), true);
                        if (arrControl_CheckBox.Length > 0)
                        {
                            CheckBox chk = (CheckBox)arrControl_CheckBox[0];
                            //Nếu chỉ có 1 xe nhận thì check luôn
                            //chk.Checked = arrXeNhan.Length == 1;

                            chk.Visible = true;
                            chk.Text = arrXeNhan[i];
                            if (g_CuocGoi.XeDenDiem.Length > 0 && Array.IndexOf(arrXeDenDiem, arrXeNhan[i]) >= 0)
                            {
                                chk.Checked = true;
                            }
                        }
                    }
                }
            }

            if (arrXeDenDiem.Length > 0)
            {
                for (int i = 0; i < arrXeDenDiem.Length; i++)
                {
                    G_ListXeDenDiem.Add(arrXeDenDiem[i]);

                    if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon)
                    {
                        Control[] arrControl_Label = Controls.Find("lbl_Xe" + (i + 1), true);
                        if (arrControl_Label.Length > 0)
                        {
                            Label lbl = (Label)arrControl_Label[0];
                            lbl.Text = (i + 1) + ".";
                            lbl.Visible = true;
                        }
                        Control[] arrControl_CheckBox = Controls.Find("chk_Xe" + (i + 1), true);
                        if (arrControl_CheckBox.Length > 0)
                        {
                            CheckBox chk = (CheckBox)arrControl_CheckBox[0];
                            //Nếu chỉ có 1 xe nhận thì check luôn
                            //chk.Checked = arrXeDenDiem.Length == 1;
                            chk.Visible = true;
                            chk.Text = arrXeDenDiem[i];
                            if (g_CuocGoi.XeDon.Length > 0 && Array.IndexOf(arrXeDon, arrXeDenDiem[i]) >= 0)
                            {
                                chk.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get danh sách xe đã chọn
        /// </summary>
        /// <returns></returns>
        private string GetXeChon()
        {
            string strValue = string.Empty;
            foreach (Control item in groupXeNhan.Controls)
            {
                if (item is CheckBox && ((CheckBox)item).Checked)
                {
                    strValue += item.Text + ".";
                }
            }
            //Cộng thêm xe nhập trong input
            strValue += g_Return;

            return strValue.TrimEnd('.');
        }

        /// <summary>
        /// hiển thị control
        /// </summary>
        private void HienThiControl()
        {
            if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon)
            {
                Text = "Nhập xe đón";
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhanDenDiem)
            {
                Text = "Nhập xe đến điểm";
            }
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeMK)
            {
                Text = "Nhập xe MK";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            g_CloseForm = true;
            string s = StringTools.TrimSpace(txtNhapXe.Text);

            #region XENHAN
            if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhan)
            {
                // Check xe nhận
                string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(s);
                g_Return = xeNhan;
                ValidateXeNhan(xeNhan, g_CuocGoi.XeDon);
            }
            #endregion XENHAN

            #region XEDON
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeDon)
            {
                // Kiểm tra xe đó có nằm trong xe nhận
                string xeDon = StringTools.ConvertToChuoiXeNhanChuan(s);
                g_Return = xeDon;
                g_Return_Chon = GetXeChon();

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
                        if (!StringTools.KiemTraXeNamTrongHeThong(xeDon, g_listSoHieuXe) && (!StringTools.KiemTraTrungLapXeChay(xeDon)))
                        {
                            new MessageBox.MessageBoxBA().Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Question);
                            g_CloseForm = false;
                            DialogResult = DialogResult.Cancel;
                            return;
                        }
                        string KenhVung_Trung = string.Empty;
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

                        if (G_XeDonLength < g_CuocGoi.SoLuong)
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
                        else
                        {
                            g_IsKetThuc = true;
                        }
                        //string XeNhan = g_CuocGoi.XeNhan;
                        //if (g_CuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                        //{
                        //if (!KiemTraXeDonThuocXeNhan(xeDon, XeNhan))
                        //{
                        //    string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", xeDon);
                        //    using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message,xeDon))
                        //    {
                        //        confirmXeDon.ShowDialog();
                        //        if (confirmXeDon.DialogResult == DialogResult.OK)
                        //        {
                        //            xeDon = confirmXeDon.XeDonResult;
                        //            if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                        //            {
                        //                new MessageBox.MessageBox().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //                return;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            g_IsKetThuc = false;
                        //            return;
                        //        }
                        //    }
                        //}
                    }
                }
                else g_IsKetThuc = true;
                g_Return = xeDon;
            }
            #endregion

            #region XENHANDENDIEM
            else if (g_KieuNhap == KieuNhapTrenGridTongDai.NhapXeNhanDenDiem)
            {
                if (!StringTools.KiemTraXeNamTrongHeThong(s, g_listSoHieuXe) && (!StringTools.KiemTraTrungLapXeChay(s)))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Vui lòng nhập chính xác xe đến điểm.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Question);
                    g_CloseForm = false;
                    DialogResult = DialogResult.Cancel;
                    return;
                }
                g_Return = s;
                g_Return_Chon = GetXeChon();
            }
            #endregion XENHAN

            g_CloseForm = true;
            DialogResult = DialogResult.OK;

            Close();
        }

        private void ValidateXeNhan(string XeNhan, string XeDon)
        {
            if (string.IsNullOrEmpty(XeNhan)) return;
            if (g_CuocGoi.XeNhan == XeNhan.TrimEnd('.')) return;

            string xeNhan_Filter = string.Empty;

            //Ktra xe nhận có nhập trùng hay không.
            if (StringTools.KiemTraTrungLapXeChay(XeNhan))
            {
                new MessageBox.MessageBoxBA().Show(this, "Nhập trùng xe nhận", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                g_CloseForm = false;
                DialogResult = DialogResult.Cancel;
            }
            //Ktra xe nhận đã báo đón hay chưa(nếu đã báo thì ko cho phép nhập).
            else if (!StringTools.KiemTraXeDonThuocXeNhan(xeNhan_Filter, XeDon))
            {
                new MessageBox.MessageBoxBA().Show(this, String.Format("Xe [{0}] đã báo đón khách", xeNhan_Filter), "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                g_CloseForm = false;
                DialogResult = DialogResult.Cancel;                
            }
        }

        #region checkbox checked changed
        private void chk_Xe1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_Xe2_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapXe.Focus();
        }

        private void chk_Xe3_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapXe.Focus();
        }

        private void chk_Xe4_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapXe.Focus();
        }

        private void chk_Xe5_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapXe.Focus();
        }

        private void chk_Xe6_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapXe.Focus();
        }

        private void chk_Xe7_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapXe.Focus();
        }

        private void chk_Xe8_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapXe.Focus();
        }
        #endregion

        #region XU LY HOTKEY

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            { 
                case Keys.F1:
                    if (chk_Xe1.Visible)
                        chk_Xe1.Checked = !chk_Xe1.Checked;
                    return true;

                case Keys.F2:
                    if (chk_Xe2.Visible)
                        chk_Xe2.Checked = !chk_Xe2.Checked;
                    return true;
                case Keys.F3:
                    if (chk_Xe3.Visible)
                        chk_Xe3.Checked = !chk_Xe3.Checked;
                    return true;
                case Keys.F4:
                    if (chk_Xe4.Visible)
                        chk_Xe4.Checked = !chk_Xe4.Checked;
                    return true;
                case Keys.F5:
                    if (chk_Xe5.Visible)
                        chk_Xe5.Checked = !chk_Xe5.Checked;
                    return true;
                case Keys.F6:
                    if (chk_Xe6.Visible)
                        chk_Xe6.Checked = !chk_Xe6.Checked;
                    return true;
                case Keys.F7:
                    if (chk_Xe6.Visible)
                        chk_Xe6.Checked = !chk_Xe6.Checked;
                    return true;
                case Keys.F8:
                    if (chk_Xe7.Visible)
                        chk_Xe7.Checked = !chk_Xe7.Checked;
                    return true;
                case Keys.Escape:
                    this.Close();
                    this.DialogResult = DialogResult.Cancel;
                    g_Return = string.Empty;
                    g_CloseForm = true;
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion XU LY HOTKEY
    }
}
