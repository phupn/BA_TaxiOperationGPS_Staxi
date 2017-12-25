using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Common.EnumUtility;
using Taxi.Common.Extender;
namespace Taxi.Controls.GMapResources
{
    public class GMapMarkerCustomEnum : GMap.NET.WindowsForms.Markers.GMapMarkerCustom
    {
        public GMapMarkerCustomEnum(GMap.NET.PointLatLng pos,EnumMarkerCustom enumMarker)
            : base(pos)
        {
            switch (enumMarker)
            {
                case EnumMarkerCustom.MarkerA:
                    Icon=Taxi.Controls.Properties.Resources.STaxi_MarkerA;
                    break;
                case EnumMarkerCustom.MarkerB:
                    Icon = Taxi.Controls.Properties.Resources.STaxi_MarkerB;
                    break;
                case EnumMarkerCustom.MarkerC: 
                    Icon = Taxi.Controls.Properties.Resources.STaxi_MarkerC;
                    break;
                case EnumMarkerCustom.MarkerD: 
                    Icon = Taxi.Controls.Properties.Resources.STaxi_MarkerD;
                    break;
                case EnumMarkerCustom.MarkerE:
                case EnumMarkerCustom.MarkerF:
                case EnumMarkerCustom.MarkerG:
                case EnumMarkerCustom.MarkerH:
                default:
                    Icon = Taxi.Controls.Properties.Resources.icon_dot_green;
                break;
            }
            Size = new System.Drawing.Size(Icon.Width, Icon.Height);          
        }
    }
}
