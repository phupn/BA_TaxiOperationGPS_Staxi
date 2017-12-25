using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.ManHinhDieuXe
{
    /// <summary>
    /// lớp thực hiện các công việc liên quan tới màn hình điều xe
    /// Input
    ///    - Services WCF - gửi tới xe
    /// 
    /// Output
    ///                   - lấy các thông tin của xe gửi về 
    /// Ref
    ///    - WCF servies thao tác lệnh với màn hình.
    /// </summary>
    /// Coongnt 
    public class DieuXe
    {
        /// <summary>
        /// Hàm thực hiện gửi lệnh tới màn hình của xe
        /// </summary>
        /// <param name="cmd">Command khởi tạo thông tin cần gửi </param>
        /// <param name="serviceManHinh"></param>
        /// <returns></returns>
        public static bool GuiThongTinToiXe(ControlCommand cmd, Object serviceManHinh)
        {

            return true;
        }
    }
}
