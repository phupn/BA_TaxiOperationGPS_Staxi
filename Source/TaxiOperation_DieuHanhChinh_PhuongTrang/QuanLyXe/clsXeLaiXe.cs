using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.GUI
{
    public class clsXeLaiXe
    {
        private string _SoHieuXe;

        public string SoHieuXe
        {
            get { return _SoHieuXe; }
            set { _SoHieuXe = value; }
        }
        private string _TenLaiXe;

        public string TenLaiXe
        {
            get { return _TenLaiXe; }
            set { _TenLaiXe = value; }
        }
        private string _SoThe;

        public string SoThe
        {
            get { return _SoThe; }
            set { _SoThe = value; }
        }
        private DateTime _GioRa;

        public DateTime GioRa
        {
            get { return _GioRa; }
            set { _GioRa = value; }
        }

        public clsXeLaiXe() { }
        public clsXeLaiXe(string sohieuxe, string tenlaixe, DateTime giora, string sothe)
        {
            this.SoHieuXe = sohieuxe;
            this.TenLaiXe = tenlaixe;
            this.GioRa = giora;
            this.SoThe = sothe;

        }
    }
}
