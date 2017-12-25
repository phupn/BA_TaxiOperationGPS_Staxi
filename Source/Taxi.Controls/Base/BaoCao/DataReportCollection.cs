using System.Collections.Generic;
namespace Taxi.Controls.BaoCao
{
    /// <summary>
    /// Lưu trữ dữ liệu cho báo cáo
    /// </summary>
    public class DataReportCollection
    {
        private List<object> data = new List<object>();
        /// <summary>
        /// Dữ liệu cho báo cáo
        /// </summary>
        public List<object> Data
        {
            get { return data; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datasources"></param>
        public void Add(params object[] datasources)
        {
            foreach (var item in datasources)
                data.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datasources"></param>
        public DataReportCollection(params object[] datasources)
        {
            Add(datasources);
        }
    }
}
