using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Word;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Data.FastTaxi;

namespace TaxiOperation_DieuHanhChinh.DM
{
    public partial class frmDanhMucLoaiXe : FormBase
    {
        #region Khai báo và khởi tạo
        private StaxiCarType _carType;
        public frmDanhMucLoaiXe()
        {
            InitializeComponent();
        }
        #endregion
        #region Events!
        private void frmDanhMucLoaiXe_Load(object sender, System.EventArgs e)
        {
            gridLoaiXe.DataSource = CommonBL.ListStaxiLoaiXe.OrderBy(a=>a.Seat).ThenBy(b=>b.OrderBy).ToList();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void txtDigital_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            int row = 0;
            row = gridViewLoaiXe.FocusedRowHandle;
            var dataRow = ((List<StaxiCarType>) gridLoaiXe.DataSource)[row];
            if (dataRow != null&&CheckValidate())
            {
                _carType = new StaxiCarType();
                _carType = (StaxiCarType)dataRow.Clone();
                _carType.Name = txtName.Text;
                _carType.IsActive = (int)inputIsActive.EditValue==1;
                _carType.Type = (Taxi.Utils.StaxiCarType_Type)txtType.Text.To<int>();
                _carType.Seat = txtSeat.Text.To<int>();
                _carType.OrderBy = txtOrderBy.Text.To<int>();
                _carType.Update();
                DisplayMessage("Sửa thông tin loại xe thành công!",Color.Blue);               
                gridLoaiXe.DataSource = CommonBL.ListStaxiLoaiXe.OrderBy(a => a.Seat).ThenBy(b => b.OrderBy).ToList();
            }
        }

        private void DisplayMessage(string pMessage, Color pColor)
        {
            lblMessage.Text = pMessage;            
            lblMessage.ForeColor = pColor;
            lblMessage.Visible = true;
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                DisplayMessage("Tên loại xe không được để trống",Color.Red);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtType.Text))
            {
                DisplayMessage("Loại xe không được để trống!",Color.Red);
                txtType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSeat.Text))
            {
                DisplayMessage("Số chỗ không được để trống!",Color.Red);
                txtSeat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtOrderBy.Text))
            {
                DisplayMessage("Số thứ tự không được để trống!",Color.Red);
                txtOrderBy.Focus();
                return false;
            }
            return true;
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            ResetControls();
        }
        #endregion

        #region Methods
        private void ResetControls()
        {
            txtName.Text = string.Empty;
            txtType.Text = string.Empty;
            txtSeat.Text = string.Empty;
            txtOrderBy.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }
        #endregion

        private void gridViewLoaiXe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int row = 0;
            row = gridViewLoaiXe.FocusedRowHandle;
            var dataRow = ((List<StaxiCarType>) gridLoaiXe.DataSource)[row];
            if (dataRow!=null)
            {
                txtName.Text = dataRow.Name;
                txtSeat.Text = dataRow.Seat.ToString();
                txtOrderBy.Text = dataRow.OrderBy.ToString();
                txtType.Text = dataRow.Type.ToString();
                if (dataRow.IsActive) 
                    inputIsActive.EditValue = 1;
                else inputIsActive.EditValue = 0;
            }
        }
    }
}
