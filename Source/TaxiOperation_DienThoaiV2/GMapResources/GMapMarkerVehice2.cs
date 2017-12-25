
namespace GMap.NET.WindowsForms.Markers2
{
   using System.Drawing;
    using TaxiApplication.Properties;

   public class GMapMarkerVehice2 : GMapMarker
   {
      public float? Bearing;
       private int g_TrangThai = 0;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="p"></param>
       /// <param name="trangThai">1 : xe bật máy - 
       /// 0 : xe tắt máy -
       /// 3 : xe tắt máy, bật điều hòa</param>
       public GMapMarkerVehice2(PointLatLng p,int trangThai) : base(p)
      {
          if (trangThai == 1)
              Size = new System.Drawing.Size(Resources.Xe.Width, Resources.Xe.Height);
          else if (trangThai == 0)
              Size = new System.Drawing.Size(Resources.XeTM.Width, Resources.XeTM.Height);
          else if (trangThai == 2)
              Size = new System.Drawing.Size(Resources.XeTM_DH.Width, Resources.XeTM_DH.Height);
        g_TrangThai = trangThai;
         Offset = new Point(-10, -34);
      }

      static readonly Point[] Arrow = new Point[] { new Point(-7, 7), new Point(0, -22), new Point(7, 7), new Point(0, 2) };

      public override void OnRender(Graphics g)
      {
         if(!Bearing.HasValue)
         {
             if (g_TrangThai == 1)
                 g.DrawImageUnscaled(Resources.Xe, LocalPosition.X, LocalPosition.Y);
             else if (g_TrangThai == 0)
                 g.DrawImageUnscaled(Resources.XeTM, LocalPosition.X, LocalPosition.Y);
             else if (g_TrangThai == 2)
                 g.DrawImageUnscaled(Resources.XeTM_DH, LocalPosition.X, LocalPosition.Y);
         }
         g.TranslateTransform(ToolTipPosition.X, ToolTipPosition.Y);
         g.ResetTransform();
      }
   }
}
