using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Common.EnumUtility;
using Taxi.Utils.Enums;

namespace Taxi.Utils
{
    public enum IServerFunction
    {
        [EnumItem("Không gửi đi")]
        None=0,
        [EnumItem("Khách hàng hủy")]
        OperatorCancel=1,
        [EnumItem("Hoàn thành cuốc")]
        ConfirmDone=2,
        [EnumItem("Gửi lệnh")]
        SendText=3,
        [EnumItem("Nhầm cuốc")]
        WrongCustomer = 4,
        [EnumItem("Mời khách")]
        ACKInvite = 5
    }
    public enum CommandBool:int
    {
        [EnumItem("Mặc định")]
        None = 0,
        [EnumItem("Có")]
        True = 1,
        [EnumItem("Không")]
        False = 2
    }
    public enum G5CommandType : int
    {
        [EnumItem("Mặc định")]
        None = 0,
        [EnumItem("Nhập xe nhận")]
        NhapXeNhan = 1,
        [EnumItem("Nhập xe điến điểm")]
        NhapXeDienDiem = 2,
        [EnumItem("Nhập xe dùng điểm")]
        NhapXeDungDiem = 3,
        [EnumItem("Nhập xe đón")]
        NhapXeDon = 5,
        [EnumItem("Chuyển vùng")]
        ChuyenVung = 7,
        [EnumItem("Nhập mở rộng")]
        NhapMoRong = 6
    }
    public interface ICommand
    {
        int Id { get; set; }
        PhimTat Shortcuts { get; set; }
        string Command { get; set; }
        string ParentCommand { get; set; }
        CommandBool IsRequited { get; set; }
    }
    
    
}
