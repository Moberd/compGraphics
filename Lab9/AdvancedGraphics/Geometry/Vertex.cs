namespace GraphicsHelper
{
    public class Vertex : Point
    {
        public TexturePoint texturePoint;
        public Vector normVector;
       // public double lightness;//для интенсивности освещения
        
        public Vertex(int x, int y, int z,double lightness=1.0) : base(x, y, z,lightness) { }

        public Vertex(double x, double y, double z, double lightness = 1.0, double u = 0, double v = 0) : base(x, y, z,lightness) {
            texturePoint = new TexturePoint(u, v);
        }
        
        public Vertex(double x, double y, double z, TexturePoint texturePoint) : base(x, y, z,0) {
            this.texturePoint = texturePoint;
        }

        public Vertex(Point p) : base(p) { }

        public Vertex(Point p, Vector normVector, TexturePoint texturePoint) : base(p)
        {
            this.normVector = normVector;
            this.texturePoint = texturePoint;
         
        }
    }
}