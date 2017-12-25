using System;
using Taxi.Controls.Base;
using Taxi.Data.DM;
using Taxi.Common.Extender;
using Taxi.MessageBox;
namespace Taxi.Controls.DanhMuc
{
    public partial class frmDanhMucKhachDungThe : FormBase
    {
        public object GetData()
        {
            return KhachHangDungThe.Inst.GetData(txtMaThe.Text, deTuNgay.EditValue.To<DateTime?>(), deDenNgay.EditValue.To<DateTime?>(), txtMaKH.Text, txtTenKH.Text, txtSDT.Text,txtDiaChi.Text);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                grdData.DataSource = GetData();
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
        public KhachHangDungThe ModelCurrent { get { return grvData.GetFocusedRow().As<KhachHangDungThe>(); } }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                if (new frmKhachDungThe().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btnTimKiem.PerformClick();
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;

            }
            
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                var model = ModelCurrent;
                if (model == null)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chưa chọn để sửa");
                    return;
                }
                if (new frmKhachDungThe(model).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btnTimKiem.PerformClick();
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                var model = ModelCurrent;
                if (model == null)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chưa chọn để xóa");
                    return;
                }
                if (new MessageBox.MessageBoxBA().Show("Bạn có xóa không?", "Thông báo", MessageBoxButtonsBA.Yes).ToLower() == "Yes".ToLower())
                {

                    model.Delete();
                    btnTimKiem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }

        private void frmDanhMucKhachDungThe_Load(object sender, EventArgs e)
        {
            btnTimKiem.PerformClick();
        }
    }
}
