using OneTaxi.Utils.Enums;
using Staxi.Utils.Attributes;

namespace OneTaxi.Utils
{
    public enum IServerFunction
    {
        [FieldInfo(Name = "Không gửi đi")]
        None = 0,
        [FieldInfo(Name = "Khách hàng hủy")]
        OperatorCancel = 1,
        [FieldInfo(Name = "Hoàn thành cuốc")]
        ConfirmDone = 2,
        [FieldInfo(Name = "Gửi lệnh")]
        SendText = 3,
        [FieldInfo(Name = "Nhầm cuốc")]
        WrongCustomer = 4,
        [FieldInfo(Name = "Mời khách")]
        ACKInvite = 5
    }
    public enum CommandBool : int
    {
        [FieldInfo(Name = "Mặc định")]
        None = 0,
        [FieldInfo(Name = "Có")]
        True = 1,
        [FieldInfo(Name = "Không")]
        False = 2
    }
    public enum G5CommandType : int
    {
        [FieldInfo(Name = "Mặc định")]
        None = 0,
        [FieldInfo(Name = "Nhập xe nhận")]
        NhapXeNhan = 1,
        [FieldInfo(Name = "Nhập xe điến điểm")]
        NhapXeDienDiem = 2,
        [FieldInfo(Name = "Nhập xe dùng điểm")]
        NhapXeDungDiem = 3,
        [FieldInfo(Name = "Nhập xe đón")]
        NhapXeDon = 5,
        [FieldInfo(Name = "Chuyển vùng")]
        ChuyenVung = 7,
        [FieldInfo(Name = "Nhập mở rộng")]
        NhapMoRong = 6
    }
    public interface ICommand
    {
        EnumKeys Shortcuts { get; set; }
        string Command { get; set; }
        string ParentCommand { get; set; }
        CommandBool IsRequited { get; set; }
    }
}
