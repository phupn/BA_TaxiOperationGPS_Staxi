using System;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI.CheckCoDuongDai
{
    public partial class frmXeBaoDiSanBay_DuongDai_Mini : Form
    {

        private bool g_boolValidate = false;

        private DateTime G_TimeServer;
        public frmXeBaoDiSanBay_DuongDai_Mini()
        {
            InitializeComponent();
        }

        private void frmXeBaoDiSanBay_DuongDai_Mini_Load(object sender, EventArgs e)
        {
            G_TimeServer = DieuHanhTaxi.GetTimeServer();
            if (G_TimeServer != DateTime.MinValue)
            {
                editThoiDiemBao.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", G_TimeServer);
                editThoiDiemBao.ReadOnly = true;
            }
            editSoHieuXe.Focus();
            Xe objXe = new Xe();
            editViTriBao.Text = objXe.GetChiTietXe(editSoHieuXe.Text).GaraName;
            if (StringTools.TrimSpace(editViTriBao.Text).Length <= 0) editViTriBao.Text = "Gara";
        }

        private void Save()
        {
            KiemSoatXeLienLac objKSXeLL = new KiemSoatXeLienLac();

            objKSXeLL.SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);
            objKSXeLL.ThoiDiemBao = G_TimeServer;
            objKSXeLL.ViTriDiemBao = StringTools.TrimSpace(editViTriBao.Text);
            objKSXeLL.MaLaiXe = "";

            objKSXeLL.IsHoatDong = true;
            objKSXeLL.ViTriDiemBao = StringTools.TrimSpace(txtViTriBao1.Text);            
            objKSXeLL.TrangThaiLaiXeBao = KieuLaiXeBao.BaoDiemDo;
            objKSXeLL.LoaiChoKhach = LoaiChoKhach.ChoKhachNoiTinh;
            if (chkDuongDai.Checked) objKSXeLL.LoaiChoKhach = LoaiChoKhach.ChoKhachDuongDai;
            else if (chkSanBay.Checked) objKSXeLL.LoaiChoKhach = LoaiChoKhach.ChoKhachSanBay;

            objKSXeLL.ViTriDiemDen = StringTools.TrimSpace(editViTriBao.Text);

            objKSXeLL.GhiChu = "";

            if (!objKSXeLL.InsertUpdate())
            {
                lblMessage.Text = "Lỗi lưu thông tin.Bạn cần liên hệ với quản trị hệ thống."; lblMessage.Visible = true;
                return;
            }
            else lblMessage.Text = "";

            if (!KiemSoatXeLienLac.InsertUpdateXeDangHoatDong(objKSXeLL.SoHieuXe, objKSXeLL.ThoiDiemBao, objKSXeLL.IsHoatDong))
            {
                lblMessage.Text = "Lỗi lưu thông tin xe hoạt động.Bạn cần liên hệ với quản trị hệ thống."; lblMessage.Visible = true;
                return;
            }
            else lblMessage.Text = "";

            lblMessage.Text = "Lưu thông tin thành công.";
        }

        private void ResetForm()
        {
            G_TimeServer = DieuHanhTaxi.GetTimeServer();
            if (G_TimeServer != DateTime.MinValue)
            {
                editThoiDiemBao.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", G_TimeServer);

            }
            lblMessage.Text = "";
            editSoHieuXe.Text = "";
            editViTriBao.Text = "";
            txtViTriBao1.Text = "";
            chkDuongDai.Checked = false;
            chkSanBay.Checked = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!g_boolValidate)
            {
                lblMessage.Text = "Thông tin số hiệu xe không phù hợp."; return;
            }

            if (StringTools.TrimSpace(txtViTriBao1.Text).Length <= 0 || StringTools.TrimSpace(editViTriBao.TextBox.Text).Length <= 0)
            {
                lblMessage.Text = "Bạn phải nhập thông tin điểm nhận, điểm đón."; return;
            }

            Save();
            ResetForm();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    {
                        Close();
                        break;
                    }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void editSoHieuXe_TextChanged(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);
            if (SoHieuXe.Length <= 0) return;

            if (!Xe.KiemTraTonTaiCuaSoHieuXe(SoHieuXe))
            {
                g_boolValidate = false;

                errorProvider.SetError(editSoHieuXe, "Số hiệu xe này không tồn tại");
                return;
            }
            g_boolValidate = true;
            errorProvider.SetError(editSoHieuXe, "");

        }

        private void editSoHieuXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                chkSanBay.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                btnSave.Focus();
            }
        }

        private void txtViTriBao1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                editViTriBao.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                chkDuongDai.Focus();
            }
        }

        private void editViTriBao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {                
                btnSave.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtViTriBao1.Focus();
            }
        }

        private void chkDuongDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtViTriBao1.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                chkSanBay.Focus();
            }
        }

        private void chkSanBay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                chkDuongDai.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                editSoHieuXe.Focus();
            }
        }

        private void chkSanBay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSanBay.Checked) { chkDuongDai.Checked = false; editViTriBao.Text = "Sân bay"; };
        }

        private void chkDuongDai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuongDai.Checked) { chkSanBay.Checked = false; editViTriBao.Text = ""; }
        }
    }
}
