using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Data.BanCo.Entity.Config;
using Taxi.Common.Extender;
using Taxi.Controls.Base;

namespace Taxi.Controls.Configs
{
    public partial class frmMobileOperationStepWorkflows : FormBase
    {
        public frmMobileOperationStepWorkflows()
        {
            InitializeComponent();
        }
        public int IdWorkflow { get; set; }
        public MobileOperationStepWorkflows model;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (model == null) model = new MobileOperationStepWorkflows();
                model.FK_WorkflowID = inputLookUp_Workflow1.EditValue.To<int>();
                model.IsStart = cbkGhiNhanBuocBatDau.Checked;
                model.IsEnd = cbkGhiNhanBuocKeThuc.Checked;
                model.IsCommon = cbkLenhDungChung.Checked;
                model.IsActive = cbkKichHoat.Checked;
                model.Description = txtMoTa.Text;
                model.Name = txtTenBuoc.Text;
                model.UpdatedByUser = ThongTinDangNhap.USER_ID;
                model.CreatedByUser = ThongTinDangNhap.USER_ID;
                model.Save();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show(ex.Message);

            }
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmMobileOperationStepWorkflows_Load(object sender, EventArgs e)
        {
            inputLookUp_Workflow1.Bind();
            if (model != null)
            {
                inputLookUp_Workflow1.EditValue = model.FK_WorkflowID;
                cbkGhiNhanBuocBatDau.Checked = model.IsStart;
                cbkGhiNhanBuocKeThuc.Checked = model.IsEnd;
                cbkLenhDungChung.Checked = model.IsCommon;
                cbkKichHoat.Checked = model.IsActive;
                txtMoTa.Text = model.Description;
                txtTenBuoc.Text = model.Name;
            }
            else
            {
                inputLookUp_Workflow1.EditValue = IdWorkflow;
            }
        }
    }
}
