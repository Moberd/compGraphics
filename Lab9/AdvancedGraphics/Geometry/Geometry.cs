using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    public delegate void ActionRef<T>(ref T item);

    /// <summary>
    /// Тип проекции на экран
    /// </summary>
    public enum ProjectionType
    {
        ISOMETRIC,
        PERSPECTIVE,
        TRIMETRIC,
        DIMETRIC,
        PARALLEL
    }

    class Geometry
    {
        /// <summary>
        /// Переводит угол из градусов в радианы
        /// </summary>
        /// <param name="angle">Угол в градусах</param>
        ///
        public static double degreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double radiansToDegrees(double angle)
        {
            return angle * 180 / Math.PI;
        }

        /// <summary>
        /// Косинус из угла в градусах, ограниченный 5 знаками после запятой
        /// </summary>
        /// <param name="angle">Угол в градусах</param>
        /// <returns></returns>
        public static double Cos(double angle)
        {
            return Math.Cos(degreesToRadians(angle));
        }

        /// <summary>
        /// Синус из угла в градусах, ограниченный 5 знаками после запятой
        /// </summary>
        /// <param name="angle">Угол в градусах</param>
        /// <returns></returns>
        public static double Sin(double angle)
        {
            return Math.Sin(degreesToRadians(angle));
        }

        public static double distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X * 100 - p2.X * 100,2) + Math.Pow(p1.Y * 100 - p2.Y * 100,2) + Math.Pow(p1.Z * 100 - p2.Z * 100,2));
        }

        /// <summary>
        /// Перевод точки в другую точку
        /// </summary>
        /// <param name="p">Исзодная точка</param>
        /// <param name="matrix">Матрица перевода</param>
        ///
        public static Point transformPoint(Point p, Matrix matrix)

        {
            var matrfrompoint = new Matrix(4, 1).fill(p.X, p.Y, p.Z, 1);

            var matrPoint = matrix * matrfrompoint; //применение преобразования к точке
            //Point newPoint = new Point(matrPoint[0, 0] / matrPoint[3, 0], matrPoint[1, 0] / matrPoint[3, 0], matrPoint[2, 0] / matrPoint[3, 0]);
            Point newPoint = new Point(matrPoint[0, 0], matrPoint[1, 0], matrPoint[2, 0]);
            return newPoint;
        }

        /// <summary>
        /// Перевод всех точек для тела вращения в другие точки
        /// </summary>
        /// <param name="matrix">Матрица перевода</param>
        ///
        public static List<Point> transformPointsRotationFig(Matrix matrix, List<Point> allpoints)
        {
            List<Point> clone = allpoints;
            List<Point> res = new List<Point>();
            foreach (var p in clone)
            {
                Point newp = transformPoint(p, matrix);
                res.Add(newp);
            }

            return res;
        }

        /// <summary>
        /// Поворот образующей для фигуры вращения
        /// </summary>
        /// <param name="general">образующая</param>
        /// <param name="axis">Ось вращения</param>
        /// <param name="angle">угол вращения</param>
        /// <returns></returns>
        public static List<Point> RotatePoint(List<Point> general, AxisType axis, double angle)
        {
            List<Point> res;
            double mysin = Math.Sin(Geometry.degreesToRadians(angle));
            double mycos = Math.Cos(Geometry.degreesToRadians(angle));
            Matrix rotation = new Matrix(0, 0);

            switch (axis)
            {
                case AxisType.X:
                    rotation = new Matrix(4, 4).fill(1, 0, 0, 0, 0, mycos, -mysin, 0, 0, mysin, mycos, 0, 0, 0, 0, 1);
                    break;
                case AxisType.Y:
                    rotation = new Matrix(4, 4).fill(mycos, 0, mysin, 0, 0, 1, 0, 0, -mysin, 0, mycos, 0, 0, 0, 0, 1);
                    break;
                case AxisType.Z:
                    rotation = new Matrix(4, 4).fill(mycos, -mysin, 0, 0, mysin, mycos, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }

            res = Geometry.transformPointsRotationFig(rotation, general);

            return res;
        }
        /// <summary>
        /// Возвращает крайние точки по 2 осям
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns>Квадрюпель координат Xmin Xmax Ymin Ymax</returns>
        public static Tuple<double, double, double, double> getTriangleBounds(List<Vertex> triangle)
        {
            if(triangle.Count != 3)
            {
                throw new Exception("It's not a triangle >:(");
            }
            return Tuple.Create(Math.Min(Math.Min(triangle[0].Xf, triangle[1].Xf), triangle[2].Xf),
                Math.Max(Math.Max(triangle[0].Xf, triangle[1].Xf), triangle[2].Xf),
                Math.Min(Math.Min(triangle[0].Yf, triangle[1].Yf), triangle[2].Yf),
                Math.Max(Math.Max(triangle[0].Yf, triangle[1].Yf), triangle[2].Yf));
        }
    }
}