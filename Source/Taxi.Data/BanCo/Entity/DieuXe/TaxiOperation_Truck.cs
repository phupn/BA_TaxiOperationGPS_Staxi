using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.DieuXe;
using Taxi.Utils;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "T_TAXIOPERATION_TRUCK")]
    public class TaxiOperation_Truck : TaxiOperationDbEntityBase<TaxiOperation_Truck>, ICloneable
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)]
        public long Id {set;get;}

        [Field]
        public string SoDT {set;get;}
        [Field]
        public DateTime TGTiepNhan {set;get;}
        [Field]
        public int Line {set;get;}
        [Field]
        public string DiaChiDon {set;get;}
        [Field]
        public int DuongPhoDon {set;get;}
        [Field]
        public int QuanHuyenDon {set;get;}
        [Field]
        public double KinhDo_Khach {set;get;}
        [Field]
        public double ViDo_Khach {set;get;}
        [Field]
        public string LoaiXe {set;get;}
        [Field]
        public int Vung  {set;get;}
        /// <summary>
        /// Số hiệu xe
        /// </summary>
        [Field]
        public string SoXe {set;get;}
        [Field]
        public string MaLaiXe { set; get; }
        public string TenLaiXe { set; get; }
        [Field]
        public long ChiSoDi { set; get; }
        /// <summary>
        /// Vị trí hiện tại của xe khi người dùng nhập xe nhận đón hàng
        /// </summary>
        [Field]
        public float KinhDo_BD {set;get;}
        /// <summary>
        /// Vị trí hiện tại của xe khi người dùng nhập xe nhận đón hàng
        /// </summary>
        [Field]
        public float  ViDo_BD {set;get;}
        /// <summary>
        /// Vị trí hiện tại của xe khi tích chọn có hàng
        /// </summary>
        [Field]
        public float KinhDo_Don {set;get;}
        /// <summary>
        /// Vị trí hiện tại của xe khi tích chọn có hàng
        /// </summary>
        [Field]
        public float ViDo_Don {set;get;}
        [Field]
        public DateTime? TGGap {set;get;}
        [Field]
        public string DiaChiTra {set;get;}
        [Field]
        public int DuongPhoTra {set;get;}
        [Field]
        public int QuanHuyenTra {set;get;}
        [Field]
        public float KinhDo_Tra {set;get;}
        [Field]
        public float ViDo_Tra {set;get;}
        [Field]
        public string TuyenDuong {set;get;}
        [Field]
        public int Chieu {set;get;}
        [Field]
        public string GiaThueBao {set;get;}
        [Field]
        public int BuXang_Don_GPS { set; get; }
        [Field]
        public int BuXang_Don {set;get;}
        [Field]
        public Taxi.Utils.KieuCuocHang KieuCuocHang { set; get; }

        [Field]
        public int KieuCuocHang_Int
        {
            get { return (int)KieuCuocHang; }
        }

        [Field]
        public DateTime? TGTra {set;get;}
        [Field]
        public long ChiSoVe { set; get; }
        /// <summary>
        /// Chỉ số về - chỉ số đi
        /// </summary>
        [Field]
        public int KmCoDH {set;get;}
        /// <summary>
        /// km gps
        /// </summary>
        [Field]
        public double KmThucDi {set;get;}
        /// <summary>
        /// Tiền lấy theo GPS
        /// </summary>
        [Field]
        public decimal TienGPS { set; get; }
        /// <summary>
        /// Tiền lấy theo đồng hồ (xe báo về)
        /// </summary>
        [Field]
        public decimal TienDH { set; get; }
        [Field]
        public int BuXang_Truot_GPS { set; get; }
        [Field]
        public int BuXang_Truot {set;get;}
        [Field]
        public decimal PhatSinh { set; get; }

        [Field]
        public float KmVuot { set; get; }
        [Field]
        public float KmVuot_Auto { set; get; }
        [Field]
        public decimal TienTroiKM { set; get; }
        [Field]
        public int PhutVuot { set; get; }
        [Field]
        public int PhutVuot_Auto { set; get; }
        [Field]
        public decimal TienTroiPhut { set; get; }

        [Field]
        public string PhuTroi {set;get;}
        [Field]
        public decimal ThanhTien { set; get; }
        [Field]
        public int DiemDoMoi {set;get;}
        [Field]
        public int LyDoTruot {set;get;}
        [Field]
        public string GhiChu {set;get;}
        /// <summary>
        /// Enum TrangThaiCuocGoiTaxi
        /// </summary>
        [Field]
        public Taxi.Utils.TrangThaiCuocGoiTaxi KetQua { set; get; }
        [Field]
        public int LayTGTuDong_Don {set;get;}
        [Field]
        public int LayTGTuDong_Tra { set; get; }
        [Field]
        public int DongBo {set;get;}
        [Field]
        public long CuocKhachID {set;get;}

        [Field]
        public Taxi.Utils.Enum_CallType KieuCuocGoi { set; get; }

        public int KieuCuocGoi_Int
        {
            get { return (int)KieuCuocGoi; }
        }

        [Field]
        public string GhiChuTiepNhan { set; get; }
        [Field]
        public int DiemXuatPhat { set; get; }

        [Field]
        public int SoLuong { set; get; }

        [Field]
        public double KmGPS { set; get; }
        [Field]
        public string LenhTiepNhan { set; get; }
        [Field]
        public string LenhDieuXe { set; get; }

        [Field]
        public int ChayTuyen { set; get; }

        [Field]
        public int SoLanGoiLai { set; get; }

        [Field]
        public long FK_CuocGoiID_Copy { set; get; }

        [Field]
        public string MaKH { set; get; }

        [Field]
        public Taxi.Utils.KieuKhachHangGoiDen KieuKhachHangGoiDen { set; get; }

        public int KieuKhachHangGoiDen_Int
        {
            get { return (int)KieuKhachHangGoiDen; }
        }
        /// <summary>
        /// Mã nhân viên tiếp nhận
        /// </summary>
        [Field]
        public string MaNVTiepNhan { set; get; }

        /// <summary>
        /// Mã nhân viên điều xe
        /// </summary>
        [Field]
        public string MaNVDieuXe { set; get; }

        /// <summary>
        /// Đánh dấu cuộc gọi có phải do bộ phận bốc xếp gọi không
        /// </summary>
        [Field]
        public bool CoBocXep { set; get; }

        /// <summary>
        /// Trạng thái lệnh của bộ phận nào cập nhật
        /// </summary>
        [Field]
        public Taxi.Utils.TrangThaiLenhTaxi TrangThaiLenh { set; get; }

        [Field]
        public int FK_TypesOfGoods { set; get; }

        [Field]
        public int FK_DiemDo { set; get; }

        [Field]
        public Taxi.Utils.LoaiCuocHangThucHien LoaiCuocHang { set; get; }

        [Field]
        public DateTime? LastModified { set; get; }

        /// <summary>
        /// Ghi nhận là cuộc gọi do nhân viên tự chèn
        /// </summary>
        [Field]
        public bool LaCuocGoiChen { set; get; }
        [Field]
        public long IdCuocGoiLai { set; get; }
        [Field]
        public string ThoiDiemGoiLai { set; get; }
        public DateTime? ThoiDiemKhongNhacMay { set; get; }

        public DateTime ThoiDiemNhacMay { set; get; }
        public DateTime KhoangThoiGianHoiThoai { set; get; }
        
        [Field]
        public string FileVoicePath { set; get; }
        [Field]
        public string XeDeCu { set; get; }
        [Field]
        public string XeDeCu_TD { set; get; }
        /// <summary>
        /// Khách hẹn luôn được ưu tiên lên đầu
        /// </summary>
        [Field]
        public bool KhachHen { set; get; }
        /// <summary>
        /// Các trạng thái khác lưu vào trường này
        /// 1 : Cuốc quay đầu
        /// </summary>
        [Field]
        public Enum_Truck_TrangThaiKhac TrangThaiKhac { set; get; }

        public string NhomKH { get; set; }
        public string TenLoaiXe { get; set; }
        public string TenTuyenDuong { get; set; }
        public string Ca { set; get; }
        [Field]
        public DateTime TGDieuXe { set; get; }
        [Field]
        public int IsCaBa { set; get; }
        /// <summary>
        /// Nếu thu ngân rồi thì đánh dấu trường này thành True
        /// </summary>
        [Field]
        public bool IsCash { set; get; }

        public string KT
        {
            get
            {
                return KieuCuocHang == KieuCuocHang.LaiXeKhaiThacDuongDai ? "x" : "";
            }
        }
        public int? SoXeInt{get { return !string.IsNullOrEmpty(SoXe) ? SoXe.To<int>() : (int?) null; }}

        public DateTime? TGDieuXeNull
        {
            get { return TGDieuXe <= DateTime.MinValue ? (DateTime?)null : TGDieuXe; }
        }

        #endregion

        #region Methods Common
        
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion

        #region Get Data For Grid
        
        /// <summary>
        /// Lấy tất cả các cuộc gọi 
        /// V3 có thêm địa chỉ trả trong thông tin tìm kiếm
        /// </summary>
        /// <param name="vung"></param>
        /// <param name="ismaytinh"></param>
        /// <param name="tttk"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllByLine_Vung_V3(string vung, int ismaytinh, ThongTinTimKiem tttk)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep_v3", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, tttk.DiaChiTra, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Get danh sách cuộc gọi xe đón trong ngày
        /// </summary>
        /// <param name="SoXe"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllTruck_EndBy_SoXe(string SoXe)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAll_SoXe", SoXe).ToList<TaxiOperation_Truck>();
        }

        
        /// <summary>
        /// Get all cuộc gọi by số xe
        /// </summary>
        /// <param name="SoXe"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllTruckBy_SoXe(string SoXe)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_GetAll_SoXe", SoXe).ToList<TaxiOperation_Truck>();
        }
        /// <summary>
        /// Get all cuốc gọi by số điện thoại
        /// </summary>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllTruckBy_SDT(string sdt)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_GetAll_SDT", sdt).ToList<TaxiOperation_Truck>();
        }
        /// <summary>
        /// Kiểm tra xe số xe này có đang điều hay không
        /// </summary>
        /// <param name="SoXe"></param>
        /// <returns></returns>
        public bool IsTruckProcessing(string SoXe)
        {
            List<TaxiOperation_Truck> lstTruck = GetAllTruckBy_SoXe(SoXe);
            return lstTruck != null && lstTruck.Count > 0;
        }
        #region Tiếp nhận
        
        /// <summary>
        /// Lay ra danh sach cuoc gọi mới có 
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllNew_TiepNhan_By_Time(params object[] para)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_TIEPNHAN_GETALLNEW_BYTIME_V2", para).ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Lay ra danh sach cuoc gọi mới thay đổi của điều xe
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllModified_TiepNhan_By_Time(params object[] para)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_TIEPNHAN_GETALLMODIFIED_BYTIME_V2", para).ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Lay ra danh sach ID cuoc gọi đã kết thúc
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<long> GetAllEnd_TiepNhan(params object[] para)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = ExeStore("SP_T_TAXIOPERATION_TRUCK_TIEPNHAN_GETALL_END_V2", para))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        #endregion

        #region Điều xe

        /// <summary>
        /// Lay ra danh sach cuoc gọi mới thay đổi của tiếp nhận
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllModified_DieuXe_By_Time(params object[] para)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_DIEUXE_GETALLMODIFIED_BYTIME", para).ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Lay ra danh sach ID cuoc gọi đã kết thúc cho Điều Xe
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public List<long> GetAllEnd_DieuXe(params object[] para)
        {
            List<long> listID = new List<long>();
            using (DataTable dt = ExeStore("SP_T_TAXIOPERATION_TRUCK_DIEUXE_GETALL_END", para))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"] != DBNull.Value)
                        {
                            listID.Add(Convert.ToInt64(dr["ID"].ToString()));
                        }
                    }
                }
            }
            return listID;
        }

        /// <summary>
        /// Lay tat ca cac cuoc thue bao tuyen
        /// V3 co them địa chỉ trả trong thông tin tìm kiếm
        /// </summary>
        /// <param name="vung"></param>
        /// <param name="ismaytinh"></param>
        /// <param name="tttk"></param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllByLine_Vung_ThueBaoTuyen_V3(string vung, int ismaytinh, ThongTinTimKiem tttk)
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep_ThueBaoTuyen_v3", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, tttk.DiaChiTra, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck>();
        }

        #endregion
        
        #endregion

        /// <summary>
        /// Cập nhật dữ liệu của bảng T_TAXIOPERATION_TRUCK_END
        /// </summary>
        /// <returns></returns>
        public int UpdateCuocHangTrunkEnd()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_END_UPDATE_V2");
        }
        /// <summary>
        /// Thêm mới cuốc hàng
        /// </summary>
        /// <returns></returns>
        public long InsertCuocHangNew()
        {
            var result = ExeStoreNoneQueryWithOutput("SP_T_TAXIOPERATION_TRUCK_INFOR_INSERT_V2");
            Id = result.Value["Id"].To<long>();
            return Id;
        }
        public long InsertCuocHangNew3()
        {
            var result = ExeStoreNoneQueryWithOutput("SP_T_TAXIOPERATION_TRUCK_INFOR_INSERT_V3");
            Id = result.Value["Id"].To<long>();
            return Id;
        }

        /// <summary>
        /// Trường hợp insert thêm các cuốc hàng cho các ngày thiếu
        /// </summary>
        /// <returns></returns>
        public long InsertCuocHangNew_AddPrev()
        {
            var result = ExeStoreNoneQueryWithOutput("SP_T_TAXIOPERATION_TRUCK_INFOR_INSERT_V2_AddPrev");

            return result.Value["Id"].To<long>();
        }

        public long InsertCuocHangNew_LanDauBatSo(params object[] para)
        {
            var result = ExeStoreNoneQueryWithOutput("SP_T_TAXIOPERATION_TRUCK_INFOR_INSERT_LanDauBatSo_V2", para);

            return result.Value["Id"].To<long>();
        }
        
        /// <summary>
        /// Cập nhật thông tin thời lượng cuộc gọi, file ghi âm, số chuông
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public long UpdateCuocHang_CapNhatBatSo(params object[] para)
        {
            var result = ExeStoreNoneQueryWithOutput("sp_T_TAXIOPERATION_TRUCK_UpdateKetThucCuocGoiDenCoBatMay", para);

            return result.Value["Id"].To<long>();
        }

        public int InsertCuocHangNew_KhachDat(params object[] para)
        {
            var result = ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_INFOR_INSERT_KhachDat", para);

            return result;
        }
        /// <summary>
        /// Insert cuộc gọi nhỡ vào bảng Truck_END
        /// </summary>
        /// <returns></returns>
        public long InsertCuocGoiNho()
        {
            var result = ExeStoreNoneQueryWithOutput("sp_T_TAXIOPERATION_TRUCK_END_Insert_CuocGoiNho");

            return result.Value["Id"].To<long>();
        }
        public int UpdateCuocHangKieuCuocGoi()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_TYPECALL_UPDATE_V2");
        }

        public int UpdateCuocHang_Command_TIEPNHAN()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_UPDATE_COMMAND_TIEPNHAN");
        }

        public int UpdateCuocHang_Command_TIEPNHAN_V2()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_UPDATE_COMMAND_TIEPNHAN_V2");
        }
        /// <summary>
        /// Update thao tác lệnh trên lưới
        /// </summary>
        /// <returns></returns>
        public int UpdateCuocHang_Command_DIEUXE()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_UPDATE_COMMAND_DIEUXE");
        }
        
        public int UpdateCuocHang_XeDon_DIEUXE()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_UPDATE_XEDON");
        }

        /// <summary>
        /// Update xu ly truot hang nhanh tren luoi
        /// </summary>
        /// <returns></returns>
        public int UpdateCuocHang_Command_Truot_DIEUXE(params object[] para)
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_UPDATE_TRUOT_DIEUXE", para);
        }
        
        public int InsertCuocHangKieuCuocGoi()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_TYPECALL_INSERT_V2");
        }
        
        public int InsertCuocHangKieuCuocGoiGetID()
        {
            try
            {
                var dt = ExeStore("SP_T_TAXIOPERATION_TRUCK_TYPECALL_INSERT_V2");
                if (dt.Rows.Count <= 0)
                {
                    return -1;
                }
                var id = dt.Rows[0][0].To<int>();
                this.Id = id;
                return id > 0 ? id : -1;
            }
            catch
            {
                return -1;
            }           
        }

        public int InsertCuocHangKieuCuocGoi2()
        {
            try
            {
                var dt = ExeStore("SP_T_TAXIOPERATION_TRUCK_TYPECALL_INSERT_V3");
                if (dt.Rows.Count <= 0)
                {
                    return -1;
                }
                var id = dt.Rows[0][0].To<int>();
                this.Id = id;
                return id > 0 ? id : -1;

            }
            catch
            {
                return -1;
            }
        }

        public int InsertCuocHang_DienThoaiVienChen()
        {
            try
            {
                var dt = ExeStore("SP_T_TAXIOPERATION_TRUCK_INSERT_BY_TIEPNHAN_V2");
                if (dt.Rows.Count <= 0)
                {
                    return -1;
                }
                var id = dt.Rows[0][0].To<int>();
                this.Id = id;
                return id > 0 ? id : -1;

            }
            catch
            {
                return -1;
            }

        }

        /// <summary>
        /// Cập nhật cuốc hàng
        /// </summary>
        /// <returns></returns>
        public int UpdateCuocHangNew()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_INFOR_UPDATE_V2");
        }

        /// <summary>
        /// Xóa cuốc hàng đã kết thúc
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int DeleteCuocHang(params object[] para)
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_END_DELETE", para);
        }


        // lấy danh sách các tuyến chạy
        public DataTable GetGroup()
        {
            return ExeStore("AllChayTuyen");
        }
        
        // lấy danh sách các tuyến chạy
        public int GetNumberCopy(params object[] para)
        {
            DataTable tbl = ExeStore("GetNumberOfCopy",para);
            if (tbl != null)
            {
                return tbl.Rows.Count;
            }
            else
                return 1;
        }

        public Dictionary<int, List<SubTypeGroup>> GetSubTypeGroup()
        {
            Dictionary<int, List<SubTypeGroup>> dicRet = new Dictionary<int, List<SubTypeGroup>>();
            #region cũ
            //DataTable dtb = ExeStore("Get_SubGroupType");

            //if (dtb != null)
            //{
            //    foreach (DataRow row in dtb.Rows)
            //    {
            //        SubTypeGroup obj = new SubTypeGroup();
            //        obj.Id = int.Parse(row["Id"].ToString());
            //        obj.Name = row["TypeName"].ToString();

            //        int key = int.Parse(row["FK_ChayTuyen"].ToString());

            //        if (!dicRet.ContainsKey(key))
            //            dicRet.Add(key, new List<SubTypeGroup>());

            //        dicRet[key].Add(obj);
            //    }
            //}

            #endregion

            /*
1	Nội tỉnh 1 chiều	1
2	Nội tỉnh 2 chiều	1
3	Nửa ngày	3
4	Một ngày	3
5	METER	4
6	Ngoại tỉnh 1 chiều	2
7	Ngoại tỉnh 2 chiều	2
8	METER	5
 */
                SubTypeGroup obj1 = new SubTypeGroup(1, "1 chiều");     
                SubTypeGroup obj2 = new SubTypeGroup(2, "2 chiều");
                int key = 1;
                if (!dicRet.ContainsKey(key))
                    dicRet.Add(key, new List<SubTypeGroup>());
                dicRet[key].Add(obj1);
                dicRet[key].Add(obj2);

                SubTypeGroup obj3 = new SubTypeGroup(3, "Nửa ngày");
                SubTypeGroup obj4 = new SubTypeGroup(4, "Cả ngày");
                key = 3;
                if (!dicRet.ContainsKey(key))
                    dicRet.Add(key, new List<SubTypeGroup>());
                dicRet[key].Add(obj3);
                dicRet[key].Add(obj4);

                SubTypeGroup obj5 = new SubTypeGroup(5, "METER");
                key = 4;
                if (!dicRet.ContainsKey(key))
                    dicRet.Add(key, new List<SubTypeGroup>());
                dicRet[key].Add(obj5);

                SubTypeGroup obj6 = new SubTypeGroup(6, "1 chiều");
                SubTypeGroup obj7 = new SubTypeGroup(7, "2 chiều");
                key = 2;
                if (!dicRet.ContainsKey(key))
                    dicRet.Add(key, new List<SubTypeGroup>());
                dicRet[key].Add(obj6);
                dicRet[key].Add(obj7);

                SubTypeGroup obj8 = new SubTypeGroup(8, "METER");
                key = 5;
                if (!dicRet.ContainsKey(key))
                    dicRet.Add(key, new List<SubTypeGroup>());
                dicRet[key].Add(obj8);

                return dicRet;
        }

        public int InsertChenCuocGoi(params object[] para)
        {
            return ExeStoreNoneQuery("sp_T_TAXIOPERATION_TRUCK_INSERT_ChenCuocGoi", para);
        }

        // lấy dữ liệu chủng loại hàng hóa
        public DataTable GetTypesOfGoods()
        {
            return ExeStore("sp_GetTypesOfGoods");
        }
        
        // lấy chỉ số về gần nhất
        public DataTable GetChiSoVe(params object[] para)
        {
            return ExeStore("Get_ChiSoVeGanNhat", para);
        }

        public DataTable GetKHBySDT(params object[] para)
        {
            try
            {
                return ExeStore("sp_T_DMKHACHHANG_SearchBySDT", para);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetXeDieuBySDT(params object[] para)
        {
            try
            {

                return ExeStore("sp_T_TaxiOperation_GetXeDieu_GoiLai", para);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetHoiGiaBySDT(params object[] para)
        {
            try
            {

                return ExeStore("sp_T_TaxiOperation_GetXeDieu_HoiGia", para);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Trả về danh sách các cuộc gọi xe từ số điện thoại đó
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public DataTable GetCGBySDT(params object[] para)
        {
            try
            {

                return ExeStore("sp_T_TaxiOperation_Check_GoiLai", para);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách xe nhận từ bảng T_TAXIOPERATION_TRUCK
        /// </summary>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllXeNhan_TaxiTai()
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_GET_XENHAN").ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Lấy danh sách xe nhận từ bảng T_TaxiOperation
        /// Taxi cũ dùng bảng này
        /// </summary>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllXeNhan_TaxiKhach()
        {
            return ExeStore("SP_T_TAXIOPERATION_GET_XENHAN").ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Lấy danh sách xe nhận đón từ bảng T_TaxiOperation
        /// Dùng cho EnVangVIP
        /// </summary>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllXeNhanDon_TaxiKhach()
        {
            return ExeStore("SP_T_TAXIOPERATION_GET_XEDON").ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Lấy danh sách xe đi tuyến từ bảng T_TAXIOPERATION_TRUCK - điều xe tải
        /// </summary>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAllXeNhan_ThueBaoTuyen_TaxiTai()
        {
            return ExeStore("SP_T_TAXIOPERATION_TRUCK_GET_XE_DI_THUEBAOTUYEN").ToList<TaxiOperation_Truck>();
        }

        /// <summary>
        /// Get danh sách các cuốc hàng hiện tại và gần đây cho bắt số
        /// </summary>
        /// <param name="ID">ID cuộc gọi = null thì lấy tất</param>
        /// <returns></returns>
        public List<TaxiOperation_Truck> GetAll_ForCallCapture(long ID)
        {
            return ExeStore("T_TaxiOperation_Truck_GetCuocGoi_ForMem").ToList<TaxiOperation_Truck>();
        }
        
        public int CheckSoXe(string Xe)
        {
            return ExeStore("sp_TaxiOperation_Truck_CheckSoXe", Xe).Rows.Count;
        }

        #region Điện thoại

        public long DienThoai_CopyNew()
        {
            try
            {
                var dt = ExeStore("SP_T_TAXIOPERATION_TRUCK_DienThoai_CopyNew");
                if (dt.Rows.Count <= 0)
                {
                    return -1;
                }
                var id = dt.Rows[0][0].To<long>();
                this.Id = id;
                return id > 0 ? id : -1;

            }
            catch
            {
                return -1;
            }
           
            
        }
        #endregion

        #region Temps

        ///// <summary>
        ///// Lấy danh sách xe đi tuyến của điều xe cũ. lấy từ bảng [TRUNGKIEN.T_NHATKYTHUEBAO]
        ///// </summary>
        ///// <returns></returns>
        //public List<TaxiOperation_Truck> GetAllXeNhan_ThueBaoTuyen_TaxiKhach()
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_GET_XENHAN_DITUYEN").ToList<TaxiOperation_Truck>();
        //}

        ////thêm mới hàng hóa
        //public int InsertTypeOfGoods(params object[] para)
        //{
        //    return ExeStoreNoneQuery("sp_TypesOfGoods_Insert", para);
        //}

        ////cập nhật thông tin hàng hóa
        //public int UpdateTypeOfGoods(params object[] para)
        //{
        //    return ExeStoreNoneQuery("sp_TypesOfGoods_Update", para);
        //}
        ////xóa thông tin hàng hóa
        //public int DeleteTypeOfGoods(params object[] para)
        //{
        //    return ExeStoreNoneQuery("sp_TypeOfGoods_Delete", para);
        //}

        //// cập nhật điểm đỗ mới
        //public int UpdateDiemDoMoi(params object[] para)
        //{
        //    return ExeStoreNoneQuery("SP_T_TAXIOPERATION_VEHICLE_STOP_UPDATE", para);
        //}
        //public int DeleteCuocHang(params object[] para)
        //{
        //    return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_DELETE", para);
        //}

        //public DataTable GetCauhinhBuXang()
        //{
        //    return ExeStore("SP_BanCo_Get_Config_BuXang");
        //}
        //public DataTable GetDL()
        //{
        //    return ExeStore("AllCuocHang");
        //}
        //public int InsertCuocHangKieuCuocGoi(params object[] para)
        //{
        //    int id = 0;
        //    var result = this.ExeStoreWithOutput("SP_T_TAXIOPERATION_TRUCK_TYPECALL_INSERT", para);
        //    id = result.Value["output"].To<int>();
        //    return id;
        //}
        //public int InsertCuocHang(params object[] para)
        //{
        //    int id = 0;
        //    var result = this.ExeStoreWithOutput("SP_T_TAXIOPERATION_TRUCK_INSERT", para);
        //    id = result.Value["output"].To<int>();
        //    return id;
        //}

        //public int UpdateCuocHang(params object[] para)
        //{
        //    return ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_UPDATE", para);
        //}
        ///// <summary>
        ///// Lay danh sach cuoc goi theo vung hoac line tuong ung
        ///// </summary>
        ///// <param name="LineVung"></param>
        ///// <returns></returns>
        //public List<TaxiOperation_Truck> GetAllByLine_Vung(params object[] para)
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep", para).ToList<TaxiOperation_Truck>();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vung"></param>
        ///// <param name="ismaytinh"></param>
        ///// <param name="tttk"></param>
        ///// <returns></returns>
        //public List<TaxiOperation_Truck> GetAllByLine_Vung(string vung, int ismaytinh, ThongTinTimKiem tttk)
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep_v21", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck>();
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vung"></param>
        ///// <param name="ismaytinh"></param>
        ///// <param name="tttk"></param>
        ///// <returns></returns>
        //public List<TaxiOperation_Truck> GetAllByLine_Vung_ThueBaoTuyen(string vung, int ismaytinh, ThongTinTimKiem tttk)
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep_ThueBaoTuyen_v21", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck>();
        //}
        //public List<TaxiOperation_Truck> GetAllByDate_SoHieuXe(string vung, int ismaytinh, ThongTinTimKiem tttk)
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep_ThueBaoTuyen_v21", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck>();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vung"></param>
        ///// <param name="ismaytinh"></param>
        ///// <param name="tttk"></param>
        ///// <returns></returns>
        //public List<TaxiOperation_Truck> GetAllByLine_Vung_CuocGoiMoi(string vung, int ismaytinh, ThongTinTimKiem tttk, DateTime? lastTime)
        //{
        //    return ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep_CuocGoiMoi_v21", vung, ismaytinh, tttk.SoXe, tttk.DienThoai, tttk.DiaChi, lastTime, tttk.IsAllLine_Vung).ToList<TaxiOperation_Truck>();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vung"></param>
        ///// <param name="ismaytinh"></param>
        ///// <returns></returns>
        //public ShKeyValue<int, int> GetAllByLine_Vung_CuocGoiMoi_Count(string vung, int ismaytinh)
        //{
        //    var data = ExeStore("SP_T_TAXIOPERATION_TRUCK_LayAllOfVungChoPhep_CuocGoiMoi_v21_ForCount", vung, ismaytinh, null, null, null).ToList<TaxiOperation_Truck>();

        //    return new ShKeyValue<int, int>
        //    {
        //        Key = data.Count,
        //        Value = data.Count(d => d.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangVIP)
        //    };
        //}

        //public void UpdateNhanVienDieu(string ids, string user)
        //{
        //    this.ExeStoreNoneQuery("SP_T_TAXIOPERATION_TRUCK_Update_MaNVDieuXe", ids, user);
        //}
        #endregion

        public TaxiOperation_Truck GetTruckBySoXe(string soxe)
        {
            var re = new TaxiOperation_Truck();
            var ro = ExeStore("SP_T_TAXIOPERATION_TRUCK_GetAll_SoXe", soxe);
            if (ro.Rows.Count > 0)
            {
                re.Parse(ro.Rows[0]);
                return re;
            }
             return null;
           
        }
        public DataTable FindDataByDateAndLoaiXe(DateTime dt, string soXe)
        {
            return ExeStore("sp_TaxiOperation_Truck_FindDataByDateAndLoaiXe", dt, soXe);
        }
    }

    [TableInfo(TableName = "T_XE_DIEMDO")]
    public class Xe_Diemdo_Entity : TaxiOperationDbEntityBase<Xe_Diemdo_Entity>
    {
        [Field(IsKey = true)]
        public string FK_SoHieuXe { set; get; }

        [Field]
        public int FK_DiemDo { set; get; }

        [Field]
        public DateTime UpdateDate { set; get; }

        public int UpdateDiemDoMoi(params object[] para)
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_VEHICLE_STOP_UPDATE",para);
        }

        public int GetDiemDungDo(params object[] para)
        {
            DataTable tbl = ExeStore("SP_T_TAXIOPERATION_VEHICLE_STOP_GET", para);

            if (tbl.Rows.Count > 0)
            {
                int ret = -1;
                int.TryParse(tbl.Rows[0]["DiemDo"].ToString(),out ret);
                return ret;
            }
            return -1;
        }

        public TaxiOperation_Truck GetByID(long id)
        {
            return this.ExeStore("SP_TaxiOperation_Truck_GetByID", id).ToList<TaxiOperation_Truck>().FirstOrDefault();
        }

       
    }
}