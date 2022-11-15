using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Тип объёмной фигуры
    /// </summary>
    public enum ShapeType { TETRAHEDRON, HEXAHEDRON, OCTAHEDRON, ICOSAHEDRON, DODECAHEDRON }

    public partial class Form1
    {
        bool isAxisVisible = false;
        ShapeType currentShapeType;
        Shape currentShape;
        Graphics g;

        private void btnShowAxis_Click(object sender, EventArgs e)
        {
            isAxisVisible = !isAxisVisible;
            g.Clear(Color.White);
            if (isAxisVisible)
            {
                drawAxis();
            }
            drawShape(currentShape);
            btnShowAxis.Text = isAxisVisible ? "Скрыть точки и оси" : "Показать точки и оси";
        }
        private void buttonShape_Click(object sender, EventArgs e)
        {
            if (isInteractiveMode)
            {
                setFlags(false);
                g.Clear(Color.White);
            }
            else
            {
                currentShape = ShapeGetter.getShape(currentShapeType);
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
        /// Рисует коодинатные прямые (с подписями)
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

        /// <summary>
        /// Перерисовывает всю сцену
        /// </summary>
        void redraw()
        {
            g.Clear(Color.White);
            
            drawShape(currentShape);
            
            if (isAxisVisible)
            {
                drawAxis();
            }
        }

        
    }
}
