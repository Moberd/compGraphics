using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Rastr
{
    public partial class GradientTraing : Form
    {
        List<Tuple<Point, Color>> vertices;
        //private Bitmap image = null;
        static Bitmap bitmap = new Bitmap(325, 399);

        public GradientTraing()
        {
            InitializeComponent();
            color1.BackColor = Color.Red;
            color2.BackColor = Color.FromArgb(0, 255, 0);
            color3.BackColor = Color.Blue;
            vertices = new List<Tuple<Point, Color>>();
        }

        //Правильное закрытие окна
        private void GradientTraing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void color1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor = colorDialog.Color;
            }
        }

        private void color2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color2.BackColor = colorDialog.Color;
            }
        }

        private void color3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color3.BackColor = colorDialog.Color;
            }
        }
        
        private void Clear_Click(object sender, EventArgs e)
        {
            canvas.Image = null;
            bitmap = new Bitmap(325, 399);
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (vertices.Count == 0)
            {
                vertices.Add(Tuple.Create(e.Location, color1.BackColor));
            }
            else if (vertices.Count == 1)
            {
                vertices.Add(Tuple.Create(e.Location, color2.BackColor));
            }
            else if (vertices.Count == 2)
            {
                vertices.Add(Tuple.Create(e.Location, color3.BackColor));
                drawTriangle();
                vertices.Clear();
            }
        }

        public static Color[] interpolateRGB(Color start, Color end, int seed)
        {
            List<Color> res = new List<Color>();
            double rstep = (end.R - start.R) / (1.0 * seed - 1);
            double gstep = (end.G - start.G) / (1.0 * seed - 1);
            double bstep = (1.0 * end.B - start.B) / (seed - 1);

            for (int i = 0; i < seed; i++)
            {
                res.Add(Color.FromArgb((byte)Math.Round(start.R + rstep * i), (byte)Math.Round(start.G + gstep * i),
                    (byte)Math.Round(start.B + bstep * i)));
            }

            return res.ToArray();
        }

        void drawTriangle()
        {
            vertices = vertices.OrderBy(x => x.Item1.Y).ToList();

            var e1 = getLineCoordsByBresenham(vertices[0].Item1, vertices[1].Item1).GroupBy(p => p.Y)
                .Select(g => (vertices[0].Item1.X > vertices[1].Item1.X ? g.First() : g.Last())).ToArray();
            var e2 = getLineCoordsByBresenham(vertices[0].Item1, vertices[2].Item1).GroupBy(p => p.Y)
                .Select(g => (vertices[0].Item1.X > vertices[2].Item1.X ? g.First() : g.Last())).ToArray();
            var e3 = getLineCoordsByBresenham(vertices[1].Item1, vertices[2].Item1).GroupBy(p => p.Y)
                .Select(g => (vertices[1].Item1.X > vertices[2].Item1.X ? g.First() : g.Last())).ToArray();

            var c1 = interpolateRGB(vertices[0].Item2, vertices[1].Item2, e1.Length);
            var c2 = interpolateRGB(vertices[0].Item2, vertices[2].Item2, e2.Length);
            var c3 = interpolateRGB(vertices[1].Item2, vertices[2].Item2, e3.Length);

            for (int i = 0; i < e1.Length; i++)
            {
                Color[] colors;
                Point left, right;
                if (vertices[1].Item1.X < vertices[2].Item1.X)
                {
                    colors = interpolateRGB(c1[i], c2[i], Math.Abs(e2[i].X - e1[i].X) + 1);
                    left = e1[i];
                    right = e2[i];
                }
                else
                {
                    colors = interpolateRGB(c2[i], c1[i], Math.Abs(e2[i].X - e1[i].X) + 1);
                    left = e2[i];
                    right = e1[i];
                }

                int cind = 0;
                for (int x = left.X; x <= right.X; x++)
                {
                    bitmap.SetPixel(x, e2[i].Y, colors[cind]);
                    cind++;
                }
            }

            for (int i = 0; i < e3.Length; i++)
            {
                int ie2 = i + e1.Length - 1;
                Color[] colors;
                Point left, right;
                if (vertices[1].Item1.X < vertices[2].Item1.X)
                {
                    colors = interpolateRGB(c3[i], c2[ie2], Math.Abs(e3[i].X - e2[ie2].X) + 1);
                    left = e3[i];
                    right = e2[ie2];
                }
                else
                {
                    colors = interpolateRGB(c2[ie2], c3[i], Math.Abs(e3[i].X - e2[ie2].X) + 1);
                    left = e2[ie2];
                    right = e3[i];
                }

                int cind = 0;
                for (int x = left.X; x <= right.X; x++)
                {
                    bitmap.SetPixel(x, e2[ie2].Y, colors[cind]);
                    cind++;
                }
            }

            canvas.Image = bitmap;
        }

        private Point[] getLineHigh(int x0, int y0, int x1, int y1)
        {
            List<Point> res = new List<Point>();
            int dx = x1 - x0;
            int dy = y1 - y0;
            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }

            int D = (2 * dx) - dy;
            int x = x0;

            for (int y = y0; y <= y1; y++)
            {
                res.Add(new Point(x, y));
                if (D > 0)
                {
                    x += xi;
                    D += 2 * (dx - dy);
                }
                else
                {
                    D += 2 * dx;
                }
            }

            return res.OrderBy(p => p.Y).ToArray();
        }

        private Point[] getLineLow(int x0, int y0, int x1, int y1)
        {
            List<Point> res = new List<Point>();
            int dx = x1 - x0;
            int dy = y1 - y0;
            int yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }

            int D = (2 * dy) - dx;
            int y = y0;

            for (int x = x0; x <= x1; x++)
            {
                res.Add(new Point(x, y));
                if (D > 0)
                {
                    y += yi;
                    D += 2 * (dy - dx);
                }
                else
                {
                    D += 2 * dy;
                }
            }

            return res.OrderBy(p => p.Y).ToArray();
        }

        Point[] getLineCoordsByBresenham(Point p0, Point p1)
        {
            if (Math.Abs(p1.Y - p0.Y) < Math.Abs(p1.X - p0.X))
            {
                if (p0.X > p1.X)
                {
                    return getLineLow(p1.X, p1.Y, p0.X, p0.Y);
                }
                return getLineLow(p0.X, p0.Y, p1.X, p1.Y);
            }
            
            if (p0.Y > p1.Y)
            {
                return getLineHigh(p1.X, p1.Y, p0.X, p0.Y);
            }

            return getLineHigh(p0.X, p0.Y, p1.X, p1.Y);
        }

    }
}