
namespace GMap.NET.WindowsForms.Markers
{
   using System.Drawing;

   public class GMapMarkerPolygonLabel : GMapMarkerCustom
   {
       public GMapMarkerPolygonLabel(PointLatLng p)
           : base(p)
      {
          //Icon = Taxi.Controls.Properties.Resources.transparentsquare;
          ////this.Size = new Size(8, 8);
          //p1 = p;
      }

       public override void OnRender(Graphics g)
       {
           StringFormat fomat = new StringFormat();
           fomat.Alignment = StringAlignment.Center;
           Font Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
           Brush Fill = new System.Drawing.SolidBrush(Color.Red);
           g.DrawString(ToolTipText, Font, Fill, LocalPosition.X-8, LocalPosition.Y-8);
       }
   }
}
