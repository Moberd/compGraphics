using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    /// <summary>
    /// Тип объёмной фигуры
    /// </summary>
    public enum ShapeType { TETRAHEDRON, HEXAHEDRON, OCTAHEDRON, ICOSAHEDRON, DODECAHEDRON, ROTATION_SHAPE}

    public partial class Form1
    {
        bool isAxisVisible = false;
        bool arePointsVisible = false;
        ShapeType currentShapeType;
        Shape currentShape;
        Graphics g;

        private void btnShowAxis_Click(object sender, EventArgs e)
        {
            isAxisVisible = !isAxisVisible;
            redraw();
            btnShowAxis.Text = isAxisVisible ? "Скрыть оси" : "Показать оси";
        }

        private void btnShowPoints_Click(object sender, EventArgs e)
        {
            arePointsVisible = !arePointsVisible;
            redraw();
            btnShowPoints.Text = arePointsVisible ? "Скрыть точки" : "Показать точки";
        }
        private void buttonShape_Click(object sender, EventArgs e)
        {
            if (isInteractiveMode)
            {
                setFlags(false);
                g.Clear(Color.White);
                RotationShapePoints.Clear();
            }
            else
            {
                if (tabControl.SelectedIndex == 0)
                {
                    currentShape = ShapeGetter.getShape(currentShapeType);
                }
                else
                {
                    if (tabControl.SelectedIndex == 1)
                    {
                        currentShape = ShapeGetter.getSurfaceSegment(currentFun, int.Parse(etX0.Text), int.Parse(etX1.Text), int.Parse(etY0.Text), int.Parse(etY1.Text), int.Parse(etSplit.Text));
                    }
                    else
                    {
                        Div = int.Parse(getDiv.Text);
                        currentShape = ShapeGetter.getRotationShape(RotationShapePoints, Div, AxisforRotate);
                    }
                }
                
                redraw();
                setFlags(true);
            }
            
        }

        /// <summary>
        /// Рисует фигуры на канвасе, выделяя цветом некоторые грани у додекаэдра и икосаэра
        /// </summary>
        /// <param name="shape">Фигура, которую надо нарисовать</param>
        void drawShape(Shape shape)
        {
            foreach (var face in shape.Faces)
            {
                Pen pen = new Pen(Color.Black, 3);
                drawFace(face,pen);
            }
        }

        /// <summary>
        /// Рисует заданную границу грани заданным цветом
        /// </summary>
        /// <param name="face">Грань, которую надо нарисовать</param>
        /// <param name="pen">Цвет границы</param>
        void drawFace(Face face, Pen pen)
        {
            foreach(var line in face.Edges)
            {
                drawLine(line, pen);
            }
        }

        /// <summary>
        /// Рисует линию, переводя её координаты из 3D в 2D
        /// </summary>
        /// <param name="line">Линия, которую надо нарисовать</param>
        /// <param name="pen">Цвет линии</param>
        void drawLine(Line line, Pen pen)
        {
            g.DrawLine(pen, line.Start.to2D(), line.End.to2D());
        }

        /// <summary>
        /// Рисует коодинатные прямые (с подписями) и подписывает координаты каждой точки
        /// </summary>
        void drawAxis()
        {
            Line axisX = new Line(new Point(0, 0, 0), new Point(300, 0, 0));
            Line axisY = new Line(new Point(0, 0, 0), new Point(0, 300, 0));
            Line axisZ = new Line(new Point(0, 0, 0), new Point(0, 0, 300));
            drawLine(axisX, new Pen(Color.Red, 4));
            drawLine(axisY, new Pen(Color.Blue, 4));
            drawLine(axisZ, new Pen(Color.Green, 4));
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -(float)canvas.Height);
            g.DrawString($" X", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Red), axisX.End.to2D().X, canvas.Height - axisX.End.to2D().Y);
            g.DrawString($" Y", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Blue), axisY.End.to2D().X, canvas.Height - axisY.End.to2D().Y);
            g.DrawString($" Z", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Green), axisZ.End.to2D().X, canvas.Height - axisZ.End.to2D().Y);
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -(float)canvas.Height);
        }

        void drawPoints()
        {
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -(float)canvas.Height);
            foreach (var face in currentShape.Faces)
            {
                foreach (var line in face.Edges)
                {
                    g.DrawString($" ({line.Start.X}, {line.Start.Y}, {line.Start.Z})", new Font("Arial", 8, FontStyle.Italic), new SolidBrush(Color.DarkBlue), line.Start.to2D().X, canvas.Height - line.Start.to2D().Y);
                    g.DrawString($" ({line.End.X}, {line.End.Y}, {line.End.Z})", new Font("Arial", 8, FontStyle.Italic), new SolidBrush(Color.DarkBlue), line.End.to2D().X, canvas.Height - line.End.to2D().Y);
                }
            }
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -(float)canvas.Height);
        }

        /// <summary>
        /// Перерисовывает всю сцену
        /// </summary>
        void redraw()
        {
            g.Clear(Color.White);
            
            if (isAxisVisible)
            {
                drawAxis();
            }
            if (arePointsVisible)
            {
                drawPoints();
            }

            drawShape(currentShape);
        }
    }
}
