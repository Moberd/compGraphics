using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public enum PointType
    {
        MAIN,
        LEFT,
        RIGHT
    }

    
    public partial class FormBezier : Form
    {
        List<BezPoint> points = new List<BezPoint>();
        Pen blackPen = new Pen(Color.LightGray, 3);
        Graphics g;
        Bitmap myBitmap;

        public FormBezier()
        {
            InitializeComponent();
            myBitmap = new Bitmap(635, 417);
            //g = canvas.CreateGraphics();
            g = Graphics.FromImage(myBitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        bool shouldRedraw = false;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (shouldRedraw)
            {
                redrawCanvas();
                shouldRedraw = false;
            }
        }

        void redrawCanvas()
        {
            g.Clear(Color.White);
            foreach (var p in points)
            {
                g.DrawLine(blackPen, p.left, p.right);
                g.FillEllipse(new SolidBrush(Color.Blue), p.left.X - 3, p.left.Y - 3, 7, 7);
                g.FillEllipse(new SolidBrush(Color.Blue), p.right.X - 3, p.right.Y - 3, 7, 7);
                g.FillEllipse(new SolidBrush(Color.Red), p.main.X - 5, p.main.Y - 5, 9, 9);
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                drawBezierLine(points[i].main, points[i].right, points[i + 1].left, points[i + 1].main);
            }
            canvas.Image = myBitmap;
        }



        void drawBezierLine(Point p1, Point p2, Point p3, Point p4)
        {
            Point lastPoint = p1;
            for (double t = 0.05; t <= 1; t += 0.05)
            {
                int x = (int)(Math.Pow(1 - t, 3) * p1.X + 3 * Math.Pow(1 - t, 2) * t * p2.X + 3 * (1 - t) * Math.Pow(t, 2) * p3.X + Math.Pow(t, 3) * p4.X);
                int y = (int)(Math.Pow(1 - t, 3) * p1.Y + 3 * Math.Pow(1 - t, 2) * t * p2.Y + 3 * (1 - t) * Math.Pow(t, 2) * p3.Y + Math.Pow(t, 3) * p4.Y);
                g.DrawLine(new Pen(Color.Black, 4), lastPoint, lastPoint = new Point(x, y));
            }
            g.DrawLine(new Pen(Color.Black, 4), lastPoint, p4);
        }

        int draggingPointIndex = -1;
        PointType draggingPointType;
        bool isDragging = false;

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if ((Math.Abs(points[i].main.X - e.X) < 10) && (Math.Abs(points[i].main.Y - e.Y) < 10))
                    {
                        draggingPointIndex = i;
                        draggingPointType = PointType.MAIN;
                        isDragging = true;
                        return;
                    }
                    if ((Math.Abs(points[i].left.X - e.X) < 10) && (Math.Abs(points[i].left.Y - e.Y) < 10))
                    {
                        draggingPointIndex = i;
                        draggingPointType = PointType.LEFT;
                        isDragging = true;
                        return;
                    }
                    if ((Math.Abs(points[i].right.X - e.X) < 10) && (Math.Abs(points[i].right.Y - e.Y) < 10))
                    {
                        draggingPointIndex = i;
                        draggingPointType = PointType.RIGHT;
                        isDragging = true;
                        return;
                    }
                }
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                points[draggingPointIndex].replacePoint(draggingPointType, e.Location);
                shouldRedraw = true;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (var point in points)
                {
                    if ((Math.Abs(point.main.X - e.X) < 10) && (Math.Abs(point.main.Y - e.Y) < 10))
                    {
                        points.Remove(point);
                        shouldRedraw = true;
                        return;
                    }
                }
            }
            else
            {
                if (!isDragging)
                {
                    points.Add(new BezPoint(e.Location));
                    shouldRedraw = true;
                    return;
                }
                isDragging = false;
                draggingPointIndex = -1;
            }
        }

        private void delall_button_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            points.Clear();
        }
    }
    public class BezPoint
    {
        public Point main;
        public Point left;
        public Point right;

        public BezPoint(Point point)
        {
            main = point;
            left = new Point(main.X - 50, main.Y);
            right = new Point(main.X + 50, main.Y);
        }

        void changeMainPointLocation(Point newLocation)
        {
            left.Offset(newLocation.X - main.X, newLocation.Y - main.Y);
            right.Offset(newLocation.X - main.X, newLocation.Y - main.Y);
            main = newLocation;
        }

        void changeLeftPointLocation(Point newLocation)
        {
            right.X -= newLocation.X - left.X;
            right.Y -= newLocation.Y - left.Y;
            left = newLocation;
        }

        void changeRightPointLocation(Point newLocation)
        {
            left.X -= newLocation.X - right.X;
            left.Y -= newLocation.Y - right.Y;
            right = newLocation;
        }

        public void replacePoint(PointType type, Point newPoint)
        {
            switch (type)
            {
                case PointType.MAIN: changeMainPointLocation(newPoint); break;
                case PointType.LEFT: changeLeftPointLocation(newPoint); break;
                case PointType.RIGHT: changeRightPointLocation(newPoint); break;
            }
        }

    }
}
