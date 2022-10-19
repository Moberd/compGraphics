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
            Point p1 = polygonPoints[0];
            Point p2 = polygonPoints[1];
            Point pnew = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);//ищем центр отрезка
            rotateAroundPoint(pnew, canvas.Size);//поворачиваем
            g.Clear(Color.White);
            drawLineWithDot(polygonPoints[0], polygonPoints[1]);
            textAngle.Clear();//для последующей работы


        }

        private void buttonCrossLines_Click(object sender, EventArgs e)
        {
            twolinesmode++;
            
        }
        Tuple<int, int, int> GetFunc(Point p1, Point p2)//чтобы получить коэффициенты уравнения, через которое проходит прямая
        {
            /*int slope_point = (p2.Y - p1.Y) / (p2.X - p1.X);
            int a = -slope_point;
            int b = 1;
            int c = -p1.Y + slope_point * p1.X;*/

            int coef1 = p1.Y - p2.Y;
            int coef2 =p2.X - p1.X;
            int coef3 = p1.X * p2.Y - p2.X * p1.Y;
             return Tuple.Create(coef1, coef2, coef3);
          
        }
        Point CrossLines()
        {
             int count = polygonPoints.Count();
             Point p1 = polygonPoints[0];
             Point p2 = polygonPoints[1];
             Point p3 = polygonPoints[2];
             Point p4 = polygonPoints[3];
            /* Point res;
            
             //уравнение прямой
             int n;
             if (p2.Y - p1.Y != 0)
             {
                   // a(y)
                 int q = (p2.X - p1.X) / (p1.Y - p2.Y);
                 int sn = (p3.X - p4.X) + (p3.X - p4.X) * q;
                     if (sn<0)
                 {
                     return new Point(int.MaxValue,int.MaxValue);
                     }  // c(x) + c(y)*q
                 int fn = (p3.X - p1.X) + (p3.Y - p1.X) * q;   // b(x) + b(y)*q
                 n = fn / sn;
             }
             else
             {
                 if ((p3.Y - p4.Y)<0)
                 { 
                     return new Point(int.MaxValue, int.MaxValue);
                 }  // b(y)
                 n = (p3.Y - p1.Y) / (p3.Y - p4.Y);   // c(y)/b(y)
             }
             int x = p3.X + (p4.X - p3.X) * n;  // x3 + (-b(x))*n
             int y = p3.Y + (p4.Y - p3.Y) * n;  // y3 +(-b(y))*n

             return new Point(x,y);
            */
            (int a1, int b1, int c1) = GetFunc(p1, p2);
            (int a2, int b2, int c2) = GetFunc(p3, p4);
            int divisor = a1 * b2 - a2 * b1;
            if (divisor == 0)
                return new Point(int.MaxValue, int.MaxValue);
            int x = (b1 * c2 - b2 * c1) / divisor;
            int y = (c1 * a2 - c2 * a1) / divisor;
            return new Point(x, y);
        }


    }
}
