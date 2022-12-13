using GraphicsHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = GraphicsHelper.Point;

namespace AdvancedGraphics
{
    public partial class Form1
    {
        public void recalculateNonFacial()
        {
            foreach (var shape in scene)
            {
                foreach (Face face in shape.Faces) // для каждой грани фигуры
                {
                    // if (face.isLine())
                    // {
                    //     face.isFacial = false;
                    //     continue;
                    // }

                    Vector vectProec = new Vector(camera.toCameraView(face.getCenter())).normalize();

                    /* вариант 2 */
                    Vector vectNormal = face.NormVector;
                    vectNormal = new Vector(camera.toCameraView(new Point(vectNormal.Xf, vectNormal.Yf, vectNormal.Zf)))
                        .normalize();
                    double vectScalar = vectNormal.Xf * vectProec.Xf + vectNormal.Yf * vectProec.Yf +
                                        vectNormal.Zf * vectProec.Zf; // скалярное произведение

                    face.isFacial = vectScalar > 0;
                }
            }
        }
    }
}