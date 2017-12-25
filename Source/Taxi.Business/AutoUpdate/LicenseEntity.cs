using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Business
{
    [TableInfo(TableName = "TcLK")]
    public class LicenseEntity:DbEntityBase<LicenseEntity>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Field]
        public string LicenseKey { get; set; }

        [Field]
        public string LicenseCode { get; set; }
        [Field]
        public string APICode { get; set; }

        [Field]
        public DateTime CreatedDate { get; set; }

        [Field]
        public DateTime UpdatedDate { get; set; }

        [Field]
        public bool IsActive { get; set; }
        public string GetServerInformation(out string  pCpuID)
        {
            pCpuID = string.Empty;
            try
            {
                var temp = this.ExeStoreWithOutput("sp_GetMacAddress", -1, "","");                
                if (temp.Value["pResult"].To<int>() == 1)
                {
                    pCpuID = temp.Value["pCPU"].ToString().Replace("  \r","");
                    return temp.Value["pMacAddress"].ToString();
                }
                else return string.Empty;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetMACAdrress: ", ex);                
                return string.Empty;
            }
        }
        /// <summary>
        /// Lưu thông tin license vào DB
        /// </summary>
        public int AuthoriseLicenseKey(params object[] parInput)//5 tham số!
        {
            try
            {
                var temp = this.ExeStoreWithOutput("sp_AuthoriseLicenseKey", parInput);
                return temp.Value["pResult"].To<int>();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("AuthoriseLicenseKey: " ,ex);
                return -1;//Lỗi kết nối cơ sở dữ liệu!
            }
        }

    }
}
