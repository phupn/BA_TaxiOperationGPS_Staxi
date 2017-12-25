using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[T_LoaiLoiViPham]")]
    public class LoaiLoiViPham : DbEntityBase<LoaiLoiViPham>
    {
        [ValueField]
        [Field(IsIdentity=true,IsKey=true)]
        public int Id { get; set; }
        [ColumnField(ColumnName="")]
        [DisplayField]
        [Field]
        public string TenLoaiLoiViPham { get; set; }
    }

    [TableInfo(TableName = "[T_LoiViPham]")]
    public class LoiViPham : DbEntityBase<LoiViPham>
    {
        [Field(IsIdentity = true, IsKey = true)]
        public int Id { get; set; }
        [Field]
        public DateTime TuNgay { get; set; }
        [Field]
        public DateTime DenNgay { get; set; }
        [Field]
        public string SoXe { get; set; }
        [Field]
        public int FK_LoaiLoiViPham { get; set; }
        public string TenLoaiLoiViPham { get; set; }
        [Field]
        public string GhiChu { get; set; }
        [Field]
        public string CreateBy { get; set; }
        [Field]
        public DateTime CreateDate { get; set; }
        public List<LoiViPham> TimKiem(DateTime start, DateTime end, string SoXe)
        {
          return ExeStore("sp_LoiViPham_TimKiem", start, end, SoXe).ToList<LoiViPham>();
        }
        /// <summary>
        /// Check xe vi phạm
        /// >0:xe tồn tại lỗi vi phạm và chưa được phép nhập xe đón.
        /// =0:được phép
        /// </summary>
        /// <param name="soXe"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool CheckXeViPham(string soXe,DateTime date)
        {
            return ExeStore("sp_LoiViPham_CheckXeViPham", soXe, date).Rows[0][0].To<int>() > 0;
        }
        public string GetXeViPham(string lsXe, DateTime date)
        {
            var dt = ExeStore("sp_LoiViPham_GetXeViPham", lsXe, date);
            if (dt.Rows.Count == 0) return string.Empty;
            string soxe = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                soxe += dt.Rows[i][0].To<string>()+",";
            }
            return soxe.TrimEnd(',');
        }
    }
   
}
