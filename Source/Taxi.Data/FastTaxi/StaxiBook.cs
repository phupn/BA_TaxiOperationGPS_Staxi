using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using Taxi.Common.EnumUtility;
namespace Taxi.Data.FastTaxi
{
    /// <summary>
    /// Trang thai
    /// </summary>
    public enum StaxiBook_Status
    {
        /// <summary>
        /// Thêm
        /// </summary>
        [EnumItem("Có xe nhận")]
        Insert = 0,
        /// <summary>
        /// Xe đến điểm
        /// </summary>
        [EnumItem("Xe đến điểm")]
        DriverGone = 1,
        /// <summary>
        /// Bắt khách
        /// </summary>
        [EnumItem("Đón được khách")]
        CatchedUser = 2,
        /// <summary>
        /// Xe đón được khách
        /// </summary>
        [EnumItem("Hoàn thành cuốc")]
        DriverDone = 3,
        /// <summary>
        /// Lái xe hủy
        /// </summary>
        [EnumItem("Lái xe hủy")]
        DriverCancel = 4,
        /// <summary>
        /// Khách hàng hủy
        /// </summary>
        [EnumItem("Khách hàng hủy")]
        SourceCancel = 5,
        /// <summary>
        /// Không thấy server trả lời gì
        /// </summary>
        [EnumItem("Hết hạn xử lý")]
        Timeout = 6
    }
    /// <summary>
    /// Cuốc khách từ app KH trả về.
    /// </summary>
    [TableInfo(TableName = "[T_Staxi_Book]")]
    public class StaxiBook : DbEntityBase<StaxiBook>
    {
        #region Const
        public const string Sp_T_Staxi_Book_Insert = "Sp_T_Staxi_Book_Insert";
        public const string Sp_T_Staxi_Book_CatchedUser = "Sp_T_Staxi_Book_CatchedUser";
        public const string Sp_T_Staxi_Book_DriverCancel = "Sp_T_Staxi_Book_DriverCancel";
        public const string Sp_T_Staxi_Book_DriverDone = "Sp_T_Staxi_Book_DriverDone";
        public const string Sp_T_Staxi_Book_DriverGone = "Sp_T_Staxi_Book_DriverGone";
        public const string Sp_T_Staxi_Book_SourceCancel = "Sp_T_Staxi_Book_SourceCancel";
        public const string Sp_T_Staxi_Book_Timeout = "Sp_T_Staxi_Book_Timeout";
        public const string Sp_StaxiBook_GetAllByLine = "Sp_StaxiBook_GetAllByLine";
        public const string Sp_StaxiBook_LayDuLieuThayDoiByLine = "Sp_StaxiBook_LayDuLieuThayDoiByLine";
        public const string Sp_StaxiBook_LayIDKetThuc = "Sp_StaxiBook_LayIDKetThuc";
        public const string Sp_StaxiBook_LayBangTinKetThuc = "Sp_StaxiBook_LayBangTinKetThuc";
        public const string Sp_StaxiBook_GetByBookID = "Sp_StaxiBook_GetByBookID";
        #endregion

        #region Field

        [Field(IsKey = true, IsIdentity = true)]
        public long Id { get; set; }
        [Field]
        public Guid BookId { get; set; }
        [Field]
        public string Line { get; set; }
        [Field]
        public string Vung { get; set; }
        [Field]
        public string PhoneNumber { get; set; }
        [Field]
        public DateTime CreateDate { get; set; }
        [Field]
        public DateTime CatchedTime { get; set; }
        [Field]
        public int CountCar { get; set; }
        [Field]
        public int CarType { get; set; }
        [Field]
        public string CarTypeName { get; set; }
        [Field]
        public string SaleOffCode { get; set; }
        [Field]
        public string FromAddress { get; set; }
        [Field]
        public float From_Lng { get; set; }
        [Field]
        public float From_Lat { get; set; }
        [Field]
        public string ToAddress { get; set; }
        [Field]
        public float To_Lng { get; set; }
        [Field]
        public float To_Lat { get; set; }
        [Field]
        public string CustomNote { get; set; }
        [Field]
        public int Status { get; set; }
        [Field]
        public string XeTuChoi { get; set; }
        [Field]
        public string XeNhan { get; set; }
        [Field]
        public string XeDungDiem { get; set; }
        [Field]
        public string XeDenDiem { get; set; }
        [Field]
        public string XeDon { get; set; }
        [Field]
        public string ServerCommand { get; set; }
        [Field]
        public string DriverCommand { get; set; }
        [Field]
        public int CancelType { get; set; }
        public DateTime UpdateTime { get; set; }
        #endregion

        #region Function
        public static List<StaxiBook> GetAll(string line)
        {
            return Inst.ExeStore(Sp_StaxiBook_GetAllByLine, line).ToList<StaxiBook>();
        }

        /// <summary>
        /// Get book by bookid
        /// </summary>
        public static StaxiBook GetByBookID(Guid bookId)
        {
            List<StaxiBook> lstBook = Inst.ExeStore(Sp_StaxiBook_GetByBookID, bookId).ToList<StaxiBook>();
            if (lstBook != null && lstBook.Count > 0)
            {
                return lstBook[0];
            }
            return null;
        }

        public static List<StaxiBook> LayDuLieuThayDoi(string line, DateTime date)
        {
            return Inst.ExeStore(Sp_StaxiBook_LayDuLieuThayDoiByLine, line, date).ToList<StaxiBook>();
        }
        public static List<long> LayIDKetThuc(string Ids)
        {
            return Inst.ExeStore(Sp_StaxiBook_LayIDKetThuc, Ids).Select().Select(p => p[0].To<long>()).ToList();
        }
        public static List<StaxiBook> LayBangTinKetThuc(int StartIndex = 1, int EndIndex = 50)
        {
            return Inst.ExeStore(Sp_StaxiBook_LayBangTinKetThuc, StartIndex, EndIndex).ToList<StaxiBook>();
        }

        #region == Server ==
        /// <summary>
        /// Tạo cuốc mới
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="Vung"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="CatchedTime"></param>
        /// <param name="CountCar"></param>
        /// <param name="CarType"></param>
        /// <param name="SaleOffCode"></param>
        /// <param name="FromAddress"></param>
        /// <param name="From_Lng"></param>
        /// <param name="From_Lat"></param>
        /// <param name="ToAddress"></param>
        /// <param name="To_Lng"></param>
        /// <param name="To_Lat"></param>
        /// <param name="CustomNote"></param>
        /// <param name="Status"></param>
        /// <param name="VehiclesDeny"></param>
        /// <param name="Vehicles"></param>
        /// <param name="VehicleSuccessful"></param>
        /// <param name="ServerCommand"></param>
        /// <returns></returns>
        public static bool InsertBook(Guid BookId, int Vung, string PhoneNumber, DateTime CatchedTime, int CountCar, int CarType, string SaleOffCode, string FromAddress, float From_Lng, float From_Lat
            , string ToAddress, float To_Lng, float To_Lat, string CustomNote, string XeTuChoi, string XeNhan)
        {
            return StaxiBook.Inst.ExeStoreNoneQuery(Sp_T_Staxi_Book_Insert, BookId, (int)StaxiBook_Status.Insert, Vung, PhoneNumber, CatchedTime, CountCar, CarType, SaleOffCode, FromAddress, From_Lng, From_Lat, ToAddress, To_Lng, To_Lat, CustomNote, XeTuChoi, XeNhan) > 0;
        }
        /// <summary>
        /// Bắt khách
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="Command"></param>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        public static bool CatchedUser(Guid BookId, string Command, string xeNhan)
        {
            return StaxiBook.Inst.ExeStoreNoneQuery(Sp_T_Staxi_Book_CatchedUser, BookId, (int)StaxiBook_Status.CatchedUser, Command, xeNhan) > 0;
        }
        /// <summary>
        /// Lái xe hủy
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="msg"></param>
        /// <param name="CancelType"></param>
        /// <param name="XeHuy"></param>
        /// <returns></returns>
        public static bool DriverCancel(Guid BookId, string msg, int CancelType, string XeHuy)
        {
            return StaxiBook.Inst.ExeStoreNoneQuery(Sp_T_Staxi_Book_DriverCancel, BookId, (int)StaxiBook_Status.DriverCancel, msg, CancelType, XeHuy) > 0;
        }
        /// <summary>
        /// Lái xe đón thành công
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="Command"></param>
        /// <param name="XeDon"></param>
        /// <returns></returns>
        public static bool DriverDone(Guid BookId, string Command, string XeDon)
        {
            return StaxiBook.Inst.ExeStoreNoneQuery(Sp_T_Staxi_Book_DriverDone, BookId, (int)StaxiBook_Status.DriverDone, Command, XeDon) > 0;
        }
        /// <summary>
        /// Lái xe gặp khách
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="Command"></param>
        /// <param name="XeDenDiem"></param>
        /// <returns></returns>
        public static bool DriverGone(Guid BookId, string Command, string XeDenDiem)
        {
            return StaxiBook.Inst.ExeStoreNoneQuery(Sp_T_Staxi_Book_DriverGone, BookId, (int)StaxiBook_Status.DriverGone, Command, XeDenDiem) > 0;
        }
        public static bool SourceCancel(Guid BookId)
        {
            return StaxiBook.Inst.ExeStoreNoneQuery(Sp_T_Staxi_Book_SourceCancel, BookId, (int)StaxiBook_Status.SourceCancel) > 0;
        }
        public static int Timeout()
        {
            return StaxiBook.Inst.ExeStoreNoneQuery(Sp_T_Staxi_Book_Timeout, (int)StaxiBook_Status.Timeout);
        }
        #endregion
        #endregion
    }
}
