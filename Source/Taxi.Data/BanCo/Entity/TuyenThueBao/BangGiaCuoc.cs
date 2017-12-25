using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Data.BanCo.DbConnections;
using System.Data;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.TuyenThueBao
{
    [TableInfo(TableName = "THUEBAO.T_BANGGIACUOC")]
    public class BangGiaCuoc: TaxiOperationDbEntityBase<BangGiaCuoc>
    {
        //public List<BangGiaCuoc> getList
        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }


        [Field]
        public string FK_TuyenDuongID { get; set; }

        [Field]
        public int FK_DiemXuatPhatID { get; set; }

        [Field]
        public int FK_LoaiXeID { get; set; }

        [Field]
        public float KmQuyDinh1Chieu { get; set; }

        [Field]
        public float ThoiGianQuyDinh1Chieu { get; set; }

        [Field]
        public float GiaTien1Chieu { get; set; }

        [Field]
        public float KmQuyDinh2Chieu { get; set; }

        [Field]
        public float ThoiGianQuyDinh2Chieu { get; set; }

        [Field]
        public float GiaTien2Chieu { get; set; }

        [Field]
        public float GiaDinhMucVuot1KmMotChieu { get; set; }

        [Field]
        public float GiaDinhMucVuot1GioMotChieu { get; set; }

        [Field]
        public float GiaDinhMucVuot1KmHaiChieu { get; set; }

        [Field]
        public float GiaDinhMucVuot1GioHaiChieu { get; set; }

        [Field]
        public int VeTram { get; set; }



        #region Bang gia cuoc
        public DataTable getTuyenByKieuTuyen(params object[] para)
        {
            return ExeStore("sp_T_TUYENDUONG_GetByKieuTuyen", para);
        }

        public DataTable GetTuyenByChayTuyen(params object[] para)
        {
            return ExeStore("sp_THUEBAO_T_TUYENDUONG_GetTuyenDuong",para);
        }

        public DataTable getBangCuoc(params object[] para)
        {
            return ExeStore("sp_T_BANGGIACUOC_Select", para);
        }

        public List<BangGiaCuoc> GetInfoBangCuoc(params object[] para)
        {
            return getBangCuoc(para).ToList<BangGiaCuoc>() ;
        }


        public int InsertBangGiaCuoc(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_BANGGIACUOC_Insert", para);
        }

        public int UpdateBangGiaCuoc(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_BANGGIACUOC_Update", para);
        }

        public int DeleteBangGiaCuoc(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_BANGGIACUOC_Delete", para);
        }

        public DataTable SearchByLoaiXeID(params object[] para)
        {
           return ExeStore("sp_T_BANGGIACUOC_SearchByLoaiXeID", para);
        }

        public DataTable SearchByLoaiXeID_New(params object[] para)
        {
            return ExeStore("sp_T_BANGGIACUOC_SearchByLoaiXeID_New", para);
        }

        public BangGiaCuoc getBangGiaByLoaiXeID(params object[] para) {
            return SearchByLoaiXeID(para).ToList<BangGiaCuoc>().FirstOrDefault<BangGiaCuoc>();
        }

        public BangGiaCuoc getBangGiaByLoaiXeID_New(params object[] para)
        {
            return SearchByLoaiXeID_New(para).ToList<BangGiaCuoc>().FirstOrDefault<BangGiaCuoc>();
        }


        //Hàm search bảng cước
        public BangGiaCuoc SearchBangGia(params object[] para) {
            return ExeStore("sp_THUEBAO_T_BANGGIACUOC_SearchGia", para).ToList<BangGiaCuoc>().FirstOrDefault<BangGiaCuoc>();
        }


        /// <summary>
        /// hàm search bảng cước có điểm xuất phát
        /// </summary>
        /// <param name="para">The para.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  04/09/2014   created
        /// </Modified>
        public BangGiaCuoc SearchBangGiaCoDiemXuatPhat(params object[] para)
        {
            return ExeStore("sp_THUEBAO_T_BANGGIACUOC_SearchGiaCoDiemXuatPhat", para).ToList<BangGiaCuoc>().FirstOrDefault();
        }

        /// <summary>
        /// Lấy bảng cước theo ca
        /// </summary>
        /// <param name="para"></param>
        public BangGiaCuoc getBangGiaByShift(params object[] para)
        {
            // lấy bảng cước tương ứng của ca
            DataTable bangcuoc = ExeStore("sp_T_BANGGIACUOC_SearchByShift", para);
            BangGiaCuoc bcRet = new BangGiaCuoc();

            if (bangcuoc != null && bangcuoc.Rows.Count > 0)
            {
                DataRow row = bangcuoc.Rows[0];
                bcRet.GiaTien2Chieu = float.Parse(row["GiaTienMotNgay"].ToString());
                bcRet.GiaTien1Chieu = float.Parse(row["GiaTienNuaNgay"].ToString());

                bcRet.ThoiGianQuyDinh2Chieu = float.Parse(row["ThoiGianMotNgay"].ToString());
                bcRet.ThoiGianQuyDinh1Chieu = float.Parse(row["ThoiGianNuaNgay"].ToString());
                bcRet.KmQuyDinh2Chieu = float.Parse(row["KmMotNgay"].ToString());
                bcRet.KmQuyDinh1Chieu = float.Parse(row["KmNuaNgay"].ToString());

                bcRet.GiaDinhMucVuot1GioHaiChieu = float.Parse(row["GiaDinhMucVuot1GioHaiChieu"].ToString());
                bcRet.GiaDinhMucVuot1GioMotChieu = float.Parse(row["GiaDinhMucVuot1GioMotChieu"].ToString());

                bcRet.GiaDinhMucVuot1KmHaiChieu = float.Parse(row["GiaDinhMucVuot1KmHaiChieu"].ToString());
                bcRet.GiaDinhMucVuot1KmMotChieu = float.Parse(row["GiaDinhMucVuot1KmMotChieu"].ToString());
                return bcRet;
            }
            else
                return null;

        }

        public BangGiaCuoc getBangGiaTuDo(params object[] para)
        {
            // lấy bảng cước tương ứng của ca
            DataTable bangcuoc = ExeStore("sp_T_BANGGIACUOC_THUEBAOTUDO", para);
            BangGiaCuoc bcRet = new BangGiaCuoc();

            if (bangcuoc != null && bangcuoc.Rows.Count > 0)
            {
                DataRow row = bangcuoc.Rows[0];

                bcRet.GiaDinhMucVuot1GioHaiChieu = float.Parse(row["GiaDinhMucVuot1GioHaiChieu"].ToString());
                bcRet.GiaDinhMucVuot1GioMotChieu = float.Parse(row["GiaDinhMucVuot1GioMotChieu"].ToString());

                bcRet.GiaDinhMucVuot1KmHaiChieu = float.Parse(row["GiaDinhMucVuot1KmHaiChieu"].ToString());
                bcRet.GiaDinhMucVuot1KmMotChieu = float.Parse(row["GiaDinhMucVuot1KmMotChieu"].ToString());
                return bcRet;
            }
            else
                return null;

        }

        /// <summary>
        /// Gets the list all.
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/26/2014   created
        /// </Modified>
        public List<BangGiaCuoc> GetListAll()
        {
            return ExeStore("sp_BangGiaCuoc_GetListAll").ToList<BangGiaCuoc>();
        }

        #endregion

        public DataTable LayGiaTheoTuyen(params object[] input)
        {
            return ExeStore("sp_LayGiaTheoTuyen", input);
        }
    }

    [TableInfo(TableName = "T_TINHTOAN_GIATIEN_METER")]
    public class BangGiaCuocMETER : TaxiOperationDbEntityBase<BangGiaCuocMETER>
    {
        [Field]
        public int LoaiXe {set;get;}
        [Field]
        public DateTime NgayApDungTu {set;get;}
        [Field]
        public DateTime NgayApDungDen {set;get;}
        [Field]
      public double KmMoCua {set;get;}
        [Field]
      public float GiaMoCua {set;get;}
        [Field]
      public float KmNguong1 {set;get;}
        [Field]
      public float GiaNguong1 {set;get;}
        [Field]
      public float GiaNguong2 {set;get;}
        [Field]
      public float KmNguong2Chieu {set;get;}
      [Field]
        public float TiLeGiamGiaHaiChieu {set;get;}
       [Field]
      public string ThongTinThueBao {set;get;}
        [Field]
      public float KmNguong2  {set;get;}
        [Field]
      public float GiaNguong3 {set;get;}
        [Field]
      public float KmNguong3 {set;get;}
        [Field]
      public float N1_ChieuDiTu {set;get;}
        [Field]
      public float N1_ChieuDiDen {set;get;}
        [Field]
      public float N1_Giam {set;get;}
      [Field]
        public float N2_ChieuDiTu {set;get;}
      [Field]
        public float N2_Giam {set;get;}
        [Field]
        public bool  IsAll  {set;get;}


    }

}
