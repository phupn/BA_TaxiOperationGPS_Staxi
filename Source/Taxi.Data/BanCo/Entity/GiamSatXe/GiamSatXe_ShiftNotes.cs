using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using System.Data.SqlTypes;
using System.Data;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "BanCo_ShiftNotes")]
    public class GiamSatXe_ShiftNotes : TaxiOperationDbEntityBase<GiamSatXe_ShiftNotes>
    {
        private SqlInt64 m_id;
        [Field(IsKey = true, IsIdentity = true)]
        public SqlInt64 Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        private SqlString m_shift;
        [Field]
        public SqlString Shift
        {
            get { return m_shift; }
            set { m_shift = value; }
        }
        private SqlDateTime m_Time;
        [Field]
        public SqlDateTime Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }
        
        private SqlDateTime m_CreatedDate;
        [Field]
        public SqlDateTime CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }
        private SqlString m_Description;
        [Field]
        public SqlString Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        private SqlString m_CreatedByUser;
        [Field]
        public SqlString CreatedByUser
        {
            get { return m_CreatedByUser; }
            set { m_CreatedByUser = value; }
        }

        [Field]
        public DateTime? UpdatedDate { set; get; }
        [Field]
        public string UpdatedByUser { set; get; }

        public DataTable Find(DateTime Ngay, string Ca)
        {
            return ExeStore("SP_GiamSatXe_ShiftNotes", Ngay, Ca);
        }

        public DataTable GetToDay()
        {
            return ExeStore("SP_GiamSatXe_ShiftNotes", DateTime.Now, "C");
        }
    }
}
