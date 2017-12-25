using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Taxi.Business.QuanTri;
using Taxi.Common.Extender;
using Taxi.Data.BanCo.Entity.GPS;
using Taxi.Data.BanCo.Entity;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Data.BanCo.Entity.MasterData;
using Taxi.Utils;
using Taxi.Data.BanCo.Entity.TuyenThueBao;
using Taxi.Data.BanCo.Entity.Config;
using Taxi.Data.FastTaxi;
using Taxi.Data.G5.DanhMuc;
using Taxi.Utils.Enums;

namespace Taxi.Business
{
    public class CommonBL
    {
        /// <summary>
        /// Load lại các đối tượng dùng chung
        /// </summary>
        public static void ReLoadCommon()
        {
            _listStaxiLoaiXe = null;
            _dictDriver = null;
            _dictDriver_MaNV = null;
            _ListAllCode = null;
            LoadVehicles();
            LoadDrivers_Active();
            Config_Common.LoadConfigCommon();
            if (Config_Common.NhapTuyenDuongDai || Config_Common.App_DieuXeHopDong)
                CommonBL.LoadTuyenDuongDai();
        }

        #region Danh sách xe
        /// <summary>
        /// Danh sách xe trên hệ thống
        /// </summary>
        public static List<Data.BanCo.Entity.DM.DMXe> ListXe { get; set; }
        /// <summary>
        /// Dic Xe:Số hiệu Xe- Biển số xe
        /// </summary>
        public static Dictionary<string, string> DicXe { get; set; }
        /// <summary>
        /// Dic xe:Số hiệu xe - Object Xe
        /// </summary>
        public static Dictionary<string, Data.BanCo.Entity.DM.DMXe> DicObjecXe { get; set; }
        /// <summary>
        /// Load danh sách xe hiện có trên hệ thống
        /// </summary>
        public static void LoadVehicles()
        {
            try
            {
                Vehicles_Active_LastUpdate = DateTime.Now; 
                DicXe = new Dictionary<string, string>();
                DicObjecXe = new Dictionary<string, Data.BanCo.Entity.DM.DMXe>();
                ListXe = new Data.BanCo.Entity.DM.DMXe().GetListAll();
                
                foreach (var item in ListXe)
                {
                    if (!DicXe.ContainsKey(item.PK_SoHieuXe))
                    {
                        DicXe.Add(item.PK_SoHieuXe, item.BienKiemSoat);
                    }
                    else
                    {
                        DicXe[item.PK_SoHieuXe] = item.BienKiemSoat;
                    }
                    if (!DicObjecXe.ContainsKey(item.PK_SoHieuXe))
                    {
                        DicObjecXe.Add(item.PK_SoHieuXe, item);
                    }
                    else
                    {
                        DicObjecXe[item.PK_SoHieuXe] = item;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi Load Danh sách xe hệ thống",ex);
            }
        }

        private static DateTime Vehicles_Active_LastUpdate;
        public static void LoadVehicles_Active_LastUpdate()
        {
            try
            {
                if ((Vehicles_Active_LastUpdate==DateTime.MinValue) && DicObjecXe != null && DicObjecXe.Count > 0)
                    Vehicles_Active_LastUpdate = DicObjecXe.Max(p => p.Value.LastUpdate);
                if ((Vehicles_Active_LastUpdate == null || Vehicles_Active_LastUpdate == DateTime.MinValue)) Vehicles_Active_LastUpdate = DieuHanhTaxi.GetTimeServer();
                if ((Vehicles_Active_LastUpdate == null || Vehicles_Active_LastUpdate == DateTime.MinValue)) Vehicles_Active_LastUpdate = DateTime.Now;
                var ListXeUpdate = Data.BanCo.Entity.DM.DMXe.Inst.GetLastUpdate(Vehicles_Active_LastUpdate);

                if (ListXeUpdate != null && ListXeUpdate.Count>0)
                {
                    foreach (var item in ListXeUpdate)
                    {
                        if (item.LastUpdate > Vehicles_Active_LastUpdate) Vehicles_Active_LastUpdate = item.LastUpdate;
                        if (!DicXe.ContainsKey(item.PK_SoHieuXe))
                        {
                            DicXe.Add(item.PK_SoHieuXe, item.BienKiemSoat);
                        }
                        else
                        {
                            DicXe[item.PK_SoHieuXe] = item.BienKiemSoat;
                        }
                        if (!DicObjecXe.ContainsKey(item.PK_SoHieuXe))
                        {
                            DicObjecXe.Add(item.PK_SoHieuXe, item);
                        }
                        else
                        {
                            DicObjecXe[item.PK_SoHieuXe] = item;
                        }
                    }
                    if (DicObjecXe != null) ListXe = DicObjecXe.Select(p => p.Value).ToList();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadVehicles_Active_LastUpdate", ex);
            }
        }

        /// <summary>
        /// Convert Từ số hiệu sang biển số
        /// </summary>
        /// <param name="soHieuXe">Số hiệu xe</param>
        /// <param name="soLan">Số lần</param>
        /// <returns>Biển số xe</returns>
        public static string ConvertSangBienSo(string soHieuXe,int soLan=0)
        {
            try
            {
                if (DicXe != null && DicXe.Count > 0)                
                {
                    if (DicXe.ContainsKey(soHieuXe) && DicXe[soHieuXe].Trim().Length>0)
                    {
                        return DicXe[soHieuXe];
                    }                   
                }
                if (soLan < 2)
                {
                    var xe = Data.BanCo.Entity.DM.DMXe.Inst.GetDMXeTheoSoXe(soHieuXe);
                    if(xe!=null)
                    //    return ConvertSangBienSo(soHieuXe, soLan++);
                    //else
                    {
                        if (DicObjecXe != null)
                        {
                            if (DicObjecXe.ContainsKey(xe.PK_SoHieuXe))
                                DicObjecXe[xe.PK_SoHieuXe] = xe;
                            else
                                DicObjecXe.Add(xe.PK_SoHieuXe, xe);
                        }
                        if (DicXe != null)
                        {
                            if (DicXe.ContainsKey(xe.PK_SoHieuXe))
                            {
                                DicXe[xe.PK_SoHieuXe] = xe.BienKiemSoat;
                            }
                            else
                            {
                                DicXe.Add(xe.PK_SoHieuXe, xe.BienKiemSoat);
                            }

                            return xe.BienKiemSoat;
                        }
                    }
                }                
            }
            catch (Exception ex) 
            {
                LogError.WriteLogError(string.Format("ConvertSangBienSo:{0}-{1}", soHieuXe, soLan), ex);
                //return ConvertSangBienSo(soHieuXe, soLan++); 
            }
            return string.Empty;
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

        #endregion

        /// <summary>
        /// Ham tra ve thoi gian hien tai cua may chu
        /// </summary>
        public static DateTime GetTimeServer()
        {
            return new Data.DieuHanhTaxi().GetTimeServer();
        }

        public static DataTable DataTypeOfGoods { set; get; }

        /// <summary>
        ///  Danh sách các tuyến chạy
        /// </summary>
        public static DataTable ListGroup { set; get; }

        /// <summary>
        /// Dictionary Cuốc App
        /// số xe - Bookid
        /// </summary>
        public static Dictionary<string, Guid> DictApp_Current
        {
            get;
            set;
        }

        #region Network Type
        private static Dictionary<string, Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE> _Dict_MobileNetwork_AREACODE;

        /// <summary>
        /// dict AreaCode - MobileNetwork AreaCode
        /// </summary>
        public static Dictionary<string, Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE> Dict_MobileNetwork_AREACODE
        {
            get
            {
                if (_Dict_MobileNetwork_AREACODE == null)
                {
                    _Dict_MobileNetwork_AREACODE = Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE.Inst.GetListItem().ToDictionary(T=>T.AreaCode, T => T);
                }
                return _Dict_MobileNetwork_AREACODE;
            }
            set
            {
                _Dict_MobileNetwork_AREACODE = value;
            }
        }


        private static Dictionary<string, Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE> _Dict_MobileNetwork_AREACODE_CD;
        /// <summary>
        /// dict AreaCode - MobileNetwork AreaCode Type cố định
        /// </summary>
        public static Dictionary<string, Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE> Dict_MobileNetwork_AREACODE_CD
        {
            get
            {
                if (_Dict_MobileNetwork_AREACODE_CD == null)
                {
                    _Dict_MobileNetwork_AREACODE_CD = Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE.Inst.GetListItem().Where(P => P.MobileNetworkType == Enum_MobileNetWork_Type.CoDinh).ToDictionary(T => T.AreaCode, T => T);
                }
                return _Dict_MobileNetwork_AREACODE_CD;
            }
            set
            {
                _Dict_MobileNetwork_AREACODE_CD = value;
            }
        }

        private static Dictionary<string, Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE> _Dict_MobileNetwork_AREACODE_DD;
        public static Dictionary<string, Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE> Dict_MobileNetwork_AREACODE_DD
        {
            get
            {
                if (_Dict_MobileNetwork_AREACODE_DD == null)
                {
                    _Dict_MobileNetwork_AREACODE_DD = Taxi.Data.G5.DanhMuc.MobileNetwork_AREACODE.Inst.GetListItem().Where(P => P.MobileNetworkType == Enum_MobileNetWork_Type.DiDong).ToDictionary(T => T.AreaCode, T => T);
                }
                return _Dict_MobileNetwork_AREACODE_DD;
            }
            set
            {
                _Dict_MobileNetwork_AREACODE_DD = value;
            }
        }
        /// <summary>
        /// Check là số di động - Theo quy định đầu số
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber_Cellphone(string phoneNumber)
        {
            bool result = false;
            if (phoneNumber != null || phoneNumber.Length > 10)
            {
                foreach (KeyValuePair<string, MobileNetwork_AREACODE> item in CommonBL.Dict_MobileNetwork_AREACODE_DD)
                {
                    if (phoneNumber.StartsWith(item.Key))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Check là số điện thoại bàn - Theo quy định đầu số
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber_Telephone(string phoneNumber)
        {
            bool result = false;
            if (phoneNumber != null || phoneNumber.Length > 10)
            {
                foreach (KeyValuePair<string, MobileNetwork_AREACODE> item in CommonBL.Dict_MobileNetwork_AREACODE_CD)
                {
                    if (phoneNumber.StartsWith(item.Key))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Số điện thoại hợp lệ - Theo quy định đầu số
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber_Valid(string phoneNumber)
        {
            bool result = false;
            if (phoneNumber != null || phoneNumber.Length > 10)
            {
                foreach (KeyValuePair<string, MobileNetwork_AREACODE> item in CommonBL.Dict_MobileNetwork_AREACODE)
                {
                    if (phoneNumber.StartsWith(item.Key))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        #endregion

        #region Nhan Vien
        public static List<T_NHANVIEN> ListNhanVien { set; get; }
        
        public static List<T_NHANVIEN> ListDriver_Active
        {
            get
            {
                return _dictDriver == null ? null : _dictDriver_MaNV.Select(p => p.Value).ToList();
            }
        }

        private static DateTime Driver_LastUpdate;
        private static List<T_NHANVIEN> _listDriver_Active;
        /// <summary>
        /// Load danh sách lái xe theo thời gian
        /// </summary>
        public static bool LoadDrivers_Active_LastUpdate()
        {
            bool hasUpdate = false;
            
            try
            {
                if ((Driver_LastUpdate== DateTime.MinValue) && _listDriver_Active != null && _listDriver_Active.Count > 0)
                    Driver_LastUpdate = _listDriver_Active.Max(p => p.LastUpdate);
                if (Driver_LastUpdate == null || Driver_LastUpdate== DateTime.MinValue)
                {
                    Driver_LastUpdate = GetTimeServer();
                }
                if (_listDriver_Active == null)
                    _listDriver_Active = new T_NHANVIEN().GetAllDriver_Active();
                else
                    _listDriver_Active = new T_NHANVIEN().GetAllDriver_Active_GetLast(Driver_LastUpdate);

                if (_dictDriver == null) 
                {
                    _dictDriver = new Dictionary<string, T_NHANVIEN>();
                }
                if (_listDriver_Active != null && _listDriver_Active.Count > 0)
                {
                    hasUpdate = true;
                    foreach (var item in _listDriver_Active)
                    {
                        if (item.LastUpdate > Driver_LastUpdate) Driver_LastUpdate = item.LastUpdate;

                        if (!_dictDriver.ContainsKey(item.FK_SoHieuXeLai))
                        {
                            _dictDriver.Add(item.FK_SoHieuXeLai, item);
                        }
                        else
                        {
                            _dictDriver[item.FK_SoHieuXeLai] = item;
                        }

                        if (!_dictDriver_MaNV.ContainsKey(item.PK_MaNhanVien))
                        {
                            _dictDriver_MaNV.Add(item.PK_MaNhanVien, item);
                        }
                        else
                        {
                            _dictDriver_MaNV[item.PK_MaNhanVien] = item;
                        }
                    }
                }
            }
            catch (Exception exx)
            {
                LogError.WriteLogError("LoadDrivers_Active_LastUpdate", exx);
            }

            return hasUpdate;
        }
        public static void LoadDrivers_Active()
        {
            try
            {
                if (_listDriver_Active == null)
                    _listDriver_Active = new T_NHANVIEN().GetAllDriver_Active();
                if (_dictDriver == null)
                {
                    _dictDriver = new Dictionary<string, T_NHANVIEN>();
                }
                if (_dictDriver_MaNV == null)
                {
                    _dictDriver_MaNV = new Dictionary<string, T_NHANVIEN>();
                }
                if (_listDriver_Active != null && _listDriver_Active.Count > 0)
                {
                    foreach (var item in _listDriver_Active)
                    {
                        if (!_dictDriver.ContainsKey(item.FK_SoHieuXeLai))
                        {
                            _dictDriver.Add(item.FK_SoHieuXeLai, item);
                        }

                        if (!_dictDriver_MaNV.ContainsKey(item.PK_MaNhanVien))//*sign
                        {
                            _dictDriver_MaNV.Add(item.PK_MaNhanVien,item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadDrivers_Active ",ex);
            }
        }

        private static Dictionary<string, T_NHANVIEN> _dictDriver;
        private static Dictionary<string, T_NHANVIEN> _dictDriver_MaNV;
        /// <summary>
        /// Dictionary Lái xe
        /// số xe - obj lái xe
        /// </summary>
        public static Dictionary<string, T_NHANVIEN> DictDriver 
        { 
            get 
            {
                return _dictDriver;
            }
            set
            {
                _dictDriver = value;
            }
        }

        #endregion

        #region Config
        private static Dictionary<Enum_Config_Alert, BanCo_Config> dic = null;

        /// <summary>
        /// Get gia tri cau hinh chung cua he thong
        /// </summary>
        public static Dictionary<Enum_Config_Alert, BanCo_Config> ConfigsBanCo
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

        private static int _LineMacDinh = -1;
        /// <summary>
        /// Line mặc định khi tổng đài thêm mới cuộc gọi
        /// </summary>
        public static int LineMacDinh
        {
            get
            {
                if (_LineMacDinh == -1)
                    int.TryParse(ConfigsBanCo[Enum_Config_Alert.LineDefault].Value, out _LineMacDinh);
                return _LineMacDinh;
            }
        }

        //private static int _VungMacDinh_DuocGan = -1;
        ///// <summary>
        ///// Vùng mặc định được gán khi chèn cuộc gọi
        ///// </summary>
        //public static int VungMacDinh_DuocGan
        //{
        //    get
        //    {
        //        if(_VungMacDinh_DuocGan == -1)
        //            int.TryParse(ThongTinDangNhap.LineVung.Split(';')[0], out _VungMacDinh_DuocGan);
        //        return _VungMacDinh_DuocGan;
        //    }
        //}
        #endregion

        #region Danh sách Loai xe
        /// <summary>
        /// Danh sách xe trên hệ thống
        /// </summary>
        public static List<TuDien_LoaiXe> ListLoaiXe { get; set; }

        #endregion

        #region Loại khách hàng
        /// <summary>
        /// Danh sách xe trên hệ thống
        /// </summary>
        public static List<DanhBaKhachQuen_Type> _ListLoaiKH { get; set; }

        /// <summary>
        /// Load danh sách loại xe hiện có trên hệ thống
        /// </summary>
        public static List<DanhBaKhachQuen_Type> ListLoaiKH
        {
            get
            {
                if (_ListLoaiKH == null)
                    _ListLoaiKH = DanhBaKhachQuen_Type.GetDanhSachKhachQuen_Type();
                return _ListLoaiKH;
            }
        }
        #endregion

        #region khách hàng
        /// <summary>
        /// Danh sách xe trên hệ thống
        /// </summary>
        public static List<T_DMKHACHHANG> ListKH { get; set; }

        #endregion

        #region Danh sách Vùng GPS
        //private static VungBound[] _listVungDieuHanh;
        //public static VungBound[] ListVungDieuHanh
        //{
        //    get
        //    {
        //        if (_listVungDieuHanh == null)
        //            _listVungDieuHanh = new SyncServiceOnlineClient().GetListVungDieuHanh_XN(ThongTinCauHinh.GPS_MaCungXN);
        //        return _listVungDieuHanh;
        //    }
        //    set
        //    {
        //        _listVungDieuHanh = value;
        //    }
        //}
        
        #endregion

        #region Gioi Han Cuoc Goi
        //public static bool HasModifyData(TaxiOperation_Truck objCuocGoi)
        //{
        //    if (ThongTinDangNhap.IsMayTinh == Enum_ChucNangNhiemVu.DienThoaiVien)
        //    {
        //        if (!ThongTinDangNhap.LineVung.Contains(objCuocGoi.Line.ToString()))
        //        {
        //            new Taxi.MessageBox.MessageBox().Show("Không có quyền thực hiện line khác");
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        if (!ThongTinDangNhap.LineVung.Contains(objCuocGoi.Vung.ToString()))
        //        {
        //            new Taxi.MessageBox.MessageBox().Show("Không có quyền thực hiện vùng khác");
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// Nếu tổng số cuộc gọi đạt ngưỡng giới hạn này thì cho phép phần mềm thoát cuốc tự động
        ///// </summary>
        //public static int GioiHanCuocGoi { set; get; }
        #endregion

        #region POI_Address
        private static List<District> _districts;
        public static List<District> Districts
        {
            get
            {
                if (_districts == null)
                    _districts = new District().GetAll_List();
                return _districts;
            }
        }

        private static List<Province> _provinces;
        public static List<Province> Provinces
        {
            get
            {
                if (_provinces == null)
                    _provinces = new Province().GetAll_List();
                return _provinces;
            }
        }
        private static List<Commune> _communes;
        public static List<Commune> Communes
        {
            get
            {
                if (_communes == null)
                    _communes = new Commune().GetAll_List();
                return _communes;
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

        public static List<StatusManagement> DSLyDoTruotHang
        {
            get
            {
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

        private  static List<TaxiOperationCommand> _commands;
        public static List<TaxiOperationCommand> Commands
        {
            get { return _commands ?? (_commands = new TaxiOperationCommand().GetListAll()); }
            set
            {
                _commands = value;
            }
        }
        
        /// <summary>
        /// Hàm lấy tên lệnh theo phím tắt trong T_Taxioperation_Command
        /// </summary>
        /// <param name="pShortCut">Phím tắt lệnh trong DB </param>
        /// <param name="pFuncUsing">Hệ thống 1: Điện thoại; 2: Tổng đài</param>  
        
        public static string GetNameByKey(int pShortCut, int pFuncUsing) 
        {
            try
            {
                return Commands.FirstOrDefault(a => a.Shortcuts == pShortCut && a.FunctionUsing == pFuncUsing).Command;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Hàm lấy tên lệnh trong T_Taxioperation_Command
        /// </summary>
        /// <param name="pCommandCode">Mã CommandCode trong DB</param>
        /// <param name="pFuncUsing">Hệ thống 1:Điện thoại; 2:Tổng đài</param>
        public static string GetNameByCode(string pCommandCode, int pFuncUsing)
        {
            try
            {
                var item = Commands.FirstOrDefault(a => a.CommandCode == (Enum_CommandCode)pCommandCode.To<int>() && a.FunctionUsing == pFuncUsing);
                if (item != null)
                    return item.Command;
                return "";
            }
            catch
            {
                return "";
            }
        }
        public static string GetNameByCodeEnum(Enum_CommandCode pCommandCode, int pFuncUsing)
        {
            try
            {
                var item = Commands.FirstOrDefault(a => a.CommandCode == pCommandCode && a.FunctionUsing == pFuncUsing);
                if (item != null)
                    return item.Command;
                return "";
            }
            catch
            {
                return "";
            }
        }
        public static void UpdateCommands()
        {
            _commands = null;
        }
        public static int WorkflowId { get; set; }
        private static List<MobileOperationCommands> _mobileCommand;
        public static List<MobileOperationCommands> MobileCommand
        {
            get
            {
                if (_mobileCommand == null)
                {
                    _mobileCommand = MobileOperationCommands.Inst.GetListByWorkflowId(WorkflowId);
                }
                return _mobileCommand;
            }
        }
        private static List<MobileOperationCommands> _mobileCommandAll;
        public static List<MobileOperationCommands> MobileCommandAll
        {
            get
            {
                if (_mobileCommandAll == null)
                {
                    _mobileCommandAll = MobileOperationCommands.Inst.GetListAll();
                }
                return _mobileCommandAll;
            }
        }
        public static void UpdateMobileCommand()
        {
            _mobileCommand = null;
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
        public static List<THUEBAO_T_KIEUTUYEN> ListKieuTuyen { get; set; }
        public static List<TuDien_LoaiXe> ListHangXe { get; set; }
        public static List<DMTuyenThueBao> ListTuyenDuong { get; set; }

        public static Dictionary<string, string> DicTuyenDuong = new Dictionary<string, string>();
        public static List<VuotGioQuyDinh> ListDanhMucVuotGio { get; set; }

        #endregion

        public static List<QuanTriCauHinhEntity> ListQuanTriCauHinh { get; set; }

        private static List<AllCodeEntity> _ListAllCode;
        public static List<AllCodeEntity> ListAllCode
        {
            get
            {
                if (_ListAllCode == null)
                    _ListAllCode = AllCodeEntity.Inst.GetListAll();
                return _ListAllCode;
            }
            set
            {
                _ListAllCode = value;
            }
        }

        /// <summary>
        /// Sử dụng điều loại xe
        /// </summary>
        public static bool IsStaxiLoaiXe = true;
        public static List<StaxiCarType> _listStaxiLoaiXe;
        public static List<StaxiCarType> ListStaxiLoaiXe
        {
            get
            {
                try
                {
                    if (_listStaxiLoaiXe == null)
                        _listStaxiLoaiXe = StaxiCarType.GetList();
                    if (_listStaxiLoaiXe == null || _listStaxiLoaiXe.Count == 0)
                        IsStaxiLoaiXe = false;
                    else IsStaxiLoaiXe = true;                   
                }
                catch (Exception ex)
                {
                    IsStaxiLoaiXe = false;
                    LogError.WriteLogError("CommonBL.ListG5LoaiXe", ex);
                    _listStaxiLoaiXe= new List<StaxiCarType>();
                }
                return _listStaxiLoaiXe;
            }
        }
        //public st//ic void LoadStaxiLoaiXe()
        //{
      ////    ListS//xiLoaiXe.Count();
        //}

        public static void LoadTuyenDuongDai()
        {
            ListKieuTuyen = new THUEBAO_T_KIEUTUYEN().GetAll().ToList<THUEBAO_T_KIEUTUYEN>();
            ListHangXe = new TuDien_LoaiXe().GetListAll();
            ListTuyenDuong = new DMTuyenThueBao().GetAll().ToList<DMTuyenThueBao>();
            ListDanhMucVuotGio = new VuotGioQuyDinh().GetListAll();
        }

        /// <summary>
        /// Đánh dấu đang có sos
        /// </summary>
        public static bool HavingSOS { get; set; }
    }
}
