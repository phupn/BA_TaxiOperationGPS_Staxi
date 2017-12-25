using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.FastTaxis;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Services;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Common.Attributes;
namespace TaxiOperation_TongDai_ENVANGVIP
{
    public partial class frmBaoXeKhaiThac : FormBase
    {
        public DateTime ThoiDiemBao = DateTime.Now;
        private string MaLaiXe = string.Empty;
        private float KinhDo = 0;
        private float ViDo = 0;
        private int DiemDo = 0;

        public frmBaoXeKhaiThac()
        {
            InitializeComponent();
            lblThoiDiemBao.Text = ThoiDiemBao.ToString("HH:mm dd/MM");
            inputVehicle.Bind();
            inputGioKhachLen.EditValue = DateTime.Now;
            lblThongBao.Text = "";
        }

        public void SetModel(string g_vungChoPhep)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var item = inputVehicle.GetSelectedDataRow() as GiamSatXe_HoatDong;
            if(item == null || inputVehicle.EditValue == null)
            {
                lblThongBao.Text = "Phải nhập số hiệu xe";
                inputVehicle.Focus();
                return;
            }

            if (inputGioKhachLen.EditValue == null)
            {
                lblThongBao.Text = "Phải nhập giờ khách lên";
                inputGioKhachLen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDiaChiDon.Text))
            {
                lblThongBao.Text = "Phải nhập địa chỉ đón khách";
                txtDiaChiDon.Focus();
                return;
            }
            var result = false;
            result = CuocGoi.EnVangVip_sp_TaoCuocGoiKhaiThac(item.SoHieuXe, ThoiDiemBao, MaLaiXe, lblDriverName.Text,
            txtDiaChiDon.Text, DiemDo, txtGhiChu.Text, inputGioKhachLen.EditValue.To<DateTime>(), ThongTinDangNhap.USER_ID, string.Empty, "0", KinhDo, ViDo);
            if(!result)
            {
                lblThongBao.Text = "Không tạo được cuộc gọi";
                return;
            }
            Close();
        }

        private void inputVehicle_EditValueChanged(object sender, EventArgs e)
        {
            var item = inputVehicle.GetSelectedDataRow() as GiamSatXe_HoatDong;
            if(item == null)
            {
                inputVehicle.EditValue = null;
                if(!string.IsNullOrEmpty(inputVehicle.Text))
                {
                    lblThongBao.Text = "Số xe không thuộc hệ thống hoặc đang chở khách";
                }
                
                item = new GiamSatXe_HoatDong();
            }
            else
            {
                
                lblThongBao.Text = string.Empty;
            }

            lblDiemDo.Text = item.TenDiemDo;
            lblDriverName.Text = item.TenNhanVien;
            MaLaiXe = item.MaLaiXe;

            if (item.SoHieuXe != null)
            {
                var xeOnline = WCFService_Common.WCFServiceClient.TryGet(p => p.GetXeOnlineBySHX(item.SoHieuXe)).Value;
                KinhDo = xeOnline.KinhDo;
                ViDo = xeOnline.ViDo;
                DiemDo = item.DiemDo ?? 0;
                try
                {
                    if (KinhDo > 0 && ViDo > 0) txtDiaChiDon.Text = Service_Common.GetAddressByGeoBA(ViDo, KinhDo);
                    else txtDiaChiDon.Text = string.Empty;

                }
                catch (Exception)
                {
                }
            }
            else
            {
                txtDiaChiDon.Text = string.Empty;
            }
        }

        private void inputVehicle_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void inputGioKhachLen_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtDiaChiDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGhiChu.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void inputVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void inputGioKhachLen_EditValueChanged(object sender, EventArgs e)
        {
            var date = inputGioKhachLen.GetValue();
            if(date != null)
            {
                lblThongBao.Text = "";
            }
            else
            {
                lblThongBao.Text = "Phải nhập giờ khách lên";
            }
        }

        private void txtDiaChiDon_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDiaChiDon.Text))
            {
                lblThongBao.Text = "Phải nhập địa chỉ đón khách";
            }
            else
            {
                lblThongBao.Text = "";
            }
        }

        [MethodWithKey(Keys=Keys.Shift | Keys.C)]
        private void FocusGhiChu()
        {

        }
    }
}
