using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;

namespace Taxi.Controls.GMapResources
{
    public class GMapMarkerA : GMapMarkerCustom
    {
        public GMapMarkerA(PointLatLng pos) : base(pos)
        {
            Icon = Taxi.Controls.Properties.Resources.Staxi_96_ic_marker_start;
            Size = new Size(Icon.Width, Icon.Height);
        }
    }
}
