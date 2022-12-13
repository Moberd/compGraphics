using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedGraphics
{
    using FastBitmap;

    using GraphicsHelper;

    public partial class Form1
    {
        bool isAxisVisible = false;
        Pen blackPen = new Pen(Color.Black, 3);
        Pen highlightPen = new Pen(Color.DarkRed, 3);
        FastBitmap fbitmap;
        List<Color> rangecolors;
        private void btnShowAxis_Click(object sender, EventArgs e)
        {
            isAxisVisible = !isAxisVisible;
            redrawScene();
            btnShowAxis.Text = isAxisVisible ? "Скрыть оси" : "Показать оси";
        }

        /// <summary>
        /// Рисует фигуры на канвасе, выделяя цветом выбранную фигуру
        /// </summary>
        /// <param name="shape">Фигура, которую надо нарисовать</param>
        void drawShape(Shape shape, Pen pen)
        {
            foreach (var face in shape.Faces)
            {
                drawFace(face, pen);
            }
        }

        /// <summary>
        /// Рисует заданную границу грани заданным цветом
        /// </summary>
        /// <param name="face">Грань, которую надо нарисовать</param>
        /// <param name="pen">Цвет границы</param>
        void drawFace(Face face, Pen pen)
        {
            for (var i = 0; i < face.Vertices.Count; i++)
            {
                drawLine(face.Vertices[i],face.Vertices[(i+1) % face.Vertices.Count], pen);
            }
            // TODO: Здесь можно включить отображение нормалей грани
            // var norm = face.NormVector;
            //drawLine(face.getCenter(), new Point((int)(face.getCenter().Xf + norm.x * 50), (int)(face.getCenter().Yf + norm.y * 50), (int)(face.getCenter().Zf + norm.z * 50)), new Pen(Color.GreenYellow));
        }

        /// <summary>
        /// Рисует линию, переводя её координаты из 3D в 2D
        /// </summary>
        /// <param name="line">Линия, которую надо нарисовать</param>
        /// <param name="end"></param>
        /// <param name="pen">Цвет линии</param>
        /// <param name="start"></param>
        void drawLine(Point start, Point end, Pen pen)
        {
            var pf1 = start.to2D(camera).Item1;
            var pf2 = end.to2D(camera).Item1;
            if(pf1.HasValue && pf2.HasValue)
            {
                AdditionalAlgorithms.drawVuLine(ref fbitmap, new System.Drawing.Point((int)pf1.Value.X, (int)(pf1.Value.Y)), new System.Drawing.Point((int)pf2.Value.X, (int)(pf2.Value.Y)), pen.Color);
            }
        }
        void DrawPoint(Point p)
        {
            AdditionalAlgorithms.drawVuLine(ref fbitmap,new System.Drawing.Point((int)p.X, (int)(p.Y)), new System.Drawing.Point((int)(p.X+10), (int)(p.Y+10)), Color.DarkSeaGreen);
            AdditionalAlgorithms.drawVuLine(ref fbitmap,new System.Drawing.Point((int)(p.X+10), (int)(p.Y)), new System.Drawing.Point((int)(p.X), (int)(p.Y+10)), Color.DarkSeaGreen);
        }

        /// <summary>
        /// Рисует коодинатные прямые (с подписями) и подписывает координаты каждой точки
        /// </summary>
        void drawAxis()
        {
            var worldCenter = new Point(0, 0, 0);
            var axisX = new Point(300, 0, 0);
            var axisY = new Point(0, 300, 0);
            var axisZ = new Point(0, 0, 300);
            drawLine(worldCenter,axisX, new Pen(Color.Red, 4));
            drawLine(worldCenter,axisY, new Pen(Color.Blue, 4));
            drawLine(worldCenter,axisZ, new Pen(Color.Green, 4));
        }

        /// <summary>
        /// Перерисовывает всю сцену
        /// </summary>
        void redrawScene()
        {
            var bitmap = new Bitmap(canvas.Width,canvas.Height);
            fbitmap = new FastBitmap(bitmap);
            if (isAxisVisible)
            {
                drawAxis();
            }
            for (int i = 0; i < sceneShapes.Count; i++)
            {
                if(i == listBox.SelectedIndex)
                {
                    drawShape(sceneShapes[i], highlightPen);
                    continue;
                }
                drawShape(sceneShapes[i], blackPen);
            }
            drawLine(camera.cameraPosition, new Point(camera.cameraPosition.Xf + camera.cameraDirection.x * 50, camera.cameraPosition.Yf + camera.cameraDirection.y * 50, camera.cameraPosition.Zf + camera.cameraDirection.z * 50), new Pen(Color.CadetBlue));
            drawLine(camera.cameraPosition, new Point(camera.cameraPosition.Xf + camera.cameraRight.x * 50, camera.cameraPosition.Yf + camera.cameraRight.y * 50, camera.cameraPosition.Zf + camera.cameraRight.z * 50), new Pen(Color.DarkOrange));
            drawLine(camera.cameraPosition, new Point(camera.cameraPosition.Xf + camera.cameraUp.x * 50, camera.cameraPosition.Yf + camera.cameraUp.y * 50, camera.cameraPosition.Zf + camera.cameraUp.z * 50), new Pen(Color.Violet));
            List<Point> lig= Z_buffer.ProjectionToPlane(new List<Point> { lightSource.Position },camera);
            //DrawPoint(lig[0]);

            fbitmap.Dispose();
            String text = "x:";
            text += lightSource.Position.Xf.ToString();
           
            text += "y:";
            text += lightSource.Position.Yf.ToString();
            
            text += "z:";
            text += lightSource.Position.Zf.ToString();
            
            label10.Text = text;
            canvas.Image = bitmap;
        }
        /// <summary>
        /// Генерирует множество цветов
        /// </summary>
        List<Color> GenerateColors()
        {
            List<Color> res = new List<Color>();
           Random r;
            r= new Random();//Environment.TickCount
            for (int i = 0; i < 50; ++i)
               res.Add(Color.FromArgb(r.Next(0, 255), r.Next(0, 100), r.Next(10, 255)));
            return res;
        }
    }
}
