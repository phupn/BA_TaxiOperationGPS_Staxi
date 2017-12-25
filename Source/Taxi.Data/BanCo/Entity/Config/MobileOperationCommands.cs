using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.Config
{
    /// <summary>
    /// Thực hiện công việc
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// HauNV  25/08/2015   created
    /// </Modified>
    [TableInfo(TableName = "[Staxi.MobileOperationCommands]")]
    public class MobileOperationCommands:DbConnections.TaxiOperationDbEntityBase<MobileOperationCommands>
    {
        #region Field
        [ValueField]
        [Field(IsIdentity = true, IsKey = true)]
        public int PK_CommandID{get;set;}
        [Field]
        public int FK_MobileOperationStepWorkflowID{get;set;}
        [Field]
        public int FK_CompanyID { get; set; }
        /// <summary>
        /// Tên lệnh
        /// </summary>
        [ColumnField]
        [DisplayField]
        [Field]
        public string CommandName { get; set; }
        /// <summary>
        /// câu lệnh có kiểm soát thời gian
        /// </summary>
        [Field]
        public bool HasLimitedTime { get; set; }
        /// <summary>
        /// Sử dụng khi HasLimitedTime = true, số phút giới hạn
        /// </summary>
        [Field]
        public int FromMinutes { get; set; }
        /// <summary>
        /// Sử dụng khi HasLimitedTime = true, số phút giới hạn lớn nhất. Vượt qua thì cảnh báo 
        /// </summary>
        [Field]
        public int ToMinutes { get; set; }
        /// <summary>
        /// Mức độ ưu tiên ( 0,1,2,3,..,99). Càng lớn càng ưu tiên. 99 : cao nhất , hiển thị popup và bắt buộc đọc
        /// </summary>
        [Field]
        public int Priority { get; set; }
        /// <summary>
        /// Phát âm thanh khi gặp lệnh này
        /// </summary>
        [Field]
        public bool HasAlarmVoice { get; set; }
        /// <summary>
        /// File âm thanh phát cảnh báo
        /// </summary>
        [Field]
        public string VoiceAlarm { get; set; }
        /// <summary>
        /// Màu nên của lệnh
        /// </summary>
        [Field]
        public int BackgroundColor { get; set; }
        /// <summary>
        /// Màu chữ của lệnh
        /// </summary>
        [Field]
        public int ForeColor { get; set; }
        /// <summary>
        /// Tên icon
        /// </summary>
        [Field]
        public string Icon { get; set; }
        /// <summary>
        /// True mặc định : hiển thị icon menu, 
        /// </summary>
        [Field]
        public bool IsShow { get; set; }
        /// <summary>
        /// Thứ tự hiển thị menu trong cùng một bước của luồng
        /// </summary>
        [Field]
        public int Order { get; set; }
        [Field]
        public bool IsReadyRecieveCustomer { get; set; }
        /// <summary>
        /// Tên file sẽ phát ghép âm thanh khi về client.
        /// </summary>
        [Field]
        public string SpeechSynthesizerVoice { get; set; }
        [Field]
        public bool IsSystemCommand { get; set; }
        /// <summary>
        /// Phim tat
        /// </summary>
        [Field]
        public int PMDH_Shortcuts { get; set; }

        /// <summary>
        /// Trang thai cuoc goi enum TrangThaiCuocGoi
        /// </summary>
        [Field]
        public int? PMDH_CallStatus { get; set; }

        /// <summary>
        /// Trang thai lenh (enum TrangThaiLenh)
        /// </summary>
        [Field]
        public int? PMDH_Status { get; set; }

        /// <summary>
        /// Kieu cuoc goi (enum KieuCuocGoi)
        /// </summary>
        [Field]
        public int? PMDH_CallType { get; set; }
        /// <summary>
        /// Lenh cha (la lenh dieu hanh khi phan hoi lai lenh con)
        /// </summary>
        [Field]
        public string PMDH_ParentCommand { get; set; }

        /// <summary>
        /// Mau nen cha (mau nen khi lenh con da duoc phan hoi)
        /// </summary>
        [Field]
        public string PMDH_ParentColor { get; set; }

        /// <summary>
        /// Check co ton tai xe nhan
        /// </summary>
        [Field]
        public bool PMDH_RequireVehicle { get; set; }

        /// <summary>
        /// Bo phan nao su dung enum Enum_ChucNangNhiemVu
        /// </summary>
        [Field]
        public int PMDH_FunctionUsing { get; set; }
        /// <summary>
        /// Gửi hàm nào cho lái xe.
        /// </summary>
        [Field]
        public int PMDH_SendDriver { get; set; }
        [Field]
        public bool IsDelete { get; set; }
        [Field]
        public string CreatedByUser { get; set; }
        [Field]
        public DateTime? CreatedDate { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
        public int FK_WorkflowID { get; set; }
        #endregion

        #region Proc
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        public override void Save()
        {
            ExeStoreNoneQuery("sp_Staxi_MobileOperationCommand_Save", PK_CommandID, FK_MobileOperationStepWorkflowID,FK_CompanyID,
                                                                    CommandName, HasLimitedTime, FromMinutes, ToMinutes, Priority,
                                                                    HasAlarmVoice, VoiceAlarm, BackgroundColor, ForeColor, Icon, IsShow,
                                                                    Order, IsReadyRecieveCustomer, SpeechSynthesizerVoice, IsSystemCommand,
                                                                    PMDH_Shortcuts, PMDH_CallStatus, PMDH_Status, PMDH_CallType, PMDH_ParentCommand, PMDH_ParentColor, PMDH_RequireVehicle,
                                                                    PMDH_FunctionUsing, PMDH_SendDriver, IsDelete, CreatedByUser, UpdatedByUser);
        }

        /// <summary>
        /// Gets the list by identifier step workflow.
        /// </summary>
        /// <param name="IdStepWorkflow">The identifier step workflow.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  25/08/2015   created
        /// </Modified>
        public List<MobileOperationCommands> GetListByIdStepWorkflow(int IdStepWorkflow)
        {
            return ExeStore("sp_Staxi_MobileOperationCommand_GetListByIdStepWorkflow", IdStepWorkflow).ToList<MobileOperationCommands>();
        }
        /// <summary>
        /// Gets the list by workflow identifier.
        /// </summary>
        /// <param name="WorkflowId">The workflow identifier.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  07/09/2015   created
        /// </Modified>
        public List<MobileOperationCommands> GetListByWorkflowId(int WorkflowId)
        {
            return ExeStore("sp_Staxi_MobileOperationCommand_GetListByWorkflowId", WorkflowId).ToList<MobileOperationCommands>();
        }
        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  25/08/2015   created
        /// </Modified>
        public void DeleteById(int id)
        {
            ExeStoreNoneQuery("sp_Staxi_MobileOperationCommand_DeleteById", id);
        }
        public override System.Data.DataTable GetAll()
        {
            return ExeStore("sp_Staxi_MobileOperationCommand_GetAll");
        }
        public List<MobileOperationCommands> GetListAll()
        {
            return GetAll().ToList<MobileOperationCommands>();
        }
        #endregion
    }
}
