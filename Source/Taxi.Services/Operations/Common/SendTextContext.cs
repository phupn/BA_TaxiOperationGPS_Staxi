using System;

namespace Taxi.Services.Operations
{
    public class SendTextContext
    {
        /// <summary>
        /// Mã lệnh
        /// </summary>
        public int CmdId { get; set; }
        /// <summary>
        /// BookId
        /// </summary>
        public Guid BookId { get; set; }
        /// <summary>
        /// Biển số gửi lên
        /// </summary>
        public string VehiclePlate;
        /// <summary>
        /// Nội dung gửi lên.
        /// </summary>
        public string TextCommand;
        /// <summary>
        /// Kết quả nhận được hay không
        /// </summary>
        public bool Result;
    }


    public enum EnumConfirmDoneBook : byte
    {
        Done = 0,
        DriverCancel = 1,
        CustomerCancel = 2,
        MissTrip = 3,
    }
}
