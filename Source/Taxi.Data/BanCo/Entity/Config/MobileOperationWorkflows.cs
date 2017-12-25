using System;
using Taxi.Common.DbBase.Attributes;
namespace Taxi.Data.BanCo.Entity.Config
{
    /// <summary>
    /// Nhóm công việc
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// HauNV  25/08/2015   created
    /// </Modified>
    [TableInfo(TableName="[Staxi.MobileOperationWorkflows]")]
    public class MobileOperationWorkflows : DbConnections.TaxiOperationDbEntityBase<MobileOperationWorkflows>
    {
        #region Field
        
        [ValueField]
        [Field(IsIdentity=true,IsKey=true)]
        public int PK_WorkflowID { get; set; }
        [Field]
        public int FK_CompanyID { get; set; }
        [ColumnField]
        [DisplayField]
        [Field]
        public string WorkflowName { get; set; }
        [Field]
        public string Descriptions { get; set; }
        [Field]
        public bool IsActive { get; set; }
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
        #endregion 

        #region Proc
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
            ExeStoreNoneQuery("sp_Staxi_MobileOperationWorkflow_DeleteById", id);
        }
        public override System.Data.DataTable GetAll()
        {
            return ExeStore("sp_Staxi_MobileOperationWorkflow_GetAll");
        }
        #endregion
    }
}
