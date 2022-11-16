using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Тип координатной прямой (для поворотов)
    /// </summary>
    public enum AxisType { X, Y, Z };

    public partial class Form1
    {
        public AxisType currentAxis;
        public AxisType currentMirrorAxis;
        public AxisType currentRollAxis;

        public bool isScaleModeWorldCenter = true;
        private void buttonScale_Click(object sender, EventArgs e)
        {
            if (isScaleModeWorldCenter)
            {
                scale(ref currentShape, int.Parse(textScaleX.Text), int.Parse(textScaleY.Text), int.Parse(textScaleZ.Text));
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
                int cx = int.Parse(textScaleX.Text);
                int cy = int.Parse(textScaleY.Text);
                int cz = int.Parse(textScaleZ.Text);
                shift(ref currentShape, -center.Xf, -center.Yf, -center.Zf);
                // scale_shift(ref currentShape, cx, cy, cz, center.X, center.Y, center.Z);
                redraw();
                scale(ref currentShape, cx, cy, cz);
                redraw();
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
        /// Растянуть фигуру на заданные коэффициенты относительно точки
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="cx">Растяжение по оси X</param>
        /// <param name="cy">Растяжение по оси Y</param>
        /// <param name="cz">Растяжение по оси Z</param>
        /// <param name="a">координата X точки</param>
        /// <param name="b">координата Y точки</param>
        /// <param name="c">координата Z точки</param>
        void scale_shift(ref Shape shape, double cx, double cy, double cz, double a, double b, double c)
        {
            Matrix scale = new Matrix(4, 4).fill(cx, 0, 0, 0, 0, cy, 0, 0, 0, 0, cz, 0, (1 - cx) * a, (1 - cy) * b, (1 - cz) * c, 1);
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
                    rotation = new Matrix(4, 4).fill(1, 0, 0, 0, 0, Math.Cos(ShapeGetter.degreesToRadians(angle)), -Math.Sin(ShapeGetter.degreesToRadians(angle)), 0, 0, Math.Sin(ShapeGetter.degreesToRadians(angle)), Math.Cos(ShapeGetter.degreesToRadians(angle)), 0, 0, 0, 0, 1);
                    break;
                case AxisType.Y:
                    rotation = new Matrix(4, 4).fill(Math.Cos(ShapeGetter.degreesToRadians(angle)), 0, Math.Sin(ShapeGetter.degreesToRadians(angle)), 0, 0, 1, 0, 0, -Math.Sin(ShapeGetter.degreesToRadians(angle)), 0, Math.Cos(ShapeGetter.degreesToRadians(angle)), 0, 0, 0, 0, 1);
                    break;
                case AxisType.Z:
                    rotation = new Matrix(4, 4).fill(Math.Cos(ShapeGetter.degreesToRadians(angle)), -Math.Sin(ShapeGetter.degreesToRadians(angle)), 0, 0, Math.Sin(ShapeGetter.degreesToRadians(angle)), Math.Cos(ShapeGetter.degreesToRadians(angle)), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }

            shape.transformPoints((ref Point p) =>
            {
                var res = rotation * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                p = new Point(res[0, 0], res[1, 0], res[2, 0]);
            });
        }

        void rotate_around_line(ref Shape shape, int angle, Point p1, Point p2)
        {
            //матрица
            Matrix rotation = new Matrix(0, 0);
            if (p2.Z < p1.Z || (p2.Z == p1.Z && p2.Y < p1.Y) ||
               (p2.Z == p1.Z && p2.Y == p1.Y) && p2.X < p1.X)
            {
                Point tmp = p1;
                p1 = p2;
                p2 = tmp;
            }
            
            Point vector = new Point(p2.Xf - p1.Xf, p2.Yf - p1.Yf, p2.Zf - p1.Zf);//прямая, вокруг которой будем вращать
            // int A = p1.Y - p2.Y;//общее уравнение прямой, проходящей через заданные точки
            //int B = p2.X - p1.X;//вектор нормали 
            //int C = p1.X * p2.Y - p2.X *p1.Y;
            double length = Math.Sqrt(vector.Xf * vector.Xf + vector.Yf * vector.Yf + vector.Zf * vector.Zf);
            double l = vector.Xf / length;
            double m = vector.Yf / length;
            double n = vector.Zf / length;
            // Point scaledvector = new Point(l, m, n);//направленный вектор
            double anglesin = Math.Sin(ShapeGetter.degreesToRadians(angle));
            double anglecos = Math.Cos(ShapeGetter.degreesToRadians(angle));
            rotation = new Matrix(4, 4).fill(l * l + anglecos * (1 - l * l), l * (1 - anglecos) * m - n * anglesin, l * (1 - anglecos) * n + m * anglesin, 0,
                                 l * (1 - anglecos) * m + n * anglesin, m * m + anglecos * (1 - m * m), m * (1 - anglecos) * n - l * anglesin, 0,
                                 l * (1 - anglecos) * n - m * anglesin, m * (1 - anglecos) * n + l * anglesin, n * n + anglecos * (1 - n * n), 0,
                                 0, 0, 0, 1);

            shape.transformPoints((ref Point p) =>
              {
                  var res = rotation * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                  p = new Point(res[0, 0], res[1, 0], res[2, 0]);
              });
        }

            // Отражение относительно выбранной координатной плоскости
            void reflectionAboutTheAxis(ref Shape shape, AxisType axis)
            {
                Matrix reflectionMatrix;
                switch (axis)
                {
                    case AxisType.X: // XY                 
                        reflectionMatrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 1);
                        break;
                    case AxisType.Y: // XZ
                        reflectionMatrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                        break;
                    case AxisType.Z: // YZ                 
                        reflectionMatrix = new Matrix(4, 4).fill(-1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                        break;
                    default:
                        throw new Exception("Зеркальные оси всё сломали :(");
                }

                // отражение фигуры
                shape.transformPoints((ref Point p) =>
                {
                    var res = reflectionMatrix * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                    p = new Point(res[0, 0], res[1, 0], res[2, 0]);
                });
            }

            // Вращение многогранника вокруг прямой проходящей через центр многогранника, параллельно выбранной координатной оси
            void rotationThroughTheCenter(ref Shape shape, AxisType axis, int angle)
            {
                double sumX = 0, sumY = 0, sumZ = 0;
                foreach (var face in shape.Faces)
                {
                    sumX += face.getCenter().Xf;
                    sumY += face.getCenter().Yf;
                    sumZ += face.getCenter().Zf;
                }

                // центр фигуры
                Point center = new Point(sumX / shape.Faces.Count(), sumY / shape.Faces.Count(), sumZ / shape.Faces.Count());

                Matrix rotationMatrix;
                // переносим в начало координат
                rotationMatrix = new Matrix(4, 4).fill(1, 0, 0, -center.Xf, 0, 1, 0, -center.Yf, 0, 0, 1, -center.Zf, 0, 0, 0, 1);
                shape.transformPoints((ref Point p) =>
                {
                    var res = rotationMatrix * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                    p = new Point(res[0, 0], res[1, 0], res[2, 0]);
                });

                // поворачиваем относительно оси
                rotate(ref shape, axis, angle);

                // возвращаем на исходное место
                rotationMatrix = new Matrix(4, 4).fill(1, 0, 0, center.Xf, 0, 1, 0, center.Yf, 0, 0, 1, center.Zf, 0, 0, 0, 1);
                shape.transformPoints((ref Point p) =>
                {
                    var res = rotationMatrix * new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);
                    p = new Point(res[0, 0], res[1, 0], res[2, 0]);
                });

            }
        }
    }
