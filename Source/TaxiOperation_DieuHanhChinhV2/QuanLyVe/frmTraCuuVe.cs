using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanLyVe;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Controls.Base;

namespace Taxi.GUI
{
    public partial class frmTraCuu : FormBase
    {
        private int SeriVe = -1;

        public frmTraCuu()
        {
            InitializeComponent();
            radVe.Checked = true;
        }

        private void frmTraCuu_Load(object sender, EventArgs e)
        {

            cboCongTy.Focus();
            SetGiaTriMacDinh();
            LoadDSCongTy(0);
           
        }
        /// <summary>
        /// set don vi quan lý ve
        /// và - lý do hủy
        /// </summary>
        private void SetGiaTriMacDinh()
        { 
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            txtNam.Text = timeServer.Year.ToString();
            lblGhiChu.Text = "";
            
        }

        private void LoadDSCongTy(int CongTyID)
        {
            cboCongTy.ValueMember = "CongTyID";
            cboCongTy.DisplayMember = "TenCongTy";
            cboCongTy.DataSource = null;
            cboCongTy.DataSource = CongTy.GetAllDSCongTy();

            if (CongTyID > 0)
            {
                int iIndex = -1;
                foreach (Janus.Windows.EditControls.UIComboBoxItem objItem in cboCongTy.Items)
                {
                    iIndex += 1;
                    if (objItem.Value.ToString() == CongTyID.ToString())
                    {
                        break;
                    }
                }
                cboCongTy.SelectedIndex = iIndex;
            }
            else
                cboCongTy.SelectedIndex = 0;

        }
        private void numSeriDau_Leave(object sender, EventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            TraCuu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radVe_CheckedChanged(object sender, EventArgs e)
        {
            HienThiDieuKhien();             
        }

        private void radThe_CheckedChanged(object sender, EventArgs e)
        {
            HienThiDieuKhien();            
        }

        private void radHopDong_CheckedChanged(object sender, EventArgs e)
        {
            HienThiDieuKhien();
        }

        private void HienThiDieuKhien()
        {
            if (radVe.Checked)
            {
                lblVeThe.Text = "Seri vé";
                numSeriDau.Visible = true;
                txtMaSoThe.Visible = false;
            }
            else if (radThe.Checked)
            {
                lblVeThe.Text = "Mã thẻ hủy";
                numSeriDau.Visible = false;
                txtMaSoThe.Visible = true; txtMaSoThe.Text = "";
            }
            else if (radHopDong.Checked)
            {
                lblVeThe.Text = "Số hợp đồng";
                numSeriDau.Visible = true;
                txtMaSoThe.Visible = false;
                txtMaSoThe.Text = "";
            }
        }

        private void TraCuu()
        {
            if (cboCongTy.SelectedIndex < 0)
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng chọn đơn vị.");
                return;
            }
            int MaDonVi = Convert.ToInt32(cboCongTy.SelectedValue.ToString());
            int Nam = Convert.ToInt32(txtNam.Text );
            if(Nam < 2009) 
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin năm vé hủy lớn hơn bằng 2009.");
                return;
            }
            if (radVe.Checked)
            {
                int Seri = int.Parse(numSeriDau.Value.ToString());

                if (Seri <= 0 || MaDonVi   <= 0)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin vé cần tra cứu.");
                }
                else
                {
                    
                    DataTable dt = Ve.TimKiemThongTinVe(MaDonVi, Seri,Nam);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        lblGiaTriSuDung.Text = "VÉ ĐÃ HỦY.";
                        if(dt.Rows[0]["GhiChu"]!=null)
                            lblGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                        if (Convert.ToBoolean( dt.Rows[0]["IsTamNhap"].ToString()))
                            lblGiaTriSuDung.Text += " [Tạm nhập ]";
                    }
                    else lblGiaTriSuDung.Text = "VÉ CHƯA ĐƯỢC NHẬP THÔNG TIN HỦY.";

                }
            }
            else if (radThe .Checked)
            {
             
                string MaSoThe = StringTools.TrimSpace(txtMaSoThe.Text);
                DataTable dt = The.GetChiTietThe(MaSoThe, MaDonVi,Nam);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    lblGiaTriSuDung.Text = "THẺ ĐÃ HỦY.(" + dt.Rows[0]["TenCongTy"].ToString() + ")";
                    if (dt.Rows[0]["GhiChu"] != null)
                        lblGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();

                }
                else lblGiaTriSuDung.Text = "THẺ CHƯA ĐƯỢC NHẬP THÔNG TIN HỦY";
            }
            else if (radHopDong.Checked)
            {
                int SoHopDong = int.Parse(numSeriDau.Value.ToString());

                if (SoHopDong <= 0 )
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin số hợp đồng cần tra cứu.");
                }
                else
                {
                    DataTable dt = Ve.TimKiemThongTinSoHopDong(MaDonVi, SoHopDong,Nam);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        lblGiaTriSuDung.Text = "SỐ HỢP ĐỒNG ĐÃ HỦY.";
                        if (dt.Rows[0]["GhiChu"] != null)
                            lblGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                    }
                    else lblGiaTriSuDung.Text = "SỐ HỢP ĐỒNG CHƯA ĐƯỢC NHẬP THÔNG TIN HỦY.";

                }
            }
        }

        private void numSeriDau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraCuu();
            }
        }
        private void txtMaSoThe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraCuu();
            }
        }
    }
}