using GraphicsHelper;

namespace AdvancedGraphics
{
    public enum Visibilty
    {
        INVISIBLE,
        VISIBLE_UP,
        VISIBLE_DOWN
    };
    public class FloatingPoint : Point
    {
        public Visibilty Visibility { get; }

        public FloatingPoint(double x, double y, double z, Visibilty visibility) : base(x, y, z)
        {
            Visibility = visibility;
        }

        public FloatingPoint(double x, double y, double z, ref double[] upHorizon, ref double[] downHorizon) :
            base(x, y, z)
        {
            if (y >= upHorizon[(int) x])
            {
                Visibility = Visibilty.VISIBLE_UP;
                return;
            }

            if (y <= downHorizon[(int) x])
            {
                Visibility = Visibilty.VISIBLE_DOWN;
                return;
            }

            Visibility = Visibilty.INVISIBLE;
        }
    }

    public class ReducedFloatingPoint : FloatingPoint
    {
        public ReducedFloatingPoint(double x, double y) : base(x, y, 0, Visibilty.INVISIBLE)
        {
        }
    }
}