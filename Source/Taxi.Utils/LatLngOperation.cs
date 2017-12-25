using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Utils
{
    /// <summary>
    /// Tọa độ
    /// </summary>
    public class LatLngOperation
    {
        public LatLngOperation() { }
        public LatLngOperation(float lat, float lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }
        public LatLngOperation(double lat, double lng)
        {
            this.Lat = (float)lat;
            this.Lng = (float)lng;
        }
        /// <summary>
        /// Vĩ độ
        /// </summary>
        public float Lat { get; set; }
        /// <summary>
        /// Kinh độ
        /// </summary>
        public float Lng { get; set; }
    }
}
