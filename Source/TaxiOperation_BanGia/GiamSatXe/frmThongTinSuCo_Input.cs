using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using EFiling.Utils;

namespace TaxiOperation_TongDai.GiamSatXe
{
    public partial class frmThongTinSuCo_Input : Form
    {
        private KieuBaoSuCo G_KieuBao;
        private KiemSoatXeLienLac G_KiemSoatLienLac = new KiemSoatXeLienLac();
        public frmThongTinSuCo_Input()
        {
            InitializeComponent();
        }

        public frmThongTinSuCo_Input(KieuBaoSuCo kieuBao)
        {
            InitializeComponent();
            G_KieuBao = kieuBao;
        }

        public frmThongTinSuCo_Input(KiemSoatXeLienLac kiemSoatLienLac)
        {
            InitializeComponent();
            G_KiemSoatLienLac = kiemSoatLienLac;
        }

        private void frmThongTinSuCo_Input_Load(object sender, EventArgs e)
        {
            string strDateTime = DieuHanhTaxi.GetTimeServer().ToString("HH:mm:ss dd/MM/yyyy", new System.Globalization.CultureInfo("vi-VN", false));
            Xe_lblThoiGian.Text = strDateTime;
            The_lblThoiGian.Text = strDateTime;
            if (G_KiemSoatLienLac != null && G_KiemSoatLienLac.SoHieuXe != null && G_KiemSoatLienLac.SoHieuXe != "")
                SetData(G_KiemSoatLienLac);
        }
                
        private void GetData(KieuBaoSuCo kieuBao)
        {
            G_KiemSoatLienLac.TrangThaiLaiXeBao = KieuLaiXeBao.BaoHong;
            G_KiemSoatLienLac.CreatedBy = ThongTinDangNhap.USER_ID;
            G_KiemSoatLienLac.UpdatedBy = ThongTinDangNhap.USER_ID;
            if (kieuBao == KieuBaoSuCo.XeGapSuCo)
            {
                G_KiemSoatLienLac.ThoiDiemBao = Convert.ToDateTime(Xe_lblThoiGian.Text.Trim(), new System.Globalization.CultureInfo("vi-VN", false));
                G_KiemSoatLienLac.SoHieuXe = Xe_txtSoXe.Text.Trim();
                G_KiemSoatLienLac.ViTriDiemBao = Xe_txtDiaDiem.Text.Trim();
                G_KiemSoatLienLac.GhiChu = Xe_txtGhiChu.Text.Trim();
                G_KiemSoatLienLac.KetQuaXuLy = Xe_txtKetQuaXuLy.Text.Trim();
                G_KiemSoatLienLac.IsHoatDong = false;                
            }
            else if (kieuBao == KieuBaoSuCo.VeThe)
            {
                G_KiemSoatLienLac.ThoiDiemBao = Convert.ToDateTime(The_lblThoiGian.Text.Trim(), new System.Globalization.CultureInfo("vi-VN", false));
                G_KiemSoatLienLac.SoHieuXe = The_txtSoXe.Text.Trim();
                G_KiemSoatLienLac.GhiChu = The_txtGhiChu.Text.Trim();
                G_KiemSoatLienLac.KetQuaXuLy = The_txtKetQua.Text.Trim();
                G_KiemSoatLienLac.NoiDungSuCo = The_txtNoiDung.Text.Trim();
                G_KiemSoatLienLac.ViTriDiemBao = "";
                G_KiemSoatLienLac.IsHoatDong = false;
            }
        }

        /// <summary>
        /// set data to form
        /// </summary>
        /// <param name="kiemSoatLienLac"></param>
        private void SetData(KiemSoatXeLienLac kiemSoatLienLac)
        {
            
            if (kiemSoatLienLac.TrangThaiLaiXeBao == KieuLaiXeBao.BaoHong
                && (kiemSoatLienLac.ViTriDiemBao != null && kiemSoatLienLac.ViTriDiemBao != ""))
            {
                G_KieuBao = KieuBaoSuCo.XeGapSuCo;
                tabSuCoInput.SelectedTab = tab_Xe;
                Xe_txtDiaDiem.Text = kiemSoatLienLac.ViTriDiemBao;
                Xe_lblThoiGian.Text = kiemSoatLienLac.ThoiDiemBao.ToString("HH:mm:ss dd/MM/yyyy", new System.Globalization.CultureInfo("vi-VN", false));
                Xe_txtGhiChu.Text = kiemSoatLienLac.GhiChu;
                Xe_txtKetQuaXuLy.Text = kiemSoatLienLac.KetQuaXuLy;
                Xe_txtSoXe.Text = kiemSoatLienLac.SoHieuXe;

                SetNoiDungSuCo(kiemSoatLienLac.NoiDungSuCo); 
            }
            else
            {
                G_KieuBao = KieuBaoSuCo.VeThe;
                tabSuCoInput.SelectedTab = tab_The;
                The_lblThoiGian.Text = kiemSoatLienLac.ThoiDiemBao.ToString("HH:mm:ss dd/MM/yyyy", new System.Globalization.CultureInfo("vi-VN", false));
                The_txtGhiChu.Text = kiemSoatLienLac.GhiChu;
                The_txtKetQua.Text = kiemSoatLienLac.KetQuaXuLy;
                The_txtNoiDung.Text = kiemSoatLienLac.NoiDungSuCo;
                The_txtSoXe.Text = kiemSoatLienLac.SoHieuXe;
            }
        }

        /// <summary>
        /// NoiDungSuCo : 1;2;3;4
        /// </summary>
        /// <returns></returns>
        private string GetNoiDungSuCo()
        {
            string noiDungSuCo = "";
            if (Xe_chkDongHo.Checked)
            {
                noiDungSuCo = noiDungSuCo + "1;";
            }
            if (Xe_chkVaChamXeMay.Checked)
            {
                noiDungSuCo = noiDungSuCo + "2;";
            }
            if (Xe_chkHetDien.Checked)
            {
                noiDungSuCo = noiDungSuCo + "3;";
            }
            if (Xe_chkChayDen.Checked)
            {
                noiDungSuCo = noiDungSuCo + "4;";
            }
            if (Xe_chkVaChamVatTinh.Checked)
            {
                noiDungSuCo = noiDungSuCo + "5;";
            }
            if (Xe_chkVaChamOTo.Checked)
            {
                noiDungSuCo = noiDungSuCo + "6;";
            }
            if (Xe_chkAcQuy.Checked)
            {
                noiDungSuCo = noiDungSuCo + "7;";
            }
            if (Xe_chkHongLop.Checked)
            {
                noiDungSuCo = noiDungSuCo + "8;";
            }
            if (Xe_chkVoKinh.Checked)
            {
                noiDungSuCo = noiDungSuCo + "9;";
            }
            if (Xe_chkKhac.Checked)
            {
                noiDungSuCo = noiDungSuCo + "0;";
            }

            if (!string.IsNullOrEmpty(noiDungSuCo))
            {//bỏ dấu ; cuối
                noiDungSuCo = noiDungSuCo.Substring(0,noiDungSuCo.Length-1);
            }
            return noiDungSuCo;
        }
        
        /// <summary>
        /// checked nội dung sự cố nếu có
        /// </summary>
        /// <param name="noiDungSuCo"></param>
        private void SetNoiDungSuCo(string noiDungSuCo)
        {
            if (noiDungSuCo == null) return;
            string[] arrNoiDungSuCo = noiDungSuCo.Split(';');
            if (arrNoiDungSuCo.Length > 0)
            {
                foreach (string item in arrNoiDungSuCo)
                {
                    if (item == "1")
                    {
                        Xe_chkDongHo.Checked = true;
                    }
                    else if (item == "2")
                    {
                        Xe_chkVaChamXeMay.Checked = true;
                    }
                    else if (item == "3")
                    {
                        Xe_chkHetDien.Checked = true;
                    }
                    else if (item == "4")
                    {
                        Xe_chkChayDen.Checked = true;
                    }
                    else if (item == "5")
                    {
                        Xe_chkVaChamVatTinh.Checked = true;
                    }
                    else if (item == "6")
                    {
                        Xe_chkVaChamOTo.Checked = true;
                    }
                    else if (item == "7")
                    {
                        Xe_chkAcQuy.Checked = true;
                    }
                    else if (item == "8")
                    {
                        Xe_chkHongLop.Checked = true;
                    }
                    else if (item == "9")
                    {
                        Xe_chkVoKinh.Checked = true;
                    }
                    else if (noiDungSuCo == "0")
                    {
                        Xe_chkKhac.Checked = true;
                    }
                }
            }
        }

        private bool ValidateForm(KieuBaoSuCo kieuBao)
        {
            if (kieuBao == KieuBaoSuCo.XeGapSuCo)
            {
                G_KiemSoatLienLac.NoiDungSuCo = GetNoiDungSuCo();
                if (string.IsNullOrEmpty(G_KiemSoatLienLac.NoiDungSuCo))
                {
                    lblMsg.Text = "Vui lòng chọn nội dung sự cố";
                    lblMsg.Visible = true;
                    return false;
                }
                else if (string.IsNullOrEmpty(Xe_txtSoXe.Text.Trim()))
                {
                    Xe_txtSoXe.Focus();
                    lblMsg.Text = "Vui lòng nhập số xe";
                    lblMsg.Visible = true;
                    return false;
                }
                else if (string.IsNullOrEmpty(Xe_txtDiaDiem.Text.Trim()))
                {
                    Xe_txtDiaDiem.Focus();
                    lblMsg.Text = "Vui lòng nhập địa điểm";
                    lblMsg.Visible = true;
                    return false;
                }
                else
                    return true;
            }
            else
            {
                if (string.IsNullOrEmpty(The_txtSoXe.Text.Trim()))
                {
                    The_txtSoXe.Focus();
                    lblMsg.Text = "Vui lòng nhập số xe";
                    lblMsg.Visible = true;
                    return false;
                }
                else if (string.IsNullOrEmpty(The_txtNoiDung.Text.Trim()))
                {
                    The_txtNoiDung.Focus();
                    lblMsg.Text = "Vui lòng nhập nội dung";
                    lblMsg.Visible = true;
                    return false;
                }
                else
                    return true;
            }
        }

        private void RefreshForm()
        {
            if (G_KieuBao == KieuBaoSuCo.VeThe)
            {
                The_lblThoiGian.Text = DieuHanhTaxi.GetTimeServer().ToString("HH:mm:ss dd/MM/yyyy");
                The_txtGhiChu.Text = "";
                The_txtKetQua.Text = "";
                The_txtSoXe.Text = "";
            }
            else
            {
                Xe_txtDiaDiem.Text = "";
                Xe_lblThoiGian.Text = DieuHanhTaxi.GetTimeServer().ToString("HH:mm:ss dd/MM/yyyy");
                Xe_txtGhiChu.Text = "";
                Xe_txtKetQuaXuLy.Text = "";
                Xe_txtSoXe.Text = "";
            }
        }

        private void Xe_txtSoXe_TextChanged(object sender, EventArgs e)
        {

        }

        private void tab_Xe_Click(object sender, EventArgs e)
        {

        }

        private void The_btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateForm(KieuBaoSuCo.VeThe))
            {
                GetData(KieuBaoSuCo.VeThe);
                if (!G_KiemSoatLienLac.Insert_Update_V3())
                {
                    lblMsg.Text = "Lỗi lưu thông tin.Bạn cần liên hệ với quản trị hệ thống.";
                    lblMsg.Visible = true;
                    return;
                }
                else
                {
                    if (!KiemSoatXeLienLac.InsertUpdateXeDangHoatDong(G_KiemSoatLienLac.SoHieuXe, G_KiemSoatLienLac.ThoiDiemBao, G_KiemSoatLienLac.IsHoatDong))
                    {
                        lblMsg.Text = "Lỗi lưu thông tin xe hoạt động.Bạn cần liên hệ với quản trị hệ thống.";
                        lblMsg.Visible = true;
                        return;
                    }
                    else lblMsg.Text = "";
                    RefreshForm();
                    MessageBox.Show("Lưu thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }            
        }

        private void The_btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Xe_btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateForm(KieuBaoSuCo.XeGapSuCo))
            {
                GetData(KieuBaoSuCo.XeGapSuCo);
                if (!G_KiemSoatLienLac.Insert_Update_V3())
                {
                    lblMsg.Text = "Lỗi lưu thông tin.Bạn cần liên hệ với quản trị hệ thống.";
                    lblMsg.Visible = true;
                    return;
                }
                else
                {
                    if (!KiemSoatXeLienLac.InsertUpdateXeDangHoatDong(G_KiemSoatLienLac.SoHieuXe, G_KiemSoatLienLac.ThoiDiemBao, G_KiemSoatLienLac.IsHoatDong))
                    {
                        lblMsg.Text = "Lỗi lưu thông tin xe hoạt động.Bạn cần liên hệ với quản trị hệ thống.";
                        lblMsg.Visible = true;
                        return;
                    }
                    else lblMsg.Text = "";
                    RefreshForm();
                    MessageBox.Show("Lưu thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.D1:
                    {
                        tabSuCoInput.SelectedTab = tab_Xe;
                        break;
                    }
                case Keys.Control | Keys.D2:
                    {
                        tabSuCoInput.SelectedTab = tab_The;
                        break;
                    }
                case Keys.Escape:
                    {
                        Close();
                        break;
                    }
                case Keys.Alt | Keys.E:
                    {
                        if (tabSuCoInput.SelectedTab == tab_Xe)
                            Xe_txtSoXe.Focus();
                        else
                            The_txtSoXe.Focus();
                        break;
                    }
                case Keys.Alt | Keys.D:
                    {
                        if (tabSuCoInput.SelectedTab == tab_Xe)
                            Xe_txtDiaDiem.Focus();
                        break;
                    }
                case Keys.Alt | Keys.N:
                    {
                        if (tabSuCoInput.SelectedTab == tab_The)
                            The_txtNoiDung.Focus();
                        break;
                    }
                case Keys.Alt | Keys.G:
                    {
                        if (tabSuCoInput.SelectedTab == tab_Xe)
                            Xe_txtGhiChu.Focus();
                        else
                            The_txtGhiChu.Focus();
                        break;
                    }
                case Keys.Alt | Keys.Q:
                    {
                        if (tabSuCoInput.SelectedTab == tab_Xe)
                            Xe_txtKetQuaXuLy.Focus();
                        else
                            The_txtKetQua.Focus();
                        break;
                    }
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
