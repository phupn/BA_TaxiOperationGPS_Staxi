using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.CanhBaoDieuApp
{
    [TableInfo(TableName = "T_CANHBAO_DIEUAPP")]
    public class CanhBaoDieuApp : DbEntityBase<CanhBaoDieuApp>
    {
        #region==Properties==
        [Field(IsIdentity=true, IsKey = true)]
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
        /// <summary>
        /// Enum_G5_PMDH_CanhBaoApp_Type
        /// </summary>
        [Field]
        public int Type { get; set; }
        [Field]
        public int CmdId { get; set; }
        #endregion

        #region==Method==
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        public List<CanhBaoDieuApp> GetAllData(string line)
        {
            return ExeStore("G5_sp_CanhBaoDieuApp_GetAllData_V1", line).ToList<CanhBaoDieuApp>();
        }
        /// <summary>
        /// Kiểm tra các bản ghi mới thêm vào
        /// </summary>
        public List<CanhBaoDieuApp> KiemTraBanGhiThayDoiVaThemMoi(string line,DateTime thoiDiemTruocThayDoiDuLieu)
        {
            return ExeStore("sp_BaSao_CanhBaoDieuApp_GetByLine", line, thoiDiemTruocThayDoiDuLieu).ToList<CanhBaoDieuApp>();
        }
        /// <summary>
        /// Kiểm tra các bản ghi bị xóa
        /// </summary>
        public DataTable KiemTraCacBanGhiXoa(string line,string lsid)
        {
            return ExeStore("sp_BaSao_CanhBaoDieuApp_CheckRecordDeleted", line, lsid);
        
        }
        public int KetThucCanhBao(long id, string noiDungXuLy)
        {
            return ExeStoreNoneQuery("sp_BaSao_CanhBaoDieuApp_End", id, noiDungXuLy);
        }
        public int CheckCanhBaoQuaGio()
        {
            return ExeStoreNoneQuery("sp_BaSao_CanhBaoDieuApp_CheckCanhBaoQuaGio");
        }
        #endregion


        public bool CheckTrungCanhBao(long pIDCuoc, string pContent)
        {
            int result = 0;
            var temp = ExeStoreNoneQueryWithOutput("sp_CanhBaoDieuApp_CheckTrung", pIDCuoc, pContent, result);
            result = temp.Value["pResult"].To<int>();
            if (result == 0)
                return true;
            else
                return false;
        }
    }
}
