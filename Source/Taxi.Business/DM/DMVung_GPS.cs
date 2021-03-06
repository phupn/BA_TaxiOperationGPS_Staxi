using System;
using System.Collections.Generic;
using Taxi.Entity;

namespace Taxi.Business.DM
{
   public  class DMVung_GPS
    {
        /// <summary>
        /// Lay tat ca vung kenh gps
        /// </summary>
        /// <returns></returns>
        public List<DMVung_GPSEntity> GetAllDSVungKenh()
        {
            return new Taxi.Data.DM.DMVung_GPS().GetAllDSVungKenh();
        }

        /// <summary>
        /// Lay Vung kenh theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DMVung_GPSEntity GetVungKenh(int ID)
        {
            return new Taxi.Data.DM.DMVung_GPS().GetVungKenh(ID);
        }

        /// <summary>
        /// Lay kenh gop theo vung
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetKenhGop_ByVung(string vung)
        {
            return new Taxi.Data.DM.DMVung_GPS().GetKenhGop_ByVung(vung);
        }

        /// <summary>
        /// Xoa Kenh VungGPS
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            return new Taxi.Data.DM.DMVung_GPS().Delete(ID);
        }

        /// <summary>
        /// Cap nhat kenh vung
        /// </summary>
        /// <param name="DMVung_GPS"></param>
        /// <returns></returns>
        public bool Update(DMVung_GPSEntity DMVung_GPS)
        {
            return new Taxi.Data.DM.DMVung_GPS().Update(DMVung_GPS);
        }

        /// <summary>
        /// Cap nhat kenh vung
        /// </summary>
        /// <param name="DMVung_GPS"></param>
        /// <returns></returns>
        public bool Insert(DMVung_GPSEntity DMVung_GPS)
        {
            return new Taxi.Data.DM.DMVung_GPS().Insert(DMVung_GPS);
        }
    }
}
