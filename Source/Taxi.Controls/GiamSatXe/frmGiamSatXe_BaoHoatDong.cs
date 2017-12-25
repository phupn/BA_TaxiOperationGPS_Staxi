using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.MasterData;

namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_BaoHoatDong : FormBase
    {
        #region bien toan cuc
        DataTable dulieu;
        private GiamSatXe_LienLac lienlac = new GiamSatXe_LienLac();
        #endregion

        public frmGiamSatXe_BaoHoatDong()
        {
            InitializeComponent();
        }


        #region load form
        private void frmGiamSatXe_BaoHoatDong_Load(object sender, EventArgs e)
        {
            dulieu = lienlac.GSX_BaoHoatDong_GetXe();

            txtSoHieu.Properties.DataSource = dulieu;
            txtSoHieu.Properties.DisplayMember = "SoHieuXe";
            txtSoHieu.Properties.ValueMember = "MaLaiXe";

            lVungDieuHanh.Properties.DataSource = new VungDieuHanh().GetTenVungDieuHanh();
            lVungDieuHanh.Properties.DisplayMember = "TenVung";
            lVungDieuHanh.Properties.ValueMember = "Id";

            deGioDi.DateTime =GiamSatXe_LienLac.Inst.GetTimeServer();

            txtSoHieu.Focus();
        }
        #endregion


        #region validate
        private void txtSoHieu_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return; }
            else lblmsg.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); txtSoHieu.Focus(); return; }
            if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng") { lblmsg.Text = ("Bạn chưa nhập vùng"); txtSoHieu.Focus(); return; }
            if (deGioDi.DateTime > DateTime.Now) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; deGioDi.Focus(); return; }
            if (deGioDi.DateTime.Year < 2000) { lblmsg.Text = "Thời điểm không phù hợp"; deGioDi.Focus(); return; }
            if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; txtGhiChu.Focus(); return; }
            else lblmsg.Text = "";

            lienlac.GSX_BaoHoatDong_XuLy(int.Parse(txtSoHieu.GetColumnValue("Id").ToString()), deGioDi.DateTime, txtGhiChu.Text
                , int.Parse(lVungDieuHanh.GetColumnValue("Id").ToString()), txtSoHieu.GetColumnValue("SoHieuXe").ToString(), txtSoHieu.GetColumnValue("MaLaiXe").ToString()
                , "Báo hoạt động lại tại " + lVungDieuHanh.GetColumnValue("NameVungDH").ToString(), Taxi.Business.ThongTinDangNhap.USER_ID, new Guid());

            this.Close();
        }


        private void txtSoHieu_Leave(object sender, EventArgs e)
        {
            var r = txtSoHieu.GetColumnValue("TenNhanVien");
            if (r!=DBNull.Value&& r != "") lblTenLaiXe.Text = r.ToString();
            else lblTenLaiXe.Text = "";
            if (!txtSoHieu.Text.Equals("") && !txtSoHieu.Text.Equals(" "))
            {
                if (txtSoHieu.GetColumnValue("DiemDo").ToString() != "")
                    lVungDieuHanh.EditValue = int.Parse(txtSoHieu.GetColumnValue("DiemDo").ToString());
            }
            if (txtSoHieu.Text.Trim() == "" || txtSoHieu.Text.Trim() == "Chọn xe") { lblmsg.Text = ("Bạn chưa nhập số xe"); return; }
            else lblmsg.Text = "";
        }

        private void txtSoHieu_EditValueChanged(object sender, EventArgs e)
        {
            var r = txtSoHieu.GetColumnValue("TenNhanVien");
            if (r != DBNull.Value && r != "") lblTenLaiXe.Text = r.ToString();
            else lblTenLaiXe.Text = "";

            if (!txtSoHieu.Text.Equals("") && !txtSoHieu.Text.Equals(" "))
            {
                if (txtSoHieu.GetColumnValue("DiemDo").ToString() != "")
                    lVungDieuHanh.EditValue = int.Parse(txtSoHieu.GetColumnValue("DiemDo").ToString());
            }
        }

        private void lVungDieuHanh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSoHieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                txtSoHieu.Text = txtSoHieu.Text.TrimStart();
            if (e.KeyChar != '\t')
                lblTenLaiXe.Text = "";
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            txtGhiChu.Text = txtGhiChu.Text.TrimStart();
            if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; return; }
            else lblmsg.Text = "";
        }

        private void lVungDieuHanh_Leave(object sender, EventArgs e)
        {
            if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng") { lblmsg.Text = ("Bạn chưa nhập vùng"); return; }
            else lblmsg.Text = "";
        }

        private void txtGhiChu_Leave(object sender, EventArgs e)
        {
            if (txtGhiChu.Text.Length > 250) { lblmsg.Text = "Ghi chú có quá nhiều ký tự"; return; }
            else lblmsg.Text = "";
        }

        private void deGioDi_Leave(object sender, EventArgs e)
        {
            if (deGioDi.DateTime > DateTime.Now) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; return; }
            else lblmsg.Text = "";
        }

        private void lVungDieuHanh_TextChanged(object sender, EventArgs e)
        {
            if (lVungDieuHanh.Text.Trim() == "" || lVungDieuHanh.Text.Trim() == "Chọn vùng") { lblmsg.Text = ("Bạn chưa nhập vùng"); return; }
            else lblmsg.Text = "";
        }

        private void deGioDi_TextChanged(object sender, EventArgs e)
        {
            if (deGioDi.DateTime > DateTime.Now) { lblmsg.Text = "Thời điểm không quá ngày hiện tại"; return; }
            else lblmsg.Text = "";
        }
        #endregion
    }
}
