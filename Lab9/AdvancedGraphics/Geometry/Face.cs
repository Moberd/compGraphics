using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    /// <summary>
    /// Грань фигуры, состоящая из конечного числа отрезков
    /// </summary>
    public class Face
    {
        Vector normVector;
        List<Vertex> vertices;
        public bool isFacial = true;

        public Face()
        {
            vertices = new List<Vertex>();
            normVector = new Vector(0, 0, 0);
        }

        public Face(IEnumerable<Vertex> vertices) : this()
        {
            this.vertices.AddRange(vertices);
        }

        public Face addVertex(Vertex newPoint)
        {
            vertices.Add(newPoint);
            return this;
        }

        public Face addVertices(IEnumerable<Vertex> points)
        {
            this.vertices.AddRange(points);
            return this;
        }
        
        public List<Vertex> Vertices
        {
            get => vertices;
        }
        public Vector NormVector
        {
            get
            {
                Vector vect1 = new Vector(vertices.First(),vertices[1]);
                Vector vect2 = new Vector(vertices.First(),vertices.Last());
                normVector = vect2 * vect1;
                return normVector;
            }
        }

        public void transformPoints(Func<Vertex,Vertex> f)
        {
            vertices = vertices.Select(f).ToList();
        }

        /// <summary>
        /// Получение центра тяжести грани
        /// </summary>
        /// <returns><c>Point</c> - центр тяжести</returns>
        public Point getCenter()
        {
            double x = 0, y = 0, z = 0;
            foreach (var point in vertices)
            {
                x += point.Xf;
                y += point.Yf;
                z += point.Zf;
            }

            return new Point(x / vertices.Count, y / vertices.Count, z / vertices.Count);
        }

        public bool isLine()
        {
            for (int j = 0; j < Vertices.Count; j++)
            {
                var dist = Geometry.distance(Vertices[j], Vertices[(j + 1) % Vertices.Count]);
                if (Geometry.distance(Vertices[j], Vertices[(j + 1) % Vertices.Count]) < 0.1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}