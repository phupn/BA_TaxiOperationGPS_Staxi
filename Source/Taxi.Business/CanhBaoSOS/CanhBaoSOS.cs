using System;
using System.Collections.Generic;
using System.Data;
using Taxi.Data.CanhBaoSOS;

namespace Taxi.Business.CanhBaoSOS
{
    public class CanhBaoSOS
    {
        public int Id { get; set; }
        public string SoXe { get; set; }
        public float KinhDo { get; set; }
        public float ViDo { get; set; }
        public string DiaChi { get; set; }
        public DateTime ThoiDiem { get; set; }
        public bool TrangThai { get; set; }
        public string MaNV { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Get danh sách SOS
        /// </summary>
        public List<CanhBaoSOS> GetList(string lineActive)
        {
            List<CanhBaoSOS> lstCanhBaoSOS = new List<CanhBaoSOS>();
            DataTable dt = new CanhBaoSOS_DA().GetList(lineActive);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["SoXe"] == DBNull.Value || (string) item["SoXe"] == "")
                        continue;

                    CanhBaoSOS objCanhBao = new CanhBaoSOS
                    {
                        DiaChi = item["DiaChi"] == DBNull.Value ? "Không xác định" : item["DiaChi"].ToString(),
                        Id = item["Id"] == DBNull.Value ? 0 : int.Parse(item["Id"].ToString()),
                        KinhDo = item["KinhDo"] == DBNull.Value ? 0 : float.Parse(item["KinhDo"].ToString()),
                        MaNV = item["MaNV"] == DBNull.Value ? "" : item["MaNV"].ToString(),
                        SoXe = item["SoXe"].ToString(),
                        ThoiDiem = item["ThoiDiem"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(item["ThoiDiem"].ToString()),
                        ViDo = item["ViDo"] == DBNull.Value ? 0 : float.Parse(item["ViDo"].ToString()),
                        TrangThai = item["TrangThai"] != DBNull.Value && bool.Parse(item["TrangThai"].ToString()),
                        PhoneNumber = item["PhoneNumber"] == DBNull.Value ? "" : item["PhoneNumber"].ToString()
                    };
                    
                    lstCanhBaoSOS.Add(objCanhBao);
                }
            }
            return lstCanhBaoSOS;
        }

        /// <summary>
        /// đánh dấu đã đọc
        /// </summary>
        public int CheckAll(string ListID)
        {
            return new CanhBaoSOS_DA().CheckAll(ListID);
        }
    }
}
