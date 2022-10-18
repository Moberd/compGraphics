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
        private void ClassifyPoint(Point edgeStart, Point edgeEnd, Point p)
        {
            int res = (p.X - edgeStart.X) * (edgeEnd.Y - edgeStart.Y) - (p.Y - edgeStart.Y) * (edgeEnd.X - edgeStart.X);
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
        private void PointInPolygon(Point p)
        {
            // определение выпуклости многоугольника
            bool isConvexPolygon = true;
            bool sign = true, tempSign = true;
            Point ab = new Point(polygonPoints[1].X - polygonPoints[0].X, polygonPoints[1].Y - polygonPoints[0].Y);
            Point bc = new Point(polygonPoints[2].X - polygonPoints[1].X, polygonPoints[2].Y - polygonPoints[1].Y);
            double rot = ab.X * bc.Y - ab.Y * bc.X; // направление поворота
            if (rot < 0)
                sign = false; // для проверки выпуклости

            for (int i = 1; i < polygonPoints.Count-1; i++)
            {
                ab = new Point(polygonPoints[i].X - polygonPoints[i - 1].X, polygonPoints[i].Y - polygonPoints[i - 1].Y);
                bc = new Point(polygonPoints[i+1].X - polygonPoints[i].X, polygonPoints[i+1].Y - polygonPoints[i].Y);
                rot = ab.X * bc.Y - ab.Y * bc.X;
                if (rot < 0)
                    tempSign = false;
                else
                    tempSign = true;
                if (sign != tempSign) // если поворот отличается от остальных
                    isConvexPolygon = false;
            }
            ab = new Point(polygonPoints[0].X - polygonPoints[polygonPoints.Count - 1].X, polygonPoints[0].Y - polygonPoints[polygonPoints.Count - 1].Y);
            bc = new Point(polygonPoints[1].X - polygonPoints[0].X, polygonPoints[1].Y - polygonPoints[0].Y);
            rot = ab.X * bc.Y - ab.Y * bc.X;
            if (rot < 0)
                tempSign = false;
            else
                tempSign = true;
            if (sign != tempSign) // если поворот отличается от остальных
                isConvexPolygon = false;

            if (isConvexPolygon)
                labelConvexPolygon.Text = "Выпуклый многоугольник";
            else
                labelConvexPolygon.Text = "Невыпуклый многоугольник";


            // определение принадлежности точки многоугольнику
            bool inPolygon = false;
            int counter = 0;
            double xinters;
            Point p1, p2;
            int pointCount = polygonPoints.Count;
            p1 = polygonPoints[0];
            for (int i = 1; i <= pointCount; i++)
            {
                p2 = polygonPoints[i % pointCount];
                if (p.Y > Math.Min(p1.Y, p2.Y)// Y контрольной точки больше минимума Y конца отрезка
                && p.Y <= Math.Max(p1.Y, p2.Y))// Y контрольной точки меньше максимального Y конца отрезка
                {
                    if (p.X <= Math.Max(p1.X, p2.X))// X контрольной точки меньше максимального X конечной точки сегмента изолинии (для оценки используйте левый луч контрольной точки).
                    {
                        if (p1.Y != p2.Y)// Отрезок не параллелен оси X
                        {
                            xinters = (p.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
                            if (p1.X == p2.X || p.X <= xinters)
                            {
                                counter++;
                            }
                        }
                    }

                }
                p1 = p2;
            }

            if (counter % 2 == 0)

                inPolygon = false;
            else
                inPolygon = true;
            if (inPolygon)
                labelPointInPolygon.Text = "Точка принадлежит";
            else
                labelPointInPolygon.Text = "Точка не принадлежит"; 
        }

        private void buttonIsPointInPolygon_Click(object sender, EventArgs e)
        {
            isPointInPolygonMode = true;
            labelClassifyPoint.Text = "";

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
