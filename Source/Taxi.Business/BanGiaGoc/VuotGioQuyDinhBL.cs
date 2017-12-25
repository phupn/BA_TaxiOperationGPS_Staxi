using System;
using System.Data;

namespace Taxi.Business
{
 public  class VuotGioQuyDinhBL
    {
        private int  _LoaiXeID;
        public int  LoaiXeID
        {
            get { return _LoaiXeID; }
            set
            {
                _LoaiXeID = value;
            }
        }
        private double _GiaTienVuot1Gio;
        public double GiaTienVuot1Gio
        {
            get { return _GiaTienVuot1Gio; }
            set
            {
                _GiaTienVuot1Gio = value;
            }
        }
        private double  _GiaTienVuot1Km;
        public double  GiaTienVuot1Km
        {
            get { return _GiaTienVuot1Km; }
            set
            {
                _GiaTienVuot1Km = value;
            }
        }

     public VuotGioQuyDinhBL Selectone( int LoaixeID)
     {
         Data.BanGiaGoc.VuotGioQuydinhDA VuotGioQuydinhControl = new Data.BanGiaGoc.VuotGioQuydinhDA();
         DataTable dt = VuotGioQuydinhControl.selectone(LoaixeID);
         VuotGioQuyDinhBL VuotGioQuydinhobj = new VuotGioQuyDinhBL();
         if (dt != null)
         {
             if (dt.Rows.Count > 0)
             {
                 VuotGioQuydinhobj.GiaTienVuot1Km = Convert.ToDouble(dt.Rows[0]["GiaTienVuot1Km"]);
                 VuotGioQuydinhobj.GiaTienVuot1Gio = Convert.ToDouble(dt.Rows[0]["GiaTienVuot1Gio"]);
                 VuotGioQuydinhobj.LoaiXeID = Convert.ToInt32(dt.Rows[0]["LoaiXeID"]);

                 return VuotGioQuydinhobj;
             }
             else
             {
                 return null;
             }
         }
         else
         {
             return null;
         }

     }
     
    }
}
