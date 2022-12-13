using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    /// <summary>
    /// Точка в пространстве
    /// </summary>
    public class Point
    {
        double x, y, z;
        public double lightness;//для интенсивности освещения
        public static ProjectionType projection = ProjectionType.PERSPECTIVE;
        public static PointF worldCenter;
        static Size screenSize;
        static double zScreenNear, zScreenFar, fov;

        static Matrix isometricMatrix =
            new Matrix(3, 3).fill(Math.Sqrt(3), 0, -Math.Sqrt(3), 1, 2, 1, Math.Sqrt(2), -Math.Sqrt(2), Math.Sqrt(2)) *
            (1 / Math.Sqrt(6));

        static Matrix trimetricMatrix = new Matrix(4, 4).fill(Math.Sqrt(3) / 2, Math.Sqrt(2) / 4, 0, 1, 0,
            Math.Sqrt(2) / 2, 0, 1, 0.5, -Math.Sqrt(6) / 4, 0, 0, 0, 0, 0, 1);

        static Matrix dimetricMatrix =
            new Matrix(4, 4).fill(0.926, 0.134, 0, 0, 0, 0.935, 0, 0, 0.378, -0.327, 0, 0, 0, 0, 0, 1);

        static Matrix centralMatrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, k, 0, 0, 0, 1);
        static Matrix parallelProjectionMatrix, perspectiveProjectionMatrix;
        const double k = 0.001f;

        public Point(int x, int y, int z,double light=1.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.lightness = light;
        }

        public Point(Point point) : this(point.x,point.y,point.z,point.lightness) { }

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
            return (this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z));
        }

        public static void setProjection(Size screenSize, double zScreenNear, double zScreenFar, double fov)
        {
            Point.screenSize = screenSize;
            Point.zScreenNear = zScreenNear;
            Point.zScreenFar = zScreenFar;
            Point.fov = fov;
            parallelProjectionMatrix = new Matrix(4, 4).fill(1.0 / screenSize.Width, 0, 0, 0, 0,
                1.0 / screenSize.Height, 0, 0, 0, 0, -2.0 / (zScreenFar - zScreenNear),
                -(zScreenFar + zScreenNear) / (zScreenFar - zScreenNear), 0, 0, 0, 1);
            perspectiveProjectionMatrix = new Matrix(4, 4).fill(
                screenSize.Height / (Math.Tan(Geometry.degreesToRadians(fov / 2)) * screenSize.Width), 0, 0, 0, 0,
                1.0 / Math.Tan(Geometry.degreesToRadians(fov / 2)), 0, 0, 0, 0,
                -(zScreenFar + zScreenNear) / (zScreenFar - zScreenNear),
                -2 * (zScreenFar * zScreenNear) / (zScreenFar - zScreenNear), 0, 0, -1, 0);
        }

        public Point(double x, double y, double z,double light=1.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.lightness = light;
        }

        public int X
        {
            get => (int) Math.Round(x);
            set => x = value;
        }

        public int Y
        {
            get => (int) Math.Round(y);
            set => y = value;
        }

        public int Z
        {
            get => (int) Math.Round(z);
            set => z = value;
        }

        public double Xf
        {
            get => x;
            set => x = value;
        }

        public double Yf
        {
            get => y;
            set => y = value;
        }

        public double Zf
        {
            get => z;
            set => z = value;
        }
        public double light
        {
            get => lightness;
                
            set => lightness = value;
        }

        /// <summary>
        /// Перевод точки из 3D в 2D
        /// </summary>
        /// <returns>Точку на экране в вещестаенных координатах</returns>
        public PointF to2D()
        {
            switch (projection)
            {
                case ProjectionType.PERSPECTIVE:
                {
                    Matrix res = new Matrix(1, 4).fill(Xf, Yf, Zf, 1) * centralMatrix * (1 / (k * Zf + 1));
                    return new PointF(worldCenter.X + (float) res[0, 0], worldCenter.Y + (float) res[0, 1]);
                }

                case ProjectionType.TRIMETRIC:
                {
                    Matrix res = new Matrix(1, 4).fill(Yf, Zf, Xf, 1) * trimetricMatrix;
                    return new PointF(worldCenter.X + (float) res[0, 0], worldCenter.Y - (float) res[0, 1]);
                }

                case ProjectionType.DIMETRIC:
                {
                    Matrix res = new Matrix(1, 4).fill(Xf, Yf, Zf, 1) * dimetricMatrix;
                    return new PointF(worldCenter.X + (float) res[0, 0], worldCenter.Y + (float) res[0, 1]);
                }

                case ProjectionType.PARALLEL:
                    return new PointF(worldCenter.X + (float) Xf, worldCenter.Y + (float) Yf);
                case ProjectionType.ISOMETRIC:
                {
                    Matrix res = new Matrix(3, 3).fill(1, 0, 0, 0, 1, 0, 0, 0, 0) * isometricMatrix *
                                 new Matrix(3, 1).fill(Xf, Yf, Zf);
                    return new PointF(worldCenter.X + (float) res[0, 0], worldCenter.Y + (float) res[1, 0]);
                }
                default: throw new Exception("C# сломался...");
            }
        }

        public System.Drawing.Point toSimple2D()
        {
            return new System.Drawing.Point(Math.Clamp(X,0,screenSize.Width - 1), Math.Clamp((int) (worldCenter.Y - Yf),0,screenSize.Height -1));
        }

        public Tuple<PointF?, double> to2D(Camera cam)
        {
            var viewCoord = cam.toCameraView(this);

            if (projection == ProjectionType.PARALLEL)
            {
                if (viewCoord.Zf > 0)
                {
                    return Tuple.Create<PointF?, double>(
                        new PointF(worldCenter.X + (float) viewCoord.Xf, worldCenter.Y + (float) viewCoord.Yf),
                        (float) viewCoord.Zf);
                }

                return null;
            }

            if (projection == ProjectionType.PERSPECTIVE)
            {
                if (viewCoord.Zf < 0)
                {
                    return Tuple.Create<PointF?, double>(null, (float) viewCoord.Zf);
                }

                //var eyeDistance = 200;
                //Matrix res = new Matrix(1, 4).fill(viewCoord.Xf * eyeDistance / (viewCoord.Zf + eyeDistance), viewCoord.Yf * eyeDistance / (viewCoord.Zf + eyeDistance), viewCoord.Zf, 1);
                //return new PointF(worldCenter.X + (float)(res[0, 0]), worldCenter.Y + (float)(res[0, 1]));
                Matrix res = new Matrix(1, 4).fill(viewCoord.Xf, viewCoord.Yf, viewCoord.Zf, 1) *
                             perspectiveProjectionMatrix;
                if (res[0, 3] == 0)
                {
                    return Tuple.Create<PointF?, double>(null, (float) viewCoord.Zf);
                    //return new PointF(worldCenter.X + (float)res[0, 0] * worldCenter.X, worldCenter.Y + (float)res[0, 1] * worldCenter.Y);
                }

                res *= 1.0 / res[0, 3];
                res[0, 0] = Math.Clamp(res[0, 0], -1, 1);
                res[0, 1] = Math.Clamp(res[0, 1], -1, 1);
                //res[0, 2] = Math.Clamp(res[0, 2], -1, 1);
                if (res[0, 2] < 0)
                {
                    return Tuple.Create<PointF?, double>(null, (float) viewCoord.Zf);
                }

                return Tuple.Create<PointF?, double>(
                    new PointF(worldCenter.X + (float) res[0, 0] * worldCenter.X,
                        worldCenter.Y + (float) res[0, 1] * worldCenter.Y), (float) viewCoord.Zf);
            }
            return Tuple.Create<PointF?, double>(to2D(), (float) viewCoord.Zf);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}