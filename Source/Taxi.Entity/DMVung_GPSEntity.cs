

namespace Taxi.Entity
{
    public class DMVung_GPSEntity
    {
        #region Properties

        private int _Id;
        /// <summary>
        /// ID Vung GPS
        /// </summary>
        public int ID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        
        private string _TenVungGPS;
        /// <summary>
        /// Ten Vung GPS
        /// </summary>
        public string TenVungGPS
        {
            get
            {
                return _TenVungGPS;
            }
            set
            {
                _TenVungGPS = value;
            }
        }

        private int _KenhVung;
        /// <summary>
        /// Kenh Vung
        /// </summary>
        public int KenhVung
        {
            get
            {
                return _KenhVung;
            }
            set
            {
                _KenhVung = value;
            }
        }

        private int _KenhGop;
        /// <summary>
        /// Kenh gop
        /// </summary>
        public int KenhGop
        {
            get { return _KenhGop;  }
            set { _KenhGop = value; }
        }

        private string _ToaDoVung;

        /// <summary>
        /// Toa do vung
        /// </summary>
        public string ToaDoVung
        {
            get
            {
                return _ToaDoVung;
            }
            set
            {
                _ToaDoVung = value;
            }
        }

        private int _BanKinhTimXe;
        /// <summary>
        /// ID Vung GPS
        /// </summary>
        public int BanKinhTimXe
        {
            get
            {
                return _BanKinhTimXe;
            }
            set
            {
                _BanKinhTimXe = value;
            }
        }

        public DMVung_GPSEntity(int _Id, string _TenVungGPS, int _VungKenh, int _KenhGop, string _ToaDoVung, int _BanKinhTimXe)
        {
            ID = _Id;
            TenVungGPS = _TenVungGPS;
            KenhVung = _VungKenh;
            KenhGop = _KenhGop;
            ToaDoVung = _ToaDoVung;
            BanKinhTimXe = _BanKinhTimXe;
        }
        public DMVung_GPSEntity()
        {
             
        }
         
#endregion Properties
    }
}