using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Drawing_Interface
{
    public class Trajectory
    {
        private List<PointF> points;
        private List<Byte> pointTypes;
        private int width, height;
        private PointF lastRecievedPoint = new PointF(-1, -1);
        private byte lastRecievedPointType = 0;

        public Trajectory(Size size)
        {
            points = new List<PointF>();
            pointTypes = new List<Byte>();
            width = size.Width;
            height = size.Height;
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public PointF[] Points
        {
            get
            {
                return points.ToArray();
            }
            set
            {
                points = value.ToList();
            }
        }

        public Byte[] PointTypes
        {
            get
            {
                return pointTypes.ToArray();
            }
            set
            {
                pointTypes = value.ToList();
            }
        }

        public int Count
        {
            get
            {
                return points.Count;
            }
        }

        public void Reset()
        {
            lastRecievedPoint = new PointF(-1, -1);
            points.Clear();
            pointTypes.Clear();
        }
        
        public void AddPoint(PointF p2, byte t)
        {
            PointF p1 = lastRecievedPoint;

            if(!IsPointOutside(p2) && t == 0)
            {
                points.Add(p2);
                pointTypes.Add(t);
                lastRecievedPoint = p2;
                lastRecievedPointType = t;
            }
            else if (!IsPointOutside(p1) && !IsPointOutside(p2))
            {
                points.Add(p2);
                pointTypes.Add(t);
                lastRecievedPoint = p2;
                lastRecievedPointType = t;
            }
            else if(!IsPointOutside(p1) && IsPointOutside(p2) && t != 0)
            {
                points.Add(BorderPoint(p1, p2, false));
                pointTypes.Add(2);
                lastRecievedPoint = p2;
                lastRecievedPointType = 2;
            }
            else if (IsPointOutside(p1) && !IsPointOutside(p2))
            {
                points.Add(BorderPoint(p1, p2, true));
                pointTypes.Add(0);
                points.Add(p2);
                pointTypes.Add(t);
                lastRecievedPoint = p2;
                lastRecievedPointType = t;
            }
            else
            {
                lastRecievedPoint = p2;
                lastRecievedPointType = t;
            }
        }

        private bool IsPointOutside(PointF p)
        {
            if (p.X < 0 || p.X > width || p.Y < 0 || p.Y > height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private PointF BorderPoint(PointF p1, PointF p2, bool goingIn)
        {
            PointF p3 = new PointF();
            float k, m, w, h, dx, dy;

            w = width;
            h = height;
            dx = p2.X - p1.X;
            dy = p2.Y - p1.Y;

            if (dx == 0 && dy > 0)
            {
                p3.X = p1.X;
                if (goingIn)
                {
                    p3.Y = 0;
                }
                else
                {
                    p3.Y = h;
                }
            }
            else if (dx == 0 && dy < 0)
            {
                p3.X = p1.X;
                if (goingIn)
                {
                    p3.Y = h;
                }
                else
                {
                    p3.Y = 0;
                }
            }
            else if (dy == 0 && dx > 0)
            {
                if (goingIn)
                {
                    p3.X = 0;
                }
                else
                {
                    p3.X = w;
                }
                p3.Y = p1.Y;
            }
            else if (dy == 0 && dx < 0)
            {
                if (goingIn)
                {
                    p3.X = w;
                }
                else
                {
                    p3.X = 0;
                }
                p3.Y = p1.Y;
            }
            else
            {
                k = (dy) / (dx);
                m = -k * p1.X + p1.Y;

                PointF p_u = new PointF((h - m) / k, h);

                PointF p_d = new PointF(-m / k, 0);

                PointF p_l = new PointF(0, k + m);

                PointF p_r = new PointF(w, k * w + m);

                if ((p_u.X > 0 && p_u.X < w) && (dy > 0 && !goingIn || dy < 0 && goingIn))
                {
                    p3 = p_u;
                }
                else if ((p_r.Y > 0 && p_r.Y < h) && (dx > 0 && !goingIn || dx < 0 && goingIn))
                {
                    p3 = p_r;
                }
                else if ((p_d.X > 0 && p_d.X < w) && (dy < 0 && !goingIn || dy > 0 && goingIn))
                {
                    p3 = p_d;
                }
                else if ((p_l.Y > 0 && p_l.Y < h) && (dx < 0 && !goingIn || dx > 0 && goingIn))
                {
                    p3 = p_l;
                }
            }
            
            return p3;
        }

        public void AddRectangle(PointF a, PointF b)
        {
            float x1, x2, y1, y2;

            x1 = a.X;
            y1 = a.Y;
            x2 = b.X;
            y2 = b.Y;

            AddPoint(new PointF((x1 > x2 ? x2 : x1), (y1 > y2 ? y2 : y1)), 0);
            AddPoint(new PointF((x1 > x2 ? x1 : x2), (y1 > y2 ? y2 : y1)), 1);
            AddPoint(new PointF((x1 > x2 ? x1 : x2), (y1 > y2 ? y1 : y2)), 1);
            AddPoint(new PointF((x1 > x2 ? x2 : x1), (y1 > y2 ? y1 : y2)), 1);
            AddPoint(new PointF((x1 > x2 ? x2 : x1), (y1 > y2 ? y2 : y1)), 2);
        }

        public void AddLine(PointF a, PointF b)
        {
            AddPoint(a, 0);
            AddPoint(b, 2);
        }

        public void AddCircle(PointF a, float radius)
        {
            AddPoint(new PointF((float)(radius * Math.Sin(0) + a.X), (float)(radius * Math.Cos(0) + a.Y)), 0);
            for (double i = 0; i < 2 * Math.PI; i+= 0.1)
            {
                AddPoint(new PointF((float)(radius * Math.Sin(i) + a.X), (float)(radius * Math.Cos(i)) + a.Y), 1);
            }
            AddPoint(new PointF((float)(radius * Math.Sin(2 * Math.PI) + a.X), (float)(radius * Math.Cos(2 * Math.PI) + a.Y)), 2);
        }

        public void AddString(String str, Font f, PointF p, int rotation)
        {
            GraphicsPath gPath = new GraphicsPath();
            Matrix rotationMatrix = new Matrix();
            Matrix translationMatrix = new Matrix();
            int frst = 0;

            gPath.AddString(str, f.FontFamily, (int)f.Style, f.Size, new PointF(0, 0), StringFormat.GenericDefault);
            rotationMatrix.Rotate(rotation);
            gPath.Transform(rotationMatrix);
            translationMatrix.Translate(p.X, p.Y);
            gPath.Transform(translationMatrix);

            for (int i = 0; i < gPath.PointCount; i++)
            {
                if (gPath.PathTypes[i] == 0)
                {
                    AddPoint(gPath.PathPoints[i], 0);
                    frst = i;
                }
                else if (gPath.PathTypes[i] == 1 || gPath.PathTypes[i] == 3)
                {
                    AddPoint(gPath.PathPoints[i], 1);
                }
                else if (gPath.PathTypes[i] > 3)
                {
                    AddPoint(gPath.PathPoints[i], 1);
                    AddPoint(gPath.PathPoints[frst], 2);
                }
            }
        }
    }
}