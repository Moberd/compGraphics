using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    public class TexturePoint
    {
        private double u, v;

        public TexturePoint(double u, double v)
        {
            this.u = u;
            this.v = v;
        }

        public double U => u;

        public double V => v;
        
        public static TexturePoint operator +(TexturePoint tp1, TexturePoint tp2)
        {
            return new TexturePoint(tp1.u + tp2.u,tp1.v + tp2.v);
        }
        
        public static TexturePoint operator -(TexturePoint tp1, TexturePoint tp2)
        {
            return new TexturePoint(tp1.u - tp2.u,tp1.v - tp2.v);
        }
        
        public static TexturePoint operator /(TexturePoint tp1, double d)
        {
            return new TexturePoint(tp1.u / d,tp1.v / d);
        }
    }
}