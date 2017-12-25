
namespace GMap.NET.WindowsForms.Markers
{
    using System.Drawing;

    public class GMapMarkerCustomer : GMapMarkerCustom
    {

        public GMapMarkerCustomer(PointLatLng p)
            : base(p)
        {
            Icon = Taxi.Controls.Properties.Resources.marker2;
            this.Size = new Size(8, 8);
        }
        public GMapMarkerCustomer(PointLatLng p, Bitmap icon)
            : base(p)
        {
            Icon = icon;
            this.Size = new Size(8, 8);
        }
    }

    public class GMapMarkerMG : GMapMarkerCustom
    {

        public GMapMarkerMG(PointLatLng p)
            : base(p)
        {
            Icon = Taxi.Controls.Properties.Resources.markerMG;
            this.Size = new Size(8, 8);
        }
    }
}
