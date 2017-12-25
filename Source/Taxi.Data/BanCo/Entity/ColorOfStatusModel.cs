using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity
{

    [TableInfo(TableName = "BanCo_MauSacTrangThai")]
    public class ColorOfStatusModel : TaxiOperationDbEntityBase<ColorOfStatusModel>
    {
        #region Properties
        private SqlInt16 m_Id = SqlInt16.Null;
        [Field(IsKey = true, IsIdentity = true)]
        public SqlInt16 Id
        {
            set { m_Id = value; }
            get { return m_Id; }
        }

        private SqlString m_StatusName = SqlString.Null;
        [Field]
        public SqlString StatusName
        {
            set { m_StatusName = value; }
            get { return m_StatusName; }
        }

        private SqlString m_Color = SqlString.Null;
        [Field]
        public SqlString Color
        {
            set { m_Color = value; }
            get { return m_Color; }
        }

        private SqlString m_Description = SqlString.Null;
        [Field]
        public SqlString Description
        {
            set { m_Description = value; }
            get { return m_Description; }
        }

        [Field]
        public string BackColor { get; set; }
        #endregion

        #region Method
        public List<ColorOfStatusModel> GetAllData()
        {
            return GetAll().ToList<ColorOfStatusModel>();
        }

        public DataTable GetAllData_Datatable()
        {
            return GetAll();
        }

        public void ShTest()
        {
            var p1 = 0;
            var p2 = 0;
            var result = this.ExeStoreNoneQueryWithOutput("sh_Test", p1,p2);

            p2 = result.Value["p2"].To<int>();
        }

        /// <summary>
        /// Thực hiện mở rộng việc Validate
        /// </summary>
        /// <returns></returns>
        //public ValidatorMessage Validate()
        //{
        //    // Nếu null thì return luôn không cần check
        //    if (this.StateCall.IsNull()) return new ValidatorMessage { Status = ValidatorStatus.Valid };

        //    // Lấy ra Attribute để thực hiện validate
        //    var vs = EnumHandler<Enums.StateCall>.Inst.GetAttribute<ValidateStateCallAttribute>((StateCall)this.StateCall.Value);

        //    // Nếu không có Attribute để validate thì thôi không cần
        //    if (vs.IsNull()) return new ValidatorMessage { Status = ValidatorStatus.Valid };

        //    // Lấy kết quả validate
        //    vs.Validate(this);

        //    // return kết quả
        //    return vs.Validator;
        //}
        #endregion
    }
}
