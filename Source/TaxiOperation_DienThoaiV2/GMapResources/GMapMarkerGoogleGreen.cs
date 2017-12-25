
namespace GMap.NET.WindowsForms.Markers
{
   using System.Drawing;
    using System.IO; 

#if !PocketPC
   using System.Windows.Forms;
    using TaxiApplication.Properties;
    using System.Resources;
    using System.Globalization;
#else
   using GMap.NET.WindowsMobile.Properties;
#endif

   public class GMapMarkerGoogleGreen : GMapMarker
   {
      public float? Bearing;
      public string SoHieu; 
      public Bitmap urlIcon;
      public int SoCho;
      public int trangthai;
      public string MauSoXe;
      
      int[] MDir = new int[] { 3, 2, 1, 8, 7, 6, 5, 4 };
      private CultureInfo resourceCulture;

      public GMapMarkerGoogleGreen(PointLatLng p )//them tham so trang thai
         : base(p)
      {
         Size = new System.Drawing.Size(Resources.littleCar.Width ,Resources.littleCar.Height);
         Offset = new Point(-10, -34);
        // BienSo = bienSo;
      }
       

       private string GetFileName(int Noseat, int dir,int  status) {
           string strFileName = "";

          int TT;
           if (Noseat == 4)
           {
               if ((status & 8) == 0)
               {
                   if ((status & 3) == 0) TT = 0;
                   else TT = 1;
               }
               else
               {
                   if ((status & 3) != 0) TT = 3;
                   else TT = 2;
               }

           }
           else
           {
               if ((status & 8) == 0)
               {
                   if ((status & 3) == 0) TT = 0;
                   else TT = 1;
               }
               else
               {
                   if ((status & 3) != 0) TT = 3;
                   else TT = 2;
               }
           }
           string urlicon = "Xe";
           urlicon += MDir[dir] + Noseat.ToString() + TT + ".png";
           
           return urlicon; 

       }
       public GMapMarkerGoogleGreen(PointLatLng p, string bienSo,int sochongoi, int Huong , int Trangthai,
           string SoHieuXe, string color, int hienthi) : base (p)//them tham so trang thai
       {
           string fullPath = "";
           fullPath = Path.GetFullPath("xeonline") + "\\" + GetFileName(sochongoi, Huong, Trangthai);
           
           //fullPath = GetFileName(sochongoi, Huong, Trangthai);
           this.urlIcon = null;
           if ( File.Exists(fullPath))
           {
              
               if(sochongoi == 4 &&((hienthi & 1) == 1))
               {
                   fullPath = Path.GetFullPath("xeonline") + "\\XeCBDungDoLau_4.png";
                    this.urlIcon = new Bitmap(fullPath);
               }
               else if (sochongoi > 4 && ((hienthi & 1) == 1))
               {
                   fullPath = Path.GetFullPath("xeonline") + "\\XeCBDungDoLau_7.png";
                   this.urlIcon = new Bitmap(fullPath);
               }
               else
               {
                   this.urlIcon = new Bitmap(fullPath);
               }
              
           }else{
               //fullPath = Path.GetFullPath("xeonline") + "\\Xe370.png" ;
               this.urlIcon = null;
           }

           //GMapMarkerGoogleGreen.urlIcon = ((System.Drawing.Bitmap)(obj));

           //urlIcon = new Bitmap(fullPath);

           Size = new System.Drawing.Size(this.urlIcon.Width,this.urlIcon.Height);
           Offset = new Point(-12,-16);
           SoCho = sochongoi;
           SoHieu = SoHieuXe ;
           trangthai = Trangthai;
           MauSoXe = color;
          
       }

      static readonly Point[] Arrow = new Point[] { new Point(-7, 7), new Point(0, -22), new Point(7, 7), new Point(0, 2) };

      public override void OnRender(Graphics g)
      {
#if !PocketPC
         if(!Bearing.HasValue)
         {
             Font Font = new Font(FontFamily.GenericMonospace ,12, FontStyle.Bold , GraphicsUnit.Pixel);
             Brush Foreground = new SolidBrush(Color.Black);//mau chu cua bien so
            
              //  g.DrawImageUnscaled(Resources.littleCar, LocalPosition.X, LocalPosition.Y);
             // thay doi kich thuoc xe 4 cho va 7 cho
             if (SoCho == 4 )
             {
                 g.DrawImage(this.urlIcon, LocalPosition.X, LocalPosition.Y, 25, 25);
             }
             else if(SoCho == 7)
             {
                 g.DrawImage(this.urlIcon, LocalPosition.X, LocalPosition.Y,35, 35);
             }
           
             //tinh do rong cho anh nen bien so
             int SoKiTu = SoHieu.Length;
             int DoRong = SoKiTu * 8;
             // ve anh nen cho bien so
             // co 4 trang thai voi 4 anh Trang.png ,Xam.png ,Do.png ,Vang.png
            if(MauSoXe == "pink")
            {
                g.DrawImage(Resources.Pink, LocalPosition.X + 10, LocalPosition.Y - 20, DoRong, 15);
            }
            else if(MauSoXe  == "yellow")
            {
                g.DrawImage(Resources.Yellow, LocalPosition.X + 10, LocalPosition.Y - 20, DoRong, 15);
            }
            else if(MauSoXe  == "red")
            {
                g.DrawImage(Resources.Red, LocalPosition.X + 10, LocalPosition.Y - 20, DoRong, 15);
            }
             else if(MauSoXe  == "white")
            {
                g.DrawImage(Resources.White, LocalPosition.X + 10, LocalPosition.Y - 20, DoRong, 15);
            }
            else if (MauSoXe == "grey")
            {
                g.DrawImage(Resources.Grey, LocalPosition.X + 10, LocalPosition.Y - 20, DoRong, 15);
            }
             // ve bien so 
             g.DrawString(SoHieu , Font, Foreground, LocalPosition.X+9, LocalPosition.Y-20);
         }
         g.TranslateTransform(ToolTipPosition.X, ToolTipPosition.Y);

         //if(Bearing.HasValue)
         //{
         //   g.RotateTransform(Bearing.Value - Overlay.Control.Bearing);
         //   g.FillPolygon(Brushes.Lime, Arrow);
         //}

         g.ResetTransform();
                  
#else
            DrawImageUnscaled(g, Resources.shadow50, LocalPosition.X, LocalPosition.Y);
            DrawImageUnscaled(g, Resources.marker, LocalPosition.X, LocalPosition.Y);
#endif
      }
   }
}
