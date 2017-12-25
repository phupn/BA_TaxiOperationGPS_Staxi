using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Controls.Base.BaoCao;
using Taxi.Utils;
using Taxi.Utils.Enums.DieuXeChieuVe;

namespace Taxi.Data.FastTaxi
{
    /// <summary>
    /// Đặt xe chiều về
    /// </summary>
    [TableInfo(TableName="[T_TAXIRETURN_BOOKINGS]")]
    public class Booking : DbEntityBase<Booking>, IReportData
    {
        #region Field
        [Field(IsKey=true)]
        public long PK_BooID { get; set; }//bigint] IDENTITY(1,1) NOT NULL,
        [Field]
        public string Mobile { get; set; }//varchar](50) NULL,
        [Field]
        public string Password { get; set; }//nvarchar](250) NULL,
        [Field]
        public string ClientKey { get; set; }//nvarchar](100) NULL,
        [Field]
        public string FromName { get; set; }//nvarchar](300) NULL,
        [Field]
        public string FromAddress { get; set; }//nvarchar](300) NULL,
        [Field]
        public float FromLat { get; set; }//float] NULL,
        [Field]
        public float FromLng { get; set; }//float] NULL,
        [Field]
        public string ToName { get; set; }//nvarchar](300) NULL,
        [Field]
        public string ToAdress { get; set; }//nvarchar](300) NULL,
        [Field]
        public float ToLat { get; set; }//float] NULL,
        [Field]
        public float ToLng { get; set; }//float] NULL,
        [Field]
        public float GPSLat { get; set; }//float] NULL,
        [Field]
        public float GPSLng { get; set; }//float] NULL,
        [Field]
        public DateTime? FromTime { get; set; }//datetime] NULL,
        [Field]
        public DateTime? ToTime { get; set; }//datetime] NULL,
        [Field]
        public DateTime? DateCreated { get; set; }//datetime] NULL,
        [Field]
        public int Status { get; set; }//tinyint] NULL,

        public string Status_String
        {
            get
            {
                switch(Status)
                {
                    case 1: return "123";
                    case 2: return "234";
                    case 3: return "456";
                    case 4: return "5667";
                }
                return string.Empty;
            }
        }


        [Field]
        public bool IsCancel { get; set; }//bit] NULL,
        [Field]
        public bool IsSchedule { get; set; }//bit] NULL,
        [Field]
        public DateTime? CreatedDate { get; set; }//datetime] NULL,
        [Field]
        public string Description { get; set; }//nvarchar](500) NULL,
        /// <summary>
        /// ID của Trip
        /// </summary>
        [Field]
        public long FK_TaxiReturn { get; set; }//bigint] NULL,
        [Field]
        public int OpStatus { get; set; }//tinyint] NULL,
        public string OpStatus_String
        {
            get
            {
                switch (OpStatus)
                {
                    case (int)Enum_Bookings_OpStatus.ChapNhan: return "Chấp nhận";
                    case (int)Enum_Bookings_OpStatus.ChoXuLy: return "Chờ xử lý";
                    case (int)Enum_Bookings_OpStatus.DaDonKhach: return "Đã đón khách";
                    case (int)Enum_Bookings_OpStatus.Hoan: return "Hoãn";
                    case (int)Enum_Bookings_OpStatus.HuyDieu: return "Hủy điều";
                    case (int)Enum_Bookings_OpStatus.KetThuc: return "Kết thúc";
                    case (int)Enum_Bookings_OpStatus.KhachHangHuy: return "Khách hàng hủy";
                    case (int)Enum_Bookings_OpStatus.KhongXe: return "Không xe";
                    case (int)Enum_Bookings_OpStatus.KhongXuLy: return "Không xử lý";
                    case (int)Enum_Bookings_OpStatus.MobileKetThuc: return "Khách hàng kết thúc";
                    case (int)Enum_Bookings_OpStatus.TuChoi: return "Từ chối";
                    case (int)Enum_Bookings_OpStatus.Truot: return "Trượt";                    
                }
                return string.Empty; 
            }
        }
        [Field]
        public string OpDescription { get; set; }//nvarchar](500) NULL,
        [Field]
        public DateTime? OpAcceptedTime { get; set; }//datetime] NULL,
        [Field]
        public string OpAcceptedUser { get; set; }//nvarchar](50) NULL,
        [Field]
        public bool OpIsDelete { get; set; }//bit] NULL,
        [Field]
        public string OpVehicle { get; set; }
        [Field]
        public int TimeWaitAcceptTrip { get; set; }
        [Field]
        public int TimeWaitReceive { get; set; }
        [Field]
        public float BC_Route_Distance { get; set; }
        [Field]
        public string BC_Route { get; set; }
        [Field]
        public string OpCommand { get; set; }
        [Field]
        public DateTime? OpReceivedTime { get; set; }
        [Field]
        public string OpReceivedUser { get; set; }
        [Field]
        public DateTime? OpLastModifyTime { get; set; }
        [Field]
        public int? OpLine { get; set; }
        /// <summary>
        /// Xe đề cử
        /// </summary>
        [Field]
        public string SuggesCars { get; set; }

        //public string DiKhoang
        //{
        //    get { return string.Format("{0:HH:mm} - {1:HH:mm dd/MM}", this.FromTime, ToTime); }
        //}

        private KhoangThoiGian diKhoang = null;

        public KhoangThoiGian DiKhoang
        {
            get 
            { 
                if(diKhoang == null)
                {
                    diKhoang = new KhoangThoiGian { From = this.FromTime.Value, To = this.ToTime.Value };
                }

                return diKhoang; 
            }            
        }

        public string Mobile_ThoiGian { get; set; }

        public string TenGhepDiaChiDon
        {
            get { return string.Format("{0}-{1}", FromName, FromAddress); }
        }
        public string TenGhepDiaChiTra
        {
            get { return string.Format("{0}-{1}", ToName, ToAdress); }
        }
        /// <summary>
        /// Đếm số lần gửi SMS
        /// Chỉ cho gửi 2 lần
        /// </summary>
        [Field]
        public int OpSendSMS { get; set; }
        #endregion

        #region Hàm
        /// <summary>
        /// Lấy dữ liệu thay đổi </summary>
        /// <param name="line"></param>
        /// <param name="thoiDiemThayDoi"></param>
        /// <returns></returns>
        public List<Booking> GetByDateTime(string line, DateTime thoiDiemThayDoi)
        {
            return ExeStore("sp_TAXIRETURN_BOOKINGS_GetByDateTime", line, thoiDiemThayDoi).ToList<Booking>();
        }
        public List<Booking> Search(string line, string soDT, string diaChiDon, DateTime start, DateTime end)
        {
            return ExeStore("sp_TAXIRETURN_BOOKINGS_Search",line, soDT, diaChiDon, start, end).ToList<Booking>();
        }
        public List<Booking> SearchKetThuc(string line, string soDT, string diaChiDon, DateTime start, DateTime end)
        {
            return ExeStore("sp_TAXIRETURN_BOOKINGS_SearchKetThuc", line, soDT, diaChiDon, start, end).ToList<Booking>();
        }
        /// <summary>
        /// Cập nhật trạng thái
        /// </summary>
        public void DaDonDuocKhach()
        {
            ExeStoreNoneQuery("sp_Booking_DaDongDuocKhach", this.PK_BooID, this.FK_TaxiReturn,this.OpAcceptedUser);
        }
        /// <summary>
        /// Xóa cập nhật trạng thái
        /// </summary>
        public void DoDelete()
        {
            ExeStoreNoneQuery("sp_Booking_DoDelete", this.PK_BooID, this.FK_TaxiReturn, this.OpAcceptedUser);
        }

        public void HuyDieu()
        {
            ExeStoreNoneQuery("sp_Booking_HuyDieu", this.PK_BooID, this.FK_TaxiReturn, this.OpAcceptedUser);
            
        }

        public void DaDieuDuocXe(long bookId, long tripId, string acceptedUser, int companyID)
        {
            ExeStoreNoneQuery("sp_Booking_DaDieuDuocXe", bookId, tripId, acceptedUser, companyID);
        }
        /// <summary>
        /// Lấy danh sách xe đã bị xóa khỏi bảng dữ liệu.
        /// </summary>
        /// <param name="lsId"></param>
        /// <returns></returns>
        public List<long> GetDataDelete(string lsId)
        {
            var dt = ExeStore("sp_Booking_GetDataDelete", lsId);
            List<long> lsReturn = new List<long>();            
            if (dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++) lsReturn.Add(dt.Rows[i][0].To<long>());
            return lsReturn;
        }
        /// <summary>
        /// cập nhật trạng thái
        /// </summary>
        /// <param name="id">Id book</param>
        /// <param name="opStatus">Trạng thái</param>
        /// <param name="userId">Ai sửa</param>
        public void UpdateStatus(long id, Enum_Bookings_OpStatus opStatus, string userId)
        {
            ExeStoreNoneQuery("sp_Booking_UpdateStatus", id, (int)opStatus, userId);
        }
        /// <summary>
        /// cập nhật trạng thái và ghi chú điều.
        /// </summary>
        /// <param name="id">Id book</param>
        /// <param name="opStatus">Trạng thái</param>
        /// <param name="userId">Ai sửa</param>
        /// <param name="description">Ghi chú điều</param>
        public void UpdateStatusDescription(long id, Enum_Bookings_OpStatus opStatus, string userId, string description)
        {
            ExeStoreNoneQuery("sp_Booking_UpdateStatusDescription", id, (int)opStatus, userId, description, description);
        }
        /// <summary>
        /// Cập nhật trạng thái và lệnh command.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opStatus"></param>
        /// <param name="opCommand"></param>
        /// <param name="userId"></param>
        public void UpdateStatus(long id, Enum_Bookings_OpStatus opStatus,string opCommand, string userId)
        {
            ExeStoreNoneQuery("sp_Booking_UpdateStatusCommand", id, (int)opStatus, opCommand, userId);
        }
        public void OpReceived(long id,string userId)
        {
            ExeStoreNoneQuery("sp_Booking_OpReceived", id, userId);
        }

        /// <summary>
        /// Cập nhật số lần gửi SMS
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sendSMS"></param>
        public void UpdateStatus_OpSendSMS(long id, int sendSMS)
        {
            ExeStoreNoneQuery("SP_T_TAXIRETURN_BOOKINGS_UPDATE_SENDSMS", id, sendSMS);
        }
        #endregion

        #region Báo cáo
        public DateTime? FromDate{get;set;}

        public DateTime? ToDate{get;set;}

        public object GetData()
        {
           return ExeStore("sp_BaoCao_KhachCanXe_ChiTiet").ToList<Booking>().OrderByDescending(p=>p.ToTime).ToList();
           
        }
        public int? SoHieuXeInt
        {
            get
            {
                 try{
                     return OpVehicle.To<int>();
                 }
                 catch
                 {
                     return null;
                 }
            }
        }
        public int? SoHieuXeInt2
        {
            get
            {
                try
                {
                    return SoHieuXe.Trim().To<int>();
                }
                catch
                {
                    return null;
                }
            }
        }
        public DateTime? Ngay { get; set; }
        public string SoHieuXe { get; set; }
        public string TenLaiXe { get; set; }
        public string SoDienThoai { get; set; }
        public int LoaiXeID { get; set; }
        public int TongCuocDuongDai { get; set; }
        public int TongCuocKhongThanhCong { get; set; }
        public int TongCuocThanhCong { get; set; }
        public float KmCoKhach { get; set; }
        public float KmRong { get; set; }
        public decimal TongTien { get; set; }
        public List<Booking> GetBaoCaoTongHop(DateTime? deStart,DateTime? deEnd,string TenLaiXe,string SoXe)
        {
            return ExeStore("sp_BaoCao_KhachCanXe_TongHopV2", deStart, deEnd, TenLaiXe, SoXe).ToList<Booking>();
        }
        #endregion
    }

    public class KhoangThoiGian :  IComparable, IComparable<KhoangThoiGian>
    {
        public DateTime From { set; get; }
        public DateTime To { set; get; }

        public override string ToString()
        {
            return string.Format("{0:HH:mm} - {1:HH:mm dd/MM}", From, To);
        }

        public int CompareTo(KhoangThoiGian other)
        {
            if (this.From > other.From) return 1;
            if (this.From == other.From) return 0;
            return -1;
            //if (From > other.From) return 1;
            //else return 0;
        }

        public int CompareTo(object obj)
        {
            if (obj is KhoangThoiGian)
            {
                var other = (obj as KhoangThoiGian);
                if (this.From > other.From) return 1;
                if (this.From == other.From) return 0;
                return -1;
                //if (From > (obj as KhoangThoiGian).From) return 1;
                //else return 0;
            }
            else return 0;
        }



        public bool Equals(KhoangThoiGian other)
        {
            throw new NotImplementedException();
        }
    }
}
