using Taxi.Common.EnumUtility;

namespace Taxi.Utils
{
    /// <summary>
    /// Trạng thái cuốc hiện tại:
    /// 0:Cuốc mới nhận điện thoại chưa thao tác gì.
    /// 1:Cuốc đã thực hiện chuyển sang đàm với 3 TH:
    /// 1.1:Cuốc điều đàm bình thường:Khi đó lệnh lái xe là rỗng.
    /// 1.2:Cuốc điều app cũng có 2 TH:
    /// 1.2.1:Không xe chuyển sang đam.
    /// 1.2.2:Lái xe hủy:Xe hỏng,điều xe khác.
    /// 1.3:Cuốc đặt từ app KH:Không xe và trả về trung tâp khai thác tiếp thị điều tiếp.
    /// 2:Cuốc đặt từ app KH và chưa sang đàm.
    /// 3:Cuốc điều app chờ thực hiện cuốc hoàn thành.
    /// </summary>
    public enum Enum_G5_Type
    {
       
        None=-1,
        /// <summary>
        /// 0.Chưa xử lý và chưa sang đàm.
        /// </summary>
        DienThoai=0,
        /// <summary>
        /// 1.Đã chuyển sang đàm xử lý.
        /// </summary>
        ChuyenSangDam=1,
        /// <summary>
        /// 2.App KH ko tìm thấy xe và chuyển về trung tâm điều hành
        /// </summary>
        CuocKhongXeApp=2,
        /// <summary>
        /// 3.Điều app Lái xe.
        /// </summary>
        DieuApp = 3,
        /// <summary>
        /// 4.Cuốc online từ app khách hàng
        /// </summary>
        CuocAppKH = 4,
        /// <summary>
        /// 5.Cuốc vãng lai, lái xe đón khách vẫy
        /// </summary>
        CuocVangLai = 5
    }
    /// <summary>
    /// Loại xe(Chưa dùng)
    /// </summary>

    public enum Enum_G5_CarType
    {
        /// <summary>
        /// Bất kỳ
        /// </summary>
        None = 0,
        /// <summary>
        /// 1: Xe 4 chỗ nho
        /// </summary>
        Xe4Cho_Nho = 1,
        /// <summary>
        /// 2: Xe 4 chỗ rộng
        /// </summary>
        Xe4Cho_Rong = 2,
        /// <summary>
        /// 3: Xe 4 chỗ bất kỳ
        /// </summary>
        Xe4Cho = 3,
        /// <summary>
        /// 4 : Xe 7 chỗ
        /// </summary>
        Xe7Cho = 4,
        /// <summary>
        /// 5 : Xe 4 chỗ sân bay
        /// </summary>
        Xe4ChoSanBay = 5,
        /// <summary>
        /// 6 : Xe 7 chỗ sân bay
        /// </summary>
        Xe7ChoSanBay = 6,
        /// <summary>
        /// 7 : Xe 16 chỗ sân bay
        /// </summary>
        Xe16ChoSanBay = 7,
        /// <summary>
        /// 8 : Xe sân bay bất kỳ
        /// </summary>
        XeSB = 8,
        /// <summary>
        /// 18 : Xe 4 chỗ hợp đồng
        /// </summary>
        Xe4ChoHopDong = 18,
        /// <summary>
        /// 19 : Xe 7 chỗ hợp đồng
        /// </summary>
        Xe7ChoHopDong = 19,
    }
    /// <summary>
    /// Kiểm tra trạng thái Ping tới Trung Tâm Điều Hành và Máy chủ BA
    /// 0:Mặc định chưa thao tác gì.
    /// 1:Mất kết nối từ Server TTDH tới Server Center.
    /// 2:Không kết nối được Server TTDH(chưa bật Server TTDH)
    /// 3:Kết nối thành công
    /// </summary>
    public enum Enum_G5_Ping
    {
        /// <summary>
        /// Mặc định
        /// </summary>
        [EnumItem("Mặc định")]
        None = 0,
        /// <summary>
        /// Không Ping Được tới BA
        /// </summary>
        [EnumItem("Không Ping Được tới BA")]
        PingFail = 1,
        /// <summary>
        /// Không kết nối được tới TTDH
        /// </summary>
        [EnumItem("Không kết nối được tới TTDH")]
        PingNotConenct = 2,
        /// <summary>
        /// Kết nối thành công
        /// </summary>
        [EnumItem("Kết nối thành công")]
        PingSu = 3
    }
    
    /// <summary>
    /// Bước của lái xe
    /// </summary>
    public enum Enum_G5_Step
    {
        [EnumItem("Ko gửi lên server")]
        None=0,
        [EnumItem("Bắt đầu gửi")]
        Send = 1,
        [EnumItem("App Ko xe")]
        AckInitTrip=2,
        [EnumItem("Có xe")]
        ConfirmTrip = 3,
        [EnumItem("Xe đến điểm")]
        DriverGone = 4,
        [EnumItem("Gặp khách")]
        CatchedUser = 5,
        [EnumItem("Đón được")]
        DriverDone = 6,
        [EnumItem("Lái xe hủy")]
        DriverCancel = 7,
        [EnumItem("Có xe chuyển sang đàm")]
        ConfirmTripLast = 8,
        [EnumItem("Xe đến điểm chuyển sang đàm")]
        DriverGoneLast = 9,
        [EnumItem("Gặp khách chuyển sang đàm")]
        CatchedUserLast = 10,
        [EnumItem("Đón được chuyển sang đàm")]
        DriverDoneLast = 11,
        [EnumItem("Lái xe hủy chuyển sang đàm")]
        DriverCancelLast = 12,
        [EnumItem("Hết thời gian xử lý")]
        Timeout = 13,
        [EnumItem("Khách hủy cuốc online")]
        SourceCancel_Customer = 14,
        [EnumItem("Nhầm khách")]
        WrongCustomer = 41,
        [EnumItem("Khách đã đặt lại cuốc")]
        Customer_Rebook = 15,
        /// <summary>
        /// 16. Xe báo khách vẫy
        /// </summary>
        [EnumItem("Xe báo khách vẫy")]
        Driver_Guest = 16,
        /// <summary>
        /// 17. Xe nhận app từ đàm
        /// </summary>
        [EnumItem("Xe nhận app từ đàm")]
        Driver_Accept_Radio = 17
    }
    public enum Enum_G5_PMDH_DriverStatus
    {
        None=0,
        ChuyenDieuDam=1,
        KhongThayDoi=2

    }

    /// <summary>
    /// Enum Type trong bản CanhBao điêu app.
    /// </summary>
    public enum Enum_G5_PMDH_CanhBaoApp_Type
    {
        /// <summary>
        /// Cảnh báo thường
        /// </summary>
        None = 0,
        /// <summary>
        /// Hiển thị theo cảnh báo của lưới cuộc gọi
        /// </summary>
        CuocDieuApp = 1,
        /// <summary>
        /// Hiển thị dòng màu đỏ
        /// </summary>
        Row_Red = 2,
        /// <summary>
        /// Hiển thị dòng màu đỏ - có âm thanh
        /// </summary>
        Row_Red_Sound = 3
    }
    
    /// <summary>
    /// Enum trạng thái cảnh báo điều app
    /// </summary>
    public enum Enum_G5_PMDH_CanhBaoApp_Status
    {
        DangChoXuLy  = 0,
        DaGiaiQuyet = 1
    }

    /// <summary>
    /// Enum Send SMS
    /// </summary>
    public enum Enum_G5_PMDH_SMS_Status
    {
        ReceiveCarInfo = 0,
        ReceiveCatchedUser = 1,
        ReceiveDriverCancel = 2,
        ReceiveNoCar = 3
    }

    /// <summary>
    /// Enum loai dau so di dong
    /// </summary>
    public enum Enum_MobileNetWork_Type
    {
        CoDinh = 1,
        DiDong = 2
    }

    /// <summary>
    /// Loại cuốc trong bảng T_NhanVien dùng để phân biệt là xe hợp đồng hay xe taxi
    /// </summary>
    public enum Enum_SystemType
    {
        Taxi = 0,
        Car = 1
    }
}

