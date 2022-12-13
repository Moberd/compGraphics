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
    public partial class FormBezier : Form
    {
        public List<Point> points = new List<Point>();
        public bool new_button = false;
        public Graphics gr;
        public Point drPoint;
        Pen blackPen = new Pen(Color.Black, 3);
        public int drInd;
        public bool moving = false;
        public bool deleting = false;

        public FormBezier()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            //gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drPoint = new Point(0, 0);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (deleting)
            {
                int delInd = -1;
                for (int i = 0; i < points.Count; i++)
                    if (Math.Sqrt(Math.Pow(e.X - points[i].X, 2) + Math.Pow(e.Y - points[i].Y, 2)) <= 7)
                        delInd = i;
                if (delInd != -1)
                    points.RemoveAt(delInd);
                button1.Enabled = true;
                if (points.Count < 4)
                    draw_points();
                else
                    drawBesier();
            }

            if (!moving && !deleting)
            {
                points.Add(new Point(e.X, e.Y));
                new_button = false;
                if (points.Count < 4)
                    draw_points();
                else
                    drawBesier();
            }
            else if (!deleting)
            {
                moving = false;
            }
            deleting = false;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!deleting)
                for (int i = 0; i < points.Count; i++)
                {
                    if (Math.Sqrt(Math.Pow(e.X - points[i].X, 2) + Math.Pow(e.Y - points[i].Y, 2)) <= 7)
                    {
                        drInd = i;
                        moving = true;
                    }
                }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && !deleting)
            {
                points[drInd] = new Point(e.X, e.Y);
                drawBesier();

            }

        }

        public void draw_points()
        {
            gr.Clear(Color.White);
            for (int i = 0; i < points.Count; i++)
            {
                gr.FillEllipse(new SolidBrush(Color.Black), points[i].X - 3, points[i].Y - 3, 7, 7);
            }
        }

        public void drawBesier()
        {
            gr.Clear(Color.White);

            List<Point> newPoints = new List<Point>();
            newPoints.Add(points[0]);
            newPoints.Add(points[1]);
            newPoints.Add(points[2]);

            for (int i = 3; i < points.Count; i++)
            {
                if (i != points.Count - 1)
                {
                    if (i % 2 == 0)
                        newPoints.Add(points[i]);
                    if (i % 2 != 0)
                    {
                        newPoints.Add(new Point(points[i - 1].X + (points[i].X - points[i - 1].X) / 2, points[i - 1].Y + (points[i].Y - points[i - 1].Y) / 2));
                        newPoints.Add(points[i]);
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        newPoints.Add(points[i]);
                        newPoints.Add(points[i]);
                    }
                    if (i % 2 != 0)
                        newPoints.Add(points[i]);
                }
            }

            List<Point> drawingPoints = new List<Point>();

            Point point1;
            Point point2;
            Point point3;
            Point point4;

            for (int i = 0; i < newPoints.Count - 3; i += 3)
            {
                point1 = newPoints[i];
                point2 = newPoints[i + 1];
                point3 = newPoints[i + 2];
                point4 = newPoints[i + 3];

                int N = 100;
                double dt = 1.0 / N;
                double t = 0.0;
                for (int j = 0; j <= N; j++)
                {
                    drawingPoints.Add(B(t, point1, point2, point3, point4));
                    t += dt;
                }

            }
            gr.DrawLines(blackPen, drawingPoints.ToArray());
            for (int i = 0; i < newPoints.Count; i++)
            {
                //if (!points.Contains(newPoints[i]))
                //    gr.FillEllipse(Brushes.Blue, newPoints[i].X - 2, newPoints[i].Y - 2, 3, 3);
                //else
                //    gr.FillEllipse(Brushes.Red, newPoints[i].X - 2, newPoints[i].Y - 2, 7, 7);

                if (points.Contains(newPoints[i]))
                    gr.FillEllipse(Brushes.Red, newPoints[i].X - 2, newPoints[i].Y - 2, 7, 7);
            }
        }
        private Point B(double t, Point point1, Point point2, Point point3, Point point4)
        {
            double x = (1 - t) * (1 - t) * (1 - t) * point1.X + (1 - t) * (1 - t) * 3 * t * point2.X + (1 - t) * t * 3 * t * point3.X + t * t * t * point4.X;
            double y = (1 - t) * (1 - t) * (1 - t) * point1.Y + (1 - t) * (1 - t) * 3 * t * point2.Y + (1 - t) * t * 3 * t * point3.Y + t * t * t * point4.Y;
            return new Point((int)x, (int)y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            points.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            deleting = true;
        }
    }
}
