using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GMap.NET.WindowsForms.Markers
{
    public class CustomPolygon : GMapPolygon
    {
        public CustomPolygon(List<PointLatLng> points, string name)
            : base(points, name)
        {
            
        }
        public override void OnRender(System.Drawing.Graphics g)
        {
            //Point[] pnts = new Point[LocalPoints.Count];
            //for (int i = 0; i < LocalPoints.Count; i++)
            //{
            //    Point p2 = new Point((int)LocalPoints[i].X, (int)LocalPoints[i].Y);
            //    pnts[pnts.Length - 1 - i] = p2;
            //}

            //if (pnts.Length > 0)
            //{
            //    g.FillPolygon(Fill, pnts);
            //    g.DrawPolygon(Stroke, pnts);
            //}
                
                using (GraphicsPath rp = new GraphicsPath())
                {
                    for (int i = 0; i < LocalPoints.Count; i++)
                    {
                        GPoint p2 = LocalPoints[i];

                        if (i == 0)
                        {
                            rp.AddLine(p2.X, p2.Y, p2.X, p2.Y);
                        }
                        else
                        {
                            System.Drawing.PointF p = rp.GetLastPoint();
                            rp.AddLine(p.X, p.Y, p2.X, p2.Y);
                        }

                    }
                    if (rp.PointCount > 0)
                    {
                        rp.FillMode = FillMode.Winding;
                        Pen custom = new Pen(Color.FromArgb(155, Color.Red));
                        custom.Width = 5;
                        //rp.CloseFigure();
                        g.FillPath(new SolidBrush(Color.FromArgb(155, Color.Pink)), rp);
                        g.DrawPath(custom, rp);
                        
                        custom.Dispose();
                    }
                }
        }
    }
}
