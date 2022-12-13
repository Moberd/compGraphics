using GraphicsHelper;

namespace AdvancedGraphics.CoolStuff
{
    public class LightSource
    {
        Point position;

        public LightSource(Point position)
        {
            this.position = position;
        }

        public Point Position => position;

        public void move(double shiftX = 0, double shiftY = 0, double shiftZ = 0)
        {
            position.Xf += shiftX;
            position.Yf += shiftY;
            position.Zf += shiftZ;
        }
    }
}