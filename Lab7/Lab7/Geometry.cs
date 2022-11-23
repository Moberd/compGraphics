using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    delegate void ActionRef<T>(ref T item);
    /// <summary>
    /// Тип проекции на экран
    /// </summary>
    public enum ProjectionType { ISOMETRIC, PERSPECTIVE, TRIMETRIC, CAVALIER }
    /// <summary>
    /// Точка в пространстве
    /// </summary>
    class Point
    {
        double x, y, z;
        public static ProjectionType projection = ProjectionType.TRIMETRIC;
        public static PointF worldCenter;
        static Matrix isometricMatrix = new Matrix(3,3).fill(Math.Sqrt(3),0,-Math.Sqrt(3),1,2,1, Math.Sqrt(2),-Math.Sqrt(2), Math.Sqrt(2)) * (1/ Math.Sqrt(6));
        static Matrix trimetricMatrix = new Matrix(4, 4).fill(Math.Sqrt(3)/2, Math.Sqrt(2)/4, 0, 1, 0, Math.Sqrt(2)/2, 0, 1, 0.5,-Math.Sqrt(6)/4,0,0,0,0,0,1);
        static Matrix cavalierMatrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, Math.Cos(Math.PI/4), Math.Cos(Math.PI/4), 0, 0, 0, 0, 0, 1);
        static Matrix centralMatrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, k, 0, 0, 0, 1);
        const double k = 0.001f;
        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X { get => (int)x; set => x = value; }
        public int Y { get => (int)y; set => y = value; }
        public int Z { get => (int)z; set => z = value; }

        public double Xf { get => x; set => x = value; }
        public double Yf { get => y; set => y = value; }
        public double Zf { get => z; set => z = value; }

        /// <summary>
        /// Перевод точки из 3D в 2D
        /// </summary>
        /// <returns>Точку на экране в вещестаенных координатах</returns>
        public PointF to2D(){
            if (projection == ProjectionType.PERSPECTIVE)
            {
                Matrix res = new Matrix(1, 4).fill(Xf, Yf, Zf, 1) * centralMatrix * (1/(k*Zf + 1));
                return new PointF(worldCenter.X + (float)res[0,0], worldCenter.Y + (float)res[0,1]);
            }
            else if (projection == ProjectionType.TRIMETRIC)
            {
                Matrix res = new Matrix(1, 4).fill(Yf, Zf, Xf, 1) * trimetricMatrix;
                return new PointF(worldCenter.X + (float)res[0,0], worldCenter.Y + (float)res[0, 1]);
            }
            else if (projection == ProjectionType.CAVALIER)
            {
                Matrix res = new Matrix(1, 4).fill(Xf, Yf, Zf, 1) * cavalierMatrix;
                return new PointF(worldCenter.X + (float)res[0, 0], worldCenter.Y + (float)res[0, 1]);
            }
            else
            {
                Matrix res = new Matrix(3, 3).fill(1, 0, 0, 0, 1, 0, 0, 0, 0) * isometricMatrix * new Matrix(3, 1).fill(Xf, Yf, Zf);
                return new PointF(worldCenter.X + (float)res[0, 0], worldCenter.Y + (float)res[1, 0]);
            }
        }
    }
    /// <summary>
    /// Отрезок в пространстве
    /// </summary>
    class Line
    {
        public Point start,end;

        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }
    }
    /// <summary>
    /// Грань фигуры, состоящая из конечного числа отрезков
    /// </summary>
    class Face
    {
        List<Line> edges;

        public Face()
        {
            edges = new List<Line>();
        }

        public Face(IEnumerable<Line> edges) : this()
        {
            this.edges.AddRange(edges);
        }

        public Face addEdge(Line edge)
        {
            edges.Add(edge);
            return this;
        }
        public Face addEdges(IEnumerable<Line> edges)
        {
            this.edges.AddRange(edges);
            return this;
        }

        public List<Line> Edges { get => edges; }

        /// <summary>
        /// Получение центра тяжести грани
        /// </summary>
        /// <returns><c>Point</c> - центр тяжести</returns>
        public Point getCenter()
        {
            double x = 0, y = 0, z = 0;
            foreach(var line in edges)
            {
                x += line.Start.Xf;
                y += line.Start.Yf;
                z += line.Start.Zf;
            }
            return new Point(x / edges.Count, y / edges.Count, z / edges.Count);
        }
    }

    /// <summary>
    /// Объёмная фигура, состоящая из граней
    /// </summary>
    class Shape
    {
        List<Face> faces;
      
        public Shape()
        {
            faces = new List<Face>();
        }

        public Shape(IEnumerable<Face> faces) : this()
        {
            this.faces.AddRange(faces);
        }

        public Shape addFace(Face face)
        {
            faces.Add(face);
            return this;
        }
        public Shape addFaces(IEnumerable<Face> faces)
        {
            this.faces.AddRange(faces);
            return this;
        }

        public List<Face> Faces { get => faces; }

        /// <summary>
        /// Преобразует все точки в фигуре по заданной функции
        /// </summary>
        /// <param name="f">Функция, преобразующая точку фигуры</param>
        public void transformPoints(ActionRef<Point> f)
        {
            foreach (var face in Faces)
            {
                foreach (var line in face.Edges)
                {
                    f(ref line.start);
                    f(ref line.end);
                }
            }
        }
        
        /// <summary>
        /// Виртуальный метод, чтобы наследники могли возвращать какую-то инфу для сохранения в файл
        /// </summary>
        /// <returns></returns>
        public virtual String getAdditionalInfo()
        {
            return "";
        }
       /// <summary>
        /// Виртуальный метод, чтобы наследники могли возвращать свои имена
        /// </summary>
        /// <returns></returns>
        public virtual String getShapeName()
        {
            return "SHAPE";
        }
        // читает модель многогранника из файла
        public static Shape readShape(string fileName)
        {
            Shape res = new Shape();
            StreamReader sr = new StreamReader(fileName);
            List<Line> edgs = new List<Line>();
            // название фигуры
            string line = sr.ReadLine();
            if (line != null)
            {
                switch (line)
                {
                    case "TETRAHEDRON":
                        res = new Tetrahedron();
                        break;
                    case "HEXAHEDRON":
                        res = new Hexahedron();
                        break;
                    case "OCTAHEDRON":
                        res = new Octahedron();
                        break;
                    case "SURFACESEGMENT":
                        res = new SurfaceSegment();
                        break;
                    case "ROTATIONSHAPE":
                        res = new RotationShape();
                        break;
                    default:
                        throw new Exception("Такой фигуры нет :с");
                }
            }
            line = sr.ReadLine();
            if (line != null)
            {
                // какая-то доп информация
                res.getAdditionalInfo();
            }
            line = sr.ReadLine();
            // считываем данные о каждой грани
            while (line != null)
            {
                string[] lineParse = line.Split(); // делим грань на ребра
                foreach (string pointLine in lineParse)
                {
                    if (pointLine == "")
                        break;
                    string[] str = pointLine.Split(';'); // делим на точки начала и конца ребер
                    var startPoint = str[0].Split(','); // начало ребра
                    var endPoint = str[1].Split(','); // конец ребра
                    // добавляем новое ребро текущей грани
                    edgs.Add(new Line(new Point(int.Parse(startPoint[0]), int.Parse(startPoint[1]), int.Parse(startPoint[2])), new Point(int.Parse(endPoint[0]), int.Parse(endPoint[1]), int.Parse(endPoint[2]))));
                }
                res.addFace(new Face(edgs)); // добавляем целую грань фигуры
                edgs = new List<Line>();
                line = sr.ReadLine();
            }
            sr.Close();
            return res;
        }
       // сохраняет модель многогранника в файл
        public void saveShape(string fileName)
        {
            // очистка файла
            File.WriteAllText(fileName, String.Empty);
            // запись в файл
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(this.getShapeName()); // название фигуры
            sw.WriteLine(this.getAdditionalInfo()); // дополнительная информация
            foreach (Face face in this.Faces)
            {
                foreach (Line edge in face.Edges)
                {
                    sw.Write(edge.Start.X + "," + edge.Start.Y + "," + edge.Start.Z + ";" + edge.End.X + "," + edge.End.Y + "," + edge.End.Z + " ");
                }
                sw.WriteLine();
            }
            sw.Close();
        }

    }

    class Tetrahedron : Shape
    {
        public override String getShapeName()
        {
            return "TETRAHEDRON";
        }
    }

    class Octahedron : Shape
    {
        public override String getShapeName()
        {
            return "OCTAHEDRON";
        }
    }

    class Hexahedron : Shape
    {
        public override String getShapeName()
        {
            return "HEXAHEDRON";
        }
    }

    class SurfaceSegment : Shape
    {
        int x0, x1, y0, y1;
        int splitting;

        public SurfaceSegment()
        {
        }

        public SurfaceSegment(int x0, int x1, int y0, int y1, int splitting)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.y0 = y0;
            this.y1 = y1;
            this.splitting = splitting;
        }
    }
    
    class RotationShape : Shape
    {
        List<Point> formingline;
        Line axiz;
        int Divisions;
        List<Point> allpoints;
        List<Line> edges;//ребра
        public RotationShape()
        {
            allpoints = new List<Point>();
            edges = new List<Line>();
        }
        public List<Line> Edges { get => edges; }
        public Shape addEdge(Line edge)
        {
            edges.Add(edge);
            return this;
        }
        public Shape addEdges(IEnumerable<Line> ed)
        {
            this.edges.AddRange(ed);
            return this;
        }
        public RotationShape(IEnumerable<Point> points) : this()
        {
            this.allpoints.AddRange(points);
        }
        public RotationShape(Line ax, int Div, IEnumerable<Point> line) : this()
        {
            this.axiz=ax;
            this.Divisions = Div;
            this.formingline.AddRange(line);
        }
        public RotationShape addPoint(Point p)
        {
            allpoints.Add(p);
            return this;
        }
        public RotationShape addPoints(IEnumerable<Point> points)
        {
            this.allpoints.AddRange(points);
            return this;
        }
        public List<Point> Points { get => allpoints; }
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

        /// <summary>
        /// Косинус из угла в градусах, ограниченный 5 знаками после запятой
        /// </summary>
        /// <param name="angle">Угол в градусах</param>
        /// <returns></returns>
        public static double Cos (int angle)
        {
            return Math.Round(Math.Cos(degreesToRadians(angle)), 5);
        }
        /// <summary>
        /// Синус из угла в градусах, ограниченный 5 знаками после запятой
        /// </summary>
        /// <param name="angle">Угол в градусах</param>
        /// <returns></returns>
        public static double Sin(int angle)
        {
            return Math.Round(Math.Sin(degreesToRadians(angle)), 5);
        }
        /// <summary>
        /// Перевод точки в другую точку
        /// </summary>
        /// <param name="p">Исзодная точка</param>
        /// <param name="matrix">Матрица перевода</param>
        /// 
        public static Point transformPoint(Point p, Matrix matrix)

        {
            var matrfrompoint = new Matrix(4, 1).fill(p.X, p.Y, p.Z,1);

            var matrPoint = matrix * matrfrompoint;//применение преобразования к точке
            //Point newPoint = new Point(matrPoint[0, 0] / matrPoint[3, 0], matrPoint[1, 0] / matrPoint[3, 0], matrPoint[2, 0] / matrPoint[3, 0]);
            Point newPoint = new Point(matrPoint[0, 0], matrPoint[1, 0], matrPoint[2, 0]);
            return newPoint;

        }
        
        /// <summary>
        /// Перевод всех точек для тела вращения в другие точки
        /// </summary>
        /// <param name="matrix">Матрица перевода</param>
        /// 
        public static List<Point> transformPointsRotationFig(Matrix matrix,List<Point> allpoints)
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

    }

    /// <summary>
    /// Класс для получения фигур различного типа
    /// </summary>
    class ShapeGetter
    {
        /// <summary>
        /// Получает фигуру фиксированного размера (в среднем до 200 пикселей по размеру)
        /// </summary>
        /// <param name="type">Тип фигуры</param>
        /// <returns></returns>
        public static Shape getShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.TETRAHEDRON: return getTetrahedron();
                case ShapeType.OCTAHEDRON: return getOctahedron();
                case ShapeType.HEXAHEDRON: return getHexahedron();
               
                default: throw new Exception("C# очень умный (нет)");
            }
        }
       
        /// <summary>
        /// Получение тетраэдра
        /// </summary>
        /// <returns></returns>
        public static Tetrahedron getTetrahedron()
        {
            Tetrahedron res = new Tetrahedron();
            Point a = new Point(0, 0, 0);
            Point c = new Point(200, 0, 200);
            Point f = new Point(200, 200, 0);
            Point h = new Point(0, 200, 200);
            res.addFace(new Face().addEdge(new Line(a, f)).addEdge(new Line(f, c)).addEdge(new Line(c, a)));
            res.addFace(new Face().addEdge(new Line(f, c)).addEdge(new Line(c, h)).addEdge(new Line(h, f)));
            res.addFace(new Face().addEdge(new Line(c, h)).addEdge(new Line(h, a)).addEdge(new Line(a, c)));
            res.addFace(new Face().addEdge(new Line(f, h)).addEdge(new Line(h, a)).addEdge(new Line(a, f)));
            return res;
        }

        /// <summary>
        /// Получение октаэдра
        /// </summary>
        /// <returns></returns>
        public static Octahedron getOctahedron()
        {
            Octahedron res = new Octahedron();
            var cube = getHexahedron();
            Point a = cube.Faces[0].getCenter();
            Point b = cube.Faces[1].getCenter();
            Point c = cube.Faces[2].getCenter();
            Point d = cube.Faces[3].getCenter();
            Point e = cube.Faces[4].getCenter();
            Point f = cube.Faces[5].getCenter();

            res.addFace(new Face().addEdge(new Line(a, f)).addEdge(new Line(f, b)).addEdge(new Line(b, a)));
            res.addFace(new Face().addEdge(new Line(b, c)).addEdge(new Line(c, f)).addEdge(new Line(f, b)));
            res.addFace(new Face().addEdge(new Line(c, d)).addEdge(new Line(d, f)).addEdge(new Line(f, c)));
            res.addFace(new Face().addEdge(new Line(d, a)).addEdge(new Line(a, f)).addEdge(new Line(f, d)));
            res.addFace(new Face().addEdge(new Line(a, e)).addEdge(new Line(e, b)).addEdge(new Line(b, a)));
            res.addFace(new Face().addEdge(new Line(b, e)).addEdge(new Line(e, c)).addEdge(new Line(c, b)));
            res.addFace(new Face().addEdge(new Line(c, e)).addEdge(new Line(e, d)).addEdge(new Line(d, c)));
            res.addFace(new Face().addEdge(new Line(d, e)).addEdge(new Line(e, a)).addEdge(new Line(a, d)));
            return res;
        }

        /// <summary>
        /// Получение гексаэдра (куба)
        /// </summary>
        /// <returns></returns>
        public static Hexahedron getHexahedron()
        {
            Hexahedron res = new Hexahedron();
            Point a = new Point(0, 0, 0);
            Point b = new Point(200, 0, 0);
            Point c = new Point(200, 0, 200);
            Point d = new Point(0, 0, 200);
            Point e = new Point(0, 200, 0);
            Point f = new Point(200, 200, 0);
            Point g = new Point(200, 200, 200);
            Point h = new Point(0, 200, 200);
            res.addFace(new Face().addEdge(new Line(a, b)).addEdge(new Line(b, c)).addEdge(new Line(c, d)).addEdge(new Line(d, a)));
            res.addFace(new Face().addEdge(new Line(b, c)).addEdge(new Line(c, g)).addEdge(new Line(g, f)).addEdge(new Line(f, b)));
            res.addFace(new Face().addEdge(new Line(f, g)).addEdge(new Line(g, h)).addEdge(new Line(h, e)).addEdge(new Line(e, f)));
            res.addFace(new Face().addEdge(new Line(h, e)).addEdge(new Line(e, a)).addEdge(new Line(a, d)).addEdge(new Line(d, h)));
            res.addFace(new Face().addEdge(new Line(a, b)).addEdge(new Line(b, f)).addEdge(new Line(f, e)).addEdge(new Line(e, a)));
            res.addFace(new Face().addEdge(new Line(d, c)).addEdge(new Line(c, g)).addEdge(new Line(g, h)).addEdge(new Line(h, d)));
            return res;
        }

        
       /// <summary>
       /// Получение фигуры вращения
       /// </summary>
       /// <returns></returns>
       public static RotationShape getRotationShape(List<Point> general, int divisions, AxisType axis)
       {
           RotationShape res = new RotationShape();
            List<Point> genline = general;
           int GeneralCount = genline.Count();
           //Line axis;
           int Count = divisions;
           double angle = (360.0 / Count);//угол 
           List<Line> edges;//ребра
        
           res.addPoints(genline);//добавили образующую
           for (int i = 1; i < divisions; i++)//количество разбиений
           {
               res.addPoints(Geometry.RotatePoint(genline, axis, angle * i));
           }
           
           //Фигура вращения задаётся тремя параметрами: образующей(набор точек), осью вращения и количеством разбиений
           //зададим ребра и грани
           for (int i = 0; i < divisions; i++)
           {
               for (int j = 0;  j < GeneralCount; j++)
               {
                   int index = i * GeneralCount + j;//индекс точки
                   if (index < divisions * GeneralCount)
                   {
                       int e = (index + GeneralCount) % res.Points.Count;
                       if ((index + 1) % GeneralCount == 0)
                       {

                           // res.addFace(new Face().addEdge(new Line( res.Points[current], res.Points[e])));
                           res.addEdge(new Line(res.Points[index], res.Points[e]));
                       }
                       else
                       {
                           res.addEdge(new Line(res.Points[index], res.Points[index + 1]));
                           res.addEdge(new Line(res.Points[index], res.Points[e]));
                           int e1 = (index + 1 + GeneralCount) % res.Points.Count;
                           //добавим грань
                           res.addFace(new Face().addEdge(new Line(res.Points[index], res.Points[index + 1])).addEdge(new Line(res.Points[index + 1], res.Points[e1])).addEdge(new Line(res.Points[e1], res.Points[e])).addEdge(new Line(res.Points[e], res.Points[index])));
                       }
                   }
                 
               }


           }
        
           return res;
       }

       public static SurfaceSegment getSurfaceSegment(Func<double, double, double> fun, int x0, int x1, int y0, int y1, int splitting)
       {
           SurfaceSegment res = new SurfaceSegment(x0, x1, y0, y1, splitting);
           double stepX = Math.Abs(x1 - x0) * 1.0 / splitting;
           double stepY = Math.Abs(y1 - y0) * 1.0 / splitting;
           for (double x = x0; x < x1; x += stepX)
           {
               for (double y = y0; y < y1; y += stepY)
               {
                   var face = new Face();
                   face.addEdge(new Line(new Point(x, y, fun(x, y)), new Point(x + stepX, y, fun(x + stepX, y))));
                   face.addEdge(new Line(new Point(x + stepX, y, fun(x + stepX, y)), new Point(x + stepX, y + stepY, fun(x + stepX, y + stepY))));
                   face.addEdge(new Line(new Point(x + stepX, y + stepY, fun(x + stepX, y + stepY)), new Point(x, y, fun(x, y))));
                   res.addFace(face);
                   face = new Face();
                   face.addEdge(new Line(new Point(x, y, fun(x, y)), new Point(x, y + stepY, fun(x, y + stepY))));
                   face.addEdge(new Line(new Point(x, y + stepY, fun(x, y + stepY)), new Point(x + stepX, y + stepY, fun(x + stepX, y + stepY))));
                   face.addEdge(new Line(new Point(x + stepX, y + stepY, fun(x + stepX, y + stepY)), new Point(x, y, fun(x, y))));
                   res.addFace(face);
               }
           }
           return res;
       }
    }
}
