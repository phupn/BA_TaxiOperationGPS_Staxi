using System;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Data.FastTaxi;
using Taxi.Common.Extender;
namespace TaxiOperation_DieuHanhChinh
{
    public partial class frmXeViPham : FormBase
    {
        private LoiViPham _model;
        public frmXeViPham(LoiViPham model)
        {
            _model = model;
            InitializeComponent();
        }
        public frmXeViPham()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            if (deStart.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập áp dụng từ ngày."); ;
                deStart.Focus();
                return;
            }
            if (deEnd.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập áp dụng đến ngày."); ;
                deEnd.Focus();
                return;
            }
            if (deStart.DateTime >deEnd.DateTime)
            {
                MessageBox.Show("Áp dụng từ ngày nhỏ hơn đến ngày."); ;
                deEnd.Focus();
                return;
            }
            if (txtSoXe.EditValue == null || txtSoXe.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số xe."); ;
                txtSoXe.Focus();
                return;
            }
            if (lup_LoaiLoiViPham1.EditValue == null )
            {
                MessageBox.Show("Bạn chưa nhập lỗi vi phạm."); ;
                lup_LoaiLoiViPham1.Focus();
                return;
            }
            if (_model == null)
            {
                _model = new LoiViPham();
                _model.CreateBy = ThongTinDangNhap.USER_ID;
                _model.CreateDate = DateTime.Now;
            }
            _model.TuNgay = deStart.DateTime;
            _model.DenNgay = deEnd.DateTime;
            _model.SoXe = txtSoXe.Text;
            _model.FK_LoaiLoiViPham = lup_LoaiLoiViPham1.EditValue.To<int>();
            _model.GhiChu = txtGhiChu.Text;            
            _model.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void frmXeViPham_Load(object sender, System.EventArgs e)
        {
            deStart.Bind();
            deEnd.Bind();
            lup_LoaiLoiViPham1.Bind();
            if (_model != null)
            {
                deStart.EditValue = _model.TuNgay;
                deEnd.EditValue = _model.DenNgay;
                txtSoXe.Text = _model.SoXe;
                lup_LoaiLoiViPham1.EditValue = _model.FK_LoaiLoiViPham;
                txtGhiChu.Text = _model.GhiChu;
            }
            txtSoXe.Focus();
        }
    }
}
