using System.Runtime.Serialization;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;

namespace Taxi.Controls.GMapResources
{
   public  class GMapMarkerB : GMapMarkerCustom
    {
        public GMapMarkerB(PointLatLng pos) : base(pos)
        {
            Icon = Taxi.Controls.Properties.Resources.Staxi_96_ic_marker_end;
        }
    }
}
