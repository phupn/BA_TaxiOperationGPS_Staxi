using System.Collections.Generic;
using System.Linq;
using System.Data;
using Taxi.Data.BanCo.Entity.GPS;
using Taxi.Data.BanCo.Entity;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Data.BanCo.Entity.MasterData;
using Taxi.Utils;
using Taxi.Data.BanCo.Entity.TuyenThueBao;

namespace Taxi.Data.BanCo
{
    public class CommonData
    {
        public static bool IsSalary
        {
            get { 
                if(System.Configuration.ConfigurationManager.AppSettings["IsSalary"] != null)
                {
                    var Salary = System.Configuration.ConfigurationManager.AppSettings["IsSalary"];
                    return Salary.Equals("1");
                }
                return false;
            }
        }       

        #region Danh sách xe
        /// <summary>
        /// Danh sách xe trên hệ thống
        /// </summary>
        public static List<DMXe> ListXe { get; set; }
        
        /// <summary>
        /// Load danh sách xe hiện có trên hệ thống
        /// </summary>
        public static void LoadVehicles()
        {
            ListXe = new DMXe().GetListAll();
        }

        /// <summary>
        /// lấy danh sách xe chưa khai báo trong bảng Giám Sát Xe để khai báo ra kinh doanh
        /// </summary>
        public static List<BanCo_GiamSatXe> ListXe_NotIn_GiamSatXe
        {
            get
            {
                return new BanCo_GiamSatXe().GetListAll_NotIn_GiamSatXe();
            }
        }

        /// <summary>
        /// lấy danh sách xe chưa khai báo về
        /// </summary>
        public static List<BanCo_GiamSatXe> ListXe_XeChuaVe
        {
            get
            {
                return new BanCo_GiamSatXe().GetListAll_XeChuaVe();
            }
        }

        /// <summary>
        /// Lấy tất cả xe có kèm lái xe mặc định
        /// </summary>
        /// <returns></returns>
        public static List<GiamSatXe_HoatDong> GetListAll_MaNhanVien
        {
            get
            {
                return new GiamSatXe_HoatDong().GetListAll_MaNhanVien();
            }
        }

        /// <summary>
        /// kiểm tra xe danh sách xe có tồn tại trong danh sách xe của hệ thống ko. danh sách xe truyền vào cách nhau bởi dấu chấm
        /// </summary>
        /// <param name="strVehicle">danh sách xe cần check</param>
        /// <returns>True : có trùng, ngược lại là không trùng</returns>
        public static bool CheckExistVehicleInSystem(string strVehicle)
        {
            bool returnValue = false;
            if (!string.IsNullOrEmpty(strVehicle))
            {
                foreach (var item in strVehicle.Split('.'))
                {
                    if (string.IsNullOrEmpty(item)) continue;

                    if (ListXe.FindIndex(t => t.PK_SoHieuXe.Trim() == item.Trim()) > 0)
                    {
                        returnValue = true;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion        

        public static DataTable _DtbTypeOfGoods { set; get; }

        public static DataTable DtbTypeOfGoods
        {
            get
            {
                if (_DtbTypeOfGoods == null)
                    _DtbTypeOfGoods = new TaxiOperation_Truck().GetTypesOfGoods();
                return _DtbTypeOfGoods;
            }
            set
            {
                _DtbTypeOfGoods = value;
            }
        }


        /// <summary>
        ///  danh sách các tuyến chạy
        /// </summary>
        public static DataTable _ListGroup { set; get; }

        /// <summary>
        /// Get All Chạy Tuyến
        /// </summary>
        public static DataTable ListGroup
        {
            get
            {
                if (_ListGroup == null)
                    _ListGroup = new TaxiOperation_Truck() .GetGroup();
                return _ListGroup;
            }
            set
            {
                _ListGroup = value;
            }
        }
        
        //List<T_NHANVIEN> lNhanVien = new T_NHANVIEN().GetListAll();

        //public static List<T_NHANVIEN> _ListNhanVien { set; get; }

        //public static List<T_NHANVIEN> ListNhanVien
        //{
        //    get
        //    {
        //        if (_ListNhanVien == null)
        //            _ListNhanVien = new T_NHANVIEN().GetListAll();
        //        return _ListNhanVien;
        //    }
        //    set
        //    {
        //        _ListNhanVien = value;
        //    }
        //}
        
        #region Config
        private static Dictionary<Taxi.Utils.Enum_Config_Alert, BanCo_Config> dic = null;

        /// <summary>
        /// Get gia tri cau hinh chung cua he thong
        /// </summary>
        public static Dictionary<Taxi.Utils.Enum_Config_Alert, BanCo_Config> ConfigsBanCo
        {
            get
            {
                if (dic == null)
                    dic = new BanCo_Config().GetListAll().ToDictionary(c => c.Id, c => c);
                return dic;
            }
        }
        private static string _SDTBocXep;
        public static string SDTBocXep
        {
            get
            {
                if (_SDTBocXep == null)
                    _SDTBocXep = ConfigsBanCo[Enum_Config_Alert.SDTBoPhanBocXep].Value;
                return _SDTBocXep;
            }
        }

        private static string _SDTLXKT;
        public static string SDTLXKT
        {
            get
            {
                if (_SDTLXKT == null)
                    _SDTLXKT = ConfigsBanCo[Enum_Config_Alert.SDTLaiXeKhaiThac].Value;
                return _SDTLXKT;
            }
        }

        public static List<ColorOfStatusModel> _ListColorOfStatusModel { set; get; }

        private static List<DoiTacStep> _ListDoiTacStep;
        public static List<DoiTacStep> ListDoiTacStep
        {
            get
            {
                if (_ListDoiTacStep == null)
                    _ListDoiTacStep = new DoiTacStep().GetAllDoiTacStep();
                return _ListDoiTacStep;
            }
        }

        #endregion

        #region Danh sách Loai xe
        /// <summary>
        /// Danh sách xe trên hệ thống
        /// </summary>
        public static List<TuDien_LoaiXe> _ListLoaiXe { get; set; }

        /// <summary>
        /// Load danh sách loại xe hiện có trên hệ thống
        /// </summary>
        public static List<TuDien_LoaiXe> ListLoaiXe
        {
             get
            {
                if (_ListLoaiXe == null)
                    _ListLoaiXe = new TuDien_LoaiXe().GetListAll();
                return _ListLoaiXe;
            }
            set
            {
                _ListLoaiXe = value;
            }
        }
        #endregion        

        #region Road
        private static List<T_Road> _roads;
        public static List<T_Road> Roads
        {
            get
            {
                if (_roads == null)
                    _roads = new T_Road().GetListAll();
                return _roads;
            }
        }
        #endregion

        #region Vùng điều hành

        private static List<VungDieuHanh> _dsVungDieuHanh;
        public static List<VungDieuHanh> DSVungDieuHanh
        {
            get
            {
                if (_dsVungDieuHanh == null)
                    _dsVungDieuHanh = new VungDieuHanh().GetAllVungDieuHanh();
                return _dsVungDieuHanh;
            }
        }

        #endregion
        
        #region Lý do trượt hàng

        private static List<StatusManagement> _dsLyDoTruotHang;
        public static List<StatusManagement> DSLyDoTruotHang
        {
            get
            {
                //if (_dsLyDoTruotHang == null)
                //    _dsLyDoTruotHang = new StatusManagement().GetListReason(Enum_ReasonType.VehicleLossTrip);
                return  StatusManagement.Inst.GetListReason(Enum_ReasonType.VehicleLossTrip);
            }
        }

        #endregion

        #region Danh sách điểm xuất phát

        private static List<DiemXuatPhat> _dsDiemXuatPhat;
        public static List<DiemXuatPhat> DSDiemXuatPhat
        {
            get
            {
                if (_dsDiemXuatPhat == null)
                    _dsDiemXuatPhat = new DiemXuatPhat().getListDiemXP();
                return _dsDiemXuatPhat;
            }
        }

        #endregion

        #region Commands
        public static List<TaxiOperationCommand> _commands;
        public static List<TaxiOperationCommand> Commands
        {
            get
            {
                if (_commands == null)
                {
                    _commands = new TaxiOperationCommand().GetListAll();
                }
                return _commands;
            }
        }
        public static void UpdateCommands()
        {
            _commands = null;
        }
        #endregion

        #region Thue Bao Tuyến
        public static bool isCuocThueBaoTuyen(LoaiCuocHangThucHien loaiCuocHang)
        {
            if (loaiCuocHang == LoaiCuocHangThucHien.CuocBinhThuong ||
                loaiCuocHang == LoaiCuocHangThucHien.MoCua ||
                loaiCuocHang == LoaiCuocHangThucHien.ThueBaoMeter)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get bảng giá cước theo loại xe và tuyến đường
        /// </summary>

        //public static string GetBangGiaCuoc(int LoaiXeID, int TuyenDuong,Enum_GroupType ChayTuyen, Enum_Chieu Chieu)
        //{
        //    BangGiaCuoc bgc = new BangGiaCuoc();
        //    if(ChayTuyen == Enum_GroupType.TheoCa)
        //        bgc = new BangGiaCuoc().getBangGiaByShift(LoaiXeID);
        //    else if(ChayTuyen == Enum_GroupType.NgoaiTinh || ChayTuyen == Enum_GroupType.NoiTinh)
        //        bgc = new BangGiaCuoc().getBangGiaByLoaiXeID(LoaiXeID, null, TuyenDuong);
        //    else if (ChayTuyen == Enum_GroupType.ThueBaoTuDo)
        //        bgc = new BangGiaCuoc().getBangGiaTuDo(LoaiXeID);

        //    string strBangGiaGoc = "";
        //    if (bgc != null)
        //    {
        //        if (Chieu == Enum_Chieu.TheoCa_NuaNgay)
        //            strBangGiaGoc = bgc.GiaTien1Chieu.ToString() + "/" + bgc.KmQuyDinh1Chieu.ToString() + "/" + bgc.ThoiGianQuyDinh1Chieu.ToString();
        //        else if (Chieu == Enum_Chieu.TheoCa_MotNgay)
        //                strBangGiaGoc = bgc.GiaTien2Chieu.ToString() + "/" + bgc.KmQuyDinh2Chieu.ToString() + "/" + bgc.ThoiGianQuyDinh2Chieu.ToString();
        //    }
        //    return strBangGiaGoc;
        //}
        #endregion


        //public static bool CheckVungNamTrongVungCauHinh(int Vung)
        //{
        //    bool bCheck = false;
        //    if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
        //    {
        //        string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
        //        for (int i = 0; i < arrVung.Length; i++)
        //        {
        //            if (Convert.ToInt32(arrVung[i]) == Vung)
        //            {
        //                bCheck = true; break;
        //            }
        //        }
        //    }
        //    else bCheck = false;
        //    return bCheck;
        //}

        /// <summary>
        /// Lưu thông tin xe online
        /// </summary>
        public static Dictionary<string, VehicleOnline> G_Dict_VehicleOnline
        {
            get;
            set;
        }

        public static Dictionary<string, string> G_Dict_Vehicle
        {
            get;
            set;
        }
    }
}
