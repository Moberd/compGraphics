using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AutoKek
{
    partial class Form1
    {
        // Положение точки относительно направленного ребра
        // yb·xa - xb·ya > 0 => b слева от Oa    
        // yb·xa - xb·ya < 0 => b справа от Oa
        private void ClassifyPoint(PointF edgeStart, PointF edgeEnd, PointF p)
        {
            float res = (p.X - edgeStart.X) * (edgeEnd.Y - edgeStart.Y) - (p.Y - edgeStart.Y) * (edgeEnd.X - edgeStart.X);
            if (res > 0)
                labelClassifyPoint.Text = "Точка находится слева от ребра";
            else if (res < 0)
                labelClassifyPoint.Text = "Точка находится справа от ребра";
            else
                labelClassifyPoint.Text = "Точка на отрезочке О_О Очень метко!";
        }

        // Положение точки относительно многоугольника
        // Многоугольник будет выпуклым если при его обходе в каждой тройке последовательных вершин происходит поворот всегда в одну и ту же сторону.
        // Если одно ребро многоугольника соответствует вектору AB, а следующее за ним ребро соответствует вектору BC, то направление поворота = AB.x* BC.y - AB.y* BC.x
        private void PointInPolygon(PointF p)
        {
                 // определение выпуклости многоугольника
                 CheckConvex(p, polygonPoints);

                 // определение принадлежности точки многоугольнику
                 CheckOuter(p, polygonPoints);
        }

        private void buttonIsPointInPolygon_Click(object sender, EventArgs e)
        {
            isPointInPolygonMode = true;
            labelClassifyPoint.Text = "";

        }

        private void CheckConvex(PointF p, List<PointF> points)
        {
            bool isConvexPolygon = true;
            bool sign = true, tempSign = true;
            PointF ab = new PointF(points[1].X - points[0].X, points[1].Y - points[0].Y);
            PointF bc = new PointF(points[2].X - points[1].X, points[2].Y - points[1].Y);
            double rot = ab.X * bc.Y - ab.Y * bc.X; // направление поворота
            if (rot < 0)
                sign = false; // для проверки выпуклости

            for (int i = 1; i < points.Count-1; i++)
            {
                ab = new PointF(points[i].X - points[i - 1].X, points[i].Y - points[i - 1].Y);
                bc = new PointF(points[i+1].X - points[i].X, points[i+1].Y - points[i].Y);
                rot = ab.X * bc.Y - ab.Y * bc.X;
                if (rot < 0)
                    tempSign = false;
                else
                    tempSign = true;
                if (sign != tempSign) // если поворот отличается от остальных
                    isConvexPolygon = false;
            }

            ab = new PointF(points[0].X - points[points.Count - 1].X, points[0].Y - points[points.Count - 1].Y);
            bc = new PointF(points[1].X - points[0].X, points[1].Y - points[0].Y);
            rot = ab.X * bc.Y - ab.Y * bc.X;
            if (rot < 0)
                tempSign = false;
            if (sign != tempSign) // если поворот отличается от остальных
                isConvexPolygon = false;
            if (isConvexPolygon)
                labelConvexPolygon.Text = "Выпуклый многоугольник";
            else
                labelConvexPolygon.Text = "Невыпуклый многоугольник";
        }

        private void CheckOuter(PointF p, List<PointF> points)
        {
            bool inPolygon = false;
            int j = points.Count() - 1;
            for (int i = 0; i < points.Count(); i++)
            {
                var p1 = points[i];
                var p2 = points[j];
                var checkY = p1.Y < p.Y && p2.Y >= p.Y || p2.Y < p.Y && p1.Y >= p.Y;
                if (checkY)
                {
                    var checkX = p1.X + (p.Y - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X) < p.X;
                    if (checkX)
                    {
                        inPolygon = !inPolygon;
                    }
                }
                j = i;
            }
            if (inPolygon)
                labelPointInPolygon.Text = "Точка принадлежит";
            else
                labelPointInPolygon.Text = "Точка не принадлежит";
        }

        private void buttonClassifyPoint_Click(object sender, EventArgs e)
        {
            isPointClassifyMode = true;
            buttonIsPointInPolygon.Enabled = false;
            labelConvexPolygon.Text = "";
            labelPointInPolygon.Text = "";
        }
    }
}
