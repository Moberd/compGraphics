using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    public class Vector
    {
        public double x, y, z;

        public Vector(double x, double y, double z, bool isVectorNeededToBeNormalized = false)
        {
            double normalization = isVectorNeededToBeNormalized
                ? Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2))
                : 1;
            this.x = x / normalization;
            this.y = y / normalization;
            this.z = z / normalization;
        }

        public Vector(Point p, bool isVectorNeededToBeNormalized = false) : this(p.Xf, p.Yf, p.Zf,
            isVectorNeededToBeNormalized)
        {
        }
        
        public Vector(Point start, Point end, bool isVectorNeededToBeNormalized = false) : this (end.Xf - start.Xf, end.Yf - start.Yf,end.Zf - start.Zf,isVectorNeededToBeNormalized){}

        public Vector normalize()
        {
            double normalization = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            x = x / normalization;
            y = y / normalization;
            z = z / normalization;
            return this;
        }

        public int X
        {
            get => (int) x;
            set => x = value;
        }

        public int Y
        {
            get => (int) y;
            set => y = value;
        }

        public int Z
        {
            get => (int) z;
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
            return new Vector(k * b.x, k * b.y, k * b.z);
        }
        public static double GetCos(Vector v1, Vector v2)
        {
            double scalar = v1.Xf * v2.Xf + v1.Yf * v2.Yf + v1.Zf * v2.Zf;
            double lengthv1 = Math.Sqrt(v1.Xf * v1.Xf + v1.Yf * v1.Yf + v1.Zf * v1.Zf);
            double lengthv2 = Math.Sqrt(v2.Xf * v2.Xf + v2.Yf * v2.Yf + v2.Zf * v2.Zf);
            double res = scalar / lengthv1 / lengthv2;
            return res;

        }
    }
    
}