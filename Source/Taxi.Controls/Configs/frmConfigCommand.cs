using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity;
using Taxi.Controls.Base.Common.Enums.RepositoryItemLookUpEdit;
using Taxi.Controls.Base.Extender;
using Taxi.Common.Extender;

namespace TaxiOperation_BanCo.Config
{
    public partial class frmConfigCommand : FormBase
    {
        #region Biến toàn cục
        private List<TaxiOperationCommand> _lstCommand = new List<TaxiOperationCommand>();
        private TaxiOperationCommand _cmdTaxi;
        private bool _isUpdate = false;
        private int _idCmd = -1;
        private bool _isXeNhan = false;
        private bool _isChuyenMoiKhach = false;
        private int _phimTat = 0;
        private string _TenLenh = "";
        #endregion

        #region Khởi tạo form
        public frmConfigCommand()
        {
            InitializeComponent();
            _cmdTaxi = new TaxiOperationCommand();
            ceMauNen.Properties.ShowCustomColors = false;
            ceMauNen.Properties.ShowSystemColors = false;
            ceMauNenThayDoi.Properties.ShowCustomColors = false;
            ceMauNenThayDoi.Properties.ShowSystemColors = false;            
            grvLenhDieuHanh.Add<RepositoryItemLookUpEdit_BoPhan>("FunctionUsing");
            grvLenhDieuHanh.Add<RepositoryItemLookUpEdit_PhimTat>("Shortcuts");
            grvLenhDieuHanh.Add<RepositoryItemLookUpEdit_TrangThaiCG>("CallStatus");
            grvLenhDieuHanh.Add<RepositoryItemLookUpEdit_TrangThaiLenh>("Status");
            grvLenhDieuHanh.Add<RepositoryItemLookUpEdit_KieuCuocGoi>("CallType");
            grvLenhDieuHanh.Add<RepositoryItemLookUpEdit_SendDriver>("SendDriver");
            grvLenhDieuHanh.Add<RepositoryItemLookUpEdit_Enum_CommandCode>("CommandCode");
        }

        #endregion

        #region Hàm load data
        private void LoadData()
        {
            _lstCommand = new TaxiOperationCommand().GetListAll().OrderBy(a=>a.FunctionUsing).ThenBy(a=>a.OrderCode).ToList();
            chkParentCommand.Properties.DataSource = _lstCommand;
            chkParentCommand.Properties.DisplayMember = "Command";
            chkParentCommand.Properties.ValueMember = "Command";
            grcLenhDieuHanh.DataSource = _lstCommand;
        }
        #endregion

        #region Form load
        private void frmConfigCommand_Load(object sender, EventArgs e)
        {
            LoadData();
            //Binding dữ liệu vào các control
            this.BindShControl();
        }
        #endregion

        #region Xử lý nút
        private void btnLuu_Click(object sender, EventArgs e)
        {            
            lblMsg.Text = "";
            if (IsValid())
            {
                if (_isUpdate)
                {
                    string msg = new Taxi.MessageBox.MessageBoxBA().Show(this,"Bạn có muốn sửa thông tin lệnh ?","Thông báo",Taxi.MessageBox.MessageBoxButtonsBA.OKCancel,Taxi.MessageBox.MessageBoxIconBA.Question);
                    if(msg =="Cancel")
                        return;                    
                    int update = _cmdTaxi.UpdateCmd(_idCmd, txtLenh.Text, luePhimTat.EditValue.To<int>(), lueTrangThaiCG.EditValue.To<int>(), lueTrangThaiLenh.EditValue.To<int>(),
                             lueKieuCuocGoi.EditValue.To<int>(), ceMauNen.Text, chkParentCommand.Properties.GetCheckedItems().To<string>(), ceMauNenThayDoi.Text, ckbCoXeNhan.Checked,
                             lueBoPhan.EditValue.To<int>(), ckbChuyenMoiKhach.Checked, lookupEdit_EnumCommand_SendDriver1.EditValue.To<int>(), txtOrderCode.Text.To<int>(), lookUpEdit_CommandCode.EditValue.To<int>());
                    if (update > 0)
                    {
                        RefreshForm();
                        lblMsg.Text = "Cập nhật thành công";
                        lblMsg.ForeColor = Color.Blue;
                        LoadData();
                    }
                    else
                    {
                        lblMsg.Text = "Cập nhật không thành công";
                        lblMsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string msg = new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn có muốn thêm lệnh mới ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question);
                    if (msg == "Cancel")
                        return;  
                    int addNew = _cmdTaxi.InsertCmd(txtLenh.Text, luePhimTat.EditValue.To<int>(), lueTrangThaiCG.EditValue.To<int>(), lueTrangThaiLenh.EditValue.To<int>(),
                             lueKieuCuocGoi.EditValue.To<int>(), ceMauNen.Text, chkParentCommand.Properties.GetCheckedItems().To<string>(), ceMauNenThayDoi.Text, ckbCoXeNhan.Checked,
                             lueBoPhan.EditValue.To<int>(), ckbChuyenMoiKhach.Checked, lookupEdit_EnumCommand_SendDriver1.EditValue.To<int>(), lookUpEdit_CommandCode.EditValue.To<int>());
                    if (addNew > 0)
                    {
                        RefreshForm();
                        lblMsg.Text = "Thêm mới thành công";
                        lblMsg.ForeColor = Color.Blue;
                        LoadData();                       
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới không thành công";
                        lblMsg.ForeColor = Color.Red;
                    }
                }
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (_idCmd != -1)
            {
                if (lookUpEdit_CommandCode.EditValue != null && lookUpEdit_CommandCode.EditValue.To<int>() == 1000)
                {
                    lblMsg.Text = "Bạn không được cập nhật lệnh của hệ thống";
                    lblMsg.ForeColor = Color.Red;
                    lookUpEdit_CommandCode.Focus();
                    return;
                }
                int del = _cmdTaxi.DeleteCmd(_idCmd);
                if (del > 0)
                {
                    RefreshForm();
                    lblMsg.Text = "Xóa thành công";
                    lblMsg.ForeColor = Color.Blue;
                    LoadData();                   
                }
                else
                {
                    lblMsg.Text = "Xóa không thành công";
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            this.Close();
        }
        #endregion

        #region Hàm refresh 
        private void RefreshForm()
        {
            lblMsg.Text = "";
            lueBoPhan.EditValue = null;
            txtLenh.Text = "";
            _TenLenh = "";
            _phimTat = 0;
            luePhimTat.EditValue = null;
            lueTrangThaiCG.EditValue = null;
            lueTrangThaiLenh.EditValue = null;
            ceMauNen.Text = "";
            ceMauNenThayDoi.Text = "";
            lueKieuCuocGoi.EditValue = null;
            chkParentCommand.EditValue = null;
            ckbCoXeNhan.Checked = false;
            ckbChuyenMoiKhach.Checked = false;
            lookupEdit_EnumCommand_SendDriver1.EditValue = null;
            txtOrderCode.Text = string.Empty;
            _isUpdate = false;
        }
        #endregion

        #region Grid event
        private void grvLenhDieuHanh_Click(object sender, EventArgs e)
        {
            try
            {
                TaxiOperationCommand objCommand = (TaxiOperationCommand)grvLenhDieuHanh.GetFocusedRow();
                txtOrderCode.Text = objCommand.OrderCode.ToString();
                _idCmd = objCommand.Id;
                lueBoPhan.EditValue = objCommand.FunctionUsing;
                txtLenh.Text = objCommand.Command;
                luePhimTat.EditValue = objCommand.Shortcuts;
                
                lueTrangThaiCG.EditValue = objCommand.CallStatus;
                //if (_phimTat != "")
                //{
                //    luePhimTat.EditValue = int.Parse(_phimTat);
                //}
                lueTrangThaiLenh.EditValue = objCommand.Status;
                lueKieuCuocGoi.EditValue = objCommand.CallType;
                if (objCommand.ParentCommand != null && !objCommand.ParentCommand.Equals(""))
                {
                    chkParentCommand.EditValue = objCommand.ParentCommand;
                }
                else
                    chkParentCommand.EditValue = null;
                lookupEdit_EnumCommand_SendDriver1.EditValue = objCommand.SendDriver;
                ceMauNen.Text = objCommand.CmdColor ?? "";
                ceMauNenThayDoi.Text = objCommand.ParentColor ?? "";
                _isXeNhan = objCommand.RequireVehicle;
                if (_isXeNhan)
                {
                    ckbCoXeNhan.Checked = true;
                }
                else
                {
                    ckbCoXeNhan.Checked = false;
                }
                _isChuyenMoiKhach = objCommand.IsSend_CallCust != null && (bool)objCommand.IsSend_CallCust; 
                if (_isChuyenMoiKhach)
                {
                    ckbChuyenMoiKhach.Checked = true;
                }
                else
                {
                    ckbChuyenMoiKhach.Checked = false;
                }
                lookUpEdit_CommandCode.EditValue = (int)objCommand.CommandCode;
                _isUpdate = true;
                _phimTat = objCommand.Shortcuts;
                _TenLenh = objCommand.Command;
            }
            catch 
            {
                MessageBox.Show("Lỗi truyền dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Validate
        private bool IsValid()
        {
            if (txtLenh.Text.Equals(""))
            {
                lblMsg.Text = "Bạn chưa nhập lệnh";
                lblMsg.ForeColor = Color.Red;
                txtLenh.Focus();
                return false;
            }
            if (lueTrangThaiLenh.EditValue.To<int>() == 0)
            {
                lblMsg.Text = "Bạn chưa chọn trạng thái lệnh";
                lblMsg.ForeColor = Color.Red;
                lueTrangThaiLenh.Focus();
                return false;
            }
            if (lueKieuCuocGoi.EditValue.To<int>() == 0)
            {
                lblMsg.Text = "Bạn chưa chọn kiểu cuộc gọi";
                lblMsg.ForeColor = Color.Red;
                lueKieuCuocGoi.Focus();
                return false;
            }
            if (lookUpEdit_CommandCode.EditValue == null)
            {
                lblMsg.Text = "Bạn chưa chọn mã lệnh";
                lblMsg.ForeColor = Color.Red;
                lookUpEdit_CommandCode.Focus();
                return false;                
            }
            else if (lookUpEdit_CommandCode.EditValue != null && (lookUpEdit_CommandCode.EditValue.To<int>() == 1000 || lookUpEdit_CommandCode.EditValue.To<int>() == 0))
            {
                lblMsg.Text = "Bạn không được cập nhật lệnh mặc định hoặc lệnh của hệ thống";
                lblMsg.ForeColor = Color.Red;
                lookUpEdit_CommandCode.Focus();
                return false;
            }
            if (_TenLenh != txtLenh.Text && _lstCommand.Any(a => a.Command == txtLenh.Text && a.FunctionUsing == lueBoPhan.EditValue.To<int>()))
            {
                lblMsg.Text = "Tên lệnh không được trùng nhau trong cùng một bộ phận!";
                lblMsg.ForeColor = Color.Red;
                txtLenh.Focus();
                return false;
            }
            if (_phimTat != luePhimTat.EditValue.To<int>())
            {

                int count = _lstCommand.Where(a => a.Shortcuts == luePhimTat.EditValue.To<int>() && a.FunctionUsing == lueBoPhan.EditValue.To<int>() && a.Command != txtLenh.Text).Count();
                if (count > 0)
                {
                    lblMsg.Text = "Phím tắt không được trùng nhau trong cùng một bộ phận!";
                    lblMsg.ForeColor = Color.Red;
                    luePhimTat.Focus();
                    return false;
                }
            }
            return true;
        }

        private void txtLenh_TextChanged(object sender, EventArgs e)
        {
            txtLenh.Text = txtLenh.Text.TrimStart();
        }
        #endregion

        private void txtOrderCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}