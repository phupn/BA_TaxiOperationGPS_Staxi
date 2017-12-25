using System.Data;
using System;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
namespace Taxi.Data.BanCo.Entity.CanhBaoXe
{
    [TableInfo(TableName = "BanCo_GiamSatXe_Notify")]
    public class CNotify : TaxiOperationDbEntityBase<CNotify>
    {
        #region properties
        private SqlInt64 m_id;
        [Field(IsKey = true, IsIdentity = true)]
        public SqlInt64 Id
        {
            get { return m_id; }
        }
        private SqlString m_soHieuXe;
        [Field]
        public SqlString SoHieuXe
        {
            get { return m_soHieuXe; }
            set { m_soHieuXe = value; }
        }
        private SqlString m_message;
        [Field]
        public SqlString Message
        {
            get { return m_message; }
            set { m_message = value; }
        }
        private SqlInt16 m_isRead;
        [Field]
        public SqlInt16 IsRead
        {
            get { return m_isRead; }
            set { m_isRead = value; }
        }
        private SqlInt32 m_timer;
        [Field]
        public SqlInt32 Timer
        {
            get { return m_timer; }
            set { m_timer = value; }
        }
        private SqlDateTime m_createdDate;
        [Field]
        public SqlDateTime CreatedDate
        {
            get { return m_createdDate; }
            set { m_createdDate = value; }
        }
        #endregion
        #region Method
        public DataTable getList()
        {
            return ExeStore("SP_BanCo_GiamSatXe_Notify");
        }
        public void LoadNotify()
        {
            try
            {
                ExeStoreNoneQuery("SP_BanCo_GiamSatXe_NotifyUpdate");
            }
            catch (System.Exception ex)
            {
                
            }
            
        }
        /// <summary>
        /// Thêm tự động vào bản lỗi vi phạm
        /// 1.Ăn ca quá giờ
        /// 2.Xe Mất liên lạc
        /// </summary>
        public void LoadViolateError()
        {
             try
            {
                ExeStoreNoneQuery("SP_BanCo_GiamSatXe_ViolateError");
            }
            catch 
            {
                
            }
          
        }

        public void DaXuLy(int id)
        {
            ExeStoreNoneQuery("SP_BanCo_GiamSatXe_Notify_DaXuLy", id);
        }

        public void XuLyBaoLai(int id)
        {
            ExeStoreNoneQuery("sp_BanCo_GiamSatXe_Notify_XuLyBaoLai", id);
        }

        public string GetXeKinhDoanh()
        {
            var dt = ExeStore("sp_GetXeKinhDoanh");
            return string.Format("{0}",dt.Rows[0][0]);
        }
        #endregion
    }
}