using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Common.EnumUtility;

namespace Taxi.Utils.Enums
{
    /// <summary>
    /// Enum Tập lệnh xử lý ở bộ phận nào.
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// Administrator   24/08/2015   created
    /// </Modified>
    public enum Enum_CommandPart
    {
        [EnumItem("Tổng đài")]
        TongDai = 1,
        [EnumItem("Điện thoại")]
        DienThoai = 2,
    }

    #region Cột nhập dữ liệu
    /// <summary>
    /// Cột nhập dữ liệu
    /// </summary>
    public enum Enum_Column : int
    {
        [EnumItem("Xe nhận")]
        XeNhan = 1,
        [EnumItem("Xe Đón")]
        XeDon = 2,
        [EnumItem("Xe nhận")]
        XeDenDiem = 3,
        [EnumItem("Ghi chú TDV")]
        GhiChuTongDai = 4,
        [EnumItem("Ghi chú DTV")]
        GhiChuDienThoai = 5,
    }
    #endregion

    #region Enum phim tắt
    /// <summary>
    /// Enum phim tắt
    /// </summary>
    public enum PhimTat
    {

        [EnumItem("None")]
        None = 0,
        //TongDai : Search Xe Nhận
        [EnumItem("0")]
        D0 = 48,
        [EnumItem("1")]
        D1 = 49,
        [EnumItem("2")]
        D2 = 50,
        [EnumItem("3")]
        D3 = 51,
        [EnumItem("4")]
        D4 = 52,
        [EnumItem("5")]
        D5 = 53,
        [EnumItem("6")]
        D6 = 54,
        [EnumItem("7")]
        D7 = 55,
        [EnumItem("8")]
        D8 = 56,
        [EnumItem("9")]
        D9 = 57,
        [EnumItem("A")]
        A = 65,
        //Mở bản đồ
        [EnumItem("B")]
        B = 66,
        //Chuyển thành gọi taxi
        [EnumItem("C")]
        C = 67,
        [EnumItem("D")]
        D = 68,
        [EnumItem("E")]
        E = 69,
        [EnumItem("F")]
        F = 70,
        [EnumItem("G")]
        G = 71,
        [EnumItem("H")]
        H = 72,
        [EnumItem("I")]
        I = 73,
        [EnumItem("J")]
        J = 74,
        // chuyển kênh
        [EnumItem("K")]
        K = 75,
        //Update cuộc gọi lại
        [EnumItem("L")]
        L = 76,
        [EnumItem("M")]
        M = 77,
        [EnumItem("N")]
        N = 78,
        [EnumItem("O")]
        O = 79,
        [EnumItem("P")]
        P = 80,
        [EnumItem("Q")]
        Q = 81,
        [EnumItem("R")]
        R = 82,
        //Gửi tin nhắn
        [EnumItem("S")]
        S = 83,
        [EnumItem("T")]
        T = 84,
        [EnumItem("U")]
        U = 85,
        [EnumItem("V")]
        V = 86,
        [EnumItem("W")]
        W = 87,
        //Tổng đài : Thoát cuốc
        [EnumItem("X")]
        X = 88,
        [EnumItem("Y")]
        Y = 89,
        [EnumItem("Z")]
        Z = 90,
        //Nhập xe đến điểm
        [EnumItem("[-]")]
        Multiply = 106,
        //Nhập xe dừng điểm
        [EnumItem("[+]")]
        Add = 107,
        [EnumItem("[,]")]
        Separator = 108,
        //Nhập xe đón
        [EnumItem("[*]")]
        Subtract = 109,
        //Nhập địa chỉ trả
        [EnumItem("[.]")]
        Decimal = 110,
        //Nhập xe nhận
        [EnumItem("[/]")]
        Divide = 111,
        [EnumItem("F1")]
        F1 = 112,
        [EnumItem("F1")]
        F2 = 113,
        [EnumItem("F3")]
        F3 = 114,
        //Nhập tuyến đường dài
        [EnumItem("F4")]
        F4 = 115,
        [EnumItem("F5")]
        F5 = 116,
        //Cảnh báo
        [EnumItem("F6")]
        F6 = 117,
        [EnumItem("F7")]
        F7 = 118,
        [EnumItem("F8")]
        F8 = 119,
        [EnumItem("F9")]
        F9 = 120,
        //TongDai: Tra cứu thẻ
        [EnumItem("F10")]
        F10 = 121,
        //TongDai : San bay đường dài
        [EnumItem("F11")]
        F11 = 122,
        [EnumItem("F12")]
        F12 = 123,
        //Xóa lệnh
        [EnumItem("Backspace")]
        Backspace = 8,
        //Xóa cuốc
        [EnumItem("Delete")]
        Delete = 46,
        //Gọi nhanh
        [EnumItem("Space")]
        Space = 32
    }
    #endregion

    #region Các lệnh gửi lên lái xe.

    //Login	            Đăng nhập
    //InitTrip	        Tạo cuốc mới
    //OperatorCancel	Điều hành hủy cuốc
    //ACKGetPhone	    Phản hồi yêu cầu lấy số điện thoại khách hàng
    //ACKInvite	        Phản hồi việc mời khách từ điều hành
    //LogoutDriver	    Ép việc logout đến lái xe
    //OperatorCatched	Điều hành báo kết thúc cuốc
    //MissCar	        Điều hành báo khách không thấy xe
    //SendText	        Điều hành gửi msg tới lái xe
    //ConfirmDone	    Trả lời lái xe có Done thành công chưa

    /// <summary>
    /// Các lệnh gửi lên lái xe.
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// Administrator  24/08/2015   created
    ///   </Modified>
    public enum Enum_SendDriver
    {
        /// <summary>
        /// Không gửi
        /// </summary>
        [EnumItem("Không gửi")]
        None = 0,
        /// <summary>
        /// Gửi thông báo
        /// </summary>
        [EnumItem("Gửi thông báo")]
        SendText = 1,
        /// <summary>
        /// Đã mời
        /// </summary>
        [EnumItem("Đã mời khách")]
        SendACKInvite = 2,
        /// <summary>
        /// Gặp xe
        /// </summary>
        [EnumItem("Gặp xe")]
        SendCatchUserSyn = 3,
        /// <summary>
        /// Xin số đt
        /// </summary>
        [EnumItem("Xin số đt")]
        ACKGetPhone=3,
        /// <summary>
        /// Đã xin lỗi ko xe
        /// </summary>
        [EnumItem("Đã xin lỗi ko xe")]
        SendOperatorDispatched_NoCar = 4,
        /// <summary>
        /// Hủy hoãn
        /// </summary>
        [EnumItem("Hủy hoãn")]
        SendOperatorCancel = 5,
        /// <summary>
        /// Hoàn thành
        /// </summary>
        [EnumItem("Hoàn thành")]
        SendConfirmDoneBook = 6
    }
    #endregion
}
