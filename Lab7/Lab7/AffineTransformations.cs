using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab7
{

    /// <summary>
    /// Тип координатной прямой (для поворотов)
    /// </summary>
    public enum AxisType { X, Y, Z };

    public partial class Form1
    {
        public AxisType currentAxis;

        public bool isScaleModeWorldCenter = true;
        private void buttonScale_Click(object sender, EventArgs e)
        {
            if (isScaleModeWorldCenter)
            {
                scale(ref currentShape, double.Parse(textScaleX.Text.Replace('.', ',')), double.Parse(textScaleY.Text.Replace('.', ',')), double.Parse(textScaleZ.Text.Replace('.', ',')));
                redraw();
            }
            else
            {
                // TODO: scale from shape center 
                double sumX = 0, sumY = 0, sumZ = 0;
                foreach (var face in currentShape.Faces)
                {
                    sumX += face.getCenter().Xf;
                    sumY += face.getCenter().Yf;
                    sumZ += face.getCenter().Zf;
                }

                // центр фигуры
                Point center = new Point(sumX / currentShape.Faces.Count(), sumY / currentShape.Faces.Count(), sumZ / currentShape.Faces.Count());
                double cx = double.Parse(textScaleX.Text.Replace('.', ','));
                double cy = double.Parse(textScaleY.Text.Replace('.', ','));
                double cz = double.Parse(textScaleZ.Text.Replace('.', ','));
                shift(ref currentShape, -center.Xf, -center.Yf, -center.Zf);
                scale(ref currentShape, cx, cy, cz);
                shift(ref currentShape, center.Xf, center.Yf, center.Zf);
                redraw();
            }

        }
        private void buttonRotate_Click(object sender, EventArgs e)
        {
            rotate(ref currentShape, currentAxis, int.Parse(textAngle.Text));
            redraw();
        }

        private void buttonShift_Click(object sender, EventArgs e)
        {
            shift(ref currentShape, int.Parse(textShiftX.Text), int.Parse(textShiftY.Text), int.Parse(textShiftZ.Text));
            redraw();
        }


        /// <summary>
        /// Сдвинуть фигуру на заданные расстояния
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="dx">Сдвиг по оси X</param>
        /// <param name="dy">Сдвиг по оси Y</param>
        /// <param name="dz">Сдвиг по оси Z</param>
        void shift(ref Shape shape, double dx, double dy, double dz)
        {
            Matrix shift = new Matrix(4, 4).fill(1, 0, 0, dx, 0, 1, 0, dy, 0, 0, 1, dz, 0, 0, 0, 1);
            shape.transformPoints((ref Point p) =>
            {
                var res = shift * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                p = new Point(res[0, 0], res[1, 0], res[2, 0]);
            });
        }

        /// <summary>
        /// Растянуть фигуру на заданные коэффициенты
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="cx">Растяжение по оси X</param>
        /// <param name="cy">Растяжение по оси Y</param>
        /// <param name="cz">Растяжение по оси Z</param>
        void scale(ref Shape shape, double cx, double cy, double cz)
        {
            Matrix scale = new Matrix(4, 4).fill(cx, 0, 0, 0, 0, cy, 0, 0, 0, 0, cz, 0, 0, 0, 0, 1);
            shape.transformPoints((ref Point p) =>
            {
                var res = scale * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                p = new Point(res[0, 0], res[1, 0], res[2, 0]);
            });
        }

        /// <summary>
        /// Повернуть фигуру на заданный угол вокруг заданной оси
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="type">Ось, вокруг которой поворачиваем</param>
        /// <param name="angle">Угол поворота в градусах</param>
        void rotate(ref Shape shape, AxisType type, int angle)
        {
            Matrix rotation = new Matrix(0, 0);

            switch (type)
            {
                case AxisType.X:
                    rotation = new Matrix(4, 4).fill(1, 0, 0, 0, 0, Geometry.Cos(angle), -Geometry.Sin(angle), 0, 0, Geometry.Sin(angle), Geometry.Cos(angle), 0, 0, 0, 0, 1);
                    break;
                case AxisType.Y:
                    rotation = new Matrix(4, 4).fill(Geometry.Cos(angle), 0, Geometry.Sin(angle), 0, 0, 1, 0, 0, -Geometry.Sin(angle), 0, Geometry.Cos(angle), 0, 0, 0, 0, 1);
                    break;
                case AxisType.Z:
                    rotation = new Matrix(4, 4).fill(Geometry.Cos(angle), -Geometry.Sin(angle), 0, 0, Geometry.Sin(angle), Geometry.Cos(angle), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }

            shape.transformPoints((ref Point p) =>
            {
                var res = rotation * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                p = new Point(res[0, 0], res[1, 0], res[2, 0]);
            });
        }
    }
}
