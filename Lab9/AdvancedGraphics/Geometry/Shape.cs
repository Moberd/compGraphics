using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    /// <summary>
    /// Объёмная фигура, состоящая из граней
    /// </summary>
    public class Shape
    {
        List<Face> faces;
        private const int objScaleFactor = 10;
        private Color shapeColor;
        

        public Shape()
        {
            Random rnd = new Random();
            shapeColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            faces = new List<Face>();
        }
        
        public Shape(Color color)
        {
            shapeColor = color;
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

        public List<Face> Faces
        {
            get => faces;
        }
        public Color GetColor
        {
            get => shapeColor;
        }
        public void SetColor(Color c)
        {
            this.shapeColor=c;
        }


        /// <summary>
        /// Преобразует все точки в фигуре по заданной функции
        /// </summary>
        /// <param name="f">Функция, преобразующая точку фигуры</param>
        public void transformPoints(Func<Vertex, Vertex> f)
        {
            foreach (var face in Faces)
            {
                face.transformPoints(f);
            }
        }

        // читает модель многогранника из файла
        public static Shape readShape(string fileName)
        {
            Shape res = new Shape();
            List<Point> vertices = new List<Point>();
            List<TexturePoint> textureVertices = new List<TexturePoint>();
            List<Vector> normales = new List<Vector>();
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                var data = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if(data.Count() == 0)
                {
                    continue;
                }
                if (data[0] == "v")
                {
                    vertices.Add(new Point(double.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat) * objScaleFactor,
                        double.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat) * objScaleFactor, double.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat) * objScaleFactor));
                }

                if (data[0] == "vt")
                {
                    textureVertices.Add(new TexturePoint(double.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat), double.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat)));
                }

                if (data[0] == "vn")
                {
                    normales.Add(new Vector(double.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat), double.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat), double.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat)));
                }

                if (data[0] == "f")
                {
                    var face = new Face();
                    for (int i = 1; i < data.Length; i++)
                    {
                        var stringVertex = data[i].Split("/");
                        if (stringVertex.Count() < 3)
                        {
                            break;
                        }
                        face.addVertex(new Vertex(vertices[int.Parse(stringVertex[0]) - 1],
                            normales[int.Parse(stringVertex[2]) - 1], textureVertices[int.Parse(stringVertex[1]) - 1]));
                    }

                   // if (!face.isLine())
                   // {
                        res.addFace(face);
                    //}
                }
            }

            return res;
        }

        public override string ToString()
        {
            return $"Object ({faces.Count})";
        }
    }
}