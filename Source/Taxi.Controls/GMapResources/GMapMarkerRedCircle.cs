
namespace GMap.NET.WindowsForms.Markers
{
   using System.Drawing;

    public class GMapMarkerRedCircle : GMapMarkerCustom
   {

       public GMapMarkerRedCircle(PointLatLng p) : base(p)
      {
          Icon = Taxi.Controls.Properties.Resources.legendIcon;
          this.Size = new Size(8, 8);
      }
   }
    public class GMapMarkerBlueCircle : GMapMarkerCustom
    {

        public GMapMarkerBlueCircle(PointLatLng p)
            : base(p)
        {
            Icon = Taxi.Controls.Properties.Resources.icon_dot_green;
        }
    }
}
