using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKek
{
   
    partial class Form1
    {
        private void buttonRotateLine_Click(object sender, EventArgs e)
        {
           // buttonСhooseCentre.Visible = false;
            textAngle.Text = "90";//по условию, повернуть ребро вокруг центра на 90 градусов
            //координата центра отрезка
            PointF p1 = polygonPoints[0];
            PointF p2 = polygonPoints[1];
            PointF pnew = new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);//ищем центр отрезка
            rotateAroundPoint(pnew, canvas.Size);//поворачиваем
            g.Clear(Color.White);
            drawLineWithDot(polygonPoints[0], polygonPoints[1]);
            textAngle.Clear();//для последующей работы


        }

        private void buttonCrossLines_Click(object sender, EventArgs e)
        {
            twolinesmode++;
            
        }
        Tuple<float, float, float> GetFunc(PointF p1, PointF p2)//чтобы получить коэффициенты уравнения, через которое проходит прямая
        {
            float coef1 = p1.Y - p2.Y;
            float coef2 =p2.X - p1.X;
            float coef3 = p1.X * p2.Y - p2.X * p1.Y;
            return Tuple.Create(coef1, coef2, coef3);
        }
        PointF CrossLines()
        {
            int count = polygonPoints.Count();
            PointF p1 = polygonPoints[0];
            PointF p2 = polygonPoints[1];
            PointF p3 = polygonPoints[2];
            PointF p4 = polygonPoints[3];
            (float a1, float b1, float c1) = GetFunc(p1, p2);
            (float a2, float b2, float c2) = GetFunc(p3, p4);
            float divisor = a1 * b2 - a2 * b1;
            if (divisor == 0)
                return new PointF(int.MaxValue, int.MaxValue);
            float x = (b1 * c2 - b2 * c1) / divisor;
            float y = (c1 * a2 - c2 * a1) / divisor;
            return new PointF(x, y);
        }


    }
}
