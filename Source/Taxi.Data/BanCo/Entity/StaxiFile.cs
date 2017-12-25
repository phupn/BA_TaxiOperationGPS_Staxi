using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils.Enums;
namespace Taxi.Data.BanCo.Entity
{
    
    [TableInfo(TableName = "[Staxi.Files]")]
    public class StaxiFile : DbConnections.TaxiOperationDbEntityBase<StaxiFile>
    {
        [Field(IsKey=true,IsIdentity=true)]
        public int Id { get; set; }
        [ColumnField]
        [DisplayField]
        [Field]
        public string Name { get; set; }
        [ValueField]
        [Field]
        public string FileName { get; set; }
        /// <summary>
        /// 1.Ico
        /// 2.Audio
        /// 3.Document
        /// 4.Video
        /// 5.img
        /// </summary>
        [Field]
        public StaxiFileType FileType { get; set; }
        /// <summary>
        /// Gets the type of the list by file.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  26/08/2015   created
        /// </Modified>
        public List<StaxiFile> GetListByFileType(StaxiFileType fileType)
        {
            return ExeStore("sp_Staxi_File_GetListByFileType", fileType).ToList<StaxiFile>();
        }
    }
}
