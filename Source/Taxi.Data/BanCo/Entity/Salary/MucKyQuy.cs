using Taxi.Data.BanCo.DbConnections;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using Taxi.Common.Extender;
using Taxi.Common.DbBase.Attributes;
using System.Data;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// Mức ký quỹ
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PhongNC  12/09/2014   created
    /// </Modified>
    [TableInfo(TableName = "Luong_MucKyQuy")]
    public class MucKyQuy : TaxiOperationDbEntityBase<MucKyQuy>
    {
        public int STT { get; set; }

        [Field(IsKey = true, IsIdentity = false)]
        public int FK_LoaiXe { get; set; }

        public string TenLoaiXe { get; set; }

        [Field]
        public decimal SoTienKyQuy { get; set; }

        public decimal SoTienKyQuy2
        {
            get
            {
                if (SoTienKyQuy % 1 == 0) //nếu ko có phần thập phân
                {
                    return Math.Round(SoTienKyQuy, 0);
                }
                return Math.Round(SoTienKyQuy, 2);
            }
        }

        [Field]
        public bool IsHuongCoDinh { get; set; }

        public string LoaiHuong
        {
            get
            {
                if(IsHuongCoDinh)
                    return "Hưởng cố định";
                return "Hưởng theo phần trăm";
            }
        }

        [Field]
        public decimal SoTienHuong { get; set; }

        public string SoTienHuongStr
        {
            get
            {
                if (SoTienHuong == 0) 
                {
                    return string.Empty;
                }
                if (SoTienHuong % 1 == 0) //nếu ko có phần thập phân
                {
                    return Math.Round(SoTienHuong, 0).ToString();
                }
                return Math.Round(SoTienHuong, 2).ToString();
            }
        }

        [Field]
        public float PhanTramHuong { get; set; }

        public string PhanTramHuongStr
        {
            get
            {
                if (PhanTramHuong == 0)
                {
                    return string.Empty;
                }
                if (PhanTramHuong % 1 == 0) //nếu ko có phần thập phân
                {
                    return Math.Round(PhanTramHuong, 0).ToString();
                }
                return Math.Round(PhanTramHuong, 2).ToString();
            }
        }

        [Field]
        public string CreatedByUser { get; set; }

        [Field]
        public SqlDateTime CreatedDate { get; set; }

        public string CreatedDateStr
        {
            get
            {
                return CreatedDate.IsNull == true ? string.Empty : string.Format("{0:dd/MM/yyyy}", CreatedDate.Value);
            }
        }

        [Field]
        public string UpdatedByUser { get; set; }

        [Field]
        public SqlDateTime UpdatedDate { get; set; }

        public string UpdatedDateStr
        {
            get
            {
                return UpdatedDate.IsNull == true ? string.Empty : string.Format("{0:dd/MM/yyyy}", UpdatedDate.Value);
            }
        }

        /// <summary>
        /// Tìm kiếm theo loại xe và có phải là hưởng cố định ko
        /// </summary>
        /// <param name="fkLoaiXe"></param>
        /// <param name="isHuongCoDinh"></param>
        /// <returns></returns>
        public List<MucKyQuy> GetByLoaiXeVaHuong(int fkLoaiXe, bool? isHuongCoDinh)
        {
            try
            {
                return ExeStore("Luong_MucKyQuy_Search", fkLoaiXe, isHuongCoDinh).ToList<MucKyQuy>();
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Lấy ra list mức kỹ quỹ
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  19/09/2014   created
        /// </Modified>
        public List<MucKyQuy> GetListAll()
        {
            return base.GetAll().ToList<MucKyQuy>();
        }

        /// <summary>
        /// Kiểm tra xem loại xe đã tồn tại mức ký quỹ hay chưa
        /// </summary>
        /// <param name="loaiXeID">The loai xe identifier.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  19/09/2014   created
        /// </Modified>
        public bool TonTaiMucKQ(int loaiXeID)
        {
            DataTable dt = ExeStore("Luong_MucKyQuy_TonTai", loaiXeID);
            if (dt.Rows.Count > 0)
            {
                int number;
                int.TryParse(dt.Rows[0][0].ToString(), out number);
                if(number > 0) return true;
            }
            return false;
        }
    }
}
