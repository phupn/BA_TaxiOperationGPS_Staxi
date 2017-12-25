#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    /// <summary>
    /// Thói quen khách hàng
    /// </summary>
    [TableInfo(TableName = _Table)]
    public class CustomerHabits : DbEntityBase<CustomerHabits>
    {
        #region ==== Const ====
        private const string _Table = "[T_Staxi_CustomerHabits]";
        private const string _sp_Staxi_CustomerHabit_Update = "sp_Staxi_CustomerHabit_Update";
        #endregion

        #region ==== Field ==== 
        [Field(IsIdentity=true,IsKey=true)]
        public int Id { get; set; }
        [Field]
        public string PhoneNumber { get; set; }
        [Field]
        public int Days { get; set; }
        [Field]
        public TimeSpan Times { get; set; }
        [Field]
        public string Address { get; set; }
        [Field]
        public int Counts { get; set; }
        [Field]
        public int Levels { get; set; }
        [Field]
        public DateTime LastDateUpdate { get; set; }
        #endregion

        #region ==== Function ==== 
        public static void Update(string phoneNumber, int Days, TimeSpan Times, string Address)
        {
            Inst.ExeStoreNoneQuery(_sp_Staxi_CustomerHabit_Update, phoneNumber, Days, Times, Address);
        }

        #endregion
    }
}

