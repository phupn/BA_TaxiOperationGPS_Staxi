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
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.Config;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Utils;
using TaxiApplication.ServiceEnVang;

namespace TaxiOperation_TongDai_ENVANGVIP
{
    public partial class frmGuiLenhLaiXe : FormBase
    {
        public frmGuiLenhLaiXe()
        {   
            InitializeComponent();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var vehicle = inputVehicle.GetSelectedDataRow() as GiamSatXe_HoatDong;
            if (vehicle == null || inputVehicle.EditValue == null)
            {
                lblThongBao.Text = "Phải nhập số hiệu xe";
                inputVehicle.Focus();
                return;
            }
            var command = ilu_mobileOperationCommand.GetSelectedDataRow() as MobileOperationCommands;
            if (command == null || ilu_mobileOperationCommand.EditValue == null)
            {
                lblThongBao.Text = "Phải chọn lệnh lái xe";
                ilu_mobileOperationCommand.Focus();
                return;
            }
            EnVangProcess.SendOperatorCmd(command.PK_CommandID, vehicle.SoHieuXe);
            Close();
        }

        private void inputVehicle_EditValueChanged(object sender, EventArgs e)
        {
            var item = inputVehicle.GetSelectedDataRow() as GiamSatXe_HoatDong;
            if (item == null)
            {
                inputVehicle.EditValue = null;
                if (!string.IsNullOrEmpty(inputVehicle.Text))
                {
                    lblThongBao.Text = "Số xe không thuộc hệ thống hoặc đang chở khách";
                }
            }
            else
            {

                lblThongBao.Text = string.Empty;
            }

            lblDiemDo.Text = item.TenDiemDo;
            lblDriverName.Text = item.TenNhanVien;
        }

        private void ilu_mobileOperationCommand_EditValueChanged(object sender, EventArgs e)
        {
            var item = ilu_mobileOperationCommand.GetSelectedDataRow() as MobileOperationCommands;
            if (item == null)
            {
                ilu_mobileOperationCommand.EditValue = null;
                if (!string.IsNullOrEmpty(ilu_mobileOperationCommand.Text))
                {
                    lblThongBao.Text = "Phải chọn lệnh lái xe";
                }
            }
            else
            {
                lblThongBao.Text = string.Empty;
            }
        }

        private void frmGuiLenhLaiXe_Load(object sender, EventArgs e)
        {
            inputVehicle.Bind();
            ilu_mobileOperationCommand.IdStepWorkflow = 13;
            //ilu_mobileOperationCommand.Data
            ilu_mobileOperationCommand.Bind();
            lblThongBao.Text = "";
        }
    }
}
