using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Linq;
namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[SYS_VersionInfo]")]
    public class SYS_VersionInfo : DbEntityBase<SYS_VersionInfo>
    {
        [Field(IsKey=true,IsIdentity=true)]
        public int Id { get; set; }
        /// <summary>
        /// Địa chỉ ip của máy tính
        /// </summary>
        [Field]
        public string IPAddress { get; set; }
        /// <summary>
        /// Module nào.
        /// Điện thoại.
        /// Tổng đài.
        /// Điều hành chính.
        /// </summary>
        [Field]
        public string IsPC { get; set; }
        /// <summary>
        /// Phiên bản hiện tại
        /// </summary>
        [Field]
        public string Version { get; set; }
        /// <summary>
        /// Thời gian cập nhật
        /// </summary>
        [Field]
        public DateTime? DateUpdate { get; set; }
        /// <summary>
        /// Trạng thái.
        /// Đang cập nhật.
        /// Đang dùng.
        /// Đang kiểm tra.
        /// Đang bắt buộc cập nhật.
        /// </summary>
        [Field]
        public string Status { get; set; }
        /// <summary>
        /// Kiểm tra phiên bản.
        /// </summary>
        [Field]
        public bool IsCheck { get; set; }
        /// <summary>
        /// Bắt buộc cập nhật
        /// </summary>
        [Field]
        public bool IsRequired { get; set; }
        /// <summary>
        /// Thời gian thay đổi mới nhất.
        /// </summary>
        [Field]
        public DateTime? LastUpdate { get; set; }
        /// <summary>
        /// Ai đang dùng máy này.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Lấy thông tin thay đổi mới nhất.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<SYS_VersionInfo> GetLastUpdate(DateTime date)
        {
            return Inst.ExeStore("sp_SYS_VersionInfo_GetLastUpdate", date).ToList<SYS_VersionInfo>();
        }
        /// <summary>
        /// Lấy Thông tin
        /// </summary>
        /// <returns></returns>
        public static List<SYS_VersionInfo> GetList()
        {
            return Inst.ExeStore("sp_SYS_VersionInfo_GetList").ToList<SYS_VersionInfo>();
        }
        /// <summary>
        /// Lấy thông tin
        /// </summary>
        /// <param name="IpAddress"></param>
        /// <param name="Module"></param>
        /// <param name="LastDate"></param>
        /// <returns></returns>
        public static SYS_VersionInfo GetVersionIPAddress(string IpAddress, string Module,DateTime? LastDate)
        {
            var entity=new SYS_VersionInfo();
            try
            {
                var dt = Inst.ExeStore("sp_SYS_VersionInfo_GetVersionIPAddress", IpAddress, Module, LastDate);
                if (dt.Rows.Count == 1)
                {
                    entity = dt.ToList<SYS_VersionInfo>().First();
                }
            }catch(Exception ex){}
           
            return entity;
        }
    }
}
