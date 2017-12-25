using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    public class GiamSatXe_Shift
    {
        private List<GiamSatXe_Shift> ShiftList { get; set; }
        public string ShiftName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public void loadShift(DataRow r) {

            ShiftList = new List<GiamSatXe_Shift>();
            GiamSatXe_Shift all = new GiamSatXe_Shift() { ShiftName = "Tất cả" };
        //Ca 1;
            GiamSatXe_Shift ca1= new GiamSatXe_Shift(){ ShiftName="1", Start=DateTime.Parse(r[1].ToString()),End=DateTime.Parse(r[2].ToString())};
         //Ca 2;
            GiamSatXe_Shift ca2 = new GiamSatXe_Shift() { ShiftName = "2", Start = DateTime.Parse(r[2].ToString()), End = DateTime.Parse(r[3].ToString()) };
        // Ca 3;
            GiamSatXe_Shift ca3 = new GiamSatXe_Shift() { ShiftName = "3", Start = DateTime.Parse(r[3].ToString()), End = DateTime.Parse(r[1].ToString()) };
            ShiftList.Add(all);
            ShiftList.Add(ca1);
            ShiftList.Add(ca2);
            ShiftList.Add(ca3);
        }
        public GiamSatXe_Shift GetShift(string ShiftName)
        {
            var item = (from r in ShiftList
                                              where r.ShiftName.Contains(ShiftName.Trim()) 
                                              select r).FirstOrDefault();
            return item;
        }
        public bool checkTime(string ShiftName, DateTime Time)
        {
            var item = from r in ShiftList
                       where r.ShiftName.Contains(ShiftName.Trim()) && (r.Start <= Time) && (r.End >= Time)
                       select r;
            if (item.Count() == 1)
                return true;
            else
                return false;
        }
        public string GetCaNow()
        {
            var item = (from r in ShiftList
                        where r.Start.TimeOfDay<=DateTime.Now.TimeOfDay && r.End.TimeOfDay>DateTime.Now.TimeOfDay
                        select r).FirstOrDefault();
            return item.ShiftName;
        }
    }

}
