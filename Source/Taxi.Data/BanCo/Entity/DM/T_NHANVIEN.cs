using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;


namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_NHANVIEN")]
    public class T_NHANVIEN : TaxiOperationDbEntityBase<T_NHANVIEN>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public string PK_MaNhanVien { get; set; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Tên nhân viên")]
        public string TenNhanVien { get; set; }

        [Field]
        public DateTime NgaySinh { get; set; }

        [Field]
        public string GioiTinh { get; set; }

        [Field]
        public string SoCMT { get; set; }

        [Field]
        public string DiaChi { get; set; }

        [Field]
        public string DienThoai { get; set; }

        [Field]
        public string DiDong { get; set; }

        [Field]
        public string Email { get; set; }

        [Field]
        public string VanBang { get; set; }

        [Field]
        public int FK_PhongID { get; set; }

        [Field]
        public int FK_ChucVu { get; set; }

        [Field]
        public string FK_SoHieuXeLai { get; set; }
       
        [Field]
        public string SoTheLaiXe { get; set; }

        [Field]
        public bool IsLaiXe { get; set; }

        [Field]
        public string ShortName { get; set; }

        [Field]
        public DateTime NgayVaoCty { get; set; }

        [Field]
        public DateTime NgayHetHan { get; set; }

        [Field]
        public DateTime NgayNghiLam { get; set; }

        [Field]
        public string HangBang { get; set; }

        [Field]
        public bool IsThamGiaBHXH { get; set; }
        [Field]
        public bool IsDelete { get; set; }
        public string SoHieuXe { get; set; }
        public string BienSoXe { get; set; }
        public string Gara { get; set; }
        public string TenLoaiXe { get; set; }
        public DateTime LastUpdate { get; set; }
        [Field]
        public Enum_SystemType SystemType { get; set; }
        /// <summary>
        /// Gets the viet tat.
        /// Thực hiện lấy ký tự đầu trong tên nhân viên
        /// Ví dụ:Nguyễn Văn Hậu ->nvh
        /// </summary>
        /// <value>
        /// The viet tat.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/17/2014   created
        /// </Modified>
        public string VietTat
        {
            get
            {
                if (TenNhanVien.IsNotNull())
                {
                    if (this.ShortName.Trim() != "")
                    {
                        return string.Format("{0}-{1}", this.ShortName.Trim().ToLower(), TenNhanVien.To<string>().ToLower());
                    }
                    var ten = TenNhanVien.To<string>().ToLower().Split(' ');
                    var tentat = ten.Where(s => s.Trim() != "" && s.Trim().Length > 0).Aggregate("", (current, s) => current + s.Trim().Substring(0, 1));
                    return string.Format("{0}-{1}", tentat.ToLower(), TenNhanVien.ToLower());
                }
                return string.Empty;

            }
        }
        #endregion

        public List<T_NHANVIEN> GetListAll() {
            return GetALLNHanVien().ToList<T_NHANVIEN>();
        }

        public DataTable GetALLNHanVien() {
            return ExeStore("sp_T_NHANVIEN_GETALL");
        }

        /// <summary>
        /// Danh sách nhân viên đang còn làm việc
        /// </summary>
        /// <returns></returns>
        public List<T_NHANVIEN> GetAllNhanVien_DangConLam()
        {
            return ExeStore("sp_T_NHANVIEN_GETALL_DangConLam").ToList<T_NHANVIEN>();
        }

        /// <summary>
        /// Danh sách nhân viên đang kinh doanh
        /// </summary>
        /// <returns></returns>
        public List<T_NHANVIEN> GetAllDriver_Active()
        {
            return ExeStore("sp_T_NHANVIEN_GETALL_Active").ToList<T_NHANVIEN>();
        }

        /// <summary>
        /// Danh sách nhân viên đang kinh doanh theo thời gian
        /// </summary>
        /// <returns></returns>
        public List<T_NHANVIEN> GetAllDriver_Active_GetLast(DateTime Driver_LastUpdate)
        {
            return ExeStore("sp_T_NHANVIEN_GETALL_Active_GetLast", Driver_LastUpdate).ToList<T_NHANVIEN>();
        }

        public int InsertNhanVien(params object[] para) {
            return ExeStoreNoneQuery("sp_T_NHANVIEN_Insert", para);
        }

        public int UpdateNhanVien(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_NHANVIEN_Update", para);
        }

        /// <summary>
        /// Cập nhật lại tên nhân viên cho các bảng khác
        /// </summary>
        /// <param name="para">
        /// @TenNhanVien, @PK_MaNhanVien
        /// </param>
        /// <returns></returns>
        public int UpdateNhanVien_TenNhanVien(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_NHANVIEN_Update_TenNhanVien", para);
        }

        public bool CheckTrungTenNhanVien(string TenNhanVien) {
            var dt = ExeStore("sp_T_NHANVIEN_CheckTrungTen", TenNhanVien);
            return dt != null && dt.Rows.Count > 0;
        }

        public bool CheckTrungMaNV(string MaNhanVien)
        {
            var dt = ExeStore("sp_T_NHANVIEN_CheckTrungMaNV", MaNhanVien);
            return dt != null && dt.Rows.Count > 0;
        }


        /// <summary>
        /// Lấy ra nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="MaNhanVien">The ma nhan vien.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  20/09/2014   created
        /// </Modified>
        public T_NHANVIEN GetNhanVienTheoMa(string MaNhanVien)
        {
            var dt = ExeStore("sp_T_NHANVIEN_GetNhanVienTheoMa", MaNhanVien);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.ToList<T_NHANVIEN>().FirstOrDefault();
            }
            return null;
        }

        /// <summary>
        /// Xóa lái xe
        /// = 1 : xóa thành công
        /// = 0 : lái xe đang khai báo ra kd
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int DeleteNhanVien(params object[] para) {
            var result = ExeStoreNoneQueryWithOutput("sp_T_NHANVIEN_Delete", para);
            return result.Value["Output"].To<int>();
        }

        //public override DataTable GetAll()
        //{
        //    return ExeStore("sp_T_NHANVIEN_GETALL");
        //}
    }
}
