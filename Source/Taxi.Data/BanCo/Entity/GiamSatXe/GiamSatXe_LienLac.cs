using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "BanCo_GiamSatXe")]
    public class GiamSatXe_LienLac : TaxiOperationDbEntityBase<GiamSatXe_LienLac>
    {
        #region properties
        private SqlInt64 m_id;
        [Field(IsKey = true, IsIdentity = true)]
        public SqlInt64 Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        private SqlString m_sohieuxe;
        [Field]
        public SqlString SoHieuXe
        {
            get { return m_sohieuxe; }
            set { m_sohieuxe = value; }
        }

        private string m_BienSoXe;
        public string BienKiemSoat
        {
            get { return m_BienSoXe; }
            set { m_BienSoXe = value; }
        }

        private SqlDateTime m_thoidiembao;
        [Field]
        public SqlDateTime ThoiDiemBao
        {
            get { return m_thoidiembao; }
            set { m_thoidiembao = value; }
        }
        private SqlString m_malaixe;
        [Field]
        public SqlString MaLaiXe
        {
            get { return m_malaixe; }
            set { m_malaixe = value; }
        }
        private SqlString m_tenLaiXe;
        [Field]

        public SqlString TenLaiXe
        {
            get { return m_tenLaiXe; }
            set { m_tenLaiXe = value; }
        }
        private SqlString m_vitridiembao;
        [Field]
        public SqlString VitriDiemBao
        {
            get { return m_vitridiembao; }
            set { m_vitridiembao = value; }
        }
        private SqlString m_vitridiemden;
        [Field]
        public SqlString ViTriDiemDen
        {
            get { return m_vitridiemden; }
            set { m_vitridiemden = value; }
        }
        private SqlChars m_loaichokhach;
        [Field]
        public SqlChars LoaiChoKhach
        {
            get { return m_loaichokhach; }
            set { m_loaichokhach = value; }
        }
        private SqlString m_trangthailaixebao;
        [Field]
        public SqlString TrangThaiLaiXeBao
        {
            get { return m_trangthailaixebao; }
            set { m_trangthailaixebao = value; }
        }
        private SqlString m_ghichu;
        [Field]
        public SqlString GhiChu
        {
            get { return m_ghichu; }
            set { m_ghichu = value; }
        }
        private SqlChars m_ishoatdong;
        [Field]
        public SqlChars IsHoatDong
        {
            get { return m_ishoatdong; }
            set { m_ishoatdong = value; }
        }
        private SqlInt16 m_chieu;
        [Field]
        public SqlInt16 Chieu
        {
            get { return m_chieu; }
            set { m_chieu = value; }
        }
        private SqlBoolean m_checkedgps;
        [Field]
        public SqlBoolean CheckedGPS
        {
            get { return m_checkedgps; }
            set { m_checkedgps = value; }
        }
        private SqlDateTime m_thoidiemve;
        [Field]
        public SqlDateTime ThoiDiemVe
        {
            get { return m_thoidiemve; }
            set { m_thoidiemve = value; }
        }
        private SqlInt64 m_codi;
        [Field]
        public SqlInt64 CoDi
        {
            get { return m_codi; }
            set { m_codi = value; }
        }
        private SqlInt64 m_cove;
        [Field]
        public SqlInt64 CoVe
        {
            get { return m_cove; }
            set { m_cove = value; }
        }
        private SqlString m_noidungsuco;
        [Field]
        public SqlString NoiDungSuCo
        {
            get { return m_noidungsuco; }
            set { m_noidungsuco = value; }
        }
        private SqlString m_ketquaxuly;
        [Field]
        public SqlString KetQuaXuLy
        {
            get { return m_ketquaxuly; }
            set { m_ketquaxuly = value; }
        }
        private SqlInt32 m_soPhutNghi;
        [Field]
        public SqlInt32 SoPhutNghi
        {
            get { return m_soPhutNghi; }
            set { m_soPhutNghi = value; }
        }
        private SqlInt32 m_diemDo;
        [Field]
        public SqlInt32 DiemDo
        {
            get { return m_diemDo; }
            set { m_diemDo = value; }
        }

        private SqlBoolean m_IsHidden;
        /// <summary>
        /// Dùng cho xe xin rời xe
        /// True : Ẩn đi ở cột 3
        /// Ngược lại thì vẫn hiển thị
        /// </summary>
        [Field]
        public SqlBoolean IsHidden
        {
            get { return m_IsHidden; }
            set { m_IsHidden = value; }
        }
        private SqlBoolean m_IsCaBa;
        /// <summary>
        /// Dùng cho xe đi kinh doanh ca 3
        /// </summary>
        [Field]
        public SqlBoolean IsCaBa
        {
            get { return m_IsCaBa; }
            set { m_IsCaBa = value; }
        }
        public SqlInt32 Node { get; set; }
        public int SoHieuXeInt { get { return SoHieuXe.To<int>(); } }
        #endregion

        #region Method
        public List<GiamSatXe_LienLac> GetListAllXeChuaVe()
        {
            return ExeStore("SP_BanCo_GiamSatXe_XeChuaVe").ToList<GiamSatXe_LienLac>();
        }

        public List<GiamSatXe_LienLac> GetListAllXe_ForXinDiemDo()
        {
            return ExeStore("sp_BanCo_GiamSatXe_XeXinDiemDo").ToList<GiamSatXe_LienLac>();
        }

        public List<GiamSatXe_LienLac> GetListAllXe_ForBaoDiemTra()
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeBaoDiemTra").ToList<GiamSatXe_LienLac>();
        }

        public DataTable GetHanhTrinhXe(DateTime Ngay, string MaXe)
        {
            return ExeStore("SP_BanCo_GiamSatXe_GetHanhTrinh", Ngay, MaXe);
        }

        public DataTable GetHanhTrinhXeByName(DateTime Ngay, string MaXe)
        {
            return ExeStore("SP_BanCo_GiamSatXe_GetHanhTrinh_HieuNM", Ngay, MaXe);
        }

        public DataTable GetGiamSatXe(string MaXe, string TrangThai)
        {
            return ExeStore("SP_BanCo_GiamSatXe_GetGiamSatXe", MaXe, TrangThai);
        }

        public DataTable GetGiamSatXeByTrangThai(string p)
        {
            return ExeStore("SP_BanCo_GiamSatXe_GetGiamSatXeByTrangThai", p);
        }

        public DataTable GetGiamSatXeByTrangThai(object p)
        {
            return ExeStore("SP_BanCo_GiamSatXe_GetGiamSatXeByTrangThai", p);
        }
        public DateTime GetTimeServer()
        {
            var DateTimeServer = DateTime.MinValue;
            var result = this.ExeStoreNoneQueryWithOutput("sp_GetDateTimeServer", DateTimeServer);
            DateTimeServer = result.Value["DateTimeServer"].To<DateTime>();
            return DateTimeServer;
        }
        //public DataTable GetNhanVien()
        //{
        //    return ExeStore("SP_BanCo_GiamSatXe_GetNhanVien");
        //}

        /// <summary>
        /// Xe chưa khai báo ra kinh doanh
        /// </summary>
        /// <returns></returns>
        public List<GiamSatXe_HoatDong> GetNhanVienList()
        {
            return ExeStore("SP_BanCo_GiamSatXe_GetNhanVien").ToList<GiamSatXe_HoatDong>();
        }

        public DataTable GetNVHoatDong()
        {
            return ExeStore("sp_BanCa_GiamSatXeHoatDong_GetXeHoatDong");
        }

        public DataTable GetNVHoatDong_ForBaoVe()
        {
            return ExeStore("sp_BanCa_GiamSatXeHoatDong_GetXeHoatDong_ForBaoVe");
        }

        public List<GiamSatXe_HoatDong> GetNVHoatDongList()
        {
            return ExeStore("sp_BanCa_GiamSatXeHoatDong_GetXeHoatDong").ToList<GiamSatXe_HoatDong>();
        }

        //SP_BanCo_GiamSatXe_GetNhanVienDangNghi
        public DataTable GetNhanVienDangNghi()
        {
            return ExeStore(";");
        }
        #endregion


        public void XeHoatDong()
        {
            ExeStoreNoneQuery("SP_BanCo_GiamSatXe_XeHoatDong", SoHieuXe, MaLaiXe, m_thoidiembao, '1', m_diemDo);
        }

        public void UnXeHoatDong()
        {
            ExeStoreNoneQuery("SP_BanCo_GiamSatXe_XeHoatDong", SoHieuXe, MaLaiXe, m_thoidiembao, '0', m_diemDo);
        }

        public DataTable getVungDieuHanh()
        {
            return ExeStore("sp_BanCo_VungDieuHanh_GetAll");
        }
        public DataTable ExeStores(string name, params object[] pa)
        {
            return ExeStore(name, pa);
        }
        public DataTable ExeStores(string name)
        {
            return ExeStore(name);
        }
        public int ThemLayID(string name, params object[] para)
        {
            int id = 0;
            //var result = this.ExeStoreNoneQueryWithOutput("sp_BanCo_GiamSatXe_Insert",para,id);
            var result = this.ExeStoreWithOutput(name, para);
            id = result.Value["id"].To<int>();
            return id;
        }


        #region------Module Giam Sat Xe-------
        //Module Giam Sat Xe
        public void GSX_BaoRaKinhDoanh(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_Insert", pa);
        }

        /// <summary>
        /// Báo ra kinh doanh
        /// v2 thêm ca 3
        /// </summary>
        /// <param name="pa"></param>
        public void GSX_BaoRaKinhDoanh_V2(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_Insert_v3", pa);
            //ExeStoreWithOutput("sp_BanCo_GiamSatXe_Insert_v2", pa);
        }

        public string GetDiemDo(params object[] pa)
        {
            DataTable dtDiemDo = new DataTable();
            dtDiemDo = ExeStore("sp_BanCo_GiamSatXe_HoatDong_GetDiemDo",pa);
            if (dtDiemDo.Rows.Count > 0) 
            {
                return dtDiemDo.Rows[0]["DiemDo"].ToString();
            }
            return "";
        }

        /// <summary>
        /// Get danh sách xe hợp lệ để báo rời xe, ăn ca, mất liên lạc
        /// </summary>
        /// <returns></returns>
        public DataTable GSX_BaoRoiXe_GetXe()
        {
            return ExeStore("sp_BanCo_GiamSatXe_XeBaoRoiXe");
        }

        public void GSX_BaoRoiXe_XuLy(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_Update_BaoRoiXe_V2", pa);
        }

        public void GSX_BaoAnCa_XuLy(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_Update_AnCa", pa);
        }

        public void GSX_BaoAnCa_XuLy_Delete(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_AnCa_Delete", pa);
        }

        public void GSX_BaoAnCa_XuLyUpdate(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_AnCa_Update", pa);
        }

        public void GSX_BaoMatLienLac_XuLy(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_XeMatLienLac", pa);
        }

        public DataTable GSX_BaoHoatDong_GetXe()
        {
            return ExeStore("sp_BanCo_GiamSatXe_HoatDong_BaoHoatDong_GetXe");
        }

        public DataTable GSX_BaoHoatDong_XuLy(params object[] pa)
        {
            return ExeStore("sp_BanCo_GiamSatXe_BaoHoatDong", pa);
        }

        public DataTable GSX_BaoVe_XuLy(params object[] pa)
        {
            return ExeStore("sp_BanCo_GiamSatXe_XeBaoVe", pa);
        }

        public void GSX_BaoChuyenVung_XuLy(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_XeChuyenVung_V2", pa);
        }

        public void GSX_BaoDiemTra(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_XeBaoDiemTra", pa);
        }

        public void GSX_BaoChuyenVung_XuLy_TruotHang(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_XeChuyenVung_TruotHang", pa);
        }

        public void GSX_BaoChuyenVung_XuLy_TruotHang_EG(params object[] pa)
        {
            // ExeStoreNoneQuery("sp_BanCo_GiamSatXe_XeChuyenVung", pa);
            ExeStoreWithOutput("sp_BanCo_EG_GiamSatXe_XeChuyenVung_TruotHang", pa);
        }

        public void GSX_BaoKhaiThac_XuLy(params object[] pa)
        {
            ExeStoreWithOutput("sp_BanCo_GiamSatXe_BaoKhaiThac", pa);
        }

        /// <summary>
        /// Cập nhập cho bảng Truck_End mã lái xe mới
        /// khi xe báo ra kd hoặc báo về
        /// cần số xe, mã lái xe, giờ đi
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        //public bool Truck_End_Update_MaLaiXe(params object[] pa)
        //{
        //    return ExeStoreNoneQuery("sp_T_TAXIOPERATION_TRUCK_END_Update_Xe_KD_BV", pa) > 0 ? true : false;
        //}

        #endregion---------End giam sat xe--------------


        public DataTable Map_HienTrangXe(params object[] para)
        {
            return ExeStore("sp_BanCo_GiamSatXe_HoatDong_TEN_LAI_XE", para);
        }

        //public List<GiamSatXe_LienLac> Get_GiamSatXe_LienLac(params object[] para)
        //{
        //    return ExeStore("SP_XE_GetInfo_GiamSatXe", para).ToList<GiamSatXe_LienLac>();
        //}

        /// <summary>
        /// Lấy trạng thái khai báo giám sát xe của xe
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<GiamSatXe_LienLac> Get_GiamSatXe_Status_BySoHieuXe(params object[] para)
        {
            return ExeStore("SP_BanCo_GiamSatXe_Get_Status_By_SHXe", para).ToList<GiamSatXe_LienLac>();
        }

        /// <summary>
        /// Lấy trạng thái khai báo giám sát xe của lái xe
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<GiamSatXe_LienLac> Get_GiamSatXe_Status_ByMaLaiXe(params object[] para)
        {
            return ExeStore("SP_BanCo_GiamSatXe_Get_Status_By_MaLX", para).ToList<GiamSatXe_LienLac>();
        }

        /// <summary>
        /// Get giam sat xe theo ngay va so hieu xe
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<GiamSatXe_LienLac> Get_GiamSatXe_ByDate(params object[] para)
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetByDate", para).ToList<GiamSatXe_LienLac>();
        }

        public DataTable CheckAnCa(params object[] para)
        {
            return ExeStore("sp_BanCo_GiamSatXe_IsAnCa", para);
        }
        public DataTable GetInfoKD(params object[] para)
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetInfoKD", para);
        }
        
        public DataTable GetXeHoatDongTrongNgay(params object[] para)
        {
            return ExeStore("sp_BanCo_GiamSatXe_GetXeHoatDongTrongNgay",para);
        }
        
        #region Bao cao
        //Bao cao
        public DataTable Report_KSXeTrongNgay_SoHieuXe()
        {
            return ExeStore("sp_T_DMXe_GetSoHieuXe");
        }

        public DataTable Report_KSXeTrongNgay_TrangThai()
        {
            return ExeStore("sp_BanCo_GiamSatXe_TrangThai_GetTrangThai");
        }

        public DataTable Report_KSXeTrongNgay_XuLy(params object[] para)
        {
            return ExeStore("sp_BanCo_GiamSatXe_BC_KSXeTrongNgay", para);
        }

        public DataTable Report_AnCaQuaGio(params object[] para)
        {
            return ExeStore("sp_BanCo_GiamSatXe_BC_AnCaQuaGio", para);
        }
        #endregion----
        
        public DataTable getVungDh(params object[] para)
        {
            return ExeStore("sp_BanCo_VungDieuHanh_POLYGON", para);
        }

        public DataTable getDsVungDh()
        {
            return ExeStore("sp_BanCo_VungDieuHanh_DS_VUNG_DH");
        }



        public static DataTable dtLoaixe;
        public DataTable listXe(DataTable dtXe)
        {
            dtLoaixe = dtXe;
            return dtXe;
        }

        #region phan khach dat
        public DataTable getKhachDatTheoNgay(DateTime ngay)
        {
            return ExeStore("SP_T_KHACHDAT_SELECT_BY_Date", ngay);
        }

        public DataTable getKhachDatTheoLoaiXe(params object[] para)
        {
            return ExeStore("SP_T_KHACHDAT_SELECT_BY_LoaiXe", para);
        }

        public DataTable getKhachDatByGroupID(params object[] para)
        {
            return ExeStore("sp_T_KHACHDAT_SELECT_BY_GROUP_ID", para);
        }
        #endregion


        #region form cuốc khách thuê bao
        public DataTable getLoaiXeByID(params object[] para)
        {
            return ExeStores("sp_T_TUDIEN_LOAIXE_LayTheoID", para);
        }


        

        public int InsertNhatKyThueBao(params object[] para) {
            int id = 0;
            var result = this.ExeStoreWithOutput("SP_T_NHATKYTHUEBAO_insert_V3", para);
            id = result.Value["output"].To<int>();
            return id;
        }

        public int InsertNhatKyThueBao1(params object[] para)
        {
            int id = 0;
            var result = this.ExeStoreWithOutput("SP_T_NHATKYTHUEBAO_insert_V4", para);
            id = result.Value["output"].To<int>();
            return id;
        }

        public int UpdateNhatKyThueBao(params object[] para)
        {
            return ExeStoreNoneQuery("SP_T_NHATKYTHUEBAO_Update_V3", para);
        }

        public int DeleteNhatKyThueBao(params object[] para) {
            return ExeStoreNoneQuery("sp_T_NHATKYTHUEBAO_Delete_V3", para);
        }

        public int ThemMoi_GiamSatXe(params object[] para)
        {
            return ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_ThemMoi",para);
        }

        public int Sua_GiamSatXe(params object[] para)
        {
            return ExeStoreNoneQuery("sp_BanCo_GiamSatXeV2_Sua", para);
        }

        public int Xoa_GiamSatXe(params object[] para)
        {
            return ExeStoreNoneQuery("sp_BanCo_GiamSatXe_Delete", para);
        }
        #endregion

        public DataTable DSKhachHang() {
            return ExeStore("V3_SP_T_DMKHACHANG_GET_ID_V2");
        }
        public List<GiamSatXe_LienLac> GetListAllXe_ForXinDiemDoByDate(DateTime dt)
        {
            return ExeStore("sp_BanCo_GiamSatXe_XeXinDiemDoByDate", dt).ToList<GiamSatXe_LienLac>();
        }

        public bool CheckXeKhongDiKinhDoanh(string soXe, DateTime thoiGian)
        {
            var dt = ExeStore("sp_BanCo_GiamSatXe_CheckXeKhongDiKinhDoanh", soXe, thoiGian);
            return dt!=null&&dt.Rows.Count > 0 && dt.Rows[0][0].To<int>() > 0;
        }
        //--sp_BanCo_VehicleNotWorking_GetBySoXe
        public DataTable GetVehicleNotWorkingBySoXe(string soXe)
        {
            return ExeStore("VehicleNotWorking_GetBySoXe", soXe);
        }

        public DataTable GetTrangThaiBySoXe(string soXe)
        {
            return ExeStore("sp_BanCo_GetTrangThaiBySoXe", soXe);
        }
    }
}