using System.Collections.Generic;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using System.Data;

namespace Taxi.Data.BanCo.Entity.CanhBaoXe
{
    public class CanhBaoXe
    {
        public List<Xe> Di=new List<Xe>();
        public List<Xe> Do = new List<Xe>();
        public List<Xe> Don = new List<Xe>();
        public List<Xe> Toi = new List<Xe>();
        public List<Xe> Bao = new List<Xe>();
        public List<Xe> Sai = new List<Xe>();
        public List<Xe> An = new List<Xe>();
        public List<Xe> Ra = new List<Xe>();
        public List<Xe> Kinh = new List<Xe>();
        public List<Xe> Chua = new List<Xe>();
        private GiamSatXe_LienLac data = new GiamSatXe_LienLac();
        public void LoadData()
        {
            An.Clear();
            Ra.Clear();
            Chua.Clear();
            Kinh.Clear();
            DataTable dt;
            dt = data.ExeStores("SP_BanCo_CanhBaoXe", 1);//Lấy ds xe nghỉ ăn ca quá giờ
            foreach (DataRow r in dt.Rows)
            {
                An.Add(new Xe() { SoHieu = r[0].ToString(), MauChu = "blue", MauNen = "Red" });
            }
            dt = data.ExeStores("SP_BanCo_CanhBaoXe", 2);// Lấy ds xe nghỉ rời xe quá giờ
            //foreach (DataRow r in dt.Rows)
            //{
            //    Ra.Add(new Xe() { SoHieu = r[0].ToString(), MauChu = "blue", MauNen = "Red" });
            //}
            //dt = data.ExeStores("SP_BanCo_CanhBaoXe", 3);// Lấy ds xe chưa có điểm đỗ
            foreach (DataRow r in dt.Rows)
            {
                Chua.Add(new Xe() { SoHieu = r[0].ToString(), MauChu = "blue", MauNen = "Red"});
            }
            dt = data.ExeStores("SP_BanCo_CanhBaoXe", 4);//  Lấy ds xe kinh doanh qua giờ
            foreach (DataRow r in dt.Rows)
            {
                Kinh.Add(new Xe() { SoHieu = r[0].ToString(), MauChu="Red", MauNen="blue" });
            }

            dt = data.ExeStores("SP_BanCo_CanhBaoXe", 5);//  Xe đỗ quá lâu so với cấu hình(2).
            foreach (DataRow r in dt.Rows)
            {
                Do.Add(new Xe() { SoHieu = r[0].ToString(), MauChu = "blue", MauNen = "Red" });
            }

            dt = data.ExeStores("SP_BanCo_CanhBaoXe", 6);//  Xe đỗ sai điểm.
            foreach (DataRow r in dt.Rows)
            {
                Sai.Add(new Xe() { SoHieu = r[0].ToString(), MauChu = "blue", MauNen = "Red" });
            }
           
        }
    }
}
