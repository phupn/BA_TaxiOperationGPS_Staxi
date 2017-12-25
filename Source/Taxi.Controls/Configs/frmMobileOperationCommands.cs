using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.Config;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Common.Enums.RepositoryItemLookUpEdit;
using Taxi.Controls.Base.Extender;
using Taxi.Business;
using System;
using System.Drawing;
using Taxi.Controls.Base.Common.RepositoryItems;
using Taxi.Services;
using Taxi.Services.Service_ServerCenter;
using System.Collections.Generic;
namespace Taxi.Controls.Configs
{
    public partial class frmMobileOperationCommands : FormBase
    {
        #region ================= Ini =====================
        MobileOperationCommands modelCurrent;
        private int ClearMsg = 5;
        public frmMobileOperationCommands()
        {
            InitializeComponent();
        }
        private void frmMobileOperationCommands_Load(object sender, System.EventArgs e)
        {
            BindControl();
        }
        #endregion

        #region =============== Function ==================
        /// <summary>
        /// Binds the control.
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  25/08/2015   created
        /// </Modified>
        private void BindControl()
        {
            try
            {
                SetMessge("");
                lue_Workflow1.Bind();
                groupBox2.BindShControl();
                grvCommand.Add<RepositoryItemLookUpEdit_PhimTat>("PMDH_Shortcuts");
                grvCommand.Add<RepositoryItemLookUpEdit_TrangThaiCG>("PMDH_CallStatus");
                grvCommand.Add<RepositoryItemLookUpEdit_TrangThaiLenh>("PMDH_Status");
                grvCommand.Add<RepositoryItemLookUpEdit_KieuCuocGoi>("PMDH_CallType");
                grvCommand.Add<RepositoryItemColor>("BackgroundColor");
                grvCommand.Add<RepositoryItemColor>("ForeColor");
                //
                grvCommand.Add<RepositoryItemLookUpEdit_SendDriver>("SendDriver");
                grvCommand.Add<RepositoryItemLookUpEdit_BoPhan>("FunctionUsing");
            }
            catch (Exception ex)
            {

            }
            
        }
        /// <summary>
        /// Does the fill.
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        private void DoFill()
        {
            if (modelCurrent != null)
            {
                txtTenLenh.Text = modelCurrent.CommandName;
                luePhimTat.EditValue = modelCurrent.PMDH_Shortcuts;
                lueBackgroundColor.EditValue = modelCurrent.BackgroundColor;
                lueForeColor.EditValue = modelCurrent.ForeColor;
                inputPriority.EditValue = modelCurrent.Priority;
                lueTrangThaiCG.EditValue = modelCurrent.PMDH_CallStatus;
                lueTrangThaiLenh.EditValue = modelCurrent.PMDH_Status;
                lueKieuCuocGoi.EditValue = modelCurrent.PMDH_CallType;
                ckbAmThanh.Checked = modelCurrent.HasAlarmVoice;
                ckbGioiHanThoiGian.Checked = modelCurrent.HasLimitedTime;
                ckbHienThiIcon.Checked = modelCurrent.IsShow;
                ckbCoXeNhan.Checked = modelCurrent.PMDH_RequireVehicle;
                lueAudio.EditValue = modelCurrent.VoiceAlarm;
                txtTu.EditValue= modelCurrent.FromMinutes ;
                txtDen.EditValue=  modelCurrent.ToMinutes ;
                lueAudioVe.EditValue = modelCurrent.SpeechSynthesizerVoice;
                //if (modelCurrent.IsShow)
                int Argb = 0;
                if (int.TryParse(modelCurrent.PMDH_ParentColor.Replace("#", ""), System.Globalization.NumberStyles.AllowHexSpecifier, null, out Argb))
                {
                    lueColor.EditValue = Color.FromArgb(Argb);
                }else
                    lueColor.EditValue =null;
                cmb_CommandParrent.SetValue(modelCurrent.PMDH_ParentCommand);
                lueIcon.EditValue = modelCurrent.Icon;
            }
        }
        /// <summary>
        /// Does the clear.
        /// đẩy form nhập lệnh về mặc định
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        private void DoClear()
        {
            txtTenLenh.EditValue = null;
            luePhimTat.EditValue = null;
            lueBackgroundColor.EditValue = null;
            lueForeColor.EditValue = null;
            inputPriority.EditValue = null;
            lueTrangThaiCG.EditValue = null;
            lueTrangThaiLenh.EditValue = null;
            lueKieuCuocGoi.EditValue = null;
            ckbAmThanh.Checked = false;
            ckbGioiHanThoiGian.Checked = false;
            ckbHienThiIcon.Checked = false;
            ckbCoXeNhan.Checked = false;
            lueAudioVe.EditValue = null;
            lueIcon.EditValue = null;
            lueAudio.EditValue = null;
            txtTu.EditValue = null;
            txtDen.EditValue = null;
            lueColor.EditValue = null;
            cmb_CommandParrent.EditValue = null;
            cmb_CommandParrent.RefreshEditValue();
        }
        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        private bool DoValidate()
        {
            if(string.IsNullOrEmpty(txtTenLenh.Text)||string.IsNullOrWhiteSpace(txtTenLenh.Text)){
                SetMessgeError("Vui lòng nhập tên lệnh");
                txtTenLenh.Focus();
                return false;
            }
            if (ckbHienThiIcon.Checked && (lueIcon.EditValue == null || lueIcon.EditValue.ToString()==""))
            {
                SetMessgeError("Vui lòng chọn ico");
                lueIcon.Focus(); 
                return false;
            }
            if (ckbAmThanh.Checked && (lueAudio.EditValue == null || lueAudio.EditValue.ToString() == ""))
            {
                SetMessgeError("Vui lòng chọn âm thanh");
                lueAudio.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Does the pasre.
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        private void DoPasre()
        {
            if (modelCurrent == null) modelCurrent = new MobileOperationCommands();
            modelCurrent.CommandName = txtTenLenh.Text;
            modelCurrent.FK_MobileOperationStepWorkflowID = lsBox_StepWorkflow.SelectedValue.To<int>();
            modelCurrent.FK_CompanyID = ThongTinCauHinh.CompanyID;
            modelCurrent.ForeColor = ((Color) lueForeColor.EditValue).ToArgb();
            modelCurrent.BackgroundColor = ((Color) lueBackgroundColor.EditValue).ToArgb(); //lueBackgroundColor.EditValue.To<int>();
            modelCurrent.PMDH_CallStatus = lueTrangThaiCG.EditValue.To<int>();
            modelCurrent.PMDH_CallType = lueKieuCuocGoi.EditValue.To<int>();
            modelCurrent.PMDH_Status = lueTrangThaiLenh.EditValue.To<int>();
            modelCurrent.Priority = inputPriority.EditValue.To<int>();
            modelCurrent.PMDH_Shortcuts = luePhimTat.EditValue.To<int>();
            modelCurrent.HasAlarmVoice = ckbAmThanh.Checked;

            if (modelCurrent.HasAlarmVoice)
            {
                modelCurrent.VoiceAlarm = lueAudio.EditValue.To<string>();
            }
            else
            {
                modelCurrent.VoiceAlarm = string.Empty;
            }
            modelCurrent.HasLimitedTime=ckbGioiHanThoiGian.Checked;
            if (modelCurrent.HasLimitedTime)
            {
                modelCurrent.FromMinutes = txtTu.EditValue.To<int>();
                modelCurrent.ToMinutes = txtDen.EditValue.To<int>();
            }
            else
            {
                modelCurrent.FromMinutes = 0;
                modelCurrent.ToMinutes = 0;
            }
            modelCurrent.IsShow = ckbHienThiIcon.Checked;
            if (modelCurrent.IsShow)
            {
                modelCurrent.Icon = lueIcon.EditValue.To<string>();
            }
            else
            {
                modelCurrent.Icon = string.Empty;
            }
            modelCurrent.SpeechSynthesizerVoice =lueAudioVe.EditValue.To<string>();
            modelCurrent.PMDH_RequireVehicle= ckbCoXeNhan.Checked;
            if (lueColor.EditValue!=null)
            modelCurrent.PMDH_ParentColor =lueColor.EditValue.As<Color>().Name;
            else
            {
                modelCurrent.PMDH_ParentColor = string.Empty;
            }
            modelCurrent.PMDH_ParentCommand = cmb_CommandParrent.EditValue.To<string>();
        }
        /// <summary>
        /// Sets the messge.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        private void SetMessge(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                lblMsg.Text = "";
                ClearMsg = 0;
            }
            else
            {
                ClearMsg = 3;
                lblMsg.ForeColor = Color.Blue;
                lblMsg.Text = msg;
                timer1.Start();
            }
        }
        /// <summary>
        /// Sets the messge error.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        private void SetMessgeError(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                lblMsg.Text = "";
                ClearMsg = 0;
            }
            else
            {
                ClearMsg = 3;
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = msg;
                timer1.Start();
            }
        }
        #endregion

        #region =============== Form Event ================
        #region ---------------- StepWorkflow --------------------
        private void lue_Workflow1_EditValueChanged(object sender, System.EventArgs e)
        {
            if(lue_Workflow1.EditValue!=null){
                lsBox_StepWorkflow.DataSource = MobileOperationStepWorkflows.Inst.GetListByIdWorkflows(lue_Workflow1.EditValue.To<int>());
            }
            else
            {
                lsBox_StepWorkflow.DataSource = null;
            }
            
        }

        private void lsBox_StepWorkflow_SelectedValueChanged(object sender, System.EventArgs e)
        {
           
            if(lsBox_StepWorkflow.SelectedValue!=null){
                int id = lsBox_StepWorkflow.SelectedValue.To<int>();
                grdCommand.DataSource = MobileOperationCommands.Inst.GetListByIdStepWorkflow(id);
                //inputCheckedComboBox_MobileOperationCommand1.StepWorkflowId = id;
                cmb_CommandParrent.Bind();
            }
            else
            {
                grdCommand.DataSource = null;
            }
            DoClear();
            modelCurrent = null;
        }

        private void btn_StepWorkflow_Refresh_Click(object sender, System.EventArgs e)
        {
            lue_Workflow1_EditValueChanged(null, null);
        }

        private void btn_StepWorkflow_Add_Click(object sender, System.EventArgs e)
        {
            if (lue_Workflow1.EditValue != null)
            {
                var frm = new frmMobileOperationStepWorkflows();
                frm.IdWorkflow = lue_Workflow1.EditValue.To<int>();
                // frm.model = lsBox_StepWorkflow.SelectedItem.As<MobileOperationStepWorkflows>();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btn_StepWorkflow_Refresh.PerformClick();
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Chưa chọn nhóm");
                lue_Workflow1.Focus();
            }
            
        }

        private void btn_StepWorkflow_Edit_Click(object sender, System.EventArgs e)
        {
            if (lsBox_StepWorkflow.SelectedItem != null)
            {
                var frm = new frmMobileOperationStepWorkflows();
                frm.IdWorkflow = lue_Workflow1.EditValue.To<int>();
                frm.model = lsBox_StepWorkflow.SelectedItem.As<MobileOperationStepWorkflows>();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btn_StepWorkflow_Refresh.PerformClick();
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa chọn bước lệnh.");
            }
            
        }

        private void btn_StepWorkflow_Delete_Click(object sender, System.EventArgs e)
        {
            if (lsBox_StepWorkflow.SelectedItem != null)
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa bước lệnh này không?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo).ToLower() == "YES".ToLower())
                {
                    var m = lsBox_StepWorkflow.SelectedItem.As<MobileOperationStepWorkflows>();
                    m.DeleteById(m.PK_StepWorkflowID);
                    btn_StepWorkflow_Refresh.PerformClick();
                    SetMessge("Xóa dữ liệu thành công");
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa chọn bước lệnh.");
            }
        }
        private void btn_StepWorkflow_Up_Click(object sender, EventArgs e)
        {
            if(lsBox_StepWorkflow.SelectedItem!=null){
                int i=lsBox_StepWorkflow.SelectedIndex;
                var m = lsBox_StepWorkflow.SelectedItem.As<MobileOperationStepWorkflows>();
                m.Up(m.PK_StepWorkflowID, m.FK_WorkflowID);
                btn_StepWorkflow_Refresh.PerformClick();
                if (i>0)
                    i--;
                lsBox_StepWorkflow.SelectedIndex = i;
            }
           
        }

        private void btn_StepWorkflow_Down_Click(object sender, EventArgs e)
        {
            if(lsBox_StepWorkflow.SelectedItem!=null){
                int i = lsBox_StepWorkflow.SelectedIndex;
                var m = lsBox_StepWorkflow.SelectedItem.As<MobileOperationStepWorkflows>();
                m.Down(m.PK_StepWorkflowID, m.FK_WorkflowID);
                btn_StepWorkflow_Refresh.PerformClick();
                if (i < lsBox_StepWorkflow.ItemCount-1)
                    i++;
                lsBox_StepWorkflow.SelectedIndex = i;
            }
             
        }
        #endregion

        #region ---------------- Command -------------------------
        private void btn_Command_Add_Click(object sender, System.EventArgs e)
        {
           
            if (DoValidate())
            {
                modelCurrent = null;
                DoPasre();
                modelCurrent.Save();
                btn_Command_Refresh.PerformClick();
                SetMessge("Thêm dữ liệu thành công");
            }
        }

        private void btn_Command_Edit_Click(object sender, System.EventArgs e)
        {         
            if (modelCurrent != null)
            {
                if (DoValidate())
                {
                    DoPasre();
                    modelCurrent.Save();
                    btn_Command_Refresh.PerformClick();
                    SetMessge("Cập nhật dữ liệu thành công");
                }
               
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa chọn lệnh.");
            }
        }

        private void btn_Command_Delete_Click(object sender, System.EventArgs e)
        {
            if (modelCurrent != null)
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa lệnh này không?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo).ToLower() == "YES".ToLower())
                {
                    modelCurrent.DeleteById(modelCurrent.PK_CommandID);
                    btn_Command_Refresh.PerformClick();
                    modelCurrent = null;
                }
               
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa chọn lệnh.");
            }
        }

        private void btn_Command_Refresh_Click(object sender, System.EventArgs e)
        {
            lsBox_StepWorkflow_SelectedValueChanged(null, null);
           // DoClear();
        }

        private void grvCommand_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            modelCurrent = grvCommand.GetFocusedRow<MobileOperationCommands>();
            DoFill();
        }

        private void grvCommand_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            modelCurrent = grvCommand.GetFocusedRow<MobileOperationCommands>();
            DoFill();
        }
        private void grvCommand_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            modelCurrent = grvCommand.GetFocusedRow<MobileOperationCommands>();
            DoFill();
        }
        private void ckbGioiHanThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            txtDen.Enabled = txtTu.Enabled = ckbGioiHanThoiGian.Checked;
        }

        private void ckbHienThiIcon_CheckedChanged(object sender, EventArgs e)
        {
            lueIcon.Enabled = ckbHienThiIcon.Checked;
        }

        private void ckbAmThanh_CheckedChanged(object sender, EventArgs e)
        {
            lueAudio.Enabled = ckbAmThanh.Checked;
        }
        private void grvCommand_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Column.FieldName == "CommandName")
            {
                try
                {
                    var row = grvCommand.GetRow(e.RowHandle).As<MobileOperationCommands>();
                    if (row != null)
                    {
                        e.Appearance.BackColor = Color.FromArgb(row.BackgroundColor);
                        e.Appearance.ForeColor = Color.FromArgb(row.ForeColor);
                    }
                    
                }catch{}               
            }
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ClearMsg > 0) ClearMsg--;
            else
            {
                lblMsg.Text = "";
                timer1.Stop();
            }
                
        }
        private void btnDongBoLenhServer_Click(object sender, EventArgs e)
        {
            try{
                if (new MessageBox.MessageBoxBA().Show("Bạn có muốn đồng bộ lênh lên server không?").ToUpper() == "YES".ToUpper())
                {
                    var _DataDataWorkflow = new List<DataDataWorkflow>();
                    var _DataDataStepWorkflow = new List<DataDataStepWorkflow>();
                    var _DataDataCommand = new List<DataDataCommand>();
                    // Get Data
                    _DataDataStepWorkflow = MobileOperationStepWorkflows.Inst.GetAll().ToList<DataDataStepWorkflow>();
                    _DataDataWorkflow = MobileOperationWorkflows.Inst.GetAll().ToList<DataDataWorkflow>();
                    _DataDataCommand = MobileOperationCommands.Inst.GetAll().ToList<DataDataCommand>();
                    // đồng bộ lên server
                    Service_Common.ServerCenter.Try(p => p.SyncCommand(ThongTinCauHinh.CompanyID.ToString(), _DataDataWorkflow.ToArray(), _DataDataStepWorkflow.ToArray(), _DataDataCommand.ToArray()));
                    new MessageBox.MessageBoxBA().Show("Quá trình đồng bộ thành công");
                }
               
            }catch(Exception ex){
                LogError.WriteLogError("DongBoLenhServer",ex);
                new MessageBox.MessageBoxBA().Show("Quá trình đồng bộ xảy ra lỗi");
            }
           
        }
      
        private void frmMobileOperationCommands_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            CommonBL.UpdateMobileCommand();
        }

        
        #endregion



    }
}
