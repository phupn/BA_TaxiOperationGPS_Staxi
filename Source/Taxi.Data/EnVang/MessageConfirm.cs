using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Data.EnVang
{
    /// <summary>
    /// Thông báo cho điều hành
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// LuanBH  9/8/2015   created
    /// </Modified>
    public class MessageConfirm
    {

        /// <summary>
        /// ID cuộc gọi
        /// </summary>
        public long IDCuocGoi { get; set; }
        /// <summary>
        /// Cần confirm hay không
        /// </summary>
        public bool CanConfirm { get; set; }
        /// <summary>
        /// Địa chỉ đón khách
        /// </summary>
        public string DiaChiDonKhach { get; set; }
        /// <summary>
        /// Xe Đón
        /// </summary>
        public string XeDon { get; set; }

        /// <summary>
        /// Mã Message
        /// </summary>
        public short MaMessage { get; set; }

        /// <summary>
        /// Nội dung mã
        /// </summary>
        public string MessageContent { get; set; }

        /// <summary>
        /// Số hiệu xe
        /// </summary>
        public string SoHieuXe { get; set; }

        /// <summary>
        /// Thời điểm gửi message
        /// </summary>
        public DateTime ThoiDiemGoiMessage { get; set; }

        /// <summary>
        /// Thời gian timeout cho mỗi message
        /// </summary>
        /// <value>
        /// The time out.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/8/2015   created
        /// </Modified>
        public short Timeout { get; set; }

        /// <summary>
        /// Thời điểm đóng popup
        /// </summary>
        public DateTime? ClosingTime { get; set; }

        /// <summary>
        /// Biển số xe
        /// </summary>
        public string BienSoXe { get; set; }
    }
}
