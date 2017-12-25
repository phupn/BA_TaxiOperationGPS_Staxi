using System.Drawing;
using System.Drawing.Drawing2D;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Taxi.Controls.Properties;

namespace Taxi.Controls.GMapResources
{
    public enum MarkerCustomType
    {
        None,
        A,
        B,
        C,
        Flag,
        Chartreuse,
        Pink,
        Custom,
        PMDH,
        GPS,
        D,
    }
    public class GMapMarkerCustomType : GMapMarker
    {
        public string Title { get; set; }//Dùng xe kẽ với tooltip
        private Bitmap _icon;

        public Bitmap Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public float? Bearing { get; set; }

        public MarkerCustomType Type { get; set; }
        public GMapMarkerCustomType(PointLatLng p,MarkerCustomType type) : base(p)
        {
            this.Size = new Size(23, 30);
           Type = type;
           switch (type)
           {
               case MarkerCustomType.A:
                   Icon = Properties.Resources.STaxi_MarkerA;
                   break;
               case MarkerCustomType.B: Icon = Properties.Resources.Staxi_MarkerB_Green; 
                   break;
               case MarkerCustomType.C: Icon = Properties.Resources.Staxi_MarkerC_Yellow;
                   break;
               case MarkerCustomType.D: Icon = Properties.Resources.Staxi_MarkerD_Red;
                   break;
               case MarkerCustomType.Custom: Icon = Properties.Resources.markerMG;
                   break;
               case MarkerCustomType.None: Icon = Properties.Resources.icong;
                   break;
               case MarkerCustomType.Flag: Icon = Properties.Resources.Marker18;
                   break;
               case MarkerCustomType.Chartreuse: Icon = ResizeImage(Properties.Resources.icon_Map_Chartreuse, this.Size);
                   break;
               case MarkerCustomType.Pink: Icon = ResizeImage(Properties.Resources.icon_Map_Pink, this.Size);
                   break;
               case MarkerCustomType.GPS:
                   Icon = Properties.Resources.red_marker_32;
                   break;
               case MarkerCustomType.PMDH:
                   Icon = Resources.marker_32;
                   break;
           }
        
       }

       public GMapMarkerCustomType(PointLatLng p,int number) : base(p)
       {
           var img = Resources.ResourceManager.GetObject(string.Format("icong{0}.png", number));
           if (img != null)
           {
               Icon = (Bitmap) img;
               this.Size = Icon.Size;
              
           }
       }
       public override void OnRender(Graphics g)
       {
           if (_icon != null)
           {
               if (Bearing.HasValue)
               {
                   var save = g.Save();
                   g.RotateTransform(this.Bearing.Value, MatrixOrder.Prepend);
                   g.DrawImageUnscaled(_icon, LocalPosition.X - (_icon.Size.Width / 2), LocalPosition.Y - (5 * _icon.Size.Height / 7));
                   g.ResetTransform();
                   g.Restore(save);
               }
               else
               {
                   g.DrawImageUnscaled(_icon, LocalPosition.X - (_icon.Size.Width / 2), LocalPosition.Y - (_icon.Size.Height / 2));
               }
           }
         
       }

        public void SetToolTip(string tl)
        {
            this.ToolTipText = tl;
        }
        public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            try
            {
                var b = new Bitmap(size.Width, size.Height);
                using (Graphics g = Graphics.FromImage((Image)b))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
                }
                return b;
            }
            catch { }
            return null;
        }
    }
}
