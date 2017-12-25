using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Data;

namespace Taxi.Business
{
    public class TinhTien_SuDungXe
    {
        #region properties
        public int ID { get; set; }
        public int LoaiXe { get; set; }
        public int Km_Tu { get; set; }
        public int Km_Den { get; set; }
        public int Vtb { get; set; }
        public float TG { get; set; }
        #endregion

        public TinhTien_SuDungXe()
       {
       }

        public TinhTien_SuDungXe(int _ID, int _LoaiXe, int _Km_Tu, int _Km_Den, int _Vtb, float _TG)
        {
            ID = _ID;
            LoaiXe = _LoaiXe;
            Km_Tu = _Km_Tu;
            Km_Den = _Km_Den;
            Vtb = _Vtb;
            TG = _TG;
        }

        public List<TinhTien_SuDungXe> GetTinhTien_SuDungXe(int LoaiXe)
        {
            List<TinhTien_SuDungXe> lstTinhTien_SuDungXe = new List<TinhTien_SuDungXe>();

            DataTable dt = new DataTable();
            dt = new Taxi.Data.TinhTien_SuDung().GetTinhTien_SuDung(LoaiXe);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataRow item in dt.Rows)
                {
                    lstTinhTien_SuDungXe.Add(new TinhTien_SuDungXe(
                    int.Parse(item["ID"].ToString()),
                    int.Parse(item["LoaiXe"].ToString()),
                    int.Parse(item["Km_Tu"].ToString()),
                    int.Parse(item["Km_Den"].ToString()),
                    int.Parse(item["Vtb"].ToString()),
                    float.Parse(item["TG"].ToString())
                    ));
                }
                
            }
            return lstTinhTien_SuDungXe;
        }

        /// <summary>
        /// Lưu thông tin sử dụng xe
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                if (this.ID > 0)
                    return new TinhTien_SuDung().Update(this.ID, this.LoaiXe, this.Km_Tu, this.Km_Den, this.Vtb, this.TG);
                else
                    return new TinhTien_SuDung().Insert(this.LoaiXe, this.Km_Tu, this.Km_Den, this.Vtb, this.TG);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TinhTien_SuDungXe.Save", ex);
                return false;
            }
           
        }
    }
}
