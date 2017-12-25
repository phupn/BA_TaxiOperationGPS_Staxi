using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Common.DbBase.Attributes;
using Taxi.Data.BanCo.DbConnections;
using System.Data;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.TuyenThueBao
{
    [TableInfo(TableName = "[THUEBAO.T_TUYENDUONG]")]
    public class DMTuyenThueBao : TaxiOperationDbEntityBase<DMTuyenThueBao>
    {

        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public string TuyenDuongID { get; set; }

        // [Field]
        
        public string TypeName { get; set; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Tên tuyến")]
        public string TenTuyenDuong { set; get; }

        [Field]
        public string VietTat { set; get; }

        public string TenDuongMoi { set; get; }

        /// <summary>
        /// Số thứ tự bản ghi
        /// </summary>
        public int STT { get; set; }

        /// <summary>
        /// Chiều của tuyến, là 1 hay 2 chiều
        /// </summary>
        public int Chieu { get; set; }
        
        /// <summary>
        /// Id chạy tuyến
        /// </summary>
        public int IdChayTuyen { get; set; }

        #region form Tuyen thue bao

        public List<DMTuyenThueBao> getDMTuyenDuong(params object[] para)
        {
           // return getAllTuyenDuong().ToList<DMTuyenThueBao>();
            return getAllTuyenDuongByChieu(para).ToList<DMTuyenThueBao>();
        }

        public List<DMTuyenThueBao> getDMTuyenDuongMoi(params object[] para)
        {
          //  List<DMTuyenThueBao> listRet = new List<DMTuyenThueBao>();
            List<DMTuyenThueBao> listTG = getDMTuyenDuong(para).ToList<DMTuyenThueBao>();
  
            foreach (DMTuyenThueBao obj in listTG)
            {
                if (String.IsNullOrEmpty(obj.VietTat))
                    obj.TenDuongMoi = obj.TenTuyenDuong;
                else
                    obj.TenDuongMoi = String.Format("{0}_{1}", obj.VietTat, obj.TenTuyenDuong);
            }

            return listTG;
        }

        public List<DMTuyenThueBao> getDMKieuTuyen()
        {
            return getAllKieuTuyen().ToList<DMTuyenThueBao>();
        }


        public DataTable getAllTuyenDuong()
        {
            return ExeStore("T_TUYENDUONG_SelectAll");
        }

        /// <summary>
        /// Lấy tất cả tuyến đường có chiều(1 chiều và 2 chiều)
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  20/09/2014   created
        /// </Modified>
        public DataTable getAllTuyenDuongCoChieu()
        {
            return ExeStore("T_TUYENDUONG_SelectAllCoChieu");
        }

        /// <summary>
        /// Lấy list tất cả tuyến đường có chiều(1 chiều và 2 chiều)
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  20/09/2014   created
        /// </Modified>
        public List<DMTuyenThueBao> getListAllTuyenDuongCoChieu()
        {
            return ExeStore("T_TUYENDUONG_SelectAllCoChieu").ToList<DMTuyenThueBao>();
        }

        /// <summary>
        /// Lấy ra các thông tin của tuyến và bazem km, giá gốc từ số xe, chiều, tuyến đường
        /// </summary>
        public DataTable getBangGiaCuocTheoSoXeTuyenDuong(string soXe, int chieu, string tuyenduong)
        {
            return ExeStore("T_BANGGIACUOC_SelectAllBy_SoXe_Chieu_Tuyen", soXe, chieu, tuyenduong);
        }

        public DataTable getAllTuyenDuongByChieu(params object[] para)
        {
            return ExeStore("sp_T_TUYENDUONG_GetByChieu",para);
        }

        public int UpdateAllTuyenDuong(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUYENDUONG_Update_V3", para);

        }

        public int InsertTuyenDuong(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUYENDUONG_Insert_V3", para);
        }

        public int DeleteTuyenDuong(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TUYENDUONG_Delete_V3", para);
        }

        public DataTable SearchTuyenDuong(params object[] para)
        {
            return ExeStore("sp_T_TUYENDUONG_Search", para);
        }

        public DataTable getAllKieuTuyen()
        {
            return ExeStore("sp_T_KIEUTUYEN_SelectAll");
        }

        public DataTable getAllByChayTuyen(params object[] para)
        {
            return ExeStore("sp_T_KIEUTUYEN_GetByChayTuyen",para);
        }

        public List<DMTuyenThueBao> lSearchTD(params object[] para) {
            return SearchTuyenDuong(para).ToList<DMTuyenThueBao>();
        }

        #endregion
    }
}
