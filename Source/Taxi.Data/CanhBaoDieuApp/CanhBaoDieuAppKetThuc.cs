using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.CanhBaoDieuApp
{
    [TableInfo(TableName = "T_CANHBAO_DIEUAPP_KETTHUC")]
    public class CanhBaoDieuAppKetThuc : DbEntityBase<CanhBaoDieuAppKetThuc>
    {
        #region==Properties==
        [Field( IsKey = true)]
        public long Id { get; set; }
        [Field]
        public long IdCuocGoi { get; set; }
        [Field]
        public Guid BookId { get; set; }
        [Field]
        public string NoiDung { get; set; }
        [Field]
        public string NoiDungXuLy { get; set; }
        [Field]
        public string SoDienThoai { get; set; }
        [Field]
        public string DiaChiDon { get; set; }
        [Field]
        public string SoXe { get; set; }
        [Field]
        public DateTime ThoiGianNhan { get; set; }
        [Field]
        public int Line { get; set; }
        [Field]
        public string NguoiNhan { get; set; }
        [Field]
        public DateTime ThoiGianXuLy { get; set; }
        [Field]
        public string NguoiXuLy { get; set; }
        [Field]
        public int TrangThai { get; set; }
        [Field]
        public int Type { get; set; }
        #endregion

        #region==Method==
        public List<CanhBaoDieuAppKetThuc> GetData()
        {
            if (GetAll().ToList<CanhBaoDieuAppKetThuc>().Count > 0)
            {
                return GetAll().ToList<CanhBaoDieuAppKetThuc>();
            }
            return null;

        }
        #endregion
    }
}
