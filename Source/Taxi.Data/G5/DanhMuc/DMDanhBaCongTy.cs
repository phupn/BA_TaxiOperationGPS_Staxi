using System;
#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using System.Collections.Generic;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = TableName)]
    public class DMDanhBaCongTy : DbEntityBase<DMDanhBaCongTy>
    {
        private const string TableName = "T_DANHBA_CONGTY";
        private const string sp_T_DANHBA_CONGTY_GetData = "sp_T_DANHBA_CONGTY_GetData";
        private const string sp_T_DANHBA_CONGTY_Save = "sp_T_DANHBA_CONGTY_Save";
        #region===Field===
        [Field(IsKey = true)]
        public string PhoneNumber { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public string Address { get; set; }
        [Field]
        public bool isAuto { get; set; }
        [Field]
        public DateTime? UpdatedDate
        {
            get;
            set;
        }

        #endregion

        #region===Methods===
        public static List<DMDanhBaCongTy> GetData(string PhoneNumber, string Name, string Address)
        {
            return Inst.ExeStore(sp_T_DANHBA_CONGTY_GetData, PhoneNumber, Name, Address).ToList<DMDanhBaCongTy>();
        }

        /// <summary>
        /// Check xem sdt có tồn tại trong danh mục nào không
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>
        /// 0 : không tồn tại
        /// 1 : Trong danh bạ công ty
        /// 2 : Trong danh bạ khách ảo
        /// 3 : Trong danh bạ khách hàng
        /// </returns>
        public static int GetDanhBa_ByPhoneNumber(string phoneNumber)
        {
            var returnValue = 0;
            var result = Inst.ExeStoreNoneQueryWithOutput("sp_T_DANHBA_CONGTY_Select_Type", phoneNumber, returnValue);
            if (result != null)
            {
                returnValue = result.Value["Type"].To<int>();
            }
            return returnValue;
        }

        public bool SaveDanhBa(string PhoneNumber, string Name, string Address)
        {
            return ExeStoreNoneQuery("", PhoneNumber, Name, Address) > 0;
        }

        public override void Save()
        {
            ExeStoreNoneQuery(sp_T_DANHBA_CONGTY_Save);
        }
        #endregion
    }
}
