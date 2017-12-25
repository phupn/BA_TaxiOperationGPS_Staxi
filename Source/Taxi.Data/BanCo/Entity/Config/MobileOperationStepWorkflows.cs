using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.Config
{
    /// <summary>
    /// Các bước công việc
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// HauNV  25/08/2015   created
    /// </Modified>
    [TableInfo(TableName = "[Staxi.MobileOperationStepWorkflows]")]
    public class MobileOperationStepWorkflows:DbConnections.TaxiOperationDbEntityBase<MobileOperationStepWorkflows>
    {
        #region Field
        [Field(IsIdentity = true, IsKey = true)]
        public int PK_StepWorkflowID{get;set;}
        [Field]
        public int FK_CompanyID { get; set; }
        [Field]
        public int FK_WorkflowID { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public string Description { get; set; }
        [Field]
        public bool IsStart { get; set; }
        [Field]
        public bool IsEnd { get; set; }
        [Field]
        public bool IsCommon { get; set; }
        [Field]
        public bool IsActive { get; set; }
        [Field]
        public int Order { get; set; }
        [Field]
        public string CreatedByUser { get; set; }
        [Field]
        public DateTime? CreatedDate { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
        public int Step { get; set; }
        public string NameStep { get { return string.Format("{0}.{1}", Step, Name); } }
        #endregion

        #region Proc
        
        public override void Save()
        {
            ExeStoreNoneQuery("sp_Staxi_MobileOperationStepWorkflow_Save");
        }


        /// <summary>
        /// Gets the list by identifier workflows.
        /// </summary>
        /// <param name="IdWorkflows">The identifier workflows.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  25/08/2015   created
        /// </Modified>
        public List<MobileOperationStepWorkflows> GetListByIdWorkflows(int IdWorkflows)
        {
            return ExeStore("sp_Staxi_MobileOperationStepWorkflows_GetListByIdWorkflows", IdWorkflows).ToList<MobileOperationStepWorkflows>();
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
            ExeStoreNoneQuery("sp_Staxi_MobileOperationStepWorkflow_DeleteById", id);
        }
        public void Up(int id, int wordflowId)
        {
            ExeStoreNoneQuery("sp_Staxi_MobileOperationStepWorkflow_Up", id, wordflowId);
        }
        public void Down(int id, int wordflowId)
        {
            ExeStoreNoneQuery("sp_Staxi_MobileOperationStepWorkflow_Down", id, wordflowId);
        }
        public override System.Data.DataTable GetAll()
        {
            return ExeStore("sp_Staxi_MobileOperationStepWorkflow_GetAll");
        }

        #endregion
    }
}
