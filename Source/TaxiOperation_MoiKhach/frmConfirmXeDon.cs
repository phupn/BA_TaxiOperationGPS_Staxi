using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmConfirmXeDon : Form
    {
        private readonly KieuCanhBaoKhiNhapThongTin G_KieuCanhBao;
        private int G_Result = 0;
        private string G_XeDonResult = string.Empty;
        private string G_Message = string.Empty;
        public int Result
        {
            get
            {
                return G_Result;
            }
        }

        public string XeDonResult
        {
            get
            {
                return G_XeDonResult;
            }
            set
            {
                G_XeDonResult = value ;
            }
        }
        public frmConfirmXeDon()
        {
            InitializeComponent();
        }

        public frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin KieuCanhBao, string Message)
        {
            InitializeComponent();
            G_KieuCanhBao = KieuCanhBao;
            G_Message = Message;
            LoadFormByKieuCanhBao();
        }

        public frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin KieuCanhBao, string Message, string xeDon)
        {
            InitializeComponent();
            G_KieuCanhBao = KieuCanhBao;
            G_Message = Message;
            LoadFormByKieuCanhBao();
            G_XeDonResult = xeDon;
        }

        private void LoadFormByKieuCanhBao()
        {
            switch (G_KieuCanhBao)
            {
                case KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon:
                    lblInfo.Text = "Chưa đủ số lượng xe đón !";
                    rbConfirmXeDon1.Text = "1.Vẫn tiếp tục điều xe đón";
                    rbConfirmXeDon2.Text = "2.Kết thúc điều xe";
                    break;
                case KieuCanhBaoKhiNhapThongTin.XeNhanQuaXa:
                    lblInfo.Text = G_Message;
                    rbConfirmXeDon1.Text = "1.Vẫn cho nhận đón khách";
                    rbConfirmXeDon2.Text = "2.Không cho nhận";
                    break;
                case KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan:
                    rbConfirmXeDon2.Location = new System.Drawing.Point(176, 41);
                    rbConfirmXeDon3.Visible = true;
                    
                    lblInfo.Text = G_Message;
                    rbConfirmXeDon1.Text = "1.Không xác định";
                    rbConfirmXeDon2.Text = "2.Lái xe không báo";
                    break;
                case KieuCanhBaoKhiNhapThongTin.TrungXeDon:
                    lblInfo.Text = G_Message;
                    rbConfirmXeDon1.Text = "1.Vẫn cho đón khách";
                    rbConfirmXeDon2.Text = "2.Không cho nhận";
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F4:
                    return true;
                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData == Keys.D1 || keyData == Keys.NumPad1) && txtXeDon.Focused == false)
            {
                rbConfirmXeDon1.Checked = true;
                return true;
            }
            if ((keyData == Keys.D2 || keyData == Keys.NumPad2) && txtXeDon.Focused == false)
            {
                rbConfirmXeDon2.Checked = true;
                return true;
            }
            if ((keyData == Keys.D3 || keyData == Keys.NumPad3) && (G_KieuCanhBao == KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan) && txtXeDon.Focused == false)
            {
                rbConfirmXeDon3.Checked = true;
                return true;
            }
            return false;
        }

        private void rbConfirmXeDon1_CheckedChanged(object sender, EventArgs e)
        {
            G_Result = 1;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void rbConfirmXeDon2_CheckedChanged(object sender, EventArgs e)
        {
            G_Result = 2;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void rbConfirmXeDon3_CheckedChanged(object sender, EventArgs e)
        {
            G_Result = 3;
            txtXeDon.Text = G_XeDonResult;
            txtXeDon.Visible = true;
            lblXeDon.Visible = true;
            txtXeDon.Select();
        }

        private void txtXeDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                G_XeDonResult = txtXeDon.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
