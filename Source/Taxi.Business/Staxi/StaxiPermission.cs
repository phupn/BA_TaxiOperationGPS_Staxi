using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Business.Staxi
{
    /*SELECT 02,N'Staxi',N'' UNION ALL
SELECT 0201,N'Xe đi đường dài',N'' UNION ALL
SELECT 020101,N'Báo xe đi đường dài',N'' UNION ALL
SELECT 020102,N'Duyệt xe đi đường dài',N'' UNION ALL
SELECT 020103,N'Xóa xe đi đường dài',N'' UNION ALL
SELECT 020104,N'Ghép xe chiều về',N'' UNION ALL
SELECT 0202,N'Staxi- Báo cáo',N'' UNION ALL
SELECT 020201,N'Staxi- Báo cáo chi tiết xe đi đường dài',N'' UNION ALL
SELECT 020202,N'Staxi- Báo cáo chi tiết cuốc đi chiều về',N''*/
    /// <summary>
    /// Quản lý quyền của Staxi.
    /// </summary>
    public class StaxiPermission
    {
        /// <summary>
        /// Quyền Staxi
        /// </summary>
        public const string Staxi="02";
        /// <summary>
        /// Xe đi đường dài
        /// </summary>
        public const string XeDiDuongDai = "0201";
        /// <summary>
        /// Quyền báo xe đi đường dài.
        /// </summary>
        public const string BaoXeDiDuongDai = "020101";
        /// <summary>
        /// Quyền duyệt xe đi đường dài.
        /// </summary>
        public const string DuyetXeDiDuongDai = "020102";
        /// <summary>
        /// Quyền xóa xe đi đường dài.
        /// </summary>
        public const string XoaXeDiDuongDai = "020103";
        /// <summary>
        /// Quyền ghép xe chiều về.
        /// </summary>
        public const string GhepXeChieuVe = "020104";
        /// <summary>
        /// Báo cáo
        /// </summary>
        public const string BaoCao = "0202";
        /// <summary>
        /// Báo cáo chi tiết xe đi đường dài.
        /// </summary>
        public const string BaoCaoChiTietXeDiDuongDai = "020201";
        /// <summary>
        /// Báo cáo chi tiết cuốc đi chiều về.
        /// </summary>
        public const string BaoCaoChiTietCuocDiChieuVe = "020202";
    }
}
