namespace GMap.NET.WindowsForms.Markers
{
    using System.Drawing;
    public class GMapMarkerVehice2 : GMapMarkerCustom
    {
        public GMapMarkerVehice2(PointLatLng p, int trangThai)
            : base(p)
        {
            if (trangThai == 1)
                Icon = Taxi.Controls.Properties.Resources.Xe;
            else if (trangThai == 0)
                Icon = Taxi.Controls.Properties.Resources.XeTM;
            else if (trangThai == 2)
                Icon = Taxi.Controls.Properties.Resources.XeCK;
            else
                Icon = Taxi.Controls.Properties.Resources.XeCK_2;
            //Offset = new Point(-10, -34);
        }
    }
}