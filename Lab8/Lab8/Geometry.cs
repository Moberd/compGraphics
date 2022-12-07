using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public delegate void ActionRef<T>(ref T item);
    /// <summary>
    /// Тип проекции на экран
    /// </summary>
    public enum ProjectionType { ISOMETRIC, PERSPECTIVE, TRIMETRIC, DIMETRIC, PARALLEL, CAVALIER }
    public class Point2d
    {
        double x, y;
        public Point2d(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
    }
    /// <summary>
    /// Точка в пространстве
    /// </summary>
    public class Point
    {
        double x, y, z;
        public static ProjectionType projection = ProjectionType.TRIMETRIC;
        public static PointF worldCenter;
        static Size screenSize;
        static double zScreenNear, zScreenFar, fov;
        static Matrix isometricMatrix = new Matrix(3,3).fill(Math.Sqrt(3),0,-Math.Sqrt(3),1,2,1, Math.Sqrt(2),-Math.Sqrt(2), Math.Sqrt(2)) * (1/ Math.Sqrt(6));
        static Matrix trimetricMatrix = new Matrix(4, 4).fill(Math.Sqrt(3)/2, Math.Sqrt(2)/4, 0, 1, 0, Math.Sqrt(2)/2, 0, 1, 0.5,-Math.Sqrt(6)/4,0,0,0,0,0,1);
        static Matrix dimetricMatrix = new Matrix(4, 4).fill(0.926, 0.134, 0, 0, 0, 0.935, 0, 0, 0.378, -0.327, 0, 0, 0, 0, 0, 1);
        static Matrix centralMatrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, k, 0, 0, 0, 1);
        static Matrix cavalierMatrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, Math.Cos(Math.PI / 4), Math.Cos(Math.PI / 4), 0, 0, 0, 0, 0, 1);
        static Matrix parallelProjectionMatrix, perspectiveProjectionMatrix;
        const double k = 0.001f;
        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Point objAsPart = obj as Point;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public bool Equals(Point other)
        {
            if (other == null) return false;
            return (this.X.Equals(other.X)&& this.Y.Equals(other.Y)&& this.Z.Equals(other.Z));
        }
        public static void setProjection(Size screenSize, double zScreenNear, double zScreenFar, double fov)
        {
            Point.screenSize = screenSize;
            Point.zScreenNear = zScreenNear;
            Point.zScreenFar = zScreenFar;
            Point.fov = fov;
            parallelProjectionMatrix = new Matrix(4, 4).fill(1.0 / screenSize.Width, 0, 0, 0, 0, 1.0 / screenSize.Height, 0, 0, 0, 0, -2.0 / (zScreenFar - zScreenNear), -(zScreenFar + zScreenNear) / (zScreenFar - zScreenNear), 0, 0, 0, 1);
            perspectiveProjectionMatrix = new Matrix(4,4).fill(screenSize.Height/(Math.Tan(Geometry.degreesToRadians(fov / 2)) * screenSize.Width), 0, 0, 0, 0, 1.0/Math.Tan(Geometry.degreesToRadians(fov/2)), 0, 0, 0, 0, -(zScreenFar + zScreenNear) / (zScreenFar - zScreenNear), -2 * (zScreenFar * zScreenNear) / (zScreenFar - zScreenNear), 0, 0, -1, 0);
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
            switch (projection)
            {
                case ProjectionType.PERSPECTIVE:
                    {
                        Matrix res = new Matrix(1, 4).fill(Xf, Yf, Zf, 1) * centralMatrix * (1 / (k * Zf + 1));
                        return new PointF(worldCenter.X + (float)res[0, 0], worldCenter.Y + (float)res[0, 1]);
                    }

                case ProjectionType.TRIMETRIC:
                    {
                        Matrix res = new Matrix(1, 4).fill(Yf, Zf, Xf, 1) * trimetricMatrix;
                        return new PointF(worldCenter.X + (float)res[0, 0], worldCenter.Y - (float)res[0, 1]);
                    }

                case ProjectionType.DIMETRIC:
                    {
                        Matrix res = new Matrix(1, 4).fill(Xf, Yf, Zf, 1) * dimetricMatrix;
                        return new PointF(worldCenter.X + (float)res[0, 0], worldCenter.Y + (float)res[0, 1]);
                    }
                case ProjectionType.CAVALIER:
                    {
                        Matrix res = new Matrix(1, 4).fill(Xf, Yf, Zf, 1) * cavalierMatrix;
                        return new PointF(worldCenter.X + (float)res[0, 0], worldCenter.Y + (float)res[0, 1]);
                    }

                case ProjectionType.PARALLEL:
                    return new PointF(worldCenter.X + (float)Xf, worldCenter.Y + (float)Yf);
                case ProjectionType.ISOMETRIC:
                    {
                        Matrix res = new Matrix(3, 3).fill(1, 0, 0, 0, 1, 0, 0, 0, 0) * isometricMatrix * new Matrix(3, 1).fill(Xf, Yf, Zf);
                        return new PointF(worldCenter.X + (float)res[0, 0], worldCenter.Y + (float)res[1, 0]);
                    }
                default: throw new Exception("C# сломался...");
            }
        }

        public Tuple<PointF?,double> to2D(Camera cam)
        {
            var viewCoord = cam.toCameraView(this);

            if (projection == ProjectionType.PARALLEL) {
                if (viewCoord.Zf > 0)
                {
                    return Tuple.Create<PointF?, double>(new PointF(worldCenter.X + (float)viewCoord.Xf, worldCenter.Y + (float)viewCoord.Yf), (float)this.Zf);
                }
                return null;
            }
            else if (projection == ProjectionType.PERSPECTIVE)
            {
                if(viewCoord.Zf < 0)
                {
                    return Tuple.Create<PointF?, double>(null, (float)this.Zf);
                }
                //var eyeDistance = 200;
                //Matrix res = new Matrix(1, 4).fill(viewCoord.Xf * eyeDistance / (viewCoord.Zf + eyeDistance), viewCoord.Yf * eyeDistance / (viewCoord.Zf + eyeDistance), viewCoord.Zf, 1);
                //return new PointF(worldCenter.X + (float)(res[0, 0]), worldCenter.Y + (float)(res[0, 1]));
                Matrix res = new Matrix(1, 4).fill(viewCoord.Xf, viewCoord.Yf, viewCoord.Zf, 1) * perspectiveProjectionMatrix;
                if(res[0,3] == 0)
                {
                    return Tuple.Create<PointF?, double>(null, (float)this.Zf);
                    //return new PointF(worldCenter.X + (float)res[0, 0] * worldCenter.X, worldCenter.Y + (float)res[0, 1] * worldCenter.Y);
                }
                res *= 1.0 / res[0, 3];
                res[0, 0] = Math.Clamp(res[0, 0], -1, 1);
                res[0, 1] = Math.Clamp(res[0, 1], -1, 1);
                //res[0, 2] = Math.Clamp(res[0, 2], -1, 1);
                if(res[0,2] < 0)
                {
                    return Tuple.Create<PointF?, double>(null, (float)this.Zf);
                }
                return Tuple.Create<PointF?, double>(new PointF(worldCenter.X + (float)res[0, 0] * worldCenter.X, worldCenter.Y + (float)res[0, 1] * worldCenter.Y), (float)this.Zf);
            } else
            {
                return Tuple.Create<PointF?,double>(to2D(), (float)this.Zf);
            }
            //else
            //{
            //    throw new Exception("Invalid projection type using camera");
            //}
        }
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }

        /// <summary>
        /// Отрезок в пространстве
        /// </summary>
        public class Line
    {
        public Point start,end;

        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }

        public Point getVectorCoordinates()
        {
            return new Point(end.Xf - start.Xf, end.Yf - start.Yf, end.Zf - start.Zf);
        }

        public Point getReverseVectorCoordinates()
        {
            return new Point(start.Xf - end.Xf, start.Yf - end.Yf, start.Zf - end.Zf);
        }
    }
    /// <summary>
    /// Грань фигуры, состоящая из конечного числа отрезков
    /// </summary>
    public class Face
    {
        List<Line> edges;
        Vector normVector;
        public List<Point> verticles;

        public Face()
        {
            edges = new List<Line>();
            verticles = new List<Point>();
            normVector = new Vector(0, 0, 0);
        }

        public Face(IEnumerable<Line> edges) : this()
        {
            this.edges.AddRange(edges);
        }

        public Face addEdge(Line edge)
        {
            edges.Add(edge);
            recalculateNormVector();
            return this;
        }
        public Face addEdges(IEnumerable<Line> edges)
        {
            this.edges.AddRange(edges);
            recalculateNormVector();
            return this;
        }
        public Face addVerticle(Point p)
        {
            verticles.Add(p);
            return this;
        }
        public Face addVerticles(IEnumerable<Point> points)
        {
            this.verticles.AddRange(points);
            return this;
        }

        public List<Point> Verticles { get => verticles; }
        void recalculateNormVector()
        {

        }

        public Vector NormVector { get {
                Vector a = new Vector(edges.First().getVectorCoordinates()), b = new Vector(edges.Last().getReverseVectorCoordinates());
                normVector = (b * a).normalize();
                return normVector;
            } }

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
    public class Shape
    {
        List<Face> faces;
        List<Point> verticles;
        public Shape()
        {
            faces = new List<Face>();
            verticles = new List<Point>();
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
        public Shape(IEnumerable<Point> verticles) : this()
        {
            this.verticles.AddRange(verticles);
        }

        public Shape addVerticle(Point verticle)
        {
            verticles.Add(verticle);
            return this;
        }
        public Shape addVerticles(IEnumerable<Point> verticles)
        {
            this.verticles.AddRange(verticles);
            return this;
        }

        public List<Point> Verticles { get => verticles; }

        /// <summary>
        /// Преобразует все точки в фигуре по заданной функции
        /// </summary>
        /// <param name="f">Функция, преобразующая точку фигуры</param>
        public void transformPoints(Func<Point, Point> f)
        {
            foreach (var face in Faces)
            {
                foreach (var line in face.Edges)
                {
                    line.start = f(line.start);
                    line.end = f(line.end);
                }
                face.verticles = face.verticles.Select(x => f(x)).ToList();
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
            List<Point> verts=new List<Point>() ;
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
                    case "ICOSAHEDRON":
                        res = new Icosahedron();
                        break;
                    case "DODECAHEDRON":
                        res = new Dodecahedron();
                        break;
                    case "SURFACESEGMENT":
                        res = new SurfaceSegment();
                        break;
                    case "ROTATIONSHAPE":
                        res = new RotationShape();
                        break;
                    case "OBJECT":
                        res = new ObjectShape();
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
                    verts.Add(new Point(int.Parse(startPoint[0]), int.Parse(startPoint[1]), int.Parse(startPoint[2])));
                    verts.Add(new Point(int.Parse(endPoint[0]), int.Parse(endPoint[1]), int.Parse(endPoint[2])));
                }
                List<Point> v= Distinct(verts);
                res.addFace(new Face(edgs).addVerticles(v)); // добавляем целую грань фигуры
                edgs = new List<Line>();
                verts.Clear();
                v.Clear();
                line = sr.ReadLine();
            }
            sr.Close();
            return res;
        }
        public static List<Point> Distinct<Point>(List<Point> l)
        {
            List<Point> uniq = new List<Point>();
            foreach (Point p in l)
            {
                if (!uniq.Contains(p))
                    uniq.Add(p);
            }
            return uniq;
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

        public override string ToString()
        {
            return $"{getShapeName()} ({faces.Count})";
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

    class ObjectShape : Shape
    {
        public override String getShapeName()
        {
            return "OBJECT";
        }
    }

    class Icosahedron : Shape
    {
        public override String getShapeName()
        {
            return "ICOSAHEDRON";
        }
    }

    class Dodecahedron : Shape
    {
        public override String getShapeName()
        {
            return "DODECAHEDRON";
        }
    }
    /// <summary>
    /// Класс фигур вращения
    /// </summary>

    class RotationShape : Shape
    {
        List<Point> formingline;
        Line axiz;
        int Divisions;
        List<Point> allpoints;
        List<Line> edges;
        List<Line> edges1=new List<Line>();//ребра
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

        public override String getShapeName()
        {
            return "ROTATIONSHAPE";
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
        public override String getShapeName()
        {
            return "SURFACESEGMENT";
        }
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
        public static double Cos (double angle)
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
        }/// <summary>
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
                case ShapeType.ICOSAHEDRON: return getIcosahedron();
                case ShapeType.DODECAHEDRON: return getDodecahedron();


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
            res.addFace(new Face().addEdge(new Line(a, c)).addEdge(new Line(c, f)).addEdge(new Line(f, a))); // ok
            res.addFace(new Face().addEdge(new Line(f, c)).addEdge(new Line(c, h)).addEdge(new Line(h, f))); // ok
            res.addFace(new Face().addEdge(new Line(a, h)).addEdge(new Line(h, c)).addEdge(new Line(c, a))); // ok
            res.addFace(new Face().addEdge(new Line(f, h)).addEdge(new Line(h, a)).addEdge(new Line(a, f))); // ok
            return res;
        }

        /// <summary>
        /// Получение октаэдра
        /// </summary>
        /// <returns></returns>
        public static Octahedron getOctahedron()
        {
            Octahedron res = new Octahedron();
            //Point a = new Point(100, 100, 0);
            //Point b = new Point(200, 100, 100);
            //Point c = new Point(100, 100, 200);
            //Point d = new Point(0, 100, 100);
            //Point e = new Point(100, 200, 100);
            //Point f = new Point(100, 0, 100);
            var cube = getHexahedron();
            Point a = cube.Faces[0].getCenter();
            Point b = cube.Faces[1].getCenter();
            Point c = cube.Faces[2].getCenter();
            Point d = cube.Faces[3].getCenter();
            Point e = cube.Faces[4].getCenter();
            Point f = cube.Faces[5].getCenter();
            res.addVerticles(new List<Point> { a,b, c, d,e,f });
            res.addFace(new Face().addEdge(new Line(a, f)).addEdge(new Line(f, b)).addEdge(new Line(b, a))); // ok
            res.addFace(new Face().addEdge(new Line(b, f)).addEdge(new Line(f, c)).addEdge(new Line(c, b))); // ok
            res.addFace(new Face().addEdge(new Line(c, f)).addEdge(new Line(f, d)).addEdge(new Line(d, c))); // ok
            res.addFace(new Face().addEdge(new Line(d, f)).addEdge(new Line(f, a)).addEdge(new Line(a, d))); // ok
            res.addFace(new Face().addEdge(new Line(a, b)).addEdge(new Line(b, e)).addEdge(new Line(e, a))); // ok
            res.addFace(new Face().addEdge(new Line(b, c)).addEdge(new Line(c, e)).addEdge(new Line(e, b))); // ok
            res.addFace(new Face().addEdge(new Line(c, d)).addEdge(new Line(d, e)).addEdge(new Line(e, c))); // ok
            res.addFace(new Face().addEdge(new Line(d, a)).addEdge(new Line(a, e)).addEdge(new Line(e, d))); // ok
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
            res.addFace(new Face().addEdge(new Line(a, d)).addEdge(new Line(d, c)).addEdge(new Line(c, b)).addEdge(new Line(b, a)));
            res.addFace(new Face().addEdge(new Line(b, c)).addEdge(new Line(c, g)).addEdge(new Line(g, f)).addEdge(new Line(f, b)));
            res.addFace(new Face().addEdge(new Line(f, g)).addEdge(new Line(g, h)).addEdge(new Line(h, e)).addEdge(new Line(e, f)));
            res.addFace(new Face().addEdge(new Line(h, d)).addEdge(new Line(d, a)).addEdge(new Line(a, e)).addEdge(new Line(e, h)));
            res.addFace(new Face().addEdge(new Line(a, b)).addEdge(new Line(b, f)).addEdge(new Line(f, e)).addEdge(new Line(e, a)));
            res.addFace(new Face().addEdge(new Line(d, h)).addEdge(new Line(h, g)).addEdge(new Line(g, c)).addEdge(new Line(c, d)));
            return res;
        }

        /// <summary>
        /// Получение икосаэдра
        /// </summary>
        /// <returns></returns>
        public static Icosahedron getIcosahedron()
        {
            Icosahedron res = new Icosahedron();
            Point circleCenter = new Point(100, 100, 100);
            List<Point> circlePoints = new List<Point>();
            for(int angle = 0; angle < 360; angle += 36)
            {
                if( angle % 72 == 0)
                {
                    circlePoints.Add(new Point(circleCenter.X + (100 * Math.Cos(Geometry.degreesToRadians(angle))), circleCenter.Y + 100, circleCenter.Z + (100 * Math.Sin(Geometry.degreesToRadians(angle)))));
                    continue;
                }
                circlePoints.Add(new Point(circleCenter.X + (100 * Math.Cos(Geometry.degreesToRadians(angle))), circleCenter.Y, circleCenter.Z + (100 * Math.Sin(Geometry.degreesToRadians(angle)))));
            }
            Point a = new Point(100, 50, 100);
            Point b = new Point(100, 250, 100);
            for(int i = 0; i < 10; i++)
            {
                res.addFace(new Face().addEdge(new Line(circlePoints[i], circlePoints[(i + 1) % 10])).addEdge(new Line(circlePoints[(i + 1) % 10], circlePoints[(i + 2) % 10])).addEdge(new Line(circlePoints[(i+2) % 10], circlePoints[i])).addVerticles(new List<Point> { circlePoints[i], circlePoints[(i + 1) % 10], circlePoints[(i + 2) % 10] }));
            }
            res.addFace(new Face().addEdge(new Line(circlePoints[1], a)).addEdge(new Line(a, circlePoints[3])).addEdge(new Line(circlePoints[3], circlePoints[1])).addVerticles(new List<Point> { circlePoints[1], a, circlePoints[3] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[3], a)).addEdge(new Line(a, circlePoints[5])).addEdge(new Line(circlePoints[5], circlePoints[3])).addVerticles(new List<Point> { circlePoints[3], a, circlePoints[5] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[5], a)).addEdge(new Line(a, circlePoints[7])).addEdge(new Line(circlePoints[7], circlePoints[5])).addVerticles(new List<Point> { circlePoints[5], a , circlePoints[7] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[7], a)).addEdge(new Line(a, circlePoints[9])).addEdge(new Line(circlePoints[9], circlePoints[7])).addVerticles(new List<Point> {  circlePoints[7],a, circlePoints[9] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[9], a)).addEdge(new Line(a, circlePoints[1])).addEdge(new Line(circlePoints[1], circlePoints[9])).addVerticles(new List<Point> { circlePoints[9], a, circlePoints[1] }));

            res.addFace(new Face().addEdge(new Line(circlePoints[0], b)).addEdge(new Line(b, circlePoints[2])).addEdge(new Line(circlePoints[2], circlePoints[0])).addVerticles(new List<Point> { circlePoints[0], b, circlePoints[2] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[2], b)).addEdge(new Line(b, circlePoints[4])).addEdge(new Line(circlePoints[4], circlePoints[2])).addVerticles(new List<Point> { circlePoints[2], b, circlePoints[4] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[4], b)).addEdge(new Line(b, circlePoints[6])).addEdge(new Line(circlePoints[6], circlePoints[4])).addVerticles(new List<Point> { circlePoints[4], b, circlePoints[6] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[6], b)).addEdge(new Line(b, circlePoints[8])).addEdge(new Line(circlePoints[8], circlePoints[6])).addVerticles(new List<Point> { circlePoints[6], b, circlePoints[8] }));
            res.addFace(new Face().addEdge(new Line(circlePoints[8], b)).addEdge(new Line(b, circlePoints[0])).addEdge(new Line(circlePoints[0], circlePoints[8])).addVerticles(new List<Point> { circlePoints[8], b, circlePoints[0] }));
            return res;
        }

        /// <summary>
        /// Получение додекаэдра
        /// </summary>
        /// <returns></returns>
        public static Dodecahedron getDodecahedron()
        {
            Dodecahedron res = new Dodecahedron();
            var icosahedron = getIcosahedron();
            List<Point> centers = new List<Point>();
            for (int i = 0; i < icosahedron.Faces.Count; i++)
            {
                Face face = icosahedron.Faces[i];
                var c = face.getCenter();
                centers.Add(c);
            }

            //res.addFace(new Face().addEdge(new Line(centers[9], centers[0])).addEdge(new Line(centers[0], centers[1])).addEdge(new Line(centers[1], centers[10])).addEdge(new Line(centers[10], centers[14])).addEdge(new Line(centers[14], centers[9])));
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    res.addFace(new Face().addEdge(new Line(centers[i], centers[(i + 1) % 10])).addEdge(new Line(centers[(i + 1) % 10], centers[(i + 2) % 10])).addEdge(new Line(centers[(i + 2) % 10], centers[15 + (i / 2 + 1) % 5])).addEdge(new Line(centers[15 + (i / 2 + 1) % 5], centers[15 + i / 2])).addEdge(new Line(centers[15 + i/ 2], centers[i])).addVerticles(new List<Point> { centers[i], centers[(i + 1) % 10], centers[(i + 2) % 10], centers[15 + (i / 2 + 1) % 5], centers[15 + i / 2] }));

                    continue;
                }
                res.addFace(new Face().addEdge(new Line(centers[i], centers[(i + 1) % 10])).addEdge(new Line(centers[(i + 1) % 10], centers[(i + 2) % 10])).addEdge(new Line(centers[(i + 2) % 10], centers[10 + (i / 2 + 1) % 5])).addEdge(new Line(centers[10 + (i / 2 + 1) % 5], centers[10 + i / 2])).addEdge(new Line(centers[10 + i / 2], centers[i]))).addVerticles(new List<Point> { centers[i], centers[(i + 1) % 10], centers[(i + 2) % 10], centers[10 + (i / 2 + 1) % 5], centers[10 + i / 2]});
            }
            res.addFace(new Face().addEdge(new Line(centers[15], centers[16])).addEdge(new Line(centers[16], centers[17])).addEdge(new Line(centers[17], centers[18])).addEdge(new Line(centers[18], centers[19])).addEdge(new Line(centers[19], centers[15])).addVerticles(new List<Point> { centers[15], centers[16] , centers[17], centers[18] , centers[19]}));
            res.addFace(new Face().addEdge(new Line(centers[10], centers[11])).addEdge(new Line(centers[11], centers[12])).addEdge(new Line(centers[12], centers[13])).addEdge(new Line(centers[13], centers[14])).addEdge(new Line(centers[14], centers[10])).addVerticles(new List<Point> { centers[10], centers[11], centers[12], centers[13], centers[14] }));

            return res;
        }

        ///
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
            List<Line> edges1=new List<Line>();//дно и верхушка
            List<Line> edges2 = new List<Line>();//
            List<Point> v = new List<Point>();
            List<Point> v1 = new List<Point>();
            res.addPoints(genline);//добавили образующую
            for (int i = 1; i < divisions; i++)//количество разбиений
            {
                res.addPoints(Geometry.RotatePoint(genline, axis, angle * i));
            }
            //

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
                            //res.addFace(new Face().addEdge(new Line(res.Points[index], res.Points[index + 1])).addEdge(new Line(res.Points[index + 1], res.Points[e1])).addEdge(new Line(res.Points[e1], res.Points[e])).addEdge(new Line(res.Points[e], res.Points[index])).addVerticles(new List<Point> { res.Points[index], res.Points[index + 1], res.Points[e1], res.Points[e] }));
                            res.addFace(new Face().addEdge(new Line(res.Points[e], res.Points[e1])).addEdge(new Line(res.Points[e1], res.Points[index + 1])).addEdge(new Line(res.Points[index + 1], res.Points[index])).addEdge(new Line(res.Points[index], res.Points[e])).addVerticles(new List<Point> { res.Points[index], res.Points[index + 1], res.Points[e1], res.Points[e] }));
                            edges1.Add(new Line(res.Points[index], res.Points[e1]));//res.Points[index], res.Points[e1])
                            v.AddRange(new List<Point> { res.Points[index], res.Points[e1] });
                            edges2.Add(new Line(res.Points[index + 1], res.Points[e]));//res.Points[index+1], res.Points[e]
                            v1.AddRange(new List<Point> { res.Points[index+1], res.Points[e] });
                        }

                    }

                }


            }
            res.addFace(new Face().addEdges(edges1).addVerticles(v));
            res.addFace(new Face().addEdges(edges2).addVerticles(v1));
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
                    face.addEdge(new Line(new Point(x + stepX, y + stepY, fun(x + stepX, y + stepY)), new Point(x, y + stepY, fun(x, y + stepY))));
                    face.addEdge(new Line(new Point(x, y + stepY, fun(x, y + stepY)), new Point(x, y, fun(x, y))));
                    res.addFace(face);
                }
            }
            return res;
        }
    }

    public class Vector
    {
        public double x, y, z;
        public Vector(double x, double y, double z, bool isVectorNeededToBeNormalized = false)
        {
            double normalization = isVectorNeededToBeNormalized ? Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)) : 1;
            this.x = x / normalization;
            this.y = y / normalization;
            this.z = z / normalization;
        }

        public Vector(Point p, bool isVectorNeededToBeNormalized = false) : this(p.Xf,p.Yf,p.Zf,isVectorNeededToBeNormalized)
        {

        }

        public Vector normalize()
        {
            double normalization = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            x = x / normalization;
            y = y / normalization;
            z = z / normalization;
            return this;
        }

        public int X { get => (int)x; set => x = value; }
        public int Y { get => (int)y; set => y = value; }
        public int Z { get => (int)z; set => z = value; }

        public double Xf { get => x; set => x = value; }
        public double Yf { get => y; set => y = value; }
        public double Zf { get => z; set => z = value; }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static Vector operator *(double k, Vector b)
        {
            return new Vector(k*b.x,k*b.y,k*b.z);
        }
    }
}
